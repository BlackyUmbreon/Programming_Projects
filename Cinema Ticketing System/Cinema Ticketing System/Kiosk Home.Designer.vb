<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KioskHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KioskHome))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPosterName = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.picMovie9 = New System.Windows.Forms.PictureBox()
        Me.picMovie8 = New System.Windows.Forms.PictureBox()
        Me.picMovie7 = New System.Windows.Forms.PictureBox()
        Me.picMovie6 = New System.Windows.Forms.PictureBox()
        Me.picMovie5 = New System.Windows.Forms.PictureBox()
        Me.picMovie4 = New System.Windows.Forms.PictureBox()
        Me.picMovie3 = New System.Windows.Forms.PictureBox()
        Me.picMovie2 = New System.Windows.Forms.PictureBox()
        Me.picMovie1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBigName = New System.Windows.Forms.Label()
        Me.picBigPicture = New System.Windows.Forms.PictureBox()
        Me.lblPoster2 = New System.Windows.Forms.Label()
        Me.lblPoster3 = New System.Windows.Forms.Label()
        Me.lblPoster4 = New System.Windows.Forms.Label()
        Me.lblPoster1 = New System.Windows.Forms.Label()
        Me.picNext = New System.Windows.Forms.PictureBox()
        Me.picBack = New System.Windows.Forms.PictureBox()
        Me.picPoster = New System.Windows.Forms.PictureBox()
        Me.mnuExit = New System.Windows.Forms.MenuStrip()
        Me.FIleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmDate = New System.Windows.Forms.Timer(Me.components)
        Me.DB_CinemaDataSet = New Cinema_Ticketing_System.DB_CinemaDataSet()
        Me.RoomTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.RoomTableAdapter()
        Me.ShowTimeTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.ShowTimeTableAdapter()
        Me.SeatTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.SeatTableAdapter()
        Me.MovieTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.MovieTableAdapter()
        Me.Panel2.SuspendLayout()
        CType(Me.picMovie9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMovie1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPoster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuExit.SuspendLayout()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoScrollMargin = New System.Drawing.Size(0, 100)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblPosterName)
        Me.Panel2.Controls.Add(Me.lblDate)
        Me.Panel2.Controls.Add(Me.picMovie9)
        Me.Panel2.Controls.Add(Me.picMovie8)
        Me.Panel2.Controls.Add(Me.picMovie7)
        Me.Panel2.Controls.Add(Me.picMovie6)
        Me.Panel2.Controls.Add(Me.picMovie5)
        Me.Panel2.Controls.Add(Me.picMovie4)
        Me.Panel2.Controls.Add(Me.picMovie3)
        Me.Panel2.Controls.Add(Me.picMovie2)
        Me.Panel2.Controls.Add(Me.picMovie1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblBigName)
        Me.Panel2.Controls.Add(Me.picBigPicture)
        Me.Panel2.Controls.Add(Me.lblPoster2)
        Me.Panel2.Controls.Add(Me.lblPoster3)
        Me.Panel2.Controls.Add(Me.lblPoster4)
        Me.Panel2.Controls.Add(Me.lblPoster1)
        Me.Panel2.Controls.Add(Me.picNext)
        Me.Panel2.Controls.Add(Me.picBack)
        Me.Panel2.Controls.Add(Me.picPoster)
        Me.Panel2.Controls.Add(Me.mnuExit)
        Me.Panel2.Location = New System.Drawing.Point(-1, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1126, 815)
        Me.Panel2.TabIndex = 17
        '
        'lblPosterName
        '
        Me.lblPosterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosterName.ForeColor = System.Drawing.Color.Yellow
        Me.lblPosterName.Location = New System.Drawing.Point(179, 564)
        Me.lblPosterName.Name = "lblPosterName"
        Me.lblPosterName.Size = New System.Drawing.Size(482, 48)
        Me.lblPosterName.TabIndex = 87
        Me.lblPosterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Yellow
        Me.lblDate.Location = New System.Drawing.Point(868, 26)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(189, 34)
        Me.lblDate.TabIndex = 86
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picMovie9
        '
        Me.picMovie9.BackColor = System.Drawing.Color.Gray
        Me.picMovie9.Location = New System.Drawing.Point(782, 1705)
        Me.picMovie9.Name = "picMovie9"
        Me.picMovie9.Size = New System.Drawing.Size(230, 310)
        Me.picMovie9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie9.TabIndex = 84
        Me.picMovie9.TabStop = False
        '
        'picMovie8
        '
        Me.picMovie8.BackColor = System.Drawing.Color.Gray
        Me.picMovie8.Location = New System.Drawing.Point(437, 1705)
        Me.picMovie8.Name = "picMovie8"
        Me.picMovie8.Size = New System.Drawing.Size(230, 310)
        Me.picMovie8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie8.TabIndex = 83
        Me.picMovie8.TabStop = False
        '
        'picMovie7
        '
        Me.picMovie7.BackColor = System.Drawing.Color.Gray
        Me.picMovie7.Location = New System.Drawing.Point(92, 1705)
        Me.picMovie7.Name = "picMovie7"
        Me.picMovie7.Size = New System.Drawing.Size(230, 310)
        Me.picMovie7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie7.TabIndex = 82
        Me.picMovie7.TabStop = False
        '
        'picMovie6
        '
        Me.picMovie6.BackColor = System.Drawing.Color.Gray
        Me.picMovie6.Location = New System.Drawing.Point(782, 1272)
        Me.picMovie6.Name = "picMovie6"
        Me.picMovie6.Size = New System.Drawing.Size(230, 310)
        Me.picMovie6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie6.TabIndex = 81
        Me.picMovie6.TabStop = False
        '
        'picMovie5
        '
        Me.picMovie5.BackColor = System.Drawing.Color.Gray
        Me.picMovie5.Location = New System.Drawing.Point(437, 1272)
        Me.picMovie5.Name = "picMovie5"
        Me.picMovie5.Size = New System.Drawing.Size(230, 310)
        Me.picMovie5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie5.TabIndex = 80
        Me.picMovie5.TabStop = False
        '
        'picMovie4
        '
        Me.picMovie4.BackColor = System.Drawing.Color.Gray
        Me.picMovie4.Location = New System.Drawing.Point(92, 1272)
        Me.picMovie4.Name = "picMovie4"
        Me.picMovie4.Size = New System.Drawing.Size(230, 310)
        Me.picMovie4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie4.TabIndex = 79
        Me.picMovie4.TabStop = False
        '
        'picMovie3
        '
        Me.picMovie3.BackColor = System.Drawing.Color.Gray
        Me.picMovie3.Location = New System.Drawing.Point(782, 839)
        Me.picMovie3.Name = "picMovie3"
        Me.picMovie3.Size = New System.Drawing.Size(230, 310)
        Me.picMovie3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie3.TabIndex = 78
        Me.picMovie3.TabStop = False
        '
        'picMovie2
        '
        Me.picMovie2.BackColor = System.Drawing.Color.Gray
        Me.picMovie2.Location = New System.Drawing.Point(437, 839)
        Me.picMovie2.Name = "picMovie2"
        Me.picMovie2.Size = New System.Drawing.Size(230, 310)
        Me.picMovie2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie2.TabIndex = 77
        Me.picMovie2.TabStop = False
        '
        'picMovie1
        '
        Me.picMovie1.BackColor = System.Drawing.Color.Gray
        Me.picMovie1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picMovie1.Location = New System.Drawing.Point(92, 839)
        Me.picMovie1.Name = "picMovie1"
        Me.picMovie1.Size = New System.Drawing.Size(230, 310)
        Me.picMovie1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMovie1.TabIndex = 76
        Me.picMovie1.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(56, 722)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(247, 66)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Today Showing"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBigName
        '
        Me.lblBigName.BackColor = System.Drawing.Color.Transparent
        Me.lblBigName.Font = New System.Drawing.Font("Comic Sans MS", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBigName.ForeColor = System.Drawing.Color.Yellow
        Me.lblBigName.Location = New System.Drawing.Point(364, 26)
        Me.lblBigName.Name = "lblBigName"
        Me.lblBigName.Size = New System.Drawing.Size(529, 100)
        Me.lblBigName.TabIndex = 9
        Me.lblBigName.Text = "Shooting Star Cinema"
        Me.lblBigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picBigPicture
        '
        Me.picBigPicture.BackColor = System.Drawing.Color.Transparent
        Me.picBigPicture.Image = CType(resources.GetObject("picBigPicture.Image"), System.Drawing.Image)
        Me.picBigPicture.Location = New System.Drawing.Point(223, 13)
        Me.picBigPicture.Name = "picBigPicture"
        Me.picBigPicture.Size = New System.Drawing.Size(135, 120)
        Me.picBigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBigPicture.TabIndex = 8
        Me.picBigPicture.TabStop = False
        '
        'lblPoster2
        '
        Me.lblPoster2.BackColor = System.Drawing.Color.Silver
        Me.lblPoster2.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblPoster2.Location = New System.Drawing.Point(399, 627)
        Me.lblPoster2.Name = "lblPoster2"
        Me.lblPoster2.Size = New System.Drawing.Size(100, 11)
        Me.lblPoster2.TabIndex = 7
        '
        'lblPoster3
        '
        Me.lblPoster3.BackColor = System.Drawing.Color.Silver
        Me.lblPoster3.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblPoster3.Location = New System.Drawing.Point(615, 627)
        Me.lblPoster3.Name = "lblPoster3"
        Me.lblPoster3.Size = New System.Drawing.Size(100, 11)
        Me.lblPoster3.TabIndex = 6
        '
        'lblPoster4
        '
        Me.lblPoster4.BackColor = System.Drawing.Color.Silver
        Me.lblPoster4.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblPoster4.Location = New System.Drawing.Point(831, 627)
        Me.lblPoster4.Name = "lblPoster4"
        Me.lblPoster4.Size = New System.Drawing.Size(100, 11)
        Me.lblPoster4.TabIndex = 5
        '
        'lblPoster1
        '
        Me.lblPoster1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblPoster1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblPoster1.Location = New System.Drawing.Point(183, 627)
        Me.lblPoster1.Name = "lblPoster1"
        Me.lblPoster1.Size = New System.Drawing.Size(100, 11)
        Me.lblPoster1.TabIndex = 4
        '
        'picNext
        '
        Me.picNext.BackColor = System.Drawing.Color.Transparent
        Me.picNext.Image = CType(resources.GetObject("picNext.Image"), System.Drawing.Image)
        Me.picNext.Location = New System.Drawing.Point(996, 380)
        Me.picNext.Name = "picNext"
        Me.picNext.Size = New System.Drawing.Size(43, 49)
        Me.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picNext.TabIndex = 3
        Me.picNext.TabStop = False
        '
        'picBack
        '
        Me.picBack.BackColor = System.Drawing.Color.Transparent
        Me.picBack.Image = CType(resources.GetObject("picBack.Image"), System.Drawing.Image)
        Me.picBack.Location = New System.Drawing.Point(74, 380)
        Me.picBack.Name = "picBack"
        Me.picBack.Size = New System.Drawing.Size(43, 49)
        Me.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBack.TabIndex = 2
        Me.picBack.TabStop = False
        '
        'picPoster
        '
        Me.picPoster.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.picPoster.Location = New System.Drawing.Point(165, 236)
        Me.picPoster.Name = "picPoster"
        Me.picPoster.Size = New System.Drawing.Size(772, 316)
        Me.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPoster.TabIndex = 1
        Me.picPoster.TabStop = False
        '
        'mnuExit
        '
        Me.mnuExit.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuExit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FIleToolStripMenuItem})
        Me.mnuExit.Location = New System.Drawing.Point(0, 953)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(1109, 24)
        Me.mnuExit.TabIndex = 85
        Me.mnuExit.Text = "MenuStrip1"
        Me.mnuExit.Visible = False
        '
        'FIleToolStripMenuItem
        '
        Me.FIleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        Me.FIleToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FIleToolStripMenuItem.Text = "FIle"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'tmDate
        '
        Me.tmDate.Interval = 1000
        '
        'DB_CinemaDataSet
        '
        Me.DB_CinemaDataSet.DataSetName = "DB_CinemaDataSet"
        Me.DB_CinemaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RoomTableAdapter
        '
        Me.RoomTableAdapter.ClearBeforeFill = True
        '
        'ShowTimeTableAdapter
        '
        Me.ShowTimeTableAdapter.ClearBeforeFill = True
        '
        'SeatTableAdapter
        '
        Me.SeatTableAdapter.ClearBeforeFill = True
        '
        'MovieTableAdapter
        '
        Me.MovieTableAdapter.ClearBeforeFill = True
        '
        'KioskHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1124, 816)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuExit
        Me.Name = "KioskHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picMovie9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMovie1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPoster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuExit.ResumeLayout(False)
        Me.mnuExit.PerformLayout()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents picNext As PictureBox
    Friend WithEvents picBack As PictureBox
    Friend WithEvents picPoster As PictureBox
    Friend WithEvents lblPoster2 As Label
    Friend WithEvents lblPoster3 As Label
    Friend WithEvents lblPoster4 As Label
    Friend WithEvents lblPoster1 As Label
    Friend WithEvents lblBigName As Label
    Friend WithEvents picBigPicture As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents picMovie9 As PictureBox
    Friend WithEvents picMovie8 As PictureBox
    Friend WithEvents picMovie7 As PictureBox
    Friend WithEvents picMovie6 As PictureBox
    Friend WithEvents picMovie5 As PictureBox
    Friend WithEvents picMovie4 As PictureBox
    Friend WithEvents picMovie3 As PictureBox
    Friend WithEvents picMovie2 As PictureBox
    Friend WithEvents picMovie1 As PictureBox
    Friend WithEvents mnuExit As MenuStrip
    Friend WithEvents FIleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblDate As Label
    Friend WithEvents tmDate As Timer
    Friend WithEvents DB_CinemaDataSet As DB_CinemaDataSet
    Friend WithEvents RoomTableAdapter As DB_CinemaDataSetTableAdapters.RoomTableAdapter
    Friend WithEvents ShowTimeTableAdapter As DB_CinemaDataSetTableAdapters.ShowTimeTableAdapter
    Friend WithEvents SeatTableAdapter As DB_CinemaDataSetTableAdapters.SeatTableAdapter
    Friend WithEvents MovieTableAdapter As DB_CinemaDataSetTableAdapters.MovieTableAdapter
    Friend WithEvents lblPosterName As Label
End Class
