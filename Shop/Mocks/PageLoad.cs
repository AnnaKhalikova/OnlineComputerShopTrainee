using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Shop.Mocks
{
    public class PageLoad
    {
        static IConnectionService service;
        LogicClass logic = new LogicClass(service);

        public PageLoad(LogicClass logic)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ViewInfo(int ProductID)
        {
            return logic.ViewInfoBeforeBuyProduct(ProductID);
        }

        public string SaveProduct(string category, string selectedImage, string txtType, string txtPrice, string txtName, string txtDescription, string txtQuant)
        {
            return logic.AddProduct(category, selectedImage, txtType, txtPrice, txtName, txtDescription, txtQuant);
        }

    }
}