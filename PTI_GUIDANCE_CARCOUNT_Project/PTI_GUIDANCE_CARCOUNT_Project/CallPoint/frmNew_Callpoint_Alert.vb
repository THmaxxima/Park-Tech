﻿Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frmNew_Callpoint_Alert
    Friend Floor_no As String
    Friend Building_ID As String
    Friend callpoint_id As String = ""
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
    Dim lbl_Z(100) As Label
    Dim pg_box As PictureBox

    Private Sub frmNew_Display_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerRealtime.Enabled = False
        T_Alert.Enabled = False
    End Sub

    Private Sub frmNew_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Timer_False()
        PanelEx2.Visible = False
        'Application.DoEvents()

        If Building_ID = "" Then Building_ID = "1"
        If Floor_no = "" Then
            Floor_no = "1"
            Load_(Floor_no, Building_ID, ZCU_ID)
        Else
            Load_(Floor_no, Building_ID, ZCU_ID)
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
        cmb_user()
        'Call update_Button_New_load_CP(Pic_ID_2)
        Timer_True()

    End Sub

    Sub Load_(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_no As String)

        Call Tab_Floor_Name(floor_no, building_no) '###  Step 1 แสดงชื่อชั้นจอดรถ ทุกชั้น แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor(floor_no) '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Call Load_Button_New(floor_no, building_no, zcu_no) '###  Step 3 Load Ultrasonic มาแสดง
   

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

            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงชื่อชั้นจอดรถ", Err.Number, Err.Description)
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
    Private Sub Button_Doubleclick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer_False()
        Dim lbl_ As PictureBox
        If TypeOf (sender) Is PictureBox Then
            lbl_ = sender
            Dim frm As New frm_Lot_History_CallPoint
            With frm
                mForm.Set_Standard_Form(frm)
                .Lot_id = lbl_.Name
                .Buiding_id = Building_ID
                .floor_no = Floor_no
                .ShowDialog()
                .Dispose()
            End With
        End If
        Timer_True()
    End Sub

    Private Sub Button_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer_False()
        GroupBox1.Visible = False
        If TypeOf (sender) Is PictureBox Then
            callpoint_id = sender.Name
            If check_alert(callpoint_id) Then
                GroupBox1.Visible = True
                load_data(callpoint_id)
                load_Accept_data(callpoint_id)
            Else
                GroupBox1.Visible = False
            End If
        End If
        Timer_True()
    End Sub
    Function check_alert(ByVal hw_lot_id As String)
        Dim sql As String = ""
        sql = "SELECT * FROM  Mas_CallPoint WHERE HW_Call_Id='" & hw_lot_id & "' and HW_On_Line = '1' and HW_Status_Id='1'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("HW_Status_Id").ToString = "1" Then
                check_alert = True
            Else
                check_alert = False
            End If
        Else
            check_alert = False
        End If
    End Function
    Sub load_data(ByVal call_point_id As String)
        Dim sql As String = ""

        sql = "SELECT * FROM V_Mas_Callpoint WHERE HW_Call_Id='" & call_point_id & "'"

        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("HW_Call_Id").ToString
            TextBox2.Text = dt.Rows(0).Item("HW_Datetime_In").ToString
            TextBox3.Text = CurUser_FullName

            If dt.Rows(0).Item("HW_Accept_Action").ToString = "0" Or dt.Rows(0).Item("HW_Accept_Action").ToString = "" Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If

        End If
    End Sub
    Sub cmb_user()

        Try
            Dim sql As String = ""
            sql = "SELECT User_ID,User_FirstName + ' ' + User_LastName as NAME_ FROM V_Mas_User "
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                With ComboBox1
                    .DataSource = dt
                    .DisplayMember = "NAME_"
                    .ValueMember = "User_ID"
                End With

                With ComboBox2
                    .DataSource = dt
                    .DisplayMember = "NAME_"
                    .ValueMember = "User_ID"
                End With

            End If
        Catch ex As Exception
            MsgBox("can not load function cmb_user :" & ex.Message)
        End Try


    End Sub
    Sub update_(ByVal call_point_id As String)
        Try
            Dim sql As String = ""
            sql = "UPDATE Mas_CallPoint SET HW_Accept_Action=1,HW_Accept_Datetime=GETDATE(),User_Accept='" & User_ID & "',User_Service='" & ComboBox1.SelectedValue & "' WHERE HW_Call_Id='" & call_point_id & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                sql = "UPDATE [Transaction_Callpoint_IN] SET HW_Accept_Action=1,HW_Accept_Datetime=GETDATE(),User_Accept='" & User_ID & "',User_Service='" & ComboBox1.SelectedValue & "' WHERE Trn_Lot_Id = '" & call_point_id & "'"
                If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then

                End If
                MsgBox(msg_update(0))
            Else
                MsgBox(msg_update(1))
            End If
        Catch ex As Exception
            MsgBox("can not load function update_ :" & ex.Message)
        End Try

    End Sub

    Sub load_Accept_data(ByVal call_point_id As String)
        Dim sql As String = ""
        Try
            sql = "SELECT * FROM V_Mas_Callpoint WHERE HW_Call_Id='" & call_point_id & "' and HW_Accept_Action='1'"

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            DataGridViewX1.Rows.Clear()
            If dt.Rows.Count > 0 Then
                DataGridViewX1.Rows.Add(dt.Rows(0).Item("User_Service").ToString, dt.Rows(0).Item("User_Name_Service").ToString, dt.Rows(0).Item("HW_Accept_Datetime").ToString)
            End If
        Catch ex As Exception
            MsgBox("can not load function load_Accept_data :" & ex.Message)
        End Try

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


    Private Sub TimerRealtime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRealtime.Tick
        TimerRealtime.Enabled = False

        Call update_Button_New_load_CP(Pic_ID_2)

        TimerRealtime.Enabled = True
    End Sub
    Sub update_Display_New()
        Try
            Dim sql As String = ""
            Dim dt As DataTable
            For Each dp As Control In Pic_ID_2.Controls
                If TypeOf (dp) Is Label Then
                    sql = "SELECT * FROM [V_MAS_Display_Config_Data]  WHERE [ID_Display] = '" & dp.Name & "'"
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

        'Dim PositionX As Integer = 20 ' X not < 750 20
        'Dim PositionY As Integer = 26 ' 26
        Dim sql As String = ""
        Dim i As Short = 0
        I_Index = 0
        Try
            sql = " SELECT distinct * "
            sql &= " FROM Q_Mas_Callpoint "
            sql &= " where HW_Lot_Type='L' and HW_Building_ID='" & building_no & "' and Floor_No = '" & floor_no & "' and HW_Floor_No='" & floor_no & "'"
            If zcu_id <> "" Then
                sql &= " and HW_Floorcontroller_Id ='" & zcu_id & "'"
            End If
            If callpoint_id <> "" Then
                sql &= " and HW_Call_Id ='" & callpoint_id & "'"
            End If
            sql &= " order by HW_Call_Id"


            Dim Tag As String = ""
            Dim I_Index As Integer = 0
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then
                For ii As Integer = 0 To DT.Rows.Count - 1
                    If DT.Rows(ii).Item("HW_Position_X").ToString = "0" And DT.Rows(ii).Item("HW_Position_Y").ToString = "0" Then

                    Else
                        If DT.Rows(ii).Item("HW_Position_X").ToString = "" And DT.Rows(ii).Item("HW_Position_Y").ToString = "" Then

                        Else
                            pg_box = New PictureBox
                            Dim name_ As String = DT.Rows(ii).Item("HW_Call_Id").ToString
                            Dim accept_id As String = DT.Rows(ii).Item("HW_Accept_Action").ToString
                            Dim status_id As String = DT.Rows(ii).Item("HW_Status_Id").ToString
                            Dim online_id As String = DT.Rows(ii).Item("HW_On_Line").ToString
                            Dim location_x As String = DT.Rows(ii).Item("HW_Position_X").ToString
                            Dim location_y As String = DT.Rows(ii).Item("HW_Position_Y").ToString
                            Dim direction As String = "TOP"
                            'Dim color_ As Color = Status_Alarm_Color(DT.Rows(ii).Item("Alarm_Id").ToString)
                            Tag = Mid(DT.Rows(ii).Item("HW_Call_Id").ToString, 4, 8)

                            Add_Control_CP(pg_box, name_, location_x, location_y, Tag, direction)
                            With pg_box
                                'AddHandler .Click, AddressOf Me.Button_Click

                                If online_id = "0" Then
                                    pg_box.BackgroundImage = convert_byte_to_Image(callpoint_pic(2))
                                Else
                                    pg_box.BackgroundImage = convert_byte_to_Image(callpoint_pic(0))
                                End If
                                If accept_id = "" Then accept_id = "0"
                                If status_id = "1" And online_id = "1" And accept_id = "0" Then
                                    'pg_box.Image = Image.FromFile("image\callpointB1.png")
                                    pg_box.BackgroundImage = convert_byte_to_Image(callpoint_pic(1))
                                End If


                                AddHandler .Click, AddressOf Me.Button_click
                                AddHandler .DoubleClick, AddressOf Me.Button_Doubleclick

                                'AddHandler .MouseHover, AddressOf Me.mouse_Hover
                                'AddHandler .MouseLeave, AddressOf Me.mouse_leave
                                .BringToFront()
                                Pic_ID_2.Controls.Add(pg_box)
                            End With
                        End If

                    End If
                Next
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "เพิ่ม Lot Sensor Error ", Err.Number, Err.Description)
        End Try
    End Sub
   

    Private Sub Pic_ID_2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Pic_ID_2.MouseClick
        ' Label2.Text = "X=" & Cursor.Position.X & " ,Y=" & Cursor.Position.Y
        Application.DoEvents()
    End Sub


    Private Sub PanelEx1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PanelEx1.MouseClick
        'Label2.Text = "X=" & Cursor.Position.X & " ,Y=" & Cursor.Position.Y
        Application.DoEvents()
    End Sub


    Function Status_Alarm_Name(ByVal id_ As String) As String
        Try
            Dim Name_ As String = ""
            Dim sql As String = ""
            sql = "SELECT * FROM  Mas_Status_Callpoint_Alarm WHERE [Status_Alarm_Id]='" & id_ & "'"
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


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If User_ID = "" Or ComboBox1.SelectedValue = "" Then
            MsgBox("ข้อมูลไม่ครบ")
            Exit Sub
        End If
        update_(callpoint_id)
        load_Accept_data(callpoint_id)
    End Sub

    Private Sub DataGridViewX1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim v As String = DataGridViewX1.Rows(e.RowIndex).Cells(0).Value
            Try
                ComboBox2.SelectedValue = v
                Panel1.Visible = True
            Catch ex As Exception
                MsgBox("DataGridViewX1_CellContentClick : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            Dim sql As String = ""
            sql = "UPDATE Mas_CallPoint SET User_Accept='" & CurUser_ID & "',User_Service='" & ComboBox2.SelectedValue & "' WHERE HW_Call_Id='" & callpoint_id & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox(msg_update(0))
            Else
                MsgBox(msg_update(1))
            End If
            Panel1.Visible = False
            load_Accept_data(callpoint_id)
        Catch ex As Exception
            MsgBox("can not load function Button2_Click :" & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Panel1.Visible = False
        load_Accept_data(callpoint_id)
    End Sub
End Class