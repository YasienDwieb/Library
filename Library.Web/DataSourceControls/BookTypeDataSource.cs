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
	/// Represents the DataRepository.BookTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BookTypeDataSourceDesigner))]
	public class BookTypeDataSource : ProviderDataSource<BookType, BookTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookTypeDataSource class.
		/// </summary>
		public BookTypeDataSource() : base(DataRepository.BookTypeProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BookTypeDataSourceView used by the BookTypeDataSource.
		/// </summary>
		protected BookTypeDataSourceView BookTypeView
		{
			get { return ( View as BookTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BookTypeDataSource control invokes to retrieve data.
		/// </summary>
		public BookTypeSelectMethod SelectMethod
		{
			get
			{
				BookTypeSelectMethod selectMethod = BookTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BookTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BookTypeDataSourceView class that is to be
		/// used by the BookTypeDataSource.
		/// </summary>
		/// <returns>An instance of the BookTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<BookType, BookTypeKey> GetNewDataSourceView()
		{
			return new BookTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the BookTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BookTypeDataSourceView : ProviderDataSourceView<BookType, BookTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BookTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BookTypeDataSourceView(BookTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BookTypeDataSource BookTypeOwner
		{
			get { return Owner as BookTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BookTypeSelectMethod SelectMethod
		{
			get { return BookTypeOwner.SelectMethod; }
			set { BookTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BookTypeProviderBase BookTypeProvider
		{
			get { return Provider as BookTypeProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BookType> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BookType> results = null;
			BookType item;
			count = 0;
			
			System.Int32 _iD;

			switch ( SelectMethod )
			{
				case BookTypeSelectMethod.Get:
					BookTypeKey entityKey  = new BookTypeKey();
					entityKey.Load(values);
					item = BookTypeProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<BookType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BookTypeSelectMethod.GetAll:
                    results = BookTypeProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case BookTypeSelectMethod.GetPaged:
					results = BookTypeProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BookTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = BookTypeProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BookTypeProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BookTypeSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = BookTypeProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<BookType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == BookTypeSelectMethod.Get || SelectMethod == BookTypeSelectMethod.GetByID )
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
				BookType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					BookTypeProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BookType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			BookTypeProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BookTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BookTypeDataSource class.
	/// </summary>
	public class BookTypeDataSourceDesigner : ProviderDataSourceDesigner<BookType, BookTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the BookTypeDataSourceDesigner class.
		/// </summary>
		public BookTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BookTypeSelectMethod SelectMethod
		{
			get { return ((BookTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BookTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BookTypeDataSourceActionList

	/// <summary>
	/// Supports the BookTypeDataSourceDesigner class.
	/// </summary>
	internal class BookTypeDataSourceActionList : DesignerActionList
	{
		private BookTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BookTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BookTypeDataSourceActionList(BookTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BookTypeSelectMethod SelectMethod
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

	#endregion BookTypeDataSourceActionList
	
	#endregion BookTypeDataSourceDesigner
	
	#region BookTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BookTypeDataSource.SelectMethod property.
	/// </summary>
	public enum BookTypeSelectMethod
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
		GetByID
	}
	
	#endregion BookTypeSelectMethod

	#region BookTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookTypeFilter : SqlFilter<BookTypeColumn>
	{
	}
	
	#endregion BookTypeFilter

	#region BookTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookTypeExpressionBuilder : SqlExpressionBuilder<BookTypeColumn>
	{
	}
	
	#endregion BookTypeExpressionBuilder	

	#region BookTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BookTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BookType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookTypeProperty : ChildEntityProperty<BookTypeChildEntityTypes>
	{
	}
	
	#endregion BookTypeProperty
}

