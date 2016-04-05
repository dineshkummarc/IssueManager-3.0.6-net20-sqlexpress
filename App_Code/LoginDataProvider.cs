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

namespace IssueManager.Login{ //Namespace @1-5911B6C9

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

//Record Login Item Class @2-94EDEEE0
public class LoginItem
{
    private bool _isNew = true;
    private bool _isDeleted = false;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField login;
    public TextField password;
    public NameValueCollection errors=new NameValueCollection();
    public LoginItem()
    {
        login=new TextField("", null);
        password=new TextField("", null);
    }

    public static LoginItem CreateFromHttpRequest()
    {
        LoginItem item = new LoginItem();
        if(DBUtility.GetInitialValue("login") != null){
        item.login.SetValue(DBUtility.GetInitialValue("login"));
        }
        if(DBUtility.GetInitialValue("password") != null){
        item.password.SetValue(DBUtility.GetInitialValue("password"));
        }
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "login":
                    return this.login;
                case "password":
                    return this.password;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "login":
                    this.login = (TextField)value;
                    break;
                case "password":
                    this.password = (TextField)value;
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

    public void Validate(LoginDataProvider provider)
    {
//End Record Login Item Class

//login validate @5-632F7E7B
        if(login.Value==null||login.Value.ToString()=="")
            errors.Add("login",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.CCS_Login));
//End login validate

//password validate @6-3DC450F6
        if(password.Value==null||password.Value.ToString()=="")
            errors.Add("password",String.Format(Resources.strings.CCS_RequiredField,Resources.strings.CCS_Password));
//End password validate

//Record Login Item Class tail @2-F5FC18C5
    }
}
//End Record Login Item Class tail

//Record Login Data Provider Class @2-12FA80C0
public class LoginDataProvider:RecordDataProviderBase
{
//End Record Login Data Provider Class

//Record Login Data Provider Class Variables @2-0302D617
    protected LoginItem item;
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
//End Record Login Data Provider Class Variables

//Record Login Data Provider Class Constructor @2-362D05AD
    public LoginDataProvider()
    {
    }
//End Record Login Data Provider Class Constructor

//Record Login Data Provider Class LoadParams Method @2-62E7B02F
    protected bool LoadParams()
    {
        return true;
    }
//End Record Login Data Provider Class LoadParams Method

//Record Login Data Provider Class GetResultSet Method @2-EDBF3038
    public void FillItem(LoginItem item, ref bool IsInsertMode)
    {
        bool ReadNotAllowed=IsInsertMode;
//End Record Login Data Provider Class GetResultSet Method

//Record Login BeforeBuildSelect @2-921CE95D
        if(!IsInsertMode){
//End Record Login BeforeBuildSelect

//Record Login AfterExecuteSelect @2-54D78817
        }
            IsInsertMode=true;
//End Record Login AfterExecuteSelect

//Record Login AfterExecuteSelect tail @2-FCB6E20C
    }
//End Record Login AfterExecuteSelect tail

//Record Login Data Provider Class @2-FCB6E20C
}

//End Record Login Data Provider Class

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

