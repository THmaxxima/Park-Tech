Imports System.IO.Ports
Imports System
Imports System.Threading
Imports System.ComponentModel '
'Imports Microsoft.WindowsMobile.PocketOutlook
Public Class frmSMS
    Dim WithEvents serialport As New IO.Ports.SerialPort
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Sub frmSMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
        '    ComboBox1.Items.Add(My.Computer.Ports.SerialPortNames(i))
        'Next
        For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
            ComboBox1.Items.Add(My.Computer.Ports.SerialPortNames(i))
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If serialport.IsOpen Then
            serialport.Close()
        End If

        Try
            With serialport
                .PortName = ComboBox1.Text
                .BaudRate = 96000
                .Parity = Parity.None
                .DataBits = 8
                .StopBits = StopBits.One
                .Handshake = Handshake.RequestToSend
                .DtrEnable = True
                .RtsEnable = True
                .NewLine = vbCrLf
            End With
            serialport.Open()
        Catch ex As Exception

        End Try


        serialport.WriteLine("AT+CMGF=1" & vbCr)
        System.Threading.Thread.Sleep(200)
        serialport.WriteLine("AT+CMGS=" & Chr(34) & "destination" & Chr(34) & vbCr)
        System.Threading.Thread.Sleep(200)
        serialport.WriteLine("test message" & vbCrLf & Chr(26))
        System.Threading.Thread.Sleep(200)

    End Sub
End Class