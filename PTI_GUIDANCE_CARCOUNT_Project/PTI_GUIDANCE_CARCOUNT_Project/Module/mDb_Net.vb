Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Module mDb_Net
    Dim CON As New OleDbConnection  'ประกาศตัวแปรประเภท  SqlConnection
    Dim ClsSqlCmd As New ClassCommandSql
    'ใช้ในการติดต่อกับ DataBase แล้วคืนค่ากลับในรูปแบบ  SqlConnection
    Function ConnecDB(ByVal ConStr As String) As OleDbConnection
        Try
            With CON
                If .State = ConnectionState.Open Then
                    'ถ้ามีการติดต่ออยู่แล้วให้คืนค่า  CON กลับไปได้เลยโดยไม่ต้องทำการติดต่อใหม่
                    .Close()
                    .ConnectionString = ConStr
                    .Open()
                    Return CON
                Else
                    'ถ้าไม่มีการติดต่อให้ทำการติดต่อใหม่
                    .ConnectionString = ConStr
                    .Open()
                    Return CON
                End If
            End With
            CON.Close()
        Catch er As Exception
            MessageBox.Show(er.Message)
            MessageBox.Show("     ไม่สามารถติดต่อกับ Database ได้       ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return CON
        End Try
    End Function
End Module
