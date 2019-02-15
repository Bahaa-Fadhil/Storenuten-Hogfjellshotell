Imports MySql.Data.MySqlClient

Public Class Endreinfo


    Private Sub Resultat_Enter(sender As Object, e As EventArgs) Handles Resultat.Enter

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

    Private Sub btnUtsjekk_Click(sender As Object, e As EventArgs) Handles btnUtsjekk.Click
        Utsjekk.Show()
        Me.Hide()
    End Sub

    Private Sub btnEndre_Click(sender As Object, e As EventArgs) Handles btnEndre.Click
    End Sub

    Private Sub btnReng_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub btnValg_Click(sender As Object, e As EventArgs) Handles btnValg.Click
        Valgmuligheter.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            DataGridViewEndreing.DataSource = Nothing
            DataGridViewEndreing.Rows.Clear()
            DataGridViewEndreing.Refresh()

            minConnection.Open() ' åpne connection med database

            ' Select for å finne ledig rom 

            Dim QueryEndre As String = "SELECT personer.Fornavn, personer.Etternavn, bestillingstype.TlfNr, bestillingstype.FraDato, bestillingstype.TilDato, bestillingstype.TypeBestilling FROM personer, bestillingstype WHERE bestillingstype.TlfNr=personer.TlfNr AND (bestillingstype.TlfNr = '" & txtTlf.Text & "') OR (personer.Fornavn = '" & txtFornavn.Text & "') OR (personer.Etternavn = '" & txtEtternavn.Text & "') Group by Fornavn;"

            ' legge select på en string

            Command.CommandText = QueryEndre       ' legge select Qurer og connection sammen
            Command.ExecuteNonQuery()

            minAdapter.SelectCommand = Command                      ' select sqlcommand 
            minAdapter.Fill(TabDataSet)                             ' Fill DataTable

            DataGridViewEndreing.DataSource = TabDataSet           ' legge data til DataGridView 
            minAdapter.Update(TabDataSet)                           ' Oppdater Data i DataGridView
            DataGridViewEndreing.Refresh()


            minConnection.Close()                                   ' Close connection 
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR ")
        Finally
            minConnection.Dispose()
        End Try

    End Sub

    Private Sub DataGridViewEndreing_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEndreing.CellContentClick


        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow
            Row = Me.DataGridViewEndreing.Rows(e.RowIndex)

            DataGridViewEndreing.Update()
            DataGridViewEndreing.Refresh()
        End If

    End Sub

    Private Sub btnRegiLag_Click(sender As Object, e As EventArgs) Handles btnRegiLag.Click

        Try
            If txtFornavnNyBestil.Text = "" Or txtEtternavnNyBestil.Text = "" Or txtTlfNyBestil.Text = "" Then
                MessageBox.Show("Fyll inn alle boksene med informasjon!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Not btnRadiNyBestilling.Checked And Not btnRadiNyReservasjon.Checked Then
                MessageBox.Show("Velg bestilling eller reservasjon!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                If MsgBox("Vil du endre informasjonen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    minConnection.Open()

                    If btnRadiNyBestilling.Checked Then
                        Dim QueryNyBestilling As String = "UPDATE personer, bestillingstype Set Fornavn = '" & txtFornavnNyBestil.Text & "', Etternavn = '" & txtEtternavnNyBestil.Text & "', TypeBestilling = 'Bestilling' WHERE Personer.TlfNr = '" & txtTlfNyBestil.Text & "' AND bestillingstype.TlfNr = '" & txtTlfNyBestil.Text & "';"
                        Command = New MySqlCommand(QueryNyBestilling, minConnection)

                    ElseIf btnRadiNyReservasjon.Checked Then
                        Dim QueryNyReservasjon As String = "UPDATE personer, bestillingstype Set Fornavn = '" & txtFornavnNyBestil.Text & "', Etternavn = '" & txtEtternavnNyBestil.Text & "', TypeBestilling = 'Reservasjon' WHERE Personer.TlfNr = '" & txtTlfNyBestil.Text & "' AND bestillingstype.TlfNr = '" & txtTlfNyBestil.Text & "';"
                        Command = New MySqlCommand(QueryNyReservasjon, minConnection)
                    End If

                    Dim fornavn As String = txtFornavnNyBestil.Text
                    Dim Etternavn As String = txtEtternavnNyBestil.Text
                    Dim Tlf As String = txtTlfNyBestil.Text
                    Dim NyBestilling As String = btnRadiNyBestilling.Text
                    Dim NyReservasjon As String = btnRadiNyReservasjon.Text


                    lblFornavn.Text = fornavn
                    lblEtternavn.Text = Etternavn
                    lblTelefonNr.Text = Tlf
                    lblTypebestilling.Text = NyBestilling
                    lblTypebestilling.Text = NyReservasjon


                    Dim ReadRes As MySqlDataReader
                    ReadRes = Command.ExecuteReader

                    'oppdater Tabelen
                    DataGridViewEndreing.Update()
                    minConnection.Close()
                    btnTømskjema.PerformClick()

                End If
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)

        Finally
            minConnection.Dispose()
        End Try



    End Sub

    Private Sub btnTømskjema_Click(sender As Object, e As EventArgs) Handles btnTømskjema.Click
        txtFornavn.Clear()
        txtEtternavn.Clear()

        txtTlf.Clear()
        txtFornavnNyBestil.Clear()
        txtEtternavnNyBestil.Clear()
        txtTlfNyBestil.Clear()
        btnRadiNyBestilling.Select()

        Dim fornavn As String = txtFornavnNyBestil.Text
        Dim Etternavn As String = txtEtternavnNyBestil.Text
        Dim Tlf As String = txtTlfNyBestil.Text
        Dim NyBestilling As String = btnRadiNyBestilling.Text
        Dim NyReservasjon As String = btnRadiNyReservasjon.Text

        'lblFraDato.Text = fradato                                   ' Vise Fra Dato
        'lblTilDato.Text = tildato                                   ' Vise Til Dato
        lblFornavn.Text = fornavn
        lblEtternavn.Text = Etternavn
        lblTelefonNr.Text = Tlf
        lblTypebestilling.Text = NyBestilling
        lblTypebestilling.Text = NyReservasjon


    End Sub
End Class