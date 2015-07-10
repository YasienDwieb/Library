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
	/// This class is the base class for any <see cref="AuthorProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AuthorProviderBaseCore : EntityProviderBase<Library.BLL.Author, Library.BLL.AuthorKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByBook_IDFromBook_Author
		
		/// <summary>
		///		Gets Author objects from the datasource by Book_ID in the
		///		Book_Author table. Table Author is related to table Book
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="_book_ID"></param>
		/// <returns>Returns a typed collection of Author objects.</returns>
		public TList<Author> GetByBook_IDFromBook_Author(System.Int32 _book_ID)
		{
			int count = -1;
			return GetByBook_IDFromBook_Author(null,_book_ID, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Library.BLL.Author objects from the datasource by Book_ID in the
		///		Book_Author table. Table Author is related to table Book
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_book_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Author objects.</returns>
		public TList<Author> GetByBook_IDFromBook_Author(System.Int32 _book_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByBook_IDFromBook_Author(null, _book_ID, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Author objects from the datasource by Book_ID in the
		///		Book_Author table. Table Author is related to table Book
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Author objects.</returns>
		public TList<Author> GetByBook_IDFromBook_Author(TransactionManager transactionManager, System.Int32 _book_ID)
		{
			int count = -1;
			return GetByBook_IDFromBook_Author(transactionManager, _book_ID, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Author objects from the datasource by Book_ID in the
		///		Book_Author table. Table Author is related to table Book
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_book_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Author objects.</returns>
		public TList<Author> GetByBook_IDFromBook_Author(TransactionManager transactionManager, System.Int32 _book_ID,int start, int pageLength)
		{
			int count = -1;
			return GetByBook_IDFromBook_Author(transactionManager, _book_ID, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Author objects from the datasource by Book_ID in the
		///		Book_Author table. Table Author is related to table Book
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="_book_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Author objects.</returns>
		public TList<Author> GetByBook_IDFromBook_Author(System.Int32 _book_ID,int start, int pageLength, out int count)
		{
			
			return GetByBook_IDFromBook_Author(null, _book_ID, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Author objects from the datasource by Book_ID in the
		///		Book_Author table. Table Author is related to table Book
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_book_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Author objects.</returns>
		public abstract TList<Author> GetByBook_IDFromBook_Author(TransactionManager transactionManager,System.Int32 _book_ID, int start, int pageLength, out int count);
		
		#endregion GetByBook_IDFromBook_Author
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Library.BLL.AuthorKey key)
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
		public override Library.BLL.Author Get(TransactionManager transactionManager, Library.BLL.AuthorKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Author index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Author"/> class.</returns>
		public Library.BLL.Author GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Author index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Author"/> class.</returns>
		public Library.BLL.Author GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Author index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Author"/> class.</returns>
		public Library.BLL.Author GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Author index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Author"/> class.</returns>
		public Library.BLL.Author GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Author index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Author"/> class.</returns>
		public Library.BLL.Author GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Author index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Author"/> class.</returns>
		public abstract Library.BLL.Author GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Author&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Author&gt;"/></returns>
		public static TList<Author> Fill(IDataReader reader, TList<Author> rows, int start, int pageLength)
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
				
				Library.BLL.Author c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Author")
					.Append("|").Append((System.Int32)reader[((int)AuthorColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Author>(
					key.ToString(), // EntityTrackingKey
					"Author",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Author();
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
					c.ID = (System.Int32)reader[((int)AuthorColumn.ID - 1)];
					c.Name = (System.String)reader[((int)AuthorColumn.Name - 1)];
					c.Country = (reader.IsDBNull(((int)AuthorColumn.Country - 1)))?null:(System.String)reader[((int)AuthorColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)AuthorColumn.City - 1)))?null:(System.String)reader[((int)AuthorColumn.City - 1)];
					c.BirthDate = (reader.IsDBNull(((int)AuthorColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)AuthorColumn.BirthDate - 1)];
					c.Position = (reader.IsDBNull(((int)AuthorColumn.Position - 1)))?null:(System.String)reader[((int)AuthorColumn.Position - 1)];
					c.IsAlive = (reader.IsDBNull(((int)AuthorColumn.IsAlive - 1)))?null:(System.String)reader[((int)AuthorColumn.IsAlive - 1)];
					c.Mobile = (reader.IsDBNull(((int)AuthorColumn.Mobile - 1)))?null:(System.String)reader[((int)AuthorColumn.Mobile - 1)];
					c.Email = (reader.IsDBNull(((int)AuthorColumn.Email - 1)))?null:(System.String)reader[((int)AuthorColumn.Email - 1)];
					c.Website = (reader.IsDBNull(((int)AuthorColumn.Website - 1)))?null:(System.String)reader[((int)AuthorColumn.Website - 1)];
					c.Gender = (reader.IsDBNull(((int)AuthorColumn.Gender - 1)))?null:(System.Boolean?)reader[((int)AuthorColumn.Gender - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Author"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Author"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Author entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)AuthorColumn.ID - 1)];
			entity.Name = (System.String)reader[((int)AuthorColumn.Name - 1)];
			entity.Country = (reader.IsDBNull(((int)AuthorColumn.Country - 1)))?null:(System.String)reader[((int)AuthorColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)AuthorColumn.City - 1)))?null:(System.String)reader[((int)AuthorColumn.City - 1)];
			entity.BirthDate = (reader.IsDBNull(((int)AuthorColumn.BirthDate - 1)))?null:(System.DateTime?)reader[((int)AuthorColumn.BirthDate - 1)];
			entity.Position = (reader.IsDBNull(((int)AuthorColumn.Position - 1)))?null:(System.String)reader[((int)AuthorColumn.Position - 1)];
			entity.IsAlive = (reader.IsDBNull(((int)AuthorColumn.IsAlive - 1)))?null:(System.String)reader[((int)AuthorColumn.IsAlive - 1)];
			entity.Mobile = (reader.IsDBNull(((int)AuthorColumn.Mobile - 1)))?null:(System.String)reader[((int)AuthorColumn.Mobile - 1)];
			entity.Email = (reader.IsDBNull(((int)AuthorColumn.Email - 1)))?null:(System.String)reader[((int)AuthorColumn.Email - 1)];
			entity.Website = (reader.IsDBNull(((int)AuthorColumn.Website - 1)))?null:(System.String)reader[((int)AuthorColumn.Website - 1)];
			entity.Gender = (reader.IsDBNull(((int)AuthorColumn.Gender - 1)))?null:(System.Boolean?)reader[((int)AuthorColumn.Gender - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Author"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Author"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Author entity)
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
		/// <param name="entity">The <see cref="Library.BLL.Author"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Author Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Author entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region Book_IDBookCollection_From_Book_Author
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Book>|Book_IDBookCollection_From_Book_Author", deepLoadType, innerList))
			{
				entity.Book_IDBookCollection_From_Book_Author = DataRepository.BookProvider.GetByAuthor_IDFromBook_Author(transactionManager, entity.ID);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Book_IDBookCollection_From_Book_Author' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Book_IDBookCollection_From_Book_Author != null)
				{
					deepHandles.Add("Book_IDBookCollection_From_Book_Author",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Book >) DataRepository.BookProvider.DeepLoad,
						new object[] { transactionManager, entity.Book_IDBookCollection_From_Book_Author, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region Book_AuthorCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Book_Author>|Book_AuthorCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Book_AuthorCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.Book_AuthorCollection = DataRepository.Book_AuthorProvider.GetByAuthor_ID(transactionManager, entity.ID);

				if (deep && entity.Book_AuthorCollection.Count > 0)
				{
					deepHandles.Add("Book_AuthorCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Book_Author>) DataRepository.Book_AuthorProvider.DeepLoad,
						new object[] { transactionManager, entity.Book_AuthorCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the Library.BLL.Author object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Author instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Author Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Author entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region Book_IDBookCollection_From_Book_Author>
			if (CanDeepSave(entity.Book_IDBookCollection_From_Book_Author, "List<Book>|Book_IDBookCollection_From_Book_Author", deepSaveType, innerList))
			{
				if (entity.Book_IDBookCollection_From_Book_Author.Count > 0 || entity.Book_IDBookCollection_From_Book_Author.DeletedItems.Count > 0)
				{
					DataRepository.BookProvider.Save(transactionManager, entity.Book_IDBookCollection_From_Book_Author); 
					deepHandles.Add("Book_IDBookCollection_From_Book_Author",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Book>) DataRepository.BookProvider.DeepSave,
						new object[] { transactionManager, entity.Book_IDBookCollection_From_Book_Author, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<Book_Author>
				if (CanDeepSave(entity.Book_AuthorCollection, "List<Book_Author>|Book_AuthorCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Book_Author child in entity.Book_AuthorCollection)
					{
						if(child.Author_IDSource != null)
						{
								child.Author_ID = child.Author_IDSource.ID;
						}

						if(child.Book_IDSource != null)
						{
								child.Book_ID = child.Book_IDSource.ID;
						}

					}

					if (entity.Book_AuthorCollection.Count > 0 || entity.Book_AuthorCollection.DeletedItems.Count > 0)
					{
						//DataRepository.Book_AuthorProvider.Save(transactionManager, entity.Book_AuthorCollection);
						
						deepHandles.Add("Book_AuthorCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Book_Author >) DataRepository.Book_AuthorProvider.DeepSave,
							new object[] { transactionManager, entity.Book_AuthorCollection, deepSaveType, childTypes, innerList }
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
	
	#region AuthorChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Author</c>
	///</summary>
	public enum AuthorChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Author</c> as ManyToMany for BookCollection_From_Book_Author
		///</summary>
		[ChildEntityType(typeof(TList<Book>))]
		Book_IDBookCollection_From_Book_Author,
		///<summary>
		/// Collection of <c>Author</c> as OneToMany for Book_AuthorCollection
		///</summary>
		[ChildEntityType(typeof(TList<Book_Author>))]
		Book_AuthorCollection,
	}
	
	#endregion AuthorChildEntityTypes
	
	#region AuthorFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AuthorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorFilterBuilder : SqlFilterBuilder<AuthorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorFilterBuilder class.
		/// </summary>
		public AuthorFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuthorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuthorFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuthorFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuthorFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuthorFilterBuilder
	
	#region AuthorParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AuthorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorParameterBuilder : ParameterizedSqlFilterBuilder<AuthorColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorParameterBuilder class.
		/// </summary>
		public AuthorParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuthorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuthorParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuthorParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuthorParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuthorParameterBuilder
	
	#region AuthorSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AuthorColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AuthorSortBuilder : SqlSortBuilder<AuthorColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorSqlSortBuilder class.
		/// </summary>
		public AuthorSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AuthorSortBuilder
	
} // end namespace
