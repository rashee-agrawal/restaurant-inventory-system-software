
Imports System.Data.SqlClient
Public Class newitem
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim myquery As String
    Dim sql As String
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim fname As String
   
    Public Sub connect()

        Try
            cn = New SqlConnection("Data source=CW\SQLEXPRESS;initial catalog=startermenu;integrated security=true")
            cn.Open()
            
           

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        If ComboBox1.SelectedIndex = 0 Then
            myquery = "insert into startermenutbl values('" & TextBox1.Text & "','" & TextBox2.Text & "'," & Val(TextBox3.Text) & ")"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            myquery = "insert into maincoursetbl values('" & TextBox1.Text & "','" & TextBox2.Text & "'," & Val(TextBox3.Text) & ")"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            myquery = "insert into drinkstbl values('" & TextBox1.Text & "','" & TextBox2.Text & "'," & Val(TextBox3.Text) & ")"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            myquery = "insert into desertstbl values('" & TextBox1.Text & "','" & TextBox2.Text & "'," & Val(TextBox3.Text) & ")"

        End If
        cmd = New SqlCommand(myquery, cn)
        cmd.ExecuteNonQuery()
        Button3_Click(sender, e)
        MsgBox("Saved !!")
        cn.Close()

        TextBox1.Clear()

        TextBox2.Clear()
        TextBox3.Clear()
        TextBox1.Focus()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect()
        If ComboBox1.SelectedIndex = 0 Then
            sql = "select *from startermenutbl"
            da = New SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "startermenutbl")
            DataGridView1.DataSource = ds.Tables(0)
        ElseIf ComboBox1.SelectedIndex = 1 Then
            sql = "select *from maincoursetbl"
            da = New SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "maincoursetbl")
            DataGridView1.DataSource = ds.Tables(0)
        ElseIf ComboBox1.SelectedIndex = 2 Then
            sql = "select *from drinkstbl"
            da = New SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "drinkstbl")
            DataGridView1.DataSource = ds.Tables(0)
        ElseIf ComboBox1.SelectedIndex = 3 Then
            sql = "select *from desertstbl"
            da = New SqlDataAdapter(sql, cn)
            ds = New DataSet
            da.Fill(ds, "desertstbl")
            DataGridView1.DataSource = ds.Tables(0)
        End If  
       
    End Sub
   
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        
        Try
            If ComboBox1.SelectedIndex = 0 Then


                If Me.DataGridView1.Rows.Count > 0 Then
                    If Me.DataGridView1.SelectedRows.Count > 0 Then
                        fname = Me.DataGridView1.SelectedRows(0).Cells(0).Value
                        'open connection

                        connect()


                        'delete data
                        Dim cmd As New SqlCommand
                        cmd.Connection = cn
                        cmd.CommandText = "DELETE FROM startermenutbl WHERE foodname='" & fname & "'"
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
            ElseIf ComboBox1.SelectedIndex = 1 Then



                If Me.DataGridView1.Rows.Count > 0 Then
                    If Me.DataGridView1.SelectedRows.Count > 0 Then
                        fname = Me.DataGridView1.SelectedRows(0).Cells(0).Value
                        'open connection

                        connect()


                        'delete data
                        Dim cmd As New SqlCommand
                        cmd.Connection = cn
                        cmd.CommandText = "DELETE FROM maincoursetbl WHERE foodname='" & fname & "'"
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
            ElseIf ComboBox1.SelectedIndex = 2 Then


                If Me.DataGridView1.Rows.Count > 0 Then
                    If Me.DataGridView1.SelectedRows.Count > 0 Then
                        fname = Me.DataGridView1.SelectedRows(0).Cells(0).Value
                        'open connection

                        connect()


                        'delete data
                        Dim cmd As New SqlCommand
                        cmd.Connection = cn
                        cmd.CommandText = "DELETE FROM drinkstbl WHERE foodname='" & fname & "'"
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
            ElseIf ComboBox1.SelectedIndex = 3 Then


                If Me.DataGridView1.Rows.Count > 0 Then
                    If Me.DataGridView1.SelectedRows.Count > 0 Then
                        fname = Me.DataGridView1.SelectedRows(0).Cells(0).Value
                        'open connection

                        connect()


                        'delete data
                        Dim cmd As New SqlCommand
                        cmd.Connection = cn
                        cmd.CommandText = "DELETE FROM desertstbl WHERE foodname='" & fname & "'"
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
            End If
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()


        Catch ex As Exception
        End Try
    End Sub

  
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            connect()
            If ComboBox1.SelectedIndex = 0 Then


                sql = "update startermenutbl set price=" & TextBox3.Text & ",picture='" & TextBox2.Text & "' where foodname='" & TextBox1.Text & "'"
                MsgBox(sql)
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            ElseIf ComboBox1.SelectedIndex = 1 Then
                sql = "update maincoursetbl set price=" & TextBox3.Text & ",picture='" & TextBox2.Text & "' where foodname='" & TextBox1.Text & "'"
                MsgBox(sql)
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            ElseIf ComboBox1.SelectedIndex = 2 Then
                sql = "update drinkstbl set price=" & TextBox3.Text & ",picture='" & TextBox2.Text & "' where foodname='" & TextBox1.Text & "'"
                MsgBox(sql)
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()

            ElseIf ComboBox1.SelectedIndex = 3 Then
                sql = "update desertstbl set price=" & TextBox3.Text & ",picture='" & TextBox2.Text & "' where foodname='" & TextBox1.Text & "'"
                MsgBox(sql)
                cmd = New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End If
            Button3_Click(sender, e)
            MsgBox("Updated Successfully")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

       
    End Sub

   

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Me.TextBox1.Text = DataGridView1.Item(0, i).Value
        Me.TextBox2.Text = DataGridView1.Item(1, i).Value
        Me.TextBox3.Text = DataGridView1.Item(2, i).Value
        fname = TextBox1.Text
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim od As New OpenFileDialog
        od.ShowDialog()
        TextBox2.Text = od.SafeFileName

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar Like "[A-Za-z]" Then
            e.Handled = True

        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub newitem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

    
End Class