<!--ASPX page @1-39717C7D-->
<%@ Page language="c#" CodeFile="IssueChange.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.IssueChange.IssueChangePage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.IssueChange" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=IssueChangeContentMeta%>">

<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_issue_change%></title>

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
<table width="100%">
  <tr>
    <td valign="top" width="50%">
      
<asp:repeater id="issueRepeater" OnItemCommand="issueItemCommand" OnItemDataBound="issueItemDataBound" runat="server">
  <HeaderTemplate>
	
        
  </HeaderTemplate>
  <ItemTemplate>
        <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.im_issue_name%> #<asp:Literal id="issueissue_id" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).issue_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></th>
 
          <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
      </table>
 
      <table class="Record" cellspacing="0" cellpadding="0">

        <tr class="Controls">
          <td colspan="2"><b><asp:Literal id="issueissue_name" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).issue_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/></b>&nbsp;</td>
        </tr>
 
        <tr class="Separator">
          <td colspan="2"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
 
        <tr class="Controls">
          <td colspan="2"><asp:Literal id="issueissue_desc" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).issue_desc.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="Separator">
          <td colspan="2"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_user_submitted%>&nbsp;</td> 
          <td width="100%"><asp:Literal id="issueuser_id" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).user_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_date_submitted%>&nbsp;</td> 
          <td><asp:Literal id="issuedate_submitted" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).date_submitted.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_version%>&nbsp;</td> 
          <td><asp:Literal id="issueversion" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).version.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_tested%>&nbsp;</td> 
          <td><asp:Literal id="issuetested" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).tested.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_approved%>&nbsp;</td> 
          <td><asp:Literal id="issueapproved" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).approved.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_assigned_to_orig%>&nbsp;</td> 
          <td><asp:Literal id="issueassigned_to_orig" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).assigned_to_orig.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_assigned_to%>&nbsp;</td> 
          <td><asp:Literal id="issueassigned_to" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).assigned_to.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_priority%>&nbsp;</td> 
          <td><asp:Literal id="issuepriority_id" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).priority_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
        <tr class="AltRow">
          <td nowrap><%=Resources.strings.im_status%>&nbsp;</td> 
          <td><asp:Literal id="issuestatus_id" Text='<%# Server.HtmlEncode(((issueItem)Container.DataItem).status_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>

      </table>
          
  </ItemTemplate>
  <FooterTemplate>
	
      
  </FooterTemplate>
</asp:repeater>

      
<asp:repeater id="filesRepeater" OnItemCommand="filesItemCommand" OnItemDataBound="filesItemDataBound" runat="server">
  <HeaderTemplate>
	<br>
      <table class="Header" cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
          <th><%=Resources.strings.im_list_of_files%></th>
 
          <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
        </tr>
      </table>
 
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th><%=Resources.strings.im_file_name%></th>
 
          <th><%=Resources.strings.im_uploaded_by%></th>
 
          <th><%=Resources.strings.im_date_uploaded%></th>
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="filesfile_name" href="" target="_blank" runat="server"  ><%#((filesItem)Container.DataItem).file_name.GetFormattedValue()%></a>&nbsp;</td> 
          <td><asp:Literal id="filesuploaded_by" Text='<%# Server.HtmlEncode(((filesItem)Container.DataItem).uploaded_by.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td> 
          <td><asp:Literal id="filesdate_uploaded" Text='<%# Server.HtmlEncode(((filesItem)Container.DataItem).date_uploaded.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
        </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td class="NoRecords" colspan="3"><%=Resources.strings.CCS_NoRecords%>&nbsp;</td>
        </tr>
        
  </asp:PlaceHolder>

      </table>
      
  </FooterTemplate>
</asp:repeater>

      
  <span id="issuesHolder" runat="server">
    <br>
      

        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.im_response%></th>
 
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
            <th><%=Resources.strings.im_response%>&nbsp;*</td> 
          <td width="100%">
<asp:TextBox id="issuesissue_resp" style="WIDTH: 100%" rows="3" Columns="50" TextMode="MultiLine"

	runat="server"/>
