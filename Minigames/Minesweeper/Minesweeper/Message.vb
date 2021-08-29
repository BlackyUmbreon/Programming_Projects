Public Class Message
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
        Easy.btnReset.Focus()
    End Sub
End Class