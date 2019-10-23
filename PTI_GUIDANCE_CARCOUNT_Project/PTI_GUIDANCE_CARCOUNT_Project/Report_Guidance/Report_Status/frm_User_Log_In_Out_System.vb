Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class frm_User_Log_In_Out_System
    Dim ClsSqlCmd As New ClassCommandSql
    Friend pHeader_Detail As String
    Private Sub frm_User_Log_In_Out_System_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mMain.Load_AppConfig()
        AddCombo2(ConnStrMasTer, Me.cboUser, "Mas_User", "FUll_Name", "User_ID", "", "User_ID", "<--เลือกทั้งหมด-->", "User_ID ,  convert(nvarchar(255),User_ID) +  ' : ' +  User_FirstName + ' ' + User_LastName as FUll_Name")
        DTPickerSt.Value = Now.Date
        DTPickerEnd.Value = Now.Date
        TimeIn.Value = Now.ToShortDateString & " " & "00:00:00"
        TimeOut.Value = Now.ToShortDateString & " " & "23:59:59"
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
            ' Header_Report = Header_Report
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
            CTR_Viewer.ParameterFieldInfo = MainParaField
            SqlReport.SetDataSource(Dtb_Report)
            CTR_Viewer.ReportSource = SqlReport
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Query_Report()
        Dim Str_Quy As String = ""
        Dim pDtb_Qury As DataTable
        Dim DateSt As DateTime
        Dim DateEnd As DateTime
        DateSt = DTPickerSt.Value.ToShortDateString & " " & TimeIn.Value.ToLongTimeString
        DateEnd = DTPickerEnd.Value.ToShortDateString & " " & TimeOut.Value.ToLongTimeString
        Str_Quy = "Select * from QR_Log_User_Log_In_Out "
        Str_Quy &= " where (Log_Datetime between " & mDB.DBFormatDate(DateSt) & " and " & mDB.DBFormatDate(DateEnd) & ")"
        If cboUser.SelectedIndex > 0 Then Str_Quy &= " and  Log_User_ID = '" & cboUser.SelectedValue & "'"
        Str_Quy &= " order by Log_User_ID,Log_Datetime"
        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrMaster_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_User_Log_In_Out_System
        ShowReport(pDtb_Qury, pHeader_Detail, RPT, DateSt, DateEnd)


    End Sub

    Private Sub btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Show.Click
        btn_Show.Enabled = False
        Query_Report()
        btn_Show.Enabled = True
    End Sub
End Class