<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Opphold
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Opphold))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSøk = New System.Windows.Forms.Button()
        Me.txtEtternavn = New System.Windows.Forms.TextBox()
        Me.txtTlf = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numRomnrSøk = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFornavn = New System.Windows.Forms.TextBox()
        Me.btnTøm = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbTypeService = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTypeVask = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.numMat = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbMat = New System.Windows.Forms.ComboBox()
        Me.numDrikke = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbDrikke = New System.Windows.Forms.ComboBox()
        Me.btnLagre = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnValg = New System.Windows.Forms.Button()
        Me.btnEndre = New System.Windows.Forms.Button()
        Me.btnUtsjekk = New System.Windows.Forms.Button()
        Me.btnOpphold = New System.Windows.Forms.Button()
        Me.btnInnsjekk = New System.Windows.Forms.Button()
        Me.btnAvbes = New System.Windows.Forms.Button()
        Me.btnNyBes = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnRegiLag = New System.Windows.Forms.Button()
        Me.GrpRegistering = New System.Windows.Forms.GroupBox()
        Me.SøkeresultatOpphold = New System.Windows.Forms.GroupBox()
        Me.ResultatOpphold = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lblAntallMat = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblAntallDrikke = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDrikk = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblMat = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTypeVask = New System.Windows.Forms.Label()
        Me.lblRomNr = New System.Windows.Forms.Label()
        Me.DataGridViewOpphold = New System.Windows.Forms.DataGridView()
        Me.btnAvslutt = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numRomnrSøk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.numMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDrikke, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GrpRegistering.SuspendLayout()
        Me.SøkeresultatOpphold.SuspendLayout()
        Me.ResultatOpphold.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridViewOpphold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.Controls.Add(Me.btnSøk)
        Me.GroupBox2.Controls.Add(Me.txtEtternavn)
        Me.GroupBox2.Controls.Add(Me.txtTlf)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.numRomnrSøk)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtFornavn)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 29)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(546, 192)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Søkekriterier"
        '
        'btnSøk
        '
        Me.btnSøk.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSøk.Location = New System.Drawing.Point(90, 149)
        Me.btnSøk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSøk.Name = "btnSøk"
        Me.btnSøk.Size = New System.Drawing.Size(85, 27)
        Me.btnSøk.TabIndex = 8
        Me.btnSøk.Text = "Søk"
        Me.btnSøk.UseVisualStyleBackColor = True
        '
        'txtEtternavn
        '
        Me.txtEtternavn.Location = New System.Drawing.Point(92, 60)
        Me.txtEtternavn.Name = "txtEtternavn"
        Me.txtEtternavn.Size = New System.Drawing.Size(156, 26)
        Me.txtEtternavn.TabIndex = 3
        '
        'txtTlf
        '
        Me.txtTlf.Location = New System.Drawing.Point(92, 88)
        Me.txtTlf.MaxLength = 8
        Me.txtTlf.Name = "txtTlf"
        Me.txtTlf.Size = New System.Drawing.Size(122, 26)
        Me.txtTlf.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(36, 119)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 19)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Romnr:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(33, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 19)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Telefon:"
        '
        'numRomnrSøk
        '
        Me.numRomnrSøk.Location = New System.Drawing.Point(92, 116)
        Me.numRomnrSøk.Maximum = New Decimal(New Integer() {165, 0, 0, 0})
        Me.numRomnrSøk.Name = "numRomnrSøk"
        Me.numRomnrSøk.Size = New System.Drawing.Size(57, 26)
        Me.numRomnrSøk.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fornavn:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Etternavn:"
        '
        'txtFornavn
        '
        Me.txtFornavn.Location = New System.Drawing.Point(92, 32)
        Me.txtFornavn.Name = "txtFornavn"
        Me.txtFornavn.Size = New System.Drawing.Size(156, 26)
        Me.txtFornavn.TabIndex = 1
        '
        'btnTøm
        '
        Me.btnTøm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnTøm.Location = New System.Drawing.Point(437, 510)
        Me.btnTøm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTøm.Name = "btnTøm"
        Me.btnTøm.Size = New System.Drawing.Size(96, 34)
        Me.btnTøm.TabIndex = 3
        Me.btnTøm.Text = "Tøm skjema"
        Me.btnTøm.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox4.Controls.Add(Me.cmbTypeService)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.cmbTypeVask)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 27)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(528, 95)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Romservice"
        '
        'cmbTypeService
        '
        Me.cmbTypeService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeService.FormattingEnabled = True
        Me.cmbTypeService.Items.AddRange(New Object() {"Vanlig", "VIP", "klassisk", "Ekstra service", "Uten service", "Annen"})
        Me.cmbTypeService.Location = New System.Drawing.Point(100, 27)
        Me.cmbTypeService.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTypeService.Name = "cmbTypeService"
        Me.cmbTypeService.Size = New System.Drawing.Size(132, 27)
        Me.cmbTypeService.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type service:"
        '
        'cmbTypeVask
        '
        Me.cmbTypeVask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeVask.FormattingEnabled = True
        Me.cmbTypeVask.Items.AddRange(New Object() {"Under opphold", "Ved utsjekk", "Speseill vask", "Annen"})
        Me.cmbTypeVask.Location = New System.Drawing.Point(100, 59)
        Me.cmbTypeVask.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTypeVask.Name = "cmbTypeVask"
        Me.cmbTypeVask.Size = New System.Drawing.Size(132, 27)
        Me.cmbTypeVask.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 62)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 19)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Type vask:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox5.Controls.Add(Me.numMat)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.cmbMat)
        Me.GroupBox5.Controls.Add(Me.numDrikke)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.cmbDrikke)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 128)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(528, 116)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Mat og Drikke"
        '
        'numMat
        '
        Me.numMat.Location = New System.Drawing.Point(342, 67)
        Me.numMat.Margin = New System.Windows.Forms.Padding(4)
        Me.numMat.Name = "numMat"
        Me.numMat.Size = New System.Drawing.Size(63, 26)
        Me.numMat.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(291, 69)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 19)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Antall:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(59, 68)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 19)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Mat:"
        '
        'cmbMat
        '
        Me.cmbMat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMat.FormattingEnabled = True
        Me.cmbMat.Items.AddRange(New Object() {"Diverse matvarer"})
        Me.cmbMat.Location = New System.Drawing.Point(99, 64)
        Me.cmbMat.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbMat.Name = "cmbMat"
        Me.cmbMat.Size = New System.Drawing.Size(180, 27)
        Me.cmbMat.TabIndex = 3
        '
        'numDrikke
        '
        Me.numDrikke.Location = New System.Drawing.Point(342, 37)
        Me.numDrikke.Margin = New System.Windows.Forms.Padding(4)
        Me.numDrikke.Name = "numDrikke"
        Me.numDrikke.Size = New System.Drawing.Size(63, 26)
        Me.numDrikke.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(292, 40)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 19)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Antall:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(43, 37)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 19)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Drikke:"
        '
        'cmbDrikke
        '
        Me.cmbDrikke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDrikke.FormattingEnabled = True
        Me.cmbDrikke.Items.AddRange(New Object() {"Øl", "Vin", "Cider", "Sterkvin", "Sterkøl", "Brennevin", "Mineralvann", "Vann"})
        Me.cmbDrikke.Location = New System.Drawing.Point(100, 33)
        Me.cmbDrikke.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDrikke.Name = "cmbDrikke"
        Me.cmbDrikke.Size = New System.Drawing.Size(180, 27)
        Me.cmbDrikke.TabIndex = 1
        '
        'btnLagre
        '
        Me.btnLagre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLagre.Location = New System.Drawing.Point(1431, 859)
        Me.btnLagre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLagre.Name = "btnLagre"
        Me.btnLagre.Size = New System.Drawing.Size(116, 34)
        Me.btnLagre.TabIndex = 20
        Me.btnLagre.Text = "Lagre "
        Me.btnLagre.UseVisualStyleBackColor = True
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
        'btnValg
        '
        Me.btnValg.Location = New System.Drawing.Point(1032, 19)
        Me.btnValg.Name = "btnValg"
        Me.btnValg.Size = New System.Drawing.Size(110, 39)
        Me.btnValg.TabIndex = 6
        Me.btnValg.Text = "Valgmeny"
        Me.btnValg.UseVisualStyleBackColor = True
        '
        'btnEndre
        '
        Me.btnEndre.Location = New System.Drawing.Point(881, 19)
        Me.btnEndre.Name = "btnEndre"
        Me.btnEndre.Size = New System.Drawing.Size(110, 39)
        Me.btnEndre.TabIndex = 5
        Me.btnEndre.Text = "Endre info"
        Me.btnEndre.UseVisualStyleBackColor = True
        '
        'btnUtsjekk
        '
        Me.btnUtsjekk.Location = New System.Drawing.Point(730, 19)
        Me.btnUtsjekk.Name = "btnUtsjekk"
        Me.btnUtsjekk.Size = New System.Drawing.Size(110, 39)
        Me.btnUtsjekk.TabIndex = 4
        Me.btnUtsjekk.Text = "Utsjekk"
        Me.btnUtsjekk.UseVisualStyleBackColor = True
        '
        'btnOpphold
        '
        Me.btnOpphold.Location = New System.Drawing.Point(579, 19)
        Me.btnOpphold.Name = "btnOpphold"
        Me.btnOpphold.Size = New System.Drawing.Size(110, 39)
        Me.btnOpphold.TabIndex = 3
        Me.btnOpphold.Text = "Opphold"
        Me.btnOpphold.UseVisualStyleBackColor = True
        '
        'btnInnsjekk
        '
        Me.btnInnsjekk.Location = New System.Drawing.Point(428, 19)
        Me.btnInnsjekk.Name = "btnInnsjekk"
        Me.btnInnsjekk.Size = New System.Drawing.Size(110, 39)
        Me.btnInnsjekk.TabIndex = 2
        Me.btnInnsjekk.Text = "Innsjekk"
        Me.btnInnsjekk.UseVisualStyleBackColor = True
        '
        'btnAvbes
        '
        Me.btnAvbes.Location = New System.Drawing.Point(277, 19)
        Me.btnAvbes.Name = "btnAvbes"
        Me.btnAvbes.Size = New System.Drawing.Size(110, 39)
        Me.btnAvbes.TabIndex = 1
        Me.btnAvbes.Text = "Avbestilling "
        Me.btnAvbes.UseVisualStyleBackColor = True
        '
        'btnNyBes
        '
        Me.btnNyBes.Location = New System.Drawing.Point(126, 19)
        Me.btnNyBes.Name = "btnNyBes"
        Me.btnNyBes.Size = New System.Drawing.Size(110, 39)
        Me.btnNyBes.TabIndex = 0
        Me.btnNyBes.Text = "Ny bestilling "
        Me.btnNyBes.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnRegiLag)
        Me.GroupBox6.Controls.Add(Me.GrpRegistering)
        Me.GroupBox6.Controls.Add(Me.GroupBox2)
        Me.GroupBox6.Controls.Add(Me.btnTøm)
        Me.GroupBox6.Location = New System.Drawing.Point(26, 110)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(590, 565)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'btnRegiLag
        '
        Me.btnRegiLag.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRegiLag.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegiLag.Location = New System.Drawing.Point(49, 510)
        Me.btnRegiLag.Name = "btnRegiLag"
        Me.btnRegiLag.Size = New System.Drawing.Size(154, 34)
        Me.btnRegiLag.TabIndex = 2
        Me.btnRegiLag.Text = "Registrer og Lagre"
        Me.btnRegiLag.UseVisualStyleBackColor = True
        '
        'GrpRegistering
        '
        Me.GrpRegistering.Controls.Add(Me.GroupBox4)
        Me.GrpRegistering.Controls.Add(Me.GroupBox5)
        Me.GrpRegistering.Location = New System.Drawing.Point(19, 228)
        Me.GrpRegistering.Name = "GrpRegistering"
        Me.GrpRegistering.Size = New System.Drawing.Size(546, 258)
        Me.GrpRegistering.TabIndex = 1
        Me.GrpRegistering.TabStop = False
        Me.GrpRegistering.Text = "Registering romservice"
        '
        'SøkeresultatOpphold
        '
        Me.SøkeresultatOpphold.Controls.Add(Me.ResultatOpphold)
        Me.SøkeresultatOpphold.Controls.Add(Me.DataGridViewOpphold)
        Me.SøkeresultatOpphold.Location = New System.Drawing.Point(631, 110)
        Me.SøkeresultatOpphold.Name = "SøkeresultatOpphold"
        Me.SøkeresultatOpphold.Size = New System.Drawing.Size(703, 565)
        Me.SøkeresultatOpphold.TabIndex = 2
        Me.SøkeresultatOpphold.TabStop = False
        Me.SøkeresultatOpphold.Text = "Søkeresultat"
        '
        'ResultatOpphold
        '
        Me.ResultatOpphold.Controls.Add(Me.GroupBox9)
        Me.ResultatOpphold.Controls.Add(Me.GroupBox3)
        Me.ResultatOpphold.Location = New System.Drawing.Point(31, 323)
        Me.ResultatOpphold.Name = "ResultatOpphold"
        Me.ResultatOpphold.Size = New System.Drawing.Size(636, 218)
        Me.ResultatOpphold.TabIndex = 1
        Me.ResultatOpphold.TabStop = False
        Me.ResultatOpphold.Text = "Resultat"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lblAntallMat)
        Me.GroupBox9.Controls.Add(Me.Label14)
        Me.GroupBox9.Controls.Add(Me.lblAntallDrikke)
        Me.GroupBox9.Controls.Add(Me.Label2)
        Me.GroupBox9.Controls.Add(Me.lblDrikk)
        Me.GroupBox9.Controls.Add(Me.Label13)
        Me.GroupBox9.Controls.Add(Me.lblMat)
        Me.GroupBox9.Controls.Add(Me.Label11)
        Me.GroupBox9.Location = New System.Drawing.Point(327, 24)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(299, 182)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Mat og Drikke"
        '
        'lblAntallMat
        '
        Me.lblAntallMat.AutoSize = True
        Me.lblAntallMat.Location = New System.Drawing.Point(103, 116)
        Me.lblAntallMat.Name = "lblAntallMat"
        Me.lblAntallMat.Size = New System.Drawing.Size(14, 19)
        Me.lblAntallMat.TabIndex = 7
        Me.lblAntallMat.Text = "!"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 19)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Antall Mat:"
        '
        'lblAntallDrikke
        '
        Me.lblAntallDrikke.AutoSize = True
        Me.lblAntallDrikke.Location = New System.Drawing.Point(103, 63)
        Me.lblAntallDrikke.Name = "lblAntallDrikke"
        Me.lblAntallDrikke.Size = New System.Drawing.Size(14, 19)
        Me.lblAntallDrikke.TabIndex = 3
        Me.lblAntallDrikke.Text = "!"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Antall Drikke:"
        '
        'lblDrikk
        '
        Me.lblDrikk.AutoSize = True
        Me.lblDrikk.Location = New System.Drawing.Point(103, 37)
        Me.lblDrikk.Name = "lblDrikk"
        Me.lblDrikk.Size = New System.Drawing.Size(14, 19)
        Me.lblDrikk.TabIndex = 1
        Me.lblDrikk.Text = "!"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(45, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 19)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Drikke:"
        '
        'lblMat
        '
        Me.lblMat.AutoSize = True
        Me.lblMat.Location = New System.Drawing.Point(103, 89)
        Me.lblMat.Name = "lblMat"
        Me.lblMat.Size = New System.Drawing.Size(14, 19)
        Me.lblMat.TabIndex = 5
        Me.lblMat.Text = "!"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(62, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 19)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Mat:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblTypeVask)
        Me.GroupBox3.Controls.Add(Me.lblRomNr)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 23)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(299, 182)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rengjøring"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Type Vask:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "RomNr:"
        '
        'lblTypeVask
        '
        Me.lblTypeVask.AutoSize = True
        Me.lblTypeVask.Location = New System.Drawing.Point(91, 64)
        Me.lblTypeVask.Name = "lblTypeVask"
        Me.lblTypeVask.Size = New System.Drawing.Size(14, 19)
        Me.lblTypeVask.TabIndex = 3
        Me.lblTypeVask.Text = "!"
        '
        'lblRomNr
        '
        Me.lblRomNr.AutoSize = True
        Me.lblRomNr.Location = New System.Drawing.Point(90, 39)
        Me.lblRomNr.Name = "lblRomNr"
        Me.lblRomNr.Size = New System.Drawing.Size(14, 19)
        Me.lblRomNr.TabIndex = 1
        Me.lblRomNr.Text = "!"
        '
        'DataGridViewOpphold
        '
        Me.DataGridViewOpphold.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DataGridViewOpphold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewOpphold.Location = New System.Drawing.Point(31, 34)
        Me.DataGridViewOpphold.Name = "DataGridViewOpphold"
        Me.DataGridViewOpphold.Size = New System.Drawing.Size(636, 274)
        Me.DataGridViewOpphold.TabIndex = 0
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
        'Opphold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.Controls.Add(Me.btnAvslutt)
        Me.Controls.Add(Me.SøkeresultatOpphold)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLagre)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Opphold"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opphold"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numRomnrSøk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.numMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDrikke, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GrpRegistering.ResumeLayout(False)
        Me.SøkeresultatOpphold.ResumeLayout(False)
        Me.ResultatOpphold.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridViewOpphold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnSøk As Button
    Friend WithEvents btnTøm As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cmbTypeVask As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents numMat As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbMat As ComboBox
    Friend WithEvents numDrikke As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbDrikke As ComboBox
    Friend WithEvents btnLagre As Button
    Friend WithEvents numRomnrSøk As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnValg As Button
    Friend WithEvents btnEndre As Button
    Friend WithEvents btnUtsjekk As Button
    Friend WithEvents btnOpphold As Button
    Friend WithEvents btnInnsjekk As Button
    Friend WithEvents btnAvbes As Button
    Friend WithEvents btnNyBes As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents SøkeresultatOpphold As GroupBox
    Friend WithEvents btnAvslutt As Button
    Friend WithEvents txtTlf As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEtternavn As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFornavn As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GrpRegistering As GroupBox
    Friend WithEvents btnRegiLag As Button
    Friend WithEvents DataGridViewOpphold As DataGridView
    Friend WithEvents ResultatOpphold As GroupBox
    Friend WithEvents lblMat As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblRomNr As Label
    Friend WithEvents lblTypeVask As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDrikk As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblAntallMat As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblAntallDrikke As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTypeService As ComboBox
    Friend WithEvents Label1 As Label
End Class
