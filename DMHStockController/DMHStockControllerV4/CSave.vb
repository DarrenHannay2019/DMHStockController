Imports System.Data
Imports System.Data.SqlClient

Public Class CSave
    Dim ut As New CUtils
    Dim username As String = ut.GetUserName()
    Public Function SaveWarehouse(WarehouseRef As String, WarehouseName As String, Address1 As String, Address2 As String, Address3 As String, Address4 As String, PostCode As String, ContactName As String, Telephone As String, Telephone2 As String, Fax As String, eMail As String, Memo As String, WarehouseType As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand
            With cmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblWarehouses (WarehouseRef,WarehouseName,Address1,Address2,Address3,Address4,PostCode,ContactName,Telephone,Telephone2,Fax,eMail,WarehouseType,Memo,CreatedBy,CreatedDate) VALUES (@WarehouseRef,@WarehouseName,@Address1,@Address2,@Address3,@Address4,@PostCode,@ContactName,@Telephone,@Telephone2,@Fax,@eMail,@WarehouseType,@Memo,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@WarehouseName", WarehouseName)
                    .AddWithValue("@Address1", Address1)
                    .AddWithValue("@Address2", Address2)
                    .AddWithValue("@Address3", Address3)
                    .AddWithValue("@Address4", Address4)
                    .AddWithValue("@PostCode", PostCode)
                    .AddWithValue("@ContactName", ContactName)
                    .AddWithValue("@Telephone", Telephone)
                    .AddWithValue("@Telephone2", Telephone2)
                    .AddWithValue("@Fax", Fax)
                    .AddWithValue("@eMail", eMail)
                    .AddWithValue("@Memo", Memo)
                    .AddWithValue("@WarehouseType", WarehouseType)
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShops(ShopRef As String, ShopName As String, Address1 As String, Address2 As String, Address3 As String, Address4 As String, PostCode As String, ContactName As String, Telephone As String, Telephone2 As String, Fax As String, eMail As String, Memo As String, ShopType As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand
            With cmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShops (ShopRef,ShopName,ContactName,Street,Area,Town,County,Country,PostCode,Telephone,Telephone2,Fax,eMail,ShopType,Memo,CreatedBy,CreatedDate) VALUES (@ShopRef,@ShopName,@ContactName,@Street,@Area,@Town,@County,@Country,@PostCode,@Telephone,@Telephone2,@Fax,@eMail,@ShopType,@Memo,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@ShopName", ShopName)
                    .AddWithValue("@Street", Address1)
                    .AddWithValue("@Area", Address2)
                    .AddWithValue("@Town", Address3)
                    .AddWithValue("@County", Address4)
                    .AddWithValue("@Country", "UK")
                    .AddWithValue("@PostCode", PostCode)
                    .AddWithValue("@ContactName", ContactName)
                    .AddWithValue("@Telephone", Telephone)
                    .AddWithValue("@Telephone2", Telephone2)
                    .AddWithValue("@Fax", Fax)
                    .AddWithValue("@eMail", eMail)
                    .AddWithValue("@Memo", Memo)
                    .AddWithValue("@ShopType", ShopType)
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveSupplier(SupplierRef As String, SupplierName As String, Address1 As String, Address2 As String, Address3 As String, Address4 As String, PostCode As String, ContactName As String, Telephone As String, Telephone2 As String, Fax As String, eMail As String, Memo As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand
            With cmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblSuppliers (SupplierRef,SupplierName,Address1,Address2,Address3,Address4,PostCode,ContactName,Telephone,Telephone2,Fax,eMail,Memo,CreatedBy,CreatedDate) VALUES (@SupplierRef,@SupplierName,@Address1,@Address2,@Address3,@Address4,@PostCode,@ContactName,@Telephone,@Telephone2,@Fax,@eMail,@Memo,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@SupplierRef", SupplierRef)
                    .AddWithValue("@SupplierName", SupplierName)
                    .AddWithValue("@Address1", Address1)
                    .AddWithValue("@Address2", Address2)
                    .AddWithValue("@Address3", Address3)
                    .AddWithValue("@Address4", Address4)
                    .AddWithValue("@PostCode", PostCode)
                    .AddWithValue("@ContactName", ContactName)
                    .AddWithValue("@Telephone", Telephone)
                    .AddWithValue("@Telephone2", Telephone2)
                    .AddWithValue("@Fax", Fax)
                    .AddWithValue("@eMail", eMail)
                    .AddWithValue("@Memo", Memo)
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SavePOrders(supplierRef As String, suppliername As String, locationref As String, locationname As String, stockcode As String, totalg As Integer, netamount As Decimal, commission As Decimal, delcharge As Decimal, totalv As Decimal, dte As Date, notes As String, invoice As String, shipper As String, shipperinv As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim insCmd As New SqlCommand
            With insCmd
                .Connection = conn
                .CommandText = "INSERT INTO tblDeliveries (OurRef,SupplierRef,SupplierName,LocationRef,LocationName,StockCode,DQtyGarments,DQtyBoxes,DQtyHangers,TotalGarments,TotalBoxes,TotalHangers,NetAmount,DeliveryCharge,Commission,TotalAmount,DeliveryDate,DeliveryType,ConfirmedDate,Notes,InvoiceNo,Shipper,ShipperInvoice,CreatedBy,CreatedDate) VALUES (@OurRef,@SupplierRef,@SupplierName,@LocationRef,@LocationName,@StockCode,@DQtyGarments,@DQtyBoxes,@DQtyHangers,@TotalGarments,@TotalBoxes,@TotalHangers,@NetAmount,@DeliveryCharge,@Commission,@TotalAmount,@DeliveryDate,@DeliveryType,@ConfirmedDate,@Notes,@InvoiceNo,@Shipper,@ShipperInvoice,@CreatedBy,@CreatedDate)"
                .CommandType = CommandType.Text
                With .Parameters
                    .AddWithValue("@OurRef", stockcode)
                    .AddWithValue("@SupplierRef", supplierRef)
                    .AddWithValue("@SupplierName", suppliername)
                    .AddWithValue("@LocationRef", locationref)
                    .AddWithValue("@LocationName", locationname)
                    .AddWithValue("@StockCode", stockcode)
                    .AddWithValue("@DQtyGarments", CInt(totalg))
                    .AddWithValue("@DQtyBoxes", "0")
                    .AddWithValue("@DQtyHangers", CInt(totalg))
                    .AddWithValue("@TotalGarments", CInt(totalg))
                    .AddWithValue("@TotalBoxes", "0")
                    .AddWithValue("@TotalHangers", CInt(totalg))
                    .AddWithValue("@NetAmount", CDec(netamount))
                    .AddWithValue("@DeliveryCharge", CDec(delcharge))
                    .AddWithValue("@Commission", CDec(commission))
                    .AddWithValue("@TotalAmount", CDec(totalv))
                    .AddWithValue("@DeliveryDate", CDate(dte))
                    .AddWithValue("@DeliveryType", "Confirmed")
                    .AddWithValue("@ConfirmedDate", CDate(dte))
                    .AddWithValue("@Notes", notes)
                    .AddWithValue("@InvoiceNo", invoice)
                    .AddWithValue("@Shipper", shipper)
                    .AddWithValue("@ShipperInvoice", shipperinv)
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Now)
                End With
                .Connection.Open()
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWHAdjustHead(WarehouseRef As String, Reference As String, TotalLossItems As Integer, TotalGainItems As Integer, MovementDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblWarehouseAdjustments(WarehouseRef,Reference,TotalLossItems,TotalGainItems,MovementDate,CreatedBy,CreatedDate) VALUES (@WarehouseRef,@Reference,@TotalLossItems,@TotalGainItems,@MovementDate,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalLossItems", CInt(TotalLossItems))
                    .AddWithValue("@TotalGainItems", CInt(TotalGainItems))
                    .AddWithValue("@MovementDate", CDate(MovementDate))
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWhAdjustLines(WarehouseAdjustID As Integer, StockCode As String, MovementType As String, qty As Integer, Value As Decimal) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblWarehouseAdjustmentsLines(WarehouseAdjustID,StockCode,MovementType,Qty,Value) VALUES (@WarehouseAdjustID,@StockCode,@MovementType,@Qty,@Value)"
                With .Parameters
                    .AddWithValue("@WarehouseAdjustID", CInt(WarehouseAdjustID))
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@MovementType", MovementType)
                    .AddWithValue("@Qty", CInt(qty))
                    .AddWithValue("@Value", CDec(Value))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveSHAdjustHead(ShopRef As String, Reference As String, TotalLossItems As Integer, TotalGainItems As Integer, MovementDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShopAdjustments(ShopRef,Reference,TotalLossItems,TotalGainItems,MovementDate,CreatedBy,CreatedDate) VALUES (@ShopRef,@Reference,@TotalLossItems,@TotalGainItems,@MovementDate,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalLossItems", CInt(TotalLossItems))
                    .AddWithValue("@TotalGainItems", CInt(TotalGainItems))
                    .AddWithValue("@MovementDate", CDate(MovementDate))
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveSHAdjustLines(ShopAdjustID As Integer, StockCode As String, MovementType As String, qty As Integer, Value As Decimal) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShopAdjustmentsLines(ShopAdjustID,StockCode,MovementType,Qty,Value) VALUES (@ShopAdjustID,@StockCode,@MovementType,@Qty,@Value)"
                With .Parameters
                    .AddWithValue("@ShopAdjustID", CInt(ShopAdjustID))
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@MovementType", MovementType)
                    .AddWithValue("@Qty", CInt(qty))
                    .AddWithValue("@Value", CDec(Value))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopDelHead(ShopRef As String, ShopName As String, WarehouseRef As String, WarehousesName As String, Reference As String, TotalItems As Integer, DeliveryDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShopDeliveries(ShopRef,ShopName,WarehouseRef,WarehouseName,Reference,TotalItems,DeliveryDate,DeliveryType,ConfirmedDate,Notes,CreatedBy,CreatedDate) VALUES (@ShopRef,@ShopName,@WarehouseRef,@WarehouseName,@Reference,@TotalItems,@DeliveryDate,@DeliveryType,@ConfirmedDate,@Notes,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@ShopName", ShopName)
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@WarehouseName", WarehousesName)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalItems", CInt(TotalItems))
                    .AddWithValue("@DeliveryDate", CDate(DeliveryDate))
                    .AddWithValue("@DeliveryType", "Confirmed")
                    .AddWithValue("@ConfirmedDate", CDate(DeliveryDate))
                    .AddWithValue("@Notes", "")
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopDelLines(SDeliveriesID As Integer, SStockCode As String, DeliveredQty As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShopDeliveriesLines (SDeliveriesID,SStockCode,DeliveredQty) VALUES (@SDeliveriesID,@SStockCode,@DeliveredQty)"
                With .Parameters
                    .AddWithValue("@SDeliveriesID", CInt(SDeliveriesID))
                    .AddWithValue("@SStockCode", SStockCode)
                    .AddWithValue("@DeliveredQty", CInt(DeliveredQty))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopTransHead(Reference As String, TransferDate As Date, ShopRef As String, ShopName As String, ToShopRef As String, ToShopName As String, TotalQtyOut As Integer, TotalQtyIn As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShopTransfers (Reference,TransferDate,ShopRef,ShopName,ToShopRef,ToShopName,TotalQtyOut,TotalQtyIn,CreatedBy,CreatedDate) VALUES (@Reference,@TransferDate,@ShopRef,@ShopName,@ToShopRef,@ToShopName,@TotalQtyOut,@TotalQtyIn,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TransferDate", CDate(TransferDate))
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@ShopName", ShopName)
                    .AddWithValue("@ToShopRef", ToShopRef)
                    .AddWithValue("@ToShopName", ToShopName)
                    .AddWithValue("@TotalQtyOut", CInt(TotalQtyOut))
                    .AddWithValue("@TotalQtyIn", CInt(TotalQtyIn))
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopTransLines(TransferID As Integer, smtoid As Integer, smtiid As Integer, StockCode As String, CurrQty As Integer, TOQty As Integer, TIQty As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblShopTransferLines (TransferID,SMTOID,SMTIID,StockCode,CurrentQty,TOQty,TIQty) VALUES (@TransferID,@SMTOID,@SMTIID,@StockCode,@CurrentQty,@TOQty,@TIQty)"
                With .Parameters
                    .AddWithValue("@TransferID", TransferID)
                    .AddWithValue("@SMTOID", CInt(smtoid))
                    .AddWithValue("@SMTIID", CInt(smtiid))
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@CurrentQty", CInt(CurrQty))
                    .AddWithValue("@TOQty", CInt(TOQty))
                    .AddWithValue("@TIQty", CInt(TIQty))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopSalesHead(shopref As String, shopname As String, TransactionDate As Date, TotalQty As Integer, TotalValue As Decimal) As Boolean
        Try
            Using conn As New SqlConnection(ut.GetConnString())
                Dim inscmd As New SqlCommand
                With inscmd
                    .Connection = conn
                    .Connection.Open()
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO tblSales (ShopRef,ShopName,SAReference,TransactionDate,TotalQty,TotalValue,CreatedBy,CreatedDate) VALUES (@ShopRef,@ShopName,@SAReference,@TransactionDate,@TotalQty,@TotalValue,@CreatedBy,@CreatedDate)"
                    With .Parameters
                        .AddWithValue("@ShopRef", shopref)
                        .AddWithValue("@ShopName", shopname)
                        .AddWithValue("@SAReference", "0")
                        .AddWithValue("@TransactionDate", TransactionDate)
                        .AddWithValue("@TotalQty", TotalQty)
                        .AddWithValue("@TotalValue", TotalValue)
                        .AddWithValue("@CreatedBy", username)
                        .AddWithValue("@CreatedDate", Date.Now)
                    End With
                    .ExecuteNonQuery()
                End With
            End Using
            Return True
        Catch ex As SqlException
            MsgBox("Record Creation Failed because of" & vbCrLf & ex.ErrorCode & "  " & ex.Message, MsgBoxStyle.Information, Application.ProductName)
        End Try
        Return True
    End Function
    Public Function SaveShopSalesLines(salesID As Integer, stockcode As String, CurrentQty As Integer, QtySold As Integer, SalesAmount As Decimal, StockID As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblSalesLines (SalesID,StockCode,CurrentQty,QtySold,SalesAmount,StockMovementID) VALUES (@SalesID,@StockCode,@CurrentQty,@QtySold,@SalesAmount,@StockMovementID)"
                With .Parameters
                    .AddWithValue("@SalesID", salesID)
                    .AddWithValue("@StockCode", stockcode)
                    .AddWithValue("@CurrentQty", CurrentQty)
                    .AddWithValue("@QtySold", QtySold)
                    .AddWithValue("@SalesAmount", SalesAmount)
                    .AddWithValue("@StockMovementID", StockID)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function

    Public Function deleteShopSalesLines(salesID As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "DELETE from tblSalesLines WHERE SalesID = @SalesID AND QtySold = @QtySold AND SalesAmount = @SalesAmount;"
                With .Parameters
                    .AddWithValue("@SalesID", salesID)
                    .AddWithValue("@QtySold", "0")
                    .AddWithValue("@SalesAmount", "0.00")

                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True

    End Function

    Public Function SaveShopReturnsHead(ShopRef As String, WarehouseRef As String, Reference As String, TotalItems As Integer, TransactionDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblReturns(ShopRef,WarehouseRef,Reference,TotalItems,TransactionDate,CreatedBy,CreatedDate) VALUES (@ShopRef,@WarehouseRef,@Reference,@TotalItems,@TransactionDate,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalItems", CInt(TotalItems))
                    .AddWithValue("@TransactionDate", CDate(TransactionDate))
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopReturnsLines(ReturnID As Integer, StockCode As String, Qty As Integer, Value As Decimal) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblReturnLines (ReturnID,StockCode,Qty,Value) VALUES (@ReturnID,@StockCode,@Qty,@Value)"
                With .Parameters
                    .AddWithValue("@ReturnID", ReturnID)
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@Qty", Qty)
                    .AddWithValue("@Value", Value)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveStock(stockcode As String, supplierref As String, costvalue As Decimal, totalG As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim insertCmd As New SqlCommand
            With insertCmd
                .Connection = conn
                .CommandText = " INSERT INTO tblStock (StockCode,SupplierRef,DeadCode,DeliveredQtyHangers,AmountTaken,CostValue,PCMarkUp,ZeroQty,CreatedBy,CreatedDate,Season) VALUES (@StockCode,@SupplierRef,@DeadCode,@DeliveredQtyHangers,@AmountTaken,@CostValue,@PCMarkUp,@ZeroQty,@CreatedBy,@CreatedDate,@Season)"
                .CommandType = CommandType.Text
                With .Parameters
                    .AddWithValue("@ZeroQty", "0")
                    .AddWithValue("@StockCode", stockcode)
                    .AddWithValue("@SupplierRef", supplierref)
                    .AddWithValue("@DeadCode", "0")
                    .AddWithValue("@AmountTaken", "0.00")
                    .AddWithValue("@CostValue", CDec(costvalue))
                    .AddWithValue("@PCMarkUp", "0")
                    .AddWithValue("@Season", "ALL")
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                    .AddWithValue("@DeliveredQtyHangers", CInt(totalG))
                End With
                .Connection.Open()
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWHReturnHead(WarehouseRef As String, SWarehouseRef As String, Reference As String, TotalItems As Integer, TransactionDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblWReturns (WarehouseRef,SWarehouseRef,Reference,TotalItems,TransactionDate,CreatedBy,CreatedDate) VALUES (@WarehouseRef,@SWarehouseRef,@Reference,@TotalItems,@TransactionDate,@CreatedBy,@CreatedDate)"
                With .Parameters
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@SWarehouseRef", SWarehouseRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalItems", CInt(TotalItems))
                    .AddWithValue("@TransactionDate", CDate(TransactionDate))
                    .AddWithValue("@CreatedBy", username)
                    .AddWithValue("@CreatedDate", Date.Now)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWhReturnLines(WReturnID As Integer, StockCode As String, Qty As Integer, Value As Decimal) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO tblWReturnLines (WReturnID,StockCode,Qty,Value) VALUES (@WReturnID,@StockCode,@Qty,@Value)"
                With .Parameters
                    .AddWithValue("@WReturnID", CInt(WReturnID))
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@Qty", CInt(Qty))
                    .AddWithValue("@Value", CDec(Value))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
End Class
