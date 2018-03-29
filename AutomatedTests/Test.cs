using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomatedTests
{
    [TestFixture]
    public class Test
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"/Users/matuskollarcik/Desktop/Reviso/Reviso/Drivers", "chromedriver");
            service.Port = 64444;
            driver = new ChromeDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.Url = "http://localhost:5000/";
        }

        [Test]
        public void TestCase()
        {
            
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement input = driver.FindElement(By.Id("lst-ib"));
            input.SendKeys("Reviso bookkeeping");
            input.SendKeys(Keys.Enter);
            IWebElement firstResult = driver.FindElement(By.ClassName("bkWMgd"));
            firstResult.Click();

        }

        [TearDown]
        public void CleanUp()
        {
        }
    }
}
