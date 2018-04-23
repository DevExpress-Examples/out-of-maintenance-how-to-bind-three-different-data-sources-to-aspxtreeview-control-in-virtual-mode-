# How to bind three different data sources to ASPxTreeView control in virtual mode


<p>This example shows how to use a virtual mode for the ASPxTreeView control. There are three data sources in the example (SqlDataSource). Nodes of the first level will be obtained from the first data source data. Its child nodes (nodes of the second level) depend on its parent node (nodes of the first level) value. They are obtained from the second data source. And the node list of the third level also depends on its parent node (the node of the second level) value and is obtained from the third data source</p><p>Take a look at the node's name. Its value has a prefix (a letter), a digit value and a Guid.  <br />
We should create a child node list just in VirtualModeCreateChildren event handler. But there is no any information about the node's level. We use a parent's prefix to determine the appropriate data source.   <br />
Digit value is an id which we will use for selecting child nodes. <br />
A Guid is separated by a comma. Since the name of each ASPxTreeView's node should be unique, but in different data sources items can have equal identifiers, we append a Guid to the node's name.</p><p><strong>See also:</strong><strong><br />
</strong><strong><br />
</strong><a href="https://www.devexpress.com/Support/Center/p/E2872">How to bind the ASPxTreeView to plain data (Virtual mode)</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2538">How to handle the VirtualModeCreateChildren event</a></p>

<br/>


