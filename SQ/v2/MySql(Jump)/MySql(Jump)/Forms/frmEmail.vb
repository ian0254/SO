Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class frmEmail
    Public Property InitialDirectory As String
    Dim FoundMatch As Boolean
    Dim Smtp_Server As New SmtpClient
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.SelectedIndex = 0
        GroupBox3.Focus()
    End Sub
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

        Try
            FoundMatch = Regex.IsMatch(Label10.Text, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)
        Catch ex As ArgumentException 'Syntax error in the regular expression
        End Try
        If Not FoundMatch Then
            lblUsername.Visible = True
            lblUsername.Text = ("Not a Valid Email Address")
        Else
            lblUsername.Visible = True
            lblUsername.Text = ("Ok!")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            txtPass.PasswordChar = ""
        Else
            txtPass.PasswordChar = "•"
        End If
    End Sub


    'Private Sub txtSubject_TextChanged(sender As Object, e As EventArgs)
    '    If txtSubject.Text = "" Then
    '        lblSubj.Visible = True
    '        lblSubj.Text = "Subject should not be blank."
    '    Else
    '        lblSubj.Visible = False
    '    End If
    'End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            lblSmtp.Text = "smtp.gmail.com"
            lblPort.Text = "587"
            Smtp_Server.EnableSsl = True
        ElseIf ComboBox1.SelectedIndex = 1 Then
            lblSmtp.Text = "smtp.mail.yahoo.com"
            lblPort.Text = "587"
            Smtp_Server.EnableSsl = True
        ElseIf ComboBox1.SelectedIndex = 2 Then
            lblSmtp.Text = "smtp.live.com"
            lblPort.Text = "587"
            Smtp_Server.EnableSsl = True
        ElseIf ComboBox1.SelectedIndex = 3 Then
            lblSmtp.Text = "smtp.live.com"
            lblPort.Text = "465"
            Smtp_Server.EnableSsl = True
        ElseIf ComboBox1.SelectedIndex = 4 Then
            lblSmtp.Text = "smtp.atomitsoln.com"
            lblPort.Text = "587"
            Smtp_Server.EnableSsl = False
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 0 Then
            ComboBox1.SelectedIndex = 0
        ElseIf ComboBox2.SelectedIndex = 1 Then
            ComboBox1.SelectedIndex = 1
        ElseIf ComboBox2.SelectedIndex = 2 Then
            ComboBox1.SelectedIndex = 2
        ElseIf ComboBox2.SelectedIndex = 3 Then
            ComboBox1.SelectedIndex = 3
        ElseIf ComboBox2.SelectedIndex = 4 Then
            ComboBox1.SelectedIndex = 4
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If txtUsername.Text = "" And txtPass.Text = "" Then
            ToolStripButton1.Enabled = False
        ElseIf txtTo.Text = "" Then
            ToolStripButton1.Enabled = False
        Else
            ToolStripButton1.Enabled = True
        End If
        Label10.Text = txtUsername.Text + Label5.Text + ComboBox2.Text
        txtFrom.Text = Label10.Text
        'If lblValid.Text = "Not a Valid Email Address" Then
        '    ToolStripButton1.Enabled = True
        'Else
        '    ToolStripButton1.Enabled = True
        'End If
    End Sub

    Dim FileSize As Long


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim OFD As New OpenFileDialog()

        OFD.InitialDirectory = "C:\"
        OFD.AddExtension = True
        OFD.Multiselect = True
        OFD.ReadOnlyChecked = True
        OFD.Title = "Select file(s)..."
        OFD.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
        OFD.FilterIndex = 1
        OFD.ShowDialog()
        OFD.CheckFileExists = True
        OFD.CheckPathExists = True

        For Counter = 0 To UBound(OFD.FileNames)
            Dim info As New IO.FileInfo(OFD.FileNames(Counter))
            FileSize = FileSize + (info.Length)
            ListBox1.Items.Add(OFD.FileNames(Counter))
        Next
        txtSize.Text = FileSize
        'For i As Integer = 0 To OFD.FileNames.Length - 1
        '    DataGridView1.Rows.Add()
        '    DataGridView1.Item(0, DataGridView1.RowCount - 1).Value = OFD.FileNames(i)
        'Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(Label10.Text, txtPass.Text)
            Smtp_Server.Port = lblPort.Text
            Smtp_Server.Host = lblSmtp.Text
            e_mail = New MailMessage()
            e_mail.From = New MailAddress(txtFrom.Text)
            e_mail.To.Add(txtTo.Text)

            If Not txtCC.Text = Nothing Then
                e_mail.CC.Add(txtCC.Text)
            End If

            e_mail.Subject = txtSubject.Text
            e_mail.IsBodyHtml = True
            e_mail.Body = txtMessage.Text
            For Counter = 0 To ListBox1.Items.Count - 1
                Dim Attachment As System.Net.Mail.Attachment
                Attachment = New Attachment(ListBox1.Items(Counter).ToString)
                e_mail.Attachments.Add(Attachment)
            Next

            
            'For i As Integer = 0 To DataGridView1.RowCount - 1
            '    Dim attch As Attachment = New Attachment(DataGridView1.Item(0, i).Value)
            '    e_mail.Attachments.Add(attch)
            'Next

            Smtp_Server.Send(e_mail)
            ToolStripProgressBar1.Value = 100
            ToolStripStatusLabel1.Text = "Done."
            Dim z = MsgBox("Mail Sent", vbOKOnly, "Success!")
            If z = MsgBoxResult.Ok Then
                Me.Close()
                'ToolStripStatusLabel1.Text = "Ready."
                'ToolStripProgressBar1.Value = 0
            End If

        Catch error_t As Exception
            MsgBox("Email Sending Failed! You may have entered the wrong account information.", vbOKOnly, "Sending Failed")
            ToolStripProgressBar1.Value = 0
            ToolStripStatusLabel1.Text = "Sending Failed."
            'MsgBox(error_t.ToString)
        End Try
    End Sub

  
    'Private Sub txtTo_LostFocus(sender As Object, e As EventArgs) Handles txtTo.LostFocus
    '    Dim FoundMatch As Boolean
    '    Try
    '        FoundMatch = Regex.IsMatch(txtTo.Text, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)
    '    Catch ex As ArgumentException 'Syntax error in the regular expression
    '    End Try
    '    If Not FoundMatch Then
    '        lblValid.Visible = True
    '        lblValid.Text = ("Not a Valid Email Address")
    '    Else
    '        lblValid.Visible = False
    '        lblValid.Text = ("Ok!")
    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim info As New IO.FileInfo(ListBox1.SelectedItem)
        FileSize = FileSize - (info.Length)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        txtSize.Text = FileSize
    End Sub

    Private Sub txtSubject_TextChanged(sender As Object, e As EventArgs) Handles txtSubject.TextChanged, txtCC.TextChanged
        If txtSubject.Text = "" Then
            Me.Text = "Write: (no subject)"
        Else
            Me.Text = "Write: " + txtSubject.Text
        End If
    End Sub
End Class