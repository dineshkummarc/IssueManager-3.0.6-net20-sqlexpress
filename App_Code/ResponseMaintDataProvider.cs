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

namespace IssueManager.ResponseMaint{ //Namespace @1-9E8732F7

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

//Record responses Item Class @7-BA15B0E1
public class responsesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerField user_id;
    public ItemCollection user_idItems;
    public DateField date_response;
    public MemoField response;
    public IntegerField assigned_to;
    public ItemCollection assigned_toItems;
    public IntegerField priority_id;
    public ItemCollection priority_idItems;
    public IntegerField status_id;
    public ItemCollection status_idItems;
    public TextField date_format;
    public NameValueCollection errors=new NameValueCollection();
    public responsesItem()
    {
        user_id = new IntegerField("", null);
        user_idItems = new ItemCollection();
        date_response=new DateField("G", null);
        response=new MemoField("", null);
        assigned_to = new IntegerField("", null);
        assigned_toItems = new ItemCollection();
        priority_id = new IntegerField("", null);
        priority_idItems = new ItemCollection();
        status_id = new IntegerField("", null);
        status_idItems = new ItemCollection();
        date_format=new TextField("", null);
    }

    public static responsesItem CreateFromHttpRequest()
    {
        responsesItem item = new responsesItem();
        if(DBUtility.GetInitialValue("user_id") != null){
        item.user_id.SetValue(DBUtility.GetInitialValue("user_id"));
        }
        if(DBUtility.GetInitialValue("date_response") != null){
        item.date_response.SetValue(DBUtility.GetInitialValue("date_response"));
        }
        if(DBUtility.GetInitialValue("response") != null){
        item.response.SetValue(DBUtility.GetInitialValue("response"));
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
        if(DBUtility.GetInitialValue("date_format") != null){
        item.date_format.SetValue(DBUtility.GetInitialValue("date_format"));
        }
        return item;
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
                case "date_format":
                    return this.date_format;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_id":
                    this.user_id = (IntegerField)value;
                    break;
                case "date_response":
                    this.date_response = (DateField)value;
                    break;
                case "response":
                    this.response = (MemoField)value;
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
                case "date_format":
                    this.date_format = (TextField)value;
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

    public void Validate(responsesDataProvider provider)
    {
//End Record responses Item Class

//user_id validate @13-D1849872
        if(user_id.Value==null||user_id.Value.ToString()=="")
            errors.Add("user_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_user_submitted));
//End user_id validate

//date_response validate @14-ED82043E
        if(date_response.Value==null||date_response.Value.ToString()=="")
            errors.Add("date_response",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_date_response));
//End date_response validate

//response validate @15-6B797BA3
        if(response.Value==null||response.Value.ToString()=="")
            errors.Add("response",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_response));
//End response validate

//assigned_to validate @16-EE5ADBBA
        if(assigned_to.Value==null||assigned_to.Value.ToString()=="")
            errors.Add("assigned_to",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_assigned_to));
//End assigned_to validate

//priority_id validate @17-C31C855D
        if(priority_id.Value==null||priority_id.Value.ToString()=="")
            errors.Add("priority_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_priority));
//End priority_id validate

//status_id validate @18-DC78C128
        if(status_id.Value==null||status_id.Value.ToString()=="")
            errors.Add("status_id",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_status));
//End status_id validate

//Record responses Item Class tail @7-F5FC18C5
    }
}
//End Record responses Item Class tail

