﻿#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Library.Web.UI;
#endregion

public partial class UserTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UserTypeEdit.aspx?{0}", UserTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UserTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "UserType.aspx");
		FormUtil.SetDefaultMode(FormView1, "ID");
	}
	protected void GridViewUsers1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ID={0}", GridViewUsers1.SelectedDataKey.Values[0]);
		Response.Redirect("UsersEdit.aspx?" + urlParams, true);		
	}	
}


