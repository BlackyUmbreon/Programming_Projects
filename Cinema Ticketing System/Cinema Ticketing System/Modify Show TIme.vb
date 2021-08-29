Public Class Modify_Show_TIme
    Public Structure ShowTime
        Dim ID, time As String
    End Structure

    Friend selectShowTime As ShowTime
    Private updateShowTime As ShowTime

    Private Sub Modify_Show_TIme_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblshowtimeID.Text = selectShowTime.ID
        mskTime.Text = selectShowTime.time

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function ValidatingInput() As Boolean
        If mskTime.Text.Length < 5 Then
            MessageBox.Show("Please fill in the necessary information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub updateAndSave()
        If ValidatingInput() Then
            If MessageBox.Show("Do you to update this showtime [" & selectShowTime.ID & "] information?", "Modify information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                updateShowTime.time = mskTime.Text
                Data_Control.DB_CinemaDataSet.ShowTime.Rows(Data_Control.row).Item(1) = updateShowTime.time
                Data_Control.ShowTimeTableAdapter.Update(Data_Control.DB_CinemaDataSet)
                MessageBox.Show("This showtime information has been updated.", "Modify information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()
            End If
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        updateAndSave()
    End Sub
End Class