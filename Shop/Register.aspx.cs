using Shop.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
	//System.Web.UI.Page
	public partial class Register : System.Web.UI.Page
	{
		ConnectionClass connection = new ConnectionClass();

		LogicClass logic = new LogicClass();
		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();
		}
		//|| txtCreditCard.Text == ""
		protected void cmdRegister_Click(object sender, EventArgs e)
		{
			if (txtName.Text == "" || txtPass.Text == "" || txtConfPass.Text == "" || txtEmail.Text == "" )
			{
				return;
			}
			string pass = txtPass.Text.Trim();
			string name = txtName.Text.Trim();
			string email = txtEmail.Text.Trim();
			string credit = txtCreditCard.Text.Trim();
			if (pass.Length < 6)
			{
				lblErr.Text = "Password must contain at least 6 symbols.";
				return;
			}
			if (IsUserExist(name))
			{
				lblErr.Text = "User with this name already exist. Please try other name.";
				return;
			}
			string creditCardNumber = logic.GetCreditNumber(credit);
			if (credit.Length < 16)
			{
				lblErr.Text = "Credit Card must be at least 16 digits.";
				return;
			}
			if (!(logic.IsEmail(email)))
			{
				lblErr.Text = "Please enter a valid email number.";
				return;
			}
			User usr = new User(1, name, pass, email, "user", txtInfo.Text, txtCreditCard.Text);
			AddUser(usr);
		}

		private void AddUser(User usr)
		{
			if (connection.AddUser(usr))
			{
				Session["login"] = usr.Name;
				Session["type"] = usr.Type;
				User tempUsr = connection.GetUser(usr.Name, usr.Password);
				Session["id"] = tempUsr.Id;
				lblErr.Text = "";
				Response.Redirect("~/Default.aspx");
			}
			else
			{
				lblErr.Text = "Failed to add user. Try to enter different name.";
			}
		}

		//private int GetCreditNumber(string str)
		//{
		//	str = str.Trim();
		//	int ans = 0;
		//	if (!int.TryParse(str, out ans))
		//	{
		//		return -1;
		//	}
		//	return ans;
		//}

		private bool IsUserExist(string usr)
		{
			LinkedList<User> users = connection.GetAllUsers();
			foreach (User user in users)
			{
				if (user.Name.Equals(usr))
				{
					return true;
				}
			}
			return false;
		}

		//public virtual bool IsEmail(string email)
		//{
		//	try
		//	{
		//		MailAddress m = new MailAddress(email);
		//		return true;
		//	}
		//	catch (Exception)
		//	{
		//		return false;
		//	}
		//}

	}
}