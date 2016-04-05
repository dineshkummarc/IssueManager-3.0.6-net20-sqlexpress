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

namespace IssueManager.IssueMaint{ //Namespace @1-06CB1DC4

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

//Record issues Item Class @2-10437BD4
public class issuesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField issue_id;
    public TextField issue_name;
    public MemoField issue_desc;
    public IntegerField user_id;
    public ItemCollection user_idItems;
    public IntegerField modified_by;
    public ItemCollection modified_byItems;
    public DateField date_submitted;
    public TextField date_format;
    public TextField version;
    public IntegerField tested;
    public IntegerField testedCheckedValue;
    public IntegerField testedUncheckedValue;
    public IntegerField approved;
    public IntegerField approvedCheckedValue;
    public IntegerField approvedUncheckedValue;
    public IntegerField assigned_to_orig;
    public ItemCollection assigned_to_origItems;
    public IntegerField assigned_to;
    public ItemCollection assigned_toItems;
    public IntegerField status_id;
    public ItemCollection status_idItems;
    public IntegerField priority_id;
    public ItemCollection priority_idItems;
    public NameValueCollection errors=new NameValueCollection();
    public issuesItem()
    {
        issue_id=new TextField("", null);
        issue_name=new TextField("", null);
        issue_desc=new MemoField("", null);
        user_id = new IntegerField("", null);
        user_idItems = new ItemCollection();
        modified_by = new IntegerField("", null);
        modified_byItems = new ItemCollection();
        date_submitted=new DateField("G", null);
        date_format=new TextField("", null);
        version=new TextField("", null);
        tested = new IntegerField("", null);
        testedCheckedValue = new IntegerField("", 1);
        testedUncheckedValue = new IntegerField("", 0);
        approved = new IntegerField("", null);
        approvedCheckedValue = new IntegerField("", 1);
        approvedUncheckedValue = new IntegerField("", 0);
        assigned_to_orig = new IntegerField("", null);
        assigned_to_origItems = new ItemCollection();
        assigned_to = new IntegerField("", null);
        assigned_toItems = new ItemCollection();
        status_id = new IntegerField("", null);
        status_idItems = new ItemCollection();
        priority_id = new IntegerField("", null);
        priority_idItems = new ItemCollection();
    }

