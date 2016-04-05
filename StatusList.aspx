<!--ASPX page @1-188E9EAE-->
<%@ Page language="c#" CodeFile="StatusList.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.StatusList.StatusListPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.StatusList" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=StatusListContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_statuses%></title>


<meta content="CodeCharge Studio 3.0.4.5" name="GENERATOR">

<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<IssueManager:Header id="Header" runat="server"/> <IssueManager:AdminMenu id="AdminMenu" runat="server"/> 
<table border="0">
  <tr>
    <td valign="top">
      
<asp:repeater id="statusesRepeater" OnItemCommand="statusesItemCommand" OnItemDataBound="statusesItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.im_statuses%></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="3">
              <tr class="Caption">
                <th>
                <CC:Sorter id="Sorter_statusSorter" field="Sorter_status" OwnerState="<%# statusesData.SortField.ToString()%>" OwnerDir="<%# statusesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_statusSort" runat="server"><%#Resources.strings.im_status%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                <th><%=Resources.strings.im_status_transl%></th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="statusesstatus" href="" runat="server"  ><%#((statusesItem)Container.DataItem).status.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="statusesstatus_transl" Text='<%# Server.HtmlEncode(((statusesItem)Container.DataItem).status_transl.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></td>
              </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="2"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td>
              </tr>
              
  </asp:PlaceHolder>

              <tr class="Footer">
                <td nowrap colspan="2">
                  
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# statusesData.PagesCount%>" PageNumber="<%# statusesData.PageNumber%>" runat="server">
 <CC:NavigatorItem type="FirstOn" runat="server"><asp:LinkButton id="NavigatorFirst" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/First.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="FirstOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/FirstOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOn" runat="server"><asp:LinkButton id="NavigatorPrev" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Prev.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="PrevOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/PrevOff.gif"%>' border="0"></CC:NavigatorItem>&nbsp; 
<CC:Pager id="NavigatorPager" Style="Centered" PagerSize="10" runat="server">
 <PageOnTemplate><asp:LinkButton runat="server"><%# ((PagerItem)Container).PageNumber.ToString() %></asp:LinkButton></PageOnTemplate>
 <PageOffTemplate><%# ((PagerItem)Container).PageNumber.ToString() %></PageOffTemplate></CC:Pager>&nbsp;<%#Resources.strings.CCS_Of%>&nbsp;<%# ((Navigator)Container).MaxPage.ToString() %>&nbsp; <CC:NavigatorItem type="NextOn" runat="server"><asp:LinkButton id="NavigatorNext" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Next.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="NextOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/NextOff.gif"%>' border="0"></CC:NavigatorItem>
 <CC:NavigatorItem type="LastOn" runat="server"><asp:LinkButton id="NavigatorLast" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Last.gif"%>' border="0"></asp:LinkButton> </CC:NavigatorItem>
 <CC:NavigatorItem type="LastOff" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/LastOff.gif"%>' border="0"></CC:NavigatorItem></CC:Navigator>&nbsp;</td>
              </tr>
              <tr class="Footer">
                <td nowrap colspan="2">
                                        [<a id="statusesLink1" href="" runat="server"  ><%#Resources.strings.im_add_new_status%></a>]
                                </td>
                          </tr>
            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>

        </td> 
    <td valign="top">
      
  <span id="statuses1Holder" runat="server">
    
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            

              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_status%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="3">
                
  <asp:PlaceHolder id="statuses1Error" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="statuses1ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.im_status%>&nbsp;*</th>
 
                  <td><asp:TextBox id="statuses1status" maxlength="50" Columns="40"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_status_transl%>&nbsp;</th>
 
                  <td><asp:Literal id="statuses1status_transl" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Footer">
                  <td align="right" colspan="2">
                    <input id='statuses1Insert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='statuses1_Insert' runat="server"/>
                    <input id='statuses1Update' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='statuses1_Update' runat="server"/>
                    <input id='statuses1Delete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='statuses1_Delete' runat="server"/>
                    <input id='statuses1Cancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='statuses1_Cancel' runat="server"/>&nbsp;</td>
                </tr>
              </table>
            

          </td>
        </tr>
      </table>
      
  </span>
  </td>
  </tr>
</table>
<IssueManager:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

