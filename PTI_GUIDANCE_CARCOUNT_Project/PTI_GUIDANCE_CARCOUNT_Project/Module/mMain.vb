Option Explicit On
'Option Strict On
Imports System.Threading
Imports Microsoft.VisualBasic.Compatibility
Module mMain
    Public MyAppName As String = My.Application.Info.ProductName
    Public IsLogIN_Mode As Boolean
    Public IsSetting_Mode As Boolean
    Public Config_Path As String = My.Application.Info.DirectoryPath & "\MTL_Guidance.ini"
    Public Config_Path_Visitor As String = My.Application.Info.DirectoryPath & "\MTL_Visitor.ini"
    Public Alert_Path As String = My.Application.Info.DirectoryPath & "\AlertMessage.ini"
    Public Lang_Path As String = My.Application.Info.DirectoryPath & "\LANG\"
    Public Menu_Config_Path As String = My.Application.Info.DirectoryPath & "\MENUCONFIG.ini"
    Public Picture_Path As String = My.Application.Info.DirectoryPath & "\Picture"
    Public ShellList_Path As String = My.Application.Info.DirectoryPath & "\ShellList.ini"


   
    Sub Load_Form_trans(ByVal f As Form)

        Dim d As Double
        For d = 0 To 1 + 0.2 Step 0.2
            System.Threading.Thread.Sleep(20)
            Application.DoEvents()
            f.Opacity = d
            f.Refresh()
        Next d

    End Sub

    Sub Close_Form_trans(ByVal f As Form)

        Dim d As Double
        For d = 1 To 0 + 0.2 Step -0.2
            System.Threading.Thread.Sleep(20)
            Application.DoEvents()
            f.Opacity = d
            f.Refresh()
        Next d

    End Sub
   

    Sub Main()
        'mAuthen = CreateObject("nAuthen.cAuthen")
        DEFULT_PWD = "1234"
        DEFULT_Encrypt = "N"
        Call Load_AppConfig()
        'frmLogin.Show()


    End Sub
 
    Sub Load_AppConfig()

        Dim aVal As String = ""
        DEFULT_PWD = "1234"
        DEFULT_Encrypt = "N"

        If Get_Config("DATABASECONFIG", "ConnStrGuidance", Config_Path, aVal) Then ConnStrGuidance = aVal
        If Get_Config("DATABASECONFIG", "ConStr_Guidance", Config_Path, aVal) Then ConStr_Guidance = aVal

        If Get_Config("DATABASECONFIG", "ConnStrMaster", Config_Path, aVal) Then ConnStrMasTer = aVal
        If Get_Config("DATABASECONFIG", "ConStr_Master", Config_Path, aVal) Then ConStr_Master = aVal

        If Get_Config("EXPORT", "Path_Export", Config_Path, aVal) Then Path_Export = aVal
        If Get_Config("EXPORT", "Drive", Config_Path, aVal) Then Drive = aVal
        '

        '## Report
        If Get_Config("DATABASECONFIG", "ConnStrGuidance_RPT", Config_Path, aVal) Then ConnStrGuidance_RPT = aVal
        If Get_Config("DATABASECONFIG", "ConnStrMaster_RPT", Config_Path, aVal) Then ConnStrMaster_RPT = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrStamp_RPT", Config_Path, aVal) Then ConnStrStamp_RPT = aVal
        If Get_Config("DATABASECONFIG", "ConnStrREPORT_RPT", Config_Path, aVal) Then ConnStrREPORT_RPT = aVal

        'ConStrCarlog
        'ConStrMaster
        '**************  Station_Exit
        If Get_Config("DATABASECONFIG", "Station_Exit", Config_Path, aVal) Then Station_Exit = aVal
        If Get_Config("DATABASECONFIG", "Aling_Vat_Original ", Config_Path, aVal) Then Aling_Vat_Original = aVal
        If Get_Config("DATABASECONFIG", "Print_Address ", Config_Path, aVal) Then Print_Address = aVal
        If Get_Config("DATABASECONFIG", "Calculate_Again ", Config_Path, aVal) Then Calculate_Again = aVal
        If Get_Config("DATABASECONFIG", "HandHelp ", Config_Path, aVal) Then HandHelp = aVal

        '#####  Delete Massage and Alam
        'Public Delete_MSG As Boolean
        'Public Delete_Alam As Boolean
        If Get_Config("DATABASECONFIG", "Delete_MSG", Config_Path, aVal) Then Delete_MSG = aVal
        If Get_Config("DATABASECONFIG", "Delete_Alam", Config_Path, aVal) Then Delete_Alam = aVal

        If Get_Config("DATABASECONFIG", "Check_Policy", Config_Path, aVal) Then Check_Policy = aVal
        'Check_Policy
        '################
        If Get_Config("ERRORCONFIG", "SHOWTHAI_ERR", Config_Path, aVal) Then mError.isThaiErr = CBool(aVal)
        If Get_Config("ERRORCONFIG", "SHOW_ERR", Config_Path, aVal) Then mError.isShowMsgBox = CBool(aVal)
        If Get_Config("ERRORCONFIG", "WRITE_ERR", Config_Path, aVal) Then mError.isWriteErr = CBool(aVal)
        If Get_Config("APPCONFIG", "DEFULT_USER", Config_Path, aVal) Then DEFULT_USER = aVal Else DEFULT_USER = "9999"
        If Get_Config("APPCONFIG", "DEBUG_MODE", Config_Path, aVal) Then IsDebug_Mode = CBool(aVal)
        If IsDebug_Mode Then CurUser_ID = DEFULT_USER
        If Get_Config("APPCONFIG", "MAIN_TERMINAL", Config_Path, aVal) Then Main_Terminal = aVal
        If Get_Config("APPCONFIG", "MAIN_LANG", Config_Path, aVal) Then Main_LANG = aVal : LANG_FILE = Main_LANG & ".lng"
        If Get_Config("DATABASECONFIG", "ConnStrMaster", Config_Path, aVal) Then ConnStrMasTer = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrPicture", Config_Path, aVal) Then ConnStrPicture = aVal
        'If Get_Config("DATABASECONFIG", "ConnStrTransac", Config_Path, aVal) Then ConnStrTransac = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrESTAMP", Config_Path, aVal) Then ConnStrEStamp = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrEClient", Config_Path, aVal) Then ConnStrEClient = aVal

        If Get_Config("CONFIGPATH", "REPORTPATH", Config_Path, aVal) Then Report_Path = aVal
        If Get_Config("CONFIGPATH", "EXPORTPATH", Config_Path, aVal) Then Export_Path = aVal

        If Get_Config("APPCONFIG", "IsLog_Process", Config_Path, aVal) Then IsLog_Process = CBool(aVal)
        If Get_Config("APPCONFIG", "IsLog_LogIN", Config_Path, aVal) Then IsLog_LogIN = CBool(aVal)
        If Get_Config("APPCONFIG", "IsLog_LogOUT", Config_Path, aVal) Then IsLog_LogOUT = CBool(aVal)
        If Get_Config("APPCONFIG", "DEBUG_MODE", Config_Path, aVal) Then Debug_Mode = CBool(aVal)
        If Get_Config("APPCONFIG", "MAIN_TERMINAL", Config_Path, aVal) Then Main_Terminal = aVal
        If Get_Config("APPCONFIG", "AUTOSIZE_MODE", Config_Path, aVal) Then IsAutoSize_Mode = CBool(aVal)
        If Get_Config("APPCONFIG", "MAIN_LANG", Config_Path, aVal) Then Main_LANG = aVal Else Main_LANG = "EN"
        '# SUTON
        If Get_Config("APPCONFIG", "SET_APPLICATION", Config_Path, aVal) Then SET_APPLICATION = aVal

        '\\Printing
        If Get_Config("REPORT", "AUTO_PRINTING", Config_Path, aVal) Then IsAUTO_PRINTING = CBool(aVal)
        If Get_Config("REPORT", "SHOW_PRINT_PREVIEW", Config_Path, aVal) Then IsSHOW_PRINT_PREVIEW = CBool(aVal)
        If Get_Config("REPORT", "SHOW_PRINT_DIALOG", Config_Path, aVal) Then IsSHOW_PRINT_DIALOG = CBool(aVal)


        '\\Prepiad
        If Get_Config("PREPIAD", "Auto_UPDATE_Expire", Config_Path, aVal) Then Auto_UPDATE_Expire = CBool(aVal)
        If Get_Config("PREPIAD", "TYPE_PREPIAD", Config_Path, aVal) Then Type_Prepiad = aVal
        If Get_Config("PREPIAD", "TOPUP_LIMIT", Config_Path, aVal) Then Topup_Limit = aVal


        '\\Tool
        If Get_Config("ERRORCONFIG", "WRITE_ERR", Config_Path, aVal) Then isWriteErr = CBool(aVal)
        If Get_Config("ERRORCONFIG", "SHOW_ERR", Config_Path, aVal) Then isShowMsgBox = CBool(aVal)
        If Get_Config("ERRORCONFIG", "SHOWTHAI_ERR", Config_Path, aVal) Then isThaiErr = CBool(aVal)
        '\\READER
        '   If Get_Config("READERCONFIG", "PORT_NO", Config_Path, aVal) Then aPORT_NO = aVal


        '#############
        If IsUse_Century And Year(Now) > 2500 Then Today = DateAdd(DateInterval.Year, -543, Now)

    End Sub

    Sub Load_AppConfigNew()

        Dim aVal As String = ""
        DEFULT_PWD = "1234"
        DEFULT_Encrypt = "N"
        If Get_Config("DATABASECONFIG", "ConnStrMaster", Config_Path, aVal) Then ConnStrMasTer = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrTransac", Config_Path, aVal) Then ConnStrTransac = aVal
        '  If Get_Config("DATABASECONFIG", "ConnStrCarlog", Config_Path, aVal) Then ConnStrCarLog = aVal

        '## Report
        '   If Get_Config("DATABASECONFIG", "ConnStrCarlog_RPT", Config_Path, aVal) Then ConnStrCarlog_RPT = aVal
        If Get_Config("DATABASECONFIG", "ConnStrMaster_RPT", Config_Path, aVal) Then ConnStrMaster_RPT = aVal
        '   If Get_Config("DATABASECONFIG", "ConnStrStamp_RPT", Config_Path, aVal) Then ConnStrStamp_RPT = aVal
        'If Get_Config("DATABASECONFIG", "ConnStrcustomer", Config_Path, aVal) Then ConnStrcustomer = aVal


        '**************  Station_Exit
        If Get_Config("DATABASECONFIG", "Station_Exit", Config_Path, aVal) Then Station_Exit = aVal
        If Get_Config("DATABASECONFIG", "Aling_Vat_Original ", Config_Path, aVal) Then Aling_Vat_Original = aVal
        If Get_Config("DATABASECONFIG", "Print_Address ", Config_Path, aVal) Then Print_Address = aVal
        If Get_Config("DATABASECONFIG", "Calculate_Again ", Config_Path, aVal) Then Calculate_Again = aVal
        If Get_Config("DATABASECONFIG", "HandHelp ", Config_Path, aVal) Then HandHelp = aVal

        '################
        If Get_Config("ERRORCONFIG", "SHOWTHAI_ERR", Config_Path, aVal) Then mError.isThaiErr = CBool(aVal)
        If Get_Config("ERRORCONFIG", "SHOW_ERR", Config_Path, aVal) Then mError.isShowMsgBox = CBool(aVal)
        If Get_Config("ERRORCONFIG", "WRITE_ERR", Config_Path, aVal) Then mError.isWriteErr = CBool(aVal)
        If Get_Config("APPCONFIG", "DEFULT_USER", Config_Path, aVal) Then DEFULT_USER = aVal Else DEFULT_USER = "9999"
        If Get_Config("APPCONFIG", "DEBUG_MODE", Config_Path, aVal) Then IsDebug_Mode = CBool(aVal)
        If IsDebug_Mode Then CurUser_ID = DEFULT_USER
        If Get_Config("APPCONFIG", "MAIN_TERMINAL", Config_Path, aVal) Then Main_Terminal = aVal
        If Get_Config("APPCONFIG", "MAIN_LANG", Config_Path, aVal) Then Main_LANG = aVal : LANG_FILE = Main_LANG & ".lng"
        If Get_Config("DATABASECONFIG", "ConnStrMaster", Config_Path, aVal) Then ConnStrMasTer = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrPicture", Config_Path, aVal) Then ConnStrPicture = aVal
        'If Get_Config("DATABASECONFIG", "ConnStrTransac", Config_Path, aVal) Then ConnStrTransac = aVal
        '  If Get_Config("DATABASECONFIG", "ConnStrESTAMP", Config_Path, aVal) Then ConnStrEStamp = aVal
        ' If Get_Config("DATABASECONFIG", "ConnStrEClient", Config_Path, aVal) Then ConnStrEClient = aVal

        If Get_Config("CONFIGPATH", "REPORTPATH", Config_Path, aVal) Then Report_Path = aVal
        If Get_Config("CONFIGPATH", "EXPORTPATH", Config_Path, aVal) Then Export_Path = aVal

        If Get_Config("APPCONFIG", "IsLog_Process", Config_Path, aVal) Then IsLog_Process = CBool(aVal)
        If Get_Config("APPCONFIG", "IsLog_LogIN", Config_Path, aVal) Then IsLog_LogIN = CBool(aVal)
        If Get_Config("APPCONFIG", "IsLog_LogOUT", Config_Path, aVal) Then IsLog_LogOUT = CBool(aVal)
        If Get_Config("APPCONFIG", "DEBUG_MODE", Config_Path, aVal) Then Debug_Mode = CBool(aVal)
        If Get_Config("APPCONFIG", "MAIN_TERMINAL", Config_Path, aVal) Then Main_Terminal = aVal
        If Get_Config("APPCONFIG", "AUTOSIZE_MODE", Config_Path, aVal) Then IsAutoSize_Mode = CBool(aVal)
        If Get_Config("APPCONFIG", "MAIN_LANG", Config_Path, aVal) Then Main_LANG = aVal Else Main_LANG = "EN"
        '# SUTON
        If Get_Config("APPCONFIG", "SET_APPLICATION", Config_Path, aVal) Then SET_APPLICATION = aVal

        '\\Printing
        If Get_Config("REPORT", "AUTO_PRINTING", Config_Path, aVal) Then IsAUTO_PRINTING = CBool(aVal)
        If Get_Config("REPORT", "SHOW_PRINT_PREVIEW", Config_Path, aVal) Then IsSHOW_PRINT_PREVIEW = CBool(aVal)
        If Get_Config("REPORT", "SHOW_PRINT_DIALOG", Config_Path, aVal) Then IsSHOW_PRINT_DIALOG = CBool(aVal)


        '\\Prepiad
        If Get_Config("PREPIAD", "Auto_UPDATE_Expire", Config_Path, aVal) Then Auto_UPDATE_Expire = CBool(aVal)
        If Get_Config("PREPIAD", "TYPE_PREPIAD", Config_Path, aVal) Then Type_Prepiad = aVal
        If Get_Config("PREPIAD", "TOPUP_LIMIT", Config_Path, aVal) Then Topup_Limit = aVal


        '\\Tool
        If Get_Config("ERRORCONFIG", "WRITE_ERR", Config_Path, aVal) Then isWriteErr = CBool(aVal)
        If Get_Config("ERRORCONFIG", "SHOW_ERR", Config_Path, aVal) Then isShowMsgBox = CBool(aVal)
        If Get_Config("ERRORCONFIG", "SHOWTHAI_ERR", Config_Path, aVal) Then isThaiErr = CBool(aVal)
        '\\READER
        '   If Get_Config("READERCONFIG", "PORT_NO", Config_Path, aVal) Then aPORT_NO = aVal


        '#############
        If IsUse_Century And Year(Now) > 2500 Then Today = DateAdd(DateInterval.Year, -543, Now)

    End Sub

    Function Get_Alert_Msg(ByVal pModule As String, ByVal pMsg_ID As String, Optional ByVal pStdMsg As String = "") As String
        Dim aVal As String = ""
        If Get_Config(pModule, pMsg_ID, Alert_Path, aVal) Then
            Return aVal
        End If
        Return pStdMsg
        Exit Function
