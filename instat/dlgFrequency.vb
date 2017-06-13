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
Public Class dlgFrequency
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsDefaultFunction As New RFunction
    Private clsSummaryCount As New RFunction
    Private bResetSubdialog As Boolean = False
    Private lstCheckboxes As New List(Of ucrCheck)

    Private Sub dlgFrequency_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
        TestOkEnabled()
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.clsRsyntax.iCallType = 2

        ucrSelectorFrequency.SetParameter(New RParameter("data_name", 0))
        ucrSelectorFrequency.SetParameterIsString()

        ucrReceiverFactors.SetParameter(New RParameter("factors", 3))
        ucrReceiverFactors.SetParameterIsString()
        ucrReceiverFactors.Selector = ucrSelectorFrequency
        ucrReceiverFactors.SetDataType("factor")
        ucrReceiverFactors.SetMeAsReceiver()

        ucrNudColumnFactors.SetParameter(New RParameter("n_column_factors", 4))
        ucrNudColumnFactors.SetRDefault(0)

        ucrChkStoreResults.SetParameter(New RParameter("store_results", 5))
        ucrChkStoreResults.SetText("Store Results in Data Frame")
        ucrChkStoreResults.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkStoreResults.SetRDefault("TRUE")

        ucrChkOmitMissing.SetParameter(New RParameter("na.rm", 7))
        ucrChkOmitMissing.SetText("Omit Missing Values")
        ucrChkOmitMissing.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkOmitMissing.SetRDefault("FALSE")

        '8: summary_name = NA

        ucrChkDisplayMargins.SetParameter(New RParameter("include_margins", 9))
        ucrChkDisplayMargins.SetText("Display Margins")
        ucrChkDisplayMargins.SetRDefault("FALSE")

        'ucrChkPrintOutput.SetParameter(New RParameter("return_output", 10))
        'ucrChkPrintOutput.SetText("Print to Output Window")
        'ucrChkPrintOutput.SetRDefault("TRUE")

        ucrChkSummaries.Enabled = False ' temporary
        ucrChkSummaries.SetParameter(New RParameter("treat_columns_as_factor", 11))
        ucrChkSummaries.SetText("Treat Summary Columns as a Further Factor")
        ucrChkSummaries.SetRDefault("FALSE")

        ' For the page_by option:
        'temp disabled, not yet implemented in R function
        'ucrInputPageBy.SetParameter(New RParameter("page_by", 12))
        'temp added to prevent developer error while disabled
        'dctPageBy.Add("None", "NULL")
        'dctPageBy.Add("Variables", Chr(34) & "variables" & Chr(34))
        'dctPageBy.Add("Summaries", Chr(34) & "summaries" & Chr(34))
        'dctPageBy.Add("Variables and Summaries", "c(" & Chr(34) & "variables" & Chr(34) & "," & Chr(34) & "summaries" & Chr(34) & ")")
        'dctPageBy.Add("Default", Chr(34) & "default" & Chr(34))
        'ucrInputPageBy.SetItems(dctPageBy)
        'ucrInputPageBy.SetRDefault(Chr(34) & "default" & Chr(34))

        ucrChkHTMLTable.SetParameter(New RParameter("as_html", 13))
        ucrChkHTMLTable.SetText("HTML Table")
        ucrChkHTMLTable.SetRDefault("TRUE")

        ucrNudSigFigs.SetParameter(New RParameter("signif_fig", 14))
        ucrNudSigFigs.SetRDefault(2)

        ucrInputNA.SetParameter(New RParameter("na_display", 15))
        ucrInputNA.SetRDefault(Chr(34) & Chr(34))

        '16: na_level_display = "NA"

        ucrChkWeights.Enabled = False ' Temporary, parameter position = 17, name = "weights"
        ucrChkWeights.SetText("Weights")
        ucrChkWeights.SetRDefault("NULL")
        ucrChkWeights.AddToLinkedControls(ucrReceiverSingle, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        '18: caption = NULL
        '19 result_names = NULL

        '2: summaries,
        '   alltypes_collection <- c(count_non_missing_label, count_missing_label, count_label, mode_label)
        '       numeric_collection <- c(count_non_missing_label, count_missing_label, count_label, mode_label, min_label, max_label, mean_label, sd_label, range_label, median_label, sum_label, var_label)
        '       factor_collection <- c(count_non_missing_label, count_missing_label, count_label, mode_label) #maximum and minimum labels should be added when we distinguish ordered factors
        '       ordered_factor_collection <- c(count_non_missing_label, count_missing_label, count_label, mode_label, min_label, max_label)




        '20: percentage_type = "none", 21: perc_total_columns = NULL
        '22: perc_total_factors = c(), 23: perc_total_filter = NULL, 25: perc_decimal = False, ...) {


        'ucrChkOverallPercentages.SetText("Overall Percentages")
        'ucrChkPercentagesOf.SetText("Percentages of")

        'ucrChkPercentagesOf.AddToLinkedControls(ucrSingleReceiver, {True}, bNewLinkedHideIfParameterMissing:=True)
        'ucrNudColumnFactors.SetMinMax(0, frmMain.clsRLink.GetDataFrameLength(ucrSelectorFrequency.ucrAvailableDataFrames.cboAvailableDataFrames.Text))
        'ucrNudDecimals.SetMinMax(0, 5)

        ''lstCheckboxes = New List(Of ucrCheck)
        ''lstCheckboxes.AddRange({ucrChkCounts}) ' add in here percentages, etc too?
        ''For Each ctrTemp As ucrCheck In lstCheckboxes
        ''    ctrTemp.SetParameterValue(Chr(34) & ctrTemp.GetParameter().strArgumentName & Chr(34))
        ''    ctrTemp.SetParameterIncludeArgumentName(False)
        ''Next
    End Sub

    Private Sub SetDefaults()
        clsDefaultFunction = New RFunction
        clsSummaryCount = New RFunction

        ucrReceiverFactors.SetMeAsReceiver()
        ucrSelectorFrequency.Reset()
        ucrSaveTable.Reset()
        ucrSaveTable.SetName("summary_table") ' change this to prefix later. currently, if this is prefix then it is blank

        clsSummaryCount.SetRCommand("c")
        clsSummaryCount.AddParameter("count_label", "count_label", bIncludeArgumentName:=False) ' TODO decide which default(s) to use?

        clsDefaultFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$summary_table")
        clsDefaultFunction.AddParameter("summaries", clsRFunctionParameter:=clsSummaryCount, iPosition:=2)
        clsDefaultFunction.AddParameter("store_results", "FALSE", iPosition:=5)
        clsDefaultFunction.AddParameter("rnames", "FALSE", iPosition:=18)
        clsDefaultFunction.SetAssignTo("last_table", strTempDataframe:=ucrSelectorFrequency.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempTable:="last_table")

        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction)
        bResetSubdialog = True

    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)

        ucrChkCounts.SetRCode(clsSummaryCount, bReset)
    End Sub

    Private Sub TestOkEnabled()
        If Not ucrReceiverFactors.IsEmpty AndAlso (Not ucrChkWeights.Checked OrElse (ucrChkWeights.Checked AndAlso Not ucrSingleReceiver.IsEmpty)) AndAlso (ucrChkCounts.Checked OrElse ucrChkOverallPercentages.Checked OrElse (ucrChkPercentagesOf.Checked AndAlso Not ucrSingleReceiver.IsEmpty)) Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If

    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        sdgFrequency.ShowDialog()
    End Sub

    Private Sub UpdateReceiver()
        If ucrChkWeights.Checked Then
            ucrReceiverSingle.SetMeAsReceiver()
        ElseIf ucrChkPercentagesOf.Checked Then
            ucrSingleReceiver.SetMeAsReceiver()
        Else
            ucrReceiverFactors.SetMeAsReceiver()
        End If
    End Sub

    Private Sub ucrchkOverallPercentages_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrChkWeights.ControlValueChanged, ucrChkPercentagesOf.ControlValueChanged
        UpdateReceiver()
    End Sub

    Private Sub ucrCoreControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverSingle.ControlContentsChanged, ucrReceiverFactors.ControlContentsChanged, ucrSingleReceiver.ControlContentsChanged, ucrChkWeights.ControlContentsChanged, ucrChkPercentagesOf.ControlContentsChanged
        TestOkEnabled()
    End Sub
End Class