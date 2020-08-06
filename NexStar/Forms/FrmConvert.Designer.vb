<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConvert
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.B_ConvertDeg = New System.Windows.Forms.Button()
        Me.B_ConvertDegM = New System.Windows.Forms.Button()
        Me.B_ConvertDegMS = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.T_Deg = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_DM_Min = New System.Windows.Forms.TextBox()
        Me.T_DM_Deg = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.T_DMS_Min = New System.Windows.Forms.TextBox()
        Me.T_DMS_Sek = New System.Windows.Forms.TextBox()
        Me.T_DMS_Deg = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.B_ConvertHours = New System.Windows.Forms.Button()
        Me.B_ConvertHM = New System.Windows.Forms.Button()
        Me.B_ConvertHMS = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_Hours = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_HM_Min = New System.Windows.Forms.TextBox()
        Me.T_HM_Hours = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.T_HMS_Min = New System.Windows.Forms.TextBox()
        Me.T_HMS_Sek = New System.Windows.Forms.TextBox()
        Me.T_HMS_Hours = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.B_ConvertRadian = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.T_Radian = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.B_ConvertDeg)
        Me.GroupBox1.Controls.Add(Me.B_ConvertDegM)
        Me.GroupBox1.Controls.Add(Me.B_ConvertDegMS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.T_Deg)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.T_DM_Min)
        Me.GroupBox1.Controls.Add(Me.T_DM_Deg)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.T_DMS_Min)
        Me.GroupBox1.Controls.Add(Me.T_DMS_Sek)
        Me.GroupBox1.Controls.Add(Me.T_DMS_Deg)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(705, 365)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'B_ConvertDeg
        '
        Me.B_ConvertDeg.Location = New System.Drawing.Point(408, 278)
        Me.B_ConvertDeg.Name = "B_ConvertDeg"
        Me.B_ConvertDeg.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertDeg.TabIndex = 106
        Me.B_ConvertDeg.Text = "Convert"
        Me.B_ConvertDeg.UseVisualStyleBackColor = True
        '
        'B_ConvertDegM
        '
        Me.B_ConvertDegM.Location = New System.Drawing.Point(408, 172)
        Me.B_ConvertDegM.Name = "B_ConvertDegM"
        Me.B_ConvertDegM.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertDegM.TabIndex = 105
        Me.B_ConvertDegM.Text = "Convert"
        Me.B_ConvertDegM.UseVisualStyleBackColor = True
        '
        'B_ConvertDegMS
        '
        Me.B_ConvertDegMS.Location = New System.Drawing.Point(408, 70)
        Me.B_ConvertDegMS.Name = "B_ConvertDegMS"
        Me.B_ConvertDegMS.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertDegMS.TabIndex = 104
        Me.B_ConvertDegMS.Text = "Convert"
        Me.B_ConvertDegMS.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 264)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 25)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Grad"
        '
        'T_Deg
        '
        Me.T_Deg.Location = New System.Drawing.Point(55, 292)
        Me.T_Deg.Name = "T_Deg"
        Me.T_Deg.Size = New System.Drawing.Size(232, 31)
        Me.T_Deg.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 25)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Min."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 25)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Grad"
        '
        'T_DM_Min
        '
        Me.T_DM_Min.Location = New System.Drawing.Point(140, 186)
        Me.T_DM_Min.Name = "T_DM_Min"
        Me.T_DM_Min.Size = New System.Drawing.Size(95, 31)
        Me.T_DM_Min.TabIndex = 99
        '
        'T_DM_Deg
        '
        Me.T_DM_Deg.Location = New System.Drawing.Point(55, 186)
        Me.T_DM_Deg.Name = "T_DM_Deg"
        Me.T_DM_Deg.Size = New System.Drawing.Size(61, 31)
        Me.T_DM_Deg.TabIndex = 98
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(135, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 25)
        Me.Label11.TabIndex = 97
        Me.Label11.Text = "Min."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(221, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 25)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Sek."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(50, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 25)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Grad"
        '
        'T_DMS_Min
        '
        Me.T_DMS_Min.Location = New System.Drawing.Point(140, 84)
        Me.T_DMS_Min.Name = "T_DMS_Min"
        Me.T_DMS_Min.Size = New System.Drawing.Size(61, 31)
        Me.T_DMS_Min.TabIndex = 94
        '
        'T_DMS_Sek
        '
        Me.T_DMS_Sek.Location = New System.Drawing.Point(226, 84)
        Me.T_DMS_Sek.Name = "T_DMS_Sek"
        Me.T_DMS_Sek.Size = New System.Drawing.Size(87, 31)
        Me.T_DMS_Sek.TabIndex = 93
        '
        'T_DMS_Deg
        '
        Me.T_DMS_Deg.Location = New System.Drawing.Point(55, 84)
        Me.T_DMS_Deg.Name = "T_DMS_Deg"
        Me.T_DMS_Deg.Size = New System.Drawing.Size(61, 31)
        Me.T_DMS_Deg.TabIndex = 92
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.B_ConvertHours)
        Me.GroupBox2.Controls.Add(Me.B_ConvertHM)
        Me.GroupBox2.Controls.Add(Me.B_ConvertHMS)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.T_Hours)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.T_HM_Min)
        Me.GroupBox2.Controls.Add(Me.T_HM_Hours)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.T_HMS_Min)
        Me.GroupBox2.Controls.Add(Me.T_HMS_Sek)
        Me.GroupBox2.Controls.Add(Me.T_HMS_Hours)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 417)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(699, 407)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stunden"
        '
        'B_ConvertHours
        '
        Me.B_ConvertHours.Location = New System.Drawing.Point(402, 280)
        Me.B_ConvertHours.Name = "B_ConvertHours"
        Me.B_ConvertHours.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertHours.TabIndex = 109
        Me.B_ConvertHours.Text = "Convert"
        Me.B_ConvertHours.UseVisualStyleBackColor = True
        '
        'B_ConvertHM
        '
        Me.B_ConvertHM.Location = New System.Drawing.Point(402, 174)
        Me.B_ConvertHM.Name = "B_ConvertHM"
        Me.B_ConvertHM.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertHM.TabIndex = 108
        Me.B_ConvertHM.Text = "Convert"
        Me.B_ConvertHM.UseVisualStyleBackColor = True
        '
        'B_ConvertHMS
        '
        Me.B_ConvertHMS.Location = New System.Drawing.Point(402, 72)
        Me.B_ConvertHMS.Name = "B_ConvertHMS"
        Me.B_ConvertHMS.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertHMS.TabIndex = 107
        Me.B_ConvertHMS.Text = "Convert"
        Me.B_ConvertHMS.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 266)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 25)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Stunden"
        '
        'T_Hours
        '
        Me.T_Hours.Location = New System.Drawing.Point(49, 294)
        Me.T_Hours.Name = "T_Hours"
        Me.T_Hours.Size = New System.Drawing.Size(232, 31)
        Me.T_Hours.TabIndex = 105
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(129, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 25)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Min."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 25)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Stunden"
        '
        'T_HM_Min
        '
        Me.T_HM_Min.Location = New System.Drawing.Point(134, 188)
        Me.T_HM_Min.Name = "T_HM_Min"
        Me.T_HM_Min.Size = New System.Drawing.Size(95, 31)
        Me.T_HM_Min.TabIndex = 102
        '
        'T_HM_Hours
        '
        Me.T_HM_Hours.Location = New System.Drawing.Point(49, 188)
        Me.T_HM_Hours.Name = "T_HM_Hours"
        Me.T_HM_Hours.Size = New System.Drawing.Size(61, 31)
        Me.T_HM_Hours.TabIndex = 101
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(129, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 25)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Min."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 25)
        Me.Label8.TabIndex = 99
        Me.Label8.Text = "Sek."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 25)
        Me.Label9.TabIndex = 98
        Me.Label9.Text = "Stunden"
        '
        'T_HMS_Min
        '
        Me.T_HMS_Min.Location = New System.Drawing.Point(134, 86)
        Me.T_HMS_Min.Name = "T_HMS_Min"
        Me.T_HMS_Min.Size = New System.Drawing.Size(61, 31)
        Me.T_HMS_Min.TabIndex = 97
        '
        'T_HMS_Sek
        '
        Me.T_HMS_Sek.Location = New System.Drawing.Point(220, 86)
        Me.T_HMS_Sek.Name = "T_HMS_Sek"
        Me.T_HMS_Sek.Size = New System.Drawing.Size(87, 31)
        Me.T_HMS_Sek.TabIndex = 96
        '
        'T_HMS_Hours
        '
        Me.T_HMS_Hours.Location = New System.Drawing.Point(49, 86)
        Me.T_HMS_Hours.Name = "T_HMS_Hours"
        Me.T_HMS_Hours.Size = New System.Drawing.Size(61, 31)
        Me.T_HMS_Hours.TabIndex = 95
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.B_ConvertRadian)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.T_Radian)
        Me.GroupBox3.Location = New System.Drawing.Point(35, 844)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(705, 156)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Radian"
        '
        'B_ConvertRadian
        '
        Me.B_ConvertRadian.Location = New System.Drawing.Point(403, 55)
        Me.B_ConvertRadian.Name = "B_ConvertRadian"
        Me.B_ConvertRadian.Size = New System.Drawing.Size(230, 59)
        Me.B_ConvertRadian.TabIndex = 98
        Me.B_ConvertRadian.Text = "Convert"
        Me.B_ConvertRadian.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(45, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 25)
        Me.Label10.TabIndex = 97
        Me.Label10.Text = "Radian"
        '
        'T_Radian
        '
        Me.T_Radian.Location = New System.Drawing.Point(50, 69)
        Me.T_Radian.Name = "T_Radian"
        Me.T_Radian.Size = New System.Drawing.Size(232, 31)
        Me.T_Radian.TabIndex = 96
        Me.T_Radian.Text = "0"
        '
        'FrmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 1046)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmConvert"
        Me.Text = "FrmConvert"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents B_ConvertDeg As Button
    Friend WithEvents B_ConvertDegM As Button
    Friend WithEvents B_ConvertDegMS As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents T_Deg As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents T_DM_Min As TextBox
    Friend WithEvents T_DM_Deg As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents T_DMS_Min As TextBox
    Friend WithEvents T_DMS_Sek As TextBox
    Friend WithEvents T_DMS_Deg As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents B_ConvertHours As Button
    Friend WithEvents B_ConvertHM As Button
    Friend WithEvents B_ConvertHMS As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents T_Hours As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents T_HM_Min As TextBox
    Friend WithEvents T_HM_Hours As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents T_HMS_Min As TextBox
    Friend WithEvents T_HMS_Sek As TextBox
    Friend WithEvents T_HMS_Hours As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents B_ConvertRadian As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents T_Radian As TextBox
End Class
