<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mas_Event
    Inherits DevComponents.DotNetBar.Office2007Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mas_Event))
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.lsv_Detail = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_Edit_Alam = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Add_Alam = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_Remark = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Event = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPickerSt = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_ID = New System.Windows.Forms.Label()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'img_Search
        '
        Me.img_Search.ImageStream = CType(resources.GetObject("img_Search.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Search.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Search.Images.SetKeyName(0, "zippo 015.png")
        '
        'img_Delete
        '
        Me.img_Delete.ImageStream = CType(resources.GetObject("img_Delete.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Delete.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Delete.Images.SetKeyName(0, "Alpha Dista Icon 050769.png")
        '
        'img_Cancel
        '
        Me.img_Cancel.ImageStream = CType(resources.GetObject("img_Cancel.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Cancel.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Cancel.Images.SetKeyName(0, "Applications.png")
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
        'lsv_Detail
        '
        Me.lsv_Detail.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lsv_Detail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lsv_Detail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lsv_Detail.FullRowSelect = True
        Me.lsv_Detail.GridLines = True
        Me.lsv_Detail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Detail.HideSelection = False
        Me.lsv_Detail.Location = New System.Drawing.Point(10, 121)
        Me.lsv_Detail.Name = "lsv_Detail"
        Me.lsv_Detail.Size = New System.Drawing.Size(463, 302)
        Me.lsv_Detail.TabIndex = 36
        Me.lsv_Detail.UseCompatibleStateImageBehavior = False
        Me.lsv_Detail.View = System.Windows.Forms.View.Details
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
        'btn_Edit_Alam
        '
        Me.btn_Edit_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit_Alam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit_Alam.ImageIndex = 0
        Me.btn_Edit_Alam.ImageList = Me.img_Edit
        Me.btn_Edit_Alam.Location = New System.Drawing.Point(301, 429)
        Me.btn_Edit_Alam.Name = "btn_Edit_Alam"
        Me.btn_Edit_Alam.Size = New System.Drawing.Size(82, 50)
        Me.btn_Edit_Alam.TabIndex = 38
        Me.btn_Edit_Alam.Text = " แก้ไข"
        Me.btn_Edit_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit_Alam.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel.ImageIndex = 0
        Me.btn_Cancel.ImageList = Me.img_Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(391, 429)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(82, 50)
        Me.btn_Cancel.TabIndex = 39
        Me.btn_Cancel.Text = "ยกเลิก"
        Me.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete.ImageIndex = 0
        Me.btn_Delete.ImageList = Me.img_Delete
        Me.btn_Delete.Location = New System.Drawing.Point(211, 429)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(82, 50)
        Me.btn_Delete.TabIndex = 40
        Me.btn_Delete.Text = "ลบ"
        Me.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'img_SaveAdd
        '
        Me.img_SaveAdd.ImageStream = CType(resources.GetObject("img_SaveAdd.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_SaveAdd.TransparentColor = System.Drawing.Color.Transparent
        Me.img_SaveAdd.Images.SetKeyName(0, "zippo 044.png")
        '
        'img_Pic
        '
        Me.img_Pic.ImageStream = CType(resources.GetObject("img_Pic.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Pic.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Pic.Images.SetKeyName(0, "zippo 036.png")
        '
        'img_Add
        '
        Me.img_Add.ImageStream = CType(resources.GetObject("img_Add.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Add.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Add.Images.SetKeyName(0, "Add.png")
        '
        'btn_Add_Alam
        '
        Me.btn_Add_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Alam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add_Alam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Alam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Alam.ImageIndex = 0
        Me.btn_Add_Alam.ImageList = Me.img_Add
        Me.btn_Add_Alam.Location = New System.Drawing.Point(123, 429)
        Me.btn_Add_Alam.Name = "btn_Add_Alam"
        Me.btn_Add_Alam.Size = New System.Drawing.Size(82, 50)
        Me.btn_Add_Alam.TabIndex = 41
        Me.btn_Add_Alam.Text = "เพิ่ม"
        Me.btn_Add_Alam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add_Alam.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Remark)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_Event)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPickerSt)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DTPickerEnd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbl_ID)
        Me.GroupBox1.Controls.Add(Me.lbl_T_ID)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(463, 113)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'txt_Remark
        '
        Me.txt_Remark.Location = New System.Drawing.Point(63, 83)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(388, 20)
        Me.txt_Remark.TabIndex = 144
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 143
        Me.Label4.Text = "หมายเหตุ :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Event
        '
        Me.txt_Event.Location = New System.Drawing.Point(51, 52)
        Me.txt_Event.Name = "txt_Event"
        Me.txt_Event.Size = New System.Drawing.Size(400, 20)
        Me.txt_Event.TabIndex = 142
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "ชื่องาน :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPickerSt
        '
        Me.DTPickerSt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerSt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerSt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerSt.Location = New System.Drawing.Point(164, 18)
        Me.DTPickerSt.Name = "DTPickerSt"
        Me.DTPickerSt.Size = New System.Drawing.Size(100, 22)
        Me.DTPickerSt.TabIndex = 137
        Me.DTPickerSt.Value = New Date(2006, 10, 14, 11, 0, 24, 922)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(104, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "เริ่มวันที่ :"
        '
        'DTPickerEnd
        '
        Me.DTPickerEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DTPickerEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DTPickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPickerEnd.Location = New System.Drawing.Point(350, 18)
        Me.DTPickerEnd.Name = "DTPickerEnd"
        Me.DTPickerEnd.Size = New System.Drawing.Size(101, 22)
        Me.DTPickerEnd.TabIndex = 138
        Me.DTPickerEnd.Value = New Date(2006, 10, 14, 11, 0, 24, 912)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(278, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "สิ้นสุดวันที่ :"
        '
        'lbl_ID
        '
        Me.lbl_ID.BackColor = System.Drawing.Color.Black
        Me.lbl_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_ID.ForeColor = System.Drawing.Color.Red
        Me.lbl_ID.Location = New System.Drawing.Point(41, 16)
        Me.lbl_ID.Name = "lbl_ID"
        Me.lbl_ID.Size = New System.Drawing.Size(59, 27)
        Me.lbl_ID.TabIndex = 12
        Me.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.AutoSize = True
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(6, 21)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(35, 16)
        Me.lbl_T_ID.TabIndex = 11
        Me.lbl_T_ID.Text = "รหัส :"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_Mas_Event
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 495)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Add_Alam)
        Me.Controls.Add(Me.btn_Edit_Alam)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.lsv_Detail)
        Me.DoubleBuffered = True
        Me.Name = "frm_Mas_Event"
        Me.Text = "การจัดงาน Event"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents lsv_Detail As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_Edit_Alam As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents btn_Add_Alam As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents txt_Event As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTPickerSt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
