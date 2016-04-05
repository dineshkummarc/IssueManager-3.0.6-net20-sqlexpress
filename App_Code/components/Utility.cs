//Using statements @1-6FB1A43B
//Target Framework version is 2.0
namespace IssueManager
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Web;
    using System.IO;
	using System.Text;
	using System.Web.SessionState;
	using System.Resources;
	using System.Globalization;
	using System.Collections.Specialized;

//End Using statements

//ResponseFilter class @2b-810E296A
	public delegate bool OnFilterCloseHandler (string htmlContent, Stream responseStream);
	public class ResponseFilter : Stream 
	{
 
		#region properties
 
		Stream responseStream;
		long position;
		StringBuilder html = new StringBuilder();
		public event OnFilterCloseHandler OnFilterClose;
 
		#endregion
 
		#region constructor

		public ResponseFilter(Stream inputStream) 
		{
 			responseStream = inputStream;
 		}
 
		#endregion

		#region implemented abstract members
 
		public override bool CanRead 
		{
			get { return true; }
		}

		public override bool CanSeek 
		{
			get { return true; }
		}

		public override bool CanWrite 
		{
			get { return true; }
		}

		public override void Close() 
		{
			byte[] data;

			if(OnFilterClose != null)
			{
				string temp = html.ToString();
				if(!OnFilterClose(temp, responseStream)) return;
				data = System.Text.UTF8Encoding.UTF8.GetBytes(temp);
				
			}
			else
			{
				data = System.Text.UTF8Encoding.UTF8.GetBytes(html.ToString());
			}
			responseStream.Write(data, 0, data.Length);			
			responseStream.Close();
		}

		public override void Flush() 
		{
			responseStream.Flush();
		}
 
		public override long Length 
		{
			get { return 0; }
		}

		public override long Position 
		{
			get { return position; }
			set { position = value; }
		}

		public override long Seek(long offset, System.IO.SeekOrigin direction) 
		{
			return responseStream.Seek(offset, direction);
		}

		public override void SetLength(long length) 
		{
			responseStream.SetLength(length);
		}

		public override int Read(byte[] buffer, int offset, int count) 
		{
			return responseStream.Read(buffer, offset, count);
		}
 
		#endregion

		#region write method
 
		public override void Write(byte[] buffer, int offset, int count) 
		{
			html.Append(System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count));
		}
  
		#endregion
  
	}

//End ResponseFilter class

//CCSResourceManager class @1-12C3AB9C
		public class CCSResourceManager:ResourceManager
		{

			public CCSResourceManager(string baseName, System.Reflection.Assembly assembly):base(baseName,assembly)
			{}

			public override string GetString(string name)
			{
				string val = null;
				val = base.GetString(name);
				if(val == null) val = name;
				return val;
			}
			public override string GetString(string name, CultureInfo culture)
			{
				string val = null;
				val = base.GetString(name, culture);
				if(val == null) val = name;
				return val;
			}

		}

