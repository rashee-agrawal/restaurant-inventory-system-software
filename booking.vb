Imports System.IO
Public Class booking
    Dim m As MsgBoxResult
    Dim t As String

    Private Sub booking_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

    Private Sub booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim m1 As MsgBoxResult
        t = MonthCalendar1.SelectionRange.Start.Month.ToString & MonthCalendar1.SelectionRange.Start.Day.ToString
        If Date.Today = MonthCalendar1.TodayDate And File.Exists(t & ".txt") = True Then
            m1 = MsgBox("You have appointments set for today, would u like to view them ?", MsgBoxStyle.YesNo)
            If m1 = MsgBoxResult.Yes Then
                MonthCalendar1.Enabled = False
                MonthCalendar1.Hide()
                TextBox1.Enabled = True
                TextBox1.Show()
                Button1.Enabled = True
                Button1.Show()
                Button2.Enabled = True
                Button2.Show()

                TextBox1.Text = File.ReadAllText(t & ".txt")

            End If
        End If
        TextBox1.Focus()

    End Sub


    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        t = MonthCalendar1.SelectionRange.Start.Month.ToString & MonthCalendar1.SelectionRange.Start.Day.ToString

        Try
            If File.Exists(t & ".txt") = True Then
                MonthCalendar1.Enabled = False
                MonthCalendar1.Hide()
                TextBox1.Enabled = True
                TextBox1.Show()
                Button1.Enabled = True
                Button1.Show()
                Button2.Enabled = True
                Button2.Show()

                TextBox1.Text = File.ReadAllText(t & ".txt")
            Else
                m = MsgBox("Would u like to enter appointments for this date ?", MsgBoxStyle.YesNo)
                If m = MsgBoxResult.Yes Then
                    MonthCalendar1.Enabled = False
                    MonthCalendar1.Hide()
                    TextBox1.Enabled = True
                    TextBox1.Show()
                    TextBox1.Text = ""
                    Button1.Enabled = True
                    Button1.Show()
                    Button2.Enabled = True
                    Button2.Show()

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Enabled = False
        TextBox1.Hide()
        Button1.Enabled = False
        Button1.Hide()
        Button2.Enabled = False
        Button2.Hide()

        MonthCalendar1.Enabled = True
        MonthCalendar1.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                If File.Exists(t & ".txt") = True Then
                    File.Delete(t & ".txt")


                End If
            End If
            If TextBox1.Text.Length > 0 Then
                File.WriteAllText(t & ".txt", TextBox1.Text)

            End If
            MsgBox("Saved !!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        welcomepage.Show()
        Me.Hide()

    End Sub
End Class