<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SystemSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemSelection))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.CmnuPanelTop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMinimize = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCinemaName = New System.Windows.Forms.Label()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.picMinimize = New System.Windows.Forms.PictureBox()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.pnlKiosk = New System.Windows.Forms.Panel()
        Me.lblKiosk = New System.Windows.Forms.Label()
        Me.picKiosk = New System.Windows.Forms.PictureBox()
        Me.pnlHome = New System.Windows.Forms.Panel()
        Me.lblHome = New System.Windows.Forms.Label()
        Me.picHome = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DB_CinemaDataSet = New Cinema_Ticketing_System.DB_CinemaDataSet()
        Me.TransactionTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.TransactionTableAdapter()
        Me.pnlTop.SuspendLayout()
        Me.CmnuPanelTop.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlKiosk.SuspendLayout()
        CType(Me.picKiosk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHome.SuspendLayout()
        CType(Me.picHome, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlTop.Location = New System.Drawing.Point(-13, -1)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1392, 48)
        Me.pnlTop.TabIndex = 0
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
        Me.picMinimize.Location = New System.Drawing.Point(1277, 3)
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
        Me.picClose.Location = New System.Drawing.Point(1335, 3)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(40, 38)
        Me.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClose.TabIndex = 1
        Me.picClose.TabStop = False
        '
        'pnlKiosk
        '
        Me.pnlKiosk.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlKiosk.Controls.Add(Me.lblKiosk)
        Me.pnlKiosk.Controls.Add(Me.picKiosk)
        Me.pnlKiosk.Location = New System.Drawing.Point(225, 175)
        Me.pnlKiosk.Name = "pnlKiosk"
        Me.pnlKiosk.Size = New System.Drawing.Size(355, 377)
        Me.pnlKiosk.TabIndex = 2
        '
        'lblKiosk
        '
        Me.lblKiosk.BackColor = System.Drawing.Color.Transparent
        Me.lblKiosk.Font = New System.Drawing.Font("Times New Roman", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKiosk.ForeColor = System.Drawing.Color.Transparent
        Me.lblKiosk.Location = New System.Drawing.Point(0, 321)
        Me.lblKiosk.Name = "lblKiosk"
        Me.lblKiosk.Size = New System.Drawing.Size(355, 56)
        Me.lblKiosk.TabIndex = 1
        Me.lblKiosk.Text = "Kiosk System"
        Me.lblKiosk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picKiosk
        '
        Me.picKiosk.BackColor = System.Drawing.Color.Transparent
        Me.picKiosk.Image = CType(resources.GetObject("picKiosk.Image"), System.Drawing.Image)
        Me.picKiosk.Location = New System.Drawing.Point(0, 0)
        Me.picKiosk.Name = "picKiosk"
        Me.picKiosk.Size = New System.Drawing.Size(355, 320)
        Me.picKiosk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKiosk.TabIndex = 0
        Me.picKiosk.TabStop = False
        '
        'pnlHome
        '
        Me.pnlHome.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlHome.Controls.Add(Me.lblHome)
        Me.pnlHome.Controls.Add(Me.picHome)
        Me.pnlHome.Location = New System.Drawing.Point(781, 175)
        Me.pnlHome.Name = "pnlHome"
        Me.pnlHome.Size = New System.Drawing.Size(355, 377)
        Me.pnlHome.TabIndex = 2
        '
        'lblHome
        '
        Me.lblHome.BackColor = System.Drawing.Color.Transparent
        Me.lblHome.Font = New System.Drawing.Font("Times New Roman", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHome.ForeColor = System.Drawing.Color.White
        Me.lblHome.Location = New System.Drawing.Point(0, 321)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(355, 56)
        Me.lblHome.TabIndex = 1
        Me.lblHome.Text = "Home Page System"
        Me.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picHome
        '
        Me.picHome.BackColor = System.Drawing.Color.Transparent
        Me.picHome.Image = CType(resources.GetObject("picHome.Image"), System.Drawing.Image)
        Me.picHome.Location = New System.Drawing.Point(0, 0)
        Me.picHome.Name = "picHome"
        Me.picHome.Size = New System.Drawing.Size(355, 320)
        Me.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHome.TabIndex = 0
        Me.picHome.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(409, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(574, 56)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Select one Cinema System"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DB_CinemaDataSet
        '
        Me.DB_CinemaDataSet.DataSetName = "DB_CinemaDataSet"
        Me.DB_CinemaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TransactionTableAdapter
        '
        Me.TransactionTableAdapter.ClearBeforeFill = True
        '
        'SystemSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1375, 600)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlHome)
        Me.Controls.Add(Me.pnlKiosk)
        Me.Controls.Add(Me.pnlTop)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SystemSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cinema Name"
        Me.pnlTop.ResumeLayout(False)
        Me.CmnuPanelTop.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlKiosk.ResumeLayout(False)
        CType(Me.picKiosk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHome.ResumeLayout(False)
        CType(Me.picHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents picClose As PictureBox
    Friend WithEvents picMinimize As PictureBox
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents lblCinemaName As Label
    Friend WithEvents CmnuPanelTop As ContextMenuStrip
    Friend WithEvents MnuMove As ToolStripMenuItem
    Friend WithEvents MnuMinimize As ToolStripMenuItem
    Friend WithEvents MnuClose As ToolStripMenuItem
    Friend WithEvents pnlKiosk As Panel
    Friend WithEvents lblKiosk As Label
    Friend WithEvents picKiosk As PictureBox
    Friend WithEvents pnlHome As Panel
    Friend WithEvents lblHome As Label
    Friend WithEvents picHome As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DB_CinemaDataSet As DB_CinemaDataSet
    Friend WithEvents TransactionTableAdapter As DB_CinemaDataSetTableAdapters.TransactionTableAdapter
End Class
