<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mas_Station_Company
     Inherits DevComponents.DotNetBar.Office2007Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mas_Station_Company))
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.txt_Tel = New System.Windows.Forms.TextBox()
        Me.txt_Fax = New System.Windows.Forms.TextBox()
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.save2 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.Opg_Logo = New System.Windows.Forms.OpenFileDialog()
        Me.msk_Tax_ID = New System.Windows.Forms.MaskedTextBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.txt_Address = New System.Windows.Forms.TextBox()
        Me.lsv_Mas_Status = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rdo_T = New System.Windows.Forms.RadioButton()
        Me.rdo_F = New System.Windows.Forms.RadioButton()
        Me.lbl_ID = New System.Windows.Forms.Label()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_Slip = New System.Windows.Forms.Button()
        Me.Pic_Slip = New System.Windows.Forms.PictureBox()
        Me.btn_Logo = New System.Windows.Forms.Button()
        Me.btn_Back_Ground = New System.Windows.Forms.Button()
        Me.Pic_Logo = New System.Windows.Forms.PictureBox()
        Me.Pic_Back_Ground = New System.Windows.Forms.PictureBox()
        Me.Opg_Back = New System.Windows.Forms.OpenFileDialog()
        Me.btn_Del = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.edit2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.Pic_Slip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Back_Ground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Enabled = False
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 51)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(147, 23)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "ชื่อ "
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LinkLabel3
        '
        Me.LinkLabel3.Enabled = False
        Me.LinkLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LinkLabel3.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(12, 152)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(147, 23)
        Me.LinkLabel3.TabIndex = 2
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "เบอร์โทรศัพท์"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LinkLabel7
        '
        Me.LinkLabel7.Enabled = False
        Me.LinkLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LinkLabel7.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel7.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel7.Location = New System.Drawing.Point(12, 183)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(147, 23)
        Me.LinkLabel7.TabIndex = 6
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "แฟ็กซ์"
        Me.LinkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LinkLabel8
        '
        Me.LinkLabel8.Enabled = False
        Me.LinkLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LinkLabel8.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel8.Location = New System.Drawing.Point(12, 82)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(147, 23)
        Me.LinkLabel8.TabIndex = 7
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "ที่อยู่"
        Me.LinkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Name
        '
        Me.txt_Name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Name.Location = New System.Drawing.Point(169, 51)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(512, 22)
        Me.txt_Name.TabIndex = 1
        '
        'txt_Tel
        '
        Me.txt_Tel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Tel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Tel.Location = New System.Drawing.Point(169, 152)
        Me.txt_Tel.Name = "txt_Tel"
        Me.txt_Tel.Size = New System.Drawing.Size(512, 22)
        Me.txt_Tel.TabIndex = 6
        '
        'txt_Fax
        '
        Me.txt_Fax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Fax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Fax.Location = New System.Drawing.Point(169, 183)
        Me.txt_Fax.Name = "txt_Fax"
        Me.txt_Fax.Size = New System.Drawing.Size(512, 22)
        Me.txt_Fax.TabIndex = 7
        '
        'btn_Edit
        '
        Me.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit.ImageIndex = 0
        Me.btn_Edit.ImageList = Me.img_Edit
        Me.btn_Edit.Location = New System.Drawing.Point(268, 374)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(97, 53)
        Me.btn_Edit.TabIndex = 9
        Me.btn_Edit.Text = "แก้ไข"
        Me.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Cancel.ImageIndex = 1
        Me.Btn_Cancel.ImageList = Me.save2
        Me.Btn_Cancel.Location = New System.Drawing.Point(478, 374)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(97, 53)
        Me.Btn_Cancel.TabIndex = 10
        Me.Btn_Cancel.Text = "ยกเลิก"
        Me.Btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'save2
        '
        Me.save2.ImageStream = CType(resources.GetObject("save2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.save2.TransparentColor = System.Drawing.Color.Transparent
        Me.save2.Images.SetKeyName(0, "zippo 050.png")
        Me.save2.Images.SetKeyName(1, "Wrong.png")
        Me.save2.Images.SetKeyName(2, "223.png")
        '
        'btn_Close
        '
        Me.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Close.ForeColor = System.Drawing.Color.Red
        Me.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Close.ImageIndex = 2
        Me.btn_Close.ImageList = Me.save2
        Me.btn_Close.Location = New System.Drawing.Point(583, 374)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(97, 53)
        Me.btn_Close.TabIndex = 11
        Me.btn_Close.Text = "ปิด"
        Me.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'msk_Tax_ID
        '
        Me.msk_Tax_ID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.msk_Tax_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.msk_Tax_ID.Location = New System.Drawing.Point(169, 119)
        Me.msk_Tax_ID.Name = "msk_Tax_ID"
        Me.msk_Tax_ID.Size = New System.Drawing.Size(123, 22)
        Me.msk_Tax_ID.TabIndex = 5
        '
        'LinkLabel5
        '
        Me.LinkLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LinkLabel5.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel5.Location = New System.Drawing.Point(12, 119)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(147, 23)
        Me.LinkLabel5.TabIndex = 12
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "เลขประจำตัวผู้เสียภาษี"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Address
        '
        Me.txt_Address.AcceptsTab = True
        Me.txt_Address.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Address.Location = New System.Drawing.Point(169, 82)
        Me.txt_Address.Name = "txt_Address"
        Me.txt_Address.Size = New System.Drawing.Size(512, 22)
        Me.txt_Address.TabIndex = 2
        '
        'lsv_Mas_Status
        '
        Me.lsv_Mas_Status.BackColor = System.Drawing.Color.White
        Me.lsv_Mas_Status.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsv_Mas_Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Mas_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lsv_Mas_Status.FullRowSelect = True
        Me.lsv_Mas_Status.GridLines = True
        Me.lsv_Mas_Status.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Mas_Status.HideSelection = False
        Me.lsv_Mas_Status.Location = New System.Drawing.Point(12, 213)
        Me.lsv_Mas_Status.Name = "lsv_Mas_Status"
        Me.lsv_Mas_Status.Size = New System.Drawing.Size(669, 147)
        Me.lsv_Mas_Status.TabIndex = 25
        Me.lsv_Mas_Status.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_Status.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "       รหัส"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                                                             ชื่อ"
        Me.ColumnHeader2.Width = 540
        '
        'rdo_T
        '
        Me.rdo_T.AutoSize = True
        Me.rdo_T.Checked = True
        Me.rdo_T.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdo_T.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_T.ForeColor = System.Drawing.Color.Green
        Me.rdo_T.Location = New System.Drawing.Point(298, 118)
        Me.rdo_T.Name = "rdo_T"
        Me.rdo_T.Size = New System.Drawing.Size(66, 22)
        Me.rdo_T.TabIndex = 26
        Me.rdo_T.TabStop = True
        Me.rdo_T.Text = "ใช้งาน"
        Me.rdo_T.UseVisualStyleBackColor = True
        '
        'rdo_F
        '
        Me.rdo_F.AutoSize = True
        Me.rdo_F.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdo_F.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_F.ForeColor = System.Drawing.Color.Red
        Me.rdo_F.Location = New System.Drawing.Point(374, 118)
        Me.rdo_F.Name = "rdo_F"
        Me.rdo_F.Size = New System.Drawing.Size(66, 22)
        Me.rdo_F.TabIndex = 27
        Me.rdo_F.Text = "ยกเลิก"
        Me.rdo_F.UseVisualStyleBackColor = True
        '
        'lbl_ID
        '
        Me.lbl_ID.BackColor = System.Drawing.Color.Black
        Me.lbl_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_ID.ForeColor = System.Drawing.Color.Red
        Me.lbl_ID.Location = New System.Drawing.Point(170, 9)
        Me.lbl_ID.Name = "lbl_ID"
        Me.lbl_ID.Size = New System.Drawing.Size(135, 33)
        Me.lbl_ID.TabIndex = 28
        Me.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel6
        '
        Me.LinkLabel6.Enabled = False
        Me.LinkLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LinkLabel6.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel6.Location = New System.Drawing.Point(12, 14)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(147, 23)
        Me.LinkLabel6.TabIndex = 29
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "รหัส"
        Me.LinkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Slip)
        Me.GroupBox2.Controls.Add(Me.Pic_Slip)
        Me.GroupBox2.Controls.Add(Me.btn_Logo)
        Me.GroupBox2.Controls.Add(Me.btn_Back_Ground)
        Me.GroupBox2.Controls.Add(Me.Pic_Logo)
        Me.GroupBox2.Controls.Add(Me.Pic_Back_Ground)
        Me.GroupBox2.Location = New System.Drawing.Point(686, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(378, 376)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        '
        'btn_Slip
        '
        Me.btn_Slip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Slip.Enabled = False
        Me.btn_Slip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Slip.ForeColor = System.Drawing.Color.Blue
        Me.btn_Slip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Slip.ImageIndex = 0
        Me.btn_Slip.Location = New System.Drawing.Point(441, 318)
        Me.btn_Slip.Name = "btn_Slip"
        Me.btn_Slip.Size = New System.Drawing.Size(106, 50)
        Me.btn_Slip.TabIndex = 15
        Me.btn_Slip.Text = "หัวใบเสร็จ"
        Me.btn_Slip.UseVisualStyleBackColor = True
        '
        'Pic_Slip
        '
        Me.Pic_Slip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_Slip.Location = New System.Drawing.Point(459, 16)
        Me.Pic_Slip.Name = "Pic_Slip"
        Me.Pic_Slip.Size = New System.Drawing.Size(89, 293)
        Me.Pic_Slip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Slip.TabIndex = 14
        Me.Pic_Slip.TabStop = False
        '
        'btn_Logo
        '
        Me.btn_Logo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Logo.Enabled = False
        Me.btn_Logo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Logo.ForeColor = System.Drawing.Color.Blue
        Me.btn_Logo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Logo.ImageIndex = 0
        Me.btn_Logo.Location = New System.Drawing.Point(192, 318)
        Me.btn_Logo.Name = "btn_Logo"
        Me.btn_Logo.Size = New System.Drawing.Size(174, 50)
        Me.btn_Logo.TabIndex = 13
        Me.btn_Logo.Text = "โลโก้"
        Me.btn_Logo.UseVisualStyleBackColor = True
        '
        'btn_Back_Ground
        '
        Me.btn_Back_Ground.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Back_Ground.Enabled = False
        Me.btn_Back_Ground.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Back_Ground.ForeColor = System.Drawing.Color.Blue
        Me.btn_Back_Ground.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Back_Ground.ImageIndex = 0
        Me.btn_Back_Ground.Location = New System.Drawing.Point(10, 318)
        Me.btn_Back_Ground.Name = "btn_Back_Ground"
        Me.btn_Back_Ground.Size = New System.Drawing.Size(176, 50)
        Me.btn_Back_Ground.TabIndex = 12
        Me.btn_Back_Ground.Text = "พื้นหลัง"
        Me.btn_Back_Ground.UseVisualStyleBackColor = True
        '
        'Pic_Logo
        '
        Me.Pic_Logo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_Logo.Location = New System.Drawing.Point(190, 16)
        Me.Pic_Logo.Name = "Pic_Logo"
        Me.Pic_Logo.Size = New System.Drawing.Size(176, 293)
        Me.Pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Logo.TabIndex = 1
        Me.Pic_Logo.TabStop = False
        '
        'Pic_Back_Ground
        '
        Me.Pic_Back_Ground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic_Back_Ground.Location = New System.Drawing.Point(10, 16)
        Me.Pic_Back_Ground.Name = "Pic_Back_Ground"
        Me.Pic_Back_Ground.Size = New System.Drawing.Size(176, 293)
        Me.Pic_Back_Ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Back_Ground.TabIndex = 0
        Me.Pic_Back_Ground.TabStop = False
        '
        'btn_Del
        '
        Me.btn_Del.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Del.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Del.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Del.ImageIndex = 0
        Me.btn_Del.ImageList = Me.img_Delete
        Me.btn_Del.Location = New System.Drawing.Point(373, 374)
        Me.btn_Del.Name = "btn_Del"
        Me.btn_Del.Size = New System.Drawing.Size(97, 53)
        Me.btn_Del.TabIndex = 31
        Me.btn_Del.Text = "ลบ"
        Me.btn_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Del.UseVisualStyleBackColor = True
        '
        'img_Delete
        '
        Me.img_Delete.ImageStream = CType(resources.GetObject("img_Delete.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Delete.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Delete.Images.SetKeyName(0, "Alpha Dista Icon 050769.png")
        '
        'btn_Add
        '
        Me.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add.ImageIndex = 0
        Me.btn_Add.ImageList = Me.save2
        Me.btn_Add.Location = New System.Drawing.Point(163, 374)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(97, 53)
        Me.btn_Add.TabIndex = 8
        Me.btn_Add.Text = "เพิ่ม"
        Me.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add.UseCompatibleTextRendering = True
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'img_Pic
        '
        Me.img_Pic.ImageStream = CType(resources.GetObject("img_Pic.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Pic.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Pic.Images.SetKeyName(0, "Applications.png")
        '
        'img_Save
        '
        Me.img_Save.ImageStream = CType(resources.GetObject("img_Save.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Save.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Save.Images.SetKeyName(0, "Add.png")
        '
        'edit2
        '
        Me.edit2.ImageStream = CType(resources.GetObject("edit2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.edit2.TransparentColor = System.Drawing.Color.Transparent
        Me.edit2.Images.SetKeyName(0, "Save.png")
        '
        'Mas_Station_Company
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1028, 441)
        Me.Controls.Add(Me.btn_Del)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LinkLabel6)
        Me.Controls.Add(Me.lbl_ID)
        Me.Controls.Add(Me.rdo_F)
        Me.Controls.Add(Me.rdo_T)
        Me.Controls.Add(Me.lsv_Mas_Status)
        Me.Controls.Add(Me.txt_Address)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.msk_Tax_ID)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.txt_Fax)
        Me.Controls.Add(Me.txt_Tel)
        Me.Controls.Add(Me.txt_Name)
        Me.Controls.Add(Me.LinkLabel8)
        Me.Controls.Add(Me.LinkLabel7)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Mas_Station_Company"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "7000"
        Me.Text = "สถานประกอบการ"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Pic_Slip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Back_Ground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Tel As System.Windows.Forms.TextBox
    Friend WithEvents txt_Fax As System.Windows.Forms.TextBox
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Close As System.Windows.Forms.Button
    Friend WithEvents Opg_Logo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents msk_Tax_ID As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents txt_Address As System.Windows.Forms.TextBox
    Friend WithEvents lsv_Mas_Status As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents rdo_T As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_F As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_ID As System.Windows.Forms.Label
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Logo As System.Windows.Forms.Button
    Friend WithEvents btn_Back_Ground As System.Windows.Forms.Button
    Friend WithEvents Pic_Logo As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Back_Ground As System.Windows.Forms.PictureBox
    Friend WithEvents Opg_Back As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_Del As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents save2 As System.Windows.Forms.ImageList
    Friend WithEvents edit2 As System.Windows.Forms.ImageList
    Friend WithEvents btn_Slip As System.Windows.Forms.Button
    Friend WithEvents Pic_Slip As System.Windows.Forms.PictureBox

End Class
