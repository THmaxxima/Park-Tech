'Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmProfile_User
    'Public mAuthen As New nAuthen.cAuthen

    Dim CDB As New CDatabase
    Private Sub frmUserProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Load_User_Profiles(CurUser_ID)

        Dim aVal As String = ""
        If Get_Config("APPCONFIG", "AUTOHIDE_MAINMENU", Config_Path, aVal) Then
            CK_AutoHideMenu.Checked = CBool(aVal)
        Else
            CK_AutoHideMenu.Checked = False
            IsAutoHideMainMenu_Mode = False
            'Call frmMain.Resize_Menu()
        End If
    End Sub

    Sub frm_Load()
        Call Load_User_Profiles(CurUser_ID)

        Dim aVal As String = ""
        If Get_Config("APPCONFIG", "AUTOHIDE_MAINMENU", Config_Path, aVal) Then
            CK_AutoHideMenu.Checked = CBool(aVal)
        Else
            CK_AutoHideMenu.Checked = False
            IsAutoHideMainMenu_Mode = False
            'Call frmMain.Resize_Menu()
        End If


    End Sub

    Sub Load_User_Profiles(ByVal pUser As String)

        Dim sql As String = ""
        Try

       
        sql = "SELECT U.*,D.* FROM Mas_User AS U "
        sql = sql & " LEFT OUTER JOIN Mas_User_Detail AS D ON D.User_ID = U.User_ID WHERE U.User_ID = '" & pUser & "'"

        Dim DT As DataTable = CDB.readTableData(sql, ConStr_Master)

        If DT.Rows.Count > 0 Then
            Call Me.Clear_User_Data()
                lbUserID.Text = "" & DT.Rows(0).Item("User_ID").ToString

                txtUser_Name.Text = "" & DT.Rows(0).Item("User_Name").ToString
                txtUser_First_Name_EN.Text = "" & DT.Rows(0).Item("User_FirstName").ToString
                txtUser_Last_Name_EN.Text = "" & DT.Rows(0).Item("User_LastName").ToString
                txtUser_First_Name_TH.Text = "" & DT.Rows(0).Item("User_FirstName_TH").ToString
                txtUser_Last_Name_TH.Text = "" & DT.Rows(0).Item("User_LastName_TH").ToString

                lbDepartMent.Text = "" & mUser.Get_Department_Name("" & DT.Rows(0).Item("User_Dept").ToString)
                lbPosition.Text = "" & mUser.Get_Position_Name("" & DT.Rows(0).Item("User_Position").ToString)
                txtUser_Address.Text = "" & DT.Rows(0).Item("User_Address").ToString
                txtUser_Phone.Text = "" & DT.Rows(0).Item("User_Phone").ToString


            txtUser_Name.ReadOnly = True
            txtUser_First_Name_EN.ReadOnly = True
            txtUser_Last_Name_EN.ReadOnly = True
            txtUser_First_Name_TH.ReadOnly = True
            txtUser_Last_Name_TH.ReadOnly = True
            txtUser_Address.ReadOnly = True
            txtUser_Phone.ReadOnly = True

                If Not VB.IsDBNull(DT.Rows(0).Item("User_Picture")) Then
                    Dim RetByte() As Byte = CType(DT.Rows(0).Item("User_Picture"), Byte())
                    Dim PictureData() As Byte = RetByte
                    Dim Ms As New System.IO.MemoryStream(PictureData)
                    ImgUser.Image = Image.FromStream(Ms)
                    ImgUser.Visible = True
                Else
                    txtUser_Name.ReadOnly = True
                    txtUser_First_Name_EN.ReadOnly = True
                    txtUser_Last_Name_EN.ReadOnly = True
                    txtUser_First_Name_TH.ReadOnly = True
                    txtUser_Last_Name_TH.ReadOnly = True
                    txtUser_Address.ReadOnly = True
                    txtUser_Phone.ReadOnly = True

                    ImgUser.Image = ImgUser.ErrorImage
                    'ImgUser.Visible = False
                End If
        End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_User_Profiles", Err.Number, Err.Description)
        End Try

    End Sub

    Private Sub cmdUpLoadImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpLoadImg.Click
        On Error GoTo Err_Renamed
        Dim FilePict As String = ""
        Dim ErrMsg As String = ""

        With DLGOpen
            .Title = "Select Your Picture"
            .Filter = "Graphic Files (*.bmp;*.jpg)|*.bmp;*.jpg"
            '.Flags = &H1000S Or &H800S
            .FilterIndex = 0
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                FilePict = .FileName
                If mDB.Save_Pict_To_DB(ConnStrMasTer, "Mas_User_Detail", "User_ID", "User_Picture", lbUserID.Text, FilePict) Then
                    ImgUser.Image = System.Drawing.Image.FromFile(FilePict)
                    ImgUser.Visible = True
                Else
                    MsgBox("Update Image  To " & txtUser_Name.Text & " : " & txtUser_First_Name_EN.Text & "  Fail !!", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle))
                    Exit Sub

                End If
            Else
                Exit Sub
            End If


        End With
        Exit Sub
