<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Hostory_Display
    Inherits DevComponents.DotNetBar.Office2007Form  '  Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Hostory_Display))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerRealtime = New System.Windows.Forms.Timer(Me.components)
        Me.img_Close = New System.Windows.Forms.ImageList(Me.components)
        Me.T_Refesh_Status = New System.Windows.Forms.Timer(Me.components)
        Me.DTPickerSt = New System.Windows.Forms.DateTimePicker()
        Me.TimeIn = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimeOut = New System.Windows.Forms.DateTimePicker()
        Me.DTPickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_Status_10 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status10 = New System.Windows.Forms.Label()
        Me.lbl_Status_9 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status9 = New System.Windows.Forms.Label()
        Me.lbl_Status_8 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status8 = New System.Windows.Forms.Label()
        Me.lbl_Status_7 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status7 = New System.Windows.Forms.Label()
        Me.lbl_Status_4 = New System.Windows.Forms.Label()
        Me.lbl_Status_5 = New System.Windows.Forms.Label()
        Me.lbl_Status_6 = New System.Windows.Forms.Label()
        Me.lbl_Status_3 = New System.Windows.Forms.Label()
        Me.lbl_Status_2 = New System.Windows.Forms.Label()
        Me.lbl_Status_1 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status6 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status1 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status2 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status3 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status4 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status5 = New System.Windows.Forms.Label()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lbl_Parking_All = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_In_Floor = New System.Windows.Forms.Label()
        Me.lbl_Green = New System.Windows.Forms.Label()
        Me.lbl_Red = New System.Windows.Forms.Label()
        Me.lbl_Parking = New System.Windows.Forms.Label()
        Me.lbl_Percent_Parking_IN_Floor = New System.Windows.Forms.Label()
        Me.lbl_Lot_Empty = New System.Windows.Forms.Label()
        Me.lbl_Show_ID = New System.Windows.Forms.Label()
        Me.lbl_Parking_In_Floor = New System.Windows.Forms.Label()
        Me.lbl_Empty = New System.Windows.Forms.Label()
        Me.Tab_Building = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Tab_ParkingA = New System.Windows.Forms.TabControl()
        Me.ID_1 = New System.Windows.Forms.TabPage()
        Me.DgvDetail = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
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
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.grb_Status_Floor = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lbl_Percent_Remain_Floor_7 = New System.Windows.Forms.Label()
        Me.lbl_Floor_7 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_7 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_Floor_6 = New System.Windows.Forms.Label()
        Me.lbl_Floor_6 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_6 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_Floor_5 = New System.Windows.Forms.Label()
        Me.lbl_Floor_5 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_5 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_5 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_Floor_4 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_Floor_3 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_Floor_2 = New System.Windows.Forms.Label()
        Me.lbl_Percent_Remain_Floor_1 = New System.Windows.Forms.Label()
        Me.lbl_Floor_4 = New System.Windows.Forms.Label()
        Me.lbl_Floor_3 = New System.Windows.Forms.Label()
        Me.lbl_Floor_2 = New System.Windows.Forms.Label()
        Me.lbl_Floor_1 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_4 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_4 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_3 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_3 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_2 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_2 = New System.Windows.Forms.Label()
        Me.lbl_Bar_IN_Floor_1 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lbl_Percent_IN_Floor_1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbl_Max_Parking = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Tab_Building, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_Building.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.Tab_ParkingA.SuspendLayout()
        Me.ID_1.SuspendLayout()
        CType(Me.DgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grb_Status_Floor.SuspendLayout()
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
        'DTPickerSt
        '
        Me.DTPickerSt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerSt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerSt.Location = New System.Drawing.Point(76, 75)
        Me.DTPickerSt.Name = "DTPickerSt"
        Me.DTPickerSt.Size = New System.Drawing.Size(166, 22)
        Me.DTPickerSt.TabIndex = 175
        '
        'TimeIn
        '
        Me.TimeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeIn.Location = New System.Drawing.Point(150, 75)
        Me.TimeIn.Name = "TimeIn"
        Me.TimeIn.Size = New System.Drawing.Size(71, 22)
        Me.TimeIn.TabIndex = 176
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(9, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "ระหว่างวันที่"
        '
        'btn_Search
        '
        Me.btn_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Search.ForeColor = System.Drawing.Color.Blue
        Me.btn_Search.Location = New System.Drawing.Point(242, 74)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(48, 51)
        Me.btn_Search.TabIndex = 178
        Me.btn_Search.Text = "..."
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(34, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "ถึงวันที่"
        '
        'TimeOut
        '
        Me.TimeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimeOut.Location = New System.Drawing.Point(150, 101)
        Me.TimeOut.Name = "TimeOut"
        Me.TimeOut.Size = New System.Drawing.Size(71, 22)
        Me.TimeOut.TabIndex = 181
        '
        'DTPickerEnd
        '
        Me.DTPickerEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerEnd.Location = New System.Drawing.Point(76, 101)
        Me.DTPickerEnd.Name = "DTPickerEnd"
        Me.DTPickerEnd.Size = New System.Drawing.Size(166, 22)
        Me.DTPickerEnd.TabIndex = 180
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.lbl_Status_10)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status10)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_9)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status9)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_8)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status8)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_7)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status7)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_4)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_5)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_6)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_3)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_2)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_1)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status6)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status1)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status2)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status3)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status4)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status5)
        Me.GroupBox3.Location = New System.Drawing.Point(979, 51)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 262)
        Me.GroupBox3.TabIndex = 183
        Me.GroupBox3.TabStop = False
        '
        'lbl_Status_10
        '
        Me.lbl_Status_10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_10.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_10.Location = New System.Drawing.Point(27, 229)
        Me.lbl_Status_10.Name = "lbl_Status_10"
        Me.lbl_Status_10.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_10.TabIndex = 109
        Me.lbl_Status_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status10
        '
        Me.lbl_Color_Status10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status10.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status10.Location = New System.Drawing.Point(8, 232)
        Me.lbl_Color_Status10.Name = "lbl_Color_Status10"
        Me.lbl_Color_Status10.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status10.TabIndex = 108
        Me.lbl_Color_Status10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_9
        '
        Me.lbl_Status_9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_9.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_9.Location = New System.Drawing.Point(27, 206)
        Me.lbl_Status_9.Name = "lbl_Status_9"
        Me.lbl_Status_9.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_9.TabIndex = 107
        Me.lbl_Status_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status9
        '
        Me.lbl_Color_Status9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status9.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status9.Location = New System.Drawing.Point(8, 209)
        Me.lbl_Color_Status9.Name = "lbl_Color_Status9"
        Me.lbl_Color_Status9.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status9.TabIndex = 106
        Me.lbl_Color_Status9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_8
        '
        Me.lbl_Status_8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_8.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_8.Location = New System.Drawing.Point(27, 182)
        Me.lbl_Status_8.Name = "lbl_Status_8"
        Me.lbl_Status_8.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_8.TabIndex = 105
        Me.lbl_Status_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status8
        '
        Me.lbl_Color_Status8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status8.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status8.Location = New System.Drawing.Point(8, 185)
        Me.lbl_Color_Status8.Name = "lbl_Color_Status8"
        Me.lbl_Color_Status8.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status8.TabIndex = 104
        Me.lbl_Color_Status8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_7
        '
        Me.lbl_Status_7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_7.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_7.Location = New System.Drawing.Point(27, 158)
        Me.lbl_Status_7.Name = "lbl_Status_7"
        Me.lbl_Status_7.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_7.TabIndex = 103
        Me.lbl_Status_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status7
        '
        Me.lbl_Color_Status7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status7.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status7.Location = New System.Drawing.Point(8, 161)
        Me.lbl_Color_Status7.Name = "lbl_Color_Status7"
        Me.lbl_Color_Status7.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status7.TabIndex = 102
        Me.lbl_Color_Status7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_4
        '
        Me.lbl_Status_4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_4.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_4.Location = New System.Drawing.Point(27, 88)
        Me.lbl_Status_4.Name = "lbl_Status_4"
        Me.lbl_Status_4.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_4.TabIndex = 101
        Me.lbl_Status_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_5
        '
        Me.lbl_Status_5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_5.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_5.Location = New System.Drawing.Point(27, 112)
        Me.lbl_Status_5.Name = "lbl_Status_5"
        Me.lbl_Status_5.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_5.TabIndex = 100
        Me.lbl_Status_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_6
        '
        Me.lbl_Status_6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_6.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_6.Location = New System.Drawing.Point(27, 136)
        Me.lbl_Status_6.Name = "lbl_Status_6"
        Me.lbl_Status_6.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_6.TabIndex = 99
        Me.lbl_Status_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_3
        '
        Me.lbl_Status_3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_3.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_3.Location = New System.Drawing.Point(27, 64)
        Me.lbl_Status_3.Name = "lbl_Status_3"
        Me.lbl_Status_3.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_3.TabIndex = 98
        Me.lbl_Status_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_2
        '
        Me.lbl_Status_2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_2.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_2.Location = New System.Drawing.Point(27, 40)
        Me.lbl_Status_2.Name = "lbl_Status_2"
        Me.lbl_Status_2.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_2.TabIndex = 97
        Me.lbl_Status_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_1
        '
        Me.lbl_Status_1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_1.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_1.Location = New System.Drawing.Point(27, 16)
        Me.lbl_Status_1.Name = "lbl_Status_1"
        Me.lbl_Status_1.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_1.TabIndex = 91
        Me.lbl_Status_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status6
        '
        Me.lbl_Color_Status6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status6.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status6.Location = New System.Drawing.Point(8, 139)
        Me.lbl_Color_Status6.Name = "lbl_Color_Status6"
        Me.lbl_Color_Status6.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status6.TabIndex = 96
        Me.lbl_Color_Status6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Status1
        '
        Me.lbl_Color_Status1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status1.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status1.Location = New System.Drawing.Point(8, 19)
        Me.lbl_Color_Status1.Name = "lbl_Color_Status1"
        Me.lbl_Color_Status1.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status1.TabIndex = 91
        Me.lbl_Color_Status1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Status2
        '
        Me.lbl_Color_Status2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status2.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status2.Location = New System.Drawing.Point(8, 43)
        Me.lbl_Color_Status2.Name = "lbl_Color_Status2"
        Me.lbl_Color_Status2.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status2.TabIndex = 92
        Me.lbl_Color_Status2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Status3
        '
        Me.lbl_Color_Status3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status3.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status3.Location = New System.Drawing.Point(8, 67)
        Me.lbl_Color_Status3.Name = "lbl_Color_Status3"
        Me.lbl_Color_Status3.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status3.TabIndex = 93
        Me.lbl_Color_Status3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Status4
        '
        Me.lbl_Color_Status4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status4.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status4.Location = New System.Drawing.Point(8, 91)
        Me.lbl_Color_Status4.Name = "lbl_Color_Status4"
        Me.lbl_Color_Status4.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status4.TabIndex = 94
        Me.lbl_Color_Status4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Status5
        '
        Me.lbl_Color_Status5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status5.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status5.Location = New System.Drawing.Point(8, 115)
        Me.lbl_Color_Status5.Name = "lbl_Color_Status5"
        Me.lbl_Color_Status5.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status5.TabIndex = 95
        Me.lbl_Color_Status5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lbl_Parking_All)
        Me.GroupPanel1.Controls.Add(Me.Label15)
        Me.GroupPanel1.Controls.Add(Me.lbl_Percent_Remain_In_Floor)
        Me.GroupPanel1.Controls.Add(Me.TimeOut)
        Me.GroupPanel1.Controls.Add(Me.lbl_Green)
        Me.GroupPanel1.Controls.Add(Me.DTPickerEnd)
        Me.GroupPanel1.Controls.Add(Me.lbl_Red)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.lbl_Parking)
        Me.GroupPanel1.Controls.Add(Me.btn_Search)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.lbl_Percent_Parking_IN_Floor)
        Me.GroupPanel1.Controls.Add(Me.TimeIn)
        Me.GroupPanel1.Controls.Add(Me.lbl_Lot_Empty)
        Me.GroupPanel1.Controls.Add(Me.DTPickerSt)
        Me.GroupPanel1.Controls.Add(Me.lbl_Show_ID)
        Me.GroupPanel1.Controls.Add(Me.lbl_Parking_In_Floor)
        Me.GroupPanel1.Controls.Add(Me.lbl_Empty)
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(979, 319)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(298, 151)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.Class = ""
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.Class = ""
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.Class = ""
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 184
        Me.GroupPanel1.Text = "สถานะชั้นจอดรถปัจจุบัน"
        '
        'lbl_Parking_All
        '
        Me.lbl_Parking_All.BackColor = System.Drawing.Color.Black
        Me.lbl_Parking_All.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Parking_All.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lbl_Parking_All.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_Parking_All.Location = New System.Drawing.Point(5, 24)
        Me.lbl_Parking_All.Name = "lbl_Parking_All"
        Me.lbl_Parking_All.Size = New System.Drawing.Size(97, 27)
        Me.lbl_Parking_All.TabIndex = 165
        Me.lbl_Parking_All.Text = "999"
        Me.lbl_Parking_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(7, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 16)
        Me.Label15.TabIndex = 164
        Me.Label15.Text = "ช่องจอดทั้งหมด"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Percent_Remain_In_Floor
        '
        Me.lbl_Percent_Remain_In_Floor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_In_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_In_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_In_Floor.Location = New System.Drawing.Point(242, 51)
        Me.lbl_Percent_Remain_In_Floor.Name = "lbl_Percent_Remain_In_Floor"
        Me.lbl_Percent_Remain_In_Floor.Size = New System.Drawing.Size(43, 24)
        Me.lbl_Percent_Remain_In_Floor.TabIndex = 135
        Me.lbl_Percent_Remain_In_Floor.Text = "100%"
        Me.lbl_Percent_Remain_In_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Green
        '
        Me.lbl_Green.BackColor = System.Drawing.Color.Lime
        Me.lbl_Green.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Green.Location = New System.Drawing.Point(48, 56)
        Me.lbl_Green.Name = "lbl_Green"
        Me.lbl_Green.Size = New System.Drawing.Size(158, 14)
        Me.lbl_Green.TabIndex = 137
        Me.lbl_Green.Text = "(100%)"
        Me.lbl_Green.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Red
        '
        Me.lbl_Red.BackColor = System.Drawing.Color.Red
        Me.lbl_Red.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Red.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Red.Location = New System.Drawing.Point(47, 56)
        Me.lbl_Red.Name = "lbl_Red"
        Me.lbl_Red.Size = New System.Drawing.Size(198, 15)
        Me.lbl_Red.TabIndex = 138
        Me.lbl_Red.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Parking
        '
        Me.lbl_Parking.AutoSize = True
        Me.lbl_Parking.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Parking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Parking.ForeColor = System.Drawing.Color.Black
        Me.lbl_Parking.Location = New System.Drawing.Point(204, 5)
        Me.lbl_Parking.Name = "lbl_Parking"
        Me.lbl_Parking.Size = New System.Drawing.Size(70, 16)
        Me.lbl_Parking.TabIndex = 136
        Me.lbl_Parking.Text = "จำนวนรถจอด"
        Me.lbl_Parking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Parking_IN_Floor
        '
        Me.lbl_Percent_Parking_IN_Floor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Parking_IN_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Parking_IN_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Parking_IN_Floor.Location = New System.Drawing.Point(3, 51)
        Me.lbl_Percent_Parking_IN_Floor.Name = "lbl_Percent_Parking_IN_Floor"
        Me.lbl_Percent_Parking_IN_Floor.Size = New System.Drawing.Size(43, 24)
        Me.lbl_Percent_Parking_IN_Floor.TabIndex = 134
        Me.lbl_Percent_Parking_IN_Floor.Text = "100%"
        Me.lbl_Percent_Parking_IN_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Lot_Empty
        '
        Me.lbl_Lot_Empty.BackColor = System.Drawing.Color.Black
        Me.lbl_Lot_Empty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_Empty.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lbl_Lot_Empty.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Lot_Empty.Location = New System.Drawing.Point(109, 24)
        Me.lbl_Lot_Empty.Name = "lbl_Lot_Empty"
        Me.lbl_Lot_Empty.Size = New System.Drawing.Size(85, 27)
        Me.lbl_Lot_Empty.TabIndex = 131
        Me.lbl_Lot_Empty.Text = "999"
        Me.lbl_Lot_Empty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Show_ID
        '
        Me.lbl_Show_ID.BackColor = System.Drawing.Color.AliceBlue
        Me.lbl_Show_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Show_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Show_ID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Show_ID.Location = New System.Drawing.Point(102, 31)
        Me.lbl_Show_ID.Name = "lbl_Show_ID"
        Me.lbl_Show_ID.Size = New System.Drawing.Size(0, 0)
        Me.lbl_Show_ID.TabIndex = 133
        Me.lbl_Show_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Parking_In_Floor
        '
        Me.lbl_Parking_In_Floor.BackColor = System.Drawing.Color.Black
        Me.lbl_Parking_In_Floor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Parking_In_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lbl_Parking_In_Floor.ForeColor = System.Drawing.Color.Red
        Me.lbl_Parking_In_Floor.Location = New System.Drawing.Point(202, 24)
        Me.lbl_Parking_In_Floor.Name = "lbl_Parking_In_Floor"
        Me.lbl_Parking_In_Floor.Size = New System.Drawing.Size(84, 27)
        Me.lbl_Parking_In_Floor.TabIndex = 130
        Me.lbl_Parking_In_Floor.Text = "999"
        Me.lbl_Parking_In_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Empty
        '
        Me.lbl_Empty.AutoSize = True
        Me.lbl_Empty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Empty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Empty.ForeColor = System.Drawing.Color.Black
        Me.lbl_Empty.Location = New System.Drawing.Point(116, 5)
        Me.lbl_Empty.Name = "lbl_Empty"
        Me.lbl_Empty.Size = New System.Drawing.Size(63, 16)
        Me.lbl_Empty.TabIndex = 132
        Me.lbl_Empty.Text = "ช่องจอดว่าง"
        Me.lbl_Empty.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.Tab_Building.Location = New System.Drawing.Point(11, 12)
        Me.Tab_Building.Name = "Tab_Building"
        Me.Tab_Building.ReorderTabsEnabled = True
        Me.Tab_Building.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Tab_Building.SelectedTabIndex = 1
        Me.Tab_Building.Size = New System.Drawing.Size(962, 754)
        Me.Tab_Building.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Tab_Building.TabIndex = 185
        Me.Tab_Building.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Building_A, Me.Building_D})
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
        Me.ID_1.Controls.Add(Me.DgvDetail)
        Me.ID_1.Controls.Add(Me.PictureBox1)
        Me.ID_1.Controls.Add(Me.Pic_ID_1)
        Me.ID_1.Location = New System.Drawing.Point(4, 29)
        Me.ID_1.Name = "ID_1"
        Me.ID_1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ID_1.Size = New System.Drawing.Size(946, 682)
        Me.ID_1.TabIndex = 0
        Me.ID_1.Text = "1"
        Me.ID_1.UseVisualStyleBackColor = True
        '
        'DgvDetail
        '
        Me.DgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetail.Location = New System.Drawing.Point(740, 39)
        Me.DgvDetail.Name = "DgvDetail"
        Me.DgvDetail.Size = New System.Drawing.Size(145, 111)
        Me.DgvDetail.TabIndex = 213
        Me.DgvDetail.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(349, 245)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(248, 192)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 211
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
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
        'ProgressBarX1
        '
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.Class = ""
        Me.ProgressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarX1.Location = New System.Drawing.Point(173, 12)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(1104, 23)
        Me.ProgressBarX1.TabIndex = 212
        Me.ProgressBarX1.Text = "ProgressBar1"
        Me.ProgressBarX1.Visible = False
        '
        'grb_Status_Floor
        '
        Me.grb_Status_Floor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grb_Status_Floor.CanvasColor = System.Drawing.SystemColors.Control
        Me.grb_Status_Floor.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_7)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_7)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_7)
        Me.grb_Status_Floor.Controls.Add(Me.Label5)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_7)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_6)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_6)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_6)
        Me.grb_Status_Floor.Controls.Add(Me.Label13)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_6)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_5)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_5)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_5)
        Me.grb_Status_Floor.Controls.Add(Me.Label22)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_5)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_4)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_3)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_2)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_Remain_Floor_1)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_4)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_3)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_2)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Floor_1)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_4)
        Me.grb_Status_Floor.Controls.Add(Me.Label34)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_4)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_3)
        Me.grb_Status_Floor.Controls.Add(Me.Label37)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_3)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_2)
        Me.grb_Status_Floor.Controls.Add(Me.Label40)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_2)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Bar_IN_Floor_1)
        Me.grb_Status_Floor.Controls.Add(Me.Label43)
        Me.grb_Status_Floor.Controls.Add(Me.lbl_Percent_IN_Floor_1)
        Me.grb_Status_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grb_Status_Floor.Location = New System.Drawing.Point(979, 476)
        Me.grb_Status_Floor.Name = "grb_Status_Floor"
        Me.grb_Status_Floor.Size = New System.Drawing.Size(298, 258)
        '
        '
        '
        Me.grb_Status_Floor.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.grb_Status_Floor.Style.BackColorGradientAngle = 90
        Me.grb_Status_Floor.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.grb_Status_Floor.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.grb_Status_Floor.Style.BorderBottomWidth = 1
        Me.grb_Status_Floor.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.grb_Status_Floor.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.grb_Status_Floor.Style.BorderLeftWidth = 1
        Me.grb_Status_Floor.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.grb_Status_Floor.Style.BorderRightWidth = 1
        Me.grb_Status_Floor.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.grb_Status_Floor.Style.BorderTopWidth = 1
        Me.grb_Status_Floor.Style.Class = ""
        Me.grb_Status_Floor.Style.CornerDiameter = 4
        Me.grb_Status_Floor.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.grb_Status_Floor.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.grb_Status_Floor.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.grb_Status_Floor.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.grb_Status_Floor.StyleMouseDown.Class = ""
        Me.grb_Status_Floor.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.grb_Status_Floor.StyleMouseOver.Class = ""
        Me.grb_Status_Floor.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.grb_Status_Floor.TabIndex = 186
        Me.grb_Status_Floor.Text = "สถานะชั้นจอดรถ"
        '
        'lbl_Percent_Remain_Floor_7
        '
        Me.lbl_Percent_Remain_Floor_7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_7.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_7.Location = New System.Drawing.Point(229, 203)
        Me.lbl_Percent_Remain_Floor_7.Name = "lbl_Percent_Remain_Floor_7"
        Me.lbl_Percent_Remain_Floor_7.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_7.TabIndex = 170
        Me.lbl_Percent_Remain_Floor_7.Text = "999(0%)"
        Me.lbl_Percent_Remain_Floor_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Floor_7
        '
        Me.lbl_Floor_7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_7.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_7.Location = New System.Drawing.Point(0, 203)
        Me.lbl_Floor_7.Name = "lbl_Floor_7"
        Me.lbl_Floor_7.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_7.TabIndex = 173
        Me.lbl_Floor_7.Text = "B6"
        Me.lbl_Floor_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_7
        '
        Me.lbl_Bar_IN_Floor_7.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_7.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_7.Location = New System.Drawing.Point(129, 204)
        Me.lbl_Bar_IN_Floor_7.Name = "lbl_Bar_IN_Floor_7"
        Me.lbl_Bar_IN_Floor_7.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_7.TabIndex = 171
        Me.lbl_Bar_IN_Floor_7.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Red
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(128, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 24)
        Me.Label5.TabIndex = 172
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_7
        '
        Me.lbl_Percent_IN_Floor_7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_7.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_7.Location = New System.Drawing.Point(70, 203)
        Me.lbl_Percent_IN_Floor_7.Name = "lbl_Percent_IN_Floor_7"
        Me.lbl_Percent_IN_Floor_7.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_7.TabIndex = 169
        Me.lbl_Percent_IN_Floor_7.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Remain_Floor_6
        '
        Me.lbl_Percent_Remain_Floor_6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_6.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_6.Location = New System.Drawing.Point(229, 171)
        Me.lbl_Percent_Remain_Floor_6.Name = "lbl_Percent_Remain_Floor_6"
        Me.lbl_Percent_Remain_Floor_6.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_6.TabIndex = 165
        Me.lbl_Percent_Remain_Floor_6.Text = "999(0%)"
        Me.lbl_Percent_Remain_Floor_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Floor_6
        '
        Me.lbl_Floor_6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_6.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_6.Location = New System.Drawing.Point(0, 171)
        Me.lbl_Floor_6.Name = "lbl_Floor_6"
        Me.lbl_Floor_6.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_6.TabIndex = 168
        Me.lbl_Floor_6.Text = "B6"
        Me.lbl_Floor_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_6
        '
        Me.lbl_Bar_IN_Floor_6.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_6.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_6.Location = New System.Drawing.Point(129, 171)
        Me.lbl_Bar_IN_Floor_6.Name = "lbl_Bar_IN_Floor_6"
        Me.lbl_Bar_IN_Floor_6.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_6.TabIndex = 166
        Me.lbl_Bar_IN_Floor_6.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Red
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.ForeColor = System.Drawing.Color.Lime
        Me.Label13.Location = New System.Drawing.Point(128, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 24)
        Me.Label13.TabIndex = 167
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_6
        '
        Me.lbl_Percent_IN_Floor_6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_6.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_6.Location = New System.Drawing.Point(70, 171)
        Me.lbl_Percent_IN_Floor_6.Name = "lbl_Percent_IN_Floor_6"
        Me.lbl_Percent_IN_Floor_6.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_6.TabIndex = 164
        Me.lbl_Percent_IN_Floor_6.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Remain_Floor_5
        '
        Me.lbl_Percent_Remain_Floor_5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_5.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_5.Location = New System.Drawing.Point(229, 139)
        Me.lbl_Percent_Remain_Floor_5.Name = "lbl_Percent_Remain_Floor_5"
        Me.lbl_Percent_Remain_Floor_5.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_5.TabIndex = 160
        Me.lbl_Percent_Remain_Floor_5.Text = "999(0%)"
        Me.lbl_Percent_Remain_Floor_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Floor_5
        '
        Me.lbl_Floor_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_5.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_5.Location = New System.Drawing.Point(0, 139)
        Me.lbl_Floor_5.Name = "lbl_Floor_5"
        Me.lbl_Floor_5.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_5.TabIndex = 163
        Me.lbl_Floor_5.Text = "B5"
        Me.lbl_Floor_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_5
        '
        Me.lbl_Bar_IN_Floor_5.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_5.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_5.Location = New System.Drawing.Point(129, 140)
        Me.lbl_Bar_IN_Floor_5.Name = "lbl_Bar_IN_Floor_5"
        Me.lbl_Bar_IN_Floor_5.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_5.TabIndex = 161
        Me.lbl_Bar_IN_Floor_5.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Red
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.ForeColor = System.Drawing.Color.Lime
        Me.Label22.Location = New System.Drawing.Point(128, 139)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 24)
        Me.Label22.TabIndex = 162
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_5
        '
        Me.lbl_Percent_IN_Floor_5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_5.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_5.Location = New System.Drawing.Point(70, 139)
        Me.lbl_Percent_IN_Floor_5.Name = "lbl_Percent_IN_Floor_5"
        Me.lbl_Percent_IN_Floor_5.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_5.TabIndex = 159
        Me.lbl_Percent_IN_Floor_5.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Remain_Floor_4
        '
        Me.lbl_Percent_Remain_Floor_4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_4.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_4.Location = New System.Drawing.Point(229, 107)
        Me.lbl_Percent_Remain_Floor_4.Name = "lbl_Percent_Remain_Floor_4"
        Me.lbl_Percent_Remain_Floor_4.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_4.TabIndex = 152
        Me.lbl_Percent_Remain_Floor_4.Text = "999(0%)"
        Me.lbl_Percent_Remain_Floor_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Remain_Floor_3
        '
        Me.lbl_Percent_Remain_Floor_3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_3.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_3.Location = New System.Drawing.Point(229, 75)
        Me.lbl_Percent_Remain_Floor_3.Name = "lbl_Percent_Remain_Floor_3"
        Me.lbl_Percent_Remain_Floor_3.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_3.TabIndex = 148
        Me.lbl_Percent_Remain_Floor_3.Text = "999(0%)"
        Me.lbl_Percent_Remain_Floor_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Remain_Floor_2
        '
        Me.lbl_Percent_Remain_Floor_2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_2.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_2.Location = New System.Drawing.Point(229, 43)
        Me.lbl_Percent_Remain_Floor_2.Name = "lbl_Percent_Remain_Floor_2"
        Me.lbl_Percent_Remain_Floor_2.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_2.TabIndex = 144
        Me.lbl_Percent_Remain_Floor_2.Text = "999(0%)"
        Me.lbl_Percent_Remain_Floor_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_Remain_Floor_1
        '
        Me.lbl_Percent_Remain_Floor_1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_Remain_Floor_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_Remain_Floor_1.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_Remain_Floor_1.Location = New System.Drawing.Point(229, 11)
        Me.lbl_Percent_Remain_Floor_1.Name = "lbl_Percent_Remain_Floor_1"
        Me.lbl_Percent_Remain_Floor_1.Size = New System.Drawing.Size(61, 24)
        Me.lbl_Percent_Remain_Floor_1.TabIndex = 140
        Me.lbl_Percent_Remain_Floor_1.Text = "999(100%)"
        Me.lbl_Percent_Remain_Floor_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Floor_4
        '
        Me.lbl_Floor_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_4.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_4.Location = New System.Drawing.Point(0, 107)
        Me.lbl_Floor_4.Name = "lbl_Floor_4"
        Me.lbl_Floor_4.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_4.TabIndex = 158
        Me.lbl_Floor_4.Text = "B4"
        Me.lbl_Floor_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Floor_3
        '
        Me.lbl_Floor_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_3.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_3.Location = New System.Drawing.Point(0, 75)
        Me.lbl_Floor_3.Name = "lbl_Floor_3"
        Me.lbl_Floor_3.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_3.TabIndex = 157
        Me.lbl_Floor_3.Text = "B3"
        Me.lbl_Floor_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Floor_2
        '
        Me.lbl_Floor_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_2.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_2.Location = New System.Drawing.Point(0, 43)
        Me.lbl_Floor_2.Name = "lbl_Floor_2"
        Me.lbl_Floor_2.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_2.TabIndex = 156
        Me.lbl_Floor_2.Text = "B2"
        Me.lbl_Floor_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Floor_1
        '
        Me.lbl_Floor_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_Floor_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_1.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor_1.Location = New System.Drawing.Point(0, 11)
        Me.lbl_Floor_1.Name = "lbl_Floor_1"
        Me.lbl_Floor_1.Size = New System.Drawing.Size(70, 24)
        Me.lbl_Floor_1.TabIndex = 155
        Me.lbl_Floor_1.Text = "B1"
        Me.lbl_Floor_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_4
        '
        Me.lbl_Bar_IN_Floor_4.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_4.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_4.Location = New System.Drawing.Point(129, 108)
        Me.lbl_Bar_IN_Floor_4.Name = "lbl_Bar_IN_Floor_4"
        Me.lbl_Bar_IN_Floor_4.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_4.TabIndex = 153
        Me.lbl_Bar_IN_Floor_4.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Red
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.ForeColor = System.Drawing.Color.Lime
        Me.Label34.Location = New System.Drawing.Point(128, 107)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(101, 24)
        Me.Label34.TabIndex = 154
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_4
        '
        Me.lbl_Percent_IN_Floor_4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_4.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_4.Location = New System.Drawing.Point(70, 107)
        Me.lbl_Percent_IN_Floor_4.Name = "lbl_Percent_IN_Floor_4"
        Me.lbl_Percent_IN_Floor_4.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_4.TabIndex = 151
        Me.lbl_Percent_IN_Floor_4.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_3
        '
        Me.lbl_Bar_IN_Floor_3.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_3.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_3.Location = New System.Drawing.Point(129, 76)
        Me.lbl_Bar_IN_Floor_3.Name = "lbl_Bar_IN_Floor_3"
        Me.lbl_Bar_IN_Floor_3.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_3.TabIndex = 149
        Me.lbl_Bar_IN_Floor_3.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Red
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.ForeColor = System.Drawing.Color.Lime
        Me.Label37.Location = New System.Drawing.Point(128, 75)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(101, 24)
        Me.Label37.TabIndex = 150
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_3
        '
        Me.lbl_Percent_IN_Floor_3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_3.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_3.Location = New System.Drawing.Point(70, 75)
        Me.lbl_Percent_IN_Floor_3.Name = "lbl_Percent_IN_Floor_3"
        Me.lbl_Percent_IN_Floor_3.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_3.TabIndex = 147
        Me.lbl_Percent_IN_Floor_3.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_2
        '
        Me.lbl_Bar_IN_Floor_2.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_2.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_2.Location = New System.Drawing.Point(129, 44)
        Me.lbl_Bar_IN_Floor_2.Name = "lbl_Bar_IN_Floor_2"
        Me.lbl_Bar_IN_Floor_2.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_2.TabIndex = 145
        Me.lbl_Bar_IN_Floor_2.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Red
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label40.ForeColor = System.Drawing.Color.Lime
        Me.Label40.Location = New System.Drawing.Point(128, 43)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(101, 24)
        Me.Label40.TabIndex = 146
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_2
        '
        Me.lbl_Percent_IN_Floor_2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_2.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_2.Location = New System.Drawing.Point(70, 43)
        Me.lbl_Percent_IN_Floor_2.Name = "lbl_Percent_IN_Floor_2"
        Me.lbl_Percent_IN_Floor_2.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_2.TabIndex = 143
        Me.lbl_Percent_IN_Floor_2.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Bar_IN_Floor_1
        '
        Me.lbl_Bar_IN_Floor_1.BackColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_1.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Bar_IN_Floor_1.Location = New System.Drawing.Point(129, 12)
        Me.lbl_Bar_IN_Floor_1.Name = "lbl_Bar_IN_Floor_1"
        Me.lbl_Bar_IN_Floor_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_Bar_IN_Floor_1.Size = New System.Drawing.Size(65, 23)
        Me.lbl_Bar_IN_Floor_1.TabIndex = 141
        Me.lbl_Bar_IN_Floor_1.Text = "(100%)"
        Me.lbl_Bar_IN_Floor_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Red
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label43.ForeColor = System.Drawing.Color.Lime
        Me.Label43.Location = New System.Drawing.Point(128, 11)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(101, 24)
        Me.Label43.TabIndex = 142
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Percent_IN_Floor_1
        '
        Me.lbl_Percent_IN_Floor_1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Percent_IN_Floor_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Percent_IN_Floor_1.ForeColor = System.Drawing.Color.Black
        Me.lbl_Percent_IN_Floor_1.Location = New System.Drawing.Point(70, 11)
        Me.lbl_Percent_IN_Floor_1.Name = "lbl_Percent_IN_Floor_1"
        Me.lbl_Percent_IN_Floor_1.Size = New System.Drawing.Size(57, 24)
        Me.lbl_Percent_IN_Floor_1.TabIndex = 139
        Me.lbl_Percent_IN_Floor_1.Text = "999(100%)"
        Me.lbl_Percent_IN_Floor_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1091, 740)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 33)
        Me.Button1.TabIndex = 213
        Me.Button1.Text = "บันทึกข้อมูล"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1189, 740)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 33)
        Me.Button2.TabIndex = 214
        Me.Button2.Text = "พิมพ์รายงาน"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'lbl_Max_Parking
        '
        Me.lbl_Max_Parking.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Max_Parking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Max_Parking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Max_Parking.ForeColor = System.Drawing.Color.Navy
        Me.lbl_Max_Parking.Location = New System.Drawing.Point(981, 738)
        Me.lbl_Max_Parking.Name = "lbl_Max_Parking"
        Me.lbl_Max_Parking.Size = New System.Drawing.Size(104, 26)
        Me.lbl_Max_Parking.TabIndex = 215
        Me.lbl_Max_Parking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Max_Parking.Visible = False
        '
        'frm_Hostory_Display
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 609)
        Me.Controls.Add(Me.lbl_Max_Parking)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.Controls.Add(Me.grb_Status_Floor)
        Me.Controls.Add(Me.Tab_Building)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Hostory_Display"
        Me.Text = "ประวัติการจอดรถแต่ละช่วงเวลา"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Tab_Building, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_Building.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.Tab_ParkingA.ResumeLayout(False)
        Me.ID_1.ResumeLayout(False)
        CType(Me.DgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.grb_Status_Floor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TimerRealtime As System.Windows.Forms.Timer
    Friend WithEvents img_Close As System.Windows.Forms.ImageList
    Friend WithEvents T_Refesh_Status As System.Windows.Forms.Timer
    Friend WithEvents DTPickerSt As System.Windows.Forms.DateTimePicker
    Friend WithEvents TimeIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TimeOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Status_10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_9 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status9 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_8 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status8 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Status5 As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbl_Parking_All As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_In_Floor As System.Windows.Forms.Label
    Friend WithEvents lbl_Green As System.Windows.Forms.Label
    Friend WithEvents lbl_Red As System.Windows.Forms.Label
    Friend WithEvents lbl_Parking As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Parking_IN_Floor As System.Windows.Forms.Label
    Friend WithEvents lbl_Lot_Empty As System.Windows.Forms.Label
    Friend WithEvents lbl_Show_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_Parking_In_Floor As System.Windows.Forms.Label
    Friend WithEvents lbl_Empty As System.Windows.Forms.Label
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
    Friend WithEvents grb_Status_Floor As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lbl_Percent_Remain_Floor_7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_Floor_6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_Floor_5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_Floor_4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_Floor_3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_Floor_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_Remain_Floor_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_4 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_3 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_2 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Bar_IN_Floor_1 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent_IN_Floor_1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents DgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbl_Max_Parking As System.Windows.Forms.Label
End Class
