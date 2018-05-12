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

Imports instat
Imports instat.Translations
Public Class dlgClimaticCheckDataTemperature
    Private bFirstload As Boolean = True
    Private bReset As Boolean = True
    Private strCurrDataFrame As String
    Private clsGroupByFunc, clsGroupingListFunc, clsCalcFilterFunc, clsRunCalcFunc As New RFunction
    'logical columns
    Private clsFilterListFunc, clsFilterFunc As New RFunction
    'Range
    Private clsGreaterEqualToOperator, clsLessEqualToOperator, clsRangeOrOperator, clsRangeOr2Opertor, clsGreaterEqualTo2Operator, clsLessEqualTo2Operator, clsRange2OrOperator As New ROperator
    'Jump
    Private clsConcFunc, clsDiffFunc, clsAbsFunc As New RFunction
    Private clsJumpGreaterOperator As New ROperator
    'Same
    Private clsRepFunc, clsRleFunc, clsAsNumFunc As New RFunction
    Private clsDollarOperator, clsSameGreaterOperator As New ROperator
    'Difference
    Private clsDiffOperator, clsLessDiffOperator As New ROperator
    'Combined
    Private clsOrOperator As New ROperator
    'outliers
    Private clsGroupByMonth, clsListForOutlierManipulations, clsOutlierLimitUpperFunc, clsOutlierLimitUpperCalc, clsOutlierLimitLowerFunc, clsOutlierLimitLowerCalc, clsListSubCalc As New RFunction
    Private clsOutlierLimitUpperFuncTmin, clsOutlierLimitUpperCalcTmin, clsOutlierLimitLowerFuncTmin, clsOutlierLimitLowerCalcTmin As New RFunction
    Private clsOutlierUpperOperator, clsOutlierLowerOperator As New ROperator
    Private clsOutlierUpperOperatorTmin, clsOutlierLowerOperatorTmin As New ROperator
    Private clsOutlierCombinedOperator As New ROperator

    Private Sub dlgClimaticCheckDataTemperature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstload Then
            InitialiseDialog()
            bFirstload = False
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
        'TODO: Not yet implemented.
        rdoMultiple.Enabled = False
        rdoSatelite.Enabled = False
        rdoIndividual.Checked = True

        ucrChkIncludeCalculatedColumns.Enabled = False

        Dim lstLabels As New List(Of Control)
        lstLabels.AddRange({lblRangeElement1to, lblNudRangeElement1Min, lblNudRangeElement1Max})

        Dim lstLabels2 As New List(Of Control)
        lstLabels2.AddRange({lblNudRangeElement2Min, lblRangeElement2to, lblNudRangeElement2Max})

        'Station Receiver
        ucrReceiverStation.Selector = ucrSelectorTemperature
        ucrReceiverStation.SetClimaticType("station")
        ucrReceiverStation.bAutoFill = True
        ucrReceiverStation.strSelectorHeading = "Station Variables"

        'Date Receiver
        ucrReceiverDate.Selector = ucrSelectorTemperature
        ucrReceiverDate.SetClimaticType("date")
        ucrReceiverDate.SetMeAsReceiver()
        ucrReceiverDate.bAutoFill = True
        ucrReceiverDate.strSelectorHeading = "Date Variables"

        'Year Receiver
        ucrReceiverYear.Selector = ucrSelectorTemperature
        ucrReceiverYear.SetClimaticType("year")
        ucrReceiverYear.bAutoFill = True
        ucrReceiverYear.strSelectorHeading = "Year Variables"

        'Month Receiver
        ucrReceiverMonth.Selector = ucrSelectorTemperature
        ucrReceiverMonth.SetClimaticType("month")
        ucrReceiverMonth.bAutoFill = True
        ucrReceiverMonth.strSelectorHeading = "Month Variables"

        'Day Receiver
        ucrReceiverDay.Selector = ucrSelectorTemperature
        ucrReceiverDay.SetParameter(New RParameter("day", 0))
        ucrReceiverDay.SetParameterIsString()
        ucrReceiverDay.bWithQuotes = False
        ucrReceiverDay.bAutoFill = True
        ucrReceiverDay.SetClimaticType("doy")
        ucrReceiverDay.strSelectorHeading = "Day Variables"

        'Element Receiver
        ucrReceiverElement1.Selector = ucrSelectorTemperature
        ucrReceiverElement1.SetParameter(New RParameter("x", 0, bNewIncludeArgumentName:=False))
        ucrReceiverElement1.SetParameterIsString()
        ucrReceiverElement1.bWithQuotes = False

        ucrReceiverElement2.Selector = ucrSelectorTemperature
        ucrReceiverElement2.SetParameter(New RParameter("x", iNewPosition:=1, bNewIncludeArgumentName:=False))
        ucrReceiverElement2.SetParameterIsString()
        ucrReceiverElement2.bWithQuotes = False

        'Checkboxes for options
        ucrChkRangeElement1.SetParameter(New RParameter("range", clsRangeOrOperator, 1), bNewChangeParameterValue:=False)
        ucrChkRangeElement1.SetText("Acceptable Range (Element1)")

        ucrChkRangeElement2.SetParameter(New RParameter("range2", clsRange2OrOperator, 1), bNewChangeParameterValue:=False)
        ucrChkRangeElement2.SetText("Acceptable Range (Element2)")

        'Linking controls
        ucrChkRangeElement1.AddToLinkedControls(ucrNudRangeElement1Min, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=10)
        ucrChkRangeElement1.AddToLinkedControls(ucrNudRangeElement1Max, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=50)
        ucrChkRangeElement2.AddToLinkedControls(ucrNudRangeElement2Min, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=0)
        ucrChkRangeElement2.AddToLinkedControls(ucrNudRangeElement2Max, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=30)
        ucrNudRangeElement2Min.SetLinkedDisplayControl(lstLabels2)
        ucrNudRangeElement1Min.SetLinkedDisplayControl(lstLabels)
        ucrNudJump.SetLinkedDisplayControl(lblNudJump)
        ucrNudSame.SetLinkedDisplayControl(lblNudSame)
        ucrNudDifference.SetLinkedDisplayControl(lblNudDiff)
        ucrReceiverElement2.SetLinkedDisplayControl(lblElement2)

        ucrChkSame.SetParameter(New RParameter("same", clsSameGreaterOperator, 1), bNewChangeParameterValue:=False)
        ucrChkSame.SetText("Same (Element1)")
        ucrChkSame.AddToLinkedControls(ucrNudSame, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=4)

        ucrChkJump.SetParameter(New RParameter("jump", clsJumpGreaterOperator, 1), bNewChangeParameterValue:=False)
        ucrChkJump.SetText("Jump (Element1)")
        ucrChkJump.AddToLinkedControls(ucrNudJump, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=10)

        ucrChkDifference.SetParameter(New RParameter("diff", clsLessDiffOperator, 1), bNewChangeParameterValue:=False)
        ucrChkDifference.SetText("Difference")

        ucrChkOutlier.SetParameter(New RParameter("Combined_outlier", clsOutlierCombinedOperator, 1), bNewChangeParameterValue:=False)
        ucrChkOutlier.SetText("Outlier")

        'Nuds for the respective options
        'Range Option
        ucrNudRangeElement1Min.SetParameter(New RParameter("from", iNewPosition:=1, bNewIncludeArgumentName:=False))
        ucrNudRangeElement1Min.SetMinMax(-35, 65)

        ucrNudRangeElement1Max.SetParameter(New RParameter("To", 1, bNewIncludeArgumentName:=False))
        ucrNudRangeElement1Max.SetMinMax(-35, 65)

        ucrNudRangeElement2Min.SetParameter(New RParameter("from", 1, bNewIncludeArgumentName:=False))
        ucrNudRangeElement2Min.SetMinMax(-50, 40)
        ucrNudRangeElement2Max.SetParameter(New RParameter("from", 1, bNewIncludeArgumentName:=False))
        ucrNudRangeElement2Max.SetMinMax(-50, 40)

        'Same Option
        ucrNudSame.SetParameter(New RParameter("n", 1, bNewIncludeArgumentName:=False))
        ucrNudSame.SetMinMax(2, 366)

        'Jump Option
        ucrNudJump.SetParameter(New RParameter("from", iNewPosition:=1, bNewIncludeArgumentName:=False))
        ucrNudJump.SetMinMax(1, 25)
        ucrNudJump.DecimalPlaces = 1
        ucrNudJump.Increment = 0.1

        'Difference Option
        ucrNudDifference.SetParameter(New RParameter("n", iNewPosition:=1, bNewIncludeArgumentName:=False))
        ucrNudDifference.SetMinMax(-10, 10)
        ucrNudDifference.DecimalPlaces = 1
        ucrNudDifference.Increment = 0.1
        ucrChkDifference.AddToLinkedControls(ucrNudDifference, {True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=0)

        ucrChkIncludeCalculatedColumns.SetText("Include calculated columns")
        ucrChkIncludeCalculatedColumns.AddParameterPresentCondition(True, "sub1", True)
        ucrChkIncludeCalculatedColumns.AddParameterPresentCondition(False, "sub1", False)

        ucrChkIncludeLogicalColumns.SetText("Include logical columns")
        ucrChkIncludeLogicalColumns.SetParameter(New RParameter("save"))
        ucrChkIncludeLogicalColumns.SetValuesCheckedAndUnchecked("2", "0")

        'ucrChkIncludeLogicalColumns.AddToLinkedControls(ucrInputNewColumnName, {True}, bNewLinkedHideIfParameterMissing:=True)
        'ucrInputNewColumnName.SetLinkedDisplayControl(lblNewColumnName)

        'TODO:To be added in future.
        'save
        'ucrInputNewColumnName.SetParameter(New RParameter("result_name", 2))
        'ucrInputNewColumnName.SetDataFrameSelector(ucrSelectorTemperature.ucrAvailableDataFrames)
        'ucrInputNewColumnName.SetName("Qc")

        'outliers Option

        ttOutliers.SetToolTip(ucrChkOutlier, "Values that are further than this number of IQRs from the corresponding quartile.")
    End Sub

    Private Sub SetDefaults()
        Dim strLengths As String = "lengths"
        Dim strUpper_Outlier_Limit_Tmax As String = "upper_outlier_limit_Tmax"
        Dim strLower_Outlier_Limit_Tmax As String = "lower_outlier_limit_Tmax"
        Dim strUpper_Outlier_Limit_Tmin As String = "upper_outlier_limit_Tmin"
        Dim strLower_Outlier_Limit_Tmin As String = "lower_outlier_limit_Tmin"

        clsGroupByFunc = New RFunction
        clsGroupingListFunc = New RFunction
        clsCalcFilterFunc = New RFunction
        clsFilterFunc = New RFunction
        clsFilterListFunc = New RFunction
        clsRunCalcFunc = New RFunction
        clsGreaterEqualToOperator = New ROperator
        clsLessEqualToOperator = New ROperator
        clsConcFunc = New RFunction
        clsDiffFunc = New RFunction
        clsAbsFunc = New RFunction
        clsDiffOperator = New ROperator
        clsRepFunc = New RFunction
        clsRleFunc = New RFunction
        clsAsNumFunc = New RFunction
        clsDollarOperator = New ROperator
        clsOrOperator = New ROperator
        clsLessEqualTo2Operator = New ROperator
        clsGreaterEqualTo2Operator = New ROperator

        clsOutlierUpperOperator.Clear()
        clsOutlierLowerOperator.Clear()
        clsOutlierUpperOperatorTmin.Clear()
        clsOutlierLowerOperatorTmin.Clear()

        clsRangeOrOperator.Clear()
        clsRange2OrOperator.Clear()
        clsSameGreaterOperator.Clear()
        clsJumpGreaterOperator.Clear()
        clsLessDiffOperator.Clear()

        ucrSelectorTemperature.Reset()
        ucrReceiverStation.SetMeAsReceiver()

        'GroupBy
        clsGroupByFunc.SetRCommand("instat_calculation$new")
        clsGroupByFunc.AddParameter("type", Chr(34) & "by" & Chr(34), iPosition:=0)
        clsGroupByFunc.SetAssignTo("grouping")
        clsGroupingListFunc.SetRCommand("list")
        clsGroupingListFunc.AddParameter("list", bIncludeArgumentName:=False, clsRFunctionParameter:=clsGroupByFunc, iPosition:=0)

        'Range
        clsGreaterEqualToOperator.SetOperation(">=")
        clsLessEqualToOperator.SetOperation("<=")
        clsRangeOrOperator.SetOperation("|")
        clsRangeOrOperator.bBrackets = False
        clsRangeOrOperator.AddParameter("left", clsROperatorParameter:=clsLessEqualToOperator, iPosition:=0, bIncludeArgumentName:=False)
        clsRangeOrOperator.AddParameter("right", clsROperatorParameter:=clsGreaterEqualToOperator, iPosition:=1, bIncludeArgumentName:=False)
        clsRange2OrOperator.SetOperation("|")
        clsRange2OrOperator.bBrackets = False
        clsGreaterEqualTo2Operator.SetOperation(">=")
        clsLessEqualTo2Operator.SetOperation("<=")
        clsLessEqualTo2Operator.AddParameter("from", "0", bIncludeArgumentName:=False, iPosition:=1)
        clsRange2OrOperator.AddParameter("left", bIncludeArgumentName:=False, clsROperatorParameter:=clsLessEqualTo2Operator, iPosition:=0)
        clsRange2OrOperator.AddParameter("right", bIncludeArgumentName:=False, clsROperatorParameter:=clsGreaterEqualTo2Operator, iPosition:=1)

        'Same
        clsSameGreaterOperator.SetOperation(">=")
        clsSameGreaterOperator.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsRepFunc, iPosition:=0)
        clsRepFunc.SetRCommand("rep")
        clsRepFunc.AddParameter("left", bIncludeArgumentName:=False, clsROperatorParameter:=clsDollarOperator, iPosition:=0)
        clsRepFunc.AddParameter("right", bIncludeArgumentName:=False, clsROperatorParameter:=clsDollarOperator, iPosition:=1)
        clsAsNumFunc.SetRCommand("as.numeric")
        clsRleFunc.SetRCommand("rle")
        clsRleFunc.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsAsNumFunc, iPosition:=0)
        clsDollarOperator.SetOperation("$")
        clsDollarOperator.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsRleFunc, iPosition:=0)
        clsDollarOperator.AddParameter("right", strParameterValue:=strLengths, bIncludeArgumentName:=False, iPosition:=1)

        'Jump
        clsConcFunc.SetRCommand("c")
        clsConcFunc.AddParameter("left", "NA", bIncludeArgumentName:=False, iPosition:=0)
        clsConcFunc.AddParameter("right", bIncludeArgumentName:=False, clsRFunctionParameter:=clsDiffFunc, iPosition:=1)
        clsAbsFunc.SetRCommand("abs")
        clsAbsFunc.AddParameter("diff", bIncludeArgumentName:=False, clsRFunctionParameter:=clsConcFunc, iPosition:=0)
        clsDiffFunc.SetRCommand("diff")
        clsJumpGreaterOperator.SetOperation(">")
        clsJumpGreaterOperator.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsAbsFunc, iPosition:=0)

        'Difference
        clsLessDiffOperator.SetOperation("<")
        clsLessDiffOperator.AddParameter("left", bIncludeArgumentName:=False, clsROperatorParameter:=clsDiffOperator, iPosition:=0)
        clsDiffOperator.SetOperation("-")

        'Group By Month for Outliers 
        clsGroupByMonth.SetRCommand("instat_calculation$new")
        clsGroupByMonth.AddParameter("type", Chr(34) & "by" & Chr(34), iPosition:=0)
        clsGroupByMonth.SetAssignTo("grouping_month")

        clsListForOutlierManipulations.SetRCommand("list")
        clsListForOutlierManipulations.AddParameter("sub1", clsRFunctionParameter:=clsGroupByMonth, bIncludeArgumentName:=False, iPosition:=0)

        'Tmax
        'Upper Outlier Limit function and calc 
        clsOutlierLimitUpperCalc.SetRCommand("instat_calculation$new")
        clsOutlierLimitUpperCalc.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsOutlierLimitUpperCalc.AddParameter("function_exp", clsRFunctionParameter:=clsOutlierLimitUpperFunc, iPosition:=1)
        clsOutlierLimitUpperCalc.AddParameter("result_name", Chr(34) & strUpper_Outlier_Limit_Tmax & Chr(34), iPosition:=4)
        clsOutlierLimitUpperCalc.AddParameter("save", "0", iPosition:=5)
        clsOutlierLimitUpperCalc.SetAssignTo("upper_outlier_limit_Tmax")
        clsOutlierLimitUpperFunc.AddParameter("bupperlimit", "TRUE")
        clsOutlierLimitUpperFunc.SetRCommand("summary_outlier_limit")
        clsOutlierLimitUpperFunc.bToScriptAsRString = True

        'Lower outlier limit Function and Calc
        clsOutlierLimitLowerCalc.SetRCommand("instat_calculation$new")
        clsOutlierLimitLowerCalc.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsOutlierLimitLowerCalc.AddParameter("function_exp", clsRFunctionParameter:=clsOutlierLimitLowerFunc, iPosition:=1)
        clsOutlierLimitLowerCalc.AddParameter("result_name", Chr(34) & strLower_Outlier_Limit_Tmax & Chr(34), iPosition:=4)
        clsOutlierLimitLowerCalc.AddParameter("save", "0", iPosition:=5)
        clsOutlierLimitLowerCalc.SetAssignTo("lower_outlier_limit_Tmax")
        clsOutlierLimitLowerFunc.AddParameter("bupperlimit", "FALSE")
        clsOutlierLimitLowerFunc.SetRCommand("summary_outlier_limit")
        clsOutlierLimitLowerFunc.bToScriptAsRString = True

        'Upper Outlier Operator 
        clsOutlierUpperOperator.SetOperation(">")
        clsOutlierUpperOperator.AddParameter("right", strUpper_Outlier_Limit_Tmax, iPosition:=1)

        'Lower Outlier Operator 
        clsOutlierLowerOperator.SetOperation("<")
        clsOutlierLowerOperator.AddParameter("right", strLower_Outlier_Limit_Tmax, iPosition:=1)

        'Tmin 
        'Upper Outlier Limit function and calc 
        clsOutlierLimitUpperCalcTmin.SetRCommand("instat_calculation$new")
        clsOutlierLimitUpperCalcTmin.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsOutlierLimitUpperCalcTmin.AddParameter("function_exp", clsRFunctionParameter:=clsOutlierLimitUpperFuncTmin, iPosition:=1)
        clsOutlierLimitUpperCalcTmin.AddParameter("result_name", Chr(34) & strUpper_Outlier_Limit_Tmin & Chr(34), iPosition:=4)
        clsOutlierLimitUpperCalcTmin.AddParameter("save", "0", iPosition:=5)
        clsOutlierLimitUpperCalcTmin.SetAssignTo("upper_outlier_limit_Tmin")
        clsOutlierLimitUpperFuncTmin.AddParameter("bupperlimit", "TRUE")
        clsOutlierLimitUpperFuncTmin.SetRCommand("summary_outlier_limit")
        clsOutlierLimitUpperFuncTmin.bToScriptAsRString = True

        'Lower outlier limit Function and Calc
        clsOutlierLimitLowerCalcTmin.SetRCommand("instat_calculation$new")
        clsOutlierLimitLowerCalcTmin.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsOutlierLimitLowerCalcTmin.AddParameter("function_exp", clsRFunctionParameter:=clsOutlierLimitLowerFuncTmin, iPosition:=1)
        clsOutlierLimitLowerCalcTmin.AddParameter("result_name", Chr(34) & strLower_Outlier_Limit_Tmin & Chr(34), iPosition:=4)
        clsOutlierLimitLowerCalcTmin.AddParameter("save", "0", iPosition:=5)
        clsOutlierLimitLowerCalcTmin.SetAssignTo("lower_outlier_limit_Tmin")
        clsOutlierLimitLowerFuncTmin.AddParameter("bupperlimit", "FALSE")
        clsOutlierLimitLowerFuncTmin.SetRCommand("summary_outlier_limit")
        clsOutlierLimitLowerFuncTmin.bToScriptAsRString = True

        'Sub Calculations List for temp_filter
        clsListSubCalc.SetRCommand("list")

        'Upper Outlier Operator 
        clsOutlierUpperOperatorTmin.SetOperation(">")
        clsOutlierUpperOperatorTmin.AddParameter("right", strUpper_Outlier_Limit_Tmin, iPosition:=1)

        'Lower Outlier Operator 
        clsOutlierLowerOperatorTmin.SetOperation("<")
        clsOutlierLowerOperatorTmin.AddParameter("right", strLower_Outlier_Limit_Tmin, iPosition:=1)

        'outlier limits combined
        clsOutlierCombinedOperator.SetOperation("|")

        'Main calculation filter
        clsCalcFilterFunc.SetRCommand("instat_calculation$new")
        clsCalcFilterFunc.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsCalcFilterFunc.AddParameter("result_name", Chr(34) & "QC" & Chr(34))
        clsCalcFilterFunc.SetAssignTo("Filter_Calculation")
        clsCalcFilterFunc.AddParameter("function_exp", clsROperatorParameter:=clsOrOperator, iPosition:=1)

        'Logical columns 
        clsFilterFunc.SetRCommand("instat_calculation$new")
        clsFilterFunc.AddParameter("type", Chr(34) & "filter" & Chr(34), iPosition:=0)
        clsFilterFunc.AddParameter("function_exp", strParameterValue:=Chr(34) & "QC" & Chr(34), iPosition:=1)
        clsFilterFunc.AddParameter("sub_calculations", clsRFunctionParameter:=clsFilterListFunc, iPosition:=2)
        clsFilterFunc.AddParameter("save", "2", iPosition:=3)
        clsFilterFunc.AddParameter("result_data_frame", Chr(34) & "Filter" & Chr(34), iPosition:=4)
        clsFilterFunc.SetAssignTo("filtered_data")

        clsFilterListFunc.SetRCommand("list")
        clsFilterListFunc.AddParameter("sub", clsRFunctionParameter:=clsCalcFilterFunc, bIncludeArgumentName:=False)

        clsFilterFunc.SetAssignTo("filtered_data")
        'Combined
        clsOrOperator.SetOperation("|")
        clsOrOperator.bBrackets = False
        clsOrOperator.bToScriptAsRString = True

        clsRunCalcFunc.SetRCommand("InstatDataObject$run_instat_calculation")
        clsRunCalcFunc.AddParameter("calc", clsRFunctionParameter:=clsFilterFunc, iPosition:=0)
        clsRunCalcFunc.AddParameter("display", "FALSE")
        ucrBase.clsRsyntax.SetBaseRFunction(clsRunCalcFunc)
    End Sub

    Private Sub SetRCodeForControls(bReset)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsGreaterEqualToOperator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=1)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsDiffFunc, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=2)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsDiffOperator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=3)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsAsNumFunc, New RParameter("x", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=4)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsOutlierUpperOperator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=5)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsOutlierLowerOperator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=6)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsOutlierLimitUpperFunc, New RParameter("x", 0), iAdditionalPairNo:=7)
        ucrReceiverElement1.AddAdditionalCodeParameterPair(clsOutlierLimitLowerFunc, New RParameter("x", 0), iAdditionalPairNo:=8)
        ucrReceiverElement2.AddAdditionalCodeParameterPair(clsGreaterEqualTo2Operator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=1)
        ucrReceiverElement2.AddAdditionalCodeParameterPair(clsLessEqualTo2Operator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=2)
        ucrReceiverElement2.AddAdditionalCodeParameterPair(clsOutlierUpperOperatorTmin, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=3)
        ucrReceiverElement2.AddAdditionalCodeParameterPair(clsOutlierLowerOperatorTmin, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=4)
        ucrReceiverElement2.AddAdditionalCodeParameterPair(clsOutlierLimitUpperFuncTmin, New RParameter("x", 0), iAdditionalPairNo:=5)
        ucrReceiverElement2.AddAdditionalCodeParameterPair(clsOutlierLimitLowerFuncTmin, New RParameter("x", 0), iAdditionalPairNo:=6)
        ucrChkOutlier.AddAdditionalCodeParameterPair(clsCalcFilterFunc, New RParameter("sub_calculations", strParamValue:=clsListSubCalc), iAdditionalPairNo:=1)

        ucrNudRangeElement2Max.SetRCode(clsGreaterEqualTo2Operator, bReset)
        ucrNudRangeElement2Min.SetRCode(clsLessEqualTo2Operator, bReset)
        ucrReceiverElement1.SetRCode(clsLessEqualToOperator, bReset)
        ucrNudRangeElement1Min.SetRCode(clsLessEqualToOperator, bReset)
        ucrNudRangeElement1Max.SetRCode(clsGreaterEqualToOperator, bReset)
        ucrNudJump.SetRCode(clsJumpGreaterOperator, bReset)
        ucrReceiverElement2.SetRCode(clsDiffOperator, bReset)
        ucrNudDifference.SetRCode(clsLessDiffOperator, bReset)
        ucrNudSame.SetRCode(clsSameGreaterOperator, bReset)
        ucrChkDifference.SetRCode(clsOrOperator, bReset)
        ucrChkRangeElement1.SetRCode(clsOrOperator, bReset)
        ucrChkRangeElement2.SetRCode(clsOrOperator, bReset)
        ucrChkSame.SetRCode(clsOrOperator, bReset)
        ucrChkJump.SetRCode(clsOrOperator, bReset)
        ucrChkIncludeLogicalColumns.SetRCode(clsCalcFilterFunc, bReset)
        ucrChkOutlier.SetRCode(clsOrOperator, bReset)
    End Sub

    Private Sub TestOkEnabled()

        Dim bEnable As Boolean = False

        If ucrReceiverElement1.IsEmpty() AndAlso ucrReceiverElement2.IsEmpty() Then
            ucrBase.OKEnabled(False)
            Exit Sub
        ElseIf ucrReceiverElement1.IsEmpty() OrElse ucrReceiverElement2.IsEmpty() AndAlso ucrChkDifference.Checked Then
            ucrBase.OKEnabled(False)
            Exit Sub
        ElseIf ucrReceiverElement1.IsEmpty() AndAlso (ucrChkRangeElement1.Checked OrElse ucrChkSame.Checked OrElse ucrChkJump.Checked) Then
            ucrBase.OKEnabled(False)
            Exit Sub
        ElseIf ucrReceiverElement2.IsEmpty() AndAlso ucrChkRangeElement2.Checked Then
            ucrBase.OKEnabled(False)
            Exit Sub
        End If

        If ucrChkRangeElement1.Checked Then
            If ucrNudRangeElement1Min.GetText <> "" AndAlso ucrNudRangeElement1Max.GetText <> "" Then
                bEnable = True
            Else
                ucrBase.OKEnabled(False)
                Exit Sub
            End If
        End If
        If ucrChkRangeElement2.Checked Then
            If ucrNudRangeElement2Min.GetText <> "" AndAlso ucrNudRangeElement2Max.GetText <> "" Then
                bEnable = True
            Else
                ucrBase.OKEnabled(False)
                Exit Sub
            End If
        End If
        If ucrChkSame.Checked Then
            If ucrNudSame.GetText <> "" Then
                bEnable = True
            Else
                ucrBase.OKEnabled(False)
                Exit Sub
            End If
        End If
        If ucrChkJump.Checked Then
            If ucrNudJump.GetText <> "" Then
                bEnable = True
            Else
                ucrBase.OKEnabled(False)
                Exit Sub
            End If
        End If
        If ucrChkDifference.Checked Then
            If ucrNudDifference.GetText <> "" Then
                bEnable = True
            Else
                ucrBase.OKEnabled(False)
                Exit Sub
            End If

        End If
        If ucrChkOutlier.Checked Then
            bEnable = True
        End If

        ucrBase.OKEnabled(bEnable)

    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub GroupByOptions()
        If Not ucrReceiverStation.IsEmpty Then
            clsGroupByFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverStation.GetVariableNames & ")", iPosition:=1)
            clsCalcFilterFunc.AddParameter("manipulations", clsRFunctionParameter:=clsGroupingListFunc, iPosition:=3)
            clsFilterFunc.AddParameter("manipulations", clsRFunctionParameter:=clsGroupingListFunc, iPosition:=3)
        Else
            clsCalcFilterFunc.RemoveParameterByName("manipulations")
            clsFilterFunc.RemoveParameterByName("manipulations")
        End If
    End Sub

    Private Sub GroupByMonth()
        If Not ucrReceiverMonth.IsEmpty Then
            clsGroupByMonth.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverMonth.GetVariableNames & ")", iPosition:=1)
            If Not ucrReceiverElement1.IsEmpty() Then
                clsOutlierLimitUpperCalc.AddParameter("manipulations", clsRFunctionParameter:=clsListForOutlierManipulations, iPosition:=3)
                clsOutlierLimitLowerCalc.AddParameter("manipulations", clsRFunctionParameter:=clsListForOutlierManipulations, iPosition:=3)
            ElseIf ucrReceiverElement1.IsEmpty() Then
                clsOutlierLimitUpperCalc.RemoveParameterByName("manipulations")
                clsOutlierLimitLowerCalc.RemoveParameterByName("manipulations")
            End If
            If Not ucrReceiverElement2.IsEmpty() Then
                clsOutlierLimitUpperCalcTmin.AddParameter("manipulations", clsRFunctionParameter:=clsListForOutlierManipulations, iPosition:=3)
                clsOutlierLimitLowerCalcTmin.AddParameter("manipulations", clsRFunctionParameter:=clsListForOutlierManipulations, iPosition:=3)
            ElseIf ucrReceiverElement2.IsEmpty Then
                clsOutlierLimitUpperCalcTmin.RemoveParameterByName("manipulations")
                clsOutlierLimitLowerCalcTmin.RemoveParameterByName("manipulations")
            End If
        Else
            clsOutlierLimitUpperCalc.RemoveParameterByName("manipulations")
            clsOutlierLimitLowerCalc.RemoveParameterByName("manipulations")
            clsOutlierLimitUpperCalcTmin.RemoveParameterByName("manipulations")
            clsOutlierLimitLowerCalcTmin.RemoveParameterByName("manipulations")
        End If
    End Sub

    Private Sub FilterFunc()
        If Not ucrReceiverElement1.IsEmpty Then
            clsOutlierLimitUpperCalc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement1.GetVariableNames & ")", iPosition:=2)
            clsOutlierLimitLowerCalc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement1.GetVariableNames & ")", iPosition:=2)
        End If
        If Not ucrReceiverElement2.IsEmpty Then
            clsOutlierLimitUpperCalcTmin.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement2.GetVariableNames & ")", iPosition:=2)
            clsOutlierLimitLowerCalcTmin.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement2.GetVariableNames & ")", iPosition:=2)
        End If
        If Not ucrReceiverElement1.IsEmpty AndAlso Not ucrReceiverElement2.IsEmpty Then
            clsCalcFilterFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement1.GetVariableNames & "," & strCurrDataFrame & "=" & ucrReceiverElement2.GetVariableNames & ")", iPosition:=2)
            clsFilterFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement1.GetVariableNames & "," & strCurrDataFrame & "=" & ucrReceiverElement2.GetVariableNames & ")", iPosition:=2)
            clsListSubCalc.AddParameter("sub1", clsRFunctionParameter:=clsOutlierLimitUpperCalc, bIncludeArgumentName:=False, iPosition:=0)
            clsListSubCalc.AddParameter("sub2", clsRFunctionParameter:=clsOutlierLimitLowerCalc, bIncludeArgumentName:=False, iPosition:=1)
            clsListSubCalc.AddParameter("sub3", clsRFunctionParameter:=clsOutlierLimitUpperCalcTmin, bIncludeArgumentName:=False, iPosition:=2)
            clsListSubCalc.AddParameter("sub4", clsRFunctionParameter:=clsOutlierLimitLowerCalcTmin, bIncludeArgumentName:=False, iPosition:=3)
            clsOutlierCombinedOperator.AddParameter("sub1", clsROperatorParameter:=clsOutlierUpperOperator, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.AddParameter("sub2", clsROperatorParameter:=clsOutlierLowerOperator, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.AddParameter("sub3", clsROperatorParameter:=clsOutlierUpperOperatorTmin, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.AddParameter("sub4", clsROperatorParameter:=clsOutlierLowerOperatorTmin, bIncludeArgumentName:=False)
        ElseIf Not ucrReceiverElement1.IsEmpty Then
            clsCalcFilterFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement1.GetVariableNames & ")", iPosition:=2)
            clsFilterFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement1.GetVariableNames & ")", iPosition:=2)
            clsListSubCalc.AddParameter("sub1", clsRFunctionParameter:=clsOutlierLimitUpperCalc, bIncludeArgumentName:=False, iPosition:=0)
            clsListSubCalc.AddParameter("sub2", clsRFunctionParameter:=clsOutlierLimitLowerCalc, bIncludeArgumentName:=False, iPosition:=1)
            clsListSubCalc.RemoveParameterByName("sub3")
            clsListSubCalc.RemoveParameterByName("sub4")
            clsOutlierCombinedOperator.AddParameter("sub1", clsROperatorParameter:=clsOutlierUpperOperator, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.AddParameter("sub2", clsROperatorParameter:=clsOutlierLowerOperator, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.RemoveParameterByName("sub3")
            clsOutlierCombinedOperator.RemoveParameterByName("sub4")
        ElseIf Not ucrReceiverElement2.IsEmpty Then
            clsCalcFilterFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement2.GetVariableNames & ")", iPosition:=2)
            clsFilterFunc.AddParameter("calculated_from", "list(" & strCurrDataFrame & "=" & ucrReceiverElement2.GetVariableNames & ")", iPosition:=2)
            clsListSubCalc.AddParameter("sub3", clsRFunctionParameter:=clsOutlierLimitUpperCalcTmin, bIncludeArgumentName:=False, iPosition:=2)
            clsListSubCalc.AddParameter("sub4", clsRFunctionParameter:=clsOutlierLimitLowerCalcTmin, bIncludeArgumentName:=False, iPosition:=3)
            clsListSubCalc.RemoveParameterByName("sub1")
            clsListSubCalc.RemoveParameterByName("sub2")
            clsOutlierCombinedOperator.AddParameter("sub3", clsROperatorParameter:=clsOutlierUpperOperatorTmin, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.AddParameter("sub4", clsROperatorParameter:=clsOutlierLowerOperatorTmin, bIncludeArgumentName:=False)
            clsOutlierCombinedOperator.RemoveParameterByName("sub1")
            clsOutlierCombinedOperator.RemoveParameterByName("sub2")
        End If
    End Sub

    Private Sub ucrSelectorTemperature_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrSelectorTemperature.ControlValueChanged
        strCurrDataFrame = Chr(34) & ucrSelectorTemperature.ucrAvailableDataFrames.cboAvailableDataFrames.SelectedItem & Chr(34)
    End Sub

    Private Sub ucrReceiverStation_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverStation.ControlValueChanged
        GroupByOptions()
    End Sub


    Private Sub ucrReceiverElement_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverElement1.ControlValueChanged, ucrReceiverElement2.ControlValueChanged
        FilterFunc()
    End Sub

    Private Sub CoreControls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverElement1.ControlContentsChanged, ucrReceiverElement2.ControlContentsChanged, ucrNudSame.ControlContentsChanged, ucrNudRangeElement1Min.ControlContentsChanged, ucrNudRangeElement1Max.ControlContentsChanged, ucrNudRangeElement2Min.ControlContentsChanged, ucrNudRangeElement2Max.ControlContentsChanged, ucrNudJump.ControlContentsChanged, ucrNudRangeElement2Min.ControlContentsChanged, ucrNudRangeElement2Max.ControlContentsChanged, ucrNudDifference.ControlContentsChanged, ucrChkRangeElement1.ControlContentsChanged, ucrChkRangeElement2.ControlContentsChanged, ucrChkJump.ControlContentsChanged, ucrChkDifference.ControlContentsChanged, ucrChkSame.ControlContentsChanged, ucrChkOutlier.ControlContentsChanged
        TestOkEnabled()
    End Sub

    Private Sub ucrReceiverMonth_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverMonth.ControlValueChanged
        GroupByMonth()
    End Sub
End Class