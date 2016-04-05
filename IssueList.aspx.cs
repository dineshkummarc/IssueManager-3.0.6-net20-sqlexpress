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

namespace IssueManager.IssueList{ //Namespace @1-BB356BAB

//Forms Definition @1-295B595B
public partial class IssueListPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-A9F4ED1C
    protected issuesSearchDataProvider issuesSearchData;
    protected NameValueCollection issuesSearchErrors=new NameValueCollection();
    protected bool issuesSearchIsSubmitted = false;
    protected FormSupportedOperations issuesSearchOperations;
    protected issuesDataProvider issuesData;
    protected int issuesCurrentRowNumber;
    protected FormSupportedOperations issuesOperations;
    protected System.Resources.ResourceManager rm;
    protected string IssueListContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-F4E1E3B8
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            issuesSearchShow();
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

//Record Form issuesSearch Parameters @4-8FE552B7
    protected void issuesSearchParameters()
    {
        issuesSearchItem item=issuesSearchItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            issuesSearchErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form issuesSearch Parameters

//Record Form issuesSearch Show method @4-1B3B3F71
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

//Record Form issuesSearch BeforeShow tail @4-297C8770
        issuesSearchParameters();
        issuesSearchData.FillItem(item,ref IsInsertMode);
        issuesSearchHolder.DataBind();
        issuesSearchs_issue_name.Text=item.s_issue_name.GetFormattedValue();
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

//Record issuesSearch Event BeforeShow. Action Custom Code @45-2A29BDB7
    // -------------------------
    IMUtils.TranslateListbox(issuesSearchs_priority_id);
    IMUtils.TranslateListbox(issuesSearchs_status_id);
    IMUtils.TranslateListbox(issuesSearchs_notstatus_id);
    // -------------------------
//End Record issuesSearch Event BeforeShow. Action Custom Code

//Record Form issuesSearch Show method tail @4-561B6F62
        if(issuesSearchErrors.Count>0)
            issuesSearchShowErrors();
    }
//End Record Form issuesSearch Show method tail

//Record Form issuesSearch LoadItemFromRequest method @4-8BF2A811
    protected void issuesSearchLoadItemFromRequest(issuesSearchItem item, bool EnableValidation)
    {
        item.s_issue_name.SetValue(issuesSearchs_issue_name.Text);
        try{
        item.s_priority_id.SetValue(issuesSearchs_priority_id.Value);
        item.s_priority_idItems.CopyFrom(issuesSearchs_priority_id.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_priority_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_priority));}
        try{
        item.s_status_id.SetValue(issuesSearchs_status_id.Value);
        item.s_status_idItems.CopyFrom(issuesSearchs_status_id.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_status_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_status));}
        item.s_notstatus_id.SetValue(issuesSearchs_notstatus_id.Value);
        item.s_notstatus_idItems.CopyFrom(issuesSearchs_notstatus_id.Items);
        try{
        item.s_assigned_to.SetValue(issuesSearchs_assigned_to.Value);
        item.s_assigned_toItems.CopyFrom(issuesSearchs_assigned_to.Items);
        }catch(ArgumentException){
            issuesSearchErrors.Add("s_assigned_to",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_assigned_to));}
        if(EnableValidation)
            item.Validate(issuesSearchData);
        issuesSearchErrors.Add(item.errors);
    }
//End Record Form issuesSearch LoadItemFromRequest method

