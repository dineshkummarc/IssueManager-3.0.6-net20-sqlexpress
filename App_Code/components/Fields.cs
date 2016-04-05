//Fields Classes @1-82008F6C
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{

public class FieldBase:IComparable
{
    private IComparable _value;
    private string _format;
    public IComparable Value{
        get{
            return _value;
        }
        set{
            _value=value;
        }
    }

    public string Format{
        get{
            return _format;
        }
        set{
            _format=value;
        }
    }

    private bool _IsEmpty;
    public bool IsEmpty{
        get{
            return _IsEmpty;
        }
        set{
            _IsEmpty=value;
        }
    }

    public FieldBase()
    {}

    public FieldBase(string format)
    {Format = format;}

    public FieldBase(string format, object defaultValue){
        Format = format;
        SetValue((IComparable)defaultValue);
    }

	public override bool Equals(object obj)
	{
		if(!(obj is FieldBase)) return false;
		if(Value==null || ((FieldBase)obj).Value ==null) return Value == ((FieldBase)obj).Value;
		return Value.Equals(((FieldBase)obj).Value);
	}
	
	protected static bool IsNull(object obj)
	{
		return obj == null;
	}

	public int CompareTo(object obj)
	{
		if(Value == null) return -1;
		return Value.CompareTo(((FieldBase)obj).Value);
	}

	public static bool operator ==(FieldBase a, FieldBase b)
	{
		if(IsNull(a) && IsNull(b)) return true;
		if(IsNull(a) && !IsNull(b)) return false;
		if(!IsNull(a) && IsNull(b)) return false;
		return a.Equals(b);
	}
	public static bool operator !=(FieldBase a, FieldBase b)
	{
		return !(a == b);
	}
	public static bool operator >=(FieldBase a, FieldBase b)
	{
		if(a == null) return a == b;
		return a.CompareTo(b) >= 0 ;
	}
	public static bool operator >(FieldBase a, FieldBase b)
	{
		if(a == null) return false;
		return a.CompareTo(b) > 0 ;
	}
	public static bool operator <=(FieldBase a, FieldBase b)
	{
		if(b == null) return a == b;
		return b.CompareTo(a) >= 0 ;
	}
	public static bool operator <(FieldBase a, FieldBase b)
	{
		if(b == null) return false;
		return b.CompareTo(a) > 0 ;
	}
	
    public virtual string GetFormattedValue(string format){
        if(Value == null || Value.Equals(DBNull.Value))
            return "";
        else
            return Value.ToString();
    }

    public virtual string GetFormattedValue(){
        return GetFormattedValue(Format);
    }

    public virtual void SetValue(object value,string format){
        if(value == null) return;
        if(value == null || value.Equals(DBNull.Value) || value.ToString() == "")
            this.Value=null;
        else
            this.Value=(IComparable)value;
    }
    public virtual void SetValue(object value){
        SetValue(value, Format);
    }
}

public class TextField:FieldBase
{
    public TextField()
    {}
    public TextField(string format)
    {Format = format;}

    public TextField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }

}

public class MemoField:FieldBase
{
    public MemoField()
    {}
    public MemoField(string format)
    {Format = format;}

    public MemoField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }

}

public class IntegerField:FieldBase
{
    public IntegerField()
    {}
    public IntegerField(string format)
    {Format = format;}

    public IntegerField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }


    public override string GetFormattedValue(string format){
        if(Value == null || Value.Equals(DBNull.Value))
            return "";
        else
            return DBUtility.FormatNumber(Value,format);
    }

    public override string GetFormattedValue(){
        return GetFormattedValue(Format);
    }

    public override void SetValue(object value,string format){
        if(value == null) return;
        if(value.Equals(DBNull.Value) || value.ToString() == "")
            this.Value=null;
        else
            try{
            if(value is String)
                this.Value=DBUtility.ParseInt(value.ToString(),format);
            else
                this.Value=Convert.ToInt64(value);
            }catch{
                throw new ArgumentException("Unable to set value for the Integer field: Unable to parse the 'Value' argument or cast it to the System.Int64 type");
            }
    }
    public override void SetValue(object value){
        SetValue(value, Format);
    }
}

