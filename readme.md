<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1054393)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Dashboard for Angular - How to implement a custom service and UI for managing dashboards list

This example illustrates a custom implementation of the dashboard list similar to one provided by [Dashboard Panel](https://docs.devexpress.com/Dashboard/119771/web-dashboard/ui-elements-and-customization/ui-elements/dashboard-panel) and [requestDashboardList](https://docs.devexpress.com/Dashboard/js-DevExpress.Dashboard.DashboardControl?p=netframework#js_devexpress_dashboard_dashboardcontrol_requestdashboardlist).

On the server side we use the [DevExtreme ASP.NET Data](https://github.com/DevExpress/DevExtreme.AspNet.Data) package APIs to prepare a list of dashboard names with their ids based on the `Products` table from the `Northwind` database accessed through the [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/). This list is returned by the `DashboardPanelController.Dashboards` action method.
In addition, it is necessary to implement the a custom [Dashboard Storage](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage) and return the corresponding dashboard from the [IDashboardStorage.LoadDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.LoadDashboard(System.String)) method. We use a single dashboard XML template (the `DashboardTemplate.xml` file) and only modify the dashboard's title to emulate different dashboards. In your particular usage scenario, you can store dashboard layouts in the database and load them from here (e.g., see [Dashboard for ASP.NET Core - How to load and save dashboards from/to a database](https://github.com/DevExpress-Examples/asp-net-core-dashboard-save-dashboards-to-database)).

On the client-side, the [dxList](https://js.devexpress.com/Documentation/ApiReference/UI_Components/dxList/) widget is used to load and display the list of dashboards.

**NOTE:** This example uses the `ProductID` database field as a dashboard's Id. The field's type is number while the [DashboardInfo.ID](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.DashboardInfo.ID) property and the [IDashboardStorage.LoadDashboard](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.IDashboardStorage.LoadDashboard(System.String)) method's argument type is string. So, it is necessary to convert types. This is done in the `NorthwindContext.OnModelCreating` method (see [NorthwindContext.cs](./asp-net-core-server/Models/NorthwindContext.cs)).

<!-- default file list -->
## Files to Look At

* [Startup.cs](./asp-net-core-server/Startup.cs)
* [DashboardPanelController.cs](./asp-net-core-server/Controllers/DashboardPanelController.cs)
* [CustomDashboardStorage.cs](./asp-net-core-server/Code/CustomDashboardStorage.cs)
* [Product.cs](./asp-net-core-server/Models/Product.cs)
* [NorthwindContext.cs](./asp-net-core-server/Models/NorthwindContext.cs)
* [app.component.ts](./dashboard-angular-app/src/app/app.component.ts)
* [app.component.html](./dashboard-angular-app/src/app/app.component.html)

<!-- default file list end -->

## Quick Start

### Server
Run the following command in the **asp-net-core-server** folder:

```
dotnet run
```

The server starts at `http://localhost:5000` and the client gets data from `http://localhost:5000/api/dashboard`. To debug the server, run the **asp-net-core-server** application in Visual Studio and change the client's `serverUrl` property according to the listening port: `https://localhost:44396/api/dashboard`.

See the following section for information on how to install NuGet packages from the DevExpress NuGet feed: [Install DevExpress Controls Using NuGet Packages](https://docs.devexpress.com/GeneralInformation/115912/installation/install-devexpress-controls-using-nuget-packages).

> This server allows CORS requests from _all_ origins with _any_ scheme (http or https). This default configuration is insecure: any website can make cross-origin requests to the app. We recommend that you specify the client application's URL to prohibit other clients from accessing sensitive information stored on the server. Learn more: [Cross-Origin Resource Sharing (CORS)](https://docs.devexpress.com/Dashboard/400709)

### Client
In the **dashboard-react-app** folder, run the following commands:

```
npm install
npm start
```

Open ```http://localhost:4200/``` in your browser to see the Web Dashboard application.

## Documentation

- [Prepare Dashboard Storage](https://docs.devexpress.com/Dashboard/16979/web-dashboard/dashboard-backend/prepare-dashboard-storage)

## More Examples

- [Dashboard for ASP.NET Core - How to load and save dashboards from/to a database](https://github.com/DevExpress-Examples/asp-net-core-dashboard-save-dashboards-to-database)
