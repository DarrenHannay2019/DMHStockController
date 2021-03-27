Public Class FCriteria
    Dim dLastSunday As Date = Date.Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FCriteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = "1/2/2016"
        DateTimePicker2.Value = dLastSunday
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label3.Text = "SalesAnalysis" Then SalesAnalysisReport()
        If Label3.Text = "ShopDeliveries" Then ShopdeliveriesReports()
        If Label3.Text = "SalesHistory" Then SalesHistoryReport()
        If Label3.Text = "WarehouseStock" Then WarehouseStockListReport()
        If Label3.Text = "ShopStock1" Then StockListByShopReport()
        If Label3.Text = "ShopStock2" Then StockListByCodeReport()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub SalesAnalysisReport()
        ReportSalesAnalysis.Show()
    End Sub

    Private Sub SalesHistoryReport()
        reportSalesHistory.Show()
    End Sub

    Private Sub StockValueReport()
        '  ReportSalesAnalysis.Show()
    End Sub

    Private Sub WarehouseStockListReport()
        ReportWarehouseStock.Show()
    End Sub

    Private Sub StockListByShopReport()
        ReportStockList1.Show()
    End Sub

    Private Sub StockListByCodeReport()
        ReportStockList2.Show()
    End Sub

    Private Sub ShopdeliveriesReports()
        ReportShopDeliveries.Show()
    End Sub
End Class