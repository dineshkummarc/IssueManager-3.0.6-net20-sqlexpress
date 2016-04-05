//Using Statements @1-C52E7E58
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using IssueManager;
using IssueManager.Data;
using IssueManager.Configuration;
using IssueManager.Security;
using IssueManager.Controls;

//End Using Statements

namespace IssueManager.Administration{ //Namespace @1-CEDB2F4B

//Forms Definition @1-FA7A7B4E
public partial class AdministrationPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-2FECCFEB
    protected System.Resources.ResourceManager rm;
    protected string AdministrationContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-69A79FC0
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.Link1Href = "AppSettings.aspx";
            item.Link2Href = "UserList.aspx";
            item.Link3Href = "PriorityList.aspx";
            item.Link4Href = "StatusList.aspx";
            item.Link5Href = "IssueList.aspx";
            item.Link6Href = "LangMaint.aspx";
            item.Link7Href = "StyleMaint.aspx";
            PageData.FillItem(item);
            Link1.InnerText=Resources.strings.im_system_configuration;
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState);
            Link2.InnerText=Resources.strings.im_users;
            Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("None","", ViewState);
            Link3.InnerText=Resources.strings.im_priorities;
            Link3.HRef = item.Link3Href+item.Link3HrefParameters.ToString("None","", ViewState);
            Link4.InnerText=Resources.strings.im_statuses;
            Link4.HRef = item.Link4Href+item.Link4HrefParameters.ToString("None","", ViewState);
            Link5.InnerText=Resources.strings.im_issues;
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("None","", ViewState);
            Link6.InnerText=Resources.strings.im_languages;
            Link6.HRef = item.Link6Href+item.Link6HrefParameters.ToString("None","", ViewState);
            Link7.InnerText=Resources.strings.im_styles;
            Link7.HRef = item.Link7Href+item.Link7HrefParameters.ToString("None","", ViewState);
    }
//End Page_Load Event BeforeIsPostBack

//Page_Load Event tail @1-FCB6E20C
}
//End Page_Load Event tail

//Page_Unload Event @1-72102C7C
private void Page_Unload(object sender, System.EventArgs e)
{
//End Page_Unload Event

//Page_Unload Event tail @1-FCB6E20C
}
//End Page_Unload Event tail

//OnInit Event @1-1E444A59
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        AdministrationContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        if(!DBUtility.AuthorizeUser(new string[]{
          "3"}))
            Response.Redirect(Settings.AccessDeniedUrl+"?ret_link="+Server.UrlEncode(Request["SCRIPT_NAME"]+"?"+Request["QUERY_STRING"]));
//End OnInit Event

//OnInit Event tail @1-CF19F5CD
        PageStyleName = Server.UrlEncode(PageStyleName);
    }
//End OnInit Event tail

//InitializeComponent Event @1-722FC1EE
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
    }
    #endregion
//End InitializeComponent Event

//Page class tail @1-F5FC18C5
}
}
//End Page class tail

