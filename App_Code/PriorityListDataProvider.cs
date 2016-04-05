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

namespace IssueManager.PriorityList{ //Namespace @1-41E343AA

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

//Grid priorities Item Class @3-2544A4FF
public class prioritiesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField priority_desc;
    public object priority_descHref;
    public LinkParameterCollection priority_descHrefParameters;
    public TextField priority_transl;
    public TextField priority_color;
    public IntegerField priority_order;
    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public prioritiesItem()
    {
        priority_desc = new TextField("",null);
        priority_descHrefParameters = new LinkParameterCollection();
        priority_transl=new TextField("", null);
        priority_color=new TextField("", null);
        priority_order=new IntegerField("", null);
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "priority_desc":
                    return this.priority_desc;
                case "priority_transl":
                    return this.priority_transl;
                case "priority_color":
                    return this.priority_color;
                case "priority_order":
                    return this.priority_order;
                case "Link1":
                    return this.Link1;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "priority_desc":
                    this.priority_desc = (TextField)value;
                    break;
                case "priority_transl":
                    this.priority_transl = (TextField)value;
                    break;
                case "priority_color":
                    this.priority_color = (TextField)value;
                    break;
                case "priority_order":
                    this.priority_order = (IntegerField)value;
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
//End Grid priorities Item Class

//Grid priorities Data Provider Class Header @3-C2BA7827
public class prioritiesDataProvider:GridDataProviderBase
{
//End Grid priorities Data Provider Class Header

//Grid priorities Data Provider Class Variables @3-409AF286
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default,Sorter_priority_desc,Sorter_priority_color,Sorter_priority_order}
    private string[] SortFieldsNames=new string[]{"","priority_desc","priority_color","priority_order"};
    private string[] SortFieldsNamesDesc=new string[]{"","priority_desc DESC","priority_color DESC","priority_order DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
//End Grid priorities Data Provider Class Variables

//Grid priorities Data Provider Class Constructor @3-2CD767BA
    public prioritiesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM priorities", new string[]{},Settings.IMDataAccessObject);
    }
//End Grid priorities Data Provider Class Constructor

//Grid priorities Data Provider Class GetResultSet Method @3-F0BEFF20
    public prioritiesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid priorities Data Provider Class GetResultSet Method

//Before build Select @3-F73CEB25
        Select.Parameters.Clear();
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @3-A96AA21F
        DataSet ds=null;
        _pagesCount=0;
        prioritiesItem[] result = new prioritiesItem[0];
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

//After execute Select @3-2FC90A3F
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new prioritiesItem[dr.Count];
//End After execute Select

//After execute Select tail @3-FA4E7D07
            for(int i=0;i<dr.Count;i++)
            {
                prioritiesItem item=new prioritiesItem();
                item.priority_desc.SetValue(dr[i]["priority_desc"],"");
                item.priority_descHref = "PriorityList.aspx";
                item.priority_descHrefParameters.Add("priority_id",System.Web.HttpUtility.UrlEncode(dr[i]["priority_id"].ToString()));
                item.priority_transl.SetValue(dr[i]["priority_desc"],"");
                item.priority_color.SetValue(dr[i]["priority_color"],"");
                item.priority_order.SetValue(dr[i]["priority_order"],"");
                item.Link1Href = "PriorityList.aspx";
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

//Record priorities1 Item Class @48-167147F7
public class priorities1Item
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField priority_desc;
    public TextField priority_transl;
    public TextField priority_color;
    public IntegerField priority_order;
    public NameValueCollection errors=new NameValueCollection();
    public priorities1Item()
    {
        priority_desc=new TextField("", null);
        priority_transl=new TextField("", null);
        priority_color=new TextField("", null);
        priority_order=new IntegerField("", null);
    }

    public static priorities1Item CreateFromHttpRequest()
    {
        priorities1Item item = new priorities1Item();
        if(DBUtility.GetInitialValue("priority_desc") != null){
        item.priority_desc.SetValue(DBUtility.GetInitialValue("priority_desc"));
        }
        if(DBUtility.GetInitialValue("priority_transl") != null){
        item.priority_transl.SetValue(DBUtility.GetInitialValue("priority_transl"));
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
                case "priority_desc":
                    return this.priority_desc;
                case "priority_transl":
                    return this.priority_transl;
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
                case "priority_desc":
                    this.priority_desc = (TextField)value;
                    break;
                case "priority_transl":
                    this.priority_transl = (TextField)value;
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

    public void Validate(priorities1DataProvider provider)
    {
//End Record priorities1 Item Class

//priority_desc validate @50-9BA09408
        if(priority_desc.Value==null||priority_desc.Value.ToString()=="")
            errors.Add("priority_desc",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_priority));
//End priority_desc validate

//Record priorities1 Item Class tail @48-F5FC18C5
    }
}
//End Record priorities1 Item Class tail

//Record priorities1 Data Provider Class @48-9F9B85B7
public class priorities1DataProvider:RecordDataProviderBase
{
//End Record priorities1 Data Provider Class

//Record priorities1 Data Provider Class Variables @48-023173DB
    protected priorities1Item item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlpriority_id;
//End Record priorities1 Data Provider Class Variables

//Record priorities1 Data Provider Class Constructor @48-1F597435
    public priorities1DataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM priorities {SQL_Where} {SQL_OrderBy}", new string[]{"priority_id58"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO priorities(priority_desc, priority_color, \n" +
          "priority_order) VALUES ({priority_desc}, {priority_color}, {priority_order})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE priorities SET priority_desc={priority_desc}, \n" +
          "priority_color={priority_color}, priority_order={priority_order}", new string[]{"priority_id58"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM priorities", new string[]{"priority_id58"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record priorities1 Data Provider Class Constructor

//Record priorities1 Data Provider Class LoadParams Method @48-9DA0C6DC
    protected bool LoadParams()
    {
        return Urlpriority_id!=null;
    }
//End Record priorities1 Data Provider Class LoadParams Method

//Record priorities1 Data Provider Class CheckUnique Method @48-7A954DD4
    public bool CheckUnique(string ControlName,priorities1Item item)
    {
        return true;
    }
//End Record priorities1 Data Provider Class CheckUnique Method

//Record priorities1 Data Provider Class PrepareInsert Method @48-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record priorities1 Data Provider Class PrepareInsert Method

//Record priorities1 Data Provider Class PrepareInsert Method tail @48-FCB6E20C
    }
//End Record priorities1 Data Provider Class PrepareInsert Method tail

//Record priorities1 Data Provider Class Insert Method @48-96A0160E
    public int InsertItem(priorities1Item item)
    {
        this.item = item;
//End Record priorities1 Data Provider Class Insert Method

//Record priorities1 Build insert @48-076A86A8
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
//End Record priorities1 Build insert

//Record priorities1 AfterExecuteInsert @48-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record priorities1 AfterExecuteInsert

//Record priorities1 Data Provider Class PrepareUpdate Method @48-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record priorities1 Data Provider Class PrepareUpdate Method

//Record priorities1 Data Provider Class PrepareUpdate Method tail @48-FCB6E20C
    }
//End Record priorities1 Data Provider Class PrepareUpdate Method tail

//Record priorities1 Data Provider Class Update Method @48-8077A61A
    public int UpdateItem(priorities1Item item)
    {
        this.item = item;
//End Record priorities1 Data Provider Class Update Method

//Record priorities1 BeforeBuildUpdate @48-E0805F11
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("priority_id58",Urlpriority_id, "","priority_id",Condition.Equal,false);
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
//End Record priorities1 BeforeBuildUpdate

//Record priorities1 AfterExecuteUpdate @48-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record priorities1 AfterExecuteUpdate

//Record priorities1 Data Provider Class PrepareDelete Method @48-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record priorities1 Data Provider Class PrepareDelete Method

//Record priorities1 Data Provider Class PrepareDelete Method tail @48-FCB6E20C
    }
//End Record priorities1 Data Provider Class PrepareDelete Method tail

//Record priorities1 Data Provider Class Delete Method @48-B6AEE7EF
    public int DeleteItem(priorities1Item item)
    {
        this.item = item;
//End Record priorities1 Data Provider Class Delete Method

//Record priorities1 BeforeBuildDelete @48-D632C36B
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("priority_id58",Urlpriority_id, "","priority_id",Condition.Equal,false);
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
//End Record priorities1 BeforeBuildDelete

//Record priorities1 BeforeBuildDelete @48-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record priorities1 BeforeBuildDelete

//Record priorities1 Data Provider Class GetResultSet Method @48-7E782000
    public void FillItem(priorities1Item item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record priorities1 Data Provider Class GetResultSet Method

//Record priorities1 BeforeBuildSelect @48-BC3C7505
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("priority_id58",Urlpriority_id, "","priority_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record priorities1 BeforeBuildSelect

//Record priorities1 BeforeExecuteSelect @48-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record priorities1 BeforeExecuteSelect

//Record priorities1 AfterExecuteSelect @48-65085255
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.priority_desc.SetValue(dr[i]["priority_desc"],"");
            item.priority_transl.SetValue(dr[i]["priority_desc"],"");
            item.priority_color.SetValue(dr[i]["priority_color"],"");
            item.priority_order.SetValue(dr[i]["priority_order"],"");
        }
        else
            IsInsertMode=true;
//End Record priorities1 AfterExecuteSelect

//Record priorities1 AfterExecuteSelect tail @48-FCB6E20C
    }
//End Record priorities1 AfterExecuteSelect tail

//Record priorities1 Data Provider Class @48-FCB6E20C
}

//End Record priorities1 Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

