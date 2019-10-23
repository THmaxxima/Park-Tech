Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Cryptography.Lib
Imports System.Security.Cryptography

Public Class frmUser
  '  Public mAuthen As New nAuthen.cAuthen

    Private MainSql As String = ""
    Dim ActionFlag As String
    Dim Tmp_File_Pict As String
    Dim Tmp_Save_Pict As String
    Dim cdb As New CDatabase
    Private Property VB6 As Object


    Private Sub frmUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsLog_Process Then Call mUser.Guidance_Log_User_Process(CurUser_ID, "0012", "VIEW_USER", "ดูรายการผู้ใช้ระบบ", Me.Name)

        Call Me.AddListGroup()
        Call Me.AddListPosition()
        Call Me.AddListDept()
        lstMenu.Enabled = False
        cmdAddPict.Enabled = False
        cmdSaveMenu.Enabled = False
        cmdEditMenu.Enabled = False
        Ck_IsPermit.Enabled = False
        CK_PermitAll.Enabled = False
        cboAppGroup.Enabled = False

        List_Gender()
        Lock_Object()
        Call Me.LoadUserList("")
    End Sub
    Sub List_Gender()
        With cboMGender
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .SelectedIndex = 0
        End With

    End Sub

    Sub Lock_Object()
        txtUser_Name.Enabled = False
        Ck_Cancel_User.Enabled = False
        txtUser_FirstName.Enabled = False
        txtUser_LastName.Enabled = False
        txtUser_FirstName_TH.Enabled = False
        txtUser_LastName_TH.Enabled = False
        cboDept.Enabled = False
        cboPosition.Enabled = False
        cboMGender.Enabled = False
        txtUser_Phone.Enabled = False
        txtUser_Detail.Enabled = False
        txtUser_Address.Enabled = False

    End Sub
    Sub UnLock_Object()
        txtUser_Name.Enabled = True
        Ck_Cancel_User.Enabled = True
        txtUser_FirstName.Enabled = True
        txtUser_LastName.Enabled = True
        txtUser_FirstName_TH.Enabled = True
        txtUser_LastName_TH.Enabled = True
        cboDept.Enabled = True
        cboPosition.Enabled = True
        cboMGender.Enabled = True
        txtUser_Phone.Enabled = True
        txtUser_Detail.Enabled = True
        txtUser_Address.Enabled = True

    End Sub
   

    Private Sub cmdUser_Permission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUser_Permission.Click
        If lbUser_ID.Text = "" Then Exit Sub
        Dim frm As New frmUser_Permission
        With frm
            mForm.Set_Standard_Form(frm)
            .lbUser_ID.Text = lbUser_ID.Text
            .StartPosition = FormStartPosition.CenterScreen
            .userFullName = txtUser_FirstName.Text & "  " & txtUser_LastName.Text
            .ShowDialog()
            .Dispose()
        End With


    End Sub


    Sub AddListGroup()
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim rst As New ADODB.Stream

        sql = " Select * From Mas_Menu_Group WHERE Applicate_Name = '" & My.Application.Info.AssemblyName & "' AND (IsCommit = 1) ORDER BY Group_ID "

        If OpenCnn(ConStr_Master, ConnMaster) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(ConnMaster)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    cboAppGroup.Items.Clear()
                    .MoveFirst()
                    Do While Not .EOF
                        cboAppGroup.Items.Add("" & rs.Fields("Group_ID").Value & ":" & rs.Fields("Group_Name").Value & ":" & rs.Fields("Group_Caption").Value)
                        .MoveNext()
                    Loop
                Else
                    cboAppGroup.Items.Clear()

                End If
            End With
        End If
    End Sub

    Sub AddListDept()
        'On Error GoTo Err_Renamed
        'Dim Conn As New ADODB.Connection
        'Dim rs As New ADODB.Recordset
        Dim sql As String

        sql = " Select Dept_ID,Dept_ID + ':' + Dept_Name AS Name_ From Mas_DepartMent " 'WHERE Applicate_Name = '" & app.EXEName & "'"
        sql = sql & " ORDER BY Dept_ID"

        Try
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                cboDept.DataSource = dt
                cboDept.DisplayMember = "Name_"
                cboDept.ValueMember = "Dept_ID"
            End If


        Catch ex As Exception
            Call mError.ShowError(Me.Name, "AddListDept", Err.Number, Err.Description)
        End Try

    End Sub
    Sub AddListPosition()
        Dim sql As String
        sql = " Select Pos_ID,Pos_ID + ':' + Pos_Name AS Name_ From Mas_User_Position " 'WHERE Applicate_Name = '" & app.EXEName & "'"
        sql = sql & " ORDER BY Pos_ID"
        Try
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                cboPosition.DataSource = dt
                cboPosition.DisplayMember = "Name_"
                cboPosition.ValueMember = "Pos_ID"
            End If


        Catch ex As Exception
            Call mError.ShowError(Me.Name, "AddListPosition", Err.Number, Err.Description)
        End Try
    End Sub

    Function CHK_Menu_Permit(ByRef pUser_ID As String, ByRef pGroup_ID As String, ByRef pMenu_ID As String, ByRef pAppName As String) As Boolean
        'On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConStr_Master, Conn) Then

            sql = "SELECT Can_Open FROM User_Authen WHERE USER_ID = '" & pUser_ID & "'"
            sql = sql & " AND Menu_Group_ID = '" & pGroup_ID & "'"
            sql = sql & " AND Menu_ID = '" & pMenu_ID & "'"
            sql = sql & " AND Applicate_Name = '" & pAppName & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    CHK_Menu_Permit = .Fields("Can_Open").Value
                Else
                    CHK_Menu_Permit = False
                End If

            End With

        End If


        rs = Nothing
        Exit Function
Err_Renamed:
        CHK_Menu_Permit = False
        Call mError.ShowError(Me.Name, "CHK_Menu_Permit", Err.Number, Err.Description)

    End Function

    Sub Dis_Ctrl()

        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdSave.Enabled = False
        cmdCancel.Enabled = False


    End Sub

    Function IsUser_Authen_Group(ByRef pApp As String, ByRef pGroup_ID As String, ByRef pUser_ID As String) As Boolean
        'on errr goto err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        If OpenCnn(ConStr_Master, Conn) Then

            sql = " SELECT *  From User_Authen_Group "
            sql = sql & " Where (User_ID = '" & pUser_ID & "')"
            sql = sql & " AND Applicate_Name = '" & pApp & "'"
            sql = sql & " AND Group_ID = '" & pGroup_ID & "'"
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If .Fields("Permit").Value = 1 Then

                        IsUser_Authen_Group = True
                    Else
                        IsUser_Authen_Group = False
                    End If
                Else
                    IsUser_Authen_Group = False
                End If
            End With
        Else
            IsUser_Authen_Group = False
        End If


        Exit Function
