<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mas_Status_Alarm
    Inherits DevComponents.DotNetBar.Office2007Form  ' Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mas_Status_Alarm))
        Me.grb_Type = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_HH_Stop = New System.Windows.Forms.TextBox()
        Me.txt_HH_Start = New System.Windows.Forms.TextBox()
        Me.txt_MM_Stop = New System.Windows.Forms.TextBox()
        Me.txt_MM_Start = New System.Windows.Forms.TextBox()
        Me.lbl_M_Stop = New System.Windows.Forms.Label()
        Me.lbl_H_Stop = New System.Windows.Forms.Label()
        Me.lbl_T_Stop = New System.Windows.Forms.Label()
        Me.lbl_M_Start = New System.Windows.Forms.Label()
        Me.lbl_T_Status = New System.Windows.Forms.Label()
        Me.lbl_H_Start = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pic_Color = New System.Windows.Forms.PictureBox()
        Me.btn_Color = New System.Windows.Forms.Button()
        Me.lbl_Color = New System.Windows.Forms.Label()
        Me.lbl_Back_Color = New System.Windows.Forms.Label()
        Me.lbl_Mas_Alam = New System.Windows.Forms.Label()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.txt_Mas_Alam = New System.Windows.Forms.TextBox()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.lsv_Mas_Alam = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grb_Search = New System.Windows.Forms.GroupBox()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit_Alam = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Add_Alam = New System.Windows.Forms.Button()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.DlgCollor = New System.Windows.Forms.ColorDialog()
        Me.grb_Type.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pic_Color, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'grb_Type
        '
        Me.grb_Type.Controls.Add(Me.GroupBox4)
        Me.grb_Type.Controls.Add(Me.GroupBox3)
        Me.grb_Type.Controls.Add(Me.lbl_Mas_Alam)
        Me.grb_Type.Controls.Add(Me.lbl_T_ID)
        Me.grb_Type.Controls.Add(Me.txt_Mas_Alam)
        Me.grb_Type.Controls.Add(Me.lbl_Name)
        Me.grb_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grb_Type.ForeColor = System.Drawing.Color.Black
        Me.grb_Type.Location = New System.Drawing.Point(14, 88)
        Me.grb_Type.Name = "grb_Type"
        Me.grb_Type.Size = New System.Drawing.Size(432, 179)
        Me.grb_Type.TabIndex = 25
        Me.grb_Type.TabStop = False
        Me.grb_Type.Text = "ประเภทการจอดรถ"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_HH_Stop)
        Me.GroupBox4.Controls.Add(Me.txt_HH_Start)
        Me.GroupBox4.Controls.Add(Me.txt_MM_Stop)
        Me.GroupBox4.Controls.Add(Me.txt_MM_Start)
        Me.GroupBox4.Controls.Add(Me.lbl_M_Stop)
        Me.GroupBox4.Controls.Add(Me.lbl_H_Stop)
        Me.GroupBox4.Controls.Add(Me.lbl_T_Stop)
        Me.GroupBox4.Controls.Add(Me.lbl_M_Start)
        Me.GroupBox4.Controls.Add(Me.lbl_T_Status)
        Me.GroupBox4.Controls.Add(Me.lbl_H_Start)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(1, 85)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(305, 93)
        Me.GroupBox4.TabIndex = 36
        Me.GroupBox4.TabStop = False
        '
        'txt_HH_Stop
        '
        Me.txt_HH_Stop.Location = New System.Drawing.Point(95, 54)
        Me.txt_HH_Stop.Name = "txt_HH_Stop"
        Me.txt_HH_Stop.Size = New System.Drawing.Size(48, 22)
        Me.txt_HH_Stop.TabIndex = 12
        Me.txt_HH_Stop.Text = "0"
        '
        'txt_HH_Start
        '
        Me.txt_HH_Start.Location = New System.Drawing.Point(95, 20)
        Me.txt_HH_Start.Name = "txt_HH_Start"
        Me.txt_HH_Start.Size = New System.Drawing.Size(48, 22)
        Me.txt_HH_Start.TabIndex = 10
        Me.txt_HH_Start.Text = "0"
        '
        'txt_MM_Stop
        '
        Me.txt_MM_Stop.Location = New System.Drawing.Point(195, 54)
        Me.txt_MM_Stop.Name = "txt_MM_Stop"
        Me.txt_MM_Stop.Size = New System.Drawing.Size(48, 22)
        Me.txt_MM_Stop.TabIndex = 13
        Me.txt_MM_Stop.Text = "0"
        '
        'txt_MM_Start
        '
        Me.txt_MM_Start.Location = New System.Drawing.Point(195, 20)
        Me.txt_MM_Start.Name = "txt_MM_Start"
        Me.txt_MM_Start.Size = New System.Drawing.Size(48, 22)
        Me.txt_MM_Start.TabIndex = 11
        Me.txt_MM_Start.Text = "0"
        '
        'lbl_M_Stop
        '
        Me.lbl_M_Stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_M_Stop.ForeColor = System.Drawing.Color.Black
        Me.lbl_M_Stop.Location = New System.Drawing.Point(247, 57)
        Me.lbl_M_Stop.Name = "lbl_M_Stop"
        Me.lbl_M_Stop.Size = New System.Drawing.Size(52, 16)
        Me.lbl_M_Stop.TabIndex = 40
        Me.lbl_M_Stop.Text = "นาที"
        '
        'lbl_H_Stop
        '
        Me.lbl_H_Stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_H_Stop.ForeColor = System.Drawing.Color.Black
        Me.lbl_H_Stop.Location = New System.Drawing.Point(147, 56)
        Me.lbl_H_Stop.Name = "lbl_H_Stop"
        Me.lbl_H_Stop.Size = New System.Drawing.Size(42, 16)
        Me.lbl_H_Stop.TabIndex = 38
        Me.lbl_H_Stop.Text = "ชม."
        '
        'lbl_T_Stop
        '
        Me.lbl_T_Stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_Stop.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_Stop.Location = New System.Drawing.Point(15, 54)
        Me.lbl_T_Stop.Name = "lbl_T_Stop"
        Me.lbl_T_Stop.Size = New System.Drawing.Size(72, 16)
        Me.lbl_T_Stop.TabIndex = 36
        Me.lbl_T_Stop.Text = "เวลาสิ้นสุด"
        Me.lbl_T_Stop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_M_Start
        '
        Me.lbl_M_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_M_Start.ForeColor = System.Drawing.Color.Black
        Me.lbl_M_Start.Location = New System.Drawing.Point(247, 24)
        Me.lbl_M_Start.Name = "lbl_M_Start"
        Me.lbl_M_Start.Size = New System.Drawing.Size(52, 16)
        Me.lbl_M_Start.TabIndex = 35
        Me.lbl_M_Start.Text = "นาที"
        '
        'lbl_T_Status
        '
        Me.lbl_T_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_Status.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_Status.Location = New System.Drawing.Point(15, 21)
        Me.lbl_T_Status.Name = "lbl_T_Status"
        Me.lbl_T_Status.Size = New System.Drawing.Size(74, 16)
        Me.lbl_T_Status.TabIndex = 32
        Me.lbl_T_Status.Text = "เวลาเริ่มต้น"
        Me.lbl_T_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_H_Start
        '
        Me.lbl_H_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_H_Start.ForeColor = System.Drawing.Color.Black
        Me.lbl_H_Start.Location = New System.Drawing.Point(147, 23)
        Me.lbl_H_Start.Name = "lbl_H_Start"
        Me.lbl_H_Start.Size = New System.Drawing.Size(42, 16)
        Me.lbl_H_Start.TabIndex = 33
        Me.lbl_H_Start.Text = "ชม."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pic_Color)
        Me.GroupBox3.Controls.Add(Me.btn_Color)
        Me.GroupBox3.Controls.Add(Me.lbl_Color)
        Me.GroupBox3.Controls.Add(Me.lbl_Back_Color)
        Me.GroupBox3.Location = New System.Drawing.Point(312, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 178)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'pic_Color
        '
        Me.pic_Color.Image = CType(resources.GetObject("pic_Color.Image"), System.Drawing.Image)
        Me.pic_Color.Location = New System.Drawing.Point(6, 14)
        Me.pic_Color.Name = "pic_Color"
        Me.pic_Color.Size = New System.Drawing.Size(108, 122)
        Me.pic_Color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Color.TabIndex = 30
        Me.pic_Color.TabStop = False
        '
        'btn_Color
        '
        Me.btn_Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Color.ForeColor = System.Drawing.Color.Blue
        Me.btn_Color.Location = New System.Drawing.Point(86, 146)
        Me.btn_Color.Name = "btn_Color"
        Me.btn_Color.Size = New System.Drawing.Size(27, 23)
        Me.btn_Color.TabIndex = 29
        Me.btn_Color.Text = "..."
        Me.btn_Color.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Color.UseVisualStyleBackColor = True
        '
        'lbl_Color
        '
        Me.lbl_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Color.ForeColor = System.Drawing.Color.Black
        Me.lbl_Color.Location = New System.Drawing.Point(6, 148)
        Me.lbl_Color.Name = "lbl_Color"
        Me.lbl_Color.Size = New System.Drawing.Size(74, 16)
        Me.lbl_Color.TabIndex = 29
        Me.lbl_Color.Text = "สี สถานะ"
        Me.lbl_Color.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Back_Color
        '
        Me.lbl_Back_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Back_Color.ImageIndex = 0
        Me.lbl_Back_Color.Location = New System.Drawing.Point(6, 16)
        Me.lbl_Back_Color.Name = "lbl_Back_Color"
        Me.lbl_Back_Color.Size = New System.Drawing.Size(95, 120)
        Me.lbl_Back_Color.TabIndex = 28
        '
        'lbl_Mas_Alam
        '
        Me.lbl_Mas_Alam.BackColor = System.Drawing.Color.Black
        Me.lbl_Mas_Alam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Mas_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Mas_Alam.ForeColor = System.Drawing.Color.Red
        Me.lbl_Mas_Alam.Location = New System.Drawing.Point(88, 27)
        Me.lbl_Mas_Alam.Name = "lbl_Mas_Alam"
        Me.lbl_Mas_Alam.Size = New System.Drawing.Size(88, 30)
        Me.lbl_Mas_Alam.TabIndex = 10
        Me.lbl_Mas_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(10, 34)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(72, 16)
        Me.lbl_T_ID.TabIndex = 6
        Me.lbl_T_ID.Text = "รหัส"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Mas_Alam
        '
        Me.txt_Mas_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Mas_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Mas_Alam.Location = New System.Drawing.Point(88, 61)
        Me.txt_Mas_Alam.Name = "txt_Mas_Alam"
        Me.txt_Mas_Alam.Size = New System.Drawing.Size(218, 22)
        Me.txt_Mas_Alam.TabIndex = 9
        '
        'lbl_Name
        '
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_Name.Location = New System.Drawing.Point(10, 64)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Name.TabIndex = 7
        Me.lbl_Name.Text = "ชื่อ"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.lsv_Mas_Alam.Location = New System.Drawing.Point(14, 273)
        Me.lsv_Mas_Alam.Name = "lsv_Mas_Alam"
        Me.lsv_Mas_Alam.Size = New System.Drawing.Size(432, 186)
        Me.lsv_Mas_Alam.TabIndex = 24
        Me.lsv_Mas_Alam.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_Alam.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = " รหัส"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                                                 ชื่อ"
        Me.ColumnHeader2.Width = 365
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
        'grb_Search
        '
        Me.grb_Search.Controls.Add(Me.txt_Search)
        Me.grb_Search.Controls.Add(Me.btn_Search)
        Me.grb_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grb_Search.ForeColor = System.Drawing.Color.Black
        Me.grb_Search.Location = New System.Drawing.Point(15, 12)
        Me.grb_Search.Name = "grb_Search"
        Me.grb_Search.Size = New System.Drawing.Size(432, 70)
        Me.grb_Search.TabIndex = 23
        Me.grb_Search.TabStop = False
        Me.grb_Search.Text = "ค้นหาข้อมูล"
        '
        'txt_Search
        '
        Me.txt_Search.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Search.Location = New System.Drawing.Point(37, 28)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(274, 22)
        Me.txt_Search.TabIndex = 2
        '
        'btn_Search
        '
        Me.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search.ForeColor = System.Drawing.Color.Black
        Me.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search.ImageIndex = 0
        Me.btn_Search.ImageList = Me.img_Search
        Me.btn_Search.Location = New System.Drawing.Point(331, 15)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(90, 49)
        Me.btn_Search.TabIndex = 1
        Me.btn_Search.Text = "ค้นหา"
        Me.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'img_Search
        '
        Me.img_Search.ImageStream = CType(resources.GetObject("img_Search.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Search.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Search.Images.SetKeyName(0, "zippo 015.png")
        '
        'btn_Delete
        '
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete.ImageIndex = 0
        Me.btn_Delete.ImageList = Me.img_Delete
        Me.btn_Delete.Location = New System.Drawing.Point(184, 476)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(82, 50)
        Me.btn_Delete.TabIndex = 22
        Me.btn_Delete.Text = "ลบ"
        Me.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'img_Delete
        '
        Me.img_Delete.ImageStream = CType(resources.GetObject("img_Delete.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Delete.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Delete.Images.SetKeyName(0, "Alpha Dista Icon 050769.png")
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel.ImageIndex = 0
        Me.btn_Cancel.ImageList = Me.img_Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(364, 476)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(82, 50)
        Me.btn_Cancel.TabIndex = 21
        Me.btn_Cancel.Text = "ยกเลิก"
        Me.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'img_Cancel
        '
        Me.img_Cancel.ImageStream = CType(resources.GetObject("img_Cancel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Cancel.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Cancel.Images.SetKeyName(0, "Applications.png")
        '
        'btn_Edit_Alam
        '
        Me.btn_Edit_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit_Alam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit_Alam.ImageIndex = 0
        Me.btn_Edit_Alam.ImageList = Me.img_Edit
        Me.btn_Edit_Alam.Location = New System.Drawing.Point(274, 476)
        Me.btn_Edit_Alam.Name = "btn_Edit_Alam"
        Me.btn_Edit_Alam.Size = New System.Drawing.Size(82, 50)
        Me.btn_Edit_Alam.TabIndex = 20
        Me.btn_Edit_Alam.Text = "แก้ไข"
        Me.btn_Edit_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit_Alam.UseVisualStyleBackColor = True
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'btn_Add_Alam
        '
        Me.btn_Add_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Alam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Alam.ImageIndex = 0
        Me.btn_Add_Alam.ImageList = Me.img_Add
        Me.btn_Add_Alam.Location = New System.Drawing.Point(94, 476)
        Me.btn_Add_Alam.Name = "btn_Add_Alam"
        Me.btn_Add_Alam.Size = New System.Drawing.Size(82, 50)
        Me.btn_Add_Alam.TabIndex = 19
        Me.btn_Add_Alam.Text = "เพิ่ม"
        Me.btn_Add_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add_Alam.UseVisualStyleBackColor = True
        '
        'img_Add
        '
        Me.img_Add.ImageStream = CType(resources.GetObject("img_Add.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Add.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Add.Images.SetKeyName(0, "Add.png")
        '
        'img_Pic
        '
        Me.img_Pic.ImageStream = CType(resources.GetObject("img_Pic.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Pic.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Pic.Images.SetKeyName(0, "zippo 036.png")
        '
        'img_Save
        '
        Me.img_Save.ImageStream = CType(resources.GetObject("img_Save.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Save.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Save.Images.SetKeyName(0, "zippo 050.png")
        '
        'img_SaveAdd
        '
        Me.img_SaveAdd.ImageStream = CType(resources.GetObject("img_SaveAdd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_SaveAdd.TransparentColor = System.Drawing.Color.Transparent
        Me.img_SaveAdd.Images.SetKeyName(0, "zippo 044.png")
        '
        'frm_Mas_Status_Alarm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(464, 538)
        Me.Controls.Add(Me.grb_Type)
        Me.Controls.Add(Me.lsv_Mas_Alam)
        Me.Controls.Add(Me.grb_Search)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit_Alam)
        Me.Controls.Add(Me.btn_Add_Alam)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Mas_Status_Alarm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ประเภทการจอดรถ"
        Me.grb_Type.ResumeLayout(False)
        Me.grb_Type.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pic_Color, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_Search.ResumeLayout(False)
        Me.grb_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grb_Type As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents txt_Mas_Alam As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents lsv_Mas_Alam As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grb_Search As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Edit_Alam As System.Windows.Forms.Button
    Friend WithEvents btn_Add_Alam As System.Windows.Forms.Button
    Friend WithEvents lbl_Mas_Alam As System.Windows.Forms.Label
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents DlgCollor As System.Windows.Forms.ColorDialog
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_Back_Color As System.Windows.Forms.Label
    Friend WithEvents btn_Color As System.Windows.Forms.Button
    Friend WithEvents lbl_Color As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pic_Color As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_M_Start As System.Windows.Forms.Label
    Friend WithEvents lbl_H_Start As System.Windows.Forms.Label
    Friend WithEvents lbl_T_Status As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_M_Stop As System.Windows.Forms.Label
    Friend WithEvents lbl_H_Stop As System.Windows.Forms.Label
    Friend WithEvents lbl_T_Stop As System.Windows.Forms.Label
    Friend WithEvents txt_HH_Stop As System.Windows.Forms.TextBox
    Friend WithEvents txt_HH_Start As System.Windows.Forms.TextBox
    Friend WithEvents txt_MM_Stop As System.Windows.Forms.TextBox
    Friend WithEvents txt_MM_Start As System.Windows.Forms.TextBox
End Class
