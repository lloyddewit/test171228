﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sdgPieChartOptions
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
        Me.UcrButtonsSubdialogue1 = New instat.ucrButtonsSubdialogue()
        Me.SuspendLayout()
        '
        'UcrButtonsSubdialogue1
        '
        Me.UcrButtonsSubdialogue1.Location = New System.Drawing.Point(49, 219)
        Me.UcrButtonsSubdialogue1.Name = "UcrButtonsSubdialogue1"
        Me.UcrButtonsSubdialogue1.Size = New System.Drawing.Size(142, 30)
        Me.UcrButtonsSubdialogue1.TabIndex = 0
        '
        'sdgPieChartOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.UcrButtonsSubdialogue1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "sdgPieChartOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Pie_Chart_Options"
        Me.Text = "Pie Chart Options"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcrButtonsSubdialogue1 As ucrButtonsSubdialogue
End Class
