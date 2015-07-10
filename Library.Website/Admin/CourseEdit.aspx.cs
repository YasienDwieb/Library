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

public partial class CourseEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CourseEdit.aspx?{0}", CourseDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CourseEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Course.aspx");
		FormUtil.SetDefaultMode(FormView1, "ID");
	}
}


