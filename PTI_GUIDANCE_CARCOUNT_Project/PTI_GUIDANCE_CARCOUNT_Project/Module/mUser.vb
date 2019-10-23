Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Cryptography.Lib
Imports System.Security.Cryptography

Module mUser
    '  Public mAuthen As New nAuthen.cAuthen

    Function Get_User_Name(ByRef pUser_ID As Object) As String
        On Error GoTo Err
        Get_User_Name = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT User_FirstName FROM Mas_User WHERE User_ID = '" & pUser_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_User_Name = "" & .Fields("User_FirstName").Value
                Else
                    Get_User_Name = pUser_ID
                End If
            End With
        End If



        Exit Function
Err:
        Get_User_Name = pUser_ID
        Call mError.ShowError("mUser", "Get_User_Name", Err.Number, Err.Description)
    End Function

    Function Decrypt_password(ByVal password As String)
        Return CipherUtility.Decrypt(Of AesManaged)(password, "cps10mtl", "salt")
    End Function
    Function Encrypt_password(ByVal password As String)
        'Return CipherUtility.Encrypt(Of AesManaged)(password, "cps10mtl", "salt")
        Return CipherUtility.Encrypt(Of AesManaged)(password, "cps10mtl", "salt")
    End Function
 
    Function Get_User_FullName(ByRef pUser_ID As Object, Optional ByRef pUser_FirsName As String = "", Optional ByRef pUser_LastName As String = "") As String
        On Error GoTo Err
        Get_User_FullName = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT User_FirstName,User_LastName FROM Mas_User WHERE User_ID = '" & pUser_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    pUser_FirsName = "" & .Fields("User_FirstName").Value
                    pUser_LastName = "" & .Fields("User_LastName").Value
                    Get_User_FullName = "" & .Fields("User_FirstName").Value & "  " & .Fields("User_LastName").Value
                Else
                    Get_User_FullName = pUser_ID
                End If
            End With
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing

        Exit Function
