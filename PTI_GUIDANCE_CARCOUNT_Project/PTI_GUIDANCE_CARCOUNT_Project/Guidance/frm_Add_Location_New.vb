Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frm_Add_Location_New
    'Friend Floor_SelectID As String

    Friend Building_ID As String
    Friend ZCU_ID As String = ""
    Dim floor_no As String = "1"

    Friend HW_Current_ID As PictureBox
    Friend Flag_Start_From As Boolean
    Dim cursor_position_X As Integer = 0
    Dim cursor_position_y As Integer = 0

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
    Dim st_edit As Integer = 0
    Dim HW_New_ADD As String = ""

    Dim x_new As Integer = 0
    Dim y_new As Integer = 4

    Dim st_x As Integer = 0
    Dim st_y As Integer = 0

    Dim lbl_Z(100) As Label
    Dim pg_box As PictureBox

    Dim step_ As Integer = 0
    Dim node_start As String = ""
    Dim node_start_x As Integer = 0
    Dim node_start_Y As Integer = 0
    Dim node_end As String = ""
    Dim node_end_x As Integer = 0
    Dim node_end_Y As Integer = 0

    Dim color_brush As Color = Color.Blue
    Dim brush_size As Integer = 8
    Dim brush_font As String = "Arial"

    Private Sub frmNew_Display_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerRealtime.Enabled = False
        T_Alert.Enabled = False
    End Sub

    Private Sub frm_Add_Location_New_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If TextBox4.Text <> "" Then
            If e.KeyCode = Keys.Left Then
                'Button11_Click(e, Nothing)
                For Each btn_ As PictureBox In Pic_ID_2.Controls
                    If btn_.Name = TextBox4.Text Then
                        btn_.Location = New Point(btn_.Location.X - 1, btn_.Location.Y)
                    End If
                Next
            End If
            If e.KeyCode = Keys.Right Then
                For Each btn_ As PictureBox In Pic_ID_2.Controls
                    If btn_.Name = TextBox4.Text Then
                        btn_.Location = New Point(btn_.Location.X + 1, btn_.Location.Y)
                    End If
                Next
            End If
            If e.KeyCode = Keys.Up Then
                For Each btn_ As PictureBox In Pic_ID_2.Controls
                    If btn_.Name = TextBox4.Text Then
                        btn_.Location = New Point(btn_.Location.X, btn_.Location.Y - 1)
                    End If
                Next
            End If
            If e.KeyCode = Keys.Down Then
                For Each btn_ As PictureBox In Pic_ID_2.Controls
                    If btn_.Name = TextBox4.Text Then
                        btn_.Location = New Point(btn_.Location.X, btn_.Location.Y + 1)
                    End If
                Next
            End If
            'If e.KeyCode = Keys.M Then
            '    ' Button1_Click(e, Nothing)
            'End If
        End If
    End Sub

    Private Sub frmNew_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PanelEx2.Visible = True
        menu_floor()
        If Me.Width > 1200 Then
            Dim x_new As Integer = (Me.Width - PanelEx2.Width) / 2
            Dim y_new As Integer = 4
            If Me.Height > 600 Then
                y_new = (PanelEx1.Height - PanelEx2.Height) / 2
            End If
            PanelEx2.Location = New Point(x_new, y_new)
        End If
        If Building_ID = "" Then Building_ID = "1"
        If floor_no = "" Then
            floor_no = "1"
            Load_(floor_no, Building_ID, ZCU_ID)
        Else
            Load_(floor_no, Building_ID, ZCU_ID)
        End If

        x_new = PanelEx2.Location.X
        y_new = PanelEx2.Location.Y
        st_x = x_new
        st_y = y_new
        Label8.Text = "X=" & st_x & " ,Y=" & st_y
        cmb_asc.SelectedIndex = 0
        TimerRealtime.Enabled = True

    End Sub
    Sub menu_floor()
        Try

            Dim i As Integer = 0
            Dim padding_space As Integer = 120
            Dim sql As String = ""
            sql = "SELECT distinct [Floor_ID],[Tower_ID],[Building_ID],[Floor_No],[Floor_Name],[Building_Name] FROM [V_Mas_Floor] order by [Building_ID],[Floor_No] asc"
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

        End Try

    End Sub
    Private Sub ButtonFloor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim a() As String = sender.name.ToString.Split("_")

            sender.checked = True
            Building_ID = a(0)
            'Floor_SelectID = a(1)
            If floor_no = a(1) Then

            Else
                ZCU_ID = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                floor_no = a(1)
            End If

            Load_(floor_no, Building_ID, ZCU_ID)
            Application.DoEvents()
            ' End If
            ' TimerRealtime.Enabled = True
            ' Else
            'check_click = 1
            'End If
            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_no As String)

        Call Tab_Floor_Name(floor_no, building_no) '###  Step 1 แสดงชื่อชั้นจอดรถ ทุกชั้น แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor(floor_no) '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Call Load_Button_New(floor_no, building_no, zcu_no) '###  Step 3 Load Ultrasonic มาแสดง
        'Call Load_Board_Zone(floor_no, Building_ID)
        Call Load_ZCU(floor_no, building_no)
        TextBox2.Focus()
    End Sub

    Sub Timer_True()
        TimerRealtime.Enabled = True

    End Sub
    Sub Timer_False()
        TimerRealtime.Enabled = False

    End Sub
    Sub Load_ZCU(ByVal floor_no As String, ByVal building_no As String)
        Try
            Dim sql As String = ""
            sql = "SELECT ID,Floor_Controller_Name FROM Mas_Floor_Controller WHERE [Building_ID]='" & building_no & "' and [Floor_No]='" & floor_no & "' order by Building_ID,Floor_No"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                Cmb_ZCU.DataSource = dt
                Cmb_ZCU.DisplayMember = "Floor_Controller_Name"
                Cmb_ZCU.ValueMember = "ID"
                Cmb_ZCU.SelectedIndex = 0


                Cmb_ZCU2.DataSource = dt
                Cmb_ZCU2.DisplayMember = "Floor_Controller_Name"
                Cmb_ZCU2.ValueMember = "ID"
                Cmb_ZCU2.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_ZCU :" & ex.Message)
        End Try

    End Sub
    Sub Show_Floor()
        ' Call DisPlay_Status_In_Floor()
        Call Value_In_Zone() 'จำนวนรถว่างในแต่ละโซน

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
                  "FROM MAS_Display_Config where Floor_No ='" & floor_No & "' and Building_ID='" & Building_ID & "' order by ID_Display"
            If OpenCnn(ConStr_Master, Conn) Then
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
    Sub Show_Picture_Floor(ByVal floor_ID As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        Pic_ID_2.Controls.Clear()

        sql = "Select Floor_Image,Floor_Id from Mas_Floor WHERE Floor_Id = '" & floor_ID & "' "

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
    Sub Tab_Floor_Name(ByVal floor_id As String, ByVal buiding As String) 'ชื่อของชั้นของแท็บ

        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT [Floor_ID]"
            sql &= ",[Tower_ID]"
            sql &= ",[Building_ID]"
            sql &= ",(SELECT TOP 1 [Building_Name] FROM [Mas_Building_Parking] WHERE [Mas_Building_Parking].[Building_ID]=Mas_Floor.[Building_ID]) as Building_Name"
            sql &= ",[Floor_No]"
            sql &= ",[Floor_Name] "
            sql &= ",[Floor_Lot_All] "
            sql &= ",[Floor_Lot_Empty] "
            sql &= ",[Floor_Lot_Parking] "
            sql &= " FROM Mas_Floor "
            sql &= " WHERE [Floor_ID]='" & floor_id & "' and [Building_ID]='" & buiding & "'"
            sql &= " ORDER BY Building_ID, Floor_Id "


            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                Me.Text = DT.Rows(0).Item("Building_Name").ToString & " - " & DT.Rows(0).Item("Floor_Name").ToString

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

    Private Sub nodebtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = False
        LeftSet = False
        TopSet = False
    End Sub
    Private Sub nodebtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = True
    End Sub
    Private Sub pb_obj_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        Dim id_ As String = sender.Tag
        Dim StringToDraw As String = (id_).Substring(id_.Length - 3, 3)
        Dim MyBrush As New SolidBrush(color_brush)
        Dim StringFont As New Font(brush_font, brush_size)
        'Dim text_l As Integer = sender.text.ToString.Length + 9
        Dim PixelsAcross As Integer = 2
        Dim PixelsDown As Integer = sender.height - 20
        e.Graphics.DrawString(StringToDraw, StringFont, MyBrush, PixelsAcross, PixelsDown)
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
            st_x = sender.Left
            st_y = sender.Top
            Label5.Text = " X = " & st_x & "   Y = " & st_y


            node_start_x = st_x
            node_start_Y = st_y


            'Select Case step_
            '    Case 0
            '        node_start_x = st_x
            '        node_start_Y = st_y
            '        step_ = 1
            '        TextBox3.Text = sender.name
            '    Case 1
            '        node_start_x = st_x
            '        node_start_Y = st_y
            '        step_ = 0
            '        TextBox2.Text = sender.name
            'End Select
        End If



        Dim lbl_ As PictureBox = sender
        HW_Current_ID = lbl_
        Label1.Text = "ID : " & lbl_.Name
        Label3.Text = "Building ID : " & Building_ID
        TextBox4.Text = HW_Current_ID.Name
        'Dim sql As String = ""
        'sql = "SELECT [HW_Position_X],[HW_Position_Y] FROM [Mas_Lot] "
        'sql &= "WHERE [HW_Floor_No] = '" & Floor_SelectID & "' and [HW_Building_ID] = '" & Building_ID & "' and [HW_Lot_Id]='" & lbl_.Name & "'"
        'Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        'If dt.Rows.Count > 0 Then
        '    Label5.Text = "POSITION X : " & dt.Rows(0).Item("HW_Position_X").ToString & " Y : " & dt.Rows(0).Item("HW_Position_Y").ToString
        'Else
        '    Label5.Text = "POSITION X : - Y : -"
        'End If

        Button1.Enabled = True
    End Sub
    Private Sub Button_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Label1.Text = "ID : " & HW_Current_ID.Name
        Label3.Text = "Building ID : " & Building_ID

        If sender.tag <> Mid(sender.name, 4, 8) Then
            If Direction_Select <> "" Then
                sql = "UPDATE Mas_Lot SET HW_Plan_Direction='" & Direction_Select & "',HW_Position_X='" & sender.location.x + 10 & "',HW_Position_Y='" & sender.location.y + 30 & "' WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"
            Else
                sql = "UPDATE Mas_Lot SET HW_Position_X='" & sender.location.x + 10 & "',HW_Position_Y='" & sender.location.y + 30 & "' WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"
            End If
        Else
            sql = "UPDATE Mas_Lot SET HW_Position_X='" & sender.location.x + 10 & "',HW_Position_Y='" & sender.location.y + 30 & "' WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"
        End If



        'sql = "UPDATE Mas_Lot SET HW_Position_X='" & st_x + 10 & "',HW_Position_Y='" & st_y + 30 & "' WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"

        If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
            Direction_Select = ""
            MsgBox("update successs")
        End If

        'Dim sql As String = ""
        'sql = "SELECT [HW_Position_X],[HW_Position_Y] FROM [Mas_Lot] "
        'sql &= "WHERE [HW_Floor_No] = '" & Floor_SelectID & "' and [HW_Building_ID] = '" & Building_ID & "' and [HW_Lot_Id]='" & lbl_.Name & "'"
        'Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        'If dt.Rows.Count > 0 Then
        '    Label5.Text = "POSITION X : " & dt.Rows(0).Item("HW_Position_X").ToString & " Y : " & dt.Rows(0).Item("HW_Position_Y").ToString
        'Else
        '    Label5.Text = "POSITION X : - Y : -"
        'End If

        'Button1.Enabled = True
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
            If OpenCnn(ConStr_Master, Conn) Then
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


    Sub Load_Board_Zone_Name()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0

        Try
            sql = "SELECT * FROM Mas_Floor_Zone_Name "
            sql &= " order by F_Zone_Id"

            If OpenCnn(ConStr_Master, Conn) Then
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
    Sub Load_Board_Zone_Name(ByVal floor_no As String, ByVal building_no As String)
        ' On Error GoTo Err_Renamed
        Dim sql As String = ""
        Dim I_Index As Short = 0

        Try
            'sql = "SELECT * FROM Mas_Floor_Zone_Name "
            'sql &= " where F_Zone_Floor_No = '" & floor_no & "' and F_Zone_Building_ID = '" & building_no & "'"
            'sql &= " order by F_Zone_Id"

            'Dim btn_(500) As Label
            'Dim Tag As String = ""
            'Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            'If DT.Rows.Count > 0 Then
            '    For ii As Integer = 0 To DT.Rows.Count - 1
            '        btn_(ii) = New Label
            '        With btn_(I_Index)

            '            .BackColor = Color.FromArgb(DT.Rows(ii).Item("F_Zone_Back_ColorA").ToString, DT.Rows(ii).Item("F_Zone_Back_ColorR").ToString, DT.Rows(ii).Item("F_Zone_Back_ColorG").ToString, DT.Rows(ii).Item("F_Zone_Back_ColorB").ToString)
            '            .ForeColor = Color.FromArgb(DT.Rows(ii).Item("F_Zone_Font_ColorA").ToString, DT.Rows(ii).Item("F_Zone_Font_ColorR").ToString, DT.Rows(ii).Item("F_Zone_Font_ColorG").ToString, DT.Rows(ii).Item("F_Zone_Font_ColorB").ToString)

            '            .Size = New System.Drawing.Size(DT.Rows(ii).Item("F_Zone_SizeX").ToString, DT.Rows(ii).Item("F_Zone_SizeY").ToString)
            '            .Location = New System.Drawing.Point(
            '                DT.Rows(ii).Item("F_Zone_PositionX").ToString + Pic_ID_2.Location.X + PanelEx2.Location.X _
            '                , DT.Rows(ii).Item("F_Zone_PositionY").ToString + Pic_ID_2.Location.Y + PanelEx2.Location.Y)
            '            .Text = DT.Rows(ii).Item("F_Zone_Name").ToString
            '            .TextAlign = ContentAlignment.MiddleCenter
            '            .Name = "lbl" & DT.Rows(ii).Item("F_Zone_Id").ToString
            '            AddHandler .Click, AddressOf Me.Button_Click
            '            Me.Controls.Add(btn_(I_Index))
            '            .Parent = Me
            '            .BringToFront()
            '        End With

            '        I_Index = I_Index + 1

            '    Next

            'End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
        End Try
    End Sub

    Sub Load_Button_New(ByVal floor_no As String, ByVal building_no As String, ByVal zcu_id As String)

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

            Dim position_x As Integer = 0
            Dim position_y As Integer = 0
            Dim x_space As Integer = 25
            Dim y_space As Integer = 50
            Dim car_per_row As Integer = 30
            Dim car_current As Integer = 0
            Dim car_row_count As Integer = 0
            Dim car_i As Integer = 0
            Dim Tag As String = ""
            Dim I_Index As Integer = 0
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then

                For ii As Integer = 0 To DT.Rows.Count - 1
                    pg_box = New PictureBox
                    Dim name_ As String = DT.Rows(ii).Item("HW_Lot_Id").ToString
                    Dim location_x As String = DT.Rows(ii).Item("HW_Position_X").ToString
                    Dim location_y As String = DT.Rows(ii).Item("HW_Position_Y").ToString
                    Dim color_ As Color = Status_Alarm_Color(DT.Rows(ii).Item("Alarm_Id").ToString)
                    Dim direction As String = DT.Rows(ii).Item("HW_Plan_Direction").ToString


                    If location_x = "0" Or location_y = "0" Or location_x = "" Or location_y = "" Then

                        If car_current = 0 Then
                            If car_row_count > 0 Then
                                location_x = car_current + x_space + Pic_ID_2.Location.Y + 30
                                location_y = car_row_count * y_space + Pic_ID_2.Location.X + 30
                            Else
                                location_x = car_current * x_space + Pic_ID_2.Location.Y + 30
                                location_y = car_row_count * y_space + Pic_ID_2.Location.X + 30
                            End If
                        Else

                            location_x = (car_current * x_space) + Pic_ID_2.Location.Y + 30
                            location_y = (car_row_count * y_space) + Pic_ID_2.Location.X + 30
                        End If


                        If car_current >= car_per_row Then
                            car_row_count = car_row_count + 1
                            location_y = car_row_count * y_space + Pic_ID_2.Location.Y + 30
                            location_x = Pic_ID_2.Location.X + 30
                            car_current = 0
                        Else
                            car_current = car_current + 1
                            location_x = (car_current * x_space) + Pic_ID_2.Location.Y + 30
                            location_y = (car_row_count * y_space) + Pic_ID_2.Location.X + 30
                        End If

                    End If


                    If direction = "" Then direction = "TOP"
                    Tag = Mid(DT.Rows(ii).Item("HW_Lot_Id").ToString, 4, 8)
                    'Dim img_ As Image
                    Add_Control(pg_box, name_, location_x, location_y, Tag, "", direction)

                    With pg_box
                        .ContextMenuStrip = CMenu_UID
                        AddHandler .Paint, AddressOf Me.pb_obj_Paint
                        AddHandler .MouseDoubleClick, AddressOf Me.Button_DoubleClick
                        AddHandler .Click, AddressOf Me.Button_Click
                        AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                        AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                        AddHandler .MouseUp, AddressOf nodebtn_MouseUp
                        'AddHandler .PreviewKeyDown, AddressOf node_PreviewKeyDown
                        Pic_ID_2.Controls.Add(pg_box)
                        .BringToFront()
                    End With
                    Application.DoEvents()
                Next

            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "เพิ่ม Lot Sensor Error ", Err.Number, Err.Description)
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

    Private Sub Pic_ID_2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Pic_ID_2.MouseClick
        cursor_position_X = Cursor.Position.X
        cursor_position_y = Cursor.Position.Y
        Label2.Text = "X=" & Cursor.Position.X & " ,Y=" & Cursor.Position.Y
        Application.DoEvents()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            'Dim x_new As Integer = (Me.Width - PanelEx2.Width) / 2
            'Dim y_new As Integer = 4
            'If Me.Height > 600 Then
            '    y_new = (PanelEx1.Height - PanelEx2.Height) / 2
            'End If
            Application.DoEvents()
            ' HW_Current_ID.Location = New Point(cursor_position_X - x_new - 10, cursor_position_y - y_new - 30)

            If cursor_position_X < 0 Or cursor_position_y = 0 Then
                MsgBox("กรุณาเลือกตำแหน่งที่จะย้าย")
                Exit Sub
            End If
            If st_x < 0 Or st_y < 0 Then
                MsgBox("กรุณาตั้งค่าตำแหน่งเริ่มต้น")
                Exit Sub
            End If

            HW_Current_ID.Location = New Point(cursor_position_X - st_x, cursor_position_y - st_y)
            'cursor_position_X = cursor_position_X - st_x
            'cursor_position_y = cursor_position_y - st_y
            st_edit = 1
            Application.DoEvents()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Try
            x_new = (Me.Width - PanelEx2.Width) / 2
            If Me.Height > 600 Then
                y_new = (PanelEx1.Height - PanelEx2.Height) / 2
            End If

            'sql = "UPDATE Mas_Lot SET HW_Position_X='" & cursor_position_X - (x_new) & "',HW_Position_Y='" & cursor_position_y - (y_new) & "' WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"
            sql = "UPDATE Mas_Lot SET HW_Position_X='" & cursor_position_X - (st_x) + 10 & "',HW_Position_Y='" & cursor_position_y - (st_y) + 30 & "' WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox("update successs")
            End If
            Button2.Enabled = True
        Catch ex As Exception
            Button2.Enabled = True
        End Try

    End Sub

    Private Sub txt_Up_Click(sender As System.Object, e As System.EventArgs) Handles txt_Up.Click
        cursor_position_X = cursor_position_X
        cursor_position_y = cursor_position_y - 1
        HW_Current_ID.Location = New Point(HW_Current_ID.Location.X, HW_Current_ID.Location.Y - 1)
        Label2.Text = "X=" & cursor_position_X & " ,Y=" & cursor_position_y
        Application.DoEvents()
    End Sub

    Private Sub txt_Pre_Click(sender As System.Object, e As System.EventArgs) Handles txt_Pre.Click
        cursor_position_X = cursor_position_X - 1
        cursor_position_y = cursor_position_y
        HW_Current_ID.Location = New Point(HW_Current_ID.Location.X - 1, HW_Current_ID.Location.Y)
        Label2.Text = "X=" & cursor_position_X & " ,Y=" & cursor_position_y
        Application.DoEvents()
    End Sub

    Private Sub txt_Next_Click(sender As System.Object, e As System.EventArgs) Handles txt_Next.Click
        cursor_position_X = cursor_position_X + 1
        cursor_position_y = cursor_position_y
        HW_Current_ID.Location = New Point(HW_Current_ID.Location.X + 1, HW_Current_ID.Location.Y)
        Label2.Text = "X=" & cursor_position_X & " ,Y=" & cursor_position_y
        Application.DoEvents()
    End Sub

    Private Sub txt_Down_Click(sender As System.Object, e As System.EventArgs) Handles txt_Down.Click
        cursor_position_X = cursor_position_X
        cursor_position_y = cursor_position_y + 1
        HW_Current_ID.Location = New Point(HW_Current_ID.Location.X, HW_Current_ID.Location.Y + 1)
        Label2.Text = "X=" & cursor_position_X & " ,Y=" & cursor_position_y
        Application.DoEvents()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Application.DoEvents()
        Panel1.Visible = True
        Button2.Enabled = False
        Button3.Enabled = False
        TextBox1.Text = Function_New_Lot_ID()
        If TextBox1.Text = "" Then
            HW_New_ADD = TextBox1.Text
        Else
            If HW_New_ADD = TextBox1.Text Then
                '----- ข้อมูลเดิมยังไม่บันทึก
                MsgBox("กรุณาบันทึกข้อมูลก่อน")
                Exit Sub
            Else
                '----- ข้อมูลใหม่ปกติ
            End If
        End If

        ZCU_ID = Cmb_ZCU.SelectedValue
        Dim ssql As String = ""
        Dim HW_Name As String = ""

        HW_Name = "TA FL:B CTRL01 Add/061"

        ssql = "INSERT INTO [Mas_Lot](HW_Tower_ID,HW_Lot_Id,HW_Building_ID,HW_Floor_No,HW_Floorcontroller_Id,HW_On_Line,HW_Building_Controller_ID,HW_Lot_Type,HW_Status_Id,HW_Status_Alarm_Id,HW_Lot_Name) "
        ssql &= "values('1','" & HW_New_ADD & "','" & Building_ID & "','" & floor_no & "','" & ZCU_ID & "','0','1','L','0','0','" & HW_Name & "')"
        If cdb.ExcuteNoneQury(ssql, ConStr_Guidance) = False Then
            MsgBox("ไม่สามารถเพิ่มลงฐานข้อมูลได้")
            Exit Sub
        End If


        Dim PositionX As Integer = 20 ' X not < 750 20
        Dim PositionY As Integer = 26 ' 26
        Dim sql As String = ""
        Dim i As Short = 0

        Dim btn_2 As New Label
        Dim Tag As String = ""
        Dim I_Index As Integer = 0

        With btn_2
            Tag = Mid(TextBox1.Text, 4, 8)
            .BackColor = Color.FromArgb(255, 0, 0, 0)
            .Size = New System.Drawing.Size(9, 9)
            .Location = New System.Drawing.Point(0, 0)
            .Text = TextBox1.Text
            .Tag = Tag
            .Name = TextBox1.Text
            .Parent = Me
            AddHandler .MouseDoubleClick, AddressOf Me.Button_DoubleClick
            AddHandler .Click, AddressOf Me.Button_Click
            AddHandler .MouseDown, AddressOf nodebtn_MouseDown
            AddHandler .MouseMove, AddressOf nodebtn_MouseMove
            AddHandler .MouseUp, AddressOf nodebtn_MouseUp

            Pic_ID_2.Controls.Add(btn_2)
            .BringToFront()
        End With


        Panel1.Visible = False
        Application.DoEvents()
        Button3.Enabled = True
    End Sub
    Private Function Function_New_Lot_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ

        Dim F_ID As String = ""
        Try
            Dim sql As String = "select TOP 1 (HW_Lot_Id) from Mas_Lot ORDER BY HW_Lot_Id DESC"
            'Dim sql As String = "select TOP 1 Floor_Id from Mas_HW_Floor ORDER BY Floor_Id"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If dt.Rows.Count > 0 Then
                F_ID = dt.Rows(0).Item(0).ToString
                F_ID = Format(F_ID + 1, "0000")
            Else
                F_ID = "0001"
            End If

        Catch ex As Exception
            F_ID = "0001"
        End Try
        Return F_ID
    End Function

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        st_x = cursor_position_X
        st_y = cursor_position_y
        Label8.Text = "X=" & cursor_position_X & " ,Y=" & cursor_position_y
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim sql As String = ""
        If TextBox1.Text <> "รหัสอุปกรณ์ :" Then
            sql = "DELETE FROM [Mas_Lot] WHERE [HW_Lot_Id]='" & HW_Current_ID.Name & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox("ลบสำเร็จ")
                Load_(floor_no, Building_ID, ZCU_ID)
            Else
                MsgBox("ไม่สามารถลบได้")
            End If
        End If

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim a As Integer = 0
        a = Cmb_ZCU2.SelectedValue.ToString.Trim
        Load_(floor_no, Building_ID, Cmb_ZCU2.SelectedValue.ToString.Trim)
        Cmb_ZCU2.SelectedValue = a
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub


    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Start ? End ?")
            Exit Sub
        End If

        If TextBox2.Text > TextBox3.Text Then
            MsgBox("Start > End")
            Exit Sub
        End If

        If cmb_asc.SelectedIndex = 0 Then
            Auto_position(TextBox2.Text.Trim, TextBox3.Text.Trim, TextBox5.Text, " ASC")
        End If
        If cmb_asc.SelectedIndex = 1 Then
            Auto_position(TextBox2.Text.Trim, TextBox3.Text.Trim, TextBox5.Text, " DESC")
        End If
    End Sub
    Sub Auto_position(ByVal HW_lot_id_st As String, ByVal HW_lot_id_end As String, ByVal space_ As String, ByVal sort As String)
        Try
            Dim sql As String = ""
            sql = " SELECT HW_Lot_Id "
            sql &= " FROM Q_Mas_Lot "
            sql &= " where HW_Lot_Type='L' and HW_Building_ID='" & Building_ID & "' and Floor_No = '" & floor_no & "'"
            If ZCU_ID <> "" Then
                sql &= " and HW_Floorcontroller_Id ='" & ZCU_ID & "'"
            End If
            sql &= " And HW_Lot_Id BETWEEN '" & HW_lot_id_st & "' and '" & HW_lot_id_end & "'"
            sql &= " order by HW_Lot_Id " & sort

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If dt.Rows.Count > 0 Then
                Dim i_count As Integer = 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    For Each btn_ As PictureBox In Pic_ID_2.Controls
                        If btn_.Name = dt.Rows(i).Item("HW_Lot_Id").ToString Then
                            btn_.Location = New Point(node_end_x + (i_count * space_), node_end_Y)
                            i_count = i_count + 1
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox("Auto_position : " & ex.Message)
        End Try
    End Sub
    Sub Auto_update_position(ByVal HW_lot_id_st As String, ByVal HW_lot_id_end As String)
        Try
            Dim sql As String = ""
            sql = " SELECT HW_Lot_Id "
            sql &= " FROM Q_Mas_Lot "
            sql &= " where HW_Lot_Type='L' and HW_Building_ID='" & Building_ID & "' and Floor_No = '" & floor_no & "'"
            If ZCU_ID <> "" Then
                sql &= " and HW_Floorcontroller_Id ='" & ZCU_ID & "'"
            End If
            sql &= " And HW_Lot_Id BETWEEN '" & HW_lot_id_st & "' and '" & HW_lot_id_end & "'"
            sql &= " order by HW_Lot_Id"

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If dt.Rows.Count > 0 Then
                Dim i_count As Integer = 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    For Each btn_ As PictureBox In Pic_ID_2.Controls
                        If btn_.Name = dt.Rows(i).Item("HW_Lot_Id").ToString Then
                            sql = "UPDATE Mas_Lot SET HW_Position_X='" & btn_.Location.X + 10 & "',HW_Position_Y='" & btn_.Location.Y + 30 & "' WHERE [HW_Lot_Id]='" & btn_.Name & "'"
                            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then

                            End If
                        End If
                    Next
                Next
            End If
            MsgBox("update successs")
        Catch ex As Exception
            MsgBox("Auto_position : " & ex.Message)
        End Try
    End Sub
    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        TextBox2.Text = HW_Current_ID.Name
        node_end_x = node_start_x
        node_end_Y = node_start_Y
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        TextBox3.Text = HW_Current_ID.Name
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Start ? End ?")
            Exit Sub
        End If

        If TextBox2.Text > TextBox3.Text Then
            MsgBox("Start > End")
            Exit Sub
        End If
        Auto_update_position(TextBox2.Text.Trim, TextBox3.Text.Trim)
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        If TextBox4.Text <> "" Then
            Frm_Direction_Car.ShowDialog()
            If Direction_Select <> "" Then
                For Each btn_ As PictureBox In Pic_ID_2.Controls
                    If btn_.Name = TextBox4.Text.Trim Then
                        Add_Control(btn_, btn_.Name, btn_.Location.X, btn_.Location.Y, Direction_Select, "", Direction_Select)
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'DETAIL 
        ' cast sender to menuitem
        Dim mi = CType(sender, ToolStripMenuItem)
        ' cast mi.Owner to CMS
        Dim cms = CType(mi.Owner, ContextMenuStrip)
        'MsgBox(cms.SourceControl.Name)

        Dim frm As New Dg_UD_Detail
        frm.UD_Id = cms.SourceControl.Name
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub ลบUDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ลบUDToolStripMenuItem.Click
        'DELETE 
        ' cast sender to menuitem
        Dim mi = CType(sender, ToolStripMenuItem)
        ' cast mi.Owner to CMS
        Dim cms = CType(mi.Owner, ContextMenuStrip)
        Dim frm As New Dg_msg_Ok_Cancle
        frm.message = "คุณต้องการลบ UD ID[" & cms.SourceControl.Name & "] ใช่หรือไม่"
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            delete_UD("", cms.SourceControl.Name)
        End If
        'MsgBox(cms.SourceControl.Name)
    End Sub

    Private Sub ตงคาปดเปดไฟToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ตงคาปดเปดไฟToolStripMenuItem.Click
        'ON_OFF 
        ' cast sender to menuitem
        Dim mi = CType(sender, ToolStripMenuItem)
        ' cast mi.Owner to CMS
        Dim cms = CType(mi.Owner, ContextMenuStrip)
        MsgBox(cms.SourceControl.Name)
    End Sub

    Sub delete_UD(ByVal zcu_id As String, ByVal UD_id As String)
        Try
            Dim sql As String = ""
            If zcu_id = "" Then
                sql = "DELETE FROM [Mas_Lot] WHERE HW_Lot_Id='" & UD_id & "'"
            Else
                If UD_id = "" Then
                    sql = "DELETE FROM [Mas_Lot] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "'"
                Else
                    sql = "DELETE FROM [Mas_Lot] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "' And HW_Lot_Id='" & UD_id & "'"
                End If
            End If


            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception
            MsgBox("delete_UD : " & ex.Message)
        End Try

    End Sub
End Class