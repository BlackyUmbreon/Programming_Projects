Public Class Kiosk_Step_3
    Public Structure orderID

        Dim orderDay As Integer
        Dim orderMonth As Integer
        Dim orderYear As Integer
        Dim orderNo As Integer

    End Structure

    Friend Id As orderID
    Dim second As Integer

    Private Sub btnCancel_Down(sender As Object, e As EventArgs) Handles btnCancel.MouseDown
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCancel_Up(sender As Object, e As EventArgs) Handles btnCancel.MouseUp
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnNext_Down(sender As Object, e As EventArgs) Handles btnNext.MouseDown
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnNext_Up(sender As Object, e As EventArgs) Handles btnNext.MouseUp
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub


    Private Sub Reserve_Step_3_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Shown

        Id.orderDay = Date.Now().ToString("dd")
        Id.orderMonth = Date.Now().ToString("MM")
        Id.orderYear = Date.Now().ToString("yyyy")
        second = 300
        Dim minute As Integer = Math.Floor(second / 60)
        Dim seconds As Integer = second Mod 60
        lblTime.Text = minute & " Minutes " & seconds & " seconds left"
        tmReserve.Start()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        generatingID()
        tmReserve.Stop()
        Me.Close()
        Kiosk_Step4.Show()
    End Sub

    Private Sub generatingID()
        Id.orderNo = SystemSelection.orderCount
        If Movie_Details.type = "VIP" Then

            If Id.orderNo < 9 Then
                Kiosk_Step_1___VIP__.orderMovie.orderID = "T" & "00" & Id.orderNo + 1
            ElseIf Id.orderNo >= 9 And Id.orderNo < 99 Then
                Kiosk_Step_1___VIP__.orderMovie.orderID = "T" & "0" & Id.orderNo + 1
            ElseIf Id.orderNo >= 99 And Id.orderNo < 999 Then
                Kiosk_Step_1___VIP__.orderMovie.orderID = "T" & Id.orderNo + 1
            End If

        ElseIf Movie_Details.type = "Standard" Then

            If Id.orderNo < 9 Then
                Kiosk_Step_1__Standard_.orderMovie.orderID = "T" & "00" & Id.orderNo + 1
            ElseIf Id.orderNo >= 9 And Id.orderNo < 99 Then
                Kiosk_Step_1__Standard_.orderMovie.orderID = "T" & "0" & Id.orderNo + 1
            ElseIf Id.orderNo >= 99 And Id.orderNo < 999 Then
                Kiosk_Step_1__Standard_.orderMovie.orderID = "T" & Id.orderNo + 1
            End If

        End If
    End Sub

    Private Sub ValidatingInput()
        If mskCard.Text.Length < 19 Then
            btnNext.Enabled = False
        Else
            If mskDate.Text.Length < 5 Then
                btnNext.Enabled = False
            Else
                If mskCVV.Text.Length < 3 Then
                    btnNext.Enabled = False
                Else
                    btnNext.Enabled = True
                End If
            End If
        End If
    End Sub


    Private Sub mskCard_TextChanged(sender As Object, e As EventArgs) Handles mskCard.TextChanged, mskCVV.TextChanged, mskDate.TextChanged
        ValidatingInput()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Movie_Details.type = "VIP" Then
            Kiosk_Step_1___VIP__.Close()
        ElseIf Movie_Details.type = "Standard" Then
            Kiosk_Step_1__Standard_.Close()
        End If
        Kiosk_Step_2.Close()
        Movie_Details.Close()
        Me.Close()
        KioskHome.Show()
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