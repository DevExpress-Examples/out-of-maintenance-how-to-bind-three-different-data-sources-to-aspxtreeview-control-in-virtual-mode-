<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>How to bind three different data sources to ASPxTreeView control in virtual mode</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxTreeView ID="treeView" runat="server" EnableCallBacks="True" OnVirtualModeCreateChildren="ASPxTreeView1_VirtualModeCreateChildren">
			</dx:ASPxTreeView>
		</div>
		<asp:SqlDataSource ID="dsJobs" runat="server" ConnectionString="Data Source=(local);Initial Catalog=pubs;Integrated Security=True"
			ProviderName="System.Data.SqlClient" SelectCommand="SELECT [job_id], [job_desc] FROM [jobs]">
		</asp:SqlDataSource>
		<asp:SqlDataSource ID="dsEmployee" runat="server" ConnectionString="Data Source=(local);Initial Catalog=pubs;Integrated Security=True"
			ProviderName="System.Data.SqlClient" SelectCommand="SELECT [fname], [lname], [pub_id] FROM [employee] WHERE ([job_id] = @job_id)">
			<SelectParameters>
				<asp:Parameter Name="job_id" Type="Int16" />
			</SelectParameters>
		</asp:SqlDataSource>
		<asp:SqlDataSource ID="dsPubInfo" runat="server" ConnectionString="Data Source=(local);Initial Catalog=pubs;Integrated Security=True"
			ProviderName="System.Data.SqlClient" SelectCommand="SELECT [pr_info] FROM [pub_info] WHERE ([pub_id] = @pub_id)">
			<SelectParameters>
				<asp:Parameter Name="pub_id" Type="String" />
			</SelectParameters>
		</asp:SqlDataSource>
	</form>
</body>
</html>
