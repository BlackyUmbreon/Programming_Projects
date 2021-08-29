<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reserve_Step_3
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reserve_Step_3))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.CmnuPanelTop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCinemaName = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.picMinimize = New System.Windows.Forms.PictureBox()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnlCash = New System.Windows.Forms.Panel()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.lblErrorText = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.radCard = New System.Windows.Forms.RadioButton()
        Me.radCash = New System.Windows.Forms.RadioButton()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.mskCVV = New System.Windows.Forms.MaskedTextBox()
        Me.mskDate = New System.Windows.Forms.MaskedTextBox()
        Me.mskCard = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.pnlStep4 = New System.Windows.Forms.Panel()
        Me.picStep4 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlStep2 = New System.Windows.Forms.Panel()
        Me.picStep2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlStep3 = New System.Windows.Forms.Panel()
        Me.picStep3 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlStep1 = New System.Windows.Forms.Panel()
        Me.picStep1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.CmnuPanelTop.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlCash.SuspendLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCard.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep4.SuspendLayout()
        CType(Me.picStep4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep2.SuspendLayout()
        CType(Me.picStep2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep3.SuspendLayout()
        CType(Me.picStep3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStep1.SuspendLayout()
        CType(Me.picStep1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlTop.Size = New System.Drawing.Size(1362, 48)
        Me.pnlTop.TabIndex = 2
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
        Me.lblCinemaName.Location = New System.Drawing.Point(68, 3)
        Me.lblCinemaName.Name = "lblCinemaName"
        Me.lblCinemaName.Size = New System.Drawing.Size(148, 37)
        Me.lblCinemaName.TabIndex = 3
        Me.lblCinemaName.Text = "SS Cinema"
        Me.lblCinemaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picIcon
        '
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.Location = New System.Drawing.Point(24, 3)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(38, 38)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 2
        Me.picIcon.TabStop = False
        '
        'picMinimize
        '
        Me.picMinimize.BackColor = System.Drawing.Color.Transparent
        Me.picMinimize.Image = CType(resources.GetObject("picMinimize.Image"), System.Drawing.Image)
        Me.picMinimize.Location = New System.Drawing.Point(1247, 5)
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
        Me.picClose.Location = New System.Drawing.Point(1305, 5)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(40, 38)
        Me.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClose.TabIndex = 1
        Me.picClose.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.lblPrice)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.Label20)
        Me.Panel6.Controls.Add(Me.pnlCash)
        Me.Panel6.Controls.Add(Me.radCard)
        Me.Panel6.Controls.Add(Me.radCash)
        Me.Panel6.Controls.Add(Me.pnlCard)
        Me.Panel6.Location = New System.Drawing.Point(102, 334)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1161, 343)
        Me.Panel6.TabIndex = 12
        '
        'lblPrice
        '
        Me.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(880, 10)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(253, 48)
        Me.lblPrice.TabIndex = 0
        Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(715, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(159, 48)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Price"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(41, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(294, 36)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Select Payment Type"
        '
        'pnlCash
        '
        Me.pnlCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlCash.Controls.Add(Me.txtAmount)
        Me.pnlCash.Controls.Add(Me.picError)
        Me.pnlCash.Controls.Add(Me.btnCalculate)
        Me.pnlCash.Controls.Add(Me.lblErrorText)
        Me.pnlCash.Controls.Add(Me.Label19)
        Me.pnlCash.Controls.Add(Me.Label16)
        Me.pnlCash.Controls.Add(Me.Label17)
        Me.pnlCash.Controls.Add(Me.lblChange)
        Me.pnlCash.ForeColor = System.Drawing.Color.White
        Me.pnlCash.Location = New System.Drawing.Point(31, 112)
        Me.pnlCash.Name = "pnlCash"
        Me.pnlCash.Size = New System.Drawing.Size(442, 204)
        Me.pnlCash.TabIndex = 63
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(193, 79)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(228, 26)
        Me.txtAmount.TabIndex = 63
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.Transparent
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(178, 158)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(36, 34)
        Me.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picError.TabIndex = 62
        Me.picError.TabStop = False
        Me.picError.Visible = False
        '
        'btnCalculate
        '
        Me.btnCalculate.BackgroundImage = CType(resources.GetObject("btnCalculate.BackgroundImage"), System.Drawing.Image)
        Me.btnCalculate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCalculate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculate.ForeColor = System.Drawing.Color.Yellow
        Me.btnCalculate.Location = New System.Drawing.Point(16, 161)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(141, 33)
        Me.btnCalculate.TabIndex = 6
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'lblErrorText
        '
        Me.lblErrorText.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblErrorText.ForeColor = System.Drawing.Color.Red
        Me.lblErrorText.Location = New System.Drawing.Point(220, 161)
        Me.lblErrorText.Name = "lblErrorText"
        Me.lblErrorText.Size = New System.Drawing.Size(201, 31)
        Me.lblErrorText.TabIndex = 61
        Me.lblErrorText.Text = "Caution , Payment Error"
        Me.lblErrorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblErrorText.Visible = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(11, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(223, 55)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Cash"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(159, 23)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Amount Paid :"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(159, 23)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Change Due :"
        '
        'lblChange
        '
        Me.lblChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblChange.Location = New System.Drawing.Point(193, 118)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(228, 23)
        Me.lblChange.TabIndex = 0
        Me.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radCard
        '
        Me.radCard.AutoSize = True
        Me.radCard.BackColor = System.Drawing.Color.Transparent
        Me.radCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.radCard.Location = New System.Drawing.Point(158, 62)
        Me.radCard.Name = "radCard"
        Me.radCard.Size = New System.Drawing.Size(157, 24)
        Me.radCard.TabIndex = 2
        Me.radCard.Text = "Debit / Credit Card"
        Me.radCard.UseVisualStyleBackColor = False
        '
        'radCash
        '
        Me.radCash.AutoSize = True
        Me.radCash.BackColor = System.Drawing.Color.Transparent
        Me.radCash.Checked = True
        Me.radCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.radCash.Location = New System.Drawing.Point(42, 62)
        Me.radCash.Name = "radCash"
        Me.radCash.Size = New System.Drawing.Size(64, 24)
        Me.radCash.TabIndex = 2
        Me.radCash.TabStop = True
        Me.radCash.Text = "Cash"
        Me.radCash.UseVisualStyleBackColor = False
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlCard.Controls.Add(Me.mskCVV)
        Me.pnlCard.Controls.Add(Me.mskDate)
        Me.pnlCard.Controls.Add(Me.mskCard)
        Me.pnlCard.Controls.Add(Me.Label9)
        Me.pnlCard.Controls.Add(Me.Label10)
        Me.pnlCard.Controls.Add(Me.Label11)
        Me.pnlCard.Controls.Add(Me.Label12)
        Me.pnlCard.Enabled = False
        Me.pnlCard.ForeColor = System.Drawing.Color.Silver
        Me.pnlCard.Location = New System.Drawing.Point(667, 112)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(457, 204)
        Me.pnlCard.TabIndex = 64
        '
        'mskCVV
        '
        Me.mskCVV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.mskCVV.Location = New System.Drawing.Point(201, 158)
        Me.mskCVV.Mask = "999"
        Me.mskCVV.Name = "mskCVV"
        Me.mskCVV.Size = New System.Drawing.Size(235, 26)
        Me.mskCVV.TabIndex = 63
        Me.mskCVV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mskDate
        '
        Me.mskDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.mskDate.Location = New System.Drawing.Point(201, 117)
        Me.mskDate.Mask = "99/99"
        Me.mskDate.Name = "mskDate"
        Me.mskDate.Size = New System.Drawing.Size(235, 26)
        Me.mskDate.TabIndex = 63
        Me.mskDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mskCard
        '
        Me.mskCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.mskCard.Location = New System.Drawing.Point(201, 79)
        Me.mskCard.Mask = "9999 9999 9999 9999"
        Me.mskCard.Name = "mskCard"
        Me.mskCard.Size = New System.Drawing.Size(235, 26)
        Me.mskCard.TabIndex = 63
        Me.mskCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(223, 50)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Debit / Credit Card"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 23)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Card Number"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(159, 23)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Expiry Date (MM/YY)"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 161)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(159, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "CVV"
        '
        'btnNext
        '
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ForeColor = System.Drawing.Color.Yellow
        Me.btnNext.Location = New System.Drawing.Point(1048, 717)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(215, 45)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(959, 161)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(64, 60)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 17
        Me.PictureBox9.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(648, 161)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(64, 60)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 18
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(339, 161)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(64, 60)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 19
        Me.PictureBox7.TabStop = False
        '
        'pnlStep4
        '
        Me.pnlStep4.AutoScroll = True
        Me.pnlStep4.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlStep4.Controls.Add(Me.picStep4)
        Me.pnlStep4.Controls.Add(Me.Label5)
        Me.pnlStep4.Controls.Add(Me.Label4)
        Me.pnlStep4.Location = New System.Drawing.Point(1043, 69)
        Me.pnlStep4.Name = "pnlStep4"
        Me.pnlStep4.Size = New System.Drawing.Size(201, 226)
        Me.pnlStep4.TabIndex = 13
        '
        'picStep4
        '
        Me.picStep4.BackColor = System.Drawing.Color.Transparent
        Me.picStep4.Image = CType(resources.GetObject("picStep4.Image"), System.Drawing.Image)
        Me.picStep4.Location = New System.Drawing.Point(42, 62)
        Me.picStep4.Name = "picStep4"
        Me.picStep4.Size = New System.Drawing.Size(115, 104)
        Me.picStep4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStep4.TabIndex = 3
        Me.picStep4.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gold
        Me.Label5.Location = New System.Drawing.Point(20, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(164, 38)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Receipt and QR code"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(42, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 38)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Step 4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlStep2
        '
        Me.pnlStep2.AutoScroll = True
        Me.pnlStep2.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlStep2.Controls.Add(Me.picStep2)
        Me.pnlStep2.Controls.Add(Me.Label7)
        Me.pnlStep2.Controls.Add(Me.Label2)
        Me.pnlStep2.Location = New System.Drawing.Point(419, 69)
        Me.pnlStep2.Name = "pnlStep2"
        Me.pnlStep2.Size = New System.Drawing.Size(201, 226)
        Me.pnlStep2.TabIndex = 14
        '
        'picStep2
        '
        Me.picStep2.BackColor = System.Drawing.Color.Transparent
        Me.picStep2.Image = CType(resources.GetObject("picStep2.Image"), System.Drawing.Image)
        Me.picStep2.Location = New System.Drawing.Point(42, 62)
        Me.picStep2.Name = "picStep2"
        Me.picStep2.Size = New System.Drawing.Size(115, 104)
        Me.picStep2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStep2.TabIndex = 3
        Me.picStep2.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label7.Location = New System.Drawing.Point(19, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(164, 38)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Food and Baverage"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label2.Location = New System.Drawing.Point(42, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 38)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Step 2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlStep3
        '
        Me.pnlStep3.AutoScroll = True
        Me.pnlStep3.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlStep3.Controls.Add(Me.picStep3)
        Me.pnlStep3.Controls.Add(Me.Label6)
        Me.pnlStep3.Controls.Add(Me.Label3)
        Me.pnlStep3.Location = New System.Drawing.Point(738, 69)
        Me.pnlStep3.Name = "pnlStep3"
        Me.pnlStep3.Size = New System.Drawing.Size(201, 226)
        Me.pnlStep3.TabIndex = 15
        '
        'picStep3
        '
        Me.picStep3.BackColor = System.Drawing.Color.Transparent
        Me.picStep3.Image = CType(resources.GetObject("picStep3.Image"), System.Drawing.Image)
        Me.picStep3.Location = New System.Drawing.Point(40, 62)
        Me.picStep3.Name = "picStep3"
        Me.picStep3.Size = New System.Drawing.Size(115, 104)
        Me.picStep3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStep3.TabIndex = 3
        Me.picStep3.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(24, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 38)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Payment"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(40, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 38)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Step 3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlStep1
        '
        Me.pnlStep1.AutoScroll = True
        Me.pnlStep1.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlStep1.Controls.Add(Me.picStep1)
        Me.pnlStep1.Controls.Add(Me.Label8)
        Me.pnlStep1.Controls.Add(Me.Label1)
        Me.pnlStep1.Location = New System.Drawing.Point(121, 69)
        Me.pnlStep1.Name = "pnlStep1"
        Me.pnlStep1.Size = New System.Drawing.Size(201, 226)
        Me.pnlStep1.TabIndex = 16
        '
        'picStep1
        '
        Me.picStep1.BackColor = System.Drawing.Color.Transparent
        Me.picStep1.Image = CType(resources.GetObject("picStep1.Image"), System.Drawing.Image)
        Me.picStep1.Location = New System.Drawing.Point(43, 62)
        Me.picStep1.Name = "picStep1"
        Me.picStep1.Size = New System.Drawing.Size(115, 104)
        Me.picStep1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStep1.TabIndex = 3
        Me.picStep1.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label8.Location = New System.Drawing.Point(21, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(164, 38)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Booking Seats"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label1.Location = New System.Drawing.Point(43, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Yellow
        Me.btnCancel.Location = New System.Drawing.Point(102, 717)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(215, 45)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Reserve_Step_3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1359, 820)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.pnlStep4)
        Me.Controls.Add(Me.pnlStep2)
        Me.Controls.Add(Me.pnlStep3)
        Me.Controls.Add(Me.pnlStep1)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reserve_Step_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reserve_Step_3"
        Me.pnlTop.ResumeLayout(False)
        Me.CmnuPanelTop.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlCash.ResumeLayout(False)
        Me.pnlCash.PerformLayout()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep4.ResumeLayout(False)
        CType(Me.picStep4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep2.ResumeLayout(False)
        CType(Me.picStep2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep3.ResumeLayout(False)
        CType(Me.picStep3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStep1.ResumeLayout(False)
        CType(Me.picStep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblCinemaName As Label
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents picMinimize As PictureBox
    Friend WithEvents picClose As PictureBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents lblPrice As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents pnlStep4 As Panel
    Friend WithEvents picStep4 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlStep2 As Panel
    Friend WithEvents picStep2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlStep3 As Panel
    Friend WithEvents picStep3 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlStep1 As Panel
    Friend WithEvents picStep1 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents pnlCash As Panel
    Friend WithEvents picError As PictureBox
    Friend WithEvents lblErrorText As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents radCard As RadioButton
    Friend WithEvents radCash As RadioButton
    Friend WithEvents pnlCard As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents mskCVV As MaskedTextBox
    Friend WithEvents mskDate As MaskedTextBox
    Friend WithEvents mskCard As MaskedTextBox
    Friend WithEvents CmnuPanelTop As ContextMenuStrip
    Friend WithEvents MnuMove As ToolStripMenuItem
    Friend WithEvents MnuMinimize As ToolStripMenuItem
    Friend WithEvents MnuClose As ToolStripMenuItem
    Friend WithEvents btnCalculate As Button
    Friend WithEvents txtAmount As TextBox
End Class
