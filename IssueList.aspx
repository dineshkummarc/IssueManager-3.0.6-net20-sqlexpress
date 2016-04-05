<!--ASPX page @1-E397871F-->
<%@ Page language="c#" CodeFile="IssueList.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.IssueList.IssueListPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.IssueList" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=IssueListContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_issue_list%></title>


<meta content="CodeCharge Studio 3.0.4.5" name="GENERATOR">

<link rel="stylesheet" type="text/css" href="Styles/<%=PageStyleName%>/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<IssueManager:Header id="Header" runat="server"/> <IssueManager:AdminMenu id="AdminMenu" runat="server"/> 

  <span id="issuesSearchHolder" runat="server">
    
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      

        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.im_search%></th>
 
            <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="issuesSearchError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="issuesSearchErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.im_keyword%>&nbsp;</th>
 
            <td><asp:TextBox id="issuesSearchs_issue_name" maxlength="100" Columns="50"

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
              <input id='issuesSearchDoSearch' class="Button" type="submit" value="<%#Resources.strings.CCS_Search%>" OnServerClick='issuesSearch_Search' runat="server"/>&nbsp;</td>
          </tr>
        </table>
      

    </td>
  </tr>
</table>
<br>

  </span>
  

<asp:repeater id="issuesRepeater" OnItemCommand="issuesItemCommand" OnItemDataBound="issuesItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.im_issue_list%></th>
 
          <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th style="text-align:center">
          <CC:Sorter id="Sorter_issue_idSorter" field="Sorter_issue_id" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_issue_idSort" runat="server"><%#Resources.strings.im_issue_no%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_issue_nameSorter" field="Sorter_issue_name" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_issue_nameSort" runat="server"><%#Resources.strings.im_issue_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter1Sorter" field="Sorter1" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter1Sort" runat="server"><%#Resources.strings.im_priority%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_status_idSorter" field="Sorter_status_id" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_status_idSort" runat="server"><%#Resources.strings.im_status%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_assigned_toSorter" field="Sorter_assigned_to" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_assigned_toSort" runat="server"><%#Resources.strings.im_assigned_to%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_date_submittedSorter" field="Sorter_date_submitted" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_date_submittedSort" runat="server"><%#Resources.strings.im_date_submitted%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_date_modifiedSorter" field="Sorter_date_modified" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_date_modifiedSort" runat="server"><%#Resources.strings.im_date_modified%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
          <th>
          <CC:Sorter id="Sorter_date_resolvedSorter" field="Sorter_date_resolved" OwnerState="<%# issuesData.SortField.ToString()%>" OwnerDir="<%# issuesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_date_resolvedSort" runat="server"><%#Resources.strings.im_date_resolved%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td align="center"><asp:Literal id="issuesissue_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).issue_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><a id="issuesissue_name" href="" runat="server"  ><%#((issuesItem)Container.DataItem).issue_name.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="issuespriority" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).priority.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="issuesstatus_id" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).status_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="issuesassigned_to" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).assigned_to.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="issuesdate_submitted" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_submitted.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="issuesdate_modified" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_modified.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="issuesdate_resolved" Text='<%# Server.HtmlEncode(((issuesItem)Container.DataItem).date_resolved.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="8"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td>
        </tr>
        
  </asp:PlaceHolder>

        <tr class="Footer">
          <td nowrap colspan="8">
            
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
      </table>
    </td>
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>
<IssueManager:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

