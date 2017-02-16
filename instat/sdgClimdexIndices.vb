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
Imports instat
Imports instat.Translations
Public Class sdgClimdexIndices
    Public bSaveIndex As Boolean = False
    Public bControlsInitialised As Boolean = False
    Public clsNewClimdexInput, clsRWriteDf As New RFunction
    Public clsRMaxMisingDays, clsROneArg, clsRTwoArg1, clsRTwoArg2, clsRTwoArg3, clsRTwoArg4, clsRTwoArg5, clsRThreeArg As New RFunction

    Private Sub sdgClimdexIndices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
    End Sub

    Public Sub InitialiseControls()
        Dim dctInputFreqPairs As New Dictionary(Of String, String)
        clsRMaxMisingDays.SetRCommand("c")
        ucrChkFrostDays.Checked = True
        ucrChkFrostDays.SetText("Frost Days")
        ucrChkFrostDays.Tag = "Frost_Days"
        ucrChkFrostDays.bChangeParameterValue = False
        ucrChkSummerDays.Checked = False
        ucrChkSummerDays.SetText("Summer Days")
        ucrChkSummerDays.Tag = "Summer_Days"
        ucrChkSummerDays.bChangeParameterValue = False
        ucrChkIcingDays.Checked = False
        ucrChkIcingDays.SetText("Icing Days")
        ucrChkIcingDays.Tag = "Icing_Days"
        ucrChkIcingDays.bChangeParameterValue = False
        ucrChkTropicalNights.Checked = False
        ucrChkTropicalNights.SetText("Tropical Nights")
        ucrChkTropicalNights.Tag = "Tropical_Nights"
        ucrChkTropicalNights.bChangeParameterValue = False
        ucrChkGrowingSeasonLength.Checked = False
        ucrChkGrowingSeasonLength.SetText("Growing Season Length")
        ucrChkGrowingSeasonLength.Tag = "Growing_Season_Length"
        ucrChkGrowingSeasonLength.bChangeParameterValue = False
        ucrChkMonthlyMaxDailyTMax.Checked = False
        ucrChkMonthlyMaxDailyTMax.SetText("Monthly Maximum of Daily Maximum Temperature")
        ucrChkMonthlyMaxDailyTMax.Tag = "Monthly_Maximum_of_Daily_Maximum_Temperature"
        ucrChkMonthlyMaxDailyTMax.bChangeParameterValue = False
        ucrChkMonthlyMaxDailyTMin.Checked = False
        ucrChkMonthlyMaxDailyTMin.SetText("Monthly Maximum of Daily Minimum Temperature")
        ucrChkMonthlyMaxDailyTMin.Tag = "Monthly_Maximum_of_Daily_Minimum_Temperature"
        ucrChkMonthlyMaxDailyTMin.bChangeParameterValue = False
        ucrChkMonthlyMinDailyTMax.Checked = False
        ucrChkMonthlyMinDailyTMax.SetText("Monthly Minimum of Daily Maximum Temperature")
        ucrChkMonthlyMinDailyTMax.Tag = "Monthly_Minimum_of_Daily_Maximum_Temperature"
        ucrChkMonthlyMinDailyTMax.bChangeParameterValue = False
        ucrChkMonthlyMinDailyTMin.Checked = False
        ucrChkMonthlyMinDailyTMin.SetText("Monthly Minimum of Daily Minimum Temperature")
        ucrChkMonthlyMinDailyTMin.Tag = "Monthly_Minimum_of_Daily_Minimum_Temperature"
        ucrChkMonthlyMinDailyTMin.bChangeParameterValue = False
        ucrChkTminBelow10Percent.Checked = False
        ucrChkTminBelow10Percent.SetText("Percentage of Days When Tmin is Below 10th Percentile")
        ucrChkTminBelow10Percent.Tag = "Percentage_of_Days_When_Tmin_is_Below_10th_Percentile"
        ucrChkTminBelow10Percent.bChangeParameterValue = False
        ucrChkTmaxBelow10Percent.Checked = False
        ucrChkTmaxBelow10Percent.SetText("Percentage of Days When Tmax is Below 10th Percentile")
        ucrChkTmaxBelow10Percent.Tag = "Percentage_of_Days_When_Tmax_is_Below_10th_Percentile"
        ucrChkTmaxBelow10Percent.bChangeParameterValue = False
        ucrChkTminAbove90Percent.Checked = False
        ucrChkTminAbove90Percent.SetText("Percentage of Days When Tmin is Above 90th Percentile")
        ucrChkTminAbove90Percent.Tag = "Percentage_of_Days_When_Tmin_is_Above_90th_Percentile"
        ucrChkTminAbove90Percent.bChangeParameterValue = False
        ucrChkTmaxAbove90Percent.Checked = False
        ucrChkTmaxAbove90Percent.SetText("Percentage of Days When Tmax is Above 90th Percentile")
        ucrChkTmaxAbove90Percent.Tag = "Percentage_of_Days_When_Tmax_is_Above_90th_Percentile"
        ucrChkTmaxAbove90Percent.bChangeParameterValue = False
        ucrChkWarmSpellDI.Checked = False
        ucrChkWarmSpellDI.SetText("Warm Spell Duration Index")
        ucrChkWarmSpellDI.Tag = "Warm_Spell_Duration_Index"
        ucrChkWarmSpellDI.bChangeParameterValue = False
        ucrChkColdSpellDI.Checked = False
        ucrChkColdSpellDI.SetText("Cold Spell Duration Index")
        ucrChkColdSpellDI.Tag = "Cold_Spell_Duration_Index"
        ucrChkColdSpellDI.bChangeParameterValue = False
        ucrChkMeanDiurnalTempRange.Checked = False
        ucrChkMeanDiurnalTempRange.SetText("Mean Diurnal Temperature Range")
        ucrChkMeanDiurnalTempRange.Tag = "Mean_Diurnal_Temperature_Range"
        ucrChkMeanDiurnalTempRange.bChangeParameterValue = False
        ucrChkMonthlyMax1dayPrec.Checked = False
        ucrChkMonthlyMax1dayPrec.SetText("Monthly Maximum 1-day Precipitation")
        ucrChkMonthlyMax1dayPrec.Tag = "Monthly_Maximum_1day_Precipitation"
        ucrChkMonthlyMax1dayPrec.bChangeParameterValue = False
        ucrChkMonthlyMax5dayPrec.Checked = False
        ucrChkMonthlyMax5dayPrec.SetText("Monthly Maximum Consecutive 5-day Precipitation")
        ucrChkMonthlyMax5dayPrec.Tag = "Monthly_Maximum_Consecutive_5day_Precipitation"
        ucrChkMonthlyMax5dayPrec.bChangeParameterValue = False
        ucrChkSimplePrecII.Checked = False
        ucrChkSimplePrecII.SetText("Simple Precipitation Intensity Index")
        ucrChkSimplePrecII.Tag = "Simple_Precipitation_Intensity_Index"
        ucrChkSimplePrecII.bChangeParameterValue = False
        ucrChkPrecExceed10mm.Checked = False
        ucrChkPrecExceed10mm.SetText("Precipitation Exceeding 10mm Per Day")
        ucrChkPrecExceed10mm.Tag = "Precipitation_Exceeding_10mm_Per_Day"
        ucrChkPrecExceed10mm.bChangeParameterValue = False
        ucrChkPrecExceed20mm.Checked = False
        ucrChkPrecExceed20mm.SetText("Precipitation Exceeding 20mm Per Day")
        ucrChkPrecExceed20mm.Tag = "Precipitation_Exceeding_20mm_Per_Day"
        ucrChkPrecExceed20mm.bChangeParameterValue = False
        ucrChkPrecExceedSpecifiedA.Checked = False
        ucrChkPrecExceedSpecifiedA.SetText("Precipitation Exceeding a Specified Amount Per Day")
        ucrChkPrecExceedSpecifiedA.Tag = "Precipitation_Exceeding_a_Specified_Amount_Per_Day"
        ucrChkPrecExceedSpecifiedA.bChangeParameterValue = False
        ucrChkMaxDrySpell.Checked = False
        ucrChkMaxDrySpell.SetText("Maximum Length of Dry Spell")
        ucrChkMaxDrySpell.Tag = "Maximum_Length_of_Dry_Spell"
        ucrChkMaxDrySpell.bChangeParameterValue = False
        ucrChkMaxWetSpell.Checked = False
        ucrChkMaxWetSpell.SetText("Maximum Length of Wet Spell")
        ucrChkMaxWetSpell.Tag = "Maximum_Length_of_Wet_Spell"
        ucrChkMaxWetSpell.bChangeParameterValue = False
        ucrChkPrecExceed95Percent.Checked = False
        ucrChkPrecExceed95Percent.SetText("Total Daily Precipitation Exceeding 95th Percentile Threshold")
        ucrChkPrecExceed95Percent.Tag = "Total_Daily_Precipitation_Exceeding_95th_Percentile_Threshold"
        ucrChkPrecExceed95Percent.bChangeParameterValue = False
        ucrChkPrecExceed99Percent.Checked = False
        ucrChkPrecExceed99Percent.SetText("Total Daily Precipitation Exceeding 99th Percentile Threshold")
        ucrChkPrecExceed99Percent.Tag = "Total_Daily_Precipitation_Exceeding_99th_Percentile_Threshold"
        ucrChkPrecExceed99Percent.bChangeParameterValue = False
        ucrChkTotalDailyPrec.Checked = False
        ucrChkTotalDailyPrec.SetText("Total Daily Precipitation")
        ucrChkTotalDailyPrec.Tag = "Total_Daily_Precipitation"

        ucrChkTotalDailyPrec.bChangeParameterValue = False

        ucrNudThreshold.SetParameter(New RParameter("threshold"))
        ucrNudThreshold.SetRDefault(1)
        ucrNudThreshold.DecimalPlaces = 2
        ucrNudThreshold.SetMinMax(0, 1)
        ucrNudThreshold.Increment = 0.01
        ucrNudN.SetParameter(New RParameter("n"))
        ucrNudN.SetRDefault(5)
        ucrNudN.SetMinMax(1, 100)

        ucrNudMinBaseData.SetParameter(New RParameter("min.base.data.fraction.present"))
        ucrNudMinBaseData.SetRDefault(0.1)
        ucrNudMinBaseData.DecimalPlaces = 2
        ucrNudMinBaseData.SetMinMax(0, 1)
        ucrNudMinBaseData.Increment = 0.01

        ucrNudAnnualMissingDays.SetParameter(New RParameter("annual"))
        ucrNudAnnualMissingDays.SetRDefault(15)
        ucrNudAnnualMissingDays.SetMinMax(1, 366)

        ucrNudMothlyMissingDays.SetParameter(New RParameter("monthly"))
        ucrNudMothlyMissingDays.SetRDefault(3)
        ucrNudMothlyMissingDays.SetMinMax(1, 31)

        clsNewClimdexInput.AddParameter("max.missing.days", clsRFunctionParameter:=clsRMaxMisingDays)
        ucrInputFreq.SetParameter(New RParameter("freq"))
        dctInputFreqPairs.Add("annual", Chr(34) & "annual" & Chr(34))
        dctInputFreqPairs.Add("monthly", Chr(34) & "monthly" & Chr(34))
        ucrInputFreq.SetItems(dctInputFreqPairs)
        ucrInputFreq.cboInput.SelectedItem = "annual"

        ucrMultipleInputTempQtiles.SetParameter(New RParameter("temp.qtiles"))
        ucrMultipleInputTempQtiles.bIsNumericInput = True
        ucrMultipleInputTempQtiles.txtNumericItems.Text = "0.1, 0.9"
        ucrMultipleInputTempQtiles.SetRDefault("0.1, 0.9")

        ucrMultipleInputPrecQtiles.SetParameter(New RParameter("prec.qtiles"))
        ucrMultipleInputPrecQtiles.bIsNumericInput = True
        ucrMultipleInputPrecQtiles.txtNumericItems.Text = "0.95, 0.99"
        ucrMultipleInputPrecQtiles.SetRDefault("0.95, 0.99")

        ucrMultipleInputBaseRange.SetParameter(New RParameter("base.range"))
        ucrMultipleInputBaseRange.bIsNumericInput = True
        ucrMultipleInputBaseRange.txtNumericItems.Text = "1961, 1990"
        ucrMultipleInputBaseRange.SetRDefault("1961, 1990")
        ucrChkNHemisphere.SetText("Northern Hemisphere")
        ucrChkNHemisphere.SetParameter(New RParameter("northern.hemisphere"), bNewChangeParameterValue:=True, bNewAddRemoveParameter:=True, strNewValueIfChecked:="TRUE", strNewValueIfUnchecked:="FALSE")
        ucrChkNHemisphere.SetRDefault("TRUE")

        ucrChkCenterMean.SetText("Center Mean on Last Day")
        ucrChkCenterMean.SetParameter(New RParameter("center.mean.on.last.day"), bNewChangeParameterValue:=True, bNewAddRemoveParameter:=True, strNewValueIfChecked:="TRUE", strNewValueIfUnchecked:="FALSE")
        ucrChkCenterMean.SetRDefault("FALSE")

        ucrChkMaxSpellSpanYears.SetText("Maximum Spell Length Span Years")
        ucrChkMaxSpellSpanYears.SetParameter(New RParameter("spells.can.span.years"), bNewChangeParameterValue:=True, bNewAddRemoveParameter:=True, strNewValueIfChecked:="TRUE", strNewValueIfUnchecked:="FALSE")
        ucrChkMaxSpellSpanYears.SetRDefault("TRUE")

        ucrChkSpellDISpanYear.SetText("Spell Duration Index Span Years")
        ucrChkSpellDISpanYear.SetParameter(New RParameter("spells.can.span.years"), bNewChangeParameterValue:=True, bNewAddRemoveParameter:=True, strNewValueIfChecked:="TRUE", strNewValueIfUnchecked:="FALSE")
        ucrChkSpellDISpanYear.SetRDefault("FALSE")

        ucrChkSave.Checked = False
        ucrChkSave.SetText("Save indices")
        ucrChkSave.bChangeParameterValue = False

        ttClimdexIndices.SetToolTip(ucrChkFrostDays.chkCheck, "The annual count of days where daily minimum temperature drops below 0 degrees Celsius")
        ttClimdexIndices.SetToolTip(ucrChkSummerDays.chkCheck, "The annual count of days where daily maximum temperature exceeds 25 degrees Celsius")
        ttClimdexIndices.SetToolTip(ucrChkIcingDays.chkCheck, "The annual count of days where daily maximum temperature is below 0 degrees Celsius")
        ttClimdexIndices.SetToolTip(ucrChkTropicalNights.chkCheck, "Annual count of days where daily minimum temperature stays above 20 degrees Celsius. ")
        ttClimdexIndices.SetToolTip(ucrChkGrowingSeasonLength.chkCheck, "Is the number of days between the start of the first spell of warm days in the first half of the year, and the start of the first spell of cold days in the second half of the year")
        ttClimdexIndices.SetToolTip(ucrChkMonthlyMaxDailyTMax.chkCheck, "Computes the monthly or annual maximum of daily maximum temperature")
        ttClimdexIndices.SetToolTip(ucrChkMonthlyMaxDailyTMin.chkCheck, "Computes the monthly or annual maximum of daily minimum temperature")
        ttClimdexIndices.SetToolTip(ucrChkMonthlyMinDailyTMax.chkCheck, "Computes the monthly or annual minimum of daily maximum temperature")
        ttClimdexIndices.SetToolTip(ucrChkMonthlyMinDailyTMin.chkCheck, "Computes the monthly or annual minimum of daily minimum temperature")
        ttClimdexIndices.SetToolTip(ucrChkTminBelow10Percent.chkCheck, "Computes  the monthly or annual proportion of minimum temperature below 10th percentile")
        ttClimdexIndices.SetToolTip(ucrChkTmaxBelow10Percent.chkCheck, "Computes  the monthly or annual proportion of maximum temperature below 10th percentile")
        ttClimdexIndices.SetToolTip(ucrChkTminAbove90Percent.chkCheck, "Computes  the monthly or annual proportion of minimum temperature above 90th percentile")
        ttClimdexIndices.SetToolTip(ucrChkTmaxAbove90Percent.chkCheck, "Computes  the monthly or annual proportion of maximum temperature above 90th percentile")
        ttClimdexIndices.SetToolTip(ucrChkWarmSpellDI.chkCheck, "Warm spell is defined as a sequence of 6 or more days in which the daily maximum temperature exceeds the 90th percentile of daily maximum temperature for a 5-day running window surrounding this day during the baseline period")
        ttClimdexIndices.SetToolTip(ucrChkColdSpellDI.chkCheck, "Cold spell is defined as a sequence of 6 or more days in which the daily minimum temperature is below the 10th percentile of daily minimum temperature for a 5-day running window surrounding this day during the baseline period.")
        ttClimdexIndices.SetToolTip(ucrChkMeanDiurnalTempRange.chkCheck, "Computes the mean daily diurnal temperature range. The frequency of observation can be either monthly or annual")
        ttClimdexIndices.SetToolTip(ucrChkMonthlyMax1dayPrec.chkCheck, "Computes the climdex index Rx1day: monthly or annual maximum 1-day precipitation")
        ttClimdexIndices.SetToolTip(ucrChkMonthlyMax5dayPrec.chkCheck, "Computes the monthly or annual maximum consecutive 5-day precipitation")
        ttClimdexIndices.SetToolTip(ucrChkSimplePrecII.chkCheck, "This is defined as the sum of precipitation in wet days (days with preciptitation over 1mm) during the year divided by the number of wet days in the year.")
        ttClimdexIndices.SetToolTip(ucrChkPrecExceed10mm.chkCheck, "Computes the annual count of days where daily precipitation is more than 10mm per day")
        ttClimdexIndices.SetToolTip(ucrChkPrecExceed20mm.chkCheck, "Computes the annual count of days where daily precipitation is more than 20mm per day")
        ttClimdexIndices.SetToolTip(ucrChkPrecExceedSpecifiedA.chkCheck, "Computes the climdex index Rnnmm: the annual count of days where daily precipitation is more than nn mm per day")
        ttClimdexIndices.SetToolTip(ucrChkMaxDrySpell.chkCheck, "Maximum number of days when precipitation is less than 1mm.")
        ttClimdexIndices.SetToolTip(ucrChkMaxWetSpell.chkCheck, "Maximum number of days when precipitation is greater than 1mm")
        ttClimdexIndices.SetToolTip(ucrChkPrecExceed95Percent.chkCheck, "Computes the annual sum of precipitation in days where daily precipitation exceeds the 95th percentile of daily precipitation in the base period ")
        ttClimdexIndices.SetToolTip(ucrChkPrecExceed99Percent.chkCheck, "Computes the annual sum of precipitation in days where daily precipitation exceeds the 99th percentile of daily precipitation in the base period ")
        ttClimdexIndices.SetToolTip(ucrChkTotalDailyPrec.chkCheck, "Computes the annual sum of precipitation in wet days (days where precipitation is at least 1mm). ")

        clsROneArg.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        clsRTwoArg1.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        clsRTwoArg2.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        clsRTwoArg2.AddParameter("gsl.mode", Chr(34) & "GSL" & Chr(34))
        clsRTwoArg3.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        clsRTwoArg4.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        clsRTwoArg5.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        clsRThreeArg.AddParameter("ci", clsRFunctionParameter:=dlgClimdex.clsDefaultFunction)
        bControlsInitialised = True
    End Sub

    Private Sub SaveIndices(ucrchkTemp As ucrCheck, clsIndex As RFunction, bSave As Boolean)
        Dim clsRListDF, clsRConvertDF As New RFunction
        clsRWriteDf.SetRCommand("InstatDataObject$add_climdex_indices")
        clsRListDF.SetRCommand("list")
        clsRListDF.AddParameter(ucrchkTemp.Tag, clsRFunctionParameter:=clsIndex)
        clsRWriteDf.AddParameter("indices", clsRFunctionParameter:=clsRListDF)
        If bSave Then
            frmMain.clsRLink.RunScript(clsRWriteDf.ToScript(), 0)
        Else
            frmMain.clsRLink.RunScript(clsIndex.ToScript(), 2)
        End If
    End Sub

    Public Sub IndicesOptions()
        If (ucrChkFrostDays.Checked = True) Then
            clsROneArg.SetRCommand("climdex.fd")
            SaveIndices(ucrChkFrostDays, clsROneArg, bSaveIndex)
        End If
        If (ucrChkSummerDays.Checked = True) Then
            clsROneArg.SetRCommand("climdex.su")
            SaveIndices(ucrChkSummerDays, clsROneArg, bSaveIndex)
        End If
        If (ucrChkIcingDays.Checked = True) Then
            clsROneArg.SetRCommand("climdex.id")
            SaveIndices(ucrChkIcingDays, clsROneArg, bSaveIndex)
        End If
        If (ucrChkTropicalNights.Checked = True) Then
            clsROneArg.SetRCommand("climdex.tr")
            SaveIndices(ucrChkTropicalNights, clsROneArg, bSaveIndex)
        End If
        If (ucrChkGrowingSeasonLength.Checked = True) Then
            clsRTwoArg2.SetRCommand("climdex.gsl")
            SaveIndices(ucrChkGrowingSeasonLength, clsRTwoArg2, bSaveIndex)
        End If
        If (ucrChkMonthlyMaxDailyTMax.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.txx")
            SaveIndices(ucrChkMonthlyMaxDailyTMax, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkMonthlyMaxDailyTMin.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.tnx")
            SaveIndices(ucrChkMonthlyMaxDailyTMin, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkMonthlyMinDailyTMax.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.txn")
            SaveIndices(ucrChkMonthlyMinDailyTMax, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkMonthlyMinDailyTMin.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.tnn")
            SaveIndices(ucrChkMonthlyMinDailyTMin, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkTminBelow10Percent.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.tn10p")
            SaveIndices(ucrChkTminBelow10Percent, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkTmaxBelow10Percent.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.tx10p")
            SaveIndices(ucrChkTmaxBelow10Percent, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkTminAbove90Percent.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.tn90p")
            SaveIndices(ucrChkTminAbove90Percent, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkTmaxAbove90Percent.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.tx90p")
            SaveIndices(ucrChkTmaxAbove90Percent, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkWarmSpellDI.Checked = True) Then
            clsRTwoArg5.SetRCommand("climdex.wsdi")
            SaveIndices(ucrChkWarmSpellDI, clsRTwoArg5, bSaveIndex)
        End If
        If (ucrChkColdSpellDI.Checked = True) Then
            clsRTwoArg5.SetRCommand("climdex.csdi")
            SaveIndices(ucrChkColdSpellDI, clsRTwoArg5, bSaveIndex)
        End If
        If (ucrChkMeanDiurnalTempRange.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.dtr")
            SaveIndices(ucrChkMeanDiurnalTempRange, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkMonthlyMax1dayPrec.Checked = True) Then
            clsRTwoArg1.SetRCommand("climdex.rx1day")
            SaveIndices(ucrChkMonthlyMax1dayPrec, clsRTwoArg1, bSaveIndex)
        End If
        If (ucrChkMonthlyMax5dayPrec.Checked = True) Then
            clsRThreeArg.SetRCommand("climdex.rx5day")
            SaveIndices(ucrChkMonthlyMax5dayPrec, clsRThreeArg, bSaveIndex)
        End If
        If (ucrChkSimplePrecII.Checked = True) Then
            clsROneArg.SetRCommand("climdex.sdii")
            SaveIndices(ucrChkSimplePrecII, clsROneArg, bSaveIndex)
        End If
        If (ucrChkPrecExceed10mm.Checked = True) Then
            clsROneArg.SetRCommand("climdex.r10mm")
            SaveIndices(ucrChkPrecExceed10mm, clsROneArg, bSaveIndex)
        End If
        If (ucrChkPrecExceed20mm.Checked = True) Then
            clsROneArg.SetRCommand("climdex.r20mm")
            SaveIndices(ucrChkPrecExceed20mm, clsROneArg, bSaveIndex)
        End If
        If (ucrChkPrecExceedSpecifiedA.Checked = True) Then
            clsRTwoArg3.SetRCommand("climdex.rnnmm")
            SaveIndices(ucrChkPrecExceedSpecifiedA, clsRTwoArg3, bSaveIndex)
        End If
        If (ucrChkMaxDrySpell.Checked = True) Then
            clsRTwoArg4.SetRCommand("climdex.cdd")
            SaveIndices(ucrChkMaxDrySpell, clsRTwoArg4, bSaveIndex)
        End If
        If (ucrChkMaxWetSpell.Checked = True) Then
            clsRTwoArg4.SetRCommand("climdex.cwd")
            SaveIndices(ucrChkMaxWetSpell, clsRTwoArg4, bSaveIndex)
        End If
        If (ucrChkPrecExceed95Percent.Checked = True) Then
            clsROneArg.SetRCommand("climdex.r95ptot")
            SaveIndices(ucrChkPrecExceed95Percent, clsROneArg, bSaveIndex)
        End If
        If (ucrChkPrecExceed99Percent.Checked = True) Then
            clsROneArg.SetRCommand("climdex.r99ptot")
            SaveIndices(ucrChkPrecExceed99Percent, clsROneArg, bSaveIndex)
        End If
        If (ucrChkTotalDailyPrec.Checked = True) Then
            clsROneArg.SetRCommand("climdex.prcptot")
            SaveIndices(ucrChkTotalDailyPrec, clsROneArg, bSaveIndex)
        End If
    End Sub

    'Private Sub nudYearFromTo_ValueChanged(sender As Object, e As EventArgs)
    '    dlgClimdex.clsDefaultFunction.AddParameter("base.range", "c(" & nudYearFrom.Value & "," & nudYearTo.Value & ")")
    '    If nudYearFrom.Value = 1961 AndAlso nudYearTo.Value = 1990 Then
    '        dlgClimdex.clsDefaultFunction.RemoveParameterByName("base.range")
    '    End If
    'End Sub

    'Private Sub ucrMultipleInputPrecQtiles_Leave(sender As Object, e As EventArgs) Handles ucrMultipleInputPrecQtiles.Leave
    '    If ucrMultipleInputPrecQtiles.txtNumericItems.Text <> "0.95, 0.99" Then
    '        dlgClimdex.clsDefaultFunction.AddParameter("prec.qtiles", ucrMultipleInputPrecQtiles.clsNumericList.ToScript)
    '    Else
    '        dlgClimdex.clsDefaultFunction.RemoveParameterByName("prec.qtiles")
    '    End If
    'End Sub

    'Private Sub ucrMultipleInputTempQtiles_Leave(sender As Object, e As EventArgs) Handles ucrMultipleInputTempQtiles.Leave
    '    If ucrMultipleInputTempQtiles.txtNumericItems.Text <> "0.1, 0.9" Then
    '        dlgClimdex.clsDefaultFunction.AddParameter("temp.qtiles", ucrMultipleInputTempQtiles.clsNumericList.ToScript)
    '    Else
    '        dlgClimdex.clsDefaultFunction.RemoveParameterByName("temp.qtiles")
    '    End If
    'End Sub

    'Private Sub ucrInputFreq_Leave(sender As Object, e As EventArgs) Handles ucrInputFreq.Leave
    '    Select Case ucrInputFreq.GetText
    '        Case "annual"
    '            clsRTwoArg1.AddParameter("freq", Chr(34) & "annual" & Chr(34))
    '            clsRThreeArg.AddParameter("freq", Chr(34) & "annual" & Chr(34))
    '        Case "monthly"
    '            clsRTwoArg1.AddParameter("freq", Chr(34) & "monthly" & Chr(34))
    '            clsRThreeArg.AddParameter("freq", Chr(34) & "monthly" & Chr(34))
    '    End Select
    'End Sub

    Public Sub SetRFunction(clsNewRFunction As RFunction, Optional bReset As Boolean = False)
        If Not bControlsInitialised Then
            InitialiseControls()
        End If
        clsNewClimdexInput = clsNewRFunction
        ucrNudN.SetRCode(clsNewClimdexInput, bReset)
        ucrNudThreshold.SetRCode(clsRTwoArg3, bReset)
        ucrNudAnnualMissingDays.SetRCode(clsRMaxMisingDays, bReset)
        ucrNudMothlyMissingDays.SetRCode(clsRMaxMisingDays, bReset)
        ucrNudMinBaseData.SetRCode(clsNewClimdexInput, bReset)
        ucrInputFreq.SetRCode(clsRTwoArg1, bReset)
        ucrInputFreq.SetRCode(clsRThreeArg, bReset)
        ucrInputFreq.SetRCode(clsRWriteDf, bReset)
        ucrMultipleInputTempQtiles.SetRCode(clsNewClimdexInput, bReset)
        ucrMultipleInputPrecQtiles.SetRCode(clsNewClimdexInput, bReset)
        ucrMultipleInputBaseRange.SetRCode(clsNewClimdexInput, bReset)
        ucrChkNHemisphere.SetRCode(clsNewClimdexInput, bReset)
        ucrChkCenterMean.SetRCode(clsRThreeArg, bReset)
        ucrChkMaxSpellSpanYears.SetRCode(clsRTwoArg4, bReset)
        ucrChkSpellDISpanYear.SetRCode(clsRTwoArg5, bReset)
        IndicesType()
    End Sub

    Private Sub ucrChkSave_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrChkSave.ControlContentsChanged
        If ucrChkSave.Checked Then
            bSaveIndex = True
        Else
            bSaveIndex = False
        End If
    End Sub

    Private Sub ucrInputFreq_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrInputFreq.ControlContentsChanged
        IndicesType()
    End Sub

    Private Sub GroupBoxControl(TempGroupBox As GroupBox)
        For Each ChkBox As ucrCheck In TempGroupBox.Controls
            ChkBox.Checked = False
        Next
    End Sub

    Public Sub IndicesType()
        If dlgClimdex.ucrReceiverPrec.IsEmpty Then
            GroupBoxControl(grpPrecAnnual)
            GroupBoxControl(grpPrecAnnualMonthly)
            grpPrecAnnualMonthly.Enabled = False
            grpPrecAnnual.Enabled = False
        Else
            If ucrInputFreq.cboInput.SelectedItem = "monthly" Then
                GroupBoxControl(grpPrecAnnual)
                grpPrecAnnual.Enabled = False
            ElseIf ucrInputFreq.cboInput.SelectedItem = "annual" Then
                grpPrecAnnual.Enabled = True
            End If
            grpPrecAnnualMonthly.Enabled = True
        End If

        If dlgClimdex.ucrReceiverTmax.IsEmpty Then
            GroupBoxControl(grpTmaxAnnual)
            GroupBoxControl(grpTmaxAnnualMonthly)
            grpTmaxAnnualMonthly.Enabled = False
            grpTmaxAnnual.Enabled = False
        Else
            If ucrInputFreq.cboInput.SelectedItem = "monthly" Then
                GroupBoxControl(grpTmaxAnnual)
                grpTmaxAnnual.Enabled = False
            ElseIf ucrInputFreq.cboInput.SelectedItem = "annual" Then
                grpTmaxAnnual.Enabled = True
            End If
            grpTmaxAnnualMonthly.Enabled = True
        End If

        If dlgClimdex.ucrReceiverTmin.IsEmpty Then
            GroupBoxControl(grpTminAnnual)
            GroupBoxControl(grpTminAnnualMonthly)
            grpTminAnnualMonthly.Enabled = False
            grpTminAnnual.Enabled = False
        Else
            If ucrInputFreq.cboInput.SelectedItem = "monthly" Then
                GroupBoxControl(grpTminAnnual)
                grpTminAnnual.Enabled = False
            ElseIf ucrInputFreq.cboInput.SelectedItem = "annual" Then
                grpTminAnnual.Enabled = True
            End If
            grpTminAnnualMonthly.Enabled = True
        End If

        If dlgClimdex.ucrReceiverTmin.IsEmpty OrElse dlgClimdex.ucrReceiverTmax.IsEmpty Then
            GroupBoxControl(grpTmaxTminAnnual)
            GroupBoxControl(grpTmaxTminAnnualMonthly)
            grpTmaxTminAnnualMonthly.Enabled = False
            grpTmaxTminAnnual.Enabled = False
        Else
            If ucrInputFreq.cboInput.SelectedItem = "monthly" Then
                GroupBoxControl(grpTmaxTminAnnual)
                grpTmaxTminAnnual.Enabled = False
            ElseIf ucrInputFreq.cboInput.SelectedItem = "annual" Then
                grpTmaxTminAnnual.Enabled = True
            End If
            grpTmaxTminAnnualMonthly.Enabled = True
        End If
    End Sub
End Class