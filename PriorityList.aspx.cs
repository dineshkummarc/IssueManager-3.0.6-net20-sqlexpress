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

namespace IssueManager.PriorityList{ //Namespace @1-41E343AA

//Forms Definition @1-A388E012
public partial class PriorityListPage : System.Web.UI.Page
{
//End Forms Definition

//Forms Objects @1-4D540A05
    protected prioritiesDataProvider prioritiesData;
    protected int prioritiesCurrentRowNumber;
    protected FormSupportedOperations prioritiesOperations;
    protected priorities1DataProvider priorities1Data;
    protected NameValueCollection priorities1Errors=new NameValueCollection();
    protected bool priorities1IsSubmitted = false;
    protected FormSupportedOperations priorities1Operations;
    protected System.Resources.ResourceManager rm;
    protected string PriorityListContentMeta;
    protected string PageStyleName;
    protected NameValueCollection PageVariables = new NameValueCollection();
//End Forms Objects

//Page_Load Event @1-55207E05
private void Page_Load(object sender, System.EventArgs e)
{
//End Page_Load Event

//Page_Load Event BeforeIsPostBack @1-95192309
    PageItem item=PageItem.CreateFromHttpRequest();
    if (!IsPostBack)
    {
            PageDataProvider PageData=new PageDataProvider();
            PageData.FillItem(item);
            prioritiesBind();
            priorities1Show();
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

//Grid priorities Bind @3-E91633A1
    protected void prioritiesBind()
    {
        if (!prioritiesOperations.AllowRead) return;
        int PagesCount;
        int FooterIndex;
        if (!IsPostBack)
        {
            DBUtility.InitializeGridParameters(ViewState,"priorities",typeof(prioritiesDataProvider.SortFields), 10, 100);
        }
//End Grid priorities Bind

//Grid Form priorities BeforeShow tail @3-42CFA8C9
        prioritiesData.SortField = (prioritiesDataProvider.SortFields)ViewState["prioritiesSortField"];
        prioritiesData.SortDir = (SortDirections)ViewState["prioritiesSortDir"];
        prioritiesData.PageNumber = (int)ViewState["prioritiesPageNumber"];
        prioritiesData.RecordsPerPage = (int)ViewState["prioritiesPageSize"];
        prioritiesRepeater.DataSource = prioritiesData.GetResultSet(out PagesCount, prioritiesOperations);
        ViewState["prioritiesPagesCount"] = PagesCount;
        prioritiesRepeater.DataBind();
        FooterIndex = prioritiesRepeater.Controls.Count - 1;
        prioritiesRepeater.Controls[FooterIndex].FindControl("NoRecords").Visible = PagesCount == 0;
        prioritiesItem item=new prioritiesItem();
        System.Web.UI.HtmlControls.HtmlAnchor prioritiesLink1 = (System.Web.UI.HtmlControls.HtmlAnchor)prioritiesRepeater.Controls[FooterIndex].FindControl("prioritiesLink1");

        item.Link1Href = "PriorityList.aspx";

        prioritiesLink1.InnerText=Resources.strings.im_add_new_priority;
        prioritiesLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","priority_id", ViewState);
        IssueManager.Controls.Navigator NavigatorNavigator = (IssueManager.Controls.Navigator)prioritiesRepeater.Controls[FooterIndex].FindControl("NavigatorNavigator");
//End Grid Form priorities BeforeShow tail

//Grid priorities Bind tail @3-FCB6E20C
    }
//End Grid priorities Bind tail

//Grid priorities ItemDataBound event @3-1C14D680
    protected void prioritiesItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        prioritiesItem DataItem=(prioritiesItem)e.Item.DataItem;
        prioritiesItem item = DataItem;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        prioritiesCurrentRowNumber ++;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            System.Web.UI.HtmlControls.HtmlAnchor prioritiespriority_desc = (System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("prioritiespriority_desc"));
            System.Web.UI.WebControls.Literal prioritiespriority_transl = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("prioritiespriority_transl"));
            System.Web.UI.WebControls.Literal prioritiespriority_color = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("prioritiespriority_color"));
            System.Web.UI.WebControls.Literal prioritiespriority_order = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("prioritiespriority_order"));
            DataItem.priority_descHref = "PriorityList.aspx";
            prioritiespriority_desc.HRef = DataItem.priority_descHref + DataItem.priority_descHrefParameters.ToString("GET","", ViewState);
        }
