Imports System.Data.SqlClient
Public Class billingpage
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim sql As String
    Dim ds As DataSet
    Dim rd As SqlDataReader
    Dim f As String

    Public Sub connect()
        Try
            cn = New SqlConnection("data source=CW\SQLEXPRESS;initial catalog=startermenu;integrated security=true")
            cn.Open()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub billingpage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub

    Private Sub billingpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()

       
       
        Label4.Text = DateTime.Now.ToLongDateString()
        Label5.Text = TimeOfDay
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
       
        Dim rt As Integer, qty As Integer, tot As Integer, i As Integer
        Dim gtot As Integer

        For i = 0 To DataGridView1.Rows.Count - 1
            rt = Val(DataGridView1.Rows(i).Cells(2).Value)
            qty = Val(DataGridView1.Rows(i).Cells(3).Value)
            tot = rt * qty
            gtot = gtot + tot
            DataGridView1.Rows(i).Cells(4).Value = tot

        Next
        Label1.Text = "Grand Total - " & gtot
        '''''''
        cmd = New SqlCommand("delete from billtbl", cn)

        cmd.ExecuteNonQuery()
        cmd = Nothing
        For Each rw As DataGridViewRow In DataGridView1.Rows
            cmd = New SqlCommand("insert into billtbl (sr_no,foodname,price,qty,total) values (" & rw.Cells(0).Value & ",'" & rw.Cells(1).Value & "'," & rw.Cells(2).Value & ",'" & rw.Cells(3).Value & "'," & rw.Cells(4).Value & ")", cn)


            cmd.ExecuteNonQuery()
        Next

        Dim str As String
        str = "insert into grandtotal values(" & gtot & ",'" & Now & "')"

        
        cmd = New SqlCommand(str, cn)
        cmd.ExecuteNonQuery()
        MsgBox("Saved !!")


        cn.Close()


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Text = TimeOfDay
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        welcomepage.Show()
        Me.Hide()
    End Sub

    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim pb As New printbill
        pb.Show()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()
        DataGridView1.Rows.Clear()

        connect()

        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Sr_no"
        DataGridView1.Columns(1).Name = "FOODNAME"
        DataGridView1.Columns(2).Name = "PRICE"
        DataGridView1.Columns(3).Name = "QTY"
        DataGridView1.Columns(4).Name = "TOTAL"

        cmd = New SqlCommand("select FOODNAME,PRICE from selectiontbl", cn)
        rd = cmd.ExecuteReader
        Dim idx As Integer = 0

        While rd.Read
            DataGridView1.Rows.Add()
            DataGridView1.Rows(idx).Cells(0).Value = idx + 1
            DataGridView1.Rows(idx).Cells(1).Value = rd.Item(0)
            DataGridView1.Rows(idx).Cells(2).Value = rd.Item(1)
            idx = idx + 1




        End While
        rd.Close()


        DataGridView1.AllowUserToAddRows = False
        

    End Sub
End Class