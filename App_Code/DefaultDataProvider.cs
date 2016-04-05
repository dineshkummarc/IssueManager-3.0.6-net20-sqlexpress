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

namespace IssueManager.Default{ //Namespace @1-E7AF9CE2

//Page Data Class @1-4A93B782
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"));
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"));
        item.Link4.SetValue(DBUtility.GetInitialValue("Link4"));
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "Link1":
                    return this.Link1;
                case "Link2":
                    return this.Link2;
                case "Link4":
                    return this.Link4;
                case "Link5":
                    return this.Link5;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "Link1":
                    this.Link1 = (TextField)value;
                    break;
                case "Link2":
                    this.Link2 = (TextField)value;
                    break;
                case "Link4":
                    this.Link4 = (TextField)value;
                    break;
                case "Link5":
                    this.Link5 = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public TextField Link2;
    public object Link2Href;
    public LinkParameterCollection Link2HrefParameters;
    public TextField Link4;
    public object Link4Href;
    public LinkParameterCollection Link4HrefParameters;
    public TextField Link5;
    public object Link5Href;
    public LinkParameterCollection Link5HrefParameters;
    public PageItem()
    {
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
        Link2 = new TextField("",null);
        Link2HrefParameters = new LinkParameterCollection();
        Link4 = new TextField("",null);
        Link4HrefParameters = new LinkParameterCollection();
        Link5 = new TextField("",null);
        Link5HrefParameters = new LinkParameterCollection();
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

//Record issuesSearch Item Class @3-74BBA484
public class issuesSearchItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField s_issue_desc;
    public IntegerField s_priority_id;
    public ItemCollection s_priority_idItems;
    public IntegerField s_status_id;
    public ItemCollection s_status_idItems;
    public IntegerField s_notstatus_id;
    public ItemCollection s_notstatus_idItems;
    public IntegerField s_assigned_to;
    public ItemCollection s_assigned_toItems;
    public NameValueCollection errors=new NameValueCollection();
    public issuesSearchItem()
    {
        s_issue_desc=new TextField("", null);
        s_priority_id = new IntegerField("", null);
        s_priority_idItems = new ItemCollection();
        s_status_id = new IntegerField("", null);
        s_status_idItems = new ItemCollection();
        s_notstatus_id = new IntegerField("", 3);
        s_notstatus_idItems = new ItemCollection();
        s_assigned_to = new IntegerField("", null);
        s_assigned_toItems = new ItemCollection();
    }

    public static issuesSearchItem CreateFromHttpRequest()
    {
        issuesSearchItem item = new issuesSearchItem();
        if(DBUtility.GetInitialValue("s_issue_desc") != null){
        item.s_issue_desc.SetValue(DBUtility.GetInitialValue("s_issue_desc"));
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
                case "s_issue_desc":
                    return this.s_issue_desc;
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
                case "s_issue_desc":
                    this.s_issue_desc = (TextField)value;
                    break;
                case "s_priority_id":
                    this.s_priority_id = (IntegerField)value;
                    break;
                case "s_status_id":
                    this.s_status_id = (IntegerField)value;
                    break;
                case "s_notstatus_id":
                    this.s_notstatus_id = (IntegerField)value;
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

//Record issuesSearch Item Class tail @3-F5FC18C5
    }
}
//End Record issuesSearch Item Class tail

//Record issuesSearch Data Provider Class @3-AA5A68F2
public class issuesSearchDataProvider:RecordDataProviderBase
{
//End Record issuesSearch Data Provider Class

//Record issuesSearch Data Provider Class Variables @3-B1097496
    protected DataCommand s_priority_idDataCommand;
    protected DataCommand s_status_idDataCommand;
    protected DataCommand s_notstatus_idDataCommand;
    protected DataCommand s_assigned_toDataCommand;
    protected issuesSearchItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
//End Record issuesSearch Data Provider Class Variables

//Record issuesSearch Data Provider Class Constructor @3-57589618
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

//Record issuesSearch Data Provider Class LoadParams Method @3-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record issuesSearch Data Provider Class LoadParams Method

//Record issuesSearch Data Provider Class GetResultSet Method @3-3FF90811
    public void FillItem(issuesSearchItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
//End Record issuesSearch Data Provider Class GetResultSet Method

//Record issuesSearch BeforeBuildSelect @3-921CE95D
        if(!IsInsertMode){
//End Record issuesSearch BeforeBuildSelect

//Record issuesSearch AfterExecuteSelect @3-C5999683
        }
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record issuesSearch AfterExecuteSelect

//ListBox s_priority_id Initialize Data Source @6-3CF33EBA
        int s_priority_idtableIndex = 0;
        s_priority_idDataCommand.OrderBy = "";
        s_priority_idDataCommand.Parameters.Clear();
//End ListBox s_priority_id Initialize Data Source

//ListBox s_priority_id BeforeExecuteSelect @6-203B14FE
        try{
            ListBoxSource=s_priority_idDataCommand.Execute().Tables[s_priority_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_priority_id BeforeExecuteSelect

//ListBox s_priority_id AfterExecuteSelect @6-F3E84935
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["priority_desc"];
            string key = (new IntegerField("", ListBoxSource[li]["priority_id"])).GetFormattedValue("");
            item.s_priority_idItems.Add(key,val);
        }
//End ListBox s_priority_id AfterExecuteSelect

//ListBox s_status_id Initialize Data Source @7-4D3F888B
        int s_status_idtableIndex = 0;
        s_status_idDataCommand.OrderBy = "";
        s_status_idDataCommand.Parameters.Clear();
//End ListBox s_status_id Initialize Data Source

//ListBox s_status_id BeforeExecuteSelect @7-F1A26E3B
        try{
            ListBoxSource=s_status_idDataCommand.Execute().Tables[s_status_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_status_id BeforeExecuteSelect

//ListBox s_status_id AfterExecuteSelect @7-4B99B762
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new IntegerField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.s_status_idItems.Add(key,val);
        }
//End ListBox s_status_id AfterExecuteSelect

//ListBox s_notstatus_id Initialize Data Source @34-0C907BE8
        int s_notstatus_idtableIndex = 0;
        s_notstatus_idDataCommand.OrderBy = "";
        s_notstatus_idDataCommand.Parameters.Clear();
//End ListBox s_notstatus_id Initialize Data Source

//ListBox s_notstatus_id BeforeExecuteSelect @34-F104C5A4
        try{
            ListBoxSource=s_notstatus_idDataCommand.Execute().Tables[s_notstatus_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_notstatus_id BeforeExecuteSelect

//ListBox s_notstatus_id AfterExecuteSelect @34-5D17CFB2
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new IntegerField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.s_notstatus_idItems.Add(key,val);
        }
//End ListBox s_notstatus_id AfterExecuteSelect

//ListBox s_assigned_to Initialize Data Source @8-E2B26DC6
        int s_assigned_totableIndex = 0;
        s_assigned_toDataCommand.OrderBy = "user_name";
        s_assigned_toDataCommand.Parameters.Clear();
//End ListBox s_assigned_to Initialize Data Source

//ListBox s_assigned_to BeforeExecuteSelect @8-23E6298F
        try{
            ListBoxSource=s_assigned_toDataCommand.Execute().Tables[s_assigned_totableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox s_assigned_to BeforeExecuteSelect

//ListBox s_assigned_to AfterExecuteSelect @8-8B3647A7
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.s_assigned_toItems.Add(key,val);
        }
//End ListBox s_assigned_to AfterExecuteSelect

//Record issuesSearch AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record issuesSearch AfterExecuteSelect tail

//Record issuesSearch Data Provider Class @3-FCB6E20C
}

//End Record issuesSearch Data Provider Class

//Grid summary Item Class @40-49BB7895
public class summaryItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField Label1;
    public object Label1Href;
    public LinkParameterCollection Label1HrefParameters;
    public TextField Label2;
    public NameValueCollection errors=new NameValueCollection();
    public summaryItem()
    {
        Label1 = new TextField("",null);
        Label1HrefParameters = new LinkParameterCollection();
        Label2=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "Label1":
                    return this.Label1;
                case "Label2":
                    return this.Label2;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "Label1":
                    this.Label1 = (TextField)value;
                    break;
                case "Label2":
                    this.Label2 = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid summary Item Class

//Grid summary Data Provider Class Header @40-9944B2DB
public class summaryDataProvider:GridDataProviderBase
{
//End Grid summary Data Provider Class Header

//Grid summary Data Provider Class Variables @40-7572BDE2
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"statuses.status_id"};
    private string[] SortFieldsNamesDesc=new string[]{"statuses.status_id"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=20;
    public int PageNumber=1;
    public MemoParameter Urls_issue_desc;
    public IntegerParameter Urls_assigned_by;
    public IntegerParameter Urls_priority_id;
    public IntegerParameter Urls_status_id;
    public IntegerParameter Urls_assigned_to;
    public IntegerParameter Urls_notstatus_id;
//End Grid summary Data Provider Class Variables

//Grid summary Data Provider Class Constructor @40-299E953F
    public summaryDataProvider()
    {
         Select=new TableCommand("SELECT COUNT(issue_id) AS issues_count, statuses.status_id AS statuses_status_id, \n" +
          "status \n" +
          "FROM issues INNER JOIN statuses ON\n" +
          "issues.status_id = statuses.status_id {SQL_Where}\n" +
          "GROUP BY statuses.status_id, status {SQL_OrderBy}", new string[]{"(","s_issue_desc167","Or","s_issue_desc168",")","And","s_assigned_by169","And","s_priority_id170","And","s_status_id171","And","s_assigned_to172","And","s_notstatus_id180"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*) FROM (SELECT  COUNT(issue_id) AS issues_count, \n" +
          "statuses.status_id AS statuses_status_id, \n" +
          "status FROM issues INNER JOIN statuses ON\n" +
          "issues.status_id = statuses.status_id {SQL_Where}\n" +
          "GROUP BY statuses.status_id, status) A", new string[]{"(","s_issue_desc167","Or","s_issue_desc168",")","And","s_assigned_by169","And","s_priority_id170","And","s_status_id171","And","s_assigned_to172","And","s_notstatus_id180"},Settings.IMDataAccessObject);
    }
//End Grid summary Data Provider Class Constructor

//Grid summary Data Provider Class GetResultSet Method @40-E05D219D
    public summaryItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid summary Data Provider Class GetResultSet Method

//Before build Select @40-2652B7A3
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("s_issue_desc167",Urls_issue_desc, "","issues.issue_name",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_issue_desc168",Urls_issue_desc, "","issues.issue_desc",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_assigned_by169",Urls_assigned_by, "","issues.user_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_priority_id170",Urls_priority_id, "","issues.priority_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_status_id171",Urls_status_id, "","issues.status_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_assigned_to172",Urls_assigned_to, "","issues.assigned_to",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_notstatus_id180",Urls_notstatus_id, "","issues.status_id",Condition.NotEqual,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @40-B501BC84
        DataSet ds=null;
        _pagesCount=0;
        summaryItem[] result = new summaryItem[0];
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

//After execute Select @40-E325835E
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new summaryItem[dr.Count];
//End After execute Select

//After execute Select tail @40-2AF02514
            for(int i=0;i<dr.Count;i++)
            {
                summaryItem item=new summaryItem();
                item.Label1.SetValue(dr[i]["status"],"");
                item.Label1Href = "Default.aspx";
                item.Label1HrefParameters.Add("s_status_id",System.Web.HttpUtility.UrlEncode(dr[i]["statuses_status_id"].ToString()));
                item.Label2.SetValue(dr[i]["issues_count"],"");
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @40-FCB6E20C
}
//End Grid Data Provider tail

//Grid issues Item Class @2-CF462AF6
public class issuesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField title;
    public IntegerField issue_id;
    public TextField issue_name;
    public object issue_nameHref;
    public LinkParameterCollection issue_nameHrefParameters;
    public TextField status_id;
    public TextField color;
    public TextField priority_id;
    public IntegerField assigned_id;
    public TextField assigned_to;
    public DateField date_submitted;
    public DateField date_modified;
    public BooleanField tested;
    public BooleanField approved;
    public TextField version;
    public IntegerField issue_id1;
    public TextField issue_name1;
    public object issue_name1Href;
    public LinkParameterCollection issue_name1HrefParameters;
    public TextField status_id1;
    public TextField color1;
    public TextField priority_id1;
    public IntegerField assigned_id1;
    public TextField assigned_to1;
    public DateField date_submitted1;
    public DateField date_modified1;
    public BooleanField tested1;
    public BooleanField approved1;
    public TextField version1;
    public TextField Link7;
    public object Link7Href;
    public LinkParameterCollection Link7HrefParameters;
    public TextField Link6;
    public object Link6Href;
    public LinkParameterCollection Link6HrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public issuesItem()
    {
        title=new TextField("", null);
        issue_id=new IntegerField("", null);
        issue_name = new TextField("",null);
        issue_nameHrefParameters = new LinkParameterCollection();
        status_id=new TextField("", null);
        color=new TextField("", null);
        priority_id=new TextField("", null);
        assigned_id=new IntegerField("", null);
        assigned_to=new TextField("", null);
        date_submitted=new DateField("G", null);
        date_modified=new DateField("G", null);
        tested=new BooleanField("res:im_yes;", null);
        approved=new BooleanField("res:im_yes;", null);
        version=new TextField("", null);
        issue_id1=new IntegerField("", null);
        issue_name1 = new TextField("",null);
        issue_name1HrefParameters = new LinkParameterCollection();
        status_id1=new TextField("", null);
        color1=new TextField("", null);
        priority_id1=new TextField("", null);
        assigned_id1=new IntegerField("", null);
        assigned_to1=new TextField("", null);
        date_submitted1=new DateField("G", null);
        date_modified1=new DateField("G", null);
        tested1=new BooleanField("res:im_yes;", null);
        approved1=new BooleanField("res:im_yes;", null);
        version1=new TextField("", null);
        Link7 = new TextField("",null);
        Link7HrefParameters = new LinkParameterCollection();
        Link6 = new TextField("",null);
        Link6HrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "title":
                    return this.title;
                case "issue_id":
                    return this.issue_id;
                case "issue_name":
                    return this.issue_name;
                case "status_id":
                    return this.status_id;
                case "color":
                    return this.color;
                case "priority_id":
                    return this.priority_id;
                case "assigned_id":
                    return this.assigned_id;
                case "assigned_to":
                    return this.assigned_to;
                case "date_submitted":
                    return this.date_submitted;
                case "date_modified":
                    return this.date_modified;
                case "tested":
                    return this.tested;
                case "approved":
                    return this.approved;
                case "version":
                    return this.version;
                case "issue_id1":
                    return this.issue_id1;
                case "issue_name1":
                    return this.issue_name1;
                case "status_id1":
                    return this.status_id1;
                case "color1":
                    return this.color1;
                case "priority_id1":
                    return this.priority_id1;
                case "assigned_id1":
                    return this.assigned_id1;
                case "assigned_to1":
                    return this.assigned_to1;
                case "date_submitted1":
                    return this.date_submitted1;
                case "date_modified1":
                    return this.date_modified1;
                case "tested1":
                    return this.tested1;
                case "approved1":
                    return this.approved1;
                case "version1":
                    return this.version1;
                case "Link7":
                    return this.Link7;
                case "Link6":
                    return this.Link6;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "title":
                    this.title = (TextField)value;
                    break;
                case "issue_id":
                    this.issue_id = (IntegerField)value;
                    break;
                case "issue_name":
                    this.issue_name = (TextField)value;
                    break;
                case "status_id":
                    this.status_id = (TextField)value;
                    break;
                case "color":
                    this.color = (TextField)value;
                    break;
                case "priority_id":
                    this.priority_id = (TextField)value;
                    break;
                case "assigned_id":
                    this.assigned_id = (IntegerField)value;
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
                case "tested":
                    this.tested = (BooleanField)value;
                    break;
                case "approved":
                    this.approved = (BooleanField)value;
                    break;
                case "version":
                    this.version = (TextField)value;
                    break;
                case "issue_id1":
                    this.issue_id1 = (IntegerField)value;
                    break;
                case "issue_name1":
                    this.issue_name1 = (TextField)value;
                    break;
                case "status_id1":
                    this.status_id1 = (TextField)value;
                    break;
                case "color1":
                    this.color1 = (TextField)value;
                    break;
                case "priority_id1":
                    this.priority_id1 = (TextField)value;
                    break;
                case "assigned_id1":
                    this.assigned_id1 = (IntegerField)value;
                    break;
                case "assigned_to1":
                    this.assigned_to1 = (TextField)value;
                    break;
                case "date_submitted1":
                    this.date_submitted1 = (DateField)value;
                    break;
                case "date_modified1":
                    this.date_modified1 = (DateField)value;
                    break;
                case "tested1":
                    this.tested1 = (BooleanField)value;
                    break;
                case "approved1":
                    this.approved1 = (BooleanField)value;
                    break;
                case "version1":
                    this.version1 = (TextField)value;
                    break;
                case "Link7":
                    this.Link7 = (TextField)value;
                    break;
                case "Link6":
                    this.Link6 = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid issues Item Class

//Grid issues Data Provider Class Header @2-68D66AE5
public class issuesDataProvider:GridDataProviderBase
{
//End Grid issues Data Provider Class Header

//Grid issues Data Provider Class Variables @2-E77D0DCE
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default,Sorter_issue_id,Sorter_issue_name,Sorter_status_id,Sorter_priority_id,Sorter_assigned_to,Sorter_date_submitted,Sorter_date_modified,Sorter_tested,Sorter_approved,Sorter_version}
    private string[] SortFieldsNames=new string[]{"date_modified desc","issue_id","issue_name","issues.status_id","priority_order","assigned_to","date_submitted","date_modified","tested","approved","version"};
    private string[] SortFieldsNamesDesc=new string[]{"date_modified desc","issue_id DESC","issue_name DESC","issues.status_id DESC","priority_order DESC","assigned_to DESC","date_submitted DESC","date_modified DESC","tested DESC","approved DESC","version DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public MemoParameter Urls_issue_desc;
    public IntegerParameter Urls_priority_id;
    public IntegerParameter Urls_status_id;
    public IntegerParameter Urls_notstatus_id;
    public IntegerParameter Urls_assigned_to;
    public IntegerParameter Urls_assigned_by;
//End Grid issues Data Provider Class Variables

//Grid issues Data Provider Class Constructor @2-5A89CB8D
    public issuesDataProvider()
    {
         Select=new TableCommand("SELECT issues.*, priority_desc, status, priority_color, \n" +
          "user_name \n" +
          "FROM ((issues LEFT JOIN priorities ON\n" +
          "issues.priority_id = priorities.priority_id) LEFT JOIN statuses ON\n" +
          "issues.status_id = statuses.status_id) LEFT JOIN users ON\n" +
          "issues.assigned_to = users.user_id {SQL_Where} {SQL_OrderBy}", new string[]{"(","s_issue_desc166","Or","s_issue_desc9",")","And","s_priority_id10","And","s_status_id11","And","s_notstatus_id50","And","s_assigned_to12","And","s_assigned_by129"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM ((issues LEFT JOIN priorities ON\n" +
          "issues.priority_id = priorities.priority_id) LEFT JOIN statuses ON\n" +
          "issues.status_id = statuses.status_id) LEFT JOIN users ON\n" +
          "issues.assigned_to = users.user_id", new string[]{"(","s_issue_desc166","Or","s_issue_desc9",")","And","s_priority_id10","And","s_status_id11","And","s_notstatus_id50","And","s_assigned_to12","And","s_assigned_by129"},Settings.IMDataAccessObject);
    }
//End Grid issues Data Provider Class Constructor

//Grid issues Data Provider Class GetResultSet Method @2-1BD238D1
    public issuesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid issues Data Provider Class GetResultSet Method

//Before build Select @2-D8DA194C
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("s_issue_desc166",Urls_issue_desc, "","issues.issue_name",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_issue_desc9",Urls_issue_desc, "","issues.issue_desc",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_priority_id10",Urls_priority_id, "","issues.priority_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_status_id11",Urls_status_id, "","issues.status_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_notstatus_id50",Urls_notstatus_id, "","issues.status_id",Condition.NotEqual,false);
        ((TableCommand)Select).AddParameter("s_assigned_to12",Urls_assigned_to, "","issues.assigned_to",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_assigned_by129",Urls_assigned_by, "","issues.user_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @2-081BAA84
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

//After execute Select @2-D9BD0183
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new issuesItem[dr.Count];
//End After execute Select

//After execute Select tail @2-87527A25
            for(int i=0;i<dr.Count;i++)
            {
                issuesItem item=new issuesItem();
                item.issue_id.SetValue(dr[i]["issue_id"],"");
                item.issue_name.SetValue(dr[i]["issue_name"],"");
                item.issue_nameHref = "IssueChange.aspx";
                item.issue_nameHrefParameters.Add("issue_id",System.Web.HttpUtility.UrlEncode(dr[i]["issue_id"].ToString()));
                item.status_id.SetValue(dr[i]["status"],"");
                item.color.SetValue(dr[i]["priority_color"],"");
                item.priority_id.SetValue(dr[i]["priority_desc"],"");
                item.assigned_id.SetValue(dr[i]["assigned_to"],"");
                item.assigned_to.SetValue(dr[i]["user_name"],"");
                item.date_submitted.SetValue(dr[i]["date_submitted"],Select.DateFormat);
                item.date_modified.SetValue(dr[i]["date_modified"],Select.DateFormat);
                item.tested.SetValue(dr[i]["tested"],"1;0");
                item.approved.SetValue(dr[i]["approved"],"1;0");
                item.version.SetValue(dr[i]["version"],"");
                item.issue_id1.SetValue(dr[i]["issue_id"],"");
                item.issue_name1.SetValue(dr[i]["issue_name"],"");
                item.issue_name1Href = "IssueChange.aspx";
                item.issue_name1HrefParameters.Add("issue_id",System.Web.HttpUtility.UrlEncode(dr[i]["issue_id"].ToString()));
                item.status_id1.SetValue(dr[i]["status"],"");
                item.color1.SetValue(dr[i]["priority_color"],"");
                item.priority_id1.SetValue(dr[i]["priority_desc"],"");
                item.assigned_id1.SetValue(dr[i]["assigned_to"],"");
                item.assigned_to1.SetValue(dr[i]["user_name"],"");
                item.date_submitted1.SetValue(dr[i]["date_submitted"],Select.DateFormat);
                item.date_modified1.SetValue(dr[i]["date_modified"],Select.DateFormat);
                item.tested1.SetValue(dr[i]["tested"],"1;0");
                item.approved1.SetValue(dr[i]["approved"],"1;0");
                item.version1.SetValue(dr[i]["version"],"");
                item.Link7Href = "IssueExport.aspx";
                item.Link6Href = "IssueNew.aspx";
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @2-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

