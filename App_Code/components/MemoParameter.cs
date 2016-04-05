//MemoParameter Class @0-1C32B473
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public class MemoParameter : Parameter
    {
        private string _value;

        public string Value
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

        public MemoParameter(string strValue)
        {
            this.Value = strValue;
        }

        public override object GetValue()
        {
            return (object)Value;
        }
        public override string GetFormattedValue(string format)
        {
            return _value;
        }

        public static MemoParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static MemoParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static MemoParameter GetParam(object param, string format)
        {
            return GetParam(param, format, null);
        }

        public static MemoParameter GetParam(object param, string format, object defaultValue)
        {
            object strValue;
            strValue  = Parameter.GetParamAsString(param, defaultValue);

            if (strValue == null)
                return null;

            MemoParameter p = new MemoParameter(strValue.ToString());
            return p;
        }
    }
}
//End MemoParameter Class

