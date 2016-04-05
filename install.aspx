<!--ASPX page @1-BA941A92-->
<%@ Page language="c#" CodeFile="install.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.install.installPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.install" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=installContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_installation%></title>


<meta content="CodeCharge Studio 3.0.4.5" name="GENERATOR">

<link href="Styles/<%=PageStyleName%>/Style.css" type="text/css" rel="stylesheet">
<script language="JavaScript" type="text/javascript">
//Begin CCS script
//End CCS script
</script>

</head>
<body>
<form runat="server">


<center>
<asp:PlaceHolder id="Panel1" Visible="True" runat="server">
	<br>
<table cellspacing="0" cellpadding="0" width="780" border="0">
                <tr>
                                <td valign="top">
                                                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                                                                <tr>
                                                                                <td class="HeaderLeft"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                                                                                <th><%=Resources.strings.inst_welcome_install%></th>
 
                                                                                <td class="HeaderRight"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                                                                </tr>
                                                </table>
 
                                                <table class="Grid" cellspacing="0" cellpadding="0">
                                                                <tr class="Caption">
                                                                                <th><%=Resources.strings.inst_application%></th>
                                                                </tr>
 
                                                                <tr class="Row">
                                                                                <td><%=Resources.strings.inst_introduce%><br>
                                                                                                <br>
                                                                                                <table width="100%" border="0">
                                                                                                                <tr>
                                                                                                                                <th style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><%=Resources.strings.inst_system_requirements%></b></th>
 
                                                                                                                                <th style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><%=Resources.strings.inst_status%></b></th>
                                                                                                                </tr>
 
                                                                                                                <tr>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.inst_asp_version%></td> 
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><font color=green><%=Resources.strings.inst_status_ok%></font></b></td>
                                                                                                                </tr>
 
                                                                                                                <tr>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.inst_fso_check%></td>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="FsoCheck" runat="server"/></b></td>
                                                                                                                </tr>

                                                                                                                <tr>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.inst_upload_check%></td>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="UploadCheck" runat="server"/></b></td>
                                                                                                                </tr>
 
                                                                                                                <tr>
                                                                                                                  <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.inst_mailer_check%></td>
                                                                                                                  <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="MailerCheck" runat="server"/></b></td>
                                                                                                                </tr>

                                                                                                                <tr>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.inst_writable_common_asp%></td> 
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="WriteCheck" runat="server"/></b></td>
                                                                                                                </tr>
 
                                                                                                                <tr>
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><%=Resources.strings.inst_writable_folder%></td> 
                                                                                                                                <td style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px"><b><asp:Literal id="FolderCheck" runat="server"/></b></td>
                                                                                                                </tr>
                                                                                                </table>
                                                                                                <br>
                                                                                                <br>
                                                                                                
<asp:PlaceHolder id="FsoResolution" Visible="False" runat="server">
	
<br>
<div style="border:1px solid red;padding:5px;background-color:white;color:red">
<%=Resources.strings.inst_resolution_fso%>
</div>

	</asp:PlaceHolder>

<asp:PlaceHolder id="UploadResolution" Visible="False" runat="server">
	
<br>
<div style="border:1px solid red;padding:5px;background-color:white;color:red">
                <%=Resources.strings.inst_resolution_upload%>
</div>

	</asp:PlaceHolder>


<asp:PlaceHolder id="MailerResolution" Visible="False" runat="server">
	<br>
<div style="border:1px solid red;padding:5px;background-color:white;color:red">
  <%=Resources.strings.inst_resolution_mailer%>
</div>

	</asp:PlaceHolder>

<asp:PlaceHolder id="MailerRemark" Visible="False" runat="server">
	<br>
<div style="border:1px solid red;padding:5px;background-color:white;color:red">
  <%=Resources.strings.inst_remarks_mailer%>
</div>

	</asp:PlaceHolder>

<asp:PlaceHolder id="WriteResolution" Visible="False" runat="server">
	
<br>
<div style="border:1px solid red;padding:5px;background-color:white;color:red">
                <%=Resources.strings.inst_resolution_write_asp%>
</div>

	</asp:PlaceHolder>
                                                                                                <br>
                                                                                                <br>
                                                                                </td>
                                                                </tr>
 
                                                                <tr class="Row">
                                                                                <td align="right"><a id="InstallLink" href="" runat="server"  ></a></td>
                                                                </tr>
                                                </table>
                                </td>
                </tr>
</table>

	</asp:PlaceHolder>
<asp:PlaceHolder id="Panel2" Visible="True" runat="server">
	

  <span id="sql_environmentHolder" runat="server">
    
<script language="javascript">
function switchUpgrade(form, upg)
{
        if (upg)
        {
                form.SampleData.checked = false;
                alert('<%=Resources.strings.inst_upgrade_warning%>');
        }
        setVisible("confirm",!upg);
        form.SampleData.disabled = upg;
}

