

Module mConfig
    Public ConnStrGuidance As String = "" 'Guidance
    Public ConnStrMasTer As String = ""
    Public ConStr_Master As String = ""
    Public ConStr_Guidance As String = ""
    Public ConnStrGuidance_RPT As String = ""
    Public ConnStrMaster_RPT As String = ""
    ' Public ConStrMaster As String = ""
    Public Debug_Mode As Boolean
    Sub Load_AppConfig_NEW()
        ConnStrGuidance = My.Settings.ConnStrGuidance.ToString()
        ConnStrMasTer = My.Settings.ConnStrMaster.ToString()
        ConStr_Master = My.Settings.ConStr_Master.ToString()
        ConnStrGuidance_RPT = My.Settings.ConnStrGuidance_RPT
        ConnStrMaster_RPT = My.Settings.ConnStrMaster_RPT
        ConStr_Guidance = My.Settings.ConStr_Guidance.ToString()
    End Sub
End Module
