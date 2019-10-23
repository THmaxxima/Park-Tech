Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frm_Display_Status
    Friend Floor_Selected_ID As String
    Friend Building_ID As String
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

    Private Sub frm_Display_Status_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerRealtime.Enabled = False
        T_Alert.Enabled = False
    End Sub

    Private Sub frm_Display_Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Timer_False()

        ClsSqlCmd = New ClassCommandSql
        Call mMain.Load_AppConfig()

        If Floor_Selected_ID = "" Then Floor_Selected_ID = "1"
        If Building_ID = "" Then Building_ID = "1"

        Call Show_Tab_Building() ' First Step แสดงเฉพาะ โหลดครั้งแรก
        Call Tab_Floor_Name() '###  Step 1 แสดงชื่อชั้นจอดรถ ทุกชั้น แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor() '###  Step 2 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Call Load_Button_New() '###  Step 3 Load Ultrasonic มาแสดง

        Call Load_Board_Zone_Name() '###  Step 4 ป้ายชื่อชั้น จอดรถ มาแสดง
        Call Load_Board_Zone_Display_Value() 'Step 7 โหลดบอร์ดแสดงจำนวนรถ แต่ละโซน


        Call Show_Page_Selected(Building_ID, Floor_Selected_ID) ' แสดงชั้นที่เลือก
        Call Timer_True()


        Flag_Start_From = False

       
    End Sub
    Private Sub Show_Page_Selected(ByVal BuildingID As String, ByVal FloorID As String)
        Select Case BuildingID
            Case "1"
                Tab_Building.SelectedTabIndex = 0
                Select Case FloorID
                    Case "1" : Tab_ParkingA.SelectedIndex = 0
                    Case "2" : Tab_ParkingA.SelectedIndex = 1
                    Case "3" : Tab_ParkingA.SelectedIndex = 2
                    Case "4" : Tab_ParkingA.SelectedIndex = 3
                    Case "5" : Tab_ParkingA.SelectedIndex = 4
                    Case "6" : Tab_ParkingA.SelectedIndex = 5
                End Select
            Case "2"
                Tab_Building.SelectedTabIndex = 1
                Select Case FloorID
                    Case "1" : Tab_ParkingD.SelectedIndex = 0
                    Case "2" : Tab_ParkingD.SelectedIndex = 1
                    Case "3" : Tab_ParkingD.SelectedIndex = 2
                    Case "4" : Tab_ParkingD.SelectedIndex = 3
                    Case "5" : Tab_ParkingD.SelectedIndex = 4
                    Case "6" : Tab_ParkingD.SelectedIndex = 5
                End Select
        End Select

    End Sub
    Sub Timer_True()
        TimerRealtime.Enabled = True

    End Sub
    Sub Timer_False()
        TimerRealtime.Enabled = False

    End Sub

    Sub Tab_Floor_Name() 'ชื่อของชั้นของแท็บ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT [Floor_ID]"
            sql &= ",[Tower_ID]"
            sql &= ",[Building_ID]"
            sql &= ",[Floor_No]"
            sql &= ",[Floor_Name] "
            sql &= " FROM Mas_Floor "
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
                            Select Case .Fields("Building_ID").Value.ToString
                                Case "1"
                                    Select Case .Fields("Floor_No").Value.ToString
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
                                    End Select
                                Case "2"
                                    Select Case .Fields("Floor_No").Value.ToString
                                        Case "1"
                                            Tab_ParkingD.Controls.Item(0).Tag = .Fields("Floor_No").Value
                                            Tab_ParkingD.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                        Case "2"
                                            Tab_ParkingD.Controls.Item(1).Tag = .Fields("Floor_No").Value
                                            Tab_ParkingD.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                        Case "3"
                                            Tab_ParkingD.Controls.Item(2).Tag = .Fields("Floor_No").Value
                                            Tab_ParkingD.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                        Case "4"
                                            Tab_ParkingD.Controls.Item(3).Tag = .Fields("Floor_No").Value
                                            Tab_ParkingD.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                        Case "5"
                                            Tab_ParkingD.Controls.Item(4).Tag = .Fields("Floor_No").Value
                                            Tab_ParkingD.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                        Case "6"
                                            Tab_ParkingD.Controls.Item(5).Tag = .Fields("Floor_No").Value
                                            Tab_ParkingD.Controls.Item(5).Text = .Fields("Floor_Name").Value
                                    End Select
                            End Select


                            .MoveNext()
                        Loop
                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงชื่อชั้นจอดรถ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Show_Tab_Building() 'ชื่อของอาคารของแท็บ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT * FROM Mas_Building_Parking "
            sql &= " ORDER BY "
            sql &= " CASE WHEN LEFT(Building_ID, 1) BETWEEN '0' AND '9' THEN ' ' ELSE LEFT(Building_ID, 1) END, "
            sql &= " CAST(STUFF(Building_ID, 1, CASE WHEN LEFT(Building_ID, 1) BETWEEN '0' AND '9' THEN 0 ELSE 1 END, '') AS int)"
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
                            Select Case .Fields("Building_ID").Value.ToString
                                Case "1"
                                    Tab_Building.Controls.Item(0).Tag = .Fields("Building_ID").Value
                                    Tab_Building.Controls.Item(0).Text = .Fields("Building_Name").Value
                                Case "2"
                                    Tab_Building.Controls.Item(1).Tag = .Fields("Building_ID").Value
                                    Tab_Building.Controls.Item(1).Text = .Fields("Building_Name").Value
                            End Select
                            .MoveNext()
                        Loop
                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงรายการ Tab อาคารจอดรถ ", Err.Number, Err.Description)
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
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer_False()
        Dim frm As New frm_Lot_History
        With frm
            mForm.Set_Standard_Form(frm)
            .HW_Lot_Sensor_ID = sender.Name
            .ShowDialog()
            .Dispose()
        End With
        Timer_True()
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
            'lbl_Floor_F.Text = 0
            'lbl_Floor_T.Text = 0
            'Rows = 0
            'If Floor_Select_Name <> "" And cmb_Floor.SelectedIndex <= 0 Then
            '    sql = "SELECT distinct (HW_Floorcontroller_Id) FROM Q_Mas_Lot where Floor_Name LIKE '%" & Floor_Select_Name & "%'"
            'Else
            '    sql = "SELECT distinct (HW_Floorcontroller_Id) FROM Q_Mas_Lot WHERE HW_Floor_No = " & cmb_Floor.SelectedValue & ""
            'End If
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
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If

        Catch ex As Exception

        End Try

        
        Call Value_In_Zone(Public_Building_ID, Public_Floor_NO) 'จำนวนรถว่างในแต่ละโซน
        Call Update_Color_Alam_ID(Public_Building_ID, Public_Floor_NO) 'set สีสถานะการจอดรถ
        Call Set_Color_btn(Public_Building_ID, Public_Floor_NO) ' Set สี การจอดรถตามชั่วโมงจอด


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
                                Select Case rs.Fields("Zone_Building_ID").Value.ToString
                                    Case "1"
                                        Select Case rs.Fields("Zone_Floor_No").Value.ToString
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
                                        End Select
                                    Case "2"
                                        Select Case rs.Fields("Zone_Floor_No").Value.ToString
                                            Case "1"
                                                Me.Pic_ID_7.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                            Case "2"
                                                Me.Pic_ID_8.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                            Case "3"
                                                Me.Pic_ID_9.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                            Case "4"
                                                Me.Pic_ID_10.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                            Case "5"
                                                Me.Pic_ID_11.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                            Case "6"
                                                Me.Pic_ID_12.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                        End Select
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
    Sub Update_Board_Zone(Optional ByVal Floor_ID As String = Nothing, Optional ByVal Building_ID As String = Nothing, Optional ByVal Floor_No As String = Nothing)
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        '  Dim I_Index As Short = 0
        Try
            If Floor_Select_Id <> "" Then
                sql = "SELECT * " & _
                      "FROM Floor_Zone where Floor_Id =" & Floor_No & " order by Zone_Id"
            Else
                sql = "SELECT * " & _
                      "FROM Floor_Zone where Floor_Id =" & Floor_No & " order by Zone_Id"
            End If
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
                            With Me.lbl_Zone(I_Index)
                                '.Size = New Size(CInt(rs.Fields("Zone_SizeX").Value), CInt(rs.Fields("Zone_SizeY").Value)) 'ขนาด button
                                '.Name = "lbl" & rs.Fields("Zone_Id").Value  'ชื่อ button
                                ' .Tag = rs.Fields("Zone_Id").Value
                                Dim Value_Zone As String = mCountCar.Get_Count_CarInZone(rs.Fields("Zone_Id").Value, Floor_ID, Building_ID)
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
                                If Floor_Select_Id = "1" Then
                                    Me.Pic_ID_7.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                ElseIf Floor_Select_Id = "2" Then
                                    Me.Pic_ID_8.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                ElseIf Floor_Select_Id = "3" Then
                                    Me.Pic_ID_9.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                ElseIf Floor_Select_Id = "4" Then
                                    Me.Pic_ID_10.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                ElseIf Floor_Select_Id = "5" Then
                                    Me.Pic_ID_11.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                                End If
                            End With
                            .MoveNext()
                        Loop
                    Else

                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
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
    Sub Show_Picture_Floor()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""


        Pic_ID_1.Controls.Clear()
        Pic_ID_2.Controls.Clear()
        Pic_ID_3.Controls.Clear()
        Pic_ID_4.Controls.Clear()
        Pic_ID_5.Controls.Clear()
        Pic_ID_6.Controls.Clear()
        Pic_ID_7.Controls.Clear()
        Pic_ID_8.Controls.Clear()
        Pic_ID_9.Controls.Clear()
        Pic_ID_10.Controls.Clear()
        Pic_ID_11.Controls.Clear()
        Pic_ID_12.Controls.Clear()


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
        '    Call mError.ShowError(Me.Name, "แสดงรูปภาพลานจอดรถ ", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
    End Sub

    Private Sub btn_MainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Timer_False()
        Me.Dispose()
    End Sub
    Sub Refesh_Status()
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

      Sub Set_Color_btn(Optional ByVal BuildingID As String = Nothing, Optional ByVal FloorNO As String = Nothing)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I As Short = 0
        Try

            sql = " SELECT distinct HW_Lot_Id,Status_Alarm_Color_A,Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B FROM Q_Mas_Lot "
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
                            Tag = Mid(.Fields("HW_Lot_Id").Value, 4, 8)
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

                            'HW_On_Line
                            If .Fields("HW_On_Line").Value = "1" Then
                                sql = ""
                                sql &= " select  Status_Alarm_Id from  Mas_Status_Alarm "
                                sql &= " where Status_Alarm_Time_Min <= " & Total_MM & " "
                                sql &= " and Status_Alarm_Time_Max >= " & Total_MM & " "
                                HW_Status_Alarm_Id = mDB_New.Get_Field_As_Select(ConnStrMasTer, sql)
                                Excute_SQL(ConStr_Guidance, " update Mas_Lot set HW_Status_Alarm_Id =" & HW_Status_Alarm_Id & " where HW_Lot_Id = " & .Fields("HW_Lot_Id").Value & "")
                            End If
                            .MoveNext()
                        Loop
                    End If
                End With
            End If

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
                                Select Case rs.Fields("F_Zone_Building_ID").Value 'FloorID 'F_Zone_Building_ID
                                    Case "1"
                                        Select Case rs.Fields("F_Zone_Floor_No").Value
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
                                        End Select
                                    Case "2"
                                        Select Case rs.Fields("F_Zone_Floor_No").Value
                                            Case "1"
                                                Me.Pic_ID_7.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                            Case "2"
                                                Me.Pic_ID_8.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                            Case "3"
                                                Me.Pic_ID_9.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                            Case "4"
                                                Me.Pic_ID_10.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                            Case "5"
                                                Me.Pic_ID_11.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                            Case "6"
                                                Me.Pic_ID_12.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                        End Select
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
            sql &= " FROM Q_Mas_Lot "
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
                                AddHandler .Click, AddressOf Me.Button_Click
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
    Private Sub Tab_ParkingA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_ParkingA.SelectedIndexChanged
        If Flag_Start_From = True Then Exit Sub
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If

        Catch ex As Exception
        End Try
        Try

        
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Tab_ParkingD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_ParkingD.SelectedIndexChanged
        If Flag_Start_From = True Then Exit Sub
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If

        Catch ex As Exception
        End Try
      
    End Sub


   
   


   
 
End Class