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
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs//");
        }
        public IWebElement KreirajKorisnika
        {
            get
            {
                IWebElement element;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.CssSelector("div:nth-of-type(2) > a"))); 
                    element = this.driver.FindElement(By.CssSelector("div:nth-of-type(2) > a"));
                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }
        public RegisterPage Register()
        {
            this.KreirajKorisnika?.Click();
            wait.Until(EC.ElementIsVisible(By.Name("ime")));
            return new RegisterPage(this.driver);
        }
    }
}
    

