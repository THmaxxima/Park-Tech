Module mDB_New
    'ตรวจสอบค่า Null
    Function ChkIsDBNULL(ByVal nValue As Object, ByVal nDefault As Object)
        If IsDBNull(nValue) = False Then
            Return nValue
        Else
            Return nDefault
        End If
    End Function
    'ตรวจสอบค่า ว่าง
    Function ChkIsStrNull(ByVal nValue As Object, ByVal nDefault As Object)
        If IsDBNull(nValue) = False Then
            If CStr(nValue) = "" Then
                Return nDefault
            Else
                Return nValue
            End If
        Else
            Return nDefault
        End If
      
    End Function
    'Get_CheckField  ที่ต้องการ
    Function Get_CheckField(ByVal strConnecTion As String, ByVal VarTableName As String, ByVal varCondition As String) As Boolean
        On Error GoTo Err
        Get_CheckField = False
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = " Select * From " & VarTableName & " where " & varCondition
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF And .BOF) Then
                    Get_CheckField = True
                Else
                    Get_CheckField = False
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        Exit Function
Err:
        Call mError.ShowError("mDB_New", "Get_CheckField", Err.Number, Err.Description)
    End Function


    'Get_CheckField  ที่ต้องการ ตามคำสั่ง SQl ที่ส่งมา
    Function Get_CheckField(ByVal strConnecTion As String, ByVal strCommand As String) As Boolean
        On Error GoTo Err
        Get_CheckField = False
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = strCommand
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF And .BOF) Then
                    Get_CheckField = True
                Else
                    Get_CheckField = False
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        Exit Function
Err:
        Call mError.ShowError("mDB_New", "Get_CheckField", Err.Number, Err.Description)
    End Function
    'ตรวจสอบเงื่อนไขที่ส่งมา
    Function Get_Field(ByVal strConnecTion As String, ByVal VarTableName As String, ByVal varCondition As String, ByVal varFieldReturn As String) As Object
        On Error GoTo Err
        Get_Field = ""
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = " Select * From " & VarTableName & " where " & varCondition
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF) Then
                    Get_Field = .Fields(varFieldReturn).Value
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        Exit Function
Err:
        Call mError.ShowError("mDB_New", "Get_Field", Err.Number, Err.Description)
    End Function
    Function Get_Field_As_Select(ByVal strConnecTion As String, ByVal varCondition As String) As Object
        On Error GoTo Err
        Get_Field_As_Select = ""
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = varCondition
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF) Then
                    Get_Field_As_Select = .Fields(0).Value
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        Exit Function
Err:
        Call mError.ShowError("mDB_New", "Get_Field_As_Select", Err.Number, Err.Description)
    End Function
    'ตรวจสอบเงื่อนไขที่ส่งมา ตามคำสั่ง SQL
    Function Get_Field(ByVal strConnecTion As String, ByVal strCommand As String, ByVal varFieldReturn As String) As Object
        On Error GoTo Err
        Get_Field = ""
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = strCommand
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF) Then
                    .MoveFirst()
                    Get_Field = .Fields(varFieldReturn).Value
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        strCommand = ""
        varFieldReturn = ""
        Exit Function
Err:
    End Function


    'ตรวจสอบเงื่อนไขที่ส่งมา
    Function Get_Field(ByVal strConnecTion As String, ByVal VarTableName As String, ByVal varCondition As String, ByVal varFieldReturn As String, ByVal IsShow_Msg As Boolean) As Object
        On Error GoTo Err
        Get_Field = ""
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = " Select * From " & VarTableName & " where " & varCondition
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF) Then
                    Get_Field = .Fields(varFieldReturn).Value
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        Exit Function
Err:
        If IsShow_Msg = True Then Call mError.ShowError("mDB_New", "Get_Field", Err.Number, Err.Description)
    End Function
    'ตรวจสอบเงื่อนไขที่ส่งมา ตามคำสั่ง SQL
    Function Get_Field(ByVal strConnecTion As String, ByVal strCommand As String, ByVal varFieldReturn As String, ByVal IsShow_Msg As Boolean) As Object
        On Error GoTo Err
        Get_Field = ""
        Dim Conn As New ADODB.Connection, rsClient As New ADODB.Recordset, Sql As String = ""
        Sql = strCommand
        If OpenCnn(strConnecTion, Conn) Then
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(Sql)
                If Not (.EOF) Then
                    .MoveFirst()
                    Get_Field = .Fields(varFieldReturn).Value
                End If
            End With
        End If
        Conn = Nothing
        rsClient = Nothing
        Exit Function
