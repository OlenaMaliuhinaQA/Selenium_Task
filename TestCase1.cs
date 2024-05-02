using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject1
{
    public class TestCase1
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        [TestCase("Java", "All Cities in Spain")]
        public void Test1(string programmingLanguage, string location)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(@"https://www.epam.com/");

            driver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);          
           
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
            driver.Quit();

            //IWebElement accept_cookies = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            //accept_cookies.Click();

            //IWebElement link = driver.FindElement(By.XPath("//a[text()='Careers']"));
            //link.Click();

            //IWebElement carriersearch = driver.FindElement(By.XPath("//*[@id='new_form_job_search-keyword']"));
            //carriersearch.SendKeys("Java");
            //carriersearch.SendKeys(Keys.Return);

            //IWebElement all_cities_dropdown = driver.FindElement(By.XPath("//span[@class='select2-selection__arrow']"));
            //all_cities_dropdown.Click();

            //IWebElement all_cities_in_spain_option = driver.FindElement(By.XPath("//li[@title='All Cities in Spain']"));
            //all_cities_in_spain_option.Click();

            //IWebElement select_remote = driver.FindElement(By.XPath("//label[contains(@class, 'recruiting-search__filter-label-23') and contains(@class, 'checkbox-custom-label') and contains(@class, 'body-text-small')]"));
            //select_remote.Click();

            //IWebElement find_button = driver.FindElement(By.XPath("//button[contains(@class, 'small-button-text small-button-transparent-preset center-background-preset small-round-gradient-border job-search-button-transparent-23')]"));
            //find_button.Click();    

        }
    }
}