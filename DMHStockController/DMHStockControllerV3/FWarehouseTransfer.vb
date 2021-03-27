Imports System.Data.SqlClient

Public Class FWarehouseTransfer

    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getWarehouse()
    End Sub

    Private Sub FWarehouseTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.txtMode.Text = "OLD" Then LoadOLD()
        If Form1.txtMode.Text = "NEW" Then LoadNew()
        If Form1.txtMode.Text = "DELETE" Then LoadDelete()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        getStock()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        getshop()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub cboPONo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPONo.SelectedIndexChanged
        GetQuantity()
    End Sub
    Public Sub SELECTText(ByVal ctr As TextBox)
        ctr.SelectionStart = 0
        ctr.SelectionLength = Len(ctr.Text)
    End Sub

    Private Sub getWarehouse()
        '    Dim i As Integer
        '   Dim bdata As DataSet
        strWarehouse = txtWarehouseRef.Text
        Dim WarehouseDataAdapter As New SqlDataAdapter("Select * from tblWarehouses where WarehouseRef = '" & strWarehouse & "'", connection)
        ' If Trim(strWarehouse) <> "" Then

        '  WarehouseDataAdapter.Fill(bdata, "tblWarehouses")
        '  txtWarehouseName.Text = bdata.Tables("tblWarehouses").Rows(i).Item("WarehouseName")
        ' connection.Open()
        '  connection.Close()
        '  If CBool(bdata.Tables("tblWarehouses").Rows(0).Item("Warehousetype") Then
        'GetWarehouseType = "Long Term"
        '  Else
        '    GetWarehouseType = "Active"
        '    End If

        '      Call FindWarehouse()
        '  End If
    End Sub
    Public Sub FindShop()
        Dim sql As String = "Select * from tblWarehouses "
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet

        zdataa.Fill(dt, "tblWarehouses")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView3.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Warehouse", MsgBoxStyle.Information, "Stock Master V2")
            DataGridView3.Visible = True
            Dim i As Integer
            i = DataGridView3.CurrentRow.Index
            txtWarehouseRef.Text = DataGridView2.Item(0, i).Value
            txtWarehouseName.Text = DataGridView2.Item(1, i).Value
        Else
            txtNewWHName.Text = dr("WarehouseName").ToString
            txtNewWarehouse.Text = dr("WarehouseRef").ToString
        End If

    End Sub
    Public Sub FindWarehouse()
        Dim sql As String = "Select * from tblWarehouses "
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet

        zdataa.Fill(dt, "tblWarehouses")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView2.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Warehouse", MsgBoxStyle.Information, "Stock Master V2")
            DataGridView2.Visible = True
            Dim i As Integer
            i = DataGridView2.CurrentRow.Index
            txtWarehouseRef.Text = DataGridView2.Item(0, i).Value
            txtWarehouseName.Text = DataGridView2.Item(1, i).Value
        Else
            txtWarehouseName.Text = dr("WarehouseName").ToString
            txtWarehouseRef.Text = dr("WarehouseRef").ToString
        End If


    End Sub
    Public Sub FindStock()
        Dim sql As String = "Select * from tblStock where StockCode='" & txtStockCode.Text & "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet

        zdataa.Fill(dt, "tblWarehouses")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView1.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Stock Code", MsgBoxStyle.Information, "Stock Master V2")
            DataGridView1.Visible = True
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            txtStockCode.Text = DataGridView2.Item(0, i).Value
            'txtWarehouseName.Text = DataGridView2.Item(1, i).Value
        Else
            'txtWarehouseName.Text = dr("WarehouseName").ToString
            txtStockCode.Text = dr("StockCode").ToString
        End If


        '   If dr("WarehouseType").ToString = "False" Then TextBox16.Text = "Active"

        'If dr("WarehouseType").ToString = "True" Then TextBox16.Text = "Long Term"
    End Sub
    Private Sub getStock()
        Dim StockDataAdapter As New SqlDataAdapter("SELECT * FROM qryWarehouseStock WHERE (((qryWarehouseStock.Location)='" & strWarehouse & "') AND ((qryWarehouseStock.StockCode) Like '" & txtStockCode.Text & "*'))", connection)
        strStock = txtStockCode.Text
        If Trim(strStock) <> "" Then
            connection.Open()
            '     StockDataAdapter.Fill(cdata, "tblStock")
            '    txtStockCode.Text = cdata.Tables("tblStock").Rows(0).Item("StockCode")
            connection.Close()
        Else
            Call FindStock()
        End If
    End Sub

    Private Sub getshop()
        '   Dim WarehouseDataAdapter As New SqlDataAdapter("Select * from tblWarehouses where WarehouseRef = '" & strWarehouse & "'", connection)

        '  strWarehouse = txtWarehouseRef.Text
        '  If Trim(strWarehouse) <> "" Then
        'connection.Open()
        '  WarehouseDataAdapter.Fill(bdata, "tblWarehouses")
        '  txtNewWarehouse.Text = bdata.Tables("tblWarehouses").Rows(0).Item("WarehouseName")
        '  connection.Close()
        '       If CBool(bdata.Tables("tblWarehouses").Rows(0).Item("Warehousetype") Then
        'GetWarehouseType = "Long Term"
        '  Else
        '  GetWarehouseType = "Active"


        '   Call FindWarehouse()
        '   End If
        '   End If
    End Sub

    Private Function GetNextRef() As Integer
        On Error Resume Next
        Dim nextref As Integer

        '   objado.Fill(ddata, "tblStockMovements")
        '   If ddata.Tables("tblStockMovements").Rows Is Nothing Then nextref = "1"

        '  nextref = ddata.Tables("tblStockMovements").Rows(0).Item("MaxRef")
        txtReference.Text = nextref + 1

    End Function

    Public Function AddRecord() As Boolean

        Dim blnTran As Boolean
        Dim lngNextRef As Integer
        AddRecord = False
        blnTran = True
        'Transfer Out 
        '  Dim username As String


        ' useridda.Fill(udata, "tblEmployees")
        'username = udata.Tables(0).Rows(0).Item(0)
        ' Dim getstockValue As String
        Dim Values As Integer
        'StockValDataAdapter.Fill(edata, "qryUnitPrice")
        ' If edata.Tables("qryUnitPrice").Rows Is Nothing Then getstockValue = "0"

        ' getstockValue = edata.Tables("qryUnitprice").Rows(0).Item(1)
        '  Values = CInt(IIf(Not IsNumeric(txtTransferActual.Text), txtTransferQtyHangers.Text, txtTransferActual.Text)) * getstockValue
        Try
            'Dim updatedb As String = " INSERT tblStock SET StockCode = @StockCode,SupplierRef = @SupplierRef,Season = @Season,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers,RemoveFromClearance = @RemoveFromClearance,AmountTaken= @AmountTaken, CostValue = @CostValue,PCMarkUp = @PCMarkUp,ZeroQty= @ZeroQty,CreatedBy = @CreatedBy,CreatedDate= @CreatedDate WHERE StockCode = @StockCode"
            Dim insertdb As String = " INSERT INTO tblStockMovements (StockCode,SupplierRef,Location,LocationType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,CreatedBy,CreatedDate)VALUES(@StockCode,@SupplierRef,@Location,@LocationType,@MovementQtyHangers,@MovementQtyBoxes,@MovementDate,@MovementValue,@Reference,@TransferReference,@CreatedBy,@CreatedDate)"
            Dim connectionString As String = "Initial Catalog=StockMaster;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
            Dim connection As New SqlConnection(connectionString)
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            'Transfer Out
            lngNextRef = GetNextRef()
            com.Connection.Open()
            ' com.Parameters.AddWithValue("@StockmovementID", lngNextRef)
            com.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            com.Parameters.AddWithValue("@SupplierRef", "")
            com.Parameters.AddWithValue("@Location", txtWarehouseRef.Text)
            com.Parameters.AddWithValue("@LocationType", "1")
            com.Parameters.AddWithValue("@MovementType", "2")
            com.Parameters.AddWithValue("@MovementQtyHangers", CInt(txtTransferQtyHangers.Text) * -1)
            com.Parameters.AddWithValue("@MovementQtyBoxes", CInt(txtTransferBoxes.Text) * -1)
            com.Parameters.AddWithValue("@MovementValue", Values)
            com.Parameters.AddWithValue("@Reference", txtReference.Text)
            com.Parameters.AddWithValue("@TransferReference", txtReference.Text)
            com.Parameters.AddWithValue("@MovementDate", dteDate.Value)
            com.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
            com.Parameters.AddWithValue("@CreatedDate", Now)
            com.ExecuteNonQuery()
            com.Connection.Close()
            'Transfer In
            com.Connection.Open()
            'com.Parameters.AddWithValue("@StockmovementID", lngNextRef)
            com.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
            com.Parameters.AddWithValue("@SupplierRef", "")
            com.Parameters.AddWithValue("@Location", txtNewWarehouse.Text)
            com.Parameters.AddWithValue("@LocationType", "2")
            com.Parameters.AddWithValue("@MovementType", "2")
            com.Parameters.AddWithValue("@MovementQtyHangers", CInt(txtTransferQtyHangers.Text))
            com.Parameters.AddWithValue("@MovementQtyBoxes", CInt(txtTransferBoxes.Text))
            com.Parameters.AddWithValue("@MovementValue", Values)
            com.Parameters.AddWithValue("@Reference", txtReference.Text)
            com.Parameters.AddWithValue("@TransferReference", txtReference.Text)
            com.Parameters.AddWithValue("@MovementDate", dteDate.Value)
            com.Parameters.AddWithValue("@CreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
            com.Parameters.AddWithValue("@CreatedDate", Now)
            com.ExecuteNonQuery()
            com.Clone()

        Catch ex As Exception

        End Try

        AddRecord = True
        Exit Function
    End Function

    Private Sub PopulateDelNo()
        Dim strSQL As String = "Select * From tblDeliveryLines Where StockCode = '" & txtStockCode.Text & "'"
        Dim adata As New DataSet()
        Dim podelDA As New SqlDataAdapter(strSQL, connection)
        connection.Open()
        podelDA.Fill(adata, "tblDeliveryLines")
        cboPONo.DataSource = adata
        cboPONo.DisplayMember = "DeiveryID"
        cboPONo.ValueMember = "DeliveryID"
        For Each dRow As DataRow In adata.Tables("tblDeliveryLines").Rows
            cboPONo.Items.Add(dRow.Item(0).ToString)
        Next
        connection.Close()
    End Sub

    Public Sub GetQuantity()
        Dim stSQL As String = "SELECT DeliveredQtyHangers,DeliveredQtyBoxes from tblDeliveryLines WHERE DeliveryID = '" + cboPONo.Text + "'"
        Dim dt As New DataSet()
        Dim da As New SqlDataAdapter(stSQL, connection)
        connection.Open()
        da.Fill(dt, "tblDeliveryLines")
        txtCurrentBoxes.Text = dt.Tables("tblDeliveryLines").Columns.Item(1).ToString()
        txtCurrentHangers.Text = dt.Tables("tblDeliveryLines").Columns.Item(0).ToString()

    End Sub
    Private Sub LoadOld()

    End Sub
    Private Sub loadNew()

    End Sub
    Private Sub LoadDelete()

    End Sub



End Class