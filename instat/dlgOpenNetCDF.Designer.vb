﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgOpenNetCDF
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
        Me.lblLocDataNamePrefix = New System.Windows.Forms.Label()
        Me.cmdOpenDataSet = New System.Windows.Forms.Button()
        Me.lblFileOpenPath = New System.Windows.Forms.Label()
        Me.lblMainDataName = New System.Windows.Forms.Label()
        Me.ucrInputLocDataName = New instat.ucrInputTextBox()
        Me.ucrInputFilePath = New instat.ucrInputTextBox()
        Me.ucrInputDataName = New instat.ucrInputTextBox()
        Me.ucrBase = New instat.ucrButtons()
        Me.SuspendLayout()
        '
        'lblLocDataNamePrefix
        '
        Me.lblLocDataNamePrefix.AutoSize = True
        Me.lblLocDataNamePrefix.Location = New System.Drawing.Point(10, 82)
        Me.lblLocDataNamePrefix.Name = "lblLocDataNamePrefix"
        Me.lblLocDataNamePrefix.Size = New System.Drawing.Size(134, 13)
        Me.lblLocDataNamePrefix.TabIndex = 5
        Me.lblLocDataNamePrefix.Tag = "Lat_Lon_Data_Name_Prefix:"
        Me.lblLocDataNamePrefix.Text = "Lat/Lon Data Name Prefix:"
        '
        'cmdOpenDataSet
        '
        Me.cmdOpenDataSet.Location = New System.Drawing.Point(226, 18)
        Me.cmdOpenDataSet.Name = "cmdOpenDataSet"
        Me.cmdOpenDataSet.Size = New System.Drawing.Size(66, 23)
        Me.cmdOpenDataSet.TabIndex = 2
        Me.cmdOpenDataSet.Tag = "select_file"
        Me.cmdOpenDataSet.Text = "Select File"
        Me.cmdOpenDataSet.UseVisualStyleBackColor = True
        '
        'lblFileOpenPath
        '
        Me.lblFileOpenPath.AutoSize = True
        Me.lblFileOpenPath.Location = New System.Drawing.Point(10, 18)
        Me.lblFileOpenPath.Name = "lblFileOpenPath"
        Me.lblFileOpenPath.Size = New System.Drawing.Size(26, 13)
        Me.lblFileOpenPath.TabIndex = 0
        Me.lblFileOpenPath.Text = "File:"
        '
        'lblMainDataName
        '
        Me.lblMainDataName.AutoSize = True
        Me.lblMainDataName.Location = New System.Drawing.Point(10, 49)
        Me.lblMainDataName.Name = "lblMainDataName"
        Me.lblMainDataName.Size = New System.Drawing.Size(122, 13)
        Me.lblMainDataName.TabIndex = 3
        Me.lblMainDataName.Tag = "Main_Data_Frame_Name:"
        Me.lblMainDataName.Text = "Main Data Frame Name:"
        '
        'ucrInputLocDataName
        '
        Me.ucrInputLocDataName.AddQuotesIfUnrecognised = True
        Me.ucrInputLocDataName.IsMultiline = False
        Me.ucrInputLocDataName.IsReadOnly = False
        Me.ucrInputLocDataName.Location = New System.Drawing.Point(150, 82)
        Me.ucrInputLocDataName.Name = "ucrInputLocDataName"
        Me.ucrInputLocDataName.Size = New System.Drawing.Size(142, 21)
        Me.ucrInputLocDataName.TabIndex = 6
        '
        'ucrInputFilePath
        '
        Me.ucrInputFilePath.AddQuotesIfUnrecognised = True
        Me.ucrInputFilePath.IsMultiline = False
        Me.ucrInputFilePath.IsReadOnly = False
        Me.ucrInputFilePath.Location = New System.Drawing.Point(52, 18)
        Me.ucrInputFilePath.Name = "ucrInputFilePath"
        Me.ucrInputFilePath.Size = New System.Drawing.Size(161, 21)
        Me.ucrInputFilePath.TabIndex = 1
        '
        'ucrInputDataName
        '
        Me.ucrInputDataName.AddQuotesIfUnrecognised = True
        Me.ucrInputDataName.IsMultiline = False
        Me.ucrInputDataName.IsReadOnly = False
        Me.ucrInputDataName.Location = New System.Drawing.Point(150, 49)
        Me.ucrInputDataName.Name = "ucrInputDataName"
        Me.ucrInputDataName.Size = New System.Drawing.Size(142, 21)
        Me.ucrInputDataName.TabIndex = 4
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(10, 116)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 53)
        Me.ucrBase.TabIndex = 7
        '
        'dlgOpenNetCDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 181)
        Me.Controls.Add(Me.ucrInputLocDataName)
        Me.Controls.Add(Me.lblLocDataNamePrefix)
        Me.Controls.Add(Me.ucrInputFilePath)
        Me.Controls.Add(Me.ucrInputDataName)
        Me.Controls.Add(Me.cmdOpenDataSet)
        Me.Controls.Add(Me.lblFileOpenPath)
        Me.Controls.Add(Me.lblMainDataName)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgOpenNetCDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open NetCDF"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrInputLocDataName As ucrInputTextBox
    Friend WithEvents lblLocDataNamePrefix As Label
    Friend WithEvents ucrInputFilePath As ucrInputTextBox
    Friend WithEvents ucrInputDataName As ucrInputTextBox
    Friend WithEvents cmdOpenDataSet As Button
    Friend WithEvents lblFileOpenPath As Label
    Friend WithEvents lblMainDataName As Label
End Class
