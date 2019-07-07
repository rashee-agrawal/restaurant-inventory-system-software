Imports System.Data.SqlClient
Public Class employeepage
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim strQ As String = String.Empty
    Dim itemcoll(100) As String
    Dim sql As String
    Dim fname As String
    Dim rd As SqlDataReader


    Public Sub connect()
        Try
            conn = New SqlConnection("Data Source=CW\SQLEXPRESS;Initial Catalog=startermenu;integrated security=true")
            conn.Open()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub employeepage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub
  
    Private Sub employeepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            connect()
            cmd = New SqlCommand("select max(EMP_ID) from employeetbl ", conn)
            rd = cmd.ExecuteReader
            While rd.Read()
                If IsDBNull(rd.Item(0)) Then
                    TextBox1.Text = 1
                ElseIf TextBox1.Text = rd.Item(0) + 1 Then

                End If
            End While

        Catch ex As Exception

        End Try
        rd.Close()


        sql = "select * from employeetbl  order by emp_id"
        da = New SqlDataAdapter(sql, conn)
        ds = New DataSet
        da.Fill(ds, "employeetbl")
        DataGridView1.DataSource = ds.Tables(0)

        autoid()
        DataGridView1.AllowUserToAddRows = False

    End Sub

   

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
        sql = "insert into employeetbl values(" & Val(TextBox1.Text) & ",'" & TextBox2.Text & "'," & Val(TextBox3.Text) & ",'" & TextBox4.Text & "','" & TextBox5.Text & "'," & Val(TextBox6.Text) & "," & Val(TextBox7.Text) & ",'" & ComboBox1.Text & "','" & ComboBox2.Text & "')"



        cmd = New SqlCommand(sql, conn)


        cmd.ExecuteNonQuery()
        Button4_Click(sender, e)


        MsgBox("saved")

        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()




    End Sub

    Public Sub autoid()
        sql = "select count(*) from employeetbl"
        cmd = New SqlCommand(sql, conn)
        Dim ct As Integer = cmd.ExecuteScalar
        TextBox1.Text = ct + 1
        TextBox2.Focus()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            connect()
            sql = "select * from employeetbl order by emp_id"
            da = New SqlDataAdapter(sql, conn)
            ds = New DataSet
            da.Fill(ds, "employeetbl")
            DataGridView1.DataSource = ds.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        autoid()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
       
         
        If Me.DataGridView1.Rows.Count > 0 Then
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                fname = Me.DataGridView1.SelectedRows(0).Cells(0).Value
                'open connection

                connect()


                'delete data
                Dim cmd As New SqlCommand
                cmd.Connection = conn

                cmd.CommandText = "DELETE FROM employeetbl WHERE emp_id=" & fname & ""
                Dim res As DialogResult
                res = MsgBox("Are you sure you want to DELETE the selected Row?", MessageBoxButtons.YesNo)
                If res = Windows.Forms.DialogResult.Yes Then
                    cmd.ExecuteNonQuery()
                Else : Exit Sub
                End If
                'refresh data
                DataGridView1.Refresh()

                'close connection
                cmd.Dispose()
                conn.Close()

            End If
        End If
        For Each x In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(x)
        Next
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
  
        ''''''''''''''''''''''''''
        Dim reader As SqlDataReader
        Dim arr(), idx As Integer
        Dim sql1 As String
        Dim cmdr As SqlCommand
        connect()
        Dim sql As String
        sql = "select count(*)  from employeetbl"
        cmdr = New SqlCommand(sql, conn)
        Dim x1 As Integer = cmdr.ExecuteScalar


        sql1 = "select emp_id from employeetbl"
        cmdr = New SqlCommand(sql1, conn)
        reader = cmdr.ExecuteReader

        ReDim arr(x1 - 1)
        While reader.Read
            arr(idx) = reader.Item(0)
            idx = idx + 1
        End While
        reader.Close()

        For i = 0 To x1 - 1
            cmd = New SqlCommand("update employeetbl set emp_id=" & i + 1 & " where emp_id=" & arr(i), conn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Next
        ' ''''''''''''''''''''''''''
  
    End Sub
    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        Me.TextBox1.Text = DataGridView1.Item(0, i).Value
        Me.TextBox2.Text = DataGridView1.Item(1, i).Value
        Me.TextBox3.Text = DataGridView1.Item(2, i).Value
        Me.TextBox4.Text = DataGridView1.Item(3, i).Value
        Me.TextBox5.Text = DataGridView1.Item(4, i).Value
        Me.TextBox6.Text = DataGridView1.Item(5, i).Value
        Me.TextBox7.Text = DataGridView1.Item(6, i).Value
        Me.ComboBox1.Text = DataGridView1.Item(7, i).Value
        Me.ComboBox2.Text = DataGridView1.Item(8, i).Value
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        welcomepage.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            connect()

            sql = "update employeetbl set emp_name='" & TextBox2.Text & "',contact_no=" & TextBox3.Text & ",address='" & TextBox4.Text & "',department='" & TextBox5.Text & "',salary=" & TextBox6.Text & ",bonus=" & TextBox7.Text & ",m_performance='" & ComboBox1.Text & "',m_attendance='" & ComboBox2.Text & "' where emp_id=" & TextBox1.Text & ""

            MsgBox(sql)
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            Button4_Click(sender, e)
            MsgBox("Updated Successfully !!")

            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar Like "[A-Za-z]" Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar Like "[A-Za-z]" Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If e.KeyChar Like "[A-Za-z]" Then
            e.Handled = True
        End If
    End Sub

   
   
End Class