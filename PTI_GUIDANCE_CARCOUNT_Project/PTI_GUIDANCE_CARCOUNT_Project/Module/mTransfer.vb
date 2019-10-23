Module mTransfer
    Function Transfer_Data(ByVal From_Table As String, ByVal To_Table As String, ByVal Condition As String) As Boolean

        Try
            Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
            
            Dim ConnClient As New ADODB.Connection, rsClient As New ADODB.Recordset, SqlClient As String = ""

            sql = " Select  *  From " & From_Table & Condition
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs '
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .LockType = ADODB.LockTypeEnum.adLockOptimistic
                    .Open(sql)
                    If OpenCnn(ConnStrGuidance, ConnClient) Then
                        If Not (.EOF And .BOF) Then
                            SqlClient = "select * from " & To_Table ' "Truncate table " & To_Table
                            If rsClient.State = 1 Then rsClient.Close()
                            rsClient.let_ActiveConnection(ConnClient)
                            rsClient.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                            rsClient.CursorType = ADODB.CursorTypeEnum.adOpenStatic
                            rsClient.LockType = ADODB.LockTypeEnum.adLockOptimistic
                            rsClient.Open(SqlClient)
                            Dim i As Integer
                            Do While Not .EOF
                                Dim strWrite As String = ""
                                Dim strLog As String = ""
                                rsClient.AddNew()
                                strLog = " insert into " & To_Table & " Values ("
                                For i = 0 To rsClient.Fields.Count - 1
                                    rsClient.Fields(i).Value = .Fields(i).Value
                                    If i = 0 Then
                                        strLog &= "'" & .Fields(i).Value & "'"
                                    Else
                                        strLog &= ",'" & .Fields(i).Value & "'"
                                    End If
                                Next
                                strLog &= ")"
                                Write_SQL_Log_Transaction(strLog)

                                .MoveNext()
                            Loop
                            rsClient.Update()
                        End If
                    End If
                End With
            End If
            Conn = Nothing
            ConnClient = Nothing
            rs = Nothing
            rsClient = Nothing

        Catch ex As Exception

        End Try
    End Function
    Function Write_SQL_Log_Member(ByVal pMsg As String) As Boolean

        Dim aFile As String = "", msg As String = ""
        Dim aFree As Integer
        Dim Month As String = ""
        Dim Years As String = ""
        If Now.Month = 1 Then
            Month = "12"
            Years = CInt(Now.Year) - 1
        Else
            Month = Now.Month - 1
            Years = Now.Year
        End If

        If Dir(Path, FileAttribute.Directory) = "" Then MkDir((Path))
        aFile = Path & "\Terminal_Transac_" & GenMonth(Now.Hour) & "_" & GenMonth(Now.Day) & "_" & GenMonth(Month) & "_" & Years & ".txt"


        aFree = FreeFile()
        FileOpen(aFree, aFile, OpenMode.Append)
        Do While Not EOF(aFree) : Loop
        PrintLine(aFree, pMsg)
        FileClose(aFree)

    End Function
    Function Write_SQL_Log_Transaction(ByVal pMsg As String) As Boolean

        Dim aFile As String = "", msg As String = ""
        Dim aFree As Integer
        Dim Month As String = ""
        Dim Years As String = ""
        If Now.Month = 1 Then
            Month = "12"
            Years = CInt(Now.Year) - 1
        Else
            Month = Now.Month - 1
            Years = Now.Year
        End If
        Try
            If Dir(Path, FileAttribute.Directory) = "" Then MkDir((Path))
        Catch ex As Exception

        End Try

        aFile = Path & "\Script_Terminal_Transac_" & GenMonth(Now.Hour) & "_" & GenMonth(Now.Day) & "_" & GenMonth(Month) & "_" & Years & ".txt"

        aFree = FreeFile()
        FileOpen(aFree, aFile, OpenMode.Append)
        Do While Not EOF(aFree) : Loop
        PrintLine(aFree, pMsg)
        FileClose(aFree)

    End Function
   
End Module
