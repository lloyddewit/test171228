﻿' Instat-R
' Copyright (C) 2015
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License k
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports RDotNet
Public Class ucrReorder
    Public Event OrderChanged()
    Public WithEvents ucrDataFrameList As ucrDataFrame
    Public WithEvents ucrReceiver As ucrReceiverSingle
    Private strDataType As String
    Dim selectedListViewItem As ListViewItem
    Dim selectedIndex As Integer
    Dim itemsCount As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strDataType = ""
        selectedListViewItem = New ListViewItem
    End Sub

    Public Sub setDataType(strType As String)
        strDataType = strType
        lstAvailableData.Clear()
        Select Case strDataType
            Case "column"
                lstAvailableData.Columns.Add("Variables")
                lstAvailableData.Columns(0).Width = -2
            Case "factor"
                lstAvailableData.Columns.Add("Levels")
                lstAvailableData.Columns(0).Width = -2
            Case "data frame"
                lstAvailableData.Columns.Add("Data Frame")
                lstAvailableData.Columns(0).Width = -2
        End Select
        loadList()
    End Sub

    Private Sub cmdUp_Click(sender As Object, e As EventArgs) Handles cmdUp.Click
        If lstAvailableData.Items.Count > 0 And lstAvailableData.SelectedItems.Count > 0 Then
            selectedListViewItem = lstAvailableData.SelectedItems(0)
            selectedIndex = lstAvailableData.SelectedItems.Item(0).Index
            itemsCount = lstAvailableData.Items.Count
            'checks if the item is at the top, if true exits
            If selectedIndex = 0 Then
                Exit Sub
            Else
                lstAvailableData.Items.RemoveAt(selectedIndex)
                lstAvailableData.Items.Insert(selectedIndex - 1, selectedListViewItem)

            End If
            selectedListViewItem.Selected = True
            lstAvailableData.Select()
            selectedListViewItem.EnsureVisible()
            RaiseEvent OrderChanged()
        End If

    End Sub

    Private Sub cmdDown_click(sender As Object, e As EventArgs) Handles cmdDown.Click
        If lstAvailableData.Items.Count > 0 And lstAvailableData.SelectedItems.Count > 0 Then
            selectedListViewItem = lstAvailableData.SelectedItems(0)
            selectedIndex = selectedListViewItem.Index
            itemsCount = lstAvailableData.Items.Count
            'checks if the item is at the bottom, if true exits
            If selectedIndex = itemsCount - 1 Then
                Exit Sub
            Else
                lstAvailableData.Items.Remove(selectedListViewItem)
                lstAvailableData.Items.Insert(selectedIndex + 1, selectedListViewItem)
            End If
            selectedListViewItem.Selected = True
            lstAvailableData.Select()
            selectedListViewItem.EnsureVisible()
            RaiseEvent OrderChanged()
        End If
    End Sub

    Private Sub cmdBottom_Click(sender As Object, e As EventArgs) Handles cmdBottom.Click
        If lstAvailableData.Items.Count > 0 And lstAvailableData.SelectedItems.Count > 0 Then
            selectedListViewItem = lstAvailableData.SelectedItems(0)
            selectedIndex = selectedListViewItem.Index
            itemsCount = lstAvailableData.Items.Count
            'checks if the item is at the bottom, if not moves it to the bottom
            If Not selectedIndex = itemsCount - 1 Then
                lstAvailableData.Items.Remove(selectedListViewItem)
                lstAvailableData.Items.Insert(itemsCount - 1, selectedListViewItem)
            End If
            selectedListViewItem.Selected = True
            lstAvailableData.Select()
            selectedListViewItem.EnsureVisible()
            RaiseEvent OrderChanged()
        End If
    End Sub

    Private Sub cmdTop_Click(sender As Object, e As EventArgs) Handles cmdTop.Click
        If lstAvailableData.Items.Count > 0 And lstAvailableData.SelectedItems.Count > 0 Then
            selectedListViewItem = lstAvailableData.SelectedItems(0)
            selectedIndex = selectedListViewItem.Index
            itemsCount = lstAvailableData.Items.Count
            'checks if the item is at the top, if not moves it to the top
            If Not selectedIndex = 0 Then
                lstAvailableData.Items.Remove(selectedListViewItem)
                lstAvailableData.Items.Insert(0, selectedListViewItem)
            End If
            selectedListViewItem.Selected = True
            lstAvailableData.Select()
            selectedListViewItem.EnsureVisible()
            RaiseEvent OrderChanged()
        End If
    End Sub

    Public Function GetVariableNames(Optional bWithQuotes As Boolean = True) As String
        Dim strTemp As String = ""
        Dim i As Integer
        If lstAvailableData.Items.Count = 1 Then
            If bWithQuotes Then
                strTemp = Chr(34) & lstAvailableData.Items(0).Text & Chr(34)
            Else
                strTemp = lstAvailableData.Items(0).Text
            End If
        ElseIf lstAvailableData.Items.Count > 1 Then
            strTemp = "c" & "("
            For i = 0 To lstAvailableData.Items.Count - 1
                If i > 0 Then
                    strTemp = strTemp & ","
                End If
                If lstAvailableData.Items(i).Text <> "" Then
                    If bWithQuotes Then
                        strTemp = strTemp & Chr(34) & lstAvailableData.Items(i).Text & Chr(34)
                    Else
                        strTemp = strTemp & lstAvailableData.Items(i).Text
                    End If
                End If
            Next
            strTemp = strTemp & ")"
        End If

        Return strTemp
    End Function

    Public Sub setDataframes(dfDataframes As ucrDataFrame)
        ucrDataFrameList = dfDataframes
        loadList()
    End Sub

    Public Sub setReceiver(dfSingle As ucrReceiverSingle)
        ucrReceiver = dfSingle
        loadList()
    End Sub

    Public Sub loadList()
        Dim vecNames As CharacterVector
        Select Case strDataType
            Case "column"
                If ucrDataFrameList IsNot Nothing AndAlso ucrDataFrameList.cboAvailableDataFrames.Text <> "" Then
                    vecNames = frmMain.clsRLink.RunInternalScriptGetValue(frmMain.clsRLink.strInstatDataObject & "$get_column_names(data_name = " & Chr(34) & ucrDataFrameList.cboAvailableDataFrames.SelectedItem & Chr(34) & ")").AsCharacter
                End If
            Case "factor"
                If ucrReceiver IsNot Nothing AndAlso ucrReceiver.lstIncludedDataTypes.Count = 1 AndAlso ucrReceiver.lstIncludedDataTypes.Contains("factor") AndAlso ucrReceiver.GetVariableNames <> "" Then
                    vecNames = frmMain.clsRLink.RunInternalScriptGetValue(frmMain.clsRLink.strInstatDataObject & "$get_column_factor_levels(data_name = " & Chr(34) & ucrReceiver.GetDataName() & Chr(34) & ", col_name = " & ucrReceiver.GetVariableNames() & ")").AsCharacter
                End If
            Case "data frame"
                vecNames = frmMain.clsRLink.RunInternalScriptGetValue(frmMain.clsRLink.strInstatDataObject & "$get_data_names()").AsCharacter
            Case Else
                vecNames = Nothing
        End Select
        FillListView(vecNames)
    End Sub

    Private Sub FillListView(vecNames As CharacterVector)
        If vecNames IsNot Nothing Then
            lstAvailableData.Items.Clear()
            For i = 0 To vecNames.Count - 1
                lstAvailableData.Items.Add(vecNames(i))
            Next
            RaiseEvent OrderChanged()
        End If
    End Sub

    Private Sub ucrDataFrameList_DataFrameChanged(sender As Object, e As EventArgs, strPrevDataFrame As String) Handles ucrDataFrameList.DataFrameChanged
        loadList()
    End Sub

    Private Sub ucrReceiver_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiver.SelectionChanged
        loadList()
    End Sub

    'to update this to check if the order has changed
    Public Function isEmpty() As Boolean
        If lstAvailableData.Items.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
