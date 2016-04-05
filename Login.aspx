<!--ASPX page @1-EB516344-->
<%@ Page language="c#" CodeFile="Login.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.Login.LoginPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.Login" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=LoginContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_login%></title>


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
<div align="center">
  
  <span id="LoginHolder" runat="server">
    
<table cellspacing="0" cellpadding="0" border="0">
<tr>
<td valign="top">

  

              <table cellspacing="0" cellpadding="0" border="0" class="Header">
                <tr>
                  <td class="HeaderLeft"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
                  <th><%=Resources.strings.im_login%></th>
                  <td class="HeaderRight"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
                </tr>
              </table>

    <table cellpadding="3" cellspacing="0" class="Record">
      
  <asp:PlaceHolder id="LoginError" visible="False" runat="server">
  
      <tr class="Error">
                          <td colspan="2"><asp:Label ID="LoginErrorLabel" runat="server"/></td>
                        </tr>
      
  </asp:PlaceHolder>
  
      <tr class="Controls">
                  <th><%=Resources.strings.CCS_Login%>&nbsp;</th>
                  <td><asp:TextBox id="Loginlogin" maxlength="100" Columns="20"

	runat="server"/>&nbsp;</td>
                </tr>
      <tr class="Controls">
                  <th><%=Resources.strings.CCS_Password%>&nbsp;</th>
                  <td><asp:TextBox id="Loginpassword" TextMode="Password" maxlength="100" Columns="20"

	runat="server"/>&nbsp;</td>
                </tr>
      <tr class="Footer">
<td colspan="2" align="right">
<input id='LoginDoLogin' class="Button" type="submit" value="<%#Resources.strings.CCS_LoginBtn%>" OnServerClick='Login_DoLogin_OnClick' runat="server"/>&nbsp;</td>
      </tr>
    </table>
  

  
</td>
</tr>
</table>

  </span>
  
</div>
<IssueManager:Footer id="Footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

