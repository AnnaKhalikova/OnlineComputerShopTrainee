using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using WatiN.Core;
using WatiN.Core.Native.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Core;
using Shop;
using Selenium;
using System.Text;

namespace Shop.IntegratedTestsWithNUnit
{
    [TestFixture]
    public class Tests
    {
        public ISelenium selenium;
        [SetUp]
        public void Setup()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:4444/Accounts/Login");
            selenium.Start();
            var verificationErrors = new StringBuilder();
        }

        [Test]
        public void Test1()
        {
            
        }
    
    }
}