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
Public Class dlgExportRWorkspace
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsDefaultFunction As New RFunction
    Private Sub dlgExportRWorkspace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub InitialiseDialog()

        ucrSelectorForDataFrames.SetParameter(New RParameter("x", 0))

        ucrReceiverMultiple.Selector = ucrSelectorForDataFrames
        ucrReceiverMultiple.SetParameter(New RParameter("data_name", 1))
        ucrReceiverMultiple.SetParameterIsRFunction()

        ucrChkMetadata.SetParameter(New RParameter("metadata", 2))
        ucrChkMetadata.SetText("Metadata")
        ucrChkMetadata.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkMetadata.SetRDefault("FALSE")


        ucrChkGraphs.SetParameter(New RParameter("graphs", 3))
        ucrChkGraphs.SetText("Graphs")
        ucrChkGraphs.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkGraphs.SetRDefault("FALSE")

        ucrChkModels.SetParameter(New RParameter("models", 4))
        ucrChkModels.SetText("Models")
        ucrChkModels.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkModels.SetRDefault("FALSE")


    End Sub

    Private Sub SetDefaults()
        clsDefaultFunction = New RFunction
        ucrInputExportFile.IsReadOnly = True
        ucrInputExportFile.SetName("")
        ucrSelectorForDataFrames.Reset()
        ucrReceiverMultiple.SetMeAsReceiver()

        clsDefaultFunction.SetRCommand("export_workspace")
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction)
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim dlgSave As New SaveFileDialog

        dlgSave.Title = "Export file dialog"
        dlgSave.InitialDirectory = frmMain.clsInstatOptions.strWorkingDirectory
        dlgSave.Filter = "Saved r objects (*.RData)|*.RData"
        If dlgSave.ShowDialog = DialogResult.OK Then
            If dlgSave.FileName <> "" Then
                ucrInputExportFile.SetName(Path.GetFullPath(dlgSave.FileName).ToString.Replace("\", "/"))
            End If
        End If
    End Sub

    Private Sub ucrInputExportFile_Click(sender As Object, e As EventArgs) Handles ucrInputExportFile.Click
        cmdBrowse_Click(sender, e)
    End Sub

    Private Sub TestOkEnabled()
        If Not ucrInputExportFile.IsEmpty AndAlso Not ucrReceiverMultiple.IsEmpty AndAlso ucrSelectorForDataFrames.Text <> "" Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrInputExportFile_ControlContentsChanged(ucrchangedControl As ucrCore) Handles ucrInputExportFile.ControlContentsChanged, ucrReceiverMultiple.ControlContentsChanged, ucrSelectorForDataFrames.ControlContentsChanged
        TestOkEnabled()
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

End Class