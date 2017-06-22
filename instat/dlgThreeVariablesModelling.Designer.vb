﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgThreeVariableModelling
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
        Me.lblFirstExplanatoryVariable = New System.Windows.Forms.Label()
        Me.lblResponse = New System.Windows.Forms.Label()
        Me.lblSecondExplanatoryVariable = New System.Windows.Forms.Label()
        Me.cmdDisplayOptions = New System.Windows.Forms.Button()
        Me.lblModelPreview = New System.Windows.Forms.Label()
        Me.cmdModelOptions = New System.Windows.Forms.Button()
        Me.lblModelOperator = New System.Windows.Forms.Label()
        Me.ucrSaveModel = New instat.ucrSave()
        Me.ucrChkSecondFunction = New instat.ucrCheck()
        Me.ucrReceiverSecondExplanatory = New instat.ucrReceiverSingle()
        Me.ucrChkFirstFunction = New instat.ucrCheck()
        Me.ucrReceiverFirstExplanatory = New instat.ucrReceiverSingle()
        Me.ucrChkConvertToVariate = New instat.ucrCheck()
        Me.ucrChkResponseFunction = New instat.ucrCheck()
        Me.ucrReceiverResponse = New instat.ucrReceiverSingle()
        Me.ucrModelOperator = New instat.ucrInputComboBox()
        Me.ucrModelPreview = New instat.ucrInputTextBox()
        Me.ucrFamily = New instat.ucrDistributions()
        Me.ucrSelectorThreeVariableModelling = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBaseThreeVariableModelling = New instat.ucrButtons()
        Me.SuspendLayout()
        '
        'lblFirstExplanatoryVariable
        '
        Me.lblFirstExplanatoryVariable.AutoSize = True
        Me.lblFirstExplanatoryVariable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFirstExplanatoryVariable.Location = New System.Drawing.Point(229, 62)
        Me.lblFirstExplanatoryVariable.Name = "lblFirstExplanatoryVariable"
        Me.lblFirstExplanatoryVariable.Size = New System.Drawing.Size(125, 13)
        Me.lblFirstExplanatoryVariable.TabIndex = 4
        Me.lblFirstExplanatoryVariable.Tag = "First_Explanatory_Variable"
        Me.lblFirstExplanatoryVariable.Text = "First Explanatory Variable"
        '
        'lblResponse
        '
        Me.lblResponse.AutoSize = True
        Me.lblResponse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblResponse.Location = New System.Drawing.Point(229, 14)
        Me.lblResponse.Name = "lblResponse"
        Me.lblResponse.Size = New System.Drawing.Size(96, 13)
        Me.lblResponse.TabIndex = 1
        Me.lblResponse.Tag = "Response_Variable"
        Me.lblResponse.Text = "Response Variable"
        '
        'lblSecondExplanatoryVariable
        '
        Me.lblSecondExplanatoryVariable.AutoSize = True
        Me.lblSecondExplanatoryVariable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecondExplanatoryVariable.Location = New System.Drawing.Point(229, 150)
        Me.lblSecondExplanatoryVariable.Name = "lblSecondExplanatoryVariable"
        Me.lblSecondExplanatoryVariable.Size = New System.Drawing.Size(143, 13)
        Me.lblSecondExplanatoryVariable.TabIndex = 8
        Me.lblSecondExplanatoryVariable.Tag = "Second_Explanatory_Variable"
        Me.lblSecondExplanatoryVariable.Text = "Second Explanatory Variable"
        '
        'cmdDisplayOptions
        '
        Me.cmdDisplayOptions.Location = New System.Drawing.Point(286, 268)
        Me.cmdDisplayOptions.Name = "cmdDisplayOptions"
        Me.cmdDisplayOptions.Size = New System.Drawing.Size(122, 23)
        Me.cmdDisplayOptions.TabIndex = 16
        Me.cmdDisplayOptions.Tag = "Display_Options"
        Me.cmdDisplayOptions.Text = "Display Options..."
        Me.cmdDisplayOptions.UseVisualStyleBackColor = True
        '
        'lblModelPreview
        '
        Me.lblModelPreview.AutoSize = True
        Me.lblModelPreview.Location = New System.Drawing.Point(6, 249)
        Me.lblModelPreview.Name = "lblModelPreview"
        Me.lblModelPreview.Size = New System.Drawing.Size(80, 13)
        Me.lblModelPreview.TabIndex = 10
        Me.lblModelPreview.Tag = "Model_Preview"
        Me.lblModelPreview.Text = "Model Preview:"
        '
        'cmdModelOptions
        '
        Me.cmdModelOptions.Location = New System.Drawing.Point(286, 214)
        Me.cmdModelOptions.Name = "cmdModelOptions"
        Me.cmdModelOptions.Size = New System.Drawing.Size(122, 23)
        Me.cmdModelOptions.TabIndex = 13
        Me.cmdModelOptions.Tag = "Model_Options"
        Me.cmdModelOptions.Text = "Model Options..."
        Me.cmdModelOptions.UseVisualStyleBackColor = True
        '
        'lblModelOperator
        '
        Me.lblModelOperator.AutoSize = True
        Me.lblModelOperator.Location = New System.Drawing.Point(229, 125)
        Me.lblModelOperator.Name = "lblModelOperator"
        Me.lblModelOperator.Size = New System.Drawing.Size(83, 13)
        Me.lblModelOperator.TabIndex = 21
        Me.lblModelOperator.Text = "Model Operator:"
        '
        'ucrSaveModel
        '
        Me.ucrSaveModel.Location = New System.Drawing.Point(9, 270)
        Me.ucrSaveModel.Name = "ucrSaveModel"
        Me.ucrSaveModel.Size = New System.Drawing.Size(255, 24)
        Me.ucrSaveModel.TabIndex = 30
        '
        'ucrChkSecondFunction
        '
        Me.ucrChkSecondFunction.Checked = False
        Me.ucrChkSecondFunction.Location = New System.Drawing.Point(353, 166)
        Me.ucrChkSecondFunction.Name = "ucrChkSecondFunction"
        Me.ucrChkSecondFunction.Size = New System.Drawing.Size(169, 20)
        Me.ucrChkSecondFunction.TabIndex = 29
        '
        'ucrReceiverSecondExplanatory
        '
        Me.ucrReceiverSecondExplanatory.frmParent = Me
        Me.ucrReceiverSecondExplanatory.Location = New System.Drawing.Point(229, 166)
        Me.ucrReceiverSecondExplanatory.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSecondExplanatory.Name = "ucrReceiverSecondExplanatory"
        Me.ucrReceiverSecondExplanatory.Selector = Nothing
        Me.ucrReceiverSecondExplanatory.Size = New System.Drawing.Size(121, 20)
        Me.ucrReceiverSecondExplanatory.strNcFilePath = ""
        Me.ucrReceiverSecondExplanatory.TabIndex = 28
        Me.ucrReceiverSecondExplanatory.ucrSelector = Nothing
        '
        'ucrChkFirstFunction
        '
        Me.ucrChkFirstFunction.Checked = False
        Me.ucrChkFirstFunction.Location = New System.Drawing.Point(353, 80)
        Me.ucrChkFirstFunction.Name = "ucrChkFirstFunction"
        Me.ucrChkFirstFunction.Size = New System.Drawing.Size(169, 20)
        Me.ucrChkFirstFunction.TabIndex = 27
        '
        'ucrReceiverFirstExplanatory
        '
        Me.ucrReceiverFirstExplanatory.frmParent = Me
        Me.ucrReceiverFirstExplanatory.Location = New System.Drawing.Point(229, 80)
        Me.ucrReceiverFirstExplanatory.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverFirstExplanatory.Name = "ucrReceiverFirstExplanatory"
        Me.ucrReceiverFirstExplanatory.Selector = Nothing
        Me.ucrReceiverFirstExplanatory.Size = New System.Drawing.Size(121, 20)
        Me.ucrReceiverFirstExplanatory.strNcFilePath = ""
        Me.ucrReceiverFirstExplanatory.TabIndex = 26
        Me.ucrReceiverFirstExplanatory.ucrSelector = Nothing
        '
        'ucrChkConvertToVariate
        '
        Me.ucrChkConvertToVariate.Checked = False
        Me.ucrChkConvertToVariate.Location = New System.Drawing.Point(353, 32)
        Me.ucrChkConvertToVariate.Name = "ucrChkConvertToVariate"
        Me.ucrChkConvertToVariate.Size = New System.Drawing.Size(136, 20)
        Me.ucrChkConvertToVariate.TabIndex = 25
        '
        'ucrChkResponseFunction
        '
        Me.ucrChkResponseFunction.Checked = False
        Me.ucrChkResponseFunction.Location = New System.Drawing.Point(353, 32)
        Me.ucrChkResponseFunction.Name = "ucrChkResponseFunction"
        Me.ucrChkResponseFunction.Size = New System.Drawing.Size(118, 20)
        Me.ucrChkResponseFunction.TabIndex = 24
        '
        'ucrReceiverResponse
        '
        Me.ucrReceiverResponse.frmParent = Me
        Me.ucrReceiverResponse.Location = New System.Drawing.Point(229, 32)
        Me.ucrReceiverResponse.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverResponse.Name = "ucrReceiverResponse"
        Me.ucrReceiverResponse.Selector = Nothing
        Me.ucrReceiverResponse.Size = New System.Drawing.Size(121, 20)
        Me.ucrReceiverResponse.strNcFilePath = ""
        Me.ucrReceiverResponse.TabIndex = 23
        Me.ucrReceiverResponse.ucrSelector = Nothing
        '
        'ucrModelOperator
        '
        Me.ucrModelOperator.AddQuotesIfUnrecognised = True
        Me.ucrModelOperator.IsReadOnly = False
        Me.ucrModelOperator.Location = New System.Drawing.Point(315, 121)
        Me.ucrModelOperator.Name = "ucrModelOperator"
        Me.ucrModelOperator.Size = New System.Drawing.Size(39, 21)
        Me.ucrModelOperator.TabIndex = 20
        '
        'ucrModelPreview
        '
        Me.ucrModelPreview.AddQuotesIfUnrecognised = True
        Me.ucrModelPreview.IsMultiline = False
        Me.ucrModelPreview.IsReadOnly = False
        Me.ucrModelPreview.Location = New System.Drawing.Point(91, 243)
        Me.ucrModelPreview.Name = "ucrModelPreview"
        Me.ucrModelPreview.Size = New System.Drawing.Size(176, 21)
        Me.ucrModelPreview.TabIndex = 11
        '
        'ucrFamily
        '
        Me.ucrFamily.Location = New System.Drawing.Point(9, 203)
        Me.ucrFamily.Name = "ucrFamily"
        Me.ucrFamily.Size = New System.Drawing.Size(225, 43)
        Me.ucrFamily.TabIndex = 12
        '
        'ucrSelectorThreeVariableModelling
        '
        Me.ucrSelectorThreeVariableModelling.bShowHiddenColumns = False
        Me.ucrSelectorThreeVariableModelling.bUseCurrentFilter = True
        Me.ucrSelectorThreeVariableModelling.Location = New System.Drawing.Point(9, 9)
        Me.ucrSelectorThreeVariableModelling.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorThreeVariableModelling.Name = "ucrSelectorThreeVariableModelling"
        Me.ucrSelectorThreeVariableModelling.Size = New System.Drawing.Size(214, 185)
        Me.ucrSelectorThreeVariableModelling.TabIndex = 0
        '
        'ucrBaseThreeVariableModelling
        '
        Me.ucrBaseThreeVariableModelling.Location = New System.Drawing.Point(9, 297)
        Me.ucrBaseThreeVariableModelling.Name = "ucrBaseThreeVariableModelling"
        Me.ucrBaseThreeVariableModelling.Size = New System.Drawing.Size(404, 54)
        Me.ucrBaseThreeVariableModelling.TabIndex = 17
        '
        'dlgThreeVariableModelling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 353)
        Me.Controls.Add(Me.ucrSaveModel)
        Me.Controls.Add(Me.ucrChkSecondFunction)
        Me.Controls.Add(Me.ucrReceiverSecondExplanatory)
        Me.Controls.Add(Me.ucrChkFirstFunction)
        Me.Controls.Add(Me.ucrReceiverFirstExplanatory)
        Me.Controls.Add(Me.ucrChkConvertToVariate)
        Me.Controls.Add(Me.ucrChkResponseFunction)
        Me.Controls.Add(Me.ucrReceiverResponse)
        Me.Controls.Add(Me.lblModelOperator)
        Me.Controls.Add(Me.ucrModelOperator)
        Me.Controls.Add(Me.cmdModelOptions)
        Me.Controls.Add(Me.lblModelPreview)
        Me.Controls.Add(Me.ucrModelPreview)
        Me.Controls.Add(Me.cmdDisplayOptions)
        Me.Controls.Add(Me.ucrFamily)
        Me.Controls.Add(Me.lblSecondExplanatoryVariable)
        Me.Controls.Add(Me.lblFirstExplanatoryVariable)
        Me.Controls.Add(Me.lblResponse)
        Me.Controls.Add(Me.ucrSelectorThreeVariableModelling)
        Me.Controls.Add(Me.ucrBaseThreeVariableModelling)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgThreeVariableModelling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Three_Variable_Modelling"
        Me.Text = "Three Variable Modelling"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBaseThreeVariableModelling As ucrButtons
    Friend WithEvents lblFirstExplanatoryVariable As Label
    Friend WithEvents lblResponse As Label
    Friend WithEvents ucrSelectorThreeVariableModelling As ucrSelectorByDataFrameAddRemove
    Friend WithEvents lblSecondExplanatoryVariable As Label
    Friend WithEvents ucrFamily As ucrDistributions
    Friend WithEvents cmdDisplayOptions As Button
    Friend WithEvents ucrModelPreview As ucrInputTextBox
    Friend WithEvents lblModelPreview As Label
    Friend WithEvents cmdModelOptions As Button
    Friend WithEvents ucrModelOperator As ucrInputComboBox
    Friend WithEvents lblModelOperator As Label
    Friend WithEvents ucrReceiverResponse As ucrReceiverSingle
    Friend WithEvents ucrChkResponseFunction As ucrCheck
    Friend WithEvents ucrChkConvertToVariate As ucrCheck
    Friend WithEvents ucrReceiverFirstExplanatory As ucrReceiverSingle
    Friend WithEvents ucrChkFirstFunction As ucrCheck
    Friend WithEvents ucrReceiverSecondExplanatory As ucrReceiverSingle
    Friend WithEvents ucrChkSecondFunction As ucrCheck
    Friend WithEvents ucrSaveModel As ucrSave
End Class
