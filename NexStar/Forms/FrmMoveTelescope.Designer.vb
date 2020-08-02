<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoveTelescope
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
        Me.components = New System.ComponentModel.Container()
        Me.Picture_Mouse_Move = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MoveGalvoStartToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ESCMoveGalvoStopToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L_SpeedX = New System.Windows.Forms.Label()
        Me.L_SpeedY = New System.Windows.Forms.Label()
        Me.Label_Achse2_Value = New System.Windows.Forms.Label()
        Me.Label_Achse_1_Value = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MouseTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Picture_Mouse_Move, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Picture_Mouse_Move
        '
        Me.Picture_Mouse_Move.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Picture_Mouse_Move.Location = New System.Drawing.Point(48, 70)
        Me.Picture_Mouse_Move.Name = "Picture_Mouse_Move"
        Me.Picture_Mouse_Move.Size = New System.Drawing.Size(476, 202)
        Me.Picture_Mouse_Move.TabIndex = 0
        Me.Picture_Mouse_Move.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveGalvoStartToolStripMenuItem1, Me.ESCMoveGalvoStopToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(335, 80)
        '
        'MoveGalvoStartToolStripMenuItem1
        '
        Me.MoveGalvoStartToolStripMenuItem1.Name = "MoveGalvoStartToolStripMenuItem1"
        Me.MoveGalvoStartToolStripMenuItem1.Size = New System.Drawing.Size(334, 38)
        Me.MoveGalvoStartToolStripMenuItem1.Text = "Move Galvo Start"
        '
        'ESCMoveGalvoStopToolStripMenuItem1
        '
        Me.ESCMoveGalvoStopToolStripMenuItem1.Name = "ESCMoveGalvoStopToolStripMenuItem1"
        Me.ESCMoveGalvoStopToolStripMenuItem1.Size = New System.Drawing.Size(334, 38)
        Me.ESCMoveGalvoStopToolStripMenuItem1.Text = "[ESC] Move Galvo Stop"
        '
        'L_SpeedX
        '
        Me.L_SpeedX.AutoSize = True
        Me.L_SpeedX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_SpeedX.Location = New System.Drawing.Point(627, 52)
        Me.L_SpeedX.Name = "L_SpeedX"
        Me.L_SpeedX.Size = New System.Drawing.Size(28, 27)
        Me.L_SpeedX.TabIndex = 1
        Me.L_SpeedX.Text = "--"
        '
        'L_SpeedY
        '
        Me.L_SpeedY.AutoSize = True
        Me.L_SpeedY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_SpeedY.Location = New System.Drawing.Point(627, 93)
        Me.L_SpeedY.Name = "L_SpeedY"
        Me.L_SpeedY.Size = New System.Drawing.Size(28, 27)
        Me.L_SpeedY.TabIndex = 2
        Me.L_SpeedY.Text = "--"
        '
        'Label_Achse2_Value
        '
        Me.Label_Achse2_Value.AutoSize = True
        Me.Label_Achse2_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Achse2_Value.Location = New System.Drawing.Point(261, 326)
        Me.Label_Achse2_Value.Name = "Label_Achse2_Value"
        Me.Label_Achse2_Value.Size = New System.Drawing.Size(28, 27)
        Me.Label_Achse2_Value.TabIndex = 4
        Me.Label_Achse2_Value.Text = "--"
        '
        'Label_Achse_1_Value
        '
        Me.Label_Achse_1_Value.AutoSize = True
        Me.Label_Achse_1_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Achse_1_Value.Location = New System.Drawing.Point(261, 285)
        Me.Label_Achse_1_Value.Name = "Label_Achse_1_Value"
        Me.Label_Achse_1_Value.Size = New System.Drawing.Size(28, 27)
        Me.Label_Achse_1_Value.TabIndex = 3
        Me.Label_Achse_1_Value.Text = "--"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 285)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Achse 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Achse 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(531, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "[ESC] Move Galvo Stop"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(531, 328)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(248, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "[F12] Punkt übernehmen"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(531, 370)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(294, 25)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "[F1] Grob [F2] Mittel [F3] Fein"
        '
        'MouseTimer
        '
        Me.MouseTimer.Interval = 200
        '
        'FrmMoveTelescope
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 450)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_Achse2_Value)
        Me.Controls.Add(Me.Label_Achse_1_Value)
        Me.Controls.Add(Me.L_SpeedY)
        Me.Controls.Add(Me.L_SpeedX)
        Me.Controls.Add(Me.Picture_Mouse_Move)
        Me.Name = "FrmMoveTelescope"
        Me.Text = "FrmMoveTelescope"
        CType(Me.Picture_Mouse_Move, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Picture_Mouse_Move As PictureBox
    Friend WithEvents L_SpeedX As Label
    Friend WithEvents L_SpeedY As Label
    Friend WithEvents Label_Achse2_Value As Label
    Friend WithEvents Label_Achse_1_Value As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents MouseTimer As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MoveGalvoStartToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ESCMoveGalvoStopToolStripMenuItem1 As ToolStripMenuItem
End Class
