Imports System
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWeb

Namespace WebDesigner_DataLoading
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim dashboardFileStorage As New DashboardFileStorage("~/App_Data/Dashboards")
			ASPxDashboard1.SetDashboardStorage(dashboardFileStorage)

			Dim objDataSource As New DashboardObjectDataSource("Object Data Source")
			objDataSource.DataId = "odsSales"
			objDataSource.DataSource = GetType(SalesPersonData)
			Dim dataSourceStorage As New DataSourceInMemoryStorage()
			dataSourceStorage.RegisterDataSource("objDataSource", objDataSource.SaveToXml())
			ASPxDashboard1.SetDataSourceStorage(dataSourceStorage)
		End Sub

		Protected Sub ASPxDashboard1_DataLoading(ByVal sender As Object, ByVal e As DataLoadingWebEventArgs)
			If e.DataId = "odsSales" Then
				e.Data = SalesPersonData.CreateData()
			End If
		End Sub
	End Class
End Namespace