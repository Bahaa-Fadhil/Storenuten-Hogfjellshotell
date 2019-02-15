Public Class Valgmuligheter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBestOpp.Click
        Me.Hide()
        BestRes.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnRegnskap.Click
        Me.Hide()
        Økonomi.Show()
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
End Class