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

namespace IssueManager.UserMaint{ //Namespace @1-3F845022

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

//Record users Item Class @4-D622485A
public class usersItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField login;
    public TextField new_pass;
    public TextField rep_pass;
    public IntegerField security_level;
    public ItemCollection security_levelItems;
    public TextField user_name;
    public TextField email;
    public IntegerField allow_upload;
    public IntegerField allow_uploadCheckedValue;
    public IntegerField allow_uploadUncheckedValue;
    public IntegerField notify_new;
    public IntegerField notify_newCheckedValue;
    public IntegerField notify_newUncheckedValue;
    public IntegerField notify_original;
    public IntegerField notify_originalCheckedValue;
    public IntegerField notify_originalUncheckedValue;
    public IntegerField notify_reassignment;
    public IntegerField notify_reassignmentCheckedValue;
    public IntegerField notify_reassignmentUncheckedValue;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        login=new TextField("", null);
        new_pass=new TextField("", null);
        rep_pass=new TextField("", null);
        security_level = new IntegerField("", null);
        security_levelItems = new ItemCollection();
        user_name=new TextField("", null);
        email=new TextField("", null);
        allow_upload = new IntegerField("", null);
        allow_uploadCheckedValue = new IntegerField("", 1);
        allow_uploadUncheckedValue = new IntegerField("", 0);
        notify_new = new IntegerField("", null);
        notify_newCheckedValue = new IntegerField("", 1);
        notify_newUncheckedValue = new IntegerField("", 0);
        notify_original = new IntegerField("", null);
        notify_originalCheckedValue = new IntegerField("", 1);
        notify_originalUncheckedValue = new IntegerField("", 0);
        notify_reassignment = new IntegerField("", null);
        notify_reassignmentCheckedValue = new IntegerField("", 1);
        notify_reassignmentUncheckedValue = new IntegerField("", 0);
    }

    public static usersItem CreateFromHttpRequest()
    {
        usersItem item = new usersItem();
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        if(DBUtility.GetInitialValue("new_pass") != null){
        item.new_pass.SetValue(DBUtility.GetInitialValue("new_pass"));
        }
        if(DBUtility.GetInitialValue("rep_pass") != null){
        item.rep_pass.SetValue(DBUtility.GetInitialValue("rep_pass"));
        }
        if(DBUtility.GetInitialValue("security_level") != null){
        item.security_level.SetValue(DBUtility.GetInitialValue("security_level"));
        }
        if(DBUtility.GetInitialValue("user_name") != null){
        item.user_name.SetValue(DBUtility.GetInitialValue("user_name"));
        }
        if(DBUtility.GetInitialValue("email") != null){
        item.email.SetValue(DBUtility.GetInitialValue("email"));
        }
        if(DBUtility.GetInitialValue("allow_upload") != null){
        if(System.Web.HttpContext.Current.Request["allow_upload"]!=null)
            item.allow_upload.Value = item.allow_uploadCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("notify_new") != null){
        if(System.Web.HttpContext.Current.Request["notify_new"]!=null)
            item.notify_new.Value = item.notify_newCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("notify_original") != null){
        if(System.Web.HttpContext.Current.Request["notify_original"]!=null)
            item.notify_original.Value = item.notify_originalCheckedValue.Value;
        }
        if(DBUtility.GetInitialValue("notify_reassignment") != null){
        if(System.Web.HttpContext.Current.Request["notify_reassignment"]!=null)
            item.notify_reassignment.Value = item.notify_reassignmentCheckedValue.Value;
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "login":
                    return this.login;
                case "new_pass":
                    return this.new_pass;
                case "rep_pass":
                    return this.rep_pass;
                case "security_level":
                    return this.security_level;
                case "user_name":
                    return this.user_name;
                case "email":
                    return this.email;
                case "allow_upload":
                    return this.allow_upload;
                case "notify_new":
                    return this.notify_new;
                case "notify_original":
                    return this.notify_original;
                case "notify_reassignment":
                    return this.notify_reassignment;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "login":
                    this.login = (TextField)value;
                    break;
                case "new_pass":
                    this.new_pass = (TextField)value;
                    break;
                case "rep_pass":
                    this.rep_pass = (TextField)value;
                    break;
                case "security_level":
                    this.security_level = (IntegerField)value;
                    break;
                case "user_name":
                    this.user_name = (TextField)value;
                    break;
                case "email":
                    this.email = (TextField)value;
                    break;
                case "allow_upload":
                    this.allow_upload = (IntegerField)value;
                    break;
                case "notify_new":
                    this.notify_new = (IntegerField)value;
                    break;
                case "notify_original":
                    this.notify_original = (IntegerField)value;
                    break;
                case "notify_reassignment":
                    this.notify_reassignment = (IntegerField)value;
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

    public void Validate(usersDataProvider provider)
    {
//End Record users Item Class

//login validate @10-00CF295F
        if(login.Value==null||login.Value.ToString()=="")
            errors.Add("login",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.CCS_Login));
        if(login!=null&&!provider.CheckUnique("login",this))
                errors.Add("login",String.Format(Resources.strings.CCS_UniqueValue,Resources.strings.CCS_Login));
//End login validate

//user_name validate @13-41927DA2
        if(user_name.Value==null||user_name.Value.ToString()=="")
            errors.Add("user_name",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_name));
//End user_name validate

//email validate @14-F318792A
        if(email.Value==null||email.Value.ToString()=="")
            errors.Add("email",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_email));
        if(email.Value!=null){
            Regex mask = new Regex(@"^[\w\.-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase|RegexOptions.Multiline);
            if(!mask.Match(email.Value.ToString()).Success)
                errors.Add("email",String.Format(Resources.strings.CCS_MaskValidation,Resources.strings.im_email));
        }
//End email validate

//Record users Event OnValidate. Action Custom Code @48-2A29BDB7
    // -------------------------
		if (new_pass.Value != null)
		{
			if (new_pass.CompareTo(rep_pass) == 0)
			{
				if (provider.Urluser_id != null)
					Settings.IMDataAccessObject.ExecuteNonQuery("UPDATE users SET pass="+Settings.IMDataAccessObject.ToSql(new_pass.Value.ToString(), FieldType.Text)+" WHERE user_id="+provider.Urluser_id.Value);
			}
			else
			{
				//errors.Add("rep_pass", rm.GetString("im_passwords_differ"));
				errors.Add("rep_pass", Resources.strings.im_passwords_differ);
			}
		}
		else if (provider.Urluser_id == null)
		{
			//errors.Add("new_pass", String.Format(rm.GetString("CCS_RequiredField"), rm.GetString("CCS_Password")));
			errors.Add("new_pass", String.Format(Resources.strings.CCS_RequiredField, Resources.strings.CCS_Password));
		}
    // -------------------------
//End Record users Event OnValidate. Action Custom Code

//Record users Item Class tail @4-F5FC18C5
    }
}
//End Record users Item Class tail