//End CCSResourceManager class

    public class Utility{ //Utility class @1-F3513C2E

//SetThreadCulture method @1-5C8C0BDD
        public static void SetThreadCulture()
        {
		  bool isCultureSelected = false;
		  HttpContext current = HttpContext.Current;
		  Hashtable locales = (Hashtable)current.Application["_locales"];
		  if( current.Application[current.Request.PhysicalPath] != null )
            current.Request.ContentEncoding = System.Text.Encoding.GetEncoding(current.Application[current.Request.PhysicalPath].ToString());
          string culture = "";
		  
		  if(current.Request.QueryString["locale"]!=null)
		    culture = current.Request.QueryString["locale"];
		  
		  if(culture=="" && current.Request.Cookies["locale"]!=null)
			culture = current.Request.Cookies["locale"].Value;
		  
		  if(culture=="" && current.Session["locale"]!=null)
		    culture = current.Session["locale"].ToString();
		  else if(culture=="" && current.Session["lang"]!=null)
		    culture = current.Session["lang"].ToString();
		  
		  if(culture=="" && current.Request.UserLanguages != null)
		  {
			foreach(string cult in current.Request.UserLanguages)
			{
				string name= cult.Split(new char[]{';'})[0];
				if(locales.ContainsKey(name) && name.IndexOf("-")>0)
				{
				  culture = name;
				  isCultureSelected = true;
				  break;
				}
				if(!locales.ContainsKey(name) && name.IndexOf("-")>0)
				  name = name.Split(new char[]{'-'})[0];

				if(locales.ContainsKey(name) && name.IndexOf("-")<0)
				{
				  culture = name;
				  isCultureSelected = true;
				  break;
				}
			}
		  }
		  

		  if(!isCultureSelected)
		  {
			if(locales.ContainsKey(culture) && culture.IndexOf("-")>0)
				isCultureSelected = true;

			if(!locales.ContainsKey(culture) && culture.IndexOf("-")>0)
				culture = culture.Split(new char[]{'-'})[0];

			if(locales.ContainsKey(culture) && culture.IndexOf("-")<0)
				isCultureSelected = true;
		  }

		  if(!isCultureSelected) 
		  
			 culture = Configuration.Settings.SiteLanguage;

	      System.Threading.Thread.CurrentThread.CurrentCulture = (CultureInfo)locales[culture];
		  System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
  		  
			HttpCookie cookie = new HttpCookie("locale",culture);
			
			cookie.Expires = DateTime.Now.AddDays(365);
			
			current.Response.Cookies.Add(cookie);
		  
		    current.Session["locale"] = culture;
		    current.Session["lang"]= System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
		    Configuration.Settings.BoolFormat = ((CCSCultureInfo)locales[culture]).BooleanFormat;
		  
        }

//End SetThreadCulture method

//GetPageStyle method @1-F8F70EAE
        public static string GetPageStyle()
        {
		  HttpContext current = HttpContext.Current;
          string style = "";
		  
		  if(current.Request.QueryString["style"]!=null)
		    style = current.Request.QueryString["style"];
		  
		  if(style=="" && current.Request.Cookies["style"]!=null)
			style = current.Request.Cookies["style"].Value;
		  
		  if(style=="" && current.Session["style"]!=null)
		    style = current.Session["style"].ToString();
		  
			HttpCookie cookie = new HttpCookie("style",style);
			
			cookie.Expires = DateTime.Now.AddDays(365);
			
			current.Response.Cookies.Add(cookie);
		  
		    current.Session["style"]= style;
		  
		  style = style.Trim();
		  if(style!="") 
		  {
			string root = HttpContext.Current.Server.MapPath("~/Styles/" + style + "/Style.css");
			if(!System.IO.File.Exists(root))
				style = "";
		  }
		  
//End GetPageStyle method

//GetPageStyle method tail @1-5EFBC847
		  if(style == null || style == "")
			  style = "GreenApple"; 
		  
		  return style;
        }
//End GetPageStyle method tail

//End Utility class @1-FCB6E20C
	}
