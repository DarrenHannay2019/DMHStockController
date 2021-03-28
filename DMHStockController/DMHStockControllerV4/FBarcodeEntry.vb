Imports System.Data.SqlClient
Public Class FBarcodeEntry
    Dim ut As New CUtils()
    Private Sub FBarcodeEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ACSC As New AutoCompleteStringCollection
            conn.Open()
            adp.SelectCommand = New SqlCommand("SELECT ShopRef from tblShops", conn)
            adp.Fill(dt)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                ACSC.Add(dt.Rows(i).Item(0).ToString())
            Next
            TxtLocationRef.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtLocationRef.AutoCompleteCustomSource = ACSC
            TxtLocationRef.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adp As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ACSC As New AutoCompleteStringCollection
            conn.Open()
            adp.SelectCommand = New SqlCommand("SELECT StockCode from tblStock WHERE DeadCode ='0'", conn)
            adp.Fill(dt)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                ACSC.Add(dt.Rows(i).Item(0).ToString())
            Next
            TxtStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtStockCode.AutoCompleteCustomSource = ACSC
            TxtStockCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End Using
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim RowNum As Integer = DgvRecords.Rows.Add()

        dgvRecords.Rows.Item(RowNum).Cells(1).Value = TxtStockCode.Text
        dgvRecords.Rows.Item(RowNum).Cells(2).Value = TxtLocationRef.Text
        dgvRecords.Rows.Item(RowNum).Cells(3).Value = TextBox4.Text
        dgvRecords.Rows.Item(RowNum).Cells(0).Value = txtBarcode.Text
        txtBarcode.Clear()
        TxtStockCode.Clear()
        txtBarcode.Select()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If dgvRecords.SelectedRows.Count > 1 Then
            For Each row As DataGridViewRow In dgvRecords.SelectedRows
                dgvRecords.Rows.Remove(row)
            Next
        ElseIf dgvRecords.SelectedRows.Count = 1 Then
            dgvRecords.Rows.Remove(dgvRecords.CurrentRow)
        ElseIf dgvRecords.SelectedRows.Count = 0 Then
            MessageBox.Show("Select one or more rows before you click delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        For i As Integer = 0 To dgvRecords.Rows.Count - 1
            Dim Barcode As String = dgvRecords.Rows(i).Cells(0).Value
            Dim stockcode As String = dgvRecords.Rows(i).Cells(1).Value
            Dim Qty As String = dgvRecords.Rows(i).Cells(2).Value
            Dim Value As String = dgvRecords.Rows(i).Cells(3).Value
            Using conn As New SqlConnection(ut.GetConnString())
                Dim SelCmd As New SqlCommand
                With SelCmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandText = "INSERT into tblBarcodes (BarcodeNumber,StockCode,LocationName) VALUES (@BarcodeNumber,@StockCode,@LocationName)"
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@BarcodeNumber", Barcode.TrimEnd())
                    .Parameters.AddWithValue("@StockCode", stockcode.TrimEnd())
                    .Parameters.AddWithValue("@LocationName", Value.TrimEnd())
                    .ExecuteNonQuery()
                End With
            End Using
            FGridBarcode.TsbRefresh.PerformClick()
            Me.Close()
        Next
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub TxtLocationRef_Leave(sender As Object, e As EventArgs) Handles TxtLocationRef.Leave
        TxtLocationRef.Text = UCase(TxtLocationRef.Text)
        Dim ShopResult As String
        Using conn As New SqlConnection(ut.GetConnString())
            Dim SelCmd As New SqlCommand
            With SelCmd
                .Connection = conn
                .Connection.Open()
                .CommandText = "SELECT ShopName FROM tblShops WHERE ShopRef = @ShopRef"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ShopRef", TxtLocationRef.Text)
                ShopResult = .ExecuteScalar
            End With
        End Using
        If ShopResult = "" Then
            MessageBox.Show("Please enter a valid Shop Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtLocationRef.Select()
        Else
            Me.Text = "Barcodes Entry for: [" + TxtLocationRef.Text + "] " + ShopResult
            TextBox4.Text = ShopResult
            txtBarcode.Select()
        End If
    End Sub

    Private Sub TxtStockCode_Leave(sender As Object, e As EventArgs) Handles TxtStockCode.Leave
        TxtStockCode.Text = UCase(TxtStockCode.Text)
    End Sub
End Class