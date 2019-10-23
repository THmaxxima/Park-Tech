<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Connect_Between_HW_Net3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Connect_Between_HW_Net3))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_Net3_Id = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Net3_Name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lsv_Net3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit_Net3 = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Add_Net3 = New System.Windows.Forms.Button()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_Net3_Id)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_Net3_Name)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 85)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "อุปกรณ์ตรวจสอบตามชั้น"
        '
        'lbl_Net3_Id
        '
        Me.lbl_Net3_Id.BackColor = System.Drawing.Color.Black
        Me.lbl_Net3_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Net3_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Net3_Id.ForeColor = System.Drawing.Color.Red
        Me.lbl_Net3_Id.Location = New System.Drawing.Point(77, 14)
        Me.lbl_Net3_Id.Name = "lbl_Net3_Id"
        Me.lbl_Net3_Id.Size = New System.Drawing.Size(107, 28)
        Me.lbl_Net3_Id.TabIndex = 10
        Me.lbl_Net3_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(-4, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "รหัส"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Net3_Name
        '
        Me.txt_Net3_Name.Enabled = False
        Me.txt_Net3_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Net3_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Net3_Name.Location = New System.Drawing.Point(77, 45)
        Me.txt_Net3_Name.Name = "txt_Net3_Name"
        Me.txt_Net3_Name.Size = New System.Drawing.Size(324, 22)
        Me.txt_Net3_Name.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(-4, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ชื่อ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lsv_Net3
        '
        Me.lsv_Net3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lsv_Net3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsv_Net3.FullRowSelect = True
        Me.lsv_Net3.GridLines = True
        Me.lsv_Net3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Net3.HideSelection = False
        Me.lsv_Net3.Location = New System.Drawing.Point(12, 208)
        Me.lsv_Net3.Name = "lsv_Net3"
        Me.lsv_Net3.Size = New System.Drawing.Size(422, 184)
        Me.lsv_Net3.TabIndex = 24
        Me.lsv_Net3.TabStop = False
        Me.lsv_Net3.UseCompatibleStateImageBehavior = False
        Me.lsv_Net3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "          รหัส"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                                          ชื่อ"
        Me.ColumnHeader2.Width = 310
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Search)
        Me.GroupBox1.Controls.Add(Me.btn_Search)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 70)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ค้นหาข้อมูล"
        '
        'txt_Search
        '
        Me.txt_Search.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Search.Location = New System.Drawing.Point(28, 21)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(261, 22)
        Me.txt_Search.TabIndex = 1
        '
        'btn_Search
        '
        Me.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search.ForeColor = System.Drawing.Color.Black
        Me.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search.ImageIndex = 0
        Me.btn_Search.ImageList = Me.img_Search
        Me.btn_Search.Location = New System.Drawing.Point(295, 8)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(82, 50)
        Me.btn_Search.TabIndex = 2
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
        Me.btn_Delete.Location = New System.Drawing.Point(172, 408)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(82, 50)
        Me.btn_Delete.TabIndex = 6
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
        Me.btn_Cancel.Location = New System.Drawing.Point(352, 408)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(82, 50)
        Me.btn_Cancel.TabIndex = 7
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
        'btn_Edit_Net3
        '
        Me.btn_Edit_Net3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_Net3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit_Net3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit_Net3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit_Net3.ImageIndex = 0
        Me.btn_Edit_Net3.ImageList = Me.img_Edit
        Me.btn_Edit_Net3.Location = New System.Drawing.Point(262, 408)
        Me.btn_Edit_Net3.Name = "btn_Edit_Net3"
        Me.btn_Edit_Net3.Size = New System.Drawing.Size(82, 50)
        Me.btn_Edit_Net3.TabIndex = 5
        Me.btn_Edit_Net3.Text = " แก้ไข"
        Me.btn_Edit_Net3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit_Net3.UseVisualStyleBackColor = True
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'btn_Add_Net3
        '
        Me.btn_Add_Net3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Net3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add_Net3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Net3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Net3.ImageIndex = 0
        Me.btn_Add_Net3.ImageList = Me.img_Add
        Me.btn_Add_Net3.Location = New System.Drawing.Point(82, 408)
        Me.btn_Add_Net3.Name = "btn_Add_Net3"
        Me.btn_Add_Net3.Size = New System.Drawing.Size(82, 50)
        Me.btn_Add_Net3.TabIndex = 4
        Me.btn_Add_Net3.Text = "เพิ่ม"
        Me.btn_Add_Net3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add_Net3.UseVisualStyleBackColor = True
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
        'img_SaveAdd
        '
        Me.img_SaveAdd.ImageStream = CType(resources.GetObject("img_SaveAdd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_SaveAdd.TransparentColor = System.Drawing.Color.Transparent
        Me.img_SaveAdd.Images.SetKeyName(0, "zippo 044.png")
        '
        'img_Save
        '
        Me.img_Save.ImageStream = CType(resources.GetObject("img_Save.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Save.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Save.Images.SetKeyName(0, "zippo 050.png")
        '
        'frm_Connect_Between_HW_Net3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(451, 474)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lsv_Net3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit_Net3)
        Me.Controls.Add(Me.btn_Add_Net3)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Connect_Between_HW_Net3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "สถานะการเชื่อมต่ออุปกรณ์ตรวจสอบ"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Net3_Id As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Net3_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lsv_Net3 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Edit_Net3 As System.Windows.Forms.Button
    Friend WithEvents btn_Add_Net3 As System.Windows.Forms.Button
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
End Class
