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

namespace IssueManager.PriorityMaint{ //Namespace @1-7136FB7A

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

//Record priorities Item Class @3-7CAB82F5
public class prioritiesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    public TextField priority_transl;
    public TextField priority_desc;
    public TextField priority_color;
    public IntegerField priority_order;
    public NameValueCollection errors=new NameValueCollection();
    public prioritiesItem()
    {
        priority_transl=new TextField("", null);
        priority_desc=new TextField("", null);
        priority_color=new TextField("", null);
        priority_order=new IntegerField("", null);
    }

    public static prioritiesItem CreateFromHttpRequest()
    {
        prioritiesItem item = new prioritiesItem();
        if(DBUtility.GetInitialValue("priority_transl") != null){
        item.priority_transl.SetValue(DBUtility.GetInitialValue("priority_transl"));
        }
        if(DBUtility.GetInitialValue("priority_desc") != null){
        item.priority_desc.SetValue(DBUtility.GetInitialValue("priority_desc"));
        }
        if(DBUtility.GetInitialValue("priority_color") != null){
        item.priority_color.SetValue(DBUtility.GetInitialValue("priority_color"));
        }
        if(DBUtility.GetInitialValue("priority_order") != null){
        item.priority_order.SetValue(DBUtility.GetInitialValue("priority_order"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "priority_transl":
                    return this.priority_transl;
                case "priority_desc":
                    return this.priority_desc;
                case "priority_color":
                    return this.priority_color;
                case "priority_order":
                    return this.priority_order;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "priority_transl":
                    this.priority_transl = (TextField)value;
                    break;
                case "priority_desc":
                    this.priority_desc = (TextField)value;
                    break;
                case "priority_color":
                    this.priority_color = (TextField)value;
                    break;
                case "priority_order":
                    this.priority_order = (IntegerField)value;
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

    public void Validate(prioritiesDataProvider provider)
    {
//End Record priorities Item Class

//priority_desc validate @8-9BA09408
        if(priority_desc.Value==null||priority_desc.Value.ToString()=="")
            errors.Add("priority_desc",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_priority));
//End priority_desc validate

//Record priorities Item Class tail @3-F5FC18C5
    }
}
//End Record priorities Item Class tail

//Record priorities Data Provider Class @3-F4B93B93
public class prioritiesDataProvider:RecordDataProviderBase
{
//End Record priorities Data Provider Class

//Record priorities Data Provider Class Variables @3-578C755A
    protected prioritiesItem item;
    public IntegerParameter Urlpriority_id;
//End Record priorities Data Provider Class Variables

//Record priorities Data Provider Class Constructor @3-4E1ADF23
    public prioritiesDataProvider()
    {
         Select=new TableCommand("SELECT *  " + 
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{"priority_id7"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO priorities(priority_desc, priority_color,  " + 
          "priority_order) VALUES ({priority_desc}, {priority_color}, {priority_order})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE priorities SET priority_desc={priority_desc},  " + 
          "priority_color={priority_color}, priority_order={priority_order}", new string[]{"priority_id7"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM priorities", new string[]{"priority_id7"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record priorities Data Provider Class Constructor

//Record priorities Data Provider Class LoadParams Method @3-9DA0C6DC
    protected bool LoadParams()
    {
        return Urlpriority_id!=null;
    }
//End Record priorities Data Provider Class LoadParams Method

//Record priorities Data Provider Class CheckUnique Method @3-9A14A021
    public bool CheckUnique(string ControlName,prioritiesItem item)
    {
        return true;
    }
//End Record priorities Data Provider Class CheckUnique Method

//Record priorities Data Provider Class PrepareInsert Method @3-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record priorities Data Provider Class PrepareInsert Method

//Record priorities Data Provider Class PrepareInsert Method tail @3-FCB6E20C
    }
//End Record priorities Data Provider Class PrepareInsert Method tail

//Record priorities Data Provider Class Insert Method @3-B1223319
    public int InsertItem(prioritiesItem item)
    {
        this.item = item;
//End Record priorities Data Provider Class Insert Method

//Record priorities Build insert @3-076A86A8
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{priority_desc}",Insert.Dao.ToSql(item.priority_desc.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{priority_color}",Insert.Dao.ToSql(item.priority_color.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{priority_order}",Insert.Dao.ToSql(item.priority_order.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record priorities Build insert

//Record priorities AfterExecuteInsert @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record priorities AfterExecuteInsert

//Record priorities Data Provider Class PrepareUpdate Method @3-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record priorities Data Provider Class PrepareUpdate Method

//Record priorities Data Provider Class PrepareUpdate Method tail @3-FCB6E20C
    }
//End Record priorities Data Provider Class PrepareUpdate Method tail

//Record priorities Data Provider Class Update Method @3-0A5D62C6
    public int UpdateItem(prioritiesItem item)
    {
        this.item = item;
//End Record priorities Data Provider Class Update Method

//Record priorities BeforeBuildUpdate @3-453CDE10
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("priority_id7",Urlpriority_id, "","priority_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{priority_desc}",Update.Dao.ToSql(item.priority_desc.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{priority_color}",Update.Dao.ToSql(item.priority_color.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{priority_order}",Update.Dao.ToSql(item.priority_order.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record priorities BeforeBuildUpdate

//Record priorities AfterExecuteUpdate @3-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record priorities AfterExecuteUpdate

//Record priorities Data Provider Class PrepareDelete Method @3-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record priorities Data Provider Class PrepareDelete Method

//Record priorities Data Provider Class PrepareDelete Method tail @3-FCB6E20C
    }
//End Record priorities Data Provider Class PrepareDelete Method tail

//Record priorities Data Provider Class Delete Method @3-D056616C
    public int DeleteItem(prioritiesItem item)
    {
        this.item = item;
//End Record priorities Data Provider Class Delete Method

//Record priorities BeforeBuildDelete @3-A3B33B87
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("priority_id7",Urlpriority_id, "","priority_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{priority_desc}",Delete.Dao.ToSql(item.priority_desc.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{priority_color}",Delete.Dao.ToSql(item.priority_color.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{priority_order}",Delete.Dao.ToSql(item.priority_order.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record priorities BeforeBuildDelete

//Record priorities BeforeBuildDelete @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record priorities BeforeBuildDelete

//Record priorities Data Provider Class GetResultSet Method @3-6089230B
    public void FillItem(prioritiesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record priorities Data Provider Class GetResultSet Method

//Record priorities BeforeBuildSelect @3-D871F56B
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("priority_id7",Urlpriority_id, "","priority_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record priorities BeforeBuildSelect

//Record priorities BeforeExecuteSelect @3-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record priorities BeforeExecuteSelect

//Record priorities AfterExecuteSelect @3-55B5A779
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.priority_transl.SetValue(dr[i]["priority_desc"],"");
            item.priority_desc.SetValue(dr[i]["priority_desc"],"");
            item.priority_color.SetValue(dr[i]["priority_color"],"");
            item.priority_order.SetValue(dr[i]["priority_order"],"");
        }
        else
            IsInsertMode=true;
//End Record priorities AfterExecuteSelect

//Record priorities AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record priorities AfterExecuteSelect tail

//Record priorities Data Provider Class @3-FCB6E20C
}

//End Record priorities Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

