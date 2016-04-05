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

namespace IssueManager.StyleMaint{ //Namespace @1-5E943A6C

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

//Grid styles Item Class @9-B8131F07
public class stylesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField style_name;
    public object style_nameHref;
    public LinkParameterCollection style_nameHrefParameters;
    public TextField styles_Insert;
    public object styles_InsertHref;
    public LinkParameterCollection styles_InsertHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public stylesItem()
    {
        style_name = new TextField("",null);
        style_nameHrefParameters = new LinkParameterCollection();
        styles_Insert = new TextField("",null);
        styles_InsertHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "style_name":
                    return this.style_name;
                case "styles_Insert":
                    return this.styles_Insert;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "style_name":
                    this.style_name = (TextField)value;
                    break;
                case "styles_Insert":
                    this.styles_Insert = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid styles Item Class

//Grid styles Data Provider Class Header @9-181F1FFA
public class stylesDataProvider:GridDataProviderBase
{
//End Grid styles Data Provider Class Header

//Grid styles Data Provider Class Variables @9-E46AB659
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
//End Grid styles Data Provider Class Variables

//Grid styles Data Provider Class Constructor @9-025856E6
    public stylesDataProvider()
    {
         Select=new TableCommand("SELECT style_name \n" +
          "FROM styles {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM styles", new string[]{},Settings.IMDataAccessObject);
    }
//End Grid styles Data Provider Class Constructor

//Grid styles Data Provider Class GetResultSet Method @9-F8A5DED6
    public stylesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid styles Data Provider Class GetResultSet Method

//Before build Select @9-F73CEB25
        Select.Parameters.Clear();
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @9-85CADE33
        DataSet ds=null;
        _pagesCount=0;
        stylesItem[] result = new stylesItem[0];
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

//After execute Select @9-199EE276
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new stylesItem[dr.Count];
//End After execute Select

//After execute Select tail @9-E7B13993
            for(int i=0;i<dr.Count;i++)
            {
                stylesItem item=new stylesItem();
                item.style_name.SetValue(dr[i]["style_name"],"");
                item.style_nameHref = "StyleMaint.aspx";
                item.style_nameHrefParameters.Add("style_name",System.Web.HttpUtility.UrlEncode(dr[i]["style_name"].ToString()));
                item.styles_InsertHref = "StyleMaint.aspx";
                result[i]=item;
            }
            _isEmpty = dr.Count == 0;
        }
        this.mPagesCount = _pagesCount;
        return result; 
    }
//End After execute Select tail

//Grid Data Provider tail @9-FCB6E20C
}
//End Grid Data Provider tail

