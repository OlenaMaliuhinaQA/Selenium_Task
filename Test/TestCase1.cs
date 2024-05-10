using OpenQA.Selenium;

namespace SeleniumProject1
{
    public class TestCase1 : BaseTest
    {
        [Test]
        [TestCase("Java", "All Cities in Spain")]
        public void Test1(string programmingLanguage, string location)
        { 
            BasePage basePage = new BasePage(); // creating an instance of the base page
            CareerPage careerPage = new CareerPage(); // creating an instance of the career page 
            
            driver.FindElement(basePage.acceptButton).Click(); // using the instance of basepage we are loking for the acceptbutton and then clicking on it
            driver.FindElement(basePage.careerTab).Click(); // click on career tab
            driver.FindElement(careerPage.keywordInput).SendKeys(programmingLanguage); // sending the programming language
            driver.FindElement(careerPage.locationDropdown).Click();
            driver.FindElement(careerPage.DropdownOptionByCountryName(location)).Click();
            driver.FindElement(careerPage.remoteCheckBox).Click();
            driver.FindElement(careerPage.findButton).Click();
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
    }
}