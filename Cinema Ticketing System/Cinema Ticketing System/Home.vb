Public Class Home
    Dim move As Boolean = False
    Dim locX, locY As Integer

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
    Friend movies(11) As Movie
    Private repeat As Boolean = False

    Private Sub picClose_MouseHover(sender As Object, e As EventArgs) Handles picClose.MouseHover
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\CloseHover.png")
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Close.png")
    End Sub

    Private Sub picClose_MouseClick(sender As Object, e As MouseEventArgs) Handles picClose.MouseClick
        If MessageBox.Show("Do you want to close the system?", "Close the program", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Me.Close()
            End
        End If
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
        Me.WindowState = FormWindowState.Minimized
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
        Cursor.Position = Me.PointToScreen(New Point((pnlTop.Right + pnlTop.Left) / 2, (pnlTop.Top + pnlTop.Bottom) / 2))
    End Sub

    Private Sub MnuMinimize_Click(sender As Object, e As EventArgs) Handles MnuMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub lblData_MouseHover(sender As Object, e As EventArgs) Handles lblData.MouseHover
        lblData.ForeColor = Color.Yellow
        picData.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Data Hover.png")
    End Sub

    Private Sub lblData_MouseLeave(sender As Object, e As EventArgs) Handles lblData.MouseLeave
        lblData.ForeColor = Color.White
        picData.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Data.png")
    End Sub

    Private Sub lblSales_MouseHover(sender As Object, e As EventArgs) Handles lblSales.MouseHover
        lblSales.ForeColor = Color.Yellow
        picSales.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Sales Hover.png")
    End Sub

    Private Sub lblSales_MouseLeave(sender As Object, e As EventArgs) Handles lblSales.MouseLeave
        lblSales.ForeColor = Color.White
        picSales.Load("C:\Users\user\Desktop\Assignment\Picture\Menu\Sales.png")
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

    Private Sub movieInitialize()
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
        picMovie10.Load(movies(9).piclocation)
        picMovie11.Load(movies(10).piclocation)
        picMovie12.Load(movies(11).piclocation)

        lblMovie1.Text = movies(0).title
        lblMovie2.Text = movies(1).title
        lblMovie3.Text = movies(2).title
        lblMovie4.Text = movies(3).title
        lblMovie5.Text = movies(4).title
        lblMovie6.Text = movies(5).title
        lblMovie7.Text = movies(6).title
        lblMovie8.Text = movies(7).title
        lblMovie9.Text = movies(8).title
        lblMovie10.Text = movies(9).title
        lblMovie11.Text = movies(10).title
        lblMovie12.Text = movies(11).title
    End Sub

    Private Sub picMouseHover() Handles picMovie1.MouseHover, picMovie2.MouseHover, picMovie3.MouseHover, picMovie4.MouseHover, picMovie5.MouseHover, picMovie6.MouseHover, picMovie7.MouseHover, picMovie8.MouseHover, picMovie9.MouseHover, picMovie10.MouseHover, picMovie11.MouseHover, picMovie12.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picMouseLeave() Handles picMovie1.MouseLeave, picMovie2.MouseLeave, picMovie3.MouseLeave, picMovie4.MouseLeave, picMovie5.MouseLeave, picMovie6.MouseLeave, picMovie7.MouseLeave, picMovie8.MouseLeave, picMovie9.MouseLeave, picMovie10.MouseLeave, picMovie11.MouseLeave, picMovie12.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmDate.Start()
        Initialize()
        movieInitialize()
        positionShow()
        lblDate.Text = TimeOfDay.ToString("hh:mm tt")
    End Sub

    Private Sub positionShow()
        Dim position As String = Home_Log_in.staffID.Substring(0, 2)
        If position = "NS" Then
            picData.Visible = False
            lblData.Visible = False
        ElseIf position = "HS" Then
            picData.Visible = True
            lblData.Visible = True
        End If
    End Sub


    Private Sub tmDate_Tick(sender As Object, e As EventArgs) Handles tmDate.Tick
        lblDate.Text = TimeOfDay.ToString("HH:mm:ss tt")
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

    Private Sub picMovie11_Click(sender As Object, e As EventArgs) Handles picMovie11.Click
        goToNext(10)
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

    Private Sub picMovie10_Click(sender As Object, e As EventArgs) Handles picMovie10.Click
        goToNext(9)
    End Sub

    Private Sub picMovie1_Click(sender As Object, e As EventArgs) Handles picMovie1.Click
        goToNext(0)
    End Sub

    Private Sub picMovie12_Click(sender As Object, e As EventArgs) Handles picMovie12.Click
        goToNext(11)
    End Sub

    Private Sub beforeGo(ByVal index As Integer)
        Dim i = 0
        ReDim Home_Movie_Detail.roomMovie(0).showTime(3)
        ReDim Home_Movie_Detail.roomMovie(1).showTime(1)
        For i = 0 To Home_Movie_Detail.roomMovie(0).showTime.Length - 1 Step 1
            ReDim Home_Movie_Detail.roomMovie(0).showTime(i).seat(191)
        Next
        ReDim Home_Movie_Detail.roomMovie(1).showTime(0).seat(23)

        Home_Movie_Detail.roomMovie(0) = rooms(index)
        Dim value As Integer = index Mod 2
        Dim value2 As Integer = index Mod 6
        If value = 0 Then
            Home_Movie_Detail.roomMovie(1).showTime(0) = rooms(12).showTime(value2)
            Home_Movie_Detail.roomMovie(1).ID = rooms(12).ID
            Home_Movie_Detail.roomMovie(1).type = rooms(12).type
        ElseIf value = 1 Then
            Home_Movie_Detail.roomMovie(1).showTime(0) = rooms(13).showTime(value2)
            Home_Movie_Detail.roomMovie(1).ID = rooms(13).ID
            Home_Movie_Detail.roomMovie(1).type = rooms(13).type
        End If
    End Sub

    Private Sub lblSales_Click(sender As Object, e As EventArgs) Handles lblSales.Click
        Sales_Report.Show()
        Me.Close()
    End Sub

    Private Sub lblData_Click(sender As Object, e As EventArgs) Handles lblData.Click
        Me.Close()
        Data_Control.Show()
    End Sub

    Private Sub lblLogOut_Click(sender As Object, e As EventArgs) Handles lblLogOut.Click
        Home_Log_in.Show()
        Me.Close()
    End Sub

    Private Sub lblDate_Changed(sender As Object, e As EventArgs) Handles lblDate.TextChanged
        resetSeat()
    End Sub

    Private Sub goToNext(ByVal index As Integer)
        Home_Movie_Detail.movieSelect = movies(index)
        beforeGo(index)
        Home_Movie_Detail.Show()
        Me.Hide()
    End Sub

    Private Sub Home_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        movieInitialize()
    End Sub
End Class