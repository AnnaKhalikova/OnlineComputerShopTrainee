using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Mocks
{
    public interface IConnectionService
    {
        Item GetProductByID(int id);
        User GetUserByID(int id);
        bool ReduceQuantity(int id);
        void AddOrder(Ordder order);
        void AddProduct(Item pr);
        LinkedList<User> GetAllUsers();
        LinkedList<Item> GetProductByType(string category, string type);
        void EditProduct(int id, int price, int quant);
        LinkedList<Item> GetProductByName(string category, string name);
        bool DeleteProduct(LinkedList<Item> product);
    }
    
}