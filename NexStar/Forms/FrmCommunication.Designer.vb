<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCommunication
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.C_Stop = New System.Windows.Forms.Button()
        Me.Tim_Comm = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 25
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(445, 629)
        Me.ListBox1.TabIndex = 0
        '
        'C_Stop
        '
        Me.C_Stop.Location = New System.Drawing.Point(30, 653)
        Me.C_Stop.Name = "C_Stop"
        Me.C_Stop.Size = New System.Drawing.Size(114, 53)
        Me.C_Stop.TabIndex = 1
        Me.C_Stop.Text = "Stop"
        Me.C_Stop.UseVisualStyleBackColor = True
        '
        'Tim_Comm
        '
        Me.Tim_Comm.Enabled = True
        '
        'FrmCommunication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 728)
        Me.Controls.Add(Me.C_Stop)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "FrmCommunication"
        Me.Text = "Communication"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents C_Stop As Button
    Friend WithEvents Tim_Comm As Timer
End Class
