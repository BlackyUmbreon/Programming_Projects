Public Class Add_staff
    Friend count As Integer
    Friend newStaff As Modify_Staff.Staff

    Private Sub Add_staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboPosition.SelectedIndex = 0
        txtEmail.ResetText()
        txtPassword.ResetText()
        txtUser.ResetText()
    End Sub

    Private Sub cboPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPosition.SelectedIndexChanged
        Dim ID As String = ""

        If cboPosition.SelectedIndex = 0 Then
            If count > 0 And count < 9 Then
                ID = "NS00" & (count + 1)
            ElseIf count >= 9 And count < 99 Then
                ID = "NS0" & (count + 1)
            ElseIf count >= 99 And count < 999 Then
                ID = "NS" & (count + 1)
            End If
        ElseIf cboPosition.SelectedIndex = 1 Then
            If count > 0 And count < 9 Then
                ID = "HS00" & (count + 1)
            ElseIf count >= 9 And count < 99 Then
                ID = "HS0" & (count + 1)
            ElseIf count >= 99 And count < 999 Then
                ID = "HS" & (count + 1)
            End If
        End If
        lblstaffID.Text = ID
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If ValidateInput() Then
            newStaff.ID = lblstaffID.Text
            If MessageBox.Show("Do you want to Add this new Staff [" & newStaff.ID & "] to Database?", "New Staff", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                newStaff.name = txtUser.Text
                newStaff.email = txtEmail.Text
                newStaff.password = txtPassword.Text
                If cboPosition.SelectedIndex = 0 Then
                    newStaff.position = "Normal"
                ElseIf cboPosition.SelectedIndex = 1 Then
                    newStaff.position = "High Management"
                End If

                With newStaff
                    Data_Control.StaffTableAdapter.Insert(.ID, .name, .email, .password, .position, "True")
                    Data_Control.StaffBindingSource.EndEdit()
                    Data_Control.StaffTableAdapter.Update(Data_Control.DB_CinemaDataSet.Staff)
                    Data_Control.StaffTableAdapter.Fill(Data_Control.DB_CinemaDataSet.Staff)
                    Data_Control.DataGridView.DataSource = Data_Control.StaffBindingSource
                End With

                MessageBox.Show("new Staff [" & newStaff.ID & "] Is Added", "New Staff", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()
            End If
        End If
    End Sub

    Private Function ValidateInput() As Boolean
        If txtUser.Text <> "" Then
            If txtEmail.Text <> "" Then
                If txtPassword.Text <> "" Then
                    Return True
                Else
                    MessageBox.Show("Please Enter Password", "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Else
                MessageBox.Show("Please Enter Email", "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("Please Enter Staff Name", "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return False
    End Function
End Class
