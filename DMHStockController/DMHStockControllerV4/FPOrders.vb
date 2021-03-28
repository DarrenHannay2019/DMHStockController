Imports System.Data.SqlClient
Public Class FPOrders
    Dim ut As New CUtils
    Dim del As New CCheck
    Dim save As New CSave
    Dim upd As New CUpdate
    Dim Ch As New CCheck
    Dim Syslog As New CSystemLog
    Dim st As New CStockMovements
    Dim stockCodeR As String
    Dim oldstockcode As String
    Dim olddate As DateTime
    Dim oldwref As String
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then Label18.Text = "Shop Ref:" : Label20.Text = "Shop Name:" : txtWarehouseRef.Text = "" : txtWarehouseName.Text = "" : txtWarehouseRef.Enabled = True : txtWarehouseName.Enabled = True : DateTimePicker1.Value = ut.GetNextSundaysDate(Now)
        If CheckBox1.Checked = False Then Label18.Text = "Warehouse Ref:" : Label20.Text = "Warehouse Name:" : DateTimePicker1.Value = ut.GetSundaysDate(Now) : txtWarehouseRef.Text = "UNI" : txtWarehouseName.Text = "Universal Warehouse" : txtWarehouseRef.Enabled = False : txtWarehouseName.Enabled = False
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If cmdOK.Text = "OK" Then
            If oldwref.TrimEnd() <> "UNI" Then
                st.DeleteStockMovements("Delivery (S)", CInt(txtOrderID.Text), txtStockCode.Text, CDate(olddate))
                st.DeleteStockMovements("Delivery (W)", CInt(txtOrderID.Text), txtStockCode.Text, CDate(olddate))
                If txtWarehouseRef.Text.TrimEnd() = "UNI" Then st.SaveStockMovements(txtStockCode.Text, txtSupplierRef.Text, txtWarehouseRef.Text, "Warehouse", CInt(txtTotalGarments.Text), 0, "Delivery (W)", CDate(DateTimePicker1.Value), CDec(txtNetCost.Text), txtOrderID.Text.TrimEnd(), CInt(txtOrderID.Text))
                If txtWarehouseRef.Text.TrimEnd() <> "UNI" Then st.SaveStockMovements(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, txtWarehouseRef.Text, "Shop", CInt(txtTotalGarments.Text), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(txtNetCost.Text), txtOrderID.Text.TrimEnd(), CInt(txtOrderID.Text))
            ElseIf oldwref.TrimEnd() = "UNI" Then
                st.DeleteStockMovements("Delivery (W)", CInt(txtOrderID.Text), txtStockCode.Text, CDate(olddate))
                st.DeleteStockMovements("Delivery (S)", CInt(txtOrderID.Text), txtStockCode.Text, CDate(olddate))
                If txtWarehouseRef.Text.TrimEnd() = "UNI" Then st.SaveStockMovements(txtStockCode.Text, txtSupplierRef.Text, txtWarehouseRef.Text, "Warehouse", CInt(txtTotalGarments.Text), 0, "Delivery (W)", CDate(DateTimePicker1.Value), CDec(txtNetCost.Text), txtOrderID.Text.TrimEnd(), CInt(txtOrderID.Text))
                If txtWarehouseRef.Text.TrimEnd() <> "UNI" Then st.SaveStockMovements(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, txtWarehouseRef.Text, "Shop", CInt(txtTotalGarments.Text), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(txtNetCost.Text), txtOrderID.Text.TrimEnd(), CInt(txtOrderID.Text))
            End If
            UpdateToDb()
        ElseIf cmdOK.Text = "ADD" And txtWarehouseRef.Text.TrimEnd = "UNI" Then
            SaveToDb()
        ElseIf cmdOK.Text = "ADD" And txtWarehouseRef.Text.TrimEnd <> "UNI" Then
            SaveToDB2()
        End If
        FGridPOrders.TsbRefresh.PerformClick()
        Close()
    End Sub
    Public Sub SaveToDB2()
        Syslog.SaveSystemLog(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, txtWarehouseRef.Text.TrimEnd, CInt(txtTotalGarments.Text.TrimEnd), "Purchase-Add", "Purchase-Orders", CDate(DateTimePicker1.Value), txtSupplierInv.Text)
        save.SavePOrders(txtSupplierRef.Text, txtSupplierName.Text, txtWarehouseRef.Text, txtWarehouseName.Text, txtStockCode.Text, CInt(txtTotalGarments.Text), CDec(txtNetCost.Text), CDec(txtCommission.Text), CDec(txtDelCharges.Text), CDec(txtTotalNet.Text), CDate(DateTimePicker1.Value), RichTextBox1.Text, txtSupplierInv.Text, txtShipper.Text, txtShipperInv.Text)
        txtOrderID.Text = Ch.SavePOrders()
        If stockCodeR = "New" Then save.SaveStock(txtStockCode.Text, txtSupplierRef.Text, CDec(txtTotal.Text), CInt(txtTotalGarments.Text))
        st.SaveStockMovements(txtStockCode.Text, txtSupplierRef.Text, txtWarehouseRef.Text, "Shop", CInt(txtTotalGarments.Text), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(txtNetCost.Text), txtStockCode.Text, CInt(txtOrderID.Text))
        save.SaveShopSalesLines(0, txtStockCode.Text, 0, 0, 0, 0)
        st.SaveStockMovements(txtStockCode.Text, txtSupplierRef.Text, "UNI", "Warehouse", 0, 0, "Delivery (W)", CDate(DateTimePicker1.Value), 0, txtStockCode.Text, CInt(txtOrderID.Text))
        FGridPOrders.TsbRefresh.PerformClick()
    End Sub
    Public Sub UpdateToDb()
        Syslog.SaveSystemLog(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, txtWarehouseRef.Text.TrimEnd, CInt(txtTotalGarments.Text.TrimEnd), "Purchase-Update", "Purchase-Orders", CDate(DateTimePicker1.Value), txtSupplierInv.Text)
        upd.SavePOrders(CInt(txtOrderID.Text), txtSupplierRef.Text, txtSupplierName.Text, txtWarehouseRef.Text, txtWarehouseName.Text, txtStockCode.Text, CInt(txtTotalGarments.Text), CDec(txtNetCost.Text), CDec(txtCommission.Text), CDec(txtDelCharges.Text), CDec(txtTotal.Text), CDate(DateTimePicker1.Value), RichTextBox1.Text, txtSupplierInv.Text, txtShipper.Text, txtShipperInv.Text)
        upd.SaveStock(txtStockCode.Text, txtSupplierRef.Text, "0", "0", CInt(txtTotalGarments.Text), CDec(txtTotal.Text), "0", "0", "ALL")
    End Sub
    Public Sub SaveToDb()
        Syslog.SaveSystemLog(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, txtWarehouseRef.Text.TrimEnd, CInt(txtTotalGarments.Text.TrimEnd), "Purchase-Add", "Purchase-Orders", CDate(DateTimePicker1.Value), txtSupplierInv.Text)
        save.SavePOrders(txtSupplierRef.Text, txtSupplierName.Text, txtWarehouseRef.Text, txtWarehouseName.Text, txtStockCode.Text, CInt(txtTotalGarments.Text), CDec(txtNetCost.Text), CDec(txtCommission.Text), CDec(txtDelCharges.Text), CDec(txtTotal.Text), CDate(DateTimePicker1.Value), RichTextBox1.Text, txtSupplierInv.Text, txtShipper.Text, txtShipperInv.Text)
        txtOrderID.Text = Ch.SavePOrders()
        If stockCodeR = "New" Then save.SaveStock(txtStockCode.Text.TrimEnd(), txtSupplierRef.Text, CDec(txtTotal.Text), CInt(txtTotalGarments.Text))
        st.SaveStockMovements(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, txtWarehouseRef.Text.TrimEnd, "Warehouse", CInt(txtTotalGarments.Text), 0, "Delivery (W)", CDate(DateTimePicker1.Value), CDec(txtNetCost.Text), txtStockCode.Text, CInt(txtOrderID.Text))
        save.SaveShopSalesLines(0, txtStockCode.Text.TrimEnd, 0, 0, 0, 0)
        st.SaveStockMovements(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, "DU", "Shop", 0, 0, "Delivery (S)", CDate(DateTimePicker1.Value), 0, txtStockCode.Text, CInt(txtOrderID.Text))
        FGridPOrders.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then FGridPOrders.TsbRefresh.PerformClick() : Me.Close()
    End Sub

    Private Sub TxtSupplierRef_Leave(sender As Object, e As EventArgs) Handles txtSupplierRef.Leave
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .CommandText = "SELECT SupplierName from tblSuppliers WHERE SupplierRef = @SupplierRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@SupplierRef", txtSupplierRef.Text.TrimEnd())
                .Connection.Open()
                txtSupplierName.Text = .ExecuteScalar
            End With
        End Using
        txtSupplierRef.Text = UCase(txtSupplierRef.Text)
        If txtSupplierName.Text = "" Then MsgBox("Please Check your Supplier Reference", MsgBoxStyle.Critical, Application.ProductName) : txtSupplierRef.Clear() : txtSupplierRef.Select() : Exit Sub
        If txtSupplierName.Text <> "" And CheckBox1.Checked = False Then
            txtStockCode.Select()
            Exit Sub
        Else
            txtWarehouseRef.Select()
            Exit Sub
        End If
    End Sub

    Private Sub TxtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles txtWarehouseRef.Leave
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .CommandText = "SELECT ShopName from tblShops WHERE ShopRef = @ShopRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ShopRef", txtWarehouseRef.Text.TrimEnd())
                .Connection.Open()
                txtWarehouseName.Text = .ExecuteScalar
            End With
        End Using
        txtWarehouseRef.Text = UCase(txtWarehouseRef.Text)

        If txtWarehouseName.Text = "" Then MsgBox("Please Check your Shop Reference", MsgBoxStyle.Critical, Application.ProductName) : txtWarehouseRef.Select() : Exit Sub
        If txtWarehouseName.Text <> "" And CheckBox1.Checked = True Then
            txtStockCode.Select()
            Exit Sub
        Else
            txtWarehouseRef.Select()
            Exit Sub
        End If
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        txtStockCode.Text = UCase(txtStockCode.Text)
        Dim work As Integer
        Dim result As Boolean = False
        If cmdOK.Text = "OK" Then
            If lblOldStockCode.Text.TrimEnd() <> txtStockCode.Text.TrimEnd() Then
                work = OlderStock(txtStockCode.Text.TrimEnd())
                If work = 1 Then Exit Sub
                If work = 0 Then Update30()
            ElseIf lblOldStockCode.Text.TrimEnd() = txtStockCode.Text.TrimEnd() Then
                result = Ch.CheckStockCode(txtStockCode.Text.TrimEnd())
                If result = True Then
                    stockCodeR = "New"
                    txtQtyGarments.Select()
                    Exit Sub
                Else
                    stockCodeR = "Old"
                    Dim results As DialogResult = MessageBox.Show("Are you sure you wish to use an existing stock code", "Exisiting StockCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If results = DialogResult.No Then txtStockCode.Select() : Exit Sub
                    If results = DialogResult.Yes Then txtQtyGarments.Select() : Exit Sub
                End If
            End If
        ElseIf cmdOK.Text = "ADD" Then
            result = Ch.CheckStockCode(txtStockCode.Text.TrimEnd())
            If result = True Then
                stockCodeR = "New"
                txtQtyGarments.Select()
                Exit Sub
            Else
                stockCodeR = "Old"
                Dim results As DialogResult = MessageBox.Show("Are you sure you wish to use an existing stock code", "Exisiting StockCode", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If results = DialogResult.No Then txtStockCode.Select() : Exit Sub
                If results = DialogResult.Yes Then txtQtyGarments.Select() : Exit Sub
            End If
        End If
    End Sub
    Private Sub Update30()
        CheckStockCode()
        save.SaveShopSalesLines(0, txtStockCode.Text.TrimEnd, 0, 0, 0, 0)
        st.SaveStockMovements(txtStockCode.Text.TrimEnd, txtSupplierRef.Text.TrimEnd, "DU", "Shop", 0, 0, "Delivery (S)", CDate(DateTimePicker1.Value), 0, txtStockCode.Text, CInt(txtOrderID.Text))
    End Sub
    Private Function OlderStock(stockcode As String) As Integer
        Dim result As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand()
            With cmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT COUNT(*) As 'NumStockCode' from tblStock WHERE StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@StockCode", stockcode)
                End With
                result = .ExecuteScalar
            End With
        End Using
        Return result
    End Function

    Private Sub CheckStockCode()
        Dim inta As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim FindCmd As New SqlCommand()
            With FindCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT StockID FROM tblStock WHERE StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@StockCode", lblOldStockCode.Text.TrimEnd())
                End With
                inta = .ExecuteScalar
            End With
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblStock SET StockCode=@StockCode WHERE StockID = @StockID"
                With .Parameters
                    .AddWithValue("@StockCode", txtStockCode.Text.TrimEnd)
                    .AddWithValue("@StockID", inta)

                End With
                .ExecuteNonQuery()
            End With
        End Using
    End Sub
    Private Sub TxtQtyGarments_Leave(sender As Object, e As EventArgs) Handles txtQtyGarments.Leave
        If txtStockCode.Text = "" Then MsgBox("Please Enter a Stock Code", vbExclamation + vbOKOnly, ProductName)
        txtTotalGarments.Text = txtQtyGarments.Text
    End Sub

    Private Sub TxtNetCost_Leave(sender As Object, e As EventArgs) Handles txtNetCost.Leave
        If txtQtyGarments.Text = "0" Then
            MsgBox("Please enter a quantity to be delivered!", vbExclamation + vbOKOnly, ProductName)
            txtQtyGarments.Select()
        ElseIf txtQtyGarments.Text > "0" Then
            txtNetCost.Text = FormatCurrency(txtNetCost.Text)
            txtTotalNet.Text = CDec(txtNetCost.Text)
            txtTotal.Text = FormatCurrency(txtTotal.Text)
            CalculateTotals()
        End If
    End Sub
    Private Sub CalculateTotals()
        Dim curNetTotal As Decimal
        curNetTotal = 0
        txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
        txtTotal.Text = FormatCurrency(CDec(txtTotalNet.Text) + CDec(txtCommission.Text) + CDec(txtDelCharges.Text))
    End Sub
    Private Sub TxtShipper_Leave(sender As Object, e As EventArgs) Handles txtShipper.Leave
        txtShipper.Text = StrConv(txtShipper.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtDelCharges_Leave(sender As Object, e As EventArgs) Handles txtDelCharges.Leave
        txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
        CalculateTotals()
    End Sub

    Private Sub TxtCommission_Leave(sender As Object, e As EventArgs) Handles txtCommission.Leave
        txtCommission.Text = FormatCurrency(txtCommission.Text)
        CalculateTotals()
    End Sub

    Private Sub FPOrders_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Using conn As New SqlConnection(ut.GetConnString())
                Dim data As New DataSet
                Dim adp As New SqlDataAdapter
#Disable Warning IDE0017 ' Simplify object initialization
                Dim txts As New SqlCommand("SELECT SupplierRef from tblSuppliers", conn)
#Enable Warning IDE0017 ' Simplify object initialization
                txts.CommandType = CommandType.Text
                adp.SelectCommand = txts
                adp.Fill(data)
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To data.Tables(0).Rows.Count - 1
                    ACSC.Add(data.Tables(0).Rows(i).Item(0).ToString)
                Next
                txtSupplierRef.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtSupplierRef.AutoCompleteCustomSource = ACSC
                txtSupplierRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
            Using conn As New SqlConnection(ut.GetConnString())
                Dim data As New DataSet
                Dim adp As New SqlDataAdapter
#Disable Warning IDE0017 ' Simplify object initialization
                Dim txts As New SqlCommand("SELECT StockCode from tblStock", conn)
#Enable Warning IDE0017 ' Simplify object initialization
                txts.CommandType = CommandType.Text
                adp.SelectCommand = txts
                adp.Fill(data)
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To data.Tables(0).Rows.Count - 1
                    ACSC.Add(data.Tables(0).Rows(i).Item(0).ToString)
                Next
                txtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtStockCode.AutoCompleteCustomSource = ACSC
                txtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
            Using conn As New SqlConnection(ut.GetConnString())
                Dim data As New DataSet
                Dim adp As New SqlDataAdapter
#Disable Warning IDE0017 ' Simplify object initialization
                Dim txts As New SqlCommand("SELECT ShopRef from tblShops", conn)
#Enable Warning IDE0017 ' Simplify object initialization
                txts.CommandType = CommandType.Text
                adp.SelectCommand = txts
                adp.Fill(data)
                Dim ACSC As New AutoCompleteStringCollection
                Dim i As Integer
                For i = 0 To data.Tables(0).Rows.Count - 1
                    ACSC.Add(data.Tables(0).Rows(i).Item(0).ToString)
                Next
                txtWarehouseRef.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtWarehouseRef.AutoCompleteCustomSource = ACSC
                txtWarehouseRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
            Text = "Delivery for [" + txtWarehouseName.Text + "]"
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try
        txtWarehouseRef.Enabled = False
        txtWarehouseName.Enabled = False
        DateTimePicker1.Value = ut.GetSundaysDate(Now)
        If cmdOK.Text = "ADD" Then loadnew()
        If cmdOK.Text = "OK" Then LoadOld()
    End Sub

    Private Sub TxtShipper_Enter(sender As Object, e As EventArgs) Handles txtShipper.Enter
        If txtNetCost.Text = "0.00" Then MsgBox("please enter a Money Value", vbExclamation + vbOKOnly, ProductName)
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("Select * from tblDeliveries WHERE DeliveriesID = '" + txtOrderID.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            txtCommission.Text = dt.Rows(0).Item("Commission")
            txtDelCharges.Text = dt.Rows(0).Item("DeliveryCharge")
            txtNetCost.Text = dt.Rows(0).Item("NetAmount")
            txtQtyGarments.Text = dt.Rows(0).Item("DQtyGarments")
            txtShipper.Text = dt.Rows(0).Item("Shipper")
            txtShipperInv.Text = dt.Rows(0).Item("ShipperInvoice")
            txtStockCode.Text = dt.Rows(0).Item("StockCode")
            lblOldStockCode.Text = dt.Rows(0).Item("StockCode")
            txtSupplierInv.Text = dt.Rows(0).Item("InvoiceNo")
            txtSupplierName.Text = dt.Rows(0).Item("SupplierName")
            txtSupplierRef.Text = dt.Rows(0).Item("SupplierRef")
            txtTotal.Text = dt.Rows(0).Item("TotalAmount")
            txtTotalGarments.Text = dt.Rows(0).Item("TotalGarments")
            txtTotalNet.Text = dt.Rows(0).Item("NetAmount")
            txtWarehouseName.Text = dt.Rows(0).Item("LocationName")
            txtWarehouseRef.Text = dt.Rows(0).Item("LocationRef")
            RichTextBox1.Text = dt.Rows(0).Item("Notes")
            DateTimePicker1.Value = dt.Rows(0).Item("DeliveryDate")
            olddate = dt.Rows(0).Item("DeliveryDate")
            txtCommission.Text = FormatCurrency(txtCommission.Text)
            txtDelCharges.Text = FormatCurrency(txtDelCharges.Text)
            txtNetCost.Text = FormatCurrency(txtNetCost.Text)
            txtTotal.Text = FormatCurrency(txtTotal.Text)
            txtTotalNet.Text = FormatCurrency(txtTotalNet.Text)
            oldwref = txtWarehouseRef.Text.TrimEnd()
            Text = "Purchase Order for [" + txtWarehouseName.Text.TrimEnd + "]"
        End Using
    End Sub
    Private Sub loadnew()
        txtWarehouseRef.Text = "UNI"
        txtWarehouseName.Text = "Universal Warehouse"
    End Sub
    Private Sub txtStockCode_Enter(sender As Object, e As EventArgs) Handles txtStockCode.Enter

    End Sub

    Private Sub txtSupplierRef_Enter(sender As Object, e As EventArgs) Handles txtSupplierRef.Enter

    End Sub

    Private Sub txtWarehouseRef_Enter(sender As Object, e As EventArgs) Handles txtWarehouseRef.Enter

    End Sub
End Class