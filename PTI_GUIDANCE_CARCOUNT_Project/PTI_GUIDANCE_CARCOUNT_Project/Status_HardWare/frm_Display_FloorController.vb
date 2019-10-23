Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_Display_FloorController

    Private Sub frm_Display_FloorController_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call mMain.Load_AppConfig()
        Call Show_Floor_Name() ' แสดงชื่อชั้นจอดรถ
        Call Show_Status_Floor_Controller() ' แสดงสถานะ อุปกรณ์ควบคุม
    End Sub
    Sub Show_Status_Floor_Controller()
        Dim Building_Id As String = ""
        Dim Floor_No As String = ""
        Dim Floor_Controller_ID As String = ""
        Dim Floor_Controller_Status As String = ""
        Dim Floor_Controller_No As String = ""
        Dim sql As String = ""
        Dim i As Integer
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
            sql &= " Select  [ID]" '0
            sql &= "  ,[Tower_ID]" '1
            sql &= "  ,[Building_Id]" '2
            sql &= "  ,[Floor_No]" '3
            sql &= "  ,[Floor_Controller_ID]" '4
            sql &= "  ,[Floor_Controller_Status]" '5
            sql &= "  , Floor_Controller_No " '6
            sql &= " FROM Mas_Floor_Controller"
            sql &= " order by "
            sql &= "   [ID]"
            sql &= "  ,[Tower_ID]"
            sql &= "  ,[Building_Id]"
            sql &= "  ,[Floor_No]"
            sql &= "  ,[Floor_Controller_ID]"
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            'sqlDs.Clear()
            sqlDa.Fill(sqlDs, "Mas_Floor_Controller")
            Con.Close()
            If sqlDs.Tables("Mas_Floor_Controller").Rows.Count <> 0 Then
                For i = 0 To sqlDs.Tables("Mas_Floor_Controller").Rows.Count - 1
                    Try
                        Floor_Controller_ID = "" & sqlDs.Tables("Mas_Floor_Controller").Rows(i)(4).ToString() ' case Floor_Controller_ID
                        Building_Id = "" & sqlDs.Tables("Mas_Floor_Controller").Rows(i)(2).ToString() ' case Building_ID
                        Floor_No = "" & sqlDs.Tables("Mas_Floor_Controller").Rows(i)(3).ToString() ' case Floor_No
                        Floor_Controller_Status = "" & sqlDs.Tables("Mas_Floor_Controller").Rows(i)(5).ToString() 'Floor_Controller_Status
                        Floor_Controller_No = "" & sqlDs.Tables("Mas_Floor_Controller").Rows(i)(6).ToString()
                    Catch ex As Exception
                        Floor_Controller_Status = "0"
                    End Try
                    Select Case Building_ID
                        Case "1"
                            Select Case Floor_No
                                Case "1"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_B_SL07, Floor_Controller_Status)
                                    End Select

                                Case "2"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_1_SL07, Floor_Controller_Status)
                                    End Select
                                Case "3"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_3_SL07, Floor_Controller_Status)
                                    End Select
                                Case "4"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_4_SL07, Floor_Controller_Status)
                                    End Select
                                Case "5"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_5_SL07, Floor_Controller_Status)
                                    End Select
                                Case "6"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_6_SL07, Floor_Controller_Status)
                                    End Select
                                Case "7"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_7_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_7_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_A_Floor_7_SL03, Floor_Controller_Status)
                                    End Select
                            End Select
                        Case "2"  ' case Building_ID
                            Select Case Floor_No
                                Case "1"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_1_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_1_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_1_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_FB_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_B_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_1_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_1_SL07, Floor_Controller_Status)
                                    End Select
                                Case "2"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_2_SL07, Floor_Controller_Status)
                                    End Select
                                Case "3"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_3_SL07, Floor_Controller_Status)
                                    End Select
                                Case "4"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_4_SL07, Floor_Controller_Status)
                                    End Select
                                Case "5"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_5_SL07, Floor_Controller_Status)
                                    End Select
                                Case "6"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL03, Floor_Controller_Status)
                                        Case "4" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL04, Floor_Controller_Status)
                                        Case "5" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL05, Floor_Controller_Status)
                                        Case "6" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL06, Floor_Controller_Status)
                                        Case "7" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_6_SL07, Floor_Controller_Status)
                                    End Select
                                Case "7"
                                    Select Case Floor_Controller_No
                                        Case "1" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_7_SL01, Floor_Controller_Status)
                                        Case "2" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_7_SL02, Floor_Controller_Status)
                                        Case "3" : Call mObject.Set_Status_Off_Line_On_Line(Me.Pic_D_Floor_7_SL03, Floor_Controller_Status)
                                    End Select
                            End Select
                    End Select
                Next
            End If
        Catch ex As Exception
            Con.Close()
        End Try

    End Sub
    Sub Show_Floor_Name()
        Dim sql As String = ""
        Dim Floor_ID As String = ""
        Dim Building_ID As String = ""
        Dim Floor_No As String = ""
        Dim i As Integer
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
            sql &= "  Select [Floor_ID]" '0
            sql &= "   ,[Tower_Id]" '1
            sql &= "  ,[Building_ID]" '2
            sql &= "  ,[Floor_No]" '3
            sql &= "  ,[Floor_Name]  " '4
            sql &= "  FROM [Mas_Floor]"
            sql &= "  order by  [Floor_ID]"
            sql &= "   ,[Tower_Id]"
            sql &= "  ,[Building_ID]"
            sql &= "  ,[Floor_No]"

            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            ' sqlDs.Clear()
            sqlDa.Fill(sqlDs, "Mas_Floor")
            Con.Close()
            If sqlDs.Tables("Mas_Floor").Rows.Count <> 0 Then
                For i = 0 To sqlDs.Tables("Mas_Floor").Rows.Count - 1
                    Try
                        Floor_ID = "" & sqlDs.Tables("Mas_Floor").Rows(i)(1).ToString() ' case Floor_ID
                        Building_ID = "" & sqlDs.Tables("Mas_Floor").Rows(i)(2).ToString()
                        Floor_No = "" & sqlDs.Tables("Mas_Floor").Rows(i)(3).ToString()
                    Catch ex As Exception
                    End Try
                    Select Case Building_ID
                        Case "1"
                            Select Case Floor_No
                                Case "1" : lbl_A_Floor_1.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "2" : lbl_A_Floor_2.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "3" : lbl_A_Floor_3.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "4" : lbl_A_Floor_4.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "5" : lbl_A_Floor_5.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "6" : lbl_A_Floor_6.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "7" : lbl_A_Floor_7.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                            End Select
                        Case "2"
                            Select Case Floor_No
                                Case "1" : lbl_D_Floor_1.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "2" : lbl_D_Floor_2.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "3" : lbl_D_Floor_3.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "4" : lbl_D_Floor_4.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "5" : lbl_D_Floor_5.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "6" : lbl_D_Floor_6.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                                Case "7" : lbl_D_Floor_7.Text = "" & sqlDs.Tables("Mas_Floor").Rows(i)(4).ToString()
                            End Select
                    End Select
                Next
            End If
        Catch ex As Exception
            Con.Close()
        End Try

    End Sub
End Class