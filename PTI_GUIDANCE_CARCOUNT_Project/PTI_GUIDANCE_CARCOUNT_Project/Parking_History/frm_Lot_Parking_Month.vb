Imports System
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic

Public Class frm_Lot_Parking_Month
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
    Dim lbl(800) As Label
    Dim mFloor As String
    Public Public_Log_ID As String
    Private Sub frm_Lot_Parking_Month_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mMain.Load_AppConfig()
        ClsSqlCmd = New ClassCommandSql
       
        If Floor_Selected_ID = "" Then Floor_Selected_ID = "1"

        sql = "" & " update Mas_Lot_History set HW_Status_Alarm_Id = 0 "
        sql &= " ,HW_Time_HH = 0 ,HW_Time_MM = 0 ,HW_Status_Id=0 "
        Excute_SQL(ConStr_Guidance, sql)


        'Update สีตามประเภทการจอดรถ
        mFloor = FloorController.Count_Floor()
        Call Show_Tab_Building() ' First Step แสดงเฉพาะ โหลดครั้งแรก
        Call Show_Picture_Floor() '###  Step 1 แสดงรูปภาพ ชั้นจอดรถ ทุกชั้น
        Call Tab_Floor_Name() '###  Step 2 แสดงชื่อชั้นจอดรถ ทุกชั้น
        Call Load_Button_New() '###  Step 3 Load Ultrasonic มาแสดง
        Call lsv_Select_Mas_Alam_View() 'Step 4 ค้นหาสีประวัติการจอด ใส่ใน List View
        Call Select_Color_History_Standard() ' Step 5 ค้นหาสีมาตรฐาน 4 สี ใส่ใน Label


        Cmb_Day.SelectedIndex = 0
        cmb_Month.SelectedIndex = 0
        cmb_Years.SelectedIndex = 0
        Tab_Building.SelectedTabIndex = 0
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
        Call mError.ShowError(Me.Name, "แสดงรูปภาพ ลานจอดรถ ผิดพลาด ", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
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
        Call mError.ShowError(Me.Name, "แสดงรูปภาพลานจอดรถ ผิดพลาด", Err.Number, Err.Description)
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Me.Enabled = True
        Return False
    End Function
    Sub Monthly_Many_Parking()
        Dim i As Integer
        Dim Lot_ID As String = ""
        btn_Search.Enabled = False
        Call Excute_SQL(ConStr_Guidance, " update Mas_Lot_History set HW_Net_02 = '0'")
        If Rdo_Month.Checked = True Then
            If cmb_Month.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If

            If cmb_Years.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            Select_Sum_Lot_Parking("", cmb_Month.Text, cmb_Years.Text)
        End If
        If rdo_Day.Checked = True Then
            If Cmb_Day.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            If cmb_Month.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            If cmb_Years.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            Select_Sum_Lot_Parking(Cmb_Day.Text, cmb_Month.Text, cmb_Years.Text)
        End If

        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = DgvDetail.RowCount

        If DgvDetail.RowCount - 1 > 0 Then
            If DgvDetail.RowCount - 1 > 0 Then
                For i = 0 To DgvDetail.RowCount - 1
                    Try
                        With DgvDetail
                            Lot_ID = "" & .Rows(i).Cells(0).Value.ToString()
                            Call Excute_SQL(ConStr_Guidance, " update Mas_Lot_History set HW_Net_02 = HW_Net_02 + " & .Rows(i).Cells(1).Value.ToString() & " where HW_Lot_Id ='" & Lot_ID & "'")
                        End With
                    Catch ex As Exception
                    End Try
                    ProgressBar1.Value = i
                Next
            End If
            ProgressBar1.Visible = False

            Call History_Set_Color_btn()


        End If


        btn_Search.Enabled = True
        ProgressBar1.Visible = False
    End Sub
    Sub Monthly_Time_Parking()
        Dim i As Integer
        Call Excute_SQL(ConStr_Guidance, " update Mas_Lot_History set HW_Time_MM = '0'")
        If Rdo_Month.Checked = True Then
            If cmb_Month.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            If cmb_Years.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            Select_Parking_Time("", cmb_Month.Text, cmb_Years.Text)
        End If
        If rdo_Day.Checked = True Then
            If Cmb_Day.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            If cmb_Month.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            If cmb_Years.SelectedIndex = 0 Then
                btn_Search.Enabled = True
                Exit Sub
            End If
            Select_Parking_Time(Cmb_Day.Text, cmb_Month.Text, cmb_Years.Text)
        End If
        Call Excute_SQL(ConStr_Guidance, " update Mas_Lot_History set HW_Time_HH = 0, HW_Time_MM = 0")

        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = dgv_Time.RowCount

        If dgv_Time.RowCount - 1 > 0 Then
            If dgv_Time.RowCount - 1 > 0 Then
                For i = 0 To dgv_Time.RowCount - 1
                    Try
                        With dgv_Time
                            Lot_Id = "" & .Rows(i).Cells(0).Value.ToString()
                            Call Excute_SQL(ConStr_Guidance, " update Mas_Lot_History set HW_Time_MM = HW_Time_MM + " & (CInt((.Rows(i).Cells(1).Value.ToString()) * 60) + CInt(.Rows(i).Cells(2).Value.ToString())) & " where HW_Lot_Id ='" & Lot_Id & "'")
                        End With
                    Catch ex As Exception
                    End Try
                    ProgressBar1.Value = i
                Next
            End If
            ProgressBar1.Visible = False

            Call History_Set_Color_btn_Time()

        End If


        btn_Search.Enabled = True
        ProgressBar1.Visible = False
    End Sub
    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        sql = ""
        sql &= " select Floor_Lot_All from Mas_Floor"
        sql &= " where Building_ID = '" & Public_Building_ID & "'"
        sql &= " and  Floor_No  = '" & Public_Floor_NO & "'"

        lbl_Max_Parking.Text = "" & Get_Field_As_Select(ConnStrMasTer, sql)

        If rdo_Many.Checked = True Then 'จำนวนครั้ง
            Monthly_Many_Parking()
        End If
        If rdo_Time.Checked = True Then 'เวลาจอด
            Monthly_Time_Parking()
        End If
    End Sub

    Sub Select_Sum_Lot_Parking(ByVal Days As String, ByVal Monthly As String, ByVal Years As String)
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
            sql = "select  Trn_Lot_Id,Count_Lot from TQV_Count_Lot_History_Month "
            If Days <> "" Then
                sql &= " where day(Trn_Log_Date)= '" & Days & "'"
                sql &= " and  month(Trn_Log_Date)= '" & Monthly & "'"
                sql &= "  and year(Trn_Log_Date)= '" & Years & "'"
                sql &= " order by Trn_Lot_Id "
            Else
                sql &= " where month(Trn_Log_Date)= '" & Monthly & "' and year(Trn_Log_Date)= '" & Years & "'"
                sql &= " order by Trn_Lot_Id "
            End If

            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            'sqlDs.Clear()
            sqlDa.Fill(sqlDs, "QV_Count_Lot_History_Month")
            DgvDetail.DataSource = sqlDs.Tables("QV_Count_Lot_History_Month")
            '  lbl_Count.Text = "" & DgvDetail.RowCount - 1
            Con.Close()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub
    Sub Select_Parking_Time(ByVal Days As String, ByVal Monthly As String, ByVal Years As String)
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

            If Days <> "" Then
                sql = "select Trn_Lot_Id,Trn_Park_HH,Trn_Park_MM from Transaction_Lot_OUT where day(Trn_Log_Date)= '" & Days & "'"
                sql &= " and  month(Trn_Log_Date)= '" & Monthly & "' and year(Trn_Log_Date)= '" & Years & "'"
                sql &= " order by Trn_Lot_Id "
            Else
                sql = "select Trn_Lot_Id,Trn_Park_HH,Trn_Park_MM from Transaction_Lot_OUT where  month(Trn_Log_Date)= '" & Monthly & "' and year(Trn_Log_Date)= '" & Years & "'"
                sql &= " order by Trn_Lot_Id "
            End If

            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            ' sqlDs.Clear()
            sqlDa.Fill(sqlDs, "Transaction_Lot_OUT")
            dgv_Time.DataSource = sqlDs.Tables("Transaction_Lot_OUT")
            Con.Close()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub
    Private Sub Rdo_Month_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rdo_Month.Checked = True Then
            Cmb_Day.Enabled = False
        End If
    End Sub

    Private Sub rdo_Day_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rdo_Day.Checked = True Then
            Cmb_Day.Enabled = True
        End If
    End Sub
    Sub History_Set_Color_btn()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim Con2 As New ADODB.Connection
        Dim Con_0 As New ADODB.Connection
        Dim Con_1 As New ADODB.Connection
        Dim Con_2 As New ADODB.Connection
        Dim Con_3 As New ADODB.Connection
        Dim Con_4 As New ADODB.Connection
        Dim rs2 As New ADODB.Recordset


        Dim sql2 As String = ""
        Dim I As Short
        Dim J As Short
        'Dim K As Integer
        Dim Lot_Id As String = ""
        Dim Floor_No As String = ""
        Dim Time_Parking = "", Trn_Floorcontroller_Id As String = ""
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0

        ''For K = 1 To 12
        ''    Try
        sql2 = ""
        sql2 = " SELECT * FROM Mas_Lot_History "
        ' sql2 &= " where HW_Floor_No = '" & K & "'"
        sql2 &= " order by HW_Lot_Id "
        If OpenCnn(ConnStrGuidance, Con2) Then
            With rs2
                If rs2.State = 1 Then rs2.Close()
                rs2.let_ActiveConnection(Con2)
                rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                rs2.Open(sql2)
                If Not (rs2.BOF And rs2.EOF) Then
                    ProgressBar1.Maximum = rs2.RecordCount
                    rs2.MoveFirst()
                    J = 0

                    Dim AMOD = 0, Step1 = 0, Step2 = 0, Step3 = 0, Step4 As Integer = 0
                    Dim aMAX As Integer = 0
                    ' aMAX = mHistory.Get_MIN_MAX("MAX", "HW_Net_2", " where HW_Lot_Id = '" & rs2.Fields("HW_Lot_Id").Value & "'")


                    Do While Not rs2.EOF

                        If Floor_No = "" Then
                            Floor_No = rs2.Fields("HW_Floor_No").Value
                            aMAX = mHistory.Get_MIN_MAX("MAX", "HW_Net_02", " where HW_Floor_No = '" & Floor_No & "'")
                            AMOD = aMAX / 4
                            Step1 = AMOD
                            Step2 = AMOD * 2
                            Step3 = AMOD * 3
                        Else
                            If Floor_No <> rs2.Fields("HW_Floor_No").Value Then
                                Floor_No = "" & rs2.Fields("HW_Floor_No").Value
                                aMAX = mHistory.Get_MIN_MAX("MAX", "HW_Net_02", " where HW_Floor_No = '" & Floor_No & "'")
                                AMOD = aMAX / 4
                                Step1 = AMOD
                                Step2 = AMOD * 2
                                Step3 = AMOD * 3
                            End If

                        End If

                        J = J + 1
                        ProgressBar1.Value = J
                        Lot_Id = ""
                        Time_Parking = ""
                        sql = ""
                        Lot_Id = rs2.Fields("HW_Lot_Id").Value '

                        I = J
                        If rs2.Fields("HW_Net_02").Value = 0 Then 'ไม่มีการจอดเลย
                            sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 1 "
                            Try
                                Dim RS_0 As New ADODB.Recordset
                                If OpenCnn(ConnStrMasTer, Con_0) Then
                                    With RS_0
                                        If RS_0.State = 1 Then RS_0.Close()
                                        RS_0.let_ActiveConnection(Con_0)
                                        RS_0.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                        RS_0.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                        RS_0.Open(sql)
                                        If Not (RS_0.BOF And RS_0.EOF) Then
                                            RS_0.MoveFirst()
                                            '  I = Lot_Id
                                            btn(I).BackColor = Color.FromArgb(RS_0.Fields("His_Color_A").Value, RS_0.Fields("His_Color_R").Value, RS_0.Fields("His_Color_G").Value, RS_0.Fields("His_Color_B").Value)
                                        End If
                                    End With
                                End If
                                RS_0 = Nothing
                            Catch ex As Exception

                            End Try
                        End If

                        If (rs2.Fields("HW_Net_02").Value > 0) And (rs2.Fields("HW_Net_02").Value <= Step1) Then
                            sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 1"
                            Try
                                Dim RS_1 As New ADODB.Recordset

                                If OpenCnn(ConnStrMasTer, Con_1) Then
                                    If RS_1.State = 1 Then RS_1.Close()

                                    RS_1.let_ActiveConnection(Con_1)
                                    RS_1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                    RS_1.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                    RS_1.Open(sql)
                                    If Not (RS_1.BOF And RS_1.EOF) Then
                                        RS_1.MoveFirst()
                                        '  I = Lot_Id
                                        btn(I).BackColor = Color.FromArgb(RS_1.Fields("His_Color_A").Value, RS_1.Fields("His_Color_R").Value, RS_1.Fields("His_Color_G").Value, RS_1.Fields("His_Color_B").Value)
                                    End If
                                End If
                                RS_1 = Nothing
                            Catch ex As Exception

                            End Try
                        End If

                        If (rs2.Fields("HW_Net_02").Value > Step1) And (rs2.Fields("HW_Net_02").Value <= Step2) Then
                            sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 2"
                            Try
                                Dim RS_2 As New ADODB.Recordset

                                If OpenCnn(ConnStrMasTer, Con_2) Then
                                    If RS_2.State = 1 Then RS_2.Close()

                                    RS_2.let_ActiveConnection(Con_2)
                                    RS_2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                    RS_2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                    RS_2.Open(sql)
                                    If Not (RS_2.BOF And RS_2.EOF) Then
                                        RS_2.MoveFirst()
                                        I = Lot_Id
                                        btn(I).BackColor = Color.FromArgb(RS_2.Fields("His_Color_A").Value, RS_2.Fields("His_Color_R").Value, RS_2.Fields("His_Color_G").Value, RS_2.Fields("His_Color_B").Value)
                                    End If
                                End If
                                RS_2 = Nothing
                            Catch ex As Exception

                            End Try
                        End If
                        If (rs2.Fields("HW_Net_02").Value > Step2) And (rs2.Fields("HW_Net_02").Value <= Step3) Then
                            sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 3"
                            Try
                                Dim RS_3 As New ADODB.Recordset

                                If OpenCnn(ConnStrMasTer, Con_3) Then

                                    If RS_3.State = 1 Then RS_3.Close()
                                    RS_3.let_ActiveConnection(Con_3)
                                    RS_3.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                    RS_3.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                    RS_3.Open(sql)
                                    If Not (RS_3.BOF And RS_3.EOF) Then
                                        RS_3.MoveFirst()
                                        ' I = Lot_Id
                                        btn(I).BackColor = Color.FromArgb(RS_3.Fields("His_Color_A").Value, RS_3.Fields("His_Color_R").Value, RS_3.Fields("His_Color_G").Value, RS_3.Fields("His_Color_B").Value)
                                    End If
                                End If
                                RS_3 = Nothing
                            Catch ex As Exception

                            End Try
                        End If
                        If rs2.Fields("HW_Net_02").Value > Step3 Then
                            sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 4"
                            Try
                                Dim RS_4 As New ADODB.Recordset
                                If OpenCnn(ConnStrMasTer, Con_4) Then
                                    If RS_4.State = 1 Then RS_4.Close()

                                    RS_4.let_ActiveConnection(Con_4)
                                    RS_4.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                    RS_4.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                    RS_4.Open(sql)
                                    If Not (RS_4.BOF And RS_4.EOF) Then
                                        RS_4.MoveFirst()
                                        ' I = Lot_Id
                                        btn(I).BackColor = Color.FromArgb(RS_4.Fields("His_Color_A").Value, RS_4.Fields("His_Color_R").Value, RS_4.Fields("His_Color_G").Value, RS_4.Fields("His_Color_B").Value)
                                    End If

                                End If
                                RS_4 = Nothing
                            Catch ex As Exception
                            End Try

                        Else
                            sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 1 "
                            Try
                                Dim RS_0 As New ADODB.Recordset
                                If OpenCnn(ConnStrMasTer, Con_0) Then
                                    With RS_0
                                        If RS_0.State = 1 Then RS_0.Close()
                                        RS_0.let_ActiveConnection(Con_0)
                                        RS_0.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                        RS_0.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                        RS_0.Open(sql)
                                        If Not (RS_0.BOF And RS_0.EOF) Then
                                            RS_0.MoveFirst()
                                            '  I = Lot_Id
                                            btn(I).BackColor = Color.FromArgb(RS_0.Fields("His_Color_A").Value, RS_0.Fields("His_Color_R").Value, RS_0.Fields("His_Color_G").Value, RS_0.Fields("His_Color_B").Value)
                                        End If
                                    End With
                                End If
                                RS_0 = Nothing
                            Catch ex As Exception
                            End Try
                        End If

                        rs2.MoveNext()
                    Loop
                End If
            End With
        End If
        ''    Catch ex As Exception
        ''    'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        ''End Try
        ''Next K

        ProgressBar1.Visible = False
    End Sub
    Sub History_Set_Color_History()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim Con2 As New ADODB.Connection
        Dim rs2 As New ADODB.Recordset
        Dim sql2 As String = ""
        Dim I As Short
        Dim k As Integer
        Dim Lot_Id As String = ""
        Dim Time_Parking = "", Trn_Floorcontroller_Id As String = ""


        Try
            For k = 1 To 5
                sql2 = ""
                sql2 = " SELECT * FROM Mas_Lot_History "
                sql2 &= " where HW_Floor_No = '" & k & "'"
                sql2 &= " order by HW_Lot_Id "
                If OpenCnn(ConnStrGuidance, Con2) Then
                    With rs2
                        If .State = 1 Then .Close()
                        rs2.let_ActiveConnection(Con2)
                        rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                        rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                        rs2.Open(sql2)
                        If Not (rs2.BOF And rs2.EOF) Then
                            rs2.MoveFirst()
                            Do While Not rs2.EOF
                                Lot_Id = ""
                                Time_Parking = ""
                                sql = ""
                                Trn_Floorcontroller_Id = ""
                                Lot_Id = rs2.Fields("HW_Lot_Id").Value '
                                'Trn_Floorcontroller_Id = rs2.Fields("HW_Net_2").Value '
                                Time_Parking = rs2.Fields("HW_Net_2").Value
                                sql = "SELECT * FROM Mas_Color_History " & _
                                  " where  His_Min <= " & Time_Parking & _
                                  " and His_Max >= " & Time_Parking & ""
                                Try
                                    If OpenCnn(ConnStrGuidance, Conn) Then
                                        With rs
                                            If .State = 1 Then .Close()
                                            .let_ActiveConnection(Conn)
                                            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                            .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                            .Open(sql)
                                            If Not (.BOF And .EOF) Then
                                                I = Lot_Id
                                                If rs2.Fields("HW_Net_2").Value = 0 Then 'ไม่มีการจอดเลย
                                                    btn(I).BackColor = Color.FromArgb(224, 224, 224)
                                                Else
                                                    btn(I).BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                                                End If

                                            End If
                                        End With
                                    End If
                                Catch ex As Exception

                                End Try
                                rs2.MoveNext()
                            Loop
                        End If
                    End With
                End If
            Next k
        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        End Try
    End Sub
    Sub lsv_Select_Mas_Alam_View()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Row_Color As String
        sql = "SELECT * FROM Mas_Color_History "
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    lsv_Mas_Alam.Items.Clear()
                    lsv_Mas_Alam.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Mas_Alam.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    Do While Not .EOF
                        Dim New_Ent As ListViewItem = lsv_Mas_Alam.Items.Add(rs.Fields("His_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("His_Name").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_A").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_R").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_G").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_B").Value)
                            .ForeColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                        End With
                        .MoveNext()
                    Loop

                Else
                    lsv_Mas_Alam.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "แสดงรายละเอียด ประวัติสีการจอดรถ", Err.Number, Err.Description)
    End Sub
    Sub Select_Color_History_Standard()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Row_Color As String
        sql = "SELECT * FROM Mas_Color_History_Standard "
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
                        If rs.Fields("His_Id").Value = "0" Then
                            '   lbl_Emtry.BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                        End If
                        If rs.Fields("His_Id").Value = "1" Then
                            lbl_Color_Step1.BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                        End If
                        If rs.Fields("His_Id").Value = "2" Then
                            lbl_Color_Step2.BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                        End If
                        If rs.Fields("His_Id").Value = "3" Then
                            lbl_Color_Step3.BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                        End If
                        If rs.Fields("His_Id").Value = "4" Then
                            lbl_Color_Step4.BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                        End If
                        .MoveNext()
                    Loop

                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "แสดงรายละเอียด ประวัติสี การจอดรถ", Err.Number, Err.Description)
    End Sub


    Private Sub rdo_Day_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_Day.CheckedChanged
        If rdo_Day.Checked = True Then
            Cmb_Day.Enabled = True
        End If
    End Sub

    Private Sub Rdo_Month_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_Month.CheckedChanged
        If Rdo_Month.Checked = True Then
            Cmb_Day.Enabled = False
        End If
    End Sub
    Sub History_Set_Color_btn_Time()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim Con2 As New ADODB.Connection
        Dim Con_0 As New ADODB.Connection
        Dim Con_1 As New ADODB.Connection
        Dim Con_2 As New ADODB.Connection
        Dim Con_3 As New ADODB.Connection
        Dim Con_4 As New ADODB.Connection
        Dim rs2 As New ADODB.Recordset


        Dim sql2 As String = ""
        Dim I As Short = 0
        Dim J As Short
        '  Dim K As Integer
        Dim Lot_Id As String = ""
        Dim Floor_No As String = ""
        Dim Time_Parking = "", Trn_Floorcontroller_Id As String = ""
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Try
            ' For K = 1 To 12
            sql2 = ""
            sql2 = " SELECT * FROM Mas_Lot_History "
            ' sql2 &= " where HW_Floor_No = '" & K & "'"
            sql2 &= " order by HW_Lot_Id "
            If OpenCnn(ConnStrGuidance, Con2) Then
                With rs2
                    If rs2.State = 1 Then rs2.Close()
                    rs2.let_ActiveConnection(Con2)
                    rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    rs2.Open(sql2)
                    If Not (rs2.BOF And rs2.EOF) Then
                        ProgressBar1.Maximum = rs2.RecordCount
                        rs2.MoveFirst()
                        J = 0

                        Dim AMOD = 0, Step1 = 0, Step2 = 0, Step3 = 0, Step4 As Integer = 0
                        Dim aMAX As Integer = 0

                        Do While Not rs2.EOF

                            If Floor_No = "" Then
                                Floor_No = rs2.Fields("HW_Floor_No").Value
                                aMAX = mHistory.Get_MIN_MAX("MAX", "HW_Time_MM", " where HW_Floor_No = '" & Floor_No & "'")
                                AMOD = aMAX / 4
                                Step1 = AMOD
                                Step2 = AMOD * 2
                                Step3 = AMOD * 3
                            Else
                                If Floor_No <> rs2.Fields("HW_Floor_No").Value Then
                                    Floor_No = "" & rs2.Fields("HW_Floor_No").Value
                                    aMAX = mHistory.Get_MIN_MAX("MAX", "HW_Time_MM", " where HW_Floor_No = '" & Floor_No & "'")
                                    AMOD = aMAX / 4
                                    Step1 = AMOD
                                    Step2 = AMOD * 2
                                    Step3 = AMOD * 3
                                End If

                            End If
                            I = I + 1
                            J = J + 1
                            ProgressBar1.Value = J
                            Lot_Id = ""
                            Time_Parking = ""
                            sql = ""
                            Lot_Id = rs2.Fields("HW_Lot_Id").Value '

                            'I = Lot_Id
                            If rs2.Fields("HW_Time_MM").Value = 0 Then 'ไม่มีการจอดเลย
                                sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 1 "
                                Try
                                    Dim RS_0 As New ADODB.Recordset
                                    If OpenCnn(ConnStrMasTer, Con_0) Then
                                        With RS_0
                                            If RS_0.State = 1 Then RS_0.Close()
                                            RS_0.let_ActiveConnection(Con_0)
                                            RS_0.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                            RS_0.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                            RS_0.Open(sql)
                                            If Not (RS_0.BOF And RS_0.EOF) Then
                                                RS_0.MoveFirst()
                                                '  I = Lot_Id
                                                btn(I).BackColor = Color.FromArgb(RS_0.Fields("His_Color_A").Value, RS_0.Fields("His_Color_R").Value, RS_0.Fields("His_Color_G").Value, RS_0.Fields("His_Color_B").Value)
                                            End If
                                        End With
                                    End If
                                    RS_0 = Nothing
                                Catch ex As Exception

                                End Try
                            End If

                            If rs2.Fields("HW_Time_MM").Value > 0 And rs2.Fields("HW_Time_MM").Value <= Step1 Then
                                sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 1"
                                Try
                                    Dim RS_1 As New ADODB.Recordset

                                    If OpenCnn(ConnStrMasTer, Con_1) Then
                                        If RS_1.State = 1 Then RS_1.Close()

                                        RS_1.let_ActiveConnection(Con_1)
                                        RS_1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                        RS_1.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                        RS_1.Open(sql)
                                        If Not (RS_1.BOF And RS_1.EOF) Then
                                            RS_1.MoveFirst()
                                            ' I = Lot_Id
                                            btn(I).BackColor = Color.FromArgb(RS_1.Fields("His_Color_A").Value, RS_1.Fields("His_Color_R").Value, RS_1.Fields("His_Color_G").Value, RS_1.Fields("His_Color_B").Value)
                                        End If
                                    End If
                                    RS_1 = Nothing
                                Catch ex As Exception

                                End Try
                            End If

                            If rs2.Fields("HW_Time_MM").Value > Step1 And rs2.Fields("HW_Time_MM").Value <= Step2 Then
                                sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 2"
                                Try
                                    Dim RS_2 As New ADODB.Recordset

                                    If OpenCnn(ConnStrMasTer, Con_2) Then
                                        If RS_2.State = 1 Then RS_2.Close()

                                        RS_2.let_ActiveConnection(Con_2)
                                        RS_2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                        RS_2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                        RS_2.Open(sql)
                                        If Not (RS_2.BOF And RS_2.EOF) Then
                                            RS_2.MoveFirst()
                                            ' I = Lot_Id
                                            btn(I).BackColor = Color.FromArgb(RS_2.Fields("His_Color_A").Value, RS_2.Fields("His_Color_R").Value, RS_2.Fields("His_Color_G").Value, RS_2.Fields("His_Color_B").Value)
                                        End If
                                    End If
                                    RS_2 = Nothing
                                Catch ex As Exception

                                End Try
                            End If
                            If rs2.Fields("HW_Time_MM").Value > Step2 And rs2.Fields("HW_Time_MM").Value <= Step3 Then
                                sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 3"
                                Try
                                    Dim RS_3 As New ADODB.Recordset

                                    If OpenCnn(ConnStrMasTer, Con_3) Then

                                        If RS_3.State = 1 Then RS_3.Close()
                                        RS_3.let_ActiveConnection(Con_3)
                                        RS_3.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                        RS_3.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                        RS_3.Open(sql)
                                        If Not (RS_3.BOF And RS_3.EOF) Then
                                            RS_3.MoveFirst()
                                            '  I = Lot_Id
                                            btn(I).BackColor = Color.FromArgb(RS_3.Fields("His_Color_A").Value, RS_3.Fields("His_Color_R").Value, RS_3.Fields("His_Color_G").Value, RS_3.Fields("His_Color_B").Value)
                                        End If
                                    End If
                                    RS_3 = Nothing
                                Catch ex As Exception

                                End Try
                            End If
                            If rs2.Fields("HW_Time_MM").Value > Step3 Then
                                sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 4"
                                Try
                                    Dim RS_4 As New ADODB.Recordset
                                    If OpenCnn(ConnStrMasTer, Con_4) Then
                                        If RS_4.State = 1 Then RS_4.Close()
                                        RS_4.let_ActiveConnection(Con_4)
                                        RS_4.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                        RS_4.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                        RS_4.Open(sql)
                                        If Not (RS_4.BOF And RS_4.EOF) Then
                                            RS_4.MoveFirst()
                                            '     I = Lot_Id
                                            btn(I).BackColor = Color.FromArgb(RS_4.Fields("His_Color_A").Value, RS_4.Fields("His_Color_R").Value, RS_4.Fields("His_Color_G").Value, RS_4.Fields("His_Color_B").Value)
                                        End If

                                    End If
                                    RS_4 = Nothing
                                Catch ex As Exception
                                End Try
                            Else
                                sql = "" & "SELECT * FROM Mas_Color_History_Standard  where  His_ID = 1 "
                                Try
                                    Dim RS_0 As New ADODB.Recordset
                                    If OpenCnn(ConnStrMasTer, Con_0) Then
                                        With RS_0
                                            If RS_0.State = 1 Then RS_0.Close()
                                            RS_0.let_ActiveConnection(Con_0)
                                            RS_0.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                            RS_0.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                            RS_0.Open(sql)
                                            If Not (RS_0.BOF And RS_0.EOF) Then
                                                RS_0.MoveFirst()
                                                '  I = Lot_Id
                                                btn(I).BackColor = Color.FromArgb(RS_0.Fields("His_Color_A").Value, RS_0.Fields("His_Color_R").Value, RS_0.Fields("His_Color_G").Value, RS_0.Fields("His_Color_B").Value)
                                            End If
                                        End With
                                    End If
                                    RS_0 = Nothing
                                Catch ex As Exception

                                End Try
                            End If

                            rs2.MoveNext()
                        Loop
                    End If
                End With
            End If
            ' Next K
        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        End Try
        ProgressBar1.Visible = False
    End Sub
    Sub History_Set_Color_History_Time()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim Con2 As New ADODB.Connection
        Dim rs2 As New ADODB.Recordset
        Dim sql2 As String = ""
        Dim I As Short
        Dim k As Integer
        Dim Lot_Id As String = ""
        Dim Time_Parking = "", Trn_Floorcontroller_Id As String = ""


        Try
            For k = 1 To 5
                sql2 = ""
                sql2 = " SELECT * FROM Mas_Lot_History "
                sql2 &= " where HW_Floor_No = '" & k & "'"
                sql2 &= " order by HW_Lot_Id "
                If OpenCnn(ConnStrGuidance, Con2) Then
                    With rs2
                        If .State = 1 Then .Close()
                        rs2.let_ActiveConnection(Con2)
                        rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                        rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                        rs2.Open(sql2)
                        If Not (rs2.BOF And rs2.EOF) Then
                            rs2.MoveFirst()
                            Do While Not rs2.EOF
                                Lot_Id = ""
                                Time_Parking = ""
                                sql = ""
                                Trn_Floorcontroller_Id = ""
                                Lot_Id = rs2.Fields("HW_Lot_Id").Value '
                                'Trn_Floorcontroller_Id = rs2.Fields("HW_Net_2").Value '
                                Time_Parking = rs2.Fields("HW_Net_2").Value
                                sql = "SELECT * FROM Mas_Color_History " & _
                                  " where  His_Min <= " & Time_Parking & _
                                  " and His_Max >= " & Time_Parking & ""
                                Try
                                    If OpenCnn(ConnStrGuidance, Conn) Then
                                        With rs
                                            If .State = 1 Then .Close()
                                            .let_ActiveConnection(Conn)
                                            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                            .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                                            .Open(sql)
                                            If Not (.BOF And .EOF) Then
                                                I = Lot_Id
                                                If rs2.Fields("HW_Net_2").Value = 0 Then 'ไม่มีการจอดเลย
                                                    btn(I).BackColor = Color.FromArgb(224, 224, 224)
                                                Else
                                                    btn(I).BackColor = Color.FromArgb(rs.Fields("His_Color_A").Value, rs.Fields("His_Color_R").Value, rs.Fields("His_Color_G").Value, rs.Fields("His_Color_B").Value)
                                                End If

                                            End If
                                        End With
                                    End If
                                Catch ex As Exception

                                End Try
                                rs2.MoveNext()
                            Loop
                        End If
                    End With
                End If
            Next k
        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Set_Color_btn No. " & I, Err.Number, Err.Description)
        End Try
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
                                    Tab_ParkingA.Controls.Item(0).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingA.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                Case "2"
                                    Tab_ParkingA.Controls.Item(1).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingA.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                Case "3"
                                    Tab_ParkingA.Controls.Item(2).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingA.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                Case "4"
                                    Tab_ParkingA.Controls.Item(3).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingA.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                Case "5"
                                    Tab_ParkingA.Controls.Item(4).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingA.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                Case "6"
                                    Tab_ParkingA.Controls.Item(5).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingA.Controls.Item(5).Text = .Fields("Floor_Name").Value
                                Case "7"
                                    Tab_ParkingD.Controls.Item(0).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingD.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                Case "8"
                                    Tab_ParkingD.Controls.Item(1).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingD.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                Case "9"
                                    Tab_ParkingD.Controls.Item(2).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingD.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                Case "10"
                                    Tab_ParkingD.Controls.Item(3).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingD.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                Case "11"
                                    Tab_ParkingD.Controls.Item(4).Tag = .Fields("Floor_Id").Value
                                    Tab_ParkingD.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                Case "12"
                                    Tab_ParkingD.Controls.Item(5).Tag = .Fields("Floor_Id").Value
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

    Private Sub btn_Capture_Screen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Capture_Screen.Click
        Try

            ' sql = ""
            sql = "" & " delete from Mas_Capture_Screen where "
            sql &= " [Log_Building_ID] = '" & Public_Building_ID & "'"
            sql &= " and [Log_Floor_No] = '" & Public_Floor_NO & "'"
            If rdo_Day.Checked = True Then
                sql &= " and [Log_Days] = '" & Cmb_Day.Text & "'"
            End If

            sql &= " and [Log_Month] = '" & cmb_Month.Text & "'"
            sql &= " and  [Log_Years] = '" & cmb_Years.Text & "'"

            If rdo_Many.Checked = True Then
                sql &= " and [Log_Type_Parking] = 'MANY'"
            End If
            If rdo_Time.Checked = True Then
                sql &= " and [Log_Type_Parking]= 'TIME'"
            End If

            mSql_Con.Excute_SQL(ConStr_Master, sql)
        Catch ex As Exception

        End Try

        Call Capture_Screen()

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

        If Cmb_Day.SelectedIndex <= 0 Then
            LogDate = "01/" & cmb_Month.Text & "/" & cmb_Years.Text
            Log_ID = "" & "01" & cmb_Month.Text & cmb_Years.Text
        Else
            LogDate = "" & Cmb_Day.Text & "/" & cmb_Month.Text & "/" & cmb_Years.Text
            Log_ID = "" & Cmb_Day.Text & cmb_Month.Text & cmb_Years.Text
        End If


        Log_ID &= Format(Now, "yyyyMMddhhmmss")
        Public_Log_ID = "" & Log_ID
        sql &= " insert into [Mas_Capture_Screen]"
        sql &= "([Log_ID]"
        sqlStr &= " VALUES('" & Log_ID & "'"

        sql &= ",[Log_Tower_ID]"
        If Cur_Tower_ID = "" Then Cur_Tower_ID = "" & "1"
        sqlStr &= ",'" & Cur_Tower_ID & "'"
        sql &= ",[Log_Building_ID]"
        sqlStr &= ",'" & Public_Building_ID & "'"
        sql &= ",[Log_Floor_No]"
        sqlStr &= ",'" & Public_Floor_NO & "'"
        sql &= ",[Log_Date]"
        sqlStr &= "," & mDB.DBFormatDate(LogDate) & ""

        If Cmb_Day.SelectedIndex > 0 Then
            sql &= ",[Log_Days]"
            sqlStr &= ",'" & GenMonth(Cmb_Day.Text) & "'"
        End If

        sql &= ",[Log_Month]"
        sqlStr &= ",'" & GenMonth(cmb_Month.Text) & "'"
        sql &= ",[Log_Years]"
        sqlStr &= ",'" & cmb_Years.Text & "'"

        If Rdo_Month.Checked = True Then
            sql &= ",[Log_Conditon_DayMonth] "
            sqlStr &= ",'" & Rdo_Month.Text & "'"
        End If
        If rdo_Day.Checked = True Then
            sql &= ",[Log_Conditon_DayMonth] "
            sqlStr &= ",'" & rdo_Day.Text & "'"
        End If

        If rdo_Many.Checked = True Then
            sql &= ",[Log_Conditon_ManyTime] "
            sqlStr &= ",'" & rdo_Many.Text & "'"
            sql &= ",[Log_Average_Parking]"
            sqlStr &= ",'" & CInt((DgvDetail.RowCount - 1)) \ CDbl((lbl_Max_Parking.Text)) & "'"
            sql &= ",[Log_Parking_Values]"
            sqlStr &= ",'" & DgvDetail.RowCount - 1 & "'"
            sql &= ",[Log_Type_Parking]"
            sqlStr &= ",'MANY'"
        End If
        If rdo_Time.Checked = True Then
            sql &= ",[Log_Conditon_ManyTime] "
            sqlStr &= ",'" & rdo_Time.Text & "'"
            sql &= ",[Log_Average_Parking]"
            sqlStr &= ",'" & CInt((dgv_Time.RowCount - 1)) \ CDbl((lbl_Max_Parking.Text)) & "'"
            sql &= ",[Log_Parking_Values]"
            sqlStr &= ",'" & dgv_Time.RowCount - 1 & "'"
            sql &= ",[Log_Type_Parking]"
            sqlStr &= ",'TIME'"
        End If

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

    Sub Save_Capture_Screen_Parking_HOUR()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim sqlStr As String = ""
        Dim Log_ID As String = ""
        Dim LogDate As String = ""

        If Cmb_Day.SelectedIndex < 0 Then
            LogDate = "01/" & cmb_Month.Text & "/" & cmb_Years.Text
        Else
            LogDate = "" & Cmb_Day.Text & "/" & cmb_Month.Text & "/" & cmb_Years.Text
        End If


        Log_ID = "" & Format(Now, "yyyyMMddhhmmss")

        sql &= " insert into [Mas_Capture_Screen]"
        sql &= "([Log_ID]"
        sqlStr &= " VALUES('" & Log_ID & "'"
        sql &= ",[Log_Date]"
        sqlStr &= "," & mDB.DBFormatDate(LogDate) & ""

        If Cmb_Day.SelectedIndex > 0 Then
            sql &= ",[Log_Days]"
            sqlStr &= ",'" & GenMonth(Cmb_Day.Text) & "'"
        End If

        sql &= ",[Log_Month]"
        sqlStr &= ",'" & GenMonth(cmb_Month.Text) & "'"
        sql &= ",[Log_Years]"
        sqlStr &= ",'" & cmb_Years.Text & "'"
        sql &= ",[Log_Max_Parking]"
        sqlStr &= ",'" & lbl_Max_Parking.Text & "'"
        sql &= ",[Log_Parking_Values]"
        sqlStr &= ",'" & DgvDetail.RowCount - 1 & "'"
        sql &= ",[Log_Average_Parking]"
        sqlStr &= ",'" & CDbl((lbl_Max_Parking.Text) / CInt((DgvDetail.RowCount - 1))) & "'"
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
   
    Private Sub Tab_Building_SelectedTabChanged(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles Tab_Building.SelectedTabChanged
        Try
            If Tab_Building.SelectedTabIndex = 0 Then
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                

            Else
                Public_Building_ID = "" & Tab_Building.SelectedTab.Tag
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
                
            End If
            sql = ""
            sql &= " select Floor_Lot_All from Mas_Floor"
            sql &= " where Building_ID = '" & Public_Building_ID & "'"
            sql &= " and  Floor_No  = '" & Public_Floor_NO & "'"

            lbl_Max_Parking.Text = "" & Get_Field_As_Select(ConnStrMasTer, sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tab_ParkingA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_ParkingA.SelectedIndexChanged
        Try
            If Tab_ParkingA.SelectedIndex = 0 Then
                Public_Floor_NO = "" & "1"
            Else
                Public_Floor_NO = "" & Tab_ParkingA.SelectedTab.Tag
            End If
        Catch ex As Exception
        End Try

        sql = ""
        sql &= " select Floor_Lot_All from Mas_Floor"
        sql &= " where Building_ID = '" & Public_Building_ID & "'"
        sql &= " and  Floor_No  = '" & Public_Floor_NO & "'"

        lbl_Max_Parking.Text = "" & Get_Field_As_Select(ConnStrMasTer, sql)
    End Sub

    Private Sub Tab_ParkingD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_ParkingD.SelectedIndexChanged
        Try
            If Tab_ParkingD.SelectedIndex = 0 Then
                Public_Floor_NO = "" & "1"
            Else
                Public_Floor_NO = "" & Tab_ParkingD.SelectedTab.Tag
            End If
        Catch ex As Exception
        End Try

        sql = ""
        sql &= " select Floor_Lot_All from Mas_Floor"
        sql &= " where Building_ID = '" & Public_Building_ID & "'"
        sql &= " and  Floor_No  = '" & Public_Floor_NO & "'"

        lbl_Max_Parking.Text = "" & Get_Field_As_Select(ConnStrMasTer, sql)
    End Sub

    Private Sub btn_Report_Click(sender As System.Object, e As System.EventArgs) Handles btn_Report.Click
        Dim Name_Report As String = ""
        Dim Description As String = ""
        Name_Report = "" & Me.Text
        Description &= "" & Me.Text
        If Rdo_Month.Checked = True Then Description &= " " & Rdo_Month.Text
        If rdo_Day.Checked = True Then Description &= " " & rdo_Day.Text

        If rdo_Many.Checked = True Then Description &= " : " & rdo_Many.Text 'rdo_Many
        If rdo_Time.Checked = True Then Description &= " : " & rdo_Time.Text 'rdo_Time

        Dim frm As New frm_RPT_CAR_Parking_Month
        With frm
            mForm.Set_Standard_Form(frm, True, Name_Report)
            .pHeader_Detail = Name_Report
            .LogID = Public_Log_ID
            .Description = Description
            .ShowDialog()
            .Dispose()
        End With

    End Sub
End Class