Imports System.Data.SqlClient

Public Class DBSqlServer
    Private Connecter As SqlConnection
    Private sqlTransaction As SqlTransaction
    Public Sub DBSqlServer()

    End Sub

    Public Function Connecting(ByVal strConn As String, ByVal isShowMessageError As Boolean) As Boolean
        Connecter = New SqlConnection(strConn)
        Try
            Connecter.Open()
            Return True
        Catch ex As System.Exception
            If isShowMessageError = True Then
                MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ กรุณาติดต่อเจ้าหน้าที่ IT", "ผลการเชื่อมต่อฐานข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            Return False
        End Try
    End Function

    Public Function ExecuteSelectCommandSQL(ByVal sql As String) As DataTable
        Dim TableResult As New DataTable
        Dim UserDataAdaptor As New SqlDataAdapter(sql, Connecter)
        Try
            UserDataAdaptor.Fill(TableResult)
            Return TableResult
        Catch ex As System.Exception
            Return TableResult
        End Try
    End Function

    Public Function ExecuteCommandSQL(ByVal sql As String) As Boolean
        Dim TableResult As New DataTable
        sqlTransaction = Connecter.BeginTransaction()
        Dim UserCommand As New SqlCommand(sql, Connecter)
        Try
            UserCommand.Transaction = sqlTransaction
            UserCommand.ExecuteNonQuery()
            sqlTransaction.Commit()
            Return True
        Catch ex As System.Exception
            sqlTransaction.Rollback()
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        Connecter.Close()
    End Sub

End Class
