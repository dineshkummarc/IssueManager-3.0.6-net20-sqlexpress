<!--ASPX page @1-229C6288-->
<%@ Control language="c#" CodeFile="AdminMenu.ascx.cs" AutoEventWireup="false" Inherits="IssueManager.AdminMenu.AdminMenuPage" %>

<%@ Import namespace="IssueManager.AdminMenu" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>
<table class="Grid" cellspacing="0" cellpadding="2" style="margin-top:-15px">
          <tr class="Controls">
                                <td nowrap width="200"><B><%=Resources.strings.im_administration%>:</B></td>
                                <td nowrap>
                                





<a id="Link1" href="" class="menulink" runat="server"  ><%#Resources.strings.im_system_configuration%></a>
                                &nbsp;&middot;&nbsp;
                                <a id="Link2" href="" class="menulink" runat="server"  ><%#Resources.strings.im_users%></a>
                                &nbsp;&middot;&nbsp;
                                <a id="Link3" href="" class="menulink" runat="server"  ><%#Resources.strings.im_priorities%></a>
                                &nbsp;&middot;&nbsp;
                                <a id="Link4" href="" class="menulink" runat="server"  ><%#Resources.strings.im_statuses%></a>
                                &nbsp;&middot;&nbsp;
                                <a id="Link5" href="" class="menulink" runat="server"  ><%#Resources.strings.im_issues%></a>
                                &nbsp;&middot;&nbsp;
                                <a id="Link8" href="" class="menulink" runat="server"  ><%#Resources.strings.im_languages%></a>
                                &nbsp;&middot;&nbsp;
                                <a id="Link9" href="" class="menulink" runat="server"  ><%#Resources.strings.im_styles%></a>
                                </td>
                </tr>
</table>
<br>



<!--End ASPX page-->

