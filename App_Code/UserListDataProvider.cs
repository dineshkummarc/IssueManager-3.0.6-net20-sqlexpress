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

namespace IssueManager.UserList{ //Namespace @1-F7CB4F48

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

//Grid users Item Class @3-3D878970
public class usersItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField user_name;
    public object user_nameHref;
    public LinkParameterCollection user_nameHrefParameters;
    public TextField email;
    public TextField security_level;
    public BooleanField allow_upload;
    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public NameValueCollection errors=new NameValueCollection();
    public usersItem()
    {
        user_name = new TextField("",null);
        user_nameHrefParameters = new LinkParameterCollection();
        email=new TextField("", null);
        security_level=new TextField("", null);
        allow_upload=new BooleanField("res:im_yes;res:im_no", null);
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user_name":
                    return this.user_name;
                case "email":
                    return this.email;
                case "security_level":
                    return this.security_level;
                case "allow_upload":
                    return this.allow_upload;
                case "Link1":
                    return this.Link1;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user_name":
                    this.user_name = (TextField)value;
                    break;
                case "email":
                    this.email = (TextField)value;
                    break;
                case "security_level":
                    this.security_level = (TextField)value;
                    break;
                case "allow_upload":
                    this.allow_upload = (BooleanField)value;
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
//End Grid users Item Class

//Grid users Data Provider Class Header @3-FDACFC2D
public class usersDataProvider:GridDataProviderBase
{
//End Grid users Data Provider Class Header

//Grid users Data Provider Class Variables @3-70B2F95A
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default,Sorter_user_name,Sorter_email,Sorter_security_level,Sorter_allow_upload}
    private string[] SortFieldsNames=new string[]{"","user_name","email","security_level","allow_upload"};
    private string[] SortFieldsNamesDesc=new string[]{"","user_name DESC","email DESC","security_level DESC","allow_upload DESC"};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=10;
    public int PageNumber=1;
//End Grid users Data Provider Class Variables

//Grid users Data Provider Class Constructor @3-1C4DC77F
    public usersDataProvider()
    {
         Select=new TableCommand("SELECT * \n" +
          "FROM users {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users", new string[]{},Settings.IMDataAccessObject);
    }
//End Grid users Data Provider Class Constructor

//Grid users Data Provider Class GetResultSet Method @3-87BDA9E9
    public usersItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid users Data Provider Class GetResultSet Method

//Before build Select @3-F73CEB25
        Select.Parameters.Clear();
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @3-6870EE9B
        DataSet ds=null;
        _pagesCount=0;
        usersItem[] result = new usersItem[0];
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

//After execute Select @3-7836DC72
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new usersItem[dr.Count];
//End After execute Select

//After execute Select tail @3-74FB6E6C
            for(int i=0;i<dr.Count;i++)
            {
                usersItem item=new usersItem();
                item.user_name.SetValue(dr[i]["user_name"],"");
                item.user_nameHref = "UserMaint.aspx";
                item.user_nameHrefParameters.Add("user_id",System.Web.HttpUtility.UrlEncode(dr[i]["user_id"].ToString()));
                item.email.SetValue(dr[i]["email"],"");
                item.security_level.SetValue(dr[i]["security_level"],"");
                item.allow_upload.SetValue(dr[i]["allow_upload"],"1;0");
                item.Link1Href = "UserMaint.aspx";
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

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

