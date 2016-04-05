//ReportLabel Control @0-1AC04A75
//Target Framework version is 2.0
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using IssueManager.Data;


namespace IssueManager.Controls
{
public enum ReportLabelSourceType {DBColumn, CodeExpression, SpecialValue}
	public enum ContentType {Text, HTML}
	public enum TotalFunction {None, Sum, Count, Min, Max, Avg}

	[DefaultProperty("Text")]
	public class ReportLabel : System.Web.UI.WebControls.Literal
	{
		private FieldType _type;
		private ReportLabelSourceType _sourceType;
		private string _source="";
		private string _emptyText;
		private ContentType _contentType = ContentType.Text;
		private bool _hideDuplicates;
		private TotalFunction _function = TotalFunction.None;
		private string _percentOf="";
		private string _format="";
		private string _resetAt="Report";

		#region Public properties
		public ReportLabelSourceType SourceType
		{
			get
			{
				return _sourceType;
			}
			set
			{
				_sourceType = value;
			}
		}
		public FieldType DataType
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}
		public string Format
		{
			get
			{
				return _format;
			}
			set
			{
				_format = value;
			}
		}

		
		public string Source
		{
			get
			{
				return _source;
			}
			set
			{
				_source = value;
			}
		}
		public string EmptyText
		{
			get
			{
				return _emptyText;
			}
			set
			{
				_emptyText = value;
			}
		}
		public ContentType ContentType
		{
			get
			{
				return _contentType;
			}
			set
			{
				_contentType = value;
			}
		}
		public bool HideDuplicates
		{
			get
			{
				return _hideDuplicates;
			}
			set
			{
				_hideDuplicates = value;
			}
		}
		public TotalFunction Function
		{
			get
			{
				return _function;
			}
			set
			{
				_function = value;
			}
		}
		public string PercentOf
		{
			get
			{
				return _percentOf;
			}
			set
			{
				_percentOf = value;
			}
		}
		public string ResetAt
		{
			get
			{
				return _resetAt;
			}
			set
			{
				_resetAt = value;
			}
		}
		#endregion
		
		protected override void Render(HtmlTextWriter writer)
        {
            string oldValue = Text;
			if(Text == null || Text == "")
				Text = EmptyText;
			if(ContentType.Text == this.ContentType)
				Text = Page.Server.HtmlEncode(Text);
			base.Render(writer);
            Text = oldValue;
        }

		protected override object SaveViewState()
		{
			ViewState.SetItemDirty("Text",true);
			return base.SaveViewState ();
		}
	}
	
	
}
//End ReportLabel Control

