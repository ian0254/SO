Public Class FrmDbConn
    Private Sub BtnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefault.Click
        TxtPort.Text = 3306
    End Sub

    Private Sub BtnResFld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnResFld.Click
        TxtServer.Text = My.Settings.SQLServer
        TxtDb.Text = My.Settings.SQLDb
        TxtUn.Text = My.Settings.SQLUn
        TxtPass.Text = My.Settings.SQLPass
        TxtPort.Text = My.Settings.SQLPort
    End Sub

    Private Sub BtnClearFld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearFld.Click
        TxtServer.Text = ""
        TxtDb.Text = ""
        TxtUn.Text = ""
        TxtPass.Text = ""
        TxtPort.Text = ""
    End Sub

    Private Sub BtnTestConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTestConn.Click
        Testdb = 1
        FrmDbTest.ShowDialog()
    End Sub

    Private Sub BtnSaveSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveSet.Click
        Dim s = MsgBox("System will restart after saving. Do you wish to continue?", vbYesNo + MsgBoxStyle.Question, "Saving Configuration")

        If s = MsgBoxResult.Yes Then
            My.Settings.SQLServer = TxtServer.Text
            My.Settings.SQLDb = TxtDb.Text
            My.Settings.SQLUn = TxtUn.Text
            My.Settings.SQLPass = TxtPass.Text
            My.Settings.SQLPort = TxtPort.Text
            My.Settings.Save()
            Testdb = 1

            If frmSplash IsNot Nothing Then
                frmSplash.Close()
            End If

            frmSplash.Show()
        End If
    End Sub

    Private Sub Me_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtServer.Text = My.Settings.SQLServer
        TxtDb.Text = My.Settings.SQLDb
        TxtUn.Text = My.Settings.SQLUn
        TxtPass.Text = My.Settings.SQLPass
        TxtPort.Text = My.Settings.SQLPort
    End Sub

    Private Sub TxtServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtServer.TextChanged
        BtnSaveSet.Enabled = False
    End Sub

    Private Sub TxtDbTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDb.TextChanged
        BtnSaveSet.Enabled = False
    End Sub

    Private Sub TxtUn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUn.TextChanged
        BtnSaveSet.Enabled = False
    End Sub

    Private Sub TxtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPass.TextChanged
        BtnSaveSet.Enabled = False
    End Sub

    Private Sub TxtPort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPort.TextChanged
        BtnSaveSet.Enabled = False
    End Sub
End Class