Imports System.Linq
Imports System.Threading.Tasks
Imports DevExtreme.AspNet.Data
Imports Microsoft.AspNetCore.Mvc

Namespace AspNetCoreDashboardBackend

    <Route("dashboardpanel")>
    Public Class DashboardPanelController
        Inherits Controller

        Private nwindContext As NorthwindContext

        Public Sub New(ByVal nwindContext As NorthwindContext)
            Me.nwindContext = nwindContext
        End Sub

        <HttpGet("dashboards")>
        Public Async Function Dashboards(ByVal loadOptions As DataSourceLoadOptions) As Task(Of IActionResult)
            Dim source = nwindContext.Products.Select(Function(item) New With {item.ProductID, item.ProductName})
            loadOptions.PrimaryKey = {"ProductID"}
            loadOptions.PaginateViaPrimaryKey = True
            Return Json(Await DataSourceLoader.LoadAsync(source, loadOptions))
        End Function
    End Class
End Namespace
