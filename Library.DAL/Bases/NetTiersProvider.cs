#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Library.BLL;

#endregion

namespace Library.DAL.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current IntroducerProviderBase instance.
		///</summary>
		public virtual IntroducerProviderBase IntroducerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AuthorProviderBase instance.
		///</summary>
		public virtual AuthorProviderBase AuthorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PublisherProviderBase instance.
		///</summary>
		public virtual PublisherProviderBase PublisherProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeProviderBase instance.
		///</summary>
		public virtual EmployeeProviderBase EmployeeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UsersProviderBase instance.
		///</summary>
		public virtual UsersProviderBase UsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CourseProviderBase instance.
		///</summary>
		public virtual CourseProviderBase CourseProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BookTypeProviderBase instance.
		///</summary>
		public virtual BookTypeProviderBase BookTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BookImageProviderBase instance.
		///</summary>
		public virtual BookImageProviderBase BookImageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserTypeProviderBase instance.
		///</summary>
		public virtual UserTypeProviderBase UserTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BookProviderBase instance.
		///</summary>
		public virtual BookProviderBase BookProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current Book_AuthorProviderBase instance.
		///</summary>
		public virtual Book_AuthorProviderBase Book_AuthorProvider{get {throw new NotImplementedException();}}
		
		
	}
}
