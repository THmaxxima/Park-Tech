<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNew_Display_Over_HH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNew_Display_Over_HH))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Close = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerRealtime = New System.Windows.Forms.Timer(Me.components)
        Me.Pl_detail = New DevComponents.DotNetBar.PanelEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pic_ID_2 = New System.Windows.Forms.PictureBox()
        Me.T_Alert = New System.Windows.Forms.Timer(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Lb_status_lot_avalaible = New System.Windows.Forms.Label()
        Me.Lb_status_lot_use = New System.Windows.Forms.Label()
        Me.Lb_status_lot_all = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_Status_10 = New System.Windows.Forms.Label()
        Me.lbl_Color_Status10 = New System.Windows.Forms.Label()
        Me.lbl_Status_9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.grb_Defeulf = New System.Windows.Forms.GroupBox()
        Me.lbl_Status_False = New System.Windows.Forms.Label()
        Me.lbl_Color_False = New System.Windows.Forms.Label()
        Me.lbl_Status_Red = New System.Windows.Forms.Label()
        Me.lbl_Color_Green = New System.Windows.Forms.Label()
        Me.lbl_Color_Red = New System.Windows.Forms.Label()
        Me.lbl_Status_Green = New System.Windows.Forms.Label()
        Me.BalloonTip1 = New DevComponents.DotNetBar.BalloonTip()
        Me.Pl_detail.SuspendLayout()
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grb_Defeulf.SuspendLayout()
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
        Me.TimerRealtime.Interval = 5000
        '
        'Pl_detail
        '
        Me.Pl_detail.CanvasColor = System.Drawing.SystemColors.Control
        Me.Pl_detail.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Pl_detail.Controls.Add(Me.Label1)
        Me.Pl_detail.Location = New System.Drawing.Point(0, 595)
        Me.Pl_detail.Name = "Pl_detail"
        Me.Pl_detail.Size = New System.Drawing.Size(1287, 33)
        Me.Pl_detail.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.Pl_detail.Style.BackColor1.Color = System.Drawing.Color.MediumTurquoise
        Me.Pl_detail.Style.BackColor2.Color = System.Drawing.Color.Teal
        Me.Pl_detail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.Pl_detail.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.Pl_detail.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.Pl_detail.Style.GradientAngle = 90
        Me.Pl_detail.TabIndex = 3
        Me.Pl_detail.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(13, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1264, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pic_ID_2
        '
        Me.Pic_ID_2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Pic_ID_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pic_ID_2.Location = New System.Drawing.Point(3, 3)
        Me.Pic_ID_2.Name = "Pic_ID_2"
        Me.Pic_ID_2.Size = New System.Drawing.Size(1282, 621)
        Me.Pic_ID_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_ID_2.TabIndex = 1
        Me.Pic_ID_2.TabStop = False
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
        Me.PanelEx1.Controls.Add(Me.PanelEx2)
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1312, 742)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.Honeydew
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.PaleTurquoise
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 135
        Me.PanelEx1.Text = "PanelEx1"
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.Label6)
        Me.PanelEx2.Controls.Add(Me.Label7)
        Me.PanelEx2.Controls.Add(Me.Pl_detail)
        Me.PanelEx2.Controls.Add(Me.GroupBox3)
        Me.PanelEx2.Controls.Add(Me.grb_Defeulf)
        Me.PanelEx2.Controls.Add(Me.Pic_ID_2)
        Me.PanelEx2.Location = New System.Drawing.Point(12, 12)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1288, 658)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.Alpha = CType(200, Byte)
        Me.PanelEx2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 3
        Me.PanelEx2.Text = "PanelEx2"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(1190, 628)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 27)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "0"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(1154, 634)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 16)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "รวม :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Lb_status_lot_avalaible)
        Me.GroupBox3.Controls.Add(Me.Lb_status_lot_use)
        Me.GroupBox3.Controls.Add(Me.Lb_status_lot_all)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_10)
        Me.GroupBox3.Controls.Add(Me.lbl_Color_Status10)
        Me.GroupBox3.Controls.Add(Me.lbl_Status_9)
        Me.GroupBox3.Controls.Add(Me.Label2)
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
        Me.GroupBox3.Location = New System.Drawing.Point(313, 666)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(970, 86)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        '
        'Lb_status_lot_avalaible
        '
        Me.Lb_status_lot_avalaible.BackColor = System.Drawing.Color.Black
        Me.Lb_status_lot_avalaible.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Lb_status_lot_avalaible.ForeColor = System.Drawing.Color.Lime
        Me.Lb_status_lot_avalaible.Location = New System.Drawing.Point(877, 58)
        Me.Lb_status_lot_avalaible.Name = "Lb_status_lot_avalaible"
        Me.Lb_status_lot_avalaible.Size = New System.Drawing.Size(87, 20)
        Me.Lb_status_lot_avalaible.TabIndex = 115
        Me.Lb_status_lot_avalaible.Text = "0"
        Me.Lb_status_lot_avalaible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_status_lot_use
        '
        Me.Lb_status_lot_use.BackColor = System.Drawing.Color.Black
        Me.Lb_status_lot_use.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Lb_status_lot_use.ForeColor = System.Drawing.Color.Red
        Me.Lb_status_lot_use.Location = New System.Drawing.Point(877, 33)
        Me.Lb_status_lot_use.Name = "Lb_status_lot_use"
        Me.Lb_status_lot_use.Size = New System.Drawing.Size(87, 20)
        Me.Lb_status_lot_use.TabIndex = 114
        Me.Lb_status_lot_use.Text = "0"
        Me.Lb_status_lot_use.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_status_lot_all
        '
        Me.Lb_status_lot_all.BackColor = System.Drawing.Color.Black
        Me.Lb_status_lot_all.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Lb_status_lot_all.ForeColor = System.Drawing.Color.Yellow
        Me.Lb_status_lot_all.Location = New System.Drawing.Point(877, 10)
        Me.Lb_status_lot_all.Name = "Lb_status_lot_all"
        Me.Lb_status_lot_all.Size = New System.Drawing.Size(87, 20)
        Me.Lb_status_lot_all.TabIndex = 113
        Me.Lb_status_lot_all.Text = "0"
        Me.Lb_status_lot_all.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(813, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "ช่องจอดว่าง"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(799, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "ช่องจอดใช้งาน"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(795, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "ช่องจอดทั้งหมด"
        '
        'lbl_Status_10
        '
        Me.lbl_Status_10.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_10.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_10.Location = New System.Drawing.Point(596, 12)
        Me.lbl_Status_10.Name = "lbl_Status_10"
        Me.lbl_Status_10.Size = New System.Drawing.Size(194, 18)
        Me.lbl_Status_10.TabIndex = 109
        Me.lbl_Status_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status10
        '
        Me.lbl_Color_Status10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status10.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status10.Location = New System.Drawing.Point(577, 15)
        Me.lbl_Color_Status10.Name = "lbl_Color_Status10"
        Me.lbl_Color_Status10.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status10.TabIndex = 108
        Me.lbl_Color_Status10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_9
        '
        Me.lbl_Status_9.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_9.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_9.Location = New System.Drawing.Point(368, 61)
        Me.lbl_Status_9.Name = "lbl_Status_9"
        Me.lbl_Status_9.Size = New System.Drawing.Size(190, 18)
        Me.lbl_Status_9.TabIndex = 107
        Me.lbl_Status_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(574, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'lbl_Color_Status9
        '
        Me.lbl_Color_Status9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status9.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status9.Location = New System.Drawing.Point(349, 63)
        Me.lbl_Color_Status9.Name = "lbl_Color_Status9"
        Me.lbl_Color_Status9.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status9.TabIndex = 106
        Me.lbl_Color_Status9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_8
        '
        Me.lbl_Status_8.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_8.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_8.Location = New System.Drawing.Point(368, 34)
        Me.lbl_Status_8.Name = "lbl_Status_8"
        Me.lbl_Status_8.Size = New System.Drawing.Size(183, 18)
        Me.lbl_Status_8.TabIndex = 105
        Me.lbl_Status_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status8
        '
        Me.lbl_Color_Status8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status8.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status8.Location = New System.Drawing.Point(349, 37)
        Me.lbl_Color_Status8.Name = "lbl_Color_Status8"
        Me.lbl_Color_Status8.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status8.TabIndex = 104
        Me.lbl_Color_Status8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_7
        '
        Me.lbl_Status_7.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_7.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_7.Location = New System.Drawing.Point(368, 10)
        Me.lbl_Status_7.Name = "lbl_Status_7"
        Me.lbl_Status_7.Size = New System.Drawing.Size(183, 18)
        Me.lbl_Status_7.TabIndex = 103
        Me.lbl_Status_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status7
        '
        Me.lbl_Color_Status7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status7.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status7.Location = New System.Drawing.Point(349, 13)
        Me.lbl_Color_Status7.Name = "lbl_Color_Status7"
        Me.lbl_Color_Status7.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status7.TabIndex = 102
        Me.lbl_Color_Status7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_4
        '
        Me.lbl_Status_4.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_4.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_4.Location = New System.Drawing.Point(197, 10)
        Me.lbl_Status_4.Name = "lbl_Status_4"
        Me.lbl_Status_4.Size = New System.Drawing.Size(146, 18)
        Me.lbl_Status_4.TabIndex = 101
        Me.lbl_Status_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_5
        '
        Me.lbl_Status_5.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_5.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_5.Location = New System.Drawing.Point(197, 33)
        Me.lbl_Status_5.Name = "lbl_Status_5"
        Me.lbl_Status_5.Size = New System.Drawing.Size(146, 18)
        Me.lbl_Status_5.TabIndex = 100
        Me.lbl_Status_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_6
        '
        Me.lbl_Status_6.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_6.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_6.Location = New System.Drawing.Point(197, 60)
        Me.lbl_Status_6.Name = "lbl_Status_6"
        Me.lbl_Status_6.Size = New System.Drawing.Size(146, 18)
        Me.lbl_Status_6.TabIndex = 99
        Me.lbl_Status_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_3
        '
        Me.lbl_Status_3.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_3.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_3.Location = New System.Drawing.Point(22, 61)
        Me.lbl_Status_3.Name = "lbl_Status_3"
        Me.lbl_Status_3.Size = New System.Drawing.Size(151, 18)
        Me.lbl_Status_3.TabIndex = 98
        Me.lbl_Status_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_2
        '
        Me.lbl_Status_2.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_2.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_2.Location = New System.Drawing.Point(24, 36)
        Me.lbl_Status_2.Name = "lbl_Status_2"
        Me.lbl_Status_2.Size = New System.Drawing.Size(151, 18)
        Me.lbl_Status_2.TabIndex = 97
        Me.lbl_Status_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Status_1
        '
        Me.lbl_Status_1.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_1.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_1.Location = New System.Drawing.Point(25, 11)
        Me.lbl_Status_1.Name = "lbl_Status_1"
        Me.lbl_Status_1.Size = New System.Drawing.Size(151, 18)
        Me.lbl_Status_1.TabIndex = 91
        Me.lbl_Status_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Status6
        '
        Me.lbl_Color_Status6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Status6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Status6.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Status6.Location = New System.Drawing.Point(178, 62)
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
        Me.lbl_Color_Status1.Location = New System.Drawing.Point(6, 15)
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
        Me.lbl_Color_Status2.Location = New System.Drawing.Point(6, 39)
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
        Me.lbl_Color_Status3.Location = New System.Drawing.Point(6, 63)
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
        Me.lbl_Color_Status4.Location = New System.Drawing.Point(178, 13)
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
        Me.lbl_Color_Status5.Location = New System.Drawing.Point(178, 35)
        Me.lbl_Color_Status5.Name = "lbl_Color_Status5"
        Me.lbl_Color_Status5.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Status5.TabIndex = 95
        Me.lbl_Color_Status5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grb_Defeulf
        '
        Me.grb_Defeulf.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.grb_Defeulf.Controls.Add(Me.lbl_Status_False)
        Me.grb_Defeulf.Controls.Add(Me.lbl_Color_False)
        Me.grb_Defeulf.Controls.Add(Me.lbl_Status_Red)
        Me.grb_Defeulf.Controls.Add(Me.lbl_Color_Green)
        Me.grb_Defeulf.Controls.Add(Me.lbl_Color_Red)
        Me.grb_Defeulf.Controls.Add(Me.lbl_Status_Green)
        Me.grb_Defeulf.Location = New System.Drawing.Point(9, 704)
        Me.grb_Defeulf.Name = "grb_Defeulf"
        Me.grb_Defeulf.Size = New System.Drawing.Size(298, 81)
        Me.grb_Defeulf.TabIndex = 105
        Me.grb_Defeulf.TabStop = False
        '
        'lbl_Status_False
        '
        Me.lbl_Status_False.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_False.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_False.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_False.Location = New System.Drawing.Point(31, 56)
        Me.lbl_Status_False.Name = "lbl_Status_False"
        Me.lbl_Status_False.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_False.TabIndex = 97
        Me.lbl_Status_False.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_False
        '
        Me.lbl_Color_False.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_False.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_False.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_False.Location = New System.Drawing.Point(8, 59)
        Me.lbl_Color_False.Name = "lbl_Color_False"
        Me.lbl_Color_False.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_False.TabIndex = 102
        Me.lbl_Color_False.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_Red
        '
        Me.lbl_Status_Red.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_Red.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_Red.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_Red.Location = New System.Drawing.Point(31, 34)
        Me.lbl_Status_Red.Name = "lbl_Status_Red"
        Me.lbl_Status_Red.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_Red.TabIndex = 90
        Me.lbl_Status_Red.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Color_Green
        '
        Me.lbl_Color_Green.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Green.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Green.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Green.Location = New System.Drawing.Point(8, 13)
        Me.lbl_Color_Green.Name = "lbl_Color_Green"
        Me.lbl_Color_Green.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Green.TabIndex = 87
        Me.lbl_Color_Green.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Color_Red
        '
        Me.lbl_Color_Red.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_Color_Red.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Color_Red.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Color_Red.Location = New System.Drawing.Point(8, 37)
        Me.lbl_Color_Red.Name = "lbl_Color_Red"
        Me.lbl_Color_Red.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Color_Red.TabIndex = 88
        Me.lbl_Color_Red.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Status_Green
        '
        Me.lbl_Status_Green.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status_Green.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status_Green.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_Green.Location = New System.Drawing.Point(31, 10)
        Me.lbl_Status_Green.Name = "lbl_Status_Green"
        Me.lbl_Status_Green.Size = New System.Drawing.Size(261, 18)
        Me.lbl_Status_Green.TabIndex = 89
        Me.lbl_Status_Green.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmNew_Display_Over_HH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1312, 742)
        Me.Controls.Add(Me.PanelEx1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNew_Display_Over_HH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "สถานะลานจอดรถ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Pl_detail.ResumeLayout(False)
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grb_Defeulf.ResumeLayout(False)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grb_Defeulf As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Status_False As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_False As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_Red As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Green As System.Windows.Forms.Label
    Friend WithEvents lbl_Color_Red As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_Green As System.Windows.Forms.Label
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
    Friend WithEvents Lb_status_lot_avalaible As System.Windows.Forms.Label
    Friend WithEvents Lb_status_lot_use As System.Windows.Forms.Label
    Friend WithEvents Lb_status_lot_all As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
