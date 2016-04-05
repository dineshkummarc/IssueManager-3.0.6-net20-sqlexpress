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

namespace IssueManager.AppSettings{ //Namespace @1-B4B13ED0

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

//Record settings Item Class @3-DA65BB45
public class settingsItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerField upload_enabled;
    public IntegerField upload_enabledCheckedValue;
    public IntegerField upload_enabledUncheckedValue;
    public MemoField file_extensions;
    public MemoField file_path;
    public TextField notify_new_from;
    public MemoField notify_new_subject;
    public MemoField notify_new_body;
    public TextField notify_change_from;
    public MemoField notify_change_subject;
    public MemoField notify_change_body;
    public TextField email_component;
    public ItemCollection email_componentItems;
    public TextField smtp_host;
    public NameValueCollection errors=new NameValueCollection();
    public settingsItem()
    {
        upload_enabled = new IntegerField("", null);
        upload_enabledCheckedValue = new IntegerField("", 1);
        upload_enabledUncheckedValue = new IntegerField("", 0);
        file_extensions=new MemoField("", null);
        file_path=new MemoField("", null);
        notify_new_from=new TextField("", null);
        notify_new_subject=new MemoField("", null);
        notify_new_body=new MemoField("", null);
        notify_change_from=new TextField("", null);
        notify_change_subject=new MemoField("", null);
        notify_change_body=new MemoField("", null);
        email_component = new TextField("", null);
        email_componentItems = new ItemCollection();
        smtp_host=new TextField("", null);
    }

