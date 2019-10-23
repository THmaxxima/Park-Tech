Option Strict Off
Option Explicit On
Imports System.IO.MemoryStream
Imports VB = Microsoft.VisualBasic
Imports ADODB

Module mDB
    ' Public WithEvents MyTmr As Polling.cCassEvent
    Public ConnRpt As New ADODB.Connection
    Public fileINI As String
    'Public ConnStrCarLog As String
    'Public ConnStrPLog As String
    'Public ConnStrCustomer As String
    'Public ConnStrRate As String
    'Public ConnStrEStamp As String

    ' Public ConnStrTransac As String

    ' Public ConnStrEClient As String

    '##### VISITOR
    ' Public ConnStrVisitor As String
    ' Public ConnStrCarpark_Client As String
    '##############

    'Public rs As New ADODB.Recordset
    'Public Conn As New ADODB.Connection
    'Public ConnPlog As New ADODB.Connection
    'Public ConnCarLog As New ADODB.Connection
    'Public ConnRate As New ADODB.Connection
    'Public ConnCustomer As New ADODB.Connection
    'Public ConnEStamp As New ADODB.Connection
    Public ConnMaster As New ADODB.Connection
    Public ConnUser As New ADODB.Connection
    Public ConnGuidance As New ADODB.Connection 'Connection GuiDance
    Public strConn As String
    Public ConnMenu As New ADODB.Connection
    'Public ConnTicket As New ADODB.Connection
    'Public ConnMember As New ADODB.Connection
    'Public ConnCollumn As New ADODB.Connection
    '  Public ConnCar As New ADODB.Connection
    Public ConnImage As New ADODB.Connection
    'Public ConnClient_Transac As New ADODB.Connection
    'Public ConnClient_TMaster As New ADODB.Connection
    Public ConnStrClnMasTer As String = ""
    ' Public ConnStrClnTransac As String = ""

    ' Public ConnStrMaster As String = "" 'Master
    Public Floor_Name As String = ""
    Public Select_Lot_ID As String = ""
    'SUTON  ใช้ตรวจสอบว่า มีการ ส่งข้อมูลหรือไม่
    Public BitSendData As Boolean = False
    'SUTON ตรวจสอบว่า จะ SET เป็น APPLICATION แบบใหน 'SET_APPLICATION   0=ALL,1=CARPARK_ONLY,2=VISITOR_ONLY
    Public SET_APPLICATION As Short = 0
    Function GetServerDate() As Date
        Dim rs As New ADODB.Recordset, Conn As New ADODB.Connection
        Dim sql As String
        Dim i As Short
        On Error GoTo Err_GetSeverDate
        sql = "select convert(datetime,getdate(),103)"
        If OpenCnn(strConn, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                GetServerDate = CDate("" & .Fields(i).Value)
                .Close()
                rs = Nothing

            End With
        End If
        Exit Function
Err_GetSeverDate:
        Call mError.ShowError("mDB", "Function_GetSeverDate", Err.Number, Err.Description)
    End Function

    Function Get_MyServerDate(Optional ByVal pConnstr As String = "") As Date
        Dim rs As New ADODB.Recordset, Conn As New ADODB.Connection
        Dim sql As String
        Dim i As Short
        On Error GoTo Err
        sql = "select convert(datetime,getdate(),120)"
        If pConnstr = "" Then pConnstr = ConnStrMasTer
        If OpenCnn(pConnstr, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                Get_MyServerDate = CDate("" & .Fields(i).Value)
                If IsUse_Century And Get_MyServerDate.Year > 2500 Then Get_MyServerDate = DateAdd(DateInterval.Year, -543, Get_MyServerDate)
                .Close()
                rs = Nothing
            End With
        Else
            Get_MyServerDate = Now
            If IsUse_Century And Year(Get_MyServerDate) > 2500 Then Get_MyServerDate = DateAdd(DateInterval.Year, -543, Get_MyServerDate)
        End If
        Exit Function
Err:

        Call mError.ShowError("mDB", "Get_MyServerDate", Err.Number, Err.Description)
    End Function

    Function DBFormatDate(ByRef dt As Date) As String
        On Error GoTo Err
        dt = Format(dt, "dd/MM/yyyy HH:mm:ss")
        Dim nYY As String = ""
        Dim nMM As String = ""
        Dim nDD As String = ""
        Dim nHH As String = ""
        Dim nMN As String = ""
        Dim nSS As String = ""
        If dt.Year > 2500 Then dt = DateAdd(DateInterval.Year, -543, dt)
        nYY = Format(dt.Year, "0000") : nMM = Format(dt.Month, "00") : nDD = Format(dt.Day, "00")
        nHH = Format(dt.Hour, "00") : nMN = Format(dt.Minute, "00") : nSS = Format(dt.Second, "00")
        'If nYY > 2500 Then dt = DateAdd("y", -543, dt)
        DBFormatDate = "Convert(datetime,'" & nYY & "-" & nMM & "-" & nDD & " " & nHH & ":" & nMN & ":" & nSS & "',120)"
        Exit Function
Err:
        Call mError.ShowError("mDB", "DBFormatDate", Err.Number, Err.Description)
    End Function


    Function DBFormat(ByRef dt As Date) As String
        On Error GoTo Err
        Dim nYY As String = ""
        Dim nMM As String = ""
        Dim nDD As String = ""
        Dim nHH As String = ""
        Dim nMN As String = ""
        Dim nSS As String = ""

        'nYY = Format(Year(dt), "0000") : nMM = Format(Month(dt), "00") : nDD = Format(dt.Day, "00")
        'nHH = Format(Hour(dt), "00") : nMN = Format(Minute(dt), "00") : nSS = Format(Second(dt), "00")
        'If nYY > 2500 Then dt = DateAdd("y", -543, dt)
        If Year(dt) > "2500" Then dt = DateAdd("y", -543, dt)
        DBFormat = "Convert(datetime,'" & Format(dt, "yyyy/MM/dd") & "',120)"
        'DBFormat = "Convert(datetime,'" & nYY & "-" & nMM & "-" & nDD & " " & nHH & ":" & nMN & ":" & nSS & "',120)"
        Exit Function
Err:
        Call mError.ShowError("mDB", "DBFormat", Err.Number, Err.Description)

    End Function
    Function OpenCnn(ByRef str_Renamed As String, ByRef Cnn As ADODB.Connection) As Boolean
        On Error GoTo Err_OpenCnn
        With Cnn
            If .State = 1 Then .Close()
            .ConnectionString = str_Renamed
            .ConnectionTimeout = 15
            .Open()
            OpenCnn = True
        End With
        Exit Function
Err_OpenCnn:
        OpenCnn = False
        Call mError.WriteError("mDB", "OpenCnn", Err.Number, Err.Description)
    End Function
    Function OpenCnn(ByRef str_Renamed As String, ByRef Cnn As ADODB.Connection, ByVal IsShow As Boolean) As Boolean
        On Error GoTo Err_OpenCnn
        With Cnn
            If .State = 1 Then .Close()
            .ConnectionString = str_Renamed
            .ConnectionTimeout = 15
            .Open()
            OpenCnn = True
        End With
        Exit Function
Err_OpenCnn:
        OpenCnn = False
        If IsShow = True Then Call mError.WriteError("mDB", "OpenCnn", Err.Number, Err.Description)
    End Function
    Function Build_Connection() As String

        Build_Connection = vbNullChar
        Dim sActivity, pwd As String
        Dim dl As Object
        Dim cnADO As Object = Nothing

        Const DDadStateClosed As Short = 0
        'On Error Resume Next
        On Error GoTo Err
        sActivity = "Creating Datalinks object."
        dl = CreateObject("DataLinks")
        sActivity = "DataLinks object created, prompting user."

        If Not cnADO Is Nothing Then
            cnADO = Nothing
        End If

        sActivity = "Prompting user for connect string"
        cnADO = dl.PromptNew()


        Build_Connection = cnADO.ConnectionString
        If Not Build_Connection = "" Then
            pwd = InputBox("Enter Password for Login to Database")
            If pwd <> "" Then Build_Connection = Build_Connection & ";PWD=" & pwd & ";"
        End If
        cnADO = Nothing
        dl = Nothing

        Exit Function
Err:

        Dim sMsg As String

        sMsg = "Error while building connection string. "
        sMsg = sMsg & vbCrLf & "Ext.Info:Source=[" & Err.Source & "] "
        sMsg = sMsg & vbCrLf & "Desc=[" & Err.Description & "]"
        sMsg = sMsg & vbCrLf & "Number=[" & CStr(Err.Number) & "]"
        sMsg = sMsg & vbCrLf & "The Error While [" & sActivity & "]"

        Call MsgBox(sMsg, MsgBoxStyle.Critical, "BuildConnectString Failed")
        'System.Windows.Forms.Cursor.Current(0)
        'Call mError.ShowError("mDB", "BuildConnection", Err.Number, Err.Description)

    End Function

    Function Get_Log_Name(ByRef pLog_Process_ID As String) As String
        On Error GoTo Err
        Get_Log_Name = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT mLog_Name FROM Mas_Log_ID WHERE mLog_ID = '" & pLog_Process_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_Log_Name = .Fields("mLog_Name").Value
                Else
                    Get_Log_Name = pLog_Process_ID
                End If
            End With
        End If


        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Log_Name = pLog_Process_ID

        Call mError.ShowError("mDB", "Get_Log_Name", Err.Number, Err.Description)
    End Function

    Function Load_Pict_To_Image(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pImage As System.Windows.Forms.PictureBox) As Boolean
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rsPict As New ADODB.Stream
        Dim sql As String

        sql = " SELECT " & pPict_Fields & " FROM " & pTable & " WHERE " & pFields & " = '" & pKey & "'"
        If OpenCnn(pConnStr, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If Not (IsDBNull(.Fields(pPict_Fields).Value)) Then
                        rsPict.Type = ADODB.StreamTypeEnum.adTypeBinary
                        rsPict.Open()
                        rsPict.Write(rs.Fields(pPict_Fields))
                        rsPict.SaveToFile(My.Application.Info.DirectoryPath & "\Temp\Ptmp_Load.jpg", ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
                        If rsPict.Size > 0 Then
                            pImage.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\Temp\Ptmp_Load.jpg")
                            Kill(My.Application.Info.DirectoryPath & "\Temp\Ptmp_Load.jpg")
                            pImage.Visible = True
                            Load_Pict_To_Image = True
                        Else
                            pImage.Visible = False
                            Load_Pict_To_Image = True
                        End If
                    Else
                        pImage.Visible = False
                        Load_Pict_To_Image = False
                    End If
                Else
                    .Close()
                    pImage.Visible = False
                    Load_Pict_To_Image = False
                    Exit Function
                End If

            End With
        Else
            pImage.Visible = False
            Load_Pict_To_Image = False

        End If

        Conn = Nothing
        rs = Nothing
        rsPict = Nothing
        Exit Function
Err_Renamed:
        Load_Pict_To_Image = False
        Call mError.ShowError("mDB", "Load_Pict_To_Image", Err.Number, Err.Description)
    End Function



    Function Save_Pict_To_DB(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pFileName As String) As Boolean
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rsPict As New ADODB.Stream
        Dim sql As String

        sql = " SELECT *  FROM " & pTable & " WHERE " & pFields & " = " & pKey & ""
        If OpenCnn(pConnStr, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(sql)
                If Not (rs.EOF And rs.BOF) Then
                    rsPict.Type = ADODB.StreamTypeEnum.adTypeBinary
                    rsPict.Open()
                    rsPict.LoadFromFile(pFileName)
                    .Fields(pPict_Fields).Value = rsPict.Read
                    If MsgBox("คุณต้องการบันทึก ภาพนี้ใช่ หรือ ไม่ ?..", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes Then
                        .Update()
                        rsPict.Close()
                        Save_Pict_To_DB = True
                    Else
                        Save_Pict_To_DB = False
                        Exit Function
                    End If
                Else
                    .Close()
                    Save_Pict_To_DB = False
                    Exit Function
                End If
            End With
        Else
            Save_Pict_To_DB = False

        End If


        Conn = Nothing
        rs = Nothing
        rsPict = Nothing
        Exit Function
Err_Renamed:
        Save_Pict_To_DB = False
        Call mError.ShowError("ฐานข้อมูล", "บันทึกรปภาพ ลงฐานข้อมูล", Err.Number, Err.Description)
    End Function
    Function Save_Pict_To_DB_No_Message(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pFileName As String) As Boolean
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rsPict As New ADODB.Stream
        Dim sql As String
        Save_Pict_To_DB_No_Message = False
        If pFileName <> "0" Then
            sql = " SELECT *  FROM " & pTable & " WHERE " & pFields & " = " & pKey & ""
            If OpenCnn(pConnStr, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .LockType = ADODB.LockTypeEnum.adLockOptimistic
                    .Open(sql)
                    If Not (rs.EOF And rs.BOF) Then
                        rsPict.Type = ADODB.StreamTypeEnum.adTypeBinary
                        rsPict.Open()
                        rsPict.LoadFromFile(pFileName)
                        .Fields(pPict_Fields).Value = rsPict.Read
                        .Update()
                        rsPict.Close()
                        Save_Pict_To_DB_No_Message = True
                    Else
                        .Close()
                        Save_Pict_To_DB_No_Message = False
                        Exit Function
                    End If
                End With
            Else
                Save_Pict_To_DB_No_Message = False

            End If
        End If
        
        Conn = Nothing
        rs = Nothing
        rsPict = Nothing
        Exit Function
Err_Renamed:
        Save_Pict_To_DB_No_Message = False
        Call mError.ShowError("ฐานข้อมูล", "บันทึกรปภาพ ลงฐานข้อมูล", Err.Number, Err.Description)
    End Function
    Function Load_Pict_To_File(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pFileName As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rsPict As New ADODB.Stream
        Dim sql As String

        sql = " SELECT " & pPict_Fields & " FROM " & pTable & " WHERE " & pFields & " = '" & pKey & "'"
        If OpenCnn(pConnStr, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If Not IsDBNull(.Fields(pPict_Fields).Value) Then
                        rsPict.Open()
                        rsPict.Write(.Fields(pPict_Fields).Value)
                        If rsPict.Size > 0 Then
                            rsPict.SaveToFile(My.Application.Info.DirectoryPath & "\Temp\Ptmp_Load.jpg", ADODB.SaveOptionsEnum.adSaveCreateOverWrite)
                            Load_Pict_To_File = True
                        Else
                            Load_Pict_To_File = False
                        End If
                    Else
                        Load_Pict_To_File = False
                    End If
                Else
                    .Close()
                    Load_Pict_To_File = False
                    Exit Function
                End If

            End With
        Else
            Load_Pict_To_File = False

        End If

        Conn = Nothing
        rs = Nothing
        rsPict = Nothing
        Exit Function
Err:
        Load_Pict_To_File = False
        Call mError.ShowError("mDB", "Load_Pict_To_File", Err.Number, Err.Description)
    End Function



    Public Function Load_Pict_To_Byte(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pImage As System.Windows.Forms.PictureBox) As Boolean
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        Dim adoCommand As New ADODB.Command
        Dim adoRecordset As New ADODB.Recordset
        sql = " SELECT " & pPict_Fields & " FROM " & pTable & " WHERE " & pFields & " = '" & pKey & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    If Not VB.IsDBNull(.Fields(pPict_Fields).Value) Then
                        Dim RetByte() As Byte = CType(.Fields(pPict_Fields).Value, Byte())
                        Dim PictureData() As Byte = RetByte
                        Dim Ms As New System.IO.MemoryStream(PictureData)
                        pImage.Image = Image.FromStream(Ms)
                        Load_Pict_To_Byte = True
                    Else
                        Dim RetByte() As Byte = {0}
                        pImage.Image = pImage.ErrorImage
                        Load_Pict_To_Byte = False
                    End If
                End If
            End With

        End If
        Exit Function
Err_Renamed:
        Load_Pict_To_Byte = False
        Call mError.ShowError("mDB", "Load_Pict_To_Byte", Err.Number, Err.Description)
    End Function


    Function CK_Table_Exist(ByVal CnnStr As String, ByVal pTable_Name As String, Optional ByRef pCreate_Date As String = "", Optional ByRef pObj_ID As String = "") As Boolean
        Dim rs As New ADODB.Recordset, Conn As New ADODB.Connection
        Dim sql As String
        Dim i As Short
        On Error GoTo Err
        sql = "SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo]." & pTable_Name & "') AND type in (N'U')"
        If OpenCnn(CnnStr, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(sql)
                If .RecordCount > 0 Then
                    pCreate_Date = "" & .Fields("Create_date").Value
                    pObj_ID = "" & .Fields("object_ID").Value
                    CK_Table_Exist = True
                Else
                    CK_Table_Exist = False
                End If
                .Close()
                rs = Nothing
            End With
        End If
        Exit Function
Err:
        Call mError.ShowError("mDB", "CK_Table_Exist", Err.Number, Err.Description)
        CK_Table_Exist = False
    End Function

    Function Get_Table_Record_Count(ByVal CnnStr As String, ByVal pTable_Name As String) As Long
        Dim rs As New ADODB.Recordset, Conn As New ADODB.Connection
        Dim sql As String
        Dim i As Short
        On Error GoTo Err
        sql = "SELECT Count(*) FROM " & pTable_Name
        If OpenCnn(CnnStr, Conn) Then
            rs = Conn.Execute(sql)
            Get_Table_Record_Count = "" & rs.Fields(0).Value
        End If
        Exit Function
Err:
        Call mError.ShowError("mDB", "Get_Table_Record_Count", Err.Number, Err.Description)
        Get_Table_Record_Count = 0
    End Function


    Function Get_Schema_Name(ByVal CnnStr As String, ByVal pSchema_ID As String, ByVal pSchema_Name As String) As Boolean
        Dim rs As New ADODB.Recordset, Conn As New ADODB.Connection
        Dim sql As String
        Dim i As Short
        On Error GoTo Err
        sql = "select * from sys.schemas WHERE Schema_id = '" & pSchema_ID & "'"
        If OpenCnn(CnnStr, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(sql)
                If .RecordCount > 0 Then
                    pSchema_Name = "" & .Fields("Name").Value

                    Get_Schema_Name = True
                Else
                    Get_Schema_Name = False
                End If
                .Close()
                rs = Nothing
            End With
        End If
        Exit Function
Err:
        Call mError.ShowError("mDB", "Get_Schema_Name", Err.Number, Err.Description)
        Get_Schema_Name = False
    End Function

    Sub Load_DB()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(sql)
                If Not (.EOF And .BOF) Then

                Else

                End If
            End With

        End If

        If rs.State = 1 Then rs.Close()
        Conn = Nothing : rs = Nothing

        Exit Sub
Err:
        Call mError.ShowError("mDB", "Load_DB", Err.Number, Err.Description)

    End Sub
    Public Sub AddCombo2(ByVal StrConnection As String, ByVal ComboName As ComboBox, ByVal StrTableName As String, ByVal StrFieldDisplay As String, ByVal StrFieldValue As String, ByVal StrCondition As String, ByVal FieldOrderBy As String, ByVal StrLabel_0 As String, ByVal Field_Select As String)
        On Error GoTo Err
        'ComboName.Items.Clear()
        Dim DataSetVariable As New DataSet
        Dim T_Col1 As New DataColumn(StrFieldValue, System.Type.GetType("System.String"))
        Dim T_Col2 As New DataColumn(StrFieldDisplay, System.Type.GetType("System.String"))
        Dim T_Row As DataRow
        Dim T_Table As New DataTable(StrTableName)
        T_Table.Columns.Add(T_Col1)
        T_Table.Columns.Add(T_Col2)
        T_Row = T_Table.NewRow()
        T_Row(StrFieldValue) = ""
        T_Row(StrFieldDisplay) = StrLabel_0
        T_Table.Rows.Add(T_Row)
        '################
        Dim ConnClient As New ADODB.Connection, rsClient As New ADODB.Recordset, SqlClient As String = ""
        If StrCondition = "" Then
            SqlClient = " Select " & Field_Select & " From " & StrTableName & "  order by " & FieldOrderBy
        Else
            SqlClient = " Select " & Field_Select & " From " & StrTableName & " where " & StrCondition & " order by " & FieldOrderBy
        End If

        If OpenCnn(StrConnection, ConnClient) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(ConnClient)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(SqlClient)
                If .RecordCount > 0 Then
                    If Not (.EOF And .BOF) Then
                        .MoveFirst()
                        Do While Not .EOF
                            T_Row = T_Table.NewRow()
                            T_Row(StrFieldValue) = .Fields(StrFieldValue).Value
                            T_Row(StrFieldDisplay) = .Fields(StrFieldDisplay).Value
                            T_Table.Rows.Add(T_Row)
                            .MoveNext()
                        Loop
                    End If
                End If
            End With
        End If
        ComboName.DataSource = T_Table
        ComboName.ValueMember = StrFieldValue
        ComboName.DisplayMember = StrFieldDisplay
        T_Col1.Dispose()
        T_Col2.Dispose()
        DataSetVariable.Dispose()
        T_Row = Nothing
        ConnClient = Nothing
        rsClient = Nothing
        Exit Sub
Err:
        Call mError.ShowError("mReadderTable.AddCombo", "AddCombo", Err.Number, Err.Description)
    End Sub
    Function Get_Value(ByVal Connection_String As String, ByVal Field As String, ByVal Table As String, ByRef Condition As Object) As String

        Get_Value = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try
            If OpenCnn(Connection_String, Conn) Then
                sql = "SELECT " & Field & " FROM " & Table & " " & Condition
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    If Not (.EOF And .BOF) Then
                        Get_Value = "" & .Fields(0).Value
                    Else
                        Get_Value = "0"
                    End If
                End With
            End If

        Catch ex As Exception
            Call mError.ShowError("mUser", "GetValue", Err.Number, Err.Description)
        End Try
        Return Get_Value

        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
    End Function
End Module