<!--ASPX page @1-D84DA823-->
<%@ Page language="c#" CodeFile="AppSettings.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.AppSettings.AppSettingsPage" validateRequest="False"ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.AppSettings" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=AppSettingsContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_settings%></title>


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

  <span id="settingsHolder" runat="server">
    
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      

        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.im_edit_settings%></th>
 
            <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="3">
          
  <asp:PlaceHolder id="settingsError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="settingsErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.im_upload_enabled%>&nbsp;</th>
 
            <td><asp:CheckBox id="settingsupload_enabled" runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_file_ext%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsfile_extensions" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_file_path%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsfile_path" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_new_from%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsnotify_new_from" maxlength="50" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_new_subject%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsnotify_new_subject" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_new_body%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsnotify_new_body" style="WIDTH: 321px; HEIGHT: 92px" rows="4" Columns="50" TextMode="MultiLine"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_change_from%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsnotify_change_from" maxlength="50" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_change_subject%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsnotify_change_subject" Columns="50"

	runat="server"/>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_notify_change_body%>&nbsp;</th>
 
            <td><asp:TextBox id="settingsnotify_change_body" style="WIDTH: 321px; HEIGHT: 92px" rows="5" Columns="50" TextMode="MultiLine"

	runat="server"/>&nbsp;</td>
          </tr>
 
                        <tr class="Controls">
                          <th><%=Resources.strings.im_email_component%>&nbsp;</th>
                          <td>
                            <select id="settingsemail_component"  runat="server"></select>
                          </td> 
                        </tr>
                        <tr class="Controls">
                          <th><%=Resources.strings.im_smtp_host%>&nbsp;</th>
 
                          <td><asp:TextBox id="settingssmtp_host" Columns="30"

	runat="server"/>&nbsp;</td> 
                        </tr>
 
          <tr class="Footer">
            <td align="right" colspan="2">
              <input id='settingsUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='settings_Update' runat="server"/>&nbsp;</td>
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

