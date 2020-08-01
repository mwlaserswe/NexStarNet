<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestJulianischesDatum
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.T_Tag = New System.Windows.Forms.TextBox()
        Me.T_Longitude = New System.Windows.Forms.TextBox()
        Me.T_Sekunden = New System.Windows.Forms.TextBox()
        Me.T_Minuten = New System.Windows.Forms.TextBox()
        Me.T_Stunden = New System.Windows.Forms.TextBox()
        Me.T_Jahr = New System.Windows.Forms.TextBox()
        Me.T_Monat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.L_GMST_Zeit = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.L_JD = New System.Windows.Forms.Label()
        Me.L_Zeit_Ort_2 = New System.Windows.Forms.Label()
        Me.L_Zeit_Ort = New System.Windows.Forms.Label()
        Me.L_Zeit2 = New System.Windows.Forms.Label()
        Me.L_Zeit = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.L_Grad = New System.Windows.Forms.Label()
        Me.L_GMST_Grad = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.B_StartCalculation = New System.Windows.Forms.Button()
        Me.T_Zeitzone = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'T_Tag
        '
        Me.T_Tag.Location = New System.Drawing.Point(47, 57)
        Me.T_Tag.Name = "T_Tag"
        Me.T_Tag.Size = New System.Drawing.Size(61, 31)
        Me.T_Tag.TabIndex = 0
        '
        'T_Longitude
        '
        Me.T_Longitude.Location = New System.Drawing.Point(179, 130)
        Me.T_Longitude.Name = "T_Longitude"
        Me.T_Longitude.Size = New System.Drawing.Size(258, 31)
        Me.T_Longitude.TabIndex = 1
        '
        'T_Sekunden
        '
        Me.T_Sekunden.Location = New System.Drawing.Point(563, 57)
        Me.T_Sekunden.Name = "T_Sekunden"
        Me.T_Sekunden.Size = New System.Drawing.Size(61, 31)
        Me.T_Sekunden.TabIndex = 2
        '
        'T_Minuten
        '
        Me.T_Minuten.Location = New System.Drawing.Point(476, 57)
        Me.T_Minuten.Name = "T_Minuten"
        Me.T_Minuten.Size = New System.Drawing.Size(61, 31)
        Me.T_Minuten.TabIndex = 3
        '
        'T_Stunden
        '
        Me.T_Stunden.Location = New System.Drawing.Point(392, 57)
        Me.T_Stunden.Name = "T_Stunden"
        Me.T_Stunden.Size = New System.Drawing.Size(61, 31)
        Me.T_Stunden.TabIndex = 4
        '
        'T_Jahr
        '
        Me.T_Jahr.Location = New System.Drawing.Point(218, 57)
        Me.T_Jahr.Name = "T_Jahr"
        Me.T_Jahr.Size = New System.Drawing.Size(61, 31)
        Me.T_Jahr.TabIndex = 5
        '
        'T_Monat
        '
        Me.T_Monat.Location = New System.Drawing.Point(132, 57)
        Me.T_Monat.Name = "T_Monat"
        Me.T_Monat.Size = New System.Drawing.Size(61, 31)
        Me.T_Monat.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Tag"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Geo. Länge"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(558, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "S"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(470, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "M"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(387, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "H"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(213, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 25)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Jahr"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(127, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 25)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Monat"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(77, 366)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 25)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Zeit GMST 0h"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(77, 325)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 25)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "GMST Zeit"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(669, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 25)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Zeit in UT"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(465, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 25)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Ost ist positiv"
        '
        'L_GMST_Zeit
        '
        Me.L_GMST_Zeit.AutoSize = True
        Me.L_GMST_Zeit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_GMST_Zeit.Location = New System.Drawing.Point(288, 325)
        Me.L_GMST_Zeit.Name = "L_GMST_Zeit"
        Me.L_GMST_Zeit.Size = New System.Drawing.Size(91, 27)
        Me.L_GMST_Zeit.TabIndex = 18
        Me.L_GMST_Zeit.Text = "Label12"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(77, 498)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(186, 25)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Zeit u. Ort (H:M:S)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(77, 452)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(201, 25)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Zeit u. Ort (dezimal)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(77, 411)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 25)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Zeit"
        '
        'L_JD
        '
        Me.L_JD.AutoSize = True
        Me.L_JD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_JD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_JD.Location = New System.Drawing.Point(248, 225)
        Me.L_JD.Name = "L_JD"
        Me.L_JD.Size = New System.Drawing.Size(131, 39)
        Me.L_JD.TabIndex = 22
        Me.L_JD.Text = "Label16"
        '
        'L_Zeit_Ort_2
        '
        Me.L_Zeit_Ort_2.AutoSize = True
        Me.L_Zeit_Ort_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Zeit_Ort_2.Location = New System.Drawing.Point(288, 498)
        Me.L_Zeit_Ort_2.Name = "L_Zeit_Ort_2"
        Me.L_Zeit_Ort_2.Size = New System.Drawing.Size(91, 27)
        Me.L_Zeit_Ort_2.TabIndex = 23
        Me.L_Zeit_Ort_2.Text = "Label17"
        '
        'L_Zeit_Ort
        '
        Me.L_Zeit_Ort.AutoSize = True
        Me.L_Zeit_Ort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Zeit_Ort.Location = New System.Drawing.Point(288, 452)
        Me.L_Zeit_Ort.Name = "L_Zeit_Ort"
        Me.L_Zeit_Ort.Size = New System.Drawing.Size(91, 27)
        Me.L_Zeit_Ort.TabIndex = 24
        Me.L_Zeit_Ort.Text = "Label18"
        '
        'L_Zeit2
        '
        Me.L_Zeit2.AutoSize = True
        Me.L_Zeit2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Zeit2.Location = New System.Drawing.Point(288, 411)
        Me.L_Zeit2.Name = "L_Zeit2"
        Me.L_Zeit2.Size = New System.Drawing.Size(91, 27)
        Me.L_Zeit2.TabIndex = 25
        Me.L_Zeit2.Text = "Label19"
        '
        'L_Zeit
        '
        Me.L_Zeit.AutoSize = True
        Me.L_Zeit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Zeit.Location = New System.Drawing.Point(288, 366)
        Me.L_Zeit.Name = "L_Zeit"
        Me.L_Zeit.Size = New System.Drawing.Size(91, 27)
        Me.L_Zeit.TabIndex = 26
        Me.L_Zeit.Text = "Label20"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(90, 227)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 37)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "JD"
        '
        'L_Grad
        '
        Me.L_Grad.AutoSize = True
        Me.L_Grad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Grad.Location = New System.Drawing.Point(720, 368)
        Me.L_Grad.Name = "L_Grad"
        Me.L_Grad.Size = New System.Drawing.Size(91, 27)
        Me.L_Grad.TabIndex = 31
        Me.L_Grad.Text = "Label20"
        '
        'L_GMST_Grad
        '
        Me.L_GMST_Grad.AutoSize = True
        Me.L_GMST_Grad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_GMST_Grad.Location = New System.Drawing.Point(720, 327)
        Me.L_GMST_Grad.Name = "L_GMST_Grad"
        Me.L_GMST_Grad.Size = New System.Drawing.Size(91, 27)
        Me.L_GMST_Grad.TabIndex = 30
        Me.L_GMST_Grad.Text = "Label12"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(509, 327)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(132, 25)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "GMST_Grad"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(509, 368)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 25)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Grad"
        '
        'B_StartCalculation
        '
        Me.B_StartCalculation.Location = New System.Drawing.Point(132, 606)
        Me.B_StartCalculation.Name = "B_StartCalculation"
        Me.B_StartCalculation.Size = New System.Drawing.Size(595, 70)
        Me.B_StartCalculation.TabIndex = 32
        Me.B_StartCalculation.Text = "Starte Berechnung"
        Me.B_StartCalculation.UseVisualStyleBackColor = True
        '
        'T_Zeitzone
        '
        Me.T_Zeitzone.AutoSize = True
        Me.T_Zeitzone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_Zeitzone.Location = New System.Drawing.Point(720, 411)
        Me.T_Zeitzone.Name = "T_Zeitzone"
        Me.T_Zeitzone.Size = New System.Drawing.Size(35, 27)
        Me.T_Zeitzone.TabIndex = 34
        Me.T_Zeitzone.Text = "---"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(509, 411)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 25)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Zeitzone"
        '
        'TestJulianischesDatum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 725)
        Me.Controls.Add(Me.T_Zeitzone)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.B_StartCalculation)
        Me.Controls.Add(Me.L_Grad)
        Me.Controls.Add(Me.L_GMST_Grad)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.L_Zeit)
        Me.Controls.Add(Me.L_Zeit2)
        Me.Controls.Add(Me.L_Zeit_Ort)
        Me.Controls.Add(Me.L_Zeit_Ort_2)
        Me.Controls.Add(Me.L_JD)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.L_GMST_Zeit)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_Monat)
        Me.Controls.Add(Me.T_Jahr)
        Me.Controls.Add(Me.T_Stunden)
        Me.Controls.Add(Me.T_Minuten)
        Me.Controls.Add(Me.T_Sekunden)
        Me.Controls.Add(Me.T_Longitude)
        Me.Controls.Add(Me.T_Tag)
        Me.Name = "TestJulianischesDatum"
        Me.Text = "TestJulianischesDatum"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents T_Tag As TextBox
    Friend WithEvents T_Longitude As TextBox
    Friend WithEvents T_Sekunden As TextBox
    Friend WithEvents T_Minuten As TextBox
    Friend WithEvents T_Stunden As TextBox
    Friend WithEvents T_Jahr As TextBox
    Friend WithEvents T_Monat As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents L_GMST_Zeit As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents L_JD As Label
    Friend WithEvents L_Zeit_Ort_2 As Label
    Friend WithEvents L_Zeit_Ort As Label
    Friend WithEvents L_Zeit2 As Label
    Friend WithEvents L_Zeit As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents L_Grad As Label
    Friend WithEvents L_GMST_Grad As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents B_StartCalculation As Button
    Friend WithEvents T_Zeitzone As Label
    Friend WithEvents Label16 As Label
End Class
