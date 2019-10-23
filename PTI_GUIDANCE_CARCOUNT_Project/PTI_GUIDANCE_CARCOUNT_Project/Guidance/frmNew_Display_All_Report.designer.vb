<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNew_Display_All_Report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNew_Display_All_Report))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Close = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerRealtime = New System.Windows.Forms.Timer(Me.components)
        Me.Pl_detail = New DevComponents.DotNetBar.PanelEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_Alert = New System.Windows.Forms.Timer(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.RD_Parking_Time = New System.Windows.Forms.RadioButton()
        Me.RD_Fequency = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.L4 = New System.Windows.Forms.Label()
        Me.PB4 = New System.Windows.Forms.PictureBox()
        Me.L3 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.PB3 = New System.Windows.Forms.PictureBox()
        Me.PB1 = New System.Windows.Forms.PictureBox()
        Me.PB2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Floor = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Cmb_Tower = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.DT_End = New System.Windows.Forms.DateTimePicker()
        Me.DT_St = New System.Windows.Forms.DateTimePicker()
        Me.Pic_ID_2 = New System.Windows.Forms.PictureBox()
        Me.BalloonTip1 = New DevComponents.DotNetBar.BalloonTip()
        Me.DotNetBarManager1 = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
        Me.DockContainerItem2 = New DevComponents.DotNetBar.DockContainerItem()
        Me.DockContainerItem3 = New DevComponents.DotNetBar.DockContainerItem()
        Me.Pl_detail.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PB4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Blank Badge Green.ico")
        Me.ImageList1.Images.SetKeyName(1, "Blank Disc Red.ico")
        '
        'img_Close
        '
        Me.img_Close.ImageStream = CType(resources.GetObject("img_Close.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Close.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Close.Images.SetKeyName(0, "")
        '
        'TimerRealtime
        '
        Me.TimerRealtime.Enabled = True
        Me.TimerRealtime.Interval = 3000
        '
        'Pl_detail
        '
        Me.Pl_detail.CanvasColor = System.Drawing.SystemColors.Control
        Me.Pl_detail.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Pl_detail.Controls.Add(Me.Label1)
        Me.Pl_detail.Location = New System.Drawing.Point(0, 598)
        Me.Pl_detail.Name = "Pl_detail"
        Me.Pl_detail.Size = New System.Drawing.Size(1287, 43)
        Me.Pl_detail.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Pl_detail.Style.BackColor1.Color = System.Drawing.Color.MediumTurquoise
        Me.Pl_detail.Style.BackColor2.Color = System.Drawing.Color.Teal
        Me.Pl_detail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Pl_detail.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Pl_detail.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Pl_detail.Style.GradientAngle = 90
        Me.Pl_detail.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("CordiaUPC", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1274, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'T_Alert
        '
        Me.T_Alert.Enabled = True
        Me.T_Alert.Interval = 10000
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.CircularProgress1)
        Me.PanelEx1.Controls.Add(Me.PanelEx2)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1362, 741)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.Honeydew
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.PaleTurquoise
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 135
        '
        'CircularProgress1
        '
        Me.CircularProgress1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.CircularProgress1.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.CircularProgress1.BackgroundStyle.Class = ""
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(10, 10)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularProgress1.ProgressTextColor = System.Drawing.Color.Black
        Me.CircularProgress1.ProgressTextVisible = True
        Me.CircularProgress1.Size = New System.Drawing.Size(98, 102)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7
        Me.CircularProgress1.TabIndex = 107
        Me.CircularProgress1.UseWaitCursor = True
        Me.CircularProgress1.Visible = False
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.RD_Parking_Time)
        Me.PanelEx2.Controls.Add(Me.RD_Fequency)
        Me.PanelEx2.Controls.Add(Me.Panel2)
        Me.PanelEx2.Controls.Add(Me.PictureBox1)
        Me.PanelEx2.Controls.Add(Me.Label2)
        Me.PanelEx2.Controls.Add(Me.Cmb_Floor)
        Me.PanelEx2.Controls.Add(Me.Cmb_Tower)
        Me.PanelEx2.Controls.Add(Me.ButtonX1)
        Me.PanelEx2.Controls.Add(Me.ButtonX2)
        Me.PanelEx2.Controls.Add(Me.DT_End)
        Me.PanelEx2.Controls.Add(Me.Pl_detail)
        Me.PanelEx2.Controls.Add(Me.DT_St)
        Me.PanelEx2.Controls.Add(Me.Pic_ID_2)
        Me.PanelEx2.Location = New System.Drawing.Point(12, 12)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1297, 732)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.Alpha = CType(200, Byte)
        Me.PanelEx2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 3
        '
        'RD_Parking_Time
        '
        Me.RD_Parking_Time.AutoSize = True
        Me.RD_Parking_Time.ForeColor = System.Drawing.Color.White
        Me.RD_Parking_Time.Location = New System.Drawing.Point(178, 698)
        Me.RD_Parking_Time.Name = "RD_Parking_Time"
        Me.RD_Parking_Time.Size = New System.Drawing.Size(169, 17)
        Me.RD_Parking_Time.TabIndex = 113
        Me.RD_Parking_Time.Text = "รายงานระยะเวลาในการใช้งาน"
        Me.RD_Parking_Time.UseVisualStyleBackColor = True
        Me.RD_Parking_Time.Visible = False
        '
        'RD_Fequency
        '
        Me.RD_Fequency.AutoSize = True
        Me.RD_Fequency.Checked = True
        Me.RD_Fequency.ForeColor = System.Drawing.Color.White
        Me.RD_Fequency.Location = New System.Drawing.Point(16, 698)
        Me.RD_Fequency.Name = "RD_Fequency"
        Me.RD_Fequency.Size = New System.Drawing.Size(156, 17)
        Me.RD_Fequency.TabIndex = 4
        Me.RD_Fequency.TabStop = True
        Me.RD_Fequency.Text = "รายงานความถี่ในการใช้งาน"
        Me.RD_Fequency.UseVisualStyleBackColor = True
        Me.RD_Fequency.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.L4)
        Me.Panel2.Controls.Add(Me.PB4)
        Me.Panel2.Controls.Add(Me.L3)
        Me.Panel2.Controls.Add(Me.L1)
        Me.Panel2.Controls.Add(Me.L2)
        Me.Panel2.Controls.Add(Me.PB3)
        Me.Panel2.Controls.Add(Me.PB1)
        Me.Panel2.Controls.Add(Me.PB2)
        Me.Panel2.Location = New System.Drawing.Point(1070, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(214, 100)
        Me.Panel2.TabIndex = 109
        '
        'L4
        '
        Me.L4.BackColor = System.Drawing.Color.LightCoral
        Me.L4.Location = New System.Drawing.Point(57, 75)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(150, 21)
        Me.L4.TabIndex = 121
        Me.L4.Text = "0 - 0"
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PB4
        '
        Me.PB4.Location = New System.Drawing.Point(4, 75)
        Me.PB4.Name = "PB4"
        Me.PB4.Size = New System.Drawing.Size(48, 19)
        Me.PB4.TabIndex = 125
        Me.PB4.TabStop = False
        '
        'L3
        '
        Me.L3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.L3.Location = New System.Drawing.Point(57, 52)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(150, 21)
        Me.L3.TabIndex = 120
        Me.L3.Text = "0 - 0"
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L1
        '
        Me.L1.BackColor = System.Drawing.Color.Linen
        Me.L1.Location = New System.Drawing.Point(55, 5)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(150, 21)
        Me.L1.TabIndex = 118
        Me.L1.Text = "0 - 0"
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L2
        '
        Me.L2.BackColor = System.Drawing.Color.NavajoWhite
        Me.L2.Location = New System.Drawing.Point(56, 28)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(150, 21)
        Me.L2.TabIndex = 119
        Me.L2.Text = "0 - 0"
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PB3
        '
        Me.PB3.Location = New System.Drawing.Point(4, 51)
        Me.PB3.Name = "PB3"
        Me.PB3.Size = New System.Drawing.Size(48, 19)
        Me.PB3.TabIndex = 124
        Me.PB3.TabStop = False
        '
        'PB1
        '
        Me.PB1.Location = New System.Drawing.Point(4, 5)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(48, 19)
        Me.PB1.TabIndex = 122
        Me.PB1.TabStop = False
        '
        'PB2
        '
        Me.PB2.Location = New System.Drawing.Point(4, 28)
        Me.PB2.Name = "PB2"
        Me.PB2.Size = New System.Drawing.Size(48, 19)
        Me.PB2.TabIndex = 123
        Me.PB2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(167, 110)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 108
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(610, 669)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 18)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "ถึง"
        '
        'Cmb_Floor
        '
        Me.Cmb_Floor.DisplayMember = "Text"
        Me.Cmb_Floor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Cmb_Floor.FormattingEnabled = True
        Me.Cmb_Floor.ItemHeight = 18
        Me.Cmb_Floor.Location = New System.Drawing.Point(222, 664)
        Me.Cmb_Floor.Name = "Cmb_Floor"
        Me.Cmb_Floor.Size = New System.Drawing.Size(196, 24)
        Me.Cmb_Floor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Floor.TabIndex = 110
        Me.Cmb_Floor.WatermarkColor = System.Drawing.SystemColors.Desktop
        Me.Cmb_Floor.WatermarkText = "เลือกชั้น"
        '
        'Cmb_Tower
        '
        Me.Cmb_Tower.DisplayMember = "Text"
        Me.Cmb_Tower.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Cmb_Tower.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Cmb_Tower.FormattingEnabled = True
        Me.Cmb_Tower.ItemHeight = 18
        Me.Cmb_Tower.Location = New System.Drawing.Point(20, 664)
        Me.Cmb_Tower.Name = "Cmb_Tower"
        Me.Cmb_Tower.Size = New System.Drawing.Size(196, 24)
        Me.Cmb_Tower.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cmb_Tower.TabIndex = 109
        Me.Cmb_Tower.WatermarkColor = System.Drawing.SystemColors.Desktop
        Me.Cmb_Tower.WatermarkText = "เลือกอาคาร"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(1197, 664)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(87, 39)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 1
        Me.ButtonX1.Text = "Print Preview"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(1090, 664)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(101, 39)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 6
        Me.ButtonX2.Text = "แสดงรายละเอียด"
        '
        'DT_End
        '
        Me.DT_End.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.DT_End.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DT_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DT_End.Location = New System.Drawing.Point(634, 665)
        Me.DT_End.Name = "DT_End"
        Me.DT_End.Size = New System.Drawing.Size(163, 22)
        Me.DT_End.TabIndex = 5
        '
        'DT_St
        '
        Me.DT_St.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.DT_St.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DT_St.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DT_St.Location = New System.Drawing.Point(440, 665)
        Me.DT_St.Name = "DT_St"
        Me.DT_St.Size = New System.Drawing.Size(164, 22)
        Me.DT_St.TabIndex = 4
        '
        'Pic_ID_2
        '
        Me.Pic_ID_2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_2.Location = New System.Drawing.Point(4, 3)
        Me.Pic_ID_2.Name = "Pic_ID_2"
        Me.Pic_ID_2.Size = New System.Drawing.Size(1282, 621)
        Me.Pic_ID_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_2.TabIndex = 1
        Me.Pic_ID_2.TabStop = False
        '
        'DotNetBarManager1
        '
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins)
        Me.DotNetBarManager1.BottomDockSite = Me.DockSite4
        Me.DotNetBarManager1.EnableFullSizeDock = False
        Me.DotNetBarManager1.LeftDockSite = Me.DockSite1
        Me.DotNetBarManager1.ParentForm = Me
        Me.DotNetBarManager1.RightDockSite = Me.DockSite2
        Me.DotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.DotNetBarManager1.ToolbarBottomDockSite = Me.DockSite8
        Me.DotNetBarManager1.ToolbarLeftDockSite = Me.DockSite5
        Me.DotNetBarManager1.ToolbarRightDockSite = Me.DockSite6
        Me.DotNetBarManager1.ToolbarTopDockSite = Me.DockSite7
        Me.DotNetBarManager1.TopDockSite = Me.DockSite3
        '
        'DockSite4
        '
        Me.DockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite4.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite4.Location = New System.Drawing.Point(0, 741)
        Me.DockSite4.Name = "DockSite4"
        Me.DockSite4.Size = New System.Drawing.Size(1362, 0)
        Me.DockSite4.TabIndex = 139
        Me.DockSite4.TabStop = False
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite1.Location = New System.Drawing.Point(0, 0)
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.Size = New System.Drawing.Size(0, 741)
        Me.DockSite1.TabIndex = 136
        Me.DockSite1.TabStop = False
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite2.Location = New System.Drawing.Point(1362, 0)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(0, 741)
        Me.DockSite2.TabIndex = 137
        Me.DockSite2.TabStop = False
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite8.Location = New System.Drawing.Point(0, 741)
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.Size = New System.Drawing.Size(1362, 0)
        Me.DockSite8.TabIndex = 143
        Me.DockSite8.TabStop = False
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite5.Location = New System.Drawing.Point(0, 0)
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.Size = New System.Drawing.Size(0, 741)
        Me.DockSite5.TabIndex = 140
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite6.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite6.Location = New System.Drawing.Point(1362, 0)
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.Size = New System.Drawing.Size(0, 741)
        Me.DockSite6.TabIndex = 141
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite7.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite7.Location = New System.Drawing.Point(0, 0)
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.Size = New System.Drawing.Size(1362, 0)
        Me.DockSite7.TabIndex = 142
        Me.DockSite7.TabStop = False
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite3.Location = New System.Drawing.Point(0, 0)
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.Size = New System.Drawing.Size(1362, 0)
        Me.DockSite3.TabIndex = 138
        Me.DockSite3.TabStop = False
        '
        'DockContainerItem2
        '
        Me.DockContainerItem2.Name = "DockContainerItem2"
        Me.DockContainerItem2.Text = "DockContainerItem2"
        '
        'DockContainerItem3
        '
        Me.DockContainerItem3.Name = "DockContainerItem3"
        Me.DockContainerItem3.Text = "DockContainerItem3"
        '
        'frmNew_Display_All_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNew_Display_All_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "สถานะลานจอดรถ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Pl_detail.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PB4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents img_Close As System.Windows.Forms.ImageList
    Friend WithEvents TimerRealtime As System.Windows.Forms.Timer
    Friend WithEvents Pic_ID_2 As System.Windows.Forms.PictureBox
    Friend WithEvents T_Alert As System.Windows.Forms.Timer
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Pl_detail As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BalloonTip1 As DevComponents.DotNetBar.BalloonTip
    Friend WithEvents DotNetBarManager1 As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockContainerItem2 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents DockContainerItem3 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents DT_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT_St As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cmb_Floor As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Cmb_Tower As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents L4 As System.Windows.Forms.Label
    Friend WithEvents L3 As System.Windows.Forms.Label
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents PB4 As System.Windows.Forms.PictureBox
    Friend WithEvents PB3 As System.Windows.Forms.PictureBox
    Friend WithEvents PB2 As System.Windows.Forms.PictureBox
    Friend WithEvents PB1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RD_Parking_Time As System.Windows.Forms.RadioButton
    Friend WithEvents RD_Fequency As System.Windows.Forms.RadioButton
End Class
