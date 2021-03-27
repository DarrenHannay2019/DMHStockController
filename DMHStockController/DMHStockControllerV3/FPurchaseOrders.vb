Imports System.Data.SqlClient
Public Class FPurchaseOrders
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    ' Create a DataSet
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim duplicateCommand As New SqlCommand
    Dim selectcommand As New SqlCommand
    Dim strShop As String
    Dim strStock As String
    Dim strWarehouse As String
    Dim strStockCode As String
    'GET LAST SATURDAY
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    'GET LAST SUNDAY
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FPurchaseOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox2.Visible = False
        If Form1.txtMode.Text = "OLD" Then loadold()
        If Form1.txtMode.Text = "NEW" Then loadNew()
        If Form1.txtMode.Text = "DELETE" Then deleterecord()
    End Sub

    Private Sub cmdFindSupplier_Click(sender As Object, e As EventArgs) Handles cmdFindSupplier.Click

    End Sub

    Private Sub cmdFindWarehouse_Click(sender As Object, e As EventArgs) Handles cmdFindWarehouse.Click
        If CheckBox1.Checked = True Then FindShops()
        If CheckBox1.Checked = False Then findwarehouse()
    End Sub

    Private Sub cmdFindStockCode_Click(sender As Object, e As EventArgs) Handles cmdFindStockCode.Click

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If Label18.Text = "Shop Ref:" Then CreateShopDelivery()
        If Label18.Text = "Warehouse Ref:" Then CreateDelivery()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub txtCommission_Leave(sender As Object, e As EventArgs) Handles txtCommission.Leave
        Dim decCost As Decimal
        Dim qty As Decimal
        Dim override As Decimal
        Dim purchase As Decimal

        'calculate the purchase

        ' Note: i changed the "CDec" to "decimal.Parse"

        decCost = Decimal.Parse(txtNetCost.Text)
        override = Decimal.Parse(txtCommission.Text)
        qty = Decimal.Parse(txtDelCharges.Text)

        purchase = override + qty + decCost

        txtTotal.Text = purchase.ToString()




        Dim intnum1 As Double
        Dim intnum2 As Double
        Dim intnum3 As Double
        intnum1 = Double.Parse(txtNetCost.Text)

        intnum2 = Double.Parse(txtCommission.Text)
        intnum3 = Double.Parse(txtDelCharges.Text)
        txtTotal.Text = intnum1 + intnum2 + intnum3
    End Sub

    Private Sub txtNetCost_Leave(sender As Object, e As EventArgs) Handles txtNetCost.Leave
        txtTotalNet.Text = txtNetCost.Text
    End Sub

    Private Sub txtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave

    End Sub

    Private Sub txtTotalNet_Leave(sender As Object, e As EventArgs) Handles txtTotalNet.Leave
        Dim intnum1 As Decimal
        Dim intnum2 As Decimal
        Dim intnum3 As Decimal
        intnum1 = Decimal.Parse(txtNetCost.Text)
        intnum2 = Decimal.Parse(txtCommission.Text)
        intnum3 = Decimal.Parse(txtDelCharges.Text)
        txtTotal.Text = intnum1 + intnum2 + intnum3
    End Sub

    Private Sub txtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles txtWarehouseRef.Leave
        If Label18.Text = "Shop Ref:" Then findshops()
        If Label18.Text = "Warehouse Ref:" Then findwarehouse()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then Label18.Text = "Shop Ref:" : Label20.Text = "Shop Name:" : CheckBox2.Visible = True
        If CheckBox1.Checked = False Then Label18.Text = "Warehouse Ref:" : Label20.Text = "Warehouse Name:" : CheckBox2.Visible = False
    End Sub

    Private Sub findshops()
        Dim shoptype As String
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select ShopName From tblShops Where ShopRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtWarehouseName.Text = selectcommand.ExecuteScalar
        selectcommand.CommandText = "Select ShopType From tblShops Where ShopRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        shoptype = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
        If shoptype = "Shop" Then CheckBox2.Checked = False
        If shoptype <> "Shop" Then CheckBox2.Checked = True
    End Sub
    Private Sub findwarehouse()
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select WarehouseName From tblWarehouses Where ShopRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtWarehouseName.Text = selectcommand.ExecuteNonQuery
        selectcommand.Connection.Close()
    End Sub
    Private Sub loadold()
        Dim i As Integer
        Label18.Text = "Location Ref:"
        Label20.Text = "Location Name:"
        i = Form1.DataGridView1.CurrentRow.Index
        txtOrderID.Text = Form1.DataGridView1.Item(0, i).Value
        txtOurRef.Text = Form1.DataGridView1.Item(1, i).Value
        txtSupplierRef.Text = Form1.DataGridView1.Item(2, i).Value
        txtSupplierName.Text = Form1.DataGridView1.Item(3, i).Value
        txtWarehouseRef.Text = Form1.DataGridView1.Item(4, i).Value
        txtWarehouseName.Text = Form1.DataGridView1.Item(5, i).Value
        txtStockCode.Text = Form1.DataGridView1.Item(6, i).Value
        txtTotalGarments.Text = Form1.DataGridView1.Item(7, i).Value
        txtTotalNet.Text = Form1.DataGridView1.Item(8, i).Value
        DateTimePicker1.Value = Form1.DataGridView1.Item(15, i).Value
        txtTotal.Text = Form1.DataGridView1.Item(11, i).Value
        txtCommission.Text = Form1.DataGridView1.Item(10, i).Value
        txtDelCharges.Text = Form1.DataGridView1.Item(9, i).Value
        txtShipper.Text = Form1.DataGridView1.Item(13, i).Value
        txtShipperInv.Text = Form1.DataGridView1.Item(14, i).Value
        txtSupplierInv.Text = Form1.DataGridView1.Item(12, i).Value
        txtNetCost.Text = txtTotalNet.Text
        txtNetCost.Text = FormatCurrency(txtNetCost.Text)
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        txtQtyGarments.Text = txtTotalGarments.Text
        txtCommission.Text = FormatCurrency(txtCommission.Text)
        txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
        txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
    End Sub
    Private Sub loadNew()

    End Sub
    Private Sub deleterecord()
        Dim i As Integer
        i = Form1.DataGridView1.CurrentRow.Index
        txtOrderID.Text = Form1.DataGridView1.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblDeliveries WHERE DeliveriesID='" & txtOrderID.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblStockmovements WHERE TransferReference='" & txtOrderID.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        ' Form1.PurchaseOrdersToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Private Sub CreateStock()

        ' Dim a As Integer
        'Dim b As Integer
        '  Dim c As Integer
        Try
            Dim insertdb As String = " INSERT INTO tblStock (StockCode,SupplierRef,DeadCode,DeliveredQtyHangers,AmountTaken,CostValue,PCMarkUp,ZeroQty,CreatedBy,CreatedDate) VALUES (@StockCode,@SupplierRef,@DeadCode,@DeliveredQtyHangers,@AmountTaken,@CostValue,@PCMarkUp,@ZeroQty,@CreatedBy,@CreatedDate)"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            com.Connection.Open()
            com.Parameters.AddWithValue("@ZeroQty", "0")
            com.Parameters.AddWithValue("@StockCode", txtStockCode.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", "0")
            com.Parameters.AddWithValue("@AmountTaken", "0.00")
            com.Parameters.AddWithValue("@CostValue", txtTotalNet.Text)
            com.Parameters.AddWithValue("@PCMarkUp", "0")
            com.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
            com.Parameters.AddWithValue("@CreatedDate", Date.Now)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", txtTotalGarments.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            Form1.StockToolStripMenuItem.PerformClick()
            MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try

    End Sub
    Private Sub CreateShopDelivery()
        AddRecord()
        Try
            ' Create record for the Delviery
            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertDeliveries"
            ' Create a DataSet
            Me.Validate()
            InsertCommand.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@WarehouseRef", "")
            InsertCommand.Parameters.AddWithValue("@WarehouseName", "")
            InsertCommand.Parameters.AddWithValue("@ShopRef", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@ShopName", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@NetAmount", txtTotalNet.Text)
            InsertCommand.Parameters.AddWithValue("@Commission", txtCommission.Text)
            InsertCommand.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            InsertCommand.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            InsertCommand.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
            InsertCommand.ExecuteNonQuery()
            InsertCommand.CommandText = "Select @@Identity"
            txtOrderID.Text = InsertCommand.ExecuteScalar()
            InsertCommand.Connection.Close()
            ' Create record in the Stock Movements Table.
            InsertCommand.Connection = connection
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = " InsertStockMovements"
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseRef.Text)
            If CheckBox2.Checked = True Then InsertCommand.Parameters.AddWithValue("@LocationType", "Consession")
            If CheckBox2.Checked = False Then InsertCommand.Parameters.AddWithValue("@LocationType", "Shop")
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
            ' Form1.PurchaseOrdersToolStripMenuItem.PerformClick()
            MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub
    Private Sub CreateDelivery()
        AddRecord()
        Try
            ' Create record for the Delviery
            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertDeliveries"
            ' Create a DataSet
            Me.Validate()
            InsertCommand.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@WarehouseRef", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@WarehouseName", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@ShopRef", "")
            InsertCommand.Parameters.AddWithValue("@ShopName", "")
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@NetAmount", txtTotalNet.Text)
            InsertCommand.Parameters.AddWithValue("@Commission", txtCommission.Text)
            InsertCommand.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            InsertCommand.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            InsertCommand.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Now)
            InsertCommand.ExecuteNonQuery()
            InsertCommand.CommandText = "Select @@Identity"
            txtOrderID.Text = InsertCommand.ExecuteScalar()
            InsertCommand.Connection.Close()
            ' Create record in the Stock Movements Table.
            InsertCommand.Connection = connection
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = " InsertStockMovements"
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@Location", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@LocationType", "Warehouse")
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
            ' Form1.PurchaseOrdersToolStripMenuItem.PerformClick()
            MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub
    Private Sub AddRecord()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStock WHERE StockCode = '" + txtStockCode.Text.ToString() + "'"
            queryResult = duplicateCommand.ExecuteNonQuery()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then MessageBox.Show("Stock Record : [" + txtStockCode.Text + "] Already Exists in the database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Information) : CreateDelivery()
            If queryResult = 0 Then CreateStock()
        Catch ex As Exception
            MessageBox.Show("Error in database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

End Class