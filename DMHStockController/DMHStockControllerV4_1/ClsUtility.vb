
Public Class ClsUtility
    Public Function GetConnectionString(ByVal ConnectionType As Int16) As String
        Dim ConnString As String = ""
        If ConnectionType = 1 Then ConnString = "Initial Catalog=DMHStockV5;Data Source=(local);Persist Security Info=False;Integrated Security=true;"
        If ConnectionType = 2 Then ConnString = "Initial Catalog=FYPv2;Data Source=192.168.1.200;Persist Security Info=False;Integrated Security=false;User ID=FYPUser;Password=@35Adc@*K9z&QJ"
        If ConnectionType = 3 Then ConnString = "Initial Catalog=master;Data Source=(local);Persist Security Info=False;Integrated Security=true;"
        If ConnectionType <> 1 And ConnectionType <> 2 And ConnectionType <> 3 Then ConnString = "Initial Catalog=master;Data Source=192.168.1.200;Persist Security Info=False;Integrated Security=false;User ID=FYPUser;Password=@35Adc@*K9z&QJ"
        Return ConnString
    End Function
    Public Property SaveToDB As Boolean
    Public Property UpdateInDB As Boolean
    Public Property DeleteFromDB As Boolean



End Class