//End Grid priorities ItemDataBound event

//Grid priorities BeforeShowRow event @3-77E330BC
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//End Grid priorities BeforeShowRow event

//Grid priorities Event BeforeShowRow. Action Custom Code @16-2A29BDB7
    // -------------------------
	System.Web.UI.WebControls.Literal prioritiespriority_transl = (System.Web.UI.WebControls.Literal)(e.Item.FindControl("prioritiespriority_transl"));
	prioritiespriority_transl.Text = IMUtils.Translate(prioritiespriority_transl.Text);
    // -------------------------
//End Grid priorities Event BeforeShowRow. Action Custom Code

//Grid priorities BeforeShowRow event tail @3-FCB6E20C
        }
//End Grid priorities BeforeShowRow event tail

//Grid priorities ItemDataBound event tail @3-FCB6E20C
    }
//End Grid priorities ItemDataBound event tail

//Grid priorities ItemCommand event @3-4914B621
    protected void prioritiesItemCommand(Object Sender, RepeaterCommandEventArgs e)
    {
        int FooterIndex = prioritiesRepeater.Controls.Count - 1;
        bool BindAllowed = false;
        if(e.CommandName=="Sort"){
            if(((SorterState)e.CommandArgument)==SorterState.None)
                if((SortDirections)ViewState["prioritiesSortDir"]==SortDirections.Asc&&ViewState["prioritiesSortField"].ToString()==((IssueManager.Controls.Sorter)e.CommandSource).Field)
                    ViewState["prioritiesSortDir"]=SortDirections.Desc;
                else
                    ViewState["prioritiesSortDir"]=SortDirections.Asc;
            else
                ViewState["prioritiesSortDir"]=(int)(((IssueManager.Controls.Sorter)e.CommandSource).State);
            ViewState["prioritiesSortField"]=Enum.Parse(typeof(prioritiesDataProvider.SortFields),((IssueManager.Controls.Sorter)e.CommandSource).Field);
            ViewState["prioritiesPageNumber"] = 1;
            BindAllowed = true;
        }
        if(e.CommandName=="Navigate"){
            ViewState["prioritiesPageNumber"] = Int32.Parse(e.CommandArgument.ToString());
            BindAllowed = true;
        }
        if (BindAllowed)
            prioritiesBind();
    }
//End Grid priorities ItemCommand event

//Record Form priorities1 Parameters @48-64FEB1FC
    protected void priorities1Parameters()
    {
        priorities1Item item=priorities1Item.CreateFromHttpRequest();
        try{
            priorities1Data.Urlpriority_id = IntegerParameter.GetParam(Request.QueryString["priority_id"]);
        }catch(Exception e){
            priorities1Errors.Add("Parameters","Form parameters: " + e.Message);
        }
    }
//End Record Form priorities1 Parameters

//Record Form priorities1 Show method @48-389E4300
    protected void priorities1Show()
    {
        if(priorities1Operations.None)
        {
            priorities1Holder.Visible=false;
            return;
        }
        priorities1Item item=priorities1Item.CreateFromHttpRequest();
        bool IsInsertMode=!priorities1Operations.AllowRead;
        priorities1Errors.Add(item.errors);
//End Record Form priorities1 Show method

//Record Form priorities1 BeforeShow tail @48-350239AD
        priorities1Parameters();
        priorities1Data.FillItem(item,ref IsInsertMode);
        priorities1Holder.DataBind();
        priorities1Insert.Visible=IsInsertMode&&priorities1Operations.AllowInsert;
        priorities1Update.Visible=!IsInsertMode&&priorities1Operations.AllowUpdate;
        priorities1Delete.Visible=!IsInsertMode&&priorities1Operations.AllowDelete;
        priorities1priority_desc.Text=item.priority_desc.GetFormattedValue();
        priorities1priority_transl.Text=Server.HtmlEncode(item.priority_transl.GetFormattedValue()).Replace("\r","").Replace("\n","<br>");
        priorities1priority_color.Text=item.priority_color.GetFormattedValue();
        priorities1priority_order.Text=item.priority_order.GetFormattedValue();
//End Record Form priorities1 BeforeShow tail

//Record priorities1 Event BeforeShow. Action Custom Code @57-2A29BDB7
    // -------------------------
	priorities1priority_transl.Text = IMUtils.Translate(priorities1priority_transl.Text);
    // -------------------------
//End Record priorities1 Event BeforeShow. Action Custom Code

//Record Form priorities1 Show method tail @48-9F8BB810
        if(priorities1Errors.Count>0)
            priorities1ShowErrors();
    }
