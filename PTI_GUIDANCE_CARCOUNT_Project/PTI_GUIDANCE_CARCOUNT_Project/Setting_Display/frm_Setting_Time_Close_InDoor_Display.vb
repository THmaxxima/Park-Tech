Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_Setting_Time_Close_InDoor_Display
    Dim HH_Start As String
    Dim MM_Start As String
    Dim SS_Start As String
    Dim HH_End As String
    Dim MM_End As String
    Dim SS_End As String

    Sub Load_Mas_Turn_Off_LED()

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

            sql &= " SELECT  * FROM  Mas_Turn_Off_LED "
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Mas_Turn_Off_LED")
            Con.Close()
            If sqlDs.Tables("Mas_Turn_Off_LED").Rows.Count <> 0 Then

                HH_Start = "" & sqlDs.Tables("Mas_Turn_Off_LED").Rows(0)(1).ToString()
                MM_Start = "" & sqlDs.Tables("Mas_Turn_Off_LED").Rows(0)(2).ToString()
                SS_Start = "" & sqlDs.Tables("Mas_Turn_Off_LED").Rows(0)(3).ToString()

                HH_End = "" & sqlDs.Tables("Mas_Turn_Off_LED").Rows(0)(4).ToString()
                MM_End = "" & sqlDs.Tables("Mas_Turn_Off_LED").Rows(0)(5).ToString()
                SS_End = "" & sqlDs.Tables("Mas_Turn_Off_LED").Rows(0)(6).ToString()

                TStart.Value = Now.ToShortDateString & " " & HH_Start & ":" & MM_Start & ":" & SS_Start
                TEnd.Value = Now.ToShortDateString & " " & HH_End & ":" & MM_End & ":" & SS_End

            End If
        Catch ex As Exception
            Con.Close()

        End Try

    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Dim sql As String = ""
        Dim SQL_VALUE As String = ""

        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.Text = "บันทึก"
            TStart.Enabled = True
            TEnd.Enabled = True
            TStart.Focus()
        Else

            If MessageBox.Show("คุณต้องการแก้ไข ข้อมูลนี้ใช้หรือไม่ ??? ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Me.Close()
                Exit Sub
            End If

            Try
                Excute_SQL(ConStr_Master, "delete from Mas_Turn_Off_LED where ID = 2 ")
                sql &= "" & " insert into Mas_Turn_Off_LED ("
                sql &= "[ID]"
                SQL_VALUE &= "" & " Values ( " & "2"

                sql &= ",[HH_Start]"
                SQL_VALUE &= "," & TStart.Value.Hour & ""

                sql &= ",[MM_Start]"
                SQL_VALUE &= "," & TStart.Value.Minute & ""

                sql &= ",[SS_Start]"
                SQL_VALUE &= "," & TStart.Value.Second & ""

                sql &= ",[HH_End]"
                SQL_VALUE &= "," & TEnd.Value.Hour & ""

                sql &= ",[MM_End]"
                SQL_VALUE &= "," & TEnd.Value.Minute & ""

                sql &= ",[SS_End]"
                SQL_VALUE &= "," & TEnd.Value.Second & ""

                sql &= ",[Flag_Update] ) "
                SQL_VALUE &= ",1 )"

                Excute_SQL(ConStr_Master, sql & SQL_VALUE)

                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TStart.Value.Hour & "' , Status ='1' where Address ='2510'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TStart.Value.Minute & "' , Status ='1'  where Address ='2511'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TEnd.Value.Hour & "' , Status ='1'  where Address ='2512'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TEnd.Value.Minute & "' , Status ='1'  where Address ='2513'")

                If Result_SQL = True Then
                    MessageBox.Show("บันทึกข้อมูลเสร็จเรียบร้อย !!!!  " & vbNewLine & "เมื่อบันทึกข้อมูลเสร็จ หน้าต้างนี้จะถูกปิดลง อัตโนมัติ ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Guidance_Log_User_Process(CurUser_ID, My.Computer.Name, "Edit", Me.Name, "แก้ไขเวลาเปิด - ปิด Ultrasonic and Display")

            Catch ex As Exception

            End Try

            btn_Edit.Text = "แก้ไข"
            TStart.Enabled = False
            TEnd.Enabled = False
            Me.Close()

        End If
    End Sub

    Private Sub frm_Setting_Time_Close_InDoor_Display_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class