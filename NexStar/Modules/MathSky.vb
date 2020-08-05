﻿Option Explicit On

Module MathSky


    Public Function GetJulianDate(Dt As MyDate, tm As MyTime) As Double
        'wenn Monat > 2 dann  Y = Jahr,   M = Monat
        '                  sonst Y = Jahr - 1, M = Monat + 12
        '
        '   D = Tag
        '
        '   H = Stunde / 24 + Minute / 1440 + Sekunde / 86400
        '
        '   wenn TT.MM.YYYY >= 15.10.1582
        '        dann gregorianischer Kalender: A = Int(Y/100), B = 2 - A + Int(A/4)
        '
        '   wenn TT.MM.YYYY <= 04.10.1582
        '        dann julianischer Kalender:                    B = 0
        '
        '   sonst Fehler: Das Datum zwischen dem 04.10.1582 und dem 15.10.1582 existiert nicht.
        '                 Auf den         04.10.1582 (julianischer Kalender) folgte
        '                 unmittelbar der 15.10.1582 (gregorianischer Kalender).
        '
        '   JD = Int(365,25*(Y+4716)) + Int(30,6001*(M+1)) + D + H + B - 1524,5
        '
        '   Das JD liefert bei 12:00:00 eine ganze Zahl. 4,5 / 24 = 0,1875
        '
        '   Beispiel: 25. März 2010, 16:30 UT (gregorianisch)    2.455.281,1875
        '  Dim A As Double
        Dim a As Double
        Dim B As Double
        Dim H As Double

        If Dt.MM <= 2 Then
            Dt.YY = Dt.YY - 1
            Dt.MM = Dt.MM + 12
        End If

        'Korrektur für den julianischen Kalender
        a = Int(Dt.YY / 100)
        B = 2 - a + Int(a / 4)

        H = tm.H / 24 + tm.M / 1440 + tm.s / 86400

        GetJulianDate = Int(365.25 * (Dt.YY + 4716)) + Int(30.6001 * (Dt.MM + 1)) + Dt.DD + H + B - 1524.5
    End Function


    Public Function GMST(LocalDate As MyDate, LocalTimeUT As MyTime) As MyTime
        ' https://de.wikipedia.org/wiki/Sternzeit
        ' https://de.wikibooks.org/wiki/Astronomische_Berechnungen_für_Amateure/_Zeit/_Zeitrechnungen

        Dim Time0hGMT As MyTime
        Dim LocalTimeSiderial As MyTime

        Dim t As Double
        Dim JD As Double
        Dim GMST_Zeit_s As Double
        Dim GMST_Zeit_h As Double
        Dim GMST_24 As Double
        Dim LokalTime As Double
        Dim GMSTindividualTime As Double

        '1.  Julianische Datum JD um 0h berechnen. Muß immer auf 0,5 enden
        Time0hGMT.H = 0
        Time0hGMT.M = 0
        Time0hGMT.s = 0
        JD = GetJulianDate(LocalDate, Time0hGMT)

        ' 2. Sternzeit in Greenwich berechnen
        ' Berechne die mittlere Sternzeit von Greenwich um 0 h UT zum gewünschten Datum.
        ' Addiere zum Ergebnis von 1) das Produkt t * 1.00273790935
        ' Der Faktor 1.002 737 909 35 berücksichtigt, dass die Sternzeit um so viel schneller abläuft als die Sonnenzeit.
        ' Das Resultat ist zum Schluss wieder auf [0; 24) zu normieren.
        ' Nächster Schritt außerhalb der Function:
        ' Soll die mittlere Sternzeit nicht für Greenwich, sondern für einen Ort der geografischen Länge L° ,
        ' addiere man zum Resultat L/15      (positiv gezählt nach Osten, negativ nach Westen)

        ' Anzahl der seit dem 1. Januar 2000, 12h UT1 (JD = 2451545.0 UT1) verstrichenen UT-Tage
        t = (JD - 2451545.0#) / 36525

        GMST_Zeit_s = 24110.54841 + 8640184.812866 * t + 0.093104 * t * t - 0.0000062 * t * t * t
        GMST_Zeit_h = GMST_Zeit_s / 3600
        GMST_24 = CutTime(GMST_Zeit_h)

        'Lokale Zeit auf siderische Zeit umgerechnet
        LocalTimeSiderial = TimeHMStoDez(LocalTimeUT)
        GMSTindividualTime = LocalTimeSiderial.TimeDec * 1.00273790935 + GMST_24
        GMSTindividualTime = CutTime(GMSTindividualTime)
        GMST = TimeDezToHMS(GMSTindividualTime)

    End Function


    Public Function CutTime(ByVal Hours As Double) As Double
        Dim HoursInt As Long
        HoursInt = Int(Hours / 24)
        CutTime = Hours - (HoursInt * 24)
    End Function


    Public Function CutAngle(ByVal Angle As Double) As Double
        Dim AngleInt As Long
        AngleInt = Int(Angle / 360)
        CutAngle = Angle - (AngleInt * 360)
    End Function


    Public Function CutRad(ByVal Angle As Double) As Double
        Dim AngleInt As Long
        AngleInt = Int(Angle / (2 * Pi))
        CutRad = Angle - (AngleInt * 2 * Pi)
    End Function

    Public Function CutIncr(ByVal Incr As Double) As Double
        Dim IncrInt As Long
        IncrInt = Int(Incr / EncoderResolution)
        CutIncr = Incr - (IncrInt * EncoderResolution)
    End Function


    Public Function TimeDezToHMS(TimeDezimal As Double) As MyTime
        Dim locTDec As Double
        Dim Negative As Boolean

        TimeDezToHMS.TimeDec = TimeDezimal

        If TimeDezimal < 0 Then
            locTDec = -TimeDezimal
            Negative = True
        Else
            locTDec = TimeDezimal
            Negative = False
        End If


        TimeDezToHMS.H = Int(locTDec)
        locTDec = locTDec - TimeDezToHMS.H

        TimeDezToHMS.s = locTDec * 3600

        TimeDezToHMS.M = Int(TimeDezToHMS.s / 60)
        TimeDezToHMS.s = TimeDezToHMS.s - (TimeDezToHMS.M * 60)

    End Function


    Public Function TimeHMStoDez(TimeIn As MyTime) As MyTime
        TimeHMStoDez.TimeDec = TimeIn.H + TimeIn.M / 60 + TimeIn.s / 3600
        TimeHMStoDez.H = TimeIn.H
        TimeHMStoDez.M = TimeIn.M
        TimeHMStoDez.s = TimeIn.s

    End Function

    Public Function GeoToDez(Coord As GeoDegMinSec) As Double
        Dim s As String

        s = Mid(Coord.Sign, 1, 1)
        GeoToDez = Coord.deg + Coord.Min / 60 + Coord.Sec / 3600
        If s = "o" Or s = "O" Or s = "E" Or s = "-" Or s = "s" Or s = "S" Or s = "e" Then
            GeoToDez = -GeoToDez
        ElseIf s = "w" Or s = "W" Or s = "n" Or s = "N" Or s = "+" Then

        End If
    End Function


    Public Function GradToTime(deg As Double) As MyTime
        Dim H As Double

        H = deg * 24 / 360
        GradToTime = TimeDezToHMS(H)
    End Function


    Public Function RadToTime(Rad As Double) As MyTime
        Dim H As Double
        Dim deg As Double

        deg = CutAngle(RadToDeg(Rad))

        H = deg * 24 / 360
        RadToTime = TimeDezToHMS(H)
    End Function


    Public Function TimeToRad(HMS As MyTime) As Double
        Dim tmp1 As MyTime
        Dim tmp2 As Double

        tmp1 = TimeHMStoDez(HMS)
        tmp2 = tmp1.TimeDec * 360 / 24
        TimeToRad = tmp2 / (180 / Pi)

    End Function


    Public Function StingsToDate(sTag As String, sMonat As String, sJahr As String, sStunden As String, sMinuten As String, sSekunden As String) As Date
        Dim iTag As Integer
        Dim iMonat As Integer
        Dim iJahr As Integer
        Dim iStunden As Integer
        Dim iMinuten As Integer
        Dim iSekunden As Integer

        iTag = Int(Zahl(sTag))
        iMonat = Int(Zahl(sMonat))
        iJahr = Int(Zahl(sJahr))
        iStunden = Int(Zahl(sStunden))
        iMinuten = Int(Zahl(sMinuten))
        iSekunden = Int(Zahl(sSekunden))

        If (iTag < 1) Or (iTag > 31) Then iTag = 1
        If (iMonat < 1) Or (iMonat > 12) Then iMonat = 1
        If (iStunden < 0) Or (iStunden > 23) Then iStunden = 0
        If (iMinuten < 0) Or (iMinuten > 59) Then iMinuten = 0
        If (iSekunden < 0) Or (iSekunden > 59) Then iSekunden = 0

        StingsToDate = iTag & "." & iMonat & "." & iJahr & " " & iStunden & ":" & iMinuten & ":" & iSekunden

    End Function


    ' Calculates Hours [0h..24h] in radian [0..6,28]
    ' Example: 12h = 3,14
    Public Function HourToRad(Hours As Double) As Double
        HourToRad = Hours * 2 * Pi / 24
    End Function


    Public Function DegToRad(deg As Double) As Double
        DegToRad = deg / (180 / Pi)
    End Function


    Public Function RadToDeg(Rad As Double) As Double
        RadToDeg = Rad * (180 / Pi)
    End Function


    Public Function arcsin(X As Double) As Double
        'hier gibt es noch ein Problrm, wenn der Stern genau im Zenit steht
        'this formula doesn't work with x = 1 ( => 90°)
        'arcsin = Atn(x / Sqr(-x * x + 1))

        'solution: https://de.wikipedia.org/wiki/Arkussinus_und_Arkuskosinus
        arcsin = 2 * Math.Atan(X / (1 + Math.Sqrt(1 - (X * X))))
    End Function




    Public Function RA_DEC_to_AZ_ALT_new(RaDec_Star As RaDec, GeoPos As GeoCoordinates, SiderialTime As Double) As AzAlt

        ' matrix_method_rev_d.pdf Seite 15
        Dim Az As Double
        Dim Alt As Double
        Dim LocalHourAngleRad As Double

        ' Calculate local hour angle
        LocalHourAngleRad = SiderialTime - RaDec_Star.Ra
        LocalHourAngleRad = LocalHourAngleRad - GeoPos.Longitude

        ' Calculate star position in rectangular equatorial coordinate system
        Dim LMN_Equatorial As Vector         ' Rectangular equatorial coordinate system
        Dim LMN_EquaMatrix(10, 10) As Double

        LMN_Equatorial = PolarKarthesisch(LocalHourAngleRad, RaDec_Star.Dec)

        LMN_EquaMatrix(0, 0) = LMN_Equatorial.X
        LMN_EquaMatrix(1, 0) = LMN_Equatorial.Y
        LMN_EquaMatrix(2, 0) = LMN_Equatorial.z

        'Calculate star position in rectangular horizontal coordinate system
        Dim LMN_Horizontal As Vector                ' Rectangular horizontal coordinate system
        Dim LMN_HorizMatrix(10, 10) As Double
        Dim TransformationMatrix(10, 10) As Double  ' Transformation-Matrix from equatorial Coordinates to horizontal Coordinates

        TransformationMatrix(0, 0) = Math.Cos(GeoPos.Latitude - Pi / 2) : TransformationMatrix(0, 1) = 0 : TransformationMatrix(0, 2) = Math.Sin(GeoPos.Latitude - Pi / 2)
        TransformationMatrix(1, 0) = 0 : TransformationMatrix(1, 1) = 1 : TransformationMatrix(1, 2) = 0
        TransformationMatrix(2, 0) = -Math.Sin(GeoPos.Latitude - Pi / 2) : TransformationMatrix(2, 1) = 0 : TransformationMatrix(2, 2) = Math.Cos(GeoPos.Latitude - Pi / 2)

        MatrixProduct(TransformationMatrix, 3, 3, LMN_EquaMatrix, 3, 1, LMN_HorizMatrix)

        Dim Lh As Double
        Dim Mh As Double
        Dim Nh As Double

        Lh = LMN_HorizMatrix(0, 0)                  ' Rectangular horizontal  coordinate system
        Mh = LMN_HorizMatrix(1, 0)
        Nh = LMN_HorizMatrix(2, 0)

        'Calculate Star position in Altazimuth horizontal coordinate system
        Dim sin_h As Double
        '    When Lh >= 0, (-A) is in the 1st quadrant or the 4th quadrant.
        '    When Lh < 0, (-A) is in the 2nd quadrant or the 3rd quadrant.
        Az = -Math.Atan(Mh / Lh)
        If Lh < 0 Then
            Az = Az + Pi
        End If

        ' Standard: North = 0° so add 180°
        Az = Az + Pi


        'geht möglicherweise einfacher: sin(h) = Nh
        sin_h = Math.Cos(GeoPos.Latitude) * Math.Cos(LocalHourAngleRad) * Math.Cos(RaDec_Star.Dec) + Math.Sin(GeoPos.Latitude) * Math.Sin(RaDec_Star.Dec)
        Alt = arcsin(sin_h)

        RA_DEC_to_AZ_ALT_new.Az = Az
        RA_DEC_to_AZ_ALT_new.Alt = Alt

    End Function


    Public Function AZ_ALT_to_RA_DEC(StarAzAlt As AzAlt, GeoPos As GeoCoordinates, SiderialTime As Double) As RaDec
        ' matrix_method_rev_d.pdf  Seite 15,16
        ' Rückwärts rechnen. Siehe "Matrix Method.doc"
        ' Input: Object Alt and Az, ObserverLatt,
        ' Output: Object RA and DEC

        Dim LMN_Horizontal As Vector
        Dim LMN_HorizMatrix(10, 10) As Double
        Dim ObsLocMatrix(10, 10) As Double  ' Observer location Matrix

        LMN_Horizontal.X = Math.Cos(StarAzAlt.Alt) * Math.Cos(-StarAzAlt.Az)
        LMN_Horizontal.Y = Math.Cos(StarAzAlt.Alt) * Math.Sin(-StarAzAlt.Az)
        LMN_Horizontal.z = Math.Sin(StarAzAlt.Alt)

        ObsLocMatrix(0, 0) = Math.Cos(GeoPos.Latitude - Pi / 2) : ObsLocMatrix(0, 1) = 0 : ObsLocMatrix(0, 2) = Math.Sin(GeoPos.Latitude - Pi / 2)
        ObsLocMatrix(1, 0) = 0 : ObsLocMatrix(1, 1) = 1 : ObsLocMatrix(1, 2) = 0
        ObsLocMatrix(2, 0) = -Math.Sin(GeoPos.Latitude - Pi / 2) : ObsLocMatrix(2, 1) = 0 : ObsLocMatrix(2, 2) = Math.Cos(GeoPos.Latitude - Pi / 2)

        Dim InverseMatrix(10, 10) As Double             'Zeile, Spalte
        Calculate_Inverse(3, ObsLocMatrix, InverseMatrix)

        LMN_HorizMatrix(0, 0) = LMN_Horizontal.X
        LMN_HorizMatrix(1, 0) = LMN_Horizontal.Y
        LMN_HorizMatrix(2, 0) = LMN_Horizontal.z

        Dim LMN_EquaMatrix(10, 10) As Double
        MatrixProduct(InverseMatrix, 3, 3, LMN_HorizMatrix, 3, 1, LMN_EquaMatrix)

        Dim dmy0 As Double
        Dim dmy1 As Double
        Dim dmy2 As Double
        dmy0 = LMN_EquaMatrix(0, 0)
        dmy1 = LMN_EquaMatrix(1, 0)
        dmy2 = LMN_EquaMatrix(2, 0)


        'SWE 
        Dim Star As RaDec
        AZ_ALT_to_RA_DEC.Dec = arcsin(LMN_EquaMatrix(2, 0))

        Dim HourAngle As Double
        HourAngle = arcsin(-LMN_EquaMatrix(1, 0) / Math.Cos(Star.Dec))

        AZ_ALT_to_RA_DEC.Ra = SiderialTime - GeoPos.Longitude - HourAngle

    End Function

    Public Sub CalibrateTelescope__OLD(InitTimerad As Double, RA1Rad As Double, DEC1Rad As Double, TelHorizAngle1 As Double, TelElevAngle1 As Double, ObservTime1Rad As Double, RA2Rad As Double, DEC2Rad As Double, TelHorizAngle2 As Double, TelElevAngle2 As Double, ObservTime2Rad As Double, TransformationMatrix(,) As Double)
        Dim lmn_Tel_1 As Vector     ' Telescope coordinates
        Dim lmn_Tel_2 As Vector
        Dim lmn_Tel_3 As Vector
        Dim LMN_Equ_1 As Vector
        Dim LMN_Equ_2 As Vector
        Dim LMN_Equ_3 As Vector

        'Equation (5.4-5)
        lmn_Tel_1.X = Math.Cos(TelElevAngle1) * Math.Cos(TelHorizAngle1)
        lmn_Tel_1.Y = Math.Cos(TelElevAngle1) * Math.Sin(TelHorizAngle1)
        lmn_Tel_1.z = Math.Sin(TelElevAngle1)

        'Equation (5.4-6)
        LMN_Equ_1.X = Math.Cos(DEC1Rad) * Math.Cos(RA1Rad - SidConst * (ObservTime1Rad - InitTimerad))
        LMN_Equ_1.Y = Math.Cos(DEC1Rad) * Math.Sin(RA1Rad - SidConst * (ObservTime1Rad - InitTimerad))
        LMN_Equ_1.z = Math.Sin(DEC1Rad)

        'Equation (5.4-7)
        lmn_Tel_2.X = Math.Cos(TelElevAngle2) * Math.Cos(TelHorizAngle2)
        lmn_Tel_2.Y = Math.Cos(TelElevAngle2) * Math.Sin(TelHorizAngle2)
        lmn_Tel_2.z = Math.Sin(TelElevAngle2)

        'Equation (5.4-8)
        LMN_Equ_2.X = Math.Cos(DEC2Rad) * Math.Cos(RA2Rad - SidConst * (ObservTime2Rad - InitTimerad))
        LMN_Equ_2.Y = Math.Cos(DEC2Rad) * Math.Sin(RA2Rad - SidConst * (ObservTime2Rad - InitTimerad))
        LMN_Equ_2.z = Math.Sin(DEC2Rad)

        Dim V1_cross_V2 As Vector
        Dim Len_V1_cross_V2 As Double

        'Equation (5.4-13)
        V1_cross_V2 = CrossProduct(lmn_Tel_1, lmn_Tel_2)
        Len_V1_cross_V2 = LenghtVector(V1_cross_V2)
        lmn_Tel_3 = ScalarProduct((1 / Len_V1_cross_V2), V1_cross_V2)

        'Equation (5.4-14)
        V1_cross_V2 = CrossProduct(LMN_Equ_1, LMN_Equ_2)
        Len_V1_cross_V2 = LenghtVector(V1_cross_V2)
        LMN_Equ_3 = ScalarProduct((1 / Len_V1_cross_V2), V1_cross_V2)


        'From equation(5.4 - 11)
        Dim LMN_Equ_Matrix(10, 10) As Double
        Dim LMN_Equ_MatrixInvers(10, 10) As Double
        Dim lmn_Tel_Matrix(10, 10) As Double

        LMN_Equ_Matrix(0, 0) = LMN_Equ_1.X : LMN_Equ_Matrix(0, 1) = LMN_Equ_2.X : LMN_Equ_Matrix(0, 2) = LMN_Equ_3.X
        LMN_Equ_Matrix(1, 0) = LMN_Equ_1.Y : LMN_Equ_Matrix(1, 1) = LMN_Equ_2.Y : LMN_Equ_Matrix(1, 2) = LMN_Equ_3.Y
        LMN_Equ_Matrix(2, 0) = LMN_Equ_1.z : LMN_Equ_Matrix(2, 1) = LMN_Equ_2.z : LMN_Equ_Matrix(2, 2) = LMN_Equ_3.z

        Calculate_Inverse(3, LMN_Equ_Matrix, LMN_Equ_MatrixInvers)
        Dim dmy As Double
        dmy = LMN_Equ_MatrixInvers(0, 0) : dmy = LMN_Equ_MatrixInvers(0, 1) : dmy = LMN_Equ_MatrixInvers(0, 2)
        dmy = LMN_Equ_MatrixInvers(1, 0) : dmy = LMN_Equ_MatrixInvers(1, 1) : dmy = LMN_Equ_MatrixInvers(1, 2)
        dmy = LMN_Equ_MatrixInvers(2, 0) : dmy = LMN_Equ_MatrixInvers(2, 1) : dmy = LMN_Equ_MatrixInvers(2, 2)

        lmn_Tel_Matrix(0, 0) = lmn_Tel_1.X : lmn_Tel_Matrix(0, 1) = lmn_Tel_2.X : lmn_Tel_Matrix(0, 2) = lmn_Tel_3.X
        lmn_Tel_Matrix(1, 0) = lmn_Tel_1.Y : lmn_Tel_Matrix(1, 1) = lmn_Tel_2.Y : lmn_Tel_Matrix(1, 2) = lmn_Tel_3.Y
        lmn_Tel_Matrix(2, 0) = lmn_Tel_1.z : lmn_Tel_Matrix(2, 1) = lmn_Tel_2.z : lmn_Tel_Matrix(2, 2) = lmn_Tel_3.z

        '==================================================================================================
        'This is the TransformationMatrix which transforms a vector from eqatorial to telescope coordinates
        '==================================================================================================
        MatrixProduct(lmn_Tel_Matrix, 3, 3, LMN_Equ_MatrixInvers, 3, 3, TransformationMatrix)
        dmy = TransformationMatrix(0, 0) : dmy = TransformationMatrix(0, 1) : dmy = TransformationMatrix(0, 2)
        dmy = TransformationMatrix(1, 0) : dmy = TransformationMatrix(1, 1) : dmy = TransformationMatrix(1, 2)
        dmy = TransformationMatrix(2, 0) : dmy = TransformationMatrix(2, 1) : dmy = TransformationMatrix(2, 2)

        '''INISetValue IniFileName, "TransformationMatrix__OLD", "Cal_InitTime", InitTimerad
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "00", TransformationMatrix(0, 0)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "01", TransformationMatrix(0, 1)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "02", TransformationMatrix(0, 2)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "10", TransformationMatrix(1, 0)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "11", TransformationMatrix(1, 1)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "12", TransformationMatrix(1, 2)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "20", TransformationMatrix(2, 0)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "21", TransformationMatrix(2, 1)
        '''        INISetValue IniFileName, "TransformationMatrix__OLD", "22", TransformationMatrix(2, 2)

    End Sub




    Public Sub CalibrateTelescope(InitTimerad As Double, Star1 As RaDec, Tel1 As AzAlt, ObservTime1Rad As Double, Star2 As RaDec, Tel2 As AzAlt, ObservTime2Rad As Double, TransformationMatrix(,) As Double)
        Dim lmn_Tel_1 As Vector     ' Telescope coordinates
        Dim lmn_Tel_2 As Vector
        Dim lmn_Tel_3 As Vector
        Dim LMN_Equ_1 As Vector
        Dim LMN_Equ_2 As Vector
        Dim LMN_Equ_3 As Vector

        'Equation (5.4-5)
        lmn_Tel_1.X = Math.Cos(Tel1.Alt) * Math.Cos(Tel1.Az)
        lmn_Tel_1.Y = Math.Cos(Tel1.Alt) * Math.Sin(Tel1.Az)
        lmn_Tel_1.z = Math.Sin(Tel1.Alt)

        'Equation (5.4-6)
        LMN_Equ_1.X = Math.Cos(Star1.Dec) * Math.Cos(Star1.Ra - SidConst * (ObservTime1Rad - InitTimerad))
        LMN_Equ_1.Y = Math.Cos(Star1.Dec) * Math.Sin(Star1.Ra - SidConst * (ObservTime1Rad - InitTimerad))
        LMN_Equ_1.z = Math.Sin(Star1.Dec)

        'Equation (5.4-7)
        lmn_Tel_2.X = Math.Cos(Tel2.Alt) * Math.Cos(Tel2.Az)
        lmn_Tel_2.Y = Math.Cos(Tel2.Alt) * Math.Sin(Tel2.Az)
        lmn_Tel_2.z = Math.Sin(Tel2.Alt)

        'Equation (5.4-8)
        LMN_Equ_2.X = Math.Cos(Star2.Dec) * Math.Cos(Star2.Ra - SidConst * (ObservTime2Rad - InitTimerad))
        LMN_Equ_2.Y = Math.Cos(Star2.Dec) * Math.Sin(Star2.Ra - SidConst * (ObservTime2Rad - InitTimerad))
        LMN_Equ_2.z = Math.Sin(Star2.Dec)

        Dim V1_cross_V2 As Vector
        Dim Len_V1_cross_V2 As Double

        'Equation (5.4-13)
        V1_cross_V2 = CrossProduct(lmn_Tel_1, lmn_Tel_2)
        Len_V1_cross_V2 = LenghtVector(V1_cross_V2)
        lmn_Tel_3 = ScalarProduct((1 / Len_V1_cross_V2), V1_cross_V2)

        'Equation (5.4-14)
        V1_cross_V2 = CrossProduct(LMN_Equ_1, LMN_Equ_2)
        Len_V1_cross_V2 = LenghtVector(V1_cross_V2)
        LMN_Equ_3 = ScalarProduct((1 / Len_V1_cross_V2), V1_cross_V2)


        'From equation(5.4 - 11)
        Dim LMN_Equ_Matrix(10, 10) As Double
        Dim LMN_Equ_MatrixInvers(10, 10) As Double
        Dim lmn_Tel_Matrix(10, 10) As Double

        LMN_Equ_Matrix(0, 0) = LMN_Equ_1.X : LMN_Equ_Matrix(0, 1) = LMN_Equ_2.X : LMN_Equ_Matrix(0, 2) = LMN_Equ_3.X
        LMN_Equ_Matrix(1, 0) = LMN_Equ_1.Y : LMN_Equ_Matrix(1, 1) = LMN_Equ_2.Y : LMN_Equ_Matrix(1, 2) = LMN_Equ_3.Y
        LMN_Equ_Matrix(2, 0) = LMN_Equ_1.z : LMN_Equ_Matrix(2, 1) = LMN_Equ_2.z : LMN_Equ_Matrix(2, 2) = LMN_Equ_3.z

        Calculate_Inverse(3, LMN_Equ_Matrix, LMN_Equ_MatrixInvers)
        Dim dmy As Double
        dmy = LMN_Equ_MatrixInvers(0, 0) : dmy = LMN_Equ_MatrixInvers(0, 1) : dmy = LMN_Equ_MatrixInvers(0, 2)
        dmy = LMN_Equ_MatrixInvers(1, 0) : dmy = LMN_Equ_MatrixInvers(1, 1) : dmy = LMN_Equ_MatrixInvers(1, 2)
        dmy = LMN_Equ_MatrixInvers(2, 0) : dmy = LMN_Equ_MatrixInvers(2, 1) : dmy = LMN_Equ_MatrixInvers(2, 2)

        lmn_Tel_Matrix(0, 0) = lmn_Tel_1.X : lmn_Tel_Matrix(0, 1) = lmn_Tel_2.X : lmn_Tel_Matrix(0, 2) = lmn_Tel_3.X
        lmn_Tel_Matrix(1, 0) = lmn_Tel_1.Y : lmn_Tel_Matrix(1, 1) = lmn_Tel_2.Y : lmn_Tel_Matrix(1, 2) = lmn_Tel_3.Y
        lmn_Tel_Matrix(2, 0) = lmn_Tel_1.z : lmn_Tel_Matrix(2, 1) = lmn_Tel_2.z : lmn_Tel_Matrix(2, 2) = lmn_Tel_3.z

        '==================================================================================================
        'This is the TransformationMatrix which transforms a vector from eqatorial to telescope coordinates
        '==================================================================================================
        MatrixProduct(lmn_Tel_Matrix, 3, 3, LMN_Equ_MatrixInvers, 3, 3, TransformationMatrix)
        dmy = TransformationMatrix(0, 0) : dmy = TransformationMatrix(0, 1) : dmy = TransformationMatrix(0, 2)
        dmy = TransformationMatrix(1, 0) : dmy = TransformationMatrix(1, 1) : dmy = TransformationMatrix(1, 2)
        dmy = TransformationMatrix(2, 0) : dmy = TransformationMatrix(2, 1) : dmy = TransformationMatrix(2, 2)

        '''INISetValue IniFileName, "TransformationMatrix", "Cal_InitTime", InitTimerad
        '''        INISetValue IniFileName, "TransformationMatrix", "00", TransformationMatrix(0, 0)
        '''        INISetValue IniFileName, "TransformationMatrix", "01", TransformationMatrix(0, 1)
        '''        INISetValue IniFileName, "TransformationMatrix", "02", TransformationMatrix(0, 2)
        '''        INISetValue IniFileName, "TransformationMatrix", "10", TransformationMatrix(1, 0)
        '''        INISetValue IniFileName, "TransformationMatrix", "11", TransformationMatrix(1, 1)
        '''        INISetValue IniFileName, "TransformationMatrix", "12", TransformationMatrix(1, 2)
        '''        INISetValue IniFileName, "TransformationMatrix", "20", TransformationMatrix(2, 0)
        '''        INISetValue IniFileName, "TransformationMatrix", "21", TransformationMatrix(2, 1)
        '''        INISetValue IniFileName, "TransformationMatrix", "22", TransformationMatrix(2, 2)

    End Sub


    Public Function AngleBetweenTelescopePositions(Tel1 As AzAlt, Tel2 As AzAlt) As Double
        Dim lmn_Tel_1 As Vector     ' Telescope coordinates
        Dim lmn_Tel_2 As Vector

        'Equation (5.4-5)
        lmn_Tel_1.X = Math.Cos(Tel1.Alt) * Math.Cos(Tel1.Az)
        lmn_Tel_1.Y = Math.Cos(Tel1.Alt) * Math.Sin(Tel1.Az)
        lmn_Tel_1.z = Math.Sin(Tel1.Alt)

        'Equation (5.4-7)
        lmn_Tel_2.X = Math.Cos(Tel2.Alt) * Math.Cos(Tel2.Az)
        lmn_Tel_2.Y = Math.Cos(Tel2.Alt) * Math.Sin(Tel2.Az)
        lmn_Tel_2.z = Math.Sin(Tel2.Alt)

        AngleBetweenTelescopePositions = AngleBetweenVectors(lmn_Tel_1, lmn_Tel_2)

    End Function


    Public Sub CalculateTelescopeCoordinates(InitTimerad As Double, CurrStarRad As RaDec, AimTimeRad As Double, TransformationMatrix(,) As Double, ByRef AzAlt_CurrStar As AzAlt)
        'LMN_Equ_Result: Vector points to Star in equatorial coordinats
        Dim LMN_Equ_Result As Vector
        LMN_Equ_Result.X = Math.Cos(CurrStarRad.Dec) * Math.Cos(CurrStarRad.Ra - SidConst * (AimTimeRad - InitTimerad))
        LMN_Equ_Result.Y = Math.Cos(CurrStarRad.Dec) * Math.Sin(CurrStarRad.Ra - SidConst * (AimTimeRad - InitTimerad))
        LMN_Equ_Result.z = Math.Sin(CurrStarRad.Dec)


        Dim LMN_Equ_ResultMatrix(10, 10) As Double
        Dim lmn_Tel_ResultMatrix(10, 10) As Double
        LMN_Equ_ResultMatrix(0, 0) = LMN_Equ_Result.X
        LMN_Equ_ResultMatrix(1, 0) = LMN_Equ_Result.Y
        LMN_Equ_ResultMatrix(2, 0) = LMN_Equ_Result.z

        MatrixProduct(TransformationMatrix, 3, 3, LMN_Equ_ResultMatrix, 3, 1, lmn_Tel_ResultMatrix)

        'lmn_Tel__Matrix: Vector points to Star in equatorial coordinats

        Dim lmn_Tel_Result As Vector
        lmn_Tel_Result.X = lmn_Tel_ResultMatrix(0, 0)
        lmn_Tel_Result.Y = lmn_Tel_ResultMatrix(1, 0)
        lmn_Tel_Result.z = lmn_Tel_ResultMatrix(2, 0)

        'Dim Az_CurrStarRad As Double
        'Dim Alt_CurrStarRad As Double
        'Dim Az_CurrStar As Double
        'Dim Az_CurrStar_corrected_1 As Double
        'Dim Az_CurrStar_corrected_2 As Double
        'Dim Alt_CurrStar As Double

        AzAlt_CurrStar = VectorToAzAlt(lmn_Tel_Result)

        '''If lmn_Tel_Result.X < 0 Then
        '''    MainForm.Label6 = "minus"
        '''Else
        '''    MainForm.Label6 = "plus"
        '''End If

    End Sub



    Public Function VectorToAzAlt(V As Vector) As AzAlt
        VectorToAzAlt.Az = Math.Atan(V.Y / V.X)
        '    When V.x >= 0, (-A) is in the 1st quadrant or the 4th quadrant.
        '    When V.x < 0, (-A) is in the 2nd quadrant or the 3rd quadrant.
        If V.X < 0 Then
            VectorToAzAlt.Az = VectorToAzAlt.Az + Pi
        End If

        VectorToAzAlt.Alt = arcsin(V.z)
    End Function


    Public Function Matrix_To_MotorIncrSystem(phi As AzAlt) As AzAlt
        'Az
        Matrix_To_MotorIncrSystem.Az = CutRad(-phi.Az) * EncoderResolution / (2 * Pi)

        'Alt
        Matrix_To_MotorIncrSystem.Alt = CutRad(phi.Alt) * EncoderResolution / (2 * Pi)

        'ist der Winkel größer als 90°, dann ist wahrscheinlich negativ
        'dann muß der Fehler bei der Umrechnung in Incremente berücksichtight werden
        If Matrix_To_MotorIncrSystem.Alt > 181639 Then
            Matrix_To_MotorIncrSystem.Alt = Matrix_To_MotorIncrSystem.Alt + 780050
        End If
    End Function


    Public Function MotorIncr_To_MatrixSystem(Incr As AzAlt) As AzAlt
        Dim tmp As Double

        'Az
        tmp = CutIncr(-Incr.Az) * (2 * Math.PI) / EncoderResolution
        MotorIncr_To_MatrixSystem.Az = tmp

        'Alt

        '=== Das gleicht den Fehler bei der Fahrt in negative Alt-Werte aus
        ' der Zähler springt nicht auf 726559 (richtig) sondern auf ca. 1506609 (falsch)
        If Incr.Alt > 780050 Then
            Incr.Alt = Incr.Alt - 780050
        End If

        MotorIncr_To_MatrixSystem.Alt = Incr.Alt * (2 * Pi) / EncoderResolution
    End Function


    Public Function AzAlt_to_MatrixSystem(phi As AzAlt) As AzAlt
        AzAlt_to_MatrixSystem.Az = CutRad(-phi.Az + GlobalOffset.Az)
        AzAlt_to_MatrixSystem.Alt = phi.Alt + GlobalOffset.Alt
    End Function


    Public Function CheckDeltaRad(a1 As Double, a2 As Double, Delta As Double) As Boolean

        If Math.Abs(a1 - a2) < Delta Then
            CheckDeltaRad = True
        ElseIf Math.Abs(a1 + 2 * Pi - a2) < Delta Then
            CheckDeltaRad = True
        ElseIf Math.Abs(a1 - a2 - 2 * Pi) < Delta Then
            CheckDeltaRad = True
        Else
            CheckDeltaRad = False
        End If

    End Function

    Public Function CheckDeltaIncr(a1 As Double, a2 As Double, Delta As Double) As Boolean

        If Math.Abs(a1 - a2) < Delta Then
            CheckDeltaIncr = True
        ElseIf Math.Abs(a1 + EncoderResolution - a2) < Delta Then
            CheckDeltaIncr = True
        ElseIf Math.Abs(a1 - a2 - EncoderResolution) < Delta Then
            CheckDeltaIncr = True
        Else
            CheckDeltaIncr = False
        End If

    End Function

    Public Function GetShortestWay(Dest As Double, From As Double) As Double
        If (Dest >= From) And ((Dest - From) <= EncoderResolution / 2) Then
            GetShortestWay = 1
        ElseIf (From >= Dest) And ((From - Dest) <= EncoderResolution / 2) Then
            GetShortestWay = -1
        ElseIf (From >= Dest) And ((From - Dest) >= EncoderResolution / 2) Then
            GetShortestWay = 1
        Else
            GetShortestWay = -1
        End If

    End Function


    Public Function GetShortestRad(Dest As Double, From As Double) As Double
        If (Dest >= From) And ((Dest - From) <= Pi) Then
            GetShortestRad = Dest - From
        ElseIf (From >= Dest) And ((From - Dest) <= Pi) Then
            GetShortestRad = Dest - From
        ElseIf (From >= Dest) And ((From - Dest) >= Pi) Then
            GetShortestRad = (Dest + 2 * Pi) - From
        Else
            GetShortestRad = Dest - (From + 2 * Pi)
        End If

    End Function




    Public Function GetCardinalDrection(Angle As Double) As String

        Angle = CutRad(Angle)
        If Angle < (16 * (2 * Pi / 16)) Then GetCardinalDrection = "N"
        If Angle < (15 * (2 * Pi / 16)) Then GetCardinalDrection = "NE"
        If Angle < (13 * (2 * Pi / 16)) Then GetCardinalDrection = "E"
        If Angle < (11 * (2 * Pi / 16)) Then GetCardinalDrection = "SE"
        If Angle < (9 * (2 * Pi / 16)) Then GetCardinalDrection = "S"
        If Angle < (7 * (2 * Pi / 16)) Then GetCardinalDrection = "SW"
        If Angle < (5 * (2 * Pi / 16)) Then GetCardinalDrection = "W"
        If Angle < (3 * (2 * Pi / 16)) Then GetCardinalDrection = "NW"
        If Angle < (1 * (2 * Pi / 16)) Then GetCardinalDrection = "N"
    End Function

End Module
