//LocalesConfigHandler @0-CA35D413
//Target Framework version is 2.0
using System;
using System.Xml;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace IssueManager
{
	public class CCSCultureInfo:CultureInfo
	{
		public CCSCultureInfo(string name):base(name)
		{
		}
		private string m_BooleanFormat;
		private string m_numberZeroFormat;
		private string m_numberNullFormat;
		private string m_outputEncoding;
		private string m_defaultCountry;
		private string[] m_weekdayNarrowNames;

		public string BooleanFormat
		{
			get
			{
				return m_BooleanFormat;
			}
			set
			{
				m_BooleanFormat = value;
			}

		}
		public string NumberZeroFormat
		{
			get
			{
				return m_numberZeroFormat;
			}
			set
			{
				m_numberZeroFormat = value;
			}
		}
		public string[] WeekdayNarrowNames
		{
			get
			{
				return m_weekdayNarrowNames;
			}
			set
			{
				m_weekdayNarrowNames = value;
			}
		}
		public string DefaultCountry
		{
			get
			{
				return m_defaultCountry;
			}
			set
			{
				m_defaultCountry = value;
			}
		}

		public string NumberNullFormat
		{
			get
			{
				return m_numberNullFormat;
			}
			set
			{
				m_numberNullFormat = value;
			}

		}
		public string Encoding
		{
			get
			{
				return m_outputEncoding;
			}
			set
			{
				m_outputEncoding = value;
			}

		}
	}
	public class LocalesConfigHandler:System.Configuration.IConfigurationSectionHandler
	{
		public LocalesConfigHandler()
		{
		}
		public object Create(object parent, object configContext, XmlNode section)
		{
			Hashtable locales = new Hashtable();
			foreach(XmlNode node in section.SelectNodes("*"))
			{
				CCSCultureInfo ci = new CCSCultureInfo(node.SelectSingleNode("@name").Value);
				locales.Add(node.SelectSingleNode("@language").Value + (node.SelectSingleNode("@country").Value==""?"":("-"+node.SelectSingleNode("@country").Value)),ci);	
				ci.BooleanFormat = node.SelectSingleNode("@booleanFormat").Value;
				ci.DefaultCountry = node.SelectSingleNode("@defaultCountry").Value;
				ci.Encoding = node.SelectSingleNode("@encoding").Value;
				if(node.SelectSingleNode("@weekdayShortNames")!=null)
					ci.DateTimeFormat.AbbreviatedDayNames = node.SelectSingleNode("@weekdayShortNames").Value.Split(new char[]{';'});
				if(node.SelectSingleNode("@weekdayNarrowNames")!=null)
					ci.WeekdayNarrowNames= node.SelectSingleNode("@weekdayNarrowNames").Value.Split(new char[]{';'});
				if(node.SelectSingleNode("@weekdayNames")!=null)
					ci.DateTimeFormat.DayNames = node.SelectSingleNode("@weekdayNames").Value.Split(new char[]{';'});
				if(node.SelectSingleNode("@monthShortNames")!=null)
					ci.DateTimeFormat.AbbreviatedMonthNames = node.SelectSingleNode("@monthShortNames").Value.Split(new char[]{';'});
				if(node.SelectSingleNode("@monthNames")!=null)
					ci.DateTimeFormat.MonthNames = node.SelectSingleNode("@monthNames").Value.Split(new char[]{';'});
				if(node.SelectSingleNode("@shortDate")!=null)
					ci.DateTimeFormat.ShortDatePattern = node.SelectSingleNode("@shortDate").Value;
				if(node.SelectSingleNode("@shortTime")!=null)
					ci.DateTimeFormat.ShortTimePattern = node.SelectSingleNode("@shortTime").Value;
				if(node.SelectSingleNode("@longDate")!=null)
					ci.DateTimeFormat.LongDatePattern = node.SelectSingleNode("@longDate").Value;
				if(node.SelectSingleNode("@longTime")!=null)
					ci.DateTimeFormat.LongTimePattern = node.SelectSingleNode("@longTime").Value;
				if(node.SelectSingleNode("@firstWeekDay")!=null)
					ci.DateTimeFormat.FirstDayOfWeek = (System.DayOfWeek)Int16.Parse(node.SelectSingleNode("@firstWeekDay").Value);

				if(node.SelectSingleNode("@decimalDigits")!=null)
					ci.NumberFormat.NumberDecimalDigits = int.Parse(node.SelectSingleNode("@decimalDigits").Value);
				if(node.SelectSingleNode("@decimalSeparator")!=null)
					ci.NumberFormat.NumberDecimalSeparator = node.SelectSingleNode("@decimalSeparator").Value;
				if(node.SelectSingleNode("@groupSeparator")!=null)
					ci.NumberFormat.NumberGroupSeparator = node.SelectSingleNode("@groupSeparator").Value;
				/*if(node.SelectSingleNode("@groupSizes")!=null)
					ci.NumberFormat.NumberGroupSizes = node.SelectSingleNode("@groupSizes").Value.Split(new char[]{';'});*/
				if(node.SelectSingleNode("@zeroFormat")!=null)
					ci.NumberZeroFormat = node.SelectSingleNode("@zeroFormat").Value;
				if(node.SelectSingleNode("@nullFormat")!=null)
					ci.NumberNullFormat = node.SelectSingleNode("@nullFormat").Value;
			}
			return locales;
		}
	}
}

//End LocalesConfigHandler

