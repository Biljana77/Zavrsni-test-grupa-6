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
    class LogIn
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LogIn(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public IWebElement Username
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.Name("username"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public IWebElement Password
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.Name("password"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public IWebElement RegButton
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.Name("login"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public HomePage LogInUser (string username,string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            RegButton.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//div[@class='container']//h2[1]")));
            return new HomePage(this.driver);
        }
    }
}
