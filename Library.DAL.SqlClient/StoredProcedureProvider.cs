﻿#region Using Directives
using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Library.BLL;
#endregion

namespace Library.DAL.SqlClient
{
	/// <summary>
	/// Summary description for Procedures.
	/// </summary>
	[Serializable()]
	[XmlRoot("root")]
	public sealed class StoredProcedureProvider
	{
		private ArrayList procedures;
		private Hashtable shortNameProcedures;
		private Hashtable longNameProcedures;
		private static StoredProcedureProvider current = null;
		private static object syncRoot = new object();
		
		/// <summary>
		/// Creates a new <see cref="StoredProcedureProvider"/> instance.
		/// </summary>
		public StoredProcedureProvider()
		{
			procedures = new ArrayList();
		}

		/// <summary>
		/// Gets the current <see cref="StoredProcedureProvider"/> singleton instance.
		/// </summary>
		/// <value><see cref="StoredProcedureProvider"/></value>
		public static StoredProcedureProvider Current
		{
			get
			{
				if (current == null)
				{
					lock(syncRoot)
					{
						if (current == null)
						{
							current = (StoredProcedureProvider) StoredProcedureProvider.Deserialize();
						}
					}
				}
				return current;
			}
		}

		/// <summary>
		/// Gets or sets the procedures.
		/// </summary>
		/// <value>An <see cref="ArrayList"/> of <see cref="Procedure"/> objects.</value>
		[XmlArray("procedures")]
		[XmlArrayItem("procedure",typeof(Procedure))]
		public ArrayList Procedures
		{
			get
			{
				return procedures;
			}
			set
			{
				procedures = value;
				InitializeProcedureLookupTables();
			}
		}

		#region Public

		/// <summary>
		/// Gets or sets the <see cref="Procedure"/> instance with the specified name.
		/// </summary>
		public Procedure this[string name]
		{
			get
			{
				lock(syncRoot)
				{
					if (longNameProcedures == null)
						InitializeProcedureLookupTables();
				}
				
				Procedure result = null;
				
				result = longNameProcedures[name] as Procedure;
				if (result == null)
				{
					result = shortNameProcedures[name] as Procedure;
				}
				return result;
			}
		}
		
		/// <summary>
		/// Gets or sets the <see cref="Procedure"/> instance at the specified index.
		/// </summary>
		public Procedure this[int index]
		{
			get
			{
				return (Procedure) procedures[index];
			}
		}

		#endregion
		
		#region Serialization
		
		/// <summary>
		/// Serializes the specified filename.
		/// </summary>
		/// <param name="filename">Filename.</param>
		public void Serialize(string filename)
		{
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			System.IO.FileStream fileStream = new System.IO.FileStream(filename,System.IO.FileMode.CreateNew,System.IO.FileAccess.ReadWrite,System.IO.FileShare.ReadWrite);
			XmlSerializer serializer = new XmlSerializer(this.GetType());
			serializer.Serialize(fileStream,this);
			fileStream.Close();
		}

		#endregion

		#region Deserialization

		/// <summary>
		/// Deserializes this instance.
		/// </summary>
		/// <returns></returns>
		private static object Deserialize ()
		{
			string nameSpace = "Library.DAL.SqlClient"; //System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
			string resourceName = string.Format("{0}.Procedures.xml",nameSpace);
			System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
			XmlSerializer serializer = new XmlSerializer(typeof(StoredProcedureProvider));
			return serializer.Deserialize(stream);
		}

		#endregion
		
		#region Embedded XML Queries
		
		/// <summary>
	    /// Get the query text from the embedded xml file.
	    /// </summary>
	    /// <param name="name">The name of the query.</param>
	    /// <returns>the text of the query</returns>
	    private static string GetProcedureBodyFromEmbeddedResource(string name)
		{
			Procedure procedure = StoredProcedureProvider.Current[name];
			
			if ( procedure == null)
				throw new ApplicationException("cannot find the query '" + name + "' in the embedded xml file.");
			else
				return StoredProcedureProvider.Current[name].Body;
		}
		
		/// <summary>
		/// Get the command wrapper, either from the stored procedures or from the embedded queries.
		/// </summary>
		/// <param name="database">The database instance.</param>
		/// <param name="commandName">the name of the sp.</param>
		/// <param name="useStoredProcedure">Indicates if we want stored procedure.</param>
		/// <returns></returns>
		public static DbCommand GetCommandWrapper(Database database, string commandName, bool useStoredProcedure)
		{
			if (useStoredProcedure)
			{
				DbCommand command = database.GetStoredProcCommand(commandName);
                command.CommandTimeout = DataRepository.Provider.DefaultCommandTimeout;
                return command;
			}
			else
			{
                DbCommand command = 
                    database.GetSqlStringCommand(StoredProcedureProvider.GetProcedureBodyFromEmbeddedResource(commandName));
                command.CommandTimeout = DataRepository.Provider.DefaultCommandTimeout;
                return command; 
            }
		}

