Public Class Modify_Food
    Public Structure Food
        Dim ID As String
        Dim name As String
        Dim desc As String
        Dim price As Decimal
        Dim picLocation As String
    End Structure

    Friend selectFood As Food
    Friend updateFood As Food

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Modify_Food_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFoodID.Text = selectFood.ID
        txtFoodName.Text = selectFood.name
        txtFoodDescription.Text = selectFood.desc
        msktxtFoodPrice.Text = selectFood.price
        picFood.Load(selectFood.picLocation)
    End Sub

    Private Function ValidatingInput() As Boolean
        If txtFoodName.Text = "" And txtFoodDescription.Text = "" And msktxtFoodPrice.Text.Length < 4 Then
            MessageBox.Show("Please fill in the necessary information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If picFood.ImageLocation = "" Then
            MessageBox.Show("Please put the image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub updateAndSave()
        If ValidatingInput() Then
            If MessageBox.Show("Do you to update this food [" & selectFood.ID & "] information?", "Modify information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                updateFood.name = txtFoodName.Text
                updateFood.desc = txtFoodDescription.Text
                updateFood.price = msktxtFoodPrice.Text
                updateFood.picLocation = picFood.ImageLocation
                Data_Control.DB_CinemaDataSet.Food.Rows(Data_Control.row).Item(1) = updateFood.name
                Data_Control.DB_CinemaDataSet.Food.Rows(Data_Control.row).Item(2) = updateFood.desc
                Data_Control.DB_CinemaDataSet.Food.Rows(Data_Control.row).Item(3) = updateFood.price
                Data_Control.DB_CinemaDataSet.Food.Rows(Data_Control.row).Item(4) = 0
                Data_Control.DB_CinemaDataSet.Food.Rows(Data_Control.row).Item(5) = updateFood.picLocation
                Data_Control.FoodTableAdapter.Update(Data_Control.DB_CinemaDataSet)
                MessageBox.Show("This food information has been updated.", "Modify information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()
            End If
        End If

    End Sub



    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If filePic.ShowDialog = DialogResult.OK Then
            picFood.Load(System.IO.Path.GetFullPath(filePic.FileName))
        End If
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        updateAndSave()
    End Sub
End Class