<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Graph_Realtime
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdo_Pie = New System.Windows.Forms.RadioButton()
        Me.rdo_Bar = New System.Windows.Forms.RadioButton()
        Me.rdo_Line = New System.Windows.Forms.RadioButton()
        Me.CTR_Viewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdo_Pie)
        Me.GroupBox1.Controls.Add(Me.rdo_Bar)
        Me.GroupBox1.Controls.Add(Me.rdo_Line)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1283, 52)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rdo_Pie
        '
        Me.rdo_Pie.AutoSize = True
        Me.rdo_Pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Pie.ForeColor = System.Drawing.Color.White
        Me.rdo_Pie.Location = New System.Drawing.Point(334, 19)
        Me.rdo_Pie.Name = "rdo_Pie"
        Me.rdo_Pie.Size = New System.Drawing.Size(101, 24)
        Me.rdo_Pie.TabIndex = 2
        Me.rdo_Pie.Text = "กราฟวงกลม"
        Me.rdo_Pie.UseVisualStyleBackColor = True
        '
        'rdo_Bar
        '
        Me.rdo_Bar.AutoSize = True
        Me.rdo_Bar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Bar.ForeColor = System.Drawing.Color.White
        Me.rdo_Bar.Location = New System.Drawing.Point(231, 19)
        Me.rdo_Bar.Name = "rdo_Bar"
        Me.rdo_Bar.Size = New System.Drawing.Size(86, 24)
        Me.rdo_Bar.TabIndex = 1
        Me.rdo_Bar.Text = "กราฟแท่ง"
        Me.rdo_Bar.UseVisualStyleBackColor = True
        '
        'rdo_Line
        '
        Me.rdo_Line.AutoSize = True
        Me.rdo_Line.Checked = True
        Me.rdo_Line.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rdo_Line.ForeColor = System.Drawing.Color.White
        Me.rdo_Line.Location = New System.Drawing.Point(129, 19)
        Me.rdo_Line.Name = "rdo_Line"
        Me.rdo_Line.Size = New System.Drawing.Size(83, 24)
        Me.rdo_Line.TabIndex = 0
        Me.rdo_Line.TabStop = True
        Me.rdo_Line.Text = "กราฟเส้น"
        Me.rdo_Line.UseVisualStyleBackColor = True
        '
        'CTR_Viewer
        '
        Me.CTR_Viewer.ActiveViewIndex = -1
        Me.CTR_Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTR_Viewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CTR_Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CTR_Viewer.Location = New System.Drawing.Point(0, 52)
        Me.CTR_Viewer.Name = "CTR_Viewer"
        Me.CTR_Viewer.Size = New System.Drawing.Size(1283, 562)
        Me.CTR_Viewer.TabIndex = 5
        Me.CTR_Viewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Timer1
        '
        Me.Timer1.Interval = 8000
        '
        'frm_Graph_Realtime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 614)
        Me.Controls.Add(Me.CTR_Viewer)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Name = "frm_Graph_Realtime"
        Me.Text = "กราฟสถานะลานจอดรถปัจจุบัน (Realtime)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_Pie As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_Bar As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_Line As System.Windows.Forms.RadioButton
    Friend WithEvents CTR_Viewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
