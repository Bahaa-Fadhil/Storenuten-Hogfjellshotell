Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Avbestill

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        BestRes.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Show()
    End Sub

    Private Sub btnInnsjekk_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Innsjekk.Show()
    End Sub

    Private Sub btnOpphold_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Opphold.Show()
    End Sub

    Private Sub btnUtsjekk_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Utsjekk.Show()
    End Sub

    Private Sub btnEndre_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Endreinfo.Show()
    End Sub




    Private Sub btnValg_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Valgmuligheter.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()

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
    End Sub

    Private Sub btnInnsjekk_Click_1(sender As Object, e As EventArgs) Handles btnInnsjekk.Click
        Innsjekk.Show()
        Me.Hide()
    End Sub

    Private Sub btnOpphold_Click_1(sender As Object, e As EventArgs) Handles btnOpphold.Click
        Opphold.Show()
        Me.Hide()
    End Sub

    Private Sub btnUtsjekk_Click_1(sender As Object, e As EventArgs) Handles btnUtsjekk.Click
        Utsjekk.Show()
        Me.Hide()
    End Sub

    Private Sub btnEndre_Click_1(sender As Object, e As EventArgs) Handles btnEndre.Click
        Endreinfo.Show()
        Me.Hide()
    End Sub

    Private Sub btnReng_Click_1(sender As Object, e As EventArgs) 

    End Sub

    Private Sub btnValg_Click_1(sender As Object, e As EventArgs) Handles btnValg.Click
        Valgmuligheter.Show()
        Me.Hide()

    End Sub

    Private Sub btnSøk_Click(sender As Object, e As EventArgs) Handles btnSøk.Click

        Try

            Dim d As DateTime = DateTime.Today.AddDays(1)


            'Clear datagridview
            DataGridViewAvbestilling.DataSource = Nothing
            DataGridViewAvbestilling.Rows.Clear()
            DataGridViewAvbestilling.Refresh()
            DataGridViewAvbestilling.Enabled = True

            ' Legge Resultat søk til Enabled
            grpResultat.Enabled = True
            txtEtternavn.Enabled = True
            txtFornavn.Enabled = True
            txtTlf.Enabled = True
            lblFraDato.Enabled = True
            lblRomNr.Enabled = True
            btnRegiLag.Enabled = True

            dtpFradato.Format = DateTimePickerFormat.Custom
            dtpFradato.CustomFormat = "yyyy-MM-dd"

            dtpTildato.Format = DateTimePickerFormat.Custom
            dtpTildato.CustomFormat = "yyyy-MM-dd"

            Dim tildato As String = dtpTildato.Text
            Dim fradato As String = dtpFradato.Text
            Dim romNr As String = numRomNr.Value.ToString
            Dim fornavn As String = txtFornavn.Text
            Dim etternavn As String = txtEtternavn.Text


            minConnection.Open() ' åpne connection med database

            Command.CommandText = "SELECT avbestilling.FraDato, avbestilling.TlfNr, avbestilling.RomNr, personer.Fornavn, personer.Etternavn, Rom.RomType  From avbestilling, bestillingstype, Personer, rom   where avbestilling.FraDato = bestillingstype.FraDato AND avbestilling.TlfNr=bestillingstype.TlfNr AND avbestilling.TlfNr = personer.TlfNr AND (avbestilling.TlfNr = '" & txtTlf.Text & "') OR (personer.Fornavn ='" & txtFornavn.Text & "') OR (personer.Etternavn ='" & txtEtternavn.Text & "') AND (bestillingstype.FraDato >= '" & dtpFradato.Value.ToString & "' ) And (bestillingstype.TilDato <= '" & dtpTildato.Value.ToString & "') group by avbestilling.FraDato, avbestilling.TlfNr, avbestilling.RomNr ;"
            Command.ExecuteNonQuery()


            minAdapter.SelectCommand = Command                      ' select sqlcommand 
            minAdapter.Fill(TabDataSet)                             ' Fill DataTable

            DataGridViewAvbestilling.DataSource = TabDataSet           ' legge data til DataGridView 
            minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
            DataGridViewAvbestilling.Refresh()

            minConnection.Close()                                   ' Close connection 
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            minConnection.Dispose()
        End Try



    End Sub

    Private Sub DataGridViewAvbestilling_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAvbestilling.CellContentClick

        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewAvbestilling.Rows(e.RowIndex)
            lblFraDato.Text = Row.Cells("FraDato").Value.ToString
            lblRomNr.Text = Row.Cells("RomNr").Value.ToString
            lblTlfnr.Text = Row.Cells("Tlfnr").Value.ToString
            lblFornavn.Text = Row.Cells("Fornavn").Value.ToString
            lblEtternavn.Text = Row.Cells("Etternavn").Value.ToString
            lblRomType.Text = Row.Cells("RomType").Value.ToString

            DataGridViewAvbestilling.Update()
            DataGridViewAvbestilling.Refresh()
        End If


    End Sub

    Private Sub Avbestill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim d As DateTime = DateTime.Today.AddDays(1)

        txtTlf.Clear()
        dtpFradato.Value = Today()
        dtpTildato.Value = d
        numRomNr.Value = 0

        lblFraDato.Text = ""
        lblRomNr.Text = ""
        lblTlfnr.Text = ""
        txtEtternavn.Text = ""
        txtFornavn.Text = ""
        txtTlf.Text = ""

        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()
        lblFraDato.Text = ""
        lblRomNr.Text = ""
        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today
        numRomNr.Value = 0


        'Clear datagridview
        DataGridViewAvbestilling.DataSource = Nothing
        DataGridViewAvbestilling.Rows.Clear()
        DataGridViewAvbestilling.Refresh()
        DataGridViewAvbestilling.Enabled = False

        ' Legge Resultat søk til Enabled
        grpResultat.Enabled = False
        lblFraDato.Enabled = False
        lblRomNr.Enabled = False
        btnRegiLag.Enabled = False




    End Sub

    Private Sub btnRegiLag_Click(sender As Object, e As EventArgs) Handles btnRegiLag.Click
        Try
            DataGridViewAvbestilling.DataSource = Nothing
            DataGridViewAvbestilling.Rows.Clear()
            DataGridViewAvbestilling.Refresh()
            DataGridViewAvbestilling.Update()


            minConnection.Open() ' åpne connection med database
            If lblTlfnr.Text = "" Then
                MessageBox.Show("Vennligst skriv inn et telefon nummer!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf lblRomNr.Text = "" Then
                MessageBox.Show("Vennligst Velg et RomNr!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else




                Dim QueryAvbesBest As String = " DELETE FROM Bestillingstype WHERE TlfNr ='" & txtTlf.Text & "';"
                Dim QueryAvbesPers As String = " DELETE FROM personer WHERE TlfNr ='" & txtTlf.Text & "';"
                Dim QueryAvbesPris As String = " DELETE FROM pris WHERE RomNr ='" & numRomNr.Value & "';"
                Dim RomTilgjengelig As String = "UPDATE `sn2016gr9`.`rom` Set `RomStatus`= 'Tilgjengelig' WHERE `RomNr`='" & numRomNr.Value & "';"


                If txtTlf.Text <> "" Then
                    If MsgBox("Vil du avbestille denne bookingen ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


                        Command.CommandText = QueryAvbesBest       ' legge select Qurer og connection sammen
                        Command.ExecuteNonQuery()

                        Command.CommandText = QueryAvbesPers       ' legge select Qurer og connection sammen
                        Command.ExecuteNonQuery()

                        Command.CommandText = QueryAvbesPris       ' legge select Qurer og connection sammen
                        Command.ExecuteNonQuery()

                        Command.CommandText = RomTilgjengelig
                        Command.ExecuteNonQuery()


                        MessageBox.Show(" Bestillingen er avbestilt ", "Medling ")
                    End If
                End If
            End If

            minAdapter.SelectCommand = Command                      ' select sqlcommand 
            minAdapter.Fill(TabDataSet)                             ' Fill DataTable

            DataGridViewAvbestilling.DataSource = TabDataSet           ' legge data til DataGridView 
            minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
            DataGridViewAvbestilling.Refresh()


            btnTøm.PerformClick()
            minConnection.Close()                                   ' Close connection 
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            minConnection.Dispose()
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnTøm.Click

        Dim d As DateTime = DateTime.Today.AddDays(1)

        txtTlf.Clear()
        dtpFradato.Value = Today()
        dtpTildato.Value = d
        numRomNr.Value = 0

        lblFraDato.Text = ""
        lblRomNr.Text = ""
        lblTlfnr.Text = ""
        txtEtternavn.Text = ""
        txtFornavn.Text = ""
        txtTlf.Text = ""

        'Clear alle tekst
        txtEtternavn.Clear()
        txtFornavn.Clear()
        txtTlf.Clear()
        lblFraDato.Text = ""
        lblRomNr.Text = ""
        dtpFradato.Value = Date.Today
        dtpTildato.Value = Date.Today
        numRomNr.Value = 0


        'Clear datagridview
        DataGridViewAvbestilling.DataSource = Nothing
        DataGridViewAvbestilling.Rows.Clear()
        DataGridViewAvbestilling.Refresh()
        DataGridViewAvbestilling.Enabled = False

        ' Legge Resultat søk til Enabled
        grpResultat.Enabled = False
        lblFraDato.Enabled = False
        lblRomNr.Enabled = False

    End Sub

    Private Sub Resultat_Enter(sender As Object, e As EventArgs) Handles Resultat.Enter

    End Sub

    Private Sub Avbestill_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
End Class