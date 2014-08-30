Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class frmLogin

    Private Sub GroupBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim a(2) As Pen

        For i As Integer = 0 To a.Length - 1
            a(i) = New Pen(Color.Red, 1)
            Select Case i
                Case 1
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtUsername.Location + New Size(1, 1), txtUsername.Size - New Size(2, 2)))
                Case 2
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtPassword.Location + New Size(1, 1), txtPassword.Size - New Size(2, 2)))
            End Select
            a(i).Dispose()
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        FrmAccount.ShowDialog()
    End Sub

    Private Sub frmLogin_FormClosed1(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Public Sub Login(ByVal un As String, ByVal ps As String)
        If txtUsername.Region Is Nothing And txtPassword.Region Is Nothing Then
            Dim slot As Integer = CreateConn(-1)
            If slot > 0 Then
                'Md5Hash Purpose
                'Dim hash As String = ""
                'Using md5Hash As MD5 = MD5.Create()
                '    hash = GetMd5Hash(md5Hash, ps)
                'End Using
                Try
                    With sqlcommand(slot)
                        With .Parameters
                            .Clear()
                            .AddWithValue("@un", un)
                            .AddWithValue("@ps", ps)
                        End With
                        .CommandText = ("SELECT fname,lname,mname,position,ctrl_id,initial,company FROM tbl_login WHERE uname=@un AND upass=@ps")
                        Dim er = .ExecuteReader
                        er.Read()
                        If er.HasRows Then
                            My.Settings.LName = er(1) & ", " & er(0) & " " & er(2)
                            My.Settings.LGrp = er(3)
                            My.Settings.LID = er(4)
                            My.Settings.LIni = er(5)
                            If My.Settings.LGrp = "Administrator" Then
                                My.Settings.Lco = "All"
                            Else
                                My.Settings.Lco = er(6)
                            End If
                            frmMain.Show()
                            Me.Close()
                        Else
                            MsgBox("Incorrect login information.", vbInformation + MsgBoxStyle.OkOnly, "Login Failed")
                            txtPassword.Clear()
                            txtPassword.Focus()
                        End If
                        CloseConn(slot)
                    End With
                Catch ex As Exception
                    CloseConn(slot)
                    MsgBox("Something went wrong while retrieving all the account information, Press login button to login again.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SQL Failure")
                End Try
            Else
                MsgBox("Something went wrong while retrieving all the account information." & _
                       vbCrLf & "If there is an available query slot try to press login button to login again..", vbInformation + MsgBoxStyle.OkOnly, "Building Connection Failed")
            End If
        Else
            MsgBox("Username and Password is required.", vbExclamation + MsgBoxStyle.OkOnly, "Invalid Login")

            If Len(txtUsername.Text) = 0 Then
                If txtUsername.Region Is Nothing Then
                    txtUsername.Region = New Region(New Rectangle(2, 2, txtUsername.Width - 4, txtUsername.Height - 4))
                End If
            End If

            If Len(txtPassword.Text) = 0 Then
                If txtPassword.Region Is Nothing Then
                    txtPassword.Region = New Region(New Rectangle(2, 2, txtPassword.Width - 4, txtPassword.Height - 4))
                End If
            End If
        End If
    End Sub

    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        Dim sBuilder As New StringBuilder()

        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        Return sBuilder.ToString()

    End Function

    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login(txtUsername.Text, txtPassword.Text)
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtUsername.Focus()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.Control = True And e.Alt = True And txtUsername IsNot Nothing And txtPassword IsNot Nothing Then
            Dim z = InputBox("Enter security key:", "Authentication", "")
            If z = "Developer" Then FrmDbAConn.ShowDialog() Else FrmDbConn.ShowDialog()
        End If
    End Sub

    Private Sub TxtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Login(txtUsername.Text, txtPassword.Text)
        Else
            txtUsername.Region = Nothing
        End If
    End Sub

    Private Sub TxtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        If Len(txtUsername.Text) = 0 Then
            If txtUsername.Region Is Nothing Then
                txtUsername.Region = New Region(New Rectangle(2, 2, txtUsername.Width - 4, txtUsername.Height - 4))
            End If
        End If
    End Sub

    Private Sub TxtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Login(txtUsername.Text, txtPassword.Text)
        Else
            txtPassword.Region = Nothing
        End If
    End Sub

    Private Sub TxtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If Len(txtPassword.Text) = 0 Then
            If txtPassword.Region Is Nothing Then
                txtPassword.Region = New Region(New Rectangle(2, 2, txtPassword.Width - 4, txtPassword.Height - 4))
            End If
        End If
    End Sub
End Class