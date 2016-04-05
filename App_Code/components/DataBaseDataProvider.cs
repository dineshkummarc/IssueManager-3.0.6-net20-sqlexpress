//DataBaseDataProvider Class @0-1D0EBBFD
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace IssueManager.Data
{
public class DataCommand
{
private ParameterCollection mParameters=new ParameterCollection();
private StringBuilder _sql;
private string _sqlStore;
private string _orderBy="";
private DataAccessObject _dao;
    public DataCommand()
    {
    }
    public ParameterCollection Parameters
    {
        get{return mParameters;}
        set{mParameters=value;}
    }
    public StringBuilder SqlQuery
    {
        get{return _sql;}
        set{_sql = value; _sqlStore = value.ToString();}
    }
    public DataAccessObject Dao
    {
        get{return _dao;}
        set{_dao=value;}
    }
    public string OrderBy
    {
        get{return _orderBy;}
        set{_orderBy=value;}
    }

    public string DateFormat
    {
        get{return Dao.DateFormat;}
        set{Dao.DateFormat=value;}
    }

    public string BoolFormat
    {
        get{return Dao.BoolFormat;}
        set{Dao.BoolFormat=value;}
    }

    public void Reset()
    {
        Parameters.Clear();
        _sql = new StringBuilder(_sqlStore);
    }
    public DataSet Execute()
    {
        return ExecuteImpl();
    }
    public DataSet Execute(int startRecord, int maxRecords)
    {
        return ExecuteImpl(startRecord,maxRecords);
    }
    public object ExecuteNonQuery()
    {
        return ExecuteNonQueryImpl();
    }
    public object ExecuteScalar()
    {
        return ExecuteScalarImpl();
    }
    public IDataReader ExecuteReader()
    {
        return ExecuteReaderImpl();
    }
    protected virtual DataSet ExecuteImpl()
    {
        return null;
    }
    protected virtual DataSet ExecuteImpl(int startRecord, int maxRecords)
    {
        return null;
    }
    protected virtual object ExecuteNonQueryImpl()
    {
        return 0;
    }
    protected virtual object ExecuteScalarImpl()
    {
        return 0;
    }
    protected virtual IDataReader ExecuteReaderImpl()
    {
        return null;
    }
}
}
//End DataBaseDataProvider Class

