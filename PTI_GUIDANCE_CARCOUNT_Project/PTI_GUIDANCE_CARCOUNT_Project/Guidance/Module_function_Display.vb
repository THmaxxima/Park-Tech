Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Module Module_function_Display
    Dim picture_car As PictureBox
    Dim picture_ As Image
    Dim lot_size_image_temp As Image
    Dim CDB2 As New CDatabase
    Dim A, R, G, B As Integer
    Public ALARM_ID_0(10) As Integer
    Public Direction_Select As String
    Public alarm_pic As ArrayList
    Public alarm_pic_visible As ArrayList
    Public alarm_colorA As ArrayList
    Public alarm_colorR As ArrayList
    Public alarm_colorG As ArrayList
    Public alarm_colorB As ArrayList
    Dim label_ As Label
    Sub Clear_count_alarm_id()
        For i As Integer = 0 To ALARM_ID_0.Length - 1
            ALARM_ID_0(i) = 0
        Next
    End Sub
    Sub Set_count_alarm_id()
        For i As Integer = 0 To ALARM_ID_0.Length - 1
            ALARM_ID_0(i) = i
        Next
    End Sub
    Sub count_alarm_id(ByVal alarm_id As Integer)

        If alarm_id = 0 Then
            ALARM_ID_0(0) = ALARM_ID_0(0) + 1
        End If

        If alarm_id = 1 Then
            ALARM_ID_0(1) = ALARM_ID_0(1) + 1
        End If

        If alarm_id = 2 Then
            ALARM_ID_0(2) = ALARM_ID_0(2) + 1
        End If

        If alarm_id = 3 Then
            ALARM_ID_0(3) = ALARM_ID_0(3) + 1
        End If

        If alarm_id = 4 Then
            ALARM_ID_0(4) = ALARM_ID_0(4) + 1
        End If

        If alarm_id = 5 Then
            ALARM_ID_0(5) = ALARM_ID_0(5) + 1
        End If

        If alarm_id = 6 Then
            ALARM_ID_0(6) = ALARM_ID_0(6) + 1
        End If


        If alarm_id = 7 Then
            ALARM_ID_0(7) = ALARM_ID_0(7) + 1
        End If


        If alarm_id = 7 Then
            ALARM_ID_0(7) = ALARM_ID_0(7) + 1
        End If


        If alarm_id = 8 Then
            ALARM_ID_0(8) = ALARM_ID_0(8) + 1
        End If

        If alarm_id = 9 Then
            ALARM_ID_0(9) = ALARM_ID_0(9) + 1
        End If

        If alarm_id = 10 Then
            ALARM_ID_0(10) = ALARM_ID_0(10) + 1
        End If

    End Sub
    Sub set_Alarm_picture()
        Dim sql As String = ""
        Try
            alarm_pic = New ArrayList
            alarm_pic_visible = New ArrayList
            alarm_colorA = New ArrayList
            alarm_colorR = New ArrayList
            alarm_colorG = New ArrayList
            alarm_colorB = New ArrayList

            'If alarm_pic.Count > 0 Then
        '    alarm_pic.Clear()
        'End If
            sql = "SELECT Status_Alarm_Id,Status_Alarm_Image,isnull(Status_visible,'0') as Status_visible,Status_Alarm_Color_A,Status_Alarm_Color_R,Status_Alarm_Color_G,Status_Alarm_Color_B FROM [Mas_Status_Alarm] order by [Status_Alarm_Id]"
        Dim dt As DataTable = CDB2.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                    alarm_pic.Add(dt.Rows(i).Item("Status_Alarm_Image"))
                    alarm_pic_visible.Add(dt.Rows(i).Item("Status_visible"))
                    alarm_colorA.Add(dt.Rows(i).Item("Status_Alarm_Color_A"))
                    alarm_colorR.Add(dt.Rows(i).Item("Status_Alarm_Color_R"))
                    alarm_colorG.Add(dt.Rows(i).Item("Status_Alarm_Color_G"))
                    alarm_colorB.Add(dt.Rows(i).Item("Status_Alarm_Color_B"))
            Next
            End If
        Catch ex As Exception
            Dim frm As New Dg_msg_Error
            frm.message = "set_Alarm_picture : " & ex.Message
            frm.ShowDialog()
            frm.Dispose()
            'MsgBox("set_Alarm_picture : " & ex.Message)
        End Try
    End Sub
    Function Add_Control(ByRef Picture_B As PictureBox, ByVal name_ As String, ByVal location_x As Integer, ByVal location_y As Integer, ByVal Tag As String, pAlarm_id As String, ByVal direction As String)
        Try
        picture_car = New PictureBox
            Dim fix_Box_x As Integer = lot_size_y
            Dim fix_Box_y As Integer = lot_size_y

            Dim fix_Car_x As Integer = lot_size_x - 1
            Dim fix_Car_y As Integer = lot_size_y - 1

        Dim dbmp As System.Drawing.Bitmap
        Dim btn_label As PictureBox
        btn_label = New PictureBox
        'Dim img As Image
            If pAlarm_id <> "" Then
                Dim RetByte() As Byte = CType(alarm_pic(pAlarm_id), Byte())
                Dim PictureData() As Byte = RetByte
                Dim Ms As New System.IO.MemoryStream(PictureData)
                btn_label.BackgroundImage = Image.FromStream(MS)
            Else
                btn_label.BackgroundImage = lot_size_image
            End If

        btn_label.Size = New Size(fix_Box_x, fix_Box_y)
        'img = btn_label.BackgroundImage
            dbmp = New System.Drawing.Bitmap(btn_label.BackgroundImage, fix_Car_x, fix_Car_y)

        With Picture_B
            .Name = name_
            .Tag = Tag
            lot_size_image_temp = lot_size_image
            .Location = New System.Drawing.Point(location_x - 10, location_y - 30)

            Select Case direction
                Case "TOP"
                    .Size = New Size(lot_size_x, lot_size_y)
                    .BackgroundImage = RotateImg(dbmp, 0.0F, Color.Transparent)
                Case "TOPRIGHT"
                    .Size = New Size(fix_Box_x, fix_Box_y)
                    .BackgroundImage = RotateImg(dbmp, 45.0F, Color.Transparent)
                Case "TOPLEFT"
                    .Size = New Size(fix_Box_x, fix_Box_y)
                    .BackgroundImage = RotateImg(dbmp, 315.0F, Color.Transparent)
                Case "BOTTOM"
                    .Size = New Size(lot_size_x, lot_size_y)
                    .BackgroundImage = RotateImg(dbmp, 180.0F, Color.Transparent)
                Case "BOTTOMLEFT"
                    .Size = New Size(lot_size_y, lot_size_y)
                    .BackgroundImage = lot_size_image
                Case "BOTTOMRIGHT"
                    .Size = New Size(fix_Box_x, fix_Box_y)
                    dbmp = RotateImg(dbmp, 135.0F, Color.Transparent)
                    .BackgroundImage = dbmp
                Case "LEFT"
                    .Size = New Size(lot_size_y, lot_size_x)
                    .BackgroundImage = RotateImg(dbmp, 270.0F, Color.Transparent)
                Case "RIGHT"
                    .Size = New Size(lot_size_y, lot_size_x)
                    .BackgroundImage = RotateImg(dbmp, 90.0F, Color.Transparent)
                Case Else
                    .Size = New Size(lot_size_x, lot_size_y)
                        .BackgroundImage = btn_label.BackgroundImage
            End Select

            .BackColor = Color.Transparent
            '------------------------------------------------------------------
            '.BackgroundImage = Image.FromStream(Ms) ' lot_size_image_temp
            '------------------------------------------------------------------
            '.BackgroundImage = lot_size_image_temp
            '.BackgroundImage = Status_Alarm_Car(pAlarm_id, True, direction) ' lot_size_image_temp
            ' .BackgroundImage = lot_size_image_temp
            .BackgroundImageLayout = ImageLayout.Zoom

        End With
            Return Picture_B
        Catch ex As Exception
            Return lot_size_image
        End Try
    End Function
    Public Function RotateImg(ByRef bmp As System.Drawing.Bitmap, ByVal angle As Double, ByVal bkColor As Color) As System.Drawing.Bitmap
        Dim w As Integer = bmp.Width
        Dim h As Integer = bmp.Height
        Dim pf As New PixelFormat
        If bkColor = Color.Transparent Then
            pf = PixelFormat.Format32bppArgb
        Else
            pf = bmp.PixelFormat
        End If
        Dim tempImg As System.Drawing.Bitmap
        tempImg = New System.Drawing.Bitmap(w, h, pf)

        Dim g As System.Drawing.Graphics
        'work out the scale factor


        g = Graphics.FromImage(tempImg)

        g.Clear(bkColor)
        g.DrawImageUnscaled(bmp, 1, 1)
        g.Dispose()

        Dim path As New GraphicsPath
        path.AddRectangle(New RectangleF(0.0F, 0.0F, w, h))
        Dim mtrx As New Matrix
        'Using System.Drawing.Drawing2D.Matrix class 
        mtrx.Rotate(angle)
        Dim rct As RectangleF
        rct = path.GetBounds(mtrx)
        Dim newImg As System.Drawing.Bitmap
        newImg = New System.Drawing.Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf)

        g = Graphics.FromImage(newImg)
        g.Clear(bkColor)
        g.TranslateTransform(-rct.X, -rct.Y)
        g.RotateTransform(angle)
        g.InterpolationMode = InterpolationMode.HighQualityBilinear
        g.DrawImageUnscaled(tempImg, 0, 0)
        g.Dispose()
        tempImg.Dispose()
        Return newImg
    End Function
    Function Resize(ByVal source As String, ByVal Output As String, ByVal dWidth As Integer, ByVal dHeight As Integer) As String
        Dim sbmp As New System.Drawing.Bitmap(source), dbmp As System.Drawing.Bitmap, gr As Graphics
        Dim DoResize As Boolean
        If Not DoResize Then
            dbmp = New System.Drawing.Bitmap(sbmp.Width, sbmp.Height)  'create new using source's dimensions
            gr = Graphics.FromImage(dbmp)
            gr.DrawImage(sbmp, 0, 0, sbmp.Width, sbmp.Height)
        Else
            dbmp = New System.Drawing.Bitmap(dWidth, dHeight) 'My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            gr = Graphics.FromImage(dbmp)
            gr.DrawImage(sbmp, 0, 0, dWidth, dHeight) 'My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        End If
        dbmp.Save(Output, Imaging.ImageFormat.Bmp)
        sbmp.Dispose()
        dbmp.Dispose()
        Return Output
    End Function
    Function convert_byte_to_Image(ByVal value_() As Byte)
        Dim picture As Image = My.Resources.car_full
        Try
            Dim RetByte() As Byte = CType(value_, Byte())
            Dim PictureData() As Byte = RetByte
            Dim Ms As New System.IO.MemoryStream(PictureData)
            picture = Image.FromStream(Ms)

            Return picture
        Catch ex As Exception
            Return picture
        End Try
    End Function
    Function Add_Control_picture(ByRef Picture_B As PictureBox, ByVal name_ As String, ByVal location_x As Integer, ByVal location_y As Integer, ByVal Tag As String, pImage As Image, ByVal direction As String)
        picture_car = New PictureBox
        With Picture_B
            .Name = name_
            .Tag = Tag
            lot_size_image_temp = lot_size_image
            .Location = New System.Drawing.Point(location_x - 10, location_y - 30)

            Select Case direction
                Case "TOP"
                    .Size = New Size(lot_size_x, lot_size_y)
                    lot_size_image_temp = lot_size_image
                Case "BOTTOM"
                    .Size = New Size(lot_size_x, lot_size_y)
                    lot_size_image_temp.RotateFlip(RotateFlipType.Rotate180FlipX)
                Case "LEFT"
                    .Size = New Size(lot_size_y, lot_size_x)
                    lot_size_image_temp.RotateFlip(RotateFlipType.Rotate90FlipX)
                Case "RIGHT"
                    .Size = New Size(lot_size_y, lot_size_x)
                    lot_size_image_temp.RotateFlip(RotateFlipType.Rotate90FlipY)
                Case Else
                    .Size = New Size(lot_size_x, lot_size_y)
                    lot_size_image_temp = lot_size_image
            End Select

            .BackColor = Color.Transparent
            .BackgroundImage = pImage ' lot_size_image_temp
            ' .BackgroundImage = lot_size_image_temp
            .BackgroundImageLayout = ImageLayout.Stretch

        End With

        Return Picture_B
    End Function
    Function Add_Control_label(ByRef label_ As Label, ByVal name_ As String, ByVal location_x As Integer, ByVal location_y As Integer, ByVal Tag As String, pImage As Image, text_ As String, ByVal direction As String)
        With label_
            .Name = name_
            .Tag = Tag
            .Text = text_
            'lot_size_image_temp = lot_size_image
            .Location = New System.Drawing.Point(location_x - 10, location_y - 30)

            Select Case direction
                Case "TOP"
                    .Size = New Size(lot_size_x, lot_size_y)
                    'lot_size_image_temp = lot_size_image
                Case "BOTTOM"
                    .Size = New Size(lot_size_x, lot_size_y)
                    'lot_size_image_temp.RotateFlip(RotateFlipType.Rotate180FlipX)
                Case "LEFT"
                    .Size = New Size(lot_size_y, lot_size_x)
                    ' lot_size_image_temp.RotateFlip(RotateFlipType.Rotate90FlipX)
                Case "RIGHT"
                    .Size = New Size(lot_size_y, lot_size_x)
                    'lot_size_image_temp.RotateFlip(RotateFlipType.Rotate90FlipY)
                Case Else
                    .Size = New Size(lot_size_x, lot_size_y)
                    'lot_size_image_temp = lot_size_image
            End Select

            .BackColor = Color.Transparent
            .BackgroundImage = pImage ' lot_size_image_temp
            ' .BackgroundImage = lot_size_image_temp
            .BackgroundImageLayout = ImageLayout.Stretch

        End With

        Return label_
    End Function
    Function Status_Alarm_Color(ByVal id_ As String) As Color
        Try
            Dim color_ As Color
            Dim sql As String = ""
            sql = "SELECT * FROM  Mas_Status_Alarm WHERE [Status_Alarm_Id]='" & id_ & "'"
            Dim DT As DataTable = CDB2.readTableData(sql, ConStr_Master)
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
            Return Color.FromArgb(0, 0, 0, 255)
        End Try
    End Function
    Public Sub update_Button_New_defult(ByRef Picture_B As PictureBox)
        Try
            Dim sql As String = ""
            Dim dt As DataTable
            Dim visible_ As Boolean = True
            For Each dp As Control In Picture_B.Controls
                If TypeOf (dp) Is PictureBox Then
                    sql = "SELECT * FROM [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Q_Mas_Lot]  WHERE HW_Lot_Id = '" & dp.Name & "'"
                    dt = CDB2.readTableData(sql, ConStr_Guidance)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("HW_Plan_Direction").ToString <> "" Then
                            dp.BackgroundImage = lot_size_image
                        Else
                            dp.BackgroundImage = lot_size_image
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("update_Button_New : " & ex.Message)
        End Try
    End Sub

    Public Sub update_Button_New_load(ByRef Picture_B As PictureBox)
        Try
            Dim sql As String = ""
            Dim dt As DataTable
            Dim visible_ As Boolean = True
            'Clear_count_alarm_id()

            For Each dp As Control In Picture_B.Controls
                If TypeOf (dp) Is PictureBox Then
                    sql = "SELECT * FROM [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Q_Mas_Lot]  WHERE HW_Lot_Id = '" & dp.Name & "'"
                    dt = CDB2.readTableData(sql, ConStr_Guidance)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("HW_Plan_Direction").ToString <> "" Then
                            dp.BackgroundImage = Status_Alarm_Car(dt.Rows(0).Item("Alarm_Id").ToString, visible_, dt.Rows(0).Item("HW_Plan_Direction").ToString, dp.BackgroundImage)
                        Else
                            dp.BackgroundImage = Status_Alarm_Car(dt.Rows(0).Item("Alarm_Id").ToString, visible_, dt.Rows(0).Item("HW_Plan_Direction").ToString, dp.BackgroundImage)
                        End If

                        dp.Visible = visible_
                        dp.Text = "        " & _
                                      "Lot_Id: " & dt.Rows(0).Item("HW_Lot_Id").ToString & " " & _
                                      "Lot_Name: " & dt.Rows(0).Item("HW_Lot_Name").ToString & " " & _
                                      "controller: " & dt.Rows(0).Item("Floor_Controller_Name").ToString & " " & _
                                      "Status: " & dt.Rows(0).Item("Status_Name").ToString

                        'count_alarm_id(dt.Rows(0).Item("Alarm_Id").ToString)
                        Application.DoEvents()
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("update_Button_New : " & ex.Message)
        End Try
    End Sub


    Function Status_Alarm_Car(ByVal id_ As String, ByRef show_pic As Boolean, ByVal direction As String, ByRef img_defult As Image) As Image
        Try
            picture_ = img_defult

            Dim picture_2 As Image

            Dim fix_Box_x As Integer = lot_size_y
            Dim fix_Box_y As Integer = lot_size_y

            Dim fix_Car_x As Integer = lot_size_x - 1
            Dim fix_Car_y As Integer = lot_size_y - 1
            '----------------------------------------------------------------------------------
            Dim RetByte() As Byte = CType(alarm_pic(id_), Byte())
            Dim PictureData() As Byte = RetByte
            Dim Ms As New System.IO.MemoryStream(PictureData)
            picture_2 = Image.FromStream(Ms) ' lot_size_image_temp

            '----------------------------------------------------------------------------------

            Dim dbmp As System.Drawing.Bitmap

            'Dim img As Image

            'img = btn_label.BackgroundImage
            dbmp = New System.Drawing.Bitmap(picture_2, fix_Car_x, fix_Car_y)


            '------------------------------------------------------------------------------
            If alarm_pic_visible(id_) = "1" Then
                show_pic = False
            Else
                show_pic = True
            End If

            Select Case direction
                Case "TOP"
                    '.Size = New Size(lot_size_x, lot_size_y)
                    picture_ = RotateImg(dbmp, 0.0F, Color.Transparent)
                Case "TOPRIGHT"
                    '.Size = New Size(fix_Box_x, fix_Box_y)
                    picture_ = RotateImg(dbmp, 45.0F, Color.Transparent)
                Case "TOPLEFT"
                    '.Size = New Size(fix_Box_x, fix_Box_y)
                    picture_ = RotateImg(dbmp, 315.0F, Color.Transparent)
                Case "BOTTOM"
                    '.Size = New Size(lot_size_x, lot_size_y)
                    picture_ = RotateImg(dbmp, 180.0F, Color.Transparent)
                Case "BOTTOMLEFT"
                    '.Size = New Size(lot_size_y, lot_size_y)
                    picture_ = lot_size_image
                Case "BOTTOMRIGHT"
                    ' .Size = New Size(fix_Box_x, fix_Box_y)
                    dbmp = RotateImg(dbmp, 135.0F, Color.Transparent)
                    picture_ = dbmp
                Case "LEFT"
                    '.Size = New Size(lot_size_y, lot_size_x)
                    picture_ = RotateImg(dbmp, 270.0F, Color.Transparent)
                Case "RIGHT"
                    '.Size = New Size(lot_size_y, lot_size_x)
                    picture_ = RotateImg(dbmp, 90.0F, Color.Transparent)
                Case Else
                    '.Size = New Size(lot_size_x, lot_size_y)
                    picture_ = picture_2
            End Select

            Return picture_
        Catch ex As Exception
            MsgBox("Status_Alarm_Car: " & ex.Message)
            Return picture_
        End Try
    End Function
    Function Show_Alert(ByRef panel_ As Panel, ByRef timer_ As Timer)
        Try
            If panel_.Visible = False Then
                panel_.Visible = True
            End If
            If timer_.Enabled = False Then
                timer_.Enabled = True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function close_Alert(ByRef panel_ As Panel, ByRef timer_ As Timer)
        Try

            If panel_.Visible = True Then
                panel_.Visible = False
            End If
            If timer_.Enabled = True Then
                timer_.Enabled = False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub Load_Tower(ByRef cmb As ComboBox)
        Try
            Dim sql As String = ""
            sql = "SELECT Building_ID,Building_Name FROM Mas_Building_Parking "
            Dim dt As DataTable = CDB2.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                With cmb
                    .DataSource = dt
                    .DisplayMember = "Building_Name"
                    .ValueMember = "Building_ID"
                End With
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_Tower :" & ex.Message)
        End Try

    End Sub

    Sub Load_floor(ByRef cmb As ComboBox, ByVal buiding_id As String)
        Try
            Dim sql As String = ""
            If buiding_id <> "" Then
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] WHERE [Building_ID]='" & buiding_id & "' order by Floor_ID"
            Else
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] order by Floor_ID"
            End If

            Dim dt As DataTable = CDB2.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                cmb.DataSource = dt
                cmb.DisplayMember = "Floor_Name"
                cmb.ValueMember = "Floor_ID"
                'CB_Floor.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_floor :" & ex.Message)
        End Try

    End Sub
End Module
