Module Color_Alam
    Function Select_Status_Color_Alam(ByVal Time As String) As String
        Try
            Select_Status_Color_Alam = ""
            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim sql As String
            sql = "SELECT Status_Alarm_Id FROM Mas_Status_Alarm where " & Time & " between Status_Alarm_Time_Min and Status_Alarm_Time_Max and Status_Alarm_Id <>2 "
            If OpenCnn(ConnStrGuidance, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    .Open(sql)
                    Select_Status_Color_Alam = .Fields("Status_Alarm_Id").Value
                End With
            End If
            Conn = Nothing
            rs = Nothing
            Exit Function
        Catch ex As Exception
            Select_Status_Color_Alam = "0"
            Call mError.ShowError("Color_Alam", "Update_Status_Color_Alam", Err.Number, Err.Description)
        End Try
    End Function

End Module
