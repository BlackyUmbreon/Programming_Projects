<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Movie_Details
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Movie_Details))
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMovie = New System.Windows.Forms.Panel()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblTItle = New System.Windows.Forms.Label()
        Me.picPlay = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlMovie.SuspendLayout()
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoScrollMargin = New System.Drawing.Size(0, 80)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnBack)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.chkVIP)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.pnlMovie)
        Me.Panel2.Location = New System.Drawing.Point(-1, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1122, 815)
        Me.Panel2.TabIndex = 16
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.Yellow
        Me.btnBack.Location = New System.Drawing.Point(95, 946)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(145, 45)
        Me.btnBack.TabIndex = 36
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
        Me.Panel3.Location = New System.Drawing.Point(95, 476)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(882, 410)
        Me.Panel3.TabIndex = 35
        '
        'btnTime4
        '
        Me.btnTime4.BackgroundImage = CType(resources.GetObject("btnTime4.BackgroundImage"), System.Drawing.Image)
        Me.btnTime4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime4.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime4.Location = New System.Drawing.Point(475, 123)
        Me.btnTime4.Name = "btnTime4"
        Me.btnTime4.Size = New System.Drawing.Size(313, 51)
        Me.btnTime4.TabIndex = 0
        Me.btnTime4.Text = "Button1"
        Me.btnTime4.UseVisualStyleBackColor = True
        '
        'btnTime5
        '
        Me.btnTime5.BackgroundImage = CType(resources.GetObject("btnTime5.BackgroundImage"), System.Drawing.Image)
        Me.btnTime5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime5.ForeColor = System.Drawing.Color.Navy
        Me.btnTime5.Location = New System.Drawing.Point(72, 209)
        Me.btnTime5.Name = "btnTime5"
        Me.btnTime5.Size = New System.Drawing.Size(313, 51)
        Me.btnTime5.TabIndex = 0
        Me.btnTime5.Text = "Button1"
        Me.btnTime5.UseVisualStyleBackColor = True
        Me.btnTime5.Visible = False
        '
        'btnTime3
        '
        Me.btnTime3.BackgroundImage = CType(resources.GetObject("btnTime3.BackgroundImage"), System.Drawing.Image)
        Me.btnTime3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime3.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime3.Location = New System.Drawing.Point(72, 123)
        Me.btnTime3.Name = "btnTime3"
        Me.btnTime3.Size = New System.Drawing.Size(313, 51)
        Me.btnTime3.TabIndex = 0
        Me.btnTime3.Text = "Button1"
        Me.btnTime3.UseVisualStyleBackColor = True
        '
        'btnTime2
        '
        Me.btnTime2.BackgroundImage = CType(resources.GetObject("btnTime2.BackgroundImage"), System.Drawing.Image)
        Me.btnTime2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime2.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime2.Location = New System.Drawing.Point(475, 37)
        Me.btnTime2.Name = "btnTime2"
        Me.btnTime2.Size = New System.Drawing.Size(313, 51)
        Me.btnTime2.TabIndex = 0
        Me.btnTime2.Text = "Button1"
        Me.btnTime2.UseVisualStyleBackColor = True
        '
        'btnTime1
        '
        Me.btnTime1.BackgroundImage = CType(resources.GetObject("btnTime1.BackgroundImage"), System.Drawing.Image)
        Me.btnTime1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTime1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTime1.ForeColor = System.Drawing.Color.Yellow
        Me.btnTime1.Location = New System.Drawing.Point(72, 37)
        Me.btnTime1.Name = "btnTime1"
        Me.btnTime1.Size = New System.Drawing.Size(313, 51)
        Me.btnTime1.TabIndex = 0
        Me.btnTime1.Text = "Button1"
        Me.btnTime1.UseVisualStyleBackColor = True
        '
        'chkVIP
        '
        Me.chkVIP.BackColor = System.Drawing.Color.Silver
        Me.chkVIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkVIP.Location = New System.Drawing.Point(357, 431)
        Me.chkVIP.Name = "chkVIP"
        Me.chkVIP.Size = New System.Drawing.Size(176, 35)
        Me.chkVIP.TabIndex = 34
        Me.chkVIP.Text = "Shows VIP Rooms"
        Me.chkVIP.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(328, 422)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 55)
        Me.Label4.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(95, 422)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 55)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Cinema Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(318, -189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(463, 65)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Cinema name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMovie
        '
        Me.pnlMovie.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlMovie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMovie.Controls.Add(Me.lblDescription)
        Me.pnlMovie.Controls.Add(Me.lblTItle)
        Me.pnlMovie.Controls.Add(Me.picPlay)
        Me.pnlMovie.Location = New System.Drawing.Point(-2, -2)
        Me.pnlMovie.Name = "pnlMovie"
        Me.pnlMovie.Size = New System.Drawing.Size(1106, 388)
        Me.pnlMovie.TabIndex = 31
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Yellow
        Me.lblDescription.Location = New System.Drawing.Point(30, 308)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(1048, 63)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Movie Title"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTItle
        '
        Me.lblTItle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTItle.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTItle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTItle.Location = New System.Drawing.Point(30, 266)
        Me.lblTItle.Name = "lblTItle"
        Me.lblTItle.Size = New System.Drawing.Size(335, 42)
        Me.lblTItle.TabIndex = 1
        Me.lblTItle.Text = "Movie Title"
        Me.lblTItle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picPlay
        '
        Me.picPlay.BackColor = System.Drawing.Color.Transparent
        Me.picPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picPlay.Image = CType(resources.GetObject("picPlay.Image"), System.Drawing.Image)
        Me.picPlay.Location = New System.Drawing.Point(30, 13)
        Me.picPlay.Name = "picPlay"
        Me.picPlay.Size = New System.Drawing.Size(59, 56)
        Me.picPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPlay.TabIndex = 0
        Me.picPlay.TabStop = False
        '
        'Movie_Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1119, 814)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Movie_Details"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movie_Details"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlMovie.ResumeLayout(False)
        CType(Me.picPlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkVIP As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlMovie As Panel
    Friend WithEvents lblTItle As Label
    Friend WithEvents picPlay As PictureBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnTime4 As Button
    Friend WithEvents btnTime5 As Button
    Friend WithEvents btnTime3 As Button
    Friend WithEvents btnTime2 As Button
    Friend WithEvents btnTime1 As Button
    Friend WithEvents btnBack As Button
End Class
