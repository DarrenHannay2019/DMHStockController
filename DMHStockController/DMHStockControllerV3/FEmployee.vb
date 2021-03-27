Imports System.Data.SqlClient
Public Class FEmployee
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Private Sub FEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SettingsDataAdapter As New SqlDataAdapter("SELECT ProfileName Name from tblProfile", connection)
        Dim adata As New DataSet()
        ' cboAccessLA.DataSource = adata
        SettingsDataAdapter.Fill(adata, "tblProfile")
        cboAccessLA.DisplayMember = "ProfileName"
        ' cboAccessLA.ValueMember = "ProfileName"
        For Each dRow As DataRow In adata.Tables("tblProfile").Rows
            cboAccessLA.Items.Add(dRow.Item(0).ToString)
        Next
        If Form1.txtMode.Text = "OLD" Then loadold()
        If Form1.txtMode.Text = "NEW" Then loadnew()
        If Form1.txtMode.Text = "DELETE" Then DeleteItem()
    End Sub

    Private Sub cmdViewAccessLevel_Click(sender As Object, e As EventArgs) Handles cmdViewAccessLevel.Click

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        DuplicateCheck()
        AddRecords()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ClearForm()
    End Sub
    Private Sub AddRecords()
        Try
            ' Dim updatedb As String = " INSERT tblStock SET StockCode = @StockCode,SupplierRef = @SupplierRef,Season = @Season,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers,RemoveFromClearance = @RemoveFromClearance,AmountTaken= @AmountTaken, CostValue = @CostValue,PCMarkUp = @PCMarkUp,ZeroQty= @ZeroQty,CreatedBy = @CreatedBy,CreatedDate= @CreatedDate WHERE StockCode = @StockCode"
            Dim insertdb As String = " INSERT INTO tblStock (FirstName,LastName,LoginCode,Password,ProfileNo,DefaultEmp)VALUES(@FirstName,@LastName,@LoginCode,@Password,@ProfileNo,@DefaultEmp)"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            com.Connection.Open()
            com.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
            com.Parameters.AddWithValue("@LastName", txtLastName.Text)
            com.Parameters.AddWithValue("@LoginCode", txtLoginCode.Text)
            com.Parameters.AddWithValue("@Password", txtPassword.Text)
            com.Parameters.AddWithValue("@ProfileNo", cboAccessLA.SelectedText.ToString())
            com.Parameters.AddWithValue("@DefaultEmp", CheckBox1.Checked)
            com.ExecuteNonQuery()
            com.Connection.Close()
            Form1.EmployeeToolStripMenuItem.PerformClick()
            MsgBox("User record created successfully", MsgBoxStyle.Information, Application.ProductName)
        Catch ex As SqlException
            MsgBox("Update Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "DMH Stock Master v2")
        End Try
        Me.Close()
    End Sub
    Private Sub ClearForm()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtLoginCode.Clear()
        txtPassword.Clear()

    End Sub
    Private Sub DuplicateCheck()
        Try
            Dim queryResult As Integer
            DuplicateCommand.Connection = connection
            DuplicateCommand.Connection.Open()
            DuplicateCommand.CommandType = CommandType.Text
            DuplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStock WHERE LoginCode = '" + txtLoginCode.Text + "'"
            queryResult = DuplicateCommand.ExecuteNonQuery()
            DuplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Employee Record: [" + txtFirstName.Text + " " + txtLastName.Text + "] Already Exists in the database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub DeleteItem()
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        txtLoginCode.Text = Form1.DataGridView1.Item(3, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE * from tblEmployee where LoginCode = '" + txtLoginCode.Text.ToString() + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()

    End Sub
    Private Sub loadnew()

        Me.Text = "New Employee Entry"
    End Sub
    Private Sub loadold()
        cmdAdd.Text = "OK"
        cmdClear.Visible = False
        cmdCancel.Text = "Cancel"
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        txtFirstName.Text = Form1.DataGridView1.Item(1, i).Value
        txtLastName.Text = Form1.DataGridView1.Item(2, i).Value
        txtLoginCode.Text = Form1.DataGridView1.Item(3, i).Value
        txtPassword.Text = Form1.DataGridView1.Item(4, i).Value
        CheckBox1.Checked = Form1.DataGridView1.Item(6, i).Value
        cboAccessLA.Text = Form1.DataGridView1.Item(5, i).Value
    End Sub
End Class