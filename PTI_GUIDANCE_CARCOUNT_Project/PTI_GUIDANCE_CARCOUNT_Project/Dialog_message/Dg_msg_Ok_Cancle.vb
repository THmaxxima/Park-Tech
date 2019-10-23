Imports System.Windows.Forms

Public Class Dg_msg_Ok_Cancle
    Public message As String = ""
    Public Auto_close_form As Integer = 0
    Dim i As Integer = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dg_msg_Login_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            OK_Button_Click(e, Nothing)
        End If
        If e.KeyCode = Keys.Escape Then
            Cancel_Button_Click(e, Nothing)
        End If
    End Sub

    Private Sub Dg_msg_Login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Lb_message.Text = message
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Auto_close_form > 0 Then
            If i >= Auto_close_form Then
                OK_Button_Click(e, Nothing)
            Else
                i = i + 1
            End If
        End If
    End Sub
End Class
