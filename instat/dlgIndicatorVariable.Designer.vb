﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgIndicatorVariable
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
        Me.grpLevelToBeOmitted = New System.Windows.Forms.GroupBox()
        Me.rdoLevelNumber = New System.Windows.Forms.RadioButton()
        Me.rdoLast = New System.Windows.Forms.RadioButton()
        Me.rdoFirst = New System.Windows.Forms.RadioButton()
        Me.rdoNone = New System.Windows.Forms.RadioButton()
        Me.chkXvariable = New System.Windows.Forms.CheckBox()
        Me.ucrAddRemove = New instat.ucrSelectorAddRemove()
        Me.ucrDataFrameSelector = New instat.ucrDataFrame()
        Me.lblSelectedFactors = New System.Windows.Forms.Label()
        Me.ucrReceiverFactor = New instat.ucrReceiverSingle()
        Me.grpLevelToBeOmitted.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(7, 369)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 56)
        Me.ucrBase.TabIndex = 0
        '
        'grpLevelToBeOmitted
        '
        Me.grpLevelToBeOmitted.Controls.Add(Me.rdoLevelNumber)
        Me.grpLevelToBeOmitted.Controls.Add(Me.rdoLast)
        Me.grpLevelToBeOmitted.Controls.Add(Me.rdoFirst)
        Me.grpLevelToBeOmitted.Controls.Add(Me.rdoNone)
        Me.grpLevelToBeOmitted.Location = New System.Drawing.Point(5, 234)
        Me.grpLevelToBeOmitted.Name = "grpLevelToBeOmitted"
        Me.grpLevelToBeOmitted.Size = New System.Drawing.Size(123, 112)
        Me.grpLevelToBeOmitted.TabIndex = 1
        Me.grpLevelToBeOmitted.TabStop = False
        Me.grpLevelToBeOmitted.Tag = "Level_to_be_omitted"
        Me.grpLevelToBeOmitted.Text = "Level to be omitted"
        '
        'rdoLevelNumber
        '
        Me.rdoLevelNumber.AutoSize = True
        Me.rdoLevelNumber.Location = New System.Drawing.Point(6, 88)
        Me.rdoLevelNumber.Name = "rdoLevelNumber"
        Me.rdoLevelNumber.Size = New System.Drawing.Size(89, 17)
        Me.rdoLevelNumber.TabIndex = 0
        Me.rdoLevelNumber.TabStop = True
        Me.rdoLevelNumber.Tag = "Level_number"
        Me.rdoLevelNumber.Text = "Level number"
        Me.rdoLevelNumber.UseVisualStyleBackColor = True
        '
        'rdoLast
        '
        Me.rdoLast.AutoSize = True
        Me.rdoLast.Location = New System.Drawing.Point(6, 65)
        Me.rdoLast.Name = "rdoLast"
        Me.rdoLast.Size = New System.Drawing.Size(45, 17)
        Me.rdoLast.TabIndex = 0
        Me.rdoLast.TabStop = True
        Me.rdoLast.Tag = "Last"
        Me.rdoLast.Text = "Last"
        Me.rdoLast.UseVisualStyleBackColor = True
        '
        'rdoFirst
        '
        Me.rdoFirst.AutoSize = True
        Me.rdoFirst.Location = New System.Drawing.Point(6, 42)
        Me.rdoFirst.Name = "rdoFirst"
        Me.rdoFirst.Size = New System.Drawing.Size(44, 17)
        Me.rdoFirst.TabIndex = 0
        Me.rdoFirst.TabStop = True
        Me.rdoFirst.Tag = "First"
        Me.rdoFirst.Text = "First"
        Me.rdoFirst.UseVisualStyleBackColor = True
        '
        'rdoNone
        '
        Me.rdoNone.AutoSize = True
        Me.rdoNone.Location = New System.Drawing.Point(6, 19)
        Me.rdoNone.Name = "rdoNone"
        Me.rdoNone.Size = New System.Drawing.Size(51, 17)
        Me.rdoNone.TabIndex = 0
        Me.rdoNone.TabStop = True
        Me.rdoNone.Tag = "None"
        Me.rdoNone.Text = "None"
        Me.rdoNone.UseVisualStyleBackColor = True
        '
        'chkXvariable
        '
        Me.chkXvariable.AutoSize = True
        Me.chkXvariable.Location = New System.Drawing.Point(5, 196)
        Me.chkXvariable.Name = "chkXvariable"
        Me.chkXvariable.Size = New System.Drawing.Size(114, 17)
        Me.chkXvariable.TabIndex = 4
        Me.chkXvariable.Tag = "Withan_X_Variable"
        Me.chkXvariable.Text = "With an X Variable"
        Me.chkXvariable.UseVisualStyleBackColor = True
        '
        'ucrAddRemove
        '
        Me.ucrAddRemove.Location = New System.Drawing.Point(1, 49)
        Me.ucrAddRemove.Name = "ucrAddRemove"
        Me.ucrAddRemove.Size = New System.Drawing.Size(212, 127)
        Me.ucrAddRemove.TabIndex = 5
        '
        'ucrDataFrameSelector
        '
        Me.ucrDataFrameSelector.Location = New System.Drawing.Point(1, 2)
        Me.ucrDataFrameSelector.Name = "ucrDataFrameSelector"
        Me.ucrDataFrameSelector.Size = New System.Drawing.Size(127, 41)
        Me.ucrDataFrameSelector.TabIndex = 6
        '
        'lblSelectedFactors
        '
        Me.lblSelectedFactors.AutoSize = True
        Me.lblSelectedFactors.Location = New System.Drawing.Point(240, 60)
        Me.lblSelectedFactors.Name = "lblSelectedFactors"
        Me.lblSelectedFactors.Size = New System.Drawing.Size(88, 13)
        Me.lblSelectedFactors.TabIndex = 7
        Me.lblSelectedFactors.Tag = "Selected_factor"
        Me.lblSelectedFactors.Text = "selected factor(s)"
        '
        'ucrReceiverFactor
        '
        Me.ucrReceiverFactor.Location = New System.Drawing.Point(234, 78)
        Me.ucrReceiverFactor.Name = "ucrReceiverFactor"
        Me.ucrReceiverFactor.Size = New System.Drawing.Size(106, 26)
        Me.ucrReceiverFactor.TabIndex = 8
        '
        'dlgIndicatorVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 424)
        Me.Controls.Add(Me.ucrReceiverFactor)
        Me.Controls.Add(Me.lblSelectedFactors)
        Me.Controls.Add(Me.ucrDataFrameSelector)
        Me.Controls.Add(Me.ucrAddRemove)
        Me.Controls.Add(Me.chkXvariable)
        Me.Controls.Add(Me.grpLevelToBeOmitted)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgIndicatorVariable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Indicator_variable"
        Me.Text = "Indicator variable"
        Me.grpLevelToBeOmitted.ResumeLayout(False)
        Me.grpLevelToBeOmitted.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents grpLevelToBeOmitted As GroupBox
    Friend WithEvents rdoLevelNumber As RadioButton
    Friend WithEvents rdoLast As RadioButton
    Friend WithEvents rdoFirst As RadioButton
    Friend WithEvents rdoNone As RadioButton
    Friend WithEvents chkXvariable As CheckBox
    Friend WithEvents ucrAddRemove As ucrSelectorAddRemove
    Friend WithEvents ucrDataFrameSelector As ucrDataFrame
    Friend WithEvents lblSelectedFactors As Label
    Friend WithEvents ucrReceiverFactor As ucrReceiverSingle
End Class
