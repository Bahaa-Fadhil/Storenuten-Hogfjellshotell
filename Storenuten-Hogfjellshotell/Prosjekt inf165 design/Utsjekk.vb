Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing


Public Class Utsjekk

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

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

    Private Sub Utsjekk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PrintDialog1.Document = PrintDocument1

        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()
        lblEtternavn.Text = ""
        lblFornavn.Text = ""
        lblTelefonNr.Text = ""
        lblRomnr.Text = ""
        lblRomPris.Text = ""
        lblAntallPerosner.Text = ""
        lblAntallMat.Text = ""
        AntallDrikke.Text = ""
        lblDrikkPris.Text = ""
        lblMatPris.Text = ""
        lblAnnen.Text = ""
        lblAnnenPris.Text = ""
        lblTotalSum.Text = ""

        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today
        numRomNr.Value = 0
        numAntallDrikke.Value = 0
        numAntallMat.Value = 0

        'Clear datagridview
        DataGridViewUtsjekk.DataSource = Nothing
        DataGridViewUtsjekk.Rows.Clear()
        DataGridViewUtsjekk.Refresh()

        'Legge Resultat søk til Enabled
        GrpSøkeresultat.Enabled = False
        grRegistering.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewUtsjekk.Enabled = False

        lblEtternavn.Enabled = False
        lblFornavn.Enabled = False
        lblTelefonNr.Enabled = False
        lblRomnr.Enabled = False
        lblRomPris.Enabled = False
        lblAntallPerosner.Enabled = False
        lblAntallMat.Enabled = False
        AntallDrikke.Enabled = False
        lblDrikkPris.Enabled = False
        lblMatPris.Enabled = False
        lblAnnen.Enabled = False
        lblAnnenPris.Enabled = False
        lblTotalSum.Enabled = False



    End Sub

    Private Sub btnSøk_Click(sender As Object, e As EventArgs) Handles btnSøk.Click

        Try

            dtpFradato.Format = DateTimePickerFormat.Custom
            dtpFradato.CustomFormat = "yyyy-MM-dd"
            dtpTildato.Format = DateTimePickerFormat.Custom
            dtpTildato.CustomFormat = "yyyy-MM-dd"

            'Clear datagridview
            DataGridViewUtsjekk.DataSource = Nothing
            DataGridViewUtsjekk.Rows.Clear()
            DataGridViewUtsjekk.Refresh()

            'Legge Resultat søk til Enabled
            GrpSøkeresultat.Enabled = True
            grRegistering.Enabled = True
            btnRegiLag.Enabled = True
            DataGridViewUtsjekk.Enabled = True

            lblEtternavn.Enabled = True
            lblFornavn.Enabled = True
            lblTelefonNr.Enabled = True
            lblRomnr.Enabled = True
            lblRomPris.Enabled = True
            lblAntallPerosner.Enabled = True
            lblAntallMat.Enabled = True
            AntallDrikke.Enabled = True
            lblDrikkPris.Enabled = True
            lblMatPris.Enabled = True
            lblAnnen.Enabled = True
            lblAnnenPris.Enabled = True
            lblTotalSum.Enabled = True


            minConnection.Open() ' åpne connection med database
            Command.CommandText = "SELECT opphold.Romnr, personer.Fornavn, personer.Etternavn, personer.TlfNr,  bestillingstype.FraDato, bestillingstype.TilDato,pris.AntallPersoner, pris.AntallVoksen, pris.AntallBarn ,romservice.TypeService ,romservice.Rengjøring ,pris.PrisRengjøring , romservice.AntallDrikke, PrisDrikke, romservice.Drikke , romservice.AntallMat, romservice.Mat, PrisMat FROM bestillingstype, personer, opphold, pris, romservice  WHERE bestillingstype.RomNr = opphold.RomNr AND pris.RomNr = opphold.RomNr AND bestillingstype.TlfNr = personer.TlfNr AND romservice.RomNr = opphold.RomNr  AND opphold.RomNr = '" & numRomNr.Value & "' AND  Personer.TlfNr='" & txtTlf.Text & "'"
            Command.ExecuteNonQuery()

            minAdapter.SelectCommand = Command                      ' select sqlcommand 
            minAdapter.Fill(TabDataSet)                             ' Fill DataTable         

            DataGridViewUtsjekk.DataSource = TabDataSet           ' legge data til DataGridView 
            minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
            DataGridViewUtsjekk.Refresh()

            'lukke connetion med database
            minConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
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
            Dim Tilgjengelig As String = "Tilgjengelig"
            Dim tblLeietaker As New DataTable
            Dim eksistererTlf As Boolean = False
            Dim msg As New MsgBoxResult
            Dim Tøm As String = ""


            minConnection.Open()

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


            If eksisterer Then
                msg = MsgBox("Er du sikker på at du vil sjekker ut for " & vbNewLine & vbNewLine & "Telefon:  " & telefonnr & vbNewLine & "Navn:  " & fornavn & "  " & etternavn, MsgBoxStyle.YesNo)
                If msg = MsgBoxResult.Yes Then



                    Command.CommandText = " UPDATE `sn2016gr9`.personer SET PostNr=null, Fornavn =null, Etternavn=null,Gateadresse=null, Epost=null WHERE TlfNr ='" & txtTlf.Text & "';"
                    Command.ExecuteNonQuery()
                    Command.CommandText = " UPDATE `sn2016gr9`.Pris SET  AntallPersoner=null , AntallVoksen =null ,AntallBarn=null, AntallRom=null,PrisRengjøring=null, PrisDrikke=null, PrisMat=null WHERE RomNr ='" & lblRomnr.Text & "';"
                    Command.ExecuteNonQuery()


                    Command.CommandText = "UPDATE `sn2016gr9`.`rom` SET `RomStatus`='Tilengjelig'   WHERE `RomNr`='" & lblRomnr.Text & "'"
                    Command.ExecuteNonQuery()

                    MsgBox("Utsjekk registrert")
                    msg = MsgBox("Ønsker du å lagre Faktura.", MsgBoxStyle.YesNo)
                    If msg = MsgBoxResult.Yes Then
                        PrintDocument1.Print()
                        PrintDocument1.ToString()
                    Else
                        Exit Sub

                    End If

                    btnTøm.PerformClick()
                Else
                    MessageBox.Show("Utsjekk ikke registrert")
                    minConnection.Close()
                    Exit Sub
                End If

            End If

            minConnection.Close()
        Catch ex As Exception

            MessageBox.Show(ex.Message, "ERROR")
        End Try




    End Sub

    Private Sub btnTømskjema_Click(sender As Object, e As EventArgs) Handles btnTømskjema.Click


        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()
        lblEtternavn.Text = ""
        lblFornavn.Text = ""
        lblTelefonNr.Text = ""
        lblRomnr.Text = ""
        lblRomPris.Text = ""
        lblAntallPerosner.Text = ""
        lblAntallMat.Text = ""
        AntallDrikke.Text = ""
        lblDrikkPris.Text = ""
        lblMatPris.Text = ""
        lblAnnen.Text = ""
        lblAnnenPris.Text = ""
        lblTotalSum.Text = ""

        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today
        numRomNr.Value = 0
        numAntallDrikke.Value = 0
        numAntallMat.Value = 0

        'Clear datagridview
        DataGridViewUtsjekk.DataSource = Nothing
        DataGridViewUtsjekk.Rows.Clear()
        DataGridViewUtsjekk.Refresh()

        'Legge Resultat søk til Enabled
        GrpSøkeresultat.Enabled = False
        grRegistering.Enabled = False
        btnRegiLag.Enabled = False
        DataGridViewUtsjekk.Enabled = False

        lblEtternavn.Enabled = False
        lblFornavn.Enabled = False
        lblTelefonNr.Enabled = False
        lblRomnr.Enabled = False
        lblRomPris.Enabled = False
        lblAntallPerosner.Enabled = False
        lblAntallMat.Enabled = False
        AntallDrikke.Enabled = False
        lblDrikkPris.Enabled = False
        lblMatPris.Enabled = False
        lblAnnen.Enabled = False
        lblAnnenPris.Enabled = False
        lblTotalSum.Enabled = False




    End Sub

    Private Sub DataGridViewUtsjekk_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewUtsjekk.CellContentClick

        ' lese rad for DataGridViewUtsjekk og legge select rad for Hver label + plusse totallpris.
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewUtsjekk.Rows(e.RowIndex)

            lblTelefonNr.Text = Row.Cells("TlfNr").Value.ToString
            lblAntallPerosner.Text = Row.Cells("AntallPersoner").Value.ToString
            lblFornavn.Text = Row.Cells("Fornavn").Value.ToString
            lblEtternavn.Text = Row.Cells("Etternavn").Value.ToString
            lblRomnr.Text = Row.Cells("Romnr").Value.ToString
            AntallDrikke.Text = Row.Cells("AntallDrikke").Value.ToString
            lblAntallMat.Text = Row.Cells("AntallMat").Value.ToString
            lblRengjøring.Text = Row.Cells("Rengjøring").Value.ToString
            lblAnnen.Text = Row.Cells("Typeservice").Value.ToString
            lblDrikkPris.Text = Row.Cells(12).Value.ToString * Row.Cells(13).Value.ToString
            lblMatPris.Text = Row.Cells(15).Value.ToString * Row.Cells(17).Value.ToString
            lblRengjøringPris.Text = Row.Cells("PrisRengjøring").Value.ToString
            'Rom pris
            lblRomPris.Text = (Row.Cells(7).Value * 1290.0) + (Row.Cells(8).Value * 645.0)
            ' Totall sum
            lblTotalSum.Text = (Row.Cells(7).Value * 1290.0) + (Row.Cells(8).Value * 645.0) + Row.Cells(11).Value + Row.Cells(12).Value * Row.Cells(13).Value + Row.Cells(15).Value * Row.Cells(17).Value & "  Kr"


            DataGridViewUtsjekk.Update()
            DataGridViewUtsjekk.Refresh()
        End If
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub btnBetal_Click(sender As Object, e As EventArgs) Handles btnBetal.Click

        Try
            Dim TabRomUtsjekk As New DataTable

            ' slette alle data fra DataGridView
            DataGridViewUtsjekk.DataSource = Nothing
            DataGridViewUtsjekk.Rows.Clear()
            DataGridViewUtsjekk.Refresh()


            minConnection.Open()

            ' oppdater informasjon til Rom serive + mat og drikk
            Command.CommandText = "UPDATE `sn2016gr9`.`romservice` SET `TypeService`='" & txtAnnen.Text & "', `Rengjøring`='" & cmbTypeVask.Text & "', `AntallMat`='" & numAntallMat.Value & "', `AntallDrikke`= '" & numAntallDrikke.Value & "' WHERE `RomNr`='" & lblRomnr.Text & "'"
            Command.ExecuteNonQuery()

            'Oppdater data for Pris table 
            Command.CommandText = "UPDATE `sn2016gr9`.`pris` SET  `PrisRengjøring`= '" & txtPrisRen.Text & "', `PrisDrikke` = '" & numAntallDrikke.Value * txtPrisDrikke.Text & "', `PrisMat` = '" & numAntallMat.Value * txtPrisMat.Text & "' WHERE `RomNr`='" & lblRomnr.Text & "' "
            Command.ExecuteNonQuery()


            minAdapter.SelectCommand = Command
            minAdapter.Fill(TabRomUtsjekk)
            'oppdater Tabelen
            DataGridViewUtsjekk.Update()

            ' vise lagret data i en MessageBox
            MessageBox.Show("Informasjon lagret. " & vbNewLine & vbNewLine & "Romnr: " & vbTab & lblRomnr.Text & vbNewLine & "Antall Drikke: " & vbTab & numAntallDrikke.Value & vbTab & "Pris " & vbTab & numAntallDrikke.Value * txtPrisDrikke.Text & vbNewLine & "Antall Mat: " & vbTab & numAntallMat.Value & vbTab & "Pris: " & vbTab & numAntallMat.Value * txtPrisMat.Text & vbNewLine & vbNewLine & "Annen: " & vbTab & vbTab & txtAnnen.Text & vbTab & "Pris: " & vbTab & txtAnnenPris.Text & vbNewLine & "Rengjøring: " & vbTab & cmbTypeVask.Text & vbTab & "Pris: " & vbTab & txtPrisRen.Text & vbNewLine & vbNewLine & "Totall Sum: " & vbTab & txtPrisRen.Text + numAntallDrikke.Value * txtPrisDrikke.Text + numAntallMat.Value * txtPrisMat.Text + txtAnnenPris.Text & vbNewLine & vbNewLine & " Total sum er registert, vennligst ta Betalling for opphold + utgifter.  ")
            ' btnTøm.PerformClick()

            DataGridViewUtsjekk.Update()
            DataGridViewUtsjekk.Refresh()

            'lukke connetion med database
            minConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' printer Faktura
        Dim Reportfont As Font = New Drawing.Font("Time New Roman", 12)
        e.Graphics.DrawRectangle(Pens.Red, e.MarginBounds)
        e.Graphics.DrawString(vbNewLine & vbNewLine & " Stornuten hotell  " & vbNewLine & vbNewLine, Reportfont, Brushes.Black, 360, 100)


        e.Graphics.DrawString("Gjesten informasjon:  ", Reportfont, Brushes.Black, 100, 200)
        e.Graphics.DrawString("Fornavn:  " & lblFornavn.Text, Reportfont, Brushes.Black, 100, 240)
        e.Graphics.DrawString("Etternavn:  " & lblEtternavn.Text, Reportfont, Brushes.Black, 100, 280)
        e.Graphics.DrawString("Telefonnr:  " & lblTelefonNr.Text & vbNewLine, Reportfont, Brushes.Black, 100, 320)

        e.Graphics.DrawString("Opphold utgifter:   ", Reportfont, Brushes.Black, 100, 360)

        e.Graphics.DrawString("Romnr:  " & lblRomnr.Text, Reportfont, Brushes.Black, 100, 400)
        e.Graphics.DrawString("Rom pris:  " & lblRomPris.Text, Reportfont, Brushes.Black, 100, 440)
        e.Graphics.DrawString("Antall perosner  " & lblAntallPerosner.Text, Reportfont, Brushes.Black, 100, 480)

        e.Graphics.DrawString("Antall drikke:  " & AntallDrikke.Text, Reportfont, Brushes.Black, 100, 520)
        e.Graphics.DrawString("Antall mat:  " & lblAntallMat.Text, Reportfont, Brushes.Black, 100, 560)
        e.Graphics.DrawString("Pris drikke:  " & lblDrikkPris.Text, Reportfont, Brushes.Black, 100, 600)
        e.Graphics.DrawString("Pris mat:  " & lblMatPris.Text, Reportfont, Brushes.Black, 100, 640)

        e.Graphics.DrawString("Rengjøring:  " & lblRengjøring.Text, Reportfont, Brushes.Black, 100, 680)
        e.Graphics.DrawString("pris rengjøring:  " & lblRengjøringPris.Text, Reportfont, Brushes.Black, 100, 720)
        e.Graphics.DrawString("Annen service:  " & lblAnnen.Text, Reportfont, Brushes.Black, 100, 760)
        e.Graphics.DrawString("pris annen service:  " & lblAnnenPris.Text & vbNewLine, Reportfont, Brushes.Black, 100, 800)

        e.Graphics.DrawString("Total sum:  " & lblTotalSum.Text, Reportfont, Brushes.Black, 100, 860)


    End Sub
End Class