﻿Option Explicit On
Imports System.IO
Imports System.IO.Ports

Imports System
Imports System.Runtime.InteropServices

Public Class MainForm

    Dim NexStarPortNr As Long
    Dim NexStarBaudrate As Long
    Dim CommandWait As Boolean
    Dim CommandCnt As Long
    Dim InputBufferAz As String
    Dim InputbufferAlt As String
    Dim TelIncr As AzAlt

    Dim ManualSlewingSpeedX As Double
    Dim ManualSlewingSpeedY As Double

    'Simulation
    Dim SimIncr As AzAlt

    Dim SimBntUp As Boolean
    Dim SimBntDn As Boolean
    Dim SimBntLe As Boolean
    Dim SimBntRi As Boolean
    Dim SimGotoAzAltActive As Boolean
    Dim SimGoto As AzAlt
    Dim SimTrackingStep As AzAlt


    Private Enum NxMode
        Unchanged = 0
        HMS = 1
        HourDec = 2
        DegDec = 3
    End Enum


    Private Sub AlignmentStarList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AlignmentStarList.SelectedIndexChanged
        Dim idx As Long

        ' Search star name in list
        idx = -1
        Do
            idx = idx + 1
        Loop Until (AlignmentStarArray(idx).ProperName = AlignmentStarList.Text) Or (idx >= UBound(AlignmentStarArray))
        '    L_CurrentStar = AlignmentStarArray(idx).ProperName




        PreviewRaDec.Ra = HourToRad(AlignmentStarArray(idx).Ra)
        PreviewRaDec.Dec = DegToRad(AlignmentStarArray(idx).Dec)

        Dim StarPos As AzAlt
        StarPos = RA_DEC_to_AZ_ALT_new(PreviewRaDec, GlbOberverPos, GlbSiderialTime)
        '    StarPos = AzAlt_to_MatrixSystem(StarPos)
        DispAlignmentStar(StarPos)

    End Sub


    Private Sub C_GetAz_Click(sender As Object, e As EventArgs) Handles C_GetAz.Click

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 1
        NexStarCmd.Cmd = Strings.Chr(&H1)
        NexStarCmd.Comment = " Read Az (0x01)"

        PushCommandBuffer(NexStarCmd)

    End Sub


    Private Sub C_GetAlt_Click(sender As Object, e As EventArgs) Handles C_GetAlt.Click

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 21
        NexStarCmd.Cmd = Strings.Chr(&H15)
        NexStarCmd.Comment = " Read Alt (0x15)"

        PushCommandBuffer(NexStarCmd)

    End Sub


    Private Sub C_GotoNorth_Click(sender As Object, e As EventArgs) Handles C_GotoNorth.Click
        ReadStatus = True
        StatusMoving = 0

        Dim MotorIncr As AzAlt

        MotorIncr = Matrix_To_MotorIncrSystem(GlobalOffset)


        If SimOffline Then
            SimGotoAzAltActive = True
            SimGoto = MotorIncr
        'Else
        '    Dim CommString As String
        '    CommString = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
        '    NexStarCommunication(CommString, " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt), ProtokollMode.Send)
        End If


        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 2
        NexStarCmd.Cmd = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
        NexStarCmd.Comment = " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt)

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_GotoStar_Click(sender As Object, e As EventArgs) Handles C_GotoStar.Click
        ReadStatus = True
        StatusMoving = 0



        '==== Telescope moves to this star ====
        ObserverRaDec = PreviewRaDec
        Tim_Tracking_Tick(Nothing, Nothing)

        Dim tmp As AzAlt
        tmp.Az = ObserverAzAlt.Az
        tmp.Alt = ObserverAzAlt.Alt
        MatrixSystemSoll = AzAlt_to_MatrixSystem(tmp)
        F_StarInfo.Text = F_PreviewInfo.Text


        ' Stern in Combobox eintragen
        Dim k As Integer
        Dim DoubleItem As Boolean
        Dim FindName As String

        k = CB_Find.Items.Count
        If k > 0 Then
            For i = 0 To CB_Find.Items.Count - 1
                FindName = CB_Find.Items(i)
                If F_StarInfo.Text = CB_Find.Items(i) Then
                    DoubleItem = True
                End If
            Next i
        End If

        If Not DoubleItem Then
            CB_Find.Items.Add(F_StarInfo.Text)
        End If

        If GlbCalibStatus = 0 Or GlbCalibStatus = 1 Then
            Dim MotorIncr As AzAlt
            MotorIncr = Matrix_To_MotorIncrSystem(MatrixSystemSoll)

            If SimOffline Then
                SimGotoAzAltActive = True
                SimGoto = MotorIncr
            End If

            Dim NexStarCmd As CommandItem



            NexStarCmd.No = 2
            NexStarCmd.Cmd = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
            NexStarCmd.Comment = " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt)

            PushCommandBuffer(NexStarCmd)



        ElseIf GlbCalibStatus = 2 Then
            ReadStatus = True
            StatusMoving = 0


            Dim AimTimeRad As Double
            Dim AzAlt_BetaCet As AzAlt

            '==== Telescope moves to this star ====
            ObserverRaDec = PreviewRaDec
            AimTimeRad = TimeToRad(ObserverTimeUT)

            TrackingisON = False

            CalculateTelescopeCoordinates(Cal_InitTime,
                                      ObserverRaDec, AimTimeRad, TransformationMatrix,
                                      AzAlt_BetaCet)


            'Set Az
            MatrixSystemSoll.Az = CutRad(AzAlt_BetaCet.Az)
            'Set Alt
            MatrixSystemSoll.Alt = AzAlt_BetaCet.Alt

            MatrixLastCalc = MatrixSystemSoll


            Dim MotorIncr As AzAlt
            MotorIncr = Matrix_To_MotorIncrSystem(MatrixSystemSoll)
            MotorLastCalc = MotorIncr

            If SimOffline Then
                SimGotoAzAltActive = True
                SimGoto = MotorIncr
                'Else
                '    Dim CommString As String
                '    CommString = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
                '    NexStarCommunication(CommString, " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt), ProtokollMode.Send)
            End If


            Dim NexStarCmd As CommandItem



            NexStarCmd.No = 2
            NexStarCmd.Cmd = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
            NexStarCmd.Comment = " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt)

            PushCommandBuffer(NexStarCmd)
        End If
    End Sub


    'Private Sub C_GotoStarCalibrated_Click(sender As Object, e As EventArgs) Handles C_GotoStarCalibrated.Click
    '    ReadStatus = True
    '    StatusMoving = 0


    '    Dim AimTimeRad As Double
    '    Dim AzAlt_BetaCet As AzAlt

    '    '==== Telescope moves to this star ====
    '    ObserverRaDec = PreviewRaDec
    '    AimTimeRad = TimeToRad(ObserverTimeUT)

    '    TrackingisON = False

    '    CalculateTelescopeCoordinates(Cal_InitTime,
    '                              ObserverRaDec, AimTimeRad, TransformationMatrix,
    '                              AzAlt_BetaCet)


    '    'Set Az
    '    MatrixSystemSoll.Az = CutRad(AzAlt_BetaCet.Az)
    '    'Set Alt
    '    MatrixSystemSoll.Alt = AzAlt_BetaCet.Alt

    '    MatrixLastCalc = MatrixSystemSoll


    '    Dim MotorIncr As AzAlt
    '    MotorIncr = Matrix_To_MotorIncrSystem(MatrixSystemSoll)
    '    MotorLastCalc = MotorIncr

    '    If SimOffline Then
    '        SimGotoAzAltActive = True
    '        SimGoto = MotorIncr
    '        'Else
    '        '    Dim CommString As String
    '        '    CommString = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
    '        '    NexStarCommunication(CommString, " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt), ProtokollMode.Send)
    '    End If


    '    Dim NexStarCmd As CommandItem



    '    NexStarCmd.No = 2
    '    NexStarCmd.Cmd = Strings.Chr(&O2) & SetNexStarPosition(CLng(MotorIncr.Az)) & Strings.Chr(&H16) & SetNexStarPosition(CLng(MotorIncr.Alt))
    '    NexStarCmd.Comment = " Goto AzAlt (0x02): " & CLng(MotorIncr.Az) & " " & CLng(MotorIncr.Alt)

    '    PushCommandBuffer(NexStarCmd)
    'End Sub


    Private Sub C_MoveTelescope_Click(sender As Object, e As EventArgs) Handles C_MoveTelescope.Click
        FrmMoveTelescope.Show()
    End Sub


    Private Sub C_Set_ObserverLocation_Click(sender As Object, e As EventArgs) Handles C_Set_ObserverLocation.Click
        ObserverLatt.deg = Zahl(T_Latt_Grad.Text)
        ObserverLatt.Min = Zahl(T_Latt_Min.Text)
        ObserverLatt.Sec = Zahl(T_Latt_Sek.Text)
        ObserverLatt.Sign = T_Latt_Sign.Text
        ObserverLong.deg = Zahl(T_Long_Grad.Text)
        ObserverLong.Min = Zahl(T_Long_Min.Text)
        ObserverLong.Sec = Zahl(T_Long_Sek.Text)
        ObserverLong.Sign = T_Long_Sign.Text

        My.Settings.UserDefinedDay = T_Tag.Text
        My.Settings.UserDefinedMonth = T_Monat.Text
        My.Settings.UserDefinedYear = T_Jahr.Text
        My.Settings.UserDefinedHour = T_Stunden.Text
        My.Settings.UserDefinedMinute = T_Minuten.Text
        My.Settings.UserDefinedSecond = T_Sekunden.Text

        My.Settings.ObserverLattGrad = T_Latt_Grad.Text
        My.Settings.ObserverLattMin = T_Latt_Min.Text
        My.Settings.ObserverLattSek = T_Latt_Sek.Text
        My.Settings.ObserverLattSign = T_Latt_Sign.Text
        My.Settings.ObserverLongGrad = T_Long_Grad.Text
        My.Settings.ObserverLongMin = T_Long_Min.Text
        My.Settings.ObserverLongSek = T_Long_Sek.Text
        My.Settings.ObserverLongSign = T_Long_Sign.Text
        My.Settings.Save()
    End Sub


    Private Sub C_SetBacklAz_Click(sender As Object, e As EventArgs) Handles C_SetBacklAz.Click
        Dim BacklashAlt As Long    '0..100


        BacklashAlt = T_Backlash.Text

        Dim NexStarCmd As CommandItem

        NexStarCmd.No = 30
        NexStarCmd.Cmd = Strings.Chr(&H1E) & SetNexStarPosition(BacklashAlt)
        NexStarCmd.Comment = " Backlash Alt (0x1E): " & BacklashAlt

        PushCommandBuffer(NexStarCmd)

        'If SimOffline Then
        'Else
        '    Dim CommString As String
        '    CommString = Strings.Chr(&H1E) & SetNexStarPosition(BacklashAlt)
        '    NexStarCommunication(CommString, " Backlash Alt (0x1E): " & BacklashAlt, ProtokollMode.Send)
        'End If
    End Sub


    Private Sub C_SetBacklAlt_Click(sender As Object, e As EventArgs) Handles C_SetBacklAlt.Click
        Dim BacklashAz As Long    '0..100


        BacklashAz = T_Backlash.Text

        Dim NexStarCmd As CommandItem

        NexStarCmd.No = 10
        NexStarCmd.Cmd = Strings.Chr(&HA) & SetNexStarPosition(BacklashAz)
        NexStarCmd.Comment = " Backlash Az (0x0A): " & BacklashAz

        PushCommandBuffer(NexStarCmd)

        'If SimOffline Then
        'Else
        '    Dim CommString As String
        '    CommString = Strings.Chr(&HA) & SetNexStarPosition(BacklashAz)
        '    NexStarCommunication(CommString, " Backlash Az (0x0A): " & BacklashAz, ProtokollMode.Send)
        'End If
    End Sub




    ''Private Sub C_SetCalibrationStar_1_Click()
    ''
    ''    Cal_RaStar_1 = ObserverRaDec.Ra
    ''    Cal_DecStar_1 = ObserverRaDec.Dec
    ''    Cal_TelHorizAngle_1 = MatrixSystemIst.Az
    ''    Cal_TelElevAngle_1 = MatrixSystemIst.Alt
    ''
    ''Cal_Star_1_RaDec = ObserverRaDec
    ''Cal_Tel_1_AzAlt = MatrixSystemIst
    ''
    ''
    ''    'Set time reference star 1 for calibration
    ''    Cal_Time_1 = TimeToRad(ObserverTimeUT)
    ''
    ''    C_SetCalibrationStar_1.BackColor = vbGreen
    ''End Sub

   Private Sub C_SetCalibrationStar_2_Click(sender As Object, e As EventArgs) Handles C_SetCalibrationStar_2.Click

        Dim Angle As Double

        Cal_RaStar_2 = ObserverRaDec.Ra
        Cal_DecStar_2 = ObserverRaDec.Dec
        Cal_TelHorizAngle_2 = MatrixSystemIst.Az
        Cal_TelElevAngle_2 = MatrixSystemIst.Alt

        Cal_Star_2_RaDec = ObserverRaDec
        Cal_Tel_2_AzAlt = MatrixSystemIst


        'Set time reference star 2 for calibration
        Cal_Time_2 = TimeToRad(ObserverTimeUT)

        C_SetCalibrationStar_2.BackColor = Color.LawnGreen


        Angle = AngleBetweenTelescopePositions(Cal_Tel_1_AzAlt, Cal_Tel_2_AzAlt)
        L_Angle.Text = Format(RadToDeg(Angle), "0.0000") & "°"



        'Set second start for 2 point calibration
        Label6.Text = "--"
        CalibrateTelescope__OLD(Cal_InitTime,
                       Cal_RaStar_1, Cal_DecStar_1, Cal_TelHorizAngle_1, Cal_TelElevAngle_1, Cal_Time_1,
                       Cal_RaStar_2, Cal_DecStar_2, Cal_TelHorizAngle_2, Cal_TelElevAngle_2, Cal_Time_2,
                       TransformationMatrix__OLD)

        CalibrateTelescope(Cal_InitTime,
                       Cal_Star_1_RaDec, Cal_Tel_1_AzAlt, Cal_Time_1,
                       Cal_Star_2_RaDec, Cal_Tel_2_AzAlt, Cal_Time_2,
                       TransformationMatrix)

        C_SetCalibrationStar_2.BackColor = Color.LawnGreen
        C_SetCalibrationStar_2.Text = "Second Star: " & F_StarInfo.Text

        ' Set status 2 point calibration done
        GlbCalibStatus = 2

    End Sub


    Private Sub C_SetEncoder_Az_Click(sender As Object, e As EventArgs) Handles C_SetEncoder_Az.Click
        'Command = 12
        'If SimOffline Then
        'Else
        '    Dim CommString As String
        '    CommString = Strings.Chr(&HC) & SetNexStarPosition(EncoderResolution)
        '    NexStarCommunication(CommString, " Encoder Rsolution Az:   0x0C " & EncoderResolution, ProtokollMode.Send)
        'End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 12
        NexStarCmd.Cmd = Strings.Chr(&HC) & SetNexStarPosition(EncoderResolution)
        NexStarCmd.Comment = " Encoder Rsolution Az:   0x0C " & EncoderResolution

        PushCommandBuffer(NexStarCmd)

    End Sub


    Private Sub C_SetEncoder_Alt_Click(sender As Object, e As EventArgs) Handles C_SetEncoder_Alt.Click
        'Command = 31
        'If SimOffline Then
        'Else
        '    Dim CommString As String
        '    CommString = Strings.Chr(&H1F) & SetNexStarPosition(EncoderResolution)
        '    NexStarCommunication(CommString, " Encoder Rsolution Alt:   0x1F " & EncoderResolution, ProtokollMode.Send)
        'End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 31
        NexStarCmd.Cmd = Strings.Chr(&H1F) & SetNexStarPosition(EncoderResolution)
        NexStarCmd.Comment = " Encoder Rsolution Alt:   0x1F " & EncoderResolution

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Simulation_Click(sender As Object, e As EventArgs) Handles C_Simulation.Click

        If SimOffline Then
            SimOffline = False
            InitNexStarComm()
        Else
            SimOffline = True
        End If

        My.Settings.SimOffline = SimOffline
        My.Settings.Save()

    End Sub


    Private Sub C_SingleStarCalib_Click(sender As Object, e As EventArgs) Handles C_SingleStarCalib.Click

        Dim tmp1 As AzAlt
        Dim tmp2 As Double
        Dim tmp3 As Double
        Dim tmp4 As Double
        Dim tmp5 As Double
        Dim tmp6 As Double


        tmp2 = GlobalOffset.Az
        tmp2 = MatrixSystemIst.Az
        tmp3 = MatrixSystemSoll.Az

        GlobalOffset = AddAzAlt(GlobalOffset, SubAzAlt(MatrixSystemIst, MatrixSystemSoll))

        ' Set status 1 point calibration done
        GlbCalibStatus = 1

        tmp1 = ObserverAzAlt
        MatrixSystemSoll = AzAlt_to_MatrixSystem(tmp1)


        'Set Initial for calibration
        Cal_InitTime = TimeToRad(ObserverTimeUT)

        C_SingleStarCalib.BackColor = Color.LawnGreen



        'Set first star of 2-star-calibration
        Cal_RaStar_1 = ObserverRaDec.Ra
        Cal_DecStar_1 = ObserverRaDec.Dec
        Cal_TelHorizAngle_1 = MatrixSystemIst.Az
        Cal_TelElevAngle_1 = MatrixSystemIst.Alt

        Cal_Star_1_RaDec = ObserverRaDec
        Cal_Tel_1_AzAlt = MatrixSystemIst


        'Set time reference star 1 for calibration
        Cal_Time_1 = TimeToRad(ObserverTimeUT)

        C_SingleStarCalib.Text = "Fist Star: " & F_StarInfo.Text
    End Sub

    Private Sub C_Tracking_Click(sender As Object, e As EventArgs) Handles C_Tracking.Click
        If TrackingisON Then
            TrackingisON = False

            'If SimOffline Then
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Stop Tracking", ProtokollMode.Send)
            'End If

            Dim NexStarCmd As CommandItem



            NexStarCmd.No = 6
            NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            NexStarCmd.Comment = " Stop Tracking"

            PushCommandBuffer(NexStarCmd)


        Else
            TrackingisON = True
        End If

    End Sub


    Private Sub C_Up_MouseDown(sender As Object, e As MouseEventArgs) Handles C_Up.MouseDown
        If SimOffline Then
            SimBntUp = True
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(CDbl(ManualSlewingSpeedY))
            '    NexStarCommunication(CommString, " Move up: (0x06) " & 0 & ", (0x1A) " & CDbl(ManualSlewingSpeedY), ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(CDbl(ManualSlewingSpeedY))
        NexStarCmd.Comment = " Move up: (0x06) " & 0 & ", (0x1A) " & CDbl(ManualSlewingSpeedY)

        PushCommandBuffer(NexStarCmd)

    End Sub


    Private Sub C_Up_MouseUp(sender As Object, e As MouseEventArgs) Handles C_Up.MouseUp
        If SimOffline Then
            SimBntUp = False
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Stop", ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Stop"

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Dn_MouseDown(sender As Object, e As MouseEventArgs) Handles C_Dn.MouseDown
        If SimOffline Then
            SimBntDn = True
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1B) & SetNexStarPosition(CDbl(ManualSlewingSpeedY))
            '    NexStarCommunication(CommString, " Move down: (0x06) " & 0 & ", (0x1B) " & CDbl(ManualSlewingSpeedY), ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1B) & SetNexStarPosition(CDbl(ManualSlewingSpeedY))
        NexStarCmd.Comment = " Move down: (0x06) " & 0 & ", (0x1B) " & CDbl(ManualSlewingSpeedY)

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Dn_MouseUp(sender As Object, e As MouseEventArgs) Handles C_Dn.MouseUp
        If SimOffline Then
            SimBntDn = False
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Stop", ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Stop"

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Le_MouseDown(sender As Object, e As MouseEventArgs) Handles C_Le.MouseDown
        If SimOffline Then
            SimBntLe = True
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H7) & SetNexStarPosition(CDbl(ManualSlewingSpeedX)) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Move left: (0x07) " & CDbl(ManualSlewingSpeedX) & ", (0x1A) " & 0, ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 7
        NexStarCmd.Cmd = Strings.Chr(&H7) & SetNexStarPosition(CDbl(ManualSlewingSpeedX)) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Move left: (0x07) " & CDbl(ManualSlewingSpeedX) & ", (0x1A) " & 0

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Le_MouseUp(sender As Object, e As MouseEventArgs) Handles C_Le.MouseUp
        If SimOffline Then
            SimBntLe = False
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Stop", ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 7
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Stop"

        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Ri_MouseDown(sender As Object, e As MouseEventArgs) Handles C_Ri.MouseDown
        If SimOffline Then
            SimBntRi = True
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(CDbl(ManualSlewingSpeedX)) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Move right: (0x06) " & CDbl(ManualSlewingSpeedX) & ", (0x1A) " & 0, ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(CDbl(ManualSlewingSpeedX)) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Move right: (0x06) " & CDbl(ManualSlewingSpeedX) & ", (0x1A) " & 0
        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub C_Ri_MouseUp(sender As Object, e As MouseEventArgs) Handles C_Ri.MouseUp
        If SimOffline Then
            SimBntRi = False
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
            '    NexStarCommunication(CommString, " Stop", ProtokollMode.Send)
        End If

        Dim NexStarCmd As CommandItem



        NexStarCmd.No = 6
        NexStarCmd.Cmd = Strings.Chr(&H6) & SetNexStarPosition(0) & Strings.Chr(&H1A) & SetNexStarPosition(0)
        NexStarCmd.Comment = " Stop"
        PushCommandBuffer(NexStarCmd)
    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Slider1.Value = 600


        ManualMovement = False

        O_TimeSelectLocal.Checked = True




        VS_ManualSlewingSpeed.Value = 0
        VS_ManualSlewingSpeed_Scroll(Nothing, Nothing)

        DefaultPath = My.Settings.BasicsDefaultPath
        DefaultStarKatalog = My.Settings.BasicsDefaultStarKatalog

        Dim SimString As String
        SimString = My.Settings.SimOffline
        If My.Settings.SimOffline = "False" Then
            SimOffline = False
        Else
            SimOffline = True
        End If

        InitNexStarComm()

        LoadAlignmetStarFile()

        T_Latt_Grad.Text = My.Settings.ObserverLattGrad
        T_Latt_Min.Text = My.Settings.ObserverLattMin
        T_Latt_Sek.Text = My.Settings.ObserverLattSek
        T_Latt_Sign.Text = My.Settings.ObserverLattSign
        T_Long_Grad.Text = My.Settings.ObserverLongGrad
        T_Long_Min.Text = My.Settings.ObserverLongMin
        T_Long_Sek.Text = My.Settings.ObserverLongSek
        T_Long_Sign.Text = My.Settings.ObserverLongSign

        ObserverLatt.deg = Zahl(T_Latt_Grad.Text)
        ObserverLatt.Min = Zahl(T_Latt_Min.Text)
        ObserverLatt.Sec = Zahl(T_Latt_Sek.Text)
        ObserverLatt.Sign = T_Latt_Sign.Text
        ObserverLong.deg = Zahl(T_Long_Grad.Text)
        ObserverLong.Min = Zahl(T_Long_Min.Text)
        ObserverLong.Sec = Zahl(T_Long_Sek.Text)
        ObserverLong.Sign = T_Long_Sign.Text

        T_Tag.Text = My.Settings.UserDefinedDay
        T_Monat.Text = My.Settings.UserDefinedMonth
        T_Jahr.Text = My.Settings.UserDefinedYear
        T_Stunden.Text = My.Settings.UserDefinedHour
        T_Minuten.Text = My.Settings.UserDefinedMinute
        T_Sekunden.Text = My.Settings.UserDefinedSecond

        T_Backlash.Text = My.Settings.Backlash

        Cal_InitTime = Zahl(My.Settings.TransformationMatrixCalInitTime)
        TransformationMatrix(0, 0) = Zahl(My.Settings.TransformationMatrix_00)
        TransformationMatrix(0, 1) = Zahl(My.Settings.TransformationMatrix_01)
        TransformationMatrix(0, 2) = Zahl(My.Settings.TransformationMatrix_02)
        TransformationMatrix(1, 0) = Zahl(My.Settings.TransformationMatrix_10)
        TransformationMatrix(1, 1) = Zahl(My.Settings.TransformationMatrix_11)
        TransformationMatrix(1, 2) = Zahl(My.Settings.TransformationMatrix_12)
        TransformationMatrix(2, 0) = Zahl(My.Settings.TransformationMatrix_20)
        TransformationMatrix(2, 1) = Zahl(My.Settings.TransformationMatrix_21)
        TransformationMatrix(2, 2) = Zahl(My.Settings.TransformationMatrix_22)



        'SWE       Dim nw As String
        'SWE       Dim CommFile As Integer
        'SWE       nw = Now
        'SWE   
        'SWE       '    CommFileName = App.Path & "\Commu_" & Year(nw) & Month(nw) & Day(nw) & Hour(nw) & Minute(nw) & Second(nw) & ".txt"
        'SWE       CommFileName = App.Path & "\Commu_.txt"
        'SWE       CommFile = FreeFile()
        'SWE       On Error GoTo openErr
        'SWE       Open CommFileName For Output As CommFile
        'SWE   Close CommFile
        'SWE   


        Dim CursorFullPath As String
        CursorFileName = My.Settings.Cursor
        CursorFullPath = Path.Combine(DefaultPath, "Cursors", CursorFileName)
        If System.IO.File.Exists(CursorFullPath) Then
            'Me.Cursor = Cursors.Arrow
            'http://cool-web.de/mouse-pointer/cursors.htm
            'Me.Cursor = AdvancedCursors.Create(Path.Combine(DefaultPath, "globe.ani"))
            Me.Cursor = AdvancedCursors.Create(Path.Combine(CursorFullPath))
        Else
            MsgBox("Datei nicht gefunden: " & CursorFullPath)
        End If



        Vis.Show()

        Exit Sub

