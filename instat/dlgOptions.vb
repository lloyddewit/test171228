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

Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports instat.Translations
Imports System.IO
Public Class dlgOptions
    Public strCurrLanguageCulture As String
    Public strOutputWindowDisplay As String
    Public strWorkingDirectory As String
    Private strGraphDisplayOption As String
    Private Panels As New List(Of Panel)()
    Private VisiblePanel As Panel = Nothing
    'Define the Fonts dialog (only one)
    Dim dlgFont As New FontDialog
    Dim bFirstLoad As Boolean = True
    Dim fntOutput, fntCommand, fntComment, fntEditor As Font
    Dim clrOutput, clrCommand, clrComment, clrEditor As Color

    Private Sub dlgOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        LoadInstatOptions()
        ApplyEnabled(False)
    End Sub

    Private Sub InitialiseDialog()
        'ucrBase.iHelpTopicID = 336
        Dim strPreviewText As String
        ucrNudMaxRows.Maximum = Integer.MaxValue
        ucrNudMaxRows.Increment = 10
        strPreviewText = "R-Instat 2016"
        rtbCommandPreview.Text = strPreviewText
        rtbCommentPreview.Text = strPreviewText
        rtbOutputPreview.Text = strPreviewText
        SetView()
        'temp disabled as not functioning yet
        rdoFrench.Enabled = False
        rdoKiswahili.Enabled = False
        rdoSpanish.Enabled = False
        ucrNudDigits.SetMinMax(0, 22)
        ucrChkIncludeCommentsbyDefault.SetText("Include Comments by Default")
        ucrChkShowRCommandsinOutputWindow.SetText(" Show R Commands in Output Window")
        ucrChkShowSignifStars.SetText("Show stars on summary tables for coefficients")
        ucrChkIncludeDefaultParams.SetText("Include Default Parameter Values in R Commands")
        ucrPnlGraphDisplay.AddRadioButton(rdoDisplayinOutputWindow)
        ucrPnlGraphDisplay.AddRadioButton(rdoDisplayinRViewer)
        ucrPnlGraphDisplay.AddRadioButton(rdoDisplayinSeparateWindows)

        'ucrNudDigits.Minimum = 0
        'ucrNudDigits.Maximum = 22
    End Sub

    Private Sub LoadInstatOptions()
        ucrChkIncludeDefaultParams.Checked = frmMain.clsInstatOptions.bIncludeRDefaultParameters
        SetOutputFont(frmMain.clsInstatOptions.fntOutput, frmMain.clsInstatOptions.clrOutput)
        SetCommandFont(frmMain.clsInstatOptions.fntScript, frmMain.clsInstatOptions.clrScript)
        SetCommentFont(frmMain.clsInstatOptions.fntComment, frmMain.clsInstatOptions.clrComment)
        SetEditorFont(frmMain.clsInstatOptions.fntEditor, frmMain.clsInstatOptions.clrEditor)
        ucrNudMaxRows.Value = frmMain.clsInstatOptions.iMaxRows
        ucrNudPreviewRows.Value = frmMain.clsInstatOptions.iPreviewRows
        txtComment.Text = frmMain.clsInstatOptions.strComment
        ucrWorkingDirectory.SetName(frmMain.clsInstatOptions.strWorkingDirectory)
        ucrChkIncludeCommentsbyDefault.Checked = frmMain.clsInstatOptions.bIncludeCommentDefault
        ucrChkShowRCommandsinOutputWindow.Checked = frmMain.clsInstatOptions.bCommandsinOutput
        ucrNudDigits.Value = frmMain.clsInstatOptions.iDigits
        ucrChkShowSignifStars.Checked = frmMain.clsInstatOptions.bShowSignifStars

        Select Case frmMain.clsInstatOptions.strLanguageCultureCode
            Case "en-GB"
                rdoEnglish.Checked = True
            ' temp disabled as not functioning
            'Case "fr-FR"
            '    rdoFrench.Checked = True
            'Case "sw-KE"
            '    rdoKiswahili.Checked = True
            'Case "es-ES"
            '    rdoSpanish.Checked = True
            Case Else
                rdoEnglish.Checked = True
        End Select

        If frmMain.clsInstatOptions.strGraphDisplayOption = "view_output_window" Then
            rdoDisplayinOutputWindow.Checked = True
        ElseIf frmMain.clsInstatOptions.strGraphDisplayOption = "view_separate_window" Then
            rdoDisplayinSeparateWindows.Checked = True
        ElseIf frmMain.clsInstatOptions.strGraphDisplayOption = "view_R_viewer" Then
            rdoDisplayinRViewer.Checked = True
        End If
    End Sub

    Private Sub SetInstatOptions()
        frmMain.clsInstatOptions.bIncludeRDefaultParameters = ucrChkIncludeDefaultParams.Checked
        frmMain.clsInstatOptions.SetFormatOutput(fntOutput, clrOutput)
        frmMain.clsInstatOptions.SetFormatComment(fntComment, clrComment)
        frmMain.clsInstatOptions.SetFormatScript(fntCommand, clrCommand)
        frmMain.clsInstatOptions.SetFormatEditor(fntEditor, clrEditor)
        frmMain.clsInstatOptions.SetComment(txtComment.Text)
        frmMain.clsInstatOptions.SetPreviewRows(ucrNudPreviewRows.Value)
        frmMain.clsInstatOptions.SetMaxRows(ucrNudMaxRows.Value)
        frmMain.clsInstatOptions.SetLanguageCultureCode(strCurrLanguageCulture)
        frmMain.clsInstatOptions.SetWorkingDirectory(strWorkingDirectory)
        frmMain.clsInstatOptions.SetGraphDisplayOption(strGraphDisplayOption)
        frmMain.clsInstatOptions.bIncludeCommentDefault = ucrChkIncludeCommentsbyDefault.Checked
        frmMain.clsInstatOptions.SetCommandInOutpt(ucrChkShowRCommandsinOutputWindow.Checked)
        frmMain.clsInstatOptions.SetDigits(ucrNudDigits.Value)
        frmMain.clsInstatOptions.SetSignifStars(ucrChkShowSignifStars.Checked)
    End Sub

    Private Sub SetView()
        Dim tbpPage As TabPage
        trOptions.Nodes.Clear()
        For Each tbpPage In tbcOptions.TabPages
            trOptions.Nodes.Add(tbpPage.Name, tbpPage.Text)
        Next
        ' Expand all tree nodes.
        trOptions.ExpandAll()
        '' Move the Panels out of the TabControl.
        'tbcOptions.Visible = False
        'For Each page As TabPage In tbcOptions.TabPages
        '    ' Add the Panel to the list.
        '    Dim the_panel As Panel = DirectCast(page.Controls(0), Panel)
        '    Panels.Add(the_panel)

        '    ' Reparent and move the Panel.
        '    the_panel.Parent = tbcOptions.Parent
        '    the_panel.Location = tbcOptions.Location
        '    the_panel.Visible = False
        'Next page

        '' Display the first panel.
        'DisplayPanel(0)
    End Sub

    ' Display the appropriate Panel.
    Private Sub DisplayPanel(iPage As Integer)
        tbcOptions.SelectedIndex = iPage
        'removed temporarily to also show tabs
        'If (Panels.Count < 1) Then Return

        '' If this is the same Panel, do nothing.
        'If (VisiblePanel Is Panels(Index)) Then Return

        '' Hide the previously visible Panel.
        'If (VisiblePanel IsNot Nothing) Then VisiblePanel.Visible = False

        '' Display the appropriate Panel.
        'Panels(Index).Visible = True
        'VisiblePanel = Panels(Index)
    End Sub

    'Handles click of the tree node
    Private Sub trOptions_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trOptions.AfterSelect
        DisplayPanel(e.Node.Index)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        cmdApply_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        SetInstatOptions()
        autoTranslate(Me)

        If frmMain.Visible Then
            autoTranslate(frmMain)
        End If

        If frmCommand.Visible Then
            autoTranslate(frmCommand)
        End If

        If frmEditor.Visible Then
            autoTranslate(frmEditor)
        End If

        If frmLog.Visible Then
            autoTranslate(frmLog)
        End If

        If frmMetaData.Visible Then
            autoTranslate(frmMetaData)
        End If

        If frmScript.Visible Then
            autoTranslate(frmScript)
        End If

        If frmVariables.Visible Then
            autoTranslate(frmVariables)
        End If
        'disables the command after running it
        ApplyEnabled(False)
    End Sub

    Private Sub LanguageChanged(sender As Object, e As EventArgs) Handles rdoKiswahili.CheckedChanged, rdoEnglish.CheckedChanged, rdoFrench.CheckedChanged, rdoSpanish.CheckedChanged
        If rdoKiswahili.Checked Then
            strCurrLanguageCulture = "sw-KE"
        ElseIf rdoFrench.Checked Then
            strCurrLanguageCulture = "fr-FR"
        ElseIf rdoEnglish.Checked Then
            strCurrLanguageCulture = "en-GB"
        ElseIf rdoSpanish.Checked Then
            strCurrLanguageCulture = "es-ES"
        End If
        ApplyEnabled(True)
    End Sub

    Private Sub txtComment_TextChanged(sender As Object, e As EventArgs) Handles txtComment.TextChanged
        ApplyEnabled(True)
    End Sub

    Private Sub cmdScriptChange_Click(sender As Object, e As EventArgs) Handles cmdCommandFormat.Click
        dlgFont.ShowColor = True
        dlgFont.MaxSize = 50
        dlgFont.MinSize = 8
        dlgFont.Font = frmMain.clsRLink.fScript
        dlgFont.Color = frmMain.clsRLink.clrScript
        If dlgFont.ShowDialog = DialogResult.OK Then
            SetCommandFont(dlgFont.Font, dlgFont.Color)
            ApplyEnabled(True)
            dlgFont.Reset()
        End If
    End Sub

    Private Sub cmdOutputChange_Click(sender As Object, e As EventArgs) Handles cmdOutputFormat.Click
        dlgFont.ShowColor = True
        dlgFont.MaxSize = 50
        dlgFont.MinSize = 8
        dlgFont.Font = fntOutput
        dlgFont.Color = clrOutput
        If dlgFont.ShowDialog = DialogResult.OK Then
            SetOutputFont(dlgFont.Font, dlgFont.Color)
            ApplyEnabled(True)
            dlgFont.Reset()
        End If
    End Sub

    Private Sub cmdCommentsChange_Click(sender As Object, e As EventArgs) Handles cmdCommentFormat.Click
        dlgFont.ShowColor = True
        dlgFont.MaxSize = 50
        dlgFont.MinSize = 8
        dlgFont.Font = frmMain.clsRLink.fComments
        dlgFont.Color = frmMain.clsRLink.clrComments
        If dlgFont.ShowDialog = DialogResult.OK Then
            SetCommentFont(dlgFont.Font, dlgFont.Color)
            ApplyEnabled(True)
            dlgFont.Reset()
        End If
    End Sub

    Private Sub cmdEditorFont_Click(sender As Object, e As EventArgs) Handles cmdEditorFont.Click
        dlgFont.ShowColor = True
        'dlgFont.ShowEffects = False
        dlgFont.MaxSize = 50
        dlgFont.MinSize = 8
        dlgFont.Font = frmMain.clsGrids.fntText
        dlgFont.Color = frmMain.clsGrids.clrText
        If dlgFont.ShowDialog = DialogResult.OK Then
            SetEditorFont(dlgFont.Font, dlgFont.Color)
            ApplyEnabled(True)
            dlgFont.Reset()
        End If

    End Sub

    Private Sub ucrNudPreviewRows_ValueChanged() Handles ucrNudPreviewRows.ControlValueChanged
        ApplyEnabled(True)
    End Sub

    Private Sub ucrChkIncludeCommentsbyDefault_controlvaluechanged() Handles ucrChkIncludeCommentsbyDefault.ControlValueChanged
        ApplyEnabled(True)
    End Sub

    Private Sub nudMaxRows_TextChanged() Handles ucrNudMaxRows.ControlValueChanged
        ApplyEnabled(True)
    End Sub

    Private Sub rdoDisplayinOutputWindow_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDisplayinOutputWindow.CheckedChanged, rdoDisplayinSeparateWindows.CheckedChanged, rdoDisplayinRViewer.CheckedChanged
        'If rdoDisplayinOutputWindow.Checked Then
        '    strGraphDisplayOption = "view_output_window"
        'ElseIf rdoDisplayinSeparateWindows.Checked Then
        '    strGraphDisplayOption = "view_separate_window"
        'ElseIf rdoDisplayinRViewer.Checked Then
        '    strGraphDisplayOption = "view_R_viewer"
        'End If

        'ApplyEnabled(True)
    End Sub

    Private Sub ucrChkIncludeDefaultParams_ControlValueChanged() Handles ucrChkIncludeDefaultParams.ControlValueChanged
        ApplyEnabled(True)
    End Sub

    Private Sub chkShowRCommandsinOutputWindow_CheckedChanged() Handles ucrChkShowRCommandsinOutputWindow.ControlValueChanged
        ApplyEnabled(True)
    End Sub

    Private Sub ApplyEnabled(bEnable As Boolean)
        cmdApply.Enabled = bEnable
        cmdOk.Enabled = bEnable
    End Sub

    Private Sub SetOutputFont(fntNew As Font, clrNew As Color)
        fntOutput = fntNew
        clrOutput = clrNew
        rtbOutputPreview.SelectAll()
        rtbOutputPreview.Font = fntOutput
        rtbOutputPreview.SelectionColor = clrOutput
        rtbOutputPreview.SelectionLength = 0
    End Sub

    Private Sub cmdFactoryReset_Click(sender As Object, e As EventArgs) Handles cmdFactoryReset.Click
        Dim msgFactoryReset = MsgBox("Are you sure you want to reset to factory defaults?", MessageBoxButtons.YesNo, "Factory Reset")
        If msgFactoryReset = DialogResult.Yes Then
            frmMain.clsInstatOptions = New InstatOptions(False)
            LoadInstatOptions()
            ApplyEnabled(True)
        End If
    End Sub

    Private Sub ucrPnlGraphDisplay_ControlValueChanged() Handles ucrPnlGraphDisplay.ControlValueChanged
        If rdoDisplayinOutputWindow.Checked Then
            strGraphDisplayOption = "view_output_window"
        ElseIf rdoDisplayinSeparateWindows.Checked Then
            strGraphDisplayOption = "view_separate_window"
        ElseIf rdoDisplayinRViewer.Checked Then
            strGraphDisplayOption = "view_R_viewer"
        End If
        ApplyEnabled(True)
    End Sub
    Private Sub SetCommandFont(fntNew As Font, clrNew As Color)
        fntCommand = fntNew
        clrCommand = clrNew
        rtbCommandPreview.SelectAll()
        rtbCommandPreview.Font = fntCommand
        rtbCommandPreview.SelectionColor = clrCommand
        rtbCommandPreview.SelectionLength = 0
    End Sub

    Private Sub SetCommentFont(fntNew As Font, clrNew As Color)
        fntComment = fntNew
        clrComment = clrNew
        rtbCommentPreview.SelectAll()
        rtbCommentPreview.Font = fntComment
        rtbCommentPreview.SelectionColor = clrComment
        rtbCommandPreview.SelectionLength = 0
    End Sub

    Private Sub SetEditorFont(fntNew As Font, clrNew As Color)
        fntEditor = fntNew
        clrEditor = clrNew
    End Sub

    Private Sub cmdWorkingDirectory_Click(sender As Object, e As EventArgs) Handles cmdWorkingDirectory.Click
        Dim dlgWorkingDirectory As New FolderBrowserDialog
        If dlgWorkingDirectory.ShowDialog = DialogResult.OK Then
            strWorkingDirectory = (dlgWorkingDirectory.SelectedPath).Replace("\", "/")
            ucrWorkingDirectory.SetName(strWorkingDirectory)
            ApplyEnabled(True)
        End If
    End Sub

    Private Sub ucrNudDigits_ValueChanged() Handles ucrNudDigits.ControlValueChanged
        ApplyEnabled(True)
    End Sub

    Private Sub ucrChkShowSignifStars_CheckedChanged() Handles ucrChkShowSignifStars.ControlValueChanged
        ApplyEnabled(True)
    End Sub
End Class