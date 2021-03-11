using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Mocks
{
	public class DBConnectionClass: IConnectionService
	{
		public virtual User GetUserByID(int id)
		{
			return new User(1, "Hanna", "123456", "hanna@mail.ru", "Tablet", "For office work");	
		}
		public virtual Item GetProductByID(int id)
		{
			if (id == 1)
				return new Item(1, "Notebook", "Lenovo", 2, "LenovoIdeaPad.jpg", "Intel i5 ,8 GB ,500 GB SSD ", "01.09.2020", 1500, "Computer");
			else if (id == 2)
				return new Item(2, "Desktop", "Lenovo", 2, "LenovoIdeaPad.jpg", "Intel i5 ,Asus ,8 GB ,500 GB SSD ", "01.09.2020", 1500, "Computer");
			else if (id == 3)
				return new Item(1, "Tablet", "Lenovo", 2, "LenovoPad.jpg", "Intel i5", "01.09.2020", 1500, "Tablet for life");
			else if (id == 4)
				return new Item(1, "No", "Lenovo", 2, "LenovoPad.jpg", "Intel i5", "01.09.2020", 1500, "Tablet for life");
			else if (id == 5)
				return new Item(1, "Tablet", "Lenovo", 2, "LenovoPad.jpg", "", "01.09.2020", 1500, "Tablet for life");
			return null;
		}
		public bool ReduceQuantity(int id)
		{
			return true;
		}
		public void AddOrder(Ordder order)
		{

		}
		public void AddProduct(Item pr)
		{

		}
		public LinkedList<User> GetAllUsers()
		{
			LinkedList<User> listOfUsers = new LinkedList<User>();
			listOfUsers.AddLast(new User(1, "Hanna", "123456", "hanna@mail.ru", "Tablet", "For office work"));
			return listOfUsers;
		}
		public LinkedList<Item> GetProductByType(string category, string type)
		{
			LinkedList<Item> listOfItems = new LinkedList<Item>();
			listOfItems.AddLast(new Item(1, "Notebook", "Lenovo", 2, "LenovoIdeaPad.jpg", "Intel i5 ,8 GB ,500 GB SSD ", "01.09.2020", 1500, "Computer"));
			return listOfItems;
		}
		public void EditProduct(int id, int price, int quant)
		{

		}
		public LinkedList<Item> GetProductByName(string category, string name)
		{
			LinkedList<Item> listOfItems = new LinkedList<Item>();
			listOfItems.AddLast(new Item(1, "Notebook", "Lenovo", 2, "LenovoIdeaPad.jpg", "Intel i5 ,8 GB ,500 GB SSD ", "01.09.2020", 1500, "Computer"));
			return listOfItems;
		}
		public bool DeleteProduct(LinkedList<Item> product)
		{
			return true;
		}
	}
}