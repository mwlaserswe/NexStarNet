<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vis
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
        Me.Pic = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pic
        '
        Me.Pic.Location = New System.Drawing.Point(-1, -6)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(1006, 887)
        Me.Pic.TabIndex = 0
        Me.Pic.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1251, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 111)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Vis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1507, 883)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Pic)
        Me.Name = "Vis"
        Me.Text = "Vis"
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pic As PictureBox
    Friend WithEvents Button1 As Button
End Class
