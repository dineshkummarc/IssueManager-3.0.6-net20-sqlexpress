//BooleanParameter Class @0-2FC6FC5D
//Target Framework version is 2.0
using System;
using System.Globalization;

namespace IssueManager.Data
{

    public class BooleanParameter : Parameter
    {
        private bool _value;

        public bool Value
        {
            get 
            {return _value;}
            set 
            {_value = value;}
        }

        public BooleanParameter(bool boolValue)
        {
            _value = boolValue;
        }

        public override object GetValue()
        {
            return (object)Value;
        }
        public override string GetFormattedValue(string format)
        {
            string result=DBUtility.FormatBool(_value,format);
            try{
                Int32.Parse(result);
                return result;
            }catch{
                if(result.ToLower(CultureInfo.CurrentCulture)=="true" || result.ToLower(CultureInfo.CurrentCulture)=="false")
                return result;
                else
                return "'"+result+"'";
            }
        }

        public static BooleanParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static BooleanParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static BooleanParameter GetParam(object param, string format)
        {
            return GetParam(param, format, null);
        }

        public static BooleanParameter GetParam(object param, string format, object defaultValue)
        {
            object Value  = Parameter.GetParamAsString(param, defaultValue);

            if (Value == null) return null;
            bool boolValue;
            if(Value is string)
                boolValue = DBUtility.ParseBool(Value.ToString(),format);
            else
                boolValue = Convert.ToBoolean(Value);

            BooleanParameter p = new BooleanParameter(boolValue);
            return p;
        }
    } 
}
//End BooleanParameter Class

