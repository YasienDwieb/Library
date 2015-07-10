#region Imports...
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

public partial class IntroducerEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "IntroducerEdit.aspx?{0}", IntroducerDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "IntroducerEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Introducer.aspx");
		FormUtil.SetDefaultMode(FormView1, "ID");
	}
	protected void GridViewBook1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ID={0}", GridViewBook1.SelectedDataKey.Values[0]);
		Response.Redirect("BookEdit.aspx?" + urlParams, true);		
	}	
}


