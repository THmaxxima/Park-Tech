Imports VB = Microsoft.VisualBasic
Public Class Mas_Station_Company
    Dim Tmp_Save_PicBack As String
    Dim Confirm As String = "ยืนยัน"
    Dim Tmp_Save_PicLogo As String
    Dim Tmp_Save_PicSlip As String
    Public Title_Error As String = "เกิดข้อผิดพลาด"
    Dim Active As String = ""
    Private Sub Mas_Station_Company_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        'Call Show_Compary()
        'AddCombo(ConnStrMasTer, Me.cmb_Province, "Mas_Province", "Prv_Code_TH", "Prv_ID", "", "Prv_ID", "--- จังหวัด ---")
        ' Pic_Logo.Image = Pic_Logo.ErrorImage
        lsv_Mas_Status_View()
        _Enable_False()
        If rdo_T.Checked = True Then Active = 1
        If rdo_F.Checked = True Then Active = 0
        If IsLog_Process Then Call mUser.Guidance_Log_User_Process(CurUser_ID, Me.Tag, "FROM", "ดู : " & Me.Text, Me.Name)

        'Show_Logo()
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        If btn_Add.Text = "เพิ่ม" Then
            lbl_ID.Text = Function_New_Tower_ID()
            btn_Add.Text = "บันทึก"
            _Enable_True()
            btn_Edit.Enabled = False
            btn_Del.Enabled = False
            txt_Name.Focus()

        ElseIf btn_Add.Text = "บันทึก" Then
            If txt_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อบริษัท ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Name.Focus()
                Exit Sub
            End If
            If msk_Tax_ID.Text = "" Then
                MsgBox("กรุณาป้อนเลขประจำตัวผู้เสียภาษี ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                msk_Tax_ID.Focus()
                Exit Sub
            End If
            If msk_Tax_ID.Text.Length < 13 Then
                MsgBox("กรุณาป้อนเลขประจำตัวผู้เสียภาษี ให้ครบ 13 ตัวอักษร ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                msk_Tax_ID.Focus()
                Exit Sub
            End If
            If txt_Address.Text = "" Then
                MsgBox("กรุณาป้อนที่อยู่ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Address.Focus()
                Exit Sub
            End If

            Call Save_Company()
            Call _Clear()
            Call lsv_Mas_Status_View()
            Call _Enable_False()
            btn_Edit.Enabled = True
            btn_Del.Enabled = True
            btn_Add.Text = "เพิ่ม"
        End If
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        If lbl_ID.Text = "" Then Exit Sub
        If btn_Edit.Text = "แก้ไข" Then
            _Enable_True()
            btn_Edit.Text = "บันทึก"
            btn_Add.Enabled = False
            btn_Del.Enabled = False
            txt_Name.Focus()
        ElseIf btn_Edit.Text = "บันทึก" Then
            If txt_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อบริษัท ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Name.Focus()
                Exit Sub
            End If
            If msk_Tax_ID.Text = "" Then
                MsgBox("กรุณาป้อนเลขประจำตัวผู้เสียภาษี ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                msk_Tax_ID.Focus()
                Exit Sub
            End If
            If msk_Tax_ID.Text.Length < 13 Then
                MsgBox("กรุณาป้อนเลขประจำตัวผู้เสียภาษี ให้ครบ 13 ตัวอักษร ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                msk_Tax_ID.Focus()
                Exit Sub
            End If
            If txt_Address.Text = "" Then
                MsgBox("กรุณาป้อนที่อยู่ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Address.Focus()
                Exit Sub
            End If
            'If Txt_Province.Text = "" Then
            '    MsgBox("กรุณาป้อนชื่อ จังหวัด", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
            '    Txt_Province.Focus()
            '    Exit Sub
            'End If
            'If Msk_Zip_code.Text = "" Then
            '    MsgBox("กรุณาป้อนรหัสไปรษณีย์", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
            '    Msk_Zip_code.Focus()
            '    Exit Sub
            'End If
            'If Msk_Zip_code.Text.Length < 5 Then
            '    MsgBox("กรุณาป้อนรหัสไปรษณีย์ ให้ครบ 5 ตัวอักษร", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
            '    Msk_Zip_code.Focus()
            '    Exit Sub
            'End If
            Call Update_Company()
            _Clear()
            Call lsv_Mas_Status_View()
            btn_Edit.Text = "แก้ไข"
            _Enable_False()
            btn_Add.Enabled = True
            btn_Del.Enabled = True
        End If
    End Sub
    Sub lsv_Mas_Status_View()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        'SELECT TOP 1000 [Tower_ID]
        '      ,[Tower_Name]
        '      ,[Tower_Location]
        '      ,[Tower_Tax]
        '      ,[Tower_Tel]
        '      ,[Tower_Fax]
        '      ,[Tower_Type]
        '      ,[Tower_Active]
        '  FROM [MTL_MASTER].[dbo].[Mas_Tower]
        sql = "SELECT * FROM Mas_Tower order by Tower_ID"
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    lsv_Mas_Status.Items.Clear()
                    lsv_Mas_Status.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Mas_Status.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        Dim New_Ent As ListViewItem = lsv_Mas_Status.Items.Add(rs.Fields("Tower_ID").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("Tower_Name").Value)
                        End With
                        .MoveNext()
                    Loop
                Else

                    lsv_Mas_Status.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Mas_Tower ", Err.Number, Err.Description)
    End Sub
    Private Function Function_New_Tower_ID() As String
        'ฟังก์ชันในการรันเลขที่เครื่อง E-STAMP
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select MAX(Tower_ID) from Mas_Tower "
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

        'Dim i As Integer
        'For i = F_ID.Length To 2
        '    F_ID = "0" & F_ID
        'Next

        Return F_ID
    End Function
    Sub Save_Company()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean
        Dim Tax As String = Report.Convert_Tax(msk_Tax_ID.Text)
        'SELECT TOP 1000 Tower_ID,Tower_Name ,Tower_Location,Tower_Tax,Tower_Tel,Tower_Fax,Tower_Type,Tower_Active
        '  FROM [MTL_MASTER].[dbo].[Mas_Tower]
        Try
            If OpenCnn(ConnStrMasTer, Conn) Then
                Conn.BeginTrans()
                TrnFlg = True
                sql = " Insert into Mas_Tower " & _
                      "(Tower_ID,Tower_Name ,Tower_Location,Tower_Tax,Tower_Tel,Tower_Fax,Tower_Type,Tower_Active)" & _
                      " Values ( " & lbl_ID.Text.Trim & _
                      ",'" & txt_Name.Text & _
                      "','" & txt_Address.Text & _
                      "','" & Tax & _
                      "','" & txt_Tel.Text & _
                      "','" & txt_Fax.Text & _
                      "'," & 0 & _
                      "," & Active & ")"
                Conn.Execute(sql)
                If MsgBox("คุณต้องการบันทึกข้อมูลนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                    Conn.CommitTrans()
                    If Not (Tmp_Save_PicBack = "") Then Call mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_Tower", "Tower_ID", "Tower_Picture", lbl_ID.Text, Tmp_Save_PicBack) 'Tmp_Save_Pict
                    If Not (Tmp_Save_PicLogo = "") Then Call mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_Tower", "Tower_ID", "Tower_Logo", lbl_ID.Text, Tmp_Save_PicLogo) 'Tmp_Save_Pict
                    '   If Not (Tmp_Save_PicSlip = "") Then Call mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_Tower", "Tower_ID", "Tower_Head_Slip", lbl_ID.Text, Tmp_Save_PicSlip) 'Tmp_Save_Slip

                    Tmp_Save_PicBack = ""
                    Tmp_Save_PicLogo = ""
                    Tmp_Save_PicSlip = ""
                Else
                    Conn.RollbackTrans()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            If TrnFlg = True Then Conn.RollbackTrans()
            Call mError.ShowError(Me.Name, "Save_Mas_Tower", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Update_Company()
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Try
            If rdo_T.Checked = True Then Active = 1
            If rdo_F.Checked = True Then Active = 0
            Dim Tax As String = Report.Convert_Tax(msk_Tax_ID.Text)
            sql = "Update Mas_Tower  set Tower_Name ='" & txt_Name.Text & _
                  "', Tower_Tax = '" & Tax & _
                  "', Tower_Location = '" & txt_Address.Text & _
                  "', Tower_Tel = '" & txt_Tel.Text & _
                  "', Tower_Fax = '" & txt_Fax.Text & _
                  "', Tower_Type = 0" & _
                  ", Tower_Active = " & Active & _
                  " where Tower_ID = " & lbl_ID.Text.Trim & ""
            If OpenCnn(ConnStrMasTer, Conn) Then
                Conn.BeginTrans()
                TrnFlg = True
                Conn.Execute(sql)
                If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                    Conn.CommitTrans()
                    'Exit Sub
                Else
                    Conn.RollbackTrans()
                    TrnFlg = False
                End If
                If Not (Tmp_Save_PicBack = "") Then Call mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_Tower", "Tower_Id", "Tower_Picture", lbl_ID.Text, Tmp_Save_PicBack) 'Tmp_Save_Pict
                If Not (Tmp_Save_PicLogo = "") Then Call mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_Tower", "Tower_Id", "Tower_Logo", lbl_ID.Text, Tmp_Save_PicLogo) 'Tmp_Save_Pict
                '    If Not (Tmp_Save_PicSlip = "") Then Call mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_Tower", "Tower_ID", "Tower_Head_Slip", lbl_ID.Text, Tmp_Save_PicSlip) 'Tmp_Save_Slip

                Tmp_Save_PicBack = ""
                Tmp_Save_PicLogo = ""
                Tmp_Save_PicSlip = ""
            End If
            Conn = Nothing
            rs = Nothing
        Catch ex As Exception
            Conn.RollbackTrans()
            Save_Company()
            'Finally
            'Call mError.ShowError(Me.Name, "Mas_Staion_Company", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Show_Compary()
        'SELECT TOP 1000 [Tower_ID]
        '      ,[Tower_Name]
        '      ,[Tower_Location]
        '      ,[Tower_Tax]
        '      ,[Tower_Tel]
        '      ,[Tower_Fax]
        '      ,[Tower_Type]
        '      ,[Tower_Active]
        '  FROM [MTL_MASTER].[dbo].[Mas_Tower]
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Try
            sql = "SELECT * FROM Mas_Tower  where Tower_ID =" & lbl_ID.Text & " "
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        .MoveFirst()
                        txt_Name.Text = rs.Fields("Tower_Name").Value '= rs.Fields("").Value
                        txt_Address.Text = rs.Fields("Tower_Location").Value
                        'Txt_Province.Text = rs.Fields("Company_Povince").Value
                        'Msk_Zip_code.Text = rs.Fields("Zip_Code").Value
                        msk_Tax_ID.Text = rs.Fields("Tower_Tax").Value
                        txt_Tel.Text = rs.Fields("Tower_Tel").Value
                        txt_Fax.Text = rs.Fields("Tower_Fax").Value 'Tower_Fax
                        If rs.Fields("Tower_Active").Value = 0 Then
                            rdo_T.Checked = False
                            rdo_F.Checked = True
                        Else
                            rdo_T.Checked = True
                            rdo_F.Checked = False
                        End If
                    End If
                End With
            End If
            If rdo_T.Checked = True Then Active = 1
            If rdo_F.Checked = True Then Active = 0
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Mas_Tower", Err.Number, Err.Description)
        End Try
    End Sub
    'Sub Show_Logo()
    '    Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
    '    Try
    '        sql = "Select Company_Logo from Mas_Staion_Company "
    '        If OpenCnn(ConnStrMasTer, Conn) Then
    '            With rs
    '                If .State = 1 Then .Close()
    '                .ActiveConnection = Conn
    '                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
    '                .Open(sql)
    '                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
    '                If Not (.EOF And .BOF) Then
    '                    If Not VB.IsDBNull(.Fields("Company_Logo").Value) Then
    '                        Dim RetByte() As Byte = CType(.Fields("Company_Logo").Value, Byte())
    '                        Dim PictureData() As Byte = RetByte
    '                        Dim Ms As New System.IO.MemoryStream(PictureData)
    '                        Pic_Logo.Image = Image.FromStream(Ms)
    '                    Else
    '                        Pic_Logo.Image = Pic_Logo.ErrorImage
    '                    End If

    '                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '                Else
    '                    rs.Close()
    '                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default : Me.Enabled = True : Exit Sub
    '                End If
    '            End With
    '            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '        End If
    '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '        Me.Enabled = True
    '        Exit Sub
    '    Catch ex As Exception
    '        Call mError.ShowError(Me.Name, "Show_Logo", Err.Number, Err.Description)
    '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '        Me.Enabled = True
    '    End Try
    'End Sub
    'Private Sub btn_Logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        With Opg_Logo
    '            .Title = "เลือกรูปภาพ"
    '            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg;*.JPEG"
    '            .ShowDialog()
    '            Tmp_Save_PicLogo = .FileName : Pic_Logo.Visible = True
    '            Pic_Logo.Image = System.Drawing.Image.FromFile(Tmp_Save_PicLogo)
    '        End With
    '        Exit Sub
    '    Catch ex As Exception
    '        Call mError.ShowError(Me.Name, "btn_Logo_Click", Err.Number, Err.Description)
    '    End Try

    'End Sub

    Private Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub
    Sub _Enable_True()
        txt_Name.Enabled = True
        msk_Tax_ID.Enabled = True
        txt_Address.Enabled = True
        txt_Tel.Enabled = True
        txt_Fax.Enabled = True
        btn_Back_Ground.Enabled = True
        btn_Logo.Enabled = True
        btn_Slip.Enabled = True
    End Sub
    Sub _Enable_False()
        txt_Name.Enabled = False
        msk_Tax_ID.Enabled = False
        txt_Address.Enabled = False
        txt_Tel.Enabled = False
        txt_Fax.Enabled = False
        btn_Back_Ground.Enabled = False
        btn_Logo.Enabled = False
        btn_Slip.Enabled = False
        lbl_ID.Text = ""
    End Sub
    Sub _Clear()
        txt_Name.Clear()
        msk_Tax_ID.Clear()
        txt_Address.Clear()
        'Txt_Province.Clear()
        'Msk_Zip_code.Clear()
        txt_Tel.Clear()
        txt_Fax.Clear()
        lbl_ID.Text = ""
    End Sub

    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
        _Enable_False()
        _Clear()
        btn_Add.Text = "เพิ่ม"
        btn_Edit.Text = "แก้ไข"
        btn_Add.Enabled = True
        btn_Edit.Enabled = True
        btn_Del.Enabled = True
    End Sub

    Private Sub txt_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Address.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Name.TextChanged

    End Sub


    Private Sub Txt_Province_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Msk_Zip_code_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            msk_Tax_ID.Focus()
            Exit Sub
        End If
    End Sub



    Private Sub txt_Tel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Tel.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Fax.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Tel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Tel.TextChanged

    End Sub

    Private Sub txt_Fax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Fax.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If btn_Add.Visible = False Then
                btn_Edit.Focus()
            Else
                btn_Add.Focus()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub txt_Fax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Fax.TextChanged

    End Sub

    Private Sub lsv_Mas_Status_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Status.MouseClick
        With lsv_Mas_Status
            lbl_ID.Text = .FocusedItem.SubItems(0).Text
        End With
        Show_Compary()
        Call Me.Show_Back_Ground(lbl_ID.Text)
        Call Me.Show_Pic_Logo(lbl_ID.Text)
        '       Call Me.Show_Pic_Slip(lbl_ID.Text)
    End Sub
    Function Show_Back_Ground(ByVal ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Pic_Back_Ground.Controls.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select Tower_Picture from Mas_Tower WHERE Tower_Id = " & ID & ""
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    If Not VB.IsDBNull(.Fields("Tower_Picture").Value) Then
                        Dim RetByte() As Byte = CType(.Fields("Tower_Picture").Value, Byte())
                        Dim PictureData() As Byte = RetByte
                        Dim Ms As New System.IO.MemoryStream(PictureData)
                        Pic_Back_Ground.Image = Image.FromStream(Ms)
                    Else
                        Pic_Back_Ground.Image = Pic_Back_Ground.ErrorImage
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

        Call mError.ShowError(Me.Name, "Show_Back_Ground", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Return False
    End Function
    Function Show_Pic_Logo(ByVal ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Pic_Logo.Controls.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select Tower_Logo from Mas_Tower WHERE Tower_Id = " & ID & ""
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    If Not VB.IsDBNull(.Fields("Tower_Logo").Value) Then
                        Dim RetByte() As Byte = CType(.Fields("Tower_Logo").Value, Byte())
                        Dim PictureData() As Byte = RetByte
                        Dim Ms As New System.IO.MemoryStream(PictureData)
                        Pic_Logo.Image = Image.FromStream(Ms)
                    Else
                        Pic_Logo.Image = Pic_Logo.ErrorImage
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
        Call mError.ShowError(Me.Name, "Show_Pic_Logo", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Return False
    End Function

    Function Show_Pic_Slip(ByVal ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Pic_Logo.Controls.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select Tower_Head_Slip from Mas_Tower WHERE Tower_Id = " & ID & ""
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    If Not VB.IsDBNull(.Fields("Tower_Head_Slip").Value) Then
                        Dim RetByte() As Byte = CType(.Fields("Tower_Head_Slip").Value, Byte())
                        Dim PictureData() As Byte = RetByte
                        Dim Ms As New System.IO.MemoryStream(PictureData)
                        Pic_Slip.Image = Image.FromStream(Ms)
                    Else
                        Pic_Slip.Image = Pic_Slip.ErrorImage
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
        Call mError.ShowError(Me.Name, "Show_Pic_Slip", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Return False
    End Function

    Private Sub rdo_T_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_T.CheckedChanged
        If rdo_T.Checked = True Then Active = 1
        If rdo_F.Checked = True Then Active = 0
    End Sub

    Private Sub rdo_F_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_F.CheckedChanged
        If rdo_T.Checked = True Then Active = 1
        If rdo_F.Checked = True Then Active = 0
    End Sub

    Private Sub btn_Back_Ground_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Back_Ground.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With Opg_Back
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg;*.JPEG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_PicBack = .FileName : Pic_Back_Ground.Visible = True
            Pic_Back_Ground.Image = System.Drawing.Image.FromFile(Tmp_Save_PicBack)
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Back_Ground_Click", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Logo.Click
        On Error GoTo Err_Renamed
        With Opg_Logo
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg;*.JPEG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_PicLogo = .FileName : Pic_Logo.Visible = True
            Pic_Logo.Image = System.Drawing.Image.FromFile(Tmp_Save_PicLogo)
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Logo_Click", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Del.Click

        If lbl_ID.Text = "" Then Exit Sub
        Try
            Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
            sql = " DELETE From Mas_Tower WHERE Tower_ID = " & lbl_ID.Text & ""
            If OpenCnn(ConnStrMasTer, Conn) Then
                Conn.BeginTrans()
                TrnFlg = True
                Conn.Execute(sql)
                If MsgBox("คุณต้องการ ลบข้อมูล รหัส  : " & lbl_ID.Text & vbCrLf & _
                           "ชื่อ : " & txt_Name.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                    Conn.CommitTrans()
                    Call lsv_Mas_Status_View()
                Else
                    Conn.RollbackTrans()
                    Exit Sub
                End If
            End If
            _Clear()
            Exit Sub
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Delete_Mas_HW_Status", Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub lsv_Mas_Status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv_Mas_Status.SelectedIndexChanged

    End Sub

    Private Sub btn_Slip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Slip.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With Opg_Back
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg;*.JPEG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_PicSlip = .FileName : Pic_Slip.Visible = True
            Pic_Slip.Image = System.Drawing.Image.FromFile(Tmp_Save_PicSlip)
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Back_Slip_Click", Err.Number, Err.Description)
    End Sub
End Class
