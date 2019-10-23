Module mForm
    Public Sub Set_Standard_Form(ByVal frm As Form, Optional ByVal IsShowMax As Boolean = False, Optional ByVal pHeader As String = "")
        With frm
            If IsShowMax = True Then
                .FormBorderStyle = FormBorderStyle.FixedSingle
                .MaximizeBox = True
                .MinimizeBox = True
                .WindowState = FormWindowState.Maximized
                .StartPosition = FormStartPosition.CenterScreen
                .BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
                .Text = pHeader
                'Dim ico As New System.Drawing.Icon(Application.StartupPath & "/PTI_Logo.ico")
                '.Icon = ico
            Else
                .FormBorderStyle = FormBorderStyle.FixedSingle
                .MaximizeBox = True
                .MinimizeBox = True
                .WindowState = FormWindowState.Normal
                .StartPosition = FormStartPosition.CenterScreen
                .BackColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(101, Byte), Integer))
                ' Dim ico As New System.Drawing.Icon(Application.StartupPath & "/PTI_Logo.ico")
                ' .Icon = ico
            End If
        End With
    End Sub
    Public Sub Set_Standard_Form_Guidance(ByVal frm As Form)
        With frm
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .MaximizeBox = True
            .MinimizeBox = True
            .WindowState = FormWindowState.Normal
            .StartPosition = FormStartPosition.CenterScreen
            .BackColor = Color.WhiteSmoke
            Dim ico As New System.Drawing.Icon(Application.StartupPath & "/pt_logo_XvJ_icon.ico")
            .Icon = ico
        End With
    End Sub

    'Sub Set_Standard_Form(frm As RPT_CAR_PARKING_HH_BY_DAY_ADD, p2 As Boolean, p3 As String)
    '    Throw New NotImplementedException
    'End Sub

End Module
