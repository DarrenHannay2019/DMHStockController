Imports System.Data.SqlClient
Public Class FShopDelivery
    Dim ut As New CUtils
    Dim save As New CSave
    Dim upd As New CUpdate
    Dim Ch As New CCheck
    Dim Syslog As New CSystemLog
    Dim st As New CStockMovements
    Private Sub FShopDelivery_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
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
                txtShopRef.AutoCompleteSource = AutoCompleteSource.CustomSource
                txtShopRef.AutoCompleteCustomSource = ACSC
                txtShopRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End Using
            If cmdAdd.Text = "OK" Then LoadOld()
            If cmdAdd.Text = "ADD" Then LoadNew()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ProductName)
        End Try

    End Sub
    Private Sub LoadNew()
        DateTimePicker1.Value = ut.GetNextSundaysDate(Now)
    End Sub
    Private Sub TxtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .CommandText = "SELECT ShopName from tblShops WHERE ShopRef = @ShopRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ShopRef", txtShopRef.Text.Trim())
                .Connection.Open()
                txtShopName.Text = .ExecuteScalar
            End With
        End Using
        txtShopRef.Text = UCase(txtShopRef.Text)
        If txtShopName.Text = "" Then MsgBox("Please Check your Shop Reference", MsgBoxStyle.Critical, Application.ProductName) : txtShopRef.Select()
        If txtShopName.Text <> "" Then
            txtStockCode.Select()
            Text = "Delivery To [" + txtShopName.Text + "]"
        Else
            txtShopRef.Select()
        End If
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        Dim qty As Integer
        txtStockCode.Text = UCase(txtStockCode.Text)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT Qty from qryWarehouseStock2 WHERE SMLocation = @SMLocation AND SMStockCode = @SMStockCode"
                With .Parameters
                    .AddWithValue("@SMLocation", txtWarehouseRef.Text)
                    .AddWithValue("@SMStockCode", txtStockCode.Text)
                End With
                qty = .ExecuteScalar
                If qty = "0" Then
                    txtStockCode.SelectAll()
                Else
                    txtQty.Text = qty
                    txtQtyHangers.Select()
                End If
            End With
        End Using
    End Sub

    Private Sub CmdAddItem_Click(sender As Object, e As EventArgs) Handles cmdAddItem.Click
        Dim LineValue As Decimal
        Dim value As Decimal
        If txtQtyHangers.Text = "0" Then
            MsgBox("Please Enter a Qty to deliver to shop", MsgBoxStyle.Critical, ProductName)
            txtQtyHangers.Select()
        Else
            '   Using conn As New SqlConnection(ut.GetConnString())
            '   Dim selectcmd As New SqlCommand
            '    With selectcmd
            '    .Connection = conn
            '            .Connection.Open()
            '    .CommandType = CommandType.Text
            '    .CommandText = "SELECT unitprice from qryWarehouseStock WHERE SMStockCode = @SMStockCode AND SMLocation = @SMLocation"
            '     With .Parameters
            '    .AddWithValue("@SMStockCode", txtStockCode.Text)
            '    .AddWithValue("@SMLocation", txtWarehouseRef.Text)
            '   End With
            '   value = .ExecuteScalar
            '   End With
            '    End Using
            '     LineValue = CDec(value * CInt(txtQtyHangers.Text))
            Dim rowNum As Integer = DataGridView1.Rows.Add()
            DataGridView1.Rows.Item(rowNum).Cells(0).Value = txtStockCode.Text.ToString
            DataGridView1.Rows.Item(rowNum).Cells(1).Value = txtQtyHangers.Text
            DataGridView1.Rows.Item(rowNum).Cells(2).Value = "0"
            txtStockCode.Clear()
            txtQtyHangers.Clear()
            txtQty.Clear()
            txtStockCode.Select()
            CTotal()
        End If
    End Sub
    Private Sub CTotal()
        Dim total As Integer
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(1).Value
        Next
        txtTotalGarments.Text = total
        Deliverlabel.Text = DataGridView1.Rows.Count
    End Sub
    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        End If
        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        CTotal()
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If Deliverlabel.Text = "0" Then
            Me.Close()
        ElseIf Deliverlabel.Text > "0" Then
            If cmdAdd.Text = "OK" Then
                UpdatetoDB()
            Else
                SavetoDB()
            End If
        End If
        FGridShopDel.TsbRefresh.PerformClick()
        Me.Close()
    End Sub
    Private Sub SavetoDB()
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-Start-ADD", "Shop-In", CDate(DateTimePicker1.Value), "Start Shop Delivery")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-Start-ADD", "Warehouse-Out", CDate(DateTimePicker1.Value), "Start Shop Delivery")
        save.SaveShopDelHead(txtShopRef.Text, txtShopName.Text, txtWarehouseRef.Text, txtWarehouseName.Text, txtReference.Text, CInt(txtTotalGarments.Text), CDate(DateTimePicker1.Value))
        txtDelNoteNumber.Text = Ch.SaveShopDelHead()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(0).Value
            Dim Qty As Integer = DataGridView1.Rows(i).Cells(1).Value
            Dim Value As Decimal = DataGridView1.Rows(i).Cells(2).Value
            save.SaveShopDelLines(CInt(txtDelNoteNumber.Text), stockcode, CInt(Qty))
            Syslog.SaveSystemLog(stockcode, "N/A", txtShopRef.Text, CInt(Qty), "Shop-Delivery", "Add New Item", CDate(DateTimePicker1.Value), "Add Item to delivery")
            st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Warehouse", CInt(Qty * -1), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(Value * -1), txtReference.Text, CInt(txtDelNoteNumber.Text))
            st.SaveStockMovements(stockcode, "N/A", txtShopRef.Text, "Shop", CInt(Qty), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(Value), txtReference.Text, CInt(txtDelNoteNumber.Text))
        Next
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-End-ADD", "Shop-In", CDate(DateTimePicker1.Value), "End Shop Delivery")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-End-ADD", "Warehouse-Out", CDate(DateTimePicker1.Value), "End Shop Delivery")
    End Sub
    Private Sub UpdatetoDB()
        st.DeleteStockMovements("Delivery (S)", CInt(txtDelNoteNumber.Text), txtReference.Text, CDate(DateTimePicker1.Value))
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-Start-Update", "Shop-In", CDate(DateTimePicker1.Value), "Start Old Shop Delivery")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-Start-Update", "Warehouse-Out", CDate(DateTimePicker1.Value), "Start Old Shop Delivery")
        upd.SaveShopDelHead(CInt(txtDelNoteNumber.Text), txtShopRef.Text, txtShopName.Text, txtWarehouseRef.Text, txtWarehouseName.Text, txtReference.Text, CInt(txtTotalGarments.Text), CDate(DateTimePicker1.Value))
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim stockcode As String = DataGridView1.Rows(i).Cells(0).Value
            Dim Qty As Integer = DataGridView1.Rows(i).Cells(1).Value
            Dim Value As Decimal = 0
            Dim LineValue As Decimal = 0
            '  Using conn As New SqlConnection(ut.GetConnString())
            ' Dim selectcmd As New SqlCommand
            '   With selectcmd
            '  .Connection = conn
            '  .Connection.Open()
            ' .CommandType = CommandType.Text
            '.CommandText = "SELECT unitprice from qryWarehouseStock WHERE StockCode = @StockCode AND Location = @Location"
            'With .Parameters
            '.AddWithValue("@StockCode", txtStockCode.Text)
            '.AddWithValue("@Location", txtWarehouseRef.Text)
            'End With
            'Value = .ExecuteScalar
            'End With
            'End Using
            ' LineValue = CDec(Value * CInt(DataGridView1.Rows(i).Cells(1).Value))
            upd.SaveShopDelLines(CInt(txtDelNoteNumber.Text), stockcode, CInt(Qty))
            Syslog.SaveSystemLog(stockcode, "N/A", txtShopRef.Text, CInt(Qty), "Shop-Delivery", "Update Item", CDate(DateTimePicker1.Value), "update item on old delivery")
            st.SaveStockMovements(stockcode, "N/A", txtWarehouseRef.Text, "Warehouse", CInt(Qty * -1), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(0 * -1), txtReference.Text, CInt(txtDelNoteNumber.Text))
            st.SaveStockMovements(stockcode, "N/A", txtShopRef.Text, "Shop", CInt(Qty), 0, "Delivery (S)", CDate(DateTimePicker1.Value), CDec(0), txtReference.Text, CInt(txtDelNoteNumber.Text))
        Next
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-End-ADD", "Shop-In", CDate(DateTimePicker1.Value), "End Shop Delivery")
        Syslog.SaveSystemLog("N/A", "N/A", txtWarehouseRef.Text, CInt(txtTotalGarments.Text), "Shop-Delivery-End-ADD", "Warehouse-Out", CDate(DateTimePicker1.Value), "End Shop Delivery")
    End Sub
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then FGridShopDel.TsbRefresh.PerformClick() : Me.Close()
    End Sub

    Private Sub CmdClearForm_Click(sender As Object, e As EventArgs) Handles cmdClearForm.Click
        txtShopRef.Clear()
        txtDelNoteNumber.Clear()
        txtQtyHangers.Clear()
        txtReference.Clear()
        txtTotalGarments.Text = "0"
        txtStockCode.Clear()
        DataGridView1.Rows.Clear()
        txtShopName.Clear()
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        CTotal()
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblShopDeliveries WHERE DeliveriesID = '" + txtDelNoteNumber.Text.ToString() + "'", conn)}
            adp.Fill(dt)
            txtReference.Text = dt.Rows(0).Item("Reference")
            txtShopRef.Text = dt.Rows(0).Item("ShopRef")
            txtShopName.Text = dt.Rows(0).Item("ShopName")
            txtTotalGarments.Text = dt.Rows(0).Item("TotalItems")
            txtWarehouseRef.Text = dt.Rows(0).Item("WarehouseRef")
            txtWarehouseName.Text = dt.Rows(0).Item("WarehouseName")
            DateTimePicker1.Value = dt.Rows(0).Item("DeliveryDate")
            cmdClearForm.Enabled = False
        End Using
        DataGridView1.Columns.Clear()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim dgd As New SqlDataAdapter("SELECT SStockCode,DeliveredQty from tblShopDeliveriesLines WHERE SDeliveriesID = '" + txtDelNoteNumber.Text.ToString() + "'", conn)
            Dim ds As New DataTable
            dgd.Fill(ds)
            With DataGridView1
                .DataSource = ds
                .AutoGenerateColumns = True
                .CellBorderStyle = DataGridViewCellBorderStyle.None
                .BackgroundColor = Color.LightCoral
                .DefaultCellStyle.SelectionBackColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Yellow
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToResizeColumns = False
                .RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                With .Columns
                    .Item(0).Visible = True
                    .Item(0).HeaderText = "Stock Code"
                    .Item(0).Width = 120
                    .Item(1).Visible = True
                    .Item(1).HeaderText = "Qty"
                End With
            End With
        End Using
        CTotal()
    End Sub
End Class