Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports VB = Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Net
Imports System.Net.IPAddress
Imports System.Net.Sockets
Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class frmMain_Menu_NEW
    Dim CDB As New CDatabase
    Dim Date_Alam_Normal As DateTime = Now
    Dim Tmp_Save_Pic1 As String
    Dim Tmp_Save_Pic2 As String
    Public MaxWith_BAR As Integer = 152
    Private Property resultDat
    Dim a As Object

    Dim pg As New ProgressBar
    Dim ip_backboffice As String = ""
    Dim ip_SERVER As String = ""
    Dim select_dgv_floor As Integer = 0
    Dim ad As New Microsoft.VisualBasic.Devices.Audio
    Dim af() As Byte = IO.File.ReadAllBytes("alarm.wav")
    Dim sound_alert As String = ""
    Dim alert_i As Integer = 0
    Dim alert_count As Integer = 0
    Dim alert_c As New ArrayList
    Dim arr_table_alert As New ArrayList
    Dim session_chk_corpoint As Integer = 0

    Private Sub frmMain_Menu_NEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Visible = False

        Try
            Call mMain.Load_AppConfig()
        Catch ex As Exception
            MsgBox("การตั้งค่า Config File ไม่ถูกต้อง")
        End Try


        'เช็คภาษา
        Change_language()

        'Debug_Mode = False

        If Debug_Mode = True Then
            Dim frm As New frmLogin
            With frm
                mForm.Set_Standard_Form(frm)
                .ShowDialog()
                .Dispose()

            End With

            If CurUser_ID = "" Then
                ' MsgBox("CurUser_ID=''")
                Application.Exit()
            End If

            Call Load_Menu_Permit()
        Else


        End If

        If Me.Width > 1200 Then
            Dim x_new As Integer = (Me.Width - PanelEx5.Width) / 2
            Dim y_new As Integer = 4
            If Me.Height > 600 Then
                y_new = (PanelEx4.Height - PanelEx5.Height) / 2 + 50
            End If
            PanelEx5.Location = New Point(x_new, y_new)
        End If

        Me.Visible = True
       
        TableLayoutPanel2.Location = New Point(Me.Width - TableLayoutPanel2.Width, TableLayoutPanel2.Location.Y)
        TableLayoutPanel1.Location = New Point(Me.Width - TableLayoutPanel1.Width, TableLayoutPanel1.Location.Y)
        TableLayoutPanel3.Location = New Point(Me.Width - TableLayoutPanel3.Width, TableLayoutPanel3.Location.Y)
        TableLayoutPanel4.Location = New Point(Me.Width - TableLayoutPanel4.Width, TableLayoutPanel4.Location.Y)

        Call Timer_False()

        Load_IP()
        load_text(lang_)
        set_lot_size()
        set_Callpoint_size()
        'set_Alarm_picture()
        'set_callpoint_picture()



        P_ALERT.Visible = False
        P_ALERT.Location = New Point(Label5.Location.X, Label5.Location.Y)
        P_ALERT.Width = PanelEx4.Width - 10

        ''ตาราง V_Mas_Floor
        Load_Mas_floor()

        Timer_3.Enabled = True
        ''ตาราง Mas_Hour_Parking
        'Load_HH()
        Timer_2.Enabled = True
        ''แจ้งเตือนของระบบ
        'Load_Alert_MSG()
        Timer_1.Enabled = True

        Call Load_Tower_Detail()

    End Sub
    Sub Load_Tower_Detail()
      
        Try
            Dim sql As String = ""
            sql = "SELECT Top 1 * FROM [Mas_Tower] where Tower_Active=1"
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                Cur_Tower_Name = dt.Rows(0).Item("Tower_Name").ToString
                Cur_Tower_Location = dt.Rows(0).Item("Tower_Location").ToString
                Cur_Tower_Tax = dt.Rows(0).Item("Tower_Tax").ToString
                Cur_Tower_Tel = dt.Rows(0).Item("Tower_Tel").ToString
                Cur_Tower_Fax = dt.Rows(0).Item("Tower_Fax").ToString
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub show_frm(ByRef frm_new As Form, ByVal text_ As String, Optional ByRef maximize_ As Boolean = True)
        Call Timer_False()
        With frm_new
            mForm.Set_Standard_Form(frm_new, maximize_, text_)
            .ShowDialog()
            .Dispose()
        End With
        Call Timer_True()
    End Sub
    Sub set_lot_size()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM Mas_Size_Lot"
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                lot_size_x = dt.Rows(0).Item("Size_X").ToString
                lot_size_y = dt.Rows(0).Item("Size_Y").ToString
                Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                Dim PictureData() As Byte = RetByte
                Dim Ms As New System.IO.MemoryStream(PictureData)
                lot_size_image = Image.FromStream(Ms)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub set_Callpoint_size()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM Mas_Size_Callpoint"
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                Callpoint_size_x = dt.Rows(0).Item("Size_X").ToString
                Callpoint_size_y = dt.Rows(0).Item("Size_Y").ToString
                Dim RetByte() As Byte = CType(dt.Rows(0).Item("Size_Image"), Byte())
                Dim PictureData() As Byte = RetByte
                Dim Ms As New System.IO.MemoryStream(PictureData)
                Callpoint_size_image = Image.FromStream(Ms)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub load_text(ByVal lang_ As String)
        GroupPanel1.Text = main_Text(0)

        'GroupPanel2.Text = "2. Status of system"
        GroupPanel2.Text = main_Text(1)

        'Label79.Text = "Warning of system"
        Label79.Text = main_Text(2)

        'lbl_Alam_Status_Sensor.Text = "Status of devices failure"
        lbl_Alam_Status_Sensor.Text = main_Text(3)

        'lbl_HH_Alert.Text = "Alert of hour parking"
        lbl_HH_Alert.Text = main_Text(4)

        'Label3.Text = "Total"
        Label3.Text = main_Text(5)

        lbl_HH.Text = main_Text(6)
        lbl_Value.Text = main_Text(7)

        Label1.Text = main_Text(6)
        Label2.Text = main_Text(7)


        'If lang_ = "TH" Then
        '    'GroupPanel1.Text = "1. Summary number of parking in each hour"
        '    GroupPanel1.Text = "1. สรุปจำนวนรถที่จอดอยู่ในอาคารตามจำนวนชั่วโมงที่จอด"

        '    'GroupPanel2.Text = "2. Status of system"
        '    GroupPanel2.Text = "2. สถานะการทำงานของระบบ"

        '    'Label79.Text = "Warning of system"
        '    Label79.Text = "ข้อความเตือนของระบบ"

        '    'lbl_Alam_Status_Sensor.Text = "Status of devices failure"
        '    lbl_Alam_Status_Sensor.Text = "สถานะอุปกรณ์ขัดข้อง"

        '    'lbl_HH_Alert.Text = "Alert of hour parking"
        '    lbl_HH_Alert.Text = "แจ้งเตือนชั่วโมงที่จอด"

        '    'Label3.Text = "Total"
        '    Label3.Text = "รวม"

        '    lbl_HH.Text = "ชั่วโมง"
        '    lbl_Value.Text = "จำนวน"

        '    Label1.Text = "ชั่วโมง"
        '    Label2.Text = "จำนวน"
        'End If

        'If lang_ = "EN" Then
        '    GroupPanel1.Text = "1. Count of parking in tower by hour parking"
        '    'GroupPanel1.Text = "1. สรุปจำนวนรถที่จอดอยู่ในอาคารตามจำนวนชั่วโมงที่จอด"


        '    GroupPanel2.Text = "2. Status of system"
        '    ' GroupPanel2.Text = "2. สถานะการทำงานของระบบ"

        '    Label79.Text = "Warning of system"
        '    ' Label79.Text = "ข้อความเตือนของระบบ"

        '    lbl_Alam_Status_Sensor.Text = "Devices failure"
        '    'lbl_Alam_Status_Sensor.Text = "สถานะอุปกรณ์ขัดข้อง"

        '    lbl_HH_Alert.Text = "Alert of hour parking"
        '    'lbl_HH_Alert.Text = "แจ้งเตือนชั่วโมงที่จอด"

        '    Label3.Text = "Total"
        '    'Label3.Text = "รวม"

        '    lbl_HH.Text = "Hour"
        '    lbl_Value.Text = "Count"

        '    Label1.Text = "Hour"
        '    Label2.Text = "Count"
        'End If
    End Sub

    Sub Time_Disable()
        'Load_Mas_floor()
        Timer_3.Enabled = False
        ''ตาราง Mas_Hour_Parking
        'Load_HH()
        Timer_2.Enabled = False
        ''แจ้งเตือนของระบบ
        'Load_Alert_MSG()
        Timer_1.Enabled = False
    End Sub

    Sub Time_Enabled()
        'Load_Mas_floor()
        Timer_3.Enabled = True
        ''ตาราง Mas_Hour_Parking
        'Load_HH()
        Timer_2.Enabled = True
        ''แจ้งเตือนของระบบ
        'Load_Alert_MSG()
        Timer_1.Enabled = True
    End Sub

    Function Load_Alert_MSG()

        Dim sql As String = ""
        'ข้อความเตือนของระบบ
        sql = "SELECT TOP 1 * FROM Lbl_Alert_A "
        Dim DT As DataTable = CDB.readTableData(sql, ConStr_Guidance)
        If DT.Rows.Count > 0 Then
            Lbl_Alert_A.Text = DT.Rows(0).Item(0).ToString
        Else
            Lbl_Alert_A.Text = "-"
        End If

        'สถานะอุปกรณ์ขัดข้อง
        sql = "SELECT TOP 1 * FROM Lbl_Alert_B "
        Dim DT_B As DataTable = CDB.readTableData(sql, ConStr_Guidance)
        If DT_B.Rows.Count > 0 Then
            Lbl_Alert_B.Text = DT_B.Rows(0).Item(0).ToString
        Else
            Lbl_Alert_B.Text = "-"
        End If


        'แจ้งเตือนจำนวนชั่วโมงที่จอด
        'Dim HH_over As String = "2"
        sql = "SELECT TOP 1 *  FROM Lbl_Alert_C "
        Dim DT_C As DataTable = CDB.readTableData(sql, ConStr_Guidance)
        If DT_C.Rows.Count > 0 Then
            Lbl_Alert_C.Text = DT_C.Rows(0).Item(0).ToString
        Else
            Lbl_Alert_C.Text = "-"
        End If

    End Function
    Function Load_HH()
        Load_HH = True

        If DGV_HH_A.Rows.Count <= 0 Then
            DGV_HH_A.Rows.Add( _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0 _
                    )
        End If
        If DGV_HH_B.Rows.Count <= 0 Then
            DGV_HH_B.Rows.Add( _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0, _
                    0 _
                    )
        End If

        Dim sql As String = ""
        sql = "SELECT  [Hour_ID],[Hour_Value] FROM [dbo].[Mas_Hour_Parking] order by [Hour_ID]"
        Try
            Dim DT As DataTable = CDB.readTableData(sql, ConStr_Guidance)
           
            'Dim dr As System.Data.DataRow
            Dim dr_A() As System.Data.DataRow
            'dr_A = DT.Select("Hour_ID='0'")

            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To 25
                    dr_A = DT.Select("Hour_ID='" & i & "'")
                    If i >= 0 And i <= 12 Then
                        If dr_A.Length > 0 Then DGV_HH_A.Rows(0).Cells(i).Value = dr_A(0)("Hour_Value").ToString
                    End If

                    If i >= 13 And i <= 25 Then
                        If dr_A.Length > 0 Then DGV_HH_B.Rows(0).Cells(i - 13).Value = dr_A(0)("Hour_Value").ToString
                    End If
                Next
            End If
        Catch ex As Exception
            Load_HH = False
            MsgBox("Load_HH:" & ex.Message)
        End Try
    End Function
    Function Load_Mas_floor()
        Load_Mas_floor = True
        Dim sql As String = ""
        'sql = "SELECT * FROM [V_Main_Floor_Display] order by [Building_ID],[Floor_ID]"
        sql = "SELECT * FROM Mas_Terminal order by Tower_ID,ID"
        Dim turn_car As Integer = 0
        Dim count_car As Integer = 0

        Dim val_Empty As Integer = 0
        Dim val_Lot_All As Integer = 0
        Dim val_Lot_Inuse As Integer = 0
        Dim val_count_car As Integer = 0
        Dim val_Percent_Value As Integer = 0
        pg.Maximum = 100
        pg.Value = 0

        Lbl_Sum_A.Text = "0"
        Lbl_Sum_B.Text = "0"
        Lbl_Sum_C.Text = "0"
        Lbl_Sum_D.Text = "0"
        Lbl_Sum_E.Text = "0"

        Try
            Dim DT As DataTable = CDB.readTableData(sql, ConStr_Master)
            If DGV_Mas_floor.Rows.Count < 1 Then

                'Dim FName As String = .Fields("Name1").Value
                'Parking_ALL = .Fields("Max_Parking").Value
                ''Parking_In = .Fields("Parking_In").Value
                ''Parking_Out = .Fields("Parking_Out").Value
                'Car_Parking = .Fields("Car_Parking").Value

                For i As Integer = 0 To DT.Rows.Count - 1
                    'val_Empty = Isnull(DT.Rows(i).Item("Floor_Lot_Empty").ToString, "0")
                    val_Lot_All = Isnull(DT.Rows(i).Item("Max_Parking").ToString, "0")
                    'val_count_car = Isnull(DT.Rows(i).Item("Count_CAR").ToString, "0")
                    val_Lot_Inuse = Isnull(DT.Rows(i).Item("Car_Parking").ToString, "0")
                    val_Empty = CInt(val_Lot_All) - CInt(val_Lot_Inuse)

                    If val_Lot_All > 0 Then count_car = val_count_car
                    If val_Empty = 0 Then
                        val_Percent_Value = 0
                    Else
                        val_Percent_Value = CInt((val_Empty * 100) / val_Lot_All)
                    End If

                    If val_count_car > 0 Then turn_car = CInt(val_count_car / val_Lot_All)

                    pg.Maximum = 100
                    pg.Value = 0

                    If val_Percent_Value > pg.Maximum Then pg.Maximum = val_Percent_Value

                    pg.Value = val_Percent_Value

                    With DGV_Mas_floor
                        .Rows.Add(DT.Rows(i).Item("Name1").ToString, _
                                  DT.Rows(i).Item("Max_Parking").ToString, _
                                  DT.Rows(i).Item("Parking_Out").ToString, _
                                  DT.Rows(i).Item("Parking_In").ToString, _
                                  DT.Rows(i).Item("Floor").ToString, _
                                  DT.Rows(i).Item("ID").ToString, _
                                DT.Rows(i).Item("Tower_ID").ToString, _
                                pg.Value, _
                                pg.Value & " %", _
                                turn_car, _
                                count_car)
                        .Rows(i).Height = 35
                    End With
                    '--------- ยอดรวม -------------------------------------------------------------------------------
                    Lbl_Sum_A.Text = CInt(Lbl_Sum_A.Text) + val_Lot_All
                    Lbl_Sum_B.Text = CInt(Lbl_Sum_B.Text) + val_Empty
                    Lbl_Sum_C.Text = CInt(Lbl_Sum_C.Text) + CInt(val_Lot_Inuse)
                    Lbl_Sum_D.Text = CInt(Lbl_Sum_D.Text) + CInt(turn_car)
                    Lbl_Sum_E.Text = CInt(Lbl_Sum_E.Text) + CInt(count_car)
                Next
            Else
                'Dim dr() As System.Data.DataRow
                Dim DT_ As DataTable = CDB.readTableData(sql, ConStr_Master)
                Dim dr_A() As System.Data.DataRow
                Dim buiding_id As String = ""
                Dim floor_id As String = ""

                For i As Integer = 0 To DGV_Mas_floor.Rows.Count - 1
                    'buiding_id = DGV_Mas_floor.Rows(i).Cells(8).Value
                    'floor_id = DGV_Mas_floor.Rows(i).Cells(6).Value

                    'dr_A = DT_.Select("ID='" & floor_id & "' and Building_ID='" & buiding_id & "'")
                    'dr_A = DT_.Select("Floor='" & floor_id)
                    'val_Empty = dr_A(0)("Floor_Lot_Empty").ToString
                    'val_Lot_All = dr_A(0)("Floor_Lot_All").ToString
                    'val_count_car = dr_A(0)("Count_CAR").ToString
                    'val_Lot_Inuse = dr_A(0)("Floor_Lot_Parking").ToString

                    val_Lot_All = Isnull(DT.Rows(i).Item("Max_Parking").ToString, "0")
                    val_Lot_Inuse = Isnull(DT.Rows(i).Item("Car_Parking").ToString, "0")
                    val_Empty = CInt(val_Lot_All) - CInt(val_Lot_Inuse)
                    val_Percent_Value = 0
                    pg.Value = 0

                    If val_Lot_All > 0 Then count_car = val_count_car

                    If val_Empty = 0 Then
                        val_Percent_Value = 0
                    Else
                        val_Percent_Value = CInt((val_Empty * 100) / val_Lot_All)
                    End If

                    If val_count_car > 0 Then turn_car = CInt(val_count_car / val_Lot_All)

                    If val_Percent_Value > pg.Maximum Then pg.Maximum = val_Percent_Value
                    pg.Value = val_Percent_Value

                    DGV_Mas_floor.Rows(i).Cells(1).Value = val_Lot_All
                    DGV_Mas_floor.Rows(i).Cells(2).Value = val_Empty
                    DGV_Mas_floor.Rows(i).Cells(3).Value = val_Lot_Inuse



                    DGV_Mas_floor.Rows(i).Cells(7).Value = pg.Value
                    DGV_Mas_floor.Rows(i).Cells(8).Value = pg.Value & " %"
                    DGV_Mas_floor.Rows(i).Cells(9).Value = turn_car
                    DGV_Mas_floor.Rows(i).Cells(10).Value = val_count_car

                  
                    '--------- ยอดรวม -------------------------------------------------------------------------------
                    Lbl_Sum_A.Text = CInt(Lbl_Sum_A.Text) + val_Lot_All
                    Lbl_Sum_B.Text = CInt(Lbl_Sum_B.Text) + val_Empty
                    Lbl_Sum_C.Text = CInt(Lbl_Sum_C.Text) + CInt(val_Lot_Inuse)
                    Lbl_Sum_D.Text = CInt(Lbl_Sum_D.Text) + CInt(turn_car)
                    Lbl_Sum_E.Text = CInt(Lbl_Sum_E.Text) + CInt(count_car)
                Next
            End If


                Dim a_val As Integer = 0
                Dim b_val As Integer = 0
                If (Lbl_Sum_B.Text * 100) / (Lbl_Sum_A.Text) > 0 Then
                    a_val = (Lbl_Sum_B.Text * 100) / Lbl_Sum_A.Text

                Else
                    a_val = 0
                End If

                b_val = 100 - a_val

                With ProgressBarX1
                    .Maximum = 100
                '.Value = 0
                    .Maximum = Lbl_Sum_A.Text
                    .Value = Lbl_Sum_B.Text
                    .Text = "" & a_val & "%                          " & b_val & "%"
                End With
                ' DGV_Mas_floor.Rows(DT.Rows.Count).Height = 1


            With DGV_Mas_floor
                .Columns(0).HeaderText = main_Text(9)
                .Columns(1).HeaderText = main_Text(10)
                .Columns(2).HeaderText = main_Text(11)
                .Columns(3).HeaderText = main_Text(12)
                .Columns(7).HeaderText = main_Text(13)
                '.Columns(8).HeaderText = main_Text(14)
                .Columns(9).HeaderText = main_Text(14)
                .Columns(10).HeaderText = main_Text(15)
            End With

        Catch ex As Exception
            Load_Mas_floor = False
            Dim frm As New Dg_msg_Error
            frm.message = "Load_Mas_floor:" & ex.Message
            frm.ShowDialog()
            frm.Dispose()
            ' MsgBox("Load_Mas_floor:" & ex.Message)
        End Try
    End Function

   
    Function Change_language()
        Change_language = True
        Try
            Dim sql As String = ""
            sql = "SELECT [Lang_Select] FROM [LANG_Select] WHERE [Id_]='1'"
            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                lang_ = dt.Rows(0).Item(0).ToString.Trim
            End If

            Menu_Manin.SelectedRibbonTabItem = rib_Main
            For Each r As Object In Menu_Manin.Items
                If TypeOf (r) Is RibbonTabItem Then
                    read_LANG_obj(lang_, Me, r)
                    'i = i + 1
                End If
            Next

            ' i = 0
            For Each r As Object In Menu_Manin.Items
                If TypeOf (r) Is ButtonItem Then
                    read_LANG_obj(lang_, Me, r)
                    'i = i + 1
                End If

            Next

            'i = 0
            For Each r As Object In Rib_MainMenu.Items
                If TypeOf (r) Is ButtonItem Then
                    read_LANG_obj(lang_, Me, r)
                End If

            Next

            For Each r As Object In RibbonBar4.Items
                If TypeOf (r) Is ButtonItem Then
                    read_LANG_obj(lang_, Me, r)
                End If

            Next

            For Each r As Object In RibbonBar10.Items
                If TypeOf (r) Is ButtonItem Then
                    read_LANG_obj(lang_, Me, r)
                End If

            Next

            For Each r As Object In RibbonBar1.Items
                If TypeOf (r) Is ButtonItem Then
                    read_LANG_obj(lang_, Me, r)
                End If
            Next

            Load_msg(lang_)

        Catch ex As Exception
            Change_language = False
            MsgBox("Change_language:" & ex.Message)
        End Try
    End Function

    Private Sub frmMain_Menu_NEW_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call Log_Out()
    End Sub

    Private Sub Log_Out()
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Try
            sql = " INSERT INTO Transac_Log_System_LogIN("
            sql &= " Log_ID" '1
            sql &= " ,Log_Date " '2
            sql &= " ,Log_Datetime" '2
            sql &= " ,Log_Station_Name" '3
            sql &= " ,Log_Process_ID" '4
            sql &= " ,Log_Process_Name" '5
            sql &= " ,Log_User_ID" '6
            sql &= " ,Log_Detail )" '7
            sql = sql & "VALUES('" & Format(Now, "yyMMddHHmmss") & CurUser_ID & "'," 'Log_ID
            sql = sql & "" & DBFormatDate(CDate(Now).ToShortDateString) & "," 'Log_Date
            sql = sql & "" & DBFormatDate(Now) & "," 'Log_Datetime
            sql = sql & "'" & GetComName() & "'," 'Log_Station_Name
            sql = sql & "'CLOSE'," 'Log_Process_ID
            sql = sql & "'CLOSE System'," 'Log_Process_Name
            sql = sql & "'" & CurUser_ID & "'," 'Log_User_ID
            sql = sql & " ' CLOSE System   " & My.Application.Info.AssemblyName & " ' )" ' Log_Detail
            If OpenCnn(ConnStrMasTer, Conn) Then
                With Conn
                    .BeginTrans()
                    TrnFlg = True
                    .Execute(sql)
                    .CommitTrans()
                    TrnFlg = False
                End With
            Else
                If TrnFlg = True Then Conn.RollbackTrans()

            End If
            If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Catch ex As Exception
            If TrnFlg = True Then Conn.RollbackTrans()
            If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        End Try
    End Sub

    Sub Timer_False()
        Time_Disable()
        T_Realtime.Enabled = False
        T_Alert.Enabled = False
        T_Show_Alert.Enabled = False
        Timer_1.Enabled = False
        Timer_2.Enabled = False
        Timer_3.Enabled = False
        Time_Reflesh_StatusBar.Enabled = False
        Timer_Chk_MasAlert.Enabled = True
    End Sub
    Sub Timer_True()
        Timer_3.Enabled = True
        ''ตาราง Mas_Hour_Parking
        Timer_2.Enabled = True
        ''แจ้งเตือนของระบบ
        Timer_1.Enabled = True

        'Time_Enabled()
        'T_Realtime.Enabled = True

        'T_Alert.Enabled = True
        'T_Show_Alert.Enabled = True
        'Timer_1.Enabled = True
        'Timer_2.Enabled = True
        'Timer_3.Enabled = True
        'Time_Reflesh_StatusBar.Enabled = True
        'Timer_Chk_MasAlert.Enabled = False
    End Sub
    Sub Show_Status_Alam_Normal()

        Dim sql As String = ""
        Try
            Con = New SqlConnection(ConStr_Guidance)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Guidance
                .Open()
            End With
            sql = "SELECT Mas_Alam_Date,Alam_Remark"
            sql &= " FROM Mas_Alam_Normal where Mas_Alam_Date > " & mDB.DBFormatDate(CDate(Date_Alam_Normal)) & ""
            ' sql &= "  order by Mas_Alam_Date DESC "

            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Mas_Alam_Normal")
            'mDgv_Status_System_Alert.DataSource = sqlDs.Tables("Mas_Alam_Normal")

            Con.Close()
            'Call FormatDgv_Status_System_Alert()

        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Sub Show_Status_Alam_Lot()
        Dim sql As String = ""
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
            'maxx modify 20150629 เลือกแสดงข้อมูล เฉพาะ Lot Type = L โดยเพิ่มเติมเงื่อนไข and (ML.[HW_Lot_Type]='L') ใน View Q_Alert_Mas_Lot
            sql = " SELECT [HW_Floor_No],HW_Building_ID,[Floor_Name],[HW_Lot_Name]"
            sql &= " FROM [Q_Alert_Mas_Lot] "
            sql &= " order by HW_Building_ID,HW_Floor_No "
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Q_Alert_Mas_Lot")
            'Mdgv_Alert_Sensor.DataSource = sqlDs.Tables("Q_Alert_Mas_Lot")

            Con.Close()
            ' Call FormatDgvdgv_Alert()

        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