//Record users Data Provider Class @4-E483AB36
public class usersDataProvider:RecordDataProviderBase
{
//End Record users Data Provider Class

//Record users Data Provider Class Variables @4-4A407A39
    protected usersItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter Urluser_id;
    public TextParameter Ctrllogin;
    public IntegerParameter Ctrlsecurity_level;
    public TextParameter Ctrluser_name;
    public TextParameter Ctrlemail;
    public IntegerParameter Ctrlallow_upload;
    public IntegerParameter Ctrlnotify_new;
    public IntegerParameter Ctrlnotify_original;
    public IntegerParameter Ctrlnotify_reassignment;
    public TextParameter Ctrlnew_pass;
//End Record users Data Provider Class Variables

//Record users Data Provider Class Constructor @4-8A9FD988
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"user_id9"},Settings.IMDataAccessObject);
         Insert=new TableCommand("INSERT INTO users(login, security_level, user_name, email, allow_upload, \n" +
          "notify_new, notify_original, notify_reassignment, pass) VALUES ({login}, \n" +
          "{security_level}, {user_name}, {email}, {allow_upload}, {notify_new}, {notify_original}, \n" +
          "{notify_reassignment}, {pass})", new string[0],Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE users SET login={login}, security_level={security_level}, \n" +
          "user_name={user_name}, email={email}, allow_upload={allow_upload}, notify_new={notify_new}" +
          ", \n" +
          "notify_original={notify_original}, notify_reassignment={notify_reassignment}", new string[]{"user_id9"},Settings.IMDataAccessObject);
         Delete=new TableCommand("DELETE FROM users", new string[]{"user_id9"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record users Data Provider Class Constructor

//Record users Data Provider Class LoadParams Method @4-6A4B88F3
    protected bool LoadParams()
    {
        return Urluser_id!=null;
    }
//End Record users Data Provider Class LoadParams Method

//Record users Data Provider Class CheckUnique Method @4-3D95906D
    public bool CheckUnique(string ControlName,usersItem item)
    {
        TableCommand Check=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users",
            new string[]{"user_id9"}
          ,Settings.IMDataAccessObject);
        string CheckWhere="";
        switch(ControlName){
        case "login":
            CheckWhere="login="+Check.Dao.ToSql(item.login.GetFormattedValue(""),FieldType.Text);
            break;
        }
        Check.Where=CheckWhere;
        Check.Operation="AND NOT";
        Check.Parameters.Clear();
        ((TableCommand)Check).AddParameter("user_id9",Urluser_id, "","user_id",Condition.Equal,false);
        if(Convert.ToInt32(Check.ExecuteScalar())>0)
            return false;
        else
        return true;
    }
//End Record users Data Provider Class CheckUnique Method

//Record users Data Provider Class PrepareInsert Method @4-CE83D355
    override protected void PrepareInsert()
    {
        CmdExecution = true;
//End Record users Data Provider Class PrepareInsert Method

//Record users Data Provider Class PrepareInsert Method tail @4-FCB6E20C
    }
//End Record users Data Provider Class PrepareInsert Method tail

//Record users Data Provider Class Insert Method @4-E2C0BE06
    public int InsertItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Insert Method

//Record users Build insert @4-1550186E
        Insert.Parameters.Clear();
        Insert.SqlQuery.Replace("{login}",Insert.Dao.ToSql(item.login.Value==null?null:item.login.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{security_level}",Insert.Dao.ToSql(item.security_level.Value==null?null:item.security_level.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{user_name}",Insert.Dao.ToSql(item.user_name.Value==null?null:item.user_name.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{email}",Insert.Dao.ToSql(item.email.Value==null?null:item.email.GetFormattedValue(""),FieldType.Text));
        Insert.SqlQuery.Replace("{allow_upload}",Insert.Dao.ToSql(item.allow_upload.Value==null?null:item.allow_upload.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{notify_new}",Insert.Dao.ToSql(item.notify_new.Value==null?null:item.notify_new.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{notify_original}",Insert.Dao.ToSql(item.notify_original.Value==null?null:item.notify_original.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{notify_reassignment}",Insert.Dao.ToSql(item.notify_reassignment.Value==null?null:item.notify_reassignment.GetFormattedValue(""),FieldType.Integer));
        Insert.SqlQuery.Replace("{pass}",Insert.Dao.ToSql(item.new_pass.Value==null?null:item.new_pass.GetFormattedValue(""),FieldType.Text));
        object result=0;Exception E=null;
        try{
            result=ExecuteInsert();
        }catch(Exception e){
            E=e;}
        finally{
//End Record users Build insert

//Record users AfterExecuteInsert @4-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users AfterExecuteInsert

//Record users Data Provider Class PrepareUpdate Method @4-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record users Data Provider Class PrepareUpdate Method

//Record users Data Provider Class PrepareUpdate Method tail @4-FCB6E20C
    }
//End Record users Data Provider Class PrepareUpdate Method tail

//Record users Data Provider Class Update Method @4-C223194F
    public int UpdateItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Update Method

//Record users BeforeBuildUpdate @4-24AD0555
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("user_id9",Urluser_id, "","user_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{login}",Update.Dao.ToSql(item.login.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{security_level}",Update.Dao.ToSql(item.security_level.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{user_name}",Update.Dao.ToSql(item.user_name.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{email}",Update.Dao.ToSql(item.email.GetFormattedValue(""),FieldType.Text));
        Update.SqlQuery.Replace("{allow_upload}",Update.Dao.ToSql(item.allow_upload.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{notify_new}",Update.Dao.ToSql(item.notify_new.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{notify_original}",Update.Dao.ToSql(item.notify_original.GetFormattedValue(""),FieldType.Integer));
        Update.SqlQuery.Replace("{notify_reassignment}",Update.Dao.ToSql(item.notify_reassignment.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteUpdate();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users BeforeBuildUpdate

//Record users AfterExecuteUpdate @4-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record users AfterExecuteUpdate

//Record users Data Provider Class PrepareDelete Method @4-505F9025
    override protected void PrepareDelete()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record users Data Provider Class PrepareDelete Method

//Record users Data Provider Class PrepareDelete Method tail @4-FCB6E20C
    }
//End Record users Data Provider Class PrepareDelete Method tail

//Record users Data Provider Class Delete Method @4-B98CC950
    public int DeleteItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Delete Method

//Record users BeforeBuildDelete @4-03AC83F3
        Delete.Parameters.Clear();
        ((TableCommand)Delete).AddParameter("user_id9",Urluser_id, "","user_id",Condition.Equal,false);
        Delete.SqlQuery.Replace("{login}",Delete.Dao.ToSql(item.login.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{security_level}",Delete.Dao.ToSql(item.security_level.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{user_name}",Delete.Dao.ToSql(item.user_name.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{email}",Delete.Dao.ToSql(item.email.GetFormattedValue(""),FieldType.Text));
        Delete.SqlQuery.Replace("{allow_upload}",Delete.Dao.ToSql(item.allow_upload.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{notify_new}",Delete.Dao.ToSql(item.notify_new.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{notify_original}",Delete.Dao.ToSql(item.notify_original.GetFormattedValue(""),FieldType.Integer));
        Delete.SqlQuery.Replace("{notify_reassignment}",Delete.Dao.ToSql(item.notify_reassignment.GetFormattedValue(""),FieldType.Integer));
        object result=0;Exception E=null;
        try{
            result=ExecuteDelete();
        }catch(Exception e){
            E=e;}
        finally{
            if(!IsParametersPassed)
                throw new Exception(Resources.strings.CCS_CustomOperationError_MissingParameters);
//End Record users BeforeBuildDelete

//Record users BeforeBuildDelete @4-33B45808
            if(E!=null) throw(E);
        }
        return (int)result;
    }
//End Record users BeforeBuildDelete

//Record users Data Provider Class GetResultSet Method @4-7B048C8D
    public void FillItem(usersItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record users Data Provider Class GetResultSet Method

//Record users BeforeBuildSelect @4-D55F34EC
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("user_id9",Urluser_id, "","user_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record users BeforeBuildSelect

//Record users BeforeExecuteSelect @4-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record users BeforeExecuteSelect

//Record users AfterExecuteSelect @4-3D10F280
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.login.SetValue(dr[i]["login"],"");
            item.security_level.SetValue(dr[i]["security_level"],"");
            item.user_name.SetValue(dr[i]["user_name"],"");
            item.email.SetValue(dr[i]["email"],"");
            item.allow_upload.SetValue(dr[i]["allow_upload"],"");
            item.notify_new.SetValue(dr[i]["notify_new"],"");
            item.notify_original.SetValue(dr[i]["notify_original"],"");
            item.notify_reassignment.SetValue(dr[i]["notify_reassignment"],"");
        }
        else
            IsInsertMode=true;
//End Record users AfterExecuteSelect

//ListBox security_level AfterExecuteSelect @12-F3D9051C
        
item.security_levelItems.Add("1",Resources.strings.im_level_1);
item.security_levelItems.Add("2",Resources.strings.im_level_2);
item.security_levelItems.Add("3",Resources.strings.im_level_3);
//End ListBox security_level AfterExecuteSelect

//Record users AfterExecuteSelect tail @4-FCB6E20C
    }
//End Record users AfterExecuteSelect tail

//Record users Data Provider Class @4-FCB6E20C
}

//End Record users Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

