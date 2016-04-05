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

namespace IssueManager.StatusMaint{ //Namespace @1-BDE9BC7D

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

//Record statuses Item Class @3-1017E412
public class statusesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField status_transl;
    public TextField status;
    public NameValueCollection errors=new NameValueCollection();
    public statusesItem()
    {
        status_transl=new TextField("", null);
        status=new TextField("", null);
    }

    public static statusesItem CreateFromHttpRequest()
    {
        statusesItem item = new statusesItem();
        if(DBUtility.GetInitialValue("status_transl") != null){
        item.status_transl.SetValue(DBUtility.GetInitialValue("status_transl"));
        }
        if(DBUtility.GetInitialValue("status") != null){
        item.status.SetValue(DBUtility.GetInitialValue("status"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "status_transl":
                    return this.status_transl;
                case "status":
                    return this.status;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "status_transl":
                    this.status_transl = (TextField)value;
                    break;
                case "status":
                    this.status = (TextField)value;
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

    public void Validate(statusesDataProvider provider)
    {
//End Record statuses Item Class

//status validate @8-468DD24E
        if(status.Value==null||status.Value.ToString()=="")
            errors.Add("status",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_status));
//End status validate

//Record statuses Item Class tail @3-F5FC18C5
    }
}
//End Record statuses Item Class tail

//Record statuses Data Provider Class @3-CAABE3F7
public class statusesDataProvider:RecordDataProviderBase
{
//End Record statuses Data Provider Class

//Record statuses Data Provider Class Variables @3-77EB9E20
    protected statusesItem item;
    public IntegerParameter Urlstatus_id;
//End Record statuses Data Provider Class Variables

//Record statuses Data Provider Class Constructor @3-A2CCB5C2
    public statusesDataProvider()
    {
         Select=new TableCommand("SELECT *  " + 
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{"status_id7"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO statuses(status) VALUES ({status})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE statuses SET status={status}", new string[]{"status_id7"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM statuses", new string[]{"status_id7"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record statuses Data Provider Class Constructor

//Record statuses Data Provider Class LoadParams Method @3-7CD8575D
    protected bool LoadParams()
    {
        return Urlstatus_id!=null;
    }
//End Record statuses Data Provider Class LoadParams Method

//Record statuses Data Provider Class CheckUnique Method @3-E2367699
    public bool CheckUnique(string ControlName,statusesItem item)
    {
        return true;
    }
//End Record statuses Data Provider Class CheckUnique Method

//Record statuses Data Provider Class PrepareInsert Method @3-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record statuses Data Provider Class PrepareInsert Method

//Record statuses Data Provider Class PrepareInsert Method tail @3-FCB6E20C
    }
//End Record statuses Data Provider Class PrepareInsert Method tail

//Record statuses Data Provider Class Insert Method @3-83945492
    public int InsertItem(statusesItem item)
    {
        this.item = item;
//End Record statuses Data Provider Class Insert Method

//Record statuses Build insert @3-F028413D
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{status}",Insert.Dao.ToSql(item.status.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record statuses Build insert

//Record statuses AfterExecuteInsert @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record statuses AfterExecuteInsert

//Record statuses Data Provider Class PrepareUpdate Method @3-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record statuses Data Provider Class PrepareUpdate Method

//Record statuses Data Provider Class PrepareUpdate Method tail @3-FCB6E20C
    }
//End Record statuses Data Provider Class PrepareUpdate Method tail

//Record statuses Data Provider Class Update Method @3-249A7B11
    public int UpdateItem(statusesItem item)
    {
        this.item = item;
//End Record statuses Data Provider Class Update Method

//Record statuses BeforeBuildUpdate @3-4A486795
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("status_id7",Urlstatus_id, "","status_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{status}",Update.Dao.ToSql(item.status.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record statuses BeforeBuildUpdate

//Record statuses AfterExecuteUpdate @3-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record statuses AfterExecuteUpdate

//Record statuses Data Provider Class PrepareDelete Method @3-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record statuses Data Provider Class PrepareDelete Method

//Record statuses Data Provider Class PrepareDelete Method tail @3-FCB6E20C
    }
//End Record statuses Data Provider Class PrepareDelete Method tail

//Record statuses Data Provider Class Delete Method @3-F4B1E441
    public int DeleteItem(statusesItem item)
    {
        this.item = item;
//End Record statuses Data Provider Class Delete Method

//Record statuses BeforeBuildDelete @3-59AC8937
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("status_id7",Urlstatus_id, "","status_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{status}",Delete.Dao.ToSql(item.status.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record statuses BeforeBuildDelete

//Record statuses BeforeBuildDelete @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record statuses BeforeBuildDelete

//Record statuses Data Provider Class GetResultSet Method @3-6F48E2B4
    public void FillItem(statusesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record statuses Data Provider Class GetResultSet Method

//Record statuses BeforeBuildSelect @3-EA9F7CCD
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("status_id7",Urlstatus_id, "","status_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record statuses BeforeBuildSelect

//Record statuses BeforeExecuteSelect @3-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record statuses BeforeExecuteSelect

//Record statuses AfterExecuteSelect @3-3B969FC7
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.status_transl.SetValue(dr[i]["status"],"");
            item.status.SetValue(dr[i]["status"],"");
        }
        else
            IsInsertMode=true;
//End Record statuses AfterExecuteSelect

//Record statuses AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record statuses AfterExecuteSelect tail

//Record statuses Data Provider Class @3-FCB6E20C
}

//End Record statuses Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

