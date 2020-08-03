Option Explicit On

Imports System.IO
Module Utilities
    Private Declare Function FindFirstFile Lib "Kernel32" Alias "FindFirstFileA" (ByVal lpFileName As String, lpFindFileData As WIN32_FIND_DATA) As Long
    Private Declare Function FindNextFile Lib "Kernel32" Alias "FindNextFileA" (ByVal hFindFile As Long, lpFindFileData As WIN32_FIND_DATA) As Long
    Private Declare Function FindClose Lib "Kernel32" (ByVal hFindFile As Long) As Long
    '''Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Any) As Long

    Const ReadBufferSize As Integer = 16 'Oder halt eine für Dich sinnvolle Größe.
    Dim ReadBuffer As Byte() = New Byte(ReadBufferSize - 1) {}

    Public NexStarComm As New System.IO.Ports.SerialPort With {.BaudRate = 4800,
                                                     .DataBits = 8,
                                                     .Parity = IO.Ports.Parity.None,
                                                     .PortName = "COM8",
                                                     .StopBits = IO.Ports.StopBits.One,
                                                     .ReadTimeout = System.Threading.Timeout.Infinite,
                                                     .WriteTimeout = 10}


    Const LB_SETHORIZONTAL = &H194


    Private Structure FILETIME
        Dim dwLowDateTime As Long
        Dim dwHighDateTime As Long
    End Structure

    Const MAX_PATH = 259

    Private Structure WIN32_FIND_DATA
        Dim dwFileAttributes As Long
        Dim ftCreationTime As FILETIME
        Dim ftLastAccessTime As FILETIME
        Dim ftLastWriteTime As FILETIME
        Dim nFileSizeHigh As Long
        Dim nFileSizeLow As Long
        Dim dwReserved0 As Long
        Dim dwReserved1 As Long
        Dim cFileName As String
        Dim cAlternate As String
    End Structure

    Const FILE_ATTRIBUTE_ARCHIVE = &H20
    Const FILE_ATTRIBUTE_COMPRESSED = &H800
    Const FILE_ATTRIBUTE_DIRECTORY = &H10
    Const FILE_ATTRIBUTE_HIDDEN = &H2
    Const FILE_ATTRIBUTE_NORMAL = &H80
    Const FILE_ATTRIBUTE_READONLY = &H1
    Const FILE_ATTRIBUTE_SYSTEM = &H4
    Const FILE_ATTRIBUTE_TEMPORARY = &H100

    Public Const maxlist = 100


    Declare Function GetShortPathName Lib "Kernel32" Alias "GetShortPathNameA" (ByVal lpszLongPath As String, ByVal lpszShortPath As String, ByVal cchBuffer As Long) As Long
    Public bitMaske(0 To 7) As Byte

    '=============================================
    '= Definitionen für Function T (Michael)
    '=============================================
    Public SpracheFileName As String   'Variable, die den Dateinamen und den Pfad, der Ausgabetextsammlng angibt
    Public SprachFileSprache As String 'Variable, mit der man die Sprache der Ausgabe einstellt (z.B. DE für Deutsch)
    Public ErrorCollection As New Collection
    Public SprachFileNummernAnzeigen As Boolean
    Public sprachcollection As New Collection 'Hier werden die Einträge der Ausgabetext-Sammlung gespeichert.
    'Die Ausgabetexte sind mit einem eineindeutigen Schlüssel abrufbar.
    'Dieser Schlüssel setzt sich aus der Textnummer und der einem Sprachkürzel (z.B. "DE") zsammen.
    'Beispiele für einen solchen Schlüssel sind "815EN" oder "753RO"

    Private LanguageCollection As New Collection 'Speicher für alle vorkommenden Sprachen z.B. EN für Englisch , DE für Deutsch...
    Private country_abbrev As String
    Private complete_entry As String
    Private Complete_TextNr_Collection As New Collection

    Private flagMMI As Boolean

    '=============================================
    '= Definitionen für MWMotionDriver
    '=============================================
    Private Declare Function SendCommand Lib "C:\MWMotionDriver\MWMotionDriver.dll" _
         (ByVal Command As String,
          ByVal Parameters As String,
          ByVal reply As String,
          ByVal maxLength As Long) As Long








    Public Function Zahl(Txt As String) As Double
        ' Wandelt die Zahl in einem String in eine Zahl um
        ' dabei werden "," in "." umgewandelt und alle Zeichen
        ' die nicht passen in Leerzeichen gewandelt
        ' 22.07.2002 Exponent möglich
        '            wenn keine Ziffern vorhanden sind, wird Err.number = 1 gesetzt
        Dim i As Integer
        Dim s As String
        Dim noVorz As Boolean, noKomma As Boolean, noExpo As Boolean, haveDigits As Boolean
        s = ""
        For i = 1 To Len(Txt)
            Select Case Mid(Txt, i, 1)
                Case "+", "-"
                    If Not noVorz Then
                        s = s + Mid(Txt, i, 1)
                        noVorz = True
                    Else
                        Exit For
                    End If
                Case ",", "."
                    If Not noKomma Then
                        s = s + "."
                        noKomma = True
                        noVorz = True
                    Else
                        Exit For
                    End If
                Case "0" To "9"
                    s = s + Mid(Txt, i, 1)
                    noVorz = True
                    haveDigits = True
                Case "&"
                    s = s + Mid(Txt, i, 2)
                    noVorz = True
                Case "E", "e"
                    If Not noExpo Then
                        s = s + Mid(Txt, i, 1)
                        noVorz = False
                        noKomma = True
                        noExpo = True
                    Else
                        Exit For
                    End If
                Case " "
                Case Else
                    If noVorz Then Exit For
            End Select
        Next i
        If Not haveDigits Then
            Err.Number = 1
            Err.Description = "Zahl set to 0. No Digits in String"
        End If
        Zahl = Val(s)
    End Function

    Public Function TestZeile(varName As String, Zeile As String, wert As String) As Boolean
        ' Überprüft ob die Zeile den Parameter varName enthält
        ' dabei muß varName am Anfang der Zeile stehen
        ' Groß/kleinschreibung bleibt unberücksichtigt
        ' Ist kein Wert vorhanden, liefert die Funktion FALSE
        ' Der Wert darf auch Leerzeichen enthalten
        ' Input: varName : Name des Parameters
        '        zeile : enthält Parameternamen am anfang und wert
        ' Output : wert : string ohne Parameternamen
        ' Return : True : zeile enthält varName
        '
        ' 18.02.02 varName auf Länge überprüft, wert ohne führende Leerzeichen

        Dim SpacePos As Integer

        TestZeile = False
        If InStr(1, Zeile, varName, vbTextCompare) <> 1 Then Exit Function
        SpacePos = InStr(1, Zeile, " ")
        If SpacePos > 0 Then
            If Len(varName) <> SpacePos - 1 Then Exit Function
        Else
            Exit Function
        End If
        TestZeile = True
        wert = Trim(Mid(Zeile, Len(varName) + 2))

    End Function

    ' Dateiname ohne Pfad extrahieren
    Function DateiName$(vollständig$)
        Dim pos&
        pos = InStrRev(vollständig, "\")
        If pos <> 0 Then
            DateiName = Mid(vollständig, pos + 1)
        Else
            DateiName = vollständig
        End If
    End Function

    ' Pfad ohne Dateinamen extrahieren
    Function Pfad$(vollständig$)
        Dim pos&
        pos = InStrRev(vollständig, "\")
        If pos <> 0 Then
            Pfad = Left(vollständig, pos)
        End If
    End Function

    ' Laufwerksname extrahieren
    Function Laufwerk$(vollständig$)
        Dim pos&
        On Error Resume Next
        If Left(vollständig, 2) = "\\" Then
            pos = InStr(3, vollständig, "\")
            Laufwerk = Left(vollständig, pos - 1)
        Else
            pos = InStr(vollständig, ":")
            Laufwerk = Left(vollständig, pos)
        End If
    End Function

    ' Dateikennung extrahieren
    Function Kennung$(DateiName$)
        Dim pos&
        pos = InStrRev(DateiName, ".")
        If pos <> 0 Then
            Kennung = Mid(DateiName, pos + 1)
        End If
    End Function

    ' Dateikennung entfernen
    Function NameOhneKennung$(DateiName$)
        Dim pos&
        pos = InStrRev(DateiName, ".")
        If pos <> 0 Then
            NameOhneKennung = Left(DateiName, pos - 1)
        Else
            NameOhneKennung = DateiName
        End If
    End Function


    '''Public Function InStrRev(String1 As String, String2 As String) As Long
    '''    Dim Pos1 As Long
    '''    Dim Pos2 As Long

    '''    If (String1 = "") Or (String2 = "") Or (Len(String2) > Len(String1)) Then
    '''        InStrRev = 0
    '''    Else
    '''        Pos2 = 0
    '''        Do
    '''            Pos1 = Pos2
    '''            Pos2 = InStr(Pos1 + 1, String1, String2)
    '''        Loop While Pos2 > 0
    '''        InStrRev = Pos1
    '''    End If
    '''End Function

    Public Function KommaToPunkt(Txt As String) As String
        Dim i As Integer
        Dim s As String

        For i = 1 To Len(Txt)
            Select Case Mid(Txt, i, 1)
                Case ","
                    s = s + "."
                Case Else
                    s = s + Mid(Txt, i, 1)
            End Select
        Next i
        KommaToPunkt = s

    End Function

    Public Function VbGetShortPathName(LongPathName As String)
        Dim sBuffer As String, lLen As Long

        sBuffer = Space$(512)
        lLen = GetShortPathName(LongPathName, sBuffer, Len(sBuffer))
        VbGetShortPathName = Left$(sBuffer, lLen)

    End Function

    Public Function DelCrtlChar(Srt1) As String
        Dim i As Integer

        DelCrtlChar = ""
        For i = 1 To Len(Srt1)
            If Mid(Srt1, i, 1) > Chr(31) And Mid(Srt1, i, 1) < Chr(128) Then
                DelCrtlChar = DelCrtlChar + Mid(Srt1, i, 1)
            End If
        Next i

    End Function

    Public Sub InitVariablen()
        '  Static isInit As Boolean
        '  Dim i As Integer, n As Long
        '
        '  If isInit Then Exit Sub
        '   isInit = True
        '
        '    For i = 0 To 7
        '      bitMaske(i) = 2 ^ i
        '    Next i
        '
        '    n = 1
        '    For i = 0 To 15
        '      bitMaske_Int(i) = n
        '      bitMaskeInv_Int(i) = Not n
        '      n = n * 2
        '    Next i

    End Sub

    Public Sub BitSet(daten As Byte, BitNr As Integer)
        daten = daten Or bitMaske(BitNr)
    End Sub
    Public Sub BitReset(daten As Byte, BitNr As Integer)
        daten = daten And (Not bitMaske(BitNr))
    End Sub


    Public Sub BitSet_Int(daten As Integer, BitNr As Integer)
        '  daten = daten Or bitMaske_Int(BitNr)
    End Sub
    Public Sub BitReset_Int(daten As Integer, BitNr As Integer)
        '  daten = daten And bitMaskeInv_Int(BitNr)
    End Sub


    Public Function BitTest(daten As Byte, BitNr As Integer) As Boolean
        '  BitTest = False
        '  If (daten And bitMaske(BitNr)) <> 0 Then
        '    BitTest = True
        '  End If
    End Function


    '''  Public Sub PrintControlCaption(WertVar As Variant, Steuerelement As Variant)
    '''      Dim WertOld As Variant
    '''      Dim wert As String

    '''      '1. sicherstellen, daß alle Werte als String vorliegen
    '''      If Not (VarType(WertVar) = 8) Then
    '''          wert = CStr(WertVar)
    '''      Else
    '''          wert = WertVar
    '''      End If

    '''      If (TypeOf Steuerelement Is Label) _
    '''   Or (TypeOf Steuerelement Is Form) _
    '''   Or (TypeOf Steuerelement Is Frame) _
    '''   Or (TypeOf Steuerelement Is CommandButton) _
    '''Then
    '''          WertOld = Steuerelement.Caption
    '''          If (WertOld <> wert) Then         'hat sich die Wert geändert?
    '''              Steuerelement.Caption = wert

    '''          End If
    '''      End If
    '''      If TypeOf Steuerelement Is TextBox Then
    '''          WertOld = Steuerelement.Text
    '''          If (WertOld <> wert) Then         'hat sich die Wert geändert?
    '''              Steuerelement.Text = wert
    '''          End If
    '''      End If
    '''  End Sub
    '''  Public Sub PrintControlFehler(WertVar As Variant, Steuerelement As Variant)
    '''      Dim WertOld As Variant
    '''      Dim wert As String

    '''      '1. sicherstellen, daß alle Werte als String vorliegen
    '''      If Not (VarType(WertVar) = 8) Then
    '''          wert = CStr(WertVar)
    '''      Else
    '''          wert = WertVar
    '''      End If

    '''      If (TypeOf Steuerelement Is Label) _
    '''   Or (TypeOf Steuerelement Is Form) _
    '''   Or (TypeOf Steuerelement Is Frame) _
    '''   Or TypeOf Steuerelement Is TextBox _
    '''   Or (TypeOf Steuerelement Is CommandButton) _
    '''Then

    '''          WertOld = Steuerelement
    '''          If (WertOld <> wert) Then         'hat sich die Wert geändert?
    '''              '      ProtokollMessage wert

    '''          End If

    '''      End If

    '''  End Sub

    '''Public Sub PrintControlColor(wert As Long, Steuerelement As Variant)
    '''    Dim WertOld As Long

    '''    WertOld = Steuerelement.BackColor
    '''    If (WertOld <> wert) Then         'hat sich die Wert geändert?
    '''        Steuerelement.BackColor = wert
    '''    End If
    '''End Sub

    '''Public Sub PrintControlForeColor(wert As Long, Steuerelement As Variant)
    '''    Dim WertOld As Long

    '''    WertOld = Steuerelement.ForeColor
    '''    If (WertOld <> wert) Then         'hat sich die Wert geändert?
    '''        Steuerelement.ForeColor = wert
    '''    End If
    '''End Sub









    '''Public Sub PrintCommImage(PortNr As String, CommStatus As String, Pic As PictureBox)
    '''    Dim TagOld As String
    '''    Dim CommStatusOld As String

    '''    CommStatusOld = Pic.Tag
    '''    If CommStatusOld <> CommStatus Then
    '''        Pic.Tag = CommStatus
    '''        If CommStatus = True Then
    '''            Pic.Cls
    '''            Pic.BackColor = vbGreen
    '''            Pic.Print PortNr
    '''Else
    '''            Pic.Cls
    '''            Pic.BackColor = vbRed
    '''            Pic.Print PortNr
    '''End If
    '''    End If

    '''End Sub


    Public Sub SepariereString(Zeile As String, ByRef WortArray() As String, Delimiter As String)
        Dim Pos1 As Long
        Dim Pos2 As Long
        Dim AnzahlWorte As Long               'Anzahl der Worte der Zeile

        ReDim WortArray(0 To 0)                         'WortArray löschen
        AnzahlWorte = 0
        Pos2 = 0

        If Delimiter = " " Then Zeile = Trim(Zeile)

        Zeile = Trim(Zeile)
        Do
            Pos1 = Pos2

            'Trennzeichen [CR]: [LF] werden überlesen
            If Delimiter = vbCr Then
                If Mid(Zeile, Pos1 + 1, 1) = vbLf Then
                    Pos1 = Pos1 + 1                             'LF übergehen
                End If
            End If

            'Trennzeichen [Space]: [Space] werden überlesen
            If Delimiter = " " Then
                Do While Mid(Zeile, Pos1 + 1, 1) = " "
                    Pos1 = Pos1 + 1                             'Space übergehen
                Loop
            End If

            Pos2 = InStr(Pos1 + 1, Zeile, Delimiter, CompareMethod.Binary)      'nach Trennzeichen suchen
            If Pos2 > 0 Then                              'noch ein Trennzeichen in der Zeile
                WortArray(AnzahlWorte) = Mid(Zeile, Pos1 + 1, Pos2 - Pos1 - 1)
                ReDim Preserve WortArray(0 To UBound(WortArray) + 1)
                AnzahlWorte = AnzahlWorte + 1
            Else                                          'kein Trennzeichen mehr vorhanden
                WortArray(AnzahlWorte) = Mid(Zeile, Pos1 + 1)
            End If
        Loop While Pos2 > 0
    End Sub








    Private Function ReadCollectionItem(varKey, var_text) As Boolean

        On Error GoTo not_found
        var_text = CStr(sprachcollection.Item(varKey))
        ReadCollectionItem = True
        Exit Function

not_found:
        ReadCollectionItem = False
    End Function



    ' Zerlegt eine 32-Bit Zahl in 4 Byte(0..3)
    Public Sub LongToByte(ByVal l As Long, B() As Byte)
        Dim i As Integer

        For i = 0 To 3
            B(i) = l And 255&
            l = Int(l / 256&)
            '         L = L \ 256&           ' funktioniert nicht !!
        Next i

    End Sub

    ' Vereint 4 Bytes(0..3) zu einer 32-Bit Zahl mit Vorzeichen
    Public Function ByteToLong(B() As Byte) As Long
        Dim i As Integer
        Dim negativ As Boolean
        Dim ByteLocal(3) As Byte

        ByteLocal(0) = B(0) : ByteLocal(1) = B(1)
        ByteLocal(2) = B(2) : ByteLocal(3) = B(3)

        negativ = False
        If (ByteLocal(3) And &H80) Then
            For i = 0 To 3
                ByteLocal(i) = Not (ByteLocal(i))
                negativ = True
            Next i
        End If

        For i = 3 To 0 Step -1
            ByteToLong = (256 * ByteToLong) + ByteLocal(i)
        Next i

        If negativ Then
            ByteToLong = Not (ByteToLong)
        End If

    End Function


    Public Sub NexStarCommunication(CommString As String, Comment As String, Mode As ProtokollMode)
        Dim CommFile As Integer
        Dim i As Integer
        '    Dim Prexit As String

        On Error GoTo OpenError

        CommFileName = Path.Combine(DefaultPath, "Commu_.txt")

        CommFile = FreeFile()                'Nächste freie DateiNr.
        FileOpen(CommFile, CommFileName, OpenMode.Append)


        Select Case Mode
            Case ProtokollMode.Send
                NexStarComm.Write(CommString)
                PrintLine(CommFile, "--> Send:   " & Comment)
                If Not FrmCommunication.StopFlag Then
                    FrmCommunication.ListBox1.Items.Add("--> Send:   " & Comment)
                    FrmCommunication.ListBox1.SelectedIndex = FrmCommunication.ListBox1.Items.Count - 1 'Letzten Eintrag hinterlegen
                End If
            Case ProtokollMode.Receive
                PrintLine(CommFile, "--> Recive:   " & Comment)
                If Not FrmCommunication.StopFlag Then
                    FrmCommunication.ListBox1.Items.Add("--> Recive:   " & Comment)
                    FrmCommunication.ListBox1.SelectedIndex = FrmCommunication.ListBox1.Items.Count - 1 'Letzten Eintrag hinterlegen
                End If

        End Select

        FileClose(CommFile)



        Exit Sub

OpenError:
        '''MsgBox CommFileName, , "Write error"

    End Sub

    'Public Sub KickoffRead()
    '    NexStarComm.BaseStream.BeginRead(ReadBuffer, 0, ReadBufferSize, AddressOf ReadCallback, Nothing)

    'End Sub
    'Public Sub ReadCallback(Result As IAsyncResult)
    '    Dim ActualLength As Integer
    '    Try
    '        ActualLength = NexStarComm.BaseStream.EndRead(Result)
    '    Catch ex As System.IO.IOException
    '        'Damit habe ich mich noch nicht genug befasst.
    '        'IOExceptions treten manchmal auf.
    '        Return
    '    Catch ex As InvalidOperationException
    '        'Tritt auf, wenn der Port geschlossen wurde.
    '        Return
    '    End Try
    '    Dim BufferCopy = New Byte(ActualLength - 1) {}
    '    Array.Copy(ReadBuffer, BufferCopy, ActualLength)
    '    'Me.BeginInvoke(Sub() BytesReceived(BufferCopy))
    '    KickoffRead()
    'End Sub
End Module
