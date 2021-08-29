Public Class Form1

    Public OX(2, 2) As String
    Public turn As Integer
    Dim randoms As New Random
    Dim endPlay As Boolean
    Public OXBool(2, 2) As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
        handlerButton()
        endPlay = False
    End Sub

    Private Function whichturn() As Integer
        Randomize()
        Dim turn As Integer = randoms.Next(0, 2)
        Return turn
    End Function

    Private Sub initialize()
        OX = {{"", "", ""}, {"", "", ""}, {"", "", ""}}
        OXBool = {{True, True, True}, {True, True, True}, {True, True, True}}
        turn = whichturn()
        If turn = 0 Then
            lblTurn.Text = "O"
        ElseIf turn = 1 Then
            lblTurn.Text = "X"
        End If
    End Sub

    Private Sub handlerButton()
        Dim controls() As Control
        For i = 1 To OX.GetLength(1)
            For j = 1 To OX.GetLength(0)
                controls = Me.Controls.Find("btn" & i & j, True)
                AddHandler controls(0).Click, AddressOf clickPlay
            Next
        Next
    End Sub

    Public Sub turnPut(ByVal turn As Integer, ByVal target As Button)
        Dim number As String
        If turn = 0 Then
            number = target.Name.Substring(3, 2)
            If OXBool(CInt(number.Substring(0, 1)) - 1, CInt(number.Substring(1, 1)) - 1) Then
                target.Text = "O"
                target.ForeColor = Color.Blue
                OX(CInt(number.Substring(0, 1)) - 1, CInt(number.Substring(1, 1)) - 1) = "O"
                OXBool(CInt(number.Substring(0, 1)) - 1, CInt(number.Substring(1, 1)) - 1) = False
            End If
        ElseIf turn = 1 Then
            number = target.Name.Substring(3, 2)
            If OXBool(CInt(number.Substring(0, 1)) - 1, CInt(number.Substring(1, 1)) - 1) Then
                target.Text = "X"
                target.ForeColor = Color.Red
                OX(CInt(number.Substring(0, 1)) - 1, CInt(number.Substring(1, 1)) - 1) = "X"
                OXBool(CInt(number.Substring(0, 1)) - 1, CInt(number.Substring(1, 1)) - 1) = False
            End If
        End If
    End Sub

    Private Sub clickPlay(sender As Object, e As EventArgs)
        Dim target As Button = CType(sender, Button)
        If Not endPlay Then
            If turn = 0 Then
                turnPut(turn, target)
                turn = 1
                lblTurn.Text = "X"
            ElseIf turn = 1 Then
                turnPut(turn, target)
                turn = 0
                lblTurn.Text = "O"
            End If
            checkwin()
        End If


    End Sub

    Private Sub win(ByVal letter As String)
        If letter = "O" Then
            MessageBox.Show("Player 1 Win", "Winner", MessageBoxButtons.OK)
            endPlay = True
            btnReset.Focus()
        ElseIf letter = "X" Then
            MessageBox.Show("Player 2 Win", "Winner", MessageBoxButtons.OK)
            endPlay = True
            btnReset.Focus()
        ElseIf letter = "T" Then
            MessageBox.Show("Tied", "Winner", MessageBoxButtons.OK)
            endPlay = True
            btnReset.Focus()
        End If

    End Sub

    Private Sub checkwin()
        If Not OXBool(0, 0) And Not OXBool(0, 1) And Not OXBool(0, 2) Then 'First Row
            If OX(0, 0) = OX(0, 1) And OX(0, 0) = OX(0, 2) And OX(0, 1) = OX(0, 2) Then
                win(OX(0, 0))
            End If
        End If
        If Not OXBool(1, 0) And Not OXBool(1, 1) And Not OXBool(1, 2) Then 'Second Row
                If OX(1, 0) = OX(1, 1) And OX(1, 0) = OX(1, 2) And OX(1, 1) = OX(1, 2) Then
                    win(OX(1, 0))
                End If
            End If
            If Not OXBool(2, 0) And Not OXBool(2, 1) And Not OXBool(2, 2) Then 'Third Row
                    If OX(2, 0) = OX(2, 1) And OX(2, 0) = OX(2, 2) And OX(2, 1) = OX(2, 2) Then
                        win(OX(2, 0))
                    End If
                End If
                If Not OXBool(0, 0) And Not OXBool(1, 1) And Not OXBool(2, 2) Then 'Diagonal \
                        If OX(0, 0) = OX(1, 1) And OX(0, 0) = OX(2, 2) And OX(1, 1) = OX(2, 2) Then
                            win(OX(0, 0))
                        End If
                    End If
                    If Not OXBool(0, 2) And Not OXBool(1, 1) And Not OXBool(2, 0) Then 'Diagonal /
                            If OX(0, 2) = OX(1, 1) And OX(0, 2) = OX(2, 0) And OX(1, 1) = OX(2, 0) Then
                                win(OX(0, 2))
                            End If
                        End If
                        If Not OXBool(0, 0) And Not OXBool(1, 0) And Not OXBool(2, 0) Then 'First Column
                                If OX(0, 0) = OX(1, 0) And OX(0, 0) = OX(2, 0) And OX(1, 0) = OX(2, 0) Then
                                    win(OX(0, 0))
                                End If
                            End If
                            If Not OXBool(0, 1) And Not OXBool(1, 1) And Not OXBool(2, 1) Then 'Second Column
                                    If OX(0, 1) = OX(1, 1) And OX(0, 1) = OX(2, 1) And OX(1, 1) = OX(2, 1) Then
                                        win(OX(0, 1))
                                    End If
                                End If
                                If Not OXBool(0, 2) And Not OXBool(1, 2) And Not OXBool(2, 2) Then 'Third Column
                                        If OX(0, 2) = OX(1, 2) And OX(0, 2) = OX(2, 2) And OX(1, 2) = OX(2, 2) Then
                                            win(OX(0, 2))
                                        End If
                                    End If
                                    If Not OXBool(0, 0) And Not OXBool(0, 1) And Not OXBool(0, 2) And Not OXBool(1, 0) And Not OXBool(1, 1) And Not OXBool(1, 2) And Not OXBool(2, 0) And Not OXBool(2, 1) And Not OXBool(2, 2) Then
                                            If OX(0, 0) <> "" And OX(0, 1) <> "" And OX(0, 2) <> "" And OX(1, 0) <> "" And OX(1, 1) <> "" And OX(1, 2) <> "" And OX(2, 0) <> "" And OX(2, 1) <> "" And OX(2, 2) <> "" Then
                If Not endPlay Then
                    win("T")
                End If

            End If
                                        End If

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim controls() As Control
        OX = {{"", "", ""}, {"", "", ""}, {"", "", ""}}
        OXBool = {{True, True, True}, {True, True, True}, {True, True, True}}
        For i = 1 To OX.GetLength(1)
            For j = 1 To OX.GetLength(0)
                Controls = Me.Controls.Find("btn" & i & j, True)
                Controls(0).Text = ""
            Next
        Next
        endPlay = False
        turn = whichturn()
        If turn = 0 Then
            lblTurn.Text = "O"
        ElseIf turn = 1 Then
            lblTurn.Text = "X"
        End If
    End Sub
End Class
