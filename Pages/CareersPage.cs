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
    class CareersPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds
        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[3]/section/div/div[2]/div/form/div[1]")]
        [CacheLookup]
        private IWebElement keywordPanel;

        [FindsBy(How = How.Id, Using = "new_form_job_search_1445745853_copy-keyword")]
        [CacheLookup]
        private IWebElement keywordTextPanel;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[3]/section/div/div[2]/div/form/div[3]/div/div[1]")]
        [CacheLookup]
        private IWebElement skillsList;

        [FindsBy(How = How.XPath, Using = "//*[@id='jobSearchFilterForm']/div[3]/div/div[2]/div/ul[2]/li[4]/label/span")]
        [CacheLookup]
        private IWebElement softwareEngineerCheck;

        [FindsBy(How = How.XPath, Using = "//*[@id='jobSearchFilterForm']/button")]
        [CacheLookup]
        private IWebElement findButton;


        [FindsBy(How = How.ClassName, Using = "//*[@id='main']/div[1]/div[1]/section/div/div/div/section/ul/li[1]/div[2]/div/div")]
        [CacheLookup]
        private IWebElement firstLink;


        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/main/div[1]/div[3]/section/div/div[2]/div/form/fieldset/div/p[3]")]
        [CacheLookup]
        private IWebElement remoteCheck;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[1]/section/div[2]/div/div/ul/li")]
        [CacheLookup]
        private IWebElement tag;



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

        public SearchPage test_search(string input_search)
        {
            load_complete();
            keywordPanel.Click();
            //keywordPanel.SendKeys(input_search);
            //keywordPanel.Submit();
            keywordTextPanel.SendKeys(input_search);
            keywordTextPanel.Submit();
            //wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit_button)).Submit();
            //elem_search_text.Submit();
            //searchButton.Click();
            return new SearchPage(driver);
        }

        public SearchPage test_searchSkills()
        {
            skillsList.Click();
            softwareEngineerCheck.Click();
            skillsList.Submit();
            return new SearchPage(driver);
        }

        public void test_button()
        {
            findButton.Click();
        }

        public bool test_search_results()
        {
            return tag.Displayed;
        }
  
    }
}
