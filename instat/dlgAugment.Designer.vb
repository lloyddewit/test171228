﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgAugment
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
        Me.lblModels = New System.Windows.Forms.Label()
        Me.ucrSaveNewColumn = New instat.ucrSave()
        Me.ucrModelReceiver = New instat.ucrReceiverSingle()
        Me.ucrChkDisplayInOutput = New instat.ucrCheck()
        Me.ucrModelSelector = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.SuspendLayout()
        '
        'lblModels
        '
        Me.lblModels.AutoSize = True
        Me.lblModels.Location = New System.Drawing.Point(424, 16)
        Me.lblModels.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModels.Name = "lblModels"
        Me.lblModels.Size = New System.Drawing.Size(53, 17)
        Me.lblModels.TabIndex = 2
        Me.lblModels.Text = "Models"
        '
        'ucrSaveNewColumn
        '
        Me.ucrSaveNewColumn.Location = New System.Drawing.Point(17, 300)
        Me.ucrSaveNewColumn.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ucrSaveNewColumn.Name = "ucrSaveNewColumn"
        Me.ucrSaveNewColumn.Size = New System.Drawing.Size(317, 30)
        Me.ucrSaveNewColumn.TabIndex = 7
        '
        'ucrModelReceiver
        '
        Me.ucrModelReceiver.frmParent = Me
        Me.ucrModelReceiver.Location = New System.Drawing.Point(377, 43)
        Me.ucrModelReceiver.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrModelReceiver.Name = "ucrModelReceiver"
        Me.ucrModelReceiver.Selector = Nothing
        Me.ucrModelReceiver.Size = New System.Drawing.Size(160, 25)
        Me.ucrModelReceiver.strNcFilePath = ""
        Me.ucrModelReceiver.TabIndex = 6
        Me.ucrModelReceiver.ucrSelector = Nothing
        '
        'ucrChkDisplayInOutput
        '
        Me.ucrChkDisplayInOutput.Checked = False
        Me.ucrChkDisplayInOutput.Location = New System.Drawing.Point(17, 254)
        Me.ucrChkDisplayInOutput.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrChkDisplayInOutput.Name = "ucrChkDisplayInOutput"
        Me.ucrChkDisplayInOutput.Size = New System.Drawing.Size(275, 25)
        Me.ucrChkDisplayInOutput.TabIndex = 4
        '
        'ucrModelSelector
        '
        Me.ucrModelSelector.bDropUnusedFilterLevels = False
        Me.ucrModelSelector.bShowHiddenColumns = False
        Me.ucrModelSelector.bUseCurrentFilter = True
        Me.ucrModelSelector.Location = New System.Drawing.Point(12, 11)
        Me.ucrModelSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrModelSelector.Name = "ucrModelSelector"
        Me.ucrModelSelector.Size = New System.Drawing.Size(280, 222)
        Me.ucrModelSelector.TabIndex = 1
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(13, 354)
        Me.ucrBase.Margin = New System.Windows.Forms.Padding(5)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(547, 64)
        Me.ucrBase.TabIndex = 0
        '
        'dlgAugment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 427)
        Me.Controls.Add(Me.ucrSaveNewColumn)
        Me.Controls.Add(Me.ucrModelReceiver)
        Me.Controls.Add(Me.ucrChkDisplayInOutput)
        Me.Controls.Add(Me.lblModels)
        Me.Controls.Add(Me.ucrModelSelector)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAugment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Augment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrModelSelector As ucrSelectorByDataFrameAddRemove
    Friend WithEvents lblModels As Label
    Friend WithEvents ucrChkDisplayInOutput As ucrCheck
    Friend WithEvents ucrModelReceiver As ucrReceiverSingle
    Friend WithEvents ucrSaveNewColumn As ucrSave
End Class
