<!--ASPX page @1-0BA14E1C-->
<%@ Page language="c#" CodeFile="IssueNew.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.IssueNew.IssueNewPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.IssueNew" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=IssueNewContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_add_new_issue%></title>


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
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      
  <span id="issuesHolder" runat="server">
    
      <table cellspacing="0" cellpadding="0" border="0" width="780">
        <tr>
          <td valign="top">
            

              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_add_new_issue%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/%20Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="3">
                
  <asp:PlaceHolder id="issuesError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="issuesErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.im_issue_name%>&nbsp;*</th>
 
                  <td width="100%"><asp:TextBox id="issuesissue_name" maxlength="100" Columns="70" style="width:100%"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_issue_description%>&nbsp;*</th>
 
                  <td><asp:TextBox id="issuesissue_desc" rows="10" Columns="70" style="width:100%" TextMode="MultiLine"

	runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_priority%></th>
 
                  <td>
                    <select id="issuespriority_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_status%>&nbsp;</th>
 
                  <td>
                    <select id="issuesstatus_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_version%>&nbsp;</th>
 
                  <td><asp:TextBox id="issuesversion" maxlength="10" Columns="10"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_assigned_to%>&nbsp;</th>
 
                  <td>
                    <select id="issuesassigned_to"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_user_submitted%>&nbsp;</th>
 
                  <td><asp:Literal id="issuesuser_name" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_date_submitted%></th>
 
                  <td><asp:Literal id="issuesdate_submitted" runat="server"/>&nbsp;</td>
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
                  <td align="right" colspan="2">
                    <input id='issuesInsert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='issues_Insert' runat="server"/>
                    <input id='issuesCancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='issues_Cancel' runat="server"/>&nbsp;</td>
                </tr>
              </table>
              
  <input id="issuesdate_now" type="hidden"  runat="server"/>
  
            

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

