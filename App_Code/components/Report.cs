//Report Control @0-26BD1508
//Target Framework version is 2.0
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using IssueManager.Data;
using IssueManager.Configuration;


namespace IssueManager.Controls
{
[ParseChildren(true)]
	public class ReportSection : Control,INamingContainer
	{
		private int itemIndex;
		private string _name="";
		private float _height=1;
		private ITemplate _template;
		
		public ReportSection(int itemIndex) 
		{
			this.itemIndex = itemIndex;
		}
		public ReportSection() 
		{
			this.itemIndex = 0;
		}

		[PersistenceMode(PersistenceMode.Attribute)]
		public string name
		{
			get 
			{
				return _name;
			}
			set 
			{
				_name = value;
			}
		}
		[PersistenceMode(PersistenceMode.Attribute)]
		public float Height
		{
			get 
			{
				return _height;
			}
			set 
			{
				_height = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(ReportSectionBody))
		]
		public ITemplate Template
		{
			get 
			{
				return _template;
			}
			set 
			{
				_template = value;
			}
		}

	}

	
	public class ReportSectionBody : Control, INamingContainer
	{
		private string _name="";
		private float _height=1;
		private IDataItem _dataItem;
		
		public string name
		{
			get 
			{
				return _name;
			}
			set 
			{
				_name = value;
			}
		}
		public float Height
		{
			get 
			{
				return _height;
			}
			set 
			{
				_height = value;
			}
		}
		public IDataItem DataItem
		{
			get 
			{
				return _dataItem;
			}
			set 
			{
				_dataItem = value;
			}
		}
	}
	
	public class BeforeItemDataBoundEventArgs : EventArgs
	{
		public IDataItem DataItem;
		public BeforeItemDataBoundEventArgs (IDataItem data)
		{
			this.DataItem = data;
		}
	}

	public class BeforeShowSectionEventArgs : EventArgs
	{
		public ReportSectionBody Item;
		public BeforeShowSectionEventArgs (ReportSectionBody item)
		{
			this.Item = item;
		}
	}

	public class OnCalculateEventArgs : EventArgs
	{
		public IDataItem DataItem;
		public string SectionName;
		public ReportSectionBody Item;
		public Hashtable TotalValues;

		public OnCalculateEventArgs (IDataItem data, string sectionName, ReportSectionBody item, Hashtable totalValues)
		{
			this.DataItem = data;
			this.SectionName = sectionName;
			this.Item = item;
			this.TotalValues = totalValues;
		}
	}

	public delegate void BeforeItemDataBoundHandler(object sender, BeforeItemDataBoundEventArgs e);
	public delegate void OnCalculateHandler(object sender, OnCalculateEventArgs e);
	public delegate void BeforeShowSectionHandler(object sender, BeforeShowSectionEventArgs e);

	public enum ReportViewMode {Print, Web}

	[PersistChildren(true)]
	public class Report:WebControl,INamingContainer
	{
		private IDataItem[] _dataSource;
		private ITemplate _layoutheader;
		private ITemplate _layoutfooter;
		private NameValueCollection _groups = new NameValueCollection();
		private NameValueCollection _values = new NameValueCollection();
		private ArrayList sections = new ArrayList();
		private ArrayList navigators = new ArrayList();
		private ArrayList specialValues = new ArrayList();
		private ArrayList controls = new ArrayList();
		private Hashtable groupsData = new Hashtable();
		private bool isPageCreated = false;

		private ReportViewMode _viewMode = ReportViewMode.Web;
		private float _pageSize = 0, _webPageSize = 0, _pageSizeLimit=0;
		private float currPageSize = 0;
		private uint _currentPageNumber = 0;
		private uint _totalPages = 0;
		private uint _rowNumber = 0;
		
		public class TotalValue
		{
			private float firstS;
			public int second;
			private double firstD;
			private bool isInitialized = false;
			public bool isDouble;
			public string source="";
			public ReportLabelSourceType sourceType=ReportLabelSourceType.DBColumn;
			public TotalFunction function = TotalFunction.None;
			public string resetAt="Report";
			public string percentOf="";
			public bool percentOfService=false;
			
			public TotalValue(TotalFunction func, bool isDouble)
			{
				function = func;
				Reset();
				this.isDouble = isDouble;
			}

