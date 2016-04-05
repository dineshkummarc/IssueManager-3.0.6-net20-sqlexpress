//Parameter Class @0-C26F49DF
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public abstract class Parameter
    {
        protected static object GetParamAsString(object param, object defaultValue)
        {
            if (param == null) return defaultValue;
            string strValue;
            strValue = param.ToString();
            if (strValue == "") return defaultValue;
            return param;
        }
        public abstract string GetFormattedValue(string format);
        public abstract object GetValue();
    } 
}
//End Parameter Class

