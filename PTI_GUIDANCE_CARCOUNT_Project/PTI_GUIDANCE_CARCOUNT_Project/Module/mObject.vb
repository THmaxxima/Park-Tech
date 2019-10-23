Imports System
Imports System.Data
Imports System.Data.SqlClient
Module mObject
    Public Sub Set_Status_Off_Line_On_Line(ByVal Picture_Box As PictureBox, ByVal Status As String)
        With Picture_Box
            .Visible = True
            Select Case Status
                Case "0"
                    .Image = .ErrorImage
                Case "1"
                    .Image = .Image
            End Select
        End With
    End Sub

    Sub Load_Size_Lot()
        Public_Size_X = 0
        Public_Size_Y = 0
        Dim sql As String = ""
        Try
            Con = New SqlConnection(ConStr_Master)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Master
                .Open()
            End With
        Catch ex As Exception

        End Try


        Try

            sql &= " SELECT [ID]"
            sql &= ",[Size_X]"
            sql &= ",[Size_Y]"
            sql &= "FROM [Mas_Size_Lot]"
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Mas_Size_Lot")
            Con.Close()
            If sqlDs.Tables("Mas_Size_Lot").Rows.Count <> 0 Then
                Public_Size_X = CInt(sqlDs.Tables("Mas_Size_Lot").Rows(0)(1).ToString())
                Public_Size_Y = CInt(sqlDs.Tables("Mas_Size_Lot").Rows(0)(2).ToString())
            End If
        Catch ex As Exception
            Con.Close()
            Public_Size_X = 10
            Public_Size_Y = 11
        End Try

        If Public_Size_X = 0 Then
            Public_Size_X = 10
        End If

        If Public_Size_Y = 0 Then
            Public_Size_Y = 11
        End If
    End Sub

End Module
