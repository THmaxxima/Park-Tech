
Option Explicit On
Imports System
Imports VB = Microsoft.VisualBasic

Public Class frmUser_Permission_By_Level
    Dim cdb As New CDatabase
    Private Permit_Menu As TreeView
    Private Permit_App As String = vbNullChar
    Dim IsPermit As Boolean
    Friend userFullName As String = ""
    Private Sub frmUser_Permission_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddCombo(ConnStrMasTer, Me.cboPosition, "Mas_User_Position", "Pos_Name", "Pos_ID", "", "Pos_ID", "---เลือกระดับผู้ใช้งาน----")
        If cboPosition.Items.Count > 0 Then
            cboPosition.SelectedIndex = 1
            Call frm_Load()
        End If
    End Sub

    Sub frm_Load()
        tabMenu.SelectedTab = PTI_GUIDANCE_CARCOUNT_Project

        Call Show_Menu_AcceptNEW(cboPosition.SelectedIndex)

        Permit_Menu = TrvMenu : Permit_App = tabMenu.SelectedTab.Name
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
        Dim TrnFlg As Boolean

        TrnFlg = True
        sql = "DELETE FROM [Menu_Permit] WHERE [User_Level] = '" & cboPosition.SelectedValue & "' AND [Control_Name] = 'MENU'"

        If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
            cdb.writeError(sql)
        End If

        For Each nNode As TreeNode In TrvMenu.Nodes
            If nNode.Checked = True Then
                sql = "INSERT INTO [Menu_Permit] ([ID],[MenuName],[Control_Name],[User_Level],[User_Id],[IsCommit]) VALUES("
                sql &= "'" & nNode.Tag & "',"
                sql &= "'" & nNode.Name & "',"
                sql &= "'MENU',"
                sql &= "'" & cboPosition.SelectedValue & "',"
                sql &= "'9999',"
                sql &= "'" & 1 & "')"

                If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                    cdb.writeError(sql)
                End If

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
                    If cdb.ExcuteNoneQury(sql, ConStr_Master) = False Then
                        cdb.writeError(sql)
                    End If

                End If
            Next
        Next
        If MsgBox("คุณต้องการบันทึกสิทธิ์การใช้งานระบบของ  " & cboPosition.Text & "ใช่ หรือ ไม่  ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            TrnFlg = False
        Else

            Exit Sub
        End If

        'End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "Svae_Menu_Permit", Err.Number, Err.Description)
        'If TrnFlg = True Then 'Conn.RollbackTrans()
    End Sub

    Function chk_group_menu_commit(ByVal lavel_ As String, ByVal group_id As String)
        Dim sql As String = ""
        sql = "SELECT TOP 1 [ID] FROM V_Menu_Permission WHERE [User_Level] = '" & lavel_ & "' and isnull([Group_id],'') ='" & group_id & "'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Function Show_Menu_AcceptNEW(ByVal user_level As String) As Boolean
        Dim sql As String
        TrvMenu.Nodes.Clear()

        Try
            sql = "SELECT distinct * FROM [Mas_Menu_Group] WHERE [IsCommit] = 1 order by [Group_ID]"
            Dim DT_Group As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT_Group.Rows.Count > 0 Then
                For ii As Integer = 0 To DT_Group.Rows.Count - 1
                    TrvMenu.Nodes.Add(ii).Text = DT_Group.Rows(ii).Item("Group_Caption").ToString
                    TrvMenu.Nodes(ii).Name = DT_Group.Rows(ii).Item("Group_Name").ToString
                    TrvMenu.Nodes(ii).Tag = DT_Group.Rows(ii).Item("Group_ID").ToString
                    TrvMenu.Nodes(ii).Checked = chk_group_menu_commit(user_level, DT_Group.Rows(ii).Item("Group_ID").ToString)

                    sql = " SELECT distinct M.[Applicate_Name]"
                    sql &= "       ,M.[Menu_ID]"
                    sql &= "      ,M.[Menu_Name]"
                    sql &= "      ,M.[Menu_Caption]"
                    sql &= "	  ,Isnull((SELECT Top 1 User_Level FROM [dbo].[Menu_Permit] WHERE M.[Menu_Name]= [dbo].[Menu_Permit].MenuName and [dbo].[Menu_Permit].User_Level='" & user_level & "'),'') AS User_Level"
                    sql &= "  FROM [Mas_Menu] As M"
                    sql &= " WHERE Menu_Group_ID='" & DT_Group.Rows(ii).Item("Group_ID").ToString & "' and M.[IsCommit]=1"
                    sql &= " order by M.[Menu_ID]"
                    Dim DT_menu As DataTable = cdb.readTableData(sql, ConStr_Master)
                    If DT_menu.Rows.Count > 0 Then
                        For iii As Integer = 0 To DT_menu.Rows.Count - 1
                            TrvMenu.Nodes(ii).Nodes.Add(iii).Text = DT_menu.Rows(iii).Item(3).ToString
                            TrvMenu.Nodes(ii).Nodes(iii).Name = DT_menu.Rows(iii).Item(2).ToString
                            TrvMenu.Nodes(ii).Nodes(iii).Tag = DT_menu.Rows(iii).Item(1).ToString

                            If DT_menu.Rows(iii).Item(4).ToString <> "" Then
                                TrvMenu.Nodes(ii).Nodes(iii).Checked = True
                            Else
                                TrvMenu.Nodes(ii).Nodes(iii).Checked = False
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    

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
                            sql_Menu = sql_Menu & " and IsCommit=1"
                            ' sql_Menu = sql_Menu & " and IsCommit=1 and Menu_Desc = 9"
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

    Private Sub TrvMenu_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TrvMenu.NodeMouseClick

        If TrvMenu.SelectedNode Is Nothing Then Exit Sub


        If TrvMenu.SelectedNode.Checked = True And TrvMenu.SelectedNode.Level = 0 Then
            TrvMenu.SelectedNode.FirstNode.Checked = True
        Else
            For Each nNode_C As TreeNode In TrvMenu.SelectedNode.Nodes
                nNode_C.Checked = False
            Next
        End If

    End Sub

    Private Sub tabMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMenu.SelectedIndexChanged
        CK_All.Checked = False

        Select Case tabMenu.SelectedIndex
            Case Is = 0 : Permit_Menu = TrvMenu : Permit_App = tabMenu.SelectedTab.Name
                'Case Is = 1 : Permit_Menu = Trv_Terminal : Permit_App = tabMenu.SelectedTab.Name
                'Case Is = 2 : Permit_Menu = Trv_EStamp : Permit_App = tabMenu.SelectedTab.Name


        End Select

        'Call Get_Menu_Permit_Level(cboPosition.SelectedValue, Permit_Menu)
    End Sub













    Private Sub lstGroupRpt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Call List_Report_Menu("2001", lstGroupRpt.FocusedItem.Text)
        ' labReportName.Text = lstGroupRpt.FocusedItem.SubItems(1).Text
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cboPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPosition.SelectedIndexChanged
        Try
            If cboPosition.SelectedIndex <> 0 Then
                Me.Text = "กำหนดสิทธิ์การใช้งานของ : " & cboPosition.Text
                'Call Get_Menu_Permit_Level(cboPosition.SelectedValue, Permit_Menu)
                Call Show_Menu_AcceptNEW(cboPosition.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class