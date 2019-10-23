Public Class frm_Setting_Car_Controller

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frm_Setting_Car_Controller_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mMain.Load_AppConfig()

    End Sub

    Private Sub btn_Set1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set1.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 1 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN1.Checked = True Then
                Type = rdo_IN1.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN1.Tag & "," & Msk_Set1.Text & ")"
                'UpdateMaster(sql)
            End If

            If rdo_OUT1.Checked = True Then
                Type = rdo_OUT1.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT1.Tag & "," & Msk_Set1.Text & ")"
                'UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 1 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set2.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 2 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN2.Checked = True Then
                Type = rdo_IN2.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN2.Tag & "," & Msk_Set2.Text & ")"
                'UpdateMaster(sql)
            End If

            If rdo_OUT2.Checked = True Then
                Type = rdo_OUT2.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT2.Tag & "," & Msk_Set2.Text & ")"
                'UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 2 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set3.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 3 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN3.Checked = True Then
                Type = rdo_IN3.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN3.Tag & "," & Msk_Set3.Text & ")"
                'UpdateMaster(sql)
            End If

            If rdo_OUT3.Checked = True Then
                Type = rdo_OUT3.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT3.Tag & "," & Msk_Set3.Text & ")"
                'UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 3 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set4.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 4 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN4.Checked = True Then
                Type = rdo_IN4.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN4.Tag & "," & Msk_Set4.Text & ")"
                'UpdateMaster(sql)
            End If

            If rdo_OUT4.Checked = True Then
                Type = rdo_OUT4.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT4.Tag & "," & Msk_Set4.Text & ")"
                'UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 4 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set5.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 5 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN5.Checked = True Then
                Type = rdo_IN5.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN5.Tag & "," & Msk_Set5.Text & ")"
                'UpdateMaster(sql)
            End If

            If rdo_OUT5.Checked = True Then
                Type = rdo_OUT5.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT5.Tag & "," & Msk_Set5.Text & ")"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 5 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set6.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 6 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN6.Checked = True Then
                Type = rdo_IN6.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN6.Tag & "," & Msk_Set6.Text & ")"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT6.Checked = True Then
                Type = rdo_OUT6.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT6.Tag & "," & Msk_Set6.Text & ")"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 6 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset1.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 1 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN1.Checked = True Then
                Type = rdo_IN1.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN1.Tag & ",0)"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT1.Checked = True Then
                Type = rdo_OUT1.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT1.Tag & ",0)"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 1 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset2.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 2 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN2.Checked = True Then
                Type = rdo_IN2.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN2.Tag & ",0)"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT2.Checked = True Then
                Type = rdo_OUT2.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT2.Tag & ",0)"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 2 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset3.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 3 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN3.Checked = True Then
                Type = rdo_IN3.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN3.Tag & ",0)"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT3.Checked = True Then
                Type = rdo_OUT3.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT3.Tag & ",0)"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 3 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset4.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 4 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN4.Checked = True Then
                Type = rdo_IN4.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN4.Tag & ",0)"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT4.Checked = True Then
                Type = rdo_OUT4.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT4.Tag & ",0)"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 4 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset5.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 5 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN5.Checked = True Then
                Type = rdo_IN5.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN5.Tag & ",0)"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT5.Checked = True Then
                Type = rdo_OUT5.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT5.Tag & ",0)"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 5 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset6.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 6 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN6.Checked = True Then
                Type = rdo_IN6.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN6.Tag & ",0)"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT6.Checked = True Then
                Type = rdo_OUT6.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT6.Tag & ",0)"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 6 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set7.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 7 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN7.Checked = True Then
                Type = rdo_IN7.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN7.Tag & "," & Msk_Set7.Text & ")"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT7.Checked = True Then
                Type = rdo_OUT7.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT7.Tag & "," & Msk_Set7.Text & ")"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 7 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set8.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 8 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN8.Checked = True Then
                Type = rdo_IN8.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN8.Tag & "," & Msk_Set8.Text & ")"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT8.Checked = True Then
                Type = rdo_OUT8.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT8.Tag & "," & Msk_Set8.Text & ")"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 8 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set9.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 9 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN9.Checked = True Then
                Type = rdo_IN9.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN9.Tag & "," & Msk_Set9.Text & ")"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT9.Checked = True Then
                Type = rdo_OUT9.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT9.Tag & "," & Msk_Set9.Text & ")"
                '' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 9 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set10.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 10 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN10.Checked = True Then
                Type = rdo_IN10.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN10.Tag & "," & Msk_Set10.Text & ")"
                '' UpdateMaster(sql)
            End If

            If rdo_OUT10.Checked = True Then
                Type = rdo_OUT10.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT10.Tag & "," & Msk_Set10.Text & ")"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 10 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set11.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 11 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN11.Checked = True Then
                Type = rdo_IN11.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN11.Tag & "," & Msk_Set11.Text & ")"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT11.Checked = True Then
                Type = rdo_OUT11.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT11.Tag & "," & Msk_Set11.Text & ")"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 11 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Set12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Set12.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการตั้งจำนวนรถจุดที่ 12 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN12.Checked = True Then
                Type = rdo_IN12.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN12.Tag & "," & Msk_Set12.Text & ")"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT12.Checked = True Then
                Type = rdo_OUT12.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT12.Tag & "," & Msk_Set12.Text & ")"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการตั้งค่าจำนวนรถจุดที่ 12 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset7.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 7 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN7.Checked = True Then
                Type = rdo_IN7.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN7.Tag & ",0)"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT7.Checked = True Then
                Type = rdo_OUT7.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT7.Tag & ",0)"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 7 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset8.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 8 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN8.Checked = True Then
                Type = rdo_IN8.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN8.Tag & ",0)"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT8.Checked = True Then
                Type = rdo_OUT8.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT8.Tag & ",0)"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 8 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset9.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 9 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN9.Checked = True Then
                Type = rdo_IN9.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN9.Tag & ",0)"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT9.Checked = True Then
                Type = rdo_OUT9.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT9.Tag & ",0)"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 9 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset10.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 1 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN10.Checked = True Then
                Type = rdo_IN10.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN10.Tag & ",0)"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT10.Checked = True Then
                Type = rdo_OUT10.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT10.Tag & ",0)"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 10 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset11.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 11 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN11.Checked = True Then
                Type = rdo_IN11.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN11.Tag & ",0)"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT11.Checked = True Then
                Type = rdo_OUT11.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT11.Tag & ",0)"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 11 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_Reset12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset12.Click
        Dim Type As String = ""
        Dim sql As String = ""
        If MessageBox.Show("คุณต้องการ Reset ค่าจำนวนรถจุดที่ 12 ให้มีค่า = 0 ใช่หรือไม่ ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            If rdo_IN12.Checked = True Then
                Type = rdo_IN12.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_IN12.Tag & ",0)"
                ' UpdateMaster(sql)
            End If

            If rdo_OUT12.Checked = True Then
                Type = rdo_OUT12.Text
                sql = "insert into Mas_Setting_Car_Pass_Len (Address,value) " & _
                      " values (" & rdo_OUT12.Tag & ",0)"
                ' UpdateMaster(sql)
            End If
            If IsLog_Process Then Call mUser.Log_User_Process _
            (CurUser_ID, Me.Tag, "FROM", "ทำรายการ Reset ค่าจำนวนรถจุดที่ 12 = 0 : " & Type, Me.Name, "2000" & "3000", "", "")
            MessageBox.Show("ทำรายการเสร็จเรียบร้อย", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class