		/// <summary>
		/// Gets the command wrapper for a dynamically generated query and
		/// optionally includes server-side paging.
		/// </summary>
		/// <param name="database"></param>
		/// <param name="commandName"></param>
		/// <param name="columnEnum"></param>
		/// <param name="parameters"></param>
		/// <param name="orderBy"></param>
		/// <param name="start"></param>
		/// <param name="pageLength"></param>
		/// <returns></returns>
		public static DbCommand GetCommandWrapper(Database database, String commandName, Type columnEnum, SqlFilterParameterCollection parameters, String orderBy, int start, int pageLength)
		{
			String query = StoredProcedureProvider.GetProcedureBodyFromEmbeddedResource(commandName);
			//query = query.Replace(SqlUtil.PAGE_INDEX, string.Concat(SqlUtil.PAGE_INDEX, Guid.NewGuid().ToString("N").Substring(0,8)));
			String sortExpression = Utility.ParseSortExpression(columnEnum, orderBy);
			String whereClause = String.Empty;

			if ( parameters != null && ! String.IsNullOrEmpty(parameters.FilterExpression) )
			{
				whereClause = String.Format("where {0}", parameters.FilterExpression);
			}

			// replace dynamic components
			query = String.Format(query, whereClause, sortExpression, start, (start + pageLength)); 

            DbCommand command = database.GetSqlStringCommand(query);
            command.CommandTimeout = DataRepository.Provider.DefaultCommandTimeout;
            return command; 
		}
		
		#endregion
		
		private void InitializeProcedureLookupTables()
		{
			lock (syncRoot)
            {
	
				shortNameProcedures = Hashtable.Synchronized(new Hashtable());
				longNameProcedures = Hashtable.Synchronized(new Hashtable());
	
				foreach (Procedure procedure in procedures)
				{
					shortNameProcedures[procedure.Name] = procedure;
					longNameProcedures[procedure.Owner + "." + procedure.Name] = procedure;
				}
			}
		}
	}

	/// <summary>
	/// Represents a sql query.
	/// </summary>
	[Serializable()]
	public class Procedure 
	{
		/// <summary>
		/// Creates a new <see cref="Procedure"/> instance.
		/// </summary>
		public Procedure()
		{
			parameters = new ArrayList();
		}

		private ArrayList parameters;
		
		/// <summary>
		/// Gets or sets the parameters.
		/// </summary>
		/// <value></value>
		[XmlArray("parameters")]
		[XmlArrayItem("parameter",typeof(Parameter))]
		public ArrayList Parameters
		{
			get{return parameters;}
			set{parameters = value;}
		}

		private string name;
		
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value></value>
		[XmlAttribute("name")]
		public string Name
		{
			get{ return name;}
			set
			{
				name = value;
			}
		}
		
		private string owner;
      
      /// <summary>
      /// Gets or sets the owner.
      /// </summary>
      /// <value></value>
      [XmlAttribute("owner")]
      public string Owner
      {
         get { return owner; }
         set
         {
            owner = value;
         }
      }

		private string comment;
		
		/// <summary>
		/// Gets or sets the comment.
		/// </summary>
		/// <value></value>
		[XmlElement("comment")]
		public string Comment
		{
			get
			{
				return comment;
			}
			set
			{
				comment = value;
			}
		}

		private string body;
		
		/// <summary>
		/// Gets or sets the body.
		/// </summary>
		/// <value></value>
		[XmlElement("body")]
		public string Body
		{
			get{return body;}
			set{body = value;}
		}

		/// <summary>
		/// Get the parameter from the specified name of the param.
		/// </summary>
		/// <param name="paramName">Name of the param.</param>
		/// <returns></returns>
		public Parameter Parameter(string paramName)
		{
			foreach(Parameter parameter in parameters)
			{
				if(parameter.Name == paramName)
				{
					return parameter;
				}
			}
			return null;
		}
	}

	/// <summary>
	/// Respresents a query parameter.
	/// </summary>
	[Serializable()]
	public class Parameter 
	{
		/// <summary>
		/// Creates a new <see cref="Parameter"/> instance.
		/// </summary>
		public Parameter(){}

		private string name;
		
		/// <summary>
		/// Gets or sets the Name.
		/// </summary>
		/// <value></value>
		[XmlAttribute("name")]
		public string Name
		{
			get{return name;}
			set{name = value;}
		}

		private string sqltype;
		/// <summary>
		/// Gets or sets the SqlType.
		/// </summary>
		/// <value></value>
		[XmlAttribute("type")]
		public string SqlType
		{
			get{return sqltype;}
			set{sqltype = value;}
		}

		private System.Data.ParameterDirection direction;
		/// <summary>
		/// Gets or sets the Direction.
		/// </summary>
		/// <value></value>
		[XmlAttribute("direction")]
		public System.Data.ParameterDirection Direction
		{
			get{return direction;}
			set{direction = value;}
		}

		private int size;
		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value></value>
		[XmlAttribute("size")]
		public int Size
		{
			get{return size;}
			set{size = value;}
		}

		private int precision;
		/// <summary>
		/// Gets or sets the precision.
		/// </summary>
		/// <value></value>
		[XmlAttribute("precision")]
		public int Precision
		{
			get{return precision;}
			set{precision = value;}
		}

		private int scale;
		/// <summary>
		/// Gets or sets the scale.
		/// </summary>
		/// <value></value>
		[XmlAttribute("scale")]
		public int Scale
		{
			get{return scale;}
			set{scale = value;}
		}
	}

}
