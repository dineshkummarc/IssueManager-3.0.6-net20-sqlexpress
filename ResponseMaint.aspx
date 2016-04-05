<!--ASPX page @1-FA57B638-->
<%@ Page language="c#" CodeFile="ResponseMaint.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.ResponseMaint.ResponseMaintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.ResponseMaint" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=ResponseMaintContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_response_maint%></title>


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
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      
  <span id="responsesHolder" runat="server">
    
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            

              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_response_maint%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="responsesError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="responsesErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.im_user_submitted%>&nbsp;*</th>
 
                  <td>
                    <select id="responsesuser_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_date_response%>&nbsp;*</th>
 
                  <td><asp:TextBox id="responsesdate_response" Columns="30"

	runat="server"/>&nbsp;<asp:Literal id="responsesdate_format" runat="server"/></td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_response%>&nbsp;*</th>
 
                  <td><asp:TextBox id="responsesresponse" rows="3" Columns="50" TextMode="MultiLine"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_assigned_to%>&nbsp;*</th>
 
                  <td>
                    <select id="responsesassigned_to"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_priority%>&nbsp;*</th>
 
                  <td>
                    <select id="responsespriority_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_status%>&nbsp;*</th>
 
                  <td>
                    <select id="responsesstatus_id"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Footer">
                  <td align="right" colspan="2">
                    <input id='responsesInsert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='responses_Insert' runat="server"/>
                    <input id='responsesUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='responses_Update' runat="server"/>
                    <input id='responsesDelete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='responses_Delete' runat="server"/>
                    <input id='responsesCancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='responses_Cancel' runat="server"/>&nbsp;</td>
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

