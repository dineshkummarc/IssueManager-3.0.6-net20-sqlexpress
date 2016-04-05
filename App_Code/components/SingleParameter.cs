//FloatParameter Class @0-640160B5
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public class SingleParameter : Parameter
    {
        private Single _value;

        public Single Value
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

        public SingleParameter(Single floatValue)
        {
            this.Value = floatValue;
        }

        public override object GetValue()
        {
            return (object)Value;
        }
        public override string GetFormattedValue(string format)
        {
            return DBUtility.FormatNumber(_value, format);
        }

        public static SingleParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static SingleParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static SingleParameter GetParam(object param, string format)
        {
            return GetParam(param, format, null);
        }

        public static SingleParameter GetParam(object param, string format, object defaultValue)
        {
            object Value  = Parameter.GetParamAsString(param, defaultValue);
            if (Value == null) return null;
            Single floatValue;
            if(Value is string)
                floatValue = DBUtility.ParseSingle(Value.ToString(), format);
            else
                floatValue = Convert.ToSingle(Value);

            SingleParameter p = new SingleParameter(floatValue);
            return p;
        }
    }
}
//End FloatParameter Class

