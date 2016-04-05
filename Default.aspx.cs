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

namespace IssueManager.Default{ //Namespace @1-E7AF9CE2

//Forms Definition @1-B6B562C7
public partial class DefaultPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-C579BC54
    protected issuesSearchDataProvider issuesSearchData;
    protected NameValueCollection issuesSearchErrors=new NameValueCollection();
    protected bool issuesSearchIsSubmitted = false;
    protected FormSupportedOperations issuesSearchOperations;
    protected summaryDataProvider summaryData;
    protected int summaryCurrentRowNumber;
    protected FormSupportedOperations summaryOperations;
    protected issuesDataProvider issuesData;
    protected int issuesCurrentRowNumber;
    protected FormSupportedOperations issuesOperations;
    protected System.Resources.ResourceManager rm;
    protected string DefaultContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-D48C1D9D
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.Link1Href = "Default.aspx";
            item.Link1HrefParameters.Add("s_notstatus_id",System.Web.HttpUtility.UrlEncode((0).ToString()));
            item.Link2Href = "Default.aspx";
            item.Link2HrefParameters.Add("s_notstatus_id",System.Web.HttpUtility.UrlEncode((3).ToString()));
            item.Link4Href = "Default.aspx";
            item.Link4HrefParameters.Add("s_assigned_by",System.Web.HttpUtility.UrlEncode(Session["UserID"]==null?"":Session["UserID"].ToString()));
            item.Link5Href = "Default.aspx";
            item.Link5HrefParameters.Add("s_assigned_to",System.Web.HttpUtility.UrlEncode(Session["UserID"]==null?"":Session["UserID"].ToString()));
            PageData.FillItem(item);
            Link1.InnerText=Resources.strings.im_all_issues;
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState);
            Link2.InnerText=Resources.strings.im_pending_by_update;
            Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("None","", ViewState);
            Link4.InnerText=Resources.strings.im_assigned_by_me;
            Link4.HRef = item.Link4Href+item.Link4HrefParameters.ToString("None","", ViewState);
            Link5.InnerText=Resources.strings.im_assigned_to_me;
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("None","", ViewState);
            issuesSearchShow();
            summaryBind();
            issuesBind();
    }
//End Page_Load Event BeforeIsPostBack

//Link Link2 Event BeforeShow. Action Custom Code @191-2A29BDB7
    // Write your own code here.
    // -------------------------
//End Link Link2 Event BeforeShow. Action Custom Code

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

