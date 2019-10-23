<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Color_History_Standard_4_Color
    Inherits DevComponents.DotNetBar.Office2007Form  '   Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Color_History_Standard_4_Color))
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit_Alam = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.btn_Add_Alam = New System.Windows.Forms.Button()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.lsv_Mas_Alam = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pic_Color = New System.Windows.Forms.PictureBox()
        Me.btn_Color = New System.Windows.Forms.Button()
        Me.lbl_Color = New System.Windows.Forms.Label()
        Me.lbl_Back_Color = New System.Windows.Forms.Label()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.lbl_Mas_Alam = New System.Windows.Forms.Label()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.grb_Type = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_ColorB = New System.Windows.Forms.Label()
        Me.lbl_ColorG = New System.Windows.Forms.Label()
        Me.lbl_ColorR = New System.Windows.Forms.Label()
        Me.lbl_ColorA = New System.Windows.Forms.Label()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.txt_Mas_Alam = New System.Windows.Forms.TextBox()
        Me.DlgCollor = New System.Windows.Forms.ColorDialog()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pic_Color, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb_Type.SuspendLayout()
        Me.SuspendLayout()
        '
        'img_Search
        '
        Me.img_Search.ImageStream = CType(resources.GetObject("img_Search.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Search.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Search.Images.SetKeyName(0, "zippo 015.png")
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                                                 ชื่อ"
        Me.ColumnHeader2.Width = 365
        '
        'img_SaveAdd
        '
        Me.img_SaveAdd.ImageStream = CType(resources.GetObject("img_SaveAdd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_SaveAdd.TransparentColor = System.Drawing.Color.Transparent
        Me.img_SaveAdd.Images.SetKeyName(0, "zippo 044.png")
        '
        'btn_Edit_Alam
        '
        Me.btn_Edit_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit_Alam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit_Alam.ImageIndex = 0
        Me.btn_Edit_Alam.ImageList = Me.img_Edit
        Me.btn_Edit_Alam.Location = New System.Drawing.Point(273, 490)
        Me.btn_Edit_Alam.Name = "btn_Edit_Alam"
        Me.btn_Edit_Alam.Size = New System.Drawing.Size(82, 50)
        Me.btn_Edit_Alam.TabIndex = 34
        Me.btn_Edit_Alam.Text = " แก้ไข"
        Me.btn_Edit_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit_Alam.UseVisualStyleBackColor = True
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'img_Save
        '
        Me.img_Save.ImageStream = CType(resources.GetObject("img_Save.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Save.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Save.Images.SetKeyName(0, "zippo 050.png")
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel.ImageIndex = 0
        Me.btn_Cancel.ImageList = Me.img_Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(363, 490)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(82, 50)
        Me.btn_Cancel.TabIndex = 35
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
        'btn_Add_Alam
        '
        Me.btn_Add_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Alam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Alam.ImageIndex = 0
        Me.btn_Add_Alam.ImageList = Me.img_Add
        Me.btn_Add_Alam.Location = New System.Drawing.Point(93, 490)
        Me.btn_Add_Alam.Name = "btn_Add_Alam"
        Me.btn_Add_Alam.Size = New System.Drawing.Size(82, 50)
        Me.btn_Add_Alam.TabIndex = 33
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
        Me.lsv_Mas_Alam.Location = New System.Drawing.Point(13, 155)
        Me.lsv_Mas_Alam.Name = "lsv_Mas_Alam"
        Me.lsv_Mas_Alam.Size = New System.Drawing.Size(432, 329)
        Me.lsv_Mas_Alam.TabIndex = 37
        Me.lsv_Mas_Alam.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_Alam.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = " รหัส"
        Me.ColumnHeader1.Width = 50
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pic_Color)
        Me.GroupBox3.Controls.Add(Me.btn_Color)
        Me.GroupBox3.Controls.Add(Me.lbl_Color)
        Me.GroupBox3.Controls.Add(Me.lbl_Back_Color)
        Me.GroupBox3.Location = New System.Drawing.Point(312, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 137)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        '
        'pic_Color
        '
        Me.pic_Color.Image = CType(resources.GetObject("pic_Color.Image"), System.Drawing.Image)
        Me.pic_Color.Location = New System.Drawing.Point(7, 16)
        Me.pic_Color.Name = "pic_Color"
        Me.pic_Color.Size = New System.Drawing.Size(108, 75)
        Me.pic_Color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Color.TabIndex = 30
        Me.pic_Color.TabStop = False
        '
        'btn_Color
        '
        Me.btn_Color.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Color.ForeColor = System.Drawing.Color.Blue
        Me.btn_Color.Location = New System.Drawing.Point(87, 101)
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
        Me.lbl_Color.Location = New System.Drawing.Point(7, 103)
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
        Me.lbl_Back_Color.Location = New System.Drawing.Point(7, 16)
        Me.lbl_Back_Color.Name = "lbl_Back_Color"
        Me.lbl_Back_Color.Size = New System.Drawing.Size(108, 75)
        Me.lbl_Back_Color.TabIndex = 28
        '
        'btn_Delete
        '
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete.ImageIndex = 0
        Me.btn_Delete.ImageList = Me.img_Delete
        Me.btn_Delete.Location = New System.Drawing.Point(183, 490)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(82, 50)
        Me.btn_Delete.TabIndex = 36
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
        'img_Pic
        '
        Me.img_Pic.ImageStream = CType(resources.GetObject("img_Pic.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Pic.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Pic.Images.SetKeyName(0, "zippo 036.png")
        '
        'lbl_Mas_Alam
        '
        Me.lbl_Mas_Alam.BackColor = System.Drawing.Color.Black
        Me.lbl_Mas_Alam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Mas_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Mas_Alam.ForeColor = System.Drawing.Color.Red
        Me.lbl_Mas_Alam.Location = New System.Drawing.Point(53, 18)
        Me.lbl_Mas_Alam.Name = "lbl_Mas_Alam"
        Me.lbl_Mas_Alam.Size = New System.Drawing.Size(53, 22)
        Me.lbl_Mas_Alam.TabIndex = 10
        Me.lbl_Mas_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Name
        '
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_Name.Location = New System.Drawing.Point(4, 46)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(36, 16)
        Me.lbl_Name.TabIndex = 7
        Me.lbl_Name.Text = "ชื่อ :"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grb_Type
        '
        Me.grb_Type.Controls.Add(Me.Label4)
        Me.grb_Type.Controls.Add(Me.Label3)
        Me.grb_Type.Controls.Add(Me.Label2)
        Me.grb_Type.Controls.Add(Me.Label1)
        Me.grb_Type.Controls.Add(Me.lbl_ColorB)
        Me.grb_Type.Controls.Add(Me.lbl_ColorG)
        Me.grb_Type.Controls.Add(Me.lbl_ColorR)
        Me.grb_Type.Controls.Add(Me.lbl_ColorA)
        Me.grb_Type.Controls.Add(Me.GroupBox3)
        Me.grb_Type.Controls.Add(Me.lbl_Mas_Alam)
        Me.grb_Type.Controls.Add(Me.lbl_T_ID)
        Me.grb_Type.Controls.Add(Me.txt_Mas_Alam)
        Me.grb_Type.Controls.Add(Me.lbl_Name)
        Me.grb_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grb_Type.ForeColor = System.Drawing.Color.Black
        Me.grb_Type.Location = New System.Drawing.Point(12, 12)
        Me.grb_Type.Name = "grb_Type"
        Me.grb_Type.Size = New System.Drawing.Size(432, 137)
        Me.grb_Type.TabIndex = 38
        Me.grb_Type.TabStop = False
        Me.grb_Type.Text = "ประเภทการจอดรถ"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(248, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 16)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "รหัสสี B"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(171, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "รหัสสี G"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(94, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "รหัสสี R"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "รหัสสี A"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ColorB
        '
        Me.lbl_ColorB.BackColor = System.Drawing.Color.Black
        Me.lbl_ColorB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ColorB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_ColorB.ForeColor = System.Drawing.Color.Lime
        Me.lbl_ColorB.Location = New System.Drawing.Point(248, 97)
        Me.lbl_ColorB.Name = "lbl_ColorB"
        Me.lbl_ColorB.Size = New System.Drawing.Size(53, 22)
        Me.lbl_ColorB.TabIndex = 34
        Me.lbl_ColorB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_ColorB.Visible = False
        '
        'lbl_ColorG
        '
        Me.lbl_ColorG.BackColor = System.Drawing.Color.Black
        Me.lbl_ColorG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ColorG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_ColorG.ForeColor = System.Drawing.Color.Lime
        Me.lbl_ColorG.Location = New System.Drawing.Point(171, 97)
        Me.lbl_ColorG.Name = "lbl_ColorG"
        Me.lbl_ColorG.Size = New System.Drawing.Size(53, 22)
        Me.lbl_ColorG.TabIndex = 33
        Me.lbl_ColorG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ColorR
        '
        Me.lbl_ColorR.BackColor = System.Drawing.Color.Black
        Me.lbl_ColorR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ColorR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_ColorR.ForeColor = System.Drawing.Color.Lime
        Me.lbl_ColorR.Location = New System.Drawing.Point(94, 97)
        Me.lbl_ColorR.Name = "lbl_ColorR"
        Me.lbl_ColorR.Size = New System.Drawing.Size(53, 22)
        Me.lbl_ColorR.TabIndex = 32
        Me.lbl_ColorR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ColorA
        '
        Me.lbl_ColorA.BackColor = System.Drawing.Color.Black
        Me.lbl_ColorA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ColorA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_ColorA.ForeColor = System.Drawing.Color.Lime
        Me.lbl_ColorA.Location = New System.Drawing.Point(17, 97)
        Me.lbl_ColorA.Name = "lbl_ColorA"
        Me.lbl_ColorA.Size = New System.Drawing.Size(53, 22)
        Me.lbl_ColorA.TabIndex = 31
        Me.lbl_ColorA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(10, 21)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(43, 16)
        Me.lbl_T_ID.TabIndex = 6
        Me.lbl_T_ID.Text = "รหัส :"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Mas_Alam
        '
        Me.txt_Mas_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Mas_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Mas_Alam.Location = New System.Drawing.Point(37, 43)
        Me.txt_Mas_Alam.Name = "txt_Mas_Alam"
        Me.txt_Mas_Alam.Size = New System.Drawing.Size(263, 22)
        Me.txt_Mas_Alam.TabIndex = 9
        '
        'frm_Color_History_Standard_4_Color
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 546)
        Me.Controls.Add(Me.btn_Edit_Alam)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Add_Alam)
        Me.Controls.Add(Me.lsv_Mas_Alam)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.grb_Type)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Color_History_Standard_4_Color"
        Me.Text = "การตั้งค่า สีมาตรฐานประวัติการจอด 4 สี"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pic_Color, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb_Type.ResumeLayout(False)
        Me.grb_Type.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents btn_Edit_Alam As System.Windows.Forms.Button
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_Add_Alam As System.Windows.Forms.Button
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents lsv_Mas_Alam As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pic_Color As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Color As System.Windows.Forms.Button
    Friend WithEvents lbl_Color As System.Windows.Forms.Label
    Friend WithEvents lbl_Back_Color As System.Windows.Forms.Label
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents lbl_Mas_Alam As System.Windows.Forms.Label
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents grb_Type As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents txt_Mas_Alam As System.Windows.Forms.TextBox
    Friend WithEvents DlgCollor As System.Windows.Forms.ColorDialog
    Friend WithEvents lbl_ColorB As System.Windows.Forms.Label
    Friend WithEvents lbl_ColorG As System.Windows.Forms.Label
    Friend WithEvents lbl_ColorR As System.Windows.Forms.Label
    Friend WithEvents lbl_ColorA As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
