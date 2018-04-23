using System;
using DevExpress.DashboardWeb;
using DevExpress.DashboardCommon;

namespace WebDesigner_DataLoading {
        public class Global_asax : System.Web.HttpApplication {
            void Application_Start(object sender, EventArgs e) {
                DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);

                DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/App_Data/Dashboards");
                DashboardService.SetDashboardStorage(dashboardFileStorage);

                DashboardObjectDataSource objDataSource = new DashboardObjectDataSource("Object Data Source");
                objDataSource.DataSource = typeof(SalesPersonData);

                DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
                dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml());
                DashboardService.SetDataSourceStorage(dataSourceStorage);

                DashboardService.DataApi.DataLoading += new ServiceDataLoadingEventHandler(DataApi_DataLoading);
            }

            void DataApi_DataLoading(object sender, DevExpress.DashboardCommon.ServiceDataLoadingEventArgs e) {
                if (e.DataSourceName == "Object Data Source") {
                    e.Data = SalesPersonData.CreateData();
                }
            }

            void Application_End(object sender, EventArgs e) {
                // Code that runs on application shutdown
            }

            void Application_Error(object sender, EventArgs e) {
                // Code that runs when an unhandled error occurs
            }

            void Session_Start(object sender, EventArgs e) {
                // Code that runs when a new session is started
            }

            void Session_End(object sender, EventArgs e) {
                // Code that runs when a session ends. 
                // Note: The Session_End event is raised only when the sessionstate mode
                // is set to InProc in the Web.config file. If session mode is set to StateServer 
                // or SQLServer, the event is not raised.
            }
        }
    }