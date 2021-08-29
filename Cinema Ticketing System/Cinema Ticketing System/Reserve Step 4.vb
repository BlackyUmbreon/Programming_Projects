Imports QRCoder

Public Class Reserve_Step_4
    Dim move As Boolean = False
    Dim locX, locY As Integer
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

    Private Sub btnBack_Down(sender As Object, e As EventArgs) Handles btnBack.MouseDown
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click, picClose.Click, MnuClose.Click
        updateseat()
        If Home_Movie_Detail.type = "VIP" Then
            Reserve_Step_1___VIP__.Close()
        ElseIf Home_Movie_Detail.type = "Standard" Then
            Reserve_Step_1___STD__.Close()
        End If
        Reserve_Step_2.Close()
        Reserve_Step_3.Close()
        Home_Movie_Detail.Close()
        Me.Close()
        Home.Show()
    End Sub

    Private Sub btnBack_Up(sender As Object, e As EventArgs) Handles btnBack.MouseUp
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub Reserve_Step_4_Load(sender As Object, e As EventArgs) Handles Me.Load
        reportinitial()
        databaseAdd()
        qrgenerate()
    End Sub

    Private Sub qrgenerate()
        Dim toString As String = ""
        Dim count As Integer = 0
        Dim comboCount As Integer = 0
        Dim orderDate As String = Date.Now.ToString("MM/dd/yyyy")
        If Home_Movie_Detail.type = "VIP" Then
            With Reserve_Step_1___VIP__.orderMovie
                For i = 0 To .seatSelect.Count - 1 Step 1
                    If .seatSelect(i).status Then
                        count += 1
                    End If
                Next

                For i = 0 To .comboCount.Count - 1
                    comboCount += .comboCount(i)
                Next
                toString = "Transaction ID : " & .orderID & vbCrLf & "Room ID : " & .room.ID & vbCrLf & "Staff ID : " & .staffID & vbCrLf & "Member ID : " & .memberID & vbCrLf & "Movie Selected : " & .movieSelect.title & vbCrLf & "Number of Seats : " & count & vbCrLf & "Number of Combo : " & comboCount & vbCrLf & "Date Purchase : " & orderDate
            End With
        ElseIf Home_Movie_Detail.type = "Standard" Then
            With Reserve_Step_1___STD__.orderMovie
                For i = 0 To .seatSelect.Count - 1 Step 1
                    If .seatSelect(i).status Then
                        count += 1
                    End If
                Next

                For i = 0 To .comboCount.Count - 1
                    comboCount += .comboCount(i)
                Next
                toString = "Transaction ID : " & .orderID & vbCrLf & "Room ID : " & .room.ID & vbCrLf & "Staff ID : " & .staffID & vbCrLf & "Member ID : " & .memberID & vbCrLf & "Movie Selected : " & .movieSelect.title & vbCrLf & "Number of Seats : " & count & vbCrLf & "Number of Combo : " & comboCount & vbCrLf & "Date Purchase : " & orderDate
            End With
        End If
        Dim qr As New QRCodeGenerator
        Dim data = qr.CreateQrCode(toString, QRCodeGenerator.ECCLevel.M)
        Dim code As New QRCode(data)
        picQR.Image = code.GetGraphic(6)
    End Sub

    Private Sub updateseat()
        Dim i, j, k As Integer

        If Home_Movie_Detail.type = "VIP" Then
            For i = 0 To Home.rooms.Count - 1 Step 1
                If Reserve_Step_1___VIP__.orderMovie.room.ID = Home.rooms(i).ID Then
                    For j = 0 To Home.rooms(i).showTime.Count - 1 Step 1
                        If Reserve_Step_1___VIP__.orderMovie.room.showTime(0).time = Home.rooms(i).showTime(j).time Then
                            For k = 0 To Home.rooms(i).showTime(j).seat.Count - 1 Step 1
                                If Reserve_Step_1___VIP__.orderMovie.seatSelect(k).status Then
                                    Home.rooms(i).showTime(j).seat(k).status = False
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        ElseIf Home_Movie_Detail.type = "Standard" Then
            For i = 0 To Home.rooms.Count - 1 Step 1
                If Reserve_Step_1___STD__.orderMovie.room.ID = Home.rooms(i).ID Then
                    For j = 0 To Home.rooms(i).showTime.Count - 1 Step 1
                        If Reserve_Step_1___STD__.orderMovie.room.showTime(0).time = Home.rooms(i).showTime(j).time Then
                            For k = 0 To Home.rooms(i).showTime(j).seat.Count - 1 Step 1
                                If Reserve_Step_1___STD__.orderMovie.seatSelect(k).status Then
                                    Home.rooms(i).showTime(j).seat(k).status = False
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If

    End Sub

    Private Sub databaseAdd()
        FoodTableAdapter.Fill(DB_CinemaDataSet.Food)
        Dim ticketCount As Integer = 0
        Dim i As Integer
        Dim comboCount As Integer = 0
        Dim orderDate As String = Date.Now.ToString("MM/dd/yyyy")
        If Home_Movie_Detail.type = "VIP" Then
            For i = 0 To Reserve_Step_1___VIP__.orderMovie.seatSelect.Count - 1 Step 1
                If Reserve_Step_1___VIP__.orderMovie.seatSelect(i).status Then
                    ticketCount += 1
                End If
            Next

            For i = 0 To Reserve_Step_1___VIP__.orderMovie.comboCount.Count - 1 Step 1
                comboCount += Reserve_Step_1___VIP__.orderMovie.comboCount(i)
                DB_CinemaDataSet.Food.Rows(i).Item(4) += Reserve_Step_1___VIP__.orderMovie.comboCount(i)
            Next

            With Reserve_Step_1___VIP__.orderMovie
                TransactionTableAdapter.Insert(.orderID, .memberID, .staffID, .movieSelect.id, ticketCount, comboCount, orderDate, .total)
                TransactionTableAdapter.Update(DB_CinemaDataSet)
            End With

        ElseIf Home_Movie_Detail.type = "Standard" Then
            For i = 0 To Reserve_Step_1___STD__.orderMovie.seatSelect.Count - 1 Step 1
                If Reserve_Step_1___STD__.orderMovie.seatSelect(i).status Then
                    ticketCount += 1
                End If
            Next

            For i = 0 To Reserve_Step_1___STD__.orderMovie.comboCount.Count - 1 Step 1
                comboCount += Reserve_Step_1___STD__.orderMovie.comboCount(i)
                DB_CinemaDataSet.Food.Rows(i).Item(4) += Reserve_Step_1___STD__.orderMovie.comboCount(i)
            Next

            With Reserve_Step_1___STD__.orderMovie
                TransactionTableAdapter.Insert(.orderID, .memberID, .staffID, .movieSelect.id, ticketCount, comboCount, orderDate, .total)
                TransactionTableAdapter.Update(DB_CinemaDataSet)
                FoodTableAdapter.Update(DB_CinemaDataSet)
            End With
        End If
        SystemSelection.orderCount += 1
    End Sub

    Private Sub picPrint_Click(sender As Object, e As EventArgs) Handles picPrint.Click
        prtPreview.Document = prtDoc
        prtPreview.ShowDialog()
    End Sub



    Private Sub reportinitial()
        Dim i As Integer
        If Home_Movie_Detail.type = "VIP" Then
            Reserve_Step_1___VIP__.orderMovie.staffID = Home_Log_in.staffID
            Reserve_Step_1___VIP__.orderMovie.memberID = "Guest"
            With Reserve_Step_1___VIP__.orderMovie
                lblTransaction.Text = .orderID
                lblStaff.Text = .staffID
                lblMember.Text = .memberID
                lblMovie.Text = .movieSelect.id
                lblTime.Text = .room.showTime(0).time
                lblRoom.Text = .room.ID
                For i = 0 To .seatSelect.Count - 1 Step 1
                    If .seatSelect(i).status Then
                        lblSeats.Text = lblSeats.Text & .seatSelect(i).id & " "
                    End If
                Next
                lblCategory.Text = .room.type
                lblPrice.Text = FormatCurrency(.total, 2)
            End With

        ElseIf Home_Movie_Detail.type = "Standard" Then
            Reserve_Step_1___STD__.orderMovie.staffID = Home_Log_in.staffID
            Reserve_Step_1___STD__.orderMovie.memberID = "Guest"
            With Reserve_Step_1___STD__.orderMovie
                lblTransaction.Text = .orderID
                lblStaff.Text = .staffID
                lblMember.Text = .memberID
                lblMovie.Text = .movieSelect.id
                lblTime.Text = .room.showTime(0).time
                lblRoom.Text = .room.ID
                For i = 0 To .seatSelect.Count - 1 Step 1
                    If .seatSelect(i).status Then
                        lblSeats.Text = lblSeats.Text & .seatSelect(i).id & " "
                    End If
                Next
                lblCategory.Text = .room.type
                lblPrice.Text = FormatCurrency(.total, 2)
            End With

        End If
    End Sub

    Private Sub picPrint_MouseHover(sender As Object, e As EventArgs) Handles picPrint.MouseHover
        picPrint.Load("C:\Users\user\Desktop\Assignment\Picture\Reserve\PrintHover.png")
    End Sub

    Private Sub prtDoc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles prtDoc.PrintPage
        Dim fontRoom As New Font("Times New Roman", 48, FontStyle.Bold)
        Dim font As New Font("Times New Roman", 20)
        Dim x As Integer = e.MarginBounds.Left
        Dim y As Integer = e.MarginBounds.Top
        Dim logoLeft As Image = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\Basic\Icon left.png")
        Dim i As Integer
        Dim j As Integer

        If Home_Movie_Detail.type = "Standard" Then
            For i = 0 To Reserve_Step_1___STD__.orderMovie.seatSelect.Count - 1 Step 1
                If Reserve_Step_1___STD__.orderMovie.seatSelect(i).status Then
                    e.Graphics.DrawImage(logoLeft, x - 70, y - 90, 100, 100)
                    e.Graphics.DrawString("SS Cinema", font, Brushes.Black, x - 90, y + 20)
                    With Reserve_Step_1___STD__.orderMovie
                        e.Graphics.DrawString("Transaction ID :  " & .orderID, font, Brushes.Black, x + 60, y - 40)
                        e.Graphics.DrawString("Expiration period :  " & Date.Now.ToString("dd/MM/yyyy"), font, Brushes.Black, x + 60, y)
                        e.Graphics.DrawString("Movie ID :  " & .movieSelect.id, font, Brushes.Black, x + 60, y + 40)
                        e.Graphics.DrawString("Movie Title :  " & .movieSelect.title, font, Brushes.Black, x + 60, y + 80)
                        e.Graphics.DrawString("Seat Select :  " & .seatSelect(i).id, font, Brushes.Black, x + 60, y + 120)
                        e.Graphics.DrawString(.room.ID, fontRoom, Brushes.Black, x + 500, y)
                        e.Graphics.DrawString("Show Time : " & .room.showTime(0).time, font, Brushes.Black, x + 470, y + 120)
                    End With
                    For j = -5 To 1000 Step 10
                        e.Graphics.DrawString("-", font, Brushes.Black, j, y + 180)
                    Next
                    y += 300
                End If
            Next
        ElseIf Home_Movie_Detail.type = "VIP" Then
            For i = 0 To Reserve_Step_1___VIP__.orderMovie.seatSelect.Count - 1 Step 1
                If Reserve_Step_1___VIP__.orderMovie.seatSelect(i).status Then
                    e.Graphics.DrawImage(logoLeft, x - 70, y - 90, 100, 100)
                    e.Graphics.DrawString("SS Cinema", font, Brushes.Black, x - 90, y + 20)
                    With Reserve_Step_1___VIP__.orderMovie
                        e.Graphics.DrawString("Transaction ID :  " & .orderID, font, Brushes.DarkGoldenrod, x + 60, y - 40)
                        e.Graphics.DrawString("Date :  " & Date.Now.ToString("dd/MM/yyyy"), font, Brushes.DarkGoldenrod, x + 60, y)
                        e.Graphics.DrawString("Movie ID :  " & .movieSelect.id, font, Brushes.DarkGoldenrod, x + 60, y + 40)
                        e.Graphics.DrawString("Movie Title :  " & .movieSelect.title, font, Brushes.DarkGoldenrod, x + 60, y + 80)
                        e.Graphics.DrawString("Seat Select :  " & .seatSelect(i).id, font, Brushes.DarkGoldenrod, x + 60, y + 120)
                        e.Graphics.DrawString(.room.ID, fontRoom, Brushes.DarkGoldenrod, x + 500, y)
                        e.Graphics.DrawString("Show Time : " & .room.showTime(0).time, font, Brushes.DarkGoldenrod, x + 470, y + 120)
                    End With
                    For j = -5 To 1000 Step 10
                        e.Graphics.DrawString("-", font, Brushes.DarkGoldenrod, j, y + 180)
                    Next
                    y += 300
                End If
            Next
        End If

    End Sub

    Private Sub picPrint_MouseLeave(sender As Object, e As EventArgs) Handles picPrint.MouseLeave
        picPrint.Load("C:\Users\user\Desktop\Assignment\Picture\Reserve\Print.png")
    End Sub
End Class