Imports CrystalDecisions.CrystalReports.Engine

Public Class FReportSalesHistory
    Private Sub FReportSalesHistory_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load(My.Computer.FileSystem.CurrentDirectory + "\SalesHistory.rpt")
        cryReport.SetParameterValue("DateFrom", FCriteria.DateTimePicker1.Value)
        cryReport.SetParameterValue("DateTo", FCriteria.DateTimePicker2.Value)
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
End Class