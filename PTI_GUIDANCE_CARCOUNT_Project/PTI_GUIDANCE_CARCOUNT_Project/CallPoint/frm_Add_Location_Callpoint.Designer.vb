<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Add_Location_Callpoint
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Add_Location_Callpoint))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Pic_ID_2 = New System.Windows.Forms.PictureBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.PanelDockContainer1 = New DevComponents.DotNetBar.PanelDockContainer()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.DockContainerItem1 = New DevComponents.DotNetBar.DockContainerItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Cmb_ZCU = New System.Windows.Forms.ComboBox()
        Me.BalloonTip1 = New DevComponents.DotNetBar.BalloonTip()
        Me.DotNetBarManager1 = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grb_Defeulf = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_ZCU2 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_Pre = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txt_Next = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Down = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_Up = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.img_Close = New System.Windows.Forms.ImageList(Me.components)
        Me.TimerRealtime = New System.Windows.Forms.Timer(Me.components)
        Me.T_Alert = New System.Windows.Forms.Timer(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockSite3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        Me.PanelDockContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grb_Defeulf.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Blank Badge Green.ico")
        Me.ImageList1.Images.SetKeyName(1, "Blank Disc Red.ico")
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite1.Location = New System.Drawing.Point(0, 98)
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.Size = New System.Drawing.Size(0, 643)
        Me.DockSite1.TabIndex = 145
        Me.DockSite1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(50, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(110, 20)
        Me.TextBox1.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "ID : "
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
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(314, 15)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 34)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "ลบ"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite2.Location = New System.Drawing.Point(1362, 98)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(0, 643)
        Me.DockSite2.TabIndex = 146
        Me.DockSite2.TabStop = False
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite3.Controls.Add(Me.Bar1)
        Me.DockSite3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer(New DevComponents.DotNetBar.DocumentBaseContainer() {CType(New DevComponents.DotNetBar.DocumentBarContainer(Me.Bar1, 1362, 95), DevComponents.DotNetBar.DocumentBaseContainer)}, DevComponents.DotNetBar.eOrientation.Vertical)
        Me.DockSite3.Location = New System.Drawing.Point(0, 0)
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.Size = New System.Drawing.Size(1362, 98)
        Me.DockSite3.TabIndex = 147
        Me.DockSite3.TabStop = False
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "DotNetBar Bar (Bar1)"
        Me.Bar1.AccessibleName = "DotNetBar Bar"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar1.AutoSyncBarCaption = True
        Me.Bar1.CloseSingleTab = True
        Me.Bar1.Controls.Add(Me.PanelDockContainer1)
        Me.Bar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.DockContainerItem1})
        Me.Bar1.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1362, 95)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.Bar1.TabIndex = 0
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "DockContainerItem1"
        '
        'PanelDockContainer1
        '
        Me.PanelDockContainer1.Controls.Add(Me.RadioButton1)
        Me.PanelDockContainer1.Location = New System.Drawing.Point(3, 23)
        Me.PanelDockContainer1.Name = "PanelDockContainer1"
        Me.PanelDockContainer1.Size = New System.Drawing.Size(1356, 69)
        Me.PanelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.PanelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.PanelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.PanelDockContainer1.Style.GradientAngle = 90
        Me.PanelDockContainer1.TabIndex = 0
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Angsana New", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(16, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(108, 33)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = False
        Me.RadioButton1.Visible = False
        '
        'DockContainerItem1
        '
        Me.DockContainerItem1.Control = Me.PanelDockContainer1
        Me.DockContainerItem1.Name = "DockContainerItem1"
        Me.DockContainerItem1.Text = "DockContainerItem1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Cmb_ZCU)
        Me.Panel1.Location = New System.Drawing.Point(534, 544)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 65)
        Me.Panel1.TabIndex = 13
        Me.Panel1.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "ติดตั้งที่ ZCU"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(229, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(79, 35)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "เพิ่ม"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Cmb_ZCU
        '
        Me.Cmb_ZCU.FormattingEnabled = True
        Me.Cmb_ZCU.Location = New System.Drawing.Point(32, 23)
        Me.Cmb_ZCU.Name = "Cmb_ZCU"
        Me.Cmb_ZCU.Size = New System.Drawing.Size(191, 21)
        Me.Cmb_ZCU.TabIndex = 108
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
        Me.DotNetBarManager1.ParentForm = Nothing
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
        Me.DockSite4.TabIndex = 148
        Me.DockSite4.TabStop = False
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite8.Location = New System.Drawing.Point(0, 741)
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.Size = New System.Drawing.Size(1362, 0)
        Me.DockSite8.TabIndex = 152
        Me.DockSite8.TabStop = False
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite5.Location = New System.Drawing.Point(0, 0)
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.Size = New System.Drawing.Size(0, 741)
        Me.DockSite5.TabIndex = 149
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite6.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite6.Location = New System.Drawing.Point(1362, 0)
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.Size = New System.Drawing.Size(0, 741)
        Me.DockSite6.TabIndex = 150
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite7.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite7.Location = New System.Drawing.Point(0, 0)
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.Size = New System.Drawing.Size(1362, 0)
        Me.DockSite7.TabIndex = 151
        Me.DockSite7.TabStop = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(286, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "ตำแหน่ง :"
        '
        'grb_Defeulf
        '
        Me.grb_Defeulf.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.grb_Defeulf.Controls.Add(Me.Label5)
        Me.grb_Defeulf.Controls.Add(Me.Label3)
        Me.grb_Defeulf.Controls.Add(Me.Label1)
        Me.grb_Defeulf.Location = New System.Drawing.Point(9, 630)
        Me.grb_Defeulf.Name = "grb_Defeulf"
        Me.grb_Defeulf.Size = New System.Drawing.Size(298, 81)
        Me.grb_Defeulf.TabIndex = 105
        Me.grb_Defeulf.TabStop = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(286, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "รหัสอาคาร :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "รหัสอุปกรณ์ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "แสดงเฉพาะ ZCU"
        '
        'Cmb_ZCU2
        '
        Me.Cmb_ZCU2.FormattingEnabled = True
        Me.Cmb_ZCU2.Location = New System.Drawing.Point(105, 17)
        Me.Cmb_ZCU2.Name = "Cmb_ZCU2"
        Me.Cmb_ZCU2.Size = New System.Drawing.Size(191, 21)
        Me.Cmb_ZCU2.TabIndex = 111
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(302, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(79, 24)
        Me.Button6.TabIndex = 110
        Me.Button6.Text = "แสดง"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txt_Pre)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.txt_Next)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txt_Down)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txt_Up)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(450, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(268, 73)
        Me.Panel2.TabIndex = 107
        Me.Panel2.Visible = False
        '
        'txt_Pre
        '
        Me.txt_Pre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Pre.Image = Global.PTI_GUIDANCE_CARCOUNT_Project.My.Resources.Resources.back
        Me.txt_Pre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txt_Pre.Location = New System.Drawing.Point(361, 23)
        Me.txt_Pre.Name = "txt_Pre"
        Me.txt_Pre.Size = New System.Drawing.Size(30, 30)
        Me.txt_Pre.TabIndex = 7
        Me.txt_Pre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_Pre.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(17, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(108, 33)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "SET"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(483, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 57)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txt_Next
        '
        Me.txt_Next.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Next.Image = Global.PTI_GUIDANCE_CARCOUNT_Project.My.Resources.Resources._next
        Me.txt_Next.Location = New System.Drawing.Point(426, 22)
        Me.txt_Next.Name = "txt_Next"
        Me.txt_Next.Size = New System.Drawing.Size(30, 30)
        Me.txt_Next.TabIndex = 9
        Me.txt_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_Next.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(217, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(173, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "ตำแหน่ง Mouse"
        '
        'txt_Down
        '
        Me.txt_Down.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Down.Image = Global.PTI_GUIDANCE_CARCOUNT_Project.My.Resources.Resources.down
        Me.txt_Down.Location = New System.Drawing.Point(393, 49)
        Me.txt_Down.Name = "txt_Down"
        Me.txt_Down.Size = New System.Drawing.Size(30, 30)
        Me.txt_Down.TabIndex = 10
        Me.txt_Down.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_Down.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(130, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 24)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "กำหนดจุดเริ่มต้น"
        '
        'txt_Up
        '
        Me.txt_Up.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txt_Up.Image = Global.PTI_GUIDANCE_CARCOUNT_Project.My.Resources.Resources.up24
        Me.txt_Up.Location = New System.Drawing.Point(393, 2)
        Me.txt_Up.Name = "txt_Up"
        Me.txt_Up.Size = New System.Drawing.Size(30, 30)
        Me.txt_Up.TabIndex = 8
        Me.txt_Up.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txt_Up.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(17, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 33)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "move"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(214, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ตำแหน่ง Mouse"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(130, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 24)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ตำแหน่ง Mouse"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Cmb_ZCU2)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Location = New System.Drawing.Point(313, 628)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(970, 115)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.GroupBox3)
        Me.PanelEx2.Controls.Add(Me.grb_Defeulf)
        Me.PanelEx2.Controls.Add(Me.Panel1)
        Me.PanelEx2.Controls.Add(Me.Pic_ID_2)
        Me.PanelEx2.Location = New System.Drawing.Point(12, 12)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(1288, 718)
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
        Me.PanelEx1.Location = New System.Drawing.Point(0, 98)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1362, 643)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.Honeydew
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.PaleTurquoise
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 144
        Me.PanelEx1.Text = "PanelEx1"
        '
        'frm_Add_Location_Callpoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Add_Location_Callpoint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Add_Location_Callpoint"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Pic_ID_2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockSite3.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        Me.PanelDockContainer1.ResumeLayout(False)
        Me.PanelDockContainer1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grb_Defeulf.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Pic_ID_2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents PanelDockContainer1 As DevComponents.DotNetBar.PanelDockContainer
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents DockContainerItem1 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Cmb_ZCU As System.Windows.Forms.ComboBox
    Friend WithEvents BalloonTip1 As DevComponents.DotNetBar.BalloonTip
    Friend WithEvents DotNetBarManager1 As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grb_Defeulf As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ZCU2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_Pre As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txt_Next As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Down As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_Up As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents img_Close As System.Windows.Forms.ImageList
    Friend WithEvents TimerRealtime As System.Windows.Forms.Timer
    Friend WithEvents T_Alert As System.Windows.Forms.Timer
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
End Class
