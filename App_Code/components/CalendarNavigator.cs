//Calendar Navigator Control @0-9DF956AF
//Target Framework version is 2.0
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections;

namespace IssueManager.Controls
{

	public enum CalendarNavigatorOrder {YearsQuartersMonths, YearsMonthsQuarters, MonthsQuartersYears, MonthsYearsQuarters, QuartersYearsMonths, QuartersMonthsYears}
	public class CalendarNavigator : WebControl, INamingContainer 
	{
		
		private Calendar owner;
		#region Templates Member variables
		
		private ITemplate footerTemplate;
		private ITemplate headerTemplate;
		private ITemplate prev_YearTemplate;
		private ITemplate prevTemplate;
		private ITemplate next_YearTemplate;
		private ITemplate nextTemplate;
		private ITemplate yearsFooterTemplate;
		private ITemplate yearsHeaderTemplate;
		private ITemplate monthsFooterTemplate;
		private ITemplate monthsHeaderTemplate;
		private ITemplate regularYearTemplate;
		private ITemplate currentYearTemplate;
		private ITemplate regularMonthTemplate;
		private ITemplate currentMonthTemplate;
		private ITemplate quartersFooterTemplate;
		private ITemplate quartersHeaderTemplate;
		private ITemplate regularQuarterTemplate;
		private ITemplate currentQuarterTemplate;
		private ITemplate bodyTemplate;
		#endregion

