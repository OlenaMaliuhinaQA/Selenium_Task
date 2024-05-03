using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject1
{
    public class TestCase1
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Navigate().GoToUrl(@"https://www.epam.com/");
            driver.Manage().Window.Maximize();

        }
        [Test]
        [TestCase("Java", "All Cities in Spain")]
        public void Test1(string programmingLanguage, string location)
        {      
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            driver.FindElement(By.XPath("//a[text()='Careers']")).Click();
            driver.FindElement(By.XPath("//*[@id='new_form_job_search-keyword']")).SendKeys(programmingLanguage);
            driver.FindElement(By.XPath("//span[@class='select2-selection__arrow']")).Click();
            driver.FindElement(By.XPath("//li[@title='All Cities in Spain']")).Click();
            driver.FindElement(By.XPath("//label[contains(@class, 'recruiting-search__filter-label-23') and contains(@class, 'checkbox-custom-label') and contains(@class, 'body-text-small')]")).Click();
            driver.FindElement(By.XPath("//button[contains(@class, 'small-button-text small-button-transparent-preset center-background-preset small-round-gradient-border job-search-button-transparent-23')]")).Click();
            driver.FindElement(By.XPath("//ul[@class=\"search-result__list\"]/li[last()]")).Click();

            // Find all search result items
            var searchResultItems = driver.FindElements(By.XPath("//ul[@class='search-result__list']/li[contains(@class, 'search-result__item')]"));

            // Find the last search result item
            IWebElement lastSearchResultItem = searchResultItems[searchResultItems.Count - 1];

            // Find the "View and apply" button within the last search result item
            IWebElement viewAndApplyButton = lastSearchResultItem.FindElement(By.XPath(".//a[contains(@class, 'search-result__item-apply-23')]"));

            // Click on the "View and apply" button
            viewAndApplyButton.Click();

            IWebElement vacancyContent = driver.FindElement(By.XPath("//div[@class='vacancy-details-23__vacancy-content vacancy_content']"));
            // bool containsProgrammingLanguage = vacancyContent != null && vacancyContent.Text.ToLower().Contains(programmingLanguage.ToLower());
            bool containsProgrammingLenguage = vacancyContent.Text.Contains(programmingLanguage);
            //Assert.Pass("The vacancy content contains {}");

            if (containsProgrammingLenguage)
            {
                Assert.Pass("The vacancy content contains the programming language.");
            }
            else
            {
                Assert.Fail($"The vacancy content does not contain the programming language '{programmingLanguage}'.");
            }
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}