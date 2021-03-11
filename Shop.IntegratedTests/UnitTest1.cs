using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatiN.Core;
using WatiN.Core.Native.Windows;
using Moq;
using Shop;
using Shop.Mocks;
using Shop.Entities;
using System.Data.SqlServerCe;
using System;

namespace Shop.IntegratedTests
{
    [TestClass]
    public class UnitTest1
    {
        //1 Itegrated Test 
        [TestMethod]
        public void ViewInfoAfterPageLoad_GoodData_NotebookStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);


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
            string actualResult = page.ViewInfo(1);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoAfterPageLoad_DesktopStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
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
            string actualResult = page.ViewInfo(2);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoAfterPageLoad_GoodData_TabletStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);

            string expectedResult =
                "<table class='buyTable' style='width: 80%;'>" +
                            "<tr><td rowspan='9'><img runat='server' src='" + "LenovoPad.jpg" + "' /></td>" +
                            "<td colspan='2' style='text-align:center'><b>" + "Tablet" + " " + "Tablet for life" + " " + "Lenovo" + "</b></td></tr>" +
                            "<tr colspan='2'><td>Proccessor</td><td>" + "Intel i5" + "</td></tr>" +
                        "</table>";
            //act
            string actualResult = page.ViewInfo(3);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoAfterPageLoad_GoodData_NoCategoryStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "Sorry this category of products doesnt exist.";
            //act
            string actualResult = page.ViewInfo(4);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoAfterPageLoad_NullItem_NoCategoryStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "Sorry this product doesnt exist.";
            //act
            string actualResult = page.ViewInfo(6);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ViewInfoAfterPageLoad_HasNoDescription_NoCategoryStringResult()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "Sorry, the model " + "Lenovo" + " haven't a description.";
            //act
            string actualResult = page.ViewInfo(5);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        //2 Integrated Test
        [TestMethod]
        public void SaveAddedProduct_GoodData_ProductAdded()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "Product was successfully added!";
            //act
            string actualResult = page.SaveProduct("Tablet", "LenovoPad.jpg",
                                                    "Tablet for office work", 
                                                    "1500", "Lenovo Tab 3", 
                                                    "Intel i5", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SaveAddedProduct_NullSelectedImage_MessageAboutEmptyField()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "One of fields is empty";
            //act
            string actualResult = page.SaveProduct("Tablet", null, "Tablet for office work",
                                                            "1500", "Lenovo Tab 3",
                                                            "Intel i5", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SaveAddedProduct_IncorrectPrice_WarningMessage()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "Price can't be negative";
            //act
            string actualResult = page.SaveProduct("Tablet", "LenovoPad.jpg",
                                                          "Tablet for office work",
                                                          "-1500", "Lenovo Tab 3",
                                                          "Intel i5", "1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SaveAddedProduct_IncorrectQuantity_WarningMessage()
        {
            //arrange
            LogicClass logicService = new LogicClass();
            PageLoad page = new PageLoad(logicService);
            string expectedResult = "Quantity must be zero or more";
            //act
            string actualResult = page.SaveProduct("Tablet", "LenovoPad.jpg",
                                                          "Tablet for office work",
                                                          "1500", "Lenovo Tab 3",
                                                          "Intel i5", "-1");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
