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
using SeleniumAutoTesting.Pages;

namespace SeleniumTesting.Pages
{
    class MainPage 
    {

        protected String test_url = "https://www.epam.com/";
        protected IWebDriver driver;
        protected WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds

        public MainPage(IWebDriver driver)
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

        public String getUrl()
        {
            return driver.Url;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/div[2]/div[1]/header/div/div/button")]
        [CacheLookup]
        private IWebElement menuButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div[2]/button/span")]
        [CacheLookup]
        private IWebElement acceptButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[3]/div")]
        [CacheLookup]
        private IWebElement searchIcon;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_form_search']")]
        [CacheLookup]
        private IWebElement searchPanel;

        [FindsBy(How = How.ClassName, Using = "header-search__submit")]
        [CacheLookup]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/services']")]
        [CacheLookup]
        private IWebElement servicesButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/header/div/div/nav/div/button")]
        [CacheLookup]
        private IWebElement languagesIcon;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/header/div/div/nav/div/nav/ul/li[9]/a")]
        [CacheLookup]
        private IWebElement russiaLangButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/careers']")]
        [CacheLookup]
        private IWebElement careersButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[3]/div[1]/footer/div/div[2]/ul[2]/li[4]/a")]
        [CacheLookup]
        private IWebElement instagramButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/div[1]/div[10]/section/div[2]/div[2]/div/div[2]/div/div/div[1]/div[1]/div/div[4]/div/button/div[1]")]
        [CacheLookup]
        private IWebElement mexicoButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/div[1]/div[10]/section/div[2]/div[2]/div/div[2]/div/div/div[2]/div[2]/h2")]
        [CacheLookup]  
        private IWebElement mexicoInfo;
        public String getSearchText()
        {
            return searchPanel.Text;
        }


        public SearchPage test_search(string input_search)
        {
            searchIcon.Click();
            searchPanel.Click();
            searchPanel.SendKeys(input_search);
            searchPanel.Submit();
            return new SearchPage(driver);
        }

        public EventPage test_event()
        {
            return new EventPage(driver);
        }

        public ServicesPage test_services()
        {
            menuButton.Click();
            acceptButton.Click();
            servicesButton.Click();
            return new ServicesPage(driver);
        }

        public void test_translate()
        {
            menuButton.Click();
            acceptButton.Click();
            languagesIcon.Click();
            russiaLangButton.Click();  
        }

        public void test_inst()
        {
            acceptButton.Click();
            instagramButton.Click();
        }

        public void test_mexico()
        {
            acceptButton.Click();
            mexicoButton.Click();
        }

        public bool check_mexico()
        {
            return mexicoInfo.Displayed;
        }
        
        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }


    }
}
