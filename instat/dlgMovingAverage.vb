﻿' R- Instat
' Copyright (C) 2015-2017
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
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations

Public Class dlgMovingAverage
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True

    Private Sub dlgMovingAverage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub InitialiseDialog()
        ucrBase.clsRsyntax.iCallType = 1

        ' ucrReceiver
        ucrReceiverDataToAverage.SetParameter(New RParameter("x", 0))
        ucrReceiverDataToAverage.SetParameterIsRFunction()
        ucrReceiverDataToAverage.Selector = ucrAddRemove
        ucrReceiverDataToAverage.SetMeAsReceiver()

        'chks
        ucrChkDisplayResults.SetText("Display Results")
        ucrChkLag.SetText("Lag")
        ucrChkPlot.SetText("Plot")
        ucrChkSaveResiduals.SetText("Save Residuals")

        'ucrSave
        ucrSaveResultsInto.SetCheckBoxText("Save Results into:")
        ucrSaveResultsInto.SetIsComboBox()

        ucrBase.OKEnabled(False)
        TestOKEnabled()
    End Sub

    Private Sub SetDefaults()
        Dim clsDefaultFunction As New RFunction

        ucrAddRemove.Reset()

        'Define the default RFunction
        clsDefaultFunction.SetRCommand("ma")

        ' Set default RFunction as the base function
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction.Clone())
    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub TestOKEnabled()
    End Sub
End Class