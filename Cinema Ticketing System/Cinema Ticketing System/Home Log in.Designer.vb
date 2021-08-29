<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home_Log_in
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home_Log_in))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.CmnuPanelTop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCinemaName = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.picMinimize = New System.Windows.Forms.PictureBox()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.lblVerification = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtstaffID = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblstaffID = New System.Windows.Forms.Label()
        Me.picBigPicture = New System.Windows.Forms.PictureBox()
        Me.lblBigName = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnsignIn = New System.Windows.Forms.Button()
        Me.btnsendCode = New System.Windows.Forms.Button()
        Me.mskCode = New System.Windows.Forms.MaskedTextBox()
        Me.lblUseless = New System.Windows.Forms.Label()
        Me.lklblForgot = New System.Windows.Forms.Label()
        Me.tmWait = New System.Windows.Forms.Timer(Me.components)
        Me.DB_CinemaDataSet = New Cinema_Ticketing_System.DB_CinemaDataSet()
        Me.StaffTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.StaffTableAdapter()
        Me.pnlTop.SuspendLayout()
        Me.CmnuPanelTop.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.Black
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTop.ContextMenuStrip = Me.CmnuPanelTop
        Me.pnlTop.Controls.Add(Me.lblCinemaName)
        Me.pnlTop.Controls.Add(Me.picIcon)
        Me.pnlTop.Controls.Add(Me.picMinimize)
        Me.pnlTop.Controls.Add(Me.picClose)
        Me.pnlTop.Location = New System.Drawing.Point(-1, -1)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(508, 48)
        Me.pnlTop.TabIndex = 1
        '
        'CmnuPanelTop
        '
        Me.CmnuPanelTop.BackColor = System.Drawing.SystemColors.Control
        Me.CmnuPanelTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMove, Me.MnuMinimize, Me.MnuClose})
        Me.CmnuPanelTop.Name = "CmnuPanelTop"
        Me.CmnuPanelTop.Size = New System.Drawing.Size(146, 70)
        '
        'MnuMove
        '
        Me.MnuMove.BackColor = System.Drawing.SystemColors.Control
        Me.MnuMove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MnuMove.Name = "MnuMove"
        Me.MnuMove.Size = New System.Drawing.Size(145, 22)
        Me.MnuMove.Text = "Move"
        '
        'MnuMinimize
        '
        Me.MnuMinimize.BackColor = System.Drawing.SystemColors.Control
        Me.MnuMinimize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MnuMinimize.Name = "MnuMinimize"
        Me.MnuMinimize.Size = New System.Drawing.Size(145, 22)
        Me.MnuMinimize.Text = "Minimize"
        '
        'MnuClose
        '
        Me.MnuClose.BackColor = System.Drawing.SystemColors.Control
        Me.MnuClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MnuClose.Name = "MnuClose"
        Me.MnuClose.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.MnuClose.Size = New System.Drawing.Size(145, 22)
        Me.MnuClose.Text = "Close"
        '
        'lblCinemaName
        '
        Me.lblCinemaName.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCinemaName.ForeColor = System.Drawing.Color.Yellow
        Me.lblCinemaName.Location = New System.Drawing.Point(56, 3)
        Me.lblCinemaName.Name = "lblCinemaName"
        Me.lblCinemaName.Size = New System.Drawing.Size(148, 37)
        Me.lblCinemaName.TabIndex = 5
        Me.lblCinemaName.Text = "SS Cinema"
        Me.lblCinemaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picIcon
        '
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.Location = New System.Drawing.Point(12, 3)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(38, 38)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 4
        Me.picIcon.TabStop = False
        '
        'picMinimize
        '
        Me.picMinimize.BackColor = System.Drawing.Color.Transparent
        Me.picMinimize.Image = CType(resources.GetObject("picMinimize.Image"), System.Drawing.Image)
        Me.picMinimize.Location = New System.Drawing.Point(397, 3)
        Me.picMinimize.Name = "picMinimize"
        Me.picMinimize.Size = New System.Drawing.Size(40, 38)
        Me.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMinimize.TabIndex = 1
        Me.picMinimize.TabStop = False
        '
        'picClose
        '
        Me.picClose.BackColor = System.Drawing.Color.Transparent
        Me.picClose.Image = CType(resources.GetObject("picClose.Image"), System.Drawing.Image)
        Me.picClose.Location = New System.Drawing.Point(452, 3)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(40, 38)
        Me.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClose.TabIndex = 1
        Me.picClose.TabStop = False
        '
        'lblVerification
        '
        Me.lblVerification.BackColor = System.Drawing.Color.Transparent
        Me.lblVerification.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerification.ForeColor = System.Drawing.Color.White
        Me.lblVerification.Location = New System.Drawing.Point(39, 303)
        Me.lblVerification.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVerification.Name = "lblVerification"
        Me.lblVerification.Size = New System.Drawing.Size(107, 27)
        Me.lblVerification.TabIndex = 41
        Me.lblVerification.Text = "Verify Code :"
        Me.lblVerification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(171, 256)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(241, 26)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtstaffID
        '
        Me.txtstaffID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstaffID.Location = New System.Drawing.Point(171, 211)
        Me.txtstaffID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtstaffID.Name = "txtstaffID"
        Me.txtstaffID.Size = New System.Drawing.Size(241, 26)
        Me.txtstaffID.TabIndex = 0
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.White
        Me.lblPassword.Location = New System.Drawing.Point(39, 256)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(107, 27)
        Me.lblPassword.TabIndex = 38
        Me.lblPassword.Text = "Password :"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblstaffID
        '
        Me.lblstaffID.BackColor = System.Drawing.Color.Transparent
        Me.lblstaffID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstaffID.ForeColor = System.Drawing.Color.White
        Me.lblstaffID.Location = New System.Drawing.Point(39, 211)
        Me.lblstaffID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblstaffID.Name = "lblstaffID"
        Me.lblstaffID.Size = New System.Drawing.Size(107, 27)
        Me.lblstaffID.TabIndex = 37
        Me.lblstaffID.Text = "Staff ID :"
        Me.lblstaffID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picBigPicture
        '
        Me.picBigPicture.BackColor = System.Drawing.Color.Transparent
        Me.picBigPicture.Image = CType(resources.GetObject("picBigPicture.Image"), System.Drawing.Image)
        Me.picBigPicture.Location = New System.Drawing.Point(33, 62)
        Me.picBigPicture.Name = "picBigPicture"
        Me.picBigPicture.Size = New System.Drawing.Size(146, 133)
        Me.picBigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBigPicture.TabIndex = 4
        Me.picBigPicture.TabStop = False
        '
        'lblBigName
        '
        Me.lblBigName.BackColor = System.Drawing.Color.Transparent
        Me.lblBigName.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBigName.ForeColor = System.Drawing.Color.Yellow
        Me.lblBigName.Location = New System.Drawing.Point(185, 112)
        Me.lblBigName.Name = "lblBigName"
        Me.lblBigName.Size = New System.Drawing.Size(273, 37)
        Me.lblBigName.TabIndex = 5
        Me.lblBigName.Text = "Shooting Star Cinema"
        Me.lblBigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Yellow
        Me.btnExit.Location = New System.Drawing.Point(317, 360)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(120, 30)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnsignIn
        '
        Me.btnsignIn.BackgroundImage = CType(resources.GetObject("btnsignIn.BackgroundImage"), System.Drawing.Image)
        Me.btnsignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnsignIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsignIn.ForeColor = System.Drawing.Color.Yellow
        Me.btnsignIn.Location = New System.Drawing.Point(59, 360)
        Me.btnsignIn.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsignIn.Name = "btnsignIn"
        Me.btnsignIn.Size = New System.Drawing.Size(120, 30)
        Me.btnsignIn.TabIndex = 4
        Me.btnsignIn.Text = "Sign In"
        Me.btnsignIn.UseVisualStyleBackColor = True
        '
        'btnsendCode
        '
        Me.btnsendCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnsendCode.BackgroundImage = CType(resources.GetObject("btnsendCode.BackgroundImage"), System.Drawing.Image)
        Me.btnsendCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnsendCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnsendCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsendCode.ForeColor = System.Drawing.Color.Yellow
        Me.btnsendCode.Location = New System.Drawing.Point(317, 301)
        Me.btnsendCode.Margin = New System.Windows.Forms.Padding(2)
        Me.btnsendCode.Name = "btnsendCode"
        Me.btnsendCode.Size = New System.Drawing.Size(120, 30)
        Me.btnsendCode.TabIndex = 3
        Me.btnsendCode.Text = "Send Code"
        Me.btnsendCode.UseVisualStyleBackColor = False
        '
        'mskCode
        '
        Me.mskCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskCode.Location = New System.Drawing.Point(171, 303)
        Me.mskCode.Mask = "9999"
        Me.mskCode.Name = "mskCode"
        Me.mskCode.Size = New System.Drawing.Size(129, 26)
        Me.mskCode.TabIndex = 2
        '
        'lblUseless
        '
        Me.lblUseless.BackColor = System.Drawing.Color.Transparent
        Me.lblUseless.ForeColor = System.Drawing.Color.White
        Me.lblUseless.Location = New System.Drawing.Point(51, 451)
        Me.lblUseless.Name = "lblUseless"
        Me.lblUseless.Size = New System.Drawing.Size(407, 23)
        Me.lblUseless.TabIndex = 47
        Me.lblUseless.Text = "---------------------------------------------------------------------------------" &
    "-----------------------------------------------------"
        Me.lblUseless.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lklblForgot
        '
        Me.lklblForgot.BackColor = System.Drawing.Color.Transparent
        Me.lklblForgot.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline)
        Me.lklblForgot.ForeColor = System.Drawing.Color.White
        Me.lklblForgot.Location = New System.Drawing.Point(177, 404)
        Me.lklblForgot.Name = "lklblForgot"
        Me.lklblForgot.Size = New System.Drawing.Size(156, 36)
        Me.lklblForgot.TabIndex = 6
        Me.lklblForgot.Text = "Forgot Password?"
        Me.lklblForgot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmWait
        '
        Me.tmWait.Interval = 500
        '
        'DB_CinemaDataSet
        '
        Me.DB_CinemaDataSet.DataSetName = "DB_CinemaDataSet"
        Me.DB_CinemaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StaffTableAdapter
        '
        Me.StaffTableAdapter.ClearBeforeFill = True
        '
        'Home_Log_in
        '
        Me.AcceptButton = Me.btnsignIn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(504, 493)
        Me.Controls.Add(Me.lblUseless)
        Me.Controls.Add(Me.lklblForgot)
        Me.Controls.Add(Me.mskCode)
        Me.Controls.Add(Me.btnsendCode)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnsignIn)
        Me.Controls.Add(Me.lblBigName)
        Me.Controls.Add(Me.picBigPicture)
        Me.Controls.Add(Me.lblVerification)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtstaffID)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblstaffID)
        Me.Controls.Add(Me.pnlTop)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Home_Log_in"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home_Log_in"
        Me.pnlTop.ResumeLayout(False)
        Me.CmnuPanelTop.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblVerification As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtstaffID As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblstaffID As Label
    Friend WithEvents CmnuPanelTop As ContextMenuStrip
    Friend WithEvents MnuMove As ToolStripMenuItem
    Friend WithEvents MnuMinimize As ToolStripMenuItem
    Friend WithEvents MnuClose As ToolStripMenuItem
    Friend WithEvents lblCinemaName As Label
    Friend WithEvents picBigPicture As PictureBox
    Friend WithEvents lblBigName As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnsignIn As Button
    Friend WithEvents btnsendCode As Button
    Friend WithEvents mskCode As MaskedTextBox
    Friend WithEvents lblUseless As Label
    Friend WithEvents lklblForgot As Label
    Friend WithEvents tmWait As Timer
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents picMinimize As PictureBox
    Friend WithEvents picClose As PictureBox
    Friend WithEvents DB_CinemaDataSet As DB_CinemaDataSet
    Friend WithEvents StaffTableAdapter As DB_CinemaDataSetTableAdapters.StaffTableAdapter
End Class
