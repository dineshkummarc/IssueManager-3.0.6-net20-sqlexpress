//Client @1-6D37CFA9
//Target Framework version is 2.0
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace IssueManager
{
	public partial class __client : System.Web.UI.Page
	{
		protected NameValueCollection allowedFiles = new NameValueCollection();
		protected System.Resources.ResourceManager rm;
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["file"]==null || allowedFiles[Request.QueryString["file"]] == null) Response.End();
			StreamReader sr = new StreamReader(MapPath(Request.QueryString["file"]));
			string rawBody = sr.ReadToEnd();
			sr.Close();
			StringBuilder body = new StringBuilder(rawBody);
			Regex res = new Regex("{res:([^}]*)}",RegexOptions.Multiline);
			MatchCollection positions = res.Matches(rawBody);
			foreach(Match m in positions)
					body.Replace(m.Value, rm.GetString(m.Groups[1].Value));
			
			Response.ContentType = allowedFiles[Request.QueryString["file"]];
			Response.Write(body.ToString());
			Response.End();
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
			rm = (System.Resources.ResourceManager)Application["rm"];
			Utility.SetThreadCulture();
			Response.ContentEncoding = System.Text.Encoding.UTF8;
			allowedFiles.Add("DatePicker.js","application/x-javascript");
			allowedFiles.Add("Functions.js","application/x-javascript");
		}
		
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
//End Client

