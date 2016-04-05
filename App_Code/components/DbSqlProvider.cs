//SqlCommand Class @0-D4EA9DC2
//Target Framework version is 2.0
using System;
using System.Data;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using IssueManager.Configuration;

namespace IssueManager.Data
{
public class SqlCommand:DataCommand
{

    public SqlCommand(string sqlQuery,DataAccessObject dao)
    {
        SqlQuery=new StringBuilder(sqlQuery);
        Dao=dao;
    }

    public void AddParameter(string paramName,FieldBase param, string format)
    {
        if(param == null) return;
        FieldType ft = FieldType.Text;
        if(param is TextField || param is MemoField) ft = FieldType.Text;
        if(param is FloatField || param is SingleField || param is IntegerField) ft = FieldType.Integer;
        if(param is BooleanField) ft = FieldType.Boolean;
        if(param is DateField) ft = FieldType.Date;
        AddParameter(paramName, param.GetFormattedValue(format),ft);
    }
    public void AddParameter(string paramName,Parameter param, string format)
    {
        if(param == null) return;
        FieldType ft = FieldType.Text;
        if(param is TextParameter || param is MemoParameter) ft = FieldType.Text;
        if(param is FloatParameter || param is SingleParameter || param is IntegerParameter) ft = FieldType.Integer;
        if(param is BooleanParameter) ft = FieldType.Boolean;
        if(param is DateParameter) ft = FieldType.Date;
        AddParameter(paramName, param.GetFormattedValue(format), ft);
    }
    protected void AddParameter(string paramName,string param, FieldType fieldType)
    {
        if(param == null) return;
        Parameters.Add(paramName,Dao.ToSql(param,fieldType, false));
    }

    override protected DataSet ExecuteImpl()
    {
        return Dao.RunSql(ToString());
    }
    override protected DataSet ExecuteImpl(int startRecord, int maxRecords)
    {
        return Dao.RunSql(ToString(), startRecord, maxRecords);
    }

    override protected object ExecuteNonQueryImpl()
    {
        return Dao.ExecuteNonQuery(ToString());
    }

    override protected object ExecuteScalarImpl()
    {
        return Dao.ExecuteScalar(ToString());
    }

    override protected IDataReader ExecuteReaderImpl()
    {
        return Dao.ExecuteReader(ToString());
    }

    public override string ToString()
    {
        object[] keys = new object[Parameters.Count];
        object[] values = new object[Parameters.Count];
        Parameters.AllKeys.CopyTo(keys, 0);
        Parameters.AllValues.CopyTo(values, 0);
        for(int i=0;i<Parameters.Count;i++)
        {
            SqlQuery.Replace("{" + keys[i].ToString() + "}", values[i].ToString());
        }
        string order=OrderBy.Length>0?" ORDER BY "+OrderBy:"";
        string sSQL=SqlQuery.ToString();
        if( sSQL.IndexOf("{SQL_OrderBy}") > 0 )
        {
            sSQL = sSQL.Replace("{SQL_OrderBy}", order);
        }
        else
            sSQL += order;
        return sSQL;
    }
}
}
//End SqlCommand Class

