Option Explicit On
Public Class TestJulianischesDatum
    Private Sub B_StartCalculation_Click(sender As Object, e As EventArgs) Handles B_StartCalculation.Click

        Dim JD As Double
        '    Dim Std As Double
        '    Dim Min As Double
        '    Dim Sek As Double

        Dim TimeToDisplay As MyTime

        Dim D As Double
        Dim M As Double
        Dim Y As Double

        Dim Time0hGMT As MyTime
        Dim LocalTimeUT As MyTime
        Dim LocalTimeSiderial As MyTime
        Dim LocalDate As MyDate
        Dim Stunde As Double
        Dim Minuten As Double
        Dim Sekunde As Double
        Dim Longitude As Double

        Dim t As Double
        Dim GMST_Zeit_s As Double
        Dim GMST_Zeit_h As Double
        Dim GMST_24 As Double
        Dim LokalTime As Double
        Dim GMSTindividualTime As Double
        Dim GMSTindividualOrt As Double

        My.Settings.UserDefinedDay = T_Tag.Text
        My.Settings.UserDefinedMonth = T_Monat.Text
        My.Settings.UserDefinedYear = T_Jahr.Text
        My.Settings.UserDefinedHour = T_Stunden.Text
        My.Settings.UserDefinedMinute = T_Minuten.Text
        My.Settings.UserDefinedSecond = T_Sekunden.Text
        My.Settings.UserDefinedTimeZone = T_Zeitzone.Text
        My.Settings.UserDefinedLongitude = T_Longitude.Text
        My.Settings.Save()

        LocalDate.YY = Zahl(T_Jahr.Text)
        LocalDate.MM = Zahl(T_Monat.Text)
        LocalDate.DD = Zahl(T_Tag.Text)
        LocalTimeUT.H = Zahl(T_Stunden.Text)
        LocalTimeUT.M = Zahl(T_Minuten.Text)
        LocalTimeUT.s = Zahl(T_Sekunden.Text)
        Longitude = Zahl(T_Longitude.Text)


        '1.  Julianische Datum JD um 0h berechnen. Muß immer auf 0,5 enden
        Time0hGMT.H = 0
        Time0hGMT.M = 0
        Time0hGMT.s = 0
        JD = GetJulianDate(LocalDate, Time0hGMT)
        L_JD.Text = JD


        ' 2. Sternzeit in Greenwich berechnen
        ' Berechne die mittlere Sternzeit von Greenwich um 0 h UT zum gewünschten Datum.
        ' Addiere zum Ergebnis von 1) das Produkt t * 1.00273790935
        ' Der Faktor 1.002 737 909 35 berücksichtigt, dass die Sternzeit um so viel schneller abläuft als die Sonnenzeit.
        ' Das Resultat ist zum Schluss wieder auf [0; 24) zu normieren.
        ' Soll die mittlere Sternzeit nicht für Greenwich, sondern für einen Ort der geografischen Länge L° ,
        ' addiere man zum Resultat L/15      (positiv gezählt nach Osten, negativ nach Westen)

        t = (JD - 2451545.0#) / 36525


        GMST_Zeit_s = 24110.54841 + 8640184.812866 * t + 0.093104 * t * t - 0.0000062 * t * t * t
        GMST_Zeit_h = GMST_Zeit_s / 3600
        L_GMST_Zeit.Text = GMST_Zeit_h
        GMST_24 = CutTime(GMST_Zeit_h)
        L_Zeit.Text = GMST_24

        ' Lokale Zeit auf siderische Zeit umgerechnet
        LocalTimeSiderial = TimeHMStoDez(LocalTimeUT)

        GMSTindividualTime = LocalTimeSiderial.TimeDec * 1.00273790935 + GMST_24

        GMSTindividualTime = CutTime(GMSTindividualTime)

        L_Zeit2.Text = GMSTindividualTime

        ' Geographische Länge berücksichtigen
        GMSTindividualOrt = GMSTindividualTime + Longitude / 15

        GMSTindividualOrt = CutTime(GMSTindividualOrt)

        L_Zeit_Ort.Text = GMSTindividualOrt


        ' Sternzeit im H:M:S Format ausgeben
        TimeToDisplay = TimeDezToHMS(GMSTindividualOrt)
        L_Zeit_Ort_2.Text = TimeToDisplay.H & ":" & TimeToDisplay.M & ":" & Format(TimeToDisplay.s, "00.00")


        '
        '  GMST_Grad = 100.46061837 + 36000.770053608 * t + 0.000387933 * t * t - ((t * t * t) / 38710000)
        '  L_GMST_Grad = GMST_Grad
        '  Grad_Integer = Int(GMST_Grad / 360)
        '  Grad_360 = GMST_Grad - (Grad_Integer * 360)
        '  L_Grad = Grad_360


    End Sub

    Private Sub TestJulianischesDatum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        T_Tag.Text = My.Settings.UserDefinedDay
        T_Monat.Text = My.Settings.UserDefinedMonth
        T_Jahr.Text = My.Settings.UserDefinedYear

        T_Stunden.Text = My.Settings.UserDefinedHour
        T_Minuten.Text = My.Settings.UserDefinedMinute
        T_Sekunden.Text = My.Settings.UserDefinedSecond
        T_Zeitzone.Text = My.Settings.UserDefinedTimeZone

        T_Longitude.Text = My.Settings.UserDefinedLongitude

    End Sub
End Class