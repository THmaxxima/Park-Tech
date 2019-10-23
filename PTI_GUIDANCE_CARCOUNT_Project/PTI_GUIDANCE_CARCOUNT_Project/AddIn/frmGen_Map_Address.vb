Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class frmGen_Map_Address

    Private Sub frmGen_Map_Address_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mMain.Load_AppConfig()
        Query_Lot_ID()
    End Sub
    Sub Query_Lot_ID()

        Dim sql As String = ""
        Try
            Con = New SqlConnection(ConStr_Guidance)
            With Con
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = ConStr_Guidance
                .Open()
            End With
            sql = " SELECT HW_Lot_Id "
            sql &= " FROM Mas_Lot "
            sql &= "  order by HW_Lot_Id  "
            sql &= ",[HW_Tower_ID]"
            sql &= ",[HW_Building_ID]"
            sql &= ",[HW_Floor_No]"
            sql &= ",[HW_Floorcontroller_Id]"
            sqlDa = New SqlDataAdapter(sql, Con)
            sqlDs = New DataSet
            sqlDa.Fill(sqlDs, "Mas_Lot")
            dgv_Detail.DataSource = sqlDs.Tables("Mas_Lot")
            Con.Close()
        Catch ex As Exception
            Con.Close()
        End Try
        Con.Close()

    End Sub

 
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        Dim log_ID As String = ""
        Dim i As Integer
        Dim sql As String = ""
        lbl_Show.Visible = True

        Try
            ProgressBarX1.Value = 0
            ProgressBarX1.Maximum = dgv_Detail.RowCount - 1
            For i = 0 To dgv_Detail.RowCount - 1
                log_ID = "" & dgv_Detail.Rows(i).Cells(0).Value.ToString()
                sql = "" & "update Mas_Lot set  HW_Address = " & i & " where HW_Lot_Id ='" & log_ID & "'"
                Try
                    Excute_SQL(ConStr_Guidance, sql)
                Catch ex As Exception
                End Try
                ProgressBarX1.Value = i
            Next
        Catch ex As Exception
        End Try
        MessageBox.Show("บันทึกข้อมูลเรียบร้อย !!!!!", "ผลการทำงาน", MessageBoxButtons.OK)
        lbl_Show.Visible = False
        Me.Close()
    End Sub
End Class