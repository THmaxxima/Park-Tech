<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZCU_Config
    Inherits System.Windows.Forms.Form

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
        Me.Labelw13 = New System.Windows.Forms.Label()
        Me.Labelw11 = New System.Windows.Forms.Label()
        Me.Labelw7 = New System.Windows.Forms.Label()
        Me.Labelw5 = New System.Windows.Forms.Label()
        Me.Labelw4 = New System.Windows.Forms.Label()
        Me.Labelw3 = New System.Windows.Forms.Label()
        Me.Labelw2 = New System.Windows.Forms.Label()
        Me.Labelw1 = New System.Windows.Forms.Label()
        Me.txt_Max_UD = New System.Windows.Forms.TextBox()
        Me.txt_Max_DP = New System.Windows.Forms.TextBox()
        Me.txt_Max_CP = New System.Windows.Forms.TextBox()
        Me.txtClose_DP_From = New System.Windows.Forms.TextBox()
        Me.txtClose_DP_To = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClose_UD_To = New System.Windows.Forms.TextBox()
        Me.txtClose_UD_From = New System.Windows.Forms.TextBox()
        Me.txtZcu_Timeout_Request = New System.Windows.Forms.TextBox()
        Me.txtZcu_Time_Sleep_Mode = New System.Windows.Forms.TextBox()
        Me.dtpDate_Time = New System.Windows.Forms.DateTimePicker()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdSave_Load = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Cmb_ZCU = New System.Windows.Forms.ComboBox()
        Me.cboMas_Building_Parking = New System.Windows.Forms.ComboBox()
        Me.cboMas_Tower = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Labelw13
        '
        Me.Labelw13.Location = New System.Drawing.Point(6, 344)
        Me.Labelw13.Name = "Labelw13"
        Me.Labelw13.Size = New System.Drawing.Size(323, 20)
        Me.Labelw13.TabIndex = 68
        Me.Labelw13.Text = "ตั้งค่าการตั้ง  ปิด Sleep mode หน้าจอ"
        Me.Labelw13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw11
        '
        Me.Labelw11.Location = New System.Drawing.Point(6, 319)
        Me.Labelw11.Name = "Labelw11"
        Me.Labelw11.Size = New System.Drawing.Size(323, 20)
        Me.Labelw11.TabIndex = 66
        Me.Labelw11.Text = "ตั้งค่าการตั้งระยะเวลาที่ Master ไม่ไป Request แล้วสั่งดับไป Display"
        Me.Labelw11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw7
        '
        Me.Labelw7.Location = New System.Drawing.Point(7, 295)
        Me.Labelw7.Name = "Labelw7"
        Me.Labelw7.Size = New System.Drawing.Size(323, 20)
        Me.Labelw7.TabIndex = 62
        Me.Labelw7.Text = "ตั้งค่า เวลาสั่งปิด - เปิด ไฟ Ultrasonic Led"
        Me.Labelw7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw5
        '
        Me.Labelw5.Location = New System.Drawing.Point(6, 271)
        Me.Labelw5.Name = "Labelw5"
        Me.Labelw5.Size = New System.Drawing.Size(323, 20)
        Me.Labelw5.TabIndex = 60
        Me.Labelw5.Text = "ตั้งค่า เวลาสั่งปิด - เปิดป้าย Display"
        Me.Labelw5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw4
        '
        Me.Labelw4.Location = New System.Drawing.Point(6, 240)
        Me.Labelw4.Name = "Labelw4"
        Me.Labelw4.Size = New System.Drawing.Size(323, 20)
        Me.Labelw4.TabIndex = 59
        Me.Labelw4.Text = "Date/Time ปัจจุบัน"
        Me.Labelw4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw3
        '
        Me.Labelw3.Location = New System.Drawing.Point(6, 214)
        Me.Labelw3.Name = "Labelw3"
        Me.Labelw3.Size = New System.Drawing.Size(323, 20)
        Me.Labelw3.TabIndex = 58
        Me.Labelw3.Text = "จำนวน Call point"
        Me.Labelw3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw2
        '
        Me.Labelw2.Location = New System.Drawing.Point(6, 185)
        Me.Labelw2.Name = "Labelw2"
        Me.Labelw2.Size = New System.Drawing.Size(323, 20)
        Me.Labelw2.TabIndex = 57
        Me.Labelw2.Text = "จำนวน Display ใช้จริง"
        Me.Labelw2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Labelw1
        '
        Me.Labelw1.Location = New System.Drawing.Point(6, 153)
        Me.Labelw1.Name = "Labelw1"
        Me.Labelw1.Size = New System.Drawing.Size(323, 20)
        Me.Labelw1.TabIndex = 56
        Me.Labelw1.Text = "จำนวน Ultrasonic ใช้จริง"
        Me.Labelw1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Max_UD
        '
        Me.txt_Max_UD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Max_UD.Location = New System.Drawing.Point(336, 153)
        Me.txt_Max_UD.Name = "txt_Max_UD"
        Me.txt_Max_UD.ReadOnly = True
        Me.txt_Max_UD.Size = New System.Drawing.Size(57, 20)
        Me.txt_Max_UD.TabIndex = 70
        '
        'txt_Max_DP
        '
        Me.txt_Max_DP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Max_DP.Location = New System.Drawing.Point(336, 185)
        Me.txt_Max_DP.Name = "txt_Max_DP"
        Me.txt_Max_DP.ReadOnly = True
        Me.txt_Max_DP.Size = New System.Drawing.Size(57, 20)
        Me.txt_Max_DP.TabIndex = 71
        '
        'txt_Max_CP
        '
        Me.txt_Max_CP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Max_CP.Location = New System.Drawing.Point(336, 214)
        Me.txt_Max_CP.Name = "txt_Max_CP"
        Me.txt_Max_CP.ReadOnly = True
        Me.txt_Max_CP.Size = New System.Drawing.Size(57, 20)
        Me.txt_Max_CP.TabIndex = 72
        '
        'txtClose_DP_From
        '
        Me.txtClose_DP_From.Location = New System.Drawing.Point(336, 271)
        Me.txtClose_DP_From.Name = "txtClose_DP_From"
        Me.txtClose_DP_From.Size = New System.Drawing.Size(57, 20)
        Me.txtClose_DP_From.TabIndex = 73
        '
        'txtClose_DP_To
        '
        Me.txtClose_DP_To.Location = New System.Drawing.Point(441, 271)
        Me.txtClose_DP_To.Name = "txtClose_DP_To"
        Me.txtClose_DP_To.Size = New System.Drawing.Size(57, 20)
        Me.txtClose_DP_To.TabIndex = 74
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(402, 271)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 20)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "ถึง"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(403, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 20)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "ถึง"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClose_UD_To
        '
        Me.txtClose_UD_To.Location = New System.Drawing.Point(441, 295)
        Me.txtClose_UD_To.Name = "txtClose_UD_To"
        Me.txtClose_UD_To.Size = New System.Drawing.Size(57, 20)
        Me.txtClose_UD_To.TabIndex = 77
        '
        'txtClose_UD_From
        '
        Me.txtClose_UD_From.Location = New System.Drawing.Point(336, 295)
        Me.txtClose_UD_From.Name = "txtClose_UD_From"
        Me.txtClose_UD_From.Size = New System.Drawing.Size(57, 20)
        Me.txtClose_UD_From.TabIndex = 76
        '
        'txtZcu_Timeout_Request
        '
        Me.txtZcu_Timeout_Request.Location = New System.Drawing.Point(336, 319)
        Me.txtZcu_Timeout_Request.Name = "txtZcu_Timeout_Request"
        Me.txtZcu_Timeout_Request.Size = New System.Drawing.Size(57, 20)
        Me.txtZcu_Timeout_Request.TabIndex = 80
        '
        'txtZcu_Time_Sleep_Mode
        '
        Me.txtZcu_Time_Sleep_Mode.Location = New System.Drawing.Point(336, 344)
        Me.txtZcu_Time_Sleep_Mode.Name = "txtZcu_Time_Sleep_Mode"
        Me.txtZcu_Time_Sleep_Mode.Size = New System.Drawing.Size(57, 20)
        Me.txtZcu_Time_Sleep_Mode.TabIndex = 82
        '
        'dtpDate_Time
        '
        Me.dtpDate_Time.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpDate_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate_Time.Location = New System.Drawing.Point(336, 240)
        Me.dtpDate_Time.Name = "dtpDate_Time"
        Me.dtpDate_Time.Size = New System.Drawing.Size(155, 20)
        Me.dtpDate_Time.TabIndex = 83
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(335, 377)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(112, 34)
        Me.cmdSave.TabIndex = 84
        Me.cmdSave.Text = "Save config"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdSave_Load
        '
        Me.cmdSave_Load.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmdSave_Load.Location = New System.Drawing.Point(336, 417)
        Me.cmdSave_Load.Name = "cmdSave_Load"
        Me.cmdSave_Load.Size = New System.Drawing.Size(112, 34)
        Me.cmdSave_Load.TabIndex = 85
        Me.cmdSave_Load.Text = "Set Data to ZCU"
        Me.cmdSave_Load.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(402, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 20)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "จุด"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(402, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 20)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "จุด"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(402, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 20)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "จุด"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(402, 319)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 20)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "วินาที"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(402, 344)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 20)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "วินาที"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(171, 53)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "ZCU No."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(171, 53)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "อาคารจอด."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 53)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "สถานที่ ."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_ZCU
        '
        Me.Cmb_ZCU.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Cmb_ZCU.FormattingEnabled = True
        Me.Cmb_ZCU.Location = New System.Drawing.Point(191, 104)
        Me.Cmb_ZCU.Name = "Cmb_ZCU"
        Me.Cmb_ZCU.Size = New System.Drawing.Size(375, 39)
        Me.Cmb_ZCU.TabIndex = 109
        '
        'cboMas_Building_Parking
        '
        Me.cboMas_Building_Parking.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboMas_Building_Parking.FormattingEnabled = True
        Me.cboMas_Building_Parking.Location = New System.Drawing.Point(191, 51)
        Me.cboMas_Building_Parking.Name = "cboMas_Building_Parking"
        Me.cboMas_Building_Parking.Size = New System.Drawing.Size(375, 39)
        Me.cboMas_Building_Parking.TabIndex = 110
        '
        'cboMas_Tower
        '
        Me.cboMas_Tower.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cboMas_Tower.FormattingEnabled = True
        Me.cboMas_Tower.Location = New System.Drawing.Point(192, 6)
        Me.cboMas_Tower.Name = "cboMas_Tower"
        Me.cboMas_Tower.Size = New System.Drawing.Size(375, 39)
        Me.cboMas_Tower.TabIndex = 111
        '
        'frmZCU_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 463)
        Me.Controls.Add(Me.cboMas_Tower)
        Me.Controls.Add(Me.cboMas_Building_Parking)
        Me.Controls.Add(Me.Cmb_ZCU)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdSave_Load)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dtpDate_Time)
        Me.Controls.Add(Me.txtZcu_Time_Sleep_Mode)
        Me.Controls.Add(Me.txtZcu_Timeout_Request)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtClose_UD_To)
        Me.Controls.Add(Me.txtClose_UD_From)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtClose_DP_To)
        Me.Controls.Add(Me.txtClose_DP_From)
        Me.Controls.Add(Me.txt_Max_CP)
        Me.Controls.Add(Me.txt_Max_DP)
        Me.Controls.Add(Me.txt_Max_UD)
        Me.Controls.Add(Me.Labelw13)
        Me.Controls.Add(Me.Labelw11)
        Me.Controls.Add(Me.Labelw7)
        Me.Controls.Add(Me.Labelw5)
        Me.Controls.Add(Me.Labelw4)
        Me.Controls.Add(Me.Labelw3)
        Me.Controls.Add(Me.Labelw2)
        Me.Controls.Add(Me.Labelw1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmZCU_Config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmZCU_Config"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Labelw13 As System.Windows.Forms.Label
    Friend WithEvents Labelw11 As System.Windows.Forms.Label
    Friend WithEvents Labelw7 As System.Windows.Forms.Label
    Friend WithEvents Labelw5 As System.Windows.Forms.Label
    Friend WithEvents Labelw4 As System.Windows.Forms.Label
    Friend WithEvents Labelw3 As System.Windows.Forms.Label
    Friend WithEvents Labelw2 As System.Windows.Forms.Label
    Friend WithEvents Labelw1 As System.Windows.Forms.Label
    Friend WithEvents txt_Max_UD As System.Windows.Forms.TextBox
    Friend WithEvents txt_Max_DP As System.Windows.Forms.TextBox
    Friend WithEvents txt_Max_CP As System.Windows.Forms.TextBox
    Friend WithEvents txtClose_DP_From As System.Windows.Forms.TextBox
    Friend WithEvents txtClose_DP_To As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClose_UD_To As System.Windows.Forms.TextBox
    Friend WithEvents txtClose_UD_From As System.Windows.Forms.TextBox
    Friend WithEvents txtZcu_Timeout_Request As System.Windows.Forms.TextBox
    Friend WithEvents txtZcu_Time_Sleep_Mode As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate_Time As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdSave_Load As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ZCU As System.Windows.Forms.ComboBox
    Friend WithEvents cboMas_Building_Parking As System.Windows.Forms.ComboBox
    Friend WithEvents cboMas_Tower As System.Windows.Forms.ComboBox
End Class
