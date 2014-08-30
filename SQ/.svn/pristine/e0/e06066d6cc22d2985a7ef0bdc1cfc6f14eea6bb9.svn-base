Imports System.ComponentModel

Public Class frmSQItem

    Friend WithEvents BwItem As BackgroundWorker
    Dim sqsearch As String
    Dim revsearch As String
    Dim itemid As New ArrayList

    Private Sub bwActivate(ByVal a As Integer)
        Select Case a
            Case 0
                If BwItem Is Nothing Then
                    BwItem = New BackgroundWorker
                    With BwItem
                        .WorkerSupportsCancellation = True
                        .WorkerReportsProgress = True
                    End With
                End If

                If BwItem.IsBusy Then
                    BwItem.CancelAsync()
                Else
                    If Label1.Text = "Sales Quotation Item" Then
                        Dim rev() As String = frmUpdateSQ.Label4.Text.Split(":")
                        revsearch = rev(1).Trim(" ")
                        sqsearch = frmUpdateSQ.TextBox1.Text
                    ElseIf Label1.Text = "Sales Order Item" Then
                        Dim rev() As String = frmUpdateSO.Label4.Text.Split(":")
                        revsearch = rev(1).Trim(" ")
                        sqsearch = frmUpdateSO.TextBox1.Text
                    End If
                    itemid.Clear()
                    BwItem.RunWorkerAsync()
                End If
        End Select
    End Sub

    Delegate Sub SetCtrlInvoker(ByVal ctrl As Control, ByVal txt As String)
    Sub SetCtrl(ByVal Ctrl As Control, ByVal Txt As String)
        If Ctrl.InvokeRequired = True Then
            Ctrl.Invoke(New SetCtrlInvoker(AddressOf SetCtrl), Ctrl, Txt)
        Else
            If TypeOf Ctrl Is UserControl Then
                CType(Ctrl, UserControl).Dock = DockStyle.Fill
                CType(Ctrl, UserControl).Tag = Txt
            ElseIf TypeOf Ctrl Is TabControl Then
                CType(Ctrl, TabControl).TabPages.Add(CType(Ctrl, TabControl).TabCount + 1)
                CType(Ctrl, TabControl).SelectedIndex = CType(Ctrl, TabControl).TabCount - 1
                CType(Ctrl, TabControl).SelectedTab.Controls.Add(MDINItem(CType(Ctrl, TabControl).TabCount - 1))
                CType(Ctrl, TabControl).SelectedTab.AutoScroll = True
                CType(Ctrl, TabControl).SelectedTab.Tag = CType(Ctrl, TabControl).TabCount - 1
                CType(Ctrl, TabControl).Refresh()
            ElseIf TypeOf Ctrl Is TextBox Then
                CType(Ctrl, TextBox).Text = Txt
                With CType(Ctrl, TextBox)
                    Select Case .Name
                        Case "cbBr", "txtIN", "txtMU", "txtDe"
                            If .Text = "" Then .Region = New Region(New Rectangle(2, 2, .Width - 4, .Height - 4)) Else .Region = Nothing
                        Case "txtQu", "txtIP", "txtDP"
                            If Val(.Text) = 0 Then .Region = New Region(New Rectangle(2, 2, .Width - 4, .Height - 4)) Else .Region = Nothing
                    End Select
                End With
            ElseIf TypeOf Ctrl Is ComboBox Then
                    CType(Ctrl, ComboBox).Text = Txt
            ElseIf TypeOf Ctrl Is Label Then
                    CType(Ctrl, Label).Text = Txt
            ElseIf TypeOf Ctrl Is RichTextBox Then
                    CType(Ctrl, RichTextBox).Text = Txt
            End If
        End If
    End Sub

    Private Sub BwItem_DoWork(sender As Object, e As DoWorkEventArgs) Handles BwItem.DoWork
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@sq", sqsearch)
                        .AddWithValue("@rev", revsearch)
                    End With
                    .CommandText = ("SELECT (CASE WHEN (SELECT name FROM tbl_brand WHERE ctrl_id=brand_id) IS NULL THEN '' ELSE (SELECT name FROM tbl_brand WHERE ctrl_id=brand_id) END)," & _
                                    "item_name,quantity,uom,price,total_price,dealer_price,margin,vat_type,free1,amount1,free2,amount2,free3,amount3,note,availability,status,category,ctrl_id " & _
                                    "FROM " & LCase(My.Settings.Lco) & "_sq_detail WHERE sq_main_id=(SELECT ctrl_id FROM " & LCase(My.Settings.Lco) & "_sq_main WHERE sqno=@sq AND revision=@rev)")
                    Dim er = .ExecuteReader
                    While er.Read
                        MDINItem(TabControl1.TabCount) = New UCNItems
                        With MDINItem(TabControl1.TabCount)
                            SetCtrl(.cbBr, er(0))
                            SetCtrl(.txtIN, er(1))
                            SetCtrl(.txtQu, er(2))
                            SetCtrl(.txtMU, er(3))
                            SetCtrl(.txtIP, er(4))
                            SetCtrl(.txtTP, er(5))
                            SetCtrl(.txtDP, er(6))
                            SetCtrl(.txtMa, er(7))
                            SetCtrl(.cbVT, er(8))
                            SetCtrl(.txtFIN1, er(9))
                            SetCtrl(.txtFIA1, er(10))
                            SetCtrl(.txtFIN2, er(11))
                            SetCtrl(.txtFIA2, er(12))
                            SetCtrl(.txtFIN3, er(13))
                            SetCtrl(.txtFIA3, er(14))
                            SetCtrl(.txtDe, er(15))
                            SetCtrl(.cbAv, er(16))
                            SetCtrl(.txtSt, er(17))
                            SetCtrl(.cbCa, er(18))
                            itemid.Add(er(19))
                        End With
                        SetCtrl(MDINItem(TabControl1.TabCount), TabControl1.TabCount)
                        SetCtrl(TabControl1, "")
                        MDINItem(TabControl1.TabCount - 1).flag = True
                        SetCtrl(Label5, TabControl1.TabCount & " item record has been loaded ...")
                    End While
                    er.Close()
                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                e.Cancel = True
                MsgBox(ex.ToString)
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub BwItem_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BwItem.RunWorkerCompleted
        If e.Cancelled Then
            bwActivate(0)
        Else
            If TabControl1.TabCount > 0 Then
                DgVDefault(TabControl1.TabCount - 1, 1)
            Else
                GenerateTab()
                SetCtrl(Label5, "No item has been found ...")
            End If
            BwItem.Dispose()
        End If
    End Sub

    Public Sub GenerateTab()
        Label5.Text = ""
        ToolStripButton2.Enabled = True
        For i As Integer = 0 To MDINItem.Length - 1
            If MDINItem(i) Is Nothing Then
                MDINItem(i) = New UCNItems
                MDINItem(i).Dock = DockStyle.Fill
                MDINItem(i).Tag = i
                With TabControl1
                    .TabPages.Add(TabControl1.TabCount + 1)
                    .SelectedIndex = .TabCount - 1
                    .SelectedTab.Controls.Add(MDINItem(i))
                    .SelectedTab.AutoScroll = True
                    .SelectedTab.Tag = i
                End With

                With MDINItem(i)
                    .txtDP.Region = New Region(New Rectangle(2, 2, .txtDP.Width - 4, .txtDP.Height - 4))
                    .txtIP.Region = New Region(New Rectangle(2, 2, .txtIP.Width - 4, .txtIP.Height - 4))
                    .cbBr.Region = New Region(New Rectangle(2, 2, .cbBr.Width - 4, .cbBr.Height - 4))
                    .txtIN.Region = New Region(New Rectangle(2, 2, .txtIN.Width - 4, .txtIN.Height - 4))
                    .txtMU.Region = New Region(New Rectangle(2, 2, .txtMU.Width - 4, .txtMU.Height - 4))
                    .txtDe.Region = New Region(New Rectangle(2, 2, .txtDe.Width - 4, .txtDe.Height - 4))
                End With

                If My.Settings.LGrp = "Supervisor" Then
                    MDINItem(i).txtSt.Text = "Approved"
                Else
                    MDINItem(i).txtSt.Text = "New"
                End If

                DgVDefault(i, i)
                MDINItem(i).flag = True
                Exit For
            End If
        Next

        If TabControl1.TabCount = MDINItem.Length Then
            ToolStripButton1.Enabled = False
        End If
    End Sub

    Public Sub DgVDefault(ByVal i As Integer, ByVal mode As Integer)
        If mode = 0 Then
            With FrmIDgv.DataGridView1
                .Item(0, .RowCount - 1).Value = MDINItem(i).cbCa.Text
                .Item(1, .RowCount - 1).Value = MDINItem(i).cbBr.Text
                .Item(2, .RowCount - 1).Value = MDINItem(i).cbAv.Text
                .Item(3, .RowCount - 1).Value = MDINItem(i).txtIN.Text
                .Item(4, .RowCount - 1).Value = MDINItem(i).txtMU.Text
                .Item(5, .RowCount - 1).Value = MDINItem(i).cbVT.Text
                .Item(6, .RowCount - 1).Value = MDINItem(i).txtDe.Text
                .Item(7, .RowCount - 1).Value = MDINItem(i).txtQu.Text
                .Item(8, .RowCount - 1).Value = MDINItem(i).txtIP.Text
                .Item(9, .RowCount - 1).Value = MDINItem(i).txtTP.Text
                .Item(10, .RowCount - 1).Value = MDINItem(i).txtDP.Text
                .Item(11, .RowCount - 1).Value = MDINItem(i).txtMa.Text
                .Item(12, .RowCount - 1).Value = MDINItem(i).txtFIN1.Text
                .Item(13, .RowCount - 1).Value = MDINItem(i).txtFIA1.Text
                .Item(14, .RowCount - 1).Value = MDINItem(i).txtFIN2.Text
                .Item(15, .RowCount - 1).Value = MDINItem(i).txtFIA2.Text
                .Item(16, .RowCount - 1).Value = MDINItem(i).txtFIN3.Text
                .Item(17, .RowCount - 1).Value = MDINItem(i).txtFIA3.Text
                .Item(18, .RowCount - 1).Value = MDINItem(i).txtSt.Text
                With MDINItem(i)
                    .cbAv.AutoCompleteSource = AutoCompleteSource.ListItems
                    .cbAv.AutoCompleteMode = AutoCompleteMode.Suggest
                    .cbBr.AutoCompleteSource = AutoCompleteSource.ListItems
                    .cbBr.AutoCompleteMode = AutoCompleteMode.Suggest
                    .cbCa.AutoCompleteSource = AutoCompleteSource.ListItems
                    .cbCa.AutoCompleteMode = AutoCompleteMode.Suggest
                    .cbVT.AutoCompleteSource = AutoCompleteSource.ListItems
                    .cbVT.AutoCompleteMode = AutoCompleteMode.Suggest
                End With
            End With
        Else
            For ii As Integer = 0 To i
                With FrmIDgv.DataGridView1
                    .Item(0, ii).Value = MDINItem(ii).cbCa.Text
                    .Item(1, ii).Value = MDINItem(ii).cbBr.Text
                    .Item(2, ii).Value = MDINItem(ii).cbAv.Text
                    .Item(3, ii).Value = MDINItem(ii).txtIN.Text
                    .Item(4, ii).Value = MDINItem(ii).txtMU.Text
                    .Item(5, ii).Value = MDINItem(ii).cbVT.Text
                    .Item(6, ii).Value = MDINItem(ii).txtDe.Text
                    .Item(7, ii).Value = MDINItem(ii).txtQu.Text
                    .Item(8, ii).Value = MDINItem(ii).txtIP.Text
                    .Item(9, ii).Value = MDINItem(ii).txtTP.Text
                    .Item(10, ii).Value = MDINItem(ii).txtDP.Text
                    .Item(11, ii).Value = MDINItem(ii).txtMa.Text
                    .Item(12, ii).Value = MDINItem(ii).txtFIN1.Text
                    .Item(13, ii).Value = MDINItem(ii).txtFIA1.Text
                    .Item(14, ii).Value = MDINItem(ii).txtFIN2.Text
                    .Item(15, ii).Value = MDINItem(ii).txtFIA2.Text
                    .Item(16, ii).Value = MDINItem(ii).txtFIN3.Text
                    .Item(17, ii).Value = MDINItem(ii).txtFIA3.Text
                    .Item(18, ii).Value = MDINItem(ii).txtSt.Text
                    With MDINItem(ii)
                        .cbAv.AutoCompleteSource = AutoCompleteSource.ListItems
                        .cbAv.AutoCompleteMode = AutoCompleteMode.Suggest
                        .cbBr.AutoCompleteSource = AutoCompleteSource.ListItems
                        .cbBr.AutoCompleteMode = AutoCompleteMode.Suggest
                        .cbCa.AutoCompleteSource = AutoCompleteSource.ListItems
                        .cbCa.AutoCompleteMode = AutoCompleteMode.Suggest
                        .cbVT.AutoCompleteSource = AutoCompleteSource.ListItems
                        .cbVT.AutoCompleteMode = AutoCompleteMode.Suggest
                    End With
                    If Label1.Text = "Sales Order Item" Then
                        If My.Settings.LGrp = "Logistics" Then
                            ToolStripSeparator1.Visible = False
                            ToolStripButton3.Visible = False
                            ToolStripButton4.Visible = False
                            ToolStripButton1.Visible = False
                            ToolStripButton2.Visible = False
                            ToolStripButton5.Visible = False
                            ToolStripSeparator1.Visible = False
                            ToolStripSeparator2.Visible = False
                            If itemid.Count > 0 And TabControl1.SelectedIndex < itemid.Count Then
                                ToolStripButton7.Visible = True
                                If MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Approved" Then
                                    ToolStripButton7.Enabled = True
                                Else
                                    ToolStripButton7.Enabled = False
                                End If
                            Else
                                ToolStripButton7.Visible = False
                            End If
                        ElseIf MDINItem(ii).txtSt.Text = "Delivered" Then
                            delflag = True
                            ToolStripButton1.Visible = False
                            ToolStripButton2.Visible = False
                            ToolStripButton3.Visible = False
                            ToolStripButton4.Visible = False
                            ToolStripButton5.Visible = False
                            ToolStripSeparator1.Visible = False
                            ToolStripSeparator2.Visible = False
                            frmUpdateSO.ToolStripButton5.Visible = False
                            frmUpdateSO.ToolStripButton1.Visible = False
                            frmUpdateSO.ToolStripSeparator1.Visible = False
                            frmUpdateSO.ToolStripSeparator2.Visible = False
                            ToolStripButton7.Enabled = False
                        End If
                    End If
                End With
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmSQItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmIDgv.Hide()
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmSQItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

        If My.Settings.Lco = "All" Then
            Label1.BackColor = Color.OliveDrab
            Label5.BackColor = Color.OliveDrab
            PictureBox1.BackColor = Color.OliveDrab
            If Label1.Text = "Sales Order Item" Then Me.Text = "Administrator S.O. Management" Else Me.Text = "Administrator S.Q. Management"
        ElseIf My.Settings.Lco = "JUMP" Then
            Label1.BackColor = Color.Maroon
            Label5.BackColor = Color.Maroon
            PictureBox1.BackColor = Color.Maroon
            If Label1.Text = "Sales Order Item" Then Me.Text = My.Settings.Lco & " S.O. Management" Else Me.Text = My.Settings.Lco & " S.Q. Management"
        ElseIf My.Settings.Lco = "FIT" Then
            Label1.BackColor = Color.CornflowerBlue
            Label5.BackColor = Color.CornflowerBlue
            PictureBox1.BackColor = Color.CornflowerBlue
            If Label1.Text = "Sales Order Item" Then Me.Text = My.Settings.Lco & " S.O. Management" Else Me.Text = My.Settings.Lco & " S.Q. Management"
        ElseIf My.Settings.Lco = "SSI" Then
            Label1.BackColor = Color.Tomato
            Label5.BackColor = Color.Tomato
            PictureBox1.BackColor = Color.Tomato
            If Label1.Text = "Sales Order Item" Then Me.Text = My.Settings.Lco & " S.O. Management" Else Me.Text = My.Settings.Lco & " S.Q. Management"
        End If
    End Sub

    Private Sub frmSQItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Label5.Text = "Loading ..." Then
            bwActivate(0)
        End If
    End Sub

    Private Sub TabControl1_ControlAdded(sender As Object, e As ControlEventArgs) Handles TabControl1.ControlAdded
        FrmIDgv.DataGridView1.Rows.Add()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim z = MsgBox("Do you wish to clear all available field?", vbQuestion + MsgBoxStyle.YesNo, "Clear Fields")
        If z = MsgBoxResult.Yes Then
            For i As Integer = 0 To MDINItem.Length - 1
                If MDINItem(i).Tag = TabControl1.SelectedTab.Tag Then
                    MDINItem(i).flag = False
                    For Each c As Control In MDINItem(i).GroupBox1.Controls
                        If TypeOf c Is TextBox Then
                            If CType(c, TextBox).ReadOnly = False Then
                                CType(c, TextBox).Clear()
                            End If
                        ElseIf TypeOf c Is ComboBox Then
                            If CType(c, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList Then
                                CType(c, ComboBox).SelectedIndex = 0
                            Else
                                CType(c, ComboBox).Text = ""
                            End If
                        ElseIf TypeOf c Is RichTextBox Then
                            CType(c, RichTextBox).Clear()
                        End If
                    Next

                    For Each c As Control In MDINItem(i).GroupBox2.Controls
                        If TypeOf c Is TextBox Then
                            If IsNumeric(CType(c, TextBox).Text) Then
                                Dim sp() As String = CType(c, TextBox).Text.Split(".")
                                If sp.Length > 1 Then
                                    CType(c, TextBox).Text = "0.00"
                                Else
                                    CType(c, TextBox).Text = 1
                                End If
                            Else
                                CType(c, TextBox).Clear()
                            End If
                        End If
                    Next
                    MDINItem(i).flag = True

                    With MDINItem(i)
                        .txtDP.Region = New Region(New Rectangle(2, 2, .txtDP.Width - 4, .txtDP.Height - 4))
                        .txtIP.Region = New Region(New Rectangle(2, 2, .txtIP.Width - 4, .txtIP.Height - 4))
                        .cbBr.Region = New Region(New Rectangle(2, 2, .cbBr.Width - 4, .cbBr.Height - 4))
                        .txtIN.Region = New Region(New Rectangle(2, 2, .txtIN.Width - 4, .txtIN.Height - 4))
                        .txtMU.Region = New Region(New Rectangle(2, 2, .txtMU.Width - 4, .txtMU.Height - 4))
                        .txtDe.Region = New Region(New Rectangle(2, 2, .txtDe.Width - 4, .txtDe.Height - 4))
                    End With
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        FrmIDgv.Show()
        If FrmIDgv.WindowState = FormWindowState.Minimized Then
            FrmIDgv.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        GenerateTab()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        For i As Integer = 0 To MDINItem.Length - 1
            If Not MDINItem(i) Is Nothing Then
                If MDINItem(i).Tag = TabControl1.SelectedTab.Tag Then
                    MDINItem(i) = Nothing

                    FrmIDgv.DataGridView1.Rows.RemoveAt(TabControl1.SelectedIndex)

                    If itemid.Count > 0 Then
                        Try
                            itemid.RemoveAt(TabControl1.SelectedIndex)
                        Catch
                        End Try
                    End If

                    If TabControl1.SelectedIndex > 0 Then
                        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
                        TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex + 1)
                    Else
                        TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex)
                    End If
                    Exit For
                End If
            End If
        Next

        For i As Integer = 0 To TabControl1.TabCount - 1
            TabControl1.TabPages(i).Text = (i + 1)
        Next

        If TabControl1.TabCount = 0 Then
            ToolStripButton2.Enabled = False
        ElseIf TabControl1.TabCount < MDINItem.Length Then
            ToolStripButton1.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@iid", itemid(TabControl1.SelectedIndex))
                    End With

                    .CommandText = ("UPDATE " & LCase(My.Settings.Lco) & "_sq_detail SET status='Delivered' WHERE ctrl_id=@iid")
                    .ExecuteNonQuery()

                    MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Delivered"
                    ToolStripButton7.Enabled = False

                    MsgBox(frmUpdateSQ.TextBox1.Text.Trim(" ") & " information is now saved.", vbOKOnly + vbInformation, "Updating Database Success")

                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                NotifyMsgBox("a", "Item")
            End Try
        Else
            NotifyMsgBox("as", "Item")
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@iid", itemid(TabControl1.SelectedIndex))
                    End With

                    .CommandText = ("UPDATE " & LCase(My.Settings.Lco) & "_sq_detail SET status='Approved' WHERE ctrl_id=@iid")
                    .ExecuteNonQuery()

                    MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Approved"
                    ToolStripButton3.Enabled = False
                    ToolStripButton4.Enabled = True

                    MsgBox(frmUpdateSQ.TextBox1.Text.Trim(" ") & " information is now saved.", vbOKOnly + vbInformation, "Updating Database Success")

                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                NotifyMsgBox("a", "Item")
            End Try
        Else
            NotifyMsgBox("as", "Item")
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim slot As Integer = CreateConn(-1)
        If slot > 0 Then
            Try
                With sqlcommand(slot)
                    With .Parameters
                        .Clear()
                        .AddWithValue("@iid", itemid(TabControl1.SelectedIndex))
                        .AddWithValue("@sq", sqsearch)
                        .AddWithValue("@rev", revsearch)
                    End With

                    .CommandText = ("UPDATE " & LCase(My.Settings.Lco) & "_sq_main SET status='Rejected' WHERE sqno=@sq AND revision=@rev")
                    .ExecuteNonQuery()

                    If Label1.Text = "Sales Order Item" Then
                        frmUpdateSO.Label3.Text = "Status: Rejected"
                    Else
                        frmUpdateSQ.Label3.Text = "Status: Rejected"
                        frmUpdateSQ.ToolStripButton3.Text = "Approve"
                        frmUpdateSQ.ToolStripButton3.Visible = True
                    End If

                    .CommandText = ("UPDATE " & LCase(My.Settings.Lco) & "_sq_detail SET status='Rejected' WHERE ctrl_id=@iid")
                    .ExecuteNonQuery()

                    MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Denied"
                    ToolStripButton3.Enabled = True
                    ToolStripButton4.Enabled = False

                    MsgBox(frmUpdateSQ.TextBox1.Text.Trim(" ") & " information is now saved.", vbOKOnly + vbInformation, "Updating Database Success")
                    CloseConn(slot)
                End With
            Catch ex As Exception
                CloseConn(slot)
                NotifyMsgBox("d", "Item")
            End Try
        Else
            NotifyMsgBox("ds", "Item")
        End If
    End Sub

    Dim delflag As Boolean = False
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If Not delflag Then
                If My.Settings.LGrp = "Supervisor" Then
                    If itemid.Count > 0 And TabControl1.SelectedIndex < itemid.Count Then
                        ToolStripSeparator1.Visible = True
                        ToolStripButton3.Visible = True
                        ToolStripButton4.Visible = True
                        If MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Approved" Then
                            ToolStripButton3.Enabled = False
                            ToolStripButton4.Enabled = True
                        ElseIf MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Rejected" Then
                            ToolStripButton3.Enabled = True
                            ToolStripButton4.Enabled = False
                        Else
                            ToolStripButton3.Enabled = True
                            ToolStripButton4.Enabled = True
                        End If
                    Else
                        ToolStripSeparator1.Visible = False
                        ToolStripButton3.Visible = False
                        ToolStripButton4.Visible = False
                    End If
                ElseIf My.Settings.LGrp = "Logistics" Then
                    ToolStripSeparator1.Visible = False
                    ToolStripButton3.Visible = False
                    ToolStripButton4.Visible = False
                    ToolStripButton1.Visible = False
                    ToolStripButton2.Visible = False
                    ToolStripButton5.Visible = False
                    ToolStripSeparator1.Visible = False
                    ToolStripSeparator2.Visible = False
                    If itemid.Count > 0 And TabControl1.SelectedIndex < itemid.Count Then
                        ToolStripButton7.Visible = True
                        If MDINItem(TabControl1.SelectedTab.Tag).txtSt.Text = "Approved" Then
                            ToolStripButton7.Enabled = True
                        Else
                            ToolStripButton7.Enabled = False
                        End If
                    Else
                        ToolStripButton7.Visible = False
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
End Class