Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Module mDb_Net
    Dim CON As New OleDbConnection  '��С�ȵ���û�����  SqlConnection
    Dim ClsSqlCmd As New ClassCommandSql
    '��㹡�õԴ��͡Ѻ DataBase ���Ǥ׹��ҡ�Ѻ��ٻẺ  SqlConnection
    Function ConnecDB(ByVal ConStr As String) As OleDbConnection
        Try
            With CON
                If .State = ConnectionState.Open Then
                    '����ա�õԴ��������������׹���  CON ��Ѻ������������ͧ�ӡ�õԴ�������
                    .Close()
                    .ConnectionString = ConStr
                    .Open()
                    Return CON
                Else
                    '�������ա�õԴ������ӡ�õԴ�������
                    .ConnectionString = ConStr
                    .Open()
                    Return CON
                End If
            End With
            CON.Close()
        Catch er As Exception
            MessageBox.Show(er.Message)
            MessageBox.Show("     �������ö�Դ��͡Ѻ Database ��       ", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return CON
        End Try
    End Function
End Module
