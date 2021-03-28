Imports System.Data.SqlClient
Imports StockMasterv4.CLoad
Public Class FGridSalesTotals
    Dim ut As New CUtils
    Private Sub FGridSalesTotals_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub
    Private Sub LoadData()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT TOP (100) PERCENT TransactionDate, SUM(TotalQty) AS Expr2, SUM(TotalValue) AS Expr3, COUNT(SalesId) AS Expr1 FROM dbo.tblSales GROUP BY TransactionDate ORDER BY TransactionDate DESC", conn)
            ad.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Columns.Item(0).HeaderText = "Sunday's Date"
            DataGridView1.Columns.Item(1).HeaderText = "Total Items"
            DataGridView1.Columns.Item(2).HeaderText = "Total Value"
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "C2"
            DataGridView1.Columns.Item(3).HeaderText = "No Records"
        End Using
    End Sub
End Class