using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop
{
	public class TabletClass
	{

		private int id;
		private string name;
		private int price;
		private string image;
		private string description;
		private int popularity;
		private string type;
		private int ammount;

		public int Id { get { return id; } set { id = value; } }
		public string Name { get { return name; } set { name = value; } }
		public int Price { get { return price; } set { price = value; } }
		public string Image { get { return image; } set { image = value; } }
		public string Description { get { return description; } set { description = value; } }
		public int Popularity { get { return popularity; } set { popularity = value; } }
		public string Type { get { return type; } set { type = value; } }
		public int Ammount { get { return ammount; } set { ammount = value; } }

		public TabletClass(int id, string name, int price, string image, string description, int pop, string type, int amm)
		{
			this.id = id;
			this.name = name;
			this.price = price;
			this.image = image;
			this.description = description;
			this.popularity = pop;
			this.type = type;
			this.ammount = amm;
		}

	}
}