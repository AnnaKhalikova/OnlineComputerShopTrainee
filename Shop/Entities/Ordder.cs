using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop
{
	public class Ordder
	{

		private int id;
		private int clientID;
		private int productID;
		private int ammount;
		private int price;
		private string date;
		private string info;
		private int totalPrice;

		public Ordder(int id, int client, int product, int amm, int price, string date, string info)
		{
			this.id = id;
			this.clientID = client;
			this.productID = product;
			this.ammount = amm;
			this.price = price;
			this.date = date;
			this.info = info;
			this.totalPrice = this.price * this.ammount;
		}


		public int Id { get { return id; } set { id = value; } }
		public int ClientID { get { return clientID; } set { clientID = value; } }
		public int ProductID { get { return productID; } set { productID = value; } }
		public int Ammount { get { return ammount; } set { ammount = value; } }
		public int Price { get { return price; } set { price = value; } }
		public string Date { get { return date; } set { date = value; } }
		public string Info { get { return info; } set { info = value; } }
		public int TotalPrice { get { return totalPrice; } }
	}
}