    public static issuesItem CreateFromHttpRequest()
    {
        issuesItem item = new issuesItem();
        if(DBUtility.GetInitialValue("issue_id") != null){
        item.issue_id.SetValue(DBUtility.GetInitialValue("issue_id"));
        }
        if(DBUtility.GetInitialValue("issue_name") != null){
        item.issue_name.SetValue(DBUtility.GetInitialValue("issue_name"));
        }
        if(DBUtility.GetInitialValue("issue_desc") != null){
        item.issue_desc.SetValue(DBUtility.GetInitialValue("issue_desc"));
        }
        if(DBUtility.GetInitialValue("user_id") != null){
        item.user_id.SetValue(DBUtility.GetInitialValue("user_id"));
        }
        if(DBUtility.GetInitialValue("modified_by") != null){
        item.modified_by.SetValue(DBUtility.GetInitialValue("modified_by"));
        }
        if(DBUtility.GetInitialValue("date_submitted") != null){
        item.date_submitted.SetValue(DBUtility.GetInitialValue("date_submitted"));
        }
        if(DBUtility.GetInitialValue("date_format") != null){
        item.date_format.SetValue(DBUtility.GetInitialValue("date_format"));
        }
        if(DBUtility.GetInitialValue("version") != null){
        item.version.SetValue(DBUtility.GetInitialValue("version"));
        }
        if(DBUtility.GetInitialValue("tested") != null){
        if(System.Web.HttpContext.Current.Request["tested"]!=null)
            item.tested.Value = item.testedCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("approved") != null){
        if(System.Web.HttpContext.Current.Request["approved"]!=null)
            item.approved.Value = item.approvedCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("assigned_to_orig") != null){
        item.assigned_to_orig.SetValue(DBUtility.GetInitialValue("assigned_to_orig"));
        }
        if(DBUtility.GetInitialValue("assigned_to") != null){
        item.assigned_to.SetValue(DBUtility.GetInitialValue("assigned_to"));
        }
        if(DBUtility.GetInitialValue("status_id") != null){
        item.status_id.SetValue(DBUtility.GetInitialValue("status_id"));
        }
        if(DBUtility.GetInitialValue("priority_id") != null){
        item.priority_id.SetValue(DBUtility.GetInitialValue("priority_id"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "issue_id":
                    return this.issue_id;
                case "issue_name":
                    return this.issue_name;
                case "issue_desc":
                    return this.issue_desc;
                case "user_id":
                    return this.user_id;
                case "modified_by":
                    return this.modified_by;
                case "date_submitted":
                    return this.date_submitted;
                case "date_format":
                    return this.date_format;
                case "version":
                    return this.version;
                case "tested":
                    return this.tested;
                case "approved":
                    return this.approved;
                case "assigned_to_orig":
                    return this.assigned_to_orig;
                case "assigned_to":
                    return this.assigned_to;
                case "status_id":
                    return this.status_id;
                case "priority_id":
                    return this.priority_id;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "issue_id":
                    this.issue_id = (TextField)value;
                    break;
                case "issue_name":
                    this.issue_name = (TextField)value;
                    break;
                case "issue_desc":
                    this.issue_desc = (MemoField)value;
                    break;
                case "user_id":
                    this.user_id = (IntegerField)value;
                    break;
                case "modified_by":
                    this.modified_by = (IntegerField)value;
                    break;
                case "date_submitted":
                    this.date_submitted = (DateField)value;
                    break;
                case "date_format":
                    this.date_format = (TextField)value;
                    break;
                case "version":
                    this.version = (TextField)value;
                    break;
                case "tested":
                    this.tested = (IntegerField)value;
                    break;
                case "approved":
                    this.approved = (IntegerField)value;
                    break;
                case "assigned_to_orig":
                    this.assigned_to_orig = (IntegerField)value;
                    break;
                case "assigned_to":
                    this.assigned_to = (IntegerField)value;
                    break;
                case "status_id":
                    this.status_id = (IntegerField)value;
                    break;
                case "priority_id":
                    this.priority_id = (IntegerField)value;
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

    public void Validate(issuesDataProvider provider)
    {
//End Record issues Item Class

//issue_name validate @8-1719D45E
        if(issue_name.Value==null||issue_name.Value.ToString()=="")
            errors.Add("issue_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_issue_name));
//End issue_name validate

//issue_desc validate @9-701A262A
        if(issue_desc.Value==null||issue_desc.Value.ToString()=="")
            errors.Add("issue_desc",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_issue_description));
//End issue_desc validate

//user_id validate @10-D1849872
        if(user_id.Value==null||user_id.Value.ToString()=="")
            errors.Add("user_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_user_submitted));
//End user_id validate

//modified_by validate @11-5F625984
        if(modified_by.Value==null||modified_by.Value.ToString()=="")
            errors.Add("modified_by",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_modified_by));
//End modified_by validate

//date_submitted validate @12-F39F30E8
        if(date_submitted.Value==null||date_submitted.Value.ToString()=="")
            errors.Add("date_submitted",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_date_submitted));
//End date_submitted validate

//assigned_to_orig validate @16-1BEECF0F
        if(assigned_to_orig.Value==null||assigned_to_orig.Value.ToString()=="")
            errors.Add("assigned_to_orig",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_assigned_to_orig));
//End assigned_to_orig validate

//assigned_to validate @17-EE5ADBBA
        if(assigned_to.Value==null||assigned_to.Value.ToString()=="")
            errors.Add("assigned_to",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_assigned_to));
//End assigned_to validate

//status_id validate @18-DC78C128
        if(status_id.Value==null||status_id.Value.ToString()=="")
            errors.Add("status_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_status));
//End status_id validate

//priority_id validate @19-C31C855D
        if(priority_id.Value==null||priority_id.Value.ToString()=="")
            errors.Add("priority_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_priority));
//End priority_id validate

//Record issues Item Class tail @2-F5FC18C5
    }
}
//End Record issues Item Class tail

//Record issues Data Provider Class @2-FECC557B
public class issuesDataProvider:RecordDataProviderBase
{
//End Record issues Data Provider Class

//Record issues Data Provider Class Variables @2-99A7CC57
    protected DataCommand user_idDataCommand;
    protected DataCommand modified_byDataCommand;
    protected DataCommand assigned_to_origDataCommand;
    protected DataCommand assigned_toDataCommand;
    protected DataCommand status_idDataCommand;
    protected DataCommand priority_idDataCommand;
    protected issuesItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlissue_id;
//End Record issues Data Provider Class Variables

//Record issues Data Provider Class Constructor @2-CFEFC32B
    public issuesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM issues {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id7"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO issues(issue_name, issue_desc, user_id, modified_by, date_submitted, \n" +
          "version, tested, approved, assigned_to_orig, assigned_to, status_id, \n" +
          "priority_id) VALUES ({issue_name}, {issue_desc}, {user_id}, {modified_by}, {date_submitted" +
          "}, \n" +
          "{version}, {tested}, {approved}, {assigned_to_orig}, {assigned_to}, \n" +
          "{status_id}, {priority_id})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE issues SET issue_name={issue_name}, issue_desc={issue_desc}, \n" +
          "user_id={user_id}, modified_by={modified_by}, date_submitted={date_submitted}, \n" +
          "version={version}, tested={tested}, approved={approved}, assigned_to_orig={assigned_to_ori" +
          "g}, \n" +
          "assigned_to={assigned_to}, status_id={status_id}, priority_id={priority_id}", new string[]{"issue_id7"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM issues", new string[]{"issue_id7"},Settings.IMDataAccessObject);
         user_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         modified_byDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         assigned_to_origDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         assigned_toDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         status_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         priority_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record issues Data Provider Class Constructor

//Record issues Data Provider Class LoadParams Method @2-D74C0467
    protected bool LoadParams()
    {
        return Urlissue_id!=null;
    }
//End Record issues Data Provider Class LoadParams Method

//Record issues Data Provider Class CheckUnique Method @2-E9EF4CC5
    public bool CheckUnique(string ControlName,issuesItem item)
    {
        return true;
    }
//End Record issues Data Provider Class CheckUnique Method

//Record issues Data Provider Class PrepareInsert Method @2-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record issues Data Provider Class PrepareInsert Method

//Record issues Data Provider Class PrepareInsert Method tail @2-FCB6E20C
    }
//End Record issues Data Provider Class PrepareInsert Method tail

//Record issues Data Provider Class Insert Method @2-9938E5BB
    public int InsertItem(issuesItem item)
    {
        this.item = item;
//End Record issues Data Provider Class Insert Method

//Record issues Build insert @2-27D94B65
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{issue_name}",Insert.Dao.ToSql(item.issue_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{issue_desc}",Insert.Dao.ToSql(item.issue_desc.GetFormattedValue(""),FieldType.Memo));
        Insert.SqlQuery.Replace("{user_id}",Insert.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{modified_by}",Insert.Dao.ToSql(item.modified_by.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{date_submitted}",Insert.Dao.ToSql(item.date_submitted.GetFormattedValue(Insert.DateFormat),FieldType.Date));
        Insert.SqlQuery.Replace("{version}",Insert.Dao.ToSql(item.version.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{tested}",Insert.Dao.ToSql(item.tested.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{approved}",Insert.Dao.ToSql(item.approved.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{assigned_to_orig}",Insert.Dao.ToSql(item.assigned_to_orig.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{assigned_to}",Insert.Dao.ToSql(item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{status_id}",Insert.Dao.ToSql(item.status_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{priority_id}",Insert.Dao.ToSql(item.priority_id.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record issues Build insert

//Record issues AfterExecuteInsert @2-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record issues AfterExecuteInsert

//Record issues Data Provider Class PrepareUpdate Method @2-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record issues Data Provider Class PrepareUpdate Method

//Record issues Data Provider Class PrepareUpdate Method tail @2-FCB6E20C
    }
//End Record issues Data Provider Class PrepareUpdate Method tail

//Record issues Data Provider Class Update Method @2-9618FF28
    public int UpdateItem(issuesItem item)
    {
        this.item = item;
//End Record issues Data Provider Class Update Method

//Record issues BeforeBuildUpdate @2-AC68FE34
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("issue_id7",Urlissue_id, "","issue_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{issue_name}",Update.Dao.ToSql(item.issue_name.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{issue_desc}",Update.Dao.ToSql(item.issue_desc.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{user_id}",Update.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{modified_by}",Update.Dao.ToSql(item.modified_by.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{date_submitted}",Update.Dao.ToSql(item.date_submitted.GetFormattedValue(Update.DateFormat),FieldType.Date));
        Update.SqlQuery.Replace("{version}",Update.Dao.ToSql(item.version.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{tested}",Update.Dao.ToSql(item.tested.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{approved}",Update.Dao.ToSql(item.approved.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{assigned_to_orig}",Update.Dao.ToSql(item.assigned_to_orig.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{assigned_to}",Update.Dao.ToSql(item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{status_id}",Update.Dao.ToSql(item.status_id.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{priority_id}",Update.Dao.ToSql(item.priority_id.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record issues BeforeBuildUpdate

//Record issues AfterExecuteUpdate @2-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record issues AfterExecuteUpdate

//Record issues Data Provider Class PrepareDelete Method @2-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record issues Data Provider Class PrepareDelete Method

//Record issues Data Provider Class PrepareDelete Method tail @2-FCB6E20C
    }
//End Record issues Data Provider Class PrepareDelete Method tail

//Record issues Data Provider Class Delete Method @2-1B6B5D0D
    public int DeleteItem(issuesItem item)
    {
        this.item = item;
//End Record issues Data Provider Class Delete Method

//Record issues BeforeBuildDelete @2-6F8D2AA1
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("issue_id7",Urlissue_id, "","issue_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{issue_name}",Delete.Dao.ToSql(item.issue_name.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{issue_desc}",Delete.Dao.ToSql(item.issue_desc.GetFormattedValue(""),FieldType.Memo));
        Delete.SqlQuery.Replace("{user_id}",Delete.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{modified_by}",Delete.Dao.ToSql(item.modified_by.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{date_submitted}",Delete.Dao.ToSql(item.date_submitted.GetFormattedValue(Delete.DateFormat),FieldType.Date));
        Delete.SqlQuery.Replace("{version}",Delete.Dao.ToSql(item.version.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{tested}",Delete.Dao.ToSql(item.tested.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{approved}",Delete.Dao.ToSql(item.approved.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{assigned_to_orig}",Delete.Dao.ToSql(item.assigned_to_orig.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{assigned_to}",Delete.Dao.ToSql(item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{status_id}",Delete.Dao.ToSql(item.status_id.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{priority_id}",Delete.Dao.ToSql(item.priority_id.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record issues BeforeBuildDelete

//Record issues BeforeBuildDelete @2-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record issues BeforeBuildDelete

//Record issues Data Provider Class GetResultSet Method @2-7F1F4CAA
    public void FillItem(issuesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record issues Data Provider Class GetResultSet Method

//Record issues BeforeBuildSelect @2-9D1A56D6
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id7",Urlissue_id, "","issue_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record issues BeforeBuildSelect

//Record issues BeforeExecuteSelect @2-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record issues BeforeExecuteSelect

//Record issues AfterExecuteSelect @2-585D5F69
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.issue_id.SetValue(dr[i]["issue_id"],"");
            item.issue_name.SetValue(dr[i]["issue_name"],"");
            item.issue_desc.SetValue(dr[i]["issue_desc"],"");
            item.user_id.SetValue(dr[i]["user_id"],"");
            item.modified_by.SetValue(dr[i]["modified_by"],"");
            item.date_submitted.SetValue(dr[i]["date_submitted"],Select.DateFormat);
            item.version.SetValue(dr[i]["version"],"");
            item.tested.SetValue(dr[i]["tested"],"");
            item.approved.SetValue(dr[i]["approved"],"");
            item.assigned_to_orig.SetValue(dr[i]["assigned_to_orig"],"");
            item.assigned_to.SetValue(dr[i]["assigned_to"],"");
            item.status_id.SetValue(dr[i]["status_id"],"");
            item.priority_id.SetValue(dr[i]["priority_id"],"");
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record issues AfterExecuteSelect

//ListBox user_id Initialize Data Source @10-A5C3AF9B
        int user_idtableIndex = 0;
        user_idDataCommand.OrderBy = "user_name";
        user_idDataCommand.Parameters.Clear();
//End ListBox user_id Initialize Data Source

//ListBox user_id BeforeExecuteSelect @10-FFA48EA8
        try{
            ListBoxSource=user_idDataCommand.Execute().Tables[user_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox user_id BeforeExecuteSelect

//ListBox user_id AfterExecuteSelect @10-07704F1A
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.user_idItems.Add(key,val);
        }
//End ListBox user_id AfterExecuteSelect

//ListBox modified_by Initialize Data Source @11-9998FBDB
        int modified_bytableIndex = 0;
        modified_byDataCommand.OrderBy = "user_name";
        modified_byDataCommand.Parameters.Clear();
//End ListBox modified_by Initialize Data Source

//ListBox modified_by BeforeExecuteSelect @11-5E5EE354
        try{
            ListBoxSource=modified_byDataCommand.Execute().Tables[modified_bytableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox modified_by BeforeExecuteSelect

//ListBox modified_by AfterExecuteSelect @11-2F557EDF
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.modified_byItems.Add(key,val);
        }
//End ListBox modified_by AfterExecuteSelect

//ListBox assigned_to_orig Initialize Data Source @16-7A8BFCE7
        int assigned_to_origtableIndex = 0;
        assigned_to_origDataCommand.OrderBy = "user_name";
        assigned_to_origDataCommand.Parameters.Clear();
//End ListBox assigned_to_orig Initialize Data Source

//ListBox assigned_to_orig BeforeExecuteSelect @16-311744D1
        try{
            ListBoxSource=assigned_to_origDataCommand.Execute().Tables[assigned_to_origtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox assigned_to_orig BeforeExecuteSelect

//ListBox assigned_to_orig AfterExecuteSelect @16-769CB25D
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.assigned_to_origItems.Add(key,val);
        }
//End ListBox assigned_to_orig AfterExecuteSelect

//ListBox assigned_to Initialize Data Source @17-E5783146
        int assigned_totableIndex = 0;
        assigned_toDataCommand.OrderBy = "user_name";
        assigned_toDataCommand.Parameters.Clear();
//End ListBox assigned_to Initialize Data Source

//ListBox assigned_to BeforeExecuteSelect @17-F907FD7C
        try{
            ListBoxSource=assigned_toDataCommand.Execute().Tables[assigned_totableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox assigned_to BeforeExecuteSelect

//ListBox assigned_to AfterExecuteSelect @17-7ED2D604
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.assigned_toItems.Add(key,val);
        }
//End ListBox assigned_to AfterExecuteSelect

//ListBox status_id Initialize Data Source @18-186FDC18
        int status_idtableIndex = 0;
        status_idDataCommand.OrderBy = "";
        status_idDataCommand.Parameters.Clear();
//End ListBox status_id Initialize Data Source

//ListBox status_id BeforeExecuteSelect @18-972A6ED1
        try{
            ListBoxSource=status_idDataCommand.Execute().Tables[status_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox status_id BeforeExecuteSelect

//ListBox status_id AfterExecuteSelect @18-D60C98FC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new IntegerField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.status_idItems.Add(key,val);
        }
//End ListBox status_id AfterExecuteSelect

//ListBox priority_id Initialize Data Source @19-201E3659
        int priority_idtableIndex = 0;
        priority_idDataCommand.OrderBy = "";
        priority_idDataCommand.Parameters.Clear();
//End ListBox priority_id Initialize Data Source

//ListBox priority_id BeforeExecuteSelect @19-87CB220C
        try{
            ListBoxSource=priority_idDataCommand.Execute().Tables[priority_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox priority_id BeforeExecuteSelect

//ListBox priority_id AfterExecuteSelect @19-FCBBBBFC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["priority_desc"];
            string key = (new IntegerField("", ListBoxSource[li]["priority_id"])).GetFormattedValue("");
            item.priority_idItems.Add(key,val);
        }
//End ListBox priority_id AfterExecuteSelect

//Record issues AfterExecuteSelect tail @2-FCB6E20C
    }
//End Record issues AfterExecuteSelect tail

//Record issues Data Provider Class @2-FCB6E20C
}

//End Record issues Data Provider Class

//Grid files Item Class @30-AFDAAA49
public class filesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField file_name;
    public object file_nameHref;
    public LinkParameterCollection file_nameHrefParameters;
    public TextField uploaded_by;
    public DateField date_uploaded;
    public NameValueCollection errors=new NameValueCollection();
    public filesItem()
    {
        file_name = new TextField("",null);
        file_nameHrefParameters = new LinkParameterCollection();
        uploaded_by=new TextField("", null);
        date_uploaded=new DateField("G", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "file_name":
                    return this.file_name;
                case "uploaded_by":
                    return this.uploaded_by;
                case "date_uploaded":
                    return this.date_uploaded;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "file_name":
                    this.file_name = (TextField)value;
                    break;
                case "uploaded_by":
                    this.uploaded_by = (TextField)value;
                    break;
                case "date_uploaded":
                    this.date_uploaded = (DateField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid files Item Class

//Grid files Data Provider Class Header @30-3E9540EA
public class filesDataProvider:GridDataProviderBase
{
//End Grid files Data Provider Class Header

//Grid files Data Provider Class Variables @30-0DE5B2E8
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default,Sorter_file_name,Sorter_uploaded_by,Sorter_date_uploaded}
    private string[] SortFieldsNames=new string[]{"","file_name","uploaded_by","date_uploaded"};
    private string[] SortFieldsNamesDesc=new string[]{"","file_name DESC","uploaded_by DESC","date_uploaded DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
    public IntegerParameter Urlissue_id;
//End Grid files Data Provider Class Variables

//Grid files Data Provider Class Constructor @30-EDA05ACF
    public filesDataProvider()
    {
         Select=new TableCommand("SELECT files.*, \n" +
          "user_name \n" +
          "FROM files LEFT JOIN users ON\n" +
          "files.uploaded_by = users.user_id {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id86"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM files LEFT JOIN users ON\n" +
          "files.uploaded_by = users.user_id", new string[]{"issue_id86"},Settings.IMDataAccessObject);
    }
//End Grid files Data Provider Class Constructor

//Grid files Data Provider Class GetResultSet Method @30-FFCC0302
    public filesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid files Data Provider Class GetResultSet Method

//Before build Select @30-66B62215
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id86",Urlissue_id, "","files.issue_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @30-E8BBEB16
        DataSet ds=null;
        _pagesCount=0;
        filesItem[] result = new filesItem[0];
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

//After execute Select @30-96CEE738
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new filesItem[dr.Count];
//End After execute Select

//After execute Select tail @30-159DABFB
            for(int i=0;i<dr.Count;i++)
            {
                filesItem item=new filesItem();
                item.file_name.SetValue(dr[i]["file_name"],"");
                item.file_nameHref = "FileMaint.aspx";
                item.file_nameHrefParameters.Add("file_id",System.Web.HttpUtility.UrlEncode(dr[i]["file_id"].ToString()));
                item.uploaded_by.SetValue(dr[i]["user_name"],"");
                item.date_uploaded.SetValue(dr[i]["date_uploaded"],Select.DateFormat);
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @30-FCB6E20C
}
//End Grid Data Provider tail

//Grid responses Item Class @20-EF111AF6
public class responsesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField user_id;
    public DateField date_response;
    public MemoField response;
    public TextField assigned_to;
    public TextField priority_id;
    public TextField status_id;
    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public responsesItem()
    {
        user_id=new TextField("", null);
        date_response=new DateField("G", null);
        response=new MemoField("", null);
        assigned_to=new TextField("", null);
        priority_id=new TextField("", null);
        status_id=new TextField("", null);
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user_id":
                    return this.user_id;
                case "date_response":
                    return this.date_response;
                case "response":
                    return this.response;
                case "assigned_to":
                    return this.assigned_to;
                case "priority_id":
                    return this.priority_id;
                case "status_id":
                    return this.status_id;
                case "Link1":
                    return this.Link1;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_id":
                    this.user_id = (TextField)value;
                    break;
                case "date_response":
                    this.date_response = (DateField)value;
                    break;
                case "response":
                    this.response = (MemoField)value;
                    break;
                case "assigned_to":
                    this.assigned_to = (TextField)value;
                    break;
                case "priority_id":
                    this.priority_id = (TextField)value;
                    break;
                case "status_id":
                    this.status_id = (TextField)value;
                    break;
                case "Link1":
                    this.Link1 = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid responses Item Class

//Grid responses Data Provider Class Header @20-718EF265
public class responsesDataProvider:GridDataProviderBase
{
//End Grid responses Data Provider Class Header

//Grid responses Data Provider Class Variables @20-E16EABE2
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=5;
    public int PageNumber=1;
    public IntegerParameter Urlissue_id;
//End Grid responses Data Provider Class Variables

//Grid responses Data Provider Class Constructor @20-45EFA9BC
    public responsesDataProvider()
    {
         Select=new TableCommand("SELECT responses.*, status, users.user_name AS users_user_name, \n" +
          "users1.user_name AS users1_user_name, \n" +
          "priority_desc \n" +
          "FROM users users1 RIGHT JOIN (users RIGHT JOIN (priorities RIGHT JOIN (statuses RIGHT JOIN" +
          " responses ON\n" +
          "statuses.status_id = responses.status_id) ON\n" +
          "priorities.priority_id = responses.priority_id) ON\n" +
          "users.user_id = responses.user_id) ON\n" +
          "users1.user_id = responses.assigned_to {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id80"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users users1 RIGHT JOIN (users RIGHT JOIN (priorities RIGHT JOIN (statuses RIGHT JOIN" +
          " responses ON\n" +
          "statuses.status_id = responses.status_id) ON\n" +
          "priorities.priority_id = responses.priority_id) ON\n" +
          "users.user_id = responses.user_id) ON\n" +
          "users1.user_id = responses.assigned_to", new string[]{"issue_id80"},Settings.IMDataAccessObject);
    }
//End Grid responses Data Provider Class Constructor

//Grid responses Data Provider Class GetResultSet Method @20-918F8C7B
    public responsesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid responses Data Provider Class GetResultSet Method

//Before build Select @20-30BD7C02
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id80",Urlissue_id, "","issue_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @20-2DEE5994
        DataSet ds=null;
        _pagesCount=0;
        responsesItem[] result = new responsesItem[0];
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

//After execute Select @20-79DC9FA7
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new responsesItem[dr.Count];
//End After execute Select

//After execute Select tail @20-DC92D95F
            for(int i=0;i<dr.Count;i++)
            {
                responsesItem item=new responsesItem();
                item.user_id.SetValue(dr[i]["users_user_name"],"");
                item.date_response.SetValue(dr[i]["date_response"],Select.DateFormat);
                item.response.SetValue(dr[i]["response"],"");
                item.assigned_to.SetValue(dr[i]["users1_user_name"],"");
                item.priority_id.SetValue(dr[i]["priority_desc"],"");
                item.status_id.SetValue(dr[i]["status"],"");
                item.Link1Href = "ResponseMaint.aspx";
                item.Link1HrefParameters.Add("response_id",System.Web.HttpUtility.UrlEncode(dr[i]["response_id"].ToString()));
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @20-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

