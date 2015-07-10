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
	/// This class is the base class for any <see cref="UsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UsersProviderBaseCore : EntityProviderBase<Library.BLL.Users, Library.BLL.UsersKey>
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
		public override bool Delete(TransactionManager transactionManager, Library.BLL.UsersKey key)
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
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserType key.
		///		FK_Users_UserType Description: 
		/// </summary>
		/// <param name="_userType_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Users objects.</returns>
		public TList<Users> GetByUserType_ID(System.Int32 _userType_ID)
		{
			int count = -1;
			return GetByUserType_ID(_userType_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserType key.
		///		FK_Users_UserType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userType_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Users objects.</returns>
		/// <remarks></remarks>
		public TList<Users> GetByUserType_ID(TransactionManager transactionManager, System.Int32 _userType_ID)
		{
			int count = -1;
			return GetByUserType_ID(transactionManager, _userType_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserType key.
		///		FK_Users_UserType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userType_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Users objects.</returns>
		public TList<Users> GetByUserType_ID(TransactionManager transactionManager, System.Int32 _userType_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByUserType_ID(transactionManager, _userType_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserType key.
		///		fK_Users_UserType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userType_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Users objects.</returns>
		public TList<Users> GetByUserType_ID(System.Int32 _userType_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserType_ID(null, _userType_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserType key.
		///		fK_Users_UserType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userType_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Users objects.</returns>
		public TList<Users> GetByUserType_ID(System.Int32 _userType_ID, int start, int pageLength,out int count)
		{
			return GetByUserType_ID(null, _userType_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Users_UserType key.
		///		FK_Users_UserType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userType_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Users objects.</returns>
		public abstract TList<Users> GetByUserType_ID(TransactionManager transactionManager, System.Int32 _userType_ID, int start, int pageLength, out int count);
		
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
		public override Library.BLL.Users Get(TransactionManager transactionManager, Library.BLL.UsersKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_Users index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByUserName(System.String _userName)
		{
			int count = -1;
			return GetByUserName(null,_userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Users index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByUserName(System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByUserName(TransactionManager transactionManager, System.String _userName)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Users index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByUserName(System.String _userName, int start, int pageLength, out int count)
		{
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public abstract Library.BLL.Users GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Users index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public Library.BLL.Users GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Users"/> class.</returns>
		public abstract Library.BLL.Users GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Users&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Users&gt;"/></returns>
		public static TList<Users> Fill(IDataReader reader, TList<Users> rows, int start, int pageLength)
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
				
				Library.BLL.Users c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Users")
					.Append("|").Append((System.Int32)reader[((int)UsersColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Users>(
					key.ToString(), // EntityTrackingKey
					"Users",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Users();
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
					c.ID = (System.Int32)reader[((int)UsersColumn.ID - 1)];
					c.UserName = (System.String)reader[((int)UsersColumn.UserName - 1)];
					c.Password = (System.String)reader[((int)UsersColumn.Password - 1)];
					c.Last_Login = (reader.IsDBNull(((int)UsersColumn.Last_Login - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.Last_Login - 1)];
					c.Last_Logout = (reader.IsDBNull(((int)UsersColumn.Last_Logout - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.Last_Logout - 1)];
					c.Is_Online = (System.Boolean)reader[((int)UsersColumn.Is_Online - 1)];
					c.Is_Active = (System.Boolean)reader[((int)UsersColumn.Is_Active - 1)];
					c.Is_Admin = (System.Boolean)reader[((int)UsersColumn.Is_Admin - 1)];
					c.UserType_ID = (System.Int32)reader[((int)UsersColumn.UserType_ID - 1)];
					c.First_Name = (reader.IsDBNull(((int)UsersColumn.First_Name - 1)))?null:(System.String)reader[((int)UsersColumn.First_Name - 1)];
					c.Last_Name = (reader.IsDBNull(((int)UsersColumn.Last_Name - 1)))?null:(System.String)reader[((int)UsersColumn.Last_Name - 1)];
					c.Email = (reader.IsDBNull(((int)UsersColumn.Email - 1)))?null:(System.String)reader[((int)UsersColumn.Email - 1)];
					c.Country = (reader.IsDBNull(((int)UsersColumn.Country - 1)))?null:(System.String)reader[((int)UsersColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)UsersColumn.City - 1)))?null:(System.String)reader[((int)UsersColumn.City - 1)];
					c.Address = (reader.IsDBNull(((int)UsersColumn.Address - 1)))?null:(System.String)reader[((int)UsersColumn.Address - 1)];
					c.Mobile = (reader.IsDBNull(((int)UsersColumn.Mobile - 1)))?null:(System.String)reader[((int)UsersColumn.Mobile - 1)];
					c.Phone = (reader.IsDBNull(((int)UsersColumn.Phone - 1)))?null:(System.String)reader[((int)UsersColumn.Phone - 1)];
					c.Postion = (reader.IsDBNull(((int)UsersColumn.Postion - 1)))?null:(System.String)reader[((int)UsersColumn.Postion - 1)];
					c.Is_Deleted = (reader.IsDBNull(((int)UsersColumn.Is_Deleted - 1)))?null:(System.Boolean?)reader[((int)UsersColumn.Is_Deleted - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)UsersColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.CreatedOn - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)UsersColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)UsersColumn.CreatedBy - 1)];
					c.UpdatedOn = (reader.IsDBNull(((int)UsersColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.UpdatedOn - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)UsersColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)UsersColumn.UpdatedBy - 1)];
					c.DeletedOn = (reader.IsDBNull(((int)UsersColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.DeletedOn - 1)];
					c.DeletedBy = (reader.IsDBNull(((int)UsersColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)UsersColumn.DeletedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Users"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Users"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Users entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)UsersColumn.ID - 1)];
			entity.UserName = (System.String)reader[((int)UsersColumn.UserName - 1)];
			entity.Password = (System.String)reader[((int)UsersColumn.Password - 1)];
			entity.Last_Login = (reader.IsDBNull(((int)UsersColumn.Last_Login - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.Last_Login - 1)];
			entity.Last_Logout = (reader.IsDBNull(((int)UsersColumn.Last_Logout - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.Last_Logout - 1)];
			entity.Is_Online = (System.Boolean)reader[((int)UsersColumn.Is_Online - 1)];
			entity.Is_Active = (System.Boolean)reader[((int)UsersColumn.Is_Active - 1)];
			entity.Is_Admin = (System.Boolean)reader[((int)UsersColumn.Is_Admin - 1)];
			entity.UserType_ID = (System.Int32)reader[((int)UsersColumn.UserType_ID - 1)];
			entity.First_Name = (reader.IsDBNull(((int)UsersColumn.First_Name - 1)))?null:(System.String)reader[((int)UsersColumn.First_Name - 1)];
			entity.Last_Name = (reader.IsDBNull(((int)UsersColumn.Last_Name - 1)))?null:(System.String)reader[((int)UsersColumn.Last_Name - 1)];
			entity.Email = (reader.IsDBNull(((int)UsersColumn.Email - 1)))?null:(System.String)reader[((int)UsersColumn.Email - 1)];
			entity.Country = (reader.IsDBNull(((int)UsersColumn.Country - 1)))?null:(System.String)reader[((int)UsersColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)UsersColumn.City - 1)))?null:(System.String)reader[((int)UsersColumn.City - 1)];
			entity.Address = (reader.IsDBNull(((int)UsersColumn.Address - 1)))?null:(System.String)reader[((int)UsersColumn.Address - 1)];
			entity.Mobile = (reader.IsDBNull(((int)UsersColumn.Mobile - 1)))?null:(System.String)reader[((int)UsersColumn.Mobile - 1)];
			entity.Phone = (reader.IsDBNull(((int)UsersColumn.Phone - 1)))?null:(System.String)reader[((int)UsersColumn.Phone - 1)];
			entity.Postion = (reader.IsDBNull(((int)UsersColumn.Postion - 1)))?null:(System.String)reader[((int)UsersColumn.Postion - 1)];
			entity.Is_Deleted = (reader.IsDBNull(((int)UsersColumn.Is_Deleted - 1)))?null:(System.Boolean?)reader[((int)UsersColumn.Is_Deleted - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)UsersColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.CreatedOn - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)UsersColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)UsersColumn.CreatedBy - 1)];
			entity.UpdatedOn = (reader.IsDBNull(((int)UsersColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.UpdatedOn - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)UsersColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)UsersColumn.UpdatedBy - 1)];
			entity.DeletedOn = (reader.IsDBNull(((int)UsersColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)UsersColumn.DeletedOn - 1)];
			entity.DeletedBy = (reader.IsDBNull(((int)UsersColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)UsersColumn.DeletedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Users"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Users"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Users entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.UserName = (System.String)dataRow["UserName"];
			entity.Password = (System.String)dataRow["Password"];
			entity.Last_Login = Convert.IsDBNull(dataRow["Last_Login"]) ? null : (System.DateTime?)dataRow["Last_Login"];
			entity.Last_Logout = Convert.IsDBNull(dataRow["Last_Logout"]) ? null : (System.DateTime?)dataRow["Last_Logout"];
			entity.Is_Online = (System.Boolean)dataRow["Is_Online"];
			entity.Is_Active = (System.Boolean)dataRow["Is_Active"];
			entity.Is_Admin = (System.Boolean)dataRow["Is_Admin"];
			entity.UserType_ID = (System.Int32)dataRow["UserType_ID"];
			entity.First_Name = Convert.IsDBNull(dataRow["First_Name"]) ? null : (System.String)dataRow["First_Name"];
			entity.Last_Name = Convert.IsDBNull(dataRow["Last_Name"]) ? null : (System.String)dataRow["Last_Name"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.Mobile = Convert.IsDBNull(dataRow["Mobile"]) ? null : (System.String)dataRow["Mobile"];
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
		/// <param name="entity">The <see cref="Library.BLL.Users"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Users Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Users entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region UserType_IDSource	
			if (CanDeepLoad(entity, "UserType|UserType_IDSource", deepLoadType, innerList) 
				&& entity.UserType_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.UserType_ID;
				UserType tmpEntity = EntityManager.LocateEntity<UserType>(EntityLocator.ConstructKeyFromPkItems(typeof(UserType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserType_IDSource = tmpEntity;
				else
					entity.UserType_IDSource = DataRepository.UserTypeProvider.GetByID(transactionManager, entity.UserType_ID);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserType_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserType_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserTypeProvider.DeepLoad(transactionManager, entity.UserType_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UserType_IDSource
			
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
		/// Deep Save the entire object graph of the Library.BLL.Users object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Users instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Users Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Users entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UserType_IDSource
			if (CanDeepSave(entity, "UserType|UserType_IDSource", deepSaveType, innerList) 
				&& entity.UserType_IDSource != null)
			{
				DataRepository.UserTypeProvider.Save(transactionManager, entity.UserType_IDSource);
				entity.UserType_ID = entity.UserType_IDSource.ID;
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
	
	#region UsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Users</c>
	///</summary>
	public enum UsersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>UserType</c> at UserType_IDSource
		///</summary>
		[ChildEntityType(typeof(UserType))]
		UserType,
	}
	
	#endregion UsersChildEntityTypes
	
	#region UsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersFilterBuilder : SqlFilterBuilder<UsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersFilterBuilder class.
		/// </summary>
		public UsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersFilterBuilder
	
	#region UsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersParameterBuilder : ParameterizedSqlFilterBuilder<UsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersParameterBuilder class.
		/// </summary>
		public UsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersParameterBuilder
	
	#region UsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;UsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class UsersSortBuilder : SqlSortBuilder<UsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersSqlSortBuilder class.
		/// </summary>
		public UsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion UsersSortBuilder
	
} // end namespace
