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
        ucrReceiverYVariate.Selector = ucrSelectorOneWayAnovaNonParam
        ucrReceiverFactor.Selector = ucrSelectorOneWayAnovaNonParam
        ucrReceiverFactor.SetDataType("factor")
        ucrReceiverYVariate.SetDataType("numeric")
        ucrReceiverFactor.SetParameter(New RParameter("x"))
        ucrReceiverFactor.SetParameterIsString()
        ucrReceiverFactor.bWithQuotes = False
        ucrReceiverYVariate.SetParameter(New RParameter("g"))
        ucrReceiverYVariate.SetParameterIsString()
        ucrReceiverYVariate.bWithQuotes = False

        ucrSelectorOneWayAnovaNonParam.SetParameter(New RParameter("data"))
        ucrSelectorOneWayAnovaNonParam.SetParameterIsrfunction()

    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)
        ucrSelectorOneWayAnovaNonParam.SetRCode(clsKruskalWallis, bReset)
        ucrReceiverYVariate.SetRCode(clsModel, bReset)
        ucrReceiverFactor.SetRCode(clsModel, bReset)
    End Sub

    Private Sub SetDefaults()
        clsModel = New ROperator
        clsKruskalWallis = New RFunction

        ucrSelectorOneWayAnovaNonParam.Reset()
        ucrReceiverYVariate.SetMeAsReceiver()
        clsModel.SetOperation("~")
        clsKruskalWallis.SetPackageName("stats")
        clsKruskalWallis.SetRCommand("kruskal.test")
        clsModel.SetOperation("~")
        clsKruskalWallis.AddParameter("formula", clsROperatorParameter:=clsModel)
        ucrBase.clsRsyntax.SetBaseRFunction(clsKruskalWallis)
    End Sub

    Private Sub TestOKEnabled()
        If (Not ucrReceiverYVariate.IsEmpty()) And (Not ucrReceiverFactor.IsEmpty()) Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If

    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub Controls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverFactor.ControlContentsChanged, ucrReceiverYVariate.ControlContentsChanged
        TestOKEnabled()
    End Sub

End Class