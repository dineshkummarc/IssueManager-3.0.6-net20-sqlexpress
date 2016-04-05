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

namespace IssueManager.UserMaint{ //Namespace @1-3F845022

//Forms Definition @1-4C0F1377
public partial class UserMaintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-80968AB4
    protected usersDataProvider usersData;
    protected NameValueCollection usersErrors=new NameValueCollection();
    protected bool usersIsSubmitted = false;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string UserMaintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-77FCC4BC
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            usersShow();
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

//Record Form users Parameters @4-C5E981BC
    protected void usersParameters()
    {
        usersItem item=usersItem.CreateFromHttpRequest();
        try{
            usersData.Urluser_id = IntegerParameter.GetParam(Request.QueryString["user_id"]);
            usersData.Ctrllogin = TextParameter.GetParam(item.login.Value);
            usersData.Ctrlsecurity_level = IntegerParameter.GetParam(item.security_level.Value);
            usersData.Ctrluser_name = TextParameter.GetParam(item.user_name.Value);
            usersData.Ctrlemail = TextParameter.GetParam(item.email.Value);
            usersData.Ctrlallow_upload = IntegerParameter.GetParam(item.allow_upload.Value);
            usersData.Ctrlnotify_new = IntegerParameter.GetParam(item.notify_new.Value);
            usersData.Ctrlnotify_original = IntegerParameter.GetParam(item.notify_original.Value);
            usersData.Ctrlnotify_reassignment = IntegerParameter.GetParam(item.notify_reassignment.Value);
            usersData.Ctrlnew_pass = TextParameter.GetParam(item.new_pass.Value);
        }catch(Exception e){
            usersErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form users Parameters

//Record Form users Show method @4-954118C6
    protected void usersShow()
    {
        if(usersOperations.None)
        {
            usersHolder.Visible=false;
            return;
        }
        usersItem item=usersItem.CreateFromHttpRequest();
        bool IsInsertMode=!usersOperations.AllowRead;
        usersErrors.Add(item.errors);
//End Record Form users Show method

//Record Form users BeforeShow tail @4-B61F3068
        usersParameters();
        usersData.FillItem(item,ref IsInsertMode);
        usersHolder.DataBind();
        usersInsert.Visible=IsInsertMode&&usersOperations.AllowInsert;
        usersUpdate.Visible=!IsInsertMode&&usersOperations.AllowUpdate;
        usersDelete.Visible=!IsInsertMode&&usersOperations.AllowDelete;
        userslogin.Text=item.login.GetFormattedValue();
        usersnew_pass.Text=item.new_pass.GetFormattedValue();
        usersrep_pass.Text=item.rep_pass.GetFormattedValue();
        item.security_levelItems.SetSelection(item.security_level.GetFormattedValue());
        if(item.security_levelItems.GetSelectedItem() != null)
            userssecurity_level.SelectedIndex = -1;
        item.security_levelItems.CopyTo(userssecurity_level.Items);
        usersuser_name.Text=item.user_name.GetFormattedValue();
        usersemail.Text=item.email.GetFormattedValue();
        if(item.allow_uploadCheckedValue.Value.Equals(item.allow_upload.Value))
            usersallow_upload.Checked = true;
        if(item.notify_newCheckedValue.Value.Equals(item.notify_new.Value))
            usersnotify_new.Checked = true;
        if(item.notify_originalCheckedValue.Value.Equals(item.notify_original.Value))
            usersnotify_original.Checked = true;
        if(item.notify_reassignmentCheckedValue.Value.Equals(item.notify_reassignment.Value))
            usersnotify_reassignment.Checked = true;
//End Record Form users BeforeShow tail

//Record users Event BeforeShow. Action Custom Code @58-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record users Event BeforeShow. Action Custom Code

//Record Form users Show method tail @4-00ECC24D
        if(usersErrors.Count>0)
            usersShowErrors();
    }
//End Record Form users Show method tail

//Record Form users LoadItemFromRequest method @4-0CA01A3A
    protected void usersLoadItemFromRequest(usersItem item, bool EnableValidation)
    {
        item.login.SetValue(userslogin.Text);
        item.new_pass.SetValue(usersnew_pass.Text);
        item.rep_pass.SetValue(usersrep_pass.Text);
        try{
        item.security_level.SetValue(userssecurity_level.Value);
        item.security_levelItems.CopyFrom(userssecurity_level.Items);
        }catch(ArgumentException){
            usersErrors.Add("security_level",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_security_level));}
        item.user_name.SetValue(usersuser_name.Text);
        item.email.SetValue(usersemail.Text);
        item.allow_upload.Value = usersallow_upload.Checked ?(item.allow_uploadCheckedValue.Value):(item.allow_uploadUncheckedValue.Value);
        item.notify_new.Value = usersnotify_new.Checked ?(item.notify_newCheckedValue.Value):(item.notify_newUncheckedValue.Value);
        item.notify_original.Value = usersnotify_original.Checked ?(item.notify_originalCheckedValue.Value):(item.notify_originalUncheckedValue.Value);
        item.notify_reassignment.Value = usersnotify_reassignment.Checked ?(item.notify_reassignmentCheckedValue.Value):(item.notify_reassignmentUncheckedValue.Value);
        if(EnableValidation)
            item.Validate(usersData);
        usersErrors.Add(item.errors);
    }
//End Record Form users LoadItemFromRequest method

//Record Form users GetRedirectUrl method @4-B39786F3
    protected string GetusersRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "UserList.aspx";
        string p = parameters.ToString("None",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form users GetRedirectUrl method

//Record Form users ShowErrors method @4-10DEF0D1
    protected void usersShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<usersErrors.Count;i++)
        switch(usersErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=usersErrors[i];
                break;
        }
        usersError.Visible = true;
        usersErrorLabel.Text = DefaultMessage;
    }
//End Record Form users ShowErrors method

//Record Form users Insert Operation @4-D59EDEA8
    protected void users_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        usersItem item=new usersItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Insert Operation

//Button Insert OnClick. @5-35A23FCA
        if(((Control)sender).ID == "usersInsert")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @5-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record Form users BeforeInsert tail @4-491CA3DB
    usersParameters();
    usersLoadItemFromRequest(item, EnableValidation);
    if(usersOperations.AllowInsert){
    ErrorFlag=(usersErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                usersData.InsertItem(item);
            }
            catch (Exception ex)
            {
                usersErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form users BeforeInsert tail

//Record Form users AfterInsert tail  @4-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users AfterInsert tail 

//Record Form users Update Operation @4-4150CA7A
    protected void users_Update(object sender, System.EventArgs e)
    {
        usersItem item=new usersItem();
        item.IsNew = false;
        usersIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Update Operation

//Button Update OnClick. @6-DABDF34E
        if(((Control)sender).ID == "usersUpdate")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @6-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form users Before Update tail @4-26DEC238
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
        if(usersOperations.AllowUpdate){
        ErrorFlag=(usersErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                usersData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                usersErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form users Before Update tail

//Record Form users Update Operation tail @4-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users Update Operation tail

//Record Form users Delete Operation @4-0534F4DD
    protected void users_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        usersItem item=new usersItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form users Delete Operation

//Button Delete OnClick. @7-BE07F07D
        if(((Control)sender).ID == "usersDelete")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = false;
//End Button Delete OnClick.

//Button Delete OnClick tail. @7-FCB6E20C
        }
//End Button Delete OnClick tail.

//Record Form BeforeDelete tail @4-D76FA851
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
        if(usersOperations.AllowDelete){
        ErrorFlag = (usersErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                usersData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                usersErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @4-CCCD5F10
        }
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form users Cancel Operation @4-9F22B2FA
    protected void users_Cancel(object sender,System.EventArgs e)
    {
        usersItem item=new usersItem();
        usersIsSubmitted = true;
        string RedirectUrl = "";
        usersLoadItemFromRequest(item, false);
//End Record Form users Cancel Operation

//Button Cancel OnClick. @8-5107DBF7
    if(((Control)sender).ID == "usersCancel")
    {
        RedirectUrl  = GetusersRedirectUrl("", "");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @8-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form users Cancel Operation tail @4-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form users Cancel Operation tail

//OnInit Event @1-E32A34C5
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        UserMaintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, true, true, true);
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

