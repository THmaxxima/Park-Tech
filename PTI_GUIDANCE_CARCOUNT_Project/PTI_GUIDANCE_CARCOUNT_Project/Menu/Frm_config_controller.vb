Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class Frm_config_controller
    Dim SqlDt As New DataTable
    Dim SqlDa As SqlDataAdapter
    Dim NewFloor_ID As String
    Dim OpenFileDialog1 As New Object
    Dim Pic_Name As String
    Dim Tmp_Save_Pict As String

    Dim Tmp_Save_Pict1 As String
    Dim Tmp_Save_Pict2 As String
    Dim Tmp_Save_Pict3 As String
    Dim Tmp_Save_Pict_tower As String

    Dim Back_Color As String
    Dim Color_A As Integer
    Dim Color_R As Integer
    Dim Color_G As Integer
    Dim Color_B As Integer
    Dim A, R, G, B As Integer



    Dim HH_Start As String
    Dim MM_Start As String
    Dim SS_Start As String
    Dim HH_End As String
    Dim MM_End As String
    Dim SS_End As String



    Dim cdb As New CDatabase
    Dim dt As DataTable

    Dim btn_label As PictureBox


    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        Dim frm As New frm_Color_History_Standard_4_Color
        With frm
            mForm.Set_Standard_Form(frm)
            '.Text = nfrm_Color_History_Standard_4_Color.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As New Frm_change_language
        With frm
            mForm.Set_Standard_Form(frm)
            '.Text = nfrm_Color_History_Standard_4_Color.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        AddCombo(ConnStrMasTer, Me.cboTowerId, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")
        AddCombo(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "Building_Name", "Building_ID", "", "Building_Name", "ทั้งหมด")

        Call AddListView()

    End Sub
    Sub AddListView()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow

        sql = "SELECT * FROM Mas_Floor "
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    lsv_Mas_HW_Floor.Items.Clear()
                    lsv_Mas_HW_Floor.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Mas_HW_Floor.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        ' tl = rs.RecordCount
                        Dim New_Ent As ListViewItem = lsv_Mas_HW_Floor.Items.Add(rs.Fields("Floor_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("Floor_Name").Value)
                            .SubItems.Add("" & rs.Fields("Tower_Id").Value)
                            .SubItems.Add("" & rs.Fields("Building_ID").Value)
                            .SubItems.Add("" & rs.Fields("Floor_No").Value)
                            .SubItems.Add("" & rs.Fields("Color_floorA").Value)
                            .SubItems.Add("" & rs.Fields("Color_floorR").Value)
                            .SubItems.Add("" & rs.Fields("Color_floorG").Value)
                            .SubItems.Add("" & rs.Fields("Color_floorB").Value)
                        End With
                        .MoveNext()
                    Loop
                Else
                    lsv_Mas_HW_Floor.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "AddListView", Err.Number, Err.Description)
    End Sub


    Private Sub Frm_config_controller_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = 0
        Timer1.Enabled = True
        AddCombo(ConnStrMasTer, Me.ComboBox1, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")
        Load_buiding("")
    End Sub
    Sub Load_buiding(ByVal buiding_id As String)
        Try
            Dim sql As String = ""
            If buiding_id = "" Then
                sql = "SELECT * FROM [dbo].[V_Mas_Building_Parking] ORDER BY [Building_ID]"
            Else
                sql = "SELECT * FROM [dbo].[Mas_Building_Parking] "
                sql &= " WHERE [Building_ID]='" & buiding_id & "'"
                sql &= " ORDER BY [Building_ID] "
            End If
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                DataGridView1.Rows.Clear()
                For i As Integer = 0 To DT.Rows.Count - 1
                    DataGridView1.Rows.Add(DT.Rows(i).Item("Building_ID").ToString, DT.Rows(i).Item("Building_Name").ToString, DT.Rows(i).Item("Tower_ID").ToString, DT.Rows(i).Item("Tower_Name").ToString)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_Add_Click(sender As System.Object, e As System.EventArgs) Handles btn_Add.Click
        If btn_Add.Text = "เพิ่ม" Then
            lbl_Floor_Id.Text = Function_New_Floor_ID()
            txt_Floor_Name.Enabled = True
            txt_Floor_Name.Focus()
            btn_Edit.Enabled = False
            btn_Add.ImageList = Me.img_SaveAdd
            Picture_Floor.Image = Picture_Floor.ErrorImage
            btn_Add_Picture.Enabled = True
            Button1.Enabled = True
            btn_Delete_Picture.Enabled = True
            msk_Floor_No.Enabled = True
            cmb_Building.Enabled = True
            cboTowerId.Enabled = True

            btn_Add.Text = "บันทึก"

        Else
            If cboTowerId.SelectedIndex <= 0 Then
                MsgBox("กรุณาป้อนเลือกสถานที่ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                cboTowerId.Focus()
                Exit Sub
            End If
            If cmb_Building.SelectedIndex <= 0 Then
                MsgBox("กรุณาป้อนเลือกอาคารจอดรถ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                cmb_Building.Focus()
                Exit Sub
            End If
            If txt_Floor_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อชั้นจอดรถ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Floor_Name.Focus()
                Exit Sub
            End If
            If msk_Floor_No.Text = "" Then
                If IsNumeric(msk_Floor_No) = False Then
                    MsgBox("กรุณาป้อนหมายเลขชั้น เป็นตัวเลข ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                Else
                    MsgBox("กรุณาป้อนหมายเลขชั้น ให้ถูกต้อง ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                End If
                msk_Floor_No.Focus()
                Exit Sub
            End If

            Call Save_Mas_HW_Floor()
            Call AddListView()
            txt_Floor_Name.Enabled = False
            btn_Edit.Enabled = True
            txt_Floor_Name.Clear()
            Picture_Floor.Controls.Clear()
            btn_Add_Picture.Enabled = False
            Button1.Enabled = False
            btn_Delete_Picture.Enabled = False
            btn_Add.Text = "เพิ่ม"
            btn_Add.ImageList = Me.img_Add
        End If
    End Sub
    Private Function Function_New_Floor_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(Floor_Id) from Mas_Floor"
            'Dim sql As String = "select TOP 1 Floor_Id from Mas_HW_Floor ORDER BY Floor_Id"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        F_ID = .Fields(0).Value.ToString
                        F_ID = F_ID + 1
                    End If
                End With
            End If
        Catch ex As Exception
            F_ID = "1"
        End Try
        Return F_ID
    End Function
    Sub Save_Mas_HW_Floor()
        Dim sql As String
        Dim TrnFlg As Boolean
        TrnFlg = True
        sql = "" & " Insert into Mas_Floor "
        sql &= "([Floor_Id]"
        sql &= ",[Tower_Id]"
        sql &= ",[Building_ID]"
        sql &= ",[Floor_No]"
        sql &= ",[Floor_Name]"
        sql &= ",[Color_floorA]"
        sql &= ",[Color_floorR]"
        sql &= ",[Color_floorG]"
        sql &= ",[Color_floorB]"
        sql &= " ) Values("
        sql &= "" & lbl_Floor_Id.Text & ""
        sql &= "," & cboTowerId.SelectedValue & ""
        sql &= "," & cmb_Building.SelectedValue & ""
        sql &= ",'" & msk_Floor_No.Text & "'"
        sql &= ",'" & txt_Floor_Name.Text & "'"
        sql &= ",'" & Color_A & "'"
        sql &= ",'" & Color_R & "'"
        sql &= ",'" & Color_G & "'"
        sql &= ",'" & Color_B & "')"

        If MsgBox("คุณต้องการบันทึกข้อมูลนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
                Dim imgData As Image = Picture_Floor.Image
                cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict_tower, imgData)

                Tmp_Save_Pict = ""
                MsgBox(msg_save(0))
            Else
                Tmp_Save_Pict = ""
                MsgBox(msg_save(1))
            End If

        End If

        Exit Sub
Err_Renamed:
        ' If TrnFlg = True Then Conn.RollbackTrans()

        Call mError.ShowError(Me.Name, "Save_Mas_Floor", Err.Number, Err.Description)
    End Sub
    Private Sub btn_Delete_Click(sender As System.Object, e As System.EventArgs) Handles btn_Delete.Click
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_Floor WHERE Floor_Id = '" & lbl_Floor_Id.Text & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส : " & lbl_Floor_Id.Text & vbCrLf & _
                        "ชั้น : " & txt_Floor_Name.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call AddListView()
                MsgBox(msg_delete(0))
            Else

                Conn.RollbackTrans()
                MsgBox(msg_delete(1))
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Floor", Err.Number, Err.Description)
    End Sub
    Private Sub btn_Edit_Click(sender As System.Object, e As System.EventArgs) Handles btn_Edit.Click
        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.ImageList = Me.img_Edit
            msk_Floor_No.Enabled = True
            btn_Add.Enabled = False
            btn_Delete.Enabled = False

            btn_Add_Picture.Enabled = True
            Button1.Enabled = True
            txt_Floor_Name.Enabled = True
            btn_Delete_Picture.Enabled = True
            txt_Floor_Name.Focus()
            cmb_Building.Enabled = True
            cboTowerId.Enabled = True
            btn_Edit.Text = "บันทึก"
            btn_Edit.ImageList = Me.img_Save

        Else

            If cboTowerId.SelectedIndex <= 0 Then
                MsgBox("กรุณาป้อนเลือกสถานที่ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                cboTowerId.Focus()
                Exit Sub
            End If
            If cmb_Building.SelectedIndex <= 0 Then
                MsgBox("กรุณาป้อนเลือกอาคารจอดรถ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                cmb_Building.Focus()
                Exit Sub
            End If
            If txt_Floor_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อชั้นจอดรถ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Floor_Name.Focus()
                Exit Sub
            End If
            If msk_Floor_No.Text = "" Then
                MsgBox("กรุณาป้อนหมายเลขชั้น ให้ถูกต้อง ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                msk_Floor_No.Focus()
                Exit Sub
            End If


            Call Save_Edit_Floor_Name()

            Call AddListView()
            txt_Floor_Name.Clear()
            txt_Floor_Name.Enabled = False
            btn_Add.Enabled = True
            btn_Delete.Enabled = True
            btn_Add_Picture.Enabled = False
            Button1.Enabled = False
            btn_Delete_Picture.Enabled = False
            btn_Edit.Text = "แก้ไข"
            btn_Edit.ImageList = Me.img_Edit
        End If

    End Sub
    Sub Save_Edit_Floor_Name()
        On Error GoTo Err
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "Update Mas_Floor set Floor_Name ='" & txt_Floor_Name.Text & "'"
        sql &= ",Color_floorA = '" & Color_A & "'"
        sql &= ",Color_floorR = '" & Color_R & "'"
        sql &= ",Color_floorG = '" & Color_G & "'"
        sql &= ",Color_floorB = '" & Color_B & "'"

        sql &= " where Floor_Id = '" & lbl_Floor_Id.Text & "'"

        If MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes Then
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                TrnFlg = True

                'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict_tower) 'Tmp_Save_Pict

                'If Not (Tmp_Save_Pict_tower = "") Then Call cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict_tower) 'Tmp_Save_Pict
                'Tmp_Save_Pict_tower = ""

                Dim imgData As Image = Picture_Floor.Image

                cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict_tower, imgData)
                'Dim cmd As New SqlCommand()
                'SqlCommand.Parameters("@photo").Value = imgData

                'MsgBox("อัพเดตข้อมูลแล้ว")
                MsgBox(msg_update(0))
            Else
                'MsgBox("ข้อมูลไม่ถูกอัพเดต")
                MsgBox(msg_update(1))
                TrnFlg = False
            End If

        End If



        'If OpenCnn(ConnStrMasTer, Conn) Then
        '    Conn.BeginTrans()
        '    TrnFlg = True
        '    Conn.Execute(sql)
        '    If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
        '        Conn.CommitTrans()
        '        MsgBox("อัพเดตข้อมูลแล้ว")
        '        'Exit Sub
        '    Else
        '        Conn.RollbackTrans()
        '        MsgBox("ข้อมูลไม่ถูกอัพเดต")
        '        TrnFlg = False
        '    End If
        '    If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
        '    Tmp_Save_Pict = ""

        'End If
        'Conn = Nothing
        'rs = Nothing
        'Exit Sub
Err:
        'Call mError.ShowError(Me.Name, "Save_Edit_Floor_Name", Err.Number, Err.Description)
    End Sub
    Private Sub btn_Cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_Cancel.Click
        Call default_Object()
    End Sub
    Sub default_Object()
        btn_Edit.Text = "แก้ไข"
        btn_Add.Text = "เพิ่ม"
        lbl_Floor_Id.Text = ""
        txt_Floor_Name.Clear()
        txt_Floor_Name.Enabled = False
        cboTowerId.SelectedIndex = 0
        btn_Edit.Enabled = True
        btn_Add.Enabled = True
        btn_Delete.Enabled = True
        btn_Edit.ImageList = Me.img_Edit
        btn_Add.ImageList = Me.img_Add
        btn_Add_Picture.Enabled = False
        Button1.Enabled = False
        btn_Delete_Picture.Enabled = False
        msk_Floor_No.Enabled = False
        msk_Floor_No.Clear()
    End Sub
    Private Sub btn_Add_Picture_Click(sender As System.Object, e As System.EventArgs) Handles btn_Add_Picture.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.JPEG;*.PNG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict_tower = .FileName : Picture_Floor.Visible = True
            If Tmp_Save_Pict_tower <> "" Then
                Picture_Floor.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict_tower)
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Add_Picture_Click", Err.Number, Err.Description)
    End Sub
    Private Sub btn_Delete_Picture_Click(sender As System.Object, e As System.EventArgs) Handles btn_Delete_Picture.Click
        Picture_Floor.Image = Picture_Floor.ErrorImage
        Tmp_Save_Pict = "Null"
        lbl_Pic.Text = ""
        Tmp_Save_Pict = ""
    End Sub
    Private Sub lsv_Mas_HW_Floor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_HW_Floor.MouseClick
        Try

        
        With lsv_Mas_HW_Floor
            lbl_Floor_Id.Text = .FocusedItem.SubItems(0).Text
            txt_Floor_Name.Text = .FocusedItem.SubItems(1).Text
            cboTowerId.SelectedValue = .FocusedItem.SubItems(2).Text
            cmb_Building.SelectedValue = .FocusedItem.SubItems(3).Text
            msk_Floor_No.Text = .FocusedItem.SubItems(4).Text

            If .FocusedItem.SubItems(5).Text = "" Then
                A = 0
            Else
                A = .FocusedItem.SubItems(5).Text
            End If
            If .FocusedItem.SubItems(6).Text = "" Then
                R = 0
            Else
                R = .FocusedItem.SubItems(6).Text
            End If

            If .FocusedItem.SubItems(7).Text = "" Then
                G = 0
            Else
                G = .FocusedItem.SubItems(7).Text
            End If
            If .FocusedItem.SubItems(8).Text = "" Then
                B = 0
            Else
                B = .FocusedItem.SubItems(8).Text
            End If
            Color_A = A
            Color_R = R
            Color_G = G
            Color_B = B
            Label20.BackColor = Color.FromArgb(A, R, G, B)
        End With

        Me.Picture_Floor.Controls.Clear()
            Call Show_Picture(lsv_Mas_HW_Floor.FocusedItem.Text)
        Catch ex As Exception

        End Try
    End Sub
    Sub Select_Picture_Floor()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        On Error GoTo Err_Renamed
        sql = "select Floor_Image from Mas_Floor where Floor_Id =" & Trim(lsv_Mas_HW_Floor.FocusedItem.SubItems(0).Text) & ""
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then

                    .MoveFirst()
                    Do While Not .EOF
                        Picture_Floor.Image = rs.Fields("Floor_Image")
                        .MoveNext()
                    Loop
                Else

                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Select_Picture_Floor", Err.Number, Err.Description)
        'End If
    End Sub
    Function Show_Picture(ByVal ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Picture_Floor.Controls.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select * from Mas_Floor WHERE Floor_Id = " & lsv_Mas_HW_Floor.FocusedItem.SubItems(0).Text & ""
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    If Not IsDBNull(.Fields("Floor_Image").Value) Then
                        Dim RetByte() As Byte = CType(.Fields("Floor_Image").Value, Byte())
                        Dim PictureData() As Byte = RetByte
                        Dim Ms As New System.IO.MemoryStream(PictureData)
                        Picture_Floor.Image = Image.FromStream(Ms)
                    Else
                        Picture_Floor.Image = Picture_Floor.ErrorImage
                    End If

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Else
                    rs.Close() : Return False
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default : Me.Enabled = True : Exit Function
                End If
            End With
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Return True

        Exit Function
Err:

        Call mError.ShowError(Me.Name, "Show_Picture", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Return False
    End Function

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Call lsv_Select_Mas_Alam_View()
        Call Style_ListView()
    End Sub
    Sub lsv_Select_Mas_Alam_View()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Row_Color As String
        sql = "SELECT * FROM Mas_Status_Alarm "
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    If .RecordCount = 13 Then
                        btn_Add_Alam.Visible = False
                    Else
                        btn_Add_Alam.Visible = True
                    End If
                    lsv_Mas_Alam.Items.Clear()
                    lsv_Mas_Alam.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Mas_Alam.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        Dim New_Ent As ListViewItem = lsv_Mas_Alam.Items.Add(rs.Fields("Status_Alarm_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("Status_Alarm_Name").Value)
                            .SubItems.Add("" & rs.Fields("Status_Alarm_Color_A").Value)
                            .SubItems.Add("" & rs.Fields("Status_Alarm_Color_R").Value)
                            .SubItems.Add("" & rs.Fields("Status_Alarm_Color_G").Value)
                            .SubItems.Add("" & rs.Fields("Status_Alarm_Color_B").Value)
                        End With
                        Tmp_Save_Pict = ""
                        If rs.Fields("Status_visible").Value.ToString = "1" Then
                            CheckBox1.Checked = True
                        Else
                            CheckBox1.Checked = False
                        End If
                        .MoveNext()
                    Loop

                Else
                    lsv_Mas_Alam.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "lsv_Select_Mas_Alam_View", Err.Number, Err.Description)
    End Sub
    Sub Style_ListView()
        Dim i As Integer
        Try
            For i = 0 To (lsv_Mas_Alam.Items.Count - 1)
                With lsv_Mas_Alam
                    If .Items(i).SubItems(2).Text.ToString <> "" And .Items(i).SubItems(3).Text.ToString <> "" Then
                        A = .Items(i).SubItems(2).Text.ToString
                        R = .Items(i).SubItems(3).Text.ToString
                        G = .Items(i).SubItems(4).Text.ToString
                        B = .Items(i).SubItems(5).Text.ToString
                        .Items(i).ForeColor = Color.FromArgb(A, R, G, B)
                    Else
                        .Items(i).ForeColor = Color.FromArgb(255, 0, 0, 0)
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_Search_Click(sender As System.Object, e As System.EventArgs) Handles btn_Search.Click
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        txt_Search.Focus()

        If txt_Search.Text = "" Or txt_Search.Text = "*" Then
            Call lsv_Select_Mas_Alam_View()
            Exit Sub
        Else
            On Error GoTo Err_Renamed

            sql = "select * from Mas_Status_Alarm where Status_Alarm_Name LIKE'%" & Trim(txt_Search.Text) & "%'order by Status_Alarm_Id"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        lsv_Mas_Alam.Items.Clear()
                        .MoveFirst()
                        Do While Not .EOF
                            Dim New_Ent As ListViewItem = lsv_Mas_Alam.Items.Add(rs.Fields("Status_Alarm_Id").Value)
                            With New_Ent
                                .SubItems.Add("" & rs.Fields("Status_Alarm_Name").Value)
                            End With
                            .MoveNext()
                        Loop
                    Else
                        lsv_Mas_Alam.Items.Clear()

                    End If
                End With
                txt_Search.SelectAll()
            End If
            rs = Nothing
            Exit Sub
Err_Renamed:
            Call mError.ShowError(Me.Name, "btn_Search_Click", Err.Number, Err.Description)
        End If
    End Sub
    Private Sub btn_Add_Alam_Click(sender As System.Object, e As System.EventArgs) Handles btn_Add_Alam.Click
        If btn_Add_Alam.Text = "เพิ่ม" Then
            btn_Edit_Alam.Enabled = False
            btn_Delete.Enabled = False
            btn_Search.Enabled = False
            txt_Search.Enabled = False
            CheckBox1.Checked = False
            btn_Color.Enabled = True
            txt_Search.Clear()

            txt_Mas_Alam.Enabled = True
            txt_HH_Start.Enabled = True
            txt_HH_Stop.Enabled = True
            txt_MM_Start.Enabled = True
            txt_MM_Stop.Enabled = True

            lbl_Mas_Alam.Text = Function_New_Alam_ID()
            txt_Mas_Alam.Focus()

            btn_Add_Alam.ImageList = Me.img_Save
            btn_Add_Alam.Text = "บันทึก"
        Else
            If Back_Color = "" Then
                MsgBox("กรุณาเลือก สีที่ท่านต้องการแสดง สถานะในระบบ   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                btn_Color.Focus()
                Exit Sub
            End If
            If txt_Mas_Alam.Text.Trim = "" Then
                MsgBox("กรุณาป้อนข้อมูลที่ต้องการบันทึก   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Mas_Alam.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_HH_Start.Text) = False Then
                MsgBox("กรุณาป้อนเวลาเป็นตัวเลข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_HH_Start.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_HH_Stop.Text) = False Then
                MsgBox("กรุณาป้อนเวลาเป็นตัวเลข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_HH_Stop.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_MM_Start.Text) = False Then
                MsgBox("กรุณาป้อนเวลาเป็นตัวเลข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_MM_Start.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_MM_Stop.Text) = False Then
                MsgBox("กรุณาป้อนเวลาเป็นตัวเลข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_MM_Stop.Focus()
                Exit Sub
            End If
            'Dim pMin As Short
            'lbl_Date_Update.Text = CDate(lbl_Date_Update.Text)
            'pMin = DateDiff(DateInterval.Minute, CDate(lbl_Date_Update.Text), CDate(Now))
            'lbl_Car_In.Text = pMin \ 60 & " ชม. " & pMin Mod 60 & " นาที "


            Call Save_Mas_Alam()
            Call lsv_Select_Mas_Alam_View()
            Call defaulf_Object()
            Call Style_ListView()
        End If
    End Sub
    Sub Update_Mas_Status_Alam()
        If btn_Edit_Alam.Text = "แก้ไข" Then Exit Sub
        ' If Back_Color = "" Then Exit Sub
        Try



            Dim Time_Min As String = mCountCar.Convert_HH_to_Min(txt_HH_Start.Text, txt_MM_Start.Text)
            Dim Time_Max As String = mCountCar.Convert_HH_to_Min(txt_HH_Stop.Text, txt_MM_Stop.Text)
            Dim chk_ As String = "0"


            If CheckBox1.Checked = True Then
                chk_ = "1"
            Else
                chk_ = "0"
            End If

            Dim sql As String = ""
            sql &= " Update Mas_Status_Alarm set Status_Alarm_Name='" & txt_Mas_Alam.Text & "'"
            sql &= " , Status_Alarm_Color_A = " & Color_A & ""
            sql &= " , Status_Alarm_Color_R = " & Color_R & ""
            sql &= " , Status_Alarm_Color_G = " & Color_G & ""
            sql &= " , Status_Alarm_Color_B = " & Color_B & " "
            sql &= " , [Status_Alarm_Time_Min] = " & Time_Min & ""
            sql &= " , [Status_Alarm_Time_Max] = " & Time_Max & ""
            sql &= " , [Status_visible] = '" & chk_ & "'"
            sql &= " where(Status_Alarm_Id = " & lbl_Mas_Alam.Text & ")"
            'If OpenCnn(ConnStrMasTer, Conn) Then
            '    Conn.BeginTrans()
            '    TrnFlg = True
            '    Conn.Execute(sql)
            If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                    'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Status_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", lbl_Mas_Alam.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
                    cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Status_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", lbl_Mas_Alam.Text, Tmp_Save_Pict, PictureBox4.BackgroundImage)
                    Tmp_Save_Pict = ""
                    'Dim frm As New Dg_msg_Ok
                    'frm.message = msg_update(0)
                    'frm.ShowDialog()
                    'frm.Dispose()
                    MsgBox(msg_update(0))
                Else
                    Dim frm As New Dg_msg_Error
                    frm.message = msg_update(1)
                    frm.ShowDialog()
                    frm.Dispose()

                    'MsgBox(msg_update(1))
                End If
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แก้ไขข้อมูลประเภทสี การจอดรถ ผิดพลาด ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Save_Mas_Alam()

        Dim sql As String
        Dim chk_ As String = "0"


        If CheckBox1.Checked = True Then
            chk_ = "1"
        Else
            chk_ = "0"
        End If

        Dim Time_Min As String = mCountCar.Convert_HH_to_Min(txt_HH_Start.Text, txt_MM_Start.Text)
        Dim Time_Max As String = mCountCar.Convert_HH_to_Min(txt_HH_Stop.Text, txt_MM_Stop.Text)

        'sql = " Insert into Mas_Status_Alarm  Values (" & Trim(lbl_Mas_Alam.Text) & _
        '      ",'" & txt_Mas_Alam.Text & "'," & Color_A & "," & Color_R & _
        '      "," & Color_G & "," & Color_B & "," & Time_Min & ", " & Time_Max & ")"
        ' Conn.Execute(sql)


        sql = " INSERT INTO [dbo].[Mas_Status_Alarm]"
        sql &= "    ([Status_Alarm_Id]"
        sql &= "    ,[Status_Alarm_Name]"
        sql &= "    ,[Status_Alarm_Color_A]"
        sql &= "    ,[Status_Alarm_Color_R]"
        sql &= "    ,[Status_Alarm_Color_G]"
        sql &= "    ,[Status_Alarm_Color_B]"
        sql &= "    ,[Status_Alarm_Time_Min]"
        sql &= "    ,[Status_Alarm_Time_Max]"
        sql &= "    ,[Status_visible])"
        sql &= "  VALUES"
        sql &= "   ('" & Trim(lbl_Mas_Alam.Text) & "'"
        sql &= "   ,'" & Trim(txt_Mas_Alam.Text) & "'"
        sql &= "   ,'" & Color_A & "'"
        sql &= "   ,'" & Color_R & "'"
        sql &= "   ,'" & Color_G & "'"
        sql &= "   ,'" & Color_B & "'"
        sql &= "   ,'" & Time_Min & "'"
        sql &= "   ,'" & Time_Max & "'"
        sql &= "   ,'" & Trim(chk_) & "')"

        If (MsgBox("คุณต้องการบันทึกข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Status_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", lbl_Mas_Alam.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
                cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Status_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", lbl_Mas_Alam.Text, "Alam_Image", PictureBox4.Image)
                Tmp_Save_Pict = ""
                'Dim frm As New Dg_msg_Ok
                'frm.message = msg_save(0)
                'frm.ShowDialog()
                'frm.Dispose()

                MsgBox(msg_save(0))
            Else
                Dim frm As New Dg_msg_Error
                frm.message = msg_save(1)
                frm.ShowDialog()
                frm.Dispose()
                'MsgBox(msg_save(1))
            End If
        End If

        Exit Sub
Err_Renamed:
        'If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "Save_Mas_Alam", Err.Number, Err.Description)
    End Sub
    Sub defaulf_Object()
        btn_Edit_Alam.Text = "แก้ไข"
        btn_Edit_Alam.Enabled = True
        btn_Edit_Alam.ImageList = Me.img_Edit

        btn_Add_Alam.Text = "เพิ่ม"
        btn_Add_Alam.Enabled = True
        btn_Add_Alam.ImageList = Me.img_Add

        lbl_Mas_Alam.Text = ""
        txt_Mas_Alam.Clear()
        txt_HH_Start.Text = 0
        txt_HH_Stop.Text = 0
        txt_MM_Start.Text = 0
        txt_MM_Stop.Text = 0
        CheckBox1.Checked = False

        btn_Delete.Enabled = True
        txt_Search.Clear()
        txt_Search.Enabled = True
        btn_Search.Enabled = True
        btn_Color.Enabled = False
        pic_Color.Visible = True

        txt_Mas_Alam.Enabled = False
        txt_HH_Start.Enabled = False
        txt_HH_Stop.Enabled = False
        txt_MM_Start.Enabled = False
        txt_MM_Stop.Enabled = False

    End Sub
    Private Function Function_New_Alam_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(Status_Alarm_Id) from Mas_Status_Alarm"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        F_ID = .Fields(0).Value.ToString
                        F_ID = F_ID + 1
                    End If
                End With
            End If
        Catch ex As Exception
            F_ID = "0"
        End Try
        Return F_ID
    End Function
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        If lbl_Mas_Alam.Text = 0 Or lbl_Mas_Alam.Text = 1 Or lbl_Mas_Alam.Text = 2 Then
            MsgBox("ไม่สามารถลบข้อมูลที่เลือกได้  เนื่องจากเป็นค่าเริ่มต้นของระบบ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
        End If
        Call Delete_Status_Alam()
        Call lsv_Select_Mas_Alam_View()
        Call defaulf_Object()
        Call Style_ListView()
    End Sub
    Sub Delete_Status_Alam()
        If lbl_Mas_Alam.Text = 0 Or lbl_Mas_Alam.Text = 1 Or lbl_Mas_Alam.Text = 2 Then
            MsgBox("ไม่สามารถลบข้อมูลที่เลือกได้  เนื่องจากเป็นค่าเริ่มต้นของระบบ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            Exit Sub
        End If
        If lbl_Mas_Alam.Text = "" Or txt_Mas_Alam.Text.Trim = "" Then Exit Sub
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_Status_Alarm WHERE Status_Alarm_Id = '" & lbl_Mas_Alam.Text & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส  : " & lbl_Mas_Alam.Text & vbCrLf & _
                       "ชื่อ : " & txt_Mas_Alam.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call lsv_Select_Mas_Alam_View()
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Status_Alam", Err.Number, Err.Description)
    End Sub
    Private Sub btn_Edit_Alam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit_Alam.Click
        If txt_Mas_Alam.Text = "" Then
            MsgBox("กรุณาเลือก ข้อมูลที่ต้องการแก้ไข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            txt_Mas_Alam.Enabled = False
            btn_Edit_Alam.Text = "แก้ไข"
            Exit Sub
        End If
        If btn_Edit_Alam.Text = "แก้ไข" Then
            btn_Edit_Alam.Text = "บันทึก"
            btn_Add_Alam.Enabled = False
            btn_Delete.Enabled = False
            btn_Search.Enabled = False
            txt_Search.Enabled = False

            txt_Mas_Alam.Enabled = True
            txt_HH_Start.Enabled = True
            txt_HH_Stop.Enabled = True
            txt_MM_Start.Enabled = True
            txt_MM_Stop.Enabled = True


            btn_Color.Enabled = True
            txt_Mas_Alam.Enabled = True
            txt_Search.Clear()
            txt_Mas_Alam.Focus()
            btn_Edit_Alam.ImageList = Me.img_SaveAdd

        Else
            If txt_Mas_Alam.Text = "" Then
                Dim frm As New Dg_msg_Error
                frm.message = "กรุณาป้อนข้อมูลให้ถูกต้อง"
                frm.ShowDialog()
                frm.Dispose()
                'MsgBox("กรุณาป้อนข้อมูลให้ถูกต้อง    ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Mas_Alam.Focus()
                Exit Sub
            End If

            Call Update_Mas_Status_Alam()
            Call lsv_Select_Mas_Alam_View()
            Call defaulf_Object()
            Call Style_ListView()
            Call set_Alarm_picture()
            btn_Edit_Alam.Text = "แก้ไข"
        End If
    End Sub
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Call defaulf_Object()
    End Sub
    Private Sub btn_Color_Click(sender As System.Object, e As System.EventArgs) Handles btn_Color.Click

        With DlgCollor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fColor As String = .Color.Name
                Color_A = .Color.A
                Color_R = .Color.R
                Color_G = .Color.G
                Color_B = .Color.B
                'lbl_Back_Color.BackColor = Color.FromArgb(fColor)
                pic_Color.Visible = False
                Back_Color = .Color.Name
                lbl_Back_Color.BackColor = .Color
                'Back_Color = .Color.Name.ToString
                'lbl_Back_Color.BackColor = Color.FromArgb(Back_Color)
                ' Back_Color = A & "," & R & "," & G & "," & B
                'Back_Color = fColor
            Else
                Exit Sub
            End If

        End With
    End Sub
    Private Sub lsv_Mas_Alam_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Alam.MouseClick

        Try
            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim sql As String

            sql = "SELECT * FROM Mas_Status_Alarm  where Status_Alarm_Id = '" & _
            lsv_Mas_Alam.FocusedItem.SubItems(0).Text & "'"

            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)

                    If Not (.BOF And .EOF) Then
                        Dim Time_Min As String = rs.Fields("Status_Alarm_Time_Min").Value
                        Dim Time_Max As String = rs.Fields("Status_Alarm_Time_Max").Value

                        txt_HH_Start.Text = mCountCar.Convert_MM_to_HH(Time_Min)
                        txt_MM_Start.Text = mCountCar.Convert_MM_to_MM(Time_Min)
                        txt_HH_Stop.Text = mCountCar.Convert_MM_to_HH(Time_Max)
                        txt_MM_Stop.Text = mCountCar.Convert_MM_to_MM(Time_Max)

                        If IsDBNull(rs.Fields("Status_Alarm_Image").Value) = False Then
                            Tmp_Save_Pict = lsv_Mas_Alam.FocusedItem.SubItems(0).Text
                            Dim RetByte() As Byte = CType(rs.Fields("Status_Alarm_Image").Value, Byte())
                            Dim PictureData() As Byte = RetByte
                            Dim Ms As New System.IO.MemoryStream(PictureData)
                            PictureBox4.BackgroundImage = Image.FromStream(Ms)
                            PictureBox4.BackColor = Color.Transparent
                            'PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                        Else
                            Tmp_Save_Pict = ""
                        End If

                        If rs.Fields("Status_visible").Value.ToString = "1" Then
                            CheckBox1.Checked = True
                        Else
                            CheckBox1.Checked = False
                        End If

                    End If
                End With
            End If
            rs = Nothing

            With lsv_Mas_Alam
                lbl_Mas_Alam.Text = .FocusedItem.SubItems(0).Text
                txt_Mas_Alam.Text = .FocusedItem.SubItems(1).Text
                If .FocusedItem.SubItems(2).Text <> "" Then
                    A = .FocusedItem.SubItems(2).Text
                    R = .FocusedItem.SubItems(3).Text
                    G = .FocusedItem.SubItems(4).Text
                    B = .FocusedItem.SubItems(5).Text
                    Color_A = A
                    Color_R = R
                    Color_G = G
                    Color_B = B
                    lbl_Back_Color.BackColor = Color.FromArgb(A, R, G, B)
                    pic_Color.Visible = False
                Else
                    pic_Color.Visible = True
                End If
            End With
        Catch ex As Exception
            pic_Color.Visible = True
            Call mError.ShowError(Me.Name, "lsv_Mas_Alam_MouseClick", Err.Number, Err.Description)
            Exit Try
        End Try


    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedTab.Name
            Case "TabPage1" : Timer1.Enabled = True
            Case "TabPage3" : Timer2.Enabled = True
            Case "TabPage6" : Timer3.Enabled = True
            Case "TabPage13" : Timer4.Enabled = True
            Case "TabPage11" : Timer5.Enabled = True
            Case "TabPage2" : Timer6.Enabled = True
            Case "TabPage4" : Timer7.Enabled = True
            Case "TabPage5" : Timer8.Enabled = True
            Case "TabPage7" : Timer9.Enabled = True
        End Select


    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Timer3.Enabled = False
        Load_Size_CallPoint()
        Load_Pic_CallPoint()
        MaskedTextBox2.Enabled = True
        MaskedTextBox1.Enabled = True
        MaskedTextBox2.Focus()
    End Sub
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
            SqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            SqlDa.Fill(sqlDs, "Mas_Turn_Off_LED")
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
    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
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
                Excute_SQL(ConStr_Master, "delete from Mas_Turn_Off_LED where ID = 1 ")
                sql &= "" & " insert into Mas_Turn_Off_LED ("
                sql &= "[ID]"
                SQL_VALUE &= "" & " Values ( " & "1"

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

                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TStart.Value.Hour & "' , Status ='1' where Address ='2520'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TStart.Value.Minute & "' , Status ='1'  where Address ='2521'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TEnd.Value.Hour & "' , Status ='1'  where Address ='2522'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TEnd.Value.Minute & "' , Status ='1'  where Address ='2523'")

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
    Sub Load_Mas_Turn_Off_LED2()

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
            SqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            SqlDa.Fill(sqlDs, "Mas_Turn_Off_LED")
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
    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
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
    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
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
                Excute_SQL(ConStr_Master, "delete from Mas_Turn_Off_LED where  ID = 3 ")
                sql &= "" & " insert into Mas_Turn_Off_LED ("
                sql &= "[ID]"
                SQL_VALUE &= "" & " Values ( " & "3"

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

                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TStart.Value.Hour & "' , Status ='1' where Address ='2515'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TStart.Value.Minute & "' , Status ='1'  where Address ='2516'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TEnd.Value.Hour & "' , Status ='1'  where Address ='2517'")
                Excute_SQL(ConStr_Master, "update Mas_Set_Modbus_Config set Value = '" & TEnd.Value.Minute & "' , Status ='1'  where Address ='2518'")

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


    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        Timer4.Enabled = False
        load_lange()
    End Sub
    Sub load_lange()
        Dim sql As String = ""
        sql = "SELECT * FROM LANG_Select"
        dt = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(1).ToString.Trim = "EN" Then
                RadioButton1.Checked = True
                RadioButton2.Checked = False
            End If
            If dt.Rows(0).Item(1).ToString.Trim = "TH" Then
                RadioButton1.Checked = False
                RadioButton2.Checked = True
            End If
        End If
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        Button25.Enabled = False
        If RadioButton1.Checked = True Then
            set_lange("EN")
        End If
        If RadioButton2.Checked = True Then
            set_lange("TH")
        End If

        Button25.Enabled = True
    End Sub
    Sub set_lange(ByVal lange As String)
        Dim sql As String = ""
        Try
            sql = "UPDATE [LANG_Select] SET [Lang_Select]='" & lange & "' WHERE Id_='1'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                MsgBox("เปลี่ยนภาษาเรียบร้อยแล้ว กรุณาปิดเปิดโปรแกรมใหม่")
                'If MsgBox("อัพเดตภาษาแล้ว จะทำการรีสตาร์ทโปรแกรมเพื่อให้การตั้งค่าแสดงผล ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Process.Start(Application.StartupPath & "/openCloseSoftware.bat")
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        With DlgCollor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fColor As String = .Color.Name
                Color_A = .Color.A
                Color_R = .Color.R
                Color_G = .Color.G
                Color_B = .Color.B
                pic_Color.Visible = False
                Back_Color = .Color.Name
                Label20.BackColor = .Color
            Else
                Exit Sub
            End If

        End With
    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        Timer5.Enabled = False
        Call lsv_Select_Mas_Alam_View2()
        Call defaulf_Object2()
        Call Style_ListView2()
    End Sub
    Sub Style_ListView2()
        Dim i As Integer
        Try
            For i = 0 To (ListView1.Items.Count - 1)
                With ListView1
                    If .Items(i).SubItems(2).Text.ToString <> "" And .Items(i).SubItems(3).Text.ToString <> "" Then
                        A = .Items(i).SubItems(2).Text.ToString
                        R = .Items(i).SubItems(3).Text.ToString
                        G = .Items(i).SubItems(4).Text.ToString
                        B = .Items(i).SubItems(5).Text.ToString
                        .Items(i).ForeColor = Color.FromArgb(A, R, G, B)
                    Else
                        .Items(i).ForeColor = Color.FromArgb(255, 0, 0, 0)
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub defaulf_Object2()
        btn_Edit_Alam2.Text = "แก้ไข"
        btn_Edit_Alam2.Enabled = True
        btn_Edit_Alam2.ImageList = Me.img_Edit

        btn_Add_Alam2.Text = "เพิ่ม"
        btn_Add_Alam2.Enabled = True
        btn_Add_Alam2.ImageList = Me.img_Add

        Label15.Text = ""
        TextBox1.Clear()
        txt_Min.Text = 0

        txt_Max.Text = 0
        txt_Mas_Alam.Enabled = False
        txt_Min.Enabled = False
        txt_Max.Enabled = False

        btn_Delete2.Enabled = True
        btn_Color2.Enabled = False
        PictureBox1.Visible = True
    End Sub
    Sub lsv_Select_Mas_Alam_View2()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Row_Color As String
        sql = "SELECT * FROM Mas_Color_History "
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    ListView1.Items.Clear()
                    ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    ListView1.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        Dim New_Ent As ListViewItem = ListView1.Items.Add(rs.Fields("His_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("His_Name").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_A").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_R").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_G").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_B").Value)

                        End With
                        .MoveNext()
                    Loop

                Else
                    ListView1.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "แสดงรายละเอียด ประวัติสีการจอดรถ", Err.Number, Err.Description)
    End Sub
    Private Sub ListView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        Try
            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim sql As String

            sql = "SELECT * FROM Mas_Color_History  where His_Id = '" & _
            ListView1.FocusedItem.SubItems(0).Text & "'"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)

                    If Not (.BOF And .EOF) Then
                        txt_Min.Text = "" & rs.Fields("His_Min").Value
                        txt_Max.Text = "" & rs.Fields("His_Max").Value

                    End If
                End With
            End If
            rs = Nothing

            With ListView1
                Label15.Text = .FocusedItem.SubItems(0).Text
                TextBox1.Text = .FocusedItem.SubItems(1).Text
                If .FocusedItem.SubItems(2).Text <> "" Then
                    A = .FocusedItem.SubItems(2).Text
                    R = .FocusedItem.SubItems(3).Text
                    G = .FocusedItem.SubItems(4).Text
                    B = .FocusedItem.SubItems(5).Text
                    Color_A = A
                    Color_R = R
                    Color_G = G
                    Color_B = B
                    Label14.BackColor = Color.FromArgb(A, R, G, B)
                    PictureBox1.Visible = False
                Else
                    PictureBox1.Visible = True
                End If
            End With
        Catch ex As Exception
            pic_Color.Visible = True
            Call mError.ShowError(Me.Name, "เลือกประเภทสีการชำระ", Err.Number, Err.Description)
            Exit Try
        End Try
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg,*.png)|*.bmp;*.gif;*.jpg;*.JPEG;*.PNG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict = .FileName : PictureBox4.Visible = True
            'PictureBox1.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)
            PictureBox4.BackColor = Color.Transparent
            'PictureBox1.BackColor = Color.Crimson
            PictureBox4.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict)
            PictureBox4.BackgroundImageLayout = ImageLayout.Zoom
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Add_Picture_Click", Err.Number, Err.Description)
    End Sub


    Private Sub Timer6_Tick(sender As System.Object, e As System.EventArgs) Handles Timer6.Tick
        Timer6.Enabled = False
        Load_Size_Lot()
        msk_X.Enabled = True
        msk_Y.Enabled = True
        msk_X.Focus()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
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
                PictureBox5.BackColor = Color.Transparent
                'PictureBox1.BackColor = Color.Crimson
                PictureBox5.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict)
                PictureBox5.BackgroundImageLayout = ImageLayout.Zoom
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Button3_Click", Err.Number, Err.Description)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Panel1.Controls.Clear()
        Try
            If RadioButton1.Checked = True Then

            End If

           
            btn_label = New PictureBox
            With btn_label
                .BackColor = Color.Black
                If Tmp_Save_Pict <> "" Then
                    .BackgroundImage = PictureBox5.BackgroundImage
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


            Dim img(8) As System.Drawing.Bitmap
            Dim dbmp As System.Drawing.Bitmap
            dbmp = New System.Drawing.Bitmap(PictureBox5.BackgroundImage, CInt(msk_X.Text), CInt(msk_Y.Text))

            img(0) = dbmp
            PictureBox18.BackgroundImage = img(0)
            PictureBox9.BackgroundImage = RotateImg(img(0), 0.0F, Color.Transparent)
            PictureBox10.BackgroundImage = RotateImg(img(0), 270.0F, Color.Transparent)
            PictureBox11.BackgroundImage = RotateImg(img(0), 90.0F, Color.Transparent)
            PictureBox12.BackgroundImage = RotateImg(img(0), 180.0F, Color.Transparent)
            PictureBox13.BackgroundImage = RotateImg(img(0), 45.0F, Color.Transparent)
            PictureBox14.BackgroundImage = RotateImg(img(0), 135.0F, Color.Transparent)
            PictureBox15.BackgroundImage = RotateImg(img(0), 315.0F, Color.Transparent)
            PictureBox16.BackgroundImage = RotateImg(img(0), 225.0F, Color.Transparent)

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Button5_Click", Err.Number, Err.Description)
        End Try
    End Sub
    

    Private Sub btn_Save_Click(sender As System.Object, e As System.EventArgs) Handles btn_Save.Click
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
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then

            End If
            sql = "insert into Mas_Size_Lot values (1," & msk_X.Text.Trim & "," & msk_Y.Text.Trim & ",null)"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then

                If Not (Tmp_Save_Pict = "") Then
                    'Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Size_Lot", "ID", "Size_Image", "1", Tmp_Save_Pict) 'Tmp_Save_Pict
                    Call cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Size_Lot", "ID", "Size_Image", "1", Tmp_Save_Pict, PictureBox5.BackgroundImage)
                End If
               
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
    End Sub
    Sub set_lot_size()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM Mas_Size_Lot"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
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

    Sub set_Callpoint_size()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM Mas_Size_Callpoint"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                Callpoint_size_x = dt.Rows(0).Item("Size_X").ToString
                Callpoint_size_y = dt.Rows(0).Item("Size_Y").ToString
                Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                Dim PictureData() As Byte = RetByte
                Dim Ms As New System.IO.MemoryStream(PictureData)
                Callpoint_size_image = Image.FromStream(Ms)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Pic_CallPoint()
        Dim sql As String = ""
        Try
            sql &= " SELECT [Status_Alarm_Id]"
            sql &= ",[Status_Alarm_Image]"
            sql &= "FROM [Mas_Status_Callpoint_Alarm]"
            Tmp_Save_Pict1 = ""
            Tmp_Save_Pict2 = ""
            Tmp_Save_Pict3 = ""
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(0).Item("Status_Alarm_Image")) = False Then
                        If dt.Rows(i).Item("Status_Alarm_Id").ToString = "0" Then
                            Tmp_Save_Pict1 = dt.Rows(i).Item("Status_Alarm_Id").ToString
                            Dim RetByte() As Byte = CType(dt.Rows(i).Item("Status_Alarm_Image"), Byte())
                            Dim PictureData() As Byte = RetByte
                            Dim Ms As New System.IO.MemoryStream(PictureData)
                            PictureBox7.BackgroundImage = Image.FromStream(Ms)
                            PictureBox7.BackColor = Color.Transparent

                        End If
                        If dt.Rows(i).Item("Status_Alarm_Id").ToString = "1" Then
                            Tmp_Save_Pict2 = dt.Rows(i).Item("Status_Alarm_Id").ToString

                            Dim RetByte() As Byte = CType(dt.Rows(i).Item("Status_Alarm_Image"), Byte())
                            Dim PictureData() As Byte = RetByte
                            Dim Ms As New System.IO.MemoryStream(PictureData)
                            PictureBox8.BackgroundImage = Image.FromStream(Ms)
                            PictureBox8.BackColor = Color.Transparent

                        End If
                        If dt.Rows(i).Item("Status_Alarm_Id").ToString = "2" Then
                            Tmp_Save_Pict3 = dt.Rows(i).Item("Status_Alarm_Id").ToString

                            Dim RetByte() As Byte = CType(dt.Rows(i).Item("Status_Alarm_Image"), Byte())
                            Dim PictureData() As Byte = RetByte
                            Dim Ms As New System.IO.MemoryStream(PictureData)
                            PictureBox17.BackgroundImage = Image.FromStream(Ms)
                            PictureBox17.BackColor = Color.Transparent

                        End If
                    End If
                Next


            Else
                Tmp_Save_Pict1 = ""
                Tmp_Save_Pict2 = ""
                Tmp_Save_Pict3 = ""
                'PictureBox1.BackgroundImageLayout = ImageLayout.Stretch

            End If

        Catch ex As Exception

            'msk_X.Text = ""
            'msk_Y.Text = ""
        End Try

    End Sub
    Sub Load_Size_CallPoint()
        Dim sql As String = ""
        Try
            sql &= " SELECT [ID]"
            sql &= ",[Size_X]"
            sql &= ",[Size_Y]"
            sql &= ",[Size_Image]"
            sql &= "FROM [Mas_Size_Callpoint]"
            Tmp_Save_Pict = ""

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)

            If dt.Rows.Count > 0 Then
                MaskedTextBox2.Text = dt.Rows(0).Item("Size_X").ToString
                MaskedTextBox1.Text = dt.Rows(0).Item("Size_Y").ToString
                If IsDBNull(dt.Rows(0).Item("Size_Image")) = False Then
                    Tmp_Save_Pict = dt.Rows(0).Item("ID").ToString
                    Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                    Dim PictureData() As Byte = RetByte
                    Dim Ms As New System.IO.MemoryStream(PictureData)
                    PictureBox7.BackgroundImage = Image.FromStream(Ms)
                    PictureBox7.BackColor = Color.Transparent
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
    Sub Load_Size_Lot()
        Dim sql As String = ""
        Try
            sql &= " SELECT [ID]"
            sql &= ",[Size_X]"
            sql &= ",[Size_Y]"
            sql &= ",[Size_Image]"
            sql &= "FROM [Mas_Size_Lot]"

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)

            If dt.Rows.Count > 0 Then
                msk_X.Text = dt.Rows(0).Item("Size_X").ToString
                msk_Y.Text = dt.Rows(0).Item("Size_Y").ToString
                If IsDBNull(dt.Rows(0).Item("Size_Image")) = False Then
                    Tmp_Save_Pict = dt.Rows(0).Item("ID").ToString
                    Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                    Dim PictureData() As Byte = RetByte
                    Dim Ms As New System.IO.MemoryStream(PictureData)
                    PictureBox5.BackgroundImage = Image.FromStream(Ms)
                    PictureBox5.BackColor = Color.Transparent
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

    Private Sub Timer7_Tick(sender As System.Object, e As System.EventArgs) Handles Timer7.Tick
        Timer7.Enabled = False
        Call Show_Hour_Alert()
    End Sub

    Sub Show_Hour_Alert()
        Try
            Dim sql As String = ""
            sql = " SELECT  HH_ID"
            sql &= " ,[HH_Alert]"
            sql &= " ,[HH_Image]"
            sql &= " FROM [Mas_Hour_Alert]"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)

            If dt.Rows.Count > 0 Then
                msk_Alert.Text = "" & dt.Rows(0).Item("HH_Alert").ToString

                If IsDBNull(dt.Rows(0).Item("HH_Image")) = False Then
                    Tmp_Save_Pict = dt.Rows(0).Item("HH_ID").ToString
                    Dim RetByte() As Byte = CType(dt.Rows(0).Item("HH_Image"), Byte())
                    Dim PictureData() As Byte = RetByte
                    Dim Ms As New System.IO.MemoryStream(PictureData)
                    PictureBox6.BackgroundImage = Image.FromStream(Ms)
                    PictureBox6.BackColor = Color.Transparent
                    'PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                Else
                    Tmp_Save_Pict = ""
                End If
            End If

        Catch ex As Exception
            msk_Alert.Text = "1"
        End Try

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        If msk_Alert.Text.Trim = "" Then
            MessageBox.Show("กรุณา ป้อนต้วเลข เวลาที่ต้องการแจ้งเตือน รถจอดเกินเวลาที่กำหนด", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            msk_Alert.Focus()
            Exit Sub
        End If

        Try
            Excute_SQL(ConStr_Master, "delete from Mas_Hour_Alert ")
            Excute_SQL(ConStr_Master, "insert into Mas_Hour_Alert(HH_ID,HH_Alert) values (1," & msk_Alert.Text.Trim & ") ")
            If Result_SQL = True Then
                'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Hour_Alert", "HH_ID", "HH_Image", "1", Tmp_Save_Pict) 'Tmp_Save_Pict
                'Tmp_Save_Pict = ""
                cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Hour_Alert", "HH_ID", "HH_Image", "1", Tmp_Save_Pict, PictureBox6.BackgroundImage)

                MsgBox(msg_save(0))
            Else
                MsgBox(msg_save(1))
            End If
            Guidance_Log_User_Process(CurUser_ID, My.Computer.Name, "Edit", Me.Name, "แก้ไข เวลาแจ้งเตือน รถจอดเกินเวลา")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
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
                PictureBox6.BackColor = Color.Transparent
                'PictureBox1.BackColor = Color.Crimson
                PictureBox6.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict)
                PictureBox6.BackgroundImageLayout = ImageLayout.Zoom
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Button8_Click", Err.Number, Err.Description)
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Panel5.Controls.Clear()
        Try


            btn_label = New PictureBox
            With btn_label
                .BackColor = Color.Black
                If Tmp_Save_Pict <> "" Then
                    .BackgroundImage = PictureBox7.BackgroundImage
                    .BackColor = Color.Transparent
                    .BackgroundImageLayout = ImageLayout.Zoom
                End If
                .Size = New System.Drawing.Size(CInt(MaskedTextBox2.Text), CInt(MaskedTextBox1.Text))
                .Location = New System.Drawing.Point((Panel5.Width / 2) - (.Width / 2), (Panel5.Height / 2) - (.Height / 2))
                .Text = ""
                .Tag = Tag
                .Name = "ex"
                'Pic_ID_2.Controls.Add(btn_label)
                Panel5.Controls.Add(btn_label)
                .BringToFront()
                Application.DoEvents()
            End With
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Button10_Click", Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        If MaskedTextBox2.Text.Trim = "" Then
            MessageBox.Show("กรุณา ป้อนตัวเลขขนาด SIZE : X  ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MaskedTextBox2.Focus()
            Exit Sub
        End If
        If MaskedTextBox2.Text.Trim = "" Then
            MessageBox.Show("กรุณา ป้อนต้วเลขขนาด SIZE : Y  ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MaskedTextBox2.Focus()
            Exit Sub
        End If
        Try
            Dim sql As String = ""
            sql = "delete from Mas_Size_Callpoint"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then

            End If
            sql = "insert into Mas_Size_Callpoint values (1," & MaskedTextBox2.Text.Trim & "," & MaskedTextBox1.Text.Trim & ",null)"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then

                sql = ""
                sql = "SELECT * FROM Mas_Status_Callpoint_Alarm"
                Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
                If dt.Rows.Count < 3 Then
                    sql = "DELETE FROM Mas_Status_Callpoint_Alarm"
                    cdb.ExcuteNoneQury(sql, ConStr_Master)

                    sql = "INSERT [dbo].[Mas_Status_Callpoint_Alarm] ([Status_Alarm_Id], [Status_Alarm_Name], [Status_Alarm_Color_A], [Status_Alarm_Color_R], [Status_Alarm_Color_G], [Status_Alarm_Color_B], [Status_Alarm_Time_Min], [Status_Alarm_Time_Max], [Status_Alarm_Image], [Status_visible]) VALUES (0, N'ไม่มีการแจ้งเตือน', 255, 128, 0, 0, 420, 999999, NULL, 0)"
                    cdb.ExcuteNoneQury(sql, ConStr_Master)

                    sql = "INSERT [dbo].[Mas_Status_Callpoint_Alarm] ([Status_Alarm_Id], [Status_Alarm_Name], [Status_Alarm_Color_A], [Status_Alarm_Color_R], [Status_Alarm_Color_G], [Status_Alarm_Color_B], [Status_Alarm_Time_Min], [Status_Alarm_Time_Max], [Status_Alarm_Image], [Status_visible]) VALUES (1, N'มีการแจ้งเตือน', 255, 128, 0, 0, 420, 999999, NULL, 0)"
                    cdb.ExcuteNoneQury(sql, ConStr_Master)

                    sql = "INSERT [dbo].[Mas_Status_Callpoint_Alarm] ([Status_Alarm_Id], [Status_Alarm_Name], [Status_Alarm_Color_A], [Status_Alarm_Color_R], [Status_Alarm_Color_G], [Status_Alarm_Color_B], [Status_Alarm_Time_Min], [Status_Alarm_Time_Max], [Status_Alarm_Image], [Status_visible]) VALUES (2, N'CP อุปกรณ์ขัดข้องทั้งหมด', 255, 128, 0, 0, 420, 999999, NULL, 0)"
                    cdb.ExcuteNoneQury(sql, ConStr_Master)
                End If


                If Not (Tmp_Save_Pict1 = "") Then
                    Call cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Status_Callpoint_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", "0", Tmp_Save_Pict1, PictureBox7.BackgroundImage) 'Tmp_Save_Pict
                End If

                Tmp_Save_Pict1 = ""
                If Not (Tmp_Save_Pict2 = "") Then
                    Call cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Status_Callpoint_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", "1", Tmp_Save_Pict2, PictureBox8.BackgroundImage)
                End If
                Tmp_Save_Pict2 = ""
                If Not (Tmp_Save_Pict3 = "") Then
                    Call cdb.Save_Pict_To_DB_No_Message(ConStr_Master, "Mas_Status_Callpoint_Alarm", "Status_Alarm_Id", "Status_Alarm_Image", "2", Tmp_Save_Pict3, PictureBox17.BackgroundImage)
                End If

                Tmp_Save_Pict3 = ""

                set_Callpoint_size()
                set_callpoint_picture()
                MsgBox(msg_save(0))
            Else
                MsgBox(msg_save(1))
            End If


            'If Result_SQL = True Then
            '    MessageBox.Show("บันทึกข้อมูลเสร็จเรียบร้อย !!!!  " & vbNewLine & "เมื่อบันทึกข้อมูลเสร็จ หน้าต้างนี้จะถูกปิดลง อัตโนมัติ ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            Guidance_Log_User_Process(CurUser_ID, My.Computer.Name, "Edit", Me.Name, "แก้ไขขนาด Mas_Size_Callpoint X = " & msk_X.Text & " และ Y = " & msk_Y.Text & "")

            'If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Floor", "Floor_Id", "Floor_Image", lbl_Floor_Id.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
            'Tmp_Save_Pict = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg,*.png)|*.bmp;*.gif;*.jpg;*.JPEG;*.PNG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict1 = .FileName
            'PictureBox1.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)
            If Tmp_Save_Pict1 <> "" Then
                PictureBox7.BackColor = Color.Transparent
                'PictureBox1.BackColor = Color.Crimson
                PictureBox7.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict1)
                PictureBox7.BackgroundImageLayout = ImageLayout.Zoom
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Button9_Click", Err.Number, Err.Description)
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg,*.png)|*.bmp;*.gif;*.jpg;*.JPEG;*.PNG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict2 = .FileName
            'PictureBox1.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)
            If Tmp_Save_Pict2 <> "" Then
                PictureBox8.BackColor = Color.Transparent
                'PictureBox1.BackColor = Color.Crimson
                PictureBox8.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict2)
                PictureBox8.BackgroundImageLayout = ImageLayout.Zoom
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Button12_Click", Err.Number, Err.Description)
    End Sub

    Private Sub Timer8_Tick(sender As System.Object, e As System.EventArgs) Handles Timer8.Tick
        Timer8.Enabled = False
        Call Show_STD_Time()
    End Sub

    Sub Show_STD_Time()
        Dim sql As String = ""
        Try

            sql = " SELECT  [CP_Time_ID]"
            sql &= " ,[CP_Time_Set]"
            sql &= " ,[CP_Last_Update]"
            sql &= " FROM [Mas_CP_STD_Service]"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                MaskedTextBox3.Text = dt.Rows(0).Item("CP_Time_Set").ToString
            Else
                MaskedTextBox3.Text = 0
            End If

        Catch ex As Exception
            MaskedTextBox3.Text = 0
        End Try
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Try
            If MsgBox("คุณต้องการ Update Standard เวลาในการ Service ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                sql = "DELETE FROM [Mas_CP_STD_Service] WHERE [CP_Time_ID]='1'"
                cdb.ExcuteNoneQury(sql, ConStr_Master)


                sql = "INSERT Mas_CP_STD_Service([CP_Time_ID],[CP_Time_Set],[CP_Last_Update],[USER_update]) VALUES('1','" & MaskedTextBox3.Text & "',GETDATE(),'" & CurUser_ID & "')"
                If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                    MsgBox(msg_update(0))
                Else
                    MsgBox(msg_update(1))
                End If
            End If
        Catch ex As Exception
            MsgBox("Button16_Click : " & ex.Message)
        End Try

    End Sub

    Private Sub Timer9_Tick(sender As System.Object, e As System.EventArgs) Handles Timer9.Tick
        Timer9.Enabled = False
        Call Show_Filter_Time()
    End Sub
    Sub Show_Filter_Time()
        Dim sql As String = ""
        Try

            sql = " SELECT  [UD_Time_FT_ID]"
            sql &= " ,[UD_Time_FT_Set]"
            sql &= " ,[UD_Last_FT_Update]"
            sql &= " FROM [Mas_UD_Timefilter]"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                MaskedTextBox4.Text = dt.Rows(0).Item("UD_Time_FT_Set").ToString
            Else
                MaskedTextBox4.Text = 0
            End If

        Catch ex As Exception
            MaskedTextBox4.Text = 0
        End Try
    End Sub

    Private Sub Button14_Click_1(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        Try
            If MsgBox("คุณต้องการ Update การกรองข้อมูล ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                sql = "DELETE FROM [Mas_UD_Timefilter] WHERE [UD_Time_FT_ID]='1'"
                cdb.ExcuteNoneQury(sql, ConStr_Master)


                sql = "INSERT INTO Mas_UD_Timefilter([UD_Time_FT_ID],[UD_Time_FT_Set],[UD_Last_FT_Update],[USER_update]) VALUES('1','" & MaskedTextBox4.Text & "',GETDATE(),'" & CurUser_ID & "')"
                If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                    MsgBox(msg_update(0))
                Else
                    MsgBox(msg_update(1))
                End If
            End If
        Catch ex As Exception
            MsgBox("Button16_Click : " & ex.Message)
        End Try

    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg,*.png)|*.bmp;*.gif;*.jpg;*.JPEG;*.PNG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict3 = .FileName
            'PictureBox1.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)
            If Tmp_Save_Pict3 <> "" Then
                PictureBox17.BackColor = Color.Transparent
                'PictureBox1.BackColor = Color.Crimson
                PictureBox17.BackgroundImage = System.Drawing.Image.FromFile(Tmp_Save_Pict3)
                PictureBox17.BackgroundImageLayout = ImageLayout.Zoom
            End If
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Button20_Click", Err.Number, Err.Description)
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.SelectedRows.Count = 1 Then
            Label42.Text = DataGridView1.SelectedRows(0).Cells(0).Value
            MaskedTextBox5.Text = DataGridView1.SelectedRows(0).Cells(1).Value
            ComboBox1.SelectedValue = DataGridView1.SelectedRows(0).Cells(2).Value
            Button23.Enabled = True
            'MaskedTextBox5.Enabled = True
            'ComboBox1.Enabled = True
            'Button23_Click(e, Nothing)
        End If
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        If Button24.Text = "เพิ่ม" Then
            Label42.Text = GET_ID_Building()
            MaskedTextBox5.Text = ""
            MaskedTextBox5.Enabled = True
            ComboBox1.Enabled = True
            ComboBox1.SelectedIndex = 0
            Button24.Text = "บันทึก"
            Button23.Enabled = False

        Else
            SAVE_ADD_Building()
            Button24.Text = "เพิ่ม"
            MaskedTextBox5.Enabled = False
            ComboBox1.Enabled = False
            Load_buiding("")
        End If
    End Sub
    Sub SAVE_ADD_Building()
        Try
            Dim sql As String = ""
            sql = "insert into [dbo].[Mas_Building_Parking]([Building_ID],[Building_Name],[Tower_ID])"
            sql &= " values('" & Label42.Text & "','" & MaskedTextBox5.Text & "','" & ComboBox1.SelectedValue & "')"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) Then
                MsgBox(msg_save(0))
            Else
                MsgBox(msg_save(1))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub UPDATE_ADD_Building()
        Try
            Dim sql As String = ""
            sql = "update [dbo].[Mas_Building_Parking] SET [Building_Name]='" & MaskedTextBox5.Text & "',[Tower_ID]='" & ComboBox1.SelectedValue & "'"
            sql &= " where [Building_ID]='" & Label42.Text & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) Then
                MsgBox(msg_save(0))
            Else
                MsgBox(msg_save(1))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function GET_ID_Building()
        GET_ID_Building = "1"
        Try
            Dim sql As String = ""
            sql = "SELECT TOP 1 [Building_ID] FROM [dbo].[Mas_Building_Parking] order by RIGHT('0000' + convert(varchar(4),[Building_ID]),3) desc"
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0).ToString <> "" Then
                    GET_ID_Building = DT.Rows(0).Item(0).ToString + 1
                End If
            End If
        Catch ex As Exception

        End Try
    End Function
    Sub Delete_Building()
        Try
            Dim sql As String = ""
            sql = "delete from [dbo].[Mas_Building_Parking] where [Building_ID]='" & Label42.Text & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) Then
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        Delete_Building()
        Load_buiding("")
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        If Button23.Text = "แก้ไข" Then
            'Label42.Text = GET_ID_Building()
            MaskedTextBox5.Enabled = True
            ComboBox1.Enabled = True
            'ComboBox1.SelectedIndex = 0
            Button23.Text = "บันทึก"
        Else
            UPDATE_ADD_Building()
            Button23.Text = "แก้ไข"
            MaskedTextBox5.Enabled = False
            ComboBox1.Enabled = False
            Load_buiding("")
        End If
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        Label42.Text = GET_ID_Building()
        MaskedTextBox5.Text = ""
        ComboBox1.SelectedIndex = 0
        MaskedTextBox5.Enabled = False
        ComboBox1.Enabled = False
        Button23.Text = "แก้ไข"
        Button24.Text = "เพิ่ม"
        Load_buiding("")
    End Sub
End Class