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
    class RegisterPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        private SelectElement GetSelect(By by)
        {
            IWebElement element;
            SelectElement select;
            try
            {
                wait.Until(EC.ElementIsVisible(by));
                element = this.driver.FindElement(by);
                select = new SelectElement(element);
            }
            catch (Exception)
            {
                select = null;
            }
            return select;
        }
        public IWebElement FirstName
        {
            get
            {
                return this.GetElement(By.Name("ime"));
            }
        }
        public IWebElement LastName
        {
            get
            {
                return this.GetElement(By.Name("prezime"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.GetElement(By.Name("email"));
            }
        }
        public IWebElement UserName
        {
            get
            {
                return this.GetElement(By.Name("korisnicko"));
            }

        }
        public IWebElement Password
        {
            get
            {
                return this.GetElement(By.Name("lozinka"));
            }

        }
        public IWebElement ConfirmPassword
        {
            get
            {
                return this.GetElement(By.Name("lozinkaOpet"));
            }

        }
        public IWebElement RegisterButton
        {
            get
            {
                return this.GetElement(By.Name("register"));
            }
        }
    }
}
