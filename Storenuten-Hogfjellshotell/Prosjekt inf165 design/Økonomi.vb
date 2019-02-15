Public Class Økonomi

    Private Sub btnNyBes_Click(sender As Object, e As EventArgs) Handles btnNyBes.Click
        BestRes.Show()
        Me.Hide()
    End Sub

    Private Sub btnAvbes_Click(sender As Object, e As EventArgs) Handles btnAvbes.Click
        Avbestill.Show()
        Me.Hide()
    End Sub

    Private Sub btnInnsjekk_Click(sender As Object, e As EventArgs) Handles btnInnsjekk.Click
        Innsjekk.Show()
        Me.Hide()
    End Sub

    Private Sub btnOpphold_Click(sender As Object, e As EventArgs) Handles btnOpphold.Click
        Opphold.Show()
        Me.Hide()
    End Sub

    Private Sub btnUtsjekk_Click(sender As Object, e As EventArgs) Handles btnUtsjekk.Click
        Utsjekk.Show()
        Me.Hide()
    End Sub

    Private Sub btnEndre_Click(sender As Object, e As EventArgs) Handles btnEndre.Click
        Endreinfo.Show()
        Me.Hide()
    End Sub

    Private Sub btnReng_Click(sender As Object, e As EventArgs) 
    End Sub

    Private Sub btnValg_Click(sender As Object, e As EventArgs) Handles btnValg.Click
        Valgmuligheter.Show()
        Me.Hide()
    End Sub

    Private Sub btnAvslutt_Click(sender As Object, e As EventArgs) Handles btnAvslutt.Click
        'Spør brukeren om han avslutte programmet. 
        Dim DialogExit As DialogResult
        DialogExit = MessageBox.Show("Vil du virklig Avslutt Programmet.", "Exit", MessageBoxButtons.YesNoCancel)

        If DialogExit = DialogResult.No Then
            DialogExit = True

        ElseIf DialogExit = DialogResult.Cancel Then
            DialogExit = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub btnSøk_Click(sender As Object, e As EventArgs) Handles btnSøk.Click


        Try
            ' slette alle data fra DataGridView
            DataGridViewØkonomi.DataSource = Nothing
            DataGridViewØkonomi.Rows.Clear()
            DataGridViewØkonomi.Refresh()

            ' Legge Resultat søk til Enabled
            GrpSøkeresultat.Enabled = True
            GrpGenelinfo.Enabled = True
            btnGrafisk.Enabled = True
            DataGridViewØkonomi.Enabled = True

            lblEtternavn.Enabled = True
            lblFornavn.Enabled = True
            lblFraDato.Enabled = True
            lblTilDato.Enabled = True
            lblRomType.Enabled = True
            lblAntallPerosner.Enabled = True
            lblAntallrom.Enabled = True
            lblRomType.Enabled = True
            lblTotalPris.Enabled = True
            lblTypeBestilling.Enabled = True
            lblRomNr.Enabled = True


            dtpFradato.Format = DateTimePickerFormat.Custom
            dtpFradato.CustomFormat = "yyyy-MM-dd"
            dtpTildato.Format = DateTimePickerFormat.Custom
            dtpTildato.CustomFormat = "yyyy-MM-dd"


            Dim fradato As String = dtpFradato.Text
            Dim tildato As String = dtpTildato.Text
            Dim TabRom As New DataTable




            ' åpen connction med database
            minConnection.Open()


            Command.CommandText = "Select bestillingstype.RomNr, rom.TlfNr, bestillingstype.TypeBestilling, rom.RomType ,bestillingstype.AntallPersoner, bestillingstype.AntallVoksen, bestillingstype.AntallBarn, bestillingstype.AntallRom , bestillingstype.FraDato, bestillingstype.TilDato, personer.Fornavn, personer.Etternavn, (bestillingstype.AntallVoksen * 1290.00 + bestillingstype.AntallBarn * 645.00) AS OppholdPris, pris.PrisDrikke, PrisMat,PrisRengjøring  FROM bestillingstype, rom, personer, pris  WHERE bestillingstype.RomNr = rom.RomNr and pris.RomNr = rom.RomNr and personer.TlfNr = bestillingstype.TlfNr and bestillingstype.TypeBestilling= 'Bestilling'"

            If chkGjest.Checked Then
                Command.CommandText &= " AND rom.TlfNr = '" & txtTlf.Text & "'"
            End If

            If chkRom.Checked Then
                Command.CommandText &= " AND bestillingstype.RomNr = '" & numRomNr.Value.ToString & "'"
            End If

            If chkDato.Checked Then
                Command.CommandText &= " AND bestillingstype.FraDato >= '" & fradato & "' AND bestillingstype.TilDato <= '" & tildato & "'"
            End If

            minAdapter.SelectCommand = Command
            minAdapter.Fill(TabRom)

            DataGridViewØkonomi.DataSource = TabRom           ' legge data til DataGridView 
            minAdapter.Update(TabRom)                           ' Oppdater Data i DataGridView
            DataGridViewØkonomi.Refresh()

            'lukke connetion med database
            minConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dtpFradato_ValueChanged(sender As Object, e As EventArgs) Handles dtpFradato.ValueChanged
        dtpTildato.MinDate = dtpFradato.Value
    End Sub

    Private Sub DataGridViewØkonomi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewØkonomi.CellContentClick


        ' lese rad for DataGridViewØkonomi og legge select rad for Hver label + plusse totallpris.
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewØkonomi.Rows(e.RowIndex)
            lblRomNr.Text = Row.Cells("RomNr").Value.ToString
            lblTelefonNr.Text = Row.Cells("TlfNr").Value.ToString
            lblTypeBestilling.Text = Row.Cells("TypeBestilling").Value.ToString
            lblRomType.Text = Row.Cells("RomType").Value.ToString
            lblAntallPerosner.Text = Row.Cells("AntallPersoner").Value.ToString
            lblAntallrom.Text = Row.Cells("AntallRom").Value.ToString
            lblFraDato.Text = Row.Cells("FraDato").Value.ToString
            lblTilDato.Text = Row.Cells("TilDato").Value.ToString
            lblFornavn.Text = Row.Cells("Fornavn").Value.ToString
            lblEtternavn.Text = Row.Cells("Etternavn").Value.ToString
            lblTotalPris.Text = Row.Cells(12).Value + Row.Cells(13).Value + Row.Cells(14).Value + Row.Cells(15).Value

            DataGridViewØkonomi.Update()
            DataGridViewØkonomi.Refresh()
        End If


    End Sub

    Private Sub btnTømskjema_Click(sender As Object, e As EventArgs) Handles btnTømskjema.Click

        'Clear alle tekst
        lblEtternavn.Text = ""
        lblFornavn.Text = ""
        txtTlf.Text = ""
        lblTelefonNr.Text = ""
        lblFraDato.Text = ""
        lblTilDato.Text = ""
        lblRomType.Text = ""
        lblAntallPerosner.Text = ""
        lblAntallrom.Text = ""
        lblTotalPris.Text = ""
        lblTypeBestilling.Text = ""
        lblRomNr.Text = ""
        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today


        'Clear alle check bokser
        chkGjest.Checked = vbEmpty
        chkDato.Checked = vbEmpty
        chkRom.Checked = vbEmpty
        chkInntjenging.Checked = vbEmpty

        Chart1.Series.Clear()

        'Clear datagridview
        DataGridViewØkonomi.DataSource = Nothing
        DataGridViewØkonomi.Rows.Clear()
        DataGridViewØkonomi.Refresh()

        ' Legge Resultat søk til Enabled
        GrpSøkeresultat.Enabled = False
        GrpGenelinfo.Enabled = False
        btnGrafisk.Enabled = False
        DataGridViewØkonomi.Enabled = False

        lblEtternavn.Enabled = False
        lblFornavn.Enabled = False
        lblFraDato.Enabled = False
        lblTilDato.Enabled = False
        lblRomType.Enabled = False
        lblAntallPerosner.Enabled = False
        lblAntallrom.Enabled = False
        lblRomType.Enabled = False
        lblTotalPris.Enabled = False
        lblTypeBestilling.Enabled = False
        lblRomNr.Enabled = False

    End Sub

    Private Sub Økonomi_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Legge Resultat søk til Enabled
        GrpSøkeresultat.Enabled = False
            GrpGenelinfo.Enabled = False
        btnGrafisk.Enabled = False

        DataGridViewØkonomi.Enabled = False
            lblEtternavn.Enabled = False
            lblFornavn.Enabled = False
            lblFraDato.Enabled = False
            lblTilDato.Enabled = False
            lblRomType.Enabled = False
            lblAntallPerosner.Enabled = False
            lblAntallrom.Enabled = False
            lblRomType.Enabled = False
            lblTotalPris.Enabled = False
            lblTypeBestilling.Enabled = False
        lblRomNr.Enabled = False

    End Sub

    Private Sub btnGrafisk_Click(sender As Object, e As EventArgs) Handles btnGrafisk.Click


        Try


            minConnection.Open() ' åpne connection med database

            Command.CommandText = " Select (bestillingstype.AntallVoksen * 1290.00 + bestillingstype.AntallBarn * 645.00) AS OppholdPris, bestillingstype.AntallPersoner FROM bestillingstype, personer WHERE personer.TlfNr = bestillingstype.TlfNr and bestillingstype.TypeBestilling = 'Bestilling'"
            Command.ExecuteNonQuery()
            sqlRead = Command.ExecuteReader

            While sqlRead.Read
                Chart1.Series("OppholdPris_vs_AntallPersoner").Points.AddXY(sqlRead.GetString("OppholdPris"), sqlRead.GetInt32("AntallPersoner"))
            End While

            minConnection.Close()                                   ' Close connection 
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            minConnection.Dispose()
        End Try


    End Sub
End Class