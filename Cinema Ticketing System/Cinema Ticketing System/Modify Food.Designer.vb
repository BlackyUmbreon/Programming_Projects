<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modify_Food
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modify_Food))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBigName = New System.Windows.Forms.Label()
        Me.picBigPicture = New System.Windows.Forms.PictureBox()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.picFood = New System.Windows.Forms.PictureBox()
        Me.txtFoodDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFoodName = New System.Windows.Forms.TextBox()
        Me.lblFoodID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.msktxtFoodPrice = New System.Windows.Forms.MaskedTextBox()
        Me.filePic = New System.Windows.Forms.OpenFileDialog()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFood, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(285, 38)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Modify Food"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBigName
        '
        Me.lblBigName.BackColor = System.Drawing.Color.Transparent
        Me.lblBigName.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBigName.ForeColor = System.Drawing.Color.Black
        Me.lblBigName.Location = New System.Drawing.Point(160, 33)
        Me.lblBigName.Name = "lblBigName"
        Me.lblBigName.Size = New System.Drawing.Size(295, 37)
        Me.lblBigName.TabIndex = 63
        Me.lblBigName.Text = "Shooting Star Cinema"
        Me.lblBigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picBigPicture
        '
        Me.picBigPicture.BackColor = System.Drawing.Color.Transparent
        Me.picBigPicture.Image = CType(resources.GetObject("picBigPicture.Image"), System.Drawing.Image)
        Me.picBigPicture.Location = New System.Drawing.Point(32, 12)
        Me.picBigPicture.Name = "picBigPicture"
        Me.picBigPicture.Size = New System.Drawing.Size(71, 71)
        Me.picBigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBigPicture.TabIndex = 62
        Me.picBigPicture.TabStop = False
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Location = New System.Drawing.Point(444, 435)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(123, 30)
        Me.btnModify.TabIndex = 4
        Me.btnModify.Text = "Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(33, 435)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(123, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(444, 384)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(123, 30)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'picFood
        '
        Me.picFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFood.Location = New System.Drawing.Point(385, 155)
        Me.picFood.Name = "picFood"
        Me.picFood.Size = New System.Drawing.Size(182, 224)
        Me.picFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFood.TabIndex = 73
        Me.picFood.TabStop = False
        '
        'txtFoodDescription
        '
        Me.txtFoodDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFoodDescription.Location = New System.Drawing.Point(133, 234)
        Me.txtFoodDescription.Multiline = True
        Me.txtFoodDescription.Name = "txtFoodDescription"
        Me.txtFoodDescription.Size = New System.Drawing.Size(228, 103)
        Me.txtFoodDescription.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 19)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Description:"
        '
        'txtFoodName
        '
        Me.txtFoodName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFoodName.Location = New System.Drawing.Point(133, 193)
        Me.txtFoodName.Name = "txtFoodName"
        Me.txtFoodName.Size = New System.Drawing.Size(228, 26)
        Me.txtFoodName.TabIndex = 0
        '
        'lblFoodID
        '
        Me.lblFoodID.BackColor = System.Drawing.Color.Transparent
        Me.lblFoodID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFoodID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoodID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFoodID.Location = New System.Drawing.Point(133, 154)
        Me.lblFoodID.Name = "lblFoodID"
        Me.lblFoodID.Size = New System.Drawing.Size(228, 26)
        Me.lblFoodID.TabIndex = 66
        Me.lblFoodID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 19)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Food ID :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(28, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 19)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Food Name:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(43, 373)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 19)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Price:"
        '
        'msktxtFoodPrice
        '
        Me.msktxtFoodPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msktxtFoodPrice.Location = New System.Drawing.Point(133, 366)
        Me.msktxtFoodPrice.Mask = "99.99"
        Me.msktxtFoodPrice.Name = "msktxtFoodPrice"
        Me.msktxtFoodPrice.Size = New System.Drawing.Size(227, 26)
        Me.msktxtFoodPrice.TabIndex = 2
        Me.msktxtFoodPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.msktxtFoodPrice.ValidatingType = GetType(Date)
        '
        'filePic
        '
        Me.filePic.FileName = "OpenFileDialog1"
        '
        'Modify_Food
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(617, 488)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.msktxtFoodPrice)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.picFood)
        Me.Controls.Add(Me.txtFoodDescription)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFoodName)
        Me.Controls.Add(Me.lblFoodID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblBigName)
        Me.Controls.Add(Me.picBigPicture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Modify_Food"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify_Food"
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFood, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents lblBigName As Label
    Friend WithEvents picBigPicture As PictureBox
    Friend WithEvents btnModify As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnBrowse As Button
    Friend WithEvents picFood As PictureBox
    Friend WithEvents txtFoodDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFoodName As TextBox
    Friend WithEvents lblFoodID As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents msktxtFoodPrice As MaskedTextBox
    Friend WithEvents filePic As OpenFileDialog
End Class
