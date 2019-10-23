Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_databiding
    Dim cdb As New CDatabase
    Dim b As BindingSource
    Dim Command As SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    ' Dim ds As DataSet
    Dim cs As New SqlConnection(ConStr_Guidance)
    Private Sub Frm_databiding_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim ds As New DataSet
        With cs
            .Close()
            If .State = ConnectionState.Open Then .Close()
            .Open()
        End With
        sql = "SELECT * FROM Mas_Hour_Parking"
        Command = New SqlCommand(sql, cs)
        'cs.ChangeDatabase("PTI_GUIDANCE_CARCOUNT_Project")
        da = New SqlDataAdapter(Command)
        da.Fill(ds, 0)
        dt = New DataTable()
        dt = ds.Tables("Mas_Hour_Parking")
        'b.DataSource = dt
        DataGridView1.DataSource = dt
        'b.ResetBindings(False)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        cs.ChangeDatabase("Mas_Hour_Parking")
        'b.ResetBindings(True)
        DataGridView1.Refresh()
    End Sub
End Class