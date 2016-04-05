<!--ASPX page @1-9A96E2A1-->
<%@ Page language="c#" CodeFile="Default.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.Default.DefaultPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.Default" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=DefaultContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_issue_list%></title>


<meta content="CodeCharge Studio 3.0.4.5" name="GENERATOR">

<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<IssueManager:Header id="Header" runat="server"/> 
<table>
  <tr valign="top">
    <td>
      
  <span id="issuesSearchHolder" runat="server">
    
      

        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.im_search%></th>
 
            <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="issuesSearchError" visible="False" runat="server">
  
          <tr>
            <td class="Error" colspan="2"><asp:Label ID="issuesSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.im_keyword%>&nbsp;</th>
 
            <td><asp:TextBox id="issuesSearchs_issue_desc" Columns="35"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_priority%>&nbsp;</th>
 
            <td>
              <select id="issuesSearchs_priority_id"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_status%></th>
 
            <td>
              <select id="issuesSearchs_status_id"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_status_is_not%></th>
 
            <td>
              <select id="issuesSearchs_notstatus_id"  runat="server"></select>
 </td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_assigned_to%>&nbsp;</th>
 
            <td>
              <select id="issuesSearchs_assigned_to"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Bottom">
            <td align="right" colspan="2">
              <input id='issuesSearchDoSearch' class="Button" type="submit" value="<%#Resources.strings.im_search%>" OnServerClick='issuesSearch_Search' runat="server"/>&nbsp;</td>
          </tr>
        </table>
      

      
  </span>
  </td> 
    <td>
      <!-- Bookmarks -->
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.im_bookmarks%></th>
 
          <td class="HeaderRight"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Row">
          <td><a id="Link1" href="" runat="server"  ><%#Resources.strings.im_all_issues%></a></td>
        </tr>
 
        <tr class="Row">
          <td><a id="Link2" href="" runat="server"  ><%#Resources.strings.im_pending_by_update%></a></td>
        </tr>
 
        <tr class="Row">
          <td><a id="Link4" href="" runat="server"  ><%#Resources.strings.im_assigned_by_me%></a></td>
        </tr>
 
        <tr class="Row">
          <td><a id="Link5" href="" runat="server"  ><%#Resources.strings.im_assigned_to_me%></a></td>
        </tr>
      </table>
    </td> 
    <td>
      
<asp:repeater id="summaryRepeater" OnItemCommand="summaryItemCommand" OnItemDataBound="summaryItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.im_summary%></th>
 
          <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="summaryLabel1" href="" runat="server"  ><%#((summaryItem)Container.DataItem).Label1.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="summaryLabel2" Text='<%# Server.HtmlEncode(((summaryItem)Container.DataItem).Label2.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="2"><%=Resources.strings.CCS_NoRecords%></td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
      
  </FooterTemplate>
</asp:repeater>
</td>
  </tr>
</table>

<asp:repeater id="issuesRepeater" OnItemCommand="issuesItemCommand" OnItemDataBound="issuesItemDataBound" runat="server">
  <HeaderTemplate>
	
<table class="Header" cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
    <th><asp:Literal id="issuestitle" runat="server"/></th>
 
    <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
  </tr>
