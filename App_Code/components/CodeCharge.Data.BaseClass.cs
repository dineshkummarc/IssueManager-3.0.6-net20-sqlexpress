//Using statements @0-94533781
//Target Framework version is 2.0
using System;
using System.Collections;
using System.Data;

namespace IssueManager.Data
{
//End Using statements

//CodeCharge.Data.DataAccessObject Class @0-4A303BD4
/// <summary>
/// Describe main methods for DAO objects.
/// </summary>

public class DataAccessObject:MarshalByRefObject, IDisposable
{
    private string _server="";
    private bool _optimized=false;
    private string _dateFormat="";
    private string _boolFormat="";
    protected string dateLeftDelim="";
    protected string dateRightDelim="";

    public string DateFormat
    {
        get
        {
            return _dateFormat;
        }
        set
        {
            _dateFormat=value;
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
            _boolFormat=value;
        }
    }

    public DataAccessObject()
        {}

    public virtual void Dispose()
    {}

    public DataAccessObject(ConnectionString connection){
        this.DateFormat=connection.DateFormat;this.BoolFormat=connection.BoolFormat;
        this.dateLeftDelim=connection.DateLeftDelim;this.dateRightDelim=connection.DateRightDelim;
        this._server=connection.Server;
        this._optimized=connection.Optimized;
    }

    public bool CheckConnection(string login,string password)
        {return CheckConnectionImpl(login,password);}

    public DataSet RunSql(string sql)
        {return RunSqlImpl(sql);}

    public DataSet RunSql(string sql,int firstRecord, int recordsNumber)
    {
        if(_server=="MySQL" && _optimized)
        {
            sql += " LIMIT " + firstRecord.ToString() + ", " + recordsNumber.ToString();
            firstRecord = 0;
        }
        if(_server=="PostgreSQL" && _optimized)
        {
            sql += " LIMIT " + recordsNumber.ToString() + " OFFSET " + firstRecord.ToString();
            firstRecord = 0;
        }
        return RunSqlImpl(sql,firstRecord,recordsNumber);
    }

    public int ExecuteNonQuery(string sql)
        {return ExecuteNonQueryImpl(sql);}

    public object ExecuteScalar(string sql)
        {return ExecuteScalarImpl(sql);}

    public IDataReader ExecuteReader(string sql)
        {return ExecuteReaderImpl(sql);}

    public IDataParameter GetSPParameter(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
        {return GetSPParameterImpl(name,value,paramType,paramDirection,size,scale,precision);}

    public int RunSP(string sprocName, ParameterCollection parameters)
        {return RunSPImpl(sprocName,parameters);}

    public int RunSP(string sprocName, ParameterCollection parameters, DataSet retSet)
        {return RunSPImpl(sprocName,parameters,retSet);}

    public int RunSP(string sprocName, ParameterCollection parameters, IDataReader dr)
        {return RunSPImpl(sprocName,parameters,dr);}

    public int RunSP(string sprocName, ParameterCollection parameters, DataSet retSet, int firstRecord, int recordsNumber)
        {return RunSPImpl(sprocName,parameters,retSet,firstRecord,recordsNumber);}

    public string ToSql(string param,FieldType paramType)
    {
        return ToSql(param,paramType, true);
    }

    public string ToSql(string param,FieldType paramType, bool addQuotes)
    {
        string startQuoteSign = "";
        string endQuoteSign = "";
        if(addQuotes && (param == null || param == ""))return "NULL";
        if( addQuotes )
            if(_server == "MSSQLServer")
            {
                startQuoteSign = "N'";
                endQuoteSign = "'";
            }
            else
            {
                startQuoteSign = "'";
                endQuoteSign = "'";
            }
            switch (paramType)
            {
            case FieldType.Text:
            case FieldType.Memo:
                if(_server == "MySQL") param = param.Replace(@"\", @"\\");
                return startQuoteSign + param.Replace("'", "''") + endQuoteSign;
            case FieldType.Integer:
            case FieldType.Float:
            case FieldType.Single:
                return param.Replace(",",".");
            case FieldType.Date:
                return (addQuotes ? dateLeftDelim : "") + param + (addQuotes ? dateRightDelim : "");
            case FieldType.Boolean:
                return param;
            default:
                return "";
            }
    }
    protected virtual bool CheckConnectionImpl(string login,string password)
        {return true;}

    protected virtual DataSet RunSqlImpl(string sql)
        {return null;}

    protected virtual DataSet RunSqlImpl(string sql,int firstRecord, int recordsNumber)
        {return null;}

    protected virtual IDataReader ExecuteReaderImpl(string sql)
        {return null;}

    protected virtual int ExecuteNonQueryImpl(string sql)
        {return 0;}

    protected virtual object ExecuteScalarImpl(string sql)
        {return 0;}

    protected virtual IDataParameter GetSPParameterImpl(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
        {return null;}

    protected virtual int RunSPImpl(string sprocName, ParameterCollection parameters)
        {return 0;}

    protected virtual int RunSPImpl(string sprocName, ParameterCollection parameters, DataSet retSet)
        {return 0;}

    protected virtual int RunSPImpl(string sprocName, ParameterCollection parameters, IDataReader dr)
        {return 0;}

    protected virtual int RunSPImpl(string sprocName, ParameterCollection parameters, DataSet retSet, int firstRecord, int recordsNumber)
        {return 0;}
}
}
//End CodeCharge.Data.DataAccessObject Class

