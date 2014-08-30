Module MySQL
    Public strcon As New MySqlConnectionStringBuilder
    Public conn(100) As MySqlConnection
    Public sqlcommand(100) As MySqlcommand
    Public sqlreader As MySqlDataReader
    Public sqlda As MySqlDataAdapter
    Public sqlpara As MySqlParameter

    Public Sub RenewConnect()
        Try
            For i As Integer = 1 To 100
                If Not conn(i) Is Nothing Then
                    If Not conn(i).State = ConnectionState.Closed Then
                        conn(i).Close()
                    End If
                    conn(i) = Nothing
                End If

                If Not sqlcommand(i) Is Nothing Then
                    sqlcommand(i) = Nothing
                    frmMain.TSSLState.Text = Val(frmMain.TSSLState.Text) - 1
                    Exit For
                End If
            Next

            conn(0) = New MySqlConnection
            sqlcommand(0) = New MySqlCommand
            With strcon
                .Server = My.Settings.SQLServer
                .Port = My.Settings.SQLPort
                .UserID = My.Settings.SQLUn
                .Password = My.Settings.SQLPass
                .Database = My.Settings.SQLDb
                .CharacterSet = "utf8"
                .AllowZeroDateTime = True
            End With
            conn(0).ConnectionString = strcon.ConnectionString
            sqlcommand(0).Connection = conn(0)
            sqlcommand(0).Connection.Open()
            sqlcommand(0).Connection.Close()

            reconsucc = 1
        Catch
            reconsucc = 0
        End Try
    End Sub

    Public Sub ConnectToMySql()
        Try
            For i As Integer = 1 To 100
                If Not conn(i) Is Nothing Then
                    If Not conn(i).State = ConnectionState.Closed Then
                        conn(i).Close()
                    End If
                    conn(i) = Nothing
                End If

                If Not sqlcommand(i) Is Nothing Then
                    sqlcommand(i) = Nothing
                    Exit For
                End If
            Next

            startup = 0
            conn(0) = New MySqlConnection
            sqlcommand(0) = New MySqlCommand
            If My.Settings.SQLServer <> "" And My.Settings.SQLDb <> "" Then
                With strcon
                    .Server = My.Settings.SQLServer
                    .Port = My.Settings.SQLPort
                    .UserID = My.Settings.SQLUn
                    .Password = My.Settings.SQLPass
                    .Database = My.Settings.SQLDb
                    .CharacterSet = "utf8"
                    .AllowZeroDateTime = True
                End With
                conn(0).ConnectionString = strcon.ConnectionString
                sqlcommand(0).Connection = conn(0)
                sqlcommand(0).Connection.Open()
                sqlcommand(0).Connection.Close()
                timer = 1
                startup = 1
            Else
                timer = 0
                MessageBox.Show("Error Connecting to database.", "Error Database Server", _
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch myerror As Exception
            timer = 0
            MessageBox.Show("Error Connecting to database.", "Error Database Server", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Public Function CreateConn(ByVal i As Integer)
        Try
            For i = 1 To 100
                If conn(i) Is Nothing Then
                    conn(i) = New MySqlConnection
                    conn(i).ConnectionString = strcon.ConnectionString
                    sqlcommand(i) = New MySqlCommand

                    sqlcommand(i).Connection = conn(i)
                    sqlcommand(i).Connection.Open()
                    frmMain.TSSLState.Text = Val(frmMain.TSSLState.Text) + 1
                    Exit For
                End If
            Next
            Return i
        Catch
            Return -1
        End Try
    End Function

    Public Sub CloseConn(ByVal i As Integer)
        Try
            sqlcommand(i).Connection.Close()
            conn(i) = Nothing
            sqlcommand(i) = Nothing
            frmMain.TSSLState.Text = Val(frmMain.TSSLState.Text) - 1
        Catch
        End Try
    End Sub
End Module
