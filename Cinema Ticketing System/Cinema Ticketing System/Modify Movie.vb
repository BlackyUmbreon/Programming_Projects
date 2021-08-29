Public Class Modify_Movie
    Public Structure Movie
        Dim ID, Title, desc, descPic, picLocation As String
    End Structure

    Friend selectMovie As Movie
    Private updateMovie As Movie

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If FileBrowse.ShowDialog() = DialogResult.OK Then
            picMovie.Load(System.IO.Path.GetFullPath(FileBrowse.FileName))
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Modify_Movie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMovieID.Text = selectMovie.ID
        txtTitle.Text = selectMovie.Title
        txtDescription.Text = selectMovie.desc
        lblBigLocation.Text = selectMovie.descPic
        picMovie.Load(selectMovie.picLocation)
    End Sub

    Private Function ValidatingInput() As Boolean
        If txtTitle.Text = "" And txtDescription.Text = "" And lblBigLocation.Text = "" Then
            MessageBox.Show("Please fill in the necessary information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If picMovie.ImageLocation = "" Then
            MessageBox.Show("Please put the image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub updateAndSave()
        If ValidatingInput() Then
            If MessageBox.Show("Do you to update this movie [" & selectMovie.ID & "] information?", "Modify information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                updateMovie.Title = txtTitle.Text
                updateMovie.desc = txtDescription.Text
                updateMovie.descPic = lblBigLocation.Text
                updateMovie.picLocation = picMovie.ImageLocation
                Data_Control.DB_CinemaDataSet.Movie.Rows(Data_Control.row).Item(1) = updateMovie.Title
                Data_Control.DB_CinemaDataSet.Movie.Rows(Data_Control.row).Item(2) = updateMovie.desc
                Data_Control.DB_CinemaDataSet.Movie.Rows(Data_Control.row).Item(4) = updateMovie.descPic
                Data_Control.DB_CinemaDataSet.Movie.Rows(Data_Control.row).Item(3) = updateMovie.picLocation
                Data_Control.MovieTableAdapter.Update(Data_Control.DB_CinemaDataSet)
                MessageBox.Show("This movie information has been updated.", "Modify information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()
            End If
        End If

    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        updateAndSave()
    End Sub

    Private Sub btnBigBrowse_Click(sender As Object, e As EventArgs) Handles btnBigBrowse.Click
        If FileBrowse.ShowDialog() = DialogResult.OK Then
            lblBigLocation.Text = (System.IO.Path.GetFullPath(FileBrowse.FileName))
        End If
    End Sub
End Class