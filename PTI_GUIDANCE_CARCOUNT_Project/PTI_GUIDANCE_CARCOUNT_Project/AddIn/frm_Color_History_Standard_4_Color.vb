Imports System.Drawing
Imports System.Windows
Public Class frm_Color_History_Standard_4_Color
    Dim Back_Color As String
    Dim Color_A As Integer
    Dim Color_R As Integer
    Dim Color_G As Integer
    Dim Color_B As Integer
    Dim A, R, G, B As Integer
    Private Sub frm_Color_History_Standard_4_Color_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call lsv_Select_Mas_Alam_View()
        Call defaulf_Object()
        Call Style_ListView()
    End Sub

    Private Sub btn_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Color.Click
        With DlgCollor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fColor As String = .Color.Name
                Color_A = .Color.A
                Color_R = .Color.R
                Color_G = .Color.G
                Color_B = .Color.B
                pic_Color.Visible = False
                Back_Color = .Color.Name
                lbl_Back_Color.BackColor = .Color
            Else
                Exit Sub
            End If

        End With
    End Sub
    Private Function Function_New_Alam_ID() As String
        'ฟังก์ชันในการรันเลขที่ใบอนุญาติ
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim F_ID As String = ""
        Try
            Dim sql As String = "select Max(His_Id) from Mas_Color_History_Standard"
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
            txt_Mas_Alam.Enabled = True


            btn_Color.Enabled = True

            lbl_Mas_Alam.Text = Function_New_Alam_ID()
            txt_Mas_Alam.Focus()

            btn_Add_Alam.ImageList = Me.img_Save
            btn_Add_Alam.Text = "บันทึก"
        Else
            If Back_Color = "" Then
                MsgBox("กรุณาเลือก สีที่ท่านต้องการแสดง สถานะในระบบ   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                btn_Color.Focus()
                Exit Sub
            End If
            If txt_Mas_Alam.Text.Trim = "" Then
                MsgBox("กรุณาป้อนข้อมูลที่ต้องการบันทึก   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Mas_Alam.Focus()
                Exit Sub
            End If
            'If IsNumeric(txt_Min.Text) = False Then
            '    MsgBox("กรุณาป้อนจำนวนต่ำสุดเป็นตัวเลข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            '    txt_Min.Focus()
            '    Exit Sub
            'End If

            'If IsNumeric(txt_Max.Text) = False Then
            '    MsgBox("กรุณาป้อนจำนวนสูงสุดเป็นตัวเลข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            '    txt_Max.Focus()
            '    Exit Sub
            'End If

            'Dim pMin As Short
            'lbl_Date_Update.Text = CDate(lbl_Date_Update.Text)
            'pMin = DateDiff(DateInterval.Minute, CDate(lbl_Date_Update.Text), CDate(Now))
            'lbl_Car_In.Text = pMin \ 60 & " ชม. " & pMin Mod 60 & " นาที "


            Call Save_Mas_Alam()
            Call lsv_Select_Mas_Alam_View()
            Call defaulf_Object()
            Call Style_ListView()
        End If
    End Sub
    Sub Style_ListView()
        Dim i As Integer
        Try
            For i = 0 To (lsv_Mas_Alam.Items.Count - 1)
                With lsv_Mas_Alam
                    If .Items(i).SubItems(2).Text.ToString <> "" And .Items(i).SubItems(3).Text.ToString <> "" Then
                        A = .Items(i).SubItems(2).Text.ToString
                        R = .Items(i).SubItems(3).Text.ToString
                        G = .Items(i).SubItems(4).Text.ToString
                        B = .Items(i).SubItems(5).Text.ToString
                        .Items(i).ForeColor = Color.FromArgb(A, R, G, B)
                    Else
                        .Items(i).ForeColor = Color.FromArgb(255, 0, 0, 0)
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If lbl_Mas_Alam.Text = 0 Or lbl_Mas_Alam.Text = 1 Or lbl_Mas_Alam.Text = 2 Then
            MsgBox("ไม่สามารถลบข้อมูลที่เลือกได้  เนื่องจากเป็นค่าเริ่มต้นของระบบ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
        End If
        Call Delete_Status_Alam()
        Call lsv_Select_Mas_Alam_View()
        Call defaulf_Object()
        Call Style_ListView()
    End Sub
    Sub Delete_Status_Alam()
        If lbl_Mas_Alam.Text = 0 Or lbl_Mas_Alam.Text = 1 Or lbl_Mas_Alam.Text = 2 Then
            MsgBox("ไม่สามารถลบข้อมูลที่เลือกได้  เนื่องจากเป็นค่าเริ่มต้นของระบบ ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            Exit Sub
        End If
        If lbl_Mas_Alam.Text = "" Or txt_Mas_Alam.Text.Trim = "" Then Exit Sub
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, sql As String = "", TrnFlg As Boolean
        sql = " DELETE From Mas_Color_History_Standard WHERE His_Id = '" & lbl_Mas_Alam.Text & "'"
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If MsgBox("คุณต้องการ ลบข้อมูล รหัส  : " & lbl_Mas_Alam.Text & vbCrLf & _
                       "ชื่อ : " & txt_Mas_Alam.Text & " ใช่ หรือ ไม่ ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Confirm) = MsgBoxResult.Yes Then
                Conn.CommitTrans()
                Call lsv_Select_Mas_Alam_View()
            Else
                Conn.RollbackTrans()
                Exit Sub
            End If
        End If
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "ลขข้อมูลประวัติสีการจอด", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Edit_Alam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit_Alam.Click
        If txt_Mas_Alam.Text = "" Then
            MsgBox("กรุณาเลือก ข้อมูลที่ต้องการแก้ไข   ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
            txt_Mas_Alam.Enabled = False
            btn_Edit_Alam.Text = "แก้ไข"
            Exit Sub
        End If
        If btn_Edit_Alam.Text = "แก้ไข" Then
            btn_Add_Alam.Enabled = False
            btn_Delete.Enabled = False
            'txt_Min.Enabled = True
            'txt_Max.Enabled = True
            btn_Color.Enabled = True
            txt_Mas_Alam.Enabled = True
            txt_Mas_Alam.Focus()
            btn_Edit_Alam.ImageList = Me.img_SaveAdd
            btn_Edit_Alam.Text = "บันทึก"
        Else
            If txt_Mas_Alam.Text = "" Then
                MsgBox("กรุณาป้อนข้อมูลให้ถูกต้อง    ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Title_Error)
                txt_Mas_Alam.Focus()
                Exit Sub
            End If

            Call Update_Mas_Status_Alam()
            Call lsv_Select_Mas_Alam_View()
            Call defaulf_Object()
            Call Style_ListView()
        End If
    End Sub
    Sub Update_Mas_Status_Alam()
        Dim TrnFlg As Boolean
        If btn_Edit_Alam.Text = "แก้ไข" Then Exit Sub
        'If Back_Color = "" Then Exit Sub
        On Error GoTo Err
        Dim Conn As New ADODB.Connection, rs As New ADODB.Recordset, sql As String = ""
        sql = "Update Mas_Color_History_Standard set His_Name='" & txt_Mas_Alam.Text & _
              "', His_Color_A = " & Color_A & _
              ", His_Color_R = " & Color_R & _
              ", His_Color_G = " & Color_G & _
              ", His_Color_B = " & Color_B & _
              " where His_Id = " & lbl_Mas_Alam.Text & ""
        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            Conn.Execute(sql)
            If (MsgBox("คุณต้องการแก้ไขข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                TrnFlg = False
                'Exit Sub
            Else
                Conn.RollbackTrans()
                TrnFlg = False
            End If
        End If
        Conn = Nothing
        rs = Nothing
        Exit Sub
Err:
        Call mError.ShowError(Me.Name, "แก้ไขข้อมูลสีสี มาตรฐาน 4 สี ", Err.Number, Err.Description)
    End Sub
    Sub lsv_Select_Mas_Alam_View()
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim dt As DataTable
        Dim dc As DataColumn
        Dim dr As DataRow
        Dim Row_Color As String
        sql = "SELECT * FROM Mas_Color_History_Standard "
        Dim tl As Integer
        If OpenCnn(ConnStrMasTer, Conn) Then
            With rs
                If .State = 1 Then .Close()
                .let_ActiveConnection(Conn)
                .CursorLocation = ADODB.CursorLocationEnum.adUseClient
                .CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                .Open(sql)

                If Not (.BOF And .EOF) Then
                    lsv_Mas_Alam.Items.Clear()
                    lsv_Mas_Alam.HeaderStyle = ColumnHeaderStyle.Nonclickable
                    lsv_Mas_Alam.Alignment = ListViewAlignment.SnapToGrid
                    .MoveFirst()
                    If .RecordCount >= 5 Then
                        btn_Add_Alam.Visible = False
                    End If
                    Do While Not .EOF

                        Dim New_Ent As ListViewItem = lsv_Mas_Alam.Items.Add(rs.Fields("His_Id").Value)
                        With New_Ent
                            .SubItems.Add("" & rs.Fields("His_Name").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_A").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_R").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_G").Value)
                            .SubItems.Add("" & rs.Fields("His_Color_B").Value)

                        End With
                        .MoveNext()
                    Loop

                Else
                    lsv_Mas_Alam.Items.Clear()
                End If
            End With
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        Call mError.ShowError(Me.Name, "แสดงรายละเอียด ประวัติสีการจอดรถ", Err.Number, Err.Description)
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Call defaulf_Object()
    End Sub
    Sub defaulf_Object()
        btn_Edit_Alam.Text = "แก้ไข"
        btn_Edit_Alam.Enabled = True
        btn_Edit_Alam.ImageList = Me.img_Edit

        btn_Add_Alam.Text = "เพิ่ม"
        btn_Add_Alam.Enabled = True
        btn_Add_Alam.ImageList = Me.img_Add

        lbl_Mas_Alam.Text = ""
        txt_Mas_Alam.Clear()
        'txt_Min.Text = 0

        'txt_Max.Text = 0
        txt_Mas_Alam.Enabled = False
        'txt_Min.Enabled = False
        'txt_Max.Enabled = False

        btn_Delete.Enabled = True
        btn_Color.Enabled = False
        pic_Color.Visible = True
    End Sub
    Sub Save_Mas_Alam()
        Dim I As Object
        On Error GoTo Err_Renamed
        Dim Conn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String
        Dim TrnFlg As Boolean

        If OpenCnn(ConnStrMasTer, Conn) Then
            Conn.BeginTrans()
            TrnFlg = True
            sql = " Insert into Mas_Color_History_Standard  Values (" & Trim(lbl_Mas_Alam.Text) & _
                  ",'" & txt_Mas_Alam.Text & "'," & Color_A & "," & Color_R & _
                  "," & Color_G & "," & Color_B & ")"
            Conn.Execute(sql)

            If (MsgBox("คุณต้องการบันทึกข้อมูลนี้ ใช่ หรือ ไม่ ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Confirm) = MsgBoxResult.Yes) Then
                Conn.CommitTrans()
                Exit Sub
            Else
                Conn.RollbackTrans()
                TrnFlg = False
            End If
        End If
        rs = Nothing
        Exit Sub
Err_Renamed:
        If TrnFlg = True Then Conn.RollbackTrans()
        Call mError.ShowError(Me.Name, "บันทึกประวิติสีการจอด", Err.Number, Err.Description)
    End Sub

    Private Sub lsv_Mas_Alam_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv_Mas_Alam.MouseClick
        Try
            Dim Conn As New ADODB.Connection
            Dim rs As New ADODB.Recordset
            Dim sql As String = ""

            With lsv_Mas_Alam
                lbl_Mas_Alam.Text = .FocusedItem.SubItems(0).Text
                txt_Mas_Alam.Text = .FocusedItem.SubItems(1).Text
                If .FocusedItem.SubItems(2).Text <> "" Then
                    A = .FocusedItem.SubItems(2).Text
                    R = .FocusedItem.SubItems(3).Text
                    G = .FocusedItem.SubItems(4).Text
                    B = .FocusedItem.SubItems(5).Text
                    Color_A = A
                    Color_R = R
                    Color_G = G
                    Color_B = B

                    lbl_ColorA.Text = "" & A
                    lbl_ColorR.Text = "" & R
                    lbl_ColorG.Text = "" & G
                    lbl_ColorB.Text = "" & B

                    lbl_Back_Color.BackColor = Color.FromArgb(A, R, G, B)
                    pic_Color.Visible = False
                Else
                    pic_Color.Visible = True
                End If
            End With
        Catch ex As Exception
            pic_Color.Visible = True
            Call mError.ShowError(Me.Name, "เลือกประเภทสีการชำระ", Err.Number, Err.Description)
            Exit Try
        End Try
    End Sub

End Class