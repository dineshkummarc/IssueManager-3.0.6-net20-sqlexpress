<!--ASPX page @1-1337AA28-->
<%@ Page language="c#" CodeFile="UserMaint.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.UserMaint.UserMaintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.UserMaint" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=UserMaintContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_user%></title>


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
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      
  <span id="usersHolder" runat="server">
    
      <table cellspacing="0" cellpadding="0" border="0">
        <tr>
          <td valign="top">
            

              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_user%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="3">
                
  <asp:PlaceHolder id="usersError" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="usersErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.CCS_Login%>&nbsp;*</th>
 
                  <td><asp:TextBox id="userslogin" maxlength="15" Columns="15"

	runat="server"/>&nbsp;</td>
                </tr>
 
                                <tr class="Controls">
                                  <th><%=Resources.strings.CCS_Password%>&nbsp;*</th>
 
                                  <td>
                                    <asp:TextBox id="usersnew_pass" TextMode="Password" maxlength="15" Columns="15"

	runat="server"/>&nbsp;<%=Resources.strings.im_new_password%><br>
                                    <asp:TextBox id="usersrep_pass" TextMode="Password" maxlength="15" Columns="15"

	runat="server"/>&nbsp;<%=Resources.strings.im_repeat_password%></td> 
                                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_security_level%>&nbsp;</th>
 
                  <td>
                    <select id="userssecurity_level"  runat="server"></select>
 &nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_name%>&nbsp;*</th>
 
                  <td><asp:TextBox id="usersuser_name" maxlength="50" Columns="50"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_email%>&nbsp;*</th>
 
                  <td><asp:TextBox id="usersemail" maxlength="50" Columns="50"

	runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_allow_upload%>&nbsp;</th>
 
                  <td><asp:CheckBox id="usersallow_upload" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_notify_new%>&nbsp;</th>
 
                  <td><asp:CheckBox id="usersnotify_new" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_notify_original%>&nbsp;</th>
 
                  <td><asp:CheckBox id="usersnotify_original" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Controls">
                  <th><%=Resources.strings.im_notify_reassignment%>&nbsp;</th>
 
                  <td><asp:CheckBox id="usersnotify_reassignment" runat="server"/>&nbsp;</td>
                </tr>
 
                <tr class="Footer">
                  <td align="right" colspan="2">
                    <input id='usersInsert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='users_Insert' runat="server"/>
                    <input id='usersUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='users_Update' runat="server"/>
                    <input id='usersDelete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='users_Delete' runat="server"/>
                    <input id='usersCancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='users_Cancel' runat="server"/>&nbsp;</td>
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

