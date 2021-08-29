Public Class Modify_Member
    Public Structure Member
        Dim ID As String
        Dim name As String
        Dim email As String
        Dim number As String
        Dim dob As Date
    End Structure

    Friend selectMember As Member

    Private updateMember As Member

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Modify_Member_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMemberID.Text = selectMember.ID
        txtUser.Text = selectMember.name
        txtEmail.Text = selectMember.email
        mskPhone.Text = selectMember.number
        mskBirthday.Text = selectMember.dob.ToString("MM/dd/yyyy")
    End Sub



    Private Function ValidatingInput() As Boolean
        If txtUser.Text = "" And txtEmail.Text = "" And mskPhone.Text.Length < 11 And mskBirthday.Text.Length < 10 Then
            MessageBox.Show("Please fill in the necessary information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub updateAndSave()
        If ValidatingInput() Then
            If MessageBox.Show("Do you to update this member [" & selectMember.ID & "] information?", "Modify information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                updateMember.name = txtUser.Text
                updateMember.email = txtEmail.Text
                updateMember.number = mskPhone.Text
                updateMember.dob = mskBirthday.Text
                Data_Control.DB_CinemaDataSet.Member.Rows(Data_Control.row).Item(1) = updateMember.name
                Data_Control.DB_CinemaDataSet.Member.Rows(Data_Control.row).Item(2) = updateMember.email
                Data_Control.DB_CinemaDataSet.Member.Rows(Data_Control.row).Item(4) = updateMember.number
                Data_Control.DB_CinemaDataSet.Member.Rows(Data_Control.row).Item(3) = updateMember.dob
                Data_Control.MemberTableAdapter.Update(Data_Control.DB_CinemaDataSet)
                MessageBox.Show("This member information has been updated.", "Modify information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()
            End If
        End If

    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        updateAndSave()
    End Sub
End Class