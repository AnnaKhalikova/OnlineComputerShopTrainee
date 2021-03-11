using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop
{
	public class User
	{

		private int id;
		private string name;
		private string password;
		private string email;
		private string type;
		private string info;
		private string creditCard;

		public User(int id, string name, string pass, string email, string type, string info)
		{
			this.id = id;
			this.name = name;
			this.password = pass;
			this.email = email;
			this.type = type;
			this.info = info;
		}
		public User(int id, string name, string pass, string email, string type, string info, string creditCard)
		{
			this.id = id;
			this.name = name;
			this.password = pass;
			this.email = email;
			this.type = type;
			this.info = info;
			this.creditCard = creditCard;
		}


		public int Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public string Name { get { return name; } set { name = value; } }
		public string Password { get { return password; } set { password = value; } }
		public string Email { get { return email; } set { email = value; } }
		public string Type { get { return type; } set { type = value; } }
		public string Info { get { return info; } set { info = value; } }
		public string CreditCard { get { return creditCard; } set { creditCard = value; } }
	}
}