#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using Library.BLL;
using Library.DAL;
using Library.DAL.Bases;
#endregion

namespace Library.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AuthorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AuthorDataSourceDesigner))]
	public class AuthorDataSource : ProviderDataSource<Author, AuthorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorDataSource class.
		/// </summary>
		public AuthorDataSource() : base(DataRepository.AuthorProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AuthorDataSourceView used by the AuthorDataSource.
		/// </summary>
		protected AuthorDataSourceView AuthorView
		{
			get { return ( View as AuthorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AuthorDataSource control invokes to retrieve data.
		/// </summary>
		public AuthorSelectMethod SelectMethod
		{
			get
			{
				AuthorSelectMethod selectMethod = AuthorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AuthorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AuthorDataSourceView class that is to be
		/// used by the AuthorDataSource.
		/// </summary>
		/// <returns>An instance of the AuthorDataSourceView class.</returns>
		protected override BaseDataSourceView<Author, AuthorKey> GetNewDataSourceView()
		{
			return new AuthorDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the AuthorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AuthorDataSourceView : ProviderDataSourceView<Author, AuthorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AuthorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AuthorDataSourceView(AuthorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AuthorDataSource AuthorOwner
		{
			get { return Owner as AuthorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AuthorSelectMethod SelectMethod
		{
			get { return AuthorOwner.SelectMethod; }
			set { AuthorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AuthorProviderBase AuthorProvider
		{
			get { return Provider as AuthorProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Author> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Author> results = null;
			Author item;
			count = 0;
			
			System.Int32 _iD;
			System.Int32 _book_ID;

			switch ( SelectMethod )
			{
				case AuthorSelectMethod.Get:
					AuthorKey entityKey  = new AuthorKey();
					entityKey.Load(values);
					item = AuthorProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Author>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AuthorSelectMethod.GetAll:
                    results = AuthorProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case AuthorSelectMethod.GetPaged:
					results = AuthorProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AuthorSelectMethod.Find:
					if ( FilterParameters != null )
						results = AuthorProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AuthorProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AuthorSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = AuthorProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<Author>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case AuthorSelectMethod.GetByBook_IDFromBook_Author:
					_book_ID = ( values["Book_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Book_ID"], typeof(System.Int32)) : (int)0;
					results = AuthorProvider.GetByBook_IDFromBook_Author(GetTransactionManager(), _book_ID, this.StartIndex, this.PageSize, out count);
					break;
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AuthorSelectMethod.Get || SelectMethod == AuthorSelectMethod.GetByID )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Author entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					AuthorProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<Author> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			AuthorProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AuthorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AuthorDataSource class.
	/// </summary>
	public class AuthorDataSourceDesigner : ProviderDataSourceDesigner<Author, AuthorKey>
	{
		/// <summary>
		/// Initializes a new instance of the AuthorDataSourceDesigner class.
		/// </summary>
		public AuthorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AuthorSelectMethod SelectMethod
		{
			get { return ((AuthorDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new AuthorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AuthorDataSourceActionList

	/// <summary>
	/// Supports the AuthorDataSourceDesigner class.
	/// </summary>
	internal class AuthorDataSourceActionList : DesignerActionList
	{
		private AuthorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AuthorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AuthorDataSourceActionList(AuthorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AuthorSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion AuthorDataSourceActionList
	
	#endregion AuthorDataSourceDesigner
	
	#region AuthorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AuthorDataSource.SelectMethod property.
	/// </summary>
	public enum AuthorSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByID method.
		/// </summary>
		GetByID,
		/// <summary>
		/// Represents the GetByBook_IDFromBook_Author method.
		/// </summary>
		GetByBook_IDFromBook_Author
	}
	
	#endregion AuthorSelectMethod

	#region AuthorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorFilter : SqlFilter<AuthorColumn>
	{
	}
	
	#endregion AuthorFilter

	#region AuthorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorExpressionBuilder : SqlExpressionBuilder<AuthorColumn>
	{
	}
	
	#endregion AuthorExpressionBuilder	

	#region AuthorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AuthorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorProperty : ChildEntityProperty<AuthorChildEntityTypes>
	{
	}
	
	#endregion AuthorProperty
}

