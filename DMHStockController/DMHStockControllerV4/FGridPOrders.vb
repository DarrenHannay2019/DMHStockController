Imports System.Data.SqlClient
Public Class FGridPOrders
    Dim ut As New CUtils

    Private Sub TsbNew_Click(sender As Object, e As EventArgs) Handles TsbNew.Click
        Dim objform As New FPOrders
        objform.cmdOK.Text = "ADD"
        objform.DateTimePicker1.Select()
        objform.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim ID As Integer
        i = DataGridView1.CurrentRow.Index
        ID = DataGridView1.Item(0, i).Value
        load.LoadPOrder(ID)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete this Purchase Order", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            Dim I As Integer = DataGridView1.CurrentRow.Index
            Dim ID As Integer = DataGridView1.Item(0, I).Value
            Dim StockCode As String = DataGridView1.Item(3, I).Value.ToString()
            DeleteRecords(ID, StockCode, DataGridView1.Item(6, I).Value, StockCode)

        End If
        TsbRecord.PerformClick()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbPrint_Click(sender As Object, e As EventArgs) Handles TsbPrint.Click
        Dim print As New FReportViewer With {.ReportName = "PrintOrderList"
        }
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "StockCode Like '%" & InputBox("Please Enter a Stock code") & "%'"
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub

    Private Sub FGridPOrders_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridView1.BackgroundColor = Color.LightCoral
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Plum
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
        LoadData()
    End Sub
    Private Sub LoadData()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT dbo.tblDeliveries.DeliveriesId, dbo.tblSuppliers.SupplierName, dbo.qryAllLocationRefs.WarehouseName, dbo.tblDeliveries.StockCode, dbo.tblDeliveries.TotalGarments, dbo.tblDeliveries.TotalAmount, dbo.tblDeliveries.DeliveryDate FROM  dbo.tblDeliveries INNER JOIN                         dbo.tblSuppliers ON dbo.tblDeliveries.SupplierRef = dbo.tblSuppliers.SupplierRef INNER JOIN dbo.qryAllLocationRefs ON dbo.tblDeliveries.LocationRef = dbo.qryAllLocationRefs.WarehouseRef order by DeliveryDate desc", conn)
            ' ad.SelectCommand = New SqlCommand("SELECT TOP (114) dbo.tblDeliveries.DeliveriesId, dbo.tblSuppliers.SupplierName, dbo.qryAllLocations.WarehouseName, dbo.tblDeliveries.StockCode, dbo.tblDeliveries.TotalGarments, dbo.tblDeliveries.TotalAmount, dbo.tblDeliveries.DeliveryDate FROM  dbo.tblDeliveries INNER JOIN                         dbo.tblSuppliers ON dbo.tblDeliveries.SupplierRef = dbo.tblSuppliers.SupplierRef INNER JOIN dbo.qryAllLocations ON dbo.tblDeliveries.LocationRef = dbo.qryAllLocations.WarehouseRef Where tblDeliveries.LocationRef = 'UNI' order by DeliveriesID desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1
            .Columns.Item(0).DefaultCellStyle.Format = "000000"
            .Columns.Item(0).Width = 70
            .Columns.Item(0).HeaderText = "Record No"
            .Columns.Item(1).Width = 220
            .Columns.Item(1).HeaderText = "Supplier Name"
            .Columns.Item(2).Width = 220
            .Columns.Item(2).HeaderText = "Location Name"
            .Columns.Item(3).Width = 120
            .Columns.Item(3).HeaderText = "Stock Code"
            .Columns.Item(4).HeaderText = "Total Items"
            .Columns.Item(4).Width = 70
            .Columns.Item(5).HeaderText = "Total Cost"
            .Columns.Item(5).DefaultCellStyle.Format = "C2"
            .Columns.Item(6).HeaderText = "Delivery Date"
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub
    Private Function DeleteRecords(ID As Integer, stockcode As String, Dte As Date, tabe As String) As Boolean

        Using conn As New SqlConnection(ut.GetConnString())
            Dim checkCmd As New SqlCommand
            With checkCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM tblDeliveries WHERE DeliveriesID=@DeliveriesID;DELETE FROM tblStockmovements WHERE TransferReference=@TransferReference AND MovementDate = @MovementDate AND Reference=Reference"
                .Parameters.AddWithValue("@DeliveriesID", ID)
                .Parameters.AddWithValue("@TransferReference", ID)
                .Parameters.AddWithValue("@MovementDate", Dte)
                .Parameters.AddWithValue("@Reference", tabe)
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        TsbRecord.PerformClick()
    End Sub

    Private Sub TsbStockCheck_Click(sender As Object, e As EventArgs) Handles TsbStockCheck.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand(" Select SUM(dbo.tblStockMovements.MovementQtyHangers) As Expr1, dbo.tblStockMovements.SMLocation FROM            dbo.tblStock RIGHT OUTER JOIN     dbo.tblStockMovements ON dbo.tblStock.StockCode = dbo.tblStockMovements.SMStockCode WHERE        (dbo.tblStock.DeadCode = 0) GROUP BY dbo.tblStockMovements.SMLocation    HAVING        (dbo.tblStockMovements.SMLocation = N'uni') OR                (dbo.tblStockMovements.SMLocation = N'bo')", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
    End Sub

End Class