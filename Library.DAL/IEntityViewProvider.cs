﻿#region Using Directives
using System;
using Library.BLL;
#endregion
namespace Library.DAL
{
	/// <summary>
	/// Defines the common data access methods that can be used by the
	/// ReadOnlyDataSource control to interact with the underlying data store.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	public interface IEntityViewProvider<Entity> where Entity : new()
	{
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		VList<Entity> Get(TransactionManager mgr, String whereClause, String orderBy, int start, int pageLength, out int count);

		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of rows in the data source.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		VList<Entity> GetPaged(TransactionManager mgr, String whereClause, String orderBy, int start, int pageLength, out int count);

		/// <summary>
		/// Gets all rows from the DataSource.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		VList<Entity> GetAll(TransactionManager mgr, int start, int pageLength, out int count);
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="mgr">A <see cref="TransactionManager"/> object.</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of Entity objects.</returns>
		VList<Entity> Find(TransactionManager mgr, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count);
		
	}
}
