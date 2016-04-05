//CodeCharge.Data.ODBC Class @0-C7BE4EC1
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections;
using System.Data.Odbc; 

namespace IssueManager.Data
{

/// <summary>
/// Data Access Object for work with ODBC data providers.
  /// </summary>

public class OdbcDao:DataAccessObject 
{
    private OdbcType[] aliases=new OdbcType[]{OdbcType.BigInt,OdbcType.Bit,OdbcType.Char,OdbcType.Date,
            OdbcType.DateTime,OdbcType.Decimal,OdbcType.Double,OdbcType.Int,OdbcType.TinyInt,OdbcType.SmallInt,
            OdbcType.NChar,OdbcType.NText,OdbcType.Numeric,OdbcType.NVarChar,OdbcType.Real,OdbcType.SmallDateTime,
            OdbcType.Text,OdbcType.Time,OdbcType.VarChar};
    private OdbcConnection m_connection;
    private ConnectionString s_connection;

    public OdbcDao(ConnectionString connection):base(connection)
    {
        Connection=new OdbcConnection(connection.Connection); 
        s_connection=connection; 
    }

    public OdbcConnection Connection
    {
        get{return m_connection;}
        set{
            m_connection = value;
            m_connection.StateChange += new StateChangeEventHandler(OnStateChange);
        }
    }

    public string ConnectionString
    {
        get{return Connection.ConnectionString;}
        set{Connection=new OdbcConnection(value);}
    }

    protected void OnStateChange(object sender, StateChangeEventArgs e)
    {
        if(e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
            foreach(string sql in s_connection.ConnectionCommands)
                using( OdbcCommand command=new OdbcCommand(s_connection.ConnectionCommands[sql],Connection) )
                    command.ExecuteNonQuery();
    }

    protected override bool CheckConnectionImpl(string login,string password)
        {
        ConnectionString="UID=\""+login+"\";PWD=\""+password+"\";"+ConnectionString;
        try{
            Connection.Open();
            Connection.Close();
        }catch{return false;}
        return true;
        }

    protected override DataSet RunSqlImpl(string sql)
    {
        DataSet dataSet=new DataSet();
        using ( OdbcDataAdapter adapter=new OdbcDataAdapter(sql,Connection) ){
        using (dataSet)
            adapter.Fill(dataSet);
        }
        return dataSet;
    }

    protected override DataSet RunSqlImpl(string sql,int firstRecord,int recordsNumber)
    {
        DataSet dataSet=new DataSet();
        using ( OdbcDataAdapter adapter=new OdbcDataAdapter(sql,Connection) ){
        using (dataSet)
            adapter.Fill(dataSet,firstRecord,recordsNumber,"Table");
        }
        return dataSet;
    }

    protected override int ExecuteNonQueryImpl(string sql)
    { 
        int result;
        using( OdbcCommand command=new OdbcCommand(sql,Connection) ){
            command.Connection.Open();
            result=Convert.ToInt32(command.ExecuteNonQuery());
            command.Connection.Close();
        }
        return result;
    }

    protected override object ExecuteScalarImpl(string sql)
    { 
        object result;
        using( OdbcCommand command=new OdbcCommand(sql,Connection) ){
            command.Connection.Open();
            result= command.ExecuteScalar();
            command.Connection.Close();
        }
        return result;
    }

    protected OdbcCommand CreateCommand(string sprocName,ParameterCollection parameters)
    {
        OdbcCommand command = new OdbcCommand( sprocName, Connection );
        command.CommandType = CommandType.StoredProcedure;

        for(int i=0;i<parameters.Count;i++)
        command.Parameters.Add( (OdbcParameter)parameters[i].Value );
        return command;
    }

    protected override IDataParameter GetSPParameterImpl(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
    {
        if(paramType == ParameterType.RecordSet) return null;
        OdbcParameter p = new OdbcParameter(name,aliases[(int)paramType],size);
        p.Direction=paramDirection;
        if(value==null)
            p.Value=DBNull.Value;
        else
            p.Value=value;
        return p;
    }

    protected override int RunSPImpl(string sprocName, ParameterCollection parameters)
    {
        using( OdbcCommand command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            foreach ( OdbcParameter parameter in command.Parameters)
                parameters[parameter.ParameterName] = parameter;
            command.Connection.Close();
        }
        return 0;
    }

    protected override int RunSPImpl( string sprocName, ParameterCollection parameters, DataSet retSet)
    {
        return RunSPImpl(sprocName, parameters, retSet, -1, -1);
    }

    protected override int RunSPImpl( string sprocName, ParameterCollection parameters, DataSet retSet, int firstRecord, int recordsNumber)
    {
        using(retSet)
        using( OdbcDataAdapter dataSetAdapter = new OdbcDataAdapter() ){
            dataSetAdapter.SelectCommand = CreateCommand( sprocName, parameters );
            if (firstRecord < 0)
            dataSetAdapter.Fill( retSet, "SourceTable" );
            else
            dataSetAdapter.Fill( retSet, firstRecord , recordsNumber, "SourceTable" );
            foreach ( OdbcParameter parameter in dataSetAdapter.SelectCommand.Parameters)
                parameters[parameter.ParameterName] = parameter;
        }
        return 0;
    }
}
}
//End CodeCharge.Data.ODBC Class

