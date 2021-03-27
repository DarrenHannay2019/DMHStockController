Imports CrystalDecisions.CrystalReports.Engine
Public Class FReportWarehouseStock
    Private Sub FReportWarehouseStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load(My.Computer.FileSystem.CurrentDirectory + "\WarehouseStockList.rpt")

        CrystalReportViewer1.ReportSource = cryReport
    End Sub
End Class