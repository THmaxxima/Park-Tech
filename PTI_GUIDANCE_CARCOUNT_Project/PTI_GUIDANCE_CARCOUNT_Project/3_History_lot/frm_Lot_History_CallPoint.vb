Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class frm_Lot_History_CallPoint
    Friend Lot_id As String = ""
    Friend Buiding_id As String = "1"
    Friend floor_no As String = "1"

    Dim DT As DataTable

    Dim cdb As New CDatabase
    Private Sub frm_Lot_History_CallPoint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "ประวัติการใช้งาน Callpoint"
        load_table()
        load_history(True)

    End Sub
    Sub load_table()
        Dim sql As String = ""
        sql = "SELECT * FROM V_Mas_Callpoint WHERE HW_Call_Id= '" & Lot_id & "'"
        DT = cdb.readTableData(sql, ConStr_Master)
        Dim st_ As String = ""

        If DT.Rows.Count > 0 Then
            If DT.Rows(0).Item("HW_Status_Id").ToString = "0" Then
                st_ = "ขัดข้อง - Crash"
            Else
                st_ = "ปกติ - Normal"
            End If
            Label1.Text = "" & _
               "Lot ID :" & DT.Rows(0).Item("HW_Call_Id").ToString & vbNewLine & _
               "อาคาร-Buiding :" & DT.Rows(0).Item("Building_Name").ToString & vbNewLine & _
               "ชั้น-Floor :" & DT.Rows(0).Item("Floor_Name").ToString & vbNewLine & _
               "สถานะ-Status :" & st_
        Else
            Label1.Text = "-"
        End If

    End Sub
    Sub load_history(ByVal load_today As Boolean)
        Dim sql As String = ""

        If CheckBox2.Checked = True Then
            If TextBox1.Text.Trim <> "" Then
                If IsNumeric(TextBox1.Text.Trim) = True Then
                    sql = "SELECT TOP " & TextBox1.Text.Trim & " * FROM [Q_Report_Transaction_CallPoint_Detail] WHERE Trn_Lot_Id = '" & Lot_id & "'"
                Else
                    MsgBox("ค่านี้ไม่ใช่ค่าตัวเลข")
                    Exit Sub
                End If
            Else
                MsgBox("กรุณาใส่จำนวน record ที่จะแสดง")
                Exit Sub
            End If
        Else
            sql = "SELECT * FROM [Q_Report_Transaction_CallPoint_Detail] WHERE Trn_Lot_Id = '" & Lot_id & "'"
        End If


        If CheckBox1.Checked = True Then
            If load_today = True Then
                sql &= " and CAST([Trn_Log_Date] AS DATE) = CAST(GETDATE() AS DATE)"
            Else
                sql &= " and [Trn_Log_Date] between '" & cdb.GetDateToDB(DateTimePicker1.Value) & "' and '" & cdb.GetDateToDB(DateTimePicker2.Value) & "'"
            End If

        End If

        If CheckBox3.Checked = True Then
            If TextBox2.Text.Trim <> "" Then
                If IsNumeric(TextBox2.Text.Trim) = True Then
                    sql &= " and datediff(MINUTE ,[T1_Time_In],[T3_Time_Out]) > " & TextBox2.Text.Trim
                Else
                    MsgBox("ค่านี้ไม่ใช่ค่าตัวเลข")
                    Exit Sub
                End If
            Else
                MsgBox("กรุณาใส่จำนวนนาที")
                Exit Sub
            End If
        End If

        sql &= " Order by Trn_Log_Date DESC"

        DT = cdb.readTableData(sql, ConStr_Guidance)
        DGV_1.Rows.Clear()
        If DT.Rows.Count > 0 Then


            For i As Integer = 0 To DT.Rows.Count - 1
                DGV_1.Rows.Add(i + 1, _
                               DT.Rows(i).Item("T1_Time_In").ToString, _
                               DT.Rows(i).Item("T3_Time_Out").ToString, _
                                DT.Rows(i).Item("T3_HH").ToString & " ชม.(Hr.) : " & DT.Rows(i).Item("T3_MM").ToString & " นาที(Sec.)", _
                               DT.Rows(i).Item("Service_User_FirstName").ToString & " " & DT.Rows(i).Item("Service_User_LastName").ToString _
                                )
            Next

            Label4.Text = DT.Rows.Count


            If DT.Rows.Count < TextBox1.Text Then
                Label5.Text = DT.Rows.Count
            Else
                Label5.Text = TextBox1.Text
            End If
        Else
            MsgBox("ไม่พบข้อมูล")
        End If

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        load_history(False)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim RPT As Object

        RPT = New RPT_History_Lot
        ShowReport(DT, Me.Text, RPT, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
        Print_Preview_H.Show()
    End Sub
    Public Sub ShowReport(ByVal Dtb_Report As DataTable, _
ByVal Header_Report As String, _
 ByVal SqlReport As Object, _
Optional ByRef DateSt As String = "", _
Optional ByRef DateEnd As String = "")
        Try
            '##################
            Dim MainParaField As New ParameterFields
            Dim DisCreatValue_ As New ParameterDiscreteValue
            Dim paraHeaderReport As New ParameterField
            Dim paraRPT_ID As New ParameterField
            Dim paraUser_Print As New ParameterField
            Dim paraDateBetaween As New ParameterField
            Dim paraDateSt As New ParameterField
            Dim paraDateEnd As New ParameterField
            Dim paraTower_Name As New ParameterField
            Dim paraTower_Location As New ParameterField
            Dim paraTower_Tax As New ParameterField
            Dim paraTower_Tel As New ParameterField
            Dim paraTower_Fax As New ParameterField
            Dim paraBuilding As New ParameterField
            Dim paraFloor As New ParameterField
            '#### Building
            'paraBuilding.ParameterFieldName = "Building"
            'DisCreatValue_ = New ParameterDiscreteValue
            'DisCreatValue_.Value = cmb_Building.Text
            'paraBuilding.CurrentValues.Add(DisCreatValue_)
            'MainParaField.Add(paraBuilding)
            '#### Building
            'paraFloor.ParameterFieldName = "Floor"
            'DisCreatValue_ = New ParameterDiscreteValue
            'DisCreatValue_.Value = cmb_Floor.Text
            'paraFloor.CurrentValues.Add(DisCreatValue_)
            'MainParaField.Add(paraFloor)

            '#### HeaderReport
            paraHeaderReport.ParameterFieldName = "HeaderReport"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Header_Report
            paraHeaderReport.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraHeaderReport)
            '#### RPT_ID
            'paraRPT_ID.ParameterFieldName = "RPT_ID"
            'DisCreatValue_ = New ParameterDiscreteValue
            'DisCreatValue_.Value = RPT_ID
            'paraRPT_ID.CurrentValues.Add(DisCreatValue_)
            'MainParaField.Add(paraRPT_ID)
            '#### User_Print
            paraUser_Print.ParameterFieldName = "User_Print"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = CurUser_FullName
            paraUser_Print.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraUser_Print)
            '#### Tower_Name
            paraTower_Name.ParameterFieldName = "Tower_Name"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Cur_Tower_Name
            paraTower_Name.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraTower_Name)
            '#### Tower_Location
            paraTower_Location.ParameterFieldName = "Tower_Location"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Cur_Tower_Location
            paraTower_Location.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraTower_Location)
            '#### Tower_Tax
            paraTower_Tax.ParameterFieldName = "Tower_Tax"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Cur_Tower_Tax
            paraTower_Tax.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraTower_Tax)
            '#### Tower_Tel
            paraTower_Tel.ParameterFieldName = "Tower_Tel"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Cur_Tower_Tel
            paraTower_Tel.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraTower_Tel)
            '#### Tower_Fax
            paraTower_Fax.ParameterFieldName = "Tower_Fax"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Cur_Tower_Fax
            paraTower_Fax.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraTower_Fax)
            '#### StTimeSt
            If DateSt.Length <= 10 Then
                DateSt = DateSt & " 00:00:00"
            End If
            If DateEnd.Length <= 10 Then
                DateEnd = DateEnd & " 23:59:59"
            End If
            paraDateSt.ParameterFieldName = "DateSt"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = DateSt
            paraDateSt.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraDateSt)
            '#### StTimeEnd
            paraDateEnd.ParameterFieldName = "DateEnd"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = DateEnd
            paraDateEnd.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraDateEnd)
            '##########
            '#################       
            Print_Preview_H.CTR_Viewer.ParameterFieldInfo = MainParaField
            SqlReport.SetDataSource(Dtb_Report)
            Print_Preview_H.CTR_Viewer.ReportSource = SqlReport
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DGV_1_Sorted(sender As Object, e As System.EventArgs) Handles DGV_1.Sorted
        For i As Integer = 0 To DGV_1.Rows.Count - 2
            DGV_1.Rows(i).Cells(0).Value = i + 1
        Next
    End Sub
End Class