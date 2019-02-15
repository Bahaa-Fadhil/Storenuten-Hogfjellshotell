Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLoginn.Click

        ' logging for programmet
        If Not txtBrukernavn.Text = "sn2016gr9" Then
            MessageBox.Show("Brukernavn eller passord er feil, sjekk stor og små bokstaver og prøve igjen. ", "Feil Innlogging ")
            Exit Sub
        ElseIf Not txtPassord.Text = "sn2016gr9" Then
            MessageBox.Show("Brukernavn eller passord er feil, sjekk stor og små bokstaver og prøve igjen. ", "Feil Innlogging ")
            Exit Sub
        Else
            Valgmuligheter.Show()
            Me.Hide()
        End If

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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Tømme tekstbokser
        txtBrukernavn.Text = ""
        txtPassord.Text = ""


    End Sub
End Class
