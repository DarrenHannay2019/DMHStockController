Imports System.Data
Imports System.Data.SqlClient
Public Class FrmDataGrid
    Public ReadOnly FunctID As Integer
    Private ReadOnly util As New ClsUtility
    Private S_SQLCMD As String

    Private Sub DgvRecords_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecords.CellContentClick

    End Sub

    Private Sub FrmDataGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        S_SQLCMD = GetDataString(FunctID)
        LoadData()
    End Sub

    Private Sub TsbNew_Click(sender As Object, e As EventArgs) Handles TsbNew.Click

    End Sub

    Private Sub TsbRecord_Click(sender As Object, e As EventArgs) Handles TsbRecord.Click

    End Sub

    Private Sub TsbDelete_Click(sender As Object, e As EventArgs) Handles TsbDelete.Click
        util.DeleteFromDB = False

    End Sub

    Private Sub TsbRefresh_Click(sender As Object, e As EventArgs) Handles TsbRefresh.Click

    End Sub

    Private Sub TsbPrint_Click(sender As Object, e As EventArgs) Handles TsbPrint.Click

    End Sub

    Private Sub TsbFind_Click(sender As Object, e As EventArgs) Handles TsbFind.Click

    End Sub

    Private Sub TsbClose_Click(sender As Object, e As EventArgs) Handles TsbClose.Click
        Me.Close()
    End Sub
    Private Function GetDataString(ByVal FunctionID As Integer) As String
        Select Case FunctionID
            Case 1
                Return ""
            Case 2
                Return ""
            Case Else
                Return ""
        End Select
    End Function
    Private Sub LoadData()
        Using SqlConn As New SqlConnection()
            SqlConn.ConnectionString = util.GetConnectionString(1)
            Using SqlCmd As New SqlCommand
                With SqlCmd
                    .Connection = SqlConn
                    .CommandText = S_SQLCMD
                    .CommandType = CommandType.Text
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            End Using
        End Using
    End Sub
End Class