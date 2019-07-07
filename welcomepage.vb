Public Class welcomepage

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        startermain.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        startermain.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        billingpage.show()
        Me.Hide()

    End Sub

   

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        employeepage.show()
        Me.Hide()

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        statistics.show()
        Me.Hide()

    End Sub

   

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        booking.Show()
        Me.Hide()

    End Sub

    Private Sub welcomepage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

   
    Private Sub welcomepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class