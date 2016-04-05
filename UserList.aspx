<!--ASPX page @1-C095DED5-->
<%@ Page language="c#" CodeFile="UserList.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.UserList.UserListPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.UserList" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=UserListContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_users%></title>


<meta content="CodeCharge Studio 3.0.4.5" name="GENERATOR">

<link rel="stylesheet" type="text/css" href="Styles/<%=PageStyleName%>/Style.css">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<IssueManager:Header id="Header" runat="server"/>
<IssueManager:AdminMenu id="AdminMenu" runat="server"/> 

<asp:repeater id="usersRepeater" OnItemCommand="usersItemCommand" OnItemDataBound="usersItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0">
<tr>
<td valign="top">
              <table cellspacing="0" cellpadding="0" border="0" class="Header">
                <tr>
                  <td class="HeaderLeft"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
                  <th><%=Resources.strings.im_users%></th>
                  <td class="HeaderRight"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
                </tr>
              </table>

<table class="Grid" cellspacing="0" cellpadding="3">
  <tr class="Caption">
    <th>
      <CC:Sorter id="Sorter_user_nameSorter" field="Sorter_user_name" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_user_nameSort" runat="server"><%#Resources.strings.im_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>'></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>'></CC:SorterItem></CC:Sorter>&nbsp;</th> 
    <th>
      <CC:Sorter id="Sorter_emailSorter" field="Sorter_email" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_emailSort" runat="server"><%#Resources.strings.im_email%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>'></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>'></CC:SorterItem></CC:Sorter>&nbsp;</th> 
    <th>
      <CC:Sorter id="Sorter_security_levelSorter" field="Sorter_security_level" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_security_levelSort" runat="server"><%#Resources.strings.im_security_level%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>'></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>'></CC:SorterItem></CC:Sorter>&nbsp;</th> 
    <th>
      <CC:Sorter id="Sorter_allow_uploadSorter" field="Sorter_allow_upload" OwnerState="<%# usersData.SortField.ToString()%>" OwnerDir="<%# usersData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_allow_uploadSort" runat="server"><%#Resources.strings.im_allow_upload%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>'></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>'></CC:SorterItem></CC:Sorter>&nbsp;</th> 
  </tr>
  
  </HeaderTemplate>
  <ItemTemplate>
  <tr class="Row">
<td  ><a id="usersuser_name" href="" runat="server"  ><%#((usersItem)Container.DataItem).user_name.GetFormattedValue()%></a>&nbsp;</td> 
    <td ><asp:Literal id="usersemail" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).email.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td ><asp:Literal id="userssecurity_level" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).security_level.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
    <td  align="middle"><asp:Literal id="usersallow_upload" Text='<%# Server.HtmlEncode(((usersItem)Container.DataItem).allow_upload.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
  </tr>
  
  </ItemTemplate>
  <FooterTemplate>
	
  
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    <tr class="NoRecords"><td  colspan="4"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td></tr>
  </asp:PlaceHolder>

  <tr class="Footer">
        <td nowrap colspan="4">
      
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# usersData.PagesCount%>" PageNumber="<%# usersData.PageNumber%>" runat="server">
 <CC:NavigatorItem type="FirstOn" runat="server"> <asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"> <img src='<%#"Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"> <asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"> <img src='<%#"Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"> </CC:NavigatorItem>
 &nbsp;
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
 <PageOnTemplate><asp:LinkButton runat="server"><%# ((PagerItem)Container).PageNumber.ToString() %></asp:LinkButton>&nbsp;</PageOnTemplate> <PageOffTemplate><%# ((PagerItem)Container).PageNumber.ToString() %>&nbsp;</PageOffTemplate>
  </CC:Pager><%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"> <asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"> <img src='<%#"Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"> <asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"> <img src='<%#"Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"> </CC:NavigatorItem>
</CC:Navigator>&nbsp;</td> 
  </tr>
  <tr class="Footer">
        <td nowrap colspan="4">
                [<a id="usersLink1" href="" runat="server"  ><%#Resources.strings.im_add_new_user%></a>]
        </td>
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

