//ICacheManager class @0-8198871D
//Target Framework version is 2.0
using System;
using System.Collections;

namespace IssueManager.Caching
{
	public interface ICacheManager : IDisposable
	{
		string GetCacheKey(string page, ArrayList parameters);
		string GetPageKey(string page);
		void PutObject(string key, object item, TimeSpan duration);
		object GetObject(string key);
		void RemoveObject(string key);
		void ClearStartedWith(string pageKey);
		void ClearExpired();
	}
}

//End ICacheManager class

