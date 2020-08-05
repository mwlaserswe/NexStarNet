Imports System.Drawing.Drawing2D

Public Class Vis
    Private gp As GraphicsPath

    Private Sub Vis_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        DispInit()
        DispCoordinateSystem()
    End Sub





    '==== Demo Gruppe füllen ===
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gp = New GraphicsPath()
        gp.AddLine(New Point(444, 22), New Point(666, 22))
        gp.AddLine(New Point(666, 22), New Point(666, 111))
        gp.AddLine(New Point(666, 111), New Point(444, 111))
        gp.AddLine(New Point(444, 111), New Point(444, 22))
        gp.CloseFigure()
        Me.Invalidate()
        Me.Update()
    End Sub
    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If gp IsNot Nothing Then
            e.Graphics.FillPath(Brushes.HotPink, gp)
        End If
    End Sub

    Private Sub B_Clear_Click(sender As Object, e As EventArgs) Handles B_Clear.Click
        Pic.CreateGraphics.Clear(Color.Black)
        DispCoordinateSystem()
    End Sub
End Class