Public Class Kiosk_Step_2
    Public Structure Food
        Dim name As String
        Dim pic As String
        Dim price As Decimal
    End Structure

    Friend foods(2) As Food
    Friend totalPrice As Decimal
    Dim second As Integer

    Dim noSetA As Integer = 0
    Dim noSetB As Integer = 0
    Dim noSetC As Integer = 0

    Private Sub btnNext_Down(sender As Object, e As EventArgs) Handles btnNext.MouseDown
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnNext_Up(sender As Object, e As EventArgs) Handles btnNext.MouseUp
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnCancel_Down(sender As Object, e As EventArgs) Handles btnCancel.MouseDown
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCancel_Up(sender As Object, e As EventArgs) Handles btnCancel.MouseUp
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Const discount As Decimal = 0.2
        Dim pricediscount As Decimal
        If Movie_Details.type = "Standard" Then
            ReDim Kiosk_Step_1__Standard_.orderMovie.comboCount(2)

            Kiosk_Step_1__Standard_.orderMovie.comboCount(0) = lblSetAQty.Text
            Kiosk_Step_1__Standard_.orderMovie.comboCount(1) = lblSetBQty.Text
            Kiosk_Step_1__Standard_.orderMovie.comboCount(2) = lblSetCQty.Text

            If Kiosk_Step_1__Standard_.orderMovie.memberID <> "Guest" Then
                Kiosk_Step_3.lblGrand.Text = FormatCurrency(totalPrice, 2)
                pricediscount = totalPrice * discount
                Kiosk_Step_3.lblDiscountPrice.Text = FormatCurrency(pricediscount, 2)
                Kiosk_Step_3.lblDiscount.Text = "Discount (" & FormatNumber(discount * 100, 0) & "%) :"
                Kiosk_Step_1__Standard_.orderMovie.total = totalPrice - pricediscount
                Kiosk_Step_3.lblTotalPrice.Text = FormatCurrency(Kiosk_Step_1__Standard_.orderMovie.total, 2)
            Else
                Kiosk_Step_3.lblGrand.Text = FormatCurrency(totalPrice, 2)
                pricediscount = 0
                Kiosk_Step_3.lblDiscountPrice.Text = FormatCurrency(pricediscount, 2)
                Kiosk_Step_3.lblDiscount.Text = "Discount ( 0" & "%) :"
                Kiosk_Step_1__Standard_.orderMovie.total = totalPrice - pricediscount
                Kiosk_Step_3.lblTotalPrice.Text = FormatCurrency(Kiosk_Step_1__Standard_.orderMovie.total, 2)
            End If

        ElseIf Movie_Details.type = "VIP" Then
            ReDim Kiosk_Step_1___VIP__.orderMovie.comboCount(2)

            Kiosk_Step_1___VIP__.orderMovie.comboCount(0) = lblSetAQty.Text
            Kiosk_Step_1___VIP__.orderMovie.comboCount(1) = lblSetBQty.Text
            Kiosk_Step_1___VIP__.orderMovie.comboCount(2) = lblSetCQty.Text

            If Kiosk_Step_1___VIP__.orderMovie.memberID <> "Guest" Then
                Kiosk_Step_3.lblGrand.Text = FormatCurrency(totalPrice, 2)
                pricediscount = totalPrice * discount
                Kiosk_Step_3.lblDiscountPrice.Text = FormatCurrency(pricediscount, 2)
                Kiosk_Step_3.lblDiscount.Text = "Discount (" & FormatNumber(discount * 100, 0) & "%) :"
                Kiosk_Step_1___VIP__.orderMovie.total = totalPrice - pricediscount
                Kiosk_Step_3.lblTotalPrice.Text = FormatCurrency(Kiosk_Step_1___VIP__.orderMovie.total, 2)
            Else
                Kiosk_Step_3.lblGrand.Text = FormatCurrency(totalPrice, 2)
                pricediscount = 0
                Kiosk_Step_3.lblDiscountPrice.Text = FormatCurrency(pricediscount, 2)
                Kiosk_Step_3.lblDiscount.Text = "Discount ( 0" & "%) :"
                Kiosk_Step_1___VIP__.orderMovie.total = totalPrice - pricediscount
                Kiosk_Step_3.lblTotalPrice.Text = FormatCurrency(Kiosk_Step_1___VIP__.orderMovie.total, 2)
            End If
        End If
        Kiosk_Step_3.Show()
        tmReserve.Stop()
        Me.Close()
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

        If Movie_Details.type = "Standard" Then

            lblTicketQty.Text = Kiosk_Step_1__Standard_.lblQuantity.Text

        ElseIf Movie_Details.type = "VIP" Then

            lblTicketQty.Text = Kiosk_Step_1___VIP__.lblQuantity.Text

        End If

        lblSetAQty.Text = 0

        lblSetBQty.Text = 0

        lblSetCQty.Text = 0

        If Movie_Details.type = "Standard" Then

            lblPriceTicket.Text = Kiosk_Step_1__Standard_.lblTotalPrice.Text

        ElseIf Movie_Details.type = "VIP" Then

            lblPriceTicket.Text = Kiosk_Step_1___VIP__.lblTotalPrice.Text

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
        If Movie_Details.type = "Standard" Then
            Kiosk_Step_1__Standard_.Close()
        ElseIf Movie_Details.type = "VIP" Then
            Kiosk_Step_1___VIP__.Close()
        End If
        Movie_Details.Close()
        Me.Close()
        KioskHome.Show()
    End Sub

    Private Sub Reserve_Step_2_Load(sender As Object, e As EventArgs) Handles Me.Load
        foodInitialize()
        second = 300
        Dim minute As Integer = Math.Floor(second / 60)
        Dim seconds As Integer = second Mod 60
        lblTime.Text = minute & " Minutes " & seconds & " seconds left"
        tmReserve.Start()
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