//Record responses Data Provider Class @7-3B9BCF1E
public class responsesDataProvider:RecordDataProviderBase
{
//End Record responses Data Provider Class

//Record responses Data Provider Class Variables @7-C908AB2F
    protected DataCommand user_idDataCommand;
    protected DataCommand assigned_toDataCommand;
    protected DataCommand priority_idDataCommand;
    protected DataCommand status_idDataCommand;
    protected responsesItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlresponse_id;
//End Record responses Data Provider Class Variables

//Record responses Data Provider Class Constructor @7-5853BE28
    public responsesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM responses {SQL_Where} {SQL_OrderBy}", new string[]{"response_id12"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO responses(user_id, date_response, response, assigned_to, priority_id, \n" +
          "status_id) VALUES ({user_id}, {date_response}, {response}, {assigned_to}, \n" +
          "{priority_id}, {status_id})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE responses SET user_id={user_id}, date_response={date_response}, \n" +
          "response={response}, assigned_to={assigned_to}, priority_id={priority_id}, \n" +
          "status_id={status_id}", new string[]{"response_id12"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM responses", new string[]{"response_id12"},Settings.IMDataAccessObject);
         user_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         assigned_toDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         priority_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         status_idDataCommand=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record responses Data Provider Class Constructor

//Record responses Data Provider Class LoadParams Method @7-C2E96877
    protected bool LoadParams()
    {
        return Urlresponse_id!=null;
    }
//End Record responses Data Provider Class LoadParams Method

//Record responses Data Provider Class CheckUnique Method @7-DCF609F2
    public bool CheckUnique(string ControlName,responsesItem item)
    {
        return true;
    }
//End Record responses Data Provider Class CheckUnique Method

//Record responses Data Provider Class PrepareInsert Method @7-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record responses Data Provider Class PrepareInsert Method

//Record responses Data Provider Class PrepareInsert Method tail @7-FCB6E20C
    }
//End Record responses Data Provider Class PrepareInsert Method tail

//Record responses Data Provider Class Insert Method @7-3838EA0F
    public int InsertItem(responsesItem item)
    {
        this.item = item;
//End Record responses Data Provider Class Insert Method

//Record responses Build insert @7-86646D81
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{user_id}",Insert.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{date_response}",Insert.Dao.ToSql(item.date_response.GetFormattedValue(Insert.DateFormat),FieldType.Date));
        Insert.SqlQuery.Replace("{response}",Insert.Dao.ToSql(item.response.GetFormattedValue(""),FieldType.Memo));
        Insert.SqlQuery.Replace("{assigned_to}",Insert.Dao.ToSql(item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{priority_id}",Insert.Dao.ToSql(item.priority_id.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{status_id}",Insert.Dao.ToSql(item.status_id.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record responses Build insert

//Record responses AfterExecuteInsert @7-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record responses AfterExecuteInsert

//Record responses Data Provider Class PrepareUpdate Method @7-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record responses Data Provider Class PrepareUpdate Method

//Record responses Data Provider Class PrepareUpdate Method tail @7-FCB6E20C
    }
//End Record responses Data Provider Class PrepareUpdate Method tail

//Record responses Data Provider Class Update Method @7-4C2E36BA
    public int UpdateItem(responsesItem item)
    {
        this.item = item;
//End Record responses Data Provider Class Update Method

//Record responses BeforeBuildUpdate @7-A55A19B8
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("response_id12",Urlresponse_id, "","response_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{user_id}",Update.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{date_response}",Update.Dao.ToSql(item.date_response.GetFormattedValue(Update.DateFormat),FieldType.Date));
        Update.SqlQuery.Replace("{response}",Update.Dao.ToSql(item.response.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{assigned_to}",Update.Dao.ToSql(item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{priority_id}",Update.Dao.ToSql(item.priority_id.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{status_id}",Update.Dao.ToSql(item.status_id.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record responses BeforeBuildUpdate

//Record responses AfterExecuteUpdate @7-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record responses AfterExecuteUpdate

//Record responses Data Provider Class PrepareDelete Method @7-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record responses Data Provider Class PrepareDelete Method

//Record responses Data Provider Class PrepareDelete Method tail @7-FCB6E20C
    }
//End Record responses Data Provider Class PrepareDelete Method tail

//Record responses Data Provider Class Delete Method @7-27954CD1
    public int DeleteItem(responsesItem item)
    {
        this.item = item;
//End Record responses Data Provider Class Delete Method

//Record responses BeforeBuildDelete @7-B28DFEAC
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("response_id12",Urlresponse_id, "","response_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{user_id}",Delete.Dao.ToSql(item.user_id.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{date_response}",Delete.Dao.ToSql(item.date_response.GetFormattedValue(Delete.DateFormat),FieldType.Date));
        Delete.SqlQuery.Replace("{response}",Delete.Dao.ToSql(item.response.GetFormattedValue(""),FieldType.Memo));
        Delete.SqlQuery.Replace("{assigned_to}",Delete.Dao.ToSql(item.assigned_to.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{priority_id}",Delete.Dao.ToSql(item.priority_id.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{status_id}",Delete.Dao.ToSql(item.status_id.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record responses BeforeBuildDelete

//Record responses BeforeBuildDelete @7-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record responses BeforeBuildDelete

//Record responses Data Provider Class GetResultSet Method @7-FF70B017
    public void FillItem(responsesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record responses Data Provider Class GetResultSet Method

//Record responses BeforeBuildSelect @7-31F9CD0F
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("response_id12",Urlresponse_id, "","response_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record responses BeforeBuildSelect

//Record responses BeforeExecuteSelect @7-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record responses BeforeExecuteSelect

//Record responses AfterExecuteSelect @7-D7CA2F79
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.user_id.SetValue(dr[i]["user_id"],"");
            item.date_response.SetValue(dr[i]["date_response"],Select.DateFormat);
            item.response.SetValue(dr[i]["response"],"");
            item.assigned_to.SetValue(dr[i]["assigned_to"],"");
            item.priority_id.SetValue(dr[i]["priority_id"],"");
            item.status_id.SetValue(dr[i]["status_id"],"");
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record responses AfterExecuteSelect

//ListBox user_id Initialize Data Source @13-A5C3AF9B
        int user_idtableIndex = 0;
        user_idDataCommand.OrderBy = "user_name";
        user_idDataCommand.Parameters.Clear();
//End ListBox user_id Initialize Data Source

//ListBox user_id BeforeExecuteSelect @13-FFA48EA8
        try{
            ListBoxSource=user_idDataCommand.Execute().Tables[user_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox user_id BeforeExecuteSelect

//ListBox user_id AfterExecuteSelect @13-07704F1A
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.user_idItems.Add(key,val);
        }
//End ListBox user_id AfterExecuteSelect

//ListBox assigned_to Initialize Data Source @16-E5783146
        int assigned_totableIndex = 0;
        assigned_toDataCommand.OrderBy = "user_name";
        assigned_toDataCommand.Parameters.Clear();
//End ListBox assigned_to Initialize Data Source

//ListBox assigned_to BeforeExecuteSelect @16-F907FD7C
        try{
            ListBoxSource=assigned_toDataCommand.Execute().Tables[assigned_totableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox assigned_to BeforeExecuteSelect

//ListBox assigned_to AfterExecuteSelect @16-7ED2D604
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.assigned_toItems.Add(key,val);
        }
//End ListBox assigned_to AfterExecuteSelect

//ListBox priority_id Initialize Data Source @17-201E3659
        int priority_idtableIndex = 0;
        priority_idDataCommand.OrderBy = "";
        priority_idDataCommand.Parameters.Clear();
//End ListBox priority_id Initialize Data Source

//ListBox priority_id BeforeExecuteSelect @17-87CB220C
        try{
            ListBoxSource=priority_idDataCommand.Execute().Tables[priority_idtableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox priority_id BeforeExecuteSelect

//ListBox priority_id AfterExecuteSelect @17-FCBBBBFC
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["priority_desc"];
            string key = (new IntegerField("", ListBoxSource[li]["priority_id"])).GetFormattedValue("");
            item.priority_idItems.Add(key,val);
        }
//End ListBox priority_id AfterExecuteSelect

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

//Record responses AfterExecuteSelect tail @7-FCB6E20C
    }
//End Record responses AfterExecuteSelect tail

//Record responses Data Provider Class @7-FCB6E20C
}

//End Record responses Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

