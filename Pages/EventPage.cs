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
namespace SeleniumAutoTesting.Pages
{
    class EventPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds

        [FindsBy(How = How.XPath, Using = "//*[@id='id - eadf3782 - 3988 - 30c9 - 8cd7 - 49d96c3ad5c6']/div[2]/div/div/ul/li[1]/h3/a")]
        [CacheLookup]
        private IWebElement eventLink;

        public EventPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void testEvent()
        {
            eventLink.Click();
        }

        public String getPageTitle()
        {
            return driver.Title;
        }

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
