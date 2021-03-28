Imports System.Data.SqlClient
Public Class FGridShops
    Dim ut As New CUtils

    Private Sub FGridShops_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim objform As New FShops()
        objform.CmdOK.Text = "ADD"
        objform.TxtShopRef.Select()
        objform.ShowDialog()
    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click
        Dim load As New CLoad
        Dim i As Integer
        Dim stock As String
        i = DataGridView1.CurrentRow.Index
        stock = DataGridView1.Item(0, i).Value.ToString()
        load.LoadShop(stock)
    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        Dim warning As DialogResult = MessageBox.Show("Are you sure you wish to delete a Shop Record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
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
                    .CommandText = "SELECT Count(*) as numRows from tblStockMovements WHERE SMLocation = @SMLocation"
                    .Parameters.AddWithValue("@SMLocation", stock)
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
                        .CommandText = "DELETE From tblShops WHERE ShopRef = @ShopRef"
                        .Parameters.AddWithValue("@ShopRef", stock)
                        .ExecuteNonQuery()
                    End With
                End Using
            Else
                MessageBox.Show("Unable to delete Shop code due to other record types with " + stock + " still in the database", "Unable To Delete")
                Exit Sub
            End If
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
        Dim print As New FReportViewer With {.ReportName = "PrintShopList"
        }
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
            ad.SelectCommand = New SqlCommand("SELECT ShopRef,ShopName,ShopType FROM tblShops", conn)
            ad.Fill(dt)
            BindingSource1.DataSource = dt
            DataGridView1.DataSource = BindingSource1
        End Using
        With DataGridView1.Columns
            .Item(0).HeaderText = "Shop Ref"
            .Item(1).HeaderText = "Shop Name"
            .Item(1).Width = 300
            .Item(2).HeaderText = "Shop Type"
            .Item(2).Width = 250
        End With
        TSSCount.Text = DataGridView1.Rows.Count.ToString()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        TsbRecord.PerformClick()
    End Sub
End Class