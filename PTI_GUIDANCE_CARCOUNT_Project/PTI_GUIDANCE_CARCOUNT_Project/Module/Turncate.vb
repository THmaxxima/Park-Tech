Module Turncate
    Public Sub TRUNCATE(ByVal Strcon_to_Database As String, ByVal Table As String)
        Try
            Dim Conn As New ADODB.Connection
            Dim sql_ As String = "Truncate table " & Table
            If OpenCnn(Strcon_to_Database, Conn) Then
                Conn.BeginTrans()
                Conn.Execute(sql_)
                Conn.CommitTrans()
                Conn = Nothing
            Else
                Conn.RollbackTrans()
            End If
        Catch ex As Exception
            Call mError.ShowError("TRUNCATE", "TRUNCATE USER Print Report GUIDANCE", Err.Number, Err.Description)
        End Try
    End Sub
End Module
