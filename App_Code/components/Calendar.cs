//Calendar Control @0-24A4218A
//Target Framework version is 2.0
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections;
using IssueManager.Data;

namespace IssueManager.Controls
{
	
	public enum WeekDayFormat {Full, Short, Narrow}
	public enum CalendarMode {Full, Quarter, ThreeMonth, OneMonth}
	[DefaultProperty("DataSource")]
	public class Calendar : WebControl, INamingContainer 
	{
			
		private class DateComparer : IComparer	
		{
			int IComparer.Compare( Object x, Object y )  
			{
				IComparable fDate = ((ICalendarDataItem)x).EventDateCalendarField.Value;
				IComparable fTime = ((ICalendarDataItem)x).EventTimeCalendarField.Value;
				IComparable sDate = ((ICalendarDataItem)y).EventDateCalendarField.Value;
				IComparable sTime = ((ICalendarDataItem)y).EventTimeCalendarField.Value;

				int result = 0;
				if(fDate == null && sDate == null) return 0;
				if(fDate == null && sDate != null) return -1;
				if(fDate != null && sDate == null) return 1;

				if(((ICalendarDataItem)x).IsEventTimeExists)
				{
					fDate = ((DateTime)fDate).Date;
					sDate = ((DateTime)sDate).Date;
				}

				result = fDate.CompareTo(sDate);
				if(result == 0 && ((ICalendarDataItem)x).IsEventTimeExists)
				{
					if(fTime == null && sTime == null) return 0;
					if(fTime == null && sTime != null) return -1;
					if(fTime != null && sTime == null) return 1;
					fTime = ((DateTime)fTime).TimeOfDay;
					sTime = ((DateTime)sTime).TimeOfDay;

					result = fTime.CompareTo(sTime);
				}
				return result;
			}

		}
		private IEnumerable dataSource;
		private ArrayList innerDataSource;
		private ArrayList nextMonthDataSource;

		#region Statics and Constants
		private static readonly object EventItemCreated = new object();
		private static readonly object EventItemDataBound = new object();
		private static readonly object EventItemCommand = new object();
		#endregion

		#region Templates Member variables
		
		private ITemplate footerTemplate;
		private ITemplate headerTemplate;
		private ITemplate monthHeaderTemplate;
		private ITemplate monthFooterTemplate;
		private ITemplate weekDaysTemplate;
		private ITemplate weekDaySeparatorTemplate;
		private ITemplate weekDaysFooterTemplate;
		private ITemplate weekHeaderTemplate;
		private ITemplate weekFooterTemplate;
		private ITemplate dayHeaderTemplate;
		private ITemplate dayFooterTemplate;
		private ITemplate eventSeparatorTemplate;
		private ITemplate daySeparatorTemplate;
		private ITemplate weekSeparatorTemplate;
		private ITemplate monthSeparatorTemplate;
		private ITemplate monthsRowSeparatorTemplate;
		private ITemplate noEventsTemplate;
		private ITemplate emptyDayTemplate;
		private ITemplate eventRowTemplate;
		#endregion

