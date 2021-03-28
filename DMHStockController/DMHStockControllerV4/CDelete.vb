Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Public Class CCheck
    Dim ut As New CUtils
    Dim result As Integer
    Public Function SaveWarehouse() As Boolean
        Return True
    End Function
    Public Function SaveShops() As Boolean
        Return True
    End Function
    Public Function SaveSupplier() As Boolean
        Return True
    End Function
    Public Function SaveStock() As Boolean

        Return True
    End Function
    Public Function SavePOrders() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(DeliveriesID) as MaxRef from tblDeliveries"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function
    Public Function SaveWHAdjustHead() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(ID) as MaxRef from tblWarehouseAdjustments"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function

    Public Function SaveShopDelHead() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(DeliveriesID) as MaxRef from tblShopDeliveries"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function

    Public Function SaveShopAdjustHead() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(ID) as MaxRef from tblShopAdjustments"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function

    Public Function SaveShopTransHead() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(TransferID) as MaxRef from tblShopTransfers"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function

    Public Function SaveShopSalesHead() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(SalesID) as MaxRef from tblSales"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function

    Public Function SaveShopReturnsHead() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(ReturnsID) as MaxRef from tblReturns"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function
    Public Function SaveWHReturns() As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectCmd As New SqlCommand
            With selectCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT MAX(ID) as MaxRef from tblWReturns"
            End With
            result = selectCmd.ExecuteScalar
        End Using
        Return result
    End Function
    Public Function CheckStockCode(StockCode As String) As Boolean
        Dim result As Integer
        Dim returnresult As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim selectcmd As New SqlCommand
            With selectcmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT COUNT(*) AS numRows From tblStock WHERE StockCode =@StockCode"
                .Parameters.AddWithValue("@StockCode", StockCode)
                result = .ExecuteScalar
            End With
        End Using
        If result = 0 Then returnresult = True
        If result = 1 Then returnresult = False
        Return returnresult
    End Function
End Class
