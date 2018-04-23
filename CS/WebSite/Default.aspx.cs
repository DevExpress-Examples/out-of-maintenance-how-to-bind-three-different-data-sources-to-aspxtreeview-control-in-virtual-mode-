using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxTreeView;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
	protected void ASPxTreeView1_VirtualModeCreateChildren(object source, TreeViewVirtualModeCreateChildrenEventArgs e) {
		List<TreeViewVirtualNode> list = new List<TreeViewVirtualNode>();
		if (e.NodeName == null) {
			foreach (DataRowView rw in dsJobs.Select(DataSourceSelectArguments.Empty)) {
				string name = String.Format("e{0},{1}", rw.Row[0], Guid.NewGuid());
				TreeViewVirtualNode node = new TreeViewVirtualNode(name, FormatText(rw.Row[1].ToString()));
				node.IsLeaf = !HasChildNodes(dsEmployee, "job_id", rw.Row[0].ToString());
				list.Add(node);
			}
			e.Children = list;
			return;
		}
		if (e.NodeName[0] == 'e') {
			dsEmployee.SelectParameters["job_id"].DefaultValue = GetId(e.NodeName);
			foreach (DataRowView rw in dsEmployee.Select(DataSourceSelectArguments.Empty)) {
				string name = String.Format("p{0},{1}", rw.Row[2], Guid.NewGuid());
				string text = String.Format("{0} {1}", rw.Row[0], rw.Row[1], rw.Row[2]);
				TreeViewVirtualNode node = new TreeViewVirtualNode(name, FormatText(text));
				node.IsLeaf = !HasChildNodes(dsPubInfo, "pub_id", rw.Row[2].ToString());
				list.Add(node);
			}
			e.Children = list;
			return;
		}
		if (e.NodeName[0] == 'p') {
			dsPubInfo.SelectParameters["pub_id"].DefaultValue = GetId(e.NodeName);
			foreach (DataRowView rw in dsPubInfo.Select(DataSourceSelectArguments.Empty)) {
				TreeViewVirtualNode node = new TreeViewVirtualNode(Guid.NewGuid().ToString(), FormatText(rw.Row[0].ToString()));
				node.IsLeaf = true;
				list.Add(node);
			}
			e.Children = list;
		}
	}
	private string GetId(string nodeName) {
		return nodeName.Split(',')[0].Substring(1);
	}
	private string FormatText(string text) {
		if (text.Length > 40)
			return text.Substring(0, 40) + "...";
		return text;
	}
	private bool HasChildNodes(SqlDataSource ds, params string[] parameters) {
		if (parameters != null)
			ds.SelectParameters[parameters[0]].DefaultValue = parameters[1];
		DataView dw = (DataView)ds.Select(DataSourceSelectArguments.Empty);
		return dw.Table.Rows.Count > 0;
	}
}
