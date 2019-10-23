<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfile_User
    Inherits DevComponents.DotNetBar.Office2007Form

    'Form  dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Sub Override(ByVal disposing As Boolean)
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
        Me.GrpChangePWD = New System.Windows.Forms.GroupBox()
        Me.txtOldPWD = New System.Windows.Forms.TextBox()
        Me.cmdChangePWD = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNewPWD = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtConfirmPWD = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbPosition = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbDepartMent = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImgUser = New System.Windows.Forms.PictureBox()
        Me.cmdUpLoadImg = New System.Windows.Forms.Button()
        Me.DLGOpen = New System.Windows.Forms.OpenFileDialog()
        Me.lbUserID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtUser_Phone = New System.Windows.Forms.TextBox()
        Me.txtUser_Address = New System.Windows.Forms.TextBox()
        Me.txtUser_Last_Name_TH = New System.Windows.Forms.TextBox()
        Me.txtUser_First_Name_TH = New System.Windows.Forms.TextBox()
        Me.txtUser_Last_Name_EN = New System.Windows.Forms.TextBox()
        Me.txtUser_First_Name_EN = New System.Windows.Forms.TextBox()
        Me.txtUser_Name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CK_AutoHideMenu = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.pMain = New System.Windows.Forms.Panel()
        Me.GrpChangePWD.SuspendLayout()
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpChangePWD
        '
        Me.GrpChangePWD.BackColor = System.Drawing.Color.Transparent
        Me.GrpChangePWD.Controls.Add(Me.txtOldPWD)
        Me.GrpChangePWD.Controls.Add(Me.cmdChangePWD)
        Me.GrpChangePWD.Controls.Add(Me.Label16)
        Me.GrpChangePWD.Controls.Add(Me.txtNewPWD)
        Me.GrpChangePWD.Controls.Add(Me.Label15)
        Me.GrpChangePWD.Controls.Add(Me.txtConfirmPWD)
        Me.GrpChangePWD.Controls.Add(Me.Label14)
        Me.GrpChangePWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GrpChangePWD.ForeColor = System.Drawing.Color.White
        Me.GrpChangePWD.Location = New System.Drawing.Point(10, 313)
        Me.GrpChangePWD.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpChangePWD.Name = "GrpChangePWD"
        Me.GrpChangePWD.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpChangePWD.Size = New System.Drawing.Size(331, 120)
        Me.GrpChangePWD.TabIndex = 21
        Me.GrpChangePWD.TabStop = False
        Me.GrpChangePWD.Text = "เปลี่ยนรหัสผ่าน"
        '
        'txtOldPWD
        '
        Me.txtOldPWD.Location = New System.Drawing.Point(120, 30)
        Me.txtOldPWD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOldPWD.Name = "txtOldPWD"
        Me.txtOldPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPWD.Size = New System.Drawing.Size(136, 22)
        Me.txtOldPWD.TabIndex = 14
        '
        'cmdChangePWD
        '
        Me.cmdChangePWD.ForeColor = System.Drawing.Color.Teal
        Me.cmdChangePWD.Location = New System.Drawing.Point(264, 88)
        Me.cmdChangePWD.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdChangePWD.Name = "cmdChangePWD"
        Me.cmdChangePWD.Size = New System.Drawing.Size(56, 27)
        Me.cmdChangePWD.TabIndex = 17
        Me.cmdChangePWD.Text = "ตกลง"
        Me.cmdChangePWD.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(10, 85)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 27)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "ยืนยันรหัสผ่านใหม่ :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNewPWD
        '
        Me.txtNewPWD.Location = New System.Drawing.Point(120, 60)
        Me.txtNewPWD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNewPWD.Name = "txtNewPWD"
        Me.txtNewPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPWD.Size = New System.Drawing.Size(136, 22)
        Me.txtNewPWD.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(29, 55)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 27)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "รหัสผ่านใหม่ :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConfirmPWD
        '
        Me.txtConfirmPWD.Location = New System.Drawing.Point(120, 90)
        Me.txtConfirmPWD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConfirmPWD.Name = "txtConfirmPWD"
        Me.txtConfirmPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPWD.Size = New System.Drawing.Size(136, 22)
        Me.txtConfirmPWD.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(42, 25)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 27)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "รหัสผ่านเดิม :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbPosition
        '
        Me.lbPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbPosition.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbPosition.Location = New System.Drawing.Point(127, 201)
        Me.lbPosition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbPosition.Name = "lbPosition"
        Me.lbPosition.Size = New System.Drawing.Size(242, 23)
        Me.lbPosition.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(26, 197)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 27)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "ระดับการใช้งาน :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbDepartMent
        '
        Me.lbDepartMent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDepartMent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbDepartMent.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbDepartMent.Location = New System.Drawing.Point(127, 174)
        Me.lbDepartMent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbDepartMent.Name = "lbDepartMent"
        Me.lbDepartMent.Size = New System.Drawing.Size(242, 23)
        Me.lbDepartMent.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(15, 170)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 27)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "แผนก :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(54, 285)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 25)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "โทรศัพท์ :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(33, 225)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 27)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "ที่อยู่ :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(20, 87)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 27)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "นามสกุลจริง(EN) :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(30, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ชื่อจริง(EN) :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ชื่อผู้ใช้ในระบบ :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImgUser
        '
        Me.ImgUser.BackColor = System.Drawing.SystemColors.ControlText
        Me.ImgUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ImgUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImgUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImgUser.ErrorImage = Nothing
        Me.ImgUser.Location = New System.Drawing.Point(376, 9)
        Me.ImgUser.Margin = New System.Windows.Forms.Padding(4)
        Me.ImgUser.Name = "ImgUser"
        Me.ImgUser.Size = New System.Drawing.Size(187, 179)
        Me.ImgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImgUser.TabIndex = 0
        Me.ImgUser.TabStop = False
        '
        'cmdUpLoadImg
        '
        Me.cmdUpLoadImg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUpLoadImg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdUpLoadImg.ForeColor = System.Drawing.Color.White
        Me.cmdUpLoadImg.Location = New System.Drawing.Point(376, 191)
        Me.cmdUpLoadImg.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdUpLoadImg.Name = "cmdUpLoadImg"
        Me.cmdUpLoadImg.Size = New System.Drawing.Size(92, 33)
        Me.cmdUpLoadImg.TabIndex = 2
        Me.cmdUpLoadImg.Text = "อัพโหลดรูปภาพ"
        Me.cmdUpLoadImg.UseVisualStyleBackColor = True
        '
        'lbUserID
        '
        Me.lbUserID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbUserID.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbUserID.Location = New System.Drawing.Point(127, 9)
        Me.lbUserID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbUserID.Name = "lbUserID"
        Me.lbUserID.Size = New System.Drawing.Size(242, 23)
        Me.lbUserID.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(38, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 27)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "รหัสผู้ใช้ :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtUser_Phone)
        Me.Panel1.Controls.Add(Me.txtUser_Address)
        Me.Panel1.Controls.Add(Me.txtUser_Last_Name_TH)
        Me.Panel1.Controls.Add(Me.txtUser_First_Name_TH)
        Me.Panel1.Controls.Add(Me.txtUser_Last_Name_EN)
        Me.Panel1.Controls.Add(Me.txtUser_First_Name_EN)
        Me.Panel1.Controls.Add(Me.txtUser_Name)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CK_AutoHideMenu)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cmdUpLoadImg)
        Me.Panel1.Controls.Add(Me.ImgUser)
        Me.Panel1.Controls.Add(Me.lbUserID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GrpChangePWD)
        Me.Panel1.Controls.Add(Me.lbPosition)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lbDepartMent)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.ForeColor = System.Drawing.Color.Teal
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(578, 476)
        Me.Panel1.TabIndex = 2
        '
        'txtUser_Phone
        '
        Me.txtUser_Phone.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_Phone.Location = New System.Drawing.Point(127, 290)
        Me.txtUser_Phone.Name = "txtUser_Phone"
        Me.txtUser_Phone.Size = New System.Drawing.Size(242, 22)
        Me.txtUser_Phone.TabIndex = 28
        '
        'txtUser_Address
        '
        Me.txtUser_Address.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_Address.Location = New System.Drawing.Point(127, 230)
        Me.txtUser_Address.Multiline = True
        Me.txtUser_Address.Name = "txtUser_Address"
        Me.txtUser_Address.Size = New System.Drawing.Size(436, 54)
        Me.txtUser_Address.TabIndex = 28
        '
        'txtUser_Last_Name_TH
        '
        Me.txtUser_Last_Name_TH.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_Last_Name_TH.Location = New System.Drawing.Point(127, 145)
        Me.txtUser_Last_Name_TH.Name = "txtUser_Last_Name_TH"
        Me.txtUser_Last_Name_TH.Size = New System.Drawing.Size(242, 22)
        Me.txtUser_Last_Name_TH.TabIndex = 27
        '
        'txtUser_First_Name_TH
        '
        Me.txtUser_First_Name_TH.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_First_Name_TH.Location = New System.Drawing.Point(127, 119)
        Me.txtUser_First_Name_TH.Name = "txtUser_First_Name_TH"
        Me.txtUser_First_Name_TH.Size = New System.Drawing.Size(242, 22)
        Me.txtUser_First_Name_TH.TabIndex = 26
        '
        'txtUser_Last_Name_EN
        '
        Me.txtUser_Last_Name_EN.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_Last_Name_EN.Location = New System.Drawing.Point(127, 91)
        Me.txtUser_Last_Name_EN.Name = "txtUser_Last_Name_EN"
        Me.txtUser_Last_Name_EN.Size = New System.Drawing.Size(242, 22)
        Me.txtUser_Last_Name_EN.TabIndex = 25
        '
        'txtUser_First_Name_EN
        '
        Me.txtUser_First_Name_EN.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_First_Name_EN.Location = New System.Drawing.Point(127, 63)
        Me.txtUser_First_Name_EN.Name = "txtUser_First_Name_EN"
        Me.txtUser_First_Name_EN.Size = New System.Drawing.Size(242, 22)
        Me.txtUser_First_Name_EN.TabIndex = 24
        '
        'txtUser_Name
        '
        Me.txtUser_Name.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtUser_Name.Location = New System.Drawing.Point(127, 35)
        Me.txtUser_Name.Name = "txtUser_Name"
        Me.txtUser_Name.Size = New System.Drawing.Size(242, 22)
        Me.txtUser_Name.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(23, 114)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 27)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ชื่อจริง(TH) :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CK_AutoHideMenu
        '
        Me.CK_AutoHideMenu.AutoSize = True
        Me.CK_AutoHideMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CK_AutoHideMenu.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.CK_AutoHideMenu.Location = New System.Drawing.Point(26, 447)
        Me.CK_AutoHideMenu.Margin = New System.Windows.Forms.Padding(4)
        Me.CK_AutoHideMenu.Name = "CK_AutoHideMenu"
        Me.CK_AutoHideMenu.Size = New System.Drawing.Size(154, 20)
        Me.CK_AutoHideMenu.TabIndex = 22
        Me.CK_AutoHideMenu.Text = "Auto Hide Main Menu"
        Me.CK_AutoHideMenu.UseVisualStyleBackColor = True
        Me.CK_AutoHideMenu.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 141)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 27)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "นามสกุลจริง(TH) :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(744, 117)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 38)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "ยกเลิก"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancel.UseVisualStyleBackColor = True
        Me.cmdCancel.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(744, 160)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 40)
        Me.cmdSave.TabIndex = 8
        Me.cmdSave.Text = "บันทึก"
        Me.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSave.UseVisualStyleBackColor = True
        Me.cmdSave.Visible = False
        '
        'cmdEdit
        '
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(744, 35)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(92, 36)
        Me.cmdEdit.TabIndex = 7
        Me.cmdEdit.Text = "แก้ไข"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEdit.UseVisualStyleBackColor = True
        Me.cmdEdit.Visible = False
        '
        'pMain
        '
        Me.pMain.BackColor = System.Drawing.Color.Gray
        Me.pMain.Controls.Add(Me.cmdCancel)
        Me.pMain.Controls.Add(Me.Panel1)
        Me.pMain.Controls.Add(Me.cmdSave)
        Me.pMain.Controls.Add(Me.cmdEdit)
        Me.pMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pMain.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.pMain.Location = New System.Drawing.Point(0, 0)
        Me.pMain.Name = "pMain"
        Me.pMain.Size = New System.Drawing.Size(591, 447)
        Me.pMain.TabIndex = 3
        '
        'frmProfile_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(591, 447)
        Me.Controls.Add(Me.pMain)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmProfile_User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUserProfile"
        Me.GrpChangePWD.ResumeLayout(False)
        Me.GrpChangePWD.PerformLayout()
        CType(Me.ImgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImgUser As System.Windows.Forms.PictureBox
    Friend WithEvents txtNewPWD As System.Windows.Forms.TextBox
    Friend WithEvents txtOldPWD As System.Windows.Forms.TextBox
    Friend WithEvents lbPosition As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbDepartMent As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmdChangePWD As System.Windows.Forms.Button
    Friend WithEvents txtConfirmPWD As System.Windows.Forms.TextBox
    Friend WithEvents GrpChangePWD As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpLoadImg As System.Windows.Forms.Button
    Friend WithEvents DLGOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbUserID As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CK_AutoHideMenu As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pMain As System.Windows.Forms.Panel
    Friend WithEvents txtUser_Last_Name_TH As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_First_Name_TH As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_Last_Name_EN As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_First_Name_EN As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_Name As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_Phone As System.Windows.Forms.TextBox
    Friend WithEvents txtUser_Address As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
