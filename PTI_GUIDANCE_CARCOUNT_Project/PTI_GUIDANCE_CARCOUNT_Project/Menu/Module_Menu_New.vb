Module Module_Menu_New
    Dim CDB As New CDatabase

    Dim btn As Button
    Dim padding_space As Integer = 120
    Dim i As Integer = 0

    Sub PlaySoundFile()
        Dim path As String = "on.wav"
        ''Dim path As String = "beep-1.wav"
        My.Computer.Audio.Play(path, _
            AudioPlayMode.WaitToComplete)
        'Process.Start("D:\Sound\alarm.wav")
    End Sub

    Function Isnull(ByVal value As String, ByVal value_return As String)
        Try
            If IsDBNull(value) = True Or value = "" Then
                Isnull = value_return
            Else
                Isnull = value
            End If
        Catch ex As Exception
            Isnull = value
        End Try
    End Function

    Function Log_In(ByVal txt_password As String, ByVal txt_user_id As String) As Boolean
        'Dim CDB As New CDatabase
        Log_In = False
        Try
            '      [User_ID]
            ',[User_Name]
            ',[User_PWD]
            ',[User_FirstName]
            ',[User_LastName]
            ',[User_FirstName_TH]
            ',[User_LastName_TH]
            ',[User_Dept]
            ',[User_Type]
            ',[User_Position]
            sql = "SELECT [User_ID],[User_Name],Convert(nVarchar(50),[User_PWD]) as User_PWD,[User_FirstName],[User_LastName],[Cancel],User_Position FROM Mas_User WHERE User_Name = '" & txt_user_id & "'"

            Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("Cancel").ToString = "1" Then
                    MsgBox(msg_login_Cancel)
                    IsLogIN_Mode = False
                    Exit Function
                End If


                'CurUser_Pwd = Decrypt_password(dt.Rows(0).Item("User_PWD").ToString)
                CurUser_Pwd = dt.Rows(0).Item("User_PWD").ToString
                If txt_password = CurUser_Pwd Then
                    '------------- login success -------
                    CurUser_ID = "" & dt.Rows(0).Item("User_ID").ToString
                    User_ID = CurUser_ID
                    CurPosition = "" & dt.Rows(0).Item("User_Position").ToString
                    CurUser_Name = "" & dt.Rows(0).Item("User_Name").ToString
                    CurUser_FirstName = "" & dt.Rows(0).Item("User_FirstName").ToString
                    CurUser_LastName = "" & dt.Rows(0).Item("User_LastName").ToString
                    ' CurUser_Pwd = "" & CurUser_Pwd
                    CurUser_FullName = "" & CurUser_FirstName & " " & CurUser_LastName
                    Log_In = True
                    IsLogIN_Mode = True
                    Call mUser.LogIN(CurUser_ID)


                Else
                    Dim frm As New Dg_msg_Error
                    frm.message = msg_Login_fail
                    frm.ShowDialog()
                    frm.Dispose()
                    CurUser_Pwd = ""
                    IsLogIN_Mode = False
                End If

                IsSetting_Mode = True
                Log_In = False
                IsLogIN_Mode = False
                'Me.Close()
            Else
                CurUser_ID = ""
                Dim frm As New Dg_msg_Error
                frm.message = msg_Login_fail
                frm.ShowDialog()
                frm.Dispose()

                'MsgBox(msg_Login_fail)
                IsLogIN_Mode = False
            End If

        Catch ex As Exception
            Call mError.ShowError("Log In", "Log IN", Err.Number, Err.Description)
        End Try
        Return True
    End Function
End Module
