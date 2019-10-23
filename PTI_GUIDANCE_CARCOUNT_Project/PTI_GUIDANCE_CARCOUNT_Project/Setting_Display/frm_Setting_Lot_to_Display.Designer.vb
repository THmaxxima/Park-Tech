<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Setting_Lot_to_Display
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
        Me.chk_Save_Auto = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Picture_Floor = New System.Windows.Forms.PictureBox()
        Me.lbl_Lot_ID = New System.Windows.Forms.Label()
        Me.cmb_Building = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_Tower = New System.Windows.Forms.ComboBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.chk_All_Floor = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_Zone = New System.Windows.Forms.ComboBox()
        Me.chk_Zone = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Count = New System.Windows.Forms.Label()
        Me.btn_Export_Zone = New System.Windows.Forms.Button()
        Me.lbl_Sensor = New System.Windows.Forms.Label()
        Me.lbl_Text_Zone = New System.Windows.Forms.Label()
        Me.lbl_Floor = New System.Windows.Forms.Label()
        Me.lbl_Zone_Name = New System.Windows.Forms.Label()
        Me.cmb_Floor = New System.Windows.Forms.ComboBox()
        Me.lbl_Lot_Name = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        CType(Me.Picture_Floor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chk_Save_Auto
        '
        Me.chk_Save_Auto.AutoSize = True
        Me.chk_Save_Auto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chk_Save_Auto.ForeColor = System.Drawing.Color.Green
        Me.chk_Save_Auto.Location = New System.Drawing.Point(90, 320)
        Me.chk_Save_Auto.Name = "chk_Save_Auto"
        Me.chk_Save_Auto.Size = New System.Drawing.Size(105, 17)
        Me.chk_Save_Auto.TabIndex = 92
        Me.chk_Save_Auto.Text = "บันทึกอัตโนมัติ"
        Me.chk_Save_Auto.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "รหัสอุปกรณ์ :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "อาคารจอดรถ :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Picture_Floor
        '
        Me.Picture_Floor.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Picture_Floor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture_Floor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Picture_Floor.Location = New System.Drawing.Point(9, 10)
        Me.Picture_Floor.Name = "Picture_Floor"
        Me.Picture_Floor.Size = New System.Drawing.Size(940, 675)
        Me.Picture_Floor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture_Floor.TabIndex = 63
        Me.Picture_Floor.TabStop = False
        '
        'lbl_Lot_ID
        '
        Me.lbl_Lot_ID.BackColor = System.Drawing.Color.Black
        Me.lbl_Lot_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Lot_ID.ForeColor = System.Drawing.Color.Red
        Me.lbl_Lot_ID.Location = New System.Drawing.Point(84, 213)
        Me.lbl_Lot_ID.Name = "lbl_Lot_ID"
        Me.lbl_Lot_ID.Size = New System.Drawing.Size(134, 33)
        Me.lbl_Lot_ID.TabIndex = 90
        Me.lbl_Lot_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb_Building
        '
        Me.cmb_Building.Enabled = False
        Me.cmb_Building.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Building.FormattingEnabled = True
        Me.cmb_Building.Location = New System.Drawing.Point(80, 45)
        Me.cmb_Building.Name = "cmb_Building"
        Me.cmb_Building.Size = New System.Drawing.Size(144, 21)
        Me.cmb_Building.TabIndex = 88
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "สถานที่ :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Tower
        '
        Me.cmb_Tower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Tower.FormattingEnabled = True
        Me.cmb_Tower.Location = New System.Drawing.Point(53, 18)
        Me.cmb_Tower.Name = "cmb_Tower"
        Me.cmb_Tower.Size = New System.Drawing.Size(171, 21)
        Me.cmb_Tower.TabIndex = 86
        '
        'btn_Save
        '
        Me.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Save.Location = New System.Drawing.Point(10, 342)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(74, 37)
        Me.btn_Save.TabIndex = 14
        Me.btn_Save.Text = "บันทึก"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Cancel)
        Me.GroupBox1.Controls.Add(Me.chk_All_Floor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_Zone)
        Me.GroupBox1.Controls.Add(Me.chk_Zone)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbl_Count)
        Me.GroupBox1.Controls.Add(Me.btn_Export_Zone)
        Me.GroupBox1.Controls.Add(Me.chk_Save_Auto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbl_Lot_ID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_Building)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_Tower)
        Me.GroupBox1.Controls.Add(Me.btn_Save)
        Me.GroupBox1.Controls.Add(Me.lbl_Sensor)
        Me.GroupBox1.Controls.Add(Me.lbl_Text_Zone)
        Me.GroupBox1.Controls.Add(Me.lbl_Floor)
        Me.GroupBox1.Controls.Add(Me.lbl_Zone_Name)
        Me.GroupBox1.Controls.Add(Me.cmb_Floor)
        Me.GroupBox1.Controls.Add(Me.lbl_Lot_Name)
        Me.GroupBox1.Location = New System.Drawing.Point(955, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(230, 427)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.Red
        Me.btn_Cancel.Location = New System.Drawing.Point(90, 341)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(134, 37)
        Me.btn_Cancel.TabIndex = 100
        Me.btn_Cancel.Text = "ยกเลิกจัดโซนจอดรถ"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'chk_All_Floor
        '
        Me.chk_All_Floor.AutoSize = True
        Me.chk_All_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chk_All_Floor.ForeColor = System.Drawing.Color.MediumBlue
        Me.chk_All_Floor.Location = New System.Drawing.Point(70, 156)
        Me.chk_All_Floor.Name = "chk_All_Floor"
        Me.chk_All_Floor.Size = New System.Drawing.Size(114, 17)
        Me.chk_All_Floor.TabIndex = 99
        Me.chk_All_Floor.Text = "เลือกข้อมูลทั้งชั้น"
        Me.chk_All_Floor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "โซนที่เลือก :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Zone
        '
        Me.cmb_Zone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Zone.Enabled = False
        Me.cmb_Zone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Zone.FormattingEnabled = True
        Me.cmb_Zone.Location = New System.Drawing.Point(70, 126)
        Me.cmb_Zone.Name = "cmb_Zone"
        Me.cmb_Zone.Size = New System.Drawing.Size(154, 24)
        Me.cmb_Zone.TabIndex = 97
        '
        'chk_Zone
        '
        Me.chk_Zone.AutoSize = True
        Me.chk_Zone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chk_Zone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chk_Zone.Location = New System.Drawing.Point(70, 103)
        Me.chk_Zone.Name = "chk_Zone"
        Me.chk_Zone.Size = New System.Drawing.Size(137, 17)
        Me.chk_Zone.TabIndex = 96
        Me.chk_Zone.Text = "แสดงป้ายโซนที่เลือก"
        Me.chk_Zone.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "จำนวนอุปกรณ์ :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Count
        '
        Me.lbl_Count.BackColor = System.Drawing.Color.Black
        Me.lbl_Count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Count.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Count.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_Count.Location = New System.Drawing.Point(84, 279)
        Me.lbl_Count.Name = "lbl_Count"
        Me.lbl_Count.Size = New System.Drawing.Size(134, 33)
        Me.lbl_Count.TabIndex = 94
        Me.lbl_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_Export_Zone
        '
        Me.btn_Export_Zone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Export_Zone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Export_Zone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Export_Zone.Location = New System.Drawing.Point(90, 384)
        Me.btn_Export_Zone.Name = "btn_Export_Zone"
        Me.btn_Export_Zone.Size = New System.Drawing.Size(134, 37)
        Me.btn_Export_Zone.TabIndex = 93
        Me.btn_Export_Zone.Text = "ส่งออกข้อมูล โซนจอดรถ"
        Me.btn_Export_Zone.UseVisualStyleBackColor = True
        '
        'lbl_Sensor
        '
        Me.lbl_Sensor.AutoSize = True
        Me.lbl_Sensor.Location = New System.Drawing.Point(23, 256)
        Me.lbl_Sensor.Name = "lbl_Sensor"
        Me.lbl_Sensor.Size = New System.Drawing.Size(61, 13)
        Me.lbl_Sensor.TabIndex = 13
        Me.lbl_Sensor.Text = "ชื่ออุปกรณ์ :"
        Me.lbl_Sensor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Text_Zone
        '
        Me.lbl_Text_Zone.AutoSize = True
        Me.lbl_Text_Zone.Location = New System.Drawing.Point(38, 190)
        Me.lbl_Text_Zone.Name = "lbl_Text_Zone"
        Me.lbl_Text_Zone.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Text_Zone.TabIndex = 12
        Me.lbl_Text_Zone.Text = "ชื่อโซน :"
        Me.lbl_Text_Zone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Floor
        '
        Me.lbl_Floor.AutoSize = True
        Me.lbl_Floor.Location = New System.Drawing.Point(6, 78)
        Me.lbl_Floor.Name = "lbl_Floor"
        Me.lbl_Floor.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Floor.TabIndex = 11
        Me.lbl_Floor.Text = "ชั้น :"
        Me.lbl_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Zone_Name
        '
        Me.lbl_Zone_Name.BackColor = System.Drawing.Color.Black
        Me.lbl_Zone_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Zone_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Zone_Name.ForeColor = System.Drawing.Color.Red
        Me.lbl_Zone_Name.Location = New System.Drawing.Point(84, 180)
        Me.lbl_Zone_Name.Name = "lbl_Zone_Name"
        Me.lbl_Zone_Name.Size = New System.Drawing.Size(134, 33)
        Me.lbl_Zone_Name.TabIndex = 9
        Me.lbl_Zone_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb_Floor
        '
        Me.cmb_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floor.Enabled = False
        Me.cmb_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Floor.FormattingEnabled = True
        Me.cmb_Floor.Location = New System.Drawing.Point(37, 72)
        Me.cmb_Floor.Name = "cmb_Floor"
        Me.cmb_Floor.Size = New System.Drawing.Size(187, 24)
        Me.cmb_Floor.TabIndex = 0
        '
        'lbl_Lot_Name
        '
        Me.lbl_Lot_Name.BackColor = System.Drawing.Color.Black
        Me.lbl_Lot_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Lot_Name.ForeColor = System.Drawing.Color.Red
        Me.lbl_Lot_Name.Location = New System.Drawing.Point(84, 246)
        Me.lbl_Lot_Name.Name = "lbl_Lot_Name"
        Me.lbl_Lot_Name.Size = New System.Drawing.Size(134, 33)
        Me.lbl_Lot_Name.TabIndex = 10
        Me.lbl_Lot_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(955, 431)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 150)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "วิธีการทำงาน" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1.เลือกสถานที่" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2.เลือกอาคารจอดรถ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. เลือกชั้นจอดรถ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. คลิกโซนท" & _
    "ี่ต้องการตั้งต่า" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5. คลิกเลือกอุปกรณ์ที่ต้องการตั้งค่า" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6. บันทึก" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7. ถ้าไม่เปลี" & _
    "่ยนโซนให้ทำขั้นตอนที่ 3 และ 4"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBarX1
        '
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.Class = ""
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.Location = New System.Drawing.Point(32, 364)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(889, 25)
        Me.ProgressBarX1.TabIndex = 72
        Me.ProgressBarX1.Text = "ProgressBarX1"
        Me.ProgressBarX1.Visible = False
        '
        'frm_Setting_Lot_to_Display
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 695)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.Controls.Add(Me.Picture_Floor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Name = "frm_Setting_Lot_to_Display"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ตั้งค่าโซนอุปกรณ์ตรวจสอบ เพื่อแสดงผลที่ป้าย"
        CType(Me.Picture_Floor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chk_Save_Auto As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Picture_Floor As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Lot_ID As System.Windows.Forms.Label
    Friend WithEvents cmb_Building As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_Tower As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Sensor As System.Windows.Forms.Label
    Friend WithEvents lbl_Text_Zone As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor As System.Windows.Forms.Label
    Friend WithEvents lbl_Zone_Name As System.Windows.Forms.Label
    Friend WithEvents cmb_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Lot_Name As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Export_Zone As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Count As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_Zone As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Zone As System.Windows.Forms.CheckBox
    Friend WithEvents chk_All_Floor As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
