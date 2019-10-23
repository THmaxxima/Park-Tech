Imports System.Data
Imports System.Data.SqlClient
Module mUNION
    Public CommitTransaction As Boolean
    Sub UNION_View_Transaction(ByVal StMonth As String, ByVal StYears As String, ByVal EnMonth As String, ByVal EnYears As String)
        Dim sql As String = ""
        Dim Begin_Union As String = ""
        Dim Begin_Table As String = ""

        If StMonth = EnMonth And EnYears = StYears Then
            If StMonth = Now.Month And EnMonth = Now.Month And StYears = Now.Year And StYears = Now.Year Then
                Begin_Union = "ALTER VIEW [dbo].[U_Transaction_Lot] "
                Begin_Union &= " AS"
                Begin_Union &= " SELECT * FROM Transaction_Lot"
                sql = Begin_Union & Begin_Table
                Excute_Union(sql)
                Exit Sub
            End If
        End If

        If EnMonth = Now.Month Then
            EnMonth = Val(EnMonth) - 1
        End If

        Begin_Union = "ALTER VIEW [dbo].[U_Transaction_Lot] "
        Begin_Union &= " AS"
        Begin_Union &= " SELECT * FROM Transaction_Lot"

        Do
            Begin_Table &= "  UNION  SELECT * FROM Transaction_Lot_" & GenMonth(EnMonth) & EnYears
            If EnYears = "2012" Then
                If EnMonth = 6 And EnYears = "2012" Then Exit Do
            End If
            EnMonth = EnMonth - 1
            If EnMonth = 0 Then
                EnMonth = 12
                EnYears = EnYears - 1
            End If
            If ((StMonth - EnMonth) = 1 And EnYears = StYears) Then Exit Do

        Loop Until EnMonth = 6 And EnYears = "2012"

        sql = Begin_Union & Begin_Table
        Excute_Union(sql)

    End Sub
    Function GenMonth(ByVal MM As String) As String
        Dim Month As String = ""
        If MM.Length < 2 Then
            Month = "0" & MM
        Else
            Month = MM
        End If
        Return Month
    End Function
    Sub Excute_Union(ByVal Sql As String)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Try
            If OpenCnn(ConnStrGuidance, Conn) Then
                ' Conn.BeginTrans()
                Conn.Execute(Sql)
                'Conn.CommitTrans()
                Conn.Close()
            End If
            rs = Nothing
        Catch ex As Exception
            '    Conn.RollbackTrans()
            '    Conn.Close()
        End Try
    End Sub

    Function Excute_SQL_Con(ByVal sqlCon As String, ByVal sql_Command As String) As Boolean

        Try
            Con = New SqlConnection(sqlCon)
            CommitTransaction = False
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = sqlCon
                .Open()
            End With
            tr = Con.BeginTransaction
            sqlCom = New SqlCommand(sql_Command, Con)
            sqlCom.ExecuteNonQuery()
            tr.Commit()
            Con.Close()
            CommitTransaction = True
        Catch ex As Exception
            CommitTransaction = False
            tr.Rollback()
            Con.Close()
            Write_Error(sql_Command)
        End Try

        Return CommitTransaction
    End Function

    Sub Excute_SQL_Com(ByVal Sqlcon As String, ByRef sql_Command As String)
        Dim com As New SqlCommand

        Try
            Con = New SqlConnection(Sqlcon)
            CommitTransaction = False
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = Sqlcon
                .Open()
            End With
            With com
                .CommandText = sql_Command '"SpTran_Car_InOut_Type"
                .CommandType = CommandType.Text
                ' .CommandType = CommandType.StoredProcedure
                .Connection = Con
                .ExecuteNonQuery()
            End With
            Con.Close()
            CommitTransaction = True
        Catch ex As Exception
            CommitTransaction = False
            Write_Error(sql_Command)
        End Try
    End Sub

    Public Function Write_Error(ByVal ErDesc As String) As Boolean
        Try
            Write_Error = False
            Dim aFile, Msg As String
            Dim aFree As Integer
            If Dir(My.Application.Info.DirectoryPath & "\ErrLOG", FileAttribute.Directory) = "" Then MkDir((My.Application.Info.DirectoryPath & "\ErrLOG"))
            aFile = My.Application.Info.DirectoryPath & "\ErrLOG\" & Format(Now, "yyyy_MM") & ".LOG"

            Msg = Format(Now, "dd-MM-yyyy HH:mm:ss") & "  ErrDescript : " & ErDesc
            If isThaiErr Then Msg = Msg & " : " & GetErrString(Err.Number)

            aFree = FreeFile()
            FileOpen(aFree, aFile, OpenMode.Append)
            Do While Not EOF(aFree) : Loop
            PrintLine(aFree, Msg)
            FileClose(aFree)
            Write_Error = True
        Catch ex As Exception
            Write_Error = False
        End Try
        Return Write_Error
    End Function

End Module
