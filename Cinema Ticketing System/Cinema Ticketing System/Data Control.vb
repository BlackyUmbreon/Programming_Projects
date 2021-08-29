Public Class Data_Control
    Friend row As Integer

    Private Sub FoodBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FoodBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DB_CinemaDataSet)

    End Sub

    Private Sub Data_Control_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FoodTableAdapter.Fill(DB_CinemaDataSet.Food)
        MemberTableAdapter.Fill(DB_CinemaDataSet.Member)
        MovieTableAdapter.Fill(DB_CinemaDataSet.Movie)
        RoomTableAdapter.Fill(DB_CinemaDataSet.Room)
        SeatTableAdapter.Fill(DB_CinemaDataSet.Seat)
        ShowTimeTableAdapter.Fill(DB_CinemaDataSet.ShowTime)
        StaffTableAdapter.Fill(DB_CinemaDataSet.Staff)
        TransactionTableAdapter.Fill(DB_CinemaDataSet.Transaction)
        Dim i As Integer = 0
        cboType.Items.Clear()
        For i = 0 To DB_CinemaDataSet.Tables.Count - 1 Step 1
            cboType.Items.Add(DB_CinemaDataSet.Tables(i).TableName)
        Next
        cboType.SelectedIndex = 0

    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        Dim sets() As BindingSource
        sets = {FoodBindingSource, MemberBindingSource, MovieBindingSource, RoomBindingSource, SeatBindingSource, ShowTimeBindingSource, StaffBindingSource, TransactionBindingSource}
        Dim type As Integer = cboType.SelectedIndex
        DataGridView.DataSource = Nothing
        DataGridView.DataSource = sets(type)

        cbosort.Items.Clear()
        Dim i As Integer
        For i = 0 To DataGridView.Columns.GetColumnCount(DataGridViewElementStates.Visible) - 1 Step 1
            cbosort.Items.Add(DataGridView.Columns(i).Name)
        Next

        cbosort.SelectedIndex = 0
        cboDirection.SelectedIndex = 0

        If Not cboType.SelectedIndex = 1 And Not cboType.SelectedIndex = 6 Then
            btnAdd.Enabled = False
            btnRemove.Enabled = False
        Else
            btnAdd.Enabled = True
            btnRemove.Enabled = True
        End If

        If Not cboType.SelectedIndex = 3 And Not cboType.SelectedIndex = 4 And Not cboType.SelectedIndex = 7 Then
            btnModify.Enabled = True
        Else
            btnModify.Enabled = False
        End If
    End Sub

    Private Sub Data_Control_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Home.Show()
    End Sub

    Private Sub cbosort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosort.SelectedIndexChanged, cboDirection.SelectedIndexChanged
        Dim sort As Integer = cbosort.SelectedIndex

        If cboDirection.SelectedIndex = 0 Then
            DataGridView.Sort(DataGridView.Columns(sort), System.ComponentModel.ListSortDirection.Ascending)
        ElseIf cboDirection.SelectedIndex = 1 Then
            DataGridView.Sort(DataGridView.Columns(sort), System.ComponentModel.ListSortDirection.Descending)
        End If

    End Sub

    Private Sub DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick
        DataGridView.CurrentRow.Selected = True
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Dim type As String = cboType.SelectedItem
        row = DataGridView.SelectedRows.Item(0).Index
        Select Case type
            Case "Food"
                Modify_Food.selectFood.ID = DataGridView(0, row).Value
                Modify_Food.selectFood.name = DataGridView(1, row).Value
                Modify_Food.selectFood.desc = DataGridView(2, row).Value
                Modify_Food.selectFood.price = DataGridView(3, row).Value
                Modify_Food.selectFood.picLocation = DataGridView(5, row).Value
                Modify_Food.Show()
            Case "Member"
                Modify_Member.selectMember.ID = DataGridView(0, row).Value
                Modify_Member.selectMember.name = DataGridView(1, row).Value
                Modify_Member.selectMember.email = DataGridView(2, row).Value
                Modify_Member.selectMember.number = DataGridView(4, row).Value
                Modify_Member.selectMember.dob = DataGridView(3, row).Value
                Modify_Member.Show()
            Case "Movie"
                Modify_Movie.selectMovie.ID = DataGridView(0, row).Value
                Modify_Movie.selectMovie.Title = DataGridView(1, row).Value
                Modify_Movie.selectMovie.desc = DataGridView(2, row).Value
                Modify_Movie.selectMovie.picLocation = DataGridView(3, row).Value
                Modify_Movie.selectMovie.descPic = DataGridView(4, row).Value
                Modify_Movie.Show()
            Case "ShowTime"
                Modify_Show_TIme.selectShowTime.ID = DataGridView(0, row).Value
                Modify_Show_TIme.selectShowTime.time = DataGridView(1, row).Value
                Modify_Show_TIme.Show()
            Case "Staff"
                Modify_Staff.selectStaff.ID = DataGridView(0, row).Value
                Modify_Staff.selectStaff.name = DataGridView(1, row).Value
                Modify_Staff.selectStaff.email = DataGridView(2, row).Value
                Modify_Staff.selectStaff.password = DataGridView(3, row).Value
                Modify_Staff.selectStaff.position = DataGridView(4, row).Value
                Modify_Staff.selectStaff.status = DataGridView(5, row).Value
                Modify_Staff.Show()
        End Select


    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim idSearch As String = txtID.Text
        Dim sqlconn As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\Assignment\Cinema Ticketing System\Cinema Ticketing System\DB Cinema.mdf;Integrated Security=True")
        sqlconn.Open()
        Dim cmd As SqlClient.SqlCommand
        Dim sqlQuery As String = "Select * From [" & cboType.SelectedItem.ToString & "] Where " & cbosort.SelectedItem & " like '%" & idSearch & "%'"
        cmd = New SqlClient.SqlCommand(sqlQuery, sqlconn)

        Dim adpt As New SqlClient.SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adpt.Fill(table)
        DataGridView.DataSource = table
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim type As String = cboType.SelectedItem
        Dim i As Integer = 0
        Select Case type
            Case "Member"
                For i = 0 To DB_CinemaDataSet.Member.Rows.Count - 1
                    If Member_Registration.count < CInt(DB_CinemaDataSet.Member.Rows(i).Item(0).ToString.Substring(1, 3)) Then
                        Member_Registration.count = CInt(DB_CinemaDataSet.Member.Rows(i).Item(0).ToString.Substring(1, 3))
                    End If
                Next
                Member_Registration.Show()
            Case "Staff"
                For i = 0 To DB_CinemaDataSet.Staff.Rows.Count - 1
                    If Add_staff.count < CInt(DB_CinemaDataSet.Staff.Rows(i).Item(0).ToString.Substring(2, 3)) Then
                        Add_staff.count = CInt(DB_CinemaDataSet.Staff.Rows(i).Item(0).ToString.Substring(2, 3))
                    End If
                Next
                Add_staff.Show()
        End Select
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim type As String = cboType.SelectedItem
        row = DataGridView.SelectedRows.Item(0).Index

        Select Case type
            Case "Member"
                If MessageBox.Show("Do you want to Delete this member [" & DB_CinemaDataSet.Member.Rows(row).Item(0) & "] ?", "Delete Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    MessageBox.Show("The member [" & DB_CinemaDataSet.Member.Rows(row).Item(0) & "] had been removed ?", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MemberBindingSource.RemoveAt(row)
                    MemberTableAdapter.Update(DB_CinemaDataSet.Member)
                    MemberBindingSource.EndEdit()
                End If
            Case "Staff"
                If MessageBox.Show("Do you want to Delete this staff [" & DB_CinemaDataSet.Staff.Rows(row).Item(0) & "] ?", "Delete Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    MessageBox.Show("The member [" & DB_CinemaDataSet.Staff.Rows(row).Item(0) & "] had been removed ?", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    StaffBindingSource.RemoveAt(row)
                    StaffTableAdapter.Update(DB_CinemaDataSet.Staff)
                    StaffBindingSource.EndEdit()
                End If
        End Select
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
