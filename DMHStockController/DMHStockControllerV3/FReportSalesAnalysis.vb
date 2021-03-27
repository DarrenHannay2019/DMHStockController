Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FReportSalesAnalysis
    Private Sub FReportSalesAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cryReport As New ReportDocument
        cryReport.Load(My.Computer.FileSystem.CurrentDirectory + "\SalesAnalysis.rpt")
        cryReport.SetParameterValue("DateFrom", FCriteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("DateTo", FCriteria.DateTimePicker2.Value)
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
End Class