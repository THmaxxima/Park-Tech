Module FloorController
    Function FloorController_Name(ByVal FloorController_ID As String)
        On Error GoTo Err
        FloorController_Name = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT Floorcontroller_Name FROM Mas_Floorcontroller where Floorcontroller_Id = '" & FloorController_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                FloorController_Name = .RecordCount
                If Not (.EOF And .BOF) Then
                    FloorController_Name = .Fields("Floorcontroller_Name").Value
                Else
                    FloorController_Name = ""
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        FloorController_Name = "0"
        Call mError.ShowError("FloorController", "FloorController_Name", Err.Number, Err.Description)
        FloorController_ID = ""
    End Function
    Function FloorController_Status(ByVal FloorController_ID As String)
        On Error GoTo Err
        FloorController_Status = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT Floorcontroller_Status FROM Mas_Floorcontroller where Floorcontroller_Id = '" & FloorController_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                FloorController_Status = .RecordCount
                If Not (.EOF And .BOF) Then
                    FloorController_Status = .Fields("Floorcontroller_Status").Value
                Else
                    FloorController_Status = ""
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        FloorController_Status = "0"
        Call mError.ShowError("FloorController", "FloorController_Status", Err.Number, Err.Description)
        FloorController_ID = ""
    End Function
    Function FloorController_Status0(ByVal FloorController_ID As String)
        On Error GoTo Err
        FloorController_Status0 = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT Floorcontroller_Status FROM Mas_Floorcontroller where Floorcontroller_Id = '" & FloorController_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                FloorController_Status0 = .RecordCount
                If Not (.EOF And .BOF) Then
                    FloorController_Status0 = .Fields("Floorcontroller_Status").Value
                Else
                    FloorController_Status0 = ""
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        FloorController_Status0 = "0"
        Call mError.ShowError("FloorController", "FloorController_Status0", Err.Number, Err.Description)
        FloorController_ID = ""
    End Function

    Function Lot_Status0(ByVal FloorController_ID As String)
        On Error GoTo Err
        Lot_Status0 = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT count(HW_Lot_Id) as Status0 FROM " & _
                  "Mas_Lot where HW_Floorcontroller_Id =" & FloorController_ID & _
                  " and HW_Net_3 = 0"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Lot_Status0 = .Fields("Status0").Value
                Else
                    Lot_Status0 = "0"
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Lot_Status0 = "0"
        Call mError.ShowError("FloorController", "Lot_Status0", Err.Number, Err.Description)
    End Function
    Function Lot_Status1(ByVal FloorController_ID As String)
        On Error GoTo Err
        Lot_Status1 = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT count(HW_Lot_Id) as Status1 FROM " & _
                  "Mas_Lot where HW_Floorcontroller_Id =" & FloorController_ID & _
                  " and HW_Net_3 = 1"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Lot_Status1 = .Fields("Status1").Value
                Else
                    Lot_Status1 = "0"
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Lot_Status1 = "0"
        Call mError.ShowError("FloorController", "Lot_Status1", Err.Number, Err.Description)

    End Function
    Function Lot_Name(ByVal Lot_ID As String)
        On Error GoTo Err
        Lot_Name = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT HW_Lot_Name FROM " & _
                  "Mas_Lot where HW_Lot_Id =" & Lot_ID & ""
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Lot_Name = .Fields("HW_Lot_Name").Value
                Else
                    Lot_Name = "0"
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Lot_Name = "0"
        Call mError.ShowError("FloorController", "Lot_Status1", Err.Number, Err.Description)

    End Function

    Function Status_FloorController_InMasLot(ByVal FloorController_ID As String)
        On Error GoTo Err
        Status_FloorController_InMasLot = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT count(HW_Net_3) as FC_Status FROM Mas_Lot where HW_Net_3 = 1  and  HW_Floorcontroller_Id = " & FloorController_ID & ""
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Status_FloorController_InMasLot = .RecordCount
                If Not (.EOF And .BOF) Then
                    Status_FloorController_InMasLot = .Fields("FC_Status").Value
                Else
                    Status_FloorController_InMasLot = "0"
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Status_FloorController_InMasLot = "0"
        Call mError.ShowError("FloorController", "Status_FloorController_InMasLot", Err.Number, Err.Description)
        FloorController_ID = ""
    End Function
    Function Count_Floor() As String
        On Error GoTo Err
        Count_Floor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT count(*) as Acount FROM Mas_Floor "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                .MoveFirst()
                If Not (.EOF And .BOF) Then
                    Count_Floor = .Fields("Acount").Value
                Else
                    Count_Floor = "0"
                End If
                '   Count_Floor = .RecordCount
            End With
        End If
        Exit Function
Err:
        Count_Floor = "0"
        Call mError.ShowError("นับจำนวนชั้นจอดรถ", "Count_Floor", Err.Number, Err.Description)
    End Function
End Module
