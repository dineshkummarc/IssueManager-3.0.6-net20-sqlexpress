//RecordDataProvider Class @1-95550D1C
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace IssueManager.Data
{
public class RecordDataProviderBase
{
    protected DataCommand Select;
    protected DataCommand Insert;
    protected DataCommand Update;
    protected DataCommand Delete;
    protected bool IsInsertMode;
    protected bool CmdExecution = true;
    protected bool IsParametersPassed = true;
    protected Hashtable CommonParameters=new Hashtable();

    protected virtual void PrepareSelect()
    {
    }

    protected DataSet ExecuteSelect()
    {
    PrepareSelect();
    return Select.Execute(0, 1);
    }

    protected virtual void PrepareInsert()
    {
    }

    protected object ExecuteInsert()
    {
    PrepareInsert();
    if(CmdExecution)
        return Insert.ExecuteNonQuery();
    else
        return 0;
    }

    protected virtual void PrepareUpdate()
    {
    }

    protected object ExecuteUpdate()
    {
    PrepareUpdate();
    if(CmdExecution && IsParametersPassed)
        return Update.ExecuteNonQuery();
    else
        return 0;
    }

    protected virtual void PrepareDelete()
    {
    }

    protected object ExecuteDelete()
    {
    PrepareDelete();
    if(CmdExecution && IsParametersPassed)
        return Delete.ExecuteNonQuery();
    else
        return 0;
    }
}
}
//End RecordDataProvider Class

