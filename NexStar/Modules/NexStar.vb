Option Explicit On
Module NexStar

    ' !!! Die Parameterübergabe per String funktioniert nicht !!!
    '''' interpretiert einen Binärstring von der RS232 als Long
    '''' s =  Chr$(&H0) & Chr$(&H3) & Chr$(&HE8) = 1000
    '''Public Function GetNexStarPosition(s As String) As Long
    '''    Dim i As Long
    '''    Dim le As Long
    '''    Dim Y As Long
    '''    Dim exp As Long
    '''    Dim X As Long
    '''
    '''
    '''    Y = 0
    '''    le = Len(s)
    '''
    '''    For i = 1 To le
    '''        X = Asc(Mid(s, i, 1))
    '''        exp = le - i
    '''        Y = Y + X * 256 ^ exp
    '''    Next i
    '''
    '''    GetNexStarPosition = Y
    '''End Function



    ' erzeugt einen Binärstring für die RS232 aus einer Long-Zahl
    ' 1000 = Chr$(&H0) & Chr$(&H3) & Chr$(&HE8)
    Public Function SetNexStarPosition(Value As Integer) As String
        Dim X As Integer
        Dim i As Integer
        Dim exp As Integer
        Dim a As Integer
        Dim e As Integer

        If (Value < 0) Or (Value > 1677216) Then
            MsgBox("Position Overflow")
            Exit Function
        End If

        X = Value

        For i = 1 To 3
            exp = 3 - i
            e = 256 ^ exp
            a = Int(X / e)
            X = X - a * e
            SetNexStarPosition = SetNexStarPosition & Strings.Chr(a)
        Next i


        ''''UTF to Unicode16
        '''Dim s As String

        '''s = SetNexStarPosition

        '''Dim b() As Byte = System.Text.Encoding.UTF8.GetBytes(s)
        '''Dim s1 As String = System.Text.Encoding.Default.GetString(b)

        '''SetNexStarPosition = s1

    End Function


End Module
