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
	/// Represents the DataRepository.Book_AuthorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(Book_AuthorDataSourceDesigner))]
	public class Book_AuthorDataSource : ProviderDataSource<Book_Author, Book_AuthorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorDataSource class.
		/// </summary>
		public Book_AuthorDataSource() : base(DataRepository.Book_AuthorProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the Book_AuthorDataSourceView used by the Book_AuthorDataSource.
		/// </summary>
		protected Book_AuthorDataSourceView Book_AuthorView
		{
			get { return ( View as Book_AuthorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the Book_AuthorDataSource control invokes to retrieve data.
		/// </summary>
		public Book_AuthorSelectMethod SelectMethod
		{
			get
			{
				Book_AuthorSelectMethod selectMethod = Book_AuthorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (Book_AuthorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the Book_AuthorDataSourceView class that is to be
		/// used by the Book_AuthorDataSource.
		/// </summary>
		/// <returns>An instance of the Book_AuthorDataSourceView class.</returns>
		protected override BaseDataSourceView<Book_Author, Book_AuthorKey> GetNewDataSourceView()
		{
			return new Book_AuthorDataSourceView(this, DefaultViewName);
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
	/// Supports the Book_AuthorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class Book_AuthorDataSourceView : ProviderDataSourceView<Book_Author, Book_AuthorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the Book_AuthorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public Book_AuthorDataSourceView(Book_AuthorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal Book_AuthorDataSource Book_AuthorOwner
		{
			get { return Owner as Book_AuthorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal Book_AuthorSelectMethod SelectMethod
		{
			get { return Book_AuthorOwner.SelectMethod; }
			set { Book_AuthorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal Book_AuthorProviderBase Book_AuthorProvider
		{
			get { return Provider as Book_AuthorProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Book_Author> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Book_Author> results = null;
			Book_Author item;
			count = 0;
			
			System.Int32 _book_ID;
			System.Int32 _author_ID;

			switch ( SelectMethod )
			{
				case Book_AuthorSelectMethod.Get:
					Book_AuthorKey entityKey  = new Book_AuthorKey();
					entityKey.Load(values);
					item = Book_AuthorProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Book_Author>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case Book_AuthorSelectMethod.GetAll:
                    results = Book_AuthorProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case Book_AuthorSelectMethod.GetPaged:
					results = Book_AuthorProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case Book_AuthorSelectMethod.Find:
					if ( FilterParameters != null )
						results = Book_AuthorProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = Book_AuthorProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case Book_AuthorSelectMethod.GetByBook_IDAuthor_ID:
					_book_ID = ( values["Book_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Book_ID"], typeof(System.Int32)) : (int)0;
					_author_ID = ( values["Author_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Author_ID"], typeof(System.Int32)) : (int)0;
					item = Book_AuthorProvider.GetByBook_IDAuthor_ID(GetTransactionManager(), _book_ID, _author_ID);
					results = new TList<Book_Author>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case Book_AuthorSelectMethod.GetByAuthor_ID:
					_author_ID = ( values["Author_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Author_ID"], typeof(System.Int32)) : (int)0;
					results = Book_AuthorProvider.GetByAuthor_ID(GetTransactionManager(), _author_ID, this.StartIndex, this.PageSize, out count);
					break;
				case Book_AuthorSelectMethod.GetByBook_ID:
					_book_ID = ( values["Book_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Book_ID"], typeof(System.Int32)) : (int)0;
					results = Book_AuthorProvider.GetByBook_ID(GetTransactionManager(), _book_ID, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
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
			if ( SelectMethod == Book_AuthorSelectMethod.Get || SelectMethod == Book_AuthorSelectMethod.GetByBook_IDAuthor_ID )
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
				Book_Author entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					Book_AuthorProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Book_Author> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			Book_AuthorProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region Book_AuthorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the Book_AuthorDataSource class.
	/// </summary>
	public class Book_AuthorDataSourceDesigner : ProviderDataSourceDesigner<Book_Author, Book_AuthorKey>
	{
		/// <summary>
		/// Initializes a new instance of the Book_AuthorDataSourceDesigner class.
		/// </summary>
		public Book_AuthorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Book_AuthorSelectMethod SelectMethod
		{
			get { return ((Book_AuthorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new Book_AuthorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region Book_AuthorDataSourceActionList

	/// <summary>
	/// Supports the Book_AuthorDataSourceDesigner class.
	/// </summary>
	internal class Book_AuthorDataSourceActionList : DesignerActionList
	{
		private Book_AuthorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the Book_AuthorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public Book_AuthorDataSourceActionList(Book_AuthorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public Book_AuthorSelectMethod SelectMethod
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

	#endregion Book_AuthorDataSourceActionList
	
	#endregion Book_AuthorDataSourceDesigner
	
	#region Book_AuthorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the Book_AuthorDataSource.SelectMethod property.
	/// </summary>
	public enum Book_AuthorSelectMethod
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
		/// Represents the GetByBook_IDAuthor_ID method.
		/// </summary>
		GetByBook_IDAuthor_ID,
		/// <summary>
		/// Represents the GetByAuthor_ID method.
		/// </summary>
		GetByAuthor_ID,
		/// <summary>
		/// Represents the GetByBook_ID method.
		/// </summary>
		GetByBook_ID
	}
	
	#endregion Book_AuthorSelectMethod

	#region Book_AuthorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorFilter : SqlFilter<Book_AuthorColumn>
	{
	}
	
	#endregion Book_AuthorFilter

	#region Book_AuthorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorExpressionBuilder : SqlExpressionBuilder<Book_AuthorColumn>
	{
	}
	
	#endregion Book_AuthorExpressionBuilder	

	#region Book_AuthorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;Book_AuthorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorProperty : ChildEntityProperty<Book_AuthorChildEntityTypes>
	{
	}
	
	#endregion Book_AuthorProperty
}

