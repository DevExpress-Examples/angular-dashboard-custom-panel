Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq

Namespace AspNetCoreDashboardBackend

    Public Class CustomDashboardStorage
        Implements IDashboardStorage

        Private dashboardTemplateFolder As String

        Private nwindContext As NorthwindContext

        Public Sub New(ByVal dashboardTemplateFolder As String, ByVal nwindContext As NorthwindContext)
            Me.dashboardTemplateFolder = dashboardTemplateFolder
            Me.nwindContext = nwindContext
        End Sub

        Public Function GetAvailableDashboardsInfo() As IEnumerable(Of DashboardInfo) Implements IDashboardStorage.GetAvailableDashboardsInfo
            Dim dashboards = nwindContext.Products.[Select](Function(item) New DashboardInfo() With {.ID = item.ProductID, .Name = item.ProductName})
            Return dashboards
        End Function

        Public Function LoadDashboard(ByVal dashboardID As String) As XDocument Implements IDashboardStorage.LoadDashboard
            Dim dashboard = New Dashboard()
            Dim product = nwindContext.Products.First(Function(product) Equals(product.ProductID, dashboardID))
            dashboard.LoadFromXml(Path.Combine(dashboardTemplateFolder, "DashboardTemplate.xml"))
            dashboard.Title.Text = product.ProductName
            Return dashboard.SaveToXDocument()
        End Function

        Public Sub SaveDashboard(ByVal dashboardID As String, ByVal dashboard As XDocument) Implements IDashboardStorage.SaveDashboard
            Throw New NotImplementedException()
        End Sub
    End Class
End Namespace
