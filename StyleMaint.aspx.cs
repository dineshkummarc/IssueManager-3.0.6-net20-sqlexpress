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

namespace IssueManager.StyleMaint{ //Namespace @1-5E943A6C

//Forms Definition @1-2C12921F
public partial class StyleMaintPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-A1283A91
    protected stylesDataProvider stylesData;
    protected int stylesCurrentRowNumber;
    protected FormSupportedOperations stylesOperations;
    protected styles1DataProvider styles1Data;
    protected NameValueCollection styles1Errors=new NameValueCollection();
    protected bool styles1IsSubmitted = false;
    protected FormSupportedOperations styles1Operations;
    protected System.Resources.ResourceManager rm;
    protected string StyleMaintContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-A66E339A
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            stylesBind();
            styles1Show();
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

//Grid styles Bind @9-A62DCB82
    protected void stylesBind()
    {
        if (!stylesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"styles",typeof(stylesDataProvider.SortFields), 0, 100);
        }
//End Grid styles Bind

//Grid Form styles BeforeShow tail @9-0E33FC6C
        stylesData.SortField = (stylesDataProvider.SortFields)ViewState["stylesSortField"];
        stylesData.SortDir = (SortDirections)ViewState["stylesSortDir"];
        stylesData.PageNumber = (int)ViewState["stylesPageNumber"];
        stylesData.RecordsPerPage = (int)ViewState["stylesPageSize"];
        stylesRepeater.DataSource = stylesData.GetResultSet(out PagesCount, stylesOperations);
        ViewState["stylesPagesCount"] = PagesCount;
        stylesRepeater.DataBind();
        FooterIndex = stylesRepeater.Controls.Count - 1;
        stylesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        stylesItem item=new stylesItem();
        System.Web.UI.HtmlControls.HtmlAnchor stylesstyles_Insert = (System.Web.UI.HtmlControls.HtmlAnchor)stylesRepeater.Controls[FooterIndex].FindControl("stylesstyles_Insert");

        item.styles_InsertHref = "StyleMaint.aspx";

        stylesstyles_Insert.InnerText=Resources.strings.CCS_InsertLink;
        stylesstyles_Insert.HRef = item.styles_InsertHref+item.styles_InsertHrefParameters.ToString("GET","style_name", ViewState);
//End Grid Form styles BeforeShow tail

//Grid styles Bind tail @9-FCB6E20C
    }
//End Grid styles Bind tail

//Grid styles ItemDataBound event @9-2013990A
    protected void stylesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        stylesItem DataItem=(stylesItem)e.Item.DataItem;
        stylesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        stylesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor stylesstyle_name = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("stylesstyle_name"));
            DataItem.style_nameHref = "StyleMaint.aspx";
            stylesstyle_name.HRef = DataItem.style_nameHref + DataItem.style_nameHrefParameters.ToString("GET","", ViewState);
        }
//End Grid styles ItemDataBound event

//Grid styles ItemDataBound event tail @9-FCB6E20C
    }
//End Grid styles ItemDataBound event tail

//Grid styles ItemCommand event @9-F938CC23
    protected void stylesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = stylesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["stylesSortDir"]==SortDirections.Asc&&ViewState["stylesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["stylesSortDir"]=SortDirections.Desc;
                else
                    ViewState["stylesSortDir"]=SortDirections.Asc;
            else
                ViewState["stylesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["stylesSortField"]=Enum.Parse(typeof(stylesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["stylesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["stylesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            stylesBind();
    }
//End Grid styles ItemCommand event

//Record Form styles1 Parameters @14-DDB6A55B
    protected void styles1Parameters()
    {
        styles1Item item=styles1Item.CreateFromHttpRequest();
        try{
            styles1Data.Urlstyle_name = TextParameter.GetParam(Request.QueryString["style_name"]);
        }catch(Exception e){
            styles1Errors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form styles1 Parameters

//Record Form styles1 Show method @14-2C1D756E
    protected void styles1Show()
    {
        if(styles1Operations.None)
        {
            styles1Holder.Visible=false;
            return;
        }
        styles1Item item=styles1Item.CreateFromHttpRequest();
        bool IsInsertMode=!styles1Operations.AllowRead;
        styles1Errors.Add(item.errors);
//End Record Form styles1 Show method

//Record Form styles1 BeforeShow tail @14-F2720B8E
        styles1Parameters();
        styles1Data.FillItem(item,ref IsInsertMode);
        styles1Holder.DataBind();
        styles1Button_Insert.Visible=IsInsertMode&&styles1Operations.AllowInsert;
        styles1Button_Update.Visible=!IsInsertMode&&styles1Operations.AllowUpdate;
        styles1Button_Delete.Visible=!IsInsertMode&&styles1Operations.AllowDelete;
        styles1style_name.Text=item.style_name.GetFormattedValue();
//End Record Form styles1 BeforeShow tail

//Record Form styles1 Show method tail @14-0CBC19BC
        if(styles1Errors.Count>0)
            styles1ShowErrors();
    }
//End Record Form styles1 Show method tail

//Record Form styles1 LoadItemFromRequest method @14-5146B8E1
    protected void styles1LoadItemFromRequest(styles1Item item, bool EnableValidation)
    {
        item.style_name.SetValue(styles1style_name.Text);
        if(EnableValidation)
            item.Validate(styles1Data);
        styles1Errors.Add(item.errors);
    }
//End Record Form styles1 LoadItemFromRequest method

//Record Form styles1 GetRedirectUrl method @14-C5661D3C
    protected string Getstyles1RedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "StyleMaint.aspx";
        string p = parameters.ToString("GET","style_name;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form styles1 GetRedirectUrl method

//Record Form styles1 ShowErrors method @14-1D801E08
    protected void styles1ShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<styles1Errors.Count;i++)
        switch(styles1Errors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=styles1Errors[i];
                break;
        }
        styles1Error.Visible = true;
        styles1ErrorLabel.Text = DefaultMessage;
    }
//End Record Form styles1 ShowErrors method

//Record Form styles1 Insert Operation @14-031B0907
    protected void styles1_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        styles1IsSubmitted = true;
        bool ErrorFlag = false;
        styles1Item item=new styles1Item();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form styles1 Insert Operation

//Button Button_Insert OnClick. @15-E39C22DF
        if(((Control)sender).ID == "styles1Button_Insert")
        {
            RedirectUrl  = Getstyles1RedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Insert OnClick.

//Button Button_Insert OnClick tail. @15-FCB6E20C
        }
//End Button Button_Insert OnClick tail.

//Record Form styles1 BeforeInsert tail @14-D88F6E26
    styles1Parameters();
    styles1LoadItemFromRequest(item, EnableValidation);
    if(styles1Operations.AllowInsert){
    ErrorFlag=(styles1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                styles1Data.InsertItem(item);
            }
            catch (Exception ex)
            {
                styles1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form styles1 BeforeInsert tail

//Record Form styles1 AfterInsert tail  @14-34BE803F
        }
        ErrorFlag=(styles1Errors.Count>0);
        if(ErrorFlag)
            styles1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form styles1 AfterInsert tail 

//Record Form styles1 Update Operation @14-879A8E23
    protected void styles1_Update(object sender, System.EventArgs e)
    {
        styles1Item item=new styles1Item();
        item.IsNew = false;
        styles1IsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form styles1 Update Operation

//Button Button_Update OnClick. @16-2EA11E14
        if(((Control)sender).ID == "styles1Button_Update")
        {
            RedirectUrl  = Getstyles1RedirectUrl("", "");
            EnableValidation  = true;
//End Button Button_Update OnClick.

//Button Button_Update OnClick tail. @16-FCB6E20C
        }
//End Button Button_Update OnClick tail.

//Record Form styles1 Before Update tail @14-798F90B7
        styles1Parameters();
        styles1LoadItemFromRequest(item, EnableValidation);
        if(styles1Operations.AllowUpdate){
        ErrorFlag=(styles1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                styles1Data.UpdateItem(item);
            }
            catch (Exception ex)
            {
                styles1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form styles1 Before Update tail

//Record Form styles1 Update Operation tail @14-34BE803F
        }
        ErrorFlag=(styles1Errors.Count>0);
        if(ErrorFlag)
            styles1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form styles1 Update Operation tail

//Record Form styles1 Delete Operation @14-8DF0C22F
    protected void styles1_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        styles1IsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        styles1Item item=new styles1Item();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form styles1 Delete Operation

//Button Button_Delete OnClick. @17-C8ED2483
        if(((Control)sender).ID == "styles1Button_Delete")
        {
            RedirectUrl  = Getstyles1RedirectUrl("", "");
            EnableValidation  = false;
//End Button Button_Delete OnClick.

//Button Button_Delete OnClick tail. @17-FCB6E20C
        }
//End Button Button_Delete OnClick tail.

//Record Form BeforeDelete tail @14-85CF4418
        styles1Parameters();
        styles1LoadItemFromRequest(item, EnableValidation);
        if(styles1Operations.AllowDelete){
        ErrorFlag = (styles1Errors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                styles1Data.DeleteItem(item);
            }
            catch (Exception ex)
            {
                styles1Errors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @14-706C2DFD
        }
        if(ErrorFlag)
            styles1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form styles1 Cancel Operation @14-AB279F13
    protected void styles1_Cancel(object sender,System.EventArgs e)
    {
        styles1Item item=new styles1Item();
        styles1IsSubmitted = true;
        string RedirectUrl = "";
        styles1LoadItemFromRequest(item, true);
//End Record Form styles1 Cancel Operation

//Record Form styles1 Cancel Operation tail @14-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form styles1 Cancel Operation tail

//OnInit Event @1-3C76C53A
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        StyleMaintContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        stylesData = new stylesDataProvider();
        stylesOperations = new FormSupportedOperations(false, true, false, false, false);
        styles1Data = new styles1DataProvider();
        styles1Operations = new FormSupportedOperations(false, true, true, true, true);
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

