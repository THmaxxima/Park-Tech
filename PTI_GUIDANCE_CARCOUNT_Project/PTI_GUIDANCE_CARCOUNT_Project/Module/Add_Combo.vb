Module Add_Combo
    Public Sub AddCombo(ByVal StrConnection As String, ByVal ComboName As ComboBox, ByVal StrTableName As String, ByVal StrFieldDisplay As String, ByVal StrFieldValue As String, ByVal StrCondition As String, ByVal FieldOrderBy As String, ByVal StrLabel_0 As String)
        'On Error GoTo Err
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
            SqlClient = " Select * From " & StrTableName & "  order by " & FieldOrderBy
        Else
            SqlClient = " Select * From " & StrTableName & " where " & StrCondition & " order by " & FieldOrderBy
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
        Call mError.ShowError("Add_Combo", "AddCombo", Err.Number, Err.Description)
    End Sub


End Module
