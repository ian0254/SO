Imports System.ComponentModel

Public Class FrmAccount

    Dim ds As New DataSet
    Dim delarra As New ArrayList
    Dim rid, sid, bwmode As Integer
    Dim dr() As System.Data.DataRow
    Friend WithEvents Bw As BackgroundWorker

    Private Sub Me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Lco = "All" Then
            ComboBox2.SelectedIndex = 0
            ComboBox2.Enabled = True
        Else
            ComboBox2.Text = My.Settings.Lco
            ComboBox2.Enabled = False
        End If


        ds.Tables.Add("ds")
        ds.Tables("ds").Columns.Add("Record No.")
        ds.Tables("ds").Columns.Add("First name")
        ds.Tables("ds").Columns.Add("Last name")
        ds.Tables("ds").Columns.Add("Middle name")
        ds.Tables("ds").Columns.Add("Contact number")
        ds.Tables("ds").Columns.Add("Email address")
        ds.Tables("ds").Columns.Add("Username")
        ds.Tables("ds").Columns.Add("Password")
        ds.Tables("ds").Columns.Add("Position")
        ds.Tables("ds").Columns.Add("Initial")
        ds.Tables("ds").Columns.Add("State")
        ds.Tables("ds").Columns.Add("Company")
        bwActivate(0)
        TxtFN.Focus()
        FReset()
    End Sub

    Dim ssearch As String
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
                ssearch = My.Settings.Lco
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
                        If My.Settings.Lco = "All" Then
                            .CommandText = ("SELECT COUNT(*) FROM tbl_login")
                        Else
                            With .Parameters
                                .Clear()
                                .AddWithValue("@co", My.Settings.Lco)
                            End With
                            .CommandText = ("SELECT COUNT(*) FROM tbl_login WHERE company=@co")
                        End If

                        Dim es = Convert.ToInt32(.ExecuteScalar)
                        Dim cnt As Integer = 0

                        If My.Settings.Lco = "All" Then
                            .CommandText = ("SELECT ctrl_id,fname,lname,mname,cnum,email,uname,upass,position,initial,company FROM tbl_login ORDER BY fname ASC")
                        Else
                            .CommandText = ("SELECT ctrl_id,fname,lname,mname,cnum,email,uname,upass,position,initial,company FROM tbl_login " & _
                                            "WHERE company=@co ORDER BY fname ASC")
                        End If

                        Dim er = .ExecuteReader
                        While er.Read
                            cnt += 1
                            Bw.ReportProgress((cnt * 100) / es)
                            ds.Tables("ds").Rows.Add(er(0), er(1), er(2), er(3), er(4), er(5), er(6), er(7), er(8), er(9), 1, er(10))
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
                                    .CommandText = ("DELETE FROM tbl_login WHERE ctrl_id=@id")
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
                                        .AddWithValue("@fn", dr(i)(1))
                                        .AddWithValue("@ln", dr(i)(2))
                                        .AddWithValue("@mn", dr(i)(3))
                                        .AddWithValue("@cn", dr(i)(4))
                                        .AddWithValue("@em", dr(i)(5))
                                        .AddWithValue("@un", dr(i)(6))
                                        .AddWithValue("@ps", dr(i)(7))
                                        .AddWithValue("@pos", dr(i)(8))
                                        .AddWithValue("@ini", dr(i)(9))
                                        .AddWithValue("@co", dr(i)(11))
                                    End With
                                    If dr(i)(10) = 0 Then
                                        .CommandText = ("INSERT INTO tbl_login (lname,fname,mname,uname,upass,cnum,email,position,initial,company) " & _
                                                        "VALUES (@ln,@fn,@mn,@un,@ps,@cn,@em,@pos,@ini,@co)")
                                        .ExecuteNonQuery()
                                    ElseIf dr(i)(10) = 2 Then
                                        .CommandText = ("UPDATE tbl_login SET lname=@ln,fname=@fn,mname=@mn,uname=@un,upass=@ps," & _
                                                        "cnum=@co,email=@em,position=@pos,initial=@ini,company=@co WHERE ctrl_id=@id")
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
                    NotifyMsgBox("r", "Login Account")
                ElseIf bwmode = 1 Then
                    NotifyMsgBox("s", "Login Account")
                    MsgBox(ex.ToString)
                End If
            End Try
        Else
            If bwmode = 0 Then
                NotifyMsgBox("pr", "Login Account")
            ElseIf bwmode = 1 Then
                NotifyMsgBox("ps", "Login Account")
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
            DataGridView1.Columns(10).Visible = False
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
        Dim a(2) As Pen

        For i As Integer = 0 To a.Length - 1
            a(i) = New Pen(Color.Red, 1)
            Select Case i
                Case 1
                    e.Graphics.DrawRectangle(a(i), New Rectangle(TxtFN.Location + New Size(1, 1), TxtFN.Size - New Size(2, 2)))
                Case 2
                    e.Graphics.DrawRectangle(a(i), New Rectangle(TxtLN.Location + New Size(1, 1), TxtLN.Size - New Size(2, 2)))
            End Select
            a(i).Dispose()
        Next
    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint
        Dim a(2) As Pen

        For i As Integer = 0 To a.Length - 1
            a(i) = New Pen(Color.Red, 1)
            Select Case i
                Case 1
                    e.Graphics.DrawRectangle(a(i), New Rectangle(TxtUN.Location + New Size(1, 1), TxtUN.Size - New Size(2, 2)))
                Case 2
                    e.Graphics.DrawRectangle(a(i), New Rectangle(TxtUP.Location + New Size(1, 1), TxtUP.Size - New Size(2, 2)))
            End Select
            a(i).Dispose()
        Next
    End Sub

    Private Sub FrmAccount_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub TxtFN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFN.KeyPress
        TxtFN.Region = Nothing
    End Sub

    Private Sub TxtFN_Leave(sender As Object, e As EventArgs) Handles TxtFN.Leave
        If Len(TxtFN.Text) = 0 Then
            If TxtFN.Region Is Nothing Then
                TxtFN.Region = New Region(New Rectangle(2, 2, TxtFN.Width - 4, TxtFN.Height - 4))
            End If
        End If
    End Sub

    Private Sub TxtLN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLN.KeyPress
        TxtLN.Region = Nothing
    End Sub

    Private Sub TxtLN_Leave(sender As Object, e As EventArgs) Handles TxtLN.Leave
        If Len(TxtLN.Text) = 0 Then
            If TxtLN.Region Is Nothing Then
                TxtLN.Region = New Region(New Rectangle(2, 2, TxtLN.Width - 4, TxtLN.Height - 4))
            End If
        End If
    End Sub

    Private Sub TxtUP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUP.KeyPress
        TxtUP.Region = Nothing
        If e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtUP_Leave(sender As Object, e As EventArgs) Handles TxtUP.Leave
        If Len(TxtUP.Text) = 0 Then
            If TxtUP.Region Is Nothing Then
                TxtUP.Region = New Region(New Rectangle(2, 2, TxtUP.Width - 4, TxtUP.Height - 4))
            End If
        End If
    End Sub

    Private Sub TxtUN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUN.KeyPress
        TxtUN.Region = Nothing
    End Sub

    Private Sub TxtUN_Leave(sender As Object, e As EventArgs) Handles TxtUN.Leave
        If Len(TxtUN.Text) = 0 Then
            If TxtUN.Region Is Nothing Then
                TxtUN.Region = New Region(New Rectangle(2, 2, TxtUN.Width - 4, TxtUN.Height - 4))
            End If
        End If
    End Sub

    Private Sub FReset()
        TxtFN.Region = New Region(New Rectangle(2, 2, TxtFN.Width - 4, TxtFN.Height - 4))
        TxtLN.Region = New Region(New Rectangle(2, 2, TxtLN.Width - 4, TxtLN.Height - 4))
        TxtUN.Region = New Region(New Rectangle(2, 2, TxtUN.Width - 4, TxtUN.Height - 4))
        TxtUP.Region = New Region(New Rectangle(2, 2, TxtUP.Width - 4, TxtUP.Height - 4))
        TxtFN.Clear()
        TxtLN.Clear()
        TxtMN.Clear()
        TxtCN.Clear()
        TxtEAdd.Clear()
        TxtUN.Clear()
        TxtUP.Clear()
        TxtFN.Focus()
    End Sub

    Private Sub FrmAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        bwActivate(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button2.Text = "&Update" Then
            Dim z = MsgBox("Do you wish to remove the changes you've made?", vbQuestion + MsgBoxStyle.YesNo, "Create New Data")
            If z = MsgBoxResult.Yes Then
                Button2.Text = "&Add"
                Button3.Enabled = False
                Button1.Enabled = False
                FReset()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "&Add" And TxtUN.Region Is Nothing And TxtUP.Region Is Nothing And TxtFN.Region Is Nothing And TxtLN.Region Is Nothing Then
            dr = ds.Tables("ds").Select("[Username]='" & TxtUN.Text & "'")
            If dr.Length > 0 Then
                MsgBox("The username data you want to save already exist", vbInformation + MsgBoxStyle.OkOnly, "Add Failed")
                TxtUN.Region = New Region(New Rectangle(2, 2, TxtUN.Width - 4, TxtUN.Height - 4))
                TxtUN.Focus()
                Exit Sub
            End If
            dr = ds.Tables("ds").Select("[First name]='" & TxtFN.Text & "' AND [Last name]='" & TxtLN.Text & "' AND [Middle name]='" & TxtMN.Text & "' AND [Company]='" & ComboBox2.Text & "'")
            If dr.Length > 0 Then
                MsgBox("The personal data in company " & ComboBox2.Text & " you want to save has an existing account.", vbInformation + MsgBoxStyle.OkOnly, "Add Failed")
                TxtFN.Region = New Region(New Rectangle(2, 2, TxtFN.Width - 4, TxtFN.Height - 4))
                TxtLN.Region = New Region(New Rectangle(2, 2, TxtLN.Width - 4, TxtLN.Height - 4))
                TxtFN.Focus()
                Exit Sub
            End If

            Dim z = MsgBox("Do you wish to add the change you've made?", vbQuestion + MsgBoxStyle.YesNo, "Add New Data")
            If z = MsgBoxResult.Yes Then
                rid += 1
                Dim flag As Boolean = False
                Dim ini As String = ""
                Dim movef As Integer = 0
                Dim movel As Integer = 0

                Try
                    While flag = False
                        ini = UCase(TxtFN.Text.Substring(movef, 1) & TxtLN.Text.Substring(movel, 1))
                        dr = ds.Tables("ds").Select("[Initial]='" & ini & "'")
                        If dr.Length = 0 Then
                            flag = True
                        End If

                        If (movel + 1) = Len(TxtLN.Text) Then
                            movel = 0
                            movef += 1
                        Else
                            movel += 1
                        End If
                    End While
                Catch

                End Try

                ds.Tables("ds").Rows.Add(rid, TxtFN.Text, TxtLN.Text, TxtMN.Text, TxtCN.Text, TxtEAdd.Text, TxtUN.Text, TxtUP.Text, ComboBox1.Text, ini, 0, ComboBox2.Text)
                FReset()
            End If
        ElseIf Button2.Text = "&Update" And TxtUN.Region Is Nothing And TxtUP.Region Is Nothing And TxtFN.Region Is Nothing And TxtLN.Region Is Nothing Then
            dr = ds.Tables("ds").Select("[Username]='" & TxtUN.Text & "' AND [Record No.]<>'" & sid & "'")
            If dr.Length > 0 Then
                MsgBox("The username data you want to save already exist", vbInformation + MsgBoxStyle.OkOnly, "Add Failed")
                TxtUN.Region = New Region(New Rectangle(2, 2, TxtUN.Width - 4, TxtUN.Height - 4))
                TxtUN.Focus()
                Exit Sub
            End If
            dr = ds.Tables("ds").Select("[First name]='" & TxtFN.Text & "' AND [Last name]='" & TxtLN.Text & "' AND [Middle name]='" & TxtMN.Text & "' AND [Company]='" & ComboBox2.Text & "' AND [Record No.]<>'" & sid & "'")
            If dr.Length > 0 Then
                MsgBox("The personal data in company " & ComboBox2.Text & " you want to save has an existing account.", vbInformation + MsgBoxStyle.OkOnly, "Add Failed")
                TxtFN.Region = New Region(New Rectangle(2, 2, TxtFN.Width - 4, TxtFN.Height - 4))
                TxtLN.Region = New Region(New Rectangle(2, 2, TxtLN.Width - 4, TxtLN.Height - 4))
                TxtFN.Focus()
                Exit Sub
            End If

            Dim z = MsgBox("Do you wish to update the changes you've made?", vbQuestion + MsgBoxStyle.YesNo, "Update New Data")
            If z = MsgBoxResult.Yes Then
                Dim flag As Boolean = False
                Dim ini As String = ""
                Dim movef As Integer = 0
                Dim movel As Integer = 0

                Try
                    While flag = False
                        ini = UCase(TxtFN.Text.Substring(movef, 1) & TxtLN.Text.Substring(movel, 1))
                        dr = ds.Tables("ds").Select("[Initial]='" & ini & "'")
                        If dr.Length = 0 Then
                            flag = True
                        ElseIf dr(0)(0) = sid Then
                            flag = True
                        End If

                        If (movel + 1) = Len(TxtLN.Text) Then
                            movel = 0
                            movef += 1
                        Else
                            movel += 1
                        End If
                    End While
                Catch

                End Try

                dr = ds.Tables("ds").Select("[Record No.]='" & sid & "'")
                dr(0)(1) = TxtFN.Text
                dr(0)(2) = TxtLN.Text
                dr(0)(3) = TxtMN.Text
                dr(0)(4) = TxtCN.Text
                dr(0)(5) = TxtEAdd.Text
                dr(0)(6) = TxtUN.Text
                dr(0)(7) = TxtUP.Text
                dr(0)(8) = ComboBox1.Text
                dr(0)(9) = ini
                dr(0)(11) = ComboBox2.Text

                If dr(0)(10) = 1 Then
                    dr(0)(10) = 2
                End If
                Button2.Text = "&Add"
                Button3.Enabled = False
                Button1.Enabled = False
                FReset()
            End If
        Else
            MsgBox("You missed a required field.", vbInformation + MsgBoxStyle.OkOnly, "Required Field Missing")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim z = MsgBox("Do you wish to remove the selected data?", vbQuestion + MsgBoxStyle.YesNo, "Remove Data")
        If z = MsgBoxResult.Yes Then
            dr = ds.Tables("ds").Select("[Record No.]='" & sid & "'")
            If dr(0)(10) > 0 Then
                delarra.Add(sid)
            End If
            dr(0).Delete()

            Button3.Enabled = False
            Button2.Text = "&Add"
            FReset()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                FReset()
                TxtFN.Text = DataGridView1.Item(1, e.RowIndex).Value
                TxtLN.Text = DataGridView1.Item(2, e.RowIndex).Value
                TxtMN.Text = DataGridView1.Item(3, e.RowIndex).Value
                TxtCN.Text = DataGridView1.Item(4, e.RowIndex).Value
                TxtEAdd.Text = DataGridView1.Item(5, e.RowIndex).Value
                TxtUN.Text = DataGridView1.Item(6, e.RowIndex).Value
                TxtUP.Text = DataGridView1.Item(7, e.RowIndex).Value
                ComboBox1.Text = DataGridView1.Item(8, e.RowIndex).Value
                sid = DataGridView1.Item(0, e.RowIndex).Value
                Button2.Text = "&Update"
                Button3.Enabled = True
                Button1.Enabled = True

                If Len(TxtFN.Text) = 0 Then
                    TxtFN.Region = New Region(New Rectangle(2, 2, TxtFN.Width - 4, TxtFN.Height - 4))
                Else
                    TxtFN.Region = Nothing
                End If

                If Len(TxtLN.Text) = 0 Then
                    TxtLN.Region = New Region(New Rectangle(2, 2, TxtLN.Width - 4, TxtLN.Height - 4))
                Else
                    TxtLN.Region = Nothing
                End If

                If Len(TxtUN.Text) = 0 Then
                    TxtUN.Region = New Region(New Rectangle(2, 2, TxtUN.Width - 4, TxtUN.Height - 4))
                Else
                    TxtUN.Region = Nothing
                End If

                If Len(TxtUP.Text) = 0 Then
                    TxtUP.Region = New Region(New Rectangle(2, 2, TxtUP.Width - 4, TxtUP.Height - 4))
                Else
                    TxtUP.Region = Nothing
                End If
            End If
        Catch ex As Exception
            NotifyMsgBox("rt", "")
        End Try
    End Sub
End Class