//Record Form issuesSearch Parameters @3-8FE552B7
    protected void issuesSearchParameters()
    {
        issuesSearchItem item=issuesSearchItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            issuesSearchErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form issuesSearch Parameters

//Record Form issuesSearch Show method @3-1B3B3F71
    protected void issuesSearchShow()
    {
        if(issuesSearchOperations.None)
        {
            issuesSearchHolder.Visible=false;
            return;
        }
        issuesSearchItem item=issuesSearchItem.CreateFromHttpRequest();
        bool IsInsertMode=!issuesSearchOperations.AllowRead;
        issuesSearchErrors.Add(item.errors);
//End Record Form issuesSearch Show method

//Record Form issuesSearch BeforeShow tail @3-805C8565
        issuesSearchParameters();
        issuesSearchData.FillItem(item,ref IsInsertMode);
        issuesSearchHolder.DataBind();
        issuesSearchs_issue_desc.Text=item.s_issue_desc.GetFormattedValue();
        item.s_priority_idItems.SetSelection(item.s_priority_id.GetFormattedValue());
        issuesSearchs_priority_id.Items.Add(new ListItem(Resources.strings.im_all,""));
        issuesSearchs_priority_id.Items[0].Selected = true;
        if(item.s_priority_idItems.GetSelectedItem() != null)
            issuesSearchs_priority_id.SelectedIndex = -1;
        item.s_priority_idItems.CopyTo(issuesSearchs_priority_id.Items);
        item.s_status_idItems.SetSelection(item.s_status_id.GetFormattedValue());
        issuesSearchs_status_id.Items.Add(new ListItem(Resources.strings.im_all,""));
        issuesSearchs_status_id.Items[0].Selected = true;
        if(item.s_status_idItems.GetSelectedItem() != null)
            issuesSearchs_status_id.SelectedIndex = -1;
        item.s_status_idItems.CopyTo(issuesSearchs_status_id.Items);
        item.s_notstatus_idItems.SetSelection(item.s_notstatus_id.GetFormattedValue());
        issuesSearchs_notstatus_id.Items.Add(new ListItem(Resources.strings.im_show_all,"0"));
        issuesSearchs_notstatus_id.Items[0].Selected = true;
        if(item.s_notstatus_idItems.GetSelectedItem() != null)
            issuesSearchs_notstatus_id.SelectedIndex = -1;
        item.s_notstatus_idItems.CopyTo(issuesSearchs_notstatus_id.Items);
        item.s_assigned_toItems.SetSelection(item.s_assigned_to.GetFormattedValue());
        issuesSearchs_assigned_to.Items.Add(new ListItem(Resources.strings.im_anybody,""));
        issuesSearchs_assigned_to.Items[0].Selected = true;
        if(item.s_assigned_toItems.GetSelectedItem() != null)
            issuesSearchs_assigned_to.SelectedIndex = -1;
        item.s_assigned_toItems.CopyTo(issuesSearchs_assigned_to.Items);
//End Record Form issuesSearch BeforeShow tail

//Record issuesSearch Event BeforeShow. Action Custom Code @186-2A29BDB7
    // -------------------------
    IMUtils.TranslateListbox(issuesSearchs_priority_id);
    IMUtils.TranslateListbox(issuesSearchs_status_id);
    IMUtils.TranslateListbox(issuesSearchs_notstatus_id);
    // -------------------------
//End Record issuesSearch Event BeforeShow. Action Custom Code

//Record Form issuesSearch Show method tail @3-561B6F62
        if(issuesSearchErrors.Count>0)
            issuesSearchShowErrors();
    }
//End Record Form issuesSearch Show method tail

//Record Form issuesSearch LoadItemFromRequest method @3-8BC38FB1
    protected void issuesSearchLoadItemFromRequest(issuesSearchItem item, bool EnableValidation)
    {
        item.s_issue_desc.SetValue(issuesSearchs_issue_desc.Text);
        try{
        item.s_priority_id.SetValue(issuesSearchs_priority_id.Value);
        item.s_priority_idItems.CopyFrom(issuesSearchs_priority_id.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_priority_id",String.Format(Resources.strings.CCS_IncorrectValue,"s_priority_id"));}
        try{
        item.s_status_id.SetValue(issuesSearchs_status_id.Value);
        item.s_status_idItems.CopyFrom(issuesSearchs_status_id.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_status_id",String.Format(Resources.strings.CCS_IncorrectValue,"s_status_id"));}
        try{
        item.s_notstatus_id.SetValue(issuesSearchs_notstatus_id.Value);
        item.s_notstatus_idItems.CopyFrom(issuesSearchs_notstatus_id.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_notstatus_id",String.Format(Resources.strings.CCS_IncorrectValue,"s_notstatus_id"));}
        try{
        item.s_assigned_to.SetValue(issuesSearchs_assigned_to.Value);
        item.s_assigned_toItems.CopyFrom(issuesSearchs_assigned_to.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_assigned_to",String.Format(Resources.strings.CCS_IncorrectValue,"s_assigned_to"));}
        if(EnableValidation)
            item.Validate(issuesSearchData);
        issuesSearchErrors.Add(item.errors);
    }
//End Record Form issuesSearch LoadItemFromRequest method

//Record Form issuesSearch GetRedirectUrl method @3-56712BE5
    protected string GetissuesSearchRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "Default.aspx";
        string p = parameters.ToString("POST",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form issuesSearch GetRedirectUrl method

//Record Form issuesSearch ShowErrors method @3-D7BA7D38
    protected void issuesSearchShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<issuesSearchErrors.Count;i++)
        switch(issuesSearchErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=issuesSearchErrors[i];
                break;
        }
        issuesSearchError.Visible = true;
        issuesSearchErrorLabel.Text = DefaultMessage;
    }
//End Record Form issuesSearch ShowErrors method

//Record Form issuesSearch Insert Operation @3-FBD22D2A
    protected void issuesSearch_Insert(object sender, System.EventArgs e)
    {
        issuesSearchIsSubmitted = true;
        bool ErrorFlag = false;
        issuesSearchItem item=new issuesSearchItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issuesSearch Insert Operation

//Record Form issuesSearch BeforeInsert tail @3-A29C10B8
    issuesSearchParameters();
    issuesSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form issuesSearch BeforeInsert tail

//Record Form issuesSearch AfterInsert tail  @3-83EA6FF6
        ErrorFlag=(issuesSearchErrors.Count>0);
        if(ErrorFlag)
            issuesSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issuesSearch AfterInsert tail 

//Record Form issuesSearch Update Operation @3-BC9E0584
    protected void issuesSearch_Update(object sender, System.EventArgs e)
    {
        issuesSearchItem item=new issuesSearchItem();
        item.IsNew = false;
        issuesSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issuesSearch Update Operation

//Record Form issuesSearch Before Update tail @3-A29C10B8
        issuesSearchParameters();
        issuesSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form issuesSearch Before Update tail

//Record Form issuesSearch Update Operation tail @3-83EA6FF6
        ErrorFlag=(issuesSearchErrors.Count>0);
        if(ErrorFlag)
            issuesSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issuesSearch Update Operation tail

//Record Form issuesSearch Delete Operation @3-DA5627C1
    protected void issuesSearch_Delete(object sender,System.EventArgs e)
    {
        issuesSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        issuesSearchItem item=new issuesSearchItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form issuesSearch Delete Operation

//Record Form BeforeDelete tail @3-A29C10B8
        issuesSearchParameters();
        issuesSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @3-DB7DB537
        if(ErrorFlag)
            issuesSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form issuesSearch Cancel Operation @3-61B6E5D9
    protected void issuesSearch_Cancel(object sender,System.EventArgs e)
    {
        issuesSearchItem item=new issuesSearchItem();
        issuesSearchIsSubmitted = true;
        string RedirectUrl = "";
        issuesSearchLoadItemFromRequest(item, true);
//End Record Form issuesSearch Cancel Operation

//Record Form issuesSearch Cancel Operation tail @3-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form issuesSearch Cancel Operation tail

//Record Form issuesSearch Search Operation @3-D168F6B0
    protected void issuesSearch_Search(object sender, System.EventArgs e)
    {
        issuesSearchIsSubmitted = true;
        bool ErrorFlag=false;
        issuesSearchItem item=new issuesSearchItem();
        issuesSearchLoadItemFromRequest(item, true);
        ErrorFlag=(issuesSearchErrors.Count>0);
        string RedirectUrl = "";
//End Record Form issuesSearch Search Operation

//Button DoSearch OnClick. @4-A8616826
        if(((Control)sender).ID == "issuesSearchDoSearch")
        {
            RedirectUrl = GetissuesSearchRedirectUrl("", "s_issue_desc;s_priority_id;s_status_id;s_notstatus_id;s_assigned_to");
//End Button DoSearch OnClick.

//Button DoSearch OnClick tail. @4-FCB6E20C
        }
//End Button DoSearch OnClick tail.

//Record Form issuesSearch Search Operation tail @3-F7F75977
        if(ErrorFlag)
            issuesSearchShowErrors();
        else{
            string Params="";
            Params+=issuesSearchs_issue_desc.Text!=""?("s_issue_desc="+Server.UrlEncode(issuesSearchs_issue_desc.Text)+"&"):"";
            foreach(ListItem li in issuesSearchs_priority_id.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_priority_id="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in issuesSearchs_status_id.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_status_id="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in issuesSearchs_notstatus_id.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_notstatus_id="+Server.UrlEncode(li.Value)+"&";
            foreach(ListItem li in issuesSearchs_assigned_to.Items)
                if(li.Selected && !"".Equals(li.Value))
                    Params += "s_assigned_to="+Server.UrlEncode(li.Value)+"&";
            if(!RedirectUrl.EndsWith("?"))
                RedirectUrl += "&" + Params;
            else
                RedirectUrl += Params;
            RedirectUrl = RedirectUrl.TrimEnd(new Char[]{'&'});
            Response.Redirect(RedirectUrl);
        }
    }
//End Record Form issuesSearch Search Operation tail

//Grid summary Bind @40-02CD068F
    protected void summaryBind()
    {
        if (!summaryOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"summary",typeof(summaryDataProvider.SortFields), 20, -1);
        }
//End Grid summary Bind

//Grid Form summary BeforeShow tail @40-3B19260C
        summaryParameters();
        summaryData.SortField = (summaryDataProvider.SortFields)ViewState["summarySortField"];
        summaryData.SortDir = (SortDirections)ViewState["summarySortDir"];
        summaryData.PageNumber = (int)ViewState["summaryPageNumber"];
        summaryData.RecordsPerPage = (int)ViewState["summaryPageSize"];
        summaryRepeater.DataSource = summaryData.GetResultSet(out PagesCount, summaryOperations);
        ViewState["summaryPagesCount"] = PagesCount;
        summaryRepeater.DataBind();
        FooterIndex = summaryRepeater.Controls.Count - 1;
        summaryRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;


//End Grid Form summary BeforeShow tail

//Grid summary Bind tail @40-FCB6E20C
    }
//End Grid summary Bind tail

//Grid summary Table Parameters @40-AE0E9E07
    protected void summaryParameters()
    {
        try{
            summaryData.Urls_issue_desc = MemoParameter.GetParam(Request.QueryString["s_issue_desc"]);
            summaryData.Urls_assigned_by = IntegerParameter.GetParam(Request.QueryString["s_assigned_by"]);
            summaryData.Urls_priority_id = IntegerParameter.GetParam(Request.QueryString["s_priority_id"]);
            summaryData.Urls_status_id = IntegerParameter.GetParam(Request.QueryString["s_status_id"]);
            summaryData.Urls_assigned_to = IntegerParameter.GetParam(Request.QueryString["s_assigned_to"]);
            summaryData.Urls_notstatus_id = IntegerParameter.GetParam(Request.QueryString["s_notstatus_id"]);
        }catch{
            ControlCollection ParentControls=summaryRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(summaryRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid summary: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid summary Table Parameters

//Grid summary ItemDataBound event @40-AD2AD1B5
    protected void summaryItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        summaryItem DataItem=(summaryItem)e.Item.DataItem;
        summaryItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        summaryCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor summaryLabel1 = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("summaryLabel1"));
            System.Web.UI.WebControls.Literal summaryLabel2 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("summaryLabel2"));
            DataItem.Label1Href = "Default.aspx";
            summaryLabel1.HRef = DataItem.Label1Href + DataItem.Label1HrefParameters.ToString("GET","", ViewState);
        }
//End Grid summary ItemDataBound event

//summary control Before Show @40-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End summary control Before Show

//Get Control @41-0439EAF9
            System.Web.UI.HtmlControls.HtmlAnchor summaryLabel1 = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("summaryLabel1"));
//End Get Control

//Link Label1 Event BeforeShow. Action Custom Code @189-2A29BDB7
    // -------------------------
    summaryLabel1.InnerText = IMUtils.Translate(summaryLabel1.InnerText);
    // -------------------------
//End Link Label1 Event BeforeShow. Action Custom Code

//summary control Before Show tail @40-FCB6E20C
        }
//End summary control Before Show tail

//Grid summary BeforeShowRow event @40-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid summary BeforeShowRow event

//Grid summary Event BeforeShowRow. Action Custom Code @187-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Grid summary Event BeforeShowRow. Action Custom Code

//Grid summary BeforeShowRow event tail @40-FCB6E20C
        }
//End Grid summary BeforeShowRow event tail

//Grid summary ItemDataBound event tail @40-FCB6E20C
    }
//End Grid summary ItemDataBound event tail

//Grid summary ItemCommand event @40-36742954
    protected void summaryItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = summaryRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["summarySortDir"]==SortDirections.Asc&&ViewState["summarySortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["summarySortDir"]=SortDirections.Desc;
                else
                    ViewState["summarySortDir"]=SortDirections.Asc;
            else
                ViewState["summarySortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["summarySortField"]=Enum.Parse(typeof(summaryDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["summaryPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["summaryPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            summaryBind();
    }
//End Grid summary ItemCommand event

//Grid issues Bind @2-A0410E45
    protected void issuesBind()
    {
        if (!issuesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"issues",typeof(issuesDataProvider.SortFields), 10, 100);
        }
//End Grid issues Bind

//Grid Form issues BeforeShow tail @2-6D7D9ADB
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
        System.Web.UI.HtmlControls.HtmlAnchor issuesLink7 = (System.Web.UI.HtmlControls.HtmlAnchor)issuesRepeater.Controls[FooterIndex].FindControl("issuesLink7");
        System.Web.UI.HtmlControls.HtmlAnchor issuesLink6 = (System.Web.UI.HtmlControls.HtmlAnchor)issuesRepeater.Controls[FooterIndex].FindControl("issuesLink6");

        item.Link7Href = "IssueExport.aspx";
        item.Link6Href = "IssueNew.aspx";

        issuestitle.Text=item.title.GetFormattedValue();
        issuesLink7.InnerText=Resources.strings.im_export_to_excel;
        issuesLink7.HRef = item.Link7Href+item.Link7HrefParameters.ToString("GET","", ViewState);
        issuesLink6.InnerText=Resources.strings.im_add_new_issue;
        issuesLink6.HRef = item.Link6Href+item.Link6HrefParameters.ToString("GET","", ViewState);
        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)issuesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form issues BeforeShow tail

//Grid issues Event BeforeShow. Action Custom Code @145-2A29BDB7
// -------------------------
//Show Status of Shown Issues
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

//Grid issues Table Parameters @2-2EF1484C
    protected void issuesParameters()
    {
        try{
            issuesData.Urls_issue_desc = MemoParameter.GetParam(Request.QueryString["s_issue_desc"]);
            issuesData.Urls_priority_id = IntegerParameter.GetParam(Request.QueryString["s_priority_id"]);
            issuesData.Urls_status_id = IntegerParameter.GetParam(Request.QueryString["s_status_id"]);
            issuesData.Urls_notstatus_id = IntegerParameter.GetParam(Request.QueryString["s_notstatus_id"]);
            issuesData.Urls_assigned_to = IntegerParameter.GetParam(Request.QueryString["s_assigned_to"]);
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

//Grid issues ItemDataBound event @2-0B782BDC
    protected void issuesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        issuesItem DataItem=(issuesItem)e.Item.DataItem;
        issuesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        issuesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item) {
            System.Web.UI.WebControls.Literal issuesissue_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesissue_id"));
            System.Web.UI.HtmlControls.HtmlAnchor issuesissue_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("issuesissue_name"));
            System.Web.UI.WebControls.Literal issuesstatus_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesstatus_id"));
            System.Web.UI.WebControls.Literal issuescolor = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuescolor"));
            System.Web.UI.WebControls.Literal issuespriority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority_id"));
            System.Web.UI.WebControls.Literal issuesassigned_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_id"));
            System.Web.UI.WebControls.Literal issuesassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to"));
            System.Web.UI.WebControls.Literal issuesdate_submitted = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_submitted"));
            System.Web.UI.WebControls.Literal issuesdate_modified = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_modified"));
            System.Web.UI.WebControls.Literal issuestested = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuestested"));
            System.Web.UI.WebControls.Literal issuesapproved = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesapproved"));
            System.Web.UI.WebControls.Literal issuesversion = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesversion"));
            DataItem.issue_nameHref = "IssueChange.aspx";
            issuesissue_name.HRef = DataItem.issue_nameHref + DataItem.issue_nameHrefParameters.ToString("GET","", ViewState);
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal issuesissue_id1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesissue_id1"));
            System.Web.UI.HtmlControls.HtmlAnchor issuesissue_name1 = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("issuesissue_name1"));
            System.Web.UI.WebControls.Literal issuesstatus_id1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesstatus_id1"));
            System.Web.UI.WebControls.Literal issuescolor1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuescolor1"));
            System.Web.UI.WebControls.Literal issuespriority_id1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority_id1"));
            System.Web.UI.WebControls.Literal issuesassigned_id1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_id1"));
            System.Web.UI.WebControls.Literal issuesassigned_to1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to1"));
            System.Web.UI.WebControls.Literal issuesdate_submitted1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_submitted1"));
            System.Web.UI.WebControls.Literal issuesdate_modified1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_modified1"));
            System.Web.UI.WebControls.Literal issuestested1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuestested1"));
            System.Web.UI.WebControls.Literal issuesapproved1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesapproved1"));
            System.Web.UI.WebControls.Literal issuesversion1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesversion1"));
            DataItem.issue_name1Href = "IssueChange.aspx";
            issuesissue_name1.HRef = DataItem.issue_name1Href + DataItem.issue_name1HrefParameters.ToString("GET","", ViewState);
        }
//End Grid issues ItemDataBound event

//issues control Before Show @2-9590CF61
        if (e.Item.ItemType == ListItemType.Item) {
//End issues control Before Show

//Get Control @26-1B3D0A9D
            System.Web.UI.WebControls.Literal issuespriority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority_id"));
//End Get Control

//Label priority_id Event BeforeShow. Action Custom Code @146-2A29BDB7
 // -------------------------
 issuespriority_id.Text = "<font color='"+((issuesItem)DataItem).color.GetFormattedValue()+"'>"+IMUtils.Translate(issuespriority_id.Text)+"</font>";
 // -------------------------
//End Label priority_id Event BeforeShow. Action Custom Code

//Get Control @27-F0B19854
            System.Web.UI.WebControls.Literal issuesassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to"));
//End Get Control

//Label assigned_to Event BeforeShow. Action Custom Code @181-2A29BDB7
 // -------------------------
	if (item.assigned_id.GetFormattedValue()==Session["UserID"].ToString())
		issuesassigned_to.Text = "<font color='red'>"+issuesassigned_to.Text+"</font>";
 // -------------------------
//End Label assigned_to Event BeforeShow. Action Custom Code

//issues control Before Show tail @2-FCB6E20C
        }
//End issues control Before Show tail

//issues control Before Show @2-E7AB1DC2
        if (e.Item.ItemType == ListItemType.AlternatingItem) {
//End issues control Before Show

//Get Control @137-7FEA7515
            System.Web.UI.WebControls.Literal issuespriority_id1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority_id1"));
//End Get Control

//Label priority_id1 Event BeforeShow. Action Custom Code @147-2A29BDB7
 // -------------------------
 issuespriority_id1.Text = "<font color='"+((issuesItem)DataItem).color1.GetFormattedValue()+"'>"+IMUtils.Translate(issuespriority_id1.Text)+"</font>";
 // -------------------------
//End Label priority_id1 Event BeforeShow. Action Custom Code

//Get Control @138-BABB773C
            System.Web.UI.WebControls.Literal issuesassigned_to1 = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to1"));
//End Get Control

//Label assigned_to1 Event BeforeShow. Action Custom Code @182-2A29BDB7
 // -------------------------
	if (item.assigned_id1.GetFormattedValue()==Session["UserID"].ToString())
		issuesassigned_to1.Text = "<font color='red'>"+issuesassigned_to1.Text+"</font>";
 // -------------------------
//End Label assigned_to1 Event BeforeShow. Action Custom Code

//issues control Before Show tail @2-FCB6E20C
        }
//End issues control Before Show tail

//Grid issues BeforeShowRow event @2-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid issues BeforeShowRow event

//Grid issues Event BeforeShowRow. Action Custom Code @188-2A29BDB7
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

//OnInit Event @1-43CF11D1
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        DefaultContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        issuesSearchData = new issuesSearchDataProvider();
        issuesSearchOperations = new FormSupportedOperations(false, true, true, true, true);
        summaryData = new summaryDataProvider();
        summaryOperations = new FormSupportedOperations(false, true, false, false, false);
        issuesData = new issuesDataProvider();
        issuesOperations = new FormSupportedOperations(false, true, false, false, false);
        if(!DBUtility.AuthorizeUser(new string[]{
          "1",
          "2",
          "3"}))
            Response.Redirect(Settings.AccessDeniedUrl+"?ret_link="+Server.UrlEncode(Request["SCRIPT_NAME"]+"?"+Request["QUERY_STRING"]));
//End OnInit Event

//Page Default Event AfterInitialize. Action Custom Code @185-2A29BDB7
    // -------------------------
	if (Request.QueryString.Count == 0)
	{
		Response.Redirect("Default.aspx?s_notstatus_id=3");
		Response.End();
	}
    // -------------------------
//End Page Default Event AfterInitialize. Action Custom Code

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

