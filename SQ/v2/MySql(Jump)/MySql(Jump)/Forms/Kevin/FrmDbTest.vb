Public Class FrmDbTest
    Private sqlstrcon As New MySqlConnectionStringBuilder
    Private sqlconn As New MySqlConnection

    Private Sub Me_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Enabled = False
        RichTextBox1.Clear()
        Me.Dispose()
    End Sub

    Private Sub FrmTestDb_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        sent = 0
        receive = 0
        lost = 0
        minping = 0
        maxping = 0
        plost = 0
        ping = 0

        If Testdb = 1 Then
            With FrmDbConn
                Try
                    Label1.Text = "Server : " & .TxtServer.Text
                    If .TxtServer.Text <> "" And .TxtDb.Text <> "" And .TxtUn.Text <> "" Then
                        With sqlstrcon
                            .Server = FrmDbConn.TxtServer.Text
                            .Port = FrmDbConn.TxtPort.Text
                            .UserID = FrmDbConn.TxtUn.Text
                            .Password = FrmDbConn.TxtPass.Text
                            .Database = FrmDbConn.TxtDb.Text
                        End With
                        sqlconn.ConnectionString = sqlstrcon.ConnectionString
                        sqlconn.Open()
                        sqlconn.Close()
                        Timer1.Enabled = True
                    Else
                        MsgBox("Cannot connect to database server!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Database Server")
                        .BtnSaveSet.Enabled = False
                        Timer1.Enabled = False
                        Me.Close()
                    End If
                Catch myerror As Exception
                    MsgBox("Cannot connect to database server!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Database Server")
                    .BtnSaveSet.Enabled = False
                    Timer1.Enabled = False
                    Me.Close()
                End Try
            End With
        ElseIf Testdb = 2 Then
            With FrmDbAConn
                Try
                    Label1.Text = "Server : " & .TxtServer.Text
                    If .TxtServer.Text <> "" And .TxtDb.Text <> "" And .TxtUn.Text <> "" Then
                        With sqlstrcon
                            .Server = FrmDbAConn.TxtServer.Text
                            .Port = FrmDbAConn.TxtPort.Text
                            .UserID = FrmDbAConn.TxtUn.Text
                            .Password = FrmDbAConn.TxtPass.Text
                            .Database = FrmDbAConn.TxtDb.Text
                        End With
                        sqlconn.ConnectionString = sqlstrcon.ConnectionString
                        sqlconn.Open()
                        sqlconn.Close()
                        Timer1.Enabled = True
                    Else
                        MsgBox("Cannot connect to database server!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Database Server")
                        .BtnSaveSet.Enabled = False
                        Timer1.Enabled = False
                        Me.Close()
                    End If
                Catch myerror As Exception
                    MsgBox("Cannot connect to database server!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Database Server")
                    .BtnSaveSet.Enabled = False
                    Timer1.Enabled = False
                    Me.Close()
                End Try
            End With
        End If
    End Sub

    Dim ping As Integer
    Dim sent, receive, lost, minping, maxping, plost, avping As Integer
    Dim MyPing As New System.Net.NetworkInformation.Ping
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        With RichTextBox1
            Try
                Dim Myreply As System.Net.NetworkInformation.PingReply = MyPing.Send(sqlstrcon.Server)
                If ping <> 4 Then
                    ping += 1
                    If ping = 1 Then .Text += "Pinging " & sqlstrcon.Server & " [" & Myreply.Address.ToString & "] with 32 bytes of data:" & vbCrLf
                    If Myreply.Status = Net.NetworkInformation.IPStatus.TimedOut Then
                        .Text += "Request timed out." & vbCrLf
                        lost += 1
                    Else
                        If ping = 1 Then minping = Myreply.RoundtripTime
                        If sqlstrcon.Server = "localhost" Then
                            .Text += "Reply from " & Myreply.Address.ToString & " time=" & Myreply.RoundtripTime & "ms" & vbCrLf
                        Else
                            .Text += "Reply from " & Myreply.Address.ToString & " bytes=32 time=" & Myreply.RoundtripTime & "ms TTL=" & Myreply.Options.Ttl.ToString & vbCrLf
                        End If
                        If Myreply.RoundtripTime > maxping Then maxping = Myreply.RoundtripTime
                        If Myreply.RoundtripTime < minping Then minping = Myreply.RoundtripTime
                        sent += 1
                        receive += 1
                    End If
                Else
                    plost = lost / 4
                    avping = (maxping + minping) / 2
                    .Text += vbCrLf & "Ping statistics for " & sqlstrcon.Server & " [" & Myreply.Address.ToString & "] : " & vbCrLf
                    .Text += vbTab & "Packets: Sent = " & sent & " Recieved = " & receive & " Lost = " & lost & " (" & plost & "% loss)," & vbCrLf
                    .Text += "Approximate round trip times in milli-seconds:" & vbCrLf
                    .Text += vbTab & "Minimum = " & minping & "ms Maximum = " & maxping & "ms Average = " & avping & "ms" & vbCrLf & vbCrLf
                    .Text += "Communicating to database server success!"
                    Timer1.Enabled = False
                    Button1.Enabled = True
                    Button1.Text = "Ok"
                    If Testdb = 1 Then
                        FrmDbConn.BtnSaveSet.Enabled = True
                    ElseIf Testdb = 2 Then
                        FrmDbAConn.BtnSaveSet.Enabled = True
                    End If
                End If
            Catch ex As Exception
                Timer1.Enabled = False
                MsgBox("Internet connection lost.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Network Failure")
            End Try
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class