Err_Renamed:
        IsUser_Authen_Group = False
        Call mError.ShowError(Me.Name, "Ck_User_Authen_Group", Err.Number, Err.Description)
    End Function

    Sub Clear_Data()
        lbUser_ID.Text = "" '& .Fields("User_ID").value
        txtUser_Name.Text = "" '& .Fields("User_Name").value
        txtUser_FirstName.Text = "" '& .Fields("User_FirstName").value
        txtUser_LastName.Text = "" '& .Fields("User_LastName").value
        txtUser_Address.Text = "" '& .Fields("User_Address").value
        txtUser_Detail.Text = "" '& .Fields("User_Detail").value
        txtUser_Phone.Text = "" '& .Fields("User_Phone").value
    End Sub

    Sub Delete_User(ByRef PID As String)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean


        If OpenCnn(ConStr_Master, Conn) Then

            sql = " DELETE FROM Mas_User WHERE User_ID = '" & PID & "'"
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            sql = " DELETE FROM Mas_User_Detail WHERE User_ID = '" & PID & "'"
            Conn.Execute(sql)
            If MsgBox("คุณต้องการลบข้อมูลผู้ใช่ระบบ ใช่ หรือ ไม่ ?..", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Dim pMsg_Log As String = "ลบผู้ใช้งาน รหัส " & lbUser_ID.Text & " ชื่อผู้ใช้ " & txtUser_Name.Text
                Call mUser.Guidance_Log_User_Process(CurUser_ID, "0004", "MEMBER", pMsg_Log, Me.Name)
                BitSendData = True
                TrnFlg = False
                Call Me.LoadUserList("")
                Call Clear_User_Detail_Data()
            Else
                Call Me.LoadUserList("")
                Exit Sub
            End If
        End If


    End Sub

    Function Gen_User_ID() As String
        Gen_User_ID = "0001"
        Try
            Dim sql As String = ""
            sql = " SELECT TOP 1 USER_ID FROM Mas_User WHERE User_ID < 8000  ORDER BY USER_ID DESC"
            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)

            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0).ToString <> "" Then
                    Gen_User_ID = (CInt(DT.Rows(0).Item(0).ToString) + 1).ToString.PadLeft(4, "0")
                End If
            End If
        Catch ex As Exception
        End Try
    End Function


    Function Get_Array(ByRef pString As String, ByRef pDelimiter As String, ByRef pArr As Short) As String
        On Error GoTo Err_Renamed
        Dim a As Object
        Dim I As Short

        a = Split(pString, pDelimiter)
        Get_Array = a(pArr)
        Exit Function
