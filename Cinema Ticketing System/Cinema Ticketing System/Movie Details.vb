Public Class Movie_Details

    Friend movieSelect As KioskHome.Movie
    Friend roomMovie(1) As KioskHome.Room
    Friend type As String
    Friend index As Integer

    Private Sub btnBack_Down(sender As Object, e As EventArgs) Handles btnBack.MouseDown
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnBack_Up(sender As Object, e As EventArgs) Handles btnBack.MouseUp
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        KioskHome.movieInitialize()
        KioskHome.Show()
    End Sub

    Private Sub Home_Movie_Detail_Load(sender As Object, e As EventArgs) Handles Me.Load
        movieInitialize()
        showTimeInitialize()
    End Sub

    Private Sub movieInitialize()
        pnlMovie.BackgroundImage = Image.FromFile(movieSelect.bigpiclocation)
        lblTItle.Text = movieSelect.title
        lblDescription.Text = movieSelect.description
    End Sub

    Private Sub showTimeInitialize()
        btnTime1.Text = roomMovie(0).showTime(0).time
        btnTime2.Text = roomMovie(0).showTime(1).time
        btnTime3.Text = roomMovie(0).showTime(2).time
        btnTime4.Text = roomMovie(0).showTime(3).time
        btnTime5.Text = roomMovie(1).showTime(0).time
    End Sub

    Private Sub chkVIP_CheckedChanged(sender As Object, e As EventArgs) Handles chkVIP.CheckedChanged
        If chkVIP.Checked Then
            btnTime5.Visible = True
        Else
            btnTime5.Visible = False
        End If
    End Sub

    Private Sub btnTime1_Down(sender As Object, e As EventArgs) Handles btnTime1.MouseDown
        btnTime1.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnTime1_Up(sender As Object, e As EventArgs) Handles btnTime1.MouseUp
        btnTime1.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnTime2_Down(sender As Object, e As EventArgs) Handles btnTime2.MouseDown
        btnTime2.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnTime2_Up(sender As Object, e As EventArgs) Handles btnTime2.MouseUp
        btnTime2.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnTime3_Down(sender As Object, e As EventArgs) Handles btnTime3.MouseDown
        btnTime3.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnTime3_Up(sender As Object, e As EventArgs) Handles btnTime3.MouseUp
        btnTime3.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnTime4_Down(sender As Object, e As EventArgs) Handles btnTime4.MouseDown
        btnTime4.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnTime4_Up(sender As Object, e As EventArgs) Handles btnTime4.MouseUp
        btnTime4.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnTime5_Down(sender As Object, e As EventArgs) Handles btnTime5.MouseDown
        btnTime5.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\buttonVIPDown.jpg")
    End Sub

    Private Sub btnTime3_Click(sender As Object, e As EventArgs) Handles btnTime3.Click
        Index = 3
        Kiosk_Member.Show()

    End Sub

    Private Sub btnTime5_Click(sender As Object, e As EventArgs) Handles btnTime5.Click
        Index = 5
        Kiosk_Member.Show()
    End Sub

    Private Sub btnTime4_Click(sender As Object, e As EventArgs) Handles btnTime4.Click
        Index = 4
        Kiosk_Member.Show()
    End Sub

    Private Sub btnTime2_Click(sender As Object, e As EventArgs) Handles btnTime2.Click
        Index = 2
        Kiosk_Member.Show()
    End Sub

    Private Sub btnTime1_Click(sender As Object, e As EventArgs) Handles btnTime1.Click
        Index = 1
        Kiosk_Member.Show()
    End Sub

    Private Sub btnTime5_Up(sender As Object, e As EventArgs) Handles btnTime5.MouseUp
        btnTime5.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\buttonVIPUp.jpg")
    End Sub
End Class