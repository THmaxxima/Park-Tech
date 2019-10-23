Module mCountCar
    Function Get_Count(ByVal Status_ID As String, ByVal Floor_ID As String, ByVal Building_ID As String) As String
        On Error GoTo Err
        Get_Count = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        'and HW_Position_X <>0 and HW_Position_Y <> 0
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT  HW_Status_Id FROM Mas_Lot where HW_Status_Id = '" & Status_ID & _
            "' and HW_Floor_No  = " & Floor_ID & " and HW_Position_X <>0 and HW_Position_Y <> 0 "
            sql &= " and HW_Building_ID = " & Building_ID & ""
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Get_Count = .RecordCount
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Count = "0"
        Call mError.ShowError("mCountCar", "Get_Count", Err.Number, Err.Description)
    End Function
    Function Get_Count_LotInFloor(ByVal Floor_ID As String) As String
        On Error GoTo Err
        Get_Count_LotInFloor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT  Count(*) as Lot FROM Mas_Lot where HW_Floor_No  = " & Floor_ID & _
            " and HW_Position_X <> 0 and HW_Position_Y <> 0"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Get_Count_LotInFloor = .Fields.Item("Lot").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Count_LotInFloor = "0"
        Call mError.ShowError("mCountCar", "Get_Count_LotInFloor", Err.Number, Err.Description)
    End Function
    Function Get_Count_CarInZone(Optional ByVal Zone_ID As String = Nothing, Optional ByVal Floor_ID As String = Nothing, Optional ByVal Building_ID As String = Nothing) As String
        On Error GoTo Err
        Get_Count_CarInZone = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT Count(*) as Value_Zone FROM Mas_Lot where HW_Zone_Id  = " & Zone_ID & _
                  " and HW_Status_Id =0 and HW_Floor_No= " & Floor_ID & _
                  " and HW_Position_X <>0 and HW_Position_Y <> 0"
            sql &= " and HW_Building_ID = " & Building_ID & ""
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Get_Count_CarInZone = .Fields.Item("Value_Zone").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Count_CarInZone = "0"
        Call mError.ShowError("mCountCar", "Get_Count_CarInZone", Err.Number, Err.Description)
    End Function
    Function Get_Floor_Name(ByVal Floor_ID As String) As String
        On Error GoTo Err
        Get_Floor_Name = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT Floor_Name FROM Mas_HW_Floor where Floor_Id = " & Floor_ID & " "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Get_Floor_Name = .Fields("Floor_Name").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Floor_Name = "0"
        Call mError.ShowError("mCountCar", "Get_Floor_Name", Err.Number, Err.Description)
    End Function
    Function Get_Status_Controller(ByVal Controller_ID As String) As String
        On Error GoTo Err
        Get_Status_Controller = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT  * FROM Mas_Floorcontroller where Floorcontroller_Id = '" & Controller_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_Status_Controller = .Fields("Floorcontroller_Status").Value
                Else
                    Get_Status_Controller = "0"
                End If
            End With
        End If


        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Status_Controller = "0"

        Call mError.ShowError("mCountCar", "Get_Status_Controller", Err.Number, Err.Description)
    End Function
    Function Get_Car_IN_Floor(ByVal Floor_ID As String) As String
        On Error GoTo Err
        Get_Car_IN_Floor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrGuidance, Conn) Then
            'sql = "SELECT  * FROM [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Mas_Floorcontroller]where [Floorcontroller_Id] = '" & Floor_ID & "'"
            sql = "SELECT COUNT(Trn_Lot_Id) as Car_In FROM Q_Tran_Lot where HW_Floor_No = " & Floor_ID & _
                  " and Trn_Log_Datetime_In Between '" & Format(Date.Now, "yyyy-MM-dd 00:00:00") & _
                  "' and '" & Format(Date.Now, "yyyy-MM-dd 23:59:59") & _
                  "' and Trn_Log_Datetime_In = Trn_Log_Datetime_Out and Trn_Status_On_Off = 1"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_Car_IN_Floor = .Fields("Car_In").Value
                Else
                    Get_Car_IN_Floor = "0"
                End If

            End With
        End If


        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Car_IN_Floor = "0"

        Call mError.ShowError("mCountCar", "Get_Car_IN_Floor", Err.Number, Err.Description)
    End Function
    Function Get_Car_Out_Floor(ByVal Floor_ID As String) As String
        On Error GoTo Err
        Get_Car_Out_Floor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT COUNT(Trn_Lot_Id) as Car_Out FROM Q_Tran_Lot where HW_Floor_No = " & Floor_ID & _
                  " and Trn_Log_Datetime_Out Between '" & Format(Date.Now, "yyyy-MM-dd 00:00:00") & _
                  "' and '" & Format(Date.Now, "yyyy-MM-dd 23:59:59") & _
                  "' and Trn_Log_Datetime_Out > Trn_Log_Datetime_In and Trn_Status_On_Off = 0"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_Car_Out_Floor = .Fields("Car_Out").Value
                Else
                    Get_Car_Out_Floor = "0"
                End If

            End With
        End If


        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Car_Out_Floor = "0"

        Call mError.ShowError("mCountCar", "Get_Car_Out_Floor", Err.Number, Err.Description)
    End Function
    Function Get_HHCar_IN_Floor(ByVal HH As String) As String
        On Error GoTo Err
        Get_HHCar_IN_Floor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT COUNT(HW_Lot_Id) as Time_HH FROM Mas_Lot where HW_Status_Id = 1 " & _
                  " and HW_Time_HH =" & HH & " and HW_Time_MM >= 0  "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_HHCar_IN_Floor = .Fields("Time_HH").Value
                Else
                    Get_HHCar_IN_Floor = "0"
                End If

            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_HHCar_IN_Floor = "0"
        Call mError.ShowError("mCountCar", "Get_HHCar_IN_Floor", Err.Number, Err.Description)
    End Function
    Function Get_HHCar_IN_Floor_HH0(ByVal HH As String) As String
        On Error GoTo Err
        Get_HHCar_IN_Floor_HH0 = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT COUNT(HW_Lot_Id) as Time_HH FROM Mas_Lot where HW_Status_Id = 1 " & _
                  " and HW_Time_HH =" & HH & " and HW_Time_MM > 0 "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_HHCar_IN_Floor_HH0 = .Fields("Time_HH").Value
                Else
                    Get_HHCar_IN_Floor_HH0 = "0"
                End If

            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_HHCar_IN_Floor_HH0 = "0"
        Call mError.ShowError("mCountCar", "Get_HHCar_IN_Floor_HH0", Err.Number, Err.Description)
    End Function
    Function Get_HHCar_IN_Floor_HH25(ByVal HH As String) As String
        On Error GoTo Err
        Get_HHCar_IN_Floor_HH25 = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT COUNT(HW_Lot_Id) as Time_HH FROM Mas_Lot where HW_Status_Id = 1 " & _
                  " and HW_Time_HH >=" & HH & " and HW_Time_MM >= 0 "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_HHCar_IN_Floor_HH25 = .Fields("Time_HH").Value
                Else
                    Get_HHCar_IN_Floor_HH25 = "0"
                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_HHCar_IN_Floor_HH25 = "0"
        Call mError.ShowError("mCountCar", "Get_HHCar_IN_Floor_HH25", Err.Number, Err.Description)
    End Function
    Function Get_Mas_HW_Floor(ByVal Floor_ID As String) As String
        On Error GoTo Err
        Get_Mas_HW_Floor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql = "SELECT  * FROM [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Mas_HW_Floor]where [Floor_ID] = '" & Floor_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Get_Mas_HW_Floor = .Fields("Floor_Name").Value
                Else
                    Get_Mas_HW_Floor = "0"
                End If

            End With
        End If


        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Mas_HW_Floor = "0"

        Call mError.ShowError("mCountCar", "Get_Mas_HW_Floor", Err.Number, Err.Description)
    End Function
    Function Get_Count_Alam(ByVal Alam_ID As String, ByVal Floor_Id As String, ByVal BuildingID As String) As String
        On Error GoTo Err
        Get_Count_Alam = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        If OpenCnn(ConnStrGuidance, Conn) Then
            sql &= "SELECT COUNT(HW_Status_Alarm_Id) as Alam_No FROM Q_Mas_Lot where HW_Status_Alarm_Id = " & Alam_ID & ""
            sql &= " and HW_Floor_No = " & Floor_Id & ""
            sql &= " and HW_Lot_Type='L' "

            '  sql &= " and HW_Datetime_Update Between'" & Format(Date.Now, "yyyy-MM-dd 00:00:00") & " and '" & Format(Date.Now, "yyyy-MM-dd 23:59:59") & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)

                If Not (.EOF And .BOF) Then
                    Get_Count_Alam = .Fields("Alam_No").Value
                Else
                    Get_Count_Alam = "0"
                End If

            End With
        End If
        Conn = Nothing
        rs = Nothing

        Exit Function

