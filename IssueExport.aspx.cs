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

namespace IssueManager.IssueExport{ //Namespace @1-C8B56552

//Forms Definition @1-C232CCEA
public partial class IssueExportPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-6CD11A66
    protected issuesDataProvider issuesData;
    protected int issuesCurrentRowNumber;
    protected FormSupportedOperations issuesOperations;
    protected System.Resources.ResourceManager rm;
    protected string IssueExportContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-A38F37FA
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            issuesBind();
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

//Grid issues Bind @2-FE0C8C4C
    protected void issuesBind()
    {
        if (!issuesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"issues",typeof(issuesDataProvider.SortFields), 0, -1);
        }
//End Grid issues Bind

//Grid Form issues BeforeShow tail @2-F569F814
        issuesParameters();
        issuesData.SortField = (issuesDataProvider.SortFields)ViewState["issuesSortField"];
        issuesData.SortDir = (SortDirections)ViewState["issuesSortDir"];
        issuesData.PageNumber = (int)ViewState["issuesPageNumber"];
        issuesData.RecordsPerPage = (int)ViewState["issuesPageSize"];
        issuesRepeater.DataSource = issuesData.GetResultSet(out PagesCount, issuesOperations);
        ViewState["issuesPagesCount"] = PagesCount;
        issuesRepeater.DataBind();
        FooterIndex = issuesRepeater.Controls.Count - 1;
        issuesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        issuesItem item=new issuesItem();
        System.Web.UI.WebControls.Literal issuestitle = (System.Web.UI.WebControls.Literal)issuesRepeater.Controls[0].FindControl("issuestitle");


        issuestitle.Text=item.title.GetFormattedValue();
//End Grid Form issues BeforeShow tail

//Grid issues Event BeforeShow. Action Custom Code @120-2A29BDB7
 // -------------------------
string param_status = Request.QueryString["s_status_id"]==null?"":Request.QueryString["s_status_id"];
string param_notstatus = Request.QueryString["s_notstatus_id"]==null?"":Request.QueryString["s_notstatus_id"];
if(param_notstatus == "0") param_notstatus = "";
string issue_look="",issue_view="";
if (param_notstatus.Length>0){
  issue_look = IMUtils.Translate(IMUtils.Lookup("status","statuses","status_id=" + param_notstatus));
  issue_view = rm.GetString("im_not_issues_title").Replace("{0}", issue_look);
}
if (param_status.Length>0){
  issue_look = IMUtils.Translate(IMUtils.Lookup("status","statuses","status_id=" + param_status));
  issue_view = rm.GetString("im_issues_title").Replace("{0}", issue_look);
}
if (param_status=="" && param_notstatus=="")
  issue_view = rm.GetString("im_all_issues");

issuestitle.Text=issue_view;
 // -------------------------
//End Grid issues Event BeforeShow. Action Custom Code

//Grid issues Bind tail @2-FCB6E20C
    }
//End Grid issues Bind tail

