Imports System.Data.SqlClient

Public Class FShopsEntry
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Private Sub FShopsEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then loadnew()
        If FMain.txtMode.Text = "DELETE" Then deleteRecord()
        If FMain.txtMode.Text = "OLD" Then LoadOld()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "OK" Then updateRecord()
        If Button1.Text = "Add" Then SaveRecord()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearscreen()
    End Sub

    Private Sub chkShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowAll.CheckedChanged
        If chkShowAll.CheckState = CheckState.Checked Then
            gridStock.DataSource = "Select * From qryShopStockDisplay Where Location = @ShopRef and QtyHangers <> 0 Order By StockCode"
            gridStock.Refresh()
        Else
            gridStock.DataSource = "Select * From qryShopStockDisplay Where  Location = @ShopRef Order By StockCode"
            gridStock.Refresh()
        End If
    End Sub
    Private Sub LoadOld()
        Button1.Text = "OK"
        Button2.Text = "Cancel"
        Button3.Visible = False
        TextBox1.Enabled = False
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        TextBox1.Text = FMain.DgvRecords.Item(0, i).Value
        TextBox2.Text = FMain.DgvRecords.Item(1, i).Value
        TextBox3.Text = FMain.DgvRecords.Item(2, i).Value
        TextBox4.Text = FMain.DgvRecords.Item(3, i).Value
        TextBox5.Text = FMain.DgvRecords.Item(4, i).Value
        TextBox6.Text = FMain.DgvRecords.Item(5, i).Value
        TextBox7.Text = FMain.DgvRecords.Item(6, i).Value
        TextBox8.Text = FMain.DgvRecords.Item(8, i).Value
        TextBox9.Text = FMain.DgvRecords.Item(9, i).Value
        TextBox10.Text = FMain.DgvRecords.Item(10, i).Value
        TextBox11.Text = FMain.DgvRecords.Item(11, i).Value
        TextBox12.Text = FMain.DgvRecords.Item(12, i).Value
        cboWType.Text = FMain.DgvRecords.Item(13, i).Value
        TextBox13.Text = FMain.DgvRecords.Item(14, i).Value
        Dim viewtrans As String = "SELECT * from tblStockMovements where SMLocation='" & TextBox1.Text & "' And SMLocationType='Shop' Order By MovementDate"
        Dim Viewstock As String = "SELECT * from qryShopStockDisplay where SMlocation='" & TextBox1.Text & "' AND QtyHangers > '0' Order By SMStockCode"
        Dim getstock As New SqlDataAdapter(Viewstock, connection)
        Dim gettrans As New SqlDataAdapter(viewtrans, connection)
        Dim ads As New DataSet()
        Dim bds As New DataSet()
        connection.Open()
        getstock.Fill(ads, "qryShopStockDisplay")
        gettrans.Fill(bds, "tblStockMovements")
        connection.Close()
        gridStock.DataSource = ads
        gridStock.DataMember = "qryShopStockDisplay"
        gridTrans.DataSource = bds
        gridTrans.DataMember = "tblStockMovements"
        gridTrans.Refresh()
        gridStock.Refresh()
        gridTrans.Columns.Item(0).Visible = False
        gridTrans.Columns.Item(1).Visible = True
        gridTrans.Columns.Item(2).Visible = False
        gridTrans.Columns.Item(1).HeaderText = "Stk. Code"
        gridTrans.Columns.Item(2).HeaderText = "Supplier Ref"
        gridTrans.Columns.Item(2).Width = "70"
        gridTrans.Columns.Item(4).Width = "70"
        gridTrans.Columns.Item(5).Width = "80"
        gridTrans.Columns.Item(6).Width = "50"
        gridTrans.Columns.Item(7).Width = "70"
        gridTrans.Columns.Item(9).Width = "70"

        gridTrans.Columns.Item(3).Visible = False
        gridTrans.Columns.Item(4).Visible = False
        gridTrans.Columns.Item(5).HeaderText = "Type"
        gridTrans.Columns.Item(5).Visible = True
        gridTrans.Columns.Item(6).HeaderText = "Qty"
        gridTrans.Columns.Item(6).Visible = True
        gridTrans.Columns.Item(7).HeaderText = "Date"
        gridTrans.Columns.Item(8).Visible = False
        gridTrans.Columns.Item(9).HeaderText = "Reference"
        gridTrans.Columns.Item(10).Visible = False
        gridTrans.Columns.Item(11).Visible = False
        gridTrans.Columns.Item(12).Visible = False
        gridStock.Columns.Item(0).Visible = False
        gridStock.Columns.Item(1).Visible = False
        gridStock.Columns.Item(2).Visible = True
        gridStock.Columns.Item(2).HeaderText = "Supplier"
        gridStock.Columns.Item(3).Visible = True
        gridStock.Columns.Item(4).Visible = True
        gridStock.Columns.Item(3).HeaderText = "Stock Code"
        gridStock.Columns.Item(5).Visible = True
        gridStock.Columns.Item(4).HeaderText = "Quantity"
        gridStock.Columns.Item(6).Visible = False
        gridStock.Columns.Item(5).HeaderText = "Value"
        gridStock.Columns.Item(5).DefaultCellStyle.Format = "c"
        Me.Text = "Shop [ " & TextBox1.Text & " ] " & TextBox2.Text
        Dim total As Integer
        Dim total2 As Decimal
        For x As Integer = 0 To gridStock.RowCount - 1
            total += gridStock.Rows(x).Cells(4).Value
        Next
        Label14.Text = total
        For t As Integer = 0 To gridStock.RowCount - 1
            total2 += gridStock.Rows(t).Cells(5).Value
        Next
        Label15.Text = total2
        Dim curNetTotal As Decimal
        curNetTotal = 0
        Label15.Text = FormatCurrency(Label15.Text)
    End Sub
    Private Sub loadnew()
        Button1.Text = "Add"
        Button2.Text = "Cancel"
        Button3.Text = "Clear"
        Me.Text = "New Shop Entry"
    End Sub
    Private Sub SaveRecord()
        Try
            Dim queryResult As Integer
            DuplicateCommand.Connection = connection
            DuplicateCommand.Connection.Open()
            DuplicateCommand.CommandType = CommandType.Text
            DuplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblShops WHERE ShopRef = '" + TextBox1.Text + "' AND ShopName = '" + TextBox2.Text + "'"
            queryResult = DuplicateCommand.ExecuteNonQuery()
            DuplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Shop Record :" + TextBox1.Text + "[" + TextBox2.Text + "] Already Exists in the database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        InsertCommand.Connection = connection
        InsertCommand.Connection.Open()
        InsertCommand.CommandText = "INSERT INTO tblShops (ShopRef,ShopName,ContactName,Street,Area,Town,County,Country,PostCode,Telephone,Telephone2,Fax,eMail,ShopType,Memo,CreatedBy,CreatedDate) VALUES (@ShopRef,@ShopName,@ContactName,@Street,@Area,@Town,@County,@Country,@PostCode,@Telephone,@Telephone2,@Fax,@eMail,@ShopType,@Memo,@CreatedBy,@CreatedDate)"
        InsertCommand.CommandType = CommandType.Text
        InsertCommand.Parameters.AddWithValue("@ShopRef", TextBox1.Text)
        InsertCommand.Parameters.AddWithValue("@ShopName", TextBox2.Text)
        InsertCommand.Parameters.AddWithValue("@ContactName", TextBox3.Text)
        InsertCommand.Parameters.AddWithValue("@Street", TextBox4.Text)
        InsertCommand.Parameters.AddWithValue("@Area", TextBox5.Text)
        InsertCommand.Parameters.AddWithValue("@Town", TextBox6.Text)
        InsertCommand.Parameters.AddWithValue("@County", TextBox7.Text)
        InsertCommand.Parameters.AddWithValue("@Country", "UK")
        InsertCommand.Parameters.AddWithValue("@PostCode", TextBox8.Text)
        InsertCommand.Parameters.AddWithValue("@Telephone", TextBox9.Text)
        InsertCommand.Parameters.AddWithValue("@Telephone2", TextBox10.Text)
        InsertCommand.Parameters.AddWithValue("@Fax", TextBox11.Text)
        InsertCommand.Parameters.AddWithValue("@eMail", TextBox12.Text)
        InsertCommand.Parameters.AddWithValue("@ShopType", cboWType.Text)
        InsertCommand.Parameters.AddWithValue("@Memo", TextBox13.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now())
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
        FMain.ShopsToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub deleteRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        TextBox1.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblShops WHERE ShopRef='" & TextBox1.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.ShopsToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub updateRecord()
        UpdateCommand.Connection = connection
        UpdateCommand.Connection.Open()
        UpdateCommand.CommandText = "UPDATE tblShops SET ShopRef = @ShopRef,ShopName = @ShopName,ContactName = @ContactName,Street = @Street,Area = @Area,Town = @Town,County = @County,PostCode = @PostCode,Telephone = @Telephone,Telephone2 = @Telephone2,Fax = @Fax,eMail = @eMail,Memo = @Memo, ShopType = @ShopType WHERE ShopRef = @ShopRef"
        UpdateCommand.CommandType = CommandType.Text
        UpdateCommand.Parameters.AddWithValue("@ShopRef", TextBox1.Text)
        UpdateCommand.Parameters.AddWithValue("@ShopName", TextBox2.Text)
        UpdateCommand.Parameters.AddWithValue("@ContactName", TextBox3.Text)
        UpdateCommand.Parameters.AddWithValue("@Street", TextBox4.Text)
        UpdateCommand.Parameters.AddWithValue("@Area", TextBox5.Text)
        UpdateCommand.Parameters.AddWithValue("@Town", TextBox6.Text)
        UpdateCommand.Parameters.AddWithValue("@County", TextBox7.Text)
        UpdateCommand.Parameters.AddWithValue("@PostCode", TextBox8.Text)
        UpdateCommand.Parameters.AddWithValue("@Telephone", TextBox9.Text)
        UpdateCommand.Parameters.AddWithValue("@Telephone2", TextBox10.Text)
        UpdateCommand.Parameters.AddWithValue("@Fax", TextBox11.Text)
        UpdateCommand.Parameters.AddWithValue("@eMail", TextBox12.Text)
        UpdateCommand.Parameters.AddWithValue("@Memo", TextBox13.Text)
        UpdateCommand.Parameters.AddWithValue("@ShopType", cboWType.Text.ToString())
        UpdateCommand.ExecuteNonQuery()
        UpdateCommand.Connection.Close()
        FMain.ShopsToolStripMenuItem.PerformClick()
        Me.Close()
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
End Class