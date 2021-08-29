<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sales_Report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sales_Report))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.CmnuPanelTop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCinemaName = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.picMinimize = New System.Windows.Forms.PictureBox()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radYearly = New System.Windows.Forms.RadioButton()
        Me.radMonthly = New System.Windows.Forms.RadioButton()
        Me.radWeekly = New System.Windows.Forms.RadioButton()
        Me.radDaily = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gpDaily = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDailyYear = New System.Windows.Forms.ComboBox()
        Me.cboDailyMonth = New System.Windows.Forms.ComboBox()
        Me.cboDailyDay = New System.Windows.Forms.ComboBox()
        Me.gpWeekly = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboWeeklyMonth = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboWeeklyYear = New System.Windows.Forms.ComboBox()
        Me.cboWeeklyDay = New System.Windows.Forms.ComboBox()
        Me.gpMonthly = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboMonthlyYear = New System.Windows.Forms.ComboBox()
        Me.cboMonthlyMonth = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gpYearly = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboYearlyYear = New System.Windows.Forms.ComboBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lstReport = New System.Windows.Forms.ListBox()
        Me.docReport = New System.Drawing.Printing.PrintDocument()
        Me.previewReport = New System.Windows.Forms.PrintPreviewDialog()
        Me.pnlTop.SuspendLayout()
        Me.CmnuPanelTop.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gpDaily.SuspendLayout()
        Me.gpWeekly.SuspendLayout()
        Me.gpMonthly.SuspendLayout()
        Me.gpYearly.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.pnlTop.Size = New System.Drawing.Size(1376, 48)
        Me.pnlTop.TabIndex = 21
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
        Me.picMinimize.Location = New System.Drawing.Point(1260, 4)
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
        Me.picClose.Location = New System.Drawing.Point(1323, 4)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(40, 38)
        Me.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClose.TabIndex = 1
        Me.picClose.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.radYearly)
        Me.Panel1.Controls.Add(Me.radMonthly)
        Me.Panel1.Controls.Add(Me.radWeekly)
        Me.Panel1.Controls.Add(Me.radDaily)
        Me.Panel1.Location = New System.Drawing.Point(62, 110)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1239, 135)
        Me.Panel1.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(30, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(376, 42)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Select One Report Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'radYearly
        '
        Me.radYearly.AutoSize = True
        Me.radYearly.BackColor = System.Drawing.Color.Transparent
        Me.radYearly.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radYearly.ForeColor = System.Drawing.Color.Yellow
        Me.radYearly.Location = New System.Drawing.Point(928, 76)
        Me.radYearly.Name = "radYearly"
        Me.radYearly.Size = New System.Drawing.Size(287, 28)
        Me.radYearly.TabIndex = 0
        Me.radYearly.Text = "Yearly Top 10 movie Report"
        Me.radYearly.UseVisualStyleBackColor = False
        '
        'radMonthly
        '
        Me.radMonthly.AutoSize = True
        Me.radMonthly.BackColor = System.Drawing.Color.Transparent
        Me.radMonthly.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radMonthly.ForeColor = System.Drawing.Color.Yellow
        Me.radMonthly.Location = New System.Drawing.Point(554, 76)
        Me.radMonthly.Name = "radMonthly"
        Me.radMonthly.Size = New System.Drawing.Size(333, 28)
        Me.radMonthly.TabIndex = 0
        Me.radMonthly.Text = "Monthly Movie Box Office Report"
        Me.radMonthly.UseVisualStyleBackColor = False
        '
        'radWeekly
        '
        Me.radWeekly.AutoSize = True
        Me.radWeekly.BackColor = System.Drawing.Color.Transparent
        Me.radWeekly.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radWeekly.ForeColor = System.Drawing.Color.Yellow
        Me.radWeekly.Location = New System.Drawing.Point(292, 76)
        Me.radWeekly.Name = "radWeekly"
        Me.radWeekly.Size = New System.Drawing.Size(221, 28)
        Me.radWeekly.TabIndex = 0
        Me.radWeekly.Text = "Weekly Sales Report"
        Me.radWeekly.UseVisualStyleBackColor = False
        '
        'radDaily
        '
        Me.radDaily.AutoSize = True
        Me.radDaily.BackColor = System.Drawing.Color.Transparent
        Me.radDaily.Checked = True
        Me.radDaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDaily.ForeColor = System.Drawing.Color.Yellow
        Me.radDaily.Location = New System.Drawing.Point(53, 76)
        Me.radDaily.Name = "radDaily"
        Me.radDaily.Size = New System.Drawing.Size(198, 28)
        Me.radDaily.TabIndex = 0
        Me.radDaily.TabStop = True
        Me.radDaily.Text = "Daily Sales Report"
        Me.radDaily.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(62, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(247, 66)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Sales Report"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpDaily
        '
        Me.gpDaily.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.gpDaily.Controls.Add(Me.Label6)
        Me.gpDaily.Controls.Add(Me.Label4)
        Me.gpDaily.Controls.Add(Me.Label3)
        Me.gpDaily.Controls.Add(Me.Label2)
        Me.gpDaily.Controls.Add(Me.cboDailyYear)
        Me.gpDaily.Controls.Add(Me.cboDailyMonth)
        Me.gpDaily.Controls.Add(Me.cboDailyDay)
        Me.gpDaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDaily.ForeColor = System.Drawing.Color.Yellow
        Me.gpDaily.Location = New System.Drawing.Point(62, 279)
        Me.gpDaily.Name = "gpDaily"
        Me.gpDaily.Size = New System.Drawing.Size(552, 137)
        Me.gpDaily.TabIndex = 0
        Me.gpDaily.TabStop = False
        Me.gpDaily.Text = "Daily Sales Report"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(45, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(343, 31)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Select the Date"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(382, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 34)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Year"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(214, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 34)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Month"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(52, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 34)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Day"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDailyYear
        '
        Me.cboDailyYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDailyYear.FormattingEnabled = True
        Me.cboDailyYear.Location = New System.Drawing.Point(379, 90)
        Me.cboDailyYear.Name = "cboDailyYear"
        Me.cboDailyYear.Size = New System.Drawing.Size(121, 28)
        Me.cboDailyYear.TabIndex = 24
        '
        'cboDailyMonth
        '
        Me.cboDailyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDailyMonth.FormattingEnabled = True
        Me.cboDailyMonth.Location = New System.Drawing.Point(211, 90)
        Me.cboDailyMonth.Name = "cboDailyMonth"
        Me.cboDailyMonth.Size = New System.Drawing.Size(121, 28)
        Me.cboDailyMonth.TabIndex = 24
        '
        'cboDailyDay
        '
        Me.cboDailyDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDailyDay.FormattingEnabled = True
        Me.cboDailyDay.Location = New System.Drawing.Point(49, 90)
        Me.cboDailyDay.Name = "cboDailyDay"
        Me.cboDailyDay.Size = New System.Drawing.Size(121, 28)
        Me.cboDailyDay.TabIndex = 24
        '
        'gpWeekly
        '
        Me.gpWeekly.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gpWeekly.Controls.Add(Me.Label10)
        Me.gpWeekly.Controls.Add(Me.Label8)
        Me.gpWeekly.Controls.Add(Me.cboWeeklyMonth)
        Me.gpWeekly.Controls.Add(Me.Label7)
        Me.gpWeekly.Controls.Add(Me.Label9)
        Me.gpWeekly.Controls.Add(Me.cboWeeklyYear)
        Me.gpWeekly.Controls.Add(Me.cboWeeklyDay)
        Me.gpWeekly.Enabled = False
        Me.gpWeekly.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpWeekly.ForeColor = System.Drawing.Color.Yellow
        Me.gpWeekly.Location = New System.Drawing.Point(749, 279)
        Me.gpWeekly.Name = "gpWeekly"
        Me.gpWeekly.Size = New System.Drawing.Size(552, 137)
        Me.gpWeekly.TabIndex = 23
        Me.gpWeekly.TabStop = False
        Me.gpWeekly.Text = "Weekly Sales Report"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(41, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(343, 31)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Select the First Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(395, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 34)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Year"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboWeeklyMonth
        '
        Me.cboWeeklyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWeeklyMonth.FormattingEnabled = True
        Me.cboWeeklyMonth.Location = New System.Drawing.Point(224, 90)
        Me.cboWeeklyMonth.Name = "cboWeeklyMonth"
        Me.cboWeeklyMonth.Size = New System.Drawing.Size(121, 28)
        Me.cboWeeklyMonth.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(227, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 34)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Month"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(48, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 34)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Day"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboWeeklyYear
        '
        Me.cboWeeklyYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWeeklyYear.FormattingEnabled = True
        Me.cboWeeklyYear.Location = New System.Drawing.Point(392, 90)
        Me.cboWeeklyYear.Name = "cboWeeklyYear"
        Me.cboWeeklyYear.Size = New System.Drawing.Size(121, 28)
        Me.cboWeeklyYear.TabIndex = 24
        '
        'cboWeeklyDay
        '
        Me.cboWeeklyDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWeeklyDay.FormattingEnabled = True
        Me.cboWeeklyDay.Location = New System.Drawing.Point(45, 90)
        Me.cboWeeklyDay.Name = "cboWeeklyDay"
        Me.cboWeeklyDay.Size = New System.Drawing.Size(121, 28)
        Me.cboWeeklyDay.TabIndex = 24
        '
        'gpMonthly
        '
        Me.gpMonthly.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gpMonthly.Controls.Add(Me.Label13)
        Me.gpMonthly.Controls.Add(Me.Label12)
        Me.gpMonthly.Controls.Add(Me.cboMonthlyYear)
        Me.gpMonthly.Controls.Add(Me.cboMonthlyMonth)
        Me.gpMonthly.Controls.Add(Me.Label11)
        Me.gpMonthly.Enabled = False
        Me.gpMonthly.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpMonthly.ForeColor = System.Drawing.Color.Yellow
        Me.gpMonthly.Location = New System.Drawing.Point(62, 449)
        Me.gpMonthly.Name = "gpMonthly"
        Me.gpMonthly.Size = New System.Drawing.Size(552, 137)
        Me.gpMonthly.TabIndex = 23
        Me.gpMonthly.TabStop = False
        Me.gpMonthly.Text = "Monthly Movie Box Office Report"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(39, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(343, 31)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Select Month and Year"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(288, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 34)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Year"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboMonthlyYear
        '
        Me.cboMonthlyYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonthlyYear.FormattingEnabled = True
        Me.cboMonthlyYear.Location = New System.Drawing.Point(285, 94)
        Me.cboMonthlyYear.Name = "cboMonthlyYear"
        Me.cboMonthlyYear.Size = New System.Drawing.Size(121, 28)
        Me.cboMonthlyYear.TabIndex = 24
        '
        'cboMonthlyMonth
        '
        Me.cboMonthlyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonthlyMonth.FormattingEnabled = True
        Me.cboMonthlyMonth.Location = New System.Drawing.Point(117, 94)
        Me.cboMonthlyMonth.Name = "cboMonthlyMonth"
        Me.cboMonthlyMonth.Size = New System.Drawing.Size(121, 28)
        Me.cboMonthlyMonth.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(120, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 34)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Month"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpYearly
        '
        Me.gpYearly.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.gpYearly.Controls.Add(Me.Label15)
        Me.gpYearly.Controls.Add(Me.Label14)
        Me.gpYearly.Controls.Add(Me.cboYearlyYear)
        Me.gpYearly.Enabled = False
        Me.gpYearly.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpYearly.ForeColor = System.Drawing.Color.Yellow
        Me.gpYearly.Location = New System.Drawing.Point(749, 449)
        Me.gpYearly.Name = "gpYearly"
        Me.gpYearly.Size = New System.Drawing.Size(552, 137)
        Me.gpYearly.TabIndex = 23
        Me.gpYearly.TabStop = False
        Me.gpYearly.Text = "Yearly Top 10 Movie Report"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(41, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(243, 31)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Select Year"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(114, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(118, 34)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Year"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboYearlyYear
        '
        Me.cboYearlyYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYearlyYear.FormattingEnabled = True
        Me.cboYearlyYear.Location = New System.Drawing.Point(263, 72)
        Me.cboYearlyYear.Name = "cboYearlyYear"
        Me.cboYearlyYear.Size = New System.Drawing.Size(121, 28)
        Me.cboYearlyYear.TabIndex = 24
        '
        'btnGenerate
        '
        Me.btnGenerate.BackgroundImage = CType(resources.GetObject("btnGenerate.BackgroundImage"), System.Drawing.Image)
        Me.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.Color.Yellow
        Me.btnGenerate.Location = New System.Drawing.Point(1148, 614)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(153, 30)
        Me.btnGenerate.TabIndex = 45
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoScrollMargin = New System.Drawing.Size(0, 50)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.btnBack)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnGenerate)
        Me.Panel2.Controls.Add(Me.gpYearly)
        Me.Panel2.Controls.Add(Me.gpWeekly)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.gpMonthly)
        Me.Panel2.Controls.Add(Me.gpDaily)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.lstReport)
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel2.Location = New System.Drawing.Point(-1, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1372, 809)
        Me.Panel2.TabIndex = 46
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Yellow
        Me.lblTotal.Location = New System.Drawing.Point(255, 1120)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(112, 34)
        Me.lblTotal.TabIndex = 46
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(58, 1120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(189, 34)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Total Records :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Location = New System.Drawing.Point(58, 614)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(343, 31)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Report :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.Yellow
        Me.btnBack.Location = New System.Drawing.Point(62, 1185)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(153, 30)
        Me.btnBack.TabIndex = 45
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Yellow
        Me.btnPrint.Location = New System.Drawing.Point(1148, 1185)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(153, 30)
        Me.btnPrint.TabIndex = 45
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(214, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(86, 20)
        Me.TextBox1.TabIndex = 0
        '
        'lstReport
        '
        Me.lstReport.BackColor = System.Drawing.Color.White
        Me.lstReport.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstReport.FormattingEnabled = True
        Me.lstReport.ItemHeight = 19
        Me.lstReport.Location = New System.Drawing.Point(62, 665)
        Me.lstReport.Name = "lstReport"
        Me.lstReport.Size = New System.Drawing.Size(1239, 441)
        Me.lstReport.TabIndex = 0
        '
        'docReport
        '
        '
        'previewReport
        '
        Me.previewReport.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.previewReport.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.previewReport.ClientSize = New System.Drawing.Size(400, 300)
        Me.previewReport.Enabled = True
        Me.previewReport.Icon = CType(resources.GetObject("previewReport.Icon"), System.Drawing.Icon)
        Me.previewReport.Name = "previewReport"
        Me.previewReport.Visible = False
        '
        'Sales_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1370, 855)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sales_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales_Report"
        Me.pnlTop.ResumeLayout(False)
        Me.CmnuPanelTop.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpDaily.ResumeLayout(False)
        Me.gpWeekly.ResumeLayout(False)
        Me.gpMonthly.ResumeLayout(False)
        Me.gpYearly.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblCinemaName As Label
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents picMinimize As PictureBox
    Friend WithEvents picClose As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents radYearly As RadioButton
    Friend WithEvents radMonthly As RadioButton
    Friend WithEvents radWeekly As RadioButton
    Friend WithEvents radDaily As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents gpDaily As GroupBox
    Friend WithEvents cboDailyYear As ComboBox
    Friend WithEvents cboDailyMonth As ComboBox
    Friend WithEvents cboDailyDay As ComboBox
    Friend WithEvents gpWeekly As GroupBox
    Friend WithEvents gpMonthly As GroupBox
    Friend WithEvents gpYearly As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboWeeklyMonth As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cboWeeklyYear As ComboBox
    Friend WithEvents cboWeeklyDay As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cboMonthlyYear As ComboBox
    Friend WithEvents cboMonthlyMonth As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cboYearlyYear As ComboBox
    Friend WithEvents btnGenerate As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents CmnuPanelTop As ContextMenuStrip
    Friend WithEvents MnuMove As ToolStripMenuItem
    Friend WithEvents MnuMinimize As ToolStripMenuItem
    Friend WithEvents MnuClose As ToolStripMenuItem
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lstReport As ListBox
    Friend WithEvents docReport As Printing.PrintDocument
    Friend WithEvents previewReport As PrintPreviewDialog
End Class
