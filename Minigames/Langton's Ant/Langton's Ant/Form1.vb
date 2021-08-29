Public Class Form1
    Public Enum direction
        up
        down
        left
        right
    End Enum

    Public Structure antPlace
        Dim controls() As Control
        Dim Isexplore As Boolean
    End Structure

    Public Structure Ant
        Dim dir As direction
        Dim onWhereX As Integer
        Dim onWhereY As Integer
    End Structure

    Public randoms As New Random
    Public ants As Ant
    Public places(,) As antPlace
    Public movesIndex(7) As Integer
    Public MaximunMove As Integer
    Public antSymbol As Char = Chr(230)

    Private Sub initializePlace()
        ReDim places(24, 39)
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                places(i, j).controls = Controls.Find("Label" & (i * 40 + j + 1), True)
                places(i, j).controls(0).ForeColor = Color.Black
                places(i, j).Isexplore = False
            Next
        Next
    End Sub

    Private Sub initializeAnt()
        Randomize()
        ants.dir = direction.right
        ants.onWhereX = Math.Floor(randoms.Next(0, 39.9))
        ants.onWhereY = Math.Floor(randoms.Next(0, 24.9))

        places(ants.onWhereY, ants.onWhereX).controls(0).Text = antSymbol
    End Sub

    Private Sub initializeDir()
        Dim addChk() As Control
        Dim addBtn() As Control
        For i = 0 To 7
            addChk = Controls.Find("chkD" & (i + 1), True)
            addBtn = Controls.Find("btnD" & (i + 1), True)
            AddHandler CType(addChk(0), CheckBox).CheckedChanged, AddressOf enableOrDisable
            AddHandler addBtn(0).Click, AddressOf changeDirection
        Next
    End Sub

    Private Sub initialize()
        initializePlace()
        initializeAnt()
        initializeDir()
        movesIndex = {-1, -1, -1, -1, -1, -1, -1, -1}
        MaximunMove = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If btnStart.Text = "Start" Then
            If MaximunMove > 1 Then
                If chkD1.Checked Then
                    tmMove.Start()
                    btnStart.Text = "Stop"
                    gbDir.Enabled = False
                    btnReset.Enabled = False
                    btnNext.Enabled = False
                    chkEndless.Enabled = False
                Else
                    MessageBox.Show("Please tick the white one, White is default moves", "Langton's Ant", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("Please Make Sure the ant moves is more than 1.", "Langton's Ant", MessageBoxButtons.OK)
            End If
        ElseIf btnStart.Text = "Stop" Then
            tmMove.Stop()
            btnStart.Text = "Start"
            btnReset.Enabled = True
            btnNext.Enabled = True
        End If
    End Sub

    Private Sub changeDirection()
        For i = 0 To MaximunMove - 1
            If places(ants.onWhereY, ants.onWhereX).controls(0).BackColor = Controls.Find("lblD" & (movesIndex(i) + 1), True)(0).BackColor Then
                Select Case Controls.Find("btnD" & (movesIndex(i) + 1), True)(0).Text
                    Case "L"
                        Select Case ants.dir
                            Case direction.up
                                ants.dir = direction.left
                            Case direction.left
                                ants.dir = direction.down
                            Case direction.down
                                ants.dir = direction.right
                            Case direction.right
                                ants.dir = direction.up
                        End Select
                    Case "R"
                        Select Case ants.dir
                            Case direction.up
                                ants.dir = direction.right
                            Case direction.left
                                ants.dir = direction.up
                            Case direction.down
                                ants.dir = direction.left
                            Case direction.right
                                ants.dir = direction.down
                        End Select
                End Select
                Exit For
            End If
        Next
    End Sub

    Private Sub changePlace()
        For i = 0 To MaximunMove - 1
            If places(ants.onWhereY, ants.onWhereX).controls(0).BackColor = Controls.Find("lblD" & (movesIndex(i) + 1), True)(0).BackColor Then
                If i = MaximunMove - 1 Then
                    places(ants.onWhereY, ants.onWhereX).controls(0).BackColor = Controls.Find("lblD" & 1, True)(0).BackColor
                Else
                    places(ants.onWhereY, ants.onWhereX).controls(0).BackColor = Controls.Find("lblD" & (movesIndex(i + 1) + 1), True)(0).BackColor
                End If
                places(ants.onWhereY, ants.onWhereX).Isexplore = True
                Exit For
            End If
        Next
    End Sub

    Private Sub moveAnts()
        places(ants.onWhereY, ants.onWhereX).controls(0).Text = ""
        Select Case ants.dir
            Case direction.up
                If ants.onWhereY = 0 Then
                    ants.onWhereY = 24
                Else
                    ants.onWhereY -= 1
                End If
            Case direction.left
                If ants.onWhereX = 0 Then
                    ants.onWhereX = 39
                Else
                    ants.onWhereX -= 1
                End If
            Case direction.down
                If ants.onWhereY = 24 Then
                    ants.onWhereY = 0
                Else
                    ants.onWhereY += 1
                End If
            Case direction.right
                If ants.onWhereX = 39 Then
                    ants.onWhereX = 0
                Else
                    ants.onWhereX += 1
                End If
        End Select
        places(ants.onWhereY, ants.onWhereX).controls(0).Text = antSymbol
        lblMoveNo.Text = CInt(lblMoveNo.Text) + 1
    End Sub

    Private Sub checkEnd()
        Dim endExplore As Boolean = True
        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                If Not places(i, j).Isexplore Then
                    endExplore = False
                End If
            Next
        Next

        If endExplore Then
            tmMove.Stop()
            btnStart.Text = "Start"
            btnReset.Enabled = True
            btnStart.Enabled = False
            MessageBox.Show("Ant : I finish my explore!", "Langton's Ant", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub enableOrDisable(ByVal sender As Object, e As EventArgs)
        For i = 0 To 7
            movesIndex(i) = -1
        Next
        MaximunMove = 0

        Dim chk() As Control
        For i = 0 To 7
            chk = Controls.Find("chkD" & (i + 1), True)
            If CType(chk(0), CheckBox).Checked Then
                movesIndex(MaximunMove) = i
                MaximunMove += 1
            End If
        Next
    End Sub

    Private Sub changeDirection(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim btn As Button = CType(sender, Button)
        If btn.Text = "L" Then
            btn.Text = "R"
        ElseIf btn.Text = "R" Then
            btn.Text = "L"
        End If
    End Sub

    Private Sub tmMove_Tick(sender As Object, e As EventArgs) Handles tmMove.Tick
        changeDirection()
        changePlace()
        moveAnts()
        If Not chkEndless.Checked Then
            checkEnd()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        changeDirection()
        changePlace()
        moveAnts()
        If Not chkEndless.Checked Then
            checkEnd()
        End If
    End Sub

    Private Sub Reset()
        For i = 0 To 7
            movesIndex(i) = -1
        Next
        MaximunMove = 0

        Dim chk() As Control
        Dim btn() As Control
        For i = 0 To 7
            chk = Controls.Find("chkD" & (i + 1), True)
            btn = Controls.Find("btnD" & (i + 1), True)
            CType(chk(0), CheckBox).Checked = False
            CType(btn(0), Button).Text = "L"
        Next

        For i = 0 To places.GetLength(0) - 1
            For j = 0 To places.GetLength(1) - 1
                places(i, j).controls(0).BackColor = Color.White
                places(i, j).controls(0).Text = ""
                places(i, j).Isexplore = False
            Next
        Next

        initializeAnt()
        lblMoveNo.Text = 0
        btnStart.Text = "Start"
        btnReset.Enabled = True
        btnNext.Enabled = True
        btnStart.Enabled = True
        gbDir.Enabled = True
        chkEndless.Enabled = True
        chkEndless.Checked = True
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub rad_CheckedChanged(sender As Object, e As EventArgs) Handles radMedium.CheckedChanged, radFast.CheckedChanged, radSlow.CheckedChanged
        If radSlow.Checked Then
            tmMove.Interval = 500
        ElseIf radMedium.Checked Then
            tmMove.Interval = 100
        ElseIf radFast.Checked Then
            tmMove.Interval = 10
        End If
    End Sub
End Class
