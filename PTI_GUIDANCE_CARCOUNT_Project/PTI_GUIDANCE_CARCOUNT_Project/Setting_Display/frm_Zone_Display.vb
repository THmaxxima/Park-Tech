Option Explicit On
'Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO.Stream
Imports VB = Microsoft.VisualBasic
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Public Class frm_Zone_Display
    Dim Go As Boolean
    Dim LeftSet As Boolean
    Dim TopSet As Boolean

    REM These will hold the mouse position
    Dim HoldLeft As Integer
    Dim HoldTop As Integer

    REM These will hold the offset of the mouse in the element
    Dim OffLeft As Integer
    Dim OffTop As Integer

    Dim Fore_Color_A As Integer = 255
    Dim Fore_Color_R As Integer = 255
    Dim Fore_Color_G As Integer = 0
    Dim Fore_Color_B As Integer = 0
    Dim Back_Color_A As Integer = 255
    Dim Back_Color_R As Integer = 0
    Dim Back_Color_G As Integer = 0
    Dim Back_Color_B As Integer = 0
    Dim A, R, G, B As Integer
    Dim lbl(100) As Label
    Dim PID(100) As Label
    Dim lbl_Z(100) As Label
    Dim Zone_Id As String = ""

    Private Sub frm_Zone_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        AddCombo(ConnStrMasTer, Me.cmb_Tower, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")

        ' AddCombo(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "Floor_Name", "Floor_Id", "", "Floor_Id", "---กรุณาเลือก ชั้น---")
        User_Level = 9
        lbl_EXC.Location = New Point(365, 33)
        If User_Level <> "9" Then
            btn_Add.Visible = False
            btn_Delete.Visible = False
        End If
    End Sub
    Private Function Function_New_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(Zone_Id) from Mas_Zone_Display"
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

    Sub Load_List_Zone(Optional ByVal Floor_No As String = "", Optional ByVal Building_ID As String = "", Optional ByVal Tower_ID As String = "")
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        If cmb_Floor.SelectedIndex <= 0 Then Exit Sub

        sql = "SELECT * FROM Mas_Zone_Display WHERE Zone_Floor_No = " & Floor_No & ""
        If Building_ID.Trim <> "" Then sql &= " and Zone_Building_ID = " & Building_ID & ""
        If Tower_ID.Trim <> "" Then sql &= "  and Zone_Tower_ID = " & Tower_ID & ""

        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    Lsv_Zone.Items.Clear()
                    Lsv_Zone.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    Lsv_Zone.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        ' tl = rs.RecordCount
                        Dim New_Ent As ListViewItem = Lsv_Zone.Items.Add(rs.Fields("Zone_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("Zone_Display_No").Value & " : " & rs.Fields("Zone_Display_Name").Value) 'Zone_Display_Name
                        End With
                        .MoveNext()
                    Loop
                Else
                    Lsv_Zone.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "แสดง List ป้ายจำนวนชั้นจอดรถ ", Err.Number, Err.Description)
    End Sub

    Sub Update_Zone()
        On Error GoTo Err
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "Update Mas_Zone_Display set Zone_Display_Name = '" & txt_Zone_Name.Text & _
                          "', Zone_PositionX = " & lbl_LocationX.Text & _
                          ", Zone_PositionY = " & lbl_LocationY.Text & _
                          ", Zone_SizeX = " & txt_SizeX.Text.Trim & _
                          ", Zone_SizeY = " & txt_SizeY.Text.Trim & _
                          ", Zone_Font_ColorA = " & Fore_Color_A & _
                          ", Zone_Font_ColorR = " & Fore_Color_R & _
                          ", Zone_Font_ColorG = " & Fore_Color_G & _
                          ", Zone_Font_ColorB = " & Fore_Color_B & _
                          ", Zone_Back_ColorA = " & Back_Color_A & _
                          ", Zone_Back_ColorR = " & Back_Color_R & _
                          ", Zone_Back_ColorG = " & Back_Color_G & _
                          ", Zone_Back_ColorB = " & Back_Color_B & _
                          ", Font_Size = " & txt_Font_Size.Text.Trim & ""
        sql &= " , Zone_Display_No = " & cmb_Dis_No.Text & ""
        sql &= "  , [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
        sql &= "  , Zone_Building_ID = " & cmb_Building.SelectedValue & ""
        sql &= " , [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""
        sql &= " where Zone_Id =" & lbl_Zone_Id.Text & ""


        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                TrnFlg = False
            Else
                Conn.RollbackTrans()
                TrnFlg = False
            End If
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "แก้ไขป้าย แสดงผลตามชั้น ", Err.Number, Err.Description)
    End Sub
    Sub Save_Mas_Floor_Zone()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim sql_Value As String = ""
        Dim TrnFlg As Boolean

        Dim Permit As Short
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True

            sql &= " INSERT INTO [Mas_Zone_Display]"
            sql &= "([Zone_Id]"
            sql_Value &= " Values (" & lbl_Zone_Id.Text & ""

            sql &= " ,[Zone_Tower_ID]"
            sql_Value &= "," & cmb_Tower.SelectedValue & ""

            sql &= ",[Zone_Building_ID]"
            sql_Value &= "," & cmb_Building.SelectedValue & ""

            sql &= ",[Zone_Floor_No]"
            sql_Value &= "," & cmb_Floor.SelectedValue & ""

            sql &= ",[Zone_Display_No]"
            sql_Value &= ",'" & cmb_Dis_No.Text.Trim() & "'"

            sql &= " ,[Zone_Display_Name]"
            sql_Value &= ",'" & txt_Zone_Name.Text & "'"

            sql &= " ,[Zone_PositionX]"
            sql_Value &= "," & lbl_LocationX.Text & ""

            sql &= " ,[Zone_PositionY]"
            sql_Value &= "," & lbl_LocationY.Text & ""

            sql &= ",[Zone_SizeX]"
            sql_Value &= "," & txt_SizeX.Text.Trim & ""

            sql &= " ,[Zone_SizeY]"
            sql_Value &= "," & txt_SizeY.Text.Trim & ""

            sql &= ",[Zone_Font_ColorA]"
            sql_Value &= "," & Fore_Color_A & ""

            sql &= " ,[Zone_Font_ColorR]"
            sql_Value &= "," & Fore_Color_R & ""

            sql &= ",[Zone_Font_ColorG]"
            sql_Value &= "," & Fore_Color_G & ""

            sql &= ",[Zone_Font_ColorB]"
            sql_Value &= "," & Fore_Color_B & ""

            sql &= ",[Zone_Back_ColorA]"
            sql_Value &= "," & Back_Color_A & ""

            sql &= ",[Zone_Back_ColorR]"
            sql_Value &= "," & Back_Color_R & ""

            sql &= ",[Zone_Back_ColorG]"
            sql_Value &= "," & Back_Color_G & ""

            sql &= ",[Zone_Back_ColorB]"
            sql_Value &= "," & Back_Color_B & ""

            sql &= " ,[Font_Size])"
            sql_Value &= "," & txt_Font_Size.Text.Trim & ")"
            Conn.Execute(sql & sql_Value)
            If MsgBox("คุณต้องการบันทึกข้อมูลนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                TrnFlg = False
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "บันทึกข้อมูล ป้ายแสดงผลตามชั้น", Err.Number, Err.Description)
    End Sub

    Private Sub cmb_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floor.SelectedIndexChanged
        If cmb_Floor.SelectedIndex > 0 Then
            Me.Picture_Floor.Controls.Clear()
            Me.Show_Picture(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_Display_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_Floor_Zone_Name(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_List_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            cmb_Dis_No.Enabled = True
        End If
    End Sub
    Function Show_Picture(ByVal Floor_No As String, ByVal Building_ID As String, ByVal Tower_ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Picture_Floor.Controls.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select * from Mas_Floor WHERE Floor_No = " & Floor_No & " and Building_ID = " & Building_ID & " and Tower_ID = " & Tower_ID & ""
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    If Not VB.IsDBNull(.Fields("Floor_Image").Value) Then
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

    Private Sub btn_Fore_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Fore_Color.Click
        Try
            With Dlg_Fore_Collor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim fColor As String = .Color.Name
                    Fore_Color_A = .Color.A
                    Fore_Color_R = .Color.R
                    Fore_Color_G = .Color.G
                    Fore_Color_B = .Color.B
                    lbl_Fore_Color.BackColor = .Color
                    lbl_EXC.ForeColor = .Color
                    lbl(Zone_Id).ForeColor = .Color
                Else
                    lbl_Fore_Color.BackColor = Color.Red
                    lbl_EXC.ForeColor = Color.Red
                    Exit Sub
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Back_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Back_Color.Click
        With Dlg_Back_Color
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fColor As String = .Color.Name
                Back_Color_A = .Color.A
                Back_Color_R = .Color.R
                Back_Color_G = .Color.G
                Back_Color_B = .Color.B
                lbl_Back_Color.BackColor = .Color
                lbl(Zone_Id).BackColor = .Color
                lbl_EXC.BackColor = .Color
            Else
                lbl_Back_Color.BackColor = Color.Black
                lbl_EXC.BackColor = Color.Black
                Exit Sub
            End If
        End With
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        If cmb_Floor.SelectedIndex <= 0 Then
            MsgBox("กรุณาเลือกชั้นที่ต้องการ จัดโซน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
            Exit Sub
        End If

        If btn_Add.Text = "เพิ่ม" Then
            btn_Add.Text = "บันทึก"
            lbl_Zone_Id.Text = Me.Function_New_ID()

            btn_Back_Color.Enabled = True
            btn_Fore_Color.Enabled = True
            btn_Edit.Enabled = False
            btn_Delete.Enabled = False
            txt_Zone_Name.Enabled = True
            txt_SizeX.Enabled = True
            txt_SizeY.Enabled = True
            txt_Font_Size.Enabled = True
            txt_Zone_Name.Enabled = True
            If txt_Zone_Name.Text.Trim = "" Then Exit Sub
            If txt_SizeX.Text.Trim = "" Then Exit Sub
            If txt_SizeY.Text.Trim = "" Then Exit Sub
            If txt_Zone_Name.Text.Trim = "" Then Exit Sub

            Call Add_Page_Zone() 'Add

        Else
            If txt_Zone_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อโซน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_Zone_Name.Focus()
                Exit Sub
            End If
            If txt_SizeX.Text = "" Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeX.Focus()
                Exit Sub
            End If

            If txt_SizeY.Text = "" Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeY.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_SizeX.Text) = False Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeX.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_SizeY.Text) = False Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeY.Focus()
                Exit Sub
            End If
            If txt_Font_Size.Text = "" Then
                MsgBox("กรุณาป้อนขนาด ตัวอักษร ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_Font_Size.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_Font_Size.Text) = False Then
                MsgBox("กรุณาระบุขนาดของ ตัวอักษร ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_Font_Size.Focus()
                Exit Sub
            End If

            Call Save_Mas_Floor_Zone()
            Call Load_Display_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_Floor_Zone_Name(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_List_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            txt_Zone_Name.Clear()
            Defaulf_Object()
            btn_Add.Text = "เพิ่ม"
        End If
    End Sub
    Sub Defaulf_Object()
        btn_Edit.Enabled = True
        btn_Edit.Text = "แก้ไข"

        btn_Delete.Enabled = True

        btn_Add.Text = "เพิ่ม"
        btn_Add.Enabled = True

        btn_Back_Color.Enabled = False
        btn_Fore_Color.Enabled = False
        'txt_Zone_Name.Clear()
        'txt_SizeX.Clear()
        'txt_SizeY.Clear()
        'txt_Font_Size.Clear()
        lbl_Zone_Id.Text = ""
        lbl_LocationX.Text = ""
        lbl_LocationY.Text = ""
        txt_SizeX.Enabled = False
        txt_SizeY.Enabled = False
        txt_Font_Size.Enabled = False
        txt_Zone_Name.Enabled = False
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        If cmb_Floor.SelectedIndex <= 0 Then
            MsgBox("กรุณาเลือกชั้นที่ต้องการ แก้ไข โซน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
            Exit Sub
        End If
        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.Text = "บันทึก"
            btn_Back_Color.Enabled = True
            btn_Fore_Color.Enabled = True
            txt_Zone_Name.Enabled = True
            txt_SizeX.Enabled = True
            txt_SizeY.Enabled = True
            txt_Font_Size.Enabled = True

        ElseIf btn_Edit.Text = "บันทึก" Then
            If txt_Zone_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อโซน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_Zone_Name.Focus()
                Exit Sub
            End If
            If txt_SizeX.Text = "" Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeX.Focus()
                Exit Sub
            End If

            If txt_SizeY.Text = "" Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeY.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_SizeX.Text) = False Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeX.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_SizeY.Text) = False Then
                MsgBox("กรุณาระบุขนาดของ ป้ายแสดงจำนวนรถ ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_SizeY.Focus()
                Exit Sub
            End If
            If txt_Font_Size.Text = "" Then
                MsgBox("กรุณาป้อนขนาด ตัวอักษร ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_Font_Size.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_Font_Size.Text) = False Then
                MsgBox("กรุณาระบุขนาดของ ตัวอักษร ให้เป็นตัวเลข ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
                txt_Font_Size.Focus()
                Exit Sub
            End If
            Call Update_Zone()
            Call Load_Display_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_List_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Defaulf_Object()
            Call Load_Floor_Zone_Name(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        End If
    End Sub

    Private Sub txt_SizeX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SizeX.TextChanged
        If rdo_Display.Checked = True Then

            Try
                If txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
                    lbl_EXC.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                End If
                If lbl_Zone_Id.Text <> "" And txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
                    lbl(lbl_Zone_Id.Text).Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                End If
            Catch ex As Exception

            End Try

        Else
            Try
                If txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
                    Pic_EXC.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                End If
                'If lbl_Zone_Id.Text <> "" And txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
                '    lbl(lbl_Zone_Id.Text).Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                'End If
            Catch ex As Exception

            End Try


        End If

    End Sub
    Sub Add_Page_Zone()
        Dim I_Index As Short = 0
        I_Index = lbl_Zone_Id.Text
        lbl_Z(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
        With Me.lbl_Z(I_Index)
            .Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text)) 'ขนาด button
            .Name = "lbl" & I_Index 'ชื่อ button
            .Tag = I_Index
            .Text = I_Index
            .Font = New Font("7 Segment", CInt(txt_Font_Size.Text), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
            .BorderStyle = BorderStyle.Fixed3D
            .TextAlign = ContentAlignment.BottomCenter
            .Cursor = Cursors.Hand
            .TabIndex = I_Index
            .BackColor = Color.FromArgb(Back_Color_A, Back_Color_R, Back_Color_G, Back_Color_B)
            .ForeColor = Color.FromArgb(Fore_Color_A, Fore_Color_R, Fore_Color_G, Fore_Color_B)
            .Location = New Point(101, 69)
            .Parent = Me
            AddHandler .Click, AddressOf Me.Button_Click
            AddHandler .MouseDown, AddressOf nodebtn_MouseDown
            AddHandler .MouseMove, AddressOf nodebtn_MouseMove
            AddHandler .MouseUp, AddressOf nodebtn_MouseUp
            AddHandler .KeyPress, AddressOf NumericValuesOnly
            'AddHandler .KeyUp, AddressOf iKeyUp
            'AddHandler .KeyDown, AddressOf iKey
            Me.Picture_Floor.Controls.Add(lbl_Z(I_Index)) 'เพิ่ม Button
            lbl_EXC.Location = New Point(365, 33)
        End With
    End Sub
    Sub NumericValuesOnly(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case Asc(e.KeyChar)
            Case AscW(ControlChars.Cr) 'Enter key
                e.Handled = True

            Case AscW(ControlChars.Back) 'Backspace

            Case 45, 46, 48 To 57 'Negative sign, Decimal and Numbers

            Case Else ' Everything else
                e.Handled = True
        End Select
    End Sub
    Private Sub iKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        Dim Result As DialogResult
        Result = MsgBox("คุณต้องการลบ ตำแหน่งนี้ใช่หรือไม่", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, Confirm)
        If Result = Windows.Forms.DialogResult.Yes Then
            If e.KeyCode = 46 Then
                Me.Picture_Floor.Controls.Remove(sender)
            End If
        End If

    End Sub
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Go = True Then
            REM Set the mouse position
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            REM Find where the mouse was clicked ONE TIME
            If TopSet = False Then
                OffTop = HoldTop - sender.Top
                REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                TopSet = True
            End If
            If LeftSet = False Then
                OffLeft = HoldLeft - sender.Left
                REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                LeftSet = True
            End If

            REM Set the position of the object
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
            lbl_LocationX.Text = sender.Left
            lbl_LocationY.Text = sender.Top
            Zone_Id = "" & sender.tag
            Call Select_Detail_Board()
        End If
    End Sub

    Sub Select_Detail_Board()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            'Picture_Floor.Controls.Clear()
            sql &= " SELECT * FROM Mas_Zone_Display "
            sql &= " where Zone_Id = " & Zone_Id & ""
            sql &= " and [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
            sql &= " and [Zone_Building_ID] = " & cmb_Building.SelectedValue & ""
            sql &= " and [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""

            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        ' .MoveFirst()
                        'Do While Not .EOF
                        lbl_Zone_Id.Text = Zone_Id
                        txt_Zone_Name.Text = rs.Fields("Zone_Display_Name").Value
                        txt_SizeX.Text = rs.Fields("Zone_SizeX").Value
                        txt_SizeY.Text = rs.Fields("Zone_SizeY").Value
                        cmb_Dis_No.Text = rs.Fields("Zone_Display_No").Value
                        txt_Font_Size.Text = rs.Fields("Font_Size").Value
                        Back_Color_A = rs.Fields("Zone_Back_ColorA").Value
                        Back_Color_R = rs.Fields("Zone_Back_ColorR").Value
                        Back_Color_G = rs.Fields("Zone_Back_ColorG").Value
                        Back_Color_B = rs.Fields("Zone_Back_ColorB").Value

                        lbl_Back_Color.BackColor = Color.FromArgb(Back_Color_A, Back_Color_R, Back_Color_G, Back_Color_B)
                        Fore_Color_A = rs.Fields("Zone_Font_ColorA").Value
                        Fore_Color_R = rs.Fields("Zone_Font_ColorR").Value
                        Fore_Color_G = rs.Fields("Zone_Font_ColorG").Value
                        Fore_Color_B = rs.Fields("Zone_Font_ColorB").Value
                        lbl_Fore_Color.BackColor = Color.FromArgb(Fore_Color_A, Fore_Color_R, Fore_Color_G, Fore_Color_B)
                        '.MoveNext()
                        'Loop
                    Else
                    End If
                End With
            End If
            lbl_EXC.Location = New Point(365, 33)
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Select_Detail_Board", Err.Number, Err.Description)
        End Try

    End Sub
    Private Sub nodebtn_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        REM Check if the mouse is down

        If Go = True Then
            REM Set the mouse position
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            REM Find where the mouse was clicked ONE TIME
            If TopSet = False Then
                OffTop = HoldTop - sender.Top  REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                TopSet = True
            End If
            If LeftSet = False Then
                OffLeft = HoldLeft - sender.Left
                REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                LeftSet = True
            End If

            REM Set the position of the object
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
            lbl_LocationX.Text = sender.Left
            lbl_LocationY.Text = sender.Top
            ' txt_Zone_Name.Text = sender.name
        End If
    End Sub
    Private Sub nodebtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = True
    End Sub
    Private Sub nodebtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = False
        LeftSet = False
        TopSet = False
    End Sub
    Sub Load_Display_Zone(ByVal FloorNo As String, ByVal Building_ID As String, ByVal TowerID As String)
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            Picture_Floor.Controls.Clear()
            sql = " SELECT * FROM Mas_Zone_Display "
            sql &= " where Zone_Floor_No =" & cmb_Floor.SelectedValue & ""
            If Building_ID.Trim <> "" Then sql &= " and Zone_Building_ID =  " & Building_ID & ""
            If TowerID.Trim <> "" Then sql &= " and Zone_Tower_ID =  " & TowerID & ""
            sql &= " order by Zone_Id "

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
                            I_Index = Val(I_Index) + 1
                            lbl_Z(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                            With Me.lbl_Z(I_Index)
                                .Size = New Size(CInt(rs.Fields("Zone_SizeX").Value), CInt(rs.Fields("Zone_SizeY").Value)) 'ขนาด button
                                .Name = "lbl" & rs.Fields("Zone_Id").Value  'ชื่อ button
                                .Tag = rs.Fields("Zone_Id").Value
                                .Text = rs.Fields("Zone_Id").Value 'Zone_Name
                                .Font = New Font("7 Segment", CInt(rs.Fields("Font_Size").Value), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                .Cursor = Cursors.Hand
                                .TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("Zone_Back_ColorA").Value, rs.Fields("Zone_Back_ColorR").Value, rs.Fields("Zone_Back_ColorG").Value, rs.Fields("Zone_Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("Zone_Font_ColorA").Value, rs.Fields("Zone_Font_ColorR").Value, rs.Fields("Zone_Font_ColorG").Value, rs.Fields("Zone_Font_ColorB").Value)
                                .Location = New Point(rs.Fields("Zone_PositionX").Value, rs.Fields("Zone_PositionY").Value)
                                .Parent = Me
                                AddHandler .Click, AddressOf Me.Button_Click
                                AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                                AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                                AddHandler .MouseUp, AddressOf nodebtn_MouseUp
                                Me.Picture_Floor.Controls.Add(lbl_Z(I_Index)) 'เพิ่ม Button
                            End With
                            .MoveNext()
                        Loop
                    Else
                    End If
                End With
            End If
            lbl_EXC.Location = New Point(597, 44)
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
        End Try

    End Sub
    Private Sub lbl_EXC_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_EXC.MouseClick
        If Go = True Then
            REM Set the mouse position
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            REM Find where the mouse was clicked ONE TIME
            If TopSet = False Then
                OffTop = HoldTop - sender.Top
                REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                TopSet = True
            End If
            If LeftSet = False Then
                OffLeft = HoldLeft - sender.Left
                REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                LeftSet = True
            End If
            REM Set the position of the object
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
        End If
    End Sub

    Private Sub lbl_EXC_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_EXC.MouseDown
        Go = True
    End Sub

    Private Sub lbl_EXC_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_EXC.MouseMove

        If Go = True Then
            REM Set the mouse position
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            REM Find where the mouse was clicked ONE TIME
            If TopSet = False Then
                OffTop = HoldTop - sender.Top  REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                TopSet = True
            End If
            If LeftSet = False Then
                OffLeft = HoldLeft - sender.Left
                REM Once the position is held, flip the switch so that it doesn't keep trying to find the position
                LeftSet = True
            End If

            REM Set the position of the object
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
            lbl_LocationX.Text = sender.Left
            lbl_LocationY.Text = sender.Top
        End If
    End Sub

    Private Sub lbl_EXC_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_EXC.MouseUp
        Go = False
    End Sub

    Private Sub txt_SizeY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SizeY.TextChanged
        If rdo_Display.Checked = True Then
            Try
                If txt_SizeX.Text <> "" And txt_SizeY.Text <> "" And IsNumeric(txt_SizeX.Text) = True And IsNumeric(txt_SizeY.Text) = True Then
                    lbl_EXC.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                End If
                If Val(txt_SizeY.Text) > 0 And txt_SizeY.Text.Trim <> "" And lbl_Zone_Id.Text <> "" Then
                    lbl_Z(lbl_Zone_Id.Text).Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                End If
            Catch ex As Exception

            End Try
        Else
            Try
                If txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
                    Pic_EXC.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                End If
                'If lbl_Zone_Id.Text <> "" And txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
                '    lbl(lbl_Zone_Id.Text).Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                'End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub txt_Font_Size_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Font_Size.TextChanged
        If txt_Font_Size.Text <> "" And IsNumeric(txt_Font_Size.Text) = True Then
            lbl_EXC.Font = New Font("7 Segment", CInt(txt_Font_Size.Text), FontStyle.Regular)
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If lbl_Zone_Id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
            Exit Sub
        End If

        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_Zone_Display WHERE Zone_Id = " & lbl_Zone_Id.Text & " "
        sql &= "  , [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
        sql &= "  , Zone_Building_ID] = " & cmb_Building.SelectedValue & ""
        sql &= " , [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส : " & lbl_Zone_Id.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                TrnFlg = False
            Else
                Conn.RollbackTrans()
                TrnFlg = False
                Exit Sub
            End If
            Conn = Nothing
        End If
        Call Load_List_Zone()
        Call Load_Display_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        Call Load_Floor_Zone_Name(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "btn_Delete_Click", Err.Number, Err.Description)
        Call Load_List_Zone()
    End Sub

    Private Sub Lsv_Zone_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lsv_Zone.MouseClick
        Try
            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim sql As String
            sql = "SELECT * FROM Mas_Zone_Display where Zone_Id = " & Lsv_Zone.FocusedItem.SubItems(0).Text & ""
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        Dim c As Integer = .RecordCount
                        lbl_Zone_Id.Text = Lsv_Zone.FocusedItem.SubItems(0).Text
                        '  Me.Show_Picture(rs.Fields("Floor_Id").Value)
                        lbl_Zone_Id.Text = rs.Fields("Zone_Id").Value
                        txt_Zone_Name.Text = rs.Fields("Zone_Display_Name").Value
                        lbl_LocationX.Text = rs.Fields("Zone_PositionX").Value
                        lbl_LocationY.Text = rs.Fields("Zone_PositionY").Value
                        ' cmb_Floor.SelectedValue = rs.Fields("Floor_Id").Value
                        txt_SizeX.Text = rs.Fields("Zone_SizeX").Value
                        txt_SizeY.Text = rs.Fields("Zone_SizeY").Value
                        lbl_Fore_Color.BackColor = Color.FromArgb(rs.Fields("Zone_Font_ColorA").Value, rs.Fields("Zone_Font_ColorR").Value, rs.Fields("Zone_Font_ColorG").Value, rs.Fields("Zone_Font_ColorB").Value)
                        lbl_Back_Color.BackColor = Color.FromArgb(rs.Fields("Zone_Back_ColorA").Value, rs.Fields("Zone_Back_ColorR").Value, rs.Fields("Zone_Back_ColorG").Value, rs.Fields("Zone_Back_ColorB").Value)
                        txt_Font_Size.Text = rs.Fields("Font_Size").Value
                    End If
                End With
            End If
            rs = Nothing


        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงรายละเอียดป้ายแสดงผลที่เลือก ", Err.Number, Err.Description)
            Exit Try
        End Try

    End Sub

    Private Sub Lsv_Zone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lsv_Zone.SelectedIndexChanged

    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        If cmb_Floor.SelectedIndex <= 0 Then Exit Sub
        Call Load_Display_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        Call Load_Floor_Zone_Name(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        Call Load_List_Zone(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        Defaulf_Object()
        lbl_EXC.Location = New Point(365, 33)
    End Sub
    Sub Load_Floor_Zone_Name(ByVal Floor_No As String, ByVal Building_ID As String, ByVal Tower_ID As String)
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            ' Picture_Floor.Controls.Clear()
            sql &= " SELECT * FROM Mas_Floor_Zone_Name "
            sql &= " where F_Zone_Floor_No = " & cmb_Floor.SelectedValue & ""
            If Building_ID.Trim <> "" Then sql &= " and  F_Zone_Building_ID = " & Building_ID & ""
            If Tower_ID.Trim <> "" Then sql &= " and F_Zone_Tower_ID = " & Tower_ID & ""

            sql &= "  order by F_Zone_Id"
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
                            I_Index = Val(I_Index) + 1
                            lbl(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                            With Me.lbl(I_Index)
                                .Size = New Size(CInt(rs.Fields("F_Zone_SizeX").Value), CInt(rs.Fields("F_Zone_SizeY").Value)) 'ขนาด button
                                .Name = "lbl" & rs.Fields("F_Zone_Id").Value  'ชื่อ button
                                .Tag = rs.Fields("F_Zone_Id").Value
                                .Text = rs.Fields("F_Zone_Name").Value
                                .Font = New Font("Microsoft Sans Serif", CInt(rs.Fields("F_Font_Size").Value), FontStyle.Bold) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                '.Cursor = Cursors.Hand
                                '.TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("F_Zone_Back_ColorA").Value, rs.Fields("F_Zone_Back_ColorR").Value, rs.Fields("F_Zone_Back_ColorG").Value, rs.Fields("F_Zone_Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("F_Zone_Font_ColorA").Value, rs.Fields("F_Zone_Font_ColorR").Value, rs.Fields("F_Zone_Font_ColorG").Value, rs.Fields("F_Zone_Font_ColorB").Value)
                                .Location = New Point(rs.Fields("F_Zone_PositionX").Value, rs.Fields("F_Zone_PositionY").Value)
                                .Parent = Me
                                'AddHandler .Click, AddressOf Me.Button_Click
                                'AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                                'AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                                'AddHandler .MouseUp, AddressOf nodebtn_MouseUp
                                'AddHandler .KeyUp, AddressOf iKeyUp
                                Me.Picture_Floor.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                            End With
                            .MoveNext()
                        Loop
                    Else
                    End If
                End With
            End If
            '  lbl_EXC.Location = New Point(597, 44)
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
        End Try

    End Sub

    Private Sub cmb_Building_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Building.SelectedIndexChanged
        If cmb_Building.SelectedIndex <= 0 Then Exit Sub
        Try
            AddCombo(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "Floor_Name", "Floor_No", "Building_ID = " & cmb_Building.SelectedValue & "", "Floor_No", "---กรุณาเลือก ชั้น---")
            cmb_Floor.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmb_Tower_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Tower.SelectedIndexChanged
        If cmb_Tower.SelectedIndex <= 0 Then Exit Sub
        AddCombo(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "Building_Name", "Building_ID", "", "Building_Name", "ทั้งหมด")
        cmb_Building.Enabled = True
    End Sub

    
    Private Sub rdo_Arrow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_Arrow.CheckedChanged
        If rdo_Arrow.Checked = True Then
            lbl_EXC.Visible = False
            Pic_EXC.Visible = True
        Else
            lbl_EXC.Visible = True
            Pic_EXC.Visible = False
        End If
    End Sub

    Private Sub rdo_Display_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_Display.CheckedChanged
        If rdo_Display.Checked = True Then
            lbl_EXC.Visible = True
            Pic_EXC.Visible = False
        Else
            lbl_EXC.Visible = False
            Pic_EXC.Visible = True
        End If
    End Sub
End Class