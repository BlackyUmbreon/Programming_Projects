Public Class Form1
    Public Structure BlockType
        Dim name As String
        Dim color As Color
        Dim size(,) As Boolean
    End Structure

    Public Structure BlockPlace
        Dim isBlock As Boolean
        Dim controls() As Control
        Dim target As Boolean
    End Structure

    Public blocks(6) As BlockType
    Public place(239) As BlockPlace
    Public randoms As New Random
    Public fontTime As New Font("Comic Sans MS", 40)
    Public fontstart As New Font("Comic Sans MS", 20.25)
    Public rotate As Integer
    Public hold As Boolean = False
    Public holdOnce As Boolean = False
    Public alpha, toEliminate(3), linenumber As Integer
    Public timerStart As Integer
    Public clearline, level, score As Integer
    Public messageTimer As Integer
    Public clearing, deleting As Boolean
    Public game As Boolean

    Public Sub initializeBlock()
        For i = 0 To blocks.Length - 1
            ReDim blocks(i).size(3, 3)
            Select Case i
                Case 0
                    blocks(i).name = "I"
                    blocks(i).color = Color.Aqua
                    blocks(i).size = {{False, False, False, False},
                                      {True, True, True, True},
                                      {False, False, False, False},
                                      {False, False, False, False}}
                Case 1
                    blocks(i).name = "J"
                    blocks(i).color = Color.DarkBlue
                    blocks(i).size = {{False, False, False, False},
                                      {False, True, False, False},
                                      {False, True, True, True},
                                      {False, False, False, False}}
                Case 2
                    blocks(i).name = "L"
                    blocks(i).color = Color.Orange
                    blocks(i).size = {{False, False, False, False},
                                      {False, False, True, False},
                                      {True, True, True, False},
                                      {False, False, False, False}}
                Case 3
                    blocks(i).name = "O"
                    blocks(i).color = Color.Yellow
                    blocks(i).size = {{False, False, False, False},
                                      {False, True, True, False},
                                      {False, True, True, False},
                                      {False, False, False, False}}
                Case 4
                    blocks(i).name = "S"
                    blocks(i).color = Color.Green
                    blocks(i).size = {{False, False, False, False},
                                      {False, False, True, True},
                                      {False, True, True, False},
                                      {False, False, False, False}}
                Case 5
                    blocks(i).name = "T"
                    blocks(i).color = Color.Purple
                    blocks(i).size = {{False, False, False, False},
                                      {False, True, False, False},
                                      {True, True, True, False},
                                      {False, False, False, False}}
                Case 6
                    blocks(i).name = "Z"
                    blocks(i).color = Color.Red
                    blocks(i).size = {{False, False, False, False},
                                      {True, True, False, False},
                                      {False, True, True, False},
                                      {False, False, False, False}}
            End Select
        Next
    End Sub

    Private Sub placeInitialize()
        For i = 0 To place.Length - 1
            place(i).isBlock = False
            place(i).controls = Me.Controls.Find("Label" & i + 1, True)
            place(i).target = False
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeBlock()
        placeInitialize()
    End Sub

    Private Sub NextBlock(ByVal index As Integer)

        Dim controls() As Control

        For i = 0 To 15
            controls = Me.Controls.Find("lblNext" & i + 1, True)
            controls(0).BackColor = Color.Transparent
        Next

        For i = 0 To blocks(index).size.GetLength(1) - 1
            For j = 0 To blocks(index).size.GetLength(0) - 1
                If blocks(index).size(i, j) Then
                    controls = Me.Controls.Find("lblNext" & (i * 4 + (j + 1)), True)
                    controls(0).BackColor = blocks(index).color
                End If
            Next
        Next
    End Sub

    Public Sub nextBlockStart()
        Dim nextBlock() As Control
        Dim currentBlock() As Control
        If checkGameOver() Then
            For i = 0 To 15
                nextBlock = Me.Controls.Find("lblNext" & i + 1, True)
                currentBlock = Me.Controls.Find("lblCurrent" & i + 1, True)
                currentBlock(0).BackColor = Color.Transparent
                If nextBlock(0).BackColor <> Color.Transparent Then
                    currentBlock(0).BackColor = nextBlock(0).BackColor
                    Select Case i
                        Case 4
                            place(3).controls(0).BackColor = nextBlock(0).BackColor
                            place(3).target = True
                        Case 5
                            place(4).controls(0).BackColor = nextBlock(0).BackColor
                            place(4).target = True
                        Case 6
                            place(5).controls(0).BackColor = nextBlock(0).BackColor
                            place(5).target = True
                        Case 7
                            place(6).controls(0).BackColor = nextBlock(0).BackColor
                            place(6).target = True
                        Case 8
                            place(13).controls(0).BackColor = nextBlock(0).BackColor
                            place(13).target = True
                        Case 9
                            place(14).controls(0).BackColor = nextBlock(0).BackColor
                            place(14).target = True
                        Case 10
                            place(15).controls(0).BackColor = nextBlock(0).BackColor
                            place(15).target = True
                        Case 11
                            place(16).controls(0).BackColor = nextBlock(0).BackColor
                            place(16).target = True
                    End Select
                End If
            Next
            rotate = 1
            invisibleDrop()
        Else
            Timer1.Stop()
            GameOver()
        End If

    End Sub

    Public Sub dropBlock()
        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                place(i + 10).controls(0).BackColor = place(i).controls(0).BackColor
                place(i + 10).target = place(i).target
                place(i).target = False
                place(i).controls(0).BackColor = Color.Transparent
            End If
        Next
        invisibleDrop()
    End Sub

    Public Function DropCheck() As Boolean
        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                If i + 10 > 239 Then
                    dropEnd()
                    Return False
                ElseIf place(i + 10).isBlock Then
                    dropEnd()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Sub dropEnd()
        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                place(i).target = False
                place(i).isBlock = True
            End If
            holdOnce = False
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If DropCheck() Then
            dropBlock()
        Else
            EliminateLine()
        End If
    End Sub

    Public Function LocationcheckL() As Boolean
        For i = 0 To place.Length - 1 Step 1
            If place(i).target Then
                If i Mod 10 = 0 Then
                    Return False
                ElseIf place(i - 1).isBlock Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function LocationcheckR() As Boolean
        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                If i Mod 10 = 9 Then
                    Return False
                ElseIf place(i + 1).isBlock Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Sub directionChange(ByVal location As Integer)
        Select Case location
            Case 0
                For i = 0 To place.Length - 1
                    If place(i).target Then
                        place(i - 1).controls(0).BackColor = place(i).controls(0).BackColor
                        place(i - 1).target = place(i).target
                        place(i).target = False
                        place(i).controls(0).BackColor = Color.Transparent
                    End If
                Next
            Case 1
                For i = place.Length - 1 To 0 Step -1
                    If place(i).target Then
                        place(i + 1).controls(0).BackColor = place(i).controls(0).BackColor
                        place(i + 1).target = place(i).target
                        place(i).target = False
                        place(i).controls(0).BackColor = Color.Transparent
                    End If
                Next
        End Select
    End Sub

    Public Sub blockCheck()
        Dim currentBlock() As Control
        For i = 0 To 15
            currentBlock = Me.Controls.Find("lblCurrent" & i + 1, True)
            If currentBlock(0).BackColor <> Color.Transparent Then
                Select Case currentBlock(0).BackColor
                    Case Color.Aqua
                        blockChange("I")
                    Case Color.DarkBlue
                        blockChange("J")
                    Case Color.Orange
                        blockChange("L")
                    Case Color.Yellow
                        blockChange("O")
                    Case Color.Green
                        blockChange("S")
                    Case Color.Purple
                        blockChange("T")
                    Case Color.Red
                        blockChange("Z")
                End Select
                Exit For
            End If
        Next
    End Sub

    Public Function checkRotate(ByVal type As String, ByVal rotate As Integer) As Boolean
        Dim target As BlockPlace
        Dim targetLocF, targetLocE As Integer
        Dim index As Integer = 0
        For i = 0 To place.Length - 1
            If place(i).target Then
                targetLocF = i
                Exit For
            End If
        Next
        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                targetLocE = i
                Exit For
            End If
        Next

        Select Case type
            Case "I"
                If rotate = 1 Then
                    target = place(targetLocF)
                    If (targetLocF + 1) <= 10 Then
                        Return True
                    ElseIf (targetLocE + 1) >= 221 Then
                        Return True
                    Else
                        If place(targetLocF - 10 + 2).isBlock Or place(targetLocF + 10 + 2).isBlock Or place(targetLocF + 20 + 2).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 10 + 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 10 + 2).target = True
                            place(targetLocF + 10 + 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10 + 2).target = True
                            place(targetLocF + 20 + 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 20 + 2).target = True
                            place(targetLocF + 1).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 1).target = False
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocF + 3).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 3).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 4 Then
                    target = place(targetLocF)
                    If (targetLocF + 1) Mod 10 <= 2 Then
                        Return True
                    ElseIf (targetLocF + 1) Mod 10 = 0 Then
                        Return True
                    Else
                        If place(targetLocF + 10 - 2).isBlock Or place(targetLocF + 10 - 1).isBlock Or place(targetLocF + 10 + 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF + 10 - 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10 - 2).target = True
                            place(targetLocF + 10 - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10 - 1).target = True
                            place(targetLocF + 10 + 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10 + 1).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocF + 20).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 20).target = False
                            place(targetLocF + 30).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 30).target = False
                            Return False
                        End If
                    End If
                End If
            Case "J"
                If rotate = 1 Then
                    target = place(targetLocF)
                    If (targetLocE + 10) > 240 Then
                        Return True
                    Else
                        If place(targetLocF + 1).isBlock Or place(targetLocF + 2).isBlock Or place(targetLocE + 10 - 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF + 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 1).target = True
                            place(targetLocF + 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 2).target = True
                            place(targetLocE + 10 - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE + 10 - 1).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocF + 10).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 10).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 2 Then
                    target = place(targetLocF)
                    If targetLocF Mod 10 <= 0 Then
                        Return True
                    Else
                        If place(targetLocF - 1 + 10).isBlock Or place(targetLocF + 1 + 10).isBlock Or place(targetLocE + 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1 + 10).target = True
                            place(targetLocF + 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 1 + 10).target = True
                            place(targetLocE + 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE + 1).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocF + 1).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 1).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 3 Then
                    target = place(targetLocF)
                    If place(targetLocE - 1).isBlock Or place(targetLocE - 2).isBlock Or place(targetLocF + 1 - 10).isBlock Then
                        Return True
                    Else
                        place(targetLocE - 1).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocE - 1).target = True
                        place(targetLocE - 2).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocE - 2).target = True
                        place(targetLocF + 1 - 10).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocF + 1 - 10).target = True
                        place(targetLocF).controls(0).BackColor = Color.Transparent
                        place(targetLocF).target = False
                        place(targetLocE - 10).controls(0).BackColor = Color.Transparent
                        place(targetLocE - 10).target = False
                        place(targetLocE).controls(0).BackColor = Color.Transparent
                        place(targetLocE).target = False
                        Return False
                    End If
                ElseIf rotate = 4 Then
                    target = place(targetLocF)
                    If (targetLocF + 1) Mod 10 = 0 Then
                        Return True
                    Else
                        If place(targetLocF - 1 + 10).isBlock Or place(targetLocF + 1 + 10).isBlock Or place(targetLocF - 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1 + 10).target = True
                            place(targetLocF + 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 1 + 10).target = True
                            place(targetLocF - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocE - 1).controls(0).BackColor = Color.Transparent
                            place(targetLocE - 1).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                End If
            Case "L"
                If rotate = 1 Then
                    target = place(targetLocF)
                    If (targetLocE + 10) > 240 Then
                        Return True
                    Else
                        If place(targetLocF - 1).isBlock Or place(targetLocE + 10).isBlock Or place(targetLocE + 10 - 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1).target = True
                            place(targetLocE + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE + 10).target = True
                            place(targetLocE + 10 - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE + 10 - 1).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocF - 2 + 10).controls(0).BackColor = Color.Transparent
                            place(targetLocF - 2 + 10).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 2 Then
                    target = place(targetLocF)
                    If targetLocF Mod 10 <= 0 Then
                        Return True
                    Else
                        If place(targetLocF - 1 + 10).isBlock Or place(targetLocF + 1 + 10).isBlock Or place(targetLocE - 2).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1 + 10).target = True
                            place(targetLocF + 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 1 + 10).target = True
                            place(targetLocE - 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE - 2).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocE - 1).controls(0).BackColor = Color.Transparent
                            place(targetLocE - 1).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 3 Then
                    target = place(targetLocF)
                    If place(targetLocE + 1).isBlock Or place(targetLocF - 10).isBlock Or place(targetLocF + 1 - 10).isBlock Then
                        Return True
                    Else
                        place(targetLocE + 1).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocE + 1).target = True
                        place(targetLocF - 10).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocF - 10).target = True
                        place(targetLocF + 1 - 10).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocF + 1 - 10).target = True
                        place(targetLocF).controls(0).BackColor = Color.Transparent
                        place(targetLocF).target = False
                        place(targetLocF + 2).controls(0).BackColor = Color.Transparent
                        place(targetLocF + 2).target = False
                        place(targetLocE).controls(0).BackColor = Color.Transparent
                        place(targetLocE).target = False
                        Return False
                    End If
                ElseIf rotate = 4 Then
                    target = place(targetLocF)
                    If (targetLocF + 2) Mod 10 = 0 Then
                        Return True
                    Else
                        If place(targetLocF + 10).isBlock Or place(targetLocF + 2 + 10).isBlock Or place(targetLocF + 2).isBlock Then
                            Return True
                        Else
                            place(targetLocF + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10).target = True
                            place(targetLocF + 2 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 2 + 10).target = True
                            place(targetLocF + 2).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 2).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocF + 1).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 1).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                End If
            Case "S"
                If rotate = 1 Then
                    target = place(targetLocF)
                    If (targetLocE + 10) > 240 Then
                        Return True
                    Else
                        If place(targetLocE + 1).isBlock Or place(targetLocE + 1 + 10).isBlock Then
                            Return True
                        Else
                            place(targetLocE + 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE + 1).target = True
                            place(targetLocE + 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE + 1 + 10).target = True
                            place(targetLocF + 1).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 1).target = False
                            place(targetLocE - 1).controls(0).BackColor = Color.Transparent
                            place(targetLocE - 1).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 4 Then
                    target = place(targetLocF)
                    If targetLocF Mod 10 <= 0 Then
                        Return True
                    Else
                        If place(targetLocF + 1).isBlock Or place(targetLocF + 10 - 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF + 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 1).target = True
                            place(targetLocF + 10 - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10 - 1).target = True
                            place(targetLocF + 1 + 10).controls(0).BackColor = Color.Transparent
                            place(targetLocF + 1 + 10).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                End If
            Case "T"
                If rotate = 1 Then
                    target = place(targetLocF)
                    If (targetLocE + 10) > 240 Then
                        Return True
                    Else
                        If place(targetLocE - 1 + 10).isBlock Then
                            Return True
                        Else
                            place(targetLocE - 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocE - 1 + 10).target = True
                            place(targetLocE - 2).controls(0).BackColor = Color.Transparent
                            place(targetLocE - 2).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 2 Then
                    target = place(targetLocF)
                    If targetLocF Mod 10 <= 0 Then
                        Return True
                    Else
                        If place(targetLocF - 1 + 10).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1 + 10).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 3 Then
                    target = place(targetLocF)
                    If place(targetLocF + 1 - 10).isBlock Then
                        Return True
                    Else
                        place(targetLocF + 1 - 10).controls(0).BackColor = target.controls(0).BackColor
                        place(targetLocF + 1 - 10).target = True
                        place(targetLocF + 2).controls(0).BackColor = Color.Transparent
                        place(targetLocF + 2).target = False
                        Return False
                    End If
                ElseIf rotate = 4 Then
                    target = place(targetLocF)
                    If (targetLocF + 1) Mod 10 = 0 Then
                        Return True
                    Else
                        If place(targetLocF + 1 + 10).isBlock Then
                            Return True
                        Else
                            place(targetLocF + 1 + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 1 + 10).target = True
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                End If
            Case "Z"
                If rotate = 1 Then
                    target = place(targetLocF)
                    If (targetLocE + 10) > 240 Then
                        Return True
                    Else
                        If place(targetLocF + 10).isBlock Or place(targetLocF + 20).isBlock Then
                            Return True
                        Else
                            place(targetLocF + 10).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10).target = True
                            place(targetLocF + 20).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 20).target = True
                            place(targetLocF).controls(0).BackColor = Color.Transparent
                            place(targetLocF).target = False
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            Return False
                        End If
                    End If
                ElseIf rotate = 4 Then
                    target = place(targetLocF)
                    If (targetLocF + 1) Mod 10 = 0 Then
                        Return True
                    Else
                        If place(targetLocF - 1).isBlock Or place(targetLocF + 10 + 1).isBlock Then
                            Return True
                        Else
                            place(targetLocF - 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF - 1).target = True
                            place(targetLocF + 10 + 1).controls(0).BackColor = target.controls(0).BackColor
                            place(targetLocF + 10 + 1).target = True
                            place(targetLocE).controls(0).BackColor = Color.Transparent
                            place(targetLocE).target = False
                            place(targetLocE - 10).controls(0).BackColor = Color.Transparent
                            place(targetLocE - 10).target = False
                            Return False
                        End If
                    End If
                End If
        End Select
    End Function

    Public Sub blockChange(ByVal type As String)
        Dim controls() As Control
        Dim defaultRotate(3, 3) As Boolean
        Dim defaultRotateIndex As Integer = rotate
        For i = 0 To 15
            controls = Me.Controls.Find("lblCurrent" & i + 1, True)
            If controls(0).BackColor = Color.Transparent Then
                defaultRotate(Math.Floor(i / 4), i Mod 4) = False
            Else
                defaultRotate(Math.Floor(i / 4), i Mod 4) = True
            End If
            controls(0).BackColor = Color.Transparent
        Next
        Select Case type
            Case "I"
                If rotate = 1 Then
                    controls = Me.Controls.Find("lblCurrent3", True)
                    controls(0).BackColor = Color.Aqua
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.Aqua
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Aqua
                    controls = Me.Controls.Find("lblCurrent15", True)
                    controls(0).BackColor = Color.Aqua
                    rotate = 4
                ElseIf rotate = 4 Then
                    controls = Me.Controls.Find("lblCurrent5", True)
                    controls(0).BackColor = Color.Aqua
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Aqua
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.Aqua
                    controls = Me.Controls.Find("lblCurrent8", True)
                    controls(0).BackColor = Color.Aqua
                    rotate = 1
                End If
                If checkRotate("I", defaultRotateIndex) Then
                    For i = 0 To 15
                        controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                        controls(0).BackColor = Color.Transparent
                    Next

                    For i = 0 To defaultRotate.GetLength(1) - 1
                        For j = 0 To defaultRotate.GetLength(0) - 1
                            If defaultRotate(i, j) Then
                                controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                                controls(0).BackColor = Color.Aqua
                            End If
                        Next
                    Next
                    rotate = defaultRotateIndex
                End If
            Case "J"
                If rotate = 1 Then
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent8", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent15", True)
                    controls(0).BackColor = Color.DarkBlue
                    rotate = 2
                ElseIf rotate = 2 Then
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent12", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent16", True)
                    controls(0).BackColor = Color.DarkBlue
                    rotate = 3
                ElseIf rotate = 3 Then
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent15", True)
                    controls(0).BackColor = Color.DarkBlue
                    rotate = 4
                ElseIf rotate = 4 Then
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.DarkBlue
                    controls = Me.Controls.Find("lblCurrent12", True)
                    controls(0).BackColor = Color.DarkBlue
                    rotate = 1
                End If

                If checkRotate("J", defaultRotateIndex) Then
                    For i = 0 To 15
                        controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                        controls(0).BackColor = Color.Transparent
                    Next

                    For i = 0 To defaultRotate.GetLength(1) - 1
                        For j = 0 To defaultRotate.GetLength(0) - 1
                            If defaultRotate(i, j) Then
                                controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                                controls(0).BackColor = Color.DarkBlue
                            End If
                        Next
                    Next
                    rotate = defaultRotateIndex
                End If
            Case "O"
                controls = Me.Controls.Find("lblCurrent6", True)
                controls(0).BackColor = Color.Yellow
                controls = Me.Controls.Find("lblCurrent7", True)
                controls(0).BackColor = Color.Yellow
                controls = Me.Controls.Find("lblCurrent10", True)
                controls(0).BackColor = Color.Yellow
                controls = Me.Controls.Find("lblCurrent11", True)
                controls(0).BackColor = Color.Yellow
            Case "L"
                If rotate = 1 Then
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent15", True)
                    controls(0).BackColor = Color.Orange
                    rotate = 2
                ElseIf rotate = 2 Then
                    controls = Me.Controls.Find("lblCurrent9", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent13", True)
                    controls(0).BackColor = Color.Orange
                    rotate = 3
                ElseIf rotate = 3 Then
                    controls = Me.Controls.Find("lblCurrent5", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.Orange
                    rotate = 4
                ElseIf rotate = 4 Then
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent9", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Orange
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Orange
                    rotate = 1
                End If
                If checkRotate("L", defaultRotateIndex) Then
                    For i = 0 To 15
                        controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                        controls(0).BackColor = Color.Transparent
                    Next

                    For i = 0 To defaultRotate.GetLength(1) - 1
                        For j = 0 To defaultRotate.GetLength(0) - 1
                            If defaultRotate(i, j) Then
                                controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                                controls(0).BackColor = Color.Orange
                            End If
                        Next
                    Next
                    rotate = defaultRotateIndex
                End If
            Case "S"
                If rotate = 1 Then
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.Green
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Green
                    controls = Me.Controls.Find("lblCurrent12", True)
                    controls(0).BackColor = Color.Green
                    controls = Me.Controls.Find("lblCurrent16", True)
                    controls(0).BackColor = Color.Green
                    rotate = 4
                ElseIf rotate = 4 Then
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.Green
                    controls = Me.Controls.Find("lblCurrent8", True)
                    controls(0).BackColor = Color.Green
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Green
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Green
                    rotate = 1
                End If
                If checkRotate("S", defaultRotateIndex) Then
                    For i = 0 To 15
                        controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                        controls(0).BackColor = Color.Transparent
                    Next

                    For i = 0 To defaultRotate.GetLength(1) - 1
                        For j = 0 To defaultRotate.GetLength(0) - 1
                            If defaultRotate(i, j) Then
                                controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                                controls(0).BackColor = Color.Green
                            End If
                        Next
                    Next
                    rotate = defaultRotateIndex
                End If
            Case "T"
                If rotate = 1 Then
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.Purple
                    rotate = 2
                ElseIf rotate = 2 Then
                    controls = Me.Controls.Find("lblCurrent9", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.Purple
                    rotate = 3
                ElseIf rotate = 3 Then
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent9", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.Purple
                    rotate = 4
                ElseIf rotate = 4 Then
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent9", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Purple
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Purple
                    rotate = 1
                End If
                If checkRotate("T", defaultRotateIndex) Then
                    For i = 0 To 15
                        controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                        controls(0).BackColor = Color.Transparent
                    Next

                    For i = 0 To defaultRotate.GetLength(1) - 1
                        For j = 0 To defaultRotate.GetLength(0) - 1
                            If defaultRotate(i, j) Then
                                controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                                controls(0).BackColor = Color.Purple
                            End If
                        Next
                    Next
                    rotate = defaultRotateIndex
                End If
            Case "Z"
                If rotate = 1 Then
                    controls = Me.Controls.Find("lblCurrent7", True)
                    controls(0).BackColor = Color.Red
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Red
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Red
                    controls = Me.Controls.Find("lblCurrent14", True)
                    controls(0).BackColor = Color.Red
                    rotate = 4
                ElseIf rotate = 4 Then
                    controls = Me.Controls.Find("lblCurrent5", True)
                    controls(0).BackColor = Color.Red
                    controls = Me.Controls.Find("lblCurrent6", True)
                    controls(0).BackColor = Color.Red
                    controls = Me.Controls.Find("lblCurrent10", True)
                    controls(0).BackColor = Color.Red
                    controls = Me.Controls.Find("lblCurrent11", True)
                    controls(0).BackColor = Color.Red
                    rotate = 1
                End If
                If checkRotate("Z", defaultRotateIndex) Then
                    For i = 0 To 15
                        controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                        controls(0).BackColor = Color.Transparent
                    Next

                    For i = 0 To defaultRotate.GetLength(1) - 1
                        For j = 0 To defaultRotate.GetLength(0) - 1
                            If defaultRotate(i, j) Then
                                controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                                controls(0).BackColor = Color.Red
                            End If
                        Next
                    Next
                    rotate = defaultRotateIndex
                End If
        End Select
    End Sub

    Private Sub holdBlock()
        If Not hold Then
            Dim controls() As Control
            Dim color As Color
            Dim type As Integer

            For i = 0 To 15
                controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                If controls(0).BackColor = Color.Transparent Then
                Else
                    color = controls(0).BackColor
                End If
            Next

            For i = 0 To blocks.Length - 1
                If color = blocks(i).color Then
                    type = i
                End If
            Next

            For i = 0 To 15
                controls = Me.Controls.Find("lblHold" & i + 1, True)
                controls(0).BackColor = Color.Transparent
            Next

            For i = 0 To blocks(type).size.GetLength(1) - 1
                For j = 0 To blocks(type).size.GetLength(0) - 1
                    If blocks(type).size(i, j) Then
                        controls = Me.Controls.Find("lblHold" & (i * 4 + (j + 1)), True)
                        controls(0).BackColor = blocks(type).color
                    End If
                Next
            Next

            For i = 0 To place.Length - 1
                If place(i).target Then
                    place(i).target = False
                    place(i).controls(0).BackColor = Color.Transparent
                End If
            Next

            nextBlockStart()
            NextBlock(CInt(randoms.Next(0, 6.9)))
            hold = True
            holdOnce = True
        Else
            If Not holdOnce Then
                Dim controls(), currentBlock() As Control
                Dim Holdblock(3, 3) As Boolean
                Dim Holdcolor As Color
                Dim color As Color
                Dim type As Integer

                For i = 0 To 15
                    controls = Me.Controls.Find("lblHold" & i + 1, True)
                    If controls(0).BackColor = Color.Transparent Then
                        Holdblock(Math.Floor(i / 4), i Mod 4) = False
                    Else
                        Holdblock(Math.Floor(i / 4), i Mod 4) = True
                        Holdcolor = controls(0).BackColor
                    End If
                Next

                For i = 0 To 15
                    controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                    If controls(0).BackColor = Color.Transparent Then
                    Else
                        color = controls(0).BackColor
                    End If
                Next

                For i = 0 To blocks.Length - 1
                    If color = blocks(i).color Then
                        type = i
                    End If
                Next

                For i = 0 To 15
                    controls = Me.Controls.Find("lblHold" & i + 1, True)
                    controls(0).BackColor = Color.Transparent
                Next

                For i = 0 To blocks(Type).size.GetLength(1) - 1
                    For j = 0 To blocks(Type).size.GetLength(0) - 1
                        If blocks(Type).size(i, j) Then
                            controls = Me.Controls.Find("lblHold" & (i * 4 + (j + 1)), True)
                            controls(0).BackColor = blocks(Type).color
                        End If
                    Next
                Next

                For i = 0 To 15
                    controls = Me.Controls.Find("lblCurrent" & i + 1, True)
                    controls(0).BackColor = Color.Transparent
                Next

                For i = 0 To Holdblock.GetLength(1) - 1
                    For j = 0 To Holdblock.GetLength(0) - 1
                        If Holdblock(i, j) Then
                            controls = Me.Controls.Find("lblCurrent" & (i * 4 + (j + 1)), True)
                            controls(0).BackColor = Holdcolor
                        End If
                    Next
                Next

                For i = 0 To place.Length - 1
                    If place(i).target Then
                        place(i).target = False
                        place(i).controls(0).BackColor = Color.Transparent
                    End If
                Next

                For i = 0 To 15
                    currentBlock = Me.Controls.Find("lblCurrent" & i + 1, True)
                    If currentBlock(0).BackColor <> Color.Transparent Then
                        Select Case i
                            Case 4
                                place(3).controls(0).BackColor = currentBlock(0).BackColor
                                place(3).target = True
                            Case 5
                                place(4).controls(0).BackColor = currentBlock(0).BackColor
                                place(4).target = True
                            Case 6
                                place(5).controls(0).BackColor = currentBlock(0).BackColor
                                place(5).target = True
                            Case 7
                                place(6).controls(0).BackColor = currentBlock(0).BackColor
                                place(6).target = True
                            Case 8
                                place(13).controls(0).BackColor = currentBlock(0).BackColor
                                place(13).target = True
                            Case 9
                                place(14).controls(0).BackColor = currentBlock(0).BackColor
                                place(14).target = True
                            Case 10
                                place(15).controls(0).BackColor = currentBlock(0).BackColor
                                place(15).target = True
                            Case 11
                                place(16).controls(0).BackColor = currentBlock(0).BackColor
                                place(16).target = True
                        End Select
                    End If
                Next

                rotate = 1
                holdOnce = True
            End If
        End If
    End Sub

    Private Sub directDown()
        Dim controls() As Control

        Dim color As Color

        For i = 0 To 15
            Controls = Me.Controls.Find("lblCurrent" & i + 1, True)
            If Controls(0).BackColor = Color.Transparent Then
            Else
                color = Controls(0).BackColor
            End If
        Next

        Select Case color
            Case Color.Aqua
                downToEnd("I", rotate)
            Case Color.DarkBlue
                downToEnd("J", rotate)
            Case Color.Orange
                downToEnd("L", rotate)
            Case Color.Yellow
                downToEnd("O", rotate)
            Case Color.Green
                downToEnd("S", rotate)
            Case Color.Purple
                downToEnd("T", rotate)
            Case Color.Red
                downToEnd("Z", rotate)
        End Select

    End Sub

    Private Sub invisibleDrop()
        Dim targetLocE As Integer
        Dim targettoDown() As Integer
        Dim finalEnd As Integer = 241
        Dim fallDownLength, pointtoLength, targettoDrop, finalLengthAddition As Integer
        Dim color As Color
        Dim changelength As Boolean = True
        pointtoLength = -1
        finalLengthAddition = 0

        For i = place.Length - 1 To 0 Step -1
            If Not place(i).target Then
                If Not place(i).isBlock Then
                    place(i).controls(0).BackColor = Color.Transparent
                End If
            End If
        Next

        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                targetLocE = i
                color = place(i).controls(0).BackColor
                Exit For
            End If
        Next

        If targetLocE >= 229 And targetLocE <= 239 Then
            For i = place.Length - 1 To 0 Step -1
                If place(i).target Then
                    place(i).isBlock = True
                    place(i).target = False
                End If
            Next
            EliminateLine()
            Return
        End If

        Select Case color
            Case Color.Aqua
                Select Case rotate
                    Case 1
                        ReDim targettoDown(3)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2, targetLocE - 3}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(0)
                        targettoDown = {targetLocE}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                        Exit For
                                    End If
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case Color.DarkBlue
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 2
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE + 1 - 20}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 3
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1 - 10, targetLocE - 2 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case Color.Orange
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 2
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 3
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE + 1 - 10, targetLocE + 2 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1 - 20}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case Color.Yellow
                Select Case rotate
                    Case 1
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case Color.Green
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case Color.Purple
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 2
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 3
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1 - 10, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case Color.Red
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
        End Select

        While changelength
            changelength = False
            For i = place.Length - 1 To 0 Step -1
                If place(i).target Then
                    If i - targettoDrop - finalLengthAddition > 10 Then
                        If i + fallDownLength - finalLengthAddition > 239 Then
                            finalLengthAddition += 10
                            changelength = True
                            Exit For
                        ElseIf Not place(i + fallDownLength - finalLengthAddition).isBlock Then
                        Else
                            finalLengthAddition += 10
                            changelength = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End While

        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                place(i + fallDownLength - finalLengthAddition).controls(0).BackColor = Color.FromArgb(150, color)
            End If
        Next

        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                place(i).controls(0).BackColor = color
            End If
        Next
    End Sub

    Private Sub downToEnd(ByVal type As String, ByVal rotate As Integer)
        Dim targetLocE As Integer
        Dim targettoDown() As Integer
        Dim finalEnd As Integer = 241
        Dim fallDownLength, pointtoLength, targettoDrop, finalLengthAddition As Integer
        Dim color As Color
        Dim changelength As Boolean = True
        pointtoLength = -1
        finalLengthAddition = 0

        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                targetLocE = i
                Exit For
            End If
        Next

        If targetLocE >= 229 And targetLocE <= 239 Then
            For i = place.Length - 1 To 0 Step -1
                If place(i).target Then
                    place(i).isBlock = True
                    place(i).target = False
                End If
            Next
            EliminateLine()
            Return
        End If

        Select Case type
            Case "I"
                color = Color.Aqua
                Select Case rotate
                    Case 1
                        ReDim targettoDown(3)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2, targetLocE - 3}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(0)
                        targettoDown = {targetLocE}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                        Exit For
                                    End If
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case "J"
                color = Color.DarkBlue
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 2
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE + 1 - 20}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 3
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1 - 10, targetLocE - 2 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case "L"
                color = Color.Orange
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 2
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 3
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE + 1 - 10, targetLocE + 2 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1 - 20}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case "O"
                color = Color.Yellow
                Select Case rotate
                    Case 1
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case "S"
                color = Color.Green
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case "T"
                color = Color.Purple
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 2
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 3
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1 - 10, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE - 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
            Case "Z"
                color = Color.Red
                Select Case rotate
                    Case 1
                        ReDim targettoDown(2)
                        targettoDown = {targetLocE, targetLocE - 1, targetLocE - 2 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                    Case 4
                        ReDim targettoDown(1)
                        targettoDown = {targetLocE, targetLocE + 1 - 10}
                        For i = 0 To targettoDown.Length - 1
                            For j = targettoDown(i) To place.Length - 1 Step 10
                                If j > 229 And j <= 239 Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                ElseIf place(j + 10).isBlock Then
                                    If j < finalEnd Then
                                        finalEnd = j
                                        pointtoLength = i
                                    End If
                                    Exit For
                                End If
                            Next
                        Next
                        fallDownLength = finalEnd - targettoDown(pointtoLength)
                        targettoDrop = targettoDown(pointtoLength)
                End Select
        End Select

        While changelength
            changelength = False
            For i = place.Length - 1 To 0 Step -1
                If place(i).target Then
                    If i - targettoDrop - finalLengthAddition > 10 Then
                        If i + fallDownLength - finalLengthAddition > 239 Then
                            finalLengthAddition += 10
                            changelength = True
                            Exit For
                        ElseIf Not place(i + fallDownLength - finalLengthAddition).isBlock Then
                        Else
                            finalLengthAddition += 10
                            changelength = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End While

        For i = place.Length - 1 To 0 Step -1
            If place(i).target Then
                place(i).controls(0).BackColor = Color.Transparent
                place(i).target = False
                place(i + fallDownLength - finalLengthAddition).controls(0).BackColor = color
                place(i + fallDownLength - finalLengthAddition).isBlock = True
            End If
        Next

    End Sub

    Private Sub EliminateLine()
        Dim cells As Integer
        toEliminate = {240, 240, 240, 240}
        Dim index = 0
        For i = 230 To 0 Step -10
            cells = 0
            For j = 0 To 9
                If place(i + j).isBlock Then
                    cells += 1
                End If
            Next

            If cells > 9 Then
                toEliminate(Index) = i
                index += 1
                cells = 0
            End If
        Next
        If toEliminate(0) <> 240 Then
            linenumber = 0
            For i = 0 To 3
                If toEliminate(i) <> 240 Then
                    linenumber += 1
                End If
            Next
            alpha = 255
            clearing = True
            Timer2.Start()
        ElseIf cells <= 9 Then
            nextBlockStart()
            Randomize()
            NextBlock(CInt(randoms.Next(0, 6.9)))
            holdOnce = False
        End If
    End Sub

    Private Sub TimetoEliminate(ByVal line() As Integer)
        For i = 0 To linenumber - 1 Step 1
            For j = line(i) To line(i) + 9 Step 1
                place(j).controls(0).BackColor = Color.FromArgb(alpha, place(j).controls(0).BackColor)
            Next
        Next


        If alpha = 0 Then
            For i = 0 To linenumber - 1 Step 1
                For j = line(i) To line(i) + 9 Step 1
                    place(j).isBlock = False
                Next
            Next
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If alpha >= 0 Then
            TimetoEliminate(toEliminate)
            alpha -= 5
        Else
            Timer2.Stop()
            clearing = False
            allCellDropOne(toEliminate)
            lineMessage()
            nextBlockStart()
            Randomize()
            NextBlock(CInt(randoms.Next(0, 6.9)))
            holdOnce = False
        End If
    End Sub

    Private Function checkGameOver() As Boolean
        Dim nextBlock() As Control
        Dim continuePlay As Boolean = True
        For i = 0 To 15
            nextBlock = Me.Controls.Find("lblNext" & i + 1, True)
            If nextBlock(0).BackColor <> Color.Transparent Then
                Select Case i
                    Case 4
                        If place(3).isBlock Then
                            continuePlay = False
                        End If
                    Case 5
                        If place(4).isBlock Then
                            continuePlay = False
                        End If
                    Case 6
                        If place(5).isBlock Then
                            continuePlay = False
                        End If
                    Case 7
                        If place(6).isBlock Then
                            continuePlay = False
                        End If
                    Case 8
                        If place(13).isBlock Then
                            continuePlay = False
                        End If
                    Case 9
                        If place(14).isBlock Then
                            continuePlay = False
                        End If
                    Case 10
                        If place(15).isBlock Then
                            continuePlay = False
                        End If
                    Case 11
                        If place(16).isBlock Then
                            continuePlay = False
                        End If
                End Select
            End If
        Next
        Return continuePlay
    End Function

    Private Sub GameOver()
        deleting = True
        Timer5.Start()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        timerStart = 3
        lblTime.Visible = True
        lblTime.Font = fontstart
        lblTime.ForeColor = Color.Black
        lblTime.Text = "Ready!"
        lblMessage.Text = ""
        lblScore.Text = ""
        lblLevel.Text = ""
        Timer3.Start()
        btnStart.Enabled = False
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If timerStart >= 0 Then
            If timerStart <> 0 Then
                If timerStart = 3 Then
                    lblTime.Font = fontTime
                End If
                lblTime.Text = timerStart
            Else
                lblTime.Text = "GO!"
            End If
            Select Case timerStart
                Case 3
                    lblTime.ForeColor = Color.Red
                Case 2
                    lblTime.ForeColor = Color.Orange
                Case 1
                    lblTime.ForeColor = Color.Yellow
                Case 0
                    lblTime.ForeColor = Color.Green
            End Select
            timerStart -= 1
        Else
            Timer3.Stop()
            reset()
            lblLevel.Text = "Level " & 1
            lblTime.Visible = False
            Randomize()
            NextBlock(CInt(randoms.Next(0, 6.9)))
            nextBlockStart()
            Randomize()
            NextBlock(CInt(randoms.Next(0, 6.9)))
            Timer1.Start()
            game = True
        End If
    End Sub

    Private Sub ScoreChanges(sender As Object, e As EventArgs) Handles lblScore.TextChanged
        If clearline < 20 Then
            level = 1
        ElseIf clearline < 40 Then
            level = 2
        ElseIf clearline < 60 Then
            level = 3
        ElseIf clearline < 80 Then
            level = 4
        ElseIf clearline < 100 Then
            level = 5
        ElseIf clearline < 120 Then
            level = 6
        ElseIf clearline < 140 Then
            level = 7
        ElseIf clearline < 160 Then
            level = 8
        ElseIf clearline < 180 Then
            level = 9
        Else
            level = 10
        End If

        If lblLevel.Text <> "Level " & level Then
            lblLevel.Text = "Level " & level
        End If
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If deleting Then
            deleting = False
            For i = 230 To place.Length - 1
                If place(i).isBlock Then
                    deleting = True
                    place(i).controls(0).BackColor = Color.Transparent
                    place(i).isBlock = False
                End If
            Next

            If deleting Then
                For i = 229 To 0 Step -1
                    If place(i).isBlock Then
                        place(i + 10).controls(0).BackColor = place(i).controls(0).BackColor
                        place(i + 10).isBlock = True
                        place(i).controls(0).BackColor = Color.Transparent
                        place(i).isBlock = False
                    End If
                Next
            End If
        Else
            Timer5.Stop()
            MessageBox.Show("Game Over", "Tetris", MessageBoxButtons.OK)
            btnStart.Enabled = True
            lblMessage.ForeColor = Color.Black
            lblMessage.Text = "Tetris!"
            game = False
        End If
    End Sub

    Private Sub reset()
        clearline = 0
        score = 0
        lblScore.Text = score
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If messageTimer < 20 Then
            Select Case linenumber
                Case 2
                    lblMessage.ForeColor = Color.Lime
                    lblMessage.Text = "Double"
                Case 3
                    lblMessage.ForeColor = Color.DarkBlue
                    lblMessage.Text = "Triple"
                Case 4
                    Select Case Math.Floor(messageTimer Mod 7)
                        Case 0
                            lblMessage.ForeColor = Color.Red
                        Case 1
                            lblMessage.ForeColor = Color.Orange
                        Case 2
                            lblMessage.ForeColor = Color.Yellow
                        Case 3
                            lblMessage.ForeColor = Color.Lime
                        Case 4
                            lblMessage.ForeColor = Color.Blue
                        Case 5
                            lblMessage.ForeColor = Color.DarkBlue
                        Case 6
                            lblMessage.ForeColor = Color.Purple
                    End Select
                    lblMessage.Text = "TETRIS!"
            End Select
            messageTimer += 1
        Else
            lblMessage.Text = ""
            Timer4.Stop()
        End If
    End Sub

    Private Sub LevelChanges(sender As Object, e As EventArgs) Handles lblLevel.TextChanged, lblMessage.TextChanged
        Select Case level
            Case 1
                Timer1.Interval = 1000
            Case 2
                Timer1.Interval = 900
            Case 3
                Timer1.Interval = 800
            Case 4
                Timer1.Interval = 700
            Case 5
                Timer1.Interval = 600
            Case 6
                Timer1.Interval = 500
            Case 7
                Timer1.Interval = 400
            Case 8
                Timer1.Interval = 300
            Case 9
                Timer1.Interval = 200
            Case 10
                Timer1.Interval = 100
        End Select
    End Sub

    Private Sub lineMessage()
        If linenumber <> 1 Then
            Timer4.Stop()
            messageTimer = 0
            Timer4.Start()
        End If
    End Sub

    Private Sub allCellDropOne(ByVal line() As Integer)
        For i = linenumber - 1 To 0 Step -1
            For j = line(i) To 0 Step -1
                If place(j).isBlock Then
                    place(j + 10).controls(0).BackColor = place(j).controls(0).BackColor
                    place(j + 10).isBlock = True
                    place(j).controls(0).BackColor = Color.Transparent
                    place(j).isBlock = False
                End If
            Next
        Next

        Select Case linenumber
            Case 1
                score = score + (40 * (level + 1))
                clearline += 1
            Case 2
                score = score + (100 * (level + 1))
                clearline += 2
            Case 3
                score = score + (300 * (level + 1))
                clearline += 3
            Case 4
                score = score + (1200 * (level + 1))
                clearline += 4
        End Select
        lblScore.Text = score
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If game Then
            If Not clearing And Not deleting Then
                If e.KeyCode = Keys.Left Then
                    If LocationcheckL() Then
                        directionChange(0)
                        invisibleDrop()
                    End If
                ElseIf e.KeyCode = Keys.Right Then
                    If LocationcheckR() Then
                        directionChange(1)
                        invisibleDrop()
                    End If
                ElseIf e.KeyCode = Keys.Down Then
                    Timer1.Stop()
                    If DropCheck() Then
                        dropBlock()
                    Else
                        EliminateLine()
                    End If
                    Timer1.Start()
                ElseIf e.KeyCode = Keys.Up Then
                    blockCheck()
                    invisibleDrop()
                ElseIf e.KeyCode = Keys.ShiftKey Then
                    holdBlock()
                    invisibleDrop()
                ElseIf e.KeyCode = Keys.Space Then
                    Timer1.Stop()
                    directDown()
                    EliminateLine()
                    Timer1.Start()
                End If
            End If
        End If
    End Sub


End Class
