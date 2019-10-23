Public Class Frm_Display_Detail
    Friend buiding_id As Integer = 1
    Friend floor_No As Integer = 1
    Friend Display_id As Integer = 1

    Friend buiding_id_main As Integer = 0
    Friend floor_No_main As Integer = 0
    Friend type_id As Integer = 0
    Dim Selected_arrow As Integer = 0
    Dim cdb As New CDatabase
    Dim flug_update As Integer = 0
    Private Sub Frm_Display_Detail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Display_id
        load_cb_type()


        cmb_floor()

        

        Load_MAS_Display_Mode()
        Load_MAS_Display_Color_Font()
        Load_MAS_Display_Color_Arrow()
        Load_MAS_Display_Direction()
        Load_MAS_Display_Font_Style()
        Load_MAS_Arrow_Mode_Code()

        load_ZCU(floor_No, buiding_id)


        cb_type.Enabled = False

        If type_id = 0 Then
            Load_ZCU_parent(floor_No, buiding_id)
            cb_type.SelectedIndex = 0
            Cmb_floor_2.Enabled = True
        Else
            Load_ZCU_parent("", "")
            cb_type.SelectedIndex = 1
            Cmb_floor_2.Enabled = True
        End If

        load_Display(Display_id)
        load_DisplayDetail(Display_id)
    End Sub
    
    Sub cmb_floor()
        Dim sql As String = ""

        sql = "SELECT CONVERT(varchar(5),Building_ID) +':' + CONVERT(varchar(5),Floor_No)   AS ID_,[Building_Name] + ' : ' +  [Floor_Name] AS NAME_ FROM [MTL_MASTER_GUIDANCE].[dbo].[V_Mas_Floor] order by [Floor_ID]"
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            Cmb_floor_2.DataSource = DT
            Cmb_floor_2.ValueMember = "ID_"
            Cmb_floor_2.DisplayMember = "Name_"
            Cmb_floor_2.SelectedIndex = 0
        End If
    End Sub
    Sub load_cb_type()
        Dim sql As String = "SELECT Type_id,Type_Name from Mas_Display_Type order by type_Id"
        Try
        Dim DT As DataTable = cdb.readTableData(sql, ConStr_Master)
        If DT.Rows.Count > 0 Then
            cb_type.DataSource = DT
            cb_type.ValueMember = "Type_Name"
            cb_type.SelectedValue = "Type_id"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function GET_Max_DP_ADDRESS() As String
        Dim sql As String = ""
        Try
            sql = "SELECT ISNULL(MAX(DP_Address),'0') + 1 FROM [MAS_Display_Config] "
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item(0).ToString
            Else
                Return "1"
            End If
        Catch ex As Exception

            Return "1"
            MsgBox("GET_Max_DP_ADDRESS :" & ex.Message)
        End Try
    End Function

    Sub load_Display(ByVal display_id As String)
        Try
        Dim sql As String = ""
        sql = "SELECT * FROM MAS_Display_Config WHERE ID_Display = '" & display_id & "'"
        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("DP_Address").ToString = "" Then
                    TextBox4.Text = GET_Max_DP_ADDRESS()
                    flug_update = 1
                Else
                    TextBox4.Text = dt.Rows(0).Item("DP_Address").ToString
                End If

                TextBox2.Text = dt.Rows(0).Item("Display_Name").ToString
                'cb_mode.SelectedValue = dt.Rows(0).Item("DP_Mode_ID").ToString
                cb_type.SelectedValue = dt.Rows(0).Item("Display_Type").ToString
                If dt.Rows(0).Item("ZCU_Parent").ToString <> "" Then
                    Cb_Zcu_parent.SelectedValue = dt.Rows(0).Item("ZCU_Parent").ToString
                    flug_update = 1
                End If

                If dt.Rows(0).Item("DP_Mode_ID").ToString <> "" Then
                    cboMAS_Display_Mode.SelectedValue = dt.Rows(0).Item("DP_Mode_ID").ToString
                    flug_update = 1
                End If

                If dt.Rows(0).Item("DP_Color_Font_ID").ToString <> "" Then
                    cboMAS_Display_Color_Font.SelectedValue = dt.Rows(0).Item("DP_Color_Font_ID").ToString
                    flug_update = 1
                End If

                If dt.Rows(0).Item("DP_Color_Arrow_ID").ToString <> "" Then
                    cboMAS_Display_Color_Arrow.SelectedValue = dt.Rows(0).Item("DP_Color_Arrow_ID").ToString
                    flug_update = 1
                End If

                If dt.Rows(0).Item("DP_Direction_ID").ToString <> "" Then
                    cboMAS_Display_Direction.SelectedValue = dt.Rows(0).Item("DP_Direction_ID").ToString
                    NEW_Load_Direction_Visible(dt.Rows(0).Item("DP_Direction_ID").ToString.Trim)
                    flug_update = 1
                End If

                If dt.Rows(0).Item("DP_Font_Style_ID").ToString <> "" Then
                    cboMAS_Display_Font_Style.SelectedValue = dt.Rows(0).Item("DP_Font_Style_ID").ToString
                    flug_update = 1
                End If

                If dt.Rows(0).Item("DP_Arrow_Mode_Code").ToString <> "" Then
                    cmb_Arrow_Mode_Code.SelectedValue = dt.Rows(0).Item("DP_Arrow_Mode_Code").ToString
                    flug_update = 1
                End If
            End If
        Catch ex As Exception
            MsgBox("load_Display : " & ex.Message)
        End Try
    End Sub

    Sub load_ZCU(ByVal floor_ As String, ByVal building_ As String)
        Try
        Dim sql As String = ""
            sql = " SELECT  [Floor_Controller_ID]"
            sql &= " ,[Floor_Controller_Name] "
            sql &= "  FROM V_Mas_Floor_Controller "
            If floor_ = "" Or building_ = "" Then
                sql &= ""
            Else
                sql &= " WHERE Building_ID ='" & buiding_id & "' and Floor_No ='" & floor_ & "'"

            End If
            sql &= "order by Floor_Controller_ID "
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            DGV_ZCU.Rows.Clear()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    DGV_ZCU.Rows.Add(dt.Rows(i).Item("Floor_Controller_ID").ToString.Trim, dt.Rows(i).Item("Floor_Controller_Name").ToString.Trim)
                Next
            End If
        Catch ex As Exception
            MsgBox("load_ZCU : " & ex.Message)
        End Try
    End Sub

    Sub load_ZCU()
        Try
            Dim sql As String = ""
            sql = " SELECT  [Floor_Controller_ID]"
            sql &= " , convert(carchar(10),Floor_Controller_ID) + ' : ' +  [Floor_Controller_Name] as Floor_Controller_Name "
            sql &= "  FROM V_Mas_Floor_Controller "
            sql &= " ORDER BY ID"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                Cb_Zcu_parent.DataSource = dt
                Cb_Zcu_parent.DisplayMember = "Floor_Controller_Name"
                Cb_Zcu_parent.ValueMember = "Floor_Controller_ID"
            End If
        Catch ex As Exception
            MsgBox("load_ZCU : " & ex.Message)
        End Try
    End Sub

    Sub load_UD(ByVal floor_ As String, ByVal building_ As String, ByVal zcu_ As String, ByVal find_ As String)
        Dim sql As String = ""
        Try
        sql = " SELECT  [HW_Lot_Id]"
        sql &= " ,[HW_Lot_Name]"
        sql &= " ,[HW_Tower_ID]"
        sql &= " ,[HW_Building_ID]"
        sql &= " ,[HW_Floor_No]"
        sql &= " ,[HW_Floorcontroller_Id]"
            sql &= "  FROM Mas_Lot"
            sql &= " WHERE  HW_Floorcontroller_Id='" & zcu_ & "'"

            'If cb_type.SelectedIndex = 0 Then
            '    sql &= " WHERE HW_Building_ID='" & buiding_id & "' and HW_Floor_No='" & floor_ & "' and HW_Floorcontroller_Id='" & zcu_ & "'"
            'Else
            '    sql &= " WHERE  HW_Floorcontroller_Id='" & zcu_ & "'"
            'End If


            If find_ <> "" Then
                sql &= find_
            End If


            sql &= " and HW_Lot_Id not in(SELECT UD_Address FROM [MTL_MASTER_GUIDANCE].[dbo].[MAS_Display_Config_Detail] WHERE [ID_ZCU]='" & zcu_ & "' and [ID_Display]='" & Display_id & "')"

            'If cb_type.SelectedIndex = 0 Then
            '    sql &= " and HW_Lot_Id not in(SELECT UD_Address FROM [MTL_MASTER_GUIDANCE].[dbo].[MAS_Display_Config_Detail] WHERE [ID_ZCU]='" & zcu_ & "'"
            '    sql &= " and [ID_Display] not in(SELECT [ID_Display] FROM [MTL_MASTER_GUIDANCE].[dbo].[MAS_Display_Config] WHERE [ID_Display]='" & Display_id & "' and display_type in('Main','MAIN')))"
            'Else
            '    sql &= " and HW_Lot_Id not in(SELECT UD_Address FROM [MTL_MASTER_GUIDANCE].[dbo].[MAS_Display_Config_Detail] WHERE [ID_ZCU]='" & zcu_ & "' and [ID_Display]='" & Display_id & "')"
            'End If

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Guidance)

            Dim cb As New CheckBox
            cb.Checked = False
            DGV_UD.Rows.Clear()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    DGV_UD.Rows.Add(cb.Checked, dt.Rows(i).Item("HW_Lot_Id").ToString.Trim, dt.Rows(i).Item("HW_Lot_Name").ToString.Trim, dt.Rows(i).Item("HW_Floorcontroller_Id").ToString.Trim, dt.Rows(i).Item("HW_Building_ID").ToString.Trim, dt.Rows(i).Item("HW_Floor_No").ToString.Trim)
                Next
            End If
        Catch ex As Exception
            MsgBox("load_UD : " & ex.Message)
        End Try
    End Sub
    Sub load_DisplayDetail(ByVal display_id As String)
        Dim sql As String = ""
        Try
        sql = "SELECT * FROM MAS_Display_Config_Detail WHERE ID_Display='" & display_id & "'"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            DGV_Detail.Rows.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                DGV_Detail.Rows.Add(dt.Rows(i).Item("ID_Display_Detail").ToString, dt.Rows(i).Item("ID_ZCU").ToString.Trim, dt.Rows(i).Item("UD_Address").ToString, dt.Rows(i).Item("Floor_No").ToString.Trim, dt.Rows(i).Item("Building_No").ToString.Trim)
            Next
            End If
        Catch ex As Exception
            MsgBox("load_DisplayDetail : " & ex.Message)
        End Try
    End Sub

    Sub NEW_Load_Direction_Visible(ByVal ID_ As String)
        For Each A As PictureBox In Panel1.Controls
            If A.Tag = ID_ Then
                A.BackColor = Color.Yellow
                A.BringToFront()
                'A.Location = New Point(PB1.Location.X, PB1.Location.Y)
                'A.Visible = True
            Else
                A.BackColor = Color.Transparent
                'A.Visible = False
            End If
        Next
    End Sub
    Private Sub DGV_ZCU_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DGV_ZCU.MouseClick
        If DGV_ZCU.SelectedRows.Count = 1 Then
            If DGV_ZCU.SelectedRows(0).Cells(0).Value.ToString <> "" Then
                load_UD(floor_No, buiding_id, DGV_ZCU.SelectedRows(0).Cells(0).Value.ToString.Trim, "")
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For i As Integer = 0 To DGV_UD.Rows.Count - 1
                DGV_UD.Rows(i).Cells(0).Value = True
            Next
        Else
            For i As Integer = 0 To DGV_UD.Rows.Count - 1
                DGV_UD.Rows(i).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        load_UD(floor_No, buiding_id, DGV_ZCU.SelectedRows(0).Cells(0).Value.ToString.Trim, " and (HW_Lot_Name LIKE '%" & TextBox1.Text & "%' or HW_Lot_Id LIKE '%" & TextBox1.Text & "%')")
    End Sub

    Private Sub Update_C_Click(sender As System.Object, e As System.EventArgs) Handles Update_C.Click

        If DGV_UD.Rows.Count <= 0 Then Exit Sub

        Try
            Dim UD_Address As String = ""
            Dim ZCU_ As String = ""
            For i As Integer = 0 To DGV_UD.Rows.Count - 1
                If DGV_UD.Rows(i).Cells(0).Value = True Then
                    UD_Address = DGV_UD.Rows(i).Cells(1).Value.ToString.Trim
                    ZCU_ = DGV_UD.Rows(i).Cells(3).Value.ToString.Trim
                    buiding_id = DGV_UD.Rows(i).Cells(4).Value.ToString.Trim
                    floor_No = DGV_UD.Rows(i).Cells(5).Value.ToString.Trim
                    If insert_data_detail(UD_Address, ZCU_, floor_No, buiding_id) = True Then
                        'DGV_Detail.Rows.Add(DGV_Detail.Rows.Count, UD_Address, ZCU_, floor_No, buiding_id)
                    End If
                End If
            Next

            load_DisplayDetail(Display_id)

            If flug_update = 1 Then
                update_mas_display_config(Display_id)
                flug_update = 0
            End If

            If DGV_ZCU.SelectedRows(0).Cells(0).Value.ToString <> "" Then
                load_UD(floor_No, buiding_id, DGV_ZCU.SelectedRows(0).Cells(0).Value.ToString.Trim, "")
            End If

            CheckBox1.Checked = False
        Catch ex As Exception
            MsgBox("Update_C_Click : " & ex.Message)
        End Try

    End Sub
    Function insert_data_detail(ByVal ud_address As String, ByVal zcu As String, ByVal floor_ As String, ByVal buiding_ As String)
        Dim sql As String = ""
        Try
        sql &= " INSERT INTO [dbo].[MAS_Display_Config_Detail]"
        sql &= "   ([ID_Display_Detail]"
        sql &= "   ,[ID_Display]"
        sql &= "   ,[UD_Address]"
        sql &= "   ,[ID_ZCU]"
        sql &= "   ,[Floor_No]"
        sql &= "   ,[Building_No])"
        sql &= "   VALUES"
        sql &= "   ("
        sql &= "    (SELECT ISNULL(MAX([ID_Display_Detail]),0)+1 FROM [MAS_Display_Config_Detail] )"
        sql &= "  ,'" & Display_id & "'"
        sql &= "  ,'" & ud_address & "'"
        sql &= "  ,'" & zcu & "'"
        sql &= "  ,'" & floor_ & "'"
        sql &= "  ,'" & buiding_ & "')"

            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                'MsgBox(msg_save(0))
                Return True
            Else
                'MsgBox(msg_save(1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(msg_save(1) & ": insert_data_detail : " & ex.Message)
            Return False
        End Try
    End Function
  

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Frm_Display_Detail_Load(e, Nothing)
    End Sub

    Private Sub DGV_Detail_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Detail.CellContentClick
        If e.ColumnIndex = 5 Then
            Dim v As String = DGV_Detail.Rows(e.RowIndex).Cells(2).Value
            Try


                If MsgBox(quetion_Delete, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim sql As String = ""
                    sql = "DELETE FROM MAS_Display_Config_Detail WHERE ID_Display = '" & Display_id & "' and UD_Address= '" & v & "'"
                    If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                        MsgBox(msg_delete(0))
                        load_DisplayDetail(Display_id)
                        load_UD(floor_No, buiding_id, DGV_ZCU.SelectedRows(0).Cells(0).Value.ToString.Trim, "")
                    Else
                        MsgBox(msg_delete(1))
                    End If
                End If
            Catch ex As Exception
                MsgBox("DGV_Detail_CellContentClick : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub DGV_Detail_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_Detail.RowsAdded
        lbl_EXC.Text = DGV_Detail.Rows.Count
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Button4.Enabled = False
        update_mas_display_config(Display_id)
        Button4.Enabled = True
    End Sub

    Sub update_mas_display_config(ByVal display_id As String)
        Dim sql As String = ""

        sql = "UPDATE MAS_Display_Config SET "
        sql &= "Display_Name = '" & TextBox2.Text & "'"
        sql &= ",Display_Type = '" & cb_type.SelectedValue & "'"
        sql &= ",ZCU_Parent = '" & Cb_Zcu_parent.SelectedValue & "'"
        sql &= ",DP_Address = '" & TextBox4.Text & "'"
        sql &= ",DP_Mode_ID = '" & cboMAS_Display_Mode.SelectedValue & "'"
        sql &= ",DP_Color_Font_ID = '" & cboMAS_Display_Color_Font.SelectedValue & "'"
        sql &= ",DP_Color_Arrow_ID = '" & cboMAS_Display_Color_Arrow.SelectedValue & "'"
        sql &= ",DP_Direction_ID = '" & cboMAS_Display_Direction.SelectedValue & "'"
        sql &= ",DP_Font_Style_ID = '" & cboMAS_Display_Font_Style.SelectedValue & "'"
        sql &= ",DP_Arrow_Mode_Code = '" & cmb_Arrow_Mode_Code.SelectedValue & "'"
        sql &= " WHERE ID_Display= '" & display_id & "'"
        Try
            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                MsgBox(msg_update(0))
            Else
                MsgBox(msg_update(1))
            End If
        Catch ex As Exception
            MsgBox("update_mas_display_config :" & ex.Message)
        End Try
    End Sub

    Private Sub Cmb_floor_2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmb_floor_2.SelectedIndexChanged
        If cb_type.SelectedIndex >= 0 Then
            If Cmb_floor_2.SelectedIndex >= 0 Then
                Dim a() As String = Cmb_floor_2.SelectedValue.ToString.Split(":")
                buiding_id_main = a(0)
                floor_No_main = a(1)
                load_ZCU(floor_No_main, buiding_id_main)
                DGV_UD.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub cb_type_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_type.SelectedIndexChanged
        If cb_type.SelectedIndex = 0 Then
            Cmb_floor_2.Enabled = False
        Else
            Cmb_floor_2.Enabled = True

        End If
    End Sub
    Sub Load_ZCU_parent(ByVal floor_no As String, ByVal building_no As String)
        Try
            Dim sql As String = ""
            sql = "SELECT ID,Floor_Controller_Name FROM Mas_Floor_Controller "

            If floor_no = "" Or building_no = "" Then
                sql &= ""
            Else
                sql &= "WHERE [Building_ID]='" & building_no & "' and [Floor_No]='" & floor_no & "'"
            End If

            sql &= " order by Building_ID,Floor_No"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                Cb_Zcu_parent.DataSource = dt
                Cb_Zcu_parent.DisplayMember = "Floor_Controller_Name"
                Cb_Zcu_parent.ValueMember = "ID"
                Cb_Zcu_parent.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("Load_ZCU :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_ZCU", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Load_MAS_Display_Mode()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM MAS_Display_Mode  order by Display_Mode_Id"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                cboMAS_Display_Mode.DataSource = dt
                cboMAS_Display_Mode.DisplayMember = "Display_Mode_Name"
                cboMAS_Display_Mode.ValueMember = "Display_Mode_Id"
                cboMAS_Display_Mode.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("MAS_Display_Mode :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_cboMAS_Display_Mode", Err.Number, Err.Description)
        End Try

    End Sub

    Sub Load_MAS_Display_Color_Font()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM MAS_Display_Color_Font  order by Display_Color_Font_Id"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                cboMAS_Display_Color_Font.DataSource = dt
                cboMAS_Display_Color_Font.DisplayMember = "Display_Color_Font_Name"
                cboMAS_Display_Color_Font.ValueMember = "Display_Color_Font_Id"
                cboMAS_Display_Color_Font.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("MAS_Display_Color_Font :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_cboMAS_Display_Color_Font", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Load_MAS_Display_Color_Arrow()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM MAS_Display_Color_Arrow  order by Display_Color_Arrow_Id"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                cboMAS_Display_Color_Arrow.DataSource = dt
                cboMAS_Display_Color_Arrow.DisplayMember = "Display_Color_Arrow_Name"
                cboMAS_Display_Color_Arrow.ValueMember = "Display_Color_Arrow_Id"
                cboMAS_Display_Color_Arrow.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("MAS_Display_Color_Arrow :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_cboMAS_Display_Color_Arrow", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Load_MAS_Display_Font_Style()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM MAS_Display_Font_Style  order by Display_Font_Style_Id"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                cboMAS_Display_Font_Style.DataSource = dt
                cboMAS_Display_Font_Style.DisplayMember = "Display_Font_Style_Name"
                cboMAS_Display_Font_Style.ValueMember = "Display_Font_Style_Id"
                cboMAS_Display_Font_Style.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("MAS_Display_Font_Style :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_cboMAS_Display_Font_Style", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Load_MAS_Display_Direction()
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM MAS_Display_Direction  order by Direction_Id"
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                cboMAS_Display_Direction.DataSource = dt
                cboMAS_Display_Direction.DisplayMember = "Direction_Name"
                cboMAS_Display_Direction.ValueMember = "Direction_Id"
                cboMAS_Display_Direction.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("MAS_Display_Direction :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_Display_Direction", Err.Number, Err.Description)
        End Try

    End Sub
    Sub Load_MAS_Arrow_Mode_Code()
        Try
            Dim sql As String = ""
            Dim DT_ As New DataTable

            DT_.Columns.Add("Code")
            DT_.Columns.Add("Detail")
            DT_.Rows.Add("64", "64 : ลูกศรนิ่ง")
            DT_.Rows.Add("0", "0 : ลูกศรวิ่ง")
            'sql = "SELECT * FROM MAS_Display_Direction  order by Direction_Id"
            'Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            'If dt.Rows.Count > 0 Then
            '    'Cmb_ZCU.Items.Clear()
            cmb_Arrow_Mode_Code.DataSource = DT_
            cmb_Arrow_Mode_Code.DisplayMember = "Detail"
            cmb_Arrow_Mode_Code.ValueMember = "Code"
            cmb_Arrow_Mode_Code.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MsgBox("Load_MAS_Arrow_Mode_Code :" & ex.Message)
            Call mError.ShowError(Me.Name, "Load_MAS_Arrow_Mode_Code", Err.Number, Err.Description)
        End Try

    End Sub
    Private Sub cboMAS_Display_Direction_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMAS_Display_Direction.SelectedIndexChanged
        Try
            Selected_arrow = cboMAS_Display_Direction.SelectedValue
            NEW_Clear_Direction()
            NEW_Load_Direction(Selected_arrow)
        Catch ex As Exception

        End Try
    End Sub

    Sub NEW_Clear_Direction()
        For Each A As PictureBox In Panel1.Controls
            A.BackColor = Color.Transparent
        Next
    End Sub

    Sub NEW_Load_Direction(ByVal ID_ As String)
        For Each A As PictureBox In Panel1.Controls
            If A.Tag = ID_ Then
                A.BackColor = Color.Yellow
            Else
                A.BackColor = Color.Transparent
            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If MsgBox("คุณต้องการลบ Ultrasonic ทั้งหมดของป้ายนี้ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Delete_All_UD(Display_id)
            load_DisplayDetail(Display_id)
        End If
    End Sub

    Sub Delete_All_UD(ByVal id_ As String)
        Dim sql As String = ""
        Try
            sql = "DELETE FROM MAS_Display_Config_Detail WHERE ID_Display ='" & id_ & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Master) = True Then
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception
            MsgBox("Delete_All_UD :" & ex.Message)
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonX2.Click
        If Cb_Zcu_parent.SelectedValue.ToString = "" Then MsgBox("กรุณาเลือก ZCU Parent") : Exit Sub
        Dim frm As New frmZCU_Config
        With frm
            .pbf_pBuiding_ID = buiding_id
            .pbf_Tower_ID = buiding_id
            .pbf_Floor_Controller_ID = Cb_Zcu_parent.SelectedValue
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class