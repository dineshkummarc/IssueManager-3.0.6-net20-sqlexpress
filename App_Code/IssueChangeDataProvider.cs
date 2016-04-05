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

namespace IssueManager.IssueChange{ //Namespace @1-04BBC92F

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

//Grid issue Item Class @2-C14C2AF9
public class issueItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField issue_id;
    public TextField issue_name;
    public MemoField issue_desc;
    public TextField user_id;
    public DateField date_submitted;
    public TextField version;
    public BooleanField tested;
    public BooleanField approved;
    public TextField assigned_to_orig;
    public TextField assigned_to;
    public TextField priority_id;
    public TextField status_id;
    public NameValueCollection errors=new NameValueCollection();
    public issueItem()
    {
        issue_id=new TextField("", null);
        issue_name=new TextField("", null);
        issue_desc=new MemoField("", null);
        user_id=new TextField("", null);
        date_submitted=new DateField("G", null);
        version=new TextField("", null);
        tested=new BooleanField("res:im_yes;res:im_no", null);
        approved=new BooleanField("res:im_yes;res:im_no", null);
        assigned_to_orig=new TextField("", null);
        assigned_to=new TextField("", null);
        priority_id=new TextField("", null);
        status_id=new TextField("", null);
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
                case "date_submitted":
                    return this.date_submitted;
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
                case "priority_id":
                    return this.priority_id;
                case "status_id":
                    return this.status_id;
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
                    this.user_id = (TextField)value;
                    break;
                case "date_submitted":
                    this.date_submitted = (DateField)value;
                    break;
                case "version":
                    this.version = (TextField)value;
                    break;
                case "tested":
                    this.tested = (BooleanField)value;
                    break;
                case "approved":
                    this.approved = (BooleanField)value;
                    break;
                case "assigned_to_orig":
                    this.assigned_to_orig = (TextField)value;
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
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid issue Item Class

//Grid issue Data Provider Class Header @2-3FF71379
public class issueDataProvider:GridDataProviderBase
{
//End Grid issue Data Provider Class Header

//Grid issue Data Provider Class Variables @2-110393EF
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=1;
    public int PageNumber=1;
    public IntegerParameter Urlissue_id;
//End Grid issue Data Provider Class Variables

//Grid issue Data Provider Class Constructor @2-A6BE2F49
    public issueDataProvider()
    {
         Select=new TableCommand("SELECT issues.*, priority_desc, status, users.user_name AS users_user_name, \n" +
          "users1.user_name AS users1_user_name, \n" +
          "users2.user_name AS users2_user_name \n" +
          "FROM users RIGHT JOIN (users users2 RIGHT JOIN (users users1 RIGHT JOIN (statuses RIGHT JO" +
          "IN (priorities RIGHT JOIN issues ON\n" +
          "priorities.priority_id = issues.priority_id) ON\n" +
          "statuses.status_id = issues.status_id) ON\n" +
          "users1.user_id = issues.assigned_to_orig) ON\n" +
          "users2.user_id = issues.assigned_to) ON\n" +
          "users.user_id = issues.user_id {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id191"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users RIGHT JOIN (users users2 RIGHT JOIN (users users1 RIGHT JOIN (statuses RIGHT JO" +
          "IN (priorities RIGHT JOIN issues ON\n" +
          "priorities.priority_id = issues.priority_id) ON\n" +
          "statuses.status_id = issues.status_id) ON\n" +
          "users1.user_id = issues.assigned_to_orig) ON\n" +
          "users2.user_id = issues.assigned_to) ON\n" +
          "users.user_id = issues.user_id", new string[]{"issue_id191"},Settings.IMDataAccessObject);
    }
//End Grid issue Data Provider Class Constructor

//Grid issue Data Provider Class GetResultSet Method @2-57CD447F
    public issueItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid issue Data Provider Class GetResultSet Method

//Before build Select @2-65094FEB
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id191",Urlissue_id, "","issue_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @2-9FA53F25
        DataSet ds=null;
        _pagesCount=0;
        issueItem[] result = new issueItem[0];
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

//After execute Select @2-FE3D8110
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new issueItem[dr.Count];
//End After execute Select

//After execute Select tail @2-5D275ACE
            for(int i=0;i<dr.Count;i++)
            {
                issueItem item=new issueItem();
                item.issue_id.SetValue(dr[i]["issue_id"],"");
                item.issue_name.SetValue(dr[i]["issue_name"],"");
                item.issue_desc.SetValue(dr[i]["issue_desc"],"");
                item.user_id.SetValue(dr[i]["users_user_name"],"");
                item.date_submitted.SetValue(dr[i]["date_submitted"],Select.DateFormat);
                item.version.SetValue(dr[i]["version"],"");
                item.tested.SetValue(dr[i]["tested"],"1;0");
                item.approved.SetValue(dr[i]["approved"],"1;0");
                item.assigned_to_orig.SetValue(dr[i]["users1_user_name"],"");
                item.assigned_to.SetValue(dr[i]["users2_user_name"],"");
                item.priority_id.SetValue(dr[i]["priority_desc"],"");
                item.status_id.SetValue(dr[i]["status"],"");
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

//Grid files Item Class @231-AFDAAA49
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

//Grid files Data Provider Class Header @231-3E9540EA
public class filesDataProvider:GridDataProviderBase
{
//End Grid files Data Provider Class Header

//Grid files Data Provider Class Variables @231-5BC49C7C
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
    public IntegerParameter Urlissue_id;
//End Grid files Data Provider Class Variables

//Grid files Data Provider Class Constructor @231-D8AA3F97
    public filesDataProvider()
    {
         Select=new TableCommand("SELECT files.*, \n" +
          "user_name \n" +
          "FROM files LEFT JOIN users ON\n" +
          "files.uploaded_by = users.user_id {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id241"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM files LEFT JOIN users ON\n" +
          "files.uploaded_by = users.user_id", new string[]{"issue_id241"},Settings.IMDataAccessObject);
    }
//End Grid files Data Provider Class Constructor

//Grid files Data Provider Class GetResultSet Method @231-FFCC0302
    public filesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid files Data Provider Class GetResultSet Method

//Before build Select @231-E4CDE26D
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id241",Urlissue_id, "","issue_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @231-E8BBEB16
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

//After execute Select @231-96CEE738
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new filesItem[dr.Count];
//End After execute Select

//After execute Select tail @231-4AA73621
            for(int i=0;i<dr.Count;i++)
            {
                filesItem item=new filesItem();
                item.file_name.SetValue(dr[i]["file_name"],"");
                item.file_nameHref = dr[i]["file_name"];
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

//Grid Data Provider tail @231-FCB6E20C
}
//End Grid Data Provider tail

//Record issues Item Class @34-51D604D8
public class issuesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public MemoField issue_resp;
    public IntegerField assigned_to;
    public ItemCollection assigned_toItems;
    public IntegerField priority_id;
    public ItemCollection priority_idItems;
    public IntegerField status_id;
    public ItemCollection status_idItems;
    public TextField version;
    public IntegerField tested;
    public IntegerField testedCheckedValue;
    public IntegerField testedUncheckedValue;
    public IntegerField approved;
    public IntegerField approvedCheckedValue;
    public IntegerField approvedUncheckedValue;
    public TextField attachment;
    public TextField FormAction;
    public DateField date_now;
    public NameValueCollection errors=new NameValueCollection();
    public issuesItem()
    {
        issue_resp=new MemoField("", null);
        assigned_to = new IntegerField("", null);
        assigned_toItems = new ItemCollection();
        priority_id = new IntegerField("", null);
        priority_idItems = new ItemCollection();
        status_id = new IntegerField("", null);
        status_idItems = new ItemCollection();
        version=new TextField("", null);
        tested = new IntegerField("", 1);
        testedCheckedValue = new IntegerField("", 1);
        testedUncheckedValue = new IntegerField("", 0);
        approved = new IntegerField("", 0);
        approvedCheckedValue = new IntegerField("", 1);
        approvedUncheckedValue = new IntegerField("", 0);
        attachment=new TextField("", null);
        FormAction=new TextField("", null);
        date_now=new DateField("G", DateTime.Now);
    }

    public static issuesItem CreateFromHttpRequest()
    {
        issuesItem item = new issuesItem();
        if(DBUtility.GetInitialValue("issue_resp") != null){
        item.issue_resp.SetValue(DBUtility.GetInitialValue("issue_resp"));
        }
        if(DBUtility.GetInitialValue("assigned_to") != null){
        item.assigned_to.SetValue(DBUtility.GetInitialValue("assigned_to"));
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
        if(DBUtility.GetInitialValue("tested") != null){
        if(System.Web.HttpContext.Current.Request["tested"]!=null)
            item.tested.Value = item.testedCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("approved") != null){
        if(System.Web.HttpContext.Current.Request["approved"]!=null)
            item.approved.Value = item.approvedCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("attachment") != null){
        }
        if(DBUtility.GetInitialValue("FormAction") != null){
        item.FormAction.SetValue(DBUtility.GetInitialValue("FormAction"));
        }
        if(DBUtility.GetInitialValue("date_now") != null){
        item.date_now.SetValue(DBUtility.GetInitialValue("date_now"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "issue_resp":
                    return this.issue_resp;
                case "assigned_to":
                    return this.assigned_to;
                case "priority_id":
                    return this.priority_id;
                case "status_id":
                    return this.status_id;
                case "version":
                    return this.version;
                case "tested":
                    return this.tested;
                case "approved":
                    return this.approved;
                case "attachment":
                    return this.attachment;
                case "FormAction":
                    return this.FormAction;
                case "date_now":
                    return this.date_now;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "issue_resp":
                    this.issue_resp = (MemoField)value;
                    break;
                case "assigned_to":
                    this.assigned_to = (IntegerField)value;
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
                case "tested":
                    this.tested = (IntegerField)value;
                    break;
                case "approved":
                    this.approved = (IntegerField)value;
                    break;
                case "attachment":
                    this.attachment = (TextField)value;
                    break;
                case "FormAction":
                    this.FormAction = (TextField)value;
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

//issue_resp validate @36-51846468
        if(issue_resp.Value==null||issue_resp.Value.ToString()=="")
            errors.Add("issue_resp",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_response));
//End issue_resp validate

//assigned_to validate @274-EE5ADBBA
        if(assigned_to.Value==null||assigned_to.Value.ToString()=="")
            errors.Add("assigned_to",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_assigned_to));
//End assigned_to validate

//priority_id validate @38-C31C855D
        if(priority_id.Value==null||priority_id.Value.ToString()=="")
            errors.Add("priority_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_priority));
//End priority_id validate

//status_id validate @39-DC78C128
        if(status_id.Value==null||status_id.Value.ToString()=="")
            errors.Add("status_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_status));
//End status_id validate

//Record issues Event OnValidate. Action Custom Code @293-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record issues Event OnValidate. Action Custom Code

//Record issues Item Class tail @34-F5FC18C5
    }
}
//End Record issues Item Class tail

//Record issues Data Provider Class @34-FECC557B
public class issuesDataProvider:RecordDataProviderBase
{
//End Record issues Data Provider Class

//Record issues Data Provider Class Variables @34-E2A0079F
    protected DataCommand assigned_toDataCommand;
    protected DataCommand priority_idDataCommand;
    protected DataCommand status_idDataCommand;
    protected issuesItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public MemoParameter Ctrlissue_resp;
    public IntegerParameter Urlissue_id;
    public IntegerParameter Ctrlassigned_to;
    public IntegerParameter Ctrlpriority_id;
    public IntegerParameter Ctrlstatus_id;
    public TextParameter Ctrlversion;
    public IntegerParameter Ctrltested;
    public IntegerParameter Ctrlapproved;
    public DateParameter Ctrldate_now;
    public IntegerParameter SesUserID;
    public DateParameter Expr286;
//End Record issues Data Provider Class Variables

//Record issues Data Provider Class Constructor @34-8602DE5F
    public issuesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM issues {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id222"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO responses(user_id, issue_id, date_response, response, assigned_to, \n" +
          "priority_id, status_id, version, tested, approved) VALUES ({user_id}, {issue_id}, \n" +
          "{date_response}, {response}, {assigned_to}, {priority_id}, {status_id}, \n" +
          "{version}, {tested}, {approved})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE issues SET assigned_to={assigned_to}, priority_id={priority_id}, \n" +
          "status_id={status_id}, version={version}, tested={tested}, approved={approved}, \n" +
          "date_modified={date_modified}, modified_by={modified_by}, date_resolved={date_resolved}", new string[]{"issue_id276"},Settings.IMDataAccessObject);
         assigned_toDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         priority_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         status_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record issues Data Provider Class Constructor

//Record issues Data Provider Class LoadParams Method @34-D74C0467
    protected bool LoadParams()
    {
        return Urlissue_id!=null;
    }
//End Record issues Data Provider Class LoadParams Method

//Record issues Data Provider Class CheckUnique Method @34-E9EF4CC5
    public bool CheckUnique(string ControlName,issuesItem item)
    {
        return true;
    }
//End Record issues Data Provider Class CheckUnique Method

//Record issues Data Provider Class PrepareInsert Method @34-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record issues Data Provider Class PrepareInsert Method

//Record issues Data Provider Class PrepareInsert Method tail @34-FCB6E20C
    }
//End Record issues Data Provider Class PrepareInsert Method tail

//Record issues Data Provider Class Insert Method @34-9938E5BB
    public int InsertItem(issuesItem item)
    {
        this.item = item;
//End Record issues Data Provider Class Insert Method

//Record issues Build insert @34-EE74D043
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{user_id}",Insert.Dao.ToSql(SesUserID==null?null:SesUserID.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{issue_id}",Insert.Dao.ToSql(Urlissue_id==null?null:Urlissue_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{date_response}",Insert.Dao.ToSql(item.date_now.Value==null?null:item.date_now.GetFormattedValue("yyyy-MM-dd HH\\:mm\\:ss"),FieldType.Date));
        Insert.SqlQuery.Replace("{response}",Insert.Dao.ToSql(item.issue_resp.Value==null?null:item.issue_resp.GetFormattedValue(""),FieldType.Memo));
        Insert.SqlQuery.Replace("{assigned_to}",Insert.Dao.ToSql(item.assigned_to.Value==null?null:item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{priority_id}",Insert.Dao.ToSql(item.priority_id.Value==null?null:item.priority_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{status_id}",Insert.Dao.ToSql(item.status_id.Value==null?null:item.status_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{version}",Insert.Dao.ToSql(item.version.Value==null?null:item.version.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{tested}",Insert.Dao.ToSql(item.tested.Value==null?null:item.tested.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{approved}",Insert.Dao.ToSql(item.approved.Value==null?null:item.approved.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record issues Build insert

//Record issues AfterExecuteInsert @34-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record issues AfterExecuteInsert

//Record issues Data Provider Class PrepareUpdate Method @34-EAF51CA7
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = Urlissue_id!=null;
//End Record issues Data Provider Class PrepareUpdate Method

//Record issues Data Provider Class PrepareUpdate Method tail @34-FCB6E20C
    }
//End Record issues Data Provider Class PrepareUpdate Method tail

//Record issues Data Provider Class Update Method @34-9618FF28
    public int UpdateItem(issuesItem item)
    {
        this.item = item;
//End Record issues Data Provider Class Update Method

//Record issues Event BeforeBuildUpdate. Action Custom Code @297-2A29BDB7
    // -------------------------
    // Write your own code here.
    // -------------------------
//End Record issues Event BeforeBuildUpdate. Action Custom Code

//Record issues BeforeBuildUpdate @34-06C464CD
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("issue_id276",Urlissue_id, "","issue_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{assigned_to}",Update.Dao.ToSql(item.assigned_to.Value==null?null:item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{priority_id}",Update.Dao.ToSql(item.priority_id.Value==null?null:item.priority_id.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{status_id}",Update.Dao.ToSql(item.status_id.Value==null?null:item.status_id.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{version}",Update.Dao.ToSql(item.version.Value==null?null:item.version.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{tested}",Update.Dao.ToSql(item.tested.Value==null?null:item.tested.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{approved}",Update.Dao.ToSql(item.approved.Value==null?null:item.approved.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{date_modified}",Update.Dao.ToSql(item.date_now.Value==null?null:item.date_now.GetFormattedValue("yyyy-MM-dd HH\\:mm\\:ss"),FieldType.Date));
        Update.SqlQuery.Replace("{modified_by}",Update.Dao.ToSql(SesUserID==null?null:SesUserID.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{date_resolved}",Update.Dao.ToSql(Expr286==null?null:Expr286.GetFormattedValue("yyyy-MM-dd HH\\:mm\\:ss"),FieldType.Date));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record issues BeforeBuildUpdate

//Record issues AfterExecuteUpdate @34-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record issues AfterExecuteUpdate

//Record issues Data Provider Class GetResultSet Method @34-7F1F4CAA
    public void FillItem(issuesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record issues Data Provider Class GetResultSet Method

//Record issues BeforeBuildSelect @34-B90AD4B9
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id222",Urlissue_id, "","issue_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record issues BeforeBuildSelect

//Record issues BeforeExecuteSelect @34-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record issues BeforeExecuteSelect

//Record issues AfterExecuteSelect @34-7B60E761
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.assigned_to.SetValue(dr[i]["assigned_to"],"");
            item.priority_id.SetValue(dr[i]["priority_id"],"");
            item.status_id.SetValue(dr[i]["status_id"],"");
            item.version.SetValue(dr[i]["version"],"");
            item.tested.SetValue(dr[i]["tested"],"");
            item.approved.SetValue(dr[i]["approved"],"");
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record issues AfterExecuteSelect

//ListBox assigned_to Initialize Data Source @274-E5783146
        int assigned_totableIndex = 0;
        assigned_toDataCommand.OrderBy = "user_name";
        assigned_toDataCommand.Parameters.Clear();
//End ListBox assigned_to Initialize Data Source

//ListBox assigned_to BeforeExecuteSelect @274-F907FD7C
        try{
            ListBoxSource=assigned_toDataCommand.Execute().Tables[assigned_totableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox assigned_to BeforeExecuteSelect

//ListBox assigned_to AfterExecuteSelect @274-7ED2D604
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.assigned_toItems.Add(key,val);
        }
//End ListBox assigned_to AfterExecuteSelect

//ListBox priority_id Initialize Data Source @38-D3A3BA31
        int priority_idtableIndex = 0;
        priority_idDataCommand.OrderBy = "priority_order";
        priority_idDataCommand.Parameters.Clear();
//End ListBox priority_id Initialize Data Source

//ListBox priority_id BeforeExecuteSelect @38-87CB220C
        try{
            ListBoxSource=priority_idDataCommand.Execute().Tables[priority_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox priority_id BeforeExecuteSelect

//ListBox priority_id AfterExecuteSelect @38-FCBBBBFC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["priority_desc"];
            string key = (new IntegerField("", ListBoxSource[li]["priority_id"])).GetFormattedValue("");
            item.priority_idItems.Add(key,val);
        }
//End ListBox priority_id AfterExecuteSelect

//ListBox status_id Initialize Data Source @39-68069BF6
        int status_idtableIndex = 0;
        status_idDataCommand.OrderBy = "status";
        status_idDataCommand.Parameters.Clear();
//End ListBox status_id Initialize Data Source

//ListBox status_id BeforeExecuteSelect @39-972A6ED1
        try{
            ListBoxSource=status_idDataCommand.Execute().Tables[status_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox status_id BeforeExecuteSelect

//ListBox status_id AfterExecuteSelect @39-D60C98FC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["status"];
            string key = (new IntegerField("", ListBoxSource[li]["status_id"])).GetFormattedValue("");
            item.status_idItems.Add(key,val);
        }
//End ListBox status_id AfterExecuteSelect

//Record issues AfterExecuteSelect tail @34-FCB6E20C
    }
//End Record issues AfterExecuteSelect tail

//Record issues Data Provider Class @34-FCB6E20C
}

//End Record issues Data Provider Class

//Grid responses1 Item Class @25-29BE1EFF
public class responses1Item:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public MemoField response;
    public TextField user_id;
    public DateField date_response;
    public TextField assigned_to;
    public TextField priority_id;
    public TextField status_id;
    public NameValueCollection errors=new NameValueCollection();
    public responses1Item()
    {
        response=new MemoField("", null);
        user_id=new TextField("", null);
        date_response=new DateField("G", null);
        assigned_to=new TextField("", null);
        priority_id=new TextField("", null);
        status_id=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "response":
                    return this.response;
                case "user_id":
                    return this.user_id;
                case "date_response":
                    return this.date_response;
                case "assigned_to":
                    return this.assigned_to;
                case "priority_id":
                    return this.priority_id;
                case "status_id":
                    return this.status_id;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "response":
                    this.response = (MemoField)value;
                    break;
                case "user_id":
                    this.user_id = (TextField)value;
                    break;
                case "date_response":
                    this.date_response = (DateField)value;
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
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid responses1 Item Class

//Grid responses1 Data Provider Class Header @25-DC4C71F7
public class responses1DataProvider:GridDataProviderBase
{
//End Grid responses1 Data Provider Class Header

//Grid responses1 Data Provider Class Variables @25-D0227343
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{"date_response desc"};
    private string[] SortFieldsNamesDesc=new string[]{"date_response desc"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=5;
    public int PageNumber=1;
    public IntegerParameter Urlissue_id;
//End Grid responses1 Data Provider Class Variables

//Grid responses1 Data Provider Class Constructor @25-2F596D62
    public responses1DataProvider()
    {
         Select=new TableCommand("SELECT responses.*, users.user_name AS users_user_name, \n" +
          "users1.user_name AS users1_user_name, priority_desc, \n" +
          "status \n" +
          "FROM statuses RIGHT JOIN (priorities RIGHT JOIN (users users1 RIGHT JOIN (users RIGHT JOIN" +
          " responses ON\n" +
          "users.user_id = responses.user_id) ON\n" +
          "users1.user_id = responses.assigned_to) ON\n" +
          "priorities.priority_id = responses.priority_id) ON\n" +
          "statuses.status_id = responses.status_id {SQL_Where} {SQL_OrderBy}", new string[]{"issue_id192"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM statuses RIGHT JOIN (priorities RIGHT JOIN (users users1 RIGHT JOIN (users RIGHT JOIN" +
          " responses ON\n" +
          "users.user_id = responses.user_id) ON\n" +
          "users1.user_id = responses.assigned_to) ON\n" +
          "priorities.priority_id = responses.priority_id) ON\n" +
          "statuses.status_id = responses.status_id", new string[]{"issue_id192"},Settings.IMDataAccessObject);
    }
//End Grid responses1 Data Provider Class Constructor

//Grid responses1 Data Provider Class GetResultSet Method @25-4228F3A7
    public responses1Item[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid responses1 Data Provider Class GetResultSet Method

//Before build Select @25-FD1958EB
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("issue_id192",Urlissue_id, "","issue_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @25-1E83DB7C
        DataSet ds=null;
        _pagesCount=0;
        responses1Item[] result = new responses1Item[0];
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

//After execute Select @25-25E1152B
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new responses1Item[dr.Count];
//End After execute Select

//After execute Select tail @25-C1490AE3
            for(int i=0;i<dr.Count;i++)
            {
                responses1Item item=new responses1Item();
                item.response.SetValue(dr[i]["response"],"");
                item.user_id.SetValue(dr[i]["users_user_name"],"");
                item.date_response.SetValue(dr[i]["date_response"],Select.DateFormat);
                item.assigned_to.SetValue(dr[i]["users1_user_name"],"");
                item.priority_id.SetValue(dr[i]["priority_desc"],"");
                item.status_id.SetValue(dr[i]["status"],"");
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @25-FCB6E20C
}
//End Grid Data Provider tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

