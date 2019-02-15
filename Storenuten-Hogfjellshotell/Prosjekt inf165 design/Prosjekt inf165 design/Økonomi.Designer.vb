<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Økonomi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Økonomi))
        Me.ResultatUtsjekk = New System.Windows.Forms.GroupBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblRomNr = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblTelefonNr = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblEtternavn = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblFornavn = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GrpSøkeresultat = New System.Windows.Forms.GroupBox()
        Me.DataGridViewØkonomi = New System.Windows.Forms.DataGridView()
        Me.btnAvslutt = New System.Windows.Forms.Button()
        Me.btnTømskjema = New System.Windows.Forms.Button()
        Me.txtTlf = New System.Windows.Forms.TextBox()
        Me.btnSøk = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnGrafisk = New System.Windows.Forms.Button()
        Me.GrpGenelinfo = New System.Windows.Forms.GroupBox()
        Me.lblTypeBestilling = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalPris = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblAntallrom = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRomType = New System.Windows.Forms.Label()
        Me.lblFraDato = New System.Windows.Forms.Label()
        Me.lblTilDato = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblAntallPerosner = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.numRomNr = New System.Windows.Forms.NumericUpDown()
        Me.btnValg = New System.Windows.Forms.Button()
        Me.btnEndre = New System.Windows.Forms.Button()
        Me.btnUtsjekk = New System.Windows.Forms.Button()
        Me.btnOpphold = New System.Windows.Forms.Button()
        Me.btnInnsjekk = New System.Windows.Forms.Button()
        Me.btnAvbes = New System.Windows.Forms.Button()
        Me.btnNyBes = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.chkInntjenging = New System.Windows.Forms.CheckBox()
        Me.chkDato = New System.Windows.Forms.CheckBox()
        Me.chkRom = New System.Windows.Forms.CheckBox()
        Me.chkGjest = New System.Windows.Forms.CheckBox()
        Me.grRom = New System.Windows.Forms.GroupBox()
        Me.grGjest = New System.Windows.Forms.GroupBox()
        Me.grDato = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTildato = New System.Windows.Forms.DateTimePicker()
        Me.dtpFradato = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnTøm = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ResultatUtsjekk.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSøkeresultat.SuspendLayout()
        CType(Me.DataGridViewØkonomi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpGenelinfo.SuspendLayout()
        CType(Me.numRomNr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.grRom.SuspendLayout()
        Me.grGjest.SuspendLayout()
        Me.grDato.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ResultatUtsjekk
        '
        Me.ResultatUtsjekk.Controls.Add(Me.Chart1)
        Me.ResultatUtsjekk.Location = New System.Drawing.Point(28, 303)
        Me.ResultatUtsjekk.Name = "ResultatUtsjekk"
        Me.ResultatUtsjekk.Size = New System.Drawing.Size(636, 238)
        Me.ResultatUtsjekk.TabIndex = 14
        Me.ResultatUtsjekk.TabStop = False
        Me.ResultatUtsjekk.Text = "Resultat"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Angle = -45
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(9, 25)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "OppholdPris_vs_AntallPersoner"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(620, 204)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'lblRomNr
        '
        Me.lblRomNr.AutoSize = True
        Me.lblRomNr.Location = New System.Drawing.Point(94, 110)
        Me.lblRomNr.Name = "lblRomNr"
        Me.lblRomNr.Size = New System.Drawing.Size(14, 19)
        Me.lblRomNr.TabIndex = 9
        Me.lblRomNr.Text = "!"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(29, 110)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(58, 19)
        Me.Label43.TabIndex = 8
        Me.Label43.Text = "RomNr:"
        '
        'lblTelefonNr
        '
        Me.lblTelefonNr.AutoSize = True
        Me.lblTelefonNr.Location = New System.Drawing.Point(93, 85)
        Me.lblTelefonNr.Name = "lblTelefonNr"
        Me.lblTelefonNr.Size = New System.Drawing.Size(14, 19)
        Me.lblTelefonNr.TabIndex = 7
        Me.lblTelefonNr.Text = "!"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 19)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Telefonnr:"
        '
        'lblEtternavn
        '
        Me.lblEtternavn.AutoSize = True
        Me.lblEtternavn.Location = New System.Drawing.Point(93, 59)
        Me.lblEtternavn.Name = "lblEtternavn"
        Me.lblEtternavn.Size = New System.Drawing.Size(14, 19)
        Me.lblEtternavn.TabIndex = 5
        Me.lblEtternavn.Text = "!"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(17, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 19)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Etternavn:"
        '
        'lblFornavn
        '
        Me.lblFornavn.AutoSize = True
        Me.lblFornavn.Location = New System.Drawing.Point(93, 34)
        Me.lblFornavn.Name = "lblFornavn"
        Me.lblFornavn.Size = New System.Drawing.Size(14, 19)
        Me.lblFornavn.TabIndex = 1
        Me.lblFornavn.Text = "!"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(24, 34)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(62, 19)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Fornavn:"
        '
        'GrpSøkeresultat
        '
        Me.GrpSøkeresultat.Controls.Add(Me.ResultatUtsjekk)
        Me.GrpSøkeresultat.Controls.Add(Me.DataGridViewØkonomi)
        Me.GrpSøkeresultat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GrpSøkeresultat.Location = New System.Drawing.Point(631, 110)
        Me.GrpSøkeresultat.Name = "GrpSøkeresultat"
        Me.GrpSøkeresultat.Size = New System.Drawing.Size(703, 565)
        Me.GrpSøkeresultat.TabIndex = 2
        Me.GrpSøkeresultat.TabStop = False
        Me.GrpSøkeresultat.Text = "Søkeresultat"
        '
        'DataGridViewØkonomi
        '
        Me.DataGridViewØkonomi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DataGridViewØkonomi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewØkonomi.Location = New System.Drawing.Point(28, 34)
        Me.DataGridViewØkonomi.Name = "DataGridViewØkonomi"
        Me.DataGridViewØkonomi.Size = New System.Drawing.Size(636, 261)
        Me.DataGridViewØkonomi.TabIndex = 0
        '
        'btnAvslutt
        '
        Me.btnAvslutt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAvslutt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvslutt.Location = New System.Drawing.Point(27, 685)
        Me.btnAvslutt.Name = "btnAvslutt"
        Me.btnAvslutt.Size = New System.Drawing.Size(90, 33)
        Me.btnAvslutt.TabIndex = 3
        Me.btnAvslutt.Text = "Avslutt"
        Me.btnAvslutt.UseVisualStyleBackColor = True
        '
        'btnTømskjema
        '
        Me.btnTømskjema.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTømskjema.Location = New System.Drawing.Point(434, 510)
        Me.btnTømskjema.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTømskjema.Name = "btnTømskjema"
        Me.btnTømskjema.Size = New System.Drawing.Size(96, 34)
        Me.btnTømskjema.TabIndex = 1
        Me.btnTømskjema.Text = "Tøm skjema"
        Me.btnTømskjema.UseVisualStyleBackColor = True
        '
        'txtTlf
        '
        Me.txtTlf.Location = New System.Drawing.Point(78, 34)
        Me.txtTlf.MaxLength = 8
        Me.txtTlf.Name = "txtTlf"
        Me.txtTlf.Size = New System.Drawing.Size(122, 26)
        Me.txtTlf.TabIndex = 1
        '
        'btnSøk
        '
        Me.btnSøk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSøk.Location = New System.Drawing.Point(433, 217)
        Me.btnSøk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSøk.Name = "btnSøk"
        Me.btnSøk.Size = New System.Drawing.Size(85, 27)
        Me.btnSøk.TabIndex = 4
        Me.btnSøk.Text = "Søk"
        Me.btnSøk.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(20, 28)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 19)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Romnr:"
        '
        'btnGrafisk
        '
        Me.btnGrafisk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGrafisk.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrafisk.Location = New System.Drawing.Point(46, 510)
        Me.btnGrafisk.Name = "btnGrafisk"
        Me.btnGrafisk.Size = New System.Drawing.Size(154, 34)
        Me.btnGrafisk.TabIndex = 0
        Me.btnGrafisk.Text = "Grafisk"
        Me.btnGrafisk.UseVisualStyleBackColor = True
        '
        'GrpGenelinfo
        '
        Me.GrpGenelinfo.Controls.Add(Me.lblTypeBestilling)
        Me.GrpGenelinfo.Controls.Add(Me.Label5)
        Me.GrpGenelinfo.Controls.Add(Me.lblTotalPris)
        Me.GrpGenelinfo.Controls.Add(Me.Label13)
        Me.GrpGenelinfo.Controls.Add(Me.lblAntallrom)
        Me.GrpGenelinfo.Controls.Add(Me.Label3)
        Me.GrpGenelinfo.Controls.Add(Me.lblRomType)
        Me.GrpGenelinfo.Controls.Add(Me.lblFraDato)
        Me.GrpGenelinfo.Controls.Add(Me.lblTilDato)
        Me.GrpGenelinfo.Controls.Add(Me.Label16)
        Me.GrpGenelinfo.Controls.Add(Me.Label15)
        Me.GrpGenelinfo.Controls.Add(Me.Label14)
        Me.GrpGenelinfo.Controls.Add(Me.lblAntallPerosner)
        Me.GrpGenelinfo.Controls.Add(Me.Label12)
        Me.GrpGenelinfo.Controls.Add(Me.lblRomNr)
        Me.GrpGenelinfo.Controls.Add(Me.Label18)
        Me.GrpGenelinfo.Controls.Add(Me.Label43)
        Me.GrpGenelinfo.Controls.Add(Me.Label26)
        Me.GrpGenelinfo.Controls.Add(Me.lblTelefonNr)
        Me.GrpGenelinfo.Controls.Add(Me.lblFornavn)
        Me.GrpGenelinfo.Controls.Add(Me.Label24)
        Me.GrpGenelinfo.Controls.Add(Me.lblEtternavn)
        Me.GrpGenelinfo.Location = New System.Drawing.Point(16, 303)
        Me.GrpGenelinfo.Name = "GrpGenelinfo"
        Me.GrpGenelinfo.Size = New System.Drawing.Size(557, 200)
        Me.GrpGenelinfo.TabIndex = 3
        Me.GrpGenelinfo.TabStop = False
        Me.GrpGenelinfo.Text = "Generell informasjon"
        '
        'lblTypeBestilling
        '
        Me.lblTypeBestilling.AutoSize = True
        Me.lblTypeBestilling.Location = New System.Drawing.Point(359, 85)
        Me.lblTypeBestilling.Name = "lblTypeBestilling"
        Me.lblTypeBestilling.Size = New System.Drawing.Size(14, 19)
        Me.lblTypeBestilling.TabIndex = 19
        Me.lblTypeBestilling.Text = "!"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(255, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Type bestilling:"
        '
        'lblTotalPris
        '
        Me.lblTotalPris.AutoSize = True
        Me.lblTotalPris.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPris.Location = New System.Drawing.Point(359, 137)
        Me.lblTotalPris.Name = "lblTotalPris"
        Me.lblTotalPris.Size = New System.Drawing.Size(14, 19)
        Me.lblTotalPris.TabIndex = 1
        Me.lblTotalPris.Text = "!"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(283, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 19)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Total Pris:"
        '
        'lblAntallrom
        '
        Me.lblAntallrom.AutoSize = True
        Me.lblAntallrom.Location = New System.Drawing.Point(94, 137)
        Me.lblAntallrom.Name = "lblAntallrom"
        Me.lblAntallrom.Size = New System.Drawing.Size(14, 19)
        Me.lblAntallrom.TabIndex = 11
        Me.lblAntallrom.Text = "!"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 19)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Antall rom:"
        '
        'lblRomType
        '
        Me.lblRomType.AutoSize = True
        Me.lblRomType.Location = New System.Drawing.Point(94, 163)
        Me.lblRomType.Name = "lblRomType"
        Me.lblRomType.Size = New System.Drawing.Size(14, 19)
        Me.lblRomType.TabIndex = 13
        Me.lblRomType.Text = "!"
        '
        'lblFraDato
        '
        Me.lblFraDato.AutoSize = True
        Me.lblFraDato.Location = New System.Drawing.Point(359, 34)
        Me.lblFraDato.Name = "lblFraDato"
        Me.lblFraDato.Size = New System.Drawing.Size(14, 19)
        Me.lblFraDato.TabIndex = 15
        Me.lblFraDato.Text = "!"
        '
        'lblTilDato
        '
        Me.lblTilDato.AutoSize = True
        Me.lblTilDato.Location = New System.Drawing.Point(359, 60)
        Me.lblTilDato.Name = "lblTilDato"
        Me.lblTilDato.Size = New System.Drawing.Size(14, 19)
        Me.lblTilDato.TabIndex = 17
        Me.lblTilDato.Text = "!"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(295, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 19)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Til dato:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(288, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 19)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Fra dato:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 162)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 19)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Rom Type:"
        '
        'lblAntallPerosner
        '
        Me.lblAntallPerosner.AutoSize = True
        Me.lblAntallPerosner.Location = New System.Drawing.Point(359, 112)
        Me.lblAntallPerosner.Name = "lblAntallPerosner"
        Me.lblAntallPerosner.Size = New System.Drawing.Size(14, 19)
        Me.lblAntallPerosner.TabIndex = 21
        Me.lblAntallPerosner.Text = "!"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(258, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 19)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Antall peroner:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(19, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 19)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Telefon:"
        '
        'numRomNr
        '
        Me.numRomNr.Location = New System.Drawing.Point(76, 25)
        Me.numRomNr.Maximum = New Decimal(New Integer() {165, 0, 0, 0})
        Me.numRomNr.Name = "numRomNr"
        Me.numRomNr.Size = New System.Drawing.Size(57, 26)
        Me.numRomNr.TabIndex = 1
        '
        'btnValg
        '
        Me.btnValg.Location = New System.Drawing.Point(1029, 19)
        Me.btnValg.Name = "btnValg"
        Me.btnValg.Size = New System.Drawing.Size(110, 39)
        Me.btnValg.TabIndex = 6
        Me.btnValg.Text = "Valgmeny"
        Me.btnValg.UseVisualStyleBackColor = True
        '
        'btnEndre
        '
        Me.btnEndre.Location = New System.Drawing.Point(878, 19)
        Me.btnEndre.Name = "btnEndre"
        Me.btnEndre.Size = New System.Drawing.Size(110, 39)
        Me.btnEndre.TabIndex = 5
        Me.btnEndre.Text = "Endre info"
        Me.btnEndre.UseVisualStyleBackColor = True
        '
        'btnUtsjekk
        '
        Me.btnUtsjekk.Location = New System.Drawing.Point(727, 19)
        Me.btnUtsjekk.Name = "btnUtsjekk"
        Me.btnUtsjekk.Size = New System.Drawing.Size(110, 39)
        Me.btnUtsjekk.TabIndex = 4
        Me.btnUtsjekk.Text = "Utsjekk"
        Me.btnUtsjekk.UseVisualStyleBackColor = True
        '
        'btnOpphold
        '
        Me.btnOpphold.Location = New System.Drawing.Point(576, 19)
        Me.btnOpphold.Name = "btnOpphold"
        Me.btnOpphold.Size = New System.Drawing.Size(110, 39)
        Me.btnOpphold.TabIndex = 3
        Me.btnOpphold.Text = "Opphold"
        Me.btnOpphold.UseVisualStyleBackColor = True
        '
        'btnInnsjekk
        '
        Me.btnInnsjekk.Location = New System.Drawing.Point(425, 19)
        Me.btnInnsjekk.Name = "btnInnsjekk"
        Me.btnInnsjekk.Size = New System.Drawing.Size(110, 39)
        Me.btnInnsjekk.TabIndex = 2
        Me.btnInnsjekk.Text = "Innsjekk"
        Me.btnInnsjekk.UseVisualStyleBackColor = True
        '
        'btnAvbes
        '
        Me.btnAvbes.Location = New System.Drawing.Point(274, 19)
        Me.btnAvbes.Name = "btnAvbes"
        Me.btnAvbes.Size = New System.Drawing.Size(110, 39)
        Me.btnAvbes.TabIndex = 1
        Me.btnAvbes.Text = "Avbestilling "
        Me.btnAvbes.UseVisualStyleBackColor = True
        '
        'btnNyBes
        '
        Me.btnNyBes.Location = New System.Drawing.Point(123, 19)
        Me.btnNyBes.Name = "btnNyBes"
        Me.btnNyBes.Size = New System.Drawing.Size(110, 39)
        Me.btnNyBes.TabIndex = 0
        Me.btnNyBes.Text = "Ny bestilling "
        Me.btnNyBes.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox9.Controls.Add(Me.GroupBox11)
        Me.GroupBox9.Controls.Add(Me.grRom)
        Me.GroupBox9.Controls.Add(Me.grGjest)
        Me.GroupBox9.Controls.Add(Me.grDato)
        Me.GroupBox9.Controls.Add(Me.btnSøk)
        Me.GroupBox9.Location = New System.Drawing.Point(17, 17)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Size = New System.Drawing.Size(556, 278)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Søkekriterier"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.chkInntjenging)
        Me.GroupBox11.Controls.Add(Me.chkDato)
        Me.GroupBox11.Controls.Add(Me.chkRom)
        Me.GroupBox11.Controls.Add(Me.chkGjest)
        Me.GroupBox11.Location = New System.Drawing.Point(17, 17)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(517, 66)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Hva vil du søke på "
        '
        'chkInntjenging
        '
        Me.chkInntjenging.AutoSize = True
        Me.chkInntjenging.Location = New System.Drawing.Point(342, 30)
        Me.chkInntjenging.Name = "chkInntjenging"
        Me.chkInntjenging.Size = New System.Drawing.Size(86, 23)
        Me.chkInntjenging.TabIndex = 3
        Me.chkInntjenging.Text = "Inntjening"
        Me.chkInntjenging.UseVisualStyleBackColor = True
        '
        'chkDato
        '
        Me.chkDato.AutoSize = True
        Me.chkDato.Location = New System.Drawing.Point(248, 30)
        Me.chkDato.Name = "chkDato"
        Me.chkDato.Size = New System.Drawing.Size(58, 23)
        Me.chkDato.TabIndex = 2
        Me.chkDato.Text = "Dato"
        Me.chkDato.UseVisualStyleBackColor = True
        '
        'chkRom
        '
        Me.chkRom.AutoSize = True
        Me.chkRom.Location = New System.Drawing.Point(155, 30)
        Me.chkRom.Name = "chkRom"
        Me.chkRom.Size = New System.Drawing.Size(57, 23)
        Me.chkRom.TabIndex = 1
        Me.chkRom.Text = "Rom"
        Me.chkRom.UseVisualStyleBackColor = True
        '
        'chkGjest
        '
        Me.chkGjest.AutoSize = True
        Me.chkGjest.Location = New System.Drawing.Point(59, 30)
        Me.chkGjest.Name = "chkGjest"
        Me.chkGjest.Size = New System.Drawing.Size(60, 23)
        Me.chkGjest.TabIndex = 0
        Me.chkGjest.Text = "Gjest"
        Me.chkGjest.UseVisualStyleBackColor = True
        '
        'grRom
        '
        Me.grRom.Controls.Add(Me.numRomNr)
        Me.grRom.Controls.Add(Me.Label20)
        Me.grRom.Location = New System.Drawing.Point(17, 188)
        Me.grRom.Name = "grRom"
        Me.grRom.Size = New System.Drawing.Size(283, 72)
        Me.grRom.TabIndex = 3
        Me.grRom.TabStop = False
        Me.grRom.Text = "Rom"
        '
        'grGjest
        '
        Me.grGjest.Controls.Add(Me.txtTlf)
        Me.grGjest.Controls.Add(Me.Label21)
        Me.grGjest.Location = New System.Drawing.Point(15, 89)
        Me.grGjest.Name = "grGjest"
        Me.grGjest.Size = New System.Drawing.Size(284, 97)
        Me.grGjest.TabIndex = 1
        Me.grGjest.TabStop = False
        Me.grGjest.Text = "Gjest"
        '
        'grDato
        '
        Me.grDato.Controls.Add(Me.Label2)
        Me.grDato.Controls.Add(Me.Label1)
        Me.grDato.Controls.Add(Me.dtpTildato)
        Me.grDato.Controls.Add(Me.dtpFradato)
        Me.grDato.Location = New System.Drawing.Point(305, 89)
        Me.grDato.Name = "grDato"
        Me.grDato.Size = New System.Drawing.Size(229, 97)
        Me.grDato.TabIndex = 2
        Me.grDato.TabStop = False
        Me.grDato.Text = "Dato"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Til dato:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fra dato:"
        '
        'dtpTildato
        '
        Me.dtpTildato.CustomFormat = "yyyy-MM-dd"
        Me.dtpTildato.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTildato.Location = New System.Drawing.Point(78, 58)
        Me.dtpTildato.Name = "dtpTildato"
        Me.dtpTildato.Size = New System.Drawing.Size(115, 26)
        Me.dtpTildato.TabIndex = 3
        Me.dtpTildato.Value = New Date(2016, 4, 28, 0, 0, 0, 0)
        '
        'dtpFradato
        '
        Me.dtpFradato.CustomFormat = "yyyy-MM-dd"
        Me.dtpFradato.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFradato.Location = New System.Drawing.Point(78, 29)
        Me.dtpFradato.Name = "dtpFradato"
        Me.dtpFradato.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpFradato.Size = New System.Drawing.Size(115, 26)
        Me.dtpFradato.TabIndex = 1
        Me.dtpFradato.Value = New Date(2016, 4, 28, 0, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.btnValg)
        Me.GroupBox1.Controls.Add(Me.btnEndre)
        Me.GroupBox1.Controls.Add(Me.btnUtsjekk)
        Me.GroupBox1.Controls.Add(Me.btnOpphold)
        Me.GroupBox1.Controls.Add(Me.btnInnsjekk)
        Me.GroupBox1.Controls.Add(Me.btnAvbes)
        Me.GroupBox1.Controls.Add(Me.btnNyBes)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(26, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1308, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnTøm
        '
        Me.btnTøm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTøm.Location = New System.Drawing.Point(1359, 747)
        Me.btnTøm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTøm.Name = "btnTøm"
        Me.btnTøm.Size = New System.Drawing.Size(112, 34)
        Me.btnTøm.TabIndex = 34
        Me.btnTøm.Text = "Tøm skjema"
        Me.btnTøm.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnGrafisk)
        Me.GroupBox6.Controls.Add(Me.GrpGenelinfo)
        Me.GroupBox6.Controls.Add(Me.GroupBox9)
        Me.GroupBox6.Controls.Add(Me.btnTømskjema)
        Me.GroupBox6.Location = New System.Drawing.Point(26, 110)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(590, 565)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'Økonomi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Controls.Add(Me.GrpSøkeresultat)
        Me.Controls.Add(Me.btnAvslutt)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnTøm)
        Me.Controls.Add(Me.GroupBox6)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Økonomi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Økonomi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResultatUtsjekk.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSøkeresultat.ResumeLayout(False)
        CType(Me.DataGridViewØkonomi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpGenelinfo.ResumeLayout(False)
        Me.GrpGenelinfo.PerformLayout()
        CType(Me.numRomNr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.grRom.ResumeLayout(False)
        Me.grRom.PerformLayout()
        Me.grGjest.ResumeLayout(False)
        Me.grGjest.PerformLayout()
        Me.grDato.ResumeLayout(False)
        Me.grDato.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ResultatUtsjekk As GroupBox
    Friend WithEvents lblRomNr As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents lblTelefonNr As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblEtternavn As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblFornavn As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents GrpSøkeresultat As GroupBox
    Friend WithEvents DataGridViewØkonomi As DataGridView
    Friend WithEvents btnAvslutt As Button
    Friend WithEvents btnTømskjema As Button
    Friend WithEvents txtTlf As TextBox
    Friend WithEvents btnSøk As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents btnGrafisk As Button
    Friend WithEvents GrpGenelinfo As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents numRomNr As NumericUpDown
    Friend WithEvents btnValg As Button
    Friend WithEvents btnEndre As Button
    Friend WithEvents btnUtsjekk As Button
    Friend WithEvents btnOpphold As Button
    Friend WithEvents btnInnsjekk As Button
    Friend WithEvents btnAvbes As Button
    Friend WithEvents btnNyBes As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnTøm As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents grGjest As GroupBox
    Friend WithEvents grDato As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTildato As DateTimePicker
    Friend WithEvents dtpFradato As DateTimePicker
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents chkInntjenging As CheckBox
    Friend WithEvents chkDato As CheckBox
    Friend WithEvents chkRom As CheckBox
    Friend WithEvents chkGjest As CheckBox
    Friend WithEvents grRom As GroupBox
    Friend WithEvents lblAntallrom As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblRomType As Label
    Friend WithEvents lblFraDato As Label
    Friend WithEvents lblTilDato As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblAntallPerosner As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTotalPris As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblTypeBestilling As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class