</td>
        </tr>
 
        <tr class="Controls">
          <th><%=Resources.strings.im_assigned_to%>&nbsp; *</th>
 
          <td>
            <select id="issuesassigned_to"  runat="server"></select>
 </td>
        </tr>
 
        <tr class="Controls">
          <th><%=Resources.strings.im_priority%>&nbsp;*</th>
 
          <td>
            <select id="issuespriority_id"  runat="server"></select>
 </td>
        </tr>
 
        <tr class="Controls">
          <th><%=Resources.strings.im_status%>&nbsp;*</th>
 
          <td>
            <select id="issuesstatus_id"  runat="server"></select>
 </td>
        </tr>
 
        <tr class="Controls">
          <th><%=Resources.strings.im_version%>&nbsp;</th>
 
          <td><asp:TextBox id="issuesversion" maxlength="10" Columns="10"

	runat="server"/></td>
        </tr>
 
        <tr class="Controls">
          <th><%=Resources.strings.im_tested%>&nbsp;</th>
 
          <td><asp:CheckBox id="issuestested" runat="server"/></td>
        </tr>
 
        <tr class="Controls">
          <th><%=Resources.strings.im_approved%>&nbsp;</th>
 
          <td><asp:CheckBox id="issuesapproved" runat="server"/></td>
        </tr>
 
        <asp:PlaceHolder id="issuesUploadControls" Visible="True" runat="server">
	
        <tr class="Controls">
          <th><%=Resources.strings.im_file%></th>
 
          <td>
            
  <CC:FileUploadControl id="issuesattachment" DeleteCaption='<%=Resources.strings.CCS_Delete%> ' runat="server"/>
  </td>
        </tr>
 
	</asp:PlaceHolder>
        <tr class="Footer">
          <td colspan="2">
            <input id='issuesInsert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='issues_Insert' runat="server"/>&nbsp;</td>
        </tr>
      </table>
      
  <input id="issuesFormAction" type="hidden"  runat="server"/>
  
  <input id="issuesdate_now" type="hidden"  runat="server"/>
  
    

    
  </span>
  </td> 
  <td valign="top" width="50%" rowspan="2">
    
<asp:repeater id="responses1Repeater" OnItemCommand="responses1ItemCommand" OnItemDataBound="responses1ItemDataBound" runat="server">
  <HeaderTemplate>
	
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
 
      <tr class="Row">
        <td colspan="2"><asp:Literal id="responses1response" Text='<%# Server.HtmlEncode(((responses1Item)Container.DataItem).response.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
      </tr>
 
      <tr class="AltRow">
        <td nowrap><%=Resources.strings.im_user_submitted%>&nbsp;</td> 
        <td width="100%"><asp:Literal id="responses1user_id" Text='<%# Server.HtmlEncode(((responses1Item)Container.DataItem).user_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
      </tr>
 
      <tr class="AltRow">
        <td nowrap><%=Resources.strings.im_date_response%>&nbsp;</td> 
        <td><asp:Literal id="responses1date_response" Text='<%# Server.HtmlEncode(((responses1Item)Container.DataItem).date_response.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
      </tr>
 
      <tr class="AltRow">
        <td nowrap><%=Resources.strings.im_assigned_to%>&nbsp;</td> 
        <td><asp:Literal id="responses1assigned_to" Text='<%# Server.HtmlEncode(((responses1Item)Container.DataItem).assigned_to.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
      </tr>
 
      <tr class="AltRow">
        <td nowrap><%=Resources.strings.im_priority%></td> 
        <td><asp:Literal id="responses1priority_id" Text='<%# Server.HtmlEncode(((responses1Item)Container.DataItem).priority_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
      </tr>
 
      <tr class="AltRow">
        <td nowrap><%=Resources.strings.im_status%></td> 
        <td><asp:Literal id="responses1status_id" Text='<%# Server.HtmlEncode(((responses1Item)Container.DataItem).status_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>") %>' runat="server"/>&nbsp;</td>
      </tr>
 
  </ItemTemplate>
  <SeparatorTemplate>
	
      <tr class="Separator">
        <td colspan="2"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
      </tr>
      
  </SeparatorTemplate>
  <FooterTemplate>
	
      
      <tr class="Footer">
        <td colspan="2">
          
<CC:Navigator id="NavigatorNavigator" MaxPage="<%# responses1Data.PagesCount%>" PageNumber="<%# responses1Data.PageNumber%>" runat="server">
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

