Module mHistory
    Public HDateSt As String = ""
    Public HDateEnd As String = ""


    Function HGet_Count(ByVal Status_ID As String, ByVal Floor_ID As String) As String
        On Error GoTo Err
        HGet_Count = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        'and HW_Position_X <>0 and HW_Position_Y <> 0
        sql = "SELECT distinct HW_Lot_Id FROM Mas_Lot_History where HW_Status_Alarm_Id >= " & Status_ID & _
            " and HW_Floor_No  = " & Floor_ID & " and HW_Position_X <>0 and HW_Position_Y <> 0 "

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                HGet_Count = .RecordCount
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        HGet_Count = "0"
        Call mError.ShowError("mHistory", "History HGet_Count", Err.Number, Err.Description)
    End Function
    Function Get_CountLot_ALL(ByVal Floor_ID As String) As String
        Get_CountLot_ALL = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Try
            If OpenCnn(ConnStrGuidance, Conn) Then
                sql = "SELECT distinct HW_Lot_Id FROM Mas_lot where HW_Floor_No  = " & Floor_ID & _
                " and HW_Position_X <>0 and HW_Position_Y <> 0 "

                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    Get_CountLot_ALL = .RecordCount
                End With
            End If
            Conn = Nothing
            rs = Nothing
            Exit Function
        Catch ex As Exception
            Get_CountLot_ALL = "0"
            Call mError.ShowError("mCountCar", "Get_Count", Err.Number, Err.Description)
        End Try
        Return Get_CountLot_ALL
    End Function
    Function HGet_Count_LotInFloor(ByVal Floor_ID As String) As String
        On Error GoTo Err
        HGet_Count_LotInFloor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT  Count(*) as Lot FROM Q_Lot_History where HW_Floor_No  = " & Floor_ID & _
            " and HW_Position_X <>0 and HW_Position_Y <> 0" & _
             " and Trn_Log_Datetime_In >= " & mDB.DBFormatDate(HDateSt) & _
            " and Trn_Log_Datetime_In <= " & mDB.DBFormatDate(HDateEnd) & ""
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                HGet_Count_LotInFloor = .Fields.Item("Lot").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        HGet_Count_LotInFloor = "0"
        Call mError.ShowError("mHistory", " History HGet_Count_LotInFloor", Err.Number, Err.Description)
    End Function

    Function HValue_in_Zone(ByVal Zone_Id As String) As String
        On Error GoTo Err
        HValue_in_Zone = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = "SELECT count(*) as VZone FROM MaS_Lot_History " & _
              " where  HW_Status_Alarm_Id > 0 and HW_Zone_Id = " & Zone_Id & ""
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                HValue_in_Zone = .Fields("VZone").Value
            End With
        End If
        Conn = Nothing
        Exit Function

Err:
        HValue_in_Zone = "0"

        Call mError.ShowError("mHistory", "History HValue_in_Zone", Err.Number, Err.Description)
    End Function

    Function HGet_Count_CarInZone(ByVal Zone_ID As String, ByVal Floor_ID As String) As String
        On Error GoTo Err
        HGet_Count_CarInZone = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT Count(*) as Value_Zone FROM Mas_Lot_History where HW_Zone_Id  = " & Zone_ID & _
                  " and HW_Status_Alarm_Id >=0 and HW_Floor_No= " & Floor_ID & _
                  " and HW_Position_X <>0 and HW_Position_Y <> 0"

            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                HGet_Count_CarInZone = .Fields.Item("Value_Zone").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        HGet_Count_CarInZone = "0"
        Call mError.ShowError("mHistory", "History HGet_Count_LotInFloor", Err.Number, Err.Description)
    End Function
    Function HGet_Count_Alam(ByVal Alam_ID As String, ByVal Floor_Id As String) As String
        On Error GoTo Err
        HGet_Count_Alam = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT COUNT(Status_Alarm_Id) as Alam_No FROM Q_Lot_History where Status_Alarm_Id = " & Alam_ID & _
                  " and HW_Floor_No = " & Floor_Id & _
                  " and Trn_Log_Datetime_In >= " & mDB.DBFormatDate(HDateSt) & _
                  " and Trn_Log_Datetime_In <= " & mDB.DBFormatDate(HDateEnd) & ""

            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    HGet_Count_Alam = .Fields("Alam_No").Value
                Else
                    HGet_Count_Alam = "0"
                End If

            End With
        End If
        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        HGet_Count_Alam = "0"

        Call mError.ShowError("mHistory", "History HGet_Count_Alam", Err.Number, Err.Description)
    End Function

    Function HGet_Status_Color_Alam(ByVal Time_Min As String, ByVal Time_Max As String, ByVal Floor_ID As String) As String
        On Error GoTo Err
        HGet_Status_Color_Alam = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        sql = "SELECT  count(HW_Lot_Id)as AlamNo FROM Q_Lot_History where Trn_Status_On_Off = 0  and " & _
              " ((HH*60) + MM) >= " & Time_Min & " and ((HH*60) + MM) <= " & Time_Max & _
              " and HW_Floor_No =" & Floor_ID & _
            " and Trn_Log_Datetime_In >= " & mDB.DBFormatDate(HDateSt) & _
            " and Trn_Log_Datetime_In <= " & mDB.DBFormatDate(HDateEnd) & ""
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                HGet_Status_Color_Alam = .Fields("AlamNo").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function

