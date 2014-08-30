Public Class FrmDateTime
    Dim i As Integer = 0
    Private Sub FrmDateTime_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If i = 0 Then
            e.Cancel = True
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmDateTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim a As String = Now.ToLongTimeString
        Dim b = "", c = "", d = "", f As String = ""
        Dim hr As String = ""
        Dim flag As Boolean = False
        For Each i As Char In a
            If i.ToString = ":" And Len(c) = 0 Then
                flag = True
            ElseIf i.ToString = ":" And Len(c) > 0 Then
                flag = False
            ElseIf i.ToString = " " And Len(f) > 0 Then
                flag = True
            ElseIf flag = True And Len(f) > 0 Then
                d += i.ToString
            ElseIf flag = False And Len(c) > 0 Then
                f += i.ToString
            ElseIf flag Then
                c += i.ToString
            Else
                b += i.ToString
            End If
        Next
        TextBox1.Text = b
        TextBox2.Text = c
        TextBox3.Text = f
        ComboBox1.Text = d

        If ComboBox1.Text = "PM" And Val(TextBox1.Text) < 12 Then
            hr = Val(TextBox1.Text) + 12
        ElseIf ComboBox1.Text = "AM" And Val(TextBox1.Text) = 12 Then
            hr = Val(TextBox1.Text) - 12
        Else
            hr = Val(TextBox1.Text)
        End If

        Dim z = MsgBox("Your current time and date is " & a & " " & DateTimePicker1.Value.Date & "." & _
               vbCrLf & "Is the settings correct?", vbQuestion + MsgBoxStyle.YesNo, "DateTime Settings")
        If z = MsgBoxResult.Yes Then

            NowDate = New DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day, hr, TextBox2.Text, TextBox3.Text)
            i = 1
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim hr As String = ""

        If ComboBox1.Text = "PM" And Val(TextBox1.Text) < 12 Then
            hr = Val(TextBox1.Text) + 12
        ElseIf ComboBox1.Text = "AM" And Val(TextBox1.Text) = 12 Then
            hr = Val(TextBox1.Text) - 12
        Else
            hr = Val(TextBox1.Text)
        End If

        NowDate = New DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day, hr, TextBox2.Text, TextBox3.Text)
        i = 1
        Me.Close()
    End Sub
End Class