			public object Value
			{
				get 
				{
					if(isDouble)
						return firstD;
					else
						return firstS;
				}
				set 
				{
					if(isDouble)
						firstD = Convert.ToDouble(value);
					else
						firstS = Convert.ToSingle(value);
				}
			}
			public object Average()
			{
				if(isDouble)
						return firstD / second;
					else
						return firstS / second;
			}

			public void AddFirst(object val)
			{
				if(isDouble)
				{
					if(val!=null && !isInitialized)
					{
						isInitialized = true;
						firstD = 0;
					}
					firstD += Convert.ToDouble(val);
				}
				else
				{
					if(val!=null && !isInitialized)
					{
						isInitialized = true;
						firstS = 0;
					}
					firstS += Convert.ToSingle(val);
				}
			}

			public void SetMin(object val)
			{
				if(isDouble)
					firstD = Convert.ToDouble(val)<firstD||double.IsNaN(firstD)?Convert.ToDouble(val):firstD;
				else
					firstS = Convert.ToSingle(val)<firstS||float.IsNaN(firstS)?Convert.ToSingle(val):firstS;
			}


			public void SetMax(object val)
			{
				if(isDouble)
					firstD = Convert.ToDouble(val)>firstD||double.IsNaN(firstD)?Convert.ToDouble(val):firstD;
				else
					firstS = Convert.ToSingle(val)>firstS||float.IsNaN(firstS)?Convert.ToSingle(val):firstS;
			}

			public object GetPercent(object val)
			{
				if(isDouble)
				{
					if(val == null || firstD == 0) return Double.NaN;
					return Convert.ToDouble(val)/firstD * (function == TotalFunction.Avg?second:1);
				}
				else
				{
					if(val == null || firstS == 0) return Single.NaN;
					return Convert.ToSingle(val)/firstS * (function == TotalFunction.Avg?second:1);
				}
			}

			public void Reset()
			{
				isInitialized = false;
				if(function == TotalFunction.Min || function == TotalFunction.Max || function == TotalFunction.Sum)
				{
					this.firstS=float.NaN;
					this.firstD=double.NaN;
					this.second=0;
				}
				else
				{
					this.firstS=0;
					this.firstD=0;
					this.second=0;
				}
			}
		}

		public event BeforeItemDataBoundHandler BeforeItemDataBound;
		public event OnCalculateHandler OnCalculate;
		public event RepeaterCommandEventHandler ItemCommand;
		public event BeforeShowSectionHandler BeforeShowSection;

		private Hashtable calculationTable = new Hashtable();
		private Hashtable percentValues = new Hashtable();
		private Hashtable headersLinks = new Hashtable();
		private Hashtable templates = new Hashtable();
		private float minPageSize = 0;
		private float maxSectionSize = 0;

		#region Properties
		
		public virtual uint PageNumber 
		{
			get 
			{
				return _currentPageNumber;
			}
		}

		public virtual uint PreviewPageNumber 
		{
			get 
			{
				if(ViewState["_pageNumber"]!=null)
					return (uint)ViewState["_pageNumber"];
				else
					return 1;
			}
			set 
			{
				ViewState["_pageNumber"] = value;
			}
		}

		public virtual uint TotalPages 
		{
			get 
			{
				return _totalPages;
			}
		}

		public virtual uint RowNumber 
		{
			get 
			{
				return _rowNumber;
			}
		}

		public virtual float PageSize 
		{
			get 
			{
				return _pageSize;
			}
			set 
			{
				_pageSize = value;
			}
		}

		public virtual float WebPageSize 
		{
			get 
			{
				return _webPageSize;
			}
			set 
			{
				_webPageSize = value;
			}
		}

		public virtual float PageSizeLimit 
		{
			get 
			{
				return _pageSizeLimit;
			}
			set 
			{
				_pageSizeLimit = value;
			}
		}

		public virtual ReportViewMode ViewMode 
		{
			get 
			{
				return _viewMode;
			}
			set 
			{
				_viewMode = value;
			}
		}

