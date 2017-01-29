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
Public Class dlgViewDescriptives
    Public bFirstLoad As Boolean = True
    Private clsDefaultFunction As New RFunction
    Private Sub dlgViewDescriptives_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)

        If bFirstLoad Then
            InitialiseDialog()
            SetDefaults()
            bFirstLoad = False
        Else
            ReopenDialog()
        End If
    End Sub

    Private Sub ReopenDialog()

    End Sub

    ' InstatDataObject$get_objects(object_name="one_var1", data_name="Damango")

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 349

        ' ucr selector
        ucrSelectorForViewObject.SetParameter(New RParameter("data_name", 0))
        ucrSelectorForViewObject.SetParameterIsString()
        ucrSelectorForViewObject.SetItemType("object")

        ' ucr receiver
        ucrReceiverSelectedObject.SetParameter(New RParameter("object_name", 1))
        ucrReceiverSelectedObject.SetParameterIsString()
        ucrReceiverSelectedObject.Selector = ucrSelectorForViewObject
        ucrReceiverSelectedObject.SetMeAsReceiver()

        ' rdo's
        'ucrPnl.SetParameter(New RParameter("", 2))
        '        ucrPnl.AddRadioButton(rdoStructure, Chr(34) & "" & Chr(34))
        '        ucrPnl.AddRadioButton(rdoAllContents, Chr(34) & "" & Chr(34))
        '        ucrPnl.AddRadioButton(rdoComponent, Chr(34) & "" & Chr(34))
        '        ucrPnl.AddRadioButton(rdoViewGraph, Chr(34) & "" & Chr(34))
        '        ucrPnl.SetRDefault(Chr(34) & "" & Chr(34)) ' rdoViewGraph

        ucrBase.clsRsyntax.iCallType = 2
        rdoAllContents.Enabled = False
        rdoComponent.Enabled = False
        rdoViewGraph.Enabled = False

        clsDefaultFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_objects")
        '        clsDefaultFunction.AddParameter("", Chr(34) & "" & Chr(34)) ' rdoViewGraph option
    End Sub

    Private Sub SetDefaults()
        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultFunction.Clone())
        ucrSelectorForViewObject.Reset()
        SetRCode(Me, ucrBase.clsRsyntax.clsBaseFunction, True)
        TestOKEnabled()
        rdoStructure.Checked = True
        TestOKEnabled()
    End Sub

    Private Sub TestOKEnabled()
        If Not ucrReceiverSelectedObject.IsEmpty Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
    End Sub

    Private Sub rdoViewGraph_CheckedChanged(sender As Object, e As EventArgs) Handles rdoViewGraph.CheckedChanged
        If rdoViewGraph.Checked Then
            ucrBase.clsRsyntax.iCallType = 0
        Else
            ucrBase.clsRsyntax.iCallType = 2
        End If
    End Sub

    Private Sub ucrReceiverSelectedObject_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverSelectedObject.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class