Public Class frm_Parking_Quitity

    Private Sub frm_Parking_Quitity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        'msk_Fashion.Text = FormatNumber(Report.Get_Car_Parking(msk_Fashion.Tag), 0)
        'msk_Promenade.Text = FormatNumber(Report.Get_Car_Parking(msk_Promenade.Tag), 0)

    End Sub
   
    Private Sub btn_Fashion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Fashion.Click
        Try
            Dim TrnFlg As Boolean
            Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

            'sql = "Update Mas_Car_Parking  set Car_Parking =" & NumberONLY(msk_Fashion.Text) & _
            '" where ID = " & msk_Fashion.Tag & ""
            If OpenCnn(ConnStrMasTer, Conn) Then
                Conn.BeginTrans()
                TrnFlg = True
                Conn.Execute(sql)
                If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                    Conn.CommitTrans()
                Else
                    Conn.RollbackTrans()
                    TrnFlg = False
                End If
               
            End If
            Conn = Nothing
            rs = Nothing
        Catch ex As Exception
            'Finally
            'Call mError.ShowError(Me.Name, "Mas_Staion_Company", Err.Number, Err.Description)
        End Try
        'msk_Fashion.Text = FormatNumber(Report.Get_Car_Parking(msk_Fashion.Tag), 0)
        If IsLog_Process Then Call mUser.Log_User_Process(CurUser_ID, Me.Tag, "FROM", "บันทึกขอมูลจำนวนรถ" & GroupBox2.Text, Me.Name, "2000" & Me.Tag, "", "")

    End Sub

    'Private Sub btn_Promenade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Promenade.Click
    '    Try
    '        Dim TrnFlg As Boolean
    '        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

    '        sql = "Update Mas_Car_Parking  set Car_Parking =" & NumberONLY(msk_Promenade.Text) & _
    '              " where ID = " & msk_Promenade.Tag & ""
    '        If OpenCnn(ConnStrMasTer, Conn) Then
    '            Conn.BeginTrans()
    '            TrnFlg = True
    '            Conn.Execute(sql)
    '            If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
    '                Conn.CommitTrans()
    '            Else
    '                Conn.RollbackTrans()
    '                TrnFlg = False
    '            End If

    '        End If
    '        Conn = Nothing
    '        rs = Nothing
    '    Catch ex As Exception
    '        'Finally
    '        'Call mError.ShowError(Me.Name, "Mas_Staion_Company", Err.Number, Err.Description)
    '    End Try
    '    msk_Promenade.Text = FormatNumber(Report.Get_Car_Parking(msk_Promenade.Tag), 0)
    '    If IsLog_Process Then Call mUser.Log_User_Process(CurUser_ID, Me.Tag, "FROM", "บันทึกขอมูลจำนวนรถ" & GroupBox1.Text, Me.Name, "2000" & Me.Tag, "", "")

    'End Sub

    Private Sub msk_Fashion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_Fashion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Fashion.Focus()
        End If
    End Sub
    Private Sub msk_Promenade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_Promenade.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Promenade.Focus()
        End If
    End Sub
End Class