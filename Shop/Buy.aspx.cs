using Shop.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
	public partial class Buy : System.Web.UI.Page
	{
		private int ProductID = 0;

		static ConnectionClass connection = new ConnectionClass();
		LogicClass logic = new LogicClass(connection);

		protected void Page_Load(object sender, EventArgs e)
		{
			//ConnectionClass connection = new ConnectionClass();
			string text = (string)Request.QueryString["id"];	// read an parameter that transfered in url
			if (text == null || text.Equals("") || Session["id"] == null)
				Response.Redirect("/Accounts/Login.aspx");
			ProductID = Convert.ToInt32(text);

			ViewInfo();
		}

		// get product from database and create html table to view the information
		private void ViewInfo()
		{
			
			lblChoose.Text = logic.ViewInfoBeforeBuyProduct(ProductID);

			Item item = connection.GetProductByID(ProductID);
			//if (item == null)
			//{
			//	lblChoose.Text = "Sorry this product doesnt exist.";
			//	//Response.Redirect("/Default.aspx");
			//	return;
			//}
			//string[] des = item.Description.Split(',');
			//for (int i = 0; i < des.Length; i++)
			//{
			//	des[i] = des[i].Substring(0, des[i].LastIndexOf(' '));
			//}
			//string outStr = "";
			//if (item.Category.Equals("Desktop"))
			//{
			//	outStr += "<table class='buyTable'>" +
			//			"<tr><td rowspan='9'><img runat='server' src='" + item.Image + "' /></td>" +
			//			"<td colspan='2' style='text-align:center'><b>" + item.Category + " " + item.Type + " " + item.Name + "</b></td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>Proccessor</td><td>" + des[0] + "</td></tr>" +
			//			"<tr><td>Motherboard</td><td>" + des[1] + "</td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>Video</td><td>NVIDIA GeForce GTX650 1GB</td></tr>" +
			//			"<tr><td>RAM</td><td>" + des[2] + "</td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>Memory</td><td>" + des[3] + "</td></tr>" +
			//			"<tr><td>PSU</td><td>Seasonic 620W</td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>Disc Drive</td><td>LG SATA 22X SUPER-MULTI DVD Burner</td></tr>" +
			//			"<tr><td>Warranty</td><td>15 Years</td></tr>" +
			//		"</table>";
			//}
			//if (item.Category.Equals("Notebook"))
			//{
			//	outStr += "<table class='buyTable' style='width: 80%;'>" +
			//			"<tr><td rowspan='9'><img runat='server' src='" + item.Image + "' /></td>" +
			//			"<td colspan='2' style='text-align:center'><b>" + item.Category + " " + item.Type + " " + item.Name + "</b></td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>Proccessor</td><td>" + des[0] + "</td></tr>" +
			//			"<tr><td>Video</td><td>Intel® HD Graphics</td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>RAM</td><td>" + des[1] + "</td></tr>" +
			//			"<tr><td>Memory</td><td>" + des[2] + "</td></tr>" +
			//			"<tr bgcolor='#eeeeee'><td>Disc Drive</td><td>LG SATA 22X SUPER-MULTI DVD Burner</td></tr>" +
			//			"<tr><td>Varranty</td><td>15 Years</td></tr>" +
			//		"</table>";
			//}
			//if (item.Category.Equals("Tablet"))
			//{
			//	outStr += "<table class='buyTable' style='width: 80%;'>" +
			//			"<tr><td rowspan='9'><img runat='server' src='" + item.Image + "' /></td>" +
			//			"<td colspan='2' style='text-align:center'><b>" + item.Category + " " + item.Type + " " + item.Name + "</b></td></tr>" +
			//			"<tr colspan='2'><td>Proccessor</td><td>" + item.Description + "</td></tr>" +
			//		"</table>";
			//}

			//lblChoose.Text = outStr;

		}

		// cancel buing -> redirect to main page
		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("/Default.aspx");
		}

		// order the product for user
		// function that takes money from client doesn't exist for yet
		// redirect to client orders page
		protected void cmdBuy_Click(object sender, EventArgs e)
		{
			lblOut.Text = logic.BuyItem(ProductID, Convert.ToInt32(Session["id"].ToString()), txtAddress.Text);
			//if(lblOut.Text == "")
			//	Response.Redirect("/Orders.aspx");
			/*
			// place for fields validation
			Item item = ConnectionClass.GetProductByID(ProductID);
			if(item == null){
				lblOut.Text = "Cannot buy this product. Please try other one.";
			}
			User user = ConnectionClass.GetUserByID(Convert.ToInt32(Session["id"].ToString()));
			Ordder order = new Ordder(1, user.Id, ProductID, 1, item.Price, DateTime.Now.ToString("d.M.yyyy"), txtAddress.Text);
			ConnectionClass.AddOrder(order);
			// function that draws money from client
			Response.Redirect("/Orders.aspx");
			 */
		}


	}
}