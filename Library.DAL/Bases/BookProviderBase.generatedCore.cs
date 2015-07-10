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
	/// This class is the base class for any <see cref="BookProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class BookProviderBaseCore : EntityProviderBase<Library.BLL.Book, Library.BLL.BookKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByAuthor_IDFromBook_Author
		
		/// <summary>
		///		Gets Book objects from the datasource by Author_ID in the
		///		Book_Author table. Table Book is related to table Author
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="_author_ID"></param>
		/// <returns>Returns a typed collection of Book objects.</returns>
		public TList<Book> GetByAuthor_IDFromBook_Author(System.Int32 _author_ID)
		{
			int count = -1;
			return GetByAuthor_IDFromBook_Author(null,_author_ID, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Library.BLL.Book objects from the datasource by Author_ID in the
		///		Book_Author table. Table Book is related to table Author
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_author_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Book objects.</returns>
		public TList<Book> GetByAuthor_IDFromBook_Author(System.Int32 _author_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByAuthor_IDFromBook_Author(null, _author_ID, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Book objects from the datasource by Author_ID in the
		///		Book_Author table. Table Book is related to table Author
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_author_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Book objects.</returns>
		public TList<Book> GetByAuthor_IDFromBook_Author(TransactionManager transactionManager, System.Int32 _author_ID)
		{
			int count = -1;
			return GetByAuthor_IDFromBook_Author(transactionManager, _author_ID, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets Book objects from the datasource by Author_ID in the
		///		Book_Author table. Table Book is related to table Author
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Book objects.</returns>
		public TList<Book> GetByAuthor_IDFromBook_Author(TransactionManager transactionManager, System.Int32 _author_ID,int start, int pageLength)
		{
			int count = -1;
			return GetByAuthor_IDFromBook_Author(transactionManager, _author_ID, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets Book objects from the datasource by Author_ID in the
		///		Book_Author table. Table Book is related to table Author
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="_author_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Book objects.</returns>
		public TList<Book> GetByAuthor_IDFromBook_Author(System.Int32 _author_ID,int start, int pageLength, out int count)
		{
			
			return GetByAuthor_IDFromBook_Author(null, _author_ID, start, pageLength, out count);
		}


		/// <summary>
		///		Gets Book objects from the datasource by Author_ID in the
		///		Book_Author table. Table Book is related to table Author
		///		through the (M:N) relationship defined in the Book_Author table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_author_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of Book objects.</returns>
		public abstract TList<Book> GetByAuthor_IDFromBook_Author(TransactionManager transactionManager,System.Int32 _author_ID, int start, int pageLength, out int count);
		
		#endregion GetByAuthor_IDFromBook_Author
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Library.BLL.BookKey key)
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
		/// 	Gets rows from the datasource based on the FK_Book_BookType key.
		///		FK_Book_BookType Description: 
		/// </summary>
		/// <param name="_type_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByType_ID(System.Int32 _type_ID)
		{
			int count = -1;
			return GetByType_ID(_type_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_BookType key.
		///		FK_Book_BookType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_type_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		/// <remarks></remarks>
		public TList<Book> GetByType_ID(TransactionManager transactionManager, System.Int32 _type_ID)
		{
			int count = -1;
			return GetByType_ID(transactionManager, _type_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_BookType key.
		///		FK_Book_BookType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_type_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByType_ID(TransactionManager transactionManager, System.Int32 _type_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByType_ID(transactionManager, _type_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_BookType key.
		///		fK_Book_BookType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_type_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByType_ID(System.Int32 _type_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByType_ID(null, _type_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_BookType key.
		///		fK_Book_BookType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_type_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByType_ID(System.Int32 _type_ID, int start, int pageLength,out int count)
		{
			return GetByType_ID(null, _type_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_BookType key.
		///		FK_Book_BookType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_type_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public abstract TList<Book> GetByType_ID(TransactionManager transactionManager, System.Int32 _type_ID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Employee key.
		///		FK_Book_Employee Description: 
		/// </summary>
		/// <param name="_employeeI_D"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByEmployeeI_D(System.Int32 _employeeI_D)
		{
			int count = -1;
			return GetByEmployeeI_D(_employeeI_D, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Employee key.
		///		FK_Book_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeI_D"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		/// <remarks></remarks>
		public TList<Book> GetByEmployeeI_D(TransactionManager transactionManager, System.Int32 _employeeI_D)
		{
			int count = -1;
			return GetByEmployeeI_D(transactionManager, _employeeI_D, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Employee key.
		///		FK_Book_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeI_D"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByEmployeeI_D(TransactionManager transactionManager, System.Int32 _employeeI_D, int start, int pageLength)
		{
			int count = -1;
			return GetByEmployeeI_D(transactionManager, _employeeI_D, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Employee key.
		///		fK_Book_Employee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeI_D"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByEmployeeI_D(System.Int32 _employeeI_D, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmployeeI_D(null, _employeeI_D, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Employee key.
		///		fK_Book_Employee Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_employeeI_D"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByEmployeeI_D(System.Int32 _employeeI_D, int start, int pageLength,out int count)
		{
			return GetByEmployeeI_D(null, _employeeI_D, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Employee key.
		///		FK_Book_Employee Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_employeeI_D"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public abstract TList<Book> GetByEmployeeI_D(TransactionManager transactionManager, System.Int32 _employeeI_D, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Image key.
		///		FK_Book_Image Description: 
		/// </summary>
		/// <param name="_image_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByImage_ID(System.Int32 _image_ID)
		{
			int count = -1;
			return GetByImage_ID(_image_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Image key.
		///		FK_Book_Image Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_image_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		/// <remarks></remarks>
		public TList<Book> GetByImage_ID(TransactionManager transactionManager, System.Int32 _image_ID)
		{
			int count = -1;
			return GetByImage_ID(transactionManager, _image_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Image key.
		///		FK_Book_Image Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_image_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByImage_ID(TransactionManager transactionManager, System.Int32 _image_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByImage_ID(transactionManager, _image_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Image key.
		///		fK_Book_Image Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_image_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByImage_ID(System.Int32 _image_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByImage_ID(null, _image_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Image key.
		///		fK_Book_Image Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_image_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByImage_ID(System.Int32 _image_ID, int start, int pageLength,out int count)
		{
			return GetByImage_ID(null, _image_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Image key.
		///		FK_Book_Image Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_image_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public abstract TList<Book> GetByImage_ID(TransactionManager transactionManager, System.Int32 _image_ID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Introducer key.
		///		FK_Book_Introducer Description: 
		/// </summary>
		/// <param name="_introducer_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByIntroducer_ID(System.Int32? _introducer_ID)
		{
			int count = -1;
			return GetByIntroducer_ID(_introducer_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Introducer key.
		///		FK_Book_Introducer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_introducer_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		/// <remarks></remarks>
		public TList<Book> GetByIntroducer_ID(TransactionManager transactionManager, System.Int32? _introducer_ID)
		{
			int count = -1;
			return GetByIntroducer_ID(transactionManager, _introducer_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Introducer key.
		///		FK_Book_Introducer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_introducer_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByIntroducer_ID(TransactionManager transactionManager, System.Int32? _introducer_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByIntroducer_ID(transactionManager, _introducer_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Introducer key.
		///		fK_Book_Introducer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_introducer_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByIntroducer_ID(System.Int32? _introducer_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByIntroducer_ID(null, _introducer_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Introducer key.
		///		fK_Book_Introducer Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_introducer_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByIntroducer_ID(System.Int32? _introducer_ID, int start, int pageLength,out int count)
		{
			return GetByIntroducer_ID(null, _introducer_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Introducer key.
		///		FK_Book_Introducer Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_introducer_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public abstract TList<Book> GetByIntroducer_ID(TransactionManager transactionManager, System.Int32? _introducer_ID, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Publisher key.
		///		FK_Book_Publisher Description: 
		/// </summary>
		/// <param name="_publisher_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByPublisher_ID(System.Int32 _publisher_ID)
		{
			int count = -1;
			return GetByPublisher_ID(_publisher_ID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Publisher key.
		///		FK_Book_Publisher Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_publisher_ID"></param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		/// <remarks></remarks>
		public TList<Book> GetByPublisher_ID(TransactionManager transactionManager, System.Int32 _publisher_ID)
		{
			int count = -1;
			return GetByPublisher_ID(transactionManager, _publisher_ID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Publisher key.
		///		FK_Book_Publisher Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_publisher_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByPublisher_ID(TransactionManager transactionManager, System.Int32 _publisher_ID, int start, int pageLength)
		{
			int count = -1;
			return GetByPublisher_ID(transactionManager, _publisher_ID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Publisher key.
		///		fK_Book_Publisher Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_publisher_ID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByPublisher_ID(System.Int32 _publisher_ID, int start, int pageLength)
		{
			int count =  -1;
			return GetByPublisher_ID(null, _publisher_ID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Publisher key.
		///		fK_Book_Publisher Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_publisher_ID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public TList<Book> GetByPublisher_ID(System.Int32 _publisher_ID, int start, int pageLength,out int count)
		{
			return GetByPublisher_ID(null, _publisher_ID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Book_Publisher key.
		///		FK_Book_Publisher Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_publisher_ID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Library.BLL.Book objects.</returns>
		public abstract TList<Book> GetByPublisher_ID(TransactionManager transactionManager, System.Int32 _publisher_ID, int start, int pageLength, out int count);
		
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
		public override Library.BLL.Book Get(TransactionManager transactionManager, Library.BLL.BookKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Book index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book"/> class.</returns>
		public Library.BLL.Book GetByID(System.Int32 _iD)
		{
			int count = -1;
			return GetByID(null,_iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book"/> class.</returns>
		public Library.BLL.Book GetByID(System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book"/> class.</returns>
		public Library.BLL.Book GetByID(TransactionManager transactionManager, System.Int32 _iD)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book"/> class.</returns>
		public Library.BLL.Book GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, _iD, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book index.
		/// </summary>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book"/> class.</returns>
		public Library.BLL.Book GetByID(System.Int32 _iD, int start, int pageLength, out int count)
		{
			return GetByID(null, _iD, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Book index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_iD"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Library.BLL.Book"/> class.</returns>
		public abstract Library.BLL.Book GetByID(TransactionManager transactionManager, System.Int32 _iD, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Book&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Book&gt;"/></returns>
		public static TList<Book> Fill(IDataReader reader, TList<Book> rows, int start, int pageLength)
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
				
				Library.BLL.Book c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Book")
					.Append("|").Append((System.Int32)reader[((int)BookColumn.ID - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Book>(
					key.ToString(), // EntityTrackingKey
					"Book",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Library.BLL.Book();
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
					c.ID = (System.Int32)reader[((int)BookColumn.ID - 1)];
					c.Name = (System.String)reader[((int)BookColumn.Name - 1)];
					c.Publisher = (System.String)reader[((int)BookColumn.Publisher - 1)];
					c.Publish_Date = (reader.IsDBNull(((int)BookColumn.Publish_Date - 1)))?null:(System.DateTime?)reader[((int)BookColumn.Publish_Date - 1)];
					c.IsAvailablePdf = (reader.IsDBNull(((int)BookColumn.IsAvailablePdf - 1)))?null:(System.Boolean?)reader[((int)BookColumn.IsAvailablePdf - 1)];
					c.IsAvailablePaper = (reader.IsDBNull(((int)BookColumn.IsAvailablePaper - 1)))?null:(System.Boolean?)reader[((int)BookColumn.IsAvailablePaper - 1)];
					c.IsBorrowed = (System.Boolean)reader[((int)BookColumn.IsBorrowed - 1)];
					c.User_ID = (System.Int32)reader[((int)BookColumn.User_ID - 1)];
					c.BorrowDate = (reader.IsDBNull(((int)BookColumn.BorrowDate - 1)))?null:(System.DateTime?)reader[((int)BookColumn.BorrowDate - 1)];
					c.Borrow_Times = (reader.IsDBNull(((int)BookColumn.Borrow_Times - 1)))?null:(System.Int32?)reader[((int)BookColumn.Borrow_Times - 1)];
					c.IsLost = (reader.IsDBNull(((int)BookColumn.IsLost - 1)))?null:(System.Boolean?)reader[((int)BookColumn.IsLost - 1)];
					c.Type_ID = (System.Int32)reader[((int)BookColumn.Type_ID - 1)];
					c.Publisher_ID = (System.Int32)reader[((int)BookColumn.Publisher_ID - 1)];
					c.Papers_no = (reader.IsDBNull(((int)BookColumn.Papers_no - 1)))?null:(System.Int32?)reader[((int)BookColumn.Papers_no - 1)];
					c.Introducer_ID = (reader.IsDBNull(((int)BookColumn.Introducer_ID - 1)))?null:(System.Int32?)reader[((int)BookColumn.Introducer_ID - 1)];
					c.EmployeeI_D = (System.Int32)reader[((int)BookColumn.EmployeeI_D - 1)];
					c.Size = (reader.IsDBNull(((int)BookColumn.Size - 1)))?null:(System.Double?)reader[((int)BookColumn.Size - 1)];
					c.Price = (reader.IsDBNull(((int)BookColumn.Price - 1)))?null:(System.Int32?)reader[((int)BookColumn.Price - 1)];
					c.Pdf_Link = (reader.IsDBNull(((int)BookColumn.Pdf_Link - 1)))?null:(System.String)reader[((int)BookColumn.Pdf_Link - 1)];
					c.Image_ID = (System.Int32)reader[((int)BookColumn.Image_ID - 1)];
					c.ISBN = (reader.IsDBNull(((int)BookColumn.ISBN - 1)))?null:(System.String)reader[((int)BookColumn.ISBN - 1)];
					c.CreatedOn = (reader.IsDBNull(((int)BookColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)BookColumn.CreatedOn - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)BookColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)BookColumn.CreatedBy - 1)];
					c.UpdatedOn = (reader.IsDBNull(((int)BookColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)BookColumn.UpdatedOn - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)BookColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)BookColumn.UpdatedBy - 1)];
					c.DeletedOn = (reader.IsDBNull(((int)BookColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)BookColumn.DeletedOn - 1)];
					c.DeletedBy = (reader.IsDBNull(((int)BookColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)BookColumn.DeletedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Book"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Book"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Library.BLL.Book entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Int32)reader[((int)BookColumn.ID - 1)];
			entity.Name = (System.String)reader[((int)BookColumn.Name - 1)];
			entity.Publisher = (System.String)reader[((int)BookColumn.Publisher - 1)];
			entity.Publish_Date = (reader.IsDBNull(((int)BookColumn.Publish_Date - 1)))?null:(System.DateTime?)reader[((int)BookColumn.Publish_Date - 1)];
			entity.IsAvailablePdf = (reader.IsDBNull(((int)BookColumn.IsAvailablePdf - 1)))?null:(System.Boolean?)reader[((int)BookColumn.IsAvailablePdf - 1)];
			entity.IsAvailablePaper = (reader.IsDBNull(((int)BookColumn.IsAvailablePaper - 1)))?null:(System.Boolean?)reader[((int)BookColumn.IsAvailablePaper - 1)];
			entity.IsBorrowed = (System.Boolean)reader[((int)BookColumn.IsBorrowed - 1)];
			entity.User_ID = (System.Int32)reader[((int)BookColumn.User_ID - 1)];
			entity.BorrowDate = (reader.IsDBNull(((int)BookColumn.BorrowDate - 1)))?null:(System.DateTime?)reader[((int)BookColumn.BorrowDate - 1)];
			entity.Borrow_Times = (reader.IsDBNull(((int)BookColumn.Borrow_Times - 1)))?null:(System.Int32?)reader[((int)BookColumn.Borrow_Times - 1)];
			entity.IsLost = (reader.IsDBNull(((int)BookColumn.IsLost - 1)))?null:(System.Boolean?)reader[((int)BookColumn.IsLost - 1)];
			entity.Type_ID = (System.Int32)reader[((int)BookColumn.Type_ID - 1)];
			entity.Publisher_ID = (System.Int32)reader[((int)BookColumn.Publisher_ID - 1)];
			entity.Papers_no = (reader.IsDBNull(((int)BookColumn.Papers_no - 1)))?null:(System.Int32?)reader[((int)BookColumn.Papers_no - 1)];
			entity.Introducer_ID = (reader.IsDBNull(((int)BookColumn.Introducer_ID - 1)))?null:(System.Int32?)reader[((int)BookColumn.Introducer_ID - 1)];
			entity.EmployeeI_D = (System.Int32)reader[((int)BookColumn.EmployeeI_D - 1)];
			entity.Size = (reader.IsDBNull(((int)BookColumn.Size - 1)))?null:(System.Double?)reader[((int)BookColumn.Size - 1)];
			entity.Price = (reader.IsDBNull(((int)BookColumn.Price - 1)))?null:(System.Int32?)reader[((int)BookColumn.Price - 1)];
			entity.Pdf_Link = (reader.IsDBNull(((int)BookColumn.Pdf_Link - 1)))?null:(System.String)reader[((int)BookColumn.Pdf_Link - 1)];
			entity.Image_ID = (System.Int32)reader[((int)BookColumn.Image_ID - 1)];
			entity.ISBN = (reader.IsDBNull(((int)BookColumn.ISBN - 1)))?null:(System.String)reader[((int)BookColumn.ISBN - 1)];
			entity.CreatedOn = (reader.IsDBNull(((int)BookColumn.CreatedOn - 1)))?null:(System.DateTime?)reader[((int)BookColumn.CreatedOn - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)BookColumn.CreatedBy - 1)))?null:(System.Int32?)reader[((int)BookColumn.CreatedBy - 1)];
			entity.UpdatedOn = (reader.IsDBNull(((int)BookColumn.UpdatedOn - 1)))?null:(System.DateTime?)reader[((int)BookColumn.UpdatedOn - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)BookColumn.UpdatedBy - 1)))?null:(System.Int32?)reader[((int)BookColumn.UpdatedBy - 1)];
			entity.DeletedOn = (reader.IsDBNull(((int)BookColumn.DeletedOn - 1)))?null:(System.DateTime?)reader[((int)BookColumn.DeletedOn - 1)];
			entity.DeletedBy = (reader.IsDBNull(((int)BookColumn.DeletedBy - 1)))?null:(System.Int32?)reader[((int)BookColumn.DeletedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Library.BLL.Book"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Library.BLL.Book"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Library.BLL.Book entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Int32)dataRow["ID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Publisher = (System.String)dataRow["Publisher"];
			entity.Publish_Date = Convert.IsDBNull(dataRow["Publish_Date"]) ? null : (System.DateTime?)dataRow["Publish_Date"];
			entity.IsAvailablePdf = Convert.IsDBNull(dataRow["IsAvailablePdf"]) ? null : (System.Boolean?)dataRow["IsAvailablePdf"];
			entity.IsAvailablePaper = Convert.IsDBNull(dataRow["IsAvailablePaper"]) ? null : (System.Boolean?)dataRow["IsAvailablePaper"];
			entity.IsBorrowed = (System.Boolean)dataRow["IsBorrowed"];
			entity.User_ID = (System.Int32)dataRow["User_ID"];
			entity.BorrowDate = Convert.IsDBNull(dataRow["BorrowDate"]) ? null : (System.DateTime?)dataRow["BorrowDate"];
			entity.Borrow_Times = Convert.IsDBNull(dataRow["Borrow_Times"]) ? null : (System.Int32?)dataRow["Borrow_Times"];
			entity.IsLost = Convert.IsDBNull(dataRow["IsLost"]) ? null : (System.Boolean?)dataRow["IsLost"];
			entity.Type_ID = (System.Int32)dataRow["Type_ID"];
			entity.Publisher_ID = (System.Int32)dataRow["Publisher_ID"];
			entity.Papers_no = Convert.IsDBNull(dataRow["Papers_no"]) ? null : (System.Int32?)dataRow["Papers_no"];
			entity.Introducer_ID = Convert.IsDBNull(dataRow["Introducer_ID"]) ? null : (System.Int32?)dataRow["Introducer_ID"];
			entity.EmployeeI_D = (System.Int32)dataRow["EmployeeI_D"];
			entity.Size = Convert.IsDBNull(dataRow["Size"]) ? null : (System.Double?)dataRow["Size"];
			entity.Price = Convert.IsDBNull(dataRow["Price"]) ? null : (System.Int32?)dataRow["Price"];
			entity.Pdf_Link = Convert.IsDBNull(dataRow["Pdf_Link"]) ? null : (System.String)dataRow["Pdf_Link"];
			entity.Image_ID = (System.Int32)dataRow["Image_ID"];
			entity.ISBN = Convert.IsDBNull(dataRow["ISBN"]) ? null : (System.String)dataRow["ISBN"];
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
		/// <param name="entity">The <see cref="Library.BLL.Book"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Library.BLL.Book Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Library.BLL.Book entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region Type_IDSource	
			if (CanDeepLoad(entity, "BookType|Type_IDSource", deepLoadType, innerList) 
				&& entity.Type_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Type_ID;
				BookType tmpEntity = EntityManager.LocateEntity<BookType>(EntityLocator.ConstructKeyFromPkItems(typeof(BookType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Type_IDSource = tmpEntity;
				else
					entity.Type_IDSource = DataRepository.BookTypeProvider.GetByID(transactionManager, entity.Type_ID);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Type_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Type_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BookTypeProvider.DeepLoad(transactionManager, entity.Type_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Type_IDSource

			#region EmployeeI_DSource	
			if (CanDeepLoad(entity, "Employee|EmployeeI_DSource", deepLoadType, innerList) 
				&& entity.EmployeeI_DSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmployeeI_D;
				Employee tmpEntity = EntityManager.LocateEntity<Employee>(EntityLocator.ConstructKeyFromPkItems(typeof(Employee), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmployeeI_DSource = tmpEntity;
				else
					entity.EmployeeI_DSource = DataRepository.EmployeeProvider.GetByID(transactionManager, entity.EmployeeI_D);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EmployeeI_DSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.EmployeeI_DSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EmployeeProvider.DeepLoad(transactionManager, entity.EmployeeI_DSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion EmployeeI_DSource

			#region Image_IDSource	
			if (CanDeepLoad(entity, "BookImage|Image_IDSource", deepLoadType, innerList) 
				&& entity.Image_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Image_ID;
				BookImage tmpEntity = EntityManager.LocateEntity<BookImage>(EntityLocator.ConstructKeyFromPkItems(typeof(BookImage), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Image_IDSource = tmpEntity;
				else
					entity.Image_IDSource = DataRepository.BookImageProvider.GetByID(transactionManager, entity.Image_ID);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Image_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Image_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.BookImageProvider.DeepLoad(transactionManager, entity.Image_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Image_IDSource

			#region Introducer_IDSource	
			if (CanDeepLoad(entity, "Introducer|Introducer_IDSource", deepLoadType, innerList) 
				&& entity.Introducer_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Introducer_ID ?? (int)0);
				Introducer tmpEntity = EntityManager.LocateEntity<Introducer>(EntityLocator.ConstructKeyFromPkItems(typeof(Introducer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Introducer_IDSource = tmpEntity;
				else
					entity.Introducer_IDSource = DataRepository.IntroducerProvider.GetByID(transactionManager, (entity.Introducer_ID ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Introducer_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Introducer_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.IntroducerProvider.DeepLoad(transactionManager, entity.Introducer_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Introducer_IDSource

			#region Publisher_IDSource	
			if (CanDeepLoad(entity, "Publisher|Publisher_IDSource", deepLoadType, innerList) 
				&& entity.Publisher_IDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.Publisher_ID;
				Publisher tmpEntity = EntityManager.LocateEntity<Publisher>(EntityLocator.ConstructKeyFromPkItems(typeof(Publisher), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.Publisher_IDSource = tmpEntity;
				else
					entity.Publisher_IDSource = DataRepository.PublisherProvider.GetByID(transactionManager, entity.Publisher_ID);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Publisher_IDSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Publisher_IDSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PublisherProvider.DeepLoad(transactionManager, entity.Publisher_IDSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion Publisher_IDSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByID methods when available
			
			#region Author_IDAuthorCollection_From_Book_Author
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<Author>|Author_IDAuthorCollection_From_Book_Author", deepLoadType, innerList))
			{
				entity.Author_IDAuthorCollection_From_Book_Author = DataRepository.AuthorProvider.GetByBook_IDFromBook_Author(transactionManager, entity.ID);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'Author_IDAuthorCollection_From_Book_Author' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.Author_IDAuthorCollection_From_Book_Author != null)
				{
					deepHandles.Add("Author_IDAuthorCollection_From_Book_Author",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< Author >) DataRepository.AuthorProvider.DeepLoad,
						new object[] { transactionManager, entity.Author_IDAuthorCollection_From_Book_Author, deep, deepLoadType, childTypes, innerList }
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

				entity.Book_AuthorCollection = DataRepository.Book_AuthorProvider.GetByBook_ID(transactionManager, entity.ID);

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
		/// Deep Save the entire object graph of the Library.BLL.Book object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Library.BLL.Book instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Library.BLL.Book Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Library.BLL.Book entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region Type_IDSource
			if (CanDeepSave(entity, "BookType|Type_IDSource", deepSaveType, innerList) 
				&& entity.Type_IDSource != null)
			{
				DataRepository.BookTypeProvider.Save(transactionManager, entity.Type_IDSource);
				entity.Type_ID = entity.Type_IDSource.ID;
			}
			#endregion 
			
			#region EmployeeI_DSource
			if (CanDeepSave(entity, "Employee|EmployeeI_DSource", deepSaveType, innerList) 
				&& entity.EmployeeI_DSource != null)
			{
				DataRepository.EmployeeProvider.Save(transactionManager, entity.EmployeeI_DSource);
				entity.EmployeeI_D = entity.EmployeeI_DSource.ID;
			}
			#endregion 
			
			#region Image_IDSource
			if (CanDeepSave(entity, "BookImage|Image_IDSource", deepSaveType, innerList) 
				&& entity.Image_IDSource != null)
			{
				DataRepository.BookImageProvider.Save(transactionManager, entity.Image_IDSource);
				entity.Image_ID = entity.Image_IDSource.ID;
			}
			#endregion 
			
			#region Introducer_IDSource
			if (CanDeepSave(entity, "Introducer|Introducer_IDSource", deepSaveType, innerList) 
				&& entity.Introducer_IDSource != null)
			{
				DataRepository.IntroducerProvider.Save(transactionManager, entity.Introducer_IDSource);
				entity.Introducer_ID = entity.Introducer_IDSource.ID;
			}
			#endregion 
			
			#region Publisher_IDSource
			if (CanDeepSave(entity, "Publisher|Publisher_IDSource", deepSaveType, innerList) 
				&& entity.Publisher_IDSource != null)
			{
				DataRepository.PublisherProvider.Save(transactionManager, entity.Publisher_IDSource);
				entity.Publisher_ID = entity.Publisher_IDSource.ID;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region Author_IDAuthorCollection_From_Book_Author>
			if (CanDeepSave(entity.Author_IDAuthorCollection_From_Book_Author, "List<Author>|Author_IDAuthorCollection_From_Book_Author", deepSaveType, innerList))
			{
				if (entity.Author_IDAuthorCollection_From_Book_Author.Count > 0 || entity.Author_IDAuthorCollection_From_Book_Author.DeletedItems.Count > 0)
				{
					DataRepository.AuthorProvider.Save(transactionManager, entity.Author_IDAuthorCollection_From_Book_Author); 
					deepHandles.Add("Author_IDAuthorCollection_From_Book_Author",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<Author>) DataRepository.AuthorProvider.DeepSave,
						new object[] { transactionManager, entity.Author_IDAuthorCollection_From_Book_Author, deepSaveType, childTypes, innerList }
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
						if(child.Book_IDSource != null)
						{
								child.Book_ID = child.Book_IDSource.ID;
						}

						if(child.Author_IDSource != null)
						{
								child.Author_ID = child.Author_IDSource.ID;
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
	
	#region BookChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Library.BLL.Book</c>
	///</summary>
	public enum BookChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>BookType</c> at Type_IDSource
		///</summary>
		[ChildEntityType(typeof(BookType))]
		BookType,
		
		///<summary>
		/// Composite Property for <c>Employee</c> at EmployeeI_DSource
		///</summary>
		[ChildEntityType(typeof(Employee))]
		Employee,
		
		///<summary>
		/// Composite Property for <c>BookImage</c> at Image_IDSource
		///</summary>
		[ChildEntityType(typeof(BookImage))]
		BookImage,
		
		///<summary>
		/// Composite Property for <c>Introducer</c> at Introducer_IDSource
		///</summary>
		[ChildEntityType(typeof(Introducer))]
		Introducer,
		
		///<summary>
		/// Composite Property for <c>Publisher</c> at Publisher_IDSource
		///</summary>
		[ChildEntityType(typeof(Publisher))]
		Publisher,
		///<summary>
		/// Collection of <c>Book</c> as ManyToMany for AuthorCollection_From_Book_Author
		///</summary>
		[ChildEntityType(typeof(TList<Author>))]
		Author_IDAuthorCollection_From_Book_Author,
		///<summary>
		/// Collection of <c>Book</c> as OneToMany for Book_AuthorCollection
		///</summary>
		[ChildEntityType(typeof(TList<Book_Author>))]
		Book_AuthorCollection,
	}
	
	#endregion BookChildEntityTypes
	
	#region BookFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;BookColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookFilterBuilder : SqlFilterBuilder<BookColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookFilterBuilder class.
		/// </summary>
		public BookFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookFilterBuilder
	
	#region BookParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;BookColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookParameterBuilder : ParameterizedSqlFilterBuilder<BookColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookParameterBuilder class.
		/// </summary>
		public BookParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookParameterBuilder
	
	#region BookSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;BookColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class BookSortBuilder : SqlSortBuilder<BookColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookSqlSortBuilder class.
		/// </summary>
		public BookSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion BookSortBuilder
	
} // end namespace
