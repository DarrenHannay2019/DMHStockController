Imports System.Data.SqlClient
Public Class FWarehouses
    Dim save As New CSave
    Dim Upd As New CUpdate
    Dim ut As New CUtils
    Dim connstring As String = ut.GetConnString()
    Private Sub TxtWarehouseRef_Leave(sender As Object, e As EventArgs) Handles TxtWarehouseRef.Leave
        TxtWarehouseRef.Text = UCase(TxtWarehouseRef.Text)
    End Sub

    Private Sub TxtWarehouseName_Leave(sender As Object, e As EventArgs) Handles TxtWarehouseName.Leave
        TxtWarehouseName.Text = StrConv(TxtWarehouseName.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtContactName_Leave(sender As Object, e As EventArgs) Handles TxtContactName.Leave
        TxtContactName.Text = StrConv(TxtContactName.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress1_Leave(sender As Object, e As EventArgs) Handles TxtAddress1.Leave
        TxtAddress1.Text = StrConv(TxtAddress1.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress2_Leave(sender As Object, e As EventArgs) Handles TxtAddress2.Leave
        TxtAddress2.Text = StrConv(TxtAddress2.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress3_Leave(sender As Object, e As EventArgs) Handles TxtAddress3.Leave
        TxtAddress3.Text = StrConv(TxtAddress3.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress4_Leave(sender As Object, e As EventArgs) Handles TxtAddress4.Leave
        TxtAddress4.Text = StrConv(TxtAddress4.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtPostCode_Leave(sender As Object, e As EventArgs) Handles TxtPostCode.Leave
        TxtPostCode.Text = UCase(TxtPostCode.Text)
    End Sub

    Private Sub FWarehouses_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CmdOK.Text = "OK" Then LoadOld()
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from tblWarehouses WHERE WarehouseRef = '" + TxtWarehouseRef.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            ' Details Tab
            TxtWarehouseRef.Text = dt.Rows(0).Item("WarehouseRef").ToString
            TxtWarehouseName.Text = dt.Rows(0).Item("WarehouseName").ToString
            TxtContactName.Text = dt.Rows(0).Item("ContactName").ToString
            TxtAddress1.Text = dt.Rows(0).Item("Address1").ToString
            TxtAddress2.Text = dt.Rows(0).Item("Address2").ToString
            TxtAddress3.Text = dt.Rows(0).Item("Address3").ToString
            TxtAddress4.Text = dt.Rows(0).Item("Address4").ToString
            TxtPostCode.Text = dt.Rows(0).Item("PostCode").ToString
            TxtTelephone1.Text = dt.Rows(0).Item("Telephone").ToString
            TxtTelephone2.Text = dt.Rows(0).Item("Telephone2").ToString
            TxtFax.Text = dt.Rows(0).Item("Fax").ToString
            TxteMail.Text = dt.Rows(0).Item("eMail").ToString
            TxtMemo.Text = dt.Rows(0).Item("Memo").ToString
            cboWType.Text = dt.Rows(0).Item("WarehouseType").ToString
        End Using
        ' Transactions Tab Load
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode AS StockCode,SMSupplierRef AS Supplier,MovementType AS Type,[MovementQtyHangers] AS Qty,MovementDate as Date,MovementValue as Value From tblStockMovements WHERE SMLocation = '" + TxtWarehouseRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            With gridTrans
                .DataSource = dt
                .Columns.Item(5).DefaultCellStyle.Format = "C2"
                .Columns.Item(0).Width = 100
                .Columns.Item(1).Width = 75
                .Columns.Item(2).Width = 80
                .Columns.Item(3).Width = 40
                .Columns.Item(4).Width = 75
                .Columns.Item(5).Width = 75
            End With
        End Using
        ' Stock Tab Load
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim a As Integer
            Dim b As Decimal
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode,Qty,Value from qryWarehouseStock2 WHERE SMLocation = '" + TxtWarehouseRef.Text + "' AND Qty <> '0'", conn)}
            conn.Open()
            adp.Fill(dt)
            With gridStock
                .DataSource = dt
                .Columns.Item(2).DefaultCellStyle.Format = "C2"
                .Columns.Item(0).HeaderText = "Stock Code"
                .Columns.Item(1).Visible = True
                .Columns.Item(1).HeaderText = "Qty"
                .Columns.Item(2).HeaderText = "Value"
            End With
            For i As Integer = 0 To gridStock.Rows.Count - 1
                a += gridStock.Rows(i).Cells(1).Value
                b += gridStock.Rows(i).Cells(2).Value
            Next
            TxtTotalStock.Text = a.ToString()
            TxtTotalValue.Text = b.ToString()
            TxtTotalValue.Text = FormatCurrency(TxtTotalValue.Text)
        End Using

    End Sub
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        If CmdOK.Text = "OK" Then Upd.SaveWarehouse(TxtWarehouseRef.Text, TxtWarehouseName.Text, TxtAddress1.Text, TxtAddress2.Text, TxtAddress3.Text, TxtAddress4.Text, TxtPostCode.Text, TxtContactName.Text, TxtTelephone1.Text, TxtTelephone2.Text, TxtFax.Text, TxteMail.Text, TxtMemo.Text, cboWType.Text)
        If CmdOK.Text = "ADD" Then save.SaveWarehouse(TxtWarehouseRef.Text, TxtWarehouseName.Text, TxtAddress1.Text, TxtAddress2.Text, TxtAddress3.Text, TxtAddress4.Text, TxtPostCode.Text, TxtContactName.Text, TxtTelephone1.Text, TxtTelephone2.Text, TxtFax.Text, TxteMail.Text, TxtMemo.Text, cboWType.Text)
        FGridWarehouses.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        TxtWarehouseName.Clear()
        TxtWarehouseRef.Clear()
        TxtAddress1.Clear()
        TxtAddress2.Clear()
        TxtAddress3.Clear()
        TxtAddress4.Clear()
        TxtContactName.Clear()
        TxteMail.Clear()
        TxtFax.Clear()
        TxtMemo.Clear()
        TxtPostCode.Clear()
        TxtTelephone1.Clear()
        TxtTelephone2.Clear()
    End Sub
End Class