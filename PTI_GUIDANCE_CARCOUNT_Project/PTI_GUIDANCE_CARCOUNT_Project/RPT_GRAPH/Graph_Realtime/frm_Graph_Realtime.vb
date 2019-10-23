Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports System.Data.SqlClient
Public Class frm_Graph_Realtime
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
            ' Header_Report = Header_Report
            '#### HeaderReport
            paraHeaderReport.ParameterFieldName = "HeaderReport"
            DisCreatValue_ = New ParameterDiscreteValue
            DisCreatValue_.Value = pHeader_Detail
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

        Str_Quy = "Select * from QR_GRAPH_REALTIME "
        Str_Quy &= " order by HW_Building_ID,HW_Floor_No"

        pDtb_Qury = ClsSqlCmd.ReturnDatatable_(ConnStrGuidance_RPT, Str_Quy)

        Dim RPT As Object
        If rdo_Bar.Checked = True Then
            RPT = New BAR_RPT_GRAPH_IN_OUT_REALTIME
            ShowReport(pDtb_Qury, pHeader_Detail, RPT, CDate(Now).ToShortDateString, "")
        End If
        If rdo_Line.Checked = True Then
            RPT = New LINE_RPT_GRAPH_IN_OUT_REALTIME
            ShowReport(pDtb_Qury, pHeader_Detail, RPT, CDate(Now).ToShortDateString, "")
        End If
        If rdo_Pie.Checked = True Then
            RPT = New PIE_RPT_GRAPH_IN_OUT_REALTIME
            ShowReport(pDtb_Qury, pHeader_Detail, RPT, CDate(Now).ToShortDateString, "")
        End If

    End Sub

    Private Sub frm_Graph_Realtime_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Enabled = False
    End Sub

    Private Sub frm_Graph_Realtime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
    End Sub

    Private Sub frm_Graph_Realtime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Query_Report()
        Timer1.Enabled = True
    End Sub

    Private Sub rdo_Line_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_Line.CheckedChanged
        Query_Report()
    End Sub

    Private Sub rdo_Bar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_Bar.CheckedChanged
        Query_Report()
    End Sub

    Private Sub rdo_Pie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_Pie.CheckedChanged
        Query_Report()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Query_Report()
    End Sub
End Class