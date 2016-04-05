<!--ASPX page @1-7A1EABFA-->
<%@ Page language="c#" CodeFile="LangMaint.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.LangMaint.LangMaintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.LangMaint" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<html>
<head>
<meta http-equiv="content-type" content="<%=LangMaintContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_languages%></title>


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
<IssueManager:AdminMenu id="AdminMenu" runat="server"/>
<table>
<tr>
<td valign="top">

<asp:repeater id="localesRepeater" OnItemCommand="localesItemCommand" OnItemDataBound="localesItemDataBound" runat="server">
  <HeaderTemplate>
	
<table cellspacing="0" cellpadding="0" border="0" width="200">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="0" border="0" class="Header">
        <tr>
          <td class="HeaderLeft"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
          <th><%=Resources.strings.im_languages%></th>
          <td class="HeaderRight"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
        </tr>
      </table>
      <table class="Grid" cellspacing="0" cellpadding="0">
        <tr class="Caption">
          <th><%=Resources.strings.im_locale_name%></th>
 
        </tr>
 
        
  </HeaderTemplate>
  <ItemTemplate>
        <tr class="Row">
          <td><a id="localeslocale_name" href="" runat="server"  ><%#((localesItem)Container.DataItem).locale_name.GetFormattedValue()%></a>&nbsp;</td> 
        </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
        
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
        <tr class="NoRecords">
          <td colspan="1"><%=Resources.strings.CCS_NoRecords%></td> 
        </tr>
 
  </asp:PlaceHolder>

        <tr class="Footer">
          <td colspan="1">[<a id="localeslocales_Insert" href="" runat="server"  ><%#Resources.strings.CCS_InsertLink%></a>] </td> 
        </tr>
      </table>
 </td> 
  </tr>
</table>

  </FooterTemplate>
</asp:repeater>

</td>
<td valign="top">

  <span id="locales1Holder" runat="server">
    


  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
      <td valign="top">
        <table cellspacing="0" cellpadding="0" border="0" class="Header">
          <tr>
            <td class="HeaderLeft"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
            <th><%=Resources.strings.im_language%></th>
            <td class="HeaderRight"><img border="0" src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>'></td>
          </tr>
        </table>
        <table class="Record" cellspacing="0" cellpadding="0">
          
  <asp:PlaceHolder id="locales1Error" visible="False" runat="server">
  
          <tr class="Error">
            <td colspan="2"><asp:Label ID="locales1ErrorLabel" runat="server"/></td> 
          </tr>
 
  </asp:PlaceHolder>
  
          <tr class="Controls">
            <th><%=Resources.strings.im_locale_name%></th>
 
            <td><asp:TextBox id="locales1locale_name" maxlength="50" Columns="50"

	runat="server"/></td> 
          </tr>
 
          <tr class="Bottom">
            <td colspan="2" align="right">
              <input id='locales1Button_Insert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='locales1_Insert' runat="server"/>
              <input id='locales1Button_Update' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='locales1_Update' runat="server"/>
              <input id='locales1Button_Delete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='locales1_Delete' runat="server"/></td> 
          </tr>
        </table>
 </td> 
    </tr>
  </table>



  </span>
  
</td>
</tr>
</table>
<%=Resources.strings.im_lang_instructions%>
<IssueManager:Footer id="Footer" runat="server"/>


</form>
</body>
</html>

<!--End ASPX page-->

