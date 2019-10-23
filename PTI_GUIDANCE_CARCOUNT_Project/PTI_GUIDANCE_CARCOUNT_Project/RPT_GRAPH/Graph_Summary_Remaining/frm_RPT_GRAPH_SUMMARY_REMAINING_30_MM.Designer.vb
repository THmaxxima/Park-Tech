<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RPT_GRAPH_SUMMARY_REMAINING_30_MM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_RPT_GRAPH_SUMMARY_REMAINING_30_MM))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdo_Bar = New System.Windows.Forms.RadioButton()
        Me.rdo_Line = New System.Windows.Forms.RadioButton()
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
        Me.CTR_Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
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
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1283, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdo_Bar)
        Me.GroupBox2.Controls.Add(Me.rdo_Line)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 47)
        Me.GroupBox2.TabIndex = 144
        Me.GroupBox2.TabStop = False
        '
        'rdo_Bar
        '
        Me.rdo_Bar.AutoSize = True
        Me.rdo_Bar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Bar.Location = New System.Drawing.Point(100, 18)
        Me.rdo_Bar.Name = "rdo_Bar"
        Me.rdo_Bar.Size = New System.Drawing.Size(71, 20)
        Me.rdo_Bar.TabIndex = 1
        Me.rdo_Bar.Text = "กราฟแท่ง"
        Me.rdo_Bar.UseVisualStyleBackColor = True
        '
        'rdo_Line
        '
        Me.rdo_Line.AutoSize = True
        Me.rdo_Line.Checked = True
        Me.rdo_Line.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Line.Location = New System.Drawing.Point(15, 18)
        Me.rdo_Line.Name = "rdo_Line"
        Me.rdo_Line.Size = New System.Drawing.Size(68, 20)
        Me.rdo_Line.TabIndex = 0
        Me.rdo_Line.TabStop = True
        Me.rdo_Line.Text = "กราฟเส้น"
        Me.rdo_Line.UseVisualStyleBackColor = True
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
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(653, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "ชั้น :"
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
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(337, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "อาคาร :"
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
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(12, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "สถานที่ :"
        '
        'TimeOut
        '
        Me.TimeOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeOut.Location = New System.Drawing.Point(722, 57)
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
        Me.TimeIn.Location = New System.Drawing.Point(463, 57)
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
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(565, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "สิ้นสุดวันที่ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(318, 60)
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
        Me.DTPickerEnd.Location = New System.Drawing.Point(637, 57)
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
        Me.DTPickerSt.Location = New System.Drawing.Point(378, 57)
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
        Me.btn_Show.Location = New System.Drawing.Point(838, 47)
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
        Me.CTR_Viewer.Location = New System.Drawing.Point(0, 100)
        Me.CTR_Viewer.Name = "CTR_Viewer"
        Me.CTR_Viewer.Size = New System.Drawing.Size(1283, 514)
        Me.CTR_Viewer.TabIndex = 4
        Me.CTR_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frm_RPT_GRAPH_SUMMARY_REMAINING_30_MM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 614)
        Me.Controls.Add(Me.CTR_Viewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_RPT_GRAPH_SUMMARY_REMAINING_30_MM"
        Me.Text = "กราฟวิเคราะห์ รถเข้า - ออก สะสม และคงเหลือ ทุก 30 นาที"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_Bar As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_Line As System.Windows.Forms.RadioButton
End Class
