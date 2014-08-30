<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDbConn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDbConn))
        Me.BtnDefault = New System.Windows.Forms.Button()
        Me.TxtPort = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUn = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtDb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnResFld = New System.Windows.Forms.Button()
        Me.BtnSaveSet = New System.Windows.Forms.Button()
        Me.BtnClearFld = New System.Windows.Forms.Button()
        Me.BtnTestConn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnDefault
        '
        Me.BtnDefault.BackColor = System.Drawing.SystemColors.Control
        Me.BtnDefault.Location = New System.Drawing.Point(147, 255)
        Me.BtnDefault.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.BtnDefault.Name = "BtnDefault"
        Me.BtnDefault.Size = New System.Drawing.Size(62, 28)
        Me.BtnDefault.TabIndex = 57
        Me.BtnDefault.Text = "Default"
        Me.BtnDefault.UseVisualStyleBackColor = False
        '
        'TxtPort
        '
        Me.TxtPort.Location = New System.Drawing.Point(14, 257)
        Me.TxtPort.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(123, 26)
        Me.TxtPort.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 233)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 18)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Port"
        '
        'TxtPass
        '
        Me.TxtPass.Location = New System.Drawing.Point(14, 201)
        Me.TxtPass.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(267, 26)
        Me.TxtPass.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 177)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 18)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Password"
        '
        'TxtUn
        '
        Me.TxtUn.Location = New System.Drawing.Point(14, 145)
        Me.TxtUn.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TxtUn.Name = "TxtUn"
        Me.TxtUn.Size = New System.Drawing.Size(267, 26)
        Me.TxtUn.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 121)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 18)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Username"
        '
        'TxtDb
        '
        Me.TxtDb.Location = New System.Drawing.Point(14, 89)
        Me.TxtDb.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TxtDb.Name = "TxtDb"
        Me.TxtDb.Size = New System.Drawing.Size(267, 26)
        Me.TxtDb.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Database"
        '
        'TxtServer
        '
        Me.TxtServer.Location = New System.Drawing.Point(14, 33)
        Me.TxtServer.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(267, 26)
        Me.TxtServer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 18)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Server"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(286, 206)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 48)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "FYI: Click Test Connection " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "first before having an access" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on Save Settings."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnResFld)
        Me.GroupBox1.Controls.Add(Me.BtnSaveSet)
        Me.GroupBox1.Controls.Add(Me.BtnClearFld)
        Me.GroupBox1.Controls.Add(Me.BtnTestConn)
        Me.GroupBox1.Location = New System.Drawing.Point(289, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(169, 164)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'BtnResFld
        '
        Me.BtnResFld.BackColor = System.Drawing.SystemColors.Control
        Me.BtnResFld.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnResFld.Location = New System.Drawing.Point(17, 17)
        Me.BtnResFld.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnResFld.Name = "BtnResFld"
        Me.BtnResFld.Size = New System.Drawing.Size(108, 28)
        Me.BtnResFld.TabIndex = 48
        Me.BtnResFld.Text = "&Reset Fields"
        Me.BtnResFld.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnResFld.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnResFld.UseVisualStyleBackColor = False
        '
        'BtnSaveSet
        '
        Me.BtnSaveSet.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSaveSet.Enabled = False
        Me.BtnSaveSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSaveSet.Location = New System.Drawing.Point(17, 125)
        Me.BtnSaveSet.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSaveSet.Name = "BtnSaveSet"
        Me.BtnSaveSet.Size = New System.Drawing.Size(115, 28)
        Me.BtnSaveSet.TabIndex = 50
        Me.BtnSaveSet.Text = "&Save Settings"
        Me.BtnSaveSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSaveSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSaveSet.UseVisualStyleBackColor = False
        '
        'BtnClearFld
        '
        Me.BtnClearFld.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClearFld.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClearFld.Location = New System.Drawing.Point(17, 53)
        Me.BtnClearFld.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClearFld.Name = "BtnClearFld"
        Me.BtnClearFld.Size = New System.Drawing.Size(123, 28)
        Me.BtnClearFld.TabIndex = 49
        Me.BtnClearFld.Text = "Clear &All Fields"
        Me.BtnClearFld.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClearFld.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClearFld.UseVisualStyleBackColor = False
        '
        'BtnTestConn
        '
        Me.BtnTestConn.BackColor = System.Drawing.SystemColors.Control
        Me.BtnTestConn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTestConn.Location = New System.Drawing.Point(17, 89)
        Me.BtnTestConn.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTestConn.Name = "BtnTestConn"
        Me.BtnTestConn.Size = New System.Drawing.Size(140, 28)
        Me.BtnTestConn.TabIndex = 47
        Me.BtnTestConn.Text = "&Test Connection"
        Me.BtnTestConn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTestConn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnTestConn.UseVisualStyleBackColor = False
        '
        'FrmDbConn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 292)
        Me.Controls.Add(Me.TxtPort)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.TxtUn)
        Me.Controls.Add(Me.TxtDb)
        Me.Controls.Add(Me.TxtServer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnDefault)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDbConn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Connector"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnDefault As System.Windows.Forms.Button
    Friend WithEvents TxtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtUn As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnResFld As System.Windows.Forms.Button
    Friend WithEvents BtnSaveSet As System.Windows.Forms.Button
    Friend WithEvents BtnClearFld As System.Windows.Forms.Button
    Friend WithEvents BtnTestConn As System.Windows.Forms.Button
End Class
