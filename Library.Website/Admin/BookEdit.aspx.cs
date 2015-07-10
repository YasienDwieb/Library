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

public partial class BookEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "BookEdit.aspx?{0}", BookDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "BookEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Book.aspx");
		FormUtil.SetDefaultMode(FormView1, "ID");
	}
}


