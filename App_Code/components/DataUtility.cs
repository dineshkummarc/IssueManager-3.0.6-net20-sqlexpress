//DBUtility Class namespaces @1-D048BE68
//Target Framework version is 2.0
using System;
using System.Data;
using System.IO;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using IssueManager.Configuration;

namespace IssueManager.Data
{

//End DBUtility Class namespaces

//Common enumerations @2-0C991368
public enum FieldType{Integer,Float,Text,Memo,Boolean,Date,Single}
public enum ParameterType{BigInt,Bit,Char,Date,DateTime,Decimal,Double,Int,TinyInt,SmallInt,NChar,NText,Numeric,NVarChar,Real,SmallDateTime,Text,Time,VarChar,RecordSet}
public enum ConnectionStringType {OleDb, Sql, Odbc, Oracle, ODP, DB2}
public enum SortDirections{Asc,Desc}

//End Common enumerations

//IDataItem interface @2a-2391B5D2
	public interface IDataItem
	{
		FieldBase this[string name]
		{
			get;
			set;
		}
	}

//End IDataItem interface

//ItemCollection Class @3-58D50B25
public class ItemCollection:NameObjectCollectionBase, ICloneable
{
    public struct ItemValue
    {
        public ItemValue(string text, bool selected)
        {
            Text = text;
            Selected = selected;
        }

        public string Text;
        public bool Selected;
    }
    public void Add(string value,string text,bool selected)
    {
        if(value != null && BaseGet(value) == null)
            BaseAdd(value,new ItemValue(text,selected));
        else if(value == null && BaseGet(value) == null)
            BaseAdd("",new ItemValue(text,selected));
    }

    public void Add(object value,object text,bool selected)
    {
        if(value != null && BaseGet(Convert.ToString(value)) == null)
            BaseAdd(Convert.ToString(value),new ItemValue(Convert.ToString(text),selected));
        else if(value == null && BaseGet(Convert.ToString(value)) == null)
            BaseAdd("",new ItemValue(Convert.ToString(text),selected));
    }

    public void Add(string value,string text)
    {
        Add(value, text, false);
    }

    public void Add(object value,object text)
    {
        Add(value, text, false);
    }

    public void SetSelection(object value)
    {
        if(value != null && BaseGet(value.ToString()) != null){
            ItemValue v = this[value.ToString()];
            v.Selected = true;
            BaseSet(value.ToString(),v);
        }
    }

    public object GetSelectedItem()
    {
        object result = null;
        for(int i = 0;i < Count; i ++)
            if(this[i].Selected){ result=this[i];break;}
        return result;
    }

    public object Clone()
    {
        ItemCollection res = new ItemCollection();
        for(int i = 0;i < Count; i ++)
            res.BaseAdd(this.Keys[i],this[i]);
        return res;
    }

    public void CopyTo(System.Web.UI.WebControls.ListItemCollection col, bool encode)
    {
        for(int i = 0;i < Count; i ++)
        {
            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(encode?HttpContext.Current.Server.HtmlEncode(this[i].Text):this[i].Text, this.Keys[i]);
            item.Selected = this[i].Selected;
            col.Add(item);
        }
    }

    public void CopyTo(System.Web.UI.WebControls.ListItemCollection col)
    {
        CopyTo(col, false);
    }

    public void CopyFrom(System.Web.UI.WebControls.ListItemCollection col)
    {
        Clear();
        for(int i = 0;i < col.Count; i ++)
            Add(col[i].Value, col[i].Value, col[i].Selected);
    }

    public void Remove(string value)
    {
        BaseRemove(value);
    }

    public void RemoveAt(int index)
    {
        BaseRemoveAt(index);
    }

    public void Clear()
    {
        BaseClear();
    }

    public ItemValue this[string key]
    {
        get
        {
            return (ItemValue) BaseGet(key);
        }
    }

    public ItemValue this[int index]
    {
        get
        {
            return (ItemValue) BaseGet(index);
        }
    }
}
//End ItemCollection Class

//LinkParameterCollection Class @3-B7B31488
public class LinkParameterCollection:NameObjectCollectionBase
{
    protected void AddUnique(string name,string value)
    {
        if(BaseGet(name) == null)
            BaseAdd(name,value);
    }
    public void Add(string name,string value)
    {
            BaseAdd(name,value);
    }
    public void Add(string name, NameValueCollection values, string keyName)
    {
        if(values[keyName]!=null)
            foreach(string val in values.GetValues(keyName))
                BaseAdd(name,System.Web.HttpUtility.UrlEncode(val));
        else
            BaseAdd(name,"");
    }

