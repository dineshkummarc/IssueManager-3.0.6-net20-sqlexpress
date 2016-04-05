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

namespace IssueManager.FileMaint{ //Namespace @1-77C51B4D

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

//Record files Item Class @3-6A74ABDB
public class filesItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField file;
    public object fileHref;
    public LinkParameterCollection fileHrefParameters;
    public TextField file_name;
    public IntegerField uploaded_by;
    public ItemCollection uploaded_byItems;
    public DateField date_uploaded;
    public TextField date_format;
    public NameValueCollection errors=new NameValueCollection();
    public filesItem()
    {
        file = new TextField("",null);
        fileHrefParameters = new LinkParameterCollection();
        file_name=new TextField("", null);
        uploaded_by = new IntegerField("", null);
        uploaded_byItems = new ItemCollection();
        date_uploaded=new DateField("G", null);
        date_format=new TextField("", null);
    }

    public static filesItem CreateFromHttpRequest()
    {
        filesItem item = new filesItem();
        if(DBUtility.GetInitialValue("file") != null){
        item.file.SetValue(DBUtility.GetInitialValue("file"));
        }
        if(DBUtility.GetInitialValue("file_name") != null){
        }
        if(DBUtility.GetInitialValue("uploaded_by") != null){
        item.uploaded_by.SetValue(DBUtility.GetInitialValue("uploaded_by"));
        }
        if(DBUtility.GetInitialValue("date_uploaded") != null){
        item.date_uploaded.SetValue(DBUtility.GetInitialValue("date_uploaded"));
        }
        if(DBUtility.GetInitialValue("date_format") != null){
        item.date_format.SetValue(DBUtility.GetInitialValue("date_format"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "file":
                    return this.file;
                case "file_name":
                    return this.file_name;
                case "uploaded_by":
                    return this.uploaded_by;
                case "date_uploaded":
                    return this.date_uploaded;
                case "date_format":
                    return this.date_format;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "file":
                    this.file = (TextField)value;
                    break;
                case "file_name":
                    this.file_name = (TextField)value;
                    break;
                case "uploaded_by":
                    this.uploaded_by = (IntegerField)value;
                    break;
                case "date_uploaded":
                    this.date_uploaded = (DateField)value;
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

    public void Validate(filesDataProvider provider)
    {
//End Record files Item Class

//file_name validate @13-C021269B
        if(file_name.Value==null||file_name.Value.ToString()=="")
            errors.Add("file_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_file_name));
//End file_name validate

//uploaded_by validate @9-A077FCFE
        if(uploaded_by.Value==null||uploaded_by.Value.ToString()=="")
            errors.Add("uploaded_by",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_uploaded_by));
//End uploaded_by validate

//date_uploaded validate @10-192A9B4F
        if(date_uploaded.Value==null||date_uploaded.Value.ToString()=="")
            errors.Add("date_uploaded",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_date_uploaded));
//End date_uploaded validate

//Record files Item Class tail @3-F5FC18C5
    }
}
//End Record files Item Class tail

//Record files Data Provider Class @3-A2EFD621
public class filesDataProvider:RecordDataProviderBase
{
//End Record files Data Provider Class

//Record files Data Provider Class Variables @3-C77E15FE
    protected DataCommand uploaded_byDataCommand;
    protected filesItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlfile_id;
//End Record files Data Provider Class Variables

//Record files Data Provider Class Constructor @3-2A076041
    public filesDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM files {SQL_Where} {SQL_OrderBy}", new string[]{"file_id7"},Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE files SET file_name={file_name}, uploaded_by={uploaded_by}, \n" +
          "date_uploaded={date_uploaded}", new string[]{"file_id7"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM files", new string[]{"file_id7"},Settings.IMDataAccessObject);
         uploaded_byDataCommand=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record files Data Provider Class Constructor

//Record files Data Provider Class LoadParams Method @3-74C495A9
    protected bool LoadParams()
    {
        return Urlfile_id!=null;
    }
//End Record files Data Provider Class LoadParams Method

//Record files Data Provider Class CheckUnique Method @3-DE0DA836
    public bool CheckUnique(string ControlName,filesItem item)
    {
        return true;
    }
//End Record files Data Provider Class CheckUnique Method

//Record files Data Provider Class PrepareUpdate Method @3-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record files Data Provider Class PrepareUpdate Method

//Record files Data Provider Class PrepareUpdate Method tail @3-FCB6E20C
    }
//End Record files Data Provider Class PrepareUpdate Method tail

//Record files Data Provider Class Update Method @3-98CE029C
    public int UpdateItem(filesItem item)
    {
        this.item = item;
//End Record files Data Provider Class Update Method

//Record files BeforeBuildUpdate @3-E0C7FB71
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("file_id7",Urlfile_id, "","file_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{file_name}",Update.Dao.ToSql(item.file_name.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{uploaded_by}",Update.Dao.ToSql(item.uploaded_by.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{date_uploaded}",Update.Dao.ToSql(item.date_uploaded.GetFormattedValue(Update.DateFormat),FieldType.Date));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record files BeforeBuildUpdate

//Record files AfterExecuteUpdate @3-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record files AfterExecuteUpdate

//Record files Data Provider Class PrepareDelete Method @3-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record files Data Provider Class PrepareDelete Method

//Record files Data Provider Class PrepareDelete Method tail @3-FCB6E20C
    }
//End Record files Data Provider Class PrepareDelete Method tail

//Record files Data Provider Class Delete Method @3-E361D283
    public int DeleteItem(filesItem item)
    {
        this.item = item;
//End Record files Data Provider Class Delete Method

//Record files BeforeBuildDelete @3-8F310276
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("file_id7",Urlfile_id, "","file_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{file_name}",Delete.Dao.ToSql(item.file_name.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{uploaded_by}",Delete.Dao.ToSql(item.uploaded_by.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{date_uploaded}",Delete.Dao.ToSql(item.date_uploaded.GetFormattedValue(Delete.DateFormat),FieldType.Date));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record files BeforeBuildDelete

//Record files BeforeBuildDelete @3-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record files BeforeBuildDelete

//Record files Data Provider Class GetResultSet Method @3-45A0AE7E
    public void FillItem(filesItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record files Data Provider Class GetResultSet Method

//Record files BeforeBuildSelect @3-2933A771
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("file_id7",Urlfile_id, "","file_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record files BeforeBuildSelect

//Record files BeforeExecuteSelect @3-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record files BeforeExecuteSelect

//Record files AfterExecuteSelect @3-44ACF026
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.file.SetValue(dr[i]["file_name"],"");
            item.fileHref = dr[i]["file_name"];
            item.file_name.SetValue(dr[i]["file_name"],"");
            item.uploaded_by.SetValue(dr[i]["uploaded_by"],"");
            item.date_uploaded.SetValue(dr[i]["date_uploaded"],Select.DateFormat);
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record files AfterExecuteSelect

//ListBox uploaded_by Initialize Data Source @9-A73CB20E
        int uploaded_bytableIndex = 0;
        uploaded_byDataCommand.OrderBy = "user_name";
        uploaded_byDataCommand.Parameters.Clear();
//End ListBox uploaded_by Initialize Data Source

//ListBox uploaded_by BeforeExecuteSelect @9-29C9884D
        try{
            ListBoxSource=uploaded_byDataCommand.Execute().Tables[uploaded_bytableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox uploaded_by BeforeExecuteSelect

//ListBox uploaded_by AfterExecuteSelect @9-AAB9AEE3
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["user_name"];
            string key = (new IntegerField("", ListBoxSource[li]["user_id"])).GetFormattedValue("");
            item.uploaded_byItems.Add(key,val);
        }
//End ListBox uploaded_by AfterExecuteSelect

//Record files AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record files AfterExecuteSelect tail

//Record files Data Provider Class @3-FCB6E20C
}

//End Record files Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

