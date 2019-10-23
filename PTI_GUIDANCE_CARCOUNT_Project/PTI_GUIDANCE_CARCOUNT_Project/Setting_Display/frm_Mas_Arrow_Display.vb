Option Explicit On
'Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO.Stream
Imports VB = Microsoft.VisualBasic
Imports System.Threading
Public Class frm_Mas_Arrow_Display
    Dim SqlDt As New DataTable
    Dim SqlDa As SqlDataAdapter
    Dim NewFloor_ID As String
    Dim OpenFileDialog1 As New Object
    Dim Pic_Name As String
    Dim Tmp_Save_Pict As String
    Private Sub frm_Mas_Arrow_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig() 'connect Database Config
       
        Call AddListView()
        ''If User_Level <> "9" Then
        ''    btn_Add.Visible = False
        ''    btn_Delete.Visible = False
        ''End If

    End Sub
    Private Function Function_New_Floor_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""

        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]

        Try
            Dim sql As String = "select TOP 1 ID from Mas_Arrow_Display order by ID DESC "
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
                        F_ID = Val(F_ID) + 1
                    End If
                End With
            End If
        Catch ex As Exception
            F_ID = "1"
        End Try
        Return F_ID
    End Function
    Sub Save_Mas_HW_Floor()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean

        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]


        Dim Permit As Short
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            sql = "" & " Insert into Mas_Arrow_Display "
            sql &= "(ID "
            sql &= ",Description"
            sql &= " ) Values ("
            sql &= "" & lbl_Floor_Id.Text & ""
            sql &= ",'" & txt_Floor_Name.Text & "')"

            Conn.Execute(sql)
            If MsgBox("คุณต้องการบันทึกข้อมูลนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Arrow_Display", "ID", "Arrow", lbl_Floor_Id.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
                Tmp_Save_Pict = ""
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If

        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        If TrnFlg = True Then Conn.RollbackTrans()

        Call mError.ShowError(Me.Name, "Save_Mas_Floor", Err.Number, Err.Description)
    End Sub
    Sub AddListView()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow

        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]

        sql = "SELECT * FROM Mas_Arrow_Display "
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
                        If .RecordCount >= 8 Then
                            btn_Add.Visible = False
                        Else
                            btn_Add.Visible = True
                        End If
                        ' tl = rs.RecordCount
                        Dim New_Ent As ListViewItem = lsv_Mas_HW_Floor.Items.Add(rs.Fields("ID").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("Description").Value)
                            '.SubItems.Add("" & rs.Fields("Tower_Id").Value)
                            '.SubItems.Add("" & rs.Fields("Building_ID").Value)
                            '.SubItems.Add("" & rs.Fields("Floor_No").Value)
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


    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click

        If btn_Add.Text = "เพิ่ม" Then
            lbl_Floor_Id.Text = Function_New_Floor_ID()
            txt_Floor_Name.Enabled = True
            txt_Floor_Name.Focus()
            btn_Edit.Enabled = False
            btn_Add.ImageList = Me.img_SaveAdd
            Picture_Floor.Image = Picture_Floor.ErrorImage
            btn_Add_Picture.Enabled = True
            btn_Delete_Picture.Enabled = True

            btn_Add.Text = "บันทึก"

        Else
           
            If txt_Floor_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อชั้นจอดรถ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Floor_Name.Focus()
                Exit Sub
            End If

            Call Save_Mas_HW_Floor()
            Call AddListView()
            txt_Floor_Name.Enabled = False
            btn_Edit.Enabled = True
            txt_Floor_Name.Clear()
            Picture_Floor.Controls.Clear()
            btn_Add_Picture.Enabled = False
            btn_Delete_Picture.Enabled = False
            btn_Add.Text = "เพิ่ม"
            btn_Add.ImageList = Me.img_Add
        End If

    End Sub
    Private Sub lsv_Mas_HW_Floor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_HW_Floor.MouseClick

        With lsv_Mas_HW_Floor
            lbl_Floor_Id.Text = .FocusedItem.SubItems(0).Text
            txt_Floor_Name.Text = .FocusedItem.SubItems(1).Text
        End With

        Me.Picture_Floor.Controls.Clear()
        Call Me.Show_Picture(lsv_Mas_HW_Floor.FocusedItem.Text)

    End Sub
    Sub Select_Picture_Floor()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]
        On Error GoTo Err_Renamed
        sql = "select Arrow from Mas_Arrow_Display where ID =" & Trim(lsv_Mas_HW_Floor.FocusedItem.SubItems(0).Text) & ""
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
                        Picture_Floor.Image = rs.Fields("Arrow")
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

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.ImageList = Me.img_Edit
            btn_Add.Enabled = False
            btn_Delete.Enabled = False

            btn_Add_Picture.Enabled = True
            txt_Floor_Name.Enabled = True
            btn_Delete_Picture.Enabled = True
            txt_Floor_Name.Focus()
            btn_Edit.Text = "บันทึก"
            btn_Edit.ImageList = Me.img_Save

        Else

           
            If txt_Floor_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่อชั้นจอดรถ ให้ถูกต้อง", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Floor_Name.Focus()
                Exit Sub
            End If

            Call Save_Edit_Floor_Name()

            Call AddListView()
            txt_Floor_Name.Clear()
            txt_Floor_Name.Enabled = False
            btn_Add.Enabled = True
            btn_Delete.Enabled = True
            btn_Add_Picture.Enabled = False
            btn_Delete_Picture.Enabled = False
            btn_Edit.Text = "แก้ไข"
            btn_Edit.ImageList = Me.img_Edit
        End If

    End Sub

    Sub Save_Edit_Floor_Name()
        On Error GoTo Err
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]

        sql = "Update Mas_Arrow_Display set Arrow ='" & txt_Floor_Name.Text & "'where ID = " & lbl_Floor_Id.Text & ""

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
            If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Arrow_Display", "ID", "Arrow", lbl_Floor_Id.Text, Tmp_Save_Pict) 'Tmp_Save_Pict
            Tmp_Save_Pict = ""

        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Save_Edit_Floor_Name", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Call default_Object()
    End Sub
    Sub default_Object()
        btn_Edit.Text = "แก้ไข"
        btn_Add.Text = "เพิ่ม"
        lbl_Floor_Id.Text = ""
        txt_Floor_Name.Clear()
        txt_Floor_Name.Enabled = False

        btn_Edit.Enabled = True
        btn_Add.Enabled = True
        btn_Delete.Enabled = True
        btn_Edit.ImageList = Me.img_Edit
        btn_Add.ImageList = Me.img_Add
        btn_Add_Picture.Enabled = False
        btn_Delete_Picture.Enabled = False
       
    End Sub


    Private Sub txt_Floor_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Floor_Name.KeyPress
        If btn_Add.Text = "บันทึก" Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                btn_Add.Focus()
                Exit Sub
            End If
        End If

        If btn_Edit.Text = "บันทึก" Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                btn_Edit.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_Floor_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Floor_Name.TextChanged

    End Sub

    Private Sub btn_Add_Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_Picture.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""

        With dlg
            .Title = "เลือกรูปภาพ"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg;*.JPEG"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict = .FileName : Picture_Floor.Visible = True
            Picture_Floor.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)
        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "btn_Add_Picture_Click", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Delete_Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete_Picture.Click
        Picture_Floor.Image = Picture_Floor.ErrorImage
        Tmp_Save_Pict = "Null"

        Tmp_Save_Pict = ""
    End Sub
    Sub Edit_Picture()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = "", TrnFlg As Boolean
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            Conn.CommitTrans()
            TrnFlg = False
        Else
            Conn.RollbackTrans()
            Exit Sub
        End If
        'End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Edit_Picture", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()
    End Sub
    Sub Delete_Picture()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = "", TrnFlg As Boolean
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            Conn.Execute(sql)
            Conn.CommitTrans()
            BitSendData = True
            TrnFlg = False
        Else
            Conn.RollbackTrans()
            Exit Sub
        End If
        'End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Picture", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()
    End Sub
    Function Show_Picture(ByVal ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Picture_Floor.Controls.Clear()
        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]

        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select * from Mas_Arrow_Display WHERE ID = " & lsv_Mas_HW_Floor.FocusedItem.SubItems(0).Text & ""
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    If Not VB.IsDBNull(.Fields("Arrow").Value) Then
                        Dim RetByte() As Byte = CType(.Fields("Arrow").Value, Byte())
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

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        On Error GoTo Err
        '      Select [ID]
        '    ,[Arrow]
        '    ,[Description]
        'FROM [Mas_Arrow_Display]

        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_Arrow_Display WHERE ID = '" & lbl_Floor_Id.Text & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส : " & lbl_Floor_Id.Text & vbCrLf & _
                        "ชั้น : " & txt_Floor_Name.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call AddListView()
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Floor", Err.Number, Err.Description)
    End Sub

    Private Sub cboTowerId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lsv_Mas_HW_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv_Mas_HW_Floor.SelectedIndexChanged

    End Sub
End Class