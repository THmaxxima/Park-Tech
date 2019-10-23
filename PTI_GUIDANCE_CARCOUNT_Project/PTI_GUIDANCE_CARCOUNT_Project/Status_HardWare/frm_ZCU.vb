Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_ZCU
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


    Private Sub frm_ZCU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
        Timer3.Enabled = False
        Timer2.Enabled = True
        'set_color_floor()

        If Me.Width > 1200 Then
            Dim x_new As Integer = (Me.Width - Panel1.Width) / 2
            Dim y_new As Integer = 4
            If Me.Height > 600 Then
                y_new = (SplitContainer1.Panel2.Height - Panel1.Height) / 2
            End If
            Panel1.Location = New Point(x_new, y_new)
        End If
        Load_Tower()
        Load_floor("")
    End Sub

    Sub Load_Tower()
        Try
            Dim sql As String = ""
            sql = "SELECT Building_ID,Building_Name FROM Mas_Building_Parking "
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                CB_Tower.DataSource = dt
                CB_Tower.DisplayMember = "Building_Name"
                CB_Tower.ValueMember = "Building_ID"
                'CB_Tower.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("can not load function Load_Tower :" & ex.Message)
        End Try

    End Sub

    Sub Load_floor(ByVal buiding_id As String)
        Try
            Dim sql As String = ""
            If buiding_id <> "" Then
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor] WHERE [Building_ID]='" & buiding_id & "'"
            Else
                sql = "SELECT [Floor_ID],[Floor_Name] FROM [Mas_Floor]"
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
        ProgressBar1.Visible = True
        ProgressBar1.Maximum = 100
        ProgressBar1.Step = 1
        ProgressBar1.Value = 0
        Application.DoEvents()
     
        For i As Integer = 0 To 99
            ProgressBar1.PerformStep()
            'System.Threading.Thread.Sleep(100)
            Application.DoEvents()
        Next
        Load_ZCU()
        Timer1.Enabled = True

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

        ProgressBar1.Maximum = 100
        ProgressBar1.Step = 1
        ProgressBar1.Value = 0

        sql = "SELECT DISTINCT  * FROM [V_Mas_Floor_Controller] order by [Building_ID],[Floor_No] asc"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Zcu_count = DT.Rows.Count - 1
            ProgressBar1.Maximum = DT.Rows.Count - 1
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
                ProgressBar1.PerformStep()
                Application.DoEvents()
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
        ProgressBar1.Visible = False
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

            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("Building_ID").ToString <> "" Then
                    CB_Tower.SelectedValue = DT.Rows(0).Item("Building_ID").ToString
                Else
                    CB_Tower.SelectedValue = 0
                End If

                If DT.Rows(0).Item("Floor_No").ToString <> "" Then
                    CB_Floor.SelectedValue = DT.Rows(0).Item("Floor_No").ToString
                Else
                    CB_Floor.SelectedValue = 0
                End If

                TextBox1.Text = DT.Rows(0).Item("Floor_Controller_Name").ToString
                TextBox2.Text = DT.Rows(0).Item("Floor_Controller_No").ToString
                TextBox3.Text = DT.Rows(0).Item("Floor_Controller_Max_Lot").ToString
                TextBox4.Text = DT.Rows(0).Item("Floor_Controller_Status").ToString

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

    Private Sub frm_ZCU_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        frm_ZCU_Load(e, Nothing)
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

   
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        clear_text()

    End Sub

    Sub clear_text()

        For Each txt_ As TextBox In ZCU_Detail.Controls
            txt_.Clear()
        Next
        CB_Floor.SelectedIndex = 0
        CB_Tower.SelectedIndex = 0
    End Sub
End Class