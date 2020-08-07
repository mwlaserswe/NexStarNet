<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TesteJulianischesDatumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CovertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CursorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisualisierungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommunicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.C_SetEncoder_Az = New System.Windows.Forms.Button()
        Me.C_MoveTelescope = New System.Windows.Forms.Button()
        Me.C_Simulation = New System.Windows.Forms.Button()
        Me.C_GotoNorth = New System.Windows.Forms.Button()
        Me.C_GetAlt = New System.Windows.Forms.Button()
        Me.C_GetAz = New System.Windows.Forms.Button()
        Me.C_SetBacklAlt = New System.Windows.Forms.Button()
        Me.C_SetBacklAz = New System.Windows.Forms.Button()
        Me.C_SetEncoder_Alt = New System.Windows.Forms.Button()
        Me.T_Backlash = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.L_SlewingSpeedX = New System.Windows.Forms.Label()
        Me.C_Up = New System.Windows.Forms.Button()
        Me.C_Dn = New System.Windows.Forms.Button()
        Me.C_Le = New System.Windows.Forms.Button()
        Me.C_Ri = New System.Windows.Forms.Button()
        Me.VS_ManualSlewingSpeed = New System.Windows.Forms.VScrollBar()
        Me.L_Angle = New System.Windows.Forms.Label()
        Me.L_SlewingSpeedY = New System.Windows.Forms.Label()
        Me.AlignmentStarList = New System.Windows.Forms.ListBox()
        Me.C_GotoStar = New System.Windows.Forms.Button()
        Me.C_SingleStarCalib = New System.Windows.Forms.Button()
        Me.C_SetCalibrationStar_2 = New System.Windows.Forms.Button()
        Me.C_Set_ObserverLocation = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.T_Monat = New System.Windows.Forms.TextBox()
        Me.T_Jahr = New System.Windows.Forms.TextBox()
        Me.T_Stunden = New System.Windows.Forms.TextBox()
        Me.T_Minuten = New System.Windows.Forms.TextBox()
        Me.T_Sekunden = New System.Windows.Forms.TextBox()
        Me.T_Tag = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.T_Latt_Min = New System.Windows.Forms.TextBox()
        Me.T_Latt_Sek = New System.Windows.Forms.TextBox()
        Me.T_Long_Grad = New System.Windows.Forms.TextBox()
        Me.T_Long_Min = New System.Windows.Forms.TextBox()
        Me.T_Long_Sek = New System.Windows.Forms.TextBox()
        Me.T_Latt_Grad = New System.Windows.Forms.TextBox()
        Me.T_Latt_Sign = New System.Windows.Forms.TextBox()
        Me.T_Long_Sign = New System.Windows.Forms.TextBox()
        Me.L_CurrentStar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.O_TimeSelectSim = New System.Windows.Forms.RadioButton()
        Me.O_TimeSelectLocal = New System.Windows.Forms.RadioButton()
        Me.L_UTime = New System.Windows.Forms.Label()
        Me.L_SiderialTime = New System.Windows.Forms.Label()
        Me.L_LocalTime = New System.Windows.Forms.Label()
        Me.F_StarInfo = New System.Windows.Forms.GroupBox()
        Me.L_CardinalOrientation = New System.Windows.Forms.Label()
        Me.L_I_HorXYZ = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.L_I_EquXYZ = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.L_I_HourAngle = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.L_I_Alt = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.L_I_Az = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.L_I_DEC = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.L_I_RA = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.F_PreviewInfo = New System.Windows.Forms.GroupBox()
        Me.L_Preview_CardinalOrientation = New System.Windows.Forms.Label()
        Me.Ch_South = New System.Windows.Forms.CheckBox()
        Me.L_Preview_HorXYZ = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.L_Preview_EquXYZ = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.L_Preview_HourAngle = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.L_Preview_Alt = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.L_Preview_Az = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.L_Preview_DEC = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.L_Preview_RA = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.C_Tracking = New System.Windows.Forms.Button()
        Me.MSComm1 = New System.IO.Ports.SerialPort(Me.components)
        Me.LoadStarKatalogDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Tim_DisplayUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.L_MotorSystemAzDiff = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAzDiff = New System.Windows.Forms.Label()
        Me.L_AzMotorIncr = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAzIst = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.L_AzAltSystem = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAzSoll = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.L_GlobalAzOffset = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.L_MotorSystemAltDiff = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAltDiff = New System.Windows.Forms.Label()
        Me.L_AltMotorIncr = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAltIst = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAltSoll = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.L_GlobalAltOffset = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.L_MatrixSystemAzDiffReal = New System.Windows.Forms.Label()
        Me.L_MotorSystemAzDiffReal = New System.Windows.Forms.Label()
        Me.L_MotorSystemAzDiffSim = New System.Windows.Forms.Label()
        Me.L_ErrorCount = New System.Windows.Forms.Label()
        Me.L_StatusMoving = New System.Windows.Forms.Label()
        Me.Tim_Preview = New System.Windows.Forms.Timer(Me.components)
        Me.Tim_Simulation = New System.Windows.Forms.Timer(Me.components)
        Me.Tim_Startup = New System.Windows.Forms.Timer(Me.components)
        Me.Tim_TestStatus = New System.Windows.Forms.Timer(Me.components)
        Me.Tim_Tracking = New System.Windows.Forms.Timer(Me.components)
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Slider1 = New System.Windows.Forms.ProgressBar()
        Me.Slider2 = New System.Windows.Forms.ProgressBar()
        Me.T_Alt = New System.Windows.Forms.TextBox()
        Me.T_Az = New System.Windows.Forms.TextBox()
        Me.L_ElapsedTime = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.CB_Find = New System.Windows.Forms.ComboBox()
        Me.Tim_Comm = New System.Windows.Forms.Timer(Me.components)
        Me.B_Comm = New System.Windows.Forms.Button()
        Me.L_NumerOfCmd = New System.Windows.Forms.Label()
        Me.OpenCursorDialog = New System.Windows.Forms.OpenFileDialog()
        Me.B_SetCurrentPos = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.F_StarInfo.SuspendLayout()
        Me.F_PreviewInfo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetupToolStripMenuItem, Me.TestToolStripMenuItem, Me.CommunicationToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(2042, 40)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(193, 36)
        Me.SetupToolStripMenuItem.Text = "Stern-Kataloge"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TesteJulianischesDatumToolStripMenuItem, Me.CovertToolStripMenuItem, Me.CursorToolStripMenuItem, Me.VisualisierungToolStripMenuItem})
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(77, 36)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'TesteJulianischesDatumToolStripMenuItem
        '
        Me.TesteJulianischesDatumToolStripMenuItem.Name = "TesteJulianischesDatumToolStripMenuItem"
        Me.TesteJulianischesDatumToolStripMenuItem.Size = New System.Drawing.Size(415, 44)
        Me.TesteJulianischesDatumToolStripMenuItem.Text = "Teste Julianisches Datum"
        '
        'CovertToolStripMenuItem
        '
        Me.CovertToolStripMenuItem.Name = "CovertToolStripMenuItem"
        Me.CovertToolStripMenuItem.Size = New System.Drawing.Size(415, 44)
        Me.CovertToolStripMenuItem.Text = "Convert"
        '
        'CursorToolStripMenuItem
        '
        Me.CursorToolStripMenuItem.Name = "CursorToolStripMenuItem"
        Me.CursorToolStripMenuItem.Size = New System.Drawing.Size(415, 44)
        Me.CursorToolStripMenuItem.Text = "Cursor"
        '
        'VisualisierungToolStripMenuItem
        '
        Me.VisualisierungToolStripMenuItem.Name = "VisualisierungToolStripMenuItem"
        Me.VisualisierungToolStripMenuItem.Size = New System.Drawing.Size(415, 44)
        Me.VisualisierungToolStripMenuItem.Text = "Visualisierung"
        '
        'CommunicationToolStripMenuItem
        '
        Me.CommunicationToolStripMenuItem.Name = "CommunicationToolStripMenuItem"
        Me.CommunicationToolStripMenuItem.Size = New System.Drawing.Size(205, 36)
        Me.CommunicationToolStripMenuItem.Text = "Communication"
        '
        'C_SetEncoder_Az
        '
        Me.C_SetEncoder_Az.Location = New System.Drawing.Point(32, 73)
        Me.C_SetEncoder_Az.Name = "C_SetEncoder_Az"
        Me.C_SetEncoder_Az.Size = New System.Drawing.Size(143, 48)
        Me.C_SetEncoder_Az.TabIndex = 1
        Me.C_SetEncoder_Az.Text = "Set Enc. Az"
        Me.C_SetEncoder_Az.UseVisualStyleBackColor = True
        '
        'C_MoveTelescope
        '
        Me.C_MoveTelescope.Location = New System.Drawing.Point(35, 535)
        Me.C_MoveTelescope.Name = "C_MoveTelescope"
        Me.C_MoveTelescope.Size = New System.Drawing.Size(370, 597)
        Me.C_MoveTelescope.TabIndex = 2
        Me.C_MoveTelescope.Text = "Move Telescope"
        Me.C_MoveTelescope.UseVisualStyleBackColor = True
        '
        'C_Simulation
        '
        Me.C_Simulation.Location = New System.Drawing.Point(653, 127)
        Me.C_Simulation.Name = "C_Simulation"
        Me.C_Simulation.Size = New System.Drawing.Size(143, 51)
        Me.C_Simulation.TabIndex = 3
        Me.C_Simulation.Text = "Simulation"
        Me.C_Simulation.UseVisualStyleBackColor = True
        '
        'C_GotoNorth
        '
        Me.C_GotoNorth.Location = New System.Drawing.Point(653, 73)
        Me.C_GotoNorth.Name = "C_GotoNorth"
        Me.C_GotoNorth.Size = New System.Drawing.Size(143, 48)
        Me.C_GotoNorth.TabIndex = 4
        Me.C_GotoNorth.Text = "Goto Noth"
        Me.C_GotoNorth.UseVisualStyleBackColor = True
        '
        'C_GetAlt
        '
        Me.C_GetAlt.Location = New System.Drawing.Point(239, 127)
        Me.C_GetAlt.Name = "C_GetAlt"
        Me.C_GetAlt.Size = New System.Drawing.Size(143, 51)
        Me.C_GetAlt.TabIndex = 5
        Me.C_GetAlt.Text = "Get Alt"
        Me.C_GetAlt.UseVisualStyleBackColor = True
        '
        'C_GetAz
        '
        Me.C_GetAz.Location = New System.Drawing.Point(239, 73)
        Me.C_GetAz.Name = "C_GetAz"
        Me.C_GetAz.Size = New System.Drawing.Size(143, 48)
        Me.C_GetAz.TabIndex = 6
        Me.C_GetAz.Text = "Get Az"
        Me.C_GetAz.UseVisualStyleBackColor = True
        '
        'C_SetBacklAlt
        '
        Me.C_SetBacklAlt.Location = New System.Drawing.Point(32, 238)
        Me.C_SetBacklAlt.Name = "C_SetBacklAlt"
        Me.C_SetBacklAlt.Size = New System.Drawing.Size(143, 49)
        Me.C_SetBacklAlt.TabIndex = 7
        Me.C_SetBacklAlt.Text = "Set Backl. Alt"
        Me.C_SetBacklAlt.UseVisualStyleBackColor = True
        '
        'C_SetBacklAz
        '
        Me.C_SetBacklAz.Location = New System.Drawing.Point(32, 184)
        Me.C_SetBacklAz.Name = "C_SetBacklAz"
        Me.C_SetBacklAz.Size = New System.Drawing.Size(143, 48)
        Me.C_SetBacklAz.TabIndex = 8
        Me.C_SetBacklAz.Text = "Set Backl. Az"
        Me.C_SetBacklAz.UseVisualStyleBackColor = True
        '
        'C_SetEncoder_Alt
        '
        Me.C_SetEncoder_Alt.Location = New System.Drawing.Point(32, 127)
        Me.C_SetEncoder_Alt.Name = "C_SetEncoder_Alt"
        Me.C_SetEncoder_Alt.Size = New System.Drawing.Size(143, 51)
        Me.C_SetEncoder_Alt.TabIndex = 9
        Me.C_SetEncoder_Alt.Text = "Set Enc. Alt"
        Me.C_SetEncoder_Alt.UseVisualStyleBackColor = True
        '
        'T_Backlash
        '
        Me.T_Backlash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_Backlash.Location = New System.Drawing.Point(239, 193)
        Me.T_Backlash.MinimumSize = New System.Drawing.Size(143, 2)
        Me.T_Backlash.Name = "T_Backlash"
        Me.T_Backlash.Size = New System.Drawing.Size(143, 31)
        Me.T_Backlash.TabIndex = 10
        Me.T_Backlash.Text = "40"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(696, 860)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 25)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Slewing Speed"
        '
        'L_SlewingSpeedX
        '
        Me.L_SlewingSpeedX.AutoSize = True
        Me.L_SlewingSpeedX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_SlewingSpeedX.Location = New System.Drawing.Point(701, 900)
        Me.L_SlewingSpeedX.Name = "L_SlewingSpeedX"
        Me.L_SlewingSpeedX.Size = New System.Drawing.Size(79, 27)
        Me.L_SlewingSpeedX.TabIndex = 13
        Me.L_SlewingSpeedX.Text = "Label3"
        '
        'C_Up
        '
        Me.C_Up.Location = New System.Drawing.Point(546, 616)
        Me.C_Up.Name = "C_Up"
        Me.C_Up.Size = New System.Drawing.Size(111, 59)
        Me.C_Up.TabIndex = 18
        Me.C_Up.Text = "^"
        Me.C_Up.UseVisualStyleBackColor = True
        '
        'C_Dn
        '
        Me.C_Dn.Location = New System.Drawing.Point(546, 752)
        Me.C_Dn.Name = "C_Dn"
        Me.C_Dn.Size = New System.Drawing.Size(111, 59)
        Me.C_Dn.TabIndex = 19
        Me.C_Dn.Text = "V"
        Me.C_Dn.UseVisualStyleBackColor = True
        '
        'C_Le
        '
        Me.C_Le.Location = New System.Drawing.Point(433, 682)
        Me.C_Le.Name = "C_Le"
        Me.C_Le.Size = New System.Drawing.Size(111, 59)
        Me.C_Le.TabIndex = 20
        Me.C_Le.Text = "<"
        Me.C_Le.UseVisualStyleBackColor = True
        '
        'C_Ri
        '
        Me.C_Ri.Location = New System.Drawing.Point(658, 682)
        Me.C_Ri.Name = "C_Ri"
        Me.C_Ri.Size = New System.Drawing.Size(111, 59)
        Me.C_Ri.TabIndex = 21
        Me.C_Ri.Text = ">"
        Me.C_Ri.UseVisualStyleBackColor = True
        '
        'VS_ManualSlewingSpeed
        '
        Me.VS_ManualSlewingSpeed.LargeChange = 100
        Me.VS_ManualSlewingSpeed.Location = New System.Drawing.Point(802, 524)
        Me.VS_ManualSlewingSpeed.Maximum = 10000
        Me.VS_ManualSlewingSpeed.Name = "VS_ManualSlewingSpeed"
        Me.VS_ManualSlewingSpeed.Size = New System.Drawing.Size(40, 295)
        Me.VS_ManualSlewingSpeed.TabIndex = 22
        Me.VS_ManualSlewingSpeed.Value = 100
        '
        'L_Angle
        '
        Me.L_Angle.AutoSize = True
        Me.L_Angle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Angle.Location = New System.Drawing.Point(1694, 1199)
        Me.L_Angle.Name = "L_Angle"
        Me.L_Angle.Size = New System.Drawing.Size(28, 27)
        Me.L_Angle.TabIndex = 23
        Me.L_Angle.Text = "--"
        '
        'L_SlewingSpeedY
        '
        Me.L_SlewingSpeedY.AutoSize = True
        Me.L_SlewingSpeedY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_SlewingSpeedY.Location = New System.Drawing.Point(701, 927)
        Me.L_SlewingSpeedY.Name = "L_SlewingSpeedY"
        Me.L_SlewingSpeedY.Size = New System.Drawing.Size(79, 27)
        Me.L_SlewingSpeedY.TabIndex = 24
        Me.L_SlewingSpeedY.Text = "Label4"
        '
        'AlignmentStarList
        '
        Me.AlignmentStarList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlignmentStarList.FormattingEnabled = True
        Me.AlignmentStarList.ItemHeight = 37
        Me.AlignmentStarList.Location = New System.Drawing.Point(870, 131)
        Me.AlignmentStarList.Name = "AlignmentStarList"
        Me.AlignmentStarList.Size = New System.Drawing.Size(205, 929)
        Me.AlignmentStarList.Sorted = True
        Me.AlignmentStarList.TabIndex = 25
        '
        'C_GotoStar
        '
        Me.C_GotoStar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C_GotoStar.Location = New System.Drawing.Point(754, 1255)
        Me.C_GotoStar.Name = "C_GotoStar"
        Me.C_GotoStar.Size = New System.Drawing.Size(384, 93)
        Me.C_GotoStar.TabIndex = 26
        Me.C_GotoStar.Text = "Goto Star "
        Me.C_GotoStar.UseVisualStyleBackColor = True
        '
        'C_SingleStarCalib
        '
        Me.C_SingleStarCalib.Location = New System.Drawing.Point(1605, 422)
        Me.C_SingleStarCalib.Name = "C_SingleStarCalib"
        Me.C_SingleStarCalib.Size = New System.Drawing.Size(401, 215)
        Me.C_SingleStarCalib.TabIndex = 28
        Me.C_SingleStarCalib.Text = "Single Star Alignment"
        Me.C_SingleStarCalib.UseVisualStyleBackColor = True
        '
        'C_SetCalibrationStar_2
        '
        Me.C_SetCalibrationStar_2.Location = New System.Drawing.Point(1605, 643)
        Me.C_SetCalibrationStar_2.Name = "C_SetCalibrationStar_2"
        Me.C_SetCalibrationStar_2.Size = New System.Drawing.Size(401, 221)
        Me.C_SetCalibrationStar_2.TabIndex = 30
        Me.C_SetCalibrationStar_2.Text = "Set Calibration Star 2"
        Me.C_SetCalibrationStar_2.UseVisualStyleBackColor = True
        '
        'C_Set_ObserverLocation
        '
        Me.C_Set_ObserverLocation.Location = New System.Drawing.Point(117, 1298)
        Me.C_Set_ObserverLocation.Name = "C_Set_ObserverLocation"
        Me.C_Set_ObserverLocation.Size = New System.Drawing.Size(265, 41)
        Me.C_Set_ObserverLocation.TabIndex = 31
        Me.C_Set_ObserverLocation.Text = "Set Observers Location"
        Me.C_Set_ObserverLocation.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1604, 1201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 25)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Angle"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(710, 1189)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 25)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Ortszeit [UT]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(168, 1158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 25)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Monat"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(254, 1158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 25)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Jahr"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(428, 1158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 25)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "H"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(511, 1158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 25)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "M"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(599, 1158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 25)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "S"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(83, 1158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 25)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Tag"
        '
        'T_Monat
        '
        Me.T_Monat.Location = New System.Drawing.Point(173, 1186)
        Me.T_Monat.Name = "T_Monat"
        Me.T_Monat.Size = New System.Drawing.Size(61, 31)
        Me.T_Monat.TabIndex = 39
        '
        'T_Jahr
        '
        Me.T_Jahr.Location = New System.Drawing.Point(259, 1186)
        Me.T_Jahr.Name = "T_Jahr"
        Me.T_Jahr.Size = New System.Drawing.Size(61, 31)
        Me.T_Jahr.TabIndex = 38
        '
        'T_Stunden
        '
        Me.T_Stunden.Location = New System.Drawing.Point(433, 1186)
        Me.T_Stunden.Name = "T_Stunden"
        Me.T_Stunden.Size = New System.Drawing.Size(61, 31)
        Me.T_Stunden.TabIndex = 37
        '
        'T_Minuten
        '
        Me.T_Minuten.Location = New System.Drawing.Point(517, 1186)
        Me.T_Minuten.Name = "T_Minuten"
        Me.T_Minuten.Size = New System.Drawing.Size(61, 31)
        Me.T_Minuten.TabIndex = 36
        '
        'T_Sekunden
        '
        Me.T_Sekunden.Location = New System.Drawing.Point(604, 1186)
        Me.T_Sekunden.Name = "T_Sekunden"
        Me.T_Sekunden.Size = New System.Drawing.Size(61, 31)
        Me.T_Sekunden.TabIndex = 35
        '
        'T_Tag
        '
        Me.T_Tag.Location = New System.Drawing.Point(88, 1186)
        Me.T_Tag.Name = "T_Tag"
        Me.T_Tag.Size = New System.Drawing.Size(61, 31)
        Me.T_Tag.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(168, 1227)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 25)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Min."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(254, 1227)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 25)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Sek."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(428, 1227)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 25)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Grad"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(511, 1227)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 25)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Min."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(599, 1227)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 25)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Sek."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(83, 1227)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 25)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "Grad"
        '
        'T_Latt_Min
        '
        Me.T_Latt_Min.Location = New System.Drawing.Point(173, 1255)
        Me.T_Latt_Min.Name = "T_Latt_Min"
        Me.T_Latt_Min.Size = New System.Drawing.Size(61, 31)
        Me.T_Latt_Min.TabIndex = 52
        '
        'T_Latt_Sek
        '
        Me.T_Latt_Sek.Location = New System.Drawing.Point(259, 1255)
        Me.T_Latt_Sek.Name = "T_Latt_Sek"
        Me.T_Latt_Sek.Size = New System.Drawing.Size(61, 31)
        Me.T_Latt_Sek.TabIndex = 51
        '
        'T_Long_Grad
        '
        Me.T_Long_Grad.Location = New System.Drawing.Point(433, 1255)
        Me.T_Long_Grad.Name = "T_Long_Grad"
        Me.T_Long_Grad.Size = New System.Drawing.Size(61, 31)
        Me.T_Long_Grad.TabIndex = 50
        '
        'T_Long_Min
        '
        Me.T_Long_Min.Location = New System.Drawing.Point(517, 1255)
        Me.T_Long_Min.Name = "T_Long_Min"
        Me.T_Long_Min.Size = New System.Drawing.Size(61, 31)
        Me.T_Long_Min.TabIndex = 49
        '
        'T_Long_Sek
        '
        Me.T_Long_Sek.Location = New System.Drawing.Point(604, 1255)
        Me.T_Long_Sek.Name = "T_Long_Sek"
        Me.T_Long_Sek.Size = New System.Drawing.Size(61, 31)
        Me.T_Long_Sek.TabIndex = 48
        '
        'T_Latt_Grad
        '
        Me.T_Latt_Grad.Location = New System.Drawing.Point(88, 1255)
        Me.T_Latt_Grad.Name = "T_Latt_Grad"
        Me.T_Latt_Grad.Size = New System.Drawing.Size(61, 31)
        Me.T_Latt_Grad.TabIndex = 47
        '
        'T_Latt_Sign
        '
        Me.T_Latt_Sign.Location = New System.Drawing.Point(12, 1252)
        Me.T_Latt_Sign.Name = "T_Latt_Sign"
        Me.T_Latt_Sign.Size = New System.Drawing.Size(61, 31)
        Me.T_Latt_Sign.TabIndex = 60
        '
        'T_Long_Sign
        '
        Me.T_Long_Sign.Location = New System.Drawing.Point(358, 1258)
        Me.T_Long_Sign.Name = "T_Long_Sign"
        Me.T_Long_Sign.Size = New System.Drawing.Size(61, 31)
        Me.T_Long_Sign.TabIndex = 61
        '
        'L_CurrentStar
        '
        Me.L_CurrentStar.AutoSize = True
        Me.L_CurrentStar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_CurrentStar.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_CurrentStar.Location = New System.Drawing.Point(882, 1136)
        Me.L_CurrentStar.Name = "L_CurrentStar"
        Me.L_CurrentStar.Size = New System.Drawing.Size(139, 44)
        Me.L_CurrentStar.TabIndex = 62
        Me.L_CurrentStar.Text = "Label3"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.O_TimeSelectSim)
        Me.GroupBox1.Controls.Add(Me.O_TimeSelectLocal)
        Me.GroupBox1.Controls.Add(Me.L_UTime)
        Me.GroupBox1.Controls.Add(Me.L_SiderialTime)
        Me.GroupBox1.Controls.Add(Me.L_LocalTime)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 293)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 219)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Time"
        '
        'O_TimeSelectSim
        '
        Me.O_TimeSelectSim.AutoSize = True
        Me.O_TimeSelectSim.Location = New System.Drawing.Point(241, 178)
        Me.O_TimeSelectSim.Name = "O_TimeSelectSim"
        Me.O_TimeSelectSim.Size = New System.Drawing.Size(180, 29)
        Me.O_TimeSelectSim.TabIndex = 22
        Me.O_TimeSelectSim.TabStop = True
        Me.O_TimeSelectSim.Text = "Simulierte Zeit"
        Me.O_TimeSelectSim.UseVisualStyleBackColor = True
        '
        'O_TimeSelectLocal
        '
        Me.O_TimeSelectLocal.AutoSize = True
        Me.O_TimeSelectLocal.Location = New System.Drawing.Point(34, 178)
        Me.O_TimeSelectLocal.Name = "O_TimeSelectLocal"
        Me.O_TimeSelectLocal.Size = New System.Drawing.Size(129, 29)
        Me.O_TimeSelectLocal.TabIndex = 21
        Me.O_TimeSelectLocal.TabStop = True
        Me.O_TimeSelectLocal.Text = "Lokalzeit"
        Me.O_TimeSelectLocal.UseVisualStyleBackColor = True
        '
        'L_UTime
        '
        Me.L_UTime.AutoSize = True
        Me.L_UTime.Location = New System.Drawing.Point(29, 84)
        Me.L_UTime.Name = "L_UTime"
        Me.L_UTime.Size = New System.Drawing.Size(40, 25)
        Me.L_UTime.TabIndex = 20
        Me.L_UTime.Text = "UT"
        '
        'L_SiderialTime
        '
        Me.L_SiderialTime.AutoSize = True
        Me.L_SiderialTime.Location = New System.Drawing.Point(29, 127)
        Me.L_SiderialTime.Name = "L_SiderialTime"
        Me.L_SiderialTime.Size = New System.Drawing.Size(137, 25)
        Me.L_SiderialTime.TabIndex = 19
        Me.L_SiderialTime.Text = "Siderial Time"
        '
        'L_LocalTime
        '
        Me.L_LocalTime.AutoSize = True
        Me.L_LocalTime.Location = New System.Drawing.Point(29, 43)
        Me.L_LocalTime.Name = "L_LocalTime"
        Me.L_LocalTime.Size = New System.Drawing.Size(117, 25)
        Me.L_LocalTime.TabIndex = 18
        Me.L_LocalTime.Text = "Local Time"
        '
        'F_StarInfo
        '
        Me.F_StarInfo.Controls.Add(Me.L_CardinalOrientation)
        Me.F_StarInfo.Controls.Add(Me.L_I_HorXYZ)
        Me.F_StarInfo.Controls.Add(Me.Label29)
        Me.F_StarInfo.Controls.Add(Me.L_I_EquXYZ)
        Me.F_StarInfo.Controls.Add(Me.Label27)
        Me.F_StarInfo.Controls.Add(Me.L_I_HourAngle)
        Me.F_StarInfo.Controls.Add(Me.Label25)
        Me.F_StarInfo.Controls.Add(Me.L_I_Alt)
        Me.F_StarInfo.Controls.Add(Me.Label23)
        Me.F_StarInfo.Controls.Add(Me.L_I_Az)
        Me.F_StarInfo.Controls.Add(Me.Label21)
        Me.F_StarInfo.Controls.Add(Me.L_I_DEC)
        Me.F_StarInfo.Controls.Add(Me.Label19)
        Me.F_StarInfo.Controls.Add(Me.L_I_RA)
        Me.F_StarInfo.Controls.Add(Me.Label9)
        Me.F_StarInfo.Location = New System.Drawing.Point(1100, 57)
        Me.F_StarInfo.Name = "F_StarInfo"
        Me.F_StarInfo.Size = New System.Drawing.Size(409, 359)
        Me.F_StarInfo.TabIndex = 64
        Me.F_StarInfo.TabStop = False
        Me.F_StarInfo.Text = "--"
        '
        'L_CardinalOrientation
        '
        Me.L_CardinalOrientation.AutoSize = True
        Me.L_CardinalOrientation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_CardinalOrientation.Location = New System.Drawing.Point(341, 127)
        Me.L_CardinalOrientation.Name = "L_CardinalOrientation"
        Me.L_CardinalOrientation.Size = New System.Drawing.Size(28, 27)
        Me.L_CardinalOrientation.TabIndex = 74
        Me.L_CardinalOrientation.Text = "--"
        '
        'L_I_HorXYZ
        '
        Me.L_I_HorXYZ.AutoSize = True
        Me.L_I_HorXYZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_HorXYZ.Location = New System.Drawing.Point(149, 296)
        Me.L_I_HorXYZ.MinimumSize = New System.Drawing.Size(250, 2)
        Me.L_I_HorXYZ.Name = "L_I_HorXYZ"
        Me.L_I_HorXYZ.Size = New System.Drawing.Size(250, 27)
        Me.L_I_HorXYZ.TabIndex = 26
        Me.L_I_HorXYZ.Text = "--"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(24, 298)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 25)
        Me.Label29.TabIndex = 25
        Me.Label29.Text = "Hroz. xyz:"
        '
        'L_I_EquXYZ
        '
        Me.L_I_EquXYZ.AutoSize = True
        Me.L_I_EquXYZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_EquXYZ.Location = New System.Drawing.Point(149, 262)
        Me.L_I_EquXYZ.MinimumSize = New System.Drawing.Size(250, 2)
        Me.L_I_EquXYZ.Name = "L_I_EquXYZ"
        Me.L_I_EquXYZ.Size = New System.Drawing.Size(250, 27)
        Me.L_I_EquXYZ.TabIndex = 24
        Me.L_I_EquXYZ.Text = "--"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(24, 262)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(95, 25)
        Me.Label27.TabIndex = 23
        Me.Label27.Text = "Equ xyz:"
        '
        'L_I_HourAngle
        '
        Me.L_I_HourAngle.AutoSize = True
        Me.L_I_HourAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_HourAngle.Location = New System.Drawing.Point(149, 207)
        Me.L_I_HourAngle.MinimumSize = New System.Drawing.Size(150, 2)
        Me.L_I_HourAngle.Name = "L_I_HourAngle"
        Me.L_I_HourAngle.Size = New System.Drawing.Size(150, 27)
        Me.L_I_HourAngle.TabIndex = 22
        Me.L_I_HourAngle.Text = "--"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(24, 207)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(119, 25)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Hour Angle"
        '
        'L_I_Alt
        '
        Me.L_I_Alt.AutoSize = True
        Me.L_I_Alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_Alt.Location = New System.Drawing.Point(149, 161)
        Me.L_I_Alt.MinimumSize = New System.Drawing.Size(150, 2)
        Me.L_I_Alt.Name = "L_I_Alt"
        Me.L_I_Alt.Size = New System.Drawing.Size(150, 27)
        Me.L_I_Alt.TabIndex = 20
        Me.L_I_Alt.Text = "--"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(24, 161)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 25)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Alt:"
        '
        'L_I_Az
        '
        Me.L_I_Az.AutoSize = True
        Me.L_I_Az.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_Az.Location = New System.Drawing.Point(149, 127)
        Me.L_I_Az.MinimumSize = New System.Drawing.Size(150, 2)
        Me.L_I_Az.Name = "L_I_Az"
        Me.L_I_Az.Size = New System.Drawing.Size(150, 27)
        Me.L_I_Az.TabIndex = 18
        Me.L_I_Az.Text = "--"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(24, 127)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 25)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Az:"
        '
        'L_I_DEC
        '
        Me.L_I_DEC.AutoSize = True
        Me.L_I_DEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_DEC.Location = New System.Drawing.Point(149, 80)
        Me.L_I_DEC.MinimumSize = New System.Drawing.Size(250, 2)
        Me.L_I_DEC.Name = "L_I_DEC"
        Me.L_I_DEC.Size = New System.Drawing.Size(250, 27)
        Me.L_I_DEC.TabIndex = 16
        Me.L_I_DEC.Text = "--"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(24, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 25)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "DEC:"
        '
        'L_I_RA
        '
        Me.L_I_RA.AutoSize = True
        Me.L_I_RA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_I_RA.Location = New System.Drawing.Point(149, 50)
        Me.L_I_RA.MinimumSize = New System.Drawing.Size(250, 2)
        Me.L_I_RA.Name = "L_I_RA"
        Me.L_I_RA.Size = New System.Drawing.Size(250, 27)
        Me.L_I_RA.TabIndex = 14
        Me.L_I_RA.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 25)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "RA:"
        '
        'F_PreviewInfo
        '
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_CardinalOrientation)
        Me.F_PreviewInfo.Controls.Add(Me.Ch_South)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_HorXYZ)
        Me.F_PreviewInfo.Controls.Add(Me.Label18)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_EquXYZ)
        Me.F_PreviewInfo.Controls.Add(Me.Label22)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_HourAngle)
        Me.F_PreviewInfo.Controls.Add(Me.Label26)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_Alt)
        Me.F_PreviewInfo.Controls.Add(Me.Label30)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_Az)
        Me.F_PreviewInfo.Controls.Add(Me.Label32)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_DEC)
        Me.F_PreviewInfo.Controls.Add(Me.Label34)
        Me.F_PreviewInfo.Controls.Add(Me.L_Preview_RA)
        Me.F_PreviewInfo.Controls.Add(Me.Label36)
        Me.F_PreviewInfo.Location = New System.Drawing.Point(1546, 57)
        Me.F_PreviewInfo.Name = "F_PreviewInfo"
        Me.F_PreviewInfo.Size = New System.Drawing.Size(372, 359)
        Me.F_PreviewInfo.TabIndex = 65
        Me.F_PreviewInfo.TabStop = False
        Me.F_PreviewInfo.Text = "--"
        '
        'L_Preview_CardinalOrientation
        '
        Me.L_Preview_CardinalOrientation.AutoSize = True
        Me.L_Preview_CardinalOrientation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_CardinalOrientation.Location = New System.Drawing.Point(264, 135)
        Me.L_Preview_CardinalOrientation.Name = "L_Preview_CardinalOrientation"
        Me.L_Preview_CardinalOrientation.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_CardinalOrientation.TabIndex = 73
        Me.L_Preview_CardinalOrientation.Text = "--"
        '
        'Ch_South
        '
        Me.Ch_South.AutoSize = True
        Me.Ch_South.Location = New System.Drawing.Point(203, 22)
        Me.Ch_South.Name = "Ch_South"
        Me.Ch_South.Size = New System.Drawing.Size(170, 29)
        Me.Ch_South.TabIndex = 72
        Me.Ch_South.Text = "South (VSky)"
        Me.Ch_South.UseVisualStyleBackColor = True
        '
        'L_Preview_HorXYZ
        '
        Me.L_Preview_HorXYZ.AutoSize = True
        Me.L_Preview_HorXYZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_HorXYZ.Location = New System.Drawing.Point(169, 296)
        Me.L_Preview_HorXYZ.Name = "L_Preview_HorXYZ"
        Me.L_Preview_HorXYZ.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_HorXYZ.TabIndex = 26
        Me.L_Preview_HorXYZ.Text = "--"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(24, 296)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 25)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Hroz. xyz:"
        '
        'L_Preview_EquXYZ
        '
        Me.L_Preview_EquXYZ.AutoSize = True
        Me.L_Preview_EquXYZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_EquXYZ.Location = New System.Drawing.Point(169, 262)
        Me.L_Preview_EquXYZ.Name = "L_Preview_EquXYZ"
        Me.L_Preview_EquXYZ.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_EquXYZ.TabIndex = 24
        Me.L_Preview_EquXYZ.Text = "--"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(24, 262)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 25)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Equ xyz:"
        '
        'L_Preview_HourAngle
        '
        Me.L_Preview_HourAngle.AutoSize = True
        Me.L_Preview_HourAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_HourAngle.Location = New System.Drawing.Point(169, 207)
        Me.L_Preview_HourAngle.Name = "L_Preview_HourAngle"
        Me.L_Preview_HourAngle.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_HourAngle.TabIndex = 22
        Me.L_Preview_HourAngle.Text = "--"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(24, 207)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(119, 25)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Hour Angle"
        '
        'L_Preview_Alt
        '
        Me.L_Preview_Alt.AutoSize = True
        Me.L_Preview_Alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_Alt.Location = New System.Drawing.Point(169, 161)
        Me.L_Preview_Alt.Name = "L_Preview_Alt"
        Me.L_Preview_Alt.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_Alt.TabIndex = 20
        Me.L_Preview_Alt.Text = "--"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(24, 161)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(43, 25)
        Me.Label30.TabIndex = 19
        Me.Label30.Text = "Alt:"
        '
        'L_Preview_Az
        '
        Me.L_Preview_Az.AutoSize = True
        Me.L_Preview_Az.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_Az.Location = New System.Drawing.Point(169, 127)
        Me.L_Preview_Az.Name = "L_Preview_Az"
        Me.L_Preview_Az.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_Az.TabIndex = 18
        Me.L_Preview_Az.Text = "--"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(24, 127)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(43, 25)
        Me.Label32.TabIndex = 17
        Me.Label32.Text = "Az:"
        '
        'L_Preview_DEC
        '
        Me.L_Preview_DEC.AutoSize = True
        Me.L_Preview_DEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_DEC.Location = New System.Drawing.Point(169, 80)
        Me.L_Preview_DEC.Name = "L_Preview_DEC"
        Me.L_Preview_DEC.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_DEC.TabIndex = 16
        Me.L_Preview_DEC.Text = "--"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(24, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(62, 25)
        Me.Label34.TabIndex = 15
        Me.Label34.Text = "DEC:"
        '
        'L_Preview_RA
        '
        Me.L_Preview_RA.AutoSize = True
        Me.L_Preview_RA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Preview_RA.Location = New System.Drawing.Point(169, 50)
        Me.L_Preview_RA.Name = "L_Preview_RA"
        Me.L_Preview_RA.Size = New System.Drawing.Size(28, 27)
        Me.L_Preview_RA.TabIndex = 14
        Me.L_Preview_RA.Text = "--"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(24, 50)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(47, 25)
        Me.Label36.TabIndex = 13
        Me.Label36.Text = "RA:"
        '
        'C_Tracking
        '
        Me.C_Tracking.Location = New System.Drawing.Point(1605, 870)
        Me.C_Tracking.Name = "C_Tracking"
        Me.C_Tracking.Size = New System.Drawing.Size(401, 313)
        Me.C_Tracking.TabIndex = 66
        Me.C_Tracking.Text = "Tracking"
        Me.C_Tracking.UseVisualStyleBackColor = True
        '
        'MSComm1
        '
        Me.MSComm1.BaudRate = 4800
        Me.MSComm1.PortName = "COM8"
        '
        'LoadStarKatalogDialog
        '
        Me.LoadStarKatalogDialog.FileName = "OpenFileDialog1"
        '
        'Tim_DisplayUpdate
        '
        Me.Tim_DisplayUpdate.Enabled = True
        Me.Tim_DisplayUpdate.Interval = 250
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.L_MotorSystemAzDiff)
        Me.GroupBox2.Controls.Add(Me.L_MatrixSystemAzDiff)
        Me.GroupBox2.Controls.Add(Me.L_AzMotorIncr)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.L_MatrixSystemAzIst)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.L_AzAltSystem)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.L_MatrixSystemAzSoll)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.L_GlobalAzOffset)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Location = New System.Drawing.Point(1100, 422)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(409, 236)
        Me.GroupBox2.TabIndex = 65
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Azimut"
        '
        'L_MotorSystemAzDiff
        '
        Me.L_MotorSystemAzDiff.AutoSize = True
        Me.L_MotorSystemAzDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MotorSystemAzDiff.Location = New System.Drawing.Point(278, 177)
        Me.L_MotorSystemAzDiff.Name = "L_MotorSystemAzDiff"
        Me.L_MotorSystemAzDiff.Size = New System.Drawing.Size(28, 27)
        Me.L_MotorSystemAzDiff.TabIndex = 24
        Me.L_MotorSystemAzDiff.Text = "--"
        '
        'L_MatrixSystemAzDiff
        '
        Me.L_MatrixSystemAzDiff.AutoSize = True
        Me.L_MatrixSystemAzDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAzDiff.Location = New System.Drawing.Point(278, 80)
        Me.L_MatrixSystemAzDiff.Name = "L_MatrixSystemAzDiff"
        Me.L_MatrixSystemAzDiff.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAzDiff.TabIndex = 23
        Me.L_MatrixSystemAzDiff.Text = "--"
        '
        'L_AzMotorIncr
        '
        Me.L_AzMotorIncr.AutoSize = True
        Me.L_AzMotorIncr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_AzMotorIncr.Location = New System.Drawing.Point(171, 179)
        Me.L_AzMotorIncr.Name = "L_AzMotorIncr"
        Me.L_AzMotorIncr.Size = New System.Drawing.Size(28, 27)
        Me.L_AzMotorIncr.TabIndex = 22
        Me.L_AzMotorIncr.Text = "--"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(29, 179)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(108, 25)
        Me.Label33.TabIndex = 21
        Me.Label33.Text = "Motor Incr"
        '
        'L_MatrixSystemAzIst
        '
        Me.L_MatrixSystemAzIst.AutoSize = True
        Me.L_MatrixSystemAzIst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAzIst.Location = New System.Drawing.Point(169, 142)
        Me.L_MatrixSystemAzIst.Name = "L_MatrixSystemAzIst"
        Me.L_MatrixSystemAzIst.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAzIst.TabIndex = 20
        Me.L_MatrixSystemAzIst.Text = "--"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(28, 144)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(141, 25)
        Me.Label37.TabIndex = 19
        Me.Label37.Text = "Matrix Sys Ist"
        '
        'L_AzAltSystem
        '
        Me.L_AzAltSystem.AutoSize = True
        Me.L_AzAltSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_AzAltSystem.Location = New System.Drawing.Point(169, 113)
        Me.L_AzAltSystem.Name = "L_AzAltSystem"
        Me.L_AzAltSystem.Size = New System.Drawing.Size(28, 27)
        Me.L_AzAltSystem.TabIndex = 18
        Me.L_AzAltSystem.Text = "--"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(28, 113)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(104, 25)
        Me.Label39.TabIndex = 17
        Me.Label39.Text = "AzAlt Sys"
        '
        'L_MatrixSystemAzSoll
        '
        Me.L_MatrixSystemAzSoll.AutoSize = True
        Me.L_MatrixSystemAzSoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAzSoll.Location = New System.Drawing.Point(169, 80)
        Me.L_MatrixSystemAzSoll.Name = "L_MatrixSystemAzSoll"
        Me.L_MatrixSystemAzSoll.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAzSoll.TabIndex = 16
        Me.L_MatrixSystemAzSoll.Text = "--"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(24, 80)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(113, 25)
        Me.Label41.TabIndex = 15
        Me.Label41.Text = "Matrix Soll"
        '
        'L_GlobalAzOffset
        '
        Me.L_GlobalAzOffset.AutoSize = True
        Me.L_GlobalAzOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_GlobalAzOffset.Location = New System.Drawing.Point(169, 50)
        Me.L_GlobalAzOffset.Name = "L_GlobalAzOffset"
        Me.L_GlobalAzOffset.Size = New System.Drawing.Size(28, 27)
        Me.L_GlobalAzOffset.TabIndex = 14
        Me.L_GlobalAzOffset.Text = "--"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(24, 50)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(114, 25)
        Me.Label43.TabIndex = 13
        Me.Label43.Text = "Glob. Offs:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.L_MotorSystemAltDiff)
        Me.GroupBox3.Controls.Add(Me.L_MatrixSystemAltDiff)
        Me.GroupBox3.Controls.Add(Me.L_AltMotorIncr)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.L_MatrixSystemAltIst)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.L_MatrixSystemAltSoll)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.L_GlobalAltOffset)
        Me.GroupBox3.Controls.Add(Me.Label44)
        Me.GroupBox3.Location = New System.Drawing.Point(1100, 679)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(372, 236)
        Me.GroupBox3.TabIndex = 66
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Altitude"
        '
        'L_MotorSystemAltDiff
        '
        Me.L_MotorSystemAltDiff.AutoSize = True
        Me.L_MotorSystemAltDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MotorSystemAltDiff.Location = New System.Drawing.Point(278, 179)
        Me.L_MotorSystemAltDiff.Name = "L_MotorSystemAltDiff"
        Me.L_MotorSystemAltDiff.Size = New System.Drawing.Size(28, 27)
        Me.L_MotorSystemAltDiff.TabIndex = 24
        Me.L_MotorSystemAltDiff.Text = "--"
        '
        'L_MatrixSystemAltDiff
        '
        Me.L_MatrixSystemAltDiff.AutoSize = True
        Me.L_MatrixSystemAltDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAltDiff.Location = New System.Drawing.Point(278, 80)
        Me.L_MatrixSystemAltDiff.Name = "L_MatrixSystemAltDiff"
        Me.L_MatrixSystemAltDiff.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAltDiff.TabIndex = 23
        Me.L_MatrixSystemAltDiff.Text = "--"
        '
        'L_AltMotorIncr
        '
        Me.L_AltMotorIncr.AutoSize = True
        Me.L_AltMotorIncr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_AltMotorIncr.Location = New System.Drawing.Point(171, 179)
        Me.L_AltMotorIncr.Name = "L_AltMotorIncr"
        Me.L_AltMotorIncr.Size = New System.Drawing.Size(28, 27)
        Me.L_AltMotorIncr.TabIndex = 22
        Me.L_AltMotorIncr.Text = "--"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 179)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 25)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Motor Incr"
        '
        'L_MatrixSystemAltIst
        '
        Me.L_MatrixSystemAltIst.AutoSize = True
        Me.L_MatrixSystemAltIst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAltIst.Location = New System.Drawing.Point(169, 142)
        Me.L_MatrixSystemAltIst.Name = "L_MatrixSystemAltIst"
        Me.L_MatrixSystemAltIst.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAltIst.TabIndex = 20
        Me.L_MatrixSystemAltIst.Text = "--"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(28, 144)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(141, 25)
        Me.Label28.TabIndex = 19
        Me.Label28.Text = "Matrix Sys Ist"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Location = New System.Drawing.Point(169, 113)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(28, 27)
        Me.Label31.TabIndex = 18
        Me.Label31.Text = "--"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(28, 113)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(104, 25)
        Me.Label35.TabIndex = 17
        Me.Label35.Text = "AzAlt Sys"
        '
        'L_MatrixSystemAltSoll
        '
        Me.L_MatrixSystemAltSoll.AutoSize = True
        Me.L_MatrixSystemAltSoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAltSoll.Location = New System.Drawing.Point(169, 80)
        Me.L_MatrixSystemAltSoll.Name = "L_MatrixSystemAltSoll"
        Me.L_MatrixSystemAltSoll.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAltSoll.TabIndex = 16
        Me.L_MatrixSystemAltSoll.Text = "--"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(24, 80)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(113, 25)
        Me.Label40.TabIndex = 15
        Me.Label40.Text = "Matrix Soll"
        '
        'L_GlobalAltOffset
        '
        Me.L_GlobalAltOffset.AutoSize = True
        Me.L_GlobalAltOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_GlobalAltOffset.Location = New System.Drawing.Point(169, 50)
        Me.L_GlobalAltOffset.Name = "L_GlobalAltOffset"
        Me.L_GlobalAltOffset.Size = New System.Drawing.Size(28, 27)
        Me.L_GlobalAltOffset.TabIndex = 14
        Me.L_GlobalAltOffset.Text = "--"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(24, 50)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(114, 25)
        Me.Label44.TabIndex = 13
        Me.Label44.Text = "Glob. Offs:"
        '
        'L_MatrixSystemAzDiffReal
        '
        Me.L_MatrixSystemAzDiffReal.AutoSize = True
        Me.L_MatrixSystemAzDiffReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MatrixSystemAzDiffReal.Location = New System.Drawing.Point(1110, 1003)
        Me.L_MatrixSystemAzDiffReal.Name = "L_MatrixSystemAzDiffReal"
        Me.L_MatrixSystemAzDiffReal.Size = New System.Drawing.Size(28, 27)
        Me.L_MatrixSystemAzDiffReal.TabIndex = 67
        Me.L_MatrixSystemAzDiffReal.Text = "--"
        '
        'L_MotorSystemAzDiffReal
        '
        Me.L_MotorSystemAzDiffReal.AutoSize = True
        Me.L_MotorSystemAzDiffReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MotorSystemAzDiffReal.Location = New System.Drawing.Point(1110, 1043)
        Me.L_MotorSystemAzDiffReal.Name = "L_MotorSystemAzDiffReal"
        Me.L_MotorSystemAzDiffReal.Size = New System.Drawing.Size(28, 27)
        Me.L_MotorSystemAzDiffReal.TabIndex = 68
        Me.L_MotorSystemAzDiffReal.Text = "--"
        '
        'L_MotorSystemAzDiffSim
        '
        Me.L_MotorSystemAzDiffSim.AutoSize = True
        Me.L_MotorSystemAzDiffSim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_MotorSystemAzDiffSim.Location = New System.Drawing.Point(1110, 1081)
        Me.L_MotorSystemAzDiffSim.Name = "L_MotorSystemAzDiffSim"
        Me.L_MotorSystemAzDiffSim.Size = New System.Drawing.Size(28, 27)
        Me.L_MotorSystemAzDiffSim.TabIndex = 69
        Me.L_MotorSystemAzDiffSim.Text = "--"
        '
        'L_ErrorCount
        '
        Me.L_ErrorCount.AutoSize = True
        Me.L_ErrorCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_ErrorCount.Location = New System.Drawing.Point(1819, 1278)
        Me.L_ErrorCount.Name = "L_ErrorCount"
        Me.L_ErrorCount.Size = New System.Drawing.Size(28, 27)
        Me.L_ErrorCount.TabIndex = 70
        Me.L_ErrorCount.Text = "--"
        '
        'L_StatusMoving
        '
        Me.L_StatusMoving.AutoSize = True
        Me.L_StatusMoving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_StatusMoving.Location = New System.Drawing.Point(1617, 1278)
        Me.L_StatusMoving.Name = "L_StatusMoving"
        Me.L_StatusMoving.Size = New System.Drawing.Size(28, 27)
        Me.L_StatusMoving.TabIndex = 71
        Me.L_StatusMoving.Text = "--"
        '
        'Tim_Preview
        '
        Me.Tim_Preview.Enabled = True
        Me.Tim_Preview.Interval = 500
        '
        'Tim_Simulation
        '
        Me.Tim_Simulation.Enabled = True
        Me.Tim_Simulation.Interval = 500
        '
        'Tim_Startup
        '
        Me.Tim_Startup.Enabled = True
        Me.Tim_Startup.Interval = 500
        '
        'Tim_TestStatus
        '
        Me.Tim_TestStatus.Enabled = True
        Me.Tim_TestStatus.Interval = 1000
        '
        'Tim_Tracking
        '
        Me.Tim_Tracking.Enabled = True
        Me.Tim_Tracking.Interval = 500
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Location = New System.Drawing.Point(1110, 918)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 27)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "--"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Location = New System.Drawing.Point(1110, 953)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 27)
        Me.Label24.TabIndex = 73
        Me.Label24.Text = "--"
        '
        'Slider1
        '
        Me.Slider1.Location = New System.Drawing.Point(1165, 1150)
        Me.Slider1.Maximum = 2000
        Me.Slider1.Name = "Slider1"
        Me.Slider1.Size = New System.Drawing.Size(425, 10)
        Me.Slider1.TabIndex = 74
        '
        'Slider2
        '
        Me.Slider2.Location = New System.Drawing.Point(1165, 1173)
        Me.Slider2.Maximum = 2000
        Me.Slider2.Name = "Slider2"
        Me.Slider2.Size = New System.Drawing.Size(425, 10)
        Me.Slider2.TabIndex = 75
        '
        'T_Alt
        '
        Me.T_Alt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_Alt.Location = New System.Drawing.Point(398, 135)
        Me.T_Alt.MinimumSize = New System.Drawing.Size(143, 2)
        Me.T_Alt.Name = "T_Alt"
        Me.T_Alt.Size = New System.Drawing.Size(143, 31)
        Me.T_Alt.TabIndex = 79
        Me.T_Alt.Text = "--"
        '
        'T_Az
        '
        Me.T_Az.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.T_Az.Location = New System.Drawing.Point(398, 83)
        Me.T_Az.MinimumSize = New System.Drawing.Size(143, 2)
        Me.T_Az.Name = "T_Az"
        Me.T_Az.Size = New System.Drawing.Size(143, 31)
        Me.T_Az.TabIndex = 80
        Me.T_Az.Text = "--"
        '
        'L_ElapsedTime
        '
        Me.L_ElapsedTime.AutoSize = True
        Me.L_ElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_ElapsedTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.L_ElapsedTime.Location = New System.Drawing.Point(1165, 1199)
        Me.L_ElapsedTime.Name = "L_ElapsedTime"
        Me.L_ElapsedTime.Size = New System.Drawing.Size(28, 27)
        Me.L_ElapsedTime.TabIndex = 81
        Me.L_ElapsedTime.Text = "--"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(1362, 1123)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(24, 37)
        Me.Label42.TabIndex = 25
        Me.Label42.Text = "|"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(1362, 1173)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(24, 37)
        Me.Label45.TabIndex = 82
        Me.Label45.Text = "|"
        '
        'CB_Find
        '
        Me.CB_Find.FormattingEnabled = True
        Me.CB_Find.Location = New System.Drawing.Point(870, 73)
        Me.CB_Find.Name = "CB_Find"
        Me.CB_Find.Size = New System.Drawing.Size(205, 33)
        Me.CB_Find.TabIndex = 83
        '
        'Tim_Comm
        '
        Me.Tim_Comm.Enabled = True
        '
        'B_Comm
        '
        Me.B_Comm.Location = New System.Drawing.Point(653, 218)
        Me.B_Comm.Name = "B_Comm"
        Me.B_Comm.Size = New System.Drawing.Size(143, 51)
        Me.B_Comm.TabIndex = 85
        Me.B_Comm.Text = "Comm"
        Me.B_Comm.UseVisualStyleBackColor = True
        '
        'L_NumerOfCmd
        '
        Me.L_NumerOfCmd.AutoSize = True
        Me.L_NumerOfCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_NumerOfCmd.Location = New System.Drawing.Point(653, 282)
        Me.L_NumerOfCmd.Name = "L_NumerOfCmd"
        Me.L_NumerOfCmd.Size = New System.Drawing.Size(28, 27)
        Me.L_NumerOfCmd.TabIndex = 25
        Me.L_NumerOfCmd.Text = "--"
        '
        'OpenCursorDialog
        '
        Me.OpenCursorDialog.FileName = "OpenFileDialog1"
        '
        'B_SetCurrentPos
        '
        Me.B_SetCurrentPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_SetCurrentPos.Location = New System.Drawing.Point(433, 322)
        Me.B_SetCurrentPos.Name = "B_SetCurrentPos"
        Me.B_SetCurrentPos.Size = New System.Drawing.Size(384, 175)
        Me.B_SetCurrentPos.TabIndex = 86
        Me.B_SetCurrentPos.Text = "Set Current Position"
        Me.B_SetCurrentPos.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2042, 1382)
        Me.Controls.Add(Me.B_SetCurrentPos)
        Me.Controls.Add(Me.L_NumerOfCmd)
        Me.Controls.Add(Me.B_Comm)
        Me.Controls.Add(Me.CB_Find)
        Me.Controls.Add(Me.L_ElapsedTime)
        Me.Controls.Add(Me.T_Az)
        Me.Controls.Add(Me.T_Alt)
        Me.Controls.Add(Me.Slider2)
        Me.Controls.Add(Me.Slider1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.L_StatusMoving)
        Me.Controls.Add(Me.L_ErrorCount)
        Me.Controls.Add(Me.L_MotorSystemAzDiffSim)
        Me.Controls.Add(Me.L_MotorSystemAzDiffReal)
        Me.Controls.Add(Me.L_MatrixSystemAzDiffReal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.C_Tracking)
        Me.Controls.Add(Me.F_PreviewInfo)
        Me.Controls.Add(Me.F_StarInfo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.L_CurrentStar)
        Me.Controls.Add(Me.T_Long_Sign)
        Me.Controls.Add(Me.T_Latt_Sign)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.T_Latt_Min)
        Me.Controls.Add(Me.T_Latt_Sek)
        Me.Controls.Add(Me.T_Long_Grad)
        Me.Controls.Add(Me.T_Long_Min)
        Me.Controls.Add(Me.T_Long_Sek)
        Me.Controls.Add(Me.T_Latt_Grad)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.T_Monat)
        Me.Controls.Add(Me.T_Jahr)
        Me.Controls.Add(Me.T_Stunden)
        Me.Controls.Add(Me.T_Minuten)
        Me.Controls.Add(Me.T_Sekunden)
        Me.Controls.Add(Me.T_Tag)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.C_Set_ObserverLocation)
        Me.Controls.Add(Me.C_SetCalibrationStar_2)
        Me.Controls.Add(Me.C_SingleStarCalib)
        Me.Controls.Add(Me.C_GotoStar)
        Me.Controls.Add(Me.AlignmentStarList)
        Me.Controls.Add(Me.L_SlewingSpeedY)
        Me.Controls.Add(Me.L_Angle)
        Me.Controls.Add(Me.VS_ManualSlewingSpeed)
        Me.Controls.Add(Me.C_Ri)
        Me.Controls.Add(Me.C_Le)
        Me.Controls.Add(Me.C_Dn)
        Me.Controls.Add(Me.C_Up)
        Me.Controls.Add(Me.L_SlewingSpeedX)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_Backlash)
        Me.Controls.Add(Me.C_SetEncoder_Alt)
        Me.Controls.Add(Me.C_SetBacklAz)
        Me.Controls.Add(Me.C_SetBacklAlt)
        Me.Controls.Add(Me.C_GetAz)
        Me.Controls.Add(Me.C_GetAlt)
        Me.Controls.Add(Me.C_GotoNorth)
        Me.Controls.Add(Me.C_Simulation)
        Me.Controls.Add(Me.C_MoveTelescope)
        Me.Controls.Add(Me.C_SetEncoder_Az)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label42)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.F_StarInfo.ResumeLayout(False)
        Me.F_StarInfo.PerformLayout()
        Me.F_PreviewInfo.ResumeLayout(False)
        Me.F_PreviewInfo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TesteJulianischesDatumToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CovertToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CursorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VisualisierungToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommunicationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents C_SetEncoder_Az As Button
    Friend WithEvents C_MoveTelescope As Button
    Friend WithEvents C_Simulation As Button
    Friend WithEvents C_GotoNorth As Button
    Friend WithEvents C_GetAlt As Button
    Friend WithEvents C_GetAz As Button
    Friend WithEvents C_SetBacklAlt As Button
    Friend WithEvents C_SetBacklAz As Button
    Friend WithEvents C_SetEncoder_Alt As Button
    Friend WithEvents T_Backlash As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents L_SlewingSpeedX As Label
    Friend WithEvents C_Up As Button
    Friend WithEvents C_Dn As Button
    Friend WithEvents C_Le As Button
    Friend WithEvents C_Ri As Button
    Friend WithEvents VS_ManualSlewingSpeed As VScrollBar
    Friend WithEvents L_Angle As Label
    Friend WithEvents L_SlewingSpeedY As Label
    Friend WithEvents AlignmentStarList As ListBox
    Friend WithEvents C_GotoStar As Button
    Friend WithEvents C_SingleStarCalib As Button
    Friend WithEvents C_SetCalibrationStar_2 As Button
    Friend WithEvents C_Set_ObserverLocation As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents T_Monat As TextBox
    Friend WithEvents T_Jahr As TextBox
    Friend WithEvents T_Stunden As TextBox
    Friend WithEvents T_Minuten As TextBox
    Friend WithEvents T_Sekunden As TextBox
    Friend WithEvents T_Tag As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents T_Latt_Min As TextBox
    Friend WithEvents T_Latt_Sek As TextBox
    Friend WithEvents T_Long_Grad As TextBox
    Friend WithEvents T_Long_Min As TextBox
    Friend WithEvents T_Long_Sek As TextBox
    Friend WithEvents T_Latt_Grad As TextBox
    Friend WithEvents T_Latt_Sign As TextBox
    Friend WithEvents T_Long_Sign As TextBox
    Friend WithEvents L_CurrentStar As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents O_TimeSelectSim As RadioButton
    Friend WithEvents O_TimeSelectLocal As RadioButton
    Friend WithEvents L_UTime As Label
    Friend WithEvents L_SiderialTime As Label
    Friend WithEvents L_LocalTime As Label
    Friend WithEvents F_StarInfo As GroupBox
    Friend WithEvents L_I_HorXYZ As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents L_I_EquXYZ As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents L_I_HourAngle As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents L_I_Alt As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents L_I_Az As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents L_I_DEC As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents L_I_RA As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents F_PreviewInfo As GroupBox
    Friend WithEvents L_Preview_HorXYZ As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents L_Preview_EquXYZ As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents L_Preview_HourAngle As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents L_Preview_Alt As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents L_Preview_Az As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents L_Preview_DEC As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents L_Preview_RA As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents C_Tracking As Button
    Friend WithEvents MSComm1 As IO.Ports.SerialPort
    Friend WithEvents LoadStarKatalogDialog As OpenFileDialog
    Friend WithEvents Tim_DisplayUpdate As Timer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents L_AzMotorIncr As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents L_MatrixSystemAzIst As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents L_AzAltSystem As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents L_MatrixSystemAzSoll As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents L_GlobalAzOffset As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents L_AltMotorIncr As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents L_MatrixSystemAltIst As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents L_MatrixSystemAltSoll As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents L_GlobalAltOffset As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents L_MatrixSystemAzDiffReal As Label
    Friend WithEvents L_MotorSystemAzDiffReal As Label
    Friend WithEvents L_MotorSystemAzDiffSim As Label
    Friend WithEvents L_MotorSystemAzDiff As Label
    Friend WithEvents L_MatrixSystemAzDiff As Label
    Friend WithEvents L_MotorSystemAltDiff As Label
    Friend WithEvents L_MatrixSystemAltDiff As Label
    Friend WithEvents L_ErrorCount As Label
    Friend WithEvents L_StatusMoving As Label
    Friend WithEvents Tim_Preview As Timer
    Friend WithEvents Tim_Simulation As Timer
    Friend WithEvents Tim_Startup As Timer
    Friend WithEvents Tim_TestStatus As Timer
    Friend WithEvents Tim_Tracking As Timer
    Friend WithEvents Ch_South As CheckBox
    Friend WithEvents L_Preview_CardinalOrientation As Label
    Friend WithEvents L_CardinalOrientation As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Slider1 As ProgressBar
    Friend WithEvents Slider2 As ProgressBar
    Friend WithEvents T_Alt As TextBox
    Friend WithEvents T_Az As TextBox
    Friend WithEvents L_ElapsedTime As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents CB_Find As ComboBox
    Friend WithEvents Tim_Comm As Timer
    Friend WithEvents B_Comm As Button
    Friend WithEvents L_NumerOfCmd As Label
    Friend WithEvents OpenCursorDialog As OpenFileDialog
    Friend WithEvents B_SetCurrentPos As Button
End Class
