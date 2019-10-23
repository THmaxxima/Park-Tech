Imports System.Windows.Forms
Imports CrystalDecisions.Shared

Public Class Dg_Lot_History
    Dim cdb As New CDatabase

    Public Lot_id As String = ""
    Public Buiding_id As String = "1"
    Public floor_no As String = "1"
    Dim date_st As DateTime = Now.Date
    Dim date_end As DateTime = Now.Date
    Dim sql_find As String = ""

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click     
        load_table(Lot_id)
        load_history(False)
    End Sub
    Sub load_table(ByVal lotid As String)
        Dim sql As String = ""
        sql = "SELECT * FROM Q_Mas_Lot WHERE HW_Lot_Id= '" & lotid & "' "
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        Dim st_ As String = ""

        If DT.Rows.Count > 0 Then
            Label1.Text = "" & _
               "Lot ID :" & DT.Rows(0).Item("HW_Lot_Id").ToString & vbNewLine & _
               "อาคาร-Buiding : " & DT.Rows(0).Item("HW_Building_ID").ToString & vbNewLine & _
               "ชั้น-Floor :" & DT.Rows(0).Item("Floor_Name").ToString & vbNewLine & _
               "สถานะ-Status :" & DT.Rows(0).Item("Status_Name").ToString

            Label10.Text = "" & _
              "วันที่เข้าล่าสุด :" & DT.Rows(0).Item("HW_Datetime_In").ToString
            If DT.Rows(0).Item("HW_On_Line").ToString = "0" Then
                Label10.Text = "วันที่เข้าล่าสุด : - "
            Else
                Label10.Text &= " จอดมาแล้ว : " & DT.Rows(0).Item("HW_Time_HH").ToString & " ชม." & _
             " : " & DT.Rows(0).Item("HW_Time_MM").ToString & " นาที. "
            End If

        Else
            Label1.Text = "-"
            Label10.Text = "วันที่เข้าล่าสุด : - "
        End If

    End Sub
    Sub load_history(ByVal load_today As Boolean)
        Dim sql As String = ""
        Dim HH As Integer = 0
        Dim MM As Integer = 0
        date_st = DateTimePicker1.Value
        date_end = DateTimePicker2.Value
        If CheckBox2.Checked = True Then
            If TextBox1.Text.Trim <> "" Then
                If IsNumeric(TextBox1.Text.Trim) = True Then
                    sql = "SELECT TOP " & TextBox1.Text.Trim & " * FROM [M_V_Transaction_Mas_Lot] WHERE Trn_Lot_Id = '" & Lot_id & "'"
                Else
                    MsgBox("ค่านี้ไม่ใช่ค่าตัวเลข")
                    Exit Sub
                End If
            Else
                MsgBox("กรุณาใส่จำนวน record ที่จะแสดง")
                Exit Sub
            End If
        Else
            sql = "SELECT * FROM [M_V_Transaction_Mas_Lot] WHERE Trn_Lot_Id = '" & Lot_id & "'"
        End If

        If CheckBox1.Checked = True Then
            If load_today = True Then
                sql &= " and CAST([Trn_Log_Date] AS DATE) = CAST(GETDATE() AS DATE)"
            Else
                sql &= " and [Trn_Log_Date] between '" & cdb.GetDateToDB(DateTimePicker1.Value) & "' and '" & cdb.GetDateToDB(DateTimePicker2.Value) & "'"
            End If
            'Else
            '    If IsDBNull(date_st) = False Then
            '        sql &= " AND Trn_Date BETWEEN '" & cdb.GetDateToDB(date_st) & "' and '" & cdb.GetDateToDB(date_end) & "' "
            '    End If
        End If

        If CheckBox3.Checked = True Then
            If TextBox2.Text.Trim <> "" Then
                If IsNumeric(TextBox2.Text.Trim) = True Then
                    sql &= " and datediff(MINUTE ,[Trn_Log_Datetime_In],[Trn_Log_Datetime_Out]) > " & TextBox2.Text.Trim
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

        sql_find = sql
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        'DT_find = DT

        DGV_1.Rows.Clear()
        ' Label6.Text = "0"
        If DT.Rows.Count > 0 Then
            ' Label6.Text = DT.Rows.Count

            For i As Integer = 0 To DT.Rows.Count - 1
                DGV_1.Rows.Add(i + 1, _
                               DT.Rows(i).Item("Trn_Log_Datetime_In").ToString, _
                               DT.Rows(i).Item("Trn_Log_Datetime_Out").ToString, _
                               DT.Rows(i).Item("Trn_Park_HH").ToString & " ชม.(Hr.) : " & DT.Rows(i).Item("Trn_Park_MM").ToString & " นาที(Sec.)" _
                                )
                HH = DT.Rows(i).Item("Trn_Park_HH").ToString + HH
                MM = DT.Rows(i).Item("Trn_Park_MM").ToString + MM
            Next

            'Label4.Text = DT.Rows.Count

            If MM >= 60 Then
                HH = HH + Math.Floor(MM / 60)
                MM = MM Mod 60
            End If
            'Label7.Text = HH & ""
            'Label9.Text = MM & ""
            'If DT.Rows.Count < TextBox1.Text Then
            '    Label5.Text = DT.Rows.Count
            'Else
            '    Label5.Text = TextBox1.Text
            'End If
        Else
            'MsgBox("ไม่พบข้อมูล")
        End If

    End Sub

    Private Sub Dg_Lot_History_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Now.Date & " 00:00:00"
        DateTimePicker2.Value = Now.Date & " 23:59:59"
        load_table(Lot_id)
        load_history(True)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim RPT As Object
        'load_history(False)
        RPT = New RPT_History_Lot_NEW

        Dim DT_find As DataTable = cdb.readTableData(sql_find, ConStr_Guidance)
        ShowReport(DT_find, Me.Text, RPT, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date)
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

            Dim frm As New Print_Preview_H
            With frm
                .CTR_Viewer.ParameterFieldInfo = MainParaField
                SqlReport.SetDataSource(Dtb_Report)
                .CTR_Viewer.ReportSource = SqlReport
                .ShowDialog()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
