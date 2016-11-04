﻿' Instat-R
' Copyright (C) 2015
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
' You should have received a copy of the GNU General Public License k
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations
Public Class dlgRegressionSimple
    Public bFirstLoad As Boolean = True
    Public clsModel, clsFunctionOperation As New ROperator
    Public clsRConvert, clsRCIFunction, clsTwoVarModel, clsRPoisson, clsRTTest, clsRBinomial, clsRLength, clsRMean, clsRMean2, clsRLength2 As New RFunction
    Public clsRLmOrGLM As New RFunction
    Private Sub dlgRegressionSimple_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseDialog()
            SetDefaults()
            bFirstLoad = False
        Else
            ReopenDialog()
        End If
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.clsRsyntax.iCallType = 2
        clsModel.SetOperation("~")
        ucrResponse.Selector = ucrSelectorSimpleReg
        ucrExplanatory.Selector = ucrSelectorSimpleReg
        ucrBase.iHelpTopicID = 171
        ucrModelName.SetDataFrameSelector(ucrSelectorSimpleReg.ucrAvailableDataFrames)
        ucrModelName.SetPrefix("reg")
        ucrModelName.SetItemsTypeAsModels()
        ucrModelName.SetDefaultTypeAsModel()
        ucrModelName.SetValidationTypeAsRVariable()
        ucrModelPreview.IsReadOnly = True
        sdgSimpleRegOptions.SetRModelFunction(clsRLmOrGLM)
        sdgSimpleRegOptions.SetRDataFrame(ucrSelectorSimpleReg.ucrAvailableDataFrames)
        sdgSimpleRegOptions.SetRYVariable(ucrResponse)
        sdgSimpleRegOptions.SetRXVariable(ucrExplanatory)
        sdgVariableTransformations.SetRYVariable(ucrResponse)
        sdgVariableTransformations.SetRXVariable(ucrExplanatory)
        sdgVariableTransformations.SetRModelOperator(clsModel)
        sdgModelOptions.SetRCIFunction(clsRCIFunction)
        sdgVariableTransformations.SetRCIFunction(clsRCIFunction)
        AssignModelName()
        nudCI.Increment = 0.05
        nudCI.Minimum = 0
        nudCI.Maximum = 1
        nudCI.DecimalPlaces = 2
        nudHypothesis.DecimalPlaces = 2
        nudHyp2.DecimalPlaces = 2
        '        ucrFamily.SetGLMDistributions()
        DistributionsOffered()
    End Sub

    Private Sub ReopenDialog()

    End Sub

    Private Sub SetDefaults()
        ucrSelectorSimpleReg.Reset()
        ucrResponse.SetMeAsReceiver()
        ucrSelectorSimpleReg.Focus()
        chkSaveModel.Checked = True
        ucrModelName.Visible = True
        chkConvertToVariate.Checked = False
        chkConvertToVariate.Visible = False
        chkFunction.Checked = False
        chkFunction.Visible = False
        rdoGeneral.Checked = True
        nudCI.Value = 0.95
        sdgSimpleRegOptions.SetDefaults()
        sdgModelOptions.SetDefaults()
        ucrModelName.Reset()
        ucrModelPreview.SetName("")
        SetRCode()
        TestOKEnabled()
    End Sub

    Private Sub LM()
        clsRLmOrGLM.ClearParameters()
        clsRLmOrGLM.SetRCommand("lm")
        clsRLmOrGLM.AddParameter("formula", clsROperatorParameter:=clsModel)
        clsModel.SetOperation("~")
        clsRLmOrGLM.AddParameter("data", ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text)
        ucrBase.clsRsyntax.SetBaseRFunction(clsRLmOrGLM)
        ConvertToVariate()
    End Sub

    Private Sub GLM()
        clsRLmOrGLM.ClearParameters()
        ucrBase.clsRsyntax.SetBaseRFunction(clsRLmOrGLM)
        clsRLmOrGLM.SetRCommand("glm")
        clsRLmOrGLM.AddParameter("formula", clsROperatorParameter:=clsModel)
        clsModel.SetOperation("~")
        clsRCIFunction.SetRCommand(ucrFamily.clsCurrDistribution.strGLMFunctionName)
        clsRLmOrGLM.AddParameter("family", clsRFunctionParameter:=clsRCIFunction)
        ConvertToVariate()
    End Sub

    Private Sub SetTTest()
        ' only variables the response receiver can accept is 
        ' if the explanatory receiver accepts a factor it needs to only use two levels
        clsRTTest.SetRCommand("t.test")
        clsRTTest.AddParameter("conf.level", nudCI.Value.ToString())
        clsRTTest.AddParameter("mu", nudHypothesis.Value.ToString())
        If ucrExplanatory.strCurrDataType = "numeric" OrElse ucrExplanatory.strCurrDataType = "integer" Then
            clsRTTest.AddParameter("x", clsRFunctionParameter:=ucrResponse.GetVariables())
            clsRTTest.AddParameter("y", clsRFunctionParameter:=ucrExplanatory.GetVariables())
        Else
            clsModel.SetOperation("~")
            clsModel.SetParameter(True, clsRFunc:=ucrResponse.GetVariables())
            clsModel.SetParameter(False, clsRFunc:=ucrExplanatory.GetVariables())
            clsRTTest.AddParameter("x", clsROperatorParameter:=clsModel)
        End If
        If chkPaired.Checked Then
            clsRTTest.AddParameter("paired", "TRUE")
        Else
            clsRTTest.RemoveParameterByName("paired")
        End If

        If ucrFamily.clsCurrDistribution.strNameTag = "Normal" Then
            If ucrResponse.strCurrDataType = "character" Or ucrResponse.strCurrDataType = "factor" Then
                ucrResponse.Clear()
            End If
            '            ucrResponse.SetDataType("numeric")
            ' do i need to do ucrExplanatory.set all data types
            ' only accept numeric, integer or positive integer for response
        End If

    End Sub

    Private Sub SetBinomTest()
        ' only variables the response receiver can accept is a factor
        ' only variables the explanatory receiver can accept is factor
        clsRBinomial.SetRCommand("prop.test")
        clsRBinomial.AddParameter("conf.level", nudCI.Value.ToString())
        clsRBinomial.AddParameter("p", "c(" & nudHypothesis.Value.ToString() & "," & nudHyp2.Value.ToString() & ")")
        clsModel.SetParameter(True, clsRFunc:=ucrResponse.GetVariables())
        clsModel.SetParameter(False, clsRFunc:=ucrExplanatory.GetVariables())
        clsRBinomial.AddParameter("x", clsROperatorParameter:=clsModel)
        clsRBinomial.AddParameter("data", ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text)

        If ucrFamily.clsCurrDistribution.strNameTag = "Binomial" Then
            If ucrExplanatory.strCurrDataType = "numeric" Or ucrExplanatory.strCurrDataType = "integer" Or ucrExplanatory.strCurrDataType = "positive integer" Then
                ucrExplanatory.Clear()
            End If
            If ucrResponse.strCurrDataType = "numeric" Or ucrResponse.strCurrDataType = "integer" Or ucrResponse.strCurrDataType = "positive integer" Then
                ucrResponse.Clear()
            End If

            ' only accept character or factor for response or explanatory
        End If
    End Sub

    Private Sub SetPoissonTest()
        ' can accept only numerical in both receivers
        If ucrFamily.clsCurrDistribution.strNameTag = "Poisson" Then
            If ucrExplanatory.strCurrDataType = "factor" Or ucrExplanatory.strCurrDataType = "character" Then
                ucrExplanatory.Clear()
            End If
            If ucrResponse.strCurrDataType = "factor" Or ucrResponse.strCurrDataType = "character" Then
                ucrResponse.Clear()
            End If
            '           ucrExplanatory.SetDataType = {"numeric", "integer"}

            '            ucrExplanatory.strCurrDataType = "numeric" Or ucrExplanatory.strCurrDataType = "integer" Or ucrExplanatory.strCurrDataType = "positive integer"
            '            ucrResponse.strCurrDataType = "numeric" Or ucrResponse.strCurrDataType = "integer" Or ucrResponse.strCurrDataType = "positive integer"
        End If


        clsRPoisson.SetRCommand("poisson.test")
        clsRPoisson.AddParameter("conf.level", nudCI.Value.ToString())
        clsRPoisson.AddParameter("r", nudHypothesis.Value.ToString())

        clsRLength.SetRCommand("length")
        clsRLength.AddParameter("x", clsRFunctionParameter:=ucrResponse.GetVariables())
        clsRLength2.SetRCommand("length")
        clsRLength2.AddParameter("x", clsRFunctionParameter:=ucrExplanatory.GetVariables())

        clsRMean.SetRCommand("mean")
        clsRMean.AddParameter("x", clsRFunctionParameter:=ucrResponse.GetVariables())
        clsRMean2.SetRCommand("mean")
        clsRMean2.AddParameter("x", clsRFunctionParameter:=ucrExplanatory.GetVariables())

        clsRPoisson.AddParameter("x", "c(" & clsRLength.ToScript & "," & clsRLength2.ToScript & ")")
        clsRPoisson.AddParameter("T", "c(" & clsRMean.ToScript & "," & clsRMean2.ToScript & ")")
    End Sub

    Private Sub SetRCode()
        clsRPoisson.ClearParameters()
        clsRBinomial.ClearParameters()
        clsRTTest.ClearParameters()
        clsTwoVarModel.ClearParameters()
        clsRLength.ClearParameters()
        If rdoGeneral.Checked Then
            If (ucrFamily.clsCurrDistribution.strNameTag = "Normal") Then
                clsRLmOrGLM.ClearParameters()
                LM()
            Else
                clsRLmOrGLM.ClearParameters()
                GLM()
            End If
        ElseIf rdoSpecific.Checked Then
            If ucrFamily.clsCurrDistribution.strNameTag = "Normal" Then
                SetTTest()
                ucrBase.clsRsyntax.SetBaseRFunction(clsRTTest)
            ElseIf ucrFamily.clsCurrDistribution.strNameTag = "Poisson" Then
                SetPoissonTest()
                ucrBase.clsRsyntax.SetBaseRFunction(clsRPoisson)
            ElseIf ucrFamily.clsCurrDistribution.strNameTag = "Bernouli" Then
                SetBinomTest()
                ucrBase.clsRsyntax.SetBaseRFunction(clsRBinomial)
            End If
        End If
        TestOKEnabled()
    End Sub

    Private Sub TestOKEnabled()
        If Not ucrResponse.IsEmpty() AndAlso Not ucrExplanatory.IsEmpty() AndAlso ucrFamily.Enabled AndAlso (chkSaveModel.Checked AndAlso Not ucrModelName.IsEmpty() OrElse Not chkSaveModel.Checked) Then
            ucrBase.OKEnabled(True)
            ucrModelPreview.SetName(clsModel.ToScript)
            If rdoGeneral.Checked Then
                ucrBase.clsRsyntax.AddParameter("formula", clsROperatorParameter:=clsModel)
            End If
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrSelectorSimpleReg_DataFrameChanged() Handles ucrSelectorSimpleReg.DataFrameChanged
        AssignModelName()
        SetRCode()
    End Sub

    Private Sub cmdDisplayOptions_Click(sender As Object, e As EventArgs) Handles cmdDisplayOptions.Click
        sdgSimpleRegOptions.ShowDialog()
        Display()
    End Sub

    Public Sub ConvertToVariate()
        If rdoGeneral.Checked AndAlso Not ucrResponse.IsEmpty Then
            '           ucrFamily.RecieverDatatype(ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text, ucrResponse.GetVariableNames(bWithQuotes:=False))
            If ucrFamily.strDataType = "numeric" Then
                chkConvertToVariate.Checked = False
                chkConvertToVariate.Visible = False
            Else
                chkConvertToVariate.Visible = True
            End If
            sdgModelOptions.ucrFamily.RecieverDatatype(ucrFamily.strDataType)
        End If

        If chkConvertToVariate.Checked Then
            clsRConvert.SetRCommand("as.numeric")
            clsRConvert.AddParameter("x", ucrResponse.GetVariableNames(bWithQuotes:=False))
            clsModel.SetParameter(True, clsRFunc:=clsRConvert)
            clsModel.SetParameter(False, clsRFunc:=ucrExplanatory.GetVariables())
            '            ucrFamily.RecieverDatatype("numeric")
        Else
            clsModel.SetParameter(True, clsRFunc:=ucrResponse.GetVariables())
            clsModel.SetParameter(False, clsRFunc:=ucrExplanatory.GetVariables())
            '            clsModel.SetParameter(True, strValue:=ucrResponse.GetVariableNames(bWithQuotes:=False))
            '            ucrFamily.RecieverDatatype(ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text, ucrResponse.GetVariableNames(bWithQuotes:=False))
        End If


        If ucrFamily.lstCurrentDistributions.Count = 0 Or ucrResponse.IsEmpty() Then
            ucrFamily.cboDistributions.Text = ""
            cmdModelOptions.Enabled = False
        Else
            cmdModelOptions.Enabled = True
        End If
    End Sub

    Private Sub DistributionsOffered()
        '        If rdoGeneral.Checked Then
        '        ucrFamily.SetGLMDistributions()
        '        Else
        '        only normal, poisson and bernouli
        '       End If
    End Sub

    Private Sub ucrResponse_SelectionChanged() Handles ucrResponse.SelectionChanged
        SetRCode()
        TestOKEnabled()
    End Sub

    Private Sub chkConvertToVariate_CheckedChanged(sender As Object, e As EventArgs) Handles chkConvertToVariate.CheckedChanged, chkConvertToVariate.VisibleChanged
        SetRCode()
        ConvertToVariate()
        TestOKEnabled()
        Display()
    End Sub

    Private Sub ExplanatoryFunctionSelect()
        Dim strExplanatoryType As String
        If Not ucrExplanatory.IsEmpty AndAlso rdoGeneral.Checked Then
            strExplanatoryType = frmMain.clsRLink.GetDataType(ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text, ucrExplanatory.GetVariableNames(bWithQuotes:=False))
            If rdoGeneral.Checked AndAlso (strExplanatoryType = "numeric" Or strExplanatoryType = "positive integer" Or strExplanatoryType = "integer") Then
                chkFunction.Visible = True
            Else
                chkFunction.Checked = False
                chkFunction.Visible = False
            End If
            If chkFunction.Checked Then
                sdgVariableTransformations.ModelFunction(False)
            Else
                sdgVariableTransformations.rdoIdentity.Checked = True
                clsModel.SetParameter(False, strValue:=ucrExplanatory.GetVariableNames(bWithQuotes:=False))
            End If
        End If
    End Sub

    Private Sub ucrExplanatory_SelectionChanged() Handles ucrExplanatory.SelectionChanged
        ExplanatoryFunctionSelect()
        SetRCode()
        TestOKEnabled()
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
    End Sub

    Private Sub ucrModelName_NameChanged() Handles ucrModelName.NameChanged
        AssignModelName()
        TestOKEnabled()
    End Sub

    Private Sub ucrBase_ClickOk(sender As Object, e As EventArgs) Handles ucrBase.ClickOk
        If rdoGeneral.Checked Then
            sdgSimpleRegOptions.RegOptions()
        End If
    End Sub

    Private Sub chkModelName_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveModel.CheckedChanged
        If chkSaveModel.Checked Then
            ucrModelName.Enabled = True
        Else
            ucrModelName.Enabled = False
        End If
        AssignModelName()
        TestOKEnabled()
    End Sub

    Private Sub AssignModelName()
        If chkSaveModel.Checked AndAlso Not ucrModelName.IsEmpty Then
            ucrBase.clsRsyntax.SetAssignTo(ucrModelName.GetText, strTempModel:=ucrModelName.GetText, strTempDataframe:=ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text)
            ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = True
        Else
            ucrBase.clsRsyntax.SetAssignTo("last_model", strTempModel:="last_model", strTempDataframe:=ucrSelectorSimpleReg.ucrAvailableDataFrames.cboAvailableDataFrames.Text)
            ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
        End If
    End Sub

    Private Sub ucrFamily_cboDistributionsIndexChanged(sender As Object, e As EventArgs) Handles ucrFamily.cboDistributionsIndexChanged
        sdgModelOptions.ucrFamily.RecieverDatatype(ucrFamily.strDataType)
        sdgModelOptions.ucrFamily.cboDistributions.SelectedIndex = sdgModelOptions.ucrFamily.lstCurrentDistributions.FindIndex(Function(dist) dist.strNameTag = ucrFamily.clsCurrDistribution.strNameTag)
        sdgModelOptions.RestrictLink()
        DistributionsOffered()
        ConvertToVariate()
        ExplanatoryFunctionSelect()
        SetRCode()
        Display()
    End Sub

    Private Sub cmdModelOptions_Click(sender As Object, e As EventArgs) Handles cmdModelOptions.Click
        sdgModelOptions.ShowDialog()
        ucrFamily.cboDistributions.SelectedIndex = ucrFamily.lstCurrentDistributions.FindIndex(Function(dist) dist.strNameTag = sdgModelOptions.ucrFamily.clsCurrDistribution.strNameTag)
        Display()
    End Sub

    Private Sub chkFunction_CheckedChanged(sender As Object, e As EventArgs) Handles chkFunction.CheckedChanged
        If chkFunction.Checked Then
            sdgVariableTransformations.ShowDialog()
        End If
        ExplanatoryFunctionSelect()
        TestOKEnabled()
        Display()
    End Sub

    Private Sub Display()
        If rdoGeneral.Checked Then
            lblFactor.Visible = False
            lblNumeric.Visible = False
            ucrModelPreview.Visible = True
            lblModelPreview.Visible = True
            lblResponse.Visible = True
            lblExplanatory.Visible = True
            cmdDisplayOptions.Visible = True
            cmdModelOptions.Visible = True
            grpParameters.Visible = False
        ElseIf rdoSpecific.Checked Then
            ucrModelPreview.Visible = False
            lblModelPreview.Visible = False
            lblResponse.Visible = False
            lblExplanatory.Visible = False
            cmdDisplayOptions.Visible = False
            cmdModelOptions.Visible = False
            lblFactor.Visible = True
            lblNumeric.Visible = True
            chkConvertToVariate.Visible = False
            chkFunction.Visible = False
            grpParameters.Visible = True
            ' once OneVarHyp has been merged, the below code can be used

            '           If ucrFamily.clsCurrDistribution.bIsExact = True Then
            '           lblHyp1.Text = ucrFamily.clsCurrDistribution.lstExact(1)
            '           nudHyp1.Value = ucrFamily.clsCurrDistribution.lstExact(2)
            '           nudHyp1.Increment = ucrFamily.clsCurrDistribution.lstExact(3)
            '           nudHyp1.DecimalPlaces = ucrFamily.clsCurrDistribution.lstExact(4)
            '           nudHyp1.Minimum = ucrFamily.clsCurrDistribution.lstExact(5)
            '           nudHyp1.Maximum = ucrFamily.clsCurrDistribution.lstExact(6)
            '       End If
            '''' write in the code I need to implement
            If ucrFamily.clsCurrDistribution.strNameTag = "Bernouli" Then
                nudHyp2.Visible = True
                lblProbability2.Visible = True
                nudHyp2.Increment = 0.1
                nudHyp2.Maximum = 0.95
                nudHyp2.Minimum = 0.05
                nudHyp2.Value = 0.5
            Else
                nudHyp2.Visible = False
                lblProbability2.Visible = False
            End If
            If ucrFamily.clsCurrDistribution.strRName = "Normal" Then
                '         'If ucrExplanatory. GetVariables Is From same dataset
                chkPaired.Visible = True
            Else
                chkPaired.Visible = False
            End If
        End If
    End Sub


    Private Sub lbls_VisibleChanged(sender As Object, e As EventArgs) Handles lblCI.VisibleChanged, lblProbability2.VisibleChanged, lblHyp1.VisibleChanged, lblExplanatory.VisibleChanged, lblResponse.VisibleChanged, lblModelPreview.VisibleChanged, lblFactor.VisibleChanged, lblNumeric.VisibleChanged
        Display()
    End Sub

    Private Sub nuds_TextChanged(sender As Object, e As EventArgs) Handles nudCI.TextChanged, nudHypothesis.TextChanged, nudHyp2.TextChanged
        SetRCode()
    End Sub

    Private Sub chkboxes_VisibleChanged(sender As Object, e As EventArgs) Handles chkFunction.VisibleChanged, chkPaired.VisibleChanged
        Display()
        ExplanatoryFunctionSelect()
        ConvertToVariate()
        TestOKEnabled()
    End Sub

    Private Sub rdoTop_CheckedChanged(sender As Object, e As EventArgs) Handles rdoGeneral.CheckedChanged, rdoSpecific.CheckedChanged
        Display()
        SetRCode()
        DistributionsOffered()
        TestOKEnabled()
    End Sub
End Class