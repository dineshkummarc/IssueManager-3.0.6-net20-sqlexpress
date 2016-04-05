//CacheSettings class @0-8BC95B44
//Target Framework version is 2.0
using System;
using System.Collections;
using System.Web;
namespace IssueManager.Caching
{
	public class CacheSettings
	{
		private ArrayList m_parameters  = new ArrayList();
		internal HttpCacheValidateHandler validateCallBack;
		internal object userData = null;
		private bool m_bypassPage = false;
		
		private TimeSpan duration;

		public TimeSpan Duration
		{
			get { return duration; }
			set { duration = value; }
		}

		public ArrayList Parameters
		{
			get { return m_parameters; }
		}

		public bool BypassPage
		{
			get { return m_bypassPage; }
			set { m_bypassPage = value; }
		}

		public void AddValidationCallback( HttpCacheValidateHandler handler, object data)
		{
			validateCallBack = handler;
			userData = data;
		}
	}
}

//End CacheSettings class

