Imports System.Drawing
Module Module_function_Callpoint
    Dim picture_car As PictureBox
    Dim picture_ As Image
    Public callpoint_pic As ArrayList
    Dim Callpoint_size_image_temp As Image
    Dim CDB2 As New CDatabase
    Dim A, R, G, B As Integer
    Dim st_ As Integer = 0
    Function Add_Control_CP(ByRef Picture_B As PictureBox, ByVal name_ As String, ByVal location_x As Integer, ByVal location_y As Integer, ByVal Tag As String, ByVal direction As String)
        picture_car = New PictureBox
        With Picture_B
            .Name = name_
            .Tag = Tag
            Callpoint_size_image_temp = Callpoint_size_image
            .Location = New System.Drawing.Point(location_x - 10, location_y - 30)

            Select Case direction
                Case "TOP"
                    .Size = New Size(Callpoint_size_x, Callpoint_size_y)
                    Callpoint_size_image_temp = Callpoint_size_image
                Case "BOTTOM"
                    .Size = New Size(Callpoint_size_x, Callpoint_size_y)
                    Callpoint_size_image_temp.RotateFlip(RotateFlipType.Rotate180FlipX)
                Case "LEFT"
                    .Size = New Size(Callpoint_size_y, Callpoint_size_x)
                    Callpoint_size_image_temp.RotateFlip(RotateFlipType.Rotate90FlipX)
                Case "RIGHT"
                    .Size = New Size(Callpoint_size_y, Callpoint_size_x)
                    Callpoint_size_image_temp.RotateFlip(RotateFlipType.Rotate90FlipY)
                Case Else
                    .Size = New Size(Callpoint_size_x, Callpoint_size_y)
                    Callpoint_size_image_temp = Callpoint_size_image
            End Select

            .BackColor = Color.Transparent
            .BackgroundImage = Callpoint_size_image_temp
            .BackgroundImageLayout = ImageLayout.Stretch

        End With

        Return Picture_B
    End Function


    Function Status_Alarm_Color_CP(ByVal id_ As String) As Color
        Try
            Dim color_ As Color
            Dim sql As String = ""
            sql = "SELECT * FROM  Mas_Status_Callpoint_Alarm WHERE [Status_Alarm_Id]='" & id_ & "'"
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
    Public Sub update_Button_New_load_CP(ByRef Picture_B As PictureBox)
        Try
            Dim sql As String = ""
            Dim dt As DataTable
            Dim visible_ As Boolean = True
            Dim play_sound As Integer = 0
            Dim ist As Integer = 0
            For Each dp As Control In Picture_B.Controls
                If TypeOf (dp) Is PictureBox Then
                    sql = "SELECT * FROM Q_Mas_Callpoint  WHERE HW_Call_Id = '" & dp.Name & "'"
                    dt = CDB2.readTableData(sql, ConStr_Guidance)
                    If dt.Rows.Count > 0 Then
                        'dp.BackgroundImage = Status_Alarm_Car_CP(dt.Rows(0).Item("HW_Status_Id").ToString, visible_, dt.Rows(0).Item("HW_Plan_Direction").ToString)
                        'dp.Visible = visible_ 'ของ Call point ต้องแสดงเท่านั้น
                        dp.BackgroundImage = convert_byte_to_Image(callpoint_pic(0))
                        If dt.Rows(0).Item("HW_Status_Id").ToString = "0" Then 'ไม่มีการกด
                            'dp.Visible = True
                            dp.BackgroundImage = convert_byte_to_Image(callpoint_pic(0))
                        End If

                        If dt.Rows(0).Item("HW_Status_Id").ToString = "1" Then 'ไม่มีการกด
                            dp.BackgroundImage = convert_byte_to_Image(callpoint_pic(1))
                            play_sound = 1
                        End If

                        dp.Text = "        " & _
                                      "Lot_Id: " & dt.Rows(0).Item("HW_Call_Id").ToString & " " & _
                                      "Lot_Name: " & dt.Rows(0).Item("HW_Lot_Name").ToString & " " & _
                                      "controller: " & dt.Rows(0).Item("Floor_Controller_Name").ToString & " " & _
                                      "Status: " & dt.Rows(0).Item("Status_Name").ToString

                    End If
                End If
            Next

            If play_sound = 1 Then
                PlaySoundFile()
            End If
        Catch ex As Exception
            MsgBox("update_Button_New : " & ex.Message)
        End Try
    End Sub
    Sub set_callpoint_picture()
        Dim sql As String = ""
        Try
            callpoint_pic = New ArrayList
            sql = "SELECT * FROM  Mas_Status_Callpoint_Alarm  order by [Status_Alarm_Id]"
            Dim dt As DataTable = CDB2.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    callpoint_pic.Add(dt.Rows(i).Item("Status_Alarm_Image"))
                Next
            End If
        Catch ex As Exception
            MsgBox("set_Alarm_picture : " & ex.Message)
        End Try
    End Sub

    Function Status_Alarm_Car_CP(ByVal id_ As String, ByRef show_pic As Boolean, ByVal direction As String) As Image
        Try
            picture_ = My.Resources.car_full
            Dim sql As String = ""
            sql = "SELECT * FROM  Mas_Status_Callpoint_Alarm WHERE [Status_Alarm_Id]='" & id_ & "'"
            Dim DT As DataTable = CDB2.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If IsDBNull(DT.Rows(0).Item("Status_Alarm_Image")) = False Then
                    'Tmp_Save_Pict = DT.Rows(0).Item("ID").ToString
                    Dim RetByte() As Byte = CType(DT.Rows(0).Item("Status_Alarm_Image"), Byte())
                    Dim PictureData() As Byte = RetByte
                    Dim Ms As New System.IO.MemoryStream(PictureData)
                    picture_ = Image.FromStream(Ms)
                    'PictureBox1.BackColor = Color.Transparent
                    'PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                    Select Case direction
                        Case "TOP" : picture_.RotateFlip(RotateFlipType.RotateNoneFlipNone)
                        Case "BOTTOM" : picture_.RotateFlip(RotateFlipType.Rotate180FlipX)
                        Case "LEFT" : picture_.RotateFlip(RotateFlipType.Rotate90FlipX)
                        Case "RIGHT" : picture_.RotateFlip(RotateFlipType.Rotate90FlipY)
                    End Select
                End If
                    If DT.Rows(0).Item("Status_visible").ToString = "1" Then
                        show_pic = False
                    Else
                        show_pic = True
                End If
            End If
            Return picture_
        Catch ex As Exception
            MsgBox("Status_Alarm_Car_CP: " & ex.Message)
            Return picture_
        End Try
    End Function


    'CALL POINT

End Module