Err_Renamed:

        If Err.Number = 7 Then ErrMsg = "Wrong Type Image File"
        Call mError.ShowError(Me.Name, "cmdAddPict_Click", Err.Number, Err.Description.ToString)
    End Sub

    Sub Clear_User_Data()


        lbDepartMent.Text = ""
        lbPosition.Text = ""
        'ImgUser.Visible = False

    End Sub

    Private Sub cmdChangePWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePWD.Click
        If Not (CurUser_Pwd = txtOldPWD.Text) Then MsgBox("รหัสผ่านเดิม ไม่ถูกต้อง ?..", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle)) : Exit Sub
        If Not (txtNewPWD.Text = txtConfirmPWD.Text) Then MsgBox("การยืนยันรหัสผ่านไม่ถูกต้อง ?..", CType(MsgBoxStyle.Critical + vbOKOnly, MsgBoxStyle)) : Exit Sub
        Call Update_PWD(lbUserID.Text)
    End Sub

    Sub Update_PWD(ByVal pUser_ID As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = "", TrnFlg As Boolean
        sql = "UPDATE Mas_User SET User_PWD = '" & Encrypt_password(txtConfirmPWD.Text) & "'"
        sql = sql & " WHERE User_ID = '" & pUser_ID & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการเปลี่ยนรหัสผ่าน ของ " & txtUser_Name.Text & " : " & txtUser_First_Name_EN.Text & " ใช่ หรือ ไม่ ?..", CType(MsgBoxStyle.Question + vbYesNo, MsgBoxStyle), "Password Reset Confirmation") = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                TrnFlg = False
                txtOldPWD.Text = ""
                txtNewPWD.Text = ""
                txtConfirmPWD.Text = ""
            Else
                Conn.RollbackTrans()
            End If

        End If
        Exit Sub
Err:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "Update_PWD", Err.Number, Err.Description)
    End Sub
    Private Sub CK_AutoHideMenu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_AutoHideMenu.CheckedChanged
        Call Write_Config("APPCONFIG", "AUTOHIDE_MAINMENU", Config_Path, CBool(CK_AutoHideMenu.Checked).ToString)
        IsAutoHideMainMenu_Mode = CK_AutoHideMenu.Checked
        'Call frmMain.Resize_Menu()
    End Sub

    Private Sub CK_AutoHideMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CK_AutoHideMenu.Click
        Call Write_Config("APPCONFIG", "AUTOHIDE_MAINMENU", Config_Path, CBool(CK_AutoHideMenu.Checked).ToString)
        IsAutoHideMainMenu_Mode = CK_AutoHideMenu.Checked
        'Call frmMain.Resize_Menu()
    End Sub

    Private Sub pMain_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pMain.Paint

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        txtUser_Name.ReadOnly = False
        txtUser_First_Name_EN.ReadOnly = False
        txtUser_Last_Name_EN.ReadOnly = False
        txtUser_First_Name_TH.ReadOnly = False
        txtUser_Last_Name_TH.ReadOnly = False
        txtUser_Address.ReadOnly = False
        txtUser_Phone.ReadOnly = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        txtUser_Name.ReadOnly = True
        txtUser_First_Name_EN.ReadOnly = True
        txtUser_Last_Name_EN.ReadOnly = True
        txtUser_First_Name_TH.ReadOnly = True
        txtUser_Last_Name_TH.ReadOnly = True
        txtUser_Address.ReadOnly = True
        txtUser_Phone.ReadOnly = True

        Call Load_User_Profiles(CurUser_ID)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Call Save_User_Profile()

    End Sub

    Sub Save_User_Profile()
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean
        Dim LastUser_ID As String
        If txtUser_Name.Text = "" Then MsgBox("กรุณาระบุชื่อผู้ใช้งาน ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : txtUser_Name.Focus() : Exit Sub
        Dim User_Focus As String = ""

        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True


            sql = " UPDATE Mas_User SET User_Name = '" & txtUser_Name.Text & "',"
            sql = sql & " User_FirstName = '" & txtUser_First_Name_EN.Text & "',"
            sql = sql & " User_LastName = '" & txtUser_Last_Name_EN.Text & "',"
            sql = sql & " User_FirstName_TH = '" & txtUser_First_Name_TH.Text & "',"
            sql = sql & " User_LastName_TH = '" & txtUser_Last_Name_TH.Text & "'"
            sql = sql & " WHERE USER_ID = '" & lbUserID.Text & "'"
            Conn.Execute(sql)

            sql = " UPDATE Mas_User_Detail SET User_Name = '" & txtUser_Name.Text & "',"
            sql = sql & " User_FirstName = '" & txtUser_First_Name_EN.Text & "',"
            sql = sql & " User_LastName = '" & txtUser_Last_Name_EN.Text & "',"
            sql = sql & " User_Phone = '" & txtUser_Phone.Text & "',"
            sql = sql & " User_Address = '" & txtUser_Address.Text & "'"

            sql = sql & " WHERE USER_ID = '" & lbUserID.Text & "'"
            Conn.Execute(sql)




            If MsgBox("คุณต้องการบันทึกข้อมูลผู้ใช้งานนี้ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                TrnFlg = False
                Call Load_User_Profiles(CurUser_ID)
            Else
                Conn.RollbackTrans()

                Exit Sub
            End If
        End If

        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Save_User_Profile", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()

    End Sub
End Class