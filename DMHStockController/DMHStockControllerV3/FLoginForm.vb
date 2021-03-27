Imports System.Data.SqlClient
Public Class FLoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        Dim conn As New SqlConnection(connectionString)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        If UsernameTextBox.Text = "" Then
            MsgBox("Enter ID", MsgBoxStyle.Critical)
        ElseIf PasswordTextBox.Text = "" Then
            MsgBox("Enter Password", MsgBoxStyle.Critical)
        Else
            Dim str As String
            str = "Select * from tblEmployees where LoginCode ='" + UsernameTextBox.Text + "' and Password = '" + PasswordTextBox.Text + "'"
            Dim cmd = New SqlCommand(str, conn)
            Dim da = New SqlDataAdapter(cmd)
            Dim ds = New Data.DataSet
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Login failed please enter a vaild UserID and Password", MsgBoxStyle.Critical)
            ElseIf a >= 0 Then
                Form1.ToolStripTextBox1.Text = Me.UsernameTextBox.Text
                Me.Hide()
                Form1.Show()
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