Err_Renamed:
        Get_Array = ""
        Call mError.ShowError(Me.Name, "Get_Array", Err.Number, Err.Description)
    End Function

    Function Get_Dept_From_ID(ByRef PID As String) As String
        On Error GoTo Err
        Get_Dept_From_ID = ""
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        sql = " Select * From Mas_DepartMent WHERE Dept_ID = '" & PID & "'"


        If OpenCnn(ConStr_Master, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    Get_Dept_From_ID = "" & .Fields("Dept_ID").Value & ":" & .Fields("Dept_Name").Value

                Else
                    Get_Dept_From_ID = ""

                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Dept_From_ID = ""
        Call mError.ShowError(Me.Name, "Get_Dept_From_ID", Err.Number, Err.Description)

    End Function

    Function Get_Position_From_ID(ByRef PID As String) As String
        On Error GoTo Err
        Get_Position_From_ID = ""
        Dim sql As String
        Dim rs As New ADODB.Recordset
        Dim Conn As New ADODB.Connection
        sql = " Select * From Mas_User_Position WHERE Pos_ID ='" & PID & "'"


        If OpenCnn(ConStr_Master, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorType = ADODB.CursorTypeEnum.adOpenStatic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    Get_Position_From_ID = "" & .Fields("Pos_ID").Value & ":" & .Fields("Pos_Name").Value

                Else
                    Get_Position_From_ID = ""

                End If
            End With
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Get_Position_From_ID = ""
        Call mError.ShowError(Me.Name, "Get_Position_From_ID", Err.Number, Err.Description)
    End Function

    Sub ListMenu(ByRef pGroupID As String)
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        sql = "SELECT * FROM Mas_Menu WHERE Menu_Group_ID = '" & pGroupID & "' AND (IsCommit = 1) ORDER BY Menu_ID"
        Dim tl As Integer
        If OpenCnn(ConStr_Master, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.BOF And .EOF) Then
                    lstMenu.Items.Clear()
                    .MoveFirst()
                    Do While Not .EOF
                        tl = lstMenu.Items.Count
                        Dim New_Ent As ListViewItem = lstMenu.Items.Add(rs.Fields("Menu_ID").Value)
                        With New_Ent
                            Dim i As Integer
                            For i = 0 To lstMenu.Columns.Count - 1
                                .SubItems.Add("" & rs.Fields("Menu_Group_ID").Value)
                                .SubItems.Add("" & rs.Fields("Applicate_Name").Value)
                                .SubItems.Add("" & rs.Fields("Menu_Name").Value)
                                .SubItems.Add("" & rs.Fields("Menu_Caption").Value)
                                .SubItems.Add("" & rs.Fields("Menu_Desc").Value)

                                Debug.Print("MENU = " & rs.Fields("Menu_ID").Value)
                                Debug.Print("GRP = " & rs.Fields("Menu_Group_ID").Value)
                                Debug.Print("App = " & rs.Fields("Applicate_Name").Value)
                                Debug.Print("Menu Name = " & rs.Fields("Menu_Name").Value)
                                Debug.Print("" & rs.Fields("Menu_Caption").Value)
                                Debug.Print("" & rs.Fields("Menu_Desc").Value)


                            Next

                            Debug.Print(lbUser_ID.Text & " : " & lstMenu.Items.Item(tl).SubItems(0).Text & " : " & lstMenu.Items.Item(tl).Text & " : " & lstMenu.Items.Item(tl).SubItems(1).Text)

                            New_Ent.Checked = Me.CHK_Menu_Permit((lbUser_ID.Text), lstMenu.Items.Item(tl).SubItems(1).Text, lstMenu.Items.Item(tl).Text, lstMenu.Items.Item(tl).SubItems(2).Text)

                        End With
                        .MoveNext()
                    Loop

                    cmdEditMenu.Enabled = True
                Else

                    lstMenu.Items.Clear()
                    cmdEditMenu.Enabled = False
                End If
            End With
        End If



        lstMenu.Enabled = False
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "ListMenu", Err.Number, Err.Description)
    End Sub

    Sub Load_User_Detail(ByRef pUser_ID As String)
      
        Dim sql As String
        lstMenu.Items.Clear()

        sql = "SELECT U.*,D.* FROM Mas_User AS U  LEFT OUTER JOIN Mas_User_Detail AS D ON D.User_ID = U.User_ID WHERE U.User_ID = '" & pUser_ID & "'"

      
        Try

      
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then

            lbUser_ID.Text = "" & dt.Rows(0).Item("User_ID").ToString
            txtUser_Name.Text = "" & dt.Rows(0).Item("User_Name").ToString
            txtUser_FirstName.Text = "" & dt.Rows(0).Item("User_FirstName").ToString
            txtUser_LastName.Text = "" & dt.Rows(0).Item("User_LastName").ToString
            txtUser_FirstName_TH.Text = "" & dt.Rows(0).Item("User_FirstName_TH").ToString
            txtUser_LastName_TH.Text = "" & dt.Rows(0).Item("User_LastName_TH").ToString
            txtUser_Address.Text = "" & dt.Rows(0).Item("User_Address").ToString
            txtUser_Detail.Text = "" & dt.Rows(0).Item("User_Detail").ToString
            txtUser_Phone.Text = "" & dt.Rows(0).Item("User_Phone").ToString

                cboDept.SelectedValue = dt.Rows(0).Item("User_Dept").ToString
                cboPosition.SelectedValue = dt.Rows(0).Item("User_Position").ToString
                Ck_Cancel_User.CheckState = IIf(dt.Rows(0).Item("Cancel").ToString = "1", System.Windows.Forms.CheckState.Checked, System.Windows.Forms.CheckState.Unchecked)
            cboMGender.Text = "" & dt.Rows(0).Item("User_Gender").ToString
            If Not mDB.Load_Pict_To_Byte(ConStr_Master, "Mas_User_Detail", "User_ID", "User_Picture", "" & dt.Rows(0).Item("User_ID").ToString, (Me.ImgUser)) Then
                ImgUser.Image = ImgUser.ErrorImage
                ImgUser.Visible = True

                cmdAddPict.Enabled = True
                cmdSaveMenu.Enabled = False
                Me.Ck_IsPermit.Enabled = False
                CK_PermitAll.Enabled = False
                cmdSaveMenu.Enabled = False
                cmdEditMenu.Enabled = True
                cmdResetPWD.Enabled = True
                cboAppGroup.Enabled = True
            End If
        Else
            cmdResetPWD.Enabled = False
            cmdAddPict.Enabled = False
            cmdSaveMenu.Enabled = False
            Me.Ck_IsPermit.Enabled = False
            CK_PermitAll.Enabled = False
            cmdSaveMenu.Enabled = False
            cmdEditMenu.Enabled = False
        End If
   
       
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_User_Detail", Err.Number, Err.Description)
        End Try
    End Sub

    Sub LoadUserList(ByVal condition As String)
        Try


            sql = " Select * from Mas_User " & condition
            'If CDbl(CurUser_ID) > 7900 Then sql = " Select * from Mas_User "


            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            Me.lstUser.Items.Clear()
            If DT.Rows.Count > 0 Then
                For ii As Integer = 0 To DT.Rows.Count - 1
                    Dim New_Ent As ListViewItem = lstUser.Items.Add("" & DT.Rows(ii).Item("User_ID").ToString)
                    With New_Ent
                        For i As Integer = 0 To lstUser.Columns.Count - 1
                            .SubItems.Add("" & DT.Rows(ii).Item("User_Name").ToString)
                            .SubItems.Add("" & DT.Rows(ii).Item("User_FirstName").ToString)
                            .SubItems.Add("" & DT.Rows(ii).Item("User_LastName").ToString)
                            .SubItems.Add(mUser.Get_Department_Name("" & DT.Rows(ii).Item("User_Dept").ToString))
                            .SubItems.Add(mUser.Get_Position_Name("" & DT.Rows(ii).Item("User_Position").ToString))
                            .SubItems.Add(DT.Rows(ii).Item("User_PWD").ToString)
                            .SubItems.Add("" & DT.Rows(ii).Item("User_Gender").ToString)

                            If Not (DT.Rows(ii).Item("Cancel").ToString = "1") Then
                                '.ForeColor = System.Drawing.ColorTranslator.FromOle(&H80000008)
                                .ForeColor = Color.SlateBlue 'ActiveCaption()
                            Else
                                .ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF) '&HFF&
                            End If
                        Next
                    End With
                Next

                Call Dis_Ctrl()
                cmdAdd.Enabled = True
                Call Clear_User_Detail_Data()
            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "LoadUserList", Err.Number, Err.Description)
        End Try
    End Sub

    Sub SrcUserList(ByVal psql As String)
        On Error GoTo Err
        Dim sql As String = ""
        Dim User_Gender As String = ""
        Dim rs As New ADODB.Recordset
        Dim rst As New ADODB.Stream
        Dim tl As Integer = 0
        If OpenCnn(ConStr_Master, ConnUser) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(ConnUser)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .LockType = ADODB.LockTypeEnum.adLockOptimistic
                .Open(psql)

                If Not (.EOF And .BOF) Then
                    Me.lstUser.Items.Clear()
                    .MoveFirst()
                    Do While Not .EOF

                        Dim New_Ent As ListViewItem = lstUser.Items.Add(rs.Fields("User_ID").Value)
                        With New_Ent
                            Dim i As Integer
                            For i = 0 To lstUser.Columns.Count - 1
                                .SubItems.Add("" & rs.Fields("User_Name").Value)
                                .SubItems.Add("" & rs.Fields("User_FirstName").Value)
                                .SubItems.Add("" & rs.Fields("User_LastName").Value)
                                .SubItems.Add(mUser.Get_Department_Name("" & rs.Fields("User_Dept").Value))
                                .SubItems.Add(mUser.Get_Position_Name("" & rs.Fields("User_Position").Value))
                                .SubItems.Add(CipherUtility.Decrypt(Of AesManaged)(rs.Fields("User_PWD").Value, "cps10mtl", "salt")) 'mAuthen.Decrypt("" & rs.Fields("User_PWD").Value, VB.Right(rs.Fields("User_Name").Value, 1))
                                If DBNull(rs.Fields("User_Gender").Value) Then
                                    User_Gender = ""
                                Else
                                    User_Gender = rs.Fields("User_Gender").Value
                                End If
                                .SubItems.Add("" & User_Gender)
                            Next
                            If Not (rs.Fields("Cancel").Value = 1) Then
                                .ForeColor = Color.SlateBlue 'ActiveCaption()
                            Else
                                .ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF) '&HFF&
                            End If

                        End With
                        .MoveNext()
                    Loop
                    Call Dis_Ctrl()
                    cmdAdd.Enabled = True
                    Call Clear_User_Detail_Data()
                Else
                    Me.lstUser.Items.Clear()
                End If
            End With
        End If

        Exit Sub
