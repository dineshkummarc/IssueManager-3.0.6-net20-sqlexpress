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

namespace IssueManager.IssueMaint{ //Namespace @1-06CB1DC4

//Forms Definition @1-73694EF0
public partial class IssueMaintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-380A02E1
    protected issuesDataProvider issuesData;
    protected NameValueCollection issuesErrors=new NameValueCollection();
    protected bool issuesIsSubmitted = false;
    protected FormSupportedOperations issuesOperations;
    protected filesDataProvider filesData;
    protected int filesCurrentRowNumber;
    protected FormSupportedOperations filesOperations;
    protected responsesDataProvider responsesData;
    protected int responsesCurrentRowNumber;
    protected FormSupportedOperations responsesOperations;
    protected System.Resources.ResourceManager rm;
    protected string IssueMaintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-37214276
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            issuesShow();
            filesBind();
            responsesBind();
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

//Record Form issues Parameters @2-C9C8DDA9
    protected void issuesParameters()
    {
        issuesItem item=issuesItem.CreateFromHttpRequest();
        try{
            issuesData.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"]);
        }catch(Exception e){
            issuesErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form issues Parameters

//Record Form issues Show method @2-98CBD354
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

//Record Form issues BeforeShow tail @2-52F667DF
        issuesParameters();
        issuesData.FillItem(item,ref IsInsertMode);
        issuesHolder.DataBind();
        issuesInsert.Visible=IsInsertMode&&issuesOperations.AllowInsert;
        issuesUpdate.Visible=!IsInsertMode&&issuesOperations.AllowUpdate;
        issuesDelete.Visible=!IsInsertMode&&issuesOperations.AllowDelete;
        issuesissue_id.Text=Server.HtmlEncode(item.issue_id.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        issuesissue_name.Text=item.issue_name.GetFormattedValue();
        issuesissue_desc.Text=item.issue_desc.GetFormattedValue();
        item.user_idItems.SetSelection(item.user_id.GetFormattedValue());
        issuesuser_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        issuesuser_id.Items[0].Selected = true;
        if(item.user_idItems.GetSelectedItem() != null)
            issuesuser_id.SelectedIndex = -1;
        item.user_idItems.CopyTo(issuesuser_id.Items);
        item.modified_byItems.SetSelection(item.modified_by.GetFormattedValue());
        issuesmodified_by.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        issuesmodified_by.Items[0].Selected = true;
        if(item.modified_byItems.GetSelectedItem() != null)
            issuesmodified_by.SelectedIndex = -1;
        item.modified_byItems.CopyTo(issuesmodified_by.Items);
        issuesdate_submitted.Text=item.date_submitted.GetFormattedValue();
        issuesdate_format.Text=Server.HtmlEncode(item.date_format.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        issuesversion.Text=item.version.GetFormattedValue();
        if(item.testedCheckedValue.Value.Equals(item.tested.Value))
            issuestested.Checked = true;
        if(item.approvedCheckedValue.Value.Equals(item.approved.Value))
            issuesapproved.Checked = true;
        item.assigned_to_origItems.SetSelection(item.assigned_to_orig.GetFormattedValue());
        issuesassigned_to_orig.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        issuesassigned_to_orig.Items[0].Selected = true;
        if(item.assigned_to_origItems.GetSelectedItem() != null)
            issuesassigned_to_orig.SelectedIndex = -1;
        item.assigned_to_origItems.CopyTo(issuesassigned_to_orig.Items);
        item.assigned_toItems.SetSelection(item.assigned_to.GetFormattedValue());
        issuesassigned_to.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        issuesassigned_to.Items[0].Selected = true;
        if(item.assigned_toItems.GetSelectedItem() != null)
            issuesassigned_to.SelectedIndex = -1;
        item.assigned_toItems.CopyTo(issuesassigned_to.Items);
        item.status_idItems.SetSelection(item.status_id.GetFormattedValue());
        issuesstatus_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        issuesstatus_id.Items[0].Selected = true;
        if(item.status_idItems.GetSelectedItem() != null)
            issuesstatus_id.SelectedIndex = -1;
        item.status_idItems.CopyTo(issuesstatus_id.Items);
        item.priority_idItems.SetSelection(item.priority_id.GetFormattedValue());
        issuespriority_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        issuespriority_id.Items[0].Selected = true;
        if(item.priority_idItems.GetSelectedItem() != null)
            issuespriority_id.SelectedIndex = -1;
        item.priority_idItems.CopyTo(issuespriority_id.Items);
//End Record Form issues BeforeShow tail

//Label date_format Event BeforeShow. Action Print General Date Format @104-5D77C37D
            issuesdate_format.Text = IMUtils.GetGeneralDateFormat();
//End Label date_format Event BeforeShow. Action Print General Date Format

//Record issues Event BeforeShow. Action Custom Code @89-2A29BDB7
    // -------------------------
	IMUtils.TranslateListbox(issuespriority_id);
	IMUtils.TranslateListbox(issuesstatus_id);
    // -------------------------
//End Record issues Event BeforeShow. Action Custom Code

//Record Form issues Show method tail @2-63B1E8A9
        if(issuesErrors.Count>0)
            issuesShowErrors();
    }
//End Record Form issues Show method tail

//Record Form issues LoadItemFromRequest method @2-83E9E2D2
    protected void issuesLoadItemFromRequest(issuesItem item, bool EnableValidation)
    {
        item.issue_name.SetValue(issuesissue_name.Text);
        item.issue_desc.SetValue(issuesissue_desc.Text);
        try{
        item.user_id.SetValue(issuesuser_id.Value);
        item.user_idItems.CopyFrom(issuesuser_id.Items);
        }catch(ArgumentException){
            issuesErrors.Add("user_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_user_submitted));}
        try{
        item.modified_by.SetValue(issuesmodified_by.Value);
        item.modified_byItems.CopyFrom(issuesmodified_by.Items);
        }catch(ArgumentException){
            issuesErrors.Add("modified_by",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_modified_by));}
        try{
        item.date_submitted.SetValue(issuesdate_submitted.Text);
        }catch(ArgumentException){
            issuesErrors.Add("date_submitted",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.im_date_submitted,@"GeneralDate"));}
        item.version.SetValue(issuesversion.Text);
        item.tested.Value = issuestested.Checked ?(item.testedCheckedValue.Value):(item.testedUncheckedValue.Value);
        item.approved.Value = issuesapproved.Checked ?(item.approvedCheckedValue.Value):(item.approvedUncheckedValue.Value);
        try{
        item.assigned_to_orig.SetValue(issuesassigned_to_orig.Value);
        item.assigned_to_origItems.CopyFrom(issuesassigned_to_orig.Items);
        }catch(ArgumentException){
            issuesErrors.Add("assigned_to_orig",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_assigned_to_orig));}
        try{
        item.assigned_to.SetValue(issuesassigned_to.Value);
        item.assigned_toItems.CopyFrom(issuesassigned_to.Items);
        }catch(ArgumentException){
            issuesErrors.Add("assigned_to",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_assigned_to));}
        try{
        item.status_id.SetValue(issuesstatus_id.Value);
        item.status_idItems.CopyFrom(issuesstatus_id.Items);
        }catch(ArgumentException){
            issuesErrors.Add("status_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_status));}
        try{
        item.priority_id.SetValue(issuespriority_id.Value);
        item.priority_idItems.CopyFrom(issuespriority_id.Items);
        }catch(ArgumentException){
            issuesErrors.Add("priority_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_priority));}
        if(EnableValidation)
            item.Validate(issuesData);
        issuesErrors.Add(item.errors);
    }
//End Record Form issues LoadItemFromRequest method

//Record Form issues GetRedirectUrl method @2-48B94139
    protected string GetissuesRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "IssueList.aspx";
        string p = parameters.ToString("GET","issue_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form issues GetRedirectUrl method

//Record Form issues ShowErrors method @2-AF233CB0
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

//Record Form issues Insert Operation @2-E1928B4D
    protected void issues_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        issuesIsSubmitted = true;
        bool ErrorFlag = false;
        issuesItem item=new issuesItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form issues Insert Operation

//Button Insert OnClick. @3-E8013A46
        if(((Control)sender).ID == "issuesInsert")
        {
            RedirectUrl  = GetissuesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @3-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record Form issues BeforeInsert tail @2-4721E804
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

//Record Form issues AfterInsert tail  @2-52D81D1C
        }
        ErrorFlag=(issuesErrors.Count>0);
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issues AfterInsert tail 

//Record Form issues Update Operation @2-A9B25668
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

//Button Update OnClick. @4-023B62B3
        if(((Control)sender).ID == "issuesUpdate")
        {
            RedirectUrl  = GetissuesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @4-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form issues Before Update tail @2-E3C05AE8
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

//Record Form issues Update Operation tail @2-52D81D1C
        }
        ErrorFlag=(issuesErrors.Count>0);
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form issues Update Operation tail

//Record Form issues Delete Operation @2-CFBE296F
    protected void issues_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        issuesIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        issuesItem item=new issuesItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form issues Delete Operation

//Button Delete OnClick. @5-89312641
        if(((Control)sender).ID == "issuesDelete")
        {
            RedirectUrl  = GetissuesRedirectUrl("", "");
            EnableValidation  = false;
//End Button Delete OnClick.

//Button Delete OnClick tail. @5-FCB6E20C
        }
//End Button Delete OnClick tail.

//Record issues Event BeforeDelete. Action Custom Code @81-2A29BDB7
 // -------------------------
    issuesParameters();
	int issue_id = Int32.Parse(issuesData.Urlissue_id.Value.ToString());
	
	string fileSQL="SELECT file_name FROM files WHERE issue_id="+issue_id;
	IDataReader dr = Settings.IMDataAccessObject.ExecuteReader(fileSQL);
	
	while (dr.Read())
	{
		try
		{
			System.IO.File.Delete(Server.MapPath(IMUtils.GetSetting("file_path")+"/"+dr.GetString(0)));
		}
		catch {}
	}
	dr.Close();

	string sSQL1 = "DELETE FROM responses WHERE issue_id=" + issue_id;
	string sSQL2 = "DELETE FROM files WHERE issue_id="+ issue_id;

	Settings.IMDataAccessObject.ExecuteNonQuery(sSQL1);
	Settings.IMDataAccessObject.ExecuteNonQuery(sSQL2);
 // -------------------------
//End Record issues Event BeforeDelete. Action Custom Code

//Record Form BeforeDelete tail @2-F03A35F9
        issuesParameters();
        issuesLoadItemFromRequest(item, EnableValidation);
        if(issuesOperations.AllowDelete){
        ErrorFlag = (issuesErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                issuesData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                issuesErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @2-AD052944
        }
        if(ErrorFlag)
            issuesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form issues Cancel Operation @2-CC0F5C39
    protected void issues_Cancel(object sender,System.EventArgs e)
    {
        issuesItem item=new issuesItem();
        issuesIsSubmitted = true;
        string RedirectUrl = "";
        issuesLoadItemFromRequest(item, false);
//End Record Form issues Cancel Operation

//Button Cancel OnClick. @6-443F8404
    if(((Control)sender).ID == "issuesCancel")
    {
        RedirectUrl  = GetissuesRedirectUrl("", "");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @6-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form issues Cancel Operation tail @2-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form issues Cancel Operation tail

//Grid files Bind @30-05421D2A
    protected void filesBind()
    {
        if (!filesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"files",typeof(filesDataProvider.SortFields), 10, 100);
        }
//End Grid files Bind

//Grid Form files BeforeShow tail @30-FF76694E
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


        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)filesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form files BeforeShow tail

//Grid files Event BeforeShow. Action Custom Code @90-2A29BDB7
    // -------------------------
 filesRepeater.Visible = filesData.RecordCount > 0;
    // -------------------------
//End Grid files Event BeforeShow. Action Custom Code

//Grid files Bind tail @30-FCB6E20C
    }
//End Grid files Bind tail

//Grid files Table Parameters @30-CEC44373
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

//Grid files ItemDataBound event @30-F712112D
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
            DataItem.file_nameHref = "FileMaint.aspx";
            filesfile_name.HRef = DataItem.file_nameHref + DataItem.file_nameHrefParameters.ToString("GET","", ViewState);
        }
//End Grid files ItemDataBound event

//files control Before Show @30-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End files control Before Show

//Get Control @34-8226B5FF
            System.Web.UI.HtmlControls.HtmlAnchor filesfile_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("filesfile_name"));
//End Get Control

//Link file_name Event BeforeShow. Action Get Original Filename @85-A95BCEAA
            filesfile_name.InnerHtml = filesfile_name.InnerHtml.Remove(0, filesfile_name.InnerHtml.IndexOf(".") + 1);
//End Link file_name Event BeforeShow. Action Get Original Filename

//DEL   // -------------------------
//DEL   filesfile_name.HRef = IMUtils.GetSetting("file_path") + "/" + filesfile_name.HRef;
//DEL   // -------------------------


//files control Before Show tail @30-FCB6E20C
        }
//End files control Before Show tail

//Grid files ItemDataBound event tail @30-FCB6E20C
    }
//End Grid files ItemDataBound event tail

//Grid files ItemCommand event @30-FA779BC2
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

//Grid responses Bind @20-3919B52A
    protected void responsesBind()
    {
        if (!responsesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"responses",typeof(responsesDataProvider.SortFields), 5, 100);
        }
//End Grid responses Bind

//Grid Form responses BeforeShow tail @20-74B5184E
        responsesParameters();
        responsesData.SortField = (responsesDataProvider.SortFields)ViewState["responsesSortField"];
        responsesData.SortDir = (SortDirections)ViewState["responsesSortDir"];
        responsesData.PageNumber = (int)ViewState["responsesPageNumber"];
        responsesData.RecordsPerPage = (int)ViewState["responsesPageSize"];
        responsesRepeater.DataSource = responsesData.GetResultSet(out PagesCount, responsesOperations);
        ViewState["responsesPagesCount"] = PagesCount;
        responsesRepeater.DataBind();
        FooterIndex = responsesRepeater.Controls.Count - 1;
        responsesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;


        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)responsesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form responses BeforeShow tail

//Grid responses Event BeforeShow. Action Custom Code @91-2A29BDB7
    // -------------------------
	responsesRepeater.Visible = responsesData.RecordCount > 0;
    // -------------------------
//End Grid responses Event BeforeShow. Action Custom Code

//Grid responses Bind tail @20-FCB6E20C
    }
//End Grid responses Bind tail

//Grid responses Table Parameters @20-68ECAC34
    protected void responsesParameters()
    {
        try{
            responsesData.Urlissue_id = IntegerParameter.GetParam(Request.QueryString["issue_id"]);
        }catch{
            ControlCollection ParentControls=responsesRepeater.Parent.Controls;
            int RepeaterIndex=ParentControls.IndexOf(responsesRepeater);
            ParentControls.RemoveAt(RepeaterIndex);
            Literal ErrorMessage=new Literal();
            ErrorMessage.Text="Error in Grid responses: Invalid parameter";
            ParentControls.AddAt(RepeaterIndex,ErrorMessage);
        }
	}
	
//End Grid responses Table Parameters

//Grid responses ItemDataBound event @20-E5BD818F
    protected void responsesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        responsesItem DataItem=(responsesItem)e.Item.DataItem;
        responsesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        responsesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.WebControls.Literal responsesuser_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responsesuser_id"));
            System.Web.UI.WebControls.Literal responsesdate_response = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responsesdate_response"));
            System.Web.UI.WebControls.Literal responsesresponse = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responsesresponse"));
            System.Web.UI.WebControls.Literal responsesassigned_to = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responsesassigned_to"));
            System.Web.UI.WebControls.Literal responsespriority_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responsespriority_id"));
            System.Web.UI.WebControls.Literal responsesstatus_id = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("responsesstatus_id"));
            System.Web.UI.HtmlControls.HtmlAnchor responsesLink1 = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("responsesLink1"));
            DataItem.Link1Href = "ResponseMaint.aspx";
            responsesLink1.HRef = DataItem.Link1Href + DataItem.Link1HrefParameters.ToString("GET","", ViewState);
        }
