Imports System.Data.SqlClient
Public Class FGridSHTransfers
    Dim ut As New CUtils
    Private Sub FGridSHTransfers_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        FShopTransfers.CmdOK.Text = "ADD"
        FShopTransfers.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As Integer
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value
        load.LoadShopTrans(stock)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Shop Transfer Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim stock As String = DataGridView1.Item(0, i).Value.ToString()

            Using conn As New SqlConnection(ut.GetConnString())
                Dim delCmd As New SqlCommand()
                With delCmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE From tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = @MovementType AND MovementDate = @MovementDate AND Reference = @Reference;DELETE FROM tblShopTransferLines WHERE TransferID = @TransferID;DELETE FROM tblShopTransfers WHERE TransferID = @TransferID"
                    With .Parameters
                        .AddWithValue("@TransferReference", stock)
                        .AddWithValue("@MovementType", "Shop Transfer")
                        .AddWithValue("@MovementDate", CDate(DataGridView1.Item(2, i).Value))
                        .AddWithValue("@Reference", DataGridView1.Item(1, i).Value.ToString())
                        .AddWithValue("@TransferID", stock)
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
        Dim print As New FReportViewer With {.Text = "Print Shop Transfers"}
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "ShopRef Like '%" & InputBox("Please Enter a From Shop code") & "%'"
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
            ad.SelectCommand = New SqlCommand("SELECT * FROM tblShopTransfers ORDER BY TransferDate desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Transfer ID"
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(2).HeaderText = "Transfer Date"
            .Item(3).Visible = False
            .Item(4).HeaderText = "From Shop Name"
            .Item(4).Width = 190
            .Item(5).Visible = False
            .Item(6).HeaderText = "To Shop Name"
            .Item(6).Width = 190
            .Item(8).HeaderText = "Qty Transfered"
            .Item(7).Visible = False
            .Item(9).Visible = False
            .Item(10).Visible = False
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        TsbRecord.PerformClick()
    End Sub
End Class