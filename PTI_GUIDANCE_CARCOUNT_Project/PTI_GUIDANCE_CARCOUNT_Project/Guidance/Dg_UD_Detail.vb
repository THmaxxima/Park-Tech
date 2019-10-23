Imports System.Windows.Forms

Public Class Dg_UD_Detail
    Public UD_Id As String = ""
    Dim cdb As New CDatabase

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dg_UD_Detail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_detail(UD_Id)
    End Sub

    Sub Load_detail(ByVal ud_id As String)
        Try

            Dim sql As String = ""
            sql = "SELECT * FROM [dbo].[Mas_Lot] WHERE [HW_Lot_Id]='" & ud_id & "'"

            Dim DT As DataTable = cdb.readTableData(sql, ConStr_Guidance)
            If DT.Rows.Count > 0 Then
                txt_Lot_Id.Text = DT.Rows(0).Item("HW_Lot_Id").ToString
                txt_Lot_name.Text = DT.Rows(0).Item("HW_Lot_Name").ToString
                txt_buiding_Id.Text = DT.Rows(0).Item("HW_Building_ID").ToString
                txt_floor_No.Text = DT.Rows(0).Item("HW_Floor_No").ToString
                txt_Address.Text = DT.Rows(0).Item("HW_Address").ToString
                txt_Zcu_Id.Text = DT.Rows(0).Item("HW_Floorcontroller_Id").ToString
            End If
        Catch ex As Exception
            Dim frm As New Dg_msg_Error
            frm.message = "Load_detail : " & ex.Message
            frm.ShowDialog()
            frm.Dispose()
        End Try
    End Sub
End Class