    public string ToString(string preserve, string removeList)
    {
        return ToString(preserve, removeList, null);
    }

    public string ToString(string preserve, string removeList, System.Web.UI.StateBag viewState)
    {
        HttpRequest Request=HttpContext.Current.Request;
        HttpServerUtility Server=HttpContext.Current.Server;
        string[] List;

        if(removeList=="")
            List=new string[1];
        else
            List=removeList.Split(new Char[] {';'});

        if(preserve=="All"||preserve=="GET"){
            if(viewState != null){
                int length = viewState.Count;
                string[] keys = new string[length];
                System.Web.UI.StateItem[] values = new System.Web.UI.StateItem[length];
                viewState.Keys.CopyTo(keys, 0);
                viewState.Values.CopyTo(values, 0);
                string cvalue = "";
                for(int i = 0; i < length; i++) {
                    if(values[i].Value != null)
                        cvalue = values[i].Value.ToString();
                    else
                        cvalue = "";
                    string ckey = "";
                    if (keys[i].EndsWith("SortField") && cvalue != "Default")
                        ckey = keys[i].Replace("SortField","Order");
                    if (keys[i].EndsWith("SortDir")) 
                        ckey = keys[i].Replace("SortDir","Dir");
                    if (keys[i].EndsWith("PageNumber") && cvalue != "1")
                        ckey = keys[i].Replace("PageNumber","Page");
                    if (ckey!="" && Array.IndexOf(List,ckey) < 0) 
                    {
                        if (this[ckey]==null) Add(ckey,cvalue); else this[ckey] = cvalue;
                    }
                }
            }
            for(int i=0;i<Request.QueryString.Count;i++)
            {
                if(Array.IndexOf(List,Request.QueryString.AllKeys[i])<0 && BaseGet(Request.QueryString.AllKeys[i]) == null)
                    foreach(string val in Request.QueryString.GetValues(i))
                        Add(Request.QueryString.AllKeys[i],Server.UrlEncode(val));
            }
        }
        if(preserve=="All"||preserve=="POST")
            for(int i=0;i<Request.Form.Count;i++)
            {
                if(Array.IndexOf(List,Request.Form.AllKeys[i])<0
                    && Request.Form.AllKeys[i]!="__EVENTTARGET"
                    &&Request.Form.AllKeys[i]!="__EVENTARGUMENT"
                    &&Request.Form.AllKeys[i]!="__VIEWSTATE"
                    && BaseGet(Request.Form.AllKeys[i]) == null)
                    foreach(string val in Request.Form.GetValues(i))
                        Add(Request.Form.AllKeys[i],Server.UrlEncode(val));
            }

        return ToString("");
    }

    public override string ToString()
    {
        return ToString("");
    }

    public string ToString(string removeList)
    {
        string Params="";string[] List;
        if(removeList=="")
            List=new string[1];
        else
            List=removeList.Split(new Char[] {';'});
        for(int i=0;i<Count;i++)
        {
            if(Array.IndexOf(List,BaseGetKey(i))<0)
                Params += BaseGetKey(i) + "=" + Convert.ToString(BaseGet(i)) + "&";
        }
        Params=Params.TrimEnd(new Char[]{'&'});
        if(Params.Length>0) Params = "?" + Params;
        return Params;
    }

    public object this[string key]
    {
        get
        {
            return BaseGet(key);
        }
        set
        {
            BaseSet(key,value);
        }
    }

    public object this[int index]
    {
        get
        {
            return BaseGet(index);
        }
        set
        {
            BaseSet(index,value);
        }
    }
}
//End LinkParameterCollection Class

//Connection String Class @4-B96C06E2

public sealed class ConnectionString
{
    private string _connection;
    private ConnectionStringType _type;
    private NameValueCollection _connectionCommands = new NameValueCollection();
    private string _server="";
    private bool _optimized=false;
    private string _dateFormat="";
    private string _boolFormat="";
    private string _dateLeftDelim="";
    private string _dateRightDelim="";
    public ConnectionString(string conStr,ConnectionStringType conType){
    this.Connection=conStr;this.Type=conType;}

