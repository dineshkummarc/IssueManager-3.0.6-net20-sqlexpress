<!--ASPX page @1-80EBD810-->
<%@ Page language="c#" CodeFile="PriorityList.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.PriorityList.PriorityListPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.PriorityList" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=PriorityListContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_priorities%></title>


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
<table border="0">
  <tr>
    <td valign="top">
      
<asp:repeater id="prioritiesRepeater" OnItemCommand="prioritiesItemCommand" OnItemDataBound="prioritiesItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.im_priorities%></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Caption">
                <th>
                <CC:Sorter id="Sorter_priority_descSorter" field="Sorter_priority_desc" OwnerState="<%# prioritiesData.SortField.ToString()%>" OwnerDir="<%# prioritiesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_priority_descSort" runat="server"><%#Resources.strings.im_priority%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                <th><%=Resources.strings.im_priority_transl%>&nbsp;</th>
 
                <th>
                <CC:Sorter id="Sorter_priority_colorSorter" field="Sorter_priority_color" OwnerState="<%# prioritiesData.SortField.ToString()%>" OwnerDir="<%# prioritiesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_priority_colorSort" runat="server"><%#Resources.strings.im_color%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                <th>
                <CC:Sorter id="Sorter_priority_orderSorter" field="Sorter_priority_order" OwnerState="<%# prioritiesData.SortField.ToString()%>" OwnerDir="<%# prioritiesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_priority_orderSort" runat="server"><%#Resources.strings.im_order%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="prioritiespriority_desc" href="" runat="server"  ><%#((prioritiesItem)Container.DataItem).priority_desc.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="prioritiespriority_transl" Text='<%# Server.HtmlEncode(((prioritiesItem)Container.DataItem).priority_transl.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="prioritiespriority_color" Text='<%# Server.HtmlEncode(((prioritiesItem)Container.DataItem).priority_color.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="prioritiespriority_order" Text='<%# Server.HtmlEncode(((prioritiesItem)Container.DataItem).priority_order.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="4"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td>
              </tr>
              
  </asp:PlaceHolder>

              <tr class="Footer">
                <td nowrap colspan="4">
                  
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# prioritiesData.PagesCount%>" PageNumber="<%# prioritiesData.PageNumber%>" runat="server">
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
                <td nowrap colspan="4">
                                        [<a id="prioritiesLink1" href="" runat="server"  ><%#Resources.strings.im_add_new_priority%></a>]
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
      
  <span id="priorities1Holder" runat="server">
    
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            

              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_priority%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="priorities1Error" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="priorities1ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.im_priority%>&nbsp;*</th>
 
                  <td><asp:TextBox id="priorities1priority_desc" maxlength="50" Columns="40"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_priority_transl%>&nbsp;</th>
 
                  <td><asp:Literal id="priorities1priority_transl" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_color%>&nbsp;</th>
 
                  <td><asp:TextBox id="priorities1priority_color" maxlength="30"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_order%>&nbsp;</th>
 
                  <td><asp:TextBox id="priorities1priority_order" maxlength="10" Columns="10"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Footer">
                  <td align="right" colspan="2">
                    <input id='priorities1Insert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='priorities1_Insert' runat="server"/>
                    <input id='priorities1Update' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='priorities1_Update' runat="server"/>
                    <input id='priorities1Delete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='priorities1_Delete' runat="server"/>
                    <input id='priorities1Cancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='priorities1_Cancel' runat="server"/>&nbsp;</td>
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

