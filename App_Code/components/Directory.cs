//Directory Control @0-8E2C831D
//Target Framework version is 2.0
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IssueManager.Controls
{
        public enum CCDirectoryItemType {Header,Footer,CategoryHeader,CategoryFooter,CategorySeparator,Subcategory,SubcategorySeparator,SubcategoriesTail,ColumnSeparator,NoRecords}
        public class CCDirectoryItem : Control, INamingContainer
        {
            private int itemIndex;
            private CCDirectoryItemType itemType;
            private ICCDirectoryDataItem dataItem;

            public CCDirectoryItem(int itemIndex, CCDirectoryItemType itemType) 
            {
                this.itemIndex = itemIndex;
                this.itemType = itemType;
            }

            public virtual ICCDirectoryDataItem DataItem 
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

            public virtual CCDirectoryItemType ItemType 
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
                    CCDirectoryCommandEventArgs args =
                        new CCDirectoryCommandEventArgs(this, source, (CommandEventArgs)e);

                    RaiseBubbleEvent(this, args);
                    return true;
                }
                return false;
            }

            internal void SetItemType(CCDirectoryItemType itemType) 
            {
                this.itemType = itemType;
            }
        }

	
        [
        DefaultProperty("DataSource"),
        ]
        public class CCDirectory : WebControl, INamingContainer 
        {
			
			[Serializable()]
			private class DummySource : ICCDirectoryDataItem
			{
				private string m_categoryID;
				private string m_subcatID;
			
				public string CategoryId
				{
					get
					{
						return m_categoryID;
					}
					set
					{
						m_categoryID = value;
					}
				}
				
				public string SubcategoryId
				{
					get
					{
						return m_subcatID;
					}
					set
					{
						m_subcatID = value;
					}
				}
			}

    
			#region Statics and Constants
            private static readonly object EventItemCreated = new object();
            private static readonly object EventItemDataBound = new object();
            private static readonly object EventItemCommand = new object();
    #endregion


    #region Member variables
            private IEnumerable dataSource;
            private ITemplate footerTemplate;
            private ITemplate headerTemplate;
            private ITemplate categoryHeaderTemplate;
            private ITemplate categoryFooterTemplate;
            private ITemplate categorySeparatorTemplate;
            private ITemplate subcategoryTemplate;
            private ITemplate subcategorySeparatorTemplate;
            private ITemplate subcategoriesTailTemplate;
            private ITemplate columnSeparatorTemplate;
            private ITemplate noRecordsTemplate;
    #endregion

    #region Properties
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
            Bindable(true),
            Category("Data"),
            DefaultValue(null),
            Description("The No. of colums"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
            ]
            public int NumberOfColumns 
            {
                get 
                {
					if(ViewState["columnCount"] == null) return 1;
                    return (int)ViewState["columnCount"];
                }
                set 
                {
                    ViewState["columnCount"] = value;
                }
            }

            [
            Bindable(true),
            Category("Data"),
            DefaultValue(null),
            Description("The No. of subcategories"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
            ]
            public int NumberOfSubCategories 
            {
                get 
                {
					if(ViewState["subcategoryCount"] == null) return -1;
					return (int)ViewState["subcategoryCount"];
                }
                set 
                {
					ViewState["subcategoryCount"] = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
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
            TemplateContainer(typeof(CCDirectoryItem))
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
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate CategoryHeaderTemplate 
            {
                get 
                {
                    return categoryHeaderTemplate;
                }
                set 
                {
                    categoryHeaderTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate CategoryFooterTemplate 
            {
                get 
                {
                    return categoryFooterTemplate;
                }
                set 
                {
                    categoryFooterTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate CategorySeparatorTemplate 
            {
                get 
                {
                    return categorySeparatorTemplate;
                }
                set 
                {
                    categorySeparatorTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate SubcategoryTemplate 
            {
                get 
                {
                    return subcategoryTemplate;
                }
                set 
                {
                    subcategoryTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate SubcategorySeparatorTemplate 
            {
                get 
                {
                    return subcategorySeparatorTemplate;
                }
                set 
                {
                    subcategorySeparatorTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate SubcategoriesTailTemplate 
            {
                get 
                {
                    return subcategoriesTailTemplate;
                }
                set 
                {
                    subcategoriesTailTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate ColumnSeparatorTemplate 
            {
                get 
                {
                    return columnSeparatorTemplate;
                }
                set 
                {
                    columnSeparatorTemplate = value;
                }
            }

            [
            Browsable(false),
            DefaultValue(null),
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(CCDirectoryItem))
            ]
            public virtual ITemplate NoRecordsTemplate 
            {
                get 
                {
                    return noRecordsTemplate;
                }
                set 
                {
                    noRecordsTemplate = value;
                }
            }

    #endregion

    #region Events
            protected virtual void OnItemCommand(CCDirectoryCommandEventArgs e) 
            {
                CCDirectoryCommandEventHandler onItemCommandHandler = (CCDirectoryCommandEventHandler)Events[EventItemCommand];
                if (onItemCommandHandler != null) onItemCommandHandler(this, e);
            }

            protected virtual void OnItemCreated(CCDirectoryItemEventArgs e) 
            {
                CCDirectoryItemEventHandler onItemCreatedHandler = (CCDirectoryItemEventHandler)Events[EventItemCreated];
                if (onItemCreatedHandler != null) onItemCreatedHandler(this, e);
            }

            protected virtual void OnItemDataBound(CCDirectoryItemEventArgs e) 
            {
                CCDirectoryItemEventHandler onItemDataBoundHandler = (CCDirectoryItemEventHandler)Events[EventItemDataBound];
                if (onItemDataBoundHandler != null) onItemDataBoundHandler(this, e);
            }

            [
            Category("Action"),
            Description("Raised when a CommandEvent occurs within an item.")
            ]
            public event CCDirectoryCommandEventHandler ItemCommand 
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
            public event CCDirectoryItemEventHandler ItemCreated 
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
            public event CCDirectoryItemEventHandler ItemDataBound 
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

            private void CreateControlHierarchy(bool useDataSource) 
            {
                IEnumerable dataSource = null;
                ArrayList categories = null;
                int subindex = 0;
                int count = -1,elementCount = 1,columnElements = 0;

                if (useDataSource == false) 
                {
                    count = (int)ViewState["ItemCount"];
                    if (count != -1) 
                        dataSource = (ArrayList)ViewState["Categories"];
                }
                else 
                {
                    dataSource = this.dataSource;
					categories = new ArrayList();
                }

                int index = 0;
                ICCDirectoryDataItem previousDataItem = null;
                CreateItem(ref index, CCDirectoryItemType.Header, false, null);
                if (dataSource != null) 
                {
                    count = 0;int subcatCount = 1;
                    bool CreateCategory = true;
                    foreach (ICCDirectoryDataItem dataItem in dataSource) 
                    {
                        if(count != 0 && previousDataItem.CategoryId != dataItem.CategoryId)
                            elementCount ++;
                        previousDataItem = dataItem;
                        count ++;
                    }
                    columnElements = (int)Math.Ceiling((double)elementCount / (double)NumberOfColumns);

                    previousDataItem = null;count = 0;elementCount = 0;
                    foreach (ICCDirectoryDataItem dataItem in dataSource) 
                    {
                        if(count != 0 && previousDataItem.CategoryId != dataItem.CategoryId)
                        {
                            CreateItem(ref index, CCDirectoryItemType.CategoryFooter, useDataSource, previousDataItem);
                            if(count == 0 || elementCount < columnElements)
                                CreateItem(ref index, CCDirectoryItemType.CategorySeparator, useDataSource, null);
                            CreateCategory = true;
                        }
                        else if (count != 0 && ((NumberOfSubCategories != 0 && subcatCount <= NumberOfSubCategories + 1) || NumberOfSubCategories == -1))
                            CreateItem(ref index, CCDirectoryItemType.SubcategorySeparator, useDataSource, null);

                        if(CreateCategory)
                        {
                            if(count != 0 && elementCount >= columnElements){
                                CreateItem(ref index, CCDirectoryItemType.ColumnSeparator, useDataSource, null);
                                elementCount = 0;}
                            CreateItem(ref index, CCDirectoryItemType.CategoryHeader, useDataSource, dataItem);
                            CreateCategory = false;
                            subcatCount = 1;
                            elementCount ++;
                        }
                        if ((NumberOfSubCategories == -1 || subcatCount <= NumberOfSubCategories) && dataItem.SubcategoryId != null)
                            CreateItem(ref index, CCDirectoryItemType.Subcategory, useDataSource, dataItem);
                        if (NumberOfSubCategories != 0 && subcatCount == NumberOfSubCategories + 1 && dataItem.SubcategoryId != null)
                            CreateItem(ref index, CCDirectoryItemType.SubcategoriesTail, useDataSource, dataItem);
                        previousDataItem = dataItem;
                        count ++;
                        subcatCount ++;
                        if(useDataSource)
						{	DummySource ds  = new DummySource();
							ds.CategoryId = dataItem.CategoryId;
							ds.SubcategoryId = dataItem.SubcategoryId;
                            categories.Add(ds);
						}
                    }
                    subindex ++;
                }
                if (count <= 0)
                {
                    CreateItem(ref index, CCDirectoryItemType.NoRecords, false, null);
                }
                else
                    CreateItem(ref index, CCDirectoryItemType.CategoryFooter, useDataSource, previousDataItem);
                CreateItem(ref index, CCDirectoryItemType.Footer, false, null);
                if (useDataSource) 
                {
                    ViewState["ItemCount"] = ((dataSource != null) ? count : -1);
                    ViewState["Categories"] = categories;
                }
            }

            private CCDirectoryItem CreateItem(ref int itemIndex, CCDirectoryItemType itemType, bool dataBind, object dataItem) 
            {
                CCDirectoryItem item = new CCDirectoryItem(itemIndex, itemType);
                CCDirectoryItemEventArgs e = new CCDirectoryItemEventArgs(item);
                switch(itemType)
                {
                    case CCDirectoryItemType.CategoryFooter:
                        if(categoryFooterTemplate != null) {CategoryFooterTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.CategoryHeader:
                        if(CategoryHeaderTemplate != null) {CategoryHeaderTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.CategorySeparator:
                        if(CategorySeparatorTemplate != null) {CategorySeparatorTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.Footer:
                        if(FooterTemplate != null) {FooterTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.Header:
                        if(HeaderTemplate != null) {HeaderTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.NoRecords:
                        if(NoRecordsTemplate != null) {NoRecordsTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.Subcategory:
                        if(SubcategoryTemplate != null) {SubcategoryTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.SubcategorySeparator:
                        if(SubcategorySeparatorTemplate != null) {SubcategorySeparatorTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.SubcategoriesTail:
                        if(SubcategoriesTailTemplate != null) {SubcategoriesTailTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                    case CCDirectoryItemType.ColumnSeparator:
                        if(ColumnSeparatorTemplate != null) {ColumnSeparatorTemplate.InstantiateIn(item);itemIndex ++;}
                        break;
                }
                if (dataBind) 
                {
                    item.DataItem = (ICCDirectoryDataItem)dataItem;
                }
                OnItemCreated(e);
                Controls.Add(item);

                if (dataBind) 
                {
                    item.DataBind();
                    OnItemDataBound(e);

                    item.DataItem = null;
                }

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

            protected override bool OnBubbleEvent(object source, EventArgs e) 
            {
                bool handled = false;

                if (e is CCDirectoryCommandEventArgs) 
                {
                    CCDirectoryCommandEventArgs ce = (CCDirectoryCommandEventArgs)e;

                    OnItemCommand(ce);
                    handled = true;

                }

                return handled;
            }

    #endregion
        }

        public sealed class CCDirectoryCommandEventArgs : CommandEventArgs 
        {

            private CCDirectoryItem item;
            private object commandSource;

            public CCDirectoryCommandEventArgs(CCDirectoryItem item, object commandSource, CommandEventArgs originalArgs) :
                base(originalArgs) 
            {
                this.item = item;
                this.commandSource = commandSource;
            }

            public CCDirectoryItem Item 
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

        public delegate void CCDirectoryCommandEventHandler(object sender, CCDirectoryCommandEventArgs e);

        public sealed class CCDirectoryItemEventArgs : EventArgs 
        {

            private CCDirectoryItem item;

            public CCDirectoryItemEventArgs(CCDirectoryItem item) 
            {
                this.item = item;
            }

            public CCDirectoryItem Item 
            {
                get 
                {
                    return item;
                }
            }
        }

        public delegate void CCDirectoryItemEventHandler(object sender, CCDirectoryItemEventArgs e);

        public interface ICCDirectoryDataItem
        {
            string CategoryId
            {
                get;
                set;
            }
            string SubcategoryId
            {
                get;
                set;
            }
        }
}

//End Directory Control

