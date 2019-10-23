Public Class frm_Mas_Floorcontroller
    Dim i As Integer
    Private Sub lsv_Mas_Floor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Floor.MouseClick
        With lsv_Mas_Floor
            lbl_Mas_FloorController_Id.Text = .FocusedItem.SubItems(0).Text
            txt_Mas_FloorController_Name.Text = .FocusedItem.SubItems(1).Text
            txt_Many.Text = .FocusedItem.SubItems(2).Text
            cboTowerId.SelectedValue = .FocusedItem.SubItems(3).Text
            cmb_Building.SelectedValue = .FocusedItem.SubItems(4).Text
            cmb_Floor.SelectedValue = .FocusedItem.SubItems(5).Text
        End With
    End Sub

    Private Sub lsv_Mas_Floor_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Floor.MouseDoubleClick
        Call Delete_MasFloorController()
        Call Defaulf_Object()
    End Sub
    Sub Delete_MasFloorController()
        If lbl_Mas_FloorController_Id.Text = "" Then Exit Sub
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE Mas_Floor_Controller WHERE ID = '" & lbl_Mas_FloorController_Id.Text & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส  : " & lbl_Mas_FloorController_Id.Text & vbCrLf & _
                   "ชื่อ  : " & txt_Mas_FloorController_Name.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call lsv_Mas_Floorcontroller()
                Call Defaulf_Object()
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_MasFloorController", Err.Number, Err.Description)
    End Sub

    Private Function Function_New_Floor_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(ID) from Mas_Floorcontroller order by ID"
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
    Private Function Function_Floor_Controller_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(Floor_Controller_ID) from Mas_Floorcontroller order by Floor_Controller_ID desc "
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
    Sub lsv_Mas_Floorcontroller()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow

        sql = "SELECT * FROM Mas_Floor_Controller order by ID "
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    lsv_Mas_Floor.Items.Clear()
                    lsv_Mas_Floor.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Mas_Floor.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        Dim New_Ent As ListViewItem = lsv_Mas_Floor.Items.Add(rs.Fields("ID").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("Floor_Controller_Name").Value)
                            .SubItems.Add("" & rs.Fields("Floor_Controller_Max_Lot").Value)
                            .SubItems.Add("" & rs.Fields("Tower_ID").Value)
                            .SubItems.Add("" & rs.Fields("Building_ID").Value)
                            .SubItems.Add("" & rs.Fields("Floor_No").Value)
                        End With
                        .MoveNext()
                    Loop
                Else

                    lsv_Mas_Floor.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "lsv_Mas_Floorcontroller", Err.Number, Err.Description)
    End Sub
    Sub Update_Mas_Floorcontroller()
        Dim TrnFlg As Boolean
        If lbl_Mas_FloorController_Id.Text = "" Then Exit Sub
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql &= "Update Mas_Floorcontroller set Floor_Controller_Name ='" & txt_Mas_FloorController_Name.Text & "'"
        sql &= " , Floor_Controller_Max_Lot = " & txt_Many.Text.Trim & ""
        sql &= " , Tower_ID = " & cboTowerId.SelectedValue & ""
        sql &= " , Building_ID = " & cmb_Building.SelectedValue & ""
        sql &= ", Floor_No = " & cmb_Floor.SelectedValue & " "
        sql &= " where ID = " & lbl_Mas_FloorController_Id.Text & ""

        ' If OpenCnn(ConnStrMasTer, Conn) Then
        If OpenCnn(ConnStrMasTer, Conn) Then
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
        '  End If
