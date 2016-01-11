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
Imports RDotNet
Imports System.IO
Imports System.Globalization
Imports System.Threading
Imports instat.Translations
Imports System.ComponentModel

Public Class frmMain

    Public clsRInterface As New RInterface
    ' TODO clsButtons needs to be deleted
    Public clsButton As New ucrButtons
    Public clsGrids As New clsGridLink

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmEditor.MdiParent = Me
        frmCommand.MdiParent = Me
        frmLog.MdiParent = Me
        frmScript.MdiParent = Me
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
        frmCommand.Dock = DockStyle.Right
        frmEditor.Dock = DockStyle.Left
        frmEditor.Dock = DockStyle.Fill
        frmCommand.Show()
        frmEditor.Show()

        'Setting the properties of R Interface
        clsRInterface.SetLog(frmLog.txtLog)
        clsRInterface.SetOutput(frmCommand.txtCommand)
        clsRInterface.clsEngine = REngine.GetInstance()
        clsRInterface.clsEngine.Initialize()
        'Sets up R source files
        clsRInterface.RSetup()

        ' TODO tstatus shouldn't be set here in this way
        tstatus.Text = frmEditor.grdData.CurrentWorksheet.Name

    End Sub

    Private Sub ImportASCIIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuFIleIEASCII.Click
        Dim pair As KeyValuePair(Of String, String) = OpenDialog()
        clsButton.clsRsyntax.SetFunction("read.csv")
        clsButton.clsRsyntax.AddParameter("file", pair.Value)
        clsRInterface.LoadData(pair.Key, clsButton.clsRsyntax.GetScript())
        clsRInterface.FillDataObjectVariables(frmVariables.grdVariables)
        clsRInterface.FillDataObjectMetadata(frmMetaData.grdMetaData)
        clsRInterface.FillDataObjectData(frmEditor.grdData)


    End Sub

    Public Sub FillData(strDataName)
        Dim bFoundWorksheet As Boolean = False
        Dim tempWorkSheet
        Dim dfDataset As DataFrame

        dfDataset = clsRInterface.GetData(strDataName)
        For Each tempWorkSheet In frmEditor.grdData.Worksheets
            If tempWorkSheet.Name = strDataName Then
                tempWorkSheet.Rows = dfDataset.RowCount
                tempWorkSheet.Columns = dfDataset.ColumnCount
                For i As Integer = 0 To dfDataset.RowCount - 1
                    For k As Integer = 0 To dfDataset.ColumnCount - 1
                        tempWorkSheet.ColumnHeaders(k).Text = dfDataset.ColumnNames(k)
                        tempWorkSheet(row:=i, col:=k) = dfDataset(i, k)
                    Next
                Next
                bFoundWorksheet = True
            End If
        Next
        If Not bFoundWorksheet Then
            tempWorkSheet = frmEditor.grdData.Worksheets.Create(strDataName)
            tempWorkSheet.Rows = dfDataset.RowCount
            tempWorkSheet.Columns = dfDataset.ColumnCount
            For i As Integer = 0 To dfDataset.RowCount - 1
                For k As Integer = 0 To dfDataset.ColumnCount - 1
                    tempWorkSheet.ColumnHeaders(k).Text = dfDataset.ColumnNames(k)
                    tempWorkSheet(row:=i, col:=k) = dfDataset(i, k)
                Next
            Next
            frmEditor.grdData.Worksheets.Add(tempWorkSheet)
        End If
    End Sub

    Private Sub DescribeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescribeToolStripMenuItem.Click
        dlgDescriptiveStatistics.ShowDialog()
    End Sub

    Private Sub SortToolStripMenuItem_Click(sender As Object, e As EventArgs)
        dlgSort.ShowDialog()
    End Sub

    Private Sub mnuSriptLog_Click(sender As Object, e As EventArgs)
        frmLog.ShowDialog()
    End Sub

    Private Sub KiswahiliToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KiswahiliToolStripMenuItem1.Click
        Thread.CurrentThread.CurrentCulture = New CultureInfo("sw-KE")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("sw-KE")
        autoTranslate(Me)
    End Sub

    Private Sub ProbabilityPlotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuGraphicsProbabilityPlot.Click
        dlgProbabilityPlot.ShowDialog()
    End Sub

    Private Sub FrenchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FrenchToolStripMenuItem.Click
        Thread.CurrentThread.CurrentCulture = New CultureInfo("fr-FR")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("fr-FR")
        autoTranslate(Me)
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnglishToolStripMenuItem.Click
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
        autoTranslate(Me)
    End Sub

    Private Sub mnuFileNewWorksheet_Click(sender As Object, e As EventArgs) Handles mnuFileNewWorksheet.Click
        dlgFileNew.ShowDialog()
    End Sub

    Private Sub LogWindowMenu_Click(sender As Object, e As EventArgs) Handles LogWindowMenu.Click
        If frmLog.Visible = True Then
            frmLog.Visible = False
        Else
            frmLog.Visible = True
        End If
    End Sub

    Private Sub StartOfTheRainsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartOfTheRainsToolStripMenuItem.Click
        dlgStartofRains.ShowDialog()
    End Sub

    Private Sub RegularSequenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegularSequenceToolStripMenuItem.Click
        dlgRegularSequence.ShowDialog()
    End Sub

    Private Sub mnuCalculations_Click(sender As Object, e As EventArgs) Handles mnuCalculations.Click
        dlgCalculator.ShowDialog()
    End Sub

    Private Sub mnuBoxPlot_Click(sender As Object, e As EventArgs) Handles mnuBoxPlot.Click
        dlgBoxplot.ShowDialog()
    End Sub

    Private Sub mnuEndofRains_Click(sender As Object, e As EventArgs) Handles mnuEndofRains.Click
        dlgEndofRains.ShowDialog()
    End Sub

    Private Sub mnuGraphicsInventory_Click(sender As Object, e As EventArgs) Handles mnuGraphicsInventory.Click
        dlgInventoryPlot.ShowDialog()
    End Sub

    Private Sub mnuStatisticsRegressionMultiple_Click(sender As Object, e As EventArgs) Handles mnuStatisticsRegressionMultiple.Click
        dlgMultipleRegression.ShowDialog()
    End Sub

    Private Sub mnuGraphicsPlot_Click(sender As Object, e As EventArgs) Handles mnuGraphicsPlot.Click
        dlgPlot.ShowDialog()
    End Sub

    Private Sub mnuGraphicsHistogram_Click(sender As Object, e As EventArgs) Handles mnuGraphicsHistogram.Click
        dlgHistogram.ShowDialog()
    End Sub

    Private Sub StemAndLeafToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StemAndLeafToolStripMenuItem.Click
        dlgStemAndLeaf.ShowDialog()
    End Sub

    Private Sub mnuGraphisDotPlot_Click(sender As Object, e As EventArgs) Handles mnuGraphisDotPlot.Click
        dlgDotPlot.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsClipBoxPlot_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsClipBoxPlot.Click
        dlgCliBoxplot.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsCliplot_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsCliplot.Click
        dlgCliPlot.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsMissingValues_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsMissingValues.Click
        dlgMissingValuesplot.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsHistogram_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsHistogram.Click
        dlgHistogramMethod.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsCumExceedance_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsCumExceedance.Click
        dlgCumulativeExceedance.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsBoxplot_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsBoxplot.Click
        dlgBoxplotMethod.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsInventory_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsInventory.Click
        dlgInventoryMethod.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsAnnualRainfall_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsAnnualRainfall.Click
        dlgAnnualRaintotal.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsTimeseries_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsTimeseries.Click
        dlgTimeseriesPlot.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsWindrose_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsWindrose.Click
        dlgWindrosePlot.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsMultipleLines_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsMultipleLines.Click
        dlgLines.ShowDialog()
    End Sub

    Private Sub mnuClimateMethodsGraphicsRainCount_Click(sender As Object, e As EventArgs) Handles mnuClimateMethodsGraphicsRainCount.Click
        dlgYearRaincount.ShowDialog()
    End Sub

    Private Sub mnuWindowMetadata_Click(sender As Object, e As EventArgs)
        frmMetaData.Show()
    End Sub

    Private Sub mnuWindowVariables_Click(sender As Object, e As EventArgs)
        frmVariables.Show()
    End Sub

    Private Sub mnuManageWorksheetInformation_Click(sender As Object, e As EventArgs) Handles mnuManageWorksheetInformation.Click
        If frmVariables.Visible = True Then
            frmVariables.Visible = False
        Else
            frmVariables.Visible = True
        End If
    End Sub

    Private Sub mnuManageLogWindow_Click(sender As Object, e As EventArgs) Handles mnuManageLogWindow.Click
        If frmLog.Visible = True Then
            frmLog.Visible = False
        Else
            frmLog.Visible = True
        End If
    End Sub

    Private Sub mnuManageScriptWindow_Click(sender As Object, e As EventArgs) Handles mnuManageScriptWindow.Click
        If frmScript.Visible = True Then
            frmScript.Visible = False
        Else
            frmScript.Visible = True
        End If
    End Sub

    Private Sub mnuManageWorksheetMetadata_Click(sender As Object, e As EventArgs) Handles mnuManageWorksheetMetadata.Click
        If frmMetaData.Visible = True Then
            frmMetaData.Visible = False
        Else
            frmMetaData.Visible = True
        End If
    End Sub

    Private Sub mnuClmateMethodThreeSummaries_Click(sender As Object, e As EventArgs) Handles mnuClmateMethodThreeSummaries.Click
        dlgThreeSummaries.ShowDialog()
    End Sub

    Private Sub StartOfRainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartOfRainToolStripMenuItem.Click
        dlgAddStartRain.ShowDialog()
    End Sub

    Private Sub EndOfRainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EndOfRainToolStripMenuItem.Click
        dlgEndRain.ShowDialog()
    End Sub

    Private Sub ChangeFormatDayMonthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeFormatDayMonthToolStripMenuItem.Click
        dlgChangeFormatDayMonth.ShowDialog()
    End Sub

    Private Sub ExportCPTToTabularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportCPTToTabularToolStripMenuItem.Click
        dlgCPTtoTabularData.ShowDialog()
    End Sub

    Private Sub DayMonthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DayMonthToolStripMenuItem.Click
        dlgDayMonth.ShowDialog()

    End Sub

    Private Sub DisplayDailyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DisplayDailyToolStripMenuItem1.Click
        dlgDisplayDaily.ShowDialog()
    End Sub

    Private Sub DisplayDOYOfYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayDOYOfYearToolStripMenuItem.Click
        dlgDisplayDOYofYear.ShowDialog()
    End Sub

    Private Sub DisplayRainRunningTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayRainRunningTotalToolStripMenuItem.Click
        dlgDisplayRainRunningTotal.ShowDialog()
    End Sub

    Private Sub DisplaySpellLengthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplaySpellLengthToolStripMenuItem.Click
        dlgDisplaySpellLength.ShowDialog()
    End Sub

    Private Sub ExportForPICSAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportForPICSAToolStripMenuItem.Click
        dlgExportforPICSA.ShowDialog()
    End Sub

    Private Sub ExtremeEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtremeEventsToolStripMenuItem.Click
        dlgExtremeEvents.ShowDialog()
    End Sub

    Private Sub MissingDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MissingDataToolStripMenuItem.Click
        dlgMissingData.ShowDialog()
    End Sub

    Private Sub MissingDataTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MissingDataTableToolStripMenuItem.Click
        dlgMissingDataTable.ShowDialog()
    End Sub

    Private Sub MonthlySummariesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlySummariesToolStripMenuItem.Click
        dlgMonthlySummaries.ShowDialog()
    End Sub

    Private Sub OutputForCDTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutputForCDTToolStripMenuItem.Click
        dlgOutputforCDT.ShowDialog()
    End Sub

    Private Sub OutputForCPTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutputForCPTToolStripMenuItem.Click
        dlgOutputforCPT.ShowDialog()
    End Sub

    Private Sub RainsStatisticsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RainsStatisticsToolStripMenuItem.Click
        dlgRainStats.ShowDialog()
    End Sub

    Private Sub SeasonalSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeasonalSummaryToolStripMenuItem.Click
        dlgSeasonalSummary.ShowDialog()
    End Sub

    Private Sub SeasonalSummaryRainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeasonalSummaryRainToolStripMenuItem.Click
        dlgSeasonalSummaryRain.ShowDialog()
    End Sub

    Private Sub mnuStatsNonParametricOneWayAnova_Click(sender As Object, e As EventArgs) Handles mnuStatsNonParametricOneWayAnova.Click
        'dlgOneWayAnova.ShowDialog()
    End Sub

    Private Sub mnuStatsNonParametricTwoWayAnova_Click(sender As Object, e As EventArgs)
        dlgTwoWayAnova.ShowDialog()
    End Sub

    Private Sub mnuStatsSummaryColumnStat_Click(sender As Object, e As EventArgs) Handles mnuStatsSummaryColumnStat.Click
        dlgColumnStats.ShowDialog()
    End Sub

    Private Sub mnuManageManipulateRowStat_Click(sender As Object, e As EventArgs) Handles mnuManageManipulateRowStat.Click
        dlgRowStats.ShowDialog()
    End Sub

    Private Sub mnuGraphicsScatterplot_Click(sender As Object, e As EventArgs) Handles mnuGraphicsScatterplot.Click
        dlgScatterPlot.ShowDialog()
    End Sub

    Private Sub mnuStatsRegressionSimple_Click(sender As Object, e As EventArgs) Handles mnuStatsRegressionSimple.Click
        dlgRegressionSimple.ShowDialog()
    End Sub

    Private Sub mnuManageDataSort_Click(sender As Object, e As EventArgs) Handles mnuManageDataSort.Click
        dlgSort.ShowDialog()
    End Sub
    Public Function OpenDialog() As KeyValuePair(Of String, String)
        Dim dlgOpen As New OpenFileDialog
        Dim strFilePath, strFileName As String
        dlgOpen.Filter = "Comma Separated (*.csv)|*.csv"
        dlgOpen.Title = "Import a .csv file into"
        If dlgOpen.ShowDialog() = DialogResult.OK Then
            'checks if the file name is not blank'
            If dlgOpen.FileName <> "" Then
                strFileName = Path.GetFileNameWithoutExtension(dlgOpen.FileName)
                strFilePath = Replace(dlgOpen.FileName, "\", "/")
                Return New KeyValuePair(Of String, String)(strFileName, Chr(34) & strFilePath & Chr(34))
            End If
        Else
            MsgBox("No File was selected!", vbInformation, "Message From Instat")
        End If
    End Function

    Private Sub mnuEditFont_Click(sender As Object, e As EventArgs) Handles mnuEditFont.Click
        'dlgFont.ShowDialog()
    End Sub

    Private Sub mnuEditReplace_Click(sender As Object, e As EventArgs) Handles mnuEditReplace.Click
        dlgReplace.ShowDialog()
    End Sub

    Private Sub OneSampleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OneSampleToolStripMenuItem.Click
        dlgOneSample.ShowDialog()
    End Sub

    Private Sub FrequencyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FrequencyToolStripMenuItem.Click
        dlgFreqTables.ShowDialog()
    End Sub

    Private Sub SummaryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SummaryToolStripMenuItem1.Click
        dlgSummaryTables.ShowDialog()
    End Sub

    Private Sub GammaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GammaToolStripMenuItem.Click
        dlgGammaDistr.ShowDialog()
    End Sub

    Private Sub DuplicatecopyColumnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicatecopyColumnsToolStripMenuItem.Click
        dlgDuplicateColumns.ShowDialog()
    End Sub

    Private Sub TransformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransformToolStripMenuItem.Click
        dlgTransform.ShowDialog()
    End Sub

    Private Sub InteractionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InteractionsToolStripMenuItem.Click
        dlgIndicatorVariable.ShowDialog()
    End Sub

    Private Sub PolynomialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PolynomialsToolStripMenuItem.Click
        dlgPolynomials.ShowDialog()
    End Sub

    Private Sub ExtremaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtremaToolStripMenuItem.Click
        dlgExtremes.ShowDialog()
    End Sub

    Private Sub StacksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StacksToolStripMenuItem.Click
        dlgStack.ShowDialog()
    End Sub

    Private Sub UnstackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnstackToolStripMenuItem.Click
        dlgUnstack.ShowDialog()
    End Sub

    Private Sub ChisquareTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChisquareTestToolStripMenuItem.Click
        dlgChiSquareTest.ShowDialog()
    End Sub

    Private Sub RecodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecodeToolStripMenuItem.Click
        dlgRecode.ShowDialog()
    End Sub

    Private Sub EnterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnterToolStripMenuItem.Click
        dlgChangeType.ShowDialog()
    End Sub

    Private Sub RandomSamplesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RandomSamplesToolStripMenuItem.Click
        dlgRandomSample.ShowDialog()
    End Sub

    Private Sub DisplayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayToolStripMenuItem.Click
        dlgDisplay.ShowDialog()
    End Sub

    Private Sub ClearRemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearRemoveToolStripMenuItem.Click
        dlgDeleteColumns.ShowDialog()
    End Sub

    Private Sub SelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectToolStripMenuItem.Click
        dlgSelect.ShowDialog()
    End Sub

    Private Sub SelectSndStackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectSndStackToolStripMenuItem.Click
        dlgSelectAndStuck.ShowDialog()
    End Sub

    Private Sub ExpandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpandToolStripMenuItem.Click
        dlgExpand.ShowDialog()
    End Sub

    Private Sub FactorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FactorToolStripMenuItem.Click
        dlgfactor.ShowDialog()
    End Sub

    Private Sub NameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NameToolStripMenuItem.Click
        dlgName.ShowDialog()
    End Sub

    Private Sub FormatCtrlDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatCtrlDToolStripMenuItem.Click
        dlgFormat.ShowDialog()
    End Sub

    Private Sub AlignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlignmentToolStripMenuItem.Click
        dlgAlignment.ShowDialog()
    End Sub

    Private Sub IndicatorVariablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndicatorVariablesToolStripMenuItem.Click
        dlgIndicatorVariable.ShowDialog()
    End Sub

    Private Sub FactorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FactorToolStripMenuItem1.Click
        dlgfactor.ShowDialog()
    End Sub

    Private Sub DeleteRowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowsToolStripMenuItem.Click
        dlgDeleteRows.ShowDialog()
    End Sub

    Private Sub OrthogonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrthogonalToolStripMenuItem.Click
        dlgOrthogonal.ShowDialog()
    End Sub

    Private Sub GeneralToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GeneralToolStripMenuItem1.Click
        dlgGeneral.ShowDialog()
    End Sub

    Private Sub BivariateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BivariateToolStripMenuItem.Click
        dlgBivariateANOVA.ShowDialog()
    End Sub

    Private Sub OnewayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnewayToolStripMenuItem.Click
        'dlgOneWayAnova.ShowDialog()
    End Sub

    Private Sub SimpleWithGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpleWithGroupsToolStripMenuItem.Click
        dlgSimpleWithGroups.ShowDialog()
    End Sub

    Private Sub GeneralLinearModelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralLinearModelToolStripMenuItem.Click
        dlgGeneralisedLinearModels.ShowDialog()
    End Sub

    Private Sub CorrelationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrelationToolStripMenuItem.Click
        dlgCorrelation.ShowDialog()
    End Sub

    Private Sub LogLinearModelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogLinearModelsToolStripMenuItem.Click
        dlglogLinearModels.ShowDialog()
    End Sub

    Private Sub OneAndTwoSamplesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OneAndTwoSamplesToolStripMenuItem.Click
        dlgNon_ParemetricOneandTwoSampleTests.ShowDialog()
    End Sub

    Private Sub mnuStatsNonParametricTwoWayAnova_Click_1(sender As Object, e As EventArgs) Handles mnuStatsNonParametricTwoWayAnova.Click
        dlgTwoWayAnova.ShowDialog()
    End Sub

    Private Sub CorrelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrelationsToolStripMenuItem.Click
        dlgCorrelation.ShowDialog()
    End Sub

    Private Sub NewWorksheetToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewWorksheetToolStripMenuItem1.Click
        dlgNewWorksheet.ShowDialog()
    End Sub

    Private Sub ImportDailyDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDailyDataToolStripMenuItem.Click

    End Sub

    Private Sub MakeFactorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MakeFactorToolStripMenuItem.Click
        dlgMakeFactor.ShowDialog()
    End Sub

    Private Sub ShiftDailyDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShiftDailyDataToolStripMenuItem.Click
        dlgShiftDailyData.ShowDialog()
    End Sub

    Private Sub UnstackDailyDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnstackDailyDataToolStripMenuItem.Click
        dlgUnstackDailyData.ShowDialog()
    End Sub

    Private Sub StackDailyDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StackDailyDataToolStripMenuItem.Click
        dlgStackDailyData.ShowDialog()
    End Sub

    Private Sub InterpolateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpolateToolStripMenuItem.Click
        dlgInterpolate.ShowDialog()
    End Sub

    Private Sub OptionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem1.Click
        dlgOptions.ShowDialog()
    End Sub

    Private Sub DisplayDailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayDailyToolStripMenuItem.Click
        dlgDisplayDaily.ShowDialog()
    End Sub

    Private Sub SummaryToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SummaryToolStripMenuItem2.Click
        dlgSummary.ShowDialog()
    End Sub

    Private Sub ExtremesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtremesToolStripMenuItem.Click
        dlgExtremes.ShowDialog()
    End Sub

    Private Sub SpellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellsToolStripMenuItem.Click
        dlgSpells.ShowDialog()
    End Sub

    Private Sub WaterBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WaterBalanceToolStripMenuItem.Click
        dlgWaterBalance.ShowDialog()
    End Sub

    Private Sub ExamineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExamineToolStripMenuItem.Click
        dlgExamine.ShowDialog()
    End Sub

    Private Sub ProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessToolStripMenuItem.Click
        dlgProcess.ShowDialog()
    End Sub

    Private Sub SiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SiteToolStripMenuItem.Click
        dlgSite.ShowDialog()
    End Sub

    Private Sub PenmanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenmanToolStripMenuItem.Click
        dlgPenman.ShowDialog()
    End Sub

    Private Sub CropCoefficientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CropCoefficientsToolStripMenuItem.Click
        dlgCropCoefficients.ShowDialog()
    End Sub

    Private Sub WaterSatisfactionIndexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WaterSatisfactionIndexToolStripMenuItem.Click
        dlgWaterSatisfactionIndex.ShowDialog()
    End Sub

    Private Sub HeatSumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeatSumToolStripMenuItem.Click
        dlgHeatSum.ShowDialog()
    End Sub

    Private Sub CountsTotalsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountsTotalsToolStripMenuItem.Click
        dlgCountsTotals.ShowDialog()
    End Sub

    Private Sub PrepareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrepareToolStripMenuItem.Click
        dlgPrepare.ShowDialog()
    End Sub

    Private Sub ModelProbabilitiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModelProbabilitiesToolStripMenuItem.Click
        dlgModelProbabilities.ShowDialog()
    End Sub

    Private Sub ModelAmountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModelAmountsToolStripMenuItem.Click
        dlgModelAmounts.ShowDialog()
    End Sub

    Private Sub InterpolateDailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterpolateDailyToolStripMenuItem.Click
        dlgInterpolateDaily.ShowDialog()
    End Sub

    Private Sub SimulationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimulationsToolStripMenuItem.Click

    End Sub

    Private Sub SpellLengthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellLengthToolStripMenuItem.Click
        dlgSpellLength.ShowDialog()
    End Sub

    Private Sub TotalsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalsToolStripMenuItem.Click
        dlgTotals.ShowDialog()
    End Sub

    Private Sub PoissonOneSampleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PoissonOneSampleToolStripMenuItem.Click
        dlgTwoSamples.ShowDialog()
    End Sub

    Private Sub mnuFIleExit_Click(sender As Object, e As EventArgs) Handles mnuFIleExit.Click
        Me.Close()
    End Sub

    Private Sub mnuFileOpenWorksheet_Click(sender As Object, e As EventArgs) Handles mnuFileOpenWorksheet.Click
        OpenFile.ShowDialog()
    End Sub

    Private Sub mnuFileSaveAs_Click(sender As Object, e As EventArgs) Handles mnuFileSaveAs.Click
        Dim kvpFile As KeyValuePair(Of String, String)
        kvpFile = SaveDialog()
        clsButton.clsRsyntax.SetFunction("saveRDS")
        clsButton.clsRsyntax.AddParameter("object", "InstatDataObject")
        clsButton.clsRsyntax.AddParameter("file", kvpFile.Value)
        clsRInterface.RunScript(clsButton.clsRsyntax.GetScript())
    End Sub

    Public Function SaveDialog() As KeyValuePair(Of String, String)
        Dim dlgOpen As New SaveFileDialog
        Dim strFilePath, strFileName As String
        dlgOpen.Filter = "RDS (*.RDS)|*.RDS"
        dlgOpen.Title = "Save workbook as RDS file"
        If dlgOpen.ShowDialog() = DialogResult.OK Then
            'checks if the file name is not blank'
            If dlgOpen.FileName <> "" Then
                strFileName = Path.GetFileNameWithoutExtension(dlgOpen.FileName)
                strFilePath = Replace(dlgOpen.FileName, "\", "/")
                Return New KeyValuePair(Of String, String)(strFileName, Chr(34) & strFilePath & Chr(34))
            End If
        Else
            MsgBox("No File was selected!", vbInformation, "Message From Instat")
        End If
    End Function

    Private Sub mnuFileCloseWorksheet_Click(sender As Object, e As EventArgs) Handles mnuFileCloseWorksheet.Click

    End Sub

    Private Sub mnuFileOpenFromLibrary_Click(sender As Object, e As EventArgs) Handles mnuFileOpenFromLibrary.Click
        Dim kvpFile As KeyValuePair(Of String, String)
        kvpFile = OpenDialog()
        clsButton.clsRsyntax.SetFunction("read.csv")
        clsButton.clsRsyntax.AddParameter("file", kvpFile.Value)
        clsRInterface.LoadData(kvpFile.Key, clsButton.clsRsyntax.GetScript())
        clsRInterface.FillDataObjectVariables(frmVariables.grdVariables)
        clsRInterface.FillDataObjectMetadata(frmMetaData.grdMetaData)
        clsRInterface.FillDataObjectData(frmEditor.grdData)
    End Sub

End Class