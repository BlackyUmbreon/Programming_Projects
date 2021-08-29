<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Forgot_Password
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Forgot_Password))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.CmnuPanelTop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCinemaName = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.picMinimize = New System.Windows.Forms.PictureBox()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.lblBigName = New System.Windows.Forms.Label()
        Me.picBigPicture = New System.Windows.Forms.PictureBox()
        Me.msktxtCode = New System.Windows.Forms.MaskedTextBox()
        Me.btnCode = New System.Windows.Forms.Button()
        Me.lblVerification = New System.Windows.Forms.Label()
        Me.txtstaffID = New System.Windows.Forms.TextBox()
        Me.lblstaffID = New System.Windows.Forms.Label()
        Me.lblResetPassword = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblResetError = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.CmnuPanelTop.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlTop.TabIndex = 2
        '
        'CmnuPanelTop
        '
        Me.CmnuPanelTop.BackColor = System.Drawing.SystemColors.Control
        Me.CmnuPanelTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMove, Me.MnuMinimize, Me.MnuBack})
        Me.CmnuPanelTop.Name = "CmnuPanelTop"
        Me.CmnuPanelTop.Size = New System.Drawing.Size(124, 70)
        '
        'MnuMove
        '
        Me.MnuMove.BackColor = System.Drawing.SystemColors.Control
        Me.MnuMove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MnuMove.Name = "MnuMove"
        Me.MnuMove.Size = New System.Drawing.Size(123, 22)
        Me.MnuMove.Text = "Move"
        '
        'MnuMinimize
        '
        Me.MnuMinimize.BackColor = System.Drawing.SystemColors.Control
        Me.MnuMinimize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MnuMinimize.Name = "MnuMinimize"
        Me.MnuMinimize.Size = New System.Drawing.Size(123, 22)
        Me.MnuMinimize.Text = "Minimize"
        '
        'MnuBack
        '
        Me.MnuBack.BackColor = System.Drawing.SystemColors.Control
        Me.MnuBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MnuBack.Name = "MnuBack"
        Me.MnuBack.Size = New System.Drawing.Size(123, 22)
        Me.MnuBack.Text = "Back"
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
        'lblBigName
        '
        Me.lblBigName.BackColor = System.Drawing.Color.Transparent
        Me.lblBigName.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBigName.ForeColor = System.Drawing.Color.Yellow
        Me.lblBigName.Location = New System.Drawing.Point(190, 103)
        Me.lblBigName.Name = "lblBigName"
        Me.lblBigName.Size = New System.Drawing.Size(273, 37)
        Me.lblBigName.TabIndex = 7
        Me.lblBigName.Text = "Shooting Star Cinema"
        Me.lblBigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picBigPicture
        '
        Me.picBigPicture.BackColor = System.Drawing.Color.Transparent
        Me.picBigPicture.Image = CType(resources.GetObject("picBigPicture.Image"), System.Drawing.Image)
        Me.picBigPicture.Location = New System.Drawing.Point(38, 53)
        Me.picBigPicture.Name = "picBigPicture"
        Me.picBigPicture.Size = New System.Drawing.Size(146, 133)
        Me.picBigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBigPicture.TabIndex = 6
        Me.picBigPicture.TabStop = False
        '
        'msktxtCode
        '
        Me.msktxtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msktxtCode.Location = New System.Drawing.Point(180, 312)
        Me.msktxtCode.Mask = "9999"
        Me.msktxtCode.Name = "msktxtCode"
        Me.msktxtCode.Size = New System.Drawing.Size(129, 26)
        Me.msktxtCode.TabIndex = 1
        '
        'btnCode
        '
        Me.btnCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCode.BackgroundImage = CType(resources.GetObject("btnCode.BackgroundImage"), System.Drawing.Image)
        Me.btnCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCode.ForeColor = System.Drawing.Color.Yellow
        Me.btnCode.Location = New System.Drawing.Point(327, 310)
        Me.btnCode.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCode.Name = "btnCode"
        Me.btnCode.Size = New System.Drawing.Size(120, 30)
        Me.btnCode.TabIndex = 2
        Me.btnCode.Text = "Send Code"
        Me.btnCode.UseVisualStyleBackColor = False
        '
        'lblVerification
        '
        Me.lblVerification.BackColor = System.Drawing.Color.Transparent
        Me.lblVerification.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerification.ForeColor = System.Drawing.Color.White
        Me.lblVerification.Location = New System.Drawing.Point(48, 312)
        Me.lblVerification.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVerification.Name = "lblVerification"
        Me.lblVerification.Size = New System.Drawing.Size(107, 27)
        Me.lblVerification.TabIndex = 49
        Me.lblVerification.Text = "Verify Code :"
        Me.lblVerification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtstaffID
        '
        Me.txtstaffID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstaffID.Location = New System.Drawing.Point(180, 241)
        Me.txtstaffID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtstaffID.Name = "txtstaffID"
        Me.txtstaffID.Size = New System.Drawing.Size(241, 26)
        Me.txtstaffID.TabIndex = 0
        '
        'lblstaffID
        '
        Me.lblstaffID.BackColor = System.Drawing.Color.Transparent
        Me.lblstaffID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstaffID.ForeColor = System.Drawing.Color.White
        Me.lblstaffID.Location = New System.Drawing.Point(48, 241)
        Me.lblstaffID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblstaffID.Name = "lblstaffID"
        Me.lblstaffID.Size = New System.Drawing.Size(107, 27)
        Me.lblstaffID.TabIndex = 47
        Me.lblstaffID.Text = "Staff ID :"
        Me.lblstaffID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResetPassword
        '
        Me.lblResetPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblResetPassword.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResetPassword.ForeColor = System.Drawing.Color.White
        Me.lblResetPassword.Location = New System.Drawing.Point(52, 189)
        Me.lblResetPassword.Name = "lblResetPassword"
        Me.lblResetPassword.Size = New System.Drawing.Size(257, 37)
        Me.lblResetPassword.TabIndex = 52
        Me.lblResetPassword.Text = "Retrieve Password :"
        Me.lblResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Yellow
        Me.btnCancel.Location = New System.Drawing.Point(327, 407)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnConfirm
        '
        Me.btnConfirm.BackgroundImage = CType(resources.GetObject("btnConfirm.BackgroundImage"), System.Drawing.Image)
        Me.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.ForeColor = System.Drawing.Color.Yellow
        Me.btnConfirm.Location = New System.Drawing.Point(69, 407)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(120, 30)
        Me.btnConfirm.TabIndex = 3
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lblResetError
        '
        Me.lblResetError.BackColor = System.Drawing.Color.Transparent
        Me.lblResetError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResetError.ForeColor = System.Drawing.Color.White
        Me.lblResetError.Location = New System.Drawing.Point(53, 356)
        Me.lblResetError.Name = "lblResetError"
        Me.lblResetError.Size = New System.Drawing.Size(394, 26)
        Me.lblResetError.TabIndex = 53
        Me.lblResetError.Text = "The Verification Code have been sent to email."
        Me.lblResetError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Forgot_Password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(505, 493)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.lblResetError)
        Me.Controls.Add(Me.lblResetPassword)
        Me.Controls.Add(Me.msktxtCode)
        Me.Controls.Add(Me.btnCode)
        Me.Controls.Add(Me.lblVerification)
        Me.Controls.Add(Me.txtstaffID)
        Me.Controls.Add(Me.lblstaffID)
        Me.Controls.Add(Me.lblBigName)
        Me.Controls.Add(Me.picBigPicture)
        Me.Controls.Add(Me.pnlTop)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Forgot_Password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forgot_Password"
        Me.pnlTop.ResumeLayout(False)
        Me.CmnuPanelTop.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblCinemaName As Label
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents picMinimize As PictureBox
    Friend WithEvents picClose As PictureBox
    Friend WithEvents lblBigName As Label
    Friend WithEvents picBigPicture As PictureBox
    Friend WithEvents msktxtCode As MaskedTextBox
    Friend WithEvents btnCode As Button
    Friend WithEvents lblVerification As Label
    Friend WithEvents txtstaffID As TextBox
    Friend WithEvents lblstaffID As Label
    Friend WithEvents lblResetPassword As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents lblResetError As Label
    Friend WithEvents CmnuPanelTop As ContextMenuStrip
    Friend WithEvents MnuMove As ToolStripMenuItem
    Friend WithEvents MnuMinimize As ToolStripMenuItem
    Friend WithEvents MnuBack As ToolStripMenuItem
End Class
