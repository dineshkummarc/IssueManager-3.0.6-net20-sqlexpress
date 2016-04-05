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

namespace IssueManager.IssueNew{ //Namespace @1-66863192

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

//Record issues Item Class @4-F387330C
public class issuesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField issue_name;
    public MemoField issue_desc;
    public IntegerField priority_id;
    public ItemCollection priority_idItems;
    public IntegerField status_id;
    public ItemCollection status_idItems;
    public TextField version;
    public IntegerField assigned_to;
    public ItemCollection assigned_toItems;
    public TextField user_name;
    public DateField date_submitted;
    public TextField attachment;
    public DateField date_now;
    public NameValueCollection errors=new NameValueCollection();
    public issuesItem()
    {
        issue_name=new TextField("", null);
        issue_desc=new MemoField("", null);
        priority_id = new IntegerField("", 3);
        priority_idItems = new ItemCollection();
        status_id = new IntegerField("", 1);
        status_idItems = new ItemCollection();
        version=new TextField("", null);
        assigned_to = new IntegerField("", null);
        assigned_toItems = new ItemCollection();
        user_name=new TextField("", null);
        date_submitted=new DateField("G", DateTime.Now);
        attachment=new TextField("", null);
        date_now=new DateField("G", DateTime.Now);
    }

    public static issuesItem CreateFromHttpRequest()
    {
        issuesItem item = new issuesItem();
        if(DBUtility.GetInitialValue("issue_name") != null){
        item.issue_name.SetValue(DBUtility.GetInitialValue("issue_name"));
        }
        if(DBUtility.GetInitialValue("issue_desc") != null){
        item.issue_desc.SetValue(DBUtility.GetInitialValue("issue_desc"));
        }
        if(DBUtility.GetInitialValue("priority_id") != null){
        item.priority_id.SetValue(DBUtility.GetInitialValue("priority_id"));
        }
        if(DBUtility.GetInitialValue("status_id") != null){
        item.status_id.SetValue(DBUtility.GetInitialValue("status_id"));
        }
        if(DBUtility.GetInitialValue("version") != null){
        item.version.SetValue(DBUtility.GetInitialValue("version"));
        }
        if(DBUtility.GetInitialValue("assigned_to") != null){
        item.assigned_to.SetValue(DBUtility.GetInitialValue("assigned_to"));
        }
        if(DBUtility.GetInitialValue("user_name") != null){
        item.user_name.SetValue(DBUtility.GetInitialValue("user_name"));
        }
        if(DBUtility.GetInitialValue("date_submitted") != null){
        item.date_submitted.SetValue(DBUtility.GetInitialValue("date_submitted"));
        }
        if(DBUtility.GetInitialValue("attachment") != null){
        }
        if(DBUtility.GetInitialValue("date_now") != null){
        item.date_now.SetValue(DBUtility.GetInitialValue("date_now"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "issue_name":
                    return this.issue_name;
                case "issue_desc":
                    return this.issue_desc;
                case "priority_id":
                    return this.priority_id;
                case "status_id":
                    return this.status_id;
                case "version":
                    return this.version;
                case "assigned_to":
                    return this.assigned_to;
                case "user_name":
                    return this.user_name;
                case "date_submitted":
                    return this.date_submitted;
                case "attachment":
                    return this.attachment;
                case "date_now":
                    return this.date_now;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "issue_name":
                    this.issue_name = (TextField)value;
                    break;
                case "issue_desc":
                    this.issue_desc = (MemoField)value;
                    break;
                case "priority_id":
                    this.priority_id = (IntegerField)value;
                    break;
                case "status_id":
                    this.status_id = (IntegerField)value;
                    break;
                case "version":
                    this.version = (TextField)value;
                    break;
                case "assigned_to":
                    this.assigned_to = (IntegerField)value;
                    break;
                case "user_name":
                    this.user_name = (TextField)value;
                    break;
                case "date_submitted":
                    this.date_submitted = (DateField)value;
                    break;
                case "attachment":
                    this.attachment = (TextField)value;
                    break;
                case "date_now":
                    this.date_now = (DateField)value;
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

//issue_name validate @10-1719D45E
        if(issue_name.Value==null||issue_name.Value.ToString()=="")
            errors.Add("issue_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_issue_name));
//End issue_name validate

//issue_desc validate @11-701A262A
        if(issue_desc.Value==null||issue_desc.Value.ToString()=="")
            errors.Add("issue_desc",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_issue_description));
//End issue_desc validate

//Record issues Item Class tail @4-F5FC18C5
    }
}
//End Record issues Item Class tail

//Record issues Data Provider Class @4-FECC557B
public class issuesDataProvider:RecordDataProviderBase
{
//End Record issues Data Provider Class

//Record issues Data Provider Class Variables @4-232EC307
    protected DataCommand priority_idDataCommand;
    protected DataCommand status_idDataCommand;
    protected DataCommand assigned_toDataCommand;
    protected issuesItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlissue_id;
    public TextParameter Ctrlissue_name;
    public MemoParameter Ctrlissue_desc;
    public IntegerParameter Ctrlpriority_id;
    public IntegerParameter Ctrlstatus_id;
    public TextParameter Ctrlversion;
    public IntegerParameter Ctrlassigned_to;
    public DateParameter Ctrldate_now;
    public IntegerParameter SesUserID;
//End Record issues Data Provider Class Variables

//Record issues Data Provider Class Constructor @4-8CA01C59
    public issuesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM issues {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id9"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO issues(issue_name, issue_desc, priority_id, status_id, version, \n" +
          "assigned_to, assigned_to_orig, date_submitted, user_id, date_modified, \n" +
          "modified_by) VALUES ({issue_name}, {issue_desc}, {priority_id}, {status_id}, {version}, \n" +
          "{assigned_to}, {assigned_to_orig}, {date_submitted}, {user_id}, {date_modified}, \n" +
          "{modified_by})", new string[0],Settings.IMDataAccessObject);
         priority_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         status_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         assigned_toDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record issues Data Provider Class Constructor

//Record issues Data Provider Class LoadParams Method @4-D74C0467
    protected bool LoadParams()
    {
        return Urlissue_id!=null;
    }
//End Record issues Data Provider Class LoadParams Method

//Record issues Data Provider Class CheckUnique Method @4-E9EF4CC5
    public bool CheckUnique(string ControlName,issuesItem item)
    {
        return true;
    }
//End Record issues Data Provider Class CheckUnique Method

//Record issues Data Provider Class PrepareInsert Method @4-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record issues Data Provider Class PrepareInsert Method

//Record issues Data Provider Class PrepareInsert Method tail @4-FCB6E20C
    }
//End Record issues Data Provider Class PrepareInsert Method tail

//Record issues Data Provider Class Insert Method @4-9938E5BB
    public int InsertItem(issuesItem item)
    {
        this.item = item;
//End Record issues Data Provider Class Insert Method

//Record issues Build insert @4-AEF77499
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{issue_name}",Insert.Dao.ToSql(item.issue_name.Value==null?null:item.issue_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{issue_desc}",Insert.Dao.ToSql(item.issue_desc.Value==null?null:item.issue_desc.GetFormattedValue(""),FieldType.Memo));
        Insert.SqlQuery.Replace("{priority_id}",Insert.Dao.ToSql(item.priority_id.Value==null?null:item.priority_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{status_id}",Insert.Dao.ToSql(item.status_id.Value==null?null:item.status_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{version}",Insert.Dao.ToSql(item.version.Value==null?null:item.version.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{assigned_to}",Insert.Dao.ToSql(item.assigned_to.Value==null?null:item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{assigned_to_orig}",Insert.Dao.ToSql(item.assigned_to.Value==null?null:item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{date_submitted}",Insert.Dao.ToSql(item.date_now.Value==null?null:item.date_now.GetFormattedValue("yyyy-MM-dd HH\\:mm\\:ss"),FieldType.Date));
        Insert.SqlQuery.Replace("{user_id}",Insert.Dao.ToSql(SesUserID==null?null:SesUserID.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{date_modified}",Insert.Dao.ToSql(item.date_now.Value==null?null:item.date_now.GetFormattedValue("yyyy-MM-dd HH\\:mm\\:ss"),FieldType.Date));
        Insert.SqlQuery.Replace("{modified_by}",Insert.Dao.ToSql(SesUserID==null?null:SesUserID.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record issues Build insert

//Record issues AfterExecuteInsert @4-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record issues AfterExecuteInsert

//Record issues Data Provider Class GetResultSet Method @4-7F1F4CAA
    public void FillItem(issuesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record issues Data Provider Class GetResultSet Method

//Record issues BeforeBuildSelect @4-0EB157FF
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id9",Urlissue_id, "","issue_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record issues BeforeBuildSelect

//Record issues BeforeExecuteSelect @4-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record issues BeforeExecuteSelect

//Record issues AfterExecuteSelect @4-186D474F
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.issue_name.SetValue(dr[i]["issue_name"],"");
            item.issue_desc.SetValue(dr[i]["issue_desc"],"");
            item.priority_id.SetValue(dr[i]["priority_id"],"");
            item.status_id.SetValue(dr[i]["status_id"],"");
            item.version.SetValue(dr[i]["version"],"");
            item.assigned_to.SetValue(dr[i]["assigned_to"],"");
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record issues AfterExecuteSelect

//ListBox priority_id Initialize Data Source @12-201E3659
        int priority_idtableIndex = 0;
        priority_idDataCommand.OrderBy = "";
        priority_idDataCommand.Parameters.Clear();
//End ListBox priority_id Initialize Data Source

//ListBox priority_id BeforeExecuteSelect @12-87CB220C
        try{
            ListBoxSource=priority_idDataCommand.Execute().Tables[priority_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox priority_id BeforeExecuteSelect

//ListBox priority_id AfterExecuteSelect @12-FCBBBBFC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["priority_desc"];
            string key = (new IntegerField("", ListBoxSource[li]["priority_id"])).GetFormattedValue("");
            item.priority_idItems.Add(key,val);
        }
//End ListBox priority_id AfterExecuteSelect

//ListBox status_id Initialize Data Source @13-186FDC18
        int status_idtableIndex = 0;
        status_idDataCommand.OrderBy = "";
        status_idDataCommand.Parameters.Clear();
//End ListBox status_id Initialize Data Source

//ListBox status_id BeforeExecuteSelect @13-972A6ED1
        try{
            ListBoxSource=status_idDataCommand.Execute().Tables[status_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox status_id BeforeExecuteSelect

//ListBox status_id AfterExecuteSelect @13-D60C98FC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new IntegerField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.status_idItems.Add(key,val);
        }
//End ListBox status_id AfterExecuteSelect

//ListBox assigned_to Initialize Data Source @15-E5783146
        int assigned_totableIndex = 0;
        assigned_toDataCommand.OrderBy = "user_name";
        assigned_toDataCommand.Parameters.Clear();
//End ListBox assigned_to Initialize Data Source

//ListBox assigned_to BeforeExecuteSelect @15-F907FD7C
        try{
            ListBoxSource=assigned_toDataCommand.Execute().Tables[assigned_totableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox assigned_to BeforeExecuteSelect

//ListBox assigned_to AfterExecuteSelect @15-7ED2D604
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.assigned_toItems.Add(key,val);
        }
//End ListBox assigned_to AfterExecuteSelect

//Record issues AfterExecuteSelect tail @4-FCB6E20C
    }
//End Record issues AfterExecuteSelect tail

//Record issues Data Provider Class @4-FCB6E20C
}

//End Record issues Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

