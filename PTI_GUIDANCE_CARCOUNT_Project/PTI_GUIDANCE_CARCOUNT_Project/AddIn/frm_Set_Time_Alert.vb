Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_Set_Time_Alert

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If btn_Save.Text = "แก้ไข" Then
            btn_Save.Text = "บันทึก"
            msk_Alert.Enabled = True
            msk_Alert.Focus()

        Else
            If msk_Alert.Text.Trim = "" Then
                MessageBox.Show("กรุณา ป้อนต้วเลข เวลาที่ต้องการแจ้งเตือน รถจอดเกินเวลาที่กำหนด", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                msk_Alert.Focus()
                Exit Sub
            End If

            Try
                Excute_SQL(ConStr_Master, "delete from Mas_Hour_Alert ")
                Excute_SQL(ConStr_Master, "insert into Mas_Hour_Alert values (1," & msk_Alert.Text.Trim & ") ")
                If Result_SQL = True Then
                    MessageBox.Show("บันทึกข้อมูลเสร็จเรียบร้อย !!!!  " & vbNewLine & "เมื่อบันทึกข้อมูลเสร็จ หน้าต้างนี้จะถูกปิดลง อัตโนมัติ ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Guidance_Log_User_Process(CurUser_ID, My.Computer.Name, "Edit", Me.Name, "แก้ไข เวลาแจ้งเตือน รถจอดเกินเวลา")

            Catch ex As Exception

            End Try

            btn_Save.Text = "แก้ไข"
            msk_Alert.Enabled = False
            Me.Close()

        End If
    End Sub

    Private Sub frm_Set_Time_Alert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Show_Hour_Alert()
    End Sub

    Sub Show_Hour_Alert()
        '      SELECT  HH_ID]
        '    ,[HH_Alert]
        'FROM [Mas_Hour_Alert]


        Dim sql As String = ""
        Try
            Con = New SqlConnection(ConStr_Master)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Master
                .Open()
            End With
        Catch ex As Exception

        End Try


        Try
            sql &= " SELECT  HH_ID"
            sql &= " ,[HH_Alert]"
            sql &= " FROM [Mas_Hour_Alert]"
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Mas_Hour_Alert")
            Con.Close()
            If sqlDs.Tables("Mas_Hour_Alert").Rows.Count <> 0 Then
                msk_Alert.Text = "" & sqlDs.Tables("Mas_Floor").Rows(0)(1).ToString()
            End If
        Catch ex As Exception
            Con.Close()
            msk_Alert.Text = "1"
        End Try

    End Sub

End Class