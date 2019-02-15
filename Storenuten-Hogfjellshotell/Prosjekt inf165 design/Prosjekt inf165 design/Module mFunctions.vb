Imports MySql.Data.MySqlClient

Module mFunctions

    'Modulen deklarerer og skaper objekter som brukes i alle skjemaene
    Private Const minConnectionString As String = "server=localhost;user id=sn2016gr9;password=sn2016gr9;persistsecurityinfo=True;database=sn2016gr9"
    Public minConnection As New MySqlConnection(minConnectionString)

    Public Query As String = ""
    Public Command As New MySqlCommand("", minConnection) 'skjemaene setter minCommand.CommandText
    Public minAdapter As New MySqlDataAdapter(Command)

    Public sqlCommand As New MySqlCommand("", minConnection)
    Public Adapter As New MySqlDataAdapter(sqlCommand)

    Public sqlRead As MySqlDataReader
    Public TabDataSet As New DataTable
    Public DBBindingSorce As BindingSource


    Public Function ekteEpost(ByVal epost As String) As Boolean

        If epost.Contains("@") And epost.Contains(".") And epost.Length > 4 Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Sub SjekkRomnr(ByVal nr As String)

        Dim sjekk As Integer = 0
        Dim tblRomnr As New DataTable
        Command.CommandText = "Select Rom.RomNr from Rom WHERE RomNr = '" & nr & "'"
        minAdapter.Fill(tblRomnr)
        For Each row As DataRow In tblRomnr.Rows
            sjekk += 1
        Next

        If sjekk = 0 Then
            Throw New Exception("Fant ikke rom nummer")
        End If


    End Sub

    Public Function Tlfeksisterer(ByVal tlf As String) As Boolean
        Dim tbl As New DataTable
        Dim eksisterer As Boolean
        Command.CommandText = "SELECT personer.TlfNr, personer.Fornavn, personer.Etternavn from personer where TlfNr = '" & tlf & "'"
        minAdapter.Fill(tbl)

        For Each row As DataRow In tbl.Rows
            If row(0).ToString = tlf Then
                eksisterer = True
            End If
        Next

        If eksisterer Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Sub sjekkTelefonnr(ByVal nr As String)
        Dim sjekk As Integer = 0
        Dim tblTelefonnr As New DataTable
        Command.CommandText = "Select telefonnr from person WHERE telefonnr = " & nr
        minAdapter.Fill(tblTelefonnr)
        For Each row As DataRow In tblTelefonnr.Rows
            sjekk += 1
        Next

        If sjekk > 0 Then
        Else
            Throw New Exception("Fant ikke telefonnummer")
        End If
    End Sub

End Module
