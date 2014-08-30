Imports System.ComponentModel
Public Class frmNewSQ

    Friend WithEvents BwSQ As BackgroundWorker
    Friend WithEvents BwCo As BackgroundWorker
    Friend WithEvents BwTerm As BackgroundWorker
    Dim cosearch, tsearch As String

    Private Sub frmNewSQ_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For i As Integer = 0 To frmSQItem.TabControl1.TabCount - 1
            MDINItem(frmSQItem.TabControl1.TabPages(i).Tag) = Nothing
        Next

        FrmIDgv.Dispose()
        frmSQItem.Dispose()
        Me.Dispose()
    End Sub
    Private Sub frmNewSQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        bwActivate(0)
        bwActivate(1)
        bwActivate(3)
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
                    BwSQ.RunWorkerAsync()
                End If
            Case 1
                If BwCo Is Nothing Then
                    BwCo = New BackgroundWorker
                    With BwCo
                        .WorkerSupportsCancellation = True
                        .WorkerReportsProgress = True
                    End With
                End If

                If BwCo.IsBusy Then
                    BwCo.CancelAsync()
                Else
                    cosearch = cbCompany.Text
                    BwCo.RunWorkerAsync()
                End If
            Case 3
                If BwTerm Is Nothing Then
                    BwTerm = New BackgroundWorker
                    With BwTerm
                        .WorkerSupportsCancellation = True
                        .WorkerReportsProgress = True
                    End With
                End If

                If BwTerm.IsBusy Then
                    BwTerm.CancelAsync()
                Else
                    tsearch = cbTerms.Text
                    BwTerm.RunWorkerAsync()
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

    Delegate Sub SetLabelInvoker(ByVal lb As Label, ByVal txt As String)
    Sub LBEditData(ByVal Lb As Label, ByVal Txt As String)
        If Lb.InvokeRequired = True Then
            Lb.Invoke(New SetLabelInvoker(AddressOf LBEditData), Lb, Txt)
        Else
            Lb.Text = Txt
        End If
    End Sub

    Private Sub BwSQ_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwSQ.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@sq", "%" & NowDate.Date.ToString("yy") & NowDate.Date.ToString("MM") & NowDate.Date.ToString("dd") & "%")
                    End With

                    .CommandText = ("SELECT COUNT(*) FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno LIKE @sq AND revision=0")

                    Dim es = Convert.ToInt32(.ExecuteScalar)
                    es += 1
                    LBEditData(Label2, "SQ Number: " & My.Settings.LIni & NowDate.Date.ToString("yy") & NowDate.Date.ToString("MM") & NowDate.Date.ToString("dd") & Format(es, "000"))
                    LBEditData(Label5, "")
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
            BwSQ.Dispose()
        End If
    End Sub

    Private Sub BwCo_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwCo.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@search", "%" & cosearch & "%")
                    End With

                    .CommandText = ("SELECT name FROM tbl_company WHERE name LIKE @search ORDER BY name ASC")
                    Dim er = .ExecuteReader
                    While er.Read
                        If BwCo.CancellationPending Then
                            Exit While
                        Else
                            CBEditData(cbCompany, er(0))
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

    Private Sub BwCo_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwCo.RunWorkerCompleted
        If e.Cancelled Then
            bwActivate(1)
        Else
            BwCo.Dispose()
        End If
    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles cbCompany.TextChanged
        bwActivate(1)
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

    Dim InfoRes As String
    Delegate Sub SetCtrlInvoker(ByVal ctrl As Control)
    Function Info(ByVal Ctrl As Control)
        If Ctrl.InvokeRequired = True Then
            Ctrl.Invoke(New SetCtrlInvoker(AddressOf Info), Ctrl)
        Else
            InfoRes = Ctrl.Text
        End If

        Return InfoRes
    End Function

    Private Sub BwTerm_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwTerm.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@search", "%" & tsearch & "%")
                    End With

                    .CommandText = ("SELECT name FROM tbl_terms WHERE name LIKE @search ORDER BY name ASC")
                    Dim er = .ExecuteReader
                    While er.Read
                        If BwTerm.CancellationPending Then
                            Exit While
                        Else
                            CBEditData(cbTerms, er(0))
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

    Private Sub BwTerm_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwTerm.RunWorkerCompleted
        If e.Cancelled Then
            bwActivate(3)
        Else
            BwTerm.Dispose()
        End If
    End Sub

    Private Sub cbTerms_TextChanged(sender As Object, e As EventArgs) Handles cbTerms.TextChanged
        bwActivate(3)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        With frmSQItem
            If .TabControl1.TabCount = 0 Then
                .GenerateTab()
            End If
            .ShowDialog()
        End With
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
                    Dim sqini() As String = Label2.Text.Split(": ")

                    With .Parameters
                        .Clear()
                        .AddWithValue("@sq", sqini(1).Trim(" "))
                        .AddWithValue("@co", Info(cbCompany))
                        .AddWithValue("@em", Info(txtEmail))
                        .AddWithValue("@cn", Info(txtCnum))
                        .AddWithValue("@fn", Info(txtFnum))
                        .AddWithValue("@atd", Info(txtAddel))
                        .AddWithValue("@atb", Info(txtAddbill))
                        .AddWithValue("@att", Info(txtAttention))
                        .AddWithValue("@av", Info(txtAvailability))
                        .AddWithValue("@te", Info(cbTerms))
                        .AddWithValue("@del", Info(txtDelivery))
                        .AddWithValue("@pv", Info(txtPriceValidity))
                        .AddWithValue("@ca", Info(txtCancel))
                        .AddWithValue("@dte", NowDate)
                        If My.Settings.LGrp = "Supervisor" Then
                            .AddWithValue("@st", "Approved")
                        ElseIf My.Settings.LGrp = "Sales" Then
                            .AddWithValue("@st", "New")
                        End If
                        .AddWithValue("@rev", 0)
                    End With

                    .CommandText = ("SELECT COUNT(*) FROM tbl_company WHERE name=@co")
                    Dim es = Convert.ToInt32(.ExecuteScalar)

                    If es = 0 Then
                        .CommandText = ("INSERT INTO tbl_company (name) VALUES (@co)")
                        .ExecuteNonQuery()
                        CBEditData(cbCompany, Info(cbCompany))
                    End If

                    .CommandText = ("SELECT COUNT(*) FROM tbl_terms WHERE name=@te")
                    es = Convert.ToInt32(.ExecuteScalar)

                    If es = 0 Then
                        .CommandText = ("INSERT INTO tbl_terms (name) VALUES (@te)")
                        .ExecuteNonQuery()
                        CBEditData(cbTerms, Info(cbTerms))
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
                            .AddWithValue("@sq", sqini(1).Trim(" "))
                            .AddWithValue("@br", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbBr))
                            .AddWithValue("@ca", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbCa))
                            .AddWithValue("@av", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbAv))
                            .AddWithValue("@in", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtIN))
                            .AddWithValue("@qu", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtQu))
                            .AddWithValue("@uom", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtMU))
                            .AddWithValue("@pr", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtIP))
                            .AddWithValue("@tpr", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtTP))
                            .AddWithValue("@dp", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtDP))
                            .AddWithValue("@ma", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtMa))
                            .AddWithValue("@vt", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbVT))
                            .AddWithValue("@f1", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIN1))
                            .AddWithValue("@a1", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIA1))
                            .AddWithValue("@f2", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIN2))
                            .AddWithValue("@a2", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIA2))
                            .AddWithValue("@f3", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIN3))
                            .AddWithValue("@a3", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtFIA3))
                            .AddWithValue("@note", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtDe))
                            If My.Settings.LGrp = "Supervisor" Then
                                .AddWithValue("@st", "Approved")
                            ElseIf My.Settings.LGrp = "Sales" Then
                                .AddWithValue("@st", Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).txtSt))
                            End If
                        End With

                        .CommandText = ("SELECT COUNT(*) FROM tbl_brand WHERE name=@br")
                        es = Convert.ToInt32(.ExecuteScalar)

                        If es = 0 Then
                            .CommandText = ("INSERT INTO tbl_brand (name) VALUES (@br)")
                            .ExecuteNonQuery()
                            CBEditData(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbBr, Info(MDINItem(frmSQItem.TabControl1.TabPages(i).Tag).cbBr))
                        End If

                        .CommandText = ("INSERT INTO " & LCase(My.Settings.Lco) & "_sq_detail (sq_main_id,brand_id,item_name,quantity,uom,price,total_price,dealer_price,margin," & _
                                        "vat_type,free1,amount1,free2,amount2,free3,amount3,note,availability,status,category) " & _
                                        "VALUES ((CASE WHEN (SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=0) IS NULL THEN 0 ELSE (SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=0) END)," & _
                                        "(CASE WHEN (SELECT ctrl_id FROM tbl_brand WHERE name=@br) IS NULL THEN 0 ELSE (SELECT ctrl_id FROM tbl_brand WHERE name=@br) END)," & _
                                        "@in,@qu,@uom,@pr,@tpr,@dp,@ma,@vt,@f1,@a1,@f2,@a2,@f3,@a3,@note,@av,@st,@ca)")
                        .ExecuteNonQuery()
                    Next
                    CloseConn(slot)

                    MsgBox(Info(Label2) & " information is now saved.", vbOKOnly + vbInformation, "Updating Database Success")

                    LBEditData(Label5, "Loading ...")
                    Me_Clear()

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

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim z = MsgBox("Do you wish to clear all available field?", vbQuestion + MsgBoxStyle.YesNo, "Clear Fields")
        If z = MsgBoxResult.Yes Then
            Me_Clear()
        End If
    End Sub
End Class