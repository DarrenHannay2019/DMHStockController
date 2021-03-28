Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop

Public Class FReportViewer
    Dim CryReport As New ReportDocument
    Public ReportName As String
    Public DateFrom As Date
    Public DateTo As Date
    Public StartStock As String
    Public EndStock As String
    Public StartShop As String
    Public EndShop As String
    Private Sub FReportViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        EmailReportToolStripMenuItem.Enabled = False
        If ReportName = "PrintAllList" Then LoadPrintAllStockList()
        If ReportName = "PrintCurrentList" Then LoadPrintCurrentList()
        If ReportName = "PrintOrderList" Then LoadPrintPorderList()
        If ReportName = "PrintShopAdjList" Then LoadPrintShopAdjList()
        If ReportName = "PrintShopDelList" Then LoadPrintShopDelList()
        If ReportName = "PrintShopList" Then LoadPrintShopList()
        If ReportName = "PrintShopReturnsList" Then LoadPrintShopReturnsList()
        If ReportName = "PrintShopSalesList" Then LoadPrintShopSalesList()
        If ReportName = "PrintShopTransList" Then LoadPrintShopTransList()
        If ReportName = "PrintSupplierList" Then LoadPrintSupplierList()
        If ReportName = "PrintWarehouseAdjList" Then LoadPrintWarehouseAdjList()
        If ReportName = "PrintWarehouseRetList" Then LoadPrintWarehouseRetList()
        If ReportName = "AllStock" Then LoadAllStockM()
        If ReportName = "ShopDel" Then LoadShopDelByCode()
        If ReportName = "SalesAnalysis" Then LoadSalesAnalysis()
        If ReportName = "SalesH" Then LoadSalesHistory()
        If ReportName = "StockList2" Then LoadStockListByCode()
        If ReportName = "Bore" Then LoadBorehamwood()
        If ReportName = "StockList1" Then StockList1()
        If ReportName = "TotalStockValuation" Then LoadTotalValue()
        If ReportName = "Warehouse" Then LoadWarehouseStockList()
        Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub LoadPrintShopList() '1
        CryReport.Load("C:\Reports2\PrintShops.rpt")
        CrViewer.ReportSource = CryReport
        Text = "Print Shop List"
    End Sub
    Private Sub LoadPrintSupplierList() '2
        CryReport.Load("C:\Reports2\SuppliersReport.rpt")
        CrViewer.ReportSource = CryReport
        Text = "Print Supplier List"
    End Sub
    Private Sub LoadPrintAllStockList() '3
        CryReport.Load("C:\Reports2\PrintShops.rpt")
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadPrintCurrentList() '4'
        CryReport.Load("C:\Reports2\StockList.rpt")
        CrViewer.ReportSource = CryReport
        Text = "Print Stock List"
    End Sub
    Private Sub LoadPrintPorderList() '5'
        CryReport.Load("C:\Reports2\PordersList.rpt")
        CrViewer.ReportSource = CryReport
        Text = "Print Purchase order List"
    End Sub
    Private Sub LoadPrintShopAdjList() '6'
        '   CryReport.Load("C:\Reports\PrintShops.rpt")
        '   CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadPrintShopDelList() '7'
        CryReport.Load("C:\Reports2\ShopDelGrid.rpt")
        CrViewer.ReportSource = CryReport
        Text = "Print Shop Delivery List"
    End Sub
    Private Sub LoadPrintShopSalesList() '8'
        CryReport.Load("C:\Reports2\SalesGrid.rpt")
        CrViewer.ReportSource = CryReport
        Text = "Print Sales Grid"
    End Sub
    Private Sub LoadPrintShopReturnsList() '9'
        CryReport.Load("C:\Reports2\PrintShops.rpt")
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadPrintShopTransList() '10'
        CryReport.Load("C:\Reports2\PrintShops.rpt")
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadPrintWarehouseAdjList() '11'
        CryReport.Load("C:\Reports2\PrintShops.rpt")
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadPrintWarehouseRetList() '12' ' Not being used for the first version of this product
        CryReport.Load("C:\Reports\PrintShops.rpt")
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadAllStockM() '13'
        With CryReport
            .Load("C:\Reports2\AllStock.rpt")
            .SetParameterValue("Stock", StartStock)
            .SetParameterValue("Stock2", EndStock)
            .SetParameterValue("DateFrom", DateFrom)
            .SetParameterValue("DateTo", DateTo)
        End With
        Text = "All Stock Movements Report for [" + StartStock.ToString() + "] to [" + EndStock.ToString() + "]"
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadShopDelByCode() '14'
        With CryReport
            .Load("C:\Reports2\ShopDeliveryRep.rpt")
            .SetParameterValue("DateFrom", DateFrom)
            .SetParameterValue("DateTo", DateTo)
            .SetParameterValue("StockCode", StartStock)
            .SetParameterValue("Stock2", EndStock)
        End With
        CrViewer.ReportSource = CryReport
        Text = "Shop Delivery Report for [" + StartStock + "] [" + EndStock + "]"
    End Sub
    Private Sub LoadBorehamwood() '15'
        With CryReport
            .Load("C:\Reports2\StockListByShopBore.rpt")
            .SetParameterValue("ShopFrom", StartShop)
            .SetParameterValue("ShopTo", StartShop)
            .SetParameterValue("WeekEnding", DateTo)
            .SetParameterValue("Date1", DateFrom)
        End With
        CrViewer.ReportSource = CryReport
        EmailReportToolStripMenuItem.Enabled = True
        Text = "Borehamwood Shop Stock List"
    End Sub
    Private Sub StockList1() '16'
        With CryReport
            .Load("C:\Reports2\StockListByShop.rpt")
            .SetParameterValue("ShopFrom", StartShop)
            .SetParameterValue("ShopTo", EndShop)
            .SetParameterValue("WeekEnding", DateTo)
            .SetParameterValue("Date1", DateFrom)
        End With
        CrViewer.ReportSource = CryReport
        EmailReportToolStripMenuItem.Enabled = True
        Text = "Shop stock list"
    End Sub
    Private Sub LoadStockListByCode() '17'
        CryReport.Load("C:\Reports2\StockListByCode.rpt")
        CryReport.SetParameterValue("StockCode", StartStock)
        CryReport.SetParameterValue("StockCode2", EndStock)
        CryReport.SetParameterValue("WeekEnding", DateTo)
        CryReport.SetParameterValue("Date1", DateFrom)
        CrViewer.ReportSource = CryReport
        Text = "Stock List by StockCode [" + StartStock + "] [" + EndStock + "]"
    End Sub
    Private Sub LoadWarehouseStockList() '18'
        With CryReport
            .Load("C:\Reports2\WarehouseStockList.rpt")
            .SetParameterValue("Date1", DateFrom)
            .SetParameterValue("Date2", DateTo)
        End With
        Text = "Warehouse Stock List"
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadTotalValue() '19'
        CryReport.Load("C:\Reports2\TotalValueRep.rpt")
        CryReport.SetParameterValue("Date2", DateTo)
        CryReport.SetParameterValue("WeekEnding", DateTo)
        CryReport.SetParameterValue("Date1", DateFrom)
        Me.Text = "Total Stock Valuation Report"
        CrViewer.ReportSource = CryReport

    End Sub
    Private Sub LoadSalesHistory() '20'
        With CryReport
            .Load("C:\Reports2\SalesHistory.rpt")
            .SetParameterValue("ShopName", StartShop)
            .SetParameterValue("StockCode", StartStock)
            .SetParameterValue("DateTo", DateTo)
            .SetParameterValue("DateFrom", DateFrom)
        End With
        Text = "Sales History Report"
        CrViewer.ReportSource = CryReport
    End Sub
    Private Sub LoadSalesAnalysis() '21'
        CryReport.Load("C:\Reports2\SalesAnalysis.rpt")
        CryReport.SetParameterValue("DateFrom1", DateFrom)
        CryReport.SetParameterValue("DateTo2", DateTo)
        CrViewer.ReportSource = CryReport
        Text = "Sales Analysis Report"
    End Sub
    Private Sub EmailReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailReportToolStripMenuItem.Click
        If Text = "Borehamwood Shop Stock List" Then
            EmailBorehamwood(DateTo)
        ElseIf Text = "Shop stock list" Then
            EmailShopStock(DateTo)
        End If
    End Sub
    Public Sub EmailBorehamwood(DateTo As Date)
        Dim t As String
        Dim d As String
        Dim m As String
        Dim y As String
        t = DateTo.Second.ToString + DateTo.Minute.ToString + DateTo.Hour.ToString
        d = DateTo.Day.ToString
        m = DateTo.Month.ToString
        y = DateTo.Year.ToString
        Dim uniqueid As String
        uniqueid = d & m & y
        CryReport.Load("c:\Reports2\StockListbyShopBore.rpt")
        CryReport.SetParameterValue("WeekEnding", DateTo)
        CryReport.SetParameterValue("Date1", DateTo)
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CrDiskFileDestinationOptions.DiskFileName = "C:\Reports2\StoreStockBore" + uniqueid + ".pdf"
        CrExportOptions = CryReport.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .ExportDestinationOptions = CrDiskFileDestinationOptions
            .ExportFormatOptions = CrFormatTypeOptions
        End With
        CryReport.Export()

        Dim Outlook As Outlook.Application
        Dim Mail As Outlook.MailItem
        Dim Acc As Outlook.Account
        Outlook = New Outlook.Application
        Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
        Mail.Subject = "Your Shop Stock List"
        For Each Acc In Outlook.Session.Accounts
            If Acc.AccountType = Microsoft.Office.Interop.Outlook.OlAccountType.olPop3 Then
                Mail.Sender = Acc
            End If
        Next
        '       If Not sender Is Nothing Then Mail.Sender = sender.currentUser.AddressEntry
        Mail.Attachments.Add("C:\Reports2\StoreStockBore" + uniqueid.ToString() + ".pdf")
        Mail.HTMLBody &= "Stock List for Borehamwood "
        Mail.Display()
    End Sub
    Public Sub EmailShopStock(Dateto As Date)
        Dim t As String
        Dim d As String
        Dim m As String
        Dim y As String
        t = Dateto.Second.ToString + Dateto.Minute.ToString + Dateto.Hour.ToString
        d = Dateto.Day.ToString
        m = Dateto.Month.ToString
        y = Dateto.Year.ToString
        Dim uniqueid As String
        uniqueid = d & m & y
        CryReport.Load("c:\Reports2\StockListByShop.rpt")
        CryReport.SetParameterValue("WeekEnding", Dateto)
        CryReport.SetParameterValue("Date1", Dateto)
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CrDiskFileDestinationOptions.DiskFileName = "C:\Reports2\StoreStock" + uniqueid + ".pdf"
        CrExportOptions = CryReport.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .ExportDestinationOptions = CrDiskFileDestinationOptions
            .ExportFormatOptions = CrFormatTypeOptions
        End With
        CryReport.Export()

        Dim Outlook As Outlook.Application
        Dim Mail As Outlook.MailItem
        Dim Acc As Outlook.Account
        Outlook = New Outlook.Application
        Mail = Outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
        Mail.Subject = "Your Shop Stock List"
        For Each Acc In Outlook.Session.Accounts
            If Acc.AccountType = Microsoft.Office.Interop.Outlook.OlAccountType.olPop3 Then
                Mail.Sender = Acc
            End If
        Next
        '       If Not sender Is Nothing Then Mail.Sender = sender.currentUser.AddressEntry
        Mail.Attachments.Add("C:\Reports2\StoreStock" + uniqueid.ToString() + ".pdf")
        Mail.HTMLBody &= "Stock List for"
        Mail.Display()
    End Sub

End Class