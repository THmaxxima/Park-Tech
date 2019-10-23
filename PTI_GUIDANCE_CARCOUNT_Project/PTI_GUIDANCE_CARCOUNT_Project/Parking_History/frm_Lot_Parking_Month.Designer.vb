<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Lot_Parking_Month
    Inherits DevComponents.DotNetBar.Office2007Form  ' Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Lot_Parking_Month))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerRealtime = New System.Windows.Forms.Timer(Me.components)
        Me.img_Close = New System.Windows.Forms.ImageList(Me.components)
        Me.T_Refesh_Status = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.rdo_Time = New System.Windows.Forms.RadioButton()
        Me.rdo_Many = New System.Windows.Forms.RadioButton()
        Me.DgvDetail = New System.Windows.Forms.DataGridView()
        Me.lbl_Color_Step1 = New System.Windows.Forms.Label()
        Me.lbl_Color_Step2 = New System.Windows.Forms.Label()
        Me.lbl_Color_Step3 = New System.Windows.Forms.Label()
        Me.lbl_Color_Step4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdo_Day = New System.Windows.Forms.RadioButton()
        Me.Rdo_Month = New System.Windows.Forms.RadioButton()
        Me.Cmb_Day = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_Years = New System.Windows.Forms.ComboBox()
        Me.cmb_Month = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsv_Mas_Alam = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgv_Time = New System.Windows.Forms.DataGridView()
        Me.Tab_Building = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Tab_ParkingA = New System.Windows.Forms.TabControl()
        Me.ID_1 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_1 = New System.Windows.Forms.PictureBox()
        Me.ID_2 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_2 = New System.Windows.Forms.PictureBox()
        Me.ID_3 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_3 = New System.Windows.Forms.PictureBox()
        Me.ID_4 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_4 = New System.Windows.Forms.PictureBox()
        Me.ID_5 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_5 = New System.Windows.Forms.PictureBox()
        Me.ID_6 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_6 = New System.Windows.Forms.PictureBox()
        Me.Building_A = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Tab_ParkingD = New System.Windows.Forms.TabControl()
        Me.ID_7 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_7 = New System.Windows.Forms.PictureBox()
        Me.ID_8 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_8 = New System.Windows.Forms.PictureBox()
        Me.ID_9 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_9 = New System.Windows.Forms.PictureBox()
        Me.ID_10 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_10 = New System.Windows.Forms.PictureBox()
        Me.ID_11 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_11 = New System.Windows.Forms.PictureBox()
        Me.ID_12 = New System.Windows.Forms.TabPage()
        Me.Pic_ID_12 = New System.Windows.Forms.PictureBox()
        Me.Building_D = New DevComponents.DotNetBar.SuperTabItem()
        Me.btn_Capture_Screen = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_Report = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.lbl_Max_Parking = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_Time, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab_Building, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Building.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.Tab_ParkingA.SuspendLayout()
        Me.ID_1.SuspendLayout()
        CType(Me.Pic_ID_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_2.SuspendLayout()
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_3.SuspendLayout()
        CType(Me.Pic_ID_3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_4.SuspendLayout()
        CType(Me.Pic_ID_4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_5.SuspendLayout()
        CType(Me.Pic_ID_5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_6.SuspendLayout()
        CType(Me.Pic_ID_6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.Tab_ParkingD.SuspendLayout()
        Me.ID_7.SuspendLayout()
        CType(Me.Pic_ID_7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_8.SuspendLayout()
        CType(Me.Pic_ID_8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_9.SuspendLayout()
        CType(Me.Pic_ID_9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_10.SuspendLayout()
        CType(Me.Pic_ID_10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_11.SuspendLayout()
        CType(Me.Pic_ID_11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ID_12.SuspendLayout()
        CType(Me.Pic_ID_12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Blank Badge Green.ico")
        Me.ImageList1.Images.SetKeyName(1, "Blank Disc Red.ico")
        '
        'TimerRealtime
        '
        Me.TimerRealtime.Enabled = True
        Me.TimerRealtime.Interval = 5000
        '
        'img_Close
        '
        Me.img_Close.ImageStream = CType(resources.GetObject("img_Close.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Close.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Close.Images.SetKeyName(0, "")
        '
        'T_Refesh_Status
        '
        Me.T_Refesh_Status.Enabled = True
        Me.T_Refesh_Status.Interval = 5000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Search)
        Me.GroupBox2.Controls.Add(Me.rdo_Time)
        Me.GroupBox2.Controls.Add(Me.rdo_Many)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(980, 358)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(237, 76)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ประเภทข้อมูล"
        '
        'btn_Search
        '
        Me.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Search.ForeColor = System.Drawing.Color.Blue
        Me.btn_Search.Location = New System.Drawing.Point(162, 14)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(70, 53)
        Me.btn_Search.TabIndex = 4
        Me.btn_Search.Text = "ค้นหา"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'rdo_Time
        '
        Me.rdo_Time.AutoSize = True
        Me.rdo_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Time.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdo_Time.Location = New System.Drawing.Point(11, 48)
        Me.rdo_Time.Name = "rdo_Time"
        Me.rdo_Time.Size = New System.Drawing.Size(138, 22)
        Me.rdo_Time.TabIndex = 15
        Me.rdo_Time.Text = "ระยะเวลาในการจอด"
        Me.rdo_Time.UseVisualStyleBackColor = True
        '
        'rdo_Many
        '
        Me.rdo_Many.AutoSize = True
        Me.rdo_Many.Checked = True
        Me.rdo_Many.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Many.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdo_Many.Location = New System.Drawing.Point(12, 19)
        Me.rdo_Many.Name = "rdo_Many"
        Me.rdo_Many.Size = New System.Drawing.Size(144, 22)
        Me.rdo_Many.TabIndex = 14
        Me.rdo_Many.TabStop = True
        Me.rdo_Many.Text = "จำนวนครั้งในการจอด"
        Me.rdo_Many.UseVisualStyleBackColor = True
        '
        'DgvDetail
        '
        Me.DgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetail.Location = New System.Drawing.Point(1107, 518)
        Me.DgvDetail.Name = "DgvDetail"
        Me.DgvDetail.Size = New System.Drawing.Size(124, 82)
        Me.DgvDetail.TabIndex = 188
        Me.DgvDetail.Visible = False
        '
        'lbl_Color_Step1
        '
        Me.lbl_Color_Step1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Color_Step1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Step1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Color_Step1.ForeColor = System.Drawing.Color.Navy
        Me.lbl_Color_Step1.Location = New System.Drawing.Point(97, 16)
        Me.lbl_Color_Step1.Name = "lbl_Color_Step1"
        Me.lbl_Color_Step1.Size = New System.Drawing.Size(133, 26)
        Me.lbl_Color_Step1.TabIndex = 192
        Me.lbl_Color_Step1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Step2
        '
        Me.lbl_Color_Step2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Color_Step2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Step2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Color_Step2.ForeColor = System.Drawing.Color.Navy
        Me.lbl_Color_Step2.Location = New System.Drawing.Point(97, 42)
        Me.lbl_Color_Step2.Name = "lbl_Color_Step2"
        Me.lbl_Color_Step2.Size = New System.Drawing.Size(133, 26)
        Me.lbl_Color_Step2.TabIndex = 193
        Me.lbl_Color_Step2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Step3
        '
        Me.lbl_Color_Step3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Color_Step3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Step3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Color_Step3.ForeColor = System.Drawing.Color.Navy
        Me.lbl_Color_Step3.Location = New System.Drawing.Point(97, 68)
        Me.lbl_Color_Step3.Name = "lbl_Color_Step3"
        Me.lbl_Color_Step3.Size = New System.Drawing.Size(133, 26)
        Me.lbl_Color_Step3.TabIndex = 194
        Me.lbl_Color_Step3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Step4
        '
        Me.lbl_Color_Step4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Color_Step4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Step4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Color_Step4.ForeColor = System.Drawing.Color.Navy
        Me.lbl_Color_Step4.Location = New System.Drawing.Point(97, 94)
        Me.lbl_Color_Step4.Name = "lbl_Color_Step4"
        Me.lbl_Color_Step4.Size = New System.Drawing.Size(133, 26)
        Me.lbl_Color_Step4.TabIndex = 195
        Me.lbl_Color_Step4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(1, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 198
        Me.Label10.Text = "จอดเฉลี่ย ช่วงที่ 1 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(1, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 199
        Me.Label11.Text = "จอดเฉลี่ย ช่วงที่ 2 :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(1, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 16)
        Me.Label12.TabIndex = 200
        Me.Label12.Text = "จอดเฉลี่ย ช่วงที่ 3 :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(1, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 16)
        Me.Label13.TabIndex = 201
        Me.Label13.Text = "จอดเฉลี่ย ช่วงที่ 4 :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_Color_Step2)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.lbl_Color_Step1)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.lbl_Color_Step3)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.lbl_Color_Step4)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(980, 50)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(237, 131)
        Me.GroupBox4.TabIndex = 202
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "สีมาตรฐาน"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdo_Day)
        Me.GroupBox5.Controls.Add(Me.Rdo_Month)
        Me.GroupBox5.Controls.Add(Me.Cmb_Day)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.cmb_Years)
        Me.GroupBox5.Controls.Add(Me.cmb_Month)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(980, 187)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(237, 165)
        Me.GroupBox5.TabIndex = 203
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "เงื่อนไข"
        '
        'rdo_Day
        '
        Me.rdo_Day.AutoSize = True
        Me.rdo_Day.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Day.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdo_Day.Location = New System.Drawing.Point(65, 38)
        Me.rdo_Day.Name = "rdo_Day"
        Me.rdo_Day.Size = New System.Drawing.Size(102, 22)
        Me.rdo_Day.TabIndex = 13
        Me.rdo_Day.Text = "สรุปผลรายวัน"
        Me.rdo_Day.UseVisualStyleBackColor = True
        '
        'Rdo_Month
        '
        Me.Rdo_Month.AutoSize = True
        Me.Rdo_Month.Checked = True
        Me.Rdo_Month.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Rdo_Month.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Rdo_Month.Location = New System.Drawing.Point(65, 16)
        Me.Rdo_Month.Name = "Rdo_Month"
        Me.Rdo_Month.Size = New System.Drawing.Size(115, 22)
        Me.Rdo_Month.TabIndex = 14
        Me.Rdo_Month.TabStop = True
        Me.Rdo_Month.Text = "สรุปผลรายเดือน"
        Me.Rdo_Month.UseVisualStyleBackColor = True
        '
        'Cmb_Day
        '
        Me.Cmb_Day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Day.Enabled = False
        Me.Cmb_Day.FormattingEnabled = True
        Me.Cmb_Day.Items.AddRange(New Object() {"เลือกวันที่", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.Cmb_Day.Location = New System.Drawing.Point(62, 69)
        Me.Cmb_Day.Name = "Cmb_Day"
        Me.Cmb_Day.Size = New System.Drawing.Size(133, 24)
        Me.Cmb_Day.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "วันที่ :"
        '
        'cmb_Years
        '
        Me.cmb_Years.FormattingEnabled = True
        Me.cmb_Years.Items.AddRange(New Object() {"เลือกปี", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"})
        Me.cmb_Years.Location = New System.Drawing.Point(62, 127)
        Me.cmb_Years.Name = "cmb_Years"
        Me.cmb_Years.Size = New System.Drawing.Size(133, 24)
        Me.cmb_Years.TabIndex = 10
        '
        'cmb_Month
        '
        Me.cmb_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Month.FormattingEnabled = True
        Me.cmb_Month.Items.AddRange(New Object() {"เลือกเดือน", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cmb_Month.Location = New System.Drawing.Point(62, 98)
        Me.cmb_Month.Name = "cmb_Month"
        Me.cmb_Month.Size = New System.Drawing.Size(133, 24)
        Me.cmb_Month.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ปี :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "เดือน :"
        '
        'lsv_Mas_Alam
        '
        Me.lsv_Mas_Alam.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lsv_Mas_Alam.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lsv_Mas_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Mas_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lsv_Mas_Alam.FullRowSelect = True
        Me.lsv_Mas_Alam.GridLines = True
        Me.lsv_Mas_Alam.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Mas_Alam.HideSelection = False
        Me.lsv_Mas_Alam.Location = New System.Drawing.Point(1282, 106)
        Me.lsv_Mas_Alam.Name = "lsv_Mas_Alam"
        Me.lsv_Mas_Alam.Size = New System.Drawing.Size(76, 202)
        Me.lsv_Mas_Alam.TabIndex = 204
        Me.lsv_Mas_Alam.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_Alam.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "รหัส"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                 รายละเอียด"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = ""
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "0"
        Me.ColumnHeader6.Width = 0
        '
        'dgv_Time
        '
        Me.dgv_Time.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Time.Location = New System.Drawing.Point(1107, 606)
        Me.dgv_Time.Name = "dgv_Time"
        Me.dgv_Time.Size = New System.Drawing.Size(124, 82)
        Me.dgv_Time.TabIndex = 207
        '
        'Tab_Building
        '
        Me.Tab_Building.BackColor = System.Drawing.Color.WhiteSmoke
        '
        '
        '
        '
        '
        '
        Me.Tab_Building.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.Tab_Building.ControlBox.MenuBox.Name = ""
        Me.Tab_Building.ControlBox.Name = ""
        Me.Tab_Building.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Tab_Building.ControlBox.MenuBox, Me.Tab_Building.ControlBox.CloseBox})
        Me.Tab_Building.Controls.Add(Me.SuperTabControlPanel1)
        Me.Tab_Building.Controls.Add(Me.SuperTabControlPanel2)
        Me.Tab_Building.Location = New System.Drawing.Point(12, 12)
        Me.Tab_Building.Name = "Tab_Building"
        Me.Tab_Building.ReorderTabsEnabled = True
        Me.Tab_Building.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tab_Building.SelectedTabIndex = 1
        Me.Tab_Building.Size = New System.Drawing.Size(962, 754)
        Me.Tab_Building.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tab_Building.TabIndex = 208
        Me.Tab_Building.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Building_A, Me.Building_D})
        Me.Tab_Building.Tag = "1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Tab_ParkingA)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 31)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(962, 723)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.Building_A
        '
        'Tab_ParkingA
        '
        Me.Tab_ParkingA.Controls.Add(Me.ID_1)
        Me.Tab_ParkingA.Controls.Add(Me.ID_2)
        Me.Tab_ParkingA.Controls.Add(Me.ID_3)
        Me.Tab_ParkingA.Controls.Add(Me.ID_4)
        Me.Tab_ParkingA.Controls.Add(Me.ID_5)
        Me.Tab_ParkingA.Controls.Add(Me.ID_6)
        Me.Tab_ParkingA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab_ParkingA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tab_ParkingA.Location = New System.Drawing.Point(4, 4)
        Me.Tab_ParkingA.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tab_ParkingA.Name = "Tab_ParkingA"
        Me.Tab_ParkingA.SelectedIndex = 0
        Me.Tab_ParkingA.Size = New System.Drawing.Size(954, 715)
        Me.Tab_ParkingA.TabIndex = 57
        Me.Tab_ParkingA.TabStop = False
        Me.Tab_ParkingA.Tag = ""
        '
        'ID_1
        '
        Me.ID_1.Controls.Add(Me.Pic_ID_1)
        Me.ID_1.Location = New System.Drawing.Point(4, 29)
        Me.ID_1.Name = "ID_1"
        Me.ID_1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_1.Size = New System.Drawing.Size(946, 682)
        Me.ID_1.TabIndex = 0
        Me.ID_1.Text = "1"
        Me.ID_1.UseVisualStyleBackColor = True
        '
        'Pic_ID_1
        '
        Me.Pic_ID_1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Pic_ID_1.Location = New System.Drawing.Point(3, 5)
        Me.Pic_ID_1.Name = "Pic_ID_1"
        Me.Pic_ID_1.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_1.TabIndex = 0
        Me.Pic_ID_1.TabStop = False
        '
        'ID_2
        '
        Me.ID_2.Controls.Add(Me.Pic_ID_2)
        Me.ID_2.Location = New System.Drawing.Point(4, 29)
        Me.ID_2.Name = "ID_2"
        Me.ID_2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_2.Size = New System.Drawing.Size(946, 682)
        Me.ID_2.TabIndex = 1
        Me.ID_2.Text = "2"
        Me.ID_2.UseVisualStyleBackColor = True
        '
        'Pic_ID_2
        '
        Me.Pic_ID_2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_2.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_2.Name = "Pic_ID_2"
        Me.Pic_ID_2.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_2.TabIndex = 1
        Me.Pic_ID_2.TabStop = False
        '
        'ID_3
        '
        Me.ID_3.Controls.Add(Me.Pic_ID_3)
        Me.ID_3.Location = New System.Drawing.Point(4, 29)
        Me.ID_3.Name = "ID_3"
        Me.ID_3.Size = New System.Drawing.Size(946, 682)
        Me.ID_3.TabIndex = 2
        Me.ID_3.Text = "3"
        Me.ID_3.UseVisualStyleBackColor = True
        '
        'Pic_ID_3
        '
        Me.Pic_ID_3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_3.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_3.Name = "Pic_ID_3"
        Me.Pic_ID_3.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_3.TabIndex = 1
        Me.Pic_ID_3.TabStop = False
        '
        'ID_4
        '
        Me.ID_4.Controls.Add(Me.Pic_ID_4)
        Me.ID_4.Location = New System.Drawing.Point(4, 29)
        Me.ID_4.Name = "ID_4"
        Me.ID_4.Size = New System.Drawing.Size(946, 682)
        Me.ID_4.TabIndex = 3
        Me.ID_4.Text = "4"
        Me.ID_4.UseVisualStyleBackColor = True
        '
        'Pic_ID_4
        '
        Me.Pic_ID_4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_4.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_4.Name = "Pic_ID_4"
        Me.Pic_ID_4.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_4.TabIndex = 1
        Me.Pic_ID_4.TabStop = False
        '
        'ID_5
        '
        Me.ID_5.Controls.Add(Me.Pic_ID_5)
        Me.ID_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ID_5.Location = New System.Drawing.Point(4, 29)
        Me.ID_5.Name = "ID_5"
        Me.ID_5.Size = New System.Drawing.Size(946, 682)
        Me.ID_5.TabIndex = 4
        Me.ID_5.Text = "5"
        Me.ID_5.UseVisualStyleBackColor = True
        '
        'Pic_ID_5
        '
        Me.Pic_ID_5.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_5.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_5.Name = "Pic_ID_5"
        Me.Pic_ID_5.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_5.TabIndex = 1
        Me.Pic_ID_5.TabStop = False
        '
        'ID_6
        '
        Me.ID_6.Controls.Add(Me.Pic_ID_6)
        Me.ID_6.Location = New System.Drawing.Point(4, 29)
        Me.ID_6.Name = "ID_6"
        Me.ID_6.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_6.Size = New System.Drawing.Size(946, 682)
        Me.ID_6.TabIndex = 5
        Me.ID_6.Text = "6"
        Me.ID_6.UseVisualStyleBackColor = True
        '
        'Pic_ID_6
        '
        Me.Pic_ID_6.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_6.Location = New System.Drawing.Point(3, 6)
        Me.Pic_ID_6.Name = "Pic_ID_6"
        Me.Pic_ID_6.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_6.TabIndex = 2
        Me.Pic_ID_6.TabStop = False
        '
        'Building_A
        '
        Me.Building_A.AttachedControl = Me.SuperTabControlPanel1
        Me.Building_A.GlobalItem = False
        Me.Building_A.Name = "Building_A"
        Me.Building_A.Tag = "1"
        Me.Building_A.Text = "Parking A"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Tab_ParkingD)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(962, 754)
        Me.SuperTabControlPanel2.TabIndex = 2
        Me.SuperTabControlPanel2.TabItem = Me.Building_D
        '
        'Tab_ParkingD
        '
        Me.Tab_ParkingD.Controls.Add(Me.ID_7)
        Me.Tab_ParkingD.Controls.Add(Me.ID_8)
        Me.Tab_ParkingD.Controls.Add(Me.ID_9)
        Me.Tab_ParkingD.Controls.Add(Me.ID_10)
        Me.Tab_ParkingD.Controls.Add(Me.ID_11)
        Me.Tab_ParkingD.Controls.Add(Me.ID_12)
        Me.Tab_ParkingD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab_ParkingD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tab_ParkingD.Location = New System.Drawing.Point(4, 4)
        Me.Tab_ParkingD.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tab_ParkingD.Name = "Tab_ParkingD"
        Me.Tab_ParkingD.SelectedIndex = 0
        Me.Tab_ParkingD.Size = New System.Drawing.Size(957, 715)
        Me.Tab_ParkingD.TabIndex = 57
        Me.Tab_ParkingD.TabStop = False
        '
        'ID_7
        '
        Me.ID_7.Controls.Add(Me.Pic_ID_7)
        Me.ID_7.Location = New System.Drawing.Point(4, 29)
        Me.ID_7.Name = "ID_7"
        Me.ID_7.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_7.Size = New System.Drawing.Size(949, 682)
        Me.ID_7.TabIndex = 0
        Me.ID_7.Text = "7"
        Me.ID_7.UseVisualStyleBackColor = True
        '
        'Pic_ID_7
        '
        Me.Pic_ID_7.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_7.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Pic_ID_7.Location = New System.Drawing.Point(3, 5)
        Me.Pic_ID_7.Name = "Pic_ID_7"
        Me.Pic_ID_7.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_7.TabIndex = 0
        Me.Pic_ID_7.TabStop = False
        '
        'ID_8
        '
        Me.ID_8.Controls.Add(Me.Pic_ID_8)
        Me.ID_8.Location = New System.Drawing.Point(4, 29)
        Me.ID_8.Name = "ID_8"
        Me.ID_8.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_8.Size = New System.Drawing.Size(949, 682)
        Me.ID_8.TabIndex = 1
        Me.ID_8.Text = "8"
        Me.ID_8.UseVisualStyleBackColor = True
        '
        'Pic_ID_8
        '
        Me.Pic_ID_8.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_8.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_8.Name = "Pic_ID_8"
        Me.Pic_ID_8.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_8.TabIndex = 1
        Me.Pic_ID_8.TabStop = False
        '
        'ID_9
        '
        Me.ID_9.Controls.Add(Me.Pic_ID_9)
        Me.ID_9.Location = New System.Drawing.Point(4, 29)
        Me.ID_9.Name = "ID_9"
        Me.ID_9.Size = New System.Drawing.Size(949, 682)
        Me.ID_9.TabIndex = 2
        Me.ID_9.Text = "9"
        Me.ID_9.UseVisualStyleBackColor = True
        '
        'Pic_ID_9
        '
        Me.Pic_ID_9.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_9.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_9.Name = "Pic_ID_9"
        Me.Pic_ID_9.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_9.TabIndex = 1
        Me.Pic_ID_9.TabStop = False
        '
        'ID_10
        '
        Me.ID_10.Controls.Add(Me.Pic_ID_10)
        Me.ID_10.Location = New System.Drawing.Point(4, 29)
        Me.ID_10.Name = "ID_10"
        Me.ID_10.Size = New System.Drawing.Size(949, 682)
        Me.ID_10.TabIndex = 3
        Me.ID_10.Text = "10"
        Me.ID_10.UseVisualStyleBackColor = True
        '
        'Pic_ID_10
        '
        Me.Pic_ID_10.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_10.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_10.Name = "Pic_ID_10"
        Me.Pic_ID_10.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_10.TabIndex = 1
        Me.Pic_ID_10.TabStop = False
        '
        'ID_11
        '
        Me.ID_11.Controls.Add(Me.Pic_ID_11)
        Me.ID_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ID_11.Location = New System.Drawing.Point(4, 29)
        Me.ID_11.Name = "ID_11"
        Me.ID_11.Size = New System.Drawing.Size(949, 682)
        Me.ID_11.TabIndex = 4
        Me.ID_11.Text = "11"
        Me.ID_11.UseVisualStyleBackColor = True
        '
        'Pic_ID_11
        '
        Me.Pic_ID_11.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_11.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_11.Name = "Pic_ID_11"
        Me.Pic_ID_11.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_11.TabIndex = 1
        Me.Pic_ID_11.TabStop = False
        '
        'ID_12
        '
        Me.ID_12.Controls.Add(Me.Pic_ID_12)
        Me.ID_12.Location = New System.Drawing.Point(4, 29)
        Me.ID_12.Name = "ID_12"
        Me.ID_12.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_12.Size = New System.Drawing.Size(949, 682)
        Me.ID_12.TabIndex = 5
        Me.ID_12.Text = "12"
        Me.ID_12.UseVisualStyleBackColor = True
        '
        'Pic_ID_12
        '
        Me.Pic_ID_12.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_12.Location = New System.Drawing.Point(4, 4)
        Me.Pic_ID_12.Name = "Pic_ID_12"
        Me.Pic_ID_12.Size = New System.Drawing.Size(940, 675)
        Me.Pic_ID_12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_12.TabIndex = 2
        Me.Pic_ID_12.TabStop = False
        '
        'Building_D
        '
        Me.Building_D.AttachedControl = Me.SuperTabControlPanel2
        Me.Building_D.GlobalItem = False
        Me.Building_D.Name = "Building_D"
        Me.Building_D.Tag = "2"
        Me.Building_D.Text = "Parking D"
        '
        'btn_Capture_Screen
        '
        Me.btn_Capture_Screen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Capture_Screen.Location = New System.Drawing.Point(1010, 448)
        Me.btn_Capture_Screen.Name = "btn_Capture_Screen"
        Me.btn_Capture_Screen.Size = New System.Drawing.Size(96, 64)
        Me.btn_Capture_Screen.TabIndex = 209
        Me.btn_Capture_Screen.Text = "บันทึกรูปภาพ"
        Me.btn_Capture_Screen.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(980, 518)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(237, 248)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 210
        Me.PictureBox1.TabStop = False
        '
        'btn_Report
        '
        Me.btn_Report.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Report.Location = New System.Drawing.Point(1112, 448)
        Me.btn_Report.Name = "btn_Report"
        Me.btn_Report.Size = New System.Drawing.Size(96, 64)
        Me.btn_Report.TabIndex = 211
        Me.btn_Report.Text = "พิมพ์รายงาน"
        Me.btn_Report.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        '
        '
        '
        Me.ProgressBar1.BackgroundStyle.Class = ""
        Me.ProgressBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBar1.Location = New System.Drawing.Point(194, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1023, 28)
        Me.ProgressBar1.TabIndex = 212
        Me.ProgressBar1.Text = "ProgressBarX1"
        '
        'lbl_Max_Parking
        '
        Me.lbl_Max_Parking.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Max_Parking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Max_Parking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Max_Parking.ForeColor = System.Drawing.Color.Navy
        Me.lbl_Max_Parking.Location = New System.Drawing.Point(980, 769)
        Me.lbl_Max_Parking.Name = "lbl_Max_Parking"
        Me.lbl_Max_Parking.Size = New System.Drawing.Size(133, 26)
        Me.lbl_Max_Parking.TabIndex = 213
        Me.lbl_Max_Parking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Max_Parking.Visible = False
        '
        'frm_Lot_Parking_Month
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 609)
        Me.Controls.Add(Me.lbl_Max_Parking)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btn_Report)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_Capture_Screen)
        Me.Controls.Add(Me.Tab_Building)
        Me.Controls.Add(Me.dgv_Time)
        Me.Controls.Add(Me.lsv_Mas_Alam)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.DgvDetail)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Lot_Parking_Month"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Lot_Parking_Month"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgv_Time, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab_Building, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Building.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.Tab_ParkingA.ResumeLayout(False)
        Me.ID_1.ResumeLayout(False)
        CType(Me.Pic_ID_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_2.ResumeLayout(False)
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_3.ResumeLayout(False)
        CType(Me.Pic_ID_3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_4.ResumeLayout(False)
        CType(Me.Pic_ID_4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_5.ResumeLayout(False)
        CType(Me.Pic_ID_5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_6.ResumeLayout(False)
        CType(Me.Pic_ID_6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.Tab_ParkingD.ResumeLayout(False)
        Me.ID_7.ResumeLayout(False)
        CType(Me.Pic_ID_7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_8.ResumeLayout(False)
        CType(Me.Pic_ID_8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_9.ResumeLayout(False)
        CType(Me.Pic_ID_9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_10.ResumeLayout(False)
        CType(Me.Pic_ID_10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_11.ResumeLayout(False)
        CType(Me.Pic_ID_11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ID_12.ResumeLayout(False)
        CType(Me.Pic_ID_12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TimerRealtime As System.Windows.Forms.Timer
    Friend WithEvents img_Close As System.Windows.Forms.ImageList
    Friend WithEvents T_Refesh_Status As System.Windows.Forms.Timer
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents DgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Color_Step1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Step2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Step3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Step4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_Time As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_Many As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_Day As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_Month As System.Windows.Forms.RadioButton
    Friend WithEvents Cmb_Day As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_Years As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Month As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsv_Mas_Alam As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgv_Time As System.Windows.Forms.DataGridView
    Friend WithEvents Tab_Building As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_ParkingA As System.Windows.Forms.TabControl
    Friend WithEvents ID_1 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_1 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_2 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_2 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_3 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_3 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_4 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_4 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_5 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_5 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_6 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_6 As System.Windows.Forms.PictureBox
    Friend WithEvents Building_A As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Tab_ParkingD As System.Windows.Forms.TabControl
    Friend WithEvents ID_7 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_7 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_8 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_8 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_9 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_9 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_10 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_10 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_11 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_11 As System.Windows.Forms.PictureBox
    Friend WithEvents ID_12 As System.Windows.Forms.TabPage
    Friend WithEvents Pic_ID_12 As System.Windows.Forms.PictureBox
    Friend WithEvents Building_D As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents btn_Capture_Screen As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Report As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents lbl_Max_Parking As System.Windows.Forms.Label
End Class
