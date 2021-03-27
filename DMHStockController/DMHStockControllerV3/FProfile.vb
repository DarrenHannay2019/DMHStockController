Imports System.Data.SqlClient
Public Class FProfile
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim cmd As SqlCommand
    Dim cbodata As New DataSet("StockMaster")
    Dim SeasonTable As New DataTable
    Dim SeasonDataAdapter As New SqlDataAdapter("SELECT * from tblProfile", connection)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim duplicateCommand As New SqlCommand
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "OK" Then Me.Close()
        If Button1.Text = "Add" Then SaveData()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub FProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.txtMode.Text = "NEW" Then MyNew()
        If Form1.txtMode.Text = "DELETE" Then MyDelete()
        If Form1.txtMode.Text = "OLD" Then MyOld()
        cbodata.Tables.Add(SeasonTable)
        connection.Open()
        SeasonDataAdapter.Fill(cbodata, "tblProfile")
        connection.Close()
    End Sub
    Public Sub MyNew()
        Button1.Text = "Add"
        Button3.Text = "Cancel"
        Button2.Text = "Clear"
    End Sub
    Public Sub MyDelete()
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        txtProfileID.Text = Form1.DataGridView1.Item(0, i).Value
        TextBox1.Text = Form1.DataGridView1.Item(1, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblProfile WHERE ProfileNo='" & txtProfileID.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        Form1.UserProfileToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Public Sub MyOld()
        Button1.Text = "OK"
        Button2.Visible = False
        Button3.Text = "Cancel"
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        TextBox1.Text = Form1.DataGridView1.Item(1, i).Value
        txtProfileID.Text = Form1.DataGridView1.Item(0, i).Value
    End Sub
    Public Sub SaveData()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblProfile WHERE ProfileName = '" + TextBox1.Text + "' "
            queryResult = duplicateCommand.ExecuteNonQuery()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Profile Record : [" + TextBox1.Text + "] Already Exists in the database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Dim insertdb As String = "INSERT INTO tblProfile (ProfileName)VALUES(@ProfileName)"

        InsertCommand.Connection = connection
        InsertCommand.Connection.Close()
        InsertCommand.Connection.Open()
        InsertCommand.CommandType = CommandType.Text
        InsertCommand.CommandText = "INSERT INTO tblProfile (ProfileName)VALUES(@ProfileName)"
        InsertCommand.Parameters.AddWithValue("@ProfileName", TextBox1.Text)
        'InsertCommand.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 50))
        ' InsertCommand.Parameters("@Description").Value = TextBox1.Text
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
        Form1.UserProfileToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Public Sub UpdateData()
        UpdateCommand.Connection = connection
        UpdateCommand.Connection.Open()
        UpdateCommand.CommandType = CommandType.Text
        UpdateCommand.CommandText = "UPDATE tblProfile SET Description = @ProfileName WHERE ProfileNo='" & txtProfileID.Text & "'"
        UpdateCommand.Parameters.AddWithValue("@ProfileName", TextBox1.Text)
        UpdateCommand.ExecuteNonQuery()
        UpdateCommand.Connection.Close()
        Form1.UserProfileToolStripMenuItem.PerformClick()
    End Sub
End Class