<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mas_Floorcontroller
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mas_Floorcontroller))
        Me.btn_Add_Controller = New System.Windows.Forms.Button()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit_Controller = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Cancel_Controller = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.txt_Mas_FloorController_Name = New System.Windows.Forms.TextBox()
        Me.lsv_Mas_Floor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grb_FloorController = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_Building = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTowerId = New System.Windows.Forms.ComboBox()
        Me.cmb_Floor = New System.Windows.Forms.ComboBox()
        Me.lbl_Floor = New System.Windows.Forms.Label()
        Me.lbl_Value = New System.Windows.Forms.Label()
        Me.txt_Many = New System.Windows.Forms.TextBox()
        Me.lbl_Mas_FloorController_Id = New System.Windows.Forms.Label()
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.dlg = New System.Windows.Forms.OpenFileDialog()
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.grb_FloorController.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Add_Controller
        '
        Me.btn_Add_Controller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add_Controller.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add_Controller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add_Controller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add_Controller.ImageIndex = 0
        Me.btn_Add_Controller.ImageList = Me.img_Add
        Me.btn_Add_Controller.Location = New System.Drawing.Point(82, 499)
        Me.btn_Add_Controller.Name = "btn_Add_Controller"
        Me.btn_Add_Controller.Size = New System.Drawing.Size(82, 50)
        Me.btn_Add_Controller.TabIndex = 5
        Me.btn_Add_Controller.Text = "เพิ่ม"
        Me.btn_Add_Controller.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add_Controller.UseVisualStyleBackColor = True
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
        'btn_Edit_Controller
        '
        Me.btn_Edit_Controller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_Controller.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit_Controller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit_Controller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit_Controller.ImageIndex = 0
        Me.btn_Edit_Controller.ImageList = Me.img_Edit
        Me.btn_Edit_Controller.Location = New System.Drawing.Point(262, 499)
        Me.btn_Edit_Controller.Name = "btn_Edit_Controller"
        Me.btn_Edit_Controller.Size = New System.Drawing.Size(82, 50)
        Me.btn_Edit_Controller.TabIndex = 6
        Me.btn_Edit_Controller.Text = " แก้ไข"
        Me.btn_Edit_Controller.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Edit_Controller.UseVisualStyleBackColor = True
        '
        'img_Edit
        '
        Me.img_Edit.ImageStream = CType(resources.GetObject("img_Edit.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Edit.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Edit.Images.SetKeyName(0, "zippo 019.png")
        '
        'btn_Cancel_Controller
        '
        Me.btn_Cancel_Controller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel_Controller.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel_Controller.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancel_Controller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel_Controller.ImageIndex = 0
        Me.btn_Cancel_Controller.ImageList = Me.img_Cancel
        Me.btn_Cancel_Controller.Location = New System.Drawing.Point(352, 499)
        Me.btn_Cancel_Controller.Name = "btn_Cancel_Controller"
        Me.btn_Cancel_Controller.Size = New System.Drawing.Size(82, 50)
        Me.btn_Cancel_Controller.TabIndex = 8
        Me.btn_Cancel_Controller.Text = "ยกเลิก"
        Me.btn_Cancel_Controller.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cancel_Controller.UseVisualStyleBackColor = True
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
        Me.btn_Delete.Location = New System.Drawing.Point(172, 499)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(82, 50)
        Me.btn_Delete.TabIndex = 7
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
        'lbl_T_ID
        '
        Me.lbl_T_ID.AutoSize = True
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(6, 24)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(35, 16)
        Me.lbl_T_ID.TabIndex = 6
        Me.lbl_T_ID.Text = "รหัส :"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Name
        '
        Me.lbl_Name.AutoSize = True
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_Name.Location = New System.Drawing.Point(14, 53)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(27, 16)
        Me.lbl_Name.TabIndex = 7
        Me.lbl_Name.Text = "ชื่อ :"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Mas_FloorController_Name
        '
        Me.txt_Mas_FloorController_Name.Enabled = False
        Me.txt_Mas_FloorController_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Mas_FloorController_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Mas_FloorController_Name.Location = New System.Drawing.Point(37, 50)
        Me.txt_Mas_FloorController_Name.Name = "txt_Mas_FloorController_Name"
        Me.txt_Mas_FloorController_Name.Size = New System.Drawing.Size(115, 22)
        Me.txt_Mas_FloorController_Name.TabIndex = 4
        '
        'lsv_Mas_Floor
        '
        Me.lsv_Mas_Floor.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.lsv_Mas_Floor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lsv_Mas_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Mas_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lsv_Mas_Floor.FullRowSelect = True
        Me.lsv_Mas_Floor.GridLines = True
        Me.lsv_Mas_Floor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Mas_Floor.HideSelection = False
        Me.lsv_Mas_Floor.Location = New System.Drawing.Point(12, 125)
        Me.lsv_Mas_Floor.Name = "lsv_Mas_Floor"
        Me.lsv_Mas_Floor.Size = New System.Drawing.Size(422, 368)
        Me.lsv_Mas_Floor.TabIndex = 10
        Me.lsv_Mas_Floor.UseCompatibleStateImageBehavior = False
        Me.lsv_Mas_Floor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "          รหัส"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                              ชื่อ"
        Me.ColumnHeader2.Width = 220
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "จำนวน"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Width = 0
        '
        'grb_FloorController
        '
        Me.grb_FloorController.Controls.Add(Me.Label2)
        Me.grb_FloorController.Controls.Add(Me.cmb_Building)
        Me.grb_FloorController.Controls.Add(Me.Label1)
        Me.grb_FloorController.Controls.Add(Me.cboTowerId)
        Me.grb_FloorController.Controls.Add(Me.cmb_Floor)
        Me.grb_FloorController.Controls.Add(Me.lbl_Floor)
        Me.grb_FloorController.Controls.Add(Me.lbl_Value)
        Me.grb_FloorController.Controls.Add(Me.txt_Many)
        Me.grb_FloorController.Controls.Add(Me.lbl_Mas_FloorController_Id)
        Me.grb_FloorController.Controls.Add(Me.lbl_T_ID)
        Me.grb_FloorController.Controls.Add(Me.txt_Mas_FloorController_Name)
        Me.grb_FloorController.Controls.Add(Me.lbl_Name)
        Me.grb_FloorController.ForeColor = System.Drawing.Color.Black
        Me.grb_FloorController.Location = New System.Drawing.Point(12, 12)
        Me.grb_FloorController.Name = "grb_FloorController"
        Me.grb_FloorController.Size = New System.Drawing.Size(422, 107)
        Me.grb_FloorController.TabIndex = 11
        Me.grb_FloorController.TabStop = False
        Me.grb_FloorController.Text = "อุปกรณ์ควบคุม"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(175, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "อาคารจอดรถ :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Building
        '
        Me.cmb_Building.Enabled = False
        Me.cmb_Building.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Building.FormattingEnabled = True
        Me.cmb_Building.Location = New System.Drawing.Point(249, 49)
        Me.cmb_Building.Name = "cmb_Building"
        Me.cmb_Building.Size = New System.Drawing.Size(157, 24)
        Me.cmb_Building.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(125, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "สถานที่ :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTowerId
        '
        Me.cboTowerId.Enabled = False
        Me.cboTowerId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboTowerId.FormattingEnabled = True
        Me.cboTowerId.Location = New System.Drawing.Point(172, 20)
        Me.cboTowerId.Name = "cboTowerId"
        Me.cboTowerId.Size = New System.Drawing.Size(234, 24)
        Me.cboTowerId.TabIndex = 36
        '
        'cmb_Floor
        '
        Me.cmb_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floor.Enabled = False
        Me.cmb_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmb_Floor.FormattingEnabled = True
        Me.cmb_Floor.Location = New System.Drawing.Point(188, 77)
        Me.cmb_Floor.Name = "cmb_Floor"
        Me.cmb_Floor.Size = New System.Drawing.Size(115, 24)
        Me.cmb_Floor.TabIndex = 35
        '
        'lbl_Floor
        '
        Me.lbl_Floor.AutoSize = True
        Me.lbl_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor.Location = New System.Drawing.Point(160, 81)
        Me.lbl_Floor.Name = "lbl_Floor"
        Me.lbl_Floor.Size = New System.Drawing.Size(28, 16)
        Me.lbl_Floor.TabIndex = 14
        Me.lbl_Floor.Text = "ชั้น :"
        Me.lbl_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Value
        '
        Me.lbl_Value.AutoSize = True
        Me.lbl_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Value.ForeColor = System.Drawing.Color.Black
        Me.lbl_Value.Location = New System.Drawing.Point(5, 81)
        Me.lbl_Value.Name = "lbl_Value"
        Me.lbl_Value.Size = New System.Drawing.Size(45, 16)
        Me.lbl_Value.TabIndex = 13
        Me.lbl_Value.Text = "จำนวน :"
        Me.lbl_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Many
        '
        Me.txt_Many.Enabled = False
        Me.txt_Many.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txt_Many.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Many.Location = New System.Drawing.Point(54, 78)
        Me.txt_Many.Name = "txt_Many"
        Me.txt_Many.Size = New System.Drawing.Size(98, 22)
        Me.txt_Many.TabIndex = 3
        '
        'lbl_Mas_FloorController_Id
        '
        Me.lbl_Mas_FloorController_Id.BackColor = System.Drawing.Color.Black
        Me.lbl_Mas_FloorController_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Mas_FloorController_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Mas_FloorController_Id.ForeColor = System.Drawing.Color.Red
        Me.lbl_Mas_FloorController_Id.Location = New System.Drawing.Point(37, 21)
        Me.lbl_Mas_FloorController_Id.Name = "lbl_Mas_FloorController_Id"
        Me.lbl_Mas_FloorController_Id.Size = New System.Drawing.Size(81, 22)
        Me.lbl_Mas_FloorController_Id.TabIndex = 10
        Me.lbl_Mas_FloorController_Id.Text = "1"
        Me.lbl_Mas_FloorController_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'frm_Mas_Floorcontroller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(448, 561)
        Me.Controls.Add(Me.grb_FloorController)
        Me.Controls.Add(Me.lsv_Mas_Floor)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Cancel_Controller)
        Me.Controls.Add(Me.btn_Edit_Controller)
        Me.Controls.Add(Me.btn_Add_Controller)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Mas_Floorcontroller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "อุปกรณ์ควบคุมตามชั้น"
        Me.grb_FloorController.ResumeLayout(False)
        Me.grb_FloorController.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Add_Controller As System.Windows.Forms.Button
    Friend WithEvents btn_Edit_Controller As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel_Controller As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents txt_Mas_FloorController_Name As System.Windows.Forms.TextBox
    Friend WithEvents lsv_Mas_Floor As System.Windows.Forms.ListView
    Friend WithEvents grb_FloorController As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents dlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents lbl_Mas_FloorController_Id As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_Value As System.Windows.Forms.Label
    Friend WithEvents txt_Many As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Floor As System.Windows.Forms.Label
    Friend WithEvents cmb_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTowerId As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_Building As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
