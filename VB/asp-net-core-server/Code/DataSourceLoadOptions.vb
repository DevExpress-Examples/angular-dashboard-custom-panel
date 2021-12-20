Imports DevExtreme.AspNet.Data
Imports DevExtreme.AspNet.Data.Helpers
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Mvc.ModelBinding
Imports System.Linq
Imports System.Threading.Tasks

Namespace AspNetCoreDashboardBackend

    <ModelBinder(BinderType:=GetType(DataSourceLoadOptionsBinder))>
    Public Class DataSourceLoadOptions
        Inherits DataSourceLoadOptionsBase

    End Class

    Public Class DataSourceLoadOptionsBinder
        Implements IModelBinder

        Public Function BindModelAsync(ByVal bindingContext As ModelBindingContext) As Task Implements IModelBinder.BindModelAsync
            Dim loadOptions = New DataSourceLoadOptions()
            Call DataSourceLoadOptionsParser.Parse(loadOptions, Function(key) bindingContext.ValueProvider.GetValue(key).FirstOrDefault())
            bindingContext.Result = ModelBindingResult.Success(loadOptions)
            Return Task.CompletedTask
        End Function
    End Class
End Namespace
