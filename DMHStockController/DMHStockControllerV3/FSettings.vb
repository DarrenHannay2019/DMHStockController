Imports System.Data.SqlClient

Public Class FSettings
    Dim connection As New SqlConnection("Initial Catalog=DMHStockv1;Data Source=(local)\SQLEXPRESS2;Persist Security Info=False;Integrated Security=true;")
    Private Sub FSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create a DataSet

        Dim adata As New DataSet()
        Dim SettingsDataAdapter As New SqlDataAdapter("SELECT * from tblCompanyDetails", connection)

        adata.Locale = System.Globalization.CultureInfo.InvariantCulture

        Dim vatcon As String
        Try
            connection.Open()
            SettingsDataAdapter.Fill(adata, "tblCompanyDetails")
            ' cboCurrentSeason.DataSource = cbodata
            ' cboCurrentSeason.DisplayMember = "SeasonName"
            ' cboCurrentSeason.ValueMember = "SeasonName"
            '    For Each dRow As DataRow In cbodata.Tables("tblSeasons").Rows
            'cboCurrentSeason.Items.Add(dRow.Item(0).ToString)
            '  Next
            txtCompanyName.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("CompanyName")
            txtAdd1.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Street").ToString()
            txtAdd2.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Area").ToString()
            txtAdd3.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Town").ToString()
            txtAdd4.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("County").ToString()
            txtPostCode.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("PostCode").ToString()
            txtTelephone.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Telephone").ToString()
            txtFax.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Fax").ToString()
            txtVATReg.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("VATRegistrationNo").ToString()
            txtEmail.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Email").ToString()
            txtWWW.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("Website").ToString()
            'cboCurrentSeason.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("CurrentSeason").ToString()
            vatcon = adata.Tables("tblCompanyDetails").Rows(0).Item("VATRate").ToString()
            txtVATRate.Text = FormatPercent(vatcon, 1)
            connection.Close()
        Catch ex As SqlException
            Return
        End Try
    End Sub

    Private Sub cmdFix_Click(sender As Object, e As EventArgs) Handles cmdFix.Click
        ' Create a DataSet
        Dim cbodata As New DataSet()
        Dim adata As New DataSet()
        Dim SettingsDataAdapter As New SqlDataAdapter("SELECT * from tblSettings", connection)
        Dim SeasonDataAdapter As New SqlDataAdapter("SELECT SeasonName from tblSeasons", connection)
        Dim fixDelNo As String = "SELECT MAX(DeliveryID) as NextOrderNo From tblDeliveries"
        Dim fixSalesDelNo As String = "Select MAX(DeliveryID) as NextSalesDelNo from tblShopDeliveries"

        Dim nextOrderNos As Long
        Dim nextSalesDelNos As Long
        nextOrderNos = fixDelNo
        nextSalesDelNos = fixSalesDelNo
        SettingsDataAdapter.Fill(adata, "tblSettings")
        nextOrderNos = adata.Tables("tblSettings").Rows(0).Item("NextOrderNo") + 1
        nextSalesDelNos = adata.Tables("tblSettings").Rows(0).Item("NextSalesDelNo") + 1
        Dim updatefix As String = "UPDATE tblSettings SET NextOrderNo = @NextOrderNos, NextSalesDelNo = @NextSalesDelNos"
        Dim com As New SqlCommand(updatefix, connection)
        com.Connection.Open()
        com.Parameters.AddWithValue("@NextOrderNos", nextOrderNos.ToString)
        com.Parameters.AddWithValue("@NextSalesDelNos", nextSalesDelNos.ToString)
        com.ExecuteNonQuery()
        com.Connection.Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        UpdateSettingsTable()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If MsgBox("Do You wish to close the settings box without saving!", MsgBoxStyle.YesNo, Application.ProductName) = vbYes Then Me.Close()
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        UpdateSettingsTable()
    End Sub
    Private Sub UpdateSettingsTable()
        ' Create a DataSet
        Dim cbodata As New DataSet()
        Dim adata As New DataSet()
        Dim SettingsDataAdapter As New SqlDataAdapter("SELECT * from tblCompanyDetails", connection)
        Dim SeasonDataAdapter As New SqlDataAdapter("SELECT SeasonName from tblSeasons", connection)
        Try
            Dim updatedb As String = " UPDATE tblCompanyDetails SET CompanyName = @CompanyName,Street = @Street,Area = @Area,Town = @Town,County = @County,PostCode= @PostCode, Telephone = Telephone,Fax = @Fax,VATRegistrationNo= @VATRegistrationNo,Email = @Email,Website = @Website,VATRate = @VATRate"
            Me.Validate()
            Dim com As New SqlCommand(updatedb, connection)
            com.Connection.Close()
            com.Connection.Open()
            com.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text)
            com.Parameters.AddWithValue("@Street", txtAdd1.Text)
            com.Parameters.AddWithValue("@Area", txtAdd2.Text)
            com.Parameters.AddWithValue("@Town", txtAdd3.Text)
            com.Parameters.AddWithValue("@County", txtAdd4.Text)
            com.Parameters.AddWithValue("@PostCode", txtPostCode.Text)
            com.Parameters.AddWithValue("@Telephone", txtTelephone.Text)
            com.Parameters.AddWithValue("@Fax", txtFax.Text)
            com.Parameters.AddWithValue("@VATRegistrationNo", txtVATReg.Text)
            com.Parameters.AddWithValue("@Email", txtEmail.Text)
            com.Parameters.AddWithValue("@Website", txtWWW.Text)
            com.Parameters.AddWithValue("@VATRate", txtVATRate.Text.ToString())
            'com.Parameters.AddWithValue("@CurrentSeason", cboCurrentSeason.Text)
            com.ExecuteNonQuery()
            com.Connection.Close()
            MsgBox("Update Successful", MsgBoxStyle.Information, "DMH Stock Master v2")
        Catch ex As SqlException
            MsgBox("Update Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, "Stock Master v2")
        End Try
    End Sub
End Class