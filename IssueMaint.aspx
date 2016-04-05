<!--ASPX page @1-EB4B9B73-->
<%@ Page language="c#" CodeFile="IssueMaint.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.IssueMaint.IssueMaintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.IssueMaint" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=IssueMaintContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_issue_maint%></title>


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
<table width="100%" border="0">
  <tr>
    <td valign="top" width="50%">
      
  <span id="issuesHolder" runat="server">
    
      <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
          <td valign="top">
            

              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_issue_maint%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="issuesError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="issuesErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  

                                <tr class="Controls">
                                  <th><%=Resources.strings.im_issue_no%>&nbsp;</th>
 
                                  <td><asp:Literal id="issuesissue_id" runat="server"/>&nbsp;</td> 
                                </tr>

                <tr class="Controls">
                  <th><%=Resources.strings.im_issue_name%>&nbsp;*</th>
 
                  <td><asp:TextBox id="issuesissue_name" maxlength="100" Columns="50"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_issue_description%>&nbsp;*&nbsp;</th>
 
                  <td><asp:TextBox id="issuesissue_desc" rows="3" Columns="50" TextMode="MultiLine"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_user_submitted%>&nbsp;*</th>
 
                  <td>
                    <select id="issuesuser_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_modified_by%>&nbsp;*</th>
 
                  <td>
                    <select id="issuesmodified_by"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_date_submitted%>&nbsp;*</th>
 
                  <td><asp:TextBox id="issuesdate_submitted" Columns="30"

	runat="server"/>&nbsp;<asp:Literal id="issuesdate_format" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_version%>&nbsp;</th>
 
                  <td><asp:TextBox id="issuesversion" maxlength="10" Columns="10"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_tested%>&nbsp;</th>
 
                  <td><asp:CheckBox id="issuestested" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_approved%>&nbsp;</th>
 
                  <td><asp:CheckBox id="issuesapproved" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_assigned_to_orig%>&nbsp;*</th>
 
                  <td>
                    <select id="issuesassigned_to_orig"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_assigned_to%>&nbsp;*</th>
 
                  <td>
                    <select id="issuesassigned_to"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_status%>&nbsp;*</th>
 
                  <td>
                    <select id="issuesstatus_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_priority%>&nbsp;*</th>
 
                  <td>
                    <select id="issuespriority_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Footer">
                  <td align="right" colspan="2">
                    <input id='issuesInsert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='issues_Insert' runat="server"/>
                    <input id='issuesUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='issues_Update' runat="server"/>
                    <input id='issuesDelete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='issues_Delete' runat="server"/>
                    <input id='issuesCancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='issues_Cancel' runat="server"/>&nbsp;</td>
                </tr>
              </table>
            

          </td>
        </tr>
      </table>
      <br>
      
  </span>
  
      
<asp:repeater id="filesRepeater" OnItemCommand="filesItemCommand" OnItemDataBound="filesItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.im_list_of_files%></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Caption">
                <th>
                <CC:Sorter id="Sorter_file_nameSorter" field="Sorter_file_name" OwnerState="<%# filesData.SortField.ToString()%>" OwnerDir="<%# filesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_file_nameSort" runat="server"><%#Resources.strings.im_file_name%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                <th>
                <CC:Sorter id="Sorter_uploaded_bySorter" field="Sorter_uploaded_by" OwnerState="<%# filesData.SortField.ToString()%>" OwnerDir="<%# filesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_uploaded_bySort" runat="server"><%#Resources.strings.im_uploaded_by%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
 
                <th>
                <CC:Sorter id="Sorter_date_uploadedSorter" field="Sorter_date_uploaded" OwnerState="<%# filesData.SortField.ToString()%>" OwnerDir="<%# filesData.SortDir%>" runat="server"><asp:LinkButton id="Sorter_date_uploadedSort" runat="server"><%#Resources.strings.im_date_uploaded%></asp:LinkButton> <CC:SorterItem type="AscOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Asc.gif"%>' border="0"></CC:SorterItem>
 <CC:SorterItem type="DescOn" runat="server"><img src='<%#"Styles/" + PageStyleName + "/Images/Desc.gif"%>' border="0"></CC:SorterItem></CC:Sorter>&nbsp;</th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="filesfile_name" href="" runat="server"  ><%#((filesItem)Container.DataItem).file_name.GetFormattedValue()%></a>&nbsp;</td> 
                <td><asp:Literal id="filesuploaded_by" Text='<%# Server.HtmlEncode(((filesItem)Container.DataItem).uploaded_by.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
                <td><asp:Literal id="filesdate_uploaded" Text='<%# Server.HtmlEncode(((filesItem)Container.DataItem).date_uploaded.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td colspan="3"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td>
              </tr>
              
  </asp:PlaceHolder>

              <tr class="Footer">
                <td nowrap colspan="3">&nbsp; 
                  
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# filesData.PagesCount%>" PageNumber="<%# filesData.PageNumber%>" runat="server">
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
</td> 
    <td valign="top" width="50%">
      
<asp:repeater id="responsesRepeater" OnItemCommand="responsesItemCommand" OnItemDataBound="responsesItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.im_response_history%></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="AltRow">
                <td><%=Resources.strings.im_user_submitted%>&nbsp;</td> 
                <td><asp:Literal id="responsesuser_id" Text='<%# Server.HtmlEncode(((responsesItem)Container.DataItem).user_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="AltRow">
                <td><%=Resources.strings.im_date_response%>&nbsp;</td> 
                <td><asp:Literal id="responsesdate_response" Text='<%# Server.HtmlEncode(((responsesItem)Container.DataItem).date_response.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="AltRow">
                <td><%=Resources.strings.im_response%></td> 
                <td><asp:Literal id="responsesresponse" Text='<%# Server.HtmlEncode(((responsesItem)Container.DataItem).response.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="AltRow">
                <td><%=Resources.strings.im_assigned_to%>&nbsp;</td> 
                <td><asp:Literal id="responsesassigned_to" Text='<%# Server.HtmlEncode(((responsesItem)Container.DataItem).assigned_to.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="AltRow">
                <td><%=Resources.strings.im_priority%>&nbsp;</td> 
                <td><asp:Literal id="responsespriority_id" Text='<%# Server.HtmlEncode(((responsesItem)Container.DataItem).priority_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="AltRow">
                <td><%=Resources.strings.im_status%>&nbsp;</td> 
                <td><asp:Literal id="responsesstatus_id" Text='<%# Server.HtmlEncode(((responsesItem)Container.DataItem).status_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
              </tr>
 
              <tr class="Row">
                <td colspan="2">[<a id="responsesLink1" href="" runat="server"  ><%#Resources.strings.im_edit_link%></a>]&nbsp;</td>
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
                  
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# responsesData.PagesCount%>" PageNumber="<%# responsesData.PageNumber%>" runat="server">
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
</td>
  </tr>
</table>
<IssueManager:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

