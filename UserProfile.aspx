<!--ASPX page @1-A8947084-->
<%@ Page language="c#" CodeFile="UserProfile.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.UserProfile.UserProfilePage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.UserProfile" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=UserProfileContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_my_profile%></title>


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

  <span id="usersHolder" runat="server">
    
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      

        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.im_edit_user%></th>
 
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
            <th><%=Resources.strings.im_name%>&nbsp;*</th>
 
            <td><asp:Literal id="usersuser_name" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.CCS_Login%>&nbsp;*</th>
 
            <td><asp:Literal id="userslogin" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_change_password%>&nbsp;*</th>
 
            <td>
                                <asp:TextBox id="usersold_pass" TextMode="Password" maxlength="15" Columns="15"

	runat="server"/>&nbsp;<%=Resources.strings.im_old_password%><br>
                <asp:TextBox id="usersnew_pass" TextMode="Password" maxlength="15" Columns="15"

	runat="server"/>&nbsp;<%=Resources.strings.im_new_password%><br>
                                <asp:TextBox id="usersrep_pass" TextMode="Password" maxlength="15" Columns="15"

	runat="server"/>&nbsp;<%=Resources.strings.im_repeat_password%>
                        </td>
                  </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_email%>&nbsp;*</th>
 
            <td><asp:TextBox id="usersemail" maxlength="50" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_new%>&nbsp;</th>
 
            <td><asp:CheckBox id="usersnotify_new" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_original%></th>
 
            <td><asp:CheckBox id="usersnotify_original" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_reassignment%>&nbsp;</th>
 
            <td><asp:CheckBox id="usersnotify_reassignment" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_allow_upload%>&nbsp;</th>
 
            <td><asp:Literal id="usersallow_upload" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_security_level%></th>
 
            <td><asp:Literal id="userssecurity_level" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Footer">
            <td align="right" colspan="2">
              <input id='usersUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='users_Update' runat="server"/>&nbsp;</td>
          </tr>
        </table>
      

    </td>
  </tr>
</table>

  </span>
  <IssueManager:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

