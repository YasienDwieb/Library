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
using Library.BLL;
#endregion

namespace Library.Web.Data
{
	/// <summary>
	/// Provides management of a many-to-many relationship between a primary
	/// table and a foreign key table via the use of a join table. This control
	/// is specifically designed to be used with ListControl sub-classes.
	/// </summary>
	public class ManyToManyListRelationship : EntityRelationship
	{
		/// <summary>
		/// Initializes a new instance of the ManyToManyListRelationship class.
		/// </summary>
		public ManyToManyListRelationship()
		{
		}

		/// <summary>
		/// Initializes and updates the control with the relationships
		/// held within the specified business object.
		/// </summary>
		/// <param name="entity"></param>
		protected override void UpdateControl(Object entity)
		{
			IList links = GetLinkList(entity);
			Object value;

			foreach ( Object link in links )
			{
				value = EntityUtil.GetPropertyValue(link, LinkMember.ForeignKeyName);

				if ( value != null )
				{
					ReferenceMember.Select(value.ToString());
				}
			}
		}

		/// <summary>
		/// Updates the specified business object with values bound to the
		/// control which represent the current relationships.
		/// </summary>
		/// <param name="entity"></param>
		protected override void UpdateRelationships(Object entity)
		{
			IList links = GetLinkList(entity);
			IList remove = new ArrayList();
			String strValue;
			Object objValue;

			// verify current items selected
			foreach ( Object link in links )
			{
				objValue = EntityUtil.GetPropertyValue(link, LinkMember.ForeignKeyName);
				strValue = String.Format("{0}", objValue);

				if ( !ReferenceMember.IsSelected(strValue) )
				{
					remove.Add(link);
				}
			}

			// remove deleted items
			foreach ( Object link in remove )
			{
				RemoveLink(links, link);
			}

			// add new items
			IList references = ReferenceMember.GetEntityList();
			Object reference;

			// loop thru the items of the list control
			foreach ( ListItem item in ReferenceMember.ListControl.Items )
			{
				if ( item.Selected )
				{
					reference = EntityUtil.GetEntity(references, ReferenceMember.EntityKeyName, item.Value);

					if ( reference != null )
					{
						InsertLink(links, item.Value);
					}
				}
			}
		}
	}
}
