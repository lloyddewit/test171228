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
Imports instat
Imports instat.Translations
Imports RDotNet

Public Class dlgReplace
    Public bFirstLoad As Boolean = True
    Private bReset As Boolean = True

    Private Sub dlgReplace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ucrBase.iHelpTopicID = 47

        ' GOT:
        ' # dlgReplace code generated by the dialog Replace

        ' Want:  InstatDataObject$replace_value_in_data(old_value= 1, new_value=2, data_name="Damango", col_names="Year")
        ' Got:   InstatDataObject$replace_value_in_data(data_name = "Damango", col_names = "Year", start_value = "", end_value = "")

        ' Want:  InstatDataObject$replace_value_in_data(col_names= "Year", old_value=2, new_value = NA, data_name="Damango")
        ' Got:   InstatDataObject$replace_value_in_data(data_name = "Damango", col_names = "Year", new_value = "NA", end_value = "", start_value = "")


        ' Want:  InstatDataObject$replace_value_in_data(data_name= "Damango", col_names="Year", end_value="200", start_value="12", new_value="NA")
        ' Got:   InstatDataObject$replace_value_in_data(start_value= 1, end_value=2000, data_name="Damango", col_names="Year", new_value=2)


        ' PROBLEMS:
        ' on OLD, value and missing are on a different panel to start/end value
        ' The inputs should have chr(34)'s if it is a factor, else no chr(34)

        rdoFromAbove.Enabled = False

        'ucrSelector
        ucrSelectorReplace.SetParameter(New RParameter("data_name", 0))
        ucrSelectorReplace.SetParameterIsString()


        'ucrReceiver
        ucrReceiverReplace.SetParameter(New RParameter("col_names", 1))
        ucrReceiverReplace.Selector = ucrSelectorReplace
        ucrReceiverReplace.SetMeAsReceiver()
        ucrReceiverReplace.SetSingleTypeStatus(True)
        ucrReceiverReplace.SetParameterIsString()




        ' OLD PANEL:
        SetParameter({ucrPnlOld, ucrInputOldValue}, New RParameter("old_value", 1))
        ucrPnlOld.AddRadioButton(rdoOldValue, ucrInputOldValue.GetText)
        ucrPnlOld.AddRadioButton(rdoOldMissing, Chr(34) & "NA" & Chr(34))
        '        ucrPnlOld.AddToLinkedControls(ucrLinked:=ucrInputOldValue, objValues:={True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ''ucrPnlOld.bChangeParameterValue = False ' currently this line means old_value does not run and is not selected
        ucrInputOldValue.bAddRemoveParameter = False
        'ucrInputOldValue.SetValidationTypeAsRVariable()
        ucrInputOldValue.SetName("")
        'ucrPnlOld.SetRDefault(Chr(34) & "0" & Chr(34)) ' rdoOldValue to be default, but it varies



        ' RANGE:
        '' If the third rdo is selected, then we run two parameters - both different to the first two
        ' this is not right, since I have created a panel for the new, separate one.

        ' What I am trying to do:
        ' We have two functions associated with this parameter: start_value and end_value
        ' These two functions also have four linkings associated with them + two labels
        SetParameter({ucrPnlRange, ucrInputRangeFrom, ucrInputRangeTo}, New RParameter("start_value", 3))
        ucrPnlRange.AddRadioButton(rdoRange, "0")
        ucrPnlRange.bChangeParameterValue = False

        ucrPnlRange.AddToLinkedControls(ucrLinked:=ucrInputRangeFrom, objValues:={True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrInputRangeFrom.SetName("0")
        ucrInputRangeFrom.bChangeParameterValue = False
        ucrInputRangeFrom.SetLabel(lblRangeMin)

        ucrPnlRange.AddToLinkedControls(ucrLinked:=ucrChkMinimum, objValues:={True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrChkMinimum.SetParameter(New RParameter("closed_start_value"))
        ucrChkMinimum.SetText("Including")
        ucrChkMinimum.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkMinimum.bAddRemoveParameter = False
        ucrChkMinimum.SetRDefault("FALSE")

        ' Would I want
        '         SetParameter({ucrPnlRange, ucrInputRangeTo}, New RParameter("end_value", 3))
        ' Or:

        ucrPnlRange.AddParameterPresentCondition(rdoRange, "end_value", "1")
        ucrPnlRange.AddToLinkedControls(ucrLinked:=ucrInputRangeTo, objValues:={True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrInputRangeTo.SetName("1")
        ucrInputRangeTo.bChangeParameterValue = False
        ucrInputRangeTo.SetLabel(lblRangeMax)

        ucrPnlRange.AddToLinkedControls(ucrLinked:=ucrChkMaximum, objValues:={True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrChkMaximum.SetParameter(New RParameter("closed_end_value"))
        ucrChkMaximum.SetText("Including")
        ucrChkMaximum.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkMaximum.bAddRemoveParameter = False
        ucrChkMaximum.SetRDefault("FALSE")



        '' NEW VALUES:
        SetParameter({ucrPnlNew, ucrInputNewValue}, New RParameter("new_value", 7))
        ucrPnlNew.AddRadioButton(rdoNewValue, ucrInputNewValue.GetText()) ' value in input
        ucrPnlNew.AddRadioButton(rdoNewMissing, "NA")
        'ucrPnlNew.SetRDefault() R default is ucrInputNewValue, however, we can't put that in as it varies

        ' linked for just rdoNewValue
        'ucrPnlNew.AddToLinkedControls(ucrLinked:=ucrInputNewValue, objValues:={True}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        'ucrPnlNew.bChangeParameterValue = False ' currently this line means new_value does not run and is not selected
        ucrInputNewValue.bAddRemoveParameter = False
        'ucrInputNewValue.SetValidationTypeAsRVariable()
        ucrInputNewValue.SetName("")
    End Sub

    Private Sub SetDefaults()
        Dim clsDefaultFunction As New RFunction
        ucrSelectorReplace.Reset()

        clsDefaultFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$replace_value_in_data")
        clsDefaultFunction.AddParameter("old_value", Chr(34) & "" & Chr(34)) 'default this is checked, however, this value varies so I don't know how to do this
        clsDefaultFunction.AddParameter("new_value", Chr(34) & "" & Chr(34))
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction.Clone())
    End Sub

    Private Sub SetRCodeforControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub ReopenDialog()

    End Sub

    Private Sub TestOKEnabled()
        If (Not ucrReceiverReplace.IsEmpty()) Then
            '           If (rdoOldValue.Checked AndAlso ucrInputOldValue.IsEmpty()) OrElse (rdoRange.Checked AndAlso ucrInputRangeFrom.IsEmpty() AndAlso ucrInputRangeTo.IsEmpty()) OrElse (rdoNewValue.Checked AndAlso ucrInputNewValue.IsEmpty()) Then
            '           ucrBase.OKEnabled(False)
            '       Else
            ucrBase.OKEnabled(True)
            '           End If
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBaseReplace_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeforControls(True)
        TestOKEnabled()
    End Sub

    Private Sub InputOldValue()
        Dim strVarType As String

        If ucrInputOldValue.IsEmpty() Then
            ucrBase.clsRsyntax.RemoveParameter("old_value")
        Else
            If Not ucrReceiverReplace.IsEmpty Then
                strVarType = ucrReceiverReplace.GetCurrentItemTypes(True)(0)
            Else
                strVarType = ""
            End If
            If (strVarType = "numeric" OrElse strVarType = "integer") Then
                ucrBase.clsRsyntax.AddParameter("old_value", ucrInputOldValue.GetText)
            Else
                ucrBase.clsRsyntax.AddParameter("old_value", Chr(34) & ucrInputOldValue.GetText() & Chr(34))
            End If
        End If
    End Sub

    Private Sub InputNewValue()
        Dim strVarType As String

        If ucrInputNewValue.IsEmpty() Then
            ucrBase.clsRsyntax.RemoveParameter("new_value")
        Else
            If Not ucrReceiverReplace.IsEmpty Then
                strVarType = ucrReceiverReplace.GetCurrentItemTypes(True)(0)
            Else
                strVarType = ""
            End If
            If (strVarType = "numeric" OrElse strVarType = "integer") Then
                ucrBase.clsRsyntax.AddParameter("new_value", ucrInputNewValue.GetText())
            Else
                ucrBase.clsRsyntax.AddParameter("new_value", Chr(34) & ucrInputNewValue.GetText & Chr(34))
            End If
        End If
    End Sub

    Private Sub rdoOldValue_CheckedChanged(sender As Object, e As EventArgs) Handles rdoOldValue.CheckedChanged
        If rdoOldValue.Checked Then
            ucrInputOldValue.Visible = True
            InputOldValue()
        Else
            ucrBase.clsRsyntax.RemoveParameter("old_value")
            ucrInputOldValue.Visible = False
        End If
        TestOKEnabled()
    End Sub

    Private Sub rdoNewValue_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNewValue.CheckedChanged
        If rdoNewValue.Checked Then
            ucrInputNewValue.Visible = True
            InputNewValue()
        Else
            ucrInputNewValue.Visible = False
            ucrBase.clsRsyntax.RemoveParameter("new_value")
        End If
        TestOKEnabled()
    End Sub

    Private Sub ucrInputOldValue_NameChanged() Handles ucrInputOldValue.NameChanged
        If rdoOldValue.Checked Then
            InputOldValue()
        Else
            ucrBase.clsRsyntax.RemoveParameter("old_value")
        End If
        TestOKEnabled()
    End Sub

    Private Sub ucrInputRangeFrom_NameChanged() Handles ucrInputRangeFrom.NameChanged
        RangeFromParameter()
        TestOKEnabled()
    End Sub

    Private Sub RangeFromParameter()
        If rdoRange.Checked Then
            ucrChkMaximum.Visible = True
            ucrChkMinimum.Visible = True
        Else
            ucrChkMaximum.Visible = False
            ucrChkMinimum.Visible = False
        End If
    End Sub

    Private Sub ucrInputRangeTo_NameChanged() Handles ucrInputRangeTo.NameChanged
        '        RangeToParameter()
        TestOKEnabled()
    End Sub

    '    Private Sub RangeToParameter()
    '    If rdoRange.Checked Then
    '    If ucrInputRangeTo.IsEmpty() Then
    '                ucrBase.clsRsyntax.RemoveParameter("end_value")
    '    Else
    '                ucrBase.clsRsyntax.AddParameter("end_value", ucrInputRangeTo.GetText)
    '    End If
    '    Else
    '            ucrBase.clsRsyntax.RemoveParameter("end_value")
    '    End If
    '    End Sub

    '    Private Sub ucrInputNewValue_NameChanged() Handles ucrInputNewValue.NameChanged
    '   If rdoNewValue.Checked Then
    '            InputNewValue()
    '    Else
    '            ucrBase.clsRsyntax.RemoveParameter("new_value")
    '    End If
    '        TestOKEnabled()
    '    End Sub

    Private Sub chkClosedLowerRange_CheckedChanged(sender As Object, e As EventArgs)
        ClosedRangeParameters()
        TestOKEnabled()
    End Sub

    Private Sub chkClosedUpperRange_CheckedChanged(sender As Object, e As EventArgs)
        ClosedRangeParameters()
        TestOKEnabled()
    End Sub

    Private Sub ClosedRangeParameters()
        '        If rdoRange.Checked Then
        '            '            If chkIncludingMaximum.Checked Then
        '            If frmMain.clsInstatOptions.bIncludeRDefaultParameters Then
        '                    ucrBase.clsRsyntax.AddParameter("closed_end_value", "TRUE")
        '                Else
        '                    ucrBase.clsRsyntax.RemoveParameter("closed_end_value")
        '                End If
        '            Else
        '                ucrBase.clsRsyntax.AddParameter("closed_end_value", "FALSE")
        '           End If

        '            If chkIncludeMinimum.Checked Then
        '        If frmMain.clsInstatOptions.bIncludeRDefaultParameters Then
        '                    ucrBase.clsRsyntax.AddParameter("closed_start_value", "TRUE")
        '                Else
        '                    ucrBase.clsRsyntax.RemoveParameter("closed_start_value")
        '                End If
        '            Else
        '                ucrBase.clsRsyntax.AddParameter("closed_start_value", "FALSE")
        '            End If
        '        Else
        '        ucrBase.clsRsyntax.RemoveParameter("closed_start_value")
        '        ucrBase.clsRsyntax.RemoveParameter("closed_end_value")
        '        End If
    End Sub

    Private Sub rdoNewMissing_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNewMissing.CheckedChanged
        If rdoNewMissing.Checked Then
            ucrBase.clsRsyntax.AddParameter("new_value", "NA")
        Else
            ucrBase.clsRsyntax.RemoveParameter("new_value")
        End If
        TestOKEnabled()
    End Sub

    Private Sub RangeEnable()
        Dim strVarType As String

        If Not ucrReceiverReplace.IsEmpty Then
            strVarType = ucrReceiverReplace.GetCurrentItemTypes(True)(0)
        Else
            strVarType = ""
        End If

        If strVarType = "" OrElse strVarType = "numeric" OrElse strVarType = "integer" Then
            rdoRange.Enabled = True
        Else
            rdoRange.Enabled = False
            If rdoRange.Checked Then
                rdoOldValue.Checked = True
            End If
        End If
    End Sub

    Private Sub ucrReceiverReplace_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverReplace.ControlContentsChanged, ucrInputOldValue.ControlContentsChanged, ucrInputRangeFrom.ControlContentsChanged, ucrInputRangeTo.ControlContentsChanged, ucrInputNewValue.ControlContentsChanged, ucrPnlOld.ControlContentsChanged, ucrPnlNew.ControlContentsChanged, ucrPnlRange.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class