    public ConnectionString(string conStr,ConnectionStringType conType,string dateFormat,string boolFormat,string dateLeftDelim, string dateRightDelim, string server, bool optimized)
    {
    this.Connection=conStr;
    this.Server=server;
    this.Optimized=optimized;
    this.Type=conType;
    this.DateFormat=dateFormat;
    this.BoolFormat=boolFormat;
    this.DateLeftDelim=dateLeftDelim;
    this.DateRightDelim=dateRightDelim;
    }

    public ConnectionString()
    {}

    public string Connection
    {
        get
        {
            return _connection;
        }
        set
        {
            _connection = value;
        }
    }

    public string Server
    {
        get
        {
            return _server;
        }
        set
        {
            _server = value;
        }
    }

    public bool Optimized
    {
        get
        {
            return _optimized;
        }
        set
        {
            _optimized = value;
        }
    }

    public ConnectionStringType Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    public NameValueCollection ConnectionCommands
    {
        get
        {
            return _connectionCommands;
        }
    }

    public string DateFormat
    {
        get
        {
            return _dateFormat;
        }
        set
        {
            _dateFormat = value;
        }
    }

    public string BoolFormat
    {
        get
        {
            return _boolFormat;
        }
        set
        {
            _boolFormat = value;
        }
    }

    public string DateLeftDelim
    {
        get
        {
            return _dateLeftDelim;
        }
        set
        {
            _dateLeftDelim = value;
        }
    }