		private float ActivePageSize
		{
			get
			{
				if(ViewMode == ReportViewMode.Print)
					return PageSize;
				else
					return WebPageSize;
			}
		}

		
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		]
		public virtual ReportSection Section 
		{
			get 
			{
				return null;
			}
			set 
			{
				ReportSection section = new ReportSection();
				value.Template.InstantiateIn(section);
				if(value.Visible &&(value.name == "Page_Header" || value.name == "Page_Footer"))
					minPageSize += value.Height;
				else if(value.Visible)
					if(value.Height > maxSectionSize) maxSectionSize = value.Height;
				PopulateCalculationTable(section.Controls, value.name);
				templates.Add(value.name, value);
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(ReportSectionBody))
		]
		public virtual ITemplate LayoutHeaderTemplate 
		{
			get 
			{
				return _layoutheader;
			}
			set 
			{
				_layoutheader = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(ReportSectionBody))
		]
		public virtual ITemplate LayoutFooterTemplate 
		{
			get 
			{
				return _layoutfooter;
			}
			set 
			{
				_layoutfooter = value;
			}
		}
		public virtual IDataItem[] DataSource 
		{
			get 
			{
				return _dataSource;
			}
			set 
			{
				_dataSource = value;
			}
		}

		public virtual NameValueCollection Groups 
		{
			get 
			{
				return _groups;
			}
			
		}
#endregion
		
		protected override bool OnBubbleEvent(object sender, EventArgs e)
		{
			bool handled = false;
			if(ItemCommand != null)
			{
				ItemCommand(this, new RepeaterCommandEventArgs(null, sender, (CommandEventArgs)e));
				handled = true;
			}
			return handled ;
		}

		protected void BindReportLabel(ReportLabel rl, object data)
		{
			switch(rl.DataType)
			{
				case FieldType.Float:
				case FieldType.Single:
				case FieldType.Integer:
					if(!double.IsNaN(Convert.ToDouble(data)))
						rl.Text = DBUtility.FormatNumber(data,rl.Format);
					break;
				case FieldType.Boolean:
					if(rl.Format == "") rl.Format = Settings.BoolFormat;
					rl.Text = DBUtility.FormatBool(data,rl.Format);
					break;
				case FieldType.Date:
					if(rl.Format == "") rl.Format = Settings.DateFormat;
					rl.Text = ((DateTime)data).ToString(rl.Format);
					break;
				default:
					rl.Text = data.ToString();
					break;
			}
		}

		protected void PopulateCalculationTable(ControlCollection col, string sectionName)
		{
			foreach(Control control in col)
			{
				if(control.Controls.Count > 0)
					PopulateCalculationTable(control.Controls, sectionName);
				if(control is ReportLabel)
				{
					ReportLabel rl = (ReportLabel)control;
					if(rl.Function!=TotalFunction.None)
					{
						TotalValue val = new TotalValue(rl.Function, rl.DataType == FieldType.Float);
						val.source = rl.Source;
						val.sourceType = rl.SourceType;
						val.resetAt = rl.ResetAt;
						val.percentOf = rl.PercentOf;
						calculationTable.Add(rl.ID, val);
					}
					if(rl.PercentOf != "")
					{
						TotalValue val = new TotalValue(rl.Function!=TotalFunction.None?rl.Function:TotalFunction.Sum, rl.DataType == FieldType.Float);
						val.source = rl.Source;
						val.sourceType = rl.SourceType;
						val.resetAt = rl.PercentOf;
						val.percentOf = rl.PercentOf;
						val.percentOfService = true;
						calculationTable.Add("__PercentOf" + rl.ID, val);
						percentValues.Add("__PercentOf"+rl.ID,new ArrayList());
					}

				}
			}
		}

		protected override void CreateChildControls()
		{
			base.CreateChildControls ();
			Controls.Clear();
			if(ViewState["sections"]!=null)
			{

				if(LayoutHeaderTemplate != null)
				{
					ReportSectionBody head = new ReportSectionBody();
					LayoutHeaderTemplate.InstantiateIn(head);
					Controls.Add(head);
				}

				sections = (ArrayList)ViewState["sections"];
				foreach(object name in sections)
				{
					ReportSectionBody item = new ReportSectionBody();
					((ReportSection)(templates[name.ToString()])).Template.InstantiateIn(item);
					item.name = name.ToString();
					Controls.Add(item);
				}
				if(LayoutFooterTemplate != null)
				{
					ReportSectionBody footer = new ReportSectionBody();
					LayoutFooterTemplate.InstantiateIn(footer);
					Controls.Add(footer);
				}
			}
		}

