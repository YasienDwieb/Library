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
	/// Represents the DataRepository.BookImageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(BookImageDataSourceDesigner))]
	public class BookImageDataSource : ProviderDataSource<BookImage, BookImageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageDataSource class.
		/// </summary>
		public BookImageDataSource() : base(DataRepository.BookImageProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the BookImageDataSourceView used by the BookImageDataSource.
		/// </summary>
		protected BookImageDataSourceView BookImageView
		{
			get { return ( View as BookImageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the BookImageDataSource control invokes to retrieve data.
		/// </summary>
		public BookImageSelectMethod SelectMethod
		{
			get
			{
				BookImageSelectMethod selectMethod = BookImageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (BookImageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the BookImageDataSourceView class that is to be
		/// used by the BookImageDataSource.
		/// </summary>
		/// <returns>An instance of the BookImageDataSourceView class.</returns>
		protected override BaseDataSourceView<BookImage, BookImageKey> GetNewDataSourceView()
		{
			return new BookImageDataSourceView(this, DefaultViewName);
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
	/// Supports the BookImageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class BookImageDataSourceView : ProviderDataSourceView<BookImage, BookImageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BookImageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BookImageDataSourceView(BookImageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal BookImageDataSource BookImageOwner
		{
			get { return Owner as BookImageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal BookImageSelectMethod SelectMethod
		{
			get { return BookImageOwner.SelectMethod; }
			set { BookImageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal BookImageProviderBase BookImageProvider
		{
			get { return Provider as BookImageProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<BookImage> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<BookImage> results = null;
			BookImage item;
			count = 0;
			
			System.Int32 _iD;

			switch ( SelectMethod )
			{
				case BookImageSelectMethod.Get:
					BookImageKey entityKey  = new BookImageKey();
					entityKey.Load(values);
					item = BookImageProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<BookImage>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case BookImageSelectMethod.GetAll:
                    results = BookImageProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case BookImageSelectMethod.GetPaged:
					results = BookImageProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case BookImageSelectMethod.Find:
					if ( FilterParameters != null )
						results = BookImageProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = BookImageProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case BookImageSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = BookImageProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<BookImage>();
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
			if ( SelectMethod == BookImageSelectMethod.Get || SelectMethod == BookImageSelectMethod.GetByID )
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
				BookImage entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					BookImageProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<BookImage> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			BookImageProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region BookImageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the BookImageDataSource class.
	/// </summary>
	public class BookImageDataSourceDesigner : ProviderDataSourceDesigner<BookImage, BookImageKey>
	{
		/// <summary>
		/// Initializes a new instance of the BookImageDataSourceDesigner class.
		/// </summary>
		public BookImageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BookImageSelectMethod SelectMethod
		{
			get { return ((BookImageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new BookImageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region BookImageDataSourceActionList

	/// <summary>
	/// Supports the BookImageDataSourceDesigner class.
	/// </summary>
	internal class BookImageDataSourceActionList : DesignerActionList
	{
		private BookImageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the BookImageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BookImageDataSourceActionList(BookImageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public BookImageSelectMethod SelectMethod
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

	#endregion BookImageDataSourceActionList
	
	#endregion BookImageDataSourceDesigner
	
	#region BookImageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the BookImageDataSource.SelectMethod property.
	/// </summary>
	public enum BookImageSelectMethod
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
	
	#endregion BookImageSelectMethod

	#region BookImageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageFilter : SqlFilter<BookImageColumn>
	{
	}
	
	#endregion BookImageFilter

	#region BookImageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageExpressionBuilder : SqlExpressionBuilder<BookImageColumn>
	{
	}
	
	#endregion BookImageExpressionBuilder	

	#region BookImageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;BookImageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageProperty : ChildEntityProperty<BookImageChildEntityTypes>
	{
	}
	
	#endregion BookImageProperty
}

