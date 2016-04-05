//SqlCommand Class @0-A74616E5
//Target Framework version is 2.0
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Web;
using IssueManager.Configuration;

namespace IssueManager.Data
{
public class SpCommand:DataCommand
{
    public SpCommand(string spName,DataAccessObject dao)
    {
        SqlQuery=new StringBuilder(spName);
        Dao=dao;
    }

    public void ClearParams()
    {
        Parameters.Clear();
    }

    public void AddParameter(string paramName,object paramValue,ParameterType paramType, ParameterDirection paramDirection, int paramSize, byte paramScale,byte paramPrecision)
    {
        if(paramValue is Parameter) paramValue = ((Parameter)paramValue).GetValue();
        if(paramValue is FieldBase) paramValue = ((FieldBase)paramValue).Value;
        object param = Dao.GetSPParameter(paramName,paramValue,paramType,paramDirection,paramSize,paramScale,paramPrecision);
        if(param != null)
            Parameters.Add(paramName,param);
    }

    override protected DataSet ExecuteImpl()
    {
        DataSet ds=new DataSet();
        Dao.RunSP(SqlQuery.ToString(), Parameters,ds);
        return ds;
    }

    override protected DataSet ExecuteImpl(int startRecord, int maxRecords)
    {
        DataSet ds=new DataSet();
        Dao.RunSP(SqlQuery.ToString(), Parameters, ds, startRecord, maxRecords);
        return ds;
    }

    override protected IDataReader ExecuteReaderImpl()
    {
        return Dao.ExecuteReader(SqlQuery.ToString());
    }

    override protected object ExecuteNonQueryImpl()
    {
        return Dao.RunSP(SqlQuery.ToString(), Parameters);
    }

}
}
//End SqlCommand Class

