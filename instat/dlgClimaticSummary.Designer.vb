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
Partial Class dlgClimaticSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgClimaticSummary))
        Me.rdoAnnual = New System.Windows.Forms.RadioButton()
        Me.rdoAnnualVariable = New System.Windows.Forms.RadioButton()
        Me.rdoWithinYear = New System.Windows.Forms.RadioButton()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.cmdSummary = New System.Windows.Forms.Button()
        Me.lblWithinYear = New System.Windows.Forms.Label()
        Me.ucrSelectorVariable = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrReceiverWithinYear = New instat.ucrReceiverSingle()
        Me.ucrReceiverElement = New instat.ucrReceiverSingle()
        Me.ucrReceiverDOY = New instat.ucrReceiverSingle()
        Me.ucrReceiverYear = New instat.ucrReceiverSingle()
        Me.ucrReceiverDate = New instat.ucrReceiverSingle()
        Me.ucrReceiverStation = New instat.ucrReceiverSingle()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrPnlAnnualWithin = New instat.UcrPanel()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.ucrChkOmitMissingValues = New instat.ucrCheck()
        Me.ucrChkStoreResults = New instat.ucrCheck()
        Me.ucrChkPrintOutput = New instat.ucrCheck()
        Me.ucrChkDropUnusedLevels = New instat.ucrCheck()
        Me.cmdDoyRange = New System.Windows.Forms.Button()
        Me.ucrInputFilterPreview = New instat.ucrInputTextBox()
        Me.grpOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdoAnnual
        '
        resources.ApplyResources(Me.rdoAnnual, "rdoAnnual")
        Me.rdoAnnual.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoAnnual.FlatAppearance.BorderSize = 2
        Me.rdoAnnual.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoAnnual.Name = "rdoAnnual"
        Me.rdoAnnual.TabStop = True
        Me.rdoAnnual.UseVisualStyleBackColor = True
        '
        'rdoAnnualVariable
        '
        resources.ApplyResources(Me.rdoAnnualVariable, "rdoAnnualVariable")
        Me.rdoAnnualVariable.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoAnnualVariable.FlatAppearance.BorderSize = 2
        Me.rdoAnnualVariable.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoAnnualVariable.Name = "rdoAnnualVariable"
        Me.rdoAnnualVariable.TabStop = True
        Me.rdoAnnualVariable.UseVisualStyleBackColor = True
        '
        'rdoWithinYear
        '
        resources.ApplyResources(Me.rdoWithinYear, "rdoWithinYear")
        Me.rdoWithinYear.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoWithinYear.FlatAppearance.BorderSize = 2
        Me.rdoWithinYear.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoWithinYear.Name = "rdoWithinYear"
        Me.rdoWithinYear.TabStop = True
        Me.rdoWithinYear.UseVisualStyleBackColor = True
        '
        'lblStation
        '
        resources.ApplyResources(Me.lblStation, "lblStation")
        Me.lblStation.Name = "lblStation"
        '
        'lblDate
        '
        resources.ApplyResources(Me.lblDate, "lblDate")
        Me.lblDate.Name = "lblDate"
        '
        'lblYear
        '
        resources.ApplyResources(Me.lblYear, "lblYear")
        Me.lblYear.Name = "lblYear"
        '
        'lblDay
        '
        resources.ApplyResources(Me.lblDay, "lblDay")
        Me.lblDay.Name = "lblDay"
        '
        'lblElement
        '
        resources.ApplyResources(Me.lblElement, "lblElement")
        Me.lblElement.Name = "lblElement"
        '
        'cmdSummary
        '
        resources.ApplyResources(Me.cmdSummary, "cmdSummary")
        Me.cmdSummary.Name = "cmdSummary"
        Me.cmdSummary.Tag = "Summaries"
        Me.cmdSummary.UseVisualStyleBackColor = True
        '
        'lblWithinYear
        '
        resources.ApplyResources(Me.lblWithinYear, "lblWithinYear")
        Me.lblWithinYear.Name = "lblWithinYear"
        '
        'ucrSelectorVariable
        '
        Me.ucrSelectorVariable.bShowHiddenColumns = False
        Me.ucrSelectorVariable.bUseCurrentFilter = True
        resources.ApplyResources(Me.ucrSelectorVariable, "ucrSelectorVariable")
        Me.ucrSelectorVariable.Name = "ucrSelectorVariable"
        '
        'ucrReceiverWithinYear
        '
        Me.ucrReceiverWithinYear.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverWithinYear, "ucrReceiverWithinYear")
        Me.ucrReceiverWithinYear.Name = "ucrReceiverWithinYear"
        Me.ucrReceiverWithinYear.Selector = Nothing
        Me.ucrReceiverWithinYear.strNcFilePath = ""
        Me.ucrReceiverWithinYear.ucrSelector = Nothing
        '
        'ucrReceiverElement
        '
        Me.ucrReceiverElement.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverElement, "ucrReceiverElement")
        Me.ucrReceiverElement.Name = "ucrReceiverElement"
        Me.ucrReceiverElement.Selector = Nothing
        Me.ucrReceiverElement.strNcFilePath = ""
        Me.ucrReceiverElement.ucrSelector = Nothing
        '
        'ucrReceiverDOY
        '
        Me.ucrReceiverDOY.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverDOY, "ucrReceiverDOY")
        Me.ucrReceiverDOY.Name = "ucrReceiverDOY"
        Me.ucrReceiverDOY.Selector = Nothing
        Me.ucrReceiverDOY.strNcFilePath = ""
        Me.ucrReceiverDOY.ucrSelector = Nothing
        '
        'ucrReceiverYear
        '
        Me.ucrReceiverYear.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverYear, "ucrReceiverYear")
        Me.ucrReceiverYear.Name = "ucrReceiverYear"
        Me.ucrReceiverYear.Selector = Nothing
        Me.ucrReceiverYear.strNcFilePath = ""
        Me.ucrReceiverYear.ucrSelector = Nothing
        '
        'ucrReceiverDate
        '
        Me.ucrReceiverDate.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverDate, "ucrReceiverDate")
        Me.ucrReceiverDate.Name = "ucrReceiverDate"
        Me.ucrReceiverDate.Selector = Nothing
        Me.ucrReceiverDate.strNcFilePath = ""
        Me.ucrReceiverDate.ucrSelector = Nothing
        '
        'ucrReceiverStation
        '
        Me.ucrReceiverStation.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverStation, "ucrReceiverStation")
        Me.ucrReceiverStation.Name = "ucrReceiverStation"
        Me.ucrReceiverStation.Selector = Nothing
        Me.ucrReceiverStation.strNcFilePath = ""
        Me.ucrReceiverStation.ucrSelector = Nothing
        '
        'ucrBase
        '
        resources.ApplyResources(Me.ucrBase, "ucrBase")
        Me.ucrBase.Name = "ucrBase"
        '
        'ucrPnlAnnualWithin
        '
        resources.ApplyResources(Me.ucrPnlAnnualWithin, "ucrPnlAnnualWithin")
        Me.ucrPnlAnnualWithin.Name = "ucrPnlAnnualWithin"
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.ucrChkOmitMissingValues)
        Me.grpOptions.Controls.Add(Me.ucrChkStoreResults)
        Me.grpOptions.Controls.Add(Me.ucrChkPrintOutput)
        Me.grpOptions.Controls.Add(Me.ucrChkDropUnusedLevels)
        resources.ApplyResources(Me.grpOptions, "grpOptions")
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.TabStop = False
        '
        'ucrChkOmitMissingValues
        '
        Me.ucrChkOmitMissingValues.Checked = False
        resources.ApplyResources(Me.ucrChkOmitMissingValues, "ucrChkOmitMissingValues")
        Me.ucrChkOmitMissingValues.Name = "ucrChkOmitMissingValues"
        '
        'ucrChkStoreResults
        '
        Me.ucrChkStoreResults.Checked = False
        resources.ApplyResources(Me.ucrChkStoreResults, "ucrChkStoreResults")
        Me.ucrChkStoreResults.Name = "ucrChkStoreResults"
        '
        'ucrChkPrintOutput
        '
        Me.ucrChkPrintOutput.Checked = False
        resources.ApplyResources(Me.ucrChkPrintOutput, "ucrChkPrintOutput")
        Me.ucrChkPrintOutput.Name = "ucrChkPrintOutput"
        '
        'ucrChkDropUnusedLevels
        '
        Me.ucrChkDropUnusedLevels.Checked = False
        resources.ApplyResources(Me.ucrChkDropUnusedLevels, "ucrChkDropUnusedLevels")
        Me.ucrChkDropUnusedLevels.Name = "ucrChkDropUnusedLevels"
        '
        'cmdDoyRange
        '
        resources.ApplyResources(Me.cmdDoyRange, "cmdDoyRange")
        Me.cmdDoyRange.Name = "cmdDoyRange"
        Me.cmdDoyRange.Tag = ""
        Me.cmdDoyRange.UseVisualStyleBackColor = True
        '
        'ucrInputFilterPreview
        '
        Me.ucrInputFilterPreview.AddQuotesIfUnrecognised = True
        Me.ucrInputFilterPreview.IsMultiline = False
        Me.ucrInputFilterPreview.IsReadOnly = True
        resources.ApplyResources(Me.ucrInputFilterPreview, "ucrInputFilterPreview")
        Me.ucrInputFilterPreview.Name = "ucrInputFilterPreview"
        '
        'dlgClimaticSummary
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrInputFilterPreview)
        Me.Controls.Add(Me.cmdDoyRange)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.ucrSelectorVariable)
        Me.Controls.Add(Me.ucrReceiverWithinYear)
        Me.Controls.Add(Me.lblWithinYear)
        Me.Controls.Add(Me.cmdSummary)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrReceiverElement)
        Me.Controls.Add(Me.ucrReceiverDOY)
        Me.Controls.Add(Me.ucrReceiverYear)
        Me.Controls.Add(Me.ucrReceiverDate)
        Me.Controls.Add(Me.ucrReceiverStation)
        Me.Controls.Add(Me.rdoWithinYear)
        Me.Controls.Add(Me.rdoAnnualVariable)
        Me.Controls.Add(Me.rdoAnnual)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrPnlAnnualWithin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgClimaticSummary"
        Me.grpOptions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents rdoAnnual As RadioButton
    Friend WithEvents rdoAnnualVariable As RadioButton
    Friend WithEvents rdoWithinYear As RadioButton
    Friend WithEvents ucrPnlAnnualWithin As UcrPanel
    Friend WithEvents ucrReceiverStation As ucrReceiverSingle
    Friend WithEvents ucrReceiverElement As ucrReceiverSingle
    Friend WithEvents ucrReceiverDOY As ucrReceiverSingle
    Friend WithEvents ucrReceiverYear As ucrReceiverSingle
    Friend WithEvents ucrReceiverDate As ucrReceiverSingle
    Friend WithEvents lblStation As Label
    Friend WithEvents lblElement As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents cmdSummary As Button
    Friend WithEvents lblWithinYear As Label
    Friend WithEvents ucrReceiverWithinYear As ucrReceiverSingle
    Friend WithEvents ucrSelectorVariable As ucrSelectorByDataFrameAddRemove
    Friend WithEvents grpOptions As GroupBox
    Friend WithEvents ucrChkStoreResults As ucrCheck
    Friend WithEvents ucrChkPrintOutput As ucrCheck
    Friend WithEvents ucrChkDropUnusedLevels As ucrCheck
    Friend WithEvents ucrChkOmitMissingValues As ucrCheck
    Friend WithEvents cmdDoyRange As Button
    Friend WithEvents ucrInputFilterPreview As ucrInputTextBox
End Class
