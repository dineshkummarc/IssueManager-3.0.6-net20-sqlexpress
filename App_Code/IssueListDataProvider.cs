//Using Statements @1-D5139E01
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using IssueManager;
using IssueManager.Data;
using IssueManager.Controls;
using IssueManager.Security;
using IssueManager.Configuration;

//End Using Statements

namespace IssueManager.IssueList{ //Namespace @1-BB356BAB

//Page Data Class @1-3FCDCDA8
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public PageItem()
    {
    }
}
//End Page Data Class

//Page Data Provider Class @1-50FE4D41
public class PageDataProvider
{
//End Page Data Provider Class

//Page Data Provider Class Constructor @1-9A44B219
    public PageDataProvider()
    {
    }
//End Page Data Provider Class Constructor

//Page Data Provider Class GetResultSet Method @1-052161C6
    public void FillItem(PageItem item)
    {
//End Page Data Provider Class GetResultSet Method

//Page Data Provider Class GetResultSet Method tail @1-FCB6E20C
    }
//End Page Data Provider Class GetResultSet Method tail

//Page Data Provider class Tail @1-FCB6E20C
}
//End Page Data Provider class Tail

//Record issuesSearch Item Class @4-1054B37B
public class issuesSearchItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField s_issue_name;
    public IntegerField s_priority_id;
    public ItemCollection s_priority_idItems;
    public IntegerField s_status_id;
    public ItemCollection s_status_idItems;
    public TextField s_notstatus_id;
    public ItemCollection s_notstatus_idItems;
    public IntegerField s_assigned_to;
    public ItemCollection s_assigned_toItems;
    public NameValueCollection errors=new NameValueCollection();
    public issuesSearchItem()
    {
        s_issue_name=new TextField("", null);
        s_priority_id = new IntegerField("", null);
        s_priority_idItems = new ItemCollection();
        s_status_id = new IntegerField("", null);
        s_status_idItems = new ItemCollection();
        s_notstatus_id = new TextField("", null);
        s_notstatus_idItems = new ItemCollection();
        s_assigned_to = new IntegerField("", null);
        s_assigned_toItems = new ItemCollection();
    }

    public static issuesSearchItem CreateFromHttpRequest()
    {
        issuesSearchItem item = new issuesSearchItem();
        if(DBUtility.GetInitialValue("s_issue_name") != null){
        item.s_issue_name.SetValue(DBUtility.GetInitialValue("s_issue_name"));
        }
        if(DBUtility.GetInitialValue("s_priority_id") != null){
        item.s_priority_id.SetValue(DBUtility.GetInitialValue("s_priority_id"));
        }
        if(DBUtility.GetInitialValue("s_status_id") != null){
        item.s_status_id.SetValue(DBUtility.GetInitialValue("s_status_id"));
        }
        if(DBUtility.GetInitialValue("s_notstatus_id") != null){
        item.s_notstatus_id.SetValue(DBUtility.GetInitialValue("s_notstatus_id"));
        }
        if(DBUtility.GetInitialValue("s_assigned_to") != null){
        item.s_assigned_to.SetValue(DBUtility.GetInitialValue("s_assigned_to"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "s_issue_name":
                    return this.s_issue_name;
                case "s_priority_id":
                    return this.s_priority_id;
                case "s_status_id":
                    return this.s_status_id;
                case "s_notstatus_id":
                    return this.s_notstatus_id;
                case "s_assigned_to":
                    return this.s_assigned_to;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "s_issue_name":
                    this.s_issue_name = (TextField)value;
                    break;
                case "s_priority_id":
                    this.s_priority_id = (IntegerField)value;
                    break;
                case "s_status_id":
                    this.s_status_id = (IntegerField)value;
                    break;
                case "s_notstatus_id":
                    this.s_notstatus_id = (TextField)value;
                    break;
                case "s_assigned_to":
                    this.s_assigned_to = (IntegerField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public bool IsNew{
        get{
            return _isNew;
        }
        set{
            _isNew = value;
        }
    }

    public bool IsDeleted{
        get{
            return _isDeleted;
        }
        set{
            _isDeleted = value;
        }
    }

    public void Validate(issuesSearchDataProvider provider)
    {
//End Record issuesSearch Item Class

//Record issuesSearch Item Class tail @4-F5FC18C5
    }
}
//End Record issuesSearch Item Class tail

//Record issuesSearch Data Provider Class @4-AA5A68F2
public class issuesSearchDataProvider:RecordDataProviderBase
{
//End Record issuesSearch Data Provider Class

//Record issuesSearch Data Provider Class Variables @4-B1097496
    protected DataCommand s_priority_idDataCommand;
    protected DataCommand s_status_idDataCommand;
    protected DataCommand s_notstatus_idDataCommand;
    protected DataCommand s_assigned_toDataCommand;
    protected issuesSearchItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
//End Record issuesSearch Data Provider Class Variables

//Record issuesSearch Data Provider Class Constructor @4-57589618
    public issuesSearchDataProvider()
    {
         s_priority_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         s_status_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         s_notstatus_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         s_assigned_toDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
    }
//End Record issuesSearch Data Provider Class Constructor

//Record issuesSearch Data Provider Class LoadParams Method @4-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record issuesSearch Data Provider Class LoadParams Method

//Record issuesSearch Data Provider Class GetResultSet Method @4-3FF90811
    public void FillItem(issuesSearchItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record issuesSearch Data Provider Class GetResultSet Method

//Record issuesSearch BeforeBuildSelect @4-921CE95D
        if(!IsInsertMode){
//End Record issuesSearch BeforeBuildSelect

//Record issuesSearch AfterExecuteSelect @4-C5999683
        }
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record issuesSearch AfterExecuteSelect

//ListBox s_priority_id Initialize Data Source @7-3CF33EBA
        int s_priority_idtableIndex = 0;
        s_priority_idDataCommand.OrderBy = "";
        s_priority_idDataCommand.Parameters.Clear();
//End ListBox s_priority_id Initialize Data Source

//ListBox s_priority_id BeforeExecuteSelect @7-203B14FE
        try{
            ListBoxSource=s_priority_idDataCommand.Execute().Tables[s_priority_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_priority_id BeforeExecuteSelect

//ListBox s_priority_id AfterExecuteSelect @7-F3E84935
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["priority_desc"];
            string key = (new IntegerField("", ListBoxSource[li]["priority_id"])).GetFormattedValue("");
            item.s_priority_idItems.Add(key,val);
        }
//End ListBox s_priority_id AfterExecuteSelect

//ListBox s_status_id Initialize Data Source @8-4D3F888B
        int s_status_idtableIndex = 0;
        s_status_idDataCommand.OrderBy = "";
        s_status_idDataCommand.Parameters.Clear();
//End ListBox s_status_id Initialize Data Source

//ListBox s_status_id BeforeExecuteSelect @8-F1A26E3B
        try{
            ListBoxSource=s_status_idDataCommand.Execute().Tables[s_status_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_status_id BeforeExecuteSelect

//ListBox s_status_id AfterExecuteSelect @8-4B99B762
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new IntegerField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.s_status_idItems.Add(key,val);
        }
//End ListBox s_status_id AfterExecuteSelect

//ListBox s_notstatus_id Initialize Data Source @29-0C907BE8
        int s_notstatus_idtableIndex = 0;
        s_notstatus_idDataCommand.OrderBy = "";
        s_notstatus_idDataCommand.Parameters.Clear();
//End ListBox s_notstatus_id Initialize Data Source

//ListBox s_notstatus_id BeforeExecuteSelect @29-F104C5A4
        try{
            ListBoxSource=s_notstatus_idDataCommand.Execute().Tables[s_notstatus_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_notstatus_id BeforeExecuteSelect

//ListBox s_notstatus_id AfterExecuteSelect @29-DDFD63F3
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new TextField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.s_notstatus_idItems.Add(key,val);
        }
//End ListBox s_notstatus_id AfterExecuteSelect

//ListBox s_assigned_to Initialize Data Source @9-E2B26DC6
        int s_assigned_totableIndex = 0;
        s_assigned_toDataCommand.OrderBy = "user_name";
        s_assigned_toDataCommand.Parameters.Clear();
//End ListBox s_assigned_to Initialize Data Source

//ListBox s_assigned_to BeforeExecuteSelect @9-23E6298F
        try{
            ListBoxSource=s_assigned_toDataCommand.Execute().Tables[s_assigned_totableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_assigned_to BeforeExecuteSelect

//ListBox s_assigned_to AfterExecuteSelect @9-8B3647A7
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.s_assigned_toItems.Add(key,val);
        }
//End ListBox s_assigned_to AfterExecuteSelect

//Record issuesSearch AfterExecuteSelect tail @4-FCB6E20C
    }
//End Record issuesSearch AfterExecuteSelect tail

//Record issuesSearch Data Provider Class @4-FCB6E20C
}

//End Record issuesSearch Data Provider Class

//Grid issues Item Class @3-E0C8A106
public class issuesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerField issue_id;
    public TextField issue_name;
    public object issue_nameHref;
    public LinkParameterCollection issue_nameHrefParameters;
    public TextField priority;
    public TextField status_id;
    public TextField assigned_to;
    public DateField date_submitted;
    public DateField date_modified;
    public DateField date_resolved;
    public NameValueCollection errors=new NameValueCollection();
    public issuesItem()
    {
        issue_id=new IntegerField("", null);
        issue_name = new TextField("",null);
        issue_nameHrefParameters = new LinkParameterCollection();
        priority=new TextField("", null);
        status_id=new TextField("", null);
        assigned_to=new TextField("", null);
        date_submitted=new DateField("G", null);
        date_modified=new DateField("G", null);
        date_resolved=new DateField("G", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "issue_id":
                    return this.issue_id;
                case "issue_name":
                    return this.issue_name;
                case "priority":
                    return this.priority;
                case "status_id":
                    return this.status_id;
                case "assigned_to":
                    return this.assigned_to;
                case "date_submitted":
                    return this.date_submitted;
                case "date_modified":
                    return this.date_modified;
                case "date_resolved":
                    return this.date_resolved;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "issue_id":
                    this.issue_id = (IntegerField)value;
                    break;
                case "issue_name":
                    this.issue_name = (TextField)value;
                    break;
                case "priority":
                    this.priority = (TextField)value;
                    break;
                case "status_id":
                    this.status_id = (TextField)value;
                    break;
                case "assigned_to":
                    this.assigned_to = (TextField)value;
                    break;
                case "date_submitted":
                    this.date_submitted = (DateField)value;
                    break;
                case "date_modified":
                    this.date_modified = (DateField)value;
                    break;
                case "date_resolved":
                    this.date_resolved = (DateField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid issues Item Class

//Grid issues Data Provider Class Header @3-68D66AE5
public class issuesDataProvider:GridDataProviderBase
{
//End Grid issues Data Provider Class Header

//Grid issues Data Provider Class Variables @3-DA6E0698
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default,Sorter_issue_id,Sorter_issue_name,Sorter1,Sorter_status_id,Sorter_assigned_to,Sorter_date_submitted,Sorter_date_modified,Sorter_date_resolved}
    private string[] SortFieldsNames=new string[]{"","issue_id","issue_name","priority_order","issues.status_id","assigned_to","date_submitted","date_modified","date_resolved"};
    private string[] SortFieldsNamesDesc=new string[]{"","issue_id DESC","issue_name DESC","priority_order DESC","issues.status_id DESC","assigned_to DESC","date_submitted DESC","date_modified DESC","date_resolved DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public TextParameter Urls_issue_name;
    public IntegerParameter Urls_priority_id;
    public IntegerParameter Urls_status_id;
    public IntegerParameter Urls_notstatus_id;
    public IntegerParameter Urls_assigned_to;
//End Grid issues Data Provider Class Variables

//Grid issues Data Provider Class Constructor @3-2E12EA46
    public issuesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM users RIGHT JOIN ((issues LEFT JOIN statuses ON\n" +
          "issues.status_id = statuses.status_id) LEFT JOIN priorities ON\n" +
          "issues.priority_id = priorities.priority_id) ON\n" +
          "users.user_id = issues.assigned_to {SQL_Where} {SQL_OrderBy}", new string[]{"s_issue_name10","And","s_priority_id11","And","s_status_id12","And","s_notstatus_id43","And","s_assigned_to13"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users RIGHT JOIN ((issues LEFT JOIN statuses ON\n" +
          "issues.status_id = statuses.status_id) LEFT JOIN priorities ON\n" +
          "issues.priority_id = priorities.priority_id) ON\n" +
          "users.user_id = issues.assigned_to", new string[]{"s_issue_name10","And","s_priority_id11","And","s_status_id12","And","s_notstatus_id43","And","s_assigned_to13"},Settings.IMDataAccessObject);
    }
//End Grid issues Data Provider Class Constructor

//Grid issues Data Provider Class GetResultSet Method @3-1BD238D1
    public issuesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid issues Data Provider Class GetResultSet Method

//Before build Select @3-CFEC8617
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("s_issue_name10",Urls_issue_name, "","issues.issue_name",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_priority_id11",Urls_priority_id, "","issues.priority_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_status_id12",Urls_status_id, "","issues.status_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_notstatus_id43",Urls_notstatus_id, "","issues.status_id",Condition.NotEqual,false);
        ((TableCommand)Select).AddParameter("s_assigned_to13",Urls_assigned_to, "","issues.assigned_to",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Grid issues Event BeforeExecuteSelect. Action Custom Code @63-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Grid issues Event BeforeExecuteSelect. Action Custom Code

//Execute Select @3-081BAA84
        DataSet ds=null;
        _pagesCount=0;
        issuesItem[] result = new issuesItem[0];
        if (ops.AllowRead) {
            try{
                if(RecordsPerPage>0)
                {
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage);
                    _pagesCount = ExecuteCount();
                    mRecordCount = _pagesCount;
                    _pagesCount = _pagesCount%RecordsPerPage>0?(int)(_pagesCount/RecordsPerPage)+1:(int)(_pagesCount/RecordsPerPage);
                }
                else
                {
                ds=ExecuteSelect();
                if(ds.Tables[tableIndex].Rows.Count!=0){
                    _pagesCount=1;mRecordCount = ds.Tables[tableIndex].Rows.Count;}
                }
            }catch(Exception e){
                E=e;}
            finally{
//End Execute Select

//After execute Select @3-D9BD0183
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new issuesItem[dr.Count];
//End After execute Select

//After execute Select tail @3-BD8C8D3C
            for(int i=0;i<dr.Count;i++)
            {
                issuesItem item=new issuesItem();
                item.issue_id.SetValue(dr[i]["issue_id"],"");
                item.issue_name.SetValue(dr[i]["issue_name"],"");
                item.issue_nameHref = "IssueMaint.aspx";
                item.issue_nameHrefParameters.Add("issue_id",System.Web.HttpUtility.UrlEncode(dr[i]["issue_id"].ToString()));
                item.priority.SetValue(dr[i]["priority_desc"],"");
                item.status_id.SetValue(dr[i]["status"],"");
                item.assigned_to.SetValue(dr[i]["user_name"],"");
                item.date_submitted.SetValue(dr[i]["date_submitted"],Select.DateFormat);
                item.date_modified.SetValue(dr[i]["date_modified"],Select.DateFormat);
                item.date_resolved.SetValue(dr[i]["date_resolved"],Select.DateFormat);
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @3-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

