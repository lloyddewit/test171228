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

Public Class ucrAxes
    Public bIsX As Boolean
    Public clsRsyntax As New RSyntax
    Public clsTitleFunction As New RFunction
    Public clsScalecontinuousFunction As New RFunction
    Public clsSeqFunction As New RFunction
    Public strAxis As String
    Public bFirstLoad As Boolean = True

    Private Sub ucrAxes_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetDefaults()
            InitialiseControl()
            bFirstLoad = False
        End If
    End Sub

    Private Sub SetDefaults()
        rdoTitleAuto.Checked = True
        rdoScalesAuto.Checked = True
        rdoTickMarkersAuto.Checked = True
        TitleDefaults()
        ucrTickMarkers.SetName("Interval")
        TitleFunction()
        ucrOverwriteTitle.SetName("")

        ucrNudTickMarkersNoOfDecimalPlaces.Value = 0
        ucrNudFrom.Value = 0
        ucrNudTo.Value = 0
        ucrNudInStepsOf.Value = 0
        ucrNudLowerLimit.Value = 0
        ucrNudUpperLimit.Value = 0
        ucrNudScalesNoOfDecimalPlaces.Value = 0
    End Sub

    Public Sub Reset()
        SetDefaults()
    End Sub

    Private Sub InitialiseControl()
        'Axis Section
        ucrPnlAxisTitle.AddRadioButton(rdoTitleAuto)
        ucrPnlAxisTitle.AddRadioButton(rdoTitleCustom)
        ucrChkDisplayTitle.SetText("Diaplay")
        ucrChkOverwriteTitle.SetText("Overwrite Title")

        'Tick Markers section
        ucrPnlTickmarkers.AddRadioButton(rdoTickMarkersAuto)
        ucrPnlTickmarkers.AddRadioButton(rdoTickMarkersCustom)
        ucrPnlTickmarkers.AddToLinkedControls(ucrTickMarkers, {rdoTickMarkersCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrPnlTickmarkers.AddToLinkedControls(ucrNudFrom, {rdoTickMarkersCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudFrom.SetLinkedDisplayControl(lblFrom)

        ucrPnlTickmarkers.AddToLinkedControls(ucrNudTo, {rdoTickMarkersCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudTo.SetLinkedDisplayControl(lblTo)

        ucrPnlTickmarkers.AddToLinkedControls(ucrNudInStepsOf, {rdoTickMarkersCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudInStepsOf.SetLinkedDisplayControl(lblInStepsOf)

        ucrPnlTickmarkers.AddToLinkedControls(ucrNudTickMarkersNoOfDecimalPlaces, {rdoTickMarkersCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudTickMarkersNoOfDecimalPlaces.SetLinkedDisplayControl(lblTickMarkersNoOfDecimalPlaces)

        'these add parameters to clsSeqFunction
        ucrNudInStepsOf.SetParameter(New RParameter("by"))
        ucrNudTo.SetParameter(New RParameter("to"))
        ucrNudFrom.SetParameter(New RParameter("from"))

        'Scales section
        ucrPnlScales.AddRadioButton(rdoScalesAuto)
        ucrPnlScales.AddRadioButton(rdoScalesCustom)
        ucrPnlScales.AddToLinkedControls(ucrNudScalesNoOfDecimalPlaces, {rdoScalesCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudScalesNoOfDecimalPlaces.SetLinkedDisplayControl(lblScalesNoDecimalPlaces)

        ucrPnlScales.AddToLinkedControls(ucrNudLowerLimit, {rdoScalesCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudLowerLimit.SetLinkedDisplayControl(lblLowerLimit)

        ucrPnlScales.AddToLinkedControls(ucrNudUpperLimit, {rdoScalesCustom}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrNudUpperLimit.SetLinkedDisplayControl(lblUpperLimit)


        ucrTickMarkers.cboInput.Items.Add("Interval")
        ucrTickMarkers.cboInput.Items.Add("Specific Values")

        TitleDefaults()
    End Sub

    Private Sub TitleDefaults()
        If rdoTitleAuto.Checked Then
            ucrChkDisplayTitle.Visible = False
            ucrChkOverwriteTitle.Visible = False
            ucrOverwriteTitle.Visible = False
        ElseIf rdoTitleCustom.Checked Then
            ucrChkDisplayTitle.Visible = True
            ucrChkDisplayTitle.Checked = True
            ucrChkOverwriteTitle.Visible = True
            ucrChkOverwriteTitle.Checked = False
        End If
    End Sub

    Public Sub SetXorY(bIsXAxis As Boolean)
        If bIsXAxis Then
            bIsX = True
            strAxis = "x"
            clsTitleFunction.SetRCommand("xlab")
            clsScalecontinuousFunction.SetRCommand("scale_" & strAxis & "_continuous")

            ' put scale_x_continuous function here
        ElseIf bIsXAxis = False Then
            bIsX = False
            strAxis = "y"
            clsTitleFunction.SetRCommand("ylab")
            clsScalecontinuousFunction.SetRCommand("scale_" & strAxis & "_continuous")
            ' put scale_y_continuous function here

        End If
    End Sub

    Public Sub SetRsyntaxAxis(clsRsyntaxAxis As RSyntax)
        clsRsyntax = clsRsyntaxAxis
    End Sub

    Private Sub TitleFunction()
        If rdoTitleCustom.Checked AndAlso ucrChkDisplayTitle.Checked Then
            If ucrChkOverwriteTitle.Checked AndAlso Not ucrOverwriteTitle.IsEmpty Then
                clsTitleFunction.AddParameter("label", Chr(34) & ucrOverwriteTitle.GetText & Chr(34))
                clsRsyntax.AddOperatorParameter(strAxis & "axistitle", clsRFunc:=clsTitleFunction)
            Else
                clsRsyntax.RemoveOperatorParameter(strAxis & "axistitle")
            End If
        Else
            clsTitleFunction.AddParameter("label", Chr(34) & "" & Chr(34))
            clsRsyntax.AddOperatorParameter(strAxis & "axistitle", clsRFunc:=clsTitleFunction)
        End If
    End Sub

    Private Sub ScalesFunction()
        If rdoScalesCustom.Checked Then
            clsScalecontinuousFunction.AddParameter("limits", "c(" & ucrNudLowerLimit.Value & "," & ucrNudUpperLimit.Value & ")")
            clsRsyntax.AddOperatorParameter("scale_" & strAxis & "_continuous", clsRFunc:=clsScalecontinuousFunction)
        Else
            clsRsyntax.RemoveOperatorParameter("scale_" & strAxis & "_continuous")
        End If
    End Sub

    Private Sub ucrOverwriteTitle_NameChanged() Handles ucrOverwriteTitle.NameChanged
        If rdoTitleCustom.Checked Then
            TitleFunction()
        End If
    End Sub

    Private Sub ucrChkOverwriteTitle_CheckedChanged(sender As Object, e As EventArgs)
        If rdoTitleCustom.Checked AndAlso ucrChkOverwriteTitle.Checked Then
            ucrOverwriteTitle.Visible = True
        Else
            ucrOverwriteTitle.Visible = False
        End If
        TitleFunction()
    End Sub

    Private Sub ucrChkDisplayTitle_CheckedChanged(sender As Object, e As EventArgs)
        If rdoTitleCustom.Checked AndAlso ucrChkDisplayTitle.Checked Then
            ucrChkOverwriteTitle.Visible = True
            If ucrChkOverwriteTitle.Checked Then
                ucrOverwriteTitle.Visible = True
            Else
                ucrOverwriteTitle.Visible = False
            End If
        Else
            ucrChkOverwriteTitle.Visible = False
            ucrOverwriteTitle.Visible = False
        End If
        TitleFunction()
    End Sub

    Private Sub rdoTitleCustom_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTitleCustom.CheckedChanged
        TitleDefaults()
    End Sub

    Private Sub rdoTitleAuto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTitleAuto.CheckedChanged
        TitleDefaults()
    End Sub

    Private Sub ucrNudLowerLimit_TextChanged(sender As Object, e As EventArgs)
        ScalesFunction()
    End Sub
    Private Sub ucrNudScalesNoOfDecimalPlaces_TextChanged() Handles ucrNudScalesNoOfDecimalPlaces.ControlContentsChanged
        ucrNudUpperLimit.DecimalPlaces = ucrNudScalesNoOfDecimalPlaces.Value
        ucrNudLowerLimit.DecimalPlaces = ucrNudScalesNoOfDecimalPlaces.Value
    End Sub

    Private Sub ucrNudTickMarkersNoOfDecimalPlaces_ControlContentsChanged() Handles ucrNudTickMarkersNoOfDecimalPlaces.ControlContentsChanged
        ucrNudFrom.DecimalPlaces = ucrNudTickMarkersNoOfDecimalPlaces.Value
        ucrNudTo.DecimalPlaces = ucrNudTickMarkersNoOfDecimalPlaces.Value
        ucrNudInStepsOf.DecimalPlaces = ucrNudTickMarkersNoOfDecimalPlaces.Value
    End Sub

    Private Sub ucrTickMarkers_NameChanged() Handles ucrTickMarkers.NameChanged
        If rdoTickMarkersCustom.Checked Then
            If ucrTickMarkers.cboInput.SelectedItem = "Interval" Then
                clsSeqFunction.SetRCommand("seq")
                clsScalecontinuousFunction.AddParameter("breaks", clsRFunctionParameter:=clsSeqFunction)

            ElseIf ucrTickMarkers.cboInput.SelectedItem = "Specific Values" Then
                clsScalecontinuousFunction.RemoveParameterByName("breaks")
            End If
        End If
    End Sub
End Class

