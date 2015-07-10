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
	/// This class is the base class for any <see cref="CourseProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CourseProviderBaseCore : EntityProviderBase<Library.BLL.Course, Library.BLL.CourseKey>
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
		public override bool Delete(TransactionManager transactionManager, Library.BLL.CourseKey key)
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
		public override Library.BLL.Course Get(TransactionManager transactionManager, Library.BLL.CourseKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Course index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Course"/> class.</returns>
		public Library.BLL.Course GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Course index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Course"/> class.</returns>
		public Library.BLL.Course GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Course index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Course"/> class.</returns>
		public Library.BLL.Course GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Course index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Course"/> class.</returns>
		public Library.BLL.Course GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Course index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Course"/> class.</returns>
		public Library.BLL.Course GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Course index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Course"/> class.</returns>
		public abstract Library.BLL.Course GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Course&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Course&gt;"/></returns>
		public static TList<Course> Fill(IDataReader reader, TList<Course> rows, int start, int pageLength)
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
				
				Library.BLL.Course c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Course")
					.Append("|").Append((System.Int32)reader[((int)CourseColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Course>(
					key.ToString(), // EntityTrackingKey
					"Course",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Course();
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
					c.ID = (System.Int32)reader[((int)CourseColumn.ID - 1)];
					c.Course_Name = (System.String)reader[((int)CourseColumn.Course_Name - 1)];
					c.Course_Scope = (System.Int32)reader[((int)CourseColumn.Course_Scope - 1)];
					c.Duration = (System.Int32)reader[((int)CourseColumn.Duration - 1)];
					c.DurationType_ID = (System.Int32)reader[((int)CourseColumn.DurationType_ID - 1)];
					c.Is_Deleted = (reader.IsDBNull(((int)CourseColumn.Is_Deleted - 1)))?null:(System.Boolean?)reader[((int)CourseColumn.Is_Deleted - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)CourseColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)CourseColumn.CreatedOn - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)CourseColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)CourseColumn.CreatedBy - 1)];
					c.UpdatedOn = (reader.IsDBNull(((int)CourseColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)CourseColumn.UpdatedOn - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)CourseColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)CourseColumn.UpdatedBy - 1)];
					c.DeletedOn = (reader.IsDBNull(((int)CourseColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)CourseColumn.DeletedOn - 1)];
					c.DeletedBy = (reader.IsDBNull(((int)CourseColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)CourseColumn.DeletedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Course"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Course"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Course entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)CourseColumn.ID - 1)];
			entity.Course_Name = (System.String)reader[((int)CourseColumn.Course_Name - 1)];
			entity.Course_Scope = (System.Int32)reader[((int)CourseColumn.Course_Scope - 1)];
			entity.Duration = (System.Int32)reader[((int)CourseColumn.Duration - 1)];
			entity.DurationType_ID = (System.Int32)reader[((int)CourseColumn.DurationType_ID - 1)];
			entity.Is_Deleted = (reader.IsDBNull(((int)CourseColumn.Is_Deleted - 1)))?null:(System.Boolean?)reader[((int)CourseColumn.Is_Deleted - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)CourseColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)CourseColumn.CreatedOn - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)CourseColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)CourseColumn.CreatedBy - 1)];
			entity.UpdatedOn = (reader.IsDBNull(((int)CourseColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)CourseColumn.UpdatedOn - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)CourseColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)CourseColumn.UpdatedBy - 1)];
			entity.DeletedOn = (reader.IsDBNull(((int)CourseColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)CourseColumn.DeletedOn - 1)];
			entity.DeletedBy = (reader.IsDBNull(((int)CourseColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)CourseColumn.DeletedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Course"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Course"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Course entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.Course_Name = (System.String)dataRow["Course_Name"];
			entity.Course_Scope = (System.Int32)dataRow["Course_Scope"];
			entity.Duration = (System.Int32)dataRow["Duration"];
			entity.DurationType_ID = (System.Int32)dataRow["DurationType_ID"];
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
		/// <param name="entity">The <see cref="Library.BLL.Course"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Course Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Course entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the Library.BLL.Course object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Course instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Course Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Course entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region CourseChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Course</c>
	///</summary>
	public enum CourseChildEntityTypes
	{
	}
	
	#endregion CourseChildEntityTypes
	
	#region CourseFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CourseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseFilterBuilder : SqlFilterBuilder<CourseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseFilterBuilder class.
		/// </summary>
		public CourseFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseFilterBuilder
	
	#region CourseParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CourseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseParameterBuilder : ParameterizedSqlFilterBuilder<CourseColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseParameterBuilder class.
		/// </summary>
		public CourseParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseParameterBuilder
	
	#region CourseSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CourseColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CourseSortBuilder : SqlSortBuilder<CourseColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseSqlSortBuilder class.
		/// </summary>
		public CourseSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CourseSortBuilder
	
} // end namespace
