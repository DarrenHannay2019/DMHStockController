Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.File

Public Class FSettings
    Dim ut As New CUtils
    Dim upd As New CUpdate
    Dim syslog As New CSystemLog

    Private Sub FSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using conn As New SqlConnection(ut.GetConnString())
            Dim adata As New DataSet()
            Dim SettingsDataAdapter As New SqlDataAdapter("SELECT * from tblCompanyDetails", conn)
            adata.Locale = System.Globalization.CultureInfo.InvariantCulture
            conn.Open()
            SettingsDataAdapter.Fill(adata, "tblCompanyDetails")
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
            txtVATRate.Text = adata.Tables("tblCompanyDetails").Rows(0).Item("VatRate").ToString("0.00")
            txtVATRate.Text = FormatPercent(txtVATRate.Text)
        End Using
        Using conn = New SqlConnection(ut.GetConnString())
            conn.Open()
            Using cmd As New SqlCommand("SELECT name from sys.databases", conn)
                Using dr As IDataReader = cmd.ExecuteReader()
                    While dr.Read
                        ComboBox1.Items.Add(dr(0).ToString())
                        ComboBox2.Items.Add(dr(0).ToString())
                    End While
                End Using
            End Using
        End Using
        If Directory.Exists("c:\DBBackup") Then
            For Each file As String In IO.Directory.GetFiles("C:\DBBackup")
                ComboBox3.Items.Add(Path.GetFileNameWithoutExtension(file))
            Next
        Else
            Directory.CreateDirectory("c:\DBBackup")
        End If
        ComboBox1.SelectedItem = "DMHStockv4"
        ComboBox2.SelectedItem = "DMHStockv4"
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updatecmd As New SqlCommand
            With updatecmd
                .Connection = conn
                .Connection.Open()
                .CommandText = " UPDATE tblCompanyDetails SET CompanyName = @CompanyName,Street = @Street,Area = @Area,Town = @Town,County = @County,PostCode= @PostCode, Telephone = Telephone,Fax = @Fax,VATRegistrationNo= @VATRegistrationNo,Email = @Email,Website = @Website,VATRate = @VATRate"
                With updatecmd.Parameters
                    .AddWithValue("@CompanyName", txtCompanyName.Text)
                    .AddWithValue("@Street", txtAdd1.Text)
                    .AddWithValue("@Area", txtAdd2.Text)
                    .AddWithValue("@Town", txtAdd3.Text)
                    .AddWithValue("@County", txtAdd4.Text)
                    .AddWithValue("@PostCode", txtPostCode.Text)
                    .AddWithValue("@Telephone", txtTelephone.Text)
                    .AddWithValue("@Fax", txtFax.Text)
                    .AddWithValue("@VATRegistrationNo", txtVATReg.Text)
                    .AddWithValue("@Email", txtEmail.Text)
                    .AddWithValue("@Website", txtWWW.Text)
                    .AddWithValue("@VATRate", CDec(txtVATRate.Text.ToString()))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you wish to cancel this input", "Cancel Input", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub
        If result = DialogResult.Yes Then Me.Close()
    End Sub

    Private Sub CmdRestore_Click(sender As Object, e As EventArgs) Handles CmdRestore.Click
        Try
            Dim con2 As New SqlConnection(ut.GetBkConnString())
            Dim alterquery As String = "ALTER DATABASE " & ComboBox2.Text & " SET Single_User WITH Rollback Immediate"
            Dim altercommand As New SqlCommand(alterquery, con2)
            con2.Open()
            altercommand.ExecuteNonQuery()
            lblRestoreInfo.Text = "Database has been set to Single user mode"
            con2.Close()
            Dim restorecommand = New SqlCommand("Restore database " & ComboBox2.Text.Trim & " from disk='C:\DBBackup\" & ComboBox3.Text & ".bak'", con2)
            con2.Open()
            restorecommand.ExecuteNonQuery()
            lblRestoreInfo.Text = lblRestoreInfo.Text & vbNewLine & "Database Restore has been completed successfully"
            con2.Close()
        Catch ex As SQlException
            MsgBox(ex.Message)
        Finally
            Dim con2 As New SqlConnection(ut.GetBkConnString())
            Dim Alter2 As String = "ALTER DATABASE " & ComboBox2.Text.Trim & " SET Multi_User"
            Dim Alter2Cmd As SqlCommand = New SqlCommand(Alter2, con2)
            con2.Open()
            Alter2Cmd.ExecuteNonQuery()
            con2.Close()
            lblRestoreInfo.Text = lblRestoreInfo.Text & vbNewLine & "Database mode set to multiuser"
        End Try
        syslog.SaveSystemLog("ALL", "ALL", "ALL", 0, "Backup/Restore", "Full Restore", Date.Now, "Full System Db Restore")
    End Sub

    Private Sub CmdBackup_Click(sender As Object, e As EventArgs) Handles CmdBackup.Click
        Try
            Dim t As String
            Dim d As String
            Dim m As String
            Dim y As String
            t = Date.Now.Second.ToString + Date.Now.Minute.ToString + Date.Now.Hour.ToString
            d = Date.Now.Day.ToString
            m = Date.Now.Month.ToString
            y = Date.Now.Year.ToString
            Dim uniqueid As String
            uniqueid = t & d & m & y
            Dim con2 As New SqlConnection(ut.GetBkConnString())
            Using cmd As New SqlCommand("Backup database " & ComboBox1.Text.Trim & " to  disk='C:\DBBackup\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak'", con2)
                con2.Open()
                cmd.ExecuteNonQuery()
                con2.Close()
                lblBackupinfo.Text = "Database Backup completed successfully" & vbCrLf & "You can find the backup file in c:\DBBackup\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak"
            End Using
            Using cmd As New SqlCommand("Backup database " & ComboBox1.Text.Trim & " to  disk='F:\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak'", con2)
                con2.Open()
                cmd.ExecuteNonQuery()
                con2.Close()
                lblBackupinfo.Text = lblBackupinfo.Text + "Database Backup completed successfully" & vbCrLf & "You can find the backup file in F:\" & ComboBox1.Text.Trim & "_" & uniqueid & ".bak"
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        syslog.SaveSystemLog("ALL", "ALL", "ALL", 0, "Backup/Restore", "Full Backup", Date.Now, "Full System Db Backup")
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage2 Then
            ComboBox3.Items.Clear()
            For Each file As String In IO.Directory.GetFiles("C:\DBBackup\")
                ComboBox3.Items.Add(Path.GetFileNameWithoutExtension(file))
            Next
        End If
    End Sub
End Class