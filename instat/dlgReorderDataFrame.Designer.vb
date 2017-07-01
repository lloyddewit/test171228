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
Partial Class dlgReorderDataFrame
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblDataFrameToReorder = New System.Windows.Forms.Label()
        Me.ucrDataFrameToReorder = New instat.ucrReorder()
        Me.ucrBase = New instat.ucrButtons()
        Me.SuspendLayout()
        '
        'lblDataFrameToReorder
        '
        Me.lblDataFrameToReorder.Location = New System.Drawing.Point(10, 22)
        Me.lblDataFrameToReorder.Name = "lblDataFrameToReorder"
        Me.lblDataFrameToReorder.Size = New System.Drawing.Size(132, 12)
        Me.lblDataFrameToReorder.TabIndex = 0
        Me.lblDataFrameToReorder.Text = "Data Frames to Reorder:"
        '
        'ucrDataFrameToReorder
        '
        Me.ucrDataFrameToReorder.Location = New System.Drawing.Point(8, 35)
        Me.ucrDataFrameToReorder.Name = "ucrDataFrameToReorder"
        Me.ucrDataFrameToReorder.Size = New System.Drawing.Size(154, 139)
        Me.ucrDataFrameToReorder.TabIndex = 1
        Me.ucrDataFrameToReorder.ucrDataFrameList = Nothing
        Me.ucrDataFrameToReorder.ucrReceiver = Nothing
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(10, 180)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 52)
        Me.ucrBase.TabIndex = 2
        '
        'dlgReorderDataFrame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 238)
        Me.Controls.Add(Me.lblDataFrameToReorder)
        Me.Controls.Add(Me.ucrDataFrameToReorder)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgReorderDataFrame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reoder Data Frames"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrDataFrameToReorder As ucrReorder
    Friend WithEvents lblDataFrameToReorder As Label
End Class
