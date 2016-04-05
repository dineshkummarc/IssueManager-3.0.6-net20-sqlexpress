//CodeCharge.Data.DB2DAO Class @0-5C12A26A
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections;
#if DB2_INSTALLED
using IBM.Data.DB2; 

namespace IssueManager.Data
{

/// <summary>
/// Data Access Object for work with DB2 Sql server.
/// </summary>


public class DB2Dao:DataAccessObject 
{ 
    private DB2Type[] aliases=new DB2Type[]{DB2Type.BigInt,DB2Type.SmallInt,DB2Type.Char,DB2Type.Date,
            DB2Type.Date,DB2Type.Decimal,DB2Type.Double,DB2Type.Integer,DB2Type.SmallInt,DB2Type.SmallInt,
            DB2Type.Graphic,DB2Type.Clob,DB2Type.Decimal,DB2Type.VarGraphic,DB2Type.Real,DB2Type.Timestamp,
            DB2Type.Clob,DB2Type.Time,DB2Type.VarChar};

    private DB2Connection m_connection;
    private ConnectionString s_connection;
    public DB2Dao(ConnectionString connection):base(connection)
    {
        Connection=new DB2Connection(connection.Connection); 
        s_connection=connection; 
    }

    public DB2Connection Connection
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
        set{Connection=new DB2Connection(value);}
    }

    protected void OnStateChange(object sender, StateChangeEventArgs e)
    {
        if(e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
            foreach(string sql in s_connection.ConnectionCommands)
                using( DB2Command command=new DB2Command(s_connection.ConnectionCommands[sql],Connection) )
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
        using ( DB2DataAdapter adapter=new DB2DataAdapter(sql,Connection) ){
        using (dataSet)
            adapter.Fill(dataSet);
        }
        return dataSet;
    }

    protected override DataSet RunSqlImpl(string sql,int firstRecord,int recordsNumber)
    {
        DataSet dataSet=new DataSet();
        using ( DB2DataAdapter adapter=new DB2DataAdapter(sql,Connection) ){
        using (dataSet)
            adapter.Fill(dataSet,firstRecord,recordsNumber,"Table");
        }
        return dataSet;
    }

    protected override int ExecuteNonQueryImpl(string sql)
    { 
        int result;
        using( DB2Command command=new DB2Command(sql, Connection) ){
            command.Connection.Open();
            result=Convert.ToInt32(command.ExecuteNonQuery());
            command.Connection.Close();
        }
        return result;
    }

    protected override object ExecuteScalarImpl(string sql)
    { 
        object result;
        using( DB2Command command=new DB2Command(sql, Connection) ){
            command.Connection.Open();
            result= command.ExecuteScalar();
            command.Connection.Close();
        }
        return result;
    }

    protected DB2Command CreateCommand(string sprocName,ParameterCollection parameters)
    {
        DB2Command command = new DB2Command( sprocName, Connection );
        command.CommandType = CommandType.StoredProcedure;

        for(int i=0;i<parameters.Count;i++)
        command.Parameters.Add( (DB2Parameter)parameters[i].Value );

        return command;
    }

    protected override IDataParameter GetSPParameterImpl(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
        {DB2Parameter p = new DB2Parameter(name,aliases[(int)paramType],size);
        p.Direction=paramDirection;
        if(value==null)
            p.Value=DBNull.Value;
        else
            p.Value=value;
        return p;
        }

    protected override int RunSPImpl(string sprocName, ParameterCollection parameters)
    {
        using( DB2Command command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            command.Connection.Open();
            command.ExecuteNonQuery();
            foreach ( DB2Parameter parameter in command.Parameters)
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
        using( DB2DataAdapter dataSetAdapter = new DB2DataAdapter() ){
            dataSetAdapter.SelectCommand = CreateCommand( sprocName, parameters );
            if (firstRecord < 0)
            dataSetAdapter.Fill( retSet, "SourceTable" );
            else
            dataSetAdapter.Fill( retSet, firstRecord , recordsNumber, "SourceTable" );
            foreach ( DB2Parameter parameter in dataSetAdapter.SelectCommand.Parameters)
                parameters[parameter.ParameterName] = parameter;
        }
        return 0;
    }
}
}
#endif
//End CodeCharge.Data.DB2DAO Class

