<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Data_Control
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Data_Control))
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.lblBigName = New System.Windows.Forms.Label()
        Me.picBigPicture = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TransactionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DB_CinemaDataSet = New Cinema_Ticketing_System.DB_CinemaDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbosort = New System.Windows.Forms.ComboBox()
        Me.FoodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FoodTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.FoodTableAdapter()
        Me.TableAdapterManager = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.TableAdapterManager()
        Me.MemberTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.MemberTableAdapter()
        Me.MovieTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.MovieTableAdapter()
        Me.RoomTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.RoomTableAdapter()
        Me.SeatTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.SeatTableAdapter()
        Me.ShowTimeTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.ShowTimeTableAdapter()
        Me.StaffTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.StaffTableAdapter()
        Me.TransactionTableAdapter = New Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.TransactionTableAdapter()
        Me.MemberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MovieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RoomBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SeatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShowTimeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StaffBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDirection = New System.Windows.Forms.ComboBox()
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FoodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MovieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RoomBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShowTimeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StaffBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(149, 136)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(161, 28)
        Me.cboType.TabIndex = 0
        '
        'lblBigName
        '
        Me.lblBigName.BackColor = System.Drawing.Color.Transparent
        Me.lblBigName.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBigName.ForeColor = System.Drawing.Color.Black
        Me.lblBigName.Location = New System.Drawing.Point(144, 12)
        Me.lblBigName.Name = "lblBigName"
        Me.lblBigName.Size = New System.Drawing.Size(360, 71)
        Me.lblBigName.TabIndex = 11
        Me.lblBigName.Text = "Shooting Star Cinema"
        Me.lblBigName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picBigPicture
        '
        Me.picBigPicture.BackColor = System.Drawing.Color.Transparent
        Me.picBigPicture.Image = CType(resources.GetObject("picBigPicture.Image"), System.Drawing.Image)
        Me.picBigPicture.Location = New System.Drawing.Point(45, 12)
        Me.picBigPicture.Name = "picBigPicture"
        Me.picBigPicture.Size = New System.Drawing.Size(73, 71)
        Me.picBigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBigPicture.TabIndex = 10
        Me.picBigPicture.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(43, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1152, 364)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'DataGridView
        '
        Me.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.GridColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView.Location = New System.Drawing.Point(6, 19)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(1140, 330)
        Me.DataGridView.TabIndex = 0
        '
        'TransactionBindingSource
        '
        Me.TransactionBindingSource.DataMember = "Transaction"
        Me.TransactionBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'DB_CinemaDataSet
        '
        Me.DB_CinemaDataSet.DataSetName = "DB_CinemaDataSet"
        Me.DB_CinemaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(465, 38)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Data Control"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Data Type :"
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(860, 136)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(213, 26)
        Me.txtID.TabIndex = 3
        '
        'btnsearch
        '
        Me.btnsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.Location = New System.Drawing.Point(1079, 135)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(110, 28)
        Me.btnsearch.TabIndex = 4
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(43, 552)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(110, 28)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(1085, 552)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(110, 28)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Location = New System.Drawing.Point(969, 552)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(110, 28)
        Me.btnModify.TabIndex = 6
        Me.btnModify.Text = "Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(853, 552)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(110, 28)
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(316, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Sort / Select By:"
        '
        'cbosort
        '
        Me.cbosort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbosort.FormattingEnabled = True
        Me.cbosort.Location = New System.Drawing.Point(458, 136)
        Me.cbosort.Name = "cbosort"
        Me.cbosort.Size = New System.Drawing.Size(141, 28)
        Me.cbosort.TabIndex = 1
        '
        'FoodBindingSource
        '
        Me.FoodBindingSource.DataMember = "Food"
        Me.FoodBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'FoodTableAdapter
        '
        Me.FoodTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.FoodTableAdapter = Me.FoodTableAdapter
        Me.TableAdapterManager.MemberTableAdapter = Me.MemberTableAdapter
        Me.TableAdapterManager.MovieTableAdapter = Me.MovieTableAdapter
        Me.TableAdapterManager.RoomTableAdapter = Me.RoomTableAdapter
        Me.TableAdapterManager.SeatTableAdapter = Me.SeatTableAdapter
        Me.TableAdapterManager.ShowTimeTableAdapter = Me.ShowTimeTableAdapter
        Me.TableAdapterManager.StaffTableAdapter = Me.StaffTableAdapter
        Me.TableAdapterManager.TransactionTableAdapter = Me.TransactionTableAdapter
        Me.TableAdapterManager.UpdateOrder = Cinema_Ticketing_System.DB_CinemaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'MemberTableAdapter
        '
        Me.MemberTableAdapter.ClearBeforeFill = True
        '
        'MovieTableAdapter
        '
        Me.MovieTableAdapter.ClearBeforeFill = True
        '
        'RoomTableAdapter
        '
        Me.RoomTableAdapter.ClearBeforeFill = True
        '
        'SeatTableAdapter
        '
        Me.SeatTableAdapter.ClearBeforeFill = True
        '
        'ShowTimeTableAdapter
        '
        Me.ShowTimeTableAdapter.ClearBeforeFill = True
        '
        'StaffTableAdapter
        '
        Me.StaffTableAdapter.ClearBeforeFill = True
        '
        'TransactionTableAdapter
        '
        Me.TransactionTableAdapter.ClearBeforeFill = True
        '
        'MemberBindingSource
        '
        Me.MemberBindingSource.DataMember = "Member"
        Me.MemberBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'MovieBindingSource
        '
        Me.MovieBindingSource.DataMember = "Movie"
        Me.MovieBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'RoomBindingSource
        '
        Me.RoomBindingSource.DataMember = "Room"
        Me.RoomBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'SeatBindingSource
        '
        Me.SeatBindingSource.DataMember = "Seat"
        Me.SeatBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'ShowTimeBindingSource
        '
        Me.ShowTimeBindingSource.DataMember = "ShowTime"
        Me.ShowTimeBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'StaffBindingSource
        '
        Me.StaffBindingSource.DataMember = "Staff"
        Me.StaffBindingSource.DataSource = Me.DB_CinemaDataSet
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(617, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 23)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Direction :"
        '
        'cboDirection
        '
        Me.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDirection.FormattingEnabled = True
        Me.cboDirection.Items.AddRange(New Object() {"Ascending", "Descending"})
        Me.cboDirection.Location = New System.Drawing.Point(720, 136)
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.Size = New System.Drawing.Size(122, 28)
        Me.cboDirection.TabIndex = 2
        '
        'Data_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1248, 606)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblBigName)
        Me.Controls.Add(Me.picBigPicture)
        Me.Controls.Add(Me.cboDirection)
        Me.Controls.Add(Me.cbosort)
        Me.Controls.Add(Me.cboType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Data_Control"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picBigPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_CinemaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FoodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MovieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RoomBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShowTimeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StaffBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboType As ComboBox
    Friend WithEvents lblBigName As Label
    Friend WithEvents picBigPicture As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnsearch As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnModify As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbosort As ComboBox
    Friend WithEvents DB_CinemaDataSet As DB_CinemaDataSet
    Friend WithEvents FoodBindingSource As BindingSource
    Friend WithEvents FoodTableAdapter As DB_CinemaDataSetTableAdapters.FoodTableAdapter
    Friend WithEvents TableAdapterManager As DB_CinemaDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridView As DataGridView
    Friend WithEvents MemberTableAdapter As DB_CinemaDataSetTableAdapters.MemberTableAdapter
    Friend WithEvents MemberBindingSource As BindingSource
    Friend WithEvents MovieTableAdapter As DB_CinemaDataSetTableAdapters.MovieTableAdapter
    Friend WithEvents MovieBindingSource As BindingSource
    Friend WithEvents RoomTableAdapter As DB_CinemaDataSetTableAdapters.RoomTableAdapter
    Friend WithEvents RoomBindingSource As BindingSource
    Friend WithEvents SeatTableAdapter As DB_CinemaDataSetTableAdapters.SeatTableAdapter
    Friend WithEvents SeatBindingSource As BindingSource
    Friend WithEvents ShowTimeTableAdapter As DB_CinemaDataSetTableAdapters.ShowTimeTableAdapter
    Friend WithEvents ShowTimeBindingSource As BindingSource
    Friend WithEvents StaffTableAdapter As DB_CinemaDataSetTableAdapters.StaffTableAdapter
    Friend WithEvents StaffBindingSource As BindingSource
    Friend WithEvents TransactionTableAdapter As DB_CinemaDataSetTableAdapters.TransactionTableAdapter
    Friend WithEvents TransactionBindingSource As BindingSource
    Friend WithEvents Label4 As Label
    Friend WithEvents cboDirection As ComboBox
End Class