Err:
        Return pStdMsg
    End Function


    Function Write_Log(ByVal pMsg As String) As Boolean

        Dim aFile As String = "", msg As String = ""
        Dim aFree As Integer

        If Dir(My.Application.Info.DirectoryPath & "\Log", FileAttribute.Directory) = "" Then MkDir((My.Application.Info.DirectoryPath & "\LOG"))
        aFile = My.Application.Info.DirectoryPath & "\Log\" & Format(Now(), "yyyy_MM") & ".LOG"
        aFree = FreeFile()
        FileOpen(aFree, aFile, OpenMode.Append)
        Do While Not EOF(aFree) : Loop
        PrintLine(aFree, Format(Now(), "dd-MM-yyyy HH:mm:ss") & " : " & pMsg)
        FileClose(aFree)

    End Function

    Function Get_Array(ByVal pString As String, ByVal pDelimiter As String, ByVal pArr As Integer) As String
        On Error GoTo Err
        Dim a As Object, i As Integer
        a = Split(pString, pDelimiter)
        Get_Array = a(pArr)
        Exit Function
Err:
        Get_Array = ""
        Call mError.ShowError("mMain", "Get_Array", Err.Number, Err.Description)
    End Function
    Function Get_Array(ByVal pString As String, ByVal pDelimiter As String, ByVal pArr As Integer, ByVal nAlert As Boolean) As String
        On Error GoTo Err
        Get_Array = ""
        Dim a As Object, i As Integer

        a = Split(pString, pDelimiter)
        Get_Array = a(pArr)
        Exit Function
