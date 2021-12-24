<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebDesigner_DataLoading.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="position: absolute; left: 0; right: 0; top:0; bottom:0;">
			<dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%" 
				ondataloading="ASPxDashboard1_DataLoading">
			</dx:ASPxDashboard>
		</div>
	</form>
</body>
</html>