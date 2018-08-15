﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgCompare))
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblSateliteElement = New System.Windows.Forms.Label()
        Me.lblStationElement = New System.Windows.Forms.Label()
        Me.lblWithinYear = New System.Windows.Forms.Label()
        Me.rdoAnomalies = New System.Windows.Forms.RadioButton()
        Me.rdoDifferences = New System.Windows.Forms.RadioButton()
        Me.ucrChkAbsDev = New instat.ucrCheck()
        Me.ucrChkBias = New instat.ucrCheck()
        Me.ucrInputAbsDev = New instat.ucrInputTextBox()
        Me.ucrInputBias = New instat.ucrInputTextBox()
        Me.ucrNudMovingAverage = New instat.ucrNud()
        Me.ucrPnlCompare = New instat.UcrPanel()
        Me.ucrChkMovingAverage = New instat.ucrCheck()
        Me.ucrReceiverWithinYear = New instat.ucrReceiverSingle()
        Me.ucrReceiverStation = New instat.ucrReceiverSingle()
        Me.ucrReceiverStationElement = New instat.ucrReceiverSingle()
        Me.ucrReceiverSateliteElement = New instat.ucrReceiverSingle()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelectorCompare = New instat.ucrSelectorByDataFrameAddRemove()
        Me.SuspendLayout()
        '
        'lblStation
        '
        resources.ApplyResources(Me.lblStation, "lblStation")
        Me.lblStation.Name = "lblStation"
        '
        'lblSateliteElement
        '
        resources.ApplyResources(Me.lblSateliteElement, "lblSateliteElement")
        Me.lblSateliteElement.Name = "lblSateliteElement"
        '
        'lblStationElement
        '
        resources.ApplyResources(Me.lblStationElement, "lblStationElement")
        Me.lblStationElement.Name = "lblStationElement"
        '
        'lblWithinYear
        '
        resources.ApplyResources(Me.lblWithinYear, "lblWithinYear")
        Me.lblWithinYear.Name = "lblWithinYear"
        '
        'rdoAnomalies
        '
        resources.ApplyResources(Me.rdoAnomalies, "rdoAnomalies")
        Me.rdoAnomalies.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoAnomalies.FlatAppearance.BorderSize = 2
        Me.rdoAnomalies.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoAnomalies.Name = "rdoAnomalies"
        Me.rdoAnomalies.TabStop = True
        Me.rdoAnomalies.UseVisualStyleBackColor = True
        '
        'rdoDifferences
        '
        resources.ApplyResources(Me.rdoDifferences, "rdoDifferences")
        Me.rdoDifferences.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoDifferences.FlatAppearance.BorderSize = 2
        Me.rdoDifferences.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoDifferences.Name = "rdoDifferences"
        Me.rdoDifferences.TabStop = True
        Me.rdoDifferences.UseVisualStyleBackColor = True
        '
        'ucrChkAbsDev
        '
        Me.ucrChkAbsDev.Checked = False
        resources.ApplyResources(Me.ucrChkAbsDev, "ucrChkAbsDev")
        Me.ucrChkAbsDev.Name = "ucrChkAbsDev"
        '
        'ucrChkBias
        '
        Me.ucrChkBias.Checked = False
        resources.ApplyResources(Me.ucrChkBias, "ucrChkBias")
        Me.ucrChkBias.Name = "ucrChkBias"
        '
        'ucrInputAbsDev
        '
        Me.ucrInputAbsDev.AddQuotesIfUnrecognised = True
        Me.ucrInputAbsDev.IsMultiline = False
        Me.ucrInputAbsDev.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputAbsDev, "ucrInputAbsDev")
        Me.ucrInputAbsDev.Name = "ucrInputAbsDev"
        '
        'ucrInputBias
        '
        Me.ucrInputBias.AddQuotesIfUnrecognised = True
        Me.ucrInputBias.IsMultiline = False
        Me.ucrInputBias.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputBias, "ucrInputBias")
        Me.ucrInputBias.Name = "ucrInputBias"
        '
        'ucrNudMovingAverage
        '
        Me.ucrNudMovingAverage.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMovingAverage.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudMovingAverage, "ucrNudMovingAverage")
        Me.ucrNudMovingAverage.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudMovingAverage.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMovingAverage.Name = "ucrNudMovingAverage"
        Me.ucrNudMovingAverage.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrPnlCompare
        '
        resources.ApplyResources(Me.ucrPnlCompare, "ucrPnlCompare")
        Me.ucrPnlCompare.Name = "ucrPnlCompare"
        '
        'ucrChkMovingAverage
        '
        Me.ucrChkMovingAverage.Checked = False
        resources.ApplyResources(Me.ucrChkMovingAverage, "ucrChkMovingAverage")
        Me.ucrChkMovingAverage.Name = "ucrChkMovingAverage"
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
        'ucrReceiverStation
        '
        Me.ucrReceiverStation.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverStation, "ucrReceiverStation")
        Me.ucrReceiverStation.Name = "ucrReceiverStation"
        Me.ucrReceiverStation.Selector = Nothing
        Me.ucrReceiverStation.strNcFilePath = ""
        Me.ucrReceiverStation.ucrSelector = Nothing
        '
        'ucrReceiverStationElement
        '
        Me.ucrReceiverStationElement.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverStationElement, "ucrReceiverStationElement")
        Me.ucrReceiverStationElement.Name = "ucrReceiverStationElement"
        Me.ucrReceiverStationElement.Selector = Nothing
        Me.ucrReceiverStationElement.strNcFilePath = ""
        Me.ucrReceiverStationElement.ucrSelector = Nothing
        '
        'ucrReceiverSateliteElement
        '
        Me.ucrReceiverSateliteElement.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverSateliteElement, "ucrReceiverSateliteElement")
        Me.ucrReceiverSateliteElement.Name = "ucrReceiverSateliteElement"
        Me.ucrReceiverSateliteElement.Selector = Nothing
        Me.ucrReceiverSateliteElement.strNcFilePath = ""
        Me.ucrReceiverSateliteElement.ucrSelector = Nothing
        '
        'ucrBase
        '
        resources.ApplyResources(Me.ucrBase, "ucrBase")
        Me.ucrBase.Name = "ucrBase"
        '
        'ucrSelectorCompare
        '
        Me.ucrSelectorCompare.bDropUnusedFilterLevels = False
        Me.ucrSelectorCompare.bShowHiddenColumns = False
        Me.ucrSelectorCompare.bUseCurrentFilter = True
        resources.ApplyResources(Me.ucrSelectorCompare, "ucrSelectorCompare")
        Me.ucrSelectorCompare.Name = "ucrSelectorCompare"
        '
        'dlgCompare
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrChkAbsDev)
        Me.Controls.Add(Me.ucrChkBias)
        Me.Controls.Add(Me.ucrInputAbsDev)
        Me.Controls.Add(Me.ucrInputBias)
        Me.Controls.Add(Me.ucrNudMovingAverage)
        Me.Controls.Add(Me.rdoAnomalies)
        Me.Controls.Add(Me.rdoDifferences)
        Me.Controls.Add(Me.ucrPnlCompare)
        Me.Controls.Add(Me.ucrChkMovingAverage)
        Me.Controls.Add(Me.lblWithinYear)
        Me.Controls.Add(Me.ucrReceiverWithinYear)
        Me.Controls.Add(Me.lblStationElement)
        Me.Controls.Add(Me.lblSateliteElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrReceiverStation)
        Me.Controls.Add(Me.ucrReceiverStationElement)
        Me.Controls.Add(Me.ucrReceiverSateliteElement)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrSelectorCompare)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCompare"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrSelectorCompare As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrReceiverSateliteElement As ucrReceiverSingle
    Friend WithEvents ucrReceiverStation As ucrReceiverSingle
    Friend WithEvents ucrReceiverStationElement As ucrReceiverSingle
    Friend WithEvents lblStationElement As Label
    Friend WithEvents lblSateliteElement As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents lblWithinYear As Label
    Friend WithEvents ucrReceiverWithinYear As ucrReceiverSingle
    Friend WithEvents ucrChkMovingAverage As ucrCheck
    Friend WithEvents rdoAnomalies As RadioButton
    Friend WithEvents rdoDifferences As RadioButton
    Friend WithEvents ucrPnlCompare As UcrPanel
    Friend WithEvents ucrNudMovingAverage As ucrNud
    Friend WithEvents ucrChkAbsDev As ucrCheck
    Friend WithEvents ucrChkBias As ucrCheck
    Friend WithEvents ucrInputAbsDev As ucrInputTextBox
    Friend WithEvents ucrInputBias As ucrInputTextBox
End Class
