import { Component } from '@angular/core';
import { createStore } from 'devextreme-aspnet-data-nojquery';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  serverUrl: string = "http://localhost:5000";
  /* To debug the server, change 'serverUrl' to https://localhost:44396 and run the server application in Visual Studio. */
  store: CustomStore;
  dataSource: DataSource;

  constructor() {
    this.store = createStore({
        key: "productID",
        loadUrl: this.serverUrl + "/dashboardpanel/dashboards"
    });

    this.dataSource = new DataSource({
      store: this.store,
      paginate: true,
      pageSize: 20
    });
  }
}