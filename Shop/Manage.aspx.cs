using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop.Pages
{
	public partial class Manage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["type"] == null)
			{
				Response.Redirect("~/Accounts/Login.aspx");
			}
			else if (!Session["type"].Equals("admin"))
			{
				Response.Redirect("~/Default.aspx");
			}
		}

		protected void cmdAddNew_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/AddProduct.aspx");
		}
	}
}