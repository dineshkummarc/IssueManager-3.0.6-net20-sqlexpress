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

namespace IssueManager.StatusList{ //Namespace @1-92D3D11E

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

//Grid statuses Item Class @3-BFF41748
public class statusesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField status;
    public object statusHref;
    public LinkParameterCollection statusHrefParameters;
    public TextField status_transl;
    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public statusesItem()
    {
        status = new TextField("",null);
        statusHrefParameters = new LinkParameterCollection();
        status_transl=new TextField("", null);
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "status":
                    return this.status;
                case "status_transl":
                    return this.status_transl;
                case "Link1":
                    return this.Link1;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "status":
                    this.status = (TextField)value;
                    break;
                case "status_transl":
                    this.status_transl = (TextField)value;
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
//End Grid statuses Item Class

//Grid statuses Data Provider Class Header @3-B1EA28E9
public class statusesDataProvider:GridDataProviderBase
{
//End Grid statuses Data Provider Class Header

//Grid statuses Data Provider Class Variables @3-172303F2
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default,Sorter_status}
    private string[] SortFieldsNames=new string[]{"","status"};
    private string[] SortFieldsNamesDesc=new string[]{"","status DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
//End Grid statuses Data Provider Class Variables

//Grid statuses Data Provider Class Constructor @3-EDCAB08B
    public statusesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM statuses", new string[]{},Settings.IMDataAccessObject);
    }
//End Grid statuses Data Provider Class Constructor

//Grid statuses Data Provider Class GetResultSet Method @3-C18DDBE6
    public statusesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid statuses Data Provider Class GetResultSet Method

//Before build Select @3-F73CEB25
        Select.Parameters.Clear();
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @3-E1875C2E
        DataSet ds=null;
        _pagesCount=0;
        statusesItem[] result = new statusesItem[0];
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

//After execute Select @3-E7AC2BEF
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new statusesItem[dr.Count];
//End After execute Select

//After execute Select tail @3-F9EE2B50
            for(int i=0;i<dr.Count;i++)
            {
                statusesItem item=new statusesItem();
                item.status.SetValue(dr[i]["status"],"");
                item.statusHref = "StatusList.aspx";
                item.statusHrefParameters.Add("status_id",System.Web.HttpUtility.UrlEncode(dr[i]["status_id"].ToString()));
                item.status_transl.SetValue(dr[i]["status"],"");
                item.Link1Href = "StatusList.aspx";
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

//Record statuses1 Item Class @48-16D0B1E7
public class statuses1Item
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField status;
    public TextField status_transl;
    public NameValueCollection errors=new NameValueCollection();
    public statuses1Item()
    {
        status=new TextField("", null);
        status_transl=new TextField("", null);
    }

    public static statuses1Item CreateFromHttpRequest()
    {
        statuses1Item item = new statuses1Item();
        if(DBUtility.GetInitialValue("status") != null){
        item.status.SetValue(DBUtility.GetInitialValue("status"));
        }
        if(DBUtility.GetInitialValue("status_transl") != null){
        item.status_transl.SetValue(DBUtility.GetInitialValue("status_transl"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "status":
                    return this.status;
                case "status_transl":
                    return this.status_transl;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "status":
                    this.status = (TextField)value;
                    break;
                case "status_transl":
                    this.status_transl = (TextField)value;
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

    public void Validate(statuses1DataProvider provider)
    {
//End Record statuses1 Item Class

//status validate @51-468DD24E
        if(status.Value==null||status.Value.ToString()=="")
            errors.Add("status",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_status));
//End status validate

//Record statuses1 Item Class tail @48-F5FC18C5
    }
}
//End Record statuses1 Item Class tail

//Record statuses1 Data Provider Class @48-D57A322E
public class statuses1DataProvider:RecordDataProviderBase
{
//End Record statuses1 Data Provider Class

//Record statuses1 Data Provider Class Variables @48-E5A17188
    protected statuses1Item item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlstatus_id;
//End Record statuses1 Data Provider Class Variables

//Record statuses1 Data Provider Class Constructor @48-7E0E59D4
    public statuses1DataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM statuses {SQL_Where} {SQL_OrderBy}", new string[]{"status_id55"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO statuses(status) VALUES ({status})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE statuses SET status={status}", new string[]{"status_id55"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM statuses", new string[]{"status_id55"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record statuses1 Data Provider Class Constructor

//Record statuses1 Data Provider Class LoadParams Method @48-7CD8575D
    protected bool LoadParams()
    {
        return Urlstatus_id!=null;
    }
//End Record statuses1 Data Provider Class LoadParams Method

//Record statuses1 Data Provider Class CheckUnique Method @48-BF5754BC
    public bool CheckUnique(string ControlName,statuses1Item item)
    {
        return true;
    }
//End Record statuses1 Data Provider Class CheckUnique Method

//Record statuses1 Data Provider Class PrepareInsert Method @48-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record statuses1 Data Provider Class PrepareInsert Method

//Record statuses1 Data Provider Class PrepareInsert Method tail @48-FCB6E20C
    }
//End Record statuses1 Data Provider Class PrepareInsert Method tail

//Record statuses1 Data Provider Class Insert Method @48-ECF8FAC1
    public int InsertItem(statuses1Item item)
    {
        this.item = item;
//End Record statuses1 Data Provider Class Insert Method

//Record statuses1 Build insert @48-F028413D
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{status}",Insert.Dao.ToSql(item.status.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record statuses1 Build insert

//Record statuses1 AfterExecuteInsert @48-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record statuses1 AfterExecuteInsert

//Record statuses1 Data Provider Class PrepareUpdate Method @48-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record statuses1 Data Provider Class PrepareUpdate Method

//Record statuses1 Data Provider Class PrepareUpdate Method tail @48-FCB6E20C
    }
//End Record statuses1 Data Provider Class PrepareUpdate Method tail

//Record statuses1 Data Provider Class Update Method @48-98EE2674
    public int UpdateItem(statuses1Item item)
    {
        this.item = item;
//End Record statuses1 Data Provider Class Update Method

//Record statuses1 BeforeBuildUpdate @48-250CD94A
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("status_id55",Urlstatus_id, "","status_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{status}",Update.Dao.ToSql(item.status.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record statuses1 BeforeBuildUpdate

//Record statuses1 AfterExecuteUpdate @48-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record statuses1 AfterExecuteUpdate

//Record statuses1 Data Provider Class PrepareDelete Method @48-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record statuses1 Data Provider Class PrepareDelete Method

//Record statuses1 Data Provider Class PrepareDelete Method tail @48-FCB6E20C
    }
//End Record statuses1 Data Provider Class PrepareDelete Method tail

//Record statuses1 Data Provider Class Delete Method @48-F3555C1F
    public int DeleteItem(statuses1Item item)
    {
        this.item = item;
//End Record statuses1 Data Provider Class Delete Method

//Record statuses1 BeforeBuildDelete @48-0645E55E
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("status_id55",Urlstatus_id, "","status_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{status}",Delete.Dao.ToSql(item.status.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record statuses1 BeforeBuildDelete

//Record statuses1 BeforeBuildDelete @48-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record statuses1 BeforeBuildDelete

//Record statuses1 Data Provider Class GetResultSet Method @48-25A94FDC
    public void FillItem(statuses1Item item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record statuses1 Data Provider Class GetResultSet Method

//Record statuses1 BeforeBuildSelect @48-A6DA12C9
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("status_id55",Urlstatus_id, "","status_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record statuses1 BeforeBuildSelect

//Record statuses1 BeforeExecuteSelect @48-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record statuses1 BeforeExecuteSelect

//Record statuses1 AfterExecuteSelect @48-1F93BD02
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.status.SetValue(dr[i]["status"],"");
            item.status_transl.SetValue(dr[i]["status"],"");
        }
        else
            IsInsertMode=true;
//End Record statuses1 AfterExecuteSelect

//Record statuses1 AfterExecuteSelect tail @48-FCB6E20C
    }
//End Record statuses1 AfterExecuteSelect tail

//Record statuses1 Data Provider Class @48-FCB6E20C
}

//End Record statuses1 Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

