Imports System.ComponentModel
Public Class frmUpdateSQ

    Friend WithEvents BwSQ As BackgroundWorker
    Dim sqsearch As String
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Len(TextBox1.Text) >= 11 And TextBox1.Text <> sqsearch Then
            Me_Clear()
            Me_Cmd()

            For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
            Next

            FrmIDgv.Dispose()
            frmSQItem.Dispose()
            bwActivate(0)
        Else
            Me_Clear()
            Me_Cmd()

            For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
            Next

            FrmIDgv.Dispose()
            frmSQItem.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(TextBox1.Text) >= 11 Then
            Me_Clear()
            Me_Cmd()

            For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
            Next

            FrmIDgv.Dispose()
            frmSQItem.Dispose()
            bwActivate(0)
        Else
            Me_Clear()
            Me_Cmd()

            For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
            Next

            FrmIDgv.Dispose()
            frmSQItem.Dispose()
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
                    For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                        MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
                    Next
                    frmSQItem.TabControl1.TabPages.Clear()
                    FrmIDgv.DataGridView1.Rows.Clear()

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
                    .CommandText = ("SELECT (CASE WHEN (SELECT name FROM tbl_company WHERE ctrl_id=company_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_company WHERE ctrl_id=company_id) END)," & _
                                    "email,contact_no,faxno,todeliver,tobill,attention,availability," & _
                                    "(CASE WHEN (SELECT name FROM tbl_terms WHERE ctrl_id=terms_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_terms WHERE ctrl_id=terms_id) END)," & _
                                    "delivery,validity,cancellation,status,revision,create_date " & _
                                    "FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND status<>'Confirmed' ORDER BY ctrl_id DESC")
                    Dim er = .ExecuteReader
                    er.Read()
                    If er.HasRows Then
                        If Not BwSQ.CancellationPending Then
                            SetCtrl(cbCompany, er(0))
                            SetCtrl(txtEmail, er(1))
                            SetCtrl(txtCnum, er(2))
                            SetCtrl(txtFnum, er(3))
                            SetCtrl(txtAddel, er(4))
                            SetCtrl(txtAddbill, er(5))
                            SetCtrl(txtAttention, er(6))
                            SetCtrl(txtAvailability, er(7))
                            SetCtrl(cbTerms, er(8))
                            SetCtrl(txtDelivery, er(9))
                            SetCtrl(txtPriceValidity, er(10))
                            SetCtrl(txtCancel, er(11))
                            SetCtrl(Label3, "Status: " & er(12))
                            SetCtrl(Label4, "Revision: " & er(13))
                            SetCtrl(Label5, Convert.ToDateTime(er(14)).Date & " " & Convert.ToDateTime(er(14)).ToShortTimeString)
                        End If
                    Else
                        SetCtrl(Label5, "No match has been found ...")
                    End If
                    er.Close()
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

    Private Sub BwSQ_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwSQ.RunWorkerCompleted
        If e.Cancelled Then
            bwActivate(0)
        Else
            Dim spl() As String = Label3.Text.Split(":")
            If spl(1).Trim(" ") = "New" Or spl(1).Trim(" ") = "Revised" Or spl(1).Trim(" ") = "Rejected" Then
                ToolStripButton3.Text = "Approve"
                ToolStripButton3.Enabled = True
                If My.Settings.LGrp = "Sales" Then
                    ToolStripButton3.Visible = False
                End If
            ElseIf spl(1).Trim(" ") = "Approved" Then
                ToolStripButton3.Text = "Confirm"
                ToolStripButton3.Enabled = True
                ToolStripButton3.Visible = True
            Else
                ToolStripButton3.Text = "Confirmed"
                ToolStripButton3.Enabled = False
                ToolStripButton3.Visible = True
            End If
            If Label3.Text <> "Status: N/A" Then
                ToolStripButton6.Enabled = True
                ToolStripButton1.Enabled = True
                ToolStripButton5.Enabled = True
                frmSQItem.Label1.Text = "Sales Quotation Item"
                frmSQItem.ShowDialog()
            End If
            BwSQ.Dispose()
        End If
    End Sub

    Public Sub Me_Clear()
        For Each c As Control In GroupBox1.Controls
            If TypeOf c Is TextBox Then
                CType(c, TextBox).Clear()
            ElseIf TypeOf c Is ComboBox Then
                CType(c, ComboBox).Text = ""
            End If
        Next

        For Each c As Control In GroupBox2.Controls
            If TypeOf c Is TextBox Then
                CType(c, TextBox).Clear()
            ElseIf TypeOf c Is ComboBox Then
                CType(c, ComboBox).Text = ""
            End If
        Next
    End Sub

    Public Sub Me_Cmd()
        Label3.Text = "Status: N/A"
        Label4.Text = "Revision: N/A"
        If Len(TextBox1.Text) < 11 Then
            Label5.Text = "Waiting for search key ..."
        Else
            Label5.Text = "Loading ..."
        End If

        ToolStripButton1.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton5.Enabled = False
        ToolStripButton6.Enabled = False
    End Sub

    Private Sub frmUpdateSQ_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
            MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
        Next

        FrmIDgv.Dispose()
        frmSQItem.Dispose()
        Me.Dispose()
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

    Delegate Sub SetLabelInvoker(ByVal lb As Label, ByVal txt As String)
    Sub LBEditData(ByVal Lb As Label, ByVal Txt As String)
        If Lb.InvokeRequired = True Then
            Lb.Invoke(New SetLabelInvoker(AddressOf LBEditData), Lb, Txt)
        Else
            Lb.Text = Txt
        End If
    End Sub

    Dim InfoRes As String
    Delegate Sub GetCtrlInvoker(ByVal ctrl As Control)
    Function GetInfo(ByVal Ctrl As Control)
        If Ctrl.InvokeRequired = True Then
            Ctrl.Invoke(New GetCtrlInvoker(AddressOf GetInfo), Ctrl)
        Else
            InfoRes = Ctrl.Text
        End If

        Return InfoRes
    End Function

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim z = MsgBox("Do you wish to clear all available field?", vbQuestion + MsgBoxStyle.YesNo, "Clear Fields")
        If z = MsgBoxResult.Yes Then
            Me_Clear()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim cnt As Integer = 0

        For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
            For Each c As Control In MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).GroupBox1.Controls
                If c.Region IsNot Nothing Then
                    cnt = 1
                    Exit For
                End If
            Next
            If cnt = 0 Then
                For Each c As Control In MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).GroupBox2.Controls
                    If c.Region IsNot Nothing Then
                        cnt = 1
                        Exit For
                    End If
                Next
            End If
            If cnt = 1 Then
                Exit For
            End If
        Next

        If cnt > 0 Then
            Dim z = MsgBox("You missed a required field in your item list." & vbCrLf & _
                           "Do you still wish to save the change's that you've made?", vbInformation + MsgBoxStyle.YesNo, "Required Field Missing")
            If z = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    Dim rev() As String = Label4.Text.Split(": ")
                    rev(1) = Val(rev(1).Trim(" ")) + 1
                    With .Parameters
                        .Clear()
                        .AddWithValue("@sq", TextBox1.Text.Trim(" "))
                        .AddWithValue("@co", GetInfo(cbCompany))
                        .AddWithValue("@em", GetInfo(txtEmail))
                        .AddWithValue("@cn", GetInfo(txtCnum))
                        .AddWithValue("@fn", GetInfo(txtFnum))
                        .AddWithValue("@atd", GetInfo(txtAddel))
                        .AddWithValue("@atb", GetInfo(txtAddbill))
                        .AddWithValue("@att", GetInfo(txtAttention))
                        .AddWithValue("@av", GetInfo(txtAvailability))
                        .AddWithValue("@te", GetInfo(cbTerms))
                        .AddWithValue("@del", GetInfo(txtDelivery))
                        .AddWithValue("@pv", GetInfo(txtPriceValidity))
                        .AddWithValue("@ca", GetInfo(txtCancel))
                        .AddWithValue("@dte", NowDate)
                        If My.Settings.LGrp = "Supervisor" Then
                            .AddWithValue("@st", "Approved")
                        ElseIf My.Settings.LGrp = "Sales" Then
                            .AddWithValue("@st", "Revised")
                        End If
                        .AddWithValue("@rev", rev(1))
                    End With

                    .CommandText = ("SELECT COUNT(*) FROM tbl_company WHERE name=@co")
                    Dim es = Convert.ToInt32(.ExecuteScalar)

                    If es = 0 Then
                        .CommandText = ("INSERT INTO tbl_company (name) VALUES (@co)")
                        .ExecuteNonQuery()
                        CBEditData(cbCompany, GetInfo(cbCompany))
                    End If

                    .CommandText = ("SELECT COUNT(*) FROM tbl_terms WHERE name=@te")
                    es = Convert.ToInt32(.ExecuteScalar)

                    If es = 0 Then
                        .CommandText = ("INSERT INTO tbl_terms (name) VALUES (@te)")
                        .ExecuteNonQuery()
                        CBEditData(cbTerms, GetInfo(cbTerms))
                    End If

                    .CommandText = ("SELECT COUNT(*) FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev")
                    es = Convert.ToInt32(.ExecuteScalar)

                    If es > 0 Then
                        .CommandText = ("DELETE FROM " & LCase(My.Settings.Lco) & "_sq_detail WHERE sq_main_id=(SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev)")
                        .ExecuteNonQuery()

                        .CommandText = ("DELETE FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev")
                        .ExecuteNonQuery()
                    End If

                    .CommandText = ("INSERT INTO " & LCase(My.Settings.Lco) & "_sq_main (sqno,company_id,email,contact_no,faxno,todeliver,tobill,attention,availability,terms_id,delivery,validity,cancellation,status,revision,create_date) " & _
                                    "VALUES (@sq,CASE WHEN (SELECT ctrl_id FROM tbl_company WHERE name=@co) IS NULL THEN 0 ELSE (SELECT ctrl_id FROM tbl_company WHERE name=@co) END," & _
                                    "@em,@cn,@fn,@atd,@atb,@att,@av,CASE WHEN (SELECT ctrl_id FROM tbl_terms WHERE name=@te) IS NULL THEN 0 ELSE (SELECT ctrl_id FROM tbl_terms WHERE name=@te) END," & _
                                    "@del,@pv,@ca,@st,@rev,@dte)")
                    .ExecuteNonQuery()

                    For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                        With .Parameters
                            .Clear()
                            .AddWithValue("@rev", rev(1))
                            .AddWithValue("@sq", TextBox1.Text.Trim(" "))
                            .AddWithValue("@br", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbBr))
                            .AddWithValue("@ca", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbCa))
                            .AddWithValue("@av", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbAv))
                            .AddWithValue("@in", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtIN))
                            .AddWithValue("@qu", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtQu))
                            .AddWithValue("@uom", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtMU))
                            .AddWithValue("@pr", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtIP))
                            .AddWithValue("@tpr", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtTP))
                            .AddWithValue("@dp", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtDP))
                            .AddWithValue("@ma", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtMa))
                            .AddWithValue("@vt", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbVT))
                            .AddWithValue("@f1", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIN1))
                            .AddWithValue("@a1", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIA1))
                            .AddWithValue("@f2", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIN2))
                            .AddWithValue("@a2", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIA2))
                            .AddWithValue("@f3", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIN3))
                            .AddWithValue("@a3", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIA3))
                            .AddWithValue("@note", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtDe))
                            .AddWithValue("@st", GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtSt))
                        End With

                        .CommandText = ("SELECT COUNT(*) FROM tbl_brand WHERE name=@br")
                        es = Convert.ToInt32(.ExecuteScalar)

                        If es = 0 Then
                            .CommandText = ("INSERT INTO tbl_brand (name) VALUES (@br)")
                            .ExecuteNonQuery()
                            CBEditData(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbBr, GetInfo(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbBr))
                        End If

                        .CommandText = ("INSERT INTO " & LCase(My.Settings.Lco) & "_sq_detail (sq_main_id,brand_id,item_name,quantity,uom,price,total_price,dealer_price,margin," & _
                                        "vat_type,free1,amount1,free2,amount2,free3,amount3,note,availability,status,category) " & _
                                        "VALUES ((CASE WHEN (SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev) IS NULL THEN 0 ELSE (SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev) END)," & _
                                        "(CASE WHEN (SELECT ctrl_id FROM tbl_brand WHERE name=@br) IS NULL THEN 0 ELSE (SELECT ctrl_id FROM tbl_brand WHERE name=@br) END)," & _
                                        "@in,@qu,@uom,@pr,@tpr,@dp,@ma,@vt,@f1,@a1,@f2,@a2,@f3,@a3,@note,@av,@st,@ca)")
                        .ExecuteNonQuery()
                    Next
                    CloseConn(slot)
                    MsgBox(GetInfo(TextBox1) & " information is now saved.", vbOKOnly + vbInformation, "Updating Database Success")

                    LBEditData(Label5, "Refreshing ...")
                    Me_Clear()
                    Me_Cmd()

                    For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                        MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
                    Next

                    FrmIDgv.Dispose()
                    frmSQItem.Dispose()

                    bwActivate(0)
                End With
            Catch ex As Exception
                CloseConn(slot)
                NotifyMsgBox("s", "Sales quotation")
            End Try
        Else
            NotifyMsgBox("ps", "Sales quotation")
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    Dim rev() As String = Label4.Text.Split(": ")
                    With .Parameters
                        .Clear()
                        .AddWithValue("@sq", TextBox1.Text.Trim(" "))
                        .AddWithValue("@rev", rev(1).Trim(" "))
                    End With

                    .CommandText = ("SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev")
                    Dim er = .ExecuteReader
                    er.Read()
                    If er.HasRows Then
                        .Parameters.AddWithValue("@id", er(0))
                        er.Close()

                        If ToolStripButton3.Text = "Approve" Then
                            .CommandText = ("UPDATE " & LCase(My.Settings.Lco) & "_sq_main SET status='Approved' WHERE ctrl_id=@id")
                            .ExecuteNonQuery()
                            Label3.Text = "Status: Approved"
                            ToolStripButton3.Text = "Confirm"
                        ElseIf ToolStripButton3.Text = "Confirm" Then
                            .CommandText = ("UPDATE " & LCase(My.Settings.Lco) & "_sq_main SET status='Confirmed' WHERE ctrl_id=@id")
                            .ExecuteNonQuery()

                            Me_Clear()
                            Me_Cmd()

                            For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
                                MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
                            Next

                            FrmIDgv.Dispose()
                            frmSQItem.Dispose()

                            bwActivate(0)
                        End If

                        MsgBox(GetInfo(TextBox1) & " information is now saved.", vbOKOnly + vbInformation, "Updating Database Success")
                    Else
                        MsgBox(GetInfo(TextBox1) & " no information has been found.", vbOKOnly + vbInformation, "Updating Database Failed")
                    End If
                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                If ToolStripButton3.Text = "Approve" Then
                    NotifyMsgBox("a", "Sales quotation")
                ElseIf ToolStripButton3.Text = "Confirm" Then
                    NotifyMsgBox("c", "Sales quotation")
                End If
            End Try
        Else
            If ToolStripButton3.Text = "Approve" Then
                NotifyMsgBox("as", "Sales quotation")
            ElseIf ToolStripButton3.Text = "Confirm" Then
                NotifyMsgBox("cs", "Sales quotation")
            End If
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        With frmSQItem
            If .TabControl1.TabCount = 0 Then
                .Label5.Text = "Loading ..."
                If My.Settings.LGrp = "Supervisor" Then
                    .ToolStripSeparator1.Visible = True
                    .ToolStripButton3.Visible = True
                    .ToolStripButton4.Visible = True
                Else
                    .ToolStripSeparator1.Visible = False
                    .ToolStripButton3.Visible = False
                    .ToolStripButton4.Visible = False
                End If
            End If
            .ShowDialog()
        End With
    End Sub

    Private Sub frmUpdateSQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        If My.Settings.LGrp = "Supervisor" Or My.Settings.LGrp = "Sales" Then
            ToolStripButton3.Visible = True
        End If
    End Sub
End Class