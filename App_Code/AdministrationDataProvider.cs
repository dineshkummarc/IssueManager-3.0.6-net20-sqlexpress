//Using Statements @1-D5139E01
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using IssueManager;
using IssueManager.Data;
using IssueManager.Controls;
using IssueManager.Security;
using IssueManager.Configuration;

//End Using Statements

namespace IssueManager.Administration{ //Namespace @1-CEDB2F4B

//Page Data Class @1-76419C88
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"));
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"));
        item.Link3.SetValue(DBUtility.GetInitialValue("Link3"));
        item.Link4.SetValue(DBUtility.GetInitialValue("Link4"));
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"));
        item.Link6.SetValue(DBUtility.GetInitialValue("Link6"));
        item.Link7.SetValue(DBUtility.GetInitialValue("Link7"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "Link1":
                    return this.Link1;
                case "Link2":
                    return this.Link2;
                case "Link3":
                    return this.Link3;
                case "Link4":
                    return this.Link4;
                case "Link5":
                    return this.Link5;
                case "Link6":
                    return this.Link6;
                case "Link7":
                    return this.Link7;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "Link1":
                    this.Link1 = (TextField)value;
                    break;
                case "Link2":
                    this.Link2 = (TextField)value;
                    break;
                case "Link3":
                    this.Link3 = (TextField)value;
                    break;
                case "Link4":
                    this.Link4 = (TextField)value;
                    break;
                case "Link5":
                    this.Link5 = (TextField)value;
                    break;
                case "Link6":
                    this.Link6 = (TextField)value;
                    break;
                case "Link7":
                    this.Link7 = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public TextField Link2;
    public object Link2Href;
    public LinkParameterCollection Link2HrefParameters;
    public TextField Link3;
    public object Link3Href;
    public LinkParameterCollection Link3HrefParameters;
    public TextField Link4;
    public object Link4Href;
    public LinkParameterCollection Link4HrefParameters;
    public TextField Link5;
    public object Link5Href;
    public LinkParameterCollection Link5HrefParameters;
    public TextField Link6;
    public object Link6Href;
    public LinkParameterCollection Link6HrefParameters;
    public TextField Link7;
    public object Link7Href;
    public LinkParameterCollection Link7HrefParameters;
    public PageItem()
    {
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
        Link2 = new TextField("",null);
        Link2HrefParameters = new LinkParameterCollection();
        Link3 = new TextField("",null);
        Link3HrefParameters = new LinkParameterCollection();
        Link4 = new TextField("",null);
        Link4HrefParameters = new LinkParameterCollection();
        Link5 = new TextField("",null);
        Link5HrefParameters = new LinkParameterCollection();
        Link6 = new TextField("",null);
        Link6HrefParameters = new LinkParameterCollection();
        Link7 = new TextField("",null);
        Link7HrefParameters = new LinkParameterCollection();
    }
}
//End Page Data Class

//Page Data Provider Class @1-50FE4D41
public class PageDataProvider
{
//End Page Data Provider Class

//Page Data Provider Class Constructor @1-9A44B219
    public PageDataProvider()
    {
    }
//End Page Data Provider Class Constructor

//Page Data Provider Class GetResultSet Method @1-052161C6
    public void FillItem(PageItem item)
    {
//End Page Data Provider Class GetResultSet Method

//Page Data Provider Class GetResultSet Method tail @1-FCB6E20C
    }
//End Page Data Provider Class GetResultSet Method tail

//Page Data Provider class Tail @1-FCB6E20C
}
//End Page Data Provider class Tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

