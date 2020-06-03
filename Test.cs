using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.ObjectModel;
using System.Threading;
using Zavrsni_test_grupa_6.PageObject;

namespace Zavrsni_test_grupa_6
{
    class Test
    {
        IWebDriver driver;
        WebDriverWait wait;
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        [Test]
        public void TestRegistration()
        {
            HomePage naslovna = new HomePage(driver);
            RegisterPage registracija;
            naslovna.GoToPage();
            registracija = naslovna.Register();

            registracija.FirstName.SendKeys("Lara");
            registracija.LastName.SendKeys("Gagic");
            registracija.Email.SendKeys("lara@gama.comm");
            registracija.UserName.SendKeys("Happy");
            registracija.Password.SendKeys("TheCure20");
            registracija.ConfirmPassword.SendKeys("TheCure20");
            registracija.RegisterButton.Click();
        }
        [Test]
        public void TestLogIn()
        {
            HPSignIn naslovna = new HPSignIn (driver);
            LogIn registracija;
            naslovna.GoToPage();
            registracija = naslovna.SignButton();
            registracija.Username.SendKeys("Happy");
            registracija.Password.SendKeys("TheCure20");
            registracija.RegButton.Click();
        }
       
        [Test]
        public void TestQuant ()
        {   
            HPOrdercs orders = new HPOrdercs(driver);
            OrderPage chart = new OrderPage(driver);
            LogIn naslovna = new LogIn(driver);
            HPSignIn click = new HPSignIn(driver);
            orders.GoToPage();
            click.SignButton();
            naslovna.LogInUser("Happy", "TheCure20");
            orders.OrderQuantity(orders.QuantityOrder, "2");
            orders.OrderButton.Click();
            chart.ContinueButton();
            orders.OrderQuantity(orders.QuantityOrder, "1");
            orders.OrderButton.Click();
            chart.ClickCard();
            chart.CheckOutButton();
            chart.CheckHistory();


        }
    }
}
