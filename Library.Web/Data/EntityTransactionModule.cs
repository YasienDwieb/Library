﻿#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Library.DAL;
#endregion

namespace Library.Web.Data
{
	/// <summary>
	/// Provides access to a TransactionManager instance associated with
	/// the current HttpContext.
	/// </summary>
	public class EntityTransactionModule : IHttpModule
	{
		private static readonly String ManagerKey = "EntityTransactionManager";

		/// <summary>
		/// Initializes a new instance of the EntityTransactionModule class.
		/// </summary>
		public EntityTransactionModule()
		{
		}

		#region IHttpModule Members

		/// <summary>
		/// Initializes a module and prepares it to handle requests.
		/// </summary>
		/// <param name="application">An reference to the current HttpApplication instance.</param>
		public void Init(HttpApplication application)
		{
			application.EndRequest += new EventHandler(OnEndRequest);
		}

		/// <summary>
		/// Disposes of the resources (other than memory) used by the module.
		/// </summary>
		public void Dispose()
		{
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Handles the System.Web.HttpApplication.EndRequest event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void OnEndRequest(Object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication) sender;
			HttpContext context = application.Context;
			ITransactionManager mgr = context.Items[ManagerKey] as TransactionManager;

			if ( mgr != null && mgr.IsOpen )
			{
				context.Items[ManagerKey] = null;
				
				if ( context.Error != null )
				{
					mgr.Rollback();
				}
				else
				{
					mgr.Commit();
				}
			}
		}

		#endregion

		/// <summary>
		/// Gets a reference to the TransactionManager object associated
		/// with the current HttpContext.  If one is not available, this method
		/// creates a new instance, associates it with the current HttpContext,
		/// and begins a new transaction.
		/// </summary>
		public static ITransactionManager TransactionManager
		{
			get
			{
				HttpContext context = HttpContext.Current;
				ITransactionManager mgr = null;

				if ( context != null )
				{
					mgr = context.Items[ManagerKey] as TransactionManager;

					if ( mgr == null )
					{
						mgr = DataRepository.Provider.CreateTransaction();
						mgr.BeginTransaction();

						context.Items[ManagerKey] = mgr;
					}
				}

				return mgr;
			}
		}
	}
}
