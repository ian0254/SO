<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewSQ
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewSQ))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbCompany = New System.Windows.Forms.ComboBox()
        Me.lblAddel = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.txtAddbill = New System.Windows.Forms.TextBox()
        Me.txtAttention = New System.Windows.Forms.TextBox()
        Me.txtAddel = New System.Windows.Forms.TextBox()
        Me.lblAddbill = New System.Windows.Forms.Label()
        Me.lblAtt1 = New System.Windows.Forms.Label()
        Me.txtCnum = New System.Windows.Forms.TextBox()
        Me.txtFnum = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblCnum = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.txtPriceValidity = New System.Windows.Forms.TextBox()
        Me.txtCancel = New System.Windows.Forms.TextBox()
        Me.txtDelivery = New System.Windows.Forms.TextBox()
        Me.txtAvailability = New System.Windows.Forms.TextBox()
        Me.lblCancellation = New System.Windows.Forms.Label()
        Me.lblPriceValidity = New System.Windows.Forms.Label()
        Me.lblDelivery = New System.Windows.Forms.Label()
        Me.lblTerms = New System.Windows.Forms.Label()
        Me.lvlAvail = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1072, 97)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.cbCompany)
        Me.GroupBox1.Controls.Add(Me.lblAddel)
        Me.GroupBox1.Controls.Add(Me.lblFax)
        Me.GroupBox1.Controls.Add(Me.txtAddbill)
        Me.GroupBox1.Controls.Add(Me.txtAttention)
        Me.GroupBox1.Controls.Add(Me.txtAddel)
        Me.GroupBox1.Controls.Add(Me.lblAddbill)
        Me.GroupBox1.Controls.Add(Me.lblAtt1)
        Me.GroupBox1.Controls.Add(Me.txtCnum)
        Me.GroupBox1.Controls.Add(Me.txtFnum)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.lblCnum)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.lblCompany)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1072, 168)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Detail"
        '
        'cbCompany
        '
        Me.cbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCompany.FormattingEnabled = True
        Me.cbCompany.Location = New System.Drawing.Point(187, 23)
        Me.cbCompany.MaxLength = 32767
        Me.cbCompany.Name = "cbCompany"
        Me.cbCompany.Size = New System.Drawing.Size(345, 26)
        Me.cbCompany.TabIndex = 1
        '
        'lblAddel
        '
        Me.lblAddel.AutoSize = True
        Me.lblAddel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblAddel.Location = New System.Drawing.Point(548, 24)
        Me.lblAddel.Name = "lblAddel"
        Me.lblAddel.Size = New System.Drawing.Size(148, 18)
        Me.lblAddel.TabIndex = 7
        Me.lblAddel.Text = "Address (To Deliver):"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblFax.Location = New System.Drawing.Point(71, 119)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(93, 18)
        Me.lblFax.TabIndex = 0
        Me.lblFax.Text = "Fax Number:"
        '
        'txtAddbill
        '
        Me.txtAddbill.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAddbill.Location = New System.Drawing.Point(718, 56)
        Me.txtAddbill.Name = "txtAddbill"
        Me.txtAddbill.Size = New System.Drawing.Size(342, 26)
        Me.txtAddbill.TabIndex = 6
        '
        'txtAttention
        '
        Me.txtAttention.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAttention.Location = New System.Drawing.Point(718, 91)
        Me.txtAttention.Name = "txtAttention"
        Me.txtAttention.Size = New System.Drawing.Size(342, 26)
        Me.txtAttention.TabIndex = 7
        '
        'txtAddel
        '
        Me.txtAddel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAddel.Location = New System.Drawing.Point(718, 24)
        Me.txtAddel.Name = "txtAddel"
        Me.txtAddel.Size = New System.Drawing.Size(342, 26)
        Me.txtAddel.TabIndex = 5
        '
        'lblAddbill
        '
        Me.lblAddbill.AutoSize = True
        Me.lblAddbill.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblAddbill.Location = New System.Drawing.Point(576, 56)
        Me.lblAddbill.Name = "lblAddbill"
        Me.lblAddbill.Size = New System.Drawing.Size(122, 18)
        Me.lblAddbill.TabIndex = 5
        Me.lblAddbill.Text = "Address (To Bill):"
        '
        'lblAtt1
        '
        Me.lblAtt1.AutoSize = True
        Me.lblAtt1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblAtt1.Location = New System.Drawing.Point(625, 91)
        Me.lblAtt1.Name = "lblAtt1"
        Me.lblAtt1.Size = New System.Drawing.Size(72, 18)
        Me.lblAtt1.TabIndex = 6
        Me.lblAtt1.Text = "Attention:"
        '
        'txtCnum
        '
        Me.txtCnum.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCnum.Location = New System.Drawing.Point(187, 87)
        Me.txtCnum.Name = "txtCnum"
        Me.txtCnum.Size = New System.Drawing.Size(345, 26)
        Me.txtCnum.TabIndex = 3
        '
        'txtFnum
        '
        Me.txtFnum.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtFnum.Location = New System.Drawing.Point(187, 119)
        Me.txtFnum.Name = "txtFnum"
        Me.txtFnum.Size = New System.Drawing.Size(345, 26)
        Me.txtFnum.TabIndex = 4
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(187, 55)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(345, 26)
        Me.txtEmail.TabIndex = 2
        '
        'lblCnum
        '
        Me.lblCnum.AutoSize = True
        Me.lblCnum.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblCnum.Location = New System.Drawing.Point(43, 87)
        Me.lblCnum.Name = "lblCnum"
        Me.lblCnum.Size = New System.Drawing.Size(120, 18)
        Me.lblCnum.TabIndex = 0
        Me.lblCnum.Text = "Contact Number:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(117, 55)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(48, 18)
        Me.lblEmail.TabIndex = 0
        Me.lblEmail.Text = "Email:"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(86, 23)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(74, 18)
        Me.lblCompany.TabIndex = 0
        Me.lblCompany.Text = "Company:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "New Sales Quotation"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.cbTerms)
        Me.GroupBox2.Controls.Add(Me.txtPriceValidity)
        Me.GroupBox2.Controls.Add(Me.txtCancel)
        Me.GroupBox2.Controls.Add(Me.txtDelivery)
        Me.GroupBox2.Controls.Add(Me.txtAvailability)
        Me.GroupBox2.Controls.Add(Me.lblCancellation)
        Me.GroupBox2.Controls.Add(Me.lblPriceValidity)
        Me.GroupBox2.Controls.Add(Me.lblDelivery)
        Me.GroupBox2.Controls.Add(Me.lblTerms)
        Me.GroupBox2.Controls.Add(Me.lvlAvail)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 306)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1072, 232)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Terms And Conditions"
        '
        'cbTerms
        '
        Me.cbTerms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbTerms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTerms.BackColor = System.Drawing.SystemColors.Control
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(187, 117)
        Me.cbTerms.MaxLength = 32767
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(345, 26)
        Me.cbTerms.TabIndex = 9
        '
        'txtPriceValidity
        '
        Me.txtPriceValidity.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtPriceValidity.Location = New System.Drawing.Point(710, 40)
        Me.txtPriceValidity.Multiline = True
        Me.txtPriceValidity.Name = "txtPriceValidity"
        Me.txtPriceValidity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPriceValidity.Size = New System.Drawing.Size(345, 68)
        Me.txtPriceValidity.TabIndex = 11
        '
        'txtCancel
        '
        Me.txtCancel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtCancel.Location = New System.Drawing.Point(710, 114)
        Me.txtCancel.Multiline = True
        Me.txtCancel.Name = "txtCancel"
        Me.txtCancel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCancel.Size = New System.Drawing.Size(345, 68)
        Me.txtCancel.TabIndex = 12
        '
        'txtDelivery
        '
        Me.txtDelivery.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtDelivery.Location = New System.Drawing.Point(187, 149)
        Me.txtDelivery.Multiline = True
        Me.txtDelivery.Name = "txtDelivery"
        Me.txtDelivery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDelivery.Size = New System.Drawing.Size(345, 68)
        Me.txtDelivery.TabIndex = 10
        '
        'txtAvailability
        '
        Me.txtAvailability.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.txtAvailability.Location = New System.Drawing.Point(187, 43)
        Me.txtAvailability.Multiline = True
        Me.txtAvailability.Name = "txtAvailability"
        Me.txtAvailability.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAvailability.Size = New System.Drawing.Size(345, 68)
        Me.txtAvailability.TabIndex = 8
        '
        'lblCancellation
        '
        Me.lblCancellation.AutoSize = True
        Me.lblCancellation.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblCancellation.Location = New System.Drawing.Point(605, 120)
        Me.lblCancellation.Name = "lblCancellation"
        Me.lblCancellation.Size = New System.Drawing.Size(91, 18)
        Me.lblCancellation.TabIndex = 0
        Me.lblCancellation.Text = "Cancellation:"
        '
        'lblPriceValidity
        '
        Me.lblPriceValidity.AutoSize = True
        Me.lblPriceValidity.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblPriceValidity.Location = New System.Drawing.Point(599, 46)
        Me.lblPriceValidity.Name = "lblPriceValidity"
        Me.lblPriceValidity.Size = New System.Drawing.Size(95, 18)
        Me.lblPriceValidity.TabIndex = 0
        Me.lblPriceValidity.Text = "Price Validity:"
        '
        'lblDelivery
        '
        Me.lblDelivery.AutoSize = True
        Me.lblDelivery.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblDelivery.Location = New System.Drawing.Point(97, 149)
        Me.lblDelivery.Name = "lblDelivery"
        Me.lblDelivery.Size = New System.Drawing.Size(64, 18)
        Me.lblDelivery.TabIndex = 0
        Me.lblDelivery.Text = "Delivery:"
        '
        'lblTerms
        '
        Me.lblTerms.AutoSize = True
        Me.lblTerms.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lblTerms.Location = New System.Drawing.Point(105, 117)
        Me.lblTerms.Name = "lblTerms"
        Me.lblTerms.Size = New System.Drawing.Size(55, 18)
        Me.lblTerms.TabIndex = 0
        Me.lblTerms.Text = "Terms:"
        '
        'lvlAvail
        '
        Me.lvlAvail.AutoSize = True
        Me.lvlAvail.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.lvlAvail.Location = New System.Drawing.Point(86, 43)
        Me.lvlAvail.Name = "lvlAvail"
        Me.lvlAvail.Size = New System.Drawing.Size(80, 18)
        Me.lvlAvail.TabIndex = 0
        Me.lvlAvail.Text = "Availability:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "SQ Number: N/A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Loading ..."
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.MySql_Jump_.My.Resources.Resources.page_white_delete
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(45, 38)
        Me.ToolStripButton5.Text = "Clear"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 41)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.MySql_Jump_.My.Resources.Resources.disk
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(43, 38)
        Me.ToolStripButton3.Text = "Save"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 41)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.MySql_Jump_.My.Resources.Resources.basket
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(51, 38)
        Me.ToolStripButton6.Text = "Items"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 97)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1072, 41)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frmNewSQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OliveDrab
        Me.ClientSize = New System.Drawing.Size(1072, 542)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNewSQ"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents lblAddel As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtAddbill As System.Windows.Forms.TextBox
    Friend WithEvents txtAttention As System.Windows.Forms.TextBox
    Friend WithEvents txtAddel As System.Windows.Forms.TextBox
    Friend WithEvents lblAddbill As System.Windows.Forms.Label
    Friend WithEvents lblAtt1 As System.Windows.Forms.Label
    Friend WithEvents txtCnum As System.Windows.Forms.TextBox
    Friend WithEvents txtFnum As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblCnum As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbTerms As System.Windows.Forms.ComboBox
    Friend WithEvents txtPriceValidity As System.Windows.Forms.TextBox
    Friend WithEvents txtCancel As System.Windows.Forms.TextBox
    Friend WithEvents txtDelivery As System.Windows.Forms.TextBox
    Friend WithEvents txtAvailability As System.Windows.Forms.TextBox
    Friend WithEvents lblCancellation As System.Windows.Forms.Label
    Friend WithEvents lblPriceValidity As System.Windows.Forms.Label
    Friend WithEvents lblDelivery As System.Windows.Forms.Label
    Friend WithEvents lblTerms As System.Windows.Forms.Label
    Friend WithEvents lvlAvail As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
End Class
