Imports System.Data.SqlClient

Public Class FStock
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim cmd As New SqlCommand
    Dim duplicateCommand As New SqlCommand
    ' Create a DataSet
    Dim cbodata As New DataSet()
    Dim adata As New DataSet()
    Dim StockDataAdapter As New SqlDataAdapter("SELECT * from tblStock", connection)
    Dim SeasonDataAdapter As New SqlDataAdapter("SELECT SeasonName from tblSeasons", connection)

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If StockCodeTextBox.Text = "" And SupplierRefTextBox.Text = "" And CostValueTextBox.Text = "" Then MsgBox("Please enter a StockCode,SupplierRef and Cost Value before continue!!", vbExclamation, ProductName)
        If StockCodeTextBox.Text <> "" And SupplierRefTextBox.Text <> "" And CostValueTextBox.Text <> "" Then
            If cmdAdd.Text = "OK" Then UpdateRecord()
            If cmdAdd.Text = "Add" Then AddRecord()
        Else
            MsgBox("Please enter data into the boxes", vbExclamation, ProductName)
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If MsgBox("Do You Wish to Cancel This Record Input", MsgBoxStyle.YesNo, ProductName) = vbYes Then Me.Close()
    End Sub

    Private Sub cmdFindSupplier_Click(sender As Object, e As EventArgs) Handles cmdFindSupplier.Click

    End Sub

    Private Sub FStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then MyNew()
        If FMain.txtMode.Text = "DELETE" Then MyDelete()
        If FMain.txtMode.Text = "OLD" Then MyOld()
        adata.Locale = System.Globalization.CultureInfo.InvariantCulture
        cbodata.Locale = System.Globalization.CultureInfo.InvariantCulture

        Try
            connection.Open()
            ' SeasonDataAdapter.Fill(cbodata, "tblSeasons")
            StockDataAdapter.Fill(adata, "tblStock")
            ' cboCurrentSeason.DataSource = cbodata
            ' cboCurrentSeason.DisplayMember = "SeasonName"
            ' cboCurrentSeason.ValueMember = "SeasonName"
            ' For Each dRow As DataRow In cbodata.Tables("tblSeasons").Rows
            'SeasonComboBox.Items.Add(dRow.Item(0).ToString)
            '  Next
            connection.Close()
        Catch h As SqlException
            Return
        End Try
    End Sub

    Private Sub SupplierRefTextBox_Leave(sender As Object, e As EventArgs) Handles SupplierRefTextBox.Leave
        Dim suppliersql As String = "SELECT * from tblSuppliers where SupplierRef = '" & SupplierRefTextBox.Text & "'"
        Dim suppliercmd As New SqlCommand()
        Dim resultset As Integer
        suppliercmd.Connection = connection
        suppliercmd.CommandType = CommandType.Text
        suppliercmd.CommandText = suppliersql
        suppliercmd.Connection.Open()
        resultset = suppliercmd.ExecuteNonQuery()
        suppliercmd.Connection.Close()
        If resultset < 1 Then MsgBox("Please enter a Supplier Reference", MsgBoxStyle.Exclamation, ProductName)
        If resultset = 1 Then AmountTakenTextBox.Select()
    End Sub
    Public Sub MyNew()
        cmdAdd.Text = "Add"
        Button1.Visible = False
        Button1.Text = "Clear"
        cmdCancel.Text = "Cancel"
        CreatedByTextBox.Text = FMain.TextBox1.Text
        DateTimePicker1.Value = Now
    End Sub
    Public Sub MyOld()

        cmdAdd.Text = "OK"
        Button1.Visible = False
        cmdCancel.Text = "Cancel"
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        StockCodeTextBox.Text = FMain.DgvRecords.Item(0, i).Value
        SupplierRefTextBox.Text = FMain.DgvRecords.Item(1, i).Value
        '  SeasonComboBox.Text = Form1.DataGridView1.Item(2, i).Value
        DeadCodeCheckBox.Checked = FMain.DgvRecords.Item(2, i).Value
        ' RemoveFromClearanceCheckBox.Checked = Form1.DataGridView1.Item(4, i).Value
        AmountTakenTextBox.Text = FMain.DgvRecords.Item(3, i).Value
        CostValueTextBox.Text = FMain.DgvRecords.Item(5, i).Value
        PCMarkUpTextBox.Text = FMain.DgvRecords.Item(6, i).Value
        ZeroQtyCheckBox.Checked = FMain.DgvRecords.Item(7, i).Value
        CreatedByTextBox.Text = FMain.DgvRecords.Item(8, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(9, i).Value
        DeliveredQtyHangersTextBox.Text = FMain.DgvRecords.Item(4, i).Value

    End Sub
    Public Sub MyDelete()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        StockCodeTextBox.Text = Form1.DataGridView1.Item(0, i).Value
        Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        Dim conn As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.Connection.Open()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM tblStock WHERE StockCode='" & StockCodeTextBox.Text & "'"
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()
        Form1.StockToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub AddRecord()

        Try
            Dim queryResult As Integer
            duplicateCommand.Connection = connection
            duplicateCommand.Connection.Open()
            duplicateCommand.CommandType = CommandType.Text
            duplicateCommand.CommandText = " SELECT COUNT(*) as numRows From tblStock WHERE stockcode = '" + StockCodeTextBox.Text + "' AND SupplierRef = '" + SupplierRefTextBox.Text + "'"
            queryResult = duplicateCommand.ExecuteNonQuery()
            duplicateCommand.Connection.Close()
            If queryResult > 0 Then
                MessageBox.Show("Stock Record :" + StockCodeTextBox.Text + "[" + SupplierRefTextBox.Text + "] Already Exists in the database", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) : StockCodeTextBox.SelectAll() : Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error in database", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Dim a As Integer
        'Dim b As Integer
        Dim c As Integer
        If DeadCodeCheckBox.CheckState = CheckState.Checked Then a = 1
        If DeadCodeCheckBox.CheckState = CheckState.Unchecked Then a = 0
        ' If RemoveFromClearanceCheckBox.CheckState = CheckState.Checked Then b = 1
        'If RemoveFromClearanceCheckBox.CheckState = CheckState.Unchecked Then b = 0
        If ZeroQtyCheckBox.CheckState = CheckState.Checked Then c = 1
        If ZeroQtyCheckBox.CheckState = CheckState.Unchecked Then c = 0
        Try
            Dim insertdb As String = " INSERT INTO tblStock (StockCode,SupplierRef,DeadCode,DeliveredQtyHangers,AmountTaken,CostValue,PCMarkUp,ZeroQty,CreatedBy,CreatedDate) VALUES (@StockCode,@SupplierRef,@DeadCode,@DeliveredQtyHangers,@AmountTaken,@CostValue,@PCMarkUp,@ZeroQty,@CreatedBy,@CreatedDate)"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(insertdb, connection)
            com.Connection.Open()
            com.Parameters.AddWithValue("@ZeroQty", ZeroQtyCheckBox.CheckState)
            com.Parameters.AddWithValue("@StockCode", StockCodeTextBox.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", SupplierRefTextBox.Text.ToString)
            ' com.Parameters.AddWithValue("@Season", SeasonComboBox.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", DeadCodeCheckBox.CheckState)
            '   com.Parameters.AddWithValue("@RemoveFromClearance", RemoveFromClearanceCheckBox.CheckState)
            com.Parameters.AddWithValue("@AmountTaken", AmountTakenTextBox.Text)
            com.Parameters.AddWithValue("@CostValue", CostValueTextBox.Text)
            com.Parameters.AddWithValue("@PCMarkUp", CDec(PCMarkUpTextBox.Text))
            com.Parameters.AddWithValue("@CreatedBy", CreatedByTextBox.Text)
            com.Parameters.AddWithValue("@CreatedDate", Now)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", DeliveredQtyHangersTextBox.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            FMain.StockToolStripMenuItem.PerformClick()
            MsgBox("Record Created Successfully", MsgBoxStyle.Information, ProductName)
            Me.Close()
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, ProductName)
        End Try
    End Sub
    Private Sub UpdateRecord()
        Try
            Dim updatedb As String = " UPDATE tblStock SET StockCode = @StockCode,SupplierRef = @SupplierRef,DeadCode = @DeadCode,DeliveredQtyHangers = @DeliveredQtyHangers,AmountTaken= @AmountTaken, CostValue = @CostValue,PCMarkUp = @PCMarkUp,ZeroQty= @ZeroQty,CreatedBy = @CreatedBy WHERE StockCode = @StockCode"
            ' Create a DataSet
            Me.Validate()
            Dim com As New SqlCommand(updatedb, connection)
            com.Connection.Open()
            com.Parameters.AddWithValue("@StockCode", StockCodeTextBox.Text.ToString)
            com.Parameters.AddWithValue("@SupplierRef", SupplierRefTextBox.Text.ToString)
            ' com.Parameters.AddWithValue("@Season", SeasonComboBox.Text.ToString)
            com.Parameters.AddWithValue("@DeadCode", DeadCodeCheckBox.CheckState)
            'com.Parameters.AddWithValue("@RemoveFromClearance", RemoveFromClearanceCheckBox.CheckState)
            com.Parameters.AddWithValue("@AmountTaken", AmountTakenTextBox.Text)
            com.Parameters.AddWithValue("@CostValue", CostValueTextBox.Text)
            com.Parameters.AddWithValue("@PCMarkUp", CDec(PCMarkUpTextBox.Text))
            com.Parameters.AddWithValue("@ZeroQty", ZeroQtyCheckBox.CheckState)
            com.Parameters.AddWithValue("@CreatedBy", CreatedByTextBox.Text)
            com.Parameters.AddWithValue("@DeliveredQtyHangers", DeliveredQtyHangersTextBox.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            FMain.StockToolStripMenuItem.PerformClick()
            MsgBox("Update Successful", MsgBoxStyle.Information, ProductName)
            Me.Close()
        Catch ex As SqlException
            MsgBox("Update Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub
End Class