Err:
        Get_Count_Alam = "0"

        Call mError.ShowError("mCountCar", "Get_Count Get_Count_Alam", Err.Number, Err.Description)
    End Function
    Function Get_Status_Color_Alam(ByVal Time_Min As String, ByVal Time_Max As String, ByVal Floor_No As String, ByVal BuildingID As String) As String

        Get_Status_Color_Alam = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try

       
        sql = "SELECT  count(HW_Lot_Id)as AlamNo FROM Mas_Lot where HW_Status_Id = 1  and " & _
              " ((HW_Time_HH*60) + HW_Time_MM) between " & Time_Min & " and " & Time_Max & _
              " and HW_Floor_No =" & Floor_No & " and  HW_Position_X <> 0  and  HW_Position_Y <> 0 "
            sql &= " and HW_Building_ID = " & BuildingID & ""
            sql &= " and HW_Lot_Type ='L' "
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Get_Status_Color_Alam = .Fields(0).Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function

        Catch ex As Exception
            Get_Status_Color_Alam = "0"

            Call mError.ShowError("mCountCar", "Get_Count Get_Status_Color_Alam", Err.Number, Err.Description)

        End Try
    End Function
    Function Get_Status_Color_Alam_False(ByVal Time_Min As String, ByVal Time_Max As String, ByVal Floor_ID As String, ByVal BuildingID As String) As String

        Get_Status_Color_Alam_False = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try


            sql &= " SELECT  count(HW_Lot_Id)as AlamNo FROM Mas_Lot "
            sql &= " where HW_On_Line = 0 "
            sql &= " And HW_Floor_No = " & Floor_ID & " "
            ' sql &= " and ((HW_Time_HH*60) + HW_Time_MM) between " & Time_Min & " and " & Time_Max & " "
            sql &= " and HW_Status_Alarm_Id = 2"
            sql &= " and HW_Position_X <> 0  and  HW_Position_Y <> 0"
            sql &= " and HW_Building_ID = " & BuildingID & ""
            'Choose only L Lot type by maxx 20150925
            sql &= " and HW_Lot_Type='L' "
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    Get_Status_Color_Alam_False = .Fields(0).Value
                End With
            End If
            Conn = Nothing
            rs = Nothing
            Exit Function


        Catch ex As Exception
            Get_Status_Color_Alam_False = "0"

            Call mError.ShowError("mCountCar", "Get_Count Get_Status_Color_Alam_False", Err.Number, Err.Description)

        End Try
    End Function
  
    Function Convert_HH_to_Min(ByVal HH As String, ByVal MM As String) As String
        Try
            Convert_HH_to_Min = (Val(HH) * 60) + Val(MM)
        Catch ex As Exception
            Convert_HH_to_Min = "0"
            Call mError.ShowError("mCountCar", "Get_Count Convert_HH_to_Min", Err.Number, Err.Description)
        End Try
    End Function
    Function Convert_MM_to_HH(ByVal MM As String) As String
        Try
            Convert_MM_to_HH = MM \ 60
        Catch ex As Exception
            Convert_MM_to_HH = MM
            Call mError.ShowError("mCountCar", "Get_Count Convert_MM_to_HH", Err.Number, Err.Description)
        End Try
    End Function
    Function Convert_MM_to_MM(ByVal MM As String) As String
        Try
            Convert_MM_to_MM = MM Mod 60
        Catch ex As Exception
            Convert_MM_to_MM = MM
            Call mError.ShowError("mCountCar", "Get_Count Convert_MM_to_HH", Err.Number, Err.Description)

        End Try
    End Function
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
    Function Convert_Format_Tax(ByVal Tax As String) As String
        Try
            Dim i As Integer
            Convert_Format_Tax = ""
            Dim Num As String
            For i = 1 To Tax.Length
                Num = Mid(Tax, i, 1)
                Select Case i
                    Case 2
                        Convert_Format_Tax = Convert_Format_Tax + "-" + Num
                    Case 5
                        Convert_Format_Tax = Convert_Format_Tax + "-" + Num
                    Case 8
                        Convert_Format_Tax = Convert_Format_Tax + "-" + Num
                    Case Else
                        Convert_Format_Tax = Convert_Format_Tax + Num
                End Select
                'Num = Mid(Tax, i, 1)
                'If Num <> "-" Then
                '    Convert_Format_Tax = Convert_Format_Tax + Num
                'End If
                Num = ""
            Next

        Catch ex As Exception
            Convert_Format_Tax = ""
            Call mError.ShowError("mCountCar", "Get_Count Convert_Tax", Err.Number, Err.Description)

        End Try
    End Function
    Function Value_in_Zone(ByVal Zone_Id As String) As String
        On Error GoTo Err
        Value_in_Zone = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = " SELECT count(*) as VZone FROM Mas_Lot "
        sql &= " where  HW_Status_Id = 0 "
        sql &= " and HW_Zone_Id = " & Zone_Id & ""
        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Value_in_Zone = .Fields("VZone").Value
            End With
        End If
        Conn = Nothing
        Exit Function

