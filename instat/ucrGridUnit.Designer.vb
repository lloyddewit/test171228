﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrGridUnit
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.grpUnits = New System.Windows.Forms.GroupBox()
        Me.lblData = New System.Windows.Forms.Label()
        Me.ucrInputData = New instat.ucrInputTextBox()
        Me.ucrInputVector = New instat.ucrInputTextBox()
        Me.ucrInputUnits = New instat.ucrInputComboBox()
        Me.ucrChkUnits = New instat.ucrCheck()
        Me.grpUnits.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpUnits
        '
        Me.grpUnits.Controls.Add(Me.lblData)
        Me.grpUnits.Controls.Add(Me.ucrInputData)
        Me.grpUnits.Controls.Add(Me.ucrInputVector)
        Me.grpUnits.Controls.Add(Me.ucrInputUnits)
        Me.grpUnits.Controls.Add(Me.ucrChkUnits)
        Me.grpUnits.Location = New System.Drawing.Point(3, -3)
        Me.grpUnits.Name = "grpUnits"
        Me.grpUnits.Size = New System.Drawing.Size(249, 120)
        Me.grpUnits.TabIndex = 108
        Me.grpUnits.TabStop = False
        Me.grpUnits.Text = "Units"
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(108, 69)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(78, 13)
        Me.lblData.TabIndex = 112
        Me.lblData.Text = "Data (Optional)"
        '
        'ucrInputData
        '
        Me.ucrInputData.AddQuotesIfUnrecognised = True
        Me.ucrInputData.IsMultiline = False
        Me.ucrInputData.IsReadOnly = False
        Me.ucrInputData.Location = New System.Drawing.Point(108, 89)
        Me.ucrInputData.Name = "ucrInputData"
        Me.ucrInputData.Size = New System.Drawing.Size(106, 23)
        Me.ucrInputData.TabIndex = 111
        '
        'ucrInputVector
        '
        Me.ucrInputVector.AddQuotesIfUnrecognised = True
        Me.ucrInputVector.IsMultiline = False
        Me.ucrInputVector.IsReadOnly = False
        Me.ucrInputVector.Location = New System.Drawing.Point(108, 18)
        Me.ucrInputVector.Name = "ucrInputVector"
        Me.ucrInputVector.Size = New System.Drawing.Size(106, 23)
        Me.ucrInputVector.TabIndex = 110
        '
        'ucrInputUnits
        '
        Me.ucrInputUnits.AddQuotesIfUnrecognised = True
        Me.ucrInputUnits.IsReadOnly = False
        Me.ucrInputUnits.Location = New System.Drawing.Point(108, 42)
        Me.ucrInputUnits.Margin = New System.Windows.Forms.Padding(21, 17, 21, 17)
        Me.ucrInputUnits.Name = "ucrInputUnits"
        Me.ucrInputUnits.Size = New System.Drawing.Size(137, 21)
        Me.ucrInputUnits.TabIndex = 109
        '
        'ucrChkUnits
        '
        Me.ucrChkUnits.Checked = False
        Me.ucrChkUnits.Location = New System.Drawing.Point(10, 18)
        Me.ucrChkUnits.Name = "ucrChkUnits"
        Me.ucrChkUnits.Size = New System.Drawing.Size(100, 20)
        Me.ucrChkUnits.TabIndex = 108
        '
        'ucrGridUnit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpUnits)
        Me.Name = "ucrGridUnit"
        Me.Size = New System.Drawing.Size(280, 119)
        Me.grpUnits.ResumeLayout(False)
        Me.grpUnits.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpUnits As GroupBox
    Friend WithEvents ucrInputData As ucrInputTextBox
    Friend WithEvents ucrInputVector As ucrInputTextBox
    Friend WithEvents ucrInputUnits As ucrInputComboBox
    Friend WithEvents lblData As Label
    Friend WithEvents ucrChkUnits As ucrCheck
End Class
