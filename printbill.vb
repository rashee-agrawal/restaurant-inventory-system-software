Public Class printbill

    Private Sub printbill_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

    Private Sub printbill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'startermenuDataSet.billtbl' table. You can move, or remove it, as needed.
        Me.billtblTableAdapter.Fill(Me.startermenuDataSet.billtbl)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        billingpage.Show()
        Me.Hide()

    End Sub
End Class