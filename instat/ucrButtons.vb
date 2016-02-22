﻿Imports instat.Translations
Public Class ucrButtons

    Public clsRsyntax As New RSyntax
    Public iHelpTopicID As Integer = -1
    Public bFirstLoad As Boolean = True

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.ParentForm.Hide()
    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        SetDefaults()
        RaiseEvent ClickReset(sender, e)
    End Sub

    Public Event ClickOk(sender As Object, e As EventArgs)
    Public Event ClickReset(sender As Object, e As EventArgs)

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim strComments As String = ""
        If chkComment.Checked Then
            strComments = txtComment.Text
        End If
        frmMain.clsRLink.RunScript(clsRsyntax.GetScript(), clsRsyntax.iCallType, strComment:=strComments)

        'This clears the script after it has been run, but leave the function and parameters in the base function
        'so that it can be run exactly the same when reopened.
        clsRsyntax.strScript = ""

        RaiseEvent ClickOk(sender, e)

        Me.ParentForm.Hide()
    End Sub

    Public Sub OKEnabled(bEnabled As Boolean)
        cmdOk.Enabled = bEnabled
        cmdPaste.Enabled = bEnabled
    End Sub

    Private Sub ucrButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        translateEach(Controls)
        If bFirstLoad Then
            SetDefaults()
            bFirstLoad = False
        End If
    End Sub

    Private Sub SetDefaults()
        chkComment.Checked = True
        'TODO these defaults should be moved to general options dialog
        '     default text should be translatable
        'txtComment.Text = ParentForm.Name & ": code generated by the dialog " & ParentForm.Text
        txtComment.Text = ParentForm.Name & "" & dlgOptions.strComment & "" & ParentForm.Text
    End Sub

    Private Sub cmdPaste_Click(sender As Object, e As EventArgs) Handles cmdPaste.Click
        frmScript.txtScript.Text = frmScript.txtScript.Text & vbCrLf & "# " & txtComment.Text
        frmScript.txtScript.Text = frmScript.txtScript.Text & vbCrLf & clsRsyntax.GetScript()
        frmScript.Visible = True
        frmScript.BringToFront()
    End Sub

    Private Sub chkComment_CheckedChanged(sender As Object, e As EventArgs) Handles chkComment.CheckedChanged
        txtComment.Enabled = chkComment.Checked
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click

        ' (1) Use HelpNDoc's Help Context number. Not dependent on HelpNDoc.
        If iHelpTopicID > 0 Then
            Help.ShowHelp(Me.Parent, frmMain.strStaticPath & "\" & frmMain.strHelpFilePath, HelpNavigator.TopicId, iHelpTopicID.ToString())
        Else
            Help.ShowHelp(Me.Parent, frmMain.strStaticPath & frmMain.strHelpFilePath, HelpNavigator.TableOfContents)
        End If

        ' (2) Use HelpNDoc's Help ID. Dependent on how HelpNDoc complies .htm files using the Help ID
        'Help.ShowHelp(Me, strHelpFilePath, HelpNavigator.Topic, "Maths.htm")

        ' (3) Use constants or enums automatically generated by HelpNDoc (but needing manual
        '     covertion from .bas) to refer to the Help Context numbers.
        'Help.ShowHelp(Me, strHelpFilePath, HelpNavigator.TopicId, mHelpConstants.HELP_Maths.ToString)
    End Sub

End Class