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

namespace IssueManager.UserProfile{ //Namespace @1-BEE63D3B

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

//Record users Item Class @3-86743328
public class usersItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField user_name;
    public TextField login;
    public TextField old_pass;
    public TextField new_pass;
    public TextField rep_pass;
    public TextField email;
    public IntegerField notify_new;
    public IntegerField notify_newCheckedValue;
    public IntegerField notify_newUncheckedValue;
    public IntegerField notify_original;
    public IntegerField notify_originalCheckedValue;
    public IntegerField notify_originalUncheckedValue;
    public IntegerField notify_reassignment;
    public IntegerField notify_reassignmentCheckedValue;
    public IntegerField notify_reassignmentUncheckedValue;
    public BooleanField allow_upload;
    public TextField security_level;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        user_name=new TextField("", null);
        login=new TextField("", null);
        old_pass=new TextField("", null);
        new_pass=new TextField("", null);
        rep_pass=new TextField("", null);
        email=new TextField("", null);
        notify_new = new IntegerField("", null);
        notify_newCheckedValue = new IntegerField("", 1);
        notify_newUncheckedValue = new IntegerField("", 0);
        notify_original = new IntegerField("", null);
        notify_originalCheckedValue = new IntegerField("", 1);
        notify_originalUncheckedValue = new IntegerField("", 0);
        notify_reassignment = new IntegerField("", null);
        notify_reassignmentCheckedValue = new IntegerField("", 1);
        notify_reassignmentUncheckedValue = new IntegerField("", 0);
        allow_upload=new BooleanField("res:im_yes;res:im_no", null);
        security_level=new TextField("", null);
    }

    public static usersItem CreateFromHttpRequest()
    {
        usersItem item = new usersItem();
        if(DBUtility.GetInitialValue("user_name") != null){
        item.user_name.SetValue(DBUtility.GetInitialValue("user_name"));
        }
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        if(DBUtility.GetInitialValue("old_pass") != null){
        item.old_pass.SetValue(DBUtility.GetInitialValue("old_pass"));
        }
        if(DBUtility.GetInitialValue("new_pass") != null){
        item.new_pass.SetValue(DBUtility.GetInitialValue("new_pass"));
        }
        if(DBUtility.GetInitialValue("rep_pass") != null){
        item.rep_pass.SetValue(DBUtility.GetInitialValue("rep_pass"));
        }
        if(DBUtility.GetInitialValue("email") != null){
        item.email.SetValue(DBUtility.GetInitialValue("email"));
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
        if(DBUtility.GetInitialValue("allow_upload") != null){
        item.allow_upload.SetValue(DBUtility.GetInitialValue("allow_upload"));
        }
        if(DBUtility.GetInitialValue("security_level") != null){
        item.security_level.SetValue(DBUtility.GetInitialValue("security_level"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user_name":
                    return this.user_name;
                case "login":
                    return this.login;
                case "old_pass":
                    return this.old_pass;
                case "new_pass":
                    return this.new_pass;
                case "rep_pass":
                    return this.rep_pass;
                case "email":
                    return this.email;
                case "notify_new":
                    return this.notify_new;
                case "notify_original":
                    return this.notify_original;
                case "notify_reassignment":
                    return this.notify_reassignment;
                case "allow_upload":
                    return this.allow_upload;
                case "security_level":
                    return this.security_level;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_name":
                    this.user_name = (TextField)value;
                    break;
                case "login":
                    this.login = (TextField)value;
                    break;
                case "old_pass":
                    this.old_pass = (TextField)value;
                    break;
                case "new_pass":
                    this.new_pass = (TextField)value;
                    break;
                case "rep_pass":
                    this.rep_pass = (TextField)value;
                    break;
                case "email":
                    this.email = (TextField)value;
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
                case "allow_upload":
                    this.allow_upload = (BooleanField)value;
                    break;
                case "security_level":
                    this.security_level = (TextField)value;
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

//email validate @9-F318792A
        if(email.Value==null||email.Value.ToString()=="")
            errors.Add("email",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.im_email));
        if(email.Value!=null){
            Regex mask = new Regex(@"^[\w\.-]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]+$",RegexOptions.IgnoreCase|RegexOptions.Multiline);
            if(!mask.Match(email.Value.ToString()).Success)
                errors.Add("email",String.Format(Resources.strings.CCS_MaskValidation,Resources.strings.im_email));
        }
//End email validate

//Record users Event OnValidate. Action Custom Code @30-2A29BDB7
    // -------------------------
		if (new_pass.Value != null)
		{
			if (new_pass.CompareTo(rep_pass) == 0)
			{
				if (old_pass.Value != null && IMUtils.Lookup("user_id", "users", "login="+Settings.IMDataAccessObject.ToSql(DBUtility.UserLogin, FieldType.Text)+" AND pass="+Settings.IMDataAccessObject.ToSql(old_pass.Value.ToString(), FieldType.Text)) != null)
				{
					Settings.IMDataAccessObject.ExecuteNonQuery("UPDATE users SET pass="+Settings.IMDataAccessObject.ToSql(new_pass.Value.ToString(), FieldType.Text)+" WHERE user_id="+DBUtility.UserId);
				}
				else
				{
					//errors.Add("old_pass", rm.GetString("im_invalid_password"));
					errors.Add("old_pass", Resources.strings.im_invalid_password);
				}
			}
			else
			{
				//errors.Add("rep_pass", rm.GetString("im_passwords_differ"));
				errors.Add("rep_pass", Resources.strings.im_passwords_differ);
			}
		}
		else if (old_pass.Value != null)
		{
			//errors.Add("old_pass", rm.GetString("im_password_required"));
			errors.Add("old_pass", Resources.strings.im_password_required);
		}
    // -------------------------
//End Record users Event OnValidate. Action Custom Code

//Record users Item Class tail @3-F5FC18C5
    }
}
//End Record users Item Class tail

//Record users Data Provider Class @3-E483AB36
public class usersDataProvider:RecordDataProviderBase
{
//End Record users Data Provider Class

//Record users Data Provider Class Variables @3-E34DFC14
    protected usersItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public IntegerParameter SesUserID;
//End Record users Data Provider Class Variables

//Record users Data Provider Class Constructor @3-6DB0C5D6
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{"UserID5"},Settings.IMDataAccessObject);
         Update=new TableCommand("UPDATE users SET email={email}, notify_new={notify_new}, \n" +
          "notify_original={notify_original}, notify_reassignment={notify_reassignment}", new string[]{"UserID5"},Settings.IMDataAccessObject);
        Select.OrderBy="";
    }
//End Record users Data Provider Class Constructor

//Record users Data Provider Class LoadParams Method @3-D7D56122
    protected bool LoadParams()
    {
        return SesUserID!=null;
    }
//End Record users Data Provider Class LoadParams Method

//Record users Data Provider Class CheckUnique Method @3-4D79C605
    public bool CheckUnique(string ControlName,usersItem item)
    {
        TableCommand Check=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users",
            new string[]{"UserID5"}
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
        ((TableCommand)Check).AddParameter("UserID5",SesUserID, "","user_id",Condition.Equal,false);
        if(Convert.ToInt32(Check.ExecuteScalar())>0)
            return false;
        else
        return true;
    }
//End Record users Data Provider Class CheckUnique Method

//Record users Data Provider Class PrepareUpdate Method @3-6598D2D5
    override protected void PrepareUpdate()
    {
        CmdExecution = true;
        IsParametersPassed = LoadParams();
//End Record users Data Provider Class PrepareUpdate Method

//Record users Data Provider Class PrepareUpdate Method tail @3-FCB6E20C
    }
//End Record users Data Provider Class PrepareUpdate Method tail

//Record users Data Provider Class Update Method @3-C223194F
    public int UpdateItem(usersItem item)
    {
        this.item = item;
//End Record users Data Provider Class Update Method

//Record users BeforeBuildUpdate @3-0AC87AD4
        Update.Parameters.Clear();
        ((TableCommand)Update).AddParameter("UserID5",SesUserID, "","user_id",Condition.Equal,false);
        Update.SqlQuery.Replace("{email}",Update.Dao.ToSql(item.email.GetFormattedValue(""),FieldType.Text));
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

//Record users AfterExecuteUpdate @3-33B45808
                if(E!=null) throw(E);
            }
            return (int)result;
    }
