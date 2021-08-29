Public Class Reserve_Step_3
    Public Structure orderID

        Dim orderDay As Integer
        Dim orderMonth As Integer
        Dim orderYear As Integer
        Dim orderNo As Integer

    End Structure

    Friend Id As orderID

    Dim move As Boolean = False
    Dim locX, locY As Integer

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

    Private Sub btnNext_Up(sender As Object, e As EventArgs) Handles btnNext.MouseUp
        btnNext.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnCalculate_Down(sender As Object, e As EventArgs) Handles btnCalculate.MouseDown
        btnCalculate.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCalculate_Up(sender As Object, e As EventArgs) Handles btnCalculate.MouseUp
        btnCalculate.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub radCash_CheckedChanged(sender As Object, e As EventArgs) Handles radCash.CheckedChanged
        If radCash.Checked = True Then
            pnlCash.Enabled = True
            pnlCash.BackColor = Color.FromArgb(200, 0, 0, 0)
            pnlCash.ForeColor = Color.White
            picError.Visible = True
            lblErrorText.Visible = True
            btnCalculate.Enabled = True
            ValidatingInput()
        Else
            pnlCash.Enabled = False
            pnlCash.BackColor = Color.FromArgb(100, 0, 0, 0)
            pnlCash.ForeColor = Color.Silver
            picError.Visible = False
            lblErrorText.Visible = False
            btnCalculate.Enabled = False
        End If
    End Sub

    Private Sub radCard_CheckedChanged(sender As Object, e As EventArgs) Handles radCard.CheckedChanged
        If radCard.Checked = True Then
            pnlCard.Enabled = True
            pnlCard.BackColor = Color.FromArgb(200, 0, 0, 0)
            pnlCard.ForeColor = Color.White
            ValidatingInput()
        Else
            pnlCard.Enabled = False
            pnlCard.BackColor = Color.FromArgb(100, 0, 0, 0)
            pnlCard.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub Reserve_Step_3_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Shown

        Id.orderDay = Date.Now().ToString("dd")
        Id.orderMonth = Date.Now().ToString("MM")
        Id.orderYear = Date.Now().ToString("yyyy")

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        generatingID()
        Me.Close()
        Reserve_Step_4.Show()
    End Sub

    Private Sub generatingID()
        Id.orderNo = SystemSelection.orderCount
        If Home_Movie_Detail.type = "VIP" Then

            If Id.orderNo < 9 Then
                Reserve_Step_1___VIP__.orderMovie.orderID = "T" & "00" & Id.orderNo + 1
            ElseIf Id.orderNo >= 9 And Id.orderNo < 99 Then
                Reserve_Step_1___VIP__.orderMovie.orderID = "T" & "0" & Id.orderNo + 1
            ElseIf Id.orderNo >= 99 And Id.orderNo < 999 Then
                Reserve_Step_1___VIP__.orderMovie.orderID = "T" & Id.orderNo + 1
            End If

        ElseIf Home_Movie_Detail.type = "Standard" Then

            If Id.orderNo < 9 Then
                Reserve_Step_1___STD__.orderMovie.orderID = "T" & "00" & Id.orderNo + 1
            ElseIf Id.orderNo >= 9 And Id.orderNo < 99 Then
                Reserve_Step_1___STD__.orderMovie.orderID = "T" & "0" & Id.orderNo + 1
            ElseIf Id.orderNo >= 99 And Id.orderNo < 999 Then
                Reserve_Step_1___STD__.orderMovie.orderID = "T" & Id.orderNo + 1
            End If

        End If
    End Sub

    Private Sub ValidatingInput()
        If radCash.Checked Then
            If lblChange.Text = "" Then
                btnNext.Enabled = False
                Return
            End If
            If CDec(lblChange.Text) < 0 Then
                picError.Visible = True
                lblErrorText.Visible = True
                btnNext.Enabled = False
            Else
                picError.Visible = False
                lblErrorText.Visible = False
                btnNext.Enabled = True
            End If
        ElseIf radCard.Checked Then
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
        End If
    End Sub



    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim amountPaid, change As Decimal

        Try
            amountPaid = CDec(txtAmount.Text)
        Catch ex As Exception
            MessageBox.Show("Please enter Amount in decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        change = amountPaid - CDec(lblPrice.Text)
        lblChange.Text = FormatCurrency(change, 2)
        ValidatingInput()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        If Home_Movie_Detail.type = "VIP" Then
            Kiosk_Step_1___VIP__.Close()
        ElseIf Home_Movie_Detail.type = "Standard" Then
            Kiosk_Step_1__Standard_.Close()
        End If
        Home.Show()
    End Sub

    Private Sub mskCard_TextChanged(sender As Object, e As EventArgs) Handles mskCard.TextChanged, mskCVV.TextChanged, mskDate.TextChanged
        ValidatingInput()
    End Sub


End Class