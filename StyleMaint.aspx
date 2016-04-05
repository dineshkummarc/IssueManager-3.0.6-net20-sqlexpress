<!--ASPX page @1-D6133DF0-->
<%@ Page language="c#" CodeFile="StyleMaint.aspx.cs" AutoEventWireup="false" Inherits="IssueManager.StyleMaint.StyleMaintPage" ResponseEncoding ="utf-8"%>

<%@ Import namespace="IssueManager.StyleMaint" %>
<%@ Import namespace="IssueManager.Configuration" %>
<%@ Import namespace="IssueManager.Data" %>

<%@Register TagPrefix="IssueManager" TagName="Header" Src="Header.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="Footer" Src="Footer.ascx"%>
<%@Register TagPrefix="IssueManager" TagName="AdminMenu" Src="AdminMenu.ascx"%>
<%@Register TagPrefix="CC" Namespace="IssueManager.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<meta http-equiv="content-type" content="<%=StyleMaintContentMeta%>">
<title><%=Resources.strings.im_application_title%> - <%=Resources.strings.im_styles%></title>


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
<IssueManager:AdminMenu id="AdminMenu" runat="server"/> 
<table>
  <tr>
    <td valign="top">
      
<asp:repeater id="stylesRepeater" OnItemCommand="stylesItemCommand" OnItemDataBound="stylesItemDataBound" runat="server">
  <HeaderTemplate>
	
      <table cellspacing="0" cellpadding="0" width="200" border="0">
        <tr>
          <td valign="top">
            <table class="Header" cellspacing="0" cellpadding="0" border="0">
              <tr>
                <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                <th><%=Resources.strings.im_styles%></th>
 
                <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
              </tr>
            </table>
 
            <table class="Grid" cellspacing="0" cellpadding="0">
              <tr class="Caption">
                <th><%=Resources.strings.im_style_name%></th>
              </tr>
 
              
  </HeaderTemplate>
  <ItemTemplate>
              <tr class="Row">
                <td><a id="stylesstyle_name" href="" runat="server"  ><%#((stylesItem)Container.DataItem).style_name.GetFormattedValue()%></a>&nbsp;</td>
              </tr>
 
  </ItemTemplate>
  <FooterTemplate>
	
              
  <asp:PlaceHolder id="NoRecords" visible="False" runat="server">
    
              <tr class="NoRecords">
                <td><%=Resources.strings.CCS_NoRecords%></td>
              </tr>
              
  </asp:PlaceHolder>

              <tr class="Footer">
                <td>[<a id="stylesstyles_Insert" href="" runat="server"  ><%#Resources.strings.CCS_InsertLink%></a>] </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
      
  </FooterTemplate>
</asp:repeater>
</td> 
    <td valign="top">
      
  <span id="styles1Holder" runat="server">
    
      

        <table cellspacing="0" cellpadding="0" border="0">
          <tr>
            <td valign="top">
              <table class="Header" cellspacing="0" cellpadding="0" border="0">
                <tr>
                  <td class="HeaderLeft"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td> 
                  <th><%=Resources.strings.im_style%></th>
 
                  <td class="HeaderRight"><img src='<%#"Styles/" + PageStyleName + "/Images/Spacer.gif"%>' border="0"></td>
                </tr>
              </table>
 
              <table class="Record" cellspacing="0" cellpadding="0">
                
  <asp:PlaceHolder id="styles1Error" visible="False" runat="server">
  
                <tr class="Error">
                  <td colspan="2"><asp:Label ID="styles1ErrorLabel" runat="server"/></td>
                </tr>
                
  </asp:PlaceHolder>
  
                <tr class="Controls">
                  <th><%=Resources.strings.im_style_name%></th>
 
                  <td><asp:TextBox id="styles1style_name" maxlength="50" Columns="50"

	runat="server"/></td>
                </tr>
 
                <tr class="Bottom">
                  <td align="right" colspan="2">
                    <input id='styles1Button_Insert' class="Button" type="submit" value="<%#Resources.strings.CCS_Insert%>" OnServerClick='styles1_Insert' runat="server"/>
                    <input id='styles1Button_Update' class="Button" type="submit" value="<%#Resources.strings.CCS_Update%>" OnServerClick='styles1_Update' runat="server"/>
                    <input id='styles1Button_Delete' class="Button" type="submit" value="<%#Resources.strings.CCS_Delete%>" OnServerClick='styles1_Delete' runat="server"/></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      

      
  </span>
  </td>
  </tr>
</table>
<%=Resources.strings.im_style_instructions%> <IssueManager:Footer id="Footer" runat="server"/> 

</form>
</body>
</html>

<!--End ASPX page-->

