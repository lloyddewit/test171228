﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRemoveUnusedLabels
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrDataFrame = New instat.ucrDataFrame()
        Me.ucrAddRemove = New instat.ucrSelectorAddRemove()
        Me.ucrSelectedVariable = New instat.ucrReceiverSingle()
        Me.lblSelectedVariable = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(2, 266)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 53)
        Me.ucrBase.TabIndex = 0
        '
        'ucrDataFrame
        '
        Me.ucrDataFrame.Location = New System.Drawing.Point(2, 2)
        Me.ucrDataFrame.Name = "ucrDataFrame"
        Me.ucrDataFrame.Size = New System.Drawing.Size(127, 41)
        Me.ucrDataFrame.TabIndex = 1
        '
        'ucrAddRemove
        '
        Me.ucrAddRemove.Location = New System.Drawing.Point(2, 59)
        Me.ucrAddRemove.Name = "ucrAddRemove"
        Me.ucrAddRemove.Size = New System.Drawing.Size(203, 127)
        Me.ucrAddRemove.TabIndex = 2
        '
        'ucrSelectedVariable
        '
        Me.ucrSelectedVariable.Location = New System.Drawing.Point(234, 103)
        Me.ucrSelectedVariable.Name = "ucrSelectedVariable"
        Me.ucrSelectedVariable.Size = New System.Drawing.Size(106, 26)
        Me.ucrSelectedVariable.TabIndex = 3
        '
        'lblSelectedVariable
        '
        Me.lblSelectedVariable.AutoSize = True
        Me.lblSelectedVariable.Location = New System.Drawing.Point(241, 85)
        Me.lblSelectedVariable.Name = "lblSelectedVariable"
        Me.lblSelectedVariable.Size = New System.Drawing.Size(87, 13)
        Me.lblSelectedVariable.TabIndex = 4
        Me.lblSelectedVariable.Tag = "selected_variable"
        Me.lblSelectedVariable.Text = "selected variable"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(13, 205)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(220, 13)
        Me.lblInfo.TabIndex = 5
        Me.lblInfo.Text = "An order,level,count control to be added later"
        '
        'dlgRemoveUnusedLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 319)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.lblSelectedVariable)
        Me.Controls.Add(Me.ucrSelectedVariable)
        Me.Controls.Add(Me.ucrAddRemove)
        Me.Controls.Add(Me.ucrDataFrame)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgRemoveUnusedLabels"
        Me.Tag = "Remove_unused_labels"
        Me.Text = "Remove Unused Labels"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrDataFrame As ucrDataFrame
    Friend WithEvents ucrAddRemove As ucrSelectorAddRemove
    Friend WithEvents ucrSelectedVariable As ucrReceiverSingle
    Friend WithEvents lblSelectedVariable As Label
    Friend WithEvents lblInfo As Label
End Class
