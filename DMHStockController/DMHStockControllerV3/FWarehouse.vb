Imports System.Data.SqlClient

Public Class FWarehouse
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"

    Dim connection As New SqlConnection(connectionString)
    Dim cmd As SqlCommand

    ' Create a DataSet
    Dim cbodata As New DataSet()
    Dim adata As New DataSet()
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim duplicateCommand As New SqlCommand
    Dim WarehouseDataAdapter As New SqlDataAdapter("SELECT * from tblCompanyDetails", connection)
    Dim TransactionsDataAdapter As New SqlDataAdapter("SELECT SeasonName from tblSeasons", connection)
    Private Sub FWarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.txtMode.Text = "OLD" Then LoadOLD()
        If Form1.txtMode.Text = "NEW" Then LoadNew()
        If Form1.txtMode.Text = "DELETE" Then LoadDelete()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Me.Text = " [ " & TextBox1.Text & " ] " & TextBox2.Text
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        Me.Text = " [ " & TextBox1.Text & " ] " & TextBox2.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Add" Then SaveRecord()
        If Button1.Text = "OK" Then updateRecord()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearscreen()
    End Sub
    Private Sub clearscreen()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
    End Sub
    Private Sub updateRecord()
        UpdateCommand.Connection = connection
        UpdateCommand.Connection.Open()
        UpdateCommand.CommandText = "UPDATE tblWarehouses SET WarehouseRef = @WarehouseRef,WarehouseName = @WarehouseName,Address1 = @Address1,Address2 = @Address2,Address3 = @Address3,Address4 = @Address4,PostCode = @PostCode,ContactName = @ContactName,Telephone = @Telephone,Telephone2 = @Telephone2,Fax = @Fax,eMail = @eMail,Memo = @Memo, WarehouseType = @WarehouseType, DefaultWarehouse = @DefaultWarehouse WHERE WarehouseRef = @WarehouseRef"
        UpdateCommand.CommandType = CommandType.Text
        UpdateCommand.Parameters.AddWithValue("@WarehouseRef", TextBox1.Text)
        UpdateCommand.Parameters.AddWithValue("@WarehouseName", TextBox2.Text)
        UpdateCommand.Parameters.AddWithValue("@Address1", TextBox3.Text)
        UpdateCommand.Parameters.AddWithValue("@Address2", TextBox4.Text)
        UpdateCommand.Parameters.AddWithValue("@Address3", TextBox5.Text)
        UpdateCommand.Parameters.AddWithValue("@Address4", TextBox6.Text)
        UpdateCommand.Parameters.AddWithValue("@PostCode", TextBox7.Text)
        UpdateCommand.Parameters.AddWithValue("@ContactName", TextBox8.Text)
        UpdateCommand.Parameters.AddWithValue("@Telephone", TextBox9.Text)
        UpdateCommand.Parameters.AddWithValue("@Telephone2", TextBox10.Text)
        UpdateCommand.Parameters.AddWithValue("@eMail", TextBox12.Text)
        UpdateCommand.Parameters.AddWithValue("@Memo", TextBox13.Text)
        UpdateCommand.Parameters.AddWithValue("@Fax", TextBox11.Text)
        UpdateCommand.Parameters.AddWithValue("@WarehouseType", cboWType.Text.ToString())
        UpdateCommand.Parameters.AddWithValue("@DefaultWarehouse", chkDefault.CheckState)

        UpdateCommand.ExecuteNonQuery()
        UpdateCommand.Connection.Close()
    End Sub
    Private Sub SaveRecord()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblWarehouses WHERE WarehouseRef = '" + TextBox1.Text + "' AND WarehouseName = '" + TextBox2.Text + "'"
            queryResult = duplicateCommand.ExecuteNonQuery()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Warehouse Record :" + TextBox1.Text + "[" + TextBox2.Text + "] Already Exists in the database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandText = " INSERT INTO tblWarehouses (WarehouseRef,WarehouseName,Address1,Address2,Address3,Address4,PostCode,ContactName,Telephone,Telephone2,Fax,eMail,Memo,WarehouseType,CreatedBy,CreatedDate) VALUES (@WarehouseRef,@WarehouseName,@Address1,@Address2,@Address3,@Address4,@PostCode,@ContactName,@Telephone,@Telephone2,@Fax,@eMail,@Memo,@WarehouseType,@CreatedBy,@CreatedDate)"
            InsertCommand.CommandType = CommandType.Text
            InsertCommand.Parameters.AddWithValue("@WarehouseRef", TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@WarehouseName", TextBox2.Text)
            InsertCommand.Parameters.AddWithValue("@Address1", TextBox3.Text)
            InsertCommand.Parameters.AddWithValue("@Address2", TextBox4.Text)
            InsertCommand.Parameters.AddWithValue("@Address3", TextBox5.Text)
            InsertCommand.Parameters.AddWithValue("@Address4", TextBox6.Text)
            InsertCommand.Parameters.AddWithValue("@PostCode", TextBox7.Text)
            InsertCommand.Parameters.AddWithValue("@ContactName", TextBox8.Text)
            InsertCommand.Parameters.AddWithValue("@Telephone", TextBox9.Text)
            InsertCommand.Parameters.AddWithValue("@Telephone2", TextBox10.Text)
            InsertCommand.Parameters.AddWithValue("@Fax", TextBox11.Text)
            InsertCommand.Parameters.AddWithValue("@eMail", TextBox12.Text)
            InsertCommand.Parameters.AddWithValue("@Memo", TextBox13.Text)
            InsertCommand.Parameters.AddWithValue("@WarehouseType", cboWType.Text.ToString)
            ' InsertCommand.Parameters.AddWithValue("@Default", chkDefault.CheckState)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
            InsertCommand.ExecuteNonQuery()
            InsertCommand.Connection.Close()
        Catch ex As SqlException
            MessageBox.Show("Record Error" & vbCr & "Please check the entry", Application.ProductName)
        End Try
    End Sub
    Private Sub LoadOLD()
        Button1.Text = "&Ok"
        Button2.Text = "Cancel"
        Button3.Visible = False


        Me.Text = "Warehouse [ " & TextBox1.Text & " ] " & TextBox2.Text
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        TextBox1.Text = Form1.DataGridView1.Item(1, i).Value
        TextBox2.Text = Form1.DataGridView1.Item(2, i).Value
        TextBox3.Text = Form1.DataGridView1.Item(3, i).Value
        TextBox4.Text = Form1.DataGridView1.Item(4, i).Value
        TextBox5.Text = Form1.DataGridView1.Item(5, i).Value
        TextBox6.Text = Form1.DataGridView1.Item(6, i).Value
        TextBox7.Text = Form1.DataGridView1.Item(7, i).Value
        TextBox8.Text = Form1.DataGridView1.Item(8, i).Value
        TextBox9.Text = Form1.DataGridView1.Item(9, i).Value
        TextBox10.Text = Form1.DataGridView1.Item(10, i).Value
        TextBox11.Text = Form1.DataGridView1.Item(11, i).Value
        TextBox12.Text = Form1.DataGridView1.Item(12, i).Value
        TextBox13.Text = Form1.DataGridView1.Item(13, i).Value
        cboWType.Text = Form1.DataGridView1.Item(14, i).Value
        TextBox13.Text = Form1.DataGridView1.Item(13, i).Value
        'chkDefault.Checked = Form1.DataGridView1.Item(15, i).Value
        Dim viewstock As String = "SELECT * from qryWarehouseStock where SMlocation='" & TextBox1.Text & "' AND QtyHangers > 0 Order By StockCode"
        Dim Viewtrans As String = "SELECT * from qryWarehouseTransDisplay where SMlocation='" & TextBox1.Text & "'"
        Dim getstock As New SqlDataAdapter(viewstock, connection)
        Dim gettrans As New SqlDataAdapter(Viewtrans, connection)
        Dim ads As New DataSet()
        Dim bds As New DataSet()
        connection.Open()
        getstock.Fill(ads, "qryWarehouseStock")
        connection.Close()
        connection.Open()
        gettrans.Fill(bds, "qryWarehouseTransDisplay")
        connection.Close()
        gridStock.DataSource = ads
        gridStock.DataMember = "qryWarehouseStock"
        gridTrans.DataSource = bds
        gridTrans.DataMember = "qryWarehouseTransDisplay"
        ' Dim strSQL As String
        ' Dim strSQL2 As String
        'strSQL = "SELECT * form qryWarehouseStock Where Location='" & TextBox1.Text.ToString & "' ORDER BY StockCode"
        ' strSQL2 = "SELECT * form qryWarehouseTransDisplay Where Location='" & TextBox1.Text.ToString & "'"
        ' Dim dadapter As New SqlDataAdapter(strSQL, connection)
        ' Dim eadapter As New SqlDataAdapter(strSQL2, connection)
        ' BindingSource1.DataSource = dadapter
        ' BindingSource2.DataSource = eadapter
        ' gridStock.ReadOnly = True
        ' gridTrans.ReadOnly = True
        ' gridStock.DataSource = BindingSource1
        ' gridTrans.DataSource = BindingSource2
        gridTrans.Columns.Item(0).Visible = True
        gridTrans.Columns.Item(0).HeaderText = "Stock Code"
        gridTrans.Columns.Item(1).Visible = True
        gridTrans.Columns.Item(2).Visible = False
        gridTrans.Columns.Item(1).HeaderText = "Reference"
        gridTrans.Columns.Item(3).Visible = True
        gridTrans.Columns.Item(4).Visible = True
        gridTrans.Columns.Item(1).HeaderText = "Supplier Ref"
        gridTrans.Columns.Item(5).Visible = True
        gridTrans.Columns.Item(4).HeaderText = "Qty"
        gridTrans.Columns.Item(6).Visible = True
        gridTrans.Columns.Item(5).HeaderText = "Movement Type"
        ' gridTrans.Columns.Item(7).Visible = True
        gridTrans.Columns.Item(6).HeaderText = "Value"
        ' gridTrans.Columns.Item(7).HeaderText = "Date"

        gridStock.Columns.Item(0).Visible = True
        gridStock.Columns.Item(1).Visible = True
        gridStock.Columns.Item(2).Visible = True
        gridStock.Columns.Item(0).HeaderText = "Supplier Ref"
        gridStock.Columns.Item(3).Visible = True
        gridStock.Columns.Item(4).Visible = True
        ' gridStock.Columns.Item(5).Visible = False
        ' gridStock.Columns.Item(6).Visible = False
        ' gridStock.Columns.Item(7).Visible = True
        gridStock.Columns.Item(1).HeaderText = "Stock Code"


    End Sub
    Private Sub LoadNew()
        Me.Text = "New Warehouse Entry"
        Button1.Text = "Add"
        Button2.Text = "Cancel"
        Button3.Text = "Clear"
    End Sub
    Private Sub LoadDelete()
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        TextBox1.Text = Form1.DataGridView1.Item(1, i).Value
        cmd.Connection = connection
        cmd.Connection.Open()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM tblWarehouses WHERE WarehouseRef='" & TextBox1.Text & "'"
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        Form1.StockToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
End Class