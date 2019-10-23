Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frm_Display_CallPoint
    Dim cdb As New CDatabase
    Dim Zcu_count As Integer = 30
    Dim buiding As String = "1"
    Dim callpoint_id As String = ""
    Dim floor As String = ""
    Dim zcu As String = ""
    Dim color_set(12) As Color
    Dim A As Integer = 0
    Dim R As Integer = 0
    Dim G As Integer = 0
    Dim B As Integer = 0


    Private Sub frm_Display_CallPoint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
        Timer3.Enabled = False
        Timer2.Enabled = True
        'set_color_floor()
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
        Load_IP()
        ping_ip()
        For i As Integer = 0 To 99
            ProgressBar1.PerformStep()
            'System.Threading.Thread.Sleep(100)
            Application.DoEvents()
        Next
        Load_Callpoint()
        Timer1.Enabled = True

    End Sub
    Sub ping_ip()

        If Label3.Text <> "" Then
            Try

                If My.Computer.Network.Ping(Label3.Text) Then
                    'PB_Backoffice.Image = My.Resources.Netdrive_Connected
                    PB_Backoffice.BackColor = Color.Lime
                    Label5.ForeColor = Color.Green
                    Label5.Text = "NETWORK : ONLINE"

                Else
                    'PB_Backoffice.Image = My.Resources.NetDrive_disconnect
                    PB_Backoffice.BackColor = Color.Red
                    Label5.ForeColor = Color.Red
                    Label5.Text = "NETWORK : OFFLINE"
                End If
            Catch ex As Exception
                PB_Backoffice.BackColor = Color.Red
                Label5.ForeColor = Color.Red
                Label5.Text = "NETWORK : OFFLINE"
            End Try

        End If

        If Label6.Text <> "" Then
            Try
                If My.Computer.Network.Ping(Label6.Text) Then
                    'PB_Server.Image = My.Resources.Netdrive_Connected
                    PB_Server.BackColor = Color.Lime
                    Label7.ForeColor = Color.Green
                    Label7.Text = "NETWORK : ONLINE"
                Else
                    'PB_Server.Image = My.Resources.NetDrive_disconnect
                    PB_Server.BackColor = Color.Red
                    Label7.ForeColor = Color.Red
                    Label7.Text = "NETWORK : OFFLINE"
                End If
            Catch ex As Exception
                PB_Server.BackColor = Color.Red
                Label7.ForeColor = Color.Red
                Label7.Text = "NETWORK : OFFLINE"
            End Try
        End If

    End Sub
    Sub Load_IP()
        Try
            Dim sql As String = ""
            Label1.Text = ""
            Label2.Text = ""
            Label3.Text = ""
            Label6.Text = ""

            sql = "SELECT DISTINCT * FROM MAS_CCU_Alive WHERE Type in('0','1')"
            Dim dt As DataTable
            dt = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("Type").ToString = "1" Then
                        Label2.Text = dt.Rows(i).Item("NAME_").ToString
                        Label3.Text = dt.Rows(i).Item("IP").ToString
                    End If
                    If dt.Rows(i).Item("Type").ToString = "0" Then
                        Label1.Text = dt.Rows(i).Item("NAME_").ToString
                        Label6.Text = dt.Rows(i).Item("IP").ToString

                        If dt.Rows(i).Item("Online").ToString = "1" Then
                            Label9.ForeColor = Color.Green
                            Label9.Text = "SERVICE : ONLINE"
                        Else
                            Label9.ForeColor = Color.Red
                            Label9.Text = "SERVICE : OFFLINE"
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Load_Callpoint()
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

        sql = "SELECT DISTINCT  * FROM [V_Mas_Callpoint] order by [HW_Building_ID],[HW_Floor_No],[HW_Call_Id] asc"
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


                If floor_current <> DT.Rows(i).Item("HW_Floor_No").ToString Then
                    floor_current = DT.Rows(i).Item("HW_Floor_No").ToString
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
                    .Name = DT.Rows(i).Item("HW_Call_Id").ToString
                    .Text = DT.Rows(i).Item("HW_Call_Id").ToString
                    .TextAlign = ContentAlignment.BottomCenter

                    If DT.Rows(i).Item("HW_On_Line").ToString = "1" Then
                        .Image = My.Resources.Netdrive_Connected48
                        .BackColor = bg_color
                    Else
                        .Image = My.Resources.NetDrive_disconnect48
                        .BackColor = bg_color
                    End If

                    AddHandler .Click, AddressOf Me.Zcu_Click
                    AddHandler .MouseHover, AddressOf Me.Zcu_Hover
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

        sql = "SELECT DISTINCT  * FROM [V_Mas_Callpoint] order by [HW_Building_ID],[HW_Floor_No],HW_Floorcontroller_Id,[HW_Call_Id] asc"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Zcu_count = DT.Rows.Count - 1
            ' ProgressBar1.Maximum = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                A = DT.Rows(i).Item("Color_floorA").ToString
                R = DT.Rows(i).Item("Color_floorR").ToString
                G = DT.Rows(i).Item("Color_floorG").ToString
                B = DT.Rows(i).Item("Color_floorB").ToString

                If floor_current <> DT.Rows(i).Item("HW_Floor_No").ToString Then
                    floor_current = DT.Rows(i).Item("HW_Floor_No").ToString
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
                    .Name = DT.Rows(i).Item("HW_Call_Id").ToString
                    .Text = DT.Rows(i).Item("HW_Call_Id").ToString
                    .TextAlign = ContentAlignment.BottomCenter
                    If DT.Rows(i).Item("HW_On_Line").ToString = "1" Then
                        .Image = My.Resources.Netdrive_Connected48
                        .BackColor = bg_color
                    Else
                        .Image = My.Resources.NetDrive_disconnect48
                        .BackColor = bg_color
                    End If

                    AddHandler .Click, AddressOf Me.Zcu_Click
                    AddHandler .MouseHover, AddressOf Me.Zcu_Hover
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
        Dim lbl_ As Button = sender
        MsgBox(lbl_.Name)
    End Sub
    Private Sub Zcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lbl_ As Button = sender
        Dim zcu_name As String
        zcu_name = lbl_.name
        Dim frm As New frmNew_Callpoint_Alert
        With frm
            .Building_ID = Me.buiding
            .callpoint_id = Me.callpoint_id
            .ZCU_ID = Me.zcu
            .Floor_no = Me.floor

            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub Zcu_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn_ As Button = sender
        Dim lbl_ As Label = Label4
        Dim panel_ As Panel = Pl_detail
        With panel_
            lbl_.Text = Load_ZCU(btn_.Name.ToString)
            lbl_.BringToFront()
            '.Location = New Point(Cursor.Position.X - 20, Cursor.Position.Y - 20)
            .Visible = True
            .BringToFront()
            lbl_.BringToFront()
        End With
    End Sub
    Function load_zcu(ByVal id_ As String)
        Dim txt_ As String = ""
        Dim sql As String = ""
        sql = "SELECT DISTINCT  * FROM V_Mas_Callpoint WHERE HW_Call_Id='" & id_ & "' order by HW_Building_ID,HW_Floor_No,HW_Floorcontroller_Id,HW_Call_Id"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Me.callpoint_id = DT.Rows(0).Item("HW_Call_Id").ToString
            Me.floor = DT.Rows(0).Item("HW_Floor_No").ToString
            Me.zcu = DT.Rows(0).Item("HW_Floorcontroller_Id").ToString
            Me.buiding = DT.Rows(0).Item("HW_Building_ID").ToString

            txt_ = "ID : " & DT.Rows(0).Item("HW_Call_Id").ToString & vbNewLine
            txt_ &= "Buiding : " & DT.Rows(0).Item("Building_Name").ToString & vbNewLine
            txt_ &= "Floor : " & DT.Rows(0).Item("Floor_Name").ToString & vbNewLine
            txt_ &= "Zcu ID : " & DT.Rows(0).Item("HW_Floorcontroller_Id").ToString & vbNewLine
            If DT.Rows(0).Item("HW_On_Line").ToString = "1" Then
                Label8.Text = "Status : ONLINE"
                Label8.ForeColor = Color.Lime
                Label8.BringToFront()
            Else
                Label8.Text = "Status : OFFINE"
                Label8.ForeColor = Color.Red
                Label8.BringToFront()
            End If

        End If

        Return txt_
    End Function
    Private Sub Zcu_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Pl_detail.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Load_IP()
        ping_ip()
        Application.DoEvents()
        Timer1.Enabled = True
    End Sub

    Private Sub frm_Display_CallPoint_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        frm_Display_CallPoint_Load(e, Nothing)
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
            load_Callpoint(dp.Name, dp)
        Next
        Timer3.Enabled = True
    End Sub

    Function load_Callpoint(ByVal id_ As String, ByRef pg As Button)
        Dim txt_ As String = ""
        Dim sql As String = ""
        sql = "SELECT DISTINCT * FROM Mas_CallPoint WHERE [HW_Call_Id] = '" & id_ & "'"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
        If DT.Rows.Count > 0 Then
            With pg
                If DT.Rows(0).Item("HW_On_Line").ToString = "1" Then
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
End Class