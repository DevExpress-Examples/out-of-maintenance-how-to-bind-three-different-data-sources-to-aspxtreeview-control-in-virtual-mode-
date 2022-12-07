Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web
Imports System.Collections.Generic

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub ASPxTreeView1_VirtualModeCreateChildren(ByVal source As Object, ByVal e As TreeViewVirtualModeCreateChildrenEventArgs)
		Dim list As List(Of TreeViewVirtualNode) = New List(Of TreeViewVirtualNode)()
		If e.NodeName Is Nothing Then
			For Each rw As DataRowView In dsJobs.Select(DataSourceSelectArguments.Empty)
				Dim name As String = String.Format("e{0},{1}", rw.Row(0), Guid.NewGuid())
				Dim node As New TreeViewVirtualNode(name, FormatText(rw.Row(1).ToString()))
				node.IsLeaf = Not HasChildNodes(dsEmployee, "job_id", rw.Row(0).ToString())
				list.Add(node)
			Next rw
			e.Children = list
			Return
		End If
		If e.NodeName(0) = "e"c Then
			dsEmployee.SelectParameters("job_id").DefaultValue = GetId(e.NodeName)
			For Each rw As DataRowView In dsEmployee.Select(DataSourceSelectArguments.Empty)
				Dim name As String = String.Format("p{0},{1}", rw.Row(2), Guid.NewGuid())
				Dim text As String = String.Format("{0} {1}", rw.Row(0), rw.Row(1), rw.Row(2))
				Dim node As New TreeViewVirtualNode(name, FormatText(text))
				node.IsLeaf = Not HasChildNodes(dsPubInfo, "pub_id", rw.Row(2).ToString())
				list.Add(node)
			Next rw
			e.Children = list
			Return
		End If
		If e.NodeName(0) = "p"c Then
			dsPubInfo.SelectParameters("pub_id").DefaultValue = GetId(e.NodeName)
			For Each rw As DataRowView In dsPubInfo.Select(DataSourceSelectArguments.Empty)
				Dim node As New TreeViewVirtualNode(Guid.NewGuid().ToString(), FormatText(rw.Row(0).ToString()))
				node.IsLeaf = True
				list.Add(node)
			Next rw
			e.Children = list
		End If
	End Sub
	Private Function GetId(ByVal nodeName As String) As String
		Return nodeName.Split(","c)(0).Substring(1)
	End Function
	Private Function FormatText(ByVal text As String) As String
		If text.Length > 40 Then
			Return text.Substring(0, 40) & "..."
		End If
		Return text
	End Function
	Private Function HasChildNodes(ByVal ds As SqlDataSource, ParamArray ByVal parameters() As String) As Boolean
		If parameters IsNot Nothing Then
			ds.SelectParameters(parameters(0)).DefaultValue = parameters(1)
		End If
		Dim dw As DataView = CType(ds.Select(DataSourceSelectArguments.Empty), DataView)
		Return dw.Table.Rows.Count > 0
	End Function
End Class
