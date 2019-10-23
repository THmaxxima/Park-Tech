<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Location_Detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Location_Detail))
        Me.grp_Status = New System.Windows.Forms.GroupBox()
        Me.cmb_Zone = New System.Windows.Forms.ComboBox()
        Me.cmb_Mas_Controller = New System.Windows.Forms.ComboBox()
        Me.cmb_Status_Name = New System.Windows.Forms.ComboBox()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.cbo_Alam_Name = New System.Windows.Forms.ComboBox()
        Me.txt_Remark = New System.Windows.Forms.TextBox()
        Me.lbl_Remark = New System.Windows.Forms.Label()
        Me.lbl_Status_Connect = New System.Windows.Forms.Label()
        Me.lbl_Type = New System.Windows.Forms.Label()
        Me.txt_Address_Sensor = New System.Windows.Forms.TextBox()
        Me.lbl_Address_Sensor = New System.Windows.Forms.Label()
        Me.txt_Address_Controller = New System.Windows.Forms.TextBox()
        Me.txt_Car_ID = New System.Windows.Forms.TextBox()
        Me.lbl_Address_FloorController = New System.Windows.Forms.Label()
        Me.lbl_Car_ID = New System.Windows.Forms.Label()
        Me.lbl_Zone = New System.Windows.Forms.Label()
        Me.grp_Control = New System.Windows.Forms.GroupBox()
        Me.lbl_MM = New System.Windows.Forms.Label()
        Me.lbl_HH = New System.Windows.Forms.Label()
        Me.lbl_Position_Y = New System.Windows.Forms.Label()
        Me.lbl_Position_X = New System.Windows.Forms.Label()
        Me.dtp_Time_Change = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Date_Change = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Change_Date = New System.Windows.Forms.Label()
        Me.lbl_Lot_Id = New System.Windows.Forms.Label()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.txt_Lot_Name = New System.Windows.Forms.TextBox()
        Me.lbl_House = New System.Windows.Forms.Label()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.lbl_Minute = New System.Windows.Forms.Label()
        Me.cmb_Floor_Name = New System.Windows.Forms.ComboBox()
        Me.lbl_Floor = New System.Windows.Forms.Label()
        Me.cmb_Floorcontroller_Name = New System.Windows.Forms.ComboBox()
        Me.lbl_FloorController = New System.Windows.Forms.Label()
        Me.lbl_P_X = New System.Windows.Forms.Label()
        Me.lbl_P_Y = New System.Windows.Forms.Label()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.img_Cancel = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.img_Edit = New System.Windows.Forms.ImageList(Me.components)
        Me.img_Save = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Search = New System.Windows.Forms.Button()
        Me.img_Search = New System.Windows.Forms.ImageList(Me.components)
        Me.grp_Status.SuspendLayout()
        Me.grp_Control.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_Status
        '
        Me.grp_Status.Controls.Add(Me.cmb_Zone)
        Me.grp_Status.Controls.Add(Me.cmb_Mas_Controller)
        Me.grp_Status.Controls.Add(Me.cmb_Status_Name)
        Me.grp_Status.Controls.Add(Me.lbl_Status)
        Me.grp_Status.Controls.Add(Me.cbo_Alam_Name)
        Me.grp_Status.Controls.Add(Me.txt_Remark)
        Me.grp_Status.Controls.Add(Me.lbl_Remark)
        Me.grp_Status.Controls.Add(Me.lbl_Status_Connect)
        Me.grp_Status.Controls.Add(Me.lbl_Type)
        Me.grp_Status.Controls.Add(Me.txt_Address_Sensor)
        Me.grp_Status.Controls.Add(Me.lbl_Address_Sensor)
        Me.grp_Status.Controls.Add(Me.txt_Address_Controller)
        Me.grp_Status.Controls.Add(Me.txt_Car_ID)
        Me.grp_Status.Controls.Add(Me.lbl_Address_FloorController)
        Me.grp_Status.Controls.Add(Me.lbl_Car_ID)
        Me.grp_Status.Controls.Add(Me.lbl_Zone)
        Me.grp_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grp_Status.ForeColor = System.Drawing.Color.Black
        Me.grp_Status.Location = New System.Drawing.Point(12, 158)
        Me.grp_Status.Name = "grp_Status"
        Me.grp_Status.Size = New System.Drawing.Size(751, 146)
        Me.grp_Status.TabIndex = 40
        Me.grp_Status.TabStop = False
        Me.grp_Status.Text = "สถานะ"
        '
        'cmb_Zone
        '
        Me.cmb_Zone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Zone.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Zone.FormattingEnabled = True
        Me.cmb_Zone.Location = New System.Drawing.Point(139, 55)
        Me.cmb_Zone.Name = "cmb_Zone"
        Me.cmb_Zone.Size = New System.Drawing.Size(178, 24)
        Me.cmb_Zone.TabIndex = 10
        '
        'cmb_Mas_Controller
        '
        Me.cmb_Mas_Controller.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Mas_Controller.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Mas_Controller.FormattingEnabled = True
        Me.cmb_Mas_Controller.Location = New System.Drawing.Point(537, 55)
        Me.cmb_Mas_Controller.Name = "cmb_Mas_Controller"
        Me.cmb_Mas_Controller.Size = New System.Drawing.Size(166, 24)
        Me.cmb_Mas_Controller.TabIndex = 11
        '
        'cmb_Status_Name
        '
        Me.cmb_Status_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Status_Name.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Status_Name.FormattingEnabled = True
        Me.cmb_Status_Name.Location = New System.Drawing.Point(97, 25)
        Me.cmb_Status_Name.Name = "cmb_Status_Name"
        Me.cmb_Status_Name.Size = New System.Drawing.Size(157, 24)
        Me.cmb_Status_Name.TabIndex = 8
        '
        'lbl_Status
        '
        Me.lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status.Location = New System.Drawing.Point(11, 26)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(86, 23)
        Me.lbl_Status.TabIndex = 9
        Me.lbl_Status.Text = "สถานะการจอด"
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_Alam_Name
        '
        Me.cbo_Alam_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbo_Alam_Name.ForeColor = System.Drawing.Color.Blue
        Me.cbo_Alam_Name.FormattingEnabled = True
        Me.cbo_Alam_Name.Location = New System.Drawing.Point(410, 25)
        Me.cbo_Alam_Name.Name = "cbo_Alam_Name"
        Me.cbo_Alam_Name.Size = New System.Drawing.Size(182, 24)
        Me.cbo_Alam_Name.TabIndex = 9
        '
        'txt_Remark
        '
        Me.txt_Remark.ForeColor = System.Drawing.Color.Blue
        Me.txt_Remark.Location = New System.Drawing.Point(103, 113)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(604, 22)
        Me.txt_Remark.TabIndex = 16
        '
        'lbl_Remark
        '
        Me.lbl_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Remark.ForeColor = System.Drawing.Color.Black
        Me.lbl_Remark.Location = New System.Drawing.Point(6, 110)
        Me.lbl_Remark.Name = "lbl_Remark"
        Me.lbl_Remark.Size = New System.Drawing.Size(91, 25)
        Me.lbl_Remark.TabIndex = 17
        Me.lbl_Remark.Text = "หมายเหตุ"
        Me.lbl_Remark.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Status_Connect
        '
        Me.lbl_Status_Connect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Status_Connect.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status_Connect.Location = New System.Drawing.Point(323, 57)
        Me.lbl_Status_Connect.Name = "lbl_Status_Connect"
        Me.lbl_Status_Connect.Size = New System.Drawing.Size(208, 21)
        Me.lbl_Status_Connect.TabIndex = 16
        Me.lbl_Status_Connect.Text = "สถานะการเชื่อมต่ออุปกรณ์ตรวจสอบ"
        Me.lbl_Status_Connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Type
        '
        Me.lbl_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Type.ForeColor = System.Drawing.Color.Black
        Me.lbl_Type.Location = New System.Drawing.Point(260, 27)
        Me.lbl_Type.Name = "lbl_Type"
        Me.lbl_Type.Size = New System.Drawing.Size(144, 21)
        Me.lbl_Type.TabIndex = 10
        Me.lbl_Type.Text = "ประเภทการจอดของรถ"
        Me.lbl_Type.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Address_Sensor
        '
        Me.txt_Address_Sensor.ForeColor = System.Drawing.Color.Blue
        Me.txt_Address_Sensor.Location = New System.Drawing.Point(366, 85)
        Me.txt_Address_Sensor.Name = "txt_Address_Sensor"
        Me.txt_Address_Sensor.Size = New System.Drawing.Size(67, 22)
        Me.txt_Address_Sensor.TabIndex = 14
        Me.txt_Address_Sensor.Text = "00"
        '
        'lbl_Address_Sensor
        '
        Me.lbl_Address_Sensor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Address_Sensor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Address_Sensor.Location = New System.Drawing.Point(232, 87)
        Me.lbl_Address_Sensor.Name = "lbl_Address_Sensor"
        Me.lbl_Address_Sensor.Size = New System.Drawing.Size(128, 19)
        Me.lbl_Address_Sensor.TabIndex = 11
        Me.lbl_Address_Sensor.Text = "ที่อยู่อุปกรณ์ตรวจสอบ"
        Me.lbl_Address_Sensor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Address_Controller
        '
        Me.txt_Address_Controller.ForeColor = System.Drawing.Color.Blue
        Me.txt_Address_Controller.Location = New System.Drawing.Point(625, 85)
        Me.txt_Address_Controller.Name = "txt_Address_Controller"
        Me.txt_Address_Controller.Size = New System.Drawing.Size(78, 22)
        Me.txt_Address_Controller.TabIndex = 15
        Me.txt_Address_Controller.Text = "00"
        '
        'txt_Car_ID
        '
        Me.txt_Car_ID.ForeColor = System.Drawing.Color.Blue
        Me.txt_Car_ID.Location = New System.Drawing.Point(159, 85)
        Me.txt_Car_ID.Name = "txt_Car_ID"
        Me.txt_Car_ID.Size = New System.Drawing.Size(67, 22)
        Me.txt_Car_ID.TabIndex = 13
        Me.txt_Car_ID.Text = "00"
        '
        'lbl_Address_FloorController
        '
        Me.lbl_Address_FloorController.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Address_FloorController.ForeColor = System.Drawing.Color.Black
        Me.lbl_Address_FloorController.Location = New System.Drawing.Point(437, 85)
        Me.lbl_Address_FloorController.Name = "lbl_Address_FloorController"
        Me.lbl_Address_FloorController.Size = New System.Drawing.Size(182, 23)
        Me.lbl_Address_FloorController.TabIndex = 12
        Me.lbl_Address_FloorController.Text = "ที่อยู่อุปกรณ์ควบคุมตามชั้น"
        Me.lbl_Address_FloorController.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Car_ID
        '
        Me.lbl_Car_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Car_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_Car_ID.Location = New System.Drawing.Point(10, 83)
        Me.lbl_Car_ID.Name = "lbl_Car_ID"
        Me.lbl_Car_ID.Size = New System.Drawing.Size(143, 27)
        Me.lbl_Car_ID.TabIndex = 13
        Me.lbl_Car_ID.Text = "ทะเบียนรถที่สามารถจอดได้"
        Me.lbl_Car_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Zone
        '
        Me.lbl_Zone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Zone.ForeColor = System.Drawing.Color.Black
        Me.lbl_Zone.Location = New System.Drawing.Point(11, 57)
        Me.lbl_Zone.Name = "lbl_Zone"
        Me.lbl_Zone.Size = New System.Drawing.Size(122, 21)
        Me.lbl_Zone.TabIndex = 14
        Me.lbl_Zone.Text = "โซนอุปกรณ์ตรวจสอบ"
        Me.lbl_Zone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grp_Control
        '
        Me.grp_Control.Controls.Add(Me.lbl_MM)
        Me.grp_Control.Controls.Add(Me.lbl_HH)
        Me.grp_Control.Controls.Add(Me.lbl_Position_Y)
        Me.grp_Control.Controls.Add(Me.lbl_Position_X)
        Me.grp_Control.Controls.Add(Me.dtp_Time_Change)
        Me.grp_Control.Controls.Add(Me.dtp_Date_Change)
        Me.grp_Control.Controls.Add(Me.lbl_Change_Date)
        Me.grp_Control.Controls.Add(Me.lbl_Lot_Id)
        Me.grp_Control.Controls.Add(Me.lbl_T_ID)
        Me.grp_Control.Controls.Add(Me.txt_Lot_Name)
        Me.grp_Control.Controls.Add(Me.lbl_House)
        Me.grp_Control.Controls.Add(Me.lbl_Name)
        Me.grp_Control.Controls.Add(Me.lbl_Minute)
        Me.grp_Control.Controls.Add(Me.cmb_Floor_Name)
        Me.grp_Control.Controls.Add(Me.lbl_Floor)
        Me.grp_Control.Controls.Add(Me.cmb_Floorcontroller_Name)
        Me.grp_Control.Controls.Add(Me.lbl_FloorController)
        Me.grp_Control.Controls.Add(Me.lbl_P_X)
        Me.grp_Control.Controls.Add(Me.lbl_P_Y)
        Me.grp_Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grp_Control.ForeColor = System.Drawing.Color.Black
        Me.grp_Control.Location = New System.Drawing.Point(12, 12)
        Me.grp_Control.Name = "grp_Control"
        Me.grp_Control.Size = New System.Drawing.Size(751, 140)
        Me.grp_Control.TabIndex = 39
        Me.grp_Control.TabStop = False
        Me.grp_Control.Text = "อุปกรณ์"
        '
        'lbl_MM
        '
        Me.lbl_MM.BackColor = System.Drawing.Color.Black
        Me.lbl_MM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_MM.ForeColor = System.Drawing.Color.Lime
        Me.lbl_MM.Location = New System.Drawing.Point(245, 96)
        Me.lbl_MM.Name = "lbl_MM"
        Me.lbl_MM.Size = New System.Drawing.Size(55, 31)
        Me.lbl_MM.TabIndex = 22
        Me.lbl_MM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HH
        '
        Me.lbl_HH.BackColor = System.Drawing.Color.Black
        Me.lbl_HH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_HH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_HH.ForeColor = System.Drawing.Color.Lime
        Me.lbl_HH.Location = New System.Drawing.Point(95, 96)
        Me.lbl_HH.Name = "lbl_HH"
        Me.lbl_HH.Size = New System.Drawing.Size(55, 31)
        Me.lbl_HH.TabIndex = 21
        Me.lbl_HH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Position_Y
        '
        Me.lbl_Position_Y.BackColor = System.Drawing.Color.Black
        Me.lbl_Position_Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Position_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Position_Y.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Position_Y.Location = New System.Drawing.Point(686, 27)
        Me.lbl_Position_Y.Name = "lbl_Position_Y"
        Me.lbl_Position_Y.Size = New System.Drawing.Size(55, 31)
        Me.lbl_Position_Y.TabIndex = 20
        Me.lbl_Position_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Position_X
        '
        Me.lbl_Position_X.BackColor = System.Drawing.Color.Black
        Me.lbl_Position_X.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Position_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Position_X.ForeColor = System.Drawing.Color.Lime
        Me.lbl_Position_X.Location = New System.Drawing.Point(537, 27)
        Me.lbl_Position_X.Name = "lbl_Position_X"
        Me.lbl_Position_X.Size = New System.Drawing.Size(55, 31)
        Me.lbl_Position_X.TabIndex = 19
        Me.lbl_Position_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp_Time_Change
        '
        Me.dtp_Time_Change.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Time_Change.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_Time_Change.Location = New System.Drawing.Point(601, 100)
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
        Me.dtp_Date_Change.Location = New System.Drawing.Point(525, 100)
        Me.dtp_Date_Change.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Date_Change.Name = "dtp_Date_Change"
        Me.dtp_Date_Change.Size = New System.Drawing.Size(194, 22)
        Me.dtp_Date_Change.TabIndex = 5
        '
        'lbl_Change_Date
        '
        Me.lbl_Change_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Change_Date.ForeColor = System.Drawing.Color.Black
        Me.lbl_Change_Date.Location = New System.Drawing.Point(323, 100)
        Me.lbl_Change_Date.Name = "lbl_Change_Date"
        Me.lbl_Change_Date.Size = New System.Drawing.Size(195, 23)
        Me.lbl_Change_Date.TabIndex = 6
        Me.lbl_Change_Date.Text = "เวลาที่มีการเปลี่ยนแปลงสถานะล่าสุด"
        Me.lbl_Change_Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Lot_Id
        '
        Me.lbl_Lot_Id.BackColor = System.Drawing.Color.Black
        Me.lbl_Lot_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Lot_Id.ForeColor = System.Drawing.Color.Red
        Me.lbl_Lot_Id.Location = New System.Drawing.Point(78, 27)
        Me.lbl_Lot_Id.Name = "lbl_Lot_Id"
        Me.lbl_Lot_Id.Size = New System.Drawing.Size(72, 31)
        Me.lbl_Lot_Id.TabIndex = 18
        Me.lbl_Lot_Id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbl_T_ID.ForeColor = System.Drawing.Color.Black
        Me.lbl_T_ID.Location = New System.Drawing.Point(16, 32)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(61, 21)
        Me.lbl_T_ID.TabIndex = 0
        Me.lbl_T_ID.Text = "รหัสอุปกรณ์"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Lot_Name
        '
        Me.txt_Lot_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Lot_Name.ForeColor = System.Drawing.Color.Blue
        Me.txt_Lot_Name.Location = New System.Drawing.Point(245, 31)
        Me.txt_Lot_Name.Name = "txt_Lot_Name"
        Me.txt_Lot_Name.Size = New System.Drawing.Size(192, 22)
        Me.txt_Lot_Name.TabIndex = 0
        '
        'lbl_House
        '
        Me.lbl_House.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_House.ForeColor = System.Drawing.Color.Black
        Me.lbl_House.Location = New System.Drawing.Point(10, 97)
        Me.lbl_House.Name = "lbl_House"
        Me.lbl_House.Size = New System.Drawing.Size(79, 28)
        Me.lbl_House.TabIndex = 7
        Me.lbl_House.Text = "เวลาจอด ชม."
        Me.lbl_House.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Name
        '
        Me.lbl_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbl_Name.ForeColor = System.Drawing.Color.Black
        Me.lbl_Name.Location = New System.Drawing.Point(156, 32)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(83, 21)
        Me.lbl_Name.TabIndex = 1
        Me.lbl_Name.Text = "ชื่ออุปกรณ์"
        Me.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Minute
        '
        Me.lbl_Minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Minute.ForeColor = System.Drawing.Color.Black
        Me.lbl_Minute.Location = New System.Drawing.Point(159, 97)
        Me.lbl_Minute.Name = "lbl_Minute"
        Me.lbl_Minute.Size = New System.Drawing.Size(80, 29)
        Me.lbl_Minute.TabIndex = 8
        Me.lbl_Minute.Text = "เวลาจอด นาที"
        Me.lbl_Minute.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Floor_Name
        '
        Me.cmb_Floor_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floor_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Floor_Name.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Floor_Name.FormattingEnabled = True
        Me.cmb_Floor_Name.Location = New System.Drawing.Point(103, 64)
        Me.cmb_Floor_Name.Name = "cmb_Floor_Name"
        Me.cmb_Floor_Name.Size = New System.Drawing.Size(168, 24)
        Me.cmb_Floor_Name.TabIndex = 1
        '
        'lbl_Floor
        '
        Me.lbl_Floor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbl_Floor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Floor.Location = New System.Drawing.Point(16, 66)
        Me.lbl_Floor.Name = "lbl_Floor"
        Me.lbl_Floor.Size = New System.Drawing.Size(81, 21)
        Me.lbl_Floor.TabIndex = 2
        Me.lbl_Floor.Text = "ชั้นที่ติดตั้ง"
        Me.lbl_Floor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Floorcontroller_Name
        '
        Me.cmb_Floorcontroller_Name.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmb_Floorcontroller_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Floorcontroller_Name.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Floorcontroller_Name.FormattingEnabled = True
        Me.cmb_Floorcontroller_Name.Location = New System.Drawing.Point(443, 64)
        Me.cmb_Floorcontroller_Name.Name = "cmb_Floorcontroller_Name"
        Me.cmb_Floorcontroller_Name.Size = New System.Drawing.Size(233, 24)
        Me.cmb_Floorcontroller_Name.TabIndex = 2
        '
        'lbl_FloorController
        '
        Me.lbl_FloorController.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbl_FloorController.ForeColor = System.Drawing.Color.Black
        Me.lbl_FloorController.Location = New System.Drawing.Point(278, 65)
        Me.lbl_FloorController.Name = "lbl_FloorController"
        Me.lbl_FloorController.Size = New System.Drawing.Size(159, 22)
        Me.lbl_FloorController.TabIndex = 3
        Me.lbl_FloorController.Text = "อุปกรณ์ควบคุมตามชั้น"
        Me.lbl_FloorController.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_P_X
        '
        Me.lbl_P_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_P_X.ForeColor = System.Drawing.Color.Black
        Me.lbl_P_X.Location = New System.Drawing.Point(443, 32)
        Me.lbl_P_X.Name = "lbl_P_X"
        Me.lbl_P_X.Size = New System.Drawing.Size(88, 21)
        Me.lbl_P_X.TabIndex = 4
        Me.lbl_P_X.Text = "ตำแหน่งแกน X"
        Me.lbl_P_X.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_P_Y
        '
        Me.lbl_P_Y.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_P_Y.ForeColor = System.Drawing.Color.Black
        Me.lbl_P_Y.Location = New System.Drawing.Point(598, 32)
        Me.lbl_P_Y.Name = "lbl_P_Y"
        Me.lbl_P_Y.Size = New System.Drawing.Size(82, 21)
        Me.lbl_P_Y.TabIndex = 5
        Me.lbl_P_Y.Text = "ตำแหน่งแกน Y"
        Me.lbl_P_Y.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Close
        '
        Me.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Close.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Close.Location = New System.Drawing.Point(656, 320)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(108, 50)
        Me.btn_Close.TabIndex = 21
        Me.btn_Close.Text = "ปิด"
        Me.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Cancel.ImageIndex = 0
        Me.btn_Cancel.ImageList = Me.img_Cancel
        Me.btn_Cancel.Location = New System.Drawing.Point(544, 320)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(108, 50)
        Me.btn_Cancel.TabIndex = 20
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
        'btn_Edit
        '
        Me.btn_Edit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Edit.ImageIndex = 0
        Me.btn_Edit.ImageList = Me.img_Edit
        Me.btn_Edit.Location = New System.Drawing.Point(432, 320)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(108, 50)
        Me.btn_Edit.TabIndex = 19
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
        'img_Save
        '
        Me.img_Save.ImageStream = CType(resources.GetObject("img_Save.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Save.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Save.Images.SetKeyName(0, "zippo 024.png")
        '
        'btn_Search
        '
        Me.btn_Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Search.ForeColor = System.Drawing.Color.Blue
        Me.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Search.ImageIndex = 0
        Me.btn_Search.ImageList = Me.img_Search
        Me.btn_Search.Location = New System.Drawing.Point(322, 320)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(108, 50)
        Me.btn_Search.TabIndex = 41
        Me.btn_Search.Text = "ค้นหา"
        Me.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Search.UseVisualStyleBackColor = True
        Me.btn_Search.Visible = False
        '
        'img_Search
        '
        Me.img_Search.ImageStream = CType(resources.GetObject("img_Search.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img_Search.TransparentColor = System.Drawing.Color.Transparent
        Me.img_Search.Images.SetKeyName(0, "zippo 015.png")
        '
        'frm_Location_Detail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(778, 387)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Search)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.grp_Status)
        Me.Controls.Add(Me.grp_Control)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Location_Detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายละเอียดของอุปกรณ์ "
        Me.grp_Status.ResumeLayout(False)
        Me.grp_Status.PerformLayout()
        Me.grp_Control.ResumeLayout(False)
        Me.grp_Control.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_Status As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_Zone As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Mas_Controller As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Status_Name As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents cbo_Alam_Name As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remark As System.Windows.Forms.Label
    Friend WithEvents lbl_Status_Connect As System.Windows.Forms.Label
    Friend WithEvents lbl_Type As System.Windows.Forms.Label
    Friend WithEvents txt_Address_Sensor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Address_Sensor As System.Windows.Forms.Label
    Friend WithEvents txt_Address_Controller As System.Windows.Forms.TextBox
    Friend WithEvents txt_Car_ID As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Address_FloorController As System.Windows.Forms.Label
    Friend WithEvents lbl_Car_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_Zone As System.Windows.Forms.Label
    Friend WithEvents grp_Control As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_Time_Change As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Date_Change As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Change_Date As System.Windows.Forms.Label
    Friend WithEvents lbl_Lot_Id As System.Windows.Forms.Label
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents txt_Lot_Name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_House As System.Windows.Forms.Label
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Minute As System.Windows.Forms.Label
    Friend WithEvents cmb_Floor_Name As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Floor As System.Windows.Forms.Label
    Friend WithEvents cmb_Floorcontroller_Name As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_FloorController As System.Windows.Forms.Label
    Friend WithEvents lbl_P_X As System.Windows.Forms.Label
    Friend WithEvents lbl_P_Y As System.Windows.Forms.Label
    Friend WithEvents btn_Close As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents lbl_Position_Y As System.Windows.Forms.Label
    Friend WithEvents lbl_Position_X As System.Windows.Forms.Label
    Friend WithEvents lbl_MM As System.Windows.Forms.Label
    Friend WithEvents lbl_HH As System.Windows.Forms.Label
    Friend WithEvents img_Edit As System.Windows.Forms.ImageList
    Friend WithEvents img_Save As System.Windows.Forms.ImageList
    Friend WithEvents img_Cancel As System.Windows.Forms.ImageList
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents img_Search As System.Windows.Forms.ImageList
End Class
