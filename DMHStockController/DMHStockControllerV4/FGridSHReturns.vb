Imports System.Data.SqlClient
Public Class FGridSHReturns
    Dim ut As New CUtils
    Private Sub FGridSHReturns_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        FShopReturns.cmdOK.Text = "ADD"
        FShopReturns.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As Integer
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value
        load.LoadShopReturn(stock)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Shop Return Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim stock As Integer = DataGridView1.Item(0, i).Value.ToString()
            Using conn As New SqlConnection(ut.GetConnString())
                Dim delCmd As New SqlCommand()
                With delCmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE From tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = @MovementType AND MovementDate = @MovementDate AND Reference = @Reference;DELETE FROM tblReturnLines WHERE ReturnID = @ReturnID;DELETE FROM tblReturns WHERE ReturnsID = @ReturnsID"
                    With .Parameters
                        .AddWithValue("@TransferReference", stock)
                        .AddWithValue("@MovementType", "Return")
                        .AddWithValue("@MovementDate", CDate(DataGridView1.Item(5, i).Value))
                        .AddWithValue("@Reference", DataGridView1.Item(1, i).Value.ToString())
                        .AddWithValue("@ReturnID", stock)
                        .AddWithValue("@ReturnsID", stock)
                    End With
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
        Dim print As New FReportViewer With {.Text = "Print Shop Returns"}
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "StockCode Like '%" & InputBox("Please Enter a Stock code") & "%'"
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
            ad.SelectCommand = New SqlCommand("SELECT * from qryReturn order by TransactionDate desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Return ID"
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).HeaderText = "Reference"
            .Item(2).HeaderText = "Shop Name"
            .Item(2).Width = 140
            .Item(3).HeaderText = "Warehouse Name"
            .Item(3).Width = 140
            .Item(4).HeaderText = "Total Items"
            .Item(5).HeaderText = "Transaction Date"
            .Item(6).Visible = False
            .Item(7).Visible = False
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
            ad.SelectCommand = New SqlCommand("SELECT TransferReference,FromShop,ToWarehouse,SMStockCode,MovementQtyHangers,Reference,MovementDate from qryReturns order by MovementDate desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Return ID"
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).HeaderText = "Shop Name"
            .Item(1).Width = 200
            .Item(2).HeaderText = "Shop Name"
            .Item(2).Width = 200
            .Item(3).HeaderText = "Stock Code"
            .Item(3).Width = 240
            .Item(4).HeaderText = "Qty"
            .Item(4).Width = 80
            .Item(5).Width = 200
            .Item(6).HeaderText = "Transaction Date"
            '.Item(6).Visible = False
            '.Item(7).Visible = False
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub
End Class