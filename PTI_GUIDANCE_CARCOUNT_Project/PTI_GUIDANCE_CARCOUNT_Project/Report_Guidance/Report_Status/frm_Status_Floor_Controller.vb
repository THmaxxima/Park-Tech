Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class frm_Status_Floor_Controller
    Dim ClsSqlCmd As New ClassCommandSql
    Friend pHeader_Detail As String
    Private Sub frm_Status_Floor_Controller_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mMain.Load_AppConfig()
        AddCombo2(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "FUll_Name", "Building_ID", "", "Building_ID", "<--เลือกทั้งหมด-->", "Building_ID ,  convert(nvarchar(255),Building_ID) +  ' : ' +  Building_Name  as FUll_Name")
        AddCombo2(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "FUll_Name", "Floor_No", "", "Building_ID,Floor_No", "<--เลือกทั้งหมด-->", "Floor_No ,  convert(nvarchar(255),Building_ID) + '  ' +  convert(nvarchar(255),Floor_No) +  ' : ' +  Floor_Name  as FUll_Name")
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
            'If DateEnd.Length <= 10 Then
            '    DateEnd = DateEnd & " 23:59:59"
            'End If
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

        Str_Quy = "Select * from QR_Status_Floor_Controller "
        Str_Quy &= " where ID > 0"
        If cmb_Building.SelectedIndex > 0 Then Str_Quy &= " and  Building_ID = '" & cmb_Building.SelectedValue & "'"
        If cmb_Floor.SelectedIndex > 0 Then Str_Quy &= " and  Floor_No = '" & cmb_Floor.SelectedValue & "'"
        If rdo_OffLine.Checked = True Then Str_Quy &= " and  Floor_Controller_Status = 0"
        If rdo_OnLine.Checked = True Then Str_Quy &= " and  Floor_Controller_Status = 1"
        Str_Quy &= " order by ID" ',Tower_ID,Building_ID,Floor_No,Floor_Controller_ID,Floor_Controller_No
        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrMaster_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_Status_Floor_Controller
        ShowReport(pDtb_Qury, pHeader_Detail, RPT, CDate(Now).ToShortDateString, "")

    End Sub

    Private Sub btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Show.Click
        btn_Show.Enabled = False
        Query_Report()
        btn_Show.Enabled = True
    End Sub
End Class