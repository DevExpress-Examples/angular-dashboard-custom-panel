Imports System.ComponentModel.DataAnnotations

Namespace AspNetCoreDashboardBackend

    Public Class Product

        <Key>
        Public Property ProductID As String

        Public Property ProductName As String

        Public Property UnitPrice As Decimal?

        Public Property UnitsOnOrder As Short?

        Public Property CategoryID As Integer?
    End Class
End Namespace
