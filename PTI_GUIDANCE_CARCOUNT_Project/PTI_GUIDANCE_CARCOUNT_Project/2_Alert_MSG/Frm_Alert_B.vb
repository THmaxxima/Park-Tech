Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class Frm_Alert_B
    Dim DT As DataTable

    Dim cdb As New CDatabase
    Private Sub Frm_Alert_B_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        load_table()
    End Sub
    Sub load_table()
        Dim sql As String = ""
        sql = "SELECT  TOP 200 * FROM Lbl_Alert_B_Detail ORDER BY HW_Datetime_Update DESC"
        DT = cdb.readTableData(sql, ConStr_Guidance)
        If DT.Rows.Count > 0 Then
            DGV_1.Rows.Clear()
            For i As Integer = 0 To DT.Rows.Count - 1
                DGV_1.Rows.Add(i + 1, DT.Rows(i).Item("HW_Datetime_Update").ToString, _
                                DT.Rows(i).Item("msg").ToString, _
                                DT.Rows(i).Item("HW_Building_ID").ToString, _
                               DT.Rows(i).Item("HW_Floor_No").ToString, _
                               DT.Rows(i).Item("HW_Lot_Id").ToString, _
                               DT.Rows(i).Item("HW_Floorcontroller_Id").ToString, _
                               "" _
                               )
            Next
        End If

    End Sub
    Sub find_table(ByVal date_ As String, ByVal keyword_ As String)
        Dim sql As String = ""
        sql = "SELECT * FROM Lbl_Alert_B_Detail "
        sql &= " WHERE [msg] <> '' "
        If date_ <> "" Then sql &= " and cast([HW_Datetime_Update] as date) = cast('" & cdb.GetDateToDB(date_) & "' as date)"
        If keyword_ <> "" Then sql &= " msg LIKE '%" & keyword_ & "%'"
        sql &= " ORDER BY HW_Datetime_Update DESC"
        DT = cdb.readTableData(sql, ConStr_Guidance)
        If DT.Rows.Count > 0 Then
            DGV_1.Rows.Clear()
            For i As Integer = 0 To DT.Rows.Count - 1
                DGV_1.Rows.Add(i + 1, DT.Rows(i).Item("HW_Datetime_Update").ToString, _
                                DT.Rows(i).Item("msg").ToString, _
                                DT.Rows(i).Item("HW_Building_ID").ToString, _
                               DT.Rows(i).Item("HW_Floor_No").ToString, _
                               DT.Rows(i).Item("HW_Lot_Id").ToString, _
                               DT.Rows(i).Item("HW_Floorcontroller_Id").ToString, _
                               "" _
                               )
            Next

            'If DT.Rows.Count > 200 Then
            '    For i As Integer = 0 To 199
            '        DGV_1.Rows.Add(i + 1, DT.Rows(i).Item(0).ToString, _
            '                       DT.Rows(i).Item(1).ToString)
            '    Next
            '    MsgBox("รายการที่ค้นหา พบมากกว่า 200 รายการ กรูณาจำกัดคำในการค้นหา")
            'Else
            '    For i As Integer = 0 To DT.Rows.Count - 1
            '        DGV_1.Rows.Add(i + 1, DT.Rows(i).Item(0).ToString, _
            '                       DT.Rows(i).Item(1).ToString)
            '    Next
            'End If
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
        Button3.Enabled = False
        Dim RPT As Object
        RPT = New RPT_ALERT_B
        ShowReport(DT, Me.Text, RPT, DateTimePicker1.Value.Date, DateTimePicker1.Value.Date)
        Print_Preview.Show()
        Button3.Enabled = True
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
            Print_Preview.CTR_Viewer.ParameterFieldInfo = MainParaField
            SqlReport.SetDataSource(Dtb_Report)
            Print_Preview.CTR_Viewer.ReportSource = SqlReport
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DGV_1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_1.CellContentClick
        Try
            If e.ColumnIndex = 7 Then
                Dim Buiding_ As String = DGV_1.Rows(e.RowIndex).Cells(3).Value
                Dim Floor_ As String = DGV_1.Rows(e.RowIndex).Cells(4).Value
                Dim UD_ID As String = DGV_1.Rows(e.RowIndex).Cells(5).Value
                Dim Zcu As String = DGV_1.Rows(e.RowIndex).Cells(6).Value

                If UD_ID <> "" Then
                    With frmNew_Display_All
                        .Building_ID = Buiding_
                        .Floor_No = Floor_
                        .ZCU_ID = Zcu
                        .UD_ID = UD_ID
                        .ShowDialog()
                    End With
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class