    public string DateRightDelim
    {
        get
        {
            return _dateRightDelim;
        }
        set
        {
            _dateRightDelim = value;
        }
    }

}

//End Connection String Class

//DBUtility Class @5-FB756526
public class DBUtility
{
    public static bool IsGroupsNested = true;
    private DBUtility()
    {
    }
//End DBUtility Class

//Authorize user method @6-AA3D37F4
    public static bool AuthorizeUser(string[] groups)
    {
        if(HttpContext.Current.Session["UserID"]==null) return false;
        if(groups.Length == 0) return false;
        string GroupId = HttpContext.Current.Session["GroupID"].ToString();
        for(int i=0;i<groups.Length;i++)
            if(Int32.Parse(groups[i]) <= Int32.Parse(GroupId)) return true;
        return false;
    }
//End Authorize user method

//User ID Property @6-14DDD8D4
    public static object UserId
    {
        get{return HttpContext.Current.Session["UserID"];}
        set{HttpContext.Current.Session["UserID"]=value;}
    }
//End User ID Property

//User login property @6-19261CD6
    public static string UserLogin
    {
        get{return Convert.ToString(HttpContext.Current.Session["UserLogin"]);}
        set{HttpContext.Current.Session["UserLogin"]=value;}
    }

//End User login property

//User Group property @6-C6E126F1
    public static string UserGroup
    {
        get{return HttpContext.Current.Session["GroupID"].ToString();}
        set{HttpContext.Current.Session["GroupID"]=value;}
    }

//End User Group property

//AuthorizeUser method @6-E00E8844
    public static bool AuthorizeUser()
    {
        if(HttpContext.Current.Session["UserID"]==null) return false;
        return true;
    }
//End AuthorizeUser method

//Check user method @6-663DEA3F
    public static bool CheckUser(string userName,string userPassword)
    {
        DataAccessObject dao=Settings.IMDataAccessObject;
        string Sql = "SELECT user_id, security_level FROM users WHERE login=" + dao.ToSql(userName,FieldType.Text) + " AND pass=" + dao.ToSql(userPassword,FieldType.Text);

        DataSet ds=dao.RunSql(Sql);

        if(ds.Tables[0].Rows.Count>0)
        {
            HttpContext.Current.Session["UserID"]= ds.Tables[0].Rows[0]["user_id"];
            HttpContext.Current.Session["GroupID"]= ds.Tables[0].Rows[0]["security_level"].ToString();;
            HttpContext.Current.Session["UserLogin"]= userName;
            return true;
        }


        return false;
    }
//End Check user method

//Get CCS format @6-5963C315
    public static string GetCCSFormat(string format)
    {
        switch (format)
        {
            case "D":
                return "LongDate";
            case "G":
                return "GeneralDate";
            case "d":
                return "ShortDate";
            case "T":
                return "LongTime";
            case "t":
                return "ShortTime";
        }

        format = format.Replace("m", "n");
        format = format.Replace("M", "m");
        format = format.Replace("tt","AM/PM");
        format = format.Replace("t", "M/P");
        format = format.Replace("\\/", "/");
        format = format.Replace("\\:", ":");

        return format;
    }
//End Get CCS format

//InitializeGridParameters @6-B28A1AAB
    public static void InitializeGridParameters(System.Web.UI.StateBag viewState, string formName, Type sortFields,int pageSize, int pageSizeLimit)
    {
        HttpRequest Request = HttpContext.Current.Request;
        string Param;
        int PageSize = pageSize;
        viewState[formName + "SortField"] = Enum.Parse(sortFields, "Default");
        viewState[formName + "PageNumber"] = 1;
        Param = Request.QueryString[formName + "Order"];
        if (Param != null && Param.Length > 0)
            try{
                viewState[formName + "SortField"] = Enum.Parse(sortFields, Param);
            }catch {}
        Param = Request.QueryString[formName + "Dir"];
        if (Param == null || Param.Length == 0 || Param.ToLower() == "asc")
            viewState[formName + "SortDir"] = SortDirections.Asc;
        else
            viewState[formName + "SortDir"] = SortDirections.Desc;
        Param = Request.QueryString[formName + "Page"];
        int PageNumber;
        if (Param != null && Param.Length > 0)
            try
            {
                PageNumber = Int32.Parse(Param);
                if (PageNumber >= 0) viewState[formName + "PageNumber"] = PageNumber;
            }
            catch {}
        Param = Request.QueryString[formName + "PageSize"];
        if (Param != null && Param.Length > 0)
            try
            {
                PageSize = Int32.Parse(Param);
                if (PageSize <= 0) PageSize = pageSize;
            }
            catch {}
        if ((PageSize > pageSizeLimit || PageSize == 0) && pageSizeLimit != -1)
            PageSize = pageSizeLimit;
        viewState[formName + "PageSize"] = PageSize;
    }
//End InitializeGridParameters

//ParseBool @6-734F478A
    public static bool ParseBool(string value, string format)
    {
        char[] chDelim = {';'};
        if (format==null||format.Length == 0)
            format = ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).BooleanFormat;
        try{
        if (format==null||format.Length == 0)
            return bool.Parse(value);
        string[] Tokens = format.Split(chDelim);
        if ( value == Tokens[0])
            return true;
        if ( value == Tokens[1])
            return false;
        }catch(Exception e){throw(new Exception("Unable to parse Boolean:"+e.Message));}
        return false;
    }
//End ParseBool

//FormatBool @6-EC3ED7AB
    public static string FormatBool(object value, string format)
    {
        char[] chDelim = {';'};
        if (format==null||format.Length == 0)
            format = ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).BooleanFormat;
        try{
        if ((format==null||format.Length == 0) && value != null)
            return value.ToString();
            else if ((format==null||format.Length == 0) && value == null)
            return "";
        string[] Tokens = format.Split(chDelim);
        if ((value==null||value is DBNull) && Tokens.Length > 2)
            return Tokens[2];
        if (value==null||value is DBNull)
            return "";
        if ((bool)value)
            return Tokens[0];
        if (!(bool)value)
            return Tokens[1];
        }catch(Exception e){throw(new Exception("Unable to format Boolean:"+e.Message));}
        return "";
    }
//End FormatBool

