//Security Class @0-A8D1BC20
//Target Framework version is 2.0
using System;
using System.Data;
using System.Collections.Specialized;
using System.Web;
using IssueManager.Configuration;
using IssueManager.Data;

namespace IssueManager.Security
{
    public struct GroupRight
    {
    	public string GroupId;
    	public bool	Read;
    	public bool	Insert;
    	public bool	Update;
    	public bool	Delete;
    	public GroupRight(string groupId, bool read):this(groupId, read, false,	false, false)
    	{
    	}
    	public GroupRight(string groupId, bool read, bool insert, bool update, bool	delete)
    	{
    		GroupId	= groupId;
    		Read = read;
    		Insert = insert;
    		Update = update;
    		Delete = delete;
    	}
    }

    public class FormSupportedOperations
    {
    	private	bool _isSecured	= false;
    	private	GroupRight[] _rights;
    	private	enum AccessIdentifier {Read, Insert, Update, Delete};

    	private	bool _AllowRead = false;
    	private	bool _AllowInsert = false;
    	private	bool _AllowUpdate = false;
    	private	bool _AllowDelete = false;

    	private	bool AllowCheck(AccessIdentifier ai)
    	{
    		if (_rights	!= null) 
    		{
    			string[] id	= new string[_rights.Length];
    			for(int	i =	0;i	< _rights.Length; i++) id[i] = _rights[i].GroupId;
    			if(!DBUtility.AuthorizeUser(id)) return	false;
    			for	( int i	= _rights.Length-1 ; i >= 0	; i--)
    				if(
    					(DBUtility.IsGroupsNested && Int32.Parse(DBUtility.UserGroup) >= Int32.Parse(_rights[i].GroupId)) ||
    					(!DBUtility.IsGroupsNested && DBUtility.UserGroup == _rights[i].GroupId)
    					)
    				{
    					if(_rights[i].Read)	_AllowRead	= true;
    					if(_rights[i].Insert) _AllowInsert	= true;
    					if(_rights[i].Update) _AllowUpdate	= true;
    					if(_rights[i].Delete) _AllowDelete	= true;
    				}
    		} 
    		else 
    		{
    			if(_isSecured && !DBUtility.AuthorizeUser()) return	false;
    		}
    
    		switch (ai)
    		{
    			case AccessIdentifier.Read:
    				return _AllowRead;
    			case AccessIdentifier.Insert:
    				return _AllowInsert;
    			case AccessIdentifier.Update:
    				return _AllowUpdate;
    			case AccessIdentifier.Delete:
    				return _AllowDelete;
    			default: 
    				return false;
    		}
    	}

    	public FormSupportedOperations(params GroupRight[] rights)
    	{
    		_rights	= rights;
    	}

    	public FormSupportedOperations(bool	isSecured, bool	read, bool insert, bool	update,	bool delete)
    	{
    		_rights	= null;
    		_isSecured = isSecured;
    		_AllowRead   = read;
    		_AllowInsert = insert;
    		_AllowUpdate = update;
    		_AllowDelete = delete;
    	}

    	public bool	AllowRead
    	{
    		get
    		{
    			return AllowCheck(AccessIdentifier.Read);
    		}
    		set
    		{
    			_AllowRead	= value;
    		}
    	}

    	public bool	AllowInsert
    	{
    		get
    		{
    			return AllowCheck(AccessIdentifier.Insert);
    		}
    		set
    		{
    			_AllowInsert =	value;
    		}
    	}

    	public bool	AllowUpdate
    	{
    		get
    		{
    			return AllowCheck(AccessIdentifier.Update);
    		}
    		set
    		{
    			_AllowUpdate =	value;
    		}
    	}

    	public bool	AllowDelete
    	{
    		get
    		{
    			return AllowCheck(AccessIdentifier.Delete);
    		}
    		set
    		{
    			_AllowDelete =	value;
    		}
    	}

    	public bool	FullControl
    	{
    		get
    		{
    			return AllowRead && _AllowInsert && _AllowUpdate && _AllowDelete;
    		}
    		set
    		{
    			_AllowRead	= true;
    			_AllowInsert =	true;
    			_AllowUpdate =	true;
    			_AllowDelete =	true;
    		}
    	}

    	public bool	None
    	{
    		get
    		{
    			return !(AllowRead || _AllowInsert || _AllowUpdate || _AllowDelete);
    		}
    		set
    		{
    			_AllowRead	= false;
    			_AllowInsert =	false;
    			_AllowUpdate =	false;
    			_AllowDelete =	false;
    		}
    	}

    	public bool	Editable
    	{
    		get
    		{
    			return AllowInsert || _AllowUpdate || _AllowDelete;
    		}
    	}
    }
}
//End Security Class

