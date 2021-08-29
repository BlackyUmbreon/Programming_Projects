<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash_Screen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Splash_Screen))
        Me.picCinema = New System.Windows.Forms.PictureBox()
        Me.lblCinemaName = New System.Windows.Forms.Label()
        CType(Me.picCinema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picCinema
        '
        Me.picCinema.BackColor = System.Drawing.Color.Transparent
        Me.picCinema.Image = CType(resources.GetObject("picCinema.Image"), System.Drawing.Image)
        Me.picCinema.Location = New System.Drawing.Point(0, -2)
        Me.picCinema.Name = "picCinema"
        Me.picCinema.Size = New System.Drawing.Size(533, 355)
        Me.picCinema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCinema.TabIndex = 0
        Me.picCinema.TabStop = False
        '
        'lblCinemaName
        '
        Me.lblCinemaName.BackColor = System.Drawing.Color.Transparent
        Me.lblCinemaName.Font = New System.Drawing.Font("Vladimir Script", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCinemaName.ForeColor = System.Drawing.Color.Yellow
        Me.lblCinemaName.Location = New System.Drawing.Point(275, 257)
        Me.lblCinemaName.Name = "lblCinemaName"
        Me.lblCinemaName.Size = New System.Drawing.Size(352, 96)
        Me.lblCinemaName.TabIndex = 1
        Me.lblCinemaName.Text = "Shooting Star Cinema"
        Me.lblCinemaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Splash_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(628, 351)
        Me.Controls.Add(Me.lblCinemaName)
        Me.Controls.Add(Me.picCinema)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Splash_Screen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Splash_Screen"
        CType(Me.picCinema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picCinema As PictureBox
    Friend WithEvents lblCinemaName As Label
End Class
