Public Class Frm_Main_display
    Dim CDB As New CDatabase
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        load_main()
        Timer1.Enabled = True
    End Sub

    Sub load_main()
        Dim sql As String = ""
        sql = " SELECT  [ID_Display]"
        sql &= "  ,[Display_Type]"
        sql &= "  ,[Display_Lot_all]"
        sql &= "  ,[Display_Lot_Emply]"
        sql &= "  ,[Display_Lot_Full],DP_Direction_ID"
        sql &= " ,DP_Direction_ID"
        sql &= "  FROM [MTL_MASTER_GUIDANCE].[dbo].[V_MAS_Display_Config_Data]"
        sql &= "  WHERE [Display_Type] in('Main','MAIN')"

        Dim dt As DataTable = CDB.readTableData(sql, ConStr_Master)
        Lbl_Sum_A.Text = 0
        Lbl_Sum_B.Text = 0
        Lbl_Sum_C.Text = 0
        DGV_Mas_floor.Rows.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                'Dim pbb As New PictureBox
                'NEW_Load_Direction(dt.Rows(i).Item("DP_Direction_ID").ToString, pbb)

                DGV_Mas_floor.Rows.Add(dt.Rows(i).Item("ID_Display").ToString, dt.Rows(i).Item("Display_Lot_all").ToString, dt.Rows(i).Item("Display_Lot_Emply").ToString, dt.Rows(i).Item("Display_Lot_Full").ToString)
                Lbl_Sum_A.Text = CInt(Lbl_Sum_A.Text) + CInt(dt.Rows(i).Item("Display_Lot_all").ToString)
                Lbl_Sum_B.Text = CInt(Lbl_Sum_B.Text) + CInt(dt.Rows(i).Item("Display_Lot_Emply").ToString)
                Lbl_Sum_C.Text = CInt(Lbl_Sum_C.Text) + CInt(dt.Rows(i).Item("Display_Lot_Full").ToString)
            Next
            Application.DoEvents()
        End If
    End Sub

    Private Sub DGV_Mas_floor_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Mas_floor.CellContentClick
        Try
            Timer1.Enabled = False
        If e.ColumnIndex = 4 Then
            Dim v As String = DGV_Mas_floor.Rows(e.RowIndex).Cells(0).Value
            Dim frm As New Frm_Display_Detail
            With frm
                .buiding_id = "1"
                .floor_No = "1"
                .type_id = "1"
                .Display_id = v
                    .Show()
                '.Dispose()
            End With
        End If

            If e.ColumnIndex = 5 Then
                Dim v As String = DGV_Mas_floor.Rows(e.RowIndex).Cells(0).Value
                If MsgBox("คุณต้องการลบข้อมูลทั้งหมดของป้ายนี้ ใช่หรือไม่", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Delete_display(v)
                    load_main()
                End If
            End If
            Timer1.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Sub Delete_display(ByVal id_ As String)
        Try
            Dim sql As String = "DELETE FROM [MAS_Display_Config] WHERE [ID_Display]='" & id_ & "'"
            If CDB.ExcuteNoneQury(sql, ConStr_Master) = True Then
                sql = "DELETE FROM [MAS_Display_Config_Detail] WHERE [ID_Display]='" & id_ & "'"
                If CDB.ExcuteNoneQury(sql, ConStr_Master) = True Then

                Else

                End If
                MsgBox(msg_delete(0))
            Else
                MsgBox(msg_delete(1))
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Delete_display", Err.Number, Err.Description)
        End Try
    End Sub
    Sub NEW_Load_Direction(ByVal ID_ As String, ByRef PB As PictureBox)
        For Each A As PictureBox In Panel1.Controls
            If A.Tag = ID_ Then
                PB.Image = A.Image
                Exit For
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Timer1.Enabled = False

        Insert_data()
        Button2.Enabled = True
        Timer1.Enabled = True
    End Sub

    Sub Insert_data()
        Try
            Dim sql As String = ""
            sql = " INSERT INTO [dbo].[MAS_Display_Config]"
            sql &= "  ([ID_Display]"
            sql &= "  ,[Display_Name]"
            sql &= "  ,[Display_Type]"
            sql &= "  ,[ZCU_Parent]"
            sql &= "  ,[DP_Address]"
            sql &= "  ,[Floor_No]"
            sql &= "  ,[DP_Color]"
            sql &= "  ,[DP_Position_X]"
            sql &= "  ,[DP_Position_Y]"
            sql &= "  ,[DP_Size_Width]"
            sql &= "  ,[DP_Size_Height]"
            sql &= "  ,[Building_ID]"
            sql &= "  ,[Tower_ID]"
            sql &= "  ,[Font_ColorA]"
            sql &= "  ,[Font_ColorR]"
            sql &= "  ,[Font_ColorG]"
            sql &= "  ,[Font_ColorB]"
            sql &= "  ,[Back_ColorA]"
            sql &= "  ,[Back_ColorR]"
            sql &= "  ,[Back_ColorG]"
            sql &= "  ,[Back_ColorB]"
            sql &= "  ,[Font_Size]"
            sql &= "  ,[DP_Mode_ID]"
            sql &= "  ,[DP_Color_Font_ID]"
            sql &= "  ,[DP_Color_Arrow_ID]"
            sql &= "  ,[DP_Direction_ID]"
            sql &= "  ,[DP_Font_Style_ID])"
            sql &= "  VALUES"
            sql &= "  ((SELECT ISNULL(MAX([ID_Display]),0)+1 FROM [MTL_MASTER_GUIDANCE].[dbo].[MAS_Display_Config])"
            sql &= "  ,'MAIN DISPLAY'"
            sql &= "  ,'Main'"
            sql &= "  ,'1'"
            sql &= "  ,(SELECT ISNULL(MAX([DP_Address]),0)+1 FROM [MTL_MASTER_GUIDANCE].[dbo].[MAS_Display_Config])"
            sql &= "  ,'1'"
            sql &= "  ,''"
            sql &= "  ,'0'"
            sql &= "  ,'0'"
            sql &= "  ,'50'"
            sql &= "  ,'30'"
            sql &= "  ,'1'"
            sql &= "  ,'1'"
            sql &= "  ,255"
            sql &= "  ,255"
            sql &= "  ,0"
            sql &= "  ,0"
            sql &= "  ,255"
            sql &= "  ,0"
            sql &= "  ,0"
            sql &= "  ,0"
            sql &= "  ,16"
            sql &= "  ,0"
            sql &= "  ,0"
            sql &= "  ,0"
            sql &= "  ,1"
            sql &= "  ,1)"

            If CDB.ExcuteNoneQury(sql, ConStr_Master) = True Then
                MsgBox(msg_save(0))
                load_main()
            Else
                MsgBox(msg_save(1))
            End If
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "Insert_data", Err.Number, Err.Description)
        End Try
    End Sub
End Class