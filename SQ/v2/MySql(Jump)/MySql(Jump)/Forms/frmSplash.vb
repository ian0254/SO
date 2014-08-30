Public NotInheritable Class frmSplash

    Dim i As Integer = 0
    Private Sub Me_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not FrmDbConn Is Nothing Then
            FrmDbConn.Close()
        End If

        If Not FrmDbAConn Is Nothing Then
            FrmDbAConn.Close()
        End If

        If Not frmMain Is Nothing Then
            frmMain.Close()
        End If

        If Not frmLogin Is Nothing Then
            frmLogin.Close()
        End If

        ProgressBar1.Value = 0
        i = 0
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ConnectToMySql()
        If startup = 0 Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Not e.Cancelled Then
            Label4.Text = "Building all resources ..."
            Timer1.Enabled = True
        Else
            Button1.Visible = True
            Button2.Visible = True
            FrmDbConn.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not FrmDbConn Is Nothing Then
            FrmDbConn.Close()
        End If

        If Not FrmDbAConn Is Nothing Then
            FrmDbAConn.Close()
        End If

        If Not frmMain Is Nothing Then
            frmMain.Close()
        End If

        If Not frmLogin Is Nothing Then
            frmLogin.Close()
        End If

        Button1.Visible = False
        Button2.Visible = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Enabled = False
            frmLogin.Show()
            Me.Close()
        Else
            i += 1
            ProgressBar1.Value = ((i * ProgressBar1.Maximum) / ProgressBar1.Maximum)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmDbConn.Show()
    End Sub
End Class
