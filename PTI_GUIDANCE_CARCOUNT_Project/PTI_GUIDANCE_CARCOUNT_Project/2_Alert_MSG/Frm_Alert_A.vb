Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient

Imports System.Data
Imports System.IO.Directory
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class Frm_Alert_A
    Dim DT As System.Data.DataTable

    Dim cdb As New CDatabase
    Private Sub Frm_Alert_A_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        load_table()
    End Sub
    Sub load_table()
        Dim sql As String = ""
        sql = "SELECT TOP 200 * FROM Lbl_Alert_A_Detail ORDER BY Mas_Alam_Date DESC"
        DT = cdb.readTableData(sql, ConStr_Guidance)
        If dt.Rows.Count > 0 Then
            DGV_1.Rows.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1
                DGV_1.Rows.Add(i + 1, DT.Rows(i).Item("Mas_Alam_Date").ToString, _
                               DT.Rows(i).Item("Alam_Remark").ToString)
            Next
        End If

    End Sub
    Sub find_table(ByVal date_ As String, ByVal keyword_ As String)
        Dim sql As String = ""
        sql = "SELECT * FROM Lbl_Alert_A_Detail "
        sql &= " WHERE Alam_Remark <> '' "
        If date_ <> "" Then sql &= " and cast([Mas_Alam_Date] as date) = cast('" & cdb.GetDateToDB(date_) & "' as date)"
        If keyword_ <> "" Then sql &= " and Alam_Remark LIKE '%" & keyword_ & "%'"
        sql &= " ORDER BY Mas_Alam_Date DESC"
        DT = cdb.readTableData(sql, ConStr_Guidance)
        If dt.Rows.Count > 0 Then
            DGV_1.Rows.Clear()
            If dt.Rows.Count > 200 Then
                For i As Integer = 0 To 199
                    DGV_1.Rows.Add(i + 1, DT.Rows(i).Item("Mas_Alam_Date").ToString, _
                                   DT.Rows(i).Item("Alam_Remark").ToString)
                Next
                MsgBox("รายการที่ค้นหา พบมากกว่า 200 รายการ กรูณาจำกัดคำในการค้นหา")
            Else
                For i As Integer = 0 To dt.Rows.Count - 1
                    DGV_1.Rows.Add(i + 1, DT.Rows(i).Item("Mas_Alam_Date").ToString, _
                                   DT.Rows(i).Item("Alam_Remark").ToString)
                Next
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            If TextBox1.Text = "" Then
                find_table(DateTimePicker1.Value.Date, "")
            Else
                find_table(DateTimePicker1.Value.Date, TextBox1.Text)
            End If

        Else
            find_table("", TextBox1.Text)
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim RPT As Object

        RPT = New RPT_ALERT_A
        ShowReport(DT, Me.Text, RPT, DateTimePicker1.Value.Date, DateTimePicker1.Value.Date)
        Print_Preview.Show()
    End Sub
    Public Sub ShowReport(ByVal Dtb_Report As System.Data.DataTable, _
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
            Print_Preview.CTR_Viewer.ParameterFieldInfo = MainParaField
            SqlReport.SetDataSource(Dtb_Report)
            Print_Preview.CTR_Viewer.ReportSource = SqlReport
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

   
End Class