		#region Templates
		[
		Bindable(true),
		Category("Data"),
		DefaultValue(null),
		Description("The data source used to build up the control."),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
		]
		public IEnumerable DataSource 
		{
			get 
			{
				return dataSource;
			}
			set 
			{
				dataSource = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
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
		TemplateContainer(typeof(CCCalendarItem))
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
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate MonthHeaderTemplate 
		{
			get 
			{
				return monthHeaderTemplate;
			}
			set 
			{
				monthHeaderTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate MonthFooterTemplate 
		{
			get 
			{
				return monthFooterTemplate;
			}
			set 
			{
				monthFooterTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate WeekHeaderTemplate 
		{
			get 
			{
				return weekHeaderTemplate;
			}
			set 
			{
				weekHeaderTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate WeekFooterTemplate 
		{
			get 
			{
				return weekFooterTemplate;
			}
			set 
			{
				weekFooterTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate DayHeaderTemplate 
		{
			get 
			{
				return dayHeaderTemplate;
			}
			set 
			{
				dayHeaderTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate DayFooterTemplate 
		{
			get 
			{
				return dayFooterTemplate;
			}
			set 
			{
				dayFooterTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate WeekDaysTemplate 
		{
			get 
			{
				return weekDaysTemplate;
			}
			set 
			{
				weekDaysTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate WeekDaysFooterTemplate 
		{
			get 
			{
				return weekDaysFooterTemplate;
			}
			set 
			{
				weekDaysFooterTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate WeekDaySeparatorTemplate 
		{
			get 
			{
				return weekDaySeparatorTemplate;
			}
			set 
			{
				weekDaySeparatorTemplate = value;
			}
		}

		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate EventRowTemplate 
		{
			get 
			{
				return eventRowTemplate;
			}
			set 
			{
				eventRowTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate EventSeparatorTemplate 
		{
			get 
			{
				return eventSeparatorTemplate;
			}
			set 
			{
				eventSeparatorTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate DaySeparatorTemplate 
		{
			get 
			{
				return daySeparatorTemplate;
			}
			set 
			{
				daySeparatorTemplate = value;
			}
		}[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate WeekSeparatorTemplate 
		 {
			 get 
			 {
				 return weekSeparatorTemplate;
			 }
			 set 
			 {
				 weekSeparatorTemplate = value;
			 }
		 }
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate MonthSeparatorTemplate 
		{
			get 
			{
				return monthSeparatorTemplate;
			}
			set 
			{
				monthSeparatorTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate MonthsRowSeparatorTemplate 
		{
			get 
			{
				return monthsRowSeparatorTemplate;
			}
			set 
			{
				monthsRowSeparatorTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate NoEventsTemplate 
		{
			get 
			{
				return noEventsTemplate;
			}
			set 
			{
				noEventsTemplate = value;
			}
		}
		[
		Browsable(false),
		DefaultValue(null),
		PersistenceMode(PersistenceMode.InnerProperty),
		TemplateContainer(typeof(CCCalendarItem))
		]
		public virtual ITemplate EmptyDayTemplate 
		{
			get 
			{
				return emptyDayTemplate;
			}
			set 
			{
				emptyDayTemplate = value;
			}
		}

		#endregion

		#region Style Properties

		public HtmlGenericControl MonthStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["MonthStyle"];
			}
			set
			{
				ViewState["MonthStyle"] = value;
			}
		}
		public HtmlGenericControl CurrentMonthStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["CurrentMonthStyle"];
			}
			set
			{
				ViewState["CurrentMonthStyle"] = value;
			}
		}
		public HtmlGenericControl WeekdayNameStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["WeekdayNameStyle"];
			}
			set
			{
				ViewState["WeekdayNameStyle"] = value;
			}
		}
		public HtmlGenericControl WeekendNameStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["WeekendNameStyle"];
			}
			set
			{
				ViewState["WeekendNameStyle"] = value;
			}
		}
		public HtmlGenericControl DayStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["DayStyle"];
			}
			set
			{
				ViewState["DayStyle"] = value;
			}
		}
		public HtmlGenericControl WeekendStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["WeekendStyle"];
			}
			set
			{
				ViewState["WeekendStyle"] = value;
			}
		}
		public HtmlGenericControl TodayStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["TodayStyle"];
			}
			set
			{
				ViewState["TodayStyle"] = value;
			}
		}
		public HtmlGenericControl WeekendTodayStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["WeekendTodayStyle"];
			}
			set
			{
				ViewState["WeekendTodayStyle"] = value;
			}
		}
		public HtmlGenericControl OtherMonthDayStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["OtherMonthDayStyle"];
			}
			set
			{
				ViewState["OtherMonthDayStyle"] = value;
			}
		}
		public HtmlGenericControl OtherMonthTodayStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["OtherMonthTodayStyle"];
			}
			set
			{
				ViewState["OtherMonthTodayStyle"] = value;
			}
		}
		public HtmlGenericControl OtherMonthWeekendStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["OtherMonthWeekendStyle"];
			}
			set
			{
				ViewState["OtherMonthWeekendStyle"] = value;
			}
		}
		public HtmlGenericControl OtherMonthWeekendTodayStyle
		{
			get
			{
				return (HtmlGenericControl)ViewState["OtherMonthWeekendTodayStyle"];
			}
			set
			{
				ViewState["OtherMonthWeekendTodayStyle"] = value;
			}

		}
		#endregion

		#region Properties
		public CalendarMode Mode
		{
			get
			{
				return (CalendarMode)ViewState["_mode"];
			}
			set
			{
				ViewState["_mode"] = value;
			}
		}

		public DateTime Date
		{
			get
			{
				return (DateTime)ViewState["_date"];
			}
			set
			{
				ViewState["_date"] = value;
			}
		}

		public DateTime CurrentDate
		{
			get
			{
				if(ViewState["_currentDate"]==null)
					ViewState["_currentDate"] = DateTime.Now;
					
				return (DateTime)ViewState["_currentDate"];
			}
			set
			{
				ViewState["_currentDate"] = value;
				this.OnInit(new EventArgs());
			}
		}

		public int Month
		{
			get
			{
				return Date.Month;
			}
			set
			{
				Date = Date.AddMonths(value - Date.Month);
			}
		}

		public int Day
		{
			get
			{
				return Date.Day;
			}
			set
			{
				Date = Date.AddDays(value - Date.Day);
			}
		}
		public int Year
		 {
			 get
			 {
				 return Date.Year;
			 }
			 set
			 {
				 Date = Date.AddYears(value - Date.Year);
			 }
		 }

		public int MonthsInRow
		{
			get
			{
				int result;
				if(CalendarMode.OneMonth == Mode) return 1;
				if(ViewState["_monthsInRow"]!=null)
					result = (int)ViewState["_monthsInRow"];
				else
					result = 12;
				if((CalendarMode.Quarter == Mode || CalendarMode.ThreeMonth == Mode) && result > 3)
					result = 3;
				return result;
			}
			set
			{
				ViewState["_monthsInRow"] = value;
			}
		}

		public bool ShowOtherMonthsDays 
		{
			get
			{
				if(ViewState["_showOtherMonthsDays"]!=null)
					return (bool)ViewState["_showOtherMonthsDays"];
				else
					return false;
			}
			set
			{
				ViewState["_showOtherMonthsDays"] = value;
			}
		}
		public WeekDayFormat WeekDayFormat
		{
			get
			{
				if(ViewState["WeekdayFormat"]!=null)
					return (WeekDayFormat)ViewState["WeekdayFormat"];
				else
					return WeekDayFormat.Full;
			}
			set
			{
				ViewState["WeekdayFormat"] = value;
			}
		}


		#endregion

		#region Events
		protected virtual void OnItemCommand(CCCalendarCommandEventArgs e) 
		{
			CCCalendarCommandEventHandler onItemCommandHandler = (CCCalendarCommandEventHandler)Events[EventItemCommand];
			if (onItemCommandHandler != null) onItemCommandHandler(this, e);
		}

		protected virtual void OnItemCreated(CCCalendarItemEventArgs e) 
		{
			CCCalendarItemEventHandler onItemCreatedHandler = (CCCalendarItemEventHandler)Events[EventItemCreated];
			if (onItemCreatedHandler != null) onItemCreatedHandler(this, e);
		}

		protected virtual void OnItemDataBound(CCCalendarItemEventArgs e) 
		{
			CCCalendarItemEventHandler onItemDataBoundHandler = (CCCalendarItemEventHandler)Events[EventItemDataBound];
			if (onItemDataBoundHandler != null) onItemDataBoundHandler(this, e);
		}

		
		public event CCCalendarCommandEventHandler ItemCommand 
		{
			add 
			{
				Events.AddHandler(EventItemCommand, value);
			}
			remove 
			{
				Events.RemoveHandler(EventItemCommand, value);
			}
		}

		[
		Category("Behavior"),
		Description("Raised when an item is created and is ready for customization.")
		]
		public event CCCalendarItemEventHandler ItemCreated 
		{
			add 
			{
				Events.AddHandler(EventItemCreated, value);
			}
			remove 
			{
				Events.RemoveHandler(EventItemCreated, value);
			}
		}

		[
		Category("Behavior"),
		Description("Raised when an item is data-bound.")
		]
		public event CCCalendarItemEventHandler ItemDataBound 
		{
			add 
			{
				Events.AddHandler(EventItemDataBound, value);
			}
			remove 
			{
				Events.RemoveHandler(EventItemDataBound, value);
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

		private int GetNumOfDay(DateTime val)
		{
			int i = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
			if(i==0)
				i = (int)val.DayOfWeek;
			else
			{
				i = (int)val.DayOfWeek - i;
				if(i<0)
					i+=7;
			}
			return i;
		}

		private void CreateControlHierarchy(bool useDataSource) 
		{
			bool extendWeeks = false;
			DateTime monthStart,monthEnd;
			switch(Mode)
			{
				case CalendarMode.Full:
					monthStart = new DateTime(Year,1,1);
					monthEnd = monthStart.AddMonths(12);
					break;
				case CalendarMode.Quarter:
					monthStart = new DateTime(Year,((Month - 1) / 3) * 3 + 1,1);
					monthEnd = monthStart.AddMonths(3);
					break;
				case CalendarMode.ThreeMonth:
					monthStart = new DateTime(Year,Month,1).AddMonths(-1);
					monthEnd = monthStart.AddMonths(3);
					break;
				case CalendarMode.OneMonth:
					monthStart = new DateTime(Year,Month,1);
					monthEnd = monthStart.AddMonths(1);
					break;
				default:
					monthStart = new DateTime(Year,1,1);
					monthEnd = monthStart.AddMonths(1);
					break;
			}
			int index = 0;
			HtmlGenericControl style = null;
			DateTime currDate = monthStart;
			while(innerDataSource!=null 
				&& innerDataSource.Count > 0 
				&& ((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value == null)
			{
				innerDataSource.RemoveAt(0);
			}
			
			CreateItem(ref index,CCCalendarItemType.Header, true, null,Date,null);
			int currMonth = 0;
			for(;currDate < monthEnd; currDate = currDate.AddMonths(1))
			{	
				
				if(CalendarMode.OneMonth != Mode && EventRowTemplate == null && currMonth % MonthsInRow == 0)
				{
					extendWeeks = false;
					DateTime monthStep = currDate.AddMonths(MonthsInRow);
					for(DateTime checkDate = currDate; checkDate < monthStep && checkDate < monthEnd; checkDate = checkDate.AddMonths(1))
						if(DateTime.DaysInMonth(checkDate.Year, checkDate.Month) + GetNumOfDay(checkDate) > 35)
						{
							extendWeeks = true;
							break;
						}
				}
				if(CurrentDate.Month == currDate.Month)
					style = CurrentMonthStyle;
				else
					style = MonthStyle;
				CreateItem(ref index,CCCalendarItemType.MonthHeader, true, null,currDate,style);
				currMonth ++;
				DateTime startDate = new DateTime(Year,currDate.Month,1);
				startDate = startDate.AddDays(-GetNumOfDay(startDate));
				DateTime endDate = new DateTime(Year,currDate.Month,DateTime.DaysInMonth(Year,currDate.Month));
				endDate = endDate.AddDays(6 - GetNumOfDay(endDate));
				int offset = (endDate - startDate).Days;
				if(offset < 29)
					endDate = endDate.AddDays(7);
				if(extendWeeks &&  offset < 36) 
					endDate = endDate.AddDays(7);
				DateTime dow = startDate;
				for(int w = 0; w < 7; w ++)
				{
					if(w == (int)DayOfWeek.Sunday || w == (int)DayOfWeek.Saturday)
						style = WeekendNameStyle;
					else
						style = WeekdayNameStyle;
					CCCalendarItem item = CreateItem(ref index,CCCalendarItemType.WeekDays, true, null,dow, style);
					if(item != null)
					{
						Literal weekDay = (Literal)item.FindControl("WeekDay");
						
						if(weekDay != null)
							switch(WeekDayFormat)
							{
								case WeekDayFormat.Full:
									weekDay.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)w) ;
									break;
								case WeekDayFormat.Short:
									weekDay.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName((DayOfWeek)w) ;
									break;
								case WeekDayFormat.Narrow:
									weekDay.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)w).Substring(0,1);
									break;
							}
					}
					if(w!=6)
						CreateItem(ref index,CCCalendarItemType.WeekDaySeparator, true, null,dow, style);
					dow = dow.AddDays(1);
				}

				CreateItem(ref index,CCCalendarItemType.WeekDaysFooter, true, null,currDate, style);
				
				for(DateTime d = startDate; d <= endDate; d = d.AddDays(1))
				{
					if((int)d.DayOfWeek == (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
						CreateItem(ref index,CCCalendarItemType.WeekHeader, true, null,d, style);
					if(d.DayOfWeek == DayOfWeek.Sunday || d.DayOfWeek == DayOfWeek.Saturday)
						if(d.Date == CurrentDate.Date && d.Month == currDate.Month)
							style = WeekendTodayStyle;
						else if(d.Month == currDate.Month)
							style = WeekendStyle;
						else if(d.Date == CurrentDate.Date && d.Month != currDate.Month)
							style = OtherMonthWeekendTodayStyle;
						else
							style = OtherMonthWeekendStyle;
					else
						if(d.Date == CurrentDate.Date && d.Month == currDate.Month)
							style = TodayStyle;
						else if(d.Month == currDate.Month)
							style = DayStyle;
						else if(d.Date == CurrentDate.Date && d.Month != currDate.Month)
							style = OtherMonthTodayStyle;
						else
							style = OtherMonthDayStyle;
					if(d.Month == currDate.Month || ShowOtherMonthsDays)
					{
						bool hasEvents = false;
						while(innerDataSource!=null
							&& innerDataSource.Count > 0 
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value)  < d)
							innerDataSource.RemoveAt(0);
						if(nextMonthDataSource!=null 
							&& nextMonthDataSource.Count > 0 
							&& ((DateTime)((ICalendarDataItem)nextMonthDataSource[0]).EventDateCalendarField.Value).Day == d.Day
							&& ((DateTime)((ICalendarDataItem)nextMonthDataSource[0]).EventDateCalendarField.Value).Year == d.Year
							&& ((DateTime)((ICalendarDataItem)nextMonthDataSource[0]).EventDateCalendarField.Value).Month == d.Month
							||
							innerDataSource!=null 
							&& innerDataSource.Count > 0 
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value).Day == d.Day
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value).Year == d.Year
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value).Month == d.Month)
							hasEvents = true;
						CreateItem(ref index,CCCalendarItemType.DayHeader, true, null,d, style, hasEvents);
						bool eventsExists = false;
						while(nextMonthDataSource!=null 
							&& nextMonthDataSource.Count > 0 
							&& ((DateTime)((ICalendarDataItem)nextMonthDataSource[0]).EventDateCalendarField.Value).Day == d.Day
							&& ((DateTime)((ICalendarDataItem)nextMonthDataSource[0]).EventDateCalendarField.Value).Year == d.Year
							&& ((DateTime)((ICalendarDataItem)nextMonthDataSource[0]).EventDateCalendarField.Value).Month == d.Month)
						{
							if(eventsExists)
								CreateItem(ref index,CCCalendarItemType.EventSeparator, true, innerDataSource[0],d, style);
							CreateItem(ref index,CCCalendarItemType.EventRow, true, nextMonthDataSource[0],d, style);
							nextMonthDataSource.RemoveAt(0);
							eventsExists = true;
						}
						if(d.Day == 15 && nextMonthDataSource!=null)
							nextMonthDataSource.Clear();
						while(innerDataSource!=null 
							&& innerDataSource.Count > 0 
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value).Day == d.Day
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value).Year == d.Year
							&& ((DateTime)((ICalendarDataItem)innerDataSource[0]).EventDateCalendarField.Value).Month == d.Month)
						{
							if(eventsExists)
								CreateItem(ref index,CCCalendarItemType.EventSeparator, true, innerDataSource[0],d, style);
							CreateItem(ref index,CCCalendarItemType.EventRow, true, innerDataSource[0],d, style);
							nextMonthDataSource.Insert(nextMonthDataSource.Count,innerDataSource[0]);
							innerDataSource.RemoveAt(0);
							eventsExists = true;
						}
						if(!eventsExists)
							CreateItem(ref index,CCCalendarItemType.NoEvents, true, null,d, style);

						CreateItem(ref index,CCCalendarItemType.DayFooter, true, null,d, style, hasEvents);
						style = null;
					}
					else
					{
						if(style == OtherMonthWeekendTodayStyle) style = OtherMonthWeekendStyle;
						if(style == OtherMonthTodayStyle) style = OtherMonthDayStyle;
						CreateItem(ref index,CCCalendarItemType.EmptyDay, true, null,d, style);
					}
					if(GetNumOfDay(d) == 6)
					{
						CreateItem(ref index,CCCalendarItemType.WeekFooter, true, null,d, style);
						if(d != endDate)
							CreateItem(ref index,CCCalendarItemType.WeekSeparator, true, null,d, style);
					}
					else if(d < endDate)
						CreateItem(ref index,CCCalendarItemType.DaySeparator, true, null,d, style);
				}
				
				CreateItem(ref index,CCCalendarItemType.MonthFooter, true, null,new DateTime(Year,currDate.Month,1), style);
				if(currMonth % MonthsInRow == 0 && currDate.AddMonths(1) < monthEnd)
					CreateItem(ref index,CCCalendarItemType.MonthsRowSeparator, true, null,new DateTime(Year,currDate.Month,1), style);
				else if(currDate.AddMonths(1) < monthEnd)
					CreateItem(ref index,CCCalendarItemType.MonthSeparator, true, null,new DateTime(Year,currDate.Month,1), style);


				
			}
			CreateItem(ref index,CCCalendarItemType.Footer, true, null,new DateTime(Year,12,31), style);
		}

		private CCCalendarItem CreateItem(ref int itemIndex, CCCalendarItemType itemType, bool dataBind, object dataItem, DateTime date, HtmlGenericControl styleControl) 
		{
			return CreateItem(ref itemIndex, itemType, dataBind, dataItem, date, styleControl, false);
		}

		private CCCalendarItem CreateItem(ref int itemIndex, CCCalendarItemType itemType, bool dataBind, object dataItem, DateTime date, HtmlGenericControl styleControl, bool hasEvents) 
		{
			CCCalendarItem item = new CCCalendarItem(itemIndex, itemType, this, hasEvents);
			item.EnableViewState = false;
			if(styleControl != null)
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				System.IO.StringWriter sw = new System.IO.StringWriter(sb);
				HtmlTextWriter tw = new HtmlTextWriter(sw);
				styleControl.Attributes.Render(tw);
				item.StyleString = sb.ToString();
			}
			//CCCalendarItemEventArgs e = new CCCalendarItemEventArgs(item);
			switch(itemType)
			{
				case CCCalendarItemType.Header:
					if(headerTemplate != null) {HeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.Footer:
					if(FooterTemplate != null) {FooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.DayFooter:
					if(DayFooterTemplate != null) {DayFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.DayHeader:
					if(DayHeaderTemplate != null) {DayHeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.EventRow:
					if(EventRowTemplate != null) {EventRowTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.EventSeparator:
					if(EventSeparatorTemplate != null) {EventSeparatorTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.MonthFooter:
					if(MonthFooterTemplate != null) {MonthFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.MonthHeader:
					if(MonthHeaderTemplate != null) {MonthHeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.WeekDays:
					if(WeekDaysTemplate != null) {WeekDaysTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.WeekDaysFooter:
					if(WeekDaysFooterTemplate != null) {WeekDaysFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.WeekDaySeparator:
					if(WeekDaySeparatorTemplate != null) {WeekDaySeparatorTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.WeekFooter:
					if(WeekFooterTemplate != null) {WeekFooterTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.WeekHeader:
					if(WeekHeaderTemplate != null) {WeekHeaderTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.DaySeparator:
					if(DaySeparatorTemplate != null) {DaySeparatorTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.MonthSeparator:
					if(MonthSeparatorTemplate != null) {MonthSeparatorTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.MonthsRowSeparator:
					if(MonthsRowSeparatorTemplate != null) {MonthsRowSeparatorTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.WeekSeparator:
					if(WeekSeparatorTemplate != null) {WeekSeparatorTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.NoEvents:
					if(NoEventsTemplate != null) {NoEventsTemplate.InstantiateIn(item);itemIndex ++;}
					break;
				case CCCalendarItemType.EmptyDay:
					if(EmptyDayTemplate != null) {EmptyDayTemplate.InstantiateIn(item);itemIndex ++;}
					break;
			}
			CCCalendarItemEventArgs e = new CCCalendarItemEventArgs(item);
			if (dataBind) 
			{
				item.DataItem = (ICalendarDataItem)dataItem;
			}
			item.CurrentProcessingDate = date;
			OnItemCreated(e);
			Controls.Add(item);
		

			if (dataBind) 
			{
				item.DataBind();
			}
			OnItemDataBound(e);

			return item;
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			string d = "";
			bool isFormPresent = Page.Request.Form[ID + "Date"] != null || Page.Request.Form[ID + "Month"]!=null || Page.Request.Form[ID + "Year"]!=null;
			if(Page.Request.QueryString[ID + "Date"] != null && !isFormPresent)
				d = Page.Request.QueryString[ID + "Date"];
			else if(Page.Request.Form[ID + "Date"] != null)
				d = Page.Request.Form[ID + "Date"];
		
			if(d != "")
				try
				{
					string[] parts = d.Split('-');
					try
					{
						DateTime.ParseExact(parts[0], "yyyy", System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat);
					}
					catch{parts[0] = CurrentDate.Year.ToString("0000");}
					try
					{
						Date = DateTime.ParseExact(parts[1], "MM", System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat);
					}
					catch{parts[1] = CurrentDate.Month.ToString("00");}
					Date = DateTime.ParseExact(parts[0]+"-"+parts[1], "yyyy-MM", System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat);
				}
				catch
				{
					Date = CurrentDate;
				}
			else
			{
				Date =  CurrentDate;
				int val = 0;
				try
				{
					if(Page.Request.QueryString[ID + "Month"] != null)
						val = int.Parse(Page.Request.QueryString[ID + "Month"]);
					else if(Page.Request.Form[ID + "Month"] != null)
						Month = int.Parse(Page.Request.Form[ID + "Month"]);
					if(val>0 && val < 13) Month = val;
				}
				catch
				{}

				try
				{
					val = 0;
					if(Page.Request.QueryString[ID + "Year"] != null)
						val = int.Parse(Page.Request.QueryString[ID + "Year"]);
					else if(Page.Request.Form[ID + "Year"] != null)
						Year = int.Parse(Page.Request.Form[ID + "Year"]);
					if(val>0 && val < 10000) Year = val;
				}
				catch
				{}
			}

		}

		public override void DataBind() 
		{
			base.OnDataBinding(EventArgs.Empty);
			
			if(DataSource != null && DataSource.GetEnumerator().MoveNext())
			{
				innerDataSource = new ArrayList();
				nextMonthDataSource = new ArrayList();
				foreach(ICalendarDataItem item in DataSource)
					innerDataSource.Add(item);
				innerDataSource.Sort(new DateComparer());
			}
			


			Controls.Clear();
			if (HasChildViewState)
				ClearChildViewState();

			CreateControlHierarchy(true);
			ChildControlsCreated = true;
		}

		protected override bool OnBubbleEvent(object source, EventArgs e) 
		{

			bool handled = false;

			if (e is CCCalendarCommandEventArgs) 
			{
				CCCalendarCommandEventArgs ce = (CCCalendarCommandEventArgs)e;

				OnItemCommand(ce);
				handled = true;

			}

			return handled;
		}

		#endregion
	}
	public enum CCCalendarItemType {Header,Footer,MonthHeader,MonthFooter,WeekDays,WeekDaysFooter,WeekDaySeparator,WeekHeader,WeekFooter,DayHeader,DayFooter,EventRow,EventSeparator,DaySeparator,WeekSeparator,MonthSeparator,MonthsRowSeparator,NoEvents,EmptyDay}
	public class CCCalendarItem : Control, INamingContainer
	{
		private int itemIndex;
		private CCCalendarItemType itemType;
		private object dataItem;
		private DateTime date;
		private Calendar owner;
		private bool hasEvents = false;
		private string style;

		public CCCalendarItem(int itemIndex, CCCalendarItemType itemType, Calendar owner) 
		{
			this.itemIndex = itemIndex;
			this.itemType = itemType;
			this.owner = owner;
		}

		public CCCalendarItem(int itemIndex, CCCalendarItemType itemType, Calendar owner, bool hasEvents):this(itemIndex, itemType, owner)
		{
			this.hasEvents = hasEvents;
		}

		public  Calendar Owner
		{
			get 
			{
				return owner;
			}
		}

		public new bool HasEvents
		{
			get 
			{
				return hasEvents;
			}
		}

		public string StyleString
		{
			get 
			{
				return style;
			}
			set
			{
				style = value;
			}
		}

		public virtual object DataItem 
		{
			get 
			{
				return dataItem;
			}
			set 
			{
				dataItem = value;
			}
		}

		public virtual int ItemIndex 
		{
			get 
			{
				return itemIndex;
			}
		}

		public virtual DateTime CurrentProcessingDate
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

		public virtual DateTime NextProcessingDate
		{
			get 
			{
				switch(ItemType)
				{
					case CCCalendarItemType.DayFooter:
					case CCCalendarItemType.DayHeader:
					case CCCalendarItemType.DaySeparator:
					case CCCalendarItemType.EmptyDay:
					case CCCalendarItemType.EventRow:
					case CCCalendarItemType.EventSeparator:
					case CCCalendarItemType.NoEvents:
					case CCCalendarItemType.WeekFooter:
					case CCCalendarItemType.WeekHeader:
					case CCCalendarItemType.WeekSeparator:
						return CurrentProcessingDate.AddDays(1);
					case CCCalendarItemType.MonthFooter:
					case CCCalendarItemType.MonthHeader:
					case CCCalendarItemType.MonthsRowSeparator:
					case CCCalendarItemType.MonthSeparator:
						return CurrentProcessingDate.AddMonths(1);
					case CCCalendarItemType.Footer:
					case CCCalendarItemType.Header:
						return CurrentProcessingDate.AddYears(1);

				}
				return CurrentProcessingDate.AddDays(1);
			}
			
		}

		public virtual DateTime PrevProcessingDate
		{
			get 
			{
				switch(ItemType)
				{
					case CCCalendarItemType.DayFooter:
					case CCCalendarItemType.DayHeader:
					case CCCalendarItemType.DaySeparator:
					case CCCalendarItemType.EmptyDay:
					case CCCalendarItemType.EventRow:
					case CCCalendarItemType.EventSeparator:
					case CCCalendarItemType.NoEvents:
					case CCCalendarItemType.WeekFooter:
					case CCCalendarItemType.WeekHeader:
					case CCCalendarItemType.WeekSeparator:
						return CurrentProcessingDate.AddDays(-1);
					case CCCalendarItemType.MonthFooter:
					case CCCalendarItemType.MonthHeader:
					case CCCalendarItemType.MonthsRowSeparator:
					case CCCalendarItemType.MonthSeparator:
						return CurrentProcessingDate.AddMonths(-1);
					case CCCalendarItemType.Footer:
					case CCCalendarItemType.Header:
						return CurrentProcessingDate.AddYears(-1);
				}
				return CurrentProcessingDate.AddDays(-11);
			}
			
		}


		public virtual CCCalendarItemType ItemType 
		{
			get 
			{
				return itemType;
			}
		}

		protected override bool OnBubbleEvent(object source, EventArgs e) 
		{
			if (e is CommandEventArgs) 
			{

				CCCalendarCommandEventArgs args =
					new CCCalendarCommandEventArgs(this, source, (CommandEventArgs)e);

				RaiseBubbleEvent(this, args);
				return true;
			}
			return false;
		}

		internal void SetItemType(CCCalendarItemType itemType) 
		{
			this.itemType = itemType;
			
		}
	}

	public sealed class CCCalendarCommandEventArgs : CommandEventArgs 
	{

		private CCCalendarItem item;
		private object commandSource;

		public CCCalendarCommandEventArgs(CCCalendarItem item, object commandSource, CommandEventArgs originalArgs) :
			base(originalArgs) 
		{
			this.item = item;
			this.commandSource = commandSource;
		}

		public CCCalendarItem Item 
		{
			get 
			{
				return item;
			}
		}

		public object CommandSource 
		{
			get 
			{
				return commandSource;
			}
		}
	}

	public delegate void CCCalendarCommandEventHandler(object sender, CCCalendarCommandEventArgs e);
	public sealed class CCCalendarItemEventArgs : EventArgs 
	{

		private CCCalendarItem item;

		public CCCalendarItemEventArgs(CCCalendarItem item) 
		{
			this.item = item;
		}

		public CCCalendarItem Item 
		{
			get 
			{
				return item;
			}
		}
	}

	public delegate void CCCalendarItemEventHandler(object sender, CCCalendarItemEventArgs e);
	public interface ICalendarDataItem
	{
		bool IsEventTimeExists
		{
			get;
			set;
		}
		DateField EventDateCalendarField
		{
			get;
			set;
		}
		DateField EventTimeCalendarField
		{
			get;
			set;
		}
	}
}

//End Calendar Control

