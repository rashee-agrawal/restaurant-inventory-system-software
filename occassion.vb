
Imports System.Data.SqlClient
Public Class occassion
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim sql As String
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As String

    Public Sub connect()
        Try
            cn = New SqlConnection("data source=CW\SQLEXPRESS;initial catalog=startermenu;integrated security=true")
            cn.Open()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub occassion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dtArrSpecialDates() As Date = New Date() {#2/27/2019#, #2/24/2019#, #2/17/2019#}
        'MonthCalendar1.BoldedDates = dtArrSpecialDates
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        TextBox7.Text = MonthCalendar1.SelectionRange.Start
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        sql = "insert into booktbl values('" & TextBox7.Text & "','" & TextBox1.Text & "'," & TextBox2.Text & ",'" & TextBox3.Text & "'," & TextBox4.Text & ",'" & TextBox5.Text & "'," & TextBox6.Text & ")"
        cmd = New SqlCommand(sql, cn)
        cmd.ExecuteNonQuery()
        MsgBox("Saved !!")
        cn.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()

        sql = "select *from booktbl"
        da = New SqlDataAdapter(sql, cn)
        ds = New DataSet
        da.Fill(ds, "booktbl")
        DataGridView1.DataSource = ds.Tables(0)
        cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            connect()

            sql = "update booktbl set name='" & TextBox1.Text & "',contact_no=" & TextBox2.Text & ",time='" & TextBox3.Text & "',no_of_person=" & TextBox4.Text & ",event='" & TextBox5.Text & "',table_no=" & TextBox6.Text & " where date='" & TextBox7.Text & "'"

            MsgBox(sql)
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            Button3_Click(sender, e)
            MsgBox("Updated Successfully")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            cn.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.TextBox1.Text = DataGridView1.Item(1, i).Value
        Me.TextBox2.Text = DataGridView1.Item(2, i).Value
        Me.TextBox3.Text = DataGridView1.Item(3, i).Value
        Me.TextBox4.Text = DataGridView1.Item(4, i).Value
        Me.TextBox5.Text = DataGridView1.Item(5, i).Value
        Me.TextBox6.Text = DataGridView1.Item(6, i).Value
        Me.TextBox7.Text = DataGridView1.Item(0, i).Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                dt = Me.DataGridView1.SelectedRows(0).Cells(0).Value
                'open connection

                connect()


                'delete data
                Dim cmd As New SqlCommand
                cmd.Connection = cn
                cmd.CommandText = "DELETE FROM booktbl WHERE date='" & dt & "'"
                Dim res As DialogResult
                res = MsgBox("Are you sure you want to DELETE the selected Row?", MessageBoxButtons.YesNo)
                If res = Windows.Forms.DialogResult.Yes Then
                    cmd.ExecuteNonQuery()
                Else : Exit Sub
                End If
                'refresh data
                DataGridView1.Refresh()

                'close connection
                cn.Close()
            End If
        End If
        For Each x In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(x)
        Next
    End Sub
End Class
