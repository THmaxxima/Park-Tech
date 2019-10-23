<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGen_Map_Address
    Inherits DevComponents.DotNetBar.Office2007Form  'Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.lbl_Show = New System.Windows.Forms.Label()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.dgv_Detail = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarX1
        '
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.Class = ""
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(775, 30)
        Me.ProgressBarX1.TabIndex = 0
        Me.ProgressBarX1.Text = "ProgressBarX1"
        '
        'lbl_Show
        '
        Me.lbl_Show.AutoSize = True
        Me.lbl_Show.Location = New System.Drawing.Point(337, 55)
        Me.lbl_Show.Name = "lbl_Show"
        Me.lbl_Show.Size = New System.Drawing.Size(84, 13)
        Me.lbl_Show.TabIndex = 1
        Me.lbl_Show.Text = "กรุณารอสักครู่...."
        Me.lbl_Show.Visible = False
        '
        'btn_Save
        '
        Me.btn_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Save.Location = New System.Drawing.Point(685, 48)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(102, 27)
        Me.btn_Save.TabIndex = 2
        Me.btn_Save.Text = "บันทึกข้อมูล"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'dgv_Detail
        '
        Me.dgv_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detail.Location = New System.Drawing.Point(12, 98)
        Me.dgv_Detail.Name = "dgv_Detail"
        Me.dgv_Detail.Size = New System.Drawing.Size(255, 234)
        Me.dgv_Detail.TabIndex = 3
        '
        'frmGen_Map_Address
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 81)
        Me.Controls.Add(Me.dgv_Detail)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.lbl_Show)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGen_Map_Address"
        Me.Text = "Genarate Map Address"
        CType(Me.dgv_Detail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents lbl_Show As System.Windows.Forms.Label
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents dgv_Detail As System.Windows.Forms.DataGridView
End Class
