<!--ASPX page @1-47C29177-->
<%@ Page language="c#" CodeFile="Administration.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.Administration.AdministrationPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.Administration" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=AdministrationContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_administration%></title>


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
<table cellspacing="0" cellpadding="0" border="0" align="center">
<tr>
<td valign="top">
              <table cellspacing="0" cellpadding="0" border="0" class="Header">
                <tr>
                  <td class="HeaderLeft"><img border="0" src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
                  <th><%=Resources.strings.im_administration%></th>
                  <td class="HeaderRight"><img border="0" src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
                </tr>
              </table>

<table class="Grid" cellspacing="0" cellpadding="3">
  <tr class="Controls">
<td  ><a id="Link1" href="" class="menulink" runat="server"  ><%#Resources.strings.im_system_configuration%></a></td>
  </tr>
  <tr class="Controls">
<td  ><a id="Link2" href="" class="menulink" runat="server"  ><%#Resources.strings.im_users%></a></td>
  </tr>
  <tr class="Controls">
<td  ><a id="Link3" href="" class="menulink" runat="server"  ><%#Resources.strings.im_priorities%></a></td>
  </tr>
  <tr class="Controls">
<td  ><a id="Link4" href="" class="menulink" runat="server"  ><%#Resources.strings.im_statuses%></a></td>
  </tr>
  <tr class="Controls">
<td  ><a id="Link5" href="" class="menulink" runat="server"  ><%#Resources.strings.im_issues%></a></td>
  </tr>
<tr class="Controls">
  <td><a id="Link6" href="" class="menulink" runat="server"  ><%#Resources.strings.im_languages%></a></td> 
</tr>
<tr class="Controls">
  <td><a id="Link7" href="" class="menulink" runat="server"  ><%#Resources.strings.im_styles%></a></td> 
</tr>
</table>

</td>
</tr>
</table>

<IssueManager:Footer id="Footer" runat="server"/>

</form>
</body>
</html>

<!--End ASPX page-->

