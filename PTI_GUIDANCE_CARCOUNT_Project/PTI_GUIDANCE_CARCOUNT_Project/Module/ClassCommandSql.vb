Imports System.Data
Imports System.Data.SqlClient
'Imports System.IO '���¡����������� Class File
Public Class ClassCommandSql
    '��㹡�õԴ��͡Ѻ DataBase ���Ǥ׹��ҡ�Ѻ��ٻẺ  SqlConnection
    Function ConnecDB(ByVal pConnecStr As String) As SqlConnection
        Try
            Dim pConn As New SqlConnection
            With pConn

                If .State = ConnectionState.Open Then
                    '����ա�õԴ��������������׹���  CON ��Ѻ������������ͧ�ӡ�õԴ�������

                    Return (pConn)
                Else
                    '�������ա�õԴ������ӡ�õԴ�������
                    .ConnectionString = pConnecStr

                    .Open()
                    Return pConn
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & "     �������ö�Դ��͡Ѻ Database ��       ", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            'MessageBox.Show("  ��سҵ�Ǩ�ͺ��Դ�ͧ���������������ٻẺ���١��ͧ������� �����ա�ë�ӡѹ�ͧ������   ")
        End Try
    End Function
    '��Ǩ�ͺ��ҵ������� Qury �������
    Function RunCheckStatus_(ByVal pConnectionStr As String, ByVal StrCheckStatus As String) As Boolean
        Try
            Dim CMD_Ex As New SqlCommand
            Dim ADT_Ex As SqlDataAdapter
            Dim DTS_EX As New DataSet
            ADT_Ex = New SqlDataAdapter(StrCheckStatus, ConnecDB(pConnectionStr))
            ADT_Ex.Fill(DTS_EX, StrCheckStatus)
            '############# ��Ǩ�ͺ���  ����� = True �����= False 
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
    '############# Return ��� Field ����ͧ��� 
    Overloads Function ReturnField_(ByVal pConnectionStr As String, ByVal ConditionName As String, ByVal ReturnFiledName As String) As String
        'ConditionName=����� Qury �������
        'ReturnFiledName=Field ����ͧ������׹��ҡ�Ѻ
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
                Return DTS_EX.Tables(ConditionName).Rows(0).Item(ReturnFiledName) '�׹��� Field ����˹���
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
    '############# Return ��� Field ����ͧ��� 
    Overloads Function ReturnField_(ByVal pConnectionStr As String, ByVal ConditionName As String, ByVal ReturnFiledName As String, ByVal strNodata As Object, ByVal IsMsg As Boolean) As String
        'ConditionName=����� Qury �������
        'ReturnFiledName=Field ����ͧ������׹��ҡ�Ѻ
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
                Return DTS_EX.Tables(ConditionName).Rows(0).Item(ReturnFiledName) '�׹��� Field ����˹���
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
    '############# Return ��� Field ����ͧ��� 
    Overloads Function ReturnField_(ByVal pConnectionStr As String, ByVal cmd_ As SqlCommand, ByVal ConditionName As String, ByVal ReturnFiledName As String) As String
        'ConditionName=����� Qury �������
        'ReturnFiledName=Field ����ͧ������׹��ҡ�Ѻ
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
    '��㹡�� Run ���������鹷��� +1 ����������͹�
    Function AutoNumber_(ByVal pConnectionStr As String, ByVal TableName As String, ByVal FieldNameAdd As String, ByVal FieldOrderBy As String, ByVal FormatNumber As Short)
        'TableName=���ͧ͢ Table
        'FieldNameAdd=���� Field ����ͧ����������
        'FieldOrderBy=���§�ӴѺ�����Ũҡ�ҡ�ҹ��� ���ͷ������Ҥ���ҡ�ش�ͧ Field ����ͧ���
        'FormatNumber=�ٻẺ�ͧ��ҷ���ͧ��� ��  0000007,007
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
                    StrFormat = Val((.Rows(.Rows.Count - 1).Item(FieldNameAdd))) + 1 '�Ӥ���ش�����Һǡ�����ա +1
                    StrFormat = StrFormat.PadLeft(FormatNumber, "0") '�ŧ������������ٻẺ����ͧ���
                    Return StrFormat
                End With
            Else
                '����ѧ����բ�������� ����˹� Reccord �ѧ����� =1
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
    '��㹡�� Run ���������鹷��� +1 ����������͹�
    Function AutoNumber_(ByVal pConnectionStr As String, ByVal TableName As String, ByVal FieldNameAdd As String, ByVal FieldOrderBy As String, ByVal FormatNumber As Short, ByVal ValueStart As String)
        'TableName=���ͧ͢ Table
        'FieldNameAdd=���� Field ����ͧ����������
        'FieldOrderBy=���§�ӴѺ�����Ũҡ�ҡ�ҹ��� ���ͷ������Ҥ���ҡ�ش�ͧ Field ����ͧ���
        'FormatNumber=�ٻẺ�ͧ��ҷ���ͧ��� ��  0000007,007
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
                    StrFormat = Val((.Rows(.Rows.Count - 1).Item(FieldNameAdd))) + 1 '�Ӥ���ش�����Һǡ�����ա +1
                    StrFormat = StrFormat.PadLeft(FormatNumber, "0") '�ŧ������������ٻẺ����ͧ���
                    Return StrFormat
                End With
            Else
                Dim StrFormat As String
                StrFormat = ValueStart
                StrFormat = StrFormat.PadLeft(FormatNumber, "0") '�ŧ������������ٻẺ����ͧ���             
                Return StrFormat
            End If
        Catch er As Exception
            MessageBox.Show(er.Message)
        End Try
    End Function
    '###### Auto Number
    '��㹡�� Run ���������鹷��� +1 �������͹㢵������˹�
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
                    StrFormat = Val((.Rows(.Rows.Count - 1).Item(FieldNameAdd))) + 1 '�Ӥ���ش�����Һǡ�����ա +1
                    StrFormat = StrFormat.PadLeft(FormatNumber, "0") '�ŧ������������ٻẺ����ͧ���
                    Return StrFormat
                End With
            Else
                '����ѧ����բ�������� ����˹� Reccord �ѧ����� =1
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
    'Qury Ẻ ������ �觤�� String 
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
            MessageBox.Show("�����㹡�ä��Ң����żԴ��Ҵ " & ex.Message)
        End Try
    End Function

    'Qury Ẻ ����ա�����ҧParameter �ҡ��ҧ�͡�� ��������� Command ���  StrQury
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