//Grid issues Table Parameters @2-63009877
    protected void issuesParameters()
    {
        try{
            issuesData.Urls_status_id = IntegerParameter.GetParam(Request.QueryString["s_status_id"]);
            issuesData.Urls_notstatus_id = IntegerParameter.GetParam(Request.QueryString["s_notstatus_id"]);
            issuesData.Urls_priority_id = IntegerParameter.GetParam(Request.QueryString["s_priority_id"]);
            issuesData.Urls_assigned_to = IntegerParameter.GetParam(Request.QueryString["s_assigned_to"]);
            issuesData.Urls_issue_desc = MemoParameter.GetParam(Request.QueryString["s_issue_desc"]);
            issuesData.Urls_assigned_by = IntegerParameter.GetParam(Request.QueryString["s_assigned_by"]);
        }catch{
            ControlCollection ParentControls=issuesRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(issuesRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid issues: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid issues Table Parameters

//Grid issues ItemDataBound event @2-45401EFD
    protected void issuesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        issuesItem DataItem=(issuesItem)e.Item.DataItem;
        issuesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        issuesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal issuesissue_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesissue_id"));
            System.Web.UI.WebControls.Literal issuesissue_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesissue_name"));
            System.Web.UI.WebControls.Literal issuesissue_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesissue_desc"));
            System.Web.UI.WebControls.Literal issuesstatus_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesstatus_id"));
            System.Web.UI.WebControls.Literal issuescolor = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuescolor"));
            System.Web.UI.WebControls.Literal issuespriority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority_id"));
            System.Web.UI.WebControls.Literal issuesuser_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesuser_id"));
            System.Web.UI.WebControls.Literal issuesdate_submitted = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_submitted"));
            System.Web.UI.WebControls.Literal issuesassigned_to_orig = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to_orig"));
            System.Web.UI.WebControls.Literal issuesassigned_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_id"));
            System.Web.UI.WebControls.Literal issuesassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to"));
            System.Web.UI.WebControls.Literal issuesmodified_by = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesmodified_by"));
            System.Web.UI.WebControls.Literal issuesdate_modified = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_modified"));
            System.Web.UI.WebControls.Literal issuestested = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuestested"));
            System.Web.UI.WebControls.Literal issuesapproved = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesapproved"));
            System.Web.UI.WebControls.Literal issuesversion = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesversion"));
        }
//End Grid issues ItemDataBound event

//issues control Before Show @2-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End issues control Before Show

//Get Control @7-1B3D0A9D
            System.Web.UI.WebControls.Literal issuespriority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority_id"));
//End Get Control

//Label priority_id Event BeforeShow. Action Custom Code @123-2A29BDB7
 // -------------------------
 issuespriority_id.Text = "<font color='"+((issuesItem)DataItem).color.GetFormattedValue()+"'>"+IMUtils.Translate(issuespriority_id.Text)+"</font>";
 // -------------------------
//End Label priority_id Event BeforeShow. Action Custom Code

//Get Control @11-F0B19854
            System.Web.UI.WebControls.Literal issuesassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to"));
//End Get Control

//Label assigned_to Event BeforeShow. Action Custom Code @124-2A29BDB7
 // -------------------------
	if (item.assigned_id.GetFormattedValue()==Session["UserID"].ToString())
		issuesassigned_to.Text = "<font color='red'>"+issuesassigned_to.Text+"</font>";
 // -------------------------
//End Label assigned_to Event BeforeShow. Action Custom Code

//issues control Before Show tail @2-FCB6E20C
        }
//End issues control Before Show tail

//Grid issues BeforeShowRow event @2-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid issues BeforeShowRow event

//Grid issues Event BeforeShowRow. Action Custom Code @185-2A29BDB7
    // -------------------------
    IMUtils.TranslateFields(e.Item, "issues");
    // -------------------------
//End Grid issues Event BeforeShowRow. Action Custom Code

//Grid issues BeforeShowRow event tail @2-FCB6E20C
        }
//End Grid issues BeforeShowRow event tail

//Grid issues ItemDataBound event tail @2-FCB6E20C
    }
//End Grid issues ItemDataBound event tail

//Grid issues ItemCommand event @2-88103A00
    protected void issuesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = issuesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["issuesSortDir"]==SortDirections.Asc&&ViewState["issuesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["issuesSortDir"]=SortDirections.Desc;
                else
                    ViewState["issuesSortDir"]=SortDirections.Asc;
            else
                ViewState["issuesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["issuesSortField"]=Enum.Parse(typeof(issuesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["issuesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["issuesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            issuesBind();
    }
//End Grid issues ItemCommand event

//OnInit Event @1-162FF1D1
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        IssueExportContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        issuesData = new issuesDataProvider();
        issuesOperations = new FormSupportedOperations(false, true, false, false, false);
//End OnInit Event

//Page IssueExport Event AfterInitialize. Action Custom Code @184-2A29BDB7
 // -------------------------
	//Change HTML header to specify Excel's MIME content type
	Response.AddHeader("Content-Type","application/x-ms-download");
	Response.AddHeader("Content-Disposition","attachment; filename=Issues.xls");
 // -------------------------
//End Page IssueExport Event AfterInitialize. Action Custom Code

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

