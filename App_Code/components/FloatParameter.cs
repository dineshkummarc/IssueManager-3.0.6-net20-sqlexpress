//FloatParameter Class @0-6BFB1234
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public class FloatParameter : Parameter
    {
        private Double _value;

        public Double Value
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

        public FloatParameter(Double floatValue)
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

        public static FloatParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static FloatParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static FloatParameter GetParam(object param, string format)
        {
            return GetParam(param, format, null);
        }

        public static FloatParameter GetParam(object param, string format, object defaultValue)
        {
            object Value  = Parameter.GetParamAsString(param, defaultValue);
            if (Value == null) return null;
            Double floatValue;
            if(Value is string)
                floatValue = DBUtility.ParseDouble(Value.ToString(), format);
            else
                floatValue = Convert.ToDouble(Value);

            FloatParameter p = new FloatParameter(floatValue);
            return p;
        }
    }
}
//End FloatParameter Class