Err:
        HGet_Status_Color_Alam = "0"

        Call mError.ShowError("mHistory", "History HGet_Status_Color_Alam", Err.Number, Err.Description)
    End Function
    Function HGet_Status_Color_Alam_False(ByVal Time_Min As String, ByVal Time_Max As String, ByVal Floor_ID As String) As String
        On Error GoTo Err
        HGet_Status_Color_Alam_False = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        sql = "SELECT  count(HW_Lot_Id)as AlamNo FROM Q_Lot_History where HW_Net_3 = 0 And HW_Floor_No = " & Floor_ID & _
        " and ((HH*60) + MM) between " & Time_Min & " and " & Time_Max & _
        " and Trn_Log_Datetime_In >= " & mDB.DBFormatDate(HDateSt) & _
        " and Trn_Log_Datetime_In <= " & mDB.DBFormatDate(HDateEnd) & ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                HGet_Status_Color_Alam_False = .Fields("AlamNo").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function

Err:
        HGet_Status_Color_Alam_False = "0"

        Call mError.ShowError("mHistory", "History HGet_Status_Color_Alam_False", Err.Number, Err.Description)
    End Function

    Function Get_MIN_MAX(ByVal MIN_MAX As String, ByVal Field As String, ByVal Condition As String) As String
        Get_MIN_MAX = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try

            sql = "SELECT Max(" & Field & ") FROM  Mas_Lot_History " & Condition & " "

            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    Get_MIN_MAX = .Fields(0).Value
                End With
            End If
            Conn = Nothing
            rs = Nothing
            Exit Function
        Catch ex As Exception
            Get_MIN_MAX = "0"
            Call mError.ShowError("mHistory", "Get_MIN_MAX", Err.Number, Err.Description)
        End Try
        Return Get_MIN_MAX
    End Function
    Function Get_Count_AlamHistory(ByVal Alam_ID As String, ByVal Floor_Id As String, ByVal BuildingID As String) As String
        On Error GoTo Err
        Get_Count_AlamHistory = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        If Floor_Id = "" Then Floor_Id = "1"
        If BuildingID = "" Then BuildingID = "1"
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql &= "SELECT COUNT (HW_Lot_Id) as Alam_No FROM Mas_Lot_History where HW_Status_Alarm_Id = " & Alam_ID & ""
            sql &= " and HW_Floor_No = " & Floor_Id & ""
            sql &= " and HW_Building_ID = " & BuildingID & ""
            '  sql &= " and HW_Datetime_Update Between'" & Format(Date.Now, "yyyy-MM-dd 00:00:00") & " and '" & Format(Date.Now, "yyyy-MM-dd 23:59:59") & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_Count_AlamHistory = .Fields("Alam_No").Value
                Else
                    Get_Count_AlamHistory = "0"
                End If

            End With
        End If
        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Count_AlamHistory = "0"

        Call mError.ShowError("mCountCar", "Get_Count Get_Count_Alam", Err.Number, Err.Description)
    End Function
    Function Get_Count_History(ByVal Status_ID As String, ByVal Floor_ID As String, ByVal Building_ID As String) As String
        On Error GoTo Err
        Get_Count_History = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        'and HW_Position_X <>0 and HW_Position_Y <> 0
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT  HW_Status_Id FROM Mas_Lot_History where HW_Status_Id = '" & Status_ID & _
            "' and HW_Floor_No  = " & Floor_ID & " and HW_Position_X <>0 and HW_Position_Y <> 0 "
            sql &= " and HW_Building_ID = " & Building_ID & ""
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Get_Count_History = .RecordCount
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Count_History = "0"
        Call mError.ShowError("mCountCar", "Get_Count", Err.Number, Err.Description)
    End Function
End Module
