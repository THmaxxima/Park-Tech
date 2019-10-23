Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_Mas_Lot
    REM These will be our switches
    Dim Go As Boolean
    Dim LeftSet As Boolean
    Dim TopSet As Boolean

    REM These will hold the mouse position
    Dim HoldLeft As Integer
    Dim HoldTop As Integer

    REM These will hold the offset of the mouse in the element
    Dim OffLeft As Integer
    Dim OffTop As Integer
    Dim sql_MasLot As String = ""
    Dim Date_Start As String = ""
    Dim Date_Stop As String = ""
    Dim Time_start As String = "00:00:00"
    Dim Time_Stop As String = "59:59:59"
    Dim Lot_Name As String = ""
    Dim Floor_Id As String = ""
    Dim Floorcontroller_Id As String = ""
    Dim Status_Id As String = ""
    Dim Status_Alarm_Id As String = ""
    Dim _Tower_ID As String = ""
    Dim Net1 As String = ""
    Dim Net2 As String = ""
    Dim Net3 As String = ""
    Private Function Function_New_Lot_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select TOP 1 (HW_Lot_Id) from Mas_Lot ORDER BY HW_Lot_Id DESC"
            'Dim sql As String = "select TOP 1 Floor_Id from Mas_HW_Floor ORDER BY Floor_Id"
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        F_ID = .Fields(0).Value.ToString
                        F_ID = Format(F_ID + 1, "0000")
                    Else
                        F_ID = "0001"
                    End If
                End With
            End If
        Catch ex As Exception
            F_ID = "0001"
        End Try
        Return F_ID
    End Function

    Private Sub frm_Mas_Lot_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call Lock_Object()
    End Sub
    Private Sub frm_Mas_Lot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' AddCombo(ConnStrGuidance, Me.Combo Name, "Table Name", "DisplayMember", "ValueMember", "เงื่อนไข", "เรียงลำดับ", "---ค่าเริ่มต้นในการแสดง กรุณาเลือก รายการ---")
        Call mMain.Load_AppConfig()
        Call Show_Mas_Lot()
        Call Lock_Object()
        If Floor_Name <> "" Then
            btn_Delete.Enabled = False
        End If
        AddCombo(ConnStrMasTer, Me.cboTowerId, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")
        AddCombo(ConnStrMasTer, Me.cmb_Floor_Name, "Mas_Floor", "Floor_Name", "Floor_Id", "", "Floor_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Floorcontroller_Name, "Mas_Floor_Controller", "Floor_Controller_Name", "ID", "", "ID", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Status_Name, "Mas_HW_Status", "HW_Status_Name", "HW_Status_Id", "", "HW_Status_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cbo_Alam_Name, "Mas_Status_Alarm", "Status_Alarm_Name", "Status_Alarm_Id", "", "Status_Alarm_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Zone, "Mas_Floor_Zone", "Zone_Name", "Zone_Id", "", "Zone_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Mas_Controller, "Mas_Status_Sensor", "Status_Name", "ID", "", "ID", "---กรุณาเลือก รายการ---")

        REM Control for Searh Data
        AddCombo(ConnStrMasTer, Me.cmb_Search_Floor, "Mas_Floor", "Floor_Name", "Floor_Id", "", "Floor_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Search_Controller, "Mas_Floor_Controller", "Floor_Controller_Name", "ID", "", "ID", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Search_Status, "Mas_HW_Status", "HW_Status_Name", "HW_Status_Id", "", "HW_Status_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Search_Alam, "Mas_Status_Alarm", "Status_Alarm_Name", "Status_Alarm_Id", "", "Status_Alarm_Id", "---กรุณาเลือก รายการ---")
        'AddCombo(ConnStrGuidance, Me.cmb_Search_Mas_FloorController, "HW_Net_1", "HW_Net_1_Name", "HW_Net_1_Id", "", "HW_Net_1_Id", "---กรุณาเลือก รายการ---")
        'AddCombo(ConnStrGuidance, Me.cmb_Search_FloorController_HW, "HW_Net_2", "HW_Net_2_Name", "HW_Net_2_Id", "", "HW_Net_2_Id", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cmb_Search_Sensor, "Mas_Status_Sensor", "Status_Name", "ID", "", "ID", "---กรุณาเลือก รายการ---")
        AddCombo(ConnStrMasTer, Me.cboTowerId2, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")

        cmb_Zone.SelectedIndex = 0

        If User_Level <> "9" Then
            btn_Add.Visible = False
            btn_Delete.Visible = False
        End If

    End Sub
    Sub Load_Mas_HW_Floor()
        On Error GoTo Err
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim Conn As New ADODB.Connection
        sql = " Select * From Mas_Floor ORDER BY Floor_Id"

        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    cmb_Floor_Name.Items.Clear()
                    cmb_Floor_Name.Items.Clear()
                    cmb_Floor_Name.Items.Add("ALL")
                    .MoveFirst()
                    Do While Not .EOF
                        cmb_Floor_Name.Items.Add("" & .Fields("Floor_Id").Value & ":" & .Fields("Floor_Name").Value)
                        'cmb_Floor_Name.Items.Add("" & .Fields("Floor_Id").Value & ":" & .Fields("Floor_Name").Value)
                        .MoveNext()
                    Loop
                    cmb_Floor_Name.SelectedIndex = 0
                    cmb_Floor_Name.SelectedIndex = 0
                Else
                    cmb_Floor_Name.Items.Clear()
                    cmb_Floor_Name.Items.Clear()
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Load_Mas_HW_Floor", Err.Number, Err.Description)
    End Sub
    Sub Load_Mas_Floorcontroller()
        On Error GoTo Err
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim Conn As New ADODB.Connection
        sql = " Select * From Mas_Floor_Controller ORDER BY Floor_Controller_Id"

        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    cmb_Floorcontroller_Name.Items.Clear()
                    cmb_Floorcontroller_Name.Items.Clear()
                    cmb_Floorcontroller_Name.Items.Add("ALL")
                    .MoveFirst()
                    Do While Not .EOF
                        cmb_Floorcontroller_Name.Items.Add("" & .Fields("Floorcontroller_Id").Value & ":" & .Fields("Floorcontroller_Name").Value)
                        'cmb_Floor_Name.Items.Add("" & .Fields("Floor_Id").Value & ":" & .Fields("Floor_Name").Value)
                        .MoveNext()
                    Loop
                    cmb_Floorcontroller_Name.SelectedIndex = 0
                    cmb_Floorcontroller_Name.SelectedIndex = 0
                Else
                    cmb_Floorcontroller_Name.Items.Clear()
                    cmb_Floorcontroller_Name.Items.Clear()
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Load_Mas_Floorcontroller", Err.Number, Err.Description)
    End Sub
    Sub Load_Mas_HW_Status()
        On Error GoTo Err
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim Conn As New ADODB.Connection
        sql = " Select * From Mas_HW_Status ORDER BY HW_Status_Id"

        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    cmb_Status_Name.Items.Clear()
                    cmb_Status_Name.Items.Clear()
                    cmb_Status_Name.Items.Add("ALL")
                    .MoveFirst()
                    Do While Not .EOF
                        cmb_Status_Name.Items.Add("" & .Fields("HW_Status_Id").Value & ":" & .Fields("HW_Status_Name").Value)
                        'cmb_Floor_Name.Items.Add("" & .Fields("Floor_Id").Value & ":" & .Fields("Floor_Name").Value)
                        .MoveNext()
                    Loop
                    cmb_Status_Name.SelectedIndex = 0
                    cmb_Status_Name.SelectedIndex = 0
                Else
                    cmb_Status_Name.Items.Clear()
                    cmb_Status_Name.Items.Clear()
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Load_Mas_HW_Status", Err.Number, Err.Description)
    End Sub
    Sub Load_Mas_Status_Alarm()
        On Error GoTo Err
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim Conn As New ADODB.Connection
        sql = " Select * From Mas_Status_Alarm ORDER BY Status_Alarm_Id"

        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    cbo_Alam_Name.Items.Clear()
                    cbo_Alam_Name.Items.Clear()
                    cbo_Alam_Name.Items.Add("ALL")
                    .MoveFirst()
                    Do While Not .EOF
                        cbo_Alam_Name.Items.Add("" & .Fields("Status_Alarm_Id").Value & ":" & .Fields("Status_Alarm_Name").Value)
                        'cmb_Floor_Name.Items.Add("" & .Fields("Floor_Id").Value & ":" & .Fields("Floor_Name").Value)
                        .MoveNext()
                    Loop
                    cbo_Alam_Name.SelectedIndex = 0
                    cbo_Alam_Name.SelectedIndex = 0
                Else
                    cbo_Alam_Name.Items.Clear()
                    cbo_Alam_Name.Items.Clear()
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Load_Mas_Status_Alarm", Err.Number, Err.Description)
    End Sub

    Sub Load_Defaulf()
        txt_Position_X.Text = "0"
        txt_Position_Y.Text = "0"
        txt_House.Text = "00"
        txt_Minute.Text = "00"
        txt_Remark.Clear()
        lbl_Lot_Id.Text = ""

        btn_Add.Text = "เพิ่ม"
        btn_Add.ImageList = Me.img_Add

        btn_Edit.Text = "แก้ไข"
        btn_Edit.ImageList = Me.img_Edit

        txt_Car_ID.Text = "00"
        txt_Lot_Name.Clear()
        txt_Address_Controller.Text = "00"
        cmb_Floor_Name.SelectedIndex = 0
        cmb_Floorcontroller_Name.SelectedIndex = 0
        cmb_Status_Name.SelectedIndex = 0
        cbo_Alam_Name.SelectedIndex = 0
        'cmb_FloorController_HW.SelectedIndex = 0
        '   cmb_Mas_Controller.SelectedIndex = 0
        'grp_Control.Enabled = False
        'grp_Status.Enabled = False
        btn_Delete.Enabled = True
        btn_Add.Enabled = True
        btn_Edit.Enabled = True
        'for Search
        grb_Search.Visible = False
        btn_Search.Enabled = True

        chk_Time.Checked = False
        Call Lock_Object()
        If Floor_Name <> "" Then
            btn_Delete.Enabled = False
        End If
    End Sub
    Sub Lock_Object()
        txt_Lot_Name.Enabled = False
        cmb_Floor_Name.Enabled = False
        cmb_Floorcontroller_Name.Enabled = False
        txt_Position_X.Enabled = False
        txt_Position_Y.Enabled = False
        dtp_Date_Change.Enabled = False
        dtp_Time_Change.Enabled = False
        txt_House.Enabled = False
        txt_Minute.Enabled = False
        cmb_Status_Name.Enabled = False
        cbo_Alam_Name.Enabled = False
        txt_Address_Sensor.Enabled = False
        txt_Address_Controller.Enabled = False
        txt_Car_ID.Enabled = False
        cmb_Zone.Enabled = False
        cmb_Zone.Enabled = False
        cmb_Mas_Controller.Enabled = False
        txt_Remark.Enabled = False
        'cmb_Search_Floor.SelectedIndex = 0
        'cmb_Search_Controller.SelectedIndex = 0
        'cmb_Zone.SelectedIndex = 0
        'cmb_Search_Status.SelectedIndex = 0
        'cmb_Search_Alam.SelectedIndex = 0
        'cmb_Search_Mas_FloorController.SelectedIndex = 0
        'cmb_Search_FloorController_HW.SelectedIndex = 0
        ' cmb_Search_Sensor.SelectedIndex = 0
    End Sub
    Sub Un_Lock_Object()
        txt_Lot_Name.Enabled = True
        cmb_Floor_Name.Enabled = True
        cmb_Floorcontroller_Name.Enabled = True
        txt_Position_X.Enabled = True
        txt_Position_Y.Enabled = True
        dtp_Date_Change.Enabled = True
        dtp_Time_Change.Enabled = True
        txt_House.Enabled = True
        txt_Minute.Enabled = True
        cmb_Status_Name.Enabled = True
        cbo_Alam_Name.Enabled = True
        txt_Address_Sensor.Enabled = True
        txt_Address_Controller.Enabled = True
        txt_Car_ID.Enabled = True
        'cmb_Mas_FloorController.Enabled = True
        cmb_Zone.Enabled = True
        cmb_Mas_Controller.Enabled = True
        txt_Remark.Enabled = True
        cmb_Search_Floor.SelectedIndex = 0
        cmb_Search_Controller.SelectedIndex = 0
        cmb_Search_Status.SelectedIndex = 0
        cmb_Search_Alam.SelectedIndex = 0
        cboTowerId.Enabled = True
        cboTowerId.SelectedIndex = 0
        'cmb_Search_Mas_FloorController.SelectedIndex = 0
        'cmb_Search_FloorController_HW.SelectedIndex = 0
        cmb_Search_Sensor.SelectedIndex = 0
    End Sub
   

    Sub Delete_Mas_Lot()
        On Error GoTo Err
        'lsv_Mas_Lot.FocusedItem.SubItems(0).Text 
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_Lot WHERE HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"
        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูลอุปกรณ์ รหัส : " & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & vbCrLf & _
                      "ชื่อ : " & Dgv_Lot.CurrentRow.Cells(1).Value.ToString & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call Show_Mas_Lot()
                Call Load_Defaulf()
            Else
                Conn.RollbackTrans()
                Call Load_Defaulf()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Mas_Lot", Err.Number, Err.Description)
    End Sub
    Sub Save_Mas_Lot()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim TrnFlg As Boolean
        Dim DateTime_Change As String = Format(dtp_Date_Change.Value, "yyyy-MM-dd") & " " & Format(dtp_Time_Change.Value, "HH:mm:ss")

        Dim Permit As Short
        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            sql &= " INSERT INTO Mas_Lot "
            sql &= "([HW_Lot_Id]"
            sql &= ",[HW_Lot_Name]"
            sql &= ",[HW_Lot_Tower_ID]"
            sql &= ",[HW_Floor_No]"
            sql &= ",[HW_Floorcontroller_Id]"
            sql &= ",[HW_Position_X]"
            sql &= ",[HW_Position_Y]"
            sql &= ",[HW_Datetime_Update]"
            sql &= ",[HW_Time_HH]"
            sql &= ",[HW_Time_MM]"
            sql &= ",[HW_Status_Id]"
            sql &= ",[HW_Status_Alarm_Id]"
            sql &= ",[HW_Address]"
            sql &= ",[HW_Address_Map]"
            sql &= ",[HW_Car_ID]"
            sql &= ",[HW_Zone_Id]"
            sql &= ",[HW_On_Line]"
            sql &= ",[HW_Net_01]"
            sql &= ",[HW_Net_02]"
            sql &= ",[HW_Net_03]"
            sql &= ",[HW_Net_04]"
            sql &= ",[HW_Net_05]"
            sql &= ",[HW_Remark])"
            sql &= "  VALUES ('" & lbl_Lot_Id.Text & "'" 'HW_Lot_Id
            sql &= ",'" & txt_Lot_Name.Text & "'" 'HW_Lot_Name
            sql &= "," & cboTowerId.SelectedValue & "" 'HW_Lot_Tower_ID
            sql &= "," & cmb_Floor_Name.SelectedValue & "" 'HW_Floor_No
            sql &= "," & cmb_Floorcontroller_Name.SelectedValue & "" 'HW_Floorcontroller_Id
            sql &= "," & txt_Position_X.Text & "" 'HW_Position_X
            sql &= "," & txt_Position_Y.Text & "" 'HW_Position_Y
            sql &= ",'" & DateTime_Change & "'" 'HW_Datetime_Update
            sql &= "'," & txt_House.Text & "" 'HW_Time_HH
            sql &= "," & txt_Minute.Text & "" 'HW_Time_MM
            sql &= "," & cmb_Status_Name.SelectedValue & "" 'HW_Status_Id
            sql &= "," & cbo_Alam_Name.SelectedValue & "" 'HW_Status_Alarm_Id
            sql &= ",'" & txt_Address_Sensor.Text.Trim & "'" 'HW_Address
            sql &= "','" & txt_Address_Controller.Text.Trim & "'" 'HW_Address_Map
            sql &= "','" & txt_Car_ID.Text & "'" 'HW_Car_ID
            sql &= "'," & cmb_Zone.SelectedValue & "" 'HW_Zone_Id
            sql &= ",0" & "" 'HW_On_Line
            sql &= "," & cmb_Mas_Controller.SelectedValue & "" 'HW_Net_01
            sql &= ",0" & "" 'HW_Net_02
            sql &= ",0" & "" 'HW_Net_03
            sql &= ",0" & "" 'HW_Net_04
            sql &= ",0" & "" 'HW_Net_05
            sql &= ",'" & txt_Remark.Text & "')" 'HW_Remark
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการบันทึกข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                Call Show_Mas_Lot()
                Call Load_Defaulf()
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
        Call mError.ShowError(Me.Name, "Save_Mas_Lot", Err.Number, Err.Description)
    End Sub

    Private Sub Format_Mas_Lot()
        Dim cs As New DataGridViewCellStyleScopes
        With Dgv_Lot
            If .RowCount > 0 Then
                .RowHeadersVisible = False 'ไม่ให้แสดงขอบตาราง
                .ColumnHeadersHeight = 20
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect  'แสดงการเลือกทั้งแถว

                .Columns(0).Visible = True
                .Columns(1).Visible = True
                .Columns(2).Visible = True
                .Columns(3).Visible = True
                .Columns(4).Visible = True
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = True
                .Columns(9).Visible = True


                .Columns(0).Width = 120
                .Columns(1).Width = 160
                .Columns(2).Width = 100
                .Columns(3).Width = 150
                .Columns(4).Width = 148
                .Columns(5).Width = 0
                .Columns(6).Width = 0
                .Columns(7).Width = 0
                .Columns(8).Width = 150
                .Columns(9).Width = 140


                .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


                .Columns(0).HeaderText = "รหัสอุปกรณ์"
                .Columns(1).HeaderText = "ชื่ออุปกรณ์"
                .Columns(2).HeaderText = "ชั้นที่ติดตั้งอุปกรณ์"
                .Columns(3).HeaderText = "อุปกรณ์ควบคุมตามชั้น"
                .Columns(4).HeaderText = "เวลาที่มีการเปลี่ยนแปลงล่าสุด"
                .Columns(5).HeaderText = "เวลาที่จอด"
                .Columns(6).HeaderText = "สถานะการจอด"
                .Columns(7).HeaderText = "ประเภทการจอด"
                .Columns(8).HeaderText = "ที่อยู่อุปกรณ์ตรวจสอบ"
                .Columns(9).HeaderText = "สถานะการเชื่อมต่อ"

                .Rows.Item(0).Height = 20
                .Rows.Item(0).ReadOnly = True

                .Columns(4).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"

            End If
        End With
    End Sub
    Sub Show_Mas_Lot()
        Try
            Con = New SqlConnection(ConStr_Guidance)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Guidance
                .Open()
            End With
        Catch ex As Exception

        End Try

        Dim sql As String = ""
        Try
            If Floor_Name <> "" Then
                sql &= " SELECT "
                sql &= " HW_Lot_Id,HW_Lot_Name,Floor_Name,Floor_Controller_Name,HW_Datetime_Update,"
                sql &= " Parking_Time,HW_Status_Name, Status_Alarm_Name, HW_Address,Status_Name "
                sql &= " FROM Q_Mas_Lot where HW_Floor_No = " & Floor_Name & " ORDER BY HW_Lot_Id "
            Else
                sql &= " SELECT "
                sql &= " HW_Lot_Id,HW_Lot_Name,Floor_Name,Floor_Controller_Name,HW_Datetime_Update,"
                sql &= " Parking_Time,HW_Status_Name, Status_Alarm_Name, HW_Address,Status_Name"
                sql &= " FROM Q_Mas_Lot "
            End If
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            'sqlDs.Clear()
            sqlDa.Fill(sqlDs, "Q_Mas_Lot")
            Dgv_Lot.DataSource = sqlDs.Tables("Q_Mas_Lot")

            Con.Close()

            Call Format_Mas_Lot()

        Catch ex As Exception
            Con.Close()
        End Try


    End Sub

    Sub Show_Mas_Lot_Old()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        If sql_MasLot = "" Then
           
            If Floor_Name <> "" Then
                sql = "SELECT * FROM Q_Mas_Lot where HW_Floor_No = " & Floor_Name & " ORDER BY HW_Lot_Id "
            Else
                sql = "SELECT * FROM Q_Mas_Lot ORDER BY HW_Lot_Id "
            End If
        Else
            sql = sql_MasLot
        End If
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                '  If Not (.BOF And .EOF) Then
                '    lsv_Mas_Lot.Items.Clear()
                '    lsv_Mas_Lot.HeaderStyle = ColumnHeaderStyle.Nonclickable
                '    lsv_Mas_Lot.Alignment = ListViewAlignment.SnapToGrid
                '    .MoveFirst()
                '    'HW_Lot_Id,HW_Lot_Name,Floor_Name,Floorcontroller_Name,HW_Datetime_Update,
                '    'Parking_Time'HW_Status_Name, Status_Alarm_Name, HW_Address, HW_Net_3_Name
                '    Do While Not .EOF
                '        Dim New_Ent As ListViewItem = lsv_Mas_Lot.Items.Add(rs.Fields("HW_Lot_Id").Value)
                '        With New_Ent
                '            .SubItems.Add("" & rs.Fields("HW_Lot_Name").Value) '2
                '            '.SubItems.Add("" & rs.Fields("HW_Floor_No").Value)
                '            .SubItems.Add("" & rs.Fields("Floor_Name").Value) '3
                '            '.SubItems.Add("" & rs.Fields("HW_Floorcontroller_Id").Value)
                '            .SubItems.Add("" & rs.Fields("Floorcontroller_Name").Value) '4
                '            '.SubItems.Add("" & rs.Fields("HW_Position_X").Value & " : " & rs.Fields("HW_Position_Y").Value) '6
                '            .SubItems.Add("" & rs.Fields("HW_Datetime_Update").Value) '7
                '            .SubItems.Add("" & rs.Fields("HW_Time_HH").Value & " ชม. " & rs.Fields("HW_Time_MM").Value & " นาที") '9
                '            '.SubItems.Add("" & rs.Fields("HW_Status_Id").Value)
                '            .SubItems.Add("" & rs.Fields("HW_Status_Name").Value) '10
                '            '.SubItems.Add("" & rs.Fields("HW_Status_Alarm_Id").Value)
                '            .SubItems.Add("" & rs.Fields("Status_Alarm_Name").Value) '11
                '            .SubItems.Add("" & rs.Fields("HW_Address").Value) '12
                '            .SubItems.Add("" & rs.Fields("HW_Net_3_Name").Value)
                '        End With
                '        .MoveNext()
                '    Loop
                'Else

                '    lsv_Mas_Lot.Items.Clear()
                'End If
            End With
        End If
        rs = Nothing
        sql_MasLot = ""
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Show_Mas_Lot", Err.Number, Err.Description)
    End Sub
    Sub Start_Status()
        txt_Lot_Name.Clear()
        txt_Position_X.Text = "00"
        txt_Position_Y.Text = "00"
        txt_House.Text = "00"
        txt_Minute.Text = "00"
        txt_Address_Controller.Text = "00"
        txt_Car_ID.Text = "00"
        txt_Remark.Clear()
    End Sub
    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click

        If btn_Add.Text = "เพิ่ม" Then
            btn_Edit.Text = "แก้ไข"
            Call Load_Defaulf()
            lbl_Lot_Id.Text = Function_New_Lot_ID() 'Function Auto Mas Lot ID
            btn_Edit.Enabled = False
            btn_Delete.Enabled = False

            Un_Lock_Object()
            Start_Status()
            txt_Lot_Name.Focus()
            btn_Search.Enabled = False

            btn_Add.Text = "บันทึก"
            btn_Add.ImageAlign = ContentAlignment.MiddleLeft
            btn_Add.ImageList = Me.img_Save
            If Floor_Name <> "" Then
                cmb_Floor_Name.SelectedValue = Floor_Name
                cmb_Floor_Name.Enabled = False
            End If
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
            End If 'cmb_Zone
            If cmb_Zone.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือก โซนอุกรณ์ ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Floorcontroller_Name.Focus()
                Exit Sub
            End If
            If cmb_Floorcontroller_Name.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือก อุปกรณ์ควบคุมตามชั้น ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Floorcontroller_Name.Focus()
                Exit Sub
            End If
            Dim CountSensor As String = Count_Sensor.CountSensor(cmb_Floorcontroller_Name.SelectedValue)
            Dim FloorControll_Max As String = Count_Sensor.FloorControll_Sensor(cmb_Floorcontroller_Name.SelectedValue)
            If CountSensor >= FloorControll_Max Then
                MsgBox("อุปกรณ์ควบคุมตามชั้น ที่เลือก  ไม่สามารถเพิ่มอุปกรณ์ตรวจสอบตามชั้นได้ " & vbCrLf & _
                        "เนื่องจากอุปกรณ์ควบคุมตามชั้น สามารถเพิ่มอุปกรณ์ตรวจสอบตามชั้นได้  : " & FloorControll_Max & vbCrLf & _
                        "และปัจจุบันอุปกรณ์ตรวจสอบตามชั้นมีจำนวน  : " & CountSensor, MsgBoxStyle.Exclamation, Title_Error)
                cmb_Floorcontroller_Name.Focus()
                Exit Sub
            End If
            If txt_Position_X.Text.Trim = "" Then
                MsgBox("กรุณาป้อนตำแหน่งแกน X  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Position_X.Focus()
                Exit Sub
            End If
            If txt_Position_Y.Text.Trim = "" Then
                MsgBox("กรุณาป้อนตำแหน่งแกน Y  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Position_Y.Focus()
                Exit Sub
            End If
            If txt_House.Text.Trim = "" Then
                MsgBox("กรุณาป้อน เวลาจอดรถ (ชม.)  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_House.Focus()
                Exit Sub
            End If
            If txt_Minute.Text.Trim = "" Then
                MsgBox("กรุณาป้อน เวลาจอดรถ (นาที)  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Minute.Focus()
                Exit Sub
            End If
            If cmb_Status_Name.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะรายการ ", MsgBoxStyle.Exclamation, Title_Error)
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
                MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Floorcontroller และ Hardware ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Zone.Focus()
                Exit Sub
            End If
            If cmb_Mas_Controller.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Hardware ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Mas_Controller.Focus()
                Exit Sub
            End If
            '************** Lingth Text To Database---------------------
            If Trim(txt_Address_Sensor.Text.Length) > 3 Then
                MsgBox("กรุณาป้อนที่อยู่ อุปกรณ์ ไม่เกิน 3 ตัวอักษร ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Address_Sensor.Focus()
                Exit Sub
            End If

            If Trim(txt_Address_Controller.Text.Length) > 4 Then
                MsgBox("กรุณาป้อนที่อยู่  Master Controller ไม่เกิน 4 ตัวอักษร", MsgBoxStyle.Exclamation, Title_Error)
                txt_Address_Controller.Focus()
                Exit Sub
            End If
            If txt_Remark.Text.Trim = "" Then txt_Remark.Text = "-"
            If txt_Remark.Text.Length > 255 Then
                If Trim(txt_Address_Controller.Text.Length) > 4 Then
                    MsgBox(" ไม่สามารถป้อนหมายเหตุเกิน 255 ตัวอักษร ได้ " & vbCrLf & "กรุณาป้อน หมายเหตุอีกครั้ง", MsgBoxStyle.Exclamation, Title_Error)
                    txt_Remark.Focus()
                    Exit Sub
                End If
            End If
            Call Save_Mas_Lot()
            Call Show_Mas_Lot()
            Call Load_Defaulf()
            Call Lock_Object()
            btn_Add.Text = "เพิ่ม"
            btn_Add.ImageList = Me.img_Add
        End If
    End Sub
    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Call Load_Defaulf()

    End Sub

    Private Sub txt_Lot_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Lot_Name.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Floor_Name.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub txt_Lot_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Lot_Name.TextChanged

    End Sub

    Private Sub txt_Position_X_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Position_X.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Position_Y.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Position_X_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Position_X.TextChanged

    End Sub

    Private Sub txt_Position_Y_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Position_Y.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            dtp_Date_Change.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Time_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'txt_House
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_House.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_House_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_House.KeyDown

    End Sub

    Private Sub txt_House_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_House.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Minute.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Minute_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Minute.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Status_Name.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Address_Sensor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Address_Sensor.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Mas_Controller.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Address_Sensor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Address_Sensor.TextChanged

    End Sub

    Private Sub txt_Car_ID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Car_ID.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Address_Sensor.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Remark_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Remark.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Add.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Remark_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Remark.TextChanged

    End Sub

    Private Sub cmb_Floor_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Floor_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Floorcontroller_Name.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Floor_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floor_Name.SelectedIndexChanged
        If cmb_Floor_Name.SelectedIndex = 0 Then Exit Sub
        If btn_Add.Text = "บันทึก" Then Exit Sub
        If btn_Edit.Text = "บันทึก" Then Exit Sub

    End Sub

    Private Sub cmb_Floorcontroller_Name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Floorcontroller_Name.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Position_X.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Floorcontroller_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floorcontroller_Name.SelectedIndexChanged

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

    Private Sub cmb_Mas_Controller_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Mas_Controller.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Remark.Focus()
            Exit Sub
        End If
    End Sub

    'Private Sub cmb_Mas_Controller_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Mas_Controller.KeyPress
    '    If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
    '        cmb_Mas_FloorController.Focus()
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub cmb_Mas_Controller_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Mas_Controller.SelectedIndexChanged

    End Sub

    Private Sub cmb_Mas_FloorController_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmb_Zone.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_Mas_FloorController_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmb_FloorController_HW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_Zone.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Address_Controller.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cmb_FloorController_HW_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Zone.SelectedIndexChanged

    End Sub

    Private Sub txt_Minute_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Minute.TextChanged

    End Sub

    Private Sub txt_Address_Controller_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Address_Controller.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txt_Car_ID.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txt_Address_Controller_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Address_Controller.TextChanged

    End Sub

    Private Sub lsv_Mas_Lot_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'select_Floor_Name()
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        If btn_Edit.Text = "แก้ไข" Then
            If lbl_Lot_Id.Text = "" Then
                MsgBox("กรุณาเลือกข้อมูลที่ต้องการแก้ไข  ", MsgBoxStyle.Information, Title_Error)
                Exit Sub
            End If
            btn_Add.Text = "เพิ่ม"
            'grp_Control.Enabled = True
            'grp_Status.Enabled = True
            Call Un_Lock_Object()
            btn_Add.Enabled = False
            btn_Delete.Enabled = False

            txt_Lot_Name.Focus()
            btn_Search.Enabled = False
            If Floor_Name <> "" Then
                cmb_Floor_Name.SelectedValue = Floor_Name
                cmb_Floor_Name.Enabled = False
            End If
            btn_Edit.ImageList = Me.img_SaveAdd
            btn_Edit.Text = "บันทึก"
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
            If cmb_Zone.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือก โซนอุกรณ์ ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Floorcontroller_Name.Focus()
                Exit Sub
            End If
            If txt_Position_X.Text.Trim = "" Then
                MsgBox("กรุณาป้อนตำแหน่งแกน X  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Position_X.Focus()
                Exit Sub
            End If
            If txt_Position_Y.Text.Trim = "" Then
                MsgBox("กรุณาป้อนตำแหน่งแกน Y  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Position_Y.Focus()
                Exit Sub
            End If
            If txt_House.Text.Trim = "" Then
                MsgBox("กรุณาป้อน เวลาจอดรถ (ชม.)  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_House.Focus()
                Exit Sub
            End If
            If txt_Minute.Text.Trim = "" Then
                MsgBox("กรุณาป้อน เวลาจอดรถ (นาที)  ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Minute.Focus()
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
            'If cmb_Mas_FloorController.SelectedIndex = 0 Then
            '    MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Master และ Floor Controller ", MsgBoxStyle.Exclamation, Title_Error)
            '    cmb_Mas_FloorController.Focus()
            '    Exit Sub
            'End If
            If cmb_Zone.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Floorcontroller และ Hardware ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Zone.Focus()
                Exit Sub
            End If
            If cmb_Mas_Controller.SelectedIndex = 0 Then
                MsgBox("กรุณาเลือกสถานะการเชื่อมต่อ ระหว่าง Hardware ", MsgBoxStyle.Exclamation, Title_Error)
                cmb_Mas_Controller.Focus()
                Exit Sub
            End If
            '************** Lingth Text To Database---------------------
            If Trim(txt_Address_Sensor.Text.Length) > 3 Then
                MsgBox("กรุณาป้อนที่อยู่ อุปกรณ์ ไม่เกิน 3 ตัวอักษร ", MsgBoxStyle.Exclamation, Title_Error)
                txt_Address_Sensor.Focus()
                Exit Sub
            End If

            If Trim(txt_Address_Controller.Text.Length) > 4 Then
                MsgBox("กรุณาป้อนที่อยู่  Master Controller ไม่เกิน 4 ตัวอักษร", MsgBoxStyle.Exclamation, Title_Error)
                txt_Address_Controller.Focus()
                Exit Sub
            End If

            Call Update_Mas_Lot()
            Call Load_Defaulf()
            Call Show_Mas_Lot()
            Call Lock_Object()
            btn_Edit.Text = "แก้ไข"
            btn_Add.ImageList = Me.img_Edit
        End If
    End Sub
    Sub Update_Mas_Lot()
        On Error GoTo Err
        Dim DateTime_Change As String = mDB.DBFormatDate(dtp_Date_Change.Value.ToShortDateString & " " & dtp_Time_Change.Value.ToShortTimeString)
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Dim TrnFlg As Boolean
        sql &= " Update Mas_Lot set HW_Lot_Name ='" & txt_Lot_Name.Text & "'"
        sql &= ", HW_Floor_No = " & cmb_Floor_Name.SelectedValue & ""
        sql &= ", HW_Floorcontroller_Id = " & cmb_Floorcontroller_Name.SelectedValue & ""
        sql &= ", HW_Lot_Tower_ID = " & cboTowerId.SelectedValue & ""
        sql &= ", HW_Position_X = " & txt_Position_X.Text.Trim & ""
        sql &= ", HW_Position_Y = " & txt_Position_Y.Text.Trim & ""
        sql &= ", HW_Datetime_Update = " & DateTime_Change & ""
        sql &= ", HW_Time_HH = " & txt_House.Text.Trim & ""
        sql &= ", HW_Time_MM = " & txt_Minute.Text.Trim & ""
        sql &= ", HW_Status_Id = " & cmb_Status_Name.SelectedValue & ""
        sql &= ", HW_Status_Alarm_Id = " & cbo_Alam_Name.SelectedValue & ""
        sql &= ", HW_Address = '" & txt_Address_Sensor.Text.Trim & "'"
        sql &= "', HW_Address_Map = '" & txt_Address_Controller.Text.Trim & ""
        sql &= ", HW_Car_ID ='" & txt_Car_ID.Text & "'"
        sql &= ", HW_Zone_Id = " & cmb_Zone.SelectedValue & ""
        sql &= ", HW_On_Line = " & cmb_Mas_Controller.SelectedValue & ""
        sql &= ", HW_Remark = '" & txt_Remark.Text & "'"
        sql &= "' where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"
        If OpenCnn(ConnStrGuidance, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการแก้ไข ข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                Exit Sub
            Else
                Conn.RollbackTrans()
                TrnFlg = False
            End If

        End If

        Conn = Nothing
        rs = Nothing
        Call Show_Mas_Lot()
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Update_Mas_Lot", Err.Number, Err.Description)
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
       
        'Value = mDB.Get_Value(ConnStrGuidance, "Floor_Id", "Mas_Lot", "where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'")

        sql = "SELECT HW_Floor_No " & _
              "FROM Mas_Lot where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "' "
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Floor_Name.SelectedValue = rs.Fields("HW_Floor_No").Value
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

        sql = "SELECT HW_Floorcontroller_Id " & _
              "FROM Mas_Lot where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "' "
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Floorcontroller_Name.SelectedValue = rs.Fields("HW_Floorcontroller_Id").Value
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
        'lsv_Mas_Lot.FocusedItem.SubItems(0).Text
        sql = " SELECT HW_Status_Id " & _
              " FROM Mas_Lot where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"
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
        'lsv_Mas_Lot.FocusedItem.SubItems(0).Text
        sql = "SELECT HW_Status_Alarm_Id " & _
              " FROM Mas_Lot where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cbo_Alam_Name.SelectedValue = rs.Fields("HW_Status_Alarm_Id").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_MasAlam_Name", Err.Number, Err.Description)
    End Sub
    Sub Load_Zone_Name()
        On Error GoTo Err
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim Conn As New ADODB.Connection
        'lsv_Mas_Lot.FocusedItem.SubItems(0).Text
        sql = "SELECT HW_Zone_Id " & _
              " FROM Mas_Lot where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    'Dim Z_Id As String = rs.Fields("Zone_Id").Value
                    'Dim name As String = rs.Fields("Zone_Name").Value
                    cmb_Zone.SelectedValue = rs.Fields("HW_Zone_Id").Value
                Else
                    cmb_Zone.SelectedIndex = 0
                End If
            End With
        End If
        rs = Nothing
        Exit Sub


Err:
        Call mError.ShowError(Me.Name, "Load_Zone_Name", Err.Number, Err.Description)
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
        'lsv_Mas_Lot.FocusedItem.SubItems(0).Text
        sql = "SELECT HW_On_Line " & _
              " FROM Mas_Lot where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"
        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    cmb_Mas_Controller.SelectedValue = rs.Fields("HW_On_Line").Value
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "select_HW_Net_3_Connect_HW", Err.Number, Err.Description)
    End Sub
    Sub Select_Other_Object()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim DateTime_Change As DateTime
        Dim Time1 As DateTime
        ' Dim DateTime_Change As DateTime = CDate(Format(dtp_Date_Change.Value, "dd/MM/yyyy") & " " & Format(dtp_Time_Change.Value, "HH:mm:ss"))
        'lsv_Mas_Lot.FocusedItem.SubItems(0).Text
        sql = "SELECT * FROM Mas_Lot_To_Object " & _
              "where HW_Lot_Id = '" & Dgv_Lot.CurrentRow.Cells(0).Value.ToString & "'"

        Dim tl As Integer
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    lbl_Lot_Id.Enabled = True
                    lbl_Lot_Id.Text = Dgv_Lot.CurrentRow.Cells(0).Value.ToString  'HW_Lot_Id
                    txt_Lot_Name.Text = rs.Fields("HW_Lot_Name").Value
                    txt_Position_X.Text = rs.Fields("HW_Position_X").Value
                    txt_Position_Y.Text = rs.Fields("HW_Position_Y").Value
                    Dim DD As DateTime
                    If IsDBNull(rs.Fields("HW_Datetime_Update").Value) = False Then
                        DD = rs.Fields("HW_Datetime_Update").Value
                        dtp_Date_Change.Value = DD.ToShortDateString
                        dtp_Time_Change.Value = DD.ToShortDateString & " " & DD.Hour & ":" & DD.Minute & ":" & DD.Second
                    End If
                    'dtp_Date_Change.Value = Format(CDate(IsDBNull(rs.Fields("HW_Datetime_Update").Value).ToString).ToShortDateString, "dd/MM/yyyy")
                    'dtp_Time_Change.Value = Format(IsDBNull(rs.Fields("HW_Datetime_Update").Value), "dd/MM/yyyy HH:mm:ss")
                    txt_House.Text = IsDBNull(rs.Fields("HW_Time_HH").Value)
                    txt_Minute.Text = IsDBNull(rs.Fields("HW_Time_MM").Value)
                    txt_Address_Sensor.Text = IsDBNull(rs.Fields("HW_Address").Value)
                    txt_Address_Controller.Text = IsDBNull(rs.Fields("HW_Address_Map").Value)
                    txt_Car_ID.Text = IsDBNull(rs.Fields("HW_Car_ID").Value)
                    txt_Remark.Text = IsDBNull(rs.Fields("HW_Remark").Value)

                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Select_Other_Object", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        'If lsv_Mas_Lot.FocusedItem.SubItems(0).Text.Length <= 0 Then Exit Sub
        Call Delete_Mas_Lot()
    End Sub

    Private Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub


    Private Sub grb_Search_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grb_Search.MouseDown
        Go = True
    End Sub

    Private Sub grb_Search_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grb_Search.MouseMove
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
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
        End If
    End Sub

    Private Sub grb_Search_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grb_Search.MouseUp
        Go = False
    End Sub

    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        grb_Search.Visible = True
        btn_Search.Enabled = False
        btn_Add.Enabled = False
        btn_Edit.Enabled = False
        btn_Delete.Enabled = False

        cmb_Search_Floor.SelectedIndex = 0
        cmb_Search_Controller.SelectedIndex = 0
        cmb_Search_Status.SelectedIndex = 0
        cmb_Search_Alam.SelectedIndex = 0
        'cmb_Search_Mas_FloorController.SelectedIndex = 0
        'cmb_Search_FloorController_HW.SelectedIndex = 0
        ' cmb_Search_Sensor.SelectedIndex = 0
    End Sub

    Private Sub btn_Hild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Hild.Click
         Call Load_Defaulf()
    End Sub

    Private Sub btn_Search1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search1.Click
        'sql_MasLot
        Dim Q_Time As String = ""
        Date_Start = Format(dtp_Date_Start.Value, "yyyy-MM-dd")
        Date_Stop = Format(dtp_Date_Stop.Value, "yyyy-MM-dd")
        Time_start = Format(dtp_Time_Start.Value, "hh:MM:ss")
        Time_Stop = Format(dtp_Time_Stop.Value, "hh:MM:ss")
        'If txt_Name.Text.Trim <> "" Then
        Lot_Name = " HW_Lot_Name like '%" & txt_Name.Text & "%'"
        'Else
        'Lot_Name = ""
        'End If
        If cmb_Search_Floor.SelectedIndex > 0 Then
            Floor_Id = "and HW_Floor_No = " & cmb_Search_Floor.SelectedValue & ""
        Else
            Floor_Id = ""
        End If
        If cmb_Search_Controller.SelectedIndex > 0 Then
            Floorcontroller_Id = " and HW_Floorcontroller_Id = " & cmb_Search_Controller.SelectedValue & ""
        Else
            Floorcontroller_Id = ""
        End If
        If cmb_Search_Status.SelectedIndex > 0 Then
            Status_Id = " and HW_Status_Id = " & cmb_Search_Status.SelectedValue & ""
        Else
            Status_Id = ""
        End If
        If cmb_Search_Alam.SelectedIndex > 0 Then
            Status_Alarm_Id = " and HW_Status_Alarm_Id =" & cmb_Search_Alam.SelectedValue & ""
        Else
            Status_Alarm_Id = ""
        End If
        If cmb_Search_Sensor.SelectedIndex > 0 Then
            Net3 = "and HW_On_Line = " & cmb_Search_Sensor.SelectedValue & ""
        Else
            Net3 = ""
        End If
        If cboTowerId2.SelectedIndex > 0 Then
            _Tower_ID = " and  HW_Lot_Tower_ID = " & cboTowerId2.SelectedValue & ""
        Else
            _Tower_ID = ""
        End If
        If chk_Time.Checked = True Then
            dtp_Date_Start.Enabled = True
            dtp_Date_Stop.Enabled = True
            dtp_Time_Start.Enabled = True
            dtp_Time_Stop.Enabled = True
            Q_Time = " and HW_Datetime_Update BETWEEN '" & Date_Start & " " & Time_start & "' And '" & Date_Stop & " " & Time_Stop & "'"
        Else
            dtp_Date_Start.Enabled = False
            dtp_Date_Stop.Enabled = False
            dtp_Time_Start.Enabled = False
            dtp_Time_Stop.Enabled = False
            Q_Time = ""
        End If
        sql_MasLot = "SELECT * FROM Q_Mas_Lot where " & Lot_Name & Floor_Id & _
                     Floorcontroller_Id & Status_Id & Status_Alarm_Id & Net1 & _
                     Net2 & Net3 & Q_Time & _Tower_ID & " ORDER BY HW_Lot_Id"

        Call Show_Mas_Lot()
        Call Load_Defaulf()

    End Sub

    Private Sub txt_Name_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Name.LostFocus
        If txt_Name.Text.Trim <> "" Then
            Lot_Name = "HW_Lot_Name like '%" & txt_Name.Text & "%'"
        Else
            Lot_Name = ""
        End If


    End Sub

    Private Sub cmb_Search_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Search_Floor.SelectedIndexChanged
        If cmb_Search_Floor.SelectedIndex > 0 Then
            Floor_Id = " and  HW_Floor_No = " & cmb_Search_Floor.SelectedValue & ""
        Else
            Floor_Id = ""
        End If
    End Sub

    Private Sub cmb_Search_Controller_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Search_Controller.SelectedIndexChanged
        If cmb_Search_Controller.SelectedIndex > 0 Then
            Floorcontroller_Id = " and HW_Floorcontroller_Id = " & cmb_Search_Controller.SelectedValue & ""
        Else
            Floorcontroller_Id = ""
        End If
    End Sub

    Private Sub cmb_Search_Status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Search_Status.SelectedIndexChanged
        If cmb_Search_Status.SelectedIndex > 0 Then
            Status_Id = " and HW_Status_Id = " & cmb_Search_Status.SelectedValue & ""
        Else
            Status_Id = ""
        End If
    End Sub

    Private Sub cmb_Search_Alam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Search_Alam.SelectedIndexChanged
        If cmb_Search_Alam.SelectedIndex > 0 Then
            Status_Alarm_Id = " and HW_Status_Alarm_Id =" & cmb_Search_Alam.SelectedValue & ""
        Else
            Status_Alarm_Id = ""
        End If
    End Sub

    Private Sub cmb_Search_Sensor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Search_Sensor.SelectedIndexChanged
        If cmb_Search_Sensor.SelectedIndex > 0 Then
            Net3 = "and HW_On_Line = " & cmb_Search_Sensor.SelectedValue & ""
        Else
            Net3 = ""
        End If
    End Sub

    Private Sub btn_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_All.Click
        Show_Mas_Lot()
        Call Load_Defaulf()

    End Sub

    Private Sub dtp_Date_Start_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Date_Start.ValueChanged
        Date_Start = Format(dtp_Date_Start.Text.ToString, "dd:MM:yyyy")
    End Sub

    Private Sub dtp_Date_Stop_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Date_Stop.ValueChanged
        Date_Stop = Format(dtp_Date_Stop.Text.ToString, "dd:MM:yyyy")
    End Sub

    Private Sub dtp_Time_Start_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Time_Start.ValueChanged
        Time_start = Format(dtp_Time_Start.Text.ToString, "hh:MM:ss")

    End Sub

    Private Sub dtp_Time_Stop_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Time_Stop.ValueChanged
        Time_Stop = Format(dtp_Time_Stop.Text.ToString, "hh:MM:ss")
    End Sub

    Private Sub chk_Time_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Time.CheckedChanged
        If chk_Time.Checked = True Then
            dtp_Date_Start.Enabled = True
            dtp_Date_Stop.Enabled = True
            dtp_Time_Start.Enabled = True
            dtp_Time_Stop.Enabled = True
        Else
            dtp_Date_Start.Enabled = False
            dtp_Date_Stop.Enabled = False
            dtp_Time_Start.Enabled = False
            dtp_Time_Stop.Enabled = False
        End If
    End Sub

    Private Sub cboTowerId2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTowerId2.SelectedIndexChanged
        If cboTowerId2.SelectedIndex > 0 Then
            _Tower_ID = " and  HW_Lot_Tower_ID = " & cboTowerId2.SelectedValue & ""
        Else
            _Tower_ID = ""
        End If
    End Sub

    Private Sub Dgv_Lot_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Lot.CellContentClick

    End Sub

    Private Sub Dgv_Lot_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv_Lot.DoubleClick
        Call select_Floor_Name()
        Call select_Controller_Name()
        Call select_MasStatus_Name()
        Call select_MasAlam_Name()
        Call Load_Zone_Name()
        'Call select_HW_Net_2_Floorcontroller_HW()
        Call select_HW_Net_3_Connect_HW()
        Call Select_Other_Object()
    End Sub
End Class