		#region Templates
		

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate HeaderTemplate 
		{
			get 
			{
				return headerTemplate;
			}
			set 
			{
				headerTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate FooterTemplate 
		{
			get 
			{
				return footerTemplate;
			}
			set 
			{
				footerTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate MonthsHeaderTemplate 
		{
			get 
			{
				return monthsHeaderTemplate;
			}
			set 
			{
				monthsHeaderTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate MonthsFooterTemplate 
		{
			get 
			{
				return monthsFooterTemplate;
			}
			set 
			{
				monthsFooterTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate YearsHeaderTemplate 
		{
			get 
			{
				return yearsHeaderTemplate;
			}
			set 
			{
				yearsHeaderTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate YearsFooterTemplate 
		{
			get 
			{
				return yearsFooterTemplate;
			}
			set 
			{
				yearsFooterTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate RegularYearTemplate 
		{
			get 
			{
				return regularYearTemplate;
			}
			set 
			{
				regularYearTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate CurrentYearTemplate
		{
			get 
			{
				return currentYearTemplate;
			}
			set 
			{
				currentYearTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate QuartersHeaderTemplate 
		{
			get 
			{
				return quartersHeaderTemplate;
			}
			set 
			{
				quartersHeaderTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate QuartersFooterTemplate 
		{
			get 
			{
				return quartersFooterTemplate;
			}
			set 
			{
				quartersFooterTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate RegularQuarterTemplate 
		{
			get 
			{
				return regularQuarterTemplate;
			}
			set 
			{
				regularQuarterTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate CurrentQuarterTemplate
		{
			get 
			{
				return currentQuarterTemplate;
			}
			set 
			{
				currentQuarterTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate RegularMonthTemplate 
		{
			get 
			{
				return regularMonthTemplate;
			}
			set 
			{
				regularMonthTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate CurrentMonthTemplate 
		{
			get 
			{
				return currentMonthTemplate;
			}
			set 
			{
				currentMonthTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate Prev_YearTemplate
		{
			get 
			{
				return prev_YearTemplate;
			}
			set 
			{
				prev_YearTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate PrevTemplate
		{
			get 
			{
				return prevTemplate;
			}
			set 
			{
				prevTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate Next_YearTemplate
		{
			get 
			{
				return next_YearTemplate;
			}
			set 
			{
				next_YearTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate NextTemplate
		{
			get 
			{
				return nextTemplate;
			}
			set 
			{
				nextTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CalendarNavigatorItem))
		]
		public virtual ITemplate BodyTemplate
		{
			get 
			{
				return bodyTemplate;
			}
			set 
			{
				bodyTemplate = value;
			}
		}
		#endregion

		
		#region Properties
		
		public  Calendar Owner
		{
			get 
			{
				return owner;
			}
		}


		public int YearsRange 
		{
			get 
			{
				if(ViewState["yearsRange"] == null) return 0;
				return (int)ViewState["yearsRange"];
			}
			set 
			{
				ViewState["yearsRange"] = value;
			}
		}

		public CalendarNavigatorOrder Order 
		{
			get 
			{
				if(ViewState["order"] == null) return CalendarNavigatorOrder.MonthsQuartersYears;
				return (CalendarNavigatorOrder)ViewState["order"];
			}
			set 
			{
				ViewState["order"] = value;
			}
		}

		
		public DateTime Date
		{
			get
			{
				return owner.Date;
			}
		}

		public int Month
		{
			get
			{
				return Date.Month;
			}
		}

		public int Year
		{
			get
			{
				return owner.Year;
			}
		}

		public int Quarter
		{
			get
			{
				return (owner.Month -1)/ 3 + 1;
			}
		}


		#endregion

		#region Methods and Implementation
		protected override void CreateChildControls() 
		{
			Controls.Clear();

			if (ViewState["ItemCount"] != null) 
			{
				CreateControlHierarchy(false);
			}
		}

		private void CreateMonths(ref int index) 
		{
			if(MonthsFooterTemplate != null)
			{
				CreateItem(ref index,CalendarNavigatorItemType.MonthsHeader, true, null,Date);
				for(int i = 1; i <= 12; i++)
				{
					if(i == Month)
						CreateItem(ref index,CalendarNavigatorItemType.CurrentMonth, true, null,Date);
					else
						CreateItem(ref index,CalendarNavigatorItemType.RegularMonth, true, null,new DateTime(Year, i ,1));
				}
				CreateItem(ref index,CalendarNavigatorItemType.MonthsFooter, true, null,Date);
			}

		}

		private void CreateYears(ref int index) 
		{
			if(YearsFooterTemplate != null)
			{
				CreateItem(ref index,CalendarNavigatorItemType.YearsHeader, true, null,Date);
				for(int i = Year - YearsRange; i <= Year + YearsRange; i++)
				{
					if(i == Year)
						CreateItem(ref index,CalendarNavigatorItemType.CurrentYear, true, null,Date);
					else
						CreateItem(ref index,CalendarNavigatorItemType.RegularYear, true, null,new DateTime(i,Month,1));
				}
				CreateItem(ref index,CalendarNavigatorItemType.YearsFooter, true, null,Date);
			}
		}

		private void CreateQuarters(ref int index) 
		{
			if(QuartersFooterTemplate != null)
			{
				CreateItem(ref index,CalendarNavigatorItemType.QuartersHeader, true, null,Date);
				for(int i = 1; i <= 4; i++)
				{
					if(i == Quarter)
						CreateItem(ref index,CalendarNavigatorItemType.CurrentQuarter, true, null,new DateTime(Year,(i-1)*3 + 1,1));
					else
						CreateItem(ref index,CalendarNavigatorItemType.RegularQuarter, true, null,new DateTime(Year,(i-1)*3 + 1,1));
				}
				CreateItem(ref index,CalendarNavigatorItemType.QuartersFooter, true, null,Date);
			}
		}

		private void CreateControlHierarchy(bool useDataSource) 
		{
			int index = 0;
			CreateItem(ref index,CalendarNavigatorItemType.Header, true, null,Date);
			CreateItem(ref index,CalendarNavigatorItemType.Prev_Year, true, null,Date.AddYears(-1));
			if(Owner.Mode == CalendarMode.Quarter)
				CreateItem(ref index,CalendarNavigatorItemType.Prev, true, null,Date.AddMonths(-(Date.Month-1)%3 - 3));
			else
				CreateItem(ref index,CalendarNavigatorItemType.Prev, true, null,Date.AddMonths(-1));

			switch(Order)
			{
				case CalendarNavigatorOrder.YearsQuartersMonths:
					CreateYears(ref index);
					CreateQuarters(ref index);
					CreateMonths(ref index);
					break;
				case CalendarNavigatorOrder.YearsMonthsQuarters:
					CreateYears(ref index);
					CreateMonths(ref index);
					CreateQuarters(ref index);
					break;
				case CalendarNavigatorOrder.MonthsQuartersYears:
					CreateMonths(ref index);
					CreateQuarters(ref index);
					CreateYears(ref index);
					break;
				case CalendarNavigatorOrder.MonthsYearsQuarters:
					CreateMonths(ref index);
					CreateYears(ref index);
					CreateQuarters(ref index);
					break;
				case CalendarNavigatorOrder.QuartersYearsMonths:
					CreateQuarters(ref index);
					CreateYears(ref index);
					CreateMonths(ref index);
					break;
				case CalendarNavigatorOrder.QuartersMonthsYears:
					CreateQuarters(ref index);
					CreateMonths(ref index);
					CreateYears(ref index);
					break;
			}

			CreateItem(ref index,CalendarNavigatorItemType.Body, true, null,Date);
			if(Owner.Mode == CalendarMode.Quarter)
				CreateItem(ref index,CalendarNavigatorItemType.Next, true, null,Date.AddMonths(3-(Date.Month-1)%3));
			else
				CreateItem(ref index,CalendarNavigatorItemType.Next, true, null,Date.AddMonths(1));

			CreateItem(ref index,CalendarNavigatorItemType.Next_Year, true, null,Date.AddYears(1));
			CreateItem(ref index,CalendarNavigatorItemType.Footer, true, null,Date);
			
		}

		private CalendarNavigatorItem CreateItem(ref int itemIndex, CalendarNavigatorItemType itemType, bool dataBind, object dataItem, DateTime date) 
		{
			CalendarNavigatorItem item = new CalendarNavigatorItem(itemIndex, itemType, this);
			item.EnableViewState = false;
			item.Date = date;			
			switch(itemType)
			{
				case CalendarNavigatorItemType.Header:
					if(headerTemplate != null) {HeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.Footer:
					if(FooterTemplate != null) {FooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.CurrentMonth:
					if(CurrentMonthTemplate != null) {CurrentMonthTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.CurrentYear:
					if(CurrentYearTemplate != null) {CurrentYearTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.CurrentQuarter:
					if(CurrentQuarterTemplate != null) {CurrentQuarterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.Prev:
					if(PrevTemplate != null) {PrevTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.MonthsFooter:
					if(MonthsFooterTemplate != null) {MonthsFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.MonthsHeader:
					if(MonthsHeaderTemplate != null) {MonthsHeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.QuartersFooter:
					if(QuartersFooterTemplate != null) {QuartersFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.QuartersHeader:
					if(QuartersHeaderTemplate != null) {QuartersHeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.Next:
					if(NextTemplate != null) {NextTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.Prev_Year:
					if(Prev_YearTemplate != null) {Prev_YearTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.RegularMonth:
					if(RegularMonthTemplate != null) {RegularMonthTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.RegularYear:
					if(RegularYearTemplate != null) {RegularYearTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.RegularQuarter:
					if(RegularQuarterTemplate != null) {RegularQuarterTemplate.InstantiateIn(item);itemIndex ++;}
					break;

				case CalendarNavigatorItemType.Next_Year:
					if(Next_YearTemplate != null) {Next_YearTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.YearsFooter:
					if(YearsFooterTemplate != null) {YearsFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.YearsHeader:
					if(YearsHeaderTemplate != null) {YearsHeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CalendarNavigatorItemType.Body:
					if(BodyTemplate != null) {BodyTemplate.InstantiateIn(item);itemIndex ++;}
					break;
			}
			Controls.Add(item);
			item.DataBind();
			return item;
		}


		public override void DataBind() 
		{
			base.OnDataBinding(EventArgs.Empty);
			
			Controls.Clear();
			if (HasChildViewState)
				ClearChildViewState();

			CreateControlHierarchy(true);
			ChildControlsCreated = true;
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			Control parent = Parent;
			while(!(parent is Calendar) && !(parent is System.Web.UI.Page))
				parent = parent.Parent;
			if(parent is System.Web.UI.Page) throw new ApplicationException("CalendarNavigator can be placed only inside Calendar component");
			owner = (Calendar)parent;
		}



		#endregion
	}
	public enum CalendarNavigatorItemType {Header,Footer,Prev_Year,Prev,YearsHeader,RegularYear,CurrentYear,YearsFooter,MonthsHeader,RegularMonth,CurrentMonth,MonthsFooter,QuartersHeader,RegularQuarter,CurrentQuarter,QuartersFooter,Next,Next_Year,Body}
	public class CalendarNavigatorItem : Control, INamingContainer
	{
		private int itemIndex;
		private CalendarNavigatorItemType itemType;
		private DateTime date;
		private CalendarNavigator owner;

		public CalendarNavigatorItem(int itemIndex, CalendarNavigatorItemType itemType, CalendarNavigator owner) 
		{
			this.itemIndex = itemIndex;
			this.itemType = itemType;
			this.owner = owner;
		}

		public  CalendarNavigator Owner
		{
			get 
			{
				return owner;
			}
		}
		
		public string CalendarName
		{
			get 
			{
				return Owner.Owner.ID;
			}
		}

		public virtual int ItemIndex 
		{
			get 
			{
				return itemIndex;
			}
		}

		public virtual DateTime Date
		{
			get 
			{
				return date;
			}
			set
			{
				date = value;
			}
		}
		public virtual int Quarter
		{
			get 
			{
				return (Date.Month - 1) / 3 + 1;
			}
		}
		public virtual string Action
		{
			get
			{
				string result = Page.Request.Url.AbsolutePath.Substring(Page.Request.Url.AbsolutePath.LastIndexOf('/') + 1) + "?";
				string id = Owner.Owner.ID;
				System.Collections.Specialized.NameValueCollection query = Page.Request.QueryString;
				for(int i=0;i<query.Count;i++)
				{
					if(query.AllKeys[i]!= id+"Year" &&
						query.AllKeys[i]!= id+"Month" &&
						query.AllKeys[i]!= id+"Date")
						if(query.AllKeys[i]!=null)
							result+= query.AllKeys[i] + "=" + Page.Server.UrlEncode(query[i]) + "&";
						else
							result+= Page.Server.UrlEncode(query[i]) + "&";
				}
				return result;
			}
		}
		public virtual string Url
		{
			get
			{
				return Action + Owner.Owner.ID + "Date=" + Date.ToString("yyyy-MM");
			}
		}
		public virtual CalendarNavigatorItemType ItemType 
		{
			get 
			{
				return itemType;
			}
		}

		
		internal void SetItemType(CalendarNavigatorItemType itemType) 
		{
			this.itemType = itemType;
			
		}
	}
}

//End Calendar Navigator Control

