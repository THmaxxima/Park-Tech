Module Report
    Public Company_Name As String = ""
    Public Tax_Id As String = ""
    Public Address As String = ""
    Public Connection As String = ""
    Public Description As String = ""
    Public Header_Report As String = ""
    Public User_Print As String = ""


    Sub Get_Company()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Try
            If OpenCnn(ConnStrMasTer, Conn) Then
                sql = "SELECT * FROM Mas_Staion_Company"
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    If Not (.EOF And .BOF) Then
                        Company_Name = "" & .Fields("Company_Name").Value '= "" & .Fields("").Value
                        Tax_Id = "" & .Fields("Company_Tax_Id").Value
                        Address = "" & .Fields("Company_Address").Value & " " & .Fields("Company_Povince").Value & " " & .Fields("Zip_Code").Value
                        Connection = "�������Ѿ��  " & .Fields("Telephone").Value & " �硫�  " & .Fields("Fax").Value
                    Else
                        Company_Name = ""
                        Tax_Id = ""
                        Address = ""
                        Connection = ""
                    End If
                End With
            End If

        Catch ex As Exception
            Call mError.ShowError("mUser", "Get_Company", Err.Number, Err.Description)
        End Try
    End Sub
    Function Convert_Tax(ByVal Tax As String) As String
        Try
            Dim i As Integer
            Convert_Tax = ""
            Dim Num As String
            For i = 1 To Tax.Length
                Num = Mid(Tax, i, 1)
                If Num <> "-" Then
                    Convert_Tax = Convert_Tax + Num
                End If
                Num = ""
            Next

        Catch ex As Exception
            Convert_Tax = ""
            Call mError.ShowError("mCountCar", "Get_Count Convert_Tax", Err.Number, Err.Description)
        End Try
    End Function
    Function Convert_Int(ByVal Int As String) As String
        Try
            Dim i As Integer
            Convert_Int = ""
            Dim Num As String
            For i = 1 To Int.Length
                Num = Mid(Int, i, 1)
                If IsNumeric(Num) = True Then
                    Convert_Int = Convert_Int + Num
                End If
                Num = ""
            Next

        Catch ex As Exception
            Convert_Int = "0"
            Call mError.ShowError("mCountCar", "Get_Count Convert_Tax", Err.Number, Err.Description)
        End Try
    End Function
    Function Format_Integer(ByVal Int As String) As String

        Try
            Format_Integer = ""
            If Int.Length > 3 Then
                If Int.Length = 4 Then
                    Format_Integer = Mid(Int, 1, 1) & "," & Mid(Int, 2, 3)
                End If
                If Int.Length = 5 Then
                    Format_Integer = Mid(Int, 1, 2) & "," & Mid(Int, 3, 3)
                End If
                If Int.Length = 6 Then
                    Format_Integer = Mid(Int, 1, 3) & "," & Mid(Int, 4, 3)
                End If
                If Int.Length = 7 Then
                    Format_Integer = Mid(Int, 1, 1) & "," & Mid(Int, 2, 3) & "," & Mid(Int, 4, 3)
                End If
            Else
                If Int = 0 Or Int = "0" Then
                    Format_Integer = 0
                Else
                    Format_Integer = Int
                End If

            End If

        Catch ex As Exception
            Format_Integer = "0"
            Call mError.ShowError("mCountCar", "Get_Count Convert_Tax", Err.Number, Err.Description)
        End Try
        Return Format_Integer
    End Function
    Public Function ThaiBaht(ByVal pAmount As Double) As String
        Dim Diff As String = ""
        If pAmount = 0 Then
            Return "�ٹ��ҷ��ǹ"
        End If

        If pAmount < 0 Then
            pAmount = pAmount * -1
            Diff = "(�Ҵ) "
        Else

            Diff = "�Թ "
        End If

        Dim _integerValue As String ' �ӹǹ���
        Dim _decimalValue As String ' �ȹ���
        Dim _integerTranslatedText As String ' �ӹǹ��� ������
        Dim _decimalTranslatedText As String ' �ȹ���������

        _integerValue = Format(pAmount, "####.00") ' �Ѵ Format ����Թ�繵���Ţ 2 ��ѡ
        _decimalValue = Mid(_integerValue, Len(_integerValue) - 1, 2) ' �ȹ���
        _integerValue = Mid(_integerValue, 1, Len(_integerValue) - 3) ' �ӹǹ���

        ' �ŧ �ӹǹ��� �� ������
        _integerTranslatedText = NumberToText(CDbl(_integerValue))

        ' �ŧ �ȹ��� �� ������
        If CDbl(_decimalValue) <> 0 Then
            _decimalTranslatedText = NumberToText(CDbl(_decimalValue))
        Else
            _decimalTranslatedText = ""
        End If

        ' �������շȹ��
        If _decimalTranslatedText.Trim = "" Then
            _integerTranslatedText += "�ҷ��ǹ"
        Else
            _integerTranslatedText += "�ҷ" & _decimalTranslatedText & "ʵҧ��"
        End If

        Return Diff & _integerTranslatedText
    End Function
    Public Function ThaiBaht_Only(ByVal pAmount As Double) As String

        If pAmount = 0 Then
            Return "�ٹ��ҷ��ǹ"
        End If

        Dim _integerValue As String ' �ӹǹ���
        Dim _decimalValue As String ' �ȹ���
        Dim _integerTranslatedText As String ' �ӹǹ��� ������
        Dim _decimalTranslatedText As String ' �ȹ���������

        _integerValue = Format(pAmount, "####.00") ' �Ѵ Format ����Թ�繵���Ţ 2 ��ѡ
        _decimalValue = Mid(_integerValue, Len(_integerValue) - 1, 2) ' �ȹ���
        _integerValue = Mid(_integerValue, 1, Len(_integerValue) - 3) ' �ӹǹ���

        ' �ŧ �ӹǹ��� �� ������
        _integerTranslatedText = NumberToText(CDbl(_integerValue))

        ' �ŧ �ȹ��� �� ������
        If CDbl(_decimalValue) <> 0 Then
            _decimalTranslatedText = NumberToText(CDbl(_decimalValue))
        Else
            _decimalTranslatedText = ""
        End If

        ' �������շȹ��
        If _decimalTranslatedText.Trim = "" Then
            _integerTranslatedText += "�ҷ��ǹ"
        Else
            _integerTranslatedText += "�ҷ" & _decimalTranslatedText & "ʵҧ��"
        End If

        Return _integerTranslatedText
    End Function
    Private Function NumberToText(ByVal pAmount As Double) As String
        ' ����ѡ��
        Dim _numberText() As String = {"", "˹��", "�ͧ", "���", "���", "���", "ˡ", "��", "Ỵ", "���", "�Ժ"}

        ' ��ѡ ˹��� �Ժ ���� �ѹ ...
        Dim _digit() As String = {"", "�Ժ", "����", "�ѹ", "����", "�ʹ", "��ҹ"}
        Dim _value As String, _aWord As String, _text As String
        Dim _numberTranslatedText As String = ""
        Dim _length, _digitPosition As Integer

        _value = pAmount.ToString
        _length = Len(_value) ' ��Ҵ�ͧ �����ŷ���ͧ����ŧ �� 122200 �բ�Ҵ ��ҡѺ 6

        For i As Integer = 0 To _length - 1 ' ǹ�ٻ ������ҡ 0 ���֧ (��Ҵ - 1)
            ' ���˹觢ͧ ��ѡ (digit) �ͧ����Ţ
            ' ��
            ' ���˹���ѡ���0 (��ѡ˹���)
            ' ���˹���ѡ���1 (��ѡ�Ժ)
            ' ���˹���ѡ���2 (��ѡ����)
            ' ����繢����� i = 7 ���˹���ѡ����ҡѺ 1 (��ѡ�Ժ)
            ' ����繢����� i = 9 ���˹���ѡ����ҡѺ 3 (��ѡ�ѹ)
            ' ����繢����� i = 13 ���˹���ѡ����ҡѺ 1 (��ѡ�Ժ)
            _digitPosition = i - (6 * ((i - 1) \ 6))
            _aWord = Mid(_value, Len(_value) - i, 1)
            _text = ""
            Select Case _digitPosition
                Case 0 ' ��ѡ˹���
                    If _aWord = "1" And _length > 1 Then
                        ' ������Ţ 1 ����բ�Ҵ�ҡ���� 1 ����դ����ҡѺ "���"
                        _text = "���"
                    ElseIf _aWord <> "0" Then
                        ' ���������Ţ 0 ����� ����ѡ�� � _numberText()
                        _text = _numberText(CInt(_aWord))
                    End If
                Case 1 ' ��ѡ�Ժ
                    If _aWord = "1" Then
                        ' ������Ţ 1 ����ͧ�� ����ѡ�� ����ա �͡�ҡ����� "�Ժ"
                        '_numberTranslatedText = "�Ժ" & _numberTranslatedText
                        _text = _digit(_digitPosition)
                    ElseIf _aWord = "2" Then
                        ' ������Ţ 2 ������ѡ�ä�� "����Ժ"
                        _text = "���" & _digit(_digitPosition)
                    ElseIf _aWord <> "0" Then
                        ' ���������Ţ 0 ����� ����ѡ�� � _numberText() �������ѡ(digit) � _digit()
                        _text = _numberText(CInt(_aWord)) & _digit(_digitPosition)
                    End If
                Case 2, 3, 4, 5 ' ��ѡ���� �֧ �ʹ
                    If _aWord <> "0" Then
                        _text = _numberText(CInt(_aWord)) & _digit(_digitPosition)
                    End If
                Case 6 ' ��ѡ��ҹ
                    If _aWord = "0" Then
                        _text = "��ҹ"
                    ElseIf _aWord = "1" And _length - 1 > i Then
                        _text = "�����ҹ"
                    Else
                        _text = _numberText(CInt(_aWord)) & _digit(_digitPosition)
                    End If
            End Select
            _numberTranslatedText = _text & _numberTranslatedText
        Next

        Return _numberTranslatedText
    End Function
End Module
