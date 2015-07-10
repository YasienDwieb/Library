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
	/// Represents the DataRepository.PublisherProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PublisherDataSourceDesigner))]
	public class PublisherDataSource : ProviderDataSource<Publisher, PublisherKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherDataSource class.
		/// </summary>
		public PublisherDataSource() : base(DataRepository.PublisherProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PublisherDataSourceView used by the PublisherDataSource.
		/// </summary>
		protected PublisherDataSourceView PublisherView
		{
			get { return ( View as PublisherDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PublisherDataSource control invokes to retrieve data.
		/// </summary>
		public PublisherSelectMethod SelectMethod
		{
			get
			{
				PublisherSelectMethod selectMethod = PublisherSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PublisherSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PublisherDataSourceView class that is to be
		/// used by the PublisherDataSource.
		/// </summary>
		/// <returns>An instance of the PublisherDataSourceView class.</returns>
		protected override BaseDataSourceView<Publisher, PublisherKey> GetNewDataSourceView()
		{
			return new PublisherDataSourceView(this, DefaultViewName);
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
	/// Supports the PublisherDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PublisherDataSourceView : ProviderDataSourceView<Publisher, PublisherKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PublisherDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PublisherDataSourceView(PublisherDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PublisherDataSource PublisherOwner
		{
			get { return Owner as PublisherDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PublisherSelectMethod SelectMethod
		{
			get { return PublisherOwner.SelectMethod; }
			set { PublisherOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PublisherProviderBase PublisherProvider
		{
			get { return Provider as PublisherProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Publisher> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Publisher> results = null;
			Publisher item;
			count = 0;
			
			System.Int32 _iD;

			switch ( SelectMethod )
			{
				case PublisherSelectMethod.Get:
					PublisherKey entityKey  = new PublisherKey();
					entityKey.Load(values);
					item = PublisherProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Publisher>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PublisherSelectMethod.GetAll:
                    results = PublisherProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case PublisherSelectMethod.GetPaged:
					results = PublisherProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PublisherSelectMethod.Find:
					if ( FilterParameters != null )
						results = PublisherProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PublisherProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PublisherSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = PublisherProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<Publisher>();
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
			if ( SelectMethod == PublisherSelectMethod.Get || SelectMethod == PublisherSelectMethod.GetByID )
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
				Publisher entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					PublisherProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Publisher> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			PublisherProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PublisherDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PublisherDataSource class.
	/// </summary>
	public class PublisherDataSourceDesigner : ProviderDataSourceDesigner<Publisher, PublisherKey>
	{
		/// <summary>
		/// Initializes a new instance of the PublisherDataSourceDesigner class.
		/// </summary>
		public PublisherDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PublisherSelectMethod SelectMethod
		{
			get { return ((PublisherDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PublisherDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PublisherDataSourceActionList

	/// <summary>
	/// Supports the PublisherDataSourceDesigner class.
	/// </summary>
	internal class PublisherDataSourceActionList : DesignerActionList
	{
		private PublisherDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PublisherDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PublisherDataSourceActionList(PublisherDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PublisherSelectMethod SelectMethod
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

	#endregion PublisherDataSourceActionList
	
	#endregion PublisherDataSourceDesigner
	
	#region PublisherSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PublisherDataSource.SelectMethod property.
	/// </summary>
	public enum PublisherSelectMethod
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
	
	#endregion PublisherSelectMethod

	#region PublisherFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherFilter : SqlFilter<PublisherColumn>
	{
	}
	
	#endregion PublisherFilter

	#region PublisherExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherExpressionBuilder : SqlExpressionBuilder<PublisherColumn>
	{
	}
	
	#endregion PublisherExpressionBuilder	

	#region PublisherProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PublisherChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherProperty : ChildEntityProperty<PublisherChildEntityTypes>
	{
	}
	
	#endregion PublisherProperty
}

