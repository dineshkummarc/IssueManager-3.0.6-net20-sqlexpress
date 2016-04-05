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

namespace IssueManager.Header{ //Namespace @1-025D523B

//Forms Definition @1-9F1BE22B
public partial class HeaderPage : System.Web.UI.UserControl
{
//End Forms Definition

//Forms Objects @1-EC755586
    protected System.Resources.ResourceManager rm;
    protected string HeaderContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-CCAD733C
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.Link1Href = "Default.aspx";
            item.Link2Href = "IssueNew.aspx";
            item.Link3Href = "UserProfile.aspx";
            item.Link5Href = "Administration.aspx";
            item.Link4Href = "Login.aspx";
            item.Link4HrefParameters.Add("Logout",System.Web.HttpUtility.UrlEncode(("True").ToString()));
            PageData.FillItem(item);
            user.Text=Server.HtmlEncode(item.user.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
            Link1.InnerText=Resources.strings.im_issue_list;
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState);
            Link2.InnerText=Resources.strings.im_add_new_issue;
            Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("None","", ViewState);
            Link3.InnerText=Resources.strings.im_my_profile;
            Link3.HRef = item.Link3Href+item.Link3HrefParameters.ToString("None","", ViewState);
            Link5.InnerText=Resources.strings.im_administration;
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("None","", ViewState);
            Link4.InnerText=Resources.strings.im_logout;
            Link4.HRef = item.Link4Href+item.Link4HrefParameters.ToString("None","", ViewState);
            item.styleItems.SetSelection(item.style.GetFormattedValue());
            style.Items.Add(new ListItem(Resources.strings.im_change_style,""));
            if(item.styleItems.GetSelectedItem() != null)
                style.SelectedIndex = -1;
            item.styleItems.CopyTo(style.Items);
            style.DataBind();
            item.localeItems.SetSelection(item.locale.GetFormattedValue());
            locale.Items.Add(new ListItem(Resources.strings.im_change_locale,""));
            if(item.localeItems.GetSelectedItem() != null)
                locale.SelectedIndex = -1;
            item.localeItems.CopyTo(locale.Items);
            locale.DataBind();
    }
//End Page_Load Event BeforeIsPostBack

//Label user Event BeforeShow. Action Custom Code @9-2A29BDB7
 // -------------------------
 string user_name = "";
 if (DBUtility.UserId != null)
 	user_name = IMUtils.Lookup("user_name", "users", "user_id="+DBUtility.UserId);
 user.Text = String.Format(rm.GetString("im_welcome"), user_name);
 // -------------------------
//End Label user Event BeforeShow. Action Custom Code

//Panel AdminLink Event BeforeShow. Action Hide-Show Component @18-141EE606
        TextField SesGroupID_18_1 = new TextField("", System.Web.HttpContext.Current.Session["GroupID"]);
        TextField ExprParam2_18_2 = new TextField("", ("3"));
        if (SesGroupID_18_1 != ExprParam2_18_2) {
            AdminLink.Visible = false;
        }
//End Panel AdminLink Event BeforeShow. Action Hide-Show Component

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

//OnInit Event @1-B397DA77
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        HeaderContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
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

