Imports System.Data.SqlClient

Public Class FProvStock
    Dim connectionString As String = "Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
    Dim connection As New SqlConnection(connectionString)
    Dim SelectCommand As New SqlCommand
    Dim UpdateCommand As New SqlCommand
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Doupdate()
    End Sub

    Private Sub FProvStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Doupdate()
    End Sub
    Private Sub Doupdate()

        Dim StrSQL As String
        SelectCommand.Connection = connection
        SelectCommand.Connection.Open()
        SelectCommand.CommandText = "Select * from tblStock order by StockCode"
        SelectCommand.CommandType = CommandType.Text
        DataGridView1.DataSource = SelectCommand.ExecuteNonQuery()
        SelectCommand.Connection.Close()

        If DataGridView1.Rows.Count > 0 Then
            pBar.Minimum = 0
            pBar.Maximum = DataGridView1.Rows.Count
            pBar.Value = 0
            Dim i As Integer
            i = DataGridView1.Rows.Count - 1
            Dim stockcode = DataGridView1.Item(0, i).Value
            ribTitle.Text = " Recalculating Stock Values - Pass 1 "
            StrSQL = "SELECT tblSalesLine.StockCode, Sum(tblSalesLine.SalesAmount /(1+(20/100))) AS SumOfSalesAmount " _
                           & "From tblSalesLine " _
                         & "GROUP BY tblSalesLine.StockCode " _
                        & "HAVING (((tblSalesLine.StockCode)= '" & stockcode & "'))"
        End If
        pBar.Minimum = 0
        pBar.Maximum = DataGridView1.Rows.Count
        pBar.Value = 0
        ribTitle.Text = " Recalculating Stock Values - Pass 2"


        ' rstStock.MoveFirst()
        ' While Not rstStock.EOF
        ' rstUpdate = New ADODB.Recordset
        ' rstUpdate.CursorLocation = adUseClient
        ' strSQL = "SELECT tblDeliveryLines.StockCode, Sum(tblDeliveryLines.DeliveredQtyGarments) AS SumOfDeliveredQtyGarments, Sum(tblDeliveryLines.NetAmount) AS SumOfNetAmount " _
        '         & "From tblDeliveryLines " _
        '        & "GROUP BY tblDeliveryLines.StockCode " _
        '       & "HAVING (((tblDeliveryLines.StockCode) = '" & rstStock!StockCode & "'))"

        '  rstUpdate.Open(strSQL, g_conCn, adOpenStatic, adLockReadOnly)
        '  If rstUpdate.RecordCount > 0 Then
        ' rstStock!DeliveredQtyHangers = rstUpdate!SumOfDeliveredQtyGarments
        ' rstStock!CostValue = rstUpdate!SumOfNetAmount
        ' rstStock.Update()
        ' Else
        ' rstStock!DeliveredQtyHangers = 0
        ' rstStock!CostValue = 0
        'rstStock.Update()
        'End If
        'rstUpdate.Close()
        'rstUpdate = Nothing

        ' objProgress.ribStatus.Caption = " Calculating Cost Value for Stock Code " & rstStock!StockCode
        ' objProgress.pBar.Value = objProgress.pBar.Value + 1
        ' objProgress.Show()
        ' DoEvents()
        ' rstStock.MoveNext()
        ' End While

        '    End If

        '        rstStock.Close()

        '        rstStock = Nothing

        '     objProgress.ribStatus.Caption = " Calculating Percentage Markup "
        '      objProgress.Show()
        '       DoEvents()
        '        strSQL = "UPDATE tblStock SET tblStock.PCMarkUp = IIf([tblStock]![AmountTaken]=0,-100,(([tblStock]![AmountTaken]/[tblStock]![CostValue])*100)-100)"
        MsgBox("Stock Revaluation Successful.", vbInformation)
        ribTitle.Text = " Recalculating Stock Values - Pass 1"
        For Each row As DataGridView In DataGridView1.Rows
            Dim i As Integer
            ribStatus.Text = " Calculating Amount Taken for Stock Code " & DataGridView1.Item(0, i).Value
            SelectCommand.CommandText = "insert into dbo.tblStock(AmountTaken); Select sumofsalesamount FROM qryProvSales"
            SelectCommand.CommandType = CommandType.Text
            SelectCommand.Connection = connection
            SelectCommand.Connection.Open()
            SelectCommand.ExecuteNonQuery()
            connection.Close()
            pBar.Value = pBar.Value + 1
        Next
        pBar.Value = 0
        ribTitle.Text = " Recalculating Stock Values - Pass 2"
        For Each row As DataGridView In DataGridView1.Rows
            Dim i As Integer
            ribStatus.Text = " Calculating Delivered Quantity for Stock Code " & DataGridView1.Item(0, i).Value

            SelectCommand.CommandText = "insert into dbo.tblstock(DeliveredQtyHangers); Select DeliveredQty From qryProveDel"
            SelectCommand.CommandType = CommandType.Text
            SelectCommand.Connection = connection
            SelectCommand.Connection.Open()
            SelectCommand.ExecuteNonQuery()
            connection.Close()
            pBar.Value = pBar.Value + 1
        Next
        pBar.Value = 0
        For Each row As DataGridView In DataGridView1.Rows
            Dim i As Integer
            ribStatus.Text = " Calculating Cost Value for Stock Code " & DataGridView1.Item(0, i).Value
            SelectCommand.CommandText = "insert into dbo.tblStock(CostValue); Select SumOfMovementValue From qryDeliveryValue "
            SelectCommand.CommandType = CommandType.Text
            SelectCommand.Connection = connection
            SelectCommand.Connection.Open()
            SelectCommand.ExecuteNonQuery()
            connection.Close()
            pBar.Value = pBar.Value + 1
        Next
        pBar.Value = 0
        ribStatus.Text = " Calculating Percentage Markup "
        For Each row As DataGridView In DataGridView1.Rows
            SelectCommand.CommandText = "UPDATE tblStock SET tblStock.PCMarkUp = IIf(AmountTaken=0,0,((AmountTaken/CostValue)*100)-100)"
            SelectCommand.CommandType = CommandType.Text
            SelectCommand.Connection = connection
            SelectCommand.Connection.Open()
            SelectCommand.ExecuteNonQuery()
            connection.Close()
            pBar.Value = pBar.Value + 1
        Next
        'End If
        Form1.StockToolStripMenuItem.PerformClick()
        MsgBox("Stock Revaluation Successful.", vbInformation)
        Me.Close()
    End Sub
    Private Sub updateCost()


    End Sub
    Private Sub updateSales()

    End Sub
    Private Sub updatePCMarkUP()

    End Sub
End Class