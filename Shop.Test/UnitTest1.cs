using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop;
using Shop.Entities;
using Shop.Mocks;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web;
using System.Data;
using System.Data.SqlServerCe;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Shop.Test
{
    [TestClass]
    public class UnitTest1
    {
        //Simple unit-tests
       //1 method
       [TestMethod]
        public void BuyItem_GoodData_EmptyString()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "Desktop", "Lenovo", 2,
                                                                            "LenovoIdeaPad.jpg",
                                                                            "Intel i5 ,Asus ,8 GB ,500 GB SSD ",
                                                                            "01.09.2020", 1500, "Computer"));
            mockConnectionClass.Setup(x => x.GetUserByID(1)).Returns(new User(1, "Hanna", "123456", 
                                                                             "hanna@mail.ru", "Tablet",
                                                                             "For office work"));
            //mockConnectionClass.Setup(x => x.AddOrder());
            mockConnectionClass.Setup(x => x.ReduceQuantity(1));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);
            string expectedResult = "";
            //act
            string actualResult = logicService.BuyItem(1, 1, "Dzergiskaga");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void BuyItem_ZeroItemQuantity_Message()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "Desktop", "Lenovo", 0,
                                                                                "LenovoIdeaPad.jpg", 
                                                                                "Intel i5 ,Asus ,8 GB ,500 GB SSD ",
                                                                                "01.09.2020", 1500, "Computer"));
            mockConnectionClass.Setup(x => x.GetUserByID(1)).Returns(new User(1, "Hanna", "123456",
                                                                              "hanna@mail.ru", "Tablet",
                                                                              "For office work"));
            mockConnectionClass.Setup(x => x.ReduceQuantity(1));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);
            string expectedResult = "Cannot buy this product. Please try other one.";
            //act
            string actualResult = logicService.BuyItem(1, 1, "Dzergiskaga");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        //2 method
        [TestMethod]
        public void GetDesktopProducts_Null_List_EmptyString()
        {
            //arrange
            LinkedList<Item> des = null;
            string expectedResult = "";
            //act
            string actualResult = LogicClass.GetDesktopProducts(des);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetDesktopProducts_Item_Is_null_EmptyString()
        {
            //arrange
            LinkedList<Item> des = new LinkedList<Item>();
            des.AddLast(new Item(1, null, null, 1, null, null, null, 100, null));
            string expectedResult = "";
            //act
            string actualResult = LogicClass.GetDesktopProducts(des);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void GetDesktopProducts_GoodData_Description()
        {
            //arrange
            LinkedList<Item> des = new LinkedList<Item>();
            des.AddLast(new Item(1, "Desktop", "Lenovo", 2, "LenovoIdeaPad.jpg", "Notebook for job", "01.09.2020",1500, "Computer"));
            string expectedResult = @"<table class='desktopTable'>" +
					"<tr><th rowspan='3' width='150px'><a href='/Buy.aspx?id=" + 1 + "'><img runat='server' src='" + "LenovoIdeaPad.jpg" + "' /></a></th>" +
					"<th width='50px'>Name: </td><td>" + "Computer" + " " + "Lenovo" + "</td>" +
					"<th rowspan='3' width='50px'>" +
					"<button type='button' onclick='redirect(" + 1 + ")' name='buy' class='css3button'>buy</button>" +
					"</th></tr><tr><th>Price: </th><td>" + 1500 + " $</td></tr>" +
					"<tr><th>Description: </th><td>" + "Notebook for job" + "</td></tr></table>";
            //act
            string actualResult = LogicClass.GetDesktopProducts(des);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        //3 method
        [TestMethod]
        public void ViewInfoBeforeBuyProduct__GoodData_StringResultDesktopCategory()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "Desktop", "Lenovo",
                                                                                 2, "LenovoIdeaPad.jpg",
                                                                                 "Intel i5 ,Asus ,8 GB ,500 GB SSD ",
                                                                                 "01.09.2020", 1500, "Computer"));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "<table class='buyTable'>" +
                            "<tr><td rowspan='9'><img runat='server' src='" + "LenovoIdeaPad.jpg" + "' /></td>" +
                            "<td colspan='2' style='text-align:center'><b>" + "Desktop" + " " + "Computer" + " " + "Lenovo" + "</b></td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>Proccessor</td><td>" + "Intel i5" + "</td></tr>" +
                            "<tr><td>Motherboard</td><td>" + "Asus" + "</td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>Video</td><td>NVIDIA GeForce GTX650 1GB</td></tr>" +
                            "<tr><td>RAM</td><td>" + "8 GB" + "</td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>Memory</td><td>" + "500 GB SSD" + "</td></tr>" +
                            "<tr><td>PSU</td><td>Seasonic 620W</td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>Disc Drive</td><td>LG SATA 22X SUPER-MULTI DVD Burner</td></tr>" +
                            "<tr><td>Warranty</td><td>15 Years</td></tr>" +
                        "</table>";
            //act
            string actualResult = logicService.ViewInfoBeforeBuyProduct(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoBeforeBuyProduct__GoodData_StringResultNotebookCategory()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "Notebook", "Lenovo", 
                                                                                 2, "LenovoIdeaPad.jpg", 
                                                                                 "Intel i5 ,8 GB ,500 GB SSD ",
                                                                                 "01.09.2020", 1500, "Computer"));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "<table class='buyTable' style='width: 80%;'>" +
                            "<tr><td rowspan='9'><img runat='server' src='" + "LenovoIdeaPad.jpg" + "' /></td>" +
                            "<td colspan='2' style='text-align:center'><b>" + "Notebook" + " " + "Computer" + " " + "Lenovo" + "</b></td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>Proccessor</td><td>" + "Intel i5" + "</td></tr>" +
                            "<tr><td>Video</td><td>Intel® HD Graphics</td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>RAM</td><td>" + "8 GB" + "</td></tr>" +
                            "<tr><td>Memory</td><td>" + "500 GB SSD" + "</td></tr>" +
                            "<tr bgcolor='#eeeeee'><td>Disc Drive</td><td>LG SATA 22X SUPER-MULTI DVD Burner</td></tr>" +
                            "<tr><td>Warranty</td><td>15 Years</td></tr>" +
                        "</table>";
            //act
            string actualResult = logicService.ViewInfoBeforeBuyProduct(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoBeforeBuyProduct__GoodData_StringResultTabletCategory()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "Tablet", "Lenovo", 
                                                                                 2, "LenovoPad.jpg",
                                                                                 "Intel i5", "01.09.2020", 
                                                                                  1500, "Tablet for life"));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult =
                "<table class='buyTable' style='width: 80%;'>" + 
                            "<tr><td rowspan='9'><img runat='server' src='" + "LenovoPad.jpg" + "' /></td>" +
                            "<td colspan='2' style='text-align:center'><b>" + "Tablet" + " " + "Tablet for life" + " " + "Lenovo" + "</b></td></tr>" +
                            "<tr colspan='2'><td>Proccessor</td><td>" + "Intel i5" + "</td></tr>" +
                        "</table>"; 
            //act
            string actualResult = logicService.ViewInfoBeforeBuyProduct(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoBeforeBuyProduct__GoodData_StringResultNoCategory()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "No", "Lenovo", 2,
                                                                                "LenovoPad.jpg", "Intel i5",
                                                                                "01.09.2020", 1500,
                                                                                "Tablet for life"));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Sorry this category of products doesnt exist.";
            //act
            string actualResult = logicService.ViewInfoBeforeBuyProduct(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoBeforeBuyProduct__NullItem_ProductDoesntExist()

        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(() => null);
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Sorry this product doesnt exist.";
            //act
            string actualResult = logicService.ViewInfoBeforeBuyProduct(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoBeforeBuyProduct__HasNoDescription_StringItemHasNoDescription()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByID(1)).Returns(new Item(1, "Tablet", "Lenovo", 
                                                                                 2, "LenovoPad.jpg", "",
                                                                                 "01.09.2020", 1500, 
                                                                                 "Tablet for life"));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Sorry, the model " + "Lenovo" + " haven't a description.";
            //act
            string actualResult = logicService.ViewInfoBeforeBuyProduct(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        //4 method
        [TestMethod]
        public void AddProduct_GoodData_ProductAdded()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.AddProduct(It.IsAny<Item>()));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Product was successfully added!";
            //act
            string actualResult = logicService.AddProduct("Tablet", "LenovoPad.jpg",
                                                          "Tablet for office work", 
                                                          "1500", "Lenovo Tab 3", 
                                                          "Intel i5", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void AddProduct__NullSelectedImage_MessageAboutEmptyField()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.AddProduct(It.IsAny<Item>()));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "One of fields is empty";
            //act
            string actualResult = logicService.AddProduct("Tablet", null, "Tablet for office work",
                                                            "1500", "Lenovo Tab 3", 
                                                            "Intel i5", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void AddProduct_IncorrectPrice_WarningMessage()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.AddProduct(It.IsAny<Item>()));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Price can't be negative";
            //act
            string actualResult = logicService.AddProduct("Tablet", "LenovoPad.jpg",
                                                          "Tablet for office work",
                                                          "-1500", "Lenovo Tab 3",
                                                          "Intel i5", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void AddProduct_IncorrectQuantity_WarningMessage()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.AddProduct(It.IsAny<Item>()));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Quantity must be zero or more";
            //act
            string actualResult = logicService.AddProduct("Tablet", "LenovoPad.jpg",
                                                          "Tablet for office work", 
                                                          "1500", "Lenovo Tab 3", 
                                                          "Intel i5", "-1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        //5 method
        [TestMethod]
        public void ConvertToNumber_NumberInString_NumberInt()
        {
            //arrange
            int expectedResult = 7;
            LogicClass logicService = new LogicClass();
            //act
            int actualResult = logicService.ConvertToNumber("7");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ConvertToNumber_IncorrectString_CodeError()
        {
            //arrange
            int expectedResult = -1;
            LogicClass logicService = new LogicClass();
            //act
            int actualResult = logicService.ConvertToNumber("7O");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //PARAMETRIZED TESTS
        //1 test
        [DataTestMethod]
        [DataRow("h@m", true)]
        [DataRow("nika@gmail.com", true)]
        [DataRow("hanna.khalikova@gmail", true)]
        [DataRow("a.i.khalikova&mail.ru", false)]
        public void IsEmail(string email, bool expectedResult)
        {
            //arrange
            LogicClass logicService = new LogicClass();
            //act
            bool actualResult = logicService.IsEmail(email);
            //assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        //2 test
        [DataTestMethod]
        [DataRow("Hanna", true)]
        [DataRow("Nika", true)]
        [DataRow("Darya", false)]
        [DataRow("", false)]
        public void IsUserExist(string userName, bool expectedResult)
        {
            //arrange
            var listOfUsers = new LinkedList<User>();
            listOfUsers.AddLast(new User(1, "Hanna", "123456", "hanna@mail.ru", "Tablet", "For office work"));
            listOfUsers.AddLast(new User(2, "Nika", "123456", "nika@mail.ru", "Desktop", "For office work"));
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetAllUsers()).Returns(listOfUsers);

            LogicClass logicService = new LogicClass(mockConnectionClass.Object);
            //act
            bool actualResult = logicService.IsUserExist(userName);
            //assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        //3 test
        [DataTestMethod]
        [DataRow("123456", 123456)]
        [DataRow("5478 69", -1)]
        [DataRow("21 25 23 69", -1)]
        [DataRow("7854-147", -1)]
        [DataRow("123-456-147", -1)]
        public void GetCreditNumber(string number, string expectedResult)
        {
            //arrange
            LogicClass logicService = new LogicClass();
            //act
            string actualResult = logicService.GetCreditNumber(number);
            //assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        //4 test
        [DataTestMethod]
        [DataRow("12", 12)]
        [DataRow("5478 69", -1)]
        [DataRow("21", 21)]
        [DataRow("785", 785)]
        [DataRow("123-456-147", -1)]
        public void ConvertToNumber(string number, int expectedResult)
        {
            //arrange
            LogicClass logicService = new LogicClass();
            //act
            int actualResult = logicService.ConvertToNumber(number);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        //5 test
        [DataTestMethod]
        [DataRow("Tablet", "LenovoPad.jpg","Tablet for office work","1500", "Lenovo Tab 3","Intel i5", "1", "Product was successfully added!")]
        [DataRow("Tablet", null, "Tablet for office work","1500", "Lenovo Tab 3", "Intel i5", "1", "One of fields is empty")]
        [DataRow("Tablet", "LenovoPad.jpg","Tablet for office work","-1500", "Lenovo Tab 3","Intel i5", "1", "Price can't be negative")]
        [DataRow("Tablet", "LenovoPad.jpg","Tablet for office work", "1500", "Lenovo Tab 3", "Intel i5", "-1", "Quantity must be zero or more")]
        public void AddProduct(string category, string selectedImage, string txtType, string txtPrice,
                                                    string txtName, string txtDescription, string txtQuant, string expectedResult)
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.AddProduct(It.IsAny<Item>()));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);
            //act
            string actualResult = logicService.AddProduct(category, selectedImage, txtType, txtPrice,
                                                     txtName, txtDescription, txtQuant);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //TDD
        //1 test
        [TestMethod]
        public void EditProduct_GoodData_StringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            string expectedResult = "Product was successfully edited!";
            //act
            string actualResult = logicService.EditProduct(1, "Notebook", "LenovoPad.jpg", "Intel i5", "1500", "Lenovo IdeaPad", "Tablet for office work", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void EditProduct_OneEmptyString_WarningStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            string expectedResult = "One of fields is empty";
            //act
            string actualResult = logicService.EditProduct(1,"Notebook", "LenovoPad.jpg", "Intel i5", "1500", "Lenovo IdeaPad", "Tablet for office work", "");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void EditProduct_NegativePrice_WarningStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            string expectedResult = "Price can't be negative";
            //act
            string actualResult = logicService.EditProduct(1,"Notebook", "LenovoPad.jpg", "Intel i5", "-1500", "Lenovo IdeaPad", "Tablet for office work", "5");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void EditProduct_NegativeQuantity_WarningStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();

            string expectedResult = "Product was successfully edited!";
            //act
            string actualResult = logicService.EditProduct(1, "Notebook", "LenovoPad.jpg", "Intel i5", "1500", "Lenovo IdeaPad", "Tablet for office work", "5");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void EditProduct_GoodDataAndConnection_GoodStringResult()
        {
            //arrange
            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.EditProduct(1, 1500, 5));
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            string expectedResult = "Product was successfully edited!";
            //act
            string actualResult = logicService.EditProduct(1, "Notebook", "LenovoPad.jpg", "Intel i5", "1500", "Lenovo IdeaPad", "Tablet for office work", "5");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        // 2 test
        [TestMethod]
        public void DeleteProduct()
        {
            //arrange
            var itemList = new LinkedList<Item>();
            itemList.AddLast(new Item(1, "Notebook", "Lenovo", 2, "LenovoPad.jpg", "Intel i5", "01.09.2020", 1500, "Tablet for life"));

            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByName("Notebook", "Lenovo")).Returns(itemList);
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);
            bool expectedResult = false;
            //act
            bool actualResult = logicService.DeleteProduct("Notebook", "Lenovo IdeaPad");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void DeleteProduct_EmptyName_FalseResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            bool expectedResult = false;
            //act
            bool actualResult = logicService.DeleteProduct("Notebook", "");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void DeleteProduct_GoodData_TrueResult()
        {
            //arrange
            var itemList = new LinkedList<Item>();
            itemList.AddLast(new Item(1, "Notebook", "Lenovo", 2,"LenovoPad.jpg", "Intel i5","01.09.2020", 1500,"Tablet for life"));

            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByName("Notebook", "Lenovo")).Returns(itemList);
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            bool expectedResult = true;
            //act
            bool actualResult = logicService.DeleteProduct("Notebook", "Lenovo");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void DeleteProduct_DeleteWithGoodData_TrueResult()
        {
            //arrange
            var itemList = new LinkedList<Item>();
            itemList.AddLast(new Item(1, "Notebook", "Lenovo", 2, "LenovoPad.jpg", "Intel i5", "01.09.2020", 1500, "Tablet for life"));

            var mockConnectionClass = new Mock<IConnectionService>();
            mockConnectionClass.Setup(x => x.GetProductByName("Notebook", "Lenovo")).Returns(itemList);
            mockConnectionClass.Setup(x => x.DeleteProduct(itemList)).Returns(true);
            LogicClass logicService = new LogicClass(mockConnectionClass.Object);

            bool expectedResult = true;
            //act
            bool actualResult = logicService.DeleteProduct("Notebook", "Lenovo");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
