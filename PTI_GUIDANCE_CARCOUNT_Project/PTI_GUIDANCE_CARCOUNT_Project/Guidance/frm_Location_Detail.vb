Public Class frm_Location_Detail

    Private Sub Group1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grp_Control.Enter

    End Sub

    Private Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

    Private Sub frm_Location_Detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        If HW_Lot_Id = "Search" Then

        Else
            lbl_Lot_Id.Text = HW_Lot_Id
        End If

        AddCombo(ConnStrMasTer, Me.cmb_Floor_Name, "Mas_Floor", "Floor_Name", "Floor_Id", "", "Floor_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Floorcontroller_Name, "Mas_Floor_Controller", "Floor_Controller_Name", "Floor_Controller_Id", "", "Floor_Controller_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Status_Name, "Mas_HW_Status", "HW_Status_Name", "HW_Status_Id", "", "HW_Status_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cbo_Alam_Name, "Mas_Status_Alarm", "Status_Alarm_Name", "Status_Alarm_Id", "", "Status_Alarm_Id", "---กรุณาเลือก รายการ---")
        ' AddCombo(ConnStrGuidance, Me.cmb_Zone, "HW_Net_1", "HW_Net_1_Name", "HW_Net_1_Id", "", "HW_Net_1_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrGuidance, Me.cmb_Zone, "Floor_Zone", "Zone_Name", "Zone_Id", "", "Zone_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrGuidance, Me.cmb_Mas_Controller, "HW_Net_3", "HW_Net_3_Name", "HW_Net_3_Id", "", "HW_Net_3_Id", "---กรุณาเลือก รายการ---")
        Call select_Floor_Name()
        Call select_Controller_Name()
        Call select_MasStatus_Name()
        Call select_MasAlam_Name()
        Call select_Zone()
        Call select_HW_Net_3_Connect_HW()
        Call Show_Detail_Other_Object()
        Call Lock_Object()
        cmb_Floor_Name.Enabled = False
    End Sub
    Sub Show_Detail_Other_Object()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow

        sql = "SELECT * FROM Mas_Lot where HW_Lot_Id = '" & HW_Lot_Id & "'"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    .MoveFirst()
                    Do While Not .EOF
                        txt_Lot_Name.Text = rs.Fields("HW_Lot_Name").Value
                        lbl_Position_X.Text = rs.Fields("HW_Position_X").Value '5
                        lbl_Position_Y.Text = rs.Fields("HW_Position_Y").Value '6
                        dtp_Date_Change.Value = Format(rs.Fields("HW_Datetime_Update").Value, "dd-MM-yyyy")
                        dtp_Time_Change.Value = Format(rs.Fields("HW_Datetime_Update").Value, "dd-MM-yyyy HH:mm:ss")
                        lbl_HH.Text = rs.Fields("HW_Time_HH").Value
                        lbl_MM.Text = rs.Fields("HW_Time_MM").Value
                        txt_Address_Sensor.Text = rs.Fields("HW_Address").Value
                        txt_Address_Controller.Text = rs.Fields("HW_Address_Map").Value
                        txt_Car_ID.Text = rs.Fields("HW_Car_ID").Value
                        txt_Remark.Text = rs.Fields("HW_Remark").Value
                        .MoveNext()
                    Loop
                Else
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Show_Detail_Other_Object", Err.Number, Err.Description)
    End Sub
    Sub select_Floor_Name()
        On Error GoTo Err_Renamed
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        sql = "SELECT Mas_HW_Floor.Floor_Id " & _
              "FROM Mas_HW_Floor,Mas_Lot where Mas_Lot.HW_Lot_Id = '" & HW_Lot_Id & _
              "' And Mas_Lot.HW_Floor_No = Mas_HW_Floor.Floor_Id"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Floor_Name.SelectedValue = rs.Fields("Floor_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_Floor_Name", Err.Number, Err.Description)
    End Sub
    Sub select_Controller_Name()
        On Error GoTo Err_Renamed
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        sql = "SELECT Mas_Floorcontroller.Floorcontroller_Id " & _
              "FROM Mas_Floorcontroller,Mas_Lot where Mas_Lot.HW_Lot_Id = '" & HW_Lot_Id & _
              "' And Mas_Lot.HW_Floorcontroller_Id = Mas_Floorcontroller.Floorcontroller_Id"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Floorcontroller_Name.SelectedValue = rs.Fields("Floorcontroller_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_Controller_Name", Err.Number, Err.Description)
    End Sub
    Sub select_MasStatus_Name()
        On Error GoTo Err_Renamed
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        sql = "SELECT Mas_HW_Status.HW_Status_Id " & _
              "FROM Mas_HW_Status,Mas_Lot where Mas_Lot.HW_Lot_Id = '" & HW_Lot_Id & _
              "' And Mas_Lot.HW_Status_Id = Mas_HW_Status.HW_Status_Id"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Status_Name.SelectedValue = rs.Fields("HW_Status_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_MasStatus_Name", Err.Number, Err.Description)
    End Sub
    Sub select_MasAlam_Name()
        On Error GoTo Err_Renamed
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        sql = "SELECT Mas_Status_Alarm.Status_Alarm_Id" & _
              " FROM Mas_Status_Alarm,Mas_Lot where Mas_Lot.HW_Lot_Id = '" & HW_Lot_Id & _
              "' And Mas_Status_Alarm.Status_Alarm_Id = Mas_Lot.HW_Status_Alarm_Id "
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cbo_Alam_Name.SelectedValue = rs.Fields("Status_Alarm_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_MasAlam_Name", Err.Number, Err.Description)
    End Sub
   
    Sub select_Zone()
        On Error GoTo Err_Renamed
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        sql = "SELECT Floor_Zone.Zone_Id" & _
              " FROM Floor_Zone,Mas_Lot where Mas_Lot.HW_Lot_Id = '" & HW_Lot_Id & _
              "' And Mas_Lot.HW_Zone_Id = Floor_Zone.Zone_Id"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Zone.SelectedValue = rs.Fields("Zone_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_Zone", Err.Number, Err.Description)
    End Sub
    Sub select_HW_Net_3_Connect_HW()
        On Error GoTo Err_Renamed
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        sql = "SELECT HW_Net_3.HW_Net_3_Id" & _
              " FROM HW_Net_3,Mas_Lot where Mas_Lot.HW_Lot_Id = '" & HW_Lot_Id & _
              "' And Mas_Lot.HW_Net_3 = HW_Net_3.HW_Net_3_Id"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Mas_Controller.SelectedValue = rs.Fields("HW_Net_3_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_HW_Net_3_Connect_HW", Err.Number, Err.Description)
    End Sub
    Sub Lock_Object()
        txt_Lot_Name.Enabled = False
        cmb_Floorcontroller_Name.Enabled = False
        cmb_Floor_Name.Enabled = False
        dtp_Date_Change.Enabled = False
        dtp_Time_Change.Enabled = False
        cmb_Status_Name.Enabled = False
        cbo_Alam_Name.Enabled = False
        cmb_Zone.Enabled = False
        cmb_Mas_Controller.Enabled = False
        cmb_Floor_Name.Enabled = False
        txt_Car_ID.Enabled = False
        txt_Address_Sensor.Enabled = False
        txt_Address_Controller.Enabled = False
        txt_Remark.Enabled = False
    End Sub
    Sub Un_Lock_Object()
        txt_Lot_Name.Enabled = True
        cmb_Floorcontroller_Name.Enabled = True
        dtp_Date_Change.Enabled = True
        dtp_Time_Change.Enabled = True
        cmb_Status_Name.Enabled = True
        cbo_Alam_Name.Enabled = True
        cmb_Zone.Enabled = True
        cmb_Mas_Controller.Enabled = True
        cmb_Floor_Name.Enabled = True
        txt_Car_ID.Enabled = True
        txt_Address_Sensor.Enabled = True
        txt_Address_Controller.Enabled = True
        txt_Remark.Enabled = True
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.ImageList = Me.img_Save
            btn_Edit.Text = "บันทึก"
            cmb_Floor_Name.Enabled = False
            Call Un_Lock_Object()
            txt_Lot_Name.Focus()
        Else
            If txt_Lot_Name.Text = "" Then
                MsgBox("กรุณาป้อนชื่ออุปกรณ์ ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Lot_Name.Focus()
                Exit Sub
            End If
            If cmb_Floor_Name.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือก ชั้นที่ติดตั้งอุปกรณ์", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Floor_Name.Focus()
                Exit Sub
            End If
            If cmb_Floorcontroller_Name.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือก Controller ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Floorcontroller_Name.Focus()
                Exit Sub
            End If
            If cmb_Status_Name.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะรายการ ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Status_Name.Focus()
                Exit Sub
            End If
            If cbo_Alam_Name.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะการจอดรถ ", MsgBoxStyle.Exclamation, Title_Error)
                cbo_Alam_Name.Focus()
                Exit Sub
            End If
            If txt_Address_Sensor.Text.Trim = "" Then
                MsgBox("กรุณาป้อน Address ที่ Set ไว้ที่ตัวเครื่อง  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Address_Sensor.Focus()
                Exit Sub
            End If
            If txt_Address_Controller.Text.Trim = "" Then
                MsgBox("กรุณาป้อน Address ใน Master Controller  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Address_Controller.Focus()
                Exit Sub
            End If
            If txt_Car_ID.Text.Trim = "" Then
                MsgBox("กรุณาป้อน ทะเบียนรถที่สมารถจอดได้  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Car_ID.Focus()
                Exit Sub
            End If
            If cmb_Zone.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกโซนอุปกรณ์ตรวจสอบตามชั้น ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Zone.Focus()
                Exit Sub
            End If
            'If cmb_Zone.SelectedIndex = 0 Then
            '    MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Floorcontroller และ Hardware ", MsgBoxStyle.Exclamation, Title_Error)
            '    cmb_Zone.Focus()
            '    Exit Sub
            'End If
            If cmb_Mas_Controller.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Hardware ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Mas_Controller.Focus()
                Exit Sub
            End If
            Call Update_Mas_Lot()
            Call Lock_Object()
            btn_Edit.Text = "แก้ไข"
            btn_Edit.ImageList = Me.img_Edit
        End If


    End Sub
    Sub Update_Mas_Lot()
        Dim TrnFlg As Boolean
        On Error GoTo err
        Dim DateTime_Change As String = mDB.DBFormatDate(dtp_Date_Change.Value.ToShortDateString & " " & dtp_Time_Change.Value.ToShortTimeString)
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "Update Mas_Lot set HW_Lot_Name='" & txt_Lot_Name.Text & _
                        "', HW_Floor_No = " & cmb_Floor_Name.SelectedValue & _
                        ", HW_Floorcontroller_Id = " & cmb_Floorcontroller_Name.SelectedValue & _
                        ", HW_Datetime_Update = " & DateTime_Change & _
                        ", HW_Status_Id = " & cmb_Status_Name.SelectedValue & _
                        ", HW_Status_Alarm_Id = " & cbo_Alam_Name.SelectedValue & _
                        ", HW_Address = '" & txt_Address_Sensor.Text & _
                        "', HW_Address_Map = '" & txt_Address_Controller.Text & _
                        "', HW_Car_ID ='" & txt_Car_ID.Text & _
                        "', HW_Zone_Id = " & cmb_Zone.SelectedValue & _
                        ", HW_Net_3 = " & cmb_Mas_Controller.SelectedValue & _
                        ", HW_Remark = '" & txt_Remark.Text & _
                        "' where HW_Lot_Id = '" & HW_Lot_Id & "'"
        If OpenCnn(ConnStrGuidance, Conn) Then
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
        Exit Sub

err:
        Call mError.ShowError(Me.Name, "Update_Mas_Lot", Err.Number, Err.Description)
    End Sub

    Private Sub txt_Lot_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Lot_Name.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Floor_Name.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txt_Lot_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Lot_Name.TextChanged

    End Sub

    Private Sub cmb_Floor_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Floor_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Floorcontroller_Name.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Floor_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floor_Name.SelectedIndexChanged

    End Sub

    Private Sub cmb_Floorcontroller_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Floorcontroller_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            dtp_Date_Change.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Floorcontroller_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floorcontroller_Name.SelectedIndexChanged

    End Sub

    Private Sub dtp_Date_Change_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Date_Change.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            dtp_Time_Change.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub dtp_Date_Change_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Date_Change.ValueChanged

    End Sub

    Private Sub dtp_Time_Change_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Time_Change.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Status_Name.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub dtp_Time_Change_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Time_Change.ValueChanged

    End Sub

    Private Sub cmb_Status_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Status_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cbo_Alam_Name.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Status_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Status_Name.SelectedIndexChanged

    End Sub

    Private Sub cbo_Alam_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Alam_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Zone.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cbo_Alam_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Alam_Name.SelectedIndexChanged

    End Sub

    Private Sub cmb_Mas_FloorController_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb_Zone.KeyDown

    End Sub

    Private Sub cmb_Mas_FloorController_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Zone.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Mas_Controller.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Mas_FloorController_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Zone.SelectedIndexChanged

    End Sub

    Private Sub cmb_Mas_Controller_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Mas_Controller.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Car_ID.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Mas_Controller_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Mas_Controller.SelectedIndexChanged

    End Sub

    Private Sub cmb_FloorController_HW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Car_ID.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_FloorController_HW_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_Car_ID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Car_ID.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Address_Sensor.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Car_ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Car_ID.TextChanged

    End Sub

    Private Sub txt_Address_Sensor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Address_Sensor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Address_Controller.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Address_Sensor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Address_Sensor.TextChanged

    End Sub

    Private Sub txt_Address_Controller_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Address_Controller.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Remark.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Address_Controller_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Address_Controller.TextChanged

    End Sub

    Private Sub txt_Remark_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Remark.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Edit.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Remark_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Remark.TextChanged

    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Lock_Object()
        btn_Edit.Text = "แก้ไข"
        btn_Edit.ImageList = Me.img_Edit
    End Sub

    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click

    End Sub
End Class