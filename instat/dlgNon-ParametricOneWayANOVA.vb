﻿'Instat-R
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
Public Class dlgNon_ParametricOneWayANOVA
    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private clsModel As New ROperator
    Private clsKruskalWallis As New RFunction

    Private Sub dlgNon_ParametricOneWayANOVA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        TestOKEnabled()
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 183

        ucrBase.clsRsyntax.iCallType = 2
        ucrReceiverYVariate.Selector = ucrDataFrameAddRemove
        ucrReceiverFactor.Selector = ucrDataFrameAddRemove
        ucrReceiverFactor.SetDataType("factor")
        clsModel.SetOperation("~")

    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)

    End Sub

    Private Sub SetDefaults()
        clsModel = New ROperator
        clsKruskalWallis = New RFunction

        ucrDataFrameAddRemove.Reset()
        ucrReceiverYVariate.SetMeAsReceiver()
        clsKruskalWallis.SetRCommand("kruskal.test")
        clsModel.AddParameter(strParameterValue:=ucrReceiverYVariate.GetVariableNames(bWithQuotes:=False), iPosition:=0)

    End Sub

    Private Sub ucrReceiverYVariate_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiverYVariate.SelectionChanged
        clsModel.AddParameter(iPosition:=0, strParameterValue:=ucrReceiverYVariate.GetVariableNames(bWithQuotes:=False))
        TestOKEnabled()
    End Sub

    Private Sub ucrReceiverFactor_SelectionChanged(sender As Object, e As EventArgs) Handles ucrReceiverFactor.SelectionChanged
        clsModel.AddParameter(iPosition:=0, strParameterValue:=ucrReceiverFactor.GetVariableNames(bWithQuotes:=False))
        TestOKEnabled()
    End Sub

    Private Sub TestOKEnabled()
        If (Not ucrReceiverYVariate.IsEmpty()) And (Not ucrReceiverFactor.IsEmpty()) Then
            ucrBase.clsRsyntax.AddParameter("formula", clsROperatorParameter:=clsModel)
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If

    End Sub

    Private Sub ucrDataFrameAddRemove_DataFrameChanged() Handles ucrDataFrameAddRemove.DataFrameChanged
        ucrBase.clsRsyntax.AddParameter("x", clsRFunctionParameter:=ucrDataFrameAddRemove.ucrAvailableDataFrames.clsCurrDataFrame)
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
    End Sub
End Class