		protected void CalculateSpecialControls(IDataItem di, ControlCollection col, string sectionName, bool isHeader,bool isTotalOnly)
		{
			foreach(Control control in col)
			{
				if(!(control is ReportLabel)) continue;
				ReportLabel rl = (ReportLabel)control;
				if(rl.SourceType == ReportLabelSourceType.SpecialValue)
				{
					specialValues.Add(rl);
					switch(rl.Source)
					{
						case "RowNumber":
							BindReportLabel(rl, RowNumber);
							break;
						case "PageNumber":
							BindReportLabel(rl, PageNumber);
							break;
						case "CurrentDate":
							rl.DataType = FieldType.Text;
							BindReportLabel(rl, DateTime.Now.ToString("d"));
							break;
						case "CurrentDateTime":
							rl.DataType = FieldType.Text;
							BindReportLabel(rl, DateTime.Now.ToString("G"));
							break;
						case "CurrentTime":
							rl.DataType = FieldType.Text;
							BindReportLabel(rl, DateTime.Now.ToString("t"));
							break;
					}

				}
			}
		}
		
		protected void CalculateControls(IDataItem di, ControlCollection col, string sectionName, bool isHeader,bool isTotalOnly)
		{
			CalculateSpecialControls(di,col,sectionName,isHeader,isTotalOnly);
			foreach(Control control in col)
			{
				if(control.Controls.Count > 0)
					CalculateControls(di,control.Controls,sectionName,isHeader,isTotalOnly);

				if(control is Navigator) navigators.Add(control);

				if(control is ReportLabel)
				{
					ReportLabel rl = (ReportLabel)control;
					object currentValue = null;
					if(rl.Function!=TotalFunction.None)
					{
						if(rl.Function==TotalFunction.Avg)
							currentValue = ((TotalValue)(calculationTable[rl.ID])).Average();
						else
							currentValue = ((TotalValue)(calculationTable[rl.ID])).Value;
						if(rl.DataType != FieldType.Float || rl.DataType != FieldType.Single || rl.DataType != FieldType.Integer)
							rl.DataType = FieldType.Float;
						BindReportLabel(rl, currentValue);
						
					}
					else if(rl.SourceType != ReportLabelSourceType.SpecialValue && !isTotalOnly && rl.Source !="")
					{
						currentValue = di[rl.Source].Value;
						rl.Text=di[rl.Source].GetFormattedValue();
					}
					

					if(rl.PercentOf != "")
					{
						((ArrayList)percentValues["__PercentOf"+rl.ID]).Add(new Pair(rl,currentValue));
						
					}
					if(rl.HideDuplicates)
						if(_values[rl.ID]!=null)
						{
							rl.Visible = _values[rl.ID]!=rl.Text;
							_values[rl.ID] = rl.Text;
						}
						else
						{
							_values.Add(rl.ID,rl.Text);
						}
				}
			}
		}

		private ReportSectionBody InstantiateSection(string name, bool isHeader, IDataItem di)
		{
			return InstantiateSection(name, isHeader, di, false, false, true);
		}

		private ReportSectionBody InstantiateSection(string name, bool isHeader, IDataItem di, bool noRecordsFlag)
		{
			return InstantiateSection(name, isHeader, di, noRecordsFlag, false,true);
		}

