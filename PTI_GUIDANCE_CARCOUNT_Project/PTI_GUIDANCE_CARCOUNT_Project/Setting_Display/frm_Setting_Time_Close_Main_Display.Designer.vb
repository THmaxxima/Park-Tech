<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Setting_Time_Close_Main_Display
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
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.TEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TStart = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Edit
        '
        Me.btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btn_Edit.ForeColor = System.Drawing.Color.Green
        Me.btn_Edit.Location = New System.Drawing.Point(471, 12)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(102, 32)
        Me.btn_Edit.TabIndex = 146
        Me.btn_Edit.Text = "แก้ไข"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'TEnd
        '
        Me.TEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TEnd.Enabled = False
        Me.TEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TEnd.Location = New System.Drawing.Point(377, 17)
        Me.TEnd.Name = "TEnd"
        Me.TEnd.ShowUpDown = True
        Me.TEnd.Size = New System.Drawing.Size(88, 22)
        Me.TEnd.TabIndex = 145
        Me.TEnd.Value = New Date(2006, 10, 14, 11, 0, 24, 842)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(316, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "ถึงเวลา :"
        '
        'TStart
        '
        Me.TStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TStart.Enabled = False
        Me.TStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TStart.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TStart.Location = New System.Drawing.Point(224, 17)
        Me.TStart.Name = "TStart"
        Me.TStart.ShowUpDown = True
        Me.TStart.Size = New System.Drawing.Size(88, 22)
        Me.TStart.TabIndex = 143
        Me.TStart.Value = New Date(2006, 10, 14, 11, 0, 24, 842)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 20)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "เวลาที่เปิดใช้งาน Main Display :"
        '
        'frm_Setting_Time_Close_Main_Display
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 63)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.TEnd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TStart)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Setting_Time_Close_Main_Display"
        Me.Text = "ตั้งเวลาเปิด - ปิด ป้าย Main"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents TEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
