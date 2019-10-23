<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RPT_Status_Sensor_History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_RPT_Status_Sensor_History))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DT_End = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DT_St = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rdo_OnLine = New System.Windows.Forms.RadioButton()
        Me.rdo_OffLine = New System.Windows.Forms.RadioButton()
        Me.cmb_Building = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_Floor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_FloorController = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_Show = New System.Windows.Forms.Button()
        Me.CTR_Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.DT_End)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DT_St)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.rdo_OnLine)
        Me.GroupBox1.Controls.Add(Me.rdo_OffLine)
        Me.GroupBox1.Controls.Add(Me.cmb_Building)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_Floor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_FloorController)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btn_Show)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1330, 104)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(49, 63)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(104, 20)
        Me.CheckBox1.TabIndex = 154
        Me.CheckBox1.Text = "ค้นหาด้วยวันที่"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DT_End
        '
        Me.DT_End.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.DT_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DT_End.Location = New System.Drawing.Point(372, 62)
        Me.DT_End.Name = "DT_End"
        Me.DT_End.Size = New System.Drawing.Size(150, 20)
        Me.DT_End.TabIndex = 153
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(312, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "ถึงวันที่ :"
        '
        'DT_St
        '
        Me.DT_St.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.DT_St.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DT_St.Location = New System.Drawing.Point(159, 63)
        Me.DT_St.Name = "DT_St"
        Me.DT_St.Size = New System.Drawing.Size(147, 20)
        Me.DT_St.TabIndex = 150
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(1033, 26)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(67, 20)
        Me.RadioButton1.TabIndex = 145
        Me.RadioButton1.Text = "ทั้งหมด"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rdo_OnLine
        '
        Me.rdo_OnLine.AutoSize = True
        Me.rdo_OnLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_OnLine.ForeColor = System.Drawing.Color.White
        Me.rdo_OnLine.Location = New System.Drawing.Point(1033, 65)
        Me.rdo_OnLine.Name = "rdo_OnLine"
        Me.rdo_OnLine.Size = New System.Drawing.Size(124, 20)
        Me.rdo_OnLine.TabIndex = 144
        Me.rdo_OnLine.Text = "อุปกรณ์ทำงานปกติ"
        Me.rdo_OnLine.UseVisualStyleBackColor = True
        '
        'rdo_OffLine
        '
        Me.rdo_OffLine.AutoSize = True
        Me.rdo_OffLine.Checked = True
        Me.rdo_OffLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_OffLine.ForeColor = System.Drawing.Color.White
        Me.rdo_OffLine.Location = New System.Drawing.Point(1033, 46)
        Me.rdo_OffLine.Name = "rdo_OffLine"
        Me.rdo_OffLine.Size = New System.Drawing.Size(103, 20)
        Me.rdo_OffLine.TabIndex = 143
        Me.rdo_OffLine.TabStop = True
        Me.rdo_OffLine.Text = "อุปกรณ์ขัดข้อง"
        Me.rdo_OffLine.UseVisualStyleBackColor = True
        '
        'cmb_Building
        '
        Me.cmb_Building.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Building.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Building.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Building.FormattingEnabled = True
        Me.cmb_Building.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cmb_Building.Location = New System.Drawing.Point(95, 21)
        Me.cmb_Building.Name = "cmb_Building"
        Me.cmb_Building.Size = New System.Drawing.Size(166, 24)
        Me.cmb_Building.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "อาคารจอดรถ :"
        '
        'cmb_Floor
        '
        Me.cmb_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Floor.FormattingEnabled = True
        Me.cmb_Floor.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cmb_Floor.Location = New System.Drawing.Point(339, 21)
        Me.cmb_Floor.Name = "cmb_Floor"
        Me.cmb_Floor.Size = New System.Drawing.Size(177, 24)
        Me.cmb_Floor.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(265, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "ชั้นจอดรถ :"
        '
        'cmb_FloorController
        '
        Me.cmb_FloorController.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_FloorController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_FloorController.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_FloorController.FormattingEnabled = True
        Me.cmb_FloorController.Items.AddRange(New Object() {"กรุณาเลือกรายการ"})
        Me.cmb_FloorController.Location = New System.Drawing.Point(651, 21)
        Me.cmb_FloorController.Name = "cmb_FloorController"
        Me.cmb_FloorController.Size = New System.Drawing.Size(251, 24)
        Me.cmb_FloorController.TabIndex = 138
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(519, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 16)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "อุปกรณ์ควบคุมตามชั้น :"
        '
        'btn_Show
        '
        Me.btn_Show.BackgroundImage = CType(resources.GetObject("btn_Show.BackgroundImage"), System.Drawing.Image)
        Me.btn_Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_Show.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Show.Location = New System.Drawing.Point(1220, 12)
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
        Me.CTR_Viewer.Location = New System.Drawing.Point(0, 104)
        Me.CTR_Viewer.Name = "CTR_Viewer"
        Me.CTR_Viewer.Size = New System.Drawing.Size(1330, 642)
        Me.CTR_Viewer.TabIndex = 4
        Me.CTR_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frm_RPT_Status_Sensor_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1330, 746)
        Me.Controls.Add(Me.CTR_Viewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frm_RPT_Status_Sensor_History"
        Me.Text = "รายงานการเชื่อมต่ออุปกรณ์ตรวจสอบ (Sensor)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_Building As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_FloorController As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_Show As System.Windows.Forms.Button
    Friend WithEvents CTR_Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents rdo_OnLine As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_OffLine As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents DT_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DT_St As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
