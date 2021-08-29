Public Class SystemSelection
    Dim move As Boolean = False
    Dim locX, locY As Integer

    Friend orderCount As Integer

    Const conn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\user\Desktop\Assignment\Cinema Ticketing System\Cinema Ticketing System\DB Cinema.mdf';Integrated Security=True"

    Private Sub picClose_MouseHover(sender As Object, e As EventArgs) Handles picClose.MouseHover
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\CloseHover.png")
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Close.png")
    End Sub

    Private Sub picClose_MouseClick(sender As Object, e As MouseEventArgs) Handles picClose.MouseClick
        Me.Close()
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

    Private Sub MnuMove_Click(sender As Object, e As EventArgs) Handles MnuMove.Click
        Cursor.Position = Me.PointToScreen(New Point((pnlTop.Right + pnlTop.Left) / 2, (pnlTop.Top + pnlTop.Bottom) / 2))
    End Sub

    Private Sub MnuMinimize_Click(sender As Object, e As EventArgs) Handles MnuMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
    End Sub

    Private Sub pnlTop_MouseLeave(sender As Object, e As EventArgs) Handles pnlTop.MouseLeave
        picMinimize.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Minimize.png")
    End Sub

    Private Sub picHome_MouseHover(sender As Object, e As EventArgs) Handles picHome.MouseHover, lblHome.MouseHover
        picHome.Load("C:\Users\user\Desktop\Assignment\Picture\System Selection\HomeHover.png")
        lblHome.ForeColor = Color.Yellow
        pnlHome.BackColor = Color.FromArgb(200, 0, 0, 0)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picHome_MouseLeave(sender As Object, e As EventArgs) Handles picHome.MouseLeave, lblHome.MouseLeave
        picHome.Load("C:\Users\user\Desktop\Assignment\Picture\System Selection\Home.png")
        lblHome.ForeColor = Color.White
        pnlHome.BackColor = Color.FromArgb(100, 0, 0, 0)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub picKiosk_MouseHover(sender As Object, e As EventArgs) Handles picKiosk.MouseHover, lblKiosk.MouseHover
        picKiosk.Load("C:\Users\user\Desktop\Assignment\Picture\System Selection\KioskHover.png")
        lblKiosk.ForeColor = Color.Yellow
        pnlKiosk.BackColor = Color.FromArgb(200, 0, 0, 0)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub picKiosk_Click(sender As Object, e As EventArgs) Handles picKiosk.Click, lblKiosk.Click
        Me.Hide()
        Kiosk_Splash.Show()
    End Sub

    Private Sub picHome_Click(sender As Object, e As EventArgs) Handles picHome.Click, lblHome.Click
        Me.Hide()
        Home_Log_in.Show()
    End Sub

    Private Sub SystemSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlconn As New SqlClient.SqlConnection(conn)
        Dim sqlstring As String = "Select * From [Transaction]"
        Dim sqlcmd As New SqlClient.SqlCommand(sqlstring, sqlconn)
        Dim sqladpt As New SqlClient.SqlDataAdapter(sqlcmd)
        Dim datatables As New DataTable
        sqladpt.Fill(datatables)
        orderCount = datatables.Rows.Count
    End Sub

    Private Sub picKiosk_MouseLeave(sender As Object, e As EventArgs) Handles picKiosk.MouseLeave, lblKiosk.MouseLeave
        picKiosk.Load("C:\Users\user\Desktop\Assignment\Picture\System Selection\Kiosk.png")
        lblKiosk.ForeColor = Color.White
        pnlKiosk.BackColor = Color.FromArgb(100, 0, 0, 0)
        Me.Cursor = Cursors.Default
    End Sub

End Class