//End Record users AfterExecuteUpdate

//Record users Data Provider Class GetResultSet Method @3-7B048C8D
    public void FillItem(usersItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
        Exception E=null;
        int tableIndex = 0;
//End Record users Data Provider Class GetResultSet Method

//Record users BeforeBuildSelect @3-216003F7
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("UserID5",SesUserID, "","user_id",Condition.Equal,false);
        IsInsertMode=!LoadParams();
        DataSet ds=null;
        DataRowCollection dr = null;
        if(!IsInsertMode){
//End Record users BeforeBuildSelect

//Record users BeforeExecuteSelect @3-794B5E80
            try{
                ds=ExecuteSelect();
                dr=ds.Tables[tableIndex].Rows;
            }catch(Exception e){
                E=e;}
            finally{
//End Record users BeforeExecuteSelect

//Record users AfterExecuteSelect @3-47631D57
                if(E!=null) throw(E);
            }
        }
        if(!IsInsertMode && !ReadNotAllowed && dr.Count!=0)
        {
            int i=0;
            item.user_name.SetValue(dr[i]["user_name"],"");
            item.login.SetValue(dr[i]["login"],"");
            item.email.SetValue(dr[i]["email"],"");
            item.notify_new.SetValue(dr[i]["notify_new"],"");
            item.notify_original.SetValue(dr[i]["notify_original"],"");
            item.notify_reassignment.SetValue(dr[i]["notify_reassignment"],"");
            item.allow_upload.SetValue(dr[i]["allow_upload"],"1;0");
            item.security_level.SetValue(dr[i]["security_level"],"");
        }
        else
            IsInsertMode=true;
//End Record users AfterExecuteSelect

//Record users AfterExecuteSelect tail @3-FCB6E20C
    }
//End Record users AfterExecuteSelect tail

//Record users Data Provider Class @3-FCB6E20C
}

//End Record users Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

