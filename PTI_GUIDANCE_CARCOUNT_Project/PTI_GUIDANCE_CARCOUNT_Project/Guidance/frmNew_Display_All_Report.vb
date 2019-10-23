Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic



Public Class frmNew_Display_All_Report
    Friend Floor_No As String = "1"
    Friend Building_ID As String = "1"
    Friend ZCU_ID As String = ""
    Friend pHeader_Detail As String = ""
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

    'get the screenshot
    Dim memoryImage As System.Drawing.Bitmap
    Dim DT_count_car As DataTable
    Dim val_min As Integer
    Dim val_max As Integer
    '------- value length of fequency and  parking time---------
    Dim part_A(2) As Integer
    Dim part_B(2) As Integer
    Dim part_C(2) As Integer
    Dim part_D(2) As Integer


    Dim max_ As Integer
    Dim val_per_part As Double = 0.0
    Dim pAlarm_id As Integer = 0

    Dim label_(500) As Label
    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Public Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
 ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Integer) As Long
    End Function
   

    Private Sub frmNew_Display_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerRealtime.Enabled = False
        T_Alert.Enabled = False
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
            Load_(Floor_No, Building_ID, ZCU_ID)
            Application.DoEvents()
            ' End If
            ' TimerRealtime.Enabled = True
            ' Else
            'check_click = 1
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Load_(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_no As String)
        Call Show_Tab_Building(building_no) ' First Step แสดงเฉพาะ โหลดครั้งแรก
        Call Tab_Floor_Name(floor_no, building_no) '###  Step 1 แสดงชื่อชั้นจอดรถ ทุกชั้น แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor(floor_no) '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Call Load_Board_Zone(floor_no, Building_ID)
        'Call Load_Button_New(floor_no, building_no, zcu_no) '###  Step 3 Load Ultrasonic มาแสดง
    End Sub

    Sub Timer_True()
        TimerRealtime.Enabled = True

    End Sub
    Sub Timer_False()
        TimerRealtime.Enabled = False

    End Sub

    Sub Show_Floor()

        ' Call DisPlay_Status_In_Floor()


        'Call Value_In_Zone() 'จำนวนรถว่างในแต่ละโซน

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
                'Lb_status_lot_all.Text = DT.Rows(0).Item("Floor_Lot_All").ToString
                'Lb_status_lot_avalaible.Text = DT.Rows(0).Item("Floor_Lot_Empty").ToString
                'Lb_status_lot_use.Text = DT.Rows(0).Item("Floor_Lot_Parking").ToString
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
                .date_st = DT_St.Value
                .date_end = DT_End.Value
                .CheckBox2.Checked = False
                .ShowDialog()
                .Dispose()
            End With
        End If
        Timer_True()
    End Sub
    Private Sub mouse_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn_ As PictureBox

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
        'Call update_Button_New_load(Pic_ID_2)
        'Call count_status_Alarm_id(Floor_No, Building_ID, ZCU_ID)
        'Call Tab_Floor_Name(Floor_No, Building_ID)
        'Call update_Display_New()
        Application.DoEvents()
        TimerRealtime.Enabled = True

    End Sub



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
    Sub Load_Button_New_Parking_Time(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_id As String)
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
            sql &= " order by HW_Lot_Id"


            Dim Tag As String = ""
            Dim I_Index As Integer = 0
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then
                part_A(2) = 0
                part_B(2) = 0
                part_C(2) = 0
                part_D(2) = 0
                Application.DoEvents()
                With PictureBox1
                    .Visible = True
                    .Width = Pic_ID_2.Width
                    .Height = Pic_ID_2.Height
                End With
                With CircularProgress1
                    .Maximum = 100
                    .BackColor = Color.Transparent
                    .Location = New Point((Me.Width / 2) - (.Width / 2), (Me.Height / 2) - (.Height / 2) - 50)
                    .Visible = True
                End With


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
                            'Dim Alarm_id As Integer = DT.Rows(ii).Item("Alarm_Id").ToString
                            'count_alarm_id(Alarm_id)
                            Tag = Mid(DT.Rows(ii).Item("HW_Lot_Id").ToString, 4, 8)
                            Dim txt_count_ As Integer = 0
                            pAlarm_id = Car_from_COUNT_car(DT.Rows(ii).Item("HW_Lot_Id").ToString, txt_count_)
                            'Dim img_ As Image = Car_from_COUNT_car(DT.Rows(ii).Item("HW_Lot_Id").ToString, txt_count_)

                            'Add_Control_picture(pg_box, name_, location_x, location_y, Tag, img_, direction)
                            Add_Control(pg_box, name_, location_x, location_y, Tag, pAlarm_id, direction)
                            With pg_box
                                .Text = "        " & _
                                     " Lot_Id : " & DT.Rows(ii).Item("HW_Lot_Id").ToString & " " & _
                                     " Lot_Name : " & DT.Rows(ii).Item("HW_Lot_Name").ToString & " " & _
                                     " controller : " & DT.Rows(ii).Item("Floor_Controller_Name").ToString & " " & _
                                     " [Total Parking Time : " & txt_count_ & " HOUR]"
                                AddHandler .Click, AddressOf Me.Button_Click
                                AddHandler .MouseHover, AddressOf Me.mouse_Hover
                                AddHandler .MouseLeave, AddressOf Me.mouse_leave
                                Pic_ID_2.Controls.Add(pg_box)
                                .BringToFront()
                            End With
                        End If

                    End If
                    CircularProgress1.Value = (DT.Rows.Count / 100) * ii
                    Application.DoEvents()
                Next
                Application.DoEvents()
                PictureBox1.Visible = False
                CircularProgress1.Visible = False

                Application.DoEvents()
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Button_New_Parking_Time", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Load_Button_New_fequency(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_id As String)
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
            sql &= " order by HW_Lot_Id"


            Dim Tag As String = ""
            Dim I_Index As Integer = 0
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then
                part_A(2) = 0
                part_B(2) = 0
                part_C(2) = 0
                part_D(2) = 0

                Application.DoEvents()
                With PictureBox1
                    .Visible = True
                    .Width = Pic_ID_2.Width
                    .Height = Pic_ID_2.Height
                End With
                With CircularProgress1
                    .Maximum = 100
                    .BackColor = Color.Transparent
                    .Location = New Point((Me.Width / 2) - (.Width / 2), (Me.Height / 2) - (.Height / 2) - 50)
                    .Visible = True
                End With


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
                            Dim txt_count_ As Integer = 0
                            ' Dim img_ As Image = Car_from_COUNT_car_fequency(DT.Rows(ii).Item("HW_Lot_Id").ToString, txt_count_)

                            pAlarm_id = Car_from_COUNT_car_fequency(DT.Rows(ii).Item("HW_Lot_Id").ToString, txt_count_)
                            'Add_Control_picture(pg_box, name_, location_x, location_y, Tag, img_, direction)
                            Add_Control(pg_box, name_, location_x, location_y, Tag, pAlarm_id, direction)

                            With pg_box
                                .Text = "        " & _
                                     "Lot_Id: " & DT.Rows(ii).Item("HW_Lot_Id").ToString & " " & _
                                     "Lot_Name: " & DT.Rows(ii).Item("HW_Lot_Name").ToString & " " & _
                                     "controller: " & DT.Rows(ii).Item("Floor_Controller_Name").ToString & " " & _
                                     "Count Car: " & txt_count_ & " Car"

                                AddHandler .Click, AddressOf Me.Button_Click
                                AddHandler .MouseHover, AddressOf Me.mouse_Hover
                                AddHandler .MouseLeave, AddressOf Me.mouse_leave
                                Pic_ID_2.Controls.Add(pg_box)
                                .BringToFront()
                            End With
                        End If

                    End If
                    CircularProgress1.Value = (DT.Rows.Count / 100) * ii
                    Application.DoEvents()
                Next
                Application.DoEvents()
                PictureBox1.Visible = False
                CircularProgress1.Visible = False

                Application.DoEvents()
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Button_New_fequency", Err.Number, Err.Description)
        End Try
    End Sub


  
    Sub count_car_fequency(ByVal dt_st As DateTime, ByVal dt_end As DateTime, ByVal buiding_id As String, ByVal floor_no As String)
        Dim sql As String = ""
        Dim sql_min As String = ""
        Dim sql_max As String = ""
        Try
            sql = "SELECT Trn_Lot_Id,Count(*) as Count_ FROM U_Transaction_Lot "
            sql &= "WHERE Trn_Log_Date between '" & cdb.GetDateToDB(dt_st) & "' and '" & cdb.GetDateToDB(dt_end) & "'"
            sql &= " and Trn_Building_ID = '" & buiding_id & "' and Trn_Floor_No='" & floor_no & "'"
            sql &= " group by Trn_Lot_Id"
            DT_count_car = cdb.readTableData(sql, ConStr_Guidance)

            sql_min = "SELECT MIN(T.Count_) from (" & sql & ") AS T"
            Dim DT_min As DataTable = cdb.readTableData(sql_min, ConStr_Guidance)
            val_min = DT_min.Rows(0).Item(0).ToString

            sql_max = "SELECT MAX(T.Count_) from (" & sql & ") AS T"
            Dim DT_max As DataTable = cdb.readTableData(sql_max, ConStr_Guidance)
            val_max = DT_max.Rows(0).Item(0).ToString

            max_ = val_max - val_min

            val_per_part = (max_ / 4).ToString("F2")
            'Math.Ceiling ปัดเศษขึ้นหมด
            val_per_part = Math.Ceiling(val_per_part)
            part_A(0) = val_min
            part_A(1) = part_A(0) + val_per_part

            part_B(0) = part_A(1) + 1
            part_B(1) = part_B(0) + val_per_part

            part_C(0) = part_B(1) + 1
            part_C(1) = part_C(0) + val_per_part

            part_D(0) = part_C(1) + 1
            part_D(1) = part_D(0) + val_per_part

            'L1.Text = part_A(0) & " - " & part_A(1) & "  ครั้ง"
            'L2.Text = part_B(0) & " - " & part_B(1) & "  ครั้ง"
            'L3.Text = part_C(0) & " - " & part_C(1) & "  ครั้ง"
            'L4.Text = part_D(0) & " - " & part_D(1) & "  ครั้ง"
        Catch ex As Exception
            MsgBox("count_car :" & ex.Message)
        End Try
    End Sub

    Sub count_car_parking_time(ByVal dt_st As DateTime, ByVal dt_end As DateTime, ByVal buiding_id As String, ByVal floor_no As String)
        Dim sql As String = ""
        Dim sql_min As String = ""
        Dim sql_max As String = ""
        Try
            sql = "SELECT Trn_Lot_Id,ISNULL(SUM(dbo.Get_Diff_Hour(Trn_Log_Datetime_In, Trn_Log_Datetime_Out)) + CEILING((SUM(dbo.Get_Diff_Minute(Trn_Log_Datetime_In, Trn_Log_Datetime_Out)))/60.0),0) AS sum_Parking_time  FROM U_Transaction_Lot "
            sql &= "WHERE Trn_Log_Date between '" & cdb.GetDateToDB(dt_st) & "' and '" & cdb.GetDateToDB(dt_end) & "'"
            sql &= " and Trn_Building_ID = '" & buiding_id & "' and Trn_Floor_No='" & Floor_No & "'"
            sql &= " group by Trn_Lot_Id"
            DT_count_car = cdb.readTableData(sql, ConStr_Guidance)

            sql_min = "SELECT MIN(ISNULL(T.sum_Parking_time,0)) from (" & sql & ") AS T"
            Dim DT_min As DataTable = cdb.readTableData(sql_min, ConStr_Guidance)
            val_min = DT_min.Rows(0).Item(0).ToString

            sql_max = "SELECT MAX(ISNULL(T.sum_Parking_time,0)) from (" & sql & ") AS T"
            Dim DT_max As DataTable = cdb.readTableData(sql_max, ConStr_Guidance)
            val_max = DT_max.Rows(0).Item(0).ToString

            max_ = val_max - val_min



            val_per_part = (max_ / 4).ToString("F2")

            '---------- ทำให้เป็น ชม. -----
            'val_per_part = val_per_part / 60

            'Math.Ceiling ปัดเศษขึ้นหมด
            val_per_part = Math.Ceiling(val_per_part)

            part_A(0) = val_min
            part_A(1) = part_A(0) + val_per_part

            part_B(0) = part_A(1) + 1
            part_B(1) = part_B(0) + val_per_part

            part_C(0) = part_B(1) + 1
            part_C(1) = part_C(0) + val_per_part

            part_D(0) = part_C(1) + 1
            part_D(1) = part_D(0) + val_per_part

            'L1.Text = part_A(0) & " - " & part_A(1) & "  ชั่วโมง"
            'L2.Text = part_B(0) & " - " & part_B(1) & "  ชั่วโมง"
            'L3.Text = part_C(0) & " - " & part_C(1) & "  ชั่วโมง"
            'L4.Text = part_D(0) & " - " & part_D(1) & "  ชั่วโมง"
        Catch ex As Exception
            MsgBox("count_car_parking_time :" & ex.Message)
        End Try
    End Sub

    Function Car_from_COUNT_car(ByVal lot_id As String, ByRef return_count As Integer) As Integer
        Try
            Dim pg_ As Image = lot_size_image

            Dim matches = From row In DT_count_car
                  Let SortCode = row.Field(Of String)("Trn_Lot_Id")
                  Where SortCode = lot_id
            If matches.Any() Then
                Dim row = matches(0).row.Item(1).ToString
                If row = "" Then
                    return_count = 0
                Else
                    return_count = row
                End If

                If row <= 0 Then
                    pAlarm_id = 0
                    return_count = 0
                    pg_ = lot_size_image
                Else
                    If row >= part_A(0) And row <= part_A(1) Then
                        pAlarm_id = 1
                        part_A(2) = part_A(2) + 1
                    End If
                    If row >= part_B(0) And row <= part_B(1) Then
                        pAlarm_id = 3
                        part_B(2) = part_B(2) + 1
                    End If
                    If row >= part_C(0) And row <= part_C(1) Then
                        pAlarm_id = 4
                        part_C(2) = part_C(2) + 1
                    End If
                    If row >= part_D(0) And row <= part_D(1) Then
                        pAlarm_id = 5
                        part_D(2) = part_D(2) + 1
                    End If
                End If

                'Dim RetByte() As Byte = CType(alarm_pic(pAlarm_id), Byte())
                'Dim PictureData() As Byte = RetByte
                'Dim Ms As New System.IO.MemoryStream(PictureData)
                'pg_ = Image.FromStream(Ms)

            Else
                'Dim RetByte() As Byte = CType(alarm_pic(0), Byte())
                'Dim PictureData() As Byte = RetByte
                'Dim Ms As New System.IO.MemoryStream(PictureData)
                'pg_ = Image.FromStream(Ms)
                return_count = 0
                pg_ = lot_size_image
            End If

            Return pAlarm_id
        Catch ex As Exception
            return_count = 0
            Return pAlarm_id
        End Try
    End Function
    Function Car_from_COUNT_car_fequency(ByVal lot_id As String, ByRef return_count As Integer) As Integer
        Try
            Dim pg_ As Image = lot_size_image
            Dim pAlarm_id As Integer = 0
            Dim matches = From row In DT_count_car
                  Let SortCode = row.Field(Of String)("Trn_Lot_Id")
                  Where SortCode = lot_id

            If matches.Any() Then
                Dim row = matches(0).row.Item(1).ToString
                If row = "" Then
                    return_count = 0
                Else
                    return_count = row
                End If

                If row <= 0 Then
                    pAlarm_id = 0
                    'part_A(2) = part_A(2) + 1
                    return_count = 0
                    pg_ = lot_size_image
                Else
                    If row >= part_A(0) And row <= part_A(1) Then
                        pAlarm_id = 1
                        part_A(2) = part_A(2) + 1
                    End If
                    If row >= part_B(0) And row <= part_B(1) Then
                        pAlarm_id = 3
                        part_B(2) = part_B(2) + 1
                    End If
                    If row >= part_C(0) And row <= part_C(1) Then
                        pAlarm_id = 4
                        part_C(2) = part_C(2) + 1
                    End If
                    If row >= part_D(0) And row <= part_D(1) Then
                        pAlarm_id = 5
                        part_D(2) = part_D(2) + 1
                    End If
                End If
                'Dim RetByte() As Byte = CType(alarm_pic(pAlarm_id), Byte())
                'Dim PictureData() As Byte = RetByte
                'Dim Ms As New System.IO.MemoryStream(PictureData)
                'Car_from_COUNT_car_fequency = Image.FromStream(Ms)
            Else
                return_count = 0
                'pg_ = lot_size_image
            End If
            'Return pg_
            Return pAlarm_id
        Catch ex As Exception
            return_count = 0
            Return pAlarm_id
        End Try
    End Function
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
    
    
    Private Sub T_Alert_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Alert.Tick
        'T_Alert.Enabled = False
        'Call Show_Alert_Parking_Time(Time_Parking_Alert) 'แจ้งเตือนรถจอด เกินจำนวนชั่วโมงที่กำหนด
        'Call Show_Status_Alam_Lot() ' แสดงสถานะ Ultrasonic dgv_Alert_Sensor
        'Call Show_Status_Alam_Normal() ' แสดงสถานะ ข้อความเตือนของระบบบ
        'T_Alert.Enabled = True
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

    Private Sub frmNew_Display_All_Report_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call Timer_False()
        PanelEx2.Visible = False
        'menu_floor()
        'CircularProgress1.Visible = False
        'CircularProgress1.Dock = DockStyle.Fill
        Me.Text = pHeader_Detail
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

        DT_St.Value = CDate(Now.Date & " 00:00:00")
        DT_End.Value = CDate(Now.Date & " 23:59:59")
        'Call Show_Picture_Floor(1) '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Load_Tower(Cmb_Tower)
        Load_floor(Cmb_Floor, Building_ID)
        Show_Picture_Floor(1)
        'Load_Button_New(1, 1, "")
        'TimerRealtime.Enabled = True
        'If RD_Fequency.Checked = True Then
        '    Label1.Text = RD_Fequency.Text
        'Else
        '    Label1.Text = RD_Parking_Time.Text
        'End If

        Label1.Text = Me.Text
    End Sub

    Private Sub CaptureScreen()
        Dim mygraphics As System.Drawing.Graphics = Me.PanelEx2.CreateGraphics()
        Dim s As Size = Me.PanelEx2.Size
        memoryImage = New System.Drawing.Bitmap(s.Width, s.Height, mygraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        Dim dc1 As IntPtr = mygraphics.GetHdc()
        Dim dc2 As IntPtr = memoryGraphics.GetHdc()
        BitBlt(dc2, 0, 0, Me.PanelEx2.ClientRectangle.Width, Me.PanelEx2.ClientRectangle.Height, dc1, _
         0, 0, 13369376)
        mygraphics.ReleaseHdc(dc1)
        memoryGraphics.ReleaseHdc(dc2)

    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        'CaptureScreen()
        Try

       
        Dim mygraphics As System.Drawing.Graphics = Me.Pic_ID_2.CreateGraphics()
        Dim s As Size = Me.Pic_ID_2.Size
            memoryImage = New System.Drawing.Bitmap(Pic_ID_2.Width, Pic_ID_2.Height - 100, mygraphics)

        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
            'Dim ScreenPos As Point = Me.PanelEx2.PointToScreen(New Point(0, 0))
            memoryGraphics.CopyFromScreen(PanelEx2.Location.X, PanelEx2.Location.Y + 40, 0, 0, s)


        If Not File.Exists("test.Bmp") Then
            memoryImage.Save("test.Bmp", System.Drawing.Imaging.ImageFormat.Bmp)
        Else
            File.Delete("test.Bmp")
            memoryImage.Save("test.Bmp", System.Drawing.Imaging.ImageFormat.Bmp)
        End If

        Excute_SQL(ConStr_Master, "delete from Mas_Image_Report ")
        Excute_SQL(ConStr_Master, "insert into Mas_Image_Report(Image_ID) values(1)")
        'PictureBox1.Image = System.Drawing.Image.FromFile("test.bmp")
        Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Image_Report", "Image_ID", "Image_Picture", "1", "test")
            With Frm_print
                .pHeader_Detail = Me.Text
                .dt_st = DT_St.Value
                .dt_end = DT_End.Value
                .Text_detail = "Tower : " & Cmb_Tower.Text & "  Floor : " & Cmb_Floor.Text
                .Show()
            End With
        Catch ex As Exception
            MsgBox("ButtonX1 : " & ex.Message)
        End Try
    End Sub

    Function Save_Pict_To_DB_No_Message(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pFileName As String) As Boolean
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rsPict As New ADODB.Stream
        Dim sql As String
        Save_Pict_To_DB_No_Message = False
        If pFileName <> "0" Then
            sql = " SELECT *  FROM " & pTable & " WHERE " & pFields & " = " & pKey & ""
            If OpenCnn(pConnStr, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .LockType = ADODB.LockTypeEnum.adLockOptimistic
                    .Open(sql)
                    If Not (rs.EOF And rs.BOF) Then
                        rsPict.Type = ADODB.StreamTypeEnum.adTypeBinary
                        rsPict.Open()
                        rsPict.LoadFromFile("test.Bmp")
                        .Fields(pPict_Fields).Value = rsPict.Read
                        .Update()
                        rsPict.Close()
                        Save_Pict_To_DB_No_Message = True
                    Else
                        .Close()
                        Save_Pict_To_DB_No_Message = False
                        Exit Function
                    End If
                End With
            Else
                Save_Pict_To_DB_No_Message = False

            End If
        End If

        Conn = Nothing
        rs = Nothing
        rsPict = Nothing
        Exit Function
Err_Renamed:
        Save_Pict_To_DB_No_Message = False
        Call mError.ShowError("ฐานข้อมูล", "บันทึกรปภาพ ลงฐานข้อมูล", Err.Number, Err.Description)
    End Function

    Private Sub Cmb_Tower_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Cmb_Tower.SelectedIndexChanged
        If Cmb_Tower.SelectedIndex > 0 Then
            Building_ID = Cmb_Tower.SelectedValue
            Load_floor(Cmb_Floor, Building_ID)
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        L1.Text = "0 - 0"
        L2.Text = "0 - 0"
        L3.Text = "0 - 0"
        L4.Text = "0 - 0"

        If RD_Fequency.Checked = True Then
            Call Fequency_report()
        Else
            Call Parking_Time_report()
        End If
        Try
        Catch ex As Exception
            MsgBox("ButtonX2_Click : " & ex.Message)
        End Try
    End Sub
    Sub Parking_Time_report()
        count_car_parking_time(DT_St.Value, DT_End.Value, Cmb_Tower.SelectedValue, Cmb_Floor.SelectedValue)
        set_label()
        Load_Button_New_Parking_Time(Cmb_Floor.SelectedValue, Building_ID, "")

        'L1.Text = part_A(0) & " - " & part_A(1) & "  ชั่วโมง"
        'L2.Text = part_B(0) & " - " & part_B(1) & "  ชั่วโมง"
        'L3.Text = part_C(0) & " - " & part_C(1) & "  ชั่วโมง"
        'L4.Text = part_D(0) & " - " & part_D(1) & "  ชั่วโมง"

        L1.Text = part_A(0) & " - " & part_A(1) & "  ชั่วโมง   [ " & part_A(2) & " คัน]"
        L2.Text = part_B(0) & " - " & part_B(1) & "  ชั่วโมง   [ " & part_B(2) & " คัน]"
        L3.Text = part_C(0) & " - " & part_C(1) & "  ชั่วโมง   [ " & part_C(2) & " คัน]"
        L4.Text = part_D(0) & " - " & part_D(1) & "  ชั่วโมง   [ " & part_D(2) & " คัน]"
    End Sub
    Sub set_label()
        Dim picture_car As Image
        Dim i_index As Integer = 1

        i_index = 1
        With PB1
            picture_car = convert_byte_to_Image(alarm_pic(i_index))
            picture_car.RotateFlip(RotateFlipType.Rotate90FlipX)
            .BackgroundImage = picture_car
            .BackgroundImageLayout = ImageLayout.Stretch
            L1.BackColor = Color.FromArgb(alarm_colorA(i_index), alarm_colorR(i_index), alarm_colorG(i_index), alarm_colorB(i_index))
        End With

        i_index = 3
        With PB2
            picture_car = convert_byte_to_Image(alarm_pic(i_index))
            picture_car.RotateFlip(RotateFlipType.Rotate90FlipX)
            .BackgroundImage = picture_car
            .BackgroundImageLayout = ImageLayout.Stretch
            L2.BackColor = Color.FromArgb(alarm_colorA(i_index), alarm_colorR(i_index), alarm_colorG(i_index), alarm_colorB(i_index))
        End With

        i_index = 4
        With PB3
            picture_car = convert_byte_to_Image(alarm_pic(i_index))
            picture_car.RotateFlip(RotateFlipType.Rotate90FlipX)
            .BackgroundImage = picture_car
            .BackgroundImageLayout = ImageLayout.Stretch
            L3.BackColor = Color.FromArgb(alarm_colorA(i_index), alarm_colorR(i_index), alarm_colorG(i_index), alarm_colorB(i_index))
        End With

        i_index = 5
        With PB4
            picture_car = convert_byte_to_Image(alarm_pic(i_index))
            picture_car.RotateFlip(RotateFlipType.Rotate90FlipX)
            .BackgroundImage = picture_car
            .BackgroundImageLayout = ImageLayout.Stretch
            L4.BackColor = Color.FromArgb(alarm_colorA(i_index), alarm_colorR(i_index), alarm_colorG(i_index), alarm_colorB(i_index))
        End With

    End Sub
    Sub Fequency_report()
        count_car_fequency(DT_St.Value, DT_End.Value, Cmb_Tower.SelectedValue, Cmb_Floor.SelectedValue)
        set_label()
        Load_Button_New_fequency(Cmb_Floor.SelectedValue, Building_ID, "")

        L1.Text = part_A(0) & " - " & part_A(1) & "  ครั้ง   [ " & part_A(2) & " คัน]"
        L2.Text = part_B(0) & " - " & part_B(1) & "  ครั้ง   [ " & part_B(2) & " คัน]"
        L3.Text = part_C(0) & " - " & part_C(1) & "  ครั้ง   [ " & part_C(2) & " คัน]"
        L4.Text = part_D(0) & " - " & part_D(1) & "  ครั้ง   [ " & part_D(2) & " คัน]"
    End Sub
    Private Sub Cmb_Floor_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Cmb_Floor.SelectedIndexChanged
        If Cmb_Floor.SelectedIndex >= 0 Then
            If Cmb_Floor.Items.Count > 0 Then
                If Cmb_Floor.SelectedIndex = 0 Then
                    Call Show_Picture_Floor(1)
                Else '
                    Call Show_Picture_Floor(Cmb_Floor.SelectedValue)
                End If
            End If
        End If
    End Sub
End Class