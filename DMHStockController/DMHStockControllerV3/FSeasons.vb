Imports System.Data.SqlClient

Public Class FSeasons
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Add" Then SaveData()
        If Button1.Text = "OK" Then UpdateData()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub FSeasons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.txtMode.Text = "NEW" Then MyNew()
        If Form1.txtMode.Text = "DELETE" Then MyDelete()
        If Form1.txtMode.Text = "OLD" Then MyOld()
    End Sub
    Public Sub MyNew()
        Button1.Text = "Add"
        Button2.Text = "Cancel"
        Button3.Text = "Clear"
    End Sub
    Public Sub MyOld()
        Button1.Text = "OK"
        Button3.Visible = False
        Button2.Text = "Cancel"
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        TextBox1.Text = Form1.DataGridView1.Item(0, i).Value
        TextBox2.Text = Form1.DataGridView1.Item(1, i).Value
    End Sub
    Public Sub MyDelete()
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        TextBox1.Text = Form1.DataGridView1.Item(0, i).Value
        TextBox2.Text = Form1.DataGridView1.Item(1, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblSeasons WHERE SeasonID='" & TextBox1.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        Form1.SeasonToolStripMenuItem.PerformClick()
        Me.Close()

    End Sub

    Private Sub UpdateData()
        UpdateCommand.Connection = connection
        UpdateCommand.Connection.Open()
        UpdateCommand.CommandType = CommandType.Text
        UpdateCommand.CommandText = "UPDATE tblSeasons SET SeasonName = @SeasonName WHERE SeasonID='" & TextBox1.Text & "'"
        UpdateCommand.Parameters.AddWithValue("@SeasonName", TextBox2.Text)
        UpdateCommand.ExecuteNonQuery()
        UpdateCommand.Connection.Close()
    End Sub
    Private Sub SaveData()
        Dim insertdb As String = " INSERT INTO tblSeasons ([SeasonName])VALUES(@SeasonName)"
        InsertCommand.Connection = connection
        InsertCommand.Connection.Open()
        InsertCommand.CommandType = CommandType.Text
        InsertCommand.CommandText = insertdb
        InsertCommand.Parameters.Add(New SqlParameter("@SeasonName", SqlDbType.NVarChar, 50))
        InsertCommand.Parameters("@SeasonName").Value = TextBox2.Text
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
        Form1.SeasonToolStripMenuItem.PerformClick()
    End Sub
End Class