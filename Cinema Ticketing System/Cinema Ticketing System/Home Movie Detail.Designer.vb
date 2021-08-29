<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home_Movie_Detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home_Movie_Detail))
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
        Me.lblLogOut = New System.Windows.Forms.Label()
        Me.lblsales = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblHome = New System.Windows.Forms.Label()
        Me.picLogOut = New System.Windows.Forms.PictureBox()
        Me.picsales = New System.Windows.Forms.PictureBox()
        Me.picData = New System.Windows.Forms.PictureBox()
        Me.picHome = New System.Windows.Forms.PictureBox()
        Me.picCinema = New System.Windows.Forms.PictureBox()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnTime4 = New System.Windows.Forms.Button()
        Me.btnTime5 = New System.Windows.Forms.Button()
        Me.btnTime3 = New System.Windows.Forms.Button()
        Me.btnTime2 = New System.Windows.Forms.Button()
        Me.btnTime1 = New System.Windows.Forms.Button()
        Me.chkVIP = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMovie = New System.Windows.Forms.Panel()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTItle = New System.Windows.Forms.Label()
        Me.picPlay = New System.Windows.Forms.PictureBox()
        Me.pnlTop.SuspendLayout()
        Me.CmnuPanelTop.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picsales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCinema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlMovie.SuspendLayout()
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.picMinimize.Location = New System.Drawing.Point(1243, 4)
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
        Me.picClose.Location = New System.Drawing.Point(1306, 4)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(40, 38)
        Me.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClose.TabIndex = 1
        Me.picClose.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblLogOut)
        Me.Panel1.Controls.Add(Me.lblsales)
        Me.Panel1.Controls.Add(Me.lblData)
        Me.Panel1.Controls.Add(Me.lblHome)
        Me.Panel1.Controls.Add(Me.picLogOut)
        Me.Panel1.Controls.Add(Me.picsales)
        Me.Panel1.Controls.Add(Me.picData)
        Me.Panel1.Controls.Add(Me.picHome)
        Me.Panel1.Controls.Add(Me.picCinema)
        Me.Panel1.Controls.Add(Me.lblMenu)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(235, 810)
        Me.Panel1.TabIndex = 22
        '
        'lblLogOut
        '
        Me.lblLogOut.Font = New System.Drawing.Font("Edwardian Script ITC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogOut.ForeColor = System.Drawing.Color.White
        Me.lblLogOut.Location = New System.Drawing.Point(65, 654)
        Me.lblLogOut.Name = "lblLogOut"
        Me.lblLogOut.Size = New System.Drawing.Size(155, 48)
        Me.lblLogOut.TabIndex = 10
        Me.lblLogOut.Text = "Log Out"
        Me.lblLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsales
        '
        Me.lblsales.Font = New System.Drawing.Font("Edwardian Script ITC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsales.ForeColor = System.Drawing.Color.White
        Me.lblsales.Location = New System.Drawing.Point(65, 536)
        Me.lblsales.Name = "lblsales"
        Me.lblsales.Size = New System.Drawing.Size(155, 48)
        Me.lblsales.TabIndex = 11
        Me.lblsales.Text = "Sales Report"
        Me.lblsales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblsales.Visible = False
        '
        'lblData
        '
        Me.lblData.Font = New System.Drawing.Font("Edwardian Script ITC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.ForeColor = System.Drawing.Color.White
        Me.lblData.Location = New System.Drawing.Point(65, 418)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(155, 48)
        Me.lblData.TabIndex = 12
        Me.lblData.Text = "Data Control"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblData.Visible = False
        '
        'lblHome
        '
        Me.lblHome.Font = New System.Drawing.Font("Edwardian Script ITC", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHome.ForeColor = System.Drawing.Color.White
        Me.lblHome.Location = New System.Drawing.Point(65, 300)
        Me.lblHome.Name = "lblHome"
        Me.lblHome.Size = New System.Drawing.Size(155, 48)
        Me.lblHome.TabIndex = 13
        Me.lblHome.Text = "Home"
        Me.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picLogOut
        '
        Me.picLogOut.BackColor = System.Drawing.Color.Transparent
        Me.picLogOut.Image = CType(resources.GetObject("picLogOut.Image"), System.Drawing.Image)
        Me.picLogOut.Location = New System.Drawing.Point(9, 652)
        Me.picLogOut.Name = "picLogOut"
        Me.picLogOut.Size = New System.Drawing.Size(50, 50)
        Me.picLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogOut.TabIndex = 6
        Me.picLogOut.TabStop = False
        '
        'picsales
        '
        Me.picsales.BackColor = System.Drawing.Color.Transparent
        Me.picsales.Image = CType(resources.GetObject("picsales.Image"), System.Drawing.Image)
        Me.picsales.Location = New System.Drawing.Point(9, 534)
        Me.picsales.Name = "picsales"
        Me.picsales.Size = New System.Drawing.Size(50, 50)
        Me.picsales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picsales.TabIndex = 7
        Me.picsales.TabStop = False
        Me.picsales.Visible = False
        '
        'picData
        '
        Me.picData.BackColor = System.Drawing.Color.Transparent
        Me.picData.Image = CType(resources.GetObject("picData.Image"), System.Drawing.Image)
        Me.picData.Location = New System.Drawing.Point(9, 416)
        Me.picData.Name = "picData"
        Me.picData.Size = New System.Drawing.Size(50, 50)
        Me.picData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picData.TabIndex = 8
        Me.picData.TabStop = False
        Me.picData.Visible = False
        '
        'picHome
        '
        Me.picHome.BackColor = System.Drawing.Color.Transparent
        Me.picHome.Image = CType(resources.GetObject("picHome.Image"), System.Drawing.Image)
        Me.picHome.Location = New System.Drawing.Point(9, 298)
        Me.picHome.Name = "picHome"
        Me.picHome.Size = New System.Drawing.Size(50, 50)
        Me.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHome.TabIndex = 9
        Me.picHome.TabStop = False
        '
        'picCinema
        '
        Me.picCinema.Image = CType(resources.GetObject("picCinema.Image"), System.Drawing.Image)
        Me.picCinema.Location = New System.Drawing.Point(53, 7)
        Me.picCinema.Name = "picCinema"
        Me.picCinema.Size = New System.Drawing.Size(127, 127)
        Me.picCinema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCinema.TabIndex = 4
        Me.picCinema.TabStop = False
        '
        'lblMenu
        '
        Me.lblMenu.Font = New System.Drawing.Font("Edwardian Script ITC", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenu.ForeColor = System.Drawing.Color.White
        Me.lblMenu.Location = New System.Drawing.Point(45, 200)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(135, 48)
        Me.lblMenu.TabIndex = 5
        Me.lblMenu.Text = "Menu"
        Me.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(16, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SS Cinema"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoScrollMargin = New System.Drawing.Size(0, 50)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnBack)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.chkVIP)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.pnlMovie)
        Me.Panel2.Location = New System.Drawing.Point(234, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 808)
        Me.Panel2.TabIndex = 23
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.Yellow
        Me.btnBack.Location = New System.Drawing.Point(136, 990)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(145, 45)
        Me.btnBack.TabIndex = 41
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnTime4)
        Me.Panel3.Controls.Add(Me.btnTime5)
        Me.Panel3.Controls.Add(Me.btnTime3)
        Me.Panel3.Controls.Add(Me.btnTime2)
        Me.Panel3.Controls.Add(Me.btnTime1)
        Me.Panel3.Location = New System.Drawing.Point(136, 520)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(882, 410)
        Me.Panel3.TabIndex = 40
        '
        'btnTime4
        '
        Me.btnTime4.BackgroundImage = CType(resources.GetObject("btnTime4.BackgroundImage"), System.Drawing.Image)
        Me.btnTime4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime4.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime4.Location = New System.Drawing.Point(475, 123)
        Me.btnTime4.Name = "btnTime4"
        Me.btnTime4.Size = New System.Drawing.Size(313, 51)
        Me.btnTime4.TabIndex = 0
        Me.btnTime4.UseVisualStyleBackColor = True
        '
        'btnTime5
        '
        Me.btnTime5.BackgroundImage = CType(resources.GetObject("btnTime5.BackgroundImage"), System.Drawing.Image)
        Me.btnTime5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTime5.Location = New System.Drawing.Point(72, 209)
        Me.btnTime5.Name = "btnTime5"
        Me.btnTime5.Size = New System.Drawing.Size(313, 51)
        Me.btnTime5.TabIndex = 0
        Me.btnTime5.UseVisualStyleBackColor = True
        Me.btnTime5.Visible = False
        '
        'btnTime3
        '
        Me.btnTime3.BackgroundImage = CType(resources.GetObject("btnTime3.BackgroundImage"), System.Drawing.Image)
        Me.btnTime3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime3.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime3.Location = New System.Drawing.Point(72, 123)
        Me.btnTime3.Name = "btnTime3"
        Me.btnTime3.Size = New System.Drawing.Size(313, 51)
        Me.btnTime3.TabIndex = 0
        Me.btnTime3.UseVisualStyleBackColor = True
        '
        'btnTime2
        '
        Me.btnTime2.BackgroundImage = CType(resources.GetObject("btnTime2.BackgroundImage"), System.Drawing.Image)
        Me.btnTime2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime2.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime2.Location = New System.Drawing.Point(475, 37)
        Me.btnTime2.Name = "btnTime2"
        Me.btnTime2.Size = New System.Drawing.Size(313, 51)
        Me.btnTime2.TabIndex = 0
        Me.btnTime2.UseVisualStyleBackColor = True
        '
        'btnTime1
        '
        Me.btnTime1.BackgroundImage = CType(resources.GetObject("btnTime1.BackgroundImage"), System.Drawing.Image)
        Me.btnTime1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime1.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime1.Location = New System.Drawing.Point(72, 37)
        Me.btnTime1.Name = "btnTime1"
        Me.btnTime1.Size = New System.Drawing.Size(313, 51)
        Me.btnTime1.TabIndex = 0
        Me.btnTime1.UseVisualStyleBackColor = True
        '
        'chkVIP
        '
        Me.chkVIP.BackColor = System.Drawing.Color.Silver
        Me.chkVIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkVIP.Location = New System.Drawing.Point(398, 475)
        Me.chkVIP.Name = "chkVIP"
        Me.chkVIP.Size = New System.Drawing.Size(176, 35)
        Me.chkVIP.TabIndex = 39
        Me.chkVIP.Text = "Shows VIP Rooms"
        Me.chkVIP.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(369, 466)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 55)
        Me.Label4.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 466)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 55)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Cinema Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMovie
        '
        Me.pnlMovie.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMovie.Controls.Add(Me.lblDescription)
        Me.pnlMovie.Controls.Add(Me.lblTItle)
        Me.pnlMovie.Controls.Add(Me.picPlay)
        Me.pnlMovie.Location = New System.Drawing.Point(0, 1)
        Me.pnlMovie.Name = "pnlMovie"
        Me.pnlMovie.Size = New System.Drawing.Size(1108, 388)
        Me.pnlMovie.TabIndex = 32
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Yellow
        Me.lblDescription.Location = New System.Drawing.Point(30, 308)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(1059, 63)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Movie Title"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTItle
        '
        Me.lblTItle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTItle.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTItle.Location = New System.Drawing.Point(27, 256)
        Me.lblTItle.Name = "lblTItle"
        Me.lblTItle.Size = New System.Drawing.Size(516, 42)
        Me.lblTItle.TabIndex = 1
        Me.lblTItle.Text = "Movie Title"
        Me.lblTItle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picPlay
        '
        Me.picPlay.BackColor = System.Drawing.Color.Transparent
        Me.picPlay.Image = CType(resources.GetObject("picPlay.Image"), System.Drawing.Image)
        Me.picPlay.Location = New System.Drawing.Point(30, 13)
        Me.picPlay.Name = "picPlay"
        Me.picPlay.Size = New System.Drawing.Size(63, 63)
        Me.picPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPlay.TabIndex = 0
        Me.picPlay.TabStop = False
        '
        'Home_Movie_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1359, 855)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Home_Movie_Detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home_Movie_Detail"
        Me.pnlTop.ResumeLayout(False)
        Me.CmnuPanelTop.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picLogOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picsales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCinema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlMovie.ResumeLayout(False)
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblCinemaName As Label
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents picMinimize As PictureBox
    Friend WithEvents picClose As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picCinema As PictureBox
    Friend WithEvents lblMenu As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlMovie As Panel
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblTItle As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnTime4 As Button
    Friend WithEvents btnTime5 As Button
    Friend WithEvents btnTime3 As Button
    Friend WithEvents btnTime2 As Button
    Friend WithEvents btnTime1 As Button
    Friend WithEvents chkVIP As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CmnuPanelTop As ContextMenuStrip
    Friend WithEvents MnuMove As ToolStripMenuItem
    Friend WithEvents MnuMinimize As ToolStripMenuItem
    Friend WithEvents MnuClose As ToolStripMenuItem
    Friend WithEvents lblLogOut As Label
    Friend WithEvents lblsales As Label
    Friend WithEvents lblData As Label
    Friend WithEvents lblHome As Label
    Friend WithEvents picLogOut As PictureBox
    Friend WithEvents picsales As PictureBox
    Friend WithEvents picData As PictureBox
    Friend WithEvents picHome As PictureBox
    Friend WithEvents picPlay As PictureBox
End Class