//ParseInt @6-3DF23F02
    public static Int64 ParseInt(string value, string format)
    {
        char[] chDelim = {';'};
        try{
        if (format==null||format.Length == 0)
            return Int64.Parse(value);
        NumberFormatInfo nfi = (NumberFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone();
        string[] Tokens = format.Split(chDelim);
        if (Tokens.Length > 4&&Tokens[4].Length>0){
            nfi.NumberDecimalSeparator=Tokens[4];
            nfi.PercentDecimalSeparator=Tokens[4];}
        if (Tokens.Length > 5&&Tokens[5].Length>0){
            nfi.NumberGroupSeparator=Tokens[5];
            nfi.PercentGroupSeparator=Tokens[5];}

        return Int64.Parse(value,NumberStyles.Integer,nfi);
        }catch(Exception e){throw(new Exception("Unable to parse Integer:"+e.Message));}
    }
//End ParseInt

//ParseDouble @6-A9387FCF
    public static Double ParseDouble(string value, string format)
    {
        char[] chDelim = {';'};
        try{
        if (format==null||format.Length == 0)
            return Double.Parse(value);
        NumberFormatInfo nfi = (NumberFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone();
        string[] Tokens = format.Split(chDelim);
        if (Tokens.Length > 4&&Tokens[4].Length>0){
            nfi.NumberDecimalSeparator=Tokens[4];
            nfi.PercentDecimalSeparator=Tokens[4];}
        if (Tokens.Length > 5&&Tokens[5].Length>0){
            nfi.NumberGroupSeparator=Tokens[5];
            nfi.PercentGroupSeparator=Tokens[5];}

        return Double.Parse(value,NumberStyles.Any,nfi);
        }catch(Exception e){throw(new Exception("Unable to parse Float:"+e.Message));}
    }
//End ParseDouble

//ParseSingle @6-426A6E40
    public static Single ParseSingle(string value, string format)
    {
        char[] chDelim = {';'};
        try{
        if (format==null||format.Length == 0)
            return Single.Parse(value);
        NumberFormatInfo nfi = (NumberFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone();
        string[] Tokens = format.Split(chDelim);
        if (Tokens.Length > 4&&Tokens[4].Length>0){
            nfi.NumberDecimalSeparator=Tokens[4];
            nfi.PercentDecimalSeparator=Tokens[4];}
        if (Tokens.Length > 5&&Tokens[5].Length>0){
            nfi.NumberGroupSeparator=Tokens[5];
            nfi.PercentGroupSeparator=Tokens[5];}

        return Single.Parse(value,NumberStyles.Any,nfi);
        }catch(Exception e){throw(new Exception("Unable to parse Single"+e.Message));}
    }
//End ParseSingle

//ParseDate @6-995E35DA
    public static DateTime ParseDate(string value, string format)
    {
        try{
        if (format==null||format.Length == 0)
            return DateTime.Parse(value);
        return DateTime.ParseExact(value,format,CultureInfo.CurrentCulture.DateTimeFormat);
        }catch(Exception e){throw(new Exception("Unable to parse DateTime:"+e.Message));}
    }
//End ParseDate

//FormatNumber @6-25EE8914
    public static string FormatNumber(object value, string format)
    {
        char[] chDelim = {';'};
        try{
        if (format==null||format.Length == 0)
            return value.ToString();
        NumberFormatInfo nfi = (NumberFormatInfo)System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.Clone();
        string[] Tokens = format.Split(chDelim);
        if (Tokens.Length > 4&&Tokens[4].Length>0){
            nfi.NumberDecimalSeparator=Tokens[4];
            nfi.PercentDecimalSeparator=Tokens[4];}
        if (Tokens.Length > 5&&Tokens[5].Length>0){
            nfi.NumberGroupSeparator=Tokens[5];
            nfi.PercentGroupSeparator=Tokens[5];}
        if ((value==null||value is DBNull) &&Tokens.Length > 3)
            return Tokens[3];
        if (value==null||value is DBNull)
            return "null";

        string formatStr="";
        if (Tokens.Length > 0)
            formatStr+=Tokens[0]+";";
        if (Tokens.Length > 1)
            formatStr+=Tokens[1]+";";
        if (Tokens.Length > 2)
            formatStr+=Tokens[2]+";";

        if (value is int)
            return ((int)value).ToString(formatStr,nfi);

        if (value is Int64)
            return ((Int64)value).ToString(formatStr,nfi);

        if (value is Double)
            return ((Double)value).ToString(formatStr,nfi);

        if (value is Single)
            return ((Single)value).ToString(formatStr,nfi);

        if (value is Decimal)
            return ((Decimal)value).ToString(formatStr,nfi);

        }catch(Exception e){throw(new Exception("Unable to format Number:"+e.Message));}
        return "";
    }
//End FormatNumber

//GetInitialValue @6-65F1B862
    public static object GetInitialValue(string parameterName, object defaultValue)
    {
        string value = null;

        if (HttpContext.Current.Request.QueryString[parameterName] != null)
            value=HttpContext.Current.Request.QueryString.GetValues(parameterName)[0];
        else
            if (HttpContext.Current.Request.Form[parameterName] != null)
                value = HttpContext.Current.Request.Form.GetValues(parameterName)[0];

        return value==null?defaultValue:value;
    }

    public static object GetInitialValue(string parameterName)
    {
        return GetInitialValue(parameterName, null);
    }
//End GetInitialValue

//DBUtility Class tail @6-F5FC18C5
}
}
//End DBUtility Class tail

