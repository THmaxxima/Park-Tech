Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frmZCU_Config_Zend_All
    Dim cdb As New CDatabase
    Friend pbf_Tower_ID As String
    Friend pbf_pBuiding_ID As String
    Friend pbf_Floor_Controller_ID As String
    Private Sub frmZCU_Config_Zend_All_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dtpDate_Time.Value = Now
        'Call Load_Mas_Tower()
        'Call Load_Mas_Building_Parking(pbf_Tower_ID, pbf_pBuiding_ID)
        load_combo_ZCUA()
        load_combo_ZCUB()

        'Call Load_ZCU_Combo(pbf_Tower_ID, pbf_pBuiding_ID, pbf_Floor_Controller_ID)
        'Call Load_ZCU_Config(pbf_Tower_ID, pbf_pBuiding_ID, pbf_Floor_Controller_ID)
    End Sub
    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        'Save_ZCU_Config(cboMas_Tower.SelectedValue, cboMas_Building_Parking.SelectedValue, Cmb_ZCU.SelectedValue)

        Dim sql As String = ""
        Dim zcu_st As Integer = 0
        Dim zcu_End As Integer = 0
        zcu_st = Zcu_A0.SelectedValue
        zcu_End = Zcu_B0.SelectedValue
        For i As Integer = zcu_st To zcu_End
            sql = "UPDATE Mas_Floor_Controller SET Floor_Controller_Date_Time = '" & cdb.GetDateToDB(dtpDate_Time.Value) & "' WHERE ID='" & i & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                cdb.writeError("cmdSave_Click : " & sql)
            End If
        Next
        MsgBox("SUCCESS")
    End Sub
    Sub Load_ZCU_Config(ByVal pTower_ID As String, ByVal pBuiding_ID As String, ByVal pFloor_Controller_ID As String)
        Dim sql As String = ""
        Try
            sql = "SELECT *"
            sql &= " FROM [V_Mas_Floor_Controller] "
            sql &= " WHERE [Tower_ID]='" & pTower_ID & "' and [Building_ID]='" & pBuiding_ID & "' and Floor_Controller_ID='" & pFloor_Controller_ID & "'"
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                txt_Max_UD.Text = DT.Rows(0).Item("Count_UD").ToString
                txt_Max_DP.Text = DT.Rows(0).Item("Count_Display").ToString
                txt_Max_CP.Text = DT.Rows(0).Item("Count_Callpoint").ToString

                dtpDate_Time.Value = Now

                'If IsDBNull(DT.Rows(0).Item("Floor_Controller_Date_Time")) = True Then 'ถ้าเป็น Null
                '    dtpDate_Time.Value = Now
                'Else
                '    dtpDate_Time.Value = DT.Rows(0).Item("Floor_Controller_Date_Time").ToString
                'End If
                txtClose_DP_From.Text = DT.Rows(0).Item("Floor_Controller_Close_DP_From").ToString
                txtClose_DP_To.Text = DT.Rows(0).Item("Floor_Controller_Close_DP_To").ToString
                txtClose_UD_From.Text = DT.Rows(0).Item("Floor_Controller_Close_UD_From").ToString
                txtClose_UD_To.Text = DT.Rows(0).Item("Floor_Controller_Close_UD_To").ToString
                txtZcu_Timeout_Request.Text = DT.Rows(0).Item("Floor_Controller_Zcu_Timeout_Request").ToString
                txtZcu_Time_Sleep_Mode.Text = DT.Rows(0).Item("Floor_Controller_Zcu_Time_Sleep_Mode").ToString

                If txtClose_DP_From.Text = "" Then txtClose_DP_From.Text = "00:00"
                If txtClose_DP_To.Text = "" Then txtClose_DP_To.Text = "00:00"
                If txtClose_UD_From.Text = "" Then txtClose_UD_From.Text = "00:00"
                If txtClose_UD_To.Text = "" Then txtClose_UD_To.Text = "00:00"
                If txtZcu_Timeout_Request.Text = "" Then txtZcu_Timeout_Request.Text = "0"
                If txtZcu_Time_Sleep_Mode.Text = "" Then txtZcu_Time_Sleep_Mode.Text = "0"
            Else
                MessageBox.Show("    ไม่พบข้อมูล ZCU No.  : " & Cmb_ZCU.SelectedValue & " ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงชื่อชั้นจอดรถ", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Save_ZCU_Config(pTower_ID As String, pBuiding_ID As String, pFloor_Controller_ID As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " UPDATE [Mas_Floor_Controller] set  "
        ' sql &= "[Floor_Controller_Max_Lot]='" & txt_Max_UD.Text & "',"
        'sql &= "[Floor_Controller_Max_DP]='" & txt_Max_DP.Text & "',"
        'sql &= "[Floor_Controller_Max_CP]='" & txt_Max_CP.Text & "',"
        sql &= "[Floor_Controller_Date_Time]=" & DBFormatDate(dtpDate_Time.Value) & ","
        sql &= "[Floor_Controller_Close_DP_From]='" & txtClose_DP_From.Text & "',"
        sql &= "[Floor_Controller_Close_DP_To]='" & txtClose_DP_To.Text & "',"
        sql &= "[Floor_Controller_Close_UD_From]='" & txtClose_UD_From.Text & "',"
        sql &= "[Floor_Controller_Close_UD_To]='" & txtClose_UD_To.Text & "',"
        sql &= "[Floor_Controller_Zcu_Timeout_Request]='" & txtZcu_Timeout_Request.Text & "',"
        sql &= "[Floor_Controller_Zcu_Time_Sleep_Mode]='" & txtZcu_Time_Sleep_Mode.Text & "'"
        sql &= " WHERE [Tower_ID]='" & pTower_ID & "' and [Building_ID]='" & pBuiding_ID & "' and Floor_Controller_ID='" & pFloor_Controller_ID & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ บันทึกข้อมูล ZCU No.  : " & Cmb_ZCU.SelectedValue & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                MessageBox.Show("    บันทึกข้อมูล ZCU No.  : " & Cmb_ZCU.SelectedValue & " เรียบร้อย ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Save_ZCU_Config", Err.Number, Err.Description)
    End Sub
    Sub Load_Mas_Tower()
        Try
            Dim sql As String = ""
            sql = "SELECT Tower_ID,Tower_Name FROM Mas_Tower   order by Tower_ID"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                cboMas_Tower.DataSource = dt
                cboMas_Tower.DisplayMember = "Tower_Name"
                cboMas_Tower.ValueMember = "Tower_ID"
                cboMas_Tower.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_Mas_Tower :" & ex.Message)
        End Try

    End Sub
    Sub Load_Mas_Building_Parking(ByVal pTower_ID As String, ByVal select_buiding As String)
        Try
            Dim sql As String = ""
            sql = "SELECT Building_ID,Building_Name FROM Mas_Building_Parking WHERE [Tower_ID]='" & pTower_ID & "' order by Building_ID"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                cboMas_Building_Parking.DataSource = dt
                cboMas_Building_Parking.DisplayMember = "Building_Name"
                cboMas_Building_Parking.ValueMember = "Building_ID"

                If select_buiding <> "" Then
                    cboMas_Building_Parking.SelectedValue = select_buiding
                Else
                    cboMas_Building_Parking.SelectedIndex = 0
                End If

            End If
        Catch ex As Exception
            MsgBox("can not load function Load_Mas_Building_Parking :" & ex.Message)
        End Try
    End Sub

    Sub load_combo_ZCUA()
        Dim sql As String = ""
        Try

            sql = "SELECT [ID],[Floor_Controller_Name] FROM [Mas_Floor_Controller] ORDER BY [ID]"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                With Zcu_A0
                    .DataSource = dt
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With


                With Zcu_A1
                    .DataSource = dt
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_A2
                    .DataSource = dt
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_A3
                    .DataSource = dt
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_A4
                    .DataSource = dt
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_A5
                    .DataSource = dt
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                Zcu_A0.SelectedIndex = 0
                Zcu_A1.SelectedIndex = 0
                Zcu_A2.SelectedIndex = 0
                Zcu_A3.SelectedIndex = 0
                Zcu_A4.SelectedIndex = 0
                Zcu_A5.SelectedIndex = 0
            End If
        Catch ex As Exception
            cdb.writeError("load_combo_ZCU :" & ex.Message)
        End Try
    End Sub

    Sub load_combo_ZCUB()
        Dim sql As String = ""
        Try


            sql = "SELECT [ID],[Floor_Controller_Name] FROM [Mas_Floor_Controller] ORDER BY [ID]"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                
                With Zcu_B0
                    Dim dt2 As New DataTable
                    dt2 = dt
                    .DataSource = dt2
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_B1
                    Dim dt3 As New DataTable
                    dt3 = dt
                    .DataSource = dt3
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_B2
                    Dim dt4 As New DataTable
                    dt4 = dt
                    .DataSource = dt4
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_B3
                    Dim dt5 As New DataTable
                    dt5 = dt
                    .DataSource = dt5
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_B4
                    Dim dt6 As New DataTable
                    dt6 = dt
                    .DataSource = dt6

                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                With Zcu_B5
                    Dim dt6 As New DataTable
                    dt6 = dt
                    .DataSource = dt6
                    .DisplayMember = "Floor_Controller_Name"
                    .ValueMember = "ID"
                End With
                Zcu_B0.SelectedIndex = Zcu_B0.Items.Count - 1
                Zcu_B1.SelectedIndex = Zcu_B1.Items.Count - 1
                Zcu_B2.SelectedIndex = Zcu_B2.Items.Count - 1
                Zcu_B3.SelectedIndex = Zcu_B3.Items.Count - 1
                Zcu_B4.SelectedIndex = Zcu_B4.Items.Count - 1
                Zcu_B5.SelectedIndex = Zcu_B5.Items.Count - 1

            End If
        Catch ex As Exception
            cdb.writeError("load_combo_ZCU :" & ex.Message)
        End Try
    End Sub
    Sub Load_ZCU_Combo(ByVal pTower_ID As String, ByVal pBuilding_ID As String, ByVal select_zcu As String)
        Try
            Dim sql As String = ""
            sql = "SELECT Floor_Controller_ID,Floor_Controller_Name FROM Mas_Floor_Controller WHERE [Tower_ID]='" & pTower_ID & "' and [Building_ID]='" & pBuilding_ID & "'  order by Floor_Controller_ID"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                Cmb_ZCU.DataSource = dt
                Cmb_ZCU.DisplayMember = "Floor_Controller_Name"
                Cmb_ZCU.ValueMember = "Floor_Controller_ID"

                If select_zcu <> "" Then
                    Cmb_ZCU.SelectedValue = select_zcu
                Else
                    Cmb_ZCU.SelectedIndex = 0
                End If

            End If
        Catch ex As Exception
            MsgBox("can not load function Load_ZCU :" & ex.Message)
        End Try
    End Sub

    Private Sub cmdSave_Load_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave_Load.Click
        'Load_Data_To_ZCU_Config(cboMas_Tower.SelectedValue, cboMas_Building_Parking.SelectedValue, Cmb_ZCU.SelectedValue)

        Dim sql As String = ""
        Dim zcu_st As Integer = 0
        Dim zcu_End As Integer = 0
        zcu_st = Zcu_A5.SelectedValue
        zcu_End = Zcu_B5.SelectedValue
        For i As Integer = zcu_st To zcu_End
            Load_Data_To_ZCU_Config("1", "1", i)
        Next
        MsgBox("SUCCESS")
    End Sub
    Sub Load_Data_To_ZCU_Config(pTower_ID As String, pBuiding_ID As String, pFloor_Controller_ID As String)
        On Error GoTo Err
        Dim sql As String = ""
        sql &= "INSERT INTO [Mas_ZCU_Update_Request]"
        sql &= "([Tower_ID]"
        sql &= ",[Building_ID]"
        sql &= ",[Floor_Controller_ID]"
        sql &= ",[Datetime_Request])"
        sql &= " VALUES("
        sql &= "'" & pTower_ID & "'," '<Tower_ID, nvarchar(50),>"
        sql &= "'" & pBuiding_ID & "'," ',<Building_ID, nvarchar(50),>"
        sql &= "'" & pFloor_Controller_ID & "'," ',<Floor_Controller_ID, nvarchar(50),>"
        sql &= "" & DBFormatDate(dtpDate_Time.Value) & "" ',<Datetime_Request, datetime,>"
        sql &= ")"
        Excute_SQL(ConStr_Master, sql)
        'If MsgBox("คุณต้องการส่งข้อมูล  Config ไปที่ ZCU No.  : " & Cmb_ZCU.SelectedValue & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
        '    MessageBox.Show("    ส่งข้อมูล  Config ไปที่ ZCU No.  : " & Cmb_ZCU.SelectedValue & " เรียบร้อย ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Excute_SQL(ConStr_Master, sql)
        'Else

        'End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Load_Data_To_ZCU_Config", Err.Number, Err.Description)
    End Sub

    Private Sub Cmb_ZCU_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmb_ZCU.SelectedIndexChanged
        Try
            Call Load_ZCU_Config(cboMas_Tower.SelectedValue, cboMas_Building_Parking.SelectedValue, Cmb_ZCU.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim sql As String = ""
        Dim zcu_st As Integer = 0
        Dim zcu_End As Integer = 0
        zcu_st = Zcu_A1.SelectedValue
        zcu_End = Zcu_B1.SelectedValue
        For i As Integer = zcu_st To zcu_End
            sql = "UPDATE Mas_Floor_Controller SET Floor_Controller_Close_DP_From = '" & txtClose_DP_From.Text & "',Floor_Controller_Close_DP_To='" & txtClose_DP_To.Text & "' where [ID] = '" & i & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                cdb.writeError("Button1_Click : " & sql)
            End If
        Next
        MsgBox("SUCCESS")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim sql As String = ""
        Dim zcu_st As Integer = 0
        Dim zcu_End As Integer = 0
        zcu_st = Zcu_A2.SelectedValue
        zcu_End = Zcu_B2.SelectedValue
        For i As Integer = zcu_st To zcu_End
            sql = "UPDATE Mas_Floor_Controller SET Floor_Controller_Close_UD_From = '" & txtClose_UD_From.Text & "',Floor_Controller_Close_UD_To='" & txtClose_UD_To.Text & "' where [ID] = '" & i & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                cdb.writeError("Button2_Click : " & sql)
            End If
        Next
        MsgBox("SUCCESS")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim sql As String = ""
        Dim zcu_st As Integer = 0
        Dim zcu_End As Integer = 0
        zcu_st = Zcu_A3.SelectedValue
        zcu_End = Zcu_B3.SelectedValue
        For i As Integer = zcu_st To zcu_End
            sql = "UPDATE Mas_Floor_Controller SET Floor_Controller_Zcu_Timeout_Request = '" & txtZcu_Timeout_Request.Text & "' where [ID] = '" & i & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                cdb.writeError("Button3_Click : " & sql)
            End If
        Next
        MsgBox("SUCCESS")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim sql As String = ""
        Dim zcu_st As Integer = 0
        Dim zcu_End As Integer = 0
        zcu_st = Zcu_A4.SelectedValue
        zcu_End = Zcu_B4.SelectedValue
        For i As Integer = zcu_st To zcu_End
            sql = "UPDATE Mas_Floor_Controller SET Floor_Controller_Zcu_Time_Sleep_Mode = '" & txtZcu_Time_Sleep_Mode.Text & "' where [ID] = '" & i & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                cdb.writeError("Button4_Click : " & sql)
            End If
        Next
        MsgBox("SUCCESS")
    End Sub
End Class