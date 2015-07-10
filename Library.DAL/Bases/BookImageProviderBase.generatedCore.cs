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
	/// This class is the base class for any <see cref="BookImageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BookImageProviderBaseCore : EntityProviderBase<Library.BLL.BookImage, Library.BLL.BookImageKey>
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
		public override bool Delete(TransactionManager transactionManager, Library.BLL.BookImageKey key)
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
		public override Library.BLL.BookImage Get(TransactionManager transactionManager, Library.BLL.BookImageKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Image index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.BookImage"/> class.</returns>
		public Library.BLL.BookImage GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Image index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.BookImage"/> class.</returns>
		public Library.BLL.BookImage GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Image index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.BookImage"/> class.</returns>
		public Library.BLL.BookImage GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Image index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.BookImage"/> class.</returns>
		public Library.BLL.BookImage GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Image index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.BookImage"/> class.</returns>
		public Library.BLL.BookImage GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Image index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.BookImage"/> class.</returns>
		public abstract Library.BLL.BookImage GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;BookImage&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;BookImage&gt;"/></returns>
		public static TList<BookImage> Fill(IDataReader reader, TList<BookImage> rows, int start, int pageLength)
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
				
				Library.BLL.BookImage c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("BookImage")
					.Append("|").Append((System.Int32)reader[((int)BookImageColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<BookImage>(
					key.ToString(), // EntityTrackingKey
					"BookImage",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.BookImage();
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
					c.ID = (System.Int32)reader[((int)BookImageColumn.ID - 1)];
					c.Name = (System.String)reader[((int)BookImageColumn.Name - 1)];
					c.Format = (reader.IsDBNull(((int)BookImageColumn.Format - 1)))?null:(System.String)reader[((int)BookImageColumn.Format - 1)];
					c.Size = (reader.IsDBNull(((int)BookImageColumn.Size - 1)))?null:(System.String)reader[((int)BookImageColumn.Size - 1)];
					c.Link = (reader.IsDBNull(((int)BookImageColumn.Link - 1)))?null:(System.String)reader[((int)BookImageColumn.Link - 1)];
					c.IsAvailable = (reader.IsDBNull(((int)BookImageColumn.IsAvailable - 1)))?null:(System.String)reader[((int)BookImageColumn.IsAvailable - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.BookImage"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.BookImage"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.BookImage entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)BookImageColumn.ID - 1)];
			entity.Name = (System.String)reader[((int)BookImageColumn.Name - 1)];
			entity.Format = (reader.IsDBNull(((int)BookImageColumn.Format - 1)))?null:(System.String)reader[((int)BookImageColumn.Format - 1)];
			entity.Size = (reader.IsDBNull(((int)BookImageColumn.Size - 1)))?null:(System.String)reader[((int)BookImageColumn.Size - 1)];
			entity.Link = (reader.IsDBNull(((int)BookImageColumn.Link - 1)))?null:(System.String)reader[((int)BookImageColumn.Link - 1)];
			entity.IsAvailable = (reader.IsDBNull(((int)BookImageColumn.IsAvailable - 1)))?null:(System.String)reader[((int)BookImageColumn.IsAvailable - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.BookImage"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.BookImage"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.BookImage entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Format = Convert.IsDBNull(dataRow["Format"]) ? null : (System.String)dataRow["Format"];
			entity.Size = Convert.IsDBNull(dataRow["Size"]) ? null : (System.String)dataRow["Size"];
			entity.Link = Convert.IsDBNull(dataRow["Link"]) ? null : (System.String)dataRow["Link"];
			entity.IsAvailable = Convert.IsDBNull(dataRow["IsAvailable"]) ? null : (System.String)dataRow["IsAvailable"];
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
		/// <param name="entity">The <see cref="Library.BLL.BookImage"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.BookImage Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.BookImage entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

				entity.BookCollection = DataRepository.BookProvider.GetByImage_ID(transactionManager, entity.ID);

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
		/// Deep Save the entire object graph of the Library.BLL.BookImage object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.BookImage instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.BookImage Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.BookImage entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.Image_IDSource != null)
						{
							child.Image_ID = child.Image_IDSource.ID;
						}
						else
						{
							child.Image_ID = entity.ID;
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
	
	#region BookImageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.BookImage</c>
	///</summary>
	public enum BookImageChildEntityTypes
	{
		///<summary>
		/// Collection of <c>BookImage</c> as OneToMany for BookCollection
		///</summary>
		[ChildEntityType(typeof(TList<Book>))]
		BookCollection,
	}
	
	#endregion BookImageChildEntityTypes
	
	#region BookImageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BookImageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageFilterBuilder : SqlFilterBuilder<BookImageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageFilterBuilder class.
		/// </summary>
		public BookImageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookImageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookImageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookImageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookImageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookImageFilterBuilder
	
	#region BookImageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BookImageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageParameterBuilder : ParameterizedSqlFilterBuilder<BookImageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageParameterBuilder class.
		/// </summary>
		public BookImageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookImageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookImageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookImageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookImageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookImageParameterBuilder
	
	#region BookImageSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;BookImageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class BookImageSortBuilder : SqlSortBuilder<BookImageColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageSqlSortBuilder class.
		/// </summary>
		public BookImageSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion BookImageSortBuilder
	
} // end namespace
