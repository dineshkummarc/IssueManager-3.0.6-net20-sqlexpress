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

namespace IssueManager.Header{ //Namespace @1-025D523B

//Page Data Class @1-D6E3B367
public class PageItem
{
    public NameValueCollection errors=new NameValueCollection();
    public static PageItem CreateFromHttpRequest()
    {
        PageItem item = new PageItem();
        item.user.SetValue(DBUtility.GetInitialValue("user"));
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"));
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"));
        item.Link3.SetValue(DBUtility.GetInitialValue("Link3"));
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"));
        item.Link4.SetValue(DBUtility.GetInitialValue("Link4"));
        item.style.SetValue(DBUtility.GetInitialValue("style"));
        item.locale.SetValue(DBUtility.GetInitialValue("locale"));
        return item;
    }

    public FieldBase this[string fieldName]{
        get{
            switch(fieldName){
                case "user":
                    return this.user;
                case "Link1":
                    return this.Link1;
                case "Link2":
                    return this.Link2;
                case "Link3":
                    return this.Link3;
                case "Link5":
                    return this.Link5;
                case "Link4":
                    return this.Link4;
                case "style":
                    return this.style;
                case "locale":
                    return this.locale;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
        set{
            switch(fieldName){
                case "user":
                    this.user = (TextField)value;
                    break;
                case "Link1":
                    this.Link1 = (TextField)value;
                    break;
                case "Link2":
                    this.Link2 = (TextField)value;
                    break;
                case "Link3":
                    this.Link3 = (TextField)value;
                    break;
                case "Link5":
                    this.Link5 = (TextField)value;
                    break;
                case "Link4":
                    this.Link4 = (TextField)value;
                    break;
                case "style":
                    this.style = (TextField)value;
                    break;
                case "locale":
                    this.locale = (TextField)value;
                    break;
                default:
                    throw (new ArgumentOutOfRangeException());
            }
        }
    }

    public TextField user;
    public TextField Link1;
    public object Link1Href;
    public LinkParameterCollection Link1HrefParameters;
    public TextField Link2;
    public object Link2Href;
    public LinkParameterCollection Link2HrefParameters;
    public TextField Link3;
    public object Link3Href;
    public LinkParameterCollection Link3HrefParameters;
    public TextField Link5;
    public object Link5Href;
    public LinkParameterCollection Link5HrefParameters;
    public TextField Link4;
    public object Link4Href;
    public LinkParameterCollection Link4HrefParameters;
    public TextField style;
    public ItemCollection styleItems;
    public TextField locale;
    public ItemCollection localeItems;
    public PageItem()
    {
        user=new TextField("", null);
        Link1 = new TextField("",null);
        Link1HrefParameters = new LinkParameterCollection();
        Link2 = new TextField("",null);
        Link2HrefParameters = new LinkParameterCollection();
        Link3 = new TextField("",null);
        Link3HrefParameters = new LinkParameterCollection();
        Link5 = new TextField("",null);
        Link5HrefParameters = new LinkParameterCollection();
        Link4 = new TextField("",null);
        Link4HrefParameters = new LinkParameterCollection();
        style = new TextField("", null);
        styleItems = new ItemCollection();
        locale = new TextField("", null);
        localeItems = new ItemCollection();
    }
}
//End Page Data Class

//Page Data Provider Class @1-50FE4D41
public class PageDataProvider
{
//End Page Data Provider Class

//Page Data Provider Class Variables @1-A2943D20
     protected DataCommand styleDataCommand=new TableCommand("SELECT * \n" +
          "FROM styles {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
     protected DataCommand localeDataCommand=new TableCommand("SELECT * \n" +
          "FROM locales {SQL_Where} {SQL_OrderBy}", new string[]{},Settings.IMDataAccessObject);
//End Page Data Provider Class Variables

//Page Data Provider Class Constructor @1-9A44B219
    public PageDataProvider()
    {
    }
//End Page Data Provider Class Constructor

//Page Data Provider Class GetResultSet Method @1-ED273E78
    public void FillItem(PageItem item)
    {
        Exception E=null;
        DataRowCollection ListBoxSource=null;
//End Page Data Provider Class GetResultSet Method

//ListBox style Initialize Data Source @14-08D9727A
        int styletableIndex = 0;
        styleDataCommand.OrderBy = "";
        styleDataCommand.Parameters.Clear();
//End ListBox style Initialize Data Source

//ListBox style BeforeExecuteSelect @14-C0A9CC5C
        try{
            ListBoxSource=styleDataCommand.Execute().Tables[styletableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox style BeforeExecuteSelect

//ListBox style AfterExecuteSelect @14-E7FC4B1E
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["style_name"];
            string key = (new TextField("", ListBoxSource[li]["style_name"])).GetFormattedValue("");
            item.styleItems.Add(key,val);
        }
//End ListBox style AfterExecuteSelect

//ListBox locale Initialize Data Source @15-EFD0105C
        int localetableIndex = 0;
        localeDataCommand.OrderBy = "";
        localeDataCommand.Parameters.Clear();
//End ListBox locale Initialize Data Source

//ListBox locale BeforeExecuteSelect @15-563B8CC0
        try{
            ListBoxSource=localeDataCommand.Execute().Tables[localetableIndex].Rows;
        }catch(Exception e){
            E=e;}
        finally{
//End ListBox locale BeforeExecuteSelect

//ListBox locale AfterExecuteSelect @15-B20CBB33
            if(E!=null) throw(E);
        }
        for(int li=0;li<ListBoxSource.Count;li++){
            object val = ListBoxSource[li]["locale_name"];
            string key = (new TextField("", ListBoxSource[li]["locale_name"])).GetFormattedValue("");
            item.localeItems.Add(key,val);
        }
//End ListBox locale AfterExecuteSelect

//Page Data Provider Class GetResultSet Method tail @1-FCB6E20C
    }
//End Page Data Provider Class GetResultSet Method tail

//Page Data Provider class Tail @1-FCB6E20C
}
//End Page Data Provider class Tail

//Page Data Provider Tail 2 @1-FCB6E20C
}
//End Page Data Provider Tail 2

