Public Class Frm_Direction_Car

    Private Sub Frm_Direction_Car_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim img(8) As System.Drawing.Bitmap
        Dim dbmp As System.Drawing.Bitmap
        dbmp = New System.Drawing.Bitmap(lot_size_image, lot_size_x, lot_size_y)
        img(0) = dbmp
        PictureBox9.BackgroundImage = RotateImg(img(0), 0.0F, Color.Transparent)
        PictureBox10.BackgroundImage = RotateImg(img(0), 270.0F, Color.Transparent)
        PictureBox11.BackgroundImage = RotateImg(img(0), 90.0F, Color.Transparent)
        PictureBox12.BackgroundImage = RotateImg(img(0), 180.0F, Color.Transparent)
        PictureBox13.BackgroundImage = RotateImg(img(0), 45.0F, Color.Transparent)
        PictureBox14.BackgroundImage = RotateImg(img(0), 135.0F, Color.Transparent)
        PictureBox15.BackgroundImage = RotateImg(img(0), 315.0F, Color.Transparent)
        PictureBox16.BackgroundImage = RotateImg(img(0), 225.0F, Color.Transparent)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Direction_Select = ""
        If RD_Buttom_0.Checked = True Then
            Direction_Select = "TOP"
        End If
        If RD_Buttom_45.Checked = True Then
            Direction_Select = "TOPRIGHT"
        End If
        If RD_Buttom_90.Checked = True Then
            Direction_Select = "RIGHT"
        End If
        If RD_Buttom_135.Checked = True Then
            Direction_Select = "BOTTOMRIGHT"
        End If
        If RD_Buttom_180.Checked = True Then
            Direction_Select = "BOTTOM"
        End If
        If RD_Buttom_225.Checked = True Then
            Direction_Select = "BOTTOMLEFT"
        End If
        If RD_Buttom_270.Checked = True Then
            Direction_Select = "LEFT"
        End If
        If RD_Buttom_315.Checked = True Then
            Direction_Select = "TOPLEFT"
        End If

        If Direction_Select <> "" Then
            Me.Close()
        End If
    End Sub
End Class