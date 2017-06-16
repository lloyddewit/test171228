﻿' Instat+R
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

Public Class ucrButtons
    Public clsRsyntax As RSyntax
    Public iHelpTopicID As Integer
    Public bFirstLoad As Boolean
    Public strComment As String


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        clsRsyntax = New RSyntax
        iHelpTopicID = -1
        bFirstLoad = True
        strComment = "code generated by the dialog"
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.ParentForm.Hide()
    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        SetDefaults()
        RaiseEvent ClickReset(sender, e)
    End Sub

    Public Event BeforeClickOk(sender As Object, e As EventArgs)
    Public Event ClickOk(sender As Object, e As EventArgs)
    Public Event ClickReset(sender As Object, e As EventArgs)

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim lstCurrentEnabled As New List(Of Boolean)
        Dim ctrTempControl As Control
        Dim j As Integer

        For Each ctrTempControl In ParentForm.Controls
            lstCurrentEnabled.Add(ctrTempControl.Enabled)
            ctrTempControl.Enabled = False
        Next
        ParentForm.Cursor = Cursors.WaitCursor

        RaiseEvent BeforeClickOk(sender, e)
        Scripts(bRun:=True)
        RaiseEvent ClickOk(sender, e)

        'Need to be resetting other AssignTo values as well, maybe through single method

        'Warning: these reinitializing processes of the RSyntax parameters should probably be integrated at the end of GetScript. 
        'However, for the moment, RSyntax is not playing it's role of capturing the whole set of R-commands that the user wants to run when OK is Cklicked. 
        'Indeed, the events BeforeClickOk and ClickOk enables for the moment to insert R-commands before and after the Base R-command handle. 
        'In the process, we want the RSyntax parameters to be set as at the end of GetScript. Hence the reset needs to come after.
        'Eventually, all this should be more neatly incorporated in the RSyntax machinery...
        ParentForm.Hide()
        j = 0
        For Each ctrTempControl In ParentForm.Controls
            ctrTempControl.Enabled = lstCurrentEnabled(j)
            j = j + 1
        Next
        ParentForm.Cursor = Cursors.Default
    End Sub

    Private Sub Scripts(bRun As Boolean)
        Dim strComments As String
        Dim bIsAssigned As Boolean
        Dim bToBeAssigned As Boolean
        Dim strAssignTo As String
        Dim lstBeforeScripts As List(Of String)
        Dim lstAfterScripts As List(Of String)
        Dim lstBeforeCodes As List(Of RCodeStructure)
        Dim lstAfterCodes As List(Of RCodeStructure)
        Dim lstAssignToVariables As List(Of String)
        Dim bFirstCode As Boolean = True
        Dim clsRemoveFunc As New RFunction
        Dim clsRemoveListFun As New RFunction

        clsRemoveFunc.SetRCommand("rm")
        clsRemoveListFun.SetRCommand("c")
        If chkComment.Checked Then
            strComments = txtComment.Text
        Else
            strComments = ""
        End If
        If Not bRun AndAlso strComments <> "" Then
            frmMain.AddToScriptWindow("# " & strComments & Environment.NewLine)
        End If
        'Also need to be getting strAssignToColumn, strAssignToDataFrame etc. maybe one method to get all as a list
        bIsAssigned = clsRsyntax.GetbIsAssigned()
        bToBeAssigned = clsRsyntax.GetbToBeAssigned()
        strAssignTo = clsRsyntax.GetstrAssignTo()

        'Run additional before codes
        lstBeforeScripts = clsRsyntax.GetBeforeCodesScripts()
        lstBeforeCodes = clsRsyntax.GetBeforeCodes()
        For i As Integer = 0 To clsRsyntax.lstBeforeCodes.Count - 1
            If bFirstCode Then
                strComment = strComments
                bFirstCode = False
            Else
                strComment = ""
            End If
            If bRun Then
                frmMain.clsRLink.RunScript(lstBeforeScripts(i), iCallType:=lstBeforeCodes(i).iCallType, strComment:=strComment)
            Else
                frmMain.AddToScriptWindow(lstBeforeScripts(i))
            End If
        Next

        'Run base code from RSyntax
        If bRun Then
            If bFirstCode Then
                frmMain.clsRLink.RunScript(clsRsyntax.GetScript(), clsRsyntax.iCallType, strComment:=strComments)
                bFirstCode = False
            Else
                frmMain.clsRLink.RunScript(clsRsyntax.GetScript(), clsRsyntax.iCallType, strComment:="")
            End If
        Else
            frmMain.AddToScriptWindow(clsRsyntax.GetScript())
        End If

        'This clears the script after it has been run, but leave the function and parameters in the base function
        'so that it can be run exactly the same when reopened.
        clsRsyntax.strScript = ""

        'Run additional after codes
        lstAfterScripts = clsRsyntax.GetAfterCodesScripts()
        lstAfterCodes = clsRsyntax.GetAfterCodes()
        For i As Integer = 0 To lstAfterCodes.Count - 1
            If bRun Then
                If bFirstCode Then
                    strComment = strComments
                    bFirstCode = False
                Else
                    strComment = ""
                End If
                frmMain.clsRLink.RunScript(lstAfterScripts(i), iCallType:=lstAfterCodes(i).iCallType, strComment:=strComment)
            Else
                frmMain.AddToScriptWindow(lstAfterScripts(i))
            End If
        Next

        'Clear variables from global environment
        lstAssignToVariables = clsRsyntax.GetAllAssignTo(New List(Of String))
        clsRemoveFunc.ClearParameters()
        If lstAssignToVariables.Count = 1 Then
            clsRemoveFunc.AddParameter("x1", lstAssignToVariables(0), bIncludeArgumentName:=False)
        ElseIf lstAssignToVariables.Count > 1 Then
            For i As Integer = 0 To lstAssignToVariables.Count - 1
                clsRemoveListFun.AddParameter(i, Chr(34) & lstAssignToVariables(i) & Chr(34), bIncludeArgumentName:=False)
            Next
            clsRemoveFunc.AddParameter("list", clsRFunctionParameter:=clsRemoveListFun)
        End If
        If bRun Then
            frmMain.clsRLink.RunScript(clsRemoveFunc.ToScript(), iCallType:=0)
        Else
            frmMain.AddToScriptWindow(clsRemoveFunc.ToScript())
        End If
        clsRsyntax.SetbIsAssigned(bIsAssigned)
        clsRsyntax.SetbToBeAssigned(bToBeAssigned)
        clsRsyntax.SetstrAssignTo(strAssignTo)
    End Sub

    Public Sub OKEnabled(bEnabled As Boolean)
        cmdOk.Enabled = bEnabled
        cmdPaste.Enabled = bEnabled
    End Sub

    Private Sub ucrButtons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.clsRecentItems.addToMenu(Me.Parent)
        translateEach(Controls)
        If bFirstLoad Then
            SetDefaults()
            bFirstLoad = False
        End If
    End Sub

    Private Sub SetDefaults()
        If frmMain.clsInstatOptions IsNot Nothing Then
            chkComment.Checked = frmMain.clsInstatOptions.bIncludeCommentDefault
        Else
            chkComment.Checked = True
        End If
        SetCommentEditable()
        'TODO default text should be translatable
        'This is needed only so that the designer displays correctly in VS
        If frmMain.clsInstatOptions IsNot Nothing Then
            txtComment.Text = ParentForm.Name & " " & frmMain.clsInstatOptions.strComment & " " & ParentForm.Text
        Else
            txtComment.Text = ParentForm.Name & " " & ParentForm.Text
        End If
    End Sub

    Private Sub cmdPaste_Click(sender As Object, e As EventArgs) Handles cmdPaste.Click
        Scripts(bRun:=False)
    End Sub

    Private Sub chkComment_CheckedChanged(sender As Object, e As EventArgs) Handles chkComment.CheckedChanged
        SetCommentEditable()
    End Sub

    Private Sub SetCommentEditable()
        txtComment.Enabled = chkComment.Checked
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        HelpContent()
    End Sub

    Private Sub HelpContent()
        If iHelpTopicID > 0 Then
            Help.ShowHelp(Me.Parent, frmMain.strStaticPath & "\" & frmMain.strHelpFilePath, HelpNavigator.TopicId, iHelpTopicID.ToString())
        Else
            Help.ShowHelp(Me.Parent, frmMain.strStaticPath & "\" & frmMain.strHelpFilePath, HelpNavigator.TableOfContents)
        End If
    End Sub
End Class