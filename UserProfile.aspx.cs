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

namespace IssueManager.UserProfile{ //Namespace @1-BEE63D3B

//Forms Definition @1-0BD72425
public partial class UserProfilePage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-D6E34B00
    protected usersDataProvider usersData;
    protected NameValueCollection usersErrors=new NameValueCollection();
    protected bool usersIsSubmitted = false;
    protected FormSupportedOperations usersOperations;
    protected System.Resources.ResourceManager rm;
    protected string UserProfileContentMeta;
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

//Record Form users Parameters @3-E6C0C700
    protected void usersParameters()
    {
        usersItem item=usersItem.CreateFromHttpRequest();
        try{
            usersData.SesUserID = IntegerParameter.GetParam(Session.Contents["UserID"]);
        }catch(Exception e){
            usersErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form users Parameters

//Record Form users Show method @3-954118C6
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

//Record Form users BeforeShow tail @3-0FD0D864
        usersParameters();
        usersData.FillItem(item,ref IsInsertMode);
        usersHolder.DataBind();
        usersUpdate.Visible=!IsInsertMode&&usersOperations.AllowUpdate;
        usersuser_name.Text=Server.HtmlEncode(item.user_name.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        userslogin.Text=Server.HtmlEncode(item.login.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        usersold_pass.Text=item.old_pass.GetFormattedValue();
        usersnew_pass.Text=item.new_pass.GetFormattedValue();
        usersrep_pass.Text=item.rep_pass.GetFormattedValue();
        usersemail.Text=item.email.GetFormattedValue();
        if(item.notify_newCheckedValue.Value.Equals(item.notify_new.Value))
            usersnotify_new.Checked = true;
        if(item.notify_originalCheckedValue.Value.Equals(item.notify_original.Value))
            usersnotify_original.Checked = true;
        if(item.notify_reassignmentCheckedValue.Value.Equals(item.notify_reassignment.Value))
            usersnotify_reassignment.Checked = true;
        usersallow_upload.Text=Server.HtmlEncode(item.allow_upload.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        userssecurity_level.Text=Server.HtmlEncode(item.security_level.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
//End Record Form users BeforeShow tail

//Record users Event BeforeShow. Action Custom Code @19-2A29BDB7
    // -------------------------
	usersallow_upload.Text = IMUtils.Translate(usersallow_upload.Text);
	userssecurity_level.Text = IMUtils.Translate("res:im_level_"+userssecurity_level.Text);
    // -------------------------
//End Record users Event BeforeShow. Action Custom Code

//Record Form users Show method tail @3-00ECC24D
        if(usersErrors.Count>0)
            usersShowErrors();
    }
//End Record Form users Show method tail

//Record Form users LoadItemFromRequest method @3-07A52A6E
    protected void usersLoadItemFromRequest(usersItem item, bool EnableValidation)
    {
        item.old_pass.SetValue(usersold_pass.Text);
        item.new_pass.SetValue(usersnew_pass.Text);
        item.rep_pass.SetValue(usersrep_pass.Text);
        item.email.SetValue(usersemail.Text);
        item.notify_new.Value = usersnotify_new.Checked ?(item.notify_newCheckedValue.Value):(item.notify_newUncheckedValue.Value);
        item.notify_original.Value = usersnotify_original.Checked ?(item.notify_originalCheckedValue.Value):(item.notify_originalUncheckedValue.Value);
        item.notify_reassignment.Value = usersnotify_reassignment.Checked ?(item.notify_reassignmentCheckedValue.Value):(item.notify_reassignmentUncheckedValue.Value);
        if(EnableValidation)
            item.Validate(usersData);
        usersErrors.Add(item.errors);
    }
//End Record Form users LoadItemFromRequest method

//Record Form users GetRedirectUrl method @3-534F42CF
    protected string GetusersRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "UserProfile.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form users GetRedirectUrl method

//Record Form users ShowErrors method @3-10DEF0D1
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

//Record Form users Insert Operation @3-EC1310A6
    protected void users_Insert(object sender, System.EventArgs e)
    {
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        usersItem item=new usersItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form users Insert Operation

//Record Form users BeforeInsert tail @3-53B6D1FB
    usersParameters();
    usersLoadItemFromRequest(item, EnableValidation);
//End Record Form users BeforeInsert tail

//Record Form users AfterInsert tail  @3-A7671D59
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users AfterInsert tail 

//Record Form users Update Operation @3-4150CA7A
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

//Button Update OnClick. @4-DABDF34E
        if(((Control)sender).ID == "usersUpdate")
        {
            RedirectUrl  = GetusersRedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @4-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form users Before Update tail @3-26DEC238
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

//Record Form users Update Operation tail @3-5E366B58
        }
        ErrorFlag=(usersErrors.Count>0);
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form users Update Operation tail

//Record Form users Delete Operation @3-F49BCB30
    protected void users_Delete(object sender,System.EventArgs e)
    {
        usersIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        usersItem item=new usersItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form users Delete Operation

//Record Form BeforeDelete tail @3-53B6D1FB
        usersParameters();
        usersLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @3-BC445D80
        if(ErrorFlag)
            usersShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form users Cancel Operation @3-61ADD70F
    protected void users_Cancel(object sender,System.EventArgs e)
    {
        usersItem item=new usersItem();
        usersIsSubmitted = true;
        string RedirectUrl = "";
        usersLoadItemFromRequest(item, true);
//End Record Form users Cancel Operation

//Record Form users Cancel Operation tail @3-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form users Cancel Operation tail

//OnInit Event @1-D0F4685E
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        UserProfileContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        usersData = new usersDataProvider();
        usersOperations = new FormSupportedOperations(false, true, false, true, false);
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

