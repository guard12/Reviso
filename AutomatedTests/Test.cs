using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomatedTests
{
    [TestFixture()]
    public class Test
    {

        [Test]
        public void TestCase()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Close();
            //driver.FindElement();
        }
    }
}