#Region "Register Menu"
    Sub register_Group(ByRef ribbon_menu As DevComponents.DotNetBar.RibbonTabItem, ByVal group_id As String)
        Dim sql As String = ""
        sql = "SELECT * FROM [Mas_Menu_Group] WHERE [Group_Name]='" & ribbon_menu.Name & "'"
        Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Group_Caption").ToString <> ribbon_menu.Text Then
                Update_menu_group(ribbon_menu.Name, ribbon_menu.Text, group_id)
            End If
            ribbon_menu.Visible = check_permission_Group(group_id, CurPosition)
        Else
            Insert_menu_group(ribbon_menu.Name, ribbon_menu.Text, group_id)
        End If
    End Sub
    Function check_permission_Group(ByVal group_id As String, ByVal level_ As String)
        check_permission_Group = False
        Dim sql As String = ""
        Try
        sql = "select * from INFORMATION_SCHEMA.TABLES "
        sql &= " where TABLE_NAME = 'V_Menu_Permission' AND TABLE_SCHEMA = 'dbo'"
        Dim dtt As DataTable = CDB.readTableData(sql, ConStr_Master)
        If dtt.Rows.Count < 1 Then
            Dim sql_create As String = ""
            sql_create = " CREATE VIEW [dbo].[V_Menu_Permission]"
            sql_create &= "  AS"
            sql_create &= "  SELECT        ID, MenuName, Control_Name, User_Level, User_Id, IsCommit,"
            sql_create &= "                               (SELECT        TOP (1) Menu_Group_ID"
            sql_create &= "                                 FROM            dbo.Mas_Menu"
            sql_create &= "                                 WHERE        (Menu_Name = dbo.Menu_Permit.MenuName)) AS Group_id"
            sql_create &= "  FROM            dbo.Menu_Permit"
            If CDB.ExcuteNoneQury(sql_create, ConStr_Master) = False Then
                CDB.writeError("" & sql_create)
            End If
        End If
        sql = ""
        sql = "SELECT distinct [User_Level],[Group_id] FROM [V_Menu_Permission] WHERE isnull([Group_id],'')<>'' and isnull([Group_id],'')='" & group_id & "' and isnull([User_Level],'')='" & level_ & "'"
        Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            Return True
        Else

            If group_id = 7 Or group_id = 1 Then
                Return True
            Else
                Return False
            End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Sub register_Group_button(ByRef btn_menu As DevComponents.DotNetBar.ButtonItem, ByVal group_id As String)
        Dim sql As String = ""
        sql = "SELECT * FROM [Mas_Menu_Group] WHERE isnull([Group_Name],'')='" & btn_menu.Name & "'"
        Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> btn_menu.Text Then
                Update_menu_group(btn_menu.Name, btn_menu.Text, group_id)
            End If
            btn_menu.Visible = check_permission_Group(group_id, CurPosition)
        Else
            Insert_menu_group(btn_menu.Name, btn_menu.Text, group_id)
        End If
    End Sub
    Sub Update_menu_group(ByVal rname As String, ByVal rtext As String, ByVal group_id As String)
        Dim sql As String = ""
        sql = "UPDATE [Mas_Menu_Group] SET [Group_Caption] ='" & rtext & "',[Group_Name]='" & rname & "' WHERE [Group_ID]='" & group_id & "'"
        If CDB.ExcuteNoneQury(sql, ConStr_Master) = False Then
            CDB.writeError("Update_menu_group :" & sql)
        End If
    End Sub
    Sub Insert_menu_group(ByVal rname As String, ByVal rtext As String, ByVal group_id As String)
        Dim sql As String = ""
        sql = " INSERT INTO [dbo].[Mas_Menu_Group]"
        sql &= "           ([Applicate_Name]"
        sql &= "            ,[Group_ID]"
        sql &= "            ,[Group_Name]"
        sql &= "            ,[Group_Caption]"
        sql &= "            ,[IsCancel]"
        sql &= "            ,[IsCommit])"
        sql &= "      VALUES"
        sql &= "            ('MTL_BACK_OFFICE'"
        sql &= "            ,'" & group_id & "'"
        sql &= "            ,'" & rname & "'"
        sql &= "            ,'" & rtext & "'"
        sql &= "            ,0"
        sql &= "            ,1)"
        If CDB.ExcuteNoneQury(sql, ConStr_Master) = False Then
            CDB.writeError("Insert_menu_group :" & sql)
        End If
    End Sub
    Sub register_menu(ByRef btn As DevComponents.DotNetBar.ButtonItem, ByVal group_menu As String)
        Dim sql As String = ""
        Dim menu_name As String = btn.Name
        Dim menu_text As String = btn.Text
        Try
            sql = "SELECT * FROM [Mas_Menu] WHERE [Menu_Name]='" & menu_name & "'"
            Dim DT As DataTable = CDB.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("Menu_Caption").ToString <> menu_text Then
                    update_menu(menu_name, menu_text, group_menu)
                End If
                btn.Visible = Get_Menu_permiss(btn.Name)
            Else
                Insert_menu(menu_name, menu_text, group_menu)
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function Get_Menu_permiss(ByVal btn_name As String) As Boolean
        Get_Menu_permiss = False
        sql = "SELECT * FROM [Menu_Permit] WHERE isnull([MenuName],'')='" & btn_name & "' and isnull([User_Level],'')='" & CurPosition & "'"
        Dim DT As DataTable = CDB.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub Insert_menu(ByVal menu_name As String, ByVal menu_text As String, ByVal group_id As String)
        Dim sql As String = ""
        Try
            sql = " INSERT INTO [dbo].[Mas_Menu]"
            sql &= "            ([Applicate_Name]"
            sql &= "            ,[Menu_ID]"
            sql &= "            ,[Menu_Group_ID]"
            sql &= "            ,[Menu_Name]"
            sql &= "            ,[Menu_Caption]"
            sql &= "            ,[Menu_Desc]"
            sql &= "            ,[IsCancel]"
            sql &= "            ,[IsCommit])"
            sql &= "      VALUES"
            sql &= "            ('MTL_BACK_OFFICE'"
            sql &= "            ,(SELECT ISnull(MAX(convert(int,isnull(Menu_ID,0))),0)+1 FROM [Mas_Menu])"
            sql &= "            ,'" & group_id & "'"
            sql &= "            ,'" & menu_name & "'"
            sql &= "            ,'" & menu_text & "'"
            sql &= "            ,0"
            sql &= "            ,0"
            sql &= "      ,1)"
            If CDB.ExcuteNoneQury(sql, ConStr_Master) = False Then
                CDB.writeError(sql)
            End If
        Catch ex As Exception
            CDB.writeError("Insert_menu :" & ex.Message)
        End Try
    End Sub
    Sub update_menu(ByVal menu_name As String, ByVal menu_text As String, ByVal group_id As String)
        Dim sql As String = ""
        Try
            sql = "UPDATE [Mas_Menu] SET [Menu_Caption]='" & menu_text & "',[Menu_Group_ID]='" & group_id & "'"
            sql &= " WHERE [Menu_Name]='" & menu_name & "'"
            If CDB.ExcuteNoneQury(sql, ConStr_Master) = False Then
                CDB.writeError(sql)
            End If
        Catch ex As Exception
            CDB.writeError("update_menu :" & ex.Message)
        End Try
    End Sub