//End Grid responses ItemDataBound event

//Grid responses BeforeShowRow event @20-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid responses BeforeShowRow event

//Grid responses Event BeforeShowRow. Action Custom Code @92-2A29BDB7
    // -------------------------
    IMUtils.TranslateFields(e.Item, "responses");
    // -------------------------
//End Grid responses Event BeforeShowRow. Action Custom Code

//Grid responses BeforeShowRow event tail @20-FCB6E20C
        }
//End Grid responses BeforeShowRow event tail

//Grid responses ItemDataBound event tail @20-FCB6E20C
    }
//End Grid responses ItemDataBound event tail

//Grid responses ItemCommand event @20-D32607F3
    protected void responsesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = responsesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["responsesSortDir"]==SortDirections.Asc&&ViewState["responsesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["responsesSortDir"]=SortDirections.Desc;
                else
                    ViewState["responsesSortDir"]=SortDirections.Asc;
            else
                ViewState["responsesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["responsesSortField"]=Enum.Parse(typeof(responsesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["responsesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["responsesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            responsesBind();
    }
//End Grid responses ItemCommand event

//OnInit Event @1-1CB6D9FF
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        IssueMaintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        issuesData = new issuesDataProvider();
        issuesOperations = new FormSupportedOperations(false, true, true, true, true);
        filesData = new filesDataProvider();
        filesOperations = new FormSupportedOperations(false, true, false, false, false);
        responsesData = new responsesDataProvider();
        responsesOperations = new FormSupportedOperations(false, true, false, false, false);
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

