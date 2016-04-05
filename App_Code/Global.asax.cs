//Global @1-454E638B
namespace IssueManager
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Web;
    using System.Web.SessionState;
	using System.Resources;
	using System.Globalization;
	using System.Collections.Specialized;


    /// <summary>
    ///    Summary description for Global.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(Object sender, EventArgs e)
        {
			  ResourceManager rm = new CCSResourceManager("resources.strings", System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("app_GlobalResources")));
			

			  Application["rm"] = rm;
			  Application["_locales"] = System.Configuration.ConfigurationManager.GetSection("locales");
			  HttpContext.Current.Cache.Insert("__InvalidateAllPages", DateTime.Now, null,
												System.DateTime.MaxValue, System.TimeSpan.Zero,
												System.Web.Caching.CacheItemPriority.NotRemovable,
												null);
        }
 
        protected void Session_Start(Object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

		  if( Application[Request.PhysicalPath] != null )
            Request.ContentEncoding =  System.Text.Encoding.GetEncoding(Application[Request.PhysicalPath].ToString());
         
        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {

        }

        protected void Application_End(Object sender, EventArgs e)
        {

        }
    }
}
//End Global

