﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sdgCorruptionCalculatedColumns
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
        Me.ucrCalculatedColumnsSelector = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtonsSubdialogue()
        Me.lblProcedureType = New System.Windows.Forms.Label()
        Me.ucrReceiverProcedureType = New instat.ucrReceiverSingle()
        Me.lblAwardYear = New System.Windows.Forms.Label()
        Me.lblWinnerID = New System.Windows.Forms.Label()
        Me.ucrReceiverWinnerID = New instat.ucrReceiverSingle()
        Me.ucrReceiverAwardYear = New instat.ucrReceiverSingle()
        Me.lblProcuringAuthority = New System.Windows.Forms.Label()
        Me.ucrReceiverProcuringAuthority = New instat.ucrReceiverSingle()
        Me.ucrReceiverForeignWinner = New instat.ucrReceiverSingle()
        Me.lblForeignWinner = New System.Windows.Forms.Label()
        Me.lblProcurementTypeCat = New System.Windows.Forms.Label()
        Me.ucrReceiverProcurementTypeCat = New instat.ucrReceiverSingle()
        Me.lblContractValueCategories = New System.Windows.Forms.Label()
        Me.lblProcurementType3 = New System.Windows.Forms.Label()
        Me.ucrReceiverProcurementType3 = New instat.ucrReceiverSingle()
        Me.ucrReceiverContractValueCategories = New instat.ucrReceiverSingle()
        Me.lblProcurementType2 = New System.Windows.Forms.Label()
        Me.ucrReceiverProcurementType2 = New instat.ucrReceiverSingle()
        Me.ucrReceiverSignaturePeriod = New instat.ucrReceiverSingle()
        Me.lblSignaturePeriod = New System.Windows.Forms.Label()
        Me.lblRollSumWinner = New System.Windows.Forms.Label()
        Me.ucrReceiverValueSumWinner = New instat.ucrReceiverSingle()
        Me.lblRollNumIssuer = New System.Windows.Forms.Label()
        Me.lblRollShareWinner = New System.Windows.Forms.Label()
        Me.ucrReceiverValueShareWinner = New instat.ucrReceiverSingle()
        Me.ucrReceiverRollingNumberIssuer = New instat.ucrReceiverSingle()
        Me.lblRollSumIssuer = New System.Windows.Forms.Label()
        Me.ucrReceiverValueSumIssuer = New instat.ucrReceiverSingle()
        Me.ucrReceiverSingleBidder = New instat.ucrReceiverSingle()
        Me.lblSingleBidder = New System.Windows.Forms.Label()
        Me.lblSignaturePeriod5 = New System.Windows.Forms.Label()
        Me.ucrReceiverPeriod5 = New instat.ucrReceiverSingle()
        Me.lblSignaturePeriodCorrected = New System.Windows.Forms.Label()
        Me.lblSignaturePeriodCat = New System.Windows.Forms.Label()
        Me.ucrReceiverPeriodCat = New instat.ucrReceiverSingle()
        Me.ucrReceiverSignaturePeriodCorrected = New instat.ucrReceiverSingle()
        Me.lblSignaturePeriod25 = New System.Windows.Forms.Label()
        Me.ucrReceiverPeriod25 = New instat.ucrReceiverSingle()
        Me.ucrReceiverRollingNumberWinner = New instat.ucrReceiverSingle()
        Me.lblRollNumWinner = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.UcrReceiverSingle16 = New instat.ucrReceiverSingle()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.UcrReceiverSingle17 = New instat.ucrReceiverSingle()
        Me.UcrReceiverSingle18 = New instat.ucrReceiverSingle()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.UcrReceiverSingle19 = New instat.ucrReceiverSingle()
        Me.UcrReceiverSingle20 = New instat.ucrReceiverSingle()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblCountryISO2 = New System.Windows.Forms.Label()
        Me.ucrReceiverCountryISO2 = New instat.ucrReceiverSingle()
        Me.lblContractValueShareOverThreshold = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.UcrReceiverSingle22 = New instat.ucrReceiverSingle()
        Me.ucrReceiverContractShareThreshold = New instat.ucrReceiverSingle()
        Me.lblCountryISO3 = New System.Windows.Forms.Label()
        Me.ucrReceiverCountryISO3 = New instat.ucrReceiverSingle()
        Me.UcrReceiverSingle25 = New instat.ucrReceiverSingle()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblTaxHaven2 = New System.Windows.Forms.Label()
        Me.ucrReceiverTaxHaven2 = New instat.ucrReceiverSingle()
        Me.lblTaxHaven = New System.Windows.Forms.Label()
        Me.lblTaxHaven3bi = New System.Windows.Forms.Label()
        Me.ucrReceiverTaxHaven3bi = New instat.ucrReceiverSingle()
        Me.ucrReceiverTaxHaven = New instat.ucrReceiverSingle()
        Me.lblTaxHaven3 = New System.Windows.Forms.Label()
        Me.ucrReceiverTaxHaven3 = New instat.ucrReceiverSingle()
        Me.SuspendLayout()
        '
        'ucrCalculatedColumnsSelector
        '
        Me.ucrCalculatedColumnsSelector.bShowHiddenColumns = False
        Me.ucrCalculatedColumnsSelector.bUseCurrentFilter = True
        Me.ucrCalculatedColumnsSelector.Location = New System.Drawing.Point(10, 10)
        Me.ucrCalculatedColumnsSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrCalculatedColumnsSelector.Name = "ucrCalculatedColumnsSelector"
        Me.ucrCalculatedColumnsSelector.Size = New System.Drawing.Size(210, 180)
        Me.ucrCalculatedColumnsSelector.TabIndex = 33
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(202, 453)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(142, 30)
        Me.ucrBase.TabIndex = 66
        '
        'lblProcedureType
        '
        Me.lblProcedureType.AutoSize = True
        Me.lblProcedureType.Location = New System.Drawing.Point(234, 54)
        Me.lblProcedureType.Name = "lblProcedureType"
        Me.lblProcedureType.Size = New System.Drawing.Size(86, 13)
        Me.lblProcedureType.TabIndex = 64
        Me.lblProcedureType.Text = "Procedure Type:"
        '
        'ucrReceiverProcedureType
        '
        Me.ucrReceiverProcedureType.frmParent = Me
        Me.ucrReceiverProcedureType.Location = New System.Drawing.Point(234, 69)
        Me.ucrReceiverProcedureType.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverProcedureType.Name = "ucrReceiverProcedureType"
        Me.ucrReceiverProcedureType.Selector = Nothing
        Me.ucrReceiverProcedureType.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverProcedureType.TabIndex = 65
        '
        'lblAwardYear
        '
        Me.lblAwardYear.AutoSize = True
        Me.lblAwardYear.Location = New System.Drawing.Point(234, 11)
        Me.lblAwardYear.Name = "lblAwardYear"
        Me.lblAwardYear.Size = New System.Drawing.Size(65, 13)
        Me.lblAwardYear.TabIndex = 52
        Me.lblAwardYear.Text = "Award Year:"
        '
        'lblWinnerID
        '
        Me.lblWinnerID.AutoSize = True
        Me.lblWinnerID.Location = New System.Drawing.Point(234, 140)
        Me.lblWinnerID.Name = "lblWinnerID"
        Me.lblWinnerID.Size = New System.Drawing.Size(58, 13)
        Me.lblWinnerID.TabIndex = 56
        Me.lblWinnerID.Text = "Winner ID:"
        '
        'ucrReceiverWinnerID
        '
        Me.ucrReceiverWinnerID.frmParent = Me
        Me.ucrReceiverWinnerID.Location = New System.Drawing.Point(234, 155)
        Me.ucrReceiverWinnerID.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverWinnerID.Name = "ucrReceiverWinnerID"
        Me.ucrReceiverWinnerID.Selector = Nothing
        Me.ucrReceiverWinnerID.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverWinnerID.TabIndex = 57
        '
        'ucrReceiverAwardYear
        '
        Me.ucrReceiverAwardYear.frmParent = Me
        Me.ucrReceiverAwardYear.Location = New System.Drawing.Point(234, 26)
        Me.ucrReceiverAwardYear.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverAwardYear.Name = "ucrReceiverAwardYear"
        Me.ucrReceiverAwardYear.Selector = Nothing
        Me.ucrReceiverAwardYear.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverAwardYear.TabIndex = 53
        '
        'lblProcuringAuthority
        '
        Me.lblProcuringAuthority.AutoSize = True
        Me.lblProcuringAuthority.Location = New System.Drawing.Point(234, 97)
        Me.lblProcuringAuthority.Name = "lblProcuringAuthority"
        Me.lblProcuringAuthority.Size = New System.Drawing.Size(113, 13)
        Me.lblProcuringAuthority.TabIndex = 54
        Me.lblProcuringAuthority.Text = "Procuring Authority ID:"
        '
        'ucrReceiverProcuringAuthority
        '
        Me.ucrReceiverProcuringAuthority.frmParent = Me
        Me.ucrReceiverProcuringAuthority.Location = New System.Drawing.Point(234, 112)
        Me.ucrReceiverProcuringAuthority.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverProcuringAuthority.Name = "ucrReceiverProcuringAuthority"
        Me.ucrReceiverProcuringAuthority.Selector = Nothing
        Me.ucrReceiverProcuringAuthority.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverProcuringAuthority.TabIndex = 55
        '
        'ucrReceiverForeignWinner
        '
        Me.ucrReceiverForeignWinner.frmParent = Me
        Me.ucrReceiverForeignWinner.Location = New System.Drawing.Point(234, 200)
        Me.ucrReceiverForeignWinner.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverForeignWinner.Name = "ucrReceiverForeignWinner"
        Me.ucrReceiverForeignWinner.Selector = Nothing
        Me.ucrReceiverForeignWinner.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverForeignWinner.TabIndex = 51
        '
        'lblForeignWinner
        '
        Me.lblForeignWinner.AutoSize = True
        Me.lblForeignWinner.Location = New System.Drawing.Point(234, 185)
        Me.lblForeignWinner.Name = "lblForeignWinner"
        Me.lblForeignWinner.Size = New System.Drawing.Size(82, 13)
        Me.lblForeignWinner.TabIndex = 50
        Me.lblForeignWinner.Text = "Foreign Winner:"
        '
        'lblProcurementTypeCat
        '
        Me.lblProcurementTypeCat.AutoSize = True
        Me.lblProcurementTypeCat.Location = New System.Drawing.Point(234, 268)
        Me.lblProcurementTypeCat.Name = "lblProcurementTypeCat"
        Me.lblProcurementTypeCat.Size = New System.Drawing.Size(150, 13)
        Me.lblProcurementTypeCat.TabIndex = 77
        Me.lblProcurementTypeCat.Text = "Procurement Type Categories:"
        '
        'ucrReceiverProcurementTypeCat
        '
        Me.ucrReceiverProcurementTypeCat.frmParent = Me
        Me.ucrReceiverProcurementTypeCat.Location = New System.Drawing.Point(234, 283)
        Me.ucrReceiverProcurementTypeCat.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverProcurementTypeCat.Name = "ucrReceiverProcurementTypeCat"
        Me.ucrReceiverProcurementTypeCat.Selector = Nothing
        Me.ucrReceiverProcurementTypeCat.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverProcurementTypeCat.TabIndex = 78
        '
        'lblContractValueCategories
        '
        Me.lblContractValueCategories.AutoSize = True
        Me.lblContractValueCategories.Location = New System.Drawing.Point(234, 225)
        Me.lblContractValueCategories.Name = "lblContractValueCategories"
        Me.lblContractValueCategories.Size = New System.Drawing.Size(133, 13)
        Me.lblContractValueCategories.TabIndex = 71
        Me.lblContractValueCategories.Text = "Contract Value Categories:"
        '
        'lblProcurementType3
        '
        Me.lblProcurementType3.AutoSize = True
        Me.lblProcurementType3.Location = New System.Drawing.Point(234, 354)
        Me.lblProcurementType3.Name = "lblProcurementType3"
        Me.lblProcurementType3.Size = New System.Drawing.Size(106, 13)
        Me.lblProcurementType3.TabIndex = 75
        Me.lblProcurementType3.Text = "Procurement Type 3:"
        '
        'ucrReceiverProcurementType3
        '
        Me.ucrReceiverProcurementType3.frmParent = Me
        Me.ucrReceiverProcurementType3.Location = New System.Drawing.Point(234, 369)
        Me.ucrReceiverProcurementType3.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverProcurementType3.Name = "ucrReceiverProcurementType3"
        Me.ucrReceiverProcurementType3.Selector = Nothing
        Me.ucrReceiverProcurementType3.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverProcurementType3.TabIndex = 76
        '
        'ucrReceiverContractValueCategories
        '
        Me.ucrReceiverContractValueCategories.frmParent = Me
        Me.ucrReceiverContractValueCategories.Location = New System.Drawing.Point(234, 240)
        Me.ucrReceiverContractValueCategories.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverContractValueCategories.Name = "ucrReceiverContractValueCategories"
        Me.ucrReceiverContractValueCategories.Selector = Nothing
        Me.ucrReceiverContractValueCategories.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverContractValueCategories.TabIndex = 72
        '
        'lblProcurementType2
        '
        Me.lblProcurementType2.AutoSize = True
        Me.lblProcurementType2.Location = New System.Drawing.Point(234, 311)
        Me.lblProcurementType2.Name = "lblProcurementType2"
        Me.lblProcurementType2.Size = New System.Drawing.Size(106, 13)
        Me.lblProcurementType2.TabIndex = 73
        Me.lblProcurementType2.Text = "Procurement Type 2:"
        '
        'ucrReceiverProcurementType2
        '
        Me.ucrReceiverProcurementType2.frmParent = Me
        Me.ucrReceiverProcurementType2.Location = New System.Drawing.Point(234, 326)
        Me.ucrReceiverProcurementType2.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverProcurementType2.Name = "ucrReceiverProcurementType2"
        Me.ucrReceiverProcurementType2.Selector = Nothing
        Me.ucrReceiverProcurementType2.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverProcurementType2.TabIndex = 74
        '
        'ucrReceiverSignaturePeriod
        '
        Me.ucrReceiverSignaturePeriod.frmParent = Me
        Me.ucrReceiverSignaturePeriod.Location = New System.Drawing.Point(399, 26)
        Me.ucrReceiverSignaturePeriod.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSignaturePeriod.Name = "ucrReceiverSignaturePeriod"
        Me.ucrReceiverSignaturePeriod.Selector = Nothing
        Me.ucrReceiverSignaturePeriod.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverSignaturePeriod.TabIndex = 70
        '
        'lblSignaturePeriod
        '
        Me.lblSignaturePeriod.AutoSize = True
        Me.lblSignaturePeriod.Location = New System.Drawing.Point(399, 11)
        Me.lblSignaturePeriod.Name = "lblSignaturePeriod"
        Me.lblSignaturePeriod.Size = New System.Drawing.Size(88, 13)
        Me.lblSignaturePeriod.TabIndex = 69
        Me.lblSignaturePeriod.Text = "Signature Period:"
        '
        'lblRollSumWinner
        '
        Me.lblRollSumWinner.AutoSize = True
        Me.lblRollSumWinner.Location = New System.Drawing.Point(399, 311)
        Me.lblRollSumWinner.Name = "lblRollSumWinner"
        Me.lblRollSumWinner.Size = New System.Drawing.Size(146, 13)
        Me.lblRollSumWinner.TabIndex = 97
        Me.lblRollSumWinner.Text = "Rolling Contract Sum Winner:"
        '
        'ucrReceiverValueSumWinner
        '
        Me.ucrReceiverValueSumWinner.frmParent = Me
        Me.ucrReceiverValueSumWinner.Location = New System.Drawing.Point(399, 326)
        Me.ucrReceiverValueSumWinner.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverValueSumWinner.Name = "ucrReceiverValueSumWinner"
        Me.ucrReceiverValueSumWinner.Selector = Nothing
        Me.ucrReceiverValueSumWinner.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverValueSumWinner.TabIndex = 98
        '
        'lblRollNumIssuer
        '
        Me.lblRollNumIssuer.AutoSize = True
        Me.lblRollNumIssuer.Location = New System.Drawing.Point(399, 268)
        Me.lblRollNumIssuer.Name = "lblRollNumIssuer"
        Me.lblRollNumIssuer.Size = New System.Drawing.Size(156, 13)
        Me.lblRollNumIssuer.TabIndex = 91
        Me.lblRollNumIssuer.Text = "Rolling Contract Number Issuer:"
        '
        'lblRollShareWinner
        '
        Me.lblRollShareWinner.AutoSize = True
        Me.lblRollShareWinner.Location = New System.Drawing.Point(399, 397)
        Me.lblRollShareWinner.Name = "lblRollShareWinner"
        Me.lblRollShareWinner.Size = New System.Drawing.Size(153, 13)
        Me.lblRollShareWinner.TabIndex = 95
        Me.lblRollShareWinner.Text = "Rolling Contract Share Winner:"
        '
        'ucrReceiverValueShareWinner
        '
        Me.ucrReceiverValueShareWinner.frmParent = Me
        Me.ucrReceiverValueShareWinner.Location = New System.Drawing.Point(399, 412)
        Me.ucrReceiverValueShareWinner.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverValueShareWinner.Name = "ucrReceiverValueShareWinner"
        Me.ucrReceiverValueShareWinner.Selector = Nothing
        Me.ucrReceiverValueShareWinner.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverValueShareWinner.TabIndex = 96
        '
        'ucrReceiverRollingNumberIssuer
        '
        Me.ucrReceiverRollingNumberIssuer.frmParent = Me
        Me.ucrReceiverRollingNumberIssuer.Location = New System.Drawing.Point(399, 283)
        Me.ucrReceiverRollingNumberIssuer.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverRollingNumberIssuer.Name = "ucrReceiverRollingNumberIssuer"
        Me.ucrReceiverRollingNumberIssuer.Selector = Nothing
        Me.ucrReceiverRollingNumberIssuer.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverRollingNumberIssuer.TabIndex = 92
        '
        'lblRollSumIssuer
        '
        Me.lblRollSumIssuer.AutoSize = True
        Me.lblRollSumIssuer.Location = New System.Drawing.Point(399, 354)
        Me.lblRollSumIssuer.Name = "lblRollSumIssuer"
        Me.lblRollSumIssuer.Size = New System.Drawing.Size(140, 13)
        Me.lblRollSumIssuer.TabIndex = 93
        Me.lblRollSumIssuer.Text = "Rolling Contract Sum Issuer:"
        '
        'ucrReceiverValueSumIssuer
        '
        Me.ucrReceiverValueSumIssuer.frmParent = Me
        Me.ucrReceiverValueSumIssuer.Location = New System.Drawing.Point(399, 369)
        Me.ucrReceiverValueSumIssuer.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverValueSumIssuer.Name = "ucrReceiverValueSumIssuer"
        Me.ucrReceiverValueSumIssuer.Selector = Nothing
        Me.ucrReceiverValueSumIssuer.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverValueSumIssuer.TabIndex = 94
        '
        'ucrReceiverSingleBidder
        '
        Me.ucrReceiverSingleBidder.frmParent = Me
        Me.ucrReceiverSingleBidder.Location = New System.Drawing.Point(234, 412)
        Me.ucrReceiverSingleBidder.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSingleBidder.Name = "ucrReceiverSingleBidder"
        Me.ucrReceiverSingleBidder.Selector = Nothing
        Me.ucrReceiverSingleBidder.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverSingleBidder.TabIndex = 90
        '
        'lblSingleBidder
        '
        Me.lblSingleBidder.AutoSize = True
        Me.lblSingleBidder.Location = New System.Drawing.Point(234, 397)
        Me.lblSingleBidder.Name = "lblSingleBidder"
        Me.lblSingleBidder.Size = New System.Drawing.Size(72, 13)
        Me.lblSingleBidder.TabIndex = 89
        Me.lblSingleBidder.Text = "Single Bidder:"
        '
        'lblSignaturePeriod5
        '
        Me.lblSignaturePeriod5.AutoSize = True
        Me.lblSignaturePeriod5.Location = New System.Drawing.Point(396, 97)
        Me.lblSignaturePeriod5.Name = "lblSignaturePeriod5"
        Me.lblSignaturePeriod5.Size = New System.Drawing.Size(147, 13)
        Me.lblSignaturePeriod5.TabIndex = 87
        Me.lblSignaturePeriod5.Text = "Signature Period (5 Quartiles):"
        '
        'ucrReceiverPeriod5
        '
        Me.ucrReceiverPeriod5.frmParent = Me
        Me.ucrReceiverPeriod5.Location = New System.Drawing.Point(399, 112)
        Me.ucrReceiverPeriod5.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverPeriod5.Name = "ucrReceiverPeriod5"
        Me.ucrReceiverPeriod5.Selector = Nothing
        Me.ucrReceiverPeriod5.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverPeriod5.TabIndex = 88
        '
        'lblSignaturePeriodCorrected
        '
        Me.lblSignaturePeriodCorrected.AutoSize = True
        Me.lblSignaturePeriodCorrected.Location = New System.Drawing.Point(399, 54)
        Me.lblSignaturePeriodCorrected.Name = "lblSignaturePeriodCorrected"
        Me.lblSignaturePeriodCorrected.Size = New System.Drawing.Size(137, 13)
        Me.lblSignaturePeriodCorrected.TabIndex = 81
        Me.lblSignaturePeriodCorrected.Text = "Signature Period Corrected:"
        '
        'lblSignaturePeriodCat
        '
        Me.lblSignaturePeriodCat.AutoSize = True
        Me.lblSignaturePeriodCat.Location = New System.Drawing.Point(399, 183)
        Me.lblSignaturePeriodCat.Name = "lblSignaturePeriodCat"
        Me.lblSignaturePeriodCat.Size = New System.Drawing.Size(141, 13)
        Me.lblSignaturePeriodCat.TabIndex = 85
        Me.lblSignaturePeriodCat.Text = "Signature Period Categories:"
        '
        'ucrReceiverPeriodCat
        '
        Me.ucrReceiverPeriodCat.frmParent = Me
        Me.ucrReceiverPeriodCat.Location = New System.Drawing.Point(399, 198)
        Me.ucrReceiverPeriodCat.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverPeriodCat.Name = "ucrReceiverPeriodCat"
        Me.ucrReceiverPeriodCat.Selector = Nothing
        Me.ucrReceiverPeriodCat.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverPeriodCat.TabIndex = 86
        '
        'ucrReceiverSignaturePeriodCorrected
        '
        Me.ucrReceiverSignaturePeriodCorrected.frmParent = Me
        Me.ucrReceiverSignaturePeriodCorrected.Location = New System.Drawing.Point(399, 69)
        Me.ucrReceiverSignaturePeriodCorrected.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverSignaturePeriodCorrected.Name = "ucrReceiverSignaturePeriodCorrected"
        Me.ucrReceiverSignaturePeriodCorrected.Selector = Nothing
        Me.ucrReceiverSignaturePeriodCorrected.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverSignaturePeriodCorrected.TabIndex = 82
        '
        'lblSignaturePeriod25
        '
        Me.lblSignaturePeriod25.AutoSize = True
        Me.lblSignaturePeriod25.Location = New System.Drawing.Point(398, 140)
        Me.lblSignaturePeriod25.Name = "lblSignaturePeriod25"
        Me.lblSignaturePeriod25.Size = New System.Drawing.Size(153, 13)
        Me.lblSignaturePeriod25.TabIndex = 83
        Me.lblSignaturePeriod25.Text = "Signature Period (25 Quartiles):"
        '
        'ucrReceiverPeriod25
        '
        Me.ucrReceiverPeriod25.frmParent = Me
        Me.ucrReceiverPeriod25.Location = New System.Drawing.Point(399, 155)
        Me.ucrReceiverPeriod25.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverPeriod25.Name = "ucrReceiverPeriod25"
        Me.ucrReceiverPeriod25.Selector = Nothing
        Me.ucrReceiverPeriod25.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverPeriod25.TabIndex = 84
        '
        'ucrReceiverRollingNumberWinner
        '
        Me.ucrReceiverRollingNumberWinner.frmParent = Me
        Me.ucrReceiverRollingNumberWinner.Location = New System.Drawing.Point(399, 243)
        Me.ucrReceiverRollingNumberWinner.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverRollingNumberWinner.Name = "ucrReceiverRollingNumberWinner"
        Me.ucrReceiverRollingNumberWinner.Selector = Nothing
        Me.ucrReceiverRollingNumberWinner.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverRollingNumberWinner.TabIndex = 80
        '
        'lblRollNumWinner
        '
        Me.lblRollNumWinner.AutoSize = True
        Me.lblRollNumWinner.Location = New System.Drawing.Point(399, 228)
        Me.lblRollNumWinner.Name = "lblRollNumWinner"
        Me.lblRollNumWinner.Size = New System.Drawing.Size(162, 13)
        Me.lblRollNumWinner.TabIndex = 79
        Me.lblRollNumWinner.Text = "Rolling Contract Number Winner:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(567, 268)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 117
        Me.Label16.Text = "Country ISO2:"
        '
        'UcrReceiverSingle16
        '
        Me.UcrReceiverSingle16.frmParent = Me
        Me.UcrReceiverSingle16.Location = New System.Drawing.Point(567, 283)
        Me.UcrReceiverSingle16.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle16.Name = "UcrReceiverSingle16"
        Me.UcrReceiverSingle16.Selector = Nothing
        Me.UcrReceiverSingle16.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle16.TabIndex = 118
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(567, 225)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 111
        Me.Label17.Text = "Country:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(567, 354)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 115
        Me.Label18.Text = "WB PPP:"
        '
        'UcrReceiverSingle17
        '
        Me.UcrReceiverSingle17.frmParent = Me
        Me.UcrReceiverSingle17.Location = New System.Drawing.Point(567, 369)
        Me.UcrReceiverSingle17.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle17.Name = "UcrReceiverSingle17"
        Me.UcrReceiverSingle17.Selector = Nothing
        Me.UcrReceiverSingle17.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle17.TabIndex = 116
        '
        'UcrReceiverSingle18
        '
        Me.UcrReceiverSingle18.frmParent = Me
        Me.UcrReceiverSingle18.Location = New System.Drawing.Point(567, 240)
        Me.UcrReceiverSingle18.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle18.Name = "UcrReceiverSingle18"
        Me.UcrReceiverSingle18.Selector = Nothing
        Me.UcrReceiverSingle18.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle18.TabIndex = 112
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(567, 311)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 13)
        Me.Label19.TabIndex = 113
        Me.Label19.Text = "Country ISO3:"
        '
        'UcrReceiverSingle19
        '
        Me.UcrReceiverSingle19.frmParent = Me
        Me.UcrReceiverSingle19.Location = New System.Drawing.Point(567, 326)
        Me.UcrReceiverSingle19.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle19.Name = "UcrReceiverSingle19"
        Me.UcrReceiverSingle19.Selector = Nothing
        Me.UcrReceiverSingle19.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle19.TabIndex = 114
        '
        'UcrReceiverSingle20
        '
        Me.UcrReceiverSingle20.frmParent = Me
        Me.UcrReceiverSingle20.Location = New System.Drawing.Point(567, 414)
        Me.UcrReceiverSingle20.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle20.Name = "UcrReceiverSingle20"
        Me.UcrReceiverSingle20.Selector = Nothing
        Me.UcrReceiverSingle20.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle20.TabIndex = 110
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(567, 399)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "Small State:"
        '
        'lblCountryISO2
        '
        Me.lblCountryISO2.AutoSize = True
        Me.lblCountryISO2.Location = New System.Drawing.Point(567, 54)
        Me.lblCountryISO2.Name = "lblCountryISO2"
        Me.lblCountryISO2.Size = New System.Drawing.Size(73, 13)
        Me.lblCountryISO2.TabIndex = 107
        Me.lblCountryISO2.Text = "Country ISO2:"
        '
        'ucrReceiverCountryISO2
        '
        Me.ucrReceiverCountryISO2.frmParent = Me
        Me.ucrReceiverCountryISO2.Location = New System.Drawing.Point(567, 69)
        Me.ucrReceiverCountryISO2.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverCountryISO2.Name = "ucrReceiverCountryISO2"
        Me.ucrReceiverCountryISO2.Selector = Nothing
        Me.ucrReceiverCountryISO2.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverCountryISO2.TabIndex = 108
        '
        'lblContractValueShareOverThreshold
        '
        Me.lblContractValueShareOverThreshold.AutoSize = True
        Me.lblContractValueShareOverThreshold.Location = New System.Drawing.Point(567, 11)
        Me.lblContractValueShareOverThreshold.Name = "lblContractValueShareOverThreshold"
        Me.lblContractValueShareOverThreshold.Size = New System.Drawing.Size(161, 13)
        Me.lblContractValueShareOverThreshold.TabIndex = 101
        Me.lblContractValueShareOverThreshold.Text = "Contract Value Share Threshold:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(567, 140)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 13)
        Me.Label23.TabIndex = 105
        Me.Label23.Text = "WB PPP:"
        '
        'UcrReceiverSingle22
        '
        Me.UcrReceiverSingle22.frmParent = Me
        Me.UcrReceiverSingle22.Location = New System.Drawing.Point(567, 155)
        Me.UcrReceiverSingle22.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle22.Name = "UcrReceiverSingle22"
        Me.UcrReceiverSingle22.Selector = Nothing
        Me.UcrReceiverSingle22.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle22.TabIndex = 106
        '
        'ucrReceiverContractShareThreshold
        '
        Me.ucrReceiverContractShareThreshold.frmParent = Me
        Me.ucrReceiverContractShareThreshold.Location = New System.Drawing.Point(567, 26)
        Me.ucrReceiverContractShareThreshold.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverContractShareThreshold.Name = "ucrReceiverContractShareThreshold"
        Me.ucrReceiverContractShareThreshold.Selector = Nothing
        Me.ucrReceiverContractShareThreshold.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverContractShareThreshold.TabIndex = 102
        '
        'lblCountryISO3
        '
        Me.lblCountryISO3.AutoSize = True
        Me.lblCountryISO3.Location = New System.Drawing.Point(567, 97)
        Me.lblCountryISO3.Name = "lblCountryISO3"
        Me.lblCountryISO3.Size = New System.Drawing.Size(73, 13)
        Me.lblCountryISO3.TabIndex = 103
        Me.lblCountryISO3.Text = "Country ISO3:"
        '
        'ucrReceiverCountryISO3
        '
        Me.ucrReceiverCountryISO3.frmParent = Me
        Me.ucrReceiverCountryISO3.Location = New System.Drawing.Point(567, 112)
        Me.ucrReceiverCountryISO3.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverCountryISO3.Name = "ucrReceiverCountryISO3"
        Me.ucrReceiverCountryISO3.Selector = Nothing
        Me.ucrReceiverCountryISO3.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverCountryISO3.TabIndex = 104
        '
        'UcrReceiverSingle25
        '
        Me.UcrReceiverSingle25.frmParent = Me
        Me.UcrReceiverSingle25.Location = New System.Drawing.Point(567, 200)
        Me.UcrReceiverSingle25.Margin = New System.Windows.Forms.Padding(0)
        Me.UcrReceiverSingle25.Name = "UcrReceiverSingle25"
        Me.UcrReceiverSingle25.Selector = Nothing
        Me.UcrReceiverSingle25.Size = New System.Drawing.Size(120, 20)
        Me.UcrReceiverSingle25.TabIndex = 100
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(567, 185)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 99
        Me.Label25.Text = "Small State:"
        '
        'lblTaxHaven2
        '
        Me.lblTaxHaven2.AutoSize = True
        Me.lblTaxHaven2.Location = New System.Drawing.Point(731, 54)
        Me.lblTaxHaven2.Name = "lblTaxHaven2"
        Me.lblTaxHaven2.Size = New System.Drawing.Size(72, 13)
        Me.lblTaxHaven2.TabIndex = 127
        Me.lblTaxHaven2.Text = "Tax Haven 2:"
        '
        'ucrReceiverTaxHaven2
        '
        Me.ucrReceiverTaxHaven2.frmParent = Me
        Me.ucrReceiverTaxHaven2.Location = New System.Drawing.Point(731, 69)
        Me.ucrReceiverTaxHaven2.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverTaxHaven2.Name = "ucrReceiverTaxHaven2"
        Me.ucrReceiverTaxHaven2.Selector = Nothing
        Me.ucrReceiverTaxHaven2.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverTaxHaven2.TabIndex = 128
        '
        'lblTaxHaven
        '
        Me.lblTaxHaven.AutoSize = True
        Me.lblTaxHaven.Location = New System.Drawing.Point(731, 11)
        Me.lblTaxHaven.Name = "lblTaxHaven"
        Me.lblTaxHaven.Size = New System.Drawing.Size(63, 13)
        Me.lblTaxHaven.TabIndex = 121
        Me.lblTaxHaven.Text = "Tax Haven:"
        '
        'lblTaxHaven3bi
        '
        Me.lblTaxHaven3bi.AutoSize = True
        Me.lblTaxHaven3bi.Location = New System.Drawing.Point(731, 140)
        Me.lblTaxHaven3bi.Name = "lblTaxHaven3bi"
        Me.lblTaxHaven3bi.Size = New System.Drawing.Size(80, 13)
        Me.lblTaxHaven3bi.TabIndex = 125
        Me.lblTaxHaven3bi.Text = "Tax Haven 3bi:"
        '
        'ucrReceiverTaxHaven3bi
        '
        Me.ucrReceiverTaxHaven3bi.frmParent = Me
        Me.ucrReceiverTaxHaven3bi.Location = New System.Drawing.Point(731, 155)
        Me.ucrReceiverTaxHaven3bi.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverTaxHaven3bi.Name = "ucrReceiverTaxHaven3bi"
        Me.ucrReceiverTaxHaven3bi.Selector = Nothing
        Me.ucrReceiverTaxHaven3bi.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverTaxHaven3bi.TabIndex = 126
        '
        'ucrReceiverTaxHaven
        '
        Me.ucrReceiverTaxHaven.frmParent = Me
        Me.ucrReceiverTaxHaven.Location = New System.Drawing.Point(731, 26)
        Me.ucrReceiverTaxHaven.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverTaxHaven.Name = "ucrReceiverTaxHaven"
        Me.ucrReceiverTaxHaven.Selector = Nothing
        Me.ucrReceiverTaxHaven.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverTaxHaven.TabIndex = 122
        '
        'lblTaxHaven3
        '
        Me.lblTaxHaven3.AutoSize = True
        Me.lblTaxHaven3.Location = New System.Drawing.Point(731, 97)
        Me.lblTaxHaven3.Name = "lblTaxHaven3"
        Me.lblTaxHaven3.Size = New System.Drawing.Size(72, 13)
        Me.lblTaxHaven3.TabIndex = 123
        Me.lblTaxHaven3.Text = "Tax Haven 3:"
        '
        'ucrReceiverTaxHaven3
        '
        Me.ucrReceiverTaxHaven3.frmParent = Me
        Me.ucrReceiverTaxHaven3.Location = New System.Drawing.Point(731, 112)
        Me.ucrReceiverTaxHaven3.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverTaxHaven3.Name = "ucrReceiverTaxHaven3"
        Me.ucrReceiverTaxHaven3.Selector = Nothing
        Me.ucrReceiverTaxHaven3.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverTaxHaven3.TabIndex = 124
        '
        'sdgCorruptionCalculatedColumns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 495)
        Me.Controls.Add(Me.lblTaxHaven2)
        Me.Controls.Add(Me.ucrReceiverTaxHaven2)
        Me.Controls.Add(Me.lblTaxHaven)
        Me.Controls.Add(Me.lblTaxHaven3bi)
        Me.Controls.Add(Me.ucrReceiverTaxHaven3bi)
        Me.Controls.Add(Me.ucrReceiverTaxHaven)
        Me.Controls.Add(Me.lblTaxHaven3)
        Me.Controls.Add(Me.ucrReceiverTaxHaven3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.UcrReceiverSingle16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.UcrReceiverSingle17)
        Me.Controls.Add(Me.UcrReceiverSingle18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.UcrReceiverSingle19)
        Me.Controls.Add(Me.UcrReceiverSingle20)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblCountryISO2)
        Me.Controls.Add(Me.ucrReceiverCountryISO2)
        Me.Controls.Add(Me.lblContractValueShareOverThreshold)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.UcrReceiverSingle22)
        Me.Controls.Add(Me.ucrReceiverContractShareThreshold)
        Me.Controls.Add(Me.lblCountryISO3)
        Me.Controls.Add(Me.ucrReceiverCountryISO3)
        Me.Controls.Add(Me.UcrReceiverSingle25)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lblRollSumWinner)
        Me.Controls.Add(Me.ucrReceiverValueSumWinner)
        Me.Controls.Add(Me.lblRollNumIssuer)
        Me.Controls.Add(Me.lblRollShareWinner)
        Me.Controls.Add(Me.ucrReceiverValueShareWinner)
        Me.Controls.Add(Me.ucrReceiverRollingNumberIssuer)
        Me.Controls.Add(Me.lblRollSumIssuer)
        Me.Controls.Add(Me.ucrReceiverValueSumIssuer)
        Me.Controls.Add(Me.ucrReceiverSingleBidder)
        Me.Controls.Add(Me.lblSingleBidder)
        Me.Controls.Add(Me.lblSignaturePeriod5)
        Me.Controls.Add(Me.ucrReceiverPeriod5)
        Me.Controls.Add(Me.lblSignaturePeriodCorrected)
        Me.Controls.Add(Me.lblSignaturePeriodCat)
        Me.Controls.Add(Me.ucrReceiverPeriodCat)
        Me.Controls.Add(Me.ucrReceiverSignaturePeriodCorrected)
        Me.Controls.Add(Me.lblSignaturePeriod25)
        Me.Controls.Add(Me.ucrReceiverPeriod25)
        Me.Controls.Add(Me.ucrReceiverRollingNumberWinner)
        Me.Controls.Add(Me.lblRollNumWinner)
        Me.Controls.Add(Me.lblProcurementTypeCat)
        Me.Controls.Add(Me.ucrReceiverProcurementTypeCat)
        Me.Controls.Add(Me.lblContractValueCategories)
        Me.Controls.Add(Me.lblProcurementType3)
        Me.Controls.Add(Me.ucrReceiverProcurementType3)
        Me.Controls.Add(Me.ucrReceiverContractValueCategories)
        Me.Controls.Add(Me.lblProcurementType2)
        Me.Controls.Add(Me.ucrReceiverProcurementType2)
        Me.Controls.Add(Me.ucrReceiverSignaturePeriod)
        Me.Controls.Add(Me.lblSignaturePeriod)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.lblProcedureType)
        Me.Controls.Add(Me.ucrReceiverProcedureType)
        Me.Controls.Add(Me.lblAwardYear)
        Me.Controls.Add(Me.lblWinnerID)
        Me.Controls.Add(Me.ucrReceiverWinnerID)
        Me.Controls.Add(Me.ucrReceiverAwardYear)
        Me.Controls.Add(Me.lblProcuringAuthority)
        Me.Controls.Add(Me.ucrReceiverProcuringAuthority)
        Me.Controls.Add(Me.ucrReceiverForeignWinner)
        Me.Controls.Add(Me.lblForeignWinner)
        Me.Controls.Add(Me.ucrCalculatedColumnsSelector)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "sdgCorruptionCalculatedColumns"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calculated Columns"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrCalculatedColumnsSelector As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrBase As ucrButtonsSubdialogue
    Friend WithEvents lblProcedureType As Label
    Friend WithEvents ucrReceiverProcedureType As ucrReceiverSingle
    Friend WithEvents lblTaxHaven2 As Label
    Friend WithEvents ucrReceiverTaxHaven2 As ucrReceiverSingle
    Friend WithEvents lblTaxHaven As Label
    Friend WithEvents lblTaxHaven3bi As Label
    Friend WithEvents ucrReceiverTaxHaven3bi As ucrReceiverSingle
    Friend WithEvents ucrReceiverTaxHaven As ucrReceiverSingle
    Friend WithEvents lblTaxHaven3 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents UcrReceiverSingle16 As ucrReceiverSingle
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents UcrReceiverSingle17 As ucrReceiverSingle
    Friend WithEvents UcrReceiverSingle18 As ucrReceiverSingle
    Friend WithEvents Label19 As Label
    Friend WithEvents UcrReceiverSingle19 As ucrReceiverSingle
    Friend WithEvents UcrReceiverSingle20 As ucrReceiverSingle
    Friend WithEvents Label20 As Label
    Friend WithEvents lblCountryISO2 As Label
    Friend WithEvents ucrReceiverCountryISO2 As ucrReceiverSingle
    Friend WithEvents lblContractValueShareOverThreshold As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents UcrReceiverSingle22 As ucrReceiverSingle
    Friend WithEvents ucrReceiverContractShareThreshold As ucrReceiverSingle
    Friend WithEvents lblCountryISO3 As Label
    Friend WithEvents ucrReceiverCountryISO3 As ucrReceiverSingle
    Friend WithEvents UcrReceiverSingle25 As ucrReceiverSingle
    Friend WithEvents Label25 As Label
    Friend WithEvents lblRollSumWinner As Label
    Friend WithEvents ucrReceiverValueSumWinner As ucrReceiverSingle
    Friend WithEvents lblRollNumIssuer As Label
    Friend WithEvents lblRollShareWinner As Label
    Friend WithEvents ucrReceiverValueShareWinner As ucrReceiverSingle
    Friend WithEvents ucrReceiverRollingNumberIssuer As ucrReceiverSingle
    Friend WithEvents lblRollSumIssuer As Label
    Friend WithEvents ucrReceiverValueSumIssuer As ucrReceiverSingle
    Friend WithEvents ucrReceiverSingleBidder As ucrReceiverSingle
    Friend WithEvents lblSingleBidder As Label
    Friend WithEvents lblSignaturePeriod5 As Label
    Friend WithEvents ucrReceiverPeriod5 As ucrReceiverSingle
    Friend WithEvents lblSignaturePeriodCorrected As Label
    Friend WithEvents lblSignaturePeriodCat As Label
    Friend WithEvents ucrReceiverPeriodCat As ucrReceiverSingle
    Friend WithEvents ucrReceiverSignaturePeriodCorrected As ucrReceiverSingle
    Friend WithEvents lblSignaturePeriod25 As Label
    Friend WithEvents ucrReceiverPeriod25 As ucrReceiverSingle
    Friend WithEvents ucrReceiverRollingNumberWinner As ucrReceiverSingle
    Friend WithEvents lblRollNumWinner As Label
    Friend WithEvents lblProcurementTypeCat As Label
    Friend WithEvents ucrReceiverProcurementTypeCat As ucrReceiverSingle
    Friend WithEvents lblContractValueCategories As Label
    Friend WithEvents lblProcurementType3 As Label
    Friend WithEvents ucrReceiverProcurementType3 As ucrReceiverSingle
    Friend WithEvents ucrReceiverContractValueCategories As ucrReceiverSingle
    Friend WithEvents lblProcurementType2 As Label
    Friend WithEvents ucrReceiverProcurementType2 As ucrReceiverSingle
    Friend WithEvents ucrReceiverSignaturePeriod As ucrReceiverSingle
    Friend WithEvents lblSignaturePeriod As Label
    Friend WithEvents lblAwardYear As Label
    Friend WithEvents lblWinnerID As Label
    Friend WithEvents ucrReceiverWinnerID As ucrReceiverSingle
    Friend WithEvents ucrReceiverAwardYear As ucrReceiverSingle
    Friend WithEvents lblProcuringAuthority As Label
    Friend WithEvents ucrReceiverProcuringAuthority As ucrReceiverSingle
    Friend WithEvents ucrReceiverForeignWinner As ucrReceiverSingle
    Friend WithEvents lblForeignWinner As Label
    Friend WithEvents ucrReceiverTaxHaven3 As ucrReceiverSingle
End Class
