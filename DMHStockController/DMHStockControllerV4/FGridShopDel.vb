Imports System.Data.SqlClient
Public Class FGridShopDel
    Dim ut As New CUtils
    Private Sub FGridShopDel_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        FShopDelivery.cmdAdd.Text = "ADD"
        FShopDelivery.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As Integer
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value
        load.LoadShopDelivery(stock)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Shop Delivery Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If warning = DialogResult.No Then Exit Sub
        If warning = DialogResult.Yes Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            Dim ID As Integer = DataGridView1.Item(0, i).Value
            Using conn As New SqlConnection(ut.GetConnString())
                Dim delCmd As New SqlCommand
                With delCmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE from tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = 'Delivery (S)' AND MovementDate = @MovementDate;DELETE from tblShopDeliveriesLines WHERE SDeliveriesID = @SDeliveriesID;DELETE from tblShopDeliveries where DeliveriesID = @DeliveriesID;"
                    .Parameters.AddWithValue("@TransferReference", ID)
                    .Parameters.AddWithValue("@MovementDate", DataGridView1.Item(7, i).Value)
                    .Parameters.AddWithValue("@SDeliveriesID", ID)
                    .Parameters.AddWithValue("@DeliveriesID", ID)
                    .ExecuteNonQuery()
                End With
            End Using
        End If
        TsbRefresh.PerformClick()
    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click
        BindingSource1.DataSource = Nothing
        BindingSource1.Filter = Nothing
        LoadData()
    End Sub

    Private Sub TsbPrint_Click(sender As Object, e As EventArgs) Handles TsbPrint.Click
        Dim print As New FReportViewer With {.ReportName = "PrintShopDelList"}
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
            ad.SelectCommand = New SqlCommand("SELECT * FROM qryGridShopDelDisplay Order by DeliveryDate desc", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).Visible = False
            .Item(0).HeaderText = "Delivery No"
            .Item(2).Width = 200
            .Item(2).HeaderText = "Shop Name"
            .Item(3).Visible = False
            .Item(4).HeaderText = "Warehouse Name"
            .Item(4).Width = 200
            .Item(5).HeaderText = "Delivery Notes"
            .Item(6).Width = 100
            .Item(6).HeaderText = "Delivery Qty"
            .Item(7).HeaderText = "Delivery Date"
            .Item(8).Visible = False
            .Item(9).Visible = False
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        TsbRecord.PerformClick()
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