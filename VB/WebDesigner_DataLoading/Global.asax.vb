Imports System
Imports DevExpress.DashboardWeb
Imports DevExpress.DashboardCommon

Namespace WebDesigner_DataLoading
        Public Class Global_asax
            Inherits System.Web.HttpApplication

            Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
                AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error

                Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
                DashboardService.SetDashboardStorage(dashboardFileStorage)

                Dim objDataSource As New DashboardObjectDataSource("Object Data Source")
                objDataSource.DataSource = GetType(SalesPersonData)

                Dim dataSourceStorage As New DataSourceInMemoryStorage()
                dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())
                DashboardService.SetDataSourceStorage(dataSourceStorage)

                AddHandler DashboardService.DataApi.DataLoading, AddressOf DataApi_DataLoading
            End Sub

            Private Sub DataApi_DataLoading(ByVal sender As Object, _
                                            ByVal e As DevExpress.DashboardCommon.ServiceDataLoadingEventArgs)
                If e.DataSourceName = "Object Data Source" Then
                    e.Data = SalesPersonData.CreateData()
                End If
            End Sub

            Private Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
                ' Code that runs on application shutdown
            End Sub

            Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
                ' Code that runs when an unhandled error occurs
            End Sub

            Private Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
                ' Code that runs when a new session is started
            End Sub

            Private Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
                ' Code that runs when a session ends. 
                ' Note: The Session_End event is raised only when the sessionstate mode
                ' is set to InProc in the Web.config file. If session mode is set to StateServer 
                ' or SQLServer, the event is not raised.
            End Sub
        End Class
End Namespace