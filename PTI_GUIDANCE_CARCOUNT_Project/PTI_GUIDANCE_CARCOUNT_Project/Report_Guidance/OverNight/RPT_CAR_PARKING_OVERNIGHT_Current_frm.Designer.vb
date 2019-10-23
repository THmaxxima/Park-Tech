<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RPT_CAR_PARKING_OVERNIGHT_frm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_RPT_CAR_PARKING_OVERNIGHT_frm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.HH_End = New System.Windows.Forms.TextBox()
        Me.HH_Start = New System.Windows.Forms.TextBox()
        Me.cmb_Floor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_Building = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_Tower = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TimeOut = New System.Windows.Forms.DateTimePicker()
        Me.TimeIn = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPickerSt = New System.Windows.Forms.DateTimePicker()
        Me.btn_Show = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CTR_Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.HH_End)
        Me.GroupBox1.Controls.Add(Me.HH_Start)
        Me.GroupBox1.Controls.Add(Me.cmb_Floor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_Building)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_Tower)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TimeOut)
        Me.GroupBox1.Controls.Add(Me.TimeIn)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTPickerEnd)
        Me.GroupBox1.Controls.Add(Me.DTPickerSt)
        Me.GroupBox1.Controls.Add(Me.btn_Show)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1283, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'HH_End
        '
        Me.HH_End.Location = New System.Drawing.Point(626, 45)
        Me.HH_End.Name = "HH_End"
        Me.HH_End.Size = New System.Drawing.Size(100, 20)
        Me.HH_End.TabIndex = 144
        '
        'HH_Start
        '
        Me.HH_Start.Location = New System.Drawing.Point(409, 48)
        Me.HH_Start.Name = "HH_Start"
        Me.HH_Start.Size = New System.Drawing.Size(100, 20)
        Me.HH_Start.TabIndex = 143
        '
        'cmb_Floor
        '
        Me.cmb_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Floor.Enabled = False
        Me.cmb_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Floor.FormattingEnabled = True
        Me.cmb_Floor.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cmb_Floor.Location = New System.Drawing.Point(685, 14)
        Me.cmb_Floor.Name = "cmb_Floor"
        Me.cmb_Floor.Size = New System.Drawing.Size(251, 24)
        Me.cmb_Floor.TabIndex = 142
        Me.cmb_Floor.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(653, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "ชั้น :"
        Me.Label4.Visible = False
        '
        'cmb_Building
        '
        Me.cmb_Building.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Building.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Building.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Building.FormattingEnabled = True
        Me.cmb_Building.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cmb_Building.Location = New System.Drawing.Point(387, 13)
        Me.cmb_Building.Name = "cmb_Building"
        Me.cmb_Building.Size = New System.Drawing.Size(251, 24)
        Me.cmb_Building.TabIndex = 140
        Me.cmb_Building.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(337, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "อาคาร :"
        Me.Label3.Visible = False
        '
        'cmb_Tower
        '
        Me.cmb_Tower.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Tower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Tower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Tower.FormattingEnabled = True
        Me.cmb_Tower.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cmb_Tower.Location = New System.Drawing.Point(66, 12)
        Me.cmb_Tower.Name = "cmb_Tower"
        Me.cmb_Tower.Size = New System.Drawing.Size(251, 24)
        Me.cmb_Tower.TabIndex = 138
        Me.cmb_Tower.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(12, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "สถานที่ :"
        Me.Label9.Visible = False
        '
        'TimeOut
        '
        Me.TimeOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeOut.Location = New System.Drawing.Point(161, 70)
        Me.TimeOut.Name = "TimeOut"
        Me.TimeOut.ShowUpDown = True
        Me.TimeOut.Size = New System.Drawing.Size(82, 22)
        Me.TimeOut.TabIndex = 134
        Me.TimeOut.Value = New Date(2006, 10, 14, 11, 0, 24, 812)
        Me.TimeOut.Visible = False
        '
        'TimeIn
        '
        Me.TimeIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeIn.Location = New System.Drawing.Point(148, 40)
        Me.TimeIn.Name = "TimeIn"
        Me.TimeIn.ShowUpDown = True
        Me.TimeIn.Size = New System.Drawing.Size(80, 22)
        Me.TimeIn.TabIndex = 132
        Me.TimeIn.Value = New Date(2006, 10, 14, 11, 0, 24, 842)
        Me.TimeIn.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(543, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "ชั่วโมงสิ้นสุด :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(321, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "ชั่วโมงเริ่มต้น :"
        '
        'DTPickerEnd
        '
        Me.DTPickerEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerEnd.Location = New System.Drawing.Point(76, 70)
        Me.DTPickerEnd.Name = "DTPickerEnd"
        Me.DTPickerEnd.Size = New System.Drawing.Size(187, 22)
        Me.DTPickerEnd.TabIndex = 133
        Me.DTPickerEnd.Value = New Date(2006, 10, 14, 11, 0, 24, 912)
        Me.DTPickerEnd.Visible = False
        '
        'DTPickerSt
        '
        Me.DTPickerSt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerSt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerSt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerSt.Location = New System.Drawing.Point(63, 40)
        Me.DTPickerSt.Name = "DTPickerSt"
        Me.DTPickerSt.Size = New System.Drawing.Size(185, 22)
        Me.DTPickerSt.TabIndex = 131
        Me.DTPickerSt.Value = New Date(2006, 10, 14, 11, 0, 24, 922)
        Me.DTPickerSt.Visible = False
        '
        'btn_Show
        '
        Me.btn_Show.BackgroundImage = CType(resources.GetObject("btn_Show.BackgroundImage"), System.Drawing.Image)
        Me.btn_Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Show.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Show.Location = New System.Drawing.Point(766, 33)
        Me.btn_Show.Name = "btn_Show"
        Me.btn_Show.Size = New System.Drawing.Size(98, 43)
        Me.btn_Show.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(302, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(585, 85)
        Me.GroupBox2.TabIndex = 145
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ป้อนจำนวนชั่วโมงที่จอด ที่ต้องการค้นหา"
        '
        'CTR_Viewer
        '
        Me.CTR_Viewer.ActiveViewIndex = -1
        Me.CTR_Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTR_Viewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CTR_Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTR_Viewer.Location = New System.Drawing.Point(0, 100)
        Me.CTR_Viewer.Name = "CTR_Viewer"
        Me.CTR_Viewer.Size = New System.Drawing.Size(1283, 514)
        Me.CTR_Viewer.TabIndex = 4
        Me.CTR_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frm_RPT_CAR_PARKING_OVERNIGHT_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 614)
        Me.Controls.Add(Me.CTR_Viewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frm_RPT_CAR_PARKING_OVERNIGHT_frm"
        Me.Text = "รายงานรถจอดค้างคืน"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_Building As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_Tower As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TimeOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents TimeIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPickerSt As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Show As System.Windows.Forms.Button
    Friend WithEvents CTR_Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents HH_End As System.Windows.Forms.TextBox
    Friend WithEvents HH_Start As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
