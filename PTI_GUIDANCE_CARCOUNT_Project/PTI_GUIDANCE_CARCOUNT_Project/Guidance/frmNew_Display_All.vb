Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frmNew_Display_All
    Friend Floor_No As String = "1"
    Friend Building_ID As String = "1"
    Friend ZCU_ID As String = ""
    Friend UD_ID As String = ""

    Friend Flag_Start_From As Boolean
    Dim ClsSqlCmd As ClassCommandSql
    Dim Count_Red As Integer
    Dim Count_Green As Integer
    Dim Count As Integer
    Dim A, R, G, B As Integer
    Dim btn(4600) As Label
    Dim lbl_Zone(4500) As Label
    Dim lbl_Z(100) As Label

    Dim OffLeft As Integer
    Dim OffTop As Integer

    Dim HoldLeft As Integer
    Dim HoldTop As Integer
    Dim Go As Boolean
    Dim LeftSet As Boolean
    Dim TopSet As Boolean
    Dim FloorID As String = ""
    Dim Floor_ID As String = ""
    Dim Sensor_Id As String = ""
    Dim Date_Alam_Normal As Date = Now
    Dim Date_Alam As Date = Now
    Dim Status_Alarm_Id = "", Time As String = ""
    Dim index_, I_Index, II_Index As Short
    Dim lbl(4500) As Label
    Dim mFloor As String
    Dim cdb As New CDatabase
    Dim pg_box As PictureBox
    Dim check_click As Integer = 0

    Private Sub frmNew_Display_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerRealtime.Enabled = False
        T_Alert.Enabled = False
    End Sub

   

    Sub menu_floor()
        Try

            Dim i As Integer = 0
            Dim padding_space As Integer = 120
            Dim sql As String = ""
            sql = "SELECT [Floor_ID],[Tower_ID],[Building_ID],[Floor_No],[Floor_Name],[Building_Name] FROM [V_Mas_Floor] order by [Building_ID],[Floor_No] asc"
            Dim rd As RadioButton
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)


            If dt.Rows.Count > 0 Then
                For ii As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(ii).Item("Floor_ID").ToString <> "" Then
                        rd = New RadioButton
                        With rd
                            i = ii * padding_space
                            'rd = RadioButton1
                            .Name = dt.Rows(ii).Item("Building_ID").ToString & "_" & dt.Rows(ii).Item("Floor_No").ToString
                            .Text = dt.Rows(ii).Item("Floor_Name").ToString

                            .BackColor = Color.Transparent
                            .Location = New Point(RadioButton1.Location.X + i, RadioButton1.Location.Y)
                            AddHandler .Click, AddressOf Me.ButtonFloor2_Click

                            PanelDockContainer1.Controls.Add(rd)
                            .BringToFront()
                            'Application.DoEvents()
                        End With
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ButtonFloor2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
          
            Dim a() As String = sender.name.ToString.Split("_")

            sender.checked = True
            Building_ID = a(0)
            'Floor_SelectID = a(1)
            If Floor_No = a(1) Then

            Else
                Floor_No = a(1)
                ZCU_ID = ""

            End If

            Floor_No = a(1)
            Load_(Floor_No, Building_ID, ZCU_ID, UD_ID)
            Application.DoEvents()
            ' End If
            ' TimerRealtime.Enabled = True
            ' Else
            'check_click = 1
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Load_(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_no As String, ByVal ud_id As String)
        Application.DoEvents()
        Call Show_Tab_Building(building_no) ' First Step แสดงเฉพาะ โหลดครั้งแรก
        Call Tab_Floor_Name(floor_no, building_no) '###  Step 1 แสดงชื่อชั้นจอดรถ ทุกชั้น แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor(floor_no) '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น

        Application.DoEvents()
        Call Load_Button_New(floor_no, building_no, zcu_no, ud_id) '###  Step 3 Load Ultrasonic มาแสดง

        Call Load_Board_Zone(floor_no, Building_ID)
        Call count_status_Alarm_id(floor_no, building_no, zcu_no)
    End Sub
   
    Sub Timer_True()
        TimerRealtime.Enabled = True

    End Sub
    Sub Timer_False()
        TimerRealtime.Enabled = False

    End Sub
    
    Sub Show_Floor()

        ' Call DisPlay_Status_In_Floor()


        Call Value_In_Zone() 'จำนวนรถว่างในแต่ละโซน

    End Sub
    Sub Tab_Floor_Name(ByVal floor_no As String, ByVal buiding As String) 'ชื่อของชั้นของแท็บ

        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT [Floor_ID]"
            sql &= ",[Tower_ID]"
            sql &= ",[Building_ID]"
            sql &= ",[Building_Name]"
            sql &= ",[Floor_No]"
            sql &= ",[Floor_Name] "
            sql &= ",[Floor_Lot_All] "
            sql &= ",[Floor_Lot_Empty] "
            sql &= ",[Floor_Lot_Parking] "
            sql &= " FROM [V_Mas_Floor] "
            sql &= " WHERE [Floor_ID]='" & floor_no & "' and [Building_ID]='" & buiding & "'"
            sql &= " ORDER BY Building_ID, Floor_No "


            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                Me.Text = DT.Rows(0).Item("Building_Name").ToString & " - " & DT.Rows(0).Item("Floor_Name").ToString
                Lb_status_lot_all.Text = DT.Rows(0).Item("Floor_Lot_All").ToString
                Lb_status_lot_avalaible.Text = DT.Rows(0).Item("Floor_Lot_Empty").ToString
                Lb_status_lot_use.Text = DT.Rows(0).Item("Floor_Lot_Parking").ToString
            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงชื่อชั้นจอดรถ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Show_Tab_Building(ByVal buiding_id As String) 'ชื่อของอาคารของแท็บ


        Try

            sql = "SELECT * FROM Mas_Building_Parking WHERE Building_ID='" & buiding_id & "'"
            sql &= " ORDER BY "
            sql &= " CASE WHEN LEFT(Building_ID, 1) BETWEEN '0' AND '9' THEN ' ' ELSE LEFT(Building_ID, 1) END, "
            sql &= " CAST(STUFF(Building_ID, 1, CASE WHEN LEFT(Building_ID, 1) BETWEEN '0' AND '9' THEN 0 ELSE 1 END, '') AS int)"

            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)

            If DT.Rows.Count > 0 Then
                'For i As Integer = 0 To DT.Rows.Count - 1
                '    'Tab_Building.Controls.Item(0).Tag = DT.Rows(i).Item("Building_ID").ToString.Trim
                '    'Tab_Building.Controls.Item(0).Text = DT.Rows(i).Item("Building_Name").ToString.Trim
                '    'Tab_Building.Tabs(Tab_Building.Controls.Item(0).Tag - 1).Visible = False
                'Next
            End If
            'Tab_Building.SelectedTabIndex = Tab_Building.Controls.Item(0).Tag - 1

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงรายการ Tab อาคารจอดรถ ", Err.Number, Err.Description)
        End Try
    End Sub
    Function Show_Picture(ByVal Floor_ID As String, Optional ByVal Tower_ID As String = "") As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""


        If Tower_ID <> "" Then
            sql = "Select Floor_Image from Mas_Floor WHERE Floor_Id =" & Floor_ID & " and Building_Id = '" & Tower_ID & "'"
        Else
            sql = "Select Floor_Image from Mas_Floor WHERE Floor_Id =" & Floor_ID & ""
        End If

        If OpenCnn(ConnStrMasTer, Conn) Then
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

                       

                    Else
                      

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
    Private Sub nodebtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = False
        LeftSet = False
        TopSet = False
    End Sub
    Private Sub nodebtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = True
    End Sub
    Sub Load_Board_Zone(ByVal floor_No As String, ByVal Building_ID As String)
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            'Pic_ID_2.Controls.Clear()
            sql = "SELECT * " & _
                  "FROM V_MAS_Display_Config_Data where Floor_No ='" & floor_No & "' and Building_ID='" & Building_ID & "' and [Display_Type] not in('Main','MAIN') order by ID_Display"
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
                                .Size = New Size(CInt(rs.Fields("DP_Size_Width").Value), CInt(rs.Fields("DP_Size_Height").Value)) 'ขนาด button
                                .Name = rs.Fields("ID_Display").Value  'ชื่อ button
                                .Tag = rs.Fields("ID_Display").Value
                                .Text = rs.Fields("Display_Lot_Emply").Value 'Zone_Name
                                .Font = New Font("7 Segment", CInt(rs.Fields("Font_Size").Value), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                .Cursor = Cursors.Hand
                                .TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("Back_ColorA").Value, rs.Fields("Back_ColorR").Value, rs.Fields("Back_ColorG").Value, rs.Fields("Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("Font_ColorA").Value, rs.Fields("Font_ColorR").Value, rs.Fields("Font_ColorG").Value, rs.Fields("Font_ColorB").Value)
                                .Location = New Point(rs.Fields("DP_Position_X").Value, rs.Fields("DP_Position_Y").Value)
                                .Parent = Me
                                'AddHandler .Click, AddressOf Me.Button_Click
                                'AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                                'AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                                'AddHandler .MouseUp, AddressOf nodebtn_MouseUp
                                Me.Pic_ID_2.Controls.Add(lbl_Z(I_Index)) 'เพิ่ม Button
                            End With
                            .MoveNext()
                        Loop
                    Else
                    End If
                End With
            End If
            'lbl_EXC.Location = New Point(597, 44)
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
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
        End If
    End Sub
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer_False()
        Dim lbl_ As PictureBox
        If TypeOf (sender) Is PictureBox Then
            lbl_ = sender
            Dim frm As New frm_Lot_History_New
            With frm
                mForm.Set_Standard_Form(frm)
                .Lot_id = lbl_.Name
                .Buiding_id = Building_ID
                .floor_no = Floor_No         
                '.date_st = CDate(Now.Date & " 00:00:00")
                '.date_end = CDate(Now.Date & " 23:59:59")
                .ShowDialog()
                .Dispose()
            End With
        End If
        Timer_True()
    End Sub
    Private Sub mouse_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn_ As PictureBox
        Me.Cursor = Cursors.Hand
        If TypeOf (sender) Is PictureBox Then
            btn_ = sender
            Dim lbl_ As Label = Label1

            Dim panel_ As Panel = Pl_detail
            With panel_
                lbl_.Text = btn_.Text.Trim
                lbl_.BringToFront()
                '.Location = New Point(Cursor.Position.X - 20, Cursor.Position.Y - 20)
                .Visible = True
                .BringToFront()
                lbl_.BringToFront()
            End With
        End If
    End Sub
    Private Sub mouse_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Pl_detail.Visible = False
    End Sub

    Sub Save_Controller_Position()
        On Error GoTo Err
        'Dim DateTime_Change As DateTime = CDate(Format(dtp_Date_Change.Value, "dd/MM/yyyy") & " " & Format(dtp_Time_Change.Value, "HH:mm:ss"))
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
            End With

        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Save_Controller_Position", Err.Number, Err.Description)

    End Sub
    Sub Show_Status_Sensor_as_Select()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rs2 As New ADODB.Recordset
        Dim sql As String = ""
        Dim Re_Mark As String = ""
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Car_In, Car_Out As String
        Car_In = ""
        Car_Out = ""
        sql = "SELECT * FROM Q_Mas_Lot where HW_Lot_Id ='" & Lot_Id & "' where HW_Position_X <> 0 and HW_Position_Y <> 0 "
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

                    'Count of Sensor IN---------------------------------------------------------------------------------------
                    Dim HW_Address As String = rs.Fields("HW_Address").Value
                    Dim HW_Address_Map As String = rs.Fields("HW_Address_Map").Value
                    Dim HW_Remark As String = rs.Fields("HW_Remark").Value
                    'If lbl_Id.Text <> "" Then
                    '    sql = "SELECT COUNT(Trn_Lot_Id) as Car_In FROM Q_Tran_Lot where HW_Lot_Id ='" & lbl_Id.Text & _
                    '          "' and Trn_Log_Datetime_In Between '" & Format(Date.Now, "yyyy-MM-dd 00:00:00") & "' and '" & Format(Date.Now, "yyyy-MM-dd 23:59:59") & "'"
                    'End If
                    If OpenCnn(ConnStrGuidance, Conn) Then
                        With rs2
                            If .State = 1 Then .Close()
                            .let_ActiveConnection(Conn)
                            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                            .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                            .Open(sql)
                            If Not (.BOF And .EOF) Then
                                Car_In = rs2.Fields("Car_In").Value
                            Else
                                'lbl_Count_CarIn.Text = 0
                            End If
                        End With
                    End If
                    'Count of Sensor Out---------------------------------------------------------------------------------------


                    If OpenCnn(ConnStrGuidance, Conn) Then
                        With rs2
                            If .State = 1 Then .Close()
                            .let_ActiveConnection(Conn)
                            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                            .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                            .Open(sql)
                            If Not (.BOF And .EOF) Then
                                Car_Out = rs2.Fields("Car_out").Value
                            Else
                                ' lbl_Count_CarIn.Text = 0
                            End If
                        End With
                    End If

                End If
            End With
        End If
        rs = Nothing
        rs2 = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Show_Status_Sensor_as_Select", Err.Number, Err.Description)
    End Sub
    Sub Check_Status_FloorController()
        Try

            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim rs2 As New ADODB.Recordset
            ' Floor_Select_ID = "2"
            Dim sql As String = ""
            Dim i, Rows, j As Integer
            Dim a(9)
            Dim HW_Floorcontroller_Id As String = ""

            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        .MoveFirst()
                        'Do While Not .EOF
                        For i = 1 To rs.RecordCount
                            HW_Floorcontroller_Id = ""
                            HW_Floorcontroller_Id = rs.Fields("HW_Floorcontroller_Id").Value
                            a(i) = HW_Floorcontroller_Id
                            Rows += 1
                            rs.MoveNext()
                        Next
                    End If
                End With
            End If
            For j = 1 To Rows
                HW_Floorcontroller_Id = ""
                HW_Floorcontroller_Id = a(j)
                sql = "SELECT Floorcontroller_Status FROM Mas_Floorcontroller where Floorcontroller_Id= " & HW_Floorcontroller_Id & ""
                If OpenCnn(ConnStrGuidance, Conn) Then
                    With rs2
                        If .State = 1 Then .Close()
                        .let_ActiveConnection(Conn)
                        .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                        .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                        .Open(sql)
                        If Not (.BOF And .EOF) Then
                            'If rs2.Fields("Floorcontroller_Status").Value = 0 Then
                            '    lbl_Floor_F.Text = Val(lbl_Floor_F.Text) + 1
                            'ElseIf rs2.Fields("Floorcontroller_Status").Value = 1 Then
                            '    lbl_Floor_T.Text = Val(lbl_Floor_T.Text) + 1
                            'End If
                        End If
                    End With
                End If
            Next j

            rs2 = Nothing
            rs = Nothing
            Exit Sub
            'Err_Renamed:

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Check_Status_FloorController", Err.Number, Err.Description)

        End Try
    End Sub
    Private Sub TimerRealtime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRealtime.Tick

        TimerRealtime.Enabled = False
        Call update_Button_New_load(Pic_ID_2)
        Call count_status_Alarm_id(Floor_No, Building_ID, ZCU_ID)
        Call Tab_Floor_Name(Floor_No, Building_ID)
        Call update_Display_New()
        Application.DoEvents()
        TimerRealtime.Enabled = True

    End Sub

    'Public Sub update_Button_New(ByVal buiding_ As String, ByVal floor_ As String)
    '    Try
    '        Dim sql As String = ""
    '        'Dim dt As DataTable
    '        Dim visible_ As Boolean = True

    '        Dim sqls As String = "SELECT * FROM [Q_Mas_Lot] WHERE HW_Building_ID =' " & buiding_ & "' and Floor_No='" & floor_ & "'"

    '        Dim dtt As DataTable = cdb.readTableData(sqls, ConStr_Guidance)
    '        If dtt.Rows.Count > 0 Then
    '            For ii As Integer = 0 To dtt.Rows.Count - 1
    '                For Each dp As Control In Pic_ID_2.Controls
    '                    If TypeOf (dp) Is PictureBox Then
    '                        If dtt.Rows(ii).Item("HW_Lot_Id").ToString = dp.Name Then
    '                            dp.BackgroundImage = Status_Alarm_Car(dtt.Rows(0).Item("Alarm_Id").ToString, visible_, dtt.Rows(0).Item("HW_Plan_Direction").ToString)
    '                            dp.Visible = visible_
    '                            dp.Text = "        " & _
    '                                 "Lot_Id: " & dtt.Rows(ii).Item("HW_Lot_Id").ToString & " " & _
    '                                 "Lot_Name: " & dtt.Rows(ii).Item("HW_Lot_Name").ToString & " " & _
    '                                 "controller: " & dtt.Rows(ii).Item("Floor_Controller_Name").ToString & " " & _
    '                                 "Status: " & dtt.Rows(ii).Item("Status_Name").ToString
    '                        End If
    '                    End If
    '                Next
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox("update_Button_New : " & ex.Message)
    '    End Try
    'End Sub

    Sub update_Display_New()
        Try
            Dim sql As String = ""
            Dim dt As DataTable
            For Each dp As Control In Pic_ID_2.Controls
                If TypeOf (dp) Is Label Then
                    sql = "SELECT * FROM [V_MAS_Display_Config_Data]  WHERE [ID_Display] = '" & dp.Name & "' and [Display_Type] not in('Main','MAIN')"
                    dt = cdb.readTableData(sql, ConStr_Master)
                    If dt.Rows.Count > 0 Then
                        dp.Text = dt.Rows(0).Item("Display_Lot_Emply").ToString
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("update_Display_New : " & ex.Message)
        End Try
    End Sub

    'Sub update_Button_New()
    '    Try
    '        Dim sql As String = ""
    '        Dim dt As DataTable
    '        For Each dp As Label In Pic_ID_2.Controls
    '            sql = "SELECT * FROM [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Q_Mas_Lot]  WHERE HW_Lot_Id = '" & dp.Name & "'"
    '            dt = cdb.readTableData(sql, ConStr_Guidance)
    '            If dt.Rows.Count > 0 Then
    '                dp.BackColor = Status_Alarm_Color(dt.Rows(0).Item("Alarm_Id").ToString)
    '                dp.Text = "        " & _
    '                             "Lot_Id: " & dt.Rows(0).Item("HW_Lot_Id").ToString & " " & _
    '                             "Lot_Name: " & dt.Rows(0).Item("HW_Lot_Name").ToString & " " & _
    '                             "controller: " & dt.Rows(0).Item("Floor_Controller_Name").ToString & " " & _
    '                             "Status: " & dt.Rows(0).Item("Status_Name").ToString
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox("update_Button_New : " & ex.Message)
    '    End Try
    'End Sub
    Sub Load_Board_Zone_Display_Value()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        '  Dim i As Integer
        Try
            'For i = 1 To mFloor
            sql = "SELECT * FROM Mas_Floor_Zone "
            sql &= "  order by Zone_Id    "
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
                            lbl_Zone(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                            With Me.lbl_Zone(I_Index)
                                .Size = New Size(CInt(rs.Fields("Zone_SizeX").Value), CInt(rs.Fields("Zone_SizeY").Value)) 'ขนาด button
                                .Name = "lbl" & rs.Fields("Zone_Id").Value  'ชื่อ button
                                ' .Tag = rs.Fields("Zone_Id").Value
                                Dim Value_Zone As String = mCountCar.Get_Count_CarInZone(rs.Fields("Zone_Id").Value, rs.Fields("Zone_Floor_No").Value, rs.Fields("Zone_Building_ID").Value)
                                If Value_Zone = 0 Then
                                    .Text = "FULL"
                                Else
                                    .Text = Value_Zone
                                End If
                                ' rs.Fields("Zone_Id").Value

                                .Font = New Font("7 Segment", CInt(rs.Fields("Font_Size").Value), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                '.Cursor = Cursors.Hand
                                ' .TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("Zone_Back_ColorA").Value, rs.Fields("Zone_Back_ColorR").Value, rs.Fields("Zone_Back_ColorG").Value, rs.Fields("Zone_Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("Zone_Font_ColorA").Value, rs.Fields("Zone_Font_ColorR").Value, rs.Fields("Zone_Font_ColorG").Value, rs.Fields("Zone_Font_ColorB").Value)
                                .Location = New Point(rs.Fields("Zone_PositionX").Value, rs.Fields("Zone_PositionY").Value)
                                .Parent = Me
                                'Select Case rs.Fields("Zone_Building_ID").Value.ToString
                                '    Case "1"
                                '        Select Case rs.Fields("Zone_Floor_No").Value.ToString
                                '            Case "1"
                                '                Me.Pic_ID_1.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '            Case "2"
                                '                Me.Pic_ID_2.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '            Case "3"
                                '                Me.Pic_ID_3.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '            Case "4"
                                '                Me.Pic_ID_4.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '            Case "5"
                                '                Me.Pic_ID_5.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '            Case "6"
                                '                Me.Pic_ID_6.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '        End Select
                                'Case "2"
                                'Select Case rs.Fields("Zone_Floor_No").Value.ToString
                                '    Case "1"
                                '        Me.Pic_ID_7.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '    Case "2"
                                '        Me.Pic_ID_8.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '    Case "3"
                                '        Me.Pic_ID_9.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '    Case "4"
                                '        Me.Pic_ID_10.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '    Case "5"
                                '        Me.Pic_ID_11.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                '    Case "6"
                                '        Me.Pic_ID_12.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                'End Select
                                'End Select
                            End With
                            .MoveNext()
                        Loop
                    Else

                    End If
                End With
            End If
            ' Next
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงป้ายจำนวนรถแต่ละ โซนจอดรถ", Err.Number, Err.Description)
        End Try
    End Sub

    Sub Value_In_Zone(Optional ByVal BuildingID As String = Nothing, Optional ByVal FloorNO As String = Nothing)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I As Short = 0

        Try
            sql = "SELECT * FROM Mas_Floor_Zone "
            sql &= " where [Zone_Building_ID] = " & BuildingID & ""
            sql &= "  and [Zone_Floor_No]  = " & FloorNO & ""
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
                            Dim Zone As String = rs.Fields("Zone_Id").Value
                            Dim V_Zone As String
                            II_Index = Zone
                            V_Zone = mCountCar.Value_in_Zone(Zone)
                            I += 1
                            If V_Zone = 0 Then
                                lbl_Zone(I).Text = "FULL"
                            Else
                                lbl_Zone(I).Text = 0
                                lbl_Zone(I).Text = V_Zone
                            End If
                            .MoveNext()
                        Loop
                    Else
                    End If
                End With
            End If
        Catch ex As Exception
            ' Call mError.ShowError(Me.Name, "Value_In_Zone", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Show_Picture_Floor(ByVal floor_no As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        Pic_ID_2.Controls.Clear()

        sql = "Select Floor_Image,Floor_Id from Mas_Floor WHERE Floor_Id = '" & floor_no & "' "

        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    Do While Not .EOF
                        If Not VB.IsDBNull(.Fields("Floor_Image").Value) Then
                            Dim RetByte() As Byte = CType(.Fields("Floor_Image").Value, Byte())
                            Dim PictureData() As Byte = RetByte
                            Dim Ms As New System.IO.MemoryStream(PictureData)
                            Pic_ID_2.Image = Image.FromStream(Ms)
                            PictureBox1.Image = Image.FromStream(Ms)
                        Else
                            Pic_ID_2.Image = Pic_ID_2.ErrorImage

                        End If
                        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        .MoveNext()
                    Loop
                Else
                    rs.Close()
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default : Me.Enabled = True : Exit Sub
                End If
            End With
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Exit Sub
Err:
        '    Call mError.ShowError(Me.Name, "แสดงรูปภาพลานจอดรถ ", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
    End Sub

    Private Sub btn_MainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Timer_False()
        Me.Dispose()
    End Sub
    Sub Refesh_Status() 'ไม่ถูกใช้งาน
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Index As Short
        sql = "SELECT * FROM Q_Mas_Lot where Floor_Id =" & Floor_Select_Id & " order by HW_Lot_Id"
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
                    For Index = 0 To rs.RecordCount - 1
                        Dim Status_Sensor As String = ""
                        Dim Lot As String = ""
                        Dim name As String = ""
                        Status_Sensor = .Fields("HW_Net_3").Value
                        Lot = .Fields("HW_Lot_Id").Value
                        name = btn(Index).Name
                        If Status_Sensor = 0 And Lot = name Then
                            'btn(Index).BackColor = 
                            Dim A As String = .Fields("Status_Alarm_Color_A").Value
                            Dim R As String = .Fields("Status_Alarm_Color_R").Value
                            Dim G As String = .Fields("Status_Alarm_Color_G").Value
                            Dim B As String = .Fields("Status_Alarm_Color_B").Value
                            btn(Index).BackColor = Color.FromArgb(A, R, G, B)
                        Else
                            If .Fields("HW_Status_Id").Value = 1 Then
                                btn(Index).BackColor = Color.Red
                            Else
                                btn(Index).BackColor = Color.Lime
                            End If
                        End If
                        Application.DoEvents()
                        .MoveNext()
                    Next
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Refesh_Status", Err.Number, Err.Description)
    End Sub

    Sub Set_Status_Lot_Parking()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Status_Alarm_Time_Min As String = ""
        Dim Status_Alarm_Time_Max As String = ""
        Dim Carparking As String = ""
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
                    .MoveFirst()
                    Do While Not .EOF
                        Dim Id As String = .Fields("Status_Alarm_Id").Value
                        Dim A As String = .Fields("Status_Alarm_Color_A").Value
                        Dim R As String = .Fields("Status_Alarm_Color_R").Value
                        Dim G As String = .Fields("Status_Alarm_Color_G").Value
                        Dim B As String = .Fields("Status_Alarm_Color_B").Value
                        Status_Alarm_Time_Min = .Fields("Status_Alarm_Time_Min").Value
                        Status_Alarm_Time_Max = .Fields("Status_Alarm_Time_Max").Value

                        Select Case Id
                            Case "0"
                                lbl_Status_Green.Text = .Fields("Status_Alarm_Name").Value 'ไม่มีรถจอด
                                lbl_Color_Green.BackColor = Color.FromArgb(A, R, G, B)
                            Case "1"
                                lbl_Status_Red.Text = .Fields("Status_Alarm_Name").Value 'มีรถจอด แต่ไม่เกิน เวลาที่กำหนด เช่น จอดไม่เกิน 15 นาที
                                lbl_Color_Red.BackColor = Color.FromArgb(A, R, G, B)
                            Case "2"
                                lbl_Color_False.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_False.Text = ""
                                lbl_Status_False.Text = .Fields("Status_Alarm_Name").Value
                            Case "3"
                                lbl_Color_Status1.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_1.Text = ""
                                lbl_Status_1.Text = .Fields("Status_Alarm_Name").Value
                            Case "4"
                                lbl_Color_Status2.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_2.Text = ""
                                lbl_Status_2.Text = .Fields("Status_Alarm_Name").Value
                            Case "5"
                                lbl_Color_Status3.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_3.Text = ""
                                lbl_Status_3.Text = .Fields("Status_Alarm_Name").Value
                            Case "6"
                                lbl_Color_Status4.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_4.Text = ""
                                lbl_Status_4.Text = .Fields("Status_Alarm_Name").Value
                            Case "7"
                                lbl_Color_Status5.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_5.Text = ""
                                lbl_Status_5.Text = .Fields("Status_Alarm_Name").Value
                            Case "8"
                                lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_6.Text = ""
                                lbl_Status_6.Text = .Fields("Status_Alarm_Name").Value

                            Case "9"
                                lbl_Color_Status7.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_7.Text = ""
                                lbl_Status_7.Text = .Fields("Status_Alarm_Name").Value
                            Case "10"
                                lbl_Color_Status8.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_8.Text = ""
                                lbl_Status_8.Text = .Fields("Status_Alarm_Name").Value
                            Case "11"
                                lbl_Color_Status9.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_9.Text = ""
                                lbl_Status_9.Text = .Fields("Status_Alarm_Name").Value
                            Case "12"
                                lbl_Color_Status10.BackColor = Color.FromArgb(A, R, G, B)
                                lbl_Status_10.Text = ""
                                lbl_Status_10.Text = .Fields("Status_Alarm_Name").Value

                        End Select
                        .MoveNext()
                    Loop
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        '   Call mError.ShowError(Me.Name, "Select_Color_Status_Alam_Value", Err.Number, Err.Description)
    End Sub
    Sub Set_Color_btn(Optional ByVal BuildingID As String = Nothing, Optional ByVal FloorNO As String = Nothing)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I As Short = 0
        Try
            'maxx 20151014 ทำให้สีสถานะ แสดงผลผิดพลาด
            'View Q_Mas_Lot store only lot L data  (where HW_Lot_Type ='L')
            'sql = " SELECT distinct HW_Lot_Id,Status_Alarm_Color_A,Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B FROM Q_Mas_Lot "
            'sql &= " where HW_Building_ID = " & BuildingID & ""
            'sql &= " and Floor_No =  " & FloorNO & ""
            'sql &= " order by HW_Lot_Id "

            sql = " SELECT distinct HW_Lot_Id,HW_Status_Id,HW_Position_X,HW_Position_Y,Floor_Name, " & _
                  " Status_Alarm_Color_A, Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B "
            sql &= " ,HW_Building_ID,HW_Floor_No "
            sql &= " FROM Q_Mas_Lot "
            sql &= " where HW_Lot_Type='L' "
            sql &= " order by HW_Lot_Id"
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
                            Dim Tag As String = ""
                            Tag = Mid(.Fields("HW_Lot_Id").Value, 4, 8)
                            Dim A As String = .Fields("Status_Alarm_Color_A").Value
                            Dim R As String = .Fields("Status_Alarm_Color_R").Value
                            Dim G As String = .Fields("Status_Alarm_Color_G").Value
                            Dim B As String = .Fields("Status_Alarm_Color_B").Value
                            I += 1
                            btn(I).BackColor = Color.FromArgb(A, R, G, B)

                            .MoveNext()
                        Loop
                    End If
                End With
            End If

        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        End Try
    End Sub
    Sub Update_Color_Alam_ID(Optional ByVal BuildingID As String = Nothing, Optional ByVal FloorNO As String = Nothing)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I As Short = 0
        Try

            sql = " SELECT * FROM Q_Mas_Lot "
            sql &= " where HW_Building_ID = " & BuildingID & ""
            sql &= " and HW_Floor_No =  " & FloorNO & ""
            sql &= " order by HW_Lot_Id "
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
                            Dim Tag As String = ""
                            Dim HW_Time_HH As Integer
                            Dim HW_Time_MM As Integer
                            Dim Total_MM As Integer
                            Dim HW_Status_Alarm_Id As String = ""
                            Tag = Mid(.Fields("HW_Lot_Id").Value, 4, 8)
                            HW_Time_HH = .Fields("HW_Time_HH").Value
                            HW_Time_MM = .Fields("HW_Time_MM").Value
                            Total_MM = CInt((HW_Time_HH) * 60) + CInt(HW_Time_MM)

                            HW_Status_Alarm_Id = .Fields("HW_Status_Alarm_Id").Value

                            'HW_On_Line
                            If .Fields("HW_On_Line").Value = "1" Then
                                Excute_SQL(ConStr_Guidance, " update Mas_Lot set HW_Status_Alarm_Id =" & HW_Status_Alarm_Id & " where HW_Lot_Id = " & .Fields("HW_Lot_Id").Value & "")
                            End If
                            If .Fields("HW_On_Line").Value = "1" And .Fields("HW_Status_Id").Value = "0" Then
                                Excute_SQL(ConStr_Guidance, " update Mas_Lot set HW_Status_Alarm_Id ='0', HW_Time_HH='0', HW_Time_MM = '0' where HW_Lot_Id = " & .Fields("HW_Lot_Id").Value & "")
                            End If

                            'MessageBox.Show(HW_Status_Alarm_Id)

                            .MoveNext()
                        Loop
                    End If
                End With
            End If

            ' MessageBox.Show("update alarm")

        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        End Try
    End Sub
    Private Sub lsv_Alam_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'HW_Lot_Id = lsv_Alam.FocusedItem.SubItems(0).Text()
        If HW_Lot_Id = "" Then Exit Sub
        Dim frm As New frm_Location_Detail
        Timer_False()
        With frm
            mForm.Set_Standard_Form(frm)
            ' .Text = M_Report_CarInOut_byDay.Text
            .ShowDialog()
            .Dispose()
        End With
        Timer_True()
    End Sub
    Sub Load_Board_Zone_Name()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0

        Try
            sql = "SELECT * FROM Mas_Floor_Zone_Name "
            sql &= " order by F_Zone_Id"

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
                                '.Tag = rs.Fields("F_Zone_Id").Value
                                .Text = rs.Fields("F_Zone_Name").Value
                                .Font = New Font("Microsoft Sans Serif", CInt(rs.Fields("F_Font_Size").Value), FontStyle.Bold) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                ' .Cursor = Cursors.Hand
                                '.TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("F_Zone_Back_ColorA").Value, rs.Fields("F_Zone_Back_ColorR").Value, rs.Fields("F_Zone_Back_ColorG").Value, rs.Fields("F_Zone_Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("F_Zone_Font_ColorA").Value, rs.Fields("F_Zone_Font_ColorR").Value, rs.Fields("F_Zone_Font_ColorG").Value, rs.Fields("F_Zone_Font_ColorB").Value)
                                .Location = New Point(rs.Fields("F_Zone_PositionX").Value, rs.Fields("F_Zone_PositionY").Value)
                                .Parent = Me
                            End With
                            .MoveNext()
                        Loop
                    Else
                    End If
                End With
            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
        End Try
    End Sub
   
    Sub Load_Button_New(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_id As String, ByVal ud_id As String)
        'Dim PositionX As Integer = 20 ' X not < 750 20
        'Dim PositionY As Integer = 26 ' 26
        Dim sql As String = ""
        Dim i As Short = 0
        I_Index = 0
        Try
            sql = " SELECT distinct * "
            sql &= " FROM Q_Mas_Lot "
            sql &= " where HW_Lot_Type='L' and HW_Building_ID='" & building_no & "' and Floor_No = '" & floor_no & "'"
            If zcu_id <> "" Then
                sql &= " and HW_Floorcontroller_Id ='" & zcu_id & "'"
            End If
            If ud_id <> "" Then
                sql &= " and HW_Lot_Id ='" & ud_id & "'"
            End If
            sql &= " order by HW_Lot_Id"

            Application.DoEvents()
            Dim Tag As String = ""
            Dim I_Index As Integer = 0
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then
                With PictureBox1
                    .Visible = True
                    .Width = Pic_ID_2.Width
                    .Height = Pic_ID_2.Height
                End With
                With CircularProgress2
                    .Maximum = 100
                    .BackColor = Color.Transparent
                    .Location = New Point((Me.Width / 2) - (.Width / 2), (Me.Height / 2) - (.Height / 2) - 50)
                    .Visible = True
                End With

                Clear_count_alarm_id()
                Set_count_alarm_id()

                For ii As Integer = 0 To DT.Rows.Count - 1
                    If DT.Rows(ii).Item("HW_Position_X").ToString = "0" And DT.Rows(ii).Item("HW_Position_Y").ToString = "0" Then

                    Else
                        If DT.Rows(ii).Item("HW_Position_X").ToString = "" And DT.Rows(ii).Item("HW_Position_Y").ToString = "" Then

                        Else
                            pg_box = New PictureBox
                            Dim name_ As String = DT.Rows(ii).Item("HW_Lot_Id").ToString
                            Dim location_x As String = DT.Rows(ii).Item("HW_Position_X").ToString
                            Dim location_y As String = DT.Rows(ii).Item("HW_Position_Y").ToString
                            Dim direction As String = DT.Rows(ii).Item("HW_Plan_Direction").ToString
                            Dim Alarm_id As Integer = DT.Rows(ii).Item("Alarm_Id").ToString
                            'count_alarm_id(Alarm_id)
                            Tag = Mid(DT.Rows(ii).Item("HW_Lot_Id").ToString, 4, 8)
                            Add_Control(pg_box, name_, location_x, location_y, Tag, Alarm_id, direction)
                            With pg_box
                                .Text = "        " & _
                                     "Lot_Id: " & DT.Rows(ii).Item("HW_Lot_Id").ToString & " " & _
                                     "Lot_Name: " & DT.Rows(ii).Item("HW_Lot_Name").ToString & " " & _
                                     "controller: " & DT.Rows(ii).Item("Floor_Controller_Name").ToString & " " & _
                                     "Status: " & DT.Rows(ii).Item("Status_Name").ToString

                                AddHandler .Click, AddressOf Me.Button_Click
                                AddHandler .MouseHover, AddressOf Me.mouse_Hover
                                AddHandler .MouseLeave, AddressOf Me.mouse_leave
                                Pic_ID_2.Controls.Add(pg_box)
                                .BringToFront()
                            End With
                        End If

                    End If

                    CircularProgress2.Value = (DT.Rows.Count / 100) * ii
                    Application.DoEvents()
                Next
                'CircularProgress2.Visible = False
                'Application.DoEvents()
                PictureBox1.Visible = False
                CircularProgress2.Visible = False

                Application.DoEvents()
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Button_New", Err.Number, Err.Description)
        End Try
    End Sub
    Function Status_Alarm_Color(ByVal id_ As String) As Color
        Try


            Dim A, R, G, B As Integer
            Dim color_ As Color
            Dim sql As String = ""
            sql = "SELECT * FROM  Mas_Status_Alarm WHERE [Status_Alarm_Id]='" & id_ & "'"
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                A = DT.Rows(0).Item("Status_Alarm_Color_A").ToString
                R = DT.Rows(0).Item("Status_Alarm_Color_R").ToString
                G = DT.Rows(0).Item("Status_Alarm_Color_G").ToString
                B = DT.Rows(0).Item("Status_Alarm_Color_B").ToString
            Else
                A = 0
                R = 0
                G = 0
                B = 255
            End If

            color_ = Color.FromArgb(A, R, G, B)

            Return color_
        Catch ex As Exception
            Return Color.FromArgb(A, R, G, B)
        End Try
    End Function
    Sub count_status_Alarm_id(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_no As String)
       Dim sql As String = ""
        sql = " SELECT [Alarm_Id]"
        sql &= " ,count(*) AS count_record"
        sql &= " FROM Q_Mas_Lot"
        sql &= " WHERE HW_Building_ID='" & building_no & "' and Floor_No = '" & floor_no & "' and HW_Floor_No='" & floor_no & "'"
        If zcu_no <> "" Then
            sql &= " and HW_Floorcontroller_Id='" & zcu_no & "' "
        End If
        sql &= " group by [Alarm_Id] "
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        If dt.Rows.Count > 0 Then
            clear_status()
            For i As Integer = 0 To dt.Rows.Count - 1

                Select Case dt.Rows(i).Item("Alarm_Id").ToString
                    Case "0"
                        lbl_Color_Green.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_Green.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "1"
                        lbl_Color_Red.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_Red.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "2"
                        lbl_Color_False.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_False.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "3"
                        lbl_Color_Status1.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_1.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "4"
                        lbl_Color_Status2.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_2.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "5"
                        lbl_Color_Status3.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_3.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "6"
                        lbl_Color_Status4.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_4.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "7"
                        lbl_Color_Status5.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_5.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "8"
                        lbl_Color_Status6.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_6.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "9"
                        lbl_Color_Status7.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_7.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "10"
                        lbl_Color_Status8.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_8.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "11"
                        lbl_Color_Status9.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_9.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "12"
                        lbl_Color_Status10.BackColor = Status_Alarm_Color(dt.Rows(i).Item("Alarm_Id").ToString)
                        lbl_Status_10.Text = Status_Alarm_Name(dt.Rows(i).Item("Alarm_Id").ToString) & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                End Select
            Next
        End If
    End Sub
    Sub clear_status()
        lbl_Color_Green.BackColor = Color.Transparent
        lbl_Status_Green.Text = ""

        lbl_Color_Red.BackColor = Color.Transparent
        lbl_Status_Red.Text = ""

        lbl_Color_False.BackColor = Color.Transparent
        lbl_Status_False.Text = ""

        lbl_Color_Status1.BackColor = Color.Transparent
        lbl_Status_1.Text = ""

        lbl_Color_Status2.BackColor = Color.Transparent
        lbl_Status_2.Text = ""

        lbl_Color_Status3.BackColor = Color.Transparent
        lbl_Status_3.Text = ""

        lbl_Color_Status4.BackColor = Color.Transparent
        lbl_Status_4.Text = ""

        lbl_Color_Status5.BackColor = Color.Transparent
        lbl_Status_5.Text = ""

        lbl_Color_Status6.BackColor = Color.Transparent
        lbl_Status_6.Text = ""

        lbl_Color_Status7.BackColor = Color.Transparent
        lbl_Status_7.Text = ""

        lbl_Color_Status8.BackColor = Color.Transparent
        lbl_Status_8.Text = ""

        lbl_Color_Status9.BackColor = Color.Transparent
        lbl_Status_9.Text = ""

        lbl_Color_Status10.BackColor = Color.Transparent
        lbl_Status_10.Text = ""
    End Sub
    Private Sub T_Alert_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Alert.Tick
        'T_Alert.Enabled = False
        'Call Show_Alert_Parking_Time(Time_Parking_Alert) 'แจ้งเตือนรถจอด เกินจำนวนชั่วโมงที่กำหนด
        'Call Show_Status_Alam_Lot() ' แสดงสถานะ Ultrasonic dgv_Alert_Sensor
        'Call Show_Status_Alam_Normal() ' แสดงสถานะ ข้อความเตือนของระบบบ
        'T_Alert.Enabled = True
    End Sub


    Private Sub Pic_ID_2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Pic_ID_2.MouseClick
        Label2.Text = "X=" & Cursor.Position.X & " ,Y=" & Cursor.Position.Y
        Application.DoEvents()
    End Sub


    Private Sub PanelEx1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PanelEx1.MouseClick
        Label2.Text = "X=" & Cursor.Position.X & " ,Y=" & Cursor.Position.Y
        Application.DoEvents()
    End Sub

    Function Status_Alarm_Name(ByVal id_ As String) As String
        Try
            Dim Name_ As String = ""
            Dim sql As String = ""
            sql = "SELECT * FROM  Mas_Status_Alarm WHERE [Status_Alarm_Id]='" & id_ & "'"
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                Name_ = DT.Rows(0).Item("Status_Alarm_Name").ToString
            Else
                Name_ = ""
            End If
            Return Name_
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Private Sub frmNew_Display_All_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call Timer_False()
        PanelEx2.Visible = False
        menu_floor()
        'CircularProgress1.Visible = False
        'CircularProgress1.Dock = DockStyle.Fill
        PanelEx2.Visible = True
        If Me.Width > 1200 Then
            Dim x_new As Integer = (Me.Width - PanelEx2.Width) / 2
            Dim y_new As Integer = 4
            If Me.Height > 600 Then
                y_new = (PanelEx1.Height - PanelEx2.Height) / 2
            End If
            PanelEx2.Location = New Point(x_new, y_new)
        End If
        If Building_ID = "" Then Building_ID = "1"
        If Floor_No = "" Then Floor_No = "1"

        Load_(Floor_No, Building_ID, ZCU_ID, UD_ID)

        Bar1.Text = "Menu"
        load_text(lang_)
        TimerRealtime.Enabled = True
    End Sub
    Sub load_text(ByVal lang_ As String)
        If lang_ <> "TH" Then
            Label3.Text = "LOTS ALL"
            Label4.Text = "NOT AVAILABLE"
            Label5.Text = "AVAILABLE"
        End If
    End Sub

End Class