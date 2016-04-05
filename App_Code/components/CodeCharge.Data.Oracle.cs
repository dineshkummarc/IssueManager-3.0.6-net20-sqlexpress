//CodeCharge.Data.OracleDAO Class @0-C1517123
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections;
using System.Data.OracleClient; 

namespace IssueManager.Data
{

/// <summary>
/// Data Access Object for work with Oracle Sql server.
/// </summary>


public class OracleDao:DataAccessObject 
{ 
    private OracleType[] aliases=new OracleType[]{OracleType.Number,OracleType.Number,OracleType.Char,OracleType.DateTime,
            OracleType.DateTime,OracleType.Number,OracleType.Double,OracleType.Int32,OracleType.Byte,OracleType.Int16,
            OracleType.NChar,OracleType.NClob,OracleType.Number,OracleType.NVarChar,OracleType.Float,OracleType.DateTime,
            OracleType.Clob,OracleType.DateTime,OracleType.VarChar,OracleType.Cursor};

    private OracleConnection m_connection;
    private ConnectionString s_connection;
    public OracleDao(ConnectionString connection):base(connection)
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
                using( System.Data.OracleClient.OracleCommand command=new System.Data.OracleClient.OracleCommand(s_connection.ConnectionCommands[sql],Connection) )
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
        using( System.Data.OracleClient.OracleCommand command=new System.Data.OracleClient.OracleCommand(sql, Connection) ){
            command.Connection.Open();
            result=Convert.ToInt32(command.ExecuteNonQuery());
            command.Connection.Close();
        }
        return result;
    }

    protected override object ExecuteScalarImpl(string sql)
    { 
        object result;
        using( System.Data.OracleClient.OracleCommand command=new System.Data.OracleClient.OracleCommand(sql, Connection) ){
            command.Connection.Open();
            result= command.ExecuteScalar();
            command.Connection.Close();
        }
        return result;
    }

    protected System.Data.OracleClient.OracleCommand CreateCommand(string sprocName,ParameterCollection parameters)
    {
        System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand( sprocName, Connection );
        command.CommandType = CommandType.StoredProcedure;

        for(int i=0;i<parameters.Count;i++)
        command.Parameters.Add( (OracleParameter)parameters[i].Value );

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

    protected override int RunSPImpl(string sprocName, ParameterCollection parameters)
    {
        using( System.Data.OracleClient.OracleCommand command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            foreach ( OracleParameter parameter in command.Parameters)
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
//End CodeCharge.Data.OracleDAO Class

