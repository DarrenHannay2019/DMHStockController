Imports System.Data.SqlClient
Public Class FGridAllStock
    Dim ut As New CUtils
    Private Sub TsbNew_Click(sender As Object, e As EventArgs) Handles TsbNew.Click
        Dim newstock As New FStock
        newstock.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As String
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value.ToString()
        load.LoadStock(stock, "All")
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Stock Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim stock As String = DataGridView1.Item(0, i).Value.ToString()
            Dim result As Integer
            Using conn As New SqlConnection(ut.GetConnString())
                Dim Checkcmd As New SqlCommand()
                With Checkcmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT Count(*) as numRows from tblStockMovements WHERE SMStockCode = @SMStockCode"
                    .Parameters.AddWithValue("@SMStockCode", stock)
                    result = .ExecuteScalar
                End With
            End Using
            If result = 0 Then
                Using conn As New SqlConnection(ut.GetConnString())
                    Dim delCmd As New SqlCommand()
                    With delCmd
                        .Connection = conn
                        .Connection.Open()
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE From tblStock WHERE StockCode = @StockCode"
                        .Parameters.AddWithValue("@StockCode", stock)
                        .ExecuteNonQuery()
                    End With
                End Using
            Else
                MessageBox.Show("Unable to delete stock code due to other record types with " + stock + " still in the database", "Unable To Delete")
                Exit Sub
            End If
        End If
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        LoadData()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbPrint_Click(sender As Object, e As EventArgs) Handles TsbPrint.Click
        Dim print As New FReportViewer With {.Text = "Print All Stock"}
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "StockCode Like '%" & InputBox("Please Enter a Stock code") & "%'"
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub

    Private Sub FGridAllStock_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                ad.SelectCommand = New SqlCommand("SELECT StockCode,SupplierRef,DeadCode = case when DeadCode != 0 then 'Yes' else 'No' end,CostValue,SalesAmount,PCMarkUp,ZeroQty = case when ZeroQty != 0 then 'yes' else 'no' end,Garments from qryStockvaluespc1 order by StockCode", conn)
                ad.Fill(dt)
                BindingSource1.DataSource = dt
                DataGridView1.DataSource = BindingSource1
            End Using
            'StockCode
            DataGridView1.Columns.Item(0).Visible = True
            DataGridView1.Columns.Item(0).HeaderText = "Stock Code"
            DataGridView1.Columns.Item(0).Width = 120
            'SupplierRef
            DataGridView1.Columns.Item(1).Visible = True
            DataGridView1.Columns.Item(1).HeaderText = "Supplier Ref"
            DataGridView1.Columns.Item(1).Width = 120
            'Dead Code
            DataGridView1.Columns.Item(2).Visible = True
            DataGridView1.Columns.Item(2).HeaderText = "Dead Code"
            DataGridView1.Columns.Item(2).Width = 80
            DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "Yes/No"
            'AmountTaken
            DataGridView1.Columns.Item(4).Visible = True                        ' Displays the column to the user.
            DataGridView1.Columns.Item(4).HeaderText = "Amount Taken"           ' Gives the column a title from the default name
            DataGridView1.Columns.Item(4).Width = 150                            ' Sets the width of the column
            DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "c"         ' Sets the formatting of the column
            'CostValue
            DataGridView1.Columns.Item(3).Visible = True
            DataGridView1.Columns.Item(3).HeaderText = "Cost Value"
            DataGridView1.Columns.Item(3).Width = 150
            DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "c"
            'PCMarkUp
            DataGridView1.Columns.Item(5).HeaderText = "Markup"
            DataGridView1.Columns.Item(5).Width = 150
            DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "p"
            'ZeroQty
            DataGridView1.Columns.Item(6).Visible = False
            DataGridView1.Columns.Item(6).Width = 0
            'Stock.CreatedDate
            ToolStripStatusLabel1.Text = "Stock"
            TSSCount.Text = DataGridView1.Rows.Count
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("To run this on this computer please specifiy the value of this computer" & vbCr & "In Data Source on the connectionString.", Application.ProductName)
        End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        TsbRecord.PerformClick()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

    End Sub
End Class