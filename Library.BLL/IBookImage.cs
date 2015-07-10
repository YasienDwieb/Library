﻿using System;
using System.ComponentModel;

namespace Library.BLL
{
	/// <summary>
	///		The data structure representation of the 'BookImage' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IBookImage 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "BookImage"</remarks>
		System.Int32 ID { get; set; }
				
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// Format : 
		/// </summary>
		System.String  Format  { get; set; }
		
		/// <summary>
		/// Size : 
		/// </summary>
		System.String  Size  { get; set; }
		
		/// <summary>
		/// Link : 
		/// </summary>
		System.String  Link  { get; set; }
		
		/// <summary>
		/// IsAvailable : 
		/// </summary>
		System.String  IsAvailable  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _bookImage_ID
		/// </summary>	
		TList<Book> BookCollection {  get;  set;}	

		#endregion Data Properties

	}
}

