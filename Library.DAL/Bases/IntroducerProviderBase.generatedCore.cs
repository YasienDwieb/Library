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
	/// This class is the base class for any <see cref="IntroducerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class IntroducerProviderBaseCore : EntityProviderBase<Library.BLL.Introducer, Library.BLL.IntroducerKey>
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
		public override bool Delete(TransactionManager transactionManager, Library.BLL.IntroducerKey key)
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
		public override Library.BLL.Introducer Get(TransactionManager transactionManager, Library.BLL.IntroducerKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Introducer index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Introducer"/> class.</returns>
		public Library.BLL.Introducer GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Introducer index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Introducer"/> class.</returns>
		public Library.BLL.Introducer GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Introducer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Introducer"/> class.</returns>
		public Library.BLL.Introducer GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Introducer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Introducer"/> class.</returns>
		public Library.BLL.Introducer GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Introducer index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Introducer"/> class.</returns>
		public Library.BLL.Introducer GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Introducer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Introducer"/> class.</returns>
		public abstract Library.BLL.Introducer GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Introducer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Introducer&gt;"/></returns>
		public static TList<Introducer> Fill(IDataReader reader, TList<Introducer> rows, int start, int pageLength)
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
				
				Library.BLL.Introducer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Introducer")
					.Append("|").Append((System.Int32)reader[((int)IntroducerColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Introducer>(
					key.ToString(), // EntityTrackingKey
					"Introducer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Introducer();
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
					c.ID = (System.Int32)reader[((int)IntroducerColumn.ID - 1)];
					c.Name = (System.String)reader[((int)IntroducerColumn.Name - 1)];
					c.Country = (reader.IsDBNull(((int)IntroducerColumn.Country - 1)))?null:(System.String)reader[((int)IntroducerColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)IntroducerColumn.City - 1)))?null:(System.String)reader[((int)IntroducerColumn.City - 1)];
					c.BirthDate = (reader.IsDBNull(((int)IntroducerColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)IntroducerColumn.BirthDate - 1)];
					c.Position = (reader.IsDBNull(((int)IntroducerColumn.Position - 1)))?null:(System.String)reader[((int)IntroducerColumn.Position - 1)];
					c.IsAlive = (reader.IsDBNull(((int)IntroducerColumn.IsAlive - 1)))?null:(System.String)reader[((int)IntroducerColumn.IsAlive - 1)];
					c.Mobile = (reader.IsDBNull(((int)IntroducerColumn.Mobile - 1)))?null:(System.String)reader[((int)IntroducerColumn.Mobile - 1)];
					c.Email = (reader.IsDBNull(((int)IntroducerColumn.Email - 1)))?null:(System.String)reader[((int)IntroducerColumn.Email - 1)];
					c.Website = (reader.IsDBNull(((int)IntroducerColumn.Website - 1)))?null:(System.String)reader[((int)IntroducerColumn.Website - 1)];
					c.Book_ID = (System.Int32)reader[((int)IntroducerColumn.Book_ID - 1)];
					c.Gender = (reader.IsDBNull(((int)IntroducerColumn.Gender - 1)))?null:(System.Boolean?)reader[((int)IntroducerColumn.Gender - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Introducer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Introducer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Introducer entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)IntroducerColumn.ID - 1)];
			entity.Name = (System.String)reader[((int)IntroducerColumn.Name - 1)];
			entity.Country = (reader.IsDBNull(((int)IntroducerColumn.Country - 1)))?null:(System.String)reader[((int)IntroducerColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)IntroducerColumn.City - 1)))?null:(System.String)reader[((int)IntroducerColumn.City - 1)];
			entity.BirthDate = (reader.IsDBNull(((int)IntroducerColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)IntroducerColumn.BirthDate - 1)];
			entity.Position = (reader.IsDBNull(((int)IntroducerColumn.Position - 1)))?null:(System.String)reader[((int)IntroducerColumn.Position - 1)];
			entity.IsAlive = (reader.IsDBNull(((int)IntroducerColumn.IsAlive - 1)))?null:(System.String)reader[((int)IntroducerColumn.IsAlive - 1)];
			entity.Mobile = (reader.IsDBNull(((int)IntroducerColumn.Mobile - 1)))?null:(System.String)reader[((int)IntroducerColumn.Mobile - 1)];
			entity.Email = (reader.IsDBNull(((int)IntroducerColumn.Email - 1)))?null:(System.String)reader[((int)IntroducerColumn.Email - 1)];
			entity.Website = (reader.IsDBNull(((int)IntroducerColumn.Website - 1)))?null:(System.String)reader[((int)IntroducerColumn.Website - 1)];
			entity.Book_ID = (System.Int32)reader[((int)IntroducerColumn.Book_ID - 1)];
			entity.Gender = (reader.IsDBNull(((int)IntroducerColumn.Gender - 1)))?null:(System.Boolean?)reader[((int)IntroducerColumn.Gender - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Introducer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Introducer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Introducer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.BirthDate = Convert.IsDBNull(dataRow["BirthDate"]) ? null : (System.DateTime?)dataRow["BirthDate"];
			entity.Position = Convert.IsDBNull(dataRow["Position"]) ? null : (System.String)dataRow["Position"];
			entity.IsAlive = Convert.IsDBNull(dataRow["IsAlive"]) ? null : (System.String)dataRow["IsAlive"];
			entity.Mobile = Convert.IsDBNull(dataRow["Mobile"]) ? null : (System.String)dataRow["Mobile"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Website = Convert.IsDBNull(dataRow["Website"]) ? null : (System.String)dataRow["Website"];
			entity.Book_ID = (System.Int32)dataRow["Book_ID"];
			entity.Gender = Convert.IsDBNull(dataRow["Gender"]) ? null : (System.Boolean?)dataRow["Gender"];
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
		/// <param name="entity">The <see cref="Library.BLL.Introducer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Introducer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Introducer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

				entity.BookCollection = DataRepository.BookProvider.GetByIntroducer_ID(transactionManager, entity.ID);

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
		/// Deep Save the entire object graph of the Library.BLL.Introducer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Introducer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Introducer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Introducer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.Introducer_IDSource != null)
						{
							child.Introducer_ID = child.Introducer_IDSource.ID;
						}
						else
						{
							child.Introducer_ID = entity.ID;
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
	
	#region IntroducerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Introducer</c>
	///</summary>
	public enum IntroducerChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Introducer</c> as OneToMany for BookCollection
		///</summary>
		[ChildEntityType(typeof(TList<Book>))]
		BookCollection,
	}
	
	#endregion IntroducerChildEntityTypes
	
	#region IntroducerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;IntroducerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerFilterBuilder : SqlFilterBuilder<IntroducerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerFilterBuilder class.
		/// </summary>
		public IntroducerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntroducerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntroducerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntroducerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntroducerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntroducerFilterBuilder
	
	#region IntroducerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;IntroducerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerParameterBuilder : ParameterizedSqlFilterBuilder<IntroducerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerParameterBuilder class.
		/// </summary>
		public IntroducerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntroducerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntroducerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntroducerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntroducerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntroducerParameterBuilder
	
	#region IntroducerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;IntroducerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class IntroducerSortBuilder : SqlSortBuilder<IntroducerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerSqlSortBuilder class.
		/// </summary>
		public IntroducerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion IntroducerSortBuilder
	
} // end namespace
