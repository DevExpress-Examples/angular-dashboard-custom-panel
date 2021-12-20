Imports Microsoft.EntityFrameworkCore

Namespace AspNetCoreDashboardBackend

    Public Partial Class NorthwindContext
        Inherits DbContext

        Public Sub New(ByVal options As DbContextOptions(Of NorthwindContext))
            MyBase.New(options)
        End Sub

        Public Overridable Property Products As DbSet(Of Product)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of Product)().[Property](Function(e) e.ProductID).HasConversion(Of String)()
        End Sub
    End Class
End Namespace
