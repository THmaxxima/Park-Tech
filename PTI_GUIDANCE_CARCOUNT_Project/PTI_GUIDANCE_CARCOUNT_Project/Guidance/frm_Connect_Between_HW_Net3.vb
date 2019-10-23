Public Class frm_Connect_Between_HW_Net3

    Private Sub frm_Connect_Between_HW_Net3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        If User_Level <> "9" Then
            btn_Delete.Visible = False
            btn_Add_Net3.Visible = False
        End If
        lsv_Select_Net3_View()
    End Sub
    Private Function Function_New_Net_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(HW_Net_3_Id) from HW_Net_3"
            If OpenCnn(ConnStrGuidance, Conn) Then
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
    Sub lsv_Select_Net3_View()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow

        sql = "SELECT * FROM HW_Net_3 "
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    lsv_Net3.Items.Clear()
                    lsv_Net3.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Net3.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        Dim New_Ent As ListViewItem = lsv_Net3.Items.Add(rs.Fields("HW_Net_3_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("HW_Net_3_Name").Value)
                        End With
                        .MoveNext()
                    Loop
                Else

                    lsv_Net3.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "lsv_Select_Net3_View", Err.Number, Err.Description)
    End Sub
    Sub Edit_HW_Net_3()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim TrnFlg As Boolean
        Dim sql As String = ""
        sql = "Update HW_Net_3 set HW_Net_3_Name = '" & txt_Net3_Name.Text & "' where HW_Net_3_Id = " & lbl_Net3_Id.Text & " "
        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
            Else
                Conn.RollbackTrans()
                TrnFlg = False
            End If
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "Edit_HW_Net_3", Err.Number, Err.Description)
    End Sub
    Sub Save_HW_Net_3()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean
        sql = " Insert into HW_Net_3  Values (" & Trim(lbl_Net3_Id.Text) & ",'" & txt_Net3_Name.Text & "')"
        Dim Permit As Short
        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการบันทึกข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then

                Conn.CommitTrans()
                TrnFlg = False
                Call lsv_Select_Net3_View()
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
        Call mError.ShowError(Me.Name, "Save_HW_Net_3", Err.Number, Err.Description)
    End Sub
    Sub Delete_HW_Net_3()
        If lbl_Net3_Id.Text = "" Then Exit Sub
        If lbl_Net3_Id.Text = "0" Or lbl_Net3_Id.Text = "1" Then
            MsgBox("ไม่สามารถลบรหัส : " & lbl_Net3_Id.Text & " ได้ " & vbCrLf & _
                   " เนื่องจากเป็นค่าเริ่มต้นของระบบ", MsgBoxStyle.Critical, Title_Error)
            Exit Sub
        End If
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From HW_Net_3 WHERE HW_Net_3_Id = " & lbl_Net3_Id.Text & " "
        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส : " & lbl_Net3_Id.Text & vbCrLf & _
                       "ชื่อ : " & txt_Net3_Name.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_HW_Net_3", Err.Number, Err.Description)
    End Sub
    Sub Defaulf_Object()
        btn_Add_Net3.ImageList = Me.img_Add
        btn_Edit_Net3.ImageList = Me.img_Edit
        btn_Edit_Net3.Text = "แก้ไข"
        btn_Add_Net3.Text = "เพิ่ม"
        btn_Edit_Net3.Enabled = True
        btn_Add_Net3.Enabled = True
        btn_Delete.Enabled = True
        lbl_Net3_Id.Text = ""
        btn_Edit_Net3.Enabled = False
        btn_Edit_Net3.Enabled = True
        txt_Net3_Name.Clear()
        txt_Net3_Name.Enabled = False
    End Sub

    Private Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If txt_Net3_Name.Text.Trim = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Title_Error)
            txt_Net3_Name.Focus()
            Exit Sub
        End If
        If lbl_Net3_Id.Text = "0" Or lbl_Net3_Id.Text = "1" Then
            MsgBox("ไม่สามารถลบรหัส : " & lbl_Net3_Id.Text & " ได้ " & vbCrLf & _
                   " เนื่องจากเป็นค่าเริ่มต้นของระบบ", MsgBoxStyle.Critical, Title_Error)
            Exit Sub
        End If
        Call Delete_HW_Net_3()
        Call lsv_Select_Net3_View()
        Call Defaulf_Object()
    End Sub

    Private Sub lsv_Net3_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Net3.MouseClick
        With lsv_Net3
            lbl_Net3_Id.Text = .FocusedItem.SubItems(0).Text
            txt_Net3_Name.Text = .FocusedItem.SubItems(1).Text
        End With
    End Sub

    Private Sub lsv_Net3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Net3.MouseDoubleClick
        Call Delete_HW_Net_3()
        Call lsv_Select_Net3_View()
        Call Defaulf_Object()
    End Sub

    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        txt_Search.Focus()
        If txt_Search.Text = "" Or txt_Search.Text = "*" Then
            Call lsv_Select_Net3_View()
            Exit Sub
        Else
            On Error GoTo Err_Renamed

            sql = "select * from HW_Net_3 where HW_Net_3_Name LIKE'%" & Trim(txt_Search.Text) & "%'order by HW_Net_3_Id"
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        lsv_Net3.Items.Clear()
                        .MoveFirst()
                        Do While Not .EOF
                            Dim New_Ent As ListViewItem = lsv_Net3.Items.Add(rs.Fields("HW_Net_3_Id").Value)
                            With New_Ent
                                .SubItems.Add("" & rs.Fields("HW_Net_3_Name").Value)
                            End With
                            .MoveNext()
                        Loop
                    Else
                        lsv_Net3.Items.Clear()
                    End If
                End With
            End If
            rs = Nothing
            Exit Sub
