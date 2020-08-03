Option Explicit On
Imports System.Text

Public Class FrmCommunication

    Public StopFlag As Boolean
    Private Sub C_Stop_Click(sender As Object, e As EventArgs) Handles C_Stop.Click
        StopFlag = Not StopFlag
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'UTF to Unicode16
        Dim s As String

        s = TextBox1.Text

        Dim b() As Byte = System.Text.Encoding.Default.GetBytes(s)
        Dim s1 As String = System.Text.Encoding.UTF8.GetString(b)

        TextBox2.Text = s1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CommString As String
        Dim buf() As Byte

        CommString = "häöllo"

        buf = System.Text.Encoding.Default.GetBytes(CommString)
        MainForm.MSComm1.Write(buf, 0, buf.Length)
        'For Each i In b
        '    MainForm.MSComm1.Write(Strings.Chr(i))
        'Next

        'MainForm.MSComm1.Write(s1)




        'Dim c As Integer
        'c = &HEA
        'MainForm.MSComm1.Write(New Byte() {c}, 0, 1)




    End Sub
End Class