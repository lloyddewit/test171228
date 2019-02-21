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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sdgWindrose
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sdgWindrose))
        Me.lblNoofDirections = New System.Windows.Forms.Label()
        Me.lblNoOfSpeeds = New System.Windows.Forms.Label()
        Me.lblCalmWind = New System.Windows.Forms.Label()
        Me.lblSpeedCuts = New System.Windows.Forms.Label()
        Me.ucrInputSpeedCuts = New instat.ucrInputTextBox()
        Me.ucrNudCalmWind = New instat.ucrNud()
        Me.ucrNudNoOfSpeeds = New instat.ucrNud()
        Me.ucrNudNoOfDirections = New instat.ucrNud()
        Me.ucrButtonsSdgWindrose = New instat.ucrButtonsSubdialogue()
        Me.lblTheme = New System.Windows.Forms.Label()
        Me.ucrInputTheme = New instat.ucrInputComboBox()
        Me.tbpWindRoseOptions = New System.Windows.Forms.TabControl()
        Me.tbpColours = New System.Windows.Forms.TabPage()
        Me.grpColours = New System.Windows.Forms.GroupBox()
        Me.ucrInputQualitative = New instat.ucrInputComboBox()
        Me.ucrInputDiverging = New instat.ucrInputComboBox()
        Me.ucrInputSequential = New instat.ucrInputComboBox()
        Me.rdoQualitative = New System.Windows.Forms.RadioButton()
        Me.rdoSequential = New System.Windows.Forms.RadioButton()
        Me.rdoDiverging = New System.Windows.Forms.RadioButton()
        Me.ucrPnlColourPalette = New instat.UcrPanel()
        Me.tbpTitles = New System.Windows.Forms.TabPage()
        Me.tbpWindRoseOptions.SuspendLayout()
        Me.tbpColours.SuspendLayout()
        Me.grpColours.SuspendLayout()
        Me.tbpTitles.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNoofDirections
        '
        resources.ApplyResources(Me.lblNoofDirections, "lblNoofDirections")
        Me.lblNoofDirections.Name = "lblNoofDirections"
        '
        'lblNoOfSpeeds
        '
        resources.ApplyResources(Me.lblNoOfSpeeds, "lblNoOfSpeeds")
        Me.lblNoOfSpeeds.Name = "lblNoOfSpeeds"
        '
        'lblCalmWind
        '
        resources.ApplyResources(Me.lblCalmWind, "lblCalmWind")
        Me.lblCalmWind.Name = "lblCalmWind"
        '
        'lblSpeedCuts
        '
        resources.ApplyResources(Me.lblSpeedCuts, "lblSpeedCuts")
        Me.lblSpeedCuts.Name = "lblSpeedCuts"
        '
        'ucrInputSpeedCuts
        '
        Me.ucrInputSpeedCuts.AddQuotesIfUnrecognised = True
        Me.ucrInputSpeedCuts.IsMultiline = False
        Me.ucrInputSpeedCuts.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputSpeedCuts, "ucrInputSpeedCuts")
        Me.ucrInputSpeedCuts.Name = "ucrInputSpeedCuts"
        '
        'ucrNudCalmWind
        '
        Me.ucrNudCalmWind.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudCalmWind.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudCalmWind, "ucrNudCalmWind")
        Me.ucrNudCalmWind.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudCalmWind.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudCalmWind.Name = "ucrNudCalmWind"
        Me.ucrNudCalmWind.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrNudNoOfSpeeds
        '
        Me.ucrNudNoOfSpeeds.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudNoOfSpeeds.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudNoOfSpeeds, "ucrNudNoOfSpeeds")
        Me.ucrNudNoOfSpeeds.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudNoOfSpeeds.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudNoOfSpeeds.Name = "ucrNudNoOfSpeeds"
        Me.ucrNudNoOfSpeeds.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrNudNoOfDirections
        '
        Me.ucrNudNoOfDirections.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudNoOfDirections.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudNoOfDirections, "ucrNudNoOfDirections")
        Me.ucrNudNoOfDirections.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudNoOfDirections.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudNoOfDirections.Name = "ucrNudNoOfDirections"
        Me.ucrNudNoOfDirections.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrButtonsSdgWindrose
        '
        resources.ApplyResources(Me.ucrButtonsSdgWindrose, "ucrButtonsSdgWindrose")
        Me.ucrButtonsSdgWindrose.Name = "ucrButtonsSdgWindrose"
        '
        'lblTheme
        '
        resources.ApplyResources(Me.lblTheme, "lblTheme")
        Me.lblTheme.Name = "lblTheme"
        '
        'ucrInputTheme
        '
        Me.ucrInputTheme.AddQuotesIfUnrecognised = True
        Me.ucrInputTheme.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputTheme, "ucrInputTheme")
        Me.ucrInputTheme.Name = "ucrInputTheme"
        '
        'tbpWindRoseOptions
        '
        Me.tbpWindRoseOptions.Controls.Add(Me.tbpColours)
        Me.tbpWindRoseOptions.Controls.Add(Me.tbpTitles)
        resources.ApplyResources(Me.tbpWindRoseOptions, "tbpWindRoseOptions")
        Me.tbpWindRoseOptions.Name = "tbpWindRoseOptions"
        Me.tbpWindRoseOptions.SelectedIndex = 0
        '
        'tbpColours
        '
        Me.tbpColours.Controls.Add(Me.grpColours)
        resources.ApplyResources(Me.tbpColours, "tbpColours")
        Me.tbpColours.Name = "tbpColours"
        Me.tbpColours.UseVisualStyleBackColor = True
        '
        'grpColours
        '
        Me.grpColours.Controls.Add(Me.ucrInputQualitative)
        Me.grpColours.Controls.Add(Me.ucrInputDiverging)
        Me.grpColours.Controls.Add(Me.ucrInputSequential)
        Me.grpColours.Controls.Add(Me.rdoQualitative)
        Me.grpColours.Controls.Add(Me.rdoSequential)
        Me.grpColours.Controls.Add(Me.rdoDiverging)
        Me.grpColours.Controls.Add(Me.ucrPnlColourPalette)
        resources.ApplyResources(Me.grpColours, "grpColours")
        Me.grpColours.Name = "grpColours"
        Me.grpColours.TabStop = False
        '
        'ucrInputQualitative
        '
        Me.ucrInputQualitative.AddQuotesIfUnrecognised = True
        Me.ucrInputQualitative.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputQualitative, "ucrInputQualitative")
        Me.ucrInputQualitative.Name = "ucrInputQualitative"
        '
        'ucrInputDiverging
        '
        Me.ucrInputDiverging.AddQuotesIfUnrecognised = True
        Me.ucrInputDiverging.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputDiverging, "ucrInputDiverging")
        Me.ucrInputDiverging.Name = "ucrInputDiverging"
        '
        'ucrInputSequential
        '
        Me.ucrInputSequential.AddQuotesIfUnrecognised = True
        Me.ucrInputSequential.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputSequential, "ucrInputSequential")
        Me.ucrInputSequential.Name = "ucrInputSequential"
        '
        'rdoQualitative
        '
        resources.ApplyResources(Me.rdoQualitative, "rdoQualitative")
        Me.rdoQualitative.BackColor = System.Drawing.SystemColors.Control
        Me.rdoQualitative.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoQualitative.FlatAppearance.BorderSize = 2
        Me.rdoQualitative.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoQualitative.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoQualitative.Name = "rdoQualitative"
        Me.rdoQualitative.UseVisualStyleBackColor = True
        '
        'rdoSequential
        '
        resources.ApplyResources(Me.rdoSequential, "rdoSequential")
        Me.rdoSequential.BackColor = System.Drawing.SystemColors.Control
        Me.rdoSequential.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoSequential.FlatAppearance.BorderSize = 2
        Me.rdoSequential.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoSequential.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoSequential.Name = "rdoSequential"
        Me.rdoSequential.UseVisualStyleBackColor = True
        '
        'rdoDiverging
        '
        resources.ApplyResources(Me.rdoDiverging, "rdoDiverging")
        Me.rdoDiverging.BackColor = System.Drawing.SystemColors.Control
        Me.rdoDiverging.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoDiverging.FlatAppearance.BorderSize = 2
        Me.rdoDiverging.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoDiverging.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoDiverging.Name = "rdoDiverging"
        Me.rdoDiverging.UseVisualStyleBackColor = True
        '
        'ucrPnlColourPalette
        '
        resources.ApplyResources(Me.ucrPnlColourPalette, "ucrPnlColourPalette")
        Me.ucrPnlColourPalette.Name = "ucrPnlColourPalette"
        '
        'tbpTitles
        '
        Me.tbpTitles.Controls.Add(Me.ucrInputSpeedCuts)
        Me.tbpTitles.Controls.Add(Me.ucrInputTheme)
        Me.tbpTitles.Controls.Add(Me.ucrNudNoOfDirections)
        Me.tbpTitles.Controls.Add(Me.lblTheme)
        Me.tbpTitles.Controls.Add(Me.ucrNudNoOfSpeeds)
        Me.tbpTitles.Controls.Add(Me.lblSpeedCuts)
        Me.tbpTitles.Controls.Add(Me.ucrNudCalmWind)
        Me.tbpTitles.Controls.Add(Me.lblCalmWind)
        Me.tbpTitles.Controls.Add(Me.lblNoofDirections)
        Me.tbpTitles.Controls.Add(Me.lblNoOfSpeeds)
        resources.ApplyResources(Me.tbpTitles, "tbpTitles")
        Me.tbpTitles.Name = "tbpTitles"
        Me.tbpTitles.UseVisualStyleBackColor = True
        '
        'sdgWindrose
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tbpWindRoseOptions)
        Me.Controls.Add(Me.ucrButtonsSdgWindrose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "sdgWindrose"
        Me.tbpWindRoseOptions.ResumeLayout(False)
        Me.tbpColours.ResumeLayout(False)
        Me.grpColours.ResumeLayout(False)
        Me.tbpTitles.ResumeLayout(False)
        Me.tbpTitles.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrButtonsSdgWindrose As ucrButtonsSubdialogue
    Friend WithEvents ucrNudNoOfDirections As ucrNud
    Friend WithEvents lblNoofDirections As Label
    Friend WithEvents ucrNudNoOfSpeeds As ucrNud
    Friend WithEvents lblNoOfSpeeds As Label
    Friend WithEvents ucrNudCalmWind As ucrNud
    Friend WithEvents lblCalmWind As Label
    Friend WithEvents lblSpeedCuts As Label
    Friend WithEvents ucrInputSpeedCuts As ucrInputTextBox
    Friend WithEvents lblTheme As Label
    Friend WithEvents ucrInputTheme As ucrInputComboBox
    Friend WithEvents tbpWindRoseOptions As TabControl
    Friend WithEvents tbpColours As TabPage
    Friend WithEvents tbpTitles As TabPage
    Friend WithEvents grpColours As GroupBox
    Friend WithEvents ucrInputQualitative As ucrInputComboBox
    Friend WithEvents ucrInputDiverging As ucrInputComboBox
    Friend WithEvents ucrInputSequential As ucrInputComboBox
    Friend WithEvents rdoQualitative As RadioButton
    Friend WithEvents rdoSequential As RadioButton
    Friend WithEvents rdoDiverging As RadioButton
    Friend WithEvents ucrPnlColourPalette As UcrPanel
End Class
