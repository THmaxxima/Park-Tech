Public Class Frm_change_language
    Dim cdb As New CDatabase
    Dim dt As DataTable
    Private Sub Frm_change_language_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        load_lange()
    End Sub
    Sub load_lange()
        Dim sql As String = ""
        sql = "SELECT * FROM LANG_Select"
        dt = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(1).ToString = "EN" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            End If
            If dt.Rows(0).Item(1).ToString = "TH" Then
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        If RadioButton1.Checked = True Then
            set_lange("EN")
        End If
        If RadioButton2.Checked = True Then
            set_lange("TH")
        End If

        Button1.Enabled = True
    End Sub
    Sub set_lange(ByVal lange As String)
        Dim sql As String = ""
        Try
            sql = "UPDATE [LANG_Select] SET [Lang_Select]='" & lange & "' WHERE Id_='1'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                If MsgBox("อัพเดตภาษาแล้ว จะทำการรีสตาร์ทโปรแกรมเพื่อให้การตั้งค่าแสดงผล ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Process.Start(Application.StartupPath & "/openCloseSoftware.bat")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class