Err_Renamed:
            Call mError.ShowError(Me.Name, "btn_Search_Click", Err.Number, Err.Description)
        End If
    End Sub

    Private Sub btn_Add_Net3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_Net3.Click
        If btn_Add_Net3.Text.Trim = "เพิ่ม" Then

            btn_Edit_Net3.Enabled = False
            btn_Delete.Enabled = False
            btn_Search.Enabled = False
            txt_Search.Clear()
            txt_Search.Enabled = False

            lbl_Net3_Id.Text = Function_New_Net_ID()
            txt_Net3_Name.Enabled = True
            txt_Net3_Name.Clear()
            txt_Net3_Name.Focus()

            btn_Add_Net3.ImageList = Me.img_Save
            btn_Add_Net3.Text = "บันทึก"
        Else
            If txt_Net3_Name.Text.Trim = "" Then
                MsgBox("กรุณาป้อนข้อมูล  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Title_Error)
                txt_Net3_Name.Focus()
                Exit Sub
            End If

            Call Save_HW_Net_3()
            Call lsv_Select_Net3_View()
            Call Defaulf_Object()

        End If
    End Sub

    Private Sub btn_Edit_Net3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit_Net3.Click
        If txt_Net3_Name.Text.Trim = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการแก้ไข  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Title_Error)
            Exit Sub
        End If
        If btn_Edit_Net3.Text.Trim = "แก้ไข" Then

            txt_Net3_Name.Focus()
            btn_Add_Net3.Enabled = False
            btn_Delete.Enabled = False
            btn_Edit_Net3.Enabled = True
            txt_Net3_Name.Enabled = True
            btn_Edit_Net3.ImageList = Me.img_SaveAdd
            btn_Edit_Net3.Text = "บันทึก"
        Else
            If txt_Net3_Name.Text.Trim = "" Then
                MsgBox("กรุณาเลือกข้อมูลที่ต้องการแก้ไข  ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Title_Error)
                txt_Net3_Name.Focus()
                Exit Sub
            End If
            Call Edit_HW_Net_3()
            Call lsv_Select_Net3_View()
            Call Defaulf_Object()
        End If
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Call Defaulf_Object()
    End Sub

    Private Sub txt_Search_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Search.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Search.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Search.TextChanged

    End Sub

    Private Sub txt_Net3_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Net3_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Add_Net3.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Net3_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Net3_Name.TextChanged

    End Sub
End Class