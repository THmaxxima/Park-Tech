Public Class Frm_Accept_Service
    Friend callpoint_id As String = ""
    Dim cdb As New CDatabase
    Private Sub Frm_Accept_Service_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        load_data(callpoint_id)
        cmb_user()
        load_Accept_data(callpoint_id)
    End Sub
    Sub load_data(ByVal call_point_id As String)
        Dim sql As String = ""

        sql = "SELECT * FROM V_Mas_Callpoint WHERE HW_Call_Id='" & call_point_id & "'"

        Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
        If dt.Rows.Count > 0 Then
            TextBox1.Text = dt.Rows(0).Item("HW_Call_Id").ToString
            TextBox2.Text = dt.Rows(0).Item("HW_Datetime_In").ToString
            TextBox3.Text = CurUser_FullName

            If dt.Rows(0).Item("HW_Accept_Action").ToString = "0" Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If

        End If
    End Sub
    Sub cmb_user()

        Try
            Dim sql As String = ""
            sql = "SELECT User_ID,User_FirstName + ' ' + User_LastName as NAME_ FROM V_Mas_User "
            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            If dt.Rows.Count > 0 Then
                'Cmb_ZCU.Items.Clear()
                With ComboBox1
                    .DataSource = dt
                    .DisplayMember = "NAME_"
                    .ValueMember = "User_ID"
                End With
              
                With ComboBox2
                    .DataSource = dt
                    .DisplayMember = "NAME_"
                    .ValueMember = "User_ID"
                End With

            End If
        Catch ex As Exception
            MsgBox("can not load function cmb_user :" & ex.Message)
        End Try


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If User_ID = "" Or ComboBox1.SelectedValue = "" Then
            MsgBox("ข้อมูลไม่ครบ")
            Exit Sub
        End If
        update_(callpoint_id)
        load_Accept_data(callpoint_id)
    End Sub

    Sub update_(ByVal call_point_id As String)
        Try
            Dim sql As String = ""
            sql = "UPDATE Mas_CallPoint SET HW_Accept_Action=1,HW_Accept_Datetime=GETDATE(),User_Accept='" & User_ID & "',User_Service='" & ComboBox1.SelectedValue & "' WHERE HW_Call_Id='" & call_point_id & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                sql = "UPDATE [Transaction_Callpoint_IN] SET HW_Accept_Action=1,HW_Accept_Datetime=GETDATE(),User_Accept='" & User_ID & "',User_Service='" & ComboBox1.SelectedValue & "' WHERE Trn_Lot_Id = '" & call_point_id & "'"
                If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then

                End If
                MsgBox(msg_update(0))
            Else
                MsgBox(msg_update(1))
            End If
        Catch ex As Exception
            MsgBox("can not load function update_ :" & ex.Message)
        End Try

    End Sub

    Sub load_Accept_data(ByVal call_point_id As String)
        Dim sql As String = ""
        Try
            sql = "SELECT * FROM V_Mas_Callpoint WHERE HW_Call_Id='" & call_point_id & "' and HW_Accept_Action='1'"

            Dim dt As DataTable = cdb.readTableData(sql, ConStr_Master)
            DataGridViewX1.Rows.Clear()
            If dt.Rows.Count > 0 Then
                DataGridViewX1.Rows.Add(dt.Rows(0).Item("User_Service").ToString, dt.Rows(0).Item("User_Name_Service").ToString, dt.Rows(0).Item("HW_Accept_Datetime").ToString)
            End If
        Catch ex As Exception
            MsgBox("can not load function load_Accept_data :" & ex.Message)
        End Try
       
    End Sub

    Private Sub DataGridViewX1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim v As String = DataGridViewX1.Rows(e.RowIndex).Cells(0).Value
            Try
                ComboBox2.SelectedValue = v
                Panel1.Visible = True
            Catch ex As Exception
                MsgBox("DataGridViewX1_CellContentClick : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            Dim sql As String = ""
            sql = "UPDATE Mas_CallPoint SET User_Accept='" & CurUser_ID & "',User_Service='" & ComboBox2.SelectedValue & "' WHERE HW_Call_Id='" & callpoint_id & "'"

            If cdb.ExcuteNoneQury(sql, ConStr_Guidance) = True Then
                MsgBox(msg_update(0))
            Else
                MsgBox(msg_update(1))
            End If
            Panel1.Visible = False
            load_Accept_data(callpoint_id)
        Catch ex As Exception
            MsgBox("can not load function Button2_Click :" & ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Panel1.Visible = False
        load_Accept_data(callpoint_id)
    End Sub
End Class