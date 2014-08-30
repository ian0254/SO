Public Class frmMain

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        If My.Settings.LGrp = "Sales" Then
            DatabaseToolStripMenuItem.Visible = False
            ToolStripMenuItem1.Visible = False
            SystemAccountToolStripMenuItem.Visible = False
        Else
            DatabaseToolStripMenuItem.Visible = True
            ToolStripMenuItem1.Visible = True
            SystemAccountToolStripMenuItem.Visible = True
        End If

        If My.Settings.Lco = "All" Then
            Me.BackColor = Color.OliveDrab
            Me.Text = "Administrator S.O/S.Q. Management"
            Me.BackgroundImage = My.Resources.Co_All
        ElseIf My.Settings.Lco = "JUMP" Then
            Me.BackColor = Color.Maroon
            Me.Text = My.Settings.Lco & " S.O/S.Q. Management"
            Me.BackgroundImage = My.Resources.Co_Jump
        ElseIf My.Settings.Lco = "FIT" Then
            Me.BackColor = Color.CornflowerBlue
            Me.Text = My.Settings.Lco & " S.O/S.Q. Management"
            Me.BackgroundImage = My.Resources.Co_Front
        ElseIf My.Settings.Lco = "SSI" Then
            Me.BackColor = Color.Tomato
            Me.Text = My.Settings.Lco & " S.O/S.Q. Management"
            'Me.BackgroundImage = My.Resources.Co_All
        End If

        If My.Settings.LGrp = "Administrator" Then
            NewSQToolStripMenuItem.Visible = False
            UpdateSQToolStripMenuItem.Visible = False
            EmailToolStripMenuItem.Visible = False
            UpdateSOToolStripMenuItem.Visible = False
            SalesOrderToolStripMenuItem.Visible = True
            SalesQuotationToolStripMenuItem.Visible = True
        ElseIf My.Settings.LGrp = "Finance" Or My.Settings.LGrp = "Production" Then
            NewSQToolStripMenuItem.Visible = False
            UpdateSQToolStripMenuItem.Visible = False
            EmailToolStripMenuItem.Visible = False
            UpdateSOToolStripMenuItem.Visible = False
            AdminToolStripMenuItem.Visible = False
            If My.Settings.LGrp = "Finance" Then
                SalesOrderToolStripMenuItem.Visible = True
                SalesQuotationToolStripMenuItem.Visible = True
            Else
                SalesOrderToolStripMenuItem.Visible = False
                SalesQuotationToolStripMenuItem.Visible = False
            End If
        ElseIf My.Settings.LGrp = "Logistics" Then
            NewSQToolStripMenuItem.Visible = False
            UpdateSQToolStripMenuItem.Visible = False
            EmailToolStripMenuItem.Visible = False
            AdminToolStripMenuItem.Visible = False
            SalesOrderToolStripMenuItem.Visible = False
            SalesQuotationToolStripMenuItem.Visible = False
        ElseIf My.Settings.LGrp = "Sales" Then
            AdminToolStripMenuItem.Visible = False
            SalesOrderToolStripMenuItem.Visible = True
            SalesQuotationToolStripMenuItem.Visible = True
        End If

        TSSLAccnt.Text = My.Settings.LName & "( " & My.Settings.LGrp & " )"

        FrmDateTime.ShowDialog()

        Timer3.Enabled = True
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Dim Myreply As System.Net.NetworkInformation.PingReply
    Dim success, rtry, cntdwn As Integer
    Dim request, rcancel As Integer
    Dim MyPing As New System.Net.NetworkInformation.Ping
    Dim csdate As Date
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TSSLDate.Text = NowDate.Date
        TSSLTime.Text = NowDate.ToLongTimeString
        TSSLServer.Text = My.Settings.SQLServer

        If Connection Then
            Timer2.Enabled = True
            Timer1.Interval = 100
            rtry = 0
            success = 1
            If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
        Else
            Timer2.Enabled = False
            Timer1.Interval = 1100
            If cntdwn = 0 Then
                rtry += 1

                TSSLStatus.Text = "Reconnecting"
                TSSLStatus.ForeColor = Color.Orange

                cntdwn = 5
                reconsucc = 0
                RenewConnect()

                If reconsucc = 1 Then
                    rtry = 0
                    success = 1
                    If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
                ElseIf rtry = 3 Then
                    Timer1.Enabled = False
                    MsgBox("Make sure that this computer is connected to the internet or lan network group.", vbOKOnly + vbInformation, "Connectivity Problem")
                    Timer1.Enabled = True
                ElseIf rtry = 6 Then
                    Timer1.Enabled = False
                    MsgBox("If you are using cross-platform web server solution (eg. xampp or wampp)," & vbCrLf & _
                           "Double check if the MySQL is connected or running.", vbOKOnly + vbInformation, "Connectivity Problem")
                    Timer1.Enabled = True
                ElseIf rtry = 8 Then
                    Timer1.Enabled = False
                    MsgBox("Make sure that the server is on or connected to the internet or lan network group.", vbOKOnly + vbInformation, "Connectivity Problem")
                    Timer1.Enabled = True
                ElseIf rtry = 10 Then
                    Timer1.Enabled = False
                    Dim z = MsgBox("Restarting the system might fix the problem, Do you wish to restart?", vbYesNo + vbQuestion, "Connectivity Problem")
                    If z = MsgBoxResult.Yes Then
                        Testdb = 1
                        frmSplash.Show()
                    Else
                        Timer1.Enabled = True
                    End If
                ElseIf rtry = 15 Then
                    Timer1.Enabled = False
                    Dim z = MsgBox("The system cannot fix the problem, The system will now restart.", vbYesNo + vbQuestion, "Connectivity Problem")
                    Testdb = 1
                    frmSplash.Show()
                End If
            Else
                TSSLStatus.ForeColor = Color.Black
                TSSLStatus.Text = "The system will reconnect to the server in " & cntdwn & "."
                cntdwn -= 1
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Timer1.Enabled = False
            Myreply = MyPing.Send(My.Settings.SQLServer)
            If Myreply.Status = Net.NetworkInformation.IPStatus.Success Then
                With sqlcommand(0)
                    .Connection = conn(0)
                    .Connection.Open()
                    .CommandText = ("SELECT COUNT(*) FROM tbl_login")
                    Dim es = Convert.ToInt32(.ExecuteScalar)
                    .Connection.Close()
                End With
            End If
        Catch ex As Exception
            sqlcommand(0).Connection.Close()
            success = 0
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If success = 0 Then
            TSSLStatus.ForeColor = Color.Red
            TSSLStatus.Text = "Disconnected"
        ElseIf Myreply.Status = Net.NetworkInformation.IPStatus.Success Then
            TSSLPing.Text = Myreply.RoundtripTime & "ms"
            TSSLStatus.ForeColor = Color.Green
            TSSLStatus.Text = "Connected"

            If Myreply.RoundtripTime > 100 Then
                TSSLPing.ForeColor = Color.Red
            Else
                TSSLPing.ForeColor = Color.Black
            End If
        Else
            TSSLStatus.ForeColor = Color.Red
            TSSLStatus.Text = "Disconnected"
        End If

        Timer1.Enabled = True
    End Sub

    Private Sub TSSLStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSSLStatus.TextChanged
        If TSSLStatus.Text = "Connected" Then
            Connection = True
        Else
            Connection = False
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        NowDate = NowDate.AddSeconds(1)
    End Sub

    Private Sub NewSQToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSQToolStripMenuItem.Click
        frmNewSQ.ShowDialog()
    End Sub

    Private Sub UpdateSQToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSQToolStripMenuItem.Click
       frmUpdateSQ.ShowDialog()
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click
        FrmDbAConn.ShowDialog()
    End Sub

    Private Sub TSSLState_Click(sender As Object, e As EventArgs)
        If Val(TSSLState.Text) = 99 Then
            TSSLState.ForeColor = Color.Red
        ElseIf Val(TSSLState.Text) > 30 Then
            TSSLState.ForeColor = Color.Orange
        Else
            TSSLState.ForeColor = Color.Black
        End If
    End Sub

    Private Sub CompanyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanyToolStripMenuItem.Click
        FrmMCo.ShowDialog()
    End Sub

    Private Sub EmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailToolStripMenuItem.Click
        frmEmail.ShowDialog()
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        If My.Settings.LGrp = "Production" Or My.Settings.LGrp = "Logistics" Then
            frmReportView.Label3.Text = "Report Sales Order"
            frmReportView.ShowDialog()
        End If
    End Sub

    Private Sub TermsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermsListToolStripMenuItem.Click
        FrmMTe.ShowDialog()
    End Sub

    Private Sub SystemAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemAccountToolStripMenuItem.Click
        FrmAccount.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        FrmCP.ShowDialog()
    End Sub

    Private Sub UpdateSOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSOToolStripMenuItem.Click
        frmUpdateSO.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If frmSplash IsNot Nothing Then
            frmSplash.Close()
        End If
        frmSplash.Show()
    End Sub

    Private Sub SalesOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesOrderToolStripMenuItem.Click
        frmReportView.Label3.Text = "Report Sales Order"
        frmReportView.ShowDialog()
    End Sub

    Private Sub SalesQuotationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesQuotationToolStripMenuItem.Click
        frmReportView.Label3.Text = "Report Sales Quotation"
        frmReportView.ShowDialog()
    End Sub
End Class