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
	/// Represents the DataRepository.CourseProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CourseDataSourceDesigner))]
	public class CourseDataSource : ProviderDataSource<Course, CourseKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDataSource class.
		/// </summary>
		public CourseDataSource() : base(DataRepository.CourseProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CourseDataSourceView used by the CourseDataSource.
		/// </summary>
		protected CourseDataSourceView CourseView
		{
			get { return ( View as CourseDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CourseDataSource control invokes to retrieve data.
		/// </summary>
		public CourseSelectMethod SelectMethod
		{
			get
			{
				CourseSelectMethod selectMethod = CourseSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CourseSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CourseDataSourceView class that is to be
		/// used by the CourseDataSource.
		/// </summary>
		/// <returns>An instance of the CourseDataSourceView class.</returns>
		protected override BaseDataSourceView<Course, CourseKey> GetNewDataSourceView()
		{
			return new CourseDataSourceView(this, DefaultViewName);
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
	/// Supports the CourseDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CourseDataSourceView : ProviderDataSourceView<Course, CourseKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CourseDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CourseDataSourceView(CourseDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CourseDataSource CourseOwner
		{
			get { return Owner as CourseDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CourseSelectMethod SelectMethod
		{
			get { return CourseOwner.SelectMethod; }
			set { CourseOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CourseProviderBase CourseProvider
		{
			get { return Provider as CourseProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Course> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Course> results = null;
			Course item;
			count = 0;
			
			System.Int32 _iD;

			switch ( SelectMethod )
			{
				case CourseSelectMethod.Get:
					CourseKey entityKey  = new CourseKey();
					entityKey.Load(values);
					item = CourseProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Course>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CourseSelectMethod.GetAll:
                    results = CourseProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case CourseSelectMethod.GetPaged:
					results = CourseProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CourseSelectMethod.Find:
					if ( FilterParameters != null )
						results = CourseProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CourseProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CourseSelectMethod.GetByID:
					_iD = ( values["ID"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ID"], typeof(System.Int32)) : (int)0;
					item = CourseProvider.GetByID(GetTransactionManager(), _iD);
					results = new TList<Course>();
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
			if ( SelectMethod == CourseSelectMethod.Get || SelectMethod == CourseSelectMethod.GetByID )
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
				Course entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					CourseProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Course> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			CourseProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CourseDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CourseDataSource class.
	/// </summary>
	public class CourseDataSourceDesigner : ProviderDataSourceDesigner<Course, CourseKey>
	{
		/// <summary>
		/// Initializes a new instance of the CourseDataSourceDesigner class.
		/// </summary>
		public CourseDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseSelectMethod SelectMethod
		{
			get { return ((CourseDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CourseDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CourseDataSourceActionList

	/// <summary>
	/// Supports the CourseDataSourceDesigner class.
	/// </summary>
	internal class CourseDataSourceActionList : DesignerActionList
	{
		private CourseDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CourseDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CourseDataSourceActionList(CourseDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseSelectMethod SelectMethod
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

	#endregion CourseDataSourceActionList
	
	#endregion CourseDataSourceDesigner
	
	#region CourseSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CourseDataSource.SelectMethod property.
	/// </summary>
	public enum CourseSelectMethod
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
	
	#endregion CourseSelectMethod

	#region CourseFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseFilter : SqlFilter<CourseColumn>
	{
	}
	
	#endregion CourseFilter

	#region CourseExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseExpressionBuilder : SqlExpressionBuilder<CourseColumn>
	{
	}
	
	#endregion CourseExpressionBuilder	

	#region CourseProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CourseChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseProperty : ChildEntityProperty<CourseChildEntityTypes>
	{
	}
	
	#endregion CourseProperty
}