Err:
        Call mError.ShowError(Me.Name, "แก้ไขข้อมูลอุปกรณ์ควบคุมตามชั้น", Err.Number, Err.Description)
    End Sub
    Private Sub lsv_Mas_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv_Mas_Floor.SelectedIndexChanged

    End Sub

    Private Sub frm_Mas_Floorcontroller_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        AddCombo(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "Floor_Name", "ID", "", "ID", "---เลือก ชั้น---")
        AddCombo(ConnStrMasTer, Me.cboTowerId, "Mas_Tower", "Company_Name", "Company_Id", "", "Company_Name", "ทั้งหมด")
        AddCombo(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "Building_Name", "Building_ID", "", "Building_Name", "ทั้งหมด")

        If User_Level <> "9" Then
            btn_Add_Controller.Visible = False
            btn_Delete.Visible = False
        End If
        Call lsv_Mas_Floorcontroller()
    End Sub

    Private Sub btn_Add_Controller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_Controller.Click
        If btn_Add_Controller.Text = "เพิ่ม" Then
            btn_Edit_Controller.Enabled = False
            btn_Delete.Enabled = False
            lbl_Mas_FloorController_Id.Text = Function_New_Floor_ID()
            txt_Mas_FloorController_Name.Enabled = True
            txt_Many.Enabled = True
            cmb_Floor.Enabled = True
            txt_Many.Focus()
            btn_Add_Controller.ImageList = Me.img_Save
            cmb_Building.Enabled = True
            cboTowerId.Enabled = True
            btn_Add_Controller.Text = "บันทึก"
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
            If txt_Mas_FloorController_Name.Text = "" Then
                MsgBox("กรุณาป้อนข้อมูล ให้ถูกต้อง ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                txt_Mas_FloorController_Name.Focus()
                Exit Sub
            End If
            If txt_Many.Text.Trim = "" Then
                MsgBox("กรุณาป้อนจำนวน อุปกรณ์ ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                txt_Many.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_Many.Text.Trim) = False Then
                MsgBox("กรุณาป้อนจำนวน อุปกรณ์ ให้เป็นตัวเลข ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                txt_Many.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_Many.Text.Trim) = True Then
                If Val(txt_Many.Text.Trim) > 60 Then
                    MsgBox("อุปกรณ์ควบคุม 1 ตัว สามารถควบคุม Sensor ได้ 60 ตัว ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                    txt_Many.Focus()
                    Exit Sub
                End If
            End If
            For i = 1 To txt_Many.Text.Length
                If Mid(txt_Many.Text, i, 1) = "." Then
                    MsgBox("กรุณาป้อนจำนวน อุปกรณ์ ให้เป็นตัวเลขจำนวนเต็ม ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                    txt_Many.Focus()
                    txt_Many.SelectAll()
                    Exit Sub
                End If
            Next
            Call Save_Mas_Controller()
            Call lsv_Mas_Floorcontroller()
            Call Defaulf_Object()
        End If
    End Sub
    Sub Save_Mas_Controller()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim TrnFlg As Boolean

        Dim Permit As Short
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True

            sql &= "INSERT INTO [Mas_Floor_Controller] "
            sql &= " ([ID]"
            sql &= " ,[Tower_ID]"
            sql &= " ,[Building_ID]"
            sql &= " ,[Floor_Controller_ID]"
            sql &= " ,[Floor_Controller_Name]"
            sql &= " ,[Floor_Controller_Max_Lot]"
            sql &= " ,[Floor_Controller_Status]"
            sql &= " ,[Floor_Controller_Parking])"
            sql &= "  Values (" & lbl_Mas_FloorController_Id.Text & ""
            sql &= " , " & cboTowerId.SelectedValue & ""
            sql &= " , " & cmb_Building.SelectedValue & ""
            sql &= " , " & Function_Floor_Controller_ID() & ""
            sql &= " ,'" & txt_Mas_FloorController_Name.Text & "'"
            sql &= " , " & txt_Many.Text.Trim & ""
            sql &= " ," & cmb_Floor.SelectedValue & " )"
            Conn.Execute(sql)

            If (MsgBox("คุณต้องการบันทึกข้อมูล Controller ใช้นี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
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
        Call mError.ShowError(Me.Name, "บันทึก ข้อมูลอุปกรณ์ควบคุมตามชั้น", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If txt_Mas_FloorController_Name.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการ ลบ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
            txt_Mas_FloorController_Name.Enabled = False
            Exit Sub
        End If
        Call Delete_MasFloorController()
        Call Defaulf_Object()
    End Sub
    Sub Defaulf_Object()

        lbl_Mas_FloorController_Id.Text = ""
        txt_Mas_FloorController_Name.Clear()
        txt_Mas_FloorController_Name.Enabled = False
        btn_Add_Controller.Text = "เพิ่ม"
        btn_Add_Controller.Enabled = True
        btn_Add_Controller.ImageList = Me.img_Add
        btn_Edit_Controller.Text = "แก้ไข"
        btn_Edit_Controller.Enabled = True
        btn_Edit_Controller.ImageList = Me.img_Edit
        btn_Delete.Enabled = True
       
        txt_Many.Clear()
        txt_Many.Enabled = False
        cmb_Floor.Enabled = False
        cmb_Floor.SelectedIndex = 0

        cmb_Building.Enabled = False
        cboTowerId.Enabled = False
    End Sub

    Private Sub btn_Edit_Controller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit_Controller.Click

        If btn_Edit_Controller.Text.Trim = "แก้ไข" Then
            If txt_Mas_FloorController_Name.Text = "" Then
                MsgBox("กรุณาเลือกข้อมูลที่ต้องการแก้ไข", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Mas_FloorController_Name.Enabled = False
                'btn_Edit_Controller.Text = "แก้ไข"
                Exit Sub
            End If

           
            btn_Add_Controller.Enabled = False
            btn_Delete.Enabled = False


            txt_Mas_FloorController_Name.Enabled = True
            txt_Many.Enabled = True
            cmb_Floor.Enabled = True
            cmb_Building.Enabled = True
            cboTowerId.Enabled = True
            txt_Many.Focus()

            btn_Edit_Controller.ImageList = Me.img_SaveAdd
            btn_Edit_Controller.Text = "บันทึก"
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
            If txt_Mas_FloorController_Name.Text = "" Then
                MsgBox("กรุณาเลือกข้อมูลที่ต้องการแก้ไข", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Title_Error)
                txt_Mas_FloorController_Name.Enabled = False
                btn_Edit_Controller.Text = "แก้ไข"
                Exit Sub
            End If
            If txt_Many.Text.Trim = "" Then
                MsgBox("กรุณาป้อนจำนวน อุปกรณ์ ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                txt_Many.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_Many.Text.Trim) = False Then
                MsgBox("กรุณาป้อนจำนวน อุปกรณ์ ให้เป็นตัวเลข ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                txt_Many.Focus()
                Exit Sub
            End If
            If IsNumeric(txt_Many.Text.Trim) = True Then
                If Val(txt_Many.Text.Trim) > 60 Then
                    MsgBox("อุปกรณ์ควบคุม 1 ตัว สามารถควบคุม Sensor ได้ 60 ตัว ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                    txt_Many.Focus()
                    Exit Sub
                End If
            End If
            For i = 1 To txt_Many.Text.Length
                If Mid(txt_Many.Text, i, 1) = "." Then
                    MsgBox("กรุณาป้อนจำนวน อุปกรณ์ ให้เป็นตัวเลขจำนวนเต็ม ", MsgBoxStyle.OkOnly = MsgBoxStyle.Information, Title_Error)
                    txt_Many.Focus()
                    txt_Many.SelectAll()
                    Exit Sub
                End If
            Next
            Call Update_Mas_Floorcontroller()
            Call lsv_Mas_Floorcontroller()
            Call Defaulf_Object()
            End If
    End Sub

    Private Sub btn_Cancel_Controller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel_Controller.Click
        Call Defaulf_Object()
    End Sub

    Private Sub txt_Many_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Many.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Mas_FloorController_Name.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Many_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Many.TextChanged

    End Sub

    Private Sub txt_Mas_FloorController_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Mas_FloorController_Name.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Floor.Focus()

        End If
    End Sub

    Private Sub txt_Mas_FloorController_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Mas_FloorController_Name.TextChanged

    End Sub

    Private Sub cmb_Floor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Floor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If btn_Add_Controller.Text.Trim = "บันทึก" Then
                btn_Add_Controller.Focus()
                Exit Sub
            End If
            If btn_Edit_Controller.Text.Trim = "บันทึก" Then
                btn_Edit_Controller.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmb_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floor.SelectedIndexChanged

    End Sub
End Class