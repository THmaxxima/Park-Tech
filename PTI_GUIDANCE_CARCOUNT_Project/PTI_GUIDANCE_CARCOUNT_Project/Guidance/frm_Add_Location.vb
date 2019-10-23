Imports VB = Microsoft.VisualBasic
Imports System.Threading
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports System.Drawing.Graphics
REM Imports System.Collections.Generic
Public Class frm_Add_Location

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
    Dim X, Y As Integer
    Public lbl(4500) As Label
    'Dim Count As Integer REM นับจำนวน Button 

    Dim ClsSqlCmd As New ClassCommandSql
    Friend StrQury As String
    Friend DateSt As DateTime
    Friend DateEnd As DateTime
    Dim sqlDa As New OleDbDataAdapter
    Dim sqlDs As New DataSet
    Dim isFind As Boolean = False
    Dim bs As New BindingSource
    Dim A, R, G, B As Integer
    Dim Location_FloorID As String = ""
    Dim I_Index As Short = 0
    Dim index_ As String
    Dim index As String
    Dim lbl_Zone(200) As Label
    Private Sub btn_Test_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = True
    End Sub
    Sub Add_Button()
        Dim Y As Integer
        Y = 30
        '  Dim Result As DialogResult
        Dim btn As New Button() REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
        ' Count = Count + 1
        btn.Text = lbl_Id.Text 'ข้อความบน button
        Dim graphics As Graphics = btn.CreateGraphics
        Dim pen As Pen = New Pen(Color.Green)
        graphics.DrawLine(pen, 0, 0, 30, 30)
        btn.Size = New Size(30, 30) 'ขนาด button
        btn.Location = New Point(3, 1) 'ตำแหน่ง button
        btn.Name = lbl_Id.Text  'ชื่อ button
        btn.BackColor = System.Drawing.Color.White
        btn.ForeColor = System.Drawing.Color.Blue
        AddHandler btn.Click, AddressOf Me.Button_Click
        AddHandler btn.MouseDown, AddressOf nodebtn_MouseDown
        AddHandler btn.MouseMove, AddressOf nodebtn_MouseMove
        AddHandler btn.MouseUp, AddressOf nodebtn_MouseUp
        AddHandler btn.KeyDown, AddressOf iKey
        Y = Y + 30
        'Me.Picture_Floor.Controls.Add(btn) 'เพิ่ม Button
        ' lbl_Count.Text = Count
    End Sub
    Sub Load_Button(Optional ByVal FloorControllerID As String = "", Optional ByVal FloorID As String = "")
        On Error GoTo Err_Renamed

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim PositionX As Integer = 20 ' X not < 750 20
        Dim PositionY As Integer = 26 ' 26
        Dim sql As String = ""
        Dim i As Integer
        I_Index = 0
        Select Case FloorID
            Case "1"
                Me.Picture_Floor_1.Controls.Clear()
            Case "2"
                Me.Picture_Floor_2.Controls.Clear()
            Case "3"
                Me.Picture_Floor_3.Controls.Clear()
            Case "4"
                Me.Picture_Floor_4.Controls.Clear()
            Case "5"
                Me.Picture_Floor_5.Controls.Clear()
            Case "6"
                Me.Picture_Floor_6.Controls.Clear()
            Case "7"
                Me.Picture_Floor_1.Controls.Clear()
            Case "8"
                Me.Picture_Floor_2.Controls.Clear()
            Case "9"
                Me.Picture_Floor_3.Controls.Clear()
            Case "10"
                Me.Picture_Floor_4.Controls.Clear()
            Case "11"
                Me.Picture_Floor_5.Controls.Clear()
            Case "12"
                Me.Picture_Floor_6.Controls.Clear()
        End Select
        'Me.Show_Picture(i)
        sql = "SELECT distinct HW_Lot_Id,HW_Status_Id,HW_Position_X,HW_Position_Y,Floor_Name, " & _
              "Status_Alarm_Color_A, Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B,HW_Lot_Type " & _
              "FROM Q_Mas_Lot "
        sql &= " where HW_Floorcontroller_Id  = " & FloorControllerID & " "
        sql &= " and HW_Floor_No = " & FloorID & ""
        sql &= " and HW_Building_ID = " & cboTowerId.SelectedValue & ""
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
                        I_Index += 1
                        If PositionX >= 700 Then
                            PositionX = 20
                            PositionY = PositionY + 20
                        End If
                        lbl(I_Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                        With Me.lbl(I_Index)
                            .Size = New Size(Public_Size_X, Public_Size_Y) 'ขนาด button
                            .Name = rs.Fields("HW_Lot_Id").Value  'ชื่อ button
                            .Tag = rs.Fields("HW_Lot_Id").Value
                            .BorderStyle = BorderStyle.Fixed3D
                            .TextAlign = ContentAlignment.TopCenter
                            .Cursor = Cursors.Hand
                            .TabIndex = I_Index
                            .BackColor = System.Drawing.Color.Lime ' is Color Green
                            'rs.Fields("HW_Status_Id").Value = 0  And
                            If  rs.Fields("HW_Position_X").Value = 0 _
                                And rs.Fields("HW_Position_Y").Value = 0 Then
                                .Location = New Point(PositionX, PositionY) 'ตำแหน่ง button X,Y HW_Position_X
                                .BackColor = Color.Magenta
                            Else
                                .Location = New Point(rs.Fields("HW_Position_X").Value, rs.Fields("HW_Position_Y").Value)
                                ' If rs.Fields("HW_Status_Id").Value = 1 Then
                                .ImageIndex = 1
                                A = rs.Fields("Status_Alarm_Color_A").Value
                                R = rs.Fields("Status_Alarm_Color_R").Value
                                G = rs.Fields("Status_Alarm_Color_G").Value
                                B = rs.Fields("Status_Alarm_Color_B").Value
                                If rs.Fields("HW_Lot_Type").Value = "L" Then
                                    .BackColor = Color.Sienna
                                Else
                                    .BackColor = Color.SeaGreen
                                End If
                                '.BackColor = Color.FromArgb(A, R, G, B)
                                'End If
                            End If
                            .Parent = Me
                            AddHandler .Click, AddressOf Me.Button_Click
                            AddHandler .MouseDown, AddressOf nodebtn_MouseDown
                            AddHandler .MouseMove, AddressOf nodebtn_MouseMove
                            AddHandler .MouseUp, AddressOf nodebtn_MouseUp

                            Select Case FloorID
                                Case "1"
                                    Me.Picture_Floor_1.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "2"
                                    Me.Picture_Floor_2.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "3"
                                    Me.Picture_Floor_3.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "4"
                                    Me.Picture_Floor_4.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "5"
                                    Me.Picture_Floor_5.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "6"
                                    Me.Picture_Floor_6.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "7"
                                    Me.Picture_Floor_1.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "8"
                                    Me.Picture_Floor_2.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "9"
                                    Me.Picture_Floor_3.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "10"
                                    Me.Picture_Floor_4.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "11"
                                    Me.Picture_Floor_5.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                                Case "12"
                                    Me.Picture_Floor_6.Controls.Add(lbl(I_Index)) 'เพิ่ม Button
                            End Select

                        End With
                        PositionX = PositionX + 40
                        .MoveNext()
                        'Count = Count + 1
                    Loop
                End If
            End With
        End If

        lbl_Count.Text = Count_Sensor.CountSensor(1)
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "Load_Button ", Err.Number, Err.Description)
    End Sub
    Private Sub iKey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown 'KeyPressEventArgs
        If e.KeyCode = 46 Then
            Me.Controls.Remove(sender)
        End If

        If e.KeyCode = 37 Then 'Key Lift
            HoldLeft = (Control.MousePosition.X - Me.Left)
        End If
        If e.KeyCode = 37 Then 'Key Up
            HoldTop = (Control.MousePosition.Y - Me.Top)
        End If
        If e.KeyCode = 39 Then 'Key Right

        End If

        If e.KeyCode = 37 Then 'Key Down

        End If
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
        End If
    End Sub
    Private Sub iKey_Load(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown 'KeyPressEventArgs
        REM 
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        If e.KeyCode = 46 Then
            sql = " DELETE From Mas_Lot WHERE HW_Lot_Id = " & lbl_Id.Text & " "
            If OpenCnn(ConnStrGuidance, Conn) Then
                Conn.BeginTrans()
                TrnFlg = True
                Conn.Execute(sql)
                If MsgBox("คุณต้องการ ลบข้อมูล รหัส : " & lbl_Id.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Confirm) = MsgBoxResult.Yes Then
                    Conn.CommitTrans()
                    ' Me.Picture_Floor.Controls.Remove(sender)
                    TrnFlg = False
                Else
                    Conn.RollbackTrans()
                    TrnFlg = False
                    Exit Sub
                End If
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "iKey_Load", Err.Number, Err.Description)
    End Sub
    Sub Delete_Mas_Lot()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        If MsgBox("คุณต้องการ ยกเลิกช่องจอด รหัส : " & lbl_Id.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Confirm) = MsgBoxResult.Yes Then

            sql = " update Mas_Lot  set [HW_Position_X] = '0' ,[HW_Position_Y] = '0' "
            sql &= " WHERE HW_Lot_Id = '" & lbl_Id.Text & "' "
            sql &= " and  HW_Building_ID = " & cboTowerId.SelectedValue & ""
            sql &= " and [HW_Floorcontroller_Id] = " & cmb_Floorcontroller_Name.SelectedValue & ""
            Excute_SQL(ConStr_Guidance, sql)
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Delete_Mas_Lot", Err.Number, Err.Description)
    End Sub
    Private Sub iKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown 'KeyPressEventArgs
        REM กดปุ่ม Up Down Left Right
        'Go = True
        If Go = True Then
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            If e.KeyCode = Keys.VolumeUp Then
                HoldTop = (Control.MousePosition.Y - Me.Top)
            End If
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
            lbl_PositionX.Text = sender.Left
            lbl_PositionY.Text = sender.Top
        End If
    End Sub
    Private Sub nodebtn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 46 Then
            ' Me.Picture_Floor.Controls.Remove(sender)
        End If
        If e.KeyCode = Keys.Delete Then
            '  Me.Picture_Floor.Controls.Remove(sender) REM Delete button Complete
        End If
        If Go = True Then
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            If e.KeyCode = Keys.VolumeUp Then
                HoldTop = (Control.MousePosition.Y - Me.Top)
            End If
            sender.Left = HoldLeft - OffLeft
            sender.Top = HoldTop - OffTop
            lbl_PositionX.Text = sender.Left
            lbl_PositionY.Text = sender.Top
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
            sender.backcolor = Color.Orange
            lbl_PositionX.Text = sender.Left
            lbl_PositionY.Text = sender.Top
            lbl_Id.Text = sender.name
            index_ = sender.tag
            lst_Remark.Items.Clear()
            Call Select_Detail_Lot()
            '  Save_Controller_Lot_Unlot()
        End If
    End Sub
    Sub Select_Detail_Lot()

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try


            sql = " SELECT  *  FROM Q_Mas_lot where HW_Lot_Id ='" & lbl_Id.Text & "'"
            If OpenCnn(ConnStrGuidance, Conn, False) Then
                With rs
                    If .State = 1 Then .Close()
                    .ActiveConnection = Conn
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    If Not (.EOF And .BOF) Then
                        .MoveFirst()
                        ' Do While Not .EOF
                        lbl_Name.Text = "" & .Fields("HW_Lot_Name").Value
                        ' lbl_FloorController.Text = "" & .Fields("Floor_Controller_Name").Value
                        lbl_Address.Text = "" & .Fields("HW_Address").Value
                        lst_Remark.Items.Add(.Fields("HW_Remark").Value)
                        '  .MoveNext()
                        'Loop
                    End If
                End With
            End If
            Conn = Nothing
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Select_Detail_Lot", Err.Number, Err.Description)

        End Try
    End Sub
    Private Sub nodebtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = False
        LeftSet = False
        TopSet = False
    End Sub
    Sub Save_Controller_Position()
        On Error GoTo Err
        'Dim DateTime_Change As DateTime = CDate(Format(dtp_Date_Change.Value, "dd/MM/yyyy") & " " & Format(dtp_Time_Change.Value, "HH:mm:ss"))
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "Update Mas_Lot set HW_Position_X = " & lbl_PositionX.Text.Trim & _
              ", HW_Position_Y = " & lbl_PositionY.Text.Trim & _
              " where HW_Lot_Id = '" & lbl_Id.Text.Trim & "'"
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
    Sub Save_Controller_Lot_Unlot(pLot As String)
        On Error GoTo Err
        'Dim DateTime_Change As DateTime = CDate(Format(dtp_Date_Change.Value, "dd/MM/yyyy") & " " & Format(dtp_Time_Change.Value, "HH:mm:ss"))
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        'B=จอดขวาง   ,L = จอดในช่อง
        sql = "Update Mas_Lot set HW_Lot_Type = '" & pLot & "' where HW_Lot_Id = '" & lbl_Id.Text.Trim & "'"
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
        Call mError.ShowError(Me.Name, "Save_Controller_Lot_Unlot", Err.Number, Err.Description)
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
            lbl_PositionX.Text = sender.Left
            lbl_PositionY.Text = sender.Top
            lbl_Id.Text = sender.Name
        End If
    End Sub
    Private Sub frm_Add_Location_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClsSqlCmd = New ClassCommandSql
        mMain.Load_AppConfig()
        AddCombo(ConnStrMasTer, Me.cboTowerId, "Mas_Building_Parking", "Building_Name", "Building_ID", "", "Building_Name", "ทั้งหมด")
        ' AddCombo(ConnStrGuidance, Me.cmb_Floor_Name, "Mas_HW_Floor", "Floor_Name", "Floor_Id", "", "Floor_Id", "---กรุณาเลือก รายการ---")
        ' AddCombo2(ConnStrMasTer, Me.cmb_Floorcontroller_Name, "Mas_DSC", "FUll_DSC", "DSC_Code", "", "DSC_Code", "-กรุณาเลือก Rate-", "DSC_Code , DSC_Code + ' : ' +  DSC_Detail as FUll_DSC")
        AddCombo2(ConnStrMasTer, Me.cmb_Floorcontroller_Name, "Mas_Floor_Controller", "FUll_DSC", "ID", "", "ID", "-กรุณาเลือก Rate-", "ID ,  convert(nvarchar(255),ID) +  ' : ' +  Floor_Controller_Name as FUll_DSC")


        'If User_Level = "5" Or User_Level <> "" Then
        '    btn_Delete.Visible = True
        'Else
        '    btn_Delete.Visible = False
        'End If
        I_Index = 0
        'Me.Show_Picture("1")
        ' Location_FloorID = "1"
        '  Call Load_Button()

    End Sub
    Private Sub btn_Detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Detail.Click
        If lbl_Id.Text.Trim = "" Then Exit Sub
        Dim frm As New frm_Location_Detail
        With frm
            mForm.Set_Standard_Form(frm)
            HW_Lot_Id = lbl_Id.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            .Dispose()
        End With
        Me.Refresh()
    End Sub
    Function Show_Picture(ByVal Floor_ID As String, Optional ByVal Building_ID As String = "") As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Select Case Building_ID
            Case "1"
                Select Case Floor_ID
                    Case "1"
                        Picture_Floor_1.Controls.Clear()
                    Case "2"
                        Picture_Floor_2.Controls.Clear()
                    Case "3"
                        Picture_Floor_3.Controls.Clear()
                    Case "4"
                        Picture_Floor_4.Controls.Clear()
                    Case "5"
                        Picture_Floor_5.Controls.Clear()
                    Case "6"
                        Picture_Floor_6.Controls.Clear()
                End Select
            Case "2"
                Select Case Floor_ID
                    Case "7"
                        Picture_Floor_1.Controls.Clear()
                    Case "8"
                        Picture_Floor_2.Controls.Clear()
                    Case "9"
                        Picture_Floor_3.Controls.Clear()
                    Case "10"
                        Picture_Floor_4.Controls.Clear()
                    Case "11"
                        Picture_Floor_5.Controls.Clear()
                    Case "12"
                        Picture_Floor_6.Controls.Clear()
                End Select
        End Select


        sql = "Select Floor_Image,Floor_Id from Mas_Floor WHERE  Building_ID = " & Building_ID & ""
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
                                    Picture_Floor_1.Image = Image.FromStream(Ms)
                                Case "2"
                                    Picture_Floor_2.Image = Image.FromStream(Ms)
                                Case "3"
                                    Picture_Floor_3.Image = Image.FromStream(Ms)
                                Case "4"
                                    Picture_Floor_4.Image = Image.FromStream(Ms)
                                Case "5"
                                    Picture_Floor_5.Image = Image.FromStream(Ms)
                                Case "6"
                                    Picture_Floor_6.Image = Image.FromStream(Ms)
                                Case "7"
                                    Picture_Floor_1.Image = Image.FromStream(Ms)
                                Case "8"
                                    Picture_Floor_2.Image = Image.FromStream(Ms)
                                Case "9"
                                    Picture_Floor_3.Image = Image.FromStream(Ms)
                                Case "10"
                                    Picture_Floor_4.Image = Image.FromStream(Ms)
                                Case "11"
                                    Picture_Floor_5.Image = Image.FromStream(Ms)
                                Case "12"
                                    Picture_Floor_6.Image = Image.FromStream(Ms)
                            End Select

                        Else
                            Select Case .Fields("Floor_Id").Value.ToString
                                Case "1"
                                    Picture_Floor_1.Image = Picture_Floor_1.ErrorImage
                                Case "2"
                                    Picture_Floor_2.Image = Picture_Floor_1.ErrorImage
                                Case "3"
                                    Picture_Floor_3.Image = Picture_Floor_1.ErrorImage
                                Case "4"
                                    Picture_Floor_4.Image = Picture_Floor_1.ErrorImage
                                Case "5"
                                    Picture_Floor_5.Image = Picture_Floor_1.ErrorImage
                                Case "6"
                                    Picture_Floor_6.Image = Picture_Floor_1.ErrorImage
                                Case "7"
                                    Picture_Floor_1.Image = Picture_Floor_1.ErrorImage
                                Case "8"
                                    Picture_Floor_2.Image = Picture_Floor_1.ErrorImage
                                Case "9"
                                    Picture_Floor_3.Image = Picture_Floor_1.ErrorImage
                                Case "10"
                                    Picture_Floor_4.Image = Picture_Floor_1.ErrorImage
                                Case "11"
                                    Picture_Floor_5.Image = Picture_Floor_1.ErrorImage
                                Case "12"
                                    Picture_Floor_6.Image = Picture_Floor_1.ErrorImage
                            End Select

                        End If
                        .MoveNext()
                    Loop
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

    Private Sub btn_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        'If cmb_Floor_Name.SelectedIndex = 0 Then Exit Sub
        If lbl_Id.Text = "" Then Exit Sub
        Call Delete_Mas_Lot()
    End Sub
    Private Sub grb_Search_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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
            'index_ = Me.Tag
        End If
    End Sub
    Private Sub grb_Search_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = True
    End Sub
    Private Sub grb_Search_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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
    Private Sub grb_Search_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Go = False
    End Sub
    Private Sub btn_Add_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_Search.Click
        Dim frm As New frm_Mas_Lot
        With frm
            mForm.Set_Standard_Form(frm)
            HW_Lot_Id = lbl_Id.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
            .Dispose()
        End With
        Me.Refresh()
        'Call Load_Button()
    End Sub
    Private Sub btn_MainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MainMenu.Click
        Me.Close()
    End Sub
    Private Sub txt_PositionX_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If lbl_PositionX.Text = "" Then Exit Sub
        If lbl(index_).Name = lbl_Id.Text Then
            lbl(I_Index).Location = New Point(lbl_PositionX.Text, lbl_PositionY.Text)
        End If
    End Sub
    Private Sub txt_Pre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Pre.Click
        If lbl_Id.Text = "" Then Exit Sub
        Try
            Dim PositionX As Integer = Val(lbl_PositionX.Text) - 1
            Dim PositionY As Integer = Val(lbl_PositionY.Text)
            lbl_PositionX.Text = PositionX
            lbl(Mid(lbl_Id.Text, 10, 2)).Location = New Point(CInt(PositionX), CInt(PositionY))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_Up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Up.Click
        If lbl_Id.Text = "" Then Exit Sub
        Try
            Dim PositionX As Integer = Val(lbl_PositionX.Text)
            Dim PositionY As Integer = Val(lbl_PositionY.Text) - 1
            lbl_PositionY.Text = PositionY
            lbl(Mid(lbl_Id.Text, 10, 2)).Location = New Point(CInt(PositionX), CInt(PositionY))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Next.Click
        If lbl_Id.Text = "" Then Exit Sub
        Try
            Dim PositionX As Integer = Val(lbl_PositionX.Text) + 1
            Dim PositionY As Integer = Val(lbl_PositionY.Text)
            lbl_PositionX.Text = PositionX
            lbl(Mid(lbl_Id.Text, 10, 2)).Location = New Point(CInt(PositionX), CInt(PositionY))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Down.Click
        If lbl_Id.Text = "" Then Exit Sub
        Try
            Dim PositionX As Integer = Val(lbl_PositionX.Text)
            Dim PositionY As Integer = Val(lbl_PositionY.Text) + 1
            lbl_PositionY.Text = PositionY
            lbl(Mid(lbl_Id.Text, 10, 2)).Location = New Point(CInt(PositionX), CInt(PositionY))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If lbl_Id.Text = "" Then Exit Sub
        Save_Controller_Position()
        lbl_Id.Text = ""
        lbl_Name.Text = ""
        ' lbl_FloorController.Text = ""
        lbl_PositionX.Text = ""
        lbl_PositionY.Text = ""
        lbl_Address.Text = ""
        lst_Remark.Items.Clear()

    End Sub

    Private Sub Tab_Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_Floor.SelectedIndexChanged
        If cboTowerId.SelectedIndex <= 0 Then Exit Sub
        cmb_Floorcontroller_Name.SelectedIndex = 0
        Dim Floor As String = Tab_Floor.SelectedTab.Tag
        If Floor = "" Then
            Floor = 1
        Else
            Me.Show_Picture(Floor, cboTowerId.SelectedValue)
        End If
        AddCombo(ConnStrMasTer, Me.cmb_Floorcontroller_Name, "Mas_Floor_Controller", "Floor_Controller_Name", "Floor_Controller_ID", "Building_ID = " & cboTowerId.SelectedValue & " and Floor_No =" & Tab_Floor.SelectedTab.Tag & " ", "Floor_Controller_ID", "---กรุณาเลือก รายการ---")

        lbl_Count.Text = Count_Sensor.CountSensor(Floor)
        lbl_Id.Text = ""
        lbl_Name.Text = ""
        ' lbl_FloorController.Text = ""
        lbl_PositionX.Text = ""
        lbl_PositionY.Text = ""
        lbl_Address.Text = ""
        lst_Remark.Items.Clear()

    End Sub
    Sub Load_Board_Zone_Name()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim Index As Short = 0
        Dim i As Integer
        Try
            For i = 1 To 5
                sql = "SELECT * " & _
                      "FROM Floor_Zone_Name where F_Floor_Id =" & i & " order by F_Zone_Id"
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
                                Index = Val(Index) + 1
                                lbl(Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                                With Me.lbl(Index)
                                    .Size = New Size(CInt(rs.Fields("F_Zone_SizeX").Value), CInt(rs.Fields("F_Zone_SizeY").Value)) 'ขนาด button
                                    .Name = "lbl" & rs.Fields("F_Zone_Id").Value  'ชื่อ button
                                    .Text = rs.Fields("F_Zone_Name").Value
                                    .Font = New Font("Microsoft Sans Serif", CInt(rs.Fields("F_Font_Size").Value), FontStyle.Bold) '7 Segment, 8.25pt Font_Size
                                    .BorderStyle = BorderStyle.Fixed3D
                                    .TextAlign = ContentAlignment.MiddleCenter
                                    .BackColor = Color.FromArgb(rs.Fields("F_Zone_Back_ColorA").Value, rs.Fields("F_Zone_Back_ColorR").Value, rs.Fields("F_Zone_Back_ColorG").Value, rs.Fields("F_Zone_Back_ColorB").Value)
                                    .ForeColor = Color.FromArgb(rs.Fields("F_Zone_Font_ColorA").Value, rs.Fields("F_Zone_Font_ColorR").Value, rs.Fields("F_Zone_Font_ColorG").Value, rs.Fields("F_Zone_Font_ColorB").Value)
                                    .Location = New Point(rs.Fields("F_Zone_PositionX").Value, rs.Fields("F_Zone_PositionY").Value)
                                    .Parent = Me
                                    If i = "1" Then
                                        Me.Picture_Floor_1.Controls.Add(lbl(Index)) 'เพิ่ม Button
                                    ElseIf i = "2" Then
                                        Me.Picture_Floor_2.Controls.Add(lbl(Index)) 'เพิ่ม Button
                                    ElseIf i = "3" Then
                                        Me.Picture_Floor_3.Controls.Add(lbl(Index)) 'เพิ่ม Button
                                    ElseIf i = "4" Then
                                        Me.Picture_Floor_4.Controls.Add(lbl(Index)) 'เพิ่ม Button
                                    ElseIf i = "5" Then
                                        Me.Picture_Floor_5.Controls.Add(lbl(Index)) 'เพิ่ม Button
                                    ElseIf i = "6" Then
                                        Me.Picture_Floor_6.Controls.Add(lbl(Index)) 'เพิ่ม Button
                                    Else
                                        Exit Sub
                                    End If
                                End With
                                .MoveNext()
                            Loop
                        Else
                        End If
                    End With
                End If
            Next
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone_Name", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Load_Board_Zone()
        ' On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim Index As Short = 0
        Dim i As Integer
        Try
            For i = 1 To 5
                sql = "SELECT * FROM Floor_Zone where Floor_Id =" & i & " order by Zone_Id"
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
                                Index = Val(Index) + 1
                                lbl_Zone(Index) = New Label REM ถ้าต้องการให้ Create ตามจำนวนให้เอา มาไว้ใน Loop
                                With Me.lbl_Zone(Index)
                                    .Size = New Size(CInt(rs.Fields("Zone_SizeX").Value), CInt(rs.Fields("Zone_SizeY").Value)) 'ขนาด button
                                    .Name = "lbl" & rs.Fields("Zone_Id").Value  'ชื่อ button
                                    .Text = 0
                                    .Font = New Font("7 Segment", CInt(rs.Fields("Font_Size").Value), FontStyle.Regular) '7 Segment, 8.25pt Font_Size
                                    .BorderStyle = BorderStyle.Fixed3D
                                    .TextAlign = ContentAlignment.MiddleCenter
                                    .BackColor = Color.FromArgb(rs.Fields("Zone_Back_ColorA").Value, rs.Fields("Zone_Back_ColorR").Value, rs.Fields("Zone_Back_ColorG").Value, rs.Fields("Zone_Back_ColorB").Value)
                                    .ForeColor = Color.FromArgb(rs.Fields("Zone_Font_ColorA").Value, rs.Fields("Zone_Font_ColorR").Value, rs.Fields("Zone_Font_ColorG").Value, rs.Fields("Zone_Font_ColorB").Value)
                                    .Location = New Point(rs.Fields("Zone_PositionX").Value, rs.Fields("Zone_PositionY").Value)
                                    .Parent = Me
                                    If i = "1" Then
                                        Me.Picture_Floor_1.Controls.Add(lbl_Zone(Index)) 'เพิ่ม Button
                                    ElseIf i = "2" Then
                                        Me.Picture_Floor_2.Controls.Add(lbl_Zone(Index)) 'เพิ่ม Button
                                    ElseIf i = "3" Then
                                        Me.Picture_Floor_3.Controls.Add(lbl_Zone(Index)) 'เพิ่ม Button
                                    ElseIf i = "4" Then
                                        Me.Picture_Floor_4.Controls.Add(lbl_Zone(Index)) 'เพิ่ม Button
                                    ElseIf i = "5" Then
                                        Me.Picture_Floor_5.Controls.Add(lbl_Zone(Index)) 'เพิ่ม Button
                                    ElseIf i = "6" Then
                                        Me.Picture_Floor_6.Controls.Add(lbl_Zone(Index)) 'เพิ่ม Button
                                    End If
                                End With
                                .MoveNext()
                            Loop
                        End If
                    End With
                End If
            Next
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Board_Zone", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Tab_Floor_Name(Optional ByVal Building_ID As String = "") 'ชื่อของชั้นของแท็บ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "SELECT * FROM Mas_Floor where Building_ID = " & Building_ID & ""
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
                                    Tab_Floor.Controls.Item(0).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                Case "2"
                                    Tab_Floor.Controls.Item(1).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                Case "3"
                                    Tab_Floor.Controls.Item(2).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                Case "4"
                                    Tab_Floor.Controls.Item(3).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                Case "5"
                                    Tab_Floor.Controls.Item(4).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                Case "6"
                                    Tab_Floor.Controls.Item(5).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(5).Text = .Fields("Floor_Name").Value
                                Case "7"
                                    Tab_Floor.Controls.Item(0).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(0).Text = .Fields("Floor_Name").Value
                                Case "8"
                                    Tab_Floor.Controls.Item(1).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(1).Text = .Fields("Floor_Name").Value
                                Case "9"
                                    Tab_Floor.Controls.Item(2).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(2).Text = .Fields("Floor_Name").Value
                                Case "10"
                                    Tab_Floor.Controls.Item(3).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(3).Text = .Fields("Floor_Name").Value
                                Case "11"
                                    Tab_Floor.Controls.Item(4).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(4).Text = .Fields("Floor_Name").Value
                                Case "12"
                                    Tab_Floor.Controls.Item(5).Tag = .Fields("Floor_No").Value
                                    Tab_Floor.Controls.Item(5).Text = .Fields("Floor_Name").Value
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

    Private Sub cmb_Floor_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboTowerId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTowerId.SelectedIndexChanged
        If cboTowerId.SelectedIndex <= 0 Then Exit Sub
        Call Tab_Floor_Name(cboTowerId.SelectedValue)

        Dim Floor As String = Tab_Floor.SelectedTab.Tag
        If Floor = "" Then
            Floor = 1
        Else
            Me.Show_Picture(Floor, cboTowerId.SelectedValue)
        End If

        AddCombo(ConnStrMasTer, Me.cmb_Floorcontroller_Name, "Mas_Floor_Controller", "Floor_Controller_Name", "Floor_Controller_ID", "Building_ID = " & cboTowerId.SelectedValue & " and Floor_No =" & Tab_Floor.SelectedTab.Tag & " ", "Floor_Controller_ID", "---กรุณาเลือก รายการ---")

    End Sub

    Private Sub cmb_Floorcontroller_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Floorcontroller_Name.SelectedIndexChanged
        If cmb_Floorcontroller_Name.SelectedIndex <= 0 Then Exit Sub
        If cboTowerId.SelectedIndex <= 0 Then
            MessageBox.Show("กรุณาเลือกอาคารจอดรถ ให้ถูกต้อง  !!!!  ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboTowerId.Focus()
            Exit Sub
        End If

        Dim FloorID As String = Tab_Floor.SelectedTab.Tag
        If FloorID = "" Then
            FloorID = "1"
        Else
            Me.Load_Button(cmb_Floorcontroller_Name.SelectedValue, FloorID)
        End If
    End Sub

 
    Private Sub cmdLot_Click(sender As System.Object, e As System.EventArgs) Handles cmdLot.Click
        Save_Controller_Lot_Unlot("B") 'จอดขวาง
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Save_Controller_Lot_Unlot("L") 'จอดในช่อง
    End Sub
End Class

