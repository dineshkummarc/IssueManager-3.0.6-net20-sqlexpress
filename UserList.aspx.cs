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

namespace IssueManager.UserList{ //Namespace @1-F7CB4F48

//Forms Definition @1-FA0003FD
public partial class UserListPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-82C05199
    protected usersDataProvider usersData;
    protected int usersCurrentRowNumber;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string UserListContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-8D86C04A
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            usersBind();
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

//Grid users Bind @3-D6ABCB2B
    protected void usersBind()
    {
        if (!usersOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"users",typeof(usersDataProvider.SortFields), 10, 100);
        }
//End Grid users Bind

//Grid Form users BeforeShow tail @3-072C6656
        usersData.SortField = (usersDataProvider.SortFields)ViewState["usersSortField"];
        usersData.SortDir = (SortDirections)ViewState["usersSortDir"];
        usersData.PageNumber = (int)ViewState["usersPageNumber"];
        usersData.RecordsPerPage = (int)ViewState["usersPageSize"];
        usersRepeater.DataSource = usersData.GetResultSet(out PagesCount, usersOperations);
        ViewState["usersPagesCount"] = PagesCount;
        usersRepeater.DataBind();
        FooterIndex = usersRepeater.Controls.Count - 1;
        usersRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        usersItem item=new usersItem();
        System.Web.UI.HtmlControls.HtmlAnchor usersLink1 = (System.Web.UI.HtmlControls.HtmlAnchor)usersRepeater.Controls[FooterIndex].FindControl("usersLink1");

        item.Link1Href = "UserMaint.aspx";

        usersLink1.InnerText=Resources.strings.im_add_new_user;
        usersLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState);
        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)usersRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form users BeforeShow tail

//Grid users Event BeforeShow. Action Custom Code @18-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Grid users Event BeforeShow. Action Custom Code

//Grid users Bind tail @3-FCB6E20C
    }
//End Grid users Bind tail

//Grid users ItemDataBound event @3-2E86797D
    protected void usersItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        usersItem DataItem=(usersItem)e.Item.DataItem;
        usersItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        usersCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor usersuser_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("usersuser_name"));
            System.Web.UI.WebControls.Literal usersemail = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersemail"));
            System.Web.UI.WebControls.Literal userssecurity_level = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("userssecurity_level"));
            System.Web.UI.WebControls.Literal usersallow_upload = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersallow_upload"));
            DataItem.user_nameHref = "UserMaint.aspx";
            usersuser_name.HRef = DataItem.user_nameHref + DataItem.user_nameHrefParameters.ToString("GET","", ViewState);
        }
//End Grid users ItemDataBound event

//Grid users BeforeShowRow event @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid users BeforeShowRow event

//Grid users Event BeforeShowRow. Action Custom Code @17-2A29BDB7
    // -------------------------
    System.Web.UI.WebControls.Literal userssecurity_level = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("userssecurity_level"));
	userssecurity_level.Text = IMUtils.Translate("res:im_level_"+userssecurity_level.Text);
	System.Web.UI.WebControls.Literal usersallow_upload = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("usersallow_upload"));
	usersallow_upload.Text = IMUtils.Translate(usersallow_upload.Text);
    // -------------------------
//End Grid users Event BeforeShowRow. Action Custom Code

//Grid users BeforeShowRow event tail @3-FCB6E20C
        }
//End Grid users BeforeShowRow event tail

//Grid users ItemDataBound event tail @3-FCB6E20C
    }
//End Grid users ItemDataBound event tail

//Grid users ItemCommand event @3-764B37BB
    protected void usersItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = usersRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["usersSortDir"]==SortDirections.Asc&&ViewState["usersSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["usersSortDir"]=SortDirections.Desc;
                else
                    ViewState["usersSortDir"]=SortDirections.Asc;
            else
                ViewState["usersSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["usersSortField"]=Enum.Parse(typeof(usersDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["usersPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["usersPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            usersBind();
    }
//End Grid users ItemCommand event

//OnInit Event @1-9B24B1C3
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        UserListContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, false, false, false);
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

