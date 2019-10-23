<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Lot_History
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
        Me.lsv_Lot_History = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtp_Date_Start = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Time_Start = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Time_Stop = New System.Windows.Forms.DateTimePicker()
        Me.dtp_Date_Stop = New System.Windows.Forms.DateTimePicker()
        Me.btn_Detail = New System.Windows.Forms.Button()
        Me.lbl_Start = New System.Windows.Forms.Label()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_Time_In = New System.Windows.Forms.Label()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.lbl_Car_In = New System.Windows.Forms.Label()
        Me.lbl_Real_Time = New System.Windows.Forms.Label()
        Me.lbl_FloorController_Name = New System.Windows.Forms.Label()
        Me.lbl_Date_Update = New System.Windows.Forms.Label()
        Me.lbl_Lot_Name = New System.Windows.Forms.Label()
        Me.lbl_Time_Last = New System.Windows.Forms.Label()
        Me.lbl_Lot_Id = New System.Windows.Forms.Label()
        Me.lblT_Status = New System.Windows.Forms.Label()
        Me.lblT_FloorController = New System.Windows.Forms.Label()
        Me.lbl_T_Name = New System.Windows.Forms.Label()
        Me.lbl_T_ID = New System.Windows.Forms.Label()
        Me.lbl_Total_Time = New System.Windows.Forms.Label()
        Me.lbl_Time_Parking = New System.Windows.Forms.Label()
        Me.lbl_Average = New System.Windows.Forms.Label()
        Me.lbl_T_Average = New System.Windows.Forms.Label()
        Me.T_Status = New System.Windows.Forms.Timer(Me.components)
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsv_Lot_History
        '
        Me.lsv_Lot_History.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lsv_Lot_History.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lsv_Lot_History.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsv_Lot_History.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsv_Lot_History.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsv_Lot_History.Location = New System.Drawing.Point(20, 209)
        Me.lsv_Lot_History.Name = "lsv_Lot_History"
        Me.lsv_Lot_History.Size = New System.Drawing.Size(607, 403)
        Me.lsv_Lot_History.TabIndex = 0
        Me.lsv_Lot_History.TabStop = False
        Me.lsv_Lot_History.UseCompatibleStateImageBehavior = False
        Me.lsv_Lot_History.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "   ลำดับ"
        Me.ColumnHeader1.Width = 65
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "                 เวลาเข้า"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "                 เวลาออก"
        Me.ColumnHeader3.Width = 170
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "                    เวลาจอด"
        Me.ColumnHeader4.Width = 190
        '
        'dtp_Date_Start
        '
        Me.dtp_Date_Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Date_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_Date_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Date_Start.Location = New System.Drawing.Point(64, 162)
        Me.dtp_Date_Start.Name = "dtp_Date_Start"
        Me.dtp_Date_Start.Size = New System.Drawing.Size(177, 22)
        Me.dtp_Date_Start.TabIndex = 1
        '
        'dtp_Time_Start
        '
        Me.dtp_Time_Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Time_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_Time_Start.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_Time_Start.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp_Time_Start.Location = New System.Drawing.Point(133, 162)
        Me.dtp_Time_Start.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Time_Start.Name = "dtp_Time_Start"
        Me.dtp_Time_Start.ShowUpDown = True
        Me.dtp_Time_Start.Size = New System.Drawing.Size(90, 22)
        Me.dtp_Time_Start.TabIndex = 3
        Me.dtp_Time_Start.Value = New Date(2011, 3, 24, 12, 0, 0, 0)
        '
        'dtp_Time_Stop
        '
        Me.dtp_Time_Stop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Time_Stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_Time_Stop.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_Time_Stop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtp_Time_Stop.Location = New System.Drawing.Point(370, 162)
        Me.dtp_Time_Stop.Margin = New System.Windows.Forms.Padding(4)
        Me.dtp_Time_Stop.Name = "dtp_Time_Stop"
        Me.dtp_Time_Stop.ShowUpDown = True
        Me.dtp_Time_Stop.Size = New System.Drawing.Size(90, 22)
        Me.dtp_Time_Stop.TabIndex = 3
        '
        'dtp_Date_Stop
        '
        Me.dtp_Date_Stop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp_Date_Stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.dtp_Date_Stop.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_Date_Stop.Location = New System.Drawing.Point(298, 162)
        Me.dtp_Date_Stop.Name = "dtp_Date_Stop"
        Me.dtp_Date_Stop.Size = New System.Drawing.Size(179, 22)
        Me.dtp_Date_Stop.TabIndex = 1
        '
        'btn_Detail
        '
        Me.btn_Detail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Detail.Location = New System.Drawing.Point(483, 160)
        Me.btn_Detail.Name = "btn_Detail"
        Me.btn_Detail.Size = New System.Drawing.Size(144, 28)
        Me.btn_Detail.TabIndex = 8
        Me.btn_Detail.Text = "ค้นหา"
        Me.btn_Detail.UseVisualStyleBackColor = True
        '
        'lbl_Start
        '
        Me.lbl_Start.BackColor = System.Drawing.Color.Silver
        Me.lbl_Start.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_Start.Location = New System.Drawing.Point(7, 164)
        Me.lbl_Start.Name = "lbl_Start"
        Me.lbl_Start.Size = New System.Drawing.Size(51, 20)
        Me.lbl_Start.TabIndex = 9
        Me.lbl_Start.Text = "จากวันที่"
        Me.lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_To
        '
        Me.lbl_To.BackColor = System.Drawing.Color.Silver
        Me.lbl_To.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbl_To.Location = New System.Drawing.Point(247, 164)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(45, 20)
        Me.lbl_To.TabIndex = 10
        Me.lbl_To.Text = "ถึงวันที่"
        Me.lbl_To.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_Time_In)
        Me.GroupBox3.Controls.Add(Me.lbl_Status)
        Me.GroupBox3.Controls.Add(Me.lbl_Car_In)
        Me.GroupBox3.Controls.Add(Me.lbl_Real_Time)
        Me.GroupBox3.Controls.Add(Me.lbl_FloorController_Name)
        Me.GroupBox3.Controls.Add(Me.lbl_Date_Update)
        Me.GroupBox3.Controls.Add(Me.lbl_Lot_Name)
        Me.GroupBox3.Controls.Add(Me.lbl_Time_Last)
        Me.GroupBox3.Controls.Add(Me.lbl_Lot_Id)
        Me.GroupBox3.Controls.Add(Me.lblT_Status)
        Me.GroupBox3.Controls.Add(Me.lblT_FloorController)
        Me.GroupBox3.Controls.Add(Me.lbl_T_Name)
        Me.GroupBox3.Controls.Add(Me.lbl_T_ID)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(620, 121)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'lbl_Time_In
        '
        Me.lbl_Time_In.Location = New System.Drawing.Point(425, 84)
        Me.lbl_Time_In.Name = "lbl_Time_In"
        Me.lbl_Time_In.Size = New System.Drawing.Size(58, 23)
        Me.lbl_Time_In.TabIndex = 12
        Me.lbl_Time_In.Text = "เวลาจอด"
        Me.lbl_Time_In.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Status
        '
        Me.lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Status.Location = New System.Drawing.Point(369, 51)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(139, 23)
        Me.lbl_Status.TabIndex = 8
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Car_In
        '
        Me.lbl_Car_In.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Car_In.Location = New System.Drawing.Point(486, 81)
        Me.lbl_Car_In.Name = "lbl_Car_In"
        Me.lbl_Car_In.Size = New System.Drawing.Size(114, 28)
        Me.lbl_Car_In.TabIndex = 11
        Me.lbl_Car_In.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Real_Time
        '
        Me.lbl_Real_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Real_Time.Location = New System.Drawing.Point(254, 82)
        Me.lbl_Real_Time.Name = "lbl_Real_Time"
        Me.lbl_Real_Time.Size = New System.Drawing.Size(165, 28)
        Me.lbl_Real_Time.TabIndex = 10
        Me.lbl_Real_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_FloorController_Name
        '
        Me.lbl_FloorController_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_FloorController_Name.Location = New System.Drawing.Point(109, 51)
        Me.lbl_FloorController_Name.Name = "lbl_FloorController_Name"
        Me.lbl_FloorController_Name.Size = New System.Drawing.Size(139, 23)
        Me.lbl_FloorController_Name.TabIndex = 7
        Me.lbl_FloorController_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Date_Update
        '
        Me.lbl_Date_Update.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Date_Update.Location = New System.Drawing.Point(109, 82)
        Me.lbl_Date_Update.Name = "lbl_Date_Update"
        Me.lbl_Date_Update.Size = New System.Drawing.Size(139, 28)
        Me.lbl_Date_Update.TabIndex = 9
        Me.lbl_Date_Update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Lot_Name
        '
        Me.lbl_Lot_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_Name.Location = New System.Drawing.Point(369, 16)
        Me.lbl_Lot_Name.Name = "lbl_Lot_Name"
        Me.lbl_Lot_Name.Size = New System.Drawing.Size(139, 23)
        Me.lbl_Lot_Name.TabIndex = 6
        Me.lbl_Lot_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Time_Last
        '
        Me.lbl_Time_Last.Location = New System.Drawing.Point(10, 85)
        Me.lbl_Time_Last.Name = "lbl_Time_Last"
        Me.lbl_Time_Last.Size = New System.Drawing.Size(93, 23)
        Me.lbl_Time_Last.TabIndex = 9
        Me.lbl_Time_Last.Text = "เวลาเข้าจอดล่าสุด"
        Me.lbl_Time_Last.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Lot_Id
        '
        Me.lbl_Lot_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Lot_Id.Location = New System.Drawing.Point(109, 16)
        Me.lbl_Lot_Id.Name = "lbl_Lot_Id"
        Me.lbl_Lot_Id.Size = New System.Drawing.Size(139, 23)
        Me.lbl_Lot_Id.TabIndex = 5
        Me.lbl_Lot_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblT_Status
        '
        Me.lblT_Status.Location = New System.Drawing.Point(263, 51)
        Me.lblT_Status.Name = "lblT_Status"
        Me.lblT_Status.Size = New System.Drawing.Size(100, 23)
        Me.lblT_Status.TabIndex = 3
        Me.lblT_Status.Text = "สถานะการทำงาน"
        Me.lblT_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblT_FloorController
        '
        Me.lblT_FloorController.Location = New System.Drawing.Point(8, 51)
        Me.lblT_FloorController.Name = "lblT_FloorController"
        Me.lblT_FloorController.Size = New System.Drawing.Size(95, 23)
        Me.lblT_FloorController.TabIndex = 2
        Me.lblT_FloorController.Text = "อุปกรณ์ควบคุม"
        Me.lblT_FloorController.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_T_Name
        '
        Me.lbl_T_Name.Location = New System.Drawing.Point(263, 16)
        Me.lbl_T_Name.Name = "lbl_T_Name"
        Me.lbl_T_Name.Size = New System.Drawing.Size(100, 23)
        Me.lbl_T_Name.TabIndex = 1
        Me.lbl_T_Name.Text = "ชื่ออุปกรณ์"
        Me.lbl_T_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_T_ID
        '
        Me.lbl_T_ID.Location = New System.Drawing.Point(22, 16)
        Me.lbl_T_ID.Name = "lbl_T_ID"
        Me.lbl_T_ID.Size = New System.Drawing.Size(81, 23)
        Me.lbl_T_ID.TabIndex = 0
        Me.lbl_T_ID.Text = "รหัสอุปกรณ์"
        Me.lbl_T_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Total_Time
        '
        Me.lbl_Total_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Total_Time.Location = New System.Drawing.Point(130, 624)
        Me.lbl_Total_Time.Name = "lbl_Total_Time"
        Me.lbl_Total_Time.Size = New System.Drawing.Size(111, 23)
        Me.lbl_Total_Time.TabIndex = 14
        Me.lbl_Total_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Time_Parking
        '
        Me.lbl_Time_Parking.Location = New System.Drawing.Point(17, 624)
        Me.lbl_Time_Parking.Name = "lbl_Time_Parking"
        Me.lbl_Time_Parking.Size = New System.Drawing.Size(93, 23)
        Me.lbl_Time_Parking.TabIndex = 13
        Me.lbl_Time_Parking.Text = "รวมเวลาจอด"
        Me.lbl_Time_Parking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Average
        '
        Me.lbl_Average.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Average.Location = New System.Drawing.Point(353, 624)
        Me.lbl_Average.Name = "lbl_Average"
        Me.lbl_Average.Size = New System.Drawing.Size(116, 23)
        Me.lbl_Average.TabIndex = 16
        Me.lbl_Average.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_T_Average
        '
        Me.lbl_T_Average.Location = New System.Drawing.Point(247, 624)
        Me.lbl_T_Average.Name = "lbl_T_Average"
        Me.lbl_T_Average.Size = New System.Drawing.Size(100, 23)
        Me.lbl_T_Average.TabIndex = 15
        Me.lbl_T_Average.Text = "เวลาจอดเฉลี่ย"
        Me.lbl_T_Average.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'T_Status
        '
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(535, 617)
        Me.cmdReport.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(92, 36)
        Me.cmdReport.TabIndex = 19
        Me.cmdReport.Text = "แสดงรายงาน"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'frm_Lot_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(652, 677)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.dtp_Time_Stop)
        Me.Controls.Add(Me.dtp_Date_Stop)
        Me.Controls.Add(Me.dtp_Time_Start)
        Me.Controls.Add(Me.dtp_Date_Start)
        Me.Controls.Add(Me.lbl_Average)
        Me.Controls.Add(Me.lbl_T_Average)
        Me.Controls.Add(Me.lbl_Total_Time)
        Me.Controls.Add(Me.lbl_Time_Parking)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_To)
        Me.Controls.Add(Me.lbl_Start)
        Me.Controls.Add(Me.btn_Detail)
        Me.Controls.Add(Me.lsv_Lot_History)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Lot_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายละเอียดการทำงานของอุปกรณ์ตรวจสอบ"
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsv_Lot_History As System.Windows.Forms.ListView
    Friend WithEvents dtp_Date_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Time_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Time_Stop As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Date_Stop As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_Detail As System.Windows.Forms.Button
    Friend WithEvents lbl_Start As System.Windows.Forms.Label
    Friend WithEvents lbl_To As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_FloorController_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Lot_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_Lot_Id As System.Windows.Forms.Label
    Friend WithEvents lblT_Status As System.Windows.Forms.Label
    Friend WithEvents lblT_FloorController As System.Windows.Forms.Label
    Friend WithEvents lbl_T_Name As System.Windows.Forms.Label
    Friend WithEvents lbl_T_ID As System.Windows.Forms.Label
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents lbl_Total_Time As System.Windows.Forms.Label
    Friend WithEvents lbl_Time_Parking As System.Windows.Forms.Label
    Friend WithEvents lbl_Average As System.Windows.Forms.Label
    Friend WithEvents lbl_T_Average As System.Windows.Forms.Label
    Friend WithEvents lbl_Time_In As System.Windows.Forms.Label
    Friend WithEvents lbl_Car_In As System.Windows.Forms.Label
    Friend WithEvents lbl_Real_Time As System.Windows.Forms.Label
    Friend WithEvents lbl_Date_Update As System.Windows.Forms.Label
    Friend WithEvents lbl_Time_Last As System.Windows.Forms.Label
    Friend WithEvents T_Status As System.Windows.Forms.Timer
    Friend WithEvents cmdReport As System.Windows.Forms.Button
End Class
