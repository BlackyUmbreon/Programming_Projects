Public Class Home_Movie_Detail
    Dim move As Boolean = False
    Dim locX, locY As Integer

    Friend movieSelect As Home.Movie
    Friend roomMovie(1) As Home.Room
    Friend type As String

    Private Sub picClose_MouseHover(sender As Object, e As EventArgs) Handles picClose.MouseHover
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\CloseHover.png")
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Close.png")
    End Sub

    Private Sub pnlTop_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTop.MouseDown
        move = True
        locX = Windows.Forms.Cursor.Position.X - Me.Left
        locY = Windows.Forms.Cursor.Position.Y - Me.Top
        Me.Cursor = Cursors.NoMove2D
    End Sub

    Private Sub pnlTop_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTop.MouseUp
        move = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub picMinimize_Click(sender As Object, e As EventArgs) Handles picMinimize.Click
        Me.Windowstate = FormWindowState.Minimized
        picMinimize.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Minimize.png")
    End Sub

    Private Sub pnlTop_Move(sender As Object, e As EventArgs) Handles pnlTop.MouseMove
        If move Then
            Me.Left = Windows.Forms.Cursor.Position.X - locX
            Me.Top = Windows.Forms.Cursor.Position.Y - locY
        End If
    End Sub

    Private Sub picMinimize_MouseHover(sender As Object, e As EventArgs) Handles picMinimize.MouseHover
        picMinimize.Load("C:\Users\user\Desktop\Assignment\Picture\basic\MinimizeHover.png")
    End Sub

    Private Sub picMinimize_MouseLeave(sender As Object, e As EventArgs) Handles picMinimize.MouseLeave
        picMinimize.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Minimize.png")
    End Sub

    Private Sub MnuMove_Click(sender As Object, e As EventArgs) Handles MnuMove.Click
        Cursor.Position = Me.PointToscreen(New Point((pnlTop.Right + pnlTop.Left) / 2, (pnlTop.Top + pnlTop.Bottom) / 2))
    End Sub

    Private Sub MnuMinimize_Click(sender As Object, e As EventArgs) Handles MnuMinimize.Click
        Me.Windowstate = FormWindowState.Minimized
    End Sub

    Private Sub lblData_MouseHover(sender As Object, e As EventArgs) Handles lblData.MouseHover
        lblData.ForeColor = Color.Yellow
        picData.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Data Hover.png")
    End Sub

    Private Sub lblData_MouseLeave(sender As Object, e As EventArgs) Handles lblData.MouseLeave
        lblData.ForeColor = Color.White
        picData.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Data.png")
    End Sub

    Private Sub lblsales_MouseHover(sender As Object, e As EventArgs) Handles lblsales.MouseHover
        lblsales.ForeColor = Color.Yellow
        picsales.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\sales Hover.png")
    End Sub

    Private Sub lblsales_MouseLeave(sender As Object, e As EventArgs) Handles lblsales.MouseLeave
        lblsales.ForeColor = Color.White
        picsales.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\sales.png")
    End Sub

    Private Sub lblLogOut_MouseHover(sender As Object, e As EventArgs) Handles lblLogOut.MouseHover
        lblLogOut.ForeColor = Color.Yellow
        picLogOut.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Logout Hover.png")
    End Sub

    Private Sub lblLogOut_MouseLeave(sender As Object, e As EventArgs) Handles lblLogOut.MouseLeave
        lblLogOut.ForeColor = Color.White
        picLogOut.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Logout.png")
    End Sub

    Private Sub lblHome_MouseHover(sender As Object, e As EventArgs) Handles lblHome.MouseHover
        lblHome.ForeColor = Color.Yellow
        picHome.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\HomeHover.png")
    End Sub

    Private Sub lblHome_MouseLeave(sender As Object, e As EventArgs) Handles lblHome.MouseLeave
        lblHome.ForeColor = Color.White
        picHome.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Home.png")
    End Sub

    Private Sub btnBack_Down(sender As Object, e As EventArgs) Handles btnBack.MouseDown
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnBack_Up(sender As Object, e As EventArgs) Handles btnBack.MouseUp
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub Home_Movie_Detail_Load(sender As Object, e As EventArgs) Handles Me.Load
        movieInitialize()
        showTimeInitialize()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click, picClose.Click, lblHome.Click
        Home.Show()
        Me.Close()
    End Sub

    Private Sub chkVIP_CheckedChanged(sender As Object, e As EventArgs) Handles chkVIP.CheckedChanged
        If chkVIP.Checked Then
            btnTime5.Visible = True
        Else
            btnTime5.Visible = False
        End If
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
        Reserve_Step_1___STD__.orderMovie = New Reserve_Step_1___STD__.Order
        ReDim Reserve_Step_1___STD__.orderMovie.room.showTime(0)
        Reserve_Step_1___STD__.orderMovie.room.ID = roomMovie(0).ID
        Reserve_Step_1___STD__.orderMovie.room.type = roomMovie(0).type
        Reserve_Step_1___STD__.orderMovie.room.showTime(0) = roomMovie(0).showTime(2)
        Reserve_Step_1___STD__.orderMovie.movieSelect = movieSelect
        Reserve_Step_1___STD__.orderMovie.staffID = Home_Log_in.staffID
        Reserve_Step_1___STD__.orderMovie.memberID = "Guest"
        Reserve_Step_1___STD__.Show()
        type = "Standard"
        Me.Hide()
    End Sub

    Private Sub btnTime5_Click(sender As Object, e As EventArgs) Handles btnTime5.Click
        Reserve_Step_1___VIP__.orderMovie = New Reserve_Step_1___STD__.Order
        ReDim Reserve_Step_1___VIP__.orderMovie.room.showTime(1)
        Reserve_Step_1___VIP__.orderMovie.room.ID = roomMovie(1).ID
        Reserve_Step_1___VIP__.orderMovie.room.type = roomMovie(1).type
        Reserve_Step_1___VIP__.orderMovie.room.showTime(0) = roomMovie(1).showTime(0)
        Reserve_Step_1___VIP__.orderMovie.movieSelect = movieSelect
        Reserve_Step_1___VIP__.orderMovie.staffID = Home_Log_in.staffID
        Reserve_Step_1___VIP__.orderMovie.memberID = "Guest"
        Reserve_Step_1___VIP__.Show()
        type = "VIP"
        Me.Hide()
    End Sub

    Private Sub btnTime4_Click(sender As Object, e As EventArgs) Handles btnTime4.Click
        Reserve_Step_1___STD__.orderMovie = New Reserve_Step_1___STD__.Order
        ReDim Reserve_Step_1___STD__.orderMovie.room.showTime(0)
        Reserve_Step_1___STD__.orderMovie.room.ID = roomMovie(0).ID
        Reserve_Step_1___STD__.orderMovie.room.type = roomMovie(0).type
        Reserve_Step_1___STD__.orderMovie.room.showTime(0) = roomMovie(0).showTime(3)
        Reserve_Step_1___STD__.orderMovie.movieSelect = movieSelect
        Reserve_Step_1___STD__.orderMovie.staffID = Home_Log_in.staffID
        Reserve_Step_1___STD__.orderMovie.memberID = "Guest"
        Reserve_Step_1___STD__.Show()
        type = "Standard"
        Me.Hide()
    End Sub

    Private Sub btnTime2_Click(sender As Object, e As EventArgs) Handles btnTime2.Click
        Reserve_Step_1___STD__.orderMovie = New Reserve_Step_1___STD__.Order
        ReDim Reserve_Step_1___STD__.orderMovie.room.showTime(0)
        Reserve_Step_1___STD__.orderMovie.room.ID = roomMovie(0).ID
        Reserve_Step_1___STD__.orderMovie.room.type = roomMovie(0).type
        Reserve_Step_1___STD__.orderMovie.room.showTime(0) = roomMovie(0).showTime(1)
        Reserve_Step_1___STD__.orderMovie.movieSelect = movieSelect
        Reserve_Step_1___STD__.orderMovie.staffID = Home_Log_in.staffID
        Reserve_Step_1___STD__.orderMovie.memberID = "Guest"
        Reserve_Step_1___STD__.Show()
        type = "Standard"
        Me.Hide()
    End Sub

    Private Sub btnTime1_Click(sender As Object, e As EventArgs) Handles btnTime1.Click
        Reserve_Step_1___STD__.orderMovie = New Reserve_Step_1___STD__.Order
        ReDim Reserve_Step_1___STD__.orderMovie.room.showTime(0)
        Reserve_Step_1___STD__.orderMovie.room.ID = roomMovie(0).ID
        Reserve_Step_1___STD__.orderMovie.room.type = roomMovie(0).type
        Reserve_Step_1___STD__.orderMovie.room.showTime(0) = roomMovie(0).showTime(0)
        Reserve_Step_1___STD__.orderMovie.movieSelect = movieSelect
        Reserve_Step_1___STD__.orderMovie.staffID = Home_Log_in.staffID
        Reserve_Step_1___STD__.orderMovie.memberID = "Guest"
        Reserve_Step_1___STD__.Show()
        type = "Standard"
        Me.Hide()
    End Sub

    Private Sub btnTime5_Up(sender As Object, e As EventArgs) Handles btnTime5.MouseUp
        btnTime5.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\buttonVIPUp.jpg")
    End Sub
End Class
