Option Explicit On

Public Class FrmMoveTelescope
    Private Structure POINTAPI
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public MoveGalvoAKT As Boolean

    Dim PixelFaktor As Double
    Dim GalvoLastPositionX As Double
    Dim GalvoLastPositionY As Double

    Dim PixelFaktorGrob As Double
    Dim PixelFaktorMittel As Double
    Dim PixelFaktorFein As Double

    Dim CounterActiveX As Integer
    Dim CounterActiveY As Integer


    Private Declare Function SetCursorPos Lib "user32" (ByVal X As Integer, ByVal Y As Integer) As Integer
    Private Declare Function GetCursorPos Lib "user32" (ByRef lpPoint As POINTAPI) As Integer
    'SWE  Private Declare Function ClientToScreen Lib "user32" (ByVal hWnd As Long, lpPoint As POINTAPI) As Long
    'SWE  Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
    'SWE  Private Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
    Private Declare Function GetAsyncKeyState Lib "User32" (ByVal vKey As Integer) As Short


    Private Sub FrmMoveTelescope_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMoveGalvo()
        MoveGalvoStartToolStripMenuItem1.PerformClick()
    End Sub


    Private Sub F3FeinToolStripMenuItem_Click(sender As Object, e As EventArgs)
        PixelFaktor = PixelFaktorFein
        MouseTimer.Enabled = True
    End Sub


    Private Sub F1GrobToolStripMenuItem_Click(sender As Object, e As EventArgs)
        PixelFaktor = PixelFaktorGrob
        MouseTimer.Enabled = True
    End Sub


    Private Sub F2MittelToolStripMenuItem_Click(sender As Object, e As EventArgs)
        PixelFaktor = PixelFaktorMittel
        MouseTimer.Enabled = True
    End Sub


    Private Sub MoveGalvoStartToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MoveGalvoStartToolStripMenuItem1.Click
        ' https://activevb.de/tipps/vbnettipps/tipp0125.html

        MoveGalvoAKT = True
        MouseTimer.Enabled = True
    End Sub


    Private Sub ESCMoveGalvoStopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ESCMoveGalvoStopToolStripMenuItem1.Click
        MoveGalvoAKT = False
        MouseTimer.Enabled = False

        L_SpeedX.Text = 0
        L_SpeedY.Text = 0

        'Dim CommString As String
        'CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        'NexStarCommunication(CommString, " Move up: (0x06) " & 0 & ", (0x1A) " & 0, ProtokollMode.Send)

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Stop Moving"

        PushCommandBuffer(NexStarCmd)

        Me.Close()
    End Sub


    Private Sub MouseTimer_Tick(sender As Object, e As EventArgs) Handles MouseTimer.Tick

        Dim GlobalMousePosition As POINTAPI
        Dim XDiffPix As Integer
        Dim YDiffPix As Integer
        Dim XDiffRel As Integer
        Dim YDiffRel As Integer
        Dim CommString As String
        Dim CmdX As String
        Dim CmdY As String
        Dim CommentX As String
        Dim CommentY As String

        Dim PicPos As POINTAPI
        Dim FormPos As POINTAPI
        Dim PicBoxCenter As POINTAPI
        Dim PicSize As POINTAPI

        PicPos.X = Picture_Mouse_Move.Left
        PicPos.Y = Picture_Mouse_Move.Top
        PicSize.X = Picture_Mouse_Move.Width
        PicSize.Y = Picture_Mouse_Move.Height
        FormPos.X = Me.Left
        FormPos.Y = Me.Top

        PicBoxCenter.X = PicPos.X + FormPos.X + PicSize.X / 2
        PicBoxCenter.Y = PicPos.Y + FormPos.Y + PicSize.Y / 2

        If MoveGalvoAKT = True Then
            GetCursorPos(GlobalMousePosition)

            XDiffPix = Limit(GlobalMousePosition.X - PicBoxCenter.X, -100, 100)
            YDiffPix = Limit(GlobalMousePosition.Y - PicBoxCenter.Y, -100, 100)

            XDiffRel = XDiffPix * PixelFaktor
            YDiffRel = -YDiffPix * PixelFaktor



            If Math.Abs(XDiffRel) >= (Math.Abs(YDiffRel)) Then
                YDiffRel = 0
            ElseIf Math.Abs(YDiffRel) > (Math.Abs(XDiffRel)) Then
                XDiffRel = 0
            End If

            'If Math.Abs(XDiffRel) > (Math.Abs(YDiffRel)) Then
            '    CounterActiveX = CounterActiveX + 1
            'ElseIf Math.Abs(YDiffRel) > (Math.Abs(XDiffRel)) Then
            '    CounterActiveY = CounterActiveY + 1
            'End If

            'If CounterActiveX > CounterActiveY Then
            '    'CounterActiveX = 0
            '    YDiffRel = 0
            'Else
            '    'CounterActiveY = 0
            '    XDiffRel = 0
            'End If


            L_SpeedX.Text = XDiffRel
            L_SpeedY.Text = YDiffRel

            If XDiffRel >= 0 Then
                CmdX = Strings.Chr(&H6)
                CommentX = "Move right (0x06) " & CDbl(XDiffRel)
            Else
                CmdX = Strings.Chr(&H7)
                XDiffRel = -XDiffRel
                CommentX = "Move left (0x07) " & CDbl(XDiffRel)
            End If

            If YDiffRel >= 0 Then
                CmdY = Strings.Chr(&H1A)
                CommentY = ", up (0x1A) " & CDbl(YDiffRel)
            Else
                CmdY = Strings.Chr(&H1B)
                YDiffRel = -YDiffRel
                CommentY = ", down (0x1B) " & CDbl(YDiffRel)
            End If

            CommString = CmdX & SetNexStarPosition(CDbl(XDiffRel)) & CmdY & SetNexStarPosition(CDbl(YDiffRel))
            'NexStarCommunication(CommString, CommentX & CommentY, ProtokollMode.Send)



            Dim NexStarCmd As CommandItem



            NexStarCmd.No = 6
            NexStarCmd.Cmd = CommString
            NexStarCmd.Comment = CommentX & CommentY

            PushCommandBuffer(NexStarCmd)


            SetCursorPos(PicBoxCenter.X, PicBoxCenter.Y)
        End If

        If CompKey(Keys.F1) Then
            PixelFaktor = PixelFaktorGrob
            Exit Sub
        End If

        If CompKey(Keys.F2) Then
            PixelFaktor = PixelFaktorMittel
            Exit Sub
        End If

        If CompKey(Keys.F3) Then
            PixelFaktor = PixelFaktorFein
            Exit Sub
        End If

        If CompKey(Keys.Escape) Then
            ESCMoveGalvoStopToolStripMenuItem1.PerformClick()
            Exit Sub
        End If

    End Sub


    Private Sub Picture_Mouse_Move_Click()
        If MoveGalvoAKT Then MouseTimer.Enabled = True
    End Sub


    Private Sub Picture_Mouse_Move_MouseDown(sender As Object, e As MouseEventArgs) Handles Picture_Mouse_Move.MouseDown
        If e.Button = MouseButtons.Left Then
            If PixelFaktor = PixelFaktorGrob Then
                PixelFaktor = PixelFaktorMittel
            ElseIf PixelFaktor = PixelFaktorMittel Then
                PixelFaktor = PixelFaktorFein
            ElseIf PixelFaktor = PixelFaktorFein Then
                PixelFaktor = PixelFaktorGrob
            End If
            L_PixelFaktor.Text = DisplayPixelFaktor(PixelFaktor)
        ElseIf e.Button = MouseButtons.Right Then
            ESCMoveGalvoStopToolStripMenuItem1.PerformClick()
        End If
    End Sub


    Private Sub InitMoveGalvo()
        PixelFaktorGrob = 1000
        PixelFaktorMittel = 100
        PixelFaktorFein = 1

        PixelFaktor = PixelFaktorMittel
        L_PixelFaktor.Text = DisplayPixelFaktor(PixelFaktor)

        MoveGalvoAKT = False
    End Sub


    Private Function CompKey(KCode As Keys) As Boolean
        Dim result As Short
        result = GetAsyncKeyState(KCode)
        If result = -32767 Then
            CompKey = True
        Else
            CompKey = False
        End If
    End Function

    Private Function DisplayPixelFaktor(Faktor As Integer) As String
        Select Case Faktor
            Case PixelFaktorGrob
                DisplayPixelFaktor = "Schnell"
            Case PixelFaktorMittel
                DisplayPixelFaktor = "Mittel"
            Case PixelFaktorFein
                DisplayPixelFaktor = "Langsam"
            Case Else
                DisplayPixelFaktor = "--"
        End Select
    End Function


End Class