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
Imports instat.Translations

Public Class ucrDataFrame
    Public CurrentColumnList As ucrNewColumnName

    Private Sub ucrDataFrame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.clsRLink.FillComboDataFrames(cboAvailableDataFrames)
    End Sub



    Public Sub SetColumnList(ColumnList As ucrNewColumnName)
        CurrentColumnList = ColumnList
        UpdateColumnList()
    End Sub

    Public Event DataFrameChanged(sender As Object, e As EventArgs)

    Private Sub cboAvailableDataFrames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAvailableDataFrames.SelectedIndexChanged
        UpdateColumnList()
        RaiseEvent DataFrameChanged(sender, e)
    End Sub

    Public Sub UpdateColumnList()
        If CurrentColumnList IsNot Nothing Then
            frmMain.clsRLink.FillColumnNames(cboAvailableDataFrames.SelectedItem, cboColumns:=CurrentColumnList.cboColumnName)
            CurrentColumnList.SetDefaultName(cboAvailableDataFrames.Text)
        End If
    End Sub
End Class
