Public Class Kiosk_Splash
    Dim sec As Integer = 0
    Private Sub Kiosk_Splash_Load(sender As Object, e As EventArgs) Handles Me.Load
        sec = 0
        tmSplash.Start()
    End Sub

    Private Sub tmSplash_Tick(sender As Object, e As EventArgs) Handles tmSplash.Tick
        sec += 1

        If sec > 2 Then
            tmSplash.Stop()
            Me.Close()
            KioskHome.Show()
        End If
    End Sub
End Class