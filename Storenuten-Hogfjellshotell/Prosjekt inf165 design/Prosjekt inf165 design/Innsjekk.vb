Imports MySql.Data.MySqlClient

Public Class Innsjekk


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

    Private Sub btnSøk_Click(sender As Object, e As EventArgs) Handles btnSøk.Click

        Try

            dtpFradato.Format = DateTimePickerFormat.Custom
            dtpFradato.CustomFormat = "yyyy-MM-dd"
            dtpTildato.Format = DateTimePickerFormat.Custom
            dtpTildato.CustomFormat = "yyyy-MM-dd"
            Dim msg As New MsgBoxResult

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
            DataGridViewInnsjekk.DataSource = Nothing
            DataGridViewInnsjekk.Rows.Clear()
            DataGridViewInnsjekk.Refresh()

            ' Legge Resultat søk til Enabled
            grpResultatInnsjek.Enabled = True
            GrpRegisterInfoInsjekk.Enabled = True
            btnRegiLag.Enabled = True
            DataGridViewInnsjekk.Enabled = True
            lblFraDato.Enabled = True
            lblTilDato.Enabled = True
            lblRomType.Enabled = True
            lblAntallVoksne.Enabled = True
            lblAntallBarn.Enabled = True
            lblAntallrom.Enabled = True
            lblRomNr.Enabled = True
            lblEtternavn.Enabled = True
            lblFornavn.Enabled = True
            lblAntallPerosner.Enabled = True
            lblTelefonNr.Enabled = True


            minConnection.Open() ' åpne connection med database

            ' Select for å finne ledig rom 
            Command.CommandText = "Select personer.Fornavn, personer.Etternavn, bestillingstype.TlfNr, BestillingsType.FraDato, BestillingsType.Tildato, bestillingstype.AntallPersoner, BestillingsType.Antallvoksen, BestillingsType.Antallbarn, rom.RomNr, rom.RomType, rom.RomStatus,  bestillingstype.AntallRom  FROM personer,BestillingsType INNER JOIN rom ON bestillingstype.romnr = rom.romnr WHERE bestillingstype.TlfNr = personer.TlfNr  AND  bestillingstype.TlfNr='" & txtTlf.Text & "' AND BestillingsType.FraDato='" & dtpFradato.Text & "' AND BestillingsType.TilDato='" & dtpTildato.Text & "' AND  personer.fornavn='" & txtFornavn.Text & "'  AND  personer.etternavn='" & txtEtternavn.Text & "' "
            Command.ExecuteNonQuery()

            minAdapter.SelectCommand = Command                      ' select sqlcommand 
            minAdapter.Fill(TabDataSet)                             ' Fill DataTable         

            DataGridViewInnsjekk.DataSource = TabDataSet           ' legge data til DataGridView 
            minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
            DataGridViewInnsjekk.Refresh()

            minConnection.Close()                                   ' Close connection 
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            minConnection.Dispose()
        End Try


    End Sub

    Private Sub DataGridViewInnsjekk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInnsjekk.CellContentClick

        ' lese rad for DataGridViewInnsjekk og legge select rad for RomNr.
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewInnsjekk.Rows(e.RowIndex)

            lblAntallPerosner.Text = Row.Cells("AntallPersoner").Value.ToString
            lblAntallVoksne.Text = Row.Cells("AntallVoksen").Value.ToString
            lblAntallBarn.Text = Row.Cells("AntallBarn").Value.ToString
            lblFornavn.Text = Row.Cells("Fornavn").Value.ToString
            lblEtternavn.Text = Row.Cells("Etternavn").Value.ToString
            lblFraDato.Text = Row.Cells("FraDato").Value.ToString
            lblTilDato.Text = Row.Cells("TilDato").Value.ToString
            lblTelefonNr.Text = Row.Cells("TlfNr").Value.ToString
            lblRomType.Text = Row.Cells("RomType").Value.ToString
            lblRomNr.Text = Row.Cells("RomNr").Value.ToString
            lblAntallrom.Text = Row.Cells("AntallRom").Value.ToString

            DataGridViewInnsjekk.Update()
            DataGridViewInnsjekk.Refresh()
        End If
    End Sub

    Private Sub btnRegiLag_Click(sender As Object, e As EventArgs) Handles btnRegiLag.Click


        Try
            dtpFradato.Format = DateTimePickerFormat.Custom
            dtpFradato.CustomFormat = "yyyy-MM-dd"
            dtpTildato.Format = DateTimePickerFormat.Custom
            dtpTildato.CustomFormat = "yyyy-MM-dd"

            Dim eksisterer As Boolean = False
            Dim tildato As String = dtpTildato.Text
            Dim fradato As String = dtpFradato.Text
            Dim Innsjekket As String = "Innsjekket"
            Dim msg As New MsgBoxResult


            ' Sjekker gjest informasjon mo de er riktig 
            If Not IsNumeric(txtTlfNrRegister.Text) Or Not txtTlfNrRegister.Text.Length = 8 Then
                Throw New Exception("Telefonnr ikke gyldig")
            ElseIf txtFornavnRegister.Text.Length < 2 Then
                Throw New Exception("Fornavn ikke gyldig")
            ElseIf txtEtternavnRegister.Text.Length < 2 Then
                Throw New Exception("Etternavn ikke gyldig")
            ElseIf Not ekteEpost(txtEpostInnsjekk.Text) Then
                Throw New Exception("Epost er ikke gyldig")
                msg = MsgBox("Epost adresse er ikke gyldig, vil du registrere gjesten uten Epost?", MsgBoxStyle.YesNo)
                If msg = MsgBoxResult.No Then
                    Throw New Exception("Ikke registrert")
                End If
                txtEpostInnsjekk.Clear()

            ElseIf txtGateadresseInnsjekk.Text.Length < 3 Then
                msg = MsgBox("Gateadresse ikke gyldig, vil du registrere gjesten uten gateadresse?", MsgBoxStyle.YesNo)
                If msg = MsgBoxResult.No Then
                    Throw New Exception("Ikke registrert")
                End If
                txtGateadresseInnsjekk.Clear()
            End If


            ' sjekker postnr om der er ekte
            If txtPostnrInnsjekk.Text.Length <> 4 Then
                Throw New Exception("Postnr ikke gyldig")
            End If

            ' Sjekker epost om den er ekte Epost
            If txtEpostInnsjekk.Text = "" Then
                msg = MsgBox("Epostadresse ikke gyldig, vil du registrere gjesten uten Epost?", MsgBoxStyle.YesNo)
                If msg = MsgBoxResult.Yes Then

                    ' åpne kontakt med database 
                    minConnection.Open()
                    Command.CommandText = "UPDATE `sn2016gr9`.`personer` SET personer.tlfnr='" & txtTlfNrRegister.Text & "', `Fornavn` = '" & txtFornavnRegister.Text & "', `Etternavn`= '" & txtEtternavnRegister.Text & "', 'PostNr'='" & txtPostnrInnsjekk.Text & "', 'Gateadresse'= '" & txtGateadresseInnsjekk.Text & "'  WHERE `TlfNr`='" & lblTelefonNr.Text & "';"
                    Command.ExecuteNonQuery() ' personer.tlfnr='" & txtTlfNrRegister.Text & "',
                Else
                    Throw New Exception("Ikke registrert")
                    minConnection.Close()
                End If
            Else
                ' åpne kontakt med database 
                minConnection.Open()

                Command.CommandText = "UPDATE `sn2016gr9`.`personer` SET  personer.tlfnr='" & txtTlfNrRegister.Text & "', `Fornavn` = '" & txtFornavnRegister.Text & "', `Etternavn`= '" & txtEtternavnRegister.Text & "', 'PostNr'='" & txtPostnrInnsjekk.Text & "', 'Gateadresse'= '" & txtGateadresseInnsjekk.Text & "', 'Epost'='" & txtEpostInnsjekk.Text & "' WHERE `TlfNr`='" & lblTelefonNr.Text & "';"
                Command.ExecuteNonQuery()
            End If

            'Oppdatere data for Rom table 
            Command.CommandText &= "UPDATE `sn2016gr9`.`rom` SET `RomStatus`= '" & Innsjekket & "' WHERE `RomNr`='" & lblRomNr.Text & "'; "
            Command.ExecuteNonQuery()

            ' open the command and read the data from the database for
            Dim ReadInnsjekk As MySqlDataReader
            ReadInnsjekk = Command.ExecuteReader


            'oppdater Tabelen
            DataGridViewInnsjekk.Update()
            ' vise lagret data i en MessageBox
            MessageBox.Show("Informasjon lagret. " & vbNewLine & vbNewLine & "Fornavn: " & lblFornavn.Text & vbNewLine & "Etternavn: " & lblEtternavn.Text & vbNewLine & "Telefonnr: " & lblTelefonNr.Text & vbNewLine & "Epost: " & txtEpostInnsjekk.Text & vbNewLine & "Gateadresse: " & txtGateadresseInnsjekk.Text & vbNewLine & "Postnr: " & txtPostnrInnsjekk.Text & vbNewLine & "RomNr: " & numRomnrInnsjekk.Value.ToString & vbNewLine & "Fra Dato: " & lblFraDato.Text & vbNewLine & "Til Dato: " & lblTilDato.Text & vbNewLine & "Type Rom: " & lblRomType.Text & vbNewLine & "Antall Rom: " & lblAntallrom.Text & vbNewLine & "Antall Perosner: " & lblAntallPerosner.Text & vbNewLine & vbNewLine & "Bekrefte bestillingen !")

            ' close the connection to the database
            minConnection.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ResultatInnsjekk_Enter(sender As Object, e As EventArgs) Handles ResultatInnsjekk.Enter

    End Sub

    Private Sub btnTøm_Click(sender As Object, e As EventArgs) Handles btnTøm.Click


        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()
        txtFornavnRegister.Clear()
        txtEtternavnRegister.Clear()
        txtEpostInnsjekk.Clear()
        txtGateadresseInnsjekk.Clear()
        txtPostnrInnsjekk.Clear()
        txtTlfNrRegister.Clear()
        lblFraDato.Text = ""
        lblTilDato.Text = ""
        lblFornavn.Text = ""
        lblEtternavn.Text = ""
        lblTelefonNr.Text = ""
        lblAntallPerosner.Text = ""

        lblAntallVoksne.Text = ""
        lblAntallBarn.Text = ""
        lblAntallrom.Text = ""
        lblRomNr.Text = ""
        lblRomType.Text = ""

        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today
        numRomnrInnsjekk.Value = 0



        'Clear datagridview
        DataGridViewInnsjekk.DataSource = Nothing
        DataGridViewInnsjekk.Rows.Clear()
        DataGridViewInnsjekk.Refresh()

        ' Legge Resultat søk til Enabled
        grpResultatInnsjek.Enabled = False
        GrpRegisterInfoInsjekk.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewInnsjekk.Enabled = False


        lblFraDato.Enabled = False
        lblTilDato.Enabled = False
        lblRomType.Enabled = False
        lblAntallVoksne.Enabled = False
        lblAntallBarn.Enabled = False
        lblAntallrom.Enabled = False
        lblRomNr.Enabled = False
        lblEtternavn.Enabled = False
        lblFornavn.Enabled = False
        lblAntallPerosner.Enabled = False
        lblTelefonNr.Enabled = False




    End Sub

    Private Sub Innsjekk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Legge Resultat søk til Enabled
        grpResultatInnsjek.Enabled = False
        GrpRegisterInfoInsjekk.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewInnsjekk.Enabled = False


        lblFraDato.Enabled = False
        lblTilDato.Enabled = False
        lblRomType.Enabled = False
        lblAntallVoksne.Enabled = False
        lblAntallBarn.Enabled = False
        lblAntallrom.Enabled = False
        lblRomNr.Enabled = False
        lblEtternavn.Enabled = False
        lblFornavn.Enabled = False
        lblAntallPerosner.Enabled = False
        lblTelefonNr.Enabled = False


    End Sub
End Class