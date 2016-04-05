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

namespace IssueManager.LangMaint{ //Namespace @1-0E853FC8

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

//Grid locales Item Class @2-930772A6
public class localesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField locale_name;
    public object locale_nameHref;
    public LinkParameterCollection locale_nameHrefParameters;
    public TextField locales_Insert;
    public object locales_InsertHref;
    public LinkParameterCollection locales_InsertHrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public localesItem()
    {
        locale_name = new TextField("",null);
        locale_nameHrefParameters = new LinkParameterCollection();
        locales_Insert = new TextField("",null);
        locales_InsertHrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "locale_name":
                    return this.locale_name;
                case "locales_Insert":
                    return this.locales_Insert;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "locale_name":
                    this.locale_name = (TextField)value;
                    break;
                case "locales_Insert":
                    this.locales_Insert = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid locales Item Class

//Grid locales Data Provider Class Header @2-98E5057B
public class localesDataProvider:GridDataProviderBase
{
//End Grid locales Data Provider Class Header

//Grid locales Data Provider Class Variables @2-E46AB659
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
//End Grid locales Data Provider Class Variables

//Grid locales Data Provider Class Constructor @2-D17AD515
    public localesDataProvider()
    {
         Select=new TableCommand("SELECT locale_name \n" +
          "FROM locales {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM locales", new string[]{},Settings.IMDataAccessObject);
    }
//End Grid locales Data Provider Class Constructor

//Grid locales Data Provider Class GetResultSet Method @2-B5440808
    public localesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid locales Data Provider Class GetResultSet Method

//Before build Select @2-F73CEB25
        Select.Parameters.Clear();
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @2-5F7C86A7
        DataSet ds=null;
        _pagesCount=0;
        localesItem[] result = new localesItem[0];
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

//After execute Select @2-D5700049
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new localesItem[dr.Count];
//End After execute Select

//After execute Select tail @2-93B7A284
            for(int i=0;i<dr.Count;i++)
            {
                localesItem item=new localesItem();
                item.locale_name.SetValue(dr[i]["locale_name"],"");
                item.locale_nameHref = "LangMaint.aspx";
                item.locale_nameHrefParameters.Add("locale_name",System.Web.HttpUtility.UrlEncode(dr[i]["locale_name"].ToString()));
                item.locales_InsertHref = "LangMaint.aspx";
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

//Record locales1 Item Class @7-81FFB1E1
public class locales1Item
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField locale_name;
    public NameValueCollection errors=new NameValueCollection();
    public locales1Item()
    {
        locale_name=new TextField("", null);
    }

    public static locales1Item CreateFromHttpRequest()
    {
        locales1Item item = new locales1Item();
        if(DBUtility.GetInitialValue("locale_name") != null){
        item.locale_name.SetValue(DBUtility.GetInitialValue("locale_name"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "locale_name":
                    return this.locale_name;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "locale_name":
                    this.locale_name = (TextField)value;
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

    public void Validate(locales1DataProvider provider)
    {
//End Record locales1 Item Class

//locale_name validate @12-A37FDE15
        if(locale_name.Value==null||locale_name.Value.ToString()=="")
            errors.Add("locale_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_locale_name));
        if(locale_name!=null&&!provider.CheckUnique("locale_name",this))
                errors.Add("locale_name",String.Format(Resources.strings.CCS_UniqueValue,Resources.strings.im_locale_name));
//End locale_name validate

//Record locales1 Item Class tail @7-F5FC18C5
    }
}
//End Record locales1 Item Class tail

//Record locales1 Data Provider Class @7-9B7819E7
public class locales1DataProvider:RecordDataProviderBase
{
//End Record locales1 Data Provider Class

//Record locales1 Data Provider Class Variables @7-F9DB950A
    protected locales1Item item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextParameter Urllocale_name;
//End Record locales1 Data Provider Class Variables

//Record locales1 Data Provider Class Constructor @7-A91AF913
    public locales1DataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM locales {SQL_Where} {SQL_OrderBy}", new string[]{"locale_name11"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO locales(locale_name) VALUES ({locale_name})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE locales SET locale_name={locale_name}", new string[]{"locale_name11"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM locales", new string[]{"locale_name11"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record locales1 Data Provider Class Constructor

//Record locales1 Data Provider Class LoadParams Method @7-6AD265A1
    protected bool LoadParams()
    {
        return Urllocale_name!=null;
    }
//End Record locales1 Data Provider Class LoadParams Method

//Record locales1 Data Provider Class CheckUnique Method @7-2AB65513
    public bool CheckUnique(string ControlName,locales1Item item)
    {
        TableCommand Check=new TableCommand("SELECT COUNT(*)\n" +
          "FROM locales",
            new string[]{"locale_name11"}
          ,Settings.IMDataAccessObject);
        string CheckWhere="";
        switch(ControlName){
        case "locale_name":
            CheckWhere="locale_name="+Check.Dao.ToSql(item.locale_name.GetFormattedValue(""),FieldType.Text);
            break;
        }
        Check.Where=CheckWhere;
        Check.Operation="AND NOT";
        Check.Parameters.Clear();
        ((TableCommand)Check).AddParameter("locale_name11",Urllocale_name, "","locale_name",Condition.Equal,false);
        if(Convert.ToInt32(Check.ExecuteScalar())>0)
            return false;
        else
        return true;
    }
//End Record locales1 Data Provider Class CheckUnique Method

//Record locales1 Data Provider Class PrepareInsert Method @7-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record locales1 Data Provider Class PrepareInsert Method

//Record locales1 Data Provider Class PrepareInsert Method tail @7-FCB6E20C
    }
//End Record locales1 Data Provider Class PrepareInsert Method tail

//Record locales1 Data Provider Class Insert Method @7-47B86069
    public int InsertItem(locales1Item item)
    {
        this.item = item;
//End Record locales1 Data Provider Class Insert Method

//Record locales1 Build insert @7-CDC6A961
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{locale_name}",Insert.Dao.ToSql(item.locale_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record locales1 Build insert

//Record locales1 AfterExecuteInsert @7-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record locales1 AfterExecuteInsert

//Record locales1 Data Provider Class PrepareUpdate Method @7-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record locales1 Data Provider Class PrepareUpdate Method

//Record locales1 Data Provider Class PrepareUpdate Method tail @7-FCB6E20C
    }
//End Record locales1 Data Provider Class PrepareUpdate Method tail

//Record locales1 Data Provider Class Update Method @7-E0B64FEA
    public int UpdateItem(locales1Item item)
    {
        this.item = item;
//End Record locales1 Data Provider Class Update Method

//Record locales1 BeforeBuildUpdate @7-CF26F881
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("locale_name11",Urllocale_name, "","locale_name",Condition.Equal,false);
        Update.SqlQuery.Replace("{locale_name}",Update.Dao.ToSql(item.locale_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record locales1 BeforeBuildUpdate

//Record locales1 AfterExecuteUpdate @7-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record locales1 AfterExecuteUpdate

//Record locales1 Data Provider Class PrepareDelete Method @7-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record locales1 Data Provider Class PrepareDelete Method

//Record locales1 Data Provider Class PrepareDelete Method tail @7-FCB6E20C
    }
//End Record locales1 Data Provider Class PrepareDelete Method tail

//Record locales1 Data Provider Class Delete Method @7-309DD0BA
    public int DeleteItem(locales1Item item)
    {
        this.item = item;
//End Record locales1 Data Provider Class Delete Method

//Record locales1 BeforeBuildDelete @7-3AC593BF
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("locale_name11",Urllocale_name, "","locale_name",Condition.Equal,false);
        Delete.SqlQuery.Replace("{locale_name}",Delete.Dao.ToSql(item.locale_name.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record locales1 BeforeBuildDelete

//Record locales1 BeforeBuildDelete @7-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record locales1 BeforeBuildDelete

//Record locales1 Data Provider Class GetResultSet Method @7-DE6E8EFD
    public void FillItem(locales1Item item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record locales1 Data Provider Class GetResultSet Method

//Record locales1 BeforeBuildSelect @7-AE14CFF6
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("locale_name11",Urllocale_name, "","locale_name",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record locales1 BeforeBuildSelect

//Record locales1 BeforeExecuteSelect @7-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record locales1 BeforeExecuteSelect

//Record locales1 AfterExecuteSelect @7-392D3B17
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.locale_name.SetValue(dr[i]["locale_name"],"");
        }
        else
            IsInsertMode=true;
//End Record locales1 AfterExecuteSelect

//Record locales1 AfterExecuteSelect tail @7-FCB6E20C
    }
//End Record locales1 AfterExecuteSelect tail

//Record locales1 Data Provider Class @7-FCB6E20C
}

//End Record locales1 Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

