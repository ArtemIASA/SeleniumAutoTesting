using System;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutoTesting.Pages;
using SeleniumTesting.Pages;
using TechTalk.SpecFlow;

namespace SeleniumAutoTesting.StepDefinitions
{
    [Binding]
    public class EpamTestSteps
    {
        IWebDriver driver;
        MainPage page;
        CareersPage careersPage;
        ContactPage contactPage;
        SearchPage searchPage;

        [Given(@"I am at ""(.*)"" page")]
        public void GivenIAmAtPage(string p0)
        {
            driver = new ChromeDriver();
            page = new MainPage(driver);
            page.goToPage(p0);
        }

        [Given(@"I choose ""(.*)"" skills")]
        public void GivenIChooseSkills(string p0)
        {
            careersPage = new CareersPage(driver);
            careersPage.test_searchSkills();
        }

        [When(@"I write ""(.*)"" as keyword and press search")]
        public void WhenIWriteAsKeywordAndPressSearch(string p0)
        {
            searchPage = page.test_search(p0);
            searchPage.load_complete();
      

        }

        [When(@"I write ""(.*)"" as name and press submit")]
        public void WhenIWriteAsNameAndPressSubmit(int p0)
        {
            contactPage = new ContactPage(driver);
            contactPage.test_input(p0.ToString());
        }

        [When(@"I click on ""(.*)"" option")]
        public void WhenIClickOnOption(string p0)
        {
            page.test_translate();
            page.load_complete();
        }

        [When(@"I click on ""(.*)"" page")]
        public void WhenIClickOnPage(string p0)
        {
            ServicesPage servicesPage = page.test_services();
            servicesPage.load_complete();
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string p0)
        {
            careersPage.test_button();
        }

        [When(@"I click on ""(.*)"" image")]
        public void WhenIClickOnImage(string p0)
        {
            page.test_mexico();
        }

        [When(@"I choose ""(.*)"" icon")]
        public void WhenIChooseIcon(string p0)
        {
            page.test_inst();
        }

        [When(@"I click on ""(.*)"" link")]
        public void WhenIClickOnLink(string p0)
        {
            EventPage eventPage = page.test_event();
            eventPage.testEvent();
        }



        [Then(@"the ""(.*)"" search results should be on the screen")]
        public void ThenTheSearchResultsShouldBeOnTheScreen(string p0)
        {
            Assert.That(searchPage.getPageTitle().Contains(p0) || driver.Url.ToLower().Contains(p0), Is.True);
        }
        
        [Then(@"I get error message")]
        public void ThenIGetErrorMessage()
        {
            Assert.That(contactPage.checkPageError(), Is.True);
        }
        
        [Then(@"I get redirect to ""(.*)""")]
        public void ThenIGetRedirectTo(string p0)
        {
            Assert.That(page.getUrl().Contains(p0) || p0.ToLower().Contains(page.getUrl().ToLower()), Is.True);
            
        }
        
        [Then(@"I get Software Engineering jobs")]
        public void ThenIGetSoftwareEngineeringJobs()
        {
            Assert.That(careersPage.test_search_results(), Is.True);
        }
        
        [Then(@"I get ""(.*)"" office info")]
        public void ThenIGetOfficeInfo(string p0)
        {
            Assert.That(page.check_mexico(), Is.True);
        }
    }
}
