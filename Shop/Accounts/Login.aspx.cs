using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop.Accounts
{
	public partial class Login : System.Web.UI.Page
	{
		ConnectionClass connection = new ConnectionClass();
		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();
		}

		protected void cmdLogin_Click(object sender, EventArgs e)
		{
			if (txtLogin.Text == "" || txtPassword.Text == "")
				return;
			User usr = connection.GetUser(txtLogin.Text, txtPassword.Text);
			if (usr != null)
			{
				Session["login"] = usr.Name;
				Session["type"] = usr.Type;
				Session["id"] = usr.Id;
				Response.Redirect("~/Default.aspx");
				lblError.Text = "";
			}
			else
			{
				lblError.Text = "Login failed";
			}
		}
	}
}