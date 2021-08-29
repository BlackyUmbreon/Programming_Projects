Public Class Kiosk_Member
    Private Sub lklblGuest_MouseHover(sender As Object, e As EventArgs) Handles lklblGuest.MouseHover
        lklblGuest.ForeColor = Color.DodgerBlue
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lklblGuest_MouseLeave(sender As Object, e As EventArgs) Handles lklblGuest.MouseLeave
        lklblGuest.ForeColor = Color.Yellow
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lklblGuest_MouseDown(sender As Object, e As EventArgs) Handles lklblGuest.MouseDown
        lklblGuest.ForeColor = Color.MediumPurple
    End Sub

    Private Sub lklblGuest_MouseUp(sender As Object, e As EventArgs) Handles lklblGuest.MouseUp
        lklblGuest.ForeColor = Color.DodgerBlue
    End Sub

    Private Function searchID() As Boolean
        Dim conn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\user\Desktop\Assignment\Cinema Ticketing System\Cinema Ticketing System\DB Cinema.mdf';Integrated Security=True"
        Dim strCommand As String = "Select * from Member where [id] ='" & txtCode.Text & "'"
        Dim sqlconn As New SqlClient.SqlConnection(conn)
        sqlconn.Open()
        Dim sqlcmd As New SqlClient.SqlCommand(strCommand, sqlconn)
        Dim adpt As New SqlClient.SqlDataAdapter(sqlcmd)
        Dim table As New DataTable
        adpt.Fill(table)
        If sqlcmd.ExecuteReader.Read Then
            Return True
        Else
            MessageBox.Show("You enter the Member ID doesn't Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
    End Function

    Private Sub lklblGuest_Click(sender As Object, e As EventArgs) Handles lklblGuest.Click
        Select Case Movie_Details.index
            Case 1
                Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(0)
                Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                Kiosk_Step_1__Standard_.orderMovie.memberID = "Guest"
                Kiosk_Step_1__Standard_.Show()
                Movie_Details.type = "Standard"
                Me.Close()
                Movie_Details.Hide()
            Case 2
                Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(1)
                Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                Kiosk_Step_1__Standard_.orderMovie.memberID = "Guest"
                Kiosk_Step_1__Standard_.Show()
                Movie_Details.type = "Standard"
                Me.Close()
                Movie_Details.Hide()
            Case 3
                Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(2)
                Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                Kiosk_Step_1__Standard_.orderMovie.memberID = "Guest"
                Kiosk_Step_1__Standard_.Show()
                Movie_Details.type = "Standard"
                Me.Close()
                Movie_Details.Hide()
            Case 4
                Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(3)
                Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                Kiosk_Step_1__Standard_.orderMovie.memberID = "Guest"
                Kiosk_Step_1__Standard_.Show()
                Movie_Details.type = "Standard"
                Me.Close()
                Movie_Details.Hide()
            Case 5
                Kiosk_Step_1___VIP__.orderMovie = New Kiosk_Step_1__Standard_.Order
                ReDim Kiosk_Step_1___VIP__.orderMovie.room.showTime(0)
                Kiosk_Step_1___VIP__.orderMovie.room.ID = Movie_Details.roomMovie(1).ID
                Kiosk_Step_1___VIP__.orderMovie.room.type = Movie_Details.roomMovie(1).type
                Kiosk_Step_1___VIP__.orderMovie.room.showTime(0) = Movie_Details.roomMovie(1).showTime(0)
                Kiosk_Step_1___VIP__.orderMovie.movieSelect = Movie_Details.movieSelect
                Kiosk_Step_1___VIP__.orderMovie.staffID = Home_Log_in.staffID
                Kiosk_Step_1___VIP__.orderMovie.memberID = "Guest"
                Kiosk_Step_1___VIP__.Show()
                Movie_Details.type = "VIP"
                Me.Close()
                Movie_Details.Hide()
        End Select
    End Sub

    Private Sub btnLogIn_Down(sender As Object, e As EventArgs) Handles btnLogIn.MouseDown
        btnLogIn.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnLogIn_Up(sender As Object, e As EventArgs) Handles btnLogIn.MouseUp
        btnLogIn.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        If searchID() Then

            Select Case Movie_Details.index
                Case 1
                    Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                    ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                    Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                    Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                    Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(0)
                    Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                    Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                    Kiosk_Step_1__Standard_.orderMovie.memberID = txtCode.Text
                    Kiosk_Step_1__Standard_.Show()
                    Movie_Details.type = "Standard"
                    Me.Close()
                    Movie_Details.Hide()
                Case 2
                    Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                    ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                    Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                    Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                    Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(1)
                    Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                    Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                    Kiosk_Step_1__Standard_.orderMovie.memberID = txtCode.Text
                    Kiosk_Step_1__Standard_.Show()
                    Movie_Details.type = "Standard"
                    Me.Close()
                Case 3
                    Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                    ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                    Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                    Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                    Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(2)
                    Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                    Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                    Kiosk_Step_1__Standard_.orderMovie.memberID = txtCode.Text
                    Kiosk_Step_1__Standard_.Show()
                    Movie_Details.type = "Standard"
                    Me.Close()
                    Movie_Details.Hide()
                Case 4
                    Kiosk_Step_1__Standard_.orderMovie = New Kiosk_Step_1__Standard_.Order
                    ReDim Kiosk_Step_1__Standard_.orderMovie.room.showTime(0)
                    Kiosk_Step_1__Standard_.orderMovie.room.ID = Movie_Details.roomMovie(0).ID
                    Kiosk_Step_1__Standard_.orderMovie.room.type = Movie_Details.roomMovie(0).type
                    Kiosk_Step_1__Standard_.orderMovie.room.showTime(0) = Movie_Details.roomMovie(0).showTime(3)
                    Kiosk_Step_1__Standard_.orderMovie.movieSelect = Movie_Details.movieSelect
                    Kiosk_Step_1__Standard_.orderMovie.staffID = Home_Log_in.staffID
                    Kiosk_Step_1__Standard_.orderMovie.memberID = txtCode.Text
                    Kiosk_Step_1__Standard_.Show()
                    Movie_Details.type = "Standard"
                    Me.Close()
                    Movie_Details.Hide()
                Case 5
                    Kiosk_Step_1___VIP__.orderMovie = New Kiosk_Step_1__Standard_.Order
                    ReDim Kiosk_Step_1___VIP__.orderMovie.room.showTime(0)
                    Kiosk_Step_1___VIP__.orderMovie.room.ID = Movie_Details.roomMovie(1).ID
                    Kiosk_Step_1___VIP__.orderMovie.room.type = Movie_Details.roomMovie(1).type
                    Kiosk_Step_1___VIP__.orderMovie.room.showTime(0) = Movie_Details.roomMovie(1).showTime(0)
                    Kiosk_Step_1___VIP__.orderMovie.movieSelect = Movie_Details.movieSelect
                    Kiosk_Step_1___VIP__.orderMovie.staffID = Home_Log_in.staffID
                    Kiosk_Step_1___VIP__.orderMovie.memberID = txtCode.Text
                    Kiosk_Step_1___VIP__.Show()
                    Movie_Details.type = "VIP"
                    Me.Close()
                    Movie_Details.Hide()
            End Select
        End If


    End Sub
End Class