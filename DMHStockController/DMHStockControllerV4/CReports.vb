Imports System.Data.SqlClient
Public Class CReports
    Dim syslog As New CSystemLog
    Dim ut As New CUtils
    Private Sub AddToLog()
        syslog.SaveSystemLog("All", "All", "All", 0, "Reports Gen", "Reports Gen", Date.Now, "Full Reports Generated")
    End Sub
    Private Sub DeleteTempTables(table As String)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim delCmd As New SqlCommand
            With delCmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "DELETE from " + table
                .ExecuteNonQuery()
            End With
        End Using
    End Sub
    Private Function checkrecords(table As String) As Integer
        Dim QueryResult As Integer
        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand
            With cmd
                .Connection = conn
                .Connection.Open()
                .CommandType = CommandType.Text
                .CommandText = "SELECT COUNT(*) as numRows From " + table
                QueryResult = .ExecuteScalar
            End With
        End Using
        Return QueryResult
    End Function
    Public Sub DeleteOldData()
        AddToLog()
        Dim result, result2, result3, result4, result5, result6, result7, result8, result9 As Integer
        result = checkrecords("tblSalesThisWeek")
        result2 = checkrecords("tblCurrentStock")
        result3 = checkrecords("tblShopStockReport")
        result4 = checkrecords("tblStockRepTotalDelivered")
        result5 = checkrecords("tblStockRepTotalGain")
        result6 = checkrecords("tblStockRepTotalLoss")
        result7 = checkrecords("tblStockRepTotalSold")
        result8 = checkrecords("tblStockRepTransfers")
        result9 = checkrecords("tblStockMovementsDate")
        If result > 0 Then DeleteTempTables("tblSalesThisWeek")
        If result2 > 0 Then DeleteTempTables("tblCurrentStock")
        If result3 > 0 Then DeleteTempTables("tblShopStockReport")
        If result4 > 0 Then DeleteTempTables("tblStockRepTotalDelivered")
        If result5 > 0 Then DeleteTempTables("tblStockRepTotalGain")
        If result6 > 0 Then DeleteTempTables("tblStockRepTotalLoss")
        If result7 > 0 Then DeleteTempTables("tblStockRepTotalSold")
        If result8 > 0 Then DeleteTempTables("tblStockRepTransfers")
        If result9 > 0 Then DeleteTempTables("tblStockMovementsDate")
    End Sub
    Public Sub CreateTempMovements(dte As Date, dte2 As Date)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlString As String = "Insert INTo tblStockMovementsDate(StockCode,SupplierRef,Location,LocationType,MovementType,MovementQtyHangers,MovementQtyBoxes,MovementDate,MovementValue,Reference,TransferReference,CreatedBy,CreatedDate) SELECT dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMSupplierRef,dbo.tblStockMovements.SMLocation,dbo.tblStockMovements.SMLocationType,dbo.tblStockMovements.MovementType,dbo.tblStockMovements.MovementQtyHangers,dbo.tblStockMovements.MovementQtyBoxes,dbo.tblStockMovements.MovementDate,dbo.tblStockMovements.MovementValue,dbo.tblStockMovements.Reference,dbo.tblStockMovements.TransferReference,dbo.tblStockMovements.SMCreatedBy,dbo.tblStockMovements.SMCreatedDate FROM dbo.tblStockMovements WHERE (dbo.tblStockMovements.MovementDate > @Date1) AND (dbo.tblStockMovements.MovementDate <= @Date2) GROUP BY dbo.tblStockMovements.SMStockCode,dbo.tblStockMovements.SMSupplierRef,dbo.tblStockMovements.SMLocation,dbo.tblStockMovements.SMLocationType,dbo.tblStockMovements.MovementType,dbo.tblStockMovements.MovementQtyHangers,dbo.tblStockMovements.MovementQtyBoxes,dbo.tblStockMovements.MovementDate,dbo.tblStockMovements.MovementValue,dbo.tblStockMovements.Reference,dbo.tblStockMovements.TransferReference,dbo.tblStockMovements.SMCreatedBy,dbo.tblStockMovements.SMCreatedDate;"
            Dim SCommand As New SqlCommand(sqlString, conn)
            SCommand.Parameters.AddWithValue("@Date1", dte)
            SCommand.Parameters.AddWithValue("@Date2", dte2)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using
        ' End Sub
        ' Public Sub CreateStockListReport(dte As DateTime, dte2 As DateTime)
        Using conn As New SqlConnection(ut.GetConnString())
            '    Dim sqlString As String = "Insert INTo tblShopStockReport (ShopName,Location,Type,StockCode,DeadCode,TotalSold,CurrentQty,QtyDel,TranIn,TranOut,QtyUp,QtyDown) SELECT dbo.tblShops.ShopName, dbo.tblStockMovements.SMLocation, dbo.tblShops.ShopType, dbo.tblStockMovements.SMStockCode, dbo.tblStock.DeadCode,ISNULL(SUM(dbo.ssrStockmovementsShopSales.MovementQtyHangers * - 1), 0) AS TotalSold, '0' AS CurrentQty, ISNULL(SUM(dbo.ssrStockMovementsShopDelivery.MovementQtyHangers), 0) AS QtyDel, ISNULL(SUM(dbo.ssrStockMovementsShopTransfer.TransferIn), 0) AS TranIn, ISNULL(SUM(dbo.ssrStockMovementsShopTransfer.TransferOut), 0) AS TranOut,               ISNULL(SUM(dbo.ssrStockMovementsShopGain.MovementQtyHangers), 0) AS QtyUp, ISNULL(SUM(dbo.ssrStockMovementsShopLoss.MovementQtyHangers), 0) AS QtyDown FROM  dbo.tblShops INNER JOIN dbo.tblStockMovements ON dbo.tblShops.ShopRef = dbo.tblStockMovements.SMLocation LEFT OUTER JOIN dbo.ssrStockMovementsShopTransfer ON dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopTransfer.StockMovementID LEFT OUTER JOIN                       dbo.ssrStockMovementsShopLoss ON dbo.tblStockMovements.MovementQtyHangers = dbo.ssrStockMovementsShopLoss.MovementQtyHangers AND dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopLoss.StockMovementID LEFT OUTER JOIN                         dbo.ssrStockMovementsShopDelivery ON dbo.tblStockMovements.MovementQtyHangers = dbo.ssrStockMovementsShopDelivery.MovementQtyHangers AND dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopDelivery.StockMovementID LEFT OUTER JOIN dbo.ssrStockmovementsShopSales ON dbo.tblStockMovements.MovementQtyHangers = dbo.ssrStockmovementsShopSales.MovementQtyHangers AND dbo.tblStockMovements.StockMovementID = dbo.ssrStockmovementsShopSales.StockMovementID LEFT OUTER JOIN dbo.ssrStockMovementsShopGain ON dbo.tblStockMovements.StockMovementID = dbo.ssrStockMovementsShopGain.StockMovementID FULL OUTER JOIN dbo.tblStock ON dbo.tblStockMovements.SMStockCode = dbo.tblStock.StockCode WHERE (dbo.tblStockMovements.MovementDate > @date1) AND (dbo.tblStockMovements.MovementDate < @date2) OR (dbo.tblStockMovements.MovementType = N'Delivery (S)') OR (dbo.tblStockMovements.MovementType = N'Stock Gain') OR (dbo.tblStockMovements.MovementType = N'Stock Loss') OR                        (dbo.tblStockMovements.MovementType = N'Shop Transfer') OR (dbo.tblStockMovements.MovementType = N'Sale') GROUP BY dbo.tblShops.ShopName, dbo.tblStockMovements.SMLocation, dbo.tblShops.ShopType, dbo.tblStockMovements.SMStockCode, dbo.tblStock.DeadCode"
            Dim sqlString2 As String = "Insert INTo tblShopStockReport (ShopName,Location,Type,StockCode,DeadCode,TotalSold,CurrentQty,QtyDel,TranIn,TranOut,QtyUp,QtyDown) SELECT  dbo.tblShops.ShopName, dbo.tblStockMovementsDate.Location, dbo.tblShops.ShopType, dbo.tblStockMovementsDate.StockCode, tblStock.DeadCode,'0' AS TotalSold, '0' AS CurrentQty, '0' AS QtyDel, '0' AS TranIn, '0' AS TranOut, '0' AS QtyUp, '0' AS QtyDown FROM dbo.tblStockMovementsDate INNER JOIN dbo.tblStock ON dbo.tblStockMovementsDate.StockCode = dbo.tblStock.StockCode RIGHT OUTER JOIN dbo.tblShops ON dbo.tblStockMovementsDate.Location = dbo.tblShops.ShopRef GROUP BY dbo.tblShops.ShopName, dbo.tblStockMovementsDate.Location, dbo.tblShops.ShopType,dbo.tblStock.DeadCode, dbo.tblStockMovementsDate.StockCode HAVING (dbo.tblStockMovementsDate.Location <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlString2, conn)
            SCommand.Parameters.AddWithValue("@Date1", dte)
            SCommand.Parameters.AddWithValue("@Date2", dte2)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using

        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalDelivered (StockCode,Location,Qty) SELECT StockCode,Location, SUM(MovementQtyHangers) AS Expr1 FROM  dbo.tblStockMovementsDate GROUP BY StockCode,Location, MovementType HAVING (MovementType = N'Delivery (S)') AND (Location <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, conn)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using

        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlString As String = "INSERT INTO tblCurrentStock (StockCode,Location,Qty) SELECT dbo.tblStockMovementsDate.StockCode,dbo.tblStockMovementsDate.Location, SUM(dbo.tblStockMovementsDate.MovementQtyHangers) AS Qty FROM dbo.tblStockMovementsDate INNER JOIN dbo.tblStock ON dbo.tblStockMovementsDate.StockCode = dbo.tblStock.StockCode WHERE (dbo.tblStockMovementsDate.LocationType = 'Shop') AND (dbo.tblStockMovementsDate.MovementType = 'Delivery (S)' OR                    dbo.tblStockMovementsDate.MovementType = 'Sale' OR dbo.tblStockMovementsDate.MovementType = 'Shop Transfer' OR dbo.tblStockMovementsDate.MovementType = 'Stock Gain' OR dbo.tblStockMovementsDate.MovementType = 'Stock Loss' OR   dbo.tblStockMovementsDate.MovementType = 'Return') AND (dbo.tblStock.DeadCode = 0) GROUP BY dbo.tblStockMovementsDate.Location, dbo.tblStockMovementsDate.StockCode"
            Dim SCommand As New SqlCommand(sqlString, conn)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using

        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalGain (StockCode,Location,Qty) SELECT StockCode,Location, SUM(MovementQtyHangers) AS Expr1 FROM   dbo.tblStockMovementsDate GROUP BY StockCode,Location, MovementType HAVING (MovementType = N'Stock Gain') AND (Location <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, conn)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using

        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalLoss (StockCode,Location,Qty) SELECT StockCode,Location, SUM(MovementQtyHangers) AS Expr1 FROM   dbo.tblStockMovementsDate GROUP BY StockCode,Location, MovementType HAVING (MovementType = N'Stock Loss') AND (Location <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, conn)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using

        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "INSERT INTO tblStockRepTotalSold (StockCode,Location,Qty) SELECT StockCode,Location, SUM(MovementQtyHangers * -1) AS Expr1 FROM   dbo.tblStockMovementsDate GROUP BY StockCode,Location, MovementType HAVING (MovementType = N'Sale') AND (Location <> N'UNI')"
            Dim SCommand As New SqlCommand(sqlstring, conn)
            SCommand.Connection.Open()
            SCommand.ExecuteNonQuery()
        End Using

        Using conn As New SqlConnection(ut.GetConnString())
            Dim cmd As New SqlCommand
            With cmd
                .Connection = conn
                .CommandText = "INSERT INTO tblStockRepTransfers (StockCode,Location,LocationType,MovementType,TransferIn,TransferOut)SELECT StockCode, Location, LocationType, MovementType, ISNULL(TransferIn,0), ISNULL(TransferOut,0) FROM qryStockMovementsShopTransfer"
                .CommandType = CommandType.Text
                .Connection.Open()
                .ExecuteNonQuery()
            End With
        End Using
    End Sub
    Public Sub UpdateStockReport()
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqestring As String = "UPDATE tblShopStockReport SET SoldThisWeek = ISNULL(tblSalesThisWeek.Qty,0) FROM tblShopStockReport,tblSalesThisWeek WHERE(tblShopStockReport.StockCode = tblSalesThisWeek.StockCode) AND (tblShopStockReport.Location = tblSalesThisWeek.ShopRef)"
            Dim scommand As New SqlCommand(sqestring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET CurrentQty = tblCurrentStock.Qty FROM tblShopStockReport,tblCurrentStock WHERE (tblShopStockReport.StockCode = tblCurrentStock.StockCode) AND (tblShopStockReport.Location = tblCurrentStock.Location)"
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET TotalSold = tblStockRepTotalSold.Qty FROM tblShopStockReport,tblStockRepTotalSold WHERE (tblShopStockReport.StockCode = tblStockRepTotalSold.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalSold.Location)"
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET QtyDel = tblStockRepTotalDelivered.Qty FROM tblShopStockReport,tblStockRepTotalDelivered WHERE (tblShopStockReport.StockCode = tblStockRepTotalDelivered.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalDelivered.Location)"
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET QtyUp = tblStockRepTotalGain.Qty FROM tblShopStockReport,tblStockRepTotalGain WHERE (tblShopStockReport.StockCode = tblStockRepTotalGain.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalGain.Location)"
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET QtyDown = tblStockRepTotalLoss.Qty FROM tblShopStockReport,tblStockRepTotalLoss WHERE (tblShopStockReport.StockCode = tblStockRepTotalLoss.StockCode) AND (tblShopStockReport.Location = tblStockRepTotalLoss.Location)"
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET TranIn = tblStockRepTransfers.TransferIn FROM tblShopStockReport,tblStockRepTransfers WHERE (tblShopStockReport.StockCode = tblStockRepTransfers.StockCode) AND (tblShopStockReport.Location = tblStockRepTransfers.Location)"
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlstring As String = "UPDATE tblShopStockReport SET TranOut = tblStockRepTransfers.TransferOut FROM tblShopStockReport,tblStockRepTransfers WHERE (tblShopStockReport.StockCode = tblStockRepTransfers.StockCode) AND (tblShopStockReport.Location = tblStockRepTransfers.Location)" '
            Dim scommand As New SqlCommand(sqlstring, conn)
            scommand.Connection.Open()
            scommand.ExecuteNonQuery()
        End Using
    End Sub
    Public Sub SalesThisWeekGen(dte As Date, dte2 As Date)
        Using conn As New SqlConnection(ut.GetConnString())
            Dim sqlString As String = "INSERT INTO tblSalesThisWeek (ShopRef,StockCode,Qty,Date) SELECT tblSales.ShopRef,tblSalesLines.StockCode,SUM(tblSalesLines.QtySold) AS Qty,tblSales.TransactionDate FROM tblSales INNER JOIN tblSalesLines ON tblSales.SalesID = tblSalesLines.SalesID GROUP By tblSales.ShopRef,tblSalesLines.StockCode,tblSales.TransactionDate HAVING (((tblSales.TransactionDate) = @Date2));"
            ' Dim sqlString As String = "INSERT INTO tblSalesThisWeek (ShopRef,StockCode,Qty,Date) SELECT SMLocation,SMStockCode,Sales,MovementDate From qrySalesWeek Group By SMLocation,SMStockCode,Sales,MovementDate HAVING (((qrySalesWeek.MovementDate) = @Date2));"
            Dim SCommand As New SqlCommand()
            With SCommand
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = sqlString
                .Connection.Open()
                .Parameters.AddWithValue("@Date2", dte2)
                '  .ExecuteNonQueryAsync()
                .ExecuteNonQuery()
            End With
            '  SCommand.Connection.Open()
            ' SCommand.Parameters.AddWithValue("@Date1", dte)
            '  SCommand.Parameters.AddWithValue("@Date2", dte2)
            '  SCommand.ExecuteNonQuery()
        End Using
    End Sub
End Class
