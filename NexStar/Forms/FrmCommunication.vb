Option Explicit On
Public Class FrmCommunication

    Public StopFlag As Boolean
    Private Sub C_Stop_Click(sender As Object, e As EventArgs) Handles C_Stop.Click
        StopFlag = Not StopFlag
    End Sub

End Class