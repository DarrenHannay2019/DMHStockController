Imports System.Data.SqlClient
Public Class FShops
    Dim save As New CSave
    Dim Upd As New CUpdate
    Dim ut As New CUtils
    Dim connstring As String = ut.GetConnString()
    Private Sub TxtShopRef_Leave(sender As Object, e As EventArgs) Handles TxtShopRef.Leave
        TxtShopRef.Text = UCase(TxtShopRef.Text)
    End Sub

    Private Sub TxtShopName_Leave(sender As Object, e As EventArgs) Handles TxtShopName.Leave
        TxtShopName.Text = StrConv(TxtShopName.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress1_Leave(sender As Object, e As EventArgs) Handles TxtAddress1.Leave
        TxtAddress1.Text = StrConv(TxtAddress1.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress2_Leave(sender As Object, e As EventArgs) Handles TxtAddress2.Leave
        TxtAddress2.Text = StrConv(TxtAddress2.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress3_Leave(sender As Object, e As EventArgs) Handles TxtAddress3.Leave
        TxtAddress3.Text = StrConv(TxtAddress3.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtAddress4_Leave(sender As Object, e As EventArgs) Handles TxtAddress4.Leave
        TxtAddress4.Text = StrConv(TxtAddress4.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtContactName_Leave(sender As Object, e As EventArgs) Handles TxtContactName.Leave
        TxtContactName.Text = StrConv(TxtContactName.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtPostCode_Leave(sender As Object, e As EventArgs) Handles TxtPostCode.Leave
        TxtPostCode.Text = UCase(TxtPostCode.Text)
    End Sub

    Private Sub FShops_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CmdOK.Text = "OK" Then LoadOld()
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * FROM tblShops WHERE ShopRef ='" + TxtShopRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            TxtShopRef.Text = dt.Rows(0).Item("ShopRef")
            TxtShopName.Text = dt.Rows(0).Item("ShopName")
            TxtContactName.Text = dt.Rows(0).Item("ContactName")
            TxtAddress1.Text = dt.Rows(0).Item("Street")
            TxtAddress2.Text = dt.Rows(0).Item("Area")
            TxtAddress3.Text = dt.Rows(0).Item("Town")
            TxtAddress4.Text = dt.Rows(0).Item("County")
            TxtPostCode.Text = dt.Rows(0).Item("PostCode")
            TxtTelephone1.Text = dt.Rows(0).Item("Telephone")
            TxtTelephone2.Text = dt.Rows(0).Item("Telephone2")
            TxtFax.Text = dt.Rows(0).Item("Fax")
            TxteMail.Text = dt.Rows(0).Item("Email")
            TxtMemo.Text = dt.Rows(0).Item("Memo")
            cboWType.Text = dt.Rows(0).Item("ShopType")
        End Using
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode,QtyHangers,Value From QryShopStockDisplay Where SMLocation ='" + TxtShopRef.Text + "' AND QtyHangers <>'0' ORDER BY SMStockCode", conn)}
            adp.Fill(dt)
            With gridStock
                .DataSource = dt
                .AutoGenerateColumns = True
                .CellBorderStyle = DataGridViewCellBorderStyle.None
                .BackgroundColor = Color.LightCoral
                .DefaultCellStyle.SelectionBackColor = Color.Red
                .DefaultCellStyle.SelectionForeColor = Color.Yellow
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToResizeColumns = False
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                With .Columns
                    .Item(0).HeaderText = "Stock Code"
                    .Item(1).HeaderText = "Qty"
                    .Item(2).HeaderText = "Value"
                    .Item(2).DefaultCellStyle.Format = "C2"
                End With
            End With
        End Using
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT SMStockCode,MovementType,MovementQtyHangers,MovementDate,Reference from tblStockMovements where SMLocation='" & TxtShopRef.Text & "' And SMLocationType='Shop' Order By MovementDate", conn)}
            adp.Fill(dt)
            With gridTrans
                .DataSource = dt
                .AutoGenerateColumns = True
                .CellBorderStyle = DataGridViewCellBorderStyle.None
                .BackgroundColor = Color.LightCoral
                .DefaultCellStyle.SelectionBackColor = Color.Plum
                .DefaultCellStyle.SelectionForeColor = Color.Yellow
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AllowUserToResizeColumns = False
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .RowsDefaultCellStyle.BackColor = Color.LightSkyBlue
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                With .Columns
                    .Item(0).HeaderText = "Stock Code"
                    .Item(1).HeaderText = "Type"
                    .Item(2).HeaderText = "Qty"
                    .Item(3).HeaderText = "Date"
                End With
            End With
        End Using
        Dim a As Integer
        Dim b As Decimal
        For i As Integer = 0 To gridStock.Rows.Count - 1
            a += gridStock.Rows(i).Cells(1).Value
            b += gridStock.Rows(i).Cells(2).Value
        Next
        TxtTotalItems.Text = a.ToString()
        TxtTotalValue.Text = b.ToString()
        TxtTotalValue.Text = FormatCurrency(TxtTotalValue.Text)
    End Sub
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        If CmdOK.Text = "OK" Then Upd.SaveShops(TxtShopRef.Text, TxtShopName.Text, TxtAddress1.Text, TxtAddress2.Text, TxtAddress3.Text, TxtAddress4.Text, TxtPostCode.Text, TxtContactName.Text, TxtTelephone1.Text, TxtTelephone2.Text, TxtFax.Text, TxteMail.Text, TxtMemo.Text, cboWType.Text)
        If CmdOK.Text = "ADD" Then save.SaveShops(TxtShopRef.Text, TxtShopName.Text, TxtAddress1.Text, TxtAddress2.Text, TxtAddress3.Text, TxtAddress4.Text, TxtPostCode.Text, TxtContactName.Text, TxtTelephone1.Text, TxtTelephone2.Text, TxtFax.Text, TxteMail.Text, TxtMemo.Text, cboWType.Text)
        FGridShops.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        TxtShopName.Clear()
        TxtShopRef.Clear()
        TxtAddress1.Clear()
        TxtAddress2.Clear()
        TxtAddress3.Clear()
        TxtAddress4.Clear()
        TxtContactName.Clear()
        TxteMail.Clear()
        TxtFax.Clear()
        TxtMemo.Clear()
        TxtPostCode.Clear()
        TxtTelephone1.Clear()
        TxtTelephone2.Clear()
    End Sub
End Class