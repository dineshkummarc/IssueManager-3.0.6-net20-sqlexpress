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

namespace IssueManager.LangMaint{ //Namespace @1-0E853FC8

//Forms Definition @1-33574EC2
public partial class LangMaintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-1357C654
    protected localesDataProvider localesData;
    protected int localesCurrentRowNumber;
    protected FormSupportedOperations localesOperations;
    protected locales1DataProvider locales1Data;
    protected NameValueCollection locales1Errors=new NameValueCollection();
    protected bool locales1IsSubmitted = false;
    protected FormSupportedOperations locales1Operations;
    protected System.Resources.ResourceManager rm;
    protected string LangMaintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-82BF7F61
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            localesBind();
            locales1Show();
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

//Grid locales Bind @2-E4A712D4
    protected void localesBind()
    {
        if (!localesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"locales",typeof(localesDataProvider.SortFields), 0, 100);
        }
//End Grid locales Bind

//Grid Form locales BeforeShow tail @2-B9C25E47
        localesData.SortField = (localesDataProvider.SortFields)ViewState["localesSortField"];
        localesData.SortDir = (SortDirections)ViewState["localesSortDir"];
        localesData.PageNumber = (int)ViewState["localesPageNumber"];
        localesData.RecordsPerPage = (int)ViewState["localesPageSize"];
        localesRepeater.DataSource = localesData.GetResultSet(out PagesCount, localesOperations);
        ViewState["localesPagesCount"] = PagesCount;
        localesRepeater.DataBind();
        FooterIndex = localesRepeater.Controls.Count - 1;
        localesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        localesItem item=new localesItem();
        System.Web.UI.HtmlControls.HtmlAnchor localeslocales_Insert = (System.Web.UI.HtmlControls.HtmlAnchor)localesRepeater.Controls[FooterIndex].FindControl("localeslocales_Insert");

        item.locales_InsertHref = "LangMaint.aspx";

        localeslocales_Insert.InnerText=Resources.strings.CCS_InsertLink;
        localeslocales_Insert.HRef = item.locales_InsertHref+item.locales_InsertHrefParameters.ToString("GET","locale_name", ViewState);
//End Grid Form locales BeforeShow tail

//Grid locales Bind tail @2-FCB6E20C
    }
//End Grid locales Bind tail

//Grid locales ItemDataBound event @2-08C431ED
    protected void localesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        localesItem DataItem=(localesItem)e.Item.DataItem;
        localesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        localesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor localeslocale_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("localeslocale_name"));
            DataItem.locale_nameHref = "LangMaint.aspx";
            localeslocale_name.HRef = DataItem.locale_nameHref + DataItem.locale_nameHrefParameters.ToString("GET","", ViewState);
        }
//End Grid locales ItemDataBound event

//Grid locales ItemDataBound event tail @2-FCB6E20C
    }
//End Grid locales ItemDataBound event tail

