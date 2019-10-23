
Option Explicit On

Imports VB = Microsoft.VisualBasic

Public Class frmUser_Permission_By_Level_OLD
    Private Permit_Menu As TreeView
    Private Permit_App As String = vbNullChar
    Dim IsPermit As Boolean
    Friend userFullName As String = ""
    Private Sub frmUser_Permission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call frm_Load()
        AddCombo(ConnStrMasTer, Me.cboPosition, "Mas_User_Position", "Pos_Name", "Pos_ID", "", "Pos_ID", "---เลือกระดับผู้ใช้งาน----")
    End Sub

    Sub frm_Load()
        tabMenu.SelectedTab = PTI_GUIDANCE_CARCOUNT_Project
        Call Show_Menu_Accept()
        CK_All.Checked = False

        Permit_Menu = TrvMenu : Permit_App = tabMenu.SelectedTab.Name
        'Call Load_Report_Group()
        Call List_Report_Menu("2001", "0000") '0000 = ãËéáÊ´§ÃÒÂ§Ò¹·Ñé§ËÁ´

        'Call ListMenu("2001")
        CK_Report_Permit_Level()
        Me.Text = "จัดระดับผู้ใช้งานระบบ"
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboPosition.SelectedIndex = 0 Then MessageBox.Show("กรุณาเลือกระดับผู้ใช้งาน     ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Call Svae_Menu_Permit(cboPosition.SelectedValue)
        ' MessageBox.Show("ºÑ¹·Ö¡ÊÔ·¸Ôì¡ÒÃãªé§Ò¹ÃÐººàÃÕÂºÃéÍÂ  ", "Â×¹ÂÑ¹", MsgBoxStyle.Information, MessageBoxButtons.OK)
        MessageBox.Show("บันทึกสิทธ์ผู้ใช้งานระบบเรียบร้อย  ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Sub Svae_Menu_Permit(ByVal pUser As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = vbNullChar, TrnFlg As Boolean
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            sql = "DELETE FROM [Menu_Permit] WHERE [User_Level] = '" & cboPosition.SelectedValue & "' AND [Control_Name] = 'MENU'"
            Conn.Execute(sql)
            For Each nNode As TreeNode In TrvMenu.Nodes
                If nNode.Checked = True Then
                    sql = "INSERT INTO [Menu_Permit] ([ID],[MenuName],[Control_Name],[User_Level],[User_Id],[IsCommit]) VALUES("
                    sql &= "'" & nNode.Tag & "',"
                    sql &= "'" & nNode.Name & "',"
                    sql &= "'MENU',"
                    sql &= "'" & cboPosition.SelectedValue & "',"
                    sql &= "'9999',"
                    sql &= "'" & 1 & "')"
                    Conn.Execute(sql)
                End If
                For Each nNode_C As TreeNode In nNode.Nodes
                    If nNode_C.Checked = True Then
                        sql = "INSERT INTO [Menu_Permit] ([ID],[MenuName],[Control_Name],[User_Level],[User_Id],[IsCommit]) VALUES("
                        sql &= "'" & nNode_C.Tag & "',"
                        sql &= "'" & nNode_C.Name & "',"
                        sql &= "'MENU',"
                        sql &= "'" & cboPosition.SelectedValue & "',"
                        sql &= "'9999',"
                        sql &= "'" & 1 & "')"
                        Conn.Execute(sql)
                    End If
                Next
            Next
            If MsgBox("คุณต้องการบันทึกสิทธิ์การใช้งานระบบของ  " & cboPosition.Text & "ใช่ หรือ ไม่  ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

    Sub Svae_Report_Permit(ByVal pUser As String)
        On Error GoTo Err

        Dim Conn As New ADODB.Connection, sql As String = vbNullChar, TrnFlg As Boolean

        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            '#####  DELETE 
            sql = "DELETE FROM [Menu_Permit] WHERE [User_Level] = '" & cboPosition.SelectedValue & "' AND [Control_Name] = 'REPORT'"
            For i As Integer = 0 To lstMenu.Items.Count - 1
                If lstMenu.Items(i).Checked = True Then
                    sql = "INSERT INTO [Menu_Permit] ([ID],[MenuName],[Control_Name],[User_Level],[User_Id],[IsCommit]) VALUES("
                    sql &= "'" & lstMenu.Items(i).Text & "',"
                    sql &= "'" & lstMenu.Items(i).SubItems(4).Text & "',"
                    sql &= "'REPORT',"
                    sql &= "'" & cboPosition.SelectedValue & "',"
                    sql &= "'9999',"
                    sql &= "'" & 1 & "')"
                    Conn.Execute(sql)
                End If
            Next
            '#####################################
            If MsgBox("คุณต้องการบันทึกสิทธิ์การใช้งานระบบของ " & cboPosition.Text & "ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

    Private Sub tabMenu_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabMenu.Selected

        'CK_All.Checked = False

        'Select Case tabMenu.SelectedIndex
        '    Case Is = 0 : Permit_Menu = TrvMenu : Permit_App = tabMenu.SelectedTab.Name
        '    Case Is = 1 : Permit_Menu = Trv_Terminal : Permit_App = tabMenu.SelectedTab.Name
        '    Case Is = 2 : Permit_Menu = Trv_EStamp : Permit_App = tabMenu.SelectedTab.Name


        'End Select

        'Call Get_Menu_Permit(lbUser_ID.Text, Permit_App, Permit_Menu)

    End Sub

    Function Show_Menu_Accept() As Boolean
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        TrvMenu.Nodes.Clear()
        If OpenCnn(ConnStrMasTer, Conn) Then
            sql = "SELECT *  FROM [Mas_Menu_Group] "
            sql = sql & " Where IsCommit=1"
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
                            sql_Menu = sql_Menu & " and IsCommit=1 and Menu_Desc = 9"
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

    Sub Get_Menu_Permit_Level(ByVal pLevel As String, ByVal pMenu As TreeView)
        If pLevel = "" Then Exit Sub

        For Each nNode As TreeNode In pMenu.Nodes
            nNode.Checked = mMain.IsMenu_Permit_Bylevel(pLevel, nNode.Tag, nNode.Name)
            For Each nNode_C As TreeNode In nNode.Nodes
                nNode_C.Checked = mMain.IsMenu_Permit_Bylevel(pLevel, nNode_C.Tag, nNode_C.Name)
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

        Call Get_Menu_Permit_Level(cboPosition.SelectedValue, Permit_Menu)
    End Sub



    Sub ListMenu(ByRef pGroupID As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String

        sql = "SELECT * FROM Mas_Menu WHERE Menu_Group_ID = '" & pGroupID & "' AND (IsCommit = 1) ORDER BY Menu_ID"
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
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

                            ' Debug.Print(lbUser_ID.Text & " : " & lstMenu.Items.Item(tl).SubItems(0).Text & " : " & lstMenu.Items.Item(tl).Text & " : " & lstMenu.Items.Item(tl).SubItems(1).Text)

                            'New_Ent.Checked = Me.CHK_Menu_Permit((lbUser_ID.Text), lstMenu.Items.Item(tl).SubItems(1).Text, lstMenu.Items.Item(tl).Text, lstMenu.Items.Item(tl).SubItems(2).Text)

                        End With
                        .MoveNext()
                    Loop


                Else

                    lstMenu.Items.Clear()

                End If
            End With
        End If



        'lstMenu.Enabled = False
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "ListMenu", Err.Number, Err.Description)
    End Sub

    Sub List_Report_Menu(ByRef pGroupID As String, ByVal pRpt_Group_ID As String)
        On Error GoTo Err
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        If pRpt_Group_ID = "0000" Then
            sql = "SELECT * FROM qMas_Menu_Report WHERE Menu_Group_ID = '" & pGroupID & "' AND (IsCommit = 1)  ORDER BY Menu_ID"
        Else
            sql = "SELECT * FROM qMas_Menu_Report WHERE Menu_Group_ID = '" & pGroupID & "' AND (IsCommit = 1) and Rpt_Group_ID='" & pRpt_Group_ID & "' ORDER BY Menu_ID"
        End If

        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
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

                                'Debug.Print("MENU = " & rs.Fields("Menu_ID").Value)
                                'Debug.Print("GRP = " & rs.Fields("Menu_Group_ID").Value)
                                'Debug.Print("App = " & rs.Fields("Applicate_Name").Value)
                                'Debug.Print("Menu Name = " & rs.Fields("Menu_Name").Value)
                                'Debug.Print("" & rs.Fields("Menu_Caption").Value)
                                'Debug.Print("" & rs.Fields("Menu_Desc").Value)
                            Next
                            '                           Debug.Print(lbUser_ID.Text & " : " & lstMenu.Items.Item(tl).SubItems(0).Text & " : " & lstMenu.Items.Item(tl).Text & " : " & lstMenu.Items.Item(tl).SubItems(1).Text)
                            '
                            'New_Ent.Checked = Me.CHK_Menu_Permit((lbUser_ID.Text), lstMenu.Items.Item(tl).SubItems(1).Text, lstMenu.Items.Item(tl).Text, lstMenu.Items.Item(tl).SubItems(2).Text)

                        End With
                        .MoveNext()
                    Loop
                Else
                    lstMenu.Items.Clear()

                End If
            End With
        End If


        CK_Report_Permit_Level()
        'lstMenu.Enabled = False
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "ListMenu", Err.Number, Err.Description)
    End Sub
    Sub CK_Report_Permit_Level()
        If lstMenu.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To lstMenu.Items.Count - 1
            If mMain.IsReport_Permit_Level(cboPosition.SelectedValue, lstMenu.Items(i).Text) Then
                lstMenu.Items(i).Checked = True
            Else
                lstMenu.Items(i).Checked = False
            End If
        Next
    End Sub

    Private Sub cmdSave_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave_Menu.Click
        If cboPosition.SelectedIndex = 0 Then MessageBox.Show("กรุณาเลือกระดับผู้ใช้งาน      ", "ผลการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Call Svae_Report_Permit(cboPosition.SelectedValue)
    End Sub

    Private Sub CK_All_Report_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CK_All_List.CheckedChanged

        If lstMenu.Items.Count = 0 Then Exit Sub
        If IsPermit = True Then Exit Sub
        If CK_All_List.CheckState = 1 Then
            For i As Integer = 0 To lstMenu.Items.Count - 1
                lstMenu.Items(i).Checked = True
            Next
        Else
            For i As Integer = 0 To lstMenu.Items.Count - 1
                lstMenu.Items(i).Checked = False
            Next
        End If



    End Sub

    Private Sub lstMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMenu.Click
        'If lstMenu.Items.Count = 0 Then Exit Sub

        'If lstMenu.Checked = False And CK_All_Report.CheckState = 1 Then IsPermit = True : CK_All_Report.CheckState = 0 : IsPermit = False
    End Sub

    Private Sub lstMenu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMenu.DoubleClick
        If lstMenu.Items.Count = 0 Then Exit Sub
        If lstMenu.FocusedItem Is Nothing Then Exit Sub
        If lstMenu.FocusedItem.Checked = False And CK_All_List.CheckState = 1 Then IsPermit = True : CK_All_List.CheckState = 0 : IsPermit = False
    End Sub

    Private Sub lstMenu_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstMenu.ItemCheck
        If lstMenu.Items.Count = 0 Then Exit Sub
        If lstMenu.FocusedItem Is Nothing Then Exit Sub
        If lstMenu.FocusedItem.Checked = False And CK_All_List.CheckState = 1 Then IsPermit = True : CK_All_List.CheckState = 0 : IsPermit = False
    End Sub
    '    Sub Load_Report_Group()
    '        On Error GoTo Err
    '        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
    '        'lstGroupRpt.Items.Clear()
    '        If OpenCnn(ConnStrMasTer, Conn) Then
    '            sql = "SELECT * FROM Report_Group where Group_Cancle<>1 ORDER BY Group_ID "
    '            With rs
    '                If .State = 1 Then .Close()
    '                .ActiveConnection = Conn
    '                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
    '                .LockType = ADODB.LockTypeEnum.adLockOptimistic
    '                .Open(sql)
    '                If Not (.EOF And .BOF) Then
    '                    .MoveFirst()
    '                    Do While Not .EOF
    '                        Dim nRow As ListViewItem = lstGroupRpt.Items.Add("" & .Fields("Group_ID").Value)
    '                        nRow.SubItems.Add("" & .Fields("Group_Caption").Value)
    '                        .MoveNext()
    '                    Loop
    '                Else
    '                    lstGroupRpt.Items.Clear()
    '                End If
    '            End With
    '        Else
    '            lstGroupRpt.Items.Clear()
    '        End If
    '        Exit Sub
    'Err:
    '        Call mError.ShowError(Me.Name, "Load_Report_Group", Err.Number, Err.Description)
    '    End Sub
    Sub Set_Report_Group(ByVal nGroup_Set As String)
        If MessageBox.Show("  คุณต้องการกำหนด สิทธิ์กลุ่มรายงาน     ", "ใช่ หรือ ไม่ ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            mDB_New.RunSqlQury(ConnStrMasTer, "UPDATE Report_Menu set Rpt_Group_ID='" & nGroup_Set & "' where Rpt_ID='" & lstMenu.FocusedItem.Text & "'")
            'Call List_Report_Menu("2001", lstGroupRpt.FocusedItem.Text)
            'Dim i As Short = 0
            'For i = 0 To lstMenu.CheckedItems.Count - 1
            '    With lstMenu.CheckedItems(i)
            '        mDB_New.RunSqlQury(ConnStrMasTer, "UPDATE Report_Menu set Rpt_Group_ID='" & nGroup_Set & "' where Rpt_ID='" & .SubItems(0).Text & "'")
            '    End With
            'Next
            'MessageBox.Show("        ·Ó¡ÒÃ¡ÓË¹´¤èÒ¡ÅØèÁ¢Í§ÃÒÂ§Ò¹àÃÕÂºÃéÍÂ             ")
            'Call List_Report_Menu("2001", lstGroupRpt.FocusedItem.Text)
            'mMain.Get_Array("", ":", 1)
        End If
    End Sub
    Private Sub nREPORT_SYSTEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_SYSTEM.Click
        Set_Report_Group(nREPORT_SYSTEM.Tag)
    End Sub
    Private Sub nREPORT_CASHIER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_CASHIER.Click
        Set_Report_Group(nREPORT_CASHIER.Tag)
    End Sub

    Private Sub nREPORT_TICKET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_TICKET.Click
        Set_Report_Group(nREPORT_TICKET.Tag)
    End Sub

    Private Sub nREPORT_COUPON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_COUPON.Click
        Set_Report_Group(nREPORT_COUPON.Tag)
    End Sub

    Private Sub nREPORT_E_STAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_E_STAMP.Click
        Set_Report_Group(nREPORT_E_STAMP.Tag)
    End Sub

    Private Sub nREPORT_ANALYSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_ANALYSE.Click
        Set_Report_Group(nREPORT_ANALYSE.Tag)
    End Sub

    Private Sub nREPORT_DISCOUNT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_DISCOUNT.Click
        Set_Report_Group(nREPORT_DISCOUNT.Tag)
    End Sub

    Private Sub nREPORT_GRAHP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_GRAHP.Click
        Set_Report_Group(nREPORT_GRAHP.Tag)
    End Sub

    Private Sub nREPORT_FINANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_FINANCE.Click
        Set_Report_Group(nREPORT_FINANCE.Tag)
    End Sub

    Private Sub nREPORT_OTHER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_OTHER.Click
        Set_Report_Group(nREPORT_OTHER.Tag)
    End Sub

    Private Sub lstGroupRpt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Call List_Report_Menu("2001", lstGroupRpt.FocusedItem.Text)
        ' labReportName.Text = lstGroupRpt.FocusedItem.SubItems(1).Text
    End Sub

    Private Sub nREPORT_VISITOR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nREPORT_VISITOR.Click
        Set_Report_Group(nREPORT_VISITOR.Tag)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPosition.SelectedIndexChanged
        Try
            If cboPosition.SelectedIndex <> 0 Then
                Me.Text = "กำหนดสิทธิ์การใช้งานของ : " & cboPosition.Text
                Call Get_Menu_Permit_Level(cboPosition.SelectedValue, Permit_Menu)
                Call CK_Report_Permit_Level()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class