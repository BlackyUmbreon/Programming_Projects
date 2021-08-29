Public Class Form1
    Public Structure Place
        Dim id As Integer
        Dim dir As String
        Dim isSnake As Boolean
        Dim isFood As Boolean
        Dim growth As Boolean
        Dim controls() As Control
    End Structure

    Public Structure Snake
        Dim location As Integer
        Dim dir As String
    End Structure

    Public snakePlace(399) As Place
    Public snakelength() As Snake
    Public nextTail As Boolean
    Public foodAvailable As Boolean
    Dim randoms As New Random
    Dim timeGO As Integer
    Public play As Boolean = False

    Private Sub Initialize()
        For i = 0 To snakePlace.Length - 1 Step 1
            With snakePlace(i)
                .id = i + 1
                .dir = "right"
                .isFood = False
                .growth = False
                .isSnake = False
                .controls = Me.Controls.Find("Label" & i + 1, True)
            End With
        Next

        ReDim Preserve snakelength(2)

        For i = 0 To snakelength.Length - 1 Step 1
            With snakelength(i)
                .dir = "right"
                .location = 210 - i
            End With
        Next

        foodAvailable = True
    End Sub

    Private Sub UpdatePlace()
        For i = 0 To snakePlace.Length - 1 Step 1
            For j = 0 To snakelength.Length - 1 Step 1
                If snakePlace(i).id = snakelength(j).location Then
                    snakePlace(i).isSnake = True
                End If
            Next
        Next

        If foodAvailable Then
            newFood()
        End If

        For i = 0 To snakePlace.Length - 1 Step 1
            If snakePlace(i).isSnake Then
                snakePlace(i).controls(0).BackColor = Color.Black
                snakePlace(i).isSnake = False
            ElseIf snakePlace(i).isFood Then
                snakePlace(i).controls(0).BackColor = Color.Red
            Else
                snakePlace(i).controls(0).BackColor = SystemColors.Control
            End If
        Next
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Initialize()
        UpdatePlace()
        play = True
        tmMove.Start()
        Me.Focus()
        btnStart.Enabled = False
    End Sub

    Private Sub tmMove_Tick(sender As Object, e As EventArgs) Handles tmMove.Tick
        snakeMove()
    End Sub

    Private Sub newFood()
        Randomize()
        Dim duplicate As Boolean = True
        Dim foodPlace As Integer
        Do While duplicate
            duplicate = False
            foodPlace = randoms.Next(1, 400)
            If snakePlace(foodPlace - 1).isSnake Then
                duplicate = True
            End If

            If Not duplicate Then
                snakePlace(foodPlace - 1).isFood = True
            End If
        Loop
        foodAvailable = False
    End Sub

    Private Sub snakeMove()
        If checkDead(snakelength(0)) Then
            If nextTail Then
                For i = 0 To snakelength.Length - 2 Step 1
                    snakelength(i).dir = snakePlace(snakelength(i).location - 1).dir
                    If snakelength(i).dir = "right" Then
                        snakelength(i).location += 1
                    ElseIf snakelength(i).dir = "left" Then
                        snakelength(i).location -= 1
                    ElseIf snakelength(i).dir = "up" Then
                        snakelength(i).location -= 20
                    ElseIf snakelength(i).dir = "down" Then
                        snakelength(i).location += 20
                    End If
                    If snakePlace(snakelength(i).location - 1).isFood Then
                        snakePlace(snakelength(i).location - 1).growth = True
                        snakePlace(snakelength(i).location - 1).isFood = False
                        foodAvailable = True
                    End If
                Next
                nextTail = False
                snakePlace(snakelength(0).location - 1).dir = snakelength(0).dir
            Else
                For i = 0 To snakelength.Length - 1 Step 1
                    snakelength(i).dir = snakePlace(snakelength(i).location - 1).dir
                    If snakelength(i).dir = "left" Then
                        snakelength(i).location -= 1
                    ElseIf snakelength(i).dir = "right" Then
                        snakelength(i).location += 1
                    ElseIf snakelength(i).dir = "up" Then
                        snakelength(i).location -= 20
                    ElseIf snakelength(i).dir = "down" Then
                        snakelength(i).location += 20
                    End If
                    If snakePlace(snakelength(i).location - 1).isFood Then
                        snakePlace(snakelength(i).location - 1).growth = True
                        snakePlace(snakelength(i).location - 1).isFood = False
                        foodAvailable = True
                    End If
                Next
                If snakePlace(snakelength(snakelength.Length - 1).location - 1).growth Then
                    ReDim Preserve snakelength(snakelength.Length)
                    nextTail = True
                    snakelength(snakelength.Length - 1).location = snakelength(snakelength.Length - 2).location
                    snakelength(snakelength.Length - 1).dir = snakelength(snakelength.Length - 2).dir
                    snakePlace(snakelength(snakelength.Length - 1).location - 1).growth = False
                End If
                snakePlace(snakelength(0).location - 1).dir = snakelength(0).dir
            End If
            UpdatePlace()
        Else
            gameover()
        End If
    End Sub

    Private Sub gameover()
        timeGO = 0
        play = False
        tmGameOver.Start()
    End Sub

    Private Function checkDead(ByVal snake As Snake) As Boolean
        Dim eatYourself As Boolean = False
        If snake.dir = "right" Then
            Select Case snake.location
                Case 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280, 300, 320, 340, 360, 380, 400
                    Return False
                Case Else
                    For i = 0 To snakelength.Length - 2 Step 1
                        If snake.location + 1 = snakelength(i).location Then
                            eatYourself = True
                        End If
                    Next

                    If eatYourself Then
                        Return False
                    End If

                    Return True
            End Select
        ElseIf snake.dir = "left" Then
            Select Case snake.location
                Case 1, 21, 41, 61, 81, 101, 121, 141, 161, 181, 201, 221, 241, 261, 281, 301, 321, 341, 361, 381
                    Return False
                Case Else
                    For i = 0 To snakelength.Length - 2 Step 1
                        If snake.location - 1 = snakelength(i).location Then
                            eatYourself = True
                        End If
                    Next

                    If eatYourself Then
                        Return False
                    End If

                    Return True
            End Select
        ElseIf snake.dir = "up" Then
            Select Case snake.location
                Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
                    Return False
                Case Else
                    For i = 0 To snakelength.Length - 2 Step 1
                        If snake.location - 20 = snakelength(i).location Then
                            eatYourself = True
                        End If
                    Next

                    If eatYourself Then
                        Return False
                    End If

                    Return True
            End Select
        ElseIf snake.dir = "down" Then
            Select Case snake.location
                Case 381, 382, 383, 384, 385, 386, 387, 388, 389, 390, 391, 392, 393, 394, 395, 396, 397, 398, 399, 400
                    Return False
                Case Else
                    For i = 0 To snakelength.Length - 2 Step 1
                        If snake.location + 20 = snakelength(i).location Then
                            eatYourself = True
                        End If
                    Next

                    If eatYourself Then
                        Return False
                    End If

                    Return True
            End Select
        End If

        Return True
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If play Then
            Select Case e.KeyCode
                Case Keys.Up
                    If snakelength(0).dir <> "down" Then
                        tmMove.Stop()
                        snakePlace(snakelength(0).location - 1).dir = "up"
                        snakelength(0).dir = "up"
                        snakeMove()
                        UpdatePlace()
                        tmMove.Start()
                    End If
                Case Keys.Down
                    If snakelength(0).dir <> "up" Then
                        tmMove.Stop()
                        snakePlace(snakelength(0).location - 1).dir = "down"
                        snakelength(0).dir = "down"
                        snakeMove()
                        UpdatePlace()
                        tmMove.Start()
                    End If
                Case Keys.Left
                    If snakelength(0).dir <> "right" Then
                        tmMove.Stop()
                        snakePlace(snakelength(0).location - 1).dir = "left"
                        snakelength(0).dir = "left"
                        snakeMove()
                        UpdatePlace()
                        tmMove.Start()
                    End If
                Case Keys.Right
                    If snakelength(0).dir <> "left" Then
                        tmMove.Stop()
                        snakePlace(snakelength(0).location - 1).dir = "right"
                        snakelength(0).dir = "right"
                        snakeMove()
                        UpdatePlace()
                        tmMove.Start()
                    End If
            End Select
        End If
    End Sub

    Private Sub tmGameOver_Tick(sender As Object, e As EventArgs) Handles tmGameOver.Tick
        If timeGO <= 381 Then
            tmMove.Stop()
            snakePlace(timeGO).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 1).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 2).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 3).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 4).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 5).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 6).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 7).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 8).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 9).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 10).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 11).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 12).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 13).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 14).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 15).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 16).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 17).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 18).controls(0).BackColor = Color.Red
            snakePlace(timeGO + 19).controls(0).BackColor = Color.Red
            timeGO += 20
        Else
            tmGameOver.Stop()
            MessageBox.Show("You Died!", "Game Over", MessageBoxButtons.OK)
            btnStart.Enabled = True
        End If

    End Sub
End Class
