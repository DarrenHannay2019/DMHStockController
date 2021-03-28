Imports System.Data.SqlClient
Public Class FGridShopSales
    Dim ut As New CUtils

    Private Sub FGridShopSales_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Sub TsbNew_Click(sender As Object, e As EventArgs) Handles TsbNew.Click
        FShopSales.cmdOK.Text = "ADD"
        FShopSales.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As Integer
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value
        load.LoadShopSale(stock)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Shop Sales Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim ID As Integer = DataGridView1.Item(0, i).Value.ToString()
            Using conn As New SqlConnection(ut.GetConnString())
                Dim delCmd As New SqlCommand()
                With delCmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE From tblStockMovements where TransferReference = @TransferReference AND MovementType = 'Sale' AND MovementDate = @MovementDate AND SMLocation = @SMLocation;DELETE from tblSalesLines WHERE SalesID = @SalesID;DELETE from tblSales WHERE SalesID =@SalesID;"
                    .Parameters.AddWithValue("@TransferReference", ID)
                    .Parameters.AddWithValue("@MovementDate", CDate(DataGridView1.Item(4, i).Value))
                    .Parameters.AddWithValue("@SMLocation", DataGridView1.Item(1, i).Value.ToString())
                    .Parameters.AddWithValue("@SalesID", ID)
                    .ExecuteNonQuery()
                End With
            End Using
        End If
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbPrint_Click(sender As Object, e As EventArgs) Handles TsbPrint.Click
        Dim print As New FReportViewer With {.Text = "Print Shop Sales"}
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "ShopRef Like '%" & InputBox("Please Enter a Shop code") & "%'"
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub
    Private Sub LoadData()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT * From qrySales order by TransactionDate desc,ShopName", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Sales ID"
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).Visible = False
            .Item(2).HeaderText = "Shop Name"
            .Item(2).Width = 200
            .Item(3).Visible = False
            .Item(4).HeaderText = "Sales Date"
            .Item(5).HeaderText = "Total Sold"
            .Item(6).HeaderText = "Total Amount"
            .Item(6).DefaultCellStyle.Format = "C2"
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        TsbRecord.PerformClick()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT TOP (100) PERCENT TransactionDate, SUM(TotalQty) AS Expr2, SUM(TotalValue) AS Expr3, COUNT(SalesId) AS Expr1 FROM dbo.tblSales GROUP BY TransactionDate ORDER BY TransactionDate DESC", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
            DataGridView1.Columns.Item(0).HeaderText = "Sunday's Date"
            DataGridView1.Columns.Item(1).HeaderText = "Total Items"
            DataGridView1.Columns.Item(2).HeaderText = "Total Value"
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "C2"
            DataGridView1.Columns.Item(3).HeaderText = "No Records"
        End Using
    End Sub
End Class