public class FloatField:FieldBase
{
    public FloatField()
    {}

    public FloatField(string format)
    {Format = format;}

    public FloatField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }

    public override string GetFormattedValue(string format){
        if(Value == null || Value.Equals(DBNull.Value))
            return "";
        else
            return DBUtility.FormatNumber(Value,format);
    }

    public override string GetFormattedValue(){
        return GetFormattedValue(Format);
    }

    public override void SetValue(object value,string format){
        if(value == null) return;
        if(value.Equals(DBNull.Value) || value.ToString() == "")
            this.Value=null;
        else
            try{
            if(value is String)
                this.Value=DBUtility.ParseDouble(value.ToString(),format);
            else
                this.Value=Convert.ToDouble(value);
            }catch{
                throw new ArgumentException("Unable to set value for the Float field: Unable to parse the 'Value' argument or cast it to the System.Double type");
            }
    }
    public override void SetValue(object value){
        SetValue(value,Format);
    }
}

public class SingleField:FieldBase
{
    public SingleField()
    {}

    public SingleField(string format)
    {Format = format;}

    public SingleField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }

    public override string GetFormattedValue(string format){
        if(Value == null || Value.Equals(DBNull.Value))
            return "";
        else
            return DBUtility.FormatNumber(Value,format);
    }

    public override string GetFormattedValue(){
        return GetFormattedValue(Format);
    }

    public override void SetValue(object value,string format){
        if(value == null) return;
        if(value.Equals(DBNull.Value) || value.ToString() == "")
            this.Value=null;
        else
            try{
            if(value is String)
                this.Value=DBUtility.ParseSingle(value.ToString(),format);
            else
                this.Value=Convert.ToSingle(value);
            }catch{
                throw new ArgumentException("Unable to set value for the Single field: Unable to parse the 'Value' argument or cast it to the System.Double type");
            }
    }
    public override void SetValue(object value){
        SetValue(value,Format);
    }
}

public class DateField:FieldBase
{
    public DateField()
    {}

    public DateField(string format)
    {Format = format;}

    public DateField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }

    public override string GetFormattedValue(string format){
        if(Value == null || Value.Equals(DBNull.Value))
            return "";
        else if(format != null && format == "wi")
            return ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).WeekdayNarrowNames[(int)((DateTime)Value).DayOfWeek];
        else
            return ((DateTime)Value).ToString(format);
    }

    public override string GetFormattedValue(){
        return GetFormattedValue(Format);
    }

    public override void SetValue(object value,string format){
        if(value == null) return;
        if(value.Equals(DBNull.Value) || value.ToString() == "")
            this.Value=null;
        else
            try{
            if(value is String)
                this.Value=DBUtility.ParseDate(value.ToString(),format);
            else if(value is TimeSpan)
                this.Value=new DateTime(1,1,1) + (TimeSpan)value;
            else
                this.Value=Convert.ToDateTime(value);
            }catch{
                throw new ArgumentException("Unable to set value for the Date field: Unable to parse the 'Value' argument or cast it to the System.DateTime type");
            }
    }
    public override void SetValue(object value){
        SetValue(value, Format);
    }
}

public class BooleanField:FieldBase
{
    public BooleanField()
    {}

    public BooleanField(string format)
    {Format = format;}

    public BooleanField(string format, object defaultValue){
        Format = format;
        SetValue(defaultValue);
    }

    public override string GetFormattedValue(string format){
        return DBUtility.FormatBool(Value,format);
    }

    public override string GetFormattedValue(){
        return GetFormattedValue(Format);
    }

    public override void SetValue(object value,string format){
        if(value == null) return;
        if(value.Equals(DBNull.Value) || value.ToString() == "")
            this.Value=null;
        else
            try{
            if(value is String)
                this.Value=DBUtility.ParseBool(value.ToString(),format);
            else
                this.Value=Convert.ToBoolean(value);
            }catch{
                throw new ArgumentException("Unable to set value for the Boolean field: Unable to parse the 'Value' argument or cast it to the System.Boolean type");
            }
    }
    public override void SetValue(object value){
        SetValue(value, Format);
    }
}
}
//End Fields Classes

