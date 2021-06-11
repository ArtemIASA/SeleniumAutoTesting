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
    class ContactPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds

        [FindsBy(How = How.XPath, Using = "//*[@id='_content_epam_en_about_who - we - are_contact_jcr_content_content - container_section_section - par_form_constructor_user_first_name']")]
        [CacheLookup]
        private IWebElement firstNameInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor']/div[3]/div/div[2]/button")]
        [CacheLookup]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='_content_epam_en_about_who -we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_last_name-error']")]
        [CacheLookup]
        private IWebElement errorMessage;

        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public String getPageTitle()
        {
            return driver.Title;
        }

        public bool checkPageError()
        {
            return errorMessage.Displayed;
        }

        public void test_input(String text) {
            firstNameInput.SendKeys(text);
            firstNameInput.Submit();
            submitButton.Click();
        }


        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
