Imports System.Net.Mail

Public Class Forgot_Password
    Dim move As Boolean = False
    Dim locX, locY As Integer

    Dim conn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\user\Desktop\Assignment\Cinema Ticketing System\Cinema Ticketing System\DB Cinema.mdf';Integrated Security=True"
    Dim code As String
    Private Sub picClose_MouseHover(sender As Object, e As EventArgs) Handles picClose.MouseHover
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\CloseHover.png")
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Close.png")
    End Sub

    Private Sub picClose_MouseClick(sender As Object, e As MouseEventArgs) Handles picClose.MouseClick
        Me.Hide()
        Home_Log_in.Show()
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

    Private Sub btnCancel_Down(sender As Object, e As EventArgs) Handles btnCancel.MouseDown
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCancel_Up(sender As Object, e As EventArgs) Handles btnCancel.MouseUp
        btnCancel.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnConfirm_Down(sender As Object, e As EventArgs) Handles btnConfirm.MouseDown
        btnConfirm.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnConfirm_Up(sender As Object, e As EventArgs) Handles btnConfirm.MouseUp
        btnConfirm.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnCode_Down(sender As Object, e As MouseEventArgs) Handles btnCode.MouseDown
        btnCode.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnCode_Up(sender As Object, e As MouseEventArgs) Handles btnCode.MouseUp
        btnCode.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnCode_Click(sender As Object, e As EventArgs) Handles btnCode.Click
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
                num = CInt(Rnd() * 10)

                code = code & num
            Next
            MessageBox.Show("Code is " & code, "Getting Code", MessageBoxButtons.OK)
        Else
            MessageBox.Show("ID is doesn't Exist" & code, "Login Error", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If msktxtCode.Text = code Then
            MessageBox.Show("The retrieve password request will be sent to the High Management!", "Retrieve Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Home_Log_in.Show()
        Else
            MessageBox.Show("You have typed invalid code!", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuBack.Click, btnCancel.Click
        Me.Close()
        Home_Log_in.Show()
    End Sub

    Private Sub Forgot_Password_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtstaffID.ResetText()
        msktxtCode.ResetText()
    End Sub
End Class
