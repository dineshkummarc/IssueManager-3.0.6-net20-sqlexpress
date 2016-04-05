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

namespace IssueManager.AdminMenu{ //Namespace @1-B998B6ED

//Page Data Class @1-F89984CB
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
        item.Link8.SetValue(DBUtility.GetInitialValue("Link8"));
        item.Link9.SetValue(DBUtility.GetInitialValue("Link9"));
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
                case "Link8":
                    return this.Link8;
                case "Link9":
                    return this.Link9;
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
                case "Link8":
                    this.Link8 = (TextField)value;
                    break;
                case "Link9":
                    this.Link9 = (TextField)value;
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
    public TextField Link8;
    public object Link8Href;
    public LinkParameterCollection Link8HrefParameters;
    public TextField Link9;
    public object Link9Href;
    public LinkParameterCollection Link9HrefParameters;
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
        Link8 = new TextField("",null);
        Link8HrefParameters = new LinkParameterCollection();
        Link9 = new TextField("",null);
        Link9HrefParameters = new LinkParameterCollection();
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

