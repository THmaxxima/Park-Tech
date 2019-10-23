Imports System.Data
Imports System.Data.SqlClient
'Imports System.IO 'เรียกขึ้นมาเพื่อใช้ Class File
Public Class ClassCommandSql
    'ใช้ในการติดต่อกับ DataBase แล้วคืนค่ากลับในรูปแบบ  SqlConnection
    Function ConnecDB(ByVal pConnecStr As String) As SqlConnection
        Try
            Dim pConn As New SqlConnection
            With pConn

                If .State = ConnectionState.Open Then
                    'ถ้ามีการติดต่ออยู่แล้วให้คืนค่า  CON กลับไปได้เลยโดยไม่ต้องทำการติดต่อใหม่

                    Return (pConn)
                Else
                    'ถ้าไม่มีการติดต่อให้ทำการติดต่อใหม่
                    .ConnectionString = pConnecStr

                    .Open()
                    Return pConn
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & "     ไม่สามารถติดต่อกับ Database ได้       ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Function
    Overloads Function RunCmd_(ByVal pConnectionStr As String, ByVal StrCmd As String)
        Dim CMD_Ex As New SqlCommand
        Try
            With CMD_Ex
                .CommandType = CommandType.Text
                .CommandTimeout = 60
                .CommandText = StrCmd
                .Connection = ConnecDB(pConnectionStr)
                .ExecuteNonQuery()
            End With
            CMD_Ex.Dispose()
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function


    Overloads Function RunCmd_(ByVal pConnectionStr As String, ByVal SqlCom As SqlCommand, ByVal StrCondition As String)
        Try
            With SqlCom
                .CommandType = CommandType.Text
                .CommandTimeout = 60
                .CommandText = StrCondition
                .Connection = ConnecDB(pConnectionStr)
                .ExecuteNonQuery()
            End With
            SqlCom.Dispose()
        Catch er As Exception
            MessageBox.Show(er.Message)
            'MessageBox.Show("  กรุณาตรวจสอบชนิดของข้อมูลว่าอยู่ในรูปแบบที่ถูกต้องหรือไม่ หรือมีการซ้ำกันของข้อมูล   ")
        End Try
    End Function
    'ตรวจสอบค่าตามคำสั่ง Qury ที่ส่งมา
    Function RunCheckStatus_(ByVal pConnectionStr As String, ByVal StrCheckStatus As String) As Boolean
        Try
            Dim CMD_Ex As New SqlCommand
            Dim ADT_Ex As SqlDataAdapter
            Dim DTS_EX As New DataSet
            ADT_Ex = New SqlDataAdapter(StrCheckStatus, ConnecDB(pConnectionStr))
            ADT_Ex.Fill(DTS_EX, StrCheckStatus)
            '############# ตรวจสอบค่า  ถ้ามี = True ไม่มี= False 
            If DTS_EX.Tables(StrCheckStatus).Rows.Count > 0 Then
                CMD_Ex.Dispose()
                ADT_Ex.Dispose()
                DTS_EX.Dispose()
                Return True
            Else
                CMD_Ex.Dispose()
                ADT_Ex.Dispose()
                DTS_EX.Dispose()
                Return False
            End If
            CMD_Ex.Dispose()
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '############# Return ค่า Field ที่ต้องการ 
    Overloads Function ReturnField_(ByVal pConnectionStr As String, ByVal ConditionName As String, ByVal ReturnFiledName As String) As String
        'ConditionName=คำสั่ง Qury ที่ส่งมา
        'ReturnFiledName=Field ที่ต้องการให้คืนค่ากลับ
        Try
            Dim CMD_Ex As New SqlCommand
            Dim ADT_Ex As SqlDataAdapter
            Dim DTS_EX As New DataSet
            ADT_Ex = New SqlDataAdapter(ConditionName, ConnecDB(pConnectionStr))
            ADT_Ex.Fill(DTS_EX, ConditionName)
            If DTS_EX.Tables(ConditionName).Rows.Count > 0 Then
                CMD_Ex.Dispose()
                ADT_Ex.Dispose()
                DTS_EX.Dispose()
                Return DTS_EX.Tables(ConditionName).Rows(0).Item(ReturnFiledName) 'คืนค่า Field ที่กำหนดมา
            Else
                CMD_Ex.Dispose()
                ADT_Ex.Dispose()
                DTS_EX.Dispose()
                MessageBox.Show("       No record           " & ConditionName, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End If
            CMD_Ex.Dispose()
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '############# Return ค่า Field ที่ต้องการ 
    Overloads Function ReturnField_(ByVal pConnectionStr As String, ByVal ConditionName As String, ByVal ReturnFiledName As String, ByVal strNodata As Object, ByVal IsMsg As Boolean) As String
        'ConditionName=คำสั่ง Qury ที่ส่งมา
        'ReturnFiledName=Field ที่ต้องการให้คืนค่ากลับ
        Try
            Dim CMD_Ex As New SqlCommand
            Dim ADT_Ex As SqlDataAdapter
            Dim DTS_EX As New DataSet
            ADT_Ex = New SqlDataAdapter(ConditionName, ConnecDB(pConnectionStr))
            ADT_Ex.Fill(DTS_EX, ConditionName)
            If DTS_EX.Tables(ConditionName).Rows.Count > 0 Then
                CMD_Ex.Dispose()
                ADT_Ex.Dispose()
                DTS_EX.Dispose()
                Return DTS_EX.Tables(ConditionName).Rows(0).Item(ReturnFiledName) 'คืนค่า Field ที่กำหนดมา
            Else
                CMD_Ex.Dispose()
                ADT_Ex.Dispose()
                DTS_EX.Dispose()
                If IsMsg = True Then
                    MessageBox.Show("       No record           " & ConditionName, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return strNodata
            End If
            CMD_Ex.Dispose()
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '############# Return ค่า Field ที่ต้องการ 
    Overloads Function ReturnField_(ByVal pConnectionStr As String, ByVal cmd_ As SqlCommand, ByVal ConditionName As String, ByVal ReturnFiledName As String) As String
        'ConditionName=คำสั่ง Qury ที่ส่งมา
        'ReturnFiledName=Field ที่ต้องการให้คืนค่ากลับ
        Try
            Dim ADT_T As New SqlDataAdapter(cmd_)
            Dim DTS_T As New DataSet
            ADT_T.Fill(DTS_T, ConditionName)
            If DTS_T.Tables(ConditionName).Rows.Count > 0 Then
                Return DTS_T.Tables(ConditionName).Rows(0).Item(ReturnFiledName)
            Else
                Return 0
            End If
            ADT_T.Dispose()
            DTS_T.Dispose()
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '###### Auto Number
    'ใช้ในการ Run ค่าเพิ่มขึ้นทีละ +1 โดยไม่มีเงื่อนใข
    Function AutoNumber_(ByVal pConnectionStr As String, ByVal TableName As String, ByVal FieldNameAdd As String, ByVal FieldOrderBy As String, ByVal FormatNumber As Short)
        'TableName=ชื่อของ Table
        'FieldNameAdd=ชื่อ Field ที่ต้องการเพิ่มค่า
        'FieldOrderBy=เรียงลำดับข้อมูลจากมากมาน้อย เพื่อที่จะได้หาค่ามากสุดของ Field ที่ต้องการ
        'FormatNumber=รูปแบบของค่าที่ต้องการ เช่น  0000007,007
        Try
            Dim strAutonumber As String
            strAutonumber = "select * from " & TableName & " (nolock) order by convert(int," & FieldOrderBy & ")"
            Dim ADT As New SqlDataAdapter
            Dim DTS As New DataSet
            ADT = New SqlDataAdapter(strAutonumber, ConnecDB(pConnectionStr))
            DTS = New DataSet
            ADT.Fill(DTS, strAutonumber)
            If DTS.Tables(strAutonumber).Rows.Count > 0 Then
                '########## Upper Record
                With DTS.Tables(strAutonumber)
                    Dim StrFormat As String
                    StrFormat = Val((.Rows(.Rows.Count - 1).Item(FieldNameAdd))) + 1 'นำค่าสุดท้ายมาบวกเพิ่มอีก +1
                    StrFormat = StrFormat.PadLeft(FormatNumber, "0") 'แปลงค่าให้อยู่ในรูปแบบที่ต้องการ
                    Return StrFormat
                End With
            Else
                'ถ้ายังไม่มีข้อมูลเลย ให้กำหนด Reccord ดังกล่าว =1
                '########## Start Record
                Dim StrFormat As String
                StrFormat = 1
                StrFormat = StrFormat.PadLeft(FormatNumber, "0")
                Return StrFormat
            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '###### Auto Number
    'ใช้ในการ Run ค่าเพิ่มขึ้นทีละ +1 โดยไม่มีเงื่อนใข
    Function AutoNumber_(ByVal pConnectionStr As String, ByVal TableName As String, ByVal FieldNameAdd As String, ByVal FieldOrderBy As String, ByVal FormatNumber As Short, ByVal ValueStart As String)
        'TableName=ชื่อของ Table
        'FieldNameAdd=ชื่อ Field ที่ต้องการเพิ่มค่า
        'FieldOrderBy=เรียงลำดับข้อมูลจากมากมาน้อย เพื่อที่จะได้หาค่ามากสุดของ Field ที่ต้องการ
        'FormatNumber=รูปแบบของค่าที่ต้องการ เช่น  0000007,007
        Try
            Dim strAutonumber As String
            strAutonumber = "select * from " & TableName & " (nolock) order by convert(int," & FieldOrderBy & ")"
            Dim ADT As New SqlDataAdapter
            Dim DTS As New DataSet
            ADT = New SqlDataAdapter(strAutonumber, ConnecDB(pConnectionStr))
            DTS = New DataSet
            ADT.Fill(DTS, strAutonumber)
            If DTS.Tables(strAutonumber).Rows.Count > 0 Then
                '########## Upper Record
                With DTS.Tables(strAutonumber)
                    Dim StrFormat As String
                    StrFormat = Val((.Rows(.Rows.Count - 1).Item(FieldNameAdd))) + 1 'นำค่าสุดท้ายมาบวกเพิ่มอีก +1
                    StrFormat = StrFormat.PadLeft(FormatNumber, "0") 'แปลงค่าให้อยู่ในรูปแบบที่ต้องการ
                    Return StrFormat
                End With
            Else
                Dim StrFormat As String
                StrFormat = ValueStart
                StrFormat = StrFormat.PadLeft(FormatNumber, "0") 'แปลงค่าให้อยู่ในรูปแบบที่ต้องการ             
                Return StrFormat
            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '###### Auto Number
    'ใช้ในการ Run ค่าเพิ่มขึ้นทีละ +1 โดยมีเงื่อนใขตามที่กำหนด
    Function AutoNumberAddField_(ByVal pConnectionStr As String, ByVal TableName As String, ByVal FieldNameAdd As String, ByVal FieldCondition As String, ByVal ValueCondition As String, ByVal FieldOrderBy As String, ByVal FormatNumber As Short)
        Try
            Dim strAutonumber As String
            strAutonumber = "select  *  from " & TableName & " (nolock) where " & FieldCondition & "=" & "'" & ValueCondition & "'" & " order by convert(int," & FieldOrderBy & ")"
            Dim ADT As New SqlDataAdapter
            Dim DTS As New DataSet
            ADT = New SqlDataAdapter(strAutonumber, ConnecDB(pConnectionStr))
            DTS = New DataSet
            ADT.Fill(DTS, strAutonumber)
            If DTS.Tables(strAutonumber).Rows.Count > 0 Then
                '########## Upper Record
                With DTS.Tables(strAutonumber)
                    Dim StrFormat As String
                    StrFormat = Val((.Rows(.Rows.Count - 1).Item(FieldNameAdd))) + 1 'นำค่าสุดท้ายมาบวกเพิ่มอีก +1
                    StrFormat = StrFormat.PadLeft(FormatNumber, "0") 'แปลงค่าให้อยู่ในรูปแบบที่ต้องการ
                    Return StrFormat
                End With
            Else
                'ถ้ายังไม่มีข้อมูลเลย ให้กำหนด Reccord ดังกล่าว =1
                '########## Start Record
                Dim StrFormat As String
                StrFormat = 1
                StrFormat = StrFormat.PadLeft(FormatNumber, "0")
                Return StrFormat
            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '############ Alarm
    'Qury แบบ ธรรมดา ส่งค่า String 
    Public Overloads Function ReturnDatatable_(ByVal pConnectionStr As String, ByVal StrQury As String) As DataTable
        Try
            Dim ADT_T As New SqlDataAdapter(StrQury, ConnecDB(pConnectionStr))
            Dim DTS_T As New DataSet
            ADT_T.Fill(DTS_T, StrQury)
            If DTS_T.Tables(StrQury).Rows.Count > 0 Then
                Return DTS_T.Tables(StrQury)
            Else
                Return DTS_T.Tables(StrQury)
            End If
        Catch ex As Exception
            MessageBox.Show("คำสั่งในการค้นหาข็อมูลผิดพลาด " & ex.Message)
        End Try
    End Function

    'Qury แบบ ที่มีการสร้างParameter จากข้างนอกมา แล้วส่งมเป็น Command และ  StrQury
    Public Overloads Function ReturnDatatable_(ByVal pConnectionStr As String, ByVal cmd_ As SqlCommand, ByVal StrQury As String) As DataTable
        cmd_.CommandTimeout = 60
        Dim ADT_T As New SqlDataAdapter(cmd_)
        Dim DTS_T As New DataSet
        ADT_T.Fill(DTS_T, StrQury)
        If DTS_T.Tables(StrQury).Rows.Count > 0 Then
            Return DTS_T.Tables(StrQury)
        Else
            Return DTS_T.Tables(StrQury)
        End If
        ADT_T.Dispose()
        DTS_T.Dispose()
    End Function
End Class
