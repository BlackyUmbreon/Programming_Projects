Public Class Modify_Staff
    Public Structure Staff
        Dim ID, name, email, password, position, status As String
    End Structure

    Friend selectStaff As Staff
    Private updateStaff As Staff

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Modify_Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStaffID.Text = selectStaff.ID
        txtUser.Text = selectStaff.name
        txtEmail.Text = selectStaff.email
        txtPassword.Text = selectStaff.password
        lblPosition.Text = selectStaff.position
        If selectStaff.status = "True" Then
            cboStatus.SelectedIndex = 0
        ElseIf selectStaff.status = "False" Then
            cboStatus.SelectedIndex = 1
        End If
    End Sub

    Private Function ValidatingInput() As Boolean
        If txtUser.Text = "" And txtPassword.Text = "" And txtEmail.Text = "" Then
            MessageBox.Show("Please fill in the necessary information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub updateAndSave()
        If ValidatingInput() Then
            If MessageBox.Show("Do you to update this staff [" & selectStaff.ID & "] information?", "Modify information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                updateStaff.name = txtUser.Text
                updateStaff.email = txtEmail.Text
                updateStaff.password = txtPassword.Text
                updateStaff.position = lblPosition.Text
                updateStaff.status = cboStatus.SelectedItem
                Data_Control.DB_CinemaDataSet.Staff.Rows(Data_Control.row).Item(1) = updateStaff.name
                Data_Control.DB_CinemaDataSet.Staff.Rows(Data_Control.row).Item(2) = updateStaff.email
                Data_Control.DB_CinemaDataSet.Staff.Rows(Data_Control.row).Item(3) = updateStaff.password
                Data_Control.DB_CinemaDataSet.Staff.Rows(Data_Control.row).Item(4) = updateStaff.position
                Data_Control.DB_CinemaDataSet.Staff.Rows(Data_Control.row).Item(5) = updateStaff.status
                Data_Control.StaffTableAdapter.Update(Data_Control.DB_CinemaDataSet)
                MessageBox.Show("This staff information has been updated.", "Modify information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()
            End If
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        updateAndSave()
    End Sub
End Class