		private ReportSectionBody InstantiateSection(string name, bool isHeader, IDataItem di, bool noRecordsFlag, bool lastSection, bool addToCollection)
		{
			ReportSectionBody item = null;
			string sName=name;
			float sectionHeight = 0, footerHeight = 0;
			if(name!="Detail")
				sName += isHeader?"_Header":"_Footer";
			if(templates.Contains(sName) && ((ReportSection)templates[sName]).Visible)
				sectionHeight = ((ReportSection)templates[sName]).Height;
			if(templates.Contains("Page_Footer") && ((ReportSection)templates["Page_Footer"]).Visible)
				footerHeight = ((ReportSection)templates["Page_Footer"]).Height;

			if(name == "Page" && isHeader)
			{
				groupsData["Page"] = di;
				_currentPageNumber ++;
				_totalPages ++;
			}
			if(ActivePageSize !=0 && currPageSize + footerHeight + sectionHeight > ActivePageSize && name!="Page" && addToCollection)
			{
				InstantiateSection("Page", false,  (IDataItem)groupsData["Page"]);
				if(ViewMode == ReportViewMode.Web &&
					PageNumber != PreviewPageNumber && !isPageCreated && (!lastSection || name == "Report"))
					controls.Clear();
				else if(ViewMode == ReportViewMode.Web &&
					PageNumber == PreviewPageNumber)
					isPageCreated = true;
				currPageSize = 0;
				InstantiateSection("Page", true, di);
			}
			if(addToCollection)
				currPageSize += sectionHeight;

			if(BeforeItemDataBound!=null)
				BeforeItemDataBound(this,new BeforeItemDataBoundEventArgs(di));
			if(name=="Detail")
			{
				_rowNumber++;
				foreach(DictionaryEntry v in calculationTable)
				{
					TotalValue val = (TotalValue)(v.Value);
					switch(val.function)
					{
						case TotalFunction.Avg:
							if(di[val.source].Value != null)
							{
								val.AddFirst(di[val.source].Value);
								val.second ++;
							}
							break;
						case TotalFunction.Sum:
							val.AddFirst(di[val.source].Value);
							break;
						case TotalFunction.Min:
							if(di[val.source].Value != null)
								val.SetMin(di[val.source].Value);
							break;
						case TotalFunction.Max:
							if(di[val.source].Value != null)
								val.SetMax(di[val.source].Value);
							break;
						case TotalFunction.Count:
							if(val.source=="")
								val.AddFirst(1);
							else
								val.AddFirst(di[val.source].Value == null?0:1);
							break;
					}
				}
			}

			if(templates.Contains(sName))
			{
				item = new ReportSectionBody();
				((ReportSection)(templates[sName])).Template.InstantiateIn(item);
				item.name = sName;
				item.Visible = ((ReportSection)(templates[sName])).Visible;
				item.Height = ((ReportSection)(templates[sName])).Height;
				item.DataItem = di;
				CalculateControls(di, item.Controls, name, isHeader, false);
				if(	controls.Count > 0 && 
					((ReportSectionBody)controls[controls.Count -1]).name == "Detail" && 
					((ReportSectionBody)controls[controls.Count -1]).FindControl(ID + "Separator") != null) ((ReportSectionBody)controls[controls.Count -1]).FindControl(ID + "Separator").Visible = sName == "Detail";
				if(item.FindControl(ID + "NoRecords") != null) item.FindControl(ID + "NoRecords").Visible = noRecordsFlag;
				if((lastSection || ViewMode == ReportViewMode.Web) && item.FindControl(ID + "PageBreak") != null) item.FindControl(ID + "PageBreak").Visible = false;
				if(OnCalculate != null)
					OnCalculate(this,new OnCalculateEventArgs(di,sName,item, calculationTable));
				if(ViewMode == ReportViewMode.Print || 
					ViewMode == ReportViewMode.Web &&
					PageNumber == PreviewPageNumber ||
					sName == "Report_Header" &&
					PreviewPageNumber == 1 ||
					sName == "Report_Footer" &&
					PreviewPageNumber == TotalPages
					)
				{
						item.DataBind();
				}
				if(addToCollection && !isPageCreated)
					controls.Add(item);

				if(isHeader) headersLinks.Add(name,item);
			}

			if(headersLinks.Contains(name) && !isHeader)
			{	
				CalculateControls(di, ((ReportSectionBody)headersLinks[name]).Controls, name, isHeader, true);
				headersLinks.Remove(name);
			}
			if(!isHeader)
				foreach(DictionaryEntry v in calculationTable)
				{
					TotalValue val = (TotalValue)(v.Value);
					if(val.percentOf == name && val.percentOfService)
					{
						foreach(Pair p in ((ArrayList)percentValues[v.Key]))
							BindReportLabel((ReportLabel)p.First, val.GetPercent(p.Second));
						((ArrayList)percentValues[v.Key]).Clear();
						if(!(name=="Page" && lastSection))
							val.Reset();
					}
					if(val.resetAt == name && name!="Report" && !(name=="Page" && lastSection))
						val.Reset();
				}
			return item;
		}

		private void OpenGroup(string name,IDataItem di)
		{
			bool flag = false;
			foreach(string key in Groups.Keys)
				if(key == name || flag)
				{
					groupsData[key] = di;
					InstantiateSection(key,true,di);
					flag = true;
				}
		}

		private void CloseGroup(string name,IDataItem di)
		{
			for(int i = Groups.Count-1;i>=0;i--)
			{	
				InstantiateSection(Groups.Keys[i],false,(IDataItem)groupsData[Groups.Keys[i]]);
				if(Groups.Keys[i] == name) break;
			}
		}
		
		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			minPageSize += maxSectionSize;
			if(Page.Request["ViewMode"]!=null)
					ViewMode = (ReportViewMode)Enum.Parse(typeof(ReportViewMode), Page.Request["ViewMode"], true);
			
