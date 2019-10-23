Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class frm_RPT_Status_Sensor_History
    Dim ClsSqlCmd As New ClassCommandSql
    Dim cdb As New CDatabase
    Friend pHeader_Detail As String

    Private Sub frm_RPT_Status_Sensor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'mMain.Load_AppConfig()
        AddCombo2(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "FUll_Name", "Building_ID", "", "Building_ID", "<--เลือกทั้งหมด-->", "Building_ID ,  convert(nvarchar(255),Building_ID) +  ' : ' +  Building_Name  as FUll_Name")
        AddCombo2(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "FUll_Name", "Floor_No", "", "Building_ID,Floor_No", "<--เลือกทั้งหมด-->", "Floor_No ,  convert(nvarchar(255),Building_ID) + '  ' +  convert(nvarchar(255),Floor_No) +  ' : ' +  Floor_Name  as FUll_Name")
        AddCombo2(ConnStrMasTer, Me.cmb_FloorController, "Mas_Floor_Controller", "FUll_Name", "Floor_Controller_ID", "", "Floor_Controller_ID", "<--เลือกทั้งหมด-->", "Floor_Controller_ID ,  convert(nvarchar(255),Floor_Controller_ID) +  ' : ' +  Floor_Controller_Name  as FUll_Name")
        DT_St.Value = Now.Date
        DT_End.Value = Now
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

        Str_Quy = "Select * from  V_Mas_UD_Error_History"

        'Str_Quy = "SELECT MTL_MASTER_GUIDANCE.dbo.Mas_Tower.Tower_Name, MTL_MASTER_GUIDANCE.dbo.Mas_Building_Parking.Building_Name, "
        'Str_Quy &= "MTL_MASTER_GUIDANCE.dbo.Mas_Floor.Floor_Name, dbo.Mas_UD_Error_History.HW_Lot_Name, dbo.Mas_UD_Error_History.HW_Datetime_Update "
        'Str_Quy &= "FROM  dbo.Mas_UD_Error_History INNER JOIN "
        'Str_Quy &= "MTL_MASTER_GUIDANCE.dbo.Mas_Building_Parking ON "
        'Str_Quy &= "dbo.Mas_UD_Error_History.HW_Building_ID = MTL_MASTER_GUIDANCE.dbo.Mas_Building_Parking.Building_ID INNER JOIN "
        'Str_Quy &= "MTL_MASTER_GUIDANCE.dbo.Mas_Tower ON dbo.Mas_UD_Error_History.HW_Tower_ID = MTL_MASTER_GUIDANCE.dbo.Mas_Tower.Tower_ID INNER JOIN "
        'Str_Quy &= "MTL_MASTER_GUIDANCE.dbo.Mas_Floor ON dbo.Mas_UD_Error_History.HW_Floor_No = MTL_MASTER_GUIDANCE.dbo.Mas_Floor.Floor_No AND "
        'Str_Quy &= "dbo.Mas_UD_Error_History.HW_Building_ID = MTL_MASTER_GUIDANCE.dbo.Mas_Floor.Building_ID "



        Str_Quy &= " where HW_Position_X <> 0 and HW_Position_Y <> 0"
        If cmb_Building.SelectedIndex > 0 Then Str_Quy &= " and  HW_Building_ID = '" & cmb_Building.SelectedValue & "'"
        If cmb_Floor.SelectedIndex > 0 Then Str_Quy &= " and  HW_Floor_No = '" & cmb_Floor.SelectedValue & "'"
        If cmb_FloorController.SelectedIndex > 0 Then Str_Quy &= " and  HW_Floorcontroller_Id = '" & cmb_FloorController.SelectedValue & "'"
        If rdo_OffLine.Checked = True Then Str_Quy &= " and  HW_On_Line = 0"
        If rdo_OnLine.Checked = True Then Str_Quy &= " and  HW_On_Line = 1"

        If CheckBox1.Checked = True Then
            Str_Quy &= " and  HW_Datetime_Update BETWEEN '" & cdb.GetDateToDB(DT_St.Value) & "' and '" & cdb.GetDateToDB(DT_End.Value) & "'"
        End If

        Str_Quy &= " order by HW_Lot_Id"
        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrGuidance_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_Status_Sensor_History
        If CheckBox1.Checked = True Then
            ShowReport(pDtb_Qury, pHeader_Detail, RPT, DT_St.Value, DT_End.Value)
        Else
            ShowReport(pDtb_Qury, pHeader_Detail, RPT, "-", "-")
        End If
    End Sub

    Private Sub btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Show.Click
        btn_Show.Enabled = False
        Call Query_Report()
        btn_Show.Enabled = True
    End Sub
End Class