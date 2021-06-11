using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace SeleniumTesting.Pages
{
    class Page
    {

        protected String test_url = "https://www.epam.com/";
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        // Go to the designated page
        public MainPage goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
            MainPage page = new MainPage(driver);
            return page;
        }

        public void goToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

 

    }
}