			if(Page.Request[ID + "Page"]!=null)
				try
				{
					PreviewPageNumber = Convert.ToUInt16(Page.Request[ID + "Page"]);
					if (PreviewPageNumber <= 0) PreviewPageNumber = 1;
				}
				catch
				{}

			if(Page.Request[ID + "PageSize"]!=null)
			try
			{
				float tempval = Convert.ToSingle(Page.Request[ID + "PageSize"]);
				if(tempval < 0) return;
				if(tempval < minPageSize && tempval != 0) tempval = minPageSize;
				if(ViewMode == ReportViewMode.Print)
					PageSize = tempval;
				else
				{
					WebPageSize = tempval;
					if(PageSizeLimit > 0 && WebPageSize > PageSizeLimit || WebPageSize == 0)
						WebPageSize = PageSizeLimit;

				}
			}
			catch
			{}
		}

		
		public override void DataBind() 
		{
			ClearChildViewState();
			Controls.Clear();
			sections.Clear();
			if(LayoutHeaderTemplate != null)
			{
				ReportSectionBody head = new ReportSectionBody();
				LayoutHeaderTemplate.InstantiateIn(head);
				Controls.Add(head);
				head.DataBind();
			}
			IDataItem di = null;
			if(DataSource.Length>0) di = DataSource[0];
			groupsData.Add("Report",di);
			groupsData.Add("Page",null);
			for(int i = Groups.Count-1;i>=0;i--)
				groupsData.Add(Groups.Keys[i],null);
			InstantiateSection("Report", true ,di);
			InstantiateSection("Page", true ,di);

			for(int k= 0;k<DataSource.Length;k++)
			{
				for(int i=0;i < Groups.Count;i++)
					if(k>0 && !DataSource[k][Groups[i]].Equals(DataSource[k-1][Groups[i]]))
					{
						CloseGroup(Groups.Keys[i],DataSource[k]);
						break;
					}
				
				for(int i=0;i < Groups.Count;i++)
					if(k==0 || !DataSource[k][Groups[i]].Equals(DataSource[k-1][Groups[i]]))
					{
						OpenGroup(Groups.Keys[i],DataSource[k]);
						break;
					}
				InstantiateSection("Detail", false, DataSource[k], false);
			}
			if(DataSource.Length>0) di = DataSource[DataSource.GetUpperBound(0)];
			if(Groups.Count > 0)
				CloseGroup(Groups[Groups.Count-1],di);
			ReportSectionBody lastFooter = InstantiateSection("Page", false,(IDataItem)groupsData["Page"], false, true, false);
			InstantiateSection("Report", false,(IDataItem)groupsData["Report"], DataSource.Length == 0, true, true);
			if(lastFooter!=null)
				CalculateSpecialControls((IDataItem)groupsData["Page"],lastFooter.Controls,"Page",false,true);
			if(TotalPages < PreviewPageNumber) PreviewPageNumber = TotalPages;
			if(lastFooter!=null && (ViewMode==ReportViewMode.Print || 
				(ViewMode==ReportViewMode.Web && PreviewPageNumber==TotalPages )))
				controls.Add(lastFooter);

			foreach(ReportSectionBody c in controls)
			{
				Controls.Add(c);
				sections.Add(c.name);
			}
			if(LayoutFooterTemplate != null)
			{
				ReportSectionBody footer = new ReportSectionBody();
				LayoutFooterTemplate.InstantiateIn(footer);
				Controls.Add(footer);
				footer.DataBind();
			}

			foreach(object nav in navigators)
			{
				if(ViewMode == ReportViewMode.Print) ((Navigator)nav).Visible = false;
				((Navigator)nav).MaxPage = (int)TotalPages;
				((Navigator)nav).PageNumber = (int)PreviewPageNumber;
				((Navigator)nav).DataBind();
			}

			foreach(object rl in specialValues)
			{
				if(((ReportLabel)rl).Source == "TotalPages")
					BindReportLabel((ReportLabel)rl, TotalPages);
			}

			ChildControlsCreated = true;
			ViewState["sections"] = sections;

			if(BeforeShowSection!=null)
				for(int i=0; i < Controls.Count; i++)
					if(Controls[i] is ReportSectionBody)
						BeforeShowSection(this, new BeforeShowSectionEventArgs((ReportSectionBody)Controls[i]));
		}
	}

}


//End Report Control

