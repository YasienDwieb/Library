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
	/// Represents the DataRepository.BookProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BookDataSourceDesigner))]
	public class BookDataSource : ProviderDataSource<Book, BookKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookDataSource class.
		/// </summary>
		public BookDataSource() : base(DataRepository.BookProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BookDataSourceView used by the BookDataSource.
		/// </summary>
		protected BookDataSourceView BookView
		{
			get { return ( View as BookDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BookDataSource control invokes to retrieve data.
		/// </summary>
		public BookSelectMethod SelectMethod
		{
			get
			{
				BookSelectMethod selectMethod = BookSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BookSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BookDataSourceView class that is to be
		/// used by the BookDataSource.
		/// </summary>
		/// <returns>An instance of the BookDataSourceView class.</returns>
		protected override BaseDataSourceView<Book, BookKey> GetNewDataSourceView()
		{
			return new BookDataSourceView(this, DefaultViewName);
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
	/// Supports the BookDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BookDataSourceView : ProviderDataSourceView<Book, BookKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BookDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BookDataSourceView(BookDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BookDataSource BookOwner
		{
			get { return Owner as BookDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BookSelectMethod SelectMethod
		{
			get { return BookOwner.SelectMethod; }
			set { BookOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BookProviderBase BookProvider
		{
			get { return Provider as BookProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Book> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Book> results = null;
			Book item;
			count = 0;
			
			System.Int32 _iD;
			System.Int32 _type_ID;
			System.Int32 _employeeI_D;
			System.Int32 _image_ID;
			System.Int32? _introducer_ID_nullable;
			System.Int32 _publisher_ID;
			System.Int32 _author_ID;

			switch ( SelectMethod )
			{
				case BookSelectMethod.Get:
					BookKey entityKey  = new BookKey();
					entityKey.Load(values);
					item = BookProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Book>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BookSelectMethod.GetAll:
                    results = BookProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case BookSelectMethod.GetPaged:
					results = BookProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BookSelectMethod.Find:
					if ( FilterParameters != null )
						results = BookProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BookProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BookSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = BookProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<Book>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case BookSelectMethod.GetByType_ID:
					_type_ID = ( values["Type_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Type_ID"], typeof(System.Int32)) : (int)0;
					results = BookProvider.GetByType_ID(GetTransactionManager(), _type_ID, this.StartIndex, this.PageSize, out count);
					break;
				case BookSelectMethod.GetByEmployeeI_D:
					_employeeI_D = ( values["EmployeeI_D"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmployeeI_D"], typeof(System.Int32)) : (int)0;
					results = BookProvider.GetByEmployeeI_D(GetTransactionManager(), _employeeI_D, this.StartIndex, this.PageSize, out count);
					break;
				case BookSelectMethod.GetByImage_ID:
					_image_ID = ( values["Image_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Image_ID"], typeof(System.Int32)) : (int)0;
					results = BookProvider.GetByImage_ID(GetTransactionManager(), _image_ID, this.StartIndex, this.PageSize, out count);
					break;
				case BookSelectMethod.GetByIntroducer_ID:
					_introducer_ID_nullable = (System.Int32?) EntityUtil.ChangeType(values["Introducer_ID"], typeof(System.Int32?));
					results = BookProvider.GetByIntroducer_ID(GetTransactionManager(), _introducer_ID_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case BookSelectMethod.GetByPublisher_ID:
					_publisher_ID = ( values["Publisher_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Publisher_ID"], typeof(System.Int32)) : (int)0;
					results = BookProvider.GetByPublisher_ID(GetTransactionManager(), _publisher_ID, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case BookSelectMethod.GetByAuthor_IDFromBook_Author:
					_author_ID = ( values["Author_ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Author_ID"], typeof(System.Int32)) : (int)0;
					results = BookProvider.GetByAuthor_IDFromBook_Author(GetTransactionManager(), _author_ID, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == BookSelectMethod.Get || SelectMethod == BookSelectMethod.GetByID )
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
				Book entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					BookProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Book> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			BookProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BookDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BookDataSource class.
	/// </summary>
	public class BookDataSourceDesigner : ProviderDataSourceDesigner<Book, BookKey>
	{
		/// <summary>
		/// Initializes a new instance of the BookDataSourceDesigner class.
		/// </summary>
		public BookDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BookSelectMethod SelectMethod
		{
			get { return ((BookDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BookDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BookDataSourceActionList

	/// <summary>
	/// Supports the BookDataSourceDesigner class.
	/// </summary>
	internal class BookDataSourceActionList : DesignerActionList
	{
		private BookDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BookDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BookDataSourceActionList(BookDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BookSelectMethod SelectMethod
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

	#endregion BookDataSourceActionList
	
	#endregion BookDataSourceDesigner
	
	#region BookSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BookDataSource.SelectMethod property.
	/// </summary>
	public enum BookSelectMethod
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
		/// Represents the GetByType_ID method.
		/// </summary>
		GetByType_ID,
		/// <summary>
		/// Represents the GetByEmployeeI_D method.
		/// </summary>
		GetByEmployeeI_D,
		/// <summary>
		/// Represents the GetByImage_ID method.
		/// </summary>
		GetByImage_ID,
		/// <summary>
		/// Represents the GetByIntroducer_ID method.
		/// </summary>
		GetByIntroducer_ID,
		/// <summary>
		/// Represents the GetByPublisher_ID method.
		/// </summary>
		GetByPublisher_ID,
		/// <summary>
		/// Represents the GetByAuthor_IDFromBook_Author method.
		/// </summary>
		GetByAuthor_IDFromBook_Author
	}
	
	#endregion BookSelectMethod

	#region BookFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookFilter : SqlFilter<BookColumn>
	{
	}
	
	#endregion BookFilter

	#region BookExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookExpressionBuilder : SqlExpressionBuilder<BookColumn>
	{
	}
	
	#endregion BookExpressionBuilder	

	#region BookProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BookChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookProperty : ChildEntityProperty<BookChildEntityTypes>
	{
	}
	
	#endregion BookProperty
}

