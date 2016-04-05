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

namespace IssueManager.IssueChange{ //Namespace @1-04BBC92F

//Forms Definition @1-2399E002
public partial class IssueChangePage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-E80974A8
    protected issueDataProvider issueData;
    protected int issueCurrentRowNumber;
    protected FormSupportedOperations issueOperations;
    protected filesDataProvider filesData;
    protected int filesCurrentRowNumber;
    protected FormSupportedOperations filesOperations;
    protected issuesDataProvider issuesData;
    protected NameValueCollection issuesErrors=new NameValueCollection();
    protected bool issuesIsSubmitted = false;
    protected FormSupportedOperations issuesOperations;
    protected responses1DataProvider responses1Data;
    protected int responses1CurrentRowNumber;
    protected FormSupportedOperations responses1Operations;
    protected System.Resources.ResourceManager rm;
    protected string IssueChangeContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-C269615A
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            issueBind();
            filesBind();
            issuesShow();
            responses1Bind();
    }
//End Page_Load Event BeforeIsPostBack

//Page IssueChange Event BeforeShow. Action Custom Code @287-2A29BDB7
 // -------------------------
 // -------------------------
//End Page IssueChange Event BeforeShow. Action Custom Code

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

//Grid issue Bind @2-B0DA0559
    protected void issueBind()
    {
        if (!issueOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"issue",typeof(issueDataProvider.SortFields), 1, 100);
        }
//End Grid issue Bind

//Grid Form issue BeforeShow tail @2-0AF84B9D
        issueParameters();
        issueData.SortField = (issueDataProvider.SortFields)ViewState["issueSortField"];
        issueData.SortDir = (SortDirections)ViewState["issueSortDir"];
        issueData.PageNumber = (int)ViewState["issuePageNumber"];
        issueData.RecordsPerPage = (int)ViewState["issuePageSize"];
        issueRepeater.DataSource = issueData.GetResultSet(out PagesCount, issueOperations);
        ViewState["issuePagesCount"] = PagesCount;
        issueRepeater.DataBind();
        FooterIndex = issueRepeater.Controls.Count - 1;


//End Grid Form issue BeforeShow tail

//Grid issue Event BeforeShow. Action Custom Code @294-2A29BDB7
    // -------------------------
	if (issueData.RecordCount == 0)
	{
		Response.Redirect("Default.aspx");
		Response.End();
	}
    // -------------------------
//End Grid issue Event BeforeShow. Action Custom Code

//Grid issue Bind tail @2-FCB6E20C
    }
//End Grid issue Bind tail

//Grid issue Table Parameters @2-C88CCB66
    protected void issueParameters()
    {
        try{
            issueData.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"], (object)(74));
        }catch{
            ControlCollection ParentControls=issueRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(issueRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid issue: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid issue Table Parameters

//Grid issue ItemDataBound event @2-C4BC2AEF
    protected void issueItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        issueItem DataItem=(issueItem)e.Item.DataItem;
        issueItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        issueCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal issueissue_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueissue_id"));
            System.Web.UI.WebControls.Literal issueissue_name = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueissue_name"));
            System.Web.UI.WebControls.Literal issueissue_desc = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueissue_desc"));
            System.Web.UI.WebControls.Literal issueuser_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueuser_id"));
            System.Web.UI.WebControls.Literal issuedate_submitted = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuedate_submitted"));
            System.Web.UI.WebControls.Literal issueversion = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueversion"));
            System.Web.UI.WebControls.Literal issuetested = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuetested"));
            System.Web.UI.WebControls.Literal issueapproved = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueapproved"));
            System.Web.UI.WebControls.Literal issueassigned_to_orig = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueassigned_to_orig"));
            System.Web.UI.WebControls.Literal issueassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issueassigned_to"));
            System.Web.UI.WebControls.Literal issuepriority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuepriority_id"));
            System.Web.UI.WebControls.Literal issuestatus_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("issuestatus_id"));
        }
//End Grid issue ItemDataBound event

//Grid issue BeforeShowRow event @2-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid issue BeforeShowRow event

//Grid issue Event BeforeShowRow. Action Custom Code @295-2A29BDB7
    // -------------------------
	IMUtils.TranslateFields(e.Item,"issue");
    // -------------------------
//End Grid issue Event BeforeShowRow. Action Custom Code

//Grid issue BeforeShowRow event tail @2-FCB6E20C
        }
