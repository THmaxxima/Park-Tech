Public Class frm_Mas_Event
    Private Function Function_New_Alam_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(Event_ID) from Mas_Event"
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)
                    If Not (.BOF And .EOF) Then
                        F_ID = .Fields(0).Value.ToString
                        F_ID = F_ID + 1
                    End If
                End With
            End If
        Catch ex As Exception
            F_ID = "1"
        End Try
        Return F_ID
    End Function
    Private Sub btn_Add_Alam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add_Alam.Click
        If btn_Add_Alam.Text = "เพิ่ม" Then
            btn_Edit_Alam.Enabled = False
            btn_Delete.Enabled = False

            lbl_ID.Text = Function_New_Alam_ID()
            txt_Event.Focus()
            btn_Add_Alam.ImageList = Me.img_Save
            btn_Add_Alam.Text = "บันทึก"
        Else

            If txt_Event.Text.Trim = "" Then
                MsgBox("กรุณาป้อนข้อมูลที่ต้องการบันทึก   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Event.Focus()
                Exit Sub
            End If

            'Select [Event_ID],[Event_Name],[Event_Start],[Event_Remark]
            'FROM [MTL_MASTER_GUIDANCE].[dbo].[Mas_Event]

            sql = ""
            sql &= " insert into Mas_Event ([Event_ID],[Event_Name],[Event_Start],[Event_End],[Event_Remark])"
            sql &= " values ('" & lbl_ID.Text & "'"
            sql &= " ,'" & txt_Event.Text & "'"
            sql &= " ," & mDB.DBFormatDate(DTPickerSt.Value.ToShortDateString) & ""
            sql &= " ," & mDB.DBFormatDate(DTPickerEnd.Value.ToShortDateString) & ""
            sql &= " ,'" & txt_Remark.Text & "'"
            sql &= " )"
            Call Show_Detail()
            Call defaulf_Object()

        End If
    End Sub
    Sub defaulf_Object()
        btn_Edit_Alam.Text = "แก้ไข"
        btn_Edit_Alam.Enabled = True
        btn_Edit_Alam.ImageList = Me.img_Edit

        btn_Add_Alam.Text = "เพิ่ม"
        btn_Add_Alam.Enabled = True
        btn_Add_Alam.ImageList = Me.img_Add

        lbl_ID.Text = ""

        btn_Delete.Enabled = True

    End Sub
    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If lbl_ID.Text = 0 Or lbl_ID.Text = 1 Or lbl_ID.Text = 2 Then
            MsgBox("ไม่สามารถลบข้อมูลที่เลือกได้  เนื่องจากเป็นค่าเริ่มต้นของระบบ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
        End If

        Call Show_Detail()
        Call defaulf_Object()

    End Sub

    Private Sub btn_Edit_Alam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit_Alam.Click
        If txt_Event.Text = "" Then
            MsgBox("กรุณาเลือก ข้อมูลที่ต้องการแก้ไข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            txt_Event.Enabled = False
            btn_Edit_Alam.Text = "แก้ไข"
            Exit Sub
        End If
        If btn_Edit_Alam.Text = "แก้ไข" Then
            btn_Add_Alam.Enabled = False
            btn_Delete.Enabled = False
           
            btn_Edit_Alam.ImageList = Me.img_SaveAdd
            btn_Edit_Alam.Text = "บันทึก"
        Else
            If txt_Event.Text = "" Then
                MsgBox("กรุณาป้อนข้อมูลให้ถูกต้อง    ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Event.Focus()
                Exit Sub
            End If


            Call Show_Detail()
            Call defaulf_Object()

        End If
    End Sub
    Sub Show_Detail()

        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
       
        '      SELECT TOP 1000 [Event_ID]
        '    ,[Event_Name]
        '    ,[Event_Start]
        '    ,[Event_End]
        '    ,[Event_Remark]
        'FROM [MTL_MASTER_GUIDANCE].[dbo].[Mas_Event]

        Try

        sql = "SELECT * FROM Mas_Event order by Event_ID  "
            If OpenCnn(ConnStrMasTer, Conn) Then
                With rs
                    If .State = 1 Then .Close()
                    .let_ActiveConnection(Conn)
                    .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    .Open(sql)

                    If Not (.BOF And .EOF) Then
                        lsv_Detail.Items.Clear()
                        lsv_Detail.HeaderStyle = ColumnHeaderStyle.Nonclickable
                        lsv_Detail.Alignment = ListViewAlignment.SnapToGrid
                        .MoveFirst()
                        Do While Not .EOF
                            Dim New_Ent As ListViewItem = lsv_Detail.Items.Add(rs.Fields("Event_ID").Value)
                            With New_Ent
                                .SubItems.Add("" & rs.Fields("Event_Name").Value)
                                .SubItems.Add("" & rs.Fields("Event_Start").Value)
                                .SubItems.Add("" & rs.Fields("Event_End").Value)
                                .SubItems.Add("" & rs.Fields("Event_Remark").Value)
                            End With
                            .MoveNext()
                        Loop

                    Else
                        lsv_Detail.Items.Clear()
                    End If
                End With
            End If
        rs = Nothing
        Catch ex As Exception
            Call mError.ShowError(Me.Name, "แสดงรายละเอียด การจัดงาน Event ", Err.Number, Err.Description)
        End Try
    End Sub

    Private Sub frm_Mas_Event_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DTPickerSt.Value = Now.ToShortDateString
        DTPickerSt.Value = Now.ToShortDateString
        Show_Detail()
    End Sub
End Class