Err:
        If IsShow_Msg = True Then Call mError.ShowError("mDB_New", "Get_Field", Err.Number, Err.Description)
    End Function

    Function RunSqlQury(ByVal strConnecTion As String, ByVal varQury As String) As Boolean
        'On Error GoTo Err
        RunSqlQury = False
        Dim Conn As New ADODB.Connection, Sql As String
        Sql = varQury
        If OpenCnn(strConnecTion, Conn) Then
            With Conn
                .BeginTrans()
                .Execute(Sql)
                .CommitTrans()
                RunSqlQury = True
            End With
        End If
        Conn = Nothing
        'Exit Function
        'Err:
        '       If RunSqlQury = False Then Conn.RollbackTrans()
        '      Call mError.ShowError("mDB_New", "RunSqlQury", Err.Number, Err.Description)
    End Function
    '    Public Sub AddCombo(ByVal StrConnection As String, ByVal ComboName As ComboBox, ByVal StrTableName As String, ByVal StrFieldDisplay As String, ByVal StrFieldValue As String, ByVal StrCondition As String, ByVal FieldOrderBy As String, ByVal StrLabel_0 As String)
    '        On Error GoTo Err
    '        'ComboName.Items.Clear()
    '        Dim DataSetVariable As New DataSet
    '        Dim T_Col1 As New DataColumn(StrFieldValue, System.Type.GetType("System.String"))
    '        Dim T_Col2 As New DataColumn(StrFieldDisplay, System.Type.GetType("System.String"))
    '        Dim T_Row As DataRow
    '        Dim T_Table As New DataTable(StrTableName)
    '        T_Table.Columns.Add(T_Col1)
    '        T_Table.Columns.Add(T_Col2)
    '        T_Row = T_Table.NewRow()
    '        T_Row(StrFieldValue) = ""
    '        T_Row(StrFieldDisplay) = StrLabel_0
    '        T_Table.Rows.Add(T_Row)
    '        '################
    '        Dim ConnClient As New ADODB.Connection, rsClient As New ADODB.Recordset, SqlClient As String = ""
    '        If StrCondition = "" Then
    '            SqlClient = " Select * From " & StrTableName & "  order by " & FieldOrderBy
    '        Else
    '            SqlClient = " Select * From " & StrTableName & " where " & StrCondition & " order by " & FieldOrderBy
    '        End If

    '        If OpenCnn(StrConnection, ConnClient) Then
    '            With rsClient
    '                If .State = 1 Then .Close()
    '                .let_ActiveConnection(ConnClient)
    '                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
    '                .LockType = ADODB.LockTypeEnum.adLockOptimistic
    '                .Open(SqlClient)
    '                If .RecordCount > 0 Then
    '                    If Not (.EOF And .BOF) Then
    '                        .MoveFirst()
    '                        Do While Not .EOF
    '                            T_Row = T_Table.NewRow()
    '                            T_Row(StrFieldValue) = .Fields(StrFieldValue).Value
    '                            T_Row(StrFieldDisplay) = .Fields(StrFieldDisplay).Value
    '                            T_Table.Rows.Add(T_Row)
    '                            .MoveNext()
    '                        Loop
    '                    End If
    '                End If
    '            End With
    '        End If
    '        ComboName.DataSource = T_Table
    '        ComboName.ValueMember = StrFieldValue
    '        ComboName.DisplayMember = StrFieldDisplay
    '        T_Col1.Dispose()
    '        T_Col2.Dispose()
    '        DataSetVariable.Dispose()
    '        T_Row = Nothing
    '        ConnClient = Nothing
    '        rsClient = Nothing
    '        Exit Sub
    'Err:
    '        Call mError.ShowError("mReadderTable.AddCombo", "AddCombo", Err.Number, Err.Description)
    '    End Sub
    Public Sub AddComboBy_Condition(ByVal StrConnection As String, ByVal ComboName As ComboBox, ByVal StrTableName As String, ByVal StrFieldDisplay As String, ByVal StrFieldValue As String, ByVal StrCondition As String, ByVal FieldOrderBy As String, ByVal StrLabel_0 As String)
        On Error GoTo Err
        '################
        Dim ConnClient As New ADODB.Connection, rsClient As New ADODB.Recordset, SqlClient As String = ""
        SqlClient = " Select * From " & StrTableName & " where " & StrCondition & " order by " & FieldOrderBy
        If OpenCnn(StrConnection, ConnClient) Then
            ComboName.Items.Clear()
            With rsClient
                If .State = 1 Then .Close()
                .let_ActiveConnection(ConnClient)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(SqlClient)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    Do While Not .EOF
                        ComboName.Items.Add(.Fields(StrFieldDisplay).Value & ":" & .Fields(StrFieldValue).Value)
                        .MoveNext()
                    Loop
                End If
            End With
        End If
        ConnClient = Nothing
        rsClient = Nothing
        Exit Sub
Err:
        Call mError.ShowError("mReadderTable.AddComboLike", "AddComboLike", Err.Number, Err.Description)
    End Sub
    Function Get_Run_ID(ByVal strConn As String, ByVal nTable As String, ByVal strCondition As String, ByVal nOrderby As String, ByVal nField_Return As String) As String
        On Error GoTo Err
        Get_Run_ID = ""
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        If OpenCnn(strConn, Conn) Then
            If strCondition = "" Then
                sql = " SELECT TOP 1 " & nField_Return & " FROM " & nTable & " ORDER BY " & nOrderby & " DESC "
            Else
                sql = " SELECT TOP 1 " & nField_Return & " FROM " & nTable & " WHERE " & strCondition & " ORDER BY " & nOrderby & " DESC "
            End If
               With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    Get_Run_ID = "" & Format(.Fields(nField_Return).Value + 1, "0")
                Else
                    Get_Run_ID = 1
                End If
            End With
        End If
        If rs.State = 1 Then rs.Close() : Conn = Nothing : rs = Nothing
        Exit Function
Err:
        Call mError.ShowError("mDB_New", "Get_Run_ID", Err.Number, Err.Description)
    End Function
End Module
