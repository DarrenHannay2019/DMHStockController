Imports System.Data.SqlClient
Public Class FSuppliers
    Dim save As New CSave
    Dim Upd As New CUpdate
    Dim ut As New CUtils
    Dim connstring As String = ut.GetConnString()

    Private Sub FSuppliers_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CmdOK.Text = "OK" Then LoadOld()
    End Sub
    Private Sub LoadOld()
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * From tblSuppliers Where SupplierRef = '" + TxtSupplierRef.Text.ToString() + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            With Me
                .TxtSupplierRef.Enabled = False
                .TxtSupplierName.Text = dt.Rows(0).Item("SupplierName")
                .TxtContactName.Text = dt.Rows(0).Item("ContactName")
                .TxtAddress1.Text = dt.Rows(0).Item("Address1")
                .TxtAddress2.Text = dt.Rows(0).Item("Address2")
                .TxtAddress3.Text = dt.Rows(0).Item("Address3")
                .TxtAddress4.Text = dt.Rows(0).Item("Address4")
                .TxtPostCode.Text = dt.Rows(0).Item("PostCode")
                .TxtTelephone.Text = dt.Rows(0).Item("Telephone")
                .TxtTelephone2.Text = dt.Rows(0).Item("Telephone2")
                .TxtFax.Text = dt.Rows(0).Item("Fax")
                .TxteMail.Text = dt.Rows(0).Item("eMail")
                .txtMemo.Text = dt.Rows(0).Item("Memo")
            End With
        End Using
        Using conn As New SqlConnection(connstring)
            Dim dt As New DataTable
            Dim adp As New SqlDataAdapter With {.SelectCommand = New SqlCommand("SELECT * FROM qrySuppliersTransDisplay where SupplierRef = '" + TxtSupplierRef.Text + "'", conn)}
            conn.Open()
            adp.Fill(dt)
            With gridTrans
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .DataSource = dt
                With .Columns
                    .Item(0).Visible = True
                    .Item(0).HeaderText = "Delivery No"
                    .Item(1).Visible = False
                    .Item(2).Visible = True
                    .Item(2).HeaderText = "Stock Code"
                    .Item(3).Visible = True
                    .Item(3).HeaderText = "Qty"
                    .Item(4).Visible = True
                    .Item(4).HeaderText = "Cost"
                    .Item(4).DefaultCellStyle.Format = "c2"
                    .Item(5).Visible = True
                    .Item(5).HeaderText = "Del Date"
                End With
            End With
        End Using
    End Sub
    Private Sub TxtSupplierRef_Leave(sender As Object, e As EventArgs) Handles TxtSupplierRef.Leave
        TxtSupplierRef.Text = UCase(TxtSupplierRef.Text)
    End Sub

    Private Sub TxtSupplierName_Leave(sender As Object, e As EventArgs) Handles TxtSupplierName.Leave
        TxtSupplierName.Text = StrConv(TxtSupplierName.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub TxtContactName_Leave(sender As Object, e As EventArgs) Handles TxtContactName.Leave
        TxtContactName.Text = StrConv(TxtContactName.Text, VbStrConv.ProperCase)
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

    Private Sub TxtPostCode_Leave(sender As Object, e As EventArgs) Handles TxtPostCode.Leave
        TxtPostCode.Text = UCase(TxtPostCode.Text)
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        If CmdOK.Text = "OK" Then Upd.SaveSupplier(TxtSupplierRef.Text, TxtSupplierName.Text, TxtAddress1.Text, TxtAddress2.Text, TxtAddress3.Text, TxtAddress4.Text, TxtPostCode.Text, TxtContactName.Text, TxtTelephone.Text, TxtTelephone2.Text, TxtFax.Text, TxteMail.Text, txtMemo.Text)
        If CmdOK.Text = "ADD" Then save.SaveSupplier(TxtSupplierRef.Text, TxtSupplierName.Text, TxtAddress1.Text, TxtAddress2.Text, TxtAddress3.Text, TxtAddress4.Text, TxtPostCode.Text, TxtContactName.Text, TxtTelephone.Text, TxtTelephone2.Text, TxtFax.Text, TxteMail.Text, txtMemo.Text)
        FGridSuppliers.TsbRefresh.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        TxtSupplierName.Clear()
        TxtSupplierRef.Clear()
        TxtAddress1.Clear()
        TxtAddress2.Clear()
        TxtAddress3.Clear()
        TxtAddress4.Clear()
        TxtContactName.Clear()
        TxteMail.Clear()
        TxtFax.Clear()
        txtMemo.Clear()
        TxtPostCode.Clear()
        TxtTelephone.Clear()
        TxtTelephone2.Clear()
    End Sub
End Class