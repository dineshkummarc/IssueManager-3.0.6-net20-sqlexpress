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

namespace IssueManager.IssueExport{ //Namespace @1-C8B56552

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

//Grid issues Item Class @2-9FB9EF0F
public class issuesItem:IDataItem
{
    private System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public TextField title;
    public IntegerField issue_id;
    public TextField issue_name;
    public MemoField issue_desc;
    public TextField status_id;
    public TextField color;
    public TextField priority_id;
    public TextField user_id;
    public DateField date_submitted;
    public TextField assigned_to_orig;
    public IntegerField assigned_id;
    public TextField assigned_to;
    public TextField modified_by;
    public DateField date_modified;
    public BooleanField tested;
    public BooleanField approved;
    public TextField version;
    public NameValueCollection errors=new NameValueCollection();
    public issuesItem()
    {
        title=new TextField("", null);
        issue_id=new IntegerField("", null);
        issue_name=new TextField("", null);
        issue_desc=new MemoField("", null);
        status_id=new TextField("", null);
        color=new TextField("", null);
        priority_id=new TextField("", null);
        user_id=new TextField("", null);
        date_submitted=new DateField(Settings.DateFormat, null);
        assigned_to_orig=new TextField("", null);
        assigned_id=new IntegerField("", null);
        assigned_to=new TextField("", null);
        modified_by=new TextField("", null);
        date_modified=new DateField(Settings.DateFormat, null);
        tested=new BooleanField("res:im_yes;", null);
        approved=new BooleanField("res:im_yes;", null);
        version=new TextField("", null);
    }
    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "title":
                    return this.title;
                case "issue_id":
                    return this.issue_id;
                case "issue_name":
                    return this.issue_name;
                case "issue_desc":
                    return this.issue_desc;
                case "status_id":
                    return this.status_id;
                case "color":
                    return this.color;
                case "priority_id":
                    return this.priority_id;
                case "user_id":
                    return this.user_id;
                case "date_submitted":
                    return this.date_submitted;
                case "assigned_to_orig":
                    return this.assigned_to_orig;
                case "assigned_id":
                    return this.assigned_id;
                case "assigned_to":
                    return this.assigned_to;
                case "modified_by":
                    return this.modified_by;
                case "date_modified":
                    return this.date_modified;
                case "tested":
                    return this.tested;
                case "approved":
                    return this.approved;
                case "version":
                    return this.version;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "title":
                    this.title = (TextField)value;
                    break;
                case "issue_id":
                    this.issue_id = (IntegerField)value;
                    break;
                case "issue_name":
                    this.issue_name = (TextField)value;
                    break;
                case "issue_desc":
                    this.issue_desc = (MemoField)value;
                    break;
                case "status_id":
                    this.status_id = (TextField)value;
                    break;
                case "color":
                    this.color = (TextField)value;
                    break;
                case "priority_id":
                    this.priority_id = (TextField)value;
                    break;
                case "user_id":
                    this.user_id = (TextField)value;
                    break;
                case "date_submitted":
                    this.date_submitted = (DateField)value;
                    break;
                case "assigned_to_orig":
                    this.assigned_to_orig = (TextField)value;
                    break;
                case "assigned_id":
                    this.assigned_id = (IntegerField)value;
                    break;
                case "assigned_to":
                    this.assigned_to = (TextField)value;
                    break;
                case "modified_by":
                    this.modified_by = (TextField)value;
                    break;
                case "date_modified":
                    this.date_modified = (DateField)value;
                    break;
                case "tested":
                    this.tested = (BooleanField)value;
                    break;
                case "approved":
                    this.approved = (BooleanField)value;
                    break;
                case "version":
                    this.version = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

}
//End Grid issues Item Class

//Grid issues Data Provider Class Header @2-68D66AE5
public class issuesDataProvider:GridDataProviderBase
{
//End Grid issues Data Provider Class Header

//Grid issues Data Provider Class Variables @2-AFBB89FF
    protected System.Resources.ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
    public enum SortFields {Default}
    private string[] SortFieldsNames=new string[]{""};
    private string[] SortFieldsNamesDesc=new string[]{""};
    public SortFields SortField=SortFields.Default;
    public SortDirections SortDir=SortDirections.Asc;
    public int RecordsPerPage=0;
    public int PageNumber=1;
    public IntegerParameter Urls_status_id;
    public IntegerParameter Urls_notstatus_id;
    public IntegerParameter Urls_priority_id;
    public IntegerParameter Urls_assigned_to;
    public MemoParameter Urls_issue_desc;
    public IntegerParameter Urls_assigned_by;
//End Grid issues Data Provider Class Variables

//Grid issues Data Provider Class Constructor @2-1DA994F2
    public issuesDataProvider()
    {
         Select=new TableCommand("SELECT issues.*, status, priority_desc, priority_color, \n" +
          "users.user_name AS users_user_name, \n" +
          "users1.user_name AS users1_user_name,\n" +
          "users2.user_name AS users2_user_name, \n" +
          "users3.user_name AS users3_user_name \n" +
          "FROM users users3 RIGHT JOIN (users users2 RIGHT JOIN (users users1 RIGHT JOIN (users RIGH" +
          "T JOIN (priorities RIGHT JOIN (statuses RIGHT JOIN issues ON\n" +
          "statuses.status_id = issues.status_id) ON\n" +
          "priorities.priority_id = issues.priority_id) ON\n" +
          "users.user_id = issues.user_id) ON\n" +
          "users1.user_id = issues.assigned_to) ON\n" +
          "users2.user_id = issues.assigned_to_orig) ON\n" +
          "users3.user_id = issues.modified_by {SQL_Where} {SQL_OrderBy}", new string[]{"s_status_id114","And","s_notstatus_id115","And","s_priority_id116","And","s_assigned_to117","And","(","s_issue_desc118","Or","s_issue_desc121",")","And","s_assigned_by122"},Settings.IMDataAccessObject);
         Count=new TableCommand("SELECT COUNT(*)\n" +
          "FROM users users3 RIGHT JOIN (users users2 RIGHT JOIN (users users1 RIGHT JOIN (users RIGH" +
          "T JOIN (priorities RIGHT JOIN (statuses RIGHT JOIN issues ON\n" +
          "statuses.status_id = issues.status_id) ON\n" +
          "priorities.priority_id = issues.priority_id) ON\n" +
          "users.user_id = issues.user_id) ON\n" +
          "users1.user_id = issues.assigned_to) ON\n" +
          "users2.user_id = issues.assigned_to_orig) ON\n" +
          "users3.user_id = issues.modified_by", new string[]{"s_status_id114","And","s_notstatus_id115","And","s_priority_id116","And","s_assigned_to117","And","(","s_issue_desc118","Or","s_issue_desc121",")","And","s_assigned_by122"},Settings.IMDataAccessObject);
    }
//End Grid issues Data Provider Class Constructor

//Grid issues Data Provider Class GetResultSet Method @2-1BD238D1
    public issuesItem[] GetResultSet(out int _pagesCount, FormSupportedOperations ops)
    {
//End Grid issues Data Provider Class GetResultSet Method

//Before build Select @2-BA7A2833
        Select.Parameters.Clear();
        ((TableCommand)Select).AddParameter("s_status_id114",Urls_status_id, "","issues.status_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_notstatus_id115",Urls_notstatus_id, "","issues.status_id",Condition.NotEqual,false);
        ((TableCommand)Select).AddParameter("s_priority_id116",Urls_priority_id, "","issues.priority_id",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_assigned_to117",Urls_assigned_to, "","assigned_to",Condition.Equal,false);
        ((TableCommand)Select).AddParameter("s_issue_desc118",Urls_issue_desc, "","issue_name",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_issue_desc121",Urls_issue_desc, "","issues.issue_desc",Condition.Contains,false);
        ((TableCommand)Select).AddParameter("s_assigned_by122",Urls_assigned_by, "","users.user_id",Condition.Equal,false);
        Count.Parameters = Select.Parameters;
        Select.OrderBy = (SortDir==SortDirections.Asc?SortFieldsNames[(int)SortField]:SortFieldsNamesDesc[(int)SortField]).Trim();
        int tableIndex = 0;
        Exception E=null;
//End Before build Select

//Execute Select @2-081BAA84
        DataSet ds=null;
        _pagesCount=0;
        issuesItem[] result = new issuesItem[0];
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

//After execute Select @2-D9BD0183
                if(E!=null) throw(E);
            }
            DataRowCollection dr=ds.Tables[tableIndex].Rows;
            result = new issuesItem[dr.Count];
//End After execute Select

//After execute Select tail @2-3CC6F8EB
            for(int i=0;i<dr.Count;i++)
            {
                issuesItem item=new issuesItem();
                item.issue_id.SetValue(dr[i]["issue_id"],"");
                item.issue_name.SetValue(dr[i]["issue_name"],"");
                item.issue_desc.SetValue(dr[i]["issue_desc"],"");
                item.status_id.SetValue(dr[i]["status"],"");
                item.color.SetValue(dr[i]["priority_color"],"");
                item.priority_id.SetValue(dr[i]["priority_desc"],"");
                item.user_id.SetValue(dr[i]["users_user_name"],"");
                item.date_submitted.SetValue(dr[i]["date_submitted"],Select.DateFormat);
                item.assigned_to_orig.SetValue(dr[i]["users2_user_name"],"");
                item.assigned_id.SetValue(dr[i]["assigned_to"],"");
                item.assigned_to.SetValue(dr[i]["users1_user_name"],"");
                item.modified_by.SetValue(dr[i]["users3_user_name"],"");
                item.date_modified.SetValue(dr[i]["date_modified"],Select.DateFormat);
                item.tested.SetValue(dr[i]["tested"],"1;0");
                item.approved.SetValue(dr[i]["approved"],"1;0");
                item.version.SetValue(dr[i]["version"],"");
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

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

