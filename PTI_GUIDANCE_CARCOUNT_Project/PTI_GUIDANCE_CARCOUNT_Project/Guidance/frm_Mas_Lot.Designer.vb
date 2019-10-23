<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Mas_Lot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Mas_Lot))
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.lbl_Floor = New System.Windows.Forms.Label()
        Me.lbl_FloorController = New System.Windows.Forms.Label()
        Me.lbl_PositionX = New System.Windows.Forms.Label()
        Me.lbl_PositionY = New System.Windows.Forms.Label()
        Me.lbl_Time_Last = New System.Windows.Forms.Label()
        Me.lbl_House = New System.Windows.Forms.Label()
        Me.lbl_Minute = New System.Windows.Forms.Label()
        Me.lbl_Car_ID = New System.Windows.Forms.Label()
        Me.lbl_Zone = New System.Windows.Forms.Label()
        Me.lbl_Status_Sensor = New System.Windows.Forms.Label()
        Me.lbl_Remark = New System.Windows.Forms.Label()
        Me.lbl_Lot_Id = New System.Windows.Forms.Label()
        Me.txt_Lot_Name = New System.Windows.Forms.TextBox()
        Me.cmb_Floor_Name = New System.Windows.Forms.ComboBox()
        Me.cmb_Floorcontroller_Name = New System.Windows.Forms.ComboBox()
        Me.txt_Position_X = New System.Windows.Forms.TextBox()
        Me.txt_Position_Y = New System.Windows.Forms.TextBox()
        Me.txt_Car_ID = New System.Windows.Forms.TextBox()
        Me.txt_Remark = New System.Windows.Forms.TextBox()
        Me.txt_Minute = New System.Windows.Forms.TextBox()
        Me.txt_House = New System.Windows.Forms.TextBox()
        Me.grp_Control = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTowerId = New System.Windows.Forms.ComboBox()
        Me.dtp_Time_Change = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Date_Change = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Add_FloorController = New System.Windows.Forms.Label()
        Me.txt_Address_Controller = New System.Windows.Forms.TextBox()
        Me.lbl_Add_Sensor = New System.Windows.Forms.Label()
        Me.txt_Address_Sensor = New System.Windows.Forms.TextBox()
        Me.lbl_Type = New System.Windows.Forms.Label()
        Me.cbo_Alam_Name = New System.Windows.Forms.ComboBox()
        Me.lbl_Status_Parking = New System.Windows.Forms.Label()
        Me.cmb_Status_Name = New System.Windows.Forms.ComboBox()
        Me.grp_Status = New System.Windows.Forms.GroupBox()
        Me.cmb_Zone = New System.Windows.Forms.ComboBox()
        Me.cmb_Mas_Controller = New System.Windows.Forms.ComboBox()
        Me.btn_Add = New System.Windows.Forms.Button()
        Me.img_Add = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.img_Delete = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Pic = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.img_SaveAdd = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList11 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.img_Close = New System.Windows.Forms.ImageList(Me.components)
        Me.grb_Search = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTowerId2 = New System.Windows.Forms.ComboBox()
        Me.lbl_Start = New System.Windows.Forms.Label()
        Me.chk_Time = New System.Windows.Forms.CheckBox()
        Me.btn_All = New System.Windows.Forms.Button()
        Me.btn_Hild = New System.Windows.Forms.Button()
        Me.btn_Search1 = New System.Windows.Forms.Button()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.dtp_Time_Stop = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Date_Stop = New System.Windows.Forms.DateTimePicker()
        Me.cmb_Search_Sensor = New System.Windows.Forms.ComboBox()
        Me.lbl_S_Status_Connect = New System.Windows.Forms.Label()
        Me.cmb_Search_Alam = New System.Windows.Forms.ComboBox()
        Me.lbl_S_Type = New System.Windows.Forms.Label()
        Me.cmb_Search_Status = New System.Windows.Forms.ComboBox()
        Me.lbl_S_Status_Parking = New System.Windows.Forms.Label()
        Me.dtp_Time_Start = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Date_Start = New System.Windows.Forms.DateTimePicker()
        Me.lbl_S_Time_Last = New System.Windows.Forms.Label()
        Me.cmb_Search_Controller = New System.Windows.Forms.ComboBox()
        Me.lbl_S_FloorController = New System.Windows.Forms.Label()
        Me.cmb_Search_Floor = New System.Windows.Forms.ComboBox()
        Me.lbl_S_Floor = New System.Windows.Forms.Label()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.lbl_S_Name = New System.Windows.Forms.Label()
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.Dgv_Lot = New System.Windows.Forms.DataGridView()
        Me.grp_Control.SuspendLayout()
        Me.grp_Status.SuspendLayout()
        Me.grb_Search.SuspendLayout()
        CType(Me.Dgv_Lot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(6, 22)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(71, 21)
        Me.lbl_T_ID.TabIndex = 0
        Me.lbl_T_ID.Text = "รหัสอุปกรณ์"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Name
        '
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_Name.Location = New System.Drawing.Point(173, 23)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(55, 19)
        Me.lbl_Name.TabIndex = 1
        Me.lbl_Name.Text = "ชื่ออุปกรณ์"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Floor
        '
        Me.lbl_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor.Location = New System.Drawing.Point(418, 24)
        Me.lbl_Floor.Name = "lbl_Floor"
        Me.lbl_Floor.Size = New System.Drawing.Size(37, 16)
        Me.lbl_Floor.TabIndex = 2
        Me.lbl_Floor.Text = "ชั้น"
        Me.lbl_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_FloorController
        '
        Me.lbl_FloorController.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FloorController.ForeColor = System.Drawing.Color.Black
        Me.lbl_FloorController.Location = New System.Drawing.Point(565, 23)
        Me.lbl_FloorController.Name = "lbl_FloorController"
        Me.lbl_FloorController.Size = New System.Drawing.Size(120, 19)
        Me.lbl_FloorController.TabIndex = 3
        Me.lbl_FloorController.Text = "อุปกรณ์ควบคุมตามชั้น"
        '
        'lbl_PositionX
        '
        Me.lbl_PositionX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_PositionX.ForeColor = System.Drawing.Color.Black
        Me.lbl_PositionX.Location = New System.Drawing.Point(12, 54)
        Me.lbl_PositionX.Name = "lbl_PositionX"
        Me.lbl_PositionX.Size = New System.Drawing.Size(77, 16)
        Me.lbl_PositionX.TabIndex = 4
        Me.lbl_PositionX.Text = "ตำแหน่งแกน X"
        '
        'lbl_PositionY
        '
        Me.lbl_PositionY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_PositionY.ForeColor = System.Drawing.Color.Black
        Me.lbl_PositionY.Location = New System.Drawing.Point(162, 54)
        Me.lbl_PositionY.Name = "lbl_PositionY"
        Me.lbl_PositionY.Size = New System.Drawing.Size(78, 16)
        Me.lbl_PositionY.TabIndex = 5
        Me.lbl_PositionY.Text = "ตำแหน่งแกน Y"
        '
        'lbl_Time_Last
        '
        Me.lbl_Time_Last.AutoSize = True
        Me.lbl_Time_Last.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Time_Last.ForeColor = System.Drawing.Color.Black
        Me.lbl_Time_Last.Location = New System.Drawing.Point(333, 54)
        Me.lbl_Time_Last.Name = "lbl_Time_Last"
        Me.lbl_Time_Last.Size = New System.Drawing.Size(170, 16)
        Me.lbl_Time_Last.TabIndex = 6
        Me.lbl_Time_Last.Text = "เวลาที่มีการเปลี่ยนแปลงสถานะล่าสุด"
        '
        'lbl_House
        '
        Me.lbl_House.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_House.ForeColor = System.Drawing.Color.Black
        Me.lbl_House.Location = New System.Drawing.Point(731, 54)
        Me.lbl_House.Name = "lbl_House"
        Me.lbl_House.Size = New System.Drawing.Size(82, 16)
        Me.lbl_House.TabIndex = 7
        Me.lbl_House.Text = "เวลาจอด ชม."
        Me.lbl_House.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Minute
        '
        Me.lbl_Minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Minute.ForeColor = System.Drawing.Color.Black
        Me.lbl_Minute.Location = New System.Drawing.Point(862, 54)
        Me.lbl_Minute.Name = "lbl_Minute"
        Me.lbl_Minute.Size = New System.Drawing.Size(70, 16)
        Me.lbl_Minute.TabIndex = 8
        Me.lbl_Minute.Text = "เวลาจอด นาที"
        Me.lbl_Minute.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Car_ID
        '
        Me.lbl_Car_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Car_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_Car_ID.Location = New System.Drawing.Point(303, 50)
        Me.lbl_Car_ID.Name = "lbl_Car_ID"
        Me.lbl_Car_ID.Size = New System.Drawing.Size(132, 16)
        Me.lbl_Car_ID.TabIndex = 13
        Me.lbl_Car_ID.Text = "ทะเบียนรถที่สามารถจอดได้"
        '
        'lbl_Zone
        '
        Me.lbl_Zone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Zone.ForeColor = System.Drawing.Color.Black
        Me.lbl_Zone.Location = New System.Drawing.Point(567, 23)
        Me.lbl_Zone.Name = "lbl_Zone"
        Me.lbl_Zone.Size = New System.Drawing.Size(106, 16)
        Me.lbl_Zone.TabIndex = 15
        Me.lbl_Zone.Text = "โซนอุปกรณ์ตรวจสอบ"
        '
        'lbl_Status_Sensor
        '
        Me.lbl_Status_Sensor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Status_Sensor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_Sensor.Location = New System.Drawing.Point(11, 79)
        Me.lbl_Status_Sensor.Name = "lbl_Status_Sensor"
        Me.lbl_Status_Sensor.Size = New System.Drawing.Size(171, 16)
        Me.lbl_Status_Sensor.TabIndex = 16
        Me.lbl_Status_Sensor.Text = "สถานะการเชื่อมต่ออุปกรณ์ตรวจสอบ"
        '
        'lbl_Remark
        '
        Me.lbl_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Remark.ForeColor = System.Drawing.Color.Black
        Me.lbl_Remark.Location = New System.Drawing.Point(424, 79)
        Me.lbl_Remark.Name = "lbl_Remark"
        Me.lbl_Remark.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Remark.TabIndex = 17
        Me.lbl_Remark.Text = "หมายเหตุ"
        Me.lbl_Remark.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Lot_Id
        '
        Me.lbl_Lot_Id.BackColor = System.Drawing.Color.Black
        Me.lbl_Lot_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Lot_Id.ForeColor = System.Drawing.Color.Red
        Me.lbl_Lot_Id.Location = New System.Drawing.Point(83, 17)
        Me.lbl_Lot_Id.Name = "lbl_Lot_Id"
        Me.lbl_Lot_Id.Size = New System.Drawing.Size(86, 31)
        Me.lbl_Lot_Id.TabIndex = 18
        Me.lbl_Lot_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Lot_Name
        '
        Me.txt_Lot_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Lot_Name.ForeColor = System.Drawing.Color.Blue
        Me.txt_Lot_Name.Location = New System.Drawing.Point(228, 21)
        Me.txt_Lot_Name.Name = "txt_Lot_Name"
        Me.txt_Lot_Name.Size = New System.Drawing.Size(181, 22)
        Me.txt_Lot_Name.TabIndex = 0
        '
        'cmb_Floor_Name
        '
        Me.cmb_Floor_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floor_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Floor_Name.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Floor_Name.FormattingEnabled = True
        Me.cmb_Floor_Name.Location = New System.Drawing.Point(455, 20)
        Me.cmb_Floor_Name.Name = "cmb_Floor_Name"
        Me.cmb_Floor_Name.Size = New System.Drawing.Size(105, 24)
        Me.cmb_Floor_Name.TabIndex = 1
        '
        'cmb_Floorcontroller_Name
        '
        Me.cmb_Floorcontroller_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floorcontroller_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Floorcontroller_Name.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Floorcontroller_Name.FormattingEnabled = True
        Me.cmb_Floorcontroller_Name.Location = New System.Drawing.Point(682, 20)
        Me.cmb_Floorcontroller_Name.Name = "cmb_Floorcontroller_Name"
        Me.cmb_Floorcontroller_Name.Size = New System.Drawing.Size(105, 24)
        Me.cmb_Floorcontroller_Name.TabIndex = 2
        '
        'txt_Position_X
        '
        Me.txt_Position_X.ForeColor = System.Drawing.Color.Blue
        Me.txt_Position_X.Location = New System.Drawing.Point(94, 51)
        Me.txt_Position_X.Name = "txt_Position_X"
        Me.txt_Position_X.Size = New System.Drawing.Size(62, 22)
        Me.txt_Position_X.TabIndex = 3
        Me.txt_Position_X.Text = "00"
        '
        'txt_Position_Y
        '
        Me.txt_Position_Y.ForeColor = System.Drawing.Color.Blue
        Me.txt_Position_Y.Location = New System.Drawing.Point(246, 51)
        Me.txt_Position_Y.Name = "txt_Position_Y"
        Me.txt_Position_Y.Size = New System.Drawing.Size(81, 22)
        Me.txt_Position_Y.TabIndex = 4
        Me.txt_Position_Y.Text = "00"
        '
        'txt_Car_ID
        '
        Me.txt_Car_ID.ForeColor = System.Drawing.Color.Blue
        Me.txt_Car_ID.Location = New System.Drawing.Point(441, 47)
        Me.txt_Car_ID.Name = "txt_Car_ID"
        Me.txt_Car_ID.Size = New System.Drawing.Size(119, 22)
        Me.txt_Car_ID.TabIndex = 12
        Me.txt_Car_ID.Text = "00"
        '
        'txt_Remark
        '
        Me.txt_Remark.ForeColor = System.Drawing.Color.Blue
        Me.txt_Remark.Location = New System.Drawing.Point(502, 76)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(339, 22)
        Me.txt_Remark.TabIndex = 16
        '
        'txt_Minute
        '
        Me.txt_Minute.ForeColor = System.Drawing.Color.Blue
        Me.txt_Minute.Location = New System.Drawing.Point(933, 51)
        Me.txt_Minute.Name = "txt_Minute"
        Me.txt_Minute.Size = New System.Drawing.Size(43, 22)
        Me.txt_Minute.TabIndex = 7
        Me.txt_Minute.Text = "00"
        '
        'txt_House
        '
        Me.txt_House.ForeColor = System.Drawing.Color.Blue
        Me.txt_House.Location = New System.Drawing.Point(819, 51)
        Me.txt_House.Name = "txt_House"
        Me.txt_House.Size = New System.Drawing.Size(37, 22)
        Me.txt_House.TabIndex = 6
        Me.txt_House.Text = "00"
        '
        'grp_Control
        '
        Me.grp_Control.Controls.Add(Me.Label1)
        Me.grp_Control.Controls.Add(Me.cboTowerId)
        Me.grp_Control.Controls.Add(Me.dtp_Time_Change)
        Me.grp_Control.Controls.Add(Me.dtp_Date_Change)
        Me.grp_Control.Controls.Add(Me.lbl_Time_Last)
        Me.grp_Control.Controls.Add(Me.lbl_Lot_Id)
        Me.grp_Control.Controls.Add(Me.txt_Minute)
        Me.grp_Control.Controls.Add(Me.lbl_T_ID)
        Me.grp_Control.Controls.Add(Me.txt_House)
        Me.grp_Control.Controls.Add(Me.txt_Lot_Name)
        Me.grp_Control.Controls.Add(Me.lbl_House)
        Me.grp_Control.Controls.Add(Me.lbl_Name)
        Me.grp_Control.Controls.Add(Me.lbl_Minute)
        Me.grp_Control.Controls.Add(Me.cmb_Floor_Name)
        Me.grp_Control.Controls.Add(Me.lbl_Floor)
        Me.grp_Control.Controls.Add(Me.cmb_Floorcontroller_Name)
        Me.grp_Control.Controls.Add(Me.lbl_FloorController)
        Me.grp_Control.Controls.Add(Me.txt_Position_X)
        Me.grp_Control.Controls.Add(Me.lbl_PositionX)
        Me.grp_Control.Controls.Add(Me.txt_Position_Y)
        Me.grp_Control.Controls.Add(Me.lbl_PositionY)
        Me.grp_Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grp_Control.ForeColor = System.Drawing.Color.Black
        Me.grp_Control.Location = New System.Drawing.Point(16, 12)
        Me.grp_Control.Name = "grp_Control"
        Me.grp_Control.Size = New System.Drawing.Size(1001, 86)
        Me.grp_Control.TabIndex = 36
        Me.grp_Control.TabStop = False
        Me.grp_Control.Text = "อุปกรณ์ตรวจสอบ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(790, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "สถานที่ :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTowerId
        '
        Me.cboTowerId.Enabled = False
        Me.cboTowerId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboTowerId.FormattingEnabled = True
        Me.cboTowerId.Location = New System.Drawing.Point(837, 20)
        Me.cboTowerId.Name = "cboTowerId"
        Me.cboTowerId.Size = New System.Drawing.Size(142, 24)
        Me.cboTowerId.TabIndex = 19
        '
        'dtp_Time_Change
        '
        Me.dtp_Time_Change.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Time_Change.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_Time_Change.Location = New System.Drawing.Point(607, 51)
        Me.dtp_Time_Change.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Time_Change.Name = "dtp_Time_Change"
        Me.dtp_Time_Change.ShowUpDown = True
        Me.dtp_Time_Change.Size = New System.Drawing.Size(98, 22)
        Me.dtp_Time_Change.TabIndex = 6
        '
        'dtp_Date_Change
        '
        Me.dtp_Date_Change.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Date_Change.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Date_Change.Location = New System.Drawing.Point(507, 51)
        Me.dtp_Date_Change.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Date_Change.Name = "dtp_Date_Change"
        Me.dtp_Date_Change.Size = New System.Drawing.Size(217, 22)
        Me.dtp_Date_Change.TabIndex = 5
        '
        'lbl_Add_FloorController
        '
        Me.lbl_Add_FloorController.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Add_FloorController.ForeColor = System.Drawing.Color.Black
        Me.lbl_Add_FloorController.Location = New System.Drawing.Point(11, 50)
        Me.lbl_Add_FloorController.Name = "lbl_Add_FloorController"
        Me.lbl_Add_FloorController.Size = New System.Drawing.Size(198, 16)
        Me.lbl_Add_FloorController.TabIndex = 12
        Me.lbl_Add_FloorController.Text = "ที่อยู่อุปกรณ์ควบคุมตามชั้น"
        Me.lbl_Add_FloorController.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Address_Controller
        '
        Me.txt_Address_Controller.ForeColor = System.Drawing.Color.Blue
        Me.txt_Address_Controller.Location = New System.Drawing.Point(215, 47)
        Me.txt_Address_Controller.Name = "txt_Address_Controller"
        Me.txt_Address_Controller.Size = New System.Drawing.Size(77, 22)
        Me.txt_Address_Controller.TabIndex = 11
        Me.txt_Address_Controller.Text = "4"
        '
        'lbl_Add_Sensor
        '
        Me.lbl_Add_Sensor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Add_Sensor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Add_Sensor.Location = New System.Drawing.Point(566, 50)
        Me.lbl_Add_Sensor.Name = "lbl_Add_Sensor"
        Me.lbl_Add_Sensor.Size = New System.Drawing.Size(107, 16)
        Me.lbl_Add_Sensor.TabIndex = 11
        Me.lbl_Add_Sensor.Text = "ที่อยู่อุปกรณ์ตรวจสอบ"
        '
        'txt_Address_Sensor
        '
        Me.txt_Address_Sensor.ForeColor = System.Drawing.Color.Blue
        Me.txt_Address_Sensor.Location = New System.Drawing.Point(679, 47)
        Me.txt_Address_Sensor.Name = "txt_Address_Sensor"
        Me.txt_Address_Sensor.Size = New System.Drawing.Size(162, 22)
        Me.txt_Address_Sensor.TabIndex = 10
        Me.txt_Address_Sensor.Text = "3"
        '
        'lbl_Type
        '
        Me.lbl_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Type.ForeColor = System.Drawing.Color.Black
        Me.lbl_Type.Location = New System.Drawing.Point(297, 20)
        Me.lbl_Type.Name = "lbl_Type"
        Me.lbl_Type.Size = New System.Drawing.Size(112, 16)
        Me.lbl_Type.TabIndex = 10
        Me.lbl_Type.Text = "ประเภทการจอดของรถ"
        '
        'cbo_Alam_Name
        '
        Me.cbo_Alam_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbo_Alam_Name.ForeColor = System.Drawing.Color.Blue
        Me.cbo_Alam_Name.FormattingEnabled = True
        Me.cbo_Alam_Name.Location = New System.Drawing.Point(413, 17)
        Me.cbo_Alam_Name.Name = "cbo_Alam_Name"
        Me.cbo_Alam_Name.Size = New System.Drawing.Size(147, 24)
        Me.cbo_Alam_Name.TabIndex = 9
        '
        'lbl_Status_Parking
        '
        Me.lbl_Status_Parking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Status_Parking.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_Parking.Location = New System.Drawing.Point(11, 23)
        Me.lbl_Status_Parking.Name = "lbl_Status_Parking"
        Me.lbl_Status_Parking.Size = New System.Drawing.Size(100, 18)
        Me.lbl_Status_Parking.TabIndex = 9
        Me.lbl_Status_Parking.Text = "สถานะการจอดรถ"
        Me.lbl_Status_Parking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Status_Name
        '
        Me.cmb_Status_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Status_Name.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Status_Name.FormattingEnabled = True
        Me.cmb_Status_Name.Location = New System.Drawing.Point(117, 17)
        Me.cmb_Status_Name.Name = "cmb_Status_Name"
        Me.cmb_Status_Name.Size = New System.Drawing.Size(174, 24)
        Me.cmb_Status_Name.TabIndex = 8
        '
        'grp_Status
        '
        Me.grp_Status.Controls.Add(Me.cmb_Zone)
        Me.grp_Status.Controls.Add(Me.cmb_Mas_Controller)
        Me.grp_Status.Controls.Add(Me.cmb_Status_Name)
        Me.grp_Status.Controls.Add(Me.lbl_Status_Parking)
        Me.grp_Status.Controls.Add(Me.cbo_Alam_Name)
        Me.grp_Status.Controls.Add(Me.txt_Remark)
        Me.grp_Status.Controls.Add(Me.lbl_Remark)
        Me.grp_Status.Controls.Add(Me.lbl_Status_Sensor)
        Me.grp_Status.Controls.Add(Me.lbl_Type)
        Me.grp_Status.Controls.Add(Me.txt_Address_Sensor)
        Me.grp_Status.Controls.Add(Me.lbl_Add_Sensor)
        Me.grp_Status.Controls.Add(Me.lbl_Zone)
        Me.grp_Status.Controls.Add(Me.txt_Address_Controller)
        Me.grp_Status.Controls.Add(Me.txt_Car_ID)
        Me.grp_Status.Controls.Add(Me.lbl_Add_FloorController)
        Me.grp_Status.Controls.Add(Me.lbl_Car_ID)
        Me.grp_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grp_Status.ForeColor = System.Drawing.Color.Black
        Me.grp_Status.Location = New System.Drawing.Point(16, 104)
        Me.grp_Status.Name = "grp_Status"
        Me.grp_Status.Size = New System.Drawing.Size(1001, 112)
        Me.grp_Status.TabIndex = 38
        Me.grp_Status.TabStop = False
        Me.grp_Status.Text = "สถานะอุปกรณ์ตรวจสอบ"
        '
        'cmb_Zone
        '
        Me.cmb_Zone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Zone.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Zone.FormattingEnabled = True
        Me.cmb_Zone.Location = New System.Drawing.Point(679, 17)
        Me.cmb_Zone.Name = "cmb_Zone"
        Me.cmb_Zone.Size = New System.Drawing.Size(163, 24)
        Me.cmb_Zone.TabIndex = 14
        '
        'cmb_Mas_Controller
        '
        Me.cmb_Mas_Controller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Mas_Controller.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Mas_Controller.FormattingEnabled = True
        Me.cmb_Mas_Controller.Location = New System.Drawing.Point(188, 75)
        Me.cmb_Mas_Controller.Name = "cmb_Mas_Controller"
        Me.cmb_Mas_Controller.Size = New System.Drawing.Size(234, 24)
        Me.cmb_Mas_Controller.TabIndex = 15
        '
        'btn_Add
        '
        Me.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Add.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Add.ImageIndex = 0
        Me.btn_Add.ImageList = Me.img_Add
        Me.btn_Add.Location = New System.Drawing.Point(520, 673)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(94, 50)
        Me.btn_Add.TabIndex = 19
        Me.btn_Add.Text = "เพิ่ม"
        Me.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'img_Add
        '
        Me.img_Add.ImageStream = CType(resources.GetObject("img_Add.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Add.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Add.Images.SetKeyName(0, "Add.png")
        '
        'btn_Edit
        '
        Me.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit.ImageIndex = 0
        Me.btn_Edit.ImageList = Me.img_Edit
        Me.btn_Edit.Location = New System.Drawing.Point(826, 673)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(94, 50)
        Me.btn_Edit.TabIndex = 20
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
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel.ImageIndex = 0
        Me.btn_Cancel.ImageList = Me.img_Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(928, 672)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(94, 50)
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
        'btn_Delete
        '
        Me.btn_Delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Delete.ImageIndex = 0
        Me.btn_Delete.ImageList = Me.img_Delete
        Me.btn_Delete.Location = New System.Drawing.Point(622, 673)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(94, 50)
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
        'img_Search
        '
        Me.img_Search.ImageStream = CType(resources.GetObject("img_Search.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Search.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Search.Images.SetKeyName(0, "zippo 015.png")
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
        'ImageList11
        '
        Me.ImageList11.ImageStream = CType(resources.GetObject("ImageList11.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList11.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList11.Images.SetKeyName(0, "Applications.png")
        '
        'btn_Close
        '
        Me.btn_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Close.ForeColor = System.Drawing.Color.Red
        Me.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Close.ImageIndex = 0
        Me.btn_Close.ImageList = Me.img_Close
        Me.btn_Close.Location = New System.Drawing.Point(1158, 717)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(82, 50)
        Me.btn_Close.TabIndex = 40
        Me.btn_Close.Text = "ปิด"
        Me.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'img_Close
        '
        Me.img_Close.ImageStream = CType(resources.GetObject("img_Close.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Close.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Close.Images.SetKeyName(0, "TurnOFF.JPG")
        '
        'grb_Search
        '
        Me.grb_Search.BackColor = System.Drawing.Color.Lavender
        Me.grb_Search.Controls.Add(Me.Label2)
        Me.grb_Search.Controls.Add(Me.cboTowerId2)
        Me.grb_Search.Controls.Add(Me.lbl_Start)
        Me.grb_Search.Controls.Add(Me.chk_Time)
        Me.grb_Search.Controls.Add(Me.btn_All)
        Me.grb_Search.Controls.Add(Me.btn_Hild)
        Me.grb_Search.Controls.Add(Me.btn_Search1)
        Me.grb_Search.Controls.Add(Me.lbl_To)
        Me.grb_Search.Controls.Add(Me.dtp_Time_Stop)
        Me.grb_Search.Controls.Add(Me.dtp_Date_Stop)
        Me.grb_Search.Controls.Add(Me.cmb_Search_Sensor)
        Me.grb_Search.Controls.Add(Me.lbl_S_Status_Connect)
        Me.grb_Search.Controls.Add(Me.cmb_Search_Alam)
        Me.grb_Search.Controls.Add(Me.lbl_S_Type)
        Me.grb_Search.Controls.Add(Me.cmb_Search_Status)
        Me.grb_Search.Controls.Add(Me.lbl_S_Status_Parking)
        Me.grb_Search.Controls.Add(Me.dtp_Time_Start)
        Me.grb_Search.Controls.Add(Me.dtp_Date_Start)
        Me.grb_Search.Controls.Add(Me.lbl_S_Time_Last)
        Me.grb_Search.Controls.Add(Me.cmb_Search_Controller)
        Me.grb_Search.Controls.Add(Me.lbl_S_FloorController)
        Me.grb_Search.Controls.Add(Me.cmb_Search_Floor)
        Me.grb_Search.Controls.Add(Me.lbl_S_Floor)
        Me.grb_Search.Controls.Add(Me.txt_Name)
        Me.grb_Search.Controls.Add(Me.lbl_S_Name)
        Me.grb_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.grb_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grb_Search.ForeColor = System.Drawing.Color.Black
        Me.grb_Search.Location = New System.Drawing.Point(304, 251)
        Me.grb_Search.Name = "grb_Search"
        Me.grb_Search.Size = New System.Drawing.Size(397, 324)
        Me.grb_Search.TabIndex = 41
        Me.grb_Search.TabStop = False
        Me.grb_Search.Text = "ค้นหาข้อมูล"
        Me.grb_Search.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(169, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "สถานที่ :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTowerId2
        '
        Me.cboTowerId2.Enabled = False
        Me.cboTowerId2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboTowerId2.FormattingEnabled = True
        Me.cboTowerId2.Location = New System.Drawing.Point(216, 290)
        Me.cboTowerId2.Name = "cboTowerId2"
        Me.cboTowerId2.Size = New System.Drawing.Size(142, 24)
        Me.cboTowerId2.TabIndex = 29
        '
        'lbl_Start
        '
        Me.lbl_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Start.ForeColor = System.Drawing.Color.Black
        Me.lbl_Start.Location = New System.Drawing.Point(15, 143)
        Me.lbl_Start.Name = "lbl_Start"
        Me.lbl_Start.Size = New System.Drawing.Size(70, 16)
        Me.lbl_Start.TabIndex = 28
        Me.lbl_Start.Text = "จาก"
        Me.lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chk_Time
        '
        Me.chk_Time.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chk_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.chk_Time.Location = New System.Drawing.Point(271, 142)
        Me.chk_Time.Name = "chk_Time"
        Me.chk_Time.Size = New System.Drawing.Size(16, 20)
        Me.chk_Time.TabIndex = 27
        Me.chk_Time.UseVisualStyleBackColor = True
        '
        'btn_All
        '
        Me.btn_All.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_All.ForeColor = System.Drawing.Color.Black
        Me.btn_All.Location = New System.Drawing.Point(296, 83)
        Me.btn_All.Name = "btn_All"
        Me.btn_All.Size = New System.Drawing.Size(95, 50)
        Me.btn_All.TabIndex = 26
        Me.btn_All.Text = "ทั้งหมด"
        Me.btn_All.UseVisualStyleBackColor = True
        '
        'btn_Hild
        '
        Me.btn_Hild.BackColor = System.Drawing.Color.OrangeRed
        Me.btn_Hild.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Hild.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Hild.ForeColor = System.Drawing.Color.White
        Me.btn_Hild.Location = New System.Drawing.Point(364, 10)
        Me.btn_Hild.Name = "btn_Hild"
        Me.btn_Hild.Size = New System.Drawing.Size(25, 25)
        Me.btn_Hild.TabIndex = 25
        Me.btn_Hild.Text = "X"
        Me.btn_Hild.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Hild.UseVisualStyleBackColor = False
        '
        'btn_Search1
        '
        Me.btn_Search1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Search1.ForeColor = System.Drawing.Color.Black
        Me.btn_Search1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search1.ImageIndex = 0
        Me.btn_Search1.ImageList = Me.img_Search
        Me.btn_Search1.Location = New System.Drawing.Point(296, 139)
        Me.btn_Search1.Name = "btn_Search1"
        Me.btn_Search1.Size = New System.Drawing.Size(95, 50)
        Me.btn_Search1.TabIndex = 24
        Me.btn_Search1.Text = "ค้นหา"
        Me.btn_Search1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Search1.UseVisualStyleBackColor = True
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.Black
        Me.lbl_To.Location = New System.Drawing.Point(12, 173)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(75, 16)
        Me.lbl_To.TabIndex = 23
        Me.lbl_To.Text = "ถึง"
        Me.lbl_To.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtp_Time_Stop
        '
        Me.dtp_Time_Stop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Time_Stop.Enabled = False
        Me.dtp_Time_Stop.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_Time_Stop.Location = New System.Drawing.Point(164, 170)
        Me.dtp_Time_Stop.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Time_Stop.Name = "dtp_Time_Stop"
        Me.dtp_Time_Stop.ShowUpDown = True
        Me.dtp_Time_Stop.Size = New System.Drawing.Size(79, 22)
        Me.dtp_Time_Stop.TabIndex = 22
        '
        'dtp_Date_Stop
        '
        Me.dtp_Date_Stop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Date_Stop.Enabled = False
        Me.dtp_Date_Stop.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Date_Stop.Location = New System.Drawing.Point(90, 170)
        Me.dtp_Date_Stop.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Date_Stop.Name = "dtp_Date_Stop"
        Me.dtp_Date_Stop.Size = New System.Drawing.Size(174, 22)
        Me.dtp_Date_Stop.TabIndex = 21
        '
        'cmb_Search_Sensor
        '
        Me.cmb_Search_Sensor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Search_Sensor.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Search_Sensor.FormattingEnabled = True
        Me.cmb_Search_Sensor.Location = New System.Drawing.Point(259, 260)
        Me.cmb_Search_Sensor.Name = "cmb_Search_Sensor"
        Me.cmb_Search_Sensor.Size = New System.Drawing.Size(99, 24)
        Me.cmb_Search_Sensor.TabIndex = 19
        '
        'lbl_S_Status_Connect
        '
        Me.lbl_S_Status_Connect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_S_Status_Connect.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_Status_Connect.Location = New System.Drawing.Point(6, 264)
        Me.lbl_S_Status_Connect.Name = "lbl_S_Status_Connect"
        Me.lbl_S_Status_Connect.Size = New System.Drawing.Size(246, 16)
        Me.lbl_S_Status_Connect.TabIndex = 20
        Me.lbl_S_Status_Connect.Text = "สถานะการเชื่อมต่ออุปกรณ์ตรวจสอบ"
        Me.lbl_S_Status_Connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Search_Alam
        '
        Me.cmb_Search_Alam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Search_Alam.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Search_Alam.FormattingEnabled = True
        Me.cmb_Search_Alam.Location = New System.Drawing.Point(201, 230)
        Me.cmb_Search_Alam.Name = "cmb_Search_Alam"
        Me.cmb_Search_Alam.Size = New System.Drawing.Size(157, 24)
        Me.cmb_Search_Alam.TabIndex = 13
        '
        'lbl_S_Type
        '
        Me.lbl_S_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_S_Type.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_Type.Location = New System.Drawing.Point(9, 234)
        Me.lbl_S_Type.Name = "lbl_S_Type"
        Me.lbl_S_Type.Size = New System.Drawing.Size(185, 16)
        Me.lbl_S_Type.TabIndex = 14
        Me.lbl_S_Type.Text = "ประเภทการจอดของรถ"
        Me.lbl_S_Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Search_Status
        '
        Me.cmb_Search_Status.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Search_Status.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Search_Status.FormattingEnabled = True
        Me.cmb_Search_Status.Location = New System.Drawing.Point(163, 200)
        Me.cmb_Search_Status.Name = "cmb_Search_Status"
        Me.cmb_Search_Status.Size = New System.Drawing.Size(195, 24)
        Me.cmb_Search_Status.TabIndex = 11
        '
        'lbl_S_Status_Parking
        '
        Me.lbl_S_Status_Parking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_S_Status_Parking.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_Status_Parking.Location = New System.Drawing.Point(9, 204)
        Me.lbl_S_Status_Parking.Name = "lbl_S_Status_Parking"
        Me.lbl_S_Status_Parking.Size = New System.Drawing.Size(146, 16)
        Me.lbl_S_Status_Parking.TabIndex = 12
        Me.lbl_S_Status_Parking.Text = "สถานะการจอด"
        Me.lbl_S_Status_Parking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtp_Time_Start
        '
        Me.dtp_Time_Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Time_Start.Enabled = False
        Me.dtp_Time_Start.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_Time_Start.Location = New System.Drawing.Point(167, 140)
        Me.dtp_Time_Start.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Time_Start.Name = "dtp_Time_Start"
        Me.dtp_Time_Start.ShowUpDown = True
        Me.dtp_Time_Start.Size = New System.Drawing.Size(76, 22)
        Me.dtp_Time_Start.TabIndex = 10
        '
        'dtp_Date_Start
        '
        Me.dtp_Date_Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Date_Start.Enabled = False
        Me.dtp_Date_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Date_Start.Location = New System.Drawing.Point(92, 140)
        Me.dtp_Date_Start.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Date_Start.Name = "dtp_Date_Start"
        Me.dtp_Date_Start.Size = New System.Drawing.Size(172, 22)
        Me.dtp_Date_Start.TabIndex = 8
        '
        'lbl_S_Time_Last
        '
        Me.lbl_S_Time_Last.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_S_Time_Last.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_Time_Last.Location = New System.Drawing.Point(12, 120)
        Me.lbl_S_Time_Last.Name = "lbl_S_Time_Last"
        Me.lbl_S_Time_Last.Size = New System.Drawing.Size(252, 16)
        Me.lbl_S_Time_Last.TabIndex = 9
        Me.lbl_S_Time_Last.Text = "เวลาที่มีการเปลี่ยนแปลงสถานะล่าสุด"
        Me.lbl_S_Time_Last.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Search_Controller
        '
        Me.cmb_Search_Controller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Search_Controller.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Search_Controller.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Search_Controller.FormattingEnabled = True
        Me.cmb_Search_Controller.Location = New System.Drawing.Point(145, 83)
        Me.cmb_Search_Controller.Name = "cmb_Search_Controller"
        Me.cmb_Search_Controller.Size = New System.Drawing.Size(109, 24)
        Me.cmb_Search_Controller.TabIndex = 6
        '
        'lbl_S_FloorController
        '
        Me.lbl_S_FloorController.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_S_FloorController.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_FloorController.Location = New System.Drawing.Point(6, 87)
        Me.lbl_S_FloorController.Name = "lbl_S_FloorController"
        Me.lbl_S_FloorController.Size = New System.Drawing.Size(137, 16)
        Me.lbl_S_FloorController.TabIndex = 7
        Me.lbl_S_FloorController.Text = "อุปกรณ์ควบคุม"
        Me.lbl_S_FloorController.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Search_Floor
        '
        Me.cmb_Search_Floor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Search_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Search_Floor.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Search_Floor.FormattingEnabled = True
        Me.cmb_Search_Floor.Location = New System.Drawing.Point(127, 53)
        Me.cmb_Search_Floor.Name = "cmb_Search_Floor"
        Me.cmb_Search_Floor.Size = New System.Drawing.Size(127, 24)
        Me.cmb_Search_Floor.TabIndex = 4
        '
        'lbl_S_Floor
        '
        Me.lbl_S_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_S_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_Floor.Location = New System.Drawing.Point(9, 57)
        Me.lbl_S_Floor.Name = "lbl_S_Floor"
        Me.lbl_S_Floor.Size = New System.Drawing.Size(115, 16)
        Me.lbl_S_Floor.TabIndex = 5
        Me.lbl_S_Floor.Text = "ชั้นที่ติดตั้ง"
        Me.lbl_S_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Name
        '
        Me.txt_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Name.ForeColor = System.Drawing.Color.Blue
        Me.txt_Name.Location = New System.Drawing.Point(126, 25)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(128, 22)
        Me.txt_Name.TabIndex = 2
        '
        'lbl_S_Name
        '
        Me.lbl_S_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_S_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_S_Name.Location = New System.Drawing.Point(6, 28)
        Me.lbl_S_Name.Name = "lbl_S_Name"
        Me.lbl_S_Name.Size = New System.Drawing.Size(116, 16)
        Me.lbl_S_Name.TabIndex = 3
        Me.lbl_S_Name.Text = "ชื่ออุปกรณ์"
        Me.lbl_S_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Search
        '
        Me.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Search.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search.ImageIndex = 0
        Me.btn_Search.ImageList = Me.img_Search
        Me.btn_Search.Location = New System.Drawing.Point(724, 673)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(94, 50)
        Me.btn_Search.TabIndex = 42
        Me.btn_Search.Text = "ค้นหา"
        Me.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'Dgv_Lot
        '
        Me.Dgv_Lot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Lot.Location = New System.Drawing.Point(5, 222)
        Me.Dgv_Lot.Name = "Dgv_Lot"
        Me.Dgv_Lot.ReadOnly = True
        Me.Dgv_Lot.Size = New System.Drawing.Size(1012, 445)
        Me.Dgv_Lot.TabIndex = 43
        '
        'frm_Mas_Lot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1034, 734)
        Me.Controls.Add(Me.grb_Search)
        Me.Controls.Add(Me.Dgv_Lot)
        Me.Controls.Add(Me.btn_Search)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.grp_Status)
        Me.Controls.Add(Me.grp_Control)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Mas_Lot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ตั้งค่าอุปกรณ์ตรวจสอบ"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_Control.ResumeLayout(False)
        Me.grp_Control.PerformLayout()
        Me.grp_Status.ResumeLayout(False)
        Me.grp_Status.PerformLayout()
        Me.grb_Search.ResumeLayout(False)
        Me.grb_Search.PerformLayout()
        CType(Me.Dgv_Lot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Floor As System.Windows.Forms.Label
    Friend WithEvents lbl_FloorController As System.Windows.Forms.Label
    Friend WithEvents lbl_PositionX As System.Windows.Forms.Label
    Friend WithEvents lbl_PositionY As System.Windows.Forms.Label
    Friend WithEvents lbl_Time_Last As System.Windows.Forms.Label
    Friend WithEvents lbl_House As System.Windows.Forms.Label
    Friend WithEvents lbl_Minute As System.Windows.Forms.Label
    Friend WithEvents lbl_Car_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_Zone As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_Sensor As System.Windows.Forms.Label
    Friend WithEvents lbl_Remark As System.Windows.Forms.Label
    Friend WithEvents lbl_Lot_Id As System.Windows.Forms.Label
    Friend WithEvents txt_Lot_Name As System.Windows.Forms.TextBox
    Friend WithEvents cmb_Floor_Name As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Floorcontroller_Name As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Position_X As System.Windows.Forms.TextBox
    Friend WithEvents txt_Position_Y As System.Windows.Forms.TextBox
    Friend WithEvents txt_Car_ID As System.Windows.Forms.TextBox
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents txt_Minute As System.Windows.Forms.TextBox
    Friend WithEvents txt_House As System.Windows.Forms.TextBox
    Friend WithEvents grp_Control As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Add_FloorController As System.Windows.Forms.Label
    Friend WithEvents txt_Address_Controller As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Add_Sensor As System.Windows.Forms.Label
    Friend WithEvents txt_Address_Sensor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Type As System.Windows.Forms.Label
    Friend WithEvents cbo_Alam_Name As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Status_Parking As System.Windows.Forms.Label
    Friend WithEvents cmb_Status_Name As System.Windows.Forms.ComboBox
    Friend WithEvents grp_Status As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_Zone As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Mas_Controller As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents dtp_Date_Change As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Time_Change As System.Windows.Forms.DateTimePicker
    Friend WithEvents img_Add As System.Windows.Forms.ImageList
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
    Friend WithEvents img_Pic As System.Windows.Forms.ImageList
    Friend WithEvents img_Delete As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_SaveAdd As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents btn_Close As System.Windows.Forms.Button
    Friend WithEvents ImageList11 As System.Windows.Forms.ImageList
    Friend WithEvents img_Close As System.Windows.Forms.ImageList
    Friend WithEvents grb_Search As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_Search_Controller As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_S_FloorController As System.Windows.Forms.Label
    Friend WithEvents cmb_Search_Floor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_S_Floor As System.Windows.Forms.Label
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_Name As System.Windows.Forms.Label
    Friend WithEvents cmb_Search_Sensor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_S_Status_Connect As System.Windows.Forms.Label
    Friend WithEvents cmb_Search_Alam As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_S_Type As System.Windows.Forms.Label
    Friend WithEvents cmb_Search_Status As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_S_Status_Parking As System.Windows.Forms.Label
    Friend WithEvents dtp_Time_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Date_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_S_Time_Last As System.Windows.Forms.Label
    Friend WithEvents dtp_Time_Stop As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Date_Stop As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_To As System.Windows.Forms.Label
    Friend WithEvents btn_Search1 As System.Windows.Forms.Button
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents btn_Hild As System.Windows.Forms.Button
    Friend WithEvents btn_All As System.Windows.Forms.Button
    Friend WithEvents chk_Time As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Start As System.Windows.Forms.Label
    Friend WithEvents Dgv_Lot As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTowerId As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTowerId2 As System.Windows.Forms.ComboBox
End Class
