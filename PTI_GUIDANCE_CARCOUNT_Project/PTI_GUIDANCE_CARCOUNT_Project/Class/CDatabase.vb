Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Drawing.Imaging

Public Class CDatabase
    Friend conStr As String = "Data Source=.\;Initial Catalog=MTL_MASTER;Persist Security Info=True;User ID=sa;Password=cps10mtl"
    Friend ConStrCarlog As String = "Data Source=.\;Initial Catalog=MTL_CARLOG;Persist Security Info=True;User ID=sa;Password=cps10mtl"
    'Public cs As New SqlConnection(conStr)
    Public cs As New SqlConnection(conStr)
    '===========สร้างตัวแปรอินสแตนส์ของ ADO.NET=========='
    Friend connection As SqlConnection
    Friend command As SqlCommand
    Friend ds As New DataSet
    Friend da As SqlDataAdapter
    Friend bingdingSrc As BindingSource
    Friend reader As SqlDataReader
    Friend reader2 As SqlDataReader
    Friend sql As String
    Friend cmb As SqlCommandBuilder
    Friend cmd As New SqlCommand
    Friend cmd2 As New SqlCommand
    '-----------------------------------------------
    Friend image2 As System.Drawing.Bitmap
    Public Overloads Sub ConnectDB(ByVal pcs As SqlConnection)
        With pcs
            .Close()
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
    End Sub
    Public Overloads Sub ConnectDB()
        With cs
            .Close()
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
    End Sub
    '======= อ่านข้อมูล ส่งออกเป็น Data Reader
    Public Overloads Function readdata(ByVal sql As String) As SqlDataReader
        Try
            ConnectDB()
            command = New SqlCommand(sql, cs)
            reader = command.ExecuteReader
            'Return reader
        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ readdata( " & sql & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("readdata :" & sql & ":" & ex.Message)
        End Try
        Return reader
    End Function

    Public Overloads Function ExcuteNoneQury(ByVal sql As String) As Boolean
        Try
            ConnectDB()
            command = New SqlCommand(sql, cs)
            command.ExecuteNonQuery()
            cs.Dispose()
            'Return reader
        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ ExcuteNoneQury( " & sql & " ) => " & ex.Message)
            cs.Dispose()
            'writeError(ex.Message)
            writeError("ExcuteNoneQury :" & sql & ":" & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Overloads Function ExcuteNoneQury(ByVal sql As String, ByVal parth As String) As Boolean
        Try
            cs = New SqlConnection(parth)
            ConnectDB(cs)
            command = New SqlCommand(sql, cs)


            If command.ExecuteNonQuery() > 0 Then
                cs.Dispose()
                Return True
            Else
                Return False
            End If

            'Return reader
        Catch ex As Exception

            cs.Dispose()
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ ExcuteNoneQury( " & sql & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("ExcuteNoneQury :" & sql & ":" & ex.Message)
            Return False
        End Try
        Return True
    End Function
    Public Overloads Function ExcuteNoneQury(ByVal sql As String, ByVal parth As String, ByVal timeOut As Integer) As Boolean
        Try
            cs = New SqlConnection(parth)
            ConnectDB(cs)

            command = New SqlCommand(sql, cs)
            command.CommandTimeout = timeOut
            If command.ExecuteNonQuery() > 0 Then
                cs.Dispose()
                Return True
            Else
                Return False
            End If
            'Return reader
        Catch ex As Exception
            cs.Dispose()
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ ExcuteNoneQury( " & sql & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("ExcuteNoneQury :" & sql & ":" & ex.Message)
            Return False
        End Try
        Return True
    End Function
    Public Function GetPingMs(ByRef hostNameOrAddress As String)
        Dim ping As New System.Net.NetworkInformation.Ping
        Return ping.Send(hostNameOrAddress).RoundtripTime
    End Function

    Public Overloads Function readdata(ByVal sql As String, ByVal parth As String) As SqlDataReader
        Try

            cs = New SqlConnection(parth)
            ConnectDB(cs)
            command = New SqlCommand(sql, cs)
            reader = command.ExecuteReader
            'cs.Dispose()
        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ readdata( " & sql & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("readdata :" & sql & ":" & ex.Message)
        End Try
        Return reader
    End Function
    Public Overloads Function readTableData(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        Try
            ConnectDB()
            Dim ds As New DataSet
            command = New SqlCommand(sql, cs)
            da = New SqlDataAdapter(command)

            da.Fill(ds, 0)

            dt = ds.Tables(0)

            cs.Dispose()
            'Return dt
        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ readTableData( " & sql & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("readTableData :" & sql & ":" & ex.Message)
        End Try
        Return dt
    End Function
    Public Overloads Function readTableData(ByVal sql As String, ByVal conStr As String) As DataTable
        Dim dt As New DataTable
        Try
            cs = New SqlConnection(conStr)
            ConnectDB(cs)
            Dim ds As New DataSet
            command = New SqlCommand(sql, cs)
            da = New SqlDataAdapter(command)
            da.Fill(ds, 0)
            dt = ds.Tables(0)
            cs.Dispose()
            'Return dt
        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ readTableData( " & sql & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("readTableData :" & sql & ":" & ex.Message)
        End Try
        cs.Close()
        Return dt
    End Function
    Public Function InsertData(ByVal tb As String, ByVal field As ArrayList, ByVal parameter As ArrayList, ByVal conStr As String) As Boolean
        Dim str As String = "Insert Into "
        Dim f As String = ""
        Dim p As String = ""
        Try
            str += tb
            str += " ( "
            For Each _field As String In field
                f += _field & ","
            Next
            For Each _data As String In parameter
                p += "'" & _data & "',"
            Next
            str += f.Substring(0, f.Length - 1)
            str += " ) values( "
            str += p.Substring(0, p.Length - 1)
            str += " )"

            cs = New SqlConnection(conStr)
            ConnectDB(cs)
            command = New SqlCommand(str, cs)
            If command.ExecuteNonQuery() > 0 Then
                cs.Dispose()
                Return True
            Else
                cs.Dispose()
                Return False
            End If
        Catch ex As Exception
            cs.Dispose()
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ InsertData( " & str & " ) => " & ex.Message)
            writeError("InsertData :" & sql & ":" & ex.Message)
            Return False
        End Try

    End Function
    Public Function GenSqlInsertData(ByVal tb As String, ByVal field As ArrayList, ByVal parameter As ArrayList, ByVal conStr As String) As String
        Dim str As String = "Insert Into "
        Dim f As String = ""
        Dim p As String = ""
        Try
            str += tb
            str += " ( "
            For Each _field As String In field
                f += _field & ","
            Next
            For Each _data As String In parameter
                p += "'" & _data & "',"
            Next
            str += f.Substring(0, f.Length - 1)
            str += " ) values( "
            str += p.Substring(0, p.Length - 1)
            str += " )"


            Return str
        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ InsertData( " & str & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("GenSqlInsertData :" & sql & ":" & ex.Message)
            Return False
        End Try

    End Function
    Public Function updateData(ByVal tb As String, ByVal field As ArrayList, ByVal parameter As ArrayList, ByVal conStr As String) As Boolean
        Dim str As String = "Update "
        Dim f As String = ""
        Dim p As String = ""
        str += tb & " SET "

        Try
            For i As Integer = 0 To field.Count - 2
                f += field(i + 1) & "='" & parameter(i + 1) & "',"
            Next

            str += f.Substring(0, f.Length - 1) & " where " & field(0) & "='" & parameter(0) & "'"
            cs = New SqlConnection(conStr)
            ConnectDB(cs)
            command = New SqlCommand(str, cs)
            If command.ExecuteNonQuery() > 0 Then
                cs.Dispose()
                Return True
            Else
                cs.Dispose()
                Return False
            End If


        Catch ex As Exception
            cs.Dispose()
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ updateData( " & str & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("updateData :" & sql & ":" & ex.Message)
            Return False
        End Try

    End Function
    Public Function GenSqlupdateData(ByVal tb As String, ByVal field As ArrayList, ByVal parameter As ArrayList, ByVal conStr As String) As String
        Dim str As String = "Update "
        Dim f As String = ""
        Dim p As String = ""
        str += tb & " SET "

        Try
            For i As Integer = 0 To field.Count - 2
                f += field(i + 1) & "='" & parameter(i + 1) & "',"
            Next

            str += f.Substring(0, f.Length - 1) & " where " & field(0) & "='" & parameter(0) & "'"

            Return str

        Catch ex As Exception
            'MsgBox("เกิดการผิดพลาดเกี่ยวกับฐานข้อมูล ในการ updateData( " & str & " ) => " & ex.Message)
            'writeError(ex.Message)
            writeError("GenSqlupdateData :" & sql & ":" & ex.Message)
            Return False
        End Try

    End Function
    Public Sub disconnect()
        If cs.State = ConnectionState.Open Then
            cs.Close()
        End If
    End Sub

    Public Function writeError(ByVal message As String) As Boolean

        Dim file_err As String = Today.Year & "_" & Today.Month.ToString.PadLeft(2, "0") & "_" & Today.Day.ToString.PadLeft(2, "0") & ".txt"
        Dim Path As String = Application.StartupPath & "\EROR\"
        If My.Computer.FileSystem.DirectoryExists(Path) = False Then
            Directory.CreateDirectory(Application.StartupPath & "\EROR\")
        End If

        'If My.Computer.FileSystem.DirectoryExists(Path) = False Then
        Dim myFileStream As New System.IO.FileStream(Path & file_err, FileMode.OpenOrCreate)
        myFileStream.Close()

        Dim objWriter As New System.IO.StreamWriter(Path & file_err, True)
        objWriter.WriteLine(Format(Now, "dd/MM/yyyy") & " " & Format(Now, "HH:mm:ss") & "=> " & message)
        objWriter.Close()
        'End If

        Return True
    End Function
    Public Function writeLog(ByVal message As String) As Boolean
        Dim file_err As String = Today.Year & "_" & Today.Month.ToString.PadLeft(2, "0") & "_" & Today.Day.ToString.PadLeft(2, "0") & ".txt"
        Dim Path As String = Application.StartupPath & "\LogProcess\"
        If My.Computer.FileSystem.DirectoryExists(Path) = False Then
            Directory.CreateDirectory(Application.StartupPath & "\LogProcess\")
        End If

        If My.Computer.FileSystem.DirectoryExists(Path) = True Then
            Dim myFileStream As New System.IO.FileStream(Path & file_err, FileMode.OpenOrCreate)
            myFileStream.Close()

            Dim objWriter As New System.IO.StreamWriter(Path & file_err, True)
            objWriter.WriteLine(Format(Now, "dd/MM/yyyy") & " " & Format(Now, "HH:mm:ss") & "=> " & message)
            objWriter.Close()
        End If

        Return True
    End Function
    Public Function writeLog_Folder(ByVal message As String, ByVal folder As String) As Boolean
        Dim file_err As String = Today.Year & "_" & Today.Month.ToString.PadLeft(2, "0") & "_" & Today.Day.ToString.PadLeft(2, "0") & ".txt"
        Dim Path As String = Application.StartupPath & "\" & folder & "\"
        If My.Computer.FileSystem.DirectoryExists(Path) = False Then
            Directory.CreateDirectory(Application.StartupPath & "\" & folder & "\")
        End If

        If My.Computer.FileSystem.DirectoryExists(Path) = True Then
            Dim myFileStream As New System.IO.FileStream(Path & file_err, FileMode.OpenOrCreate)
            myFileStream.Close()

            Dim objWriter As New System.IO.StreamWriter(Path & file_err, True)
            objWriter.WriteLine(Format(Now, "dd/MM/yyyy") & " " & Format(Now, "HH:mm:ss") & "=> " & message)
            objWriter.Close()
        End If

        Return True
    End Function
    Public Function GetTime_Now()
        Dim str_Now As String = Now.Hour.ToString.PadLeft(2, "0") & ":" & Now.Minute.ToString.PadLeft(2, "0") & ":" & Now.Second.ToString.PadLeft(2, "0")
        Return str_Now
    End Function
    Public Function GetDate_Now()
        Dim str_Now As String = Today.Year & "-" & Today.Month.ToString.PadLeft(2, "0") & "-" & Today.Day.ToString.PadLeft(2, "0")
        Return str_Now
    End Function
    Public Overloads Function GetDate(ByVal DTdate As Date)
        Dim str_Now As String = DTdate.Year & "-" & DTdate.Month.ToString.PadLeft(2, "0") & "-" & DTdate.Day.ToString.PadLeft(2, "0")
        Return str_Now
    End Function
    Public Overloads Function GetDateToDB(ByVal DTdate As Date)
        Dim str_Now As String = DTdate.Year & "-" & DTdate.Month.ToString.PadLeft(2, "0") & "-" & DTdate.Day.ToString.PadLeft(2, "0") & " " & DTdate.Hour.ToString.PadLeft(2, "0") & ":" & DTdate.Minute.ToString.PadLeft(2, "0") & ":" & DTdate.Second.ToString.PadLeft(2, "0")
        Return str_Now
    End Function
    Public Overloads Function GetDateToDB(ByVal DTdate As String)

        Dim str_Now As String = ""
        If DTdate <> "" Then
            str_Now = CDate(DTdate).Year & "-" & CDate(DTdate).Month.ToString.PadLeft(2, "0") & "-" & CDate(DTdate).Day.ToString.PadLeft(2, "0") & " " & CDate(DTdate).Hour.ToString.PadLeft(2, "0") & ":" & CDate(DTdate).Minute.ToString.PadLeft(2, "0") & ":" & CDate(DTdate).Second.ToString.PadLeft(2, "0")
        End If
        Return str_Now
    End Function
    Function CheckPortOpen(ByVal hostname As String, ByVal portnum As Integer) As Boolean

        Dim ipa As IPAddress = CType(Dns.GetHostAddresses(hostname)(0), IPAddress)

        Try
            Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Console.WriteLine("Testing " & hostname & ":" & portnum)
            sock.Connect(ipa, portnum)
            If (sock.Connected = True) Then
                sock.Close()
                sock = Nothing
                Return True
            Else
                Return Nothing
            End If

        Catch sx As SocketException
            If sx.ErrorCode = 10061 Then
                Return False
            Else
                Return Nothing
            End If
        End Try
    End Function

    Function Save_Pict_To_DB_No_Message(ByVal ConStr As String, ByVal pTable As String, ByVal pFields As String, ByVal pPict_Fields As String, ByVal pKey As String, ByVal pFileName As String, ByVal img As Image) As Boolean
        Dim sql As String = ""
        Try

            Save_Pict_To_DB_No_Message = False
            If File.Exists(pFileName) Then
                If pFileName <> "0" Then
                    Dim id As Integer = 1
                    cs = New SqlConnection(ConStr)
                    ConnectDB(cs)
                    'Dim content As Byte() = ImageToStream(pFileName)

                    Dim imgData As Byte()
                    imgData = ImgToByteArray(img, img.RawFormat)

                    Dim cmd As New SqlCommand("UPDATE " & pTable & " SET " & pPict_Fields & "=@img WHERE " & pFields & " ='" & pKey & "'", cs)
                    cmd.Parameters.AddWithValue("@img", imgData)
                    cmd.ExecuteNonQuery()
                    cs.Close()
                    'MsgBox("Image inserted")
                    Save_Pict_To_DB_No_Message = True
                End If
            End If
        Catch ex As Exception
            Save_Pict_To_DB_No_Message = False
            Call mError.ShowError("ฐานข้อมูล", "บันทึกรปภาพ ลงฐานข้อมูล", Err.Number, Err.Description)
        End Try
    End Function
    Private Function ImageToStream(ByVal fileName As String) As Byte()
        Dim stream As New MemoryStream()
tryagain:
        Try
            image2 = New System.Drawing.Bitmap(fileName)
            image2.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            GoTo tryagain
        End Try

        Return stream.ToArray()
    End Function
End Class