//End Grid issue BeforeShowRow event tail

//Grid issue ItemDataBound event tail @2-FCB6E20C
    }
//End Grid issue ItemDataBound event tail

//Grid issue ItemCommand event @2-B4F65BCD
    protected void issueItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = issueRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["issueSortDir"]==SortDirections.Asc&&ViewState["issueSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["issueSortDir"]=SortDirections.Desc;
                else
                    ViewState["issueSortDir"]=SortDirections.Asc;
            else
                ViewState["issueSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["issueSortField"]=Enum.Parse(typeof(issueDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["issuePageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["issuePageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            issueBind();
    }
//End Grid issue ItemCommand event

//Grid files Bind @231-EE448040
    protected void filesBind()
    {
        if (!filesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"files",typeof(filesDataProvider.SortFields), 0, -1);
        }
//End Grid files Bind

//Grid Form files BeforeShow tail @231-777B34D8
        filesParameters();
        filesData.SortField = (filesDataProvider.SortFields)ViewState["filesSortField"];
        filesData.SortDir = (SortDirections)ViewState["filesSortDir"];
        filesData.PageNumber = (int)ViewState["filesPageNumber"];
        filesData.RecordsPerPage = (int)ViewState["filesPageSize"];
        filesRepeater.DataSource = filesData.GetResultSet(out PagesCount, filesOperations);
        ViewState["filesPagesCount"] = PagesCount;
        filesRepeater.DataBind();
        FooterIndex = filesRepeater.Controls.Count - 1;
        filesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;


//End Grid Form files BeforeShow tail

//Grid files Event BeforeShow. Action Custom Code @242-2A29BDB7
 // -------------------------
 filesRepeater.Visible = filesData.RecordCount > 0;
 // -------------------------
//End Grid files Event BeforeShow. Action Custom Code

//Grid files Bind tail @231-FCB6E20C
    }
//End Grid files Bind tail

//Grid files Table Parameters @231-CEC44373
    protected void filesParameters()
    {
        try{
            filesData.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"], (object)(-1));
        }catch{
            ControlCollection ParentControls=filesRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(filesRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid files: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid files Table Parameters

//Grid files ItemDataBound event @231-BA372767
    protected void filesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        filesItem DataItem=(filesItem)e.Item.DataItem;
        filesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        filesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor filesfile_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("filesfile_name"));
            System.Web.UI.WebControls.Literal filesuploaded_by = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("filesuploaded_by"));
            System.Web.UI.WebControls.Literal filesdate_uploaded = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("filesdate_uploaded"));
            filesfile_name.HRef = DataItem.file_nameHref + DataItem.file_nameHrefParameters.ToString("None","", ViewState);
        }
//End Grid files ItemDataBound event

//files control Before Show @231-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End files control Before Show

//Get Control @235-8226B5FF
            System.Web.UI.HtmlControls.HtmlAnchor filesfile_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("filesfile_name"));
//End Get Control

//Link file_name Event BeforeShow. Action Get Original Filename @236-A95BCEAA
            filesfile_name.InnerHtml = filesfile_name.InnerHtml.Remove(0, filesfile_name.InnerHtml.IndexOf(".") + 1);
//End Link file_name Event BeforeShow. Action Get Original Filename

//Link file_name Event BeforeShow. Action Custom Code @243-2A29BDB7
 // -------------------------
 filesfile_name.HRef = IMUtils.GetSetting("file_path") + "/" + filesfile_name.HRef;
 // -------------------------
//End Link file_name Event BeforeShow. Action Custom Code

//files control Before Show tail @231-FCB6E20C
        }
//End files control Before Show tail

//Grid files ItemDataBound event tail @231-FCB6E20C
    }
//End Grid files ItemDataBound event tail

