Public Class CUtils

    Public Function GetConnString()
        Dim connString As String
        'connString = "Initial Catalog=DMHStockv4a;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        connString = "Initial Catalog=DMHStockv4;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        Return connString
    End Function
    Public Function GetSundaysDate(ByRef Dte As Date) As Date
        Return Dte.AddDays(0 - Dte.DayOfWeek)
    End Function
    Public Function GetNextSundaysDate(ByRef dte As Date) As Date
        Return dte.AddDays(0 - dte.DayOfWeek + 7)
    End Function
    Public Function GetUserName() As String
        Return "David"
    End Function
    Public Function GetBkConnString()
        Dim connString As String
        'connString = "Initial Catalog=DMHStockv4a;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        connString = "Initial Catalog=master;Data Source=.\SQLEXPRESS;Persist Security Info=False;Integrated Security=true;"
        Return connString
    End Function

End Class
