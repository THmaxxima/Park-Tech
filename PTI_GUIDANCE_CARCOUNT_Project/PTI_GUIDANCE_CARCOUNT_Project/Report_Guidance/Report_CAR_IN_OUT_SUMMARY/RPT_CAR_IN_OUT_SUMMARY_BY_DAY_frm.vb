Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class RPT_CAR_IN_OUT_SUMMARY_BY_DAY_frm
    Dim ClsSqlCmd As New ClassCommandSql
    Friend pHeader_Detail As String
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
            paraBuilding.ParameterFieldName = "Building"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = cmb_Building.Text
            paraBuilding.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraBuilding)
            '#### Building
            paraFloor.ParameterFieldName = "Floor"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = cmb_Floor.Text
            paraFloor.CurrentValues.Add(DisCreatValue_)
            MainParaField.Add(paraFloor)
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
    Sub Query_Report_ByFloor()
        Dim Str_Quy As String = ""
        Dim pDtb_Qury As DataTable
        Dim DateSt As DateTime
        Dim DateEnd As DateTime
        DateSt = DTPickerSt.Value.ToShortDateString & " " & TimeIn.Value.ToLongTimeString
        DateEnd = DTPickerEnd.Value.ToShortDateString & " " & TimeOut.Value.ToLongTimeString

        Str_Quy = "Select * from VQR_CAR_IN_OUT_SUMMARY_BY_DAY_BY_FLOOR "
        Str_Quy &= " where (Trn_Log_Date between " & mDB.DBFormatDate(DateSt) & " and " & mDB.DBFormatDate(DateEnd) & ")"

        If cmb_Tower.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Tower_ID = '" & cmb_Tower.SelectedValue & "'"
        If cmb_Building.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Building_ID = '" & cmb_Building.SelectedValue & "'"
        If cmb_Floor.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Floor_No = '" & cmb_Floor.SelectedValue & "'"

        Str_Quy &= " order by Trn_Tower_ID,Trn_Building_ID,Trn_Floor_No,Trn_Log_Date"

        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrGuidance_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_CAR_IN_OUT_SUMMARY_BY_DAY_BY_FLOOR
        ShowReport(pDtb_Qury, pHeader_Detail, RPT, DateSt, DateEnd)

    End Sub
    Sub Query_Report_ByBuilding()
        Dim Str_Quy As String = ""
        Dim pDtb_Qury As DataTable
        Dim DateSt As DateTime
        Dim DateEnd As DateTime
        DateSt = DTPickerSt.Value.ToShortDateString & " " & TimeIn.Value.ToLongTimeString
        DateEnd = DTPickerEnd.Value.ToShortDateString & " " & TimeOut.Value.ToLongTimeString

        Str_Quy = "Select * from VQR_CAR_IN_OUT_SUMMARY_BY_DAY "
        Str_Quy &= " where (Trn_Log_Date between " & mDB.DBFormatDate(DateSt) & " and " & mDB.DBFormatDate(DateEnd) & ")"

        If cmb_Tower.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Tower_ID = '" & cmb_Tower.SelectedValue & "'"
        If cmb_Building.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Building_ID = '" & cmb_Building.SelectedValue & "'"
        'If cmb_Floor.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Floor_No = '" & cmb_Floor.SelectedValue & "'"

        Str_Quy &= " order by Trn_Tower_ID,Trn_Building_ID,Trn_Log_Date"

        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrGuidance_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_CAR_IN_OUT_SUMMARY_BY_DAY
        ShowReport(pDtb_Qury, pHeader_Detail, RPT, DateSt, DateEnd)

    End Sub
    Sub Query_Report_ByTower()
        Dim Str_Quy As String = ""
        Dim pDtb_Qury As DataTable
        Dim DateSt As DateTime
        Dim DateEnd As DateTime
        DateSt = DTPickerSt.Value.ToShortDateString & " " & TimeIn.Value.ToLongTimeString
        DateEnd = DTPickerEnd.Value.ToShortDateString & " " & TimeOut.Value.ToLongTimeString

        Str_Quy = "Select * from VQR_CAR_IN_OUT_SUMMARY_BY_DAY_TOWER "
        Str_Quy &= " where (Trn_Log_Date between " & mDB.DBFormatDate(DateSt) & " and " & mDB.DBFormatDate(DateEnd) & ")"

        If cmb_Tower.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Tower_ID = '" & cmb_Tower.SelectedValue & "'"
        'If cmb_Building.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Building_ID = '" & cmb_Building.SelectedValue & "'"
        'If cmb_Floor.SelectedIndex > 0 Then Str_Quy &= " and  Trn_Floor_No = '" & cmb_Floor.SelectedValue & "'"

        Str_Quy &= " order by Trn_Tower_ID,Trn_Log_Date"

        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrGuidance_RPT, Str_Quy)
        Dim RPT As Object
        RPT = New RPT_CAR_IN_OUT_SUMMARY_BY_DAY_TOWER
        ShowReport(pDtb_Qury, pHeader_Detail, RPT, DateSt, DateEnd)

    End Sub
    Private Sub RPT_CAR_IN_OUT_SUMMARY_BY_DAY_frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_Floor.Enabled = False
        AddCombo(ConnStrMasTer, Me.cmb_Tower, "Mas_Tower", "Tower_Name", "Tower_ID", "", "Tower_Name", "ทั้งหมด")
        AddCombo2(ConnStrMasTer, Me.cmb_Building, "Mas_Building_Parking", "FUll_Name", "Building_ID", "", "Building_ID", "<--เลือกทั้งหมด-->", "Building_ID ,  convert(nvarchar(255),Building_ID) +  ' : ' +  Building_Name  as FUll_Name")
        DTPickerSt.Value = Now.Date
        DTPickerEnd.Value = Now.Date
        TimeIn.Value = Now.ToShortDateString & " " & "00:00:00"
        TimeOut.Value = Now.ToShortDateString & " " & "23:59:59"
    End Sub

    Private Sub btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Show.Click
        btn_Show.Enabled = False
        If cmb_Floor.SelectedIndex > 0 Then
            Call Query_Report_ByFloor()
        Else
            If cmb_Building.SelectedIndex > 0 Then
                Call Query_Report_ByBuilding()
            Else
                Call Query_Report_ByTower()
            End If
        End If
        btn_Show.Enabled = True
    End Sub

    Private Sub cmb_Building_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_Building.SelectedIndexChanged
        If cmb_Building.SelectedIndex <= 0 Then Exit Sub
        AddCombo2(ConnStrMasTer, Me.cmb_Floor, "Mas_Floor", "FUll_Name", "Floor_No", " Building_ID = " & cmb_Building.SelectedValue & "", "Building_ID,Floor_No", "<--เลือกทั้งหมด-->", "Floor_No ,  convert(nvarchar(255),Building_ID) + '  ' +  convert(nvarchar(255),Floor_No) +  ' : ' +  Floor_Name  as FUll_Name")
        cmb_Floor.Enabled = True
    End Sub
End Class