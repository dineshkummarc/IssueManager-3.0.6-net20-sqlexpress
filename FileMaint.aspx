<!--ASPX page @1-936143E9-->
<%@ Page language="c#" CodeFile="FileMaint.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.FileMaint.FileMaintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.FileMaint" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=FileMaintContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_file_maint%></title>


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

  <span id="filesHolder" runat="server">
    
<table cellspacing="0" cellpadding="0" border="0">
  <tr>
    <td valign="top">
      

        <table class="Header" cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
            <th><%=Resources.strings.im_file_maint%></th>
 
            <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
          </tr>
        </table>
 
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="filesError" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="filesErrorLabel" runat="server"/></td>
          </tr>
          
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.im_file%>&nbsp;</th>
 
            <td><a id="filesfile" href="" target="_blank" runat="server"  ></a>&nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_file_name%>&nbsp;*</th>
 
            <td>
              
  <CC:FileUploadControl id="filesfile_name" DeleteCaption='' OnBeforeProcessFile="filesfile_nameBeforeProcessFile" runat="server"/>
  </td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_uploaded_by%>&nbsp;*</th>
 
            <td>
              <select id="filesuploaded_by"  runat="server"></select>
 &nbsp;</td>
          </tr>
 
          <tr class="Controls">
            <th><%=Resources.strings.im_date_uploaded%>&nbsp;*</th>
 
            <td><asp:TextBox id="filesdate_uploaded" Columns="30"

	runat="server"/>&nbsp;<asp:Literal id="filesdate_format" runat="server"/></td>
          </tr>
 
          <tr class="Footer">
            <td align="right" colspan="2">
              <input id='filesUpdate' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='files_Update' runat="server"/>
              <input id='filesDelete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='files_Delete' runat="server"/>
              <input id='filesCancel' class="Button" type="submit" value="<%#Resources.strings.CCS_Cancel%>" OnServerClick='files_Cancel' runat="server"/>&nbsp;</td>
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