</table>
<table class="Grid" cellspacing="0" cellpadding="0">
  <tr class="Caption">
    <th style="TEXT-ALIGN: center">
    <CC:Sorter id="Sorter_issue_idSorter" field="Sorter_issue_id" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_issue_idSort" runat="server"><%#Resources.strings.im_issue_no%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_issue_nameSorter" field="Sorter_issue_name" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_issue_nameSort" runat="server"><%#Resources.strings.im_issue_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_status_idSorter" field="Sorter_status_id" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_status_idSort" runat="server"><%#Resources.strings.im_status%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_priority_idSorter" field="Sorter_priority_id" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_priority_idSort" runat="server"><%#Resources.strings.im_priority%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_assigned_toSorter" field="Sorter_assigned_to" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_assigned_toSort" runat="server"><%#Resources.strings.im_assigned_to%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_date_submittedSorter" field="Sorter_date_submitted" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_date_submittedSort" runat="server"><%#Resources.strings.im_date_submitted%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_date_modifiedSorter" field="Sorter_date_modified" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_date_modifiedSort" runat="server"><%#Resources.strings.im_last_update%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th style="TEXT-ALIGN: center">
    <CC:Sorter id="Sorter_testedSorter" field="Sorter_tested" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_testedSort" runat="server"><%#Resources.strings.im_tested%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th style="TEXT-ALIGN: center">
    <CC:Sorter id="Sorter_approvedSorter" field="Sorter_approved" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_approvedSort" runat="server"><%#Resources.strings.im_approved%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
    <th>
    <CC:Sorter id="Sorter_versionSorter" field="Sorter_version" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_versionSort" runat="server"><%#Resources.strings.im_version%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
  </tr>
 
  
  </HeaderTemplate>
  <ItemTemplate>
  <tr class="Row">
    <td align="middle"><asp:Literal id="issuesissue_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).issue_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td><a id="issuesissue_name" href="" runat="server"  ><%#((issuesItem)Container.DataItem).issue_name.GetFormattedValue()%></a>&nbsp;</td> 
    <td><asp:Literal id="issuesstatus_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).status_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td>
 <!--<asp:Literal id="issuescolor" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).color.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>-->
      <asp:Literal id="issuespriority_id" Text='<%# ((issuesItem)Container.DataItem).priority_id.GetFormattedValue() %>' runat="server"/>&nbsp;</td> 
    <td>
 <!--<asp:Literal id="issuesassigned_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).assigned_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>-->
      <asp:Literal id="issuesassigned_to" Text='<%# ((issuesItem)Container.DataItem).assigned_to.GetFormattedValue() %>' runat="server"/>&nbsp;</td> 
    <td nowrap><asp:Literal id="issuesdate_submitted" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_submitted.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td nowrap><asp:Literal id="issuesdate_modified" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_modified.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td align="middle"><asp:Literal id="issuestested" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).tested.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td align="middle"><asp:Literal id="issuesapproved" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).approved.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td><asp:Literal id="issuesversion" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).version.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
  </tr>
 
  </ItemTemplate>
  <AlternatingItemTemplate>
	
  <tr class="AltRow">
    <td align="middle"><asp:Literal id="issuesissue_id1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).issue_id1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td><a id="issuesissue_name1" href="" runat="server"  ><%#((issuesItem)Container.DataItem).issue_name1.GetFormattedValue()%></a>&nbsp;</td> 
    <td><asp:Literal id="issuesstatus_id1" Text='<%# ((issuesItem)Container.DataItem).status_id1.GetFormattedValue() %>' runat="server"/>&nbsp;</td> 
    <td>
 <!--<asp:Literal id="issuescolor1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).color1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>-->
      <asp:Literal id="issuespriority_id1" Text='<%# ((issuesItem)Container.DataItem).priority_id1.GetFormattedValue() %>' runat="server"/>&nbsp;</td> 
    <td>
 <!--<asp:Literal id="issuesassigned_id1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).assigned_id1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>-->
      <asp:Literal id="issuesassigned_to1" Text='<%# ((issuesItem)Container.DataItem).assigned_to1.GetFormattedValue() %>' runat="server"/>&nbsp;</td> 
    <td nowrap><asp:Literal id="issuesdate_submitted1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_submitted1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td nowrap><asp:Literal id="issuesdate_modified1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_modified1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td align="middle"><asp:Literal id="issuestested1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).tested1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td align="middle"><asp:Literal id="issuesapproved1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).approved1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td><asp:Literal id="issuesversion1" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).version1.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
  </tr>
 
  </AlternatingItemTemplate>
  <FooterTemplate>
	
  
  
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
  <tr class="NoRecords">
    <td colspan="10"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td>
  </tr>
  
  </asp:PlaceHolder>

  <tr class="Footer">
    <td nowrap colspan="10">
      
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# issuesData.PagesCount%>" PageNumber="<%# issuesData.PageNumber%>" runat="server">
 <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"></CC:NavigatorItem>&nbsp; 
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
 <PageOnTemplate><asp:LinkButton runat="server"><%# ((PagerItem)Container).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate>
 <PageOffTemplate><%# ((PagerItem)Container).PageNumber.ToString() %>&nbsp;</PageOffTemplate></CC:Pager><%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"></CC:NavigatorItem></CC:Navigator>&nbsp;</td>
  </tr>
 
  <tr class="Footer">
    <td colspan="10">[<a id="issuesLink6" href="" runat="server"  ><%#Resources.strings.im_add_new_issue%></a>]&nbsp;[<a id="issuesLink7" href="" runat="server"  ><%#Resources.strings.im_export_to_excel%></a>] </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<IssueManager:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

