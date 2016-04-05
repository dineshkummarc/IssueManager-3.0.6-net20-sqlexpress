//GridDataProvider Class @1-93EB7891
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace IssueManager.Data
{
public class GridDataProviderBase
{
    protected DataCommand Select;
    protected DataCommand Count;
    protected Hashtable Parameters=new Hashtable();
    protected int mRecordCount;
    protected int mPagesCount;

    public int RecordCount{
        get{
            return mRecordCount;
        }
    }

    public int PagesCount{
        get{
            return mPagesCount;
        }
    }

    protected bool _isEmpty = true;
    public bool IsEmpty{
        get{
            return _isEmpty;
        }
    }

    protected virtual void PrepareSelect()
    {
    }

    protected IDataReader ExecuteDataReader()
    {
    return Select.ExecuteReader();
    }

    protected DataSet ExecuteSelect()
    {
    return Select.Execute();
    }

    protected DataSet ExecuteSelect(int startRecord, int maxRecords)
    {
    return Select.Execute(startRecord,maxRecords);
    }

    protected int ExecuteCount()
    {
    return Convert.ToInt32(Count.ExecuteScalar());
    }
}

public delegate void ItemUpdatedEventHandler(object sender, ItemUpdatedEventArgs e);

public enum EditableGridOperation {Insert, Update, Delete};

public class ItemUpdatedEventArgs
{
    public EditableGridOperation Operation;
    public object Item;
    public ItemUpdatedEventArgs(EditableGridOperation operation, object item)
    {
        Operation = operation;
        Item = item;
    }
}

public class EditableGridDataProviderBase:GridDataProviderBase
{
    public event ItemUpdatedEventHandler ItemUpdated;
    protected virtual void OnItemUpdated(ItemUpdatedEventArgs e)
    {
        if(ItemUpdated != null)
            ItemUpdated(this, e);
    }
}
}
//End GridDataProvider Class