Err:
        'Call mError.ShowError(Me.Name, "SrcUserList", Err.Number, Err.Description)
    End Sub

    Sub Save_Menu()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean

        sql = " Delete From User_Authen "
        sql = sql & " Where ([User_ID] = '" & lbUser_ID.Text & "')"
        sql = sql & " AND [Applicate_Name] = '" & My.Application.Info.AssemblyName & "'"
        sql = sql & " AND Menu_Group_ID = '" & VB.Left(cboAppGroup.Text, 4) & "'"

        Dim Permit As Short
        If OpenCnn(ConStr_Master, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)

            sql = " Delete From User_Authen_Group "
            sql = sql & " Where (User_ID = '" & lbUser_ID.Text & "')"
            sql = sql & " AND Applicate_Name = '" & My.Application.Info.AssemblyName & "'"
            sql = sql & " AND Group_ID = '" & mMain.Get_Array((Me.cboAppGroup.Text), ":", 0) & "'"
            Conn.Execute(sql)

            sql = " Insert into User_Authen_Group (User_ID,Applicate_Name,Group_ID,Group_Name, "
            sql = sql & " Group_Caption,Permit)"
            sql = sql & " Values ( '" & lbUser_ID.Text & "',"
            sql = sql & "'" & My.Application.Info.AssemblyName & "',"
            sql = sql & "'" & mMain.Get_Array((Me.cboAppGroup.Text), ":", 0) & "',"
            sql = sql & "'" & mMain.Get_Array((Me.cboAppGroup.Text), ":", 1) & "',"
            sql = sql & "'" & mMain.Get_Array((Me.cboAppGroup.Text), ":", 2) & "',"
            sql = sql & "" & Ck_IsPermit.CheckState & ")"

            Conn.Execute(sql)


            If Ck_IsPermit.CheckState = 1 Then
                For I = 0 To lstMenu.Items.Count - 1
                    If lstMenu.Items.Item(I).Checked = True Then
                        sql = " Insert into User_Authen (User_ID,Menu_ID,Menu_Group_ID,Applicate_Name, "
                        sql = sql & " Menu_Name,Form_Name,Menu_Caption,Can_Open)"

                        sql = sql & " Values ( '" & lbUser_ID.Text & "',"
                        sql = sql & "'" & lstMenu.Items.Item(I).Text & "',"
                        sql = sql & "'" & lstMenu.Items.Item(I).SubItems(1).Text & "',"
                        sql = sql & "'" & lstMenu.Items.Item(I).SubItems(2).Text & "',"
                        sql = sql & "'" & lstMenu.Items.Item(I).SubItems(3).Text & "',"
                        sql = sql & "'" & lstMenu.Items.Item(I).SubItems(3).Text & "',"
                        sql = sql & "'" & lstMenu.Items.Item(I).SubItems(4).Text & "',"
                        sql = sql & "" & 1 & ")"
                        Conn.Execute(sql)
                    End If
                Next
            End If
            If (MsgBox("คุณต้องการบันทึกข้อมูล สิทธิ์ของผู้ใช้นี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes) Then
                '             cmdEditMenu.Enabled=True
                Conn.CommitTrans()
                lstMenu.Enabled = False
                Ck_IsPermit.Enabled = False
                cmdSaveMenu.Enabled = False
                TrnFlg = False
                Exit Sub
            Else
                Conn.RollbackTrans()
                TrnFlg = False
                'cmdSaveMenu.Enabled = False
            End If


        End If

        rs = Nothing
        Exit Sub
Err_Renamed:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "Save_Menu", Err.Number, Err.Description)
    End Sub

    Sub Save_User_Detail()

        'Dim Conn As New ADODB.Connection
        'Dim rs As New ADODB.Recordset
        Dim sql As String = ""
        Dim sql_detail As String = ""
        Dim sql_delete As String = ""
        Dim TrnFlg As Boolean
        Dim LastUser_ID As String
        If txtUser_Name.Text = "" Then MsgBox("กรุณาระบุชื่อผู้ใช้งาน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : txtUser_Name.Focus() : Exit Sub
        If txtUser_FirstName.Text = "" Then MsgBox("กรุณาระบุชื่อผู้ใช้งาน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : txtUser_FirstName.Focus() : Exit Sub
        If cboDept.Text = "" Then MsgBox("กรุณาระบุแผนกของผู้ใช้งาน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : cboDept.Focus() : Exit Sub
        If cboPosition.Text = "" Then MsgBox("กรุณาระบุระดับของผู้ใช้งาน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : cboPosition.Focus() : Exit Sub
        If cboMGender.Text = "" Then
            MsgBox("กรุณาเลือกเพศผู้ใช้งานให้ถูกต้อง  ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : cboMGender.Focus()
            cboMGender.Enabled = True
            Exit Sub
        End If

        Dim User_Focus As String = ""

        'If OpenCnn(ConStr_Master, Conn) Then
        '    Conn.BeginTrans()
        '    TrnFlg = True

        Try

       
        Dim pMsg_Log As String = ""
        Select Case ActionFlag
            Case "ADD"
                LastUser_ID = Gen_User_ID()
                If Check_Name_Exist(txtUser_Name.Text) Then MsgBox("ชื่อผู้ใช้นี้มีการใช้ในระบบแล้ว กรุณาเปลี่ยนชื่อผู้ใช้ ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Exit Sub

                lbUser_ID.Text = LastUser_ID
                User_Focus = LastUser_ID
                sql = " INSERT INTO Mas_User (User_ID,User_Name,User_PWD,User_FirstName,User_LastName,User_FirstName_TH,User_LastName_TH, "
                sql = sql & " User_Dept,User_Position,Cancel,User_Gender)"

                sql = sql & " VALUES ('" & LastUser_ID & "',"
                sql = sql & "'" & txtUser_Name.Text & "',"
                sql = sql & "'" & Encrypt_password(DEFULT_PWD) & "'," 'mAuthen.Encrypt(DEFULT_PWD, VB.Right(txtUser_Name.Text, 1)) 
                sql = sql & "'" & txtUser_FirstName.Text & "',"
                sql = sql & "'" & txtUser_LastName.Text & "',"
                sql = sql & "'" & txtUser_FirstName_TH.Text & "',"
                sql = sql & "'" & txtUser_LastName_TH.Text & "',"
                sql = sql & "'" & Me.Get_Array((cboDept.Text), ":", 0) & "',"
                sql = sql & "'" & Get_Array((cboPosition.Text), ":", 0) & "',"
                sql = sql & "'" & Me.Ck_Cancel_User.CheckState & "',"
                sql = sql & "'" & cboMGender.Text & "')"


                sql_detail = " INSERT INTO Mas_User_Detail (User_ID,User_Name,User_FirstName,User_LastName,User_Phone,User_Address,User_Detail,Cancel) "
                sql_detail = sql_detail & " VALUES ('" & LastUser_ID & "',"
                sql_detail = sql_detail & "'" & txtUser_Name.Text & "',"
                sql_detail = sql_detail & "'" & txtUser_FirstName.Text & "',"
                sql_detail = sql_detail & "'" & txtUser_LastName.Text & "',"
                sql_detail = sql_detail & "'" & txtUser_Phone.Text & "',"
                sql_detail = sql_detail & "'" & txtUser_Address.Text & "',"
                sql_detail = sql_detail & "'" & txtUser_Detail.Text & "',"
                sql_detail = sql_detail & "" & Me.Ck_Cancel_User.CheckState & ")"

                pMsg_Log = "เพิ่มผู้ใช้งาน รหัส " & lbUser_ID.Text & " ชื่อผู้ใช้ " & txtUser_Name.Text
            Case "EDIT"
                User_Focus = lbUser_ID.Text
                sql = " UPDATE Mas_User SET User_Name = '" & txtUser_Name.Text & "',"
                sql = sql & " User_FirstName = '" & txtUser_FirstName.Text & "',"
                sql = sql & " User_LastName = '" & txtUser_LastName.Text & "',"
                sql = sql & " User_FirstName_TH = '" & txtUser_FirstName_TH.Text & "',"
                sql = sql & " User_LastName_TH = '" & txtUser_LastName_TH.Text & "',"
                sql = sql & " User_Dept = '" & Me.Get_Array((cboDept.Text), ":", 0) & "',"
                sql = sql & " User_Position = '" & Get_Array((cboPosition.Text), ":", 0) & "',"
                sql = sql & " Cancel = " & Me.Ck_Cancel_User.CheckState & ","
                sql = sql & " User_Gender = '" & cboMGender.Text & "'"
                    sql = sql & " WHERE USER_ID = '" & lbUser_ID.Text & "'"

                    sql_delete = "DELETE FROM Mas_User_Detail WHERE User_ID='" & lbUser_ID.Text & "'"

                    sql_detail = " INSERT INTO Mas_User_Detail (User_ID,User_Name,User_FirstName,User_LastName,User_Phone,User_Address,User_Detail,Cancel) "
                    sql_detail = sql_detail & " VALUES ('" & lbUser_ID.Text & "',"
                    sql_detail = sql_detail & "'" & txtUser_Name.Text & "',"
                    sql_detail = sql_detail & "'" & txtUser_FirstName.Text & "',"
                    sql_detail = sql_detail & "'" & txtUser_LastName.Text & "',"
                    sql_detail = sql_detail & "'" & txtUser_Phone.Text & "',"
                    sql_detail = sql_detail & "'" & txtUser_Address.Text & "',"
                    sql_detail = sql_detail & "'" & txtUser_Detail.Text & "',"
                    sql_detail = sql_detail & "" & Me.Ck_Cancel_User.CheckState & ")"


                pMsg_Log = "แก้ไขผู้ใช้งาน รหัส " & lbUser_ID.Text & " ชื่อผู้ใช้ " & txtUser_Name.Text
        End Select

        If MsgBox("คุณต้องการบันทึกข้อมูลผู้ใช้งานนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then

                    cdb.ExcuteNoneQury(sql_delete, ConStr_Master)

                    cdb.ExcuteNoneQury(sql_detail, ConStr_Master)

                    If ActionFlag = "ADD" Then
                        MsgBox(msg_save(0))
                    Else
                        MsgBox(msg_update(0))
                    End If
                    Call mUser.Guidance_Log_User_Process(CurUser_ID, "0004", "MEMBER", pMsg_Log, Me.Name)

                    If ActionFlag = "ADD" Then Call Reset_User_Password_New()
                    BitSendData = True
                    If Not (Tmp_Save_Pict = "") Then Call mDB.Save_Pict_To_DB(ConStr_Master, "Mas_User_Detail", "User_ID", "User_Picture", lbUser_ID.Text, Tmp_Save_Pict)
                    Tmp_Save_Pict = ""

                    TrnFlg = False
                    Call Clear_User_Detail_Data()
                    If Not User_Focus = "" Then Call Me.Load_User_Detail(User_Focus)
                    lstMenu.Items.Clear()
                    cmdAddPict.Enabled = False
                End If
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Save_User_Detail", Err.Number, Err.Description)
            User_Focus = ""
        End Try
      

    End Sub
    Private Sub cboDept_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboDept.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub cboAppGroup_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboAppGroup.SelectedIndexChanged
        If lbUser_ID.Text = "" Then Exit Sub
        If cboAppGroup.Text = "" Then Exit Sub
        If IsUser_Authen_Group(My.Application.Info.AssemblyName, mMain.Get_Array((Me.cboAppGroup.Text), ":", 0), (lbUser_ID.Text)) Then
            Call Me.ListMenu(mMain.Get_Array((Me.cboAppGroup.Text), ":", 0))
            Me.Ck_IsPermit.CheckState = System.Windows.Forms.CheckState.Checked
            Ck_IsPermit.Enabled = False
            lstMenu.Enabled = False
        Else
            Call Me.ListMenu(mMain.Get_Array((Me.cboAppGroup.Text), ":", 0))
            Me.Ck_IsPermit.CheckState = System.Windows.Forms.CheckState.Unchecked
            Ck_IsPermit.Enabled = False
            lstMenu.Enabled = False
        End If
        cmdSaveMenu.Enabled = False
    End Sub

    Private Sub cboAppGroup_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboAppGroup.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub cboPosition_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles cboPosition.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub Ck_IsPermit_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ck_IsPermit.CheckStateChanged
        Dim I As Short
        If Ck_IsPermit.CheckState = 1 Then
            lstMenu.Enabled = True
            If Not lstMenu.Items.Count = 0 Then lstMenu.Items.Item(0).Checked = True
            CK_PermitAll.Enabled = True
        Else
            lstMenu.Enabled = False
            CK_PermitAll.CheckState = 0
            CK_PermitAll.Enabled = False
            For I = 0 To lstMenu.Items.Count - 1
                lstMenu.Items.Item(I).Checked = False
            Next
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        On Error GoTo Err_Renamed
        ActionFlag = "ADD"
        Tmp_Save_Pict = ""
        Call Dis_Ctrl()
        cmdCancel.Enabled = True
        cmdSave.Enabled = True
        cboMGender.Enabled = True
        cmdAddPict.Enabled = False
        Call Clear_User_Detail_Data()
        Call UnLock_User_Control()
        UnLock_Object()
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "cmdAdd", Err.Number, Err.Description)
    End Sub

    Private Sub cmdAddPict_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddPict.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String

        With Dlg
            .Title = "Select Picture"
            .Filter = "Graphic Files (*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg"
            '.Flags = &H1000S Or &H800S
            .ShowDialog()
            Tmp_Save_Pict = .FileName : ImgUser.Visible = True
            ImgUser.Image = System.Drawing.Image.FromFile(Tmp_Save_Pict)



        End With
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "cmdAddPict_Click", Err.Number, Err.Description)
    End Sub

    Private Sub cmdCancel_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ActionFlag = "CANCEL"
        Tmp_Save_Pict = ""
        Call Clear_User_Detail_Data()
        Call Lock_User_Control()
        Lock_Object()
        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdSave.Enabled = True
        cmdCancel.Enabled = True
        cmdAddPict.Enabled = True
        cboAppGroup.Enabled = True
    End Sub

    Private Sub cmdDel_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
        If lbUser_ID.Text = "" Then Exit Sub
        ActionFlag = "DELETE"
        cmdAddPict.Enabled = False
        Call Delete_User((lbUser_ID.Text))
        Tmp_Save_Pict = ""
        cboAppGroup.Enabled = False
    End Sub
    Private Sub cmdEdit_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If lbUser_ID.Text = "" Then Exit Sub
        ActionFlag = "EDIT"
        Call Dis_Ctrl()
        cmdCancel.Enabled = True
        cmdSave.Enabled = True
        cboMGender.Enabled = True
        Tmp_Save_Pict = ""
        cboAppGroup.Enabled = False
        Call UnLock_User_Control()
        UnLock_Object()
        cmdAddPict.Enabled = True
    End Sub


    Private Sub cmdEditMenu_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditMenu.Click
        Me.Ck_IsPermit.Enabled = True
        If Ck_IsPermit.CheckState = 1 Then lstMenu.Enabled = True Else lstMenu.Enabled = False
        cmdSaveMenu.Enabled = True

    End Sub


    Private Sub cmdSave_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        cboMGender.Enabled = False
        Call Me.Save_User_Detail()
        Dim Position As String = ""
        If CurUser_ID = "" Then CurUser_ID = lbUser_ID.Text
        Position = CurPosition
        Try
            If Position <> 5 Then
                cmdUser_Permission.Enabled = False
            Else
                cmdUser_Permission.Enabled = True
            End If
        Catch ex As Exception

        End Try

        Lock_Object()
    End Sub

    Private Sub cmdSaveMenu_Click(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveMenu.Click
        Call Me.Save_Menu()
    End Sub


    Sub Clear_User_Detail_Data()
        lbUser_ID.Text = ""
        txtUser_Name.Text = ""
        txtUser_FirstName.Text = ""
        txtUser_LastName.Text = ""
        txtUser_FirstName_TH.Text = ""
        txtUser_LastName_TH.Text = ""
        txtUser_Address.Text = ""
        txtUser_Detail.Text = ""
        txtUser_Phone.Text = ""
        cboDept.Text = ""
        cboPosition.Text = ""
        Ck_Cancel_User.CheckState = System.Windows.Forms.CheckState.Unchecked

        cboAppGroup.Text = ""
        lstMenu.Items.Clear()
        Ck_IsPermit.CheckState = System.Windows.Forms.CheckState.Unchecked
        ImgUser.Image = ImgUser.ErrorImage
        cmdSaveMenu.Enabled = False
        cmdEditMenu.Enabled = False
        cboAppGroup.Enabled = False
        Call Lock_User_Control()
    End Sub

    Sub Lock_User_Control()
        txtUser_Name.ReadOnly = True
        txtUser_FirstName.ReadOnly = True
        txtUser_LastName.ReadOnly = True
        txtUser_FirstName_TH.ReadOnly = True
        txtUser_LastName_TH.ReadOnly = True
        txtUser_Address.ReadOnly = True
        txtUser_Detail.ReadOnly = True
        txtUser_Phone.ReadOnly = True
        cboDept.Enabled = False
        cboPosition.Enabled = False
        Ck_Cancel_User.Enabled = False
        cboAppGroup.Enabled = False
        lstMenu.Enabled = False
        Ck_IsPermit.Enabled = False

    End Sub

    Sub UnLock_User_Control()
        txtUser_Name.ReadOnly = False
        txtUser_FirstName.ReadOnly = False
        txtUser_LastName.ReadOnly = False
        txtUser_FirstName_TH.ReadOnly = False
        txtUser_LastName_TH.ReadOnly = False
        txtUser_Address.ReadOnly = False
        txtUser_Detail.ReadOnly = False
        txtUser_Phone.ReadOnly = False
        cboDept.Enabled = True
        cboPosition.Enabled = True
        Ck_Cancel_User.Enabled = True
        cboAppGroup.Enabled = False
        lstMenu.Enabled = False
        Ck_IsPermit.Enabled = False

    End Sub
    Function PopImg(ByVal pUser_ID As String) As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = "", TrnFlg As Boolean
        sql = "SELECT User_Picture FROM Mas_User_Detail WHERE User_ID = '" & pUser_ID & "'"

        If OpenCnn(ConStr_Master, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    If Not IsDBNull(.Fields("User_Picture").Value) Then
                        Dim RetByte() As Byte = CType(.Fields("User_Picture").Value, Byte())
                        Dim PictureData() As Byte = RetByte
                        Dim Ms As New System.IO.MemoryStream(PictureData)
                        ImgPop.Image = Image.FromStream(Ms)
                        PopImg = True
                    Else
                        PopImg = False
                    End If
                Else
                    PopImg = False
                End If
            End With
        End If
        Exit Function
Err:

        Call mError.ShowError(Me.Name, "PopImg", Err.Number, Err.Description)
        PopImg = False
    End Function




    Private Sub lstUser_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstUser.ItemSelectionChanged
        Dim nItem As ListViewItem = lstUser.FocusedItem

        If PopImg(lstUser.FocusedItem.Text) Then

            Ppop.Top = nItem.Position.Y
            Ppop.Left = lstUser.Width - 40
            Ppop.Visible = True
        Else
            Ppop.Visible = False
        End If
    End Sub

    Private Sub lstUser_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUser.MouseLeave
        Ppop.Visible = False
    End Sub


    Private Sub cmdLoadAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadAll.Click
        Dim find As String = " WHERE User_ID <> '' "
        If txtFindID.Text = "" And txtFindName.Text = "" And txtFindID.Text = "" And txtFindFirstName.Text = "" Then
            LoadUserList("")
        Else
            If txtFindID.Text <> "" Then find &= " and User_ID = '" & txtFindID.Text & "'"
            If txtFindName.Text <> "" Then find &= " and User_Name LIKE '%" & txtFindName.Text & "%'"
            If txtFindFirstName.Text <> "" Then find &= " and User_FirstName LIKE '%" & txtFindFirstName.Text & "%'"
            LoadUserList(find)
        End If
    End Sub

    Private Sub cmdResetPWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResetPWD.Click
        Call Reset_User_Password()
    End Sub
    Sub Reset_User_Password()
        Try
            sql = "UPDATE Mas_User SET User_PWD = '" & Encrypt_password(DEFULT_PWD) & "'"
            sql = sql & " WHERE User_ID = '" & lbUser_ID.Text & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                MsgBox(msg_update(0))
                Dim pMsg_Log As String = "Reset รหัสผู้ใช้งาน รหัส " & lbUser_ID.Text & " ชื่อผู้ใช้ " & txtUser_Name.Text
                Call mUser.Guidance_Log_User_Process(CurUser_ID, "0004", "MEMBER", pMsg_Log, Me.Name)
            Else
                MsgBox(msg_update(1))
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Reset Password", Err.Number, Err.Description)
        End Try
    End Sub
    Sub Reset_User_Password_New()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = "", TrnFlg As Boolean
        sql = "UPDATE Mas_User SET User_PWD = '" & CipherUtility.Encrypt(Of AesManaged)("1234", "cps10mtl", "salt") & "'" 'mAuthen.Encrypt("1234", VB.Right(txtUser_Name.Text, 1))
        sql = sql & " WHERE User_ID = '" & lbUser_ID.Text & "'"
        If OpenCnn(ConStr_Master, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            Conn.CommitTrans()
            TrnFlg = False
        End If
        Exit Sub
Err:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "Reset Password", Err.Number, Err.Description)
    End Sub
    Private Sub Print_User_Detail(ByVal pIsShow_IMG As Boolean)
        If lstUser.Items.Count = 0 Then Exit Sub
        Dim nRptID = "", nRptGroupID = "", nRptFile = "", nRptConfig = "", nRptTitle As String = ""
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""

        Dim LayOutID As String = ""
        If pIsShow_IMG Then
            LayOutID = Get_LayOutID("Print_User_List_With_Image")
        Else
            LayOutID = Get_LayOutID("Print_User_List")
        End If

        If LayOutID = "" Then Exit Sub
        sql = "SELECT * FROM [Report_Menu] WHERE [Rpt_ID] = '" & LayOutID & "'"

        If OpenCnn(ConStr_Master, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    nRptID = "" & .Fields("Rpt_ID").Value
                    nRptGroupID = "" & .Fields("Rpt_Group_ID").Value
                    nRptFile = "" & .Fields("Rpt_Name").Value
                    nRptConfig = "" & .Fields("Rpt_Config_File").Value
                    nRptTitle = "" & .Fields("Rpt_Caption").Value
                    sql = MainSql
                    Debug.Print(sql)
                    Dim nRptCmd As String = "PRINT" & "|" & CurUser_ID & "|" & nRptID & "|" & nRptGroupID & "|" & nRptFile & "|" & nRptConfig & "|" & nRptTitle & "|" & sql & "|" & True & "|" & True
                    Debug.Print(nRptCmd)
                    Dim nRptFilePath As String = Report_Path & "\ReportViewer.exe " & nRptCmd
                    Shell(nRptFilePath, AppWinStyle.NormalFocus)

                Else
                    MsgBox("Invalid Report ID", CType(MsgBoxStyle.Information + vbOKOnly, MsgBoxStyle), "Report Config Checking") : Exit Sub
                End If
            End With
        Else
            MsgBox("Data Base Connection Fail", CType(MsgBoxStyle.Information + vbOKOnly, MsgBoxStyle), "Report Config Checking") : Exit Sub

        End If
    End Sub

    Private Sub cmdPrintUserList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintUserList.Click
        Call Me.Print_User_Detail(CK_ShowImg.Checked)
    End Sub

    Private Sub lstUser_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstUser.DoubleClick
        If lstUser.Items.Count = 0 Then Exit Sub

        Call Me.Load_User_Detail(lstUser.FocusedItem.Text)
        cmdDel.Enabled = True
        cmdEdit.Enabled = True
        If Not lbUser_ID.Text = "" Then cboAppGroup.Enabled = True Else cboAppGroup.Enabled = False
        Dim Position As String = ""
        If CurUser_ID = "" Then Exit Sub
        Position = CurPosition
        If Position <> "5" Or Position <> 5 Then
            cmdUser_Permission.Enabled = False
        Else
            cmdUser_Permission.Enabled = True
        End If
    End Sub

    Private Sub CK_PermitAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_PermitAll.CheckedChanged
        If CK_PermitAll.CheckState = 1 Then
            For i As Integer = 0 To lstMenu.Items.Count - 1
                lstMenu.Items(i).Checked = True
            Next
        Else
            For i As Integer = 0 To lstMenu.Items.Count - 1
                lstMenu.Items(i).Checked = False
            Next
        End If

    End Sub

    Private Sub cmdCopyPermit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyPermit.Click
        Call Clone_Permit()
    End Sub
    Sub Clone_Permit()
        On Error GoTo Err
        Dim nUser As String = VB.InputBox("Choose Source User ID For Clonning ")
        If nUser = "" Then Exit Sub
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, TrnFlg As Boolean, sql As String = "SELECT * FROM [User_Authen_Group] "
        sql &= " WHERE [User_ID] = '" & nUser & "' AND [Applicate_Name] = '" & My.Application.Info.AssemblyName & "' ORDER BY [Group_ID]"

        If OpenCnn(ConStr_Master, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    Conn.BeginTrans()
                    TrnFlg = True
                    Do While Not .EOF
                        Dim sqlClone As String = "INSERT INTO [User_Authen_Group] ([User_ID],[Applicate_Name],[Group_ID],[Group_Name],[Group_Caption],[Permit])"
                        sqlClone &= " VALUES ('" & "" & lbUser_ID.Text & "','" & .Fields("Applicate_Name").Value & "','" & .Fields("Group_ID").Value & "',"
                        sqlClone &= "'" & .Fields("Group_Name").Value & "','" & .Fields("Group_Caption").Value & "','" & .Fields("Permit").Value & "')"
                        Conn.Execute(sqlClone)
                        .MoveNext()
                    Loop
                Else
                    Dim nMsgBox As String = " This User Not Permit"
                    MsgBox("User ID [" & nUser & "] " & Get_Alert_Msg(Me.Name.ToString, "Clone_Permit", nMsgBox), MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                    If TrnFlg = True Then Conn.RollbackTrans()
                    Exit Sub
                End If
            End With

            sql = "SELECT * FROM [User_Authen] "
            sql &= " WHERE [User_ID] = '" & nUser & "' AND [Applicate_Name] = '" & My.Application.Info.AssemblyName & "' ORDER BY [Menu_Group_ID],[Menu_ID]"
            With rs
                If .State = 1 Then .Close()
                .ActiveConnection = Conn
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    .MoveFirst()
                    If TrnFlg = False Then Conn.BeginTrans()
                    TrnFlg = True
                    Do While Not .EOF
                        Dim sqlClone As String = "INSERT INTO [User_Authen] ([User_ID],[Applicate_Name],[Form_Name],[Menu_Group_ID],[Menu_ID],[Menu_Name]"
                        sqlClone &= ",[Menu_Caption],[Can_Open],[Can_Create],[Can_Edit],[Can_Delete])"
                        sqlClone &= " VALUES ('" & "" & lbUser_ID.Text & "','" & .Fields("Applicate_Name").Value & "','" & .Fields("Form_Name").Value & "',"
                        sqlClone &= "'" & .Fields("Menu_Group_ID").Value & "','" & .Fields("Menu_ID").Value & "','" & .Fields("Menu_Name").Value & "',"
                        sqlClone &= "'" & .Fields("Menu_Caption").Value & "','" & .Fields("Can_Open").Value & "','" & .Fields("Can_Create").Value & "',"
                        sqlClone &= "'" & .Fields("Can_Edit").Value & "','" & .Fields("Can_Delete").Value & "')"
                        Conn.Execute(sqlClone)
                        .MoveNext()
                    Loop
                Else
                    Dim nMsgBox As String = " This User Not Permit"
                    MsgBox("User ID [" & nUser & "] " & Get_Alert_Msg(Me.Name.ToString, "Clone_Permit", nMsgBox), MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                    If TrnFlg = True Then Conn.RollbackTrans()
                    Exit Sub
                End If
            End With

            If MsgBox("คุณต้องการคัดลอกสิทะการใช้งานจาก (" & nUser & ") สู่ผู้ใช้งาน (" & lbUser_ID.Text & ") ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                TrnFlg = False
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If

        End If


        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Clone_Permit", Err.Number, Err.Description)
    End Sub

    Private Sub cmdChangePWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePWD.Click
        If lbUser_ID.Text = "" Or txtUser_Name.Text = "" Then MsgBox("   กรุณาเลือกผู้ใช้งาน    ?..", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle)) : Exit Sub
        If txtNewPWD.Text = "" Then MsgBox("     กรุณาใส่รหัสผ่านใหม่        ?..", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle)) : txtNewPWD.Focus() : Exit Sub
        If txtConfirmPWD.Text = "" Then MsgBox("     กรุณายืนยันรหัสผ่าน        ?..", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle)) : txtConfirmPWD.Focus() : Exit Sub
        If Not (txtNewPWD.Text = txtConfirmPWD.Text) Then MsgBox("การยืนยันรหัสผ่านไม่ถูกต้อง ?..", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle)) : Exit Sub
        Call Update_PWD(lbUser_ID.Text)
    End Sub
    Sub Update_PWD(ByVal pUser_ID As String)
        Try
        sql = "UPDATE Mas_User SET User_PWD = '" & Encrypt_password(txtConfirmPWD.Text) & "'"
        sql = sql & " WHERE User_ID = '" & pUser_ID & "'"
        If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
            If MsgBox("คุณต้องการเปลี่ยนรหัสผ่าน ของ " & txtUser_FirstName.Text & "  " & txtUser_LastName.Text & " ใช่ หรือ ไม่ ?..", CType(MsgBoxStyle.Question + vbYesNo, MsgBoxStyle), "Password Reset Confirmation") = MsgBoxResult.Yes Then
                Dim pMsg_Log As String = "เปลี่ยน รหัสผู้ใช้งาน รหัส " & lbUser_ID.Text & " ชื่อผู้ใช้ " & txtUser_Name.Text
                Call mUser.Guidance_Log_User_Process(CurUser_ID, "0004", "MEMBER", pMsg_Log, Me.Name)
                txtNewPWD.Text = ""
                txtConfirmPWD.Text = ""
                MessageBox.Show("เปลี่ยนรหัสผ่านเรียบร้อย")
            Else
            End If
        Else

            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Update_PWD", Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmUser_Permission_By_Level
        With frm
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub txtNewPWD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewPWD.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtConfirmPWD.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtNewPWD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewPWD.TextChanged

    End Sub

    Private Sub txtConfirmPWD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConfirmPWD.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmdChangePWD.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtConfirmPWD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConfirmPWD.TextChanged

    End Sub

    Private Function DBNull(ByVal p1 As Object) As Boolean
        Throw New NotImplementedException
    End Function

End Class