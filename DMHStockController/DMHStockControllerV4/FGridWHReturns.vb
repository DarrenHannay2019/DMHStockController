Imports System.Data.SqlClient
Public Class FGridWHReturns
    Dim ut As New CUtils
    Private Sub FGridWHReturns_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim objform As New FWarehouseReturns
        objform.cmdOK.Text = "ADD"
        objform.Show()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As Integer
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value
        load.LoadWarehouseReturn(stock)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Warehouse Return Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
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
                    .CommandText = "DELETE From tblStockMovements WHERE TransferReference = @TransferReference AND MovementType = @MovementType AND MovementDate = @MovementDate AND Reference = @Reference;DELETE FROM tblWReturnLines WHERE ReturnID = @ReturnID;DELETE FROM tblWReturns WHERE ReturnsID = @ReturnsID"
                    With .Parameters
                        .AddWithValue("@TransferReference", stock)
                        .AddWithValue("@MovementType", "WReturn")
                        .AddWithValue("@MovementDate", CDate(DataGridView1.Item(7, i).Value))
                        .AddWithValue("@Reference", DataGridView1.Item(5, i).Value.ToString())
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
        Dim print As New FReportViewer With {.Text = "Print All Stock"}
        print.Show()
    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click
        BindingSource1.Filter = "FWarehouseRef Like '%" & InputBox("Please Enter a Warehouse code") & "%'"
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
            ad.SelectCommand = New SqlCommand("SELECT * FROM qryWarehouseReturns", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Warehouse Return ID"
            .Item(0).DefaultCellStyle.Format = "000000"
            .Item(1).Visible = False
            .Item(3).Visible = False
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub
End Class