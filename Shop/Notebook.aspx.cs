using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop.Pages
{
	public partial class Notebook : System.Web.UI.Page
	{
		ConnectionClass connection = new ConnectionClass();
		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionClass connection = new ConnectionClass();
			FillPage();
		}

		protected void FillPage()
		{
			LinkedList<Item> list = new LinkedList<Item>();
			if (!IsPostBack)
				list = connection.GetAllNotebookByType();
			else
				list = connection.GetNotebookByType(DropDownList1.SelectedValue);
			/*
			string sb = "";
			foreach (Item d in list)
			{
				sb += @"<table class='desktopTable'>" +
				"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id="+d.ID+"'><img runat='server' src='" + d.Image + "' /></a></th>" +
				"<th width='50px'>Name: </td><td>" + d.Type + " " + d.Name + "</td>" +
				"<th rowspan='3' width='50px'>" +
				"<button type='button' name='buy' onclick='redirect(" + d.ID + ")' value='" + d.ID + "' class='css3button'>buy</button>" +
				"</th></tr><tr><th>Price: </th><td>" + d.Price + " $</td></tr>" +
				"<tr><th>Description: </th><td>" + d.Description + "</td></tr></table>";
			}
			 */
			lblOutput.Text = LogicClass.GetNotebookProducts(list);
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillPage();
		}

	}
}