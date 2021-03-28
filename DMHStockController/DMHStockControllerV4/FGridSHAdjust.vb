Imports System.Data.SqlClient
Public Class FGridSHAdjust
    Dim ut As New CUtils
    Private Sub FGridSHAdjust_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim objform As New FShopAdjustments
        objform.CmdOK.Text = "ADD"
        objform.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        If ToolStripStatusLabel1.Text = "Shop Adjustments" Then
            Dim load As New CLoad
            Dim i As Integer
            Dim stock As Integer
            i = DataGridView1.CurrentRow.Index
            stock = DataGridView1.Item(0, i).Value
            load.LoadShopAdjust(stock)
        Else
            FShAdjustOld.Show()
        End If
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Shop Adjustment Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            If ToolStripStatusLabel1.Text = "Shop Adjustments" Then
                Dim i As Integer = DataGridView1.CurrentRow.Index
                Dim ID As Integer = DataGridView1.Item(0, i).Value
                Using conn As New SqlConnection(ut.GetConnString())
                    Dim delCmd As New SqlCommand
                    With delCmd
                        .Connection = conn
                        .Connection.Open()
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE from tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = 'Stock Loss' AND MovementDate = @MovementDate;DELETE from tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = 'Stock Gain' AND MovementDate = @MovementDate;DELETE from tblShopAdjustmentsLines WHERE ShopAdjustID = @ShopAdjustID;DELETE from tblShopAdjustments where ID = @ID;"
                        .Parameters.AddWithValue("@TransferReference", ID)
                        .Parameters.AddWithValue("@MovementDate", DataGridView1.Item(5, i).Value)
                        .Parameters.AddWithValue("@ShopAdjustID", ID)
                        .Parameters.AddWithValue("@ID", ID)
                        .ExecuteNonQuery()
                    End With
                End Using
            Else
                Dim i As Integer = DataGridView1.CurrentRow.Index
                Dim ID As Integer = DataGridView1.Item(0, i).Value.ToString()
                Using conn As New SqlConnection(ut.GetConnString())
                    Dim delCmd As New SqlCommand()
                    With delCmd
                        .Connection = conn
                        .Connection.Open()
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE from tblStockMovements WHERE StockMovementID = @StockMovementID;"
                        .Parameters.AddWithValue("@StockMovementID", ID)

                        .ExecuteNonQuery()
                    End With
                End Using
            End If
        End If
            TsbRefresh.PerformClick()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbPrint_Click(sender As Object, e As EventArgs) Handles TsbPrint.Click
        Dim print As New FReportViewer With {.ReportName = "PrintShopAdjustments"}
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
            ad.SelectCommand = New SqlCommand("SELECT dbo.tblShopAdjustments.ID, dbo.tblShopAdjustments.ShopRef, dbo.tblShops.ShopName, dbo.tblShopAdjustments.Reference, SUM(dbo.tblShopAdjustments.TotalLossItems + dbo.tblShopAdjustments.TotalGainItems) AS Expr1, dbo.tblShopAdjustments.MovementDate FROM dbo.tblShopAdjustments INNER JOIN dbo.tblShops ON dbo.tblShopAdjustments.ShopRef = dbo.tblShops.ShopRef GROUP BY dbo.tblShopAdjustments.ID, dbo.tblShopAdjustments.ShopRef, dbo.tblShops.ShopName, dbo.tblShopAdjustments.Reference, dbo.tblShopAdjustments.TotalLossItems, dbo.tblShopAdjustments.TotalGainItems,                          dbo.tblShopAdjustments.MovementDate order by MovementDate desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1
            ' DeliveryID = 0 
            .Columns.Item(0).HeaderText = "SH Adjust ID"
            .Columns.Item(0).DefaultCellStyle.Format = "00000"
            .Columns.Item(1).Visible = False ' ShopRef = 1
            .Columns.Item(2).HeaderText = "Shop Name" ' ShopName = 2
            .Columns.Item(2).Width = 190
            .Columns.Item(3).HeaderText = "Reference" ' Reference = 3
            .Columns.Item(3).Width = 190
            .Columns.Item(4).HeaderText = "Total Items" ' TotalLossItems =4
            ' .Columns.Item(5).HeaderText = "Total Gain Items" ' TotalGainItems=5
            .Columns.Item(5).HeaderText = "Movement Date" ' MovementDate=6
        End With
        ToolStripStatusLabel1.Text = "Shop Adjustments"
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
            ad.SelectCommand = New SqlCommand("SELECT * from qryShopAdjustments order by MovementDate desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Adjust ID"
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).HeaderText = "Reference"
            .Item(1).Width = 140
            .Item(2).Visible = False
            .Item(3).Visible = False
            .Item(4).HeaderText = "Shop Name"
            .Item(4).Width = 200
            .Item(5).HeaderText = "Stock Code"
            .Item(5).Width = 140
            '.Item(5).Visible = False
            .Item(6).HeaderText = "Qty"
            .Item(6).Width = 50
            .Item(7).HeaderText = "Transaction Date"
            .Item(8).Width = 150
            .Item(8).HeaderText = "Movement Type"
            '.Item(6).Visible = False
            '.Item(7).Visible = False
        End With
        ToolStripStatusLabel1.Text = "Old Shop Adjustments"
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub TsbStockCheck_Click(sender As Object, e As EventArgs) Handles TsbStockCheck.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("  Select 'Shops' AS LocationType, SUM(Qty) AS Garments From qryShopStock", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using



    End Sub
End Class