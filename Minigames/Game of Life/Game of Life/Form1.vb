Public Class Form1
    Public Structure Place
        Dim alive As Integer
        Dim controls() As Control
        Dim newAlive As Integer
    End Structure

    Public places(,) As Place
    Public randoms As New Random

    Private Sub initialize()
        Randomize()
        ReDim places(24, 39)
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                places(i, j).controls = Controls.Find("Label" & (i * 40 + j + 1), True)
                places(i, j).alive = 0
                places(i, j).newAlive = 0
            Next
        Next
    End Sub

    Private Sub random()
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                If Math.Floor(randoms.Next(1.99)) = 1 Then
                    places(i, j).alive = 1
                    places(i, j).controls(0).BackColor = Color.Black
                Else
                    places(i, j).alive = 0
                    places(i, j).controls(0).BackColor = Color.White
                End If
            Next
        Next

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
        random()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If btnStart.Text = "Start" Then
            TmGame.Start()
            btnStart.Text = "Stop"
            btnNext.Enabled = False
            btnReset.Enabled = False
            btnClear.Enabled = False
        Else
            TmGame.Stop()
            btnStart.Text = "Start"
            btnNext.Enabled = True
            btnReset.Enabled = True
            btnClear.Enabled = True
        End If

    End Sub

    Private Sub checklife()
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                If checkneighbour(places(i, j).alive, i, j) Then
                    places(i, j).newAlive = 1
                Else
                    places(i, j).newAlive = 0
                End If
            Next
        Next
    End Sub

    Private Function checkneighbour(ByVal alive As Integer, ByVal row As Integer, ByVal col As Integer)
        Dim sum As Integer = 0
        Select Case alive
            Case 1
                If row = 0 And col = 0 Then 'Left Top              
                    sum += places(row + 1, col).alive
                    sum += places(row + 1, col + 1).alive
                    sum += places(row, col + 1).alive
                ElseIf row = 0 And col = 39 Then 'Right Top
                    sum += places(row + 1, col).alive
                    sum += places(row + 1, col - 1).alive
                    sum += places(row, col - 1).alive
                ElseIf row = 24 And col = 0 Then 'Left Bottom
                    sum += places(row - 1, col).alive
                    sum += places(row - 1, col + 1).alive
                    sum += places(row, col + 1).alive
                ElseIf row = 24 And col = 39 Then 'Right Bottom
                    sum += places(row - 1, col).alive
                    sum += places(row - 1, col - 1).alive
                    sum += places(row, col - 1).alive
                Else
                    If row = 0 Then 'Top Side
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row + 1, col - 1).alive
                        sum += places(row, col - 1).alive
                    ElseIf row = 24 Then 'Botton Side
                        sum += places(row - 1, col).alive
                        sum += places(row - 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row - 1, col - 1).alive
                        sum += places(row, col - 1).alive
                    ElseIf col = 0 Then 'Left Side
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row - 1, col + 1).alive
                        sum += places(row - 1, col).alive
                    ElseIf col = 39 Then 'Right Side
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col - 1).alive
                        sum += places(row, col - 1).alive
                        sum += places(row - 1, col - 1).alive
                        sum += places(row - 1, col).alive
                    Else
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col - 1).alive
                        sum += places(row, col - 1).alive
                        sum += places(row - 1, col - 1).alive
                        sum += places(row - 1, col).alive
                        sum += places(row + 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row - 1, col + 1).alive
                    End If
                End If

                If sum = 2 Or sum = 3 Then
                    Return True
                Else
                    Return False
                End If
            Case 0
                If row = 0 And col = 0 Then 'Left Top              
                    sum += places(row + 1, col).alive
                    sum += places(row + 1, col + 1).alive
                    sum += places(row, col + 1).alive
                ElseIf row = 0 And col = 39 Then 'Right Top
                    sum += places(row + 1, col).alive
                    sum += places(row + 1, col - 1).alive
                    sum += places(row, col - 1).alive
                ElseIf row = 24 And col = 0 Then 'Left Bottom
                    sum += places(row - 1, col).alive
                    sum += places(row - 1, col + 1).alive
                    sum += places(row, col + 1).alive
                ElseIf row = 24 And col = 39 Then 'Right Bottom
                    sum += places(row - 1, col).alive
                    sum += places(row - 1, col - 1).alive
                    sum += places(row, col - 1).alive
                Else
                    If row = 0 Then 'Top Side
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row + 1, col - 1).alive
                        sum += places(row, col - 1).alive
                    ElseIf row = 24 Then 'Botton Side
                        sum += places(row - 1, col).alive
                        sum += places(row - 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row - 1, col - 1).alive
                        sum += places(row, col - 1).alive
                    ElseIf col = 0 Then 'Left Side
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row - 1, col + 1).alive
                        sum += places(row - 1, col).alive
                    ElseIf col = 39 Then 'Right Side
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col - 1).alive
                        sum += places(row, col - 1).alive
                        sum += places(row - 1, col - 1).alive
                        sum += places(row - 1, col).alive
                    Else
                        sum += places(row + 1, col).alive
                        sum += places(row + 1, col - 1).alive
                        sum += places(row, col - 1).alive
                        sum += places(row - 1, col - 1).alive
                        sum += places(row - 1, col).alive
                        sum += places(row + 1, col + 1).alive
                        sum += places(row, col + 1).alive
                        sum += places(row - 1, col + 1).alive
                    End If
                End If

                If sum = 3 Then
                    Return True
                Else
                    Return False
                End If
        End Select
        Return False
    End Function

    Private Sub updateplaces()
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                If places(i, j).newAlive = 1 Then
                    places(i, j).controls(0).BackColor = Color.Black
                Else
                    places(i, j).controls(0).BackColor = Color.White
                End If
                places(i, j).alive = places(i, j).newAlive
                places(i, j).newAlive = 0
            Next
        Next

        lblGenNo.Text = CInt(lblGenNo.Text) + 1
    End Sub

    Private Sub TmGame_Tick(sender As Object, e As EventArgs) Handles TmGame.Tick
        checklife()
        updateplaces()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        checklife()
        updateplaces()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                places(i, j).alive = 0
                places(i, j).controls(0).BackColor = Color.White
                places(i, j).newAlive = 0
            Next
        Next
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        random()
        lblGenNo.Text = 0
    End Sub

    Private Sub rad_CheckedChanged(sender As Object, e As EventArgs) Handles radMedium.CheckedChanged, radFast.CheckedChanged, radSlow.CheckedChanged
        If radSlow.Checked Then
            TmGame.Interval = 500
        ElseIf radMedium.Checked Then
            TmGame.Interval = 100
        ElseIf radFast.Checked Then
            TmGame.Interval = 10
        End If
    End Sub

End Class
