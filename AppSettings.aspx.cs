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

namespace IssueManager.AppSettings{ //Namespace @1-B4B13ED0

//Forms Definition @1-C9BFADCD
public partial class AppSettingsPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-1226CC8C
    protected settingsDataProvider settingsData;
    protected NameValueCollection settingsErrors=new NameValueCollection();
    protected bool settingsIsSubmitted = false;
    protected FormSupportedOperations settingsOperations;
    protected System.Resources.ResourceManager rm;
    protected string AppSettingsContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-5C9B9E36
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            settingsShow();
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

//Record Form settings Parameters @3-E5D1B828
    protected void settingsParameters()
    {
        settingsItem item=settingsItem.CreateFromHttpRequest();
        try{
            settingsData.Urlsettings_id = IntegerParameter.GetParam(Request.QueryString["settings_id"], (object)(1));
        }catch(Exception e){
            settingsErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form settings Parameters

//Record Form settings Show method @3-CD43E804
    protected void settingsShow()
    {
        if(settingsOperations.None)
        {
            settingsHolder.Visible=false;
            return;
        }
        settingsItem item=settingsItem.CreateFromHttpRequest();
        bool IsInsertMode=!settingsOperations.AllowRead;
        settingsErrors.Add(item.errors);
//End Record Form settings Show method

//Record Form settings BeforeShow tail @3-36701706
        settingsParameters();
        settingsData.FillItem(item,ref IsInsertMode);
        settingsHolder.DataBind();
        settingsUpdate.Visible=!IsInsertMode&&settingsOperations.AllowUpdate;
        if(item.upload_enabledCheckedValue.Value.Equals(item.upload_enabled.Value))
            settingsupload_enabled.Checked = true;
        settingsfile_extensions.Text=item.file_extensions.GetFormattedValue();
        settingsfile_path.Text=item.file_path.GetFormattedValue();
        settingsnotify_new_from.Text=item.notify_new_from.GetFormattedValue();
        settingsnotify_new_subject.Text=item.notify_new_subject.GetFormattedValue();
        settingsnotify_new_body.Text=item.notify_new_body.GetFormattedValue();
        settingsnotify_change_from.Text=item.notify_change_from.GetFormattedValue();
        settingsnotify_change_subject.Text=item.notify_change_subject.GetFormattedValue();
        settingsnotify_change_body.Text=item.notify_change_body.GetFormattedValue();
        item.email_componentItems.SetSelection(item.email_component.GetFormattedValue());
        if(item.email_componentItems.GetSelectedItem() != null)
            settingsemail_component.SelectedIndex = -1;
        item.email_componentItems.CopyTo(settingsemail_component.Items);
        settingssmtp_host.Text=item.smtp_host.GetFormattedValue();
//End Record Form settings BeforeShow tail

//Record settings Event BeforeShow. Action Custom Code @48-2A29BDB7
    // -------------------------
	IMUtils.TranslateListbox(settingsemail_component);
    // -------------------------
//End Record settings Event BeforeShow. Action Custom Code

//Record Form settings Show method tail @3-E1CADFCF
        if(settingsErrors.Count>0)
            settingsShowErrors();
    }
//End Record Form settings Show method tail

//Record Form settings LoadItemFromRequest method @3-6306B2A1
    protected void settingsLoadItemFromRequest(settingsItem item, bool EnableValidation)
    {
        item.upload_enabled.Value = settingsupload_enabled.Checked ?(item.upload_enabledCheckedValue.Value):(item.upload_enabledUncheckedValue.Value);
        item.file_extensions.SetValue(settingsfile_extensions.Text);
        item.file_path.SetValue(settingsfile_path.Text);
        item.notify_new_from.SetValue(settingsnotify_new_from.Text);
        item.notify_new_subject.SetValue(settingsnotify_new_subject.Text);
        item.notify_new_body.SetValue(settingsnotify_new_body.Text);
        item.notify_change_from.SetValue(settingsnotify_change_from.Text);
        item.notify_change_subject.SetValue(settingsnotify_change_subject.Text);
        item.notify_change_body.SetValue(settingsnotify_change_body.Text);
        item.email_component.IsEmpty = Request.Form[settingsemail_component.UniqueID]==null;
        item.email_component.SetValue(settingsemail_component.Value);
        item.email_componentItems.CopyFrom(settingsemail_component.Items);
        item.smtp_host.IsEmpty = Request.Form[settingssmtp_host.UniqueID]==null;
        item.smtp_host.SetValue(settingssmtp_host.Text);
        if(EnableValidation)
            item.Validate(settingsData);
        settingsErrors.Add(item.errors);
    }
//End Record Form settings LoadItemFromRequest method

//Record Form settings GetRedirectUrl method @3-2619E213
    protected string GetsettingsRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "Administration.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form settings GetRedirectUrl method

//Record Form settings ShowErrors method @3-884E0386
    protected void settingsShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<settingsErrors.Count;i++)
        switch(settingsErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=settingsErrors[i];
                break;
        }
        settingsError.Visible = true;
        settingsErrorLabel.Text = DefaultMessage;
    }
//End Record Form settings ShowErrors method

//Record Form settings Insert Operation @3-9A98C82E
    protected void settings_Insert(object sender, System.EventArgs e)
    {
        settingsIsSubmitted = true;
        bool ErrorFlag = false;
        settingsItem item=new settingsItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form settings Insert Operation

//Record Form settings BeforeInsert tail @3-42D744AF
    settingsParameters();
    settingsLoadItemFromRequest(item, EnableValidation);
//End Record Form settings BeforeInsert tail

//Record Form settings AfterInsert tail  @3-1FD67C4F
        ErrorFlag=(settingsErrors.Count>0);
        if(ErrorFlag)
            settingsShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form settings AfterInsert tail 

//Record Form settings Update Operation @3-42CF4D4F
    protected void settings_Update(object sender, System.EventArgs e)
    {
        settingsItem item=new settingsItem();
        item.IsNew = false;
        settingsIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form settings Update Operation

//Button Update OnClick. @5-097E26FC
        if(((Control)sender).ID == "settingsUpdate")
        {
            RedirectUrl  = GetsettingsRedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @5-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form settings Before Update tail @3-A2E4B14D
        settingsParameters();
        settingsLoadItemFromRequest(item, EnableValidation);
        if(settingsOperations.AllowUpdate){
        ErrorFlag=(settingsErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                settingsData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                settingsErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form settings Before Update tail

//Record settings Event AfterUpdate. Action Custom Code @49-2A29BDB7
    // -------------------------
	IMUtils.FlushSettings();
    // -------------------------
//End Record settings Event AfterUpdate. Action Custom Code

//Record Form settings Update Operation tail @3-6BBC9A1D
        }
        ErrorFlag=(settingsErrors.Count>0);
        if(ErrorFlag)
            settingsShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form settings Update Operation tail

//Record Form settings Delete Operation @3-B225F663
    protected void settings_Delete(object sender,System.EventArgs e)
    {
        settingsIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        settingsItem item=new settingsItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form settings Delete Operation

//Record Form BeforeDelete tail @3-42D744AF
        settingsParameters();
        settingsLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @3-2445BE05
        if(ErrorFlag)
            settingsShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form settings Cancel Operation @3-84AE9A69
    protected void settings_Cancel(object sender,System.EventArgs e)
    {
        settingsItem item=new settingsItem();
        settingsIsSubmitted = true;
        string RedirectUrl = "";
        settingsLoadItemFromRequest(item, true);
//End Record Form settings Cancel Operation

//Record Form settings Cancel Operation tail @3-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form settings Cancel Operation tail

//OnInit Event @1-71D60889
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        AppSettingsContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        settingsData = new settingsDataProvider();
        settingsOperations = new FormSupportedOperations(false, true, false, true, false);
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

