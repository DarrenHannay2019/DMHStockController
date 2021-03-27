Imports System.Data.SqlClient
Public Class FChgPwd
    Dim ConnectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim PassConnection As New SqlConnection(ConnectionString)
    Dim Com As New SqlCommand
    Dim Passds As New DataSet
    Dim masterpassword As String
    Dim oldpass As String
    Dim newpass As String
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        newpass = TextBox2.Text
        oldpass = TextBox1.Text
        If oldpass <> masterpassword Then Change_Password()
        If oldpass = masterpassword Then MsgBox("Please check your old password", MsgBoxStyle.Critical, "DMH Stock Master v2")
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FChgPwd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim useridda As New SqlDataAdapter("SELECT * from tblEmployee where LoginCode = '" + Form1.ToolStripTextBox1.Text + "'", passconnection)
        passconnection.Open()
        useridda.Fill(passds, "tblEmployee")
        passconnection.Close()
        masterpassword = passds.Tables(0).Rows(0).Item("Password")
    End Sub
    Private Sub Change_Password()
        If newpass = TextBox3.Text Then
            Dim sqltext As String = "  Update [dbo].[tblEmployee] SET [Password] = @Password  WHERE LoginCode = @LoginCode"
            Dim com As New SqlCommand(sqltext, passconnection)
            com.Connection.Open()
            com.Parameters.AddWithValue("@Password", newpass)
            com.Parameters.AddWithValue("@LoginCode", Form1.ToolStripTextBox1.Text.ToString())
            com.ExecuteNonQuery()
            com.Connection.Close()
            MsgBox("Password has been Updated", MsgBoxStyle.Information, "StockMaster V2")
            Me.Close()
        Else
            MsgBox("New and Confirmed passwords don't match", MsgBoxStyle.Critical, "DMH Stock Master v2")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox1.Focus()
        End If

    End Sub
End Class