Err:
        Value_in_Zone = "0"

        Call mError.ShowError("mCountCar", "Get_Count Value_in_Zone", Err.Number, Err.Description)
    End Function
    Function Value_Status_Sensor(ByVal FloorController_Id As String, ByVal Status As String) As String
        On Error GoTo Err
        Value_Status_Sensor = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = "SELECT count(HW_Net_3) as V_Status FROM Mas_Lot where " & _
              "HW_Floorcontroller_Id = " & FloorController_Id & _
              " and HW_Net_3 = " & Status & ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Value_Status_Sensor = .Fields("V_Status").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Value_Status_Sensor = "0"
        Call mError.ShowError("mCountCar", "Get_Count Value_in_Zone", Err.Number, Err.Description)
    End Function
    Function Floor_ID(ByVal FloorController_Id As String) As String
        On Error GoTo Err
        Floor_ID = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        sql = "SELECT Floor_Id FROM Mas_Floorcontroller " & _
              " where Floorcontroller_Id = " & FloorController_Id & ""

        If OpenCnn(ConnStrGuidance, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                Floor_ID = .Fields("Floor_ID").Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Floor_ID = "0"
        Call mError.ShowError("mCountCar", "Get_Count Floor_ID", Err.Number, Err.Description)
    End Function
    Function Select_Address(ByVal Select_Lot_ID As String, ByVal Field As String) As String

        Select_Address = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Try
            sql = "SELECT " & Field & " FROM Mas_Lot where " & _
                  " HW_Lot_Id  = '" & Select_Lot_ID & "'"
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    Select_Address = .Fields(0).Value
                End With
            End If
            Conn = Nothing
            rs = Nothing

        Catch ex As Exception
            Select_Address = "0"
            Call mError.ShowError("mCountCar", "Selec Address Lot Ultrasonic ", Err.Number, Err.Description)
        End Try

    End Function
    Function Get_Value_AS_Select(ByVal Connection As String, ByVal Table As String, ByVal Field As String, ByVal Condition As String) As String

        Get_Value_AS_Select = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Try
            sql &= " SELECT " & Field & " FROM " & Table & ""
            If Condition <> "" Then sql &= " where " & Condition
            If OpenCnn(Connection, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    Get_Value_AS_Select = .Fields(0).Value
                End With
            End If
            Conn = Nothing
            rs = Nothing

        Catch ex As Exception
            Get_Value_AS_Select = "0"
            Call mError.ShowError("mCountCar", "Get_Value_AS_Select ", Err.Number, Err.Description)
        End Try

    End Function
    Function Count_By_Condition(ByVal Condition As String, ByVal Connection As String) As String
        On Error GoTo Err
        Count_By_Condition = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If OpenCnn(Connection, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(Condition)
                Count_By_Condition = .Fields(0).Value
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Count_By_Condition = "0"
        Call mError.ShowError("mCountCar : Count_By_Condition", "นับจำนวนตามเงื่อนไขที่เลือก", Err.Number, Err.Description)
    End Function
End Module
