
Option Explicit On

Imports VB = Microsoft.VisualBasic


Public Class frmUser_Permission
    Private Permit_Menu As TreeView
    Private Permit_App As String = vbNullChar
    Dim IsPermit As Boolean
    Friend userFullName As String = ""
    Private Sub frmUser_Permission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call frm_Load()
        Catch ex As Exception

        End Try

    End Sub
    Sub frm_Load()
        
        tabMenu.SelectedTab = PTI_GUIDANCE_CARCOUNT_Project
        'Call Show_Menu_Accept()
        CK_All.Checked = False
        Permit_Menu = TrvMenu : Permit_App = tabMenu.SelectedTab.Name
        'Call Load_Report_Group()
        'Call List_Report_Menu("2001", "0000") '0000 = ãËéáÊ´§ÃÒÂ§Ò¹·Ñé§ËÁ´
        ' Call ListMenu("2001") : CK_Report_Permit()

        Me.Text = "กำหนดสิทธิ์ผู้ใช้งานระบบของ  : " & userFullName
        Dim Level As String = ""
        Level = mDB_New.Get_Field(ConnStrMasTer, "select User_Position from Mas_User where User_ID= '" & lbUser_ID.Text & "' ", "User_Position")

        AddCombo(ConnStrMasTer, Me.cboPosition, "Mas_User_Position", "Pos_Name", "Pos_ID", "", "Pos_ID", "---àÅ×Í¡ÃÐ´Ñº¼Ùéãªé§Ò¹----")

        cboPosition.SelectedValue = Level
        Call Show_Menu_Accept_Level()
        Call Get_Menu_Permit(lbUser_ID.Text, Permit_App, Permit_Menu)
    End Sub



    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call Svae_Menu_Permit(lbUser_ID.Text)
        MessageBox.Show("บันทึกสิทธิ์การใช้งานระบบเรียบร้อย    ", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Sub Svae_Menu_Permit(ByVal pUser As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = vbNullChar, TrnFlg As Boolean
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            sql = "DELETE FROM User_Authen_Group WHERE User_ID = '" & pUser & "' AND Applicate_Name = '" & "PTI_GUIDANCE_CARCOUNT_Project" & "'"
            Conn.Execute(sql)
            sql = "DELETE FROM User_Authen WHERE User_ID = '" & pUser & "' AND Applicate_Name = '" & "PTI_GUIDANCE_CARCOUNT_Project" & "'"
            Conn.Execute(sql)
            For Each nNode As TreeNode In TrvMenu.Nodes
                If nNode.Checked = True Then
                    sql = "INSERT INTO User_Authen_Group (User_ID,Applicate_Name,Group_ID,Group_Name,Group_Caption,Permit) VALUES ('" & pUser & "',"
                    sql &= "'" & "PTI_GUIDANCE_CARCOUNT_Project" & "',"
                    sql &= "'" & nNode.Tag & "',"
                    sql &= "'" & nNode.Name & "',"
                    sql &= "'" & nNode.Text & "',"
                    sql &= "'" & 1 & "')"
                    Conn.Execute(sql)

                    sql = "INSERT INTO User_Authen (User_ID,Applicate_Name,Form_Name,Menu_Group_ID,Menu_ID,Menu_Name,Menu_Caption"
                    sql &= ",Can_Open,Can_Create,Can_Edit,Can_Delete) VALUES ('" & pUser & "',"
                    sql &= "'" & "PTI_GUIDANCE_CARCOUNT_Project" & "',"
                    sql &= "'" & "" & "',"
                    sql &= "'" & nNode.Tag & "',"
                    sql &= "'" & nNode.Tag & "',"
                    sql &= "'" & nNode.Name & "',"
                    sql &= "'" & nNode.Text & "',"
                    sql &= "'" & 1 & "',"
                    sql &= "'" & 1 & "',"
                    sql &= "'" & 1 & "',"
                    sql &= "'" & 1 & "')"
                    Conn.Execute(sql)
                End If


                For Each nNode_C As TreeNode In nNode.Nodes
                    If nNode_C.Checked = True Then
                        sql = "INSERT INTO User_Authen (User_ID,Applicate_Name,Form_Name,Menu_Group_ID,Menu_ID,Menu_Name,Menu_Caption"
                        sql &= ",Can_Open,Can_Create,Can_Edit,Can_Delete) VALUES ('" & pUser & "',"
                        sql &= "'" & "PTI_GUIDANCE_CARCOUNT_Project" & "',"
                        sql &= "'" & "" & "',"
                        sql &= "'" & nNode.Tag & "',"
                        sql &= "'" & nNode_C.Tag & "',"
                        sql &= "'" & nNode_C.Name & "',"
                        sql &= "'" & nNode_C.Text & "',"
                        sql &= "'" & 1 & "',"
                        sql &= "'" & 1 & "',"
                        sql &= "'" & 1 & "',"
                        sql &= "'" & 1 & "')"
                        Conn.Execute(sql)
                    End If
                Next
            Next


            If MsgBox("คุณต้องการบันทึกสิทธิ์  การใช้งานของ  " & lbUser_ID.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Conn.CommitTrans()
                TrnFlg = False

            Else
                Conn.RollbackTrans()
                Exit Sub
            End If

        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Svae_Menu_Permit", Err.Number, Err.Description)
        If TrnFlg = True Then Conn.RollbackTrans()
    End Sub

   

   

    Function Show_Menu_Accept() As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        TrvMenu.Nodes.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT *  FROM [Mas_Menu_Group] "
            sql = sql & " Where IsCommit=1" ' and Group_ID<>'2000'"

            Dim Position As String = ""
            Position = mDB_New.Get_Field(ConnStrMasTer, "select User_Position from Mas_User  where User_ID = " & lbUser_ID.Text & "", "User_Position")
            'If (Position <> "5" Or Position <> 5) And (Position <> "3" Or Position <> 3) And (Position <> "9" Or Position <> 9) Then
            '    sql = sql & " and Group_ID not in (5000,7005,7006) "
            'End If
            sql = sql & " Order by  Group_ID "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Dim i As Short = 0
                    Dim j As Short = 0
                    Do While Not .EOF
                        TrvMenu.Nodes.Add(i).Text = rs.Fields("Group_Caption").Value
                        TrvMenu.Nodes(i).Name = rs.Fields("Group_Name").Value
                        TrvMenu.Nodes(i).Tag = rs.Fields("Group_ID").Value
                        TrvMenu.Nodes(i).Checked = rs.Fields("IsCommit").Value
                        '################################
                        Dim Conn_Menu As New ADODB.Connection
                        Dim rs_Menu As New ADODB.Recordset
                        Dim sql_Menu As String

                        If OpenCnn(ConnStrMasTer, Conn_Menu) Then
                            sql_Menu = "SELECT *  FROM [Mas_Menu] "
                            sql_Menu = sql_Menu & " WHERE Menu_Group_ID='" & rs.Fields("Group_ID").Value & "'"
                            sql_Menu = sql_Menu & " and IsCommit=1   AND Menu_Desc = 9"
                            'If (Position <> "5" Or Position <> 5) And (Position <> "3" Or Position <> 3) And (Position <> "9" Or Position <> 9) Then
                            '    sql_Menu = sql_Menu & " and Menu_Group_ID not in (5000,7005,7006) and Menu_ID not in (7005,7006)"
                            'End If
                            sql_Menu = sql_Menu & " Order by  Menu_Group_ID,Menu_ID "
                            '################################
                            With rs_Menu
                                If .State = 1 Then .Close()
                                .let_ActiveConnection(Conn_Menu)
                                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                                .Open(sql_Menu)
                                If Not (.EOF And .BOF) Then
                                    j = 0
                                    Do While Not .EOF
                                        TrvMenu.Nodes(i).Nodes.Add(j).Text = rs_Menu.Fields("Menu_Caption").Value
                                        TrvMenu.Nodes(i).Nodes(j).Name = rs_Menu.Fields("Menu_Name").Value
                                        TrvMenu.Nodes(i).Nodes(j).Tag = rs_Menu.Fields("Menu_ID").Value
                                        TrvMenu.Nodes(i).Nodes(j).Checked = rs_Menu.Fields("IsCommit").Value
                                        j += 1
                                        .MoveNext()
                                    Loop
                                End If
                            End With
                            '###############################
                        Else
                            Show_Menu_Accept = False
                        End If
                        Conn_Menu = Nothing
                        rs_Menu = Nothing
                        '###############################
                        i += 1
                        .MoveNext()
                    Loop
                End If
            End With
        Else
            Show_Menu_Accept = False
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Call mError.ShowError(Me.Name, "Show_Menu_Accept", Err.Number, Err.Description)
        Show_Menu_Accept = False
    End Function

    Sub Get_Menu_Permit(ByVal pUser_ID As String, ByVal pApp As String, ByVal pMenu As TreeView)

        If pUser_ID = "" Or pApp = "" Then Exit Sub


        For Each nNode As TreeNode In pMenu.Nodes
            nNode.Checked = mMain.IsMenu_Permit(pUser_ID, nNode.Tag, nNode.Name, pApp)
            For Each nNode_C As TreeNode In nNode.Nodes
                nNode_C.Checked = mMain.IsMenu_Permit(pUser_ID, nNode.Tag, nNode_C.Name, pApp)
            Next
        Next

    End Sub

    Private Sub CK_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_All.CheckedChanged
        If Permit_Menu Is Nothing Then Exit Sub

        Permit_Menu.ExpandAll()
        For Each nNode As TreeNode In Permit_Menu.Nodes
            nNode.Checked = CK_All.Checked
            For Each nNode_C As TreeNode In nNode.Nodes
                nNode_C.Checked = CK_All.Checked
            Next
        Next

    End Sub

    Private Sub TrvMenu_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TrvMenu.AfterCheck
        'If TrvMenu.SelectedNode Is Nothing Then Exit Sub

        'If TrvMenu.SelectedNode.Checked = True Then
        '    If Not TrvMenu.SelectedNode Is Nothing Then TrvMenu.SelectedNode.FirstNode.Checked = True
        'Else
        '    For Each nNode_C As TreeNode In TrvMenu.SelectedNode.Nodes
        '        nNode_C.Checked = False
        '    Next
        'End If


    End Sub


    Private Sub TrvMenu_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TrvMenu.NodeMouseClick

        If TrvMenu.SelectedNode Is Nothing Then Exit Sub


        If TrvMenu.SelectedNode.Checked = True And TrvMenu.SelectedNode.Level = 0 Then
            TrvMenu.SelectedNode.FirstNode.Checked = True
        Else
            For Each nNode_C As TreeNode In TrvMenu.SelectedNode.Nodes
                nNode_C.Checked = False
            Next
        End If


        'For Each nNode As TreeNode In Permit_Menu.Nodes
        '    nNode.Checked = CK_All.Checked
        '    For Each nNode_C As TreeNode In nNode.Nodes
        '        nNode_C.Checked = CK_All.Checked
        '    Next
        'Next
    End Sub

    Private Sub tabMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMenu.SelectedIndexChanged
        CK_All.Checked = False

        Select Case tabMenu.SelectedIndex
            Case Is = 0 : Permit_Menu = TrvMenu : Permit_App = tabMenu.SelectedTab.Name
                'Case Is = 1 : Permit_Menu = Trv_Terminal : Permit_App = tabMenu.SelectedTab.Name
                'Case Is = 2 : Permit_Menu = Trv_EStamp : Permit_App = tabMenu.SelectedTab.Name


        End Select

        Call Get_Menu_Permit(lbUser_ID.Text, Permit_App, Permit_Menu)
    End Sub


    Private Sub lstMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'If lstMenu.Items.Count = 0 Then Exit Sub

        'If lstMenu.Checked = False And CK_All_Report.CheckState = 1 Then IsPermit = True : CK_All_Report.CheckState = 0 : IsPermit = False
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

        If OpenCnn(ConnStrMasTer, Conn) Then
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

            If MsgBox("คุณต้องการคัดลอกสิทธิ์ การใช้งานของ  (" & nUser & ") ไปยังผู้ใช้งาน (" & lbUser_ID.Text & ") ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                TrnFlg = False
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If

        End If
        Call Get_Menu_Permit(lbUser_ID.Text, Permit_App, Permit_Menu)

        If rs.State = 1 Then rs.Close()
        If Conn.State = 1 Then Conn.Close()
        rs = Nothing : Conn = Nothing

        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Clone_Permit", Err.Number, Err.Description)
    End Sub



    Private Sub cboPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPosition.SelectedIndexChanged
        'TrvMenu.Nodes.Clear()
        If cboPosition.SelectedIndex <= 0 Then Exit Sub
        TrvMenu.Nodes.Clear()
        Try
            Show_Menu_Accept_Level()
            If RadioButton2.Checked = True Then
                If cboPosition.SelectedIndex <> 0 Then
                    Call Get_Menu_Permit_Level(cboPosition.SelectedValue, Permit_Menu)
                    ' Call CK_Report_Permit_Level()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Get_Menu_Permit_Level(ByVal pLevel As String, ByVal pMenu As TreeView)
        If pLevel = "" Then Exit Sub

        For Each nNode As TreeNode In pMenu.Nodes
            nNode.Checked = mMain.IsMenu_Permit_Bylevel(pLevel, nNode.Tag, nNode.Name)
            For Each nNode_C As TreeNode In nNode.Nodes
                nNode_C.Checked = mMain.IsMenu_Permit_Bylevel(pLevel, nNode_C.Tag, nNode_C.Name)
            Next
        Next

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Call Show_Menu_Accept()
            Call Get_Menu_Permit(lbUser_ID.Text, Permit_App, Permit_Menu)

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        'If RadioButton2.Checked = True Then
        '    cboPosition.Enabled = True
        'Else
        '    cboPosition.Enabled = False
        'End If
    End Sub
    Function Show_Menu_Accept_Level() As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        TrvMenu.Nodes.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT  Distinct Menu_Permit.ID, "
            sql = sql & " Mas_Menu_Group.[Applicate_Name]"
            sql = sql & ",Mas_Menu_Group.[Group_ID]"
            sql = sql & ",Mas_Menu_Group.[Group_Name]"
            sql = sql & ",Mas_Menu_Group.[Group_Caption]"
            sql = sql & " ,Mas_Menu_Group.[IsCancel]"
            sql = sql & " ,Mas_Menu_Group.[IsCommit]"
            sql = sql & " FROM [Mas_Menu_Group],Menu_Permit "
            sql = sql & " Where Mas_Menu_Group.IsCommit=1 and Menu_Permit.ID = Mas_Menu_Group.[Group_ID] " ' and Group_ID<>'2000'"
            sql = sql & " and Menu_Permit.User_Level =" & cboPosition.SelectedValue & ""
            'Dim Position As String = ""
            'Position = mDB_New.Get_Field(ConnStrMasTer, "select User_Position from Mas_User  where User_ID = " & lbUser_ID.Text & "", "User_Position")
            'If (Position <> "5" Or Position <> 5) And (Position <> "3" Or Position <> 3) And (Position <> "9" Or Position <> 9) Then
            '    sql = sql & " and Group_ID not in (5000,7005,7006) "
            'End If
            sql = sql & " Order by Mas_Menu_Group.Group_ID "
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                .Open(sql)
                If Not (.EOF And .BOF) Then
                    Dim i As Short = 0
                    Dim j As Short = 0
                    Do While Not .EOF
                        TrvMenu.Nodes.Add(i).Text = rs.Fields("Group_Caption").Value
                        TrvMenu.Nodes(i).Name = rs.Fields("Group_Name").Value
                        TrvMenu.Nodes(i).Tag = rs.Fields("Group_ID").Value
                        TrvMenu.Nodes(i).Checked = rs.Fields("IsCommit").Value
                        '################################
                        Dim Conn_Menu As New ADODB.Connection
                        Dim rs_Menu As New ADODB.Recordset
                        Dim sql_Menu As String

                        If OpenCnn(ConnStrMasTer, Conn_Menu) Then
                            sql_Menu = "SELECT Distinct *  FROM [Mas_Menu],Menu_Permit "
                            sql_Menu = sql_Menu & " WHERE Mas_Menu.Menu_Group_ID='" & rs.Fields("Group_ID").Value & "'"
                            sql_Menu = sql_Menu & " and Mas_Menu.IsCommit=1   AND Mas_Menu.Menu_Desc = 9 and Mas_Menu.Menu_ID = Menu_Permit.ID"
                            'If (Position <> "5" Or Position <> 5) And (Position <> "3" Or Position <> 3) And (Position <> "9" Or Position <> 9) Then
                            '    sql_Menu = sql_Menu & " and Menu_Group_ID not in (5000,7005,7006) and Menu_ID not in (7005,7006)"
                            'End If

                            sql_Menu = sql_Menu & " and Menu_Permit.User_Level =" & cboPosition.SelectedValue & ""
                            sql_Menu = sql_Menu & " Order by  Mas_Menu.Menu_Group_ID,Mas_Menu.Menu_ID "
                            '################################
                            With rs_Menu
                                If .State = 1 Then .Close()
                                .let_ActiveConnection(Conn_Menu)
                                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                                .CursorType = ADODB.CursorTypeEnum.adOpenKeyset
                                .Open(sql_Menu)
                                If Not (.EOF And .BOF) Then
                                    j = 0
                                    Do While Not .EOF
                                        TrvMenu.Nodes(i).Nodes.Add(j).Text = rs_Menu.Fields("Menu_Caption").Value
                                        TrvMenu.Nodes(i).Nodes(j).Name = rs_Menu.Fields("Menu_Name").Value
                                        TrvMenu.Nodes(i).Nodes(j).Tag = rs_Menu.Fields("Menu_ID").Value
                                        TrvMenu.Nodes(i).Nodes(j).Checked = rs_Menu.Fields("IsCommit").Value
                                        j += 1
                                        .MoveNext()
                                    Loop
                                End If
                            End With
                            '###############################
                        Else
                            'Show_Menu_Accept = False
                        End If
                        Conn_Menu = Nothing
                        rs_Menu = Nothing
                        '###############################
                        i += 1
                        .MoveNext()
                    Loop
                End If
            End With
        Else
            'Show_Menu_Accept = False
        End If
        Conn = Nothing
        rs = Nothing
        Exit Function
Err:
        Call mError.ShowError(Me.Name, "Show_Menu_Accept", Err.Number, Err.Description)
        'Show_Menu_Accept = False
    End Function

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
End Class