using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
//using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Providers.Entities;
using Shop.Mocks;
using System.Data;

namespace Shop
{

	/*
	 * 
	 Database get/set methods
	 * 
	 */
	//: IConnectionService
	public class ConnectionClass : IConnectionService
	{

		private static SqlCeConnection con;		// DB connection string
		private static SqlCeCommand comand;     // command to execute
		private IConnectionService connection;

		private IDbConnection connect;
		private IDbCommand command;

		static ConnectionClass()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;    // get started directory name
			con = new SqlCeConnection("Data Source=" + path + @"\App_Data\CoffeeDB.sdf");
			comand = new SqlCeCommand("", con);
		}
		public ConnectionClass(IDbConnection connect, IDbCommand command)
		{
			this.connect = connect;
			this.command = command;
		}
		public ConnectionClass(IConnectionService service)
		{
			connection = service;
		}
		public ConnectionClass()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;    // get started directory name
			con = new SqlCeConnection("Data Source=" + path + @"\App_Data\CoffeeDB.sdf");
			command = new SqlCeCommand("", con);
		}
		/*******************      Users     ************************/
		//, reader.GetString(6)
		public LinkedList<User> GetAllUsers()
		{
			LinkedList<User> users = new LinkedList<User>();
			string query = "select * from Users";
			try
			{
				con.Open();
				command = new SqlCeCommand(query, con);
				IDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					User usr = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetString(3), reader.GetString(4), reader.GetString(5));
					users.AddLast(usr);

				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return users;
		}
		// , reader.GetString(6)
		public User GetUser(string name, string pass)
		{
			User usr = null;
			string query = "select * from Users where Name = '" + name + "'";
			con.Open();
			comand = new SqlCeCommand(query, con);
			var reader = comand.ExecuteReader();
			int i = 0;
			while (reader.Read() && i == 0)
			{
				usr = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
						reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
				i++;
		    }
			if(usr != null && pass != usr.Password)
			{
			    con.Close();
			}

			return usr;
		}
		//reader.GetString(6)
		public virtual User GetUserByID(int id)
		{
			User usr = null;
			string query = "select * from Users where Id = '" + id + "'";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				int i = 0;
				while (reader.Read())
				{
					if (i > 0)
					{
						con.Close();
						return null;
					}
					usr = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetString(3), reader.GetString(4), reader.GetString(5));
					i++;
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return usr;
		}
	    //			"', '" + usr.Info + "', " + usr.CreditCard + ")";

		public bool AddUser(User usr)
		{
			string query = "Insert into Users (Name, Password, Email, Type, Info, CreditCard)" +
					" values('" + usr.Name + "', '" + usr.Password + "','" + usr.Email + "','" + usr.Type + "', '" + usr.Info + "', " + usr.CreditCard + ")"; ;
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				comand.ExecuteNonQuery();
			}
			catch (Exception)
			{
				con.Close();
				return false;
			}
			con.Close();
			return true;
		}

		public int UsersCount()
		{
			int ans = 0;
			string query = "select count (*) from Users";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				ans = (int) comand.ExecuteScalar();
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}


		/******************    Orders    **************************/

		public void AddOrder(Ordder order)
		{
			string query = "Insert into Orders (ClientID, ProductID, Ammount, Price, Date, Info, TotalPrice)" +
				" values(" + order.ClientID + "," + order.ProductID + "," + order.Ammount + "," +
				"" + order.Price + ", '" + order.Date + "', '" + order.Info + "', "+order.TotalPrice+")";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				comand.ExecuteNonQuery();
			}
			catch { }
			finally
			{
				con.Close();
			}
		}

		public LinkedList<Ordder> GetAllOrdersForClient(int id)
		{
			string query = "select * from Orders where ClientID =" + id + "";
			LinkedList<Ordder> ans = new LinkedList<Ordder>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					// on new Order creation TotalPrice will calculated in Constructor
					Ordder order = new Ordder(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
						reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
					ans.AddLast(order);
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}

		public LinkedList<Ordder> GetAllOrders()
		{
			string query = "select * from Orders order by Date";
			LinkedList<Ordder> ans = new LinkedList<Ordder>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					// on new Order creation TotalPrice will calculated in Constructor
					Ordder order = new Ordder(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
						reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6));
					ans.AddLast(order);
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}

		/*****************   Products    **************************/

		public LinkedList<Item> GetAllProducts()
		{
			string query = "select * from Items order by Category";
			LinkedList<Item> ans = new LinkedList<Item>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					Item it = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
								reader.GetInt32(7), reader.GetString(8));
					ans.AddLast(it);
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}

		public virtual Item GetProductByID(int id)
		{
			string query = "select * from Items where Id = '" + id + "'";
			Item ans = null;
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				var reader = comand.ExecuteReader();
				int i = 0;
				while (reader.Read())
				{
					if (i > 0)
						ans = null;
					else
						ans = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
								reader.GetInt32(7), reader.GetString(1));
					i++;
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}

		public virtual LinkedList<Item> GetProductByName(string category, string name)
		{
			string query = "select* from Items where Category = '"+category+"' and Name = '"+name+"'";
			LinkedList<Item> ans = new LinkedList<Item>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					Item it = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
								reader.GetInt32(7), reader.GetString(1));
					ans.AddLast(it);
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}

		public virtual LinkedList<Item> GetProductByType(string category, string type)
		{
			string query = "select* from Items where Category = '" + category + "' and Type = '" + type + "'";
			LinkedList<Item> ans = new LinkedList<Item>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					Item it = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
								reader.GetInt32(7), reader.GetString(8));
					ans.AddLast(it);
				}
			}
			catch { }
			//finally
			//{

			//	connect.Close();
			//}
			return ans;
		}

		public LinkedList<Item> GetAllProductsByCategory(string category)
		{
			string query = "select* from Items where Category = '" + category + "'";
			LinkedList<Item> ans = new LinkedList<Item>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					Item it = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
								reader.GetInt32(7), reader.GetString(8));
					ans.AddLast(it);
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}

		public virtual void AddProduct(Item pr)
		{
			string query = "Insert into Items (Category, Name, Quantity, Image, Description, PublishDate, Price, Type)" +
				"values('" + pr.Category + "', '" + pr.Name + "','" + pr.Quantity + "','" + pr.Image + "'," +
				"'" + pr.Description + "', '" + pr.Date + "', '" + pr.Price + "', '" + pr.Type + "')";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				comand.ExecuteNonQuery();
			}
			finally
			{
				con.Close();
			}
		}

		public void AddItem(Item item)
		{
			string query = "Insert into Items (Category, Name, Quantity, Image, Description, PublishDate, Price, Type)" +
				"values('" + item.Category + "', '" + item.Name + "','" + item.Quantity + "','" + item.Image + "'," +
				"'" + item.Description + "', '" + item.Date + "', '" + item.Price + "', '" + item.Type + "')";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				comand.ExecuteNonQuery();
			}
			catch { }
			finally
			{
				con.Close();
			}
		}

		public LinkedList<Item> GetLastAdded()
		{
			string query = "select TOP 10 * from Items";
			LinkedList<Item> ans = new LinkedList<Item>();
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				SqlCeDataReader reader = comand.ExecuteReader();
				while (reader.Read())
				{
					Item it = new Item(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
								reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
								reader.GetInt32(7), reader.GetString(8));
					ans.AddLast(it);
				}
			}
			catch { }
			finally
			{

				con.Close();
			}
			return ans;
		}
		public virtual void EditProduct(int id, int price, int quant)
		{
			Item item = GetProductByID(id);
			item.Price = price;
			item.Quantity = quant;

			string query = "UPDATE Items SET Price = " + item.Price +" WHERE Id = " + id + "";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				comand.ExecuteNonQuery();
			}
			catch (Exception)
			{
				con.Close();
			}
			con.Close();
		}
		public virtual bool DeleteProduct(LinkedList<Item> product)
		{
			//Item item = GetProductByID(product.First.Value.ID);
			//int quant = item.Quantity - 1;
			//string query = "UPDATE Items SET Quantity = " + quant + " WHERE Id = " + id + "";
			//try
			//{
			//	con.Open();
			//	comand = new SqlCeCommand(query, con);
			//	comand.ExecuteNonQuery();
			//}
			//catch (Exception)
			//{
			//	con.Close();
			//	return false;
			//}
			//con.Close();
			return true;
		}
		public bool ReduceQuantity(int id)
		{
			Item item = GetProductByID(id);
			int quant = item.Quantity - 1;
			string query = "UPDATE Items SET Quantity = " + quant + " WHERE Id = " + id + "";
			try
			{
				con.Open();
				comand = new SqlCeCommand(query, con);
				comand.ExecuteNonQuery();
			}
			catch (Exception)
			{
				con.Close();
				return false;
			}
			con.Close();
			return true;
		}

		/**************************       Desktop        *********************************/

		public  LinkedList<Item> GetDesktopByProccess(string type)
		{
			LinkedList<Item> ans = GetProductByType("Desktop", type);
			return ans;
		}

		public LinkedList<Item> GetAllDesktopByProccess()
		{
			LinkedList<Item> ans = GetAllProductsByCategory("Desktop");
			return ans;
		}

		public void AddDesktop(Item des)
		{
			AddItem(des);
		}


		/****************************     Notebook      ******************************/

		public LinkedList<Item> GetNotebookByType(string type)
		{
			LinkedList<Item> ans = GetProductByType("Notebook", type);
			return ans;
		}

		public LinkedList<Item> GetAllNotebookByType()
		{
			LinkedList<Item> ans = GetAllProductsByCategory("Notebook");
			return ans;
		}

		public  void AddNotebook(Item note)
		{
			AddItem(note);
		}

		/*********************************           Tablet        ******************************/

		public LinkedList<Item> GetTabletByType(string type)
		{
			LinkedList<Item> ans = GetProductByType("Tablet", type);
			return ans;
		}

		public LinkedList<Item> GetAllTabletByType()
		{
			LinkedList<Item> ans = GetAllProductsByCategory("Tablet");
			return ans;
		}

		public void AddTablet(Item tab)
		{
			AddItem(tab);
		}





		
	}
}