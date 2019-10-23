<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mas_Arrow_Display
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mas_Arrow_Display))
        Me.lbl_Floor = New System.Windows.Forms.Label()
        Me.txt_Floor_Name = New System.Windows.Forms.TextBox()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lsv_Mas_HW_Floor = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_Floor_Id = New System.Windows.Forms.Label()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.grb_Floor = New System.Windows.Forms.GroupBox()
        Me.btn_Delete_Picture = New System.Windows.Forms.Button()
        Me.btn_Add_Picture = New System.Windows.Forms.Button()
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.Picture_Floor = New System.Windows.Forms.PictureBox()
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.grb_Floor.SuspendLayout()
        CType(Me.Picture_Floor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Floor
        '
        Me.lbl_Floor.AutoSize = True
        Me.lbl_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor.Location = New System.Drawing.Point(8, 46)
        Me.lbl_Floor.Name = "lbl_Floor"
        Me.lbl_Floor.Size = New System.Drawing.Size(27, 16)
        Me.lbl_Floor.TabIndex = 1
        Me.lbl_Floor.Text = "ชื่อ :"
        Me.lbl_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Floor_Name
        '
        Me.txt_Floor_Name.Enabled = False
        Me.txt_Floor_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Floor_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Floor_Name.Location = New System.Drawing.Point(38, 43)
        Me.txt_Floor_Name.Name = "txt_Floor_Name"
        Me.txt_Floor_Name.Size = New System.Drawing.Size(359, 22)
        Me.txt_Floor_Name.TabIndex = 2
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.AutoSize = True
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(6, 16)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(35, 16)
        Me.lbl_T_ID.TabIndex = 8
        Me.lbl_T_ID.Text = "รหัส :"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "            รหัส"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                                      ชื่อ"
        Me.ColumnHeader2.Width = 270
        '
        'lsv_Mas_HW_Floor
        '
        Me.lsv_Mas_HW_Floor.BackColor = System.Drawing.Color.White
        Me.lsv_Mas_HW_Floor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsv_Mas_HW_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Mas_HW_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lsv_Mas_HW_Floor.FullRowSelect = True
        Me.lsv_Mas_HW_Floor.GridLines = True
        Me.lsv_Mas_HW_Floor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Mas_HW_Floor.HideSelection = False
        Me.lsv_Mas_HW_Floor.Location = New System.Drawing.Point(12, 181)
        Me.lsv_Mas_HW_Floor.Name = "lsv_Mas_HW_Floor"
        Me.lsv_Mas_HW_Floor.Size = New System.Drawing.Size(402, 328)
        Me.lsv_Mas_HW_Floor.TabIndex = 7
        Me.lsv_Mas_HW_Floor.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_HW_Floor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 0
        '
        'lbl_Floor_Id
        '
        Me.lbl_Floor_Id.BackColor = System.Drawing.Color.Black
        Me.lbl_Floor_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Floor_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor_Id.ForeColor = System.Drawing.Color.Red
        Me.lbl_Floor_Id.Location = New System.Drawing.Point(38, 13)
        Me.lbl_Floor_Id.Name = "lbl_Floor_Id"
        Me.lbl_Floor_Id.Size = New System.Drawing.Size(56, 27)
        Me.lbl_Floor_Id.TabIndex = 9
        Me.lbl_Floor_Id.Text = "0"
        Me.lbl_Floor_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'img_Add
        '
        Me.img_Add.ImageStream = CType(resources.GetObject("img_Add.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Add.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Add.Images.SetKeyName(0, "Add.png")
        '
        'img_Search
        '
        Me.img_Search.ImageStream = CType(resources.GetObject("img_Search.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Search.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Search.Images.SetKeyName(0, "zippo 015.png")
        '
        'grb_Floor
        '
        Me.grb_Floor.Controls.Add(Me.btn_Delete_Picture)
        Me.grb_Floor.Controls.Add(Me.lbl_Floor_Id)
        Me.grb_Floor.Controls.Add(Me.btn_Add_Picture)
        Me.grb_Floor.Controls.Add(Me.lbl_Floor)
        Me.grb_Floor.Controls.Add(Me.txt_Floor_Name)
        Me.grb_Floor.Controls.Add(Me.Picture_Floor)
        Me.grb_Floor.Controls.Add(Me.lbl_T_ID)
        Me.grb_Floor.ForeColor = System.Drawing.Color.Black
        Me.grb_Floor.Location = New System.Drawing.Point(12, 12)
        Me.grb_Floor.Name = "grb_Floor"
        Me.grb_Floor.Size = New System.Drawing.Size(402, 162)
        Me.grb_Floor.TabIndex = 12
        Me.grb_Floor.TabStop = False
        Me.grb_Floor.Text = "ชั้น"
        '
        'btn_Delete_Picture
        '
        Me.btn_Delete_Picture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete_Picture.Enabled = False
        Me.btn_Delete_Picture.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Delete_Picture.Image = CType(resources.GetObject("btn_Delete_Picture.Image"), System.Drawing.Image)
        Me.btn_Delete_Picture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete_Picture.Location = New System.Drawing.Point(302, 106)
        Me.btn_Delete_Picture.Name = "btn_Delete_Picture"
        Me.btn_Delete_Picture.Size = New System.Drawing.Size(94, 50)
        Me.btn_Delete_Picture.TabIndex = 16
        Me.btn_Delete_Picture.Text = "ลบรูป"
        Me.btn_Delete_Picture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Delete_Picture.UseVisualStyleBackColor = True
        '
        'btn_Add_Picture
        '
        Me.btn_Add_Picture.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Picture.Enabled = False
        Me.btn_Add_Picture.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Picture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Picture.ImageIndex = 0
        Me.btn_Add_Picture.ImageList = Me.img_Pic
        Me.btn_Add_Picture.Location = New System.Drawing.Point(204, 106)
        Me.btn_Add_Picture.Name = "btn_Add_Picture"
        Me.btn_Add_Picture.Size = New System.Drawing.Size(94, 50)
        Me.btn_Add_Picture.TabIndex = 13
        Me.btn_Add_Picture.Text = "เลือกรูป"
        Me.btn_Add_Picture.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add_Picture.UseVisualStyleBackColor = True
        '
        'img_Pic
        '
        Me.img_Pic.ImageStream = CType(resources.GetObject("img_Pic.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Pic.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Pic.Images.SetKeyName(0, "zippo 036.png")
        '
        'Picture_Floor
        '
        Me.Picture_Floor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Picture_Floor.ErrorImage = CType(resources.GetObject("Picture_Floor.ErrorImage"), System.Drawing.Image)
        Me.Picture_Floor.Location = New System.Drawing.Point(86, 76)
        Me.Picture_Floor.Name = "Picture_Floor"
        Me.Picture_Floor.Size = New System.Drawing.Size(115, 81)
        Me.Picture_Floor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture_Floor.TabIndex = 14
        Me.Picture_Floor.TabStop = False
        '
        'img_Delete
        '
        Me.img_Delete.ImageStream = CType(resources.GetObject("img_Delete.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Delete.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Delete.Images.SetKeyName(0, "Alpha Dista Icon 050769.png")
        '
        'img_Save
        '
        Me.img_Save.ImageStream = CType(resources.GetObject("img_Save.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Save.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Save.Images.SetKeyName(0, "zippo 050.png")
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'img_SaveAdd
        '
        Me.img_SaveAdd.ImageStream = CType(resources.GetObject("img_SaveAdd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_SaveAdd.TransparentColor = System.Drawing.Color.Transparent
        Me.img_SaveAdd.Images.SetKeyName(0, "zippo 044.png")
        '
        'img_Cancel
        '
        Me.img_Cancel.ImageStream = CType(resources.GetObject("img_Cancel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Cancel.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Cancel.Images.SetKeyName(0, "Applications.png")
        '
        'btn_Delete
        '
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete.ImageIndex = 0
        Me.btn_Delete.ImageList = Me.img_Delete
        Me.btn_Delete.Location = New System.Drawing.Point(119, 515)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(93, 50)
        Me.btn_Delete.TabIndex = 6
        Me.btn_Delete.Text = "ลบ"
        Me.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btn_Cancel.ImageIndex = 0
        Me.btn_Cancel.ImageList = Me.img_Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(321, 515)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(93, 50)
        Me.btn_Cancel.TabIndex = 5
        Me.btn_Cancel.Text = "ยกเลิก"
        Me.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit.ImageIndex = 0
        Me.btn_Edit.ImageList = Me.img_Edit
        Me.btn_Edit.Location = New System.Drawing.Point(220, 515)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(93, 50)
        Me.btn_Edit.TabIndex = 4
        Me.btn_Edit.Text = "แก้ไข"
        Me.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add.ImageIndex = 0
        Me.btn_Add.ImageList = Me.img_Add
        Me.btn_Add.Location = New System.Drawing.Point(18, 515)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(93, 50)
        Me.btn_Add.TabIndex = 3
        Me.btn_Add.Text = "เพิ่ม"
        Me.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'frm_Mas_Arrow_Display
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(429, 576)
        Me.Controls.Add(Me.grb_Floor)
        Me.Controls.Add(Me.lsv_Mas_HW_Floor)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.btn_Add)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Mas_Arrow_Display"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ตั้งค่าลูกศรป้ายแสดงผล"
        Me.grb_Floor.ResumeLayout(False)
        Me.grb_Floor.PerformLayout()
        CType(Me.Picture_Floor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Floor As System.Windows.Forms.Label
    Friend WithEvents txt_Floor_Name As System.Windows.Forms.TextBox
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lsv_Mas_HW_Floor As System.Windows.Forms.ListView
    Friend WithEvents lbl_Floor_Id As System.Windows.Forms.Label
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents grb_Floor As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Add_Picture As System.Windows.Forms.Button
    Friend WithEvents Picture_Floor As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Delete_Picture As System.Windows.Forms.Button
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
End Class
