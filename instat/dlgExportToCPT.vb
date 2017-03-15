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
Imports System.IO
Imports instat.Translations
Public Class dlgExportToCPT
    Dim bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsOutPut As New RFunction
    Private Sub dlgExportToCPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOkEnabled()
    End Sub

    Private Sub ReopenDialog()

    End Sub

    Private Sub SetDefaults()
        Dim clsDefaultFunction As New RFunction
        ucrInputExportFile.IsReadOnly = True
        ucrInputExportFile.SetName("")
        ucrSSTDataframe.Reset()
        ucrLocationDataFrame.Reset()
        ucrReceiverYears.SetMeAsReceiver()
        ucrChkLong.Checked = True
        clsDefaultFunction.SetRCommand("rio::export")
        clsDefaultFunction.AddParameter("x", clsRFunctionParameter:=clsOutPut)
        clsDefaultFunction.AddParameter("sep", Chr(34) & "\t" & Chr(34))
        clsDefaultFunction.AddParameter("quote", "FALSE")
        clsDefaultFunction.AddParameter("row.names", "FALSE")
        clsDefaultFunction.AddParameter("col.names", "TRUE")
        ucrBaseExportToCPT.clsRsyntax.SetBaseRFunction(clsDefaultFunction.Clone())
    End Sub

    Private Sub InitialiseDialog()
        ucrBaseExportToCPT.iHelpTopicID = 355
        clsOutPut.SetRCommand("output_for_CPT")

        ucrSSTDataframe.SetParameter(New RParameter("data_name", 0))
        ucrSSTDataframe.SetParameterIsrfunction()

        ucrLocationDataFrame.SetParameter(New RParameter("lat_lon_data", 1))
        ucrLocationDataFrame.SetParameterIsRFunction()
        ucrLocationDataFrame.lblDataFrame.Size = New System.Drawing.Size(120, 13)
        ucrLocationDataFrame.lblDataFrame.Text = "Location Data Frame:"

        ucrReceiverMultipleDataColumns.Selector = ucrSSTDataframe
        ucrReceiverMultipleDataColumns.SetParameter(New RParameter("sst_cols"))
        ucrReceiverMultipleDataColumns.SetParameterIsString()
        ucrReceiverMultipleDataColumns.SetLinkedDisplayControl(lblDataColumns)

        ucrReceiverDataColumn.Selector = ucrSSTDataframe
        ucrReceiverDataColumn.SetParameter(New RParameter("sst_cols"))
        ucrReceiverDataColumn.SetParameterIsString()
        ucrReceiverDataColumn.SetLinkedDisplayControl(lblDataColumn)

        ucrReceiverYears.Selector = ucrSSTDataframe
        ucrReceiverYears.SetParameter(New RParameter("year_col"))
        ucrReceiverYears.SetParameterIsString()

        ucrReceiverStations.Selector = ucrSSTDataframe
        ucrReceiverStations.SetParameter(New RParameter("station_col"))
        ucrReceiverStations.SetParameterIsString()
        ucrReceiverStations.SetLinkedDisplayControl(lblStations)

        ucrInputExportFile.SetParameter(New RParameter("file", 1))

        ucrChkLong.SetParameter(New RParameter("long"))
        ucrChkLong.SetText("Long Data Format")
        ucrChkLong.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkLong.bUpdateRCodeFromControl = True

        ucrChkLong.AddToLinkedControls(ucrReceiverMultipleDataColumns, {False}, bNewLinkedAddRemoveParameter:=False, bNewLinkedHideIfParameterMissing:=True)
        ucrChkLong.AddToLinkedControls(ucrReceiverDataColumn, {True}, bNewLinkedAddRemoveParameter:=False, bNewLinkedHideIfParameterMissing:=True)
        ucrChkLong.AddToLinkedControls(ucrReceiverStations, {True}, bNewLinkedHideIfParameterMissing:=True)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrChkLong.SetRCode(clsOutPut, bReset)
        ucrSSTDataframe.SetRCode(clsOutPut, bReset)
        ucrLocationDataFrame.SetRCode(clsOutPut, bReset)
        ucrReceiverYears.SetRCode(clsOutPut, bReset)
        ucrReceiverMultipleDataColumns.SetRCode(clsOutPut, bReset)
        ucrReceiverDataColumn.SetRCode(clsOutPut, bReset)
        ucrReceiverStations.SetRCode(clsOutPut, bReset)
        ucrInputExportFile.SetRCode(ucrBaseExportToCPT.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub TestOkEnabled()
        'checking that the data frames are different is here temporarily since lat-lon information will be obtained from metadata
        If (ucrLocationDataFrame.cboAvailableDataFrames.Text <> "" AndAlso Not ucrSSTDataframe.ucrAvailableDataFrames.strCurrDataFrame = ucrLocationDataFrame.cboAvailableDataFrames.SelectedItem AndAlso Not ucrInputExportFile.IsEmpty AndAlso (Not ucrReceiverYears.IsEmpty) AndAlso ((ucrChkLong.Checked AndAlso (Not ucrReceiverStations.IsEmpty) AndAlso (Not ucrReceiverDataColumn.IsEmpty)) OrElse ((Not ucrChkLong.Checked) AndAlso (Not ucrReceiverMultipleDataColumns.IsEmpty)))) Then
            ucrBaseExportToCPT.OKEnabled(True)
        Else
            ucrBaseExportToCPT.OKEnabled(False)
        End If
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim dlgSave As New SaveFileDialog
        dlgSave.Title = "Export file dialog"
        dlgSave.InitialDirectory = frmMain.clsInstatOptions.strWorkingDirectory
        dlgSave.Filter = "Text separated file (*.txt)|*.txt"
        If dlgSave.ShowDialog = DialogResult.OK Then
            If dlgSave.FileName <> "" Then
                ucrInputExportFile.SetName(Path.GetFullPath(dlgSave.FileName).ToString.Replace("\", "/"))
            End If
        End If
    End Sub

    Private Sub ucrInputExportFile_Click(sender As Object, e As EventArgs) Handles ucrInputExportFile.Click
        cmdBrowse_Click(sender, e)
    End Sub

    Private Sub ucrBaseExportToCPT_ClickReset(sender As Object, e As EventArgs) Handles ucrBaseExportToCPT.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub ucrInputExportFile_ControlContentsChanged(ucrchangedControl As ucrCore) Handles ucrInputExportFile.ControlContentsChanged, ucrSSTDataframe.ControlContentsChanged, ucrLocationDataFrame.ControlContentsChanged, ucrReceiverDataColumn.ControlContentsChanged, ucrReceiverMultipleDataColumns.ControlContentsChanged, ucrReceiverStations.ControlContentsChanged, ucrReceiverYears.ControlContentsChanged
        ucrBaseExportToCPT.clsRsyntax.AddParameter("x", clsRFunctionParameter:=clsOutPut)
        TestOkEnabled()
    End Sub

    Private Sub ucrChkLong_ControlContentsChanged(ucrchangedControl As ucrCore) Handles ucrChkLong.ControlContentsChanged
        ucrReceiverYears.SetMeAsReceiver()
        ucrBaseExportToCPT.clsRsyntax.AddParameter("x", clsRFunctionParameter:=clsOutPut)
    End Sub
End Class