Public Class frm_Setting_Parking
    Public Location1 As String = ""
    Public Location2 As String = ""

    Property Text As Object

    Private Sub frm_Setting_Parking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mMain.Load_AppConfig()
        lsv_Mas_Status_View()
    End Sub

    Private Sub btn_Reset_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset_All.Click
        If (MsgBox("คุณต้องการ Reset ข้อมูลทั้งหมดนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
            'Call Report.Reset_All()
            Call lsv_Mas_Status_View()
            If IsLog_Process Then Call mUser.Log_User_Process(CurUser_ID, Me.Tag, "FROM", "Reset ค่าระบบทั้งหมด" & Me.Text, Me.Name, "2000" & Me.Tag, "", "")
        Else
            Exit Sub
        End If
    End Sub
    Sub lsv_Mas_Status_View()
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim i As Integer
        Try
            sql = "SELECT * FROM Mas_Terminal order by left(Name1,4),ID"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)

                    If Not (.BOF And .EOF) Then
                        lsv_Terminal.Items.Clear()
                        lsv_Terminal.HeaderStyle = ColumnHeaderStyle.Nonclickable
                        lsv_Terminal.Alignment = ListViewAlignment.SnapToGrid
                        .MoveFirst()
                        i = 0
                        Do While Not .EOF
                            i = i + 1
                            Dim New_Ent As ListViewItem = lsv_Terminal.Items.Add(i)
                            With New_Ent
                                .SubItems.Add("" & rs.Fields("ID").Value)
                                .SubItems.Add("" & rs.Fields("Name1").Value)
                                .SubItems.Add("" & rs.Fields("Name1").Value)
                                .SubItems.Add("" & rs.Fields("Parking_In").Value)
                                .SubItems.Add("" & rs.Fields("Parking_Out").Value)
                                .SubItems.Add("" & rs.Fields("Slave_ID1").Value)
                                .SubItems.Add("" & rs.Fields("Tower_ID").Value)
                                .SubItems.Add("" & rs.Fields("Max_Parking").Value)
                                .SubItems.Add("" & rs.Fields("Car_Parking").Value)
                                .SubItems.Add("" & rs.Fields("Name1").Value)
                                If rs.Fields("Status_ID1").Value = "1" Then
                                    .ForeColor = Color.Green
                                Else
                                    .ForeColor = Color.Red
                                End If
                            End With
                            .MoveNext()
                        Loop
                    Else
                        lsv_Terminal.Items.Clear()
                    End If
                End With
            End If
            rs = Nothing
            Exit Sub
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Mas_Terminal ", Err.Number, Err.Description)
        End Try

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub lsv_Terminal_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Terminal.MouseClick
        Dim Status As String = ""
        Dim Tower_Id As String = ""
        Location1 = ""
        Location2 = ""
        lbl_ID.Text = ""
        msk_In.Text = ""
        msk_Out.Text = ""
        msk_Max_Lot.Text = ""
        msk_Car_Parking.Text = ""
        txt_Floor_name.Text = ""

        With lsv_Terminal
            lbl_ID.Text = .FocusedItem.SubItems(1).Text
            Location1 = .FocusedItem.SubItems(2).Text
            Location2 = .FocusedItem.SubItems(3).Text
            msk_In.Text = .FocusedItem.SubItems(4).Text
            msk_Out.Text = .FocusedItem.SubItems(5).Text
            Status = .FocusedItem.SubItems(6).Text
            Tower_Id = .FocusedItem.SubItems(7).Text
            msk_Max_Lot.Text = .FocusedItem.SubItems(8).Text
            msk_Car_Parking.Text = .FocusedItem.SubItems(9).Text
            txt_Floor_name.Text = .FocusedItem.SubItems(10).Text
        End With
        If Status = "1" Then
            lbl_Status.Text = "Online"
            lbl_Status.ForeColor = Color.Lime
        Else
            lbl_Status.Text = "Offline"
            lbl_Status.ForeColor = Color.Red
        End If
        Call Select_Tower_Name(Tower_Id)
    End Sub
    Sub Select_Tower_Name(ByVal ID As String)
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Try
            sql = "SELECT * FROM Mas_Tower where Tower_ID = " & ID & ""
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)

                    If Not (.BOF And .EOF) Then
                        .MoveFirst()
                        lbl_Tower_Name.Text = "" & rs.Fields("Tower_Name").Value
                    Else
                        lbl_Tower_Name.Text = ""
                    End If
                End With
            End If
            rs = Nothing
            Exit Sub
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Mas_Tower ", Err.Number, Err.Description)
        End Try
    End Sub
    Private Sub lsv_Terminal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv_Terminal.SelectedIndexChanged

    End Sub
   
    Private Sub btn_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reset.Click
        Try
            Dim TrnFlg As Boolean
            Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
            sql = "Update Mas_Terminal  set Parking_In = 0, Parking_Out =  0 , Car_Parking = 0 where ID=" & lbl_ID.Text & ""
            If OpenCnn(ConnStrMasTer, Conn) Then
                Conn.BeginTrans()
                TrnFlg = True
                Conn.Execute(sql)
                If (MsgBox("คุณต้องการ Reset ข้อมูล ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                    Conn.CommitTrans()
                Else
                    Conn.RollbackTrans()
                    TrnFlg = False
                    If IsLog_Process Then Call mUser.Log_User_Process(CurUser_ID, Me.Tag, "FROM", "Reset ค่าสถานะ รหัส " & lbl_ID.Text & " " & Me.Text, Me.Name, "2000" & Me.Tag, "", "")
                End If

            End If
            Conn = Nothing
            rs = Nothing
        Catch ex As Exception
            'Call mError.ShowError(Me.Name, "Mas_Staion_Company", Err.Number, Err.Description)
        End Try
        Call lsv_Mas_Status_View()
    End Sub

    Sub Clear_Object()
        lbl_ID.Text = ""
        lbl_Tower_Name.Text = ""
        lbl_Status.Text = ""
        msk_In.Clear()
        msk_Out.Clear()
        msk_Car_Parking.Clear()
        msk_Max_Lot.Clear()
        txt_Floor_name.Clear()

        msk_In.Enabled = False
        msk_Out.Enabled = False
        msk_Car_Parking.Enabled = False
        msk_Max_Lot.Enabled = False
        txt_Floor_name.Enabled = False

    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        If btn_Edit.Text = "แก้ไข" Then
            btn_Edit.Text = "บันทึก"
            msk_In.Enabled = True
            msk_Out.Enabled = True
            msk_Car_Parking.Enabled = True
            msk_Max_Lot.Enabled = True
            txt_Floor_name.Enabled = True
            msk_In.Focus()
        Else

            Try
                Dim TrnFlg As Boolean
                Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
                sql &= " Update Mas_Terminal  set Parking_In = " & msk_In.Text & ""
                sql &= " , Parking_Out = " & msk_Out.Text & ""
                sql &= " , Max_Parking = " & msk_Max_Lot.Text & ""
                sql &= " , Car_Parking = " & msk_Car_Parking.Text & ""
                sql &= " , Name1 = '" & txt_Floor_name.Text & "'"
                '  sql &= " , Name1 =  '" & txt_Floor_name.Text & "'"
                sql &= " where ID = " & lbl_ID.Text & ""
                If OpenCnn(ConnStrMasTer, Conn) Then
                    Conn.BeginTrans()
                    TrnFlg = True
                    Conn.Execute(sql)
                    If (MsgBox("คุณต้องการ แก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                        Conn.CommitTrans()
                    Else
                        Conn.RollbackTrans()
                        TrnFlg = False
                        If IsLog_Process Then Call mUser.Log_User_Process(CurUser_ID, Me.Tag, "FROM", "แก้ไข " & Me.Text, Me.Name, "2000" & Me.Tag, "", "")

                    End If

                End If
                Conn = Nothing
                rs = Nothing
            Catch ex As Exception
                'Call mError.ShowError(Me.Name, "Mas_Staion_Company", Err.Number, Err.Description)
            End Try
            Call lsv_Mas_Status_View()

            btn_Edit.Text = "แก้ไข"
            Clear_Object()
        End If
    End Sub

    Private Sub msk_In_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_In.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            msk_Out.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub msk_In_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles msk_In.MaskInputRejected

    End Sub

    Private Sub msk_Out_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles msk_Out.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btn_Reset.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub msk_Out_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles msk_Out.MaskInputRejected

    End Sub

End Class