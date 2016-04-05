//CacheParameter class @0-888CD6B8
//Target Framework version is 2.0
using System;
using System.Collections;

namespace IssueManager.Caching
{
	public enum CacheParameterType{Key, Bypass}
	public enum CacheParameterSource{Get, Post, Session, Expression}
	public class CacheParameter
	{
		private CacheParameterType m_type;
		private CacheParameterSource m_source;
		private string m_name;

		public CacheParameterType Type
		{
			get { return m_type; }
			set { m_type = value; }
		}

		public CacheParameterSource Source
		{
			get { return m_source; }
			set { m_source = value; }
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public CacheParameter()
		{
			
		}
		public CacheParameter(string name, CacheParameterSource source, CacheParameterType type)
		{
			Name = name;
			Source = source;
			Type = type;
		}
	}
}

//End CacheParameter class