Err:
        Get_Array = ""
        If nAlert = False Then Exit Function
        Call mError.ShowError("mMain", "Get_Array_NoAlert", Err.Number, Err.Description)
    End Function
    Function GetComName() As String
        Dim a As Integer
        Dim aBuff As New VB6.FixedLengthString(255)
        a = mAPI.GetComputerName(aBuff.Value, 250)
        If a > 0 Then
            GetComName = Left(aBuff.Value, InStr(aBuff.Value, Chr(0)) - 1)
        Else
            GetComName = "<ERROR> : " & Err.Description
        End If

    End Function

    Function Count_Array(ByVal pString As String, ByVal pDelimiter As String, Optional ByVal pArr As Integer = 0) As Long
        On Error GoTo Err
        Dim a As Object, i As Integer

        a = Split(pString, pDelimiter)
        Count_Array = UBound(a)
        Exit Function
Err:
        Count_Array = 0
        Call mError.ShowError("mMain", "Count_Array", Err.Number, Err.Description)
    End Function


    Function LoadListMenu(ByRef pApp As String, ByRef pForm As String, ByRef pMenu As String) As Boolean
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim sql As String


        sql = " Select * from User_Authen_Group where User_ID = '" & CurUser_ID & "'"
        sql = sql & " AND Applicate_Name = '" & pApp & "'"
        sql = sql & " AND Group_Name = '" & pMenu & "'"
        '    sql = sql & " AND Menu_ID = '" & "0001" & "'"

        If OpenCnn(ConnStrMasTer, ConnMenu) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(ConnMenu)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    If .Fields("Permit").Value = 1 Then
                        LoadListMenu = True
                    Else
                        LoadListMenu = False
                    End If
                Else
                    LoadListMenu = False

                End If
            End With
        End If
        Exit Function
