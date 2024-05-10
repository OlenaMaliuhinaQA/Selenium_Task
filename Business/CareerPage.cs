using OpenQA.Selenium;

public class CareerPage : BasePage
{
    public By keywordInput = By.XPath("//*[@id='new_form_job_search-keyword']");
    public By locationDropdown = By.XPath("//span[@class='select2-selection__arrow']");
    public By DropdownOptionByCountryName(string countryName) => By.XPath($"//li[@title='{countryName}']");
    public By remoteCheckBox = By.XPath("//input[@name='remote']");
    public By findButton = By.XPath("//button[@type='submit' and contains(text(),'Find')]");
}