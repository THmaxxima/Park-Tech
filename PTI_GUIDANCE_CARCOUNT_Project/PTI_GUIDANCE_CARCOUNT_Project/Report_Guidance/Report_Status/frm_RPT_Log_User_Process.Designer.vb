<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RPT_Log_User_Process
    Inherits DevComponents.DotNetBar.Office2007Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_RPT_Log_User_Process))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TimeOut = New System.Windows.Forms.DateTimePicker()
        Me.TimeIn = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPickerSt = New System.Windows.Forms.DateTimePicker()
        Me.btn_Show = New System.Windows.Forms.Button()
        Me.CTR_Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboUser)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TimeOut)
        Me.GroupBox1.Controls.Add(Me.TimeIn)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTPickerEnd)
        Me.GroupBox1.Controls.Add(Me.DTPickerSt)
        Me.GroupBox1.Controls.Add(Me.btn_Show)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1272, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cboUser
        '
        Me.cboUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cboUser.Location = New System.Drawing.Point(610, 18)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(251, 24)
        Me.cboUser.TabIndex = 138
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(543, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "พนักงาน :"
        '
        'TimeOut
        '
        Me.TimeOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeOut.Location = New System.Drawing.Point(419, 19)
        Me.TimeOut.Name = "TimeOut"
        Me.TimeOut.ShowUpDown = True
        Me.TimeOut.Size = New System.Drawing.Size(82, 22)
        Me.TimeOut.TabIndex = 134
        Me.TimeOut.Value = New Date(2006, 10, 14, 11, 0, 24, 812)
        '
        'TimeIn
        '
        Me.TimeIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeIn.Location = New System.Drawing.Point(160, 19)
        Me.TimeIn.Name = "TimeIn"
        Me.TimeIn.ShowUpDown = True
        Me.TimeIn.Size = New System.Drawing.Size(80, 22)
        Me.TimeIn.TabIndex = 132
        Me.TimeIn.Value = New Date(2006, 10, 14, 11, 0, 24, 842)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(262, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "สิ้นสุดวันที่ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "เริ่มวันที่ :"
        '
        'DTPickerEnd
        '
        Me.DTPickerEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerEnd.Location = New System.Drawing.Point(334, 19)
        Me.DTPickerEnd.Name = "DTPickerEnd"
        Me.DTPickerEnd.Size = New System.Drawing.Size(187, 22)
        Me.DTPickerEnd.TabIndex = 133
        Me.DTPickerEnd.Value = New Date(2006, 10, 14, 11, 0, 24, 912)
        '
        'DTPickerSt
        '
        Me.DTPickerSt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerSt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerSt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerSt.Location = New System.Drawing.Point(75, 19)
        Me.DTPickerSt.Name = "DTPickerSt"
        Me.DTPickerSt.Size = New System.Drawing.Size(185, 22)
        Me.DTPickerSt.TabIndex = 131
        Me.DTPickerSt.Value = New Date(2006, 10, 14, 11, 0, 24, 922)
        '
        'btn_Show
        '
        Me.btn_Show.BackgroundImage = CType(resources.GetObject("btn_Show.BackgroundImage"), System.Drawing.Image)
        Me.btn_Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Show.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Show.Location = New System.Drawing.Point(867, 9)
        Me.btn_Show.Name = "btn_Show"
        Me.btn_Show.Size = New System.Drawing.Size(98, 43)
        Me.btn_Show.TabIndex = 13
        '
        'CTR_Viewer
        '
        Me.CTR_Viewer.ActiveViewIndex = -1
        Me.CTR_Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTR_Viewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CTR_Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTR_Viewer.Location = New System.Drawing.Point(0, 57)
        Me.CTR_Viewer.Name = "CTR_Viewer"
        Me.CTR_Viewer.Size = New System.Drawing.Size(1272, 689)
        Me.CTR_Viewer.TabIndex = 1
        Me.CTR_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frm_RPT_Log_User_Process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1272, 746)
        Me.Controls.Add(Me.CTR_Viewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frm_RPT_Log_User_Process"
        Me.Text = "รายงานการทำรายการของผู้ใช้งานระบบ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CTR_Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btn_Show As System.Windows.Forms.Button
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TimeOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents TimeIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPickerSt As System.Windows.Forms.DateTimePicker
End Class
