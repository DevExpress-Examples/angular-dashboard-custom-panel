Imports Microsoft.AspNetCore.Mvc

Namespace AspNetCoreDashboardBackend

    Public Class HomeController
        Inherits Controller

        Public Function Index() As IActionResult
            Return View()
        End Function
    End Class
End Namespace