function setVisible(id,visible)
{
        document.getElementById(id).style.display = visible?"":"none";
}
function initUpgrade()
{
        switchUpgrade(document.forms["sql_environment"], document.forms["sql_environment"].UpgradeData.checked);
}
window.onload=initUpgrade;
</script>
<br>


                <table cellspacing="0" cellpadding="0" width="780" border="0">
                                <tr>
                                                <td valign="top">
                                                                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                                                                                                <th><%=Resources.strings.inst_step2%></th>
 
                                                                                                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                                                                                </tr>
                                                                </table>
 
                                                                <table class="Record" cellspacing="0" cellpadding="0">
                                                                                <tr class="Controls">
                                                                                                <td colspan="2"><%=Resources.strings.inst_introduce2%><br>
                                                                                                                <br>
                                                                                                                <br>
                                                                                                </td>
                                                                                </tr>
 
                                                                                
  <asp:PlaceHolder id="sql_environmentError" visible="False" runat="server">
  
                                                                                <tr class="Error">
                                                                                                <td colspan="2"><asp:Label ID="sql_environmentErrorLabel" runat="server"/></td>
                                                                                </tr>
                                                                                
  </asp:PlaceHolder>
  

                                                                                <tr class="Controls">
                                                                                                <th width="50%"><%=Resources.strings.inst_site_url%> *</th>
                                                                                                <td><asp:TextBox id="sql_environmentSiteURL" Columns="40" maxlength="250" style="width:100%"

	runat="server"/></td> 
                                                                                </tr>

                                                                                <tr class="Footer">
                                                                                                <td colspan="2"><b><%=Resources.strings.inst_sql_environment_mssql%></b></td>
                                                                                </tr>

                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_sql_host%> *</th>
 
                                                                                  <td><asp:TextBox id="sql_environmentdb_host" maxlength="200" Columns="20"

	runat="server"/></td> 
                                                                                </tr>
                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_sql_database_name%> *</th>
 
                                                                                  <td><asp:TextBox id="sql_environmentdb_name" maxlength="200" Columns="20"

	runat="server"/></td> 
                                                                                </tr>
                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_sql_username%></th>
 
                                                                                  <td><asp:TextBox id="sql_environmentdb_username" maxlength="200" Columns="20"

	runat="server"/></td> 
                                                                                </tr>
                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_sql_password%></th>
 
                                                                                  <td><asp:TextBox id="sql_environmentdb_password" maxlength="200" Columns="20"

	runat="server"/></td> 
                                                                                </tr>
                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_sql_additional%></th>
 
                                                                                  <td><asp:TextBox id="sql_environmentdb_additional" maxlength="200" Columns="40" style="width:100%"

	runat="server"/></td> 
                                                                                </tr>

                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_upgrade_data%></th>
 
                                                                                  <td><asp:CheckBox id="sql_environmentUpgradeData" Enabled="False" onclick="switchUpgrade(this.form,this.checked)" runat="server"/>&nbsp;</td>
                                                                                </tr>

                                                                                <tr class="Controls">
                                                                                  <th><%=Resources.strings.inst_sample_data%></th>
 
                                                                                  <td><asp:CheckBox id="sql_environmentSampleData" runat="server"/>&nbsp;</td>
                                                                                </tr>


                                                                                <tr class="Footer">
                                                                                                <td colspan="2"><b><%=Resources.strings.inst_your_admin_account%></b></td>
                                                                                </tr>
 
                                                                                <tr class="Controls">
                                                                                                <th><%=Resources.strings.CCS_Login%> *</th>
 
                                                                                                <td><asp:TextBox id="sql_environmentuser_login"

	runat="server"/></td>
                                                                                </tr>
 
                                                                                <tr class="Controls">
                                                                                                <th><%=Resources.strings.CCS_Password%> *</th>
 
                                                                                                <td><asp:TextBox id="sql_environmentuser_password" TextMode="Password"

	runat="server"/></td>
                                                                                </tr>
 

                                                                                <tr class="Controls" id="confirm">
                                                                                  <th><%=Resources.strings.inst_user_confirm_password%></th>
 
                                                                                  <td><asp:TextBox id="sql_environmentuser_password_rep" TextMode="Password"

	runat="server"/></td>
                                                                                </tr>
 
                                                                                <tr class="Bottom">
                                                                                                <td align="right" colspan="2">
                                                                                                                <input id='sql_environmentUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" border="0" OnServerClick='sql_environment_Update_OnClick' runat="server"/></td>
                                                                                </tr>
                                                                </table>
                                                </td>
                                </tr>
                </table>



  </span>
  
	</asp:PlaceHolder>
<asp:PlaceHolder id="Panel3" Visible="True" runat="server">
	<br>
<table cellspacing="0" cellpadding="0" width="780" border="0">
                <tr>
                                <td valign="top">
                                                <table class="Header" cellspacing="0" cellpadding="0" border="0">
                                                                <tr>
                                                                                <td class="HeaderLeft"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                                                                                <th><%=Resources.strings.inst_finish%></th>
 
                                                                                <td class="HeaderRight"><img src='<%="Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                                                                </tr>
                                                </table>
 
                                                <table class="Record" cellspacing="0" cellpadding="0">
                                                                <tr class="Controls">
                                                                                <td colspan="2"><%=Resources.strings.inst_finish2%></td>
                                                                </tr>
 
                                                                <tr class="Row">
                                                                                <td align="center" colspan="2">
                                                                                                <br>
                                                                                                <br>
                                                                                                <br>
                                                                                                <br>
                                                                                                <b><%=Resources.strings.inst_finish_desc%></b><br>
                                                                                                <br>
                                                                                                <br>
                                                                                                <br>
                                                                                                <br>
                                                                                </td>
                                                                </tr>
 
                                                                <tr class="Row">
                                                                                <td align="right"><a id="Link2" href="" runat="server"  ><%#Resources.strings.inst_start%></a></td>
                                                                </tr>
                                                </table>
                                </td>
                </tr>
</table>

	</asp:PlaceHolder>
</center>

</form>
</body>
</html>

<!--End ASPX page-->