Err:

        Call mError.ShowError("mUser", "Get_User_FullName", Err.Number, Err.Description)
        Get_User_FullName = pUser_ID
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing

    End Function

    Function Get_User_ID(ByRef pUser_Name As Object) As String
        On Error GoTo Err
        Get_User_ID = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT User_ID FROM Mas_User WHERE User_Name = '" & pUser_Name & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_User_ID = "" & .Fields("User_ID").Value
                Else
                    Get_User_ID = pUser_Name
                End If
            End With
        End If


        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:

        Call mError.ShowError("mUser", "Get_User_ID", Err.Number, Err.Description)
        Get_User_ID = pUser_Name
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
    End Function

    Function Get_Department_Name(ByVal pID As String) As String
        Get_Department_Name = ""
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        sql = "SELECT * FROM Mas_Department WHERE Dept_ID = '" & pID & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_Department_Name = "" & .Fields("Dept_Name").Value
                Else
                    Get_Department_Name = ""
                End If
            End With
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:

        Call mError.ShowError("mUser", "Get_Department_Name", Err.Number, Err.Description)
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Get_Department_Name = ""

    End Function

    Function Get_Position_Name(ByVal pID As String) As String
        Get_Position_Name = ""
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        sql = "SELECT * FROM Mas_User_Position WHERE Pos_ID = '" & pID & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_Position_Name = "" & .Fields("Pos_Name").Value
                Else
                    Get_Position_Name = ""
                End If
            End With
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:

        Call mError.ShowError("mUser", "Get_Department_Name", Err.Number, Err.Description)
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Get_Position_Name = ""
    End Function

    Function Check_Name_Exist(ByVal pUser_Name As String) As Boolean
        On Error GoTo Err
        Check_Name_Exist = False
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        sql = "SELECT Count(*) FROM Mas_User WHERE User_Name = '" & pUser_Name & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            rs = Conn.Execute(sql)
            If Not rs.Fields(0).Value = 0 Then
                Check_Name_Exist = True
            Else
                Check_Name_Exist = False
            End If
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:

        Call mError.ShowError("mUser", "Check_Name_Exist", Err.Number, Err.Description)
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Check_Name_Exist = False
    End Function

    Function LogIN(ByVal pUser_ID As String) As Boolean
        On Error GoTo Err
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String
        '  [Log_ID]()
        ',[Log_Datetime]
        ',[Log_Station_Name]
        ',[Log_Process_ID]
        ',[Log_Process_Name]
        ',[Log_User_ID]
        ',[Log_Detail]
        ',[IsLog_In]
        sql = " INSERT INTO Transac_Log_System_LogIN("
        sql &= " Log_ID" '1
        sql &= " ,Log_Datetime" '2
        sql &= " ,Log_Station_Name" '3
        sql &= " ,Log_Process_ID" '4
        sql &= " ,Log_Process_Name" '5
        sql &= " ,Log_User_ID" '6
        sql &= " ,Log_Detail )" '7
        sql = sql & "VALUES('" & Format(Now, "yyMMddHHmmss") & CurUser_ID & "'," 'Log_ID
        sql = sql & "" & DBFormatDate(Now) & "," 'Log_Datetime
        sql = sql & "'" & GetComName() & "'," 'Log_Station_Name
        sql = sql & "'CLOSE'," 'Log_Process_ID
        sql = sql & "'CLOSE System'," 'Log_Process_Name
        sql = sql & "'" & CurUser_ID & "'," 'Log_User_ID
        sql = sql & " ' CLOSE System   " & My.Application.Info.AssemblyName & " ' )" ' Log_Detail
        If OpenCnn(ConnStrMasTer, Conn) Then
            With Conn
                .BeginTrans()
                TrnFlg = True
                .Execute(sql)
                .CommitTrans()
                TrnFlg = False
                LogIN = True
            End With
        Else
            If TrnFlg = True Then Conn.RollbackTrans()
            LogIN = False
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:
        Call mError.ShowError("mUser", "LogIN", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()
        LogIN = False

        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
    End Function

    Function LogOut(ByVal pUser_ID As String) As Boolean
        On Error GoTo Err
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String
        sql = " INSERT INTO Transac_Log_System_LogIN(Log_ID,Log_Datetime,Log_Station_Name,Log_Process_ID,Log_Process_Name,Log_User_ID,Log_Detail)"
        sql = sql & "VALUES('" & Format(Now, "yyMMddHHmmss") & pUser_ID & "',"
        sql = sql & "" & DBFormatDate(Now) & ","
        sql = sql & "'" & GetComName() & "',"
        sql = sql & "'0999',"
        sql = sql & "'LOGOUT',"
        sql = sql & "'" & pUser_ID & "',"
        sql = sql & "'" & My.Application.Info.AssemblyName & "')"
        If OpenCnn(ConnStrMasTer, Conn) Then
            With Conn
                .BeginTrans()
                TrnFlg = True
                .Execute(sql)
                .CommitTrans()
                TrnFlg = False
                LogOut = True
            End With
        Else
            If TrnFlg = True Then Conn.RollbackTrans()
            LogOut = False
        End If

        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:
        Call mError.ShowError("mUser", "LogIN", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()
        LogOut = False

        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        End
    End Function


    Function Log_User_Process(ByRef pUser_ID As String, ByRef pLog_Process_ID As String, ByRef pLog_Process_Name As String, _
                                  ByRef pDetail As String, ByRef pForm As String, ByRef pMenuID As String, ByRef pRef_Type As String, _
                                  ByRef pRef_ID As String, Optional ByVal pMem_Code As String = Nothing, Optional ByVal pTickNo As String = Nothing, _
                                  Optional ByVal pCarID As String = Nothing, Optional ByVal pTickType As Integer = 0) As Boolean
        On Error GoTo Err
        Dim TrnFlg As Boolean
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = " INSERT INTO Transac_Log_User_Process(Log_ID,Log_Datetime,Log_Station_Name,Log_Process_ID,Log_Process_Name, "
        sql = sql & " Log_From_Name,Log_User_ID,Log_Ref_Type,Log_Ref_ID,Log_Menu_ID,Log_Detail,Log_TickNo,Log_Memcode,Log_CarID,Log_TickType)"

        sql = sql & "VALUES('" & Format(Now, "yyMMddHHmmss") & pUser_ID & "',"
        sql = sql & "" & DBFormatDate(Now) & ","
        sql = sql & "'" & GetComName() & "',"
        sql = sql & "'" & pLog_Process_ID & "',"
        sql = sql & "'" & Get_Log_Name(pLog_Process_ID) & "',"
        sql = sql & "'" & pForm & "',"
        sql = sql & "'" & pUser_ID & "',"
        sql = sql & "'" & pRef_Type & "',"
        sql = sql & "'" & pRef_ID & "',"
        sql = sql & "'" & pMenuID & "',"
        sql = sql & "'" & pDetail & "',"

        sql = sql & "'" & pTickNo & "',"
        sql = sql & "'" & pMem_Code & "',"
        sql = sql & "'" & pCarID & "',"
        sql = sql & "'" & pTickType & "')"




        If OpenCnn(ConnStrMasTer, Conn) Then 'ConnStrMasTer
            With Conn
                .BeginTrans()
                TrnFlg = True
                .Execute(sql)
                .CommitTrans()
                TrnFlg = False
                Log_User_Process = True
            End With
        Else
            If TrnFlg = True Then Conn.RollbackTrans()
            Log_User_Process = False
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing

        Exit Function
Err:
        Call mError.ShowError("mDB", "Log_User_Process", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()
        Log_User_Process = False

        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
    End Function
    Function Guidance_Log_User_Process(ByRef pUser_ID As String, _
                                       ByRef Log_Station_Name As String, _
                                       ByRef Log_Process_Name As String, _
                                       ByRef Log_From_Name As String, _
                                       ByRef Log_Detail As String) As Boolean
        Try
            Dim sql As String = ""

            sql = sql & " INSERT INTO [Transac_Log_User_Process]"
            sql = sql & " ([Log_ID]"
            sql = sql & " ,[Log_Date]"
            sql = sql & " ,[Log_Datetime]"
            sql = sql & " ,[Log_User_ID]"
            sql = sql & " ,[Log_Station_Name]"
            sql = sql & " ,[Log_Process_Name]"
            sql = sql & " ,[Log_From_Name]"
            sql = sql & " ,[Log_Detail])"

            sql = sql & " VALUES('" & Format(Now, "yyyyMMddHHmmss") & pUser_ID & "'"
            sql = sql & "," & DBFormatDate(CDate(Now).ToShortDateString) & ""
            sql = sql & "," & DBFormatDate(Now) & ""
            sql = sql & ",'" & pUser_ID & "'"
            sql = sql & ",'" & Log_Station_Name & "'"
            sql = sql & ",'" & Log_Process_Name & "'"
            sql = sql & ",'" & Log_From_Name & "'"
            sql = sql & ",'" & Log_Detail & "'"
            sql = sql & ")"
            Excute_SQL(ConStr_Master, sql)
            Return True
        Catch ex As Exception
            Return False
            Call mError.ShowError("mDB", "Log_User_Process", Err.Number, Err.Description)
        End Try


    End Function
    Function Get_LayOutID(ByVal pLayOut_Name As String) As String
        On Error GoTo Err
        Get_LayOutID = ""
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "SELECT * FROM  [Mas_Print_Layout] WHERE [LayOutName] = '" & pLayOut_Name & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_LayOutID = "" & .Fields("MenuID").Value
                Else
                    Get_LayOutID = ""
                End If
            End With
        End If
        If Get_LayOutID = "" Then MsgBox("Report Layout For  " & pLayOut_Name & " Still Null Configuration ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Exit Function

Err:
        Get_LayOutID = ""
        Call mError.ShowError("mRptPrint", "Get_LayOutID", Err.Number, Err.Description)
    End Function

End Module