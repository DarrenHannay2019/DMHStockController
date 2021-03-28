Imports System.Data
Imports System.Data.SqlClient

Public Class CSystemLog
    Dim ut As New CUtils

    Public Sub SaveSystemLog(stockcode As String, supplierref As String, location As String, qty As Integer, movementtype As String, recordtype As String, mdate As Date, reference As String)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim ICmd As New SqlCommand()
            With ICmd
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblSystemLog (StockCode,SupplierRef,Location,Qty,MovementType,RecordType,MovementDate,Timestamp,Reference,CreatedBy) VALUES (@StockCode,@SupplierRef,@Location,@Qty,@MovementType,@RecordType,@MovementDate,@Timestamp,@Reference,@CreatedBy)"
                .Connection.Open()
                .Parameters.AddWithValue("@StockCode", stockcode)
                .Parameters.AddWithValue("@SupplierRef", supplierref)
                .Parameters.AddWithValue("@Location", location)
                .Parameters.AddWithValue("@Qty", qty)
                .Parameters.AddWithValue("@MovementType", movementtype)
                .Parameters.AddWithValue("@RecordType", recordtype)
                .Parameters.AddWithValue("@MovementDate", mdate)
                .Parameters.AddWithValue("@Timestamp", Date.Now)
                .Parameters.AddWithValue("@Reference", reference)
                .Parameters.AddWithValue("@CreatedBy", ut.GetUserName)
                .ExecuteNonQuery()
            End With
        End Using
    End Sub
End Class
