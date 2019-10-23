Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class Frm_Alert_C
    Dim DT As DataTable

    Dim cdb As New CDatabase
    Private Sub Frm_Alert_C_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        load_table("")
        cmb_floor()
    End Sub
    Sub load_table(ByVal condition_ As String)
        Dim sql As String = ""
        sql = " SELECT [HW_Lot_Id]"
        sql &= "  ,[HW_Lot_Name]"
        sql &= "  ,[HW_Floor_No]"
        sql &= "  ,[HW_Floorcontroller_Id]"
        sql &= "  ,[HW_Datetime_Update]"
        sql &= "  ,[HW_Datetime_In]"
        sql &= "  ,[HW_Time_HH]"
        sql &= "  ,[HW_Time_MM]"
        sql &= "  ,[Floor_No]"
        sql &= "  ,[Floor_Controller_Name]"
        sql &= "  ,[Floor_Name]"
        sql &= "  ,[HW_Building_ID]"
        sql &= "  ,[Status_Name]"
        sql &= "  ,[Alarm_Id]"
        sql &= " FROM Lbl_Alert_C_Detail "
        If condition_ <> "" Then
            sql &= condition_
        End If
        sql &= " ORDER BY [HW_Building_ID],Floor_No,HW_Datetime_In,HW_Lot_Id DESC"
        DT = cdb.readTableData(sql, ConStr_Guidance)
        If DT.Rows.Count > 0 Then
            DGV_1.Rows.Clear()

            For i As Integer = 0 To DT.Rows.Count - 1
                DGV_1.Rows.Add(i + 1, DT.Rows(i).Item("HW_Datetime_In").ToString, _
                               DT.Rows(i).Item("HW_Lot_Name").ToString & "=" & DT.Rows(i).Item("HW_Time_HH").ToString & " ชม. " & DT.Rows(i).Item("HW_Time_MM").ToString & " นาที.", _
                               DT.Rows(i).Item("HW_Building_ID").ToString, _
                                DT.Rows(i).Item("Floor_No").ToString, _
                               DT.Rows(i).Item("HW_Building_ID").ToString & ":" & DT.Rows(i).Item("Floor_Name").ToString, _
                               DT.Rows(i).Item("HW_Lot_Id").ToString)
            Next
        End If

    End Sub
  

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim sql As String = " WHERE HW_Lot_Name <> '' "

        If TextBox1.Text <> "" Then
            sql &= " and [HW_Lot_Name] LIKE '%" & TextBox1.Text & "%'"
        Else
            sql &= ""
        End If
        If Cmb_floor_2.SelectedValue <> "" Then
            Dim a() As String = Cmb_floor_2.SelectedValue.ToString.Split(":")
            sql &= " and HW_Building_ID='" & a(0) & "' and Floor_No = '" & a(1) & "'"
        End If

        load_table(sql)
    End Sub
    Sub cmb_floor()
        Dim sql As String = ""

        sql = "SELECT CONVERT(varchar(5),Building_ID) +':' + CONVERT(varchar(5),Floor_No)   AS ID_,[Building_Name] + ' : ' +  [Floor_Name] AS NAME_ FROM [MTL_MASTER_GUIDANCE].[dbo].[V_Mas_Floor] order by [Floor_ID]"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Cmb_floor_2.DataSource = DT
            Cmb_floor_2.ValueMember = "ID_"
            Cmb_floor_2.DisplayMember = "Name_"
            Cmb_floor_2.SelectedIndex = 0
        End If
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim RPT As Object

        RPT = New RPT_ALERT_A
        ShowReport(DT, Me.Text, RPT, Now.Date, Now.Date)
        Print_Preview.Show()
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
                'Dim UD_ID As String = DGV_1.Rows(e.RowIndex).Cells(6).Value

                With frmNew_Display_Over_HH
                    .Building_ID = Buiding_
                    .Floor_no = Floor_
                    .Show()
                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

   
End Class