using System;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;

namespace WebDesigner_DataLoading {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
            ASPxDashboard1.SetDashboardStorage(dashboardFileStorage);
            
            DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source");
            objDataSource.DataId = "odsSales";
            objDataSource.DataSource = typeof(SalesPersonData);
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml());
            ASPxDashboard1.SetDataSourceStorage(dataSourceStorage);
        }

        protected void ASPxDashboard1_DataLoading(object sender, DataLoadingWebEventArgs e) {
            if (e.DataId == "odsSales") {
                e.Data = SalesPersonData.CreateData();
            }
        }
    }
}