using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
	public partial class Desktop : System.Web.UI.Page
	{
		ConnectionClass connection = new ConnectionClass();

		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();
			FillPage();
		}

		private void FillPage()
		{
			LinkedList<Item> des = new LinkedList<Item>();
			if(!IsPostBack)
				des = connection.GetAllDesktopByProccess();
			else
				des = connection.GetDesktopByProccess(DropDownList1.SelectedValue);
			/*
			string sb = "";
			foreach (Item d in des)
			{
				sb += @"<table class='desktopTable'>" +
				"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id=" + d.ID + "'><img runat='server' src='" + d.Image + "' /></a></th>" +
				"<th width='50px'>Name: </td><td>" + d.Type + " " + d.Name + "</td>" +
				"<th rowspan='3' width='50px'>" +
				"<button type='button' onclick='redirect(" + d.ID + ")' name='buy' class='css3button'>buy</button>" +
				//"<asp:Button CssClass='css3button' onclick='redirect(" + d.ID + ")'  runat='server' Text='buy' />"+
				"</th></tr><tr><th>Price: </th><td>" + d.Price + " $</td></tr>" +
				"<tr><th>Description: </th><td>" + d.Description + "</td></tr></table>";
			}
			 */
			lblOutput.Text = LogicClass.GetDesktopProducts(des);
		}

		// sort menu
		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillPage();
		}

		protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
		{

		}


	}
}