//Record styles1 Item Class @14-273A42E8
public class styles1Item
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField style_name;
    public NameValueCollection errors=new NameValueCollection();
    public styles1Item()
    {
        style_name=new TextField("", null);
    }

    public static styles1Item CreateFromHttpRequest()
    {
        styles1Item item = new styles1Item();
        if(DBUtility.GetInitialValue("style_name") != null){
        item.style_name.SetValue(DBUtility.GetInitialValue("style_name"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "style_name":
                    return this.style_name;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "style_name":
                    this.style_name = (TextField)value;
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

    public void Validate(styles1DataProvider provider)
    {
//End Record styles1 Item Class

//style_name validate @19-D81B587B
        if(style_name.Value==null||style_name.Value.ToString()=="")
            errors.Add("style_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_style_name));
        if(style_name!=null&&!provider.CheckUnique("style_name",this))
                errors.Add("style_name",String.Format(Resources.strings.CCS_UniqueValue,Resources.strings.im_style_name));
//End style_name validate

//Record styles1 Item Class tail @14-F5FC18C5
    }
}
//End Record styles1 Item Class tail

//Record styles1 Data Provider Class @14-96CA8909
public class styles1DataProvider:RecordDataProviderBase
{
//End Record styles1 Data Provider Class

//Record styles1 Data Provider Class Variables @14-E948DEA3
    protected styles1Item item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextParameter Urlstyle_name;
//End Record styles1 Data Provider Class Variables

//Record styles1 Data Provider Class Constructor @14-B37A46F2
    public styles1DataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM styles {SQL_Where} {SQL_OrderBy}", new string[]{"style_name18"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO styles(style_name) VALUES ({style_name})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE styles SET style_name={style_name}", new string[]{"style_name18"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM styles", new string[]{"style_name18"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record styles1 Data Provider Class Constructor

//Record styles1 Data Provider Class LoadParams Method @14-0085C9D5
    protected bool LoadParams()
    {
        return Urlstyle_name!=null;
    }
//End Record styles1 Data Provider Class LoadParams Method

//Record styles1 Data Provider Class CheckUnique Method @14-20DF3B69
    public bool CheckUnique(string ControlName,styles1Item item)
    {
        TableCommand Check=new TableCommand("SELECT COUNT(*)\n" +
          "FROM styles",
            new string[]{"style_name18"}
          ,Settings.IMDataAccessObject);
        string CheckWhere="";
        switch(ControlName){
        case "style_name":
            CheckWhere="style_name="+Check.Dao.ToSql(item.style_name.GetFormattedValue(""),FieldType.Text);
            break;
        }
        Check.Where=CheckWhere;
        Check.Operation="AND NOT";
        Check.Parameters.Clear();
        ((TableCommand)Check).AddParameter("style_name18",Urlstyle_name, "","style_name",Condition.Equal,false);
        if(Convert.ToInt32(Check.ExecuteScalar())>0)
            return false;
        else
        return true;
    }
//End Record styles1 Data Provider Class CheckUnique Method

//Record styles1 Data Provider Class PrepareInsert Method @14-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record styles1 Data Provider Class PrepareInsert Method

//Record styles1 Data Provider Class PrepareInsert Method tail @14-FCB6E20C
    }
//End Record styles1 Data Provider Class PrepareInsert Method tail

//Record styles1 Data Provider Class Insert Method @14-4BCB4A11
    public int InsertItem(styles1Item item)
    {
        this.item = item;
//End Record styles1 Data Provider Class Insert Method

//Record styles1 Build insert @14-92B4A151
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{style_name}",Insert.Dao.ToSql(item.style_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record styles1 Build insert

//Record styles1 AfterExecuteInsert @14-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record styles1 AfterExecuteInsert

//Record styles1 Data Provider Class PrepareUpdate Method @14-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record styles1 Data Provider Class PrepareUpdate Method

//Record styles1 Data Provider Class PrepareUpdate Method tail @14-FCB6E20C
    }
//End Record styles1 Data Provider Class PrepareUpdate Method tail

//Record styles1 Data Provider Class Update Method @14-22C2A8F5
    public int UpdateItem(styles1Item item)
    {
        this.item = item;
//End Record styles1 Data Provider Class Update Method

//Record styles1 BeforeBuildUpdate @14-0E690833
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("style_name18",Urlstyle_name, "","style_name",Condition.Equal,false);
        Update.SqlQuery.Replace("{style_name}",Update.Dao.ToSql(item.style_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record styles1 BeforeBuildUpdate

//Record styles1 AfterExecuteUpdate @14-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record styles1 AfterExecuteUpdate

//Record styles1 Data Provider Class PrepareDelete Method @14-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record styles1 Data Provider Class PrepareDelete Method

//Record styles1 Data Provider Class PrepareDelete Method tail @14-FCB6E20C
    }
//End Record styles1 Data Provider Class PrepareDelete Method tail

//Record styles1 Data Provider Class Delete Method @14-694B0F10
    public int DeleteItem(styles1Item item)
    {
        this.item = item;
//End Record styles1 Data Provider Class Delete Method

//Record styles1 BeforeBuildDelete @14-77046C96
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("style_name18",Urlstyle_name, "","style_name",Condition.Equal,false);
        Delete.SqlQuery.Replace("{style_name}",Delete.Dao.ToSql(item.style_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record styles1 BeforeBuildDelete

//Record styles1 BeforeBuildDelete @14-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record styles1 BeforeBuildDelete

//Record styles1 Data Provider Class GetResultSet Method @14-C1B845F6
    public void FillItem(styles1Item item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record styles1 Data Provider Class GetResultSet Method

//Record styles1 BeforeBuildSelect @14-DD81D379
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("style_name18",Urlstyle_name, "","style_name",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record styles1 BeforeBuildSelect

//Record styles1 BeforeExecuteSelect @14-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record styles1 BeforeExecuteSelect

//Record styles1 AfterExecuteSelect @14-67BCF4F7
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.style_name.SetValue(dr[i]["style_name"],"");
        }
        else
            IsInsertMode=true;
//End Record styles1 AfterExecuteSelect

//Record styles1 AfterExecuteSelect tail @14-FCB6E20C
    }
//End Record styles1 AfterExecuteSelect tail

//Record styles1 Data Provider Class @14-FCB6E20C
}

//End Record styles1 Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

