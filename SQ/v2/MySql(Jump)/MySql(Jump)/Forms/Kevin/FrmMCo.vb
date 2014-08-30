Imports System.ComponentModel
Public Class FrmMCo

    Dim ds As New DataSet
    Dim delarra As New ArrayList
    Dim rid, sid, bwmode As Integer
    Dim dr() As System.Data.DataRow
    Friend WithEvents Bw As BackgroundWorker

    Private Sub Me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Tables.Add("ds")
        ds.Tables("ds").Columns.Add("Record No.")
        ds.Tables("ds").Columns.Add("Company name")
        ds.Tables("ds").Columns.Add("State")

        bwActivate(0)
        TxtCo.Focus()
    End Sub

    Private Sub bwActivate(ByVal mode As Integer)
        If Bw Is Nothing Then
            Bw = New BackgroundWorker
            With Bw
                .WorkerSupportsCancellation = True
                .WorkerReportsProgress = True
            End With
        End If

        bwmode = mode
        If mode = 0 Then
            If Bw.IsBusy Then
                Bw.CancelAsync()
            Else
                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Visible = True
                DataGridView1.DataSource = Nothing
                ToolStripStatusLabel1.Text = "Loading all data .."
                ToolStripStatusLabel1.Visible = True
                ds.Tables("ds").Clear()
                Bw.RunWorkerAsync()
            End If
        ElseIf mode = 1 Then
            If Bw.IsBusy Then
                Bw.CancelAsync()
            Else
                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Visible = True
                ToolStripStatusLabel1.Text = "Saving all data changes .."
                ToolStripStatusLabel1.Visible = True
                Bw.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub Bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles Bw.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    If bwmode = 0 Then 'Load all available related data from the database.
                        .CommandText = ("SELECT COUNT(*) FROM tbl_company")
                        Dim es = Convert.ToInt32(.ExecuteScalar)
                        Dim cnt As Integer = 0

                        .CommandText = ("SELECT ctrl_id, name FROM tbl_company ORDER BY name ASC")
                        Dim er = .ExecuteReader
                        While er.Read
                            cnt += 1
                            Bw.ReportProgress((cnt * 100) / es)
                            ds.Tables("ds").Rows.Add(er(0), er(1), 1)
                            If er(0) > rid Then
                                rid = er(0)
                            End If
                        End While
                    ElseIf bwmode = 1 Then 'Save all available data to the database.
                        Dim z = MsgBox("Do you wish to save all the changes you've made to the database?", vbQuestion + MsgBoxStyle.YesNo, "Update Database")
                        If z = MsgBoxResult.Yes Then

                            dr = ds.Tables("ds").Select("[State]<>'1'")

                            Dim es = dr.Length + delarra.Count
                            Dim cnt = 0

                            For i As Integer = 0 To delarra.Count - 1
                                If e.Cancel Then
                                    Exit For
                                Else
                                    With .Parameters
                                        .Clear()
                                        .AddWithValue("@id", delarra(i))
                                    End With
                                    .CommandText = ("DELETE FROM tbl_company WHERE ctrl_id=@id")
                                    .ExecuteNonQuery()
                                    cnt += 1
                                    Bw.ReportProgress((cnt * 100) / es)
                                End If
                            Next

                            For i As Integer = 0 To dr.Length - 1
                                If e.Cancel Then
                                    Exit For
                                Else
                                    With .Parameters
                                        .Clear()
                                        .AddWithValue("@id", dr(i)(0))
                                        .AddWithValue("@val", dr(i)(1))
                                    End With
                                    If dr(i)(2) = 0 Then
                                        .CommandText = ("INSERT INTO tbl_company (name) VALUES (@val)")
                                        .ExecuteNonQuery()
                                    ElseIf dr(i)(2) = 2 Then
                                        .CommandText = ("UPDATE tbl_company SET name=@val WHERE ctrl_id=@id")
                                        .ExecuteNonQuery()
                                    End If
                                    cnt += 1
                                    Bw.ReportProgress((cnt * 100) / es)
                                End If
                            Next
                            MsgBox("Informations is now saved.", vbOKOnly + vbInformation, "Updating Database Success")
                        End If
                    End If
                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                If bwmode = 0 Then
                    NotifyMsgBox("r", "Company name")
                ElseIf bwmode = 1 Then
                    NotifyMsgBox("s", "Company name")
                End If
            End Try
        Else
            If bwmode = 0 Then
                NotifyMsgBox("pr", "Company name")
            ElseIf bwmode = 1 Then
                NotifyMsgBox("ps", "Company name")
            End If
        End If
    End Sub

    Private Sub Bw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles Bw.ProgressChanged
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Bw.RunWorkerCompleted
        If e.Cancelled And bwmode = 0 Then 'Refreshing Again
            bwActivate(bwmode)
        ElseIf bwmode = 1 And ToolStripProgressBar1.Value < 100 Or _
            bwmode = 1 And e.Cancelled Then 'Saving stop
            Bw.Dispose()
        Else 'Finished Task
            DataGridView1.DataSource = ds.Tables("ds")
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(0).Visible = False
            delarra.Clear()
            If bwmode = 1 Then
                bwActivate(0)
            Else
                Bw.Dispose()
            End If
        End If

        ToolStripButton6.Enabled = True
        ToolStripButton3.Text = "&Save"
        ToolStripProgressBar1.Visible = False
        ToolStripStatusLabel1.Visible = False
    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint
        Dim a = New Pen(Color.Red, 1)
        e.Graphics.DrawRectangle(a, New Rectangle(TxtCo.Location + New Size(1, 1), TxtCo.Size - New Size(2, 2)))
    End Sub

    Private Sub TxtCo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCo.KeyPress
        TxtCo.Region = Nothing
    End Sub

    Private Sub TxtCo_Leave(sender As Object, e As EventArgs) Handles TxtCo.Leave
        If Len(TxtCo.Text) = 0 Then
            TxtCo.Region = New Region(New Rectangle(2, 2, TxtCo.Width - 4, TxtCo.Height - 4))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button2.Text = "&Update" Then
            Dim z = MsgBox("Do you wish to remove the changes you've made?", vbQuestion + MsgBoxStyle.YesNo, "Create New Data")
            If z = MsgBoxResult.Yes Then
                TxtCo.Region = Nothing
                Button2.Text = "&Add"
                Button3.Enabled = False
                Button1.Enabled = False
                TxtCo.Clear()
                TxtCo.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "&Add" Then
            dr = ds.Tables("ds").Select("[Company name]='" & TxtCo.Text & "'")
            If dr.Length > 0 Then
                MsgBox("The data you want to save already exist", vbInformation + MsgBoxStyle.OkOnly, "Add Failed")
                TxtCo.Region = New Region(New Rectangle(2, 2, TxtCo.Width - 4, TxtCo.Height - 4))
                TxtCo.Focus()
                Exit Sub
            End If

            Dim z = MsgBox("Do you wish to add the change you've made?", vbQuestion + MsgBoxStyle.YesNo, "Add New Data")
            If z = MsgBoxResult.Yes Then
                rid += 1
                ds.Tables("ds").Rows.Add(rid, TxtCo.Text, 0)
                TxtCo.Region = Nothing
                TxtCo.Clear()
                TxtCo.Focus()
            End If
        ElseIf Button2.Text = "&Update" Then
            dr = ds.Tables("ds").Select("[Company name]='" & TxtCo.Text & "'")
            If dr.Length > 0 Then
                MsgBox("The data you want to save already exist", vbInformation + MsgBoxStyle.OkOnly, "Add Failed")
                TxtCo.Region = New Region(New Rectangle(2, 2, TxtCo.Width - 4, TxtCo.Height - 4))
                TxtCo.Focus()
                Exit Sub
            End If

            Dim z = MsgBox("Do you wish to update the changes you've made?", vbQuestion + MsgBoxStyle.YesNo, "Update New Data")
            If z = MsgBoxResult.Yes Then
                dr = ds.Tables("ds").Select("[Record No.]='" & sid & "'")
                dr(0)(1) = TxtCo.Text
                If dr(0)(2) = 1 Then
                    dr(0)(2) = 2
                End If
                TxtCo.Region = Nothing
                Button2.Text = "&Add"
                Button3.Enabled = False
                Button1.Enabled = False
                TxtCo.Clear()
                TxtCo.Focus()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim z = MsgBox("Do you wish to remove the selected data?", vbQuestion + MsgBoxStyle.YesNo, "Remove Data")
        If z = MsgBoxResult.Yes Then
            dr = ds.Tables("ds").Select("[Record No.]='" & sid & "'")
            If dr(0)(2) > 0 Then
                delarra.Add(sid)
            End If
            dr(0).Delete()

            TxtCo.Region = Nothing
            Button3.Enabled = False
            Button2.Text = "&Add"
            TxtCo.Clear()
            TxtCo.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                TxtCo.Text = DataGridView1.Item(1, e.RowIndex).Value
                sid = DataGridView1.Item(0, e.RowIndex).Value
                Button2.Text = "&Update"
                Button3.Enabled = True
                Button1.Enabled = True
                TxtCo.Region = Nothing
            End If
        Catch ex As Exception
            NotifyMsgBox("rt", "")
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        bwActivate(0)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Text = "&Save" Then
            ToolStripButton3.Text = "&Cancel"
            ToolStripButton6.Enabled = False
            bwActivate(1)
        ElseIf ToolStripButton3.Text = "&Cancel" Then
            Bw.CancelAsync()
        End If
    End Sub
End Class