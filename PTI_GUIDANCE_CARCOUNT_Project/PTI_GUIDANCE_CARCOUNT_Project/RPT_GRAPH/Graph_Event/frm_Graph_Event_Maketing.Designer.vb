<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Graph_Event_Maketing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Graph_Event_Maketing))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdo_Bar = New System.Windows.Forms.RadioButton()
        Me.rdo_Line = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DTPickerSt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTPickerEnd2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DTPickerSt = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_Floor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_Building = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_Tower = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_Show = New System.Windows.Forms.Button()
        Me.CTR_Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmb_Floor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_Building)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_Tower)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btn_Show)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1073, 150)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.ComboBox1.Location = New System.Drawing.Point(110, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(484, 24)
        Me.ComboBox1.TabIndex = 147
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(15, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 16)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "ชื่องาน Event :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdo_Bar)
        Me.GroupBox4.Controls.Add(Me.rdo_Line)
        Me.GroupBox4.Location = New System.Drawing.Point(600, 43)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(190, 38)
        Me.GroupBox4.TabIndex = 145
        Me.GroupBox4.TabStop = False
        '
        'rdo_Bar
        '
        Me.rdo_Bar.AutoSize = True
        Me.rdo_Bar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Bar.Location = New System.Drawing.Point(100, 12)
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
        Me.rdo_Line.Location = New System.Drawing.Point(15, 12)
        Me.rdo_Line.Name = "rdo_Line"
        Me.rdo_Line.Size = New System.Drawing.Size(68, 20)
        Me.rdo_Line.TabIndex = 0
        Me.rdo_Line.TabStop = True
        Me.rdo_Line.Text = "กราฟเส้น"
        Me.rdo_Line.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DTPickerSt2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.DTPickerEnd2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(395, 87)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 54)
        Me.GroupBox3.TabIndex = 144
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ช่วงเวลาสิ้นสุด"
        '
        'DTPickerSt2
        '
        Me.DTPickerSt2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerSt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerSt2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerSt2.Location = New System.Drawing.Point(67, 19)
        Me.DTPickerSt2.Name = "DTPickerSt2"
        Me.DTPickerSt2.Size = New System.Drawing.Size(109, 22)
        Me.DTPickerSt2.TabIndex = 131
        Me.DTPickerSt2.Value = New Date(2006, 10, 14, 11, 0, 24, 922)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(7, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "เริ่มวันที่ :"
        '
        'DTPickerEnd2
        '
        Me.DTPickerEnd2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerEnd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerEnd2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerEnd2.Location = New System.Drawing.Point(253, 19)
        Me.DTPickerEnd2.Name = "DTPickerEnd2"
        Me.DTPickerEnd2.Size = New System.Drawing.Size(106, 22)
        Me.DTPickerEnd2.TabIndex = 133
        Me.DTPickerEnd2.Value = New Date(2006, 10, 14, 11, 0, 24, 912)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(181, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 136
        Me.Label6.Text = "สิ้นสุดวันที่ :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPickerSt)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DTPickerEnd)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 87)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 54)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ช่วงเวลาเริ่มต้น"
        '
        'DTPickerSt
        '
        Me.DTPickerSt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerSt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerSt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerSt.Location = New System.Drawing.Point(67, 19)
        Me.DTPickerSt.Name = "DTPickerSt"
        Me.DTPickerSt.Size = New System.Drawing.Size(109, 22)
        Me.DTPickerSt.TabIndex = 131
        Me.DTPickerSt.Value = New Date(2006, 10, 14, 11, 0, 24, 922)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 22)
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
        Me.DTPickerEnd.Location = New System.Drawing.Point(253, 19)
        Me.DTPickerEnd.Name = "DTPickerEnd"
        Me.DTPickerEnd.Size = New System.Drawing.Size(106, 22)
        Me.DTPickerEnd.TabIndex = 133
        Me.DTPickerEnd.Value = New Date(2006, 10, 14, 11, 0, 24, 912)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(181, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "สิ้นสุดวันที่ :"
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
        'btn_Show
        '
        Me.btn_Show.BackgroundImage = CType(resources.GetObject("btn_Show.BackgroundImage"), System.Drawing.Image)
        Me.btn_Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Show.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Show.Location = New System.Drawing.Point(777, 97)
        Me.btn_Show.Name = "btn_Show"
        Me.btn_Show.Size = New System.Drawing.Size(111, 44)
        Me.btn_Show.TabIndex = 13
        '
        'CTR_Viewer
        '
        Me.CTR_Viewer.ActiveViewIndex = -1
        Me.CTR_Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTR_Viewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CTR_Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTR_Viewer.Location = New System.Drawing.Point(0, 150)
        Me.CTR_Viewer.Name = "CTR_Viewer"
        Me.CTR_Viewer.Size = New System.Drawing.Size(1073, 570)
        Me.CTR_Viewer.TabIndex = 6
        Me.CTR_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frm_Graph_Event_Maketing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 720)
        Me.Controls.Add(Me.CTR_Viewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Graph_Event_Maketing"
        Me.Text = "frm_Graph_Event_Maketing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPickerSt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPickerEnd2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPickerSt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Show As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_Bar As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_Line As System.Windows.Forms.RadioButton
    Friend WithEvents CTR_Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmb_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_Building As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_Tower As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
