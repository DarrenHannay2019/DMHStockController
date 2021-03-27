Imports System.Data.SqlClient

Public Class FSuppliersEntry
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim duplicateCommand As New SqlCommand
    Private Sub FSuppliersEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "OLD" Then LoadOld()
        If FMain.txtMode.Text = "NEW" Then loadnew()
        If FMain.txtMode.Text = "DELETE" Then deleteRecord()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Ok" Then updateRecord()
        If Button1.Text = "Add" Then SaveRecord()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearscreen()
    End Sub
    Private Sub LoadOld()
        Button1.Text = "Ok"
        Button2.Text = "Cancel"
        Button3.Visible = False
        TextBox1.Enabled = False

        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        TextBox1.Text = FMain.DgvRecords.Item(0, i).Value
        TextBox2.Text = FMain.DgvRecords.Item(1, i).Value
        TextBox3.Text = FMain.DgvRecords.Item(7, i).Value
        TextBox4.Text = FMain.DgvRecords.Item(2, i).Value
        TextBox5.Text = FMain.DgvRecords.Item(3, i).Value
        TextBox6.Text = FMain.DgvRecords.Item(4, i).Value
        TextBox7.Text = FMain.DgvRecords.Item(8, i).Value
        TextBox8.Text = FMain.DgvRecords.Item(9, i).Value
        TextBox9.Text = FMain.DgvRecords.Item(10, i).Value
        TextBox10.Text = FMain.DgvRecords.Item(9, i).Value
        TextBox11.Text = FMain.DgvRecords.Item(10, i).Value
        TextBox12.Text = FMain.DgvRecords.Item(11, i).Value
        TextBox13.Text = FMain.DgvRecords.Item(12, i).Value
        Dim viewtrans As String = "SELECT * from qrySuppliersTransDisplay where SupplierRef='" & TextBox1.Text & "' Order By DeliveryDate"
        Dim gettrans As New SqlDataAdapter(viewtrans, connection)
        Dim bds As New DataSet()
        Me.Text = "Supplier [ " & TextBox1.Text & " ] " & TextBox2.Text
        connection.Open()
        gettrans.Fill(bds, "qrySuppliersTransDisplay")
        connection.Close()
        gridTrans.DataSource = bds
        gridTrans.DataMember = "qrySuppliersTransDisplay"
        gridTrans.Columns.Item(0).Visible = True
        gridTrans.Columns.Item(1).Visible = False
        gridTrans.Columns.Item(2).Visible = True
        gridTrans.Columns.Item(0).HeaderText = "Delivery No"
        gridTrans.Columns.Item(3).Visible = True
        gridTrans.Columns.Item(4).Visible = True
        gridTrans.Columns.Item(2).HeaderText = "Stock Code"
        gridTrans.Columns.Item(5).Visible = True
        gridTrans.Columns.Item(3).HeaderText = "Qty"
        gridTrans.Columns.Item(5).HeaderText = "Del Date"
        gridTrans.Columns.Item(4).HeaderText = "Cost"
    End Sub
    Private Sub loadnew()
        Button1.Text = "Add"
        Button2.Text = "Cancel"
        Button3.Text = "Clear"
        Me.Text = "New Supplier Entry"
    End Sub
    Private Sub SaveRecord()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblSuppliers WHERE SupplierRef = '" + TextBox1.Text + "'"
            queryResult = duplicateCommand.ExecuteScalar()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Suppliers Record :" + TextBox1.Text + "[" + TextBox2.Text + "] Already Exists in the database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Information) : TextBox1.Select() : Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        InsertCommand.Connection = connection
        InsertCommand.Connection.Open()
        InsertCommand.CommandText = " INSERT INTO tblSuppliers (SupplierRef,SupplierName,Address1,Address2,Address3,Address4,PostCode,ContactName,Telephone,Telephone2,Fax,eMail,Memo,CreatedBy,CreatedDate) VALUES (@SupplierRef,@SupplierName,@Address1,@Address2,@Address3,@Address4,@PostCode,@ContactName,@Telephone,@Telephone2,@Fax,@eMail,@Memo,@CreatedBy,@CreatedDate)"
        InsertCommand.CommandType = CommandType.Text
        InsertCommand.Parameters.AddWithValue("@SupplierRef", TextBox1.Text)
        InsertCommand.Parameters.AddWithValue("@SupplierName", TextBox2.Text)
        InsertCommand.Parameters.AddWithValue("@Address1", TextBox4.Text)
        InsertCommand.Parameters.AddWithValue("@Address2", TextBox5.Text)
        InsertCommand.Parameters.AddWithValue("@Address3", TextBox6.Text)
        InsertCommand.Parameters.AddWithValue("@Address4", TextBox7.Text)
        InsertCommand.Parameters.AddWithValue("@PostCode", TextBox8.Text)
        InsertCommand.Parameters.AddWithValue("@ContactName", TextBox3.Text)
        InsertCommand.Parameters.AddWithValue("@Telephone", TextBox9.Text)
        InsertCommand.Parameters.AddWithValue("@Telephone2", TextBox10.Text)
        InsertCommand.Parameters.AddWithValue("@Fax", TextBox11.Text)
        InsertCommand.Parameters.AddWithValue("@eMail", TextBox12.Text)
        InsertCommand.Parameters.AddWithValue("@Memo", TextBox13.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text.ToString())
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
        FMain.SuppliersToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub deleteRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        TextBox1.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblSuppliers WHERE SupplierRef='" & TextBox1.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.SuppliersToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub updateRecord()
        UpdateCommand.Connection = connection
        UpdateCommand.Connection.Open()
        UpdateCommand.CommandText = "UPDATE tblSuppliers SET SupplierRef = @SupplierRef,SupplierName = @SupplierName,Address1 = @Address1,Address2 = @Address2,Address3 = @Address3,Address4 = @Address4,PostCode = @PostCode,ContactName = @ContactName,Telephone = @Telephone,Telephone2 = @Telephone2,Fax = @Fax,eMail = @eMail,Memo = @Memo WHERE SupplierRef = @SupplierRef"
        UpdateCommand.CommandType = CommandType.Text
        UpdateCommand.Parameters.AddWithValue("@SupplierRef", TextBox1.Text)
        UpdateCommand.Parameters.AddWithValue("@SupplierName", TextBox2.Text)
        UpdateCommand.Parameters.AddWithValue("@Address1", TextBox4.Text)
        UpdateCommand.Parameters.AddWithValue("@Address2", TextBox5.Text)
        UpdateCommand.Parameters.AddWithValue("@Address3", TextBox6.Text)
        UpdateCommand.Parameters.AddWithValue("@Address4", TextBox7.Text)
        UpdateCommand.Parameters.AddWithValue("@PostCode", TextBox8.Text)
        UpdateCommand.Parameters.AddWithValue("@ContactName", TextBox3.Text)
        UpdateCommand.Parameters.AddWithValue("@Telephone", TextBox9.Text)
        UpdateCommand.Parameters.AddWithValue("@Telephone2", TextBox10.Text)
        UpdateCommand.Parameters.AddWithValue("@eMail", TextBox12.Text)
        UpdateCommand.Parameters.AddWithValue("@Memo", TextBox13.Text)
        UpdateCommand.Parameters.AddWithValue("@Fax", TextBox11.Text)
        UpdateCommand.ExecuteNonQuery()
        UpdateCommand.Connection.Close()
        FMain.SuppliersToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub clearscreen()
        TextBox1.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
    End Sub
End Class