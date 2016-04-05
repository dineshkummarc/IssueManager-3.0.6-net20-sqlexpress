//Setting Class @0-506F40A4
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Collections.Specialized;
using IssueManager.Data;
namespace IssueManager.Configuration
{
public sealed class Settings
{
    private static string _serverUrl = ConfigurationManager.AppSettings["ServerUrl"];
    private static string _securedUrl = ConfigurationManager.AppSettings["SecuredUrl"];
    private static string _cultureId = ConfigurationManager.AppSettings["CultureId"];
    private static string _siteLanguage = ConfigurationManager.AppSettings["SiteLanguage"];
    private static string _AccesDeniedUrl = ConfigurationManager.AppSettings["AccessDeniedUrl"];
    private static string _DateFormat = ConfigurationManager.AppSettings["DefaultDateFormat"];
    private static string _BoolFormat = ConfigurationManager.AppSettings["DefaultBooleanFormat"];
    private Settings()
    {}

    public static string CultureId
    {
        get
        {
            if(_cultureId == null || _cultureId == "")
                return CultureInfo.CurrentCulture.Name;
            else
                return _cultureId;
        }
        set
        {
            _cultureId=value;
        }
    }

    public static string SiteLanguage
    {
        get
        {
            return _siteLanguage;
        }
        set
        {
            _siteLanguage = value;
        }
    }

    public static string DateFormat
    {
        get
        {
            return _DateFormat;
        }
        set
        {
            _DateFormat=value;
        }
    }

    public static string BoolFormat
    {
        get
        {
            return _BoolFormat;
        }
        set
        {
            _BoolFormat=value;
        }
    }

    public static string AccessDeniedUrl
    {
        get
        {
            return _AccesDeniedUrl;
        }
        set
        {
            _AccesDeniedUrl=value;
        }
    }

    public static string ServerURL
    {
        get
        {
            return _serverUrl;
        }
        set
        {
            _serverUrl=value;
        }
    }

    public static string SecuredURL
    {
        get
        {
            return _securedUrl;
        }
        set
        {
            _securedUrl=value;
        }
    }
    public static DataAccessObject GetConnection(string name)
    {
        switch (name)
        {
            case "IM":
                return IMDataAccessObject;
        }
        return null;
    }

    public static ConnectionString IMConnection
    {
        get
        {
            ConnectionString cs=new ConnectionString();
            cs.Connection=ConfigurationManager.AppSettings["IMString"];
            cs.Server=ConfigurationManager.AppSettings["IMServer"];
            cs.Optimized=bool.Parse(ConfigurationManager.AppSettings["IMOptimized"]);
            cs.ConnectionCommands.Add((NameValueCollection) ConfigurationSettings.GetConfig("connectionCommands/_IMCommands"));
            cs.DateFormat=ConfigurationManager.AppSettings["IMDateFormat"];
            cs.BoolFormat=ConfigurationManager.AppSettings["IMBoolFormat"];
            cs.DateRightDelim=ConfigurationManager.AppSettings["IMDateRightDelimeter"];
            cs.DateLeftDelim=ConfigurationManager.AppSettings["IMDateLeftDelimeter"];
            switch(ConfigurationManager.AppSettings["IMType"].ToUpper(CultureInfo.CurrentCulture))
            {
            case "OLEDB":
                cs.Type=ConnectionStringType.OleDb;
                break;
            case "ODBC":
                cs.Type=ConnectionStringType.Odbc;
                break;
            case "ORACLE":
                cs.Type=ConnectionStringType.Oracle;
                break;
#if ODP_INSTALLED
	
            case "ODP":
                cs.Type=ConnectionStringType.ODP;
                break;
#endif
#if DB2_INSTALLED
	
            case "DB2":
                cs.Type=ConnectionStringType.DB2;
                break;
#endif
	
            case "SQL":
                cs.Type=ConnectionStringType.Sql;
                break;
            }
            return cs;
        }
    }

    public static DataAccessObject IMDataAccessObject
    {
        get
        {
            ConnectionString Connection=IMConnection;
            switch(Connection.Type)
            {
            case ConnectionStringType.OleDb:
                return new OleDbDao(Connection);
            case ConnectionStringType.Odbc:
                return new OdbcDao(Connection);
            case ConnectionStringType.Oracle:
                return new OracleDao(Connection);
#if ODP_INSTALLED
	
            case ConnectionStringType.ODP:
                return new ODPDao(Connection);
#endif
#if DB2_INSTALLED
	
            case ConnectionStringType.DB2:
                return new DB2Dao(Connection);
#endif
	
            case ConnectionStringType.Sql:
                return new SqlDao(Connection);
            }
            return null;
        }
    }

}
}
//End Setting Class

