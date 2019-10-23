
Module mValible
    Public Time_Parking_Alert As String = "" 'ตัวแปลแจ้งเตือนจำนวนชั่วโมงกำจอดเกิน ที่ระบบกำหนด

    Public Public_Floor_NO As String = "" ' ตัวแปรกับค่าชั้น
    Public Public_Building_ID As String = ""
    Public Public_Floor_ID As String = ""
    Public Public_Size_X As Integer
    Public Public_Size_Y As Integer
    Public Path_Export As String = "" ' พาร์ทส่งออก Config ข้อมูลสำหรับแสดงผลป้าย
    Public Drive As String = "" ' Drive ในการเขียนไฟล์
    Public ConnStrMsg As String = ""
    Public nComPort As String, nBuffer As String, nSetting As String
    Public nNext_Send_Sum As Date

    'Public mAuthen As New nAuthen.cAuthen

    Public Cur_Tower_Name As String
    Public Cur_Tower_Location As String
    Public Cur_Tower_Tax As String
    Public Cur_Tower_Tel As String
    Public Cur_Tower_Fax As String
    Public Cur_Tower_ID As String
    Public Path As String

    Public ConnStrREPORT_RPT As String

    Public Delete_MSG As Boolean
    Public Delete_Alam As Boolean

    Public Check_Policy As Boolean

    Public Main_Terminal As String

    Public IsUse_Century As Boolean

    Public IsAUTO_PRINTING As Boolean
    Public IsSHOW_PRINT_PREVIEW As Boolean
    Public IsSHOW_PRINT_DIALOG As Boolean
    Public IsSHOW_REPORT_FETURE_WHEN_CLICK As Boolean

    Public Main_LANG As String = "EN"
    Public LANG_FILE As String = Main_LANG & ".lng"


    '\\Var Encode
    Public DEFULT_USER As String
    Public DEFULT_PWD As String
    Public DEFULT_Encrypt As String


    Public PathRpt As String
    Public Report_Path As String = ""
    Public Export_Path As String = ""



    Public AppPath As String
    Public PictMenuPath As String
    Public Collect_Form As Collection
    Public Menu_Mode As Short
    Public IsLog_Process As Boolean
    Public IsLog_LogIN As Boolean
    Public IsLog_LogOUT As Boolean
    Public Auto_UPDATE_Expire As Boolean
    Public Type_Prepiad As String
    Public Topup_Limit As Integer

    Public Setting_Mode As Boolean
    Public IsOntop_Mode As Boolean
    Public IsAutoSize_Mode As Boolean
    Public IsAutoHideMainMenu_Mode As Boolean

    Public IsSHOW_CARCOUNT As Boolean

    Public myP_ID As String = ""
    Public myP_Name As String = ""
    Public myP_Address As String = ""
    Public myP_Phone As String = ""
    Public myP_Fax As String = ""
    Public myP_URL As String = ""
    Public myP_Mail As String = ""
    Public myP_Slogan As String = ""
    Public myP_Detail As String = ""
    Public myP_TAX_0 As String = ""
    Public myP_TAX_1 As String = ""
    Public Date_Q_Report As String
    Public Station_Exit As String = ""
    Public Station As String = ""
    Public T_Bath As String = ""
    Public Report_ID As String = ""
    Public LogID As String = ""
    Public Tower_ID As String = ""
    Public Log_Date As String = ""
    Public Aling_Vat_Original As String = ""
    Public Print_Address As String = ""
    Public Calculate_Again As String = ""

    Public HandHelp As String = ""

    Public aVal As String = ""

    'Public DT_find As DataTable
End Module
