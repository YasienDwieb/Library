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
	/// This class is the base class for any <see cref="Book_AuthorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class Book_AuthorProviderBaseCore : EntityProviderBase<Library.BLL.Book_Author, Library.BLL.Book_AuthorKey>
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
		public override bool Delete(TransactionManager transactionManager, Library.BLL.Book_AuthorKey key)
		{
			return Delete(transactionManager, key.Book_ID, key.Author_ID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_book_ID">. Primary Key.</param>
		/// <param name="_author_ID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _book_ID, System.Int32 _author_ID)
		{
			return Delete(null, _book_ID, _author_ID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID">. Primary Key.</param>
		/// <param name="_author_ID">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _book_ID, System.Int32 _author_ID);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Author key.
		///		FK_Book_Author_Author Description: 
		/// </summary>
		/// <param name="_author_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByAuthor_ID(System.Int32 _author_ID)
		{
			int count = -1;
			return GetByAuthor_ID(_author_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Author key.
		///		FK_Book_Author_Author Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_author_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		/// <remarks></remarks>
		public TList<Book_Author> GetByAuthor_ID(TransactionManager transactionManager, System.Int32 _author_ID)
		{
			int count = -1;
			return GetByAuthor_ID(transactionManager, _author_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Author key.
		///		FK_Book_Author_Author Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByAuthor_ID(TransactionManager transactionManager, System.Int32 _author_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByAuthor_ID(transactionManager, _author_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Author key.
		///		fK_Book_Author_Author Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_author_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByAuthor_ID(System.Int32 _author_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByAuthor_ID(null, _author_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Author key.
		///		fK_Book_Author_Author Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_author_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByAuthor_ID(System.Int32 _author_ID, int start, int pageLength,out int count)
		{
			return GetByAuthor_ID(null, _author_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Author key.
		///		FK_Book_Author_Author Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public abstract TList<Book_Author> GetByAuthor_ID(TransactionManager transactionManager, System.Int32 _author_ID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Book key.
		///		FK_Book_Author_Book Description: 
		/// </summary>
		/// <param name="_book_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByBook_ID(System.Int32 _book_ID)
		{
			int count = -1;
			return GetByBook_ID(_book_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Book key.
		///		FK_Book_Author_Book Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		/// <remarks></remarks>
		public TList<Book_Author> GetByBook_ID(TransactionManager transactionManager, System.Int32 _book_ID)
		{
			int count = -1;
			return GetByBook_ID(transactionManager, _book_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Book key.
		///		FK_Book_Author_Book Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByBook_ID(TransactionManager transactionManager, System.Int32 _book_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByBook_ID(transactionManager, _book_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Book key.
		///		fK_Book_Author_Book Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_book_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByBook_ID(System.Int32 _book_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByBook_ID(null, _book_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Book key.
		///		fK_Book_Author_Book Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_book_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public TList<Book_Author> GetByBook_ID(System.Int32 _book_ID, int start, int pageLength,out int count)
		{
			return GetByBook_ID(null, _book_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Author_Book key.
		///		FK_Book_Author_Book Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book_Author objects.</returns>
		public abstract TList<Book_Author> GetByBook_ID(TransactionManager transactionManager, System.Int32 _book_ID, int start, int pageLength, out int count);
		
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
		public override Library.BLL.Book_Author Get(TransactionManager transactionManager, Library.BLL.Book_AuthorKey key, int start, int pageLength)
		{
			return GetByBook_IDAuthor_ID(transactionManager, key.Book_ID, key.Author_ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Book_Author index.
		/// </summary>
		/// <param name="_book_ID"></param>
		/// <param name="_author_ID"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book_Author"/> class.</returns>
		public Library.BLL.Book_Author GetByBook_IDAuthor_ID(System.Int32 _book_ID, System.Int32 _author_ID)
		{
			int count = -1;
			return GetByBook_IDAuthor_ID(null,_book_ID, _author_ID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book_Author index.
		/// </summary>
		/// <param name="_book_ID"></param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book_Author"/> class.</returns>
		public Library.BLL.Book_Author GetByBook_IDAuthor_ID(System.Int32 _book_ID, System.Int32 _author_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByBook_IDAuthor_ID(null, _book_ID, _author_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book_Author index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <param name="_author_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book_Author"/> class.</returns>
		public Library.BLL.Book_Author GetByBook_IDAuthor_ID(TransactionManager transactionManager, System.Int32 _book_ID, System.Int32 _author_ID)
		{
			int count = -1;
			return GetByBook_IDAuthor_ID(transactionManager, _book_ID, _author_ID, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book_Author index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book_Author"/> class.</returns>
		public Library.BLL.Book_Author GetByBook_IDAuthor_ID(TransactionManager transactionManager, System.Int32 _book_ID, System.Int32 _author_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByBook_IDAuthor_ID(transactionManager, _book_ID, _author_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book_Author index.
		/// </summary>
		/// <param name="_book_ID"></param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book_Author"/> class.</returns>
		public Library.BLL.Book_Author GetByBook_IDAuthor_ID(System.Int32 _book_ID, System.Int32 _author_ID, int start, int pageLength, out int count)
		{
			return GetByBook_IDAuthor_ID(null, _book_ID, _author_ID, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book_Author index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book_Author"/> class.</returns>
		public abstract Library.BLL.Book_Author GetByBook_IDAuthor_ID(TransactionManager transactionManager, System.Int32 _book_ID, System.Int32 _author_ID, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Book_Author&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Book_Author&gt;"/></returns>
		public static TList<Book_Author> Fill(IDataReader reader, TList<Book_Author> rows, int start, int pageLength)
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
				
				Library.BLL.Book_Author c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Book_Author")
					.Append("|").Append((System.Int32)reader[((int)Book_AuthorColumn.Book_ID - 1)])
					.Append("|").Append((System.Int32)reader[((int)Book_AuthorColumn.Author_ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Book_Author>(
					key.ToString(), // EntityTrackingKey
					"Book_Author",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Book_Author();
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
					c.ID = (System.Int32)reader[((int)Book_AuthorColumn.ID - 1)];
					c.Book_ID = (System.Int32)reader[((int)Book_AuthorColumn.Book_ID - 1)];
					c.OriginalBook_ID = c.Book_ID;
					c.Author_ID = (System.Int32)reader[((int)Book_AuthorColumn.Author_ID - 1)];
					c.OriginalAuthor_ID = c.Author_ID;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Book_Author"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Book_Author"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Book_Author entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)Book_AuthorColumn.ID - 1)];
			entity.Book_ID = (System.Int32)reader[((int)Book_AuthorColumn.Book_ID - 1)];
			entity.OriginalBook_ID = (System.Int32)reader["Book_ID"];
			entity.Author_ID = (System.Int32)reader[((int)Book_AuthorColumn.Author_ID - 1)];
			entity.OriginalAuthor_ID = (System.Int32)reader["Author_ID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Book_Author"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Book_Author"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Book_Author entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.Book_ID = (System.Int32)dataRow["Book_ID"];
			entity.OriginalBook_ID = (System.Int32)dataRow["Book_ID"];
			entity.Author_ID = (System.Int32)dataRow["Author_ID"];
			entity.OriginalAuthor_ID = (System.Int32)dataRow["Author_ID"];
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
		/// <param name="entity">The <see cref="Library.BLL.Book_Author"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Book_Author Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Book_Author entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region Author_IDSource	
			if (CanDeepLoad(entity, "Author|Author_IDSource", deepLoadType, innerList) 
				&& entity.Author_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Author_ID;
				Author tmpEntity = EntityManager.LocateEntity<Author>(EntityLocator.ConstructKeyFromPkItems(typeof(Author), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Author_IDSource = tmpEntity;
				else
					entity.Author_IDSource = DataRepository.AuthorProvider.GetByID(transactionManager, entity.Author_ID);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Author_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Author_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AuthorProvider.DeepLoad(transactionManager, entity.Author_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Author_IDSource

			#region Book_IDSource	
			if (CanDeepLoad(entity, "Book|Book_IDSource", deepLoadType, innerList) 
				&& entity.Book_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Book_ID;
				Book tmpEntity = EntityManager.LocateEntity<Book>(EntityLocator.ConstructKeyFromPkItems(typeof(Book), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Book_IDSource = tmpEntity;
				else
					entity.Book_IDSource = DataRepository.BookProvider.GetByID(transactionManager, entity.Book_ID);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Book_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Book_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BookProvider.DeepLoad(transactionManager, entity.Book_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Book_IDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the Library.BLL.Book_Author object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Book_Author instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Book_Author Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Book_Author entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region Author_IDSource
			if (CanDeepSave(entity, "Author|Author_IDSource", deepSaveType, innerList) 
				&& entity.Author_IDSource != null)
			{
				DataRepository.AuthorProvider.Save(transactionManager, entity.Author_IDSource);
				entity.Author_ID = entity.Author_IDSource.ID;
			}
			#endregion 
			
			#region Book_IDSource
			if (CanDeepSave(entity, "Book|Book_IDSource", deepSaveType, innerList) 
				&& entity.Book_IDSource != null)
			{
				DataRepository.BookProvider.Save(transactionManager, entity.Book_IDSource);
				entity.Book_ID = entity.Book_IDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region Book_AuthorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Book_Author</c>
	///</summary>
	public enum Book_AuthorChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Author</c> at Author_IDSource
		///</summary>
		[ChildEntityType(typeof(Author))]
		Author,
		
		///<summary>
		/// Composite Property for <c>Book</c> at Book_IDSource
		///</summary>
		[ChildEntityType(typeof(Book))]
		Book,
	}
	
	#endregion Book_AuthorChildEntityTypes
	
	#region Book_AuthorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;Book_AuthorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorFilterBuilder : SqlFilterBuilder<Book_AuthorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorFilterBuilder class.
		/// </summary>
		public Book_AuthorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Book_AuthorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Book_AuthorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Book_AuthorFilterBuilder
	
	#region Book_AuthorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;Book_AuthorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorParameterBuilder : ParameterizedSqlFilterBuilder<Book_AuthorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorParameterBuilder class.
		/// </summary>
		public Book_AuthorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Book_AuthorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Book_AuthorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Book_AuthorParameterBuilder
	
	#region Book_AuthorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;Book_AuthorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class Book_AuthorSortBuilder : SqlSortBuilder<Book_AuthorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorSqlSortBuilder class.
		/// </summary>
		public Book_AuthorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion Book_AuthorSortBuilder
	
} // end namespace
