Imports System.Data.SqlClient

Public Class FWarehouseAdjustments
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
    Private Sub FWarehouseAdjustments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "OLD" Then LoadOld()
        If FMain.txtMode.Text = "NEW" Then LoadNew()
        If FMain.txtMode.Text = "DELETE" Then LoadDelete()
        DateTimePicker1.Value = dLastSunday
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FindWarehouse()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtWarehouseRef.Text = Nothing Then MsgBox("Please Select a Warehouse", MsgBoxStyle.Critical, Application.ProductName)
        If txtWarehouseRef.Text <> Nothing Then FindStock()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If cboType.Text = "Loss" Then getnextRefLoss()
        If cboType.Text = "Gain" Then getnextRef()
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select unitprice from qryWarehouseStock where StockCode = '" + txtStockCode.Text + "'"
        SelectCommand.Connection.Open()
        TextBox1.Text = SelectCommand.ExecuteScalar()
        SelectCommand.Connection.Close()
        Dim Values As Decimal
        Values = CDec(txtAdjustHangers.Text * TextBox1.Text)
        Me.Validate()
        InsertCommand.Connection = connection
        InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
        InsertCommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
        InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "")
        InsertCommand.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
        InsertCommand.Parameters.AddWithValue("@SMLocationType", "Warehouse")
        If cboType.Text = "Gain" Then InsertCommand.Parameters.AddWithValue("@MovementType", "Stock Gain")
        If cboType.Text = "Loss" Then InsertCommand.Parameters.AddWithValue("@MovementType", "Stock Loss")
        InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
        If cboType.Text = "Gain" Then InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", txtAdjustHangers.Text)
        If cboType.Text = "Loss" Then InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(txtAdjustHangers.Text * -1))
        InsertCommand.Parameters.AddWithValue("@MovementValue", Values)
        InsertCommand.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
        InsertCommand.Parameters.AddWithValue("@TransferReference", "0")
        InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
        InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
        InsertCommand.Connection.Open()
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
        '  Main.WarehouseAdjustmentToolStripMenuItem.PerformClick()
        FMain.WarehouseAdjustmentsToolStripMenuItem.PerformClick()

        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtAdjustHangers.Clear()
        txtCurrentHangers.Clear()
        txtReference.Clear()
        txtStockCode.Clear()
        txtWarehouseName.Clear()
        txtWarehouseRef.Clear()
        DateTimePicker1.Value = dLastSunday
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub txtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles txtWarehouseRef.Leave
        FindWarehouse()
    End Sub

    Private Sub txtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        FindStock()
    End Sub

    Private Sub cboType_TextChanged(sender As Object, e As EventArgs) Handles cboType.TextChanged
        If cboType.Text = "Loss" Then getnextRefLoss()
        If cboType.Text = "Gain" Then getnextRef()
    End Sub
    Public Sub SELECTText(ByVal ctr As TextBox)
        ctr.SelectionStart = 0
        ctr.SelectionLength = Len(ctr.Text)
    End Sub
    Private Function getnextRefLoss() As Long
        On Error Resume Next
        SelectCommand.CommandText = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Stock Loss'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        getnextRefLoss = SelectCommand.ExecuteScalar()
        SelectCommand.Connection.Close()

        Dim str As String
        str = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Stock Loss'"
        Dim cmd = New SqlCommand(str, connection)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New Data.DataSet
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a = 0 Then getnextRefLoss = 1
        If a = 1 Then getnextRefLoss = ds.Tables(0).Columns(0).ToString
        getnextRefLoss = getnextRefLoss + 1
        txtReference.Text = txtWarehouseRef.Text + getnextRefLoss + "Loss"
    End Function
    Private Function getnextRef() As Long
        On Error Resume Next
        SelectCommand.CommandText = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Stock Gain'"
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Open()
        getnextRef = SelectCommand.ExecuteScalar()
        SelectCommand.Connection.Close()

        Dim str As String
        str = "Select Max(TransferReference) as MaxRef From tblStockMovements Where MovementType = 'Stock Gain'"
        Dim cmd = New SqlCommand(str, connection)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New Data.DataSet
        da.Fill(ds)
        Dim a As Integer
        a = ds.Tables(0).Rows.Count
        If a < 0 Then getnextRef = 1
        If a >= 0 Then getnextRef = ds.Tables(0).Columns(0).ToString
        getnextRef = getnextRef + 1
        txtReference.Text = txtWarehouseRef.Text + getnextRef + "Gain"
    End Function

    Private Sub GetStock()
        '     Dim Qstock As String = "SELECT tblStock.StockCode, Sum(qryWarehouseStock.QtyHangers) AS QtyHangers, Sum(qryWarehouseStock.QtyBoxes) AS QtyBoxes FROM tblStock INNER JOIN qryWarhouseStock ON tblStock.StockCode = qryWarehouseStock.StockCode WHERE (((qryWarehouseStock.Location)='" & txtWarehouseRef.Text & "') AND ((qryWarehouseStock.StockCode) = '" & txtStockCode.Text & "')) Group By tblStock.StockCode ORDER BY tblStock.StockCode"
        '   txtCurrentHangers = qtyHangers
        ' txtCurrentBoxes = qtyBoxes
        Dim sql As String = "SELECT QtyHangers from qryWarehouseStock Where SMLocation='" + txtWarehouseRef.Text + "' AND StockCode='" + txtStockCode.Text.ToString() + "'"
        '   Dim da As New SqlDataAdapter(sql, connection)
        '   Dim ds As New DataSet
        '   da.Fill(ds, "qryWarehouseStock")
        '   Dim dr As DataRow = ds.Tables(0).Rows(1)
        SelectCommand.Connection = connection
        SelectCommand.CommandText = sql
        SelectCommand.CommandType = CommandType.Text
        SelectCommand.Connection.Close()
        SelectCommand.Connection.Open()
        txtCurrentHangers.Text = SelectCommand.ExecuteScalar
        SelectCommand.Connection.Close()

        'txtCurrentHangers.Text = dr("QtyHangers").ToString()
    End Sub

    Private Sub LoadOld()
        Button4.Text = "&Ok"
        '  Button6.Text = "Cancel"
        Button5.Visible = False

    End Sub
    Private Sub LoadNew()
        Button4.Text = "&Add"
        '  Button6.Text = "Cancel"
        '  Button5.Text = "Clear"

    End Sub
    Private Sub LoadDelete()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index

        txtReference.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where StockmovementID = '" + txtReference.Text.ToString() + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.WarehouseAdjustmentsToolStripMenuItem.PerformClick()
        Me.Close()

    End Sub
    Public Sub FindWarehouse()
        Dim sql As String = "Select * from tblWarehouses WHERE WarehouseRef = '" & txtWarehouseRef.Text & "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet

        zdataa.Fill(dt, "tblWarehouses")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView2.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Warehouse", MsgBoxStyle.Information, Application.ProductName)
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
        Dim sql As String = "Select StockCode from tblStock where StockCode='" + txtStockCode.Text + "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet
        Try
            zdataa.Fill(dt, "tblStock")
            Dim dr As DataRow = dt.Tables(0).Rows(0)
            DataGridView1.DataSource = dt.Tables(0)
            If dr.Table.Rows.Count - 1 > 1 Then
                MsgBox("Please Select a Stock Code", MsgBoxStyle.Information, Application.ProductName)
                DataGridView1.Visible = True
                Dim i As Integer
                i = DataGridView1.CurrentRow.Index
                txtStockCode.Text = DataGridView2.Item(0, i).Value
                'txtWarehouseName.Text = DataGridView2.Item(1, i).Value
            Else
                'txtWarehouseName.Text = dr("WarehouseName").ToString
                txtStockCode.Text = dr("StockCode").ToString
            End If
            GetStock()

            '   If dr("WarehouseType").ToString = "False" Then TextBox16.Text = "Active"

            'If dr("WarehouseType").ToString = "True" Then TextBox16.Text = "Long Term"
        Catch
            MsgBox("Stock Code Not in the database", MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub






End Class