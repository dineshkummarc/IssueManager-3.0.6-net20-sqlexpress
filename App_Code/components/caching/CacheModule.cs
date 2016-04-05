//CacheModule class @0-FE0CBB3E
//Target Framework version is 2.0
using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace IssueManager.Caching
{

	public class CacheModule : IHttpModule
	{
		public CacheModule()
		{
		}

		public void Init(HttpApplication context)
		{
			context.PreRequestHandlerExecute += new EventHandler(OnEntry);
			context.UpdateRequestCache += new EventHandler(OnLeave);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		private void OnEntry(object sender, EventArgs e)
		{
			HttpApplication context = (HttpApplication) sender;
			CacheManager cm = (CacheManager) context.Application["cache"];
			IHttpHandler h = HttpContext.Current.Handler;
			if (!(h is Page)) return;
			FieldInfo fi = h.GetType().GetField("cacheSettings");
			if (fi == null) return;
			object val = h.GetType().InvokeMember("cacheSettings",
			                                      BindingFlags.Public |
			                                      	BindingFlags.Instance |
			                                      	BindingFlags.GetField, null, h, null);
			if (val == null || !(val is CacheSettings)) return;
			CacheSettings settings = (CacheSettings) val;

			for (int i = 0; i < settings.Parameters.Count; i++)
			{
				CacheParameter parameter = (CacheParameter) settings.Parameters[i];
				if (parameter.Type == CacheParameterType.Key) continue;
				switch (parameter.Source)
				{
					case CacheParameterSource.Expression:
						if (parameter.Name != null && parameter.Name != "")	settings.BypassPage = true;
						break;
					case CacheParameterSource.Get:
						if (context.Request.QueryString[parameter.Name] != null) settings.BypassPage = true;
						break;
					case CacheParameterSource.Post:
						if (context.Request.Form[parameter.Name] != null) settings.BypassPage = true;
						break;
					case CacheParameterSource.Session:
						if (context.Session[parameter.Name] != null) settings.BypassPage = true;
						break;
				}
			}
			object body = cm.GetObject(cm.GetCacheKey(context.Context.Request.Path, settings.Parameters));
			HttpValidationStatus currentStatus;
			if(settings.BypassPage) 
				currentStatus = HttpValidationStatus.IgnoreThisRequest;
			else if(body==null)
				currentStatus = HttpValidationStatus.Invalid;
			else
				currentStatus = HttpValidationStatus.Valid;
				
			if (settings.validateCallBack!=null)
			{
				settings.validateCallBack(HttpContext.Current, settings.userData, ref currentStatus);
				switch (currentStatus)
				{
					case HttpValidationStatus.IgnoreThisRequest:
						settings.BypassPage = true;
						return;
					case HttpValidationStatus.Invalid:
						cm.RemoveObject(cm.GetCacheKey(context.Context.Request.Path, settings.Parameters));
						return;
				}
			}
			
			if (body != null)
			{
				MemoryStream ms = (MemoryStream) body;
				ms.Position = 0;
				byte[] buffer = new byte[4096];
				int i = ms.Read(buffer, 0, 4096);
				while (i > 0)
				{
					context.Context.Response.OutputStream.Write(buffer, 0, i);
					i = ms.Read(buffer, 0, 4096);
				}


				context.CompleteRequest();
			}
		}

		private void OnLeave(object sender, EventArgs e)
		{
			HttpApplication context = (HttpApplication) sender;
			CacheManager cm = (CacheManager) context.Application["cache"];
			IHttpHandler h = HttpContext.Current.Handler;
			if (!(h is Page)) return;
			FieldInfo fi = h.GetType().GetField("cacheSettings");
			if (fi == null) return;
			object val = h.GetType().InvokeMember("cacheSettings",
			                                      BindingFlags.Public |
			                                      	BindingFlags.Instance |
			                                      	BindingFlags.GetField, null, h, null);
			if (val == null || !(val is CacheSettings)) return;
			CacheSettings settings = (CacheSettings) val;
			string key = cm.GetCacheKey(context.Request.Path, settings.Parameters);
			if (settings.BypassPage) return;
			fi = h.GetType().GetField("pageFilter");
			if (fi == null) return;
			val = h.GetType().InvokeMember("pageFilter",
			                               BindingFlags.Public |
			                               	BindingFlags.Instance |
			                               	BindingFlags.GetField, null, h, null);
			if (val == null || !(val is ResponseFilter)) return;
			ResponseFilter pageFilter = (ResponseFilter) val;

			
			cm.PutObject(key, pageFilter.Body, settings.Duration);

		}
	}
}

//End CacheModule class

