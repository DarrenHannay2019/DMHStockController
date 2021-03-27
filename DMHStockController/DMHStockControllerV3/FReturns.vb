Imports System.Data.SqlClient

Public Class FReturns
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim insert2Command As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim strWarehouse As String
    Dim strStock As String
    Dim strStockCode As String
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FReturns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Dim currentRef As String
        '   Dim nextRef As Integer
        If FMain.txtMode.Text = "DELETE" Then DeleteRecord()
        txtWarehouseRef.Text = "Uni"
        GetWarehouse()
        txtWarehouseName.Enabled = False
        txtWarehouseRef.Enabled = False
        DateTimePicker1.Value = dLastSunday

        '  SelectCommand.Connection = connection
        ' SelectCommand.CommandText = "Select Max(TransferReference) as MaxRef from tblStockMovements where MovementType = 'Return'"
        'SelectCommand.Connection.Open()
        'currentRef = SelectCommand.ExecuteScalar()
        'SelectCommand.Connection.Close()
        'nextRef = IIf(IsDBNull(currentRef.ToString), 1, currentRef + 1)
        'lblTransRef.Text = nextRef
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        createReturnRecord()
        Addrecord()
        FMain.ReturnsToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtReference.Clear()
        txtMovementBoxes.Clear()
        txtCurrentQty.Clear()
        txtShopName.Clear()
        txtShopRef.Clear()
        txtStockCode.Clear()
        txtTransferQty.Clear()
        txtWarehouseName.Clear()
        txtWarehouseRef.Clear()
        DateTimePicker1.Value = dLastSunday
    End Sub

    Private Sub cmdFindShop_Click(sender As Object, e As EventArgs) Handles cmdFindShop.Click
        GetShopName()
    End Sub

    Private Sub cmdFindStock_Click(sender As Object, e As EventArgs) Handles cmdFindStock.Click
        GetShopStock()
    End Sub

    Private Sub cmdFindWarehouse_Click(sender As Object, e As EventArgs) Handles cmdFindWarehouse.Click
        GetWarehouse()
    End Sub

    Private Sub txtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        GetShopName()
        getnextRef()
    End Sub

    Private Sub txtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        If txtShopRef.Text = "" Then MsgBox("Select A Shop", MsgBoxStyle.Critical, Application.ProductName)
        GetShopStock()
    End Sub

    Private Sub txtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles txtWarehouseRef.Leave
        GetWarehouse()
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Dim i As Integer
        i = DataGridView2.CurrentRow.Index
        txtWarehouseRef.Text = DataGridView2.Item(0, i).Value
        txtWarehouseName.Text = DataGridView2.Item(1, i).Value
        DataGridView3.Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        txtWarehouseRef.Text = DataGridView1.Item(0, i).Value
        txtWarehouseName.Text = DataGridView1.Item(1, i).Value
        DataGridView1.Visible = False
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim i As Integer
        i = DataGridView2.CurrentRow.Index
        txtStockCode.Text = DataGridView2.Item(0, i).Value
        txtCurrentQty.Text = DataGridView2.Item(1, i).Value
        DataGridView2.Visible = False
    End Sub

    Private Sub nextref()
        Dim value As Integer
        Dim nref As Integer
        Dim command As New SqlCommand("SELECT MAX(TransferReference) as MaxRef from tblStockMovements where MovementType = 'Return'")
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            value = reader(0)
        End If
        reader.Close()
        nref = IIf(IsDBNull(value.ToString), 1, value + 1)
        lblTransRef.Text = nref

    End Sub

    Private Sub GetWarehouse()
        Dim sql As String = "Select * from tblWarehouses WHERE WarehouseRef = '" & txtWarehouseRef.Text & "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet
        zdataa.Fill(dt, "tblWarehouses")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView1.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Warehouse", MsgBoxStyle.Information, Application.ProductName)
            DataGridView1.Visible = True
        Else
            txtWarehouseName.Text = dr("WarehouseName").ToString
            txtWarehouseRef.Text = dr("WarehouseRef").ToString
        End If
    End Sub
    Private Sub GetShopName()
        Dim sql As String = "Select ShopRef,ShopName from tblShops WHERE ShopRef = '" & txtShopRef.Text & "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet
        zdataa.Fill(dt, "tblShops")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView3.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Shop", MsgBoxStyle.Information, Application.ProductName)
            DataGridView3.Visible = True
        Else
            txtShopName.Text = dr("ShopName").ToString
            txtShopRef.Text = dr("ShopRef").ToString
        End If
        txtReference.Text = Trim(txtShopRef.Text) + lblTransRef.Text
    End Sub
    Private Sub GetShopStock()
        Try
            SelectCommand.Connection = connection
            SelectCommand.Connection.Open()
            SelectCommand.CommandType = CommandType.Text
            Dim sql As String = "SELECT tblStock.StockCode, Sum(qryShopStock.Qty) AS Qty FROM tblStock INNER JOIN qryShopStock ON tblStock.StockCode = qryShopStock.SMStockCode WHERE (((qryShopStock.SMLocation)='" & txtShopRef.Text & "') AND ((qryShopStock.SMStockCode) = '" & txtStockCode.Text & "')) and tblStock.DeadCode = 0 GROUP BY tblStock.StockCode"
            Dim zdata As New SqlDataAdapter(sql, connection)
            Dim dta As New DataSet
            If txtStockCode.Text = "" Then MsgBox("Please enter a stock code", MsgBoxStyle.Information, Application.ProductName)
            '  strStock = SelectCommand.ExecuteNonQuery()
            If txtStockCode.Text <> "" Then zdata.Fill(dta, "tblStock")
            Dim dr As DataRow = dta.Tables(0).Rows(0)
            DataGridView2.DataSource = dta.Tables(0)
            If dr.Table.Rows.Count - 1 > 1 Then
                MsgBox("Please Select a Stock", MsgBoxStyle.Information, Application.ProductName)
                DataGridView2.Visible = True
            Else
                txtStockCode.Text = dr("StockCode").ToString
                txtCurrentQty.Text = dr("Qty").ToString
                connection.Close()
            End If
        Catch ex As Exception
            MsgBox("Invalid Stock Code Please Try Again", vbCritical, ProductName)
        End Try
    End Sub
    Private Sub Addrecord()
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select unitprice from qryWarehouseStock where SMlocation = '" + txtWarehouseRef.Text + "' and StockCode = '" + txtStockCode.Text + "'"
        SelectCommand.Connection.Close()
        SelectCommand.Connection.Open()
        txtBoxes.Text = SelectCommand.ExecuteNonQuery()
        SelectCommand.Connection.Close()
        Dim Values As Decimal
        Values = CDec(txtTransferQty.Text * txtBoxes.Text)
        Me.Validate()
        InsertCommand.Connection = connection
        InsertCommand.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
        InsertCommand.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
        InsertCommand.Parameters.AddWithValue("@SMSupplierRef", "")
        InsertCommand.Parameters.AddWithValue("@SMLocation", txtShopRef.Text)
        InsertCommand.Parameters.AddWithValue("@SMLocationType", "Shop")
        InsertCommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(txtTransferQty.Text * -1))
        InsertCommand.Parameters.AddWithValue("@MovementType", "Return")
        InsertCommand.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
        InsertCommand.Parameters.AddWithValue("@MovementValue", Values)
        InsertCommand.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
        InsertCommand.Parameters.AddWithValue("@TransferReference", lblTransRef.Text)
        InsertCommand.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
        InsertCommand.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
        InsertCommand.Connection.Open()
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
        insert2Command.Connection = connection
        insert2Command.CommandText = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
        insert2Command.Parameters.AddWithValue("@SMStockCode", txtStockCode.Text)
        insert2Command.Parameters.AddWithValue("@SMSupplierRef", "")
        insert2Command.Parameters.AddWithValue("@SMLocation", txtWarehouseRef.Text)
        insert2Command.Parameters.AddWithValue("@SMLocationType", "Warehouse")
        insert2Command.Parameters.AddWithValue("@MovementQtyHangers", txtTransferQty.Text)
        insert2Command.Parameters.AddWithValue("@MovementType", "Return")
        insert2Command.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
        insert2Command.Parameters.AddWithValue("@MovementValue", Values)
        insert2Command.Parameters.AddWithValue("@Reference", txtReference.Text.ToString())
        insert2Command.Parameters.AddWithValue("@TransferReference", lblTransRef.Text)
        insert2Command.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text.ToString())
        insert2Command.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
        insert2Command.Connection.Open()
        insert2Command.ExecuteNonQuery()
        insert2Command.Connection.Close()
    End Sub
    Private Function getnextRef() As Long
        SelectCommand.Connection = connection
        SelectCommand.Connection.Open()
        SelectCommand.CommandType = CommandType.Text
        Dim Sesql As String = "SELECT MAX(TransferReference) as MaxRef FROM tblStockMovements WHERE MovementType = 'Return' AND SMLocation ='" + txtShopRef.Text + "'"
        Dim sdata As New SqlDataAdapter(Sesql, connection)
        Dim dtr As New DataSet
        '  Dim rdata As String
        '  rdata = SelectCommand.ExecuteNonQuery()
        sdata.Fill(dtr, "tblStockMovements")
        Dim dr As DataRow = dtr.Tables(0).Rows(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Error Getting Next Ref from the Database", MsgBoxStyle.Information, ProductName)
        Else
            lblTransRef.Text = dr("MaxRef") + 1
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
        txtReference.Text = Trim(txtShopRef.Text) + lblTransRef.Text
    End Function
    Private Sub DeleteRecord()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtReference.Text = FMain.DgvRecords.Item(1, i).Value
        '     DateTimePicker1.Value = Main.DataGridView1.Item(9, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where Reference = '" + txtReference.Text.ToString + "' AND MovementType = 'return'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        Dim DeleteCommand2 As New SqlCommand
        DeleteCommand2.Connection = connection
        DeleteCommand2.CommandType = CommandType.Text
        DeleteCommand2.CommandText = "DELETE from tblReturn where TFNote ='" + txtReference.Text.ToString + "'"
        DeleteCommand2.Connection.Close()
        DeleteCommand2.Connection.Open()
        DeleteCommand2.ExecuteNonQuery()
        DeleteCommand2.Connection.Close()
        FMain.ReturnsToolStripMenuItem.PerformClick() : Me.Close()
    End Sub

    Private Sub createReturnRecord()

        InsertCommand.Connection = connection
        InsertCommand.Connection.Close()
        InsertCommand.CommandText = "INSERT INTO tblReturn (TFNote,ReturnNo,ShopRef,ShopName,WarehouseRef,WarehouseName,StockCode,Qty,RMovementDate,CreatedBy,CreatedDate) VALUES(@TFNote,@ReturnNo,@ShopRef,@ShopName,@WarehouseRef,@WarehouseName,@StockCode,@Qty,@RMovementDate,@CreatedBy,@CreatedDate)"
        InsertCommand.Parameters.AddWithValue("@TFNote", txtReference.Text)
        InsertCommand.Parameters.AddWithValue("@ReturnNo", lblTransRef.Text)
        InsertCommand.Parameters.AddWithValue("@ShopRef", txtShopRef.Text)
        InsertCommand.Parameters.AddWithValue("@ShopName", txtShopName.Text)
        InsertCommand.Parameters.AddWithValue("@WarehouseRef", txtWarehouseRef.Text)
        InsertCommand.Parameters.AddWithValue("@WarehouseName", txtWarehouseName.Text)
        InsertCommand.Parameters.AddWithValue("@StockCode", txtStockCode.Text)
        InsertCommand.Parameters.AddWithValue("@Qty", CInt(txtTransferQty.Text))
        InsertCommand.Parameters.AddWithValue("@RMovementDate", DateTimePicker1.Value)
        InsertCommand.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text.ToString())
        InsertCommand.Parameters.AddWithValue("@CreatedDate", Date.Now)
        InsertCommand.Connection.Open()
        InsertCommand.ExecuteNonQuery()
        InsertCommand.Connection.Close()
    End Sub
End Class