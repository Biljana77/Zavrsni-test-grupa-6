using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.ObjectModel;
using System.Threading;

namespace Zavrsni_test_grupa_6.PageObject
{
    class OrderPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public IWebElement NewOrder
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.CssSelector("form[method='post'] > .btn.btn-default"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public HomePage ContinueButton()
        {
            this.NewOrder?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//div[@class='container']//h2[1])")));
            return new HomePage(this.driver);
            //input[@name='checkout']
        }
        public IWebElement CheckOut
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//input[@name='checkout']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public HomePage CheckOutButton()
        {
            this.CheckOut?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/']")));
            return new HomePage(this.driver);

        }
        public IWebElement ViewShopping
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/cart']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public HomePage ClickCard()
        {
            this.ViewShopping?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//table")));
            return new HomePage(this.driver);

        }
        public IWebElement ViewHistory
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/history']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public HomePage CheckHistory()
        {
            this.ViewHistory?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//table")));
            return new HomePage(this.driver);

        }
        public IWebElement OrderCheck
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/history']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
    }
}
