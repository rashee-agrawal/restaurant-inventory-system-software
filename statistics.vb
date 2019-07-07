Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class statistics
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim sql As String
    Dim ds As DataSet
    Dim da As SqlDataAdapter
    Dim gt As Long
    Public Sub connect()
        Try
            cn = New SqlConnection("Data Source=CW\SQLEXPRESS;Initial Catalog=startermenu;integrated security=true")
            cn.Open()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Dim x(11) As String
        Dim y(11) As Long
        For i As Integer = 1 To 12
            sql = "select  sum(grand_total) from grandtotal where month(date)=" & i

            cmd = New SqlCommand(sql, cn)
            If cmd.ExecuteScalar IsNot DBNull.Value Then
                gt = cmd.ExecuteScalar
            Else
                gt = 0
            End If
            x(i - 1) = MonthName(i)
            y(i - 1) = gt
            ' MsgBox(x(i - 1) & vbNewLine & y(i - 1))
            cmd.Dispose()
        Next

        Chart1.ChartAreas(0).AxisX.Interval = 1

        Chart1.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Column
        For i = 1 To 12
            Chart1.Series("Series1").Points.AddXY(x(i - 1), y(i - 1))
        Next
        Chart1.Series("Series1")("PointWidth") = "0.7"
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series1").LegendText = "Totals By Month"
        Chart1.ChartAreas(0).AxisX.Title = "Months"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'connect()

        'Dim sqlProducts As String = "SELECT (grand_total),date  FROM grandtotal"
        'Dim da As New SqlDataAdapter(sqlProducts, cn)
        'Dim ds As New DataSet()
        'da.Fill(ds, "grandtotal")



        'Chart1.Size = New System.Drawing.Size(400, 200)
        'Chart1.TabIndex = 1
        'Chart1.Text = "Chart1"

        'Chart1.Series("Series1").XValueMember = gt
        'Chart1.Series("Series1").YValueMembers = "grand_total"

        'Chart1.DataSource = ds.Tables("grandtotal")
        'Chart1.Series.Clear()



    End Sub


    
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        welcomepage.Show()
        Me.Hide()

    End Sub

    Private Sub statistics_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

   
    
End Class