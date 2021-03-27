Imports System.Data.SqlClient

Public Class FShopDeliveries
    Dim connectionString As String = "Initial Catalog=DMHStockV1;Data Source=(local)\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    ' Create a DataSet
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim strShop As String
    Dim strStock As String
    Dim strWarehouse As String
    Dim strStockCode As String
    'GET LAST SATURDAY
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    'GET LAST SUNDAY
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FShopDeliveries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then loadnew()
        If FMain.txtMode.Text = "OLD" Then LoadRecord()
        If FMain.txtMode.Text = "DELETE" Then DeleteRecord()
        DateTimePicker1.Value = dLastSunday.AddDays(7)
    End Sub

    Private Sub cmdFindSupplier_Click(sender As Object, e As EventArgs) Handles cmdFindSupplier.Click
        If txtShopRef.Text = "" Then displayallshops()
        If txtShopRef.Text <> "" Then FindFromShop()
    End Sub

    Private Sub cmdFindWarehouse_Click(sender As Object, e As EventArgs) Handles cmdFindWarehouse.Click

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        addDeliveries()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdClearForm_Click(sender As Object, e As EventArgs) Handles cmdClearForm.Click
        txtShopRef.Clear()
        txtDelNoteNumber.Clear()
        txtQtyHangers.Clear()
        txtReference.Clear()
        txtTotalGarments.Text = "0"
        txtStockCode.Clear()
        DataGridView1.Rows.Clear()
        txtShopName.Clear()

    End Sub

    Private Sub cmdFindStockCode_Click(sender As Object, e As EventArgs) Handles cmdFindStockCode.Click
        If txtStockCode.Text = "" Then showallstock()
        If txtStockCode.Text <> "" Then FindStock()
    End Sub

    Private Sub cmdAddItem_Click(sender As Object, e As EventArgs) Handles cmdAddItem.Click
        Dim rowNum As Integer = DataGridView1.Rows.Add()
        DataGridView1.Rows.Item(rowNum).Cells(0).Value = txtStockCode.Text.ToString
        DataGridView1.Rows.Item(rowNum).Cells(1).Value = txtQtyHangers.Text
        Dim total As Integer
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(1).Value
            'Change the number 2 to your column index number (The first column has a 0 index column)
            'In this example the column index of Price is 2
        Next
        txtTotalGarments.Text = total
        txtStockCode.Clear()
        txtQtyHangers.Clear()
        txtStockCode.Select()
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        If DataGridView1.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
        End If

        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
        If DataGridView1.SelectedRows.Count < 1 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim total As String = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            total += DataGridView1.Rows(i).Cells(1).Value
        Next
    End Sub
    Private Sub loadnew()
        Dim qry As String = "SELECT ShopRef,ShopName from tblShops"
        Dim mycommand = New SqlCommand(qry, connection)
        mycommand.Connection.Open()
        Dim reader As SqlDataReader = mycommand.ExecuteReader()
        dgvShops.DataSource = reader
        mycommand.Connection.Close()
        DateTimePicker1.Value = dLastSunday
        Dim qry2 As String = "SELECT StockCode from tblStock"
        Dim mycommand2 = New SqlCommand(qry2, connection)
        mycommand2.Connection.Open()
        Dim reader2 As SqlDataReader = mycommand2.ExecuteReader()
        dgvStock.DataSource = reader2
        mycommand2.Connection.Close()
        cmdAdd.Text = "Add"
    End Sub

    Private Sub FindStock()
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select StockCode From tblStock Where StockCode = '" & txtStockCode.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        txtStockCode.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
    End Sub
    Private Sub showallstock()
        dgvStock.Visible = True
    End Sub
    Private Sub LoadRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtReference.Text = FMain.DgvRecords.Item(5, i).Value
        txtDelNoteNumber.Text = FMain.DgvRecords.Item(0, i).Value
        txtTotalGarments.Text = FMain.DgvRecords.Item(6, i).Value
        txtShopName.Text = FMain.DgvRecords.Item(2, i).Value
        txtShopRef.Text = FMain.DgvRecords.Item(1, i).Value
        txtWarehouseRef.Text = FMain.DgvRecords.Item(3, i).Value
        txtWarehouseName.Text = FMain.DgvRecords.Item(4, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(7, i).Value
        Dim qry As String = "SELECT SStockCode,DeliveredQty from tblShopDeliveriesLines Where SDeliveriesID='" & txtDelNoteNumber.Text & "'"
        Dim mycommand2 = New SqlCommand(qry, connection)
        mycommand2.Connection.Open()
        Dim reader2 As SqlDataReader = mycommand2.ExecuteReader()
        'DataGridView1.DataSource = reader2
        mycommand2.Connection.Close()
        'DataGridView1.Refresh()
        DataGridView1.Columns.Clear()
        connection.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New SqlDataAdapter
        adapter.SelectCommand = mycommand2
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
        DataGridView1.Columns.Item(1).HeaderText = "Qty"
        cmdAdd.Text = "OK"
    End Sub
    Private Sub nextref()
        Dim value As Integer
        Dim nref As Integer
        Dim command As New SqlCommand("SELECT MAX(TransferReference) as MaxRef from tblStockMovements where MovementType = 'Delivery (S)'")
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            value = reader(0)
        End If
        reader.Close()
        nref = IIf(IsDBNull(value.ToString), 1, value + 1)
        txtReference.Text = nref

    End Sub
    Private Function getnextRef() As Long
        SelectCommand.Connection = connection
        SelectCommand.Connection.Open()
        SelectCommand.CommandType = CommandType.Text
        Dim Sesql As String = "SELECT MAX(TransferReference) as MaxRef FROM tblStockMovements WHERE MovementType = 'Delivery (S)' AND SMLocation ='" + txtShopRef.Text + "'"
        Dim sdata As New SqlDataAdapter(Sesql, connection)
        Dim dtr As New DataSet
        '   Dim rdata As String
        '  rdata = SelectCommand.ExecuteNonQuery()
        sdata.Fill(dtr, "tblStockMovements")
        Dim dr As DataRow = dtr.Tables(0).Rows(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Error Getting Next Ref from the Database", MsgBoxStyle.Information, ProductName)
        Else
            Label7.Text = dr("MaxRef") + 1
            connection.Close()
        End If


        '        On Error Resume Next
        '       SelectCommand.CommandText = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Return'"
        '      SelectCommand.CommandType = CommandType.Text
        '     SelectCommand.Connection.Open()
        '    getnextRef = SelectCommand.ExecuteScalar()
        '   SelectCommand.Connection.Close()

        '        Dim str As String
        '        Str = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Return'"
        '        Dim cmd = New SqlCommand(str, connection)
        '       Dim da = New SqlDataAdapter(cmd)
        '       Dim ds = New Data.DataSet
        '       da.Fill(ds)
        '       Dim a As Integer
        '       a = ds.Tables(0).Rows.Count
        '
        '      If a = 0 Then getnextRef = 1
        '       If a = 1 Then getnextRef = ds.Tables(0).Columns(0).ToString
        '     Dim value As Integer
        '    value = ds.Tables(0).Rows(0).ToString
        '   getnextRef = value + 1
        '  lblTransRef.Text = getnextRef
        txtReference.Text = Trim(txtShopRef.Text) + Label7.Text
    End Function
    Private Sub DeleteRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtDelNoteNumber.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where TransferReference = '" + txtDelNoteNumber.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblShopDeliveriesLines where SDeliveriesID = '" + txtDelNoteNumber.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblShopDeliveries where DeliveriesID = '" + txtDelNoteNumber.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.ShopDeliveriesToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Private Sub UpdateRecord()
        Me.Validate()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where TransferReference = '" + txtDelNoteNumber.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblShopDeliveriesLines where DeliveryID = '" + txtDelNoteNumber.Text.ToString + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            ' InsertCommand.Parameters.Clear()
            InsertCommand.Connection = connection
            InsertCommand.Parameters.Clear()

            InsertCommand.Connection.Open()
            InsertCommand.CommandType = CommandType.Text
            InsertCommand.CommandText = " INSERT INTO tblShopDeliveriesLines (sDeliveriesID,sStockCode,DeliveredQty) VALUES (@sDeliveriesID,@sStockCode,@DeliveredQty)"
            InsertCommand.Parameters.AddWithValue("@sDeliveriesID", txtDelNoteNumber.Text)
            InsertCommand.Parameters.AddWithValue("@sStockCode", DataGridView1.Rows(i).Cells(0).Value)
            InsertCommand.Parameters.AddWithValue("@DeliveredQty", DataGridView1.Rows(i).Cells(1).Value)
            InsertCommand.ExecuteNonQuery()
            InsertCommand.Connection.Close()
        Next

        Dim pvalue As String
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            SelectCommand.Connection = connection
            SelectCommand.CommandText = "Select unitprice from qryWarehouseStock where SMlocation = '" + txtWarehouseRef.Text + "' and StockCode = '" + DataGridView1.Rows(i).Cells(0).Value + "'"
            SelectCommand.Connection.Close()
            SelectCommand.Connection.Open()
            pvalue = SelectCommand.ExecuteNonQuery()
            SelectCommand.Connection.Close()
            InsertCommand.Parameters.Clear()

            Me.Validate()
            InsertCommand.Connection = connection
            InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value)
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "")
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text)
            InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", DataGridView1.Rows(i).Cells(1).Value)
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", pvalue)
            InsertCommand.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtDelNoteNumber.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()
            InsertCommand.Connection.Close()
            InsertCommand.Parameters.Clear()
            InsertCommand.Connection = connection
            InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
            InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value)
            InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "")
            InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
            InsertCommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
            InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(1).Value * -1))
            InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
            InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            InsertCommand.Parameters.AddWithValue("@MovementValue", pvalue)
            InsertCommand.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
            InsertCommand.Parameters.AddWithValue("@TransferReference", txtDelNoteNumber.Text)
            InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
            InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            InsertCommand.Connection.Open()
            InsertCommand.ExecuteNonQuery()
            InsertCommand.Connection.Close()
        Next
        Dim updatedb As String = "UPDATE tblShopDeliveries SET TotalItems = @TotalItems WHERE Deliveries ='" + txtDelNoteNumber.Text + "'"
        Dim com As New SqlCommand(updatedb, connection)
        com.Connection.Open()
        com.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text.ToString)
        com.ExecuteNonQuery()
        com.Connection.Close()

        FMain.ShopDeliveriesToolStripMenuItem.PerformClick()
        Me.Close()

    End Sub

    Private Sub AddToShopDeliveryTable()
        If DataGridView1.RowCount = 0 Then MsgBox("Please Add some stock to the delivery", vbExclamation, ProductName) : Exit Sub
        If DataGridView1.RowCount >= 1 Then
            '  Dim ID As Integer
            Try
                connection.Close()
                InsertCommand.CommandType = CommandType.StoredProcedure
                InsertCommand.CommandText = "AddShopDeliveryReturnIDwithoutput"
                InsertCommand.Connection = connection
                InsertCommand.Parameters.AddWithValue("@ShopRef", txtShopRef.Text)
                InsertCommand.Parameters.AddWithValue("@ShopName", txtShopName.Text)
                InsertCommand.Parameters.AddWithValue("@WarehouseRef", txtWarehouseRef.Text)
                InsertCommand.Parameters.AddWithValue("@WarehouseName", txtWarehouseName.Text)
                InsertCommand.Parameters.AddWithValue("@Reference", txtDelNoteNumber.Text)
                InsertCommand.Parameters.AddWithValue("@TotalItems", txtTotalGarments.Text)
                InsertCommand.Parameters.AddWithValue("@DeliveryDate", DateTimePicker1.Value)
                InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text.ToString())
                InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
                InsertCommand.Parameters.Add("@DeliveriesId", SqlDbType.Int)
                InsertCommand.Parameters("@DeliveriesId").Direction = ParameterDirection.Output
                connection.Open()
                ' InsertCommand.ExecuteNonQuery()
                ' id = InsertCommand.Parameters("@DeliveriesId").Value
                'txtReference.Text = ID
                connection.Close()
                ' InsertCommand.ExecuteNonQuery()
                InsertCommand.Connection.Open()
                Dim d As String = InsertCommand.Parameters("@DeliveriesId").Value
                ' Dim WaypointID As Integer = InsertCommand.ExecuteScalar 'The ID will be returned.
                d = InsertCommand.ExecuteScalar
                ' MsgBox(WaypointID + d, MsgBoxStyle.Information, Application.ProductName)
                '  txtReference.Text = WaypointID
                InsertCommand.Connection.Close()
                Dim insertcommand2 As New SqlCommand
                Dim p As Integer = 0
                insertcommand2.CommandText = "SELECT MAX(DeliveriesID) from tblShopDeliveries"
                insertcommand2.CommandType = CommandType.Text
                insertcommand2.Connection = connection
                insertcommand2.Connection.Close()
                insertcommand2.Connection.Open()
                p = insertcommand2.ExecuteScalar
                insertcommand2.Connection.Close()

                txtDelNoteNumber.Text = p
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    ' InsertCommand.Parameters.Clear()
                    InsertCommand.Connection = connection
                    InsertCommand.Parameters.Clear()

                    InsertCommand.Connection.Open()
                    InsertCommand.CommandType = CommandType.Text
                    InsertCommand.CommandText = " INSERT INTO tblShopDeliveriesLines (sDeliveriesID,sStockCode,DeliveredQty) VALUES (@sDeliveriesID,@sStockCode,@DeliveredQty)"
                    InsertCommand.Parameters.AddWithValue("@sDeliveriesID", txtDelNoteNumber.Text)
                    InsertCommand.Parameters.AddWithValue("@sStockCode", DataGridView1.Rows(i).Cells(0).Value)
                    InsertCommand.Parameters.AddWithValue("@DeliveredQty", DataGridView1.Rows(i).Cells(1).Value)
                    InsertCommand.ExecuteNonQuery()
                    InsertCommand.Connection.Close()
                Next
                InsertCommand.Connection.Close()
            Catch ex As SqlException
                MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
            End Try
        End If
    End Sub

    Private Sub addDeliveries()
        If DataGridView1.Rows.Count = 0 Then MsgBox("Please add Some Items", vbExclamation, ProductName)
        If DataGridView1.Rows.Count >= 1 Then

            AddRecord()
            Dim pvalue As String
            Try
                Me.Validate()
                SelectCommand.Connection = connection
                SelectCommand.CommandText = "Select unitprice from qryWarehouseStock where SMlocation = '" + txtWarehouseRef.Text + "' and StockCode = '" + txtStockCode.Text + "'"
                SelectCommand.Connection.Close()
                SelectCommand.Connection.Open()
                pvalue = SelectCommand.ExecuteNonQuery()
                SelectCommand.Connection.Close()
                '  InsertCommand.CommandText = " INSERT INTO tblStockMovements (StockCode,SupplierRef,Location,LocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,CreatedBy,CreatedDate) VALUES(@StockCode,@SupplierRef,@Location,@LocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@CreatedBy,@CreatedDate)"
                '  InsertCommand.Parameters.Add("@StockCode") '0 0
                '  InsertCommand.Parameters.Add("@SupplierRef") '1
                '  InsertCommand.Parameters.Add("@Location") '2 1
                '   InsertCommand.Parameters.Add("@LocationType") '3
                '   InsertCommand.Parameters.Add("@MovementQtyHangers") '4 4
                '  InsertCommand.Parameters.Add("@MovementType") '5 3
                '  InsertCommand.Parameters.Add("@MovementDate") '6 5
                '   InsertCommand.Parameters.Add("@MovementValue") '7 6
                '   InsertCommand.Parameters.Add("@Reference") '8
                '   InsertCommand.Parameters.Add("@TransferReference") '9
                '   InsertCommand.Parameters.Add("@CreatedBy") '10
                '   InsertCommand.Parameters.Add("@CreatedDate") '11
                '   InsertCommand.Connection.Open()
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    InsertCommand.Parameters.Clear()

                    Me.Validate()
                    InsertCommand.Connection = connection
                    InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                    InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value)
                    InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "")
                    InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text)
                    InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop")
                    InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", DataGridView1.Rows(i).Cells(1).Value)
                    InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
                    InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                    InsertCommand.Parameters.AddWithValue("@MovementValue", pvalue)
                    InsertCommand.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
                    InsertCommand.Parameters.AddWithValue("@TransferReference", txtDelNoteNumber.Text)
                    InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
                    InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                    InsertCommand.Connection.Open()
                    InsertCommand.ExecuteNonQuery()
                    InsertCommand.Connection.Close()
                    InsertCommand.Parameters.Clear()
                    InsertCommand.Connection = connection
                    InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                    InsertCommand.Parameters.AddWithValue("@SMStockCode", DataGridView1.Rows(i).Cells(0).Value)
                    InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "")
                    InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
                    InsertCommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
                    InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(DataGridView1.Rows(i).Cells(1).Value * -1))
                    InsertCommand.Parameters.AddWithValue("@MovementType", "Delivery (S)")
                    InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                    InsertCommand.Parameters.AddWithValue("@MovementValue", pvalue)
                    InsertCommand.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
                    InsertCommand.Parameters.AddWithValue("@TransferReference", txtDelNoteNumber.Text)
                    InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FMain.TextBox1.Text.ToString())
                    InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                    InsertCommand.Connection.Open()
                    InsertCommand.ExecuteNonQuery()
                    InsertCommand.Connection.Close()
                Next



            Catch ex As SqlException
                MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, ProductName)
            End Try
        End If
        FMain.ShopDeliveriesToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Private Sub AddRecord()
        Try
            Dim queryResult As Integer
            DuplicateCommand.Connection = connection
            DuplicateCommand.Connection.Open()
            DuplicateCommand.CommandType = CommandType.Text
            DuplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStockmovements WHERE Reference = '" + txtReference.Text.ToString() + "'"
            queryResult = DuplicateCommand.ExecuteNonQuery()
            DuplicateCommand.Connection.Close()
            If queryResult > 0 Then MessageBox.Show("Reference Record : [" + txtReference.Text + "] Already Exists in the database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtReference.Select()

            If queryResult < 0 Then AddToShopDeliveryTable()
        Catch ex As Exception
            MessageBox.Show("Error in database", "DMH Stock Master v2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub FindFromShop()
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select ShopName From tblShops Where ShopRef = '" & txtShopRef.Text & "'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        txtShopName.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()
    End Sub
    Private Sub displayallshops()
        dgvShops.Visible = True

    End Sub





End Class