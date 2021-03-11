using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();

			lnkManage2.Visible = false;
			if (Session["login"] != null)
			{
				// if  logged in as admin can view Manage page
				if (Session["type"].Equals("admin"))
				{
					lnkManage2.Visible = true;
				}
				lblLogin.Text = "Welcome " + Session["login"].ToString();		// user welcome message
				lblLogin.Visible = true;
				lnkLogin.Text = "Logout";		// switch text for user to logout
				lnkRegister.Visible = false;
				lnkOrders.Visible = true;
			}
				// if not logged in 
			else
			{
				lblLogin.Visible = false;
				lnkLogin.Text = "Login";
				lnkRegister.Visible = true;
				lnkManage2.Visible = false;
			}
		}

		// redirect tot login page
		protected void lnkLogin_Click(object sender, EventArgs e)
		{
			if (lnkLogin.Text == "Login")
			{
				Response.Redirect("~/Accounts/Login.aspx");
			}
			else
			{
				// if click login when already logged in it means log out
				// redirect to main page and clears logged data about user
				Session.Clear();
				Response.Redirect("~/Default.aspx");
			}
		}

		// redirect to register page
		// when logged in user can't see this link
		protected void lnkRegister_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Register.aspx");
		}
	}
}