Imports System.Data.SqlClient
Public Class FGridWHAdjust
    Dim ut As New CUtils
    Private Sub FGridWHAdjust_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim objform As New FWarehouseAdjust
        objform.CmdOK.Text = "ADD"
        objform.DateTimePicker1.Value = ut.GetSundaysDate(Now)
        objform.Show()

    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        If ToolStripStatusLabel1.Text = "Warehouse Adjustments" Then
            Dim load As New CLoad
            Dim i As Integer
            Dim stock As Integer
            i = DataGridView1.CurrentRow.Index
            stock = DataGridView1.Item(0, i).Value
            load.LoadWarehouseAdjust(stock)
        Else
            FWhAdjustOld.Show()
        End If
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Warehouse Adjustments Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            If ToolStripStatusLabel1.Text = "Warehouse Adjustments" Then
                Dim i As Integer = DataGridView1.CurrentRow.Index
                Dim ID As Integer = DataGridView1.Item(0, i).Value.ToString()
                Using conn As New SqlConnection(ut.GetConnString())
                    Dim delCmd As New SqlCommand()
                    With delCmd
                        .Connection = conn
                        .Connection.Open()
                        .CommandType = CommandType.Text
                        .CommandText = "DELETE from tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = 'Stock Loss' AND MovementDate = @MovementDate;DELETE from tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = 'Stock Gain' AND MovementDate = @MovementDate;DELETE from tblWarehouseAdjustmentsLines WHERE WarehouseAdjustID = @WarehouseAdjustID;DELETE from tblWarehouseAdjustments where ID = @ID;"
                        .Parameters.AddWithValue("@TransferReference", ID)
                        .Parameters.AddWithValue("@MovementDate", DataGridView1.Item(5, i).Value)
                        .Parameters.AddWithValue("@WarehouseAdjustID", ID)
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
        Dim print As New FReportViewer With {.Text = "Print All Warehouse Adjustments"}
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "[Warehouse Ref] Like '%" & InputBox("Please Enter a Warehouse code") & "%'"
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
            ad.SelectCommand = New SqlCommand("SELECT dbo.tblWarehouseAdjustments.ID AS [WH Adjust ID], dbo.tblWarehouseAdjustments.WarehouseRef AS [Warehouse Ref], dbo.tblWarehouses.WarehouseName AS [Warehouse Name], dbo.tblWarehouseAdjustments.Reference, SUM(dbo.tblWarehouseAdjustments.TotalLossItems + dbo.tblWarehouseAdjustments.TotalGainItems) AS [Total Items], dbo.tblWarehouseAdjustments.MovementDate AS [Movement Date] FROM            dbo.tblWarehouseAdjustments INNER JOIN dbo.tblWarehouses ON dbo.tblWarehouseAdjustments.WarehouseRef = dbo.tblWarehouses.WarehouseRef GROUP BY dbo.tblWarehouseAdjustments.ID, dbo.tblWarehouseAdjustments.WarehouseRef, dbo.tblWarehouses.WarehouseName, dbo.tblWarehouseAdjustments.Reference, dbo.tblWarehouseAdjustments.MovementDate order by [Movement Date] desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).Visible = False
            .Item(2).Width = 240
        End With
        ToolStripStatusLabel1.Text = "Warehouse Adjustments"
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
            ad.SelectCommand = New SqlCommand("SELECT * from qryWarehouseAdjustments order by MovementDate desc", conn)
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
            .Item(3).HeaderText = "Warehouse Name"
            .Item(3).Width = 200
            .Item(4).HeaderText = "Stock Code"
            .Item(4).Width = 140
            .Item(5).Visible = False
            .Item(6).HeaderText = "Qty"
            .Item(6).Width = 50
            .Item(7).HeaderText = "Transaction Date"
            .Item(8).Width = 150
            .Item(8).HeaderText = "Movement Type"
            '.Item(6).Visible = False
            '.Item(7).Visible = False
        End With
        ToolStripStatusLabel1.Text = "Old Warehouse Adjustments"
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub TsbStockCount_Click(sender As Object, e As EventArgs) Handles TsbStockCount.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ad As New SqlDataAdapter
            Dim dt As New DataTable
            conn.Open()
            ad.SelectCommand = New SqlCommand("SELECT SMLocation, SUM(QtyHangers) AS Garments, WarehouseName FROM dbo.qryWarehouseStock GROUP BY SMLocation, WarehouseName", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        '  With DataGridView1.Columns
        '  .Item(0).DefaultCellStyle.Format = "000000"
        ' .Item(1).Visible = False
        '  .Item(2).Width = 240
        '  End With
        ToolStripStatusLabel1.Text = "Warehouse Adjustments"
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

End Class