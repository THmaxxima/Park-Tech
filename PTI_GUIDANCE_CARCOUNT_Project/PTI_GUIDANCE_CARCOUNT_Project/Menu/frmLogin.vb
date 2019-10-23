
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Cryptography.Lib
Imports System.Security.Cryptography
Imports System.Xml

Public Class frmLogin
    Public IsOntop As Boolean
    Public MsgScroll As String
    '  Public mAuthen As New nAuthen.cAuthen
    Private Const SWP_NOSIZE As Short = &H1S
    Private Const SWP_NOMOVE As Short = &H2S
    Private Const SWP_NOZORDER As Short = &H4S
    Private Const SWP_NOREDRAW As Short = &H8S
    Private Const SWP_NOACTIVATE As Short = &H10S
    Private Const SWP_FRAMECHANGED As Short = &H20S
    Private Const SWP_SHOWWINDOW As Short = &H40S
    Private Const SWP_HIDEWINDOW As Short = &H80S
    Private Const SWP_NOCOPYBITS As Short = &H100S
    Private Const SWP_NOOWNERZORDER As Short = &H200S
    Private Const SWP_DRAWFRAME As Short = SWP_FRAMECHANGED
    Private Const SWP_NOREPOSITION As Short = SWP_NOOWNERZORDER

    Private Const HWND_TOP As Short = 0
    Private Const HWND_BOTTOM As Short = 1
    Private Const HWND_TOPMOST As Short = -1
    Private Const HWND_NOTOPMOST As Short = -2
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private mbOnTop As Boolean

    Private Property OnTop() As Boolean
        Get
            OnTop = mbOnTop
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                SetWindowPos(Handle.ToInt32, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
            Else
                SetWindowPos(Handle.ToInt32, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
            End If
            mbOnTop = Value
        End Set
    End Property

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If txtPassword.Text.Trim = "" Then Exit Sub
        CurUser_Name = txtUsername.Text
        If Module_Menu_New.Log_In(txtPassword.Text.Trim, txtUsername.Text) = True Then
            Me.Close()
        End If
    End Sub

   
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Dim d As Double
        For d = 1 To 0 + 0.2 Step -0.2
            System.Threading.Thread.Sleep(50)
            Application.DoEvents()
            Me.Opacity = d
            Me.Refresh()
        Next d
        Environment.Exit(0)
        End

    End Sub

    'Private Sub frm_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Call mMain.Load_AppConfig()
    '    lbl_Version.Text = "Version : " & Version
    'End Sub

    Private Sub txtUsername_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text.Trim <> "" Then
            txtUsername.SelectAll()
        End If
    End Sub
    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtPassword.Focus()
            If txtPassword.Text.Trim <> "" Then
                txtPassword.SelectAll()
            End If
        Else
            KeyAscii = 0
        End If
    End Sub
    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text.Trim <> "" Then
            txtPassword.SelectAll()
        End If
    End Sub


    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CDB As New CDatabase
        lbl_Version.Text = "Version : " & My.Application.Info.Version.Major & "." & _
       My.Application.Info.Version.MajorRevision & "." & _
       My.Application.Info.Version.Minor & "." & _
       My.Application.Info.Version.MinorRevision
        Try
            Dim sql As String = ""
            sql = "SELECT [Lang_Select] FROM [LANG_Select] WHERE [Id_]='1'"
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                lang_ = dt.Rows(0).Item(0).ToString
            End If

            read_LANG_obj(lang_, Me, UsernameLabel)
            read_LANG_obj(lang_, Me, PasswordLabel)
            read_LANG_obj(lang_, Me, OK)
            read_LANG_obj(lang_, Me, Cancel)
        Catch ex As Exception

        End Try

    End Sub


    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            'CurUser_Name = txtUsername.Text
            If Log_In(txtPassword.Text.Trim, txtUsername.Text) = True Then
                Me.Close()
            End If
        End If
    End Sub
End Class
