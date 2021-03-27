Imports System.Data.SqlClient
Public Class FDeliveriesIn
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=.\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;"
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
    Dim dLastSaturday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 1))
    'GET LAST SUNDAY
    Dim dLastSunday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FDeliveriesIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = dLastSunday
        CheckBox2.Visible = False
        txtBoxes.Text = "0"
        txtHangers.Text = "0"
        txtWarehouseRef.Text = "Uni"
        txtWarehouseName.Text = "Universal Warehouse"
        If FMain.txtMode.Text = "OLD" Then loadOld()
        If FMain.txtMode.Text = "NEW" Then LoadNew()
        If FMain.txtMode.Text = "DELETE" Then DeleteRecord()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        '    If CheckBox1.Checked = True Then CreateShopDelivery()
        '   If CheckBox1.Checked = False Then CreateDelivery()
        If txtStockCode.Text = "" Then MsgBox("Please enter a stock code!", vbExclamation, Application.ProductName)
        If txtSupplierRef.Text = "" Then MsgBox("Please enter a supplier ref!", vbExclamation, Application.ProductName)
        If txtNetCost.Text = "" Then MsgBox("please enter a Money Value!", vbExclamation, ProductName)
        If txtStockCode.Text <> "" And txtSupplierRef.Text <> "" And txtNetCost.Text <> "" And cmdOK.Text = "Add" Then CreateDelivery() : Me.Close()
        If cmdOK.Text = "OK" Then updaterecord() : Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdFindSupplier_Click(sender As Object, e As EventArgs) Handles cmdFindSupplier.Click
        selectcommand.Connection = connection
        selectcommand.CommandText = "Select SupplierName From tblSuppliers Where SupplierRef = '" & txtSupplierRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtSupplierName.Text = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
    End Sub

    Private Sub cmdFindWarehouse_Click(sender As Object, e As EventArgs) Handles cmdFindWarehouse.Click
        If CheckBox1.Checked = True Then findshops()
        If CheckBox1.Checked = False Then findwarehouse()
        Me.Text = "Delivery For: [" + txtWarehouseRef.Text + "] " + txtWarehouseName.Text
    End Sub

    Private Sub cmdFindStockCode_Click(sender As Object, e As EventArgs) Handles cmdFindStockCode.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then Label18.Text = "Shop Ref:" : Label20.Text = "Shop Name:" : CheckBox2.Visible = False : DateTimePicker1.Value = dLastSunday.AddDays(7) : txtWarehouseRef.Text = "" : txtWarehouseName.Text = ""
        If CheckBox1.Checked = False Then Label18.Text = "Warehouse Ref:" : Label20.Text = "Warehouse Name:" : CheckBox2.Visible = False : DateTimePicker1.Value = dLastSunday : txtWarehouseRef.Text = "Universal" : txtWarehouseName.Text = "Universal Warehouse"
    End Sub

    Private Sub txtNetCost_Leave(sender As Object, e As EventArgs) Handles txtNetCost.Leave
        If txtNetCost.Text = "" Then MsgBox("please enter a Money Value", vbExclamation + vbOKOnly, ProductName)
        txtNetCost.Text = FormatCurrency(txtNetCost.Text)
        txtTotalNet.Text = FormatCurrency(txtNetCost.Text)
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        CalculateTotals()
    End Sub

    Private Sub txtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        If txtStockCode.Text = "" Then MsgBox("Please Enter a Stock Code", vbExclamation + vbOKOnly, ProductName)
        txtOurRef.Text = txtStockCode.Text
    End Sub

    Private Sub txtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles txtWarehouseRef.Leave
        cmdFindWarehouse.PerformClick()
    End Sub

    Private Sub txtSupplierRef_Leave(sender As Object, e As EventArgs) Handles txtSupplierRef.Leave
        cmdFindSupplier.PerformClick()
    End Sub

    Private Sub txtDelCharges_Leave(sender As Object, e As EventArgs) Handles txtDelCharges.Leave
        txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
        CalculateTotals()
    End Sub

    Private Sub txtCommission_Leave(sender As Object, e As EventArgs) Handles txtCommission.Leave
        txtCommission.Text = FormatCurrency(txtCommission.Text)
        CalculateTotals()
    End Sub

    Private Sub txtQtyGarments_Leave(sender As Object, e As EventArgs) Handles txtQtyGarments.Leave
        If txtQtyGarments.Text = "" Then MsgBox("Please enter a quantity to be delivered!", vbExclamation + vbOKOnly, ProductName)
        '  txtTotalGarments.Text = txtQtyGarments.Text
        GarmentsTotal()
    End Sub

    Private Sub loadOld()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtOrderID.Text = FMain.DgvRecords.Item(0, i).Value
        txtOurRef.Text = FMain.DgvRecords.Item(1, i).Value
        txtSupplierRef.Text = FMain.DgvRecords.Item(2, i).Value
        txtSupplierName.Text = FMain.DgvRecords.Item(3, i).Value
        txtWarehouseRef.Text = FMain.DgvRecords.Item(4, i).Value
        txtWarehouseName.Text = FMain.DgvRecords.Item(5, i).Value
        txtStockCode.Text = FMain.DgvRecords.Item(6, i).Value
        txtQtyGarments.Text = FMain.DgvRecords.Item(7, i).Value
        txtTotalGarments.Text = FMain.DgvRecords.Item(7, i).Value
        txtNetCost.Text = FMain.DgvRecords.Item(8, i).Value
        txtTotalNet.Text = FMain.DgvRecords.Item(8, i).Value
        txtDelCharges.Text = FMain.DgvRecords.Item(9, i).Value
        txtCommission.Text = FMain.DgvRecords.Item(10, i).Value
        txtTotal.Text = FMain.DgvRecords.Item(11, i).Value
        txtSupplierInv.Text = FMain.DgvRecords.Item(12, i).Value
        txtShipper.Text = FMain.DgvRecords.Item(13, i).Value
        txtShipperInv.Text = FMain.DgvRecords.Item(14, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(15, i).Value
        CheckBox1.Visible = False
        CheckBox2.Visible = False
        txtNetCost.Text = FormatCurrency(txtNetCost.Text)
        txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
        txtCommission.Text = FormatCurrency(txtCommission.Text)
        txtTotal.Text = FormatCurrency(txtTotal.Text)
        txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
        Label18.Text = "Location Ref:"
        Label20.Text = "Location Name:"
        cmdOK.Text = "OK"
    End Sub
    Private Sub LoadNew()
        DateTimePicker1.Value = dLastSunday
        cmdOK.Text = "Add"
    End Sub
    Private Sub DeleteRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtOrderID.Text = FMain.DgvRecords.Item(0, i).Value
        txtStockCode.Text = FMain.DgvRecords.Item(6, i).Value
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
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE FROM tblStock WHERE StockCode='" & txtStockCode.Text & "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()

        FMain.PurchaseOrdersToolStripMenuItem.PerformClick()
        Me.Close()
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
        selectcommand.CommandText = "Select WarehouseName From tblWarehouses Where WarehouseRef = '" & txtWarehouseRef.Text & "'"
        selectcommand.CommandType = CommandType.Text
        selectcommand.Connection.Open()
        txtWarehouseName.Text = selectcommand.ExecuteScalar
        selectcommand.Connection.Close()
    End Sub
    Private Sub CalculateTotals()
        Dim curNetTotal As Decimal
        curNetTotal = 0
        txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
        txtTotal.Text = FormatCurrency(CDec(txtTotalNet.Text) + CDec(txtCommission.Text) + CDec(txtDelCharges.Text))

    End Sub
    Private Sub GarmentsTotal()
        txtTotalGarments.Text = (CInt(txtHangers.Text) + CInt(txtQtyGarments.Text) + CInt(txtBoxes.Text))
    End Sub
    Private Sub AddRecord()
        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStock WHERE StockCode = '" + txtStockCode.Text.ToString() + "'"
            queryResult = duplicateCommand.ExecuteScalar()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then MessageBox.Show("Stock Record : [" + txtStockCode.Text + "] Already Exists in the database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) : txtStockCode.SelectAll() : Exit Sub
            If queryResult = 0 Then CreateStock()
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub CreateStock()
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
            com.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            com.Parameters.AddWithValue("@CreatedDate", Date.Now)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", txtTotalGarments.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            FMain.StockToolStripMenuItem.PerformClick()
            MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub
    Private Sub CreateShopDelivery()
        AddRecord()
        Try
            Dim id As Integer
            ' Create record for the Delviery
            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertDeliveries"
            ' Create a DataSet
            Me.Validate()
            InsertCommand.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            InsertCommand.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@NetAmount", txtTotalNet.Text)
            InsertCommand.Parameters.AddWithValue("@Commission", txtCommission.Text)
            InsertCommand.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            InsertCommand.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            InsertCommand.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Now)
            InsertCommand.Parameters.Add("@DeliveriesId", SqlDbType.Int, 0, "DeliveriesId")
            InsertCommand.Parameters("@DeliveriesId").Direction = ParameterDirection.Output
            InsertCommand.ExecuteNonQuery()
            id = InsertCommand.Parameters("@DeliveriesId").Value
            ' Dim newID As Integer = CInt(InsertCommand.ExecuteScalar())
            txtOrderID.Text = id
            ' Create record in the Stock Movements Table.
            InsertCommand.Connection = connection
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertStockMovements"
            InsertCommand.Connection.Close()
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
            If CheckBox2.Checked = True Then InsertCommand.Parameters.AddWithValue("@LocationType", "Consession")
            If CheckBox2.Checked = False Then InsertCommand.Parameters.AddWithValue("@LocationType", "Shop")
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            ' FMain.PurchaseOrdersToolStripMenuItem.PerformClick()
            MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub
    Private Sub CreateDelivery()

        AddRecord()
        Try
            Dim id As Integer
            ' Create record for the Delviery
            InsertCommand.Connection = connection
            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.StoredProcedure
            InsertCommand.CommandText = "InsertDeliveries"
            ' Create a DataSet
            Me.Validate()
            InsertCommand.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            InsertCommand.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@NetAmount", txtTotalNet.Text)
            InsertCommand.Parameters.AddWithValue("@Commission", txtCommission.Text)
            InsertCommand.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            InsertCommand.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            InsertCommand.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            InsertCommand.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@CreatedDate", Now)
            InsertCommand.Parameters.Add("@DeliveriesId", SqlDbType.Int, 0, "DeliveriesId")
            InsertCommand.Parameters("@DeliveriesId").Direction = ParameterDirection.Output
            InsertCommand.ExecuteNonQuery()
            id = InsertCommand.Parameters("@DeliveriesId").Value
            ' Dim newID As Integer = CInt(InsertCommand.ExecuteScalar())
            txtOrderID.Text = id
            InsertCommand.Connection.Close()
            ' Create record in the Stock Movements Table.
            InsertCommand.Connection = connection
            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES (@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            InsertCommand.Connection.Open()
            InsertCommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
            If CheckBox1.Checked = True Then InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop")
            'If CheckBox1.Checked = True And CheckBox2.Checked = True Then InsertCommand.Parameters.AddWithValue("@SMLocationType", "Consession")
            If CheckBox1.Checked = False Then InsertCommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
            If CheckBox1.Checked = True Then InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            If CheckBox1.Checked = False Then InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (W)")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtTotalGarments.Text)
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            InsertCommand.Parameters.AddWithValue("@Reference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            InsertCommand.ExecuteNonQuery()
            FMain.PurchaseOrdersToolStripMenuItem.PerformClick()
            InsertCommand.Connection.Close()
            ' MsgBox("Record Created Successfully", MsgBoxStyle.Information, "Stock Master v2")
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub

    Private Sub updaterecord()

        Try
            Dim updatedb As String = " UPDATE tblStock SET SupplierRef = @SupplierRef,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers, CostValue = @CostValue WHERE StockCode = '" + txtStockCode.Text + "';"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(updatedb, connection)
            com.Connection.Open()
            '  com.Parameters.AddWithValue("@StockCode", txtStockCode.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text.ToString)
            ' com.Parameters.AddWithValue("@Season", SeasonComboBox.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", "0")
            'com.Parameters.AddWithValue("@RemoveFromClearance", RemoveFromClearanceCheckBox.CheckState)
            'com.Parameters.AddWithValue("@AmountTaken", "0.00")
            com.Parameters.AddWithValue("@CostValue", txtTotalNet.Text)
            ' com.Parameters.AddWithValue("@PCMarkUp", "0")
            'com.Parameters.AddWithValue("@ZeroQty", "0")
            ' com.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", txtTotalGarments.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            Dim updatedb2 As String = " UPDATE tblStockMovements SET SMStockCode = @SMStockCode,SMSupplierRef = @SMSupplierRef, MovementQtyHangers = @MovementQtyHangers, MovementDate = @MovementDate,MovementValue = @MovementValue WHERE TransferReference = @TransferReference;"
            Dim updatedb3 As String = " UPDATE tblDeliveries SET OurRef = @OurRef, SupplierRef = @SupplierRef,SupplierName = @SupplierName,LocationRef = @LocationRef,LocationName = @LocationName , StockCode = @StockCode, TotalItems = @TotalItems, NetAmount = @NetAmount, DeliveryCharge = @DeliveryCharge, Commission = @Commission, TotalAmount = @TotalAmount, InvoiceNo = @InvoiceNo, Shipper = @Shipper, ShipperInvoice = @ShipperInvoice, DeliveryDate = @DeliveryDate WHERE DeliveriesID = '" + txtOrderID.Text + "';"
            Dim update1 As New SqlCommand(updatedb2, connection)
            Dim update2 As New SqlCommand(updatedb3, connection)
            update2.Connection.Open()
            update2.Parameters.AddWithValue("@OurRef", txtOurRef.Text)
            update2.Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text)
            update2.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text)
            update2.Parameters.AddWithValue("@LocationRef", txtWarehouseRef.Text)
            update2.Parameters.AddWithValue("@LocationName", txtWarehouseName.Text)
            update2.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            update2.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text)
            update2.Parameters.AddWithValue("@NetAmount", txtNetCost.Text)
            update2.Parameters.AddWithValue("@DeliveryCharge", txtDelCharges.Text)
            update2.Parameters.AddWithValue("@Commission", txtCommission.Text)
            update2.Parameters.AddWithValue("@TotalAmount", txtTotal.Text)
            update2.Parameters.AddWithValue("@InvoiceNo", txtSupplierInv.Text)
            update2.Parameters.AddWithValue("@Shipper", txtShipper.Text)
            update2.Parameters.AddWithValue("@ShipperInvoice", txtShipperInv.Text)
            update2.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
            update2.ExecuteNonQuery()
            update2.Connection.Close()
            update1.Connection.Open()
            update1.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
            update1.Parameters.AddWithValue("@SMSupplierRef", txtSupplierRef.Text)

            update1.Parameters.AddWithValue("@MovementQtyHangers", txtTotalGarments.Text)
            update1.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            update1.Parameters.AddWithValue("@MovementValue", txtTotal.Text)
            update1.Parameters.AddWithValue("@TransferReference", txtOrderID.Text)
            update1.ExecuteNonQuery()
            update1.Connection.Close()

            MsgBox("Update Successful", MsgBoxStyle.Information, ProductName)
        Catch ex As SqlException
            MsgBox("Update Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub





End Class