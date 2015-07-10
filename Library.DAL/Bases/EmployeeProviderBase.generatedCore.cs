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
	/// This class is the base class for any <see cref="EmployeeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmployeeProviderBaseCore : EntityProviderBase<Library.BLL.Employee, Library.BLL.EmployeeKey>
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
		public override bool Delete(TransactionManager transactionManager, Library.BLL.EmployeeKey key)
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
		public override Library.BLL.Employee Get(TransactionManager transactionManager, Library.BLL.EmployeeKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Employee index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByUserName(System.String _userName)
		{
			int count = -1;
			return GetByUserName(null,_userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByUserName(System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByUserName(TransactionManager transactionManager, System.String _userName)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByUserName(System.String _userName, int start, int pageLength, out int count)
		{
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Employee index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public abstract Library.BLL.Employee GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Employee_1 index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_1 index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_1 index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public Library.BLL.Employee GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Employee_1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Employee"/> class.</returns>
		public abstract Library.BLL.Employee GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Employee&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Employee&gt;"/></returns>
		public static TList<Employee> Fill(IDataReader reader, TList<Employee> rows, int start, int pageLength)
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
				
				Library.BLL.Employee c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Employee")
					.Append("|").Append((System.Int32)reader[((int)EmployeeColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Employee>(
					key.ToString(), // EntityTrackingKey
					"Employee",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Employee();
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
					c.ID = (System.Int32)reader[((int)EmployeeColumn.ID - 1)];
					c.UserName = (reader.IsDBNull(((int)EmployeeColumn.UserName - 1)))?null:(System.String)reader[((int)EmployeeColumn.UserName - 1)];
					c.Password = (reader.IsDBNull(((int)EmployeeColumn.Password - 1)))?null:(System.String)reader[((int)EmployeeColumn.Password - 1)];
					c.Last_Login = (reader.IsDBNull(((int)EmployeeColumn.Last_Login - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.Last_Login - 1)];
					c.Last_Logout = (System.DateTime)reader[((int)EmployeeColumn.Last_Logout - 1)];
					c.Is_Online = (reader.IsDBNull(((int)EmployeeColumn.Is_Online - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Online - 1)];
					c.Is_Active = (reader.IsDBNull(((int)EmployeeColumn.Is_Active - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Active - 1)];
					c.Is_Admin = (reader.IsDBNull(((int)EmployeeColumn.Is_Admin - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Admin - 1)];
					c.First_Name = (System.String)reader[((int)EmployeeColumn.First_Name - 1)];
					c.Last_Name = (System.String)reader[((int)EmployeeColumn.Last_Name - 1)];
					c.Email = (System.String)reader[((int)EmployeeColumn.Email - 1)];
					c.Country = (System.String)reader[((int)EmployeeColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)EmployeeColumn.City - 1)))?null:(System.String)reader[((int)EmployeeColumn.City - 1)];
					c.Address = (reader.IsDBNull(((int)EmployeeColumn.Address - 1)))?null:(System.String)reader[((int)EmployeeColumn.Address - 1)];
					c.Mobile = (System.String)reader[((int)EmployeeColumn.Mobile - 1)];
					c.Phone = (reader.IsDBNull(((int)EmployeeColumn.Phone - 1)))?null:(System.String)reader[((int)EmployeeColumn.Phone - 1)];
					c.Postion = (reader.IsDBNull(((int)EmployeeColumn.Postion - 1)))?null:(System.String)reader[((int)EmployeeColumn.Postion - 1)];
					c.Is_Deleted = (reader.IsDBNull(((int)EmployeeColumn.Is_Deleted - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Deleted - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)EmployeeColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.CreatedOn - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)EmployeeColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.CreatedBy - 1)];
					c.UpdatedOn = (reader.IsDBNull(((int)EmployeeColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.UpdatedOn - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)EmployeeColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.UpdatedBy - 1)];
					c.DeletedOn = (reader.IsDBNull(((int)EmployeeColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.DeletedOn - 1)];
					c.DeletedBy = (reader.IsDBNull(((int)EmployeeColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.DeletedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Employee"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Employee"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Employee entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)EmployeeColumn.ID - 1)];
			entity.UserName = (reader.IsDBNull(((int)EmployeeColumn.UserName - 1)))?null:(System.String)reader[((int)EmployeeColumn.UserName - 1)];
			entity.Password = (reader.IsDBNull(((int)EmployeeColumn.Password - 1)))?null:(System.String)reader[((int)EmployeeColumn.Password - 1)];
			entity.Last_Login = (reader.IsDBNull(((int)EmployeeColumn.Last_Login - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.Last_Login - 1)];
			entity.Last_Logout = (System.DateTime)reader[((int)EmployeeColumn.Last_Logout - 1)];
			entity.Is_Online = (reader.IsDBNull(((int)EmployeeColumn.Is_Online - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Online - 1)];
			entity.Is_Active = (reader.IsDBNull(((int)EmployeeColumn.Is_Active - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Active - 1)];
			entity.Is_Admin = (reader.IsDBNull(((int)EmployeeColumn.Is_Admin - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Admin - 1)];
			entity.First_Name = (System.String)reader[((int)EmployeeColumn.First_Name - 1)];
			entity.Last_Name = (System.String)reader[((int)EmployeeColumn.Last_Name - 1)];
			entity.Email = (System.String)reader[((int)EmployeeColumn.Email - 1)];
			entity.Country = (System.String)reader[((int)EmployeeColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)EmployeeColumn.City - 1)))?null:(System.String)reader[((int)EmployeeColumn.City - 1)];
			entity.Address = (reader.IsDBNull(((int)EmployeeColumn.Address - 1)))?null:(System.String)reader[((int)EmployeeColumn.Address - 1)];
			entity.Mobile = (System.String)reader[((int)EmployeeColumn.Mobile - 1)];
			entity.Phone = (reader.IsDBNull(((int)EmployeeColumn.Phone - 1)))?null:(System.String)reader[((int)EmployeeColumn.Phone - 1)];
			entity.Postion = (reader.IsDBNull(((int)EmployeeColumn.Postion - 1)))?null:(System.String)reader[((int)EmployeeColumn.Postion - 1)];
			entity.Is_Deleted = (reader.IsDBNull(((int)EmployeeColumn.Is_Deleted - 1)))?null:(System.Boolean?)reader[((int)EmployeeColumn.Is_Deleted - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)EmployeeColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.CreatedOn - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)EmployeeColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.CreatedBy - 1)];
			entity.UpdatedOn = (reader.IsDBNull(((int)EmployeeColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.UpdatedOn - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)EmployeeColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.UpdatedBy - 1)];
			entity.DeletedOn = (reader.IsDBNull(((int)EmployeeColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)EmployeeColumn.DeletedOn - 1)];
			entity.DeletedBy = (reader.IsDBNull(((int)EmployeeColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)EmployeeColumn.DeletedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Employee"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Employee"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Employee entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.UserName = Convert.IsDBNull(dataRow["UserName"]) ? null : (System.String)dataRow["UserName"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
			entity.Last_Login = Convert.IsDBNull(dataRow["Last_Login"]) ? null : (System.DateTime?)dataRow["Last_Login"];
			entity.Last_Logout = (System.DateTime)dataRow["Last_Logout"];
			entity.Is_Online = Convert.IsDBNull(dataRow["Is_Online"]) ? null : (System.Boolean?)dataRow["Is_Online"];
			entity.Is_Active = Convert.IsDBNull(dataRow["Is_Active"]) ? null : (System.Boolean?)dataRow["Is_Active"];
			entity.Is_Admin = Convert.IsDBNull(dataRow["Is_Admin"]) ? null : (System.Boolean?)dataRow["Is_Admin"];
			entity.First_Name = (System.String)dataRow["First_Name"];
			entity.Last_Name = (System.String)dataRow["Last_Name"];
			entity.Email = (System.String)dataRow["Email"];
			entity.Country = (System.String)dataRow["Country"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.Mobile = (System.String)dataRow["Mobile"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Postion = Convert.IsDBNull(dataRow["Postion"]) ? null : (System.String)dataRow["Postion"];
			entity.Is_Deleted = Convert.IsDBNull(dataRow["Is_Deleted"]) ? null : (System.Boolean?)dataRow["Is_Deleted"];
			entity.CreatedOn = Convert.IsDBNull(dataRow["CreatedOn"]) ? null : (System.DateTime?)dataRow["CreatedOn"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["CreatedBy"]) ? null : (System.Int32?)dataRow["CreatedBy"];
			entity.UpdatedOn = Convert.IsDBNull(dataRow["UpdatedOn"]) ? null : (System.DateTime?)dataRow["UpdatedOn"];
			entity.UpdatedBy = Convert.IsDBNull(dataRow["UpdatedBy"]) ? null : (System.Int32?)dataRow["UpdatedBy"];
			entity.DeletedOn = Convert.IsDBNull(dataRow["DeletedOn"]) ? null : (System.DateTime?)dataRow["DeletedOn"];
			entity.DeletedBy = Convert.IsDBNull(dataRow["DeletedBy"]) ? null : (System.Int32?)dataRow["DeletedBy"];
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
		/// <param name="entity">The <see cref="Library.BLL.Employee"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Employee Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Employee entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

				entity.BookCollection = DataRepository.BookProvider.GetByEmployeeI_D(transactionManager, entity.ID);

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
		/// Deep Save the entire object graph of the Library.BLL.Employee object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Employee instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Employee Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Employee entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.EmployeeI_DSource != null)
						{
							child.EmployeeI_D = child.EmployeeI_DSource.ID;
						}
						else
						{
							child.EmployeeI_D = entity.ID;
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
	
	#region EmployeeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Employee</c>
	///</summary>
	public enum EmployeeChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Employee</c> as OneToMany for BookCollection
		///</summary>
		[ChildEntityType(typeof(TList<Book>))]
		BookCollection,
	}
	
	#endregion EmployeeChildEntityTypes
	
	#region EmployeeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilterBuilder : SqlFilterBuilder<EmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		public EmployeeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeFilterBuilder
	
	#region EmployeeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeParameterBuilder : ParameterizedSqlFilterBuilder<EmployeeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		public EmployeeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeParameterBuilder
	
	#region EmployeeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EmployeeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EmployeeSortBuilder : SqlSortBuilder<EmployeeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeSqlSortBuilder class.
		/// </summary>
		public EmployeeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EmployeeSortBuilder
	
} // end namespace
