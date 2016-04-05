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

namespace IssueManager.IssueNew{ //Namespace @1-66863192

//Forms Definition @1-8AF7AA06
public partial class IssueNewPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-5B20CE5A
    protected issuesDataProvider issuesData;
    protected NameValueCollection issuesErrors=new NameValueCollection();
    protected bool issuesIsSubmitted = false;
    protected FormSupportedOperations issuesOperations;
    protected System.Resources.ResourceManager rm;
    protected string IssueNewContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-59F5330C
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            issuesShow();
    }
//End Page_Load Event BeforeIsPostBack

//Page IssueNew Event BeforeShow. Action Custom Code @65-2A29BDB7
 // -------------------------
 // -------------------------
//End Page IssueNew Event BeforeShow. Action Custom Code

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

//Record Form issues Parameters @4-100A4D5B
    protected void issuesParameters()
    {
        issuesItem item=issuesItem.CreateFromHttpRequest();
        try{
            issuesData.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"]);
            issuesData.Ctrlissue_name = TextParameter.GetParam(item.issue_name.Value);
            issuesData.Ctrlissue_desc = MemoParameter.GetParam(item.issue_desc.Value);
            issuesData.Ctrlpriority_id = IntegerParameter.GetParam(item.priority_id.Value);
            issuesData.Ctrlstatus_id = IntegerParameter.GetParam(item.status_id.Value);
            issuesData.Ctrlversion = TextParameter.GetParam(item.version.Value);
            issuesData.Ctrlassigned_to = IntegerParameter.GetParam(item.assigned_to.Value);
            issuesData.Ctrldate_now = DateParameter.GetParam(item.date_now.Value, "G");
            issuesData.SesUserID = IntegerParameter.GetParam(Session.Contents["UserID"]);
        }catch(Exception e){
            issuesErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form issues Parameters

//Record Form issues Show method @4-98CBD354
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

//Record Form issues BeforeShow tail @4-94716ACE
        issuesParameters();
        issuesData.FillItem(item,ref IsInsertMode);
        issuesHolder.DataBind();
        issuesInsert.Visible=IsInsertMode&&issuesOperations.AllowInsert;
        issuesissue_name.Text=item.issue_name.GetFormattedValue();
        issuesissue_desc.Text=item.issue_desc.GetFormattedValue();
        item.priority_idItems.SetSelection(item.priority_id.GetFormattedValue());
        if(item.priority_idItems.GetSelectedItem() != null)
            issuespriority_id.SelectedIndex = -1;
        item.priority_idItems.CopyTo(issuespriority_id.Items);
        item.status_idItems.SetSelection(item.status_id.GetFormattedValue());
        if(item.status_idItems.GetSelectedItem() != null)
            issuesstatus_id.SelectedIndex = -1;
        item.status_idItems.CopyTo(issuesstatus_id.Items);
        issuesversion.Text=item.version.GetFormattedValue();
        item.assigned_toItems.SetSelection(item.assigned_to.GetFormattedValue());
        if(item.assigned_toItems.GetSelectedItem() != null)
            issuesassigned_to.SelectedIndex = -1;
        item.assigned_toItems.CopyTo(issuesassigned_to.Items);
        issuesuser_name.Text=Server.HtmlEncode(item.user_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        issuesdate_submitted.Text=Server.HtmlEncode(item.date_submitted.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
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
        issuesdate_now.Value=item.date_now.GetFormattedValue();
//End Record Form issues BeforeShow tail

//Label user_name Event BeforeShow. Action Retrieve Value for Control @51-C7F610F0
            issuesuser_name.Text = (new TextField("", System.Web.HttpContext.Current.Session["UserLogin"])).GetFormattedValue();
//End Label user_name Event BeforeShow. Action Retrieve Value for Control

//Button Insert Event BeforeShow. Action Hide-Show Component @68-8B68F5C8
        TextField ExprParam1_68_1 = new TextField("", (1));
        TextField ExprParam2_68_2 = new TextField("", (1));
        if (ExprParam1_68_1 == ExprParam2_68_2) {
            issuesInsert.Visible = true;
        }
//End Button Insert Event BeforeShow. Action Hide-Show Component

//Record issues Event BeforeShow. Action Custom Code @66-2A29BDB7
 // -------------------------
 	issuesUploadControls.Visible = IMUtils.GetSetting("upload_enabled") == "1" && IMUtils.Lookup("allow_upload","users","user_id="+Session["UserID"]) == "1";
	IMUtils.TranslateListbox(issuespriority_id);
	IMUtils.TranslateListbox(issuesstatus_id);
	IMUtils.SetupUpload(issuesattachment);
 // -------------------------
//End Record issues Event BeforeShow. Action Custom Code

//Record Form issues Show method tail @4-63B1E8A9
        if(issuesErrors.Count>0)
            issuesShowErrors();
    }
//End Record Form issues Show method tail

//Record Form issues LoadItemFromRequest method @4-180AD6CF
    protected void issuesLoadItemFromRequest(issuesItem item, bool EnableValidation)
    {
        item.issue_name.SetValue(issuesissue_name.Text);
        item.issue_desc.SetValue(issuesissue_desc.Text);
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
        try{
        item.assigned_to.SetValue(issuesassigned_to.Value);
        item.assigned_toItems.CopyFrom(issuesassigned_to.Items);
        }catch(ArgumentException){
            issuesErrors.Add("assigned_to",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_assigned_to));}
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
        try{
        item.date_now.SetValue(issuesdate_now.Value);
        }catch(ArgumentException){
            issuesErrors.Add("date_now",String.Format(Resources.strings.CCS_IncorrectFormat,"date_now",@"GeneralDate"));}
        if(EnableValidation)
            item.Validate(issuesData);
        issuesErrors.Add(item.errors);
    }
//End Record Form issues LoadItemFromRequest method

//Record Form issues GetRedirectUrl method @4-243ABD38
    protected string GetissuesRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "Default.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form issues GetRedirectUrl method

//Record Form issues ShowErrors method @4-AF233CB0
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

//Record Form issues Insert Operation @4-E1928B4D
    protected void issues_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        issuesIsSubmitted = true;
        bool ErrorFlag = false;
        issuesItem item=new issuesItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issues Insert Operation

//Button Insert OnClick. @5-E8013A46
        if(((Control)sender).ID == "issuesInsert")
        {
            RedirectUrl  = GetissuesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @5-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record issues Event BeforeInsert. Action Custom Code @67-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record issues Event BeforeInsert. Action Custom Code

//Record Form issues BeforeInsert tail @4-4721E804
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

//Record issues Event AfterInsert. Action Custom Code @37-2A29BDB7
    // -------------------------
  if(ExecuteFlag&&!ErrorFlag)
	{
		int current = Int32.Parse(Session["UserID"].ToString());
		//@@IDENTITY extraction not working with Lookup
		//int issue_id = Int32.Parse(IMUtils.Lookup("@@IDENTITY","issues","1=1"));
		int issue_id = Int32.Parse(IMUtils.Lookup("MAX(issue_id)","issues","user_id="+current));
		int assigned = Int32.Parse(IMUtils.Lookup("assigned_to", "issues", "issue_id="+issue_id));

		if (issuesattachment.Text != null && issuesattachment.Text.Length > 0)
		{
			DataAccessObject dao = Settings.IMDataAccessObject;
			string sql = "INSERT INTO files(issue_id, uploaded_by, file_name, date_uploaded) VALUES ("+issue_id+", "+current+", "+dao.ToSql(issuesattachment.Text, FieldType.Text)+", "+dao.ToSql(new DateParameter(DateTime.Now).GetFormattedValue(dao.DateFormat), FieldType.Date)+")";
			dao.ExecuteNonQuery(sql);
		}

		if (assigned != current && IMUtils.Lookup("notify_new","users","user_id="+assigned) == "1")
			IMUtils.SendNotification("notify_new", assigned, issue_id);
	}
    // -------------------------
//End Record issues Event AfterInsert. Action Custom Code

//Record Form issues AfterInsert tail  @4-D790B512
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

//Record Form issues Update Operation @4-9B252B3D
    protected void issues_Update(object sender, System.EventArgs e)
    {
        issuesItem item=new issuesItem();
        item.IsNew = false;
        issuesIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issues Update Operation

//Record Form issues Before Update tail @4-57B233D6
        issuesParameters();
        issuesLoadItemFromRequest(item, EnableValidation);
//End Record Form issues Before Update tail

//Record Form issues Update Operation tail @4-F2A50105
        ErrorFlag=(issuesErrors.Count>0);
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issues Update Operation tail

//Record Form issues Delete Operation @4-CCFD5533
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

//Record Form BeforeDelete tail @4-57B233D6
        issuesParameters();
        issuesLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @4-5D7A3302
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form issues Cancel Operation @4-CC0F5C39
    protected void issues_Cancel(object sender,System.EventArgs e)
    {
        issuesItem item=new issuesItem();
        issuesIsSubmitted = true;
        string RedirectUrl = "";
        issuesLoadItemFromRequest(item, false);
//End Record Form issues Cancel Operation

//Button Cancel OnClick. @8-443F8404
    if(((Control)sender).ID == "issuesCancel")
    {
        RedirectUrl  = GetissuesRedirectUrl("", "");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @8-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form issues Cancel Operation tail @4-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form issues Cancel Operation tail

//OnInit Event @1-75B837CA
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        IssueNewContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        issuesData = new issuesDataProvider();
        issuesOperations = new FormSupportedOperations(false, false, true, false, false);
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

