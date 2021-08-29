Public Class Home_Log_in
    Dim move As Boolean = False
    Dim locX, locY As Integer
    Dim wait As Integer = 0
    Dim count As Integer = 0

    Friend staffID As String
    Dim code As String
    Dim conn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\user\Desktop\Assignment\Cinema Ticketing System\Cinema Ticketing System\DB Cinema.mdf';Integrated Security=True"
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

    Private Sub btnExit_Down(sender As Object, e As EventArgs) Handles btnExit.MouseDown
        btnExit.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnExit_Up(sender As Object, e As EventArgs) Handles btnExit.MouseUp
        btnExit.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnsignIn_Down(sender As Object, e As EventArgs) Handles btnsignIn.MouseDown
        btnsignIn.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnsignIn_Up(sender As Object, e As EventArgs) Handles btnsignIn.MouseUp
        btnsignIn.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnCode_Down(sender As Object, e As MouseEventArgs) Handles btnsendCode.MouseDown
        btnsendCode.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCode_Up(sender As Object, e As MouseEventArgs) Handles btnsendCode.MouseUp
        btnsendCode.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
        End
    End Sub

    Private Sub lblForgot_MouseHover(sender As Object, e As EventArgs) Handles lklblForgot.MouseHover
        lklblForgot.ForeColor = Color.DodgerBlue
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblForgot_Click(sender As Object, e As EventArgs) Handles lklblForgot.Click
        Me.Hide()
        Forgot_Password.show()
        lklblForgot.ForeColor = Color.White
    End Sub

    Private Sub lblForgot_MouseDown(sender As Object, e As EventArgs) Handles lklblForgot.MouseDown
        lklblForgot.ForeColor = Color.MediumPurple
    End Sub

    Private Sub lblForgot_MouseUp(sender As Object, e As EventArgs) Handles lklblForgot.MouseUp
        lklblForgot.ForeColor = Color.White
    End Sub

    Private Sub btnsignIn_Click(sender As Object, e As EventArgs) Handles btnsignIn.Click
        StaffTableAdapter.Fill(DB_CinemaDataSet.Staff)
        For i = 0 To DB_CinemaDataSet.Staff.Rows.Count - 1
            If DB_CinemaDataSet.Staff.Rows(i).Item(0) = txtstaffID.Text Then
                If DB_CinemaDataSet.Staff.Rows(i).Item(5) = "False" Then
                    MessageBox.Show("Your account has been banned!" & vbCrLf & "Please refer to Manager in order to remove ban!", "Account Banned", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
        Next

        If mskCode.Text = code Then
            wait = 0
            Please_wait.Show()
            tmWait.Start()
        Else
            MessageBox.Show("Invalid Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub lblForgot_MouseLeave(sender As Object, e As EventArgs) Handles lklblForgot.MouseLeave
        lklblForgot.ForeColor = Color.White
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tmWait_Tick(sender As Object, e As EventArgs) Handles tmWait.Tick
        wait += 1
        Dim strCommand As String = "Select * from Staff where [id] ='" & txtstaffID.Text & "' AND [Password] = '" & txtPassword.Text & "'"
        If wait > 8 Then
            Dim sqlconn As New SqlClient.SqlConnection(conn)
            sqlconn.Open()
            Dim sqlcmd As New SqlClient.SqlCommand(strCommand, sqlconn)
            tmWait.Stop()
            Dim adpt As New SqlClient.SqlDataAdapter(sqlcmd)
            Dim table As New DataTable
            adpt.Fill(table)
            If sqlcmd.ExecuteReader.Read Then
                staffID = table.Rows(0).Item(0)
                txtPassword.ResetText()
                txtstaffID.ResetText()
                mskCode.ResetText()
                Me.Hide()
                count = 3
                Home.Show()
            Else
                count -= 1
                MessageBox.Show("You enter the incorrect password!" & vbCrLf & "Attempt left : " & count & " left", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If count = 0 Then
                    For i = 0 To DB_CinemaDataSet.Staff.Rows.Count - 1 Step 1
                        If DB_CinemaDataSet.Staff.Rows(i).Item(0) = txtstaffID.Text Then
                            DB_CinemaDataSet.Staff.Rows(i).Item(5) = "False"
                            StaffTableAdapter.Update(DB_CinemaDataSet)
                            MessageBox.Show("Staff ID [" & DB_CinemaDataSet.Staff.Rows(i).Item(0) & "] has been banned!", "Account Banned", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Next
                    count = 3
                End If
            End If

        End If
    End Sub

    Private Sub btnsendCode_Click(sender As Object, e As EventArgs) Handles btnsendCode.Click
        Dim sqlconn As New SqlClient.SqlConnection(conn)
        sqlconn.Open()
        Dim sqlcmd As New SqlClient.SqlCommand
        Dim strSQL As String = "Select * From Staff Where Id = '" & txtstaffID.Text & "'"
        code = ""
        sqlcmd = New SqlClient.SqlCommand(strSQL, sqlconn)
        If sqlcmd.ExecuteReader.Read Then
            Dim num As Integer
            Dim i As Integer

            For i = 0 To 3 Step 1
                num = CInt(Rnd() * 9)

                code = code & num
            Next
            MessageBox.Show("Code is " & code, "Getting Code", MessageBoxButtons.OK)
        Else
            MessageBox.Show("ID is doesn't Exist" & code, "Login Error", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        End
    End Sub

    Private Sub Home_Log_in_Load(sender As Object, e As EventArgs) Handles Me.Load
        count = 3
        Dim num As Integer
        Dim i As Integer
        code = ""
        For i = 0 To 3 Step 1
            num = CInt(Rnd() * 9)

            code = code & num
        Next
    End Sub


End Class
