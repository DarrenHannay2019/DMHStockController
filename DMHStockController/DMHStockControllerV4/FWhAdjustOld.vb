Imports System.Data.SqlClient
Public Class FWhAdjustOld
    Dim ut As New CUtils

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updatecmd As New SqlCommand
            With updatecmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblStockMovements SET MovementType = @MovementType, MovementQtyHangers = @MovementQtyHangers,MovementDate = @MovementDate,Reference = @Reference Where StockMovementID = @StockMovementID"
                .Parameters.AddWithValue("@StockmovementID", Label1.Text.TrimEnd())
                .Parameters.AddWithValue("@MovementType", CboMovementType.Text.TrimEnd())
                If CboMovementType.Text = "Loss" Or CboMovementType.Text = "Stock Loss" Then .Parameters.AddWithValue("@MovementQtyHangers", CInt(TxtQty.Text.TrimEnd() * -1))
                If CboMovementType.Text = "Gain" Or CboMovementType.Text = "Stock Gain" Then .Parameters.AddWithValue("@MovementQtyHangers", CInt(TxtQty.Text.TrimEnd()))
                .Parameters.AddWithValue("@MovementDate", CDate(DtpDate.Value))
                .Parameters.AddWithValue("@Reference", TxtReference.Text.TrimEnd())
                .ExecuteNonQuery()
                .Connection.Close()
            End With
        End Using
        FGridWHAdjust.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FWhAdjustOld_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim i As Integer = FGridWHAdjust.DataGridView1.CurrentRow.Index
        Label1.Text = FGridWHAdjust.DataGridView1.Item(0, i).Value
        TxtReference.Text = FGridWHAdjust.DataGridView1.Item(1, i).Value
        TxtLocationID.Text = FGridWHAdjust.DataGridView1.Item(2, i).Value
        TxtLocationName.Text = FGridWHAdjust.DataGridView1.Item(3, i).Value
        TxtLocationType.Text = FGridWHAdjust.DataGridView1.Item(5, i).Value
        TxtStockCode.Text = FGridWHAdjust.DataGridView1.Item(4, i).Value
        TxtQty.Text = FGridWHAdjust.DataGridView1.Item(6, i).Value
        DtpDate.Text = FGridWHAdjust.DataGridView1.Item(7, i).Value
        CboMovementType.Text = FGridWHAdjust.DataGridView1.Item(8, i).Value
        Label1.Visible = False
        TxtLocationType.Enabled = False
    End Sub
End Class