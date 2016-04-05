<!--ASPX page @1-EF1441A5-->
<%@ Control language="c#" CodeFile="Header.ascx.cs" AutoEventWireup="false" Inherits="IssueManager.Header.HeaderPage" %>

<%@ Import namespace="IssueManager.Header" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>
<script language="javascript">
function addParam(url, param, value)
{
        re = new RegExp('\&?'+param+'=[^\&\?$]*');
        url = url.replace(re, '');
        url = url.replace('?&', '?');
        sep = url.indexOf('?')>=0?'&':'?';
        return url+sep+param+'='+value;
}
</script>

<table class="Header" cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td class="HeaderLeft">





<img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
    <th><%=Resources.strings.im_application_title%></th>
    <td class="HeaderRight"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
  </tr>
</table>
<table class="Grid" cellspacing="0">
  <tr class="Controls">
    <td width="200"><nobr><b><asp:Literal id="user" runat="server"/></b></nobr></td>
    <td nowrap>
        <a id="Link1" href="" class="menulink" runat="server"  ><%#Resources.strings.im_issue_list%></a>
        &nbsp;&middot;&nbsp;
    <a id="Link2" href="" class="menulink" runat="server"  ><%#Resources.strings.im_add_new_issue%></a>
        &nbsp;&middot;&nbsp;
    <a id="Link3" href="" class="menulink" runat="server"  ><%#Resources.strings.im_my_profile%></a>
        &nbsp;&middot;&nbsp;

        <asp:PlaceHolder id="AdminLink" Visible="True" runat="server">
	
        <a id="Link5" href="" class="menulink" runat="server"  ><%#Resources.strings.im_administration%></a>&nbsp;&middot;&nbsp;
        
	</asp:PlaceHolder>
        <a id="Link4" href="" class="menulink" runat="server"  ><%#Resources.strings.im_logout%></a>
        </td>
                <td width="10" align="right" style="padding:0px">
                        <select id="style" style="font-size:11px" onchange="if(this.selectedIndex>0)document.location.href=addParam(document.location.href, 'style', this.options[this.selectedIndex].value)"  runat="server"></select>
                </td>
                <td width="10" align="right" style="padding:0px">
                  <select id="locale" style="font-size:11px" class="Control" onchange="if(this.selectedIndex>0)document.location.href=addParam(document.location.href, 'locale', this.options[this.selectedIndex].value)"  runat="server"></select>
                </td>
  </tr>
</table>
<br>



<!--End ASPX page-->

