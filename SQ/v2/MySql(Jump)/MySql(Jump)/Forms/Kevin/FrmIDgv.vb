Public Class FrmIDgv

    Private Sub FrmIDgv_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub FrmIDgv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmSQItem
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                frmSQItem.TabControl1.SelectedIndex = e.RowIndex
            End If
        Catch ex As Exception
            NotifyMsgBox("rt", "Sales Quotation Item")
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If DataGridView1.RowCount > 0 Then
            If Val(DataGridView1.Item(11, e.RowIndex).Value) < 7 Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
            End If
        End If
    End Sub
End Class