//End End Utility class

	public class IMUtils
	{
		private static Hashtable cache = new Hashtable();

		public static string GetSetting(string var)
		{
			string val;
			if (cache[var] != null)
				val = (string)cache[var];
			else
			{
				val = Lookup(var,"settings","settings_id=1"); 
				cache[var] = val;
			}
			return val;
		}

		public static void FlushSettings()
		{
			cache.Clear();
		}

		public static string Lookup(string field, string table, string where)
		{
			string sql = "SELECT "+field+" FROM "+table+" WHERE "+where;
			object result = IssueManager.Configuration.Settings.IMDataAccessObject.ExecuteScalar(sql);
			return result==null?null:result.ToString();
		}

		public static void SendNotification(string message, int user_id, int issue_id)
		{
			string curUserName = IMUtils.Lookup("user_name","users","user_id="+HttpContext.Current.Session["UserID"]);
			string receiver = IMUtils.Lookup("user_name","users","user_id="+user_id);
			string issue_name = IMUtils.Lookup("issue_name","issues","issue_id="+issue_id);
			string issue_desc = IMUtils.Lookup("issue_desc","issues","issue_id="+issue_id);

			System.Text.StringBuilder mailBody = new System.Text.StringBuilder(GetSetting(message+"_body"));
			mailBody.Replace("\r\n","<br>");
			mailBody.Replace("{issue_no}",issue_id.ToString());
			mailBody.Replace("{issue_title}",issue_name);
			mailBody.Replace("{issue_desc}",issue_desc);
			mailBody.Replace("{issue_url}","<a href='http://"+HttpContext.Current.Request.Url.Host+HttpContext.Current.Request.ApplicationPath+"/IssueChange.aspx?issue_id="+issue_id+"'>here</a>");
			mailBody.Replace("{issue_poster}",curUserName);
			mailBody.Replace("{issue_receiver}",receiver);

			System.Text.StringBuilder mailSubject = new System.Text.StringBuilder(GetSetting(message+"_subject"));
			mailSubject.Replace("{issue_no}",issue_id.ToString());
			mailSubject.Replace("{issue_title}",issue_name);
			mailSubject.Replace("{issue_poster}",curUserName);
			mailSubject.Replace("{issue_receiver}",receiver);

			SendEmail(GetSetting(message+"_from"), Lookup("email","users","user_id="+user_id), mailSubject.ToString(), mailBody.ToString());
		}

		public static void SendEmail(string from, string to, string subject, string body)
		{
			switch (GetSetting("email_component"))
			{
				case "0":
					break;
				case "1":
					HttpContext.Current.Response.Buffer = false;
					HttpContext.Current.Response.Write("<b>FROM:</b> "+from+"<br>");
					HttpContext.Current.Response.Write("<b>TO:</b> "+to+"<br>");
					HttpContext.Current.Response.Write("<b>SUBJECT:</b> "+subject+"<br>");
					HttpContext.Current.Response.Write(body+"<hr>");
					break;
				case "9":
					try
					{
						System.Web.Mail.MailMessage newMsg = new System.Web.Mail.MailMessage();
						newMsg.BodyFormat=System.Web.Mail.MailFormat.Html;
						newMsg.From = from;
						newMsg.To = to;
						newMsg.Subject = subject;
						newMsg.Body = body;
						string server = GetSetting("smtp_host");
						if (server == null || server.Length == 0)
							server = "127.0.0.1";
						System.Web.Mail.SmtpMail.SmtpServer = server;
						System.Web.Mail.SmtpMail.Send(newMsg);
					}
					catch (Exception e)
					{
						HttpContext.Current.Response.Write("<b><p><font color=red>Your local IIS SMTP Server is misconfigured.</font></p>");
						HttpContext.Current.Response.Write("<p><a href=\"AppSettings.aspx\">Turn mailing off</a> or refer to <a href=\"http://support.microsoft.com/search/default.aspx?qu=configure+iis+smtp\">Microsoft Support</a> for help configuring it.</p>");
						HttpContext.Current.Response.Write("Exception: </b>");
						DumpException(e);
						HttpContext.Current.Response.End();
					}
					break;
				case "10":
					try
					{
						System.Net.Mail.MailMessage newMsg = new System.Net.Mail.MailMessage();
						newMsg.IsBodyHtml = true;
						newMsg.From = new System.Net.Mail.MailAddress(from);
						newMsg.To.Add(to);
						newMsg.Subject = subject;
						newMsg.Body = body;
						string server = GetSetting("smtp_host");
						if (server == null || server.Length == 0)
							server = "127.0.0.1";
						System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(server);
						smtp.Send(newMsg);
					}
					catch (Exception e)
					{
						HttpContext.Current.Response.Write("<b><p><font color=red>Your mailer is misconfigured.</font></p>");
						HttpContext.Current.Response.Write("<p><a href=\"AppSettings.aspx\">Turn mailing off</a> or refer to <a href=\"http://support.microsoft.com/search/default.aspx?qu=configure+iis+smtp\">Microsoft Support</a> for help configuring it.</p>");
						HttpContext.Current.Response.Write("Exception: </b>");
						DumpException(e);
						HttpContext.Current.Response.End();
					}
					break;
			}
		}

		public static void DumpException(Exception e)
		{
			while (e != null)
			{
				HttpContext.Current.Response.Write("<li>"+e.Message);
				e = e.InnerException;
			}
		}

		public static void SetupUpload(IssueManager.Controls.FileUploadControl control)
		{
			control.AllowedFileMasks = IMUtils.GetSetting("file_extensions");
			control.FileFolder = HttpContext.Current.Server.MapPath(IMUtils.GetSetting("file_path"));
		}

		public static System.Web.UI.Control LookupControl(System.Web.UI.Control parent, string name)
		{
			System.Web.UI.Control ctrl = null;
			ctrl = parent.FindControl(name);
			if (ctrl == null)
			{
				foreach (System.Web.UI.Control child in parent.Controls)
				{
					ctrl = LookupControl(child, name);
					if (ctrl != null)
						break;
				}
			}
			return ctrl;
		}

		public static string Translate(string str)
		{
			if (str.StartsWith("res:"))
			{
				ResourceManager rm = (System.Resources.ResourceManager)System.Web.HttpContext.Current.Application["rm"];
				return rm.GetString(str.Substring(4));
			}
			else
				return str;
		}

		public static void TranslateFields(System.Web.UI.Control parent, string prefix)
		{
			string[] fields = new string[] {"tested", "approved", "tested1", "approved1", "status_id","status_id1","priority_id","priority_id1"};
			foreach (string field in fields)
				try
				{
					System.Web.UI.WebControls.Literal val = LookupControl(parent,prefix+field) as System.Web.UI.WebControls.Literal;
					if (val != null)
						val.Text = Translate(val.Text);
				}
				catch (Exception e) {}
		}

		public static void TranslateListbox(System.Web.UI.HtmlControls.HtmlSelect listbox)
		{
			foreach(System.Web.UI.WebControls.ListItem item in listbox.Items)
				item.Text = Translate(item.Text);
		}

		public static string GetGeneralDateFormat()
		{
			return DateTimeFormatInfo.CurrentInfo.ShortDatePattern+" "+DateTimeFormatInfo.CurrentInfo.LongTimePattern;
		}
	}
} //End namespace @1-FCB6E20C

