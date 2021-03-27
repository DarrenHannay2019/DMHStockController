Imports System.Data.SqlClient

Public Class FAdjustments
    Dim connectionString As String = "Initial Catalog=DMHStockv4;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"

    Private Sub FAdjustments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtOption.Text = "Shop Adjustments" Then Shop_Adjustments()
        If FMain.txtOption.Text = "Warehouse Adjustments" Then Warehouse_Adjustments()
    End Sub
    Private Sub Warehouse_Adjustments()
        Me.Text = "Warehouse Adjustment"
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        Label9.Text = FMain.DgvRecords.Item(0, i).Value
        TextBox1.Text = FMain.DgvRecords.Item(1, i).Value
        TextBox2.Text = FMain.DgvRecords.Item(2, i).Value
        TextBox3.Text = FMain.DgvRecords.Item(3, i).Value
        TextBox4.Text = "Warehouse"
        TextBox5.Text = FMain.DgvRecords.Item(4, i).Value
        TextBox6.Text = FMain.DgvRecords.Item(6, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(7, i).Value
        ComboBox1.Text = FMain.DgvRecords.Item(8, i).Value

    End Sub
    Private Sub Shop_Adjustments()
        Me.Text = "Shop Adjustment"
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        Label9.Text = FMain.DgvRecords.Item(0, i).Value
        TextBox1.Text = FMain.DgvRecords.Item(1, i).Value
        TextBox2.Text = FMain.DgvRecords.Item(2, i).Value
        TextBox3.Text = FMain.DgvRecords.Item(4, i).Value
        TextBox4.Text = "Shop"
        TextBox5.Text = FMain.DgvRecords.Item(5, i).Value
        TextBox6.Text = FMain.DgvRecords.Item(6, i).Value
        DateTimePicker1.Value = FMain.DgvRecords.Item(7, i).Value
        ComboBox1.Text = FMain.DgvRecords.Item(8, i).Value
    End Sub
    Private Sub Adjustment_Update()
        Using conn As New SqlConnection(connectionString)
            Dim insertcommand As New SqlCommand()
            insertcommand.Connection = conn
            insertcommand.CommandType = CommandType.Text
            insertcommand.CommandText = "UPDATE tblStockMovements SET Movementtype = @MovementType, MovementQtyHangers = @MovementQtyHangers, MovementValue = @MovementValue Where StockMovementID ='" + Label9.Text + "'"
            insertcommand.Parameters.AddWithValue("@MovementType", ComboBox1.Text)
            If ComboBox1.Text = "Stock Gain" Then insertcommand.Parameters.AddWithValue("@MovementQtyHangers", TextBox6.Text)
            If ComboBox1.Text = "Stock Loss" Then insertcommand.Parameters.AddWithValue("@MovementQtyHangers", CInt(TextBox6.Text * -1))
            insertcommand.Parameters.AddWithValue("@MovementValue", "0")  '8
            insertcommand.Connection.Open()
            insertcommand.ExecuteNonQuery()
            conn.Close()
        End Using
        Using dconn As New SqlConnection(connectionString)
            Dim insertCommand2 As New SqlCommand
            insertCommand2.Connection = dconn
            insertCommand2.CommandType = CommandType.Text
            insertCommand2.CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference)"
            insertCommand2.Connection.Open()
            insertCommand2.Parameters.AddWithValue("@StockCode", TextBox5.Text)
            insertCommand2.Parameters.AddWithValue("@SupplierRef", " ")
            insertCommand2.Parameters.AddWithValue("@Location", TextBox3.Text)
            insertCommand2.Parameters.AddWithValue("@MovementQtyHangers", TextBox6.Text)
            insertCommand2.Parameters.AddWithValue("@MovementType", "Adjustments")
            insertCommand2.Parameters.AddWithValue("@RecordType", "Adjustment-Update")
            insertCommand2.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            insertCommand2.Parameters.AddWithValue("@Timestamp", Date.Now)
            insertCommand2.Parameters.AddWithValue("@Reference", Label9.Text)
            insertCommand2.Parameters.AddWithValue("@CreatedBy", FMain.TextBox1.Text)
            insertCommand2.ExecuteNonQuery()
        End Using

    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Adjustment_Update()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class