    public static settingsItem CreateFromHttpRequest()
    {
        settingsItem item = new settingsItem();
        if(DBUtility.GetInitialValue("upload_enabled") != null){
        if(System.Web.HttpContext.Current.Request["upload_enabled"]!=null)
            item.upload_enabled.Value = item.upload_enabledCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("file_extensions") != null){
        item.file_extensions.SetValue(DBUtility.GetInitialValue("file_extensions"));
        }
        if(DBUtility.GetInitialValue("file_path") != null){
        item.file_path.SetValue(DBUtility.GetInitialValue("file_path"));
        }
        if(DBUtility.GetInitialValue("notify_new_from") != null){
        item.notify_new_from.SetValue(DBUtility.GetInitialValue("notify_new_from"));
        }
        if(DBUtility.GetInitialValue("notify_new_subject") != null){
        item.notify_new_subject.SetValue(DBUtility.GetInitialValue("notify_new_subject"));
        }
        if(DBUtility.GetInitialValue("notify_new_body") != null){
        item.notify_new_body.SetValue(DBUtility.GetInitialValue("notify_new_body"));
        }
        if(DBUtility.GetInitialValue("notify_change_from") != null){
        item.notify_change_from.SetValue(DBUtility.GetInitialValue("notify_change_from"));
        }
        if(DBUtility.GetInitialValue("notify_change_subject") != null){
        item.notify_change_subject.SetValue(DBUtility.GetInitialValue("notify_change_subject"));
        }
        if(DBUtility.GetInitialValue("notify_change_body") != null){
        item.notify_change_body.SetValue(DBUtility.GetInitialValue("notify_change_body"));
        }
        if(DBUtility.GetInitialValue("email_component") != null){
        item.email_component.SetValue(DBUtility.GetInitialValue("email_component"));
        }
        if(DBUtility.GetInitialValue("smtp_host") != null){
        item.smtp_host.SetValue(DBUtility.GetInitialValue("smtp_host"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "upload_enabled":
                    return this.upload_enabled;
                case "file_extensions":
                    return this.file_extensions;
                case "file_path":
                    return this.file_path;
                case "notify_new_from":
                    return this.notify_new_from;
                case "notify_new_subject":
                    return this.notify_new_subject;
                case "notify_new_body":
                    return this.notify_new_body;
                case "notify_change_from":
                    return this.notify_change_from;
                case "notify_change_subject":
                    return this.notify_change_subject;
                case "notify_change_body":
                    return this.notify_change_body;
                case "email_component":
                    return this.email_component;
                case "smtp_host":
                    return this.smtp_host;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "upload_enabled":
                    this.upload_enabled = (IntegerField)value;
                    break;
                case "file_extensions":
                    this.file_extensions = (MemoField)value;
                    break;
                case "file_path":
                    this.file_path = (MemoField)value;
                    break;
                case "notify_new_from":
                    this.notify_new_from = (TextField)value;
                    break;
                case "notify_new_subject":
                    this.notify_new_subject = (MemoField)value;
                    break;
                case "notify_new_body":
                    this.notify_new_body = (MemoField)value;
                    break;
                case "notify_change_from":
                    this.notify_change_from = (TextField)value;
                    break;
                case "notify_change_subject":
                    this.notify_change_subject = (MemoField)value;
                    break;
                case "notify_change_body":
                    this.notify_change_body = (MemoField)value;
                    break;
                case "email_component":
                    this.email_component = (TextField)value;
                    break;
                case "smtp_host":
                    this.smtp_host = (TextField)value;
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

    public void Validate(settingsDataProvider provider)
    {
//End Record settings Item Class

//Record settings Event OnValidate. Action Custom Code @19-2A29BDB7
    // -------------------------
	string msg = "";
	//msg = rm.GetString("im_error_upload_folder");
	msg = Resources.strings.im_error_upload_folder;
    if (!System.IO.Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(file_path.GetFormattedValue())))
		errors.Add("file_path",msg);
    // -------------------------
//End Record settings Event OnValidate. Action Custom Code

//Record settings Item Class tail @3-F5FC18C5
    }
}
//End Record settings Item Class tail

//Record settings Data Provider Class @3-671F7C4B
public class settingsDataProvider:RecordDataProviderBase
{
//End Record settings Data Provider Class

//Record settings Data Provider Class Variables @3-18136724
    protected DataCommand email_componentDataCommand;
    protected settingsItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urlsettings_id;
//End Record settings Data Provider Class Variables

//Record settings Data Provider Class Constructor @3-840789B7
    public settingsDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM settings {SQL_Where} {SQL_OrderBy}", new string[]{"settings_id7"},Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE settings SET upload_enabled={upload_enabled}, \n" +
          "file_extensions={file_extensions}, file_path={file_path}, notify_new_from={notify_new_from" +
          "}, \n" +
          "notify_new_subject={notify_new_subject}, notify_new_body={notify_new_body}, \n" +
          "notify_change_from={notify_change_from}, notify_change_subject={notify_change_subject}, \n" +
          "notify_change_body={notify_change_body}, email_component={email_component}, \n" +
          "smtp_host={smtp_host}", new string[]{"settings_id7"},Settings.IMDataAccessObject);
         email_componentDataCommand=new TableCommand("SELECT * \n" +
          "FROM email_components {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record settings Data Provider Class Constructor

//Record settings Data Provider Class LoadParams Method @3-54C98841
    protected bool LoadParams()
    {
        return Urlsettings_id!=null;
    }
//End Record settings Data Provider Class LoadParams Method

//Record settings Data Provider Class CheckUnique Method @3-3D3AB838
    public bool CheckUnique(string ControlName,settingsItem item)
    {
        return true;
    }
//End Record settings Data Provider Class CheckUnique Method

//Record settings Data Provider Class PrepareUpdate Method @3-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record settings Data Provider Class PrepareUpdate Method

//Record settings Data Provider Class PrepareUpdate Method tail @3-FCB6E20C
    }
//End Record settings Data Provider Class PrepareUpdate Method tail

//Record settings Data Provider Class Update Method @3-A0EFFA72
    public int UpdateItem(settingsItem item)
    {
        this.item = item;
//End Record settings Data Provider Class Update Method

//Record settings BeforeBuildUpdate @3-BA14FCDD
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("settings_id7",Urlsettings_id, "","settings_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{upload_enabled}",Update.Dao.ToSql(item.upload_enabled.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{file_extensions}",Update.Dao.ToSql(item.file_extensions.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{file_path}",Update.Dao.ToSql(item.file_path.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{notify_new_from}",Update.Dao.ToSql(item.notify_new_from.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{notify_new_subject}",Update.Dao.ToSql(item.notify_new_subject.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{notify_new_body}",Update.Dao.ToSql(item.notify_new_body.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{notify_change_from}",Update.Dao.ToSql(item.notify_change_from.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{notify_change_subject}",Update.Dao.ToSql(item.notify_change_subject.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{notify_change_body}",Update.Dao.ToSql(item.notify_change_body.GetFormattedValue(""),FieldType.Memo));
        Update.SqlQuery.Replace("{email_component}",Update.Dao.ToSql(item.email_component.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{smtp_host}",Update.Dao.ToSql(item.smtp_host.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record settings BeforeBuildUpdate

//Record settings AfterExecuteUpdate @3-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record settings AfterExecuteUpdate

//Record settings Data Provider Class GetResultSet Method @3-965AEF97
    public void FillItem(settingsItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record settings Data Provider Class GetResultSet Method

//Record settings BeforeBuildSelect @3-5D98B9C3
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("settings_id7",Urlsettings_id, "","settings_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record settings BeforeBuildSelect

//Record settings BeforeExecuteSelect @3-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record settings BeforeExecuteSelect

//Record settings AfterExecuteSelect @3-B111F671
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.upload_enabled.SetValue(dr[i]["upload_enabled"],"");
            item.file_extensions.SetValue(dr[i]["file_extensions"],"");
            item.file_path.SetValue(dr[i]["file_path"],"");
            item.notify_new_from.SetValue(dr[i]["notify_new_from"],"");
            item.notify_new_subject.SetValue(dr[i]["notify_new_subject"],"");
            item.notify_new_body.SetValue(dr[i]["notify_new_body"],"");
            item.notify_change_from.SetValue(dr[i]["notify_change_from"],"");
            item.notify_change_subject.SetValue(dr[i]["notify_change_subject"],"");
            item.notify_change_body.SetValue(dr[i]["notify_change_body"],"");
            item.email_component.SetValue(dr[i]["email_component"],"");
            item.smtp_host.SetValue(dr[i]["smtp_host"],"");
        }
        else
            IsInsertMode=true;
        DataRowCollection ListBoxSource=null;
//End Record settings AfterExecuteSelect

//ListBox email_component Initialize Data Source @23-57EF7B82
        int email_componenttableIndex = 0;
        email_componentDataCommand.OrderBy = "";
        email_componentDataCommand.Parameters.Clear();
//End ListBox email_component Initialize Data Source

//ListBox email_component BeforeExecuteSelect @23-6600DD2F
        try{
            ListBoxSource=email_componentDataCommand.Execute().Tables[email_componenttableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox email_component BeforeExecuteSelect

//ListBox email_component AfterExecuteSelect @23-A6EC135C
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["component_name"];
            string key = (new TextField("", ListBoxSource[li]["component_id"])).GetFormattedValue("");
            item.email_componentItems.Add(key,val);
        }
//End ListBox email_component AfterExecuteSelect

//Record settings AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record settings AfterExecuteSelect tail

//Record settings Data Provider Class @3-FCB6E20C
}

//End Record settings Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

