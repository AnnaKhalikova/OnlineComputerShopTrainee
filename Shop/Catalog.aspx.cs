using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
	public partial class Catalog : System.Web.UI.Page
	{
		ConnectionClass connection = new ConnectionClass();

		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();
			FillPage();
		}

		// get all products from DB and create html table for each one
		private void FillPage()
		{
			LinkedList<Item> items = connection.GetAllProducts();
			string sb = "";
			if (items != null)
				foreach (Item it in items)
				{
					sb += @"<table class='desktopTable'>" +
					"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id=" + it.ID + "'><img runat='server' src='" + it.Image + "' /></a></th>" +
					"<th width='50px'>Name: </td><td>" + it.Type + " " + it.Name + "</td>" +
					"<th rowspan='3' width='50px'>" +
					"<button type='button' onclick='redirect("+it.ID+")' name='buy' value='" + it.ID + "' class='css3button'>buy</button>" +
					"</th></tr><tr><th>Price: </th><td>" + it.Price + " $</td></tr>" +
					"<tr><th>Description: </th><td>" + it.Description + "</td></tr></table>";
				}
			lblOut.Text = sb;
		}


	}
}