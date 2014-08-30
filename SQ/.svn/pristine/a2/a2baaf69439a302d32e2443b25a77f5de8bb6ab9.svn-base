Imports System.ComponentModel

Public Class UCNItems

    Private Sub UCNItems_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        cbCa.SelectedIndex = 0
        cbAv.SelectedIndex = 0
        cbVT.SelectedIndex = 0
    End Sub

    Private Sub GroupBox1_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox1.Paint
        Dim a(3) As Pen

        For i As Integer = 0 To a.Length - 1
            a(i) = New Pen(Color.Red, 1)
            Select Case i
                Case 0
                    e.Graphics.DrawRectangle(a(i), New Rectangle(cbBr.Location + New Size(1, 1), cbBr.Size - New Size(2, 2)))
                Case 1
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtIN.Location + New Size(1, 1), txtIN.Size - New Size(2, 2)))
                Case 2
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtMU.Location + New Size(1, 1), txtMU.Size - New Size(2, 2)))
                Case 3
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtDe.Location + New Size(1, 1), txtDe.Size - New Size(2, 2)))
            End Select
            a(i).Dispose()
        Next
    End Sub

    Private Sub GroupBox2_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox2.Paint
        Dim a(8) As Pen

        For i As Integer = 0 To a.Length - 1
            a(i) = New Pen(Color.Red, 1)
            Select Case i
                Case 0
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtQu.Location + New Size(1, 1), txtQu.Size - New Size(2, 2)))
                Case 1
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtIP.Location + New Size(1, 1), txtIP.Size - New Size(2, 2)))
                Case 2
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtDP.Location + New Size(1, 1), txtDP.Size - New Size(2, 2)))
                Case 3
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtFIN1.Location + New Size(1, 1), txtFIN1.Size - New Size(2, 2)))
                Case 4
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtFIA1.Location + New Size(1, 1), txtFIA1.Size - New Size(2, 2)))
                Case 5
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtFIA2.Location + New Size(1, 1), txtFIA2.Size - New Size(2, 2)))
                Case 6
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtFIN2.Location + New Size(1, 1), txtFIN2.Size - New Size(2, 2)))
                Case 7
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtFIA3.Location + New Size(1, 1), txtFIA3.Size - New Size(2, 2)))
                Case 8
                    e.Graphics.DrawRectangle(a(i), New Rectangle(txtFIN3.Location + New Size(1, 1), txtFIN3.Size - New Size(2, 2)))
            End Select
            a(i).Dispose()
        Next
    End Sub

    Friend WithEvents BwBr As BackgroundWorker
    Dim brsearch As String
    Public flag As Boolean = False

    Private Sub bwActivate(ByVal a As Integer)
        Select Case a
            Case 0
                If BwBr Is Nothing Then
                    BwBr = New BackgroundWorker
                    With BwBr
                        .WorkerSupportsCancellation = True
                        .WorkerReportsProgress = True
                    End With
                End If

                If BwBr.IsBusy Then
                    BwBr.CancelAsync()
                Else
                    brsearch = cbBr.Text
                    BwBr.RunWorkerAsync()
                End If
        End Select
    End Sub

    Delegate Sub SetComboBoxInvoker(ByVal cb As ComboBox, ByVal txt As String)
    Sub CBEditData(ByVal Cb As ComboBox, ByVal Txt As String)
        If Cb.InvokeRequired = True Then
            Cb.Invoke(New SetComboBoxInvoker(AddressOf CBEditData), Cb, Txt)
        Else
            If Cb.FindStringExact(Txt) = -1 Then
                Cb.Items.Add(Txt)
            End If
            If Cb.DropDownStyle = ComboBoxStyle.DropDownList Then
                If Cb.Text = "" Then
                    Cb.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub BwBr_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwBr.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@search", "%" & brsearch & "%")
                    End With

                    .CommandText = ("SELECT name FROM tbl_brand WHERE name LIKE @search ORDER BY name ASC")
                    Dim er = .ExecuteReader
                    While er.Read
                        If BwBr.CancellationPending Then
                            Exit While
                        Else
                            CBEditData(cbBr, er(0))
                        End If
                    End While
                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                e.Cancel = True
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub BwBr_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwBr.RunWorkerCompleted
        If e.Cancelled Then
            bwActivate(1)
        Else
            BwBr.Dispose()
        End If
    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles cbCa.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(0, frmSQItem.TabControl1.SelectedIndex).Value = cbCa.Text
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbBr.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub ComboBox1_LostFocus(sender As Object, e As EventArgs) Handles cbBr.LostFocus
        If sender.Text Is String.Empty And sender.Region Is Nothing Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles cbBr.TextChanged
        bwActivate(0)
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(1, frmSQItem.TabControl1.SelectedIndex).Value = cbBr.Text
        End If
    End Sub

    Private Sub ComboBox3_TextChanged(sender As Object, e As EventArgs) Handles cbAv.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(2, frmSQItem.TabControl1.SelectedIndex).Value = cbAv.Text
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIN.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles txtIN.LostFocus
        If sender.Text Is String.Empty And sender.Region Is Nothing Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtIN.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(3, frmSQItem.TabControl1.SelectedIndex).Value = txtIN.Text
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMU.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles txtMU.LostFocus
        If sender.Text Is String.Empty And sender.Region Is Nothing Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtMU.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(4, frmSQItem.TabControl1.SelectedIndex).Value = txtMU.Text
        End If
    End Sub

    Private Sub ComboBox4_TextChanged(sender As Object, e As EventArgs) Handles cbVT.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(5, frmSQItem.TabControl1.SelectedIndex).Value = cbVT.Text
        End If
    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDe.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub RichTextBox1_LostFocus(sender As Object, e As EventArgs) Handles txtDe.LostFocus
        If sender.Text Is String.Empty And sender.Region Is Nothing Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtDe.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(6, frmSQItem.TabControl1.SelectedIndex).Value = txtDe.Text
        End If
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIP.KeyPress
        If e.KeyChar = "." Then
            Dim sp() As String = txtIP.Text.Split(".")
            If sp.Length > 1 Then
                e.Handled = True
            Else
                sender.region = Nothing
            End If
        ElseIf (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            sender.region = Nothing
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox10_LostFocus(sender As Object, e As EventArgs) Handles txtIP.LostFocus
        Dim sp() As String = txtIP.Text.Split(".")
        If sp.Length = 1 Then
            txtIP.Text += ".00"
        End If

        If Val(sender.text) = 0 And sender.Region Is Nothing Then
            txtIP.Text = "0.00"
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles txtIP.TextChanged
        txtTP.Text = (Decimal.Round(Double.Parse(Val(txtIP.Text) * Val(txtQu.Text)), 2, MidpointRounding.AwayFromZero)).ToString("0.00")
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(8, frmSQItem.TabControl1.SelectedIndex).Value = txtIP.Text
        End If
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQu.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            e.Handled = True
        Else
            sender.region = Nothing
        End If
    End Sub

    Private Sub TextBox13_LostFocus(sender As Object, e As EventArgs) Handles txtQu.LostFocus
        If Val(sender.text) = 0 And sender.Region Is Nothing Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles txtQu.TextChanged
        txtTP.Text = (Decimal.Round(Double.Parse(Val(txtIP.Text) * Val(txtQu.Text)), 2, MidpointRounding.AwayFromZero)).ToString("0.00")
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(7, frmSQItem.TabControl1.SelectedIndex).Value = txtQu.Text
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles txtTP.TextChanged
        If flag Then ComputeMarg()
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(9, frmSQItem.TabControl1.SelectedIndex).Value = txtTP.Text
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDP.KeyPress
        If e.KeyChar = "." Then
            Dim sp() As String = txtDP.Text.Split(".")
            If sp.Length > 1 Then
                e.Handled = True
            Else
                sender.region = Nothing
            End If
        ElseIf (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            sender.region = Nothing
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox8_LostFocus(sender As Object, e As EventArgs) Handles txtDP.LostFocus
        Dim sp() As String = txtDP.Text.Split(".")
        If sp.Length = 1 Then
            txtDP.Text += ".00"
        End If

        If Val(sender.text) = 0 And sender.Region Is Nothing Then
            txtDP.Text = "0.00"
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles txtDP.TextChanged
        If flag Then ComputeMarg()
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(10, frmSQItem.TabControl1.SelectedIndex).Value = txtDP.Text
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles txtMa.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(11, frmSQItem.TabControl1.SelectedIndex).Value = txtMa.Text
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFIN1.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub TextBox3_LostFocus(sender As Object, e As EventArgs) Handles txtFIN1.LostFocus
        If Val(txtFIA1.Text) > 0 Then
            If sender.text Is String.Empty And sender.Region Is Nothing Then
                sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
            End If
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtFIN1.TextChanged
        If sender.Text IsNot String.Empty Then
            If Val(txtFIA1.Text) = 0 Then
                If txtFIA1.Region Is Nothing Then
                    txtFIA1.Region = New Region(New Rectangle(2, 2, txtFIA1.Width - 4, txtFIA1.Height - 4))
                End If
            Else
                sender.region = Nothing
                txtFIA1.Region = Nothing
            End If
        Else
            txtFIA1.Region = Nothing
            txtFIN1.Region = Nothing
        End If

        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(12, frmSQItem.TabControl1.SelectedIndex).Value = txtFIN1.Text
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFIA1.KeyPress
        If e.KeyChar = "." Then
            Dim sp() As String = txtFIA1.Text.Split(".")
            If sp.Length > 1 Then
                e.Handled = True
            Else
                sender.region = Nothing
            End If
        ElseIf (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            sender.region = Nothing
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_LostFocus(sender As Object, e As EventArgs) Handles txtFIA1.LostFocus
        If Len(txtFIA1.Text) > 0 Then
            Dim sp() As String = txtFIA1.Text.Split(".")
            If sp.Length = 1 Then
                txtFIA1.Text += ".00"
            End If
        Else
            txtFIA1.Text = "0.00"
        End If

        If txtFIN1.Text IsNot String.Empty Then
            If Val(sender.text) = 0 And sender.Region Is Nothing Then
                sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
            End If
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtFIA1.TextChanged
        If Val(sender.text) > 0 Then
            If txtFIN1.Text Is String.Empty Then
                If txtFIN1.Region Is Nothing Then
                    txtFIN1.Region = New Region(New Rectangle(2, 2, txtFIN1.Width - 4, txtFIN1.Height - 4))
                End If
            Else
                sender.region = Nothing
                txtFIN1.Region = Nothing
            End If
        Else
            txtFIN1.Region = Nothing
            txtFIA1.Region = Nothing
        End If

        If flag Then ComputeMarg()

        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(13, frmSQItem.TabControl1.SelectedIndex).Value = txtFIA1.Text
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFIN2.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub TextBox6_LostFocus(sender As Object, e As EventArgs) Handles txtFIN2.LostFocus
        If Val(txtFIA2.Text) > 0 Then
            If sender.text Is String.Empty And sender.Region Is Nothing Then
                sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtFIN2.TextChanged
        If sender.Text IsNot String.Empty Then
            If Val(txtFIA2.Text) = 0 Then
                If txtFIA2.Region Is Nothing Then
                    txtFIA2.Region = New Region(New Rectangle(2, 2, txtFIA2.Width - 4, txtFIA2.Height - 4))
                End If
            Else
                sender.region = Nothing
                txtFIA2.Region = Nothing
            End If
        Else
            txtFIA2.Region = Nothing
            txtFIN2.Region = Nothing
        End If

        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(14, frmSQItem.TabControl1.SelectedIndex).Value = txtFIN2.Text
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFIA2.KeyPress
        If e.KeyChar = "." Then
            Dim sp() As String = txtFIA2.Text.Split(".")
            If sp.Length > 1 Then
                e.Handled = True
            Else
                sender.region = Nothing
            End If
        ElseIf (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            sender.region = Nothing
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_LostFocus(sender As Object, e As EventArgs) Handles txtFIA2.LostFocus
        If Len(txtFIA2.Text) > 0 Then
            Dim sp() As String = txtFIA2.Text.Split(".")
            If sp.Length = 1 Then
                txtFIA2.Text += ".00"
            End If
        Else
            txtFIA2.Text = "0.00"
        End If

        If txtFIN2.Text IsNot String.Empty Then
            If Val(sender.text) = 0 And sender.Region Is Nothing Then
                sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtFIA2.TextChanged
        If Val(sender.text) > 0 Then
            If txtFIN2.Text Is String.Empty Then
                If txtFIN2.Region Is Nothing Then
                    txtFIN2.Region = New Region(New Rectangle(2, 2, txtFIN2.Width - 4, txtFIN2.Height - 4))
                End If
            Else
                sender.region = Nothing
                txtFIN2.Region = Nothing
            End If
        Else
            txtFIN2.Region = Nothing
            txtFIA2.Region = Nothing
        End If

        If flag Then ComputeMarg()

        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(15, frmSQItem.TabControl1.SelectedIndex).Value = txtFIA2.Text
        End If
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFIN3.KeyPress
        sender.region = Nothing
    End Sub

    Private Sub TextBox12_LostFocus(sender As Object, e As EventArgs) Handles txtFIN3.LostFocus
        If Val(txtFIA3.Text) > 0 Then
            If sender.text Is String.Empty And sender.Region Is Nothing Then
                sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
            End If
        End If
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles txtFIN3.TextChanged
        If sender.Text IsNot String.Empty Then
            If Val(txtFIA3.Text) = 0 Then
                If txtFIA3.Region Is Nothing Then
                    txtFIA3.Region = New Region(New Rectangle(2, 2, txtFIA3.Width - 4, txtFIA3.Height - 4))
                End If
            Else
                sender.region = Nothing
                txtFIA3.Region = Nothing
            End If
        Else
            txtFIA3.Region = Nothing
            txtFIN3.Region = Nothing
        End If

        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(16, frmSQItem.TabControl1.SelectedIndex).Value = txtFIN3.Text
        End If
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFIA3.KeyPress
        If e.KeyChar = "." Then
            Dim sp() As String = txtFIA3.Text.Split(".")
            If sp.Length > 1 Then
                e.Handled = True
            Else
                sender.region = Nothing
            End If
        ElseIf (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8) Then
            sender.region = Nothing
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox11_LostFocus(sender As Object, e As EventArgs) Handles txtFIA3.LostFocus
        If Len(txtFIA3.Text) > 0 Then
            Dim sp() As String = txtFIA3.Text.Split(".")
            If sp.Length = 1 Then
                txtFIA3.Text += ".00"
            End If
        Else
            txtFIA3.Text = "0.00"
        End If

        If txtFIN3.Text IsNot String.Empty Then
            If Val(sender.text) = 0 And sender.Region Is Nothing Then
                sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
            End If
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles txtFIA3.TextChanged
        If Val(sender.text) > 0 Then
            If txtFIN3.Text Is String.Empty Then
                If txtFIN3.Region Is Nothing Then
                    txtFIN3.Region = New Region(New Rectangle(2, 2, txtFIN3.Width - 4, txtFIN3.Height - 4))
                End If
            Else
                sender.region = Nothing
                txtFIN3.Region = Nothing
            End If
        Else
            txtFIN3.Region = Nothing
            txtFIA3.Region = Nothing
        End If

        If flag Then ComputeMarg()

        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(17, frmSQItem.TabControl1.SelectedIndex).Value = txtFIA3.Text
        End If
    End Sub

    Private Sub txtSt_TextChanged(sender As Object, e As EventArgs) Handles txtSt.TextChanged
        If frmSQItem.TabControl1.TabCount > 0 And flag Then
            FrmIDgv.DataGridView1.Item(18, frmSQItem.TabControl1.SelectedIndex).Value = txtSt.Text
        End If
    End Sub

    Public Sub ComputeMarg()
        Try
            Dim dp As Decimal = (Decimal.Round(Double.Parse(Val(txtDP.Text) + Val(txtFIA1.Text) + Val(txtFIA2.Text) + Val(txtFIA3.Text)), 2, MidpointRounding.AwayFromZero)).ToString("0.00")
            txtMa.Text = (Decimal.Round(Double.Parse((100 - ((Val(dp) / Val(txtIP.Text)) * 100))), 2, MidpointRounding.AwayFromZero)).ToString("0")
        Catch

        End Try
    End Sub
End Class
