Imports System.Data.SqlClient
Public Class FReportCriteria
    Dim ut As New CUtils
    Dim Rep As New CReports
    Private Sub FReportCriteria_Load(sender As Object, e As EventArgs) Handles Me.Load
        DateTimePicker1.Value = "01/01/2003"
        Label3.Visible = True
        DateTimePicker2.Value = ut.GetSundaysDate(Date.Now)
        LoadShops(ComboBox1, "Order By ShopName")
        LoadShops(ComboBox3, "Order By ShopName desc")
        LoadStock(ComboBox2, "Order By StockCode")
        LoadStock(ComboBox4, "Order By StockCode desc")
        If Label3.Text = "SalesAnalysis" Then LoadSalesAnalysisReport()
        If Label3.Text = "ShopDel" Then LoadShopDeliveriesReports()
        If Label3.Text = "SalesHistory" Then LoadSalesHistoryReport()
        If Label3.Text = "WarehouseStock" Then LoadWarehouseStockListReport()
        If Label3.Text = "StockList2" Then LoadStocklistreport()
        If Label3.Text = "StockList1" Then LoadStockListByShopReport()
        If Label3.Text = "AllStock" Then LoadStockListByCodeReport()
        If Label3.Text = "TotalValue" Then LoadTotalValueReport()
        If Label3.Text = "Bore" Then LoadBorehamwood()
    End Sub
    Private Sub LoadBorehamwood()
        Me.Text = "Borehamwood Stock Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
    End Sub
    Private Sub LoadTotalValueReport()
        Me.Text = "Total Value Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
    End Sub
    Private Sub LoadStocklistreport()
        DateTimePicker1.Enabled = False
        Me.Text = "Stock List By Stock Code Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
    End Sub
    Private Sub LoadSalesAnalysisReport()
        Me.Text = "Sales Analysis Report"
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
        DateTimePicker2.Value = ut.GetNextSundaysDate(Now)
    End Sub
    Private Sub LoadShopDeliveriesReports()
        Me.Text = "Shop Deliveries Report"
        DateTimePicker1.Enabled = False
    End Sub
    Private Sub LoadSalesHistoryReport()
        Me.Text = "Sales History Report"
        DateTimePicker1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
    End Sub
    Private Sub LoadWarehouseStockListReport()
        Me.Text = "Warehouse Stock List Report"
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
    End Sub
    Private Sub LoadStockListByShopReport()
        Me.Text = "Stock List By Shop"
        ComboBox2.Enabled = False
        ComboBox4.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub
    Private Sub LoadStockListByCodeReport()
        Me.Text = "All Stock Report"
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub
    Private Function LoadShops(WhichComboBox As ComboBox, orderby As String)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adp As New SqlDataAdapter
            Dim ds As New DataSet
            conn.Open()
            adp.SelectCommand = New SqlCommand("Select ShopName From tblShops " + orderby, conn)
            adp.Fill(ds)
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString())
            Next
            WhichComboBox.DataSource = ACSC
        End Using
        Return True
    End Function
    Private Function LoadStock(WhichCbo As ComboBox, orderby As String)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adp As New SqlDataAdapter
            Dim ds As New DataSet
            conn.Open()
            adp.SelectCommand = New SqlCommand("Select StockCode From tblStock WHERE DeadCode = '0' " + orderby, conn)
            adp.Fill(ds)
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                ACSC.Add(ds.Tables(0).Rows(i).Item(0).ToString())
            Next
            WhichCbo.DataSource = ACSC
        End Using
        Return True
    End Function
    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub
    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click
        CmdGenerate.Enabled = True
        If Label3.Text = "AllStock" Then LoadAllStock()
        If Label3.Text = "ShopDel" Then ShopDeliveries()
        If Label3.Text = "Bore" Then Borehamwood()
        If Label3.Text = "StockList1" Then LoadStockListByShop()
        If Label3.Text = "StockList2" Then LoadStockListByCode()
        If Label3.Text = "Warehouse" Then LoadWarehouseStock()
        If Label3.Text = "TotalValue" Then LoadTotalValuation()
        If Label3.Text = "SalesHistory" Then LoadSalesHistory()
        If Label3.Text = "SalesAnalysis" Then LoadSalesAnalysis()
    End Sub
    Private Sub CmdGenerate_Click(sender As Object, e As EventArgs) Handles CmdGenerate.Click
        Rep.DeleteOldData()
        Rep.CreateTempMovements(DateTimePicker1.Value, DateTimePicker2.Value)
        Rep.SalesThisWeekGen(DateTimePicker1.Text, DateTimePicker2.Text)
        Rep.UpdateStockReport()
        CmdGenerate.Enabled = False
    End Sub
    Private Sub LoadAllStock()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "AllStock"
            .StartStock = ComboBox2.Text
            .EndStock = ComboBox4.Text
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .Show()
        End With
    End Sub
    Private Sub ShopDeliveries()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "ShopDel"
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .StartStock = ComboBox2.Text
            .EndStock = ComboBox4.Text
            .Show()
        End With
    End Sub
    Private Sub Borehamwood()
        Dim viewer As New FReportViewer

        viewer.ReportName = "Bore"
        viewer.DateFrom = DateTimePicker1.Value
        viewer.DateTo = DateTimePicker2.Value
        viewer.StartShop = "Borehamwood"
        viewer.Show()
    End Sub
    Private Sub LoadStockListByShop()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "StockList1"
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .StartShop = ComboBox1.Text
            .EndShop = ComboBox3.Text
            .Show()
        End With
    End Sub
    Private Sub LoadStockListByCode()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "StockList2"
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .StartStock = ComboBox2.Text
            .EndStock = ComboBox4.Text
            .Show()
        End With
    End Sub
    Private Sub LoadWarehouseStock()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "Warehouse"
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .Show()
        End With
    End Sub
    Private Sub LoadTotalValuation()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "TotalStockValuation"
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .Show()
        End With
    End Sub
    Private Sub LoadSalesHistory()
        Dim viewer As New FReportViewer
        With viewer
            .ReportName = "SalesH"
            .DateFrom = DateTimePicker1.Value
            .DateTo = DateTimePicker2.Value
            .StartStock = ComboBox2.Text
            .EndStock = ComboBox4.Text
            .StartShop = ComboBox1.Text
            .EndShop = ComboBox3.Text
            viewer.Show()
        End With

    End Sub
    Private Sub LoadSalesAnalysis()
        Dim viewer As New FReportViewer
        viewer.ReportName = "SalesAnalysis"
        viewer.DateFrom = DateTimePicker1.Value
        viewer.DateTo = DateTimePicker2.Value
        viewer.Show()
    End Sub
End Class