openErr:
        MsgBox(CommFileName & vbCr & Err.Description, , "NexStar Error 001")

    End Sub


    Public Class AdvancedCursors
        <DllImport("User32.dll")>
        Private Shared Function LoadCursorFromFile(ByVal str As String) As IntPtr
        End Function
        Public Shared Function Create(ByVal filename As String) As Windows.Forms.Cursor
            Dim hCursor As IntPtr = LoadCursorFromFile(filename)
            If Not IntPtr.Zero.Equals(hCursor) Then
                Return New Windows.Forms.Cursor(hCursor)
            Else
                Throw New ApplicationException("Could not create cursor from file " & filename)
            End If
        End Function
    End Class

    Private Sub InitNexStarComm()

        On Error GoTo v24error

        If SimOffline Then
        Else
            MSComm1.Open()
        End If

        Exit Sub

v24error:
        MsgBox("Port kann nicht geöffnet werden")

        SimOffline = True
        My.Settings.SimOffline = SimOffline
        My.Settings.Save()

        On Error Resume Next


    End Sub


    Private Sub CommunicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommunicationToolStripMenuItem.Click
        FrmCommunication.Show()
    End Sub

    Private Sub SetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupToolStripMenuItem.Click

        Dim StarKatalogFile As String

        LoadStarKatalogDialog.InitialDirectory = DefaultPath
        LoadStarKatalogDialog.Filter = "TXT-Datei (*.txt)|*.txt"

        Dim result As Integer = LoadStarKatalogDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        If LoadStarKatalogDialog.FileName = "" Then
            Exit Sub
        End If

        StarKatalogFile = LoadStarKatalogDialog.FileName

        DefaultPath = Path.GetDirectoryName(StarKatalogFile)
        DefaultStarKatalog = Path.GetFileName(StarKatalogFile)

        My.Settings.BasicsDefaultPath = DefaultPath
        My.Settings.BasicsDefaultStarKatalog = DefaultStarKatalog
        My.Settings.Save()

        LoadAlignmetStarFile()


        Exit Sub

    End Sub


    Private Sub TesteJulianischesDatumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TesteJulianischesDatumToolStripMenuItem.Click
        TestJulianischesDatum.Show()
    End Sub


    Private Sub MSComm1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles MSComm1.DataReceived

        Dim i As Integer
        Dim BytesToRead As Integer
        Dim ByteArray(19) As Byte
        Dim buf As Byte
        Dim NexStarAz As Long
        Dim NexStarAlt As Long


        BytesToRead = MSComm1.BytesToRead()

        B_Comm.BackColor = Color.LawnGreen

        If BytesToRead > 3 Then
            MSComm1.Read(ByteArray, 0, BytesToRead)
            ErrorCount = ErrorCount + 1
            ReadComm = "--> Read Error: " & BytesToRead & " Bytes"
            CommandWait = False
            Exit Sub
        End If

        If NexStarCommand = 1 Then
            If BytesToRead >= 3 Then

                NexStarAz = 0
                MSComm1.Read(ByteArray, 0, 3)
                For i = 0 To 2
                    buf = ByteArray(i)
                    NexStarAz = NexStarAz + buf * 256 ^ (2 - i)
                Next i

                TelIncr.Az = NexStarAz
                ReadComm = "--> Receive: Az: " & TelIncr.Az
                CommandWait = False
            End If

        ElseIf NexStarCommand = 21 Then
            If BytesToRead >= 3 Then

                NexStarAlt = 0
                MSComm1.Read(ByteArray, 0, 3)
                For i = 0 To 2
                    buf = ByteArray(i)
                    NexStarAlt = NexStarAlt + buf * 256 ^ (2 - i)
                Next i

                TelIncr.Alt = NexStarAlt
                ReadComm = "--> Receive: Alt: " & TelIncr.Alt
                CommandWait = False
            End If

        ElseIf NexStarCommand = 13 Then
            If BytesToRead = 1 Then

                NexStarChar1 = ""
                MSComm1.Read(ByteArray, 0, 1)
                buf = ByteArray(0)
                NexStarChar1 = NexStarChar1 & Strings.Chr(buf)

                If buf = 0 Then
                    StatusMoving = 1      'Busy
                    ReadComm = "--> Busy"
                ElseIf buf = 255 Then
                    StatusMoving = 2      'Idle
                    ReadComm = "--> In Position"
                End If

                CommandWait = False
            Else
                MSComm1.Read(ByteArray, 0, BytesToRead)
                ErrorCount = ErrorCount + 1
                ReadComm = "--> Read Error: " & BytesToRead & " Bytes"
                CommandWait = False
                Exit Sub
            End If

        End If
        '        Exit Sub
        'msgError:
        '        MsgBox("Error: " + Err.Description + "in Function OnComm() in MainFrm.")

    End Sub

    Private Sub Tim_DisplayUpdate_Tick(sender As Object, e As EventArgs) Handles Tim_DisplayUpdate.Tick
        Static Toggle As Boolean

        If SimOffline Then
            C_Simulation.BackColor = Color.Yellow
        Else
            C_Simulation.BackColor = Color.White
        End If

        If Not FrmMoveTelescope.MoveTelescopeActive Then

            Static GetAzAltCount As Long
            Const GetAzAltInterval = 1        'calculate new star positition ever ... sec
            Dim N As Long

            N = (GetAzAltInterval * 1000) / Tim_DisplayUpdate.Interval

            GetAzAltCount = GetAzAltCount + 1

            ' this code only every "GetAzAltInterval" sec
            'If GetAzAltCount >= N And StatusMoving = 2 Then
            If GetAzAltCount >= N Then
                GetAzAltCount = 0
                If Toggle Then
                    Toggle = False
                    C_GetAz.PerformClick()
                Else
                    Toggle = True
                    C_GetAlt.PerformClick()
                End If
            End If

        End If


        MatrixSystemIst = MotorIncr_To_MatrixSystem(TelIncr)

        L_GlobalAzOffset.Text = Format(RadToDeg(GlobalOffset.Az), "0.0000") & "°"
        L_MatrixSystemAzSoll.Text = Format(RadToDeg(MatrixSystemSoll.Az), "0.0000") & "°"
        L_MatrixSystemAzDiff.Text = Format(RadToDeg(MatrixDiffCalc.Az), "0.0000") & "°/s"
        L_MatrixSystemAzIst.Text = Format(RadToDeg(MatrixSystemIst.Az), "0.0000") & "°"
        L_AzMotorIncr.Text = Format(TelIncr.Az, "0.0")
        L_MotorSystemAzDiff.Text = Format(MotorDiffCalc.Az, "0.0")


        L_GlobalAltOffset.Text = Format(RadToDeg(GlobalOffset.Alt), "0.0000") & "°"
        L_MatrixSystemAltSoll.Text = Format(RadToDeg(MatrixSystemSoll.Alt), "0.0000") & "°"
        L_MatrixSystemAltDiff.Text = Format(RadToDeg(MatrixDiffCalc.Alt), "0.0000") & "°/s"
        L_MatrixSystemAltIst.Text = Format(RadToDeg(MatrixSystemIst.Alt), "0.0000") & "°"
        L_AltMotorIncr.Text = Format(TelIncr.Alt, "0.0")
        L_MotorSystemAltDiff.Text = Format(MotorDiffCalc.Alt, "0.0")


        L_MatrixSystemAzDiffReal.Text = "Real track rate: " & Format(RadToDeg(MatrixSystemDiffPerSec.Az), "0.0000") & "°/s"
        L_MotorSystemAzDiffReal.Text = "Real (RS232):      " & Format(TrackingSpeed.Az / 10, "0.000") & " Incr/s"
        L_MotorSystemAzDiffSim.Text = "Real (Simulation): " & Format(SimTrackingStep.Az, "0.000") & " Incr/s"


        If SimOffline Then
            Slider1.Value = Limit(SimIncr.Az - Matrix_To_MotorIncrSystem(MatrixSystemSoll).Az + 1000, 0, 2000)
            Slider2.Value = Limit(SimIncr.Alt - Matrix_To_MotorIncrSystem(MatrixSystemSoll).Alt + 1000, 0, 2000)
        Else
            Slider1.Value = Limit(TelIncr.Az - Matrix_To_MotorIncrSystem(MatrixSystemSoll).Az + 1000, 0, 2000)
            Slider2.Value = Limit(TelIncr.Alt - Matrix_To_MotorIncrSystem(MatrixSystemSoll).Alt + 1000, 0, 2000)
        End If

        L_ErrorCount.Text = "Error cout: " & ErrorCount

        DispTelescopePos(MatrixSystemIst)



        If GlbCalibStatus > 0 Then
            C_Tracking.Enabled = True
        Else
            C_Tracking.Enabled = False
        End If



        Select Case StatusMoving
            Case 0
                L_StatusMoving.Text = "--"
                L_StatusMoving.BackColor = Color.White
            Case 1
                L_StatusMoving.Text = "Busy"
                L_StatusMoving.BackColor = Color.Yellow
            Case 2
                L_StatusMoving.Text = "Idle"
                L_StatusMoving.BackColor = Color.LawnGreen
        End Select



    End Sub




    Private Sub Tim_Preview_Tick(sender As Object, e As EventArgs) Handles Tim_Preview.Tick

        Dim idx As Long
        Dim Az As Double
        Dim HourAngle As Double
        Dim HourAngleHMS As MyTime




        idx = AlignmentStarList.SelectedIndex

        ' no star selected yet
        If idx < 0 Then
            Exit Sub
        End If

        ' Search star name in list
        idx = -1
        Do
            idx = idx + 1
        Loop Until (AlignmentStarArray(idx).ProperName = AlignmentStarList.Text) Or (idx >= UBound(AlignmentStarArray))
        L_CurrentStar.Text = AlignmentStarArray(idx).ProperName
        F_PreviewInfo.Text = AlignmentStarArray(idx).ProperName

        PreviewRaDec.Ra = HourToRad(AlignmentStarArray(idx).Ra)
        PreviewRaDec.Dec = DegToRad(AlignmentStarArray(idx).Dec)
        DisplayCoordinate(L_Preview_RA, PreviewRaDec.Ra, NxMode.HMS)
        DisplayCoordinate(L_Preview_DEC, PreviewRaDec.Dec, NxMode.DegDec)

        PreviewAzAlt = RA_DEC_to_AZ_ALT_new(PreviewRaDec, GlbOberverPos, GlbSiderialTime)



        Dim DisplPreviewAz As Double
        If Ch_South.Checked Then
            DisplPreviewAz = CutRad(PreviewAzAlt.Az + Pi)
        Else
            DisplPreviewAz = CutRad(PreviewAzAlt.Az)
        End If

        DisplayCoordinate(L_Preview_Az, DisplPreviewAz, NxMode.DegDec)







        Dim tmp As AzAlt
        tmp.Az = PreviewAzAlt.Az
        tmp.Alt = PreviewAzAlt.Alt
        L_Preview_CardinalOrientation.Text = GetCardinalDrection(AzAlt_to_MatrixSystem(tmp).Az)
        DisplayCoordinate(L_Preview_Alt, PreviewAzAlt.Alt, NxMode.DegDec)
        DisplayCoordinate(L_Preview_HourAngle, HourAngle, NxMode.HMS)

        'Just for testing: get matrix vectors
        Dim X As Double
        Dim Y As Double
        Dim z As Double
        Dim HorizAngle As Double
        Dim ElevAngle As Double

        HorizAngle = PreviewRaDec.Ra
        ElevAngle = PreviewRaDec.Dec
        X = Math.Cos(ElevAngle) * Math.Cos(HorizAngle)
        Y = Math.Cos(ElevAngle) * Math.Sin(HorizAngle)
        z = Math.Sin(ElevAngle)
        L_Preview_EquXYZ.Text = Format(X, "0.0000") & " " & Format(Y, "0.0000") & " " & Format(z, "0.0000")

        HorizAngle = PreviewAzAlt.Az
        ElevAngle = PreviewAzAlt.Alt
        X = Math.Cos(ElevAngle) * Math.Cos(HorizAngle)
        Y = Math.Cos(ElevAngle) * Math.Sin(HorizAngle)
        z = Math.Sin(ElevAngle)
        L_Preview_HorXYZ.Text = Format(X, "0.0000") & " " & Format(Y, "0.0000") & " " & Format(z, "0.0000")


        If PreviewAzAlt.Alt < 0 Then
            L_CurrentStar.BackColor = Color.Red
        ElseIf (PreviewAzAlt.Alt > 0) And (PreviewAzAlt.Alt < 0.3) Then
            L_CurrentStar.BackColor = Color.Yellow
        Else
            L_CurrentStar.BackColor = Color.LawnGreen
        End If

    End Sub

    Private Sub Tim_Simulation_Tick(sender As Object, e As EventArgs) Handles Tim_Simulation.Tick
        Dim SimScaling As Double
        Dim SimGotoStep As Double

        SimScaling = 100
        SimGotoStep = 10000

        If SimBntUp Then
            SimIncr.Alt = SimIncr.Alt + (ManualSlewingSpeedY / SimScaling)
        End If

        If SimBntDn Then
            SimIncr.Alt = SimIncr.Alt - (ManualSlewingSpeedY / SimScaling)
        End If

        If SimBntLe Then
            SimIncr.Az = SimIncr.Az - (ManualSlewingSpeedX / SimScaling)
        End If

        If SimBntRi Then
            SimIncr.Az = SimIncr.Az + (ManualSlewingSpeedX / SimScaling)
        End If


        ' movement active
        If SimGotoAzAltActive Then
            If CheckDeltaIncr(SimGoto.Az, SimIncr.Az, SimGotoStep * 2) Then
                SimIncr.Az = SimGoto.Az
            Else
                SimIncr.Az = SimIncr.Az + GetShortestWayAz(SimGoto.Az, SimIncr.Az) * SimGotoStep
            End If

            If CheckDeltaIncr(SimGoto.Alt, SimIncr.Alt, SimGotoStep * 2) Then
                SimIncr.Alt = SimGoto.Alt
            Else
                SimIncr.Alt = SimIncr.Alt + GetShortestWayAlt(SimGoto.Alt, SimIncr.Alt) * SimGotoStep
            End If

            'SWE   If CheckDeltaIncr(SimGoto.Alt, SimIncr.Alt, SimGotoStep * 2) Then
            'SWE       SimIncr.Alt = SimGoto.Alt
            'SWE   ElseIf SimGoto.Alt > SimIncr.Alt Then
            'SWE       SimIncr.Alt = SimIncr.Alt + SimGotoStep
            'SWE   Else
            'SWE       SimIncr.Alt = SimIncr.Alt - SimGotoStep
            'SWE   End If

            ' movement finished
            If (SimIncr.Az = SimGoto.Az) And (SimIncr.Alt = SimGoto.Alt) Then
                SimGotoAzAltActive = False
            End If

        End If


        ' tracking active
        If TrackingisON Then
            SimIncr = AddAzAlt(SimIncr, SimTrackingStep)
            '''        SimTrackingActive = False

        End If


        SimIncr.Az = CutIncr(SimIncr.Az)
        SimIncr.Alt = CutIncr(SimIncr.Alt)

        Dim DispSimInc As AzAlt
        ' convert SimIncr to radian
        DispSimInc.Az = (SimIncr.Az / EncoderResolution) * 2 * Pi
        DispSimInc.Alt = (SimIncr.Alt / EncoderResolution) * 2 * Pi

        '    DispTelescopePos DispSimInc
    End Sub

    Private Sub Tim_Startup_Tick(sender As Object, e As EventArgs) Handles Tim_Startup.Tick
        Static StartupStep As Long

        Select Case StartupStep
            Case 0
                ''check communication
                Dim NexStarCmd As CommandItem



                NexStarCmd.No = 13
                NexStarCmd.Cmd = Strings.Chr(&HD)
                NexStarCmd.Comment = " Request Status (0x0D)"

                PushCommandBuffer(NexStarCmd)

                StatusMoving = 0
                StartupStep = 10



            Case 10

                If StatusMoving = 1 Or StatusMoving = 2 Then
                    StartupStep = 20    'Communication OK
                Else
                    StartupStep = 0     'Communication not OK. Retry
                End If


            Case 20
                C_SetEncoder_Az.PerformClick()
                C_SetEncoder_Az.BackColor = Color.LawnGreen
                StartupStep = 30

            Case 30
                C_SetEncoder_Alt.PerformClick()
                C_SetEncoder_Alt.BackColor = Color.LawnGreen
                StartupStep = 40

            Case 40
                C_SetBacklAz.PerformClick()
                C_SetBacklAz.BackColor = Color.LawnGreen
                StartupStep = 50

            Case 50
                C_SetBacklAlt.PerformClick()
                C_SetBacklAlt.BackColor = Color.LawnGreen
                StartupStep = 60

            Case 60



        End Select
    End Sub

    Private Sub Tim_TestStatus_Tick(sender As Object, e As EventArgs) Handles Tim_TestStatus.Tick
        If ReadStatus Then
            'Command = 13
            'If SimOffline Then
            'Else
            '    Dim CommString As String
            '    CommString = Strings.Chr(&HD)
            '    NexStarCommunication(CommString, " Read Status (0x0D)", ProtokollMode.Send)
            'End If

            Dim NexStarCmd As CommandItem



            NexStarCmd.No = 13
            NexStarCmd.Cmd = Strings.Chr(&HD)
            NexStarCmd.Comment = " Read Status (0x0D)"
            PushCommandBuffer(NexStarCmd)
        End If


        If StatusMoving = 2 Then
            ReadStatus = False
        End If


    End Sub

    Private Sub Tim_Tracking_Tick(sender As Object, e As EventArgs) Handles Tim_Tracking.Tick
        Dim tDate As MyDate
        Dim tTs As MyTime
        Dim tTsRad As Double
        Dim LongitudeDeg As Double
        Dim LongitudeRad As Double
        Dim LatitudeDeg As Double
        Dim LatitudeRad As Double



        If O_TimeSelectLocal.Checked Then
            'VB6 ObserverDateTimeUT = UtcTime(Now)              ' Get current Time UT
            ObserverDateTimeUT = DateTime.UtcNow            ' Get current Time UT
            L_LocalTime.Text = " Local time:   " & Now
        Else
            ' Take simulation time
            ObserverDateTimeUT = StingsToDate(T_Tag.Text, T_Monat.Text, T_Jahr.Text, T_Stunden.Text, T_Minuten.Text, T_Sekunden.Text)
            L_LocalTime.Text = " Local time:   " & "--"
        End If

        L_UTime.Text = " UT:              " & ObserverDateTimeUT
        ObserverTimeUT.H = Hour(ObserverDateTimeUT)
        ObserverTimeUT.M = Minute(ObserverDateTimeUT)
        ObserverTimeUT.s = Second(ObserverDateTimeUT)
        tDate.YY = DateAndTime.Year(ObserverDateTimeUT)
        tDate.MM = DateAndTime.Month(ObserverDateTimeUT)
        tDate.DD = DateAndTime.Day(ObserverDateTimeUT)

        LatitudeDeg = GeoToDez(ObserverLatt)
        LatitudeRad = DegToRad(LatitudeDeg)
        LongitudeDeg = GeoToDez(ObserverLong)
        LongitudeRad = DegToRad(LongitudeDeg)

        GlbOberverPos.Latitude = LatitudeRad
        GlbOberverPos.Longitude = LongitudeRad

        'double check siderial time: https://tycho.usno.navy.mil/sidereal.html
        tTsRad = TimeToRad(GMST(tDate, ObserverTimeUT)) - LongitudeRad
        GlbSiderialTime = TimeToRad(GMST(tDate, ObserverTimeUT))
        tTs = RadToTime(tTsRad)
        L_SiderialTime.Text = "Siderial time: " & tTs.H & ":" & Format(tTs.M, "00") & ":" & Format(tTs.s, "00")




        Dim idx As Long
        Dim Az As Double
        Dim HourAngle As Double
        Dim HourAngleHMS As MyTime


        idx = AlignmentStarList.SelectedIndex

        ' no star selected yet
        If idx < 0 Then
            Exit Sub
        End If

        ' Search star name in list
        idx = -1

        Do
            idx = idx + 1
        Loop Until (AlignmentStarArray(idx).ProperName = AlignmentStarList.Text) Or (idx >= UBound(AlignmentStarArray))
        '    L_CurrentStar = AlignmentStarArray(idx).ProperName
        '''''    F_StarInfo.Caption = AlignmentStarArray(idx).ProperName

        '    ObserverRA = HourToRad(AlignmentStarArray(idx).Ra)
        '    ObserverDEC = DegToRad(AlignmentStarArray(idx).Dec)


        '''    ObserverRaDec.Ra = HourToRad(AlignmentStarArray(idx).Ra)
        '''    ObserverRaDec.Dec = DegToRad(AlignmentStarArray(idx).Dec)



        DisplayCoordinate(L_I_RA, ObserverRaDec.Ra, NxMode.HMS)
        DisplayCoordinate(L_I_DEC, ObserverRaDec.Dec, NxMode.DegDec)

        '    RA_DEC_to_AZ_ALT_radian ObserverRA, ObserverDEC, ObserverLong, ObserverLatt, ObserverDateTimeUT, ObserverAzAlt.Az, ObserverAzAlt.Alt, HourAngle
        ObserverAzAlt = RA_DEC_to_AZ_ALT_new(ObserverRaDec, GlbOberverPos, GlbSiderialTime)
        ObserverAzAlt.Az = ObserverAzAlt.Az
        ObserverAzAlt.Alt = ObserverAzAlt.Alt

        Dim DisplObserverAz As Double
        If Ch_South.Checked Then
            DisplObserverAz = CutRad(ObserverAzAlt.Az + Pi)
        Else
            DisplObserverAz = CutRad(ObserverAzAlt.Az)
        End If

        DisplayCoordinate(L_I_Az, DisplObserverAz, NxMode.DegDec)

        Dim tmp As AzAlt
        tmp = ObserverAzAlt
        L_CardinalOrientation.Text = GetCardinalDrection(AzAlt_to_MatrixSystem(tmp).Az)
        DisplayCoordinate(L_I_Alt, ObserverAzAlt.Alt, NxMode.DegDec)
        DisplayCoordinate(L_I_HourAngle, HourAngle, NxMode.HMS)

        'Just for testing: get matrix vectors
        Dim X As Double
        Dim Y As Double
        Dim z As Double
        Dim HorizAngle As Double
        Dim ElevAngle As Double

        HorizAngle = ObserverRaDec.Ra
        ElevAngle = ObserverRaDec.Dec
        X = Math.Cos(ElevAngle) * Math.Cos(HorizAngle)
        Y = Math.Cos(ElevAngle) * Math.Sin(HorizAngle)
        z = Math.Sin(ElevAngle)
        L_I_EquXYZ.Text = Format(X, "0.0000") & " " & Format(Y, "0.0000") & " " & Format(z, "0.0000")

        HorizAngle = ObserverAzAlt.Az
        ElevAngle = ObserverAzAlt.Alt
        X = Math.Cos(ElevAngle) * Math.Cos(HorizAngle)
        Y = Math.Cos(ElevAngle) * Math.Sin(HorizAngle)
        z = Math.Sin(ElevAngle)
        L_I_HorXYZ.Text = Format(X, "0.0000") & " " & Format(Y, "0.0000") & " " & Format(z, "0.0000")


        '''    If ObserverAzAlt.Alt < 0 Then
        '''        L_CurrentStar.BackColor = RGB(255, 0, 0)
        '''    ElseIf (ObserverAzAlt.Alt > 0) And (ObserverAzAlt.Alt < 0.3) Then
        '''        L_CurrentStar.BackColor = RGB(255, 255, 0)
        '''    Else
        '''        L_CurrentStar.BackColor = RGB(0, 255, 0)
        '''    End If





        Static TrackCount As Long
        Const TrackInterval = 30        'calculate new star positition ever ... sec
        Dim N As Long

        N = (TrackInterval * 1000) / Tim_Tracking.Interval

        ' start with tracking immediately
        If Not TrackingisON Then
            TrackCount = N
        End If

        If TrackingisON Then
            TrackCount = TrackCount + 1

            L_ElapsedTime.Text = TrackCount / 2 & " sec"

            ' this code only every "TrackInterval" sec
            ' do write if another command is beeing executed
            If TrackCount >= N Then
                '==== Life counter ====
                Static LifeCounter As Long
                Dim i As Long
                Dim s As String
                If LifeCounter >= 10 Then
                    LifeCounter = 0
                    s = ""
                Else
                    LifeCounter = LifeCounter + 1
                    For i = 0 To LifeCounter
                        s = s & "."
                    Next i
                End If

                TrackCount = 0

                C_Tracking.BackColor = Color.LawnGreen

                If GlbCalibStatus = 0 Or GlbCalibStatus = 1 Then
                    Dim tmp1 As AzAlt
                    '                            tmp1.Az = CutRad(ObserverAzAlt.Az)
                    '                            tmp1.Alt = ObserverAzAlt.Alt
                    tmp1 = ObserverAzAlt
                    MatrixSystemSoll = AzAlt_to_MatrixSystem(tmp1)

                ElseIf GlbCalibStatus = 2 Then
                    Dim AimTimeRad As Double
                    Dim CalculatedObserverAzAlt As AzAlt
                    Dim TimeDiff As MyTime


                    TimeDiff.s = TrackInterval

                    AimTimeRad = TimeToRad(ObserverTimeUT) + TimeToRad(TimeDiff)
                    JetztTime = TimeToRad(ObserverTimeUT)

                    CalculateTelescopeCoordinates(Cal_InitTime,
                                                          ObserverRaDec, AimTimeRad, TransformationMatrix,
                                                          CalculatedObserverAzAlt)
                    'Set Az
                    MatrixSystemSoll.Az = CutRad(CalculatedObserverAzAlt.Az)
                    'Set Alt
                    MatrixSystemSoll.Alt = CalculatedObserverAzAlt.Alt
                End If



                Dim MatrixSystemDiff As AzAlt
                'real values

                'das funktioniert nicht wenn mal gegen den Sternenenlauf positioniert werden soll...
                '... oder beim Durchgang durch 0°
                MatrixSystemDiff = SubAzAlt(MatrixSystemSoll, MatrixSystemIst)
                'Ersatz...
                MatrixDiffCalc.Az = GetShortestRad(MatrixSystemSoll.Az, MatrixSystemIst.Az)
                MatrixDiffCalc.Alt = GetShortestRad(MatrixSystemSoll.Alt, MatrixSystemIst.Alt)



                MatrixSystemDiffPerSec.Az = MatrixSystemDiff.Az / TrackInterval
                MatrixSystemDiffPerSec.Alt = MatrixSystemDiff.Alt / TrackInterval



                'Hier geht das Vorzeichen verloren
                '                DiffMotorIncr = Matrix_To_MotorIncrSystem(MatrixSystemDiff)
                'Ersatz
                DiffMotorIncr.Az = -MatrixSystemDiff.Az * EncoderResolution / (2 * Pi)
                DiffMotorIncr.Alt = MatrixSystemDiff.Alt * EncoderResolution / (2 * Pi)

                'check motor movement with calculated values

                'das funktioniert nicht wenn mal gegen den Sternenenlauf positioniert werden soll...
                '... oder beim Durchgang durch 0°
                'MatrixDiffCalc = SubAzAlt(MatrixSystemSoll, MatrixLastCalc)


                MatrixDiffCalc.Az = MatrixDiffCalc.Az / TrackInterval
                MatrixDiffCalc.Alt = MatrixDiffCalc.Alt / TrackInterval
                MatrixLastCalc = MatrixSystemSoll

                MotorDiffCalc = SubAzAlt(Matrix_To_MotorIncrSystem(MatrixSystemSoll), MotorLastCalc)
                MotorDiffCalc.Az = MotorDiffCalc.Az / TrackInterval
                MotorDiffCalc.Alt = MotorDiffCalc.Alt / TrackInterval
                MotorLastCalc = Matrix_To_MotorIncrSystem(MatrixSystemSoll)

                Label17.Text = Format(RadToDeg(MatrixSystemDiff.Az), "0.0000") & "° = " & Format(DiffMotorIncr.Az, "0.0") & " Incr pro " & TrackInterval & " sec"
                Label24.Text = Format(RadToDeg(MatrixSystemDiff.Alt), "0.0000") & "° = " & Format(DiffMotorIncr.Alt, "0.0") & " Incr pro " & TrackInterval & " sec"


                TrackingSpeed.Az = (DiffMotorIncr.Az * 10) / TrackInterval
                TrackingSpeed.Alt = (DiffMotorIncr.Alt * 10) / TrackInterval


                Dim LogString As String
                Dim AzString As String
                Dim AltString As String

                'If DiffMotorIncr.Az < 0 Then
                If MatrixSystemDiff.Az > 0 Then
                    'CCW
                    AzString = Strings.Chr(&H7) & SetNexStarPosition(-CLng(TrackingSpeed.Az))
                Else
                    'CW (normal direction)
                    AzString = Strings.Chr(&H6) & SetNexStarPosition(CLng(TrackingSpeed.Az))
                End If

                If DiffMotorIncr.Alt < 0 Then
                    'descending
                    AltString = Strings.Chr(&H1B) & SetNexStarPosition(-CLng(TrackingSpeed.Alt))
                Else
                    'ascending
                    AltString = Strings.Chr(&H1A) & SetNexStarPosition(CLng(TrackingSpeed.Alt))
                End If


                If Not SimOffline Then
                    LogString = "Tracking: " & Format(TrackingSpeed.Az, "0.0") & " " & Format(TrackingSpeed.Alt, "0.0")

                    Dim CommString As String
                    CommString = AzString & AltString
                    'NexStarCommunication(CommString, LogString, ProtokollMode.Send)


                    Dim NexStarCmd As CommandItem



                    NexStarCmd.No = 6
                    NexStarCmd.Cmd = CommString
                    NexStarCmd.Comment = LogString

                    PushCommandBuffer(NexStarCmd)




                End If
            End If



            ' every TimTracking.Interval
            If SimOffline Then
                '''                SimTrackingActive = True

                SimTrackingStep.Az = (DiffMotorIncr.Az / TrackInterval) * (Tim_Tracking.Interval / 1000.0#)
                SimTrackingStep.Alt = (DiffMotorIncr.Alt / TrackInterval) * (Tim_Tracking.Interval / 1000.0#)
            End If


        Else
            'Tracking is OFF
            C_Tracking.BackColor = Color.Gray
        End If


    End Sub


    Private Sub VS_ManualSlewingSpeed_Scroll(sender As Object, e As ScrollEventArgs) Handles VS_ManualSlewingSpeed.Scroll
        Dim tmp As Double

        tmp = VS_ManualSlewingSpeed.Maximum - VS_ManualSlewingSpeed.Value
        ManualSlewingSpeedX = 100 * tmp
        ManualSlewingSpeedY = 100 * tmp
        L_SlewingSpeedX.Text = ManualSlewingSpeedX
        L_SlewingSpeedY.Text = ManualSlewingSpeedY

        'TrackingSpeed[Incr/sec] = ManualSlewingSpeed[Incr/sec] * 0,1 [Incr/sec]

    End Sub


    'Coordinate [radian]
    Private Sub DisplayCoordinate(l As Label, Coord As Double, Mode As NxMode)
        Dim TmpTime As MyTime

        If Mode = NxMode.HMS Then
            TmpTime = RadToTime(Coord)
            l.Text = TmpTime.H & ":" & TmpTime.M & ":" & Format(TmpTime.s, "00.00")
        ElseIf Mode = NxMode.DegDec Then
            l.Text = Format(RadToDeg(Coord), "0.0000") & "°"
        Else
            l.Text = Coord
        End If
    End Sub

    Private Sub LoadAlignmetStarFile()
        Dim AlignmetStarFile As Integer
        Dim AlignmetStarFileName As String
        Dim i As Integer
        Dim Zeile As String
        Dim StarEntities() As String
        Dim idx As Long

        ReDim AlignmentStarArray(0 To 0)
        AlignmentStarList.Items.Clear()

        On Error GoTo openErr

        AlignmetStarFile = FreeFile()
        AlignmetStarFileName = Path.Combine(DefaultPath, DefaultStarKatalog)
        FileOpen(AlignmetStarFile, AlignmetStarFileName, OpenMode.Input)

        While Not EOF(AlignmetStarFile)
            Zeile = LineInput(AlignmetStarFile)
            SepariereString(Zeile, StarEntities, vbTab)
            idx = UBound(AlignmentStarArray)
            AlignmentStarArray(idx).Index = Zahl(StarEntities(0))
            AlignmentStarArray(idx).ProperName = StarEntities(1)
            AlignmentStarArray(idx).Constellation = StarEntities(2)
            AlignmentStarArray(idx).Bayer = StarEntities(3)
            AlignmentStarArray(idx).Flamsteed = StarEntities(4)
            AlignmentStarArray(idx).Ra = Zahl(StarEntities(5))
            AlignmentStarArray(idx).Dec = Zahl(StarEntities(6))
            AlignmentStarArray(idx).Mag = Zahl(StarEntities(7))

            AlignmentStarList.Items.Add(AlignmentStarArray(idx).ProperName)

            ReDim Preserve AlignmentStarArray(0 To UBound(AlignmentStarArray) + 1)
        End While
        FileClose(AlignmetStarFile)


        Exit Sub

openErr:
        MsgBox(Err.Description & vbCrLf & "Can't read Config File:" & AlignmetStarFileName, , "NexStar Error 002")
        FileClose(AlignmetStarFile)
    End Sub


    Private Sub T_Backlash_Leave(sender As Object, e As EventArgs) Handles T_Backlash.Leave
        My.Settings.Backlash = T_Backlash.Text
        My.Settings.Save()
    End Sub

    Private Sub Tim_Comm_Tick(sender As Object, e As EventArgs) Handles Tim_Comm.Tick
        Dim NexStarCmd As CommandItem
        Dim NexStarAnswer As CommandItem
        Dim dummy As Integer
        Dim N As Integer

        Static Cnt As Integer

        N = 3000 / Tim_Comm.Interval

        Cnt = Cnt + 1

        L_NumerOfCmd.Text = CommandBuffer.Count

        If SimOffline Then
            If CommandBuffer.Count > 0 Then
                NexStarCmd = CommandBuffer.Item(0)
                Writelog(NexStarCmd, ProtokollMode.Send)
                CommandBuffer.RemoveRange(0, 1)
            End If

            Select Case NexStarCmd.No
                Case 1
                    TelIncr = SimIncr
                    NexStarAnswer.Comment = "Az = " & TelIncr.Az
                    Writelog(NexStarAnswer, ProtokollMode.Receive)
                Case 21
                    TelIncr = SimIncr
                    NexStarAnswer.Comment = "Alt = " & TelIncr.Alt
                    Writelog(NexStarAnswer, ProtokollMode.Receive)
                Case 13
                    If Not SimGotoAzAltActive Then
                        StatusMoving = 2      'Idle
                        NexStarAnswer.Comment = " In Position"
                        Writelog(NexStarAnswer, ProtokollMode.Receive)
                    Else
                        StatusMoving = 1      'Busy
                        NexStarAnswer.Comment = " Busy"
                        Writelog(NexStarAnswer, ProtokollMode.Receive)
                    End If
                Case Else

            End Select

        Else
            If ReadComm <> "" Then
                NexStarCmd.Comment = ReadComm
                Writelog(NexStarCmd, ProtokollMode.Receive)
                ReadComm = ""
            End If

            If CommandWait Then
                If Cnt > 10 Then
                    B_Comm.BackColor = Color.LightGray
                    CommandWait = False
                    CommandBuffer.Clear()
                End If
            Else
                'If CommandBuffer.Count > 0 And Cnt > N Then
                If CommandBuffer.Count > 0 Then
                    Cnt = 0
                    NexStarCmd = CommandBuffer.Item(0)
                    Writelog(NexStarCmd, ProtokollMode.Send)
                    CommandBuffer.RemoveRange(0, 1)
                    NexStarCommand = NexStarCmd.No

                    Dim buf() As Byte
                    buf = System.Text.Encoding.Default.GetBytes(NexStarCmd.Cmd)
                    If MSComm1.IsOpen Then
                        MSComm1.Write(buf, 0, buf.Length)

                        Select Case NexStarCmd.No
                            Case 1
                                CommandWait = True
                            Case 21
                                CommandWait = True
                            Case 13
                                CommandWait = True
                            Case 6
                                dummy = 1
                            Case Else

                        End Select

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub B_Comm_Click(sender As Object, e As EventArgs) Handles B_Comm.Click

        CommandWait = False
        CommandBuffer.Clear()

        Dim BytesToRead As Integer
        Dim ByteArray(19) As Byte

        If MSComm1.IsOpen Then
            BytesToRead = MSComm1.BytesToRead()
            MSComm1.Read(ByteArray, 0, BytesToRead)
        End If

    End Sub

    Private Sub CB_Find_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Find.SelectedIndexChanged

    End Sub

    Private Sub CovertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CovertToolStripMenuItem.Click
        FrmConvert.Show()
    End Sub

    Private Sub CursorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CursorToolStripMenuItem.Click

        'Dim StarKatalogFile As String

        OpenCursorDialog.InitialDirectory = Path.Combine(DefaultPath, "Cursors")
        OpenCursorDialog.FileName = CursorFileName
        OpenCursorDialog.Filter = "Cursors (*.cur;*.ani)|*.cur;*.ani"


        Dim result As Integer = OpenCursorDialog.ShowDialog()
        If result = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        If OpenCursorDialog.FileName = "" Then
            Exit Sub
        End If

        CursorFileName = Path.GetFileName(OpenCursorDialog.FileName)

        My.Settings.Cursor = CursorFileName
        My.Settings.Save()

        Dim CursorFullPath As String
        CursorFullPath = Path.Combine(DefaultPath, "Cursors", CursorFileName)
        If System.IO.File.Exists(CursorFullPath) Then
            'Me.Cursor = Cursors.Arrow
            'http://cool-web.de/mouse-pointer/cursors.htm
            'Me.Cursor = AdvancedCursors.Create(Path.Combine(DefaultPath, "bigarrow.cur"))
            Me.Cursor = AdvancedCursors.Create(CursorFullPath)
        Else
            MsgBox("Datei nicht gefunden: " & CursorFullPath)
        End If


        Exit Sub
    End Sub


    Private Sub B_SetCurrentPos_Click(sender As Object, e As EventArgs) Handles B_SetCurrentPos.Click
        MatrixSystemSoll = AzAlt_to_MatrixSystem(PreviewAzAlt)
        GlobalOffset = SubAzAlt(MatrixSystemIst, MatrixSystemSoll)
    End Sub
End Class