#End Region
    Sub Get_Menu_Accept()
        '**** #### Main Menu System ####****
        REM :  1 เมนูหลัก  #########################
        rib_Main.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "rib_Main", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  2 ตั้งค่า  #########################
        M_Setting.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "M_Setting", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  3 ตั้งค่าพิเศษ  #########################
        'mSpecial_Setting.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "mSpecial_Setting", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  4 การเชื่อมต่อ  #########################
        'rib_Status_Connect.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "rib_Status_Connect", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  5 รายงานระบบ  #########################
        rib_Report.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "rib_Report", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  6 ผู้ใช้งานระบบ  #########################
        rib_User.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "rib_User", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  7 เครื่องมือผู้ดูแลระบบ  #########################
        'rib_Mange.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "rib_Mange", "PTI_GUIDANCE_CARCOUNT_Project")
        REM :  8 เกี่ยวกับ  #########################
        'rib_About.Visible = mMain.IsMenu_Permit_Screen_New(CurUser_ID, "", "rib_About", "PTI_GUIDANCE_CARCOUNT_Project")


    End Sub
    Sub Load_Menu_Permit()
        Try
            Dim Group_manage As String = 0
            Dim Group_sub_manage As String = 0
            '--------- GRUOP____
            Dim iii As Integer = 0
            Group_manage = 1
            register_Group(rib_Main, Group_manage)
            For Each r As Object In Rib_MainMenu.Items
                If TypeOf (r) Is ButtonItem Then
                    register_menu(r, Group_manage)
                End If
            Next


            'M_Setting
            Group_manage = 2
            register_Group(M_Setting, Group_manage)
            For Each r As Object In RibbonBar4.Items
                If TypeOf (r) Is ButtonItem Then
                    register_menu(r, Group_manage)
                End If
            Next

            'rib_User
            Group_manage = 3
            register_Group(rib_User, Group_manage)
            For Each r As Object In RibbonBar1.Items
                If TypeOf (r) Is ButtonItem Then
                    register_menu(r, Group_manage)
                End If
            Next

            Group_manage = 4
            register_Group(rib_Report, Group_manage)
            For Each r As Object In RibbonBar10.Items
                If TypeOf (r) Is ButtonItem Then
                    Group_sub_manage = Group_manage & (iii + 1)
                    register_Group_button(r, Group_sub_manage)
                    For i As Integer = 0 To r.subItems.count - 1

                        If TypeOf (r.subItems(i)) Is ButtonItem Then
                            register_menu(r.subItems(i), Group_sub_manage)
                        End If
                    Next
                End If
                iii = iii + 1
            Next


            

            'For Each r As ButtonItem In Menu_Manin.Items

            'Next
            'REM :  1 เมนูหลัก  #########################
            'Group_manage = 1
            'register_Group(rib_Main, Group_manage)
            'REM : menu-----------------------------------------
            'register_menu(nfrmNew_Display, Group_manage)


            'REM :  2 ตั้งค่า  #########################
            'Group_manage = 2
            'register_Group(M_Setting, Group_manage)
            'REM : menu-----------------------------------------
            'register_menu(nMas_Floor, Group_manage)


            'REM :  5 รายงานระบบ  #########################

            'Group_manage = 5
            'register_Group(rib_Report, Group_manage)
            'REM :##############  5.1  รายงานตรวจสอบ  ###########



            'Group_manage = 56
            'register_Group_button(rib_User, Group_manage)
            'REM :  6 ผู้ใช้งานระบบ  #########################
            'register_menu(btnUserManager, Group_manage)
            'register_menu(btnUserProfile, Group_manage)
            'register_menu(Rib_User_Level, Group_manage)


            'Group_manage = 57
            'register_Group_button(rb_Report_ADD1, Group_manage)
            'register_menu(mfrm_RPT_CAR_PARKING_BY_DAY_ADD1_frm, Group_manage)
            'register_menu(RPT_GD_V_Turn_By_Floor_frm, Group_manage)
            'register_menu(RPT_GD_V_Lotinpark_HH_By_Floor, Group_manage)
            'register_menu(RPT_GD_V_Lotvaliable_HH_By_Floor_frm, Group_manage)
            'register_menu(RPT_GD_V_Parking_HH_By_Floor_frm, Group_manage)
            'register_menu(RPT_Carcount_By_Week, Group_manage)
            'register_menu(RPT_Turn_By_Week, Group_manage)
            'register_menu(RPT_Lotinpark_By_Week, Group_manage)
            'register_menu(RPT_GD_V_Lotvaliable_By_Floor_By_Week, Group_manage)
            'register_menu(RPT_GD_V_Parking_HH_By_Floor_By_Week, Group_manage)
            'register_menu(RPT_GD_Present_Carcount_By_Floor_All_Day_frm, Group_manage)
            'register_menu(RPT_GD_Present_Turn_By_Floor_All_Day_H_N_Distinct_frm, Group_manage)
            'register_menu(RPT_GD_Present_Lotinpark_HH_By_Floor_All_Day_Distinct_frm, Group_manage)
            'register_menu(RPT_GD_Present_Lotvaliable_HH_By_Floor_All_Day_Distinct_frm, Group_manage)
            'register_menu(RPT_GD_Present_Parking_HH_By_Floor_All_Day_N_H_Distinct_frm, Group_manage)
            'register_menu(RPT_GD_Present_Parking_IN_HH_By_Floor_All_Day_N_H_Distinct_frm, Group_manage)
            'register_menu(RPT_GD_Present_Parking_OUT_HH_By_Floor_All_day_Distinct_frm, Group_manage)

            'Group_manage = 58
            'register_Group_button(ButtonItem74, Group_manage)
            'register_menu(ButtonItem77, Group_manage)
            'register_menu(ButtonItem75, Group_manage)
            'register_menu(ButtonItem76, Group_manage)
            'register_menu(ButtonItem78, Group_manage)


            If CurPosition = 5 Then
                rib_Main.Visible = True
                rib_User.Visible = True
                Rib_User_Level.Visible = True
                btnUserManager.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Show_Alert_Parking_Time(ByVal Hour_Alert As String)

        Dim sql As String = ""
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
            sql = " SELECT HW_Lot_Id"
            sql &= " ,HW_Lot_Name"
            sql &= " ,HW_Time_HH"
            sql &= " ,HW_Time_MM"
            sql &= " ,HW_Remark"
            sql &= " ,[HW_Building_ID]"
            sql &= " ,[HW_Floor_No]  "
            sql &= "  FROM Mas_Lot where HW_Time_HH >= " & Hour_Alert & " "
            sql &= " and [HW_Lot_Type]='L' "
            sql &= " order by HW_Datetime_Update desc "
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Q_Alert_Mas_Lot")
            'Mdgv_Hour_Alert.DataSource = sqlDs.Tables("Q_Alert_Mas_Lot")

            Con.Close()
            'If Mdgv_Hour_Alert.RowCount - 1 > 0 Then
            '    lbl_HH_Alert.Text = " แจ้งเตือนจำนวนชั่วโมงที่จอด เกิน " & Hour_Alert & " ชั่วโมง จำนวน " & Mdgv_Hour_Alert.RowCount - 1 & " คัน"
            'End If

            'Call FormatDgv_Time_Alert()
            '    Con.Close()
        Catch ex As Exception
            Con.Close()
            Call mError.ShowError(Me.Name, "แจ้งเตือนรถจอดเกินเวลาที่กำหนด ผิดพลาด", Err.Number, Err.Description)
        End Try

    End Sub

    Sub load_Version()
        mSt_Version.Text = "Version : " & My.Application.Info.Version.Major & "." & _
      My.Application.Info.Version.MajorRevision & "." & _
      My.Application.Info.Version.Minor & "." & _
      My.Application.Info.Version.MinorRevision
    End Sub

    Private Sub T_Realtime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Realtime.Tick
        T_Realtime.Enabled = False

        T_Realtime.Enabled = True
        ' lbl_Bar_Empty_A_Floor_1.Width = MaxWith_BAR
    End Sub

    Private Sub T_Alert_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Alert.Tick
        T_Alert.Enabled = False
        'Call Show_Alert_Parking_Time(Time_Parking_Alert) 'แจ้งเตือนรถจอด เกินจำนวนชั่วโมงที่กำหนด
        'Call Show_Status_Alam_Normal() ' แสดงสถานะ ของระบบบ
        'Call Show_Status_Alam_Lot() ' แสดงสถานะ Ultrasonic
        T_Alert.Enabled = True
    End Sub

    Private Sub Time_Clock_Tick(sender As System.Object, e As System.EventArgs) Handles Time_Clock.Tick
        mSt_Datetime.Text = Now

    End Sub

    Sub Load_IP()
        Try
            Dim sql As String = ""
           
            sql = "SELECT DISTINCT * FROM MAS_IP WHERE Type in('0','1')"
            Dim dt As DataTable
            dt = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("Type").ToString = "1" Then

                        ip_backboffice = dt.Rows(i).Item("IP").ToString
                    End If
                    If dt.Rows(i).Item("Type").ToString = "0" Then

                        ip_SERVER = dt.Rows(i).Item("IP").ToString
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub ping_ip()

        If ip_backboffice <> "" Then
            Try
                If My.Computer.Network.Ping(ip_backboffice) Then
                    mSt_Master.Text = "WORKSTATION : ONLINE"
                Else
                    mSt_Master.Text = "WORKSTATION : OFFLINE"
                End If
            Catch ex As Exception
                mSt_Master.Text = "WORKSTATION : OFFLINE"
            End Try
        End If

        If ip_SERVER <> "" Then
            Try
                If My.Computer.Network.Ping(ip_SERVER) Then
                    mSt_Polling.Text = "SERVER : ONLINE"
                Else
                    mSt_Polling.Text = "SERVER : OFFLINE"
                End If
            Catch ex As Exception
                mSt_Polling.Text = "SERVER : OFFLINE"
            End Try
        End If

    End Sub

    Private Sub Time_Reflesh_StatusBar_Tick(sender As System.Object, e As System.EventArgs) Handles Time_Reflesh_StatusBar.Tick
        load_Version()
        ping_ip()
        mSt_User.Text = "USER : " & CurUser_FirstName

        Application.DoEvents()
    End Sub

    Private Sub Timer_1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_1.Tick
        Load_HH()

        'Check_CallPoint()
    End Sub

    Private Sub Timer_2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_2.Tick
        Load_Alert_MSG()
    End Sub

    Private Sub Timer_3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_3.Tick
        Load_Mas_floor()
        'If DGV_Mas_floor.RowCount > 0 Then
        '    If DGV_Mas_floor.SelectedRows.Count > 0 Then
        '        DGV_Mas_floor.SelectedRows(select_dgv_floor).Cells(0).Selected = True
        '    End If
        'End If
        'Timer_Chk_MasAlert.Enabled = True
    End Sub

    Private Sub Timer_Chk_MasAlert_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Chk_MasAlert.Tick
        Timer_Chk_MasAlert.Enabled = False
        'blackgound_play_sound()
        Timer_Chk_MasAlert.Enabled = True
    End Sub
    Sub blackgound_play_sound()
        sql = " SELECT count(*) FROM V_Mas_CallPoint_Alert WHERE Count_Status_id > 0 "
        Dim dt As DataTable = CDB.readTableData(sql, ConStr_Guidance)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString > 0 Then
                PlaySoundFile()
            End If
        End If
    End Sub  

    Private Sub T_Show_Alert_Tick(sender As System.Object, e As System.EventArgs) Handles T_Show_Alert.Tick
        T_Show_Alert.Enabled = False
        
        For Each btn As Button In P_ALERT.Controls
     
            For i As Integer = 0 To alert_c.Count - 1
                If btn.Name = alert_c(i) Then
                    btn.BackColor = Color.Orange
                    Exit For
                End If
            Next

            If btn.BackColor = Color.Maroon Then
                btn.BackColor = Color.Red
            Else
                If btn.BackColor = Color.Orange Then

                Else
                    btn.BackColor = Color.Maroon
                End If
            End If

            'Application.DoEvents()

        Next
        If sound_alert <> "" Then
            PlaySoundFile()
        End If
        T_Show_Alert.Enabled = True
    End Sub
    
    Private Sub mBtn_Exit_Click_1(sender As System.Object, e As System.EventArgs) Handles mBtn_Exit.Click
        If MessageBox.Show("คุณต้องการออกจากโปรแกรมนี้ ใช่หรือไม่ ???? ", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnUserManager_Click_1(sender As System.Object, e As System.EventArgs) Handles btnUserManager.Click
        Dim frm As New frmUser
        show_frm(frm, sender.text, False)
    End Sub

    Private Sub btnUserProfile_Click(sender As System.Object, e As System.EventArgs) Handles btnUserProfile.Click
        Dim frm As New frmProfile_User
        show_frm(frm, sender.text, False)
    End Sub

    Private Sub Rib_User_Level_Click(sender As System.Object, e As System.EventArgs) Handles Rib_User_Level.Click
        Dim frm As New frmUser_Permission_By_Level
        show_frm(frm, sender.text, False)
    End Sub

    Private Sub nfrmNew_Display_Click(sender As System.Object, e As System.EventArgs) Handles nfrmNew_Display.Click
        Dim frm As New frm_Parking_Quitity
        With frm
            mForm.Set_Standard_Form_Guidance(frm)
            '.Text = stCar_Parking.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ButtonItem112_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem112.Click
        Dim frm As New frm_Setting_Parking
        With frm
            mForm.Set_Standard_Form_Guidance(frm)
            '.Text = stReset.Text
            .ShowDialog()
            '.Dispose()
        End With
    End Sub

    Private Sub ButtonItem113_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem113.Click
        Dim frm As New frm_Setting_Car_Controller
        With frm
            mForm.Set_Standard_Form_Guidance(frm)
            .Text = ButtonItem113.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ButtonItem103_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem103.Click
        Dim frm As New Mas_Station_Company
        With frm
            mForm.Set_Standard_Form_Guidance(frm)
            .Text = ButtonItem103.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class


