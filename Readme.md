<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128563761/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2956)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to bind three different data sources to ASPxTreeView control in virtual mode
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2956/)**
<!-- run online end -->


<p>This example shows how to use a virtual mode for the ASPxTreeView control. There are three data sources in the example (SqlDataSource). Nodes of the first level will be obtained from the first data source data. Its child nodes (nodes of the second level) depend on its parent node (nodes of the first level) value. They are obtained from the second data source. And the node list of the third level also depends on its parent node (the node of the second level) value and is obtained from the third data source</p><p>Take a look at the node's name. Its value has a prefix (a letter), a digit value and a Guid.  <br />
We should create a child node list just in VirtualModeCreateChildren event handler. But there is no any information about the node's level. We use a parent's prefix to determine the appropriate data source.   <br />
Digit value is an id which we will use for selecting child nodes. <br />
A Guid is separated by a comma. Since the name of each ASPxTreeView's node should be unique, but in different data sources items can have equal identifiers, we append a Guid to the node's name.</p><p><strong>See also:</strong><strong><br />
</strong><strong><br />
</strong><a href="https://www.devexpress.com/Support/Center/p/E2872">How to bind the ASPxTreeView to plain data (Virtual mode)</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2538">How to handle the VirtualModeCreateChildren event</a></p>

<br/>


