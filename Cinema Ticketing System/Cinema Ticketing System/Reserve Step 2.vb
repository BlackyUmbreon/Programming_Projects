Public Class Reserve_Step_2
    Dim move As Boolean = False
    Dim locX, locY As Integer

    public Structure Food
        Dim name As String
        Dim pic As String
        Dim price As Decimal
    End Structure

    Friend foods(2) As Food
    Friend totalPrice As Decimal

    Dim noSetA As Integer = 0
    Dim noSetB As Integer = 0
    Dim noSetC As Integer = 0

    Private Sub picClose_MouseHover(sender As Object, e As EventArgs) Handles picClose.MouseHover
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\CloseHover.png")
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Close.png")
    End Sub

    Private Sub picClose_MouseClick(sender As Object, e As MouseEventArgs) Handles picClose.MouseClick
        Me.Close()
        End
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
    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
        End
    End Sub

    Private Sub btnCancel_Down(sender As Object, e As EventArgs) Handles btnCancel.MouseDown
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCancel_Up(sender As Object, e As EventArgs) Handles btnCancel.MouseUp
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnNext_Down(sender As Object, e As EventArgs) Handles btnNext.MouseDown
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If Home_Movie_Detail.type = "Standard" Then
            ReDim Reserve_Step_1___STD__.orderMovie.comboCount(2)

            Reserve_Step_1___STD__.orderMovie.comboCount(0) = lblSetAQty.Text
            Reserve_Step_1___STD__.orderMovie.comboCount(1) = lblSetBQty.Text
            Reserve_Step_1___STD__.orderMovie.comboCount(2) = lblSetCQty.Text

            Reserve_Step_1___STD__.orderMovie.total = totalPrice
            Reserve_Step_3.lblPrice.Text = FormatCurrency(Reserve_Step_1___STD__.orderMovie.total, 2)
        ElseIf Home_Movie_Detail.type = "VIP" Then
            ReDim Reserve_Step_1___VIP__.orderMovie.comboCount(2)

            Reserve_Step_1___VIP__.orderMovie.comboCount(0) = lblSetAQty.Text
            Reserve_Step_1___VIP__.orderMovie.comboCount(1) = lblSetBQty.Text
            Reserve_Step_1___VIP__.orderMovie.comboCount(2) = lblSetCQty.Text

            Reserve_Step_1___VIP__.orderMovie.total = totalPrice
            Reserve_Step_3.lblPrice.Text = FormatCurrency(Reserve_Step_1___VIP__.orderMovie.total, 2)
        End If
        Reserve_Step_3.Show()
        Me.Close()
    End Sub

    Private Sub btnNext_Up(sender As Object, e As EventArgs) Handles btnNext.MouseUp
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub foodInitialize()


        numSetA.Maximum = 9
        numSetB.Maximum = 9
        numSetC.Maximum = 9

        Dim totalSetA, totalSetB, totalSetC As Decimal

        totalSetA = 0
        totalSetB = 0
        totalSetC = 0

        lblPriceA.Text = FormatNumber(0, 2)

        lblPriceB.Text = FormatNumber(0, 2)

        lblPriceC.Text = FormatNumber(0, 2)

        If Home_Movie_Detail.type = "Standard" Then

            lblTicketQty.Text = Reserve_Step_1___STD__.lblQuantity.Text

        ElseIf Home_Movie_Detail.type = "VIP" Then

            lblTicketQty.Text = Reserve_Step_1___VIP__.lblQuantity.Text

        End If

        lblSetAQty.Text = 0

        lblSetBQty.Text = 0

        lblSetCQty.Text = 0

        If Home_Movie_Detail.type = "Standard" Then

            lblPriceTicket.Text = Reserve_Step_1___STD__.lblTotalPrice.Text

        ElseIf Home_Movie_Detail.type = "VIP" Then

            lblPriceTicket.Text = Reserve_Step_1___VIP__.lblTotalPrice.Text

        End If

        FoodTableAdapter.Fill(DB_CinemaDataSet.Food)

        Dim i As Integer

        For i = 0 To foods.Count - 1 Step 1
            foods(i).name = DB_CinemaDataSet.Food.Rows(i).Item(1).ToString
            foods(i).pic = DB_CinemaDataSet.Food.Rows(i).Item(5).ToString
            foods(i).price = DB_CinemaDataSet.Food.Rows(i).Item(3).ToString
        Next

        lblUnitPriceA.Text = "* RM " & FormatNumber(foods(0).price, 2)
        lblUnitPriceA2.Text = "* RM " & FormatNumber(foods(0).price, 2)
        lblUnitPriceB.Text = "* RM " & FormatNumber(foods(1).price, 2)
        lblUnitPriceB2.Text = "* RM " & FormatNumber(foods(1).price, 2)
        lblUnitPriceC.Text = "* RM " & FormatNumber(foods(2).price, 2)
        lblUnitPriceC2.Text = "* RM " & FormatNumber(foods(2).price, 2)

        lblPriceSetA.Text = FormatNumber(0, 2)
        lblPriceSetB.Text = FormatNumber(0, 2)
        lblPriceSetC.Text = FormatNumber(0, 2)

        totalPrice = CDec(lblPriceTicket.Text) + CDec(lblPriceSetA.Text) + CDec(lblPriceSetB.Text) + CDec(lblPriceSetC.Text)

        lblTotalPrice.Text = FormatNumber(totalPrice, 2)

        picSetA.Load(foods(0).pic)
        picSetB.Load(foods(1).pic)
        picSetC.Load(foods(2).pic)

        lblSetA.Text = foods(0).name
        lblSetB.Text = foods(1).name
        lblSetC.Text = foods(2).name
    End Sub

    Private Sub numSet_ValueChanged(sender As Object, e As EventArgs) Handles numSetA.ValueChanged, numSetB.ValueChanged, numSetC.ValueChanged
        calculate()
    End Sub

    Private Sub calculate()
        Dim qtyA, qtyB, qtyC As Integer

        qtyA = numSetA.Value
        qtyB = numSetB.Value
        qtyC = numSetC.Value

        Dim totalA, totalB, totalC As Decimal

        totalA = qtyA * foods(0).price
        totalB = qtyB * foods(1).price
        totalC = qtyC * foods(2).price

        lblPriceA.Text = FormatNumber(totalA, 2)
        lblPriceB.Text = FormatNumber(totalB, 2)
        lblPriceC.Text = FormatNumber(totalC, 2)

        lblPriceSetA.Text = FormatNumber(totalA, 2)
        lblPriceSetB.Text = FormatNumber(totalB, 2)
        lblPriceSetC.Text = FormatNumber(totalC, 2)

        lblSetAQty.Text = qtyA
        lblSetBQty.Text = qtyB
        lblSetCQty.Text = qtyC

        Dim totalticketprice As Decimal = CDec(lblPriceTicket.Text)

        totalPrice = totalticketprice + totalA + totalB + totalC

        lblTotalPrice.Text = FormatNumber(totalPrice, 2)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        Home.Show()
    End Sub

    Private Sub Reserve_Step_2_Load(sender As Object, e As EventArgs) Handles Me.Load
        foodInitialize()
    End Sub
End Class