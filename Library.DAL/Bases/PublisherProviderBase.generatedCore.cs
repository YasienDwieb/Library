#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Library.BLL;
using Library.DAL;

#endregion

namespace Library.DAL.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="PublisherProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PublisherProviderBaseCore : EntityProviderBase<Library.BLL.Publisher, Library.BLL.PublisherKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Library.BLL.PublisherKey key)
		{
			return Delete(transactionManager, key.ID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_iD">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _iD)
		{
			return Delete(null, _iD);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _iD);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override Library.BLL.Publisher Get(TransactionManager transactionManager, Library.BLL.PublisherKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Publishers index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Publisher"/> class.</returns>
		public Library.BLL.Publisher GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Publishers index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Publisher"/> class.</returns>
		public Library.BLL.Publisher GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Publishers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Publisher"/> class.</returns>
		public Library.BLL.Publisher GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Publishers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Publisher"/> class.</returns>
		public Library.BLL.Publisher GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Publishers index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Publisher"/> class.</returns>
		public Library.BLL.Publisher GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Publishers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Publisher"/> class.</returns>
		public abstract Library.BLL.Publisher GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Publisher&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Publisher&gt;"/></returns>
		public static TList<Publisher> Fill(IDataReader reader, TList<Publisher> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				Library.BLL.Publisher c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Publisher")
					.Append("|").Append((System.Int32)reader[((int)PublisherColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Publisher>(
					key.ToString(), // EntityTrackingKey
					"Publisher",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Publisher();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.ID = (System.Int32)reader[((int)PublisherColumn.ID - 1)];
					c.Name = (System.String)reader[((int)PublisherColumn.Name - 1)];
					c.Mobile = (reader.IsDBNull(((int)PublisherColumn.Mobile - 1)))?null:(System.String)reader[((int)PublisherColumn.Mobile - 1)];
					c.Email = (reader.IsDBNull(((int)PublisherColumn.Email - 1)))?null:(System.String)reader[((int)PublisherColumn.Email - 1)];
					c.Website = (reader.IsDBNull(((int)PublisherColumn.Website - 1)))?null:(System.String)reader[((int)PublisherColumn.Website - 1)];
					c.FounedOn = (reader.IsDBNull(((int)PublisherColumn.FounedOn - 1)))?null:(System.DateTime?)reader[((int)PublisherColumn.FounedOn - 1)];
					c.Country = (reader.IsDBNull(((int)PublisherColumn.Country - 1)))?null:(System.String)reader[((int)PublisherColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)PublisherColumn.City - 1)))?null:(System.String)reader[((int)PublisherColumn.City - 1)];
					c.Address = (reader.IsDBNull(((int)PublisherColumn.Address - 1)))?null:(System.String)reader[((int)PublisherColumn.Address - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Publisher"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Publisher"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Publisher entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)PublisherColumn.ID - 1)];
			entity.Name = (System.String)reader[((int)PublisherColumn.Name - 1)];
			entity.Mobile = (reader.IsDBNull(((int)PublisherColumn.Mobile - 1)))?null:(System.String)reader[((int)PublisherColumn.Mobile - 1)];
			entity.Email = (reader.IsDBNull(((int)PublisherColumn.Email - 1)))?null:(System.String)reader[((int)PublisherColumn.Email - 1)];
			entity.Website = (reader.IsDBNull(((int)PublisherColumn.Website - 1)))?null:(System.String)reader[((int)PublisherColumn.Website - 1)];
			entity.FounedOn = (reader.IsDBNull(((int)PublisherColumn.FounedOn - 1)))?null:(System.DateTime?)reader[((int)PublisherColumn.FounedOn - 1)];
			entity.Country = (reader.IsDBNull(((int)PublisherColumn.Country - 1)))?null:(System.String)reader[((int)PublisherColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)PublisherColumn.City - 1)))?null:(System.String)reader[((int)PublisherColumn.City - 1)];
			entity.Address = (reader.IsDBNull(((int)PublisherColumn.Address - 1)))?null:(System.String)reader[((int)PublisherColumn.Address - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Publisher"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Publisher"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Publisher entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Mobile = Convert.IsDBNull(dataRow["Mobile"]) ? null : (System.String)dataRow["Mobile"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Website = Convert.IsDBNull(dataRow["Website"]) ? null : (System.String)dataRow["Website"];
			entity.FounedOn = Convert.IsDBNull(dataRow["FounedOn"]) ? null : (System.DateTime?)dataRow["FounedOn"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Library.BLL.Publisher"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Publisher Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Publisher entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region BookCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Book>|BookCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BookCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.BookCollection = DataRepository.BookProvider.GetByPublisher_ID(transactionManager, entity.ID);

				if (deep && entity.BookCollection.Count > 0)
				{
					deepHandles.Add("BookCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Book>) DataRepository.BookProvider.DeepLoad,
						new object[] { transactionManager, entity.BookCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Library.BLL.Publisher object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Publisher instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Publisher Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Publisher entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Book>
				if (CanDeepSave(entity.BookCollection, "List<Book>|BookCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Book child in entity.BookCollection)
					{
						if(child.Publisher_IDSource != null)
						{
							child.Publisher_ID = child.Publisher_IDSource.ID;
						}
						else
						{
							child.Publisher_ID = entity.ID;
						}

					}

					if (entity.BookCollection.Count > 0 || entity.BookCollection.DeletedItems.Count > 0)
					{
						//DataRepository.BookProvider.Save(transactionManager, entity.BookCollection);
						
						deepHandles.Add("BookCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Book >) DataRepository.BookProvider.DeepSave,
							new object[] { transactionManager, entity.BookCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region PublisherChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Publisher</c>
	///</summary>
	public enum PublisherChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Publisher</c> as OneToMany for BookCollection
		///</summary>
		[ChildEntityType(typeof(TList<Book>))]
		BookCollection,
	}
	
	#endregion PublisherChildEntityTypes
	
	#region PublisherFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PublisherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherFilterBuilder : SqlFilterBuilder<PublisherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherFilterBuilder class.
		/// </summary>
		public PublisherFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PublisherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PublisherFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PublisherFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PublisherFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PublisherFilterBuilder
	
	#region PublisherParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PublisherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherParameterBuilder : ParameterizedSqlFilterBuilder<PublisherColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherParameterBuilder class.
		/// </summary>
		public PublisherParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PublisherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PublisherParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PublisherParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PublisherParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PublisherParameterBuilder
	
	#region PublisherSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PublisherColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PublisherSortBuilder : SqlSortBuilder<PublisherColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherSqlSortBuilder class.
		/// </summary>
		public PublisherSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PublisherSortBuilder
	
} // end namespace
