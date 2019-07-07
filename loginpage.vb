Public Class loginpage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If usernametxt.Text = "Admin" And pwdtxt.Text = "1234" Then
            ProgressBar1.Visible = True
            Label3.Visible = True
            Timer1.Enabled = True
        Else
            MsgBox("Invalid Username or Password ", MsgBoxStyle.Critical, "loginpage")

            ProgressBar1.Visible = False
            Label3.Visible = False
            usernametxt.Clear()
            pwdtxt.Clear()
            usernametxt.Focus()

        End If





    End Sub

    Private Sub loginpage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

    Private Sub loginpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        Label3.Visible = False
        ProgressBar1.Visible = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 2
        Label3.Text = ProgressBar1.Value & "% " & "Completed"
        If ProgressBar1.Value >= 100 Then
            Timer1.Enabled = False
            If usernametxt.Text = "Admin" And pwdtxt.Text = "1234" Then
                MsgBox("WELCOME !!!", MsgBoxStyle.Information, "loginpage")
                ProgressBar1.Value = 0
                welcomepage.Show()
                Me.Hide()

            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class