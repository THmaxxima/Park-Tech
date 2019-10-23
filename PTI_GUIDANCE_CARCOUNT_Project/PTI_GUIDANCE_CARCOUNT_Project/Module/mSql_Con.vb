Imports System.Data 'เป็นไลบรารี่หลักๆ ที่รวบรวมคำสั่งให้เรียกใช้งาน
Imports System.Data.SqlClient 'เป็นไรบรารี้ที่ใช้กับ Microsoft SQL Server ใช้ในการติดต่อกับฐานข้อมูล
Module mSql_Con

    Public Con As SqlConnection
    Public sqlDa As SqlDataAdapter
    Public sqlRd As SqlDataReader
    Public sqlDs As DataSet
    Public sqlCom As SqlCommand
    Public SQLDT As New DataTable
    Public TestRe As String
    Public isFind As Boolean = False
    Public Result As DialogResult
    Public i As Integer
    Public tr As SqlTransaction
    Public FNameId As String
    Public StatusId As String
    Public CusStatusId As String
    Public sql As String = ""
    Public Cus As String   'ตัวแปรเก็บรัหสการกำหนดสิทธิการข้าใช้ระบบ
    Public Department As String  'ตัวแปรเก็บหน้าที่การทำงานในระบบ
    '-------------------------ตัวแปรส่วนของลูกค้าCustomer-------------------------------------------------

    Public Confirm As String = "ยืนยัน"
    Public Title_Error As String = "ผลการตรวจสอบ"
    Public User_Level As String = ""
    Public Floor_Select_Id As String = "" 'ตัวแปรเก็บค่าชั้น
    Public Floor_Controller_Id As String = "" 'ตัวแปรเก็บอุปกรณ์ควบคุมตามชั้น
    Public HW_Lot_Id As String = ""
    Public Lot_Id As String = ""
    Public Result_SQL As Boolean
    Public Result_Store As Boolean
    Function Excute_SQL(ByVal StrCon As String, Optional ByVal sql_Excute As String = "") As Boolean
        Result_SQL = False

        Try
            Con = New SqlConnection(StrCon)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = StrCon
                .Open()
            End With
            tr = Con.BeginTransaction
            sqlCom = New SqlCommand(sql_Excute, Con)
            tr.Commit()
            sqlCom.ExecuteNonQuery()
            Con.Close()
            Result_SQL = True
            Excute_SQL = True
        Catch ex As Exception
            '  tr.Rollback()
            Con.Close()
            WriteError("", "", "Excute SQL Connection : ", sql)
            Excute_SQL = False
        End Try
        sql_Excute = ""
    End Function





End Module
