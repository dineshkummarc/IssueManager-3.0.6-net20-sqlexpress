//TextParameter Class @0-F116CD16
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public class TextParameter : Parameter
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

        public TextParameter(string strValue)
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

        public static TextParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static TextParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static TextParameter GetParam(object param, string format)
        {
            return GetParam(param, format, null);
        }

        public static TextParameter GetParam(object param, string format, object defaultValue)
        {
            object strValue = Parameter.GetParamAsString(param, defaultValue);

            if (strValue == null)
                return null;

            TextParameter p = new TextParameter(strValue.ToString());
            return p;
        }
    }
}
//End TextParameter Class

