Option Explicit On
Public Class FrmConvert
    Dim Radian As Double

    Dim Sign As Double

    Dim Deg As Double
    Dim Min As Double
    Dim Sek As Double

    Dim TimeDec As Double
    Dim H As Double
    Dim M As Double
    Dim S As Double

    Dim TimeHMS As MyTime

    Private Sub B_ConvertDegMS_Click_1(sender As Object, e As EventArgs) Handles B_ConvertDegMS.Click



        Deg = Zahl(T_DMS_Deg.Text)
        Sign = VorZeichen(Deg)
        Deg = Math.Abs(Deg)
        Min = Zahl(T_DMS_Min.Text)
        Sek = Zahl(T_DMS_Sek.Text)

        Deg = Sign * (Deg + Min / 60 + Sek / 3600)

        Radian = DegToRad(Deg)
        T_Radian.Text = Format(Radian, "0.00000000")
        B_ConvertRadian.PerformClick()

    End Sub



    Private Sub B_ConvertDegM_Click_1(sender As Object, e As EventArgs) Handles B_ConvertDegM.Click


        Deg = Zahl(T_DM_Deg.Text)
        Sign = VorZeichen(Deg)
        Deg = Math.Abs(Deg)
        Min = Zahl(T_DM_Min.Text)

        Deg = Sign * (Deg + Min / 60)

        Radian = DegToRad(Deg)
        T_Radian.Text = Format(Radian, "0.00000000")
        B_ConvertRadian.PerformClick()
    End Sub


    Private Sub B_ConvertDeg_Click_1(sender As Object, e As EventArgs) Handles B_ConvertDeg.Click



        'T_Radian.Text = DegToRad(T_Deg.Text)
        Radian = DegToRad(Zahl(T_Deg.Text))
        T_Radian.Text = Format(Radian, "0.00000000")
        B_ConvertRadian.PerformClick()
    End Sub


    Private Sub B_ConvertHMS_Click_1(sender As Object, e As EventArgs) Handles B_ConvertHMS.Click


        TimeHMS.H = Zahl(T_HMS_Hours.Text)
        TimeHMS.M = Zahl(T_HMS_Min.Text)
        TimeHMS.S = Zahl(T_HMS_Sek.Text)

        Radian = TimeToRad(TimeHMS)
        T_Radian.Text = Format(Radian, "0.00000000")
        B_ConvertRadian.PerformClick()
    End Sub

    Private Sub B_ConvertHM_Click_1(sender As Object, e As EventArgs) Handles B_ConvertHM.Click


        TimeHMS.H = Zahl(T_HM_Hours.Text)
        TimeHMS.M = Zahl(T_HM_Min.Text)

        Radian = TimeToRad(TimeHMS)
        T_Radian.Text = Format(Radian, "0.00000000")
        B_ConvertRadian.PerformClick()
    End Sub

    Private Sub B_ConvertHours_Click_1(sender As Object, e As EventArgs) Handles B_ConvertHours.Click


        Radian = (Zahl(T_Hours.Text) / 12) * Math.PI

        T_Radian.Text = Format(Radian, "0.00000000")
        B_ConvertRadian.PerformClick()
    End Sub

    Private Sub B_ConvertRadian_Click_1(sender As Object, e As EventArgs) Handles B_ConvertRadian.Click


        Dim Grad As Double
        Dim Minute As Double
        Dim Sekunde As Double
        Dim Deg As Double
        Dim Min As Double
        Dim Sek As Double


        Radian = Zahl(T_Radian.Text)

        Deg = RadToDeg(Radian)
        Sign = VorZeichen(Deg)
        Deg = Math.Abs(Deg)

        Grad = Math.Truncate(Deg)
        Min = (Deg - Grad) * 60
        Minute = Math.Truncate(Min)
        Sek = (Min - Minute) * 60
        Sekunde = Math.Truncate(Sek)

        T_DMS_Deg.Text = Sign * Grad
        T_DMS_Min.Text = Minute
        T_DMS_Sek.Text = Format(Sekunde, "0.00")

        T_DM_Deg.Text = Sign * Grad
        T_DM_Min.Text = Format(Min, "0.0000")

        T_Deg.Text = Format(RadToDeg(T_Radian.Text), "0.0000")


        TimeHMS = RadToTime(Radian)

        T_HMS_Hours.Text = TimeHMS.H
        T_HMS_Min.Text = TimeHMS.M
        T_HMS_Sek.Text = Format(TimeHMS.S, "0.00")

        T_HM_Hours.Text = TimeHMS.H
        T_HM_Min.Text = Format(TimeHMS.M + TimeHMS.S / 60, "0.00")


        T_Hours.Text = Format(RadToTime(T_Radian.Text).TimeDec, "0.0000")


    End Sub

    Private Function VorZeichen(X As Double) As Double
        If X < 0 Then
            VorZeichen = -1
        Else
            VorZeichen = 1
        End If

    End Function

    Private Sub FrmConvert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        B_ConvertRadian.PerformClick()
    End Sub








End Class