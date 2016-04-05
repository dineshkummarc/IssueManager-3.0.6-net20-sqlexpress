//DateParameter Class @0-68EDAB10
//Target Framework version is 2.0
using System;

namespace IssueManager.Data
{
    public class DateParameter : Parameter
    {
        private DateTime _value;

        public DateTime Value
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

        public DateParameter (DateTime dateTimeValue)
        {
            this.Value = dateTimeValue;
        }

        public override object GetValue()
        {
            return (object)Value;
        }
        public override string GetFormattedValue(string format)
        {
            if(format.Length==0)
                return _value.ToString();
        else if(format != null && format == "wi")
            return ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).WeekdayNarrowNames[(int)_value.DayOfWeek];
            else
                return _value.ToString(format);
        }

        public static DateParameter GetParam(object param)
        {
            return GetParam(param, "", null);
        }

        public static DateParameter GetParam(object param, object defaultValue)
        {
            return GetParam(param, "", defaultValue);
        }

        public static DateParameter GetParam(object param, string format)
        {
                return GetParam(param, format, null);
        }

        public static DateParameter GetParam(object param, string format, object defaultValue)
        {
            object Value  = Parameter.GetParamAsString(param, defaultValue);

            if (Value == null) return null;
            DateTime dateValue;
            if(Value is string)
                dateValue = DBUtility.ParseDate(Value.ToString(),format);
            else if(Value is TimeSpan)
                dateValue = new DateTime(1,1,1) + (TimeSpan)Value;
            else
                dateValue = Convert.ToDateTime(Value);

            DateParameter p = new DateParameter(dateValue);
            return p;
        }
    }
}
//End DateParameter Class

