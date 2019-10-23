Imports System.Threading
Imports System.Data.OleDb
Imports System.Data
Imports System.IO
Imports System.Globalization   'เนมสเปซด้านวันที่และเวลา
Imports System.Data.SqlClient  'เนมสเปชของกลุ่มออบเจ็กต์ ADO.NET
Imports VB = Microsoft.VisualBasic
Public Class frm_Lot_History
    Friend HW_Lot_Sensor_ID As String
    Dim ClsSqlCmd As ClassCommandSql
    Dim CDB As New CDatabase

    Private Sub frm_Lot_History_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Show_Status_Sensor_as_Select()
        lbl_Lot_Id.Text = HW_Lot_Sensor_ID

    End Sub
    Sub Show_Status_Sensor_as_Select()

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rs2 As New ADODB.Recordset
        Dim sql As String = ""
        Dim Re_Mark As String = ""
        Dim Total_HH = 0, Total_MM As Integer = 0
        Dim Lot_Status As String = ""
        Dim No As Integer
        Try
            sql = "SELECT top 10 * FROM Q_Tran_Lot where HW_Lot_Id ='" & HW_Lot_Sensor_ID & "' and Trn_Log_Datetime_Out > Trn_Log_Datetime_In order by Trn_Log_Datetime_In DESC "
            Dim DT As DataTable = CDB.readTableData(sql, ConStr_Guidance)

            If DT.Rows.Count > 0 Then
                Me.Visible = True
                lsv_Lot_History.Items.Clear()
                lsv_Lot_History.Items.Clear()

                lsv_Lot_History.HeaderStyle = ColumnHeaderStyle.Nonclickable
                lsv_Lot_History.Alignment = ListViewAlignment.SnapToGrid
                No = 1
                lbl_Lot_Name.Text = "" & DT.Rows(0).Item("HW_Lot_Name").ToString
                Lot_Status = "" & DT.Rows(0).Item("HW_Status_Id").ToString
                lbl_FloorController_Name.Text = "" & DT.Rows(0).Item("Floor_Controller_Name").ToString
                If DT.Rows(0).Item("HW_On_Line").ToString = 0 Then
                    lbl_Status.Text = "อุปกรณ์ขัดข้อง"
                Else
                    lbl_Status.Text = "อุปกรณ์ทำงานปกติ"
                End If

                For ii As Integer = 0 To DT.Rows.Count - 1
                    Dim AddList As ListViewItem = lsv_Lot_History.Items.Add(Val(No))
                    With AddList
                        .SubItems.Add("" & DT.Rows(ii).Item("Trn_Log_Datetime_In").ToString)
                        .SubItems.Add("" & DT.Rows(ii).Item("Trn_Log_Datetime_Out").ToString)
                        .SubItems.Add("" & DT.Rows(ii).Item("Trn_Park_HH").ToString & " ชม. " & DT.Rows(ii).Item("Trn_Park_MM").ToString & " นาที")
                        Total_HH = Val(Total_HH) + Val(DT.Rows(ii).Item("Trn_Park_HH").ToString)
                        Total_MM = Val(Total_MM) + Val(DT.Rows(ii).Item("Trn_Park_MM").ToString)
                    End With

                    No = Val(No) + 1
                Next

                No = Val(No) - 1
                Dim Convert_MM_to_HH As Integer = Val(Total_MM) \ 60
                Dim Convert_MM_is_MM As Integer = Val(Total_MM) Mod 60
                Dim Total_Min As Integer = ((Val(Total_HH) * 60)) + Val(Total_MM)
                Dim Average_HH As Integer = ((Val(Total_Min) / Val(No)) \ 60)
                Dim Average_MM As Integer = ((Val(Total_Min) / Val(No)) Mod 60)
                Total_HH = Val(Total_HH) + Val(Convert_MM_to_HH)

                If Total_HH = 0 Then
                    lbl_Total_Time.Text = " " & Convert_MM_is_MM & " นาที"
                ElseIf Convert_MM_is_MM = 0 Then
                    lbl_Total_Time.Text = " " & Total_HH & " ชม. "
                Else
                    lbl_Total_Time.Text = " " & Total_HH & " ชม. " & Convert_MM_is_MM & " นาที"
                End If

                If Average_HH = 0 Then
                    lbl_Average.Text = " " & Average_MM & " นาที"
                ElseIf Average_MM = 0 Then
                    lbl_Average.Text = " " & Average_HH & " ชม. "
                Else
                    lbl_Average.Text = " " & Average_HH & " ชม. " & Average_MM & " นาที"
                End If



                If Lot_Status = 1 Then
                    lbl_Real_Time.Text = CDate(Now)
                    sql = "SELECT top 1 (Trn_Log_Datetime_In) FROM Q_Tran_Lot where HW_Lot_Id ='" & HW_Lot_Sensor_ID & "' order by Trn_Log_Datetime_In DESC "
                    Dim DT2 As DataTable = CDB.readTableData(sql, ConStr_Guidance)
                    If DT.Rows.Count > 0 Then
                        Dim pMin As Short
                        For iii As Integer = 0 To DT.Rows.Count - 1
                            lbl_Date_Update.Text = DT2.Rows(iii).Item("Trn_Log_Datetime_In").ToString
                            pMin = DateDiff(DateInterval.Minute, CDate("" & DT2.Rows(iii).Item("Trn_Log_Datetime_In").ToString), CDate(Now))
                            'pMin = DateDiff(DateInterval.Minute, CDate(Now), CDate("" & rs.Fields("Trn_Log_Datetime_In").Value))
                            lbl_Car_In.Text = " " & pMin \ 60 & " ชม. " & pMin Mod 60 & " นาที"
                        Next
                    Else
                        lbl_Real_Time.Text = ""
                    End If
                    T_Status.Enabled = True

                Else
                    T_Status.Enabled = False
                End If
            Else
                Dim Address As String = ""
                Address = mCountCar.Select_Address(HW_Lot_Sensor_ID, "HW_Lot_Name")
                MsgBox("อุปกรณ์ตรวจสอบชื่อ : " & Address & vbNewLine & _
                vbCrLf & "ยังไม่มีประวัติการจอดรถ", MsgBoxStyle.Information, "ผลการตรวจสอบ")
                Me.Close()
                Exit Sub
            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงประวัติการจอดรถ ของอุปกรณ์ตรวจสอบที่เลือก", Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub btn_Detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Detail.Click

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rs2 As New ADODB.Recordset
        Dim sql As String = ""
        Dim Re_Mark As String = ""
        Dim dt As New DataTable
        Dim No As Integer

        Try
            sql = "SELECT * FROM Q_Tran_Lot where HW_Lot_Id ='" & lbl_Lot_Id.Text.Trim & _
                  "' and Trn_Log_Datetime_Out > Trn_Log_Datetime_In " & _
                  " and Trn_Log_Datetime_In  >='" & Format(dtp_Date_Start.Value, "yyyy-MM-dd ") & Format(dtp_Time_Start.Value, "HH:mm:ss") & _
                  "' and Trn_Log_Datetime_Out <='" & Format(dtp_Date_Stop.Value, "yyyy-MM-dd ") & Format(dtp_Time_Stop.Value, "HH:mm:ss") & "'"
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)

                    If Not (.BOF And .EOF) Then
                        lsv_Lot_History.Items.Clear()
                        lsv_Lot_History.Items.Clear()
                        lsv_Lot_History.HeaderStyle = ColumnHeaderStyle.Nonclickable
                        lsv_Lot_History.Alignment = ListViewAlignment.SnapToGrid
                        .MoveFirst()
                        No = 1
                        Do While Not .EOF
                            Dim AddList As ListViewItem = lsv_Lot_History.Items.Add(Val(No))
                            With AddList
                                .SubItems.Add("" & rs.Fields("Trn_Log_Datetime_In").Value)
                                .SubItems.Add("" & rs.Fields("Trn_Log_Datetime_Out").Value)
                                .SubItems.Add("" & rs.Fields("Trn_Time_HH").Value & " ชม. " & rs.Fields("Trn_Time_MM").Value & " นาที")
                            End With
                            .MoveNext()
                            No = Val(No) + 1
                        Loop
                    Else
                        lsv_Lot_History.Items.Clear()
                    End If
                End With
            End If
            rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "btn_Detail_Click", Err.Number, Err.Description)

        End Try
    End Sub
    Private Sub T_Status_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Status.Tick
        If lbl_Date_Update.Text.Trim <> "" Then
            lbl_Real_Time.Text = CDate(Now)
        End If

        Dim pMin As Short
        If lbl_Date_Update.Text = "" Then Exit Sub
        lbl_Date_Update.Text = CDate(lbl_Date_Update.Text)
        pMin = DateDiff(DateInterval.Minute, CDate(lbl_Date_Update.Text), CDate(Now))
        lbl_Car_In.Text = pMin \ 60 & " ชม. " & pMin Mod 60 & " นาที "
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles cmdReport.Click
        Dim frm As New frm_RPT_CAR_PARKING_DETAIL_BY_LOT
        With frm
            mForm.Set_Standard_Form(frm, True, "รายงานรายละเอียดการจอดรถ แต่ละช่องจอด")
            .pHeader_Detail = "รายงานรายละเอียดการจอดรถ แต่ละช่องจอด"
            .pHW_ID = lbl_Lot_Id.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class