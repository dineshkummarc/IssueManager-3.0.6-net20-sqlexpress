//Sorter Class @0-5C6629B3
//Target Framework version is 2.0
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using IssueManager.Data;

namespace IssueManager.Controls
{
    public enum SorterItemTypes{AscOn,AscOff,DescOn,DescOff}
    public enum SorterState{ Ascending , Descending , None}

    public class SorterItem:Control,INamingContainer 
    { 
        private SorterItemTypes m_type;

        public SorterItemTypes Type
        {
            get{return m_type;}
            set{m_type=value;}
        }

        protected override void AddParsedSubObject(Object obj)
        { 
            Controls.Add((Control)obj);
        }
    }

    public class SortEventArgs:CommandEventArgs 
    {
        private string m_field;
        private SorterState m_state;

    public string Field{
        get{
            return m_field;
        }
        set{
            m_field=value;
        }
    }

    public SorterState State{
        get{
            return m_state;
        }
        set{
            m_state=value;
        }
    }

        public SortEventArgs(string commandName,SorterState state,string field):base(commandName,state)
        {
            this.Field=field;this.State=state;
        }
    }

    [ParseChildren(false)]
    public class Sorter : Control,INamingContainer
    {
        private SorterItem AscOn,AscOff,DescOn,DescOff;
        private SorterState m_state=SorterState.None;
        private string m_field ="";
        private string m_ownerID ="";
        private string m_ownerState ="";
        private SortDirections m_ownerDir = SortDirections.Asc;

        public SorterState State 
        {
            get{return m_state;}
            set{m_state = value;}
        }

        public string Field 
        {
            get{return m_field;}
            set{m_field = value;}
        }

        public string OwnerID 
        {
            get{return m_ownerID;}
            set{m_ownerID = value;}
        }

        public string OwnerState 
        {
            get{return m_ownerState;}
            set{m_ownerState = value;}
        }

        public SortDirections OwnerDir 
        {
            get{return m_ownerDir;}
            set{m_ownerDir = value;}
        }

        protected override bool OnBubbleEvent(object source, EventArgs e) 
        {
            if(source is SorterItem)
            {
                if(((string)((CommandEventArgs)e).CommandArgument)=="AscOff")State=SorterState.Ascending;
                if(((string)((CommandEventArgs)e).CommandArgument)=="DescOff")State=SorterState.Descending;
            }
            else State=SorterState.None;

            SortEventArgs args = new SortEventArgs("Sort",State,Field);
            RaiseBubbleEvent(this, args);
            return true;
        }

        protected override void AddParsedSubObject(Object obj)
        {
            Controls.Add((Control)obj);
            if(obj is SorterItem){
                if(((SorterItem)obj).Type==SorterItemTypes.AscOn) AscOn=(SorterItem)obj;
                if(((SorterItem)obj).Type==SorterItemTypes.AscOff) AscOff=(SorterItem)obj;
                if(((SorterItem)obj).Type==SorterItemTypes.DescOn) DescOn=(SorterItem)obj;
                if(((SorterItem)obj).Type==SorterItemTypes.DescOff) DescOff=(SorterItem)obj;}
        }

        protected override void OnPreRender(EventArgs e )
        { 
            if (OwnerState != "" && OwnerState == Field)
                State = OwnerDir==SortDirections.Asc?SorterState.Ascending:SorterState.Descending;
            if(AscOn!=null)AscOn.Visible=(State==SorterState.Ascending);
            if(AscOff!=null)AscOff.Visible=(State==SorterState.Descending||State==SorterState.None);
            if(DescOn!=null)DescOn.Visible=(State==SorterState.Descending);
            if(DescOff!=null)DescOff.Visible=(State==SorterState.Ascending||State==SorterState.None);
            base.OnPreRender(e);
        }
    }
}
//End Sorter Class

