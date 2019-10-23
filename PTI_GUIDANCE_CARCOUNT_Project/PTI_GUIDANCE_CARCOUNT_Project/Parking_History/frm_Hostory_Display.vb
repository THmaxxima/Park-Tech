Imports System.Threading
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frm_Hostory_Display
    Friend Floor_Selected_ID As String
    Dim ClsSqlCmd As ClassCommandSql


    Dim Count_Red As Integer
    Dim Count_Green As Integer
    Dim Count As Integer
    Dim A, R, G, B As Integer
    Dim btn(4500) As Label
    Dim lbl_Zone(800) As Label
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

    Private Sub frm_Hostory_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClsSqlCmd = New ClassCommandSql
        Call mMain.Load_AppConfig()

        If Floor_Selected_ID = "" Then Floor_Selected_ID = "1"
        sql = "" & " update Mas_Lot_History set HW_Status_Alarm_Id = 0 "
        sql &= " ,HW_Time_HH = 0 ,HW_Time_MM = 0 ,HW_Status_Id=0 "
        Excute_SQL(ConStr_Guidance, sql)

        Call Show_Picture_Floor() '###  Step 1 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Call Tab_Floor_Name() '###  Step 2 แสดงชื่อชั้นจอดรถ ทุกชั้น
        Call Load_Button_New() '###  Step 3 Load Ultrasonic มาแสดง
        Call Load_Board_Zone_Name(Floor_Selected_ID) '###  Step 4 ป้ายชื่อชั้น จอดรถ มาแสดง
        Call Select_Color_Status_Alam_Value(Floor_Selected_ID) '###  Step 5 แสดงสถานะรถจอด แต่ละประเภท เช่น ว่าง,จอด,อุปกรณ์ขัดข้อง
        Call Floor_Name_In_Other_Floor(Public_Building_ID, Floor_Selected_ID) 'Step 6 แสดง สถานะรถจอด ของททุกชั้น ในอาคารจอดรถ ปัจจุบัน
        '  Call Load_Board_Zone(Floor_Selected_ID) 'Step 7 โหลดบอร์ดแสดงจำนวนรถ แต่ละโซน




        Tab_Building.SelectedTabIndex = 0
        If Tab_Building.SelectedTabIndex = 0 Then
            lbl_Floor_7.Visible = False
            lbl_Percent_IN_Floor_7.Visible = False
            lbl_Bar_IN_Floor_7.Visible = False
            Label5.Visible = False
            lbl_Percent_Remain_Floor_7.Visible = False
        Else
            lbl_Floor_7.Visible = True
            lbl_Percent_IN_Floor_7.Visible = True
            lbl_Bar_IN_Floor_7.Visible = True
            Label5.Visible = True
            lbl_Percent_Remain_Floor_7.Visible = True
        End If
    End Sub
    Sub Show_Picture_Floor()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        sql = "Select Floor_Image,Floor_Id from Mas_Floor "
        sql &= " ORDER BY "
        sql &= " CASE WHEN LEFT(Floor_Id, 1) BETWEEN '0' AND '9' THEN ' ' ELSE LEFT(Floor_Id, 1) END, "
        sql &= " CAST(STUFF(Floor_Id, 1, CASE WHEN LEFT(Floor_Id, 1) BETWEEN '0' AND '9' THEN 0 ELSE 1 END, '') AS int)"

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
                            Select Case .Fields("Floor_Id").Value.ToString
                                Case "1"
                                    Pic_ID_1.Image = Image.FromStream(Ms)
                                Case "2"
                                    Pic_ID_2.Image = Image.FromStream(Ms)
                                Case "3"
                                    Pic_ID_3.Image = Image.FromStream(Ms)
                                Case "4"
                                    Pic_ID_4.Image = Image.FromStream(Ms)
                                Case "5"
                                    Pic_ID_5.Image = Image.FromStream(Ms)
                                Case "6"
                                    Pic_ID_6.Image = Image.FromStream(Ms)
                                Case "7"
                                    Pic_ID_7.Image = Image.FromStream(Ms)
                                Case "8"
                                    Pic_ID_8.Image = Image.FromStream(Ms)
                                Case "9"
                                    Pic_ID_9.Image = Image.FromStream(Ms)
                                Case "10"
                                    Pic_ID_10.Image = Image.FromStream(Ms)
                                Case "11"
                                    Pic_ID_11.Image = Image.FromStream(Ms)
                                Case "12"
                                    Pic_ID_12.Image = Image.FromStream(Ms)
                            End Select


                        Else
                            Select Case .Fields("Floor_Id").Value.ToString
                                Case "1"
                                    Pic_ID_1.Image = Pic_ID_1.ErrorImage
                                Case "2"
                                    Pic_ID_2.Image = Pic_ID_2.ErrorImage
                                Case "3"
                                    Pic_ID_3.Image = Pic_ID_3.ErrorImage
                                Case "4"
                                    Pic_ID_4.Image = Pic_ID_4.ErrorImage
                                Case "5"
                                    Pic_ID_5.Image = Pic_ID_5.ErrorImage
                                Case "6"
                                    Pic_ID_6.Image = Pic_ID_6.ErrorImage
                                Case "7"
                                    Pic_ID_7.Image = Pic_ID_7.ErrorImage
                                Case "8"
                                    Pic_ID_8.Image = Pic_ID_8.ErrorImage
                                Case "9"
                                    Pic_ID_9.Image = Pic_ID_9.ErrorImage
                                Case "10"
                                    Pic_ID_10.Image = Pic_ID_10.ErrorImage
                                Case "11"
                                    Pic_ID_11.Image = Pic_ID_11.ErrorImage
                                Case "12"
                                    Pic_ID_12.Image = Pic_ID_12.ErrorImage
                            End Select

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
        Call mError.ShowError(Me.Name, "Show_Picture_Floor", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
    End Sub
    Sub Tab_Floor_Name() 'ชื่อของชั้นของแท็บ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT * FROM Mas_Floor "
            sql &= " ORDER BY "
            sql &= " CASE WHEN LEFT(Floor_Id, 1) BETWEEN '0' AND '9' THEN ' ' ELSE LEFT(Floor_Id, 1) END, "
            sql &= " CAST(STUFF(Floor_Id, 1, CASE WHEN LEFT(Floor_Id, 1) BETWEEN '0' AND '9' THEN 0 ELSE 1 END, '') AS int)"
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
                            Select Case .Fields("Floor_Id").Value.ToString
                                Case "1"
                                    Tab_ParkingA.Controls.Item(0).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingA.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                Case "2"
                                    Tab_ParkingA.Controls.Item(1).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingA.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                Case "3"
                                    Tab_ParkingA.Controls.Item(2).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingA.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                Case "4"
                                    Tab_ParkingA.Controls.Item(3).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingA.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                Case "5"
                                    Tab_ParkingA.Controls.Item(4).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingA.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                Case "6"
                                    Tab_ParkingA.Controls.Item(5).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingA.Controls.Item(5).Text = .Fields("Floor_Name").Value
                                Case "7"
                                    Tab_ParkingD.Controls.Item(0).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingD.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                Case "8"
                                    Tab_ParkingD.Controls.Item(1).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingD.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                Case "9"
                                    Tab_ParkingD.Controls.Item(2).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingD.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                Case "10"
                                    Tab_ParkingD.Controls.Item(3).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingD.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                Case "11"
                                    Tab_ParkingD.Controls.Item(4).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingD.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                Case "12"
                                    Tab_ParkingD.Controls.Item(5).Tag = .Fields("Floor_No").Value
                                    Tab_ParkingD.Controls.Item(5).Text = .Fields("Floor_Name").Value
                            End Select

                            .MoveNext()
                        Loop
                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Tab_Floor_Name", Err.Number, Err.Description)
        End Try
    End Sub
    Function Show_Picture(ByVal Floor_ID As String, Optional ByVal Tower_ID As String = "") As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Select Case Floor_ID
            Case 1
                Pic_ID_1.Controls.Clear()
            Case 2
                Pic_ID_2.Controls.Clear()
            Case 3
                Pic_ID_3.Controls.Clear()
            Case 4
                Pic_ID_4.Controls.Clear()
            Case 5
                Pic_ID_5.Controls.Clear()
            Case 6
                Pic_ID_6.Controls.Clear()
            Case 7
                Pic_ID_7.Controls.Clear()
            Case 8
                Pic_ID_8.Controls.Clear()
            Case 9
                Pic_ID_9.Controls.Clear()
            Case 10
                Pic_ID_10.Controls.Clear()
            Case 11
                Pic_ID_11.Controls.Clear()
            Case 12
                Pic_ID_12.Controls.Clear()
        End Select

        If Tower_ID <> "" Then
            sql = "Select Floor_Image from Mas_Floor WHERE Floor_Id =" & Floor_ID & " and Building_ID = '" & Tower_ID & "'"
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

                        Select Case Floor_ID
                            Case 1
                                Pic_ID_1.Image = Image.FromStream(Ms)
                            Case 2
                                Pic_ID_2.Image = Image.FromStream(Ms)
                            Case 3
                                Pic_ID_3.Image = Image.FromStream(Ms)
                            Case 4
                                Pic_ID_4.Image = Image.FromStream(Ms)
                            Case 5
                                Pic_ID_5.Image = Image.FromStream(Ms)
                            Case 6
                                Pic_ID_6.Image = Image.FromStream(Ms)
                            Case 7
                                Pic_ID_7.Image = Image.FromStream(Ms)
                            Case 8
                                Pic_ID_8.Image = Image.FromStream(Ms)
                            Case 9
                                Pic_ID_9.Image = Image.FromStream(Ms)
                            Case 10
                                Pic_ID_10.Image = Image.FromStream(Ms)
                            Case 11
                                Pic_ID_11.Image = Image.FromStream(Ms)
                            Case 12
                                Pic_ID_12.Image = Image.FromStream(Ms)
                        End Select

                    Else
                        Select Case Floor_ID
                            Case 1
                                Pic_ID_1.Image = Pic_ID_1.ErrorImage
                            Case 2
                                Pic_ID_2.Image = Pic_ID_2.ErrorImage
                            Case 3
                                Pic_ID_3.Image = Pic_ID_3.ErrorImage
                            Case 4
                                Pic_ID_4.Image = Pic_ID_4.ErrorImage
                            Case 5
                                Pic_ID_5.Image = Pic_ID_5.ErrorImage
                            Case 6
                                Pic_ID_6.Image = Pic_ID_6.ErrorImage
                            Case 7
                                Pic_ID_7.Image = Pic_ID_7.ErrorImage
                            Case 8
                                Pic_ID_8.Image = Pic_ID_8.ErrorImage
                            Case 9
                                Pic_ID_9.Image = Pic_ID_9.ErrorImage
                            Case 10
                                Pic_ID_10.Image = Pic_ID_10.ErrorImage
                            Case 11
                                Pic_ID_11.Image = Pic_ID_11.ErrorImage
                            Case 12
                                Pic_ID_12.Image = Pic_ID_12.ErrorImage
                        End Select

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
    Sub Load_Button_New()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim PositionX As Integer = 20 ' X not < 750 20
        Dim PositionY As Integer = 26 ' 26
        Dim sql As String = ""
        Dim i As Short = 0
        I_Index = 0
        Try
            'For i = 1 To mFloor
            '     Me.Show_Picture(FloorID, Tab_Building.SelectedTab.Tag)
            sql = " SELECT distinct HW_Lot_Id,HW_Status_Id,HW_Position_X,HW_Position_Y,Floor_Name, " & _
                  " Status_Alarm_Color_A, Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B "
            sql &= " ,HW_Building_ID,HW_Floor_No "
            sql &= " FROM Q_Mas_Lot_History "
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
                            Tag = Mid(rs.Fields("HW_Lot_Id").Value, 4, 8)
                            I_Index += 1
                            btn(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                            With Me.btn(I_Index)
                                .Size = New Size(Public_Size_X, Public_Size_Y) 'ขนาด button
                                .Name = rs.Fields("HW_Lot_Id").Value  'ชื่อ button
                                .Tag = Tag
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.TopCenter
                                .Cursor = Cursors.Hand
                                .TabIndex = I_Index
                                A = rs.Fields("Status_Alarm_Color_A").Value
                                R = rs.Fields("Status_Alarm_Color_R").Value
                                G = rs.Fields("Status_Alarm_Color_G").Value
                                B = rs.Fields("Status_Alarm_Color_B").Value
                                .BackColor = Color.FromArgb(A, R, G, B)
                                If rs.Fields("HW_Status_Id").Value = 0 _
                                   And rs.Fields("HW_Position_X").Value <> 0 _
                                   And rs.Fields("HW_Position_Y").Value <> 0 Then
                                    .Location = New Point(rs.Fields("HW_Position_X").Value, rs.Fields("HW_Position_Y").Value)
                                Else
                                    .Location = New Point(rs.Fields("HW_Position_X").Value, rs.Fields("HW_Position_Y").Value) 'ตำแหน่ง button X,Y HW_Position_X
                                    If rs.Fields("HW_Position_X").Value = 0 And rs.Fields("HW_Position_Y").Value = 0 Then
                                        .Visible = False
                                    End If
                                End If
                                .Parent = Me
                                '  AddHandler .Click, AddressOf Me.Button_Click
                                Select Case rs.Fields("HW_Building_ID").Value
                                    Case "1"
                                        Select Case rs.Fields("HW_Floor_No").Value 'FloorID 'HW_Floor_No
                                            Case "1"
                                                Me.Pic_ID_1.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "2"
                                                Me.Pic_ID_2.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "3"
                                                Me.Pic_ID_3.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "4"
                                                Me.Pic_ID_4.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "5"
                                                Me.Pic_ID_5.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "6"
                                                Me.Pic_ID_6.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                        End Select
                                    Case "2"
                                        Select Case rs.Fields("HW_Floor_No").Value 'FloorID 'HW_Floor_No
                                            Case "1"
                                                Me.Pic_ID_7.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "2"
                                                Me.Pic_ID_8.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "3"
                                                Me.Pic_ID_9.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "4"
                                                Me.Pic_ID_10.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "5"
                                                Me.Pic_ID_11.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                            Case "6"
                                                Me.Pic_ID_12.Controls.Add(btn(I_Index)) 'เพิ่ม Button
                                        End Select
                                End Select
                            End With
                            .MoveNext()
                        Loop
                    End If
                End With
            End If
            'Next
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "เพิ่ม Lot Sensor Error ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Load_Board_Zone_Name(Optional ByVal FloorID As String = "")
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0

        Try
            sql = "SELECT * " & _
                  "FROM Mas_Floor_Zone_Name where F_Floor_Id =" & FloorID & " order by F_Zone_Id"
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
                                Select Case FloorID
                                    Case "1"
                                        Me.Pic_ID_1.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "2"
                                        Me.Pic_ID_2.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "3"
                                        Me.Pic_ID_3.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "4"
                                        Me.Pic_ID_4.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "5"
                                        Me.Pic_ID_5.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "6"
                                        Me.Pic_ID_6.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "7"
                                        Me.Pic_ID_7.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "8"
                                        Me.Pic_ID_8.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "9"
                                        Me.Pic_ID_9.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "10"
                                        Me.Pic_ID_10.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "11"
                                        Me.Pic_ID_11.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                    Case "12"
                                        Me.Pic_ID_12.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                End Select

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
    Sub Select_Color_Status_Alam_Value(Optional ByVal FloorID As String = "", Optional ByVal Building_ID As String = "")
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

                        'If Status_Alarm_Time_Min <> "0" Or Status_Alarm_Time_Max <> "0" Then
                        '    Carparking = mCountCar.Get_Status_Color_Alam(Status_Alarm_Time_Min, Status_Alarm_Time_Max, FloorID, Public_Building_ID)
                        'ElseIf Status_Alarm_Time_Min = "0" And Status_Alarm_Time_Max = "0" Then
                        '    Carparking = mCountCar.Get_Status_Color_Alam_False(Status_Alarm_Time_Min, Status_Alarm_Time_Max, FloorID, Public_Building_ID)
                        'End If
                        Select Case Id
                            'Case "0"
                            '    lbl_Status_Green.Text = .Fields("Status_Alarm_Name").Value 'ไม่มีรถจอด
                            '    lbl_Color_Green.BackColor = Color.FromArgb(A, R, G, B)
                            'Case "1"
                            '    lbl_Status_Red.Text = .Fields("Status_Alarm_Name").Value 'มีรถจอด แต่ไม่เกิน เวลาที่กำหนด เช่น จอดไม่เกิน 15 นาที
                            '    lbl_Color_Red.BackColor = Color.FromArgb(A, R, G, B)
                            'Case "2"
                            '    lbl_Color_False.BackColor = Color.FromArgb(A, R, G, B)
                            '    Dim Alam As String = mCountCar.Get_Count_Alam("2", FloorID) 'อุปกรณ์ขัดข้อง
                            '    lbl_Status_False.Text = ""
                            '    lbl_Status_False.Text = .Fields("Status_Alarm_Name").Value & " : " & Carparking
                            Case "3"
                                lbl_Color_Status1.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("3", FloorID, Building_ID)
                                lbl_Status_1.Text = ""
                                lbl_Status_1.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "4"
                                lbl_Color_Status2.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("4", FloorID, Building_ID)
                                lbl_Status_2.Text = ""
                                lbl_Status_2.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "5"
                                lbl_Color_Status3.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("5", FloorID, Building_ID)
                                lbl_Status_3.Text = ""
                                lbl_Status_3.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "6"
                                lbl_Color_Status4.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("6", FloorID, Building_ID)
                                lbl_Status_4.Text = ""
                                lbl_Status_4.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "7"
                                lbl_Color_Status5.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("7", FloorID, Building_ID)
                                lbl_Status_5.Text = ""
                                lbl_Status_5.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "8"
                                lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("8", FloorID, Building_ID)
                                lbl_Status_6.Text = ""
                                lbl_Status_6.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam

                            Case "9"
                                lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("9", FloorID, Building_ID)
                                lbl_Status_7.Text = ""
                                lbl_Status_7.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "10"
                                lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("10", FloorID, Building_ID)
                                lbl_Status_8.Text = ""
                                lbl_Status_8.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "11"
                                lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("11", FloorID, Building_ID)
                                lbl_Status_9.Text = ""
                                lbl_Status_9.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam
                            Case "12"
                                lbl_Color_Status6.BackColor = Color.FromArgb(A, R, G, B)
                                Dim Alam As String = "" & mHistory.Get_Count_AlamHistory("12", FloorID, Building_ID)
                                lbl_Status_10.Text = ""
                                lbl_Status_10.Text = .Fields("Status_Alarm_Name").Value & " : " & Alam

                        End Select
                        .MoveNext()
                    Loop
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Select_Color_Status_Alam_Value", Err.Number, Err.Description)
    End Sub
    Sub Floor_Name_In_Other_Floor(Optional ByVal Building_ID As String = Nothing, Optional ByVal Floor_No As String = Nothing) 'ชื่อของชั้นอื่น
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim With_Bar As Integer
        With_Bar = 99
        Dim Car_Green, Car_Red, Total, Percent_Green, Width_Green As Integer

        Try
            sql = "SELECT * FROM Mas_Floor where Building_ID = " & Building_ID & " "
            ''  sql &= " and  HW_Floor_No = " & Floor_No & ""
            sql &= "  order by "
            sql &= " CASE WHEN LEFT(Floor_Id, 1) BETWEEN '0' AND '9' THEN ' ' ELSE LEFT(Floor_Id, 1) END, "
            sql &= " CAST(STUFF(Floor_Id, 1, CASE WHEN LEFT(Floor_Id, 1) BETWEEN '0' AND '9' THEN 0 ELSE 1 END, '') AS int)"

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
                            Car_Green = 0
                            Car_Red = 0
                            Total = 0
                            Width_Green = 0
                            Percent_Green = 0
                            Try

                                Select Case rs.Fields("Floor_Id").Value.ToString
                                    Case "1"
                                        lbl_Floor_1.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_1.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_1.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_1.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100
                                        lbl_Percent_IN_Floor_1.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_1.Text = Car_Red & "(" & 100 - Percent_Green & "%)"
                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_1.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If
                                    Case "2"
                                        lbl_Floor_2.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_2.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_2.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_2.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100
                                        lbl_Percent_IN_Floor_2.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_2.Text = Car_Red & "(" & 100 - Percent_Green & "%)"
                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_2.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If


                                    Case "3"
                                        lbl_Floor_3.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_3.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_3.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_3.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100
                                        lbl_Percent_IN_Floor_3.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_4.Text = Car_Red & "(" & 100 - Percent_Green & "%)"
                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_3.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If


                                    Case "4"
                                        lbl_Floor_4.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_4.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_4.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_4.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_4.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_4.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_4.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If


                                    Case "5"
                                        lbl_Floor_5.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_5.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_5.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_5.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_5.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_5.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_5.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "6"
                                        lbl_Floor_6.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_6.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_6.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_6.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_6.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_6.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_6.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "7"
                                        lbl_Floor_1.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_1.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_1.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_1.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100
                                        lbl_Percent_IN_Floor_1.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_1.Text = Car_Red & "(" & 100 - Percent_Green & "%)"
                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_1.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "8"
                                        lbl_Floor_2.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_2.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_2.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_2.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100
                                        lbl_Percent_IN_Floor_2.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_2.Text = Car_Red & "(" & 100 - Percent_Green & "%)"
                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_2.Width = Width_Green

                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "9"
                                        lbl_Floor_3.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_3.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_3.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_3.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100
                                        lbl_Percent_IN_Floor_3.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_4.Text = Car_Red & "(" & 100 - Percent_Green & "%)"
                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_3.Width = Width_Green


                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "10"
                                        lbl_Floor_4.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_4.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_4.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_4.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_4.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_4.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_4.Width = Width_Green


                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "11"
                                        lbl_Floor_5.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_5.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_5.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_5.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_5.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_5.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_5.Width = Width_Green


                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "12"
                                        lbl_Floor_6.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_6.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_6.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_6.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_6.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_6.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_6.Width = Width_Green


                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "13"
                                        lbl_Floor_7.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_7.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_7.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_7.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_7.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_7.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_7.Width = Width_Green


                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                    Case "14"
                                        lbl_Floor_7.Tag = rs.Fields("Floor_Id").Value
                                        lbl_Floor_7.Text = rs.Fields("Floor_Name").Value

                                        Car_Green = mHistory.Get_Count_History("0", lbl_Floor_7.Tag, Building_ID)
                                        Car_Red = mHistory.Get_Count_History("1", lbl_Floor_7.Tag, Building_ID)
                                        Total = Val(Car_Green) + Val(Car_Red)

                                        Percent_Green = (Val(Car_Green) / Val(Total)) * 100

                                        lbl_Percent_IN_Floor_7.Text = Car_Green & "(" & Percent_Green & "%)"
                                        lbl_Percent_Remain_Floor_7.Text = Car_Red & "(" & 100 - Percent_Green & "%)"

                                        Width_Green = (With_Bar * Val(Car_Green)) / Val(Total)
                                        lbl_Bar_IN_Floor_7.Width = Width_Green


                                        If rs.Fields("Floor_Id").Value.ToString = Public_Floor_NO Then
                                            lbl_Parking_All.Text = "" & Total
                                            lbl_Lot_Empty.Text = "" & Car_Green
                                            lbl_Parking_In_Floor.Text = "" & Car_Red
                                            Percent_Green = 0
                                            Percent_Green = (Val(lbl_Lot_Empty.Text) / Val(lbl_Parking_All.Text)) * 100
                                            lbl_Percent_Parking_IN_Floor.Text = "(" & Percent_Green & "%)"
                                            lbl_Percent_Remain_In_Floor.Text = "(" & 100 - Percent_Green & "%)"
                                            Width_Green = (196 * Val(lbl_Lot_Empty.Text)) / Val(lbl_Parking_All.Text)
                                            lbl_Green.Width = Width_Green
                                        End If

                                End Select

                            Catch ex As Exception

                            End Try
                            .MoveNext()
                        Loop

                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Floor_Name_In_Other_Floor", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Load_Board_Zone(Optional ByVal FloorID As String = Nothing)
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        '  Dim i As Integer
        Try
            'For i = 1 To mFloor
            sql = "SELECT * " & _
                  "FROM Mas_Floor_Zone where Floor_Id =" & FloorID & "  order by Zone_Id    "
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
                                Dim Value_Zone As String = mCountCar.Get_Count_CarInZone(rs.Fields("Zone_Id").Value, Floor_Selected_ID, Tab_Building.SelectedTab.Tag)
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
                                Select Case rs.Fields("Floor_Id").Value.ToString
                                    Case "1"
                                        Me.Pic_ID_1.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "2"
                                        Me.Pic_ID_2.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "3"
                                        Me.Pic_ID_3.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "4"
                                        Me.Pic_ID_4.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "5"
                                        Me.Pic_ID_5.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "6"
                                        Me.Pic_ID_6.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "7"
                                        Me.Pic_ID_7.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "8"
                                        Me.Pic_ID_8.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "9"
                                        Me.Pic_ID_9.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "10"
                                        Me.Pic_ID_10.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "11"
                                        Me.Pic_ID_11.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                    Case "12"
                                        Me.Pic_ID_12.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                End Select
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
    Sub Capture_Screen()
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        PictureBox1.Image = screenshot

        If Dir(My.Application.Info.DirectoryPath & "\ScreenLOG", FileAttribute.Directory) = "" Then MkDir((My.Application.Info.DirectoryPath & "\ScreenLOG"))
        Me.PictureBox1.Image.Save(My.Application.Info.DirectoryPath & "\ScreenLOG\capture.bmp")
        If MessageBox.Show("คุณต้องการบันทึกรูปภาพหน้าต่างการทำงานนี้ใช่หรือไม่ ???? ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Save_Capture_Screen_Parking_Quantity() ' บันทึกรูปภาพ
        Else
            Kill(My.Application.Info.DirectoryPath & "\ScreenLOG\capture.bmp")
        End If
    End Sub
    Sub Save_Capture_Screen_Parking_Quantity()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim sqlStr As String = ""
        Dim Log_ID As String = ""
        Dim LogDate As String = ""

        Log_ID &= DTPickerSt.Value.Year ' Format(Now, "yyyyMMddhhmmss")
        Log_ID &= GenMonth(DTPickerSt.Value.Month)
        Log_ID &= GenMonth(DTPickerSt.Value.Day)
        Log_ID &= GenMonth(TimeIn.Value.Hour)
        Log_ID &= GenMonth(TimeIn.Value.Minute)
        Log_ID &= GenMonth(TimeIn.Value.Second)

        Log_ID &= DTPickerEnd.Value.Year ' Format(Now, "yyyyMMddhhmmss")
        Log_ID &= GenMonth(DTPickerEnd.Value.Month)
        Log_ID &= GenMonth(DTPickerEnd.Value.Day)
        Log_ID &= GenMonth(TimeOut.Value.Hour)
        Log_ID &= GenMonth(TimeOut.Value.Minute)
        Log_ID &= GenMonth(TimeOut.Value.Second)



        sql &= " insert into [Mas_Capture_Screen]"
        sql &= "([Log_ID]"
        sqlStr &= " VALUES('" & Log_ID & "'"

        sql &= ",[Log_Tower_ID]"
        sqlStr &= ",'" & Cur_Tower_ID & "'"
        sql &= ",[Log_Building_ID]"
        sqlStr &= ",'" & Public_Building_ID & "'"
        sql &= ",[Log_Floor_No]"
        sqlStr &= ",'" & Public_Floor_NO & "'"
        sql &= ",[Log_Date]"
        sqlStr &= "," & mDB.DBFormatDate(LogDate) & ""

        sql &= ",[Log_Days]"
        sqlStr &= ",'" & GenMonth(DTPickerSt.Value.Day) & "'"


        sql &= ",[Log_Month]"
        sqlStr &= ",'" & GenMonth(DTPickerSt.Value.Month) & "'"
        sql &= ",[Log_Years]"
        sqlStr &= ",'" & DTPickerSt.Value.Year & "'"

        'If Rdo_Month.Checked = True Then
        '    sql &= ",[Log_Conditon_DayMonth] "
        '    sqlStr &= ",'" & Rdo_Month.Text & "'"
        'End If
        'If rdo_Day.Checked = True Then
        '    sql &= ",[Log_Conditon_DayMonth] "
        '    sqlStr &= ",'" & rdo_Day.Text & "'"
        'End If

        'If rdo_Many.Checked = True Then
        '    sql &= ",[Log_Conditon_ManyTime] "
        '    sqlStr &= ",'" & rdo_Many.Text & "'"
        '    sql &= ",[Log_Average_Parking]"
        '    sqlStr &= ",'" & CInt((DgvDetail.RowCount - 1)) \ CDbl((lbl_Max_Parking.Text)) & "'"
        '    sql &= ",[Log_Parking_Values]"
        '    sqlStr &= ",'" & DgvDetail.RowCount - 1 & "'"
        '    sql &= ",[Log_Type_Parking]"
        '    sqlStr &= ",'MANY'"
        'End If

        'If rdo_Time.Checked = True Then
        '    sql &= ",[Log_Conditon_ManyTime] "
        '    sqlStr &= ",'" & rdo_Time.Text & "'"
        '    sql &= ",[Log_Average_Parking]"
        '    sqlStr &= ",'" & CInt((dgv_Time.RowCount - 1)) \ CDbl((lbl_Max_Parking.Text)) & "'"
        '    sql &= ",[Log_Parking_Values]"
        '    sqlStr &= ",'" & dgv_Time.RowCount - 1 & "'"
        sql &= ",[Log_Type_Parking]"
        sqlStr &= ",'PARKINGTIME'"
        'End If

        sql &= ",[Log_Max_Parking]"
        sqlStr &= ",'" & lbl_Max_Parking.Text & "'"
        sql &= ",[Log_Date_Time]"
        sqlStr &= "," & mDB.DBFormatDate(Now) & ""
        sql &= ",[Log_User_ID]"
        sqlStr &= ",'" & CurUser_ID & "'"
        sql &= ",[Log_User_Name]"
        sqlStr &= ",'" & R_User & "'"
        sql &= ",[Log_From]"
        sqlStr &= ",'" & Me.Name & "'"
        sql &= ",[Log_Process]"
        sqlStr &= ",'" & Me.Text & "'"
        sql &= ",[Log_Detail])"
        sqlStr &= ",'Capture Screen หน้าต่างเมนู : " & Me.Text & "'"
        sqlStr &= ")"
        mSql_Con.Excute_SQL(ConStr_Master, sql & sqlStr)
        Call mDB.Save_Pict_To_DB_No_Message(ConnStrMasTer, "Mas_Capture_Screen", "Log_ID", "Log_Picture", Log_ID, My.Application.Info.DirectoryPath & "\ScreenLOG\capture.bmp") 'Tmp_Save_Pict
        Kill(My.Application.Info.DirectoryPath & "\ScreenLOG\capture.bmp")
    End Sub


    Private Sub Tab_ParkingA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_ParkingA.SelectedIndexChanged
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If

            Call Select_Color_Status_Alam_Value(Public_Floor_NO, Public_Building_ID) '###  Step 5 แสดงสถานะรถจอด แต่ละประเภท เช่น ว่าง,จอด,อุปกรณ์ขัดข้อง
            Call Floor_Name_In_Other_Floor(Public_Building_ID, Public_Floor_NO) 'Step 6 แสดง สถานะรถจอด ของททุกชั้น ในอาคารจอดรถ ปัจจุบัน

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tab_ParkingD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_ParkingD.SelectedIndexChanged
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If
            Call Select_Color_Status_Alam_Value(Public_Floor_NO, Public_Building_ID) '###  Step 5 แสดงสถานะรถจอด แต่ละประเภท เช่น ว่าง,จอด,อุปกรณ์ขัดข้อง
            Call Floor_Name_In_Other_Floor(Public_Building_ID, Public_Floor_NO) 'Step 6 แสดง สถานะรถจอด ของททุกชั้น ในอาคารจอดรถ ปัจจุบัน

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tab_Building_SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles Tab_Building.SelectedTabChanged
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If
            If Tab_Building.SelectedTabIndex = 0 Then
                lbl_Floor_7.Visible = False
                lbl_Percent_IN_Floor_7.Visible = False
                lbl_Bar_IN_Floor_7.Visible = False
                Label5.Visible = False
                lbl_Percent_Remain_Floor_7.Visible = False
            Else
                lbl_Floor_7.Visible = True
                lbl_Percent_IN_Floor_7.Visible = True
                lbl_Bar_IN_Floor_7.Visible = True
                Label5.Visible = True
                lbl_Percent_Remain_Floor_7.Visible = True
            End If
            Call Select_Color_Status_Alam_Value(Public_Floor_NO, Public_Building_ID) '###  Step 5 แสดงสถานะรถจอด แต่ละประเภท เช่น ว่าง,จอด,อุปกรณ์ขัดข้อง
            Call Floor_Name_In_Other_Floor(Public_Building_ID, Public_Floor_NO) 'Step 6 แสดง สถานะรถจอด ของททุกชั้น ในอาคารจอดรถ ปัจจุบัน

        Catch ex As Exception
        End Try
    End Sub

  
    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        Dim HDateSt As String = ""
        Dim HDateEnd As String = ""

        sql = ""
        sql &= " select Floor_Lot_All from Mas_Floor"
        sql &= " where Building_ID = '" & Public_Building_ID & "'"
        sql &= " and  Floor_No  = '" & Public_Floor_NO & "'"

        lbl_Max_Parking.Text = "" & Get_Field_As_Select(ConnStrMasTer, sql)

        HDateSt = DTPickerSt.Value.ToShortDateString & " " & TimeIn.Text.ToString
        HDateEnd = DTPickerEnd.Value.ToShortDateString & " " & TimeOut.Text.ToString
        sql = "" & " update Mas_Lot_History set HW_Status_Alarm_Id = 1 "
        sql &= " ,HW_Time_HH = 0 ,HW_Time_MM = 0  " ', HW_Time_SS = 0
        Excute_SQL(ConStr_Guidance, sql)


        Call Select_Color_Status_Alam_Value(Public_Floor_NO, Public_Building_ID) '###  Step  แสดงสถานะรถจอด แต่ละประเภท เช่น ว่าง,จอด,อุปกรณ์ขัดข้อง
        Call Select_Sum_Lot_Parking(HDateSt, HDateEnd)
        Call History_Set_btn()
        Call Set_Color_btn()


        Call Select_Color_Status_Alam_Value(Public_Floor_NO, Public_Building_ID) '###  Step 5 แสดงสถานะรถจอด แต่ละประเภท เช่น ว่าง,จอด,อุปกรณ์ขัดข้อง
        Call Floor_Name_In_Other_Floor(Public_Building_ID, Public_Floor_NO) 'Step 6 แสดง สถานะรถจอด ของททุกชั้น ในอาคารจอดรถ ปัจจุบัน
        '  Floor_Name_In_Other_Floor()
        '  Call Load_Board_Zone(Floor_Selected_ID) 'Step 7 โหลดบอร์ดแสดงจำนวนรถ แต่ละโซน

    End Sub

    Sub Select_Sum_Lot_Parking(ByVal DateSatrt As String, ByVal DateEnd As String)
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
            sql = "select   [Trn_Lot_Id],[Trn_Park_HH],[Trn_Park_MM],[Trn_Park_SS]  from Transaction_Lot "
            sql &= " where  Trn_Log_Datetime_In >= " & mDB.DBFormatDate(DateSatrt) & " and Trn_Log_Datetime_In  <= " & mDB.DBFormatDate(DateEnd) & ""
            ' sql &= " and Trn_Log_Datetime_Out <= " & mDB.DBFormatDate(DateEnd) & " "
            'sql &= " and Building_ID = '" & Public_Building_ID & "'"
            'sql &= " and  Floor_No  = '" & Public_Floor_NO & "'"
            sql &= " order by Trn_Lot_Id "
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            '   sqlDs.Clear()
            sqlDa.Fill(sqlDs, "Transaction_Lot")
            DgvDetail.DataSource = sqlDs.Tables("Transaction_Lot")
            Con.Close()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub
  
    Sub History_Set_btn()
        Dim i As Integer
        If DgvDetail.RowCount - 1 > 0 Then
            If DgvDetail.RowCount - 1 > 0 Then
                ProgressBarX1.Visible = True
                ProgressBarX1.Maximum = DgvDetail.RowCount - 1
                ProgressBarX1.Value = 0
                For i = 0 To DgvDetail.RowCount - 1
                    Try
                        With DgvDetail
                            Lot_Id = "" & .Rows(i).Cells(0).Value.ToString()
                            sql = "" & " update Mas_Lot_History set HW_Time_HH = HW_Time_HH + " & .Rows(i).Cells(1).Value.ToString() & ""
                            sql &= ", HW_Time_MM = HW_Time_MM + " & .Rows(i).Cells(2).Value.ToString() & ""
                            If CInt(.Rows(i).Cells(1).Value.ToString()) <> 0 Or CInt(.Rows(i).Cells(2).Value.ToString()) <> 0 Then
                                sql &= " , HW_Status_Id = 1 "


                                Dim strsql As String = ""
                                Dim TimeMax As Integer = 0
                                TimeMax = CInt((.Rows(i).Cells(1).Value.ToString()) * 60) + CInt(.Rows(i).Cells(2).Value.ToString())
                                strsql = " select Status_Alarm_Id from Mas_Status_Alarm_History where Status_Alarm_Time_Min <= " & TimeMax & " and Status_Alarm_Time_Max >= " & TimeMax & ""
                                sql &= " , HW_Status_Alarm_Id = " & Get_Field_As_Select(ConnStrMasTer, strsql)
                            End If
                            '
                            sql &= " where HW_Lot_Id ='" & Lot_Id & "'"
                            Call Excute_SQL(ConStr_Guidance, sql)

                        End With
                    Catch ex As Exception
                    End Try
                    ProgressBarX1.Value = i
                Next
            End If
            ProgressBarX1.Visible = False
        End If
    End Sub
    Sub Set_Color_btn()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I As Short = 0
        Try

            sql = " SELECT distinct HW_Lot_Id,Status_Alarm_Color_A,Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B"
            sql &= " FROM Q_Mas_Lot_History "
            'sql &= " where HW_Building_ID = " & BuildingID & ""
            'sql &= " and HW_Floor_No =  " & FloorNO & ""
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
                            ' Tag = Mid(.Fields("HW_Lot_Id").Value, 4, 8)
                            I = I + 1
                            btn(I).BackColor = Color.FromArgb(.Fields("Status_Alarm_Color_A").Value, .Fields("Status_Alarm_Color_R").Value, .Fields("Status_Alarm_Color_G").Value, .Fields("Status_Alarm_Color_B").Value)
                            .MoveNext()
                        Loop
                    End If
                End With
            End If

        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub lbl_Status_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_Status_1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Capture_Screen()
    End Sub
End Class