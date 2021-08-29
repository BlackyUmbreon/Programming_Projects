Public Class Kiosk_Step_1__Standard_
    Public Structure Order
        Dim orderID As String  'Last Step
        Dim staffID As String  'Last Step
        Dim memberID As String 'Always Guest
        Dim movieSelect As KioskHome.Movie  'Selected
        Dim room As KioskHome.Room  'Selected
        Dim total As Decimal   'After Step 1 and Step 2
        Dim seatSelect() As KioskHome.Seat  'After Step 1
        Dim comboCount() As Integer  'Step 2
    End Structure


    Friend orderMovie As Order
    Private seatAdd(191) As String
    Dim second As Integer

    Private Sub btnNext_Down(sender As Object, e As EventArgs) Handles btnNext.MouseDown
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnNext_Up(sender As Object, e As EventArgs) Handles btnNext.MouseUp
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnCancel_Down(sender As Object, e As EventArgs) Handles btnCancel.MouseDown
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Me.Hide()
        orderMovie.total = CDec(lblTotalPrice.Text)
        Kiosk_Step_2.Show()
        tmReserve.Stop()
    End Sub

    Private Sub btnCancel_Up(sender As Object, e As EventArgs) Handles btnCancel.MouseUp
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub Reserve_Step_1___STD___Load(sender As Object, e As EventArgs) Handles Me.Load
        initialize()
        btnNext.Enabled = False
        second = 300
        Dim minute As Integer = Math.Floor(second / 60)
        Dim seconds As Integer = second Mod 60
        lblTime.Text = minute & " Minutes " & seconds & " seconds left"
        tmReserve.Start()
    End Sub

    Private Sub initialize()
        seatInitialize()
        picMovie.Load(orderMovie.movieSelect.piclocation)
        lblMovieTItle.Text = orderMovie.movieSelect.title
        lblRoom.Text = "Room " & orderMovie.room.ID
        lblShowtime.Text = orderMovie.room.showTime(0).time
        handleSeat()
    End Sub

    Private Sub handleSeat()
        Dim intCursor As Integer = 0
        Dim row(11) As Char
        row = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}
        Do Until intCursor = 192
            Dim lblTarget() As Control = Me.Controls.Find(seatAdd(intCursor), True)
            AddHandler lblTarget(0).Click, AddressOf HandleSeatClick
            intCursor += 1
        Loop
    End Sub

    Private Sub HandleSeatClick(sender As Object, e As EventArgs)
        Dim lblTarget As Label = CType(sender, Label)
        Dim i As Integer
        For i = 0 To orderMovie.room.showTime(0).seat.Count - 1 Step 1
            If lblTarget.Name.Equals(seatAdd(i)) Then
                If orderMovie.room.showTime(0).seat(i).status Then
                    If lblTarget.BackColor = Color.Yellow Then
                        seatAdding(seatAdd(i), 1)
                        lblTarget.BackColor = Color.LimeGreen
                    ElseIf lblTarget.BackColor = Color.LimeGreen Then
                        seatRemove(seatAdd(i), 1)
                        lblTarget.BackColor = Color.Yellow
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub seatInitialize()
        Dim i As Integer
        Dim row(11) As Char
        Dim label() As Control
        row = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}
        With orderMovie.room.showTime(0)
            For i = 0 To .seat.Count - 1 Step 1
                seatAdd(i) = "lbl" & row(Math.Floor(i / 16)) & (i Mod 16) + 1
                If Not .seat(i).status Then
                    label = Me.Controls.Find(seatAdd(i), True)
                    label(0).BackColor = Color.Red
                End If
            Next
        End With

        ReDim orderMovie.seatSelect(191)

        For i = 0 To orderMovie.seatSelect.Length - 1 Step 1
            orderMovie.seatSelect(i).id = orderMovie.room.showTime(0).seat(i).id
            orderMovie.seatSelect(i).status = False
        Next

        numAdult.Maximum = 0
        numChildren.Maximum = 0
        numOKU.Maximum = 0
    End Sub

    Private Sub seatAdding(ByVal address As String, ByVal addingValue As Integer)
        Dim i As Integer = 0
        For i = 0 To orderMovie.seatSelect.Length - 1 Step 1
            If seatAdd(i).Equals(address) Then
                orderMovie.seatSelect(i).status = True
            End If
        Next

        Dim stringSeat As String = ""
        Dim count As Integer = 0

        For i = 0 To orderMovie.seatSelect.Length - 1 Step 1
            If orderMovie.seatSelect(i).status Then
                If seatAdd(i).Length = 5 Then
                    stringSeat += seatAdd(i).Substring(3, 2) & " "
                    count += 1
                ElseIf seatAdd(i).Length = 6 Then
                    stringSeat += seatAdd(i).Substring(3, 3) & " "
                    count += 1
                End If
            End If
        Next

        lblSeatSelected.Text = stringSeat
        lblQuantity.Text = count

        finalMaximum()
        checking()
    End Sub

    Private Sub seatRemove(ByVal address As String, ByVal removeValue As Integer)
        Dim i As Integer = 0
        For i = 0 To orderMovie.seatSelect.Length - 1 Step 1
            If seatAdd(i).Equals(address) Then
                orderMovie.seatSelect(i).status = False
            End If
        Next

        Dim stringSeat As String = ""
        Dim count As Integer = 0

        For i = 0 To orderMovie.seatSelect.Length - 1 Step 1
            If orderMovie.seatSelect(i).status Then
                If seatAdd(i).Length = 5 Then
                    stringSeat += seatAdd(i).Substring(3, 2) & " "
                    count += 1
                ElseIf seatAdd(i).Length = 6 Then
                    stringSeat += seatAdd(i).Substring(3, 3) & " "
                    count += 1
                End If
            End If
        Next

        lblSeatSelected.Text = stringSeat
        lblQuantity.Text = count

        Dim sum As Integer
        sum = CInt(numAdult.Value) + CInt(numChildren.Value) + CInt(numOKU.Value)

        If sum > count Then
            If numAdult.Value <> 0 Then
                numAdult.Maximum -= 1
            ElseIf numChildren.Value <> 0 Then
                numChildren.Maximum -= 1
            ElseIf numOKU.Value <> 0 Then
                numOKU.Maximum -= 1

            End If
        End If
        checking()

    End Sub

    Private Sub finalMaximum()
        Dim count As Integer
        Dim sum As Integer
        count = CInt(lblQuantity.Text)
        sum = CInt(numAdult.Value) + CInt(numChildren.Value) + CInt(numOKU.Value)
        numAdult.Maximum = count - sum + numAdult.Value
        numChildren.Maximum = count - sum + numChildren.Value
        numOKU.Maximum = count - sum + numOKU.Value
    End Sub

    Private Sub checking()
        Dim sum As Integer
        Dim count As Integer
        count = CInt(lblQuantity.Text)
        sum = CInt(numAdult.Value) + CInt(numChildren.Value) + CInt(numOKU.Value)

        If count = 0 Then
            picError.Visible = True
            lblErrorText.Visible = True
            btnNext.Enabled = False
        Else
            If sum <> count Then
                picError.Visible = True
                lblErrorText.Visible = True
                btnNext.Enabled = False
            Else
                picError.Visible = False
                lblErrorText.Visible = False
                btnNext.Enabled = True
            End If
        End If

    End Sub

    Private Sub numeric_changed(sender As Object, e As EventArgs) Handles numAdult.ValueChanged, numChildren.ValueChanged, numOKU.ValueChanged
        finalMaximum()
        checking()
        calculatePrice()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        Movie_Details.Close()
        KioskHome.Show()
    End Sub

    Private Sub calculatePrice()
        Dim adult As Decimal
        Dim children As Decimal
        Dim oku As Decimal
        Dim foreign As Decimal
        Dim total As Decimal

        Const adultPrice As Decimal = 12.0
        Const childrenPrice As Decimal = 8.0
        Const okuPrice As Decimal = 6.0

        adult = CInt(numAdult.Value) * adultPrice
        children = CInt(numChildren.Value) * childrenPrice
        oku = CInt(numOKU.Value) * okuPrice
        total = adult + children + foreign + oku

        lblAdultPrice.Text = FormatNumber(adult, 2)
        lblChildrenPrice.Text = FormatNumber(children, 2)
        lblOKUPrice.Text = FormatNumber(oku, 2)
        lblTotalPrice.Text = FormatNumber(total, 2)
    End Sub

    Private Sub tmReserve_Tick(sender As Object, e As EventArgs) Handles tmReserve.Tick
        second -= 1
        Dim minute As Integer = Math.Floor(second / 60)
        Dim seconds As Integer = second Mod 60
        lblTime.Text = minute & " Minutes " & seconds & " seconds left"
        If second = 0 Then
            tmReserve.Stop()
            MessageBox.Show("Reservation Timed Out, Reservation has been Cancelled", "Timed Out", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            KioskHome.Show()
        End If
    End Sub
End Class