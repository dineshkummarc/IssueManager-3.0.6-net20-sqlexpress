//ParameterCollection class @1-159DFA4C
//Target Framework version is 2.0
using System;
using System.Collections;
using System.Collections.Specialized;


namespace IssueManager.Data
{
	public class ParameterCollection : NameObjectCollectionBase  
	{

		private DictionaryEntry _de = new DictionaryEntry();

		public ParameterCollection()  
		{
		}

		public ParameterCollection( IDictionary d, Boolean bReadOnly )  
		{
			foreach ( DictionaryEntry de in d )  
			{
				this.BaseAdd( (String) de.Key, de.Value );
			}
			this.IsReadOnly = bReadOnly;
		}

		public DictionaryEntry this[ int index ]  
		{
			get  
			{
				_de.Key = this.BaseGetKey(index);
				_de.Value = this.BaseGet(index);
				return( _de );
			}
		}

		public Object this[ String key ]  
		{
			get  
			{
				return( this.BaseGet( key ) );
			}
			set  
			{
				this.BaseSet( key, value );
			}
		}

		public String[] AllKeys  
		{
			get  
			{
				return( this.BaseGetAllKeys() );
			}
		}

		public Array AllValues  
		{
			get  
			{
				return( this.BaseGetAllValues() );
			}
		}

		public String[] AllStringValues  
		{
			get  
			{
				return( (String[]) this.BaseGetAllValues( Type.GetType( "System.String" ) ) );
			}
		}

		public Boolean HasKeys  
		{
			get  
			{
				return( this.BaseHasKeys() );
			}
		}

		public void Add( String key, Object value )  
		{
			this.BaseAdd( key, value );
		}

		public void Remove( String key )  
		{
			this.BaseRemove( key );
		}

		public void Remove( int index )  
		{
			this.BaseRemoveAt( index );
		}

		public void Clear()  
		{
			this.BaseClear();
		}

	}
}

//End ParameterCollection class

