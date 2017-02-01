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

Public Class ucrCheck
    ''Is the checkbox linked to specific parameter values when checked/unchecked
    'Private bIsParameterValue As Boolean = True

    Private strValueIfChecked As String = "TRUE"
    Private strValueIfUnchecked As String = "FALSE"

    ''Is the checkbox linked to a parameter only by whether the parameter is present or not, irrespective of the parameter value
    'Private bIsParameterPresent As Boolean = False

    ''When bIsParameterPresent should the control be checked when the parameter is present (and unchecked when not present)
    ''If = False then the opposite.
    'Private bParameterIncludedWhenChecked As Boolean = True

    Public Overrides Sub UpdateControl(Optional bReset As Boolean = False)

        MyBase.UpdateControl(bReset)

        If clsParameter IsNot Nothing Then
            If bChangeParameterValue Then
                If clsParameter.strArgumentValue = strValueIfChecked OrElse clsParameter.strArgumentValue = strValueIfUnchecked Then
                    chkCheck.Checked = (clsParameter.strArgumentValue = strValueIfChecked)
                Else
                    MsgBox("Developer error: The value of parameter " & clsParameter.strArgumentName & ": " & clsParameter.strArgumentValue & " does not match strValueIfChecked or strValueIfUnchecked so cannot determine state for the checkbox. Setting as the default instead.")
                    chkCheck.Checked = False
                End If
            ElseIf bAddRemoveParameter Then
                'Commented out as not currently needed. Can be included if needed.
                'If bParameterIncludedWhenChecked Then
                chkCheck.Checked = clsRCode.ContainsParameter(clsParameter)
                'Else
                'chkCheck.Checked = Not clsRCodeObject.clsParameters.Contains(clsParameter)
                'End If
            End If
        Else
            If lstValuesAndControl.Count > 0 Then
                chkCheck.Checked = LinkedControlsParametersPresent()
            End If
        End If
        UpdateLinkedControls()
    End Sub

    Public Sub SetValueIfChecked(strNewValueIfChecked As String)
        Dim clsTempCond As New Condition

        strValueIfChecked = strNewValueIfChecked
        If clsParameter Is Nothing Then
            MsgBox("Developer error: Parameter must be set before SetValueIfChecked can be run! Control will not update correctly.")
        Else
            AddParameterValuesCondition(True, clsParameter.strArgumentName, strValueIfChecked)
        End If
    End Sub

    Public Sub SetValueIfUnchecked(strNewValueIfUnchecked As String)
        strValueIfUnchecked = strNewValueIfUnchecked
        If clsParameter Is Nothing OrElse clsParameter.strArgumentName Is Nothing Then
            MsgBox("Developer error: Parameter must be set with a parameter name before SetValueIfUnchecked can be run! Control will not update correctly.")
        Else
            AddParameterValuesCondition(False, clsParameter.strArgumentName, strValueIfUnchecked)
        End If
    End Sub

    Public Sub SetValuesCheckedAndUnchecked(strNewValueIfChecked As String, strNewValueIfUnchecked As String)
        SetValueIfChecked(strNewValueIfChecked)
        SetValueIfUnchecked(strNewValueIfUnchecked)
    End Sub

    Private Sub chkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheck.CheckedChanged
        If bChangeParameterValue AndAlso clsParameter IsNot Nothing Then
            If chkCheck.Checked Then
                clsParameter.SetArgumentValue(strValueIfChecked)
            Else
                clsParameter.SetArgumentValue(strValueIfUnchecked)
            End If
        End If
        UpdateRCode()
        OnControlValueChanged()
    End Sub

    Public Property Checked As Boolean
        Get
            Return chkCheck.Checked
        End Get
        Set(bChecked As Boolean)
            chkCheck.Checked = bChecked
        End Set
    End Property

    Public Overrides Function ValueContainedIn(lstTemp As Object()) As Boolean
        Dim bTempValue As Boolean
        Dim bContainedIn As Boolean = False

        For Each objVal In lstTemp
            If Boolean.TryParse(objVal, bTempValue) Then
                If bTempValue = chkCheck.Checked Then
                    bContainedIn = True
                End If
            Else
                MsgBox("Developer error: Cannot convert value to boolean for linked control.")
            End If
        Next
        Return bContainedIn
    End Function

    Protected Overrides Sub SetControlValue(objTemp As Object)
        Dim bTempValue As Boolean

        If Boolean.TryParse(objTemp, bTempValue) Then
            Checked = bTempValue
        Else
            MsgBox("Developer error: Cannot set the value of " & Name & " because cannot convert value of object to boolean.")
        End If
    End Sub

    Public Overrides Property bAddRemoveParameter As Object
        Get
            Return MyBase.bAddRemoveParameter
        End Get
        Set(bValue As Object)
            MyBase.bAddRemoveParameter = bValue

        End Set
    End Property
End Class