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

namespace IssueManager.ResponseMaint{ //Namespace @1-9E8732F7

//Forms Definition @1-8E0697AD
public partial class ResponseMaintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-05796103
    protected responsesDataProvider responsesData;
    protected NameValueCollection responsesErrors=new NameValueCollection();
    protected bool responsesIsSubmitted = false;
    protected FormSupportedOperations responsesOperations;
    protected System.Resources.ResourceManager rm;
    protected string ResponseMaintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-692BED60
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            responsesShow();
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

//Record Form responses Parameters @7-A1835EFE
    protected void responsesParameters()
    {
        responsesItem item=responsesItem.CreateFromHttpRequest();
        try{
            responsesData.Urlresponse_id = IntegerParameter.GetParam(Request.QueryString["response_id"]);
        }catch(Exception e){
            responsesErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form responses Parameters

//Record Form responses Show method @7-176F3E92
    protected void responsesShow()
    {
        if(responsesOperations.None)
        {
            responsesHolder.Visible=false;
            return;
        }
        responsesItem item=responsesItem.CreateFromHttpRequest();
        bool IsInsertMode=!responsesOperations.AllowRead;
        responsesErrors.Add(item.errors);
//End Record Form responses Show method

//Record Form responses BeforeShow tail @7-8C9EFFEC
        responsesParameters();
        responsesData.FillItem(item,ref IsInsertMode);
        responsesHolder.DataBind();
        responsesInsert.Visible=IsInsertMode&&responsesOperations.AllowInsert;
        responsesUpdate.Visible=!IsInsertMode&&responsesOperations.AllowUpdate;
        responsesDelete.Visible=!IsInsertMode&&responsesOperations.AllowDelete;
        item.user_idItems.SetSelection(item.user_id.GetFormattedValue());
        responsesuser_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        responsesuser_id.Items[0].Selected = true;
        if(item.user_idItems.GetSelectedItem() != null)
            responsesuser_id.SelectedIndex = -1;
        item.user_idItems.CopyTo(responsesuser_id.Items);
        responsesdate_response.Text=item.date_response.GetFormattedValue();
        responsesresponse.Text=item.response.GetFormattedValue();
        item.assigned_toItems.SetSelection(item.assigned_to.GetFormattedValue());
        responsesassigned_to.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        responsesassigned_to.Items[0].Selected = true;
        if(item.assigned_toItems.GetSelectedItem() != null)
            responsesassigned_to.SelectedIndex = -1;
        item.assigned_toItems.CopyTo(responsesassigned_to.Items);
        item.priority_idItems.SetSelection(item.priority_id.GetFormattedValue());
        responsespriority_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        responsespriority_id.Items[0].Selected = true;
        if(item.priority_idItems.GetSelectedItem() != null)
            responsespriority_id.SelectedIndex = -1;
        item.priority_idItems.CopyTo(responsespriority_id.Items);
        item.status_idItems.SetSelection(item.status_id.GetFormattedValue());
        responsesstatus_id.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        responsesstatus_id.Items[0].Selected = true;
        if(item.status_idItems.GetSelectedItem() != null)
            responsesstatus_id.SelectedIndex = -1;
        item.status_idItems.CopyTo(responsesstatus_id.Items);
        responsesdate_format.Text=Server.HtmlEncode(item.date_format.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
//End Record Form responses BeforeShow tail

//Label date_format Event BeforeShow. Action Print General Date Format @104-30D4B514
            responsesdate_format.Text = IMUtils.GetGeneralDateFormat();
//End Label date_format Event BeforeShow. Action Print General Date Format

//Record responses Event BeforeShow. Action Custom Code @20-2A29BDB7
    // -------------------------
	IMUtils.TranslateListbox(responsespriority_id);
	IMUtils.TranslateListbox(responsesstatus_id);
    // -------------------------
//End Record responses Event BeforeShow. Action Custom Code

//Record Form responses Show method tail @7-FC388417
        if(responsesErrors.Count>0)
            responsesShowErrors();
    }
//End Record Form responses Show method tail

//Record Form responses LoadItemFromRequest method @7-AC38CFB6
    protected void responsesLoadItemFromRequest(responsesItem item, bool EnableValidation)
    {
        try{
        item.user_id.SetValue(responsesuser_id.Value);
        item.user_idItems.CopyFrom(responsesuser_id.Items);
        }catch(ArgumentException){
            responsesErrors.Add("user_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_user_submitted));}
        try{
        item.date_response.SetValue(responsesdate_response.Text);
        }catch(ArgumentException){
            responsesErrors.Add("date_response",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.im_date_response,@"GeneralDate"));}
        item.response.SetValue(responsesresponse.Text);
        try{
        item.assigned_to.SetValue(responsesassigned_to.Value);
        item.assigned_toItems.CopyFrom(responsesassigned_to.Items);
        }catch(ArgumentException){
            responsesErrors.Add("assigned_to",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_assigned_to));}
        try{
        item.priority_id.SetValue(responsespriority_id.Value);
        item.priority_idItems.CopyFrom(responsespriority_id.Items);
        }catch(ArgumentException){
            responsesErrors.Add("priority_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_priority));}
        try{
        item.status_id.SetValue(responsesstatus_id.Value);
        item.status_idItems.CopyFrom(responsesstatus_id.Items);
        }catch(ArgumentException){
            responsesErrors.Add("status_id",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_status));}
        if(EnableValidation)
            item.Validate(responsesData);
        responsesErrors.Add(item.errors);
    }
//End Record Form responses LoadItemFromRequest method

//Record Form responses GetRedirectUrl method @7-8B364BB4
    protected string GetresponsesRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "IssueMaint.aspx";
        string p = parameters.ToString("GET","response_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form responses GetRedirectUrl method

//Record Form responses ShowErrors method @7-5C06861E
    protected void responsesShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<responsesErrors.Count;i++)
        switch(responsesErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=responsesErrors[i];
                break;
        }
        responsesError.Visible = true;
        responsesErrorLabel.Text = DefaultMessage;
    }
//End Record Form responses ShowErrors method

//Record Form responses Insert Operation @7-E88663AE
    protected void responses_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        responsesIsSubmitted = true;
        bool ErrorFlag = false;
        responsesItem item=new responsesItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form responses Insert Operation

//Button Insert OnClick. @8-371EAB12
        if(((Control)sender).ID == "responsesInsert")
        {
            RedirectUrl  = GetresponsesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @8-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record Form responses BeforeInsert tail @7-9823C8F8
    responsesParameters();
    responsesLoadItemFromRequest(item, EnableValidation);
    if(responsesOperations.AllowInsert){
    ErrorFlag=(responsesErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                responsesData.InsertItem(item);
            }
            catch (Exception ex)
            {
                responsesErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form responses BeforeInsert tail

//Record Form responses AfterInsert tail  @7-B5D339F5
        }
        ErrorFlag=(responsesErrors.Count>0);
        if(ErrorFlag)
            responsesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form responses AfterInsert tail 

//Record Form responses Update Operation @7-57201DDB
    protected void responses_Update(object sender, System.EventArgs e)
    {
        responsesItem item=new responsesItem();
        item.IsNew = false;
        responsesIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form responses Update Operation

//Button Update OnClick. @9-307F142D
        if(((Control)sender).ID == "responsesUpdate")
        {
            RedirectUrl  = GetresponsesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @9-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form responses Before Update tail @7-34242BC5
        responsesParameters();
        responsesLoadItemFromRequest(item, EnableValidation);
        if(responsesOperations.AllowUpdate){
        ErrorFlag=(responsesErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                responsesData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                responsesErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form responses Before Update tail

//Record Form responses Update Operation tail @7-B5D339F5
        }
        ErrorFlag=(responsesErrors.Count>0);
        if(ErrorFlag)
            responsesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form responses Update Operation tail

//Record Form responses Delete Operation @7-ED5F0B4E
    protected void responses_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        responsesIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        responsesItem item=new responsesItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form responses Delete Operation

//Button Delete OnClick. @10-028DA4E9
        if(((Control)sender).ID == "responsesDelete")
        {
            RedirectUrl  = GetresponsesRedirectUrl("", "");
            EnableValidation  = false;
//End Button Delete OnClick.

//Button Delete OnClick tail. @10-FCB6E20C
        }
//End Button Delete OnClick tail.

//Record Form BeforeDelete tail @7-6B50D843
        responsesParameters();
        responsesLoadItemFromRequest(item, EnableValidation);
        if(responsesOperations.AllowDelete){
        ErrorFlag = (responsesErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                responsesData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                responsesErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @7-904767EB
        }
        if(ErrorFlag)
            responsesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form responses Cancel Operation @7-C585EE8E
    protected void responses_Cancel(object sender,System.EventArgs e)
    {
        responsesItem item=new responsesItem();
        responsesIsSubmitted = true;
        string RedirectUrl = "";
        responsesLoadItemFromRequest(item, false);
//End Record Form responses Cancel Operation

//Button Cancel OnClick. @11-0F2B6AA9
    if(((Control)sender).ID == "responsesCancel")
    {
        RedirectUrl  = GetresponsesRedirectUrl("", "");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @11-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form responses Cancel Operation tail @7-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form responses Cancel Operation tail

//OnInit Event @1-755660D8
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        ResponseMaintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        responsesData = new responsesDataProvider();
        responsesOperations = new FormSupportedOperations(false, true, true, true, true);
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

