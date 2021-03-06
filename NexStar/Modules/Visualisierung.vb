﻿Option Explicit On
Module Visualisierung

    Public Sub DispInit()

        GlbCx = 1
        GlbCY = -1
        GlbScale = 200
        Vis.Pic.BackColor = Color.Black
    End Sub


    Public Sub DispCoordinateSystem()
        Dim sx As Single
        Dim sy As Single
        Dim ex As Single
        Dim ey As Single
        Dim CenterX As Double
        Dim CenterY As Double
        Dim CoordColor As Color

        CoordColor = Color.DarkRed

        CenterX = GlbCx * GlbScale
        CenterY = GlbCY * -GlbScale

        DrawCircle(CenterX, CenterY, (90 / 90) * GlbScale, Color.Red, False)

        DrawCircle(CenterX, CenterY, (90 / 90) * GlbScale, CoordColor, False)
        DrawCircle(CenterX, CenterY, (70 / 90) * GlbScale, CoordColor, False)
        DrawCircle(CenterX, CenterY, (50 / 90) * GlbScale, CoordColor, False)
        DrawCircle(CenterX, CenterY, (30 / 90) * GlbScale, CoordColor, False)
        DrawCircle(CenterX, CenterY, (10 / 90) * GlbScale, CoordColor, False)




        Dim pen1 As New System.Drawing.Pen(CoordColor, 1)
        sx = (GlbCx - 0.05) * GlbScale
        sy = GlbCY * -GlbScale
        ex = (GlbCx + 0.05) * GlbScale
        ey = GlbCY * -GlbScale
        Vis.Pic.CreateGraphics.DrawLine(pen1, sx, sy, ex, ey)

        sx = GlbCx * GlbScale
        sy = (GlbCY - 0.05) * -GlbScale
        ex = GlbCx * GlbScale
        ey = (GlbCY + 0.05) * -GlbScale
        Vis.Pic.CreateGraphics.DrawLine(pen1, sx, sy, ex, ey)

        '=== Draw Polaris ===
        Dim Polaris As AzAlt
        Polaris.Az = 0
        Polaris.Alt = 0.5458

        ' Rotate -90°: North is below
        Polaris.Az = Polaris.Az - Pi / 2

        CenterX = (Math.Cos(Polaris.Az) * (1 - Polaris.Alt) + GlbCx) * GlbScale
        CenterY = (Math.Sin(Polaris.Az) * (1 - Polaris.Alt) + GlbCY) * -GlbScale
        DrawCircle(CenterX, CenterY, 2, CoordColor, True)

    End Sub

    Private Sub DrawCircle(x As Double, y As Double, r As Double, ccolor As Color, fill As Boolean)
        Dim myPen As Pen
        myPen = New Pen(ccolor, 1)


        Dim myRectangle As New Rectangle
        myRectangle.X = x - r
        myRectangle.Y = y - r
        myRectangle.Width = 2 * r
        myRectangle.Height = 2 * r
        Vis.Pic.CreateGraphics.DrawEllipse(myPen, myRectangle)
        If fill Then
            Vis.Pic.CreateGraphics.FillEllipse(New SolidBrush(ccolor), myRectangle)
        End If
    End Sub




    Public Sub DispTelescopePos(Polar As AzAlt)
        '    For i = 100 To 1000
        '        Vis.Pic.PSet (i, 4560), vbRed
        '    Next i

        Dim mx As Double
        Dim my As Double
        Dim Center As AzAlt
        Dim LclPolar As AzAlt

        LclPolar = Polar

        Static LastCenter As AzAlt
        ' Overwrite last circle with white
        DrawCircle(LastCenter.Az, LastCenter.Alt, 2, Color.Green, False)


        ' Rotate -90°: North is below
        LclPolar.Az = LclPolar.Az - Pi / 2

        ' convert 0..Pi/2 to 0..1
        ' LclPolar.Alt comes as 0..360°. Not OK here. hac to bey converted to +/-
        If LclPolar.Alt > Math.PI Then
            LclPolar.Alt = LclPolar.Alt - 2 * Math.PI
        End If

        LclPolar.Alt = LclPolar.Alt * (1 / (Math.PI / 2))

        Center.Az = (Math.Cos(LclPolar.Az) * (1 - LclPolar.Alt) + GlbCx) * GlbScale
        Center.Alt = (Math.Sin(LclPolar.Az) * (1 - LclPolar.Alt) + GlbCY) * -GlbScale
        DrawCircle(Center.Az, Center.Alt, 2, Color.Blue, False)

        LastCenter = Center

    End Sub

    Public Sub DispAlignmentStar(Polar As AzAlt)
        Dim mx As Double
        Dim my As Double
        Dim Center As AzAlt
        Dim LclPolar As AzAlt

        LclPolar = Polar

        '=== Replace old star with a point ===
        Static LastCenter As AzAlt
        ' Overwrite last circle with black
        DrawCircle(LastCenter.Az, LastCenter.Alt, 5, Color.Black, True)
        ' Draw a small point
        DrawCircle(LastCenter.Az, LastCenter.Alt, 1, Color.Gray, True)

        ' Rotate -90°: North is below
        LclPolar.Az = -LclPolar.Az - Pi / 2

        ' convert 0..Pi/2 to 0..1
        ' LclPolar.Alt comes as +/-.  Thats OK here
        LclPolar.Alt = LclPolar.Alt * (1 / (Pi / 2))


        Center.Az = (Math.Cos(LclPolar.Az) * (1 - LclPolar.Alt) + GlbCx) * GlbScale
        Center.Alt = (Math.Sin(LclPolar.Az) * (1 - LclPolar.Alt) + GlbCY) * -GlbScale
        DrawCircle(Center.Az, Center.Alt, 5, Color.White, True)

        LastCenter = Center

    End Sub

End Module
