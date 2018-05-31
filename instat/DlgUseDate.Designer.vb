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
Partial Class dlgUseDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgUseDate))
        Me.lblDateVariable = New System.Windows.Forms.Label()
        Me.grpShifted = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblShiftYear = New System.Windows.Forms.Label()
        Me.lblShiftQuarter = New System.Windows.Forms.Label()
        Me.lblShiftDekad = New System.Windows.Forms.Label()
        Me.lblShiftAbbr = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblShiftMonth = New System.Windows.Forms.Label()
        Me.lblShiftPentad = New System.Windows.Forms.Label()
        Me.lblShiftDayInYear366 = New System.Windows.Forms.Label()
        Me.lblShiftNumeric = New System.Windows.Forms.Label()
        Me.lblShiftStartingMonth = New System.Windows.Forms.Label()
        Me.grpOthers = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDayInMonth = New System.Windows.Forms.Label()
        Me.lblLeapYear = New System.Windows.Forms.Label()
        Me.lblAbbr = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDayInYear = New System.Windows.Forms.Label()
        Me.lblWeekDay = New System.Windows.Forms.Label()
        Me.lblWeek = New System.Windows.Forms.Label()
        Me.lblNumeric = New System.Windows.Forms.Label()
        Me.ucrChkWeekName = New instat.ucrCheck()
        Me.ucrChkWeekAbbr = New instat.ucrCheck()
        Me.ucrChkDayInYearNum = New instat.ucrCheck()
        Me.ucrChkWeekdayName = New instat.ucrCheck()
        Me.ucrChkWeekdayAbbr = New instat.ucrCheck()
        Me.ucrChkWeekNum = New instat.ucrCheck()
        Me.ucrChkDayInMonthNum = New instat.ucrCheck()
        Me.ucrChkWeekdayNum = New instat.ucrCheck()
        Me.ucrChkLeapYearNum = New instat.ucrCheck()
        Me.ucrChkShiftQuarterAbbr = New instat.ucrCheck()
        Me.ucrChkShiftDekadAbbr = New instat.ucrCheck()
        Me.ucrChkShiftQuarterNum = New instat.ucrCheck()
        Me.ucrChkShiftPentadAbbr = New instat.ucrCheck()
        Me.ucrChkShiftDekadNum = New instat.ucrCheck()
        Me.ucrChkShiftYearNum = New instat.ucrCheck()
        Me.ucrChkShiftMonthAbbr = New instat.ucrCheck()
        Me.ucrChkShiftPentadNum = New instat.ucrCheck()
        Me.ucrChkShiftMonthName = New instat.ucrCheck()
        Me.ucrChkShiftMonthNum = New instat.ucrCheck()
        Me.ucrChkShiftDayInYearNum366 = New instat.ucrCheck()
        Me.ucrInputComboBoxStartingMonth = New instat.ucrInputComboBox()
        Me.ucrReceiverUseDate = New instat.ucrReceiverSingle()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelectorUseDate = New instat.ucrSelectorByDataFrameAddRemove()
        Me.grpShifted.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpOthers.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDateVariable
        '
        resources.ApplyResources(Me.lblDateVariable, "lblDateVariable")
        Me.lblDateVariable.Name = "lblDateVariable"
        '
        'grpShifted
        '
        Me.grpShifted.Controls.Add(Me.TableLayoutPanel1)
        Me.grpShifted.Controls.Add(Me.lblShiftStartingMonth)
        Me.grpShifted.Controls.Add(Me.ucrInputComboBoxStartingMonth)
        resources.ApplyResources(Me.grpShifted, "grpShifted")
        Me.grpShifted.Name = "grpShifted"
        Me.grpShifted.TabStop = False
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftQuarterAbbr, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftYear, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftQuarter, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftDekadAbbr, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftQuarterNum, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftPentadAbbr, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftDekadNum, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftYearNum, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftDekad, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftMonthAbbr, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftAbbr, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftPentadNum, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftMonthName, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShift, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftMonth, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftMonthNum, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftPentad, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftDayInYear366, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ucrChkShiftDayInYearNum366, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblShiftNumeric, 0, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'lblShiftYear
        '
        resources.ApplyResources(Me.lblShiftYear, "lblShiftYear")
        Me.lblShiftYear.Name = "lblShiftYear"
        '
        'lblShiftQuarter
        '
        resources.ApplyResources(Me.lblShiftQuarter, "lblShiftQuarter")
        Me.lblShiftQuarter.Name = "lblShiftQuarter"
        '
        'lblShiftDekad
        '
        resources.ApplyResources(Me.lblShiftDekad, "lblShiftDekad")
        Me.lblShiftDekad.Name = "lblShiftDekad"
        '
        'lblShiftAbbr
        '
        resources.ApplyResources(Me.lblShiftAbbr, "lblShiftAbbr")
        Me.lblShiftAbbr.Name = "lblShiftAbbr"
        '
        'lblShift
        '
        resources.ApplyResources(Me.lblShift, "lblShift")
        Me.lblShift.Name = "lblShift"
        '
        'lblShiftMonth
        '
        resources.ApplyResources(Me.lblShiftMonth, "lblShiftMonth")
        Me.lblShiftMonth.Name = "lblShiftMonth"
        '
        'lblShiftPentad
        '
        resources.ApplyResources(Me.lblShiftPentad, "lblShiftPentad")
        Me.lblShiftPentad.Name = "lblShiftPentad"
        '
        'lblShiftDayInYear366
        '
        resources.ApplyResources(Me.lblShiftDayInYear366, "lblShiftDayInYear366")
        Me.lblShiftDayInYear366.Name = "lblShiftDayInYear366"
        '
        'lblShiftNumeric
        '
        resources.ApplyResources(Me.lblShiftNumeric, "lblShiftNumeric")
        Me.lblShiftNumeric.Name = "lblShiftNumeric"
        '
        'lblShiftStartingMonth
        '
        resources.ApplyResources(Me.lblShiftStartingMonth, "lblShiftStartingMonth")
        Me.lblShiftStartingMonth.Name = "lblShiftStartingMonth"
        '
        'grpOthers
        '
        Me.grpOthers.Controls.Add(Me.TableLayoutPanel2)
        resources.ApplyResources(Me.grpOthers, "grpOthers")
        Me.grpOthers.Name = "grpOthers"
        Me.grpOthers.TabStop = False
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkWeekName, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkWeekAbbr, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkDayInYearNum, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDayInMonth, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkWeekdayName, 4, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblLeapYear, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkWeekdayAbbr, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkWeekNum, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkDayInMonthNum, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblAbbr, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblName, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDayInYear, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkWeekdayNum, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblWeekDay, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblWeek, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNumeric, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ucrChkLeapYearNum, 5, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'lblDayInMonth
        '
        resources.ApplyResources(Me.lblDayInMonth, "lblDayInMonth")
        Me.lblDayInMonth.Name = "lblDayInMonth"
        '
        'lblLeapYear
        '
        resources.ApplyResources(Me.lblLeapYear, "lblLeapYear")
        Me.lblLeapYear.Name = "lblLeapYear"
        '
        'lblAbbr
        '
        resources.ApplyResources(Me.lblAbbr, "lblAbbr")
        Me.lblAbbr.Name = "lblAbbr"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'lblDayInYear
        '
        resources.ApplyResources(Me.lblDayInYear, "lblDayInYear")
        Me.lblDayInYear.Name = "lblDayInYear"
        '
        'lblWeekDay
        '
        resources.ApplyResources(Me.lblWeekDay, "lblWeekDay")
        Me.lblWeekDay.Name = "lblWeekDay"
        '
        'lblWeek
        '
        resources.ApplyResources(Me.lblWeek, "lblWeek")
        Me.lblWeek.Name = "lblWeek"
        '
        'lblNumeric
        '
        resources.ApplyResources(Me.lblNumeric, "lblNumeric")
        Me.lblNumeric.Name = "lblNumeric"
        '
        'ucrChkWeekName
        '
        resources.ApplyResources(Me.ucrChkWeekName, "ucrChkWeekName")
        Me.ucrChkWeekName.Checked = False
        Me.ucrChkWeekName.Name = "ucrChkWeekName"
        '
        'ucrChkWeekAbbr
        '
        resources.ApplyResources(Me.ucrChkWeekAbbr, "ucrChkWeekAbbr")
        Me.ucrChkWeekAbbr.Checked = False
        Me.ucrChkWeekAbbr.Name = "ucrChkWeekAbbr"
        '
        'ucrChkDayInYearNum
        '
        resources.ApplyResources(Me.ucrChkDayInYearNum, "ucrChkDayInYearNum")
        Me.ucrChkDayInYearNum.Checked = False
        Me.ucrChkDayInYearNum.Name = "ucrChkDayInYearNum"
        '
        'ucrChkWeekdayName
        '
        resources.ApplyResources(Me.ucrChkWeekdayName, "ucrChkWeekdayName")
        Me.ucrChkWeekdayName.Checked = False
        Me.ucrChkWeekdayName.Name = "ucrChkWeekdayName"
        '
        'ucrChkWeekdayAbbr
        '
        resources.ApplyResources(Me.ucrChkWeekdayAbbr, "ucrChkWeekdayAbbr")
        Me.ucrChkWeekdayAbbr.Checked = False
        Me.ucrChkWeekdayAbbr.Name = "ucrChkWeekdayAbbr"
        '
        'ucrChkWeekNum
        '
        resources.ApplyResources(Me.ucrChkWeekNum, "ucrChkWeekNum")
        Me.ucrChkWeekNum.Checked = False
        Me.ucrChkWeekNum.Name = "ucrChkWeekNum"
        '
        'ucrChkDayInMonthNum
        '
        resources.ApplyResources(Me.ucrChkDayInMonthNum, "ucrChkDayInMonthNum")
        Me.ucrChkDayInMonthNum.Checked = False
        Me.ucrChkDayInMonthNum.Name = "ucrChkDayInMonthNum"
        '
        'ucrChkWeekdayNum
        '
        resources.ApplyResources(Me.ucrChkWeekdayNum, "ucrChkWeekdayNum")
        Me.ucrChkWeekdayNum.Checked = False
        Me.ucrChkWeekdayNum.Name = "ucrChkWeekdayNum"
        '
        'ucrChkLeapYearNum
        '
        resources.ApplyResources(Me.ucrChkLeapYearNum, "ucrChkLeapYearNum")
        Me.ucrChkLeapYearNum.Checked = False
        Me.ucrChkLeapYearNum.Name = "ucrChkLeapYearNum"
        '
        'ucrChkShiftQuarterAbbr
        '
        resources.ApplyResources(Me.ucrChkShiftQuarterAbbr, "ucrChkShiftQuarterAbbr")
        Me.ucrChkShiftQuarterAbbr.Checked = False
        Me.ucrChkShiftQuarterAbbr.Name = "ucrChkShiftQuarterAbbr"
        '
        'ucrChkShiftDekadAbbr
        '
        resources.ApplyResources(Me.ucrChkShiftDekadAbbr, "ucrChkShiftDekadAbbr")
        Me.ucrChkShiftDekadAbbr.Checked = False
        Me.ucrChkShiftDekadAbbr.Name = "ucrChkShiftDekadAbbr"
        '
        'ucrChkShiftQuarterNum
        '
        resources.ApplyResources(Me.ucrChkShiftQuarterNum, "ucrChkShiftQuarterNum")
        Me.ucrChkShiftQuarterNum.Checked = False
        Me.ucrChkShiftQuarterNum.Name = "ucrChkShiftQuarterNum"
        '
        'ucrChkShiftPentadAbbr
        '
        resources.ApplyResources(Me.ucrChkShiftPentadAbbr, "ucrChkShiftPentadAbbr")
        Me.ucrChkShiftPentadAbbr.Checked = False
        Me.ucrChkShiftPentadAbbr.Name = "ucrChkShiftPentadAbbr"
        '
        'ucrChkShiftDekadNum
        '
        resources.ApplyResources(Me.ucrChkShiftDekadNum, "ucrChkShiftDekadNum")
        Me.ucrChkShiftDekadNum.Checked = False
        Me.ucrChkShiftDekadNum.Name = "ucrChkShiftDekadNum"
        '
        'ucrChkShiftYearNum
        '
        resources.ApplyResources(Me.ucrChkShiftYearNum, "ucrChkShiftYearNum")
        Me.ucrChkShiftYearNum.Checked = False
        Me.ucrChkShiftYearNum.Name = "ucrChkShiftYearNum"
        '
        'ucrChkShiftMonthAbbr
        '
        resources.ApplyResources(Me.ucrChkShiftMonthAbbr, "ucrChkShiftMonthAbbr")
        Me.ucrChkShiftMonthAbbr.Checked = False
        Me.ucrChkShiftMonthAbbr.Name = "ucrChkShiftMonthAbbr"
        '
        'ucrChkShiftPentadNum
        '
        resources.ApplyResources(Me.ucrChkShiftPentadNum, "ucrChkShiftPentadNum")
        Me.ucrChkShiftPentadNum.Checked = False
        Me.ucrChkShiftPentadNum.Name = "ucrChkShiftPentadNum"
        '
        'ucrChkShiftMonthName
        '
        resources.ApplyResources(Me.ucrChkShiftMonthName, "ucrChkShiftMonthName")
        Me.ucrChkShiftMonthName.Checked = False
        Me.ucrChkShiftMonthName.Name = "ucrChkShiftMonthName"
        '
        'ucrChkShiftMonthNum
        '
        resources.ApplyResources(Me.ucrChkShiftMonthNum, "ucrChkShiftMonthNum")
        Me.ucrChkShiftMonthNum.Checked = False
        Me.ucrChkShiftMonthNum.Name = "ucrChkShiftMonthNum"
        '
        'ucrChkShiftDayInYearNum366
        '
        resources.ApplyResources(Me.ucrChkShiftDayInYearNum366, "ucrChkShiftDayInYearNum366")
        Me.ucrChkShiftDayInYearNum366.Checked = False
        Me.ucrChkShiftDayInYearNum366.Name = "ucrChkShiftDayInYearNum366"
        '
        'ucrInputComboBoxStartingMonth
        '
        Me.ucrInputComboBoxStartingMonth.AddQuotesIfUnrecognised = True
        Me.ucrInputComboBoxStartingMonth.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputComboBoxStartingMonth, "ucrInputComboBoxStartingMonth")
        Me.ucrInputComboBoxStartingMonth.Name = "ucrInputComboBoxStartingMonth"
        '
        'ucrReceiverUseDate
        '
        Me.ucrReceiverUseDate.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverUseDate, "ucrReceiverUseDate")
        Me.ucrReceiverUseDate.Name = "ucrReceiverUseDate"
        Me.ucrReceiverUseDate.Selector = Nothing
        Me.ucrReceiverUseDate.strNcFilePath = ""
        Me.ucrReceiverUseDate.ucrSelector = Nothing
        '
        'ucrBase
        '
        resources.ApplyResources(Me.ucrBase, "ucrBase")
        Me.ucrBase.Name = "ucrBase"
        '
        'ucrSelectorUseDate
        '
        Me.ucrSelectorUseDate.bDropUnusedFilterLevels = False
        Me.ucrSelectorUseDate.bShowHiddenColumns = False
        Me.ucrSelectorUseDate.bUseCurrentFilter = True
        resources.ApplyResources(Me.ucrSelectorUseDate, "ucrSelectorUseDate")
        Me.ucrSelectorUseDate.Name = "ucrSelectorUseDate"
        '
        'dlgUseDate
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpOthers)
        Me.Controls.Add(Me.grpShifted)
        Me.Controls.Add(Me.ucrReceiverUseDate)
        Me.Controls.Add(Me.lblDateVariable)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrSelectorUseDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgUseDate"
        Me.grpShifted.ResumeLayout(False)
        Me.grpShifted.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grpOthers.ResumeLayout(False)
        Me.grpOthers.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrSelectorUseDate As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents lblDateVariable As Label
    Friend WithEvents ucrReceiverUseDate As ucrReceiverSingle
    Friend WithEvents grpOthers As GroupBox
    Friend WithEvents ucrChkDayInYearNum As ucrCheck
    Friend WithEvents ucrChkWeekdayNum As ucrCheck
    Friend WithEvents ucrChkWeekNum As ucrCheck
    Friend WithEvents ucrChkShiftMonthNum As ucrCheck
    Friend WithEvents ucrChkWeekName As ucrCheck
    Friend WithEvents ucrChkWeekdayName As ucrCheck
    Friend WithEvents ucrChkShiftMonthName As ucrCheck
    Friend WithEvents ucrChkShiftMonthAbbr As ucrCheck
    Friend WithEvents ucrChkWeekdayAbbr As ucrCheck
    Friend WithEvents ucrChkLeapYearNum As ucrCheck
    Friend WithEvents ucrChkShiftDekadNum As ucrCheck
    Friend WithEvents ucrChkShiftPentadNum As ucrCheck
    Friend WithEvents ucrChkShiftDayInYearNum366 As ucrCheck
    Friend WithEvents ucrChkShiftYearNum As ucrCheck
    Friend WithEvents grpShifted As GroupBox
    Friend WithEvents lblShiftStartingMonth As Label
    Friend WithEvents ucrInputComboBoxStartingMonth As ucrInputComboBox
    Friend WithEvents ucrChkShiftQuarterNum As ucrCheck
    Friend WithEvents ucrChkWeekAbbr As ucrCheck
    Friend WithEvents ucrChkShiftQuarterAbbr As ucrCheck
    Friend WithEvents ucrChkShiftDekadAbbr As ucrCheck
    Friend WithEvents ucrChkShiftPentadAbbr As ucrCheck
    Friend WithEvents lblShiftQuarter As Label
    Friend WithEvents lblShiftDekad As Label
    Friend WithEvents lblShift As Label
    Friend WithEvents lblShiftAbbr As Label
    Friend WithEvents lblShiftNumeric As Label
    Friend WithEvents lblShiftYear As Label
    Friend WithEvents lblShiftMonth As Label
    Friend WithEvents lblShiftDayInYear366 As Label
    Friend WithEvents lblShiftPentad As Label
    Friend WithEvents ucrChkDayInMonthNum As ucrCheck
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblDayInMonth As Label
    Friend WithEvents lblLeapYear As Label
    Friend WithEvents lblAbbr As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblDayInYear As Label
    Friend WithEvents lblWeekDay As Label
    Friend WithEvents lblWeek As Label
    Friend WithEvents lblNumeric As Label
End Class