Err_Renamed:
        Call mError.ShowError("mAuthen", "LoadListMenu", Err.Number, Err.Description)

    End Function

    Function Clear_All_Text_InForm(ByVal f As Form) As Boolean
        For Each ctl As Control In f.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = String.Empty
            End If
        Next
    End Function

    Function IsPermit(ByRef pUser_ID As String, ByRef pMenu_Group_ID As String, ByRef pMenu_ID As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT Can_Open FROM User_Authen WHERE User_ID = '" & pUser_ID & "'"
            sql = sql & " AND Menu_Group_ID = '" & pMenu_Group_ID & "'"
            sql = sql & " AND Menu_ID = '" & pMenu_ID & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("Can_Open").Value = 1 Then
                        IsPermit = True
                    Else
                        IsPermit = False
                    End If
                Else
                    IsPermit = False
                End If
            End With
        Else
            IsPermit = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsPermit", Err.Number, Err.Description)
        IsPermit = False
    End Function
    Function IsGroup_Menu_Permit(ByRef pUser_ID As String, ByRef pMenu_Group_ID As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT Can_Open FROM User_Authen WHERE User_ID = '" & pUser_ID & "'"
            sql = sql & " AND Menu_Group_ID = '" & pMenu_Group_ID & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    If .Fields("Can_Open").Value = 1 Then
                        IsGroup_Menu_Permit = True
                    Else
                        IsGroup_Menu_Permit = False
                    End If
                Else
                    IsGroup_Menu_Permit = False
                End If
            End With
        Else
            IsGroup_Menu_Permit = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsPermit", Err.Number, Err.Description)
        IsGroup_Menu_Permit = False
    End Function
    Function IsMenu_Accept(ByRef pMenu_Group_ID As String, ByRef pMenu_Name As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT IsCommit FROM [Mas_Menu] "
            sql = sql & " WHERE Menu_Group_ID = '" & pMenu_Group_ID & "'"
            sql = sql & " AND Menu_Name = '" & pMenu_Name & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("IsCommit").Value = 1 Then
                        IsMenu_Accept = True
                    Else
                        IsMenu_Accept = False
                    End If
                Else
                    IsMenu_Accept = False
                End If
            End With
        Else
            IsMenu_Accept = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsMenu_Accept", Err.Number, Err.Description)
        IsMenu_Accept = False
    End Function


    Function IsMenu_Permit(ByRef pUser_ID As String, ByRef pMenu_Group_ID As String, ByRef pMenu_Name As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT Can_Open FROM User_Authen WHERE User_ID = '" & pUser_ID & "'"
            sql = sql & " AND Menu_Group_ID = '" & pMenu_Group_ID & "'"
            sql = sql & " AND Menu_Name = '" & pMenu_Name & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("Can_Open").Value = 1 Then
                        IsMenu_Permit = True
                    Else
                        IsMenu_Permit = False
                    End If
                Else
                    IsMenu_Permit = False
                End If
            End With
        Else
            IsMenu_Permit = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsPermit", Err.Number, Err.Description)
        IsMenu_Permit = False
    End Function


    Function IsMenu_Permit_Bylevel(ByRef pLevel As String, ByRef pMenu_ID As String, ByRef pMenu_Name As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT * FROM [Menu_Permit] WHERE [ID] = '" & pMenu_ID & "'"
            sql = sql & " AND User_Level = '" & pLevel & "'"
            sql = sql & " AND Control_Name = 'MENU'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("IsCommit").Value = 1 Then
                        IsMenu_Permit_Bylevel = True
                    Else
                        IsMenu_Permit_Bylevel = False
                    End If
                Else
                    IsMenu_Permit_Bylevel = False
                End If
            End With
        Else
            IsMenu_Permit_Bylevel = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsMenu_Permit_Bylevel", Err.Number, Err.Description)
        IsMenu_Permit_Bylevel = False
    End Function

    Function IsMenu_Permit_Screen_New(ByRef pUser_ID As String, ByRef pMenu_Group_ID As String, ByRef pMenu_Name As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT Can_Open FROM User_Authen WHERE User_ID = '" & pUser_ID & "'"
            'sql = sql & " AND Menu_Group_ID = '" & pMenu_Group_ID & "'"
            sql = sql & " AND Menu_Name = '" & pMenu_Name & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("Can_Open").Value = 1 Then
                        IsMenu_Permit_Screen_New = True
                    Else
                        IsMenu_Permit_Screen_New = False
                    End If
                Else
                    IsMenu_Permit_Screen_New = False
                End If
            End With
        Else
            IsMenu_Permit_Screen_New = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsPermit", Err.Number, Err.Description)
        IsMenu_Permit_Screen_New = False
    End Function
    Function IsMenu_Accept_Screen_New(ByRef pMenu_Name As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT IsCommit FROM [Mas_Menu] "
            sql = sql & " WHERE Menu_Name = '" & pMenu_Name & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("IsCommit").Value = 1 Then
                        IsMenu_Accept_Screen_New = True
                    Else
                        IsMenu_Accept_Screen_New = False
                    End If
                Else
                    IsMenu_Accept_Screen_New = False
                End If
            End With
        Else
            IsMenu_Accept_Screen_New = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mMain", "IsMenu_Accept_Screen_New", Err.Number, Err.Description)
        IsMenu_Accept_Screen_New = False
    End Function
    Function IsReport_Permit(ByRef pUser_ID As String, ByRef pMenu_Group_ID As String, ByRef pMenu_Name As String, ByRef pApp As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT Can_Open FROM Report_Authen WHERE User_ID = '" & pUser_ID & "'"
            'sql = sql & " AND Menu_Group_ID = '" & pMenu_Group_ID & "'"
            sql = sql & " AND Menu_ID = '" & pMenu_Name & "'"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    'If .Fields("Can_Open").Value = 1 Then
                    '    IsReport_Permit = True
                    'Else
                    '    IsReport_Permit = False
                    'End If
                    IsReport_Permit = True
                Else
                    IsReport_Permit = False
                End If
            End With
        Else
            IsReport_Permit = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsReport_Permit", Err.Number, Err.Description)
        IsReport_Permit = False
    End Function

    Function IsReport_Permit_Level(ByRef pLevel As String, ByRef pMenu_ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT * FROM [Menu_Permit] WHERE [ID] = '" & pMenu_ID & "'"
            sql = sql & " AND User_Level = '" & pLevel & "'"
            sql = sql & " AND Control_Name = 'REPORT'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    IsReport_Permit_Level = True
                Else
                    IsReport_Permit_Level = False
                End If
            End With
        Else
            IsReport_Permit_Level = False
        End If

        Conn = Nothing
        rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mAuthen", "IsReport_Permit_Level", Err.Number, Err.Description)
        IsReport_Permit_Level = False
    End Function

End Module
