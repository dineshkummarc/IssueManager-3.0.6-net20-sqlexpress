//TableCommand Class @0-FAB7E601
//Target Framework version is 2.0
using System;
using System.Data;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using IssueManager.Configuration;

namespace IssueManager.Data
{
public enum Condition{Equal,NotEqual,LessThan,LessThanOrEqual,GreaterThan,GreaterThanOrEqual,BeginsWith,NotBeginsWith,EndsWith,NotEndsWith,Contains,NotContains,NotNull,IsNull,DefaultNull}
public class TableCommand:DataCommand
{
    private string[] _whereTemplate;
    private string _where="";
    private string _operation="";

    public TableCommand(string sqlQuery, string[] whereTemplate, DataAccessObject dao):this(sqlQuery, "", "", whereTemplate, dao)
    {
    }

    public TableCommand(string sqlQuery, string staticWhere, string joinOperation, string[] whereTemplate, DataAccessObject dao)
    {
        SqlQuery=new StringBuilder(sqlQuery);
        WhereTemplate = whereTemplate;
        Where = staticWhere;
        Operation = joinOperation;
        Dao=dao;
    }

    public void AddParameter(string paramName,FieldBase param, string format, string field, Condition op, bool useDefaultNull)
    {
        string val = "";
        FieldType ft = FieldType.Boolean;
        if(useDefaultNull && param == null)
            op = Condition.IsNull;
        else if(param != null)
            val = param.GetFormattedValue(format);
        else
            {Parameters.Add(paramName,"");return;}
        if(param is TextField || param is MemoField) ft = FieldType.Text;
        if(param is FloatField || param is SingleField || param is IntegerField) ft = FieldType.Integer;
        if(param is DateField) ft = FieldType.Date;
        AddParameter(paramName, val,ft, field, op);
    }
    public void AddParameter(string paramName,Parameter param, string format, string field, Condition op, bool useDefaultNull)
    {
        string val = "";
        FieldType ft = FieldType.Boolean;
        if(useDefaultNull && param == null)
            op = Condition.IsNull;
        else if(param != null)
            val = param.GetFormattedValue(format);
        else
            {Parameters.Add(paramName,"");return;}
        if(param is TextParameter || param is MemoParameter) ft = FieldType.Text;
        if(param is FloatParameter || param is SingleParameter || param is IntegerParameter) ft = FieldType.Integer;
        if(param is DateParameter) ft = FieldType.Date;
        AddParameter(paramName, val, ft, field, op);
    }
    protected void AddParameter(string paramName,string param, FieldType fieldType, string field, Condition op)
    {
        string p = fieldType==FieldType.Text?"%":"";
        switch(op)
        {
        case Condition.Equal:
                Parameters.Add(paramName,field + " = " + Dao.ToSql(param, fieldType, true));return;
        case Condition.NotEqual:
                Parameters.Add(paramName,field + " <> " + Dao.ToSql(param, fieldType, true));return;
        case Condition.LessThan:
                Parameters.Add(paramName,field + " < " + Dao.ToSql(param, fieldType, true));return;
        case Condition.GreaterThan:
                Parameters.Add(paramName,field + " > " + Dao.ToSql(param, fieldType, true));return;
        case Condition.LessThanOrEqual:
                Parameters.Add(paramName,field + " <= " + Dao.ToSql(param, fieldType, true));return;
        case Condition.GreaterThanOrEqual:
                Parameters.Add(paramName,field + " >= " + Dao.ToSql(param, fieldType, true));return;
        case Condition.BeginsWith:
                Parameters.Add(paramName,field + " like " + Dao.ToSql(param+p, fieldType, true));return;
        case Condition.NotBeginsWith:
                Parameters.Add(paramName,field + " not like " + Dao.ToSql(param+p, fieldType, true));return;
        case Condition.EndsWith:
                Parameters.Add(paramName,field + " like " + Dao.ToSql(p+param, fieldType, true));return;
        case Condition.NotEndsWith:
                Parameters.Add(paramName,field + " not like " + Dao.ToSql(p+param, fieldType, true));return;
        case Condition.Contains:
                Parameters.Add(paramName,field + " like " + Dao.ToSql(p+param+p, fieldType, true));return;
        case Condition.NotContains:
                Parameters.Add(paramName,field + " not like " + Dao.ToSql(p+param+p, fieldType, true));return;
        case Condition.NotNull:
                Parameters.Add(paramName,field + " IS NOT NULL");return;
        case Condition.IsNull:
                Parameters.Add(paramName,field + " IS NULL");return;
        }
    }

    public string[] WhereTemplate
    {
        get{return _whereTemplate;}
        set{_whereTemplate = value;}
    }

    public string Where
    {
        get{return _where;}
        set{_where = value;}
    }

    public string Operation
    {
        get{return _operation;}
        set{_operation = value;}
    }

    protected string PrepareWhere()
    {
        string[] template = new string[WhereTemplate.Length];
        WhereTemplate.CopyTo(template, 0);
        for(int i = 0; i < template.Length; i++)
        {
            if(!(template[i] == "(" || template[i] == ")" || template[i] == "Or" || template[i] == "And")) template[i] = Parameters[template[i]].ToString();
        }
        return (new WhereBuilder(template)).GetWhere();
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
        string where=PrepareWhere();
        string sSQL=SqlQuery.ToString();
        if(where!=null&&where.Length>0)
            where=" WHERE "+ (string)(Where!=null&&Where.Length>0?Where+" "+Operation:"")+" ("+where+")";
        else
            where=(Where.Length>0)?(" WHERE "+Where):"";
        string order=OrderBy.Length>0?" ORDER BY "+OrderBy:"";
        if( sSQL.IndexOf("{SQL_Where}") > 0 || sSQL.IndexOf("{SQL_OrderBy}") > 0 )
        {
            sSQL = sSQL.Replace("{SQL_Where}", where);
            sSQL = sSQL.Replace("{SQL_OrderBy}", order);
        }
        else
            sSQL += where + order;
        return sSQL;
    }
}
}
//End TableCommand Class

