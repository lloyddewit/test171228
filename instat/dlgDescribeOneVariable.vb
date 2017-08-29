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

Public Class dlgDescribeOneVariable
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsSummaryFunction, clsSummariesList, clsInstatSummaryFunction As New RFunction
    Private bResetSubdialog As Boolean = False

    Private Sub dlgDescriptiveStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOKEnabled()
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBaseDescribeOneVar.iHelpTopicID = 410
        ucrBaseDescribeOneVar.clsRsyntax.iCallType = 2

        'The selector is only used for one of the functions. Therefore it's parameter name is always the same. So this can be done in Initialise.
        ucrSelectorDescribeOneVar.SetParameter(New RParameter("data_name", 0))
        ucrSelectorDescribeOneVar.SetParameterIsString()

        ucrReceiverDescribeOneVar.SetParameter(New RParameter("object", 0))
        ucrReceiverDescribeOneVar.SetParameterIsRFunction()
        ucrReceiverDescribeOneVar.Selector = ucrSelectorDescribeOneVar
        ucrReceiverDescribeOneVar.SetMeAsReceiver()

        ucrNudMaxSum.SetParameter(New RParameter("maxsum", 2))
        ucrNudMaxSum.SetRDefault("7")

        ucrChkOmitMissing.SetParameter(New RParameter("na.rm", 3))
        ucrChkOmitMissing.SetText("Omit Missing Values")
        ucrChkOmitMissing.SetRDefault("FALSE")
        ucrChkOmitMissing.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkOmitMissing.bUpdateRCodeFromControl = True

        ucrChkCustomise.SetText("Customise")
        ucrChkCustomise.AddFunctionNamesCondition(True, frmMain.clsRLink.strInstatDataObject & "$summary")
        ucrChkCustomise.AddFunctionNamesCondition(False, "summary")
        ucrChkCustomise.AddToLinkedControls(ucrNudMaxSum, {False}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudMaxSum.SetLinkedDisplayControl(lblMaxSum)

        ucrChkSaveResult.SetText("Save Result") 'this is disabled in the initial implementation
        ucrChkSaveResult.Enabled = False
        'ucrChkSaveResult.SetParameter(New RParameter("store_results"))
        'ucrChkSaveResult.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        'ucrChkSaveResult.SetRDefault("FALSE")
    End Sub

    Private Sub SetDefaults()
        clsSummariesList = New RFunction
        clsSummaryFunction = New RFunction
        clsInstatSummaryFunction = New RFunction
        cmdSummaries.Enabled = False

        ucrSelectorDescribeOneVar.Reset()

        clsSummariesList.SetRCommand("c")
        clsSummariesList.AddParameter("summary_count_non_missing", Chr(34) & "summary_count_non_missing" & Chr(34), bIncludeArgumentName:=False)
        clsSummariesList.AddParameter("summary_count", Chr(34) & "summary_count" & Chr(34), bIncludeArgumentName:=False)
        clsSummariesList.AddParameter("summary_sum", Chr(34) & "summary_sum" & Chr(34), bIncludeArgumentName:=False)

        clsSummaryFunction.SetRCommand("summary")
        clsSummaryFunction.AddParameter("maxsum", 7)
        clsSummaryFunction.AddParameter("na.rm", "FALSE", iPosition:=3)

        clsInstatSummaryFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$summary")
        clsInstatSummaryFunction.AddParameter("return_output", "TRUE")
        clsInstatSummaryFunction.AddParameter("summaries", clsRFunctionParameter:=clsSummariesList)

        ucrBaseDescribeOneVar.clsRsyntax.SetBaseRFunction(clsSummaryFunction)
        bResetSubdialog = True
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrChkOmitMissing.AddAdditionalCodeParameterPair(clsInstatSummaryFunction, ucrChkOmitMissing.GetParameter(), iAdditionalPairNo:=1)
        ucrNudMaxSum.SetRCode(clsSummaryFunction, bReset)
        ucrReceiverDescribeOneVar.SetRCode(clsSummaryFunction, bReset)
        ucrChkOmitMissing.SetRCode(clsSummaryFunction, bReset)
        ucrChkCustomise.SetRCode(ucrBaseDescribeOneVar.clsRsyntax.clsBaseFunction, bReset)
        ucrSelectorDescribeOneVar.SetRCode(clsInstatSummaryFunction, bReset)
    End Sub

    Public Sub TestOKEnabled()
        'We cannot test the values on the sub dialog because the sub dialog may not be in sync with the main dialog code. This only happens once the sub dialog has been opened.
        If ucrReceiverDescribeOneVar.IsEmpty() OrElse (ucrChkCustomise.Checked AndAlso clsSummariesList.clsParameters.Count = 0) OrElse ucrNudMaxSum.GetText = "" Then
            ucrBaseDescribeOneVar.OKEnabled(False)
        Else
            ucrBaseDescribeOneVar.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBaseDescribeOneVar_ClickReset(sender As Object, e As EventArgs) Handles ucrBaseDescribeOneVar.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub cmdSummaries_Click(sender As Object, e As EventArgs) Handles cmdSummaries.Click
        sdgSummaries.SetRFunction(clsSummariesList, bResetSubdialog)
        bResetSubdialog = False
        sdgSummaries.ShowDialog()
        TestOKEnabled()
    End Sub

    Private Sub ChangeBaseFunction()
        If ucrChkCustomise.Checked Then
            ucrBaseDescribeOneVar.clsRsyntax.SetBaseRFunction(clsInstatSummaryFunction)
            cmdSummaries.Enabled = True
        Else
            ucrBaseDescribeOneVar.clsRsyntax.SetBaseRFunction(clsSummaryFunction)
            cmdSummaries.Enabled = False
        End If
        'We need to update the base function to include the 
        'ucrBaseDescribeOneVar.clsRsyntax.clsBaseFunction.AddParameter(ucrChkOmitMissing.GetParameter())
    End Sub

    Private Sub ucrReceiverDescribeOneVar_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverDescribeOneVar.ControlValueChanged
        If Not ucrReceiverDescribeOneVar.IsEmpty Then
            clsInstatSummaryFunction.AddParameter("columns_to_summarise", ucrReceiverDescribeOneVar.GetVariableNames())
        Else
            clsInstatSummaryFunction.RemoveParameterByName("columns_to_summarise")
        End If
    End Sub

    Private Sub ucrChkCustomise_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkCustomise.ControlValueChanged
        ChangeBaseFunction()
    End Sub

    Private Sub Controls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverDescribeOneVar.ControlContentsChanged, ucrChkCustomise.ControlContentsChanged, ucrNudMaxSum.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class
