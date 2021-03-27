Imports System.Data.SqlClient

Public Class FShopTransfers
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim strWarehouse As String
    Dim strStock As String
    Dim strStockCode As String
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FShopTransfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then loadnew()
        If FMain.txtMode.Text = "DELETE" Then recorddelete()
        If FMain.txtMode.Text = "OLD" Then loadold()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If cmdOK.Text = "OK" Then Updatedb() : FMain.ShopTransfersToolStripMenuItem.PerformClick() : Me.Close()
        ' If cmdOK.Text = "Add" Then addrecord() : addother() : Me.Close()
        If cmdOK.Text = "Add" Then addshoptransrecord() : FMain.ShopTransfersToolStripMenuItem.PerformClick() : Me.Close()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        DataGridView1.Rows.Clear()
        txtStockCode.Clear()
        txtTransferFromQty.Clear()
        txtCurrentQty.Clear()
        txtTransferToQty.Clear()
        txtFromShopName.Clear()
        txtFromShopRef.Clear()
        txtTFNote.Clear()
        txtToShopName.Clear()
        txtToShopRef.Clear()
        txtTotalTransferFrom.Clear()
        txtTotalTransferTo.Clear()
        DateTimePicker1.Value = dLastSunday
    End Sub

    Private Sub cmdAddToGrid_Click(sender As Object, e As EventArgs) Handles cmdAddToGrid.Click
        If txtCurrentQty.Text = "0" Then MsgBox("Can't Transfer Zero Qty Stock") : Exit Sub
        If txtCurrentQty.Text < "0" Then MsgBox("Can't Transfer Negative Qty Stock") : Exit Sub

        Dim Values As Decimal
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select UnitPrice from qryShopStockDisplay where SMlocation = '" + txtFromShopRef.Text + "' and SMStockCode = '" + txtStockCode.Text + "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        Values = SelectCommand.ExecuteNonQuery()
        SelectCommand.Connection.Close()

        Dim total As Decimal
        total = CDec(txtTransferFromQty.Text * Values)

        Dim rowNum As Integer = DataGridView1.Rows.Add()
        DataGridView1.Rows.Item(rowNum).Cells(4).Value = txtStockCode.Text.ToString
        DataGridView1.Rows.Item(rowNum).Cells(5).Value = txtCurrentQty.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(6).Value = txtTransferFromQty.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(7).Value = txtTransferToQty.Text.ToString()

        Dim total2 As Integer
        Dim total3 As Integer
        Dim total4 As String = 0
        Dim total5 As String = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total3 += DataGridView1.Rows(i).Cells(6).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
            txtTotalTransferFrom.Text = total3
        Next

        For p As Integer = 0 To DataGridView1.RowCount - 1
            total2 += DataGridView1.Rows(p).Cells(7).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
            txtTotalTransferTo.Text = total2
        Next

        txtStockCode.Clear()
        txtTransferFromQty.Clear()
        txtCurrentQty.Clear()
        txtTransferToQty.Clear()

    End Sub

    Private Sub cmdDeleteFromGrid_Click(sender As Object, e As EventArgs) Handles cmdDeleteFromGrid.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        End If

        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        If DataGridView1.SelectedRows.Count < 1 Then
            MessageBox.Show("Select one or more rows before you click delete", "DMH StockMaster v2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim total2 As String = 0
        Dim total3 As String = 0
        Dim total4 As String = 0
        Dim total5 As String = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total3 += DataGridView1.Rows(i).Cells(2).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtTotalTransferFrom.Text = total2
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total2 += DataGridView1.Rows(i).Cells(3).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
    End Sub

    Private Sub cmdFindShopFrom_Click(sender As Object, e As EventArgs) Handles cmdFindShopFrom.Click
        FindFromShop()
    End Sub

    Private Sub cmdFindShopTo_Click(sender As Object, e As EventArgs) Handles cmdFindShopTo.Click
        FindToShop()
    End Sub

    Private Sub cmdFindStock_Click(sender As Object, e As EventArgs) Handles cmdFindStock.Click
        If txtFromShopRef.Text = "" Then MsgBox("Please Select Transfer from Shop", MsgBoxStyle.Critical, Application.ProductName)
        If txtFromShopRef.Text <> "" Then FindStockCode()
    End Sub

    Private Sub txtFromShopRef_Leave(sender As Object, e As EventArgs) Handles txtFromShopRef.Leave
        FindFromShop()
    End Sub

    Private Sub txtToShopRef_Leave(sender As Object, e As EventArgs) Handles txtToShopRef.Leave
        FindToShop()
    End Sub

    Private Sub txtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        getcurrentqty()
    End Sub

    Private Sub txtTransferFromQty_Leave(sender As Object, e As EventArgs) Handles txtTransferFromQty.Leave
        txtTransferToQty.Text = txtTransferFromQty.Text
    End Sub

    Public Sub SELECTText(ByVal ctr As TextBox)
        ctr.SelectionStart = 0
        ctr.SelectionLength = Len(ctr.Text)
    End Sub

    Private Sub FindFromShop()
        If txtFromShopRef.Text = "" Then MsgBox("Please Enter Shop Code", ProductName) : txtFromShopRef.Select() : Exit Sub
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select ShopName From tblShops Where ShopRef = '" & txtFromShopRef.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        txtFromShopName.Text = SelectCommand.ExecuteScalar
        SelectCommand.CommandText = "Select ShopType From tblShops Where ShopRef = '" & txtFromShopRef.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        txtFromShopType.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
    End Sub
    Private Sub FindToShop()
        If txtFromShopRef.Text = "" And txtToShopRef.Text = "" Then MsgBox("Please Enter Shop Code", ProductName) : txtFromShopRef.Select() : Exit Sub
        If txtToShopRef.Text = "" Then MsgBox("Please Enter Shop Code", ProductName) : txtToShopRef.Select() : Exit Sub
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select ShopName From tblShops Where ShopRef = '" & txtToShopRef.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        txtToShopName.Text = SelectCommand.ExecuteScalar
        SelectCommand.CommandText = "Select ShopType From tblShops Where ShopRef = '" & txtToShopRef.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        txtToShopType.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
    End Sub
    Private Sub FindStockCode()
        If txtFromShopRef.Text = "" And txtToShopRef.Text = "" Then MsgBox("Please Enter Shop Code", ProductName) : txtFromShopRef.Select() : Exit Sub
        If txtStockCode.Text = "" Then MsgBox("Please Enter a Stock Code", ProductName) : txtStockCode.Select() : Exit Sub

        ' SelectCommand.Connection = connection
        ' SelectCommand.CommandText = "Select Qty From qryShopStock Where SMLocation = '" & txtFromShopRef.Text & "' AND SMStockCode = '" & txtStockCode.Text & "'"
        ' SelectCommand.CommandType = CommandType.Text
        ' SelectCommand.Connection.Open()
        ' txtCurrentQty.Text = SelectCommand.ExecuteNonQuery
        ' SelectCommand.Connection.Close()
        ' Dim Qstock As String = "SELECT tblStock.StockCode, Sum(qryWarehouseStock.QtyHangers) AS QtyHangers, Sum(qryWarehouseStock.QtyBoxes) AS QtyBoxes FROM tblStock INNER JOIN qryWarhouseStock ON tblStock.StockCode = qryWarehouseStock.StockCode WHERE (((qryWarehouseStock.Location)='" & txtWarehouseRef.Text & "') AND ((qryWarehouseStock.StockCode) = '" & txtStockCode.Text & "')) Group By tblStock.StockCode ORDER BY tblStock.StockCode"
        ' txtCurrentHangers = qtyHangers
        ' txtCurrentBoxes = qtyBoxes
        Dim sql As String = "SELECT Qty from qryShopStock Where SMLocation='" + txtFromShopRef.Text + "' AND SMStockCode='" + txtStockCode.Text.ToString() + "'"
        ' Dim da As New SqlDataAdapter(sql, connection)
        ' Dim ds As New DataSet
        ' da.Fill(ds, "qryWarehouseStock")
        ' Dim dr As DataRow = ds.Tables(0).Rows(1)
        SelectCommand.Connection = connection
        SelectCommand.CommandText = sql
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Close()
        SelectCommand.Connection.Open()
        txtCurrentQty.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
    End Sub
    Private Sub loadold()
        cmdOK.Text = "OK"
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        TextBox1.Text = FMain.DgvRecords.Item(0, i).Value
        txtTFNote.Text = FMain.DgvRecords.Item(1, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(2, i).Value
        txtFromShopRef.Text = FMain.DgvRecords.Item(3, i).Value
        txtFromShopName.Text = FMain.DgvRecords.Item(4, i).Value
        txtToShopRef.Text = FMain.DgvRecords.Item(5, i).Value
        txtToShopName.Text = FMain.DgvRecords.Item(6, i).Value
        Dim strsql As String = "SELECT * from tblShopTransferLines Where TransferID='" & TextBox1.Text & "'"
        Dim gridDataAdapter As New SqlDataAdapter(strsql, connection)
        Dim data As New DataSet
        DataGridView1.Columns.Clear()
        gridDataAdapter.Fill(data, "tblShopTransferLines")
        DataGridView1.DataSource = data
        DataGridView1.DataMember = "tblShopTransferLines"
        DataGridView1.AutoGenerateColumns = True
        txtTotalTransferFrom.Text = FMain.DgvRecords.Item(7, i).Value
        txtTotalTransferTo.Text = FMain.DgvRecords.Item(8, i).Value

        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(0).Visible = False
        DataGridView1.Columns.Item(0).HeaderText = "TransID Ref"
        DataGridView1.Columns.Item(0).Width = "182"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(0).Visible = False
        DataGridView1.Columns.Item(0).HeaderText = "TransID Ref"
        DataGridView1.Columns.Item(0).Width = "182"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(1).Visible = False
        DataGridView1.Columns.Item(1).HeaderText = "TransID Ref"
        DataGridView1.Columns.Item(1).Width = "182"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(2).Visible = False
        DataGridView1.Columns.Item(2).HeaderText = "TransID Ref"
        DataGridView1.Columns.Item(2).Width = "182"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(3).Visible = False
        DataGridView1.Columns.Item(3).HeaderText = "TransID Ref"
        DataGridView1.Columns.Item(3).Width = "182"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(4).Visible = True
        DataGridView1.Columns.Item(4).HeaderText = "Stock Code"
        DataGridView1.Columns.Item(4).Width = "82"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(5).Visible = True
        DataGridView1.Columns.Item(5).HeaderText = "Current Qty"
        DataGridView1.Columns.Item(5).Width = "82"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(6).Visible = True
        DataGridView1.Columns.Item(6).HeaderText = "Transfer Out"
        DataGridView1.Columns.Item(6).Width = "82"
        'tblShopTransfer.TransferID
        DataGridView1.Columns.Item(7).Visible = True
        DataGridView1.Columns.Item(7).HeaderText = "Transfer In"
        DataGridView1.Columns.Item(7).Width = "82"

    End Sub
    Private Sub loadnew()
        cmdOK.Text = "Add"
        DateTimePicker1.Value = dLastSunday
    End Sub
    Private Sub recorddelete()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        TextBox1.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where TransferReference = '" + TextBox1.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblShopTransferLines where TransferID = '" + TextBox1.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblShopTransfers where TransferID = '" + TextBox1.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.ShopTransfersToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Private Sub getcurrentqty()
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select Qty From qryShopStock Where SMLocation = '" & txtFromShopRef.Text & "' AND SMStockCode = '" & txtStockCode.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        txtCurrentQty.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()

    End Sub


    Private Function addrecord()
        Dim blnTran As Boolean
        ' Dim lngNextRef As Integer
        addrecord = False
        blnTran = True
        'Transfer Out 
        ' Dim getstockValue As String
        Dim Values As Integer
        'StockValDataAdapter.Fill(edata, "qryUnitPrice")
        ' If edata.Tables("qryUnitPrice").Rows Is Nothing Then getstockValue = "0"

        ' getstockValue = edata.Tables("qryUnitprice").Rows(0).Item(1)
        '  Values = CInt(IIf(Not IsNumeric(txtTransferActual.Text), txtTransferQtyHangers.Text, txtTransferActual.Text)) * getstockValue
        Try
            'Dim updatedb As String = " INSERT tblStock SET StockCode = @StockCode,SupplierRef = @SupplierRef,Season = @Season,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers,RemoveFromClearance = @RemoveFromClearance,AmountTaken= @AmountTaken, CostValue = @CostValue,PCMarkUp = @PCMarkUp,ZeroQty= @ZeroQty,CreatedBy = @CreatedBy,CreatedDate= @CreatedDate WHERE StockCode = @StockCode"
            Dim insertdb As String = " INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate)VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            Dim connection As New SqlConnection(connectionString)
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            'Transfer Out
            ' lngNextRef = getnextRef()
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                com.Connection.Open()
                ' com.Parameters.AddWithValue("@StockmovementID", lngNextRef)
                com.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(4).Value)
                com.Parameters.AddWithValue("@SMSupplierRef", "")
                com.Parameters.AddWithValue("@SMLocation", txtFromShopRef.Text)
                com.Parameters.AddWithValue("@SMLocationType", "Shop")
                com.Parameters.AddWithValue("@MovementType", "Shop Transfer")
                com.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(6).Value * -1))
                'com.Parameters.AddWithValue("@MovementQtyBoxes", "0")
                com.Parameters.AddWithValue("@MovementValue", Values * -1)
                com.Parameters.AddWithValue("@Reference", txtTFNote.Text)
                com.Parameters.AddWithValue("@TransferReference", txtTFNote.Text)
                com.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                com.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
                com.Parameters.AddWithValue("@SMCreatedDate", Now)
                com.ExecuteNonQuery()
                com.Connection.Close()
            Next

        Catch ex As Exception

        End Try

        addrecord = True
        Exit Function
    End Function
    Private Sub addother()
        'Transfer Out 
        ' Dim getstockValue As String
        Dim Values As Integer
        'StockValDataAdapter.Fill(edata, "qryUnitPrice")
        ' If edata.Tables("qryUnitPrice").Rows Is Nothing Then getstockValue = "0"

        ' getstockValue = edata.Tables("qryUnitprice").Rows(0).Item(1)
        '  Values = CInt(IIf(Not IsNumeric(txtTransferActual.Text), txtTransferQtyHangers.Text, txtTransferActual.Text)) * getstockValue
        Try
            'Dim updatedb As String = " INSERT tblStock SET StockCode = @StockCode,SupplierRef = @SupplierRef,Season = @Season,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers,RemoveFromClearance = @RemoveFromClearance,AmountTaken= @AmountTaken, CostValue = @CostValue,PCMarkUp = @PCMarkUp,ZeroQty= @ZeroQty,CreatedBy = @CreatedBy,CreatedDate= @CreatedDate WHERE StockCode = @StockCode"
            Dim insertdb As String = " INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate)VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            Dim connection As New SqlConnection(connectionString)
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            'Transfer Out
            ' lngNextRef = getnextRef()
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                com.Connection.Open()
                'com.Parameters.AddWithValue("@StockmovementID", lngNextRef)
                com.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(4).Value)
                com.Parameters.AddWithValue("@SMSupplierRef", "")
                com.Parameters.AddWithValue("@SMLocation", txtToShopRef.Text)
                com.Parameters.AddWithValue("@SMLocationType", "Shop")
                com.Parameters.AddWithValue("@MovementType", "Shop Transfer")
                com.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(7).Value))
                ' com.Parameters.AddWithValue("@MovementQtyBoxes", "0")
                com.Parameters.AddWithValue("@MovementValue", Values)
                com.Parameters.AddWithValue("@Reference", txtTFNote.Text)
                com.Parameters.AddWithValue("@TransferReference", txtTFNote.Text)
                com.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                com.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
                com.Parameters.AddWithValue("@SMCreatedDate", Now)
                com.ExecuteNonQuery()
                com.Clone()
            Next

        Catch ex As Exception

        End Try


    End Sub
    Private Function getnextRef() As Long
        On Error Resume Next
        SelectCommand.CommandText = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Shop Transfer'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        getnextRef = SelectCommand.ExecuteScalar()
        SelectCommand.Connection.Close()

        Dim str As String
        str = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Shop Transfer'"
        Dim cmd = New SqlCommand(str, connection)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New Data.DataSet
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a = 0 Then getnextRef = 1
        If a >= 0 Then getnextRef = ds.Tables(0).Columns(0).ToString
        getnextRef = getnextRef + 1

    End Function
    Public Sub addTransfer()
        Dim rowNum As Integer = DataGridView1.Rows.Add()
        ' TextBox1.Text = DataGridView1.Rows.Item(rowNum).Cells(0).Value
        '  TextBox2.Text = DataGridView1.Rows.Item(rowNum).Cells(1).Value
        ' TextBox3.Text = DataGridView1.Rows.Item(rowNum).Cells(2).Value
        '  TextBox4.Text = DataGridView1.Rows.Item(rowNum).Cells(3).Value
        txtStockCode.Text = DataGridView1.Rows.Item(rowNum).Cells(4).Value
        txtCurrentQty.Text = DataGridView1.Rows.Item(rowNum).Cells(5).Value
        txtTransferFromQty.Text = DataGridView1.Rows.Item(rowNum).Cells(6).Value
        txtTransferToQty.Text = DataGridView1.Rows.Item(rowNum).Cells(7).Value

    End Sub
    Private Sub addshoptransrecord()
        Dim insertcommand1 As New SqlCommand
        Dim insertcommand2 As New SqlCommand
        Dim insertcommand3 As New SqlCommand
        Dim insertcommand4 As New SqlCommand
        Dim selectcommand5 As New SqlCommand
        Dim selectcommand6 As New SqlCommand
        Dim selectcommand7 As New SqlCommand
        Dim selectcommand8 As New SqlCommand


        Dim getnextref As Integer
        Dim getnextref2 As Integer
        Dim getnextref3 As Integer

        Try
            ' Create Transfer main record
            insertcommand1.CommandType = CommandType.Text
            insertcommand1.CommandText = "INSERT INTO tblShopTransfers(Reference,TransferDate,ShopRef,ShopName,ToShopRef,ToShopName,TotalQtyOut,TotalQtyIn,CreatedBy,CreatedDate) VALUES (@Reference,@TransferDate,@ShopRef,@ShopName,@ToShopRef,@ToShopName,@TotalQtyOut,@TotalQtyIn,@CreatedBy,@CreatedDate)"
            insertcommand1.Connection = connection
            insertcommand1.Connection.Close()
            insertcommand1.Connection.Open()
            insertcommand1.Parameters.AddWithValue("@Reference", txtTFNote.Text)
            insertcommand1.Parameters.AddWithValue("@TransferDate", DateTimePicker1.Value)
            insertcommand1.Parameters.AddWithValue("@ShopRef", txtFromShopRef.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@ShopName", txtFromShopName.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@ToShopRef", txtToShopRef.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@ToShopName", txtToShopName.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@TotalQtyOut", txtTotalTransferFrom.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@TotalQtyIn", txtTotalTransferTo.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text.ToString())
            insertcommand1.Parameters.AddWithValue("@CreatedDate", Date.Now())
            insertcommand1.Connection.Close()
            insertcommand1.Connection.Open()
            insertcommand1.ExecuteNonQuery()
            insertcommand1.Connection.Close()

            SelectCommand.CommandText = "Select Max(TransferID) From tblShopTransfers"
            SelectCommand.CommandType = CommandType.Text
            SelectCommand.Connection.Open()
            getnextref = SelectCommand.ExecuteScalar()
            SelectCommand.Connection.Close()
            TextBox4.Text = getnextref
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim value As Double
                Dim retvalue As Double
                Dim sql As String = "SELECT Unitprice from qryUnitPrice Where StockCode = '" + DataGridView1.Rows(i).Cells(4).Value.ToString() + "'"
                Dim selectcommand1 As New SqlCommand
                selectcommand1.CommandText = sql
                selectcommand1.CommandType = CommandType.Text
                selectcommand1.Connection = connection
                selectcommand1.Connection.Close()
                selectcommand1.Connection.Open()
                retvalue = selectcommand1.ExecuteScalar
                selectcommand1.Connection.Close()

                value = retvalue * CInt(DataGridView1.Rows(i).Cells(6).Value * -1)



                'Create StockMovement out Record
                insertcommand2.CommandType = CommandType.Text
                insertcommand2.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate)VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                insertcommand2.Connection = connection
                insertcommand2.Connection.Close()
                insertcommand2.Connection.Open()
                insertcommand2.Parameters.Clear()
                insertcommand2.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(4).Value)
                insertcommand2.Parameters.AddWithValue("@SMSupplierRef", "")
                insertcommand2.Parameters.AddWithValue("@SMLocation", txtFromShopRef.Text)
                insertcommand2.Parameters.AddWithValue("@SMLocationType", "Shop")
                insertcommand2.Parameters.AddWithValue("@MovementType", "Shop Transfer")
                insertcommand2.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(6).Value * -1))
                'com.Parameters.AddWithValue("@MovementQtyBoxes", "0")
                insertcommand2.Parameters.AddWithValue("@MovementValue", value * -1)
                insertcommand2.Parameters.AddWithValue("@Reference", txtTFNote.Text)
                insertcommand2.Parameters.AddWithValue("@TransferReference", TextBox4.Text)
                insertcommand2.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                insertcommand2.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
                insertcommand2.Parameters.AddWithValue("@SMCreatedDate", Now)
                insertcommand2.ExecuteNonQuery()
                insertcommand2.Connection.Close()
                Dim selectcommand4 As New SqlCommand
                selectcommand4.CommandText = "Select Max(StockMovementID) From tblStockMovements"
                selectcommand4.CommandType = CommandType.Text
                selectcommand4.Connection = connection
                selectcommand4.Connection.Open()
                getnextref2 = selectcommand4.ExecuteScalar()
                selectcommand4.Connection.Close()
                TextBox3.Text = getnextref2
                'Create StockMovement In Record
                Dim values As Double
                Dim retvalues As Double
                Dim sql2 As String = "SELECT Unitprice from qryUnitPrice Where StockCode = '" + DataGridView1.Rows(i).Cells(4).Value.ToString() + "'"
                Dim selectcommand2 As New SqlCommand
                selectcommand2.CommandText = sql
                selectcommand2.CommandType = CommandType.Text
                selectcommand2.Connection = connection
                selectcommand2.Connection.Close()
                selectcommand2.Connection.Open()
                retvalues = selectcommand2.ExecuteScalar
                selectcommand1.Connection.Close()

                values = retvalues * CInt(DataGridView1.Rows(i).Cells(7).Value)

                insertcommand3.CommandType = CommandType.Text
                insertcommand3.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate)VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                insertcommand3.Connection = connection
                insertcommand3.Connection.Close()
                insertcommand3.Connection.Open()
                'insertcommand3.Connection.Open()
                insertcommand3.Parameters.Clear()
                'com.Parameters.AddWithValue("@StockmovementID", lngNextRef)
                insertcommand3.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(4).Value)
                insertcommand3.Parameters.AddWithValue("@SMSupplierRef", "")
                insertcommand3.Parameters.AddWithValue("@SMLocation", txtToShopRef.Text)
                insertcommand3.Parameters.AddWithValue("@SMLocationType", "Shop")
                insertcommand3.Parameters.AddWithValue("@MovementType", "Shop Transfer")
                insertcommand3.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(7).Value))
                ' com.Parameters.AddWithValue("@MovementQtyBoxes", "0")
                insertcommand3.Parameters.AddWithValue("@MovementValue", values)
                insertcommand3.Parameters.AddWithValue("@Reference", txtTFNote.Text)
                insertcommand3.Parameters.AddWithValue("@TransferReference", TextBox4.Text)
                insertcommand3.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                insertcommand3.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
                insertcommand3.Parameters.AddWithValue("@SMCreatedDate", Now)
                insertcommand3.ExecuteNonQuery()
                insertcommand3.Connection.Close()
                selectcommand5.Connection = connection
                selectcommand5.CommandText = "Select Max(StockMovementID) From tblStockMovements"
                selectcommand5.CommandType = CommandType.Text
                selectcommand5.Connection.Close()
                selectcommand5.Connection.Open()
                getnextref3 = selectcommand5.ExecuteScalar()
                selectcommand5.Connection.Close()
                TextBox2.Text = getnextref3

                ' Create Transfer Lines records
                insertcommand4.CommandType = CommandType.Text
                insertcommand4.CommandText = "INSERT INTO tblShopTransferLines(TransferID,SMTOID,SMTIID,CurrentQty,StockCode,TOQty,TIQty) VALUES (@TransferID,@SMTOID,@SMTIID,@CurrentQty,@StockCode,@TOQty,@TIQty)"
                insertcommand4.Connection = connection
                insertcommand4.Connection.Close()
                insertcommand4.Connection.Open()
                insertcommand4.Parameters.Clear()
                insertcommand4.Parameters.AddWithValue("@TransferID", TextBox4.Text)
                insertcommand4.Parameters.AddWithValue("@SMTOID", TextBox3.Text)
                insertcommand4.Parameters.AddWithValue("@SMTIID", TextBox2.Text)
                insertcommand4.Parameters.AddWithValue("@StockCode", DataGridView1.Rows(i).Cells(4).Value.ToString())
                insertcommand4.Parameters.AddWithValue("@CurrentQty", DataGridView1.Rows(i).Cells(5).Value)
                insertcommand4.Parameters.AddWithValue("@TOQty", DataGridView1.Rows(i).Cells(6).Value)
                insertcommand4.Parameters.AddWithValue("@TIQty", DataGridView1.Rows(i).Cells(7).Value)
                insertcommand4.Connection.Close()
                insertcommand4.Connection.Open()
                insertcommand4.ExecuteNonQuery()
                insertcommand4.Connection.Close()

            Next
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")

        End Try

    End Sub
    Private Sub Updatedb()
        Dim insertcommand1 As New SqlCommand
        Dim insertcommand2 As New SqlCommand
        Dim insertcommand3 As New SqlCommand
        Dim insertcommand4 As New SqlCommand
        Dim selectcommand5 As New SqlCommand
        Dim selectcommand6 As New SqlCommand
        Dim selectcommand7 As New SqlCommand
        Dim selectcommand8 As New SqlCommand
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where TransferReference = '" + TextBox1.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblShopTransferLines where TransferID = '" + TextBox1.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim value As Double
            Dim retvalue As Double
            Dim sql As String = "SELECT Unitprice from qryUnitPrice Where StockCode = '" + DataGridView1.Rows(i).Cells(4).Value.ToString() + "'"
            Dim selectcommand1 As New SqlCommand
            selectcommand1.CommandText = sql
            selectcommand1.CommandType = CommandType.Text
            selectcommand1.Connection = connection
            selectcommand1.Connection.Close()
            selectcommand1.Connection.Open()
            retvalue = selectcommand1.ExecuteScalar
            selectcommand1.Connection.Close()

            value = retvalue * CInt(DataGridView1.Rows(i).Cells(6).Value * -1)



            'Create StockMovement out Record
            insertcommand2.CommandType = CommandType.Text
            insertcommand2.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate)VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            insertcommand2.Connection = connection
            insertcommand2.Connection.Close()
            insertcommand2.Connection.Open()
            insertcommand2.Parameters.Clear()
            insertcommand2.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(4).Value)
            insertcommand2.Parameters.AddWithValue("@SMSupplierRef", "")
            insertcommand2.Parameters.AddWithValue("@SMLocation", txtFromShopRef.Text)
            insertcommand2.Parameters.AddWithValue("@SMLocationType", "Shop")
            insertcommand2.Parameters.AddWithValue("@MovementType", "Shop Transfer")
            insertcommand2.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(6).Value * -1))
            'com.Parameters.AddWithValue("@MovementQtyBoxes", "0")
            insertcommand2.Parameters.AddWithValue("@MovementValue", value * -1)
            insertcommand2.Parameters.AddWithValue("@Reference", txtTFNote.Text)
            insertcommand2.Parameters.AddWithValue("@TransferReference", TextBox4.Text)
            insertcommand2.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertcommand2.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
            insertcommand2.Parameters.AddWithValue("@SMCreatedDate", Now)
            insertcommand2.ExecuteNonQuery()
            insertcommand2.Connection.Close()
            Dim selectcommand4 As New SqlCommand
            Dim getnextref2 As String
            selectcommand4.CommandText = "Select Max(StockMovementID) From tblStockMovements"
            selectcommand4.CommandType = CommandType.Text
            selectcommand4.Connection = connection
            selectcommand4.Connection.Open()
            getnextref2 = selectcommand4.ExecuteScalar()
            selectcommand4.Connection.Close()
            TextBox3.Text = getnextref2
            'Create StockMovement In Record
            Dim getnextref3 As String
            Dim values As Double
            Dim retvalues As Double
            Dim sql2 As String = "SELECT Unitprice from qryUnitPrice Where StockCode = '" + DataGridView1.Rows(i).Cells(4).Value.ToString() + "'"
            Dim selectcommand2 As New SqlCommand
            selectcommand2.CommandText = sql
            selectcommand2.CommandType = CommandType.Text
            selectcommand2.Connection = connection
            selectcommand2.Connection.Close()
            selectcommand2.Connection.Open()
            retvalues = selectcommand2.ExecuteScalar
            selectcommand1.Connection.Close()

            values = retvalues * CInt(DataGridView1.Rows(i).Cells(7).Value)

            insertcommand3.CommandType = CommandType.Text
            insertcommand3.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementType,MovementQtyHangers,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate)VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementType,@MovementQtyHangers,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            insertcommand3.Connection = connection
            insertcommand3.Connection.Close()
            insertcommand3.Connection.Open()
            'insertcommand3.Connection.Open()
            insertcommand3.Parameters.Clear()
            'com.Parameters.AddWithValue("@StockmovementID", lngNextRef)
            insertcommand3.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(4).Value)
            insertcommand3.Parameters.AddWithValue("@SMSupplierRef", "")
            insertcommand3.Parameters.AddWithValue("@SMLocation", txtToShopRef.Text)
            insertcommand3.Parameters.AddWithValue("@SMLocationType", "Shop")
            insertcommand3.Parameters.AddWithValue("@MovementType", "Shop Transfer")
            insertcommand3.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(7).Value))
            ' com.Parameters.AddWithValue("@MovementQtyBoxes", "0")
            insertcommand3.Parameters.AddWithValue("@MovementValue", values)
            insertcommand3.Parameters.AddWithValue("@Reference", txtTFNote.Text)
            insertcommand3.Parameters.AddWithValue("@TransferReference", TextBox4.Text)
            insertcommand3.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertcommand3.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
            insertcommand3.Parameters.AddWithValue("@SMCreatedDate", Now)
            insertcommand3.ExecuteNonQuery()
            insertcommand3.Connection.Close()
            selectcommand5.Connection = connection
            selectcommand5.CommandText = "Select Max(StockMovementID) From tblStockMovements"
            selectcommand5.CommandType = CommandType.Text
            selectcommand5.Connection.Close()
            selectcommand5.Connection.Open()
            getnextref3 = selectcommand5.ExecuteScalar()
            selectcommand5.Connection.Close()
            TextBox2.Text = getnextref3

            ' Create Transfer Lines records
            insertcommand4.CommandType = CommandType.Text
            insertcommand4.CommandText = "INSERT INTO tblShopTransferLines(TransferID,SMTOID,SMTIID,CurrentQty,StockCode,TOQty,TIQty) VALUES (@TransferID,@SMTOID,@SMTIID,@CurrentQty,@StockCode,@TOQty,@TIQty)"
            insertcommand4.Connection = connection
            insertcommand4.Connection.Close()
            insertcommand4.Connection.Open()
            insertcommand4.Parameters.Clear()
            insertcommand4.Parameters.AddWithValue("@TransferID", TextBox4.Text)
            insertcommand4.Parameters.AddWithValue("@SMTOID", TextBox3.Text)
            insertcommand4.Parameters.AddWithValue("@SMTIID", TextBox2.Text)
            insertcommand4.Parameters.AddWithValue("@StockCode", DataGridView1.Rows(i).Cells(4).Value.ToString())
            insertcommand4.Parameters.AddWithValue("@CurrentQty", DataGridView1.Rows(i).Cells(5).Value)
            insertcommand4.Parameters.AddWithValue("@TOQty", DataGridView1.Rows(i).Cells(6).Value)
            insertcommand4.Parameters.AddWithValue("@TIQty", DataGridView1.Rows(i).Cells(7).Value)
            insertcommand4.Connection.Close()
            insertcommand4.Connection.Open()
            insertcommand4.ExecuteNonQuery()
            insertcommand4.Connection.Close()

        Next
    End Sub
End Class