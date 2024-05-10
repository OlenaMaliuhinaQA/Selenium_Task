using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SeleniumProject1
{
    public class Tests2
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            driver.Navigate().GoToUrl(@"https://www.epam.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCase("BLOCKCHAIN/Cloud/Automation")]
        public void Test2(string searchItem)
        {
           //2.	Find a magnifier icon and click on it
            driver.FindElement(By.XPath("//span[contains(@class, 'search-icon') and contains(@class, 'dark-iconheader-search__search-icon')]")).Click();

            //3.	Find a search string and put there “BLOCKCHAIN”/”Cloud”/”Automation” (use as a parameter for a test)
                    
            IWebElement inputElement = driver.FindElement(By.Id("new_form_search"));
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(d => inputElement.Displayed);
            inputElement.Clear();
            inputElement.SendKeys(searchItem);

            //4.Click “Find” button
            driver.FindElement(By.XPath("//span[contains(text(), 'Find')]")).Click();
          
            string htmlContent = "<div class=\"search-results__items\">...</div>";

            // Load the HTML content into an XElement
            XElement root = XElement.Parse(htmlContent);

            // Query to check if all <article> elements contain the specified words
            bool allContainWords = root.XPathSelectElements("//article")
                .All(article =>
                    article.Value.Contains("BLOCKCHAIN", StringComparison.OrdinalIgnoreCase) ||
                    article.Value.Contains("Cloud", StringComparison.OrdinalIgnoreCase) ||
                    article.Value.Contains("Automation", StringComparison.OrdinalIgnoreCase));

            // Assert if all <article> elements contain the specified words
            if (allContainWords)
            {
                Assert.Pass("All <article> elements contain the specified words.");
            }
            else
            {
                Assert.Fail("Not all <article> elements contain the specified words.");
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