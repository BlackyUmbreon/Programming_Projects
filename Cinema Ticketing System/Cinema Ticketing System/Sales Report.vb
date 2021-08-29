Public Class Sales_Report
    Dim move As Boolean = False
    Dim locX, locY As Integer

    Const stringConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\user\Desktop\Assignment\Cinema Ticketing System\Cinema Ticketing System\DB Cinema.mdf';Integrated Security=True"

    Private Sub picClose_MouseHover(sender As Object, e As EventArgs) Handles picClose.MouseHover
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\CloseHover.png")
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        picClose.Load("C:\Users\user\Desktop\Assignment\Picture\basic\Close.png")
    End Sub

    Private Sub picClose_MouseClick(sender As Object, e As MouseEventArgs) Handles picClose.MouseClick, btnBack.Click
        Me.Close()
        Home.Show()
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
    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
        End
    End Sub

    Private Sub btnGenerate_Down(sender As Object, e As EventArgs) Handles btnGenerate.MouseDown
        btnGenerate.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnGenerate_Up(sender As Object, e As EventArgs) Handles btnGenerate.MouseUp
        btnGenerate.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnPrint_Down(sender As Object, e As EventArgs) Handles btnPrint.MouseDown
        btnPrint.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub btnPrint_Up(sender As Object, e As EventArgs) Handles btnPrint.MouseUp
        btnPrint.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub btnBack_Down(sender As Object, e As EventArgs) Handles btnBack.MouseDown
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonDown.jpg")
    End Sub

    Private Sub radDaily_CheckedChanged(sender As Object, e As EventArgs) Handles radDaily.CheckedChanged
        If radDaily.Checked = True Then
            gpDaily.Enabled = True
            gpDaily.BackColor = Color.FromArgb(200, 100, 100, 100)
        Else
            gpDaily.Enabled = False
            gpDaily.BackColor = Color.FromArgb(200, 0, 0, 0)
        End If
    End Sub

    Private Sub radWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles radWeekly.CheckedChanged
        If radWeekly.Checked = True Then
            gpWeekly.Enabled = True
            gpWeekly.BackColor = Color.FromArgb(200, 100, 100, 100)
        Else
            gpWeekly.Enabled = False
            gpWeekly.BackColor = Color.FromArgb(200, 0, 0, 0)
        End If
    End Sub

    Private Sub radYearly_CheckedChanged(sender As Object, e As EventArgs) Handles radYearly.CheckedChanged
        If radYearly.Checked = True Then
            gpYearly.Enabled = True
            gpYearly.BackColor = Color.FromArgb(200, 100, 100, 100)
        Else
            gpYearly.Enabled = False
            gpYearly.BackColor = Color.FromArgb(200, 0, 0, 0)
        End If
    End Sub

    Private Sub radMonthly_CheckedChanged(sender As Object, e As EventArgs) Handles radMonthly.CheckedChanged
        If radMonthly.Checked = True Then
            gpMonthly.Enabled = True
            gpMonthly.BackColor = Color.FromArgb(200, 100, 100, 100)
        Else
            gpMonthly.Enabled = False
            gpMonthly.BackColor = Color.FromArgb(200, 0, 0, 0)
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim dataConn As New SqlClient.SqlConnection(stringConn)
        Dim dataComm As SqlClient.SqlCommand

        Dim dataadpt As SqlClient.SqlDataAdapter
        Dim datatable As New DataTable()

        If radDaily.Checked Then
            Dim day As Integer = cboDailyDay.SelectedItem
            Dim month As Integer = cboDailyMonth.SelectedItem
            Dim year As Integer = cboDailyYear.SelectedItem
            Dim strSQL As String = "Select * From [Transaction] Where Date = '" & month & "/" & day & "/" & year & "' order by Date"

            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            printDailyListBox(datatable)
        ElseIf radWeekly.Checked Then
            Dim day As Integer = cboWeeklyDay.SelectedItem
            Dim month As Integer = cboWeeklyMonth.SelectedItem
            Dim year As Integer = cboWeeklyYear.SelectedItem
            Dim nextDay As Integer = day + 6
            Dim nextMonth As Integer = month
            Dim nextYear As Integer = year
            next7Day(nextDay, nextMonth, nextYear)
            Dim strSQL As String = "Select [Date], count([ID]) , Sum([TicketPurchased]), Sum([ComboCount]), Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & nextMonth & "/" & nextDay & "/" & nextYear & "' group by Date order by Date"

            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            printWeeklyListBox(datatable)
        ElseIf radMonthly.Checked Then
            Dim day As Integer = 1
            Dim month As Integer = cboMonthlyMonth.SelectedItem
            Dim year As Integer = cboMonthlyYear.SelectedItem
            Dim nextDay As Integer = day
            Dim nextMonth As Integer = month + 1
            Dim nextYear As Integer = year
            next1Month(nextDay, nextMonth, nextYear)
            Dim strSQL As String = "Select [Date], count([ID]) , Sum([TicketPurchased]), Sum([ComboCount]), Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & nextMonth & "/" & nextDay & "/" & nextYear & "' group by Date order by Date"

            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            printWeeklyListBox(datatable)
        ElseIf radYearly.Checked Then
            Dim day As Integer = 1
            Dim month As Integer = 1
            Dim year As Integer = cboYearlyYear.SelectedItem

            Dim strSQL As String = "Select [MovieSelectID], count([ID]) as count , Sum([TicketPurchased]), Sum([ComboCount]), Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & month & "/" & day & "/" & year + 1 & "' group by [MovieSelectID] order by Sum([Price]) DESC"

            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            printTopListBox(datatable)
        End If

        If lstReport.Items.Count > 1 Then
            btnPrint.Enabled = True
        Else
            btnPrint.Enabled = False
        End If

    End Sub

    Private Sub printDailyListBox(ByVal datatable As DataTable)
        Dim i As Integer = 0
        Dim str As String = ""
        lstReport.Items.Clear()
        lstReport.Items.Add(String.Format("{0,-26} {1,-26} {2,-32} {3,-24} {4,-23} {5,-26} {6,-29} {7,-30}", "Transaction ID", "Customer ID", "Staff ID", "Movie Selected ID", "No. of Tickets", "No. of Combo Selected", "Date Booking", "Total Price (RM)"))
        For i = 0 To datatable.Rows.Count - 1 Step 1
            str = String.Format("{0,-30} {1,-30} {2,-30} {3,-30} {4,-30} {5,-40} {6,-30} {7,-30}", datatable.Rows(i).Item(0), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4), datatable.Rows(i).Item(5), CDate(datatable.Rows(i).Item(6)).ToString("MM/dd/yyyy"), datatable.Rows(i).Item(7))
            lstReport.Items.Add(str)
        Next

        lblTotal.Text = lstReport.Items.Count - 1
    End Sub

    Private Sub printWeeklyListBox(ByVal datatable As DataTable)
        Dim i As Integer = 0
        Dim str As String = ""
        lstReport.Items.Clear()
        lstReport.Items.Add(String.Format("{0,-25} {1,-29} {2,-29} {3,-30} {4,-30}", "Date Booking", "Total Number of Booking", "Total Tickets Purchased", "Total Combo Selected", "Total Price (RM)"))
        For i = 0 To datatable.Rows.Count - 1 Step 1
            str = String.Format("{0,-26} {1,-45} {2,-40} {3,-43} {4,-30}", CDate(datatable.Rows(i).Item(0)).ToString("MM/dd/yyyy"), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4))
            lstReport.Items.Add(str)
        Next

        lblTotal.Text = lstReport.Items.Count - 1
    End Sub

    Private Sub printTopListBox(ByVal datatable As DataTable)
        Dim i As Integer = 0
        Dim str As String = ""
        lstReport.Items.Clear()
        lstReport.Items.Add(String.Format("{0,-24} {1,-30} {2,-29} {3,-30} {4,-30}", "Movie ID", "Total Number of Booking", "Total Tickets Purchased", "Total Combo Selected", "Total Price (RM)"))
        For i = 0 To datatable.Rows.Count - 1 Step 1
            str = String.Format("{0,-26} {1,-45} {2,-40} {3,-43} {4,-30}", datatable.Rows(i).Item(0), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4))
            lstReport.Items.Add(str)
        Next

        lblTotal.Text = lstReport.Items.Count - 1
    End Sub

    Private Sub btnBack_Up(sender As Object, e As EventArgs) Handles btnBack.MouseUp
        btnBack.BackgroundImage = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\basic\ButtonUp.jpg")
    End Sub

    Private Sub Sales_Report_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitializeDate()
        radDaily.Checked = True
    End Sub

    Private Sub next7Day(ByRef day As Integer, ByRef month As Integer, ByRef year As Integer)
        If CInt(year) Mod 4 = 0 Then
            Select Case CInt(month)
                Case 1, 3, 5, 7, 8, 10, 12
                    If day > 31 Then
                        day -= 31
                        month += 1
                        If month > 12 Then
                            year += 1
                            month -= 12
                        End If
                    End If
                Case 4, 6, 9, 11
                    If day > 30 Then
                        day -= 30
                        month += 1
                    End If
                Case 2
                    If day > 29 Then
                        day -= 29
                        month += 1
                    End If

            End Select
        Else
            Select Case CInt(month)
                Case 1, 3, 5, 7, 8, 10, 12
                    If day > 31 Then
                        day -= 31
                        month += 1
                        If month > 12 Then
                            year += 1
                            month -= 12
                        End If
                    End If
                Case 4, 6, 9, 11
                    If day > 30 Then
                        day -= 30
                        month += 1
                    End If
                Case 2
                    If day > 28 Then
                        day -= 28
                        month += 1
                    End If
            End Select
        End If
    End Sub

    Private Sub next1Month(ByRef day As Integer, ByRef month As Integer, ByRef year As Integer)
        If month > 12 Then
            year += 1
            month -= 12
        End If
    End Sub

    Private Sub dateChange()
        Dim i As Integer
        If radDaily.Checked = True Then
            If CInt(cboDailyYear.SelectedItem) Mod 4 = 0 Then
                Select Case CInt(cboDailyMonth.SelectedItem)
                    Case 1, 3, 5, 7, 8, 10, 12
                        cboDailyDay.Items.Clear()
                        For i = 0 To 30
                            cboDailyDay.Items.Add(i + 1)
                        Next
                    Case 4, 6, 9, 11
                        cboDailyDay.Items.Clear()
                        For i = 0 To 29
                            cboDailyDay.Items.Add(i + 1)
                        Next
                    Case 2
                        cboDailyDay.Items.Clear()
                        For i = 0 To 28
                            cboDailyDay.Items.Add(i + 1)
                        Next
                End Select
                cboDailyDay.SelectedIndex = 0
            Else
                Select Case CInt(cboDailyMonth.SelectedItem)
                    Case 1, 3, 5, 7, 8, 10, 12
                        cboDailyDay.Items.Clear()
                        For i = 0 To 30
                            cboDailyDay.Items.Add(i + 1)
                        Next
                    Case 4, 6, 9, 11
                        cboDailyDay.Items.Clear()
                        For i = 0 To 29
                            cboDailyDay.Items.Add(i + 1)
                        Next
                    Case 2
                        cboDailyDay.Items.Clear()
                        For i = 0 To 27
                            cboDailyDay.Items.Add(i + 1)
                        Next
                End Select
                cboDailyDay.SelectedIndex = 0
            End If
        ElseIf radWeekly.Checked Then
            If CInt(cboWeeklyYear.SelectedItem) Mod 4 = 0 Then
                Select Case CInt(cboWeeklyMonth.SelectedItem)
                    Case 1, 3, 5, 7, 8, 10, 12
                        cboWeeklyDay.Items.Clear()
                        For i = 0 To 30
                            cboWeeklyDay.Items.Add(i + 1)
                        Next
                    Case 4, 6, 9, 11
                        cboWeeklyDay.Items.Clear()
                        For i = 0 To 29
                            cboWeeklyDay.Items.Add(i + 1)
                        Next
                    Case 2
                        cboWeeklyDay.Items.Clear()
                        For i = 0 To 28
                            cboWeeklyDay.Items.Add(i + 1)
                        Next
                End Select
                cboWeeklyDay.SelectedIndex = 0
            Else
                Select Case CInt(cboWeeklyMonth.SelectedItem)
                    Case 1, 3, 5, 7, 8, 10, 12
                        cboWeeklyDay.Items.Clear()
                        For i = 0 To 30
                            cboWeeklyDay.Items.Add(i + 1)
                        Next
                    Case 4, 6, 9, 11
                        cboWeeklyDay.Items.Clear()
                        For i = 0 To 29
                            cboWeeklyDay.Items.Add(i + 1)
                        Next
                    Case 2
                        cboWeeklyDay.Items.Clear()
                        For i = 0 To 27
                            cboWeeklyDay.Items.Add(i + 1)
                        Next
                End Select
                cboWeeklyDay.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cboDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDailyYear.SelectedIndexChanged, cboDailyMonth.SelectedIndexChanged, cboWeeklyMonth.SelectedIndexChanged, cboWeeklyYear.SelectedIndexChanged
        dateChange()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        previewReport.Document = docReport
        previewReport.ShowDialog()
    End Sub

    Private Sub docReport_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles docReport.PrintPage
        Dim fontHeading1 As New Font("Times New Roman", 24, FontStyle.Bold)
        Dim fontHeading2 As New Font("Times New Roman", 18, FontStyle.Bold)
        Dim fontresult As New Font("Times New Roman", 14)
        Dim font As New Font("Times New Roman", 10)
        Dim fontHeight As Integer = fontHeading1.GetHeight
        Dim x As Integer = e.MarginBounds.Left
        Dim y As Integer = e.MarginBounds.Top
        Dim dataConn As New SqlClient.SqlConnection(stringConn)
        Dim dataComm As SqlClient.SqlCommand
        Dim dataadpt As SqlClient.SqlDataAdapter
        Dim datatable As New DataTable()

        Dim logoLeft As Image = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\Basic\Icon left.png")
        Dim logoRight As Image = Image.FromFile("C:\Users\user\Desktop\Assignment\Picture\Basic\Icon.png")
        e.Graphics.DrawImage(logoLeft, x - 15, y - 50, 100, 100)
        e.Graphics.DrawString("Shooting Star Cinema", fontHeading1, Brushes.Black, x + 155, y)
        e.Graphics.DrawImage(logoRight, x + 560, y - 50, 100, 100)
        y += fontHeight
        e.Graphics.DrawString("----------------------------------------------------------------", fontHeading1, Brushes.Black, x - 45, y)
        fontHeight = fontHeading2.GetHeight
        y += fontHeight * 2
        If radDaily.Checked Then
            Dim day As Integer = cboDailyDay.SelectedItem
            Dim month As Integer = cboDailyMonth.SelectedItem
            Dim year As Integer = cboDailyYear.SelectedItem
            Dim str As String = String.Format("{0,-20} {1,-16} {2,-15} {3,-20} {4,-18} {5,-20} {6,-16} {7,-20}", "Transaction ID", "Customer ID", "Staff ID", "Movie Selected ID", "No. of Tickets", "Combo Selected", "Date Booking", "Total Price (RM)")
            e.Graphics.DrawString("Daily Sales Report", fontHeading2, Brushes.Black, x - 20, y)
            e.Graphics.DrawString("Date : " & month & "/" & day & "/" & year, fontHeading2, Brushes.Black, x + 500, y)
            fontHeight = font.GetHeight
            y += fontHeight
            e.Graphics.DrawString("----------------------------", fontHeading2, Brushes.Black, x - 30, y)
            y += fontHeight * 3
            e.Graphics.DrawString(str, font, Brushes.Black, x - 75, y)
            y += fontHeight
            str = String.Format("{0,-24} {1,-21} {2,-17} {3,-26} {4,-21} {5,-26} {6,-21} {7,-20}", "-----------------", "----------------", "----------", "-----------------------", "-----------------", "--------------------", "----------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 75, y)
            y += fontHeight * 2

            Dim strSQL As String = "Select * From [Transaction] Where Date = '" & month & "/" & day & "/" & year & "' order by Date"
            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            printDailyListBox(datatable)
            For i = 0 To datatable.Rows.Count - 1 Step 1
                str = String.Format("{0,-26} {1,-22} {2,-15} {3,-27} {4,-26} {5,-30} {6,-20} {7,20}", datatable.Rows(i).Item(0), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4), datatable.Rows(i).Item(5), CDate(datatable.Rows(i).Item(6)).ToString("MM/dd/yyyy"), datatable.Rows(i).Item(7))
                e.Graphics.DrawString(str, font, Brushes.Black, x - 75, y)
                y += fontHeight * 2
            Next

            Dim totaltable As New DataTable
            Dim TotalstrSQL As String = "Select Sum([Price]) From [Transaction] Where Date = '" & month & "/" & day & "/" & year & "' group by Date"
            dataadpt = New SqlClient.SqlDataAdapter(TotalstrSQL, dataConn)
            dataadpt.Fill(totaltable)
            y += fontHeight
            str = String.Format("{0,-24} {1,-21} {2,-17} {3,-26} {4,-21} {5,-26} {6,-21} {7,-20}", "-----------------", "----------------", "----------", "-----------------------", "-----------------", "--------------------", "----------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 75, y)
            y += fontHeight
            str = String.Format("{0,-24} {1,86}", "Total Price:", totaltable.Rows(0).Item(0))
            e.Graphics.DrawString(str, fontHeading2, Brushes.Black, x - 75, y)
            y += fontHeight * 4
            fontHeight = fontresult.GetHeight
            e.Graphics.DrawString("Number of records :" & datatable.Rows.Count, fontresult, Brushes.Black, x - 75, y)
            y += fontHeight * 2
            str = "Updated on : " & TimeOfDay.ToString("h:mm:ss tt")
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 2
            str = "Cinema Name : " & "Shooting Star Cinema"
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 5
            e.Graphics.DrawString("Produced by DCN2 Group2", font, Brushes.Black, x + 250, y)
            y += fontHeight
            e.Graphics.DrawString("Lim Wei Yang, Lo Yee Chang, Julia Adriana, Quek Wei Xuan", font, Brushes.Black, x + 150, y)
        ElseIf radWeekly.Checked Then
            Dim fontDate As New Font("Times New Roman", 14)
            Dim day As Integer = cboWeeklyDay.SelectedItem
            Dim month As Integer = cboWeeklyMonth.SelectedItem
            Dim year As Integer = cboweeklyYear.SelectedItem
            Dim nextDay As Integer = day + 6
            Dim nextMonth As Integer = month
            Dim nextYear As Integer = year
            next7Day(nextDay, nextMonth, nextYear)
            Dim str As String = String.Format("{0,-25} {1,-29} {2,-29} {3,-30} {4,-30}", "Date Booking", "Total Number of Booking", "Total Tickets Purchased", "Total Combo Selected", "Total Price (RM)")
            e.Graphics.DrawString("Weekly Sales Report", fontHeading2, Brushes.Black, x - 15, y)
            e.Graphics.DrawString("Date period: " & month & "/" & day & "/" & year & "-" & nextMonth & "/" & nextDay & "/" & nextYear, fontDate, Brushes.Black, x + 380, y + 10)
            fontHeight = font.GetHeight
            y += fontHeight
            e.Graphics.DrawString("-------------------------------", fontHeading2, Brushes.Black, x - 25, y)
            y += fontHeight * 3
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight
            str = String.Format("{0,-31} {1,-37} {2,-35} {3,-37} {4,-30}", "-----------------", "-------------------------------", "-----------------------------", "--------------------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight

            Dim strSQL As String = "Select [Date], count([ID]) , Sum([TicketPurchased]), Sum([ComboCount]), Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & nextMonth & "/" & nextDay & "/" & nextYear & "' group by Date order by Date"
            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            For i = 0 To datatable.Rows.Count - 1 Step 1
                str = String.Format("{0,-31} {1,-45} {2,-43} {3,-45} {4,20}", CDate(datatable.Rows(i).Item(0)).ToString("MM/dd/yyyy"), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4))
                e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
                y += fontHeight * 2
            Next

            Dim totaltable As New DataTable
            Dim TotalstrSQL As String = "Select Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & nextMonth & "/" & nextDay & "/" & nextYear & "'"
            dataadpt = New SqlClient.SqlDataAdapter(TotalstrSQL, dataConn)
            dataadpt.Fill(totaltable)

            y += fontHeight
            str = String.Format("{0,-31} {1,-37} {2,-35} {3,-37} {4,-30}", "-----------------", "-------------------------------", "-----------------------------", "--------------------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight
            str = String.Format("{0,-24} {1,72}", "Total Price:", totaltable.Rows(0).Item(0))
            e.Graphics.DrawString(str, fontHeading2, Brushes.Black, x - 40, y)
            y += fontHeight * 4
            fontHeight = fontresult.GetHeight
            e.Graphics.DrawString("Number of records :" & datatable.Rows.Count, fontresult, Brushes.Black, x - 75, y)
            y += fontHeight * 2
            str = "Updated on : " & TimeOfDay.ToString("h:mm:ss tt")
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 2
            str = "Cinema Name : " & "Shooting Star Cinema"
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 5
            e.Graphics.DrawString("Produced by DCN2 Group2", font, Brushes.Black, x + 250, y)
            y += fontHeight
            e.Graphics.DrawString("Lim Wei Yang, Lo Yee Chang, Julia Adriana, Quek Wei Xuan", font, Brushes.Black, x + 150, y)
        ElseIf radMonthly.Checked Then
            Dim fontDate As New Font("Times New Roman", 14)
            Dim day As Integer = 1
            Dim month As Integer = cboMonthlyMonth.SelectedItem
            Dim year As Integer = cboMonthlyYear.SelectedItem
            Dim nextDay As Integer = day
            Dim nextMonth As Integer = month + 1
            Dim nextYear As Integer = year
            next1Month(nextDay, nextMonth, nextYear)
            Dim str As String = String.Format("{0,-25} {1,-29} {2,-29} {3,-30} {4,-30}", "Date Booking", "Total Number of Booking", "Total Tickets Purchased", "Total Combo Selected", "Total Price (RM)")
            e.Graphics.DrawString("Monthly Movie box office Report", fontHeading2, Brushes.Black, x - 15, y)
            e.Graphics.DrawString("Date period: " & month & "/" & day & "/" & year & "-" & nextMonth & "/" & nextDay & "/" & nextYear, fontDate, Brushes.Black, x + 420, y + 10)
            fontHeight = font.GetHeight
            y += fontHeight
            e.Graphics.DrawString("------------------------------------------------", fontHeading2, Brushes.Black, x - 25, y)
            y += fontHeight * 3
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight
            str = String.Format("{0,-31} {1,-37} {2,-35} {3,-37} {4,-30}", "-----------------", "-------------------------------", "-----------------------------", "--------------------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight

            Dim strSQL As String = "Select [Date], count([ID]) , Sum([TicketPurchased]), Sum([ComboCount]), Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & nextMonth & "/" & nextDay & "/" & nextYear & "' group by Date order by Date"
            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            For i = 0 To datatable.Rows.Count - 1 Step 1
                str = String.Format("{0,-31} {1,-45} {2,-43} {3,-45} {4,20}", CDate(datatable.Rows(i).Item(0)).ToString("MM/dd/yyyy"), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4))
                e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
                y += fontHeight * 2
            Next

            Dim totaltable As New DataTable
            Dim TotalstrSQL As String = "Select Sum([Price]) From [Transaction] Where Date between '" & month & "/" & day & "/" & year & "' and  '" & nextMonth & "/" & nextDay & "/" & nextYear & "'"
            dataadpt = New SqlClient.SqlDataAdapter(TotalstrSQL, dataConn)
            dataadpt.Fill(totaltable)

            y += fontHeight
            str = String.Format("{0,-31} {1,-37} {2,-35} {3,-37} {4,-30}", "-----------------", "-------------------------------", "-----------------------------", "--------------------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight
            str = String.Format("{0,-24} {1,72}", "Total Price:", totaltable.Rows(0).Item(0))
            e.Graphics.DrawString(str, fontHeading2, Brushes.Black, x - 40, y)
            y += fontHeight * 4
            fontHeight = fontresult.GetHeight
            e.Graphics.DrawString("Number of records :" & datatable.Rows.Count, fontresult, Brushes.Black, x - 75, y)
            y += fontHeight * 2
            str = "Updated on : " & TimeOfDay.ToString("h:mm:ss tt")
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 2
            str = "Cinema Name : " & "Shooting Star Cinema"
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 5
            e.Graphics.DrawString("Produced by DCN2 Group2", font, Brushes.Black, x + 250, y)
            y += fontHeight
            e.Graphics.DrawString("Lim Wei Yang, Lo Yee Chang, Julia Adriana, Quek Wei Xuan", font, Brushes.Black, x + 150, y)
        ElseIf radYearly.Checked Then
            Dim day As Integer = 1
            Dim month As Integer = 1
            Dim year As Integer = cboYearlyYear.SelectedItem
            Dim nextDay As Integer = day
            Dim nextMonth As Integer = month
            Dim nextYear As Integer = year + 1
            next1Month(nextDay, nextMonth, nextYear)
            Dim str As String = String.Format("{0,-10} {1,-15} {2,-29} {3,-30} {4,-30} {5,-30}", "Top", "Movie ID", "Total Number of Booking", "Total Tickets Purchased", "Total Combo Selected", "Total Price (RM)")
            e.Graphics.DrawString("Yearly Top 10 Movie Report", fontHeading2, Brushes.Black, x - 15, y)
            e.Graphics.DrawString("Year : " & year, fontHeading2, Brushes.Black, x + 550, y)
            fontHeight = font.GetHeight
            y += fontHeight
            e.Graphics.DrawString("------------------------------------------", fontHeading2, Brushes.Black, x - 25, y)
            y += fontHeight * 3
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight
            str = String.Format("{0,-12} {1,-18} {2,-39} {3,-36} {4,-37} {5,-30}", "------", "------------", "-----------------------------", "-----------------------------", "--------------------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight

            Dim strSQL As String = "Select [MovieSelectID], count([ID]) as count , Sum([TicketPurchased]), Sum([ComboCount]), Sum([Price]) From [Transaction] Where [Date] between '" & month & "/" & day & "/" & year & "' and  '" & month & "/" & day & "/" & year + 1 & "' group by [MovieSelectID] order by Sum([Price]) DESC"
            dataComm = New SqlClient.SqlCommand(strSQL, dataConn)
            dataadpt = New SqlClient.SqlDataAdapter(dataComm)
            dataadpt.Fill(datatable)

            For i = 0 To datatable.Rows.Count - 1 Step 1
                str = String.Format("{0,-13} {1,-18} {2,-48} {3,-44} {4,-45} {5,15}", i + 1, datatable.Rows(i).Item(0), datatable.Rows(i).Item(1), datatable.Rows(i).Item(2), datatable.Rows(i).Item(3), datatable.Rows(i).Item(4))
                e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
                y += fontHeight * 2
            Next

            y += fontHeight
            str = String.Format("{0,-12} {1,-18} {2,-39} {3,-36} {4,-37} {5,-30}", "------", "------------", "-----------------------------", "-----------------------------", "--------------------------", "--------------------")
            e.Graphics.DrawString(str, font, Brushes.Black, x - 40, y)
            y += fontHeight

            y += fontHeight * 3
            e.Graphics.DrawString("Number of records :" & datatable.Rows.Count, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 2
            str = "Updated on : " & TimeOfDay.ToString("h:mm:ss tt")
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 2
            str = "Cinema Name : " & "Shooting Star Cinema"
            e.Graphics.DrawString(str, fontresult, Brushes.Black, x - 40, y)
            y += fontHeight * 5
            e.Graphics.DrawString("Produced by DCN2 Group2", font, Brushes.Black, x + 250, y)
            y += fontHeight
            e.Graphics.DrawString("Lim Wei Yang, Lo Yee Chang, Julia Adriana, Quek Wei Xuan", font, Brushes.Black, x + 150, y)
        End If

    End Sub


    Private Sub InitializeDate()
        Dim i As Integer
        For i = 1 To 12 Step 1
            cboMonthlyMonth.Items.Add(i)
            cboDailyMonth.Items.Add(i)
            cboWeeklyMonth.Items.Add(i)
        Next
        For i = 100 To 0 Step -1
            cboDailyYear.Items.Add(2019 - i)
            cboWeeklyYear.Items.Add(2019 - i)
            cboYearlyYear.Items.Add(2019 - i)
            cboMonthlyYear.Items.Add(2019 - i)
        Next


        cboMonthlyMonth.SelectedIndex = 0
        cboDailyMonth.SelectedIndex = 0
        cboWeeklyMonth.SelectedIndex = 0
        cboDailyYear.SelectedIndex = 0
        cboWeeklyYear.SelectedIndex = 0
        cboYearlyYear.SelectedIndex = 0
        cboMonthlyYear.SelectedIndex = 0


        radWeekly.Checked = True
        dateChange()

        radDaily.Checked = True
        dateChange()

        cboDailyDay.SelectedIndex = 0
        cboWeeklyDay.SelectedIndex = 0

    End Sub
End Class