Module mPicture
    Function Save_Pict_To_DB(ByRef pConnStr As String, ByRef pTable As String, ByRef pFields As String, ByRef pPict_Fields As String, ByRef pKey As String, ByRef pFileName As String) As Boolean
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim rsPict As New ADODB.Stream
        Dim sql As String

        sql = " SELECT *  FROM " & pTable & " WHERE " & pFields & " = '" & pKey & "'"
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
                    If MsgBox("คุณต้องการบันทึกข้อมูล ภาพนี้ใช่ หรือ ไม่ ?..", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
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
        Call mError.ShowError("mPicture", "Save_Pict_To_DB", Err.Number, Err.Description)
    End Function

End Module
