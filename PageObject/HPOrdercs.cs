using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.ObjectModel;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Zavrsni_test_grupa_6.PageObject
{
    class HPOrdercs
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HPOrdercs(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs//");
        }
        public IWebElement Order
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//div[@class='container']//h2[1]"));


                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }

        public void OrderQuantity(IWebElement element, string quantity)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(quantity);
        }
        public IWebElement QuantityOrder
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.CssSelector("div:nth-of-type(4) > div:nth-of-type(2) form[method='post']  select[name='quantity']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
            public IWebElement OrderButton
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.CssSelector("div:nth-of-type(4) > div:nth-of-type(2) form[method='post']  .btn.btn-primary"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
             public OrderPage ClickOrder()
        {
            this.OrderButton?.Click();
            wait.Until(EC.ElementIsVisible(By.CssSelector("tr > th:nth-of-type(1)")));
            return new OrderPage(this.driver);
        }
    }

    
}