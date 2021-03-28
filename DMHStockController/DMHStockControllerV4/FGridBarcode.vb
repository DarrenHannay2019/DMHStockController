Imports System.Data.SqlClient
Public Class FGridBarcode
    Dim ut As New CUtils
    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "BarcodeNumber Like '%" & InputBox("Please Enter a Barcode Number") & "%'"
    End Sub

    Private Sub TsbNew_Click(sender As Object, e As EventArgs) Handles TsbNew.Click
        Dim barcodeform As New FBarcodeEntry
        barcodeform.Show()
    End Sub

    Private Sub FGridBarcode_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Try
            Using conn As New SqlConnection(ut.GetConnString())
                Dim ad As New SqlDataAdapter
                Dim dt As New DataTable
                conn.Open()
                ad.SelectCommand = New SqlCommand("SELECT * from tblBarcodes order by StockCode", conn)
                ad.Fill(dt)
                BindingSource1.DataSource = dt
                DataGridView1.DataSource = BindingSource1
            End Using
            'StockCode
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(1).Width = 120
            'SupplierRef
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Barcode Number"
            DataGridView1.Columns.Item(0).Width = 120
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Location Name"
            DataGridView1.Columns.Item(2).Width = 80


        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub
End Class