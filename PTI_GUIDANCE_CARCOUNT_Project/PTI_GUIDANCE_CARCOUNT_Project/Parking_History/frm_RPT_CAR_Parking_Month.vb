Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class frm_RPT_CAR_Parking_Month
    Dim ClsSqlCmd As New ClassCommandSql
    Friend pHeader_Detail As String
    Friend LogID As String
    Friend Description As String
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
            Dim paraDescription As New ParameterField
            ''#### Building
            'paraBuilding.ParameterFieldName = "Building"
            'DisCreatValue_ = New ParameterDiscreteValue
            'DisCreatValue_.Value = cmb_Building.Text
            'paraBuilding.CurrentValues.Add(DisCreatValue_)
            'MainParaField.Add(paraBuilding)
            ''#### Building
            'paraFloor.ParameterFieldName = "Floor"
            'DisCreatValue_ = New ParameterDiscreteValue
            'DisCreatValue_.Value = cmb_Floor.Text
            'paraFloor.CurrentValues.Add(DisCreatValue_)
            'MainParaField.Add(paraFloor)
            ' Header_Report = Header_Report
            '#### HeaderReport
            ''#### Building
            paraDescription.ParameterFieldName = "Description"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = Description
            paraDescription.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraDescription)
            ' Header_Report = Header_Report
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
            CTR_Viewer.ParameterFieldInfo = MainParaField
            SqlReport.SetDataSource(Dtb_Report)
            CTR_Viewer.ReportSource = SqlReport
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frm_RPT_CAR_Parking_Month_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Query_Report_ByTower()
    End Sub
    Sub Query_Report_ByTower()
        Dim Str_Quy As String = ""
        Dim pDtb_Qury As DataTable
        'Dim DateSt As DateTime
        'Dim DateEnd As DateTime
        'DateSt = DTPickerSt.Value.ToShortDateString & " " & TimeIn.Value.ToLongTimeString
        'DateEnd = DTPickerEnd.Value.ToShortDateString & " " & TimeOut.Value.ToLongTimeString

        Str_Quy = "Select * from Mas_Capture_Screen "
        Str_Quy &= " where Log_ID ='" & LogID & "' " '(Trn_Log_Date between " & mDB.DBFormatDate(DateSt) & " and " & mDB.DBFormatDate(DateEnd) & ")"

        'If cmb_Tower.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Tower_ID = '" & cmb_Tower.SelectedValue & "'"
        'If cmb_Building.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Building_ID = '" & cmb_Building.SelectedValue & "'"
        'If cmb_Floor.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Floor_No = '" & cmb_Floor.SelectedValue & "'"

        ' Str_Quy &= " order by  [Trn_Tower_ID],[Trn_Building_ID],[Trn_Month],[Trn_Log_Date]"

        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrMaster_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_CAR_Parking_Month
        ShowReport(pDtb_Qury, pHeader_Detail, RPT)

    End Sub
End Class