//Grid locales ItemCommand event @2-0825803F
    protected void localesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = localesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["localesSortDir"]==SortDirections.Asc&&ViewState["localesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["localesSortDir"]=SortDirections.Desc;
                else
                    ViewState["localesSortDir"]=SortDirections.Asc;
            else
                ViewState["localesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["localesSortField"]=Enum.Parse(typeof(localesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["localesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["localesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            localesBind();
    }
//End Grid locales ItemCommand event

//Record Form locales1 Parameters @7-0E580167
    protected void locales1Parameters()
    {
        locales1Item item=locales1Item.CreateFromHttpRequest();
        try{
            locales1Data.Urllocale_name = TextParameter.GetParam(Request.QueryString["locale_name"]);
        }catch(Exception e){
            locales1Errors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form locales1 Parameters

//Record Form locales1 Show method @7-5A090107
    protected void locales1Show()
    {
        if(locales1Operations.None)
        {
            locales1Holder.Visible=false;
            return;
        }
        locales1Item item=locales1Item.CreateFromHttpRequest();
        bool IsInsertMode=!locales1Operations.AllowRead;
        locales1Errors.Add(item.errors);
//End Record Form locales1 Show method

//Record Form locales1 BeforeShow tail @7-D2533ABC
        locales1Parameters();
        locales1Data.FillItem(item,ref IsInsertMode);
        locales1Holder.DataBind();
        locales1Button_Insert.Visible=IsInsertMode&&locales1Operations.AllowInsert;
        locales1Button_Update.Visible=!IsInsertMode&&locales1Operations.AllowUpdate;
        locales1Button_Delete.Visible=!IsInsertMode&&locales1Operations.AllowDelete;
        locales1locale_name.Text=item.locale_name.GetFormattedValue();
//End Record Form locales1 BeforeShow tail

//Record Form locales1 Show method tail @7-A75C7B6D
        if(locales1Errors.Count>0)
            locales1ShowErrors();
    }
//End Record Form locales1 Show method tail

//Record Form locales1 LoadItemFromRequest method @7-041A07D9
    protected void locales1LoadItemFromRequest(locales1Item item, bool EnableValidation)
    {
        item.locale_name.SetValue(locales1locale_name.Text);
        if(EnableValidation)
            item.Validate(locales1Data);
        locales1Errors.Add(item.errors);
    }
//End Record Form locales1 LoadItemFromRequest method

//Record Form locales1 GetRedirectUrl method @7-39A9F123
    protected string Getlocales1RedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "LangMaint.aspx";
        string p = parameters.ToString("GET","locale_name;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form locales1 GetRedirectUrl method

//Record Form locales1 ShowErrors method @7-9EAF8D55
    protected void locales1ShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<locales1Errors.Count;i++)
        switch(locales1Errors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=locales1Errors[i];
                break;
        }
        locales1Error.Visible = true;
        locales1ErrorLabel.Text = DefaultMessage;
    }
//End Record Form locales1 ShowErrors method

//Record Form locales1 Insert Operation @7-10856AC8
    protected void locales1_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        locales1IsSubmitted = true;
        bool ErrorFlag = false;
        locales1Item item=new locales1Item();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form locales1 Insert Operation

//Button Button_Insert OnClick. @8-0A51F416
        if(((Control)sender).ID == "locales1Button_Insert")
        {
            RedirectUrl  = Getlocales1RedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert OnClick tail. @8-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record Form locales1 BeforeInsert tail @7-E0FA3C46
    locales1Parameters();
    locales1LoadItemFromRequest(item, EnableValidation);
    if(locales1Operations.AllowInsert){
    ErrorFlag=(locales1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                locales1Data.InsertItem(item);
            }
            catch (Exception ex)
            {
                locales1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form locales1 BeforeInsert tail

//Record Form locales1 AfterInsert tail  @7-DB74C89E
        }
        ErrorFlag=(locales1Errors.Count>0);
        if(ErrorFlag)
            locales1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form locales1 AfterInsert tail 

//Record Form locales1 Update Operation @7-95CEE467
    protected void locales1_Update(object sender, System.EventArgs e)
    {
        locales1Item item=new locales1Item();
        item.IsNew = false;
        locales1IsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form locales1 Update Operation

//Button Button_Update OnClick. @9-062AD212
        if(((Control)sender).ID == "locales1Button_Update")
        {
            RedirectUrl  = Getlocales1RedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @9-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form locales1 Before Update tail @7-DD10F09D
        locales1Parameters();
        locales1LoadItemFromRequest(item, EnableValidation);
        if(locales1Operations.AllowUpdate){
        ErrorFlag=(locales1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                locales1Data.UpdateItem(item);
            }
            catch (Exception ex)
            {
                locales1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form locales1 Before Update tail

//Record Form locales1 Update Operation tail @7-DB74C89E
        }
        ErrorFlag=(locales1Errors.Count>0);
        if(ErrorFlag)
            locales1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form locales1 Update Operation tail

//Record Form locales1 Delete Operation @7-65E1938A
    protected void locales1_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        locales1IsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        locales1Item item=new locales1Item();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form locales1 Delete Operation

//Button Button_Delete OnClick. @10-EC784E47
        if(((Control)sender).ID == "locales1Button_Delete")
        {
            RedirectUrl  = Getlocales1RedirectUrl("", "");
            EnableValidation  = false;
//End Button Button_Delete OnClick.

//Button Button_Delete OnClick tail. @10-FCB6E20C
        }
//End Button Button_Delete OnClick tail.

//Record Form BeforeDelete tail @7-1BEAA114
        locales1Parameters();
        locales1LoadItemFromRequest(item, EnableValidation);
        if(locales1Operations.AllowDelete){
        ErrorFlag = (locales1Errors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                locales1Data.DeleteItem(item);
            }
            catch (Exception ex)
            {
                locales1Errors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @7-35C47C2E
        }
        if(ErrorFlag)
            locales1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form locales1 Cancel Operation @7-BE1DD51F
    protected void locales1_Cancel(object sender,System.EventArgs e)
    {
        locales1Item item=new locales1Item();
        locales1IsSubmitted = true;
        string RedirectUrl = "";
        locales1LoadItemFromRequest(item, true);
//End Record Form locales1 Cancel Operation

//Record Form locales1 Cancel Operation tail @7-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form locales1 Cancel Operation tail

//OnInit Event @1-5357AE35
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        LangMaintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        localesData = new localesDataProvider();
        localesOperations = new FormSupportedOperations(false, true, false, false, false);
        locales1Data = new locales1DataProvider();
        locales1Operations = new FormSupportedOperations(false, true, true, true, true);
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

