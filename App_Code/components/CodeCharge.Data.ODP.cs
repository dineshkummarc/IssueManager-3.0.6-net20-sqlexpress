//CodeCharge.Data.ODPDAO Class @0-4828483C
//Target Framework version is 2.0
using System;
using System.Data;
#if ODP_INSTALLED
using Oracle.DataAccess.Client;

namespace IssueManager.Data
{

/// <summary>
/// Data Access Object for work with Oracle Sql server.
/// </summary>


public class ODPDao:DataAccessObject 
{ 
    private OracleDbType[] aliases=new OracleDbType[]{OracleDbType.Int64,OracleDbType.Byte,OracleDbType.Char,OracleDbType.Date,
            OracleDbType.Date,OracleDbType.Decimal,OracleDbType.Double,OracleDbType.Int32,OracleDbType.Byte,OracleDbType.Int16,
            OracleDbType.NChar,OracleDbType.NClob,OracleDbType.Int32,OracleDbType.NVarchar2,OracleDbType.Double,OracleDbType.Date,
            OracleDbType.Clob,OracleDbType.Date,OracleDbType.Varchar2,OracleDbType.RefCursor};

    private OracleConnection m_connection;
    private ConnectionString s_connection;
    public ODPDao(ConnectionString connection):base(connection)
    {
        Connection=new OracleConnection(connection.Connection); 
        s_connection=connection; 
    }

    public OracleConnection Connection
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
        set{Connection=new OracleConnection(value);}
    }

    protected void OnStateChange(object sender, StateChangeEventArgs e)
    {
        if(e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
            foreach(string sql in s_connection.ConnectionCommands)
                using( OracleCommand command=new OracleCommand(s_connection.ConnectionCommands[sql],Connection) )
                    command.ExecuteNonQuery();
    }

    protected override bool CheckConnectionImpl(string login,string password)
        {
        ConnectionString+=";User ID=\""+login+"\";Password=\""+password+"\"";
        try{
            Connection.Open();
            Connection.Close();
        }catch{return false;}
        return true;
        }

    protected override DataSet RunSqlImpl(string sql)
    {
        DataSet dataSet=new DataSet();
        using ( OracleDataAdapter adapter=new OracleDataAdapter(sql,Connection) ){
        using (dataSet)
            adapter.Fill(dataSet);
        }
        return dataSet;
    }

    protected override DataSet RunSqlImpl(string sql,int firstRecord,int recordsNumber)
    {
        DataSet dataSet=new DataSet();
        using ( OracleDataAdapter adapter=new OracleDataAdapter(sql,Connection) ){
        using (dataSet)
            adapter.Fill(dataSet,firstRecord,recordsNumber,"Table");
        }
        return dataSet;
    }

    protected override int ExecuteNonQueryImpl(string sql)
    { 
        int result;
        using( OracleCommand command=new OracleCommand(sql, Connection) ){
            command.Connection.Open();
            result=Convert.ToInt32(command.ExecuteNonQuery());
            command.Connection.Close();
        }
        return result;
    }

    protected override object ExecuteScalarImpl(string sql)
    { 
        object result;
        using( OracleCommand command=new OracleCommand(sql, Connection) ){
            command.Connection.Open();
            result= command.ExecuteScalar();
            command.Connection.Close();
        }
        return result;
    }

    protected OracleCommand CreateCommand(string sprocName,IDataParameter[] parameters)
    {
        OracleCommand command = new OracleCommand( sprocName, Connection );
        command.CommandType = CommandType.StoredProcedure;

        foreach ( DictionaryEntry parameter in parameters )
        command.Parameters.Add( (OracleParameter)parameter.Value );

        return command;
    }

    protected override IDataParameter GetSPParameterImpl(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
        {OracleParameter p = new OracleParameter(name,aliases[(int)paramType],size);
        p.Direction=paramDirection;
        if(value==null)
            p.Value=DBNull.Value;
        else
            p.Value=value;
        return p;
        }

    protected override int RunSPImpl(string sprocName, IDataParameter[] parameters)
    {
        using( OracleCommand command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            foreach ( OracleParameter parameter in command.Parameters)
                parameters[parameter.ParameterName] = parameter;
            command.Connection.Close();
        }
        return 0;
    }

    protected override int RunSPImpl( string sprocName, IDataParameter[] parameters, DataSet retSet)
    {
        return RunSPImpl(sprocName, parameters, retSet, -1, -1);
    }

    protected override int RunSPImpl( string sprocName, IDataParameter[] parameters, DataSet retSet, int firstRecord, int recordsNumber)
    {
        using(retSet)
        using( OracleDataAdapter dataSetAdapter = new OracleDataAdapter() ){
            dataSetAdapter.SelectCommand = CreateCommand( sprocName, parameters );
            if (firstRecord < 0)
            dataSetAdapter.Fill( retSet, "SourceTable" );
            else
            dataSetAdapter.Fill( retSet, firstRecord , recordsNumber, "SourceTable" );
            foreach ( OracleParameter parameter in dataSetAdapter.SelectCommand.Parameters)
                parameters[parameter.ParameterName] = parameter;
        }
        return 0;
    }
}
}
#endif
//End CodeCharge.Data.ODPDAO Class

