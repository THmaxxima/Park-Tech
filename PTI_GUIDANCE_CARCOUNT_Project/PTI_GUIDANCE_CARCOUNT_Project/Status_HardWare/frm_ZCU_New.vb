Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class frm_ZCU_New
    Dim cdb As New CDatabase
    Dim Zcu_count As Integer = 30
    Dim buiding As String = ""
    Dim floor As String = ""
    Dim zcu As String = ""
    Dim color_set(12) As Color
    Dim A As Integer = 0
    Dim R As Integer = 0
    Dim G As Integer = 0
    Dim B As Integer = 0
    Dim zcu_select_id As String = ""

    Private Sub frm_ZCU_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        'ProgressBar1.Visible = False
        'Timer3.Enabled = False
        'Timer2.Enabled = True
        ''set_color_floor()

        'If Me.Width > 1200 Then
        '    Dim x_new As Integer = (Me.Width - Panel1.Width) / 2
        '    Dim y_new As Integer = 4
        '    If Me.Height > 600 Then
        '        y_new = (SplitContainer1.Panel2.Height - Panel1.Height) / 2
        '    End If
        '    Panel1.Location = New Point(x_new, y_new)
        'End If
        Load_Tower()
        Load_floor("")
        Load_Tree_Node()
        SuperTabControl1.Tabs(0).Visible = True
        SuperTabControl1.Tabs(1).Visible = False
    End Sub
    Sub Load_tree_Node()
        Dim sql As String = ""
        Try

     
            sql = "SELECT * FROM Mas_Floor_Controller order by ID"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            TreeView1.Nodes.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                With TreeView1
                    .Nodes.Add(i).Text = dt.Rows(i).Item("Floor_Controller_Name").ToString
                    .Nodes(i).Name = dt.Rows(i).Item("ID").ToString
                    .Nodes(i).Tag = dt.Rows(i).Item("ID").ToString
                    .Nodes(i).Checked = False

                        Dim ssql As String = "SELECT COUNT(*) AS UD_Count FROM [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Mas_Lot] WHERE HW_Floorcontroller_Id = '" & dt.Rows(i).Item("ID").ToString & "'"
                    Dim DTT As DataTable = cdb.readTableData(ssql, ConStr_Master)

                    If DTT.Rows.Count > 0 Then
                        For ii As Integer = 0 To DTT.Rows.Count - 1
                                .Nodes(i).Nodes.Add(ii).Text = "UD = " & DTT.Rows(ii).Item("UD_Count").ToString
                                .Nodes(i).Nodes(ii).Name = ii
                                .Nodes(i).Nodes(ii).Tag = ii
                            .Nodes(i).Nodes(ii).Checked = False
                        Next
                    End If
                End With
            Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Tower()
        Try
            Dim sql As String = ""
            sql = "SELECT Building_ID,Building_Name FROM Mas_Building_Parking "
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                With CB_Tower
                    .DataSource = dt
                    .DisplayMember = "Building_Name"
                    .ValueMember = "Building_ID"
                End With
                'CB_Tower.SelectedIndex = 0
                With ComboBox2
                    .DataSource = dt
                    .DisplayMember = "Building_Name"
                    .ValueMember = "Building_ID"
                End With

            End If
        Catch ex As Exception
            MsgBox("can not load function Load_Tower :" & ex.Message)
        End Try

    End Sub

    Sub Load_floor(ByVal buiding_id As String)
        Try
            Dim sql As String = ""
            If buiding_id <> "" Then
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] WHERE [Building_ID]='" & buiding_id & "' order by Floor_ID"
            Else
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] order by Floor_ID"
            End If

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                CB_Floor.DataSource = dt
                CB_Floor.DisplayMember = "Floor_Name"
                CB_Floor.ValueMember = "Floor_ID"
                'CB_Floor.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_floor :" & ex.Message)
        End Try

    End Sub
    Sub Load_floor_Add(ByVal buiding_id As String)
        Try
            Dim sql As String = ""
            If buiding_id <> "" Then
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] WHERE [Building_ID]='" & buiding_id & "' order by Floor_ID"
            Else
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] order by Floor_ID"
            End If

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                ComboBox1.DataSource = dt
                ComboBox1.DisplayMember = "Floor_Name"
                ComboBox1.ValueMember = "Floor_ID"
                'CB_Floor.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_floor :" & ex.Message)
        End Try

    End Sub

    Sub set_color_floor()
        color_set(0) = Color.PeachPuff
        color_set(1) = Color.Khaki
        color_set(2) = Color.GreenYellow
        color_set(3) = Color.Aquamarine
        color_set(4) = Color.PaleTurquoise
        color_set(5) = Color.AliceBlue
        color_set(6) = Color.LightSteelBlue
        color_set(7) = Color.Lavender
        color_set(8) = Color.Plum
        color_set(9) = Color.Pink
        color_set(10) = Color.White
        color_set(11) = Color.Gray
        color_set(12) = Color.Black
    End Sub
    Sub load_frm()
        'ProgressBar1.Visible = True
        'ProgressBar1.Maximum = 100
        'ProgressBar1.Step = 1
        'ProgressBar1.Value = 0
        'Application.DoEvents()

        'For i As Integer = 0 To 99
        '    ProgressBar1.PerformStep()
        '    'System.Threading.Thread.Sleep(100)
        '    Application.DoEvents()
        'Next
        ' Load_ZCU()
        'Timer1.Enabled = True

    End Sub


    Sub Load_ZCU()
        Panel6.Controls.Clear()
        Dim point_x As Integer = 10
        Dim point_y As Integer = 10
        Dim count_ As Integer = 0
        Dim sql As String = ""
        Dim floor_current As String = ""
        Dim change_color_Index As Integer = 0
        Dim bg_color As New Color

        'ProgressBar1.Maximum = 100
        'ProgressBar1.Step = 1
        'ProgressBar1.Value = 0

        sql = "SELECT DISTINCT  * FROM [V_Mas_Floor_Controller] order by [Building_ID],[Floor_No] asc"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Zcu_count = DT.Rows.Count - 1
            ' ProgressBar1.Maximum = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                If DT.Rows(i).Item("Color_floorA").ToString = "" Then
                    A = 0
                    R = 0
                    G = 0
                    B = 255
                Else
                    A = DT.Rows(i).Item("Color_floorA").ToString
                    R = DT.Rows(i).Item("Color_floorR").ToString
                    G = DT.Rows(i).Item("Color_floorG").ToString
                    B = DT.Rows(i).Item("Color_floorB").ToString
                End If


                If floor_current <> DT.Rows(i).Item("Floor_No").ToString Then
                    floor_current = DT.Rows(i).Item("Floor_No").ToString
                    bg_color = Color.FromArgb(A, R, G, B)
                    'bg_color = color_set(change_color_Index)
                    change_color_Index = change_color_Index + 1
                End If

                point_x = (100 * count_)
                If (point_x + 100) >= Panel6.Width Then
                    point_y = point_y + 100
                    count_ = 0
                    point_x = 10
                End If

                Dim pb_obj As New Button
                Dim pb_label As New Label

                With pb_obj
                    If i = 0 Then
                        .Location = New Point(10, 10)
                    Else
                        .Location = New Point(point_x, point_y)
                    End If

                    .Width = 83
                    .Height = 88
                    .Name = DT.Rows(i).Item("Floor_Controller_ID").ToString
                    .Text = DT.Rows(i).Item("Floor_Controller_ID").ToString
                    .TextAlign = ContentAlignment.BottomCenter

                    If DT.Rows(i).Item("Floor_Controller_Status").ToString = "1" Then
                        .Image = My.Resources.Netdrive_Connected48
                        .BackColor = bg_color
                    Else
                        .Image = My.Resources.NetDrive_disconnect48
                        .BackColor = bg_color
                    End If

                    AddHandler .Click, AddressOf Me.Zcu_Click
                    'AddHandler .MouseHover, AddressOf Me.Zcu_Hover
                    AddHandler .MouseLeave, AddressOf Me.Zcu_leave

                    '.SizeMode = PictureBoxSizeMode.StretchImage
                    '.BorderStyle = BorderStyle.Fixed3D
                    Panel6.Controls.Add(pb_obj)
                End With
                ' ProgressBar1.PerformStep()
                'Application.DoEvents()
                System.Threading.Thread.Sleep(50)
                count_ = count_ + 1

                'pb_label.Location = New Point(pb_obj.Location.X, pb_obj.Location.Y)
                'pb_label.Width = pb_obj.Width
                'pb_label.Height = 40
                'pb_label.Text = DT.Rows(i).Item("Floor_Controller_Name").ToString
                'pb_label.BringToFront()
                'pb_label.BackColor = Color.Black
                'pb_label.ForeColor = Color.Yellow
                'Panel6.Controls.Add(pb_label)
            Next

        End If
        '  ProgressBar1.Visible = False
    End Sub

    Sub Ping_ZCU()
        Panel6.Controls.Clear()
        Dim point_x As Integer = 10
        Dim point_y As Integer = 10
        Dim count_ As Integer = 0
        Dim sql As String = ""
        Dim floor_current As String = ""
        Dim change_color_Index As Integer = 0
        Dim bg_color As New Color

        'ProgressBar1.Maximum = 100
        'ProgressBar1.Step = 1
        'ProgressBar1.Value = 0

        sql = "SELECT DISTINCT  * FROM [V_Mas_Floor_Controller] order by [Building_ID],[Floor_No] asc"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Zcu_count = DT.Rows.Count - 1
            ' ProgressBar1.Maximum = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                A = DT.Rows(i).Item("Color_floorA").ToString
                R = DT.Rows(i).Item("Color_floorR").ToString
                G = DT.Rows(i).Item("Color_floorG").ToString
                B = DT.Rows(i).Item("Color_floorB").ToString

                If floor_current <> DT.Rows(i).Item("Floor_No").ToString Then
                    floor_current = DT.Rows(i).Item("Floor_No").ToString
                    bg_color = Color.FromArgb(A, R, G, B)
                    'bg_color = color_set(change_color_Index)
                    change_color_Index = change_color_Index + 1
                End If

                point_x = (100 * count_)
                If (point_x + 100) >= Panel6.Width Then
                    point_y = point_y + 100
                    count_ = 0
                    point_x = 10
                End If

                Dim pb_obj As New Button
                Dim pb_label As New Label

                With pb_obj
                    If i = 0 Then
                        .Location = New Point(10, 10)
                    Else
                        .Location = New Point(point_x, point_y)
                    End If

                    .Width = 83
                    .Height = 88
                    .Name = DT.Rows(i).Item("Floor_Controller_ID").ToString
                    .Text = DT.Rows(i).Item("Floor_Controller_ID").ToString
                    .TextAlign = ContentAlignment.BottomCenter
                    If DT.Rows(i).Item("Floor_Controller_Status").ToString = "1" Then
                        .Image = My.Resources.Netdrive_Connected48
                        .BackColor = bg_color
                    Else
                        .Image = My.Resources.NetDrive_disconnect48
                        .BackColor = bg_color
                    End If

                    AddHandler .Click, AddressOf Me.Zcu_Click
                    'AddHandler .MouseHover, AddressOf Me.Zcu_Hover
                    AddHandler .MouseLeave, AddressOf Me.Zcu_leave
                    'AddHandler .Validated, AddressOf Me.Zcu_refresh
                    '.SizeMode = PictureBoxSizeMode.StretchImage
                    '.BorderStyle = BorderStyle.Fixed3D

                    'pb_label = Label8
                    'pb_label.Location = New Point(pb_obj.Location.X, pb_obj.Location.Y)
                    'pb_label.BringToFront()


                    Panel6.Controls.Add(pb_obj)
                    'Panel6.BringToFront()
                    'Panel6.Controls.Add(Label8)
                    'Panel6.Controls.Add(pb_label)
                End With
                'ProgressBar1.PerformStep()
                Application.DoEvents()
                'System.Threading.Thread.Sleep(50)
                count_ = count_ + 1

                'pb_label.Location = New Point(pb_obj.Location.X, pb_obj.Location.Y)
                'pb_label.Width = pb_obj.Width
                'pb_label.Height = 40
                'pb_label.Text = DT.Rows(i).Item("Floor_Controller_Name").ToString
                'pb_label.BringToFront()
                'pb_label.BackColor = Color.Black
                'pb_label.ForeColor = Color.Yellow
                'Panel6.Controls.Add(pb_label)
            Next

        End If
        'ProgressBar1.Visible = False
    End Sub
    Private Sub Zcu_refresh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lbl_ As PictureBox = sender
        MsgBox(lbl_.Name)
    End Sub
    Private Sub Zcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sql As String = ""
            Dim btn_ As Button = sender

            sql = "SELECT * FROM Mas_Floor_Controller WHERE Floor_Controller_ID= '" & btn_.Name & "'"


            SuperTabControlPanel1.Visible = True
            SuperTabControlPanel2.Visible = False


            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("Building_ID").ToString <> "" Then
                    CB_Tower.SelectedValue = DT.Rows(0).Item("Building_ID").ToString
                Else
                    CB_Tower.SelectedIndex = 0
                End If

                If DT.Rows(0).Item("Floor_No").ToString <> "" Then
                    CB_Floor.SelectedValue = DT.Rows(0).Item("Floor_No").ToString
                Else
                    CB_Tower.SelectedIndex = 0
                End If

                Txt_floor_controller_Name.Text = DT.Rows(0).Item("Floor_Controller_Name").ToString
                Txt_Floor_Controller_ID.Text = DT.Rows(0).Item("Floor_Controller_ID").ToString
                Txt_Max_Lot.Text = DT.Rows(0).Item("Floor_Controller_Max_Lot").ToString
                Txt_Status.Text = DT.Rows(0).Item("Floor_Controller_Status").ToString


            End If
        Catch ex As Exception

        End Try
    End Sub


    Function load_zcu(ByVal id_ As String)
        Dim txt_ As String = ""
        Dim sql As String = ""
        sql = "SELECT DISTINCT  * FROM V_Mas_Floor_Controller WHERE Floor_Controller_ID='" & id_ & "'"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            buiding = DT.Rows(0).Item("Building_ID").ToString
            floor = DT.Rows(0).Item("Floor_No").ToString
            zcu = DT.Rows(0).Item("Floor_Controller_ID").ToString

            txt_ = "ID : " & DT.Rows(0).Item("Floor_Controller_ID").ToString & vbNewLine
            txt_ &= "Buiding : " & DT.Rows(0).Item("Building_Name").ToString & vbNewLine
            txt_ &= "Floor : " & DT.Rows(0).Item("Floor_Name").ToString & vbNewLine
            If DT.Rows(0).Item("Floor_Controller_Status").ToString = "1" Then
                txt_ &= "Status : OFFINE"
            Else
                txt_ &= "Status : ONLINE"
            End If

        End If

        Return txt_
    End Function
    Private Sub Zcu_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Pl_detail.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        'Load_IP()
        'ping_ip()
        'Application.DoEvents()
        Timer1.Enabled = True
    End Sub

    Private Sub frm_ZCU_New_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        'frm_ZCU_New_Load(e, Nothing)
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        load_frm()
        Timer3.Enabled = True
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Timer3.Enabled = False
        'Ping_ZCU()
        For Each dp As Button In Panel6.Controls
            Load_ZCU(dp.Name, dp)
        Next
        Timer3.Enabled = True
    End Sub

    Function load_zcu(ByVal id_ As String, ByRef pg As Button)
        Dim txt_ As String = ""
        Dim sql As String = ""
        sql = "SELECT DISTINCT * FROM V_Mas_Floor_Controller WHERE Floor_Controller_ID='" & id_ & "'"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            With pg


                If DT.Rows(0).Item("Floor_Controller_Status").ToString = "1" Then
                    .Image = My.Resources.Netdrive_Connected48
                    '.BackColor = bg_color
                Else
                    .Image = My.Resources.NetDrive_disconnect48
                    '.BackColor = bg_color
                End If

            End With

        End If

        Return txt_
    End Function




    Sub clear_text()

        For Each txt_ As TextBox In ZCU_Detail.Controls
            txt_.Clear()
        Next
        CB_Floor.SelectedIndex = 0
        CB_Tower.SelectedIndex = 0
    End Sub

    Private Sub ButtonX1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX1.Click
        'clear_text()
        Add_ZCU()
    End Sub
    Sub Add_ZCU()

        SuperTabControl1.Tabs(0).Visible = False
        SuperTabControl1.Tabs(1).Visible = True
        Button1.Enabled = True
        For Each Tx As Object In Panel2.Controls
            If TypeOf (Tx) Is TextBox Then
                Tx.text = ""
            End If
        Next

        TXT_Add_ZCU_ID.Text = GET_ZCU_ID()
        TextBox3.Text = GET_ZCU_Controller_ID()
        TextBox5.Text = ""
        TextBox2.Text = "60"
        TextBox1.Text = "1"
        TextBox6.Text = "1"
        TextBox5.Text = ComboBox1.SelectedValue
        TextBox4.Text = "" & ComboBox1.Text & " - ZCU-ID " & TXT_Add_ZCU_ID.Text
    End Sub
    Function GET_ZCU_Controller_ID()
        Dim sql As String = ""
        Dim Id_ As String = "0"
        Try
            sql = "SELECT ISNULL(MAX([Floor_Controller_ID]),0)+1 FROM [Mas_Floor_Controller] "

            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0).ToString <> "" Then
                    Id_ = DT.Rows(0).Item(0).ToString
                End If
            End If
            Return Id_
        Catch ex As Exception
            Return Id_
        End Try
    End Function
    Function GET_ZCU_ID()
        Dim sql As String = ""
        Dim Id_ As String = "0"
        Try
            sql = "SELECT ISNULL(MAX([ID]),0)+1 FROM [Mas_Floor_Controller] "

            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item(0).ToString <> "" Then
                    Id_ = DT.Rows(0).Item(0).ToString
                End If
            End If
            Return Id_
        Catch ex As Exception
            Return Id_
        End Try
    End Function

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.Name.ToString.Length > 3 Then
            'show_detail_zcu(e.Node.Name)
        Else
            zcu_select_id = e.Node.Name


            show_detail_zcu(zcu_select_id)
            show_detail_UD(zcu_select_id)
            get_UD_ID(zcu_select_id)
            show_detail_Callpoint(zcu_select_id)
            get_Callpoint_ID(zcu_select_id)
            show_detail_Display(zcu_select_id)
        End If

    End Sub
    Sub show_detail_Display(ByVal zcu_id As String)
        Try

            Dim ssql As String = ""
            ssql = " SELECT "
            ssql &= " [ID_Display]"
            ssql &= " ,[Display_Name]    "
            ssql &= " ,[Display_Type]"
            ssql &= " ,[DP_Address]"
            ssql &= " ,[DP_Direction_ID]"
            ssql &= " ,[DP_Font_Style_ID]"
            ssql &= " ,[DP_Mode_ID]"
            ssql &= "FROM MAS_Display_Config "
            ssql &= " WHERE ZCU_Parent = '" & zcu_id & "' order by ID_Display "
            Dim dtt As DataTable = cdb.readTableData(ssql, ConStr_Master)
            DataGridViewX3.Rows.Clear()
            Label23.Text = dtt.Rows.Count
            If dtt.Rows.Count > 0 Then
                For i As Integer = 0 To dtt.Rows.Count - 1
                    With DataGridViewX3.Rows
                        .Add(dtt.Rows(i).Item("ID_Display").ToString, _
                        dtt.Rows(i).Item("Display_Name").ToString, _
                        dtt.Rows(i).Item("Display_Type").ToString, _
                        dtt.Rows(i).Item("DP_Address").ToString, _
                        dtt.Rows(i).Item("DP_Direction_ID").ToString, _
                        dtt.Rows(i).Item("DP_Font_Style_ID").ToString, _
                        dtt.Rows(i).Item("DP_Mode_ID").ToString)
                    End With
                Next
            Else

            End If
        Catch ex As Exception
            MsgBox("show_detail_Display : " & ex.Message)
        End Try
    End Sub
    Sub show_detail_zcu(ByVal floor_controller_id As String)
        SuperTabControl1.Tabs(0).Visible = True
        SuperTabControl1.Tabs(1).Visible = False
        Dim sql As String = ""
        Txt_floor_controller_Name.Text = ""
        Txt_Floor_Controller_ID.Text = ""
        Txt_Max_Lot.Text = ""
        Txt_Status.Text = ""
        CB_Tower.SelectedIndex = 0
        CB_Floor.SelectedIndex = 0


        sql = "SELECT * FROM Mas_Floor_Controller WHERE [Floor_Controller_ID]='" & floor_controller_id & "'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            Txt_floor_controller_Name.Text = dt.Rows(0).Item("Floor_Controller_Name").ToString
            Txt_Floor_Controller_ID.Text = dt.Rows(0).Item("Floor_Controller_ID").ToString
            Txt_Max_Lot.Text = dt.Rows(0).Item("Floor_Controller_Max_Lot").ToString
            Txt_Status.Text = dt.Rows(0).Item("Floor_Controller_Status").ToString
            CB_Tower.SelectedValue = dt.Rows(0).Item("Building_ID").ToString
            Load_floor(CB_Tower.SelectedValue)
            CB_Floor.SelectedValue = dt.Rows(0).Item("Floor_No").ToString


        Else

        End If
    End Sub
    Sub show_detail_UD(ByVal zcu_id As String)
        Try

      
        Dim ssql As String = ""
        ssql = " SELECT "
        ssql &= " [HW_Lot_Id]"
        ssql &= " ,[HW_Lot_Name]    "
        ssql &= " ,[HW_Address]"
        ssql &= " ,[HW_Address_Map]"
        ssql &= " ,[HW_Floorcontroller_Id]"
        ssql &= " ,[HW_Building_ID]"
        ssql &= " ,[HW_Floor_No]"
        ssql &= " ,[HW_Position_X]"
        ssql &= " ,[HW_Position_Y]  "
        ssql &= "FROM Q_Mas_Lot "
        ssql &= " WHERE HW_Floorcontroller_Id = '" & zcu_id & "' order by HW_Lot_Id "
        Dim dtt As DataTable = cdb.readTableData(ssql, ConStr_Guidance)
        DataGridViewX1.Rows.Clear()
        lbl_EXC.Text = dtt.Rows.Count
        If dtt.Rows.Count > 0 Then
            For i As Integer = 0 To dtt.Rows.Count - 1
                With DataGridViewX1.Rows
                    .Add(dtt.Rows(i).Item("HW_Lot_Id").ToString, _
                    dtt.Rows(i).Item("HW_Lot_Name").ToString, _
                    dtt.Rows(i).Item("HW_Address").ToString, _
                    dtt.Rows(i).Item("HW_Floorcontroller_Id").ToString, _
                    dtt.Rows(i).Item("HW_Building_ID").ToString, _
                    dtt.Rows(i).Item("HW_Floor_No").ToString, _
                    dtt.Rows(i).Item("HW_Position_X").ToString, _
                    dtt.Rows(i).Item("HW_Position_Y").ToString)
                End With
            Next
        Else

            End If
        Catch ex As Exception
            MsgBox("show_detail_UD : " & ex.Message)
        End Try
    End Sub
    Sub show_detail_Callpoint(ByVal zcu_id As String)
        Try


            Dim ssql As String = ""
            ssql = " SELECT "
            ssql &= " [HW_Call_Id]"
            ssql &= " ,[HW_Lot_Name]    "
            ssql &= " ,[HW_Address]"
            ssql &= " ,[HW_Address_Map]"
            ssql &= " ,[HW_Floorcontroller_Id]"
            ssql &= " ,[HW_Building_ID]"
            ssql &= " ,[HW_Floor_No]"
            ssql &= " ,[HW_Position_X]"
            ssql &= " ,[HW_Position_Y]  "
            ssql &= "FROM Mas_CallPoint "
            ssql &= " WHERE HW_Floorcontroller_Id = '" & zcu_id & "' order by HW_Call_Id "
            Dim dtt As DataTable = cdb.readTableData(ssql, ConStr_Guidance)
            DataGridViewX2.Rows.Clear()
            Label19.Text = dtt.Rows.Count
            If dtt.Rows.Count > 0 Then
                For i As Integer = 0 To dtt.Rows.Count - 1
                    With DataGridViewX2.Rows
                        .Add(dtt.Rows(i).Item("HW_Call_Id").ToString, _
                        dtt.Rows(i).Item("HW_Lot_Name").ToString, _
                        dtt.Rows(i).Item("HW_Address").ToString, _
                        dtt.Rows(i).Item("HW_Floorcontroller_Id").ToString, _
                        dtt.Rows(i).Item("HW_Building_ID").ToString, _
                        dtt.Rows(i).Item("HW_Floor_No").ToString, _
                        dtt.Rows(i).Item("HW_Position_X").ToString, _
                        dtt.Rows(i).Item("HW_Position_Y").ToString)
                    End With
                Next
            Else

            End If
        Catch ex As Exception
            MsgBox("show_detail_Callpoint : " & ex.Message)
        End Try
    End Sub
    Sub get_UD_ID(ByVal zcu_ud As String)
        sql = "SELECT top 1 isnull(HW_Address,0) + 1 FROM Q_Mas_Lot  WHERE HW_Floorcontroller_Id = '" & zcu_ud & "' order by HW_Lot_Id desc"
        Dim dtm As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        If dtm.Rows.Count > 0 Then
            TextBox7.Text = dtm.Rows(0).Item(0).ToString
        Else
            TextBox7.Text = "1"
        End If

        Dim building_id As String = CB_Tower.SelectedValue.ToString.PadLeft(2, "0")
        Dim floor_no As String = CB_Floor.SelectedValue.ToString.PadLeft(2, "0")
        Dim zcu_id As String = Txt_Floor_Controller_ID.Text.ToString.PadLeft(2, "0")
        Dim type_ud As String = "1"
        TextBox9.Text = building_id & floor_no & zcu_id & type_ud & TextBox7.Text.ToString.PadLeft(3, "0")
    End Sub

    Sub get_Callpoint_ID(ByVal zcu_ud As String)
        sql = "SELECT top 1 isnull(HW_Address,0) + 1 FROM Mas_CallPoint  WHERE HW_Floorcontroller_Id = '" & zcu_ud & "' order by HW_Call_Id desc"
        Dim dtm As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        If dtm.Rows.Count > 0 Then
            TextBox12.Text = dtm.Rows(0).Item(0).ToString
        Else
            TextBox12.Text = "1"
        End If

        Dim building_id As String = CB_Tower.SelectedValue.ToString.PadLeft(2, "0")
        Dim floor_no As String = CB_Floor.SelectedValue.ToString.PadLeft(2, "0")
        Dim zcu_id As String = Txt_Floor_Controller_ID.Text.ToString.PadLeft(2, "0")
        Dim type_ud As String = "2"
        TextBox10.Text = building_id & floor_no & zcu_id & type_ud & TextBox12.Text.ToString.PadLeft(3, "0")
    End Sub

    Private Sub CB_Tower_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CB_Tower.SelectedIndexChanged
        Try
            Load_floor(CB_Tower.SelectedValue)
        Catch ex As Exception
            Load_floor("")

        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            Load_floor_Add(ComboBox2.SelectedValue)
            TextBox6.Text = ComboBox2.SelectedValue
        Catch ex As Exception
            Load_floor_Add("")
            TextBox6.Text = "1"
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        Try
            TextBox5.Text = ComboBox1.SelectedValue

            TextBox4.Text = "" & ComboBox1.Text & " - ZCU-ID " & TXT_Add_ZCU_ID.Text
        Catch ex As Exception
            TextBox5.Text = ""

        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False
            If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Insert_Data() = True Then
                    MsgBox(msg_save(0))
                    Load_tree_Node()
                Else
                    MsgBox(msg_save(1))
                End If


            End If

        Catch ex As Exception

        End Try
    End Sub

    Function Insert_Data()
        Dim sql As String = ""
        Try
            sql &= " INSERT INTO [dbo].[Mas_Floor_Controller]"
            sql &= "   ([ID]"
            sql &= "   ,[Tower_ID]"
            sql &= "   ,[Building_ID]"
            sql &= "   ,[Floor_No]"
            sql &= "   ,[Floor_Controller_ID]"
            sql &= "   ,[Floor_Controller_No]"
            sql &= "   ,[Floor_Controller_Name]"
            sql &= "   ,[Floor_Controller_Max_Lot]"
            sql &= "   ,[Floor_Controller_Status]"
            sql &= "    ,[HW_Building_Controller_ID])"
            sql &= "  VALUES"
            sql &= "  ('" & TXT_Add_ZCU_ID.Text & "'"
            sql &= "  ,'" & ComboBox2.SelectedValue & "'"
            sql &= "  ,'" & ComboBox2.SelectedValue & "'"
            sql &= "  ,'" & ComboBox1.SelectedValue & "'"
            sql &= "  ,'" & TextBox3.Text & "'"
            sql &= "  ,'" & TextBox5.Text & "'"
            sql &= "  ,'" & TextBox4.Text & "'"
            sql &= "  ,'" & TextBox2.Text & "'"
            sql &= "  ,'" & TextBox1.Text & "'"
            sql &= "  ,'" & TextBox6.Text & "')"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ZCU_update_Click(sender As System.Object, e As System.EventArgs) Handles ZCU_update.Click

        Dim sql As String = ""
        Try
            sql &= " UPDATE [dbo].[Mas_Floor_Controller] SET "
            sql &= "   [Building_ID] = '" & CB_Tower.SelectedValue & "'"
            sql &= "   ,[Floor_No] = '" & CB_Floor.SelectedValue & "'"
            sql &= "   ,[Floor_Controller_Name] = '" & Txt_floor_controller_Name.Text.Trim & "'"
            sql &= "   ,[Floor_Controller_Max_Lot]  = '" & Txt_Max_Lot.Text & "'"
            sql &= "    ,[HW_Building_Controller_ID] = '" & CB_Tower.SelectedValue & "'"
            sql &= " WHERE [ID] = '" & Txt_Floor_Controller_ID.Text & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                If DataGridViewX1.Rows.Count > 0 Then
                    sql = "update [PTI_GUIDANCE_CARCOUNT_Project].[dbo].[Mas_Lot] SET "
                    sql &= "   [HW_Tower_ID] = '" & CB_Tower.SelectedValue & "'"
                    sql &= "   ,[HW_Building_ID] = '" & CB_Tower.SelectedValue & "'"
                    sql &= "   ,[HW_Building_Controller_ID] = '" & CB_Tower.SelectedValue & "'"
                    sql &= "   ,[HW_Floor_No] = '" & CB_Floor.SelectedValue & "'"

                    Dim building_id As String = CB_Tower.SelectedValue.ToString.PadLeft(2, "0")
                    Dim floor_no As String = CB_Floor.SelectedValue.ToString.PadLeft(2, "0")
                    Dim zcu_id As String = Txt_Floor_Controller_ID.Text.ToString.PadLeft(2, "0")
                    Dim type_ud As String = "1"

                    sql &= "   ,[HW_Lot_Id] = '" & building_id & floor_no & zcu_id & type_ud & "' + CONVERT(varchar(3),RIGHT(HW_Lot_Id,3))"
                    sql &= "   ,[HW_Lot_Name] = 'TA " & CB_Floor.Text & " CTRL" & Txt_Floor_Controller_ID.Text.ToString.PadLeft(2, "0") & " Add/' + CONVERT(varchar(3),RIGHT(HW_Lot_Id,3))"
                    sql &= "  WHERE [HW_Floorcontroller_Id]='" & Txt_Floor_Controller_ID.Text.Trim & "'"
                    If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                        MsgBox(msg_update(0))
                    Else
                        MsgBox(msg_update(1))
                    End If
                Else
                    MsgBox(msg_update(0))
                End If

            Else
                MsgBox(msg_update(1))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If MsgBox("คุณต้องการลบ UD ทั้งหมดของ ZCU นี้ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            delete_UD(Txt_Floor_Controller_ID.Text, "")
            show_detail_UD(Txt_Floor_Controller_ID.Text)
            get_UD_ID(Txt_Floor_Controller_ID.Text)
        End If
    End Sub

    Sub delete_UD(ByVal zcu_id As String, ByVal UD_id As String)
        Try
            Dim sql As String = ""
            If UD_id = "" Then
                sql = "DELETE FROM [Mas_Lot] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "'"
            Else
                sql = "DELETE FROM [Mas_Lot] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "' And HW_Lot_Id='" & UD_id & "'"
            End If

            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception
            MsgBox("delete_UD : " & ex.Message)
        End Try

    End Sub

    Private Sub DataGridViewX1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        If e.ColumnIndex = 8 Then
            Try
                Dim v As String = DataGridViewX1.Rows(e.RowIndex).Cells(0).Value

                If MsgBox(quetion_Delete, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    delete_UD(Txt_Floor_Controller_ID.Text, v)
                    show_detail_UD(Txt_Floor_Controller_ID.Text)
                    get_UD_ID(Txt_Floor_Controller_ID.Text)
                End If
            Catch ex As Exception
                MsgBox("DataGridViewX1_CellContentClick : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Insert_ud(TextBox9.Text, TextBox7.Text, TextBox8.Text)
        show_detail_UD(Txt_Floor_Controller_ID.Text)
        get_UD_ID(Txt_Floor_Controller_ID.Text)
        TextBox8.Text = ""
    End Sub

    Sub Insert_ud(ByVal start_ud As String, ByVal ud_start As String, ByVal ud_end As String)

        If start_ud = "" Or ud_start = "" Or ud_end = "" Then
            Exit Sub
        End If

        If IsNumeric(start_ud) = False Or IsNumeric(ud_start) = False Or IsNumeric(ud_end) = False Then
            Exit Sub
        End If

        If ud_start > ud_end Then
            MsgBox("เลขตั้งต้น มากกว่า เลขสิ้นสุด กรุณาป้อนใหม่")
            Exit Sub
        End If

        Dim ud_front As String = start_ud.Substring(0, 7)
        For i As Integer = ud_start To ud_end
            Insert_ud2(ud_front & i.ToString.PadLeft(3, "0"), i)
        Next

    End Sub

    Sub Insert_ud2(ByVal ud_id As String, ByVal hw_address As String)
        Try


            Dim sql As String = ""

            sql = "SELECT * FROM [Mas_Lot] WHERE [HW_Lot_Id]= '" & ud_id & "'"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If dt.Rows.Count > 0 Then


            Else
                Dim ssql As String = ""
                Dim ssql_field As String = ""
                Dim ssql_data As String = ""

                ssql_field = "HW_Lot_Id" : ssql_data = "'" & ud_id & "'"
                ssql_field &= ",HW_Lot_Name" : ssql_data &= ",'TA " & CB_Floor.Text & " CTRL" & Txt_Floor_Controller_ID.Text.ToString.PadLeft(2, "0") & " Add/" & hw_address.ToString.PadLeft(3, "0") & "'"
                ssql_field &= ",HW_Tower_ID" : ssql_data &= ",'1'"
                ssql_field &= ",HW_Building_ID" : ssql_data &= ",'" & CB_Tower.SelectedValue & "'"
                ssql_field &= ",HW_Floor_No" : ssql_data &= ",'" & CB_Floor.SelectedValue & "'"
                ssql_field &= ",HW_Floorcontroller_Id" : ssql_data &= ",'" & Txt_Floor_Controller_ID.Text & "'"
                ssql_field &= ",HW_Position_X" : ssql_data &= ",0"
                ssql_field &= ",HW_Position_Y" : ssql_data &= ",0"
                ssql_field &= ",HW_Datetime_Update" : ssql_data &= ",GETDATE()"
                'ssql_field &= ",HW_Datetime_In" : ssql_data = ""
                'ssql_field &= ",HW_Datetime_Out" : ssql_data = ""
                'ssql_field &= ",HW_Time_HH" : ssql_data = ""
                'ssql_field &= ",HW_Time_MM" : ssql_data = ""
                ssql_field &= ",HW_Status_Id" : ssql_data &= ",'" & Txt_Status.Text & "'"
                ssql_field &= ",HW_Status_Alarm_Id" : ssql_data &= ",0"
                ssql_field &= ",HW_Address" : ssql_data &= ",'" & hw_address & "'"
                ssql_field &= ",HW_Address_Map" : ssql_data &= ",'" & hw_address & "'"
                'ssql_field &= ",HW_Car_ID" : ssql_data = ""
                'ssql_field &= ",HW_Zone_Id" : ssql_data = ""
                ssql_field &= ",HW_On_Line" : ssql_data &= ",0"
                'ssql_field &= ",HW_Net_01" : ssql_data = ""
                'ssql_field &= ",HW_Net_02" : ssql_data = ""
                'ssql_field &= ",HW_Net_03" : ssql_data = ""
                'ssql_field &= ",HW_Net_04" : ssql_data = ""
                'ssql_field &= ",HW_Net_05" : ssql_data = ""
                'ssql_field &= ",HW_Remark" : ssql_data = ""
                ssql_field &= ",HW_Building_Controller_ID" : ssql_data &= ",'" & CB_Tower.SelectedValue & "'"
                ssql_field &= ",HW_Lot_Type" : ssql_data &= ",'L'"
                'ssql_field &= ",HW_Plan_Direction" : ssql_data = ""

                ssql = "INSERT INTO [dbo].[Mas_Lot](" & ssql_field & ") VALUES(" & ssql_data & ")"
                If cdb.ExcuteNoneQury(ssql, ConStr_Guidance) = True Then

                Else

                End If
            End If
        Catch ex As Exception
            MsgBox("Insert_ud2:" & ex.Message)
        End Try

    End Sub
    Sub Insert_callpoint(ByVal start_ud As String, ByVal ud_start As String, ByVal ud_end As String)

        If start_ud = "" Or ud_start = "" Or ud_end = "" Then
            Exit Sub
        End If

        If IsNumeric(start_ud) = False Or IsNumeric(ud_start) = False Or IsNumeric(ud_end) = False Then
            Exit Sub
        End If

        If ud_start > ud_end Then
            MsgBox("เลขตั้งต้น มากกว่า เลขสิ้นสุด กรุณาป้อนใหม่")
            Exit Sub
        End If

        Dim ud_front As String = start_ud.Substring(0, 7)
        For i As Integer = ud_start To ud_end
            Insert_callpoint2(ud_front & i.ToString.PadLeft(3, "0"), i)
        Next

    End Sub

    Sub Insert_callpoint2(ByVal ud_id As String, ByVal hw_address As String)
        Try


            Dim sql As String = ""

            sql = "SELECT * FROM [Mas_CallPoint] WHERE [HW_Call_Id]= '" & ud_id & "'"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If dt.Rows.Count > 0 Then


            Else
                Dim ssql As String = ""
                Dim ssql_field As String = ""
                Dim ssql_data As String = ""

                ssql_field = "HW_Call_Id" : ssql_data = "'" & ud_id & "'"
                ssql_field &= ",HW_Lot_Name" : ssql_data &= ",'TA " & CB_Floor.Text & " CTRL" & Txt_Floor_Controller_ID.Text.ToString.PadLeft(2, "0") & " Add/" & hw_address.ToString.PadLeft(3, "0") & "'"
                ssql_field &= ",HW_Tower_ID" : ssql_data &= ",'1'"
                ssql_field &= ",HW_Building_ID" : ssql_data &= ",'" & CB_Tower.SelectedValue & "'"
                ssql_field &= ",HW_Floor_No" : ssql_data &= ",'" & CB_Floor.SelectedValue & "'"
                ssql_field &= ",HW_Floorcontroller_Id" : ssql_data &= ",'" & Txt_Floor_Controller_ID.Text & "'"
                ssql_field &= ",HW_Position_X" : ssql_data &= ",0"
                ssql_field &= ",HW_Position_Y" : ssql_data &= ",0"
                ssql_field &= ",HW_Datetime_Update" : ssql_data &= ",GETDATE()"
                'ssql_field &= ",HW_Datetime_In" : ssql_data = ""
                'ssql_field &= ",HW_Datetime_Out" : ssql_data = ""
                'ssql_field &= ",HW_Time_HH" : ssql_data = ""
                'ssql_field &= ",HW_Time_MM" : ssql_data = ""
                ssql_field &= ",HW_Status_Id" : ssql_data &= ",'0'"
                ssql_field &= ",HW_Status_Alarm_Id" : ssql_data &= ",'0'"
                ssql_field &= ",HW_Address" : ssql_data &= ",'" & hw_address & "'"
                ssql_field &= ",HW_Address_Map" : ssql_data &= ",'" & hw_address & "'"
                'ssql_field &= ",HW_Car_ID" : ssql_data = ""
                'ssql_field &= ",HW_Zone_Id" : ssql_data = ""
                ssql_field &= ",HW_On_Line" : ssql_data &= ",'1'"
                'ssql_field &= ",HW_Net_01" : ssql_data = ""
                'ssql_field &= ",HW_Net_02" : ssql_data = ""
                'ssql_field &= ",HW_Net_03" : ssql_data = ""
                'ssql_field &= ",HW_Net_04" : ssql_data = ""
                'ssql_field &= ",HW_Net_05" : ssql_data = ""
                'ssql_field &= ",HW_Remark" : ssql_data = ""
                ssql_field &= ",HW_Building_Controller_ID" : ssql_data &= ",'" & CB_Tower.SelectedValue & "'"
                ssql_field &= ",HW_Lot_Type" : ssql_data &= ",'L'"
                'ssql_field &= ",HW_Plan_Direction" : ssql_data = ""

                ssql = "INSERT INTO [dbo].[Mas_CallPoint](" & ssql_field & ") VALUES(" & ssql_data & ")"
                If cdb.ExcuteNoneQury(ssql, ConStr_Guidance) = True Then

                Else

                End If
            End If
        Catch ex As Exception
            MsgBox("Insert_callpoint2 :" & ex.Message)
        End Try

    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If MsgBox("คุณต้องการลบ ZCU นี้ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            delete_Zcu(Txt_Floor_Controller_ID.Text)
            'show_detail_UD(Txt_Floor_Controller_No.Text)
            frm_ZCU_New_Load(e, Nothing)
        End If
    End Sub

    Sub delete_Zcu(ByVal zcu_id As String)
        Try
            Dim sql As String = ""
            sql = "DELETE FROM [Mas_Floor_Controller] WHERE [Floor_Controller_ID] = '" & zcu_id & "'"
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                sql = "DELETE FROM [Mas_Lot] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "'"
                If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then

                End If

                sql = "DELETE FROM [Mas_CallPoint] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "'"
                If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                End If
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception
            MsgBox("delete_Zcu : " & ex.Message)
        End Try

    End Sub
    Sub delete_callpoint(ByVal zcu_id As String, ByVal UD_id As String)
        Try
            Dim sql As String = ""
            If UD_id = "" Then
                sql = "DELETE FROM [Mas_CallPoint] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "'"
            Else
                sql = "DELETE FROM [Mas_CallPoint] WHERE [HW_Floorcontroller_Id] = '" & zcu_id & "' And HW_Call_Id = '" & UD_id & "'"
            End If

            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception
            MsgBox("delete_callpoint : " & ex.Message)
        End Try

    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        If MsgBox("คุณต้องการลบ CallPoint ทั้งหมดของ ZCU นี้ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            delete_callpoint(Txt_Floor_Controller_ID.Text, "")
            show_detail_Callpoint(Txt_Floor_Controller_ID.Text)
            get_Callpoint_ID(Txt_Floor_Controller_ID.Text)
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Insert_callpoint(TextBox10.Text, TextBox12.Text, TextBox11.Text)
        show_detail_Callpoint(Txt_Floor_Controller_ID.Text)
        get_Callpoint_ID(Txt_Floor_Controller_ID.Text)
        TextBox11.Text = ""
    End Sub

    Private Sub DataGridViewX2_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX2.CellContentClick
        If e.ColumnIndex = 8 Then
            Dim v As String = DataGridViewX2.Rows(e.RowIndex).Cells(0).Value
            Try
                If MsgBox(quetion_Delete, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    delete_callpoint(Txt_Floor_Controller_ID.Text, v)
                    show_detail_Callpoint(Txt_Floor_Controller_ID.Text)
                    get_Callpoint_ID(Txt_Floor_Controller_ID.Text)
                End If
            Catch ex As Exception
                MsgBox("DataGridViewX2_CellContentClick : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        Dim frm As New frmZCU_Config

        With frm
            .pbf_pBuiding_ID = CB_Tower.SelectedValue
            .pbf_Tower_ID = CB_Tower.SelectedValue
            .pbf_Floor_Controller_ID = Txt_Floor_Controller_ID.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ButtonX3_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX3.Click
        Dim sql As String = ""
        Dim frm As New frmZCU_Config_Zend_All
        frm.ShowDialog()
        'If MsgBox("คุณต้องการส่งข้อมูล  Config ไปที่ ZCU ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then

        '    sql = "SELECT [Building_ID],[Floor_Controller_ID] FROM Mas_Floor_Controller order by [Floor_Controller_ID] "
        '    Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        '    If DT.Rows.Count > 0 Then
        '        For i As Integer = 0 To DT.Rows.Count - 1
        '            Load_Data_To_ZCU_Config(DT.Rows(i).Item("Building_ID").ToString, DT.Rows(i).Item("Building_ID").ToString, DT.Rows(i).Item("Floor_Controller_ID").ToString)
        '        Next
        '    End If

        '    MessageBox.Show("    ส่งข้อมูล  Config ไปที่ ZCU เรียบร้อย ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else

        'End If
    End Sub

    Sub Load_Data_To_ZCU_Config(pTower_ID As String, pBuiding_ID As String, pFloor_Controller_ID As String)

        Dim sql As String = ""
        Try
            sql &= "INSERT INTO [Mas_ZCU_Update_Request]"
            sql &= "([Tower_ID]"
            sql &= ",[Building_ID]"
            sql &= ",[Floor_Controller_ID]"
            sql &= ",[Datetime_Request])"
            sql &= " VALUES("
            sql &= "'" & pTower_ID & "'," '<Tower_ID, nvarchar(50),>"
            sql &= "'" & pBuiding_ID & "'," ',<Building_ID, nvarchar(50),>"
            sql &= "'" & pFloor_Controller_ID & "'," ',<Floor_Controller_ID, nvarchar(50),>"
            sql &= "GETDATE()" ',<Datetime_Request, datetime,>"
            sql &= ")"

            If cdb.ExcuteNoneQury(ConStr_Master, sql) = True Then

            Else

            End If

        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Load_Data_To_ZCU_Config", Err.Number, Err.Description)
        End Try


    End Sub
End Class