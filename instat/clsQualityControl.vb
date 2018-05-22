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

Public Class clsQCJumpRCode
    Private clsLagFunction, clsAbsLagFunction, clsLeadFunction, clsPmaxFunction, clsAbsFunc, clsAbsLeadFunction As New RFunction
    Public clsJumpCalcFunction, clsJumpTestFunction As New RFunction
    Private clsLagMinusOperator, clsLeadMinusOperator As New ROperator
    Public clsGreaterJumpOperator As New ROperator
    Private clsJumpListFunc As New RFunction
    Public strTestName As String

    Public Sub SetDefaults(strElementName As String)
        Dim strlargest_jump As String = "largest_jump" & strElementName
        Dim strjump_test As String = "Jump" & strElementName

        clsLagFunction = New RFunction
        clsAbsLagFunction = New RFunction
        clsLeadFunction = New RFunction
        clsAbsFunc = New RFunction
        clsAbsLeadFunction = New RFunction
        clsJumpCalcFunction = New RFunction
        clsJumpListFunc = New RFunction

        clsLagMinusOperator = New ROperator

        clsLeadMinusOperator.Clear()
        clsPmaxFunction.Clear()
        clsJumpTestFunction.Clear()
        clsGreaterJumpOperator.Clear()

        clsLagFunction.SetPackageName("dplyr")
        clsLagFunction.SetRCommand("lag")

        clsLagMinusOperator.SetOperation("-")
        clsLagMinusOperator.AddParameter("right", clsRFunctionParameter:=clsLagFunction, bIncludeArgumentName:=False, iPosition:=1)

        clsAbsLagFunction.SetRCommand("abs")
        clsAbsLagFunction.AddParameter("abs", clsROperatorParameter:=clsLagMinusOperator, bIncludeArgumentName:=False)

        clsLeadFunction.SetPackageName("dplyr")
        clsLeadFunction.SetRCommand("lead")

        clsLeadMinusOperator.SetOperation("-")
        clsLeadMinusOperator.AddParameter("right", bIncludeArgumentName:=False, clsRFunctionParameter:=clsLeadFunction, iPosition:=1)

        clsAbsLeadFunction.SetRCommand("abs")
        clsAbsLeadFunction.AddParameter("abs", bIncludeArgumentName:=False, clsROperatorParameter:=clsLeadMinusOperator)

        clsPmaxFunction.SetRCommand("pmax")
        clsPmaxFunction.AddParameter("lag", bIncludeArgumentName:=False, clsRFunctionParameter:=clsAbsLagFunction, iPosition:=0)
        clsPmaxFunction.AddParameter("lead", bIncludeArgumentName:=False, clsRFunctionParameter:=clsAbsLeadFunction, iPosition:=1)
        clsPmaxFunction.AddParameter("na.rm", "TRUE", iPosition:=2)
        clsPmaxFunction.bToScriptAsRString = True

        clsJumpCalcFunction.SetRCommand("instat_calculation$new")
        clsJumpCalcFunction.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsJumpCalcFunction.AddParameter("function_exp", clsRFunctionParameter:=clsPmaxFunction, iPosition:=1)
        clsJumpCalcFunction.AddParameter("result_name", Chr(34) & strlargest_jump & Chr(34), iPosition:=4)
        clsJumpCalcFunction.SetAssignTo("largest_jump" & strElementName)

        strTestName = strjump_test
        clsJumpListFunc.SetRCommand("list")
        clsJumpListFunc.AddParameter("sub1", clsRFunctionParameter:=clsJumpCalcFunction, bIncludeArgumentName:=False)
        clsJumpTestFunction.SetRCommand("instat_calculation$new")
        clsJumpTestFunction.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsJumpTestFunction.AddParameter("function_exp", clsROperatorParameter:=clsGreaterJumpOperator, iPosition:=1)
        clsJumpTestFunction.AddParameter("result_name", Chr(34) & strTestName & Chr(34), iPosition:=4)
        clsJumpTestFunction.AddParameter("sub_calculations", clsRFunctionParameter:=clsJumpListFunc, iPosition:=2)
        clsJumpTestFunction.SetAssignTo("largest_test_jump" & strElementName)

        clsGreaterJumpOperator.SetOperation(">")
        clsGreaterJumpOperator.bToScriptAsRString = True
        clsGreaterJumpOperator.AddParameter("left", strParameterValue:=strlargest_jump, iPosition:=0)
    End Sub

    Public Sub SetElementParameters(ucrNewControl As ucrCore, iAdditionalPairNo1 As Integer, iAdditionalPairNo2 As Integer, iAdditionalPairNo3 As Integer, iAdditionalPairNo4 As Integer)

        ucrNewControl.AddAdditionalCodeParameterPair(clsLagFunction, New RParameter("Tmax", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=iAdditionalPairNo1)
        ucrNewControl.AddAdditionalCodeParameterPair(clsLagMinusOperator, New RParameter("Tmax", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=iAdditionalPairNo2)
        ucrNewControl.AddAdditionalCodeParameterPair(clsLeadFunction, New RParameter("Tmax", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=iAdditionalPairNo3)
        ucrNewControl.AddAdditionalCodeParameterPair(clsLeadMinusOperator, New RParameter("Tmax", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=iAdditionalPairNo4)

    End Sub
End Class


Public Class clsQCSameRCode
    Private clsRleFunc, clsAsNumFunc, clsSameListFunc As New RFunction
    Public clsSameCalcFunction, clsSameTestFunction As New RFunction
    Private clsDollarOperator As New ROperator
    Public clsSameGreaterOperator As New ROperator
    Public clsRepFunc As New RFunction
    Public strTestName As String

    Public Sub SetDefaults(strElementName As String)
        Dim strLengths As String = "lengths"
        Dim strlargest_Same As String = "Largest_Same" & strElementName
        Dim strSame_test As String = "Same" & strElementName

        clsRepFunc = New RFunction
        clsRleFunc = New RFunction
        clsAsNumFunc = New RFunction
        clsDollarOperator = New ROperator

        clsSameGreaterOperator.Clear()

        clsRepFunc.SetRCommand("rep")
        clsRepFunc.AddParameter("left", bIncludeArgumentName:=False, clsROperatorParameter:=clsDollarOperator, iPosition:=0)
        clsRepFunc.AddParameter("right", bIncludeArgumentName:=False, clsROperatorParameter:=clsDollarOperator, iPosition:=1)
        clsAsNumFunc.SetRCommand("as.numeric")
        clsRleFunc.SetRCommand("rle")
        clsRleFunc.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsAsNumFunc, iPosition:=0)
        clsDollarOperator.SetOperation("$")
        clsDollarOperator.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsRleFunc, iPosition:=0)
        clsDollarOperator.AddParameter("right", strParameterValue:=strLengths, bIncludeArgumentName:=False, iPosition:=1)

        clsSameCalcFunction.SetRCommand("instat_calculation$new")
        clsSameCalcFunction.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsSameCalcFunction.AddParameter("function_exp", clsRFunctionParameter:=clsRepFunc, iPosition:=1)
        clsSameCalcFunction.AddParameter("result_name", Chr(34) & strlargest_Same & Chr(34), iPosition:=4)
        clsSameCalcFunction.SetAssignTo("Largest_Same" & strElementName)
        clsRepFunc.bToScriptAsRString = True

        strTestName = strSame_test
        clsSameListFunc.SetRCommand("list")
        clsSameListFunc.AddParameter("sub1", clsRFunctionParameter:=clsSameCalcFunction, bIncludeArgumentName:=False)

        clsSameTestFunction.SetRCommand("instat_calculation$new")
        clsSameTestFunction.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsSameTestFunction.AddParameter("function_exp", clsROperatorParameter:=clsSameGreaterOperator, iPosition:=1)
        clsSameTestFunction.AddParameter("result_name", Chr(34) & strTestName & Chr(34), iPosition:=4)
        clsSameTestFunction.AddParameter("sub_calculations", clsRFunctionParameter:=clsSameListFunc, iPosition:=2)
        clsSameTestFunction.SetAssignTo("Largest_test_same" & strElementName)

        clsSameGreaterOperator.SetOperation(">=")
        clsSameGreaterOperator.bToScriptAsRString = True
        clsSameGreaterOperator.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsSameCalcFunction, iPosition:=0)
    End Sub

    Public Sub SetElementParameters(ucrNewControl As ucrCore, iAdditionalPairNo As Integer)
        ucrNewControl.AddAdditionalCodeParameterPair(clsAsNumFunc, New RParameter("x", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=iAdditionalPairNo)
    End Sub
End Class

Public Class clsQCDifferenceRCode
    Public clsDiffOperator, clsLessDiffOperator As New ROperator
    Public clsDiffCalcFunction, clsDiffTestFunction As New RFunction
    Private clsListFunc As New RFunction
    Public strTestName As String

    Public Sub SetDefaults()

        Dim strDiffCalc As String = "diff_calculation"
        Dim strDiffTest As String = "diff"

        clsDiffOperator = New ROperator
        clsDiffCalcFunction = New RFunction
        clsListFunc = New RFunction
        clsLessDiffOperator.Clear()
        clsLessDiffOperator.SetOperation("<")
        clsLessDiffOperator.bToScriptAsRString = True
        clsLessDiffOperator.AddParameter("left", bIncludeArgumentName:=False, clsRFunctionParameter:=clsDiffCalcFunction, iPosition:=0)
        clsDiffOperator.SetOperation("-")
        clsDiffOperator.bToScriptAsRString = True

        clsDiffCalcFunction.SetRCommand("instat_calculation$new")
        clsDiffCalcFunction.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsDiffCalcFunction.AddParameter("function_exp", clsROperatorParameter:=clsDiffOperator, iPosition:=1)
        clsDiffCalcFunction.AddParameter("result_name", Chr(34) & strDiffCalc & Chr(34), iPosition:=4)
        clsDiffCalcFunction.SetAssignTo("diff_calculation")

        strTestName = strDiffTest
        clsListFunc.SetRCommand("list")
        clsListFunc.AddParameter("sub1", bIncludeArgumentName:=False, clsRFunctionParameter:=clsDiffCalcFunction, iPosition:=0)
        clsDiffTestFunction.SetRCommand("instat_calculation$new")
        clsDiffTestFunction.AddParameter("type", Chr(34) & "calculation" & Chr(34), iPosition:=0)
        clsDiffTestFunction.AddParameter("function_exp", clsROperatorParameter:=clsLessDiffOperator, iPosition:=1)
        clsDiffTestFunction.AddParameter("result_name", Chr(34) & strTestName & Chr(34), iPosition:=4)
        clsDiffTestFunction.AddParameter("sub_calculations", clsRFunctionParameter:=clsListFunc, iPosition:=2)
        clsDiffTestFunction.SetAssignTo("diff_test_calculation")
    End Sub

    Public Sub SetElementParameters(ucrNewControl As ucrCore, iAdditionalPairNo As Integer)
        ucrNewControl.AddAdditionalCodeParameterPair(clsDiffOperator, New RParameter("left", 0, bNewIncludeArgumentName:=False), iAdditionalPairNo:=iAdditionalPairNo)
    End Sub
End Class

