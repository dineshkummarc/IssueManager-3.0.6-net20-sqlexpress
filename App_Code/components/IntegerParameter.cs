//IntegerParameter Class @0-ADD13C6D
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public class IntegerParameter : Parameter
    {
        private Int64 _value;

        public Int64 Value
        {
            get 
            { 
                return _value;
            }
            set 
            { 
                _value = value;
            }
        }

        public IntegerParameter(Int64 intValue)
        {
            this.Value = intValue;
        }

        public override object GetValue()
        {
            return (object)Value;
        }
        public override string GetFormattedValue(string format)
        {
            return DBUtility.FormatNumber(_value,format);
        }

        public static IntegerParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static IntegerParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static IntegerParameter GetParam(object param, string format)
        {
            return GetParam(param, format, null);
        }

        public static IntegerParameter GetParam(object param, string format, object defaultValue)
        {
            object Value  = Parameter.GetParamAsString(param, defaultValue);
            if (Value == null) return null;
            Int64 intValue;
            if(Value is string)
                intValue = DBUtility.ParseInt(Value.ToString(),format);
            else
                intValue = Convert.ToInt64(Value);

            IntegerParameter p = new IntegerParameter(intValue);
            return p;
        }
    }
}
//End IntegerParameter Class

