Imports CrystalDecisions.CrystalReports.Engine
Public Class FReportTotalValue
    Private Sub FReportTotalValue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cryReport As New ReportDocument
        cryReport.Load(My.Computer.FileSystem.CurrentDirectory + "\TotalValueRep.rpt")
        CrystalReportViewer1.ReportSource = cryReport
    End Sub
End Class