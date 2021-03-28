Imports System.Data
Imports System.Data.SqlClient

Public Class CLoad
    Dim ut As New CUtils()
    Dim connstring As String = ut.GetConnString()

    Public Sub LoadWarehouse(WarehouseRef As String)
        Dim objform As New FWarehouses
        With objform
            .TxtWarehouseRef.Text = WarehouseRef
            .TxtWarehouseRef.Enabled = False
            .CmdOK.Text = "OK"
            .CmdClear.Enabled = False
            .Show()
        End With
    End Sub
    Public Sub LoadSupplier(SupplierRef As String)
        Dim objform As New FSuppliers
        With objform
            .TxtSupplierRef.Text = SupplierRef
            .TxtSupplierRef.Enabled = False
            .CmdOK.Text = "OK"
            .CmdClear.Enabled = False
            .Show()
        End With
    End Sub
    Public Sub LoadStock(StockCode As String, SFunction As String)
        Dim objform As New FStock
        With objform
            .StockCodeTextBox.Enabled = False
            Using conn As New SqlConnection(connstring)
                Dim dt As New DataTable
                Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * from qryStockValuesPC1 WHERE StockCode = '" + StockCode + "'", conn)}
                conn.Open()
                adp.Fill(dt)
                .StockCodeTextBox.Text = dt.Rows(0).Item("StockCode")
                .SupplierRefTextBox.Text = dt.Rows(0).Item("SupplierRef")
                .DeadCodeCheckBox.Checked = dt.Rows(0).Item("DeadCode")
                .AmountTakenTextBox.Text = dt.Rows(0).Item("SalesAmount")
                .CostValueTextBox.Text = dt.Rows(0).Item("CostValue")
                .PCMarkUpTextBox.Text = dt.Rows(0).Item("PCMarkUp")
                .PCMarkUpTextBox.Text = FormatPercent(.PCMarkUpTextBox.Text)
                .AmountTakenTextBox.Text = FormatCurrency(.AmountTakenTextBox.Text)
                .CostValueTextBox.Text = FormatCurrency(.CostValueTextBox.Text)
                .sd = SFunction
            End Using
        End With
        objform.CmdOK.Text = "OK"
        objform.StockCodeTextBox.Enabled = False
        objform.Show()
    End Sub
    Public Sub LoadShop(shopref As String)
        Dim objform As New FShops()
        With objform
            .TxtShopRef.Enabled = False
            .CmdOK.Text = "OK"
            .TxtShopRef.Text = shopref
            .Show()
        End With
    End Sub
    Public Sub LoadPOrder(ID As Integer)
        Dim objForm As New FPOrders
        With objForm
            .txtOrderID.Enabled = False
            .cmdOK.Text = "OK"
            .txtOrderID.Text = ID.ToString
            .Show()
        End With
    End Sub
    Public Sub LoadShopAdjust(ID As Integer)
        Dim objform As New FShopAdjustments()
        With objform
            .TxtSID.Text = ID.ToString()
            .CmdOK.Text = "OK"
            .TxtSID.Enabled = False
            .CmdClear.Enabled = False
            .Text = "Shop Adjustment for [" + .txtWarehouseName.Text + "]"
            .Show()
        End With
    End Sub
    Public Sub LoadShopDelivery(ID As Integer)
        Dim objform As New FShopDelivery()
        With objform
            .txtDelNoteNumber.Text = ID.ToString()
            .txtDelNoteNumber.Enabled = False
            .cmdAdd.Text = "OK"
            .Show()
        End With
    End Sub

    Public Sub LoadShopSale(ID As Integer)
        Dim objform As New FShopSales
        With objform
            .txtSalesID.Text = ID.ToString()
            .cmdOK.Text = "OK"
            .txtSalesID.Enabled = False
            .Show()
        End With
    End Sub
    Public Sub LoadShopReturn(ID As Integer)
        Dim objform As New FShopReturns
        With objform
            .txtReturnID.Text = ID.ToString()
            .txtReturnID.Enabled = False
            .cmdOK.Text = "OK"
            .cmdClear.Enabled = False
            .Show()
        End With
    End Sub
    Public Sub LoadShopTrans(ID As Integer)
        Dim objform As New FShopTransfers
        With objform
            .TxtTransferID.Text = ID.ToString()
            .TxtTransferID.Enabled = False
            .CmdOK.Text = "OK"
            .CmdClear.Enabled = False
            .Show()
        End With

    End Sub

    Public Sub LoadWarehouseAdjust(ID As Integer)
        Dim objform As New FWarehouseAdjust
        With objform
            .TxtRecordID.Text = ID.ToString()
            .CmdOK.Text = "OK"
            .CmdClear.Enabled = False
            .Show()
        End With
    End Sub
    Public Sub LoadWarehouseReturn(ID As Integer)
        Dim objform As New FWarehouseReturns
        With objform

        End With

    End Sub
End Class
