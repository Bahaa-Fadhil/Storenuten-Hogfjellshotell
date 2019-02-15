Imports MySql.Data.MySqlClient
Imports System.Data

Public Class BestRes
    Dim connct As New MySqlConnection
    Dim sqlCommad As New MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNyBes.Click
        Me.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnAvbes.Click
        Me.Hide()
        Avbestill.Show()

    End Sub

    Private Sub btnInnsjekk_Click(sender As Object, e As EventArgs) Handles btnInnsjekk.Click
        Me.Hide()
        Innsjekk.Show()
    End Sub

    Private Sub btnOpphold_Click(sender As Object, e As EventArgs) Handles btnOpphold.Click
        Me.Hide()
        Opphold.Show()
    End Sub

    Private Sub btnUtsjekk_Click(sender As Object, e As EventArgs) Handles btnUtsjekk.Click
        Me.Hide()
        Utsjekk.Show()
    End Sub

    Private Sub btnEndre_Click(sender As Object, e As EventArgs) Handles btnEndre.Click
        Me.Hide()
        Endreinfo.Show()
    End Sub

    Private Sub btnReng_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnValg_Click(sender As Object, e As EventArgs) Handles btnValg.Click
        Me.Hide()
        Valgmuligheter.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAvslutt.Click

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



        Dim PrisVoksen, PrisBarn, TotallPris As Integer
        Dim tildato As String = dtpTildato.Text
        Dim fradato As String = dtpFradato.Text

        PrisVoksen = numVoksne.Value * (1290.0)                     ' Beregn Pris for voksen
        PrisBarn = numBarn.Value * (645.0)                          ' Beregn Pris for barn
        TotallPris = PrisVoksen + PrisBarn                          ' Beregn Total pris
        lblTotalPris.Text = TotallPris                              ' Vise Total Pris

        lblAntallVoksne.Text = numVoksne.Value                      ' Vise Antall Barn
        lblAntallBarn.Text = numBarn.Value                          ' Vise Antall Voksen




        If chkFamilie.Checked And chkDobbelt.Checked Then                                   ' Hvis familierom velgt

            lblRomType.Text = "Dobbeltrom" & " + " & "Familierom"

        ElseIf chkDobbelt.Checked Then                              ' Hvis Dobbeltrom velgt
            lblRomType.Text = "Dobbeltrom"
            lblAntallrom.Text = AntallDobRom.Value

        ElseIf chkFamilie.Checked Then                              ' Hvis familierom og Dobbeltrom velgt
            lblRomType.Text = "Familierom"
            lblAntallrom.Text = AntallFamRom.Value
        Else
            lblRomType.Text = ""
        End If



        ' Sjekk hvilke Type bestilling ble utført
        If chkBestilling.Checked Then                                     '  Hvis bestilling velgt
            lblTypebestilling.Text = "Bestilling"

        ElseIf chkReservasjon.Checked Then                                '  Hvis Reservasjon velgt
            lblTypebestilling.Text = "Reservasjon"
        Else
            lblTypebestilling.Text = ""                                   '  Hvis ingenting er velgt
        End If



        ' sjekk om dato som ble valgt er riktig, altså ikke bakover dato 
        If dtpFradato.Value < Today.Date Then
            MessageBox.Show("Du må velge riktig 'Fra dato' !")
            Exit Sub
        ElseIf dtpTildato.Value < dtpFradato.Value Then
            MessageBox.Show("Du må velge riktig 'Til Dato' !")
            Exit Sub

        End If

        '  dtpFradato.Value = Date.Today
        dtpFradato.Format = DateTimePickerFormat.Custom
        dtpFradato.CustomFormat = "yyyy-MM-dd"
        ' dtpTildato.Value = Date.Today
        dtpTildato.Format = DateTimePickerFormat.Custom
        dtpTildato.CustomFormat = "yyyy-MM-dd"

        lblFraDato.Text = fradato                                   ' Vise Fra Dato
        lblTilDato.Text = tildato                                   ' Vise Til Dato




        Try
            ' Clear dataGridView Først
            DataGridViewBestiling.DataSource = Nothing
            DataGridViewBestiling.Rows.Clear()
            DataGridViewBestiling.Refresh()


            ' Legge Resultat søk til Enabled
            grpResultat.Enabled = True
            '  grpGenelinfo.Enabled = True
            btnRegiLag.Enabled = True
            DataGridViewBestiling.Enabled = True

            txtEtternavn.Enabled = True
            txtFornavn.Enabled = True
            txtTlf.Enabled = True
            lblFraDato.Enabled = True
            lblTilDato.Enabled = True
            lblRomType.Enabled = True
            lblAntallVoksne.Enabled = True
            lblAntallBarn.Enabled = True
            lblAntallrom.Enabled = True
            lblRomType.Enabled = True
            lblTotalPris.Enabled = True
            lblTypebestilling.Enabled = True
            lblRomNr.Enabled = True


            ' søker etter Familierom
            If chkFamilie.Checked Then

                minConnection.Open() ' åpne connection med database

                ' Select for å finne ledig rom 
                Dim QueryFamili As String = "Select  rom.RomNr, rom.RomStatus, rom.RomType, bestillingstype.FraDato, bestillingstype.TilDato,bestillingstype.TypeBestilling  From bestillingstype RIGHT JOIN rom ON bestillingstype.romnr=rom.romnr and (bestillingstype.FraDato >= '2016-04-01' and bestillingstype.TilDato <= '2016-04-25' ) WHERE RomStatus='tilgjengelig' and RomType = 'Familierom' ;"

                ' legge select på en string
                Command = New MySqlCommand(QueryFamili, minConnection)
                minAdapter.SelectCommand = Command                      ' select sqlcommand 
                minAdapter.Fill(TabDataSet)                             ' Fill DataTable

                DataGridViewBestiling.DataSource = TabDataSet           ' legge data til DataGridView 
                minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
                DataGridViewBestiling.Refresh()


                ' søker etter  Dobbeltrom
            ElseIf chkDobbelt.Checked Then


                ' Select for å finne ledig rom 
                Dim QueryDobbel As String = "Select  rom.RomNr, rom.RomStatus, rom.RomType, bestillingstype.FraDato, bestillingstype.TilDato,bestillingstype.TypeBestilling  From bestillingstype RIGHT JOIN rom ON bestillingstype.romnr=rom.romnr and (bestillingstype.FraDato >= '2016-04-01' and bestillingstype.TilDato <= '2016-04-25' ) WHERE RomStatus= 'Tilgjengelig' and RomType = 'Dobbeltrom' ;"

                ' legge select på en string
                Command = New MySqlCommand(QueryDobbel, minConnection)  ' legge select Qurer og connection sammen

                minAdapter.SelectCommand = Command                      ' select sqlcommand 
                minAdapter.Fill(TabDataSet)                             ' Fill DataTable

                DataGridViewBestiling.DataSource = TabDataSet           ' legge data til DataGridView 
                minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
                DataGridViewBestiling.Refresh()


                'Hvis listen er tom er det ingen Rom å vise
                If DataGridViewBestiling.Rows.Count = 0 Then
                    MessageBox.Show("Ingen rom å vise med valgte søkekriterer")
                End If


            End If

            minConnection.Close()                                   ' Close connection 
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            minConnection.Dispose()
        End Try

    End Sub

    Private Sub btnRegiLag_Click(sender As Object, e As EventArgs) Handles btnRegiLag.Click

        Try
            dtpFradato.Format = DateTimePickerFormat.Custom
            dtpFradato.CustomFormat = "yyyy-MM-dd"
            dtpTildato.Format = DateTimePickerFormat.Custom
            dtpTildato.CustomFormat = "yyyy-MM-dd"


            Dim eksisterer As Boolean = False
            Dim telefonnr As String = ""
            Dim fornavn As String = ""
            Dim etternavn As String = ""
            Dim RomNr As String = ""
            Dim tildato As String = dtpTildato.Text
            Dim fradato As String = dtpFradato.Text
            Dim Utilengelig As String = "Utilengelig"

            Dim tblLeietaker As New DataTable
            Dim eksistererTlf As Boolean = False
            Dim msg As New MsgBoxResult

            ' sjekke gjennom tabler om kunde er register frafør
            Command.CommandText = "SELECT personer.TlfNr, personer.Fornavn, personer.Etternavn from personer where TlfNr = '" & txtTlf.Text & "'"
            minAdapter.Fill(tblLeietaker)

            For Each row As DataRow In tblLeietaker.Rows
                If CStr(row("TlfNr")) = txtTlf.Text Then
                    eksisterer = True
                    telefonnr = CStr(row("TlfNr"))
                    fornavn = CStr(row("Fornavn"))
                    etternavn = CStr(row("Etternavn"))
                End If
            Next


            ' Hivs det er Bestilling så skjer dette.
            If chkBestilling.Checked Then

                ' åpne kontakt med database 
                minConnection.Open()

                ' hvis kunder eksisterer fra før  så hente kunde info
                If eksisterer Then
                    msg = MsgBox("Gjesten eksisterer frafør, vil du registere opphold på sammen gjestnr! " & vbNewLine & "Telefon: " & telefonnr & vbNewLine & "Navn: " & fornavn & "  " & etternavn, MsgBoxStyle.YesNo)
                    If msg = MsgBoxResult.Yes Then

                        For Each row As DataRow In tblLeietaker.Rows
                            If CStr(row("TlfNr")) = txtTlf.Text Then
                                eksisterer = True
                                txtTlf.Text = CStr(row("TlfNr"))
                                txtFornavn.Text = CStr(row("Fornavn"))
                                txtEtternavn.Text = CStr(row("Etternavn"))
                            End If
                        Next


                        Command.CommandText = "UPDATE `sn2016gr9`.`BestillingsType` SET `FraDato`='" & lblFraDato.Text & "', `RomNr`='" & lblRomNr.Text & "', `TilDato`='" & lblTilDato.Text & "', `TypeBestilling`='" & lblTypebestilling.Text & "', `AntallPersoner`='" & numVoksne.Value + numBarn.Value & "', `AntallVoksen`='" & lblAntallVoksne.Text & "', `AntallBarn`='" & lblAntallBarn.Text & "', `AntallRom`='" & lblAntallrom.Text & "' WHERE  `TlfNr`= '" & txtTlf.Text & "' "

                        Command.CommandText = "UPDATE `sn2016gr9`.`pris` SET `RomNr`='" & lblRomNr.Text & "', `AntallPersoner`='" & numVoksne.Value + numBarn.Value & "', `AntallVoksen`='" & lblAntallVoksne.Text & "', `AntallBarn`='" & lblAntallBarn.Text & "' WHERE `RomNr`='" & lblRomNr.Text & "'"

                        'Oppdatere data for Rom table 
                        Dim QueryBestRomUpDatEkses As String = "UPDATE `sn2016gr9`.`rom` SET `RomStatus`= '" & Utilengelig & "' , `TlfNr`= '" & txtTlf.Text & "'  WHERE `RomNr`='" & lblRomNr.Text & "'"
                        Command = New MySqlCommand(QueryBestRomUpDatEkses, minConnection)
                        Command.ExecuteNonQuery()


                        MsgBox("Bestillingen registrert " & vbNewLine & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "Fra dato: " & lblFraDato.Text & vbNewLine & "Til dato: " & lblTilDato.Text & vbNewLine & "Rom Type: " & lblRomType.Text & vbNewLine & "Antall rom: " & lblAntallrom.Text & vbNewLine & "Antall voksne: " & lblAntallVoksne.Text & vbNewLine & "Antall barn: " & lblAntallBarn.Text & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "RomNr: " & lblRomNr.Text & vbNewLine & "Total pris: " & lblTotalPris.Text & vbNewLine & vbNewLine & " Takk ")
                        btnTøm.PerformClick()
                    Else
                        MessageBox.Show("Bestillingen ikke registrert ")
                        minConnection.Close()
                        Exit Sub
                    End If


                    ' hvis den ikke eksesterer frafør da register ny gjest
                Else
                    msg = MsgBox("Telefonnr er ikke registrert fra før, vennligst registrer ny gjest eller prøv et annet telefonnr", MsgBoxStyle.YesNo)

                    If msg = MsgBoxResult.Yes Then

                        'Insort data for Personer table 
                        Dim QueryBestPerson As String = "INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `Fornavn`, `Etternavn`) VALUES ('" & txtTlf.Text & "', '" & txtFornavn.Text & "', '" & txtEtternavn.Text & "');"
                        Command = New MySqlCommand(QueryBestPerson, minConnection)
                        Command.ExecuteNonQuery()

                        'Insort data for bestillingstyps table 
                        Dim QueryBest As String = "INSERT INTO sn2016gr9.Bestillingstype (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallRom`) VALUES('" & lblFraDato.Text & "','" & txtTlf.Text & "', '" & lblRomNr.Text & "' ,'" & lblTilDato.Text & "', '" & lblTypebestilling.Text & "' ,'" & numVoksne.Value + numBarn.Value & "', '" & lblAntallrom.Text & "');"
                        Command = New MySqlCommand(QueryBest, minConnection)
                        Command.ExecuteNonQuery()

                        'Insort data for Pris table 
                        Dim QueryBestPris As String = "INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallRom`) VALUES ('" & lblRomNr.Text & "', '" & numVoksne.Value + numBarn.Value & "', '" & lblAntallrom.Text & "');"
                        Command = New MySqlCommand(QueryBestPris, minConnection)
                        Command.ExecuteNonQuery()


                        'Oppdatere data for Rom table 
                        Dim QueryBestRomUpDat As String = "UPDATE `sn2016gr9`.`rom` SET `RomStatus`= '" & Utilengelig & "' , `TlfNr`= '" & txtTlf.Text & "'  WHERE `RomNr`='" & lblRomNr.Text & "'"
                        Command = New MySqlCommand(QueryBestRomUpDat, minConnection)
                        Command.ExecuteNonQuery()

                        ' open the command and read the data from the database for
                        Dim ReadBest As MySqlDataReader
                        ReadBest = Command.ExecuteReader


                        ''oppdater Tabelen
                        'DataGridViewBestiling.Update()

                        ' vise lagret data i en MessageBox
                        MessageBox.Show("Informasjon lagret. " & vbNewLine & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "Fra dato: " & lblFraDato.Text & vbNewLine & "Til dato: " & lblTilDato.Text & vbNewLine & "Rom Type: " & lblRomType.Text & vbNewLine & "Antall rom: " & lblAntallrom.Text & vbNewLine & "Antall voksne: " & lblAntallVoksne.Text & vbNewLine & "Antall barn: " & lblAntallBarn.Text & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "RomNr: " & lblRomNr.Text & vbNewLine & "Total pris: " & lblTotalPris.Text & vbNewLine & vbNewLine & "Bekrefte bestillingen !")
                        minConnection.Close()
                        Exit Sub

                    Else
                        MessageBox.Show("Bestillingen ikke registrert")
                        minConnection.Close()
                        Exit Sub
                    End If

                End If

                ' close the connection to the database
                minConnection.Close()




                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ' Eller Hivs det er Reservasjon så skjer dette.
            ElseIf chkReservasjon.Checked Then

                ' åpne kontakt med database 
                minConnection.Open()

                If eksisterer Then
                    msg = MsgBox("Gjesten eksisterer frafør, vil du registere opphold på sammen gjestnr! " & vbNewLine & "Telefon: " & telefonnr & vbNewLine & "Navn: " & fornavn & "  " & etternavn, MsgBoxStyle.YesNo)
                    If msg = MsgBoxResult.Yes Then

                        For Each row As DataRow In tblLeietaker.Rows
                            If CStr(row("TlfNr")) = txtTlf.Text Then
                                eksisterer = True
                                txtTlf.Text = CStr(row("TlfNr"))
                                txtFornavn.Text = CStr(row("Fornavn"))
                                txtEtternavn.Text = CStr(row("Etternavn"))
                            End If
                        Next

                        ' oppdater data for bestillingestype tabell
                        Command.CommandText = "UPDATE `sn2016gr9`.`BestillingsType` SET `FraDato`='" & lblFraDato.Text & "', `RomNr`='" & lblRomNr.Text & "', `TilDato`='" & lblTilDato.Text & "', `TypeBestilling`='" & lblTypebestilling.Text & "', `AntallPersoner`='" & numVoksne.Value + numBarn.Value & "', `AntallVoksen`='" & lblAntallVoksne.Text & "', `AntallBarn`='" & lblAntallBarn.Text & "', `AntallRom`='" & lblAntallrom.Text & "' WHERE  `TlfNr`= '" & txtTlf.Text & "' "

                        ' Oppdater data for pris tabell
                        Command.CommandText = "UPDATE `sn2016gr9`.`pris` SET `RomNr`='" & lblRomNr.Text & "', `AntallPersoner`='" & numVoksne.Value + numBarn.Value & "', `AntallVoksen`='" & lblAntallVoksne.Text & "', `AntallBarn`='" & lblAntallBarn.Text & "' WHERE `RomNr`='" & lblRomNr.Text & "'"

                        'Oppdatere data for Rom table 
                        Command.CommandText = "UPDATE `sn2016gr9`.`rom` SET `RomStatus`= '" & Utilengelig & "' , `TlfNr`= '" & txtTlf.Text & "'  WHERE `RomNr`='" & lblRomNr.Text & "'"
                        'Command = New MySqlCommand(QueryBestRomUpDatEkses, minConnection)
                        Command.ExecuteNonQuery()


                        MsgBox("Bestillingen registrert " & vbNewLine & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "Fra dato: " & lblFraDato.Text & vbNewLine & "Til dato: " & lblTilDato.Text & vbNewLine & "Rom Type: " & lblRomType.Text & vbNewLine & "Antall rom: " & lblAntallrom.Text & vbNewLine & "Antall voksne: " & lblAntallVoksne.Text & vbNewLine & "Antall barn: " & lblAntallBarn.Text & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "RomNr: " & lblRomNr.Text & vbNewLine & "Total pris: " & lblTotalPris.Text & vbNewLine & vbNewLine & " Takk ")
                        btnTøm.PerformClick()
                    Else
                        MessageBox.Show("Bestillingen ikke registrert ")
                        minConnection.Close()
                        Exit Sub
                    End If



                    ' hvis den ikke eksesterer frafør da register ny gjest
                Else
                    msg = MsgBox("Telefonnr er ikke registrert fra før, vennligst registrer ny gjest eller prøv et annet telefonnr", MsgBoxStyle.YesNo)

                    If msg = MsgBoxResult.Yes Then

                        'Insort data for Personer table 
                        Command.CommandText = "INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `Fornavn`, `Etternavn`) VALUES ('" & txtTlf.Text & "', '" & txtFornavn.Text & "', '" & txtEtternavn.Text & "');"
                        '  Command = New MySqlCommand(QueryBestPerson, minConnection)
                        Command.ExecuteNonQuery()

                        'Insort data for bestillingstyps table 
                        Command.CommandText = "INSERT INTO sn2016gr9.Bestillingstype (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallRom`) VALUES('" & lblFraDato.Text & "','" & txtTlf.Text & "', '" & lblRomNr.Text & "' ,'" & lblTilDato.Text & "', '" & lblTypebestilling.Text & "' ,'" & numVoksne.Value + numBarn.Value & "', '" & lblAntallrom.Text & "');"
                        ' Command = New MySqlCommand(QueryBest, minConnection)
                        Command.ExecuteNonQuery()

                        'Insort data for Pris table 
                        Command.CommandText = "INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallRom`) VALUES ('" & lblRomNr.Text & "', '" & numVoksne.Value + numBarn.Value & "', '" & lblAntallrom.Text & "');"
                        ' Command = New MySqlCommand(QueryBestPris, minConnection)
                        Command.ExecuteNonQuery()


                        'Oppdatere data for Rom table 
                        Command.CommandText = "UPDATE `sn2016gr9`.`rom` SET `RomStatus`= '" & Utilengelig & "' , `TlfNr`= '" & txtTlf.Text & "'  WHERE `RomNr`='" & lblRomNr.Text & "'"
                        '  Command = New MySqlCommand(QueryBestRomUpDat, minConnection)
                        Command.ExecuteNonQuery()

                        ' open the command and read the data from the database for
                        Dim ReadBest As MySqlDataReader
                        ReadBest = Command.ExecuteReader

                        ' vise lagret data i en MessageBox
                        MessageBox.Show("Informasjon lagret. " & vbNewLine & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "Fra dato: " & lblFraDato.Text & vbNewLine & "Til dato: " & lblTilDato.Text & vbNewLine & "Rom Type: " & lblRomType.Text & vbNewLine & "Antall rom: " & lblAntallrom.Text & vbNewLine & "Antall voksne: " & lblAntallVoksne.Text & vbNewLine & "Antall barn: " & lblAntallBarn.Text & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "RomNr: " & lblRomNr.Text & vbNewLine & "Total pris: " & lblTotalPris.Text & vbNewLine & vbNewLine & "Bekrefte bestillingen !")
                        minConnection.Close()
                        Exit Sub

                    Else
                        MessageBox.Show("Bestillingen ikke registrert")
                        minConnection.Close()
                        Exit Sub
                    End If

                End If







                ''Insort data for Personer table 
                'Dim QueryResvPerson As String = "INSERT INTO `sn2016gr9`.`personer` (`TlfNr`, `Fornavn`, `Etternavn`) VALUES ('" & txtTlf.Text & "', '" & txtFornavn.Text & "', '" & txtEtternavn.Text & "');"
                'Command = New MySqlCommand(QueryResvPerson, minConnection)
                'Command.ExecuteNonQuery()

                ''Insort data for bestillingstyps table 
                'Dim QueryResv As String = "INSERT INTO sn2016gr9.Bestillingstype (`FraDato`, `TlfNr`, `RomNr`, `TilDato`, `TypeBestilling`, `AntallPersoner`, `AntallRom`) VALUES('" & lblFraDato.Text & "','" & txtTlf.Text & "', '" & lblRomNr.Text & "' ,'" & lblTilDato.Text & "', '" & lblTypebestilling.Text & "' ,'" & numVoksne.Value + numBarn.Value & "', '" & lblAntallrom.Text & "');"
                'Command = New MySqlCommand(QueryResv, minConnection)
                'Command.ExecuteNonQuery()

                ''Insort data for Pris table 
                'Dim QueryResvPris As String = "INSERT INTO `sn2016gr9`.`pris` (`RomNr`, `AntallPersoner`, `AntallRom`) VALUES ('" & lblRomNr.Text & "', '" & numVoksne.Value + numBarn.Value & "', '" & lblAntallrom.Text & "');"
                'Command = New MySqlCommand(QueryResvPris, minConnection)
                'Command.ExecuteNonQuery()


                ''Oppdatere data for Rom table 
                'Dim QueryResvRomUpDat As String = "UPDATE `sn2016gr9`.`rom` SET `RomStatus`= '" & Utilengelig & "' , `TlfNr`= '" & txtTlf.Text & "'  WHERE `RomNr`='" & lblRomNr.Text & "'"
                'Command = New MySqlCommand(QueryResvRomUpDat, minConnection)
                'Command.ExecuteNonQuery()

                '' open the command and read the data from the database for
                'Dim ReadResv As MySqlDataReader
                'ReadResv = Command.ExecuteReader


                ''oppdater Tabelen
                '' DataGridViewBestiling.Update()

                '' vise lagret data i en MessageBox
                'MessageBox.Show("Informasjon lagret. " & vbNewLine & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "Fra dato: " & lblFraDato.Text & vbNewLine & "Til dato: " & lblTilDato.Text & vbNewLine & "Rom Type: " & lblRomType.Text & vbNewLine & "Antall rom: " & lblAntallrom.Text & vbNewLine & "Antall voksne: " & lblAntallVoksne.Text & vbNewLine & "Antall barn: " & lblAntallBarn.Text & vbNewLine & "Type bestilling: " & lblTypebestilling.Text & vbNewLine & "RomNr: " & lblRomNr.Text & vbNewLine & "Total pris: " & lblTotalPris.Text & vbNewLine & vbNewLine & "Bekrefte bestillingen !")
                ''btnTøm.PerformClick()

                '' close the connection to the database
                'minConnection.Close()

            Else
                MessageBox.Show("Du må sjekke alle informasjon på nytt, og prøv igjen.")
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message, "ERROR ")

        Finally
            minConnection.Dispose()
        End Try
    End Sub

    Private Sub DataGridViewBestiling_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewBestiling.CellContentClick

        ' lese rad for DataGridViewBestilling og legge select rad for RomNr.
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewBestiling.Rows(e.RowIndex)
            lblRomNr.Text = Row.Cells("RomNr").Value.ToString
            If lblRomType.Text = Row.Cells("RomType").Value.ToString Then
                grpGenelinfo.Enabled = True
            End If
            DataGridViewBestiling.Update()
            DataGridViewBestiling.Refresh()
        End If


    End Sub

    Private Sub dtpFradato_ValueChanged(sender As Object, e As EventArgs) Handles dtpFradato.ValueChanged


    End Sub

    Private Sub lblFraDato_Click(sender As Object, e As EventArgs) Handles lblFraDato.Click

    End Sub

    Private Sub Resultat_Enter(sender As Object, e As EventArgs) Handles Resultat.Enter

    End Sub

    Private Sub btnTøm_Click(sender As Object, e As EventArgs) Handles btnTøm.Click


        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()
        lblFraDato.Text = ""
        lblTilDato.Text = ""
        lblRomType.Text = ""
        lblAntallVoksne.Text = ""
        lblAntallBarn.Text = ""
        lblAntallrom.Text = ""
        lblRomType.Text = ""
        lblTotalPris.Text = ""
        lblTypebestilling.Text = ""
        lblRomNr.Text = ""
        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today
        numVoksne.Value = 0
        numBarn.Value = 0
        AntallDobRom.Value = 0
        AntallFamRom.Value = 0

        'Clear alle check bokser
        chkBestilling.Checked = vbEmpty
        chkReservasjon.Checked = vbEmpty
        chkFamilie.Checked = vbEmpty
        chkDobbelt.Checked = vbEmpty

        'Clear datagridview
        DataGridViewBestiling.DataSource = Nothing
        DataGridViewBestiling.Rows.Clear()
        DataGridViewBestiling.Refresh()

        ' Legge Resultat søk til Enabled
        grpResultat.Enabled = False
        grpGenelinfo.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewBestiling.Enabled = False

        txtEtternavn.Enabled = False
        txtFornavn.Enabled = False
        txtTlf.Enabled = False
        lblFraDato.Enabled = False
        lblTilDato.Enabled = False
        lblRomType.Enabled = False
        lblAntallVoksne.Enabled = False
        lblAntallBarn.Enabled = False
        lblAntallrom.Enabled = False
        lblRomType.Enabled = False
        lblTotalPris.Enabled = False
        lblTypebestilling.Enabled = False
        lblRomNr.Enabled = False


    End Sub

    Private Sub BestRes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'Spør brukeren om han avslutte programmet. 
        Dim DialogExit As DialogResult
        DialogExit = MessageBox.Show("Vil du virklig Avslutt Programmet.", "Exit", MessageBoxButtons.YesNoCancel)

        If DialogExit = DialogResult.No Then
            e.Cancel = True

        ElseIf DialogExit = DialogResult.Cancel Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub BestRes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Legge Resultat søk til Enabled
        grpResultat.Enabled = False
        grpGenelinfo.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewBestiling.Enabled = False

        txtEtternavn.Enabled = False
        txtFornavn.Enabled = False
        txtTlf.Enabled = False
        lblFraDato.Enabled = False
        lblTilDato.Enabled = False
        lblRomType.Enabled = False
        lblAntallVoksne.Enabled = False
        lblAntallBarn.Enabled = False
        lblAntallrom.Enabled = False
        lblRomType.Enabled = False
        lblTotalPris.Enabled = False
        lblTypebestilling.Enabled = False
        lblRomNr.Enabled = False

    End Sub
End Class