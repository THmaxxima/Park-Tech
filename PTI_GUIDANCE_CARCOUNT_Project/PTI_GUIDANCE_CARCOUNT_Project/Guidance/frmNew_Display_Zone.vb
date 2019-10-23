Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frmNew_Display_Zone
    ' Friend Floor_SelectID As String
    Friend Floor_No As String = "1"
    Friend Building_ID As String = "1"
    Friend ZCU_ID As String = ""
    Friend Flag_Start_From As Boolean
    Dim ClsSqlCmd As ClassCommandSql
    Dim Count_Red As Integer
    Dim Count_Green As Integer
    Dim Count As Integer
    Dim A, R, G, B As Integer
    Dim btn(4600) As Label
    Dim lbl_Zone(4500) As Label
    Dim OffLeft As Integer
    Dim OffTop As Integer
    Dim HoldLeft As Integer
    Dim HoldTop As Integer
    Dim Go As Boolean
    Dim LeftSet As Boolean
    Dim TopSet As Boolean
    'Dim FloorID As String = ""
    'Dim Floor_ID As String = ""
    Dim Sensor_Id As String = ""
    Dim Date_Alam_Normal As Date = Now
    Dim Date_Alam As Date = Now
    Dim Status_Alarm_Id = "", Time As String = ""
    Dim index_, I_Index, II_Index As Short
    Dim lbl(4500) As Label
    Dim mFloor As String

    '-----zone ----
    'Dim Go As Boolean
    'Dim LeftSet As Boolean
    'Dim TopSet As Boolean

    'REM These will hold the mouse position
    'Dim HoldLeft As Integer
    'Dim HoldTop As Integer

    REM These will hold the offset of the mouse in the element
    'Dim OffLeft As Integer
    'Dim OffTop As Integer

    Dim select_fore_color As Color
    Dim Fore_Color_A As Integer = 255
    Dim Fore_Color_R As Integer = 255
    Dim Fore_Color_G As Integer = 0
    Dim Fore_Color_B As Integer = 0
    Dim Back_Color_A As Integer = 255
    Dim Back_Color_R As Integer = 0
    Dim Back_Color_G As Integer = 0
    Dim Back_Color_B As Integer = 0
    'Dim A, R, G, B As Integer
    'Dim lbl(100) As Label
    Dim lbl_Z(100) As Label
    Dim Zone_Id As String


    Dim st_Edit As Integer = 0
    Dim st_Insert As Integer = 0
    Dim Selected_arrow As Integer = 0
    Dim selected_ZCU As Integer = 0
    Dim cdb As New CDatabase
    Sub Load_Language()
        If lang_ = "TH" Then
            'Me.Text = ""
            GroupBox4.Text = "เลือกสี"
            Button2.Text = "เลือก"
            lbl_Zone_Name.Text = "ชื่อป้าย"
            lbl_Position_Zone.Text = "ตำแหน่ง"
            lbl_Color_font.Text = "สีตัวอักษร"
            lbl_Back_Ground.Text = "สีพื้นหลัง"
            lbl_Zone_Size.Text = "กว้าง"
            Label12.Text = "สูง"
            lbl_Font_Size.Text = "ขนาดตัวอักษร"
            'Label8.Text = "ติดตั้งที่ ZCU:"

        End If
        If lang_ = "EN" Then
            'Me.Text = ""
            GroupBox4.Text = "SELECT COLOR"
            Button2.Text = "OK"
            lbl_Zone_Name.Text = "Name"
            lbl_Position_Zone.Text = "Position"
            lbl_Color_font.Text = "Font Col."
            lbl_Back_Ground.Text = "Back Col."
            lbl_Zone_Size.Text = "Width"
            Label12.Text = "Height"
            lbl_Font_Size.Text = "Font Size"
            'Label8.Text = "At ZCU:"
        End If
    End Sub
    Private Sub frmNew_Display_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerRealtime.Enabled = False
        T_Alert.Enabled = False
    End Sub

    Private Sub frmNew_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Timer_False()
        PanelEx2.Visible = False
        Application.DoEvents()

        If Building_ID = "" Then Building_ID = "1"
        If Floor_No = "" Then
            Floor_No = "1"
            Load_(Floor_No, Building_ID, ZCU_ID)
        Else
            Load_(Floor_No, Building_ID, ZCU_ID)
        End If

        If Me.Width > 1200 Then
            Dim x_new As Integer = (Me.Width - PanelEx2.Width) / 2
            Dim y_new As Integer = 4
            If Me.Height > 600 Then
                y_new = (PanelEx1.Height - PanelEx2.Height) / 2
            End If
            PanelEx2.Location = New Point(x_new, y_new)
        End If
        PanelEx2.Visible = True
        menu_floor()


     

        Application.DoEvents()

        Load_Language()
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
                            .Name = dt.Rows(ii).Item("Building_ID").ToString & "_" & dt.Rows(ii).Item("Floor_ID").ToString & "_" & dt.Rows(ii).Item("Floor_No").ToString
                            .Text = dt.Rows(ii).Item("Floor_Name").ToString
                            If ii = 0 Then .Checked = True Else .Checked = False
                            .BackColor = Color.Transparent
                            .Location = New Point(RadioButton1.Location.X + i, RadioButton1.Location.Y)
                            AddHandler .Click, AddressOf Me.ButtonFloor_Click

                            PanelDockContainer1.Controls.Add(rd)
                            .BringToFront()
                            Application.DoEvents()
                        End With
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("menu_floor:" & ex.Message)
            Call mError.ShowError(Me.Name, "menu_floor", Err.Number, Err.Description)
        End Try

    End Sub
    Private Sub ButtonFloor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim a() As String = sender.name.ToString.Split("_")
            Building_ID = a(0)
            'Floor_SelectID = a(1)
            Floor_No = a(2)
            Load_(Floor_No, Building_ID, ZCU_ID)
            Application.DoEvents()
        Catch ex As Exception
            MsgBox("ButtonFloor_Click :" & ex.Message)
            Call mError.ShowError(Me.Name, "ButtonFloor_Click", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Load_(ByVal floorNo As String, ByVal building_no As String, ByVal zcu_no As String)

        'AddCombo(ConnStrMasTer, Me.cmb_Tower, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")
        ' Call Load_List_Zone(Floor_No, Building_ID)
        User_Level = 9
        ' lbl_EXC.Location = New Point(365, 33)
        If User_Level <> "9" Then
            btn_Add.Visible = False
            btn_Delete.Visible = False
        End If


        Call Tab_Floor_Name(Floor_No, building_no) '###  Step 1 แสดงชื่อชั้นจอดรถ ทุกชั้น แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor(Floor_No) '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        'Call Load_Button_New(Floor_No, building_no) '###  Step 3 Load Ultrasonic มาแสดง
        Call Load_Board_Zone(Floor_No, Building_ID)


        Defaulf_Object()
    End Sub

   


    


    Sub Timer_True()
        TimerRealtime.Enabled = True
    End Sub
    Sub Timer_False()
        TimerRealtime.Enabled = False

    End Sub

    Sub Tab_Floor_Name(ByVal floor_no As String, ByVal buiding As String) 'ชื่อของชั้นของแท็บ

        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT [Floor_ID]"
            sql &= ",[Tower_ID]"
            sql &= ",[Building_ID]"
            sql &= ",(SELECT TOP 1 [Building_Name] FROM [Mas_Building_Parking] WHERE [Mas_Building_Parking].[Building_ID] = Mas_Floor.[Building_ID]) as Building_Name"
            sql &= ",[Floor_No]"
            sql &= ",[Floor_Name] "
            sql &= ",[Floor_Lot_All] "
            sql &= ",[Floor_Lot_Empty] "
            sql &= ",[Floor_Lot_Parking] "
            sql &= " FROM Mas_Floor "
            sql &= " WHERE [Floor_No]='" & floor_no & "' and [Building_ID]='" & buiding & "'"
            sql &= " ORDER BY Building_ID, Floor_Id "


            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                Me.Text = DT.Rows(0).Item("Building_Name").ToString & " - " & DT.Rows(0).Item("Floor_Name").ToString
                Lb_status_lot_all.Text = DT.Rows(0).Item("Floor_Lot_All").ToString
                Lb_status_lot_avalaible.Text = DT.Rows(0).Item("Floor_Lot_Empty").ToString
                Lb_status_lot_use.Text = DT.Rows(0).Item("Floor_Lot_Parking").ToString
            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "", Err.Number, Err.Description)
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
                For i As Integer = 0 To DT.Rows.Count - 1
                    'Tab_Building.Controls.Item(0).Tag = DT.Rows(i).Item("Building_ID").ToString.Trim
                    'Tab_Building.Controls.Item(0).Text = DT.Rows(i).Item("Building_Name").ToString.Trim
                    'Tab_Building.Tabs(Tab_Building.Controls.Item(0).Tag - 1).Visible = False
                Next
            End If
            'Tab_Building.SelectedTabIndex = Tab_Building.Controls.Item(0).Tag - 1

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงรายการ Tab อาคารจอดรถ ", Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub mouse_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn_ As Label = sender
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
            ' Floor_SelectID = "2"
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

        'maxx 20151014 ถูกกำหนดค่าด้านบนแล้ว(Public_Floor_ID เท่ากับค่าว่าง ทำให้คิวรี่ข้อมูลไม่ได้ค่า เลขที่ชั้น)
        'Public_Floor_NO = "" & Cout_by_Condition(ConnStrMasTer, "select Floor_No from Mas_Floor where Floor_Id = " & Public_Floor_ID & " and Building_ID = " & Public_Building_ID & "", "Floor_No")

        'Call Floor_Name_In_Other_Floor(Public_Building_ID, Public_Floor_NO) 'ชื่อของชั้นอื่น
        ''Call Select_Color_Status_Alam_Value(Public_Floor_NO, Public_Building_ID) 'แสดงสีตามประเภทการจอด และ จำนวน
        'Call Value_In_Zone(Public_Building_ID, Public_Floor_NO) 'จำนวนรถว่างในแต่ละโซน

        ''maxx 20151014
        'Call Update_Color_Alam_ID(Public_Building_ID, Public_Floor_NO) 'set สีสถานะการจอดรถ
        ''maxx 20151014 ทำให้การแสดงผลสีการจอดผิดพลาด
        'Call Set_Color_btn(Public_Building_ID, Public_Floor_NO) ' Set สี การจอดรถตามชั่วโมงจอด

        TimerRealtime.Enabled = True
    End Sub

    Sub Load_Board_Zone_Display_Value()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        '  Dim i As Integer
        Try
            'For i = 1 To mFloor
            sql = "SELECT * FROM [V_MAS_Display_Config_Data] WHERE [Display_Type] not in('Main','MAIN') order by [ID_Display] "
            sql &= "  order by ID_Display    "
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
                                .Name = "lbl" & rs.Fields("ID_Display").Value  'ชื่อ button
                                .Tag = rs.Fields("Zone_Id").Value
                                Dim Value_Zone As String = mCountCar.Get_Count_CarInZone(rs.Fields("ID_Display").Value, rs.Fields("Zone_Floor_No").Value, rs.Fields("Zone_Building_ID").Value)
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
    Sub Show_Picture_Floor(ByVal floor_id As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        Pic_ID_2.Controls.Clear()

        sql = "Select Floor_Image,Floor_Id from Mas_Floor WHERE Floor_Id = '" & floor_id & "' "

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
            sql &= " where HW_Building_ID = '" & BuildingID & "'"
            sql &= " and HW_Floor_No =  '" & FloorNO & "'"
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
   

    Sub Load_Button_New(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_id As String)

        Dim PositionX As Integer = 20 ' X not < 750 20
        Dim PositionY As Integer = 26 ' 26
        Dim sql As String = ""
        Dim i As Short = 0
        I_Index = 0

        Try

            sql = " SELECT distinct HW_Lot_Id,HW_Status_Id,HW_Position_X,HW_Position_Y,Floor_Name, " & _
                  " Status_Alarm_Color_A, Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B,HW_Lot_Name,Floor_Controller_Name,Status_Name,HW_Floorcontroller_Id "
            sql &= " ,HW_Building_ID,HW_Floor_No "
            sql &= " FROM Q_Mas_Lot "
            sql &= " where HW_Lot_Type='L' and HW_Building_ID='" & building_no & "' and Floor_No = '" & floor_no & "' and HW_Floor_No='" & floor_no & "'"
            If zcu_id <> "" Then
                sql &= " and HW_Floorcontroller_Id ='" & zcu_id & "'"
            End If

            sql &= " order by HW_Lot_Id"

            Dim btn_(500) As Label
            Dim Tag As String = ""
            Dim I_Index As Integer = 0
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then
                For ii As Integer = 0 To DT.Rows.Count - 1
                    If DT.Rows(ii).Item("HW_Position_X").ToString = 0 And DT.Rows(ii).Item("HW_Position_Y").ToString = 0 Then

                    Else
                        btn_(ii) = New Label
                        A = DT.Rows(ii).Item("Status_Alarm_Color_A").ToString
                        R = DT.Rows(ii).Item("Status_Alarm_Color_R").ToString
                        G = DT.Rows(ii).Item("Status_Alarm_Color_G").ToString
                        B = DT.Rows(ii).Item("Status_Alarm_Color_B").ToString

                        With btn_(I_Index)
                            Tag = Mid(DT.Rows(ii).Item("HW_Lot_Id").ToString, 4, 8)
                            .BackColor = Color.FromArgb(A, R, G, B)
                            .Size = New System.Drawing.Size(9, 9)
                            .Location = New System.Drawing.Point(
                                DT.Rows(ii).Item("HW_Position_X").ToString - 10 _
                                , DT.Rows(ii).Item("HW_Position_Y").ToString - 30)
                            .Text = "        " & _
                                "Lot_Id: " & DT.Rows(ii).Item("HW_Lot_Id").ToString & " " & _
                                "Lot_Name: " & DT.Rows(ii).Item("HW_Lot_Name").ToString & " " & _
                                "controller: " & DT.Rows(ii).Item("Floor_Controller_Name").ToString & " " & _
                                "Status: " & DT.Rows(ii).Item("Status_Name").ToString
                            .Tag = Tag
                            .Name = DT.Rows(ii).Item("HW_Lot_Id").ToString
                            AddHandler .Click, AddressOf Me.Button_Click
                            AddHandler .MouseHover, AddressOf Me.mouse_Hover
                            AddHandler .MouseLeave, AddressOf Me.mouse_leave
                            Pic_ID_2.Controls.Add(btn_(I_Index))
                            .BringToFront()
                        End With

                        I_Index = I_Index + 1
                    End If
                Next

            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "เพิ่ม Lot Sensor Error ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub count_status_Alarm_id(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_no As String)
        Dim sql As String = ""

        sql = " SELECT [HW_Status_Alarm_Id]"
        sql &= " ,[Status_Alarm_Name]"
        sql &= " ,[Status_Alarm_Color_A]"
        sql &= " ,[Status_Alarm_Color_R]"
        sql &= " ,[Status_Alarm_Color_G]"
        sql &= " ,[Status_Alarm_Color_B]"
        sql &= " ,count(*) AS count_record"
        sql &= " FROM Q_Mas_Lot"
        sql &= " WHERE HW_Building_ID='" & building_no & "' and Floor_No = '" & floor_no & "' and HW_Floor_No='" & floor_no & "'"
        If zcu_no <> "" Then
            sql &= " and HW_Floorcontroller_Id='" & zcu_no & "' "
        End If
        sql &= " group by [HW_Status_Alarm_Id] "
        sql &= " ,[Status_Alarm_Name]"
        sql &= " ,[Status_Alarm_Color_A]"
        sql &= " ,[Status_Alarm_Color_R]"
        sql &= " ,[Status_Alarm_Color_G]"
        sql &= " ,[Status_Alarm_Color_B]"

        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                A = dt.Rows(i).Item("Status_Alarm_Color_A").ToString
                R = dt.Rows(i).Item("Status_Alarm_Color_R").ToString
                G = dt.Rows(i).Item("Status_Alarm_Color_G").ToString
                B = dt.Rows(i).Item("Status_Alarm_Color_B").ToString

                Select Case dt.Rows(i).Item("HW_Status_Alarm_Id").ToString
                    Case "0"
                        lbl_Color_Green.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_Green.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "1"
                        lbl_Color_Red.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_Red.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "2"
                        lbl_Color_False.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_False.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "3"
                        lbl_Color_Status1.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_1.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "4"
                        lbl_Color_Status2.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_2.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "5"
                        lbl_Color_Status3.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_3.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "6"
                        lbl_Color_Status4.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_4.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "7"
                        lbl_Color_Status5.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_5.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "8"
                        lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_6.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "9"
                        lbl_Color_Status7.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_7.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "10"
                        lbl_Color_Status8.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_8.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "11"
                        lbl_Color_Status9.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_9.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                    Case "12"
                        lbl_Color_Status10.BackColor = Color.FromArgb(A, R, G, B)
                        lbl_Status_10.Text = dt.Rows(i).Item("Status_Alarm_Name").ToString & " " & dt.Rows(i).Item("count_record").ToString & " คัน"
                End Select
            Next
        End If
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

   

    Private Sub btn_Back_Color_Click(sender As System.Object, e As System.EventArgs) Handles btn_Back_Color.Click
        With Dlg_Back_Color
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fColor As String = .Color.Name
                Back_Color_A = .Color.A
                Back_Color_R = .Color.R
                Back_Color_G = .Color.G
                Back_Color_B = .Color.B
                lbl_Back_Color.BackColor = .Color
                lbl(Zone_Id).BackColor = .Color
                ' lbl_EXC.BackColor = .Color
            Else
                lbl_Back_Color.BackColor = Color.Black
                'lbl_EXC.BackColor = Color.Black
                Exit Sub
            End If
        End With
    End Sub
    Private Function Function_New_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max([ID_Display]) from [MAS_Display_Config]"
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

    Sub Update_Zone(ByVal tower_ As String, ByVal buiding_ As String, ByVal floor_no As String)
        Try
        Dim TrnFlg As Boolean
            Dim sql As String = ""
            sql = " UPDATE [dbo].[MAS_Display_Config]"
            sql &= " SET [Display_Name] = '" & txt_Zone_Name.Text & "'"
            'sql &= "       ,[ZCU_Parent] = '" & selected_ZCU & "'"
            sql &= "       ,[Floor_No] = '" & floor_no & "'"
            sql &= "       ,[DP_Position_X] = '" & lbl_LocationX.Text & "'"
            sql &= "       ,[DP_Position_Y] = '" & lbl_LocationY.Text & "'"
            sql &= "       ,[DP_Size_Width] = '" & txt_SizeX.Text & "'"
            sql &= "       ,[DP_Size_Height] ='" & txt_SizeY.Text & "'"
            sql &= "       ,[Building_ID] = '" & buiding_ & "'"
            sql &= "       ,[Tower_ID] = '" & tower_ & "'"
            sql &= "       ,[Font_ColorA] = '" & Fore_Color_A & "'"
            sql &= "       ,[Font_ColorR] = '" & Fore_Color_R & "'"
            sql &= "       ,[Font_ColorG] = '" & Fore_Color_G & "'"
            sql &= "       ,[Font_ColorB] = '" & Fore_Color_B & "'"
            sql &= "       ,[Back_ColorA] = '" & Back_Color_A & "'"
            sql &= "       ,[Back_ColorR] = '" & Back_Color_R & "'"
            sql &= "       ,[Back_ColorG] = '" & Back_Color_G & "'"
            sql &= "       ,[Back_ColorB] = '" & Back_Color_B & "'"
            sql &= "       ,[Font_Size] = '" & txt_Font_Size.Text & "'"
            sql &= "  WHERE ID_Display = '" & lbl_Zone_Id.Text & "'"

        If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                    MsgBox(msg_update(0))
                TrnFlg = False
            Else

                    MsgBox(msg_update(1))
                TrnFlg = False
            End If
        Else
           
        End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Update_Zone", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Save_MAS_Display_Config(ByVal tower_id As String, ByVal buiding_ As String, ByVal floor_no As String)
        Dim I As Object


        Dim sql As String = ""
        Dim sql_Value As String = ""
        Dim TrnFlg As Boolean
 
            TrnFlg = True
        Try

     
            sql &= " INSERT INTO [MAS_Display_Config]"
            sql &= "([ID_Display]"
            sql_Value &= " Values (" & lbl_Zone_Id.Text & ""

            sql &= " ,[Tower_ID]"
            sql_Value &= ",'" & tower_id & "'"

            sql &= ",[Building_ID]"
            sql_Value &= ",'" & buiding_ & "'"

            sql &= ",[Floor_No]"
            sql_Value &= ",'" & floor_no & "'"

            sql &= " ,[Display_Name]"
            sql_Value &= ",'" & txt_Zone_Name.Text & "'"

            sql &= " ,[DP_Position_X]"
            sql_Value &= "," & lbl_LocationX.Text & ""

            sql &= " ,[DP_Position_Y]"
            sql_Value &= "," & lbl_LocationY.Text & ""

            sql &= ",[DP_Size_Width]"
            sql_Value &= "," & txt_SizeX.Text.Trim & ""

            sql &= " ,[DP_Size_Height]"
            sql_Value &= "," & txt_SizeY.Text.Trim & ""

            sql &= ",[Font_ColorA]"
            sql_Value &= "," & Fore_Color_A & ""

            sql &= " ,[Font_ColorR]"
            sql_Value &= "," & Fore_Color_R & ""

            sql &= ",[Font_ColorG]"
            sql_Value &= "," & Fore_Color_G & ""

            sql &= ",[Font_ColorB]"
            sql_Value &= "," & Fore_Color_B & ""

            sql &= ",[Back_ColorA]"
            sql_Value &= "," & Back_Color_A & ""

            sql &= ",[Back_ColorR]"
            sql_Value &= "," & Back_Color_R & ""

            sql &= ",[Back_ColorG]"
            sql_Value &= "," & Back_Color_G & ""

            sql &= ",[Display_Type]"
            sql_Value &= ",'Floor'"

            sql &= ",[Back_ColorB]"
            sql_Value &= "," & Back_Color_B & ""

            'sql &= ",[DP_Direction_ID]"
            'sql_Value &= ",'" & Selected_arrow & "'"

            'sql &= ",[ZCU_Parent]"
            'sql_Value &= ",'" & selected_ZCU & "'"

            sql &= ",[Font_Size])"
            sql_Value &= "," & txt_Font_Size.Text.Trim & ")"

            '#########
            If MsgBox("คุณต้องการบันทึกข้อมูลนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then

                If cdb.ExcuteNoneQury(sql & sql_Value, ConStr_Master) = True Then
                    TrnFlg = False
                    MsgBox(msg_save(0))
                Else
                    MsgBox(msg_save(1))
                End If

            Else
              
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Save_MAS_Display_Config", Err.Number, Err.Description)
        End Try
    End Sub
    Private Sub cmb_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floor.SelectedIndexChanged
        'With lsv_Mas_HW_Floor
        '    lbl_Floor_Id.Text = .FocusedItem.SubItems(0).Text
        '    txt_Floor_Name.Text = .FocusedItem.SubItems(1).Text
        'End With
        If cmb_Floor.SelectedIndex > 0 Then
            Me.Pic_ID_2.Controls.Clear()
            Me.Show_Picture_Floor(cmb_Floor.SelectedValue)
            Call Load_Board_Zone(Floor_No, Building_ID)

            'Call Load_List_Zone(Floor_No, Building_ID)
        End If
    End Sub

    Private Sub btn_Fore_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Fore_Color.Click
        Try

            If PanelEx3.Visible = False Then
                PanelEx3.Visible = True
            Else
                PanelEx3.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        'If cmb_Floor.SelectedIndex <= 0 Then
        '    MsgBox("กรุณาเลือกชั้นที่ต้องการ จัดโซน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
        '    Exit Sub
        'End If

        If btn_Add.Text = "เพิ่ม" Then
            ' lbl_EXC.Visible = True
            btn_Add.Text = "บันทึก"
            lbl_Zone_Id.Text = Me.Function_New_ID()
            NEW_Clear_Direction()

            btn_Back_Color.Enabled = True
            btn_Fore_Color.Enabled = True
            btn_Edit.Enabled = False
            btn_Delete.Enabled = False
            txt_Zone_Name.Enabled = True
            txt_SizeX.Enabled = True
            txt_SizeY.Enabled = True
            txt_Font_Size.Enabled = True
            txt_Zone_Name.Enabled = True


            If txt_SizeX.Text = "" Then
                txt_SizeX.Text = "60"
            End If
            If txt_SizeY.Text = "" Then
                txt_SizeY.Text = "30"
            End If
            txt_Zone_Name.Text = ""
            st_Insert = 1
            Call Add_Page_Zone() 'Add

        ElseIf btn_Add.Text = "บันทึก" Then
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
            'If Selected_arrow = "0" Then
            '    MsgBox("กรุณาเลือกลูกศร ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
            '    Exit Sub
            'End If

            Call Save_MAS_Display_Config("1", Building_ID, Floor_No)
            Call Load_Board_Zone(Floor_No, Building_ID)

            'Call Load_List_Zone(Floor_No, Building_ID)
            txt_Zone_Name.Clear()
            Defaulf_Object()
            btn_Add.Text = "เพิ่ม"
            st_Insert = 0
            lbl_EXC.Visible = False
        End If
    End Sub

    Sub NEW_Clear_Direction()
        For Each A As PictureBox In Panel1.Controls
            A.BackColor = Color.Transparent
        Next
    End Sub

    Sub NEW_Load_Direction(ByVal ID_ As String)
        For Each A As PictureBox In Panel1.Controls
            If A.Tag = ID_ Then
                A.BackColor = Color.Yellow
            Else
                A.BackColor = Color.Transparent
            End If
        Next
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
        'If cmb_Floor.SelectedIndex <= 0 Then
        '    MsgBox("กรุณาเลือกชั้นที่ต้องการ แก้ไข โซน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
        '    Exit Sub
        'End If
        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.Text = "บันทึก"
            btn_Back_Color.Enabled = True
            btn_Fore_Color.Enabled = True
            txt_Zone_Name.Enabled = True
            txt_SizeX.Enabled = True
            txt_SizeY.Enabled = True
            txt_Font_Size.Enabled = True
            st_Edit = 1
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
            Call Update_Zone("1", Building_ID, Floor_No)
            Call Load_Board_Zone(Floor_No, Building_ID)
            'Call Load_List_Zone(Floor_No, Building_ID)
            Call Defaulf_Object()
            st_Edit = 0
        End If
    End Sub

    Private Sub txt_SizeX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SizeX.TextChanged
        Try
            'If txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then
            '    lbl_EXC.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
            'End If

            If lbl_Zone_Id.Text <> "" And txt_SizeX.Text <> "" And txt_SizeY.Text <> "" Then

                For Each lbl As Label In Pic_ID_2.Controls
                    If lbl.Text = lbl_Zone_Id.Text Then
                        lbl.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
                    End If
                Next

                'lbl(lbl_Zone_Id.Text).Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Add_Page_Zone()
        Dim I_Index As Short = 0
        I_Index = lbl_Zone_Id.Text
        If txt_Font_Size.Text = "" Then
            txt_Font_Size.Text = "16"
        End If
       

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
            Me.Pic_ID_2.Controls.Add(lbl_Z(I_Index)) 'เพิ่ม Button


            'lbl_EXC.Location = New Point(365, 33)
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
                Me.Pic_ID_2.Controls.Remove(sender)
            End If
        End If

    End Sub
    Private Sub Button_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            Zone_Id = sender.tag

            sql = " UPDATE [dbo].[MAS_Display_Config]"
            sql &= " SET [Display_Name] = '" & txt_Zone_Name.Text & "'"
            sql &= "       ,[Floor_No] = '" & Floor_No & "'"
            sql &= "       ,[DP_Position_X] = '" & lbl_LocationX.Text & "'"
            sql &= "       ,[DP_Position_Y] = '" & lbl_LocationY.Text & "'"
            sql &= "  WHERE ID_Display = '" & lbl_Zone_Id.Text & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                Direction_Select = ""
                MsgBox("update successs")
            End If
            Call Select_Detail_Board(sender.tag)
        End If

        'Label1.Text = "ID : " & HW_Current_ID.Name
        'Label3.Text = "Building ID : " & Building_ID

       
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
            Zone_Id = sender.tag
            Call Select_Detail_Board(sender.tag)
        End If
    End Sub

    Sub Select_Detail_Board(ByVal id_ As String)
      
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            'Picture_Floor.Controls.Clear()
            sql = "SELECT * " & _
                  "FROM MAS_Display_Config where ID_Display ='" & id_ & "'"

            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)

            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    lbl_Zone_Id.Text = id_
                    txt_Zone_Name.Text = DT.Rows(i).Item("Display_Name").ToString
                    txt_SizeX.Text = DT.Rows(i).Item("DP_Size_Width").ToString
                    txt_SizeY.Text = DT.Rows(i).Item("DP_Size_Height").ToString
                    txt_Font_Size.Text = DT.Rows(i).Item("Font_Size").ToString
                    Back_Color_A = DT.Rows(i).Item("Back_ColorA").ToString
                    Back_Color_R = DT.Rows(i).Item("Back_ColorR").ToString
                    Back_Color_G = DT.Rows(i).Item("Back_ColorG").ToString
                    Back_Color_B = DT.Rows(i).Item("Back_ColorB").ToString

                    lbl_Back_Color.BackColor = Color.FromArgb(Back_Color_A, Back_Color_R, Back_Color_G, Back_Color_B)
                    Fore_Color_A = DT.Rows(i).Item("Font_ColorA").ToString
                    Fore_Color_R = DT.Rows(i).Item("Font_ColorR").ToString
                    Fore_Color_G = DT.Rows(i).Item("Font_ColorG").ToString
                    Fore_Color_B = DT.Rows(i).Item("Font_ColorB").ToString
                    lbl_Fore_Color.BackColor = Color.FromArgb(Fore_Color_A, Fore_Color_R, Fore_Color_G, Fore_Color_B)

                    If DT.Rows(i).Item("DP_Direction_ID").ToString <> "" Then
                        Selected_arrow = DT.Rows(i).Item("DP_Direction_ID").ToString
                        NEW_Load_Direction(Selected_arrow)
                    Else
                        NEW_Clear_Direction()
                    End If

                    'selected_ZCU = DT.Rows(i).Item("ZCU_Parent").ToString
                    If DT.Rows(i).Item("DP_Color").ToString = "1" Then
                        RD_Red.Checked = True
                    End If
                    If DT.Rows(i).Item("DP_Color").ToString = "2" Then
                        RD_Green.Checked = True
                    End If
                    If DT.Rows(i).Item("DP_Color").ToString = "3" Then
                        RD_Yellow.Checked = True
                    End If

                Next
            End If
            ' lbl_EXC.Location = New Point(365, 33)
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
            'txt_Zone_Name.Text = sender.name
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
    Sub Load_Board_Zone(ByVal floor_No As String, ByVal Building_ID As String)
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            Pic_ID_2.Controls.Clear()
            sql = "SELECT * " & _
                  "FROM [V_MAS_Display_Config_Data] where Floor_No ='" & floor_No & "' and Building_ID='" & Building_ID & "' and [Display_Type] not in('Main','MAIN')  order by ID_Display"
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
                                .Text = rs.Fields("ID_Display").Value 'Zone_Name
                                .Font = New Font("7 Segment", CInt(rs.Fields("Font_Size").Value), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                .Cursor = Cursors.Hand
                                .TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("Back_ColorA").Value, rs.Fields("Back_ColorR").Value, rs.Fields("Back_ColorG").Value, rs.Fields("Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("Font_ColorA").Value, rs.Fields("Font_ColorR").Value, rs.Fields("Font_ColorG").Value, rs.Fields("Font_ColorB").Value)
                                .Location = New Point(rs.Fields("DP_Position_X").Value, rs.Fields("DP_Position_Y").Value)
                                .Parent = Me
                                .ContextMenuStrip = CMenu_UID
                                AddHandler .Click, AddressOf Me.Button_Click
                                AddHandler .MouseDoubleClick, AddressOf Me.Button_DoubleClick
                                AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                                AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                                AddHandler .MouseUp, AddressOf nodebtn_MouseUp
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
        Try
            'If txt_SizeX.Text <> "" And txt_SizeY.Text <> "" And IsNumeric(txt_SizeX.Text) = True And IsNumeric(txt_SizeY.Text) = True Then
            '    lbl_EXC.Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
            'End If
            If Val(txt_SizeY.Text) > 0 And txt_SizeY.Text.Trim <> "" And lbl_Zone_Id.Text <> "" Then


                lbl_Z(lbl_Zone_Id.Text).Size = New Size(CInt(txt_SizeX.Text), CInt(txt_SizeY.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_Font_Size_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Font_Size.TextChanged
        If txt_Font_Size.Text <> "" And IsNumeric(txt_Font_Size.Text) = True Then
            'lbl_EXC.Font = New Font("7 Segment", CInt(txt_Font_Size.Text), FontStyle.Regular)
            For Each lbl As Label In Pic_ID_2.Controls
                If lbl.Name = lbl_Zone_Id.Text Then
                    lbl.Font = New Font("7 Segment", CInt(txt_Font_Size.Text), FontStyle.Regular)
                End If
            Next

            'lbl_Z(lbl_Zone_Id.Text).Font = New Font("7 Segment", CInt(txt_Font_Size.Text), FontStyle.Regular)
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        Dim sql As String = ""

        If lbl_Zone_Id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Title_Error)
            Exit Sub
        End If

        On Error GoTo Err
        ' Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From MAS_Display_Config WHERE ID_Display = '" & lbl_Zone_Id.Text & "'"


        If MsgBox("คุณต้องการ ลบข้อมูล รหัส : " & lbl_Zone_Id.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Confirm) = MsgBoxResult.Yes Then
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                sql = " DELETE From MAS_Display_Config_Detail WHERE ID_Display = '" & lbl_Zone_Id.Text & "'"
                If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then

                Else
                    ' MsgBox(msg_delete(1))
                    ' Exit Sub
                End If
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
                Exit Sub
            End If
        End If
        ' Call Load_List_Zone(Floor_No, Building_ID)
        Call Load_Board_Zone(Floor_No, Building_ID)

        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "btn_Delete_Click", Err.Number, Err.Description)
        'Call Load_List_Zone(Floor_No, Building_ID)
    End Sub

    Private Sub Lsv_Zone_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lsv_Zone.MouseClick
        Try
            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim sql As String
            sql = "SELECT * FROM Mas_Floor_Zone where Zone_Id = " & Lsv_Zone.FocusedItem.SubItems(0).Text & ""
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
                        txt_Zone_Name.Text = rs.Fields("Zone_Name").Value
                        lbl_LocationX.Text = rs.Fields("Zone_PositionX").Value
                        lbl_LocationY.Text = rs.Fields("Zone_PositionY").Value
                        ' cmb_Floor.SelectedValue = rs.Fields("Floor_Id").Value
                        txt_SizeX.Text = rs.Fields("Zone_SizeX").Value
                        txt_SizeY.Text = rs.Fields("Zone_SizeY").Value
                        lbl_Fore_Color.BackColor = Color.FromArgb(rs.Fields("Zone_Font_ColorA").Value, rs.Fields("Zone_Font_ColorR").Value, rs.Fields("Zone_Font_ColorG").Value, rs.Fields("Zone_Font_ColorB").Value)
                        lbl_Back_Color.BackColor = Color.FromArgb(rs.Fields("Zone_Back_ColorA").Value, rs.Fields("Zone_Back_ColorR").Value, rs.Fields("Zone_Back_ColorG").Value, rs.Fields("Zone_Back_ColorB").Value)
                        txt_Font_Size.Text = rs.Fields("Font_Size").Value

                        'cboMAS_Display_Mode.SelectedValue = rs.Fields("DP_Mode_ID").Value
                        'cboMAS_Display_Color_Font.SelectedValue = rs.Fields("DP_Color_Font_ID]").Value
                        'cboMAS_Display_Color_Arrow.SelectedValue = rs.Fields("DP_Color_Arrow_ID").Value
                        'cboMAS_Display_Direction.SelectedValue = rs.Fields("DP_Direction_ID").Value
                        'cboMAS_Display_Font_Style.SelectedValue = rs.Fields("DP_Font_Style_ID").Value

                    End If
                End With
            End If
            rs = Nothing


        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Lsv_Zone_MouseClick", Err.Number, Err.Description)
            Exit Try
        End Try

    End Sub

    Private Sub Lsv_Zone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lsv_Zone.SelectedIndexChanged

    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click

        Call Load_Board_Zone(Floor_No, Building_ID)

        'Call Load_List_Zone(Floor_No, Building_ID)
        Defaulf_Object()
        'lbl_EXC.Location = New Point(365, 33)
        'lbl_EXC.Visible = False
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


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If lbl_Zone_Id.Text <> "" Then
            Dim frm As New Frm_Display_Detail
            With frm
                .buiding_id = Building_ID
                .floor_No = Floor_No
                .Display_id = lbl_Zone_Id.Text
                .Show()
                '.Dispose()
            End With
        End If
    End Sub

    Private Sub PB1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB1.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 1
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB2.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 2
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB3.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 3
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB4_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB4.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 4
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB5_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB5.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 5
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB6_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB6.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 6
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB7_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB7.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 7
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub PB8_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PB8.MouseClick
        If st_Edit = 1 Or st_Insert = 1 Then
            Selected_arrow = 8
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        PanelEx3.Visible = False
        Application.DoEvents()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If RD_Green.Checked = True Then
            select_fore_color = Color.Lime
        End If
        If RD_Red.Checked = True Then
            select_fore_color = Color.Red
        End If
        If RD_Yellow.Checked = True Then
            select_fore_color = Color.Yellow
        End If
        Dlg_Fore_Collor.Color = select_fore_color
        Dim fColor As String = Dlg_Fore_Collor.Color.Name
        Fore_Color_A = Dlg_Fore_Collor.Color.A
        Fore_Color_R = Dlg_Fore_Collor.Color.R
        Fore_Color_G = Dlg_Fore_Collor.Color.G
        Fore_Color_B = Dlg_Fore_Collor.Color.B
        lbl_Fore_Color.BackColor = Dlg_Fore_Collor.Color
        lbl_EXC.ForeColor = Dlg_Fore_Collor.Color
        ' lbl(Zone_Id).ForeColor = Dlg_Fore_Collor.Color
        PanelEx3.Visible = False
    End Sub

 
    Private Sub ลบUDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ลบUDToolStripMenuItem.Click
        'DETAIL 
        ' cast sender to menuitem
        Dim mi = CType(sender, ToolStripMenuItem)
        ' cast mi.Owner to CMS
        Dim cms = CType(mi.Owner, ContextMenuStrip)

        MsgBox(cms.SourceControl.Name)

        'btn_Delete_Click(e, Nothing)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'DETAIL 
        ' cast sender to menuitem
        Dim mi = CType(sender, ToolStripMenuItem)
        ' cast mi.Owner to CMS
        Dim cms = CType(mi.Owner, ContextMenuStrip)
        'MsgBox(cms.SourceControl.Name)

        Call Select_Detail_Board(cms.SourceControl.Name)

        If lbl_Zone_Id.Text <> "" Then
            Dim frm As New Frm_Display_Detail
            With frm
                .buiding_id = Building_ID
                .floor_No = Floor_No
                .Display_id = lbl_Zone_Id.Text
                .Show()
                '.Dispose()
            End With
        End If
    End Sub
End Class