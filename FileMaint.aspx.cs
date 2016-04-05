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

namespace IssueManager.FileMaint{ //Namespace @1-77C51B4D

//Forms Definition @1-B44DCD1B
public partial class FileMaintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-88DD50EA
    protected filesDataProvider filesData;
    protected NameValueCollection filesErrors=new NameValueCollection();
    protected bool filesIsSubmitted = false;
    protected FormSupportedOperations filesOperations;
    protected System.Resources.ResourceManager rm;
    protected string FileMaintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-2621AF21
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            filesShow();
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

//Record Form files Parameters @3-A84C2D87
    protected void filesParameters()
    {
        filesItem item=filesItem.CreateFromHttpRequest();
        try{
            filesData.Urlfile_id = IntegerParameter.GetParam(Request.QueryString["file_id"]);
        }catch(Exception e){
            filesErrors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form files Parameters

//Record Form files Show method @3-CEC18390
    protected void filesShow()
    {
        if(filesOperations.None)
        {
            filesHolder.Visible=false;
            return;
        }
        filesItem item=filesItem.CreateFromHttpRequest();
        bool IsInsertMode=!filesOperations.AllowRead;
        filesErrors.Add(item.errors);
//End Record Form files Show method

//Record Form files BeforeShow tail @3-616709E5
        filesParameters();
        filesData.FillItem(item,ref IsInsertMode);
        filesHolder.DataBind();
        filesUpdate.Visible=!IsInsertMode&&filesOperations.AllowUpdate;
        filesDelete.Visible=!IsInsertMode&&filesOperations.AllowDelete;
        filesfile.InnerText += item.file.GetFormattedValue().Replace("\r","").Replace("\n","<br>");
        filesfile.HRef = item.fileHref+item.fileHrefParameters.ToString("None","", ViewState);
        try{
            filesfile_name.FileFolder = @"uploads";
        }catch(System.IO.DirectoryNotFoundException){
            filesErrors.Add("file_name",String.Format(Resources.strings.CCS_FilesFolderNotFound,"{res:im_file_name}"));
        }catch(System.Security.SecurityException){
            filesErrors.Add("file_name",String.Format(Resources.strings.CCS_InsufficientPermissions,"{res:im_file_name}"));
        }
        try{
            filesfile_name.TemporaryFolder = @"temp";
        }catch(System.IO.DirectoryNotFoundException){
            filesErrors.Add("file_name",String.Format(Resources.strings.CCS_TempFolderNotFound,"{res:im_file_name}"));
        }catch(System.Security.SecurityException){
            filesErrors.Add("file_name",String.Format(Resources.strings.CCS_TempInsufficientPermissions,"{res:im_file_name}"));
        }
        filesfile_name.FileSizeLimit = 1000000;
        filesfile_name.Required = true;
        try{
            filesfile_name.Text = item.file_name.GetFormattedValue();
        }catch(System.IO.FileNotFoundException){
            filesErrors.Add("file_name",String.Format(Resources.strings.CCS_FileNotFound,item.file_name.GetFormattedValue(),"{res:im_file_name}"));
        }
        item.uploaded_byItems.SetSelection(item.uploaded_by.GetFormattedValue());
        filesuploaded_by.Items.Add(new ListItem(Resources.strings.CCS_SelectValue,""));
        filesuploaded_by.Items[0].Selected = true;
        if(item.uploaded_byItems.GetSelectedItem() != null)
            filesuploaded_by.SelectedIndex = -1;
        item.uploaded_byItems.CopyTo(filesuploaded_by.Items);
        filesdate_uploaded.Text=item.date_uploaded.GetFormattedValue();
        filesdate_format.Text=Server.HtmlEncode(item.date_format.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
//End Record Form files BeforeShow tail

//Link file Event BeforeShow. Action Get Original Filename @49-1290F3B6
            filesfile.InnerHtml = filesfile.InnerHtml.Remove(0, filesfile.InnerHtml.IndexOf(".") + 1);
//End Link file Event BeforeShow. Action Get Original Filename

//Label date_format Event BeforeShow. Action Print General Date Format @104-C746B608
            filesdate_format.Text = IMUtils.GetGeneralDateFormat();
//End Label date_format Event BeforeShow. Action Print General Date Format

//Record files Event BeforeShow. Action Custom Code @15-2A29BDB7
 // -------------------------
 IMUtils.SetupUpload(filesfile_name);
 filesfile.HRef = IMUtils.GetSetting("file_path") + "/" + filesfile.HRef;
 // -------------------------
//End Record files Event BeforeShow. Action Custom Code

//Record Form files Show method tail @3-358F1888
        if(filesErrors.Count>0)
            filesShowErrors();
    }
//End Record Form files Show method tail

//Record Form files LoadItemFromRequest method @3-E7217F8A
    protected void filesLoadItemFromRequest(filesItem item, bool EnableValidation)
    {
        try{
            filesfile_name.ValidateFile();
            item.file_name.SetValue(filesfile_name.Text);
        }catch(InvalidOperationException ex){
            if(ex.Message == "The file type is not allowed.")
                filesErrors.Add("file_name",String.Format(Resources.strings.CCS_WrongType,"{res:im_file_name}"));
            if(ex.Message == "The file is too large.")
                filesErrors.Add("file_name",String.Format(Resources.strings.CCS_LargeFile,"{res:im_file_name}"));
        }
        try{
        item.uploaded_by.SetValue(filesuploaded_by.Value);
        item.uploaded_byItems.CopyFrom(filesuploaded_by.Items);
        }catch(ArgumentException){
            filesErrors.Add("uploaded_by",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_uploaded_by));}
        try{
        item.date_uploaded.SetValue(filesdate_uploaded.Text);
        }catch(ArgumentException){
            filesErrors.Add("date_uploaded",String.Format(Resources.strings.CCS_IncorrectFormat,Resources.strings.im_date_uploaded,@"GeneralDate"));}
        if(EnableValidation)
            item.Validate(filesData);
        filesErrors.Add(item.errors);
    }
//End Record Form files LoadItemFromRequest method

//Record Form files GetRedirectUrl method @3-563691BB
    protected string GetfilesRedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "IssueMaint.aspx";
        string p = parameters.ToString("GET","file_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form files GetRedirectUrl method

//Record Form files ShowErrors method @3-6A44F9AD
    protected void filesShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<filesErrors.Count;i++)
        switch(filesErrors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=filesErrors[i];
                break;
        }
        filesError.Visible = true;
        filesErrorLabel.Text = DefaultMessage;
    }
//End Record Form files ShowErrors method

//Record Form files Insert Operation @3-4EAD6F10
    protected void files_Insert(object sender, System.EventArgs e)
    {
        filesIsSubmitted = true;
        bool ErrorFlag = false;
        filesItem item=new filesItem();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form files Insert Operation

//Record Form files BeforeInsert tail @3-10B319A1
    filesParameters();
    filesLoadItemFromRequest(item, EnableValidation);
//End Record Form files BeforeInsert tail

//Record Form files AfterInsert tail  @3-B733018E
        ErrorFlag=(filesErrors.Count>0);
        if(ErrorFlag)
            filesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form files AfterInsert tail 

//Record Form files Update Operation @3-99C87E6D
    protected void files_Update(object sender, System.EventArgs e)
    {
        filesItem item=new filesItem();
        item.IsNew = false;
        filesIsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form files Update Operation

//Button Update OnClick. @4-B9C1E46C
        if(((Control)sender).ID == "filesUpdate")
        {
            RedirectUrl  = GetfilesRedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @4-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form files Before Update tail @3-E99DBA4C
        filesParameters();
        filesLoadItemFromRequest(item, EnableValidation);
        if(filesOperations.AllowUpdate){
        ErrorFlag=(filesErrors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                filesData.UpdateItem(item);
            }
            catch (Exception ex)
            {
                filesErrors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form files Before Update tail

//Record Form files Update Operation tail @3-370A44D7
            if(!ErrorFlag)
                filesfile_name.SaveFile();
        }
        ErrorFlag=(filesErrors.Count>0);
        if(ErrorFlag)
            filesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form files Update Operation tail

//Record Form files Delete Operation @3-3AD3158D
    protected void files_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        filesIsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        filesItem item=new filesItem();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form files Delete Operation

//Button Delete OnClick. @5-6B04CD8E
        if(((Control)sender).ID == "filesDelete")
        {
            RedirectUrl  = GetfilesRedirectUrl("", "");
            EnableValidation  = false;
//End Button Delete OnClick.

//Button Delete OnClick tail. @5-FCB6E20C
        }
//End Button Delete OnClick tail.

//Record Form BeforeDelete tail @3-182CD025
        filesParameters();
        filesLoadItemFromRequest(item, EnableValidation);
        if(filesOperations.AllowDelete){
        ErrorFlag = (filesErrors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                filesData.DeleteItem(item);
            }
            catch (Exception ex)
            {
                filesErrors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record files Event AfterDelete. Action Custom Code @14-2A29BDB7
 // -------------------------
	System.IO.File.Delete(Server.MapPath(IMUtils.GetSetting("file_path")+"/"+item.file_name));
 // -------------------------
//End Record files Event AfterDelete. Action Custom Code

//Record Form AfterDelete tail @3-32B7C6E8
            if(!ErrorFlag)
                filesfile_name.DeleteFile();
        }
        if(ErrorFlag)
            filesShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form files Cancel Operation @3-CBCCBCEB
    protected void files_Cancel(object sender,System.EventArgs e)
    {
        filesItem item=new filesItem();
        filesIsSubmitted = true;
        string RedirectUrl = "";
        filesLoadItemFromRequest(item, false);
//End Record Form files Cancel Operation

//Button Cancel OnClick. @6-BE64B08F
    if(((Control)sender).ID == "filesCancel")
    {
        RedirectUrl  = GetfilesRedirectUrl("", "file_id");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @6-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form files Cancel Operation tail @3-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form files Cancel Operation tail

//FileUpload file_name Event BeforeProcessFile. Action Custom Code @16-27CC416E
 protected void filesfile_nameBeforeProcessFile(object sender, EventArgs e)
 {
 // -------------------------
 IMUtils.SetupUpload(filesfile_name);
 // -------------------------
 }
//End FileUpload file_name Event BeforeProcessFile. Action Custom Code

//OnInit Event @1-8F10E488
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        FileMaintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        filesData = new filesDataProvider();
        filesOperations = new FormSupportedOperations(false, true, false, true, true);
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

