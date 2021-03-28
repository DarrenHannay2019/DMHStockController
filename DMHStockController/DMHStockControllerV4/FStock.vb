Imports System.Data.SqlClient
Public Class FStock
    Dim upd As New CUpdate
    Dim syslog As New CSystemLog
    Dim ut As New CUtils
    Public sd As String
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        upd.SaveStock(StockCodeTextBox.Text, SupplierRefTextBox.Text, CBool(DeadCodeCheckBox.CheckState), CDec(AmountTakenTextBox.Text), 0, CDec(CostValueTextBox.Text), CDec(0.00), 0, "All")
        If sd = "All" Then FGridAllStock.TsbRefresh.PerformClick()
        If sd = "Current" Then FGridCurrentStock.TsbRefresh.PerformClick()
        Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub FStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using conn As New SqlConnection(ut.GetConnString())
            Dim data As New DataSet
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SupplierRef from tblSuppliers", conn)}
            conn.Open()
            adp.Fill(data)
            Dim ACSC As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To data.Tables(0).Rows.Count - 1
                ACSC.Add(data.Tables(0).Rows(i).Item(0).ToString)
            Next
            SupplierRefTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            SupplierRefTextBox.AutoCompleteCustomSource = ACSC
            SupplierRefTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub
End Class