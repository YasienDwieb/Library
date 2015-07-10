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
	/// Represents the DataRepository.IntroducerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(IntroducerDataSourceDesigner))]
	public class IntroducerDataSource : ProviderDataSource<Introducer, IntroducerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerDataSource class.
		/// </summary>
		public IntroducerDataSource() : base(DataRepository.IntroducerProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the IntroducerDataSourceView used by the IntroducerDataSource.
		/// </summary>
		protected IntroducerDataSourceView IntroducerView
		{
			get { return ( View as IntroducerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the IntroducerDataSource control invokes to retrieve data.
		/// </summary>
		public IntroducerSelectMethod SelectMethod
		{
			get
			{
				IntroducerSelectMethod selectMethod = IntroducerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (IntroducerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the IntroducerDataSourceView class that is to be
		/// used by the IntroducerDataSource.
		/// </summary>
		/// <returns>An instance of the IntroducerDataSourceView class.</returns>
		protected override BaseDataSourceView<Introducer, IntroducerKey> GetNewDataSourceView()
		{
			return new IntroducerDataSourceView(this, DefaultViewName);
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
	/// Supports the IntroducerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class IntroducerDataSourceView : ProviderDataSourceView<Introducer, IntroducerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the IntroducerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public IntroducerDataSourceView(IntroducerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal IntroducerDataSource IntroducerOwner
		{
			get { return Owner as IntroducerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal IntroducerSelectMethod SelectMethod
		{
			get { return IntroducerOwner.SelectMethod; }
			set { IntroducerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal IntroducerProviderBase IntroducerProvider
		{
			get { return Provider as IntroducerProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Introducer> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Introducer> results = null;
			Introducer item;
			count = 0;
			
			System.Int32 _iD;

			switch ( SelectMethod )
			{
				case IntroducerSelectMethod.Get:
					IntroducerKey entityKey  = new IntroducerKey();
					entityKey.Load(values);
					item = IntroducerProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Introducer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case IntroducerSelectMethod.GetAll:
                    results = IntroducerProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case IntroducerSelectMethod.GetPaged:
					results = IntroducerProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case IntroducerSelectMethod.Find:
					if ( FilterParameters != null )
						results = IntroducerProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = IntroducerProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case IntroducerSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = IntroducerProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<Introducer>();
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
			if ( SelectMethod == IntroducerSelectMethod.Get || SelectMethod == IntroducerSelectMethod.GetByID )
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
				Introducer entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					IntroducerProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Introducer> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			IntroducerProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region IntroducerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the IntroducerDataSource class.
	/// </summary>
	public class IntroducerDataSourceDesigner : ProviderDataSourceDesigner<Introducer, IntroducerKey>
	{
		/// <summary>
		/// Initializes a new instance of the IntroducerDataSourceDesigner class.
		/// </summary>
		public IntroducerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IntroducerSelectMethod SelectMethod
		{
			get { return ((IntroducerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new IntroducerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region IntroducerDataSourceActionList

	/// <summary>
	/// Supports the IntroducerDataSourceDesigner class.
	/// </summary>
	internal class IntroducerDataSourceActionList : DesignerActionList
	{
		private IntroducerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the IntroducerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public IntroducerDataSourceActionList(IntroducerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public IntroducerSelectMethod SelectMethod
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

	#endregion IntroducerDataSourceActionList
	
	#endregion IntroducerDataSourceDesigner
	
	#region IntroducerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the IntroducerDataSource.SelectMethod property.
	/// </summary>
	public enum IntroducerSelectMethod
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
	
	#endregion IntroducerSelectMethod

	#region IntroducerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerFilter : SqlFilter<IntroducerColumn>
	{
	}
	
	#endregion IntroducerFilter

	#region IntroducerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerExpressionBuilder : SqlExpressionBuilder<IntroducerColumn>
	{
	}
	
	#endregion IntroducerExpressionBuilder	

	#region IntroducerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;IntroducerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerProperty : ChildEntityProperty<IntroducerChildEntityTypes>
	{
	}
	
	#endregion IntroducerProperty
}

