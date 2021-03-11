using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Entities
{
	public class Item
	{

		private int id;
		private string category;
		private string name;
		private int quantity;
		private string image;
		private string description;
		private string date;
		private int price;
		private string type;

		public Item()
		{
			Item item = new Item();
			item = null;
		}

		public Item(int id, string category, string name, int quant, string image, string descrption,
						string date, int price, string type)
		{
			this.id = id;
			this.category = category;
			this.name = name;
			this.quantity = quant;
			this.image = image;
			this.description = descrption;
			this.date = date;
			this.price = price;
			this.type = type;
		}

		public int ID { get { return id; } set { id = value; } }
		public string Category { get { return category; } set { category = value; } }
		public string Name { get { return name; } set { name = value; } }
		public int Quantity { get { return quantity; } set { quantity = value; } }
		public string Image { get { return image; } set { image = value; } }
		public string Description { get { return description; } set { description = value; } }
		public string Date { get { return date; } set { date = value; } }
		public int Price { get { return price; } set { price = value; } }
		public string Type { get { return type; } set { type = value; } }
	}
}