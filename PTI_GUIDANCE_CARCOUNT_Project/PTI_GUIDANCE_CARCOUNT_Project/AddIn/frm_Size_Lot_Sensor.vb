Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_Size_Lot_Sensor
    Dim btn_label As PictureBox
    Dim Tmp_Save_Pict As String
    Dim CDB As New CDatabase

    Private Sub frm_Size_Lot_Sensor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Size_Lot()

        msk_X.Enabled = True
        msk_Y.Enabled = True
        msk_X.Focus()
    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        'If btn_Save.Text = "Update" Then
        '    btn_Save.Text = "บันทึก"
        '    msk_X.Enabled = True
        '    msk_Y.Enabled = True
        '    msk_X.Focus()

        'Else
        If msk_X.Text.Trim = "" Then
            MessageBox.Show("กรุณา ป้อนต้วเลขขนาด Ultrasonic SIZE : X  ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            msk_X.Focus()
            Exit Sub
        End If
        If msk_Y.Text.Trim = "" Then
            MessageBox.Show("กรุณา ป้อนต้วเลขขนาด Ultrasonic SIZE : Y  ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            msk_Y.Focus()
            Exit Sub
        End If
        Try
            Dim sql As String = ""
            sql = "delete from Mas_Size_Lot"
            If CDB.ExcuteNoneQury(sql, ConStr_Master) = True Then
               
            End If
            sql = "insert into Mas_Size_Lot values (1," & msk_X.Text.Trim & "," & msk_Y.Text.Trim & ",null)"
            If CDB.ExcuteNoneQury(sql, ConStr_Master) = True Then

                If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Size_Lot", "ID", "Size_Image", "1", Tmp_Save_Pict) 'Tmp_Save_Pict
                Tmp_Save_Pict = ""
                set_lot_size()
                MsgBox(msg_save(0))
            Else
                MsgBox(msg_save(1))
            End If


            'If Result_SQL = True Then
            '    MessageBox.Show("บันทึกข้อมูลเสร็จเรียบร้อย !!!!  " & vbNewLine & "เมื่อบันทึกข้อมูลเสร็จ หน้าต้างนี้จะถูกปิดลง อัตโนมัติ ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            Guidance_Log_User_Process(CurUser_ID, My.Computer.Name, "Edit", Me.Name, "แก้ไขขนาด Ultrasonic X = " & msk_X.Text & " และ Y = " & msk_Y.Text & "")

            'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
            'Tmp_Save_Pict = ""
        Catch ex As Exception

        End Try

        'btn_Save.Text = "Update"
        'msk_X.Enabled = False
        'msk_Y.Enabled = False
        'Me.Close()

        'End If
    End Sub
    Sub set_lot_size()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM Mas_Size_Lot"
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                lot_size_x = dt.Rows(0).Item("Size_X").ToString
                lot_size_y = dt.Rows(0).Item("Size_Y").ToString
                Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                Dim PictureData() As Byte = RetByte
                Dim Ms As New System.IO.MemoryStream(PictureData)
                lot_size_image = Image.FromStream(Ms)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Size_Lot()
        Dim sql As String = ""
        Try
            sql &= " SELECT [ID]"
            sql &= ",[Size_X]"
            sql &= ",[Size_Y]"
            sql &= ",[Size_Image]"
            sql &= "FROM [Mas_Size_Lot]"
   
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)

            If dt.Rows.Count > 0 Then
                msk_X.Text = dt.Rows(0).Item("Size_X").ToString
                msk_Y.Text = dt.Rows(0).Item("Size_Y").ToString
                If IsDBNull(dt.Rows(0).Item("Size_Image")) = False Then
                    Tmp_Save_Pict = dt.Rows(0).Item("ID").ToString
                    Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                    Dim PictureData() As Byte = RetByte
                    Dim Ms As New System.IO.MemoryStream(PictureData)
                    PictureBox1.BackgroundImage = Image.FromStream(Ms)
                    PictureBox1.BackColor = Color.Transparent
                    'PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                Else
                    Tmp_Save_Pict = ""
                End If
            End If

        Catch ex As Exception

            'msk_X.Text = ""
            'msk_Y.Text = ""
        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Panel1.Controls.Clear()
        
        btn_label = New PictureBox
        With btn_label
            .BackColor = Color.Black
            If Tmp_Save_Pict <> "" Then
                .BackgroundImage = PictureBox1.BackgroundImage
                .BackColor = Color.Transparent
                .BackgroundImageLayout = ImageLayout.Zoom
            End If
            .Size = New System.Drawing.Size(CInt(msk_X.Text), CInt(msk_Y.Text))
            .Location = New System.Drawing.Point((Panel1.Width / 2) - (.Width / 2), (Panel1.Height / 2) - (.Height / 2))
            .Text = ""
            .Tag = Tag
            .Name = "ex"
            'Pic_ID_2.Controls.Add(btn_label)
            Panel1.Controls.Add(btn_label)
            .BringToFront()
            Application.DoEvents()
        End With

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg,*.png)|*.bmp;*.gif;*.jpg;*.JPEG;*.PNG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict = .FileName : PictureBox1.Visible = True
            'PictureBox1.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)
            If Tmp_Save_Pict <> "" Then
                PictureBox1.BackColor = Color.Transparent
                'PictureBox1.BackColor = Color.Crimson
                PictureBox1.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict)
                PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Add_Picture_Click", Err.Number, Err.Description)
    End Sub
End Class