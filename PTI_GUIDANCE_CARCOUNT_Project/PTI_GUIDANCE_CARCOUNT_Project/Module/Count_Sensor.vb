Module Count_Sensor
    Function CountSensor(ByVal Floor_Id As String) As String
        On Error GoTo Err
        CountSensor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = "SELECT Count(*) as C_Sonser FROM Mas_Lot where HW_Floor_No = " & Floor_Id & ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                CountSensor = .Fields("C_Sonser").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        CountSensor = "0"
        Call mError.ShowError("mCountCar", "CountSensor ", Err.Number, Err.Description)
    End Function
    Function FloorControll_Sensor(ByVal FloorController_Id As String) As String
        On Error GoTo Err
        FloorControll_Sensor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = "SELECT Floorcontroller_Max_Lot FROM Mas_Floorcontroller where Floorcontroller_Id = " & FloorController_Id & ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                FloorControll_Sensor = .Fields("Floorcontroller_Max_Lot").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        FloorControll_Sensor = "0"
        Call mError.ShowError("mCountCar", "CountSensor ", Err.Number, Err.Description)
    End Function

    Function Cout_by_Condition(ByVal Connection As String, ByVal Condition As String, ByRef ValueReturn As String) As String
        Cout_by_Condition = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try
            If OpenCnn(Connection, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(Condition)
                    Cout_by_Condition = .Fields("" & ValueReturn & "").Value
                End With
            End If
            Conn = Nothing
            rs = Nothing
            Exit Function
        Catch ex As Exception
            ' Call mError.ShowError("mCountCar", "Cout_by_Condition ", Err.Number, Err.Description)
        End Try

    End Function
End Module
