Imports System.Data.SqlClient

Public Class FShAdjustOld
    Dim ut As New CUtils()

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updatecmd As New SqlCommand
            With updatecmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblStockMovements SET SMLocation = @SMLocation, MovementType = @MovementType, MovementQtyHangers = @MovementQtyHangers,MovementDate = @MovementDate,Reference = @Reference Where StockMovementID = @StockMovementID"
                .Parameters.AddWithValue("@StockmovementID", Label1.Text.TrimEnd())
                .Parameters.AddWithValue("@SMLocation", TxtLocationID.Text.TrimEnd())
                .Parameters.AddWithValue("@MovementType", CboMovementType.Text.TrimEnd())
                If CboMovementType.Text = "Loss" Or CboMovementType.Text = "Stock Loss" Then .Parameters.AddWithValue("@MovementQtyHangers", CInt(TxtQty.Text.TrimEnd() * -1))
                If CboMovementType.Text = "Gain" Or CboMovementType.Text = "Stock Gain" Then .Parameters.AddWithValue("@MovementQtyHangers", CInt(TxtQty.Text.TrimEnd()))
                .Parameters.AddWithValue("@MovementDate", CDate(DtpDate.Value))
                .Parameters.AddWithValue("@Reference", TxtReference.Text.TrimEnd())
                .ExecuteNonQuery()
                .Connection.Close()
            End With
        End Using
        FGridSHAdjust.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FShAdjustOld_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim i As Integer = FGridSHAdjust.DataGridView1.CurrentRow.Index
        Label1.Text = FGridSHAdjust.DataGridView1.Item(0, i).Value
        TxtReference.Text = FGridSHAdjust.DataGridView1.Item(1, i).Value
        TxtLocationID.Text = FGridSHAdjust.DataGridView1.Item(2, i).Value
        TxtLocationName.Text = FGridSHAdjust.DataGridView1.Item(4, i).Value
        TxtLocationType.Text = FGridSHAdjust.DataGridView1.Item(3, i).Value
        TxtStockCode.Text = FGridSHAdjust.DataGridView1.Item(5, i).Value
        TxtQty.Text = FGridSHAdjust.DataGridView1.Item(6, i).Value
        DtpDate.Text = FGridSHAdjust.DataGridView1.Item(7, i).Value
        CboMovementType.Text = FGridSHAdjust.DataGridView1.Item(8, i).Value
        Label1.Visible = False
        TxtLocationType.Enabled = False
        TxtStockCode.Enabled = False
    End Sub

    Private Sub TxtLocationID_Leave(sender As Object, e As EventArgs) Handles TxtLocationID.Leave
        TxtLocationID.Text = UCase(TxtLocationID.Text)
        Dim ShopResult As String
        Using conn As New SqlConnection(ut.GetConnString())
            Dim SelCmd As New SqlCommand
            With SelCmd
                .Connection = conn
                .Connection.Open()
                .CommandText = "SELECT ShopName FROM tblShops WHERE ShopRef = @ShopRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ShopRef", TxtLocationID.Text)
                ShopResult = .ExecuteScalar
            End With
        End Using
        If ShopResult = "" Then
            MessageBox.Show("Please enter a valid Shop Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtLocationID.Select()
        Else
            Me.Text = "Shop Adjustments for: [" + TxtLocationName.Text + "] " + ShopResult
            TxtLocationName.Text = ShopResult
            TxtStockCode.Select()
        End If
    End Sub
End Class