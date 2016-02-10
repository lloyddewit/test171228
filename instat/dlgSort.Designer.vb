﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgSort
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
        Me.grpOrder = New System.Windows.Forms.GroupBox()
        Me.rdoDescending = New System.Windows.Forms.RadioButton()
        Me.rdoAscending = New System.Windows.Forms.RadioButton()
        Me.lblColumnsToSort = New System.Windows.Forms.Label()
        Me.ucrReceiverSort = New instat.ucrReceiverMultiple()
        Me.ucrAddRemove = New instat.ucrSelectorAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelectorDataFrame = New instat.ucrSelectorByDataFrame()
        Me.ucrNewColumnNameSelector = New instat.ucrNewColumnName()
        Me.grpMissingValues = New System.Windows.Forms.GroupBox()
        Me.rdoFirst = New System.Windows.Forms.RadioButton()
        Me.rdoLast = New System.Windows.Forms.RadioButton()
        Me.grpOrder.SuspendLayout()
        Me.grpMissingValues.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpOrder
        '
        Me.grpOrder.Controls.Add(Me.rdoDescending)
        Me.grpOrder.Controls.Add(Me.rdoAscending)
        Me.grpOrder.Location = New System.Drawing.Point(13, 197)
        Me.grpOrder.Name = "grpOrder"
        Me.grpOrder.Size = New System.Drawing.Size(181, 47)
        Me.grpOrder.TabIndex = 2
        Me.grpOrder.TabStop = False
        Me.grpOrder.Tag = "Order"
        Me.grpOrder.Text = "Order"
        '
        'rdoDescending
        '
        Me.rdoDescending.AutoSize = True
        Me.rdoDescending.Location = New System.Drawing.Point(88, 20)
        Me.rdoDescending.Name = "rdoDescending"
        Me.rdoDescending.Size = New System.Drawing.Size(82, 17)
        Me.rdoDescending.TabIndex = 0
        Me.rdoDescending.TabStop = True
        Me.rdoDescending.Tag = "Descending"
        Me.rdoDescending.Text = "Descending"
        Me.rdoDescending.UseVisualStyleBackColor = True
        '
        'rdoAscending
        '
        Me.rdoAscending.AutoSize = True
        Me.rdoAscending.Location = New System.Drawing.Point(7, 20)
        Me.rdoAscending.Name = "rdoAscending"
        Me.rdoAscending.Size = New System.Drawing.Size(75, 17)
        Me.rdoAscending.TabIndex = 0
        Me.rdoAscending.TabStop = True
        Me.rdoAscending.Tag = "Ascending"
        Me.rdoAscending.Text = "Ascending"
        Me.rdoAscending.UseVisualStyleBackColor = True
        '
        'lblColumnsToSort
        '
        Me.lblColumnsToSort.AutoSize = True
        Me.lblColumnsToSort.Location = New System.Drawing.Point(287, 72)
        Me.lblColumnsToSort.Name = "lblColumnsToSort"
        Me.lblColumnsToSort.Size = New System.Drawing.Size(85, 13)
        Me.lblColumnsToSort.TabIndex = 5
        Me.lblColumnsToSort.Tag = "Columns_To_Sort"
        Me.lblColumnsToSort.Text = "Columns To Sort"
        '
        'ucrReceiverSort
        '
        Me.ucrReceiverSort.Location = New System.Drawing.Point(290, 88)
        Me.ucrReceiverSort.Name = "ucrReceiverSort"
        Me.ucrReceiverSort.Size = New System.Drawing.Size(125, 103)
        Me.ucrReceiverSort.TabIndex = 4
        '
        'ucrAddRemove
        '
        Me.ucrAddRemove.Location = New System.Drawing.Point(12, 59)
        Me.ucrAddRemove.Name = "ucrAddRemove"
        Me.ucrAddRemove.Size = New System.Drawing.Size(204, 132)
        Me.ucrAddRemove.TabIndex = 3
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(13, 291)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(402, 56)
        Me.ucrBase.TabIndex = 0
        '
        'ucrSelectorDataFrame
        '
        Me.ucrSelectorDataFrame.Location = New System.Drawing.Point(13, 7)
        Me.ucrSelectorDataFrame.Name = "ucrSelectorDataFrame"
        Me.ucrSelectorDataFrame.Size = New System.Drawing.Size(133, 46)
        Me.ucrSelectorDataFrame.TabIndex = 6
        '
        'ucrNewColumnNameSelector
        '
        Me.ucrNewColumnNameSelector.Location = New System.Drawing.Point(13, 250)
        Me.ucrNewColumnNameSelector.Name = "ucrNewColumnNameSelector"
        Me.ucrNewColumnNameSelector.Size = New System.Drawing.Size(367, 35)
        Me.ucrNewColumnNameSelector.TabIndex = 7
        Me.ucrNewColumnNameSelector.ucrDataFrameSelector = Nothing
        '
        'grpMissingValues
        '
        Me.grpMissingValues.Controls.Add(Me.rdoLast)
        Me.grpMissingValues.Controls.Add(Me.rdoFirst)
        Me.grpMissingValues.Location = New System.Drawing.Point(200, 197)
        Me.grpMissingValues.Name = "grpMissingValues"
        Me.grpMissingValues.Size = New System.Drawing.Size(215, 47)
        Me.grpMissingValues.TabIndex = 8
        Me.grpMissingValues.TabStop = False
        Me.grpMissingValues.Tag = "Missing_values"
        Me.grpMissingValues.Text = "Missing values"
        '
        'rdoFirst
        '
        Me.rdoFirst.AutoSize = True
        Me.rdoFirst.Location = New System.Drawing.Point(17, 20)
        Me.rdoFirst.Name = "rdoFirst"
        Me.rdoFirst.Size = New System.Drawing.Size(44, 17)
        Me.rdoFirst.TabIndex = 0
        Me.rdoFirst.TabStop = True
        Me.rdoFirst.Tag = "First"
        Me.rdoFirst.Text = "First"
        Me.rdoFirst.UseVisualStyleBackColor = True
        '
        'rdoLast
        '
        Me.rdoLast.AutoSize = True
        Me.rdoLast.Location = New System.Drawing.Point(114, 20)
        Me.rdoLast.Name = "rdoLast"
        Me.rdoLast.Size = New System.Drawing.Size(45, 17)
        Me.rdoLast.TabIndex = 1
        Me.rdoLast.TabStop = True
        Me.rdoLast.Tag = "Last"
        Me.rdoLast.Text = "Last"
        Me.rdoLast.UseVisualStyleBackColor = True
        '
        'dlgSort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 356)
        Me.Controls.Add(Me.grpMissingValues)
        Me.Controls.Add(Me.ucrNewColumnNameSelector)
        Me.Controls.Add(Me.ucrSelectorDataFrame)
        Me.Controls.Add(Me.lblColumnsToSort)
        Me.Controls.Add(Me.ucrReceiverSort)
        Me.Controls.Add(Me.ucrAddRemove)
        Me.Controls.Add(Me.grpOrder)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSort"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sort"
        Me.grpOrder.ResumeLayout(False)
        Me.grpOrder.PerformLayout()
        Me.grpMissingValues.ResumeLayout(False)
        Me.grpMissingValues.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents grpOrder As GroupBox
    Friend WithEvents rdoDescending As RadioButton
    Friend WithEvents rdoAscending As RadioButton
    Friend WithEvents ucrAddRemove As ucrSelectorAddRemove
    Friend WithEvents ucrReceiverSort As ucrReceiverMultiple
    Friend WithEvents lblColumnsToSort As Label
    Friend WithEvents ucrSelectorDataFrame As ucrSelectorByDataFrame
    Friend WithEvents ucrNewColumnNameSelector As ucrNewColumnName
    Friend WithEvents grpMissingValues As GroupBox
    Friend WithEvents rdoLast As RadioButton
    Friend WithEvents rdoFirst As RadioButton
End Class
