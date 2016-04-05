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

namespace IssueManager.install_mdb{ //Namespace @1-091E0B56

//Forms Definition @1-8BF4486F
public partial class install_mdbPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-34E1BC4B
    protected sql_environmentDataProvider sql_environmentData;
    protected NameValueCollection sql_environmentErrors=new NameValueCollection();
    protected bool sql_environmentIsSubmitted = false;
    protected FormSupportedOperations sql_environmentOperations;
    protected System.Resources.ResourceManager rm;
    protected string install_mdbContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-8F630642
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            item.InstallLinkHref = "install_mdb.aspx";
            item.Link2Href = "Default.aspx";
            PageData.FillItem(item);
            FsoCheck.Text=item.FsoCheck.GetFormattedValue();
            UploadCheck.Text=item.UploadCheck.GetFormattedValue();
            MailerCheck.Text=item.MailerCheck.GetFormattedValue();
            WriteCheck.Text=item.WriteCheck.GetFormattedValue();
            DbWriteCheck.Text=item.DbWriteCheck.GetFormattedValue();
            FolderCheck.Text=item.FolderCheck.GetFormattedValue();
            InstallLink.InnerText += item.InstallLink.GetFormattedValue().Replace("\r","").Replace("\n","<br>");
            InstallLink.HRef = item.InstallLinkHref+item.InstallLinkHrefParameters.ToString("None","", ViewState);
            Link2.InnerText=Resources.strings.inst_start;
            Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("None","step", ViewState);
            sql_environmentShow();
    }
//End Page_Load Event BeforeIsPostBack

//Panel Panel1 Event BeforeShow. Action Custom Code @39-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Panel Panel1 Event BeforeShow. Action Custom Code

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

