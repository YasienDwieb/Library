#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using Library.BLL;
using Library.DAL;
using Library.DAL.Bases;

#endregion

namespace Library.DAL
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("Library.DAL") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region IntroducerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Introducer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IntroducerProviderBase IntroducerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IntroducerProvider;
			}
		}
		
		#endregion
		
		#region AuthorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Author"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AuthorProviderBase AuthorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AuthorProvider;
			}
		}
		
		#endregion
		
		#region PublisherProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Publisher"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PublisherProviderBase PublisherProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PublisherProvider;
			}
		}
		
		#endregion
		
		#region EmployeeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Employee"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmployeeProviderBase EmployeeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmployeeProvider;
			}
		}
		
		#endregion
		
		#region UsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Users"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UsersProviderBase UsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UsersProvider;
			}
		}
		
		#endregion
		
		#region CourseProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Course"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CourseProviderBase CourseProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CourseProvider;
			}
		}
		
		#endregion
		
		#region BookTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BookType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BookTypeProviderBase BookTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BookTypeProvider;
			}
		}
		
		#endregion
		
		#region BookImageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="BookImage"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BookImageProviderBase BookImageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BookImageProvider;
			}
		}
		
		#endregion
		
		#region UserTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UserType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserTypeProviderBase UserTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserTypeProvider;
			}
		}
		
		#endregion
		
		#region BookProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Book"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static BookProviderBase BookProvider
		{
			get 
			{
				LoadProviders();
				return _provider.BookProvider;
			}
		}
		
		#endregion
		
		#region Book_AuthorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Book_Author"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static Book_AuthorProviderBase Book_AuthorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.Book_AuthorProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region IntroducerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerFilters : IntroducerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerFilters class.
		/// </summary>
		public IntroducerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntroducerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntroducerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntroducerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntroducerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntroducerFilters
	
	#region IntroducerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IntroducerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Introducer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntroducerQuery : IntroducerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntroducerQuery class.
		/// </summary>
		public IntroducerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntroducerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntroducerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntroducerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntroducerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntroducerQuery
		
	#region AuthorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorFilters : AuthorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorFilters class.
		/// </summary>
		public AuthorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuthorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuthorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuthorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuthorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuthorFilters
	
	#region AuthorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AuthorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AuthorQuery : AuthorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AuthorQuery class.
		/// </summary>
		public AuthorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AuthorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AuthorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AuthorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AuthorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AuthorQuery
		
	#region PublisherFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherFilters : PublisherFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherFilters class.
		/// </summary>
		public PublisherFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PublisherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PublisherFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PublisherFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PublisherFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PublisherFilters
	
	#region PublisherQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PublisherParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Publisher"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PublisherQuery : PublisherParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PublisherQuery class.
		/// </summary>
		public PublisherQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PublisherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PublisherQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PublisherQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PublisherQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PublisherQuery
		
	#region EmployeeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeFilters : EmployeeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		public EmployeeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeFilters
	
	#region EmployeeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmployeeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Employee"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmployeeQuery : EmployeeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		public EmployeeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmployeeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmployeeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmployeeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmployeeQuery
		
	#region UsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersFilters : UsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersFilters class.
		/// </summary>
		public UsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersFilters
	
	#region UsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersQuery : UsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersQuery class.
		/// </summary>
		public UsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersQuery
		
	#region CourseFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseFilters : CourseFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseFilters class.
		/// </summary>
		public CourseFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseFilters
	
	#region CourseQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CourseParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Course"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseQuery : CourseParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseQuery class.
		/// </summary>
		public CourseQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseQuery
		
	#region BookTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookTypeFilters : BookTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookTypeFilters class.
		/// </summary>
		public BookTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookTypeFilters
	
	#region BookTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BookTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BookType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookTypeQuery : BookTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookTypeQuery class.
		/// </summary>
		public BookTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookTypeQuery
		
	#region BookImageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageFilters : BookImageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageFilters class.
		/// </summary>
		public BookImageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookImageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookImageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookImageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookImageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookImageFilters
	
	#region BookImageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BookImageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="BookImage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookImageQuery : BookImageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookImageQuery class.
		/// </summary>
		public BookImageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookImageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookImageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookImageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookImageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookImageQuery
		
	#region UserTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeFilters : UserTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserTypeFilters class.
		/// </summary>
		public UserTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserTypeFilters
	
	#region UserTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeQuery : UserTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserTypeQuery class.
		/// </summary>
		public UserTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserTypeQuery
		
	#region BookFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookFilters : BookFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookFilters class.
		/// </summary>
		public BookFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookFilters
	
	#region BookQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="BookParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Book"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class BookQuery : BookParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BookQuery class.
		/// </summary>
		public BookQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the BookQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public BookQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the BookQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public BookQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion BookQuery
		
	#region Book_AuthorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorFilters : Book_AuthorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorFilters class.
		/// </summary>
		public Book_AuthorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Book_AuthorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Book_AuthorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Book_AuthorFilters
	
	#region Book_AuthorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="Book_AuthorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Book_Author"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Book_AuthorQuery : Book_AuthorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Book_AuthorQuery class.
		/// </summary>
		public Book_AuthorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Book_AuthorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Book_AuthorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Book_AuthorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Book_AuthorQuery
	#endregion

	
}
