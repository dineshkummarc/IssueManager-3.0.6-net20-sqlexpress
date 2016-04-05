//CodeCharge.Data.WhereBuilder Cclass @0-273DE13D
//Target Framework version is 2.0
using System;
using System.Data;

namespace IssueManager.Data
{
  public class WhereBuilder
  {
    private System.Collections.Queue elements;

    public WhereBuilder(params string[] parameters)
    {
      elements=new System.Collections.Queue(parameters);
      elements.Enqueue("");elements.Enqueue("");elements.Enqueue("");elements.Enqueue("");elements.Enqueue("");
    }

    public string GetWhere()
    {
      string first="";
      string op="";
      string second="";
      bool UsePrevOp=false;
      while(elements.Count>3){
        if(first==""){
          first=(string)elements.Dequeue();
          if(first=="("){
            first=GetWhere();
            if(first!="") first="("+first+")";
          }
        }
        op=UsePrevOp==true?op:(string)elements.Dequeue();
		if(op==")") return first;
        UsePrevOp=false;
        second=(string)elements.Dequeue();
        if(second=="("){
          second=GetWhere();
          if(second!="")
          second="("+second+")";
        }
        if(first.Trim()!=""&&second!="")
          first+=" "+op+" "+second;
        else{
          string Peek=(string)elements.Peek();
          if(first.Trim()==""&&second!="") first+=" "+second;
          if(first.Trim()!=""&&second==""&&Peek=="And") {UsePrevOp=true;elements.Dequeue();}
          if(first==""&&second==""&&Peek!=")") {first+=" ";}
        }
        if((string)elements.Peek()==")"){elements.Dequeue();return first.Trim();}
      }
	  if(first.Trim()==")") first="";
      return first.Trim();
    }
  }
}
//End CodeCharge.Data.WhereBuilder Cclass

