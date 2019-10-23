<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mas_HW_Status
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mas_HW_Status))
        Me.grb_Detail = New System.Windows.Forms.GroupBox()
        Me.lbl_Mas_Status_Id = New System.Windows.Forms.Label()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.txt_Mas_Status_Name = New System.Windows.Forms.TextBox()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.lsv_Mas_Status = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grb_Search = New System.Windows.Forms.GroupBox()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit_Status = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Add_Status = New System.Windows.Forms.Button()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.grb_Detail.SuspendLayout()
        Me.grb_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'grb_Detail
        '
        Me.grb_Detail.Controls.Add(Me.lbl_Mas_Status_Id)
        Me.grb_Detail.Controls.Add(Me.lbl_T_ID)
        Me.grb_Detail.Controls.Add(Me.txt_Mas_Status_Name)
        Me.grb_Detail.Controls.Add(Me.lbl_Name)
        Me.grb_Detail.ForeColor = System.Drawing.Color.Black
        Me.grb_Detail.Location = New System.Drawing.Point(12, 109)
        Me.grb_Detail.Name = "grb_Detail"
        Me.grb_Detail.Size = New System.Drawing.Size(422, 85)
        Me.grb_Detail.TabIndex = 18
        Me.grb_Detail.TabStop = False
        Me.grb_Detail.Text = "รายละเอียด"
        '
        'lbl_Mas_Status_Id
        '
        Me.lbl_Mas_Status_Id.BackColor = System.Drawing.Color.Black
        Me.lbl_Mas_Status_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Mas_Status_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Mas_Status_Id.ForeColor = System.Drawing.Color.Red
        Me.lbl_Mas_Status_Id.Location = New System.Drawing.Point(103, 16)
        Me.lbl_Mas_Status_Id.Name = "lbl_Mas_Status_Id"
        Me.lbl_Mas_Status_Id.Size = New System.Drawing.Size(107, 28)
        Me.lbl_Mas_Status_Id.TabIndex = 10
        Me.lbl_Mas_Status_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(6, 25)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(93, 16)
        Me.lbl_T_ID.TabIndex = 6
        Me.lbl_T_ID.Text = "รหัส"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Mas_Status_Name
        '
        Me.txt_Mas_Status_Name.Enabled = False
        Me.txt_Mas_Status_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Mas_Status_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Mas_Status_Name.Location = New System.Drawing.Point(103, 47)
        Me.txt_Mas_Status_Name.Name = "txt_Mas_Status_Name"
        Me.txt_Mas_Status_Name.Size = New System.Drawing.Size(288, 22)
        Me.txt_Mas_Status_Name.TabIndex = 9
        '
        'lbl_Name
        '
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_Name.Location = New System.Drawing.Point(9, 51)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(88, 16)
        Me.lbl_Name.TabIndex = 7
        Me.lbl_Name.Text = "ชื่อ"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lsv_Mas_Status
        '
        Me.lsv_Mas_Status.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lsv_Mas_Status.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsv_Mas_Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Mas_Status.FullRowSelect = True
        Me.lsv_Mas_Status.GridLines = True
        Me.lsv_Mas_Status.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Mas_Status.HideSelection = False
        Me.lsv_Mas_Status.Location = New System.Drawing.Point(12, 213)
        Me.lsv_Mas_Status.Name = "lsv_Mas_Status"
        Me.lsv_Mas_Status.Size = New System.Drawing.Size(422, 218)
        Me.lsv_Mas_Status.TabIndex = 17
        Me.lsv_Mas_Status.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_Status.View = System.Windows.Forms.View.Details
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
        'grb_Search
        '
        Me.grb_Search.Controls.Add(Me.txt_Search)
        Me.grb_Search.Controls.Add(Me.btn_Search)
        Me.grb_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grb_Search.ForeColor = System.Drawing.Color.Black
        Me.grb_Search.Location = New System.Drawing.Point(12, 21)
        Me.grb_Search.Name = "grb_Search"
        Me.grb_Search.Size = New System.Drawing.Size(422, 70)
        Me.grb_Search.TabIndex = 16
        Me.grb_Search.TabStop = False
        Me.grb_Search.Text = "ค้นหาข้อมูล"
        '
        'txt_Search
        '
        Me.txt_Search.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Search.Location = New System.Drawing.Point(38, 28)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(261, 22)
        Me.txt_Search.TabIndex = 2
        '
        'btn_Search
        '
        Me.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search.ForeColor = System.Drawing.Color.Black
        Me.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search.ImageIndex = 0
        Me.btn_Search.ImageList = Me.img_Search
        Me.btn_Search.Location = New System.Drawing.Point(305, 15)
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
        Me.btn_Delete.Location = New System.Drawing.Point(172, 437)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(82, 50)
        Me.btn_Delete.TabIndex = 15
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
        Me.btn_Cancel.Location = New System.Drawing.Point(352, 437)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(82, 50)
        Me.btn_Cancel.TabIndex = 14
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
        'btn_Edit_Status
        '
        Me.btn_Edit_Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit_Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit_Status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit_Status.ImageIndex = 0
        Me.btn_Edit_Status.ImageList = Me.img_Edit
        Me.btn_Edit_Status.Location = New System.Drawing.Point(262, 437)
        Me.btn_Edit_Status.Name = "btn_Edit_Status"
        Me.btn_Edit_Status.Size = New System.Drawing.Size(82, 50)
        Me.btn_Edit_Status.TabIndex = 13
        Me.btn_Edit_Status.Text = " แก้ไข"
        Me.btn_Edit_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit_Status.UseVisualStyleBackColor = True
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'btn_Add_Status
        '
        Me.btn_Add_Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add_Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Status.ImageIndex = 0
        Me.btn_Add_Status.ImageList = Me.img_Add
        Me.btn_Add_Status.Location = New System.Drawing.Point(82, 437)
        Me.btn_Add_Status.Name = "btn_Add_Status"
        Me.btn_Add_Status.Size = New System.Drawing.Size(82, 50)
        Me.btn_Add_Status.TabIndex = 12
        Me.btn_Add_Status.Text = "เพิ่ม"
        Me.btn_Add_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add_Status.UseVisualStyleBackColor = True
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
        'frm_Mas_HW_Status
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(449, 499)
        Me.Controls.Add(Me.grb_Detail)
        Me.Controls.Add(Me.lsv_Mas_Status)
        Me.Controls.Add(Me.grb_Search)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit_Status)
        Me.Controls.Add(Me.btn_Add_Status)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Mas_HW_Status"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "สถานะการจอดรถ"
        Me.grb_Detail.ResumeLayout(False)
        Me.grb_Detail.PerformLayout()
        Me.grb_Search.ResumeLayout(False)
        Me.grb_Search.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grb_Detail As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents txt_Mas_Status_Name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents lsv_Mas_Status As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grb_Search As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Edit_Status As System.Windows.Forms.Button
    Friend WithEvents btn_Add_Status As System.Windows.Forms.Button
    Friend WithEvents lbl_Mas_Status_Id As System.Windows.Forms.Label
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
End Class
