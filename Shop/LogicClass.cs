using DotNetOpenAuth;
using Shop.Entities;
using Shop.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Shop
{
	public class LogicClass : Mocks.ILogicService
	{

		// order the product for user
		// function that takes money from client doesn't exist for yet
		// redirect to client orders page
		//public ConnectionClass repository;
		public IConnectionService repos;
		public ConnectionClass repository;


		public LogicClass()
		{

		}
		public LogicClass(IConnectionService connectRepository)
		{
			repos = connectRepository;
		}
		public LogicClass(ConnectionClass connectRepository)
		{
			repository = connectRepository;
		}

		public string BuyItem(int ProductID, int userID, string addres)
		{
			// place for fields validation
			Item item = repository.GetProductByID(ProductID);
			if (item == null || item.Quantity <= 0)
			{
				return "Cannot buy this product. Please try other one.";
			}
			User user = repository.GetUserByID(userID);
			Ordder order = new Ordder(1, user.Id, ProductID, 1, item.Price, DateTime.Now.ToString("d.M.yyyy"), addres);
			repository.AddOrder(order);
			repository.ReduceQuantity(ProductID);
			// function that draws money from client
			//Response.Redirect("/Orders.aspx");
			return "";
		}

		public static string GetDesktopProducts(LinkedList<Item> des)
		{
			string sb = "";
			if(des != null)
			{
				foreach (Item d in des)
				{
					if(d.Image == null || d.Type == null || d.Name == null || d.Description == null)
					{
						sb = "";
						break;
					}
					sb += @"<table class='desktopTable'>" +
					"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id=" + d.ID + "'><img runat='server' src='" + d.Image + "' /></a></th>" +
					"<th width='50px'>Name: </td><td>" + d.Type + " " + d.Name + "</td>" +
					"<th rowspan='3' width='50px'>" +
					"<button type='button' onclick='redirect(" + d.ID + ")' name='buy' class='css3button'>buy</button>" +
					"</th></tr><tr><th>Price: </th><td>" + d.Price + " $</td></tr>" +
					"<tr><th>Description: </th><td>" + d.Description + "</td></tr></table>";
				}
			}
			
			return sb;
		}

		public static string GetNotebookProducts(LinkedList<Item> list)
		{
			string sb = "";
			if (list != null)
			{
				foreach (Item d in list)
				{
					sb += @"<table class='desktopTable'>" +
					"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id=" + d.ID + "'><img runat='server' src='" + d.Image + "' /></a></th>" +
					"<th width='50px'>Name: </td><td>" + d.Type + " " + d.Name + "</td>" +
					"<th rowspan='3' width='50px'>" +
					"<button type='button' name='buy' onclick='redirect(" + d.ID + ")' value='" + d.ID + "' class='css3button'>buy</button>" +
					"</th></tr><tr><th>Price: </th><td>" + d.Price + " $</td></tr>" +
					"<tr><th>Description: </th><td>" + d.Description + "</td></tr></table>";
				}
			}
			return sb;
		}

		public static string GetTabletProducts(LinkedList<Item> list)
		{
			string sb = "";
			if (list != null)
			{
				foreach (Item d in list)
				{
					sb += @"<table class='desktopTable'>" +
					"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id=" + d.ID + "'><img runat='server' src='" + d.Image + "' /></a></th>" +
					"<th width='50px'>Name: </td><td>" + d.Type + " " + d.Name + "</td>" +
					"<th rowspan='3' width='50px'>" +
					"<button type='button' onclick='redirect(" + d.ID + ")' name='buy' value='" + d.ID + "' class='css3button'>buy</button>" +
					"</th></tr><tr><th>Price: </th><td>" + d.Price + " $</td></tr>" +
					"<tr><th>Description: </th><td>" + d.Description + "</td></tr></table>";
				}
			}
			return sb;
		}

		public string ViewInfoBeforeBuyProduct(int ProductID)
		{
			//Item item = ConnectionClass.GetProductByID(ProductID);
			Item item = repository.GetProductByID(ProductID);
			//for testing
			//DBConnectionClass dbConnection = new DBConnectionClass();
			//Item item = dbConnection.GetProductByID(ProductID);
			string outStr = "";
			if (item == null)
			{
				outStr = "Sorry this product doesnt exist.";
				//Response.Redirect("/Default.aspx");
			}
			else
			{
				string[] des = item.Description.Split(',');
				int i = 0;
				while(i < des.Length && des[i].Length != 0)
				{
					des[i] = des[i].Substring(0, des[i].LastIndexOf(' '));
					i++;
				}

				if (des[0].Length == 0 && (item.Category == "Desktop" || item.Category == "Notebook" || item.Category == "Tablet"))
				{
					outStr += "Sorry, the model " + item.Name + " haven't a description.";
				}
				else if (item.Category.Equals("Desktop"))
				{
					outStr += "<table class='buyTable'>" +
							"<tr><td rowspan='9'><img runat='server' src='" + item.Image + "' /></td>" +
							"<td colspan='2' style='text-align:center'><b>" + item.Category + " " + item.Type + " " + item.Name + "</b></td></tr>" +
							"<tr bgcolor='#eeeeee'><td>Proccessor</td><td>" + des[0] + "</td></tr>" +
							"<tr><td>Motherboard</td><td>" + des[1] + "</td></tr>" +
							"<tr bgcolor='#eeeeee'><td>Video</td><td>NVIDIA GeForce GTX650 1GB</td></tr>" +
							"<tr><td>RAM</td><td>" + des[2] + "</td></tr>" +
							"<tr bgcolor='#eeeeee'><td>Memory</td><td>" + des[3] + "</td></tr>" +
							"<tr><td>PSU</td><td>Seasonic 620W</td></tr>" +
							"<tr bgcolor='#eeeeee'><td>Disc Drive</td><td>LG SATA 22X SUPER-MULTI DVD Burner</td></tr>" +
							"<tr><td>Warranty</td><td>15 Years</td></tr>" +
						"</table>";
				}
				else if (item.Category.Equals("Notebook"))
				{
					outStr += "<table class='buyTable' style='width: 80%;'>" +
							"<tr><td rowspan='9'><img runat='server' src='" + item.Image + "' /></td>" +
							"<td colspan='2' style='text-align:center'><b>" + item.Category + " " + item.Type + " " + item.Name + "</b></td></tr>" +
							"<tr bgcolor='#eeeeee'><td>Proccessor</td><td>" + des[0] + "</td></tr>" +
							"<tr><td>Video</td><td>Intel® HD Graphics</td></tr>" +
							"<tr bgcolor='#eeeeee'><td>RAM</td><td>" + des[1] + "</td></tr>" +
							"<tr><td>Memory</td><td>" + des[2] + "</td></tr>" +
							"<tr bgcolor='#eeeeee'><td>Disc Drive</td><td>LG SATA 22X SUPER-MULTI DVD Burner</td></tr>" +
							"<tr><td>Warranty</td><td>15 Years</td></tr>" +
						"</table>";
				}
				else if (item.Category.Equals("Tablet"))
				{
					outStr += "<table class='buyTable' style='width: 80%;'>" +
							"<tr><td rowspan='9'><img runat='server' src='" + item.Image + "' /></td>" +
							"<td colspan='2' style='text-align:center'><b>" + item.Category + " " + item.Type + " " + item.Name + "</b></td></tr>" +
							"<tr colspan='2'><td>Proccessor</td><td>" + item.Description + "</td></tr>" +
						"</table>";
				}
				else
					outStr += "Sorry this category of products doesnt exist.";
			}
			
			return outStr;
		}

		public string AddProduct(string category, string selectedImage, string txtType, string txtPrice,
													string txtName, string txtDescription, string txtQuant)
		{
			
			if (selectedImage == null || txtType == "" || txtPrice == "" || txtName == "" ||
											txtDescription == "" || txtQuant == "")
			{
				return "One of fields is empty";
			}
			
			string name = txtName;
			string des = txtDescription;
			int price = ConvertToNumber(txtPrice);
			if (price < 0)
			{
				return "Price can't be negative";				
			}
			string date = DateTime.Now.ToString("d.M.yyyy");
			string type = txtType;
			string img = "Images/" + selectedImage;
			int quant = ConvertToNumber(txtQuant);
			if (quant < 0)
			{
				return "Quantity must be zero or more";
			}
			//string category = drpProductType.SelectedValue.ToString();
			//DBConnectionClass dbRepository = new DBConnectionClass();
			//dbRepository.AddProduct(new Item(1, category, name, quant, img, des, date, price, type));
			repository.AddProduct(new Item(1, category, name, quant, img, des, date, price, type));
			//lblResult.Text = "";
			return "Product was successfully added!";
		}
		public string EditProduct(int id, string category, string selectedImage, string type, string price,
													string name, string description, string quant)
		{
			if (selectedImage == null || type == "" || price == "" || name == "" ||
											description == "" || quant == "")
			{
				return "One of fields is empty";
			}

			string newName = name;
			string des = description;

			int newPrice = ConvertToNumber(price);
			if (newPrice < 0)
			{
				return "Price can't be negative";
			}
			string date = DateTime.Now.ToString("d.M.yyyy");
			string newType = type;
			string img = "Images/" + selectedImage;
			int newQuant = ConvertToNumber(quant);
			if (newQuant < 0)
			{
				return "Quantity must be zero or more";
			}
			//repos.EditProduct(id, newPrice, newQuant);
			return "Product was successfully edited!";
		}
		// convert string to intв
		// if string contains symbols that not numbers return -1
		public int ConvertToNumber(string str)
		{
			str = str.Trim();
			int ans = 0;
			if (!int.TryParse(str, out ans))
			{
				return -1;
			}
			return ans;
		}

		public virtual bool IsEmail(string email)
		{
			try
			{
				MailAddress m = new MailAddress(email);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public virtual bool IsUserExist(string usr)
		{
			LinkedList<User> users = repository.GetAllUsers();
			foreach (User user in users)
			{
				if (user.Name.Equals(usr))
				{
					return true;
				}
			}
			return false;
		}
		public virtual string GetCreditNumber(string str)
		{
			char[] trimSymbols = { ',', '.', '-', ' '};
			str = str.Trim(trimSymbols);
			return str;
		}
		public LinkedList<Item> SortItems(LinkedList<Item> listOfItems)
		{
			return listOfItems.OrderBy(x => x.Price);
		}
		public virtual bool DeleteProduct(string category, string name)
		{
			if(category == "" || name == "")
			{
				return false;
			}
			var product = repos.GetProductByName(category, name);
			
			return repos.DeleteProduct(product);
		}
	}
}