Option Explicit On
'Option Strict On
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Stream
Imports System.Text
Imports VB = Microsoft.VisualBasic
Imports System.Threading
Public Class frm_Setting_Lot_to_Display
    Dim Go As Boolean
    Dim LeftSet As Boolean
    Dim TopSet As Boolean

    REM These will hold the mouse position
    Dim HoldLeft As Integer
    Dim HoldTop As Integer

    REM These will hold the offset of the mouse in the element
    Dim OffLeft As Integer
    Dim OffTop As Integer
    Dim lbl(900) As Label
    Dim lbl_Zone(900) As Label
    Dim lbl_BZN(900) As Label
    Dim A, R, G, B As Integer
    Dim I_Index As Short
    Private Sub frm_Setting_Lot_to_Display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        AddCombo(ConnStrMasTer, Me.cmb_Tower, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")

    End Sub
    Function Show_Picture(ByVal FloorNO As String, ByVal BuildingID As String, ByVal TowerID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Picture_Floor.Controls.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "Select * from Mas_Floor WHERE Floor_No = " & FloorNO & " and Building_ID =" & BuildingID & " and Tower_ID = " & TowerID & ""
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
                        Picture_Floor.Image = Image.FromStream(Ms)
                    Else
                        Picture_Floor.Image = Picture_Floor.ErrorImage
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

    Sub Load_Display_Zone_Name(Optional ByVal Zone_Display_No As String = Nothing)

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        Try
            sql &= " SELECT * FROM [Mas_Zone_Display] "
            sql &= " where Zone_Tower_ID  =" & cmb_Tower.SelectedValue & ""
            sql &= " and Zone_Building_ID = " & cmb_Building.SelectedValue & ""
            If Zone_Display_No <> "" Then
                sql &= " and Zone_Display_No = " & Zone_Display_No & ""
            Else
                sql &= " and Zone_Floor_No  = " & cmb_Floor.SelectedValue & ""
            End If

            sql &= "  order by Zone_Id"
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
                                .Tag = rs.Fields("Zone_Id").Value
                                .Text = rs.Fields("Zone_Id").Value
                                .Font = New Font("7 Segment", CInt(rs.Fields("Font_Size").Value), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.MiddleCenter
                                .Cursor = Cursors.Hand
                                .TabIndex = I_Index
                                .BackColor = Color.FromArgb(rs.Fields("Zone_Back_ColorA").Value, rs.Fields("Zone_Back_ColorR").Value, rs.Fields("Zone_Back_ColorG").Value, rs.Fields("Zone_Back_ColorB").Value)
                                .ForeColor = Color.FromArgb(rs.Fields("Zone_Font_ColorA").Value, rs.Fields("Zone_Font_ColorR").Value, rs.Fields("Zone_Font_ColorG").Value, rs.Fields("Zone_Font_ColorB").Value)
                                .Location = New Point(rs.Fields("Zone_PositionX").Value, rs.Fields("Zone_PositionY").Value)
                                .Parent = Me
                                AddHandler .Click, AddressOf Me.Button_Click_Zone
                                'AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                                'AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                                'AddHandler .MouseUp, AddressOf nodebtn_MouseUp
                                Me.Picture_Floor.Controls.Add(lbl_Zone(I_Index)) 'เพิ่ม Button
                            End With
                            .MoveNext()
                        Loop
                    Else
                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "โหลดป้าย แสดงผลตามชั้น ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Load_Object_Sensor()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        I_Index = 0
        Try
            sql = "select * FROM Q_Mas_Lot"
            sql &= " where HW_Floor_No = " & cmb_Floor.SelectedValue & ""
            sql &= " and HW_Building_ID = " & cmb_Building.SelectedValue & ""
            sql &= " and HW_Tower_ID = " & cmb_Tower.SelectedValue & ""
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
                            I_Index = Val(I_Index) + 1
                            lbl(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                            With Me.lbl(I_Index)
                                .Size = New Size(Public_Size_X, Public_Size_Y) 'ขนาด button
                                .Name = rs.Fields("HW_Lot_Id").Value  'ชื่อ button
                                .Tag = I_Index
                                .BorderStyle = BorderStyle.Fixed3D
                                .TextAlign = ContentAlignment.TopCenter
                                .Cursor = Cursors.Hand
                                .TabIndex = I_Index
                                'A = rs.Fields("Status_Alarm_Color_A").Value
                                'R = rs.Fields("Status_Alarm_Color_R").Value
                                'G = rs.Fields("Status_Alarm_Color_G").Value
                                'B = rs.Fields("Status_Alarm_Color_B").Value
                                '.BackColor = Color.FromArgb(A, R, G, B)
                                .BackColor = Color.FromArgb(255, 0, 255, 0)

                                If rs.Fields("HW_Status_Id").Value = 0 _
                                   And rs.Fields("HW_Position_X").Value <> 0 _
                                   And rs.Fields("HW_Position_Y").Value <> 0 Then
                                    .Location = New Point(rs.Fields("HW_Position_X").Value, rs.Fields("HW_Position_Y").Value)
                                Else
                                    .Location = New Point(rs.Fields("HW_Position_X").Value, rs.Fields("HW_Position_Y").Value) 'ตำแหน่ง button X,Y HW_Position_X
                                    If rs.Fields("HW_Position_X").Value = 0 _
                                   And rs.Fields("HW_Position_Y").Value = 0 Then
                                        .Visible = False
                                    End If
                                End If
                                .Parent = Me
                                AddHandler .Click, AddressOf Me.Button_Click_Sensor
                                Me.Picture_Floor.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                            End With
                            .MoveNext()
                        Loop
                    Else
                        Me.Picture_Floor.Controls.Remove(lbl(I_Index))
                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "โหลดอุปกรณ์ ตรวจสอบตามชั้น", Err.Number, Err.Description)
        End Try
    End Sub
    Private Sub Button_Click_Zone(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lbl_Zone_Name.Tag = sender.tag
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim I_Index As Short = 0
        If lbl_Zone_Name.Tag <= 0 Then Exit Sub
        Try
            sql &= " SELECT Zone_Display_Name FROM Mas_Zone_Display "
            sql &= " where [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
            sql &= " and [Zone_Building_ID] = " & cmb_Building.SelectedValue & ""
            If chk_Zone.Checked = False Then
                sql &= " and [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""
            End If
            sql &= " and [Zone_Id] = " & lbl_Zone_Name.Tag & ""


            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        lbl_Zone_Name.Text = rs.Fields("Zone_Display_Name").Value
                    Else
                    End If
                End With
            End If


        Catch ex As Exception
            Call mError.ShowError(Me.Name, "กำหนดป้ายแสดงผลลานจอดรถ ที่เลือก", Err.Number, Err.Description)
        End Try
    End Sub



    Private Sub Button_Click_Sensor(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim I_Index As Short
        I_Index = sender.tag
        lbl_Lot_Name.Tag = sender.name
        lbl(I_Index).BackColor = Color.DarkGreen
        lbl_Lot_ID.Text = "" & sender.name

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        If lbl_Zone_Name.Tag <= 0 Then Exit Sub
        Try
            sql = "SELECT HW_Lot_Name " & _
                  "FROM Mas_Lot where HW_Lot_Id =" & lbl_Lot_ID.Text & ""
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        lbl_Lot_Name.Text = rs.Fields("HW_Lot_Name").Value
                    Else
                    End If
                End With
            End If
            If chk_Save_Auto.Checked = True Then
                Call Auto_Save()
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงรายละเอียด อุปกรณ์ตรวจสอบที่เลือก", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Auto_Save()

        Dim sql As String = ""
        Dim sql_Value As String = ""

        If lbl_Zone_Name.Text = "" Then Exit Sub
        If lbl_Lot_Name.Text = "" Then Exit Sub
        Dim Floor_Controller_ID As String = ""
        Dim Zone_Display_No As String = ""
        Dim HW_Building_Controller_ID As String = ""
        HW_Building_Controller_ID = Get_Value_AS_Select(ConnStrGuidance, "Mas_Lot", "HW_Building_Controller_ID", " HW_Lot_Id = '" & lbl_Lot_ID.Text & "'")
        Floor_Controller_ID = Get_Value_AS_Select(ConnStrGuidance, "Mas_Lot", "HW_Floorcontroller_Id", " HW_Lot_Id = '" & lbl_Lot_ID.Text & "'")
        Zone_Display_No = Get_Value_AS_Select(ConnStrMasTer, "Mas_Zone_Display", "Zone_Display_No", " Zone_Id = " & lbl_Zone_Name.Tag & "")
        Try
            sql &= "  delete from  [Mas_Lot_In_Zone_Display] where "
            sql &= " [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
            sql &= " and [Zone_Building_ID] = " & cmb_Building.SelectedValue & ""
            sql &= " and [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""
            sql &= " and [Zone_Display_ID] = " & lbl_Zone_Name.Tag & ""
            sql &= " and [Zone_Display_No] = " & Zone_Display_No & ""
            sql &= " and  [Zone_Floor_Controller_ID] = " & Floor_Controller_ID & ""
            sql &= " and [Zone_HW_Lot_ID] = '" & lbl_Lot_ID.Text & "'"
            Excute_SQL(ConStr_Master, sql)
            sql = ""
        Catch ex As Exception

        End Try

        Try
            sql &= "" & "  INSERT INTO [Mas_Lot_In_Zone_Display]"
            sql_Value &= "" & " VALUES("
            sql &= " ([Zone_Tower_ID]"
            sql_Value &= " " & cmb_Tower.SelectedValue & ""

            sql &= " ,[Zone_Building_ID]"
            sql_Value &= ", " & cmb_Building.SelectedValue & ""

            sql &= " ,[Zone_Floor_No]"
            sql_Value &= "," & cmb_Floor.SelectedValue & ""

            sql &= " ,[Zone_Display_ID]"
            sql_Value &= "," & lbl_Zone_Name.Tag & ""

            sql &= " ,[Zone_Display_No]"
            sql_Value &= "," & Zone_Display_No & ""

            sql &= " , [Zone_Floor_Controller_ID] "
            sql_Value &= "," & Floor_Controller_ID & ""

            sql &= " ,[Zone_HW_Lot_ID]"
            sql_Value &= ",'" & lbl_Lot_ID.Text & "'"

            sql &= " ,[Zone_HW_Address]"
            sql_Value &= ",'" & Mid(lbl_Lot_ID.Text, 10, 2) & "'"

            sql &= " ,[Zone_Building_Controller_ID] ) "
            sql_Value &= ",'" & HW_Building_Controller_ID & "'"

            sql_Value &= " )"
            Excute_SQL(ConStr_Master, sql & sql_Value)
            sql &= ""
        Catch ex As Exception

        End Try

        Call Count_Zone(lbl_Zone_Name.Tag, Zone_Display_No)
    End Sub

    Sub Save_ALL_Lot_Parking()
        Dim sql As String = ""
        Dim sql_Value As String = ""
        Dim Floor_Controller_ID As String = ""
        Dim Zone_Display_No As String = ""
        Dim i As Integer
        Try
            Con = New SqlConnection(ConStr_Guidance)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Guidance
                .Open()
            End With
        Catch ex As Exception

        End Try


        Try

            sql &= " Select  HW_Lot_Id,HW_Floorcontroller_Id,HW_Building_Controller_ID"
            sql &= " FROM Mas_Lot "
            sql &= " where [HW_Tower_ID] = " & cmb_Tower.SelectedValue & ""
            sql &= " and [HW_Building_ID] = " & cmb_Building.SelectedValue & ""
            sql &= " and [HW_Floor_No] = " & cmb_Floor.SelectedValue & ""
            sql &= " order by HW_Lot_Id "
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Mas_Lot")
            Con.Close()
            If sqlDs.Tables("Mas_Lot").Rows.Count <> 0 Then
                Zone_Display_No = Get_Value_AS_Select(ConnStrMasTer, "Mas_Zone_Display", "Zone_Display_No", " Zone_Id = " & lbl_Zone_Name.Tag & "")

                ProgressBarX1.Visible = True
                ProgressBarX1.Value = 0
                ProgressBarX1.Maximum = sqlDs.Tables("Mas_Lot").Rows.Count

                For i = 0 To sqlDs.Tables("Mas_Lot").Rows.Count - 1
                    ProgressBarX1.Value = i
                    ' sqlDs.Tables("Mas_Lot").Rows(i)(0).ToString()

                    Try
                        sql = ""
                        sql &= "  delete from  [Mas_Lot_In_Zone_Display] where "
                        sql &= " [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
                        sql &= " and [Zone_Building_ID] = " & cmb_Building.SelectedValue & ""
                        sql &= " and [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""
                        sql &= " and [Zone_Display_ID] = " & lbl_Zone_Name.Tag & ""
                        sql &= " and [Zone_Display_No] = " & Zone_Display_No & ""
                        sql &= " and [Zone_Floor_Controller_ID] = " & sqlDs.Tables("Mas_Lot").Rows(i)(1).ToString() & ""
                        sql &= " and [Zone_HW_Lot_ID] = '" & sqlDs.Tables("Mas_Lot").Rows(i)(0).ToString() & "'"
                        Excute_SQL(ConStr_Master, sql)
                        sql = ""
                    Catch ex As Exception

                    End Try

                    Try
                        sql &= "" & "  INSERT INTO [Mas_Lot_In_Zone_Display]"
                        sql_Value &= "" & " VALUES("
                        sql &= " ([Zone_Tower_ID]"
                        sql_Value &= " " & cmb_Tower.SelectedValue & ""

                        sql &= " ,[Zone_Building_ID]"
                        sql_Value &= ", " & cmb_Building.SelectedValue & ""

                        sql &= " ,[Zone_Floor_No]"
                        sql_Value &= "," & cmb_Floor.SelectedValue & ""

                        sql &= " ,[Zone_Display_ID]"
                        sql_Value &= "," & lbl_Zone_Name.Tag & ""

                        sql &= " ,[Zone_Display_No]"
                        sql_Value &= "," & Zone_Display_No & ""

                        sql &= " , [Zone_Floor_Controller_ID] "
                        sql_Value &= "," & sqlDs.Tables("Mas_Lot").Rows(i)(1).ToString() & ""

                        sql &= " ,[Zone_HW_Lot_ID]"
                        sql_Value &= ",'" & sqlDs.Tables("Mas_Lot").Rows(i)(0).ToString() & "'"

                        sql &= " ,[Zone_HW_Address]"
                        sql_Value &= ",'" & Mid(sqlDs.Tables("Mas_Lot").Rows(i)(0).ToString(), 10, 2) & "'"

                        sql &= " ,[Zone_Building_Controller_ID] ) "
                        sql_Value &= ",'" & sqlDs.Tables("Mas_Lot").Rows(i)(2).ToString() & "'"

                        sql_Value &= " )"
                        Excute_SQL(ConStr_Master, sql & sql_Value)
                        sql &= ""
                        sql_Value = ""
                    Catch ex As Exception

                    End Try


                Next
            End If
        Catch ex As Exception
            Con.Close()
        End Try
        ProgressBarX1.Visible = False
    End Sub

    Sub Count_Zone(ByVal Zone_Display_ID As String, ByVal Zone_Display_No As String)
        sql = "" & " select count(*) as Acount from Mas_Lot_In_Zone_Display where Zone_Display_No=" & Zone_Display_ID & ""
        sql &= " and Zone_Display_No = " & Zone_Display_No & ""
        sql &= " and Zone_Building_ID = " & cmb_Building.SelectedValue & ""
        sql &= " and Zone_Floor_No = " & cmb_Floor.SelectedValue & ""
        sql &= " and Zone_Tower_ID = " & cmb_Tower.SelectedValue & ""
        lbl_Count.Text = "" & Count_By_Condition(sql, ConnStrMasTer)
    End Sub
    Private Sub cmb_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floor.SelectedIndexChanged
        If cmb_Floor.SelectedIndex > 0 Then
            Me.Picture_Floor.Controls.Clear()
            Me.Show_Picture(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
            Call Load_Object_Sensor()
           
            Call Load_Display_Zone_Name()
        End If
    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If CStr(lbl_Zone_Name.Tag) = "" Then Exit Sub
        If chk_All_Floor.AutoCheck = True Then
            Save_ALL_Lot_Parking()
            Exit Sub
        End If
        Call Auto_Save()


    End Sub
 

    Private Sub cmb_Building_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Building.SelectedIndexChanged
        If cmb_Building.SelectedIndex <= 0 Then Exit Sub
        Try
            AddCombo(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "Floor_Name", "Floor_Id", "Building_ID = " & cmb_Building.SelectedValue & "", "Floor_Id", "---กรุณาเลือก ชั้น---")
            cmb_Floor.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmb_Tower_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Tower.SelectedIndexChanged
        If cmb_Tower.SelectedIndex <= 0 Then Exit Sub
        AddCombo(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "Building_Name", "Building_ID", "", "Building_Name", "ทั้งหมด")
        cmb_Building.Enabled = True

    End Sub

    Private Sub chk_Save_Auto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Save_Auto.CheckedChanged
        If chk_Save_Auto.Checked = False Then
            btn_Save.Visible = True
        Else
            btn_Save.Visible = False
        End If
    End Sub

    Private Sub chk_Zone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Zone.CheckedChanged
        If chk_Zone.Checked = True Then
            cmb_Zone.Enabled = True
            AddCombo2(ConnStrMasTer, Me.cmb_Zone, "Mas_Zone_Display", "FUll_Name", "Zone_Display_No", "", "Zone_Display_No", "<--เลือกทั้งหมด-->", "Zone_Display_No ,  convert(nvarchar(255),Zone_Display_No) +  ' : ' +  Zone_Display_Name  as FUll_Name")

        Else
            cmb_Zone.Enabled = False

        End If
    End Sub

    Private Sub cmb_Zone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Zone.SelectedIndexChanged
        If cmb_Zone.SelectedIndex <= 0 Then Exit Sub

        Me.Show_Picture(cmb_Floor.SelectedValue, cmb_Building.SelectedValue, cmb_Tower.SelectedValue)
        Load_Object_Sensor()
        Load_Display_Zone_Name(cmb_Zone.SelectedValue)

        lbl_Lot_ID.Text = ""
        lbl_Lot_Name.Text = ""
        lbl_Count.Text = ""

    End Sub

    Private Sub btn_Export_Zone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export_Zone.Click
        Dim i As Integer
        Dim Msg_Value As String = ""
        Try
            Kill(Drive & Path_Export)
        Catch ex As Exception

        End Try
        Try
            Con = New SqlConnection(ConStr_Master)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Master
                .Open()
            End With
        Catch ex As Exception

        End Try



        Try

            sql = ""
            sql &= "  Select [Zone_Tower_ID]"
            sql &= " ,[Zone_Building_ID]"
            sql &= " ,[Zone_Display_No]"
            sql &= " ,[Zone_Floor_Controller_ID]"
            sql &= " ,[MIN_ADDRESS]"
            sql &= " ,[MAX_ADDRESS]"
            sql &= " FROM [QR_EXPORT_DISPLAY_IN_FLOOR]"
            sql &= "  order by  [Zone_Tower_ID]"
            sql &= " ,[Zone_Building_ID]"
            sql &= " ,[Zone_Display_No]"
            sql &= " ,[Zone_Floor_Controller_ID]"

            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "QR_EXPORT_DISPLAY_IN_FLOOR")
            Con.Close()
            If sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows.Count <> 0 Then
                ProgressBarX1.Visible = True
                ProgressBarX1.Value = 0
                ProgressBarX1.Maximum = sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows.Count

                For i = 0 To sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows.Count - 1
                    ProgressBarX1.Value = i
                    Msg_Value = ""
                    Msg_Value &= sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows(i)(0).ToString() & "|" '"Tower_ID|"
                    Msg_Value &= sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows(i)(1).ToString() & "|" ' "Building_ID|"
                    Msg_Value &= sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows(i)(2).ToString() & "|" '"Zone_Display_No|"
                    Msg_Value &= sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows(i)(3).ToString() & "|" '"Zone_Floor_Controller_ID|"
                    Msg_Value &= sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows(i)(4).ToString() & "-" & sqlDs.Tables("QR_EXPORT_DISPLAY_IN_FLOOR").Rows(i)(5).ToString() '"MIN Address - MAX address"
                    Write_File_Export_Config_Display_Guidance(Msg_Value)
                Next
            End If
            Msg_Value = ""
            Msg_Value &= "Tower_ID|"
            Msg_Value &= "Building_ID|"
            Msg_Value &= "Zone_Display_No|"
            Msg_Value &= "Zone_Floor_Controller_ID|"
            Msg_Value &= "MIN Address - MAX address"
            Write_File_Export_Config_Display_Guidance(Msg_Value)
            ProgressBarX1.Visible = False
            MessageBox.Show("ส่งออกข้อมูลเสร็จเรียบร้อย  !!! ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
    End Sub

    Function Write_File_Export_Config_Display_Guidance(ByVal Msg_Value As String) As Boolean

        Dim aFile As String
        Dim aFree As Integer
        Try
            If Dir(Drive, FileAttribute.Directory) = "" Then MkDir((Drive))
            aFile = Drive & Path_Export

            aFree = FreeFile()
            FileOpen(aFree, aFile, OpenMode.Append)
            Do While Not EOF(aFree) : Loop
            PrintLine(aFree, Msg_Value)
            '  PrintLine(aFree, Msg_Value + Environment.NewLine)
            FileClose(aFree)
        Catch ex As Exception

        End Try


        Return True
    End Function
   
    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
       

        Dim Zone_Display_No As String = ""

        If MessageBox.Show("คุณต้องการลบข้อมูลการจัดโซนป้ายแสดงผล ที่เลือกใช่หรือไม่ ??? ", "ยีนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Zone_Display_No = Get_Value_AS_Select(ConnStrMasTer, "Mas_Zone_Display", "Zone_Display_No", " Zone_Id = " & lbl_Zone_Name.Tag & "")
            sql = ""
            sql &= "  delete from  [Mas_Lot_In_Zone_Display] where "
            sql &= " [Zone_Tower_ID] = " & cmb_Tower.SelectedValue & ""
            sql &= " and [Zone_Building_ID] = " & cmb_Building.SelectedValue & ""
            sql &= " and [Zone_Floor_No] = " & cmb_Floor.SelectedValue & ""
            sql &= " and [Zone_Display_ID] = " & lbl_Zone_Name.Tag & ""
            sql &= " and [Zone_Display_No] = " & Zone_Display_No & ""
            Excute_SQL(ConStr_Master, sql)
            If Result_SQL = True Then
                MessageBox.Show("ลบข้อมูลเสร็จเรียบร้อย !!!! ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If



    End Sub

    Private Sub Picture_Floor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Picture_Floor.Click

    End Sub
End Class