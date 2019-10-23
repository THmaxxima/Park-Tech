Option Explicit On
Public Class frm_Mas_HW_Status


    Private Sub frm_Mas_HW_Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call mMain.Load_AppConfig()
        Call lsv_Mas_Status_View()
        If User_Level <> "9" Then
            btn_Add_Status.Visible = False
            btn_Delete.Visible = False
        End If
    End Sub
    Private Function Function_New_Status_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(HW_Status_Id) from Mas_HW_Status"
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
    Sub lsv_Mas_Status_View()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        sql = "SELECT * FROM Mas_HW_Status"
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
                        Dim New_Ent As ListViewItem = lsv_Mas_Status.Items.Add(rs.Fields("HW_Status_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("HW_Status_Name").Value)
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
        Call mError.ShowError(Me.Name, "lsv_Mas_Status_View", Err.Number, Err.Description)
    End Sub
    Sub Save_Edit_Mas_Status()
        If lbl_Mas_Status_Id.Text = "" Then Exit Sub
        If btn_Edit_Status.Text = "แก้ไข" Then Exit Sub
        Dim TrnFlg As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "Update Mas_HW_Status set HW_Status_Name='" & txt_Mas_Status_Name.Text & "'where HW_Status_Id = " & lbl_Mas_Status_Id.Text & ""
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                Conn = Nothing
                rs = Nothing
                Exit Sub
            Else
                Conn.RollbackTrans()
                TrnFlg = False
            End If
        End If
        Conn = Nothing
        rs = Nothing
Err:
        Call mError.ShowError(Me.Name, "Save_Edit_Mas_Status", Err.Number, Err.Description)
    End Sub
    Private Sub lsv_Mas_Status_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Status.MouseClick
        With lsv_Mas_Status
            lbl_Mas_Status_Id.Text = .FocusedItem.SubItems(0).Text
            txt_Mas_Status_Name.Text = .FocusedItem.SubItems(1).Text
        End With
    End Sub

    Private Sub lsv_Mas_Status_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Status.MouseDoubleClick
        'Delete_Mas_HW_Status()
    End Sub
    Sub Delete_Mas_HW_Status()
        If lbl_Mas_Status_Id.Text = "" Then Exit Sub
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_HW_Status WHERE HW_Status_Id = '" & lbl_Mas_Status_Id.Text & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส  : " & lbl_Mas_Status_Id.Text & vbCrLf & _
                       "ชื่อ : " & txt_Mas_Status_Name.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call lsv_Mas_Status_View()
                lbl_Mas_Status_Id.Text = ""
                txt_Mas_Status_Name.Clear()
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Mas_HW_Status", Err.Number, Err.Description)
    End Sub
    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        txt_Search.Focus()
        Call default_Object()
        If txt_Search.Text = "" Or txt_Search.Text = "*" Then
            Call lsv_Mas_Status_View()
            Exit Sub
        Else
            On Error GoTo Err_Renamed

            sql = "select * from Mas_HW_Status where HW_Status_Name LIKE'%" & Trim(txt_Search.Text) & "%'order by HW_Status_Id"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        lsv_Mas_Status.Items.Clear()
                        .MoveFirst()
                        Do While Not .EOF
                            Dim New_Ent As ListViewItem = lsv_Mas_Status.Items.Add(rs.Fields("HW_Status_Id").Value)
                            With New_Ent
                                .SubItems.Add("" & rs.Fields("HW_Status_Name").Value)
                            End With
                            .MoveNext()
                        Loop
                    Else
                        lsv_Mas_Status.Items.Clear()

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

    Private Sub btn_Add_Status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_Status.Click


        If btn_Add_Status.Text = "เพิ่ม" Then
            txt_Search.Clear()
            txt_Search.Enabled = False
            btn_Search.Enabled = False
            btn_Edit_Status.Enabled = False
            btn_Delete.Enabled = False
            lbl_Mas_Status_Id.Text = Function_New_Status_ID()
            txt_Mas_Status_Name.Enabled = True
            txt_Mas_Status_Name.Focus()
            btn_Add_Status.ImageList = Me.img_Save
            btn_Add_Status.Text = "บันทึก"
        Else
            If txt_Mas_Status_Name.Text = "" Then
                MsgBox("   กรุณาป้อนข้อมูล ให้ถูกต้อง        ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                txt_Mas_Status_Name.Focus()
                Exit Sub
            End If

            Call Save_Mas_Status()
            Call lsv_Mas_Status_View()
            Call Default_Object()
        End If
    End Sub
    Sub Save_Mas_Status()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean

        Dim Permit As Short
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            sql = " Insert into Mas_HW_Status  Values (" & Trim(lbl_Mas_Status_Id.Text) & ",'" & txt_Mas_Status_Name.Text & "')"
            Conn.Execute(sql)

            If (MsgBox("คุณต้องการบันทึกข้อมูล สิทธิ์ของผู้ใช้นี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                Exit Sub
            Else
                Conn.RollbackTrans()
                TrnFlg = False

            End If
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "Save_Mas_Status", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Call Default_Object()
        txt_Search.Clear()
    End Sub
    Sub Default_Object()
        btn_Add_Status.Text = "เพิ่ม"
        btn_Add_Status.Enabled = True
        btn_Add_Status.ImageList = Me.img_Add

        btn_Edit_Status.Text = "แก้ไข"
        btn_Edit_Status.Enabled = True
        btn_Edit_Status.ImageList = Me.img_Edit

        lbl_Mas_Status_Id.Text = ""
        txt_Mas_Status_Name.Clear()
        txt_Mas_Status_Name.Enabled = False
        btn_Delete.Enabled = True

        btn_Search.Enabled = True
        txt_Search.Clear()
        txt_Search.Enabled = True


    End Sub

    Private Sub txt_Mas_Status_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Mas_Status_Name.KeyPress
        If btn_Add_Status.Text = "บันทึก" Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                btn_Add_Status.Focus()
                Exit Sub
            End If
        End If

        If btn_Edit_Status.Text = "บันทึก" Then
            If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
                btn_Edit_Status.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Search.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Search.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub btn_Edit_Status_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit_Status.Click
        If txt_Mas_Status_Name.Text = "" Then
            MsgBox("กรุณาเลือก ข้อมูลที่ต้องการแก้ไข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            txt_Mas_Status_Name.Enabled = False
            btn_Edit_Status.Text = "แก้ไข"
            Exit Sub
        End If

        If btn_Edit_Status.Text = "แก้ไข" Then
            btn_Add_Status.Enabled = False
            btn_Delete.Enabled = False
            btn_Search.Enabled = False
            txt_Search.Clear()
            txt_Search.Enabled = False
            txt_Mas_Status_Name.Enabled = True
            txt_Mas_Status_Name.Focus()
            btn_Edit_Status.ImageList = Me.img_SaveAdd
            btn_Edit_Status.Text = "บันทึก"
        Else
            If txt_Mas_Status_Name.Text = "" Then
                MsgBox("กรุณาป้อนข้อมูลให้ถูกต้อง    ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Mas_Status_Name.Focus()
                Exit Sub
            End If
            Call Save_Edit_Mas_Status()
            Call lsv_Mas_Status_View()
            Call Default_Object()
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If lbl_Mas_Status_Id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการ ลบ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "")
            Exit Sub
        End If
        Call Delete_Mas_HW_Status()
        Call Default_Object()
    End Sub

    Private Sub lsv_Mas_Status_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsv_Mas_Status.SelectedIndexChanged

    End Sub
End Class