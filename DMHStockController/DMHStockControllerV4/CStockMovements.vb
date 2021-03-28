Imports System.Data
Imports System.Data.SqlClient
Public Class CStockMovements
    Dim ut As New CUtils()
    Public Sub SaveStockMovements(stockcode As String, supplierref As String, location As String, locationtype As String, hqty As Integer, bqty As Integer, movementtype As String, movedate As Date, value As Decimal, IReference As String, TRef As Integer)
        Try
            Using conn As New SqlConnection(ut.GetConnString())
                Dim insertcmd As New SqlCommand
                With insertcmd
                    .CommandText = "INSERT INTO tblStockMovements(SMStockCode,SMSupplierRef,SMLocation,SMLocationType,MovementQtyHangers,MovementQtyBoxes,MovementType,MovementDate,MovementValue,Reference,TransferReference,SMCreatedBy,SMCreatedDate) VALUES(@SMStockCode,@SMSupplierRef,@SMLocation,@SMLocationType,@MovementQtyHangers,@MovementQtyBoxes,@MovementType,@MovementDate,@MovementValue,@Reference,@TransferReference,@SMCreatedBy,@SMCreatedDate)"
                    .CommandType = CommandType.Text
                    .Connection = conn
                    .Parameters.AddWithValue("@SMStockCode", stockcode)
                    .Parameters.AddWithValue("@SMSupplierRef", supplierref)
                    .Parameters.AddWithValue("@SMLocation", location)
                    .Parameters.AddWithValue("@SMLocationType", locationtype)
                    .Parameters.AddWithValue("@MovementQtyHangers", CInt(hqty))
                    .Parameters.AddWithValue("@MovementQtyBoxes", CInt(bqty))
                    .Parameters.AddWithValue("@MovementType", movementtype)
                    .Parameters.AddWithValue("@MovementDate", CDate(movedate))
                    .Parameters.AddWithValue("@MovementValue", CDec(value))
                    .Parameters.AddWithValue("@Reference", IReference)
                    .Parameters.AddWithValue("@TransferReference", CInt(TRef))
                    .Parameters.AddWithValue("@SMCreatedBy", ut.GetUserName())
                    .Parameters.AddWithValue("@SMCreatedDate", Date.Now)
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            End Using
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
    End Sub
    Public Sub DeleteZeroStockMovements(movementtype As String, transferref As Integer, reference As String, dte As Date)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim deleteCmd As New SqlCommand
            With deleteCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM tblStockMovements WHERE movementtype = @MovementType AND TransferReference = @TransferReference AND Reference = @Reference AND MovementDate = @MovementDate AND MovementQtyHangers = '0' AND MovementValue = '0'"
                With .Parameters
                    .AddWithValue("@MovementType", movementtype)
                    .AddWithValue("@TransferReference", CInt(transferref))
                    .AddWithValue("@Reference", reference)
                    .AddWithValue("@MovementDate", dte)
                End With
                .ExecuteNonQuery()
            End With
        End Using
    End Sub
    Public Sub DeleteStockMovements(movementtype As String, transferref As Integer, reference As String, dte As Date)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim deleteCmd As New SqlCommand
            With deleteCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM tblStockMovements WHERE movementtype = @MovementType AND TransferReference = @TransferReference AND Reference = @Reference AND MovementDate = @MovementDate"
                With .Parameters
                    .AddWithValue("@MovementType", movementtype)
                    .AddWithValue("@TransferReference", CInt(transferref))
                    .AddWithValue("@Reference", reference)
                    .AddWithValue("@MovementDate", dte)
                End With
                .ExecuteNonQuery()
            End With
        End Using
    End Sub
    Public Function ChkStockMovements(movementtype As String, transferref As Integer, reference As String, dte As Date) As Integer
        Dim result As Integer = 0
        Using conn As New SqlConnection(ut.GetConnString())
            Dim deleteCmd As New SqlCommand
            With deleteCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(StockMovementID) as ID FROM tblStockMovements WHERE movementtype = @MovementType AND TransferReference = @TransferReference AND Reference = @Reference AND MovementDate = @MovementDate AND MovementQtyHangers < 0"
                With .Parameters
                    .AddWithValue("@MovementType", movementtype)
                    .AddWithValue("@TransferReference", CInt(transferref))
                    .AddWithValue("@Reference", reference)
                    .AddWithValue("@MovementDate", dte)
                End With
                result = .ExecuteNonQuery()
            End With
        End Using
        Return result
    End Function
    Public Function ChkStockMovementsplus(movementtype As String, transferref As Integer, reference As String, dte As Date) As Integer
        Dim result As Integer = 0
        Using conn As New SqlConnection(ut.GetConnString())
            Dim deleteCmd As New SqlCommand
            With deleteCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(StockMovementID) as ID FROM tblStockMovements WHERE movementtype = @MovementType AND TransferReference = @TransferReference AND Reference = @Reference AND MovementDate = @MovementDate AND MovementQtyHangers > 0"
                With .Parameters
                    .AddWithValue("@MovementType", movementtype)
                    .AddWithValue("@TransferReference", CInt(transferref))
                    .AddWithValue("@Reference", reference)
                    .AddWithValue("@MovementDate", dte)
                End With
                result = .ExecuteNonQuery()
            End With
        End Using
        Return result
    End Function
End Class