//Record Form issuesSearch GetRedirectUrl method @4-9906E162
    protected string GetissuesSearchRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "IssueList.aspx";
        string p = parameters.ToString("POST",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form issuesSearch GetRedirectUrl method

//Record Form issuesSearch ShowErrors method @4-D7BA7D38
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

//Record Form issuesSearch Insert Operation @4-FBD22D2A
    protected void issuesSearch_Insert(object sender, System.EventArgs e)
    {
        issuesSearchIsSubmitted = true;
        bool ErrorFlag = false;
        issuesSearchItem item=new issuesSearchItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issuesSearch Insert Operation

//Record Form issuesSearch BeforeInsert tail @4-A29C10B8
    issuesSearchParameters();
    issuesSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form issuesSearch BeforeInsert tail

//Record Form issuesSearch AfterInsert tail  @4-83EA6FF6
        ErrorFlag=(issuesSearchErrors.Count>0);
        if(ErrorFlag)
            issuesSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issuesSearch AfterInsert tail 

//Record Form issuesSearch Update Operation @4-BC9E0584
    protected void issuesSearch_Update(object sender, System.EventArgs e)
    {
        issuesSearchItem item=new issuesSearchItem();
        item.IsNew = false;
        issuesSearchIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issuesSearch Update Operation

//Record Form issuesSearch Before Update tail @4-A29C10B8
        issuesSearchParameters();
        issuesSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form issuesSearch Before Update tail

//Record Form issuesSearch Update Operation tail @4-83EA6FF6
        ErrorFlag=(issuesSearchErrors.Count>0);
        if(ErrorFlag)
            issuesSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issuesSearch Update Operation tail

//Record Form issuesSearch Delete Operation @4-DA5627C1
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

//Record Form BeforeDelete tail @4-A29C10B8
        issuesSearchParameters();
        issuesSearchLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @4-DB7DB537
        if(ErrorFlag)
            issuesSearchShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form issuesSearch Cancel Operation @4-61B6E5D9
    protected void issuesSearch_Cancel(object sender,System.EventArgs e)
    {
        issuesSearchItem item=new issuesSearchItem();
        issuesSearchIsSubmitted = true;
        string RedirectUrl = "";
        issuesSearchLoadItemFromRequest(item, true);
//End Record Form issuesSearch Cancel Operation

//Record Form issuesSearch Cancel Operation tail @4-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form issuesSearch Cancel Operation tail

//Record Form issuesSearch Search Operation @4-D168F6B0
    protected void issuesSearch_Search(object sender, System.EventArgs e)
    {
        issuesSearchIsSubmitted = true;
        bool ErrorFlag=false;
        issuesSearchItem item=new issuesSearchItem();
        issuesSearchLoadItemFromRequest(item, true);
        ErrorFlag=(issuesSearchErrors.Count>0);
        string RedirectUrl = "";
//End Record Form issuesSearch Search Operation

//Button DoSearch OnClick. @5-074200FD
        if(((Control)sender).ID == "issuesSearchDoSearch")
        {
            RedirectUrl = GetissuesSearchRedirectUrl("", "s_issue_name;s_priority_id;s_status_id;s_notstatus_id;s_assigned_to");
//End Button DoSearch OnClick.

//Button DoSearch OnClick tail. @5-FCB6E20C
        }
//End Button DoSearch OnClick tail.

//Record Form issuesSearch Search Operation tail @4-AAE04255
        if(ErrorFlag)
            issuesSearchShowErrors();
        else{
            string Params="";
            Params+=issuesSearchs_issue_name.Text!=""?("s_issue_name="+Server.UrlEncode(issuesSearchs_issue_name.Text)+"&"):"";
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

//Grid issues Bind @3-A0410E45
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

//Grid Form issues BeforeShow tail @3-A6DA507C
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


        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)issuesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form issues BeforeShow tail

//Grid issues Bind tail @3-FCB6E20C
    }
//End Grid issues Bind tail

//Grid issues Table Parameters @3-23A9146D
    protected void issuesParameters()
    {
        try{
            issuesData.Urls_issue_name = TextParameter.GetParam(Request.QueryString["s_issue_name"]);
            issuesData.Urls_priority_id = IntegerParameter.GetParam(Request.QueryString["s_priority_id"]);
            issuesData.Urls_status_id = IntegerParameter.GetParam(Request.QueryString["s_status_id"]);
            issuesData.Urls_notstatus_id = IntegerParameter.GetParam(Request.QueryString["s_notstatus_id"]);
            issuesData.Urls_assigned_to = IntegerParameter.GetParam(Request.QueryString["s_assigned_to"]);
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

//Grid issues ItemDataBound event @3-13749011
    protected void issuesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        issuesItem DataItem=(issuesItem)e.Item.DataItem;
        issuesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        issuesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal issuesissue_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesissue_id"));
            System.Web.UI.HtmlControls.HtmlAnchor issuesissue_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("issuesissue_name"));
            System.Web.UI.WebControls.Literal issuespriority = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority"));
            System.Web.UI.WebControls.Literal issuesstatus_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesstatus_id"));
            System.Web.UI.WebControls.Literal issuesassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesassigned_to"));
            System.Web.UI.WebControls.Literal issuesdate_submitted = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_submitted"));
            System.Web.UI.WebControls.Literal issuesdate_modified = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_modified"));
            System.Web.UI.WebControls.Literal issuesdate_resolved = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuesdate_resolved"));
            DataItem.issue_nameHref = "IssueMaint.aspx";
            issuesissue_name.HRef = DataItem.issue_nameHref + DataItem.issue_nameHrefParameters.ToString("GET","", ViewState);
        }
//End Grid issues ItemDataBound event

//issues control Before Show @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End issues control Before Show

//Get Control @51-5940F362
            System.Web.UI.WebControls.Literal issuespriority = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuespriority"));
//End Get Control

//Label priority Event BeforeShow. Action Translate @61-8BCBE31B
            issuespriority.Text = IMUtils.Translate(issuespriority.Text);
//End Label priority Event BeforeShow. Action Translate

//issues control Before Show tail @3-FCB6E20C
        }
//End issues control Before Show tail

//Grid issues BeforeShowRow event @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid issues BeforeShowRow event

//Grid issues Event BeforeShowRow. Action Custom Code @46-2A29BDB7
    // -------------------------
    IMUtils.TranslateFields(e.Item, "issues");
    // -------------------------
//End Grid issues Event BeforeShowRow. Action Custom Code

//Grid issues BeforeShowRow event tail @3-FCB6E20C
        }
//End Grid issues BeforeShowRow event tail

//Grid issues ItemDataBound event tail @3-FCB6E20C
    }
//End Grid issues ItemDataBound event tail

//Grid issues ItemCommand event @3-88103A00
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

//OnInit Event @1-0BD501BC
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        IssueListContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        issuesSearchData = new issuesSearchDataProvider();
        issuesSearchOperations = new FormSupportedOperations(false, true, true, true, true);
        issuesData = new issuesDataProvider();
        issuesOperations = new FormSupportedOperations(false, true, false, false, false);
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

