//CacheManager class @0-70F88092
//Target Framework version is 2.0
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace IssueManager.Caching
{
	public class CacheManager : ICacheManager
	{
		public CacheManager()
		{
		}

		public string GetCacheKey(string page, ArrayList parameters)
		{
			StringBuilder result = new StringBuilder();
			HttpContext context = HttpContext.Current;
			result.Append(GetPageKey(page));
			for (int i = 0; i < parameters.Count; i++)
			{
				CacheParameter parameter = (CacheParameter) parameters[i];
				if (parameter.Type == CacheParameterType.Bypass) continue;
				switch (parameter.Source)
				{
					case CacheParameterSource.Expression:
						result.Append("EXPR:");
						result.Append(parameter.Name);
						break;
					case CacheParameterSource.Get:

						if (context.Request.QueryString[parameter.Name] != null)
						{
							result.Append("GET:");
							result.Append(context.Request.QueryString[parameter.Name]);
						}
						break;
					case CacheParameterSource.Post:
						if (context.Request.Form[parameter.Name] != null)
						{
							result.Append("POST:");
							result.Append(context.Request.QueryString[parameter.Name]);
						}
						break;
					case CacheParameterSource.Session:
						if (context.Session[parameter.Name] != null)
						{
							result.Append("SESS:");
							result.Append(context.Request.QueryString[parameter.Name]);
						}
						break;

				}
				result.Append(';');
			}
			return result.ToString().TrimEnd(';') ;
		}

		public string GetPageKey(string page)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] source = encoding.GetBytes(page);
			byte[] hash = md5.ComputeHash(source);
			string result = encoding.GetString(hash);

			return result;
		}

		public void PutObject(string key, object item, TimeSpan duration)
		{
			HttpContext context = HttpContext.Current;
			context.Cache.Add(key, item, null, DateTime.Now + duration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
		}

		public object GetObject(string key)
		{
			HttpContext context = HttpContext.Current;
			return context.Cache.Get(key);
		}

		public void RemoveObject(string key)
		{
			HttpContext context = HttpContext.Current;
			context.Cache.Remove(key);
		}

		public void ClearStartedWith(string pageKey)
		{
			HttpContext context = HttpContext.Current;
			foreach (DictionaryEntry entry in context.Cache)
			{
				if (entry.Key.ToString().StartsWith(pageKey))
					context.Cache.Remove(entry.Key.ToString());
			}
		}

		public void ClearExpired()
		{
		}

		#region IDisposable Members

		public void Dispose()
		{
		}

		#endregion
	}
}

//End CacheManager class

