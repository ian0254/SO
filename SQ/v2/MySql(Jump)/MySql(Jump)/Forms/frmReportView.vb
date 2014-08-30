Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmReportView

    Friend WithEvents BwSQ As BackgroundWorker
    Dim sqsearch As String
    Dim ds As New DataSet1

    Private Sub frmReportView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Len(TextBox1.Text) >= 11 And TextBox1.Text <> sqsearch Then
            CrystalReportViewer1.ReportSource = Nothing
            Label5.Text = "Loading ..."
            bwActivate(0)
        Else
            Label5.Text = "Waiting for search key ..."
        End If
    End Sub

    Private Sub bwActivate(ByVal a As Integer)
        Select Case a
            Case 0
                If BwSQ Is Nothing Then
                    BwSQ = New BackgroundWorker
                    With BwSQ
                        .WorkerSupportsCancellation = True
                        .WorkerReportsProgress = True
                    End With
                End If

                If BwSQ.IsBusy Then
                    BwSQ.CancelAsync()
                Else
                    ds.Tables("Info_Tbl").Clear()
                    ds.Tables("Item_Tbl").Clear()
                    sqsearch = TextBox1.Text
                    BwSQ.RunWorkerAsync()
                End If
        End Select
    End Sub

    Delegate Sub SetCtrlInvoker(ByVal ctrl As Control, ByVal txt As String)
    Sub SetCtrl(ByVal Ctrl As Control, ByVal Txt As String)
        If Ctrl.InvokeRequired = True Then
            Ctrl.Invoke(New SetCtrlInvoker(AddressOf SetCtrl), Ctrl, Txt)
        Else
            Ctrl.Text = Txt
        End If
    End Sub

    Private Sub BwSQ_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwSQ.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@sq", sqsearch)
                    End With

                    If Label3.Text = "Report Sales Quotation" Then
                        .CommandText = ("SELECT (CASE WHEN (SELECT name FROM tbl_company WHERE ctrl_id=company_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_company WHERE ctrl_id=company_id) END)," & _
                                        "attention,contact_no,faxno,availability,delivery," & _
                                        "(CASE WHEN (SELECT name FROM tbl_terms WHERE ctrl_id=terms_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_terms WHERE ctrl_id=terms_id) END)," & _
                                        "cancellation,validity,ctrl_id,revision,status,create_date " & _
                                        "FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND status<>'Confirmed' ORDER BY ctrl_id DESC")
                    Else
                        .CommandText = ("SELECT (CASE WHEN (SELECT name FROM tbl_company WHERE ctrl_id=company_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_company WHERE ctrl_id=company_id) END)," & _
                                                            "attention,contact_no,faxno,availability,delivery," & _
                                                            "(CASE WHEN (SELECT name FROM tbl_terms WHERE ctrl_id=terms_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_terms WHERE ctrl_id=terms_id) END)," & _
                                                            "cancellation,validity,ctrl_id,revision,status,create_date " & _
                                                            "FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND status='Confirmed' ORDER BY ctrl_id DESC")
                    End If
                    Dim er = .ExecuteReader

                    er.Read()
                    If er.HasRows Then
                        If Not BwSQ.CancellationPending Then
                            SetCtrl(Label1, "Status: " & er(11) & vbCrLf & "Revision: " & er(10))
                            SetCtrl(Label5, Convert.ToDateTime(er(12)).Date & " " & Convert.ToDateTime(er(12)).ToLongTimeString)
                            ds.Tables("Info_Tbl").Rows.Add(NowDate.Date, er(0), er(1), er(2), er(3), er(4), er(5), er(6), er(7), er(8))
                            .Parameters.AddWithValue("@sqid", er(9))
                            er.Close()
                            .CommandText = ("SELECT quantity,uom,note,price,total_price," & _
                                            "(CASE WHEN status = 'Delivered' THEN status ELSE 'Pending' END) FROM " & LCase(My.Settings.Lco) & "_sq_detail " & _
                                            "WHERE sq_main_id=@sqid ORDER BY total_price ASC")
                            er = .ExecuteReader

                            While er.Read
                                If BwSQ.CancellationPending Then
                                    Exit While
                                Else
                                    ds.Tables("Item_Tbl").Rows.Add(er(0), er(1), er(2), er(3), er(4), er(5))
                                End If
                            End While
                        End If
                    Else
                        SetCtrl(Label5, "No match has been found ...")
                    End If
                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                MsgBox(ex.ToString)
                e.Cancel = True
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub BwSQ_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwSQ.RunWorkerCompleted
        If e.Cancelled Then
            bwActivate(0)
        Else
            If ds.Tables("Info_Tbl").Rows.Count > 0 Then
                If Label3.Text = "Report Sales Order" Then
                    rprt = New CrystalReport1
                    rprt.SetDataSource(ds.Tables("Item_Tbl"))
                Else
                    rprt2 = New CrystalReport2
                    rprt2.SetDataSource(ds.Tables("Item_Tbl"))
                End If

                Dim txtdate As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text26"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtco As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text27"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtatt As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text28"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtcnum As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text29"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtfax As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text30"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtav As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text21"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtdel As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text22"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtterm As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text23"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtcan As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text24"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim txtval As CrystalDecisions.CrystalReports.Engine.TextObject = DirectCast(rprt.ReportDefinition.ReportObjects("Text25"), CrystalDecisions.CrystalReports.Engine.TextObject)

                txtdate.Text = ds.Tables("Info_Tbl").Rows(0).Item(0)
                txtco.Text = ds.Tables("Info_Tbl").Rows(0).Item(1)
                txtatt.Text = ds.Tables("Info_Tbl").Rows(0).Item(2)
                txtcnum.Text = ds.Tables("Info_Tbl").Rows(0).Item(3)
                txtfax.Text = ds.Tables("Info_Tbl").Rows(0).Item(4)
                txtav.Text = ds.Tables("Info_Tbl").Rows(0).Item(5)
                txtdel.Text = ds.Tables("Info_Tbl").Rows(0).Item(6)
                txtterm.Text = ds.Tables("Info_Tbl").Rows(0).Item(7)
                txtcan.Text = ds.Tables("Info_Tbl").Rows(0).Item(8)
                txtval.Text = ds.Tables("Info_Tbl").Rows(0).Item(9)
                If Label3.Text = "Report Sales Order" Then
                    CrystalReportViewer1.ReportSource = rprt
                Else
                    CrystalReportViewer1.ReportSource = rprt2
                End If
            End If
            BwSQ.Dispose()
        End If
    End Sub

    Dim rprt As CrystalReport1
    Dim rprt2 As CrystalReport2
    Private Sub frmReportView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Lco = "All" Then
            Me.BackColor = Color.OliveDrab
            Me.Text = "Administrator S.Q. Management"
        ElseIf My.Settings.Lco = "JUMP" Then
            Me.BackColor = Color.Maroon
            Me.Text = My.Settings.Lco & " S.Q. Management"
        ElseIf My.Settings.Lco = "FIT" Then
            Me.BackColor = Color.CornflowerBlue
            Me.Text = My.Settings.Lco & " S.Q. Management"
        ElseIf My.Settings.Lco = "SSI" Then
            Me.BackColor = Color.Tomato
            Me.Text = My.Settings.Lco & " S.Q. Management"
        End If

        Me.MaximumSize = New Size(1009, Screen.PrimaryScreen.WorkingArea.Height)
        If Label3.Text = "Report Sales Order" Then
            rprt = New CrystalReport1
            rprt.SetDataSource(ds.Tables("Item_Tbl"))
            CrystalReportViewer1.ReportSource = rprt
        Else
            rprt2 = New CrystalReport2
            rprt2.SetDataSource(ds.Tables("Item_Tbl"))
            CrystalReportViewer1.ReportSource = rprt2
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) >= 11 Then
            CrystalReportViewer1.ReportSource = Nothing
            Label5.Text = "Loading ..."
            bwActivate(0)
        Else
            Label5.Text = "Waiting for search key ..."
        End If
    End Sub
End Class