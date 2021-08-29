Public Class Easy
    Public Structure mine
        Dim id As String
        Dim status As Boolean
        Dim isBomb As Boolean
        Dim numBomb As Integer
    End Structure

    Public mineplace(9, 9) As mine
    Public rows(9) As Char
    Public mineSet As Boolean
    Const mineNum As Integer = 15

    Private Sub handlesMine()
        Dim row As Integer
        Dim col As Integer
        Dim controls() As Control

        For row = 0 To 9 Step 1
            For col = 0 To 9 Step 1
                controls = Me.Controls.Find("btn" & rows(row) & col + 1, True)
                AddHandler controls(0).MouseDown, AddressOf mine_Click
            Next
        Next
    End Sub

    Private Sub setMine(ByVal rowSe As Integer, ByVal colSe As Integer)
        Randomize()
        Dim row As Integer
        Dim col As Integer
        Dim randomMine(mineNum - 1) As String
        Dim randomID As String
        Dim duplicate As Boolean
        Dim randoms As New Random
        Dim randomsNum As Integer
        Dim count = 0
        Dim idSe As String = mineplace(rowSe, colSe).id

        For i = 0 To mineNum - 1 Step 1
            duplicate = False
            randomsNum = randoms.Next(1, 100)

            If randomsNum Mod 10 = 0 Then
                randomID = rows(Math.Floor(randomsNum / 10) - 1) & 10
            Else
                randomID = rows(Math.Floor(randomsNum / 10)) & randomsNum Mod 10
            End If

            If randomID = idSe Then
                i -= 1
                duplicate = True
            End If

            For j = 0 To count - 1 Step 1
                If randomMine(j) = randomID Then
                    i -= 1
                    duplicate = True
                End If
            Next

            If Not duplicate Then
                randomMine(i) = randomID
                count += 1
            End If
        Next

        For row = 0 To mineplace.GetLength(1) - 1
            For col = 0 To mineplace.GetLength(0) - 1
                For i = 0 To randomMine.Length - 1 Step 1
                    If randomMine(i) = mineplace(row, col).id Then
                        mineplace(row, col).isBomb = True
                        randomMine(i) = ""

                    End If
                Next
            Next
        Next
        mineSetNum()
    End Sub

    Private Sub mineSetNum()
        Dim row As Integer
        Dim col As Integer
        For row = 0 To mineplace.GetLength(1) - 1
            For col = 0 To mineplace.GetLength(0) - 1
                If row = 0 Then
                    If col = 0 Then
                        If mineplace(row + 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    ElseIf col = 9 Then
                        If mineplace(row + 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    ElseIf col > 0 And col < 9 Then
                        If mineplace(row + 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    End If
                    ElseIf row = 9 Then
                    If col = 0 Then
                        If mineplace(row - 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    ElseIf col = 9 Then
                        If mineplace(row - 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    ElseIf col > 0 And col < 9 Then
                        If mineplace(row - 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    End If
                ElseIf row > 0 And row < 9 Then
                    If col = 0 Then
                        If mineplace(row + 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    ElseIf col = 9 Then
                        If mineplace(row + 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    ElseIf col > 0 And col < 9 Then
                        If mineplace(row + 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col - 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row - 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                        If mineplace(row + 1, col + 1).isBomb Then
                            mineplace(row, col).numBomb += 1
                        End If
                    End If
                    End If
            Next
        Next

    End Sub

    Private Sub setPlace()
        rows = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"}
        Dim row As Integer
        Dim col As Integer

        For row = 0 To mineplace.GetLength(1) - 1
            For col = 0 To mineplace.GetLength(0) - 1
                mineplace(row, col).id = rows(row) & col + 1
                mineplace(row, col).status = True
                mineplace(row, col).isBomb = False
            Next
        Next
    End Sub

    Private Sub Easy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setPlace()
        handlesMine()
        picemoji.Load("C:\Users\user\Desktop\Minigames\Minesweeper\Happy.png")
        mineSet = True
    End Sub

    Private Sub mine_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim controls As Button = CType(sender, Button)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If controls.Name.Length = 6 Then
                mineStart(controls.Name.Substring(3, 3))
            ElseIf controls.Name.Length = 5 Then
                mineStart(controls.Name.Substring(3, 2))
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If controls.Text = "" Then
                controls.Text = "F"
            ElseIf controls.Text = "F" Then
                controls.Text = "?"
            ElseIf controls.Text = "?" Then
                controls.Text = ""
            End If
        End If


    End Sub

    Private Sub mineStart(ByVal id As String)
        Dim repeat As Boolean = True

        Dim row As Integer
        Dim col As Integer


        For row = 0 To mineplace.GetLength(1) - 1
            For col = 0 To mineplace.GetLength(0) - 1
                If mineplace(row, col).id = id Then
                    If mineSet Then
                        setMine(row, col)
                        mineSet = False
                    End If
                    repeat = mineCheck(row, col)
                End If

                If Not repeat Then
                    Exit For
                End If
            Next
            If Not repeat Then
                Exit For
            End If
        Next
    End Sub

    Private Function mineCheck(ByVal row As Integer, ByVal col As Integer) As Boolean
        If mineplace(row, col).isBomb Then
            gameOver()
        Else
            mineUpdate(row, col)
        End If

        If finalCheck() Then
            win()
        End If
        Return False
    End Function

    Private Sub mineUpdate(ByVal row As Integer, ByVal col As Integer)
        Dim repeatSearch As Boolean = True
        mineplace(row, col).status = False

        Dim rows As Integer
        Dim cols As Integer

        Dim controls() As Control

        Do While repeatSearch
            repeatSearch = False
            For rows = 0 To mineplace.GetLength(1) - 1 Step 1
                For cols = 0 To mineplace.GetLength(0) - 1 Step 1
                    If Not mineplace(rows, cols).status Then
                        If mineplace(rows, cols).numBomb = 0 Then
                            repeatSearch = mineForZero(rows, cols)
                        End If
                    End If
                Next
            Next
        Loop

        For rows = 0 To mineplace.GetLength(1) - 1 Step 1
            For cols = 0 To mineplace.GetLength(0) - 1 Step 1
                If Not mineplace(rows, cols).status Then
                    controls = Me.Controls.Find("btn" & mineplace(rows, cols).id, True)
                    controls(0).BackColor = Color.LightGray
                    If controls(0).Text = "F" Then
                        controls(0).Text = ""
                    ElseIf controls(0).Text = "?" Then
                        controls(0).Text = ""
                    End If
                    Select Case mineplace(rows, cols).numBomb
                        Case 1
                            controls(0).ForeColor = Color.Green
                            controls(0).Text = "1"
                        Case 2
                            controls(0).ForeColor = Color.Lime
                            controls(0).Text = "2"
                        Case 3
                            controls(0).ForeColor = Color.GreenYellow
                            controls(0).Text = "3"
                        Case 4
                            controls(0).ForeColor = Color.Yellow
                            controls(0).Text = "4"
                        Case 5
                            controls(0).ForeColor = Color.Orange
                            controls(0).Text = "5"
                        Case 6
                            controls(0).ForeColor = Color.OrangeRed
                            controls(0).Text = "6"
                        Case 7
                            controls(0).ForeColor = Color.Red
                            controls(0).Text = "7"
                        Case 8
                            controls(0).ForeColor = Color.DarkRed
                            controls(0).Text = "8"
                        Case Else
                            controls(0).Text = ""
                    End Select
                End If
            Next
        Next
    End Sub

    Private Function mineForZero(ByVal row As Integer, ByVal col As Integer) As Boolean
        If row = 0 Then
            If col = 0 Then
                mineplace(row + 1, col).status = False
                mineplace(row + 1, col + 1).status = False
                mineplace(row, col + 1).status = False
                mineplace(row, col).numBomb = -1
            ElseIf col = 9 Then
                mineplace(row + 1, col).status = False
                mineplace(row + 1, col - 1).status = False
                mineplace(row, col - 1).status = False
                mineplace(row, col).numBomb = -1
            ElseIf col > 0 And col < 9 Then
                mineplace(row + 1, col).status = False
                mineplace(row + 1, col - 1).status = False
                mineplace(row, col - 1).status = False
                mineplace(row + 1, col + 1).status = False
                mineplace(row, col + 1).status = False
                mineplace(row, col).numBomb = -1
            End If
        ElseIf row = 9 Then
            If col = 0 Then
                mineplace(row - 1, col).status = False
                mineplace(row - 1, col + 1).status = False
                mineplace(row, col + 1).status = False
                mineplace(row, col).numBomb = -1
            ElseIf col = 9 Then
                mineplace(row - 1, col).status = False
                mineplace(row - 1, col - 1).status = False
                mineplace(row, col - 1).status = False
                mineplace(row, col).numBomb = -1
            ElseIf col > 0 And col < 9 Then
                mineplace(row - 1, col).status = False
                mineplace(row - 1, col - 1).status = False
                mineplace(row, col - 1).status = False
                mineplace(row - 1, col + 1).status = False
                mineplace(row, col + 1).status = False
                mineplace(row, col).numBomb = -1
            End If
        ElseIf row > 0 And row < 9 Then
            If col = 0 Then
                mineplace(row + 1, col).status = False
                mineplace(row - 1, col).status = False
                mineplace(row, col + 1).status = False
                mineplace(row - 1, col + 1).status = False
                mineplace(row + 1, col + 1).status = False
                mineplace(row, col).numBomb = -1
            ElseIf col = 9 Then
                mineplace(row + 1, col).status = False
                mineplace(row - 1, col).status = False
                mineplace(row, col - 1).status = False
                mineplace(row - 1, col - 1).status = False
                mineplace(row + 1, col - 1).status = False
                mineplace(row, col).numBomb = -1
            ElseIf col > 0 And col < 9 Then
                mineplace(row + 1, col).status = False
                mineplace(row - 1, col).status = False
                mineplace(row, col - 1).status = False
                mineplace(row, col + 1).status = False
                mineplace(row - 1, col - 1).status = False
                mineplace(row + 1, col - 1).status = False
                mineplace(row - 1, col + 1).status = False
                mineplace(row + 1, col + 1).status = False
                mineplace(row, col).numBomb = -1
            End If
        End If
        Return True
    End Function

    Private Function finalCheck() As Boolean
        Dim rows As Integer
        Dim cols As Integer
        Dim numDone As Integer = 0

        For rows = 0 To mineplace.GetLength(1) - 1 Step 1
            For cols = 0 To mineplace.GetLength(0) - 1 Step 1
                If Not mineplace(rows, cols).status Then
                    numDone += 1
                End If
            Next
        Next

        If numDone = mineplace.Length - mineNum Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub gameOver()
        gbMine.Enabled = False

        Dim rows As Integer
        Dim cols As Integer

        Dim controls() As Control

        For rows = 0 To mineplace.GetLength(1) - 1 Step 1
            For cols = 0 To mineplace.GetLength(0) - 1 Step 1
                If mineplace(rows, cols).isBomb Then
                    controls = Me.Controls.Find("btn" & mineplace(rows, cols).id, True)
                    If controls(0).Text = "F" Then
                        controls(0).Text = ""
                    ElseIf controls(0).Text = "?" Then
                        controls(0).Text = ""
                    End If
                    controls(0).BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Minigames\Minesweeper\Bomb.png")
                End If
                controls = Me.Controls.Find("btn" & mineplace(rows, cols).id, True)
                If controls(0).Text = "F" Then
                    If Not mineplace(rows, cols).isBomb Then
                        controls(0).Text = "X"
                    Else
                        controls(0).Text = ""
                    End If
                ElseIf controls(0).Text = "?" Then
                    If Not mineplace(rows, cols).isBomb Then
                        controls(0).Text = "X"
                    Else
                        controls(0).Text = ""
                    End If
                End If
            Next
        Next
        picemoji.Load("C:\Users\user\Desktop\Minigames\Minesweeper\Died.png")
        My.Computer.Audio.Play("C:\Users\user\Desktop\Minigames\Minesweeper\Fail.wav")
        Message.Show()
        Message.lblMessage.Text = "You Lose"
    End Sub

    Private Sub win()
        gbMine.Enabled = False

        Dim rows As Integer
        Dim cols As Integer

        Dim controls() As Control

        For rows = 0 To mineplace.GetLength(1) - 1 Step 1
            For cols = 0 To mineplace.GetLength(0) - 1 Step 1
                If mineplace(rows, cols).isBomb Then
                    controls = Me.Controls.Find("btn" & mineplace(rows, cols).id, True)
                    If controls(0).Text = "F" Then
                        controls(0).Text = ""
                    ElseIf controls(0).Text = "?" Then
                        controls(0).Text = ""
                    End If
                    controls(0).BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Minigames\Minesweeper\Flower.png")
                End If

            Next
        Next
        picemoji.Load("C:\Users\user\Desktop\Minigames\Minesweeper\Win.png")
        My.Computer.Audio.Play("C:\Users\user\Desktop\Minigames\Minesweeper\Victory.wav")
        Message.Show()
        Message.lblMessage.Text = "You Win"
    End Sub

    Private Sub resetBomb()
        Dim rows As Integer
        Dim cols As Integer

        Dim controls() As Control

        For rows = 0 To mineplace.GetLength(1) - 1 Step 1
            For cols = 0 To mineplace.GetLength(0) - 1 Step 1
                mineplace(rows, cols).isBomb = False
                mineplace(rows, cols).status = True
                mineplace(rows, cols).numBomb = 0
                controls = Me.Controls.Find("btn" & mineplace(rows, cols).id, True)
                controls(0).Text = ""
                controls(0).BackgroundImage = Nothing
                controls(0).ForeColor = SystemColors.ControlText
                controls(0).BackColor = SystemColors.Control
                picemoji.Load("C:\Users\user\Desktop\Minigames\Minesweeper\Happy.png")
            Next
        Next

        mineSet = True
        gbMine.Enabled = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        resetBomb()
    End Sub
End Class