//Record Form sql_environment Parameters @2-1F43CFE2
    protected void sql_environmentParameters()
    {
        sql_environmentItem item=sql_environmentItem.CreateFromHttpRequest();
        try{
        }catch(Exception e){
            sql_environmentErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form sql_environment Parameters

//Record Form sql_environment Show method @2-4E86F276
    protected void sql_environmentShow()
    {
        if(sql_environmentOperations.None)
        {
            sql_environmentHolder.Visible=false;
            return;
        }
        sql_environmentItem item=sql_environmentItem.CreateFromHttpRequest();
        bool IsInsertMode=!sql_environmentOperations.AllowRead;
        sql_environmentErrors.Add(item.errors);
//End Record Form sql_environment Show method

//Record Form sql_environment BeforeShow tail @2-0C14EFB5
        sql_environmentParameters();
        sql_environmentData.FillItem(item,ref IsInsertMode);
        sql_environmentHolder.DataBind();
        sql_environmentSiteURL.Text=item.SiteURL.GetFormattedValue();
        sql_environmentmdb_file.Text=item.mdb_file.GetFormattedValue();
        if(item.UpgradeDataCheckedValue.Value.Equals(item.UpgradeData.Value))
            sql_environmentUpgradeData.Checked = true;
        if(item.SampleDataCheckedValue.Value.Equals(item.SampleData.Value))
            sql_environmentSampleData.Checked = true;
        sql_environmentuser_login.Text=item.user_login.GetFormattedValue();
        sql_environmentuser_password.Text=item.user_password.GetFormattedValue();
        sql_environmentuser_password_rep.Text=item.user_password_rep.GetFormattedValue();
//End Record Form sql_environment BeforeShow tail

//Record Form sql_environment Show method tail @2-DF3CDB06
        if(sql_environmentErrors.Count>0)
            sql_environmentShowErrors();
    }
//End Record Form sql_environment Show method tail

//Record Form sql_environment LoadItemFromRequest method @2-99987E55
    protected void sql_environmentLoadItemFromRequest(sql_environmentItem item, bool EnableValidation)
    {
        item.SiteURL.SetValue(sql_environmentSiteURL.Text);
        item.mdb_file.SetValue(sql_environmentmdb_file.Text);
        item.UpgradeData.Value = sql_environmentUpgradeData.Checked ?(item.UpgradeDataCheckedValue.Value):(item.UpgradeDataUncheckedValue.Value);
        item.SampleData.Value = sql_environmentSampleData.Checked ?(item.SampleDataCheckedValue.Value):(item.SampleDataUncheckedValue.Value);
        item.user_login.SetValue(sql_environmentuser_login.Text);
        item.user_password.SetValue(sql_environmentuser_password.Text);
        item.user_password_rep.SetValue(sql_environmentuser_password_rep.Text);
        if(EnableValidation)
            item.Validate(sql_environmentData);
        sql_environmentErrors.Add(item.errors);
    }
//End Record Form sql_environment LoadItemFromRequest method

//Record Form sql_environment GetRedirectUrl method @2-98EEFDCE
    protected string Getsql_environmentRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "install_mdb.aspx";
        string p = parameters.ToString("GET",removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form sql_environment GetRedirectUrl method

//Record Form sql_environment ShowErrors method @2-49124DDF
    protected void sql_environmentShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<sql_environmentErrors.Count;i++)
        switch(sql_environmentErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=sql_environmentErrors[i];
                break;
        }
        sql_environmentError.Visible = true;
        sql_environmentErrorLabel.Text = DefaultMessage;
    }
//End Record Form sql_environment ShowErrors method

//Record Form sql_environment Insert Operation @2-1C155996
    protected void sql_environment_Insert(object sender, System.EventArgs e)
    {
        sql_environmentIsSubmitted = true;
        bool ErrorFlag = false;
        sql_environmentItem item=new sql_environmentItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form sql_environment Insert Operation

//Record Form sql_environment BeforeInsert tail @2-46858B07
    sql_environmentParameters();
    sql_environmentLoadItemFromRequest(item, EnableValidation);
//End Record Form sql_environment BeforeInsert tail

//Record Form sql_environment AfterInsert tail  @2-65B81C57
        ErrorFlag=(sql_environmentErrors.Count>0);
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form sql_environment AfterInsert tail 

//Record Form sql_environment Update Operation @2-48338BF6
    protected void sql_environment_Update(object sender, System.EventArgs e)
    {
        sql_environmentItem item=new sql_environmentItem();
        item.IsNew = false;
        sql_environmentIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form sql_environment Update Operation

//Record Form sql_environment Before Update tail @2-46858B07
        sql_environmentParameters();
        sql_environmentLoadItemFromRequest(item, EnableValidation);
//End Record Form sql_environment Before Update tail

//Record Form sql_environment Update Operation tail @2-65B81C57
        ErrorFlag=(sql_environmentErrors.Count>0);
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form sql_environment Update Operation tail

//Record Form sql_environment Delete Operation @2-617F9CF3
    protected void sql_environment_Delete(object sender,System.EventArgs e)
    {
        sql_environmentIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        sql_environmentItem item=new sql_environmentItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form sql_environment Delete Operation

//Record Form BeforeDelete tail @2-46858B07
        sql_environmentParameters();
        sql_environmentLoadItemFromRequest(item, EnableValidation);
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @2-B9341FA3
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form sql_environment Cancel Operation @2-25DCCFC1
    protected void sql_environment_Cancel(object sender,System.EventArgs e)
    {
        sql_environmentItem item=new sql_environmentItem();
        sql_environmentIsSubmitted = true;
        string RedirectUrl = "";
        sql_environmentLoadItemFromRequest(item, true);
//End Record Form sql_environment Cancel Operation

//Record Form sql_environment Cancel Operation tail @2-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form sql_environment Cancel Operation tail

//Button Update OnClick Handler @8-73EB5098
    protected void sql_environment_Update_OnClick(object sender, System.EventArgs e)
    {
        string RedirectUrl = Getsql_environmentRedirectUrl("", "");
        sql_environmentItem item = new sql_environmentItem();
        sql_environmentLoadItemFromRequest(item, true);
        bool ErrorFlag=(sql_environmentErrors.Count>0);
//End Button Update OnClick Handler

//Button Update OnClick Handler tail @8-B9341FA3
        if(ErrorFlag)
            sql_environmentShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Button Update OnClick Handler tail

//OnInit Event @1-13DF2612
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        install_mdbContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        sql_environmentData = new sql_environmentDataProvider();
        sql_environmentOperations = new FormSupportedOperations(false, true, true, true, true);
//End OnInit Event

//Page install_mdb Event AfterInitialize. Action Custom Code @23-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Page install_mdb Event AfterInitialize. Action Custom Code

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

