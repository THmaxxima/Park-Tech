Public Class frm_With_Parktech

    Private Sub frm_With_Mecomb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If IsLog_Process Then Call mUser.Guidance_Log_User_Process(CurUser_ID, Me.Tag, "FROM", "เรียกดู : " & Me.Text, Me.Name)

    End Sub
End Class