Imports System.Data.SqlClient
Imports System.Data
Public Class CUpdate
    Dim ut As New CUtils
    Public Function SaveWarehouse(WarehouseRef As String, WarehouseName As String, Address1 As String, Address2 As String, Address3 As String, Address4 As String, PostCode As String, ContactName As String, Telephone As String, Telephone2 As String, Fax As String, eMail As String, Memo As String, WarehouseType As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblWarehouses SET WarehouseName = @WarehouseName,Address1=@Address1,Address2=@Address2,Address3=@Address3,Address4 = @Address4,PostCode = @PostCode,ContactName = @ContactName,Telephone = Telephone,Telephone2 = @Telephone2,Fax = @Fax,eMail = @eMail,Memo = @Memo,WarehouseType = @WarehouseType WHERE WarehouseRef = @WarehouseRef"
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
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShops(ShopRef As String, ShopName As String, Address1 As String, Address2 As String, Address3 As String, Address4 As String, PostCode As String, ContactName As String, Telephone As String, Telephone2 As String, Fax As String, eMail As String, Memo As String, ShopType As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShops SET ShopName = @ShopName,Street=@Street,Area=@Area,Town=@Town,County = @County,PostCode = @PostCode,ContactName = @ContactName,Telephone = Telephone,Telephone2 = @Telephone2,Fax = @Fax,eMail = @eMail,Memo = @Memo,ShopType = @ShopType WHERE ShopRef = @ShopRef"
                With .Parameters
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@ShopName", ShopName)
                    .AddWithValue("@Street", Address1)
                    .AddWithValue("@Area", Address2)
                    .AddWithValue("@Town", Address3)
                    .AddWithValue("@County", Address4)
                    .AddWithValue("@PostCode", PostCode)
                    .AddWithValue("@ContactName", ContactName)
                    .AddWithValue("@Telephone", Telephone)
                    .AddWithValue("@Telephone2", Telephone2)
                    .AddWithValue("@Fax", Fax)
                    .AddWithValue("@eMail", eMail)
                    .AddWithValue("@Memo", Memo)
                    .AddWithValue("@ShopType", ShopType)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveSupplier(SupplierRef As String, SupplierName As String, Address1 As String, Address2 As String, Address3 As String, Address4 As String, PostCode As String, ContactName As String, Telephone As String, Telephone2 As String, Fax As String, eMail As String, Memo As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblSuppliers SET SupplierName = @SupplierName,Address1=@Address1,Address2=@Address2,Address3=@Address3,Address4 = @Address4,PostCode = @PostCode,ContactName = @ContactName,Telephone = Telephone,Telephone2 = @Telephone2,Fax = @Fax,eMail = @eMail,Memo = @Memo WHERE SupplierRef = @SupplierRef"
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
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveStock(StockCode As String, SupplierRef As String, DeadCode As Boolean, AmountTaken As Decimal, DelQtyH As Integer, CostValue As Decimal, PCMarkUp As Decimal, ZeroQty As Boolean, Season As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblStock SET SupplierRef=@SupplierRef,DeadCode=@DeadCode,AmountTaken=@AmountTaken,DeliveredQtyHangers=@DeliveredQtyHangers,CostValue=@CostValue,PCMarkUp=@PCMarkUp,ZeroQty=@ZeroQty,Season =@Season WHERE StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@SupplierRef", SupplierRef)
                    .AddWithValue("@DeadCode", CBool(DeadCode))
                    .AddWithValue("@AmountTaken", CDec(AmountTaken))
                    .AddWithValue("@DeliveredQtyHangers", CInt(DelQtyH))
                    .AddWithValue("@CostValue", CDec(CostValue))
                    .AddWithValue("@PCMarkUp", CDec(PCMarkUp))
                    .AddWithValue("@ZeroQty", CBool(ZeroQty))
                    .AddWithValue("@Season", Season)
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SavePOrders(DeliveriesID As Integer, supplierRef As String, suppliername As String, locationref As String, locationname As String, stockcode As String, totalg As Integer, netamount As Decimal, commission As Decimal, delcharge As Decimal, totalv As Decimal, dte As Date, notes As String, invoice As String, shipper As String, shipperinv As String) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblDeliveries
   SET OurRef = @OurRef, SupplierRef = @SupplierRef, SupplierName = @SupplierName, LocationRef = @LocationRef, LocationName = @LocationName, StockCode = @StockCode, DQtyGarments = @DQtyGarments ,DQtyBoxes = @DQtyBoxes,DQtyHangers = @DQtyHangers,TotalGarments = @TotalGarments,TotalBoxes = @TotalBoxes,TotalHangers = @TotalHangers,NetAmount = @NetAmount,DeliveryCharge = @DeliveryCharge,Commission = @Commission,TotalAmount = @TotalAmount,DeliveryDate = @DeliveryDate,DeliveryType = @DeliveryType,ConfirmedDate = @ConfirmedDate,Notes = @Notes,InvoiceNo = @InvoiceNo,Shipper = @Shipper,ShipperInvoice = @ShipperInvoice WHERE DeliveriesID = @DeliveriesID"
                With .Parameters
                    .AddWithValue("@DeliveriesID", CInt(DeliveriesID))
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
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWHAdjustHead(ID As Integer, ShopRef As String, Reference As String, TotalLossItems As Integer, TotalGainItems As Integer, MovementDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblWarehouseAdjustments SET WarehouseRef = @WarehouseRef,Reference = @Reference,TotalLossItems = @TotalLossItems,TotalGainItems = @TotalGainItems, MovementDate = @MovementDate WHERE ID = @ID"
                With .Parameters
                    .AddWithValue("@ID", ID)
                    .AddWithValue("@WarehouseRef", ShopRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalLossItems", TotalLossItems)
                    .AddWithValue("@TotalGainItems", TotalGainItems)
                    .AddWithValue("@MovementDate", CDate(MovementDate))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWHAdjustLines(StockCode As String, MovementType As String, Qty As Integer, Value As Decimal, ID As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblWarehouseAdjustmentsLines SET MovementType = @MovementType,Qty = @Qty,Value = @Value WHERE WarehouseAdjustID = @WarehouseAdjustID AND StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@MovementType", MovementType)
                    .AddWithValue("@Qty", CInt(Qty))
                    .AddWithValue("@Value", CDec(Value))
                    .AddWithValue("@WarehouseAdjustID", CInt(ID))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopDelHead(DeliveriesID As Integer, ShopRef As String, ShopName As String, WarehouseRef As String, WarehousesName As String, Reference As String, TotalItems As Integer, DeliveryDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShopDeliveries SET ShopRef = @ShopRef,ShopName = @ShopName,WarehouseRef = @WarehouseRef,WarehouseName = @WarehouseName,Reference = @Reference,TotalItems = @TotalItems,DeliveryDate = @DeliveryDate,DeliveryType = @DeliveryType,ConfirmedDate = @ConfirmedDate,Notes = @Notes WHERE DeliveriesID = @DeliveriesID"
                With .Parameters
                    .AddWithValue("@DeliveriesID", CInt(DeliveriesID))
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
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopDelLines(SDeliveriesID As Integer, SStockCode As String, DeliveredQty As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShopDeliveriesLines SET DeliveredQty = @DeliveredQty WHERE SDeliveriesID = @SDeliveriesID AND SStockCode = @SStockCode"
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
    Public Function SaveShopAdjustHead(ID As Integer, ShopRef As String, Reference As String, TotalLossItems As Integer, TotalGainItems As Integer, MovementDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShopAdjustments SET ShopRef = @ShopRef,Reference = @Reference,TotalLossItems = @TotalLossItems,TotalGainItems = @TotalGainItems, MovementDate = @MovementDate WHERE ID = @ID"
                With .Parameters
                    .AddWithValue("@ID", CInt(ID))
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalLossItems", CInt(TotalLossItems))
                    .AddWithValue("@TotalGainItems", CInt(TotalGainItems))
                    .AddWithValue("@MovementDate", CDate(MovementDate))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopAdjustLines(StockCode As String, MovementType As String, Qty As Integer, Value As Decimal, ID As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShopAdjustmentsLines SET MovementType = @MovementType,Qty = @Qty,Value = @Value WHERE ShopAdjustID = @ShopAdjustID AND StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@MovementType", MovementType)
                    .AddWithValue("@Qty", CInt(Qty))
                    .AddWithValue("@Value", CDec(Value))
                    .AddWithValue("@ShopAdjustID", CInt(ID))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopTransHead(TransferID As Integer, Reference As String, TransferDate As Date, ShopRef As String, ShopName As String, ToShopRef As String, ToShopName As String, TotalQtyOut As Integer, TotalQtyIn As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShopTransfers SET Reference = @Reference,TransferDate = @TransferDate,ShopRef = @ShopRef,ShopName = @ShopName,ToShopRef = @ToShopRef,ToShopName = @ToShopName,TotalQtyOut = @TotalQtyOut,TotalQtyIn = @TotalQtyOut WHERE TransferID = @TransferID"
                With .Parameters
                    .AddWithValue("@TransferID", CInt(TransferID))
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TransferDate", CDate(TransferDate))
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@ShopName", ShopName)
                    .AddWithValue("@ToShopRef", ToShopRef)
                    .AddWithValue("@ToShopName", ToShopName)
                    .AddWithValue("@TotalQtyOut", CInt(TotalQtyOut))
                    .AddWithValue("@TotalQtyIn", CInt(TotalQtyIn))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopTransLines(TransferID As Integer, smtoid As Integer, smtiid As Integer, StockCode As String, CurrQty As Integer, TOQty As Integer, TIQty As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblShopTransferLines SET SMTOID = @SMTOID,SMTIID=@SMTIID,CurrentQty = @CurrentQty,TOQty=@TOQty,TIQty=@TIQty WHERE TransferID=@TransferID AND StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@TransferID", CInt(TransferID))
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
    Public Function SaveShopSalesHead(SalesID As Integer, shopref As String, shopname As String, SAReference As String, TransactionDate As Date, TotalQty As Integer, TotalValue As Decimal) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblSales SET ShopRef = @ShopRef,ShopName=@ShopName,SAReference = @SAReference,TransactionDate=@TransactionDate,TotalQty = @TotalQty,TotalValue=@TotalValue WHERE SalesID=@SalesID"
                With .Parameters
                    .AddWithValue("@SalesID", CInt(SalesID))
                    .AddWithValue("@ShopRef", shopref)
                    .AddWithValue("@ShopName", shopname)
                    .AddWithValue("@SAReference", SAReference)
                    .AddWithValue("@TransactionDate", CDate(TransactionDate))
                    .AddWithValue("@TotalQty", CInt(TotalQty))
                    .AddWithValue("@TotalValue", CDec(TotalValue))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopSalesLines(salesID As Integer, stockcode As String, CurrentQty As Integer, QtySold As Integer, SalesAmount As Decimal, StockID As Integer) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblSalesLines SET CurrentQty = @CurrentQty, QtySold = @QtySold,SalesAmount = @SalesAmount,StockMovementID = @StockMovementID WHERE SalesID = @SalesID AND StockCode =@StockCode"
                With .Parameters
                    .AddWithValue("@SalesID", CInt(salesID))
                    .AddWithValue("@StockCode", stockcode)
                    .AddWithValue("@CurrentQty", CInt(CurrentQty))
                    .AddWithValue("@QtySold", CInt(QtySold))
                    .AddWithValue("@SalesAmount", CDec(SalesAmount))
                    .AddWithValue("@StockMovementID", CInt(StockID))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopReturnsHead(ReturnID As Integer, ShopRef As String, WarehouseRef As String, Reference As String, TotalItems As Integer, TransactionDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblReturns SET ShopRef=@ShopRef,WarehouseRef=@WarehouseRef,Reference=@Reference,TotalItems = @TotalItems,TransactionDate=@TransactionDate WHERE ReturnsID =@ReturnsID"
                With .Parameters
                    .AddWithValue("@ReturnsID", CInt(ReturnID))
                    .AddWithValue("@ShopRef", ShopRef)
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalItems", CInt(TotalItems))
                    .AddWithValue("@TransactionDate", CDate(TransactionDate))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveShopReturnsLines(ReturnID As Integer, StockCode As String, Qty As Integer, Value As Decimal) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim updCmd As New SqlCommand()
            With updCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblReturnLines SET Qty = @Qty,Value=@Value WHERE ReturnID = @ReturnID AND StockCode = @StockCode"
                With .Parameters
                    .AddWithValue("@ReturnID", CInt(ReturnID))
                    .AddWithValue("@StockCode", StockCode)
                    .AddWithValue("@Qty", CInt(Qty))
                    .AddWithValue("@Value", CInt(Value))
                End With
                .ExecuteNonQuery()
            End With
        End Using
        Return True
    End Function
    Public Function SaveWHReturnHead(WReturns As Integer, WarehouseRef As String, SWarehouseRef As String, Reference As String, TotalItems As Integer, TransactionDate As Date) As Boolean
        Using conn As New SqlConnection(ut.GetConnString())
            Dim inscmd As New SqlCommand
            With inscmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "UPDATE tblWReturns SET WarehouseRef=@WarehouseRef,SWarehouseRef=@SWarehouseRef,Reference=@Reference,TotalItems=@TotalItems,TransactionDate=@TransactionDate WHERE WReturnsID =@WReturnsID"
                With .Parameters
                    .AddWithValue("@WReturnsID", CInt(WReturns))
                    .AddWithValue("@WarehouseRef", WarehouseRef)
                    .AddWithValue("@SWarehouseRef", SWarehouseRef)
                    .AddWithValue("@Reference", Reference)
                    .AddWithValue("@TotalItems", CInt(TotalItems))
                    .AddWithValue("@TransactionDate", CDate(TransactionDate))
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
                .CommandText = "UPDATE tblWReturnLines SET Qty = @Qty,Value = @Value WHERE WReturnID = @WReturnID AND StockCode = @StockCode"
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
