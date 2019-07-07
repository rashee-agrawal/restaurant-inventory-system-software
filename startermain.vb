Imports System.Data.SqlClient

Public Class startermain
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim rd As SqlDataReader
    Dim sql As String

  
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        welcomepage.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        billingpage.Show()
        Me.Hide()

    End Sub
    Public Sub connect()
        Try
            conn = New SqlConnection("Data Source=CW\SQLEXPRESS;Initial Catalog=startermenu;integrated security=true")
            conn.Open()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub startermain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim ans As String = MsgBox("Are You Sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If ans = vbYes Then
            Process.GetCurrentProcess.Kill()

        Else
            e.Cancel = True

        End If
    End Sub
    Private Sub startermain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        ListView1.View = View.SmallIcon
        'Create ImageList objects. 
        Dim imageListLarge As New ImageList()
        imageListLarge.ImageSize = New Size(50, 50)
        Dim ct As Integer
        
        connect()
        sql = "select picture,foodname,price from startermenutbl"
        cmd = New SqlCommand(sql, conn)

        rd = cmd.ExecuteReader
        While rd.Read

            imageListLarge.Images.Add(Bitmap.FromFile("C:\Users\cws\Pictures\restaurant\starters\" & rd.Item(0)))

            ListView1.Items.Add(rd.Item(1) & "-" & rd.Item(2), ct)

            ct = ct + 1
        End While
        ListView1.SmallImageList = imageListLarge
        

        rd.Close()
        conn.Close()

        ''''''''''''''''''''''
        ListView2.View = View.SmallIcon
        'Create ImageList objects. 

        Dim imageListLarge1 As New ImageList()
        imageListLarge1.ImageSize = New Size(50, 50)
        Dim ct1 As Integer

        connect()
        sql = "select picture,foodname,price from maincoursetbl"
        cmd = New SqlCommand(sql, conn)

        rd = cmd.ExecuteReader
        While rd.Read

            imageListLarge1.Images.Add(Bitmap.FromFile("C:\Users\cws\Pictures\restaurant\maincourse\" & rd.Item(0)))

            ListView2.Items.Add(rd.Item(1) & "-" & rd.Item(2), ct1)
            ct1 = ct1 + 1
        End While
        ListView2.SmallImageList = imageListLarge1

        rd.Close()
        conn.Close()
        '''''''''''''
        ListView3.View = View.SmallIcon

        'Create ImageList objects. 
        Dim imageListLarge2 As New ImageList()
        imageListLarge2.ImageSize = New Size(50, 50)
        Dim ct2 As Integer

        connect()
        sql = "select picture,foodname,price from drinkstbl"
        cmd = New SqlCommand(sql, conn)

        rd = cmd.ExecuteReader
        While rd.Read

            imageListLarge2.Images.Add(Bitmap.FromFile("C:\Users\cws\Pictures\restaurant\drinks\" & rd.Item(0)))

            ListView3.Items.Add(rd.Item(1) & "-" & rd.Item(2), ct2)

            ct2 = ct2 + 1
        End While
        ListView3.SmallImageList = imageListLarge2


        rd.Close()
        conn.Close()

        ''''''''''''''''''''''
        ListView4.View = View.SmallIcon

        'Create ImageList objects. 

        Dim imageListLarge3 As New ImageList()
        imageListLarge3.ImageSize = New Size(50, 50)
        Dim ct3 As Integer

        connect()
        sql = "select picture,foodname,price from desertstbl"
        cmd = New SqlCommand(sql, conn)

        rd = cmd.ExecuteReader
        While rd.Read

            imageListLarge3.Images.Add(Bitmap.FromFile("C:\Users\cws\Pictures\restaurant\desserts\" & rd.Item(0)))

            ListView4.Items.Add(rd.Item(1) & "-" & rd.Item(2), ct3)
            ct3 = ct3 + 1
        End While
        ListView4.SmallImageList = imageListLarge3

        rd.Close()
        conn.Close()

        Label6.Text = TimeOfDay
        Label7.Text = DateTime.Now.ToLongDateString()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        newitem.Show()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        cmd = New SqlCommand("delete from selectiontbl", conn)
        cmd.ExecuteNonQuery()
        cmd = Nothing
        For Each item In ListView1.CheckedItems

            Dim str As String
            Dim strArr() As String

            str = item.text
            strArr = str.Split("-")

            cmd = New SqlCommand("insert into selectiontbl values('" & strArr(0) & "'," & strArr(1) & ")", conn)
            cmd.ExecuteNonQuery()
            cmd = Nothing
        Next
        
        For Each item1 In ListView2.CheckedItems

            Dim str1 As String
            Dim strArr1() As String

            str1 = item1.text
            strArr1 = str1.Split("-")

            cmd = New SqlCommand("insert into selectiontbl values('" & strArr1(0) & "'," & strArr1(1) & ")", conn)
            cmd.ExecuteNonQuery()
            cmd = Nothing
        Next
        For Each item2 In ListView3.CheckedItems

            Dim str2 As String
            Dim strArr2() As String

            str2 = item2.text
            strArr2 = str2.Split("-")

            cmd = New SqlCommand("insert into selectiontbl values('" & strArr2(0) & "'," & strArr2(1) & ")", conn)
            cmd.ExecuteNonQuery()
            cmd = Nothing
        Next
        For Each item3 In ListView4.CheckedItems

            Dim str3 As String
            Dim strArr3() As String

            str3 = item3.text
            strArr3 = str3.Split("-")

            cmd = New SqlCommand("insert into selectiontbl values('" & strArr3(0) & "'," & strArr3(1) & ")", conn)
            cmd.ExecuteNonQuery()
            cmd = Nothing
        Next
        
        MsgBox("Get Selected !!")

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = TimeOfDay

    End Sub

    

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        ''    ListView1.CheckedItems.Item(i).Checked = Not (ListView1.CheckedItems.Item(i).Checked)

        'ListView1.CheckedItems.Item(i).Checked = False
        For Each lv1 As ListViewItem In ListView1.CheckedItems
            lv1.Checked = False
        Next
        For Each lv2 As ListViewItem In ListView2.CheckedItems
            lv2.Checked = False
        Next
        For Each lv3 As ListViewItem In ListView3.CheckedItems
            lv3.Checked = False
        Next
        For Each lv4 As ListViewItem In ListView4.CheckedItems
            lv4.Checked = False
        Next
    End Sub
End Class