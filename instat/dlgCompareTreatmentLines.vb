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

Public Class dlgCompareTreatmentLines
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private bResetSubdialog As Boolean = True
    Private bResetBoxLayerSubdialog As Boolean = True
    Private clsCompareLines As New clsCompareTwoOptionsLines

    ' String constants for Context variables
    Public strFacetRow As String = "Facet Row"
    Public strFacetCol As String = "Facet Column"
    Public strNone As String = "None"

    Private Sub dlgCompareTreatmentLines_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeforControls(bReset)
        bReset = False
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()

        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
        'ucrBase.iHelpTopicID = 
        ucrBase.clsRsyntax.iCallType = 3

        ucrSelectorPlot.SetParameter(New RParameter("data", 0))
        ucrSelectorPlot.SetParameterIsrfunction()

        ucrReceiverMeasurement.SetParameter(New RParameter("y", 1))
        ucrReceiverMeasurement.Selector = ucrSelectorPlot
        ucrReceiverMeasurement.SetIncludedDataTypes({"numeric"})
        ucrReceiverMeasurement.strSelectorHeading = "Numerics"
        ucrReceiverMeasurement.SetParameterIsString()
        ucrReceiverMeasurement.bWithQuotes = False

        ucrReceiverOption.SetParameter(New RParameter("right", 1))
        ucrReceiverOption.Selector = ucrSelectorPlot
        ucrReceiverOption.SetIncludedDataTypes({"factor"})
        ucrReceiverOption.strSelectorHeading = "Factors"
        ucrReceiverOption.SetParameterIsString()
        ucrReceiverOption.bWithQuotes = False

        ucrInputFactorOption1.SetParameter(New RParameter("left", 0))
        ucrInputFactorOption1.SetFactorReceiver(ucrReceiverOption)
        ucrInputFactorOption1.AddQuotesIfUnrecognised = False
        ucrInputFactorOption1.strQuotes = "`"

        ucrInputFactorOption2.SetParameter(New RParameter("right", 1))
        ucrInputFactorOption2.SetFactorReceiver(ucrReceiverOption)
        ucrInputFactorOption2.AddQuotesIfUnrecognised = False
        ucrInputFactorOption2.strQuotes = "`"

        ucrReceiverID.SetParameter(New RParameter("left", 0))
        ucrReceiverID.Selector = ucrSelectorPlot
        ucrReceiverID.SetParameterIsString()
        ucrReceiverID.bWithQuotes = False

        clsCompareLines.clsColourParam.SetArgumentName("colour")
        clsCompareLines.clsColourParam.SetArgumentValue(clsCompareLines.strDiffCode)
        clsCompareLines.clsColourParam.Position = 1
        ucrChkColourByDifference.SetText("Colour lines by difference")
        ucrChkColourByDifference.SetParameter(clsCompareLines.clsColourParam)
        ucrChkColourByDifference.bAddRemoveParameter = True
        ucrChkColourByDifference.bChangeParameterValue = False
        ucrChkColourByDifference.AddParameterPresentCondition(True, "colour")
        ucrChkColourByDifference.AddParameterPresentCondition(False, "colour", False)

        ucrChkIncludeBoxplot.SetText("Include Boxplot")
        ucrChkIncludeBoxplot.bAddRemoveParameter = True
        ucrChkIncludeBoxplot.bChangeParameterValue = False
        ucrChkIncludeBoxplot.AddParameterPresentCondition(True, "geom_boxplot")
        ucrChkIncludeBoxplot.AddParameterPresentCondition(False, "geom_boxplot", False)
        ucrChkIncludeBoxplot.AddToLinkedControls(ucrNudTransparency, {True}, bNewLinkedHideIfParameterMissing:=True)
        ucrChkIncludeBoxplot.AddToLinkedControls(ucrChkBoxplotOnlyComplete, {True}, bNewLinkedHideIfParameterMissing:=True)

        ucrNudTransparency.SetLinkedDisplayControl(lblTransparency)
        ucrNudTransparency.SetParameter(New RParameter("alpha", iNewPosition:=1))
        ucrNudTransparency.SetMinMax(0, 1)
        ucrNudTransparency.DecimalPlaces = 2

        ucrChkBoxplotOnlyComplete.SetText("Complete records only")
        ucrChkBoxplotOnlyComplete.bAddRemoveParameter = True
        ucrChkBoxplotOnlyComplete.bChangeParameterValue = False
        ucrChkBoxplotOnlyComplete.AddParameterPresentCondition(True, "right")
        ucrChkBoxplotOnlyComplete.AddParameterPresentCondition(False, "right", False)

        ucrChkIncludeHline.SetText("Include Horizontal Line")
        ucrChkIncludeHline.bAddRemoveParameter = True
        ucrChkIncludeHline.bChangeParameterValue = False
        ucrChkIncludeHline.AddParameterPresentCondition(True, "geom_hline")
        ucrChkIncludeHline.AddParameterPresentCondition(False, "geom_hline", False)
        ucrChkIncludeHline.AddToLinkedControls(ucrInputHlineValue, {True}, bNewLinkedHideIfParameterMissing:=True)

        ucrInputHlineValue.SetParameter(New RParameter("yintercept", iNewPosition:=2))
        ucrInputHlineValue.SetLinkedDisplayControl(lblHlineValue)
        ucrInputHlineValue.SetValidationTypeAsNumeric()
        ucrInputHlineValue.AddQuotesIfUnrecognised = False

        ucrReceiverContext1.Selector = ucrSelectorPlot
        ucrReceiverContext1.SetParameterIsString()
        ucrReceiverContext1.bWithQuotes = False

        ucrReceiverContext2.Selector = ucrSelectorPlot
        ucrReceiverContext2.SetParameterIsString()
        ucrReceiverContext2.bWithQuotes = False

        ucrInputContext1.SetItems({strFacetRow, strFacetCol, strNone})
        ucrInputContext1.SetDropDownStyleAsNonEditable()

        ucrInputContext2.SetItems({strFacetRow, strFacetCol, strNone})
        ucrInputContext2.SetDropDownStyleAsNonEditable()

        ucrSavePlot.SetPrefix("line")
        ucrSavePlot.SetIsComboBox()
        ucrSavePlot.SetCheckBoxText("Save Graph")
        ucrSavePlot.SetSaveTypeAsGraph()
        ucrSavePlot.SetDataFrameSelector(ucrSelectorPlot.ucrAvailableDataFrames)
        ucrSavePlot.SetAssignToIfUncheckedValue("last_graph")
    End Sub

    Private Sub SetDefaults()

        clsCompareLines.SetDefaults()

        ucrSelectorPlot.Reset()
        ucrSelectorPlot.SetGgplotFunction(clsCompareLines.clsBaseOperator)
        ucrReceiverMeasurement.SetMeAsReceiver()

        ucrSavePlot.Reset()
        sdgPlots.Reset()

        bResetSubdialog = True
        bResetBoxLayerSubdialog = True

        ' TODO temporary until can link these controls correctly
        ucrInputContext1.SetName(strNone)
        ucrInputContext2.SetName(strNone)

        SetMergeDataAssignTo()

        clsCompareLines.clsBaseOperator.SetAssignTo("last_graph", strTempDataframe:=ucrSelectorPlot.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempGraph:="last_graph")
        ucrBase.clsRsyntax.SetBaseROperator(clsCompareLines.clsBaseOperator)
    End Sub

    Private Sub SetRCodeforControls(bResetControls As Boolean)
        clsCompareLines.SetRCodeforControls(ucrSelectorPlot, ucrReceiverOption, ucrReceiverID, ucrReceiverMeasurement, ucrInputFactorOption1, ucrInputFactorOption2, ucrChkColourByDifference, ucrChkIncludeBoxplot, ucrNudTransparency, ucrChkBoxplotOnlyComplete, ucrChkIncludeHline, ucrInputHlineValue, bResetControls)
    End Sub

    Private Sub TestOkEnabled()
        If Not ucrReceiverMeasurement.IsEmpty() AndAlso Not ucrReceiverOption.IsEmpty() AndAlso Not ucrInputFactorOption1.IsEmpty() AndAlso Not ucrInputFactorOption2.IsEmpty() AndAlso ucrSavePlot.IsComplete() AndAlso Not ucrReceiverID.IsEmpty() AndAlso (Not ucrChkIncludeBoxplot.Checked OrElse ucrNudTransparency.GetText() <> "") AndAlso (Not ucrChkIncludeHline.Checked OrElse Not ucrInputHlineValue.IsEmpty()) Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeforControls(True)
        TestOkEnabled()
    End Sub

    Private Sub ucrSelectorPlot_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSelectorPlot.ControlValueChanged
        SetMergeDataAssignTo()
    End Sub

    Private Sub ucrReceiverMeasurement_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverMeasurement.ControlValueChanged
        If ucrReceiverMeasurement.IsEmpty() Then
            clsCompareLines.clsDCast.RemoveParameterByName("value.var")
        Else
            clsCompareLines.clsDCast.AddParameter("value.var", ucrReceiverMeasurement.GetVariableNames(), iPosition:=7)
        End If
    End Sub

    Private Sub ucrReceiverID_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverID.ControlValueChanged
        If ucrReceiverID.IsEmpty() Then
            clsCompareLines.clsLeftJoin.RemoveParameterByName("by")
        Else
            clsCompareLines.clsLeftJoin.AddParameter("by", ucrReceiverID.GetVariableNames(), iPosition:=2)
        End If
    End Sub

    Private Sub InputFactorTreatmentControls_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputFactorOption1.ControlValueChanged, ucrInputFactorOption2.ControlValueChanged
        If Not ucrInputFactorOption1.IsEmpty() AndAlso Not ucrInputFactorOption2.IsEmpty Then
            clsCompareLines.clsFilterInOperator.AddParameter("1", "c(" & Chr(34) & ucrInputFactorOption1.GetText().Trim("`") & Chr(34) & ", " & Chr(34) & ucrInputFactorOption2.GetText().Trim("`") & Chr(34) & ")", iPosition:=1)
        Else
            clsCompareLines.clsFilterInOperator.RemoveParameterByName("1")
        End If
    End Sub

    Private Sub ContextControls_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputContext1.ControlValueChanged, ucrInputContext2.ControlValueChanged, ucrReceiverContext1.ControlValueChanged, ucrReceiverContext2.ControlValueChanged
        Dim iRowVars As Integer = 0
        Dim iColVars As Integer = 0

        clsCompareLines.clsFacetColOp.ClearParameters()
        clsCompareLines.clsFacetRowOp.ClearParameters()
        clsCompareLines.clsFacetOp.ClearParameters()
        clsCompareLines.clsRFacetFunction.RemoveParameterByName("dir")

        If Not ucrReceiverContext1.IsEmpty() Then
            Select Case ucrInputContext1.GetText()
                Case strFacetRow
                    clsCompareLines.clsFacetRowOp.AddParameter(iRowVars, ucrReceiverContext1.GetVariableNames(False), iPosition:=iRowVars)
                    iRowVars = iRowVars + 1
                Case strFacetCol
                    clsCompareLines.clsFacetColOp.AddParameter(iColVars, ucrReceiverContext1.GetVariableNames(False), iPosition:=iColVars)
                    iColVars = iColVars + 1
            End Select
        End If
        If Not ucrReceiverContext2.IsEmpty() Then
            Select Case ucrInputContext2.GetText()
                Case strFacetRow
                    clsCompareLines.clsFacetRowOp.AddParameter(iRowVars, ucrReceiverContext2.GetVariableNames(False), iPosition:=iRowVars)
                    iRowVars = iRowVars + 1
                Case strFacetCol
                    clsCompareLines.clsFacetColOp.AddParameter(iColVars, ucrReceiverContext2.GetVariableNames(False), iPosition:=iColVars)
                    iColVars = iColVars + 1
            End Select
        End If
        clsCompareLines.clsRFacetFunction.SetRCommand("facet_wrap")
        If iRowVars = 2 Then
            clsCompareLines.clsFacetOp.AddParameter("left", "", iPosition:=0)
            clsCompareLines.clsFacetOp.AddParameter("right", clsROperatorParameter:=clsCompareLines.clsFacetRowOp, iPosition:=1)
        ElseIf iColVars = 2 Then
            clsCompareLines.clsFacetOp.AddParameter("left", "", iPosition:=0)
            clsCompareLines.clsFacetOp.AddParameter("right", clsROperatorParameter:=clsCompareLines.clsFacetColOp, iPosition:=1)
        ElseIf iRowVars = 1 AndAlso iColVars = 1 Then
            clsCompareLines.clsFacetOp.AddParameter("left", clsROperatorParameter:=clsCompareLines.clsFacetRowOp, iPosition:=0)
            clsCompareLines.clsFacetOp.AddParameter("right", clsROperatorParameter:=clsCompareLines.clsFacetColOp, iPosition:=1)
            clsCompareLines.clsRFacetFunction.SetRCommand("facet_grid")
        ElseIf iRowVars = 1 AndAlso iColVars = 0 Then
            clsCompareLines.clsFacetOp.AddParameter("left", "", iPosition:=0)
            clsCompareLines.clsFacetOp.AddParameter("right", clsROperatorParameter:=clsCompareLines.clsFacetRowOp, iPosition:=1)
            clsCompareLines.clsRFacetFunction.AddParameter("dir", Chr(34) & "h" & Chr(34))
        ElseIf iColVars = 1 AndAlso iRowVars = 0 Then
            clsCompareLines.clsFacetOp.AddParameter("left", "", iPosition:=0)
            clsCompareLines.clsFacetOp.AddParameter("right", clsROperatorParameter:=clsCompareLines.clsFacetColOp, iPosition:=1)
            clsCompareLines.clsRFacetFunction.AddParameter("dir", Chr(34) & "v" & Chr(34))
        End If
        If iRowVars > 0 OrElse iColVars > 0 Then
            clsCompareLines.clsBaseOperator.AddParameter("facets", clsRFunctionParameter:=clsCompareLines.clsRFacetFunction, iPosition:=10)
        Else
            clsCompareLines.clsBaseOperator.RemoveParameterByName("facets")
        End If
    End Sub

    Private Sub ucrChkIncludeBoxplot_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkIncludeBoxplot.ControlValueChanged
        If ucrChkIncludeBoxplot.Checked Then
            clsCompareLines.clsBaseOperator.AddParameter("geom_boxplot", clsRFunctionParameter:=clsCompareLines.clsBoxplotGeom, iPosition:=3)
        Else
            clsCompareLines.clsBaseOperator.RemoveParameterByName("geom_boxplot")
        End If
    End Sub

    Private Sub ucrChkHline_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkIncludeHline.ControlValueChanged
        If ucrChkIncludeHline.Checked Then
            clsCompareLines.clsBaseOperator.AddParameter("geom_hline", clsRFunctionParameter:=clsCompareLines.clsHlineGeom, iPosition:=4)
        Else
            clsCompareLines.clsBaseOperator.RemoveParameterByName("geom_hline")
        End If
    End Sub

    Private Sub ucrReceiverMeasurement_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverMeasurement.ControlContentsChanged, ucrReceiverOption.ControlContentsChanged, ucrInputFactorOption1.ControlContentsChanged, ucrInputFactorOption2.ControlContentsChanged, ucrReceiverID.ControlContentsChanged, ucrChkIncludeBoxplot.ControlContentsChanged, ucrNudTransparency.ControlContentsChanged, ucrChkIncludeHline.ControlContentsChanged, ucrInputHlineValue.ControlContentsChanged
        TestOkEnabled()
    End Sub

    Public Sub SetMergeDataAssignTo()
        If ucrSelectorPlot.ucrAvailableDataFrames.cboAvailableDataFrames.Text <> "" Then
            clsCompareLines.clsFilterMissingOperator.SetAssignTo(ucrSelectorPlot.ucrAvailableDataFrames.cboAvailableDataFrames.Text & "_with_diff")
        Else
            clsCompareLines.clsFilterMissingOperator.RemoveAssignTo()
        End If
    End Sub

    Private Sub ucrChkBoxplotOnlyComplete_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkBoxplotOnlyComplete.ControlValueChanged
        If ucrChkBoxplotOnlyComplete.Checked Then
            clsCompareLines.clsFilterMissingOperator.AddParameter("right", clsRFunctionParameter:=clsCompareLines.clsFilterMissingFunction, iPosition:=1)
        Else
            clsCompareLines.clsFilterMissingOperator.RemoveParameterByName("right")
        End If
    End Sub
End Class