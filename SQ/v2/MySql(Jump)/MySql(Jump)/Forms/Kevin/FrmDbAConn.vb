Imports System.IO

Public Class FrmDbAConn

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
        TxtServer.Clear()
        TxtDb.Clear()
        TxtUn.Clear()
        TxtPass.Clear()
        TxtPort.Clear()
    End Sub

    Private Sub BtnTestConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTestConn.Click
        Testdb = 2
        FrmDbTest.ShowDialog()
    End Sub

    Private Sub BtnSaveSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveSet.Click
        Dim s = MsgBox("The system will restart after saving. Do you wish to continue?", vbYesNo + MsgBoxStyle.Question, frmMain.Text)

        If s = MsgBoxResult.Yes Then
            My.Settings.SQLServer = TxtServer.Text
            My.Settings.SQLDb = TxtDb.Text
            My.Settings.SQLUn = TxtUn.Text
            My.Settings.SQLPass = TxtPass.Text
            My.Settings.SQLPort = TxtPort.Text
            My.Settings.Save()

            If frmSplash IsNot Nothing Then
                frmSplash.Close()
            End If
            frmSplash.Show()
        End If
    End Sub

    Private Sub TxtServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtServer.TextChanged
        BtnSaveSet.Enabled = False
    End Sub

    Private Sub TxtDb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDb.TextChanged
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

    Private mb As New MySqlBackup
    Dim WithEvents ODE As New OpenFileDialog
    Dim WithEvents FBD As New FolderBrowserDialog
    Public StrTitle, StrFilter, FrmName As String

    Private Sub BtnImDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImDb.Click
        If Not Connection Then
            NotifyMsgBox("conn", "")
        Else
            With ODE
                .Multiselect = False
                .Title = "Select mysql file"
                .Filter = "SQL File (*.sql)|*.sql*"
                .FileName = ""
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ODE_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ODE.FileOk
        If Not Connection Then
            NotifyMsgBox("conn", "")
        Else
            Dim slot As Integer = CreateConn(-1)
            If slot = 1 Then
                Dim file As String = ODE.FileName
                mb = New MySqlBackup(conn(slot))
                mb.DeleteAllRows(0)
                mb.ImportInfo.FileName = file
                CloseConn(slot)
                Dim s = MsgBox("The system will restart after importing. Do you wish to continue?", vbYesNo + MsgBoxStyle.Question, frmMain.Text)
                If s = MsgBoxResult.Yes Then
                    MsgBox("Importing database file complete!", vbOKOnly + MsgBoxStyle.Information, frmMain.Text)

                    If frmSplash IsNot Nothing Then
                        frmSplash.Close()
                    End If
                    frmSplash.Show()
                End If
            Else
                NotifyMsgBox("im", "")
            End If
        End If
    End Sub

    Private Sub BtnExDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExDb.Click
        If Not Connection Then
            NotifyMsgBox("conn", "")
        Else
            With FBD

                Dim slot As Integer = CreateConn(-1)
                If slot = 1 Then
                    If Not Directory.Exists(Application.StartupPath + "\Backup") Then
                        Directory.CreateDirectory(Application.StartupPath + "\Backup")
                    End If

                    .RootFolder = Environment.SpecialFolder.Desktop
                    .SelectedPath = Application.StartupPath + "\Backup\"
                    .Description = "Select Output Folder File Path"

                    If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim filename As String = NowDate.ToString("MM.dd.yyyy(HH.mm.ss tt)")
                        Dim file As String = .SelectedPath & "\" & filename & ".sql"
                        mb = New MySqlBackup(conn(slot))
                        mb.ExportInfo.FileName = file
                        mb.Export()
                        MsgBox("Exporting database file complete!", vbOKOnly + MsgBoxStyle.Information, frmMain.Text)
                    End If
                    CloseConn(slot)
                Else
                    NotifyMsgBox("ex", "")
                End If
            End With
        End If
    End Sub
End Class