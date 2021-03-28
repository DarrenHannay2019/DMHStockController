Imports System.Data.SqlClient
Imports StockMasterv4.CLoad
Public Class FGridMoveTypes
    Dim ut As New CUtils
    Private Sub LoadData()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT * from QryTotalDelivery Order by StockCode", conn)
            ad.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.AutoGenerateColumns = True
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
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "c"
            DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "c"
            DataGridView1.Columns.Item(7).DefaultCellStyle.Format = "p"
            DataGridView1.Columns.Item(3).Width = 50
            DataGridView1.RowHeadersWidth = 50
            Text = "Delivered And Sold"
            Dim pCMarkup As Decimal
            Dim SalesTotal As Decimal
            Dim CostTotal As Decimal
            Dim WarehouseTotal As Integer
            Dim ShopTotal As Integer
            Dim DeliveryTotal As Integer
            Dim SalesQty As Integer
            Dim gridrow As Integer = DataGridView1.Rows.Count
            Dim Head As String = "Totals -------->"
            For Each row As DataGridViewRow In DataGridView1.Rows
                DeliveryTotal += row.Cells(1).Value
                SalesQty += row.Cells(2).Value
                ShopTotal += row.Cells(3).Value
                WarehouseTotal += row.Cells(4).Value
                CostTotal += row.Cells(5).Value
                SalesTotal += row.Cells(6).Value
                pCMarkup += row.Cells(7).Value
            Next
            Dim myrow = dt.NewRow
            myrow(0) = Head
            myrow(1) = DeliveryTotal
            myrow(2) = SalesQty
            myrow(3) = ShopTotal
            myrow(4) = WarehouseTotal
            myrow(5) = CostTotal
            myrow(6) = SalesTotal
            myrow(7) = pCMarkup
            dt.Rows.Add(myrow)
        End Using
    End Sub

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub FGridMoveTypes_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub
    Private Sub LoadData2()

        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT StockCode,CostValue,SalesAmount,PCMarkup,Garments from qryStockvaluespc1 Where SupplierRef = 'VATO' Order by StockCode", conn)
            ad.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.AutoGenerateColumns = True
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
            DataGridView1.Columns.Item(1).DefaultCellStyle.Format = "c"
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "c"
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "p"
            DataGridView1.Columns.Item(0).Width = 150
            DataGridView1.RowHeadersWidth = 50
            Text = "Delivered And Sold"
            Dim pCMarkup As Decimal
            Dim CostTotal As Decimal
            Dim WarehouseTotal As Integer
            Dim SalesQty As Integer
            Dim gridrow As Integer = DataGridView1.Rows.Count
            Dim Head As String = "Totals -------->"
            For Each row As DataGridViewRow In DataGridView1.Rows
                CostTotal += row.Cells(1).Value
                SalesQty += row.Cells(2).Value
                pCMarkup += row.Cells(3).Value
                WarehouseTotal += row.Cells(4).Value
            Next
            Dim myrow = dt.NewRow
            myrow(0) = Head
            myrow(1) = CostTotal
            myrow(2) = SalesQty
            myrow(3) = pCMarkup
            myrow(4) = WarehouseTotal
            dt.Rows.Add(myrow)
        End Using
    End Sub

    Private Sub TSBSupplierPref_Click(sender As Object, e As EventArgs) Handles TSBSupplierPref.Click
        DataGridView1.DataSource = Nothing
        LoadData2()
    End Sub
End Class