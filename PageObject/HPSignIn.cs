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
    class HPSignIn
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HPSignIn(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs//");
        }
        public IWebElement SignIn
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/login']"));


                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }
        public LogIn SignButton()
        {
            this.SignIn?.Click();
            wait.Until(EC.ElementIsVisible(By.Name("username")));
            return new LogIn(this.driver);
        }
    }
}
