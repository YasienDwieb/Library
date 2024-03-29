﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Library.BLL
{
	/// <summary>
    /// Provides the core entity factory behavior.  Will create a type based on a string
    /// or a type and will try to auto discover which assembly this type lives in, even if it's
    /// not a local referenced assembly.
    /// </summary>
    public abstract class EntityFactoryBase : IEntityFactory
    {
        #region Events
        /// <summary>
        /// Exposes an Event which fires when an Entity is about to be created.
        /// </summary>
        [field: NonSerialized]
        public static event EntityCreatingEventHandler EntityCreating;
        /// <summary>
        /// Exposes an Event which fires when an Entity has been created.
        /// </summary>
        [field: NonSerialized]
        public static event EntityCreatedEventHandler EntityCreated;

        /// <summary>
        /// A delegate to handle <see cref="EntityCreating"/> events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EntityCreatingEventHandler(object sender, EntityEventArgs e);
        
        /// <summary>
        /// A delegate to handle <see cref=" EntityCreated"/> events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EntityCreatedEventHandler(object sender, EntityEventArgs e);
        #endregion

        #region Fields
        /// <summary>
        /// The current assembly from which to attempt to create entities from.
        /// </summary>
        protected static Assembly currentAssembly = typeof(EntityFactoryBase).Assembly;
        
        /// <summary>
        /// This will create entities by default if not found in the current assembly
        /// </summary>
        protected static string defaultCreationalNamespace = typeof(EntityFactoryBase).Namespace;
        
        /// <summary>
        /// This provides a cache of already discovered types, so that there is minimal performance hit after first lookup.
        /// </summary>
        protected static Dictionary<string, Type> internalTypeCache = new Dictionary<string, Type>();
        
        /// <summary>
        /// A synchronization object
        /// </summary>
        protected static object syncRoot = new object();
        
        /// <summary>
        /// This is the namespace for the currentAssembly property
        /// </summary>
        private static string currentEntityAssemblyNamespace = defaultCreationalNamespace;
        #endregion

        #region Properties

        #region CurrentAssembly
        /// <summary>
        /// Gets the current assembly.
        /// </summary>
        /// <value>The current assembly.</value>
        public virtual System.Reflection.Assembly CurrentEntityAssembly
        {
            get
            {
                return currentAssembly;
            }
            set 
            {
                if (value != null)
                {
                    lock (syncRoot)
                    {
                        currentAssembly = value;
                        CurrentEntityAssemblyNamespace = currentAssembly.FullName.Split(',')[0];
                    }
                }
            }
        }
        
        /// <summary>
        /// Gets the current entity assembly namespace to discover types from.
        /// </summary>
        /// <value>The current assembly.</value>
        public virtual string CurrentEntityAssemblyNamespace
        {
            get
            {
                return currentEntityAssemblyNamespace;
            }
            set
            {
                if (value != null)
                {
                    lock (syncRoot)
                    {
                        currentEntityAssemblyNamespace = value;
                    }
                }
            }
        } 
        #endregion
        
        #endregion 

        #region Member Create Methods
        /// <summary>
        /// Create an entity based on a string.
        /// It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString">string of entity to discover and create</param>
        /// <param name="defaultType">if string is not found defaultType will be created.</param>
        /// <returns>Created IEntity object</returns>
        public virtual IEntity CreateEntity(string typeString, Type defaultType)
        {
            return Create(typeString, defaultType);
        }

        /// <summary>
        /// Create a view entity based on a string.
        /// It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString">string of entity to discover and create</param>
        /// <param name="defaultType">if string is not found defaultType will be created.</param>
        /// <returns>Created object</returns>
        public virtual object CreateViewEntity(string typeString, Type defaultType)
        {
            return CreateReadOnlyEntity(typeString, defaultType);
        }
        #endregion

        #region Static Create Methods
        /// <summary>
        /// Create an entity based on a string.  It will autodiscover the type based on
        /// based on any information we can gather.
        /// </summary>
        /// <param name="typeString">string of entity to discover and create</param>
        /// <returns>created IEntity object</returns>
        public static IEntity Create(string typeString)
        {
            return Create(typeString, null);
        }

        /// <summary>
        /// Create an entity of generic type T
        /// </summary>
        /// <returns>T</returns>
        public static T Create<T>() where T : IEntity, new()
        {
            Type type = typeof(T);
			
			lock (syncRoot)
            {
            	if (!internalTypeCache.ContainsValue(type))
                	internalTypeCache.Add(type.FullName, type);
			}

            //fire pre creating event
            OnEntityCreating(type);

            //create entity
            T entity = new T();

            //fire post created event
            OnEntityCreated(entity, type);

            return entity;
        }

        /// <summary>
        /// Create an entity based on a string.  It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString"></param>
		/// <param name="defaultType"></param>
        /// <returns>IEntity</returns>
        public static IEntity Create(string typeString, Type defaultType)
        {
            return CoreCreate(typeString, defaultType) as IEntity;
        }

        /// <summary>
        /// Creates an <see cref="IEntity"/> object and begins tracking on the object.
        /// </summary>
        /// <param name="type">known type to create</param>
        /// <returns>created IEntity object</returns>
        public static IEntity Create(Type type)
        {
            if (type.GetInterface("IEntity") == null)
                throw new ArgumentException("Type Parameter must implement the IEntity interface.");

            IEntity entity = CoreCreate(type) as IEntity;
            
            return entity;
        }

        #region CreateReadOnlyEntity
        /// <summary>
        /// Create an entity based on a string from a view.  It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString"></param>
        /// <param name="defaultType"></param>
        /// <returns>Object</returns>
        public static Object CreateReadOnlyEntity(string typeString, Type defaultType)
        {
            return CoreCreate(typeString, defaultType);
        }

        /// <summary>
        /// Creates an view object.
        /// </summary>
        /// <param name="type">known type to create</param>
        /// <returns>created view ReadOnlyEntity entity object</returns>
        public static Object CreateReadOnlyEntity(Type type)
        {
            return CoreCreate(type);
        }
        #endregion 

        #region CoreCreate

        /// <summary>
        /// Create an entity based on a string.  It will autodiscover the type based on any information we can gather.
        /// </summary>
        /// <param name="typeString"></param>
        /// <param name="defaultType"></param>
        /// <returns>object</returns>
        private static Object CoreCreate(string typeString, Type defaultType)
        {
            if (string.IsNullOrEmpty(typeString))
                throw new ArgumentException("Entity can not be null or empty when being passed into the factory.");

            typeString = string.Format("{0}.{1}", currentEntityAssemblyNamespace, typeString);

			lock (syncRoot)
            {
            	if (internalTypeCache.ContainsKey(typeString))
                	return CoreCreate(internalTypeCache[typeString]);
			}

            // resolve the type
            Type targetType = ResolveType(typeString);

            if (targetType == null)
            {
                if (defaultType != null)
                    targetType = defaultType;
                else if (defaultCreationalNamespace != null)
                    targetType = ResolveType(typeString, defaultCreationalNamespace);
                else
                    throw new ArgumentException(string.Format("This type '{0}' can not be resolved.  Please ensure that your NetTiersService Section is correct in the configuration file.", typeString));
            }

            return CoreCreate(targetType);
        }

        /// <summary>
        /// Creates an object and begins .
        /// </summary>
        /// <param name="type">known type to create</param>
        /// <returns>created object</returns>
        private static object CoreCreate(Type type)
        {
			lock (syncRoot)
            {
            	if (!internalTypeCache.ContainsValue(type))
            	{
                    internalTypeCache.Add(type.FullName, type);
                }
            }

            //fire pre creating event
            OnEntityCreating(type);

            //create entity based on passed in type.
            Object entity = Activator.CreateInstance(type) as Object;

            if (entity == null)
                throw new ArgumentException(string.Format("This type '{0}' can not be resolved correctly to instatiate your entity.  Please ensure that your NetTiersService Section is correct in the configuration file.", type.FullName));

            //fire post created event
            OnEntityCreated(entity as IEntity, type);

            return entity;
        }
        #endregion 

        #endregion 
        
        #region Helper Methods
        /// <summary>
        /// Resolves a type based on a string.  It will attempt to Auto-Discover the type, 
        /// based on it's fullname or partial names.
        /// </summary>
        /// <param name="typeString">the string of the type to resolve</param>
        /// <returns>IEntity</returns>
        private static Type ResolveType(string typeString)
        {
            //string className = GetClassNameFromString(typeString);
            //string assemblyName = GetAssemblyNameFromString(typeString);

            // Get the assembly containing the handler
            System.Reflection.Assembly assembly = currentAssembly;
            //Type foundType = null;
            return assembly.GetType(typeString, false, true); 
        }

        /// <summary>
        /// Resolves a type based on a string.  It will attempt to Auto-Discover the type, 
        /// based on it's fullname or partial names.
        /// </summary>
        /// <param name="typeString">the string of the type to resolve</param>
        /// <param name="defaultNamespace">the string of the type to resolve</param>
        /// <returns>IEntity</returns>
        private static Type ResolveType(string typeString, string defaultNamespace)
        {
            //string className = GetClassNameFromString(typeString);
            //string assemblyName = GetAssemblyNameFromString(typeString);

            // Get the assembly containing the handler
            System.Reflection.Assembly assembly = currentAssembly;
            //Type foundType = null;
            return assembly.GetType(String.Format("{0}.{1}", defaultNamespace, typeString), false, true);
        }


        /// <summary>
        /// Parses a string and gets the class name from a qualified name, based on [Type, Assembly]
        /// </summary>
        /// <param name="typeString"></param>
        /// <example>
        ///     MyNamespace.MyType, MyNamespace
        /// </example>
        /// <returns>string of the qualified classname</returns>
        private static string GetClassNameFromString(string typeString)
        {
            int commaIndex = typeString.IndexOf(",");
            if (commaIndex > 0)
                return typeString.Substring(0, commaIndex).Trim();

            return typeString;
        }

        /// <summary>
        /// Parses a string and gets the class name from a qualified name, based on [Type, Assembly]
        /// </summary>
        /// <param name="typeString"></param>
        /// <example>
        ///     MyNamespace.MyType, MyNamespace
        /// </example>
        /// <returns>string of the qualified Assembly Name</returns>
        private static string GetAssemblyNameFromString(string typeString)
        {
            int commaIndex = typeString.IndexOf(",");
            if (commaIndex > 0 && typeString.Length >= commaIndex + 1)
                return typeString.Substring(commaIndex + 1).Trim();

            return typeString;
        }

        /// <summary>
        /// Flushes the Internal Type Cache
        /// </summary>
        public static void FlushTypeCache()
        {
            internalTypeCache.Clear();
        }
        #endregion

        #region Fire Events

        /// <summary>
        /// Used to fire the event just before an entity is creating.
        /// </summary>
        /// <param name="type">The type.</param>
        private static void OnEntityCreating(Type type)
        {
            EntityCreatingEventHandler handler = EntityCreating;
            if (handler != null)
            {
                handler(null, new EntityEventArgs(null, type));
            }
        }

        /// <summary>
        /// Used to fire the an event when the entity has just been created.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="type">The type.</param>
        private static void OnEntityCreated(IEntity entity, Type type)
        {
            EntityCreatedEventHandler handler = EntityCreated;
            if (handler != null)
            {
                handler(null, new EntityEventArgs(entity, type));
            }
        }

        #endregion

        #region EntityEventArgs class
        /// <summary>
        /// Used to suppliment information for the EntityCreating and EntityCreated events.
        /// </summary>
        /// <remarks>
        /// The EntityCreating and EntityCreated events occur when an Entity is about to be created,
        /// or just after an Entity is created.
        /// </remarks>
        public class EntityEventArgs : System.EventArgs
        {
            private IEntity entity;
            private Type creationalType;

            /// <summary>
            /// Initalizes a new Instance of the ComponentEntityEventArgs class.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <param name="type">The type.</param>
            public EntityEventArgs(IEntity entity, Type type)
            {
                this.entity = entity;
                this.creationalType = type;
            }

            /// <summary>
            /// The entity that is about to be created or has just been created.
            /// </summary>
            /// <value>The entity.</value>
            public IEntity Entity { get { return this.entity; } }

            /// <summary>
            /// Gets the type of the entity to be created.
            /// </summary>
            /// <value>The type of the creational.</value>
            public Type CreationalType { get { return this.creationalType; } }
        }
        #endregion
    }
}
