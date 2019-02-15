Public Class Opphold


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

    Private Sub Opphold_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Legge Resultat søk til Enabled
        SøkeresultatOpphold.Enabled = False
        GrpRegistering.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewOpphold.Enabled = False

        lblRomNr.Enabled = False
        lblTypeVask.Enabled = False
        lblDrikk.Enabled = False
        lblMat.Enabled = False
        lblAntallDrikke.Enabled = False
        lblAntallMat.Enabled = False


    End Sub

    Private Sub btnSøk_Click(sender As Object, e As EventArgs) Handles btnSøk.Click

        Try

            Dim msg As New MsgBoxResult
            Dim TabRom As New DataTable

            ' Sjekker søke om informasjon er riktig 
            If Not IsNumeric(txtTlf.Text) Or Not txtTlf.Text.Length = 8 Then
                msg = MsgBox("Telefonnr ikke gyldig")
                Exit Sub
            ElseIf txtFornavn.Text.Length < 2 Then
                msg = MsgBox("Fornavn ikke gyldig")
                Exit Sub
            ElseIf txtEtternavn.Text.Length < 2 Then
                msg = MsgBox("Etternavn ikke gyldig")
                Exit Sub
            End If

            ' slette alle data fra DataGridView
            DataGridViewOpphold.DataSource = Nothing
            DataGridViewOpphold.Rows.Clear()
            DataGridViewOpphold.Refresh()


            ' Legge Resultat søk til Enabled
            SøkeresultatOpphold.Enabled = True
            GrpRegistering.Enabled = True
            btnRegiLag.Enabled = True
            DataGridViewOpphold.Enabled = True

            lblRomNr.Enabled = True
            lblTypeVask.Enabled = True
            lblDrikk.Enabled = True
            lblMat.Enabled = True
            lblAntallDrikke.Enabled = True
            lblAntallMat.Enabled = True

            ' åpen connction med database
            minConnection.Open()


            ' Finne riktig opphold
            Command.CommandText = "SELECT opphold.RomNr, opphold.TlfNr, personer.Fornavn, personer.Etternavn, TypeService, pris.PrisDrikke, pris.PrisMat, pris.PrisRengjøring   FROM  Opphold,Personer, pris  WHERE opphold.TlfNr = personer.TlfNr AND  opphold.RomNr =pris.RomNr  AND Opphold.TlfNr='" & txtTlf.Text & "' AND Fornavn='" & txtFornavn.Text & "' AND EtterNavn='" & txtEtternavn.Text & "' AND Opphold.RomNr='" & numRomnrSøk.Value & "'"
            Command.ExecuteNonQuery()

            minAdapter.SelectCommand = Command
            minAdapter.Fill(TabRom)

            DataGridViewOpphold.DataSource = TabRom           ' legge data til DataGridView 
            minAdapter.Update(TabRom)                          ' Oppdater Data i DataGridView
            DataGridViewOpphold.Refresh()

            'lukke connetion med database
            minConnection.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridViewOpphold_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewOpphold.CellContentClick
        ' lese rad for DataGridViewInnsjekk og legge select rad for RomNr.
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewOpphold.Rows(e.RowIndex)
            lblRomNr.Text = Row.Cells("RomNr").Value.ToString
            DataGridViewOpphold.Update()
            DataGridViewOpphold.Refresh()
        End If
    End Sub

    Private Sub btnTøm_Click(sender As Object, e As EventArgs) Handles btnTøm.Click

        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()

        lblRomNr.Text = ""
        lblTypeVask.Text = ""
        lblDrikk.Text = ""
        lblMat.Text = ""
        lblAntallDrikke.Text = ""
        lblAntallMat.Text = ""

        numRomnrSøk.Value = 0
        numMat.Value = 0
        numDrikke.Value = 0

        cmbDrikke.Text = vbEmpty
        cmbMat.Text = vbEmpty
        cmbTypeVask.Text = vbEmpty
        cmbTypeService.Text = vbEmpty

        'Clear datagridview
        DataGridViewOpphold.DataSource = Nothing
        DataGridViewOpphold.Rows.Clear()
        DataGridViewOpphold.Refresh()

        ' Legge Resultat søk til Enabled
        SøkeresultatOpphold.Enabled = False
        GrpRegistering.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewOpphold.Enabled = False

        lblRomNr.Enabled = False
        lblTypeVask.Enabled = False
        lblDrikk.Enabled = False
        lblMat.Enabled = False
        lblAntallDrikke.Enabled = False
        lblAntallMat.Enabled = False

    End Sub

    Private Sub btnRegiLag_Click(sender As Object, e As EventArgs) Handles btnRegiLag.Click


        Try
            minConnection.Open()

            ' legge informasjon til Rom serive + mat og drikk
            Command.CommandText = "INSERT INTO `sn2016gr9`.`romservice`(`RomNr`, `TypeService`, `Rengjøring`, `Mat`, `AntallMat`, `Drikke`, `AntallDrikke`) VALUES('" & lblRomNr.Text & "', '" & cmbTypeService.Text & "' ,'" & cmbTypeVask.Text.ToString & "', '" & cmbMat.Text & "', '" & numMat.Value & "' ,'" & cmbDrikke.Text & "' ,'" & numDrikke.Value & "');"
            Command.ExecuteNonQuery()

            lblTypeVask.Text = cmbTypeVask.Text
            lblDrikk.Text = cmbDrikke.Text
            lblMat.Text = cmbMat.Text
            lblAntallDrikke.Text = numDrikke.Text
            lblAntallMat.Text = numMat.Text

            'oppdater Tabelen
            DataGridViewOpphold.Update()

            ' vise lagret data i en MessageBox
            MessageBox.Show("Informasjon lagret. " & vbNewLine & vbNewLine & "Romnr: " & lblRomNr.Text & vbNewLine & "Type vask: " & lblTypeVask.Text & vbNewLine & "Drikke: " & cmbDrikke.Text & vbNewLine & "Antall drikke: " & numDrikke.Value & vbNewLine & "Mat: " & cmbMat.Text & vbNewLine & "Antall mat: " & numMat.Value & vbNewLine & vbNewLine & " Bekreftelse på registering ")
            btnTøm.PerformClick()

            'lukke connetion med database
            minConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class