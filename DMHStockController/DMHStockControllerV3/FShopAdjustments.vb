Imports System.Data.SqlClient

Public Class FShopAdjustments
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim InsertCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Dim DeleteCommand As New SqlCommand
    Dim DuplicateCommand As New SqlCommand
    Dim SelectCommand As New SqlCommand
    Dim strWarehouse As String
    Dim strStock As String
    Dim strStockCode As String
    Dim dLastSaturday As Date = Now.AddDays(-(Now.DayOfWeek + 1))
    Dim dLastSunday As Date = Now.AddDays(-(Now.DayOfWeek + 7) + 7)
    Private Sub FShopAdjustments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FMain.txtMode.Text = "NEW" Then LoadNew()
        If FMain.txtMode.Text = "DELETE" Then LoadDelete()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "&OK" Then Me.Close()
        If Button1.Text = "&Add" Then AddRecord()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtAdjustmentQty.Clear()
        txtCurrentQty.Clear()
        txtReferemce.Clear()
        txtShopName.Clear()
        txtShopRef.Clear()
        txtStockCode.Clear()
        If DataGridView1.Rows.Count > 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows.Clear()
            Next
        End If
        DateTimePicker1.Value = dLastSunday
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FindStock()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FindWarehouse()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SelectCommand.Connection = connection
        SelectCommand.CommandText = "Select UnitPrice from qryShopStockDisplay where SMlocation = '" + txtShopRef.Text + "' and SMStockCode = '" + txtStockCode.Text + "'"
        SelectCommand.Connection.Open()
        TextBox1.Text = SelectCommand.ExecuteNonQuery()
        SelectCommand.Connection.Close()


        Dim Values As Decimal
        Values = CDec(txtAdjustmentQty.Text * TextBox1.Text)

        Dim rowNum As Integer = DataGridView1.Rows.Add()
        DataGridView1.Rows.Item(rowNum).Cells(0).Value = txtStockCode.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(1).Value = txtShopRef.Text.ToString()
        'DataGridView1.Rows.Item(rowNum).Cells(2).Value = txtShopName.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(2).Value = txtCurrentQty.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(3).Value = cboType.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(4).Value = txtAdjustmentQty.Text.ToString()
        DataGridView1.Rows.Item(rowNum).Cells(5).Value = DateTimePicker1.Value()
        DataGridView1.Rows.Item(rowNum).Cells(6).Value = Values
        txtStockCode.Text = ""
        txtAdjustmentQty.Text = ""
        txtCurrentQty.Text = ""
        cboType.Text = ""
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub txtShopRef_Leave(sender As Object, e As EventArgs) Handles txtShopRef.Leave
        Dim sql As String = "Select ShopRef,ShopName,ShopType from tblShops WHERE ShopRef = '" & txtShopRef.Text & "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet

        zdataa.Fill(dt, "tblShops")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView3.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Shop", MsgBoxStyle.Information, "Stock Master V2")
            DataGridView3.Visible = True
            Dim i As Integer
            i = DataGridView3.CurrentRow.Index
            txtShopRef.Text = DataGridView2.Item(0, i).Value
            txtShopName.Text = DataGridView2.Item(1, i).Value
            txtfromshoptype.Text = DataGridView2.Item(2, i).Value
        Else
            txtShopName.Text = dr("ShopName").ToString
            txtShopRef.Text = dr("ShopRef").ToString
            txtfromshoptype.Text = dr("ShopType").ToString
        End If
    End Sub

    Private Sub txtStockCode_Leave(sender As Object, e As EventArgs) Handles txtStockCode.Leave
        Try
            Dim strStock As String
            SelectCommand.Connection = connection
            SelectCommand.Connection.Close()
            SelectCommand.Connection.Open()
            SelectCommand.CommandType = CommandType.Text
            Dim sql As String = "SELECT Qty from qryShopStock Where SMLocation = '" + txtShopRef.Text + "' And SMStockCode = '" + txtStockCode.Text + "'"
            SelectCommand.CommandText = sql
            strStock = SelectCommand.ExecuteNonQuery()
            SelectCommand.Connection.Close()
            Dim sql2 As String = "SELECT SMStockCode,Qty from qryShopStock Where SMLocation = '" + txtShopRef.Text + "'"

            Dim zdata As New SqlDataAdapter(sql2, connection)
            Dim dta As New DataSet
            If txtStockCode.Text = "" Then MsgBox("Please enter a stock code", MsgBoxStyle.Information, Application.ProductName)
            If txtStockCode.Text <> "" Then zdata.Fill(dta, "qryShopStock")
            Dim dr As DataRow = dta.Tables(0).Rows(0)
            DataGridView2.DataSource = dta.Tables(0)
            If dr.Table.Rows.Count - 1 > 1 Then
                MsgBox("Please Select a Stock", MsgBoxStyle.Information, Application.ProductName)
                DataGridView2.Visible = True
                Dim i As Integer
                i = DataGridView2.CurrentRow.Index
                txtStockCode.Text = DataGridView2.Item(0, i).Value
                txtCurrentQty.Text = DataGridView2.Item(1, i).Value
            Else
                txtStockCode.Text = dr("SMStockCode").ToString
                txtCurrentQty.Text = dr("Qty").ToString
            End If
        Catch ex As Exception
            MsgBox("No Stock Code Found Please add stock to the shop before adjusting", vbCritical, ProductName)
        End Try

    End Sub

    Private Sub DeleteItem()
        Dim i As Integer
        i = FMain.DgvRecords.CurrentRow.Index
        txtReferemce.Text = FMain.DgvRecords.Item(0, i).Value
        DeleteCommand.Connection = connection
        DeleteCommand.Connection.Open()
        DeleteCommand.CommandType = CommandType.Text
        DeleteCommand.CommandText = "DELETE from tblStockMovements where StockmovementID = '" + txtReferemce.Text.ToString() + "'"
        DeleteCommand.ExecuteNonQuery()
        DeleteCommand.Connection.Close()
        FMain.ShopAdjustmentsToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub
    Private Sub AddRecord()
        Dim stockcode As String
        Dim shopcode As String
        Dim adjustmenttype As String
        Dim unitprice As Decimal
        Dim adjustmentqty As Integer
        Try
            Me.Validate()
            Dim STR1 = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@SMCreatedBy,@SMCreatedDate)"
            Dim Comm As New SqlCommand(STR1, connection)
            connection.Close()
            connection.Open()
            If DataGridView1.RowCount = 1 Then addsingle()
            If DataGridView1.RowCount > 1 Then
                For x As Integer = 0 To DataGridView1.Rows.Count - 1
                    'MusicID = SalesDataGridView.Rows(x).Cells(0).Value
                    stockcode = DataGridView1.Rows(x).Cells(0).Value
                    shopcode = DataGridView1.Rows(x).Cells(1).Value
                    adjustmenttype = DataGridView1.Rows(x).Cells(3).Value
                    unitprice = DataGridView1.Rows(x).Cells(6).Value
                    adjustmentqty = DataGridView1.Rows(x).Cells(4).Value
                    Comm.Connection.Close()
                    Comm.Connection = connection
                    Comm.Connection.Open()
                    Comm.Parameters.AddWithValue("@SMStockCode", stockcode)
                    Comm.Parameters.AddWithValue("@SMSupplierRef", "")
                    Comm.Parameters.AddWithValue("@SMLocation", txtShopRef.Text.ToString())
                    'If txtfromshoptype.Text = "Shop" Then 
                    Comm.Parameters.AddWithValue("@SMLocationType", "Shop")
                    ' If txtfromshoptype.Text <> "Shop" Then Comm.Parameters.AddWithValue("@SMLocationType", "Concession")
                    If adjustmenttype = "Gain" Then Comm.Parameters.AddWithValue("@MovementQtyHangers", adjustmentqty)
                    If adjustmenttype = "Loss" Then Comm.Parameters.AddWithValue("@MovementQtyHangers", adjustmentqty * -1)

                    'Comm.Parameters.AddWithValue("@MovementQtyHangers", adjustmentqty)
                    If adjustmenttype = "Gain" Then Comm.Parameters.AddWithValue("@MovementType", "Stock Gain")
                    If adjustmenttype = "Loss" Then Comm.Parameters.AddWithValue("@MovementType", "Stock Loss")
                    Comm.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
                    If adjustmenttype = "Gain" Then Comm.Parameters.AddWithValue("@MovementValue", CDec(unitprice))
                    If adjustmenttype = "Loss" Then Comm.Parameters.AddWithValue("@MovementValue", CDec(unitprice * -1))
                    Comm.Parameters.AddWithValue("@Reference", txtReferemce.Text)
                    Comm.Parameters.AddWithValue("@TransferRefernce", txtReferemce.Text)
                    Comm.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text)
                    Comm.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                    Comm.ExecuteNonQuery()
                    Comm.Connection.Dispose()

                Next
            End If
            Comm.Connection.Close()
            FMain.ShopAdjustmentsToolStripMenuItem.PerformClick()
            Me.Close()
        Catch ex As SqlException
            ' Display Error Message
            MessageBox.Show("Unable to create record" & vbCr & "In DataBase.", Application.ProductName)


        End Try

    End Sub
    Private Sub addsingle()
        Dim stockcode As String
        Dim shopcode As String
        Dim adjustmenttype As String
        Dim unitprice As Decimal
        Dim adjustmentqty As Integer
        Dim STR1 = "INSERT INTO tblStockMovements (SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementType,MovementDate,MovementValue,Reference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementType,@MovementDate,@MovementValue,@Reference,@SMCreatedBy,@SMCreatedDate)"
        Dim Comm As New SqlCommand(STR1, connection)
        connection.Close()
        connection.Open()

        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            'MusicID = SalesDataGridView.Rows(x).Cells(0).Value
            stockcode = DataGridView1.Rows(x).Cells(0).Value
            shopcode = DataGridView1.Rows(x).Cells(1).Value
            adjustmenttype = DataGridView1.Rows(x).Cells(3).Value
            unitprice = DataGridView1.Rows(x).Cells(6).Value
            adjustmentqty = DataGridView1.Rows(x).Cells(4).Value
            Comm.Connection.Close()
            Comm.Connection = connection
            Comm.Connection.Open()
            Comm.Parameters.AddWithValue("@SMStockCode", stockcode)
            Comm.Parameters.AddWithValue("@SMSupplierRef", "")
            Comm.Parameters.AddWithValue("@SMLocation", txtShopRef.Text.ToString())
            'If txtfromshoptype.Text = "Shop" Then 
            Comm.Parameters.AddWithValue("@SMLocationType", "Shop")
            ' If txtfromshoptype.Text <> "Shop" Then Comm.Parameters.AddWithValue("@SMLocationType", "Concession")
            Comm.Parameters.AddWithValue("@MovementQtyHangers", adjustmentqty)
            If adjustmenttype = "Gain" Then Comm.Parameters.AddWithValue("@MovementType", "Stock Gain")
            If adjustmenttype = "Loss" Then Comm.Parameters.AddWithValue("@MovementType", "Stock Loss")
            Comm.Parameters.AddWithValue("@MovementDate", DateTimePicker1.Value)
            If adjustmenttype = "Gain" Then Comm.Parameters.AddWithValue("@MovementValue", CDec(unitprice))
            If adjustmenttype = "Loss" Then Comm.Parameters.AddWithValue("@MovementValue", CDec(unitprice * -1))
            Comm.Parameters.AddWithValue("@Reference", txtReferemce.Text)
            Comm.Parameters.AddWithValue("@TransferRefernce", txtReferemce.Text)
            Comm.Parameters.AddWithValue("@SMCreatedBy", FLoginForm.UsernameTextBox.Text)
            Comm.Parameters.AddWithValue("@SMCreatedDate", Date.Now)
            Comm.ExecuteNonQuery()
            Comm.Connection.Dispose()
            FMain.ShopAdjustmentsToolStripMenuItem.PerformClick()
            Me.Close()
        Next
    End Sub
    Private Sub LoadNew()
        Button1.Text = "&Add"
        Button3.Text = "Cancel"
        Button2.Text = "Clear"
        DateTimePicker1.Value = dLastSunday
    End Sub
    Private Sub LoadDelete()
        DeleteItem()
        Me.Close()
    End Sub
    Public Sub FindWarehouse()
        Dim sql As String = "Select ShopRef,ShopName from tblShops WHERE ShopRef = '" & txtShopRef.Text & "'"
        Dim zdataa As New SqlDataAdapter(sql, connection)
        Dim dt As New DataSet

        zdataa.Fill(dt, "tblShops")
        Dim dr As DataRow = dt.Tables(0).Rows(0)
        DataGridView3.DataSource = dt.Tables(0)
        If dr.Table.Rows.Count - 1 > 1 Then
            MsgBox("Please Select a Warehouse", MsgBoxStyle.Information, Application.ProductName)
            DataGridView3.Visible = True
            Dim i As Integer
            i = DataGridView3.CurrentRow.Index
            txtShopRef.Text = DataGridView2.Item(0, i).Value
            txtShopName.Text = DataGridView2.Item(1, i).Value
        Else
            txtShopName.Text = dr("ShopName").ToString
            txtShopRef.Text = dr("ShopRef").ToString
        End If


    End Sub
    Public Sub FindStock()
        Try
            Dim sql As String = "Select SMStockCode, QtyHangers from qryShopStockDisplay where SMStockCode='" & txtStockCode.Text & "' AND SMLocation='" + txtShopRef.Text + "'"
            Dim zdataa As New SqlDataAdapter(sql, connection)
            Dim dt As New DataSet

            zdataa.Fill(dt, "qryShopStockDisplay")
            Dim dr As DataRow = dt.Tables(0).Rows(0)
            DataGridView2.DataSource = dt.Tables(0)
            If dr.Table.Rows.Count - 1 > 1 Then
                MsgBox("Please Select a Stock Code", MsgBoxStyle.Information, Application.ProductName)
                DataGridView1.Visible = True
                Dim i As Integer
                i = DataGridView1.CurrentRow.Index
                txtStockCode.Text = DataGridView2.Item(0, i).Value
                txtCurrentQty.Text = DataGridView2.Item(1, i).Value
                'txtWarehouseName.Text = DataGridView2.Item(1, i).Value
            Else
                'txtWarehouseName.Text = dr("WarehouseName").ToString
                txtStockCode.Text = dr("SMStockCode").ToString
                txtCurrentQty.Text = dr("QtyHangers").ToString
            End If


            '   If dr("WarehouseType").ToString = "False" Then TextBox16.Text = "Active"

            'If dr("WarehouseType").ToString = "True" Then TextBox16.Text = "Long Term"
        Catch
            MsgBox("Unable to find stock code in the database", MsgBoxStyle.Information, Application.ProductName)
            txtStockCode.Clear()
        End Try
    End Sub
    Public Sub SELECTText(ByVal ctr As TextBox)
        ctr.SelectionStart = 0
        ctr.SelectionLength = Len(ctr.Text)
    End Sub












End Class