//Grid files ItemCommand event @231-FA779BC2
    protected void filesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = filesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["filesSortDir"]==SortDirections.Asc&&ViewState["filesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["filesSortDir"]=SortDirections.Desc;
                else
                    ViewState["filesSortDir"]=SortDirections.Asc;
            else
                ViewState["filesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["filesSortField"]=Enum.Parse(typeof(filesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["filesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["filesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            filesBind();
    }
//End Grid files ItemCommand event

//Record Form issues Parameters @34-E23017E6
    protected void issuesParameters()
    {
        issuesItem item=issuesItem.CreateFromHttpRequest();
        try{
            issuesData.Ctrlissue_resp = MemoParameter.GetParam(item.issue_resp.Value);
            issuesData.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"]);
            issuesData.Ctrlassigned_to = IntegerParameter.GetParam(item.assigned_to.Value);
            issuesData.Ctrlpriority_id = IntegerParameter.GetParam(item.priority_id.Value);
            issuesData.Ctrlstatus_id = IntegerParameter.GetParam(item.status_id.Value);
            issuesData.Ctrlversion = TextParameter.GetParam(item.version.Value);
            issuesData.Ctrltested = IntegerParameter.GetParam(item.tested.Value);
            issuesData.Ctrlapproved = IntegerParameter.GetParam(item.approved.Value);
            issuesData.Ctrldate_now = DateParameter.GetParam(item.date_now.Value, "G");
            issuesData.SesUserID = IntegerParameter.GetParam(Session.Contents["UserID"]);
            issuesData.Expr286 = DateParameter.GetParam("", "G");
        }catch(Exception e){
            issuesErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form issues Parameters

//Record Form issues Show method @34-98CBD354
    protected void issuesShow()
    {
        if(issuesOperations.None)
        {
            issuesHolder.Visible=false;
            return;
        }
        issuesItem item=issuesItem.CreateFromHttpRequest();
        bool IsInsertMode=!issuesOperations.AllowRead;
        issuesErrors.Add(item.errors);
//End Record Form issues Show method

//Record Form issues BeforeShow tail @34-3485DD8F
        issuesParameters();
        issuesData.FillItem(item,ref IsInsertMode);
        issuesHolder.DataBind();
        issuesInsert.Visible=IsInsertMode&&issuesOperations.AllowInsert;
        issuesissue_resp.Text=item.issue_resp.GetFormattedValue();
        item.assigned_toItems.SetSelection(item.assigned_to.GetFormattedValue());
        if(item.assigned_toItems.GetSelectedItem() != null)
            issuesassigned_to.SelectedIndex = -1;
        item.assigned_toItems.CopyTo(issuesassigned_to.Items);
        item.priority_idItems.SetSelection(item.priority_id.GetFormattedValue());
        if(item.priority_idItems.GetSelectedItem() != null)
            issuespriority_id.SelectedIndex = -1;
        item.priority_idItems.CopyTo(issuespriority_id.Items);
        item.status_idItems.SetSelection(item.status_id.GetFormattedValue());
        if(item.status_idItems.GetSelectedItem() != null)
            issuesstatus_id.SelectedIndex = -1;
        item.status_idItems.CopyTo(issuesstatus_id.Items);
        issuesversion.Text=item.version.GetFormattedValue();
        if(item.testedCheckedValue.Value.Equals(item.tested.Value))
            issuestested.Checked = true;
        if(item.approvedCheckedValue.Value.Equals(item.approved.Value))
            issuesapproved.Checked = true;
        try{
            issuesattachment.FileFolder = @"uploads";
        }catch(System.IO.DirectoryNotFoundException){
            issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_FilesFolderNotFound,"{res:im_file}"));
        }catch(System.Security.SecurityException){
            issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_InsufficientPermissions,"{res:im_file}"));
        }
        try{
            issuesattachment.TemporaryFolder = @"temp";
        }catch(System.IO.DirectoryNotFoundException){
            issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_TempFolderNotFound,"{res:im_file}"));
        }catch(System.Security.SecurityException){
            issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_TempInsufficientPermissions,"{res:im_file}"));
        }
        issuesattachment.FileSizeLimit = 1000000;
        try{
            issuesattachment.Text = item.attachment.GetFormattedValue();
        }catch(System.IO.FileNotFoundException){
            issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_FileNotFound,item.attachment.GetFormattedValue(),"{res:im_file}"));
        }
        issuesFormAction.Value=item.FormAction.GetFormattedValue();
        issuesdate_now.Value=item.date_now.GetFormattedValue();
//End Record Form issues BeforeShow tail

//DEL   // -------------------------
//DEL  		IMUtils.PopulateFiles(issuesfiles, issuesAddFiles);
//DEL   // -------------------------


//Button Insert Event BeforeShow. Action Hide-Show Component @275-5EEE9FD3
        TextField ExprParam1_275_1 = new TextField("", (1));
        TextField ExprParam2_275_2 = new TextField("", (1));
        if (ExprParam1_275_1 == ExprParam2_275_2) {
            issuesInsert.Visible = true;
        }
//End Button Insert Event BeforeShow. Action Hide-Show Component

//Record issues Event BeforeShow. Action Custom Code @223-2A29BDB7
 // -------------------------
 	issuesUploadControls.Visible = IMUtils.GetSetting("upload_enabled") == "1" && IMUtils.Lookup("allow_upload","users","user_id="+Session["UserID"]) == "1";
	IMUtils.TranslateListbox(issuespriority_id);
	IMUtils.TranslateListbox(issuesstatus_id);
	IMUtils.SetupUpload(issuesattachment);
// -------------------------
//End Record issues Event BeforeShow. Action Custom Code

//Record Form issues Show method tail @34-63B1E8A9
        if(issuesErrors.Count>0)
            issuesShowErrors();
    }
//End Record Form issues Show method tail

//Record Form issues LoadItemFromRequest method @34-A7CEC598
    protected void issuesLoadItemFromRequest(issuesItem item, bool EnableValidation)
    {
        item.issue_resp.SetValue(issuesissue_resp.Text);
        try{
        item.assigned_to.SetValue(issuesassigned_to.Value);
        item.assigned_toItems.CopyFrom(issuesassigned_to.Items);
        }catch(ArgumentException){
            issuesErrors.Add("assigned_to",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_assigned_to));}
        try{
        item.priority_id.SetValue(issuespriority_id.Value);
        item.priority_idItems.CopyFrom(issuespriority_id.Items);
        }catch(ArgumentException){
            issuesErrors.Add("priority_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_priority));}
        try{
        item.status_id.SetValue(issuesstatus_id.Value);
        item.status_idItems.CopyFrom(issuesstatus_id.Items);
        }catch(ArgumentException){
            issuesErrors.Add("status_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_status));}
        item.version.SetValue(issuesversion.Text);
        item.tested.Value = issuestested.Checked ?(item.testedCheckedValue.Value):(item.testedUncheckedValue.Value);
        item.approved.Value = issuesapproved.Checked ?(item.approvedCheckedValue.Value):(item.approvedUncheckedValue.Value);
        item.attachment.IsEmpty = Request.Form[issuesattachment.UniqueID]==null;
        try{
            issuesattachment.ValidateFile();
            item.attachment.SetValue(issuesattachment.Text);
        }catch(InvalidOperationException ex){
            if(ex.Message == "The file type is not allowed.")
                issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_WrongType,"{res:im_file}"));
            if(ex.Message == "The file is too large.")
                issuesErrors.Add("attachment",String.Format(Resources.strings.CCS_LargeFile,"{res:im_file}"));
        }
        item.FormAction.SetValue(issuesFormAction.Value);
        try{
        item.date_now.SetValue(issuesdate_now.Value);
        }catch(ArgumentException){
            issuesErrors.Add("date_now",String.Format(Resources.strings.CCS_IncorrectFormat,"date_now",@"GeneralDate"));}
        if(EnableValidation)
            item.Validate(issuesData);
        issuesErrors.Add(item.errors);
    }
//End Record Form issues LoadItemFromRequest method

//Record Form issues GetRedirectUrl method @34-39A58B06
    protected string GetissuesRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "Default.aspx";
        string p = parameters.ToString("GET","issue_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form issues GetRedirectUrl method

//Record Form issues ShowErrors method @34-AF233CB0
    protected void issuesShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<issuesErrors.Count;i++)
        switch(issuesErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=issuesErrors[i];
                break;
        }
        issuesError.Visible = true;
        issuesErrorLabel.Text = DefaultMessage;
    }
//End Record Form issues ShowErrors method

//Record Form issues Insert Operation @34-E1928B4D
    protected void issues_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        issuesIsSubmitted = true;
        bool ErrorFlag = false;
        issuesItem item=new issuesItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issues Insert Operation

//Button Insert OnClick. @43-E8013A46
        if(((Control)sender).ID == "issuesInsert")
        {
            RedirectUrl  = GetissuesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @43-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record issues Event BeforeInsert. Action Custom Code @292-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record issues Event BeforeInsert. Action Custom Code

//Record Form issues BeforeInsert tail @34-4721E804
    issuesParameters();
    issuesLoadItemFromRequest(item, EnableValidation);
    if(issuesOperations.AllowInsert){
    ErrorFlag=(issuesErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                issuesData.InsertItem(item);
            }
            catch (Exception ex)
            {
                issuesErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form issues BeforeInsert tail

//Record issues Event AfterInsert. Action Custom Code @228-2A29BDB7
 // -------------------------
  if(ExecuteFlag&&!ErrorFlag)
	{
 		int issue_id = (int)issuesData.Urlissue_id.Value;
		int current = Int32.Parse(Session["UserID"].ToString());
		int user_id = Int32.Parse(IMUtils.Lookup("user_id","issues","issue_id="+issue_id));
		int assigned = Int32.Parse(IMUtils.Lookup("assigned_to", "issues", "issue_id="+issue_id));
		int assigned_new = Int32.Parse(item.assigned_to.GetFormattedValue());

		if (issuesattachment.Text != null && issuesattachment.Text.Length > 0)
		{
			DataAccessObject dao = Settings.IMDataAccessObject;
			string sql = "INSERT INTO files(issue_id, uploaded_by, file_name, date_uploaded) VALUES ("+issue_id+", "+current+", "+dao.ToSql(issuesattachment.Text, FieldType.Text)+", "+dao.ToSql(new DateParameter(DateTime.Now).GetFormattedValue(dao.DateFormat), FieldType.Date)+")";
			dao.ExecuteNonQuery(sql);
		}

		if (user_id != current && IMUtils.Lookup("notify_original","users","user_id="+user_id) == "1")
			IMUtils.SendNotification("notify_change", user_id, issue_id);

		if (assigned != current && IMUtils.Lookup("notify_reassignment","users","user_id="+assigned) == "1")
			IMUtils.SendNotification("notify_change", assigned, issue_id);

		if (assigned != assigned_new && assigned_new != current && IMUtils.Lookup("notify_new","users","user_id="+assigned_new) == "1")
			IMUtils.SendNotification("notify_new", assigned_new, issue_id);


 		if (issuesstatus_id.Items[issuesstatus_id.SelectedIndex].Value == "3")
			issuesData.Expr286 = issuesData.Ctrldate_now;

    	issuesData.UpdateItem(item);
	}
 // -------------------------
//End Record issues Event AfterInsert. Action Custom Code

//Record Form issues AfterInsert tail  @34-D790B512
            if(!ErrorFlag)
                issuesattachment.SaveFile();
            if(!ErrorFlag)
                issuesattachment.SaveFile();
        }
        ErrorFlag=(issuesErrors.Count>0);
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issues AfterInsert tail 

//Record Form issues Update Operation @34-A9B25668
    protected void issues_Update(object sender, System.EventArgs e)
    {
        issuesItem item=new issuesItem();
        item.IsNew = false;
        issuesIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issues Update Operation

//Record Form issues Before Update tail @34-E3C05AE8
        issuesParameters();
        issuesLoadItemFromRequest(item, EnableValidation);
        if(issuesOperations.AllowUpdate){
        ErrorFlag=(issuesErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                issuesData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                issuesErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form issues Before Update tail

//Record Form issues Update Operation tail @34-D790B512
            if(!ErrorFlag)
                issuesattachment.SaveFile();
            if(!ErrorFlag)
                issuesattachment.SaveFile();
        }
        ErrorFlag=(issuesErrors.Count>0);
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issues Update Operation tail

//Record Form issues Delete Operation @34-CCFD5533
    protected void issues_Delete(object sender,System.EventArgs e)
    {
        issuesIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        issuesItem item=new issuesItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form issues Delete Operation

//Record Form BeforeDelete tail @34-57B233D6
        issuesParameters();
        issuesLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @34-5D7A3302
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form issues Cancel Operation @34-FFD024FD
    protected void issues_Cancel(object sender,System.EventArgs e)
    {
        issuesItem item=new issuesItem();
        issuesIsSubmitted = true;
        string RedirectUrl = "";
        issuesLoadItemFromRequest(item, true);
//End Record Form issues Cancel Operation

//Record Form issues Cancel Operation tail @34-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form issues Cancel Operation tail

//Grid responses1 Bind @25-3C99F278
    protected void responses1Bind()
    {
        if (!responses1Operations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"responses1",typeof(responses1DataProvider.SortFields), 5, 100);
        }
//End Grid responses1 Bind

//Grid Form responses1 BeforeShow tail @25-1F5E8FD0
        responses1Parameters();
        responses1Data.SortField = (responses1DataProvider.SortFields)ViewState["responses1SortField"];
        responses1Data.SortDir = (SortDirections)ViewState["responses1SortDir"];
        responses1Data.PageNumber = (int)ViewState["responses1PageNumber"];
        responses1Data.RecordsPerPage = (int)ViewState["responses1PageSize"];
        responses1Repeater.DataSource = responses1Data.GetResultSet(out PagesCount, responses1Operations);
        ViewState["responses1PagesCount"] = PagesCount;
        responses1Repeater.DataBind();
        FooterIndex = responses1Repeater.Controls.Count - 1;


        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)responses1Repeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form responses1 BeforeShow tail

//Grid responses1 Event BeforeShow. Action Custom Code @226-2A29BDB7
    // -------------------------
		responses1Repeater.Visible = responses1Data.RecordCount > 0;
    // -------------------------
//End Grid responses1 Event BeforeShow. Action Custom Code

//Grid responses1 Bind tail @25-FCB6E20C
    }
//End Grid responses1 Bind tail

//Grid responses1 Table Parameters @25-96D58AD0
    protected void responses1Parameters()
    {
        try{
            responses1Data.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"], (object)(-1));
        }catch{
            ControlCollection ParentControls=responses1Repeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(responses1Repeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid responses1: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid responses1 Table Parameters

//Grid responses1 ItemDataBound event @25-C5FF2DC8
    protected void responses1ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        responses1Item DataItem=(responses1Item)e.Item.DataItem;
        responses1Item item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        responses1CurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal responses1response = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responses1response"));
            System.Web.UI.WebControls.Literal responses1user_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responses1user_id"));
            System.Web.UI.WebControls.Literal responses1date_response = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responses1date_response"));
            System.Web.UI.WebControls.Literal responses1assigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responses1assigned_to"));
            System.Web.UI.WebControls.Literal responses1priority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responses1priority_id"));
            System.Web.UI.WebControls.Literal responses1status_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responses1status_id"));
        }
//End Grid responses1 ItemDataBound event

//Grid responses1 BeforeShowRow event @25-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid responses1 BeforeShowRow event

//Grid responses1 Event BeforeShowRow. Action Custom Code @296-2A29BDB7
    // -------------------------
	IMUtils.TranslateFields(e.Item,"responses1");
    // -------------------------
//End Grid responses1 Event BeforeShowRow. Action Custom Code

//Grid responses1 BeforeShowRow event tail @25-FCB6E20C
        }
//End Grid responses1 BeforeShowRow event tail

//Grid responses1 ItemDataBound event tail @25-FCB6E20C
    }
//End Grid responses1 ItemDataBound event tail

//Grid responses1 ItemCommand event @25-1CD9EB43
    protected void responses1ItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = responses1Repeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["responses1SortDir"]==SortDirections.Asc&&ViewState["responses1SortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["responses1SortDir"]=SortDirections.Desc;
                else
                    ViewState["responses1SortDir"]=SortDirections.Asc;
            else
                ViewState["responses1SortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["responses1SortField"]=Enum.Parse(typeof(responses1DataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["responses1PageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["responses1PageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            responses1Bind();
    }
//End Grid responses1 ItemCommand event

//OnInit Event @1-AB4E6E31
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        IssueChangeContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        issueData = new issueDataProvider();
        issueOperations = new FormSupportedOperations(false, true, false, false, false);
        filesData = new filesDataProvider();
        filesOperations = new FormSupportedOperations(false, true, false, false, false);
        issuesData = new issuesDataProvider();
        issuesOperations = new FormSupportedOperations(false, true, true, true, false);
        responses1Data = new responses1DataProvider();
        responses1Operations = new FormSupportedOperations(false, true, false, false, false);
        if(!DBUtility.AuthorizeUser(new string[]{
          "1",
          "2",
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

