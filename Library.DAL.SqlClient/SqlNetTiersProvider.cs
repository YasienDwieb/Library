#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Library.BLL;
using Library.DAL;
using Library.DAL.Bases;

#endregion

namespace Library.DAL.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : Library.DAL.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "IntroducerProvider"
			
		private SqlIntroducerProvider innerSqlIntroducerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Introducer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IntroducerProviderBase IntroducerProvider
		{
			get
			{
				if (innerSqlIntroducerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIntroducerProvider == null)
						{
							this.innerSqlIntroducerProvider = new SqlIntroducerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIntroducerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlIntroducerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIntroducerProvider SqlIntroducerProvider
		{
			get {return IntroducerProvider as SqlIntroducerProvider;}
		}
		
		#endregion
		
		
		#region "AuthorProvider"
			
		private SqlAuthorProvider innerSqlAuthorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Author"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AuthorProviderBase AuthorProvider
		{
			get
			{
				if (innerSqlAuthorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAuthorProvider == null)
						{
							this.innerSqlAuthorProvider = new SqlAuthorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAuthorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlAuthorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAuthorProvider SqlAuthorProvider
		{
			get {return AuthorProvider as SqlAuthorProvider;}
		}
		
		#endregion
		
		
		#region "PublisherProvider"
			
		private SqlPublisherProvider innerSqlPublisherProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Publisher"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override PublisherProviderBase PublisherProvider
		{
			get
			{
				if (innerSqlPublisherProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlPublisherProvider == null)
						{
							this.innerSqlPublisherProvider = new SqlPublisherProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlPublisherProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlPublisherProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlPublisherProvider SqlPublisherProvider
		{
			get {return PublisherProvider as SqlPublisherProvider;}
		}
		
		#endregion
		
		
		#region "EmployeeProvider"
			
		private SqlEmployeeProvider innerSqlEmployeeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmployeeProviderBase EmployeeProvider
		{
			get
			{
				if (innerSqlEmployeeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmployeeProvider == null)
						{
							this.innerSqlEmployeeProvider = new SqlEmployeeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmployeeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEmployeeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmployeeProvider SqlEmployeeProvider
		{
			get {return EmployeeProvider as SqlEmployeeProvider;}
		}
		
		#endregion
		
		
		#region "UsersProvider"
			
		private SqlUsersProvider innerSqlUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Users"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UsersProviderBase UsersProvider
		{
			get
			{
				if (innerSqlUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUsersProvider == null)
						{
							this.innerSqlUsersProvider = new SqlUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUsersProvider SqlUsersProvider
		{
			get {return UsersProvider as SqlUsersProvider;}
		}
		
		#endregion
		
		
		#region "CourseProvider"
			
		private SqlCourseProvider innerSqlCourseProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Course"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CourseProviderBase CourseProvider
		{
			get
			{
				if (innerSqlCourseProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCourseProvider == null)
						{
							this.innerSqlCourseProvider = new SqlCourseProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCourseProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCourseProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCourseProvider SqlCourseProvider
		{
			get {return CourseProvider as SqlCourseProvider;}
		}
		
		#endregion
		
		
		#region "BookTypeProvider"
			
		private SqlBookTypeProvider innerSqlBookTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BookType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BookTypeProviderBase BookTypeProvider
		{
			get
			{
				if (innerSqlBookTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBookTypeProvider == null)
						{
							this.innerSqlBookTypeProvider = new SqlBookTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBookTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlBookTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBookTypeProvider SqlBookTypeProvider
		{
			get {return BookTypeProvider as SqlBookTypeProvider;}
		}
		
		#endregion
		
		
		#region "BookImageProvider"
			
		private SqlBookImageProvider innerSqlBookImageProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="BookImage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BookImageProviderBase BookImageProvider
		{
			get
			{
				if (innerSqlBookImageProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBookImageProvider == null)
						{
							this.innerSqlBookImageProvider = new SqlBookImageProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBookImageProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlBookImageProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBookImageProvider SqlBookImageProvider
		{
			get {return BookImageProvider as SqlBookImageProvider;}
		}
		
		#endregion
		
		
		#region "UserTypeProvider"
			
		private SqlUserTypeProvider innerSqlUserTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UserType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserTypeProviderBase UserTypeProvider
		{
			get
			{
				if (innerSqlUserTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserTypeProvider == null)
						{
							this.innerSqlUserTypeProvider = new SqlUserTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUserTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserTypeProvider SqlUserTypeProvider
		{
			get {return UserTypeProvider as SqlUserTypeProvider;}
		}
		
		#endregion
		
		
		#region "BookProvider"
			
		private SqlBookProvider innerSqlBookProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Book"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override BookProviderBase BookProvider
		{
			get
			{
				if (innerSqlBookProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBookProvider == null)
						{
							this.innerSqlBookProvider = new SqlBookProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBookProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlBookProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBookProvider SqlBookProvider
		{
			get {return BookProvider as SqlBookProvider;}
		}
		
		#endregion
		
		
		#region "Book_AuthorProvider"
			
		private SqlBook_AuthorProvider innerSqlBook_AuthorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Book_Author"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override Book_AuthorProviderBase Book_AuthorProvider
		{
			get
			{
				if (innerSqlBook_AuthorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlBook_AuthorProvider == null)
						{
							this.innerSqlBook_AuthorProvider = new SqlBook_AuthorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlBook_AuthorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlBook_AuthorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlBook_AuthorProvider SqlBook_AuthorProvider
		{
			get {return Book_AuthorProvider as SqlBook_AuthorProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
