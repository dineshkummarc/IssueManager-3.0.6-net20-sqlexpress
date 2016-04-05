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

namespace IssueManager.StatusList{ //Namespace @1-92D3D11E

//Forms Definition @1-5AE7BFE1
public partial class StatusListPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-0C1035EB
    protected statusesDataProvider statusesData;
    protected int statusesCurrentRowNumber;
    protected FormSupportedOperations statusesOperations;
    protected statuses1DataProvider statuses1Data;
    protected NameValueCollection statuses1Errors=new NameValueCollection();
    protected bool statuses1IsSubmitted = false;
    protected FormSupportedOperations statuses1Operations;
    protected System.Resources.ResourceManager rm;
    protected string StatusListContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-3B334966
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            statusesBind();
            statuses1Show();
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

//Grid statuses Bind @3-297F45B6
    protected void statusesBind()
    {
        if (!statusesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"statuses",typeof(statusesDataProvider.SortFields), 10, 100);
        }
//End Grid statuses Bind

//Grid Form statuses BeforeShow tail @3-8A907739
        statusesData.SortField = (statusesDataProvider.SortFields)ViewState["statusesSortField"];
        statusesData.SortDir = (SortDirections)ViewState["statusesSortDir"];
        statusesData.PageNumber = (int)ViewState["statusesPageNumber"];
        statusesData.RecordsPerPage = (int)ViewState["statusesPageSize"];
        statusesRepeater.DataSource = statusesData.GetResultSet(out PagesCount, statusesOperations);
        ViewState["statusesPagesCount"] = PagesCount;
        statusesRepeater.DataBind();
        FooterIndex = statusesRepeater.Controls.Count - 1;
        statusesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        statusesItem item=new statusesItem();
        System.Web.UI.HtmlControls.HtmlAnchor statusesLink1 = (System.Web.UI.HtmlControls.HtmlAnchor)statusesRepeater.Controls[FooterIndex].FindControl("statusesLink1");

        item.Link1Href = "StatusList.aspx";

        statusesLink1.InnerText=Resources.strings.im_add_new_status;
        statusesLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","status_id", ViewState);
        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)statusesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form statuses BeforeShow tail

//Grid statuses Bind tail @3-FCB6E20C
    }
//End Grid statuses Bind tail

//Grid statuses ItemDataBound event @3-F8352239
    protected void statusesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        statusesItem DataItem=(statusesItem)e.Item.DataItem;
        statusesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        statusesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor statusesstatus = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("statusesstatus"));
            System.Web.UI.WebControls.Literal statusesstatus_transl = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("statusesstatus_transl"));
            DataItem.statusHref = "StatusList.aspx";
            statusesstatus.HRef = DataItem.statusHref + DataItem.statusHrefParameters.ToString("GET","", ViewState);
        }
//End Grid statuses ItemDataBound event

//statuses control Before Show @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End statuses control Before Show

//Get Control @11-ECC88EF4
            System.Web.UI.WebControls.Literal statusesstatus_transl = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("statusesstatus_transl"));
//End Get Control

//Label status_transl Event BeforeShow. Action Custom Code @12-2A29BDB7
    // -------------------------
	statusesstatus_transl.Text = IMUtils.Translate(statusesstatus_transl.Text);
    // -------------------------
//End Label status_transl Event BeforeShow. Action Custom Code

//statuses control Before Show tail @3-FCB6E20C
        }
//End statuses control Before Show tail

//Grid statuses ItemDataBound event tail @3-FCB6E20C
    }
//End Grid statuses ItemDataBound event tail

//Grid statuses ItemCommand event @3-6C7E3509
    protected void statusesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = statusesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["statusesSortDir"]==SortDirections.Asc&&ViewState["statusesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["statusesSortDir"]=SortDirections.Desc;
                else
                    ViewState["statusesSortDir"]=SortDirections.Asc;
            else
                ViewState["statusesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["statusesSortField"]=Enum.Parse(typeof(statusesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["statusesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["statusesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            statusesBind();
    }
//End Grid statuses ItemCommand event

//Record Form statuses1 Parameters @48-394A6BBD
    protected void statuses1Parameters()
    {
        statuses1Item item=statuses1Item.CreateFromHttpRequest();
        try{
            statuses1Data.Urlstatus_id = IntegerParameter.GetParam(Request.QueryString["status_id"]);
        }catch(Exception e){
            statuses1Errors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form statuses1 Parameters

//Record Form statuses1 Show method @48-330649D4
    protected void statuses1Show()
    {
        if(statuses1Operations.None)
        {
            statuses1Holder.Visible=false;
            return;
        }
        statuses1Item item=statuses1Item.CreateFromHttpRequest();
        bool IsInsertMode=!statuses1Operations.AllowRead;
        statuses1Errors.Add(item.errors);
//End Record Form statuses1 Show method

//Record Form statuses1 BeforeShow tail @48-C388326B
        statuses1Parameters();
        statuses1Data.FillItem(item,ref IsInsertMode);
        statuses1Holder.DataBind();
        statuses1Insert.Visible=IsInsertMode&&statuses1Operations.AllowInsert;
        statuses1Update.Visible=!IsInsertMode&&statuses1Operations.AllowUpdate;
        statuses1Delete.Visible=!IsInsertMode&&statuses1Operations.AllowDelete;
        statuses1status.Text=item.status.GetFormattedValue();
        statuses1status_transl.Text=Server.HtmlEncode(item.status_transl.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
//End Record Form statuses1 BeforeShow tail

//Label status_transl Event BeforeShow. Action Custom Code @50-2A29BDB7
    // -------------------------
    statuses1status_transl.Text = IMUtils.Translate(statuses1status_transl.Text);
    // -------------------------
//End Label status_transl Event BeforeShow. Action Custom Code

//Record Form statuses1 Show method tail @48-F0E2EE57
        if(statuses1Errors.Count>0)
            statuses1ShowErrors();
    }
//End Record Form statuses1 Show method tail

//Record Form statuses1 LoadItemFromRequest method @48-068404E2
    protected void statuses1LoadItemFromRequest(statuses1Item item, bool EnableValidation)
    {
        item.status.SetValue(statuses1status.Text);
        if(EnableValidation)
            item.Validate(statuses1Data);
        statuses1Errors.Add(item.errors);
    }
//End Record Form statuses1 LoadItemFromRequest method

//Record Form statuses1 GetRedirectUrl method @48-835F0F8F
    protected string Getstatuses1RedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "StatusList.aspx";
        string p = parameters.ToString("None","status_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form statuses1 GetRedirectUrl method

//Record Form statuses1 ShowErrors method @48-F4854BEB
    protected void statuses1ShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<statuses1Errors.Count;i++)
        switch(statuses1Errors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=statuses1Errors[i];
                break;
        }
        statuses1Error.Visible = true;
        statuses1ErrorLabel.Text = DefaultMessage;
    }
//End Record Form statuses1 ShowErrors method

//Record Form statuses1 Insert Operation @48-6BA97233
    protected void statuses1_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        statuses1IsSubmitted = true;
        bool ErrorFlag = false;
        statuses1Item item=new statuses1Item();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form statuses1 Insert Operation

//Button Insert OnClick. @52-589DCA47
        if(((Control)sender).ID == "statuses1Insert")
        {
            RedirectUrl  = Getstatuses1RedirectUrl("", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @52-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record Form statuses1 BeforeInsert tail @48-10C8A52C
    statuses1Parameters();
    statuses1LoadItemFromRequest(item, EnableValidation);
    if(statuses1Operations.AllowInsert){
    ErrorFlag=(statuses1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                statuses1Data.InsertItem(item);
            }
            catch (Exception ex)
            {
                statuses1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form statuses1 BeforeInsert tail

//Record Form statuses1 AfterInsert tail  @48-5BD8CC8D
        }
        ErrorFlag=(statuses1Errors.Count>0);
        if(ErrorFlag)
            statuses1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form statuses1 AfterInsert tail 

//Record Form statuses1 Update Operation @48-19440746
    protected void statuses1_Update(object sender, System.EventArgs e)
    {
        statuses1Item item=new statuses1Item();
        item.IsNew = false;
        statuses1IsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form statuses1 Update Operation

//Button Update OnClick. @53-5FFC7578
        if(((Control)sender).ID == "statuses1Update")
        {
            RedirectUrl  = Getstatuses1RedirectUrl("", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @53-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form statuses1 Before Update tail @48-BCCF4611
        statuses1Parameters();
        statuses1LoadItemFromRequest(item, EnableValidation);
        if(statuses1Operations.AllowUpdate){
        ErrorFlag=(statuses1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                statuses1Data.UpdateItem(item);
            }
            catch (Exception ex)
            {
                statuses1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form statuses1 Before Update tail

//Record Form statuses1 Update Operation tail @48-5BD8CC8D
        }
        ErrorFlag=(statuses1Errors.Count>0);
        if(ErrorFlag)
            statuses1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form statuses1 Update Operation tail

//Record Form statuses1 Delete Operation @48-085E84A9
    protected void statuses1_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        statuses1IsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        statuses1Item item=new statuses1Item();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form statuses1 Delete Operation

//Button Delete OnClick. @54-19E382F3
        if(((Control)sender).ID == "statuses1Delete")
        {
            RedirectUrl  = Getstatuses1RedirectUrl("", "");
            EnableValidation  = false;
//End Button Delete OnClick.

//Button Delete OnClick tail. @54-FCB6E20C
        }
//End Button Delete OnClick tail.

//Record Form BeforeDelete tail @48-E3BBB597
        statuses1Parameters();
        statuses1LoadItemFromRequest(item, EnableValidation);
        if(statuses1Operations.AllowDelete){
        ErrorFlag = (statuses1Errors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                statuses1Data.DeleteItem(item);
            }
            catch (Exception ex)
            {
                statuses1Errors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @48-828C249B
        }
        if(ErrorFlag)
            statuses1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form statuses1 Cancel Operation @48-6D7EB802
    protected void statuses1_Cancel(object sender,System.EventArgs e)
    {
        statuses1Item item=new statuses1Item();
        statuses1IsSubmitted = true;
        string RedirectUrl = "";
        statuses1LoadItemFromRequest(item, false);
//End Record Form statuses1 Cancel Operation

//Button Cancel OnClick. @15-8E80C220
    if(((Control)sender).ID == "statuses1Cancel")
    {
        RedirectUrl  = Getstatuses1RedirectUrl("", "");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @15-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form statuses1 Cancel Operation tail @48-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form statuses1 Cancel Operation tail

//OnInit Event @1-32068113
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        StatusListContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        statusesData = new statusesDataProvider();
        statusesOperations = new FormSupportedOperations(false, true, false, false, false);
        statuses1Data = new statuses1DataProvider();
        statuses1Operations = new FormSupportedOperations(false, true, true, true, true);
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

