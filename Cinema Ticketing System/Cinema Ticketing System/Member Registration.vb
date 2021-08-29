Public Class Member_Registration
    Friend count As Integer
    Friend newMember As Modify_Member.Member



    Private Sub initialID()
        Dim ID As String = ""
        If count > 0 And count < 9 Then
            ID = "C00" & (count + 1)
        ElseIf count >= 9 And count < 99 Then
            ID = "C0" & (count + 1)
        ElseIf count >= 99 And count < 999 Then
            ID = "C" & (count + 1)
        End If

        lblMemberID.Text = ID
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If validateInput() Then
            newMember.ID = lblMemberID.Text
            If MessageBox.Show("Do you want to Add this new Staff [" & newMember.ID & "] to Database?", "New Staff", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                With newMember
                    .name = txtUser.Text
                    .email = txtEmail.Text
                    .number = mskPhone.Text
                    .dob = msktxtBirthday.Text
                End With

                With newMember
                    Data_Control.MemberTableAdapter.Insert(.ID, .name, .email, .dob, .number)
                    Data_Control.MemberBindingSource.EndEdit()
                    Data_Control.MemberTableAdapter.Update(Data_Control.DB_CinemaDataSet.Member)
                    Data_Control.MemberTableAdapter.Fill(Data_Control.DB_CinemaDataSet.Member)
                    Data_Control.DataGridView.DataSource = Data_Control.MemberBindingSource
                End With

                MessageBox.Show("new Staff [" & newMember.ID & "] Is Added", "New Staff", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Data_Control.Focus()

            End If
        End If
    End Sub

    Private Function validateInput() As Boolean
        If txtUser.Text = "" Then
            MessageBox.Show("Please Enter MemberName", "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If txtEmail.Text = "" Then
            MessageBox.Show("Please Enter Email", "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Dim Pnum() As String = mskPhone.Text.Split("-")

        If Pnum(0) <> " " And Pnum(1) <> "" Then
            If mskPhone.Text.Length <> 11 Then
                MessageBox.Show("Please Enter Phone Number in Correct Format", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("Please Enter Phone Number", "Null Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Dim num() As String = msktxtBirthday.Text.Split("/")
        Dim dateNum(2) As Integer

        If num(0) = " " Or num(1) = " " Or num(2) = "" Then
            MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            dateNum = {CInt(num(0)), CInt(num(1)), CInt(num(2))}
            If Not dateValidate(dateNum) Then
                Return False
            End If
        End If


        Return True
    End Function

    Private Function dateValidate(ByVal num() As Integer) As Boolean


        If CInt(num(0)) < 0 Then
            MessageBox.Show("Year can't be negative", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If CInt(num(2)) Mod 4 = 0 Then
            Select Case CInt(num(0))
                Case 1, 3, 5, 7, 8, 10, 12
                    If CInt(num(1)) > 0 And CInt(num(1)) < 32 Then
                        Return True
                    Else
                        MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case 4, 6, 9, 11
                    If CInt(num(1)) > 0 And CInt(num(1)) < 31 Then
                        Return True
                    Else
                        MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case 2
                    If CInt(num(1)) > 0 And CInt(num(1)) < 30 Then
                        Return True
                    Else
                        MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case Else
                    MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
            End Select
        Else
            Select Case CInt(num(0))
                Case 1, 3, 5, 7, 8, 10, 12
                    If CInt(num(1)) > 0 And CInt(num(1)) < 32 Then
                        Return True
                    Else
                        MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case 4, 6, 9, 11
                    If CInt(num(1)) > 0 And CInt(num(1)) < 31 Then
                        Return True
                    Else
                        MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case 2
                    If CInt(num(1)) > 0 And CInt(num(1)) < 29 Then
                        Return True
                    Else
                        MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Case Else
                    MessageBox.Show("Date Format 'MM/dd/yyyy'", "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
            End Select
        End If
    End Function

    Private Sub Member_Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEmail.ResetText()
        txtUser.ResetText()
        mskPhone.ResetText()
        msktxtBirthday.ResetText()
        initialID()
    End Sub
End Class