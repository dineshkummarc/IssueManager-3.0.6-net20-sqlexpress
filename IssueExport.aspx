<!--ASPX page @1-106AE171-->
<%@ Page language="c#" CodeFile="IssueExport.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.IssueExport.IssueExportPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.IssueExport" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=IssueExportContentMeta%>">
<title><%=Resources.strings.im_export_to_excel%></title>


<meta content="CodeCharge Studio 3.0.4.5" name="GENERATOR">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">



<asp:repeater id="issuesRepeater" OnItemCommand="issuesItemCommand" OnItemDataBound="issuesItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
<tr>
<td valign="top">
              <table cellspacing="0" cellpadding="0" border="0" class="Header">
                <tr>
                  <th><asp:Literal id="issuestitle" runat="server"/></th>
                </tr>
              </table>

<table class="Grid" cellspacing="0" cellpadding="3" border="1">
  <tr class="Caption">
    <th><%=Resources.strings.im_issue_no%>&nbsp;</th>
    <th><%=Resources.strings.im_issue_name%>&nbsp;</th>
    <th><%=Resources.strings.im_issue_description%>&nbsp;</th>
    <th><%=Resources.strings.im_status%>&nbsp;</th>
    <th><%=Resources.strings.im_priority%>&nbsp;</th>
    <th><%=Resources.strings.im_user_submitted%>&nbsp;</th>
    <th><%=Resources.strings.im_date_submitted%>&nbsp;</th>
    <th><%=Resources.strings.im_assigned_to_orig%>&nbsp;</th>
    <th><%=Resources.strings.im_assigned_to%>&nbsp;</th>
    <th><%=Resources.strings.im_updated_by%>&nbsp;</th>
    <th><%=Resources.strings.im_last_update%>&nbsp;</th>
    <th><%=Resources.strings.im_tested%>&nbsp;</th>
    <th><%=Resources.strings.im_approved%>&nbsp;</th>
    <th><%=Resources.strings.im_version%>&nbsp;</th>
  </tr>
  
  </HeaderTemplate>
  <ItemTemplate>
  <tr class="Row">
<td  ><asp:Literal id="issuesissue_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).issue_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesissue_name" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).issue_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesissue_desc" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).issue_desc.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesstatus_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).status_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><!--<asp:Literal id="issuescolor" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).color.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>--><asp:Literal id="issuespriority_id" Text='<%# ((issuesItem)Container.DataItem).priority_id.GetFormattedValue() %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesuser_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).user_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesdate_submitted" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_submitted.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesassigned_to_orig" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).assigned_to_orig.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><!--<asp:Literal id="issuesassigned_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).assigned_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>--><asp:Literal id="issuesassigned_to" Text='<%# ((issuesItem)Container.DataItem).assigned_to.GetFormattedValue() %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesmodified_by" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).modified_by.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesdate_modified" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_modified.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuestested" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).tested.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesapproved" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).approved.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
    <td ><asp:Literal id="issuesversion" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).version.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
  </tr>
  
  </ItemTemplate>
  <FooterTemplate>
	
  
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    <tr class="NoRecords"><td  colspan="14"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td></tr>
  </asp:PlaceHolder>

</table>

</td>
</tr>
</table>

  </FooterTemplate>
</asp:repeater>


</form>
</body>
</html>

<!--End ASPX page-->

