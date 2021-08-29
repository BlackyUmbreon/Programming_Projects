Imports Chess

Public Class Form1

    Public Enum Player
        None
        Red
        Blue
    End Enum

    Public Structure Piece
        Dim classPiece As String
        Dim type As String
        Dim team As Player
        Dim death As Boolean
        Dim seat() As Control
    End Structure

    Public Structure Place
        Dim controls() As Control
        Dim pieceControl As Boolean
        Dim controlBy As Player
        Dim nextMove As Boolean
    End Structure

    Public RedPlayer(15) As Piece
    Public BluePlayer(15) As Piece
    Public ChessBoard(,) As Place
    Public turn As Player
    Public targetPiece As Integer
    Public targetI, targetJ As Integer
    Public redDeath, blueDeath As Integer
    Dim play As Boolean

    Private Sub Initialize()
        PieceInitialize()
        placeInitialize()
        PieceSeatInitialize()
        turn = Player.Red
        redDeath = 0
        blueDeath = 0
        play = True
    End Sub

    Private Sub PieceInitialize()
        'For Red
        RedPlayer(0).type = "King"
        RedPlayer(0).classPiece = "King"
        RedPlayer(1).type = "Queen"
        RedPlayer(1).classPiece = "Queen"
        For i = 0 To 2 Step 1
            For j = 0 To 1
                Select Case i
                    Case 0
                        RedPlayer((i * 2) + 2 + j).type = "Bishop" & j + 1
                        RedPlayer((i * 2) + 2 + j).classPiece = "Bishop"
                    Case 1
                        RedPlayer((i * 2) + 2 + j).type = "Horse" & j + 1
                        RedPlayer((i * 2) + 2 + j).classPiece = "Horse"
                    Case 2
                        RedPlayer((i * 2) + 2 + j).type = "Rook" & j + 1
                        RedPlayer((i * 2) + 2 + j).classPiece = "Rook"
                End Select
            Next
        Next

        For i = 8 To RedPlayer.Length - 1
            RedPlayer(i).type = "Pawn" & i - 7
            RedPlayer(i).classPiece = "Pawn"
        Next

        For i = 0 To RedPlayer.Length - 1
            RedPlayer(i).team = Player.Red
            RedPlayer(i).death = False
        Next


        'For Blue
        BluePlayer(0).type = "King"
        BluePlayer(0).classPiece = "King"
        BluePlayer(1).type = "Queen"
        BluePlayer(1).classPiece = "Queen"
        For i = 0 To 2 Step 1
            For j = 0 To 1
                Select Case i
                    Case 0
                        BluePlayer((i * 2) + 2 + j).type = "Bishop" & j + 1
                        BluePlayer((i * 2) + 2 + j).classPiece = "Bishop"
                    Case 1
                        BluePlayer((i * 2) + 2 + j).type = "Horse" & j + 1
                        BluePlayer((i * 2) + 2 + j).classPiece = "Horse"
                    Case 2
                        BluePlayer((i * 2) + 2 + j).type = "Rook" & j + 1
                        BluePlayer((i * 2) + 2 + j).classPiece = "Rook"
                End Select
            Next
        Next

        For i = 8 To BluePlayer.Length - 1
            BluePlayer(i).type = "Pawn" & i - 7
            BluePlayer(i).classPiece = "Pawn"
        Next

        For i = 0 To BluePlayer.Length - 1
            BluePlayer(i).team = Player.Blue
            BluePlayer(i).death = False
        Next
    End Sub

    Private Sub placeInitialize()
        Dim letter(7) As String
        letter = {"A", "B", "C", "D", "E", "F", "G", "H"}
        ReDim ChessBoard(7, 7)
        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                ChessBoard(i, j).controls = Controls.Find("lbl" & letter(i) & (j + 1), True)
                ChessBoard(i, j).pieceControl = False
                ChessBoard(i, j).controlBy = Player.None
                If i Mod 2 = 1 Then
                    If (i * 8 + j) Mod 2 <> 0 Then
                        ChessBoard(i, j).controls(0).BackColor = Color.Gray
                    Else
                        ChessBoard(i, j).controls(0).BackColor = Color.White
                    End If
                Else
                    If (i * 8 + j - 1) Mod 2 <> 0 Then
                        ChessBoard(i, j).controls(0).BackColor = Color.Gray
                    Else
                        ChessBoard(i, j).controls(0).BackColor = Color.White
                    End If
                End If
                AddHandler ChessBoard(i, j).controls(0).Click, AddressOf clickPlace
                ChessBoard(i, j).nextMove = False
            Next
        Next

    End Sub

    Private Sub PieceSeatInitialize()
        Dim arrangementF(7) As String
        Dim arrangementB(7) As String
        arrangementF = {"Pawn1", "Pawn2", "Pawn3", "Pawn4", "Pawn5", "Pawn6", "Pawn7", "Pawn8"}
        arrangementB = {"Rook1", "Horse1", "Bishop1", "Queen", "King", "Bishop2", "Horse2", "Rook2"}

        'Clean Place
        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                ChessBoard(i, j).controls(0).Text = ""
                ChessBoard(i, j).controls(0).ForeColor = Color.Black
                ChessBoard(i, j).pieceControl = False
                ChessBoard(i, j).controlBy = Player.None
            Next
        Next

        'For Red
        For i = 0 To 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                Select Case i
                    Case 0
                        For k = 0 To RedPlayer.Length - 1
                            If RedPlayer(k).type = arrangementB(j) Then
                                RedPlayer(k).seat = ChessBoard(i, j).controls
                                ChessBoard(i, j).pieceControl = True
                                ChessBoard(i, j).controlBy = RedPlayer(k).team
                                Exit For
                            End If
                        Next
                    Case 1
                        For k = 0 To RedPlayer.Length - 1
                            If RedPlayer(k).type = arrangementF(j) Then
                                RedPlayer(k).seat = ChessBoard(i, j).controls
                                ChessBoard(i, j).pieceControl = True
                                ChessBoard(i, j).controlBy = RedPlayer(k).team
                                Exit For
                            End If
                        Next
                End Select
            Next
        Next

        For i = 0 To RedPlayer.Length - 1
            RedPlayer(i).seat(0).ForeColor = Color.Red
            Select Case RedPlayer(i).classPiece
                Case "King"
                    RedPlayer(i).seat(0).Text = "K"
                Case "Queen"
                    RedPlayer(i).seat(0).Text = "Q"
                Case "Bishop"
                    RedPlayer(i).seat(0).Text = "B"
                Case "Horse"
                    RedPlayer(i).seat(0).Text = "H"
                Case "Rook"
                    RedPlayer(i).seat(0).Text = "R"
                Case "Pawn"
                    RedPlayer(i).seat(0).Text = "P"
            End Select
        Next

        'For Blue
        For i = 7 To 6 Step -1
            For j = ChessBoard.GetLength(1) - 1 To 0 Step -1
                Select Case i
                    Case 7
                        For k = 0 To BluePlayer.Length - 1
                            If BluePlayer(k).type = arrangementB(j) Then
                                BluePlayer(k).seat = ChessBoard(i, j).controls
                                ChessBoard(i, j).pieceControl = True
                                ChessBoard(i, j).controlBy = BluePlayer(k).team
                                Exit For
                            End If
                        Next
                    Case 6
                        For k = 0 To BluePlayer.Length - 1
                            If BluePlayer(k).type = arrangementF(j) Then
                                BluePlayer(k).seat = ChessBoard(i, j).controls
                                ChessBoard(i, j).pieceControl = True
                                ChessBoard(i, j).controlBy = BluePlayer(k).team
                                Exit For
                            End If
                        Next
                End Select
            Next
        Next

        For i = 0 To BluePlayer.Length - 1
            BluePlayer(i).seat(0).ForeColor = Color.Blue
            Select Case BluePlayer(i).classPiece
                Case "King"
                    BluePlayer(i).seat(0).Text = "K"
                Case "Queen"
                    BluePlayer(i).seat(0).Text = "Q"
                Case "Bishop"
                    BluePlayer(i).seat(0).Text = "B"
                Case "Horse"
                    BluePlayer(i).seat(0).Text = "H"
                Case "Rook"
                    BluePlayer(i).seat(0).Text = "R"
                Case "Pawn"
                    BluePlayer(i).seat(0).Text = "P"
            End Select
        Next
    End Sub

    Private Sub movePlaceB(ByVal target As Control, ByVal player As Player)

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If ChessBoard(i, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow) Or ChessBoard(i, j).controls(0).BackColor = Color.FromArgb(100, Color.Red) Then
                    If i Mod 2 = 1 Then
                        If (i * 8 + j) Mod 2 <> 0 Then
                            ChessBoard(i, j).controls(0).BackColor = Color.Gray
                        Else
                            ChessBoard(i, j).controls(0).BackColor = Color.White
                        End If
                    Else
                        If (i * 8 + j - 1) Mod 2 <> 0 Then
                            ChessBoard(i, j).controls(0).BackColor = Color.Gray
                        Else
                            ChessBoard(i, j).controls(0).BackColor = Color.White
                        End If
                    End If
                    ChessBoard(i, j).nextMove = False
                End If
            Next
        Next

        If turn = player Then
            Select Case target.Text
                Case "P"
                    PawnMove(target, turn)
                Case "R"
                    RookMove(target, turn)
                Case "H"
                    HorseMove(target, turn)
                Case "B"
                    BishopMove(target, turn)
                Case "Q"
                    QueenMove(target, turn)
                Case "K"
                    KingMove(target, turn)
                Case Else
                    Return
            End Select
        Else
            Return
        End If

        Select Case turn
            Case Player.Red
                For i = 0 To RedPlayer.Length - 1
                    If target Is RedPlayer(i).seat(0) Then
                        targetPiece = i
                    End If
                Next
            Case Player.Blue
                For i = 0 To BluePlayer.Length - 1
                    If target Is BluePlayer(i).seat(0) Then
                        targetPiece = i
                    End If
                Next
        End Select
    End Sub

    Private Sub movePlaceA(ByVal target As Control)
        Dim noloop As Boolean = False
        Dim checkI, checkJ As Integer
        Dim checkPlayer As Player

        checkDeath(target)

        Select Case turn
            Case Player.Red
                For i = 0 To ChessBoard.GetLength(0) - 1
                    For j = 0 To ChessBoard.GetLength(1) - 1
                        If ChessBoard(i, j).controls(0) Is target Then
                            ChessBoard(i, j).pieceControl = True
                            ChessBoard(i, j).controlBy = RedPlayer(targetPiece).team
                            ChessBoard(i, j).controls(0).Text = RedPlayer(targetPiece).seat(0).Text
                            ChessBoard(i, j).controls(0).ForeColor = RedPlayer(targetPiece).seat(0).ForeColor
                            RedPlayer(targetPiece).seat(0).ForeColor = Color.Black
                            RedPlayer(targetPiece).seat(0).Text = ""
                            RedPlayer(targetPiece).seat = ChessBoard(i, j).controls
                            ChessBoard(targetI, targetJ).pieceControl = False
                            ChessBoard(targetI, targetJ).controlBy = Player.None
                            checkI = i
                            checkJ = j
                            checkPlayer = Player.Red
                            noloop = True
                            Exit For
                        End If
                    Next
                    If noloop Then Exit For
                Next
            Case Player.Blue
                For i = 0 To ChessBoard.GetLength(0) - 1
                    For j = 0 To ChessBoard.GetLength(1) - 1
                        If ChessBoard(i, j).controls(0) Is target Then
                            ChessBoard(i, j).pieceControl = True
                            ChessBoard(i, j).controlBy = BluePlayer(targetPiece).team
                            ChessBoard(i, j).controls(0).Text = BluePlayer(targetPiece).seat(0).Text
                            ChessBoard(i, j).controls(0).ForeColor = BluePlayer(targetPiece).seat(0).ForeColor
                            BluePlayer(targetPiece).seat(0).ForeColor = Color.Black
                            BluePlayer(targetPiece).seat(0).Text = ""
                            BluePlayer(targetPiece).seat = ChessBoard(i, j).controls
                            ChessBoard(targetI, targetJ).pieceControl = False
                            ChessBoard(targetI, targetJ).controlBy = Player.None
                            noloop = True
                            checkI = i
                            checkJ = j
                            checkPlayer = Player.Blue
                            Exit For
                        End If
                    Next
                    If noloop Then Exit For
                Next
        End Select

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If ChessBoard(i, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow) Or ChessBoard(i, j).controls(0).BackColor = Color.FromArgb(100, Color.Red) Then
                    If i Mod 2 = 1 Then
                        If (i * 8 + j) Mod 2 <> 0 Then
                            ChessBoard(i, j).controls(0).BackColor = Color.Gray
                        Else
                            ChessBoard(i, j).controls(0).BackColor = Color.White
                        End If
                    Else
                        If (i * 8 + j - 1) Mod 2 <> 0 Then
                            ChessBoard(i, j).controls(0).BackColor = Color.Gray
                        Else
                            ChessBoard(i, j).controls(0).BackColor = Color.White
                        End If
                    End If
                    ChessBoard(i, j).nextMove = False
                End If
            Next
        Next

        checkWin()
        checkKing()
    End Sub

    Private Sub PawnMove(ByVal target As Control, ByVal player As Player)
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                If Ti < 6 Then
                    For i = 1 To 2
                        If Not ChessBoard(Ti + i, Tj).pieceControl Then
                            ChessBoard(Ti + i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + i, Tj).nextMove = True
                        Else
                            Exit For
                        End If
                    Next
                ElseIf Ti < 7 Then
                    If Not ChessBoard(Ti + 1, Tj).pieceControl Then
                        ChessBoard(Ti + 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti + 1, Tj).nextMove = True
                    End If
                End If

                If Ti < 7 Then
                    If Tj > 0 Then
                        If ChessBoard(Ti + 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj - 1).controlBy = Player.Blue Then
                                ChessBoard(Ti + 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + 1, Tj - 1).nextMove = True
                            End If
                        End If
                    End If

                    If Tj < 7 Then
                        If ChessBoard(Ti + 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj + 1).controlBy = Player.Blue Then
                                ChessBoard(Ti + 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + 1, Tj + 1).nextMove = True
                            End If
                        End If
                    End If
                End If

            Case Player.Blue
                If Ti > 1 Then
                    For i = 1 To 2
                        If Not ChessBoard(Ti - i, Tj).pieceControl Then
                            ChessBoard(Ti - i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - i, Tj).nextMove = True
                        Else
                            Exit For
                        End If
                    Next
                ElseIf Ti > 0 Then
                    If Not ChessBoard(Ti - 1, Tj).pieceControl Then
                        ChessBoard(Ti - 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti - 1, Tj).nextMove = True
                    End If
                End If

                If Ti > 0 Then
                    If Tj > 0 Then
                        If ChessBoard(Ti - 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj - 1).controlBy = Player.Red Then
                                ChessBoard(Ti - 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - 1, Tj - 1).nextMove = True
                            End If
                        End If
                    End If

                    If Tj < 7 Then
                        If ChessBoard(Ti - 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj + 1).controlBy = Player.Red Then
                                ChessBoard(Ti - 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - 1, Tj + 1).nextMove = True
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub RookMove(ByVal target As Control, ByVal player As Player)
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

            Case Player.Blue
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

        End Select
    End Sub

    Private Sub HorseMove(ByVal target As Control, ByVal player As Player)
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim eightPosition(7, 1) As Integer
        Dim DifferentI, DifferentJ As Integer
        Dim noBlock As Integer

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        eightPosition = {{Ti - 2, Tj - 1}, {Ti - 2, Tj + 1},
                         {Ti - 1, Tj - 2}, {Ti - 1, Tj + 2},
                         {Ti + 1, Tj - 2}, {Ti + 1, Tj + 2},
                         {Ti + 2, Tj - 1}, {Ti + 2, Tj + 1}}

        Select Case player
            Case Player.Red
                For i = 0 To eightPosition.GetLength(0) - 1
                    If eightPosition(i, 0) < 0 Or eightPosition(i, 0) > 7 Then
                        Continue For
                    ElseIf eightPosition(i, 1) < 0 Or eightPosition(i, 1) > 7 Then
                        Continue For
                    Else
                        noBlock = 0
                        DifferentI = eightPosition(i, 0) - Ti
                        DifferentJ = eightPosition(i, 1) - Tj

                        If DifferentI = -2 Then
                            For y = -1 To DifferentI Step -1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti - y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf Differentj = -2 Then
                            For x = -1 To DifferentJ Step -1
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj - x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf Differentj = 2 Then
                            For x = 1 To DifferentJ
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentI = 2 Then
                            For y = 1 To DifferentI Step 1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti + y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        End If

                        If noBlock < 2 Then
                            If ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controlBy = Player.Blue Then
                                ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).nextMove = True
                            Else
                                If Not ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).pieceControl Then
                                    ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                                    ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).nextMove = True
                                End If
                            End If
                        Else
                            Continue For
                        End If
                    End If
                Next
            Case Player.Blue
                For i = 0 To eightPosition.GetLength(0) - 1
                    If eightPosition(i, 0) < 0 Or eightPosition(i, 0) > 7 Then
                        Continue For
                    ElseIf eightPosition(i, 1) < 0 Or eightPosition(i, 1) > 7 Then
                        Continue For
                    Else
                        noBlock = 0
                        DifferentI = eightPosition(i, 0) - Ti
                        DifferentJ = eightPosition(i, 1) - Tj

                        If DifferentI = -2 Then
                            For y = -1 To DifferentI Step -1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti - y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentJ = -2 Then
                            For x = -1 To DifferentJ Step -1
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj - x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentJ = 2 Then
                            For x = 1 To DifferentJ
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentI = 2 Then
                            For y = 1 To DifferentI Step 1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti + y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        End If

                        If noBlock < 2 Then
                            If ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controlBy = Player.Red Then
                                ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).nextMove = True
                            Else
                                If Not ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).pieceControl Then
                                    ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                                    ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).nextMove = True
                                End If
                            End If
                        Else
                            Continue For
                        End If
                    End If
                Next
        End Select
    End Sub

    Private Sub BishopMove(ByVal target As Control, ByVal player As Player)
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim d As Integer
        Dim move As Integer
        Dim newI, newJ As Integer
        Dim stopPlace As Boolean

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj + d).pieceControl Then
                            ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Blue Then
                                ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj - d).pieceControl Then
                            ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Blue Then
                                ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj - d).pieceControl Then
                            ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Blue Then
                                ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj + d).pieceControl Then
                            ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Blue Then
                                ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
            Case Player.Blue
                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj + d).pieceControl Then
                            ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Red Then
                                ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj - d).pieceControl Then
                            ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Red Then
                                ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj - d).pieceControl Then
                            ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Red Then
                                ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj + d).pieceControl Then
                            ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Red Then
                                ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
        End Select
    End Sub

    Private Sub QueenMove(ByVal target As Control, ByVal player As Player)
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim d As Integer
        Dim move As Integer
        Dim newI, newJ As Integer
        Dim stopPlace As Boolean

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI += 1
                            newJ += 1
                            Move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj + d).pieceControl Then
                            ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Blue Then
                                ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI += 1
                            newJ -= 1
                            Move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj - d).pieceControl Then
                            ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Blue Then
                                ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI -= 1
                            newJ -= 1
                            Move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj - d).pieceControl Then
                            ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Blue Then
                                ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI -= 1
                            newJ += 1
                            Move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj + d).pieceControl Then
                            ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Blue Then
                                ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
            Case Player.Blue
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If Not ChessBoard(i, Tj).pieceControl Then
                        ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(i, Tj).nextMove = True
                    Else
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            ChessBoard(i, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(i, Tj).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If Not ChessBoard(Ti, j).pieceControl Then
                        ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, j).nextMove = True
                    Else
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            ChessBoard(Ti, j).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, j).nextMove = True
                        End If
                        Exit For
                    End If
                Next

                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI += 1
                            newJ += 1
                            Move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj + d).pieceControl Then
                            ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Red Then
                                ChessBoard(Ti + d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI += 1
                            newJ -= 1
                            Move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti + d, Tj - d).pieceControl Then
                            ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Red Then
                                ChessBoard(Ti + d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI -= 1
                            newJ -= 1
                            Move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj - d).pieceControl Then
                            ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj - d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Red Then
                                ChessBoard(Ti - d, Tj - d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj - d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        Move = 0
                        newI = Ti
                        newJ = Tj
                        While Move < i - 1
                            newI -= 1
                            newJ += 1
                            Move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If Not ChessBoard(Ti - d, Tj + d).pieceControl Then
                            ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - d, Tj + d).nextMove = True
                        Else
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Red Then
                                ChessBoard(Ti - d, Tj + d).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - d, Tj + d).nextMove = True
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
        End Select
    End Sub

    Private Sub KingMove(ByVal target As Control, ByVal player As Player)
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim up, down, left, right As Boolean

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                up = True
                down = True
                right = True
                left = True

                If Ti < 7 Then
                    If Not ChessBoard(Ti + 1, Tj).pieceControl Then
                        ChessBoard(Ti + 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti + 1, Tj).nextMove = True
                    Else
                        If ChessBoard(Ti + 1, Tj).controlBy = Player.Blue Then
                            ChessBoard(Ti + 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti + 1, Tj).nextMove = True
                        End If
                        down = False
                    End If
                Else
                    down = False
                End If

                If Ti > 0 Then
                    If Not ChessBoard(Ti - 1, Tj).pieceControl Then
                        ChessBoard(Ti - 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti - 1, Tj).nextMove = True
                    Else
                        If ChessBoard(Ti - 1, Tj).controlBy = Player.Blue Then
                            ChessBoard(Ti - 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti - 1, Tj).nextMove = True
                        End If
                        up = False
                    End If
                Else
                    up = False
                End If

                If Tj < 7 Then
                    If Not ChessBoard(Ti, Tj + 1).pieceControl Then
                        ChessBoard(Ti, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, Tj + 1).nextMove = True
                    Else
                        If ChessBoard(Ti, Tj + 1).controlBy = Player.Blue Then
                            ChessBoard(Ti, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, Tj + 1).nextMove = True
                        End If
                        right = False
                    End If
                Else
                    right = False
                End If

                If Tj > 0 Then
                    If Not ChessBoard(Ti, Tj - 1).pieceControl Then
                        ChessBoard(Ti, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, Tj - 1).nextMove = True
                    Else
                        If ChessBoard(Ti, Tj - 1).controlBy = Player.Blue Then
                            ChessBoard(Ti, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, Tj - 1).nextMove = True
                        End If
                        left = False
                    End If
                Else
                    left = False
                End If

                If down Or right Then
                    If Ti < 7 And Tj < 7 Then
                        If Not ChessBoard(Ti + 1, Tj + 1).pieceControl Then
                            ChessBoard(Ti + 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + 1, Tj + 1).nextMove = True
                        Else
                            If ChessBoard(Ti + 1, Tj + 1).controlBy = Player.Blue Then
                                ChessBoard(Ti + 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + 1, Tj + 1).nextMove = True
                            End If
                        End If
                    End If
                End If

                If down Or left Then
                    If Ti < 7 And Tj > 0 Then
                        If Not ChessBoard(Ti + 1, Tj - 1).pieceControl Then
                            ChessBoard(Ti + 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + 1, Tj - 1).nextMove = True
                        Else
                            If ChessBoard(Ti + 1, Tj - 1).controlBy = Player.Blue Then
                                ChessBoard(Ti + 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + 1, Tj - 1).nextMove = True
                            End If
                        End If
                    Else
                    End If
                End If

                If up Or left Then
                    If Ti > 0 And Tj > 0 Then
                        If Not ChessBoard(Ti - 1, Tj - 1).pieceControl Then
                            ChessBoard(Ti - 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - 1, Tj - 1).nextMove = True
                        Else
                            If ChessBoard(Ti - 1, Tj - 1).controlBy = Player.Blue Then
                                ChessBoard(Ti - 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - 1, Tj - 1).nextMove = True
                            End If
                        End If
                    End If
                End If

                If up Or right Then
                    If Ti > 0 And Tj < 7 Then
                        If Not ChessBoard(Ti - 1, Tj + 1).pieceControl Then
                            ChessBoard(Ti - 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - 1, Tj + 1).nextMove = True
                        Else
                            If ChessBoard(Ti - 1, Tj + 1).controlBy = Player.Blue Then
                                ChessBoard(Ti - 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - 1, Tj + 1).nextMove = True
                            End If
                        End If
                    End If
                End If
            Case Player.Blue
                up = True
                down = True
                left = True
                right = True

                If Ti < 7 Then
                    If Not ChessBoard(Ti + 1, Tj).pieceControl Then
                        ChessBoard(Ti + 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti + 1, Tj).nextMove = True
                    Else
                        If ChessBoard(Ti + 1, Tj).controlBy = Player.Red Then
                            ChessBoard(Ti + 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti + 1, Tj).nextMove = True
                        End If
                        down = False
                    End If
                Else
                    down = False
                End If

                If Ti > 0 Then
                    If Not ChessBoard(Ti - 1, Tj).pieceControl Then
                        ChessBoard(Ti - 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti - 1, Tj).nextMove = True
                    Else
                        If ChessBoard(Ti - 1, Tj).controlBy = Player.Red Then
                            ChessBoard(Ti - 1, Tj).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti - 1, Tj).nextMove = True
                        End If
                        up = False
                    End If
                Else
                    up = False
                End If

                If Tj < 7 Then
                    If Not ChessBoard(Ti, Tj + 1).pieceControl Then
                        ChessBoard(Ti, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, Tj + 1).nextMove = True
                    Else
                        If ChessBoard(Ti, Tj + 1).controlBy = Player.Red Then
                            ChessBoard(Ti, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, Tj + 1).nextMove = True
                        End If
                        right = False
                    End If
                Else
                    right = False
                End If

                If Tj > 0 Then
                    If Not ChessBoard(Ti, Tj - 1).pieceControl Then
                        ChessBoard(Ti, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                        ChessBoard(Ti, Tj - 1).nextMove = True
                    Else
                        If ChessBoard(Ti, Tj - 1).controlBy = Player.Red Then
                            ChessBoard(Ti, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                            ChessBoard(Ti, Tj - 1).nextMove = True
                        End If
                        left = False
                    End If
                Else
                    left = False
                End If

                If down Or right Then
                    If Ti < 7 And Tj < 7 Then
                        If Not ChessBoard(Ti + 1, Tj + 1).pieceControl Then
                            ChessBoard(Ti + 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + 1, Tj + 1).nextMove = True
                        Else
                            If ChessBoard(Ti + 1, Tj + 1).controlBy = Player.Red Then
                                ChessBoard(Ti + 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + 1, Tj + 1).nextMove = True
                            End If
                        End If
                    End If
                End If

                If down Or left Then
                    If Ti < 7 And Tj > 0 Then
                        If Not ChessBoard(Ti + 1, Tj - 1).pieceControl Then
                            ChessBoard(Ti + 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti + 1, Tj - 1).nextMove = True
                        Else
                            If ChessBoard(Ti + 1, Tj - 1).controlBy = Player.Red Then
                                ChessBoard(Ti + 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti + 1, Tj - 1).nextMove = True
                            End If
                        End If
                    Else
                    End If
                End If

                If up Or left Then
                    If Ti > 0 And Tj > 0 Then
                        If Not ChessBoard(Ti - 1, Tj - 1).pieceControl Then
                            ChessBoard(Ti - 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - 1, Tj - 1).nextMove = True
                        Else
                            If ChessBoard(Ti - 1, Tj - 1).controlBy = Player.Red Then
                                ChessBoard(Ti - 1, Tj - 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - 1, Tj - 1).nextMove = True
                            End If
                        End If
                    End If
                End If

                If up Or right Then
                    If Ti > 0 And Tj < 7 Then
                        If Not ChessBoard(Ti - 1, Tj + 1).pieceControl Then
                            ChessBoard(Ti - 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Yellow)
                            ChessBoard(Ti - 1, Tj + 1).nextMove = True
                        Else
                            If ChessBoard(Ti - 1, Tj + 1).controlBy = Player.Red Then
                                ChessBoard(Ti - 1, Tj + 1).controls(0).BackColor = Color.FromArgb(100, Color.Red)
                                ChessBoard(Ti - 1, Tj + 1).nextMove = True
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub nextturn()
        If turn = Player.Red Then
            turn = Player.Blue
        ElseIf turn = Player.Blue Then
            turn = Player.Red
        End If
    End Sub

    Private Sub goEvent(ByVal target As Place)
        If target.nextMove Then
            movePlaceA(target.controls(0))
            nextturn()
        Else
            movePlaceB(target.controls(0), target.controlBy)
        End If
    End Sub

    Private Sub clickPlace(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim controls As Label = CType(sender, Label)
        Dim noloop As Boolean = False

        If Not play Then
            Exit Sub
        End If

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If ChessBoard(i, j).controls(0) Is controls Then
                    goEvent(ChessBoard(i, j))
                    targetI = i
                    targetJ = j
                    noloop = True
                    Exit For
                End If
            Next
            If noloop Then Exit For
        Next
    End Sub

    Private Sub checkDeath(ByVal target As Control)
        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If ChessBoard(i, j).controls(0) Is target Then
                    If ChessBoard(i, j).pieceControl Then
                        deathTime(i, j, ChessBoard(i, j).controlBy)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub deathTime(ByVal i As Integer, ByVal j As Integer, ByVal player As Player)
        Dim deathPlace() As Control
        Select Case player
            Case Player.Red
                For x = 0 To RedPlayer.Length - 1
                    If RedPlayer(x).seat(0) Is ChessBoard(i, j).controls(0) Then
                        RedPlayer(x).death = True
                        deathPlace = Controls.Find("lblRD" & (redDeath + 1), True)
                        deathPlace(0).Text = ChessBoard(i, j).controls(0).Text
                        deathPlace(0).ForeColor = ChessBoard(i, j).controls(0).ForeColor
                        redDeath += 1
                        Exit For
                    End If
                Next
            Case Player.Blue
                For x = 0 To BluePlayer.Length - 1
                    If BluePlayer(x).seat(0) Is ChessBoard(i, j).controls(0) Then
                        BluePlayer(x).death = True
                        deathPlace = Controls.Find("lblBD" & (blueDeath + 1), True)
                        deathPlace(0).Text = ChessBoard(i, j).controls(0).Text
                        deathPlace(0).ForeColor = ChessBoard(i, j).controls(0).ForeColor
                        blueDeath += 1
                        Exit For
                    End If
                Next
        End Select
    End Sub

    Private Sub checkWin()
        If RedPlayer(0).death Then
            MessageBox.Show("Blue Team Win!", "Game Over", MessageBoxButtons.OK)
            play = False
        ElseIf BluePlayer(0).death Then
            MessageBox.Show("Red Team Win!", "Game Over", MessageBoxButtons.OK)
            play = False
        Else
            Return
        End If
    End Sub

    Private Sub checkKing()
        Dim kingR As Boolean = False
        Dim kingB As Boolean = False

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If ChessBoard(i, j).pieceControl Then
                    Select Case ChessBoard(i, j).controls(0).Text
                        Case "P"
                            If PawnCheck(ChessBoard(i, j).controls(0), ChessBoard(i, j).controlBy) Then
                                Select Case ChessBoard(i, j).controlBy
                                    Case Player.Red
                                        kingR = True
                                    Case Player.Blue
                                        kingB = True
                                End Select
                            End If
                        Case "R"
                            If RookCheck(ChessBoard(i, j).controls(0), ChessBoard(i, j).controlBy) Then
                                Select Case ChessBoard(i, j).controlBy
                                    Case Player.Red
                                        kingR = True
                                    Case Player.Blue
                                        kingB = True
                                End Select
                            End If
                        Case "H"
                            If HorseCheck(ChessBoard(i, j).controls(0), ChessBoard(i, j).controlBy) Then
                                Select Case ChessBoard(i, j).controlBy
                                    Case Player.Red
                                        kingR = True
                                    Case Player.Blue
                                        kingB = True
                                End Select
                            End If
                        Case "B"
                            If BishopCheck(ChessBoard(i, j).controls(0), ChessBoard(i, j).controlBy) Then
                                Select Case ChessBoard(i, j).controlBy
                                    Case Player.Red
                                        kingR = True
                                    Case Player.Blue
                                        kingB = True
                                End Select
                            End If
                        Case "Q"
                            If QueenCheck(ChessBoard(i, j).controls(0), ChessBoard(i, j).controlBy) Then
                                Select Case ChessBoard(i, j).controlBy
                                    Case Player.Red
                                        kingR = True
                                    Case Player.Blue
                                        kingB = True
                                End Select
                            End If
                        Case "K"
                            If kingCheck(ChessBoard(i, j).controls(0), ChessBoard(i, j).controlBy) Then
                                Select Case ChessBoard(i, j).controlBy
                                    Case Player.Red
                                        kingR = True
                                    Case Player.Blue
                                        kingB = True
                                End Select
                            End If
                    End Select
                End If
            Next
        Next

        If kingR Or kingB Then
            If kingR Then
                Warning(Player.Red)
            End If

            If kingB Then
                Warning(Player.Blue)
            End If
        Else
            Warning(Player.None)
        End If
    End Sub

    Private Sub Warning(ByVal turn As Player)
        Select Case turn
            Case Player.Red
                lblBW.Text = "Your King is Danger!!"
            Case Player.Blue
                lblRW.Text = "Your King is Danger!!"
            Case Player.None
                lblBW.Text = ""
                lblRW.Text = ""
        End Select
    End Sub

    Private Function PawnCheck(ByVal target As Control, ByVal player As Player) As Boolean
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                If Ti < 7 Then
                    If Tj > 0 Then
                        If ChessBoard(Ti + 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj - 1).controlBy = Player.Blue Then
                                If ChessBoard(Ti + 1, Tj - 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If

                    If Tj < 7 Then
                        If ChessBoard(Ti + 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj + 1).controlBy = Player.Blue Then
                                If ChessBoard(Ti + 1, Tj + 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If

            Case Player.Blue
                If Ti > 0 Then
                    If Tj > 0 Then
                        If ChessBoard(Ti - 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj - 1).controlBy = Player.Red Then
                                If ChessBoard(Ti - 1, Tj - 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If

                    If Tj < 7 Then
                        If ChessBoard(Ti - 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj + 1).controlBy = Player.Red Then
                                If ChessBoard(Ti - 1, Tj + 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If
        End Select
        Return False
    End Function

    Private Function RookCheck(ByVal target As Control, ByVal player As Player) As Boolean
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

            Case Player.Blue
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

        End Select
        Return False
    End Function

    Private Function HorseCheck(ByVal target As Control, ByVal player As Player) As Boolean
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim eightPosition(7, 1) As Integer
        Dim DifferentI, DifferentJ As Integer
        Dim noBlock As Integer

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        eightPosition = {{Ti - 2, Tj - 1}, {Ti - 2, Tj + 1},
                         {Ti - 1, Tj - 2}, {Ti - 1, Tj + 2},
                         {Ti + 1, Tj - 2}, {Ti + 1, Tj + 2},
                         {Ti + 2, Tj - 1}, {Ti + 2, Tj + 1}}

        Select Case player
            Case Player.Red
                For i = 0 To eightPosition.GetLength(0) - 1
                    If eightPosition(i, 0) < 0 Or eightPosition(i, 0) > 7 Then
                        Continue For
                    ElseIf eightPosition(i, 1) < 0 Or eightPosition(i, 1) > 7 Then
                        Continue For
                    Else
                        noBlock = 0
                        DifferentI = eightPosition(i, 0) - Ti
                        DifferentJ = eightPosition(i, 1) - Tj

                        If DifferentI = -2 Then
                            For y = -1 To DifferentI Step -1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti - y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentJ = -2 Then
                            For x = -1 To DifferentJ Step -1
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj - x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentJ = 2 Then
                            For x = 1 To DifferentJ
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentI = 2 Then
                            For y = 1 To DifferentI Step 1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti + y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        End If

                        If noBlock < 2 Then
                            If ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controlBy = Player.Blue Then
                                If ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        Else
                            Continue For
                        End If
                    End If
                Next
            Case Player.Blue
                For i = 0 To eightPosition.GetLength(0) - 1
                    If eightPosition(i, 0) < 0 Or eightPosition(i, 0) > 7 Then
                        Continue For
                    ElseIf eightPosition(i, 1) < 0 Or eightPosition(i, 1) > 7 Then
                        Continue For
                    Else
                        noBlock = 0
                        DifferentI = eightPosition(i, 0) - Ti
                        DifferentJ = eightPosition(i, 1) - Tj

                        If DifferentI = -2 Then
                            For y = -1 To DifferentI Step -1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti - y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentJ = -2 Then
                            For x = -1 To DifferentJ Step -1
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj - x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentJ = 2 Then
                            For x = 1 To DifferentJ
                                If ChessBoard(Ti, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For x = 0 To 1
                                If ChessBoard(Ti + DifferentI, Tj + x).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        ElseIf DifferentI = 2 Then
                            For y = 1 To DifferentI Step 1
                                If ChessBoard(Ti + y, Tj).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next

                            For y = 0 To 1
                                If ChessBoard(Ti + y, Tj + DifferentJ).pieceControl Then
                                    noBlock += 1
                                    Exit For
                                End If
                            Next
                        End If

                        If noBlock < 2 Then
                            If ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controlBy = Player.Red Then
                                If ChessBoard(eightPosition(i, 0), eightPosition(i, 1)).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        Else
                            Continue For
                        End If
                    End If
                Next
        End Select
        Return False
    End Function

    Private Function BishopCheck(ByVal target As Control, ByVal player As Player) As Boolean
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim d As Integer
        Dim move As Integer
        Dim newI, newJ As Integer
        Dim stopPlace As Boolean

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj + d).pieceControl Then
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Blue Then
                                If ChessBoard(Ti + d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj - d).pieceControl Then
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Blue Then
                                If ChessBoard(Ti + d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj - d).pieceControl Then
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Blue Then
                                If ChessBoard(Ti - d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj + d).pieceControl Then
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Blue Then
                                If ChessBoard(Ti - d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
            Case Player.Blue
                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj + d).pieceControl Then
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Red Then
                                If ChessBoard(Ti + d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj - d).pieceControl Then
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Red Then
                                If ChessBoard(Ti + d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj - d).pieceControl Then
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Red Then
                                If ChessBoard(Ti - d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj + d).pieceControl Then
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Red Then
                                If ChessBoard(Ti - d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
        End Select
        Return False
    End Function

    Private Function QueenCheck(ByVal target As Control, ByVal player As Player) As Boolean
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim d As Integer
        Dim move As Integer
        Dim newI, newJ As Integer
        Dim stopPlace As Boolean

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Blue Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Blue Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj + d).pieceControl Then
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Blue Then
                                If ChessBoard(Ti + d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj - d).pieceControl Then
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Blue Then
                                If ChessBoard(Ti + d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj - d).pieceControl Then
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Blue Then
                                If ChessBoard(Ti - d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj + d).pieceControl Then
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Blue Then
                                If ChessBoard(Ti - d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
            Case Player.Blue
                For i = Ti + 1 To ChessBoard.GetLength(0) - 1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For i = Ti - 1 To 0 Step -1
                    If ChessBoard(i, Tj).pieceControl Then
                        If ChessBoard(i, Tj).controlBy = Player.Red Then
                            If ChessBoard(i, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj + 1 To ChessBoard.GetLength(1) - 1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                For j = Tj - 1 To 0 Step -1
                    If ChessBoard(Ti, j).pieceControl Then
                        If ChessBoard(Ti, j).controlBy = Player.Red Then
                            If ChessBoard(Ti, j).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        Exit For
                    End If
                Next

                d = 1
                While Ti + d < 8 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj + d).pieceControl Then
                            If ChessBoard(Ti + d, Tj + d).controlBy = Player.Red Then
                                If ChessBoard(Ti + d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                    d += 1
                End While

                d = 1
                While Ti + d < 8 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI += 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI + 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti + d, Tj - d).pieceControl Then
                            If ChessBoard(Ti + d, Tj - d).controlBy = Player.Red Then
                                If ChessBoard(Ti + d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj - d > -1
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ -= 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ - 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj - d).pieceControl Then
                            If ChessBoard(Ti - d, Tj - d).controlBy = Player.Red Then
                                If ChessBoard(Ti - d, Tj - d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While

                d = 1
                While Ti - d > -1 And Tj + d < 8
                    stopPlace = False
                    For i = 1 To d
                        move = 0
                        newI = Ti
                        newJ = Tj
                        While move < i - 1
                            newI -= 1
                            newJ += 1
                            move += 1
                        End While

                        If ChessBoard(newI - 1, newJ).pieceControl And ChessBoard(newI, newJ + 1).pieceControl Then
                            stopPlace = True
                            Exit For
                        End If
                    Next

                    If Not stopPlace Then
                        If ChessBoard(Ti - d, Tj + d).pieceControl Then
                            If ChessBoard(Ti - d, Tj + d).controlBy = Player.Red Then
                                If ChessBoard(Ti - d, Tj + d).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                    d += 1
                End While
        End Select
        Return False
    End Function

    Private Function kingCheck(ByVal target As Control, ByVal player As Player) As Boolean
        Dim noloop As Boolean = False
        Dim Ti, Tj As Integer
        Dim up, down, left, right As Boolean

        For i = 0 To ChessBoard.GetLength(0) - 1
            For j = 0 To ChessBoard.GetLength(1) - 1
                If target Is ChessBoard(i, j).controls(0) Then
                    Ti = i
                    Tj = j
                    noloop = True
                End If
            Next
            If noloop Then Exit For
        Next

        Select Case player
            Case Player.Red
                up = True
                down = True
                right = True
                left = True

                If Ti < 7 Then
                    If ChessBoard(Ti + 1, Tj).pieceControl Then
                        If ChessBoard(Ti + 1, Tj).controlBy = Player.Blue Then
                            If ChessBoard(Ti + 1, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        down = False
                    End If
                Else
                    down = False
                End If

                If Ti > 0 Then
                    If ChessBoard(Ti - 1, Tj).pieceControl Then
                        If ChessBoard(Ti - 1, Tj).controlBy = Player.Blue Then
                            If ChessBoard(Ti - 1, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        up = False
                    End If
                Else
                    up = False
                End If

                If Tj < 7 Then
                    If ChessBoard(Ti, Tj + 1).pieceControl Then
                        If ChessBoard(Ti, Tj + 1).controlBy = Player.Blue Then
                            If ChessBoard(Ti, Tj + 1).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        right = False
                    End If
                Else
                    right = False
                End If

                If Tj > 0 Then
                    If ChessBoard(Ti, Tj - 1).pieceControl Then
                        If ChessBoard(Ti, Tj - 1).controlBy = Player.Blue Then
                            If ChessBoard(Ti, Tj - 1).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        left = False
                    End If
                Else
                    left = False
                End If

                If down Or right Then
                    If Ti < 7 And Tj < 7 Then
                        If ChessBoard(Ti + 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj + 1).controlBy = Player.Blue Then
                                If ChessBoard(Ti + 1, Tj + 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If

                If down Or left Then
                    If Ti < 7 And Tj > 0 Then
                        If ChessBoard(Ti + 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj - 1).controlBy = Player.Blue Then
                                If ChessBoard(Ti + 1, Tj - 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    Else
                    End If
                End If

                If up Or left Then
                    If Ti > 0 And Tj > 0 Then
                        If ChessBoard(Ti - 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj - 1).controlBy = Player.Blue Then
                                If ChessBoard(Ti - 1, Tj - 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If

                If up Or right Then
                    If Ti > 0 And Tj < 7 Then
                        If ChessBoard(Ti - 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj + 1).controlBy = Player.Blue Then
                                If ChessBoard(Ti - 1, Tj + 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If
            Case Player.Blue
                up = True
                down = True
                right = True
                left = True

                If Ti < 7 Then
                    If ChessBoard(Ti + 1, Tj).pieceControl Then
                        If ChessBoard(Ti + 1, Tj).controlBy = Player.Red Then
                            If ChessBoard(Ti + 1, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        down = False
                    End If
                Else
                    down = False
                End If

                If Ti > 0 Then
                    If ChessBoard(Ti - 1, Tj).pieceControl Then
                        If ChessBoard(Ti - 1, Tj).controlBy = Player.Red Then
                            If ChessBoard(Ti - 1, Tj).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        up = False
                    End If
                Else
                    up = False
                End If

                If Tj < 7 Then
                    If ChessBoard(Ti, Tj + 1).pieceControl Then
                        If ChessBoard(Ti, Tj + 1).controlBy = Player.Red Then
                            If ChessBoard(Ti, Tj + 1).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        right = False
                    End If
                Else
                    right = False
                End If

                If Tj > 0 Then
                    If ChessBoard(Ti, Tj - 1).pieceControl Then
                        If ChessBoard(Ti, Tj - 1).controlBy = Player.Red Then
                            If ChessBoard(Ti, Tj - 1).controls(0).Text = "K" Then
                                Return True
                            End If
                        End If
                        left = False
                    End If
                Else
                    left = False
                End If

                If down Or right Then
                    If Ti < 7 And Tj < 7 Then
                        If ChessBoard(Ti + 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj + 1).controlBy = Player.Red Then
                                If ChessBoard(Ti + 1, Tj + 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If

                If down Or left Then
                    If Ti < 7 And Tj > 0 Then
                        If ChessBoard(Ti + 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti + 1, Tj - 1).controlBy = Player.Red Then
                                If ChessBoard(Ti + 1, Tj - 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    Else
                    End If
                End If

                If up Or left Then
                    If Ti > 0 And Tj > 0 Then
                        If ChessBoard(Ti - 1, Tj - 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj - 1).controlBy = Player.Red Then
                                If ChessBoard(Ti - 1, Tj - 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If

                If up Or right Then
                    If Ti > 0 And Tj < 7 Then
                        If ChessBoard(Ti - 1, Tj + 1).pieceControl Then
                            If ChessBoard(Ti - 1, Tj + 1).controlBy = Player.Red Then
                                If ChessBoard(Ti - 1, Tj + 1).controls(0).Text = "K" Then
                                    Return True
                                End If
                            End If
                        End If
                    End If
                End If
        End Select
        Return False
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize()
    End Sub
End Class
