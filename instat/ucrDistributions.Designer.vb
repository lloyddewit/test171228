﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrDistributions
    Inherits instat.ucrCore

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
        Me.lblDistributionType = New System.Windows.Forms.Label()
        Me.ucrInputDistributions = New instat.ucrInputComboBox()
        Me.SuspendLayout()
        '
        'lblDistributionType
        '
        Me.lblDistributionType.AutoSize = True
        Me.lblDistributionType.Location = New System.Drawing.Point(-1, 5)
        Me.lblDistributionType.Name = "lblDistributionType"
        Me.lblDistributionType.Size = New System.Drawing.Size(62, 13)
        Me.lblDistributionType.TabIndex = 0
        Me.lblDistributionType.Tag = "distribution:"
        Me.lblDistributionType.Text = "Distribution:"
        '
        'ucrInputDistributions
        '
        Me.ucrInputDistributions.AddQuotesIfUnrecognised = True
        Me.ucrInputDistributions.IsReadOnly = False
        Me.ucrInputDistributions.Location = New System.Drawing.Point(67, 3)
        Me.ucrInputDistributions.Name = "ucrInputDistributions"
        Me.ucrInputDistributions.Size = New System.Drawing.Size(137, 21)
        Me.ucrInputDistributions.TabIndex = 1
        '
        'ucrDistributions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrInputDistributions)
        Me.Controls.Add(Me.lblDistributionType)
        Me.Name = "ucrDistributions"
        Me.Size = New System.Drawing.Size(208, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDistributionType As Label
    Friend WithEvents ucrInputDistributions As ucrInputComboBox
End Class
