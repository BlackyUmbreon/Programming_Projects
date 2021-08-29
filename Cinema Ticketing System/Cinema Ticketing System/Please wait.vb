Public Class Please_wait
    Dim wait As Integer
    Private Sub Please_wait_Load(sender As Object, e As EventArgs) Handles Me.Load
        wait = 0
        tmWait.Start()
    End Sub

    Private Sub tmWait_Tick(sender As Object, e As EventArgs) Handles tmWait.Tick
        wait += 1
        lblWait.Text = lblWait.Text & "."

        If wait > 8 Then
            Me.Close()
            tmWait.Stop()
        End If
    End Sub
End Class