//End Record Form priorities1 Show method tail

//Record Form priorities1 LoadItemFromRequest method @48-EF553038
    protected void priorities1LoadItemFromRequest(priorities1Item item, bool EnableValidation)
    {
        item.priority_desc.SetValue(priorities1priority_desc.Text);
        item.priority_color.SetValue(priorities1priority_color.Text);
        try{
        item.priority_order.SetValue(priorities1priority_order.Text);
        }catch(ArgumentException){
            priorities1Errors.Add("priority_order",String.Format(Resources.strings.CCS_IncorrectValue,Resources.strings.im_order));}
        if(EnableValidation)
            item.Validate(priorities1Data);
        priorities1Errors.Add(item.errors);
    }
//End Record Form priorities1 LoadItemFromRequest method

//Record Form priorities1 GetRedirectUrl method @48-0CAF0877
    protected string Getpriorities1RedirectUrl(string redirectString ,string removeList)
    {
        LinkParameterCollection parameters = new LinkParameterCollection();
        if(redirectString == "") redirectString = "PriorityList.aspx";
        string p = parameters.ToString("None","priority_id;" + removeList,ViewState);
        if(p == "") p="?";
        return redirectString + p;
    }

//End Record Form priorities1 GetRedirectUrl method

//Record Form priorities1 ShowErrors method @48-1DDCFBD9
    protected void priorities1ShowErrors()
    {
        string DefaultMessage="";
        for(int i=0;i<priorities1Errors.Count;i++)
        switch(priorities1Errors.AllKeys[i])
        {
            default:
                if(DefaultMessage != "") DefaultMessage += "<br>";
                DefaultMessage+=priorities1Errors[i];
                break;
        }
        priorities1Error.Visible = true;
        priorities1ErrorLabel.Text = DefaultMessage;
    }
//End Record Form priorities1 ShowErrors method

//Record Form priorities1 Insert Operation @48-635AFC4F
    protected void priorities1_Insert(object sender, System.EventArgs e)
    {
        bool ExecuteFlag = true;
        priorities1IsSubmitted = true;
        bool ErrorFlag = false;
        priorities1Item item=new priorities1Item();
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form priorities1 Insert Operation

//Button Insert OnClick. @53-FDE34496
        if(((Control)sender).ID == "priorities1Insert")
        {
            RedirectUrl  = Getpriorities1RedirectUrl("PriorityList.aspx", "");
            EnableValidation  = true;
//End Button Insert OnClick.

//Button Insert OnClick tail. @53-FCB6E20C
        }
//End Button Insert OnClick tail.

//Record Form priorities1 BeforeInsert tail @48-B69FFE6E
    priorities1Parameters();
    priorities1LoadItemFromRequest(item, EnableValidation);
    if(priorities1Operations.AllowInsert){
    ErrorFlag=(priorities1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                priorities1Data.InsertItem(item);
            }
            catch (Exception ex)
            {
                priorities1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form priorities1 BeforeInsert tail

//Record Form priorities1 AfterInsert tail  @48-063CD0FC
        }
        ErrorFlag=(priorities1Errors.Count>0);
        if(ErrorFlag)
            priorities1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form priorities1 AfterInsert tail 

//Record Form priorities1 Update Operation @48-BDDBD79E
    protected void priorities1_Update(object sender, System.EventArgs e)
    {
        priorities1Item item=new priorities1Item();
        item.IsNew = false;
        priorities1IsSubmitted = true;
        bool ExecuteFlag = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
//End Record Form priorities1 Update Operation

//Button Update OnClick. @54-A9F15DBF
        if(((Control)sender).ID == "priorities1Update")
        {
            RedirectUrl  = Getpriorities1RedirectUrl("PriorityList.aspx", "");
            EnableValidation  = true;
//End Button Update OnClick.

//Button Update OnClick tail. @54-FCB6E20C
        }
//End Button Update OnClick tail.

//Record Form priorities1 Before Update tail @48-E57DDF19
        priorities1Parameters();
        priorities1LoadItemFromRequest(item, EnableValidation);
        if(priorities1Operations.AllowUpdate){
        ErrorFlag=(priorities1Errors.Count>0);
        if(ExecuteFlag&&!ErrorFlag)
            try
            {
                priorities1Data.UpdateItem(item);
            }
            catch (Exception ex)
            {
                priorities1Errors.Add("DataProvider",ex.Message);
                ErrorFlag=true;
            }
//End Record Form priorities1 Before Update tail

//Record Form priorities1 Update Operation tail @48-063CD0FC
        }
        ErrorFlag=(priorities1Errors.Count>0);
        if(ErrorFlag)
            priorities1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form priorities1 Update Operation tail

//Record Form priorities1 Delete Operation @48-D1D64E46
    protected void priorities1_Delete(object sender,System.EventArgs e)
    {
        bool ExecuteFlag = true;
        priorities1IsSubmitted = true;
        bool ErrorFlag = false;
        string RedirectUrl = "";
        bool EnableValidation = false;
        priorities1Item item=new priorities1Item();
        item.IsNew = false;
        item.IsDeleted = true;
//End Record Form priorities1 Delete Operation

//Button Delete OnClick. @55-37ECC910
        if(((Control)sender).ID == "priorities1Delete")
        {
            RedirectUrl  = Getpriorities1RedirectUrl("PriorityList.aspx", "");
            EnableValidation  = false;
//End Button Delete OnClick.

//Button Delete OnClick tail. @55-FCB6E20C
        }
//End Button Delete OnClick tail.

//Record Form BeforeDelete tail @48-46ADFA4E
        priorities1Parameters();
        priorities1LoadItemFromRequest(item, EnableValidation);
        if(priorities1Operations.AllowDelete){
        ErrorFlag = (priorities1Errors.Count > 0);
        if(ExecuteFlag && !ErrorFlag)
            try
            {
                priorities1Data.DeleteItem(item);
            }
            catch (Exception ex)
            {
                priorities1Errors.Add("DataProvider", ex.Message);
                ErrorFlag = true;
            }
//End Record Form BeforeDelete tail

//Record Form AfterDelete tail @48-A0ED7CB9
        }
        if(ErrorFlag)
            priorities1ShowErrors();
        else
            Response.Redirect(RedirectUrl);
    }
//End Record Form AfterDelete tail

//Record Form priorities1 Cancel Operation @48-5D72BB39
    protected void priorities1_Cancel(object sender,System.EventArgs e)
    {
        priorities1Item item=new priorities1Item();
        priorities1IsSubmitted = true;
        string RedirectUrl = "";
        priorities1LoadItemFromRequest(item, false);
//End Record Form priorities1 Cancel Operation

//Button Cancel OnClick. @56-5716FE7D
    if(((Control)sender).ID == "priorities1Cancel")
    {
        RedirectUrl  = Getpriorities1RedirectUrl("", "");
//End Button Cancel OnClick.

//Button Cancel OnClick tail. @56-FCB6E20C
    }
//End Button Cancel OnClick tail.

//Record Form priorities1 Cancel Operation tail @48-AE897FBA
        Response.Redirect(RedirectUrl);
    }
//End Record Form priorities1 Cancel Operation tail

//OnInit Event @1-63C42A09
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        rm = (System.Resources.ResourceManager)Application["rm"];
        Utility.SetThreadCulture();
        PageStyleName = Utility.GetPageStyle();
        if(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding != null)
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding);
        PriorityListContentMeta = "text/html; charset=" +  ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).Encoding;
        if(Application[Request.PhysicalPath] == null)
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName);
        InitializeComponent();
        this.Load += new System.EventHandler(this.Page_Load);
        this.Unload += new System.EventHandler(this.Page_Unload);
        base.OnInit(e);
        prioritiesData = new prioritiesDataProvider();
        prioritiesOperations = new FormSupportedOperations(false, true, false, false, false);
        priorities1Data = new priorities1DataProvider();
        priorities1Operations = new FormSupportedOperations(false, true, true, true, true);
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

