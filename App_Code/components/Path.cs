//Path Control @0-CCE2B42F
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
    public enum CCPathItemType {Header,Footer,PathComponent,CurrentCategory}
    public class CCPathItem : Control, INamingContainer
    {
        private int itemIndex;
        private CCPathItemType itemType;
        private object dataItem;

        public CCPathItem(int itemIndex, CCPathItemType itemType) 
        {
            this.itemIndex = itemIndex;
            this.itemType = itemType;
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

        public virtual CCPathItemType ItemType 
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
                // Add the information about Item to CommandEvent.

                CCPathCommandEventArgs args =
                    new CCPathCommandEventArgs(this, source, (CommandEventArgs)e);

                RaiseBubbleEvent(this, args);
                return true;
            }
            return false;
        }

        internal void SetItemType(CCPathItemType itemType) 
        {
            this.itemType = itemType;
        }
    }

    [
    DefaultProperty("DataSource"),
    ]
    public class CCPath : WebControl, INamingContainer 
    {

    #region Statics and Constants
        private static readonly object EventItemCreated = new object();
        private static readonly object EventItemDataBound = new object();
        private static readonly object EventItemCommand = new object();
    #endregion

    #region Member variables
        private IEnumerable dataSource;
        private ITemplate footerTemplate;
        private ITemplate headerTemplate;
        private ITemplate pathComponentTemplate;
        private ITemplate currentCategoryTemplate;
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
        Browsable(false),
        DefaultValue(null),
        PersistenceMode(PersistenceMode.InnerProperty),
        TemplateContainer(typeof(CCPathItem))
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
        TemplateContainer(typeof(CCPathItem))
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
        TemplateContainer(typeof(CCPathItem))
        ]
        public virtual ITemplate PathComponentTemplate 
        {
            get 
            {
                return pathComponentTemplate;
            }
            set 
            {
                pathComponentTemplate = value;
            }
        }

        [
        Browsable(false),
        DefaultValue(null),
        PersistenceMode(PersistenceMode.InnerProperty),
        TemplateContainer(typeof(CCPathItem))
        ]
        public virtual ITemplate CurrentCategoryTemplate 
        {
            get 
            {
                return currentCategoryTemplate;
            }
            set 
            {
                currentCategoryTemplate = value;
            }
        }

    #endregion

    #region Events
        protected virtual void OnItemCommand(CCPathCommandEventArgs e) 
        {
            CCPathCommandEventHandler onItemCommandHandler = (CCPathCommandEventHandler)Events[EventItemCommand];
            if (onItemCommandHandler != null) onItemCommandHandler(this, e);
        }

        protected virtual void OnItemCreated(CCPathItemEventArgs e) 
        {
            CCPathItemEventHandler onItemCreatedHandler = (CCPathItemEventHandler)Events[EventItemCreated];
            if (onItemCreatedHandler != null) onItemCreatedHandler(this, e);
        }

        protected virtual void OnItemDataBound(CCPathItemEventArgs e) 
        {
            CCPathItemEventHandler onItemDataBoundHandler = (CCPathItemEventHandler)Events[EventItemDataBound];
            if (onItemDataBoundHandler != null) onItemDataBoundHandler(this, e);
        }

        [
        Category("Action"),
        Description("Raised when a CommandEvent occurs within an item.")
        ]
        public event CCPathCommandEventHandler ItemCommand 
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
        public event CCPathItemEventHandler ItemCreated 
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
        public event CCPathItemEventHandler ItemDataBound 
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
                // Create the control hierarchy using the view state, 
                // not the data source.
                CreateControlHierarchy(false);
            }
        }

        private void CreateControlHierarchy(bool useDataSource) 
        {
            IEnumerable dataSource = null;
            int count = -1;

            if (useDataSource == false) 
            {
                // ViewState must have a non-null value for ItemCount because this is checked 
                //  by CreateChildControls.
                count = (int)ViewState["ItemCount"];
                if (count != -1) 
                {
                dataSource = (ArrayList)ViewState["Categories"];
                }
            }
            else 
            {
                dataSource = this.dataSource;
            }

            int index = 0;
            ArrayList categories = new ArrayList();
            CreateItem(ref index, CCPathItemType.Header, useDataSource, null);
            if (dataSource != null) 
            {
                count = 0;
                object lastDataItem = null;
                foreach (object dataItem in dataSource) 
                {	
                    if(count != 0)
                    {
                        CreateItem(ref index, CCPathItemType.PathComponent, useDataSource, lastDataItem);
                    }
                    lastDataItem = dataItem;
                    count ++;
                    if(useDataSource)
                        categories.Add("");
                }
                if(lastDataItem != null)
                {
                    index --;
                    CreateItem(ref index, CCPathItemType.CurrentCategory, useDataSource, lastDataItem);
                }
            }
            CreateItem(ref index, CCPathItemType.Footer, useDataSource, null);

            if (useDataSource) 
            {
                // Save the number of items contained for use in round trips.
                ViewState["ItemCount"] = ((dataSource != null) ? count : -1);
                ViewState["Categories"] = categories;
            }
        }

        private CCPathItem CreateItem(ref int itemIndex, CCPathItemType itemType, bool dataBind, object dataItem) 
        {
            CCPathItem item = new CCPathItem(itemIndex, itemType);
            CCPathItemEventArgs e = new CCPathItemEventArgs(item);
            switch(itemType)
            {
                case CCPathItemType.Footer:
                    if(FooterTemplate != null) FooterTemplate.InstantiateIn(item);
                    break;
                case CCPathItemType.Header:
                    if(HeaderTemplate != null) HeaderTemplate.InstantiateIn(item);
                    break;
                case CCPathItemType.CurrentCategory:
                    if(CurrentCategoryTemplate != null) CurrentCategoryTemplate.InstantiateIn(item);
                    break;
                case CCPathItemType.PathComponent:
                    if(PathComponentTemplate != null) PathComponentTemplate.InstantiateIn(item);
                    break;
            }
            if (dataBind) 
            {
                item.DataItem = dataItem;
            }
            OnItemCreated(e);
            Controls.Add(item);

            if (dataBind) 
            {
                item.DataBind();
                OnItemDataBound(e);
                item.DataItem = null;
            }
            itemIndex ++;
            return item;
        }

        public override void DataBind() 
        {
            // Controls with a data-source property perform their custom data binding
            // by overriding DataBind.

            // Evaluate any data-binding expressions on the control itself.
            base.OnDataBinding(EventArgs.Empty);

            // Reset the control state.
            Controls.Clear();
            if (HasChildViewState)
                ClearChildViewState();


            //  Create the control hierarchy using the data source.
            CreateControlHierarchy(true);
            ChildControlsCreated = true;
        }

        protected override bool OnBubbleEvent(object source, EventArgs e) 
        {
            // Handle events raised by children by overriding OnBubbleEvent.

            bool handled = false;

            if (e is CCPathCommandEventArgs) 
            {
                CCPathCommandEventArgs ce = (CCPathCommandEventArgs)e;

                OnItemCommand(ce);
                handled = true;
            }

            return handled;
        }


    #endregion
    }

    public sealed class CCPathCommandEventArgs : CommandEventArgs 
    {

        private CCPathItem item;
        private object commandSource;

        public CCPathCommandEventArgs(CCPathItem item, object commandSource, CommandEventArgs originalArgs) :
            base(originalArgs) 
        {
            this.item = item;
            this.commandSource = commandSource;
        }

        public CCPathItem Item 
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

    public delegate void CCPathCommandEventHandler(object sender, CCPathCommandEventArgs e);

    public sealed class CCPathItemEventArgs : EventArgs 
    {

        private CCPathItem item;

        public CCPathItemEventArgs(CCPathItem item) 
        {
            this.item = item;
        }

        public CCPathItem Item 
        {
            get 
            {
                return item;
            }
        }
    }

    public delegate void CCPathItemEventHandler(object sender, CCPathItemEventArgs e);
}

//End Path Control

