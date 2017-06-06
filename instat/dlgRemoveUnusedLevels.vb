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

Imports RDotNet
Imports instat.Translations
Public Class dlgRemoveUnusedLevels
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsUnusedLevels, clstable, clsSum As New RFunction
    Private clsTableOperation As New ROperator

    Private Sub dlgRemoveUnusedLevels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        TestOKEnabled()
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 40

        'Set receiver
        ucrReceiverFactorColumn.Selector = ucrSelectorFactorColumn
        ucrReceiverFactorColumn.SetMeAsReceiver()
        ucrReceiverFactorColumn.SetIncludedDataTypes({"factor"})

        ucrRemoveUnusedFactorLevels.SetReceiver(ucrReceiverFactorColumn)
        ucrRemoveUnusedFactorLevels.SetIncludeLevels(False)

        'Set selector data frame
        ucrSelectorFactorColumn.SetParameter(New RParameter("data_name", 0))
        ucrSelectorFactorColumn.SetParameterIsString()

        ucrReceiverFactorColumn.SetParameter(New RParameter("col_name", 1))
        ucrReceiverFactorColumn.SetParameterIsString()
    End Sub

    Private Sub SetDefaults()
        clsUnusedLevels = New RFunction
        ucrSelectorFactorColumn.Reset()
        clsUnusedLevels.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$drop_unused_factor_levels")
        ucrBase.clsRsyntax.SetBaseRFunction(clsUnusedLevels)
    End Sub

    Private Sub SetRCodeforControls(bReset As Boolean)
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If ucrReceiverFactorColumn.IsEmpty() Then
            ucrBase.OKEnabled(False)
        Else
            ucrBase.OKEnabled(True)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeforControls(True)
        TestOKEnabled()
    End Sub

    Private Sub Controls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverFactorColumn.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrReceiverFactorColumn_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrReceiverFactorColumn.ControlValueChanged
        Dim numOutput As Integer
        clstable.SetRCommand("table")
        clsSum.SetRCommand("sum")
        If Not ucrReceiverFactorColumn.IsEmpty Then
            clstable.AddParameter("x", clsRFunctionParameter:=ucrReceiverFactorColumn.GetVariables)
            clsTableOperation.SetOperation("==")
            clsTableOperation.AddParameter(clsRFunctionParameter:=clstable, iPosition:=0)
            clsTableOperation.AddParameter("threshhold", 0, iPosition:=1)

            clsSum.AddParameter("x", clsROperatorParameter:=clsTableOperation)

            numOutput = frmMain.clsRLink.RunInternalScriptGetValue(clsSum.ToScript).AsNumeric(0)
            If numOutput = 0 Then
                ucrInputUnusedLevels.SetName("no unused levels to remove")
            Else
                ucrInputUnusedLevels.SetName(numOutput & " unused levels will be removed")
            End If
        Else
            clstable.RemoveParameterByName("x")
        End If
    End Sub
End Class