Public Class KioskHome

    Public Structure Seat
        Dim id As String
        Dim status As Boolean
        Dim type As String
    End Structure

    Public Structure ShowTime
        Dim seat() As Seat
        Dim time As String
    End Structure

    Public Structure Room
        Dim showTime() As ShowTime
        Dim type As String
        Dim ID As String
    End Structure

    Public Structure Movie
        Dim id As String
        Dim title, description As String
        Dim piclocation, bigpiclocation As String
    End Structure

    Friend rooms(13) As Room
    Friend movies(8) As Movie
    Dim MoviePoster(3) As Movie
    Dim slideNo As Integer = 0
    Private repeat As Boolean = False

    Private Sub picNext_MouseHover(sender As Object, e As EventArgs) Handles picNext.MouseHover
        picNext.Load("C:\Users\user\Desktop\Assignment\Picture\Home\Next Hover.png")
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picNext_MouseLeave(sender As Object, e As EventArgs) Handles picNext.MouseLeave
        picNext.Load("C:\Users\user\Desktop\Assignment\Picture\Home\Next.png")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub picBack_MouseHover(sender As Object, e As EventArgs) Handles picBack.MouseHover
        picBack.Load("C:\Users\user\Desktop\Assignment\Picture\Home\Back Hover.png")
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picBack_MouseLeave(sender As Object, e As EventArgs) Handles picBack.MouseLeave
        picBack.Load("C:\Users\user\Desktop\Assignment\Picture\Home\Back.png")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
        End
    End Sub

    Private Sub Kiosk_Home_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmDate.Start()
        Initialize()
        movieInitialize()
        lblDate.Text = TimeOfDay.ToString("hh:mm tt")
    End Sub

    Private Sub tmDate_Tick(sender As Object, e As EventArgs) Handles tmDate.Tick
        lblDate.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub Initialize()
        If repeat = True Then
            Return
        End If
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        RoomTableAdapter.Fill(DB_CinemaDataSet.Room)
        ShowTimeTableAdapter.Fill(DB_CinemaDataSet.ShowTime)
        SeatTableAdapter.Fill(DB_CinemaDataSet.Seat)

        For i = 0 To rooms.Length - 1 Step 1
            rooms(i).ID = DB_CinemaDataSet.Room.Rows(i).Item(0).ToString
            rooms(i).type = DB_CinemaDataSet.Room.Rows(i).Item(1).ToString
            If rooms(i).type = "Normal" Then
                ReDim rooms(i).showTime(3)
                j = 0
                k = 0
                For j = 0 To rooms(i).showTime.Length - 1 Step 1
                    rooms(i).showTime(j).time = DB_CinemaDataSet.ShowTime.Rows(j + 1).Item(1).ToString
                    ReDim rooms(i).showTime(j).seat(191)
                    For k = 0 To rooms(i).showTime(j).seat.Length - 1 Step 1
                        rooms(i).showTime(j).seat(k).id = DB_CinemaDataSet.Seat.Rows(k).Item(0).ToString
                        If DB_CinemaDataSet.Seat.Rows(k).Item(1).ToString().Equals("True ") Then
                            rooms(i).showTime(j).seat(k).status = DB_CinemaDataSet.Seat.Rows(k).Item(1).ToString.Substring(0, 4)
                        Else
                            rooms(i).showTime(j).seat(k).status = DB_CinemaDataSet.Seat.Rows(k).Item(1).ToString.Substring(0, 5)
                        End If
                        rooms(i).showTime(j).seat(k).type = DB_CinemaDataSet.Seat.Rows(k).Item(2).ToString
                    Next
                Next
            ElseIf rooms(i).type = "VIP" Then
                ReDim rooms(i).showTime(5)
                j = 0
                k = 0
                For j = 0 To rooms(i).showTime.Length - 1 Step 1
                    rooms(i).showTime(j).time = DB_CinemaDataSet.ShowTime.Rows(j).Item(1).ToString
                    ReDim rooms(i).showTime(j).seat(23)
                    For k = 0 To rooms(i).showTime(j).seat.Length - 1 Step 1
                        rooms(i).showTime(j).seat(k).id = DB_CinemaDataSet.Seat.Rows(k + 192).Item(0).ToString
                        If DB_CinemaDataSet.Seat.Rows(k + 192).Item(1).ToString().Equals("True ") Then
                            rooms(i).showTime(j).seat(k).status = DB_CinemaDataSet.Seat.Rows(k + 192).Item(1).ToString.Substring(0, 4)
                        Else
                            rooms(i).showTime(j).seat(k).status = DB_CinemaDataSet.Seat.Rows(k + 192).Item(1).ToString.Substring(0, 5)
                        End If
                        rooms(i).showTime(j).seat(k).type = DB_CinemaDataSet.Seat.Rows(192 + k).Item(2).ToString
                    Next
                Next
            End If
        Next
        repeat = True
    End Sub

    Public Sub movieInitialize()
        MovieTableAdapter.Fill(DB_CinemaDataSet.Movie)
        Dim i As Integer = 0
        For i = 0 To movies.Length - 1 Step 1
            movies(i).id = DB_CinemaDataSet.Movie.Rows(i).Item(0)
            movies(i).title = DB_CinemaDataSet.Movie.Rows(i).Item(1)
            movies(i).description = DB_CinemaDataSet.Movie.Rows(i).Item(2)
            movies(i).piclocation = DB_CinemaDataSet.Movie.Rows(i).Item(3)
            movies(i).bigpiclocation = DB_CinemaDataSet.Movie.Rows(i).Item(4)
        Next

        picMovie1.Load(movies(0).piclocation)
        picMovie2.Load(movies(1).piclocation)
        picMovie3.Load(movies(2).piclocation)
        picMovie4.Load(movies(3).piclocation)
        picMovie5.Load(movies(4).piclocation)
        picMovie6.Load(movies(5).piclocation)
        picMovie7.Load(movies(6).piclocation)
        picMovie8.Load(movies(7).piclocation)
        picMovie9.Load(movies(8).piclocation)

        Dim num As Integer
        Dim numarray(3) As Integer
        Dim yesorno As Boolean
        numarray = {-1, -1, -1, -1}
        For i = 0 To 3 Step 1
            yesorno = False
            num = CInt(Rnd() * (movies.Length - 1))
            For j = 0 To numarray.Length - 1 Step 1
                If numarray(j) = num Then
                    i -= 1
                    yesorno = True
                End If

            Next
            If Not yesorno Then
                MoviePoster(i) = movies(num)
                numarray(i) = num
            End If
        Next
        picPoster.Load(MoviePoster(0).bigpiclocation)
        lblPosterName.Text = MoviePoster(0).title
    End Sub

    Private Sub changeSlide(ByVal scrollIndex As Integer)
        slideNo += scrollIndex

        If slideNo = -1 Then
            slideNo = 3
        ElseIf slideNo = 4 Then
            slideNo = 0
        End If


        changePoster()
    End Sub

    Private Sub changePoster()
        Select Case slideNo
            Case 0
                lblPoster1.BackColor = Color.WhiteSmoke
                lblPoster2.BackColor = Color.Silver
                lblPoster3.BackColor = Color.Silver
                lblPoster4.BackColor = Color.Silver
            Case 1
                lblPoster1.BackColor = Color.Silver
                lblPoster2.BackColor = Color.WhiteSmoke
                lblPoster3.BackColor = Color.Silver
                lblPoster4.BackColor = Color.Silver
            Case 2
                lblPoster1.BackColor = Color.Silver
                lblPoster2.BackColor = Color.Silver
                lblPoster3.BackColor = Color.WhiteSmoke
                lblPoster4.BackColor = Color.Silver
            Case 3
                lblPoster1.BackColor = Color.Silver
                lblPoster2.BackColor = Color.Silver
                lblPoster3.BackColor = Color.Silver
                lblPoster4.BackColor = Color.WhiteSmoke
        End Select
        picPoster.Load(MoviePoster(slideNo).bigpiclocation)
        lblPosterName.Text = MoviePoster(slideNo).title
    End Sub

    Private Sub resetSeat()
        Dim i, j, k As Integer
        Dim str As String = lblDate.Text.Substring(0, 8)
        Dim time As String = ""
        For i = 0 To rooms.Length - 1 Step 1
            For j = 0 To rooms(i).showTime.Length - 1 Step 1
                time = rooms(i).showTime(j).time & ":00"
                If time = str Then
                    For k = 0 To rooms(i).showTime(j).seat.Length - 1 Step 1
                        rooms(i).showTime(j).seat(k).status = True
                    Next
                End If
            Next
        Next

        For i = 0 To DB_CinemaDataSet.ShowTime.Rows.Count - 1 Step 1
            If DB_CinemaDataSet.ShowTime.Rows(i).Item(1).ToString & ":00" = str Then
                MessageBox.Show("All rooms in show Time [" & str.Substring(0, 5) & "] is reset", "Seat reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next

    End Sub

    Private Sub lblDate_Changed(sender As Object, e As EventArgs) Handles lblDate.TextChanged
        resetSeat()
    End Sub


    Private Sub goToNext(ByVal index As Integer)
        Movie_Details.movieSelect = movies(index)
        beforeGo(index)
        Movie_Details.Show()
        Me.Hide()
    End Sub

    Private Sub beforeGo(ByVal index As Integer)
        Dim i = 0
        ReDim Movie_Details.roomMovie(0).showTime(3)
        ReDim Movie_Details.roomMovie(1).showTime(1)
        For i = 0 To Movie_Details.roomMovie(0).showTime.Length - 1 Step 1
            ReDim Movie_Details.roomMovie(0).showTime(i).seat(191)
        Next
        ReDim Movie_Details.roomMovie(1).showTime(0).seat(23)

        Movie_Details.roomMovie(0) = rooms(index)
        Dim value As Integer = index Mod 2
        Dim value2 As Integer = index Mod 6
        If value = 0 Then
            Movie_Details.roomMovie(1).showTime(0) = rooms(12).showTime(value2)
            Movie_Details.roomMovie(1).ID = rooms(12).ID
            Movie_Details.roomMovie(1).type = rooms(12).type
        ElseIf value = 1 Then
            Movie_Details.roomMovie(1).showTime(0) = rooms(13).showTime(value2)
            Movie_Details.roomMovie(1).ID = rooms(13).ID
            Movie_Details.roomMovie(1).type = rooms(13).type
        End If
    End Sub

    Private Sub picMovie2_Click(sender As Object, e As EventArgs) Handles picMovie2.Click
        goToNext(1)
    End Sub

    Private Sub picMovie3_Click(sender As Object, e As EventArgs) Handles picMovie3.Click
        goToNext(2)
    End Sub

    Private Sub picMovie4_Click(sender As Object, e As EventArgs) Handles picMovie4.Click
        goToNext(3)
    End Sub

    Private Sub picMovie5_Click(sender As Object, e As EventArgs) Handles picMovie5.Click
        goToNext(4)
    End Sub

    Private Sub picMovie6_Click(sender As Object, e As EventArgs) Handles picMovie6.Click
        goToNext(5)
    End Sub

    Private Sub picMovie7_Click(sender As Object, e As EventArgs) Handles picMovie7.Click
        goToNext(6)
    End Sub

    Private Sub picMovie8_Click(sender As Object, e As EventArgs) Handles picMovie8.Click
        goToNext(7)
    End Sub

    Private Sub picMovie9_Click(sender As Object, e As EventArgs) Handles picMovie9.Click
        goToNext(8)
    End Sub

    Private Sub picMovie1_Click(sender As Object, e As EventArgs) Handles picMovie1.Click
        goToNext(0)
    End Sub

    Private Sub picNext_Click(sender As Object, e As EventArgs) Handles picNext.Click
        changeSlide(1)
    End Sub

    Private Sub picBack_Click(sender As Object, e As EventArgs) Handles picBack.Click
        changeSlide(-1)
    End Sub

    Private Sub lblPoster4_Click(sender As Object, e As EventArgs) Handles lblPoster4.Click
        slideNo = 3
        changePoster()
    End Sub

    Private Sub lblPoster2_Click(sender As Object, e As EventArgs) Handles lblPoster2.Click
        slideNo = 1
        changePoster()
    End Sub

    Private Sub lblPoster3_Click(sender As Object, e As EventArgs) Handles lblPoster3.Click
        slideNo = 2
        changePoster()
    End Sub

    Private Sub lblPoster1_Click(sender As Object, e As EventArgs) Handles lblPoster1.Click
        slideNo = 0
        changePoster()
    End Sub

    Private Sub picMouseHover() Handles picMovie1.MouseHover, picMovie2.MouseHover, picMovie3.MouseHover, picMovie4.MouseHover, picMovie5.MouseHover, picMovie6.MouseHover, picMovie7.MouseHover, picMovie8.MouseHover, picMovie9.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picMouseLeave() Handles picMovie1.MouseLeave, picMovie2.MouseLeave, picMovie3.MouseLeave, picMovie4.MouseLeave, picMovie5.MouseLeave, picMovie6.MouseLeave, picMovie7.MouseLeave, picMovie8.MouseLeave, picMovie9.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

End Class