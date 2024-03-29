﻿#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BLL;
using Library.DAL;
using Library.DAL.Bases;
#endregion

namespace Library.Web.Data
{
	/// <summary>
	/// Represents a business object that provides data to data-bound
	/// controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomDataSourceDesigner))]
	public class CustomDataSource : BaseDataSource<Object, Object>, ILinkedDataSource
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomDataSource class.
		/// </summary>
		public CustomDataSource()
		{
		}

		/// <summary>
		/// Initializes a new instance of the CustomDataSource class using
		/// the specified data provider.
		/// </summary>
		/// <param name="provider">The business object that provides data access methods.</param>
		/// <param name="entityType">The type of entity that is returned by the provider.</param>
		public CustomDataSource(Object provider, Type entityType)
		{
			Provider = provider;
			EntityType = entityType;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets a reference to the CustomDataSourceView used by the CustomDataSource.
		/// </summary>
		protected CustomDataSourceView EntityView
		{
			get { return ( View as CustomDataSourceView ); }
		}

		#region Provider

		/// <summary>
		/// Gets or sets the object that the CustomDataSource object represents.
		/// </summary>
		[Browsable(false)]
		public Object Provider
		{
			get { return EntityView.Provider; }
			set { EntityView.Provider = value; }
		}

		/// <summary>
		/// Gets or sets the name of the property of the Provider which holds
		/// a reference to an object instance that the CustomDataSource object represents.
		/// </summary>
		public String ProviderName
		{
			get { return TypeProperty; }
			set { TypeProperty = value; }
		}

		/// <summary>
		/// Gets or sets the name of the class that the CustomDataSource object represents.
		/// </summary>
		public String TypeName
		{
			get { return EntityView.TypeName; }
			set { EntityView.TypeName = value; }
		}

		/// <summary>
		/// Gets or sets the name of the property of the Provider which holds
		/// a reference to an object instance that the CustomDataSource object represents.
		/// </summary>
		public String TypeProperty
		{
			get { return EntityView.TypeProperty; }
			set { EntityView.TypeProperty = value; }
		}

		/// <summary>
		/// Gets or sets the name of the static property of the Provider which holds
		/// a reference to an object instance that the CustomDataSource object represents.
		/// </summary>
		public String TypeInstanceProperty
		{
			get { return EntityView.TypeInstanceProperty; }
			set { EntityView.TypeInstanceProperty = value; }
		}

		#endregion Provider

		#region Entity

		/// <summary>
		/// Gets or sets the System.Type of entity that is returned by the Provider.
		/// </summary>
		[Browsable(false)]
		public Type EntityType
		{
			get { return EntityView.EntityType; }
			set { EntityView.EntityType = value; }
		}

		/// <summary>
		/// Gets or set the name of the class of the entity that is returned by the Provider.
		/// </summary>
		public String EntityTypeName
		{
			get { return EntityView.EntityTypeName; }
			set { EntityView.EntityTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the System.Type of the primary key property of the entity.
		/// </summary>
		[Browsable(false)]
		public Type EntityKeyType
		{
			get { return EntityView.EntityKeyType; }
			set { EntityView.EntityKeyType = value; }
		}

		/// <summary>
		/// Gets or sets the name of the class of the primary key property of the entity.
		/// </summary>
		public String EntityKeyTypeName
		{
			get { return EntityView.EntityKeyTypeName; }
			set { EntityView.EntityKeyTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the name of the primary key property of the entity.
		/// </summary>
		public String EntityKeyNames
		{
			get { return EntityView.EntityKeyNames; }
			set { EntityView.EntityKeyNames = value; }
		}

		#endregion Entity

		#region Methods

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to retrieve data.
		/// </summary>
		public String SelectMethod
		{
			get { return ((String) ViewState["SelectMethod"]) ?? "GetAll"; }
			set { ViewState["SelectMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to insert data.
		/// </summary>
		public String InsertMethod
		{
			get { return ((String) ViewState["InsertMethod"]) ?? "Insert"; }
			set { ViewState["InsertMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to update data.
		/// </summary>
		public String UpdateMethod
		{
			get { return ((String) ViewState["UpdateMethod"]) ?? "Update"; }
			set { ViewState["UpdateMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to delete data.
		/// </summary>
		public String DeleteMethod
		{
			get { return ((String) ViewState["DeleteMethod"]) ?? "Delete"; }
			set { ViewState["DeleteMethod"] = value; }
		}

		#endregion Methods

		#endregion Properties

		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomDataSourceView class that is to be
		/// used by the CustomDataSource.
		/// </summary>
		/// <returns>An instance of the CustomDataSourceView class.</returns>
		/// <remarks>This method should be overridden by sub-classes who need to provide
		/// additional functionality through the use of a sub-classed CustomDataSourceView.</remarks>
		protected override BaseDataSourceView<Object, Object> GetNewDataSourceView()
		{
			return new CustomDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomDataSourceView : BaseDataSourceView<Object, Object>
	{
		#region Declarations

		private Object _provider;
		private Type _providerType = typeof(DataRepository);
		private Type _entityType;
		private Type _entityKeyType;

		private String _typeName;
		private String _typeProperty;
		private String _typeInstanceProperty;
		private String _entityTypeName;
		private String _entityKeyTypeName;
		private String _entityKeyNames;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomDataSourceView(CustomDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}

		#endregion Constructors

		#region Properties

		#region Provider

		/// <summary>
		/// Gets or sets the System.Type of the class that the CustomDataSource object represents.
		/// </summary>
		internal Type ProviderType
		{
			get
			{
				if ( _providerType == null )
				{
					_providerType = EntityUtil.GetType(TypeName);
				}

				return _providerType;
			}
			set { _providerType = value; }
		}

		/// <summary>
		/// Gets or sets the object that the CustomDataSource object represents.
		/// </summary>
		internal Object Provider
		{
			get
			{
				if ( _provider == null )
				{
					Type t = ProviderType;

					if ( String.IsNullOrEmpty(TypeProperty) )
					{
						_provider = EntityUtil.GetNewEntity(t);
					}
					else if ( String.IsNullOrEmpty(TypeInstanceProperty) )
					{
						_provider = EntityUtil.GetStaticPropertyValue(t, TypeProperty);
					}
					else
					{
						Object providerManager = EntityUtil.GetStaticPropertyValue(t, TypeInstanceProperty);
						_provider = EntityUtil.GetPropertyValue(providerManager, TypeProperty);
					}
				}

				return _provider;
			}
			set { _provider = value; }
		}

		/// <summary>
		/// Gets or sets the name of the class that the CustomDataSource object represents.
		/// </summary>
		internal String TypeName
		{
			get { return _typeName; }
			set
			{
				_providerType = null;
				_typeName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the property of the Provider which holds
		/// a reference to an object instance that the CustomDataSource object represents.
		/// </summary>
		internal String TypeProperty
		{
			get { return _typeProperty; }
			set { _typeProperty = value; }
		}

		/// <summary>
		/// Gets or sets the name of the static property of the Provider which holds
		/// a reference to an object instance that the CustomDataSource object represents.
		/// </summary>
		internal String TypeInstanceProperty
		{
			get { return _typeInstanceProperty; }
			set { _typeInstanceProperty = value; }
		}

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomDataSource ProviderOwner
		{
			get { return Owner as CustomDataSource; }
		}

		#endregion Provider

		#region Entity

		/// <summary>
		/// Gets or set the name of the class of the entity that is returned by the Provider.
		/// </summary>
		internal String EntityTypeName
		{
			get { return _entityTypeName; }
			set { _entityTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the System.Type of entity that is returned by the Provider.
		/// </summary>
		internal Type EntityType
		{
			get
			{
				if ( _entityType == null )
				{
					_entityType = EntityUtil.GetType(EntityTypeName);
				}

				return _entityType;
			}
			set
			{
				_entityType = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the class of the primary key property of the entity.
		/// </summary>
		internal String EntityKeyTypeName
		{
			get { return _entityKeyTypeName; }
			set { _entityKeyTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the System.Type of the primary key property of the entity.
		/// </summary>
		internal Type EntityKeyType
		{
			get
			{
				if ( _entityKeyType == null )
				{
					_entityKeyType = EntityUtil.GetType(EntityKeyTypeName);
				}

				return _entityKeyType;
			}
			set { _entityKeyType = value; }
		}

		/// <summary>
		/// Gets or sets the name of the primary key property of the entity.
		/// </summary>
		internal String EntityKeyNames
		{
			get { return _entityKeyNames; }
			set { _entityKeyNames = value; }
		}

		#endregion Entity

		#region Methods

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to retrieve data.
		/// </summary>
		internal String SelectMethod
		{
			get { return ProviderOwner.SelectMethod; }
			set { ProviderOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to insert data.
		/// </summary>
		internal String InsertMethod
		{
			get { return ProviderOwner.InsertMethod; }
			set { ProviderOwner.InsertMethod = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to update data.
		/// </summary>
		internal String UpdateMethod
		{
			get { return ProviderOwner.UpdateMethod; }
			set { ProviderOwner.UpdateMethod = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomDataSource control invokes to delete data.
		/// </summary>
		internal String DeleteMethod
		{
			get { return ProviderOwner.DeleteMethod; }
			set { ProviderOwner.DeleteMethod = value; }
		}

		#endregion

		#endregion Properties

		#region Select Methods

		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		/// <remarks>This method can be overridden by sub-classes needing to provide
		/// additional data retrieval functionality.</remarks>
		protected override IList<Object> GetSelectData(out int count)
		{
			IDictionary values = GetParameterValues();
			int countIndex = -1;
			int pos = 0;

			Object[] args = new Object[values.Count];
			Type[] types = new Type[values.Count];

			Object value;
			Type type;

			foreach ( DictionaryEntry e in values )
			{
				value = e.Value;
				type = e.Value.GetType();

				if ( "OrderByClause".Equals(e.Key) )
				{
					if ( EnableSorting )
					{
						value = SortExpression;
					}
				}
				else if ( "RecordCount".Equals(e.Key) )
				{
					type = EntityUtil.GetType("System.Int32&");
					countIndex = pos;

					// increment to account for TransactionManager argument
					if ( GetTransactionManager() != null )
					{
						countIndex++;
					}
				}
				else if ( "NullableRecordCount".Equals(e.Key) )
				{
					type = EntityUtil.GetType("System.Nullable`1[System.Int32]&");
					countIndex = pos;

					// increment to account for TransactionManager argument
					if ( GetTransactionManager() != null )
					{
						countIndex++;
					}
				}

				args[pos] = value;
				types[pos] = type;
				pos++;
			}

			args = GetArgs(args);
			types = GetTypes(types);

			// invoke method
			Object data = EntityUtil.InvokeMethod(Provider, SelectMethod, args, types);

			// make sure paging and sorting were not enabled
			if ( !EnablePaging && !EnableSorting )
			{
				// apply filter
				if ( !String.IsNullOrEmpty(Filter) )
				{
					EntityUtil.SetPropertyValue(data, "Filter", Filter);
				}
				// apply sort
				if ( !String.IsNullOrEmpty(Sort) )
				{
					EntityUtil.InvokeMethod(data, "Sort", new Object[] { Sort });
				}
			}
			
			// try to convert to IList<Object>
			IList<Object> list = data as IList<Object>;

			if ( list == null )
			{
				list = new List<Object>();

				if ( data != null )
				{
					IList dataList = data as IList;

					if ( dataList != null )
					{
						foreach ( Object item in dataList )
						{
							list.Add(item);
						}
					}
					else
					{
						list.Add(data);
					}
				}
			}

			// report RecordCount
			count = ( countIndex > -1 ) ? (int) args[countIndex] : list.Count;

			return list;
		}

		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
	    /// <param name="values"></param>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		/// <remarks>This method can be overridden by sub-classes needing to provide
		/// additional data retrieval functionality.</remarks>
		protected override IList<Object> GetSelectData(IDictionary values, out int count)
		{
			if (values == null || values.Count == 0) 
				values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());

			return GetSelectData(out count);
		}		
		
		#endregion Select Methods

		#region Insert Methods

		/// <summary>
		/// Performs an insert operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to insert.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteInsert(Object entity)
		{
			Object[] args = GetArgs(entity);
			Object result = EntityUtil.InvokeMethod(Provider, InsertMethod, args);
			return ( result == null || Convert.ToBoolean(result) );
		}

		#endregion Insert Methods

		#region Update Methods

		/// <summary>
		/// Performs an update operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteUpdate(Object entity)
		{
			Object[] args = GetArgs(entity);
			Object result = EntityUtil.InvokeMethod(Provider, UpdateMethod, args);
			return ( result == null || Convert.ToBoolean(result) );
		}

		#endregion UpdateMethods

		#region Delete Methods

		/// <summary>
		/// Performs a delete operation on the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to delete.</param>
		/// <returns>Returns true if successful, otherwise false.</returns>
		protected override bool ExecuteDelete(Object entity)
		{
			Object[] args = GetArgs(entity);
			Object result = EntityUtil.InvokeMethod(Provider, DeleteMethod, args);
			return ( result == null || Convert.ToBoolean(result) );
		}

		#endregion Delete Methods

		#region Helper Methods

		/// <summary>
		/// Gets the unique identifier of the specified entity object
		/// as an <see cref="IDictionary"/> object.
		/// </summary>
		/// <param name="entity">The current business object.</param>
		/// <returns>A collection of name/value pairs.</returns>
		protected override Object GetEntityId(Object entity)
		{
			IDictionary<String, Object> entityId = new Dictionary<String, Object>();
			String[] names = GetEntityKeyNames();
			Object value;

			if ( entity != null )
			{
				for ( int i = 0; i < names.Length; i++ )
				{
					value = EntityUtil.GetPropertyValue(entity, names[i]);
					entityId.Add(names[i], value);
				}
			}

			return entityId;
		}

		/// <summary>
		/// Gets an array of unique identifier property names.
		/// </summary>
		/// <returns>An array of property names.</returns>
		protected String[] GetEntityKeyNames()
		{
			return GetNames(EntityKeyNames);
		}

		/// <summary>
		/// Gets the Entity object within the collection of Entity objects that matches
		/// the values found in the specified IDictionary object.
		/// </summary>
		/// <param name="entityList">A collection of Entity objects.</param>
		/// <param name="keys">An IDictionary of name/value pairs representing a unique identifier.</param>
		/// <returns>The Entity object that matches the supplied unique identifier.</returns>
		protected override Object GetCurrentEntity(IList<Object> entityList, IDictionary keys)
		{
			// special processing when keys parameter is null
			if ( keys == null && entityList.Count == 1 )
			{
				return entityList[0];
			}

			Object currEntity = null;

			foreach ( Object entity in entityList )
			{
				currEntity = entity;

				foreach ( DictionaryEntry entry in keys )
				{
					if ( !EntityUtil.IsPropertyValueEqual(entity, entry.Key.ToString(), entry.Value) )
					{
						currEntity = null;
						break;
					}
				}
				if ( currEntity != null )
				{
					break;
				}
			}

			return currEntity;
		}

		/// <summary>
		/// Gets the Entity object within the collection of Entity objects that matches
		/// the values found in the specified entityKey object.
		/// </summary>
		/// <param name="entityList">A collection of Entity objects.</param>
		/// <param name="entityKey">The entity's unique identifier.</param>
		/// <returns></returns>
		protected override Object GetCurrentEntity(IList<Object> entityList, Object entityKey)
		{
			Object entity = null;

			if ( entityKey is IDictionary )
			{
				entity = GetCurrentEntity(entityList, entityKey as IDictionary);
			}

			return entity;
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Object entity)
		{
			base.SetEntityKeyValues(entity);
			String[] names = GetEntityKeyNames();

			foreach ( String name in names )
			{
				EntityUtil.SetEntityKeyValue(entity, name);
			}
		}

		/// <summary>
		/// Stores the specified entity in the temporary cache.
		/// </summary>
		/// <param name="entity">The Entity object to cache.</param>
		/// <param name="entityList">The list of Entity objects to cache.</param>
		protected override void SetTempCache(Object entity, out IList<Object> entityList)
		{
			entityList = new List<Object>();
			entityList.Add(entity);
		}

		/// <summary>
		/// Prepends a TransactionManager object to the supplied <paramref name="args"/> array
		/// if the EnableTransaction property is set to True.
		/// </summary>
		/// <param name="args">The values to be passed to a data access operation.</param>
		/// <returns>An array of method arguments.</returns>
		private Object[] GetArgs(params Object[] args)
		{
			ITransactionManager mgr = GetTransactionManager();

			if ( mgr != null )
			{
				Object[] newArgs = new Object[args.Length + 1];
				newArgs[0] = mgr;

				if ( args.Length > 0 )
				{
					args.CopyTo(newArgs, 1);
				}

				args = newArgs;
			}

			return args;
		}

		/// <summary>
		/// Prepends a System.Type object to the supplied <paramref name="types"/> array
		/// if the EnableTransaction property is set to True.
		/// </summary>
		/// <param name="types">The types to be passed to a data access operation.</param>
		/// <returns>An array of method argument types.</returns>
		private Type[] GetTypes(params Type[] types)
		{
			if ( GetTransactionManager() != null )
			{
				Type[] newTypes = new Type[types.Length + 1];
				newTypes[0] = typeof(ITransactionManager);

				if ( types.Length > 0 )
				{
					types.CopyTo(newTypes, 1);
				}

				types = newTypes;
			}

			return types;
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Object entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					Object[] args = GetArgs(entity, EnableRecursiveDeepLoad);
					EntityUtil.InvokeMethod(Provider, "DeepLoad", args);
					IsDeepLoaded = true;
				}
			}
		}

		#endregion Helper Methods
	}
}
