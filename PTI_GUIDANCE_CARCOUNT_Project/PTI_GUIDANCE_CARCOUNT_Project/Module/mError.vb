Option Strict Off
Option Explicit On
Module mError

    Public IsDebug_Mode As Boolean
    Public isShowPopErr As Boolean
    Public isShowMsgBox As Boolean
    Public isWriteErr As Boolean
    Public isIgnorErr As Boolean
    Public isSendErr As Boolean
    Public isSendProcess As Boolean
    Public isShowTrans As Boolean
    Public isShowConnect As Boolean

    Public ErrCount As Long

    Public isThaiErr As Boolean
    Public isCkCPUIdle As Boolean
    Public LimitCPUIdle As Short
    Public isOverIDle As Boolean
    Public isMonBG As Boolean
    Public MonTransParent As Short
    Public isSetting As Boolean
    Public EventErr As Boolean

    Function GetErrString(ByRef ErrNum As Integer) As String
        Dim a As Integer
        Dim aBuff As New System.Text.StringBuilder(250)
        Dim aErrfile As String
        aErrfile = My.Application.Info.DirectoryPath & "\ErrorCode.lst"
        a = GetPrivateProfileString("ErrorDict", Str(ErrNum), "", aBuff, 250, aErrfile)
        If a > 0 Then
            GetErrString = Left(aBuff.ToString, a)

        Else
            GetErrString = ""
        End If



    End Function


    Sub WriteError(ByRef f As String, ByRef Evnt As String, Optional ByVal ErNo As String = "", Optional ByVal ErDesc As String = "")

        mError.EventErr = True
        If Not isWriteErr Then Exit Sub
        Dim aFile, Msg As String
        Dim aFree As Integer
        If Dir(My.Application.Info.DirectoryPath & "\ErrLOG", FileAttribute.Directory) = "" Then MkDir((My.Application.Info.DirectoryPath & "\ErrLOG"))
        aFile = My.Application.Info.DirectoryPath & "\ErrLOG\" & Format(Now, "yyyy_MM") & ".LOG"

        Msg = Format(Now, "dd-MM-yyyy HH:mm:ss") & " : " & f & " : " & Evnt & " ErrNo : " & ErNo & " ErrDescript : " & ErDesc
        If isThaiErr Then Msg = Msg & " : " & GetErrString(Err.Number)

        aFree = FreeFile()
        FileOpen(aFree, aFile, OpenMode.Append)
        Do While Not EOF(aFree) : Loop
        PrintLine(aFree, Msg)
        FileClose(aFree)

    End Sub

    Sub ShowError(ByRef f As String, ByRef Evnt As String, Optional ByVal ErNo As String = "", Optional ByVal ErDesc As String = "")
        Try
        mError.EventErr = True
        If Not isWriteErr Then Exit Sub
        Dim aFile, Msg As String
        Dim aFree As Integer
        If Dir(My.Application.Info.DirectoryPath & "\ErrLOG", FileAttribute.Directory) = "" Then MkDir((My.Application.Info.DirectoryPath & "\ErrLOG"))
        aFile = My.Application.Info.DirectoryPath & "\ErrLOG\" & Format(Now, "yyyy_MM") & ".LOG"
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Msg = Format(Now, "dd-MM-yyyy HH:mm:ss") & " : ตรวจพบความผิดพลาด ที่ " & f & " : " & Evnt & " เลขที่ Err No : " & ErNo & " รายละเอียดข้อผิดพลาด Err Descript : " & ErDesc
        If isThaiErr Then Msg = Msg & " : " & GetErrString(Err.Number)
        aFree = FreeFile()
        FileOpen(aFree, aFile, OpenMode.Append)
        Do While Not EOF(aFree) : Loop
        PrintLine(aFree, Msg)
        FileClose(aFree)

        If isShowMsgBox Then MsgBox(Msg, CType(MsgBoxStyle.Information + vbOKOnly, MsgBoxStyle), "Error Handle From " & My.Application.Info.AssemblyName)
        Catch ex As Exception

        End Try

    End Sub


    Sub ShowErrorPop(ByRef f As String, ByRef Evnt As String)

        mError.EventErr = True
        Dim aFile, Msg As String
        Dim aFree As Integer
        aFile = My.Application.Info.DirectoryPath & "\ErrLOG\" & Format(Now, "yyyy_MM") & ".LOG"

        If Dir(My.Application.Info.DirectoryPath & "\ErrLOG", FileAttribute.Directory) = "" Then MkDir((My.Application.Info.DirectoryPath & "\ErrLOG"))

        Msg = Now & " : " & f & " : " & Evnt & " : " & Err.Number & " : " & Err.Description
        If isThaiErr Then Msg = Msg & " : " & GetErrString(Err.Number)

        If isWriteErr = True Then
            aFree = FreeFile()
            FileOpen(aFree, aFile, OpenMode.Append)
            Do While Not EOF(aFree) : Loop
            PrintLine(aFree, Msg)
            FileClose(aFree)
        End If


    End Sub

End Module