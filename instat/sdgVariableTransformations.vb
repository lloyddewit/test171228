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
Public Class sdgVariableTransformations
    Public clsRToFunction, clsRCIFunction As New RFunction
    Public clsModel1 As New ROperator
    Public bFirstLoad As Boolean = True
    Private Sub sdgVariableTransformations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)

        If bFirstLoad Then
            SetDefaults()
            bFirstLoad = False
        End If
    End Sub

    Public Sub SetDefaults()
        rdoNaturallog.Checked = False
        rdoLogBase10.Checked = False
        rdoSquareroot.Checked = False
        rdoPower.Checked = False
    End Sub

    Public Sub SetRCIFunction(clsNewFunction As RFunction)
        clsRCIFunction = clsNewFunction
    End Sub

    Private Function ExplanatoryFunction(strFunctionName As String, strPower As String)
        If strFunctionName = "power" Then
            If strPower = "1" Then
                dlgRegressionSimple.clsModel.SetParameter(False, strValue:=dlgRegressionSimple.ucrExplanatory.GetVariableNames(bWithQuotes:=False))
            Else
                clsModel1.SetOperation("^")
                clsModel1.bBrackets = False
                clsModel1.SetParameter(True, strValue:=dlgRegressionSimple.ucrExplanatory.GetVariableNames(bWithQuotes:=False))
                clsModel1.SetParameter(False, strValue:=strPower)
                dlgRegressionSimple.clsModel.SetParameter(False, clsOp:=clsModel1)
            End If
        Else
            clsRToFunction.SetRCommand(strFunctionName)
            clsRToFunction.AddParameter("x", dlgRegressionSimple.ucrExplanatory.GetVariableNames(bWithQuotes:=False))
            dlgRegressionSimple.clsModel.SetParameter(False, clsRFunc:=clsRToFunction)
        End If
    End Function

    Public Sub ModelFunction()
        If rdoLogBase10.Checked Then
            ExplanatoryFunction("log10", 1)
        End If
        If rdoNaturallog.Checked Then
            ExplanatoryFunction("log", 1)
        End If
        If rdoSquareroot.Checked Then
            ExplanatoryFunction("sqrt", 1)
        End If
        If rdoPower.Checked Then
            ExplanatoryFunction